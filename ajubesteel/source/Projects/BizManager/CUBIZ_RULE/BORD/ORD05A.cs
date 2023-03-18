using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace BORD
{
    public class ORD05A
    {

        public static DataSet ORD05A_SER(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "SHIP_FLAG", "1", typeof(string));
                //UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "SHIP_STATE", "", typeof(string));

                DataTable dtRslt = DORD.TORD_PRODUCT_QUERY.TORD_PRODUCT_QUERY2_1(paramDS.Tables["RQSTDT"], bizExecute);

                dtRslt.Columns.Add("SEL");
                dtRslt.TableName = "RSLTDT";

                string prodCodeIn = "";

                foreach (DataRow row in dtRslt.Rows)
                {
                    prodCodeIn = prodCodeIn + "," + row["PROD_CODE"].ToString();
                }

                if (prodCodeIn.Length > 0)
                {
                    prodCodeIn = prodCodeIn.Substring(1, prodCodeIn.Length - 1);

                    DataTable billTable = new DataTable("RQSTDT");
                    billTable.Columns.Add("PLT_CODE", typeof(String));
                    billTable.Columns.Add("PROD_CODE_IN", typeof(String));
                    billTable.Columns.Add("DATA_FLAG", typeof(byte));

                    DataRow billRow = billTable.NewRow();
                    billRow["PLT_CODE"] = ConnInfo.PLT_CODE;
                    billRow["PROD_CODE_IN"] = prodCodeIn;
                    billRow["DATA_FLAG"] = 0;
                    billTable.Rows.Add(billRow);

                    DataTable dtRslt_bill = DORD.TORD_PRODUCT_BILL_QUERY.TORD_PRODUCT_BILL_QUERY1(billTable, bizExecute);
                    dtRslt_bill.TableName = "RSLTDT_BILL";
                    paramDS.Tables.Add(dtRslt_bill);

                }

                paramDS.Tables.Add(dtRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }


        public static DataSet ORD05A_SER2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));
                
                DataTable dtRslt = DORD.TORD_PRODUCT_BILL.TORD_PRODUCT_BILL_SER3(paramDS.Tables["RQSTDT"], bizExecute);

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
        /// 세금계산서, 거래명세표 발행일 등록
        /// </summary>
        /// <param name="paramDS"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataSet ORD05A_INS(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte),true);
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "BILL_NO",typeof(string));
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "TAX_DATE", typeof(string));
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "TRADE_DATE", typeof(string));
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "COL_DATE", typeof(string));
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "COL_PLAN_DATE", typeof(string));

                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    if (row["BILL_TYPE"].ToString() == "") continue;

                    DataTable dtSer = DORD.TORD_PRODUCT_BILL.TORD_PRODUCT_BILL_SER(UTIL.GetRowToDt(row), bizExecute);

                    if(dtSer.Rows.Count > 0)
                    {
                        DORD.TORD_PRODUCT_BILL.TORD_PRODUCT_BILL_UPD(UTIL.GetRowToDt(row), bizExecute);
                    }
                    else
                    {
                        string bill_no = UTIL.UTILITY_GET_SERIALNO(ConnInfo.PLT_CODE, "BILL", bizExecute);
                        row["BILL_NO"] = bill_no;
                        DORD.TORD_PRODUCT_BILL.TORD_PRODUCT_BILL_INS(UTIL.GetRowToDt(row), bizExecute);
                    }

                    DataTable dtBill = DORD.TORD_PRODUCT_BILL.TORD_PRODUCT_BILL_SER2(UTIL.GetRowToDt(row), bizExecute);

                    string tax_date = string.Empty;
                    string trade_date = string.Empty;
                    string col_date = string.Empty;
                    string col_plan_date = string.Empty;

                    foreach (DataRow billRow in dtBill.Rows)
                    {
                        string billQty = string.Format("{0:n0}", billRow["BILL_QTY"]);
                        string billAmt = string.Format("{0:n2}", billRow["BILL_AMT"]);

                        switch (billRow["BILL_TYPE"].ToString())
                        {
                            case "TAX":
                                tax_date += billRow["BILL_DATE"].toDateString("yyyy-MM-dd") + " (" + billQty + ", " + billAmt + ")" +  ", ";

                                if (billRow["COL_PLAN_DATE"].ToString() != "")
                                {
                                    col_plan_date += billRow["COL_PLAN_DATE"].toDateString("yyyy-MM-dd") + " (" + billQty + ", " + billAmt + ")" + ", ";
                                }

                                break;
                            case "TRADE":
                                trade_date += billRow["BILL_DATE"].toDateString("yyyy-MM-dd") + " (" + billQty + ", " + billAmt + ")" + ", ";
                                break;
                            case "COL":
                                col_date += billRow["BILL_DATE"].toDateString("yyyy-MM-dd") + " (" + billQty + ", " + billAmt + ")" + ", ";
                                break;
                        }
                    }

                    if (tax_date.Length > 0)
                        tax_date = tax_date.Substring(0, tax_date.Length - 2);

                    if (trade_date.Length > 0)
                        trade_date = trade_date.Substring(0, trade_date.Length - 2);

                    if (col_date.Length > 0)
                        col_date = col_date.Substring(0, col_date.Length - 2);

                    if (col_plan_date.Length > 0)
                        col_plan_date = col_plan_date.Substring(0, col_plan_date.Length - 2);


                    row["TAX_DATE"] = tax_date;
                    row["TRADE_DATE"] = trade_date;
                    row["COL_DATE"] = col_date;
                    row["COL_PLAN_DATE"] = col_plan_date;
                    DORD.TORD_PRODUCT.TORD_PRODUCT_UPD6(UTIL.GetRowToDt(row), bizExecute);

                }

                #region 삭제건이 있으면
                if (paramDS.Tables.Contains("RQSTDT_DEL"))
                {
                    if (paramDS.Tables["RQSTDT_DEL"].Rows.Count > 0)
                    {
                        UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT_DEL"], "TAX_DATE", typeof(string));
                        UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT_DEL"], "TRADE_DATE", typeof(string));
                        UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT_DEL"], "COL_DATE", typeof(string));
                        UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT_DEL"], "COL_PLAN_DATE", typeof(string));

                        DORD.TORD_PRODUCT_BILL.TORD_PRODUCT_BILL_UDE(paramDS.Tables["RQSTDT_DEL"], bizExecute);

                        DataTable dtBill = DORD.TORD_PRODUCT_BILL.TORD_PRODUCT_BILL_SER2(UTIL.GetRowToDt(paramDS.Tables["RQSTDT_DEL"].Rows[0]), bizExecute);

                        string tax_date = string.Empty;
                        string trade_date = string.Empty;
                        string col_date = string.Empty;
                        string col_plan_date = string.Empty;

                        foreach (DataRow billRow in dtBill.Rows)
                        {
                            string billQty = string.Format("{0:n0}", billRow["BILL_QTY"]);
                            string billAmt = string.Format("{0:n2}", billRow["BILL_AMT"]);

                            switch (billRow["BILL_TYPE"].ToString())
                            {
                                case "TAX":
                                    tax_date += billRow["BILL_DATE"].toDateString("yyyy-MM-dd") + " (" + billQty + ", " + billAmt + ")" + ", ";
                                    col_plan_date += billRow["COL_PLAN_DATE"].toDateString("yyyy-MM-dd") + " (" + billQty + ", " + billAmt + ")" + ", ";
                                    break;
                                case "TRADE":
                                    trade_date += billRow["BILL_DATE"].toDateString("yyyy-MM-dd") + " (" + billQty + ", " + billAmt + ")" + ", ";
                                    break;
                                case "COL":
                                    col_date += billRow["BILL_DATE"].toDateString("yyyy-MM-dd") + " (" + billQty + ", " + billAmt + ")" + ", ";
                                    break;
                            }

                        }

                        if (tax_date.Length > 0)
                            tax_date = tax_date.Substring(0, tax_date.Length - 2);

                        if (trade_date.Length > 0)
                            trade_date = trade_date.Substring(0, trade_date.Length - 2);

                        if (col_date.Length > 0)
                            col_date = col_date.Substring(0, col_date.Length - 2);

                        if (col_plan_date.Length > 0)
                            col_plan_date = col_plan_date.Substring(0, col_plan_date.Length - 2);

                        paramDS.Tables["RQSTDT_DEL"].Rows[0]["TAX_DATE"] = tax_date;
                        paramDS.Tables["RQSTDT_DEL"].Rows[0]["TRADE_DATE"] = trade_date;
                        paramDS.Tables["RQSTDT_DEL"].Rows[0]["COL_DATE"] = col_date;
                        paramDS.Tables["RQSTDT_DEL"].Rows[0]["COL_PLAN_DATE"] = col_plan_date;
                        DORD.TORD_PRODUCT.TORD_PRODUCT_UPD6(UTIL.GetRowToDt(paramDS.Tables["RQSTDT_DEL"].Rows[0]), bizExecute);
                    }

                }
                #endregion

                return ORD05A_SER(paramDS, bizExecute);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet ORD05A_INS2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    DataTable prodRslt = DORD.TORD_PRODUCT.TORD_PRODUCT_SER(UTIL.GetRowToDt(row), bizExecute);

                    if (prodRslt.Rows.Count > 0)
                    {
                        DORD.TORD_PRODUCT.TORD_PRODUCT_UPD11(UTIL.GetRowToDt(row), bizExecute);
                    }
                }

                return ORD05A_SER(paramDS, bizExecute);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet ORD05A_INS3(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    DataTable prodRslt = DORD.TORD_PRODUCT.TORD_PRODUCT_SER(UTIL.GetRowToDt(row), bizExecute);

                    if (prodRslt.Rows.Count > 0)
                    {
                        DORD.TORD_PRODUCT.TORD_PRODUCT_UPD12(UTIL.GetRowToDt(row), bizExecute);
                    }
                }

                return ORD05A_SER(paramDS, bizExecute);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet ORD05A_INS4(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "TRADE_DATE", typeof(string));

                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {

                    DataTable billRslt = DORD.TORD_PRODUCT_BILL.TORD_PRODUCT_BILL_SER4(UTIL.GetRowToDt(row), bizExecute);

                    DataTable prodRslt = DORD.TORD_PRODUCT.TORD_PRODUCT_SER(UTIL.GetRowToDt(row), bizExecute);

                    int billQty = 0;

                    Decimal billAmt = 0;

                    if (prodRslt.Rows.Count > 0)
                    {
                        billQty = prodRslt.Rows[0]["PROD_QTY"].toInt();
                        billAmt = prodRslt.Rows[0]["PROD_AMT"].toDecimal();
                    }

                    if (billRslt.Rows.Count > 0)
                    {
                        billQty = billQty - billRslt.Rows[0]["BILL_QTY"].toInt();
                        billAmt = billAmt - billRslt.Rows[0]["BILL_AMT"].toDecimal();
                    }

                    if (billQty <= 0) continue;

                    DataTable paramTable = new DataTable("RQSTDT");
                    paramTable.Columns.Add("PLT_CODE", typeof(string));
                    paramTable.Columns.Add("BILL_NO", typeof(string));
                    paramTable.Columns.Add("BILL_TYPE", typeof(string));
                    paramTable.Columns.Add("PROD_CODE", typeof(string));
                    paramTable.Columns.Add("BILL_DATE", typeof(string));
                    paramTable.Columns.Add("BILL_EMP", typeof(string));
                    paramTable.Columns.Add("BILL_QTY", typeof(int));
                    paramTable.Columns.Add("BILL_AMT", typeof(Decimal));
                    paramTable.Columns.Add("DATA_FLAG", typeof(byte));

                    DataRow paramRow = paramTable.NewRow();
                    paramRow["PLT_CODE"] = ConnInfo.PLT_CODE;
                    paramRow["BILL_NO"] = UTIL.UTILITY_GET_SERIALNO(ConnInfo.PLT_CODE, "BILL", bizExecute);
                    paramRow["BILL_TYPE"] = row["BILL_TYPE"];
                    paramRow["PROD_CODE"] = row["PROD_CODE"];
                    paramRow["BILL_DATE"] = row["BILL_DATE"];
                    paramRow["BILL_EMP"] = ConnInfo.UserID;
                    paramRow["BILL_QTY"] = billQty;
                    paramRow["BILL_AMT"] = billAmt;
                    paramRow["DATA_FLAG"] = 0;

                    paramTable.Rows.Add(paramRow);

                    DORD.TORD_PRODUCT_BILL.TORD_PRODUCT_BILL_INS(paramTable, bizExecute);



                    DataTable dtBill = DORD.TORD_PRODUCT_BILL.TORD_PRODUCT_BILL_SER2(UTIL.GetRowToDt(row), bizExecute);

                    string tax_date = string.Empty;
                    string trade_date = string.Empty;
                    string col_date = string.Empty;

                    foreach (DataRow billRow in dtBill.Rows)
                    {
                        string pordBillQty = string.Format("{0:n0}", billRow["BILL_QTY"]);
                        string prodBillAmt = string.Format("{0:n2}", billRow["BILL_AMT"]);

                        switch (billRow["BILL_TYPE"].ToString())
                        {
                            case "TAX":
                                tax_date += billRow["BILL_DATE"].toDateString("yyyy-MM-dd") + " (" + pordBillQty + ", " + prodBillAmt + ")" + ", ";
                                break;
                            case "TRADE":
                                trade_date += billRow["BILL_DATE"].toDateString("yyyy-MM-dd") + " (" + pordBillQty + ", " + prodBillAmt + ")" + ", ";
                                break;
                            case "COL":
                                col_date += billRow["BILL_DATE"].toDateString("yyyy-MM-dd") + " (" + pordBillQty + ", " + prodBillAmt + ")" + ", ";
                                break;
                        }
                    }

                    if (tax_date.Length > 0)
                        tax_date = tax_date.Substring(0, tax_date.Length - 2);

                    if (trade_date.Length > 0)
                        trade_date = trade_date.Substring(0, trade_date.Length - 2);

                    row["TAX_DATE"] = tax_date;
                    row["TRADE_DATE"] = trade_date;
                    row["COL_DATE"] = col_date;
                    DORD.TORD_PRODUCT.TORD_PRODUCT_UPD6(UTIL.GetRowToDt(row), bizExecute);

                }


                #region 세금계산서 기준 수금일 일괄등록
                //UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "BILL_TYPE", "TAX", typeof(String));
                //UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "COLLECT_DATE", "COL_DATE");
                //UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(byte));

                //foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                //{
                //    DataTable prodRslt = DORD.TORD_PRODUCT.TORD_PRODUCT_SER(UTIL.GetRowToDt(row), bizExecute);

                //    if (prodRslt.Rows.Count > 0)
                //    {
                //        DataTable rsltdt_Col = DORD.TORD_PRODUCT_BILL.TORD_PRODUCT_BILL_SER5(UTIL.GetRowToDt(row), bizExecute);

                //        if (rsltdt_Col.Rows.Count > 0)
                //        {
                //            rsltdt_Col.Rows[0]["COLLECT_DATE"] = row["COLLECT_DATE"];
                //            DORD.TORD_PRODUCT_BILL.TORD_PRODUCT_BILL_UPD2(UTIL.GetRowToDt(rsltdt_Col.Rows[0]), bizExecute);


                //            DataTable dtBill = DORD.TORD_PRODUCT_BILL.TORD_PRODUCT_BILL_SER2(UTIL.GetRowToDt(row), bizExecute);

                //            string collect_date = string.Empty;

                //            foreach (DataRow billRow in dtBill.Rows)
                //            {
                //                if (billRow["COLLECT_DATE"].toStringEmpty() == "") continue;

                //                switch (billRow["BILL_TYPE"].ToString())
                //                {
                //                    case "TAX":
                //                        collect_date += billRow["COLLECT_DATE"].toDateString("yyyy-MM-dd") + ", ";
                //                        break;
                //                }
                //            }

                //            if (collect_date.Length > 0)
                //                collect_date = collect_date.Substring(0, collect_date.Length - 2);


                //            row["COL_DATE"] = collect_date;
                //            DORD.TORD_PRODUCT.TORD_PRODUCT_UPD6_2(UTIL.GetRowToDt(row), bizExecute);
                //        }
                //    }
                //}
                #endregion

                return ORD05A_SER(paramDS, bizExecute);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet ORD05A_INS5(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "TAX_DATE", typeof(string));
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "TRADE_DATE", typeof(string));
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "COL_DATE", typeof(string));
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "COL_PLAN_DATE", typeof(string));

                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    //switch (row["BILL_TYPE"].ToString())
                    //{
                    //    case "TAX":

                    //        break;

                    //    case "TRADE":

                    //        break;
                    //}

                    DataTable billRslt = DORD.TORD_PRODUCT_BILL.TORD_PRODUCT_BILL_SER4(UTIL.GetRowToDt(row), bizExecute);

                    DataTable prodRslt = DORD.TORD_PRODUCT.TORD_PRODUCT_SER(UTIL.GetRowToDt(row), bizExecute);

                    int billQty = 0;

                    Decimal billAmt = 0;

                    if (prodRslt.Rows.Count > 0)
                    {
                        billQty = prodRslt.Rows[0]["PROD_QTY"].toInt();
                        billAmt = prodRslt.Rows[0]["PROD_AMT"].toDecimal();
                    }

                    if (billRslt.Rows.Count > 0)
                    {
                        billQty = billQty - billRslt.Rows[0]["BILL_QTY"].toInt();
                        billAmt = billAmt - billRslt.Rows[0]["BILL_AMT"].toDecimal();
                    }

                    if (billQty <= 0) continue;

                    DataTable paramTable = new DataTable("RQSTDT");
                    paramTable.Columns.Add("PLT_CODE", typeof(string));
                    paramTable.Columns.Add("BILL_NO", typeof(string));
                    paramTable.Columns.Add("BILL_TYPE", typeof(string));
                    paramTable.Columns.Add("PROD_CODE", typeof(string));
                    paramTable.Columns.Add("BILL_DATE", typeof(string));
                    paramTable.Columns.Add("BILL_EMP", typeof(string));
                    paramTable.Columns.Add("BILL_QTY", typeof(int));
                    paramTable.Columns.Add("BILL_AMT", typeof(Decimal));
                    paramTable.Columns.Add("DATA_FLAG", typeof(byte));

                    paramTable.Columns.Add("COL_PLAN_DATE", typeof(string));


                    DataRow paramRow = paramTable.NewRow();
                    paramRow["PLT_CODE"] = ConnInfo.PLT_CODE;
                    paramRow["BILL_NO"] = UTIL.UTILITY_GET_SERIALNO(ConnInfo.PLT_CODE, "BILL", bizExecute);
                    paramRow["BILL_TYPE"] = row["BILL_TYPE"];
                    paramRow["PROD_CODE"] = row["PROD_CODE"];
                    paramRow["BILL_DATE"] = row["BILL_DATE"];
                    paramRow["BILL_EMP"] = ConnInfo.UserID;
                    paramRow["BILL_QTY"] = billQty;
                    paramRow["BILL_AMT"] = billAmt;
                    paramRow["DATA_FLAG"] = 0;

                    paramRow["COL_PLAN_DATE"] = row["COL_PLAN_DATE"];

                    paramTable.Rows.Add(paramRow);

                    DORD.TORD_PRODUCT_BILL.TORD_PRODUCT_BILL_INS(paramTable, bizExecute);



                    DataTable dtBill = DORD.TORD_PRODUCT_BILL.TORD_PRODUCT_BILL_SER2(UTIL.GetRowToDt(row), bizExecute);

                    string tax_date = string.Empty;
                    string trade_date = string.Empty;
                    string col_date = string.Empty;
                    string col_plan_date = string.Empty;

                    foreach (DataRow billRow in dtBill.Rows)
                    {
                        string pordBillQty = string.Format("{0:n0}", billRow["BILL_QTY"]);
                        string prodBillAmt = string.Format("{0:n2}", billRow["BILL_AMT"]);

                        switch (billRow["BILL_TYPE"].ToString())
                        {
                            case "TAX":
                                tax_date += billRow["BILL_DATE"].toDateString("yyyy-MM-dd") + " (" + pordBillQty + ", " + prodBillAmt + ")" + ", ";

                                if (billRow["COL_PLAN_DATE"].ToString() != "")
                                {
                                    col_plan_date += billRow["COL_PLAN_DATE"].toDateString("yyyy-MM-dd") + " (" + billQty + ", " + billAmt + ")" + ", ";
                                }

                                break;
                            case "TRADE":
                                trade_date += billRow["BILL_DATE"].toDateString("yyyy-MM-dd") + " (" + pordBillQty + ", " + prodBillAmt + ")" + ", ";
                                break;
                            case "COL":
                                col_date += billRow["BILL_DATE"].toDateString("yyyy-MM-dd") + " (" + pordBillQty + ", " + prodBillAmt + ")" + ", ";
                                break;
                        }
                    }

                    if (tax_date.Length > 0)
                        tax_date = tax_date.Substring(0, tax_date.Length - 2);

                    if (trade_date.Length > 0)
                        trade_date = trade_date.Substring(0, trade_date.Length - 2);

                    if (col_date.Length > 0)
                        col_date = col_date.Substring(0, col_date.Length - 2);

                    if (col_plan_date.Length > 0)
                        col_plan_date = col_plan_date.Substring(0, col_plan_date.Length - 2);

                    row["TAX_DATE"] = tax_date;
                    row["TRADE_DATE"] = trade_date;
                    row["COL_DATE"] = col_date;
                    row["COL_PLAN_DATE"] = col_plan_date;

                    DORD.TORD_PRODUCT.TORD_PRODUCT_UPD6(UTIL.GetRowToDt(row), bizExecute);

                }

                return ORD05A_SER(paramDS, bizExecute);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet ORD05A_INS6(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));


                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {

                    DataTable dtRslt = DORD.TORD_PRODUCT.TORD_PRODUCT_SER(UTIL.GetRowToDt(row), bizExecute);

                    //데이터가 있을경우
                    if (dtRslt.Rows.Count > 0)
                    {
                        //데이터 삭제여부
                        if (row["OVERWRITE"].Equals("1"))
                        {
                            //덮어쓰기 여부
                            if (row["DATA_FLAG"].Equals("2"))
                            {
                                throw UTIL.SetException("동일 이력 데이터가 존재합니다."
                                   , new System.Diagnostics.StackFrame().GetMethod().Name);
                            }
                            else
                            {
                                DORD.TORD_PRODUCT.TORD_PRODUCT_UPD(UTIL.GetRowToDt(row), bizExecute);
                            }
                        }
                        //덮어쓰기 여부
                        else
                        {
                            throw UTIL.SetException("동일 데이터가 존재합니다."
                                , new System.Diagnostics.StackFrame().GetMethod().Name);
                        }
                    }
                    else
                    {
                        string prod_code = UTIL.UTILITY_GET_SERIALNO(row["PLT_CODE"].ToString(), "PROD", UTIL.emSerialFormat.YYYYMMDD, "-", bizExecute);

                        row["PROD_CODE"] = prod_code;

                        DORD.TORD_PRODUCT.TORD_PRODUCT_INS(UTIL.GetRowToDt(row), bizExecute);

                    }

                    //마감현황에서 bom관련 로직 필요여부 확인 필요
                    ////repeat 수주 bom 복사
                    //if (row["PROD_FLAG"].Equals("RE"))
                    //{

                    //    //구분이 제품인건만 BOM등록
                    //    //상품도 필요하다고 하면 자동 불출요청 로직 필요(확인필요)
                    //    if (row["PROD_KIND"].Equals("PD"))
                    //    {
                    //        DataTable dtExistBom = DORD.TORD_PRODUCT_QUERY.TORD_PRODUCT_QUERY1(UTIL.GetRowToDt(row), bizExecute);

                    //        DataTable dtCopyBom = new DataTable();

                    //        DataTable dttmpCopyBom = new DataTable();

                    //        if (paramDS.Tables.Contains("RQSTDT_BOM"))
                    //        {
                    //            dtCopyBom = paramDS.Tables["RQSTDT_BOM"]; // 편집된 BOM

                    //            dttmpCopyBom = paramDS.Tables["RQSTDT_BOM"].Copy(); // 편집된 BOM
                    //        }

                    //        DataTable dtDelBom = new DataTable();

                    //        if (paramDS.Tables.Contains("RQSTDT_DEL_BOM"))
                    //        {
                    //            dtDelBom = paramDS.Tables["RQSTDT_DEL_BOM"];
                    //        }


                    //        if (dtExistBom.Rows.Count > 0 && !dtExistBom.Rows[0]["BOM_FLAG"].Equals(1))
                    //        {
                    //            //Repeat인데 등록된 bom이 없으면 복사등록
                    //            SetCopyBom(row, dtCopyBom, bizExecute);

                    //            SetWorkOrderCreate(row, "RE", bizExecute);
                    //        }
                    //        else if (dtExistBom.Rows.Count > 0 && dtCopyBom.Rows.Count > 0)
                    //        {
                    //            //Repeat인데 편집된 bom이 있으면 수정
                    //            SetBom(row, dtCopyBom, dtDelBom, bizExecute);

                    //            SetWorkOrder(row, "RE", dttmpCopyBom, bizExecute);
                    //        }
                    //    }
                    //}
                    //else if (row["PROD_FLAG"].Equals("NE"))
                    //{
                    //    if (row["PROD_KIND"].Equals("PD"))
                    //    {
                    //        DataTable dtExistBom = DORD.TORD_PRODUCT_QUERY.TORD_PRODUCT_QUERY1(UTIL.GetRowToDt(row), bizExecute);

                    //        DataTable dtCopyBom = new DataTable();
                    //        DataTable dttmpCopyBom = new DataTable();

                    //        if (paramDS.Tables.Contains("RQSTDT_BOM"))
                    //        {
                    //            dtCopyBom = paramDS.Tables["RQSTDT_BOM"]; // 편집된 BOM

                    //            dttmpCopyBom = paramDS.Tables["RQSTDT_BOM"].Copy(); // 편집된 BOM
                    //        }

                    //        DataTable dtDelBom = new DataTable();

                    //        if (paramDS.Tables.Contains("RQSTDT_DEL_BOM"))
                    //        {
                    //            dtDelBom = paramDS.Tables["RQSTDT_DEL_BOM"];
                    //        }

                    //        if (dtExistBom.Rows.Count > 0 && dtCopyBom.Rows.Count > 0)
                    //        {
                    //            SetBom(row, dtCopyBom, dtDelBom, bizExecute);

                    //            SetWorkOrder(row, "RE", dttmpCopyBom, bizExecute);
                    //        }
                    //    }
                    //}


                }

                return ORD05A_SER(paramDS, bizExecute);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet ORD05A_INS7(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    DataTable prodRslt = DORD.TORD_PRODUCT.TORD_PRODUCT_SER(UTIL.GetRowToDt(row), bizExecute);

                    if (prodRslt.Rows.Count > 0)
                    {
                        DORD.TORD_PRODUCT.TORD_PRODUCT_UPD2_1(UTIL.GetRowToDt(row), bizExecute);
                    }
                }

                return ORD05A_SER(paramDS, bizExecute);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        //public static DataSet ORD05A_INS8(DataSet paramDS, BizExecute.BizExecute bizExecute)
        //{
        //    try
        //    {
        //        UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte), true);

        //        UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "COL_DATE", typeof(string));

        //        foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
        //        {
        //            DataTable dtSer = DORD.TORD_PRODUCT_BILL.TORD_PRODUCT_BILL_SER(UTIL.GetRowToDt(row), bizExecute);

        //            if (dtSer.Rows.Count > 0)
        //            {
        //                DORD.TORD_PRODUCT_BILL.TORD_PRODUCT_BILL_UPD2(UTIL.GetRowToDt(row), bizExecute);
        //            }

        //            DataTable dtBill = DORD.TORD_PRODUCT_BILL.TORD_PRODUCT_BILL_SER2(UTIL.GetRowToDt(row), bizExecute);

        //            string collect_date = string.Empty;

        //            foreach (DataRow billRow in dtBill.Rows)
        //            {
        //                if (billRow["COLLECT_DATE"].toStringEmpty() == "") continue;

        //                switch (billRow["BILL_TYPE"].ToString())
        //                {
        //                    case "TAX":
        //                        collect_date += billRow["COLLECT_DATE"].toDateString("yyyy-MM-dd") + ", ";
        //                        break;
        //                }
        //            }

        //            if (collect_date.Length > 0)
        //                collect_date = collect_date.Substring(0, collect_date.Length - 2);


        //            row["COL_DATE"] = collect_date;
        //            DORD.TORD_PRODUCT.TORD_PRODUCT_UPD6_2(UTIL.GetRowToDt(row), bizExecute);

        //        }

        //        return ORD05A_SER(paramDS, bizExecute);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
        //    }
        //}

    }
}
