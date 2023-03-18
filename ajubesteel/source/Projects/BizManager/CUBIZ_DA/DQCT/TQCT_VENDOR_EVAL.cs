using BizExecute;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DQCT
{
    public class TQCT_VENDOR_EVAL
    {
        public static DataTable TQCT_VENDOR_EVAL_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("  SELECT  ");
                    sbQuery.Append("  PLT_CODE ");
                    sbQuery.Append(" ,EVAL_NO ");
                    sbQuery.Append(" ,EVAL_TYPE ");
                    sbQuery.Append(" ,EVAL_TITLE ");
                    sbQuery.Append(" ,VEN_CODE ");
                    sbQuery.Append(" ,SCOMMENT ");
                    sbQuery.Append(" ,REG_DATE ");
                    sbQuery.Append(" ,REG_EMP ");
                    sbQuery.Append(" ,MDFY_DATE ");
                    sbQuery.Append(" ,MDFY_EMP ");
                    sbQuery.Append(" ,DEL_DATE ");
                    sbQuery.Append(" ,DEL_EMP ");
                    sbQuery.Append(" ,DATA_FLAG ");
                    sbQuery.Append("  FROM TQCT_VENDOR_EVAL  ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("  AND EVAL_NO = @EVAL_NO  ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "EVAL_NO")) isHasColumn = false;

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

        public static void TQCT_VENDOR_EVAL_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" INSERT INTO TQCT_VENDOR_EVAL (  ");
                    sbQuery.Append("  PLT_CODE ");
                    sbQuery.Append(" ,EVAL_NO ");
                    sbQuery.Append(" ,EVAL_TYPE ");
                    sbQuery.Append(" ,EVAL_TITLE ");
                    sbQuery.Append(" ,VEN_CODE ");
                    sbQuery.Append(" ,SCOMMENT ");
                    sbQuery.Append(" ,REG_DATE ");
                    sbQuery.Append(" ,REG_EMP ");
                    sbQuery.Append(" ,DATA_FLAG ");
                    sbQuery.Append("  ) VALUES (  ");
                    sbQuery.Append("  @PLT_CODE ");
                    sbQuery.Append(" ,@EVAL_NO ");
                    sbQuery.Append(" ,@EVAL_TYPE ");
                    sbQuery.Append(" ,@EVAL_TITLE ");
                    sbQuery.Append(" ,@VEN_CODE ");
                    sbQuery.Append(" ,@SCOMMENT ");
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


        public static void TQCT_VENDOR_EVAL_UPD(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TQCT_VENDOR_EVAL SET  ");
                    sbQuery.Append("  EVAL_TYPE = @EVAL_TYPE ");
                    sbQuery.Append(" ,EVAL_TITLE = @EVAL_TITLE ");
                    sbQuery.Append(" ,VEN_CODE = @VEN_CODE ");
                    sbQuery.Append(" ,SCOMMENT = @SCOMMENT ");
                    sbQuery.Append(" ,MDFY_DATE = GETDATE() ");
                    sbQuery.Append(" ,MDFY_EMP = '" + ConnInfo.UserID + "' ");
                    sbQuery.Append(" ,DATA_FLAG = @DATA_FLAG ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append("  AND EVAL_NO = @EVAL_NO ");
                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "EVAL_NO")) isHasColumn = false;

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

        public static void TQCT_VENDOR_EVAL_UDE(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TQCT_VENDOR_EVAL SET  ");
                    sbQuery.Append("  DEL_DATE = GETDATE() ");
                    sbQuery.Append(" ,DEL_EMP = '" + ConnInfo.UserID + "' ");
                    sbQuery.Append(" ,DATA_FLAG = @DATA_FLAG ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append("  AND EVAL_NO = @EVAL_NO ");
                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "EVAL_NO")) isHasColumn = false;

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

    public class TQCT_VENDOR_EVAL_QUERY
    {
        public static DataTable TQCT_VENDOR_EVAL_QUERY1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("  SELECT  ");
                    sbQuery.Append("  VE.PLT_CODE ");
                    sbQuery.Append(" ,VE.EVAL_NO ");
                    sbQuery.Append(" ,VE.EVAL_TYPE ");
                    sbQuery.Append(" ,VE.EVAL_TITLE ");
                    sbQuery.Append(" ,VE.VEN_CODE ");
                    sbQuery.Append(" ,V.VEN_NAME ");
                    sbQuery.Append(" ,VE.SCOMMENT ");
                    sbQuery.Append(" ,VE.REG_DATE ");
                    sbQuery.Append(" ,VE.REG_EMP ");
                    sbQuery.Append(" ,RE.EMP_NAME AS REG_EMP_NAME ");
                    sbQuery.Append(" ,VE.MDFY_DATE ");
                    sbQuery.Append(" ,VE.MDFY_EMP ");
                    sbQuery.Append(" ,ME.EMP_NAME AS MDFY_EMP_NAME ");
                    sbQuery.Append(" ,VE.DEL_DATE ");
                    sbQuery.Append(" ,VE.DEL_EMP ");
                    sbQuery.Append(" ,VE.DATA_FLAG ");

                    sbQuery.Append("  FROM TQCT_VENDOR_EVAL VE ");
                    sbQuery.Append("  LEFT JOIN TSTD_VENDOR V ");
                    sbQuery.Append("  ON VE.PLT_CODE = V.PLT_CODE ");
                    sbQuery.Append("  AND VE.VEN_CODE = V.VEN_CODE ");

                    sbQuery.Append("  LEFT JOIN TSTD_EMPLOYEE RE ");
                    sbQuery.Append("  ON VE.PLT_CODE = RE.PLT_CODE ");
                    sbQuery.Append("  AND VE.REG_EMP = RE.EMP_CODE ");

                    sbQuery.Append("  LEFT JOIN TSTD_EMPLOYEE ME ");
                    sbQuery.Append("  ON VE.PLT_CODE = ME.PLT_CODE ");
                    sbQuery.Append("  AND VE.MDFY_EMP = ME.EMP_CODE ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder();

                        sbWhere.Append(" WHERE VE.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                        sbWhere.Append(UTIL.GetWhere(row, "@EVAL_NO", "VE.EVAL_NO = @EVAL_NO"));

                        sbWhere.Append(UTIL.GetWhere(row, "@S_REG_DATE,@E_REG_DATE", "CONVERT(VARCHAR(8), VE.REG_DATE, 112) BETWEEN @S_REG_DATE AND @E_REG_DATE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@VEN_LIKE", "(VE.VEN_CODE LIKE '%' + @VEN_LIKE + '%' OR V.VEN_NAME LIKE '%' + @VEN_LIKE + '%')"));

                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "VE.DATA_FLAG = @DATA_FLAG"));

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
