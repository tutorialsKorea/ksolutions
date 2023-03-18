using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace BREP
{
    public class REP18A
    {
        //월별 공정 품질 비용 현황
        public static DataSet REP18A_SER(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable dtRsltGoal = DSTD.TSTD_REPORT_GOAL_QUERY.TSTD_REPORT_GOAL_QUERY_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);
                dtRsltGoal.TableName = "RSLTDT_GOAL";

                DataTable dtRsltShip = DORD.TORD_SHIP_QUERY.TORD_SHIP_QUERY11(paramDS.Tables["RQSTDT"], bizExecute);
                dtRsltShip.TableName = "RSLTDT_SHIP";

                DataTable dtRsltShip_1yearsAgo = DORD.TORD_SHIP_QUERY.TORD_SHIP_QUERY12(paramDS.Tables["RQSTDT"], bizExecute);
                dtRsltShip_1yearsAgo.TableName = "RSLTDT_SHIP_1Y_AGO";

                //DataTable dtRsltAs = DORD.TORD_AS_QUERY.TORD_AS_QUERY3(paramDS.Tables["RQSTDT"], bizExecute);
                //dtRsltAs.TableName = "RSLTDT_AS";

                DataTable dtRsltNg = DSHP.TSHP_DAILYWORK_QUERY.TSHP_DAILYWORK_QUERY11(paramDS.Tables["RQSTDT"], bizExecute);
                dtRsltNg.TableName = "RSLTDT_NG";

                DataTable dtRsltNg_1yearsAgo = DSHP.TSHP_DAILYWORK_QUERY.TSHP_DAILYWORK_QUERY12(paramDS.Tables["RQSTDT"], bizExecute);
                dtRsltNg_1yearsAgo.TableName = "RSLTDT_NG_1Y_AGO";

                paramDS.Tables.Add(dtRsltGoal);
                paramDS.Tables.Add(dtRsltShip);
                //paramDS.Tables.Add(dtRsltAs);
                paramDS.Tables.Add(dtRsltNg);

                paramDS.Tables.Add(dtRsltShip_1yearsAgo);
                paramDS.Tables.Add(dtRsltNg_1yearsAgo);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }
    }
}
 