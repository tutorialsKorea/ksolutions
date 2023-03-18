using BizExecute;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BREP
{
    public class REP22A
    {
        public static DataSet REP22A_SER(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable dtProdTalbe = DORD.TORD_PRODUCT_QUERY.TORD_PRODUCT_QUERY29(paramDS.Tables["RQSTDT"], bizExecute);
                DataTable dtRsltProc = DCOST.DCOST.DCOST_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);
                DataTable dtRsltMat = DCOST.DCOST.DCOST_QUERY2(paramDS.Tables["RQSTDT"], bizExecute);
                DataTable dtRsltPo = DCOST.DCOST.DCOST_QUERY3(paramDS.Tables["RQSTDT"], bizExecute);
                dtRsltProc.TableName = "RSLTDT_PROC";
                dtRsltMat.TableName = "RSLTDT_MAT";
                dtRsltPo.TableName = "RSLTDT_PO";

                dtRsltProc.Columns.Add("PROD_QTY", typeof(int)); //수량
                dtRsltProc.Columns.Add("PROD_COST", typeof(Decimal)); // 원가
                dtRsltProc.Columns.Add("PROD_EX_COST", typeof(Decimal)); //제조경비
                dtRsltProc.Columns.Add("PROD_AMT", typeof(Decimal)); // 합계
                dtRsltProc.Columns.Add("PROD_CIRCLE", typeof(Decimal)); // 원판(재료비)
                dtRsltProc.Columns.Add("PROD_PROC", typeof(Decimal)); // 가공비
                dtRsltProc.Columns.Add("PROD_PO_MAT", typeof(Decimal)); // 구매비

                DataTable dt = dtRsltProc.AsEnumerable()
                    .GroupBy(g => new
                    {
                        PROD_CODE = g.Field<string>("PROD_CODE")
                        ,PROD_NAME = g.Field<string>("PROD_NAME")
                        ,BUSINESS_EMP = g.Field<string>("BUSINESS_EMP")
                        ,BUSINESS_EMP_NAME = g.Field<string>("BUSINESS_EMP_NAME")

                        ,CVND_CODE = g.Field<string>("CVND_CODE")
                        ,CVND_NAME = g.Field<string>("CVND_NAME")

                        ,
                        ITEM_FLAG = g.Field<string>("ITEM_FLAG")
                        ,
                        PROD_FLAG = g.Field<string>("PROD_FLAG")
                        ,
                        PROD_TYPE = g.Field<string>("PROD_TYPE")

                    })
                    .Select(r =>
                    {
                        var row = dtRsltProc.NewRow();
                        row["PROD_CODE"] = r.Key.PROD_CODE;
                        row["PROD_NAME"] = r.Key.PROD_NAME;
                        row["BUSINESS_EMP"] = r.Key.BUSINESS_EMP;
                        row["BUSINESS_EMP_NAME"] = r.Key.BUSINESS_EMP_NAME;
                        row["CVND_CODE"] = r.Key.CVND_CODE;
                        row["CVND_NAME"] = r.Key.CVND_NAME;
                        row["ITEM_FLAG"] = r.Key.ITEM_FLAG;
                        row["PROD_FLAG"] = r.Key.PROD_FLAG;
                        row["PROD_TYPE"] = r.Key.PROD_TYPE;
                        row["PROD_CIRCLE"] = r.Sum(x => x.Field<decimal>("CIRCLE_COST"));
                        row["PROD_PROC"] = r.Sum(x => x.Field<decimal>("DES_COST")) + r.Sum(x => x.Field<decimal>("MILL_COST")) + r.Sum(x => x.Field<decimal>("CAM_COST")) + r.Sum(x => x.Field<decimal>("MCT_COST"))
                                            + r.Sum(x => x.Field<decimal>("SIDE_COST")) + r.Sum(x => x.Field<decimal>("ASSY_COST")) + r.Sum(x => x.Field<decimal>("SHIP_COST")) + r.Sum(x => x.Field<decimal>("INS_COST"));
                        return row;
                    }).CopyToDataTable();


                
                

                foreach (DataRow row in dt.Rows)
                {
                    DataRow[] matRows = dtRsltMat.Select("PROD_CODE = '" + row["PROD_CODE"].ToString() + "'");
                    DataRow[] poRows = dtRsltPo.Select("PROD_CODE = '" + row["PROD_CODE"].ToString() + "'");
                    DataRow[] prodRows = dtProdTalbe.Select("PROD_CODE = '" + row["PROD_CODE"].ToString() + "'");

                    if (prodRows.Length > 0)
                    {
                        row["PLT_CODE"] = prodRows[0]["PLT_CODE"];
                        row["PROD_QTY"] = prodRows[0]["PROD_QTY"];
                    }

                    decimal mat_amt = 0;
                    decimal po_amt = 0;

                    if (matRows.Length > 0)
                    {
                        mat_amt = matRows.CopyToDataTable().Compute("SUM(OUT_AMT)", "").toDecimal();
                    }

                    if (poRows.Length > 0)
                    {
                        po_amt = poRows.CopyToDataTable().Compute("SUM(AMT)", "").toDecimal();
                    }

                    row["PROD_PO_MAT"] = mat_amt + po_amt;

                    row["PROD_AMT"] = row["PROD_PO_MAT"].toDecimal() + row["PROD_CIRCLE"].toDecimal() + row["PROD_PROC"].toDecimal();

                    Decimal prodQTY = row["PROD_QTY"].toDecimal() == 0 ? 1 : row["PROD_QTY"].toDecimal();

                    row["PROD_EX_COST"] = row["PROD_PO_MAT"].toDecimal() + row["PROD_CIRCLE"].toDecimal() + row["PROD_PROC"].toDecimal() / prodQTY;
                    row["PROD_COST"] = row["PROD_PO_MAT"].toDecimal() + row["PROD_CIRCLE"].toDecimal() + row["PROD_PROC"].toDecimal() / prodQTY;
                }

                dt.TableName = "RSLTDT";
                paramDS.Tables.Add(dtRsltProc);
                paramDS.Tables.Add(dtRsltMat);
                paramDS.Tables.Add(dtRsltPo);
                paramDS.Tables.Add(dt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }


        public static DataSet REP22A_SER2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    DataTable dt1 = DSTD.TSTD_PART_RATE.TSTD_PART_RATE_SER(UTIL.GetRowToDt(row), bizExecute);
                    DataTable dt2 = DSTD.TSTD_COST_TYPE.TSTD_COST_TYPE_SER2(UTIL.GetRowToDt(row), bizExecute);
                    DataTable dt3 = DSTD.TSTD_COST_EXCHANGE.TSTD_COST_EXCHANGE_SER2(UTIL.GetRowToDt(row), bizExecute);
                    DataTable dt4 = DLSE.LSE_STD_PART_QUERY.LSE_STD_PART_QUERY19(UTIL.GetRowToDt(row), bizExecute);

                    dt1.TableName = "RSLTDT";
                    dt2.TableName = "RSLTDT2";
                    dt3.TableName = "RSLTDT3";
                    dt4.TableName = "RSLTDT4";
                    paramDS.Tables.Add(dt1);
                    paramDS.Tables.Add(dt2);
                    paramDS.Tables.Add(dt3);
                    paramDS.Tables.Add(dt4);
                }

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet REP22A_SER3(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    
                    DataTable dt3 = DSTD.TSTD_COST_EXCHANGE.TSTD_COST_EXCHANGE_SER2(UTIL.GetRowToDt(row), bizExecute);

                    dt3.TableName = "RSLTDT";
                    paramDS.Tables.Add(dt3);
                }

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet REP22A_INS(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                foreach (DataRow row in paramDS.Tables["RQSTDT_PART_RATE"].Rows)
                {
                    DSTD.TSTD_PART_RATE.TSTD_PART_RATE_UPD(UTIL.GetRowToDt(row), bizExecute);
                }

                foreach (DataRow row in paramDS.Tables["RQSTDT_COST_TYPE"].Rows)
                {
                    DSTD.TSTD_COST_TYPE.TSTD_COST_TYPE_UPD(UTIL.GetRowToDt(row), bizExecute);
                }

                foreach (DataRow row in paramDS.Tables["RQSTDT_EXCHANGE"].Rows)
                {
                    DataTable dt = DSTD.TSTD_COST_EXCHANGE.TSTD_COST_EXCHANGE_SER(UTIL.GetRowToDt(row), bizExecute);

                    if (dt.Rows.Count == 0)
                    {
                        DSTD.TSTD_COST_EXCHANGE.TSTD_COST_EXCHANGE_INS(UTIL.GetRowToDt(row), bizExecute);
                    }
                    else
                    {
                        DSTD.TSTD_COST_EXCHANGE.TSTD_COST_EXCHANGE_UPD(UTIL.GetRowToDt(row), bizExecute);
                    }
                }

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }


        public static DataSet REP22A_INS2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    DLSE.LSE_STD_PART.LSE_STD_PART_UPD20(UTIL.GetRowToDt(row), bizExecute);
                }

                DataTable dt = DLSE.LSE_STD_PART_QUERY.LSE_STD_PART_QUERY19(paramDS.Tables["RQSTDT"], bizExecute);

                paramDS.Tables.Add(dt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }
    }
}
