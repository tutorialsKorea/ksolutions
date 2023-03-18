using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace DMAT
{
    public class TMAT_QUC_MASTER
    {
        public static void TMAT_QUC_MASTER_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {

                StringBuilder sbQuery = new StringBuilder();

                sbQuery.Append(" INSERT INTO TMAT_QUC_MASTER ");
                sbQuery.Append(" ( ");
                sbQuery.Append("        PLT_CODE ");
                sbQuery.Append("      , MQLTY_CODE ");
                sbQuery.Append("      , MQLTY_NAME ");
                sbQuery.Append("      , MQLTY_RANGE ");
                sbQuery.Append("      , MQLTY_WEIGHT ");
                sbQuery.Append("      , UNIT_CONVERT_VALUE ");
                sbQuery.Append("      , SCOMMENT ");
                sbQuery.Append("      , REG_DATE ");
                sbQuery.Append("      , REG_EMP ");
                sbQuery.Append("      , DATA_FLAG ");
                sbQuery.Append(" ) ");
                sbQuery.Append(" VALUES ");
                sbQuery.Append(" ( ");
                sbQuery.Append("        @PLT_CODE ");
                sbQuery.Append("      , @MQLTY_CODE ");
                sbQuery.Append("      , @MQLTY_NAME ");
                sbQuery.Append("      , @MQLTY_RANGE ");
                sbQuery.Append("      , @MQLTY_WEIGHT ");
                sbQuery.Append("      , @UNIT_CONVERT_VALUE ");
                sbQuery.Append("      , @SCOMMENT ");
                sbQuery.Append("      , GETDATE() ");
                sbQuery.Append("      , @REG_EMP ");
                sbQuery.Append("      , @DATA_FLAG ");
                sbQuery.Append(" ) ");

                foreach (DataRow row in dtParam.Rows)
                {

                    bizExecute.executeInsertQuery(sbQuery.ToString(), row);
                }

            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataTable TMAT_QUC_MASTER_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT   PLT_CODE ");
                    sbQuery.Append("        , MQLTY_CODE ");
                    sbQuery.Append("        , MQLTY_NAME ");
                    sbQuery.Append("        , MQLTY_RANGE ");
                    sbQuery.Append("        , MQLTY_WEIGHT ");
                    sbQuery.Append("        , UNIT_CONVERT_VALUE ");
                    sbQuery.Append("        , SCOMMENT ");
                    sbQuery.Append("        , REG_DATE ");
                    sbQuery.Append("        , REG_EMP ");
                    sbQuery.Append("        , MDFY_DATE ");
                    sbQuery.Append("        , MDFY_EMP ");
                    sbQuery.Append("        , DEL_DATE ");
                    sbQuery.Append("        , DEL_EMP ");
                    sbQuery.Append("        , DEL_REASON ");
                    sbQuery.Append("        , DATA_FLAG ");
                    sbQuery.Append("   FROM TMAT_QUC_MASTER ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append("    AND MQLTY_CODE = @MQLTY_CODE ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                       

                        DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString(), row).Copy();

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

        public static void TMAT_QUC_MASTER_DEL(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" DELETE FROM TMAT_QUC_MASTER ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE ");
 
                    foreach (DataRow row in dtParam.Rows)
                    {

                        bizExecute.executeUpdateQuery(sbQuery.ToString(), row);

                    }
                }
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }

        public static void TMAT_QUC_MASTER_UPD(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQUery = new StringBuilder();

                    sbQUery.Append(" UPDATE TMAT_QUC_MASTER ");
                    sbQUery.Append("    SET   MQLTY_NAME = @MQLTY_NAME ");
                    sbQUery.Append("        , MQLTY_RANGE = @MQLTY_RANGE ");
                    sbQUery.Append("        , MQLTY_WEIGHT = @MQLTY_WEIGHT ");
                    sbQUery.Append("        , UNIT_CONVERT_VALUE = @UNIT_CONVERT_VALUE ");
                    sbQUery.Append("        , SCOMMENT = @SCOMMENT ");
                    sbQUery.Append("        , MDFY_DATE = GETDATE() ");
                    sbQUery.Append("        , MDFY_EMP = @MDFY_EMP ");
                    sbQUery.Append("        , DATA_FLAG = @DATA_FLAG ");
                    sbQUery.Append("  WHERE PLT_CODE = @PLT_CODE  ");
                    sbQUery.Append("    AND MQLTY_CODE = @MQLTY_CODE ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bizExecute.executeUpdateQuery(sbQUery.ToString(), row);

                    }
                }
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }

        public static void TMAT_QUC_MASTER_UDE(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {

           try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" UPDATE TMAT_QUC_MASTER ");
                    sbQuery.Append("   SET   DEL_DATE = GETDATE() ");
                    sbQuery.Append("       , DEL_EMP = @DEL_EMP ");
                    sbQuery.Append("       , DEL_REASON = @DEL_REASON ");
                    sbQuery.Append("       , DATA_FLAG = @DATA_FLAG ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("   AND MQLTY_CODE = @MQLTY_CODE ");


                    foreach (DataRow row in dtParam.Rows)
                    {

                        bizExecute.executeUpdateQuery(sbQuery.ToString(), row);

                    }
                }
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }
    }

    public class TMAT_QUC_MASTER_QUERY
    {
        public static DataTable TMAT_QUC_MASTER_QUERY2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                 DataSet dsResult = new DataSet();

                 if (dtParam.Rows.Count > 0)
                 {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT M.PLT_CODE ");
                    sbQuery.Append("       ,M.MQLTY_CODE ");
                    sbQuery.Append("       ,M.MQLTY_NAME ");
                    sbQuery.Append("       ,M.MQLTY_RANGE ");
                    sbQuery.Append("       ,M.MQLTY_WEIGHT ");
                    sbQuery.Append("       ,M.UNIT_CONVERT_VALUE ");
                    sbQuery.Append("       ,M.SCOMMENT ");
                    sbQuery.Append("       ,ISNULL(D.MQLTY_UC, 0) MQLTY_UC ");
                    sbQuery.Append("       ,SYS_VALUE ");
                    sbQuery.Append("   FROM TMAT_QUC_MASTER M ");
                    sbQuery.Append(" LEFT OUTER JOIN TMAT_QUC_DETAIL D  ");
                    sbQuery.Append(" ON M.PLT_CODE = D.PLT_CODE  ");
                    sbQuery.Append(" AND M.MQLTY_CODE = D.MQLTY_CODE ");
                    sbQuery.Append(" AND (CONVERT(nvarchar(8), GETDATE(), 112) BETWEEN D.MQLTY_START AND D.MQLTY_END) ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE M.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                        
                        sbWhere.Append(UTIL.GetWhere(row, "@MQLTY_CODE", "M.MQLTY_CODE = @MQLTY_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@MQLTY_NAME", "M.MQLTY_NAME = @MQLTY_NAME"));
                        sbWhere.Append(UTIL.GetWhere(row, "@MQLTY_LIKE", "(M.MQLTY_CODE LIKE '%' + @MQLTY_LIKE + '%' OR M.MQLTY_NAME LIKE '%' + @MQLTY_LIKE + '%')"));
                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "M.DATA_FLAG = @DATA_FLAG "));
                        

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
        

        public static DataTable TMAT_QUC_MASTER_QUERY3(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                 DataSet dsResult = new DataSet();

                 if (dtParam.Rows.Count > 0)
                 {
                     StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT M.PLT_CODE ");
                    sbQuery.Append("       ,M.MQLTY_CODE ");
                    sbQuery.Append("       ,M.MQLTY_NAME ");
                    sbQuery.Append("       ,M.MQLTY_RANGE ");
                    sbQuery.Append("       ,M.MQLTY_WEIGHT ");
                    sbQuery.Append("       ,M.SCOMMENT ");
                    sbQuery.Append("       ,M.REG_EMP ");
                    sbQuery.Append("       ,REG.EMP_NAME AS REG_EMP_NAME ");
                    sbQuery.Append("       ,M.REG_DATE ");
                    sbQuery.Append("       ,M.MDFY_EMP ");
                    sbQuery.Append("       ,MDFY.EMP_NAME AS MDFY_EMP_NAME ");
                    sbQuery.Append("       ,M.MDFY_DATE ");
                    sbQuery.Append("       ,M.DATA_FLAG ");
                    sbQuery.Append("       ,M.UNIT_CONVERT_VALUE ");
                    sbQuery.Append("       ,M.SYS_VALUE ");
                    sbQuery.Append("   FROM TMAT_QUC_MASTER M ");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE REG ");
                    sbQuery.Append(" ON M.PLT_CODE = REG.PLT_CODE ");
                    sbQuery.Append(" AND M.REG_EMP = REG.EMP_CODE ");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE MDFY ");
                    sbQuery.Append(" ON M.PLT_CODE = MDFY.PLT_CODE ");
                    sbQuery.Append(" AND M.MDFY_EMP = MDFY.EMP_CODE ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE M.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                        
                        if (dtParam.Columns.Contains("MQLTY_CODE")) sbWhere.Append(UTIL.GetWhere(row, "@MQLTY_CODE", "M.MQLTY_CODE = @MQLTY_CODE"));
                        if (dtParam.Columns.Contains("MQLTY_LIKE")) sbWhere.Append(UTIL.GetWhere(row, "@MQLTY_LIKE", "(M.MQLTY_CODE LIKE '%' + @MQLTY_LIKE + '%' OR M.MQLTY_NAME LIKE '%' + @MQLTY_LIKE + '%')"));

                        sbWhere.Append(" AND M.DATA_FLAG = 0");

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
