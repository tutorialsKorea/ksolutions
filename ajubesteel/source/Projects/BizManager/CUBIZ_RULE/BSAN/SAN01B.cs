using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;


namespace BSAN
{
    public class SAN01B
    {

        public static DataSet SAN01B_SER(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                DataTable dtRslt1 = DMAT.TMAT_REQUEST_MASTER_QUERY.TMAT_REQUEST_MASTER_QUERY2(paramDS.Tables["RQSTDT"], bizExecute);
                dtRslt1.TableName = "RSLTDT";
                dtRslt1.Columns.Add("SEL");

                DataTable dtRslt2 = DOUT.TOUT_REQUEST_MASTER_QUERY.TOUT_REQUEST_MASTER_QUERY2(paramDS.Tables["RQSTDT"], bizExecute);
                dtRslt2.TableName = "RSLTDT";
                dtRslt2.Columns.Add("SEL");

                DataTable dtRslt3 = DOUT.TOUT_SETREQUEST_MASTER_QUERY.TOUT_SETREQUEST_MASTER_QUERY2(paramDS.Tables["RQSTDT"], bizExecute);
                dtRslt3.TableName = "RSLTDT";
                dtRslt3.Columns.Add("SEL");

                DataTable dtRslt4 = DTOL.TTOL_REQUEST_MASTER_QUERY.TTOL_REQUEST_MASTER_QUERY2(paramDS.Tables["RQSTDT"], bizExecute);
                dtRslt4.TableName = "RSLTDT";
                dtRslt4.Columns.Add("SEL");



                dsResult.Merge(dtRslt1);
                dsResult.Merge(dtRslt2);
                dsResult.Merge(dtRslt3);
                dsResult.Merge(dtRslt4);

                return dsResult;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        //자재신청승인
        public static void SAN01B_INS_M(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    DataTable dtSer = UTIL.GetRowToDt(row);
                    dtSer.Columns.Remove("CONFIRM_EMP");

                    DataSet dsSanRslt = SAN01B_SER(UTIL.GetDtToDs(dtSer), bizExecute);

                    if (dsSanRslt.Tables["RSLTDT"].Rows.Count != 0)
                    {
                        //승인처리
                        DataTable dtReqUPD = UTIL.GetRowToDt(row);

                        UTIL.SetBizAddColumnToValue(dtReqUPD, "REQ_STAT", "03", typeof(String));
                        UTIL.SetBizAddColumnToValue(dtReqUPD, "CONFIRM_DATE", DateTime.Now.toDateString("yyyyMMdd"), typeof(String));

                        DMAT.TMAT_REQUEST_MASTER.TMAT_REQUEST_MASTER_UPD(dtReqUPD, bizExecute);

                        //신청상태의 정보만 조회
                        DataTable dtReqSer = UTIL.GetRowToDt(row);
                        UTIL.SetBizAddColumnToValue(dtReqUPD, "REQ_STAT", "01", typeof(String));

                        DataTable dtReqRslt = DMAT.TMAT_REQUEST_QUERY.TMAT_REQUEST_QUERY1(dtReqSer, bizExecute);

                        //자재신청 상세승인
                        UTIL.SetBizAddColumnToValue(dtReqRslt, "REQ_STAT", "03", typeof(String));

                        DMAT.TMAT_REQUEST.TMAT_REQUEST_UPD2(dtReqRslt, bizExecute);

                        //구매 이벤트
                        UTIL.SetBizAddColumnToValue(dtReqRslt, "PUR_STAT", "03", typeof(String));

                        CTRL.CTRL.SET_PURCHASE_EVENT_M(UTIL.GetDtToDs(dtReqRslt) , bizExecute);

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

        //공정외주신청승인
        public static void SAN01B_INS_PO(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    DataTable dtSer = UTIL.GetRowToDt(row);
                    dtSer.Columns.Remove("CONFIRM_EMP");

                    DataSet dsSanRslt = SAN01B_SER(UTIL.GetDtToDs(dtSer), bizExecute);

                    if (dsSanRslt.Tables["RSLTDT"].Rows.Count != 0)
                    {
                        //승인처리
                        DataTable dtReqUPD = UTIL.GetRowToDt(row);

                        UTIL.SetBizAddColumnToValue(dtReqUPD, "REQ_STAT", "03", typeof(String));
                        UTIL.SetBizAddColumnToValue(dtReqUPD, "CONFIRM_DATE", DateTime.Now.toDateString("yyyyMMdd"), typeof(String));

                        DOUT.TOUT_REQUEST_MASTER.TOUT_REQUEST_MASTER_UPD(dtReqUPD, bizExecute);

                        //신청상태의 정보만 조회
                        DataTable dtReqSer = UTIL.GetRowToDt(row);
                        UTIL.SetBizAddColumnToValue(dtReqUPD, "REQ_STAT", "01", typeof(String));

                        DataTable dtReqRslt = DOUT.TOUT_REQUEST_QUERY.TOUT_REQUEST_QUERY8(dtReqSer, bizExecute);


                        //공정외주신청 상세승인
                        UTIL.SetBizAddColumnToValue(dtReqRslt, "REQ_STAT", "03", typeof(String));

                        DOUT.TOUT_REQUEST.TOUT_REQUEST_UPD2(dtReqRslt, bizExecute);

                        //작업지시변경
                        UTIL.SetBizAddColumnToValue(dtReqRslt, "WO_FLAG", "1", typeof(String));

                        DSHP.TSHP_WORKORDER.TSHP_WORKORDER_UPD22(dtReqRslt, bizExecute);

                        //LSE 스케줄러 변경
                        UTIL.SetBizAddColumnToValue(dtReqRslt, "SCH_FIX", 1, typeof(Byte));
                        DLSE.LSE_PROC.LSE_PROC_UPD22(dtReqRslt, bizExecute);

                        //구매 이벤트
                        UTIL.SetBizAddColumnToValue(dtReqRslt, "PUR_STAT", "03", typeof(String));

                        CTRL.CTRL.SET_PURCHASE_EVENT_PO(UTIL.GetDtToDs(dtReqRslt), bizExecute);

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
