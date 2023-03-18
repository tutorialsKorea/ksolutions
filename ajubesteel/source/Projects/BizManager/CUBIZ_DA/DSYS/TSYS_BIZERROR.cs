using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace DSYS
{
    public class TSYS_BIZERROR
    {
    }

    public class TSYS_BIZERROR_QUERY
    {
        public static DataTable TSYS_BIZERROR_QUERY1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {

                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT PLT_CODE ");
                    sbQuery.Append("       ,NUMBER ");
                    sbQuery.Append("       ,LANG ");
                    sbQuery.Append("       ,DESCRIPTION ");
                    sbQuery.Append("   FROM TSYS_BIZERROR ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder();

                        sbWhere.Append(" WHERE PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                        sbWhere.Append(UTIL.GetWhere(row, "@NUMBERE", "NUMBER = @NUMBERE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@LANG", "LANG = @LANG"));
                        sbWhere.Append(UTIL.GetWhere(row, "@DESCRIPTION_LIKE", "DESCRIPTION LIKE '%' + @DESCRIPTION_LIKE +  '%'"));

                        DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString() + sbWhere.ToString(), row).Copy();

                        sourceTable.TableName = "RSLTDT";
                        dsResult.Merge(sourceTable);  
                    }
                }


                return UTIL.GetDsToDt(dsResult);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }
        
    }
}
