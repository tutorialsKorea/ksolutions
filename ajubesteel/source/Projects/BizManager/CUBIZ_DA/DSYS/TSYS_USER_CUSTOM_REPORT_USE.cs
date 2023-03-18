using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace DSYS
{
    public class TSYS_USER_CUSTOM_REPORT_USE
    {
        public static bool TSYS_USER_CUSTOM_REPORT_USE_CREATE(BizExecute.BizExecute bizExecute)
        {

            try
            {
                DataSet dsResult = new DataSet();

                StringBuilder sbQuery = new StringBuilder();
                sbQuery.AppendLine(" IF NOT EXISTS ( ");
                sbQuery.AppendLine("  SELECT * FROM INFORMATION_SCHEMA.tables WITH(NOLOCK) WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'TSYS_USER_CUSTOM_REPORT_USE' ) ");
                sbQuery.AppendLine("  exec(' ");
                sbQuery.AppendLine(" 	CREATE TABLE TSYS_USER_CUSTOM_REPORT_USE ");
                sbQuery.AppendLine(" 	( ");
                sbQuery.AppendLine(" 		PLT_CODE VARCHAR(3) ");
                sbQuery.AppendLine(" 		,CUS_ID VARCHAR(20) ");
                sbQuery.AppendLine(" 		, EMP_CODE VARCHAR(10) ");
                sbQuery.AppendLine(" 	) ");
                sbQuery.AppendLine("  ') ");

                return bizExecute.executeInsertQuery(sbQuery.ToString());
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataTable TSYS_USER_CUSTOM_REPORT_USE_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {

            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.AppendLine(" SELECT RE.PLT_CODE ");
                    sbQuery.AppendLine(" , RE.CUS_ID");
                    sbQuery.AppendLine(" , RM.CLASS_NAME ");
                    sbQuery.AppendLine(" , RM.CONTROL_NAME");
                    sbQuery.AppendLine(" , RM.EXPORT_TYPE");
                    sbQuery.AppendLine(" , RE.EMP_CODE AS REG_EMP");
                    sbQuery.AppendLine(" , EMP.EMP_NAME");
                    sbQuery.AppendLine(" , RM.FILE_NAME ");
                    sbQuery.AppendLine(" , RM.REG_DATE");
                    sbQuery.AppendLine(" FROM TSYS_USER_CUSTOM_REPORT_USE RE");
                    sbQuery.AppendLine("    INNER JOIN TSYS_USER_CUSTOM_REPORT RM ");
                    sbQuery.AppendLine("   	    ON RE.PLT_CODE = RM.PLT_CODE  ");
                    sbQuery.AppendLine("   	    AND RE.CUS_ID = RM.CUS_ID  ");
                    sbQuery.AppendLine("    LEFT JOIN TSTD_EMPLOYEE EMP ");
                    sbQuery.AppendLine("        ON RE.PLT_CODE = EMP.PLT_CODE ");
                    sbQuery.AppendLine("        AND RE.EMP_CODE = EMP.EMP_CODE ");
                    sbQuery.AppendLine(" WHERE RE.PLT_CODE = @PLT_CODE");
                    sbQuery.AppendLine(" AND RE.EMP_CODE = @EMP_CODE");
                    sbQuery.AppendLine(" AND RM.CLASS_NAME = @CLASS_NAME");
                    sbQuery.AppendLine(" AND RM.CONTROL_NAME = @CONTROL_NAME");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "EMP_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "CLASS_NAME")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "CONTROL_NAME")) isHasColumn = false;

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

        public static void TSYS_USER_CUSTOM_REPORT_USE_DEL(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.AppendLine("DELETE FROM TSYS_USER_CUSTOM_REPORT_USE");
                    sbQuery.AppendLine(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.AppendLine(" AND CUS_ID = @CUS_ID");
                    sbQuery.AppendLine(" AND EMP_CODE = @EMP_CODE");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "CUS_ID")) isHasColumn = false;
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

        public static void TSYS_USER_CUSTOM_REPORT_USE_DEL2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.AppendLine(" DELETE U");
                    sbQuery.AppendLine(" FROM TSYS_USER_CUSTOM_REPORT_USE U");
                    sbQuery.AppendLine(" 	INNER JOIN TSYS_USER_CUSTOM_REPORT RM");
                    sbQuery.AppendLine(" 		ON U.PLT_CODE = RM.PLT_CODE");
                    sbQuery.AppendLine(" 		AND U.CUS_ID = RM.CUS_ID");
                    sbQuery.AppendLine(" WHERE U.PLT_CODE = @PLT_CODE");
                    sbQuery.AppendLine(" 	AND U.EMP_CODE = @EMP_CODE");
                    sbQuery.AppendLine(" 	AND RM.CLASS_NAME = @CLASS_NAME");
                    sbQuery.AppendLine(" 	AND RM.CONTROL_NAME = @CONTROL_NAME");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "CUS_ID")) isHasColumn = false;
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

        public static void TSYS_USER_CUSTOM_REPORT_USE_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.AppendLine(" INSERT INTO TSYS_USER_CUSTOM_REPORT_USE");
                    sbQuery.AppendLine(" (");
                    sbQuery.AppendLine(" PLT_CODE ");
                    sbQuery.AppendLine(" , CUS_ID ");
                    sbQuery.AppendLine(" , EMP_CODE ");
                    sbQuery.AppendLine(" )");
                    sbQuery.AppendLine(" VALUES ");
                    sbQuery.AppendLine(" (");
                    sbQuery.AppendLine(" @PLT_CODE ");
                    sbQuery.AppendLine(" , @CUS_ID ");
                    sbQuery.AppendLine(" , @EMP_CODE ");
                    sbQuery.AppendLine(") ");

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
    }
}
