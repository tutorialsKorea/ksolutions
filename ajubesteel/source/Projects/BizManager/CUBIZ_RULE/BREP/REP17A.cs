using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace BREP
{
    public class REP17A
    {
        //월별 공정 품질 비용 현황
        public static DataSet REP17A_SER(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable dtRsltGoal = DSTD.TSTD_REPORT_GOAL_QUERY.TSTD_REPORT_GOAL_QUERY_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);
                dtRsltGoal.TableName = "RSLTDT_GOAL";

                DataTable dtRslt = DSHP.TSHP_DAILYWORK_QUERY.TSHP_DAILYWORK_QUERY11(paramDS.Tables["RQSTDT"], bizExecute);
                dtRslt.TableName = "RSLTDT";

                DataTable dtRslt_1Y_Ago = DSHP.TSHP_DAILYWORK_QUERY.TSHP_DAILYWORK_QUERY12(paramDS.Tables["RQSTDT"], bizExecute);
                dtRslt_1Y_Ago.TableName = "RSLTDT_1Y_AGO";

                paramDS.Tables.Add(dtRslt);
                paramDS.Tables.Add(dtRsltGoal);
                paramDS.Tables.Add(dtRslt_1Y_Ago);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }
    }
}
 