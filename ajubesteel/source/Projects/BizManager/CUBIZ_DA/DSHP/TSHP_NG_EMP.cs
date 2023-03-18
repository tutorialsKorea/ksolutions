using BizExecute;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSHP
{
    public class TSHP_NG_EMP
    {
        public static DataTable TSHP_NG_EMP_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("  SELECT  ");
                    sbQuery.Append("  PLT_CODE ");
                    sbQuery.Append(" ,NG_ID ");
                    sbQuery.Append(" ,EMP_CODE ");
                    sbQuery.Append(" ,IS_POPUP ");
                    sbQuery.Append(" ,REG_DATE ");
                    sbQuery.Append(" ,REG_EMP ");
                    sbQuery.Append(" ,MDFY_DATE ");
                    sbQuery.Append(" ,MDFY_EMP ");
                    sbQuery.Append("  FROM TSHP_NG_EMP  ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("  AND NG_ID = @NG_ID  ");
                    sbQuery.Append("  AND EMP_CODE = @EMP_CODE  ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "NG_ID")) isHasColumn = false;
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

        public static DataTable TSHP_NG_EMP_SER2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("  SELECT  ");
                    sbQuery.Append("  PLT_CODE ");
                    sbQuery.Append(" ,NG_ID ");
                    sbQuery.Append(" ,EMP_CODE ");
                    sbQuery.Append(" ,IS_POPUP ");
                    sbQuery.Append(" ,REG_DATE ");
                    sbQuery.Append(" ,REG_EMP ");
                    sbQuery.Append(" ,MDFY_DATE ");
                    sbQuery.Append(" ,MDFY_EMP ");
                    sbQuery.Append("  FROM TSHP_NG_EMP  ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("  AND NG_ID = @NG_ID  ");
                    sbQuery.Append("  AND EMP_CODE = @EMP_CODE  ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "NG_ID")) isHasColumn = false;
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

        public static void TSHP_NG_EMP_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" INSERT INTO TSHP_NG_EMP (  ");
                    sbQuery.Append("  PLT_CODE ");
                    sbQuery.Append(" ,NG_ID ");
                    sbQuery.Append(" ,EMP_CODE ");
                    sbQuery.Append(" ,IS_POPUP ");
                    sbQuery.Append(" ,REG_DATE ");
                    sbQuery.Append(" ,REG_EMP ");
                    sbQuery.Append("  ) VALUES (  ");
                    sbQuery.Append("  @PLT_CODE ");
                    sbQuery.Append(" ,@NG_ID ");
                    sbQuery.Append(" ,@EMP_CODE ");
                    sbQuery.Append(" ,@IS_POPUP ");
                    sbQuery.Append(" ,GETDATE() ");
                    sbQuery.Append(" ,'" + ConnInfo.UserID + "' ");
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

        public static void TSHP_NG_EMP_UPD(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TSHP_NG_EMP SET  ");
                    sbQuery.Append("  IS_POPUP = @IS_POPUP ");
                    sbQuery.Append(" ,MDFY_DATE = GETDATE() ");
                    sbQuery.Append(" ,MDFY_EMP = '" + ConnInfo.UserID + "' ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append("  AND NG_ID = @NG_ID ");
                    sbQuery.Append("  AND EMP_CODE = @EMP_CODE ");
                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "NG_ID")) isHasColumn = false;
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
}
