using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace BPUR
{
    public class PUR58B
    {
        public static DataSet PUR58B_SER(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable dtRslt = new DataTable("RSLTDT");

                if (paramDS.Tables["RQSTDT"].Rows.Count > 0)
                {
                    dtRslt = DSTD.TSTD_STOCK_GRP.TSTD_STOCK_GRP_SER3(paramDS.Tables["RQSTDT"], bizExecute);

                }

                dtRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }

        public static DataSet PUR58B_SER2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                //단품, 구매품만
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "MAT_TYPE", "단품,구매품", typeof(String));


                DataTable dtRslt = new DataTable("RSLTDT");
                if (paramDS.Tables["RQSTDT"].Rows.Count > 0)
                {
                    if (paramDS.Tables["RQSTDT"].Rows[0]["STK_GROUP"].ToString() == "")
                    {
                        dtRslt = DLSE.LSE_STD_PART_QUERY.LSE_STD_PART_QUERY4(paramDS.Tables["RQSTDT"], bizExecute);
                        dtRslt.Columns.Add("USE_QTY", typeof(int));
                        dtRslt.Columns.Add("STK_", typeof(int));
                        dtRslt.Columns.Add("STK_SCOMMENT", typeof(string));
                    }
                    else
                        dtRslt = DSTD.TSTD_STOCK_GRP.TSTD_STOCK_GRP_SER1(paramDS.Tables["RQSTDT"], bizExecute);
                }
                dtRslt.TableName = "RSLTDT";


                //생산완료 제품 현황
                DataTable dtRsltStockLog1 = DSHP.TSHP_STOCK_LOG_QUERY.TSHP_STOCK_LOG_QUERY6(paramDS.Tables["RQSTDT"], bizExecute);
                dtRsltStockLog1.TableName = "RSLTDT_COMPLETE";

                //출하현황
                DataTable dtRsltShip = DORD.TORD_SHIP_QUERY.TORD_SHIP_QUERY13(paramDS.Tables["RQSTDT"], bizExecute);
                dtRsltShip.TableName = "RSLTDT_SHIP";

                ////재고현황
                //DataTable dtRsltStockLog2 = DSHP.TSHP_STOCK_LOG_QUERY.TSHP_STOCK_LOG_QUERY2(paramDS.Tables["RQSTDT"], bizExecute);
                //dtRsltStockLog2.TableName = "RSLTDT_STOCK_LOG";

                paramDS.Tables.Add(dtRsltStockLog1);
                paramDS.Tables.Add(dtRsltShip);
                //paramDS.Tables.Add(dtRsltStockLog2);
                paramDS.Tables.Add(dtRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }

        public static DataSet PUR58B_SER3(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable dtRslt = DSHP.TSHP_STOCK_LOG_QUERY.TSHP_STOCK_LOG_QUERY2(paramDS.Tables["RQSTDT"], bizExecute);
                dtRslt.TableName = "RSLTDT";
                
                paramDS.Tables.Add(dtRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }
    }
}
