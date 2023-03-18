using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace BMAT
{
    public class MAT02A
    {
        public static DataSet MAT02A_SER(DataSet paramDS, BizExecute.BizExecute bizExe)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "OUT_REQ", "0", typeof(string));

                DataTable dtRslt = null;
                if (paramDS.Tables["RQSTDT"].Rows[0]["REQ_TYPE"].ToString() == "B")
                {
                    dtRslt = DMAT.TMAT_PARTLIST_QUERY.TMAT_PARTLIST_QUERY3(paramDS.Tables["RQSTDT"], bizExe);
                }
                else
                {
                    //UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "IS_MAIN_PART", "1", typeof(string));
                    dtRslt = DLSE.LSE_STD_PART_QUERY.LSE_STD_PART_QUERY18(paramDS.Tables["RQSTDT"], bizExe);
                }
                
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

        public static DataSet MAT02A_SER2(DataSet paramDS, BizExecute.BizExecute bizExe)
        {
            try
            {
                DataTable dtRslt = DMAT.TMAT_OUT_REQ_QUERY.TMAT_OUT_REQ_QUERY2(paramDS.Tables["RQSTDT"], bizExe);
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

        public static DataSet MAT02A_SER3(DataSet paramDS, BizExecute.BizExecute bizExe)
        {
            try
            {
                DataTable dtRslt = DMAT.TMAT_OUT_REQ_QUERY.TMAT_OUT_REQ_QUERY3(paramDS.Tables["RQSTDT"], bizExe);
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


        public static DataSet MAT02A_INS(DataSet paramDS, BizExecute.BizExecute bizExe)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "OUT_REQ", "1", typeof(string));
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "OUT_REQ_LOC", "ASY", typeof(string));

                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    string OutReqID = UTIL.UTILITY_GET_SERIALNO(row["PLT_CODE"].ToString(), "OREQ", UTIL.emSerialFormat.YYYYMMDD, "W", bizExe);

                    row["OUT_REQ_ID"] = OutReqID;

                    DMAT.TMAT_OUT_REQ.TMAT_OUT_REQ_INS(UTIL.GetRowToDt(row), bizExe);

                    DMAT.TMAT_PARTLIST.TMAT_PARTLIST_UPD4(UTIL.GetRowToDt(row), bizExe);
                }

                //return MAT02A_SER(paramDS,bizExe);
                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet MAT02A_INS2(DataSet paramDS, BizExecute.BizExecute bizExe)
        {
            try
            {

                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    DMAT.TMAT_PARTLIST.TMAT_PARTLIST_UPD6(UTIL.GetRowToDt(row), bizExe);
                }

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        /// <summary>
        /// 불출 요청 취소
        /// </summary>
        /// <param name="paramDS"></param>
        /// <param name="bizExe"></param>
        /// <returns></returns>
        public static DataSet MAT02A_DEL(DataSet paramDS, BizExecute.BizExecute bizExe)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "OUT_REQ", "0", typeof(string));

                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    DMAT.TMAT_OUT_REQ.TMAT_OUT_REQ_UDE(UTIL.GetRowToDt(row), bizExe);

                    //상품 불출요청 취소시 수주상태변경
                    if (row["OUT_REQ_LOC"].ToString() == "ORD")
                    {
                        DataTable outReqRslt = DMAT.TMAT_OUT_REQ_QUERY.TMAT_OUT_REQ_QUERY7(UTIL.GetRowToDt(row), bizExe);

                        /*
                             불출요청건이 없으면 확정
                             불출요청 상태가 50또는53만 있으면 출하지시요청
                             불출요청 상태가 51,52인데 수주출하여부(ORD_SHIP_FLAG)가 있으면 부분출하 없으면 출하지시
                        */

                        DataTable prodDT = new DataTable("RQSTDT");
                        prodDT.Columns.Add("PLT_CODE", typeof(string));
                        prodDT.Columns.Add("PROD_CODE", typeof(string));
                        prodDT.Columns.Add("PROD_STATE", typeof(string));

                        if (outReqRslt.Rows.Count == 0)
                        {
                            //불출요청건이 없으면 확정
                            DataRow prodRow = prodDT.NewRow();
                            prodRow["PLT_CODE"] = ConnInfo.PLT_CODE;
                            prodRow["PROD_CODE"] = row["PROD_CODE"];
                            prodRow["PROD_STATE"] = "7";
                            prodDT.Rows.Add(prodRow);

                            DORD.TORD_PRODUCT.TORD_PRODUCT_UPD2(prodDT, bizExe);
                        }
                        else
                        {
                            bool is50 = false;
                            bool is51 = false;
                            bool is52 = false;
                            bool is53 = false;

                            bool isShip = false;

                            foreach (DataRow rw in outReqRslt.Rows)
                            {
                                if (is50 && is51 && is52) break;

                                switch(rw["OUT_REQ_STAT"].ToString())
                                {
                                    case "50":
                                        is50 = true;
                                        break;

                                    case "51":
                                        is51 = true;

                                        if (rw["ORD_SHIP_FLAG"].ToString() == "1")
                                        {
                                            isShip = true;
                                        }

                                        break;

                                    case "52":
                                        is52 = true;

                                        if (rw["ORD_SHIP_FLAG"].ToString() == "1")
                                        {
                                            isShip = true;
                                        }

                                        break;

                                    case "53":
                                        is53 = true;
                                        break;
                                }
                            }

                            DataRow prodRow = prodDT.NewRow();
                            prodRow["PLT_CODE"] = ConnInfo.PLT_CODE;
                            prodRow["PROD_CODE"] = row["PROD_CODE"];

                            //불출요청 상태가 50또는53이 있으면 출하지시요청
                            //불출요청 상태가 51,52인데 수주출하여부(ORD_SHIP_FLAG)가 있으면 부분출하 없으면 출하지시
                            if ((is50 || is53) && !is51 && !is52)
                            {
                                prodRow["PROD_STATE"] = "13";

                                prodDT.Rows.Add(prodRow);

                                DORD.TORD_PRODUCT.TORD_PRODUCT_UPD2(prodDT, bizExe);
                            }
                            else if ((is51 || is52))
                            {
                                if (isShip)
                                {
                                    prodRow["PROD_STATE"] = "8";
                                }
                                else
                                {
                                    prodRow["PROD_STATE"] = "10";
                                }

                                prodDT.Rows.Add(prodRow);

                                DORD.TORD_PRODUCT.TORD_PRODUCT_UPD2(prodDT, bizExe);
                            }
                        }
                    }

                    DMAT.TMAT_PARTLIST.TMAT_PARTLIST_UPD4(UTIL.GetRowToDt(row), bizExe);

                    DataTable dtPT = DMAT.TMAT_OUT_REQ_PT.TMAT_OUT_REQ_PT_SER(UTIL.GetRowToDt(row), bizExe);

                    if (dtPT.Rows.Count > 0)
                    {
                        DMAT.TMAT_OUT_REQ_PT.TMAT_OUT_REQ_PT_DEL(dtPT, bizExe);

                        
                    }
                }

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        /// <summary>
        /// 불출 요청 수량 및 비고 수정
        /// </summary>
        /// <param name="paramDS"></param>
        /// <param name="bizExe"></param>
        /// <returns></returns>
        public static DataSet MAT02A_UPD(DataSet paramDS, BizExecute.BizExecute bizExe)
        {
            try
            {

                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {


                    DMAT.TMAT_OUT_REQ.TMAT_OUT_REQ_UPD2(UTIL.GetRowToDt(row), bizExe);

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
