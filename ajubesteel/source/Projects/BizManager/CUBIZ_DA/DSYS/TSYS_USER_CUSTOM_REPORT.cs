using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace DSYS
{
    public class TSYS_USER_CUSTOM_REPORT
    {
        public static bool TSYS_USER_CUSTOM_REPORT_CREATE(BizExecute.BizExecute bizExecute)
        {

            try
            {
                DataSet dsResult = new DataSet();

                StringBuilder sbQuery = new StringBuilder();
                sbQuery.AppendLine(" IF NOT EXISTS ( ");
                sbQuery.AppendLine("  SELECT * FROM INFORMATION_SCHEMA.tables WITH(NOLOCK) WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'TSYS_USER_CUSTOM_REPORT' ) ");
                sbQuery.AppendLine("  exec(' ");
                sbQuery.AppendLine(" 	CREATE TABLE TSYS_USER_CUSTOM_REPORT ");
                sbQuery.AppendLine(" 	( ");
                sbQuery.AppendLine(" 		PLT_CODE VARCHAR(3) ");
                sbQuery.AppendLine(" 		,CUS_ID VARCHAR(20) ");
                sbQuery.AppendLine(" 		, CLASS_NAME VARCHAR(20) ");
                sbQuery.AppendLine(" 		, CONTROL_NAME VARCHAR(30) ");
                sbQuery.AppendLine(" 		, EXPORT_TYPE VARCHAR(10) ");
                sbQuery.AppendLine(" 		, EMP_CODE VARCHAR(10) ");
                sbQuery.AppendLine(" 		, FILE_NAME VARCHAR(60) ");
                sbQuery.AppendLine(" 		, FILE_DATA VARBINARY(MAX) ");
                sbQuery.AppendLine(" 		, REG_DATE DATETIME ");
                sbQuery.AppendLine(" 		,CONSTRAINT PRI_TSYS_USER_CUSTOM_REPORT_PC PRIMARY KEY (PLT_CODE,CUS_ID) ");
                sbQuery.AppendLine(" 	) ");
                sbQuery.AppendLine("  ') ");
                //sbQuery.AppendLine("  GO ");
                //sbQuery.AppendLine(" GO ");

                return bizExecute.executeInsertQuery(sbQuery.ToString());
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataTable TSYS_USER_CUSTOM_REPORT_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {

            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.AppendLine(" SELECT PLT_CODE ");
                    sbQuery.AppendLine(" , CUS_ID");
                    sbQuery.AppendLine(" , CLASS_NAME ");
                    sbQuery.AppendLine(" , CONTROL_NAME");
                    sbQuery.AppendLine(" , EXPORT_TYPE");
                    sbQuery.AppendLine(" , EMP_CODE");
                    sbQuery.AppendLine(" , FILE_NAME ");
                    sbQuery.AppendLine(" , FILE_DATA ");
                    sbQuery.AppendLine(" , REG_DATE");
                    sbQuery.AppendLine(" FROM TSYS_USER_CUSTOM_REPORT");
                    sbQuery.AppendLine(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.AppendLine(" AND CUS_ID = @CUS_ID");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "CUS_ID")) isHasColumn = false;

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

        public static DataTable TSYS_USER_CUSTOM_REPORT_SER2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {

            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.AppendLine(" SELECT RE.PLT_CODE ");
                    sbQuery.AppendLine(" , RE.CUS_ID");
                    sbQuery.AppendLine(" , RE.CLASS_NAME ");
                    sbQuery.AppendLine(" , RE.CONTROL_NAME");
                    sbQuery.AppendLine(" , RE.EXPORT_TYPE");
                    sbQuery.AppendLine(" , RE.EMP_CODE");
                    sbQuery.AppendLine(" , EMP.EMP_NAME");
                    sbQuery.AppendLine(" , RE.FILE_NAME ");
                    sbQuery.AppendLine(" , RE.REG_DATE");
                    sbQuery.AppendLine(" FROM TSYS_USER_CUSTOM_REPORT RE");
                    sbQuery.AppendLine("    LEFT JOIN TSTD_EMPLOYEE EMP ");
                    sbQuery.AppendLine("        ON RE.PLT_CODE = EMP.PLT_CODE ");
                    sbQuery.AppendLine("        AND RE.EMP_CODE = EMP.EMP_CODE ");
                    sbQuery.AppendLine(" WHERE RE.PLT_CODE = @PLT_CODE");
                    sbQuery.AppendLine(" AND RE.CLASS_NAME = @CLASS_NAME");
                    sbQuery.AppendLine(" AND RE.CONTROL_NAME = @CONTROL_NAME");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
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

        public static void TSYS_USER_CUSTOM_REPORT_DEL(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.AppendLine("DELETE FROM TSYS_USER_CUSTOM_REPORT");
                    sbQuery.AppendLine(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.AppendLine(" AND CUS_ID = @CUS_ID");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "CUS_ID")) isHasColumn = false;

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

        public static void TSYS_USER_CUSTOM_REPORT_DEL2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.AppendLine("DELETE FROM TSYS_USER_CUSTOM_REPORT");
                    sbQuery.AppendLine(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.AppendLine(" AND CLASS_NAME = @CLASS_NAME");
                    sbQuery.AppendLine(" AND CONTROL_NAME = @CONTROL_NAME");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "CLASS_NAME")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "CONTROL_NAME")) isHasColumn = false;

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

        public static void TSYS_USER_CUSTOM_REPORT_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.AppendLine(" INSERT INTO TSYS_USER_CUSTOM_REPORT");
                    sbQuery.AppendLine(" (");
                    sbQuery.AppendLine(" PLT_CODE ");
                    sbQuery.AppendLine(" , CUS_ID ");
                    sbQuery.AppendLine(" , CLASS_NAME");
                    sbQuery.AppendLine(" , CONTROL_NAME ");
                    sbQuery.AppendLine(" , EXPORT_TYPE");
                    sbQuery.AppendLine(" , EMP_CODE ");
                    sbQuery.AppendLine(" , FILE_NAME");
                    sbQuery.AppendLine(" , FILE_DATA");
                    sbQuery.AppendLine(" , REG_DATE");
                    sbQuery.AppendLine(" )");
                    sbQuery.AppendLine(" VALUES ");
                    sbQuery.AppendLine(" (");
                    sbQuery.AppendLine(" @PLT_CODE ");
                    sbQuery.AppendLine(" , @CUS_ID ");
                    sbQuery.AppendLine(" , @CLASS_NAME");
                    sbQuery.AppendLine(" , @CONTROL_NAME ");
                    sbQuery.AppendLine(" , @EXPORT_TYPE");
                    sbQuery.AppendLine(" , @EMP_CODE ");
                    sbQuery.AppendLine(" , @FILE_NAME");
                    sbQuery.AppendLine(" , @FILE_DATA");
                    sbQuery.AppendLine(" , GETDATE()");
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


        public static void TSYS_USER_CUSTOM_REPORT_UPD(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.AppendLine(" UPDATE TSYS_USER_CUSTOM_REPORT");
                    sbQuery.AppendLine(" SET REG_DATE = GETDATE()");
                    sbQuery.AppendLine(" , EXPORT_TYPE = @EXPORT_TYPE");
                    sbQuery.AppendLine(" , FILE_DATA = @FILE_DATA");
                    sbQuery.AppendLine(" , FILE_NAME = @FILE_NAME");
                    sbQuery.AppendLine(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.AppendLine(" AND CUS_ID = @CUS_ID");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "CUS_ID")) isHasColumn = false;

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
