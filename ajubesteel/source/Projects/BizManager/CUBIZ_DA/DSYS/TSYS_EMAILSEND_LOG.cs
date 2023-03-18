using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace DSYS
{
    public class TSYS_EMAILSEND_LOG
    {
        public static DataTable TSYS_EMAILSEND_LOG_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
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

        public static void TSYS_EMAILSEND_LOG_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" INSERT INTO TSYS_EMAILSEND_LOG (  ");
                    sbQuery.Append(" [LINK_NO] ");
                    sbQuery.Append(" ,[SUBJECT] ");
                    sbQuery.Append(" ,[BODY] ");
                    sbQuery.Append(" ,[FROM] ");
                    sbQuery.Append(" ,[TO] ");
                    sbQuery.Append(" ,CC ");
                    sbQuery.Append(" ,[ATTATCH_FILE] ");
                    sbQuery.Append(" ,REG_DATE ");
                    sbQuery.Append(" ,REG_EMP ");
                    sbQuery.Append(" ,DATA_FLAG ");
                    sbQuery.Append(" ,RESULT ");
                    sbQuery.Append("  ) VALUES (  ");
                    sbQuery.Append(" @LINK_NO ");
                    sbQuery.Append(" ,@SUBJECT ");
                    sbQuery.Append(" ,SUBSTRING(@BODY,1,2000) ");
                    sbQuery.Append(" ,@FROM ");
                    sbQuery.Append(" ,@TO ");
                    sbQuery.Append(" ,@CC ");
                    sbQuery.Append(" ,@ATTATCH_FILE ");
                    sbQuery.Append(" ,GETDATE() ");
                    sbQuery.Append(" , " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" ,0 ");
                    sbQuery.Append(" ,@RESULT ");
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


    public class TSYS_EMAILSEND_LOG_QUERY
    {

        public static DataTable TSYS_EMAILSEND_LOG_QUERY1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT L.ID ");
                    sbQuery.Append(" 	, L.LINK_NO ");
                    sbQuery.Append(" 	, L.[SUBJECT] ");
                    sbQuery.Append(" 	, L.BODY ");
                    sbQuery.Append(" 	, L.[FROM] ");
                    sbQuery.Append(" 	, L.[TO] ");
                    sbQuery.Append(" 	, L.CC ");
                    sbQuery.Append(" 	, L.ATTATCH_FILE ");
                    sbQuery.Append(" 	, L.REG_DATE ");
                    sbQuery.Append(" 	, L.REG_EMP ");
                    sbQuery.Append(" 	, L.RESULT ");
                    sbQuery.Append(" FROM TSYS_EMAILSEND_LOG L ");
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
