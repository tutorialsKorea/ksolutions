using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace BORD
{
    public class ORD10A
    {
        public static DataSet ORD10A_SER(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));
                //UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "SHIP_FLAG", "1", typeof(string));

                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "PROD_KIND", "IE,SK", typeof(string));
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "PROD_STATE_IN", "1,2,3,7,8,10,12,13", typeof(string));

                DataTable dtRslt = DORD.TORD_PRODUCT_QUERY.TORD_PRODUCT_QUERY2(paramDS.Tables["RQSTDT"], bizExecute);

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
        /// 출하지시
        /// </summary>
        /// <param name="paramDS"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataSet ORD10A_UPD(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "PROD_STATE", "13", typeof(string));

                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    DataTable dtStock = paramDS.Tables["RQSTDT_STOCK"].Select(string.Format("PROD_CODE = '{0}'", row["PROD_CODE"])).CopyToDataTable();

                    foreach (DataRow stkRow in dtStock.Rows)
                    {
                        //TMAT_PARTLIST생성
                        DataTable matRslt = DMAT.TMAT_PARTLIST.TMAT_PARTLIST_SER3(UTIL.GetRowToDt(stkRow), bizExecute);

                        DataTable partRslt = DLSE.LSE_STD_PART.LSE_STD_PART_SER(UTIL.GetRowToDt(stkRow), bizExecute);

                        if (partRslt.Rows.Count == 0)
                        {
                            continue;
                        }

                        int cnt = matRslt.Rows.Count + 1;

                        string pt_id = row["PROD_CODE"].ToString() + "_" + stkRow["PART_CODE"].ToString() + "_" + cnt.ToString().PadLeft(3, '0');

                        DataTable partListTable = new DataTable("RQSTDT");
                        partListTable.Columns.Add("PLT_CODE", typeof(string));
                        partListTable.Columns.Add("PT_ID", typeof(string));
                        partListTable.Columns.Add("PT_NO", typeof(string));
                        partListTable.Columns.Add("PROD_CODE", typeof(string));
                        partListTable.Columns.Add("PART_CODE", typeof(string));
                        partListTable.Columns.Add("PT_NAME", typeof(string));
                        partListTable.Columns.Add("PART_QTY", typeof(int));

                        DataRow partListRow = partListTable.NewRow();
                        partListRow["PLT_CODE"] = ConnInfo.PLT_CODE;
                        partListRow["PT_ID"] = pt_id;
                        partListRow["PT_NO"] = UTIL.UTILITY_GET_SERIALNO(ConnInfo.PLT_CODE, "PT", bizExecute);
                        partListRow["PROD_CODE"] = stkRow["PROD_CODE"];
                        partListRow["PART_CODE"] = stkRow["PART_CODE"];
                        partListRow["PT_NAME"] = partRslt.Rows[0]["PART_NAME"];
                        partListRow["PART_QTY"] = 1;

                        partListTable.Rows.Add(partListRow);

                        DMAT.TMAT_PARTLIST.TMAT_PARTLIST_INS(partListTable, bizExecute);


                        //TMAT_OUT_REQ생성
                        DataTable matOutTable = new DataTable("RQSTDT");
                        matOutTable.Columns.Add("PLT_CODE", typeof(string));
                        matOutTable.Columns.Add("OUT_REQ_ID", typeof(string));
                        matOutTable.Columns.Add("PT_ID", typeof(string));
                        matOutTable.Columns.Add("PART_CODE", typeof(string));
                        matOutTable.Columns.Add("OUT_REQ_DATE", typeof(string));
                        matOutTable.Columns.Add("OUT_REQ_EMP", typeof(string));
                        matOutTable.Columns.Add("OUT_REQ_QTY", typeof(int));
                        matOutTable.Columns.Add("OUT_REQ_STAT", typeof(string));
                        matOutTable.Columns.Add("OUT_REQ_LOC", typeof(string));
                        matOutTable.Columns.Add("DATA_FLAG", typeof(byte));

                        DataRow matOutRow = matOutTable.NewRow();
                        matOutRow["PLT_CODE"] = ConnInfo.PLT_CODE;
                        matOutRow["OUT_REQ_ID"] = UTIL.UTILITY_GET_SERIALNO(ConnInfo.PLT_CODE, "QREQ", bizExecute);
                        matOutRow["PT_ID"] = pt_id;
                        matOutRow["PART_CODE"] = stkRow["PART_CODE"];
                        matOutRow["OUT_REQ_DATE"] = DateTime.Now.ToString("yyyyMMdd");
                        matOutRow["OUT_REQ_EMP"] = ConnInfo.UserID;
                        matOutRow["OUT_REQ_QTY"] = stkRow["OUT_QTY"];
                        matOutRow["OUT_REQ_STAT"] = "50";
                        matOutRow["OUT_REQ_LOC"] = "ORD";
                        matOutRow["DATA_FLAG"] = "0";

                        matOutTable.Rows.Add(matOutRow);

                        DMAT.TMAT_OUT_REQ.TMAT_OUT_REQ_INS(matOutTable, bizExecute);

                        if (paramDS.Tables.Contains("RQSTDT2"))
                        {
                            if (paramDS.Tables["RQSTDT2"].Rows.Count != 0)
                            {
                                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT2"], "OUT_REQ_ID", "", typeof(string));
                                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT2"], "IS_POPUP", 0, typeof(byte));

                                foreach (DataRow row2 in paramDS.Tables["RQSTDT2"].Rows)
                                {
                                    row2["OUT_REQ_ID"] = matOutRow["OUT_REQ_ID"];

                                    DMAT.TMAT_OUT_REQ_EMP.TMAT_OUT_REQ_EMP_INS(UTIL.GetRowToDt(row2), bizExecute);
                                }
                            }
                        }
                    }

                    DORD.TORD_PRODUCT.TORD_PRODUCT_UPD2(UTIL.GetRowToDt(row), bizExecute);
                }

                

                return ORD10A_SER(paramDS, bizExecute);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet ORD10A_UPD2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "SHIP_ID", null, typeof(string));
                //UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "SHIP_EMP", null, typeof(string));
                //UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "SHIP_DATE", null, typeof(string));
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "SHIP_FLAG", "1", typeof(string));
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "PROD_STATE", "9", typeof(string));
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "WO_TYPE", "SHP", typeof(string));

                //UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "BILL_NO", "", typeof(string));
                //UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "BILL_TYPE", "TRADE", typeof(string));
                //UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "BILL_DATE", "SHIP_DATE");
                //UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "BILL_EMP", "SHIP_EMP");
                //UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "BILL_QTY", "SHIP_QTY");
                //UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "TAX_DATE", typeof(string));
                //UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "TRADE_DATE", typeof(string));

                //UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT_STOCK"], "OUT_QTY", typeof(int));
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT_STOCK"], "REMAIN_QTY", typeof(int));


                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT_STOCK"], "ORD_SHIP_FLAG", 1, typeof(byte));


                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "PO_NO", null, typeof(string));

                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    string ship_id = UTIL.UTILITY_GET_SERIALNO(ConnInfo.PLT_CODE, "SH", bizExecute);

                    row["SHIP_ID"] = ship_id;
                    //row["SHIP_EMP"] = ConnInfo.UserID;


                    DORD.TORD_SHIP.TORD_SHIP_INS(UTIL.GetRowToDt(row), bizExecute);

                    DataTable dtStock = paramDS.Tables["RQSTDT_STOCK"].Select(string.Format("PROD_CODE = '{0}'", row["PROD_CODE"])).CopyToDataTable();

                    UTIL.SetBizAddColumnToValue(dtStock, "SHIP_ID", ship_id, typeof(string));


                    foreach (DataRow stkRow in dtStock.Rows)
                    {
                        DataTable partRslt = DLSE.LSE_STD_PART.LSE_STD_PART_SER(UTIL.GetRowToDt(stkRow), bizExecute);

                        if (partRslt.Rows.Count == 0)
                        {
                            continue;
                        }

                        int shipQty = stkRow["SHIP_QTY"].toInt();

                        DataTable oldOut = DMAT.TMAT_OUT.TMAT_OUT_SER(UTIL.GetRowToDt(stkRow), bizExecute);

                        if (oldOut.Rows.Count > 0)
                        {
                            stkRow["REMAIN_QTY"] = oldOut.Rows[0]["REMAIN_QTY"].toInt() - stkRow["SHIP_QTY"].toInt();
                            stkRow["SHIP_QTY"] = oldOut.Rows[0]["SHIP_QTY"].toInt() + stkRow["SHIP_QTY"].toInt();
                        }
                        else
                        {
                            stkRow["REMAIN_QTY"] = stkRow["OUT_QTY"].toInt() - stkRow["SHIP_QTY"].toInt();
                            stkRow["SHIP_QTY"] = stkRow["SHIP_QTY"].toInt();
                        }

                        if (stkRow["OUT_QTY"].toInt() > stkRow["SHIP_QTY"].toInt())
                        {
                            stkRow["ORD_SHIP_FLAG"] = 2;
                        }
                        

                        //불출건 출하여부 수정
                        DMAT.TMAT_OUT.TMAT_OUT_UPD3(UTIL.GetRowToDt(stkRow), bizExecute);

                        DataTable outShipTable = new DataTable("RQSTDT");
                        outShipTable.Columns.Add("PLT_CODE", typeof(String));
                        outShipTable.Columns.Add("SHIP_ID", typeof(String));
                        outShipTable.Columns.Add("OUT_ID", typeof(String));
                        outShipTable.Columns.Add("SHIP_QTY", typeof(int));


                        DataRow newRow = outShipTable.NewRow();
                        newRow["PLT_CODE"] = ConnInfo.PLT_CODE;
                        newRow["SHIP_ID"] = ship_id;
                        newRow["OUT_ID"] = stkRow["OUT_ID"];
                        newRow["SHIP_QTY"] = shipQty;
                        outShipTable.Rows.Add(newRow);

                        DMAT.TMAT_OUT_SHIP.TMAT_OUT_SHIP_INS(outShipTable, bizExecute);

                        //상품별 납품일/금액 등록?
                    }

                    //수주상태 변경
                    DataTable dtRslt = DORD.TORD_PRODUCT_QUERY.TORD_PRODUCT_QUERY2(UTIL.GetRowToDt(row), bizExecute);


                    //부분출하 판단
                    if (dtRslt.Rows.Count > 0)
                    {
                        row["PROD_STATE"] = "8";
                    }

                    DORD.TORD_PRODUCT.TORD_PRODUCT_UPD3(UTIL.GetRowToDt(row), bizExecute);


                    DataTable WoRslt = DSHP.TSHP_WORKORDER_QUERY.TSHP_WORKORDER_QUERY33(UTIL.GetRowToDt(row), bizExecute);

                    string woFlag = "4";

                    if (row["PROD_STATE"].ToString() == "8")
                    {
                        woFlag = "2";
                    }

                    DataTable woTable = new DataTable("RQSTDT");
                    woTable.Columns.Add("PLT_CODE", typeof(string));
                    woTable.Columns.Add("WO_NO", typeof(string));
                    woTable.Columns.Add("WO_FLAG", typeof(string));
                    woTable.Columns.Add("ACT_START_TIME", typeof(DateTime));
                    woTable.Columns.Add("ACT_END_TIME", typeof(DateTime));
                    woTable.Columns.Add("ACT_QTY", typeof(int));

                    foreach (DataRow rw in WoRslt.Rows)
                    {
                        rw["WO_FLAG"] = woFlag;
                        if (rw["ACT_START_TIME"].isNullOrEmpty()) rw["ACT_START_TIME"] = DateTime.Now;
                        if (woFlag == "4" && rw["ACT_END_TIME"].isNullOrEmpty()) rw["ACT_END_TIME"] = DateTime.Now;
                        rw["ACT_QTY"] = rw["ACT_QTY"].toInt() + row["SHIP_QTY"].toInt();

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



                    //string bill_no = UTIL.UTILITY_GET_SERIALNO(ConnInfo.PLT_CODE, "BILL", bizExecute);
                    //row["BILL_NO"] = bill_no;
                    //DORD.TORD_PRODUCT_BILL.TORD_PRODUCT_BILL_INS(UTIL.GetRowToDt(row), bizExecute);

                    //DataTable dtBill = DORD.TORD_PRODUCT_BILL.TORD_PRODUCT_BILL_SER2(UTIL.GetRowToDt(row), bizExecute);


                    //string tax_date = string.Empty;
                    //string trade_date = string.Empty;

                    //foreach (DataRow billRow in dtBill.Rows)
                    //{
                    //    switch (billRow["BILL_TYPE"].ToString())
                    //    {
                    //        case "TAX":
                    //            tax_date += billRow["BILL_DATE"].toDateString("yyyy-MM-dd") + " (" + billRow["BILL_QTY"].ToString() + ")" + ", ";
                    //            break;
                    //        case "TRADE":
                    //            trade_date += billRow["BILL_DATE"].toDateString("yyyy-MM-dd") + " (" + billRow["BILL_QTY"].ToString() + ")" + ", ";
                    //            break;
                    //    }
                    //}

                    //if (tax_date.Length > 0)
                    //    tax_date = tax_date.Substring(0, tax_date.Length - 2);

                    //if (trade_date.Length > 0)
                    //    trade_date = trade_date.Substring(0, trade_date.Length - 2);

                    //row["TAX_DATE"] = tax_date;
                    //row["TRADE_DATE"] = trade_date;
                    //DORD.TORD_PRODUCT.TORD_PRODUCT_UPD6(UTIL.GetRowToDt(row), bizExecute);

                }

                return ORD10A_SER(paramDS, bizExecute);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        /// <summary>
        /// 출하장 출력(Log관리?)
        /// </summary>
        /// <param name="paramDS"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataSet ORD10A_PRINT(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "SHIP_FLAG", "1", typeof(string));

                DataTable dtRslt = DORD.TORD_PRODUCT_QUERY.TORD_PRODUCT_QUERY2(paramDS.Tables["RQSTDT"], bizExecute);

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

       

        public static DataSet ORD10A_SER2(DataSet paramDS, BizExecute.BizExecute bizExe)
        {
            try
            {
                //UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "MAT_LTYPE", "11", typeof(string));

                //UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "STOCK_ZERO", "1", typeof(string));

                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "IS_MAIN", "1", typeof(string));

                DataTable dtRslt = DMAT.TMAT_STOCK_QUERY.TMAT_STOCK_QUERY1(paramDS.Tables["RQSTDT"], bizExe);

                dtRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRslt);


                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet ORD10A_SER3(DataSet paramDS, BizExecute.BizExecute bizExe)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "OUT_REQ_STAT", "52", typeof(string)); 
                DataTable dtRslt = DMAT.TMAT_OUT_REQ_QUERY.TMAT_OUT_REQ_QUERY6(paramDS.Tables["RQSTDT"], bizExe);

                dtRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRslt);


                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet ORD10A_SER4(DataSet paramDS, BizExecute.BizExecute bizExe)
        {
            try
            {
                DataTable dtRslt = DMAT.TMAT_OUT_REQ_QUERY.TMAT_OUT_REQ_QUERY8(paramDS.Tables["RQSTDT"], bizExe);

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
        /// 출하지시 취소
        /// </summary>
        /// <param name="paramDS"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataSet ORD10A_RETURN(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "SHIP_FLAG", "0", typeof(string));
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "PROD_STATE", "11", typeof(string));

                DORD.TORD_PRODUCT.TORD_PRODUCT_UPD8(paramDS.Tables["RQSTDT"], bizExecute);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }
    }
}
