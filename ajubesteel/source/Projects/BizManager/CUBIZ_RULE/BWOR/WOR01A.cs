using BizExecute;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BWOR
{
    public class WOR01A
    {
        public static DataSet WOR01A_SER(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

                DataTable dtRslt = DSHP.TSHP_WORK_MNG_QUERY.TSHP_WORK_MNG_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);

                dtRslt.Columns.Add("SEL");
                dtRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRslt);

                if (paramDS.Tables["RQSTDT"].Columns.Contains("S_REQ_DATE"))
                {
                    UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "REQ_YEAR", paramDS.Tables["RQSTDT"].Rows[0]["S_REQ_DATE"].ToString().Substring(0, 4), typeof(string));
                }
                else
                {
                    UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "REQ_YEAR", paramDS.Tables["RQSTDT"].Rows[0]["REQ_START_DATE"].ToString().Substring(0, 4), typeof(string));
                }
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "S_REQ_DATE", null, typeof(string));
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "E_REQ_DATE", null, typeof(string));
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "S_REQ_DATETIME", null, typeof(string));
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "E_REQ_DATETIME", null, typeof(string));
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "S_REQ_START_DATE", null, typeof(string));
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "E_REQ_START_DATE", null, typeof(string));
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "REQ_STATUS", "2", typeof(string));

                DataTable dtYearRslt = DSHP.TSHP_WORK_MNG_QUERY.TSHP_WORK_MNG_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);
                dtYearRslt.TableName = "RSLTDT_YEAR";
                paramDS.Tables.Add(dtYearRslt);

                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "IS_USE", "1", typeof(string));
                DataTable dtEmpHoli = DSTD.TSTD_EMP_HOLI_QUERY.TSTD_EMP_HOLI_QUERY2(paramDS.Tables["RQSTDT"], bizExecute);

                // 수정전 원본 UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "COMPARE_YEAR", paramDS.Tables["RQSTDT"].Rows[0]["YEAR"].toInt() - DateTime.Now.Year, typeof(int));
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "COMPARE_YEAR", paramDS.Tables["RQSTDT"].Rows[0]["REQ_YEAR"].toInt() - DateTime.Now.Year, typeof(int)); //210910 pkd 수정


                if (dtEmpHoli.Rows.Count > 0
                    && paramDS.Tables["RQSTDT"].Rows[0]["COMPARE_YEAR"].toInt() != 0)
                {
                    UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "IS_USE", DBNull.Value, typeof(string));
                    UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "ACCOUNT_CALC_YEAR", (dtEmpHoli.Rows[0]["ACCOUNT_CALC_YEAR"].toInt() + paramDS.Tables["RQSTDT"].Rows[0]["COMPARE_YEAR"].toInt()).ToString(), typeof(string));

                    dtEmpHoli = DSTD.TSTD_EMP_HOLI_QUERY.TSTD_EMP_HOLI_QUERY2(paramDS.Tables["RQSTDT"], bizExecute);
                }

                dtEmpHoli.TableName = "RSLTDT_EMP_HOLI";
                paramDS.Tables.Add(dtEmpHoli);

                DataTable workDayRslt = DSTD.TSTD_WORKDAY.TSTD_WORKDAY_SER2(paramDS.Tables["RQSTDT"], bizExecute);
                workDayRslt.TableName = "RSLTDT_WORKDAY";
                paramDS.Tables.Add(workDayRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet WOR01A_SER2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

                DataTable dtRslt = DSTD.TSTD_WORKCODE_QUERY.TSTD_WORKCODE_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);

                dtRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet WOR01A_SER3(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable dtRslt = DLSE.LSE_HOLIDAY_QUERY.LSE_HOLIDAY_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);

                dtRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet WOR01A_SER4(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

                DataTable dtRslt = DSTD.TSTD_WORKTIME_QUERY.TSTD_WORKTIME_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);

                dtRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet WOR01A_SER5(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

                DataTable dtRslt = DSTD.TSTD_WORKCODE_CAUSE_QUERY.TSTD_WORKCODE_CAUSE_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);

                dtRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet WOR01A_SER6(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

                DataTable dtRslt = DSTD.TSTD_IDLETIME_QUERY.TSTD_IDLETIME_QUERY2(paramDS.Tables["RQSTDT"], bizExecute);

                dtRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet WOR01A_SER7(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

                DataTable dtRslt = DSHP.TSHP_WORK_MNG_EMP_QUERY.TSHP_WORK_MNG_EMP_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);

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

        public static DataSet WOR01A_SER8(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

                DataTable dtRslt = DSTD.TSTD_ORG_REF_EMP_QUERY.TSTD_ORG_REF_EMP_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);

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

        public static DataSet WOR01A_SER9(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable dtRslt = DSHP.TSHP_WORK_MNG_QUERY.TSHP_WORK_MNG_QUERY5(paramDS.Tables["RQSTDT"], bizExecute);

                dtRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet WOR01A_SER10(DataSet paramDS, BizExecute.BizExecute bizExecute)
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

        public static DataSet WOR01A_SER11(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

                DataTable dtRslt = DSHP.TSHP_WORK_MNG_QUERY.TSHP_WORK_MNG_QUERY10(paramDS.Tables["RQSTDT"], bizExecute);

                dtRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet WOR01A_INS(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", "0", typeof(Byte));

                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "APP_EMP1", "", typeof(string));
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "APP_EMP2", "", typeof(string));
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "APP_EMP3", "", typeof(string));
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "APP_EMP4", "", typeof(string));

                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "COMPARE_DATE", "", typeof(string));
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "NON_WORK_ID", "", typeof(string));

                DataTable dtAppRqst = new DataTable("RQSTDT");
                dtAppRqst.Columns.Add("PLT_CODE", typeof(string));
                dtAppRqst.Columns.Add("APP_TYPE", typeof(string));

                DataRow appRow = dtAppRqst.NewRow();
                appRow["PLT_CODE"] = ConnInfo.PLT_CODE;
                //appRow["APP_TYPE"] = "ATD";
                appRow["APP_TYPE"] = paramDS.Tables["RQSTDT"].Rows[0]["APP_TYPE"];

                dtAppRqst.Rows.Add(appRow);

                DataTable dtAppRslt = DSTD.TSTD_APP_EMP.TSTD_APP_EMP_SER(dtAppRqst, bizExecute);

                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    DataTable dtRslt = DSHP.TSHP_WORK_MNG.TSHP_WORK_MNG_SER(UTIL.GetRowToDt(row), bizExecute);

                    //이미 신청이 되있는지 확인
                    //본인제외
                    row["NON_WORK_ID"] = row["WORK_ID"];

                    //신청시작일이 반차/연차 기간에 포함된경우
                    row["COMPARE_DATE"] = row["REQ_START_DATE"].toDateString("yyyyMMdd");

                    DataTable dtWorkRslt = DSHP.TSHP_WORK_MNG_QUERY.TSHP_WORK_MNG_QUERY9(UTIL.GetRowToDt(row), bizExecute);

                    bool isExist = false;

                    if (dtWorkRslt.Rows.Count > 0)
                    {
                        isExist = true;

                        //반차인경우 오전,오후 2번입력할 수 있음
                        if (row["WORK_CODE"].ToString() == "W06")
                        {                            
                            if (dtWorkRslt.Rows[0]["WORK_CODE"].ToString() == "W06")
                            {
                                if (row["REQ_AMPM"].ToString() != dtWorkRslt.Rows[0]["REQ_AMPM"].ToString()
                                    && dtWorkRslt.Rows.Count < 2)
                                {
                                    isExist = false;
                                }
                            }
                        }

                        //반차가 오전/오후중 한번이면 해당외 시간에는 외근신청이 가능
                        //외근 : W13 && 반차가 있는경우 외근 종일은 안됨
                        if (row["WORK_CODE"].ToString() == "W13" && row["OUT_TYPE"].ToString() != "DAY")
                        {
                            if (dtWorkRslt.Rows.Count < 2
                                 && row["OUT_TYPE"].ToString() != dtWorkRslt.Rows[0]["REQ_AMPM"].ToString())
                            {
                                isExist = false;
                            }
                        }

                        //반차후 무급휴가 가능
                        if (row["WORK_CODE"].ToString() == "W04")
                        {
                            if (dtWorkRslt.Rows.Count == 1
                                && dtWorkRslt.Rows[0]["WORK_CODE"].ToString() == "W06")
                            {
                                isExist = false;
                            }
                        }
                    }
                    else
                    {
                        //신청종료일이 반차/연차 기간에 포함된 경우
                        row["COMPARE_DATE"] = row["REQ_END_DATE"].toDateString("yyyyMMdd");

                        dtWorkRslt = DSHP.TSHP_WORK_MNG_QUERY.TSHP_WORK_MNG_QUERY9(UTIL.GetRowToDt(row), bizExecute);

                        if (dtWorkRslt.Rows.Count > 0)
                        {
                            isExist = true;
                        }
                    }

                    //잔업은 입력 가능하게
                    if (row["WORK_CODE"].ToString() == "W01"
                        || row["WORK_CODE"].ToString() == "W02"
                        || row["WORK_CODE"].ToString() == "W03"
                        || row["WORK_CODE"].ToString() == "W04"
                        || row["WORK_CODE"].ToString() == "W08"
                        || row["WORK_CODE"].ToString() == "W09"
                        || row["WORK_CODE"].ToString() == "W13"
                        || row["WORK_CODE"].ToString() == "W14"
                        || row["WORK_CODE"].ToString() == "W15")
                        
                    {
                        isExist = false;
                    }

                    if (isExist)
                    {
                        throw UTIL.SetException("신청기간중 신청한 연차/반차가 존재합니다."
                        , row["WORK_ID"].ToString()
                        , new System.Diagnostics.StackFrame().GetMethod().Name
                        , 999999);
                    }

                    //데이터가 있으면 삭제여부 및 덮어쓰기 여부에 따라 update
                    if (dtRslt.Rows.Count > 0)
                    {
                        if (row["OVERWRITE"].Equals("1"))
                        {
                            if (dtRslt.Rows[0]["REQ_STATUS"].ToString() != "0")
                            {
                                throw UTIL.SetException("승인 진행중일 경우 수정/삭제할 수 없습니다."
                                , row["WORK_ID"].ToString()
                                , new System.Diagnostics.StackFrame().GetMethod().Name
                                , BizException.ABORT);
                            }

                            DSHP.TSHP_WORK_MNG.TSHP_WORK_MNG_UPD(UTIL.GetRowToDt(row), bizExecute);
                        }
                        else
                        {
                            if (dtRslt.Rows[0]["DATA_FLAG"].Equals((byte)2))
                            {

                                throw UTIL.SetException("동일 데이터가 이력이 존재할때 발생"
                                    , row["WORK_ID"].ToString()
                                    , new System.Diagnostics.StackFrame().GetMethod().Name
                                    , BizException.OVERWRITE_HISTORY, dtRslt.Rows[0]);

                            }
                            else
                            {
                                throw UTIL.SetException("동일 데이터가 존재할때 발생"
                                    , row["WORK_ID"].ToString()
                                    , new System.Diagnostics.StackFrame().GetMethod().Name
                                    , BizException.OVERWRITE);
                            }
                        }
                    }
                    else
                    {
                        if (dtAppRslt.Rows.Count > 0)
                        {
                            row["APP_EMP1"] = dtAppRslt.Rows[0]["APP_EMP1"].ToString();
                            row["APP_EMP2"] = dtAppRslt.Rows[0]["APP_EMP2"].ToString();
                            row["APP_EMP3"] = dtAppRslt.Rows[0]["APP_EMP3"].ToString();
                            row["APP_EMP4"] = dtAppRslt.Rows[0]["APP_EMP4"].ToString();
                        }

                        row["WORK_ID"] = UTIL.UTILITY_GET_SERIALNO(row["PLT_CODE"].ToString(), "WOR", UTIL.emSerialFormat.YYYYMMDD, "", bizExecute);
                        DSHP.TSHP_WORK_MNG.TSHP_WORK_MNG_INS(UTIL.GetRowToDt(row), bizExecute);
                    }

                    DSHP.TSHP_WORK_MNG_EMP.TSHP_WORK_MNG_EMP_DEL(UTIL.GetRowToDt(row), bizExecute);

                    if (paramDS.Tables.Contains("RQSTDT2"))
                    {
                        if (paramDS.Tables["RQSTDT2"].Rows.Count != 0)
                        {
                            UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT2"], "WORK_ID", row["WORK_ID"].ToString(), typeof(string));
                            UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT2"], "DATA_FLAG", 0, typeof(byte));

                            foreach (DataRow row2 in paramDS.Tables["RQSTDT2"].Rows)
                            {
                                DSHP.TSHP_WORK_MNG_EMP.TSHP_WORK_MNG_EMP_INS(UTIL.GetRowToDt(row2), bizExecute);
                            }
                        }
                    }
                }

                return WOR01A_SER(paramDS, bizExecute);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet WOR01A_DEL(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {

            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", "2", typeof(Byte));

                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    DataTable dtRslt = DSHP.TSHP_WORK_MNG.TSHP_WORK_MNG_SER(UTIL.GetRowToDt(row), bizExecute);

                    if (dtRslt.Rows.Count > 0)
                    {
                        if (dtRslt.Rows[0]["REQ_STATUS"].ToString() != "0")
                        {
                            throw UTIL.SetException("승인 진행중일 경우 수정/삭제할 수 없습니다."
                            , row["WORK_ID"].ToString()
                            , new System.Diagnostics.StackFrame().GetMethod().Name
                            , BizException.ABORT);
                        }
                    }

                    DSHP.TSHP_WORK_MNG.TSHP_WORK_MNG_UDE(UTIL.GetRowToDt(row), bizExecute);
                }

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }
    }
}