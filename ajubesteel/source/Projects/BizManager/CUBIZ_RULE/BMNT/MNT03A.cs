using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace BMNT
{
    public class MNT03A
    {
        public static DataSet MNT03A_SER(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable dtRslt = DPOP.TPOP_MC_ACTUAL_QUERY.TPOP_MC_ACTUAL_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);
                DataTable dtRslt2 = DPOP.TPOP_MC_ACTUAL_QUERY.TPOP_MC_ACTUAL_QUERY2(paramDS.Tables["RQSTDT"], bizExecute);

                dtRslt.TableName = "RSLTDT";
                dtRslt2.TableName = "RSLTDT2";

                paramDS.Tables.Add(dtRslt);
                paramDS.Tables.Add(dtRslt2);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }
    }
}
