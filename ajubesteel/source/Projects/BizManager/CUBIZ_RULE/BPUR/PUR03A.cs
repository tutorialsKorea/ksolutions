using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace BPUR
{
    public class PUR03A
    {
        public static DataSet PUR03A_SER(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));
                

                DataTable dtRslt = DSHP.TSHP_WORKORDER_QUERY.TSHP_WORKORDER_QUERY11(paramDS.Tables["RQSTDT"], bizExecute);
                dtRslt.Columns.Add("DUE_DATE", typeof(string));

                dtRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet PUR03A_SER2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                //UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "BAL_STAT", "11", typeof(string));
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "PUR01", "1", typeof(string));

                //UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "INS_FLAG", "2", typeof(string));
                

                DataTable dtRslt = DOUT.TOUT_PROCBALJU_QUERY.TOUT_PROCBALJU_QUERY3(paramDS.Tables["RQSTDT"], bizExecute);

                DataTable dtMail = DSYS.TSYS_EMAILSEND_LOG_QUERY.TSYS_EMAILSEND_LOG_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);

                DataTable dtPrint = DSYS.TSYS_PRINT_LOG_QUERY.TSYS_PRINT_LOG_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);

                dtRslt.Columns.Add("STATUS");
                dtRslt.TableName = "RSLTDT";
                dtMail.TableName = "RSLTDT_MAIL";

                dtPrint.TableName = "RSLTDT_PRINT";

                dtRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRslt);
                paramDS.Tables.Add(dtMail);
                paramDS.Tables.Add(dtPrint);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        //발주 이력
        public static DataSet PUR03A_SER3(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "BAL_STAT", "11", typeof(string));

                DataTable dtRslt = DOUT.TOUT_PROCBALJU_QUERY.TOUT_PROCBALJU_QUERY3(paramDS.Tables["RQSTDT"], bizExecute);


                dtRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet PUR03A_SER4(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte), true);
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "PART_NO", "PART_CODE");
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "LINK_KEY", "PART_CODE");
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "UPLOAD_MENU", "PLN13A", typeof(string), true);

                DataTable dtRslt = DIF.IF_MES_DWG.IF_MES_DWG_FILE_SER(paramDS.Tables["RQSTDT"], bizExecute);

                if (dtRslt.Rows.Count == 0)
                {
                    dtRslt = DSYS.TSYS_FILELIST_MASTER.TSYS_FILELIST_MASTER_SER2(paramDS.Tables["RQSTDT"], bizExecute);
                }

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

        public static DataSet PUR03A_INS(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable dtBalju_M = new DataTable("RQSTDT");
                dtBalju_M.Columns.Add("PLT_CODE", typeof(string));
                dtBalju_M.Columns.Add("BALJU_NUM", typeof(string));
                dtBalju_M.Columns.Add("OVND_CODE", typeof(string));
                dtBalju_M.Columns.Add("BALJU_DATE", typeof(string));
                dtBalju_M.Columns.Add("BAL_STAT", typeof(string));

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

                DataTable paramTableWO = new DataTable("RQSTDT");
                paramTableWO.Columns.Add("PLT_CODE", typeof(String));
                paramTableWO.Columns.Add("WO_NO", typeof(String));
                paramTableWO.Columns.Add("WO_FLAG", typeof(Int32));
                paramTableWO.Columns.Add("PLN_START_TIME", typeof(String));
                paramTableWO.Columns.Add("PLN_END_TIME", typeof(String));
                paramTableWO.Columns.Add("ACT_START_TIME", typeof(DateTime));
                paramTableWO.Columns.Add("MC_CODE", typeof(String));



                DataTable dtMaster = paramDS.Tables["RQSTDT_V"];
                DataTable dtDetail = paramDS.Tables["RQSTDT"];

                dtDetail.Columns.Add("BALJU_NUM", typeof(string));
                dtDetail.Columns.Add("BALJU_SEQ", typeof(string));
                dtDetail.Columns.Add("BAL_STAT", typeof(string));
                foreach (DataRow dr in dtMaster.Rows)
                {
                    string balju_num = UTIL.UTILITY_GET_SERIALNO(dr["PLT_CODE"].ToString(), "OB", UTIL.emSerialFormat.YYMMDD, "", bizExecute);

                    DataRow[] details = dtDetail.Select(string.Format("OVND_CODE = '{0}'", dr["MAIN_VND"].ToString()));

                    DataRow drM = dtBalju_M.NewRow();
                    drM["PLT_CODE"] = "100";
                    drM["BALJU_NUM"] = balju_num;
                    drM["OVND_CODE"] = dr["MAIN_VND"];
                    drM["BALJU_DATE"] = DateTime.Today.ToString("yyyyMMdd");
                    drM["BAL_STAT"] = "11";

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

                    DOUT.TOUT_PROCBALJU_MASTER.TOUT_PROCBALJU_MASTER_INS(dtBalju_M, bizExecute);

                    DataRow newRow = dtBalju.NewRow();
                    newRow.ItemArray = drM.ItemArray;
                    dtBalju.Rows.Add(newRow);

                    int seq = 1;
                    foreach (DataRow detail in details)
                    {
                        detail["BALJU_NUM"] = balju_num;
                        detail["BALJU_SEQ"] = seq;
                        detail["BAL_STAT"] = "11";

                        if (detail["INS_FLAG"].ToString() == "2")
                            detail["BAL_STAT"] = "20";

                        DOUT.TOUT_PROCBALJU.TOUT_PROCBALJU_INS(UTIL.GetRowToDt(detail), bizExecute);
                        
                        seq++;

                        //작업지시 상태 진행으로 변경
                        //계획시작일 : 발주일, 계획완료일 : 입고예정일, 실적시작일 : 발주일

                        DateTime balju_time = new DateTime(System.Convert.ToInt32(detail["BALJU_DATE"].ToString().Substring(0, 4)),
                                     System.Convert.ToInt32(detail["BALJU_DATE"].ToString().Substring(4, 2)),
                                     System.Convert.ToInt32(detail["BALJU_DATE"].ToString().Substring(6, 2)),
                                     DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);

                        DateTime due_date = new DateTime(System.Convert.ToInt32(detail["DUE_DATE"].ToString().Substring(0, 4)),
                                 System.Convert.ToInt32(detail["DUE_DATE"].ToString().Substring(4, 2)),
                                 System.Convert.ToInt32(detail["DUE_DATE"].ToString().Substring(6, 2)),
                                 DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);

                        DataRow paramRowWo = paramTableWO.NewRow();
                        paramRowWo["PLT_CODE"] = detail["PLT_CODE"];
                        paramRowWo["WO_NO"] = detail["WO_NO"];
                        paramRowWo["WO_FLAG"] = 2;            //진행
                        paramRowWo["PLN_START_TIME"] = balju_time.ToString("yyyyMMddHHmm"); //paramDS.Tables["RQSTDT_M"].Rows[0]["BALJU_DATE"].ToString() + "0000";
                        paramRowWo["PLN_END_TIME"] = due_date.ToString("yyyyMMddHHmm"); //paramDS.Tables["RQSTDT_M"].Rows[0]["DUE_DATE"].ToString() + "0000";
                        paramRowWo["ACT_START_TIME"] = balju_time;
                        paramTableWO.Rows.Add(paramRowWo);

                        
                        DSHP.TSHP_WORKORDER.TSHP_WORKORDER_UPD5(paramTableWO, bizExecute);
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

        public static DataSet PUR03A_UPD(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "BAL_STAT", "11", typeof(String));
                //UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "SCOMMENT", "BALJU_SCOMMENT"); 

                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {

                    if (row["INS_FLAG"].ToString() == "2")
                        row["BAL_STAT"] = "20";


                    DOUT.TOUT_PROCBALJU.TOUT_PROCBALJU_UPD(UTIL.GetRowToDt(row), bizExecute);
                }

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet PUR03A_DEL(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "BAL_STAT", "14", typeof(String));
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "WO_FLAG", "1", typeof(String));
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "BALJU_SEQ_TEMP", "BALJU_SEQ");

                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    DOUT.TOUT_PROCBALJU.TOUT_PROCBALJU_UPD2(UTIL.GetRowToDt(row), bizExecute);
                    DSHP.TSHP_WORKORDER.TSHP_WORKORDER_UPD5(UTIL.GetRowToDt(row), bizExecute);

                    row["BAL_STAT"] = "11";
                    row["BALJU_SEQ"] = null;
                    DataTable dtBalju = DOUT.TOUT_PROCBALJU_QUERY.TOUT_PROCBALJU_QUERY2(UTIL.GetRowToDt(row), bizExecute);
                    row["BALJU_SEQ"] = row["BALJU_SEQ_TEMP"];

                    if (dtBalju.Rows.Count == 0)
                    {
                        row["BAL_STAT"] = "14";
                        DOUT.TOUT_PROCBALJU_MASTER.TOUT_PROCBALJU_MASTER_UPD2(UTIL.GetRowToDt(row), bizExecute);
                    }
                }

                //DataRow dr = paramDS.Tables["RQSTDT"].Rows[0];
                //dr["BAL_STAT"] = "11";
                
                //DataTable dtBalju = DOUT.TOUT_PROCBALJU_QUERY.TOUT_PROCBALJU_QUERY2(UTIL.GetRowToDt(dr), bizExecute);

                //if (dtBalju.Rows.Count == 0)
                //{
                //    dr["BAL_STAT"] = "14";
                //    DOUT.TOUT_PROCBALJU_MASTER.TOUT_PROCBALJU_MASTER_UPD2(UTIL.GetRowToDt(dr), bizExecute);
                    
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
