using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace BPUR
{
    public class PUR11B
    {
        //공정외주 신청(작업지시 참조)
        public static DataSet PUR11B_SER2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "IS_REQ", "1", typeof(String));

                DataTable dtRslt = DSHP.TSHP_WORKORDER_QUERY.TSHP_WORKORDER_QUERY11(paramDS.Tables["RQSTDT"], bizExecute);

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


        public static DataSet PUR11B_SER3(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable dtRslt = DOUT.TOUT_REQUEST_QUERY.TOUT_REQUEST_QUERY3(paramDS.Tables["RQSTDT"], bizExecute);

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


        public static DataSet PUR11B_SER4(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "REQ_STAT", "01", typeof(String));

                DataTable dtRslt = DOUT.TOUT_REQUEST_QUERY.TOUT_REQUEST_QUERY2(paramDS.Tables["RQSTDT"], bizExecute);

                DataSet dsMenuConfig = paramDS.Copy();

                UTIL.SetBizAddColumnToValue(dsMenuConfig.Tables["RQSTDT"], "MENU_CODE", "PUR11B", typeof(String));
                UTIL.SetBizAddColumnToValue(dsMenuConfig.Tables["RQSTDT"], "CONF_NAME", "AUTOAPP_OUT_REQ", typeof(String));

                DataSet dsMnConfRslt = CTRL.CTRL.GET_MENU_CONFIG(dsMenuConfig, bizExecute);

                DataTable dtRslt2 = new DataTable();
                if (dsMnConfRslt.Tables["RSLTDT"].Rows[0]["CONF_VALUE"].Equals("1"))
                {
                    UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "REQ_STAT", "03", typeof(String));
                    dtRslt2 = DOUT.TOUT_REQUEST_QUERY.TOUT_REQUEST_QUERY2(paramDS.Tables["RQSTDT"], bizExecute);
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

        //공정외주신청(작업지시 참조)
        public static void PUR11B_INS2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                int idx = 1;

                DataTable dtRqst = new DataTable("REQUEST");
                dtRqst.Columns.Add("PLT_CODE", typeof(String));
                dtRqst.Columns.Add("QTY", typeof(int));
                dtRqst.Columns.Add("SEQ", typeof(int));
                dtRqst.Columns.Add("PT_ID", typeof(String));
                dtRqst.Columns.Add("PROC_CODE", typeof(String));
                dtRqst.Columns.Add("PART_CODE", typeof(String));
                dtRqst.Columns.Add("WO_NO", typeof(String));

                foreach (DataRow row in paramDS.Tables["RQSTDT_D"].Rows)
                {
                    //DataSet ds = paramDS.Copy();
                    DataSet ds = UTIL.GetDtToDs(UTIL.GetRowToDt(row)).Copy();
                    UTIL.SetBizAddColumnToValue(ds.Tables["RQSTDT"], "PLT_CODE", "100", typeof(String));

                    DataSet dsRslt = PUR11B_SER2(ds, bizExecute);

                    if (dsRslt.Tables["RSLTDT"].Rows.Count != 0)
                    {
                        DataRow paramRow = dtRqst.NewRow();
                        paramRow["PLT_CODE"] = dsRslt.Tables["RSLTDT"].Rows[0]["PLT_CODE"];
                        paramRow["QTY"] = row["QTY"];
                        paramRow["SEQ"] = idx;
                        paramRow["WO_NO"] = dsRslt.Tables["RSLTDT"].Rows[0]["WO_NO"];
                        paramRow["PT_ID"] = dsRslt.Tables["RSLTDT"].Rows[0]["PT_ID"];
                        paramRow["PART_CODE"] = dsRslt.Tables["RSLTDT"].Rows[0]["PT_ID"];
                        paramRow["PROC_CODE"] = dsRslt.Tables["RSLTDT"].Rows[0]["PROC_CODE"];

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

                    string REQUEST_ID = UTIL.UTILITY_GET_SERIALNO(row["PLT_CODE"].ToString(), "OR", UTIL.emSerialFormat.YYYYMMDD, "", bizExecute);

                    UTIL.SetBizAddColumnToValue(dtMIns, "REQUEST_NO", REQUEST_ID, typeof(String));
                    UTIL.SetBizAddColumnToValue(dtMIns, "REQ_STAT", "01", typeof(String));

                    //공정외주 마스터 정보
                    DOUT.TOUT_REQUEST_MASTER.TOUT_REQUEST_MASTER_INS(dtMIns, bizExecute);

                    //구매 참조 부품 생성
                    DataTable dtPurPart = dtRqst;

                    UTIL.SetBizAddColumnToValue(dtPurPart, "REQUEST_NO", REQUEST_ID, typeof(String));

                    dtPurPart.Columns.Add("REQUEST_SEQ", typeof(int));

                    for (int i = 0; i < dtPurPart.Rows.Count; i++)
                    {
                        dtPurPart.Rows[i]["REQUEST_SEQ"] = dtPurPart.Rows[i]["SEQ"];
                    }

                    //UTIL.SetBizAddColumnToValue(dtPurPart, "REQUEST_SEQ", dtPurPart.Rows[0]["SEQ"], typeof(String));

                    //작업지시와 부품리스트 연결 X
                    //CTRL.CTRL.CREATE_PUR_PART(UTIL.GetDtToDs(dtPurPart), bizExecute);

                    //공정외주 디테일 정보
                    DataTable dtRqstIns = dtRqst;

                    UTIL.SetBizAddColumnToValue(dtRqstIns, "REQUEST_NO", REQUEST_ID, typeof(String));
                    UTIL.SetBizAddColumnToValue(dtRqstIns, "REQ_STAT", "01", typeof(String));

                    DOUT.TOUT_REQUEST.TOUT_REQUEST_INS(dtRqstIns, bizExecute);

                    //구매이벤트
                    DataTable dtPurEvent = dtRqst;
                    UTIL.SetBizAddColumnToValue(dtRqstIns, "REQUEST_NO", REQUEST_ID, typeof(String));
                    UTIL.SetBizAddColumnToValue(dtRqstIns, "PUR_STAT", "01", typeof(String));

                    CTRL.CTRL.SET_PURCHASE_EVENT_PO(UTIL.GetDtToDs(dtPurEvent), bizExecute);


                    //자동승인 환경설정 조회
                    DataTable dtConf = paramDS.Tables["RQSTDT_M"];
                    UTIL.SetBizAddColumnToValue(dtConf, "MENU_CODE", "PUR11B", typeof(String));
                    UTIL.SetBizAddColumnToValue(dtConf, "CONF_NAME", "AUTOAPP_OUT_REQ", typeof(String));

                    DataSet dsConfRslt = CTRL.CTRL.GET_MENU_CONFIG(UTIL.GetDtToDs(dtConf), bizExecute);

                    if (dsConfRslt.Tables["RSLTDT"].Rows[0]["CONF_VALUE"].ToString() == "1")
                    {
                        //자동승인
                        DataTable dtAuto = UTIL.GetRowToDt(row);
                        UTIL.SetBizAddColumnToValue(dtAuto, "REQUEST_NO", REQUEST_ID, typeof(String));
                        UTIL.SetBizAddColumnToValue(dtAuto, "CONFIRM_EMP", row["REG_EMP"].ToString(), typeof(String));

                        BSAN.SAN01B.SAN01B_INS_PO(UTIL.GetDtToDs(dtAuto), bizExecute);
                    }

                }



            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }


        //공정외주신청(표준부품)
        public static void PUR11B_INS3(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                int idx = 1;

                DataTable dtRqst = new DataTable("REQUEST");
                dtRqst.Columns.Add("PLT_CODE", typeof(String));
                dtRqst.Columns.Add("QTY", typeof(int));
                dtRqst.Columns.Add("SEQ", typeof(int));
                dtRqst.Columns.Add("PROC_CODE", typeof(String));
                dtRqst.Columns.Add("PART_CODE", typeof(String));
                dtRqst.Columns.Add("WO_NO", typeof(String));

                foreach (DataRow row in paramDS.Tables["RQSTDT_D"].Rows)
                {
                    DataSet ds = UTIL.GetDtToDs(UTIL.GetRowToDt(row)).Copy();
                    UTIL.SetBizAddColumnToValue(ds.Tables["RQSTDT"], "PLT_CODE", "100", typeof(String));

                    DataSet dsRslt = PUR11B_SER3(ds, bizExecute);

                    if (dsRslt.Tables["RSLTDT"].Rows.Count != 0)
                    {
                        DataRow paramRow = dtRqst.NewRow();
                        paramRow["PLT_CODE"] = dsRslt.Tables["RSLTDT"].Rows[0]["PLT_CODE"];
                        paramRow["QTY"] = row["QTY"];
                        paramRow["SEQ"] = idx;
                        paramRow["WO_NO"] = dsRslt.Tables["RSLTDT"].Rows[0]["WO_NO"];
                        paramRow["PART_CODE"] = dsRslt.Tables["RSLTDT"].Rows[0]["PART_CODE"];
                        paramRow["PROC_CODE"] = dsRslt.Tables["RSLTDT"].Rows[0]["PROC_CODE"];

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

                    string REQUEST_ID = UTIL.UTILITY_GET_SERIALNO(row["PLT_CODE"].ToString(), "OR", UTIL.emSerialFormat.YYYYMMDD, "", bizExecute);

                    UTIL.SetBizAddColumnToValue(dtMIns, "REQUEST_NO", REQUEST_ID, typeof(String));
                    UTIL.SetBizAddColumnToValue(dtMIns, "REQ_STAT", "01", typeof(String));

                    //공정외주 마스터 정보
                    DOUT.TOUT_REQUEST_MASTER.TOUT_REQUEST_MASTER_INS(dtMIns, bizExecute);

                    //구매 참조 부품 생성
                    DataTable dtPurPart = dtRqst;

                    UTIL.SetBizAddColumnToValue(dtPurPart, "REQUEST_NO", REQUEST_ID, typeof(String));

                    dtPurPart.Columns.Add("REQUEST_SEQ", typeof(int));

                    for (int i = 0; i < dtPurPart.Rows.Count; i++)
                    {
                        dtPurPart.Rows[i]["REQUEST_SEQ"] = dtPurPart.Rows[i]["SEQ"];
                    }

                    //UTIL.SetBizAddColumnToValue(dtPurPart, "REQUEST_SEQ", dtPurPart.Rows[0]["SEQ"], typeof(String));

                    //작업지시와 부품리스트 연결 X
                    //CTRL.CTRL.CREATE_PUR_PART(UTIL.GetDtToDs(dtPurPart), bizExecute);

                    //공정외주 디테일 정보
                    DataTable dtRqstIns = dtRqst;

                    UTIL.SetBizAddColumnToValue(dtRqstIns, "REQUEST_NO", REQUEST_ID, typeof(String));
                    UTIL.SetBizAddColumnToValue(dtRqstIns, "REQ_STAT", "01", typeof(String));

                    DOUT.TOUT_REQUEST.TOUT_REQUEST_INS(dtRqstIns, bizExecute);

                    //구매이벤트
                    DataTable dtPurEvent = dtRqst;
                    UTIL.SetBizAddColumnToValue(dtRqstIns, "REQUEST_NO", REQUEST_ID, typeof(String));
                    UTIL.SetBizAddColumnToValue(dtRqstIns, "PUR_STAT", "01", typeof(String));

                    CTRL.CTRL.SET_PURCHASE_EVENT_PO(UTIL.GetDtToDs(dtPurEvent), bizExecute);


                    //자동승인 환경설정 조회
                    DataTable dtConf = paramDS.Tables["RQSTDT_M"];
                    UTIL.SetBizAddColumnToValue(dtConf, "MENU_CODE", "PUR11B", typeof(String));
                    UTIL.SetBizAddColumnToValue(dtConf, "CONF_NAME", "AUTOAPP_OUT_REQ", typeof(String));

                    DataSet dsConfRslt = CTRL.CTRL.GET_MENU_CONFIG(UTIL.GetDtToDs(dtConf), bizExecute);

                    if (dsConfRslt.Tables["RSLTDT"].Rows[0]["CONF_VALUE"].ToString() == "1")
                    {
                        //자동승인
                        DataTable dtAuto = UTIL.GetRowToDt(row);
                        UTIL.SetBizAddColumnToValue(dtAuto, "REQUEST_NO", REQUEST_ID, typeof(String));
                        UTIL.SetBizAddColumnToValue(dtAuto, "CONFIRM_EMP", row["REG_EMP"].ToString(), typeof(String));

                        BSAN.SAN01B.SAN01B_INS_PO(UTIL.GetDtToDs(dtAuto), bizExecute);
                    }

                }



            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }




        public static DataSet PUR11B_INS4(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    

                    DataTable dtSer = UTIL.GetRowToDt(row);

                    UTIL.SetBizAddColumnToValue(dtSer, "MDFY_EMP", "REG_EMP");
                    dtSer.Rows[0]["REG_EMP"] = "";

                    DataSet dsPurRslt = PUR11B_SER4(UTIL.GetDtToDs(dtSer), bizExecute);

                    if (dsPurRslt.Tables["RSLTDT"].Rows.Count != 0)
                    {
                        DataTable dtUpd = UTIL.GetRowToDt(row);

                        UTIL.SetBizAddColumnToValue(dtUpd, "REQ_STAT", "04", typeof(String));
                        UTIL.SetBizAddColumnToValue(dtUpd, "PUR_STAT", "04", typeof(String));
                        //UTIL.SetBizAddColumnToValue(dtUpd, "MDFY_EMP", "REG_EMP");

                        DOUT.TOUT_REQUEST.TOUT_REQUEST_UPD3(dtUpd, bizExecute);

                        CTRL.CTRL.SET_PURCHASE_EVENT_PO(UTIL.GetDtToDs(dtUpd), bizExecute);

                        //if (dsPurRslt.Tables["RSLTDT"].Rows[0]["REG_EMP"].Equals(row["REG_EMP"]))
                        //{
                            
                        //}
                        //else
                        //{
                        //    throw UTIL.SetException("해당 신청자만 취소하거나 수정할 수 있습니다."
                        //            , new System.Diagnostics.StackFrame().GetMethod().Name
                        //            , 200048);
                        //}
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


        //공정외주신청(표준부품)
        public static void PUR11B_INS7(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                int idx = 1;

                DataTable dtRqst = new DataTable("REQUEST");
                dtRqst.Columns.Add("PLT_CODE", typeof(String));
                dtRqst.Columns.Add("QTY", typeof(int));
                dtRqst.Columns.Add("SEQ", typeof(int));
                dtRqst.Columns.Add("PROC_CODE", typeof(String));
                dtRqst.Columns.Add("PART_CODE", typeof(String));
                dtRqst.Columns.Add("WO_NO", typeof(String));

                foreach (DataRow row in paramDS.Tables["RQSTDT_D"].Rows)
                {
                    DataTable dt = UTIL.GetRowToDt(row);
                    UTIL.SetBizAddColumnToValue(dt, "PLT_CODE", "100", typeof(String));

                    DataTable dtRslt = DLSE.LSE_STD_PART.LSE_STD_PART_SER(dt, bizExecute);

                    if (dtRslt.Rows.Count != 0)
                    {
                        DataRow paramRow = dtRqst.NewRow();
                        paramRow["PLT_CODE"] = dtRslt.Rows[0]["PLT_CODE"];
                        paramRow["QTY"] = row["QTY"];
                        paramRow["SEQ"] = idx;
                        paramRow["WO_NO"] = DBNull.Value;
                        paramRow["PART_CODE"] = dtRslt.Rows[0]["PART_CODE"];
                        paramRow["PROC_CODE"] = paramDS.Tables["RQSTDT_M"].Rows[0]["PROC_CODE"];

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

                    string REQUEST_ID = UTIL.UTILITY_GET_SERIALNO(row["PLT_CODE"].ToString(), "OR", UTIL.emSerialFormat.YYYYMMDD, "", bizExecute);

                    UTIL.SetBizAddColumnToValue(dtMIns, "REQUEST_NO", REQUEST_ID, typeof(String));
                    UTIL.SetBizAddColumnToValue(dtMIns, "REQ_STAT", "01", typeof(String));

                    //공정외주 마스터 정보
                    DOUT.TOUT_REQUEST_MASTER.TOUT_REQUEST_MASTER_INS(dtMIns, bizExecute);

                    //구매 참조 부품 생성
                    DataTable dtPurPart = dtRqst;

                    UTIL.SetBizAddColumnToValue(dtPurPart, "REQUEST_NO", REQUEST_ID, typeof(String));

                    dtPurPart.Columns.Add("REQUEST_SEQ", typeof(int));

                    for (int i = 0; i < dtPurPart.Rows.Count; i++)
                    {
                        dtPurPart.Rows[i]["REQUEST_SEQ"] = dtPurPart.Rows[i]["SEQ"];
                    }

                    //UTIL.SetBizAddColumnToValue(dtPurPart, "REQUEST_SEQ", dtPurPart.Rows[0]["SEQ"], typeof(String));

                    //작업지시와 부품리스트 연결 X
                    //CTRL.CTRL.CREATE_PUR_PART(UTIL.GetDtToDs(dtPurPart), bizExecute);

                    //공정외주 디테일 정보
                    DataTable dtRqstIns = dtRqst;

                    UTIL.SetBizAddColumnToValue(dtRqstIns, "REQUEST_NO", REQUEST_ID, typeof(String));
                    UTIL.SetBizAddColumnToValue(dtRqstIns, "REQ_STAT", "01", typeof(String));

                    DOUT.TOUT_REQUEST.TOUT_REQUEST_INS(dtRqstIns, bizExecute);

                    //구매이벤트
                    DataTable dtPurEvent = dtRqst;
                    UTIL.SetBizAddColumnToValue(dtRqstIns, "REQUEST_NO", REQUEST_ID, typeof(String));
                    UTIL.SetBizAddColumnToValue(dtRqstIns, "PUR_STAT", "01", typeof(String));

                    CTRL.CTRL.SET_PURCHASE_EVENT_PO(UTIL.GetDtToDs(dtPurEvent), bizExecute);


                    //자동승인 환경설정 조회
                    DataTable dtConf = paramDS.Tables["RQSTDT_M"];
                    UTIL.SetBizAddColumnToValue(dtConf, "MENU_CODE", "PUR11B", typeof(String));
                    UTIL.SetBizAddColumnToValue(dtConf, "CONF_NAME", "AUTOAPP_OUT_REQ", typeof(String));

                    DataSet dsConfRslt = CTRL.CTRL.GET_MENU_CONFIG(UTIL.GetDtToDs(dtConf), bizExecute);

                    if (dsConfRslt.Tables["RSLTDT"].Rows[0]["CONF_VALUE"].ToString() == "1")
                    {
                        //자동승인
                        DataTable dtAuto = UTIL.GetRowToDt(row);
                        UTIL.SetBizAddColumnToValue(dtAuto, "REQUEST_NO", REQUEST_ID, typeof(String));
                        UTIL.SetBizAddColumnToValue(dtAuto, "CONFIRM_EMP", row["REG_EMP"].ToString(), typeof(String));

                        BSAN.SAN01B.SAN01B_INS_PO(UTIL.GetDtToDs(dtAuto), bizExecute);
                    }

                }



            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }


        public static void PUR11B_UPD(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    DataTable dtSer = UTIL.GetRowToDt(row);

                    DataSet dsPurRslt = PUR11B_SER4(UTIL.GetDtToDs(dtSer), bizExecute);

                    if (dsPurRslt.Tables["RSLTDT"].Rows.Count != 0)
                    {
                        if (dsPurRslt.Tables["RSLTDT"].Rows[0]["REG_EMP"].Equals(row["REG_EMP"]))
                        {

                            DOUT.TOUT_REQUEST.TOUT_REQUEST_UPD(UTIL.GetRowToDt(row), bizExecute);

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
