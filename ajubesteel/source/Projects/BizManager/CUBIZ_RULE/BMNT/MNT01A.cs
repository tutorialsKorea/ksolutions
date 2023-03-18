using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace BMNT
{

    public class MNT01A
    {
        public static DataSet MNT01A_SER(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(byte));

                DataTable workRslt = DSHP.TSHP_ACTUAL_QUERY.TSHP_ACTUAL_QUERY31(paramDS.Tables["RQSTDT"], bizExecute);
                workRslt.TableName = "RSLTDT_WORK";
                paramDS.Tables.Add(workRslt);

                DataTable stopRslt = DSHP.TSHP_ACTUAL_QUERY.TSHP_ACTUAL_QUERY32(paramDS.Tables["RQSTDT"], bizExecute);
                stopRslt.TableName = "RSLTDT_STOP";
                paramDS.Tables.Add(stopRslt);

                DataTable idleRslt = DSHP.TSHP_IDLETIME_QUERY.TSHP_IDLETIME_QUERY8(paramDS.Tables["RQSTDT"], bizExecute);
                idleRslt.TableName = "RSLTDT_IDLE";
                paramDS.Tables.Add(idleRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        

    }
}
