using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace DIF
{
    public class IF_MES_DWG
    {
        public static DataTable IF_MES_DWG_FILE_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    //sbQuery.Append("  SELECT TOP 1 ");
                    //sbQuery.Append("  PART_NO ");
                    //sbQuery.Append(" ,PART_REV_ID ");
                    //sbQuery.Append(" ,PART_DIVISION ");
                    //sbQuery.Append(" ,PART_FILE_PATH ");
                    //sbQuery.Append(" ,PART_FILE_NAME ");
                    //sbQuery.Append(" ,IF_REGDATE ");
                    //sbQuery.Append(" ,IF_RULT ");
                    //sbQuery.Append(" ,IF_MSG ");
                    //sbQuery.Append(" ,PART_PUID ");
                    //sbQuery.Append(" ,PART_DRIVER ");
                    //sbQuery.Append("  FROM IF_MES_DWG_FILE  ");
                    //sbQuery.Append("  WHERE  ");
                    //sbQuery.Append(" CASE WHEN CHARINDEX('.', PART_FILE_NAME, 0) > 0 THEN SUBSTRING(PART_FILE_NAME, 0, CHARINDEX('.', PART_FILE_NAME, 0))");
                    //sbQuery.Append(" ELSE PART_FILE_NAME END = @PART_NO");
                    //sbQuery.Append(" ORDER BY IF_REGDATE DESC");
                    sbQuery.Append(" SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED");
                    sbQuery.Append(" SELECT");
                    sbQuery.Append(" FILE_SEQ");
                    sbQuery.Append(" ,PART_NO");
                    sbQuery.Append(" ,PART_REV_ID");
                    sbQuery.Append(" ,PART_DIVISION");
                    sbQuery.Append(" ,PART_FILE_PATH");
                    sbQuery.Append(" ,PART_FILE_NAME");
                    sbQuery.Append(" ,IF_REGDATE");
                    sbQuery.Append(" ,IF_RULT");
                    sbQuery.Append(" ,IF_MSG");
                    sbQuery.Append(" ,PART_PUID");
                    sbQuery.Append(" ,PART_DRIVER");
                    sbQuery.Append(" ,PART_PATH");
                    sbQuery.Append(" FROM");
                    sbQuery.Append(" (");
                    sbQuery.Append(" SELECT");
                    sbQuery.Append(" ROW_NUMBER() OVER (PARTITION BY SUBSTRING(PART_FILE_PATH, LEN(PART_FILE_PATH) - CHARINDEX('.', REVERSE(PART_FILE_PATH), 0) + 2, LEN(PART_FILE_PATH) - (LEN(PART_FILE_PATH) - CHARINDEX('.', REVERSE(PART_FILE_PATH), 0) + 1)) ORDER BY IF_REGDATE DESC) AS FILE_SEQ");
                    sbQuery.Append(" ,PART_NO");
                    sbQuery.Append(" ,PART_REV_ID");
                    sbQuery.Append(" ,PART_DIVISION");
                    sbQuery.Append(" ,PART_FILE_PATH");
                    sbQuery.Append(" ,PART_FILE_NAME");
                    sbQuery.Append(" ,IF_REGDATE");
                    sbQuery.Append(" ,IF_RULT");
                    sbQuery.Append(" ,IF_MSG");
                    sbQuery.Append(" ,PART_PUID");
                    sbQuery.Append(" ,PART_DRIVER");
                    sbQuery.Append(" ,SUBSTRING(PART_FILE_PATH, 0, len(PART_FILE_PATH) - CHARINDEX('\\', REVERSE(PART_FILE_PATH), 0) + 1) AS PART_PATH");
                    sbQuery.Append(" FROM IF_MES_DWG_FILE");
                    sbQuery.Append(" WHERE");
                    sbQuery.Append(" CASE WHEN CHARINDEX('.', PART_FILE_NAME, 0) > 0 THEN SUBSTRING(PART_FILE_NAME, 0, CHARINDEX('.', PART_FILE_NAME, 0))");
                    sbQuery.Append(" ELSE PART_FILE_NAME END = @PART_NO");
                    sbQuery.Append(" AND PART_FILE_PATH LIKE '%' + @PART_NO + '%'");
                    sbQuery.Append(" ) A");
                    sbQuery.Append(" WHERE FILE_SEQ = 1");
                    sbQuery.Append(" AND SUBSTRING(PART_FILE_PATH, LEN(PART_FILE_PATH) - CHARINDEX('.', REVERSE(PART_FILE_PATH), 0) + 2, LEN(PART_FILE_PATH) - (LEN(PART_FILE_PATH) - CHARINDEX('.', REVERSE(PART_FILE_PATH), 0) + 1)) = @FILE_TYPE");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;
                        if (!UTIL.ValidColumn(row, "PART_NO")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "FILE_TYPE")) isHasColumn = false;

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

        public static DataTable IF_MES_DWG_FILE_SER2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    //sbQuery.Append("  SELECT TOP 1 ");
                    //sbQuery.Append("  PART_NO ");
                    //sbQuery.Append(" ,PART_REV_ID ");
                    //sbQuery.Append(" ,PART_DIVISION ");
                    //sbQuery.Append(" ,PART_FILE_PATH ");
                    //sbQuery.Append(" ,PART_FILE_NAME ");
                    //sbQuery.Append(" ,IF_REGDATE ");
                    //sbQuery.Append(" ,IF_RULT ");
                    //sbQuery.Append(" ,IF_MSG ");
                    //sbQuery.Append(" ,PART_PUID ");
                    //sbQuery.Append(" ,PART_DRIVER ");
                    //sbQuery.Append("  FROM IF_MES_DWG_FILE  ");
                    //sbQuery.Append("  WHERE  ");
                    //sbQuery.Append(" CASE WHEN CHARINDEX('.', PART_FILE_NAME, 0) > 0 THEN SUBSTRING(PART_FILE_NAME, 0, CHARINDEX('.', PART_FILE_NAME, 0))");
                    //sbQuery.Append(" ELSE PART_FILE_NAME END = @PART_NO");
                    //sbQuery.Append(" ORDER BY IF_REGDATE DESC");
                    sbQuery.Append(" SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED");
                    sbQuery.Append(" SELECT");
                    sbQuery.Append(" FILE_SEQ");
                    sbQuery.Append(" ,PART_NO");

                    sbQuery.Append(" ,CASE WHEN CHARINDEX('.', PART_FILE_NAME, 0) > 0 THEN SUBSTRING(PART_FILE_NAME, 0, CHARINDEX('.', PART_FILE_NAME, 0))");
                    sbQuery.Append(" ELSE PART_FILE_NAME END AS PART_CODE");

                    sbQuery.Append(" ,PART_REV_ID");
                    sbQuery.Append(" ,PART_DIVISION");
                    sbQuery.Append(" ,PART_FILE_PATH");
                    sbQuery.Append(" ,PART_FILE_NAME");
                    sbQuery.Append(" ,IF_REGDATE");
                    sbQuery.Append(" ,IF_RULT");
                    sbQuery.Append(" ,IF_MSG");
                    sbQuery.Append(" ,PART_PUID");
                    sbQuery.Append(" ,PART_DRIVER");
                    sbQuery.Append(" ,FILE_TYPE");
                    sbQuery.Append(" ,PART_PATH");
                    sbQuery.Append(" FROM");
                    sbQuery.Append(" (");
                    sbQuery.Append(" SELECT");
                    sbQuery.Append(" ROW_NUMBER() OVER (PARTITION BY SUBSTRING(PART_FILE_PATH, LEN(PART_FILE_PATH) - CHARINDEX('.', REVERSE(PART_FILE_PATH), 0) + 2, LEN(PART_FILE_PATH) - (LEN(PART_FILE_PATH) - CHARINDEX('.', REVERSE(PART_FILE_PATH), 0) + 1)) ORDER BY IF_REGDATE DESC) AS FILE_SEQ");
                    sbQuery.Append(" ,PART_NO");
                    sbQuery.Append(" ,PART_REV_ID");
                    sbQuery.Append(" ,PART_DIVISION");
                    sbQuery.Append(" ,PART_FILE_PATH");
                    sbQuery.Append(" ,PART_FILE_NAME");
                    sbQuery.Append(" ,IF_REGDATE");
                    sbQuery.Append(" ,IF_RULT");
                    sbQuery.Append(" ,IF_MSG");
                    sbQuery.Append(" ,PART_PUID");
                    sbQuery.Append(" ,PART_DRIVER");
                    sbQuery.Append(" ,SUBSTRING(PART_FILE_PATH, LEN(PART_FILE_PATH) - CHARINDEX('.', REVERSE(PART_FILE_PATH), 0) + 2, LEN(PART_FILE_PATH) - (LEN(PART_FILE_PATH) - CHARINDEX('.', REVERSE(PART_FILE_PATH), 0) + 1)) AS FILE_TYPE");
                    sbQuery.Append(" ,SUBSTRING(PART_FILE_PATH, 0, len(PART_FILE_PATH) - CHARINDEX('\\', REVERSE(PART_FILE_PATH), 0) + 1) AS PART_PATH");
                    sbQuery.Append(" FROM IF_MES_DWG_FILE");
                    sbQuery.Append(" WHERE");
                    sbQuery.Append(" CASE WHEN CHARINDEX('.', PART_FILE_NAME, 0) > 0 THEN SUBSTRING(PART_FILE_NAME, 0, CHARINDEX('.', PART_FILE_NAME, 0))");
                    sbQuery.Append(" ELSE PART_FILE_NAME END = @PART_NO");
                    sbQuery.Append(" AND PART_FILE_PATH LIKE '%' + @PART_NO + '%'");
                    sbQuery.Append(" ) A");
                    sbQuery.Append(" WHERE FILE_SEQ = 1");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;
                        if (!UTIL.ValidColumn(row, "PART_NO")) isHasColumn = false;

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

        public static DataTable IF_MES_DWG_FILE_SER3(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED");
                    sbQuery.Append(" SELECT");
                    sbQuery.Append(" FILE_SEQ");
                    sbQuery.Append(" ,PART_NO");
                    sbQuery.Append(" ,PART_REV_ID");
                    sbQuery.Append(" ,PART_DIVISION");
                    sbQuery.Append(" ,PART_FILE_PATH");
                    sbQuery.Append(" ,PART_FILE_NAME");
                    sbQuery.Append(" ,IF_REGDATE");
                    sbQuery.Append(" ,IF_RULT");
                    sbQuery.Append(" ,IF_MSG");
                    sbQuery.Append(" ,PART_PUID");
                    sbQuery.Append(" ,PART_DRIVER");
                    sbQuery.Append(" ,PART_PATH");
                    sbQuery.Append(" FROM");
                    sbQuery.Append(" (");
                    sbQuery.Append(" SELECT");
                    sbQuery.Append(" ROW_NUMBER() OVER (PARTITION BY SUBSTRING(PART_FILE_PATH, LEN(PART_FILE_PATH) - CHARINDEX('.', REVERSE(PART_FILE_PATH), 0) + 2, LEN(PART_FILE_PATH) - (LEN(PART_FILE_PATH) - CHARINDEX('.', REVERSE(PART_FILE_PATH), 0) + 1)) ORDER BY IF_REGDATE DESC) AS FILE_SEQ");
                    sbQuery.Append(" ,PART_NO");
                    sbQuery.Append(" ,PART_REV_ID");
                    sbQuery.Append(" ,PART_DIVISION");
                    sbQuery.Append(" ,PART_FILE_PATH");
                    sbQuery.Append(" ,PART_FILE_NAME");
                    sbQuery.Append(" ,IF_REGDATE");
                    sbQuery.Append(" ,IF_RULT");
                    sbQuery.Append(" ,IF_MSG");
                    sbQuery.Append(" ,PART_PUID");
                    sbQuery.Append(" ,PART_DRIVER");
                    sbQuery.Append(" ,SUBSTRING(PART_FILE_PATH, 0, len(PART_FILE_PATH) - CHARINDEX('\\', REVERSE(PART_FILE_PATH), 0) + 1) AS PART_PATH");
                    sbQuery.Append(" FROM IF_MES_DWG_FILE");
                    sbQuery.Append(" WHERE");
                    sbQuery.Append(" PART_FILE_PATH LIKE '%' + @PART_PATH_LIKE + '%'");
                    sbQuery.Append(" ) A");
                    sbQuery.Append(" WHERE FILE_SEQ = 1");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;
                        if (!UTIL.ValidColumn(row, "PART_PATH_LIKE")) isHasColumn = false;

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

        public static DataTable IF_MES_DWG_FILE_SER4(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED");
                    sbQuery.Append(" SELECT");
                    sbQuery.Append(" FILE_SEQ");
                    sbQuery.Append(" ,PART_NO");
                    sbQuery.Append(" ,PART_REV_ID");
                    sbQuery.Append(" ,PART_DIVISION");
                    sbQuery.Append(" ,PART_FILE_PATH");
                    sbQuery.Append(" ,PART_FILE_NAME");
                    sbQuery.Append(" ,IF_REGDATE");
                    sbQuery.Append(" ,IF_RULT");
                    sbQuery.Append(" ,IF_MSG");
                    sbQuery.Append(" ,PART_PUID");
                    sbQuery.Append(" ,PART_DRIVER");
                    sbQuery.Append(" ,PART_PATH");
                    sbQuery.Append(" FROM");
                    sbQuery.Append(" (");
                    sbQuery.Append(" SELECT");
                    sbQuery.Append(" ROW_NUMBER() OVER (PARTITION BY SUBSTRING(PART_FILE_PATH, LEN(PART_FILE_PATH) - CHARINDEX('.', REVERSE(PART_FILE_PATH), 0) + 2, LEN(PART_FILE_PATH) - (LEN(PART_FILE_PATH) - CHARINDEX('.', REVERSE(PART_FILE_PATH), 0) + 1)) ORDER BY IF_REGDATE DESC) AS FILE_SEQ");
                    sbQuery.Append(" ,PART_NO");
                    sbQuery.Append(" ,PART_REV_ID");
                    sbQuery.Append(" ,PART_DIVISION");
                    sbQuery.Append(" ,PART_FILE_PATH");
                    sbQuery.Append(" ,PART_FILE_NAME");
                    sbQuery.Append(" ,IF_REGDATE");
                    sbQuery.Append(" ,IF_RULT");
                    sbQuery.Append(" ,IF_MSG");
                    sbQuery.Append(" ,PART_PUID");
                    sbQuery.Append(" ,PART_DRIVER");
                    sbQuery.Append(" ,SUBSTRING(PART_FILE_PATH, 0, len(PART_FILE_PATH) - CHARINDEX('\\', REVERSE(PART_FILE_PATH), 0) + 1) AS PART_PATH");
                    sbQuery.Append(" FROM IF_MES_DWG_FILE");
                    sbQuery.Append(" WHERE");
                    sbQuery.Append(" PART_FILE_PATH LIKE '%' + @PART_PATH_LIKE + '%'");
                    sbQuery.Append(" ) A");
                    sbQuery.Append(" WHERE FILE_SEQ = 1");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;
                        if (!UTIL.ValidColumn(row, "PART_PATH_LIKE")) isHasColumn = false;

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

        public static DataTable IF_MES_DWG_FILE_SER5(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED");
                    sbQuery.Append(" SELECT");
                    sbQuery.Append(" PART_NO");
                    sbQuery.Append(" ,FILE_TYPE");
                    sbQuery.Append(" FROM");
                    sbQuery.Append(" (");
                    sbQuery.Append(" SELECT");
                    sbQuery.Append(" ROW_NUMBER() OVER (PARTITION BY PART_NO, SUBSTRING(PART_FILE_PATH, LEN(PART_FILE_PATH) - CHARINDEX('.', REVERSE(PART_FILE_PATH), 0) + 2, LEN(PART_FILE_PATH) - (LEN(PART_FILE_PATH) - CHARINDEX('.', REVERSE(PART_FILE_PATH), 0) + 1)) ORDER BY IF_REGDATE DESC) AS FILE_SEQ");
                    sbQuery.Append(" ,*");
                    sbQuery.Append(" FROM");
                    sbQuery.Append(" (");
                    sbQuery.Append(" SELECT");
                    sbQuery.Append(" PART_NO");
                    sbQuery.Append(" ,SUBSTRING(PART_FILE_PATH, LEN(PART_FILE_PATH) - CHARINDEX('.', REVERSE(PART_FILE_PATH), 0) + 2, LEN(PART_FILE_PATH) - (LEN(PART_FILE_PATH) - CHARINDEX('.', REVERSE(PART_FILE_PATH), 0) + 1)) AS FILE_TYPE");
                    sbQuery.Append(" ,IF_REGDATE");
                    sbQuery.Append(" ,PART_FILE_PATH");
                    sbQuery.Append(" FROM IF_MES_DWG_FILE");
                    sbQuery.Append(" WHERE PART_FILE_PATH LIKE '%' + PART_NO + '%'");
                    sbQuery.Append(" UNION ALL");
                    sbQuery.Append(" SELECT");
                    sbQuery.Append(" LINK_KEY");
                    sbQuery.Append(" ,SUBSTRING(FILE_NAME, LEN(FILE_NAME) - CHARINDEX('.', REVERSE(FILE_NAME), 0) + 2, LEN(FILE_NAME) - (LEN(FILE_NAME) - CHARINDEX('.', REVERSE(FILE_NAME), 0) + 1)) AS FILE_TYPE");
                    sbQuery.Append(" ,REG_DATE");
                    sbQuery.Append(" ,FILE_NAME");
                    sbQuery.Append(" FROM TSYS_FILELIST_MASTER");
                    sbQuery.Append(" WHERE UPLOAD_MENU = 'PLN13A'");
                    sbQuery.Append(" AND DATA_FLAG = '0' AND IS_UPLOAD = '1'");
                    sbQuery.Append(" ) D");
                    sbQuery.Append(" ) DWG");
                    sbQuery.Append(" WHERE FILE_SEQ = 1");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

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

        public static DataTable IF_MES_DWG_FILE_SER6(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED");
                    sbQuery.Append(" SELECT");
                    sbQuery.Append(" PART_NO");
                    sbQuery.Append(" ,FILE_TYPE");
                    sbQuery.Append(" FROM");
                    sbQuery.Append(" (");
                    sbQuery.Append(" SELECT");
                    sbQuery.Append(" ROW_NUMBER() OVER (PARTITION BY PART_NO, SUBSTRING(PART_FILE_PATH, LEN(PART_FILE_PATH) - CHARINDEX('.', REVERSE(PART_FILE_PATH), 0) + 2, LEN(PART_FILE_PATH) - (LEN(PART_FILE_PATH) - CHARINDEX('.', REVERSE(PART_FILE_PATH), 0) + 1)) ORDER BY IF_REGDATE DESC) AS FILE_SEQ");
                    sbQuery.Append(" ,*");
                    sbQuery.Append(" FROM");
                    sbQuery.Append(" (");
                    sbQuery.Append(" SELECT");
                    sbQuery.Append(" PART_NO");
                    sbQuery.Append(" ,SUBSTRING(PART_FILE_PATH, LEN(PART_FILE_PATH) - CHARINDEX('.', REVERSE(PART_FILE_PATH), 0) + 2, LEN(PART_FILE_PATH) - (LEN(PART_FILE_PATH) - CHARINDEX('.', REVERSE(PART_FILE_PATH), 0) + 1)) AS FILE_TYPE");
                    sbQuery.Append(" ,IF_REGDATE");
                    sbQuery.Append(" ,PART_FILE_PATH");
                    sbQuery.Append(" FROM IF_MES_DWG_FILE");
                    sbQuery.Append(" WHERE PART_FILE_PATH LIKE '%' + PART_NO + '%'");
                    sbQuery.Append(" AND PART_FILE_PATH LIKE '%' + @ASSY_CODE + '%'");
                    sbQuery.Append(" UNION ALL");
                    sbQuery.Append(" SELECT");
                    sbQuery.Append(" LINK_KEY");
                    sbQuery.Append(" ,SUBSTRING(FILE_NAME, LEN(FILE_NAME) - CHARINDEX('.', REVERSE(FILE_NAME), 0) + 2, LEN(FILE_NAME) - (LEN(FILE_NAME) - CHARINDEX('.', REVERSE(FILE_NAME), 0) + 1)) AS FILE_TYPE");
                    sbQuery.Append(" ,REG_DATE");
                    sbQuery.Append(" ,FILE_NAME");
                    sbQuery.Append(" FROM TSYS_FILELIST_MASTER");
                    sbQuery.Append(" WHERE UPLOAD_MENU = 'PLN13A'");
                    sbQuery.Append(" AND DATA_FLAG = '0' AND IS_UPLOAD = '1'");
                    sbQuery.Append(" ) D");
                    sbQuery.Append(" ) DWG");
                    sbQuery.Append(" WHERE FILE_SEQ = 1");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

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
    }

    public class IF_MES_DWG_QUERY
    {
          
    }

}
