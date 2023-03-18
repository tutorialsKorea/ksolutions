using BizExecute;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIF
{
    public class IF_MES_BOM
    {
    }

    public class IF_MES_BOM_QUERY
    {
        public static DataTable IF_MES_BOM_QUERY1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT ");
                    sbQuery.Append(" CHILD_PART_NO ");
                    sbQuery.Append(" FROM IF_MES_BOM ");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE  1=1");
                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_CODE", " PROD_CODE = @PROD_CODE"));
                        sbWhere.Append(" AND PARENT_PART_NO IS NULL AND LEFT(CHILD_PART_NO, 1) = 'A'");

                        DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString() + sbWhere.ToString()).Copy();

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
