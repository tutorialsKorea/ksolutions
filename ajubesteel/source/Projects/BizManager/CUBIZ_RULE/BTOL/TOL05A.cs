using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using BizExecute;

namespace BTOL
{
    public class TOL05A
    {
        /// <summary>
        /// 공구 지급 내역
        /// </summary>
        /// <param name="paramDS"></param>
        /// <returns></returns>
        public static DataSet TOL05A_SER(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

                DataTable dtRslt_M = DSTD.TSTD_TOOL_QUERY.TSTD_TOOL_QUERY5(paramDS.Tables["RQSTDT"],  bizExecute);
                dtRslt_M.TableName = "RSLTDT_M";

                DataTable dtRslt_Gvie = DTOL.TTOL_GIVE_QUERY.TTOL_GIVE_QUERY2(paramDS.Tables["RQSTDT"], bizExecute);
                dtRslt_Gvie.TableName = "RSLTDT_GIVE";

                DataTable dtRslt_Return = DTOL.TTOL_RETURN_QUERY.TTOL_RETURN_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);
                dtRslt_Return.TableName = "RSLTDT_RETURN";

                DataTable dtRslt_Disuse = DTOL.TTOL_DISUSE_QUERY.TTOL_DISUSE_QUERY2(paramDS.Tables["RQSTDT"], bizExecute);
                dtRslt_Disuse.TableName = "RSLTDT_DISUSE";

                paramDS.Tables.Add(dtRslt_M);
                paramDS.Tables.Add(dtRslt_Gvie);
                paramDS.Tables.Add(dtRslt_Return);
                paramDS.Tables.Add(dtRslt_Disuse);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }


        /// <summary>
        /// 공구 반납 내역
        /// </summary>
        /// <param name="paramDS"></param>
        /// <returns></returns>
        public static DataSet TOL05A_SER2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable dtRslt =  DTOL.TTOL_GIVE_QUERY.TTOL_GIVE_QUERY1(paramDS.Tables["RQSTDT"],  bizExecute);
                dtRslt.Columns.Add("SEL", typeof(string));
               
                dtRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        /// <summary>
        /// 지급 폐기 내역
        /// </summary>
        /// <param name="paramDS"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataSet TOL05A_SER3(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable dtRslt = DTOL.TTOL_DISUSE_QUERY.TTOL_DISUSE_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);
                dtRslt.Columns.Add("SEL", typeof(string));

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
