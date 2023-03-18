using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace BPUR
{
    public class PUR02A
    {
        public static DataSet PUR02A_SER(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "PUR02A", 0, typeof(string));

                DataTable dtRslt = DLSE.LSE_STD_PART_QUERY.LSE_STD_PART_QUERY6(paramDS.Tables["RQSTDT"], bizExecute);
                dtRslt.Columns.Add("DUE_DATE", typeof(string));
                dtRslt.Columns.Add("BAL_QTY", typeof(string));
                dtRslt.Columns.Add("MAT_AMT", typeof(decimal));
                dtRslt.Columns.Add("BAL_SCOMMENT", typeof(string));

                dtRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet PUR02A_SER2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                //UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "BAL_STAT", "11", typeof(string));
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "BAL_TYPE", "SUP", typeof(string));

                DataTable dtRslt = DMAT.TMAT_BALJU_QUERY.TMAT_BALJU_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);

                dtRslt.Columns.Add("STATUS");
                dtRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

      
        public static DataSet PUR02A_INS(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT_V"], "PLT_CODE", ConnInfo.PLT_CODE, typeof(String));


                DataTable dtBalju_M = new DataTable("RQSTDT");
                dtBalju_M.Columns.Add("PLT_CODE", typeof(string));
                dtBalju_M.Columns.Add("BALJU_NUM", typeof(string));
                dtBalju_M.Columns.Add("MVND_CODE", typeof(string));
                dtBalju_M.Columns.Add("BALJU_DATE", typeof(string));
                dtBalju_M.Columns.Add("BAL_STAT", typeof(string));
                dtBalju_M.Columns.Add("BAL_TYPE", typeof(string));

                dtBalju_M.Columns.Add("INCL_VAT", typeof(string));
                dtBalju_M.Columns.Add("SPLIT", typeof(string));
                dtBalju_M.Columns.Add("DELIVERY_LOCATION", typeof(string));
                dtBalju_M.Columns.Add("PAY_CONDITION", typeof(string));
                dtBalju_M.Columns.Add("YPGO_CHARGE", typeof(string));
                dtBalju_M.Columns.Add("CHK_MEASURE", typeof(string));
                dtBalju_M.Columns.Add("CHK_PERFORM", typeof(string));
                dtBalju_M.Columns.Add("CHK_ATTEND", typeof(string));
                dtBalju_M.Columns.Add("CHK_TEST", typeof(string));
                dtBalju_M.Columns.Add("CHK_MEEL", typeof(string));
                dtBalju_M.Columns.Add("CHK_ADD1", typeof(string));
                dtBalju_M.Columns.Add("CHK_ADD2", typeof(string));
                dtBalju_M.Columns.Add("CHK_ADD3", typeof(string));
                dtBalju_M.Columns.Add("CHARGE_EMP", typeof(string));
                dtBalju_M.Columns.Add("CHARGE_PHONE", typeof(string));
                dtBalju_M.Columns.Add("CHARGE_EMAIL", typeof(string));
                dtBalju_M.Columns.Add("SCOMMENT", typeof(string));

                dtBalju_M.Columns.Add("CHK_RD", typeof(string));

                dtBalju_M.Columns.Add("APP_ORG", typeof(string));
                dtBalju_M.Columns.Add("APP_EMP1", typeof(string));
                dtBalju_M.Columns.Add("APP_EMP2", typeof(string));
                dtBalju_M.Columns.Add("APP_EMP3", typeof(string));
                dtBalju_M.Columns.Add("APP_EMP4", typeof(string));

                DataTable dtBalju = dtBalju_M.Clone();

                DataTable dtAppRqst = new DataTable("RQSTDT");
                dtAppRqst.Columns.Add("PLT_CODE", typeof(string));
                dtAppRqst.Columns.Add("APP_TYPE", typeof(string));
                dtAppRqst.Columns.Add("ORG_CODE", typeof(string));

                DataRow appRow = dtAppRqst.NewRow();
                appRow["PLT_CODE"] = ConnInfo.PLT_CODE;
                appRow["APP_TYPE"] = "PUR";
                appRow["ORG_CODE"] = paramDS.Tables["RQSTDT_V"].Rows[0]["APP_ORG"];

                dtAppRqst.Rows.Add(appRow);

                DataTable dtAppRslt = DSTD.TSTD_APP_EMP.TSTD_APP_EMP_SER3(dtAppRqst, bizExecute);

                DataTable dtMaster = paramDS.Tables["RQSTDT_V"];
                DataTable dtDetail = paramDS.Tables["RQSTDT"];

                dtDetail.Columns.Add("BALJU_NUM", typeof(string));
                dtDetail.Columns.Add("BALJU_SEQ", typeof(string));
                dtDetail.Columns.Add("BAL_STAT", typeof(string));
                foreach (DataRow dr in dtMaster.Rows)
                {
                    string balju_num = UTIL.UTILITY_GET_SERIALNO(dr["PLT_CODE"].ToString(), "MB", UTIL.emSerialFormat.YYMMDD, "", bizExecute);

                    DataRow[] details = dtDetail.Select(string.Format("MVND_CODE = '{0}'", dr["SUPP_VND"].ToString()));

                    DataRow drM = dtBalju_M.NewRow();
                    drM["PLT_CODE"] = "100";
                    drM["BALJU_NUM"] = balju_num;
                    drM["MVND_CODE"] = dr["SUPP_VND"];
                    drM["BALJU_DATE"] = DateTime.Today.ToString("yyyyMMdd");
                    drM["BAL_STAT"] = "11";
                    drM["BAL_TYPE"] = "SUP"; //소모품

                    drM["INCL_VAT"] = dr["INCL_VAT"];
                    drM["SPLIT"] = dr["SPLIT"];
                    drM["DELIVERY_LOCATION"] = dr["DELIVERY_LOCATION"];
                    drM["PAY_CONDITION"] = dr["PAY_CONDITION"];
                    drM["YPGO_CHARGE"] = dr["YPGO_CHARGE"];
                    drM["CHK_MEASURE"] = dr["CHK_MEASURE"];
                    drM["CHK_PERFORM"] = dr["CHK_PERFORM"];
                    drM["CHK_ATTEND"] = dr["CHK_ATTEND"];
                    drM["CHK_TEST"] = dr["CHK_TEST"];
                    drM["CHK_MEEL"] = dr["CHK_MEEL"];
                    drM["CHK_ADD1"] = dr["CHK_ADD1"];
                    drM["CHK_ADD2"] = dr["CHK_ADD2"];
                    drM["CHK_ADD3"] = dr["CHK_ADD3"];
                    drM["CHARGE_EMP"] = dr["CHARGE_EMP"];
                    drM["CHARGE_PHONE"] = dr["CHARGE_PHONE"];
                    drM["CHARGE_EMAIL"] = dr["CHARGE_EMAIL"];
                    drM["SCOMMENT"] = dr["SCOMMENT"];

                    drM["CHK_RD"] = dr["CHK_RD"];

                    if (dtAppRslt.Rows.Count > 0)
                    {
                        drM["APP_ORG"] = dr["APP_ORG"];

                        drM["APP_EMP1"] = dtAppRslt.Rows[0]["APP_EMP1"];
                        drM["APP_EMP2"] = dtAppRslt.Rows[0]["APP_EMP2"];
                        drM["APP_EMP3"] = dtAppRslt.Rows[0]["APP_EMP3"];
                        drM["APP_EMP4"] = dtAppRslt.Rows[0]["APP_EMP4"];
                    }

                    dtBalju_M.Rows.Add(drM);

                    DMAT.TMAT_BALJU_MASTER.TMAT_BALJU_MASTER_INS(dtBalju_M, bizExecute);

                    DataRow newRow = dtBalju.NewRow();
                    newRow.ItemArray = drM.ItemArray;
                    dtBalju.Rows.Add(newRow);

                    int seq = 1;
                    foreach (DataRow detail in details)
                    {
                        detail["BALJU_NUM"] = balju_num;
                        detail["BALJU_SEQ"] = seq;
                        detail["BAL_STAT"] = "11";
                        DMAT.TMAT_BALJU.TMAT_BALJU_INS(UTIL.GetRowToDt(detail), bizExecute);

                        seq++;
                    }

                    dtBalju_M.Clear();

                }

                dtBalju.TableName = "RQSTDT_BALJU";

                paramDS.Tables.Add(dtBalju);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet PUR02A_UPD(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "BAL_STAT", "11", typeof(String));

                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    DMAT.TMAT_BALJU.TMAT_BALJU_UPD(UTIL.GetRowToDt(row), bizExecute);
                }

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet PUR02A_DEL(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "BAL_STAT", "14", typeof(String));

                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    DMAT.TMAT_BALJU.TMAT_BALJU_UPD2(UTIL.GetRowToDt(row), bizExecute);

                    DataTable dtBalju = DMAT.TMAT_BALJU_QUERY.TMAT_BALJU_QUERY2(UTIL.GetRowToDt(row), bizExecute);

                    if (dtBalju.Rows.Count == 0)
                    {
                        DMAT.TMAT_BALJU_MASTER.TMAT_BALJU_MASTER_UPD2(UTIL.GetRowToDt(row), bizExecute);
                    }

                }

                //DataRow dr = paramDS.Tables["RQSTDT"].Rows[0];

                //DataTable dtBalju = DMAT.TMAT_BALJU_QUERY.TMAT_BALJU_QUERY2(UTIL.GetRowToDt(dr), bizExecute);

                //if (dtBalju.Rows.Count == 0)
                //{
                //    DMAT.TMAT_BALJU_MASTER.TMAT_BALJU_MASTER_UPD2(UTIL.GetRowToDt(dr), bizExecute);
                //}

                return paramDS;

            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        
    }
}
