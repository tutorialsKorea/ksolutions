using BizExecute;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSYS
{
    public class TSYS_DAILY_LOG_PLAN
    {
        public static DataTable TSYS_DAILY_LOG_PLAN_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("  SELECT  ");
                    sbQuery.Append("  PLT_CODE ");
                    sbQuery.Append(" ,DLOG_ID ");
                    sbQuery.Append(" ,DLOG_CAT ");
                    sbQuery.Append(" ,DLOG_TYPE ");
                    sbQuery.Append(" ,DLOG_PERIOD ");
                    sbQuery.Append(" ,DLOG_PLAN ");
                    sbQuery.Append(" ,WORK_DATE ");
                    sbQuery.Append(" ,VEN_CODE ");
                    sbQuery.Append(" ,RELATED_EMP ");
                    sbQuery.Append(" ,RELATED_PROD ");
                    sbQuery.Append(" ,CONTENTS ");
                    sbQuery.Append(" ,DLOG_TIME ");
                    sbQuery.Append(" ,SCOMMENT ");
                    sbQuery.Append(" ,APPLY_START_DATE "); 
                    sbQuery.Append(" ,APPLY_END_DATE "); 
                    sbQuery.Append(" ,APPLY_FLAG ");  
                    sbQuery.Append(" ,REG_DATE ");
                    sbQuery.Append(" ,REG_EMP ");
                    sbQuery.Append(" ,MDFY_DATE ");
                    sbQuery.Append(" ,MDFY_EMP ");
                    sbQuery.Append(" ,DEL_DATE ");
                    sbQuery.Append(" ,DEL_EMP ");
                    sbQuery.Append(" ,DATA_FLAG ");
                    sbQuery.Append("  FROM TSYS_DAILY_LOG_PLAN  ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("  AND DLOG_ID = @DLOG_ID  ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "DLOG_ID")) isHasColumn = false;

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

        public static void TSYS_DAILY_LOG_PLAN_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" INSERT INTO TSYS_DAILY_LOG_PLAN (  ");
                    sbQuery.Append("  PLT_CODE ");
                    sbQuery.Append(" ,DLOG_ID ");
                    sbQuery.Append(" ,DLOG_CAT ");
                    sbQuery.Append(" ,DLOG_TYPE ");
                    sbQuery.Append(" ,DLOG_PERIOD ");
                    sbQuery.Append(" ,DLOG_PLAN ");
                    sbQuery.Append(" ,WORK_DATE ");
                    sbQuery.Append(" ,VEN_CODE ");
                    sbQuery.Append(" ,RELATED_EMP ");
                    sbQuery.Append(" ,RELATED_PROD ");
                    sbQuery.Append(" ,CONTENTS ");
                    sbQuery.Append(" ,DLOG_TIME ");
                    sbQuery.Append(" ,SCOMMENT ");
                    sbQuery.Append(" ,APPLY_START_DATE ");
                    sbQuery.Append(" ,APPLY_END_DATE ");
                    sbQuery.Append(" ,APPLY_FLAG ");
                    sbQuery.Append(" ,REG_DATE ");
                    sbQuery.Append(" ,REG_EMP ");
                    sbQuery.Append(" ,DATA_FLAG ");
                    sbQuery.Append("  ) VALUES (  ");
                    sbQuery.Append("  @PLT_CODE ");
                    sbQuery.Append(" ,@DLOG_ID ");
                    sbQuery.Append(" ,@DLOG_CAT ");
                    sbQuery.Append(" ,@DLOG_TYPE ");
                    sbQuery.Append(" ,@DLOG_PERIOD ");
                    sbQuery.Append(" ,@DLOG_PLAN ");
                    sbQuery.Append(" ,@WORK_DATE ");
                    sbQuery.Append(" ,@VEN_CODE ");
                    sbQuery.Append(" ,@RELATED_EMP ");
                    sbQuery.Append(" ,@RELATED_PROD ");
                    sbQuery.Append(" ,@CONTENTS ");
                    sbQuery.Append(" ,@DLOG_TIME ");
                    sbQuery.Append(" ,@SCOMMENT ");
                    sbQuery.Append(" ,@APPLY_START_DATE ");
                    sbQuery.Append(" ,@APPLY_END_DATE ");
                    sbQuery.Append(" ,@APPLY_FLAG ");
                    sbQuery.Append(" ,GETDATE() ");
                    sbQuery.Append(" ,'" + ConnInfo.UserID + "' ");
                    sbQuery.Append(" ,@DATA_FLAG ");
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

        public static void TSYS_DAILY_LOG_PLAN_UPD(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TSYS_DAILY_LOG_PLAN SET  ");
                    sbQuery.Append("  DLOG_CAT = @DLOG_CAT ");
                    sbQuery.Append(" ,DLOG_TYPE = @DLOG_TYPE ");
                    sbQuery.Append(" ,DLOG_PERIOD = @DLOG_PERIOD ");
                    sbQuery.Append(" ,DLOG_PLAN = @DLOG_PLAN ");
                    sbQuery.Append(" ,WORK_DATE = @WORK_DATE ");
                    sbQuery.Append(" ,VEN_CODE = @VEN_CODE ");
                    sbQuery.Append(" ,RELATED_EMP = @RELATED_EMP ");
                    sbQuery.Append(" ,RELATED_PROD = @RELATED_PROD ");
                    sbQuery.Append(" ,CONTENTS = @CONTENTS ");
                    sbQuery.Append(" ,DLOG_TIME = @DLOG_TIME ");
                    sbQuery.Append(" ,SCOMMENT = @SCOMMENT ");
                    sbQuery.Append(" ,APPLY_START_DATE = @APPLY_START_DATE ");
                    sbQuery.Append(" ,APPLY_END_DATE = @APPLY_END_DATE ");
                    sbQuery.Append(" ,APPLY_FLAG = @APPLY_FLAG ");
                    sbQuery.Append(" ,MDFY_DATE = GETDATE() ");
                    sbQuery.Append(" ,MDFY_EMP = '" + ConnInfo.UserID + "' ");
                    sbQuery.Append(" ,DATA_FLAG = @DATA_FLAG ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append("  AND DLOG_ID = @DLOG_ID ");
                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "DLOG_ID")) isHasColumn = false;

                        if (isHasColumn == true)
                        {
                            bizExecute.executeUpdateQuery(sbQuery.ToString(), row);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static void TSYS_DAILY_LOG_PLAN_UDE(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TSYS_DAILY_LOG_PLAN SET  ");
                    sbQuery.Append("  DEL_DATE = GETDATE() ");
                    sbQuery.Append(" ,DEL_EMP = '" + ConnInfo.UserID + "' ");
                    sbQuery.Append(" ,DATA_FLAG = @DATA_FLAG ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append("  AND DLOG_ID = @DLOG_ID ");
                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "DLOG_ID")) isHasColumn = false;

                        if (isHasColumn == true)
                        {
                            bizExecute.executeUpdateQuery(sbQuery.ToString(), row);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }
    }

    public class TSYS_DAILY_LOG_PLAN_QUERY
    {
        public static DataTable TSYS_DAILY_LOG_PLAN_QUERY1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT L.PLT_CODE  ");
                    sbQuery.Append(" ,L.DLOG_ID ");
                    sbQuery.Append(" ,L.DLOG_CAT ");
                    sbQuery.Append(" ,L.DLOG_TYPE ");
                    sbQuery.Append(" ,L.DLOG_PERIOD ");
                    sbQuery.Append(" ,L.DLOG_PLAN ");
                    sbQuery.Append(" ,L.VEN_CODE  ");
                    sbQuery.Append(" ,L.WORK_DATE  ");
                    sbQuery.Append(" ,L.RELATED_EMP  ");
                    sbQuery.Append(" ,L.RELATED_PROD ");
                    sbQuery.Append(" ,L.CONTENTS  ");
                    sbQuery.Append(" ,L.DLOG_TIME ");
                    sbQuery.Append(" ,L.SCOMMENT ");
                    sbQuery.Append(" ,L.APPLY_START_DATE ");
                    sbQuery.Append(" ,L.APPLY_END_DATE ");
                    sbQuery.Append(" ,L.APPLY_FLAG ");
                    sbQuery.Append(" ,L.REG_DATE ");
                    sbQuery.Append(" ,L.REG_EMP ");
                    sbQuery.Append(" ,L.MDFY_DATE ");
                    sbQuery.Append(" ,L.MDFY_EMP ");
                    sbQuery.Append(" ,L.DEL_DATE ");
                    sbQuery.Append(" ,L.DEL_EMP ");
                    sbQuery.Append(" ,L.DATA_FLAG ");
                    sbQuery.Append("  FROM TSYS_DAILY_LOG_PLAN L");

                    DataRow row = dtParam.Rows[0];

                    StringBuilder sbWhere = new StringBuilder();

                    sbWhere.Append(" WHERE 1=1 ");

                    sbWhere.Append(UTIL.GetWhere(row, "@PLT_CODE", " L.PLT_CODE = @PLT_CODE"));
                    sbWhere.Append(UTIL.GetWhere(row, "@DLOG_CAT", " L.DLOG_CAT = @DLOG_CAT"));
                    sbWhere.Append(UTIL.GetWhere(row, "@DLOG_ID", " L.DLOG_ID = @DLOG_ID"));
                    sbWhere.Append(UTIL.GetWhere(row, "@REG_EMP", " L.REG_EMP = @REG_EMP"));
                    sbWhere.Append(UTIL.GetWhere(row, "@CONTENTS_LIKE", " L.CONTENTS LIKE '%' + @CONTENTS_LIKE + '%'"));
                    sbWhere.Append(" AND L.DATA_FLAG = 0");

                    DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString() + sbWhere.ToString()).Copy();

                    sourceTable.TableName = "RSLTDT";
                    dsResult.Merge(sourceTable);

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
