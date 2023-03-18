using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace BPUR
{
    public class PUR01A
    {
        public static DataSet PUR01A_SER(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "PUR01A", 0, typeof(string));
                //UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "MAT_LTYPE", "2", typeof(string));

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

        public static DataSet PUR01A_SER2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                //발주내역 조회
                //발주 상태 : 발주(11), 검사대기(20)
                //UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "BAL_STAT", "11", typeof(string));
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "BAL_TYPE", "PUR", typeof(string));
                //UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "PUR01", "1", typeof(string));

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

        //발주 이력
        public static DataSet PUR01A_SER3(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                //UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "BAL_STAT", "11", typeof(string));
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "PUR01_CANCEL", "1", typeof(string));
                DataTable dtRslt = DMAT.TMAT_BALJU_QUERY.TMAT_BALJU_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);

                dtRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet PUR01A_INS(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable dtBalju_M = new DataTable("RQSTDT");
                dtBalju_M.Columns.Add("PLT_CODE", typeof(string));
                dtBalju_M.Columns.Add("BALJU_NUM", typeof(string));
                dtBalju_M.Columns.Add("MVND_CODE", typeof(string));
                dtBalju_M.Columns.Add("BALJU_DATE", typeof(string));
                dtBalju_M.Columns.Add("BAL_STAT", typeof(string));
                dtBalju_M.Columns.Add("BAL_TYPE", typeof(string));      //구매품/소모품

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

                dtBalju_M.Columns.Add("APP_ORG", typeof(string));
                dtBalju_M.Columns.Add("APP_EMP1", typeof(string));
                dtBalju_M.Columns.Add("APP_EMP2", typeof(string));
                dtBalju_M.Columns.Add("APP_EMP3", typeof(string));
                dtBalju_M.Columns.Add("APP_EMP4", typeof(string));

                dtBalju_M.Columns.Add("CHK_RD", typeof(string));

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
                    drM["BAL_TYPE"] = "PUR";    //구매품(일반 자재)

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

                        if (detail["INS_FLAG"].ToString() == "2")
                            detail["BAL_STAT"] = "20";

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

        public static DataSet PUR01A_UPD(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "BAL_STAT", "11", typeof(String));

                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    if (row["INS_FLAG"].ToString() == "2")
                        row["BAL_STAT"] = "20";


                    DMAT.TMAT_BALJU.TMAT_BALJU_UPD(UTIL.GetRowToDt(row), bizExecute);
                }

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet PUR01A_UPD2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    DMAT.TMAT_BALJU_MASTER.TMAT_BALJU_MASTER_UPD5(UTIL.GetRowToDt(row), bizExecute);
                }

                return PUR01A_SER2(paramDS, bizExecute);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet PUR01A_DEL(DataSet paramDS, BizExecute.BizExecute bizExecute)
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

        //자재구매 신청
        public static DataSet PUR01B_INS2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                int idx = 1;

                DataTable dtRqst = new DataTable("REQUEST");
                dtRqst.Columns.Add("PLT_CODE", typeof(String));
                dtRqst.Columns.Add("PART_CODE", typeof(String));
                dtRqst.Columns.Add("PART_NUM", typeof(String));
                dtRqst.Columns.Add("QTY", typeof(int));
                dtRqst.Columns.Add("SEQ", typeof(int));
                dtRqst.Columns.Add("PT_ID", typeof(String));
                dtRqst.Columns.Add("MAT_SPEC", typeof(String));
                dtRqst.Columns.Add("MAT_WEIGHT", typeof(Decimal));
                dtRqst.Columns.Add("UNIT_COST", typeof(Decimal));
                dtRqst.Columns.Add("AMT", typeof(Decimal));
                dtRqst.Columns.Add("SCOMMENT", typeof(String));
                dtRqst.Columns.Add("DUE_DATE", typeof(String));

                foreach (DataRow row in paramDS.Tables["RQSTDT_D"].Rows)
                {
                    DataTable dt = UTIL.GetRowToDt(row);
                    UTIL.SetBizAddColumnToValue(dt, "PLT_CODE", "100", typeof(String));

                    DataTable dtRslt = DLSE.LSE_STD_PART.LSE_STD_PART_SER(dt, bizExecute);

                    if (dtRslt.Rows.Count != 0)
                    {
                        if (dtRslt.Rows[0]["DATA_FLAG"].Equals(2))
                        {
                            throw UTIL.SetException("이미처리되거나 유효하지 않는 데이터입니다. 새로고침합니다."
                                    , new System.Diagnostics.StackFrame().GetMethod().Name
                                    , BizException.UNVALID_DATA);
                        }
                        else
                        {
                            DataRow paramRow = dtRqst.NewRow();
                            paramRow["PLT_CODE"] = dtRslt.Rows[0]["PLT_CODE"];
                            paramRow["PART_CODE"] = dtRslt.Rows[0]["PART_CODE"];
                            paramRow["PART_NUM"] = DBNull.Value;
                            paramRow["QTY"] = row["QTY"];
                            paramRow["SEQ"] = idx;
                            paramRow["MAT_SPEC"] = row["BAL_SPEC"];
                            paramRow["MAT_WEIGHT"] = row["BAL_WEIGHT"];
                            paramRow["UNIT_COST"] = row["UNIT_COST"];
                            paramRow["AMT"] = row["AMT"];
                            paramRow["SCOMMENT"] = row["SCOMMENT"];
                            paramRow["DUE_DATE"] = row["DUE_DATE"];

                            dtRqst.Rows.Add(paramRow);

                            idx++;
                        }
                    }
                    else
                    {
                        throw UTIL.SetException("이미처리되거나 유효하지 않는 데이터입니다. 새로고침합니다."
                                    , new System.Diagnostics.StackFrame().GetMethod().Name
                                    , BizException.UNVALID_DATA);

                    }
                }

                //foreach (DataRow row in paramDS.Tables["RQSTDT_M"].Rows)
                //{

                DataRow rowM = paramDS.Tables["RQSTDT_M"].Rows[0];
                DataTable dtMIns = UTIL.GetRowToDt(rowM);

                string REQUEST_ID = UTIL.UTILITY_GET_SERIALNO(rowM["PLT_CODE"].ToString(), "MR", UTIL.emSerialFormat.YYYYMMDD, "", bizExecute);

                UTIL.SetBizAddColumnToValue(dtMIns, "REQUEST_NO", REQUEST_ID, typeof(String));
                UTIL.SetBizAddColumnToValue(dtMIns, "REQ_STAT", "01", typeof(String));

                string nowDateTime = DateTime.Now.toDateString("yyyyMMdd");

                UTIL.SetBizAddColumnToValue(dtMIns, "DUE_DATE", nowDateTime, typeof(String));

                //자재구매마스터 정보
                DMAT.TMAT_REQUEST_MASTER.TMAT_REQUEST_MASTER_INS(dtMIns, bizExecute);


                //자재구매 디테일 정보
                DataTable dtRqstIns = dtRqst;

                dtRqstIns.Columns.Add("REQUEST_SEQ", typeof(int));

                for (int i = 0; i < dtRqstIns.Rows.Count; i++)
                {
                    dtRqstIns.Rows[i]["REQUEST_SEQ"] = dtRqstIns.Rows[i]["SEQ"];
                }

                UTIL.SetBizAddColumnToValue(dtRqstIns, "REQUEST_NO", REQUEST_ID, typeof(String));
                UTIL.SetBizAddColumnToValue(dtRqstIns, "REQ_STAT", "01", typeof(String));

                DMAT.TMAT_REQUEST.TMAT_REQUEST_INS(dtRqstIns, bizExecute);

                //구매이벤트
                DataTable dtPurEvent = dtRqst;
                UTIL.SetBizAddColumnToValue(dtRqstIns, "REQUEST_NO", REQUEST_ID, typeof(String));
                UTIL.SetBizAddColumnToValue(dtRqstIns, "PUR_STAT", "01", typeof(String));

                DPUR.TPURCHASE_EVENT.TPURCHASE_EVENT_INS(dtPurEvent, bizExecute);

                dtRqstIns.TableName = "RQSTDT_D";
                DataSet dsResult = new DataSet();
                dsResult.Tables.Add(dtMIns);
                dsResult.Tables.Add(dtRqstIns);

                return dsResult;

                    //자동승인 환경설정 조회
                    //DataTable dtConf = paramDS.Tables["RQSTDT_M"];
                    //UTIL.SetBizAddColumnToValue(dtConf, "MENU_CODE", "PUR01B", typeof(String));
                    //UTIL.SetBizAddColumnToValue(dtConf, "CONF_NAME", "AUTOAPP_MAT_REQ", typeof(String));

                    //DataSet dsConfRslt = CTRL.CTRL.GET_MENU_CONFIG(UTIL.GetDtToDs(dtConf), bizExecute);

                    //if (dsConfRslt.Tables["RSLTDT"].Rows[0]["CONF_VALUE"].ToString() == "1")
                    //{
                    //    //자동승인
                    //    DataTable dtAuto = UTIL.GetRowToDt(row);
                    //    UTIL.SetBizAddColumnToValue(dtAuto, "REQUEST_NO", REQUEST_ID, typeof(String));
                    //    UTIL.SetBizAddColumnToValue(dtAuto, "CONFIRM_EMP", row["REG_EMP"].ToString(), typeof(String));

                    //    BSAN.SAN01B.SAN01B_INS_M(UTIL.GetDtToDs(dtAuto), bizExecute);
                    //}

                //}

            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }


        
    }
}
