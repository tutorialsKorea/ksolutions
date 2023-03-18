using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace BMAT
{
    public class MAT01A
    {
        public static DataSet MAT01A_SER(DataSet paramDS, BizExecute.BizExecute bizExe)
        {
            try
            {
                DataTable dtRslt = DMAT.TMAT_STOCK_QUERY.TMAT_STOCK_QUERY1(paramDS.Tables["RQSTDT"], bizExe);

                dtRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRslt);


                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }


        public static void MAT01A_UPD1(DataSet paramDS, BizExecute.BizExecute bizExe)
        {
            try
            {
                //foreach (DataRow dr in paramDS.Tables["RQSTDT"].Rows)
                //{
                //    DMAT.TMAT_STOCK.TMAT_STOCK_UPD12(UTIL.GetRowToDt(dr), bizExe);

                //}
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }


    }
}
