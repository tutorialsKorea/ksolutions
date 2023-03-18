using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace DSYS
{
    public class TSYS_PRINT_LOG
    {
        public static DataTable TSYS_PRINT_LOG_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("  SELECT  ");
                    sbQuery.Append("  ID ");
                    sbQuery.Append(" ,LINK_NO ");
                    sbQuery.Append(" ,SUBJECT ");
                    sbQuery.Append(" ,BODY ");
                    sbQuery.Append(" ,FROM ");
                    sbQuery.Append(" ,TO ");
                    sbQuery.Append(" ,ATTATCH_FILE ");
                    sbQuery.Append(" ,REG_DATE ");
                    sbQuery.Append(" ,REG_EMP ");
                    sbQuery.Append(" ,DATA_FLAG ");
                    sbQuery.Append("  FROM TSYS_EMAILSEND_LOG  ");
                    sbQuery.Append("  WHERE ID = @ID  ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "ID")) isHasColumn = false;

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

        public static void TSYS_PRINT_LOG_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" INSERT INTO TSYS_PRINT_LOG (  ");
                    sbQuery.Append(" [TYPE] ");
                    sbQuery.Append(" ,[LINK_NO] ");
                    sbQuery.Append(" ,[REG_DATE] ");
                    sbQuery.Append(" ,[REG_EMP] ");
                    sbQuery.Append("  ) VALUES (  ");
                    sbQuery.Append(" @TYPE ");
                    sbQuery.Append(" ,@LINK_NO ");
                    sbQuery.Append(" ,GETDATE() ");
                    sbQuery.Append(" , " + UTIL.GetValidValue(ConnInfo.UserID));
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


    public class TSYS_PRINT_LOG_QUERY
    {

        public static DataTable TSYS_PRINT_LOG_QUERY1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT L.ID ");
                    sbQuery.Append(" 	, L.LINK_NO ");
                    sbQuery.Append(" 	, L.TYPE ");
                    sbQuery.Append(" 	, L.REG_DATE ");
                    sbQuery.Append(" 	, L.REG_EMP ");
                    sbQuery.Append(" FROM TSYS_PRINT_LOG L ");
                    sbQuery.Append(" WHERE L.LINK_NO = @LINK_NO ");
                    sbQuery.Append(" ORDER BY REG_DATE DESC ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "LINK_NO")) isHasColumn = false;

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


    }
}
