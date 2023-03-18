using BizExecute;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BWOR
{
    public class WOR04A
    {
        public static DataSet WOR04A_SER(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

                DataTable dtRslt = DSTD.TSTD_EMP_HOLIPLAN_QUERY.TSTD_EMP_HOLIPLAN_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);
                dtRslt.TableName = "RSLTDT";
                paramDS.Tables.Add(dtRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet WOR04A_SER2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

                DataTable dtRslt = DSTD.TSTD_EMP_HOLIPLAN_QUERY.TSTD_EMP_HOLIPLAN_QUERY2(paramDS.Tables["RQSTDT"], bizExecute);
                dtRslt.TableName = "RSLTDT";
                paramDS.Tables.Add(dtRslt);

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(string));
                paramTable.Columns.Add("S_HOLI_MONTH", typeof(string));
                paramTable.Columns.Add("E_HOLI_MONTH", typeof(string));
                paramTable.Columns.Add("PLAN_NO", typeof(string));

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = ConnInfo.PLT_CODE;
                paramRow["S_HOLI_MONTH"] = dtRslt.Rows[0]["PLAN_MONTH"];
                paramRow["E_HOLI_MONTH"] = dtRslt.Rows[dtRslt.Rows.Count - 1]["PLAN_MONTH"];
                paramRow["PLAN_NO"] = paramDS.Tables["RQSTDT"].Rows[0]["PLAN_NO"];

                paramTable.Rows.Add(paramRow);

                DataTable dtHOliRslt = DLSE.LSE_HOLIDAY_QUERY.LSE_HOLIDAY_QUERY1(paramTable, bizExecute);
                dtHOliRslt.TableName = "RSLTDT_HOLI";
                paramDS.Tables.Add(dtHOliRslt);

                DataTable dtPlanRslt = DSTD.TSTD_EMP_HOLIPLAN_DETAIL.TSTD_EMP_HOLIPLAN_DETAIL_SER2(paramTable, bizExecute);
                dtPlanRslt.TableName = "RSLTDT_PLAN";
                paramDS.Tables.Add(dtPlanRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet WOR04A_SER3(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "IS_USE", "1", typeof(string));

                DataTable dtRslt = DSTD.TSTD_EMP_HOLI_QUERY.TSTD_EMP_HOLI_QUERY2(paramDS.Tables["RQSTDT"], bizExecute);

                if (dtRslt.Rows.Count > 0
                    && paramDS.Tables["RQSTDT"].Rows[0]["COMPARE_YEAR"].toInt() != 0)
                {
                    UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "IS_USE", DBNull.Value, typeof(string));
                    UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "ACCOUNT_CALC_YEAR", (dtRslt.Rows[0]["ACCOUNT_CALC_YEAR"].toInt() + paramDS.Tables["RQSTDT"].Rows[0]["COMPARE_YEAR"].toInt()).ToString(), typeof(string));

                    dtRslt = DSTD.TSTD_EMP_HOLI_QUERY.TSTD_EMP_HOLI_QUERY2(paramDS.Tables["RQSTDT"], bizExecute);
                }

                dtRslt.TableName = "RSLTDT_HOLI";
                paramDS.Tables.Add(dtRslt);

                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "IN_WORK_CODE1", "W05", typeof(string));
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "IN_WORK_CODE2", "W06", typeof(string));
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "REQ_STATUS", "2", typeof(string));

                DataTable dtUseRslt = DSHP.TSHP_WORK_MNG_QUERY.TSHP_WORK_MNG_QUERY6(paramDS.Tables["RQSTDT"], bizExecute);
                dtUseRslt.TableName = "RSLTDT_USE_HOLI";
                paramDS.Tables.Add(dtUseRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet WOR04A_INS(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT_EMP"], "DATA_FLAG", 0, typeof(Byte));
                foreach (DataRow row in paramDS.Tables["RQSTDT_EMP"].Rows)
                {
                    DataTable empRslt = DSTD.TSTD_EMPLOYEE.TSTD_EMPLOYEE_SER(UTIL.GetRowToDt(row), bizExecute);

                    if (empRslt.Rows.Count > 0)
                    {
                        DSTD.TSTD_EMPLOYEE.TSTD_EMPLOYEE_UPD5(UTIL.GetRowToDt(row), bizExecute);
                    }
                }

                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "APP_EMP1", "", typeof(string));
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "APP_EMP2", "", typeof(string));
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "APP_EMP3", "", typeof(string));
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "APP_EMP4", "", typeof(string));

                DataTable dtAppRqst = new DataTable("RQSTDT");
                dtAppRqst.Columns.Add("PLT_CODE", typeof(string));
                dtAppRqst.Columns.Add("APP_TYPE", typeof(string));

                DataRow appRow = dtAppRqst.NewRow();
                appRow["PLT_CODE"] = ConnInfo.PLT_CODE;
                appRow["APP_TYPE"] = "HOL";

                dtAppRqst.Rows.Add(appRow);

                DataTable dtAppRslt = DSTD.TSTD_APP_EMP.TSTD_APP_EMP_SER(dtAppRqst, bizExecute);

                string planNo = "";
                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    planNo = row["PLAN_NO"].ToString();

                    DataTable dtRslt = DSTD.TSTD_EMP_HOLIPLAN.TSTD_EMP_HOLIPLAN_SER(UTIL.GetRowToDt(row), bizExecute);

                    //데이터가 있으면 삭제여부 및 덮어쓰기 여부에 따라 update
                    if (dtRslt.Rows.Count > 0)
                    {
                        if (row["OVERWRITE"].Equals("1"))
                        {
                            DSTD.TSTD_EMP_HOLIPLAN.TSTD_EMP_HOLIPLAN_UPD2(UTIL.GetRowToDt(row), bizExecute);
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
                        planNo = UTIL.UTILITY_GET_SERIALNO(row["PLT_CODE"].ToString(), "PN", UTIL.emSerialFormat.YYYYMMDD, "", bizExecute);
                        row["PLAN_NO"] = planNo;

                        if (dtAppRslt.Rows.Count > 0)
                        {
                            row["APP_EMP1"] = dtAppRslt.Rows[0]["APP_EMP1"].ToString();
                            row["APP_EMP2"] = dtAppRslt.Rows[0]["APP_EMP2"].ToString();
                            row["APP_EMP3"] = dtAppRslt.Rows[0]["APP_EMP3"].ToString();
                            row["APP_EMP4"] = dtAppRslt.Rows[0]["APP_EMP4"].ToString();
                        }

                        DSTD.TSTD_EMP_HOLIPLAN.TSTD_EMP_HOLIPLAN_INS(UTIL.GetRowToDt(row), bizExecute);
                    }
                }

                //계획일 초기화
                DSTD.TSTD_EMP_HOLIPLAN_DETAIL.TSTD_EMP_HOLIPLAN_DETAIL_DEL2(paramDS.Tables["RQSTDT"], bizExecute);

                if (paramDS.Tables["RQSTDT_DETAIL"].Rows.Count > 0)
                {
                    UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT_DETAIL"], "PLAN_NO", planNo, typeof(String));
                }

                foreach (DataRow row in paramDS.Tables["RQSTDT_DETAIL"].Rows)
                {
                    DSTD.TSTD_EMP_HOLIPLAN_DETAIL.TSTD_EMP_HOLIPLAN_DETAIL_INS(UTIL.GetRowToDt(row), bizExecute);
                }

                return WOR04A_SER(paramDS, bizExecute);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet WOR04A_DEL(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", "2", typeof(Byte));

                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    DataTable dtRslt = DSTD.TSTD_EMP_HOLIPLAN.TSTD_EMP_HOLIPLAN_SER(UTIL.GetRowToDt(row), bizExecute);

                    if (dtRslt.Rows.Count > 0)
                    {
                        if (dtRslt.Rows[0]["PLAN_STATUS"].ToString() != "0")
                        {
                            throw UTIL.SetException("승인 진행중일 경우 수정/삭제할 수 없습니다."
                            , row["PLAN_NO"].ToString()
                            , new System.Diagnostics.StackFrame().GetMethod().Name
                            , BizException.ABORT);
                        }
                    }

                    DSTD.TSTD_EMP_HOLIPLAN.TSTD_EMP_HOLIPLAN_UDE(UTIL.GetRowToDt(row), bizExecute);
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
