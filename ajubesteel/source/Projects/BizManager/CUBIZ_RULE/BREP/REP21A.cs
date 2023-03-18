using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace BREP
{
    public class REP21A
    {
        public static DataSet REP21A_SER(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable dtRsltGoal = DSTD.TSTD_REPORT_GOAL_QUERY.TSTD_REPORT_GOAL_QUERY_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);
                dtRsltGoal.TableName = "RSLTDT_GOAL";

                DataTable dtRsltNg = DSHP.TSHP_NG_QUERY.TSHP_NG_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);
                dtRsltNg.TableName = "RSLTDT_NG";

                DataTable dtRsltPNg = DQCT.TQCT_PURCHASE_NG_QUERY.TQCT_PURCHASE_NG_QUERY2(paramDS.Tables["RQSTDT"], bizExecute);
                dtRsltPNg.TableName = "RSLTDT_PNG";

                //DataTable dtRslt = DSHP.TSHP_NG_QUERY.TSHP_NG_QUERY2(paramDS.Tables["RQSTDT"], bizExecute);

                //UTIL.SetBizAddColumnToValue(dtRslt, "DATA_FLAG", 0, typeof(Byte), true);
                //if (dtRslt.Rows.Count > 0)
                //{
                //    DataTable dtWo = DSHP.TSHP_WORKORDER_QUERY.TSHP_WORKORDER_QUERY20(dtRslt, bizExecute);

                //    DataTable dt = dtRslt.AsEnumerable()
                //            .Join(dtWo.AsEnumerable()
                //                , wo => wo["ACTUAL_ID"]
                //                , rslt => rslt["ACTUAL_ID"]
                //                , (rslt, wo) => new
                //                {
                //                    PLT_CODE = rslt.Field<String?>("PLT_CODE"),
                //                    WORK_DATE = rslt["WORK_DATE"].ToString().Substring(4,2),
                //                    NG_OUT_COST = rslt.Field<Decimal?>("NG_OUT_COST"),
                //                    NG_PROC_COST = rslt.Field<Decimal?>("NG_PROC_COST"),
                //                    IN_COST = wo.Field<byte?>("IS_OS") == 0 ? rslt["QUANTITY"].toDecimal() * wo["PROC_COST"].toDecimal() : 0,
                //                    OUT_COST = wo.Field<byte?>("IS_OS") == 1 ? rslt["QUANTITY"].toDecimal() * wo["PROC_COST"].toDecimal() : 0
                //                })
                //    .GroupBy(g => new { WORK_DATE = g.WORK_DATE })
                //    .Select(r => new
                //    {
                //        PLT_CODE = r.Max(m => m.PLT_CODE),
                //        MONTH = r.Key.WORK_DATE,
                //        NG_COST = (r.Max(m => m.NG_OUT_COST).isNullOrEmpty() ? r.Sum(s => s.OUT_COST.toDecimal()) : r.Max(m => m.NG_OUT_COST.toDecimal()))
                //                        + (r.Max(m => m.NG_PROC_COST).isNullOrEmpty() ? r.Sum(s => s.IN_COST.toDecimal()) : r.Max(m => m.NG_PROC_COST.toDecimal()))
                //    }).LINQToDataTable();

                //    dt.TableName = "RSLTDT_NG";
                //    paramDS.Tables.Add(dt);
                //}
                //else
                //{
                //    dtRslt.TableName = "RSLTDT_NG";
                //    paramDS.Tables.Add(dtRslt);
                //}


                //DataTable dtRsltAs = DORD.TORD_AS_QUERY.TORD_AS_QUERY2(paramDS.Tables["RQSTDT"], bizExecute);
                //dtRsltAs.TableName = "RSLTDT_AS";

                DataTable dtRsltQct = DQCT.TQCT_COST_QUERY.TQCT_COST_QUERY2(paramDS.Tables["RQSTDT"], bizExecute);
                dtRsltQct.TableName = "RSLTDT_QCT";
                
                DataTable dtRsltShip = DORD.TORD_SHIP_QUERY.TORD_SHIP_QUERY9(paramDS.Tables["RQSTDT"], bizExecute);
                dtRsltShip.TableName = "RSLTDT_SHIP";

                paramDS.Tables.Add(dtRsltGoal);
                paramDS.Tables.Add(dtRsltNg);
                paramDS.Tables.Add(dtRsltPNg);
                //paramDS.Tables.Add(dtRsltAs);
                paramDS.Tables.Add(dtRsltQct);
                paramDS.Tables.Add(dtRsltShip);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }
    }
}
 