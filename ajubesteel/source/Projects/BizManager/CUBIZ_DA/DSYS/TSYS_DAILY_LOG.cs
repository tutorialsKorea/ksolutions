using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace DSYS
{
    public class TSYS_DAILY_LOG
    {
        public static DataTable TSYS_DAILY_LOG_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("  SELECT  ");
                    sbQuery.Append("  PLT_CODE ");
                    sbQuery.Append(" ,DLOG_ID ");
                    sbQuery.Append(" ,DLOG_CAT ");
                    sbQuery.Append(" ,DLOG_TYPE ");
                    sbQuery.Append(" ,DLOG_PERIOD ");
                    sbQuery.Append(" ,DLOG_PLAN ");
                    sbQuery.Append(" ,PLAN_DATE ");
                    sbQuery.Append(" ,WORK_DATE ");
                    sbQuery.Append(" ,VEN_CODE ");
                    sbQuery.Append(" ,RELATED_EMP ");
                    sbQuery.Append(" ,RELATED_PROD ");
                    sbQuery.Append(" ,CONTENTS ");
                    sbQuery.Append(" ,DLOG_PLAN_TIME ");
                    sbQuery.Append(" ,DLOG_TIME ");
                    sbQuery.Append(" ,CONVERT(DECIMAL(14,1), DLOG_PLAN_TIME / 60) AS DLOG_PLAN_HOUR_TIME ");
                    sbQuery.Append(" ,CONVERT(DECIMAL(14,1), DLOG_TIME / 60) AS DLOG_HOUR_TIME ");
                    sbQuery.Append(" ,PLAN_SCOMMENT ");
                    sbQuery.Append(" ,SCOMMENT ");
                    sbQuery.Append(" ,DLOG_ACT_FLAG ");
                    sbQuery.Append(" ,REG_DATE ");
                    sbQuery.Append(" ,REG_EMP ");
                    sbQuery.Append(" ,MDFY_DATE ");
                    sbQuery.Append(" ,MDFY_EMP ");
                    sbQuery.Append(" ,DEL_DATE ");
                    sbQuery.Append(" ,DEL_EMP ");
                    sbQuery.Append(" ,DATA_FLAG ");
                    sbQuery.Append("  FROM TSYS_DAILY_LOG  ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("   AND DLOG_ID = @DLOG_ID");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "DLOG_ID")) isHasColumn = false;

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


        public static DataTable TSYS_DAILY_LOG_SER2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append("  SELECT  ");
                    sbQuery.Append("  PLT_CODE ");
                    sbQuery.Append(" ,DLOG_ID ");
                    sbQuery.Append(" ,DLOG_CAT ");
                    sbQuery.Append(" ,DLOG_TYPE ");
                    sbQuery.Append(" ,DLOG_PERIOD ");
                    sbQuery.Append(" ,DLOG_PLAN ");
                    sbQuery.Append(" ,WORK_DATE ");
                    sbQuery.Append(" ,VEN_CODE ");
                    sbQuery.Append(" ,RELATED_EMP ");
                    sbQuery.Append(" ,RELATED_PROD ");
                    sbQuery.Append(" ,CONTENTS ");
                    sbQuery.Append(" ,DLOG_TIME ");
                    sbQuery.Append(" ,SCOMMENT ");
                    sbQuery.Append(" ,REG_DATE ");
                    sbQuery.Append(" ,REG_EMP ");
                    sbQuery.Append(" ,MDFY_DATE ");
                    sbQuery.Append(" ,MDFY_EMP ");
                    sbQuery.Append(" ,DEL_DATE ");
                    sbQuery.Append(" ,DEL_EMP ");
                    sbQuery.Append(" ,DATA_FLAG ");
                    sbQuery.Append("  FROM TSYS_DAILY_LOG  ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("   AND DLOG_ID = @DLOG_ID");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "DLOG_ID")) isHasColumn = false;

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


        public static void TSYS_DAILY_LOG_UPD(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("UPDATE TSYS_DAILY_LOG ");
                    sbQuery.Append(" SET DLOG_CAT = @DLOG_CAT ");
                    sbQuery.Append(" ,DLOG_TYPE = @DLOG_TYPE ");
                    sbQuery.Append(" ,DLOG_PERIOD = @DLOG_PERIOD ");
                    sbQuery.Append(" ,DLOG_PLAN = @DLOG_PLAN ");
                    sbQuery.Append(" ,PLAN_DATE = @PLAN_DATE ");
                    sbQuery.Append(" ,WORK_DATE = @WORK_DATE ");
                    sbQuery.Append(" ,VEN_CODE = @VEN_CODE ");
                    sbQuery.Append(" ,RELATED_EMP = @RELATED_EMP ");
                    sbQuery.Append(" ,RELATED_PROD = @RELATED_PROD ");
                    sbQuery.Append(" ,CONTENTS = @CONTENTS ");
                    sbQuery.Append(" ,DLOG_PLAN_TIME = @DLOG_PLAN_TIME ");
                    sbQuery.Append(" ,DLOG_TIME = @DLOG_TIME ");
                    sbQuery.Append(" ,PLAN_SCOMMENT = @PLAN_SCOMMENT ");
                    sbQuery.Append(" ,SCOMMENT = @SCOMMENT ");
                    sbQuery.Append(" ,DLOG_ACT_FLAG = @DLOG_ACT_FLAG ");
                    sbQuery.Append(" ,MDFY_DATE = GETDATE() ");
                    sbQuery.Append(" ,MDFY_EMP = @MDFY_EMP ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("   AND DLOG_ID = @DLOG_ID ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크                        
                        if (!UTIL.ValidColumn(row, "DLOG_ID")) isHasColumn = false;

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

        public static void TSYS_DAILY_LOG_UPD2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("UPDATE TSYS_DAILY_LOG SET ");
                    sbQuery.Append(" WORK_DATE = @WORK_DATE ");
                    sbQuery.Append(" ,DLOG_TIME = @DLOG_TIME ");
                    sbQuery.Append(" ,SCOMMENT = @SCOMMENT ");
                    sbQuery.Append(" ,DLOG_ACT_FLAG = @DLOG_ACT_FLAG ");
                    sbQuery.Append(" ,MDFY_DATE = GETDATE() ");
                    sbQuery.Append(" ,MDFY_EMP = @MDFY_EMP ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("   AND DLOG_ID = @DLOG_ID ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크                        
                        if (!UTIL.ValidColumn(row, "DLOG_ID")) isHasColumn = false;

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

        public static void TSYS_DAILY_LOG_UPD3(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("UPDATE TSYS_DAILY_LOG SET ");
                    sbQuery.Append(" DLOG_TYPE = @DLOG_TYPE ");
                    sbQuery.Append(" ,RELATED_PROD = @RELATED_PROD ");
                    sbQuery.Append(" ,CONTENTS = @CONTENTS ");
                    sbQuery.Append(" ,MDFY_DATE = GETDATE() ");
                    sbQuery.Append(" ,MDFY_EMP = @MDFY_EMP ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("   AND DLOG_ID = @DLOG_ID ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크                        
                        if (!UTIL.ValidColumn(row, "DLOG_ID")) isHasColumn = false;

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

        public static void TSYS_DAILY_LOG_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();


                    sbQuery.Append("INSERT INTO TSYS_DAILY_LOG ");
                    sbQuery.Append("( ");
                    sbQuery.Append("  PLT_CODE ");
                    sbQuery.Append(" ,DLOG_ID ");
                    sbQuery.Append(" ,DLOG_CAT ");
                    sbQuery.Append(" ,DLOG_TYPE ");
                    sbQuery.Append(" ,DLOG_PERIOD ");
                    sbQuery.Append(" ,DLOG_PLAN ");
                    sbQuery.Append(" ,PLAN_DATE ");
                    sbQuery.Append(" ,WORK_DATE ");
                    sbQuery.Append(" ,VEN_CODE ");
                    sbQuery.Append(" ,RELATED_EMP ");
                    sbQuery.Append(" ,RELATED_PROD ");
                    sbQuery.Append(" ,CONTENTS ");
                    sbQuery.Append(" ,DLOG_PLAN_TIME ");
                    sbQuery.Append(" ,DLOG_TIME ");
                    sbQuery.Append(" ,PLAN_SCOMMENT ");
                    sbQuery.Append(" ,SCOMMENT ");
                    sbQuery.Append(" ,DLOG_ACT_FLAG ");
                    sbQuery.Append(" ,REG_DATE ");
                    sbQuery.Append(" ,REG_EMP ");
                    sbQuery.Append(" ,DATA_FLAG ");
                    sbQuery.Append(") ");
                    sbQuery.Append("VALUES ");
                    sbQuery.Append("( ");
                    sbQuery.Append("  @PLT_CODE ");
                    sbQuery.Append(" ,@DLOG_ID ");
                    sbQuery.Append(" ,@DLOG_CAT ");
                    sbQuery.Append(" ,@DLOG_TYPE ");
                    sbQuery.Append(" ,@DLOG_PERIOD ");
                    sbQuery.Append(" ,@DLOG_PLAN ");
                    sbQuery.Append(" ,@PLAN_DATE ");
                    sbQuery.Append(" ,@WORK_DATE ");
                    sbQuery.Append(" ,@VEN_CODE ");
                    sbQuery.Append(" ,@RELATED_EMP ");
                    sbQuery.Append(" ,@RELATED_PROD ");
                    sbQuery.Append(" ,@CONTENTS ");
                    sbQuery.Append(" ,@DLOG_PLAN_TIME ");
                    sbQuery.Append(" ,@DLOG_TIME ");
                    sbQuery.Append(" ,@PLAN_SCOMMENT ");
                    sbQuery.Append(" ,@SCOMMENT ");
                    sbQuery.Append(" ,@DLOG_ACT_FLAG ");
                    sbQuery.Append(" ,GETDATE() ");
                    sbQuery.Append(" ,@REG_EMP ");
                    sbQuery.Append(" ,0 ");
                    sbQuery.Append(") ");

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

        public static void TSYS_DAILY_LOG_UDE(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("UPDATE TSYS_DAILY_LOG ");
                    sbQuery.Append("  SET   DEL_DATE = GETDATE() ");
                    sbQuery.Append("      , DEL_EMP = @DEL_EMP ");
                    sbQuery.Append("      , DATA_FLAG = 2 ");
                    sbQuery.Append("WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("  AND DLOG_ID = @DLOG_ID ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크                        
                        if (!UTIL.ValidColumn(row, "DLOG_ID")) isHasColumn = false;

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

    public class TSYS_DAILY_LOG_QUERY
    {
      
        public static DataTable TSYS_DAILY_LOG_QUERY1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT L.PLT_CODE  ");
                    sbQuery.Append(" ,L.DLOG_ID ");
                    sbQuery.Append(" ,L.DLOG_CAT ");
                    sbQuery.Append(" ,L.DLOG_TYPE ");
                    sbQuery.Append(" ,L.DLOG_PERIOD ");
                    sbQuery.Append(" ,L.DLOG_PLAN ");
                    sbQuery.Append(" ,L.VEN_CODE  ");
                    sbQuery.Append(" ,L.PLAN_DATE  ");
                    sbQuery.Append(" ,L.WORK_DATE  ");
                    sbQuery.Append(" ,L.RELATED_EMP  ");
                    sbQuery.Append(" ,L.RELATED_PROD ");
                    sbQuery.Append(" ,L.CONTENTS  ");
                    sbQuery.Append(" ,CASE ISNULL(F.LINK_KEY,'') WHEN '' THEN '0' ELSE '1' END HAS_ATTACH  ");
                    sbQuery.Append(" ,L.DLOG_PLAN_TIME ");
                    sbQuery.Append(" ,L.DLOG_TIME ");
                    sbQuery.Append(" ,CONVERT(DECIMAL(14,1), L.DLOG_PLAN_TIME / 60) AS DLOG_PLAN_HOUR_TIME ");
                    sbQuery.Append(" ,CONVERT(DECIMAL(14,1), L.DLOG_TIME / 60) AS DLOG_HOUR_TIME ");
                    sbQuery.Append(" ,L.PLAN_SCOMMENT ");
                    sbQuery.Append(" ,L.SCOMMENT ");
                    sbQuery.Append(" ,L.DLOG_ACT_FLAG ");
                    sbQuery.Append(" ,L.REG_DATE ");
                    sbQuery.Append(" ,L.REG_EMP ");
                    sbQuery.Append(" ,L.MDFY_DATE ");
                    sbQuery.Append(" ,L.MDFY_EMP ");
                    sbQuery.Append(" ,L.DEL_DATE ");
                    sbQuery.Append(" ,L.DEL_EMP ");
                    sbQuery.Append(" ,L.DATA_FLAG ");
                    sbQuery.Append("  FROM TSYS_DAILY_LOG L");
                    sbQuery.Append("  LEFT JOIN TSYS_FILELIST_MASTER F");
                    sbQuery.Append("  ON L.PLT_CODE = F.PLT_CODE ");
                    sbQuery.Append("  AND L.DLOG_ID = F.LINK_KEY ");
                    sbQuery.Append("  AND F.DATA_FLAG = 0 ");

                    DataRow row = dtParam.Rows[0];

                    StringBuilder sbWhere = new StringBuilder();

                    sbWhere.Append(" WHERE 1=1 ");

                    sbWhere.Append(UTIL.GetWhere(row, "@PLT_CODE", " L.PLT_CODE = @PLT_CODE"));
                    sbWhere.Append(UTIL.GetWhere(row, "@EMP_CODE", " L.REG_EMP = @EMP_CODE"));
                    sbWhere.Append(UTIL.GetWhere(row, "@DLOG_CAT", " L.DLOG_CAT = @DLOG_CAT"));
                    sbWhere.Append(UTIL.GetWhere(row, "@IS_ACT_FLAG", " ISNULL(L.DLOG_ACT_FLAG,0) IN (0)"));
                    sbWhere.Append(UTIL.GetWhere(row, "@IS_ACT_FLAG2", " ISNULL(L.DLOG_ACT_FLAG,0) IN (0, 1)"));

                    if (dtParam.Columns.Contains("IS_NON_ACT"))
                    {
                        sbWhere.Append(UTIL.GetWhere(row, "@S_WORK_DATE,@E_WORK_DATE", " (L.WORK_DATE BETWEEN @S_WORK_DATE AND @E_WORK_DATE OR ISNULL(DLOG_ACT_FLAG, 0) = 0)"));
                    }
                    else
                    {
                        sbWhere.Append(UTIL.GetWhere(row, "@S_WORK_DATE,@E_WORK_DATE", " L.WORK_DATE BETWEEN @S_WORK_DATE AND @E_WORK_DATE"));
                    }
                    sbWhere.Append(UTIL.GetWhere(row, "@S_PLAN_DATE,@E_PLAN_DATE", " L.PLAN_DATE BETWEEN @S_PLAN_DATE AND @E_PLAN_DATE "));
                    sbWhere.Append(" AND L.DATA_FLAG = 0");

                    sbWhere.Append(" GROUP BY L.PLT_CODE, L.DLOG_ID , L.VEN_CODE, L.WORK_DATE, L.PLAN_DATE , L.RELATED_EMP, L.RELATED_PROD ,L.CONTENTS  , CASE ISNULL(F.LINK_KEY,'') WHEN '' THEN '0' ELSE '1' END");
                    sbWhere.Append(" , L.DLOG_ACT_FLAG, L.REG_DATE, L.REG_EMP , L.MDFY_DATE , L.MDFY_EMP , L.DEL_DATE , L.DEL_EMP , L.DATA_FLAG ");
                    sbWhere.Append(" , L.DLOG_CAT, L.DLOG_TYPE, L.DLOG_PERIOD, L.DLOG_PLAN, L.DLOG_TIME, L.DLOG_PLAN_TIME, L.PLAN_SCOMMENT, L.SCOMMENT");

                    sbWhere.Append(" ORDER BY L.WORK_DATE DESC, L.PLAN_DATE ");

                    DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString() + sbWhere.ToString()).Copy();

                    sourceTable.TableName = "RSLTDT";
                    dsResult.Merge(sourceTable);

                }

                return UTIL.GetDsToDt(dsResult);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataTable TSYS_DAILY_LOG_QUERY2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT");
                    sbQuery.Append(" D.PLT_CODE");
                    sbQuery.Append(" ,D.DLOG_TYPE");
                    sbQuery.Append(" ,C.CD_NAME AS DLOG_TYPE_NAME");
                    sbQuery.Append(" ,D.REG_EMP");
                    sbQuery.Append(" ,E.EMP_NAME");
                    sbQuery.Append(" ,LEFT(D.WORK_DATE,6) AS WORK_MONTH");
                    sbQuery.Append(" ,SUM(D.DLOG_TIME) AS DLOG_TIME");
                    sbQuery.Append(" ,SUM(D.DLOG_PLAN_TIME) AS DLOG_PLAN_TIME");
                    sbQuery.Append(" ,W.WORK_DAY");
                    //CONVERT(DECIMAL(14, 1), L.DLOG_TIME / 60)
                    //CONVERT(DECIMAL(14, 1), L.DLOG_PLAN_TIME / 60)
                    sbQuery.Append(" ,CASE WHEN ISNULL(W.WORK_DAY,0) = 0 THEN 0 ELSE SUM(ISNULL(D.DLOG_TIME ,0) / 60) / W.WORK_DAY END AS DLOG_DAY");
                    sbQuery.Append(" ,CASE WHEN ISNULL(W.WORK_DAY,0) = 0 THEN 0 ELSE SUM(ISNULL(D.DLOG_PLAN_TIME, 0) / 60) / W.WORK_DAY END AS DLOG_PLAN_DAY");
                    sbQuery.Append(" FROM TSYS_DAILY_LOG D");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE E");
                    sbQuery.Append(" ON D.PLT_CODE = E.PLT_CODE");
                    sbQuery.Append(" AND D.REG_EMP = E.EMP_CODE");
                    
                    sbQuery.Append(" LEFT JOIN TSTD_WORKDAY W");
                    sbQuery.Append(" ON D.PLT_CODE = W.PLT_CODE");
                    sbQuery.Append(" AND LEFT(D.WORK_DATE,6) = W.WORK_MONTH");
                    sbQuery.Append(" AND W.DATA_FLAG = '0'");

                    sbQuery.Append(" LEFT JOIN TSTD_CODES C");
                    sbQuery.Append(" ON D.PLT_CODE = C.PLT_CODE");
                    sbQuery.Append(" AND D.DLOG_TYPE = C.CD_CODE");
                    sbQuery.Append(" AND C.CAT_CODE = 'S096'");


                    DataRow row = dtParam.Rows[0];

                    StringBuilder sbWhere = new StringBuilder();

                    sbWhere.Append(" WHERE 1=1 ");

                    sbWhere.Append(UTIL.GetWhere(row, "@PLT_CODE", " D.PLT_CODE = @PLT_CODE"));
                    sbWhere.Append(UTIL.GetWhere(row, "@EMP_CODE", " D.REG_EMP = @EMP_CODE"));
                    sbWhere.Append(UTIL.GetWhere(row, "@YEAR", " LEFT(D.WORK_DATE,4) = @YEAR"));
                    sbWhere.Append(UTIL.GetWhere(row, "@MONTH", " LEFT(D.WORK_DATE,6) = @MONTH"));
                    sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", " D.DATA_FLAG = @DATA_FLAG"));
                    sbWhere.Append(" AND W.WORK_DAY IS NOT NULL AND D.DLOG_TIME IS NOT NULL");

                    sbWhere.Append(" GROUP BY D.PLT_CODE");
                    sbWhere.Append(" ,D.DLOG_TYPE");
                    sbWhere.Append(" ,C.CD_NAME");
                    sbWhere.Append(" ,D.REG_EMP");
                    sbWhere.Append(" ,E.EMP_NAME");
                    sbWhere.Append(" ,LEFT(WORK_DATE,6)");
                    sbWhere.Append(" ,W.WORK_DAY");


                    DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString() + sbWhere.ToString()).Copy();

                    sourceTable.TableName = "RSLTDT";
                    dsResult.Merge(sourceTable);

                }

                return UTIL.GetDsToDt(dsResult);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataTable TSYS_DAILY_LOG_QUERY3(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT");
                    sbQuery.Append(" D.PLT_CODE");
                    sbQuery.Append(" ,D.RELATED_PROD");
                    sbQuery.Append(" ,C.CD_NAME AS RELATED_PROD_NAME");
                    sbQuery.Append(" ,D.REG_EMP");
                    sbQuery.Append(" ,E.EMP_NAME");
                    sbQuery.Append(" ,LEFT(D.WORK_DATE,6) AS WORK_MONTH");
                    sbQuery.Append(" ,SUM(D.DLOG_TIME) AS DLOG_TIME");
                    sbQuery.Append(" ,SUM(D.DLOG_PLAN_TIME) AS DLOG_PLAN_TIME");
                    sbQuery.Append(" ,W.WORK_DAY");
                    //sbQuery.Append(" ,CASE WHEN ISNULL(W.WORK_DAY,0) = 0 THEN 0 ELSE SUM(D.DLOG_TIME) / W.WORK_DAY END AS DLOG_DAY");
                    //sbQuery.Append(" ,CASE WHEN ISNULL(W.WORK_DAY,0) = 0 THEN 0 ELSE SUM(D.DLOG_PLAN_TIME) / W.WORK_DAY END AS DLOG_PLAN_DAY");
                    sbQuery.Append(" ,CASE WHEN ISNULL(W.WORK_DAY,0) = 0 THEN 0 ELSE SUM(ISNULL(D.DLOG_TIME, 0) / 60) / W.WORK_DAY END AS DLOG_DAY");
                    sbQuery.Append(" ,CASE WHEN ISNULL(W.WORK_DAY,0) = 0 THEN 0 ELSE SUM(ISNULL(D.DLOG_PLAN_TIME, 0) / 60) / W.WORK_DAY END AS DLOG_PLAN_DAY");
                    sbQuery.Append(" FROM TSYS_DAILY_LOG D");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE E");
                    sbQuery.Append(" ON D.PLT_CODE = E.PLT_CODE");
                    sbQuery.Append(" AND D.REG_EMP = E.EMP_CODE");

                    sbQuery.Append(" LEFT JOIN TSTD_WORKDAY W");
                    sbQuery.Append(" ON D.PLT_CODE = W.PLT_CODE");
                    sbQuery.Append(" AND LEFT(D.WORK_DATE,6) = W.WORK_MONTH");
                    sbQuery.Append(" AND W.DATA_FLAG = '0'");

                    sbQuery.Append(" LEFT JOIN TSTD_CODES C");
                    sbQuery.Append(" ON D.PLT_CODE = C.PLT_CODE");
                    sbQuery.Append(" AND D.RELATED_PROD = C.CD_CODE");
                    sbQuery.Append(" AND C.CAT_CODE = 'S099'");

                    DataRow row = dtParam.Rows[0];

                    StringBuilder sbWhere = new StringBuilder();

                    sbWhere.Append(" WHERE 1=1 ");

                    sbWhere.Append(UTIL.GetWhere(row, "@PLT_CODE", " D.PLT_CODE = @PLT_CODE"));
                    sbWhere.Append(UTIL.GetWhere(row, "@EMP_CODE", " D.REG_EMP = @EMP_CODE"));
                    sbWhere.Append(UTIL.GetWhere(row, "@YEAR", " LEFT(D.WORK_DATE,4) = @YEAR"));
                    sbWhere.Append(UTIL.GetWhere(row, "@MONTH", " LEFT(D.WORK_DATE,6) = @MONTH"));
                    sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", " D.DATA_FLAG = @DATA_FLAG"));
                    sbWhere.Append(" AND W.WORK_DAY IS NOT NULL AND D.DLOG_TIME IS NOT NULL");

                    sbWhere.Append(" GROUP BY D.PLT_CODE");
                    sbWhere.Append(" ,D.RELATED_PROD");
                    sbWhere.Append(" ,C.CD_NAME");
                    sbWhere.Append(" ,D.REG_EMP");
                    sbWhere.Append(" ,E.EMP_NAME");
                    sbWhere.Append(" ,LEFT(WORK_DATE,6)");
                    sbWhere.Append(" ,W.WORK_DAY");

                    DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString() + sbWhere.ToString()).Copy();

                    sourceTable.TableName = "RSLTDT";
                    dsResult.Merge(sourceTable);

                }

                return UTIL.GetDsToDt(dsResult);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataTable TSYS_DAILY_LOG_QUERY4(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT");
                    sbQuery.Append(" D.PLT_CODE");
                    sbQuery.Append(" ,D.CONTENTS");
                    sbQuery.Append(" ,D.REG_EMP");
                    sbQuery.Append(" ,E.EMP_NAME");
                    sbQuery.Append(" ,LEFT(D.WORK_DATE,6) AS WORK_MONTH");
                    sbQuery.Append(" ,SUM(D.DLOG_TIME) AS DLOG_TIME");
                    sbQuery.Append(" ,SUM(D.DLOG_PLAN_TIME) AS DLOG_PLAN_TIME");
                    sbQuery.Append(" ,W.WORK_DAY");
                    //sbQuery.Append(" ,CASE WHEN ISNULL(W.WORK_DAY,0) = 0 THEN 0 ELSE SUM(D.DLOG_TIME) / W.WORK_DAY END AS DLOG_DAY");
                    //sbQuery.Append(" ,CASE WHEN ISNULL(W.WORK_DAY,0) = 0 THEN 0 ELSE SUM(D.DLOG_PLAN_TIME) / W.WORK_DAY END AS DLOG_PLAN_DAY");
                    sbQuery.Append(" ,CASE WHEN ISNULL(W.WORK_DAY,0) = 0 THEN 0 ELSE SUM(ISNULL(D.DLOG_TIME, 0) / 60) / W.WORK_DAY END AS DLOG_DAY");
                    sbQuery.Append(" ,CASE WHEN ISNULL(W.WORK_DAY,0) = 0 THEN 0 ELSE SUM(ISNULL(D.DLOG_PLAN_TIME, 0) / 60) / W.WORK_DAY END AS DLOG_PLAN_DAY");
                    sbQuery.Append(" FROM TSYS_DAILY_LOG D");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE E");
                    sbQuery.Append(" ON D.PLT_CODE = E.PLT_CODE");
                    sbQuery.Append(" AND D.REG_EMP = E.EMP_CODE");

                    sbQuery.Append(" LEFT JOIN TSTD_WORKDAY W");
                    sbQuery.Append(" ON D.PLT_CODE = W.PLT_CODE");
                    sbQuery.Append(" AND LEFT(D.WORK_DATE,6) = W.WORK_MONTH");
                    sbQuery.Append(" AND W.DATA_FLAG = '0'");

                    DataRow row = dtParam.Rows[0];

                    StringBuilder sbWhere = new StringBuilder();

                    sbWhere.Append(" WHERE 1=1 ");

                    sbWhere.Append(UTIL.GetWhere(row, "@PLT_CODE", " D.PLT_CODE = @PLT_CODE"));
                    sbWhere.Append(UTIL.GetWhere(row, "@EMP_CODE", " D.REG_EMP = @EMP_CODE"));
                    sbWhere.Append(UTIL.GetWhere(row, "@YEAR", " LEFT(D.WORK_DATE,4) = @YEAR"));
                    sbWhere.Append(UTIL.GetWhere(row, "@MONTH", " LEFT(D.WORK_DATE,6) = @MONTH"));
                    sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", " D.DATA_FLAG = @DATA_FLAG"));
                    sbWhere.Append(" AND W.WORK_DAY IS NOT NULL AND D.DLOG_TIME IS NOT NULL");

                    sbWhere.Append(" GROUP BY D.PLT_CODE");
                    sbWhere.Append(" ,D.CONTENTS");
                    sbWhere.Append(" ,D.REG_EMP");
                    sbWhere.Append(" ,E.EMP_NAME");
                    sbWhere.Append(" ,LEFT(WORK_DATE,6)");
                    sbWhere.Append(" ,W.WORK_DAY");


                    DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString() + sbWhere.ToString()).Copy();

                    sourceTable.TableName = "RSLTDT";
                    dsResult.Merge(sourceTable);

                }

                return UTIL.GetDsToDt(dsResult);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }


        public static DataTable TSYS_DAILY_LOG_QUERY5(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT");
                    sbQuery.Append(" D.PLT_CODE");
                    sbQuery.Append(" ,D.DLOG_TYPE");
                    sbQuery.Append(" ,C.CD_NAME AS DLOG_TYPE_NAME");
                    sbQuery.Append(" ,D.REG_EMP");
                    sbQuery.Append(" ,E.EMP_NAME");
                    sbQuery.Append(" ,LEFT(D.WORK_DATE,4) AS WORK_YEAR");
                    sbQuery.Append(" ,SUM(D.DLOG_TIME) AS DLOG_TIME");
                    sbQuery.Append(" ,SUM(D.DLOG_PLAN_TIME) AS DLOG_PLAN_TIME");
                    sbQuery.Append(" ,W.WORK_DAY");
                    sbQuery.Append(" ,CASE WHEN ISNULL(W.WORK_DAY,0) = 0 THEN 0 ELSE SUM(ISNULL(D.DLOG_TIME, 0) / 60) / W.WORK_DAY END AS DLOG_DAY");
                    sbQuery.Append(" ,CASE WHEN ISNULL(W.WORK_DAY,0) = 0 THEN 0 ELSE SUM(ISNULL(D.DLOG_PLAN_TIME, 0) / 60) / W.WORK_DAY END AS DLOG_PLAN_DAY");
                    sbQuery.Append(" FROM TSYS_DAILY_LOG D");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE E");
                    sbQuery.Append(" ON D.PLT_CODE = E.PLT_CODE");
                    sbQuery.Append(" AND D.REG_EMP = E.EMP_CODE");

                    sbQuery.Append(" LEFT JOIN (");
                    sbQuery.Append(" SELECT PLT_CODE, LEFT(WORK_MONTH, 4) AS WORK_YEAR, SUM(WORK_DAY) AS WORK_DAY FROM TSTD_WORKDAY");
                    sbQuery.Append(" WHERE DATA_FLAG = '0'");
                    sbQuery.Append(" GROUP BY PLT_CODE, LEFT(WORK_MONTH, 4)");
                    sbQuery.Append(" ) W");
                    sbQuery.Append(" ON D.PLT_CODE = W.PLT_CODE");
                    sbQuery.Append(" AND LEFT(D.WORK_DATE,4) = W.WORK_YEAR");


                    sbQuery.Append(" LEFT JOIN TSTD_CODES C");
                    sbQuery.Append(" ON D.PLT_CODE = C.PLT_CODE");
                    sbQuery.Append(" AND D.DLOG_TYPE = C.CD_CODE");
                    sbQuery.Append(" AND C.CAT_CODE = 'S096'");


                    DataRow row = dtParam.Rows[0];

                    StringBuilder sbWhere = new StringBuilder();

                    sbWhere.Append(" WHERE 1=1 ");

                    sbWhere.Append(UTIL.GetWhere(row, "@PLT_CODE", " D.PLT_CODE = @PLT_CODE"));
                    sbWhere.Append(UTIL.GetWhere(row, "@EMP_CODE", " D.REG_EMP = @EMP_CODE"));
                    sbWhere.Append(UTIL.GetWhere(row, "@YEAR", " LEFT(D.WORK_DATE,4) = @YEAR"));
                    sbWhere.Append(UTIL.GetWhere(row, "@MONTH", " LEFT(D.WORK_DATE,6) = @MONTH"));
                    sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", " D.DATA_FLAG = @DATA_FLAG"));
                    sbWhere.Append(" AND W.WORK_DAY IS NOT NULL AND D.DLOG_TIME IS NOT NULL");

                    sbWhere.Append(" GROUP BY D.PLT_CODE");
                    sbWhere.Append(" ,D.DLOG_TYPE");
                    sbWhere.Append(" ,C.CD_NAME");
                    sbWhere.Append(" ,D.REG_EMP");
                    sbWhere.Append(" ,E.EMP_NAME");
                    sbWhere.Append(" ,LEFT(WORK_DATE,4)");
                    sbWhere.Append(" ,W.WORK_DAY");


                    DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString() + sbWhere.ToString()).Copy();

                    sourceTable.TableName = "RSLTDT";
                    dsResult.Merge(sourceTable);

                }

                return UTIL.GetDsToDt(dsResult);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataTable TSYS_DAILY_LOG_QUERY6(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT");
                    sbQuery.Append(" D.PLT_CODE");
                    sbQuery.Append(" ,D.RELATED_PROD");
                    sbQuery.Append(" ,C.CD_NAME AS RELATED_PROD_NAME");
                    sbQuery.Append(" ,D.REG_EMP");
                    sbQuery.Append(" ,E.EMP_NAME");
                    sbQuery.Append(" ,LEFT(D.WORK_DATE,4) AS WORK_YEAR");
                    sbQuery.Append(" ,SUM(D.DLOG_TIME) AS DLOG_TIME");
                    sbQuery.Append(" ,SUM(D.DLOG_PLAN_TIME) AS DLOG_PLAN_TIME");
                    sbQuery.Append(" ,W.WORK_DAY");
                    //sbQuery.Append(" ,CASE WHEN ISNULL(W.WORK_DAY,0) = 0 THEN 0 ELSE SUM(D.DLOG_TIME) / W.WORK_DAY END AS DLOG_DAY");
                    //sbQuery.Append(" ,CASE WHEN ISNULL(W.WORK_DAY,0) = 0 THEN 0 ELSE SUM(D.DLOG_PLAN_TIME) / W.WORK_DAY END AS DLOG_PLAN_DAY");
                    sbQuery.Append(" ,CASE WHEN ISNULL(W.WORK_DAY,0) = 0 THEN 0 ELSE SUM(ISNULL(D.DLOG_TIME, 0) / 60) / W.WORK_DAY END AS DLOG_DAY");
                    sbQuery.Append(" ,CASE WHEN ISNULL(W.WORK_DAY,0) = 0 THEN 0 ELSE SUM(ISNULL(D.DLOG_PLAN_TIME, 0) / 60) / W.WORK_DAY END AS DLOG_PLAN_DAY");
                    sbQuery.Append(" FROM TSYS_DAILY_LOG D");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE E");
                    sbQuery.Append(" ON D.PLT_CODE = E.PLT_CODE");
                    sbQuery.Append(" AND D.REG_EMP = E.EMP_CODE");

                    sbQuery.Append(" LEFT JOIN (");
                    sbQuery.Append(" SELECT PLT_CODE, LEFT(WORK_MONTH, 4) AS WORK_YEAR, SUM(WORK_DAY) AS WORK_DAY FROM TSTD_WORKDAY");
                    sbQuery.Append(" WHERE DATA_FLAG = '0'");
                    sbQuery.Append(" GROUP BY PLT_CODE, LEFT(WORK_MONTH, 4)");
                    sbQuery.Append(" ) W");
                    sbQuery.Append(" ON D.PLT_CODE = W.PLT_CODE");
                    sbQuery.Append(" AND LEFT(D.WORK_DATE,4) = W.WORK_YEAR");

                    sbQuery.Append(" LEFT JOIN TSTD_CODES C");
                    sbQuery.Append(" ON D.PLT_CODE = C.PLT_CODE");
                    sbQuery.Append(" AND D.RELATED_PROD = C.CD_CODE");
                    sbQuery.Append(" AND C.CAT_CODE = 'S099'");

                    DataRow row = dtParam.Rows[0];

                    StringBuilder sbWhere = new StringBuilder();

                    sbWhere.Append(" WHERE 1=1 ");

                    sbWhere.Append(UTIL.GetWhere(row, "@PLT_CODE", " D.PLT_CODE = @PLT_CODE"));
                    sbWhere.Append(UTIL.GetWhere(row, "@EMP_CODE", " D.REG_EMP = @EMP_CODE"));
                    sbWhere.Append(UTIL.GetWhere(row, "@YEAR", " LEFT(D.WORK_DATE,4) = @YEAR"));
                    sbWhere.Append(UTIL.GetWhere(row, "@MONTH", " LEFT(D.WORK_DATE,6) = @MONTH"));
                    sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", " D.DATA_FLAG = @DATA_FLAG"));
                    sbWhere.Append(" AND W.WORK_DAY IS NOT NULL AND D.DLOG_TIME IS NOT NULL");

                    sbWhere.Append(" GROUP BY D.PLT_CODE");
                    sbWhere.Append(" ,D.RELATED_PROD");
                    sbWhere.Append(" ,C.CD_NAME");
                    sbWhere.Append(" ,D.REG_EMP");
                    sbWhere.Append(" ,E.EMP_NAME");
                    sbWhere.Append(" ,LEFT(WORK_DATE,4)");
                    sbWhere.Append(" ,W.WORK_DAY");

                    DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString() + sbWhere.ToString()).Copy();

                    sourceTable.TableName = "RSLTDT";
                    dsResult.Merge(sourceTable);

                }

                return UTIL.GetDsToDt(dsResult);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataTable TSYS_DAILY_LOG_QUERY7(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT");
                    sbQuery.Append(" D.PLT_CODE");
                    sbQuery.Append(" ,D.CONTENTS");
                    sbQuery.Append(" ,D.REG_EMP");
                    sbQuery.Append(" ,E.EMP_NAME");
                    sbQuery.Append(" ,LEFT(D.WORK_DATE,4) AS WORK_YEAR");
                    sbQuery.Append(" ,SUM(D.DLOG_TIME) AS DLOG_TIME");
                    sbQuery.Append(" ,SUM(D.DLOG_PLAN_TIME) AS DLOG_PLAN_TIME");
                    sbQuery.Append(" ,W.WORK_DAY");
                    //sbQuery.Append(" ,CASE WHEN ISNULL(W.WORK_DAY,0) = 0 THEN 0 ELSE SUM(D.DLOG_TIME) / W.WORK_DAY END AS DLOG_DAY");
                    //sbQuery.Append(" ,CASE WHEN ISNULL(W.WORK_DAY,0) = 0 THEN 0 ELSE SUM(D.DLOG_PLAN_TIME) / W.WORK_DAY END AS DLOG_PLAN_DAY");
                    sbQuery.Append(" ,CASE WHEN ISNULL(W.WORK_DAY,0) = 0 THEN 0 ELSE SUM(ISNULL(D.DLOG_TIME, 0) / 60) / W.WORK_DAY END AS DLOG_DAY");
                    sbQuery.Append(" ,CASE WHEN ISNULL(W.WORK_DAY,0) = 0 THEN 0 ELSE SUM(ISNULL(D.DLOG_PLAN_TIME, 0) / 60) / W.WORK_DAY END AS DLOG_PLAN_DAY");
                    sbQuery.Append(" FROM TSYS_DAILY_LOG D");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE E");
                    sbQuery.Append(" ON D.PLT_CODE = E.PLT_CODE");
                    sbQuery.Append(" AND D.REG_EMP = E.EMP_CODE");

                    sbQuery.Append(" LEFT JOIN (");
                    sbQuery.Append(" SELECT PLT_CODE, LEFT(WORK_MONTH, 4) AS WORK_YEAR, SUM(WORK_DAY) AS WORK_DAY FROM TSTD_WORKDAY");
                    sbQuery.Append(" WHERE DATA_FLAG = '0'");
                    sbQuery.Append(" GROUP BY PLT_CODE, LEFT(WORK_MONTH, 4)");
                    sbQuery.Append(" ) W");
                    sbQuery.Append(" ON D.PLT_CODE = W.PLT_CODE");
                    sbQuery.Append(" AND LEFT(D.WORK_DATE,4) = W.WORK_YEAR");


                    DataRow row = dtParam.Rows[0];

                    StringBuilder sbWhere = new StringBuilder();

                    sbWhere.Append(" WHERE 1=1 ");

                    sbWhere.Append(UTIL.GetWhere(row, "@PLT_CODE", " D.PLT_CODE = @PLT_CODE"));
                    sbWhere.Append(UTIL.GetWhere(row, "@EMP_CODE", " D.REG_EMP = @EMP_CODE"));
                    sbWhere.Append(UTIL.GetWhere(row, "@YEAR", " LEFT(D.WORK_DATE,4) = @YEAR"));
                    sbWhere.Append(UTIL.GetWhere(row, "@MONTH", " LEFT(D.WORK_DATE,6) = @MONTH"));
                    sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", " D.DATA_FLAG = @DATA_FLAG"));
                    sbWhere.Append(" AND W.WORK_DAY IS NOT NULL AND D.DLOG_TIME IS NOT NULL");

                    sbWhere.Append(" GROUP BY D.PLT_CODE");
                    sbWhere.Append(" ,D.CONTENTS");
                    sbWhere.Append(" ,D.REG_EMP");
                    sbWhere.Append(" ,E.EMP_NAME");
                    sbWhere.Append(" ,LEFT(WORK_DATE,4)");
                    sbWhere.Append(" ,W.WORK_DAY");


                    DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString() + sbWhere.ToString()).Copy();

                    sourceTable.TableName = "RSLTDT";
                    dsResult.Merge(sourceTable);

                }

                return UTIL.GetDsToDt(dsResult);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataTable TSYS_DAILY_LOG_QUERY8(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT");
                    sbQuery.Append(" D.PLT_CODE");
                    sbQuery.Append(" ,D.DLOG_TYPE");
                    sbQuery.Append(" ,C.CD_NAME AS DLOG_TYPE_NAME");
                    sbQuery.Append(" ,D.REG_EMP");
                    sbQuery.Append(" ,E.EMP_NAME");
                    sbQuery.Append(" ,SUM(ISNULL(D.DLOG_TIME, 0)) / 60 AS DLOG_TIME");
                    sbQuery.Append(" ,SUM(ISNULL(D.DLOG_PLAN_TIME, 0)) / 60 AS DLOG_PLAN_TIME");
                    sbQuery.Append(" FROM TSYS_DAILY_LOG D");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE E");
                    sbQuery.Append(" ON D.PLT_CODE = E.PLT_CODE");
                    sbQuery.Append(" AND D.REG_EMP = E.EMP_CODE");

                    sbQuery.Append(" LEFT JOIN TSTD_CODES C");
                    sbQuery.Append(" ON D.PLT_CODE = C.PLT_CODE");
                    sbQuery.Append(" AND D.DLOG_TYPE = C.CD_CODE");
                    sbQuery.Append(" AND C.CAT_CODE = 'S096'");


                    DataRow row = dtParam.Rows[0];

                    StringBuilder sbWhere = new StringBuilder();

                    sbWhere.Append(" WHERE 1=1 ");

                    sbWhere.Append(UTIL.GetWhere(row, "@PLT_CODE", " D.PLT_CODE = @PLT_CODE"));
                    sbWhere.Append(UTIL.GetWhere(row, "@EMP_CODE", " D.REG_EMP = @EMP_CODE"));
                    sbWhere.Append(UTIL.GetWhere(row, "@S_DATE,@E_DATE", "D.WORK_DATE BETWEEN @S_DATE AND @E_DATE"));
                    sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", " D.DATA_FLAG = @DATA_FLAG"));
                    sbWhere.Append(" AND D.DLOG_TIME IS NOT NULL");

                    sbWhere.Append(" GROUP BY D.PLT_CODE");
                    sbWhere.Append(" ,D.DLOG_TYPE");
                    sbWhere.Append(" ,C.CD_NAME");
                    sbWhere.Append(" ,D.REG_EMP");
                    sbWhere.Append(" ,E.EMP_NAME");


                    DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString() + sbWhere.ToString()).Copy();

                    sourceTable.TableName = "RSLTDT";
                    dsResult.Merge(sourceTable);

                }

                return UTIL.GetDsToDt(dsResult);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataTable TSYS_DAILY_LOG_QUERY9(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT");
                    sbQuery.Append(" D.PLT_CODE");
                    sbQuery.Append(" ,D.RELATED_PROD");
                    sbQuery.Append(" ,C.CD_NAME AS RELATED_PROD_NAME");
                    sbQuery.Append(" ,D.REG_EMP");
                    sbQuery.Append(" ,E.EMP_NAME");
                    sbQuery.Append(" ,SUM(ISNULL(D.DLOG_TIME, 0)) / 60 AS DLOG_TIME");
                    sbQuery.Append(" ,SUM(ISNULL(D.DLOG_PLAN_TIME, 0)) / 60 AS DLOG_PLAN_TIME");
                    sbQuery.Append(" FROM TSYS_DAILY_LOG D");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE E");
                    sbQuery.Append(" ON D.PLT_CODE = E.PLT_CODE");
                    sbQuery.Append(" AND D.REG_EMP = E.EMP_CODE");

                    sbQuery.Append(" LEFT JOIN TSTD_CODES C");
                    sbQuery.Append(" ON D.PLT_CODE = C.PLT_CODE");
                    sbQuery.Append(" AND D.RELATED_PROD = C.CD_CODE");
                    sbQuery.Append(" AND C.CAT_CODE = 'S099'");


                    DataRow row = dtParam.Rows[0];

                    StringBuilder sbWhere = new StringBuilder();

                    sbWhere.Append(" WHERE 1=1 ");

                    sbWhere.Append(UTIL.GetWhere(row, "@PLT_CODE", " D.PLT_CODE = @PLT_CODE"));
                    sbWhere.Append(UTIL.GetWhere(row, "@EMP_CODE", " D.REG_EMP = @EMP_CODE"));
                    sbWhere.Append(UTIL.GetWhere(row, "@S_DATE,@E_DATE", "D.WORK_DATE BETWEEN @S_DATE AND @E_DATE"));
                    sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", " D.DATA_FLAG = @DATA_FLAG"));
                    sbWhere.Append(" AND D.DLOG_TIME IS NOT NULL");

                    sbWhere.Append(" GROUP BY D.PLT_CODE");
                    sbWhere.Append(" ,D.RELATED_PROD");
                    sbWhere.Append(" ,C.CD_NAME");
                    sbWhere.Append(" ,D.REG_EMP");
                    sbWhere.Append(" ,E.EMP_NAME");

                    DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString() + sbWhere.ToString()).Copy();

                    sourceTable.TableName = "RSLTDT";
                    dsResult.Merge(sourceTable);

                }

                return UTIL.GetDsToDt(dsResult);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataTable TSYS_DAILY_LOG_QUERY10(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT");
                    sbQuery.Append(" D.PLT_CODE");
                    sbQuery.Append(" ,D.CONTENTS");
                    sbQuery.Append(" ,D.REG_EMP");
                    sbQuery.Append(" ,E.EMP_NAME");
                    sbQuery.Append(" ,SUM(ISNULL(D.DLOG_TIME, 0)) / 60 AS DLOG_TIME");
                    sbQuery.Append(" ,SUM(ISNULL(D.DLOG_PLAN_TIME, 0)) / 60 AS DLOG_PLAN_TIME");
                    sbQuery.Append(" FROM TSYS_DAILY_LOG D");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE E");
                    sbQuery.Append(" ON D.PLT_CODE = E.PLT_CODE");
                    sbQuery.Append(" AND D.REG_EMP = E.EMP_CODE");

                    sbQuery.Append(" LEFT JOIN TSTD_CODES C");
                    sbQuery.Append(" ON D.PLT_CODE = C.PLT_CODE");
                    sbQuery.Append(" AND D.DLOG_TYPE = C.CD_CODE");
                    sbQuery.Append(" AND C.CAT_CODE = 'S096'");

                    DataRow row = dtParam.Rows[0];

                    StringBuilder sbWhere = new StringBuilder();

                    sbWhere.Append(" WHERE 1=1 ");

                    sbWhere.Append(UTIL.GetWhere(row, "@PLT_CODE", " D.PLT_CODE = @PLT_CODE"));
                    sbWhere.Append(UTIL.GetWhere(row, "@EMP_CODE", " D.REG_EMP = @EMP_CODE"));
                    sbWhere.Append(UTIL.GetWhere(row, "@S_DATE,@E_DATE", "D.WORK_DATE BETWEEN @S_DATE AND @E_DATE"));
                    sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", " D.DATA_FLAG = @DATA_FLAG"));
                    sbWhere.Append(" AND D.DLOG_TIME IS NOT NULL");

                    sbWhere.Append(" GROUP BY D.PLT_CODE");
                    sbWhere.Append(" ,D.CONTENTS");
                    sbWhere.Append(" ,D.REG_EMP");
                    sbWhere.Append(" ,E.EMP_NAME");

                    DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString() + sbWhere.ToString()).Copy();

                    sourceTable.TableName = "RSLTDT";
                    dsResult.Merge(sourceTable);

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
