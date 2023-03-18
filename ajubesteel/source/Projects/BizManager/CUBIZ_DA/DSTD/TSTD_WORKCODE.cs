using BizExecute;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSTD
{
    public class TSTD_WORKCODE
    {
        public static DataTable TSTD_WORKCODE_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("  SELECT  ");
                    sbQuery.Append("  PLT_CODE ");
                    sbQuery.Append(" ,WORK_CODE ");
                    sbQuery.Append(" ,WORK_NAME ");
                    sbQuery.Append(" ,INPUT_TYPE ");
                    sbQuery.Append(" ,WORK_SEQ ");
                    sbQuery.Append(" ,SCOMMENT ");
                    sbQuery.Append(" ,REG_DATE ");
                    sbQuery.Append(" ,REG_EMP ");
                    sbQuery.Append(" ,MDFY_DATE ");
                    sbQuery.Append(" ,MDFY_EMP ");
                    sbQuery.Append(" ,DEL_DATE ");
                    sbQuery.Append(" ,DEL_EMP ");
                    sbQuery.Append(" ,DATA_FLAG ");
                    sbQuery.Append("  FROM TSTD_WORKCODE  ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("  AND WORK_CODE = @WORK_CODE  ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "WORK_CODE")) isHasColumn = false;

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

        public static void TSTD_WORKCODE_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" INSERT INTO TSTD_WORKCODE (  ");
                    sbQuery.Append("  PLT_CODE ");
                    sbQuery.Append(" ,WORK_CODE ");
                    sbQuery.Append(" ,WORK_NAME ");
                    sbQuery.Append(" ,INPUT_TYPE ");
                    sbQuery.Append(" ,START_TIME ");
                    sbQuery.Append(" ,IS_HALF ");
                    sbQuery.Append(" ,IS_HOLI ");
                    sbQuery.Append(" ,IS_PRE ");
                    sbQuery.Append(" ,IS_OUT ");
                    sbQuery.Append(" ,IS_YESTERDAY ");
                    sbQuery.Append(" ,IS_UPD ");
                    sbQuery.Append(" ,WORK_SEQ ");
                    sbQuery.Append(" ,SCOMMENT ");
                    sbQuery.Append(" ,REG_DATE ");
                    sbQuery.Append(" ,REG_EMP ");
                    sbQuery.Append(" ,DATA_FLAG ");
                    sbQuery.Append("  ) VALUES (  ");
                    sbQuery.Append("  @PLT_CODE ");
                    sbQuery.Append(" ,@WORK_CODE ");
                    sbQuery.Append(" ,@WORK_NAME ");
                    sbQuery.Append(" ,@INPUT_TYPE ");
                    sbQuery.Append(" ,@START_TIME ");
                    sbQuery.Append(" ,@IS_HALF ");
                    sbQuery.Append(" ,@IS_HOLI ");
                    sbQuery.Append(" ,@IS_PRE ");
                    sbQuery.Append(" ,@IS_OUT ");
                    sbQuery.Append(" ,@IS_YESTERDAY ");
                    sbQuery.Append(" ,@IS_UPD ");
                    sbQuery.Append(" ,@WORK_SEQ ");
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

        public static void TSTD_WORKCODE_UPD(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TSTD_WORKCODE SET  ");
                    sbQuery.Append("  WORK_NAME = @WORK_NAME ");
                    sbQuery.Append(" ,INPUT_TYPE = @INPUT_TYPE ");
                    sbQuery.Append(" ,START_TIME = @START_TIME ");
                    sbQuery.Append(" ,IS_HALF = @IS_HALF ");
                    sbQuery.Append(" ,IS_HOLI = @IS_HOLI ");
                    sbQuery.Append(" ,IS_PRE = @IS_PRE ");
                    sbQuery.Append(" ,IS_OUT = @IS_OUT ");
                    sbQuery.Append(" ,IS_YESTERDAY = @IS_YESTERDAY ");
                    sbQuery.Append(" ,IS_UPD = @IS_UPD ");
                    sbQuery.Append(" ,WORK_SEQ = @WORK_SEQ ");
                    sbQuery.Append(" ,SCOMMENT = @SCOMMENT ");
                    sbQuery.Append(" ,MDFY_DATE = GETDATE()");
                    sbQuery.Append(" ,MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" ,DATA_FLAG = @DATA_FLAG ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append("  AND WORK_CODE = @WORK_CODE ");
                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "WORK_CODE")) isHasColumn = false;

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

        public static void TSTD_WORKCODE_UDE(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TSTD_WORKCODE SET  ");
                    sbQuery.Append("  DEL_DATE = GETDATE()");
                    sbQuery.Append(" ,DEL_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" ,DATA_FLAG = @DATA_FLAG ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append("  AND WORK_CODE = @WORK_CODE ");
                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "WORK_CODE")) isHasColumn = false;

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

    public class TSTD_WORKCODE_QUERY
    {
        public static DataTable TSTD_WORKCODE_QUERY1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT");
                    sbQuery.Append(" PLT_CODE");
                    sbQuery.Append(" ,WORK_CODE");
                    sbQuery.Append(" ,WORK_NAME");
                    sbQuery.Append(" ,INPUT_TYPE");
                    sbQuery.Append(" ,ISNULL(IS_HALF, '0') AS IS_HALF");
                    sbQuery.Append(" ,ISNULL(IS_HOLI,'0') AS IS_HOLI");
                    sbQuery.Append(" ,ISNULL(IS_PRE,'0') AS IS_PRE");
                    sbQuery.Append(" ,ISNULL(IS_OUT,'0') AS IS_OUT");
                    sbQuery.Append(" ,ISNULL(IS_YESTERDAY,'0') AS IS_YESTERDAY");
                    sbQuery.Append(" ,ISNULL(IS_UPD,'0') AS IS_UPD");
                    sbQuery.Append(" ,WORK_SEQ");
                    sbQuery.Append(" ,START_TIME");
                    sbQuery.Append(" ,SCOMMENT");
                    sbQuery.Append(" ,REG_DATE");
                    sbQuery.Append(" ,REG_EMP");
                    sbQuery.Append(" ,MDFY_DATE");
                    sbQuery.Append(" ,MDFY_EMP");
                    sbQuery.Append(" ,DEL_DATE");
                    sbQuery.Append(" ,DEL_EMP");
                    sbQuery.Append(" ,DATA_FLAG");
                    sbQuery.Append(" FROM TSTD_WORKCODE");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder();

                        sbWhere.Append(" WHERE PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@WORK_CODE", "WORK_CODE = @WORK_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@WORK_LIKE", "(WORK_CODE LIKE '%' + @WORK_LIKE + '%' OR WORK_NAME '%' + @WORK_LIKE + '%')"));
                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "DATA_FLAG = @DATA_FLAG"));

                        StringBuilder sbOrderBy = new StringBuilder();
                        sbOrderBy.Append(" ORDER BY WORK_SEQ");

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
