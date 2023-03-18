using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace BREP
{
    public class REP19A
    {
        //월별 공정 품질 비용 현황
        public static DataSet REP19A_SER(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable dtRsltGoal = DSTD.TSTD_REPORT_GOAL_QUERY.TSTD_REPORT_GOAL_QUERY_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);
                dtRsltGoal.TableName = "RSLTDT_GOAL";

                DataTable dtRsltQct = DQCT.TQCT_COST_QUERY.TQCT_COST_QUERY2(paramDS.Tables["RQSTDT"], bizExecute);
                dtRsltQct.TableName = "RSLTDT_QCT";

                DataTable dtRsltNg = DSHP.TSHP_NG_QUERY.TSHP_NG_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);
                dtRsltNg.TableName = "RSLTDT_NG";

                DataTable dtRsltPNg = DQCT.TQCT_PURCHASE_NG_QUERY.TQCT_PURCHASE_NG_QUERY2(paramDS.Tables["RQSTDT"], bizExecute);
                dtRsltPNg.TableName = "RSLTDT_PNG";

                //DataTable dtRsltAs = DORD.TORD_AS_QUERY.TORD_AS_QUERY2(paramDS.Tables["RQSTDT"], bizExecute);
                //dtRsltAs.TableName = "RSLTDT_AS";

                paramDS.Tables.Add(dtRsltQct);
                paramDS.Tables.Add(dtRsltNg);
                paramDS.Tables.Add(dtRsltPNg);
                //paramDS.Tables.Add(dtRsltAs);
                paramDS.Tables.Add(dtRsltGoal);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }
    }
}
 