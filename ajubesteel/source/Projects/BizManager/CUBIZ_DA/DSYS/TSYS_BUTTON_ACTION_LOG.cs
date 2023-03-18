using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace DSYS
{
    public class TSYS_BUTTON_ACTION_LOG
    {
        public static void TSYS_BUTTON_ACTION_LOG_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("INSERT INTO TSYS_BUTTON_ACTION_LOG");
                    sbQuery.Append("(");
                    sbQuery.Append("  PLT_CODE");
                    sbQuery.Append("  , CLASS_NAME");
                    sbQuery.Append("  , BTN_CAPTION");
                    sbQuery.Append("  , BTN_NAME");
                    sbQuery.Append("  , VERSION");
                    sbQuery.Append("  , REG_DATE");
                    sbQuery.Append("  , REG_EMP");
                    sbQuery.Append(")");
                    sbQuery.Append("VALUES");
                    sbQuery.Append("(");
                    sbQuery.Append("  @PLT_CODE");
                    sbQuery.Append("  , @CLASS_NAME");
                    sbQuery.Append("  , @BTN_CAPTION");
                    sbQuery.Append("  , @BTN_NAME");
                    sbQuery.Append("  , @VERSION");
                    sbQuery.Append("  , GETDATE()");
                    sbQuery.Append(" , " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(")");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bizExecute.executeInsertQuery(sbQuery.ToString(), row);
                    }
                }
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }
    }


    public class TSYS_BUTTON_ACTION_LOG_QUERY
    {
        

    }
}
