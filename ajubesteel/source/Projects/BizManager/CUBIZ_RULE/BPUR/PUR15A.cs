using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace BPUR
{
    public class PUR15A
    {
       
        public static DataSet PUR15A_SER(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));
                DataTable ypgoTable = DMAT.TMAT_YPGO_QUERY.TMAT_YPGO_QUERY4(paramDS.Tables["RQSTDT"], bizExecute);
                
                DataTable outYpgoTable = DOUT.TOUT_PROCYPGO_QUERY.TOUT_PROCYPGO_QUERY3(paramDS.Tables["RQSTDT"], bizExecute);

                ypgoTable.Merge(outYpgoTable);

                ypgoTable.Columns.Add("SEL");
                ypgoTable.TableName = "RSLTDT";
                
                paramDS.Tables.Add(ypgoTable);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }
    }
}
