using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace BPUR
{
    public class PUR59A
    {
        public static DataSet PUR59A_SER(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable dtRslt = new DataTable("RSLTDT");

                if (paramDS.Tables["RQSTDT"].Rows.Count > 0)
                {
                    dtRslt = DSTD.TSTD_STOCK_GRP.TSTD_STOCK_GRP_SER(paramDS.Tables["RQSTDT"], bizExecute);
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

        public static DataSet PUR59A_SER2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable dtRslt = DSHP.TSHP_STOCK_LOG_QUERY.TSHP_STOCK_LOG_QUERY5(paramDS.Tables["RQSTDT"], bizExecute);
                dtRslt.TableName = "RSLTDT";

                DataTable dtRsltBal = DMAT.TMAT_BALJU_QUERY.TMAT_BALJU_QUERY17(paramDS.Tables["RQSTDT"], bizExecute);
                dtRsltBal.TableName = "RSLTDT_BAL";

                DataTable dtRsltOutBal = DOUT.TOUT_PROCBALJU_QUERY.TOUT_PROCBALJU_QUERY19(paramDS.Tables["RQSTDT"], bizExecute);
                dtRsltOutBal.TableName = "RSLTDT_OUTBAL";

                dtRsltBal.Merge(dtRsltOutBal);

                DataTable dtRslt_Stock = new DataTable("RSLTDT_STOCK");
                if (paramDS.Tables["RQSTDT"].Rows.Count > 0)
                {
                    if (paramDS.Tables["RQSTDT"].Rows[0]["STK_GROUP"].ToString() == "")
                    {
                        dtRslt_Stock = DLSE.LSE_STD_PART_QUERY.LSE_STD_PART_QUERY4(paramDS.Tables["RQSTDT"], bizExecute);
                        dtRslt_Stock.Columns.Add("USE_QTY", typeof(int));
                        dtRslt_Stock.Columns.Add("STK_", typeof(int));
                        dtRslt_Stock.Columns.Add("STK_SCOMMENT", typeof(string));
                    }
                    else
                        dtRslt_Stock = DSTD.TSTD_STOCK_GRP.TSTD_STOCK_GRP_SER1(paramDS.Tables["RQSTDT"], bizExecute);
                }
                dtRslt_Stock.TableName = "RSLTDT_STOCK";


                paramDS.Tables.Add(dtRslt);
                paramDS.Tables.Add(dtRsltBal);
                paramDS.Tables.Add(dtRslt_Stock);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }
    }
}
