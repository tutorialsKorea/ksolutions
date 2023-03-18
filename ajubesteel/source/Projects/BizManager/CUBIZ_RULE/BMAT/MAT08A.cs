using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace BMAT
{
    public class MAT08A
    {
        /// <summary>
        /// 현재고 조회
        /// </summary>
        /// <param name="paramDS"></param>
        /// <param name="bizExe"></param>
        /// <returns></returns>
        public static DataSet MAT08A_SER(DataSet paramDS, BizExecute.BizExecute bizExe)
        {
            try
            {
                DataTable dtRslt = DSHP.TSHP_STOCK_SNAPSHOT_QUERY.TSHP_STOCK_SNAPSHOT_QUERY1(paramDS.Tables["RQSTDT"], bizExe);

                dtRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }


        public static DataSet MAT08A_SER2(DataSet paramDS, BizExecute.BizExecute bizExe)
        {
            try
            {
                DataTable dtRslt = DMAT.TMAT_STOCK_LOG_QUERY.TMAT_STOCK_LOG_QUERY3(paramDS.Tables["RQSTDT"], bizExe);

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
