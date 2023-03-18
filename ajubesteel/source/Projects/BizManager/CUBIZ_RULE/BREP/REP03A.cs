using BizExecute;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BREP
{
    public class REP03A
    {
        public static DataSet REP03A_SER(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {

                DataTable dtRslt = DSTD.TSTD_EMPLOYEE.TSTD_EMPLOYEE_SER5(paramDS.Tables["RQSTDT"], bizExecute);

                dtRslt.Columns.Add("SEL", typeof(string));
                dtRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet REP03A_SER2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", "0", typeof(Byte));
                //사원정보 조회
                DataTable dtEmpRslt = DSTD.TSTD_EMPLOYEE_QUERY.TSTD_EMPLOYEE_QUERY8(paramDS.Tables["RQSTDT"], bizExecute);

                //정례화시간 조회
                DataTable dtIdleRslt = DSTD.TSTD_IDLETIME_QUERY.TSTD_IDLETIME_QUERY2(paramDS.Tables["RQSTDT"], bizExecute);

                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "YEAR", "REQ_YEAR");



                //사원별 연차(W05)/반차(W06) 조회
                //일단위로 변경
                //월별 사용수 집계
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "REQ_STATUS", "2", typeof(string));
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "REQ_YEAR", "YEAR");
                DataTable dtWorkMngRslt = DSHP.TSHP_WORK_MNG_QUERY.TSHP_WORK_MNG_QUERY5(paramDS.Tables["RQSTDT"], bizExecute);

                
                DataTable workDayRslt = DSTD.TSTD_WORKDAY.TSTD_WORKDAY_SER2(paramDS.Tables["RQSTDT"], bizExecute);



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
                dtEmpRslt.Columns.Add("WORK_SUM", typeof(decimal));


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

                    DataSet resultSet = REP03_SER6(idleSet, bizExecute);

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

                    DataTable dtWorkTimeRslt = DSTD.TSTD_WORKTIME_QUERY.TSTD_WORKTIME_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);

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
                            if (workRow["NIGHT_FLAG"].ToString() != "1")
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


                DataTable orgTable = dtEmpRslt.Clone();

                foreach(DataRow row in dtEmpRslt.Rows)
                {
                    if (row["ORG_CODE"].ToString() == "")
                    {
                        continue;
                    }

                    DataRow[] rows = orgTable.Select("ORG_CODE = '" + row["ORG_CODE"].ToString() + "'");

                    if (rows.Length == 0)
                    {
                        DataRow newRow = orgTable.NewRow();
                        newRow["PLT_CODE"] = row["PLT_CODE"];
                        newRow["ORG_CODE"] = row["ORG_CODE"];
                        newRow["ORG_NAME"] = row["ORG_NAME"];

                        newRow["WORK_1"] = row["WORK_1"];
                        newRow["WORK_2"] = row["WORK_2"];
                        newRow["WORK_3"] = row["WORK_3"];
                        newRow["WORK_4"] = row["WORK_4"];
                        newRow["WORK_5"] = row["WORK_5"];
                        newRow["WORK_6"] = row["WORK_6"];
                        newRow["WORK_7"] = row["WORK_7"];
                        newRow["WORK_8"] = row["WORK_8"];
                        newRow["WORK_9"] = row["WORK_9"];
                        newRow["WORK_10"] = row["WORK_10"];
                        newRow["WORK_11"] = row["WORK_11"];
                        newRow["WORK_12"] = row["WORK_12"];

                        orgTable.Rows.Add(newRow);
                    }
                    else
                    {

                        rows[0]["WORK_1"] = rows[0]["WORK_1"].toDouble() + row["WORK_1"].toDouble();
                        rows[0]["WORK_2"] = rows[0]["WORK_2"].toDouble() + row["WORK_2"].toDouble();
                        rows[0]["WORK_3"] = rows[0]["WORK_3"].toDouble() + row["WORK_3"].toDouble();
                        rows[0]["WORK_4"] = rows[0]["WORK_4"].toDouble() + row["WORK_4"].toDouble();
                        rows[0]["WORK_5"] = rows[0]["WORK_5"].toDouble() + row["WORK_5"].toDouble();
                        rows[0]["WORK_6"] = rows[0]["WORK_6"].toDouble() + row["WORK_6"].toDouble();
                        rows[0]["WORK_7"] = rows[0]["WORK_7"].toDouble() + row["WORK_7"].toDouble();
                        rows[0]["WORK_8"] = rows[0]["WORK_8"].toDouble() + row["WORK_8"].toDouble();
                        rows[0]["WORK_9"] = rows[0]["WORK_9"].toDouble() + row["WORK_9"].toDouble();
                        rows[0]["WORK_10"] = rows[0]["WORK_10"].toDouble() + row["WORK_10"].toDouble();
                        rows[0]["WORK_11"] = rows[0]["WORK_11"].toDouble() + row["WORK_11"].toDouble();
                        rows[0]["WORK_12"] = rows[0]["WORK_12"].toDouble() + row["WORK_12"].toDouble();
                    }

                }

                

                foreach (DataRow row in orgTable.Rows)
                {
                    string s1 = paramDS.Tables["RQSTDT"].Rows[0]["YEAR"].ToString() + "01";
                    string s2 = paramDS.Tables["RQSTDT"].Rows[0]["YEAR"].ToString() + "02";
                    string s3 = paramDS.Tables["RQSTDT"].Rows[0]["YEAR"].ToString() + "03";
                    string s4 = paramDS.Tables["RQSTDT"].Rows[0]["YEAR"].ToString() + "04";
                    string s5 = paramDS.Tables["RQSTDT"].Rows[0]["YEAR"].ToString() + "05";
                    string s6 = paramDS.Tables["RQSTDT"].Rows[0]["YEAR"].ToString() + "06";
                    string s7 = paramDS.Tables["RQSTDT"].Rows[0]["YEAR"].ToString() + "07";
                    string s8 = paramDS.Tables["RQSTDT"].Rows[0]["YEAR"].ToString() + "08";
                    string s9 = paramDS.Tables["RQSTDT"].Rows[0]["YEAR"].ToString() + "09";
                    string s10 = paramDS.Tables["RQSTDT"].Rows[0]["YEAR"].ToString() + "10";
                    string s11 = paramDS.Tables["RQSTDT"].Rows[0]["YEAR"].ToString() + "11";
                    string s12 = paramDS.Tables["RQSTDT"].Rows[0]["YEAR"].ToString() + "12";

                    DataRow[] rows1 = workDayRslt.Select("WORK_MONTH = '" + s1 + "'");
                    DataRow[] rows2 = workDayRslt.Select("WORK_MONTH = '" + s2 + "'");
                    DataRow[] rows3 = workDayRslt.Select("WORK_MONTH = '" + s3 + "'");
                    DataRow[] rows4 = workDayRslt.Select("WORK_MONTH = '" + s4 + "'");
                    DataRow[] rows5 = workDayRslt.Select("WORK_MONTH = '" + s5 + "'");
                    DataRow[] rows6 = workDayRslt.Select("WORK_MONTH = '" + s6 + "'");
                    DataRow[] rows7 = workDayRslt.Select("WORK_MONTH = '" + s7 + "'");
                    DataRow[] rows8 = workDayRslt.Select("WORK_MONTH = '" + s8 + "'");
                    DataRow[] rows9 = workDayRslt.Select("WORK_MONTH = '" + s9 + "'");
                    DataRow[] rows10 = workDayRslt.Select("WORK_MONTH = '" + s10 + "'");
                    DataRow[] rows11 = workDayRslt.Select("WORK_MONTH = '" + s11 + "'");
                    DataRow[] rows12 = workDayRslt.Select("WORK_MONTH = '" + s12 + "'");


                    double d1 = 0;
                    if (rows1.Length > 0) d1 = rows1[0]["WORK_DAY"].toDouble();

                    double d2 = 0;
                    if (rows2.Length > 0) d2 = rows2[0]["WORK_DAY"].toDouble();

                    double d3 = 0;
                    if (rows3.Length > 0) d3 = rows3[0]["WORK_DAY"].toDouble();

                    double d4 = 0;
                    if (rows4.Length > 0) d4 = rows4[0]["WORK_DAY"].toDouble();

                    double d5 = 0;
                    if (rows5.Length > 0) d5 = rows5[0]["WORK_DAY"].toDouble();

                    double d6 = 0;
                    if (rows6.Length > 0) d6 = rows6[0]["WORK_DAY"].toDouble();

                    double d7 = 0;
                    if (rows7.Length > 0) d7 = rows7[0]["WORK_DAY"].toDouble();

                    double d8 = 0;
                    if (rows8.Length > 0) d8 = rows8[0]["WORK_DAY"].toDouble();

                    double d9 = 0;
                    if (rows9.Length > 0) d9 = rows9[0]["WORK_DAY"].toDouble();

                    double d10 = 0;
                    if (rows10.Length > 0) d10 = rows10[0]["WORK_DAY"].toDouble();

                    double d11 = 0;
                    if (rows11.Length > 0) d11 = rows11[0]["WORK_DAY"].toDouble();

                    double d12 = 0;
                    if (rows12.Length > 0) d12 = rows12[0]["WORK_DAY"].toDouble();

                    if (d1 > 0)
                    {
                        row["WORK_1"] = row["WORK_1"].toDouble() / d1;
                    }
                    else
                    {
                        row["WORK_1"] = 0;
                    }

                    if (d2 > 0)
                    {
                        row["WORK_2"] = row["WORK_2"].toDouble() / d2;
                    }
                    else
                    {
                        row["WORK_2"] = 0;
                    }

                    if (d3 > 0)
                    {
                        row["WORK_3"] = row["WORK_3"].toDouble() / d3;
                    }
                    else
                    {
                        row["WORK_3"] = 0;
                    }

                    if (d4 > 0)
                    {
                        row["WORK_4"] = row["WORK_4"].toDouble() / d4;
                    }
                    else
                    {
                        row["WORK_4"] = 0;
                    }

                    if (d5 > 0)
                    {
                        row["WORK_5"] = row["WORK_5"].toDouble() / d5;
                    }
                    else
                    {
                        row["WORK_5"] = 0;
                    }

                    if (d6 > 0)
                    {
                        row["WORK_6"] = row["WORK_6"].toDouble() / d6;
                    }
                    else
                    {
                        row["WORK_6"] = 0;
                    }

                    if (d7 > 0)
                    {
                        row["WORK_7"] = row["WORK_7"].toDouble() / d7;
                    }
                    else
                    {
                        row["WORK_7"] = 0;
                    }

                    if (d8 > 0)
                    {
                        row["WORK_8"] = row["WORK_8"].toDouble() / d8;
                    }
                    else
                    {
                        row["WORK_8"] = 0;
                    }

                    if (d9 > 0)
                    {
                        row["WORK_9"] = row["WORK_9"].toDouble() / d9;
                    }
                    else
                    {
                        row["WORK_9"] = 0;
                    }

                    if (d10 > 0)
                    {
                        row["WORK_10"] = row["WORK_10"].toDouble() / d10;
                    }
                    else
                    {
                        row["WORK_10"] = 0;
                    }

                    if (d11 > 0)
                    {
                        row["WORK_11"] = row["WORK_11"].toDouble() / d11;
                    }
                    else
                    {
                        row["WORK_11"] = 0;
                    }

                    if (d12 > 0)
                    {
                        row["WORK_12"] = row["WORK_12"].toDouble() / d12;
                    }
                    else
                    {
                        row["WORK_12"] = 0;
                    }

                    //row["WORK_2"] = row["WORK_2"];
                    //row["WORK_3"] = row["WORK_3"];
                    //row["WORK_4"] = row["WORK_4"];
                    //row["WORK_5"] = row["WORK_5"];
                    //row["WORK_6"] = row["WORK_6"];
                    //row["WORK_7"] = row["WORK_7"];
                    //row["WORK_8"] = row["WORK_8"];
                    //row["WORK_9"] = row["WORK_9"];
                    //row["WORK_10"] = row["WORK_10"];
                    //row["WORK_11"] = row["WORK_11"];
                    //row["WORK_12"] = row["WORK_12"];

                    row["WORK_SUM"] = row["WORK_1"].toDouble() + row["WORK_2"].toDouble() + row["WORK_3"].toDouble() + row["WORK_4"].toDouble() + row["WORK_5"].toDouble() + row["WORK_6"].toDouble() +
                                       row["WORK_7"].toDouble() + row["WORK_8"].toDouble() + row["WORK_9"].toDouble() + row["WORK_10"].toDouble() + row["WORK_11"].toDouble() + row["WORK_12"].toDouble();
                }


                orgTable.TableName = "RSLTDT";
                paramDS.Tables.Add(orgTable);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        //주차(기간?)
        public static DataSet REP03A_SER3(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "S_HOLI_DATE", "S_DATE");
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "E_HOLI_DATE", "E_DATE");

                DataTable dtHoli = DLSE.LSE_HOLIDAY_QUERY.LSE_HOLIDAY_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);

                DateTime sDateTime = paramDS.Tables["RQSTDT"].Rows[0]["S_DATE"].toDateTime();
                DateTime eDateTime = paramDS.Tables["RQSTDT"].Rows[0]["E_DATE"].toDateTime();

                int workDay = 0;
                for (DateTime dateTime = sDateTime; dateTime <= eDateTime; dateTime = dateTime.AddDays(1))
                {
                    string dt = dateTime.ToString("yyyyMMdd");

                    DataRow[] rows = dtHoli.Select("HOLI_DATE = '" + dt + "'");
                    if (rows.Length > 0)
                    {
                        continue;
                    }
                    else if (dateTime.DayOfWeek == DayOfWeek.Saturday
                        || dateTime.DayOfWeek == DayOfWeek.Sunday)
                    {
                        continue;
                    }

                    workDay++;
                }

                //1.
                DataTable dtRslt = DSYS.TSYS_DAILY_LOG_QUERY.TSYS_DAILY_LOG_QUERY8(paramDS.Tables["RQSTDT"], bizExecute);

                dtRslt.Columns.Add("RATE", typeof(string));
                dtRslt.Columns.Add("DLOG_DAY", typeof(double));
                dtRslt.Columns.Add("DLOG_PLAN_DAY", typeof(double));

                if (workDay > 0)
                {
                    foreach (DataRow row in dtRslt.Rows)
                    {
                        row["DLOG_DAY"] = row["DLOG_TIME"].toDouble() / workDay.toDouble();
                        row["DLOG_PLAN_DAY"] = row["DLOG_PLAN_TIME"].toDouble() / workDay.toDouble();
                    }
                }
                else
                {
                    UTIL.SetBizAddColumnToValue(dtRslt, "DLOG_DAY", "0", typeof(double), true);
                    UTIL.SetBizAddColumnToValue(dtRslt, "DLOG_PLAN_DAY", "0", typeof(double), true);
                }


                Double planSum = 0;
                Double actSum = 0;
                if (dtRslt.Rows.Count > 0)
                {
                    planSum = dtRslt.Compute("Sum(DLOG_PLAN_DAY)", "").toDouble();
                    actSum = dtRslt.Compute("Sum(DLOG_DAY)", "").toDouble();
                }

                if (actSum > 0)
                {
                    foreach (DataRow row in dtRslt.Rows)
                    {
                        double rate = Math.Round(row["DLOG_DAY"].toDouble() / actSum * 100, 1);

                        row["RATE"] = String.Format("{0:n1}%", rate);
                    }
                }
                else
                {
                    UTIL.SetBizAddColumnToValue(dtRslt, "RATE", "0.0%", typeof(String), true);
                }

                DataRow sumRow = dtRslt.NewRow();
                sumRow["DLOG_TYPE_NAME"] = "합계";
                sumRow["DLOG_DAY"] = actSum;
                sumRow["DLOG_PLAN_DAY"] = planSum;

                dtRslt.Rows.Add(sumRow);

                //foreach (DataRow row in dtRslt.Rows)
                //{
                //    double act = row["DLOG_DAY"].toDouble();
                //    double plan = row["DLOG_PLAN_DAY"].toDouble();

                //    double rRate = 0;
                //    if (plan > 0)
                //    {
                //        rRate = Math.Round((act / plan) * 100, 1);
                //    }

                //    row["ROW_RATE"] = String.Format("{0:n1}%", rRate);
                //}


                dtRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRslt);


                //2.
                DataTable dtRslt2 = DSYS.TSYS_DAILY_LOG_QUERY.TSYS_DAILY_LOG_QUERY9(paramDS.Tables["RQSTDT"], bizExecute);

                //dtRslt2.Columns.Add("RATE", typeof(string));
                dtRslt2.Columns.Add("DLOG_DAY", typeof(double));
                dtRslt2.Columns.Add("DLOG_PLAN_DAY", typeof(double));

                if (workDay > 0)
                {
                    foreach (DataRow row in dtRslt2.Rows)
                    {
                        row["DLOG_DAY"] = row["DLOG_TIME"].toDouble() / workDay.toDouble();
                        row["DLOG_PLAN_DAY"] = row["DLOG_PLAN_TIME"].toDouble() / workDay.toDouble();
                    }
                }
                else
                {
                    UTIL.SetBizAddColumnToValue(dtRslt2, "DLOG_DAY", "0", typeof(double), true);
                    UTIL.SetBizAddColumnToValue(dtRslt2, "DLOG_PLAN_DAY", "0", typeof(double), true);
                }

                dtRslt2.Columns.Add("RATE", typeof(string));
                dtRslt2.Columns.Add("ROW_RATE", typeof(string));

                Double planSum2 = 0;
                Double actSum2 = 0;
                if (dtRslt2.Rows.Count > 0)
                {
                    planSum2 = dtRslt2.Compute("Sum(DLOG_PLAN_DAY)", "").toDouble();
                    actSum2 = dtRslt2.Compute("Sum(DLOG_DAY)", "").toDouble();
                }

                if (actSum2 > 0)
                {
                    foreach (DataRow row in dtRslt2.Rows)
                    {
                        double rate = Math.Round(row["DLOG_DAY"].toDouble() / actSum2 * 100, 1);

                        row["RATE"] = String.Format("{0:n1}%", rate);
                    }
                }
                else
                {
                    UTIL.SetBizAddColumnToValue(dtRslt2, "RATE", "0.0%", typeof(String), true);
                }

                DataRow sumRow2 = dtRslt2.NewRow();
                sumRow2["RELATED_PROD_NAME"] = "합계";
                sumRow2["DLOG_DAY"] = actSum2;
                sumRow2["DLOG_PLAN_DAY"] = planSum2;

                dtRslt2.Rows.Add(sumRow2);

                foreach (DataRow row in dtRslt2.Rows)
                {
                    double act = row["DLOG_DAY"].toDouble();
                    double plan = row["DLOG_PLAN_DAY"].toDouble();

                    double rRate = 0;
                    if (plan > 0)
                    {
                        rRate = Math.Round((act / plan) * 100, 1);
                    }

                    row["ROW_RATE"] = String.Format("{0:n1}%", rRate);
                }


                dtRslt2.TableName = "RSLTDT2";

                paramDS.Tables.Add(dtRslt2);


                //3.
                DataTable dtRslt3 = DSYS.TSYS_DAILY_LOG_QUERY.TSYS_DAILY_LOG_QUERY10(paramDS.Tables["RQSTDT"], bizExecute);

                //dtRslt3.Columns.Add("RATE", typeof(string));
                dtRslt3.Columns.Add("DLOG_DAY", typeof(double));
                dtRslt3.Columns.Add("DLOG_PLAN_DAY", typeof(double));

                if (workDay > 0)
                {
                    foreach (DataRow row in dtRslt3.Rows)
                    {
                        row["DLOG_DAY"] = row["DLOG_TIME"].toDouble() / workDay.toDouble();
                        row["DLOG_PLAN_DAY"] = row["DLOG_PLAN_TIME"].toDouble() / workDay.toDouble();
                    }
                }
                else
                {
                    UTIL.SetBizAddColumnToValue(dtRslt3, "DLOG_DAY", "0", typeof(double), true);
                    UTIL.SetBizAddColumnToValue(dtRslt3, "DLOG_PLAN_DAY", "0", typeof(double), true);
                }

                dtRslt3.Columns.Add("RATE", typeof(string));
                dtRslt3.Columns.Add("ROW_RATE", typeof(string));

                Double planSum3 = 0;
                Double actSum3 = 0;
                if (dtRslt3.Rows.Count > 0)
                {
                    planSum3 = dtRslt3.Compute("Sum(DLOG_PLAN_DAY)", "").toDouble();
                    actSum3 = dtRslt3.Compute("Sum(DLOG_DAY)", "").toDouble();
                }

                if (actSum3 > 0)
                {
                    foreach (DataRow row in dtRslt3.Rows)
                    {
                        double rate = Math.Round(row["DLOG_DAY"].toDouble() / actSum3 * 100, 1);

                        row["RATE"] = String.Format("{0:n1}%", rate);
                    }
                }
                else
                {
                    UTIL.SetBizAddColumnToValue(dtRslt, "RATE", "0.0%", typeof(String), true);
                }

                DataRow sumRow3 = dtRslt3.NewRow();
                sumRow3["CONTENTS"] = "합계";
                sumRow3["DLOG_DAY"] = actSum3;
                sumRow3["DLOG_PLAN_DAY"] = planSum3;

                dtRslt3.Rows.Add(sumRow3);

                foreach (DataRow row in dtRslt3.Rows)
                {
                    double act = row["DLOG_DAY"].toDouble();
                    double plan = row["DLOG_PLAN_DAY"].toDouble();

                    double rRate = 0;
                    if (plan > 0)
                    {
                        rRate = Math.Round((act / plan) * 100, 1);
                    }

                    row["ROW_RATE"] = String.Format("{0:n1}%", rRate);
                }

                dtRslt3.TableName = "RSLTDT3";

                paramDS.Tables.Add(dtRslt3);


                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        //월
        public static DataSet REP03A_SER4(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", "0", typeof(Byte));

                /////
                DataTable dtRslt = DSYS.TSYS_DAILY_LOG_QUERY.TSYS_DAILY_LOG_QUERY2(paramDS.Tables["RQSTDT"], bizExecute);

                dtRslt.Columns.Add("RATE", typeof(string));

                Double planSum = 0;
                Double actSum = 0;
                if (dtRslt.Rows.Count > 0)
                {
                    planSum = dtRslt.Compute("Sum(DLOG_PLAN_DAY)", "").toDouble();
                    actSum = dtRslt.Compute("Sum(DLOG_DAY)", "").toDouble();
                }

                if (actSum > 0)
                {
                    foreach (DataRow row in dtRslt.Rows)
                    {
                        double rate = Math.Round(row["DLOG_DAY"].toDouble() / actSum * 100, 1);

                        row["RATE"] = String.Format("{0:n1}%", rate);
                    }
                }
                else
                {
                    UTIL.SetBizAddColumnToValue(dtRslt, "RATE", "0.0%", typeof(String), true);
                }

                DataRow sumRow = dtRslt.NewRow();
                sumRow["DLOG_TYPE_NAME"] = "합계";
                sumRow["DLOG_DAY"] = actSum;
                sumRow["DLOG_PLAN_DAY"] = planSum;

                dtRslt.Rows.Add(sumRow);

                dtRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRslt);

                ////////
                DataTable dtRslt2 = DSYS.TSYS_DAILY_LOG_QUERY.TSYS_DAILY_LOG_QUERY3(paramDS.Tables["RQSTDT"], bizExecute);

                dtRslt2.Columns.Add("RATE", typeof(string));
                dtRslt2.Columns.Add("ROW_RATE", typeof(string));

                Double planSum2 = 0;
                Double actSum2 = 0;
                if (dtRslt2.Rows.Count > 0)
                {
                    planSum2 = dtRslt2.Compute("Sum(DLOG_PLAN_DAY)", "").toDouble();
                    actSum2 = dtRslt2.Compute("Sum(DLOG_DAY)", "").toDouble();
                }

                if (actSum2 > 0)
                {
                    foreach (DataRow row in dtRslt2.Rows)
                    {
                        double rate = Math.Round(row["DLOG_DAY"].toDouble() / actSum2 * 100, 1);

                        row["RATE"] = String.Format("{0:n1}%", rate);
                    }
                }
                else
                {
                    UTIL.SetBizAddColumnToValue(dtRslt2, "RATE", "0.0%", typeof(String), true);
                }

                DataRow sumRow2 = dtRslt2.NewRow();
                sumRow2["RELATED_PROD_NAME"] = "합계";
                sumRow2["DLOG_DAY"] = actSum2;
                sumRow2["DLOG_PLAN_DAY"] = planSum2;

                dtRslt2.Rows.Add(sumRow2);

                foreach (DataRow row in dtRslt2.Rows)
                {
                    double act = row["DLOG_DAY"].toDouble();
                    double plan = row["DLOG_PLAN_DAY"].toDouble();

                    double rRate = 0;
                    if (plan > 0)
                    {
                        rRate = Math.Round((act / plan) * 100, 1);
                    }

                    row["ROW_RATE"] = String.Format("{0:n1}%", rRate);
                }


                dtRslt2.TableName = "RSLTDT2";

                paramDS.Tables.Add(dtRslt2);


                ///////////
                DataTable dtRslt3 = DSYS.TSYS_DAILY_LOG_QUERY.TSYS_DAILY_LOG_QUERY4(paramDS.Tables["RQSTDT"], bizExecute);

                dtRslt3.Columns.Add("RATE", typeof(string));
                dtRslt3.Columns.Add("ROW_RATE", typeof(string));

                Double planSum3 = 0;
                Double actSum3 = 0;
                if (dtRslt3.Rows.Count > 0)
                {
                    planSum3 = dtRslt3.Compute("Sum(DLOG_PLAN_DAY)", "").toDouble();
                    actSum3 = dtRslt3.Compute("Sum(DLOG_DAY)", "").toDouble();
                }

                if (actSum3 > 0)
                {
                    foreach (DataRow row in dtRslt3.Rows)
                    {
                        double rate = Math.Round(row["DLOG_DAY"].toDouble() / actSum3 * 100, 1);

                        row["RATE"] = String.Format("{0:n1}%", rate);
                    }
                }
                else
                {
                    UTIL.SetBizAddColumnToValue(dtRslt, "RATE", "0.0%", typeof(String), true);
                }

                DataRow sumRow3 = dtRslt3.NewRow();
                sumRow3["CONTENTS"] = "합계";
                sumRow3["DLOG_DAY"] = actSum3;
                sumRow3["DLOG_PLAN_DAY"] = planSum3;

                dtRslt3.Rows.Add(sumRow3);

                foreach (DataRow row in dtRslt3.Rows)
                {
                    double act = row["DLOG_DAY"].toDouble();
                    double plan = row["DLOG_PLAN_DAY"].toDouble();

                    double rRate = 0;
                    if (plan > 0)
                    {
                        rRate = Math.Round((act / plan) * 100, 1);
                    }

                    row["ROW_RATE"] = String.Format("{0:n1}%", rRate);
                }

                dtRslt3.TableName = "RSLTDT3";

                paramDS.Tables.Add(dtRslt3);


                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        //년
        public static DataSet REP03A_SER5(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", "0", typeof(Byte));

                /////
                DataTable dtRslt = DSYS.TSYS_DAILY_LOG_QUERY.TSYS_DAILY_LOG_QUERY5(paramDS.Tables["RQSTDT"], bizExecute);

                dtRslt.Columns.Add("RATE", typeof(string));

                Double planSum = 0;
                Double actSum = 0;
                if (dtRslt.Rows.Count > 0)
                {
                    planSum = dtRslt.Compute("Sum(DLOG_PLAN_DAY)", "").toDouble();
                    actSum = dtRslt.Compute("Sum(DLOG_DAY)", "").toDouble();
                }

                if (actSum > 0)
                {
                    foreach (DataRow row in dtRslt.Rows)
                    {
                        double rate = Math.Round(row["DLOG_DAY"].toDouble() / actSum * 100, 1);

                        row["RATE"] = String.Format("{0:n1}%", rate);
                    }
                }
                else
                {
                    UTIL.SetBizAddColumnToValue(dtRslt, "RATE", "0.0%", typeof(String), true);
                }

                DataRow sumRow = dtRslt.NewRow();
                sumRow["DLOG_TYPE_NAME"] = "합계";
                sumRow["DLOG_DAY"] = actSum;
                sumRow["DLOG_PLAN_DAY"] = planSum;

                dtRslt.Rows.Add(sumRow);

                dtRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRslt);

                ////////
                DataTable dtRslt2 = DSYS.TSYS_DAILY_LOG_QUERY.TSYS_DAILY_LOG_QUERY6(paramDS.Tables["RQSTDT"], bizExecute);

                dtRslt2.Columns.Add("RATE", typeof(string));
                dtRslt2.Columns.Add("ROW_RATE", typeof(string));

                Double planSum2 = 0;
                Double actSum2 = 0;
                if (dtRslt2.Rows.Count > 0)
                {
                    planSum2 = dtRslt2.Compute("Sum(DLOG_PLAN_DAY)", "").toDouble();
                    actSum2 = dtRslt2.Compute("Sum(DLOG_DAY)", "").toDouble();
                }

                if (actSum2 > 0)
                {
                    foreach (DataRow row in dtRslt2.Rows)
                    {
                        double rate = Math.Round(row["DLOG_DAY"].toDouble() / actSum2 * 100, 1);

                        row["RATE"] = String.Format("{0:n1}%", rate);
                    }
                }
                else
                {
                    UTIL.SetBizAddColumnToValue(dtRslt2, "RATE", "0.0%", typeof(String), true);
                }

                DataRow sumRow2 = dtRslt2.NewRow();
                sumRow2["RELATED_PROD_NAME"] = "합계";
                sumRow2["DLOG_DAY"] = actSum2;
                sumRow2["DLOG_PLAN_DAY"] = planSum2;

                dtRslt2.Rows.Add(sumRow2);

                foreach (DataRow row in dtRslt2.Rows)
                {
                    double act = row["DLOG_DAY"].toDouble();
                    double plan = row["DLOG_PLAN_DAY"].toDouble();

                    double rRate = 0;
                    if (plan > 0)
                    {
                        rRate = Math.Round((act / plan) * 100, 1);
                    }

                    row["ROW_RATE"] = String.Format("{0:n1}%", rRate);
                }


                dtRslt2.TableName = "RSLTDT2";

                paramDS.Tables.Add(dtRslt2);


                ///////////
                DataTable dtRslt3 = DSYS.TSYS_DAILY_LOG_QUERY.TSYS_DAILY_LOG_QUERY7(paramDS.Tables["RQSTDT"], bizExecute);

                dtRslt3.Columns.Add("RATE", typeof(string));
                dtRslt3.Columns.Add("ROW_RATE", typeof(string));

                Double planSum3 = 0;
                Double actSum3 = 0;
                if (dtRslt3.Rows.Count > 0)
                {
                    planSum3 = dtRslt3.Compute("Sum(DLOG_PLAN_DAY)", "").toDouble();
                    actSum3 = dtRslt3.Compute("Sum(DLOG_DAY)", "").toDouble();
                }

                if (actSum3 > 0)
                {
                    foreach (DataRow row in dtRslt3.Rows)
                    {
                        double rate = Math.Round(row["DLOG_DAY"].toDouble() / actSum3 * 100, 1);

                        row["RATE"] = String.Format("{0:n1}%", rate);
                    }
                }
                else
                {
                    UTIL.SetBizAddColumnToValue(dtRslt, "RATE", "0.0%", typeof(String), true);
                }

                DataRow sumRow3 = dtRslt3.NewRow();
                sumRow3["CONTENTS"] = "합계";
                sumRow3["DLOG_DAY"] = actSum3;
                sumRow3["DLOG_PLAN_DAY"] = planSum3;

                dtRslt3.Rows.Add(sumRow3);

                foreach (DataRow row in dtRslt3.Rows)
                {
                    double act = row["DLOG_DAY"].toDouble();
                    double plan = row["DLOG_PLAN_DAY"].toDouble();

                    double rRate = 0;
                    if (plan > 0)
                    {
                        rRate = Math.Round((act / plan) * 100, 1);
                    }

                    row["ROW_RATE"] = String.Format("{0:n1}%", rRate);
                }

                dtRslt3.TableName = "RSLTDT3";

                paramDS.Tables.Add(dtRslt3);


                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet REP03_SER6(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable dtRslt = DSTD.TSTD_EMP_WORKTYPE_QUERY.TSTD_EMP_WORKTYPE_QUERY3(paramDS.Tables["RQSTDT"], bizExecute);

                dtRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRslt);

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
