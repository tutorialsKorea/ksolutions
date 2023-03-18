using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace BPLN
{
    public class PLN03A
    {
        //계획 정보
        public static DataSet PLN03A_SER(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

                DataTable dtRslt = DORD.TORD_PRODUCT_QUERY.TORD_PRODUCT_QUERY4(paramDS.Tables["RQSTDT"], bizExecute);

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

        //제품 작업지시 정보
        public static DataSet PLN03A_SER2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {

            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));
                
                DataTable dtRslt = DSHP.TSHP_WORKORDER_QUERY.TSHP_WORKORDER_QUERY4(paramDS.Tables["RQSTDT"], bizExecute);

                dtRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }

        
     
        public static DataSet PLN03A_SER7(DataSet paramDS, BizExecute.BizExecute bizExecute)
        { 
            try
            {
                DataTable dtRslt = DSHP.TSHP_WORKORDER_HIS_QUERY.TSHP_WORKORDER_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);

                dtRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRslt);

                return paramDS;

            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }



        //재작업지시
        public static DataSet PLN03A_SAVE3(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                //PLT_CODE,WO_NO,WORK_CODE
                DataTable dtRqst = paramDS.Tables["RQSTDT"];

                foreach(DataRow dr in dtRqst.Rows)
                {
                    string strSerialWO = UTIL.UTILITY_GET_SERIALNO(ConnInfo.PLT_CODE, "W", bizExecute);

                    DataTable dtSer = DSHP.TSHP_WORKORDER.TSHP_WORKORDER_SER(UTIL.GetRowToDt(dr), bizExecute);

                    if(dtSer.Rows.Count == 0)
                        throw UTIL.SetException("데이터에 문제가 발생 하였습니다.\n\r"
                                                            + "다시 확인 하여 주십시오"
                                , new System.Diagnostics.StackFrame().GetMethod().Name);

                    dtSer.Rows[0]["WO_NO"] = strSerialWO;
                    dtSer.Rows[0]["O_WO_NO"] = dr["WO_NO"];
                    dtSer.Rows[0]["WO_FLAG"] = "0";
                    dtSer.Rows[0]["WO_TYPE"] = "0";
                    dtSer.Rows[0]["JOB_PRIORITY"] = "2";
                    dtSer.Rows[0]["ACT_INPUT_TYPE"] = "IN";
       

                    UTIL.SetBizAddColumnToValue(dtRqst, "O_WO_NO", dr["WO_NO"], typeof(string));
                    //작지번호
                    UTIL.SetBizAddColumnToValue(dtRqst, "WO_NO", strSerialWO, typeof(string));

                    DSHP.TSHP_WORKORDER.TSHP_WORKORDER_INS(dtSer, bizExecute);
                }

                //DataSet dsParam = new DataSet();
                //dsParam.Tables.Add(paramDS.Tables["RQSTDT_M"].Copy());
                //dsParam.Tables[0].TableName = "RQSTDT";

                return PLN03A_SER2(paramDS, bizExecute);

            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }


        //작업지시 삭제
        public static DataSet PLN03A_DEL(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                //PLT_CODE,WO_NO
                DataTable dtRqst = paramDS.Tables["RQSTDT"];

                foreach (DataRow dr in dtRqst.Rows)
                {

                    DataTable dtSer = DSHP.TSHP_WORKORDER_QUERY.TSHP_WORKORDER_QUERY4(UTIL.GetRowToDt(dr), bizExecute);

                    if (dtSer.Rows.Count == 0)
                        throw UTIL.SetException("데이터에 문제가 발생 하였습니다.\n\r"
                                                            + "다시 확인 하여 주십시오"                                
                                , new System.Diagnostics.StackFrame().GetMethod().Name);


                    if(dtSer.Rows[0]["WO_FLAG"].Equals("2")
                        || dtSer.Rows[0]["WO_FLAG"].Equals("3")
                        || dtSer.Rows[0]["WO_FLAG"].Equals("4"))
                        throw UTIL.SetException("작업지시가 이미 진행되어 삭제 할 수 없습니다.\n\r"
                                                                + "다시 확인 하여 주십시오"
                                    , dr["WO_NO"].ToString()
                                    , new System.Diagnostics.StackFrame().GetMethod().Name
                                    , 200090, dtSer.Rows[0]);

                    DSHP.TSHP_WORKORDER.TSHP_WORKORDER_UDE(UTIL.GetRowToDt(dr), bizExecute);

                    //if (dr["IS_MAT"].ToString() == "1")
                    //{
                    //    DMAT.TMAT_REQUEST.TMAT_REQUEST_DEL(UTIL.GetRowToDt(dr), bizExecute);
                    //}
                }
                

                
                //DataSet dsParam = new DataSet();
                ////dsParam.Tables.Add(paramDS.Tables["RQSTDT_M"].Copy());
                //dsParam.Tables[0].TableName = "RQSTDT";

                return paramDS;

            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        //확정 미확정
        public static DataSet PLN03A_SAVE2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable dtRqst = paramDS.Tables["RQSTDT"];

                //DataRow[] matRows = dtRqst.Select("IS_MAT = 1");

                string request_no = string.Empty;

                //if (matRows.Length > 0) request_no = UTIL.UTILITY_GET_SERIALNO(ConnInfo.PLT_CODE, "MR", bizExecute);
                
                foreach(DataRow row in dtRqst.Rows)
                {
                    
                    DataTable dtCopy = UTIL.GetRowToDt(row);
                    DataTable dtSer = DSHP.TSHP_WORKORDER_QUERY.TSHP_WORKORDER_QUERY4(dtCopy, bizExecute);

                    if(dtSer.Rows.Count == 0)
                    {
                        
                        throw UTIL.SetException("이미 처리되었거나 유효하지 않는 데이터입니다."                        
                        , new System.Diagnostics.StackFrame().GetMethod().Name
                        , 100003);
                        
                    }

                    if(!(dtSer.Rows[0]["WO_FLAG"].Equals("0")
                        || dtSer.Rows[0]["WO_FLAG"].Equals("1")))                        
                    {
                        throw UTIL.SetException("작업지시 상태가 진행,중지,완료 일경우는 수정하거나 삭제할수없습니다."
                        , row["WO_NO"].ToString()
                        , new System.Diagnostics.StackFrame().GetMethod().Name
                        , 200020, dtSer.Rows[0]);
                        
                    }

                    DSHP.TSHP_WORKORDER.TSHP_WORKORDER_UPD4(dtCopy, bizExecute);

                    

                    //if (row["WO_FLAG"].Equals("1"))
                    //{
                    //    //제품상태변경
                    //    UTIL.SetBizAddColumnToValue(dtCopy, "PROD_STATE", "1", typeof(string));
                    //    DORD.TORD_PRODUCT.TORD_PRODUCT_UPD(dtCopy, bizExecute);

                    //    //if (row["IS_MAT"].Equals(1))
                    //    //{ 
                    //    //    //WO_NO, REQ_STAT (03:신청승인 04: 신청취소)
                    //    //    //자재발주 공정일 경우, 자재 신청 정보 생성.
                    //    //    DataTable dtReqRqst = new DataTable("RQSTDT");

                    //    //    UTIL.SetBizAddColumnToValue(dtReqRqst, "PLT_CODE", ConnInfo.PLT_CODE, typeof(String));
                    //    //    UTIL.SetBizAddColumnToValue(dtReqRqst, "REQ_DATE", DateTime.Now.ToString("yyyyMMdd"), typeof(String));
                    //    //    UTIL.SetBizAddColumnToValue(dtReqRqst, "DUE_DATE", DateTime.Now.ToString("yyyyMMdd"), typeof(String));
                    //    //    UTIL.SetBizAddColumnToValue(dtReqRqst, "SCOMMENT", "자동 소재신청", typeof(String));
                    //    //    UTIL.SetBizAddColumnToValue(dtReqRqst, "CONFIRM_DATE", DateTime.Now.ToString("yyyyMMdd"), typeof(String));
                    //    //    UTIL.SetBizAddColumnToValue(dtReqRqst, "CONFIRM_EMP", ConnInfo.UserID, typeof(String));
                    //    //    UTIL.SetBizAddColumnToValue(dtReqRqst, "PROD_CODE", dtSer.Rows[0]["PROD_CODE"], typeof(String));
                    //    //    UTIL.SetBizAddColumnToValue(dtReqRqst, "PART_CODE", dtSer.Rows[0]["PART_CODE"], typeof(String));
                    //    //    UTIL.SetBizAddColumnToValue(dtReqRqst, "WO_NO", row["WO_NO"], typeof(String));
                    //    //    UTIL.SetBizAddColumnToValue(dtReqRqst, "QTY", dtSer.Rows[0]["PART_QTY"].toInt32(), typeof(Int32));
                    //    //    UTIL.SetBizAddColumnToValue(dtReqRqst, "REQ_STAT", "03", typeof(String));
                    //    //    DataTable dtProcMcEmp = DLSE.LSE_STD_PARTPROC.LSE_STD_PARTPROC_SER(dtSer, bizExecute);

                    //    //    if (dtProcMcEmp.Rows.Count > 0)
                    //    //        UTIL.SetBizAddColumnToValue(dtReqRqst, "PUR_SCOMMENT", dtProcMcEmp.Rows[0]["PUR_SCOMMENT"], typeof(String));
                            

                    //    //    DataTable dtReqRslt = DMAT.TMAT_REQUEST_QUERY.TMAT_REQUEST_QUERY1(UTIL.GetRowToDt(row), bizExecute);
                        
                    //    //    if (dtReqRslt.Rows.Count > 0)
                    //    //    {
                    //    //        UTIL.SetBizAddColumnToValue(dtReqRqst, "REQUEST_NO", dtReqRslt.Rows[0]["REQUEST_NO"], typeof(String));
                    //    //        UTIL.SetBizAddColumnToValue(dtReqRqst, "REQUEST_SEQ", dtReqRslt.Rows[0]["REQUEST_SEQ"], typeof(String));
                                
                    //    //        DMAT.TMAT_REQUEST.TMAT_REQUEST_UPD4(dtReqRqst, bizExecute);
                    //    //        DMAT.TMAT_REQUEST_MASTER.TMAT_REQUEST_MASTER_UPD(dtReqRqst, bizExecute);
                    //    //    }
                    //    //    else
                    //    //    {
                    //    //        request_no = UTIL.UTILITY_GET_SERIALNO(ConnInfo.PLT_CODE, "MR", bizExecute);

                    //    //        UTIL.SetBizAddColumnToValue(dtReqRqst, "REQUEST_NO", request_no, typeof(String));
                    //    //        UTIL.SetBizAddColumnToValue(dtReqRqst, "REQUEST_SEQ", 1, typeof(String));
                                
                    //    //        DMAT.TMAT_REQUEST.TMAT_REQUEST_INS(dtReqRqst, bizExecute);
                    //    //        DMAT.TMAT_REQUEST_MASTER.TMAT_REQUEST_MASTER_INS(dtReqRqst, bizExecute);
                    //    //    }
                    //    //}

                    //}
                    //else
                    //{
                    //    UTIL.SetBizAddColumnToValue(dtCopy, "DATA_FLAG", "0", typeof(string));
                    //    DataTable dtWoRslt = DSHP.TSHP_WORKORDER.TSHP_WORKORDER_SER4(dtCopy, bizExecute);
                    //    //if (dtWoRslt.Rows.Count == 0)
                    //    //{
                    //    //    //제품상태변경
                    //    //    UTIL.SetBizAddColumnToValue(dtCopy, "PROD_STATE", "0", typeof(string));
                    //    //    DORD.TORD_PRODUCT.TORD_PRODUCT_UPD(dtCopy, bizExecute);
                    //    //}

                    //    //if (row["IS_MAT"].Equals(1))
                    //    //{
                    //    //    //자재발주 공정인 경우, 자재신청 취소로 변경
                    //    //    DataTable dtReqRslt = DMAT.TMAT_REQUEST_QUERY.TMAT_REQUEST_QUERY1(UTIL.GetRowToDt(row), bizExecute);

                    //    //    if (dtReqRslt.Rows.Count > 0)
                    //    //    {
                    //    //        DataTable dtReqRqst = new DataTable("RQSTDT");

                    //    //        UTIL.SetBizAddColumnToValue(dtReqRqst, "PLT_CODE", ConnInfo.PLT_CODE, typeof(String));
                    //    //        UTIL.SetBizAddColumnToValue(dtReqRqst, "REQUEST_NO", dtReqRslt.Rows[0]["REQUEST_NO"], typeof(String));
                    //    //        UTIL.SetBizAddColumnToValue(dtReqRqst, "REQUEST_SEQ", dtReqRslt.Rows[0]["REQUEST_SEQ"], typeof(String));
                    //    //        UTIL.SetBizAddColumnToValue(dtReqRqst, "REQ_STAT", "04", typeof(String));

                    //    //        DataTable dtProcMcEmp = DLSE.LSE_STD_PARTPROC.LSE_STD_PARTPROC_SER(dtSer, bizExecute);

                    //    //        if (dtProcMcEmp.Rows.Count > 0)
                    //    //            UTIL.SetBizAddColumnToValue(dtReqRqst, "PUR_SCOMMENT", dtProcMcEmp.Rows[0]["PUR_SCOMMENT"], typeof(String));

                    //    //        DMAT.TMAT_REQUEST.TMAT_REQUEST_UPD2(dtReqRqst, bizExecute);

                    //    //    }
                    //    //}


                    //}

                }

                //작업지시 확정/확정취소 이력 저장
                DSHP.TSHP_WORKORDER_HIS.TSHP_WORKORDER_HIS_INS(dtRqst, bizExecute);

                                
                return PLN03A_SER2(paramDS, bizExecute);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        //품목별 표준 공정 정보 가져오기
        public static DataSet PLN03A_SER3(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {

            try
            {
                DataTable dtRqst = paramDS.Tables["RQSTDT"];               

                DataTable dtRslt = DLSE.LSE_STD_PARTPROC_QUERY.LSE_STD_PARTPROC_QUERY2(dtRqst, bizExecute);
                dtRslt.Columns.Add("SEL", typeof(String));
                dtRslt.TableName = "RSLTDT";
                paramDS.Tables.Add(dtRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }

        public static DataSet PLN03A_UPD(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    DSHP.TSHP_WORKORDER.TSHP_WORKORDER_UPD26(UTIL.GetRowToDt(row), bizExecute);
                }

                return PLN03A_SER2(paramDS,bizExecute);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
            
        }
        
    }
}
