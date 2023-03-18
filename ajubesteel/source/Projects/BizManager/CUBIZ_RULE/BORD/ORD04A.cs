using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace BORD
{
    public class ORD04A
    {

        public static DataSet ORD04A_SER(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "SHIP_FLAG", "1", typeof(string));

                DataTable dtRslt = DORD.TORD_SHIP_QUERY.TORD_SHIP_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);

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
        
        /// <summary>
        /// 출하 취소
        /// </summary>
        /// <param name="paramDS"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataSet ORD04A_CANCEL(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 2, typeof(Byte));

                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "PO_NO", null, typeof(string));

                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    DataTable dtSer = DORD.TORD_SHIP.TORD_SHIP_SER(UTIL.GetRowToDt(row), bizExecute);

                    DataTable dtSerProd = DORD.TORD_PRODUCT.TORD_PRODUCT_SER(dtSer, bizExecute);

                    if(dtSerProd.Rows.Count == 0)
                        throw UTIL.SetException("데이터에 문제가 발생 하였습니다."
                                                            , null
                                                            , new System.Diagnostics.StackFrame().GetMethod().Name
                                                            , BizException.ABORT, row);
                    //상품,재고 경우에 출고 취소
                    // ->변경 불출요청 취소
                    // 불출이 진행된경우 불출 취소후 진행하게
                    if (dtSerProd.Rows[0]["PROD_KIND"].ToString() == "IE" || dtSerProd.Rows[0]["PROD_KIND"].ToString() == "SK")
                    {

                        //DataTable outReqRslt = DMAT.TMAT_OUT_REQ_QUERY.TMAT_OUT_REQ_QUERY4(UTIL.GetRowToDt(dtSerProd.Rows[0]), bizExecute);

                        //if (outReqRslt.Rows.Count > 0)
                        //{
                        //    throw UTIL.SetException("불출된 품목이 존재합니다."
                        //            , row["SHIP_ID"].toStringEmpty()
                        //            , new System.Diagnostics.StackFrame().GetMethod().Name
                        //            , BizException.ABORT, row);
                        //}


                        //DataTable outCancelReqRslt = DMAT.TMAT_OUT_REQ_QUERY.TMAT_OUT_REQ_QUERY5(UTIL.GetRowToDt(row), bizExecute);

                        //UTIL.SetBizAddColumnToValue(outCancelReqRslt, "OUT_REQ", "0", typeof(string));

                        //foreach (DataRow outCancelRow in outCancelReqRslt.Rows)
                        //{
                        //    DMAT.TMAT_OUT_REQ.TMAT_OUT_REQ_UDE(UTIL.GetRowToDt(outCancelRow), bizExecute);

                        //    DMAT.TMAT_PARTLIST.TMAT_PARTLIST_UPD4(UTIL.GetRowToDt(outCancelRow), bizExecute);
                        //}


                        #region 불출취소
                        //DataTable paramTable = new DataTable();
                        //paramTable.Columns.Add("PLT_CODE", typeof(String));
                        //paramTable.Columns.Add("TYPE", typeof(String));
                        //paramTable.Columns.Add("PART_CODE", typeof(String));
                        //paramTable.Columns.Add("PART_QTY", typeof(String));
                        //paramTable.Columns.Add("OUT_ID", typeof(String));

                        //DataRow paramRow = paramTable.NewRow();
                        //paramRow["PLT_CODE"] = ConnInfo.PLT_CODE;
                        //paramRow["TYPE"] = "OUT_CANCEL";
                        ////paramRow["PART_CODE"] = oldRow["OUT_MAT_CODE"];
                        //paramRow["PART_QTY"] = dtSer.Rows[0]["SHIP_QTY"].toInt();
                        //paramRow["OUT_ID"] = row["SHIP_ID"];

                        //paramTable.Rows.Add(paramRow);
                        //CTRL.CTRL.SET_STOCK_PROCESS(paramRow, bizExecute, "PART_CODE", "STOCK_LOC", "PART_QTY", "AMT", "", "OUT_ID");
                        #endregion
                    }

                    //수주상태 변경
                    DataTable dtProdState = new DataTable("RQSTDT");
                    dtProdState.Columns.Add("PLT_CODE", typeof(string));
                    dtProdState.Columns.Add("PROD_CODE", typeof(string));
                    dtProdState.Columns.Add("PROD_STATE", typeof(string));

                    DataRow prodStateRow = dtProdState.NewRow();
                    prodStateRow["PLT_CODE"] = ConnInfo.PLT_CODE;
                    prodStateRow["PROD_CODE"] = dtSerProd.Rows[0]["PROD_CODE"];
                    prodStateRow["PROD_STATE"] = "12";
                    dtProdState.Rows.Add(prodStateRow);

                    //DORD.TORD_PRODUCT.TORD_PRODUCT_UPD2(dtProdState, bizExecute);
                    DORD.TORD_PRODUCT.TORD_PRODUCT_UPD2_1(dtProdState, bizExecute);

                    DORD.TORD_SHIP.TORD_SHIP_UDE(UTIL.GetRowToDt(row), bizExecute);

                    DataTable outShipRslt = DMAT.TMAT_OUT_SHIP.TMAT_OUT_SHIP_SER(UTIL.GetRowToDt(row), bizExecute);

                    foreach (DataRow rw in outShipRslt.Rows)
                    {
                        DataTable outRslt = DMAT.TMAT_OUT.TMAT_OUT_SER(UTIL.GetRowToDt(rw), bizExecute);

                        if (outRslt.Rows.Count > 0)
                        {
                            DataTable outshipTable = new DataTable();
                            outshipTable.Columns.Add("PLT_CODE", typeof(String));
                            outshipTable.Columns.Add("OUT_ID", typeof(String));
                            outshipTable.Columns.Add("SHIP_QTY", typeof(int));
                            outshipTable.Columns.Add("REMAIN_QTY", typeof(int));
                            outshipTable.Columns.Add("ORD_SHIP_FLAG", typeof(String));

                            DataRow newRow = outshipTable.NewRow();
                            newRow["PLT_CODE"] = rw["PLT_CODE"];
                            newRow["OUT_ID"] = rw["OUT_ID"];
                            newRow["SHIP_QTY"] = outRslt.Rows[0]["SHIP_QTY"].toInt() - rw["SHIP_QTY"].toInt();
                            newRow["REMAIN_QTY"] = outRslt.Rows[0]["REMAIN_QTY"].toInt() + rw["SHIP_QTY"].toInt();

                            if (newRow["SHIP_QTY"].toInt() > 0)
                            {
                                newRow["ORD_SHIP_FLAG"] = 2;
                            }
                            else
                            {
                                newRow["ORD_SHIP_FLAG"] = 0;
                            }

                            outshipTable.Rows.Add(newRow);

                            DMAT.TMAT_OUT.TMAT_OUT_UPD3(outshipTable, bizExecute);
                        }
                    }

                    int cancelQty = dtSer.Rows[0]["SHIP_QTY"].toInt();

                    //작지수랑 마이너스
                    UTIL.SetBizAddColumnToValue(dtSerProd, "WO_TYPE", "SHP", typeof(string));
                    dtSerProd.Rows[0]["DATA_FLAG"] = "0";
                    
                    DataTable WoRslt = DSHP.TSHP_WORKORDER_QUERY.TSHP_WORKORDER_QUERY33(UTIL.GetRowToDt(dtSerProd.Rows[0]), bizExecute);

                    string woFlag = "1";
                    

                    foreach (DataRow rw in WoRslt.Rows)
                    {
                        int qty = rw["ACT_QTY"].toInt() - cancelQty;

                        rw["ACT_END_TIME"] = DBNull.Value;
                        if (qty > 0)
                        {
                            woFlag = "2";
                        }
                        else
                        {
                            rw["ACT_START_TIME"] = DBNull.Value;
                        }

                        rw["WO_FLAG"] = woFlag;


                        rw["ACT_QTY"] = qty < 0 ? 0 : qty;

                        DSHP.TSHP_WORKORDER.TSHP_WORKORDER_UPD38(UTIL.GetRowToDt(rw), bizExecute);

                    }



                    DataTable dtShip = DORD.TORD_SHIP.TORD_SHIP_SER2(UTIL.GetRowToDt(row), bizExecute);

                    string poNo = string.Empty;

                    foreach (DataRow poRow in dtShip.Rows)
                    {
                        if (poNo.IndexOf(poRow["SHIP_PO_NO"].ToString()) < 0)
                        {
                            poNo += poRow["SHIP_PO_NO"].ToString() + ", ";
                        }
                    }

                    if (poNo.Length > 0)
                    {
                        poNo = poNo.Substring(0, poNo.Length - 2);
                    }

                    row["PO_NO"] = poNo;

                    DORD.TORD_PRODUCT.TORD_PRODUCT_UPD16(UTIL.GetRowToDt(row), bizExecute);


                }

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet ORD04A_INS(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    DataTable shipRslt = DORD.TORD_SHIP.TORD_SHIP_SER(UTIL.GetRowToDt(row), bizExecute);

                    if (shipRslt.Rows.Count > 0)
                    {
                        DORD.TORD_SHIP.TORD_SHIP_UPD(UTIL.GetRowToDt(row), bizExecute);
                    }
                }

                return ORD04A_SER(paramDS, bizExecute);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet ORD04A_INS2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    DataTable shipRslt = DORD.TORD_SHIP.TORD_SHIP_SER(UTIL.GetRowToDt(row), bizExecute);

                    if (shipRslt.Rows.Count > 0)
                    {
                        DORD.TORD_SHIP.TORD_SHIP_UPD2(UTIL.GetRowToDt(row), bizExecute);
                    }
                }

                return ORD04A_SER(paramDS, bizExecute);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet ORD04A_INS3(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "PO_NO", null, typeof(string));

                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    DataTable shipRslt = DORD.TORD_SHIP.TORD_SHIP_SER(UTIL.GetRowToDt(row), bizExecute);

                    if (shipRslt.Rows.Count > 0)
                    {
                        DORD.TORD_SHIP.TORD_SHIP_UPD3(UTIL.GetRowToDt(row), bizExecute);
                    }

                    DataTable dtShip = DORD.TORD_SHIP.TORD_SHIP_SER2(UTIL.GetRowToDt(row), bizExecute);

                    string poNo = string.Empty;

                    foreach (DataRow poRow in dtShip.Rows)
                    {
                        if (poNo.IndexOf(poRow["SHIP_PO_NO"].ToString()) < 0)
                        {
                            poNo += poRow["SHIP_PO_NO"].ToString() + ", ";
                        }
                    }

                    if (poNo.Length > 0)
                    {
                        poNo = poNo.Substring(0, poNo.Length - 2);
                    }

                    row["PO_NO"] = poNo;

                    DORD.TORD_PRODUCT.TORD_PRODUCT_UPD16(UTIL.GetRowToDt(row), bizExecute);

                }


                paramDS.Tables["RQSTDT"].Columns.Remove("SHIP_ID");

                return ORD04A_SER(paramDS, bizExecute);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

    }
}
