using BizExecute;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSTD
{
    public class TSTD_IDLETIME
    {
        public static DataTable TSTD_IDLETIME_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("  SELECT  ");
                    sbQuery.Append("  PLT_CODE ");
                    sbQuery.Append(" ,IDLE_ID ");
                    sbQuery.Append(" ,IDLE_NAME ");
                    sbQuery.Append(" ,IDLE_START_TIME ");
                    sbQuery.Append(" ,IDLE_END_TIME ");
                    sbQuery.Append(" ,IDLE_SEQ ");
                    sbQuery.Append(" ,IDLE_FLAG ");
                    sbQuery.Append(" ,SCOMMENT ");
                    sbQuery.Append(" ,REG_DATE ");
                    sbQuery.Append(" ,REG_EMP ");
                    sbQuery.Append(" ,MDFY_DATE ");
                    sbQuery.Append(" ,MDFY_EMP ");
                    sbQuery.Append(" ,DEL_DATE ");
                    sbQuery.Append(" ,DEL_EMP ");
                    sbQuery.Append(" ,DATA_FLAG ");
                    sbQuery.Append("  FROM TSTD_IDLETIME  ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("  AND IDLE_ID = @IDLE_ID  ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "IDLE_ID")) isHasColumn = false;

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

        public static void TSTD_IDLETIME_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" INSERT INTO TSTD_IDLETIME (  ");
                    sbQuery.Append("  PLT_CODE ");
                    sbQuery.Append(" ,IDLE_ID ");
                    sbQuery.Append(" ,IDLE_NAME ");
                    sbQuery.Append(" ,IDLE_START_TIME ");
                    sbQuery.Append(" ,IDLE_END_TIME ");
                    sbQuery.Append(" ,IDLE_SEQ ");
                    sbQuery.Append(" ,IDLE_FLAG ");
                    sbQuery.Append(" ,SCOMMENT ");
                    sbQuery.Append(" ,REG_DATE ");
                    sbQuery.Append(" ,REG_EMP ");
                    sbQuery.Append(" ,DATA_FLAG ");
                    sbQuery.Append("  ) VALUES (  ");
                    sbQuery.Append("  @PLT_CODE ");
                    sbQuery.Append(" ,@IDLE_ID ");
                    sbQuery.Append(" ,@IDLE_NAME ");
                    sbQuery.Append(" ,@IDLE_START_TIME ");
                    sbQuery.Append(" ,@IDLE_END_TIME ");
                    sbQuery.Append(" ,@IDLE_SEQ ");
                    sbQuery.Append(" ,@IDLE_FLAG ");
                    sbQuery.Append(" ,@SCOMMENT ");
                    sbQuery.Append(" ,GETDATE() ");
                    sbQuery.Append(" ," + UTIL.GetValidValue(ConnInfo.UserID));
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

        public static void TSTD_IDLETIME_UPD(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TSTD_IDLETIME SET  ");
                    sbQuery.Append("  IDLE_NAME = @IDLE_NAME ");
                    sbQuery.Append(" ,IDLE_START_TIME = @IDLE_START_TIME ");
                    sbQuery.Append(" ,IDLE_END_TIME = @IDLE_END_TIME ");
                    sbQuery.Append(" ,IDLE_SEQ = @IDLE_SEQ ");
                    sbQuery.Append(" ,IDLE_FLAG = @IDLE_FLAG ");
                    sbQuery.Append(" ,SCOMMENT = @SCOMMENT ");
                    sbQuery.Append(" ,MDFY_DATE = GETDATE()");
                    sbQuery.Append(" ,MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" ,DATA_FLAG = @DATA_FLAG ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append("  AND IDLE_ID = @IDLE_ID ");
                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "IDLE_ID")) isHasColumn = false;

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

        public static void TSTD_IDLETIME_UDE(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TSTD_IDLETIME SET  ");
                    sbQuery.Append("  DEL_DATE = GETDATE()");
                    sbQuery.Append(" ,DEL_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" ,DATA_FLAG = @DATA_FLAG ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append("  AND IDLE_ID = @IDLE_ID ");
                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "IDLE_ID")) isHasColumn = false;

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

    public class TSTD_IDLETIME_QUERY
    {
        public static DataTable TSTD_IDLETIME_QUERY1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT");
                    sbQuery.Append(" PLT_CODE");
                    sbQuery.Append(" ,IDLE_ID");
                    sbQuery.Append(" ,IDLE_NAME");
                    sbQuery.Append(" ,IDLE_START_TIME");
                    sbQuery.Append(" ,IDLE_END_TIME");
                    sbQuery.Append(" ,IDLE_SEQ");
                    sbQuery.Append(" ,IDLE_FLAG");
                    sbQuery.Append(" ,SCOMMENT");
                    sbQuery.Append(" FROM TSTD_IDLETIME");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder();

                        sbWhere.Append(" WHERE PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                        sbWhere.Append(UTIL.GetWhere(row, "@IDLE_ID", "IDLE_ID = @IDLE_ID"));
                        sbWhere.Append(UTIL.GetWhere(row, "@IDLE_LIKE", "(IDLE_ID LIKE '%' + @IDLE_LIKE + '%' OR IDLE_NAME LIKE '%' + @IDLE_LIKE + '%')"));
                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "DATA_FLAG = @DATA_FLAG"));

                        StringBuilder sbOrderBy = new StringBuilder();
                        sbOrderBy.Append(" ORDER BY IDLE_SEQ");

                        DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString() + sbWhere.ToString() + sbOrderBy.ToString()).Copy();

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

        public static DataTable TSTD_IDLETIME_QUERY2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT");
                    sbQuery.Append(" PLT_CODE");
                    sbQuery.Append(" ,IDLE_START_TIME");
                    sbQuery.Append(" ,IDLE_END_TIME");
                    sbQuery.Append(" ,ISNULL(IDLE_FLAG, '0') AS IDLE_FLAG");
                    sbQuery.Append(" FROM TSTD_IDLETIME");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder();

                        sbWhere.Append(" WHERE PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                        sbWhere.Append(UTIL.GetWhere(row, "@IDLE_ID", "IDLE_ID = @IDLE_ID"));
                        sbWhere.Append(UTIL.GetWhere(row, "@IDLE_LIKE", "(IDLE_ID LIKE '%' + @IDLE_LIKE + '%' OR IDLE_NAME LIKE '%' + @IDLE_LIKE + '%')"));
                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "DATA_FLAG = @DATA_FLAG"));

                        StringBuilder sbGrouprBy = new StringBuilder();
                        sbGrouprBy.Append(" GROUP BY PLT_CODE, IDLE_START_TIME, IDLE_END_TIME, ISNULL(IDLE_FLAG, '0')");

                        DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString() + sbWhere.ToString() + sbGrouprBy.ToString()).Copy();

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
