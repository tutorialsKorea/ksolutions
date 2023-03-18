using BizExecute;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BWOR
{
    public class WOR03A
    {
        public static DataSet WOR03A_SER(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", "0", typeof(Byte));
                //사원정보 조회
                DataTable dtEmpRslt = DSTD.TSTD_EMPLOYEE_QUERY.TSTD_EMPLOYEE_QUERY8(paramDS.Tables["RQSTDT"], bizExecute);

                //정례화시간 조회
                DataTable dtIdleRslt = DSTD.TSTD_IDLETIME_QUERY.TSTD_IDLETIME_QUERY2(paramDS.Tables["RQSTDT"], bizExecute);

                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "YEAR", "REQ_YEAR");

                UTIL.SetBizAddColumnToValue(dtEmpRslt, "COMPARE_YEAR", 0, typeof(int));
                UTIL.SetBizAddColumnToValue(dtEmpRslt, "IS_USE", "1", typeof(string));

                UTIL.SetBizAddColumnToValue(dtEmpRslt, "CNT_HOLI", 0, typeof(decimal));
                UTIL.SetBizAddColumnToValue(dtEmpRslt, "REMAIN_HOLI", 0, typeof(decimal));
                UTIL.SetBizAddColumnToValue(dtEmpRslt, "ACCOUNT_CALC_YEAR", "", typeof(string));

                foreach (DataRow row in dtEmpRslt.Rows)
                {
                    DataTable dtEmpHoli = DSTD.TSTD_EMP_HOLI_QUERY.TSTD_EMP_HOLI_QUERY2(UTIL.GetRowToDt(row), bizExecute);

                    //UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "COMPARE_YEAR", paramDS.Tables["RQSTDT"].Rows[0]["YEAR"].toInt() - DateTime.Now.Year, typeof(int));
                    row["COMPARE_YEAR"] = paramDS.Tables["RQSTDT"].Rows[0]["YEAR"].toInt() - DateTime.Now.Year;

                    if (dtEmpHoli.Rows.Count > 0
                        && row["COMPARE_YEAR"].toInt() != 0)
                    {
                        //UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "IS_USE", DBNull.Value, typeof(string));
                        //UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "ACCOUNT_CALC_YEAR", (dtEmpHoli.Rows[0]["ACCOUNT_CALC_YEAR"].toInt() + row["COMPARE_YEAR"].toInt()).ToString(), typeof(string));

                        row["IS_USE"] = DBNull.Value;
                        row["ACCOUNT_CALC_YEAR"] = (dtEmpHoli.Rows[0]["ACCOUNT_CALC_YEAR"].toInt() + row["COMPARE_YEAR"].toInt()).ToString();

                        dtEmpHoli = DSTD.TSTD_EMP_HOLI_QUERY.TSTD_EMP_HOLI_QUERY2(UTIL.GetRowToDt(row), bizExecute);
                    }

                    if (dtEmpHoli.Rows.Count > 0)
                    {
                        row["CNT_HOLI"] = dtEmpHoli.Rows[0]["HOLI_OCCUR_INPUT_CNT"];
                        row["REMAIN_HOLI"] = dtEmpHoli.Rows[0]["HOLI_OCCUR_INPUT_CNT"];
                    }
                }


                //사원별 연차(W05)/반차(W06) 조회
                //일단위로 변경
                //월별 사용수 집계
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "REQ_STATUS", "2", typeof(string));
                //UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "OR_WORK_CODE1", "W05", typeof(string));
                //UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "OR_WORK_CODE2", "W06", typeof(string));
                DataTable dtWorkMngRslt = DSHP.TSHP_WORK_MNG_QUERY.TSHP_WORK_MNG_QUERY5(paramDS.Tables["RQSTDT"], bizExecute);

                DataTable dtHoliRslt = DLSE.LSE_HOLIDAY_QUERY.LSE_HOLIDAY_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);
                //dtHoliRslt.TableName = "RSLTDT_HOLI";
                //paramDS.Tables.Add(dtHoliRslt);

                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "YEAR", "REQ_YEAR");
                DataTable workDayRslt = DSTD.TSTD_WORKDAY.TSTD_WORKDAY_SER2(paramDS.Tables["RQSTDT"], bizExecute);

                double qtMaxTime1 = 0.0;
                double qtMaxTime2 = 0.0;
                double qtMaxTime3 = 0.0;
                double qtMaxTime4 = 0.0;

                double qtDayTime1 = 0.0;
                double qtDayTime2 = 0.0;
                double qtDayTime3 = 0.0;
                double qtDayTime4 = 0.0;

                foreach (DataRow wdRow in workDayRslt.Rows)
                {
                    if (wdRow["WORK_MONTH"].ToString().Substring(4, 2) == "01"
                        || wdRow["WORK_MONTH"].ToString().Substring(4, 2) == "02"
                        || wdRow["WORK_MONTH"].ToString().Substring(4, 2) == "03")
                    {
                        qtMaxTime1 = Math.Round(qtMaxTime1 + wdRow["WORK_MONTH_TIME"].toDouble(),2);
                        qtDayTime1 = Math.Round(qtDayTime1 + wdRow["WORK_HOUR"].toDouble(), 2);
                    }
                    else if (wdRow["WORK_MONTH"].ToString().Substring(4, 2) == "04"
                        || wdRow["WORK_MONTH"].ToString().Substring(4, 2) == "05"
                        || wdRow["WORK_MONTH"].ToString().Substring(4, 2) == "06")
                    {
                        qtMaxTime2 = Math.Round(qtMaxTime2 + wdRow["WORK_MONTH_TIME"].toDouble(), 2);
                        qtDayTime2 = Math.Round(qtDayTime2 + wdRow["WORK_HOUR"].toDouble(), 2);
                    }
                    else if (wdRow["WORK_MONTH"].ToString().Substring(4, 2) == "07"
                        || wdRow["WORK_MONTH"].ToString().Substring(4, 2) == "08"
                        || wdRow["WORK_MONTH"].ToString().Substring(4, 2) == "09")
                    {
                        qtMaxTime3 = Math.Round(qtMaxTime3 + wdRow["WORK_MONTH_TIME"].toDouble(), 2);
                        qtDayTime3 = Math.Round(qtDayTime3 + wdRow["WORK_HOUR"].toDouble(), 2);
                    }
                    else if (wdRow["WORK_MONTH"].ToString().Substring(4, 2) == "10"
                        || wdRow["WORK_MONTH"].ToString().Substring(4, 2) == "11"
                        || wdRow["WORK_MONTH"].ToString().Substring(4, 2) == "12")
                    {
                        qtMaxTime4 = Math.Round(qtMaxTime4 + wdRow["WORK_MONTH_TIME"].toDouble(), 2);
                        qtDayTime4 = Math.Round(qtDayTime4 + wdRow["WORK_HOUR"].toDouble(), 2);
                    }
                }

                DataTable dtWorkTimeRslt = DSTD.TSTD_WORKTIME_QUERY.TSTD_WORKTIME_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);

                //일단위로 변경
                DataRow[] dayRows = dtWorkMngRslt.Select("WORK_CODE = 'W05'");

                foreach (DataRow row in dayRows)
                {
                    int days = row["REQ_TIME"].toInt() / 480;

                    for (int i = 0; i < days; i++)
                    {
                        DateTime reqDateTime = row["REQ_START_DATE"].toDateTime().AddDays(i);
                        DataRow[] hRows = dtHoliRslt.Select("HOLI_DATE = '" + reqDateTime.toDateString("yyyyMMdd") + "'");

                        if (hRows.Length > 0
                            || reqDateTime.DayOfWeek == DayOfWeek.Saturday
                            || reqDateTime.DayOfWeek == DayOfWeek.Sunday)
                        {
                            days++;
                            continue;
                        }

                        DataRow newRow = dtWorkMngRslt.NewRow();
                        newRow.ItemArray = row.ItemArray;

                        newRow["STR_REQ_DATE"] = reqDateTime.toDateString("yyyyMMdd");
                        newRow["REQ_START_DATE"] = reqDateTime;
                        newRow["REQ_END_DATE"] = reqDateTime;
                        newRow["REQ_TIME"] = 480;

                        dtWorkMngRslt.Rows.Add(newRow);
                    }

                    dtWorkMngRslt.Rows.Remove(row);
                }



                //월별 사용수 집계
                //DataTable dtHoliMonth = new DataTable();
                //dtEmpRslt.Columns.Add("EMP_CODE", typeof(string));
                dtEmpRslt.Columns.Add("USE_HOLI", typeof(decimal));
                //dtEmpRslt.Columns.Add("REMAIN_HOLI", typeof(decimal));
                dtEmpRslt.Columns.Add("HOLI_TIME", typeof(decimal));
                dtEmpRslt.Columns.Add("HOLI_1", typeof(decimal));
                dtEmpRslt.Columns.Add("HOLI_2", typeof(decimal));
                dtEmpRslt.Columns.Add("HOLI_3", typeof(decimal));
                dtEmpRslt.Columns.Add("HOLI_4", typeof(decimal));
                dtEmpRslt.Columns.Add("HOLI_5", typeof(decimal));
                dtEmpRslt.Columns.Add("HOLI_6", typeof(decimal));
                dtEmpRslt.Columns.Add("HOLI_7", typeof(decimal));
                dtEmpRslt.Columns.Add("HOLI_8", typeof(decimal));
                dtEmpRslt.Columns.Add("HOLI_9", typeof(decimal));
                dtEmpRslt.Columns.Add("HOLI_10", typeof(decimal));
                dtEmpRslt.Columns.Add("HOLI_11", typeof(decimal));
                dtEmpRslt.Columns.Add("HOLI_12", typeof(decimal));

                dtEmpRslt.Columns.Add("WORK_1", typeof(decimal));
                dtEmpRslt.Columns.Add("WORK_2", typeof(decimal));
                dtEmpRslt.Columns.Add("WORK_3", typeof(decimal));
                dtEmpRslt.Columns.Add("WORK_4", typeof(decimal));
                dtEmpRslt.Columns.Add("WORK_5", typeof(decimal));
                dtEmpRslt.Columns.Add("WORK_6", typeof(decimal));
                dtEmpRslt.Columns.Add("WORK_7", typeof(decimal));
                dtEmpRslt.Columns.Add("WORK_8", typeof(decimal));
                dtEmpRslt.Columns.Add("WORK_9", typeof(decimal));
                dtEmpRslt.Columns.Add("WORK_10", typeof(decimal));
                dtEmpRslt.Columns.Add("WORK_11", typeof(decimal));
                dtEmpRslt.Columns.Add("WORK_12", typeof(decimal));

                dtEmpRslt.Columns.Add("HM_1", typeof(decimal));
                dtEmpRslt.Columns.Add("HM_2", typeof(decimal));
                dtEmpRslt.Columns.Add("HM_3", typeof(decimal));
                dtEmpRslt.Columns.Add("HM_4", typeof(decimal));
                dtEmpRslt.Columns.Add("HM_5", typeof(decimal));
                dtEmpRslt.Columns.Add("HM_6", typeof(decimal));
                dtEmpRslt.Columns.Add("HM_7", typeof(decimal));
                dtEmpRslt.Columns.Add("HM_8", typeof(decimal));
                dtEmpRslt.Columns.Add("HM_9", typeof(decimal));
                dtEmpRslt.Columns.Add("HM_10", typeof(decimal));
                dtEmpRslt.Columns.Add("HM_11", typeof(decimal));
                dtEmpRslt.Columns.Add("HM_12", typeof(decimal));

                dtEmpRslt.Columns.Add("QUARTER_1", typeof(decimal));
                dtEmpRslt.Columns.Add("QUARTER_2", typeof(decimal));
                dtEmpRslt.Columns.Add("QUARTER_3", typeof(decimal));
                dtEmpRslt.Columns.Add("QUARTER_4", typeof(decimal));

                //총사용연차
                //double totalHoliDays = 0.0;
                Dictionary<string, double> empTotalHoliDic = new Dictionary<string, double>();

                DataRow[] holiRows = dtWorkMngRslt.Select("WORK_CODE IN ('W05','W06')");

                foreach (DataRow row in holiRows)
                {
                    //DataRow[] holiMonthRows = dtHoliMonth.Select("EMP_CODE = '" + row["EMP_CODE"].ToString() + "'");
                    //if (holiMonthRows.Length == 0)
                    //{
                    //    DataRow newRow = dtHoliMonth.NewRow();
                    //    newRow["EMP_CODE"] = row["EMP_CODE"];

                    //    dtHoliMonth.Rows.Add(newRow);
                    //}

                    DataRow[] holiMonthRows = dtEmpRslt.Select("EMP_CODE = '" + row["EMP_CODE"].ToString() + "'");

                    if (!empTotalHoliDic.ContainsKey(row["EMP_CODE"].ToString()))
                    {
                        empTotalHoliDic.Add(row["EMP_CODE"].ToString(), 0);
                    }

                    foreach (DataColumn col in dtEmpRslt.Columns)
                    {
                        string colName = col.ColumnName;
                        if (colName.IndexOf("HOLI_") > -1)
                        {
                            string[] colNames = colName.Split('_');
                            colName = colNames[1];
                        }

                        if (colName == row["STR_REQ_DATE"].ToString().Substring(4, 2).toInt().ToString()
                            && holiMonthRows.Length > 0)
                        {
                            holiMonthRows[0][col.ColumnName] = holiMonthRows[0][col.ColumnName].toDouble() + (row["REQ_TIME"].toDouble() / 480.0);

                            empTotalHoliDic[row["EMP_CODE"].ToString()] = empTotalHoliDic[row["EMP_CODE"].ToString()] + (row["REQ_TIME"].toDouble() / 480.0);
                            holiMonthRows[0]["USE_HOLI"] = empTotalHoliDic[row["EMP_CODE"].ToString()];
                            holiMonthRows[0]["REMAIN_HOLI"] = holiMonthRows[0]["CNT_HOLI"].toDouble() - empTotalHoliDic[row["EMP_CODE"].ToString()];
                        }
                    }
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

                    int iSeq = 1;
                    foreach (DataRow workRow in workRows)
                    {
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
                            //야간근무를 제외한 연장 누계시간
                            if (workRow["NIGHT_FLAG_52"].ToString() != "1")
                            {
                                //DataRow[] holiMonthRows = dtHoliMonth.Select("EMP_CODE = '" + row["EMP_CODE"].ToString() + "'");
                                //if (holiMonthRows.Length == 0)
                                //{
                                //    DataRow newRow = dtHoliMonth.NewRow();
                                //    newRow["EMP_CODE"] = row["EMP_CODE"];

                                //    dtHoliMonth.Rows.Add(newRow);
                                //}

                                DataRow[] holiMonthRows = dtEmpRslt.Select("EMP_CODE = '" + row["EMP_CODE"].ToString() + "'");

                                foreach (DataColumn col in dtEmpRslt.Columns)
                                {
                                    string colName = col.ColumnName;
                                    if (colName.IndexOf("WORK_") > -1)
                                    {
                                        string[] colNames = colName.Split('_');
                                        colName = colNames[1];
                                    }

                                    if (colName == row["STR_REQ_DATE"].ToString().Substring(4, 2).toInt().ToString()
                                        && holiMonthRows.Length > 0)
                                    {
                                        holiMonthRows[0][col.ColumnName] = holiMonthRows[0][col.ColumnName].toDouble() + Math.Round((time).toDecimal() / 60, 1).toDouble();

                                        //totalHoliDays = totalHoliDays + holiMonthRows[0]["HOLI_" + col.ColumnName].toDouble();
                                    }
                                }
                            }
                            //else
                            //{
                            //    if (sumDic.ContainsKey("NIGHT_TIME"))
                            //    {
                            //        sumDic["NIGHT_TIME"] = sumDic["NIGHT_TIME"] + newRow[row["WORK_CODE"].ToString() + "_" + iSeq.ToString()].toDecimal();
                            //    }
                            //    else
                            //    {
                            //        sumDic.Add("NIGHT_TIME", newRow[row["WORK_CODE"].ToString() + "_" + iSeq.ToString()].toDecimal());
                            //    }
                            //}
                        }
                        iSeq++;
                    }
                }

                //사원별 분기별 잔여시간 조회
                //지,조,외출,연차,반차 시간
                DataRow[] wRows = dtWorkMngRslt.Select("WORK_CODE IN ('W01','W02','W03','W04','W05','W06','W07')");
                foreach (DataRow row in wRows)
                {
                    DataRow[] holiMonthRows = dtEmpRslt.Select("EMP_CODE = '" + row["EMP_CODE"].ToString() + "'");
                    if (holiMonthRows.Length > 0)
                    {

                        foreach (DataColumn col in dtEmpRslt.Columns)
                        {
                            string colName = col.ColumnName;
                            if (colName.IndexOf("HM_") > -1)
                            {
                                string[] colNames = colName.Split('_');
                                colName = colNames[1];
                            }

                            if (colName == row["STR_REQ_DATE"].ToString().Substring(4, 2).toInt().ToString()
                                && holiMonthRows.Length > 0)
                            {
                                holiMonthRows[0][col.ColumnName] = Math.Round(((holiMonthRows[0][col.ColumnName].toDouble() * 60) + row["REQ_TIME"].toDouble()) / 60, 2);
                            }
                        }
                    }
                }

                foreach (DataRow empwRow in dtEmpRslt.Rows)
                {
                    double wTime1 = 0.0;
                    double wTime2 = 0.0;
                    double wTime3 = 0.0;
                    double wTime4 = 0.0;

                    double hTime1 = 0.0;
                    double hTime2 = 0.0;
                    double hTime3 = 0.0;
                    double hTime4 = 0.0;

                    foreach (DataColumn col in dtEmpRslt.Columns)
                    {
                        string colName = col.ColumnName;
                        if (colName.IndexOf("WORK_") > -1)
                        {
                            string[] colNames = colName.Split('_');
                            colName = colNames[1];

                            if (colName == "1"
                                || colName == "2"
                                || colName == "3")
                            {
                                wTime1 = Math.Round(wTime1 + empwRow[col.ColumnName].toDouble(), 2);
                            }
                            else if (colName == "4"
                                || colName == "5"
                                || colName == "6")
                            {
                                wTime2 = Math.Round(wTime2 + empwRow[col.ColumnName].toDouble(), 2);
                            }
                            else if (colName == "7"
                                || colName == "8"
                                || colName == "9")
                            {
                                wTime3 = Math.Round(wTime3 + empwRow[col.ColumnName].toDouble(), 2);
                            }
                            else if (colName == "10"
                                || colName == "11"
                                || colName == "12")
                            {
                                wTime4 = Math.Round(wTime4 + empwRow[col.ColumnName].toDouble(), 2);
                            }
                        }

                        if (colName.IndexOf("HM_") > -1)
                        {
                            string[] colNames = colName.Split('_');
                            colName = colNames[1];

                            if (colName == "1"
                                || colName == "2"
                                || colName == "3")
                            {
                                hTime1 = Math.Round(hTime1 + empwRow[col.ColumnName].toDouble(), 2);
                            }
                            else if (colName == "4"
                                || colName == "5"
                                || colName == "6")
                            {
                                hTime2 = Math.Round(hTime2 + empwRow[col.ColumnName].toDouble(), 2);
                            }
                            else if (colName == "7"
                                || colName == "8"
                                || colName == "9")
                            {
                                hTime3 = Math.Round(hTime3 + empwRow[col.ColumnName].toDouble(), 2);
                            }
                            else if (colName == "10"
                                || colName == "11"
                                || colName == "12")
                            {
                                hTime4 = Math.Round(hTime4 + empwRow[col.ColumnName].toDouble(), 2);
                            }
                        }
                    }

                    empwRow["QUARTER_1"] = qtMaxTime1 - (qtDayTime1 + wTime1 - hTime1);
                    empwRow["QUARTER_2"] = qtMaxTime2 - (qtDayTime2 + wTime2 - hTime2);
                    empwRow["QUARTER_3"] = qtMaxTime3 - (qtDayTime3 + wTime3 - hTime3);
                    empwRow["QUARTER_4"] = qtMaxTime4 - (qtDayTime4 + wTime4 - hTime4);
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

        public static DataSet WOR03A_SER2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "REQ_STATUS", "2", typeof(string));

                DataTable dtRslt = DSHP.TSHP_WORK_MNG_QUERY.TSHP_WORK_MNG_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);
                dtRslt.TableName = "RSLTDT";
                paramDS.Tables.Add(dtRslt);

                DataTable workDayRslt = DSTD.TSTD_WORKDAY.TSTD_WORKDAY_SER2(paramDS.Tables["RQSTDT"], bizExecute);
                workDayRslt.TableName = "RSLTDT_WORKDAY";
                paramDS.Tables.Add(workDayRslt);

                DataTable dtHoliRslt = DLSE.LSE_HOLIDAY_QUERY.LSE_HOLIDAY_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);
                dtHoliRslt.TableName = "RSLTDT_HOLI";
                paramDS.Tables.Add(dtHoliRslt);

                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "IS_USE", "1", typeof(string));
                DataTable dtEmpHoli = DSTD.TSTD_EMP_HOLI_QUERY.TSTD_EMP_HOLI_QUERY2(paramDS.Tables["RQSTDT"], bizExecute);
                dtEmpHoli.TableName = "RSLTDT_EMP_HOLI";
                paramDS.Tables.Add(dtEmpHoli);



                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
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
