using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace BPUR
{
    public class PUR54A
    {
        public static DataSet PUR54A_SER(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                //DataTable dtRslt = DMAT.TMAT_REQUEST_QUERY.TMAT_REQUEST_QUERY11(paramDS.Tables["RQSTDT"], bizExecute);
                DataTable dtRslt = DMAT.TMAT_BALJU_QUERY.TMAT_BALJU_QUERY15(paramDS.Tables["RQSTDT"], bizExecute);
                dtRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

       
        public static DataSet PUR54A_SER2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable dtRslt = DOUT.TOUT_PROCBALJU_QUERY.TOUT_PROCBALJU_QUERY15(paramDS.Tables["RQSTDT"], bizExecute);

                dtRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet PUR54A_SER3(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                //DataTable dtRslt = DMAT.TMAT_REQUEST_QUERY.TMAT_REQUEST_QUERY11(paramDS.Tables["RQSTDT"], bizExecute);
                DataTable dtRslt = DMAT.TMAT_BALJU_QUERY.TMAT_BALJU_QUERY16(paramDS.Tables["RQSTDT"], bizExecute);
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
