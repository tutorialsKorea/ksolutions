using BizExecute;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DORD
{
    public class TORD_PRODUCT_SEND_DEV
    {
        public static DataTable TORD_PRODUCT_SEND_DEV_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("  SELECT  ");
                    sbQuery.Append("  PLT_CODE ");
                    sbQuery.Append(" ,SEND_NO ");
                    sbQuery.Append(" ,EMP_CODE ");
                    sbQuery.Append(" ,PROD_CODE ");
                    sbQuery.Append(" ,PROD_NAME ");
                    sbQuery.Append(" ,PROD_FLAG ");
                    sbQuery.Append(" ,PROD_TYPE ");
                    sbQuery.Append(" ,CUSTDESIGN_EMP ");
                    sbQuery.Append(" ,BUSINESS_EMP ");
                    sbQuery.Append(" ,CVND_NAME ");
                    sbQuery.Append(" ,PROD_QTY ");
                    sbQuery.Append(" ,REG_DATE ");
                    sbQuery.Append("  FROM TORD_PRODUCT_SEND_DEV  ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("  AND SEND_NO = @SEND_NO  ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "SEND_NO")) isHasColumn = false;

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

        public static DataTable TORD_PRODUCT_SEND_DEV_SER2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("  SELECT  ");
                    sbQuery.Append("  PLT_CODE ");
                    sbQuery.Append(" ,SEND_NO ");
                    sbQuery.Append(" ,EMP_CODE ");
                    sbQuery.Append(" ,PROD_CODE ");
                    sbQuery.Append(" ,PROD_NAME ");
                    sbQuery.Append(" ,PROD_FLAG ");
                    sbQuery.Append(" ,PROD_TYPE ");
                    sbQuery.Append(" ,CUSTDESIGN_EMP ");
                    sbQuery.Append(" ,BUSINESS_EMP ");
                    sbQuery.Append(" ,CVND_NAME ");
                    sbQuery.Append(" ,PROD_QTY ");
                    sbQuery.Append(" ,REG_DATE ");
                    sbQuery.Append("  FROM TORD_PRODUCT_SEND_DEV  ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("  AND EMP_CODE = @EMP_CODE  ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
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

        public static void TORD_PRODUCT_SEND_DEV_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" INSERT INTO TORD_PRODUCT_SEND_DEV (  ");
                    sbQuery.Append("  PLT_CODE ");
                    sbQuery.Append(" ,SEND_NO ");
                    sbQuery.Append(" ,EMP_CODE ");
                    sbQuery.Append(" ,PROD_CODE ");
                    sbQuery.Append(" ,PROD_NAME ");
                    sbQuery.Append(" ,PROD_FLAG ");
                    sbQuery.Append(" ,PROD_TYPE ");
                    sbQuery.Append(" ,CUSTDESIGN_EMP ");
                    sbQuery.Append(" ,BUSINESS_EMP ");
                    sbQuery.Append(" ,CVND_NAME ");
                    sbQuery.Append(" ,PROD_QTY ");
                    sbQuery.Append(" ,REG_DATE ");
                    sbQuery.Append("  ) VALUES (  ");
                    sbQuery.Append("  @PLT_CODE ");
                    sbQuery.Append(" ,@SEND_NO ");
                    sbQuery.Append(" ,@EMP_CODE ");
                    sbQuery.Append(" ,@PROD_CODE ");
                    sbQuery.Append(" ,@PROD_NAME ");
                    sbQuery.Append(" ,@PROD_FLAG ");
                    sbQuery.Append(" ,@PROD_TYPE ");
                    sbQuery.Append(" ,@CUSTDESIGN_EMP ");
                    sbQuery.Append(" ,@BUSINESS_EMP ");
                    sbQuery.Append(" ,@CVND_NAME ");
                    sbQuery.Append(" ,@PROD_QTY ");
                    sbQuery.Append(" ,GETDATE() ");
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

        public static void TORD_PRODUCT_SEND_DEV_DEL(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" DELETE FROM TORD_PRODUCT_SEND_DEV  ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append("  AND SEND_NO = @SEND_NO ");
                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "SEND_NO")) isHasColumn = false;

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
