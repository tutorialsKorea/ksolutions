using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace DLSE
{
    public class LSE_STD_PARTPROC_CONT_DETAIL
    {

        public static DataTable LSE_STD_PARTPROC_CONT_DETAIL_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {

            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("SELECT   PLT_CODE ");
                    sbQuery.Append(" , PROD_CODE     ");
                    sbQuery.Append(" , CONT_CODE     ");
                    sbQuery.Append(" , IS_COMPLETE      ");

                    sbQuery.Append(" FROM LSE_STD_PARTPROC_CONT_DETAIL ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append(" AND PROD_CODE = @PROD_CODE ");
                    sbQuery.Append(" AND CONT_CODE = @CONT_CODE ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PROD_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "CONT_CODE")) isHasColumn = false;

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

        public static void LSE_STD_PARTPROC_CONT_DETAIL_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" INSERT INTO LSE_STD_PARTPROC_CONT_DETAIL ");
                    sbQuery.Append(" ( ");
                    sbQuery.Append("        PLT_CODE    ");
                    sbQuery.Append("      , CONT_CODE     ");
                    sbQuery.Append("      , PROD_CODE     ");
                    sbQuery.Append("      , IS_COMPLETE       ");
                    sbQuery.Append(" ) ");
                    sbQuery.Append(" VALUES ");
                    sbQuery.Append(" ( ");
                    sbQuery.Append("        @PLT_CODE    ");
                    sbQuery.Append("      , @CONT_CODE     ");
                    sbQuery.Append("      , @PROD_CODE     ");
                    sbQuery.Append("      , @IS_COMPLETE       ");
                    sbQuery.Append(" ) ");

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

        public static void LSE_STD_PARTPROC_CONT_DETAIL_UPD(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE LSE_STD_PARTPROC_CONT_DETAIL ");
                    sbQuery.Append(" SET IS_COMPLETE = @IS_COMPLETE ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("   AND CONT_CODE = @CONT_CODE  ");
                    sbQuery.Append("   AND PROD_CODE = @PROD_CODE  ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "CONT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PROD_CODE")) isHasColumn = false;

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
