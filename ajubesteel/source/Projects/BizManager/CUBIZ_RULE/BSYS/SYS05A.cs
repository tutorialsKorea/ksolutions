using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using BizExecute;

namespace BSYS
{
    public class SYS05A
    {
        public static DataSet SYS05A_SER(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable dtRslt = DSYS.TSYS_LOGIN_LOG_QUERY.TSYS_LOGIN_LOG_QUERY2(paramDS.Tables["RQSTDT"], bizExecute);

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


        public static DataSet SYS05A_INS(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {

            try
            {
                if (paramDS.Tables["RQSTDT"].Rows.Count != 0)
                {

                    DataTable dtNow = UTIL.UTILITY_GET_DTNOW(bizExecute);
                    //string dt = ((DateTime)dtNow.Rows[0]["NOW_DT"]).ToString("yyyy-MM-dd HH:mm:ss");
                    DateTime dt = ((DateTime)dtNow.Rows[0]["NOW_DT"]);
                    UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "CLASS_OPEN_TIME", dt, typeof(DateTime));

                    
                    DSYS.TSYS_LOGIN_LOG.TSYS_LOGIN_LOG_INS1(paramDS.Tables["RQSTDT"], bizExecute);

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
