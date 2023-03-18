using BizExecute;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSTD
{
    public class TSTD_WORKMNG
    {
        public static DataTable TSTD_WORKMNG_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("  SELECT  ");
                    sbQuery.Append("  PLT_CODE ");
                    sbQuery.Append(" ,WORK_DATE ");
                    sbQuery.Append(" ,EMP_CODE ");
                    sbQuery.Append(" ,EMP_NAME ");
                    sbQuery.Append(" ,ORG_CODE ");
                    sbQuery.Append(" ,ORG_NAME ");
                    sbQuery.Append(" ,EMP_TITLE ");
                    sbQuery.Append(" ,WORK_START_TIME ");
                    sbQuery.Append(" ,WORK_END_TIME ");
                    sbQuery.Append(" ,WORK_START_TYPE ");
                    sbQuery.Append(" ,WORK_END_TYPE ");
                    sbQuery.Append(" ,WORK_TIME ");
                    sbQuery.Append(" ,SCOMMENT ");
                    sbQuery.Append(" ,REG_DATE ");
                    sbQuery.Append(" ,REG_EMP ");
                    sbQuery.Append(" ,MDFY_DATE ");
                    sbQuery.Append(" ,MDFY_EMP ");
                    sbQuery.Append(" ,DEL_DATE ");
                    sbQuery.Append(" ,DEL_EMP ");
                    sbQuery.Append(" ,DATA_FLAG ");
                    sbQuery.Append("  FROM TSTD_WORKMNG  ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("  AND WORK_DATE = @WORK_DATE  ");
                    sbQuery.Append("  AND EMP_CODE = @EMP_CODE  ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "WORK_DATE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "EMP_CODE")) isHasColumn = false;

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


        public static void TSTD_WORKMNG_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" INSERT INTO TSTD_WORKMNG (  ");
                    sbQuery.Append("  PLT_CODE ");
                    sbQuery.Append(" ,WORK_DATE ");
                    sbQuery.Append(" ,EMP_CODE ");
                    sbQuery.Append(" ,EMP_NAME ");
                    sbQuery.Append(" ,ORG_CODE ");
                    sbQuery.Append(" ,ORG_NAME ");
                    sbQuery.Append(" ,EMP_TITLE ");
                    sbQuery.Append(" ,WORK_START_TIME ");
                    sbQuery.Append(" ,WORK_END_TIME ");
                    sbQuery.Append(" ,WORK_START_TYPE ");
                    sbQuery.Append(" ,WORK_END_TYPE ");
                    sbQuery.Append(" ,WORK_TIME ");
                    sbQuery.Append(" ,SCOMMENT ");
                    sbQuery.Append(" ,REG_DATE ");
                    sbQuery.Append(" ,REG_EMP ");
                    sbQuery.Append(" ,DATA_FLAG ");
                    sbQuery.Append("  ) VALUES (  ");
                    sbQuery.Append("  @PLT_CODE ");
                    sbQuery.Append(" ,@WORK_DATE ");
                    sbQuery.Append(" ,@EMP_CODE ");
                    sbQuery.Append(" ,@EMP_NAME ");
                    sbQuery.Append(" ,@ORG_CODE ");
                    sbQuery.Append(" ,@ORG_NAME ");
                    sbQuery.Append(" ,@EMP_TITLE ");
                    sbQuery.Append(" ,@WORK_START_TIME ");
                    sbQuery.Append(" ,@WORK_END_TIME ");
                    sbQuery.Append(" ,@WORK_START_TYPE ");
                    sbQuery.Append(" ,@WORK_END_TYPE ");
                    sbQuery.Append(" ,@WORK_TIME ");
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


        public static void TSTD_WORKMNG_UPD(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TSTD_WORKMNG SET  ");
                    sbQuery.Append("  EMP_NAME = @EMP_NAME ");
                    sbQuery.Append(" ,ORG_CODE = @ORG_CODE ");
                    sbQuery.Append(" ,ORG_NAME = @ORG_NAME ");
                    sbQuery.Append(" ,EMP_TITLE = @EMP_TITLE ");
                    sbQuery.Append(" ,WORK_START_TIME = @WORK_START_TIME ");
                    sbQuery.Append(" ,WORK_END_TIME = @WORK_END_TIME ");
                    sbQuery.Append(" ,WORK_START_TYPE = @WORK_START_TYPE ");
                    sbQuery.Append(" ,WORK_END_TYPE = @WORK_END_TYPE ");
                    sbQuery.Append(" ,WORK_TIME = @WORK_TIME ");
                    sbQuery.Append(" ,SCOMMENT = @SCOMMENT ");
                    sbQuery.Append(" ,MDFY_DATE = GETDATE()");
                    sbQuery.Append(" ,MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" ,DATA_FLAG = @DATA_FLAG ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append("  AND WORK_DATE = @WORK_DATE ");
                    sbQuery.Append("  AND EMP_CODE = @EMP_CODE ");
                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "WORK_DATE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "EMP_CODE")) isHasColumn = false;

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

    public class TSTD_WORKMNG_QUERY
    {
        public static DataTable TSTD_WORKMNG_QUERY1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT");
                    sbQuery.Append(" PLT_CODE");
                    sbQuery.Append(" ,WORK_DATE");
                    sbQuery.Append(" ,EMP_CODE");
                    sbQuery.Append(" ,EMP_NAME");
                    sbQuery.Append(" ,ORG_CODE");
                    sbQuery.Append(" ,ORG_NAME");
                    sbQuery.Append(" ,EMP_TITLE");
                    sbQuery.Append(" ,WORK_START_TIME");
                    sbQuery.Append(" ,WORK_END_TIME");
                    sbQuery.Append(" ,WORK_START_TYPE");
                    sbQuery.Append(" ,WORK_END_TYPE");
                    sbQuery.Append(" ,WORK_TIME");
                    sbQuery.Append(" ,SCOMMENT");
                    sbQuery.Append(" ,REG_DATE");
                    sbQuery.Append(" ,REG_EMP");
                    sbQuery.Append(" ,MDFY_DATE");
                    sbQuery.Append(" ,MDFY_EMP");
                    sbQuery.Append(" ,DEL_DATE");
                    sbQuery.Append(" ,DEL_EMP");
                    sbQuery.Append(" ,DATA_FLAG");
                    sbQuery.Append(" FROM TSTD_WORKMNG");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder();

                        sbWhere.Append(" WHERE PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                        sbWhere.Append(UTIL.GetWhere(row, "@EMP_CODE", "EMP_CODE = @EMP_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_WORK_DATE,@E_WORK_DATE", "WORK_DATE BETWEEN @S_WORK_DATE AND @E_WORK_DATE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "DATA_FLAG = @DATA_FLAG"));

                        StringBuilder sbOrderBy = new StringBuilder();
                        sbOrderBy.Append(" ORDER BY EMP_NAME");

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
    }
}
