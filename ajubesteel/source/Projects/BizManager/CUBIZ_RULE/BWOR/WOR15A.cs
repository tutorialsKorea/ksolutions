using BizExecute;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BWOR
{
    public class WOR15A
    {
        public static DataSet WOR15A_SER(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", "0", typeof(Byte));
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "HIRE_DATE_MONTH", "REQ_MONTH");
                //사원정보 조회
                DataTable dtEmpRslt = DSTD.TSTD_EMPLOYEE_QUERY.TSTD_EMPLOYEE_QUERY8(paramDS.Tables["RQSTDT"], bizExecute);

                //정례화시간 조회
                DataTable dtIdleRslt = DSTD.TSTD_IDLETIME_QUERY.TSTD_IDLETIME_QUERY2(paramDS.Tables["RQSTDT"], bizExecute);


                //사원별 연차(W05)/반차(W06) 조회
                //일단위로 변경
                //월별 사용수 집계
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "REQ_STATUS", "2", typeof(string));
                DataTable dtWorkMngRslt = DSHP.TSHP_WORK_MNG_QUERY.TSHP_WORK_MNG_QUERY5(paramDS.Tables["RQSTDT"], bizExecute);

                DataTable dtHoliRslt = DLSE.LSE_HOLIDAY_QUERY.LSE_HOLIDAY_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);

                DataTable dtWorkTimeRslt = DSTD.TSTD_WORKTIME_QUERY.TSTD_WORKTIME_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);

                //일단위로 변경
                //DataRow[] dayRows = dtWorkMngRslt.Select("WORK_CODE = 'W05'");

                //foreach (DataRow row in dayRows)
                //{
                //    int days = row["REQ_TIME"].toInt() / 480;

                //    for (int i = 0; i < days; i++)
                //    {
                //        DateTime reqDateTime = row["REQ_START_DATE"].toDateTime().AddDays(i);
                //        DataRow[] hRows = dtHoliRslt.Select("HOLI_DATE = '" + reqDateTime.toDateString("yyyyMMdd") + "'");

                //        if (hRows.Length > 0
                //            || reqDateTime.DayOfWeek == DayOfWeek.Saturday
                //            || reqDateTime.DayOfWeek == DayOfWeek.Sunday)
                //        {
                //            days++;
                //            continue;
                //        }

                //        DataRow newRow = dtWorkMngRslt.NewRow();
                //        newRow.ItemArray = row.ItemArray;

                //        newRow["STR_REQ_DATE"] = reqDateTime.toDateString("yyyyMMdd");
                //        newRow["REQ_START_DATE"] = reqDateTime;
                //        newRow["REQ_END_DATE"] = reqDateTime;
                //        newRow["REQ_TIME"] = 480;

                //        dtWorkMngRslt.Rows.Add(newRow);
                //    }

                //    dtWorkMngRslt.Rows.Remove(row);
                //}


                dtEmpRslt.Columns.Add("NON_TIME", typeof(decimal));
                dtEmpRslt.Columns.Add("OVER_TIME1", typeof(decimal));
                dtEmpRslt.Columns.Add("OVER_TIME2", typeof(decimal));
                dtEmpRslt.Columns.Add("OVER_TIME3", typeof(decimal));
                dtEmpRslt.Columns.Add("HOLI_DATE", typeof(decimal));
                dtEmpRslt.Columns.Add("TOTAL_TIME", typeof(decimal));


                //연차&반차일수 집계
                DataRow[] dayRows = dtWorkMngRslt.Select("WORK_CODE IN ('W05', 'W06')");

                foreach (DataRow row in dayRows)
                {
                    DataRow[] holiMonthRows = dtEmpRslt.Select("EMP_CODE = '" + row["EMP_CODE"].ToString() + "'");

                    if (holiMonthRows.Length == 0) continue;

                    double oneDayTime = 480;

                    holiMonthRows[0]["HOLI_DATE"] = Math.Round(holiMonthRows[0]["HOLI_DATE"].toDouble() + (row["REQ_TIME"].toDouble() / oneDayTime), 1);
                }

                


                //사원별 연장근로내역 조회
                //잔업(W08), 교대(W09), 특근(W10), 휴일교대(W11)
                //야근근무제외 월별 근로내역 집계
                DataRow[] Rows = dtWorkMngRslt.Select("WORK_CODE IN ('W08','W09','W10','W11')");
                foreach (DataRow row in Rows)
                {

                    //근무형태에 따른 주,야간 정례화 시간을 가져온다.
                    DataTable idleTable = new DataTable("RQSTDT");
                    idleTable.Columns.Add("PLT_CODE", typeof(string));
                    idleTable.Columns.Add("EMP_CODE", typeof(string));
                    idleTable.Columns.Add("WORK_YEAR", typeof(string));
                    idleTable.Columns.Add("EWT_DATE", typeof(string));

                    DataRow idleRow = idleTable.NewRow();
                    idleRow["PLT_CODE"] = ConnInfo.PLT_CODE;
                    idleRow["EMP_CODE"] = row["EMP_CODE"];
                    idleRow["WORK_YEAR"] = row["REQ_START_DATE"].toDateTime().ToString("yyyy");
                    idleRow["EWT_DATE"] = row["REQ_START_DATE"].toDateTime().ToString("yyyyMMdd");

                    idleTable.Rows.Add(idleRow);
                    DataSet idleSet = new DataSet();
                    idleSet.Tables.Add(idleTable);

                    DataSet resultSet = WOR01A.WOR01A_SER10(idleSet, bizExecute);

                    //IDLE_FLAG - 0 : 주간 , 1 : 야간
                    string idleFillter = "IDLE_FLAG = '0'";

                    if (resultSet.Tables["RSLTDT"].Rows.Count > 0)
                    {
                        if (resultSet.Tables["RSLTDT"].Rows[0]["EWT_TYPE"].ToString() == "1")
                        {
                            idleFillter = "IDLE_FLAG = '1'";
                        }
                    }

                    //휴일교대일 경우 강제 야간근무자
                    if (row["WORK_CODE"].ToString() == "W11")
                    {
                        idleFillter = "IDLE_FLAG = '1'";
                    }

                    //기준시간의 교집합구하기
                    //1.신청시간에 기준시간 시작시간과 종료시간이 포함된경우
                    //2.기준시작시간이 신청시간 사이에 있는경우
                    //3.기준시간에 신청시간 시작시간과 종료시간이 포함된경우
                    //5.기준종료시간이 신청시간 사이에 있는경우
                    DataRow[] workRows = dtWorkTimeRslt.Select("WORK_CODE = '" + row["WORK_CODE"].ToString() + "'");

                    Dictionary<string, bool> nextdaydic = new Dictionary<string, bool>();

                    if (!nextdaydic.ContainsKey(row["WORK_CODE"].ToString()))
                    {
                        nextdaydic.Add(row["WORK_CODE"].ToString(), false);
                    }
                    else
                    {
                        nextdaydic[row["WORK_CODE"].ToString()] = false;
                    }

                    //휴일교대(W11) 확인용
                    // 해당일에 20:30 ~ 05:30 근무가 없을경우 1.5로계산
                    Dictionary<string, double> workDic = new Dictionary<string, double>();

                    double rate = 0.0;
                    double rateTime = 0.0;
                    double prevTime = 0.0;
                    double prevRateTIme = 0.0;

                    bool isClear = false;


                    DataTable dtWork = workRows.CopyToDataTable();

                    dtWork.Columns.Add("WORK_USE_TIME", typeof(double));

                    double totalReqTime = 0;

                    int iSeq = 1;
                    foreach (DataRow workRow in workRows)
                    {

                        //if (rateTime == 0.0 || isClear == true)
                        //{
                        //    rateTime = workRow["WORK_TIME"].toDouble();
                        //    rate = workRow["WORK_RATE"].toDouble();

                        //    isClear = false;
                        //}

                        DateTime reqStartDateTime = row["REQ_START_DATE"].toDateTime();
                        DateTime reqEndDateTime = row["REQ_END_DATE"].toDateTime();

                        DateTime stdStartDate = new DateTime(reqStartDateTime.Year, reqStartDateTime.Month, reqStartDateTime.Day, workRow["WORK_START_HOUR"].ToString().Substring(0, 2).toInt(), workRow["WORK_START_HOUR"].ToString().Substring(2, 2).toInt(), 0);
                        DateTime stdEndDate = new DateTime(reqStartDateTime.Year, reqStartDateTime.Month, reqStartDateTime.Day, workRow["WORK_END_HOUR"].ToString().Substring(0, 2).toInt(), workRow["WORK_END_HOUR"].ToString().Substring(2, 2).toInt(), 0);

                        if (nextdaydic[row["WORK_CODE"].ToString()])
                        {
                            stdStartDate = stdStartDate.AddDays(1);
                            stdEndDate = stdEndDate.AddDays(1);
                        }

                        //종료시간이 작을경우 하루 더함
                        if (workRow["WORK_START_HOUR"].ToString().Substring(0, 2).toInt() > workRow["WORK_END_HOUR"].ToString().Substring(0, 2).toInt())
                        {
                            stdEndDate = stdEndDate.AddDays(1);

                            nextdaydic[row["WORK_CODE"].ToString()] = true;
                        }

                        DataRow[] IdleRslt = dtIdleRslt.Select(idleFillter);

                        TimeSpan ts = new TimeSpan();
                        double time = 0.0;
                        //시간 교집합 구분
                        if (reqStartDateTime <= stdStartDate && reqEndDateTime >= stdEndDate) //신청시간에 기준시간 시작시간과 종료시간이 포함된경우
                        {
                            ts = stdEndDate.Subtract(stdStartDate);
                            time = ts.TotalMinutes;
                            time = time - GetIdleTime(stdStartDate, stdEndDate, IdleRslt.CopyToDataTable());
                            //newRow[row["WORK_CODE"].ToString() + "_" + iSeq.ToString()] = Math.Round(((newRow[row["WORK_CODE"].ToString() + "_" + iSeq.ToString()].toDouble() * 60) + ts.TotalMinutes).toDecimal() / 60, 1);
                        }
                        else if (reqStartDateTime <= stdStartDate && reqEndDateTime >= stdStartDate) //기준시작시간이 신청시간 사이에 있는경우
                        {
                            ts = reqEndDateTime.Subtract(stdStartDate);
                            time = ts.TotalMinutes;
                            time = time - GetIdleTime(stdStartDate, reqEndDateTime, IdleRslt.CopyToDataTable());
                            //newRow[row["WORK_CODE"].ToString() + "_" + iSeq.ToString()] = Math.Round(((newRow[row["WORK_CODE"].ToString() + "_" + iSeq.ToString()].toDouble() * 60) + ts.TotalMinutes).toDecimal() / 60, 1);
                        }
                        else if (stdStartDate <= reqStartDateTime && stdEndDate >= reqEndDateTime) //기준시간에 신청시간 시작시간과 종료시간이 포함된경우
                        {
                            ts = reqEndDateTime.Subtract(reqStartDateTime);
                            time = ts.TotalMinutes;
                            time = time - GetIdleTime(reqStartDateTime, reqEndDateTime, IdleRslt.CopyToDataTable());
                            //newRow[row["WORK_CODE"].ToString() + "_" + iSeq.ToString()] = Math.Round(((newRow[row["WORK_CODE"].ToString() + "_" + iSeq.ToString()].toDouble() * 60) + ts.TotalMinutes).toDecimal() / 60, 1);
                        }
                        else if (reqStartDateTime <= stdEndDate && reqEndDateTime >= stdEndDate) //기준종료시간이 신청시간 사이에 있는경우
                        {
                            ts = stdEndDate.Subtract(reqStartDateTime);
                            time = ts.TotalMinutes;
                            time = time - GetIdleTime(reqStartDateTime, stdEndDate, IdleRslt.CopyToDataTable());
                            //newRow[row["WORK_CODE"].ToString() + "_" + iSeq.ToString()] = Math.Round(((newRow[row["WORK_CODE"].ToString() + "_" + iSeq.ToString()].toDouble() * 60) + ts.TotalMinutes).toDecimal() / 60, 1);
                        }

                        if (time > 0)
                        {
                            /*
                                        OVER_TIME1 : 연장근무(A)/1.5
                                        OVER_TIME2 : 연장근무(B)/0.5
                                        OVER_TIME3 : 연장근무(C)/1

                                        //가중치 분배
                                        0.5 -> 0.5
                                        1.0 -> 1.0
                                        1.5 -> 1.5
                                        2.0 -> 1.5, 0.5
                                        2.5 -> 1.5, 1.0
                            */

                            DataRow[] holiMonthRows = dtEmpRslt.Select("EMP_CODE = '" + row["EMP_CODE"].ToString() + "'");

                            if (holiMonthRows.Length == 0)
                            {
                                continue;
                            }

                            double hourTime = Math.Round((time).toDecimal() / 60, 1).toDouble();

                            /*
                              특근/휴일교대(야간)일경우에는 앞에 비어있는시간을 채워서 계산
                              그리고 특근 22시 이후 앞에 시간이 8시간이 안되면 2.0, 되면 2.5
                              그리고 휴일교대(야간) 6시 이후 앞에 시간이 8시간이 안되면 1.5, 되면 2.0

                            EX)
                              가중치    1.5      2      2.5      2
                              시간시작  8:30	18:00	22:00	6:00
                              시간종료  17:30	22:00	6:00	8:00
                              총시간     8      4       6.5      2

                              특근신청시간이 9:30 ~ 00:30(익일)
                                1.5 -> 8, 2 -> 3, 2.5 -> 2.5
                              

                            */
                            if (workRow["WORK_CODE"].ToString() == "W10"
                                || workRow["WORK_CODE"].ToString() == "W11")
                            {
                                //if (rateTime - prevRateTIme >= hourTime + prevTime)
                                //{
                                //    hourTime = hourTime + prevTime;
                                //    rate = workRow["WORK_RATE"].toDouble();
                                //    prevTime = 0.0;
                                //    prevRateTIme = 0.0;
                                //    isClear = true;
                                //}
                                //else
                                //{
                                //    hourTime = rateTime;
                                //    prevTime = rateTime - hourTime + prevTime;
                                //}

                                double tempHourTime = hourTime;


                                foreach (DataRow wRow in dtWork.Rows)
                                {
                                    if (wRow["WORK_TIME"].toDouble() == wRow["WORK_USE_TIME"].toDouble())
                                    {
                                        continue;
                                    }

                                    double wRate = wRow["WORK_RATE"].toDouble();

                                    if (workRow["IS_EIGHT_TIME_PLUS"].ToString() == "1")
                                    {
                                        if (workRow["WORK_CODE"].ToString() == "W10")
                                        {
                                            if (totalReqTime >= 8)
                                            {
                                                wRate = 2.5;
                                            }
                                            else
                                            {
                                                wRate = 2.0;
                                            }
                                        }
                                        else if (workRow["WORK_CODE"].ToString() == "W11")
                                        {
                                            if (totalReqTime >= 8)
                                            {
                                                wRate = 2.0;
                                            }
                                            else
                                            { 
                                                wRate = 1.5;
                                            }
                                        }
                                        
                                    }

                                    if (wRow["WORK_TIME"].toDouble() - wRow["WORK_USE_TIME"].toDouble() >= tempHourTime)
                                    {
                                        //totalReqTime = totalReqTime + tempHourTime;

                                        wRow["WORK_USE_TIME"] = wRow["WORK_USE_TIME"].toDouble() + tempHourTime;

                                        SetTime(wRate, holiMonthRows, tempHourTime);

                                        //totalReqTime = totalReqTime + wRow["WORK_USE_TIME"].toDouble();
                                        totalReqTime = totalReqTime + tempHourTime;
                                        break;
                                    }
                                    else
                                    {
                                        SetTime(wRate, holiMonthRows, wRow["WORK_TIME"].toDouble() - wRow["WORK_USE_TIME"].toDouble());

                                        tempHourTime = tempHourTime - (wRow["WORK_TIME"].toDouble() - wRow["WORK_USE_TIME"].toDouble());

                                        totalReqTime = totalReqTime + wRow["WORK_TIME"].toDouble() - wRow["WORK_USE_TIME"].toDouble();

                                        wRow["WORK_USE_TIME"] = wRow["WORK_TIME"].toDouble();

                                    }
                                }
                            }
                            else
                            { 
                                rate = workRow["WORK_RATE"].toDouble();

                                switch (rate)
                                {
                                    case 0.5:

                                        holiMonthRows[0]["OVER_TIME2"] = holiMonthRows[0]["OVER_TIME2"].toDouble() + Math.Round((time).toDecimal() / 60, 1).toDouble();

                                        break;

                                    case 1.0:

                                        holiMonthRows[0]["OVER_TIME3"] = holiMonthRows[0]["OVER_TIME3"].toDouble() + Math.Round((time).toDecimal() / 60, 1).toDouble();

                                        break;

                                    case 1.5:

                                        holiMonthRows[0]["OVER_TIME1"] = holiMonthRows[0]["OVER_TIME1"].toDouble() + Math.Round((time).toDecimal() / 60, 1).toDouble();

                                        break;

                                    case 2.0:

                                        //휴일근무시 6시 이전근무가 8시간이 안되면 1.5로 계산
                                        if (workRow["WORK_CODE"].ToString() == "W11")
                                        {
                                            if (workRow["WORK_START_HOUR"].ToString() == "0600")
                                            {
                                                if (workDic[row["EMP_CODE"].ToString()] < 8)
                                                {
                                                    holiMonthRows[0]["OVER_TIME1"] = holiMonthRows[0]["OVER_TIME1"].toDouble() + Math.Round((time).toDecimal() / 60, 1).toDouble();
                                                }
                                                else
                                                {
                                                    holiMonthRows[0]["OVER_TIME1"] = holiMonthRows[0]["OVER_TIME1"].toDouble() + Math.Round((time).toDecimal() / 60, 1).toDouble();
                                                    holiMonthRows[0]["OVER_TIME2"] = holiMonthRows[0]["OVER_TIME2"].toDouble() + Math.Round((time).toDecimal() / 60, 1).toDouble();
                                                }
                                            }
                                            else
                                            {
                                                holiMonthRows[0]["OVER_TIME1"] = holiMonthRows[0]["OVER_TIME1"].toDouble() + Math.Round((time).toDecimal() / 60, 1).toDouble();
                                                holiMonthRows[0]["OVER_TIME2"] = holiMonthRows[0]["OVER_TIME2"].toDouble() + Math.Round((time).toDecimal() / 60, 1).toDouble();
                                            }
                                        }
                                        else
                                        {
                                            holiMonthRows[0]["OVER_TIME1"] = holiMonthRows[0]["OVER_TIME1"].toDouble() + Math.Round((time).toDecimal() / 60, 1).toDouble();
                                            holiMonthRows[0]["OVER_TIME2"] = holiMonthRows[0]["OVER_TIME2"].toDouble() + Math.Round((time).toDecimal() / 60, 1).toDouble();
                                        }

                                        break;

                                    case 2.5:

                                        holiMonthRows[0]["OVER_TIME1"] = holiMonthRows[0]["OVER_TIME1"].toDouble() + Math.Round((time).toDecimal() / 60, 1).toDouble();
                                        holiMonthRows[0]["OVER_TIME3"] = holiMonthRows[0]["OVER_TIME3"].toDouble() + Math.Round((time).toDecimal() / 60, 1).toDouble();

                                        break;
                                }
                            }

                            if (workRow["WORK_CODE"].ToString() == "W10"
                                || workRow["WORK_CODE"].ToString() == "W11")
                            {
                                if (!workDic.ContainsKey(row["EMP_CODE"].ToString()))
                                {
                                    workDic.Add(row["EMP_CODE"].ToString(), Math.Round((time).toDecimal() / 60, 1).toDouble());
                                }
                                else
                                {
                                    workDic[row["EMP_CODE"].ToString()] = workDic[row["EMP_CODE"].ToString()].toDouble() + Math.Round((time).toDecimal() / 60, 1).toDouble();
                                }
                            }
                        }
                        iSeq++;
                    }

                    if (workDic.ContainsKey(row["EMP_CODE"].ToString()))
                    {
                        workDic[row["EMP_CODE"].ToString()] = 0;
                    }
                }



                //지각, 외출, 조퇴, 무급
                DataRow[] wRows = dtWorkMngRslt.Select("WORK_CODE IN ('W01','W02','W03','W04')");
                foreach (DataRow row in wRows)
                {
                    DataRow[] nonTimeRows = dtEmpRslt.Select("EMP_CODE = '" + row["EMP_CODE"].ToString() + "'");
                    if (nonTimeRows.Length > 0)
                    {

                        foreach (DataColumn col in dtEmpRslt.Columns)
                        {
                            string colName = col.ColumnName;
                            
                            if (nonTimeRows.Length > 0 && colName == "NON_TIME")
                            {
                                nonTimeRows[0][col.ColumnName] = Math.Round(((nonTimeRows[0][col.ColumnName].toDouble()) + row["REQ_TIME"].toDouble()), 2);
                            }
                        }
                    }
                }


                dtEmpRslt.Columns.Add("NO_TIME", typeof(decimal));

                dtEmpRslt.Columns.Add("REAL_TOTAL_TIME", typeof(decimal));
                dtEmpRslt.Columns.Add("SUB_TOTAL_TIME", typeof(decimal));

                foreach (DataRow row in dtEmpRslt.Rows)
                {
                    if (row["PAY_CONTRACT"].ToString() == "01")
                    {
                        row["NO_TIME"] = 52;
                    }

                    row["TOTAL_TIME"] = Math.Round(row["OVER_TIME1"].toDecimal() + row["OVER_TIME2"].toDecimal() + row["OVER_TIME3"].toDecimal(), 1);


                    if (row["TOTAL_TIME"].toDecimal() <= 0)
                    {
                        row["TOTAL_TIME"] = 0;
                    }

                    decimal overtime1 = row["OVER_TIME1"].toDecimal() - row["NO_TIME"].toDecimal();

                    row["SUB_TOTAL_TIME"] = Math.Round(overtime1, 1);

                    if (overtime1 < 0)
                    {
                        overtime1 = 0;
                    }

                    row["REAL_TOTAL_TIME"] = Math.Round(overtime1 + row["OVER_TIME2"].toDecimal() + row["OVER_TIME3"].toDecimal(), 1);
                }

                dtEmpRslt.TableName = "RSLTDT";
                paramDS.Tables.Add(dtEmpRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        static void SetTime(double rate, DataRow[] holiMonthRows, double hourTime)
        {
            switch (rate)
            {
                case 0.5:

                    holiMonthRows[0]["OVER_TIME2"] = holiMonthRows[0]["OVER_TIME2"].toDouble() + hourTime;

                    break;

                case 1.0:

                    holiMonthRows[0]["OVER_TIME3"] = holiMonthRows[0]["OVER_TIME3"].toDouble() + hourTime;

                    break;

                case 1.5:

                    holiMonthRows[0]["OVER_TIME1"] = holiMonthRows[0]["OVER_TIME1"].toDouble() + hourTime;

                    break;

                case 2.0:

                    holiMonthRows[0]["OVER_TIME1"] = holiMonthRows[0]["OVER_TIME1"].toDouble() + hourTime;
                    holiMonthRows[0]["OVER_TIME2"] = holiMonthRows[0]["OVER_TIME2"].toDouble() + hourTime;

                    break;

                case 2.5:

                    holiMonthRows[0]["OVER_TIME1"] = holiMonthRows[0]["OVER_TIME1"].toDouble() + hourTime;
                    holiMonthRows[0]["OVER_TIME3"] = holiMonthRows[0]["OVER_TIME3"].toDouble() + hourTime;

                    break;
            }
        }

        static int GetIdleTime(DateTime startDate, DateTime endDate, DataTable idelTable)
        {
            int idleTime = 0;

            foreach (DataRow row in idelTable.Rows)
            {
                string sIdleHour = row["IDLE_START_TIME"].ToString().Substring(0, 2);
                string sIdleMinute = row["IDLE_START_TIME"].ToString().Substring(2, 2);

                string eIdleHour = row["IDLE_END_TIME"].ToString().Substring(0, 2);
                string eIdleMinute = row["IDLE_END_TIME"].ToString().Substring(2, 2);

                DateTime idleStartTime = new DateTime(startDate.Year, startDate.Month, startDate.Day, sIdleHour.toInt(), sIdleMinute.toInt(), 0);
                DateTime idleEndTime = new DateTime(startDate.Year, startDate.Month, startDate.Day, eIdleHour.toInt(), eIdleMinute.toInt(), 0);

                if (startDate.Day != endDate.Day && (sIdleHour.toInt() >= 0 && sIdleHour.toInt() <= 7))
                {
                    idleStartTime = idleStartTime.AddDays(1);
                    idleEndTime = idleEndTime.AddDays(1);
                }

                TimeSpan idleTs = new TimeSpan();

                if (idleStartTime < startDate && idleEndTime > startDate)
                {
                    //정례화 시작시간이 신청시작시간보다 작거나 같고 정례화 종료시간이 신청시작시간보다 클떄
                    idleTs = idleEndTime.Subtract(startDate);

                }
                else if (idleStartTime >= startDate && idleEndTime <= endDate)
                {
                    //정례화 시작시간 종료시간이 신청시간사이에 포함될때
                    idleTs = idleEndTime.Subtract(idleStartTime);
                }
                else if (idleStartTime < endDate && idleEndTime > endDate)
                {
                    //정례화 시작시간이 신청종료시간보다 작고 정례화 종료시간이 신청종료시간보다 클때
                    idleTs = endDate.Subtract(idleStartTime);
                }
                else if (idleStartTime <= startDate && idleEndTime >= endDate)
                {
                    //정례화 시간이 신청시간보다 클때
                    idleTs = endDate.Subtract(startDate);
                }

                idleTime = idleTime + idleTs.TotalMinutes.toInt();
            }

            return idleTime;
        }
    }
}
