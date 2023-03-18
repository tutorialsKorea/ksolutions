using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace COMMON
{
    public class COMMON
    {
        /// <summary>
        /// 특정일 임률 수정
        /// </summary>
        /// <param name="paramDS"></param>
        /// <returns></returns>
        public static DataSet COMMON_PROC(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(byte));

                DataTable dtRslt = DLSE.LSE_STD_PROC_QUERY.LSE_STD_PROC_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);
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
        /// 특정일 임률 수정
        /// </summary>
        /// <param name="paramDS"></param>
        /// <returns></returns>
        public static DataSet COMMON_GET_SERIAL(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(byte));
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "SR_NO", "", typeof(string));
                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    row["SR_NO"] = UTIL.UTILITY_GET_SERIALNO(row["PLT_CODE"].ToString(), row["SR_CODE"].ToString(), bizExecute);                
                }

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }





    }

}
