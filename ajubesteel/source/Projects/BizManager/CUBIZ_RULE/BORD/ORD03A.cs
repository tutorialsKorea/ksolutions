using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace BORD
{
    public class ORD03A
    {
        public static DataSet ORD03A_SER(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "SHIP_FLAG", "1", typeof(string));

                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "NOT_PROD_KIND", "IE,SK", typeof(string));

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
        /// 출하처리
        /// </summary>
        /// <param name="paramDS"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataSet ORD03A_UPD(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "SHIP_ID", null, typeof(string));
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "SHIP_FLAG", "1", typeof(string));
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "PROD_STATE", "9", typeof(string));
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "WO_TYPE", "SHP", typeof(string));
                //UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "SHIP_EMP", null, typeof(string));
                //UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "SHIP_DATE", null, typeof(string));
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "PO_NO", null, typeof(string));

                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "BILL_NO", "", typeof(string));
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "BILL_TYPE", "TRADE", typeof(string));
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "BILL_DATE", "SHIP_DATE");
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "BILL_EMP", "SHIP_EMP");
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "BILL_QTY", "SHIP_QTY");
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "TAX_DATE", typeof(string));
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "TRADE_DATE", typeof(string));

                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    string ship_id = UTIL.UTILITY_GET_SERIALNO(ConnInfo.PLT_CODE, "SH", bizExecute);

                    row["SHIP_ID"] = ship_id;
                    //row["SHIP_EMP"] = ConnInfo.UserID;

                    DORD.TORD_SHIP.TORD_SHIP_INS(UTIL.GetRowToDt(row), bizExecute);

                    DataTable dtRslt = DORD.TORD_PRODUCT_QUERY.TORD_PRODUCT_QUERY2(UTIL.GetRowToDt(row), bizExecute);

                    //dtRslt.Columns.Add("SEL");
                    //dtRslt.TableName = "RSLTDT";

                    //paramDS.Merge(dtRslt);

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


                return ORD03A_SER(paramDS, bizExecute);
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
        public static DataSet ORD03A_PRINT(DataSet paramDS, BizExecute.BizExecute bizExecute)
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


        /// <summary>
        /// 출하지시 취소
        /// </summary>
        /// <param name="paramDS"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataSet ORD03A_RETURN(DataSet paramDS, BizExecute.BizExecute bizExecute)
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
