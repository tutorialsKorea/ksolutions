using BizExecute;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMNT
{
    public class MNT02A
    {
        public static DataSet MNT02A_SER(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                //UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(byte));

                DataTable workRslt = DPOP.TPOP_MC_STATUS_QUERY.TPOP_MC_STATUS_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);
                workRslt.Columns.Add("PROD_CODE", typeof(string));
                workRslt.Columns.Add("PART_CODE", typeof(string));
                workRslt.Columns.Add("PART_NAME", typeof(string));
                workRslt.TableName = "RSLTDT";

                DataTable prodRslt = DPOP.TPOP_MC_STATUS_QUERY.TPOP_MC_STATUS_QUERY2(paramDS.Tables["RQSTDT"], bizExecute);
                prodRslt.TableName = "RSLTDT_PROD";

                paramDS.Tables.Add(workRslt);
                paramDS.Tables.Add(prodRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }
    }
}
