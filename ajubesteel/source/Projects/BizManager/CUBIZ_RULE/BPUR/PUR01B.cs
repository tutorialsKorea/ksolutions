using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace BPUR
{
    public class PUR01B
    {
        public static DataSet PUR01B_SER(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

                DataTable dtRslt = DMAT.TMAT_PARTLIST_QUERY.TMAT_PARTLIST_QUERY2(paramDS.Tables["RQSTDT"], bizExecute);

                dtRslt.Columns.Add("SEL");
                dtRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet PUR01B_SER2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

                DataTable dtRslt = DLSE.LSE_STD_PART_QUERY.LSE_STD_PART_QUERY2(paramDS.Tables["RQSTDT"], bizExecute);

                dtRslt.Columns.Add("SEL");
                dtRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet PUR01B_SER3(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                
                DataTable dtRslt = DMAT.TMAT_REQUEST_QUERY.TMAT_REQUEST_QUERY4(paramDS.Tables["RQSTDT"], bizExecute);

                DataTable dtRslt2 = new DataTable();
                if (paramDS.Tables["RQSTDT"].Rows[0]["PROD_CODE"].Equals(DBNull.Value))
                {
                    dtRslt2 = DMAT.TMAT_REQUEST_QUERY.TMAT_REQUEST_QUERY5(paramDS.Tables["RQSTDT"], bizExecute);
                }

                dtRslt.Columns.Add("SEL");
                dtRslt.TableName = "RSLTDT";

                dtRslt2.Columns.Add("SEL");
                dtRslt2.TableName = "RSLTDT";

                //paramDS.Tables.Add(dtRslt);

                paramDS.Merge(dtRslt);
                paramDS.Merge(dtRslt2);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet PUR01B_SER4(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "REQ_STAT", "01", typeof(String));

                DataTable dtRslt = DMAT.TMAT_REQUEST_QUERY.TMAT_REQUEST_QUERY2(paramDS.Tables["RQSTDT"], bizExecute);

                DataTable dtRslt2 = new DataTable();
                DataTable dtRslt3 = new DataTable();
                DataTable dtRslt4 = new DataTable();

                if (paramDS.Tables["RQSTDT"].Rows[0]["PROD_CODE"].Equals(DBNull.Value))
                {
                    dtRslt2 = DMAT.TMAT_REQUEST_QUERY.TMAT_REQUEST_QUERY3(paramDS.Tables["RQSTDT"], bizExecute);
                }

                DataSet dsMenuConfig = paramDS.Copy();

                UTIL.SetBizAddColumnToValue(dsMenuConfig.Tables["RQSTDT"], "MENU_CODE", "PUR01B", typeof(String));
                UTIL.SetBizAddColumnToValue(dsMenuConfig.Tables["RQSTDT"], "CONF_NAME", "AUTOAPP_MAT_REQ", typeof(String));

                DataSet dsMnConfRslt = CTRL.CTRL.GET_MENU_CONFIG(dsMenuConfig, bizExecute);

                if (dsMnConfRslt.Tables["RSLTDT"].Rows[0]["CONF_VALUE"].Equals("1"))
                {
                    UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "REQ_STAT", "03", typeof(String));
                   dtRslt3 = DMAT.TMAT_REQUEST_QUERY.TMAT_REQUEST_QUERY2(paramDS.Tables["RQSTDT"], bizExecute);
                   dtRslt4 = DMAT.TMAT_REQUEST_QUERY.TMAT_REQUEST_QUERY3(paramDS.Tables["RQSTDT"], bizExecute);
                }

                dtRslt.Columns.Add("SEL");
                dtRslt.TableName = "RSLTDT";
                dtRslt2.Columns.Add("SEL");
                dtRslt2.TableName = "RSLTDT";
                dtRslt3.Columns.Add("SEL");
                dtRslt3.TableName = "RSLTDT";
                dtRslt4.Columns.Add("SEL");
                dtRslt4.TableName = "RSLTDT";

                //paramDS.Tables.Add(dtRslt);

                paramDS.Merge(dtRslt);
                paramDS.Merge(dtRslt2);
                paramDS.Merge(dtRslt3);
                paramDS.Merge(dtRslt4);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }


        public static void PUR01B_INS(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                int idx = 1;

                DataTable dtRqst = new DataTable("REQUEST");
                dtRqst.Columns.Add("PLT_CODE", typeof(String));
                dtRqst.Columns.Add("QTY", typeof(int));
                dtRqst.Columns.Add("SEQ", typeof(int));
                dtRqst.Columns.Add("PT_ID", typeof(String)); 

                foreach (DataRow row in paramDS.Tables["RQSTDT_D"].Rows)
                {
                    DataSet ds = paramDS.Copy();
                    UTIL.SetBizAddColumnToValue(ds.Tables["RQSTDT_D"], "PLT_CODE", "100", typeof(String));
                    ds.Tables["RQSTDT_D"].TableName = "RQSTDT";

                    DataSet dsRslt = PUR01B_SER(ds, bizExecute);

                    if (dsRslt.Tables["RSLTDT"].Rows.Count != 0)
                    {
                        DataRow paramRow = dtRqst.NewRow();
                        paramRow["PLT_CODE"] = dsRslt.Tables["RSLTDT"].Rows[0]["PLT_CODE"];
                        paramRow["QTY"] = row["QTY"];
                        paramRow["SEQ"] = idx;
                        paramRow["PT_ID"] = row["PT_ID"];

                        dtRqst.Rows.Add(paramRow);

                        idx++; 
                    }
                    else
                    {
                        throw UTIL.SetException("이미처리되거나 유효하지 않는 데이터입니다. 새로고침합니다."
                                    , new System.Diagnostics.StackFrame().GetMethod().Name
                                    , BizException.UNVALID_DATA);
                        
                    }
                }

                foreach (DataRow row in paramDS.Tables["RQSTDT_M"].Rows)
                {

                    DataTable dtMIns = UTIL.GetRowToDt(row);

                    string REQUEST_ID = UTIL.UTILITY_GET_SERIALNO(row["PLT_CODE"].ToString(), "MR", UTIL.emSerialFormat.YYYYMMDD, "", bizExecute);

                    UTIL.SetBizAddColumnToValue(dtMIns, "REQUEST_NO", REQUEST_ID , typeof(String));
                    UTIL.SetBizAddColumnToValue(dtMIns, "REQ_STAT", "01", typeof(String));

                    //자재구매마스터 정보
                    DMAT.TMAT_REQUEST_MASTER.TMAT_REQUEST_MASTER_INS(dtMIns, bizExecute);

                    //구매프로세스 신청시 참조되는 부품을 생성한다.
                    DataTable dtPurPart = dtRqst;

                    UTIL.SetBizAddColumnToValue(dtPurPart, "REQUEST_NO", REQUEST_ID , typeof(String));

                    dtPurPart.Columns.Add("REQUEST_SEQ", typeof(int));

                    for (int i = 0; i < dtPurPart.Rows.Count; i++)
                    {
                        dtPurPart.Rows[i]["REQUEST_SEQ"] = dtPurPart.Rows[i]["SEQ"];
                    }

                        //UTIL.SetBizAddColumnToValue(dtPurPart, "REQUEST_SEQ", dtPurPart.Rows[0]["SEQ"], typeof(String));

                    CTRL.CTRL.CREATE_PUR_PART(UTIL.GetDtToDs(dtPurPart), bizExecute);

                    //자재구매 디테일 정보
                    DataTable dtRqstIns = dtRqst;

                    UTIL.SetBizAddColumnToValue(dtRqstIns, "REQUEST_NO", REQUEST_ID, typeof(String));
                    UTIL.SetBizAddColumnToValue(dtRqstIns, "PART_CODE", DBNull.Value, typeof(String));
                    UTIL.SetBizAddColumnToValue(dtRqstIns, "REQ_STAT", "01", typeof(String));

                    DMAT.TMAT_REQUEST.TMAT_REQUEST_INS(dtRqstIns, bizExecute);

                    //구매이벤트
                    DataTable dtPurEvent = dtRqst;
                    UTIL.SetBizAddColumnToValue(dtRqstIns, "REQUEST_NO", REQUEST_ID, typeof(String));
                    UTIL.SetBizAddColumnToValue(dtRqstIns, "PUR_STAT", "01", typeof(String));

                    CTRL.CTRL.SET_PURCHASE_EVENT_M(UTIL.GetDtToDs(dtPurEvent), bizExecute);


                    //자동승인 환경설정 조회
                    DataTable dtConf = paramDS.Tables["RQSTDT_M"];
                    UTIL.SetBizAddColumnToValue(dtConf, "MENU_CODE", "PUR01B", typeof(String));
                    UTIL.SetBizAddColumnToValue(dtConf, "CONF_NAME", "AUTOAPP_MAT_REQ", typeof(String));

                    DataSet dsConfRslt = CTRL.CTRL.GET_MENU_CONFIG(UTIL.GetDtToDs(dtConf), bizExecute);

                    if (dsConfRslt.Tables["RSLTDT"].Rows[0]["CONF_VALUE"].ToString() == "1")
                    {
                        //자동승인
                        DataTable dtAuto = UTIL.GetRowToDt(row);
                        UTIL.SetBizAddColumnToValue(dtAuto, "REQUEST_NO", REQUEST_ID, typeof(String));
                        UTIL.SetBizAddColumnToValue(dtAuto, "CONFIRM_EMP", row["REG_EMP"].ToString(), typeof(String));

                        BSAN.SAN01B.SAN01B_INS_M(UTIL.GetDtToDs(dtAuto), bizExecute);
                    }

                }

                

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

        //자재구매신청-취소내역
        public static void PUR01B_INS3(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if(paramDS.Tables["RQSTDT_PARTLIST_D"].Rows.Count > 0)
                {
                    DataSet ds = paramDS.Copy();
                    ds.Tables["RQSTDT_PARTLIST_M"].TableName = "RQSTDT_M";
                    ds.Tables["RQSTDT_PARTLIST_D"].TableName = "RQSTDT_D";

                    PUR01B_INS(ds, bizExecute);

                }

                if (paramDS.Tables["RQSTDT_STDPART_D"].Rows.Count > 0)
                {
                    DataSet ds = paramDS.Copy();
                    ds.Tables["RQSTDT_STDPART_M"].TableName = "RQSTDT_M";
                    ds.Tables["RQSTDT_STDPART_D"].TableName = "RQSTDT_D";

                    PUR01B_INS2(ds, bizExecute);
                }


            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }


        public static DataSet PUR01B_INS4(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    DataTable dtSer = UTIL.GetRowToDt(row);

                    UTIL.SetBizAddColumnToValue(dtSer, "PROD_CODE", DBNull.Value, typeof(String));

                    DataSet dsPurRslt = PUR01B_SER4(UTIL.GetDtToDs(dtSer), bizExecute);

                    if (dsPurRslt.Tables["RSLTDT"].Rows.Count != 0)
                    {
                        if (dsPurRslt.Tables["RSLTDT"].Rows[0]["REG_EMP"].Equals(row["REG_EMP"]))
                        {
                            DataTable dtUpd = UTIL.GetRowToDt(row);

                            UTIL.SetBizAddColumnToValue(dtUpd, "REQ_STAT", "04", typeof(String));
                            UTIL.SetBizAddColumnToValue(dtUpd, "PUR_STAT", "04", typeof(String));

                            DMAT.TMAT_REQUEST.TMAT_REQUEST_UPD3(dtUpd, bizExecute);

                            CTRL.CTRL.SET_PURCHASE_EVENT_M(UTIL.GetDtToDs(dtUpd) , bizExecute);
                        }
                        else
                        {
                            throw UTIL.SetException("해당 신청자만 취소하거나 수정할 수 있습니다."
                                    , new System.Diagnostics.StackFrame().GetMethod().Name
                                    , 200048);
                        }
                    }
                    else
                    {
                        throw UTIL.SetException("이미처리되거나 유효하지 않는 데이터입니다. 새로고침합니다."
                                    , new System.Diagnostics.StackFrame().GetMethod().Name
                                    , BizException.UNVALID_DATA);
                    }

                }

                return paramDS;

            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }


        public static void PUR01B_UPD(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    DataTable dtSer = UTIL.GetRowToDt(row);

                    UTIL.SetBizAddColumnToValue(dtSer, "PROD_CODE", DBNull.Value, typeof(String));

                    DataSet dsPurRslt = PUR01B_SER4(UTIL.GetDtToDs(dtSer), bizExecute);

                    if (dsPurRslt.Tables["RSLTDT"].Rows.Count != 0)
                    {
                        if (dsPurRslt.Tables["RSLTDT"].Rows[0]["REG_EMP"].Equals(row["REG_EMP"]))
                        {
                            
                            DMAT.TMAT_REQUEST.TMAT_REQUEST_UPD(UTIL.GetRowToDt(row), bizExecute);

                        }
                        else
                        {
                            throw UTIL.SetException("해당 신청자만 취소하거나 수정할 수 있습니다."
                                    , new System.Diagnostics.StackFrame().GetMethod().Name
                                    , 200048);
                        }
                    }
                    else
                    {
                        throw UTIL.SetException("이미처리되거나 유효하지 않는 데이터입니다. 새로고침합니다."
                                    , new System.Diagnostics.StackFrame().GetMethod().Name
                                    , BizException.UNVALID_DATA);
                    }

                }


            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }
    }
}
