using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace DSYS
{
    public class TSYS_EXECUTE_LOG
    {
        public static DataTable TSYS_EXECUTE_LOG_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("  SELECT  ");
                    sbQuery.Append("  UID ");
                    sbQuery.Append(" ,logDt ");
                    sbQuery.Append(" ,useSe ");
                    sbQuery.Append(" ,sysUser ");
                    sbQuery.Append(" ,conectIp ");
                    sbQuery.Append(" ,dataUsgqty ");
                    sbQuery.Append(" ,sendFlag ");
                    sbQuery.Append("  FROM TSYS_EXECUTE_LOG  ");
                    sbQuery.Append("  WHERE UID = @UID  ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "UID")) isHasColumn = false;

                        if (isHasColumn == true)
                        {
                            DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString(), row).Copy();

                            sourceTable.TableName = "RSLTDT";
                            dsResult.Merge(sourceTable);
                        }
                    }
                }
                return UTIL.GetDsToDt(dsResult);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }



        public static void TSYS_EXECUTE_LOG_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" INSERT INTO TSYS_EXECUTE_LOG (  ");
                    sbQuery.Append(" logDt ");
                    sbQuery.Append(" ,useSe ");
                    sbQuery.Append(" ,sysUser ");
                    sbQuery.Append(" ,conectIp ");
                    sbQuery.Append(" ,dataUsgqty ");
                    sbQuery.Append(" ,ruleName ");
                    sbQuery.Append(" ,sendFlag ");
                    sbQuery.Append("  ) VALUES (  ");
                    sbQuery.Append(" GETDATE() ");
                    sbQuery.Append(" ,@useSe ");
                    sbQuery.Append(" ,'"+ ConnInfo.UserID + "'");
                    sbQuery.Append(" ,'" + ConnInfo.ClientIP + "'");
                    sbQuery.Append(" ,@dataUsgqty ");
                    sbQuery.Append(" ,@ruleName ");
                    sbQuery.Append(" ,'0' ");
                    sbQuery.Append("  ) ");

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

    public class TSYS_EXECUTE_LOG_QUERY
    {
        
        
    }
}
