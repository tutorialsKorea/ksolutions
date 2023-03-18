using BizExecute;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSTD
{
    public class TSTD_EMP_HOLI
    {
        public static DataTable TSTD_EMP_HOLI_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("  SELECT  ");
                    sbQuery.Append("  PLT_CODE ");
                    sbQuery.Append(" ,EMP_CODE ");
                    sbQuery.Append(" ,EH_SEQ ");
                    sbQuery.Append(" ,ACCOUNT_CNT ");
                    sbQuery.Append(" ,ACCOUNT_CALC_DATE ");
                    sbQuery.Append(" ,EMP_STATUS ");
                    sbQuery.Append(" ,WORK_YEAR ");
                    sbQuery.Append(" ,HOLI_OCCUR_DATE ");
                    sbQuery.Append(" ,HOLI_OCCUR_CNT ");
                    sbQuery.Append(" ,HOLI_OCCUR_INPUT_CNT ");
                    sbQuery.Append(" ,ALLOWANCE_DATE ");
                    sbQuery.Append(" ,ALLOWANCE_CNT ");
                    sbQuery.Append(" ,IS_USE ");
                    sbQuery.Append(" ,REG_DATE ");
                    sbQuery.Append(" ,REG_EMP ");
                    sbQuery.Append(" ,MDFY_DATE ");
                    sbQuery.Append(" ,MDFY_EMP ");
                    sbQuery.Append(" ,DEL_DATE ");
                    sbQuery.Append(" ,DEL_EMP ");
                    sbQuery.Append(" ,DATA_FLAG ");
                    sbQuery.Append("  FROM TSTD_EMP_HOLI  ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("  AND EMP_CODE = @EMP_CODE  ");
                    sbQuery.Append("  AND EH_SEQ = @EH_SEQ  ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "EMP_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "EH_SEQ")) isHasColumn = false;

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

        public static DataTable TSTD_EMP_HOLI_SER2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("  SELECT  ");
                    sbQuery.Append("  PLT_CODE ");
                    sbQuery.Append(" ,EMP_CODE ");
                    sbQuery.Append(" ,EH_SEQ ");
                    sbQuery.Append(" ,ACCOUNT_CNT ");
                    sbQuery.Append(" ,ACCOUNT_CALC_DATE ");
                    sbQuery.Append(" ,EMP_STATUS ");
                    sbQuery.Append(" ,WORK_YEAR ");
                    sbQuery.Append(" ,HOLI_OCCUR_DATE ");
                    sbQuery.Append(" ,HOLI_OCCUR_CNT ");
                    sbQuery.Append(" ,HOLI_OCCUR_INPUT_CNT ");
                    sbQuery.Append(" ,ALLOWANCE_DATE ");
                    sbQuery.Append(" ,ALLOWANCE_CNT ");
                    sbQuery.Append(" ,IS_USE ");
                    sbQuery.Append(" ,REG_DATE ");
                    sbQuery.Append(" ,REG_EMP ");
                    sbQuery.Append(" ,MDFY_DATE ");
                    sbQuery.Append(" ,MDFY_EMP ");
                    sbQuery.Append(" ,DEL_DATE ");
                    sbQuery.Append(" ,DEL_EMP ");
                    sbQuery.Append(" ,DATA_FLAG ");
                    sbQuery.Append("  FROM TSTD_EMP_HOLI  ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("  AND EMP_CODE = @EMP_CODE  ");
                    sbQuery.Append("  AND ACCOUNT_CNT = @ACCOUNT_CNT  ");
                    sbQuery.Append("  AND ACCOUNT_CALC_DATE = @ACCOUNT_CALC_DATE  ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "EMP_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "ACCOUNT_CNT")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "ACCOUNT_CALC_DATE")) isHasColumn = false;

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

        public static void TSTD_EMP_HOLI_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" INSERT INTO TSTD_EMP_HOLI (  ");
                    sbQuery.Append("  PLT_CODE ");
                    sbQuery.Append(" ,EMP_CODE ");
                    sbQuery.Append(" ,EH_SEQ ");
                    sbQuery.Append(" ,ACCOUNT_CNT ");
                    sbQuery.Append(" ,ACCOUNT_CALC_DATE ");
                    sbQuery.Append(" ,EMP_STATUS ");
                    sbQuery.Append(" ,WORK_YEAR ");
                    sbQuery.Append(" ,HOLI_OCCUR_DATE ");
                    sbQuery.Append(" ,HOLI_OCCUR_CNT ");
                    sbQuery.Append(" ,HOLI_OCCUR_INPUT_CNT ");
                    sbQuery.Append(" ,ALLOWANCE_DATE ");
                    sbQuery.Append(" ,ALLOWANCE_CNT ");
                    sbQuery.Append(" ,IS_USE ");
                    sbQuery.Append(" ,REG_DATE ");
                    sbQuery.Append(" ,REG_EMP ");
                    sbQuery.Append(" ,DATA_FLAG ");
                    sbQuery.Append("  ) VALUES (  ");
                    sbQuery.Append("  @PLT_CODE ");
                    sbQuery.Append(" ,@EMP_CODE ");
                    sbQuery.Append(" ,@EH_SEQ ");
                    sbQuery.Append(" ,@ACCOUNT_CNT ");
                    sbQuery.Append(" ,@ACCOUNT_CALC_DATE ");
                    sbQuery.Append(" ,@EMP_STATUS ");
                    sbQuery.Append(" ,@WORK_YEAR ");
                    sbQuery.Append(" ,@HOLI_OCCUR_DATE ");
                    sbQuery.Append(" ,@HOLI_OCCUR_CNT ");
                    sbQuery.Append(" ,@HOLI_OCCUR_INPUT_CNT ");
                    sbQuery.Append(" ,@ALLOWANCE_DATE ");
                    sbQuery.Append(" ,@ALLOWANCE_CNT ");
                    sbQuery.Append(" ,@IS_USE ");
                    sbQuery.Append(" , GETDATE()");
                    sbQuery.Append(" , " + UTIL.GetValidValue(ConnInfo.UserID));
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

        public static void TSTD_EMP_HOLI_UPD(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TSTD_EMP_HOLI SET  ");
                    sbQuery.Append("  ACCOUNT_CNT = @ACCOUNT_CNT ");
                    sbQuery.Append(" ,ACCOUNT_CALC_DATE = @ACCOUNT_CALC_DATE ");
                    sbQuery.Append(" ,EMP_STATUS = @EMP_STATUS ");
                    sbQuery.Append(" ,WORK_YEAR = @WORK_YEAR ");
                    sbQuery.Append(" ,HOLI_OCCUR_DATE = @HOLI_OCCUR_DATE ");
                    sbQuery.Append(" ,HOLI_OCCUR_CNT = @HOLI_OCCUR_CNT ");
                    sbQuery.Append(" ,HOLI_OCCUR_INPUT_CNT = @HOLI_OCCUR_INPUT_CNT ");
                    sbQuery.Append(" ,ALLOWANCE_DATE = @ALLOWANCE_DATE ");
                    sbQuery.Append(" ,ALLOWANCE_CNT = @ALLOWANCE_CNT ");
                    sbQuery.Append(" ,IS_USE = @IS_USE ");
                    sbQuery.Append(" ,MDFY_DATE = GETDATE()");
                    sbQuery.Append(" ,MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" ,DATA_FLAG = @DATA_FLAG ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append("  AND EMP_CODE = @EMP_CODE ");
                    sbQuery.Append("  AND EH_SEQ = @EH_SEQ ");
                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "EMP_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "EH_SEQ")) isHasColumn = false;

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

        public static void TSTD_EMP_HOLI_UPD2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TSTD_EMP_HOLI SET  ");
                    sbQuery.Append("  ACCOUNT_CNT = @ACCOUNT_CNT ");
                    sbQuery.Append(" ,ACCOUNT_CALC_DATE = @ACCOUNT_CALC_DATE ");
                    sbQuery.Append(" ,EMP_STATUS = @EMP_STATUS ");
                    sbQuery.Append(" ,WORK_YEAR = @WORK_YEAR ");
                    sbQuery.Append(" ,HOLI_OCCUR_DATE = @HOLI_OCCUR_DATE ");
                    sbQuery.Append(" ,HOLI_OCCUR_CNT = @HOLI_OCCUR_CNT ");
                    sbQuery.Append(" ,ALLOWANCE_DATE = @ALLOWANCE_DATE ");
                    sbQuery.Append(" ,ALLOWANCE_CNT = @ALLOWANCE_CNT ");
                    sbQuery.Append(" ,IS_USE = @IS_USE ");
                    sbQuery.Append(" ,MDFY_DATE = GETDATE()");
                    sbQuery.Append(" ,MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" ,DATA_FLAG = @DATA_FLAG ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append("  AND EMP_CODE = @EMP_CODE ");
                    sbQuery.Append("  AND EH_SEQ = @EH_SEQ ");
                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "EMP_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "EH_SEQ")) isHasColumn = false;

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

        public static void TSTD_EMP_HOLI_UPD3(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TSTD_EMP_HOLI SET  ");
                    sbQuery.Append("  IS_USE = @IS_USE ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append("  AND EMP_CODE = @EMP_CODE ");
                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
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

        public static void TSTD_EMP_HOLI_UPD4(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TSTD_EMP_HOLI SET  ");
                    sbQuery.Append("  HOLI_OCCUR_INPUT_CNT = @HOLI_OCCUR_INPUT_CNT ");
                    sbQuery.Append(" ,IS_USE = @IS_USE ");
                    sbQuery.Append(" ,MDFY_DATE = GETDATE()");
                    sbQuery.Append(" ,MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" ,DATA_FLAG = @DATA_FLAG ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append("  AND EMP_CODE = @EMP_CODE ");
                    sbQuery.Append("  AND EH_SEQ = @EH_SEQ ");
                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "EMP_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "EH_SEQ")) isHasColumn = false;

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

        public static void TSTD_EMP_HOLI_UPD5(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TSTD_EMP_HOLI SET  ");
                    sbQuery.Append("  IS_USE = @IS_USE ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append("  AND EMP_CODE = @EMP_CODE ");
                    sbQuery.Append("  AND EH_SEQ = @EH_SEQ ");
                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "EMP_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "EH_SEQ")) isHasColumn = false;

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

        public static void TSTD_EMP_HOLI_UPD6(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TSTD_EMP_HOLI SET  ");
                    sbQuery.Append("  HOLI_OCCUR_INPUT_CNT = @HOLI_OCCUR_INPUT_CNT");
                    sbQuery.Append(" ,MDFY_DATE = GETDATE()");
                    sbQuery.Append(" ,MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append("  AND EMP_CODE = @EMP_CODE ");
                    sbQuery.Append("  AND EH_SEQ = @EH_SEQ ");
                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "EMP_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "EH_SEQ")) isHasColumn = false;

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

    public class TSTD_EMP_HOLI_QUERY
    {
        public static DataTable TSTD_EMP_HOLI_QUERY1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT");
                    sbQuery.Append(" EH.PLT_CODE");
                    sbQuery.Append(" ,EH.EMP_CODE");
                    sbQuery.Append(" ,E.EMP_NAME");
                    sbQuery.Append(" ,EH.EH_SEQ");
                    sbQuery.Append(" ,EH.ACCOUNT_CNT");
                    sbQuery.Append(" ,EH.ACCOUNT_CALC_DATE");
                    sbQuery.Append(" ,EH.EMP_STATUS");
                    sbQuery.Append(" ,EH.WORK_YEAR");
                    //sbQuery.Append(" ,EH.HOLI_OCCUR_DATE");
                    sbQuery.Append(" ,CASE WHEN LEN(HOLI_OCCUR_DATE) = 8 THEN SUBSTRING(HOLI_OCCUR_DATE,1,4) +'-' + SUBSTRING(HOLI_OCCUR_DATE, 5, 2) + '-' + SUBSTRING(HOLI_OCCUR_DATE, 7, 2) ELSE HOLI_OCCUR_DATE END AS HOLI_OCCUR_DATE");
                    sbQuery.Append(" ,EH.HOLI_OCCUR_CNT");
                    sbQuery.Append(" ,EH.HOLI_OCCUR_INPUT_CNT");
                    sbQuery.Append(" ,EH.ALLOWANCE_DATE");
                    sbQuery.Append(" ,EH.ALLOWANCE_CNT");
                    sbQuery.Append(" ,EH.IS_USE");
                    sbQuery.Append(" ,EH.REG_DATE");
                    sbQuery.Append(" ,EH.REG_EMP");
                    sbQuery.Append(" ,EH.MDFY_DATE");
                    sbQuery.Append(" ,EH.MDFY_EMP");
                    sbQuery.Append(" ,EH.DEL_DATE");
                    sbQuery.Append(" ,EH.DEL_EMP");
                    sbQuery.Append(" ,EH.DATA_FLAG");
                    sbQuery.Append(" FROM TSTD_EMP_HOLI EH");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE E");
                    sbQuery.Append(" ON EH.PLT_CODE = E.PLT_CODE");
                    sbQuery.Append(" AND EH.EMP_CODE = E.EMP_CODE");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        StringBuilder sbWhere = new StringBuilder();
                        sbWhere.Append(" WHERE EH.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                        sbWhere.Append(UTIL.GetWhere(row, "@EMP_CODE", "EH.EMP_CODE = @EMP_CODE"));

                        StringBuilder sbOrderBy = new StringBuilder();
                        sbOrderBy.Append(" ORDER BY EH.EH_SEQ");

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

        public static DataTable TSTD_EMP_HOLI_QUERY2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT");
                    sbQuery.Append(" PLT_CODE");
                    sbQuery.Append(" ,EMP_CODE");
                    sbQuery.Append(" ,LEFT(ACCOUNT_CALC_DATE, 4) AS ACCOUNT_CALC_YEAR");
                    sbQuery.Append(" ,SUM(HOLI_OCCUR_INPUT_CNT) AS HOLI_OCCUR_INPUT_CNT");
                    sbQuery.Append(" FROM TSTD_EMP_HOLI");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        StringBuilder sbWhere = new StringBuilder();
                        sbWhere.Append(" WHERE PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                        sbWhere.Append(UTIL.GetWhere(row, "@EMP_CODE", "EMP_CODE = @EMP_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@IS_USE", "IS_USE = @IS_USE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@ACCOUNT_CALC_YEAR", "LEFT(ACCOUNT_CALC_DATE, 4) <= @ACCOUNT_CALC_YEAR"));

                        StringBuilder sbGroupBy = new StringBuilder();

                        sbGroupBy.Append(" GROUP BY PLT_CODE");
                        sbGroupBy.Append(" ,EMP_CODE");
                        sbGroupBy.Append(" ,LEFT(ACCOUNT_CALC_DATE, 4)");

                        StringBuilder sbOrderBy = new StringBuilder();
                        sbOrderBy.Append(" ORDER BY LEFT(ACCOUNT_CALC_DATE, 4) DESC");

                        DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString() + sbWhere.ToString() + sbGroupBy.ToString() + sbOrderBy.ToString()).Copy();

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
