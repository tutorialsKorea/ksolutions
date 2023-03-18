using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace BMNT
{
    public class MNT10A
    {

        //가동현황
        public static DataSet MNT10A_SER(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable dtRslt = DSHP.TSHP_ACTUAL_QUERY.TSHP_ACTUAL_QUERY10(paramDS.Tables["RQSTDT"], bizExecute);

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
