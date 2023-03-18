using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace DSYS
{
    public class TSYS_PROPOSE
    {
        public static DataTable TSYS_PROPOSE_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("SELECT   PLT_CODE ");
                    sbQuery.Append("       , PROPS_ID ");
                    sbQuery.Append("       , PROPS_DATE ");
                    sbQuery.Append("       , EMP_CODE ");
                    sbQuery.Append("       , ORG_CODE ");
                    sbQuery.Append("       , PROC_NAME ");
                    sbQuery.Append("       , TITLE ");
                    sbQuery.Append("       , AS_IS ");
                    sbQuery.Append("       , TO_BE ");
                    sbQuery.Append("       , EXP_EFFECT");
                    sbQuery.Append("       , EXP_FINISH_DATE ");
                    sbQuery.Append("       , FINISH_DATE ");
                    sbQuery.Append("       , ISSU_FILE_ID ");
                    sbQuery.Append("       , SOL_FILE_ID ");
                    sbQuery.Append("       , RPT_FILE_ID ");
                    sbQuery.Append("       , REWARD ");
                    sbQuery.Append("       , REWARD_DATE ");
                    sbQuery.Append("       , GRADE ");
                    sbQuery.Append("       , SCOMMENT ");
                    sbQuery.Append("       , APP_STATUS");
                    sbQuery.Append("       , APP_EMP1");
                    sbQuery.Append("       , APP_EMP_FLAG1");
                    sbQuery.Append("       , APP_EMP2");
                    sbQuery.Append("       , APP_EMP_FLAG2");
                    sbQuery.Append("       , APP_EMP3");
                    sbQuery.Append("       , APP_EMP_FLAG3");
                    sbQuery.Append("       , APP_EMP4");
                    sbQuery.Append("       , APP_EMP_FLAG4");
                    sbQuery.Append("       , APP_EMP1_OK");
                    sbQuery.Append("       , APP_EMP2_OK");
                    sbQuery.Append("       , APP_EMP3_OK");
                    sbQuery.Append("       , APP_EMP4_OK");
                    sbQuery.Append("       , REG_DATE ");
                    sbQuery.Append("       , REG_EMP ");
                    sbQuery.Append("       , MDFY_DATE ");
                    sbQuery.Append("       , MDFY_EMP ");
                    sbQuery.Append("       , DEL_DATE ");
                    sbQuery.Append("       , DEL_EMP ");
                    sbQuery.Append("       , DATA_FLAG ");
                    sbQuery.Append("  FROM TSYS_PROPOSE ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("   AND PROPS_ID = @PROPS_ID");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PROPS_ID")) isHasColumn = false;

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


       
        public static void TSYS_PROPOSE_UPD(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("UPDATE TSYS_PROPOSE ");
                    sbQuery.Append("   SET   PROPS_DATE = @PROPS_DATE ");
                    sbQuery.Append("       , ORG_CODE = @ORG_CODE ");
                    sbQuery.Append("       , EMP_CODE = @EMP_CODE ");
                    sbQuery.Append("       , PROC_NAME = @PROC_NAME ");
                    sbQuery.Append("       , TITLE = @TITLE ");
                    sbQuery.Append("       , AS_IS = @AS_IS ");
                    sbQuery.Append("       , TO_BE = @TO_BE ");
                    //sbQuery.Append("       , APP_EMP1 = @APP_EMP1 ");
                    //sbQuery.Append("       , APP_EMP2 = @APP_EMP2 ");
                    //sbQuery.Append("       , APP_EMP3 = @APP_EMP3 ");
                    //sbQuery.Append("       , APP_EMP4 = @APP_EMP4 ");
                    sbQuery.Append("       , EXP_EFFECT = @EXP_EFFECT ");
                    sbQuery.Append("       , EXP_FINISH_DATE = @EXP_FINISH_DATE ");
                    sbQuery.Append("       , FINISH_DATE = @FINISH_DATE ");

                    sbQuery.Append("       , REWARD = @REWARD ");
                    sbQuery.Append("       , REWARD_DATE = @REWARD_DATE ");
                    sbQuery.Append("       , GRADE = @GRADE ");
                    sbQuery.Append("       , SCOMMENT = @SCOMMENT ");
                
                    sbQuery.Append("       , MDFY_DATE = GETDATE() ");
                    sbQuery.Append("       , MDFY_EMP = @MDFY_EMP ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("   AND PROPS_ID = @PROPS_ID ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크                        
                        if (!UTIL.ValidColumn(row, "PROPS_ID")) isHasColumn = false;

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

        /// <summary>
        /// 승인자 업데이트
        /// </summary>
        /// <param name="dtParam"></param>
        /// <param name="bizExecute"></param>
        public static void TSYS_PROPOSE_UPD2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" UPDATE TSYS_PROPOSE ");
                    sbQuery.Append(" SET APP_STATUS = @APP_STATUS   ");
                    sbQuery.Append("  ,APP_EMP1 = @APP_EMP1 ");
                    sbQuery.Append("  ,APP_EMP_FLAG1 = @APP_EMP_FLAG1 ");
                    sbQuery.Append("  ,APP_EMP2 = @APP_EMP2 ");
                    sbQuery.Append("  ,APP_EMP_FLAG2 = @APP_EMP_FLAG2 ");
                    sbQuery.Append("  ,APP_EMP3 = @APP_EMP3 ");
                    sbQuery.Append("  ,APP_EMP_FLAG3 = @APP_EMP_FLAG3 ");
                    sbQuery.Append("  ,APP_EMP4 = @APP_EMP4 ");
                    sbQuery.Append("  ,APP_EMP_FLAG4 = @APP_EMP_FLAG4 ");
                    sbQuery.Append(" , MDFY_DATE =  GETDATE() ");
                    sbQuery.Append(" , MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("    AND PROPS_ID = @PROPS_ID  ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PROPS_ID")) isHasColumn = false;

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

        public static void TSYS_PROPOSE_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();


                    sbQuery.Append("INSERT INTO TSYS_PROPOSE ");
                    sbQuery.Append("( ");
                    sbQuery.Append("       PLT_CODE ");
                    sbQuery.Append("       , PROPS_ID ");
                    sbQuery.Append("       , PROPS_DATE ");
                    sbQuery.Append("       , EMP_CODE ");
                    sbQuery.Append("       , ORG_CODE ");
                    sbQuery.Append("       , PROC_NAME ");
                    sbQuery.Append("       , TITLE ");
                    sbQuery.Append("       , AS_IS ");
                    sbQuery.Append("       , TO_BE ");
                    sbQuery.Append("       , APP_EMP1 ");
                    sbQuery.Append("       , APP_EMP2 ");
                    sbQuery.Append("       , APP_EMP3 ");
                    sbQuery.Append("       , APP_EMP4 ");
                    sbQuery.Append("       , EXP_EFFECT");
                    sbQuery.Append("       , EXP_FINISH_DATE ");
                    sbQuery.Append("       , FINISH_DATE ");
                    sbQuery.Append("       , ISSU_FILE_ID ");
                    sbQuery.Append("       , SOL_FILE_ID ");
                    sbQuery.Append("       , RPT_FILE_ID ");
                    sbQuery.Append("       , REG_DATE ");
                    sbQuery.Append("       , REG_EMP ");
                    sbQuery.Append("       , DATA_FLAG ");
                    sbQuery.Append(") ");
                    sbQuery.Append("VALUES ");
                    sbQuery.Append("( ");
                    sbQuery.Append("         @PLT_CODE ");
                    sbQuery.Append("       , @PROPS_ID ");
                    sbQuery.Append("       , @PROPS_DATE ");
                    sbQuery.Append("       , @EMP_CODE ");
                    sbQuery.Append("       , @ORG_CODE ");
                    sbQuery.Append("       , @PROC_NAME ");
                    sbQuery.Append("       , @TITLE ");
                    sbQuery.Append("       , @AS_IS ");
                    sbQuery.Append("       , @TO_BE ");
                    sbQuery.Append("       , @APP_EMP1 ");
                    sbQuery.Append("       , @APP_EMP2 ");
                    sbQuery.Append("       , @APP_EMP3 ");
                    sbQuery.Append("       , @APP_EMP4 ");
                    sbQuery.Append("       , @EXP_EFFECT");
                    sbQuery.Append("       , @EXP_FINISH_DATE ");
                    sbQuery.Append("       , @FINISH_DATE ");
                    sbQuery.Append("       , @ISSU_FILE_ID ");
                    sbQuery.Append("       , @SOL_FILE_ID ");
                    sbQuery.Append("       , @RPT_FILE_ID ");
                    sbQuery.Append("       , GETDATE() ");
                    sbQuery.Append("       , @REG_EMP ");
                    sbQuery.Append("       , 0 ");
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

        public static void TSYS_PROPOSE_UDE(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("UPDATE TSYS_PROPOSE ");
                    sbQuery.Append("  SET   DEL_DATE = GETDATE() ");
                    sbQuery.Append("      , DEL_EMP = @DEL_EMP ");
                    sbQuery.Append("      , DATA_FLAG = 2 ");
                    sbQuery.Append("WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("  AND PROPS_ID = @PROPS_ID ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크                        
                        if (!UTIL.ValidColumn(row, "PROPS_ID")) isHasColumn = false;

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

    public class TSYS_PROPOSE_QUERY
    {
      
        public static DataTable TSYS_PROPOSE_QUERY1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT P.PLT_CODE  ");
                    sbQuery.Append("       , P.PROPS_ID ");
                    sbQuery.Append("       , P.PROPS_DATE ");
                    sbQuery.Append("       , P.EMP_CODE ");
                    sbQuery.Append("       , P.ORG_CODE ");
                    sbQuery.Append("       , P.PROC_NAME ");
                    sbQuery.Append("       , P.TITLE ");
                    sbQuery.Append("       , P.AS_IS ");
                    sbQuery.Append("       , P.TO_BE ");
                    sbQuery.Append("       , P.EXP_EFFECT");
                    sbQuery.Append("       , P.EXP_FINISH_DATE ");
                    sbQuery.Append("       , P.FINISH_DATE ");
                    sbQuery.Append("       , CASE ISNULL(P.FINISH_DATE,'') WHEN '' THEN '' ELSE '완료' END AS PROPS_STATE ");
                    sbQuery.Append("       , P.ISSU_FILE_ID ");
                    sbQuery.Append("       , P.SOL_FILE_ID ");
                    sbQuery.Append("       , P.RPT_FILE_ID ");
                    sbQuery.Append("       , P.REWARD ");
                    sbQuery.Append("       , P.REWARD_DATE ");
                    sbQuery.Append("       , P.GRADE ");
                    sbQuery.Append("       , P.SCOMMENT ");
                    sbQuery.Append(" ,ISNULL(P.APP_EMP1,APP.APP_EMP1) AS APP_EMP1");
                    sbQuery.Append(" ,ISNULL(P.APP_EMP_FLAG1,'0') AS APP_EMP_FLAG1");

                    sbQuery.Append(" ,ISNULL(P.APP_EMP2,APP.APP_EMP2) AS APP_EMP2");
                    sbQuery.Append(" ,ISNULL(P.APP_EMP_FLAG2,'0') AS APP_EMP_FLAG2");

                    sbQuery.Append(" ,ISNULL(P.APP_EMP3,APP.APP_EMP3) AS APP_EMP3");
                    sbQuery.Append(" ,ISNULL(P.APP_EMP_FLAG3,'0') AS APP_EMP_FLAG3");

                    sbQuery.Append(" ,ISNULL(P.APP_EMP4,APP.APP_EMP4) AS APP_EMP4");
                    sbQuery.Append(" ,ISNULL(P.APP_EMP_FLAG4,'0') AS APP_EMP_FLAG4");

                    sbQuery.Append("       , P.REG_DATE ");
                    sbQuery.Append("       , P.REG_EMP ");
                    sbQuery.Append("       , P.MDFY_DATE ");
                    sbQuery.Append("       , P.MDFY_EMP ");
                    sbQuery.Append("       , P.DEL_DATE ");
                    sbQuery.Append("       , P.DEL_EMP ");
                    sbQuery.Append("       , P.DATA_FLAG ");
                    sbQuery.Append("  FROM TSYS_PROPOSE P");
                    sbQuery.Append(" LEFT JOIN TSTD_APP_EMP APP ");
                    sbQuery.Append(" ON P.PLT_CODE = APP.PLT_CODE");
                    sbQuery.Append(" AND APP.APP_TYPE = 'PRS' ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;

                        if (isHasColumn == true)
                        {
                            StringBuilder sbWhere = new StringBuilder();

                            sbWhere.Append(" WHERE P.DATA_FLAG = 0 ");

                            sbWhere.Append(UTIL.GetWhere(row, "@PLT_CODE", " P.PLT_CODE = @PLT_CODE"));
                            sbWhere.Append(UTIL.GetWhere(row, "@EMP_CODE", " P.REG_EMP = @EMP_CODE"));
                            sbWhere.Append(UTIL.GetWhere(row, "@TITLE_LIKE", "P.TITLE LIKE '%' + @TITLE_LIKE + '%'"));
                            sbWhere.Append(UTIL.GetWhere(row, "@S_PROPS_DATE, @E_PROPS_DATE", " P.PROPS_DATE BETWEEN @S_PROPS_DATE AND @E_PROPS_DATE "));
                            sbWhere.Append(UTIL.GetWhere(row, "@S_FINISH_DATE, @E_FINISH_DATE", " P.FINISH_DATE BETWEEN @S_FINISH_DATE AND @E_FINISH_DATE "));

                            sbWhere.Append(" ORDER BY P.PROPS_DATE DESC ");

                            DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString() + sbWhere.ToString()).Copy();

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

        public static DataTable TSYS_PROPOSE_QUERY2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT P.PLT_CODE  ");
                    sbQuery.Append("       , P.PROPS_ID ");
                    sbQuery.Append("       , P.PROPS_DATE ");
                    sbQuery.Append("       , P.EMP_CODE ");
                    sbQuery.Append("       , P.ORG_CODE ");
                    sbQuery.Append("       , P.PROC_NAME ");
                    sbQuery.Append("       , P.TITLE ");
                    sbQuery.Append("       , P.AS_IS ");
                    sbQuery.Append("       , P.TO_BE ");
                    sbQuery.Append("       , P.EXP_EFFECT");
                    sbQuery.Append("       , P.EXP_FINISH_DATE ");
                    sbQuery.Append("       , P.FINISH_DATE ");
                    sbQuery.Append("       , CASE ISNULL(P.FINISH_DATE,'') WHEN '' THEN '' ELSE '완료' END AS PROPS_STATE ");
                    sbQuery.Append("       , P.ISSU_FILE_ID ");
                    sbQuery.Append("       , P.SOL_FILE_ID ");
                    sbQuery.Append("       , P.RPT_FILE_ID ");
                    sbQuery.Append("       , P.REWARD ");
                    sbQuery.Append("       , P.REWARD_DATE ");
                    sbQuery.Append("       , P.GRADE ");
                    sbQuery.Append("       , P.SCOMMENT ");
                    sbQuery.Append(" ,ISNULL(P.APP_EMP1,APP.APP_EMP1) AS APP_EMP1");
                    sbQuery.Append(" ,ISNULL(P.APP_EMP_FLAG1,'0') AS APP_EMP_FLAG1");

                    sbQuery.Append(" ,ISNULL(P.APP_EMP2,APP.APP_EMP2) AS APP_EMP2");
                    sbQuery.Append(" ,ISNULL(P.APP_EMP_FLAG2,'0') AS APP_EMP_FLAG2");

                    sbQuery.Append(" ,ISNULL(P.APP_EMP3,APP.APP_EMP3) AS APP_EMP3");
                    sbQuery.Append(" ,ISNULL(P.APP_EMP_FLAG3,'0') AS APP_EMP_FLAG3");

                    sbQuery.Append(" ,ISNULL(P.APP_EMP4,APP.APP_EMP4) AS APP_EMP4");
                    sbQuery.Append(" ,ISNULL(P.APP_EMP_FLAG4,'0') AS APP_EMP_FLAG4");
                    sbQuery.Append("       , P.REG_DATE ");
                    sbQuery.Append("       , P.REG_EMP ");
                    sbQuery.Append("       , P.MDFY_DATE ");
                    sbQuery.Append("       , P.MDFY_EMP ");
                    sbQuery.Append("       , P.DEL_DATE ");
                    sbQuery.Append("       , P.DEL_EMP ");
                    sbQuery.Append("       , P.DATA_FLAG ");
                    sbQuery.Append("  FROM TSYS_PROPOSE P");
                    sbQuery.Append(" LEFT JOIN TSTD_APP_EMP APP ");
                    sbQuery.Append(" ON P.PLT_CODE = APP.PLT_CODE");
                    sbQuery.Append(" AND APP.APP_TYPE = 'PRS' ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;

                        if (isHasColumn == true)
                        {
                            StringBuilder sbWhere = new StringBuilder();

                            sbWhere.Append(" WHERE P.DATA_FLAG = 0 ");

                            sbWhere.Append(UTIL.GetWhere(row, "@PLT_CODE", " P.PLT_CODE = @PLT_CODE"));
                            sbWhere.Append(UTIL.GetWhere(row, "@EMP_CODE", " P.REG_EMP = @EMP_CODE"));
                            sbWhere.Append(UTIL.GetWhere(row, "@TITLE_LIKE", "P.TITLE LIKE '%' + @TITLE_LIKE + '%'"));
                            sbWhere.Append(UTIL.GetWhere(row, "@S_PROPS_DATE, @E_PROPS_DATE", " P.PROPS_DATE BETWEEN @S_PROPS_DATE AND @E_PROPS_DATE "));
                            sbWhere.Append(UTIL.GetWhere(row, "@S_FINISH_DATE, @E_FINISH_DATE", " P.FINISH_DATE BETWEEN @S_FINISH_DATE AND @E_FINISH_DATE "));

                            string sQuery = "((ISNULL(P.APP_EMP1,APP.APP_EMP1) = @REG_EMP AND ISNULL(P.APP_EMP_FLAG1,'0') = '0')";
                            sQuery += " OR (ISNULL(P.APP_EMP2,APP.APP_EMP2) = @REG_EMP AND ISNULL(P.APP_EMP_FLAG1,'0') = '1' AND ISNULL(P.APP_EMP_FLAG2,'0') = '0')";
                            sQuery += " OR (ISNULL(P.APP_EMP3,APP.APP_EMP3) = @REG_EMP AND ISNULL(P.APP_EMP_FLAG1,'0') = '1' AND ISNULL(P.APP_EMP_FLAG2,'0') = '1' AND ISNULL(P.APP_EMP_FLAG3,'0') = '0')";
                            sQuery += " OR (ISNULL(P.APP_EMP4,APP.APP_EMP4) = @REG_EMP AND ISNULL(P.APP_EMP_FLAG1,'0') = '1' AND ISNULL(P.APP_EMP_FLAG2,'0') = '1' AND ISNULL(P.APP_EMP_FLAG3,'0') = '1' AND ISNULL(P.APP_EMP_FLAG4,'0') = '0'))";

                            sbWhere.Append(UTIL.GetWhere(row, "@REG_EMP", sQuery));

                            sbWhere.Append(" ORDER BY P.PROPS_DATE DESC ");

                            DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString() + sbWhere.ToString()).Copy();

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

        public static DataTable TSYS_PROPOSE_QUERY3(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT P.PLT_CODE  ");
                    sbQuery.Append("       , P.PROPS_ID ");
                    sbQuery.Append("       , P.PROPS_DATE ");
                    sbQuery.Append("       , P.EMP_CODE ");
                    sbQuery.Append("       , P.ORG_CODE ");
                    sbQuery.Append("       , P.PROC_NAME ");
                    sbQuery.Append("       , P.TITLE ");
                    sbQuery.Append("       , P.AS_IS ");
                    sbQuery.Append("       , P.TO_BE ");
                    sbQuery.Append("       , P.EXP_EFFECT");
                    sbQuery.Append("       , P.EXP_FINISH_DATE ");
                    sbQuery.Append("       , P.FINISH_DATE ");
                    sbQuery.Append("       , CASE ISNULL(P.FINISH_DATE,'') WHEN '' THEN '' ELSE '완료' END AS PROPS_STATE ");
                    sbQuery.Append("       , P.ISSU_FILE_ID ");
                    sbQuery.Append("       , P.SOL_FILE_ID ");
                    sbQuery.Append("       , P.RPT_FILE_ID ");
                    sbQuery.Append("       , P.REWARD ");
                    sbQuery.Append("       , P.REWARD_DATE ");
                    sbQuery.Append("       , P.GRADE ");
                    sbQuery.Append("       , P.SCOMMENT ");
                    sbQuery.Append(" ,ISNULL(P.APP_EMP1,APP.APP_EMP1) AS APP_EMP1");
                    sbQuery.Append(" ,ISNULL(P.APP_EMP_FLAG1,'0') AS APP_EMP_FLAG1");

                    sbQuery.Append(" ,ISNULL(P.APP_EMP2,APP.APP_EMP2) AS APP_EMP2");
                    sbQuery.Append(" ,ISNULL(P.APP_EMP_FLAG2,'0') AS APP_EMP_FLAG2");

                    sbQuery.Append(" ,ISNULL(P.APP_EMP3,APP.APP_EMP3) AS APP_EMP3");
                    sbQuery.Append(" ,ISNULL(P.APP_EMP_FLAG3,'0') AS APP_EMP_FLAG3");

                    sbQuery.Append(" ,ISNULL(P.APP_EMP4,APP.APP_EMP4) AS APP_EMP4");
                    sbQuery.Append(" ,ISNULL(P.APP_EMP_FLAG4,'0') AS APP_EMP_FLAG4");
                    sbQuery.Append("       , P.REG_DATE ");
                    sbQuery.Append("       , P.REG_EMP ");
                    sbQuery.Append("       , P.MDFY_DATE ");
                    sbQuery.Append("       , P.MDFY_EMP ");
                    sbQuery.Append("       , P.DEL_DATE ");
                    sbQuery.Append("       , P.DEL_EMP ");
                    sbQuery.Append("       , P.DATA_FLAG ");
                    sbQuery.Append("  FROM TSYS_PROPOSE P");
                    sbQuery.Append(" LEFT JOIN TSTD_APP_EMP APP ");
                    sbQuery.Append(" ON P.PLT_CODE = APP.PLT_CODE");
                    sbQuery.Append(" AND APP.APP_TYPE = 'PRS' ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;

                        if (isHasColumn == true)
                        {
                            StringBuilder sbWhere = new StringBuilder();

                            sbWhere.Append(" WHERE P.DATA_FLAG = 0 ");

                            sbWhere.Append(UTIL.GetWhere(row, "@PLT_CODE", " P.PLT_CODE = @PLT_CODE"));
                            sbWhere.Append(UTIL.GetWhere(row, "@EMP_CODE", " P.REG_EMP = @EMP_CODE"));
                            sbWhere.Append(UTIL.GetWhere(row, "@TITLE_LIKE", "P.TITLE LIKE '%' + @TITLE_LIKE + '%'"));
                            sbWhere.Append(UTIL.GetWhere(row, "@S_PROPS_DATE, @E_PROPS_DATE", " P.PROPS_DATE BETWEEN @S_PROPS_DATE AND @E_PROPS_DATE "));
                            sbWhere.Append(UTIL.GetWhere(row, "@S_FINISH_DATE, @E_FINISH_DATE", " P.FINISH_DATE BETWEEN @S_FINISH_DATE AND @E_FINISH_DATE "));

                            string sQuery = "((ISNULL(P.APP_EMP1,APP.APP_EMP1) = @REG_EMP AND ISNULL(P.APP_EMP_FLAG1,'0') = '1' AND ISNULL(P.APP_EMP_FLAG2,'0') = '0' AND ISNULL(P.APP_EMP_FLAG3,'0') = '0' AND ISNULL(P.APP_EMP_FLAG4,'0') = '0' )";
                            sQuery += " OR (ISNULL(P.APP_EMP2,APP.APP_EMP2) = @REG_EMP AND ISNULL(P.APP_EMP_FLAG2,'0') = '1' AND ISNULL(P.APP_EMP_FLAG3,'0') = '0' AND ISNULL(P.APP_EMP_FLAG4,'0') = '0')";
                            sQuery += " OR (ISNULL(P.APP_EMP3,APP.APP_EMP3) = @REG_EMP AND ISNULL(P.APP_EMP_FLAG3,'0') = '1' AND ISNULL(P.APP_EMP_FLAG4,'0') = '0')";
                            sQuery += " OR (ISNULL(P.APP_EMP4,APP.APP_EMP4) = @REG_EMP AND ISNULL(P.APP_EMP_FLAG4,'0') = '1'))";

                            sbWhere.Append(UTIL.GetWhere(row, "@REG_EMP", sQuery));

                            sbWhere.Append(" ORDER BY P.PROPS_DATE DESC ");

                            DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString() + sbWhere.ToString()).Copy();

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

        public static DataTable TSYS_PROPOSE_QUERY4(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT P.PLT_CODE  ");
                    sbQuery.Append("       , P.PROPS_ID ");
                    sbQuery.Append("       , P.PROPS_DATE ");
                    sbQuery.Append("       , P.EMP_CODE ");
                    sbQuery.Append("       , P.ORG_CODE ");
                    sbQuery.Append("       , P.PROC_NAME ");
                    sbQuery.Append("       , P.TITLE ");
                    sbQuery.Append("       , P.AS_IS ");
                    sbQuery.Append("       , P.TO_BE ");
                    sbQuery.Append("       , P.EXP_EFFECT");
                    sbQuery.Append("       , P.EXP_FINISH_DATE ");
                    sbQuery.Append("       , P.FINISH_DATE ");
                    sbQuery.Append("       , CASE ISNULL(P.FINISH_DATE,'') WHEN '' THEN '' ELSE '완료' END AS PROPS_STATE ");
                    sbQuery.Append("       , P.ISSU_FILE_ID ");
                    sbQuery.Append("       , P.SOL_FILE_ID ");
                    sbQuery.Append("       , P.RPT_FILE_ID ");
                    sbQuery.Append("       , P.REWARD ");
                    sbQuery.Append("       , P.REWARD_DATE ");
                    sbQuery.Append("       , P.GRADE ");
                    sbQuery.Append("       , P.SCOMMENT ");
                    sbQuery.Append(" ,ISNULL(P.APP_EMP1,APP.APP_EMP1) AS APP_EMP1");
                    sbQuery.Append(" ,ISNULL(P.APP_EMP_FLAG1,'0') AS APP_EMP_FLAG1");

                    sbQuery.Append(" ,ISNULL(P.APP_EMP2,APP.APP_EMP2) AS APP_EMP2");
                    sbQuery.Append(" ,ISNULL(P.APP_EMP_FLAG2,'0') AS APP_EMP_FLAG2");

                    sbQuery.Append(" ,ISNULL(P.APP_EMP3,APP.APP_EMP3) AS APP_EMP3");
                    sbQuery.Append(" ,ISNULL(P.APP_EMP_FLAG3,'0') AS APP_EMP_FLAG3");

                    sbQuery.Append(" ,ISNULL(P.APP_EMP4,APP.APP_EMP4) AS APP_EMP4");
                    sbQuery.Append(" ,ISNULL(P.APP_EMP_FLAG4,'0') AS APP_EMP_FLAG4");
                    sbQuery.Append("       , P.REG_DATE ");
                    sbQuery.Append("       , P.REG_EMP ");
                    sbQuery.Append("       , P.MDFY_DATE ");
                    sbQuery.Append("       , P.MDFY_EMP ");
                    sbQuery.Append("       , P.DEL_DATE ");
                    sbQuery.Append("       , P.DEL_EMP ");
                    sbQuery.Append("       , P.DATA_FLAG ");
                    sbQuery.Append("  FROM TSYS_PROPOSE P");
                    sbQuery.Append(" LEFT JOIN TSTD_APP_EMP APP ");
                    sbQuery.Append(" ON P.PLT_CODE = APP.PLT_CODE");
                    sbQuery.Append(" AND APP.APP_TYPE = 'PRS' ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;

                        if (isHasColumn == true)
                        {
                            StringBuilder sbWhere = new StringBuilder();

                            sbWhere.Append(" WHERE P.DATA_FLAG = 0 ");

                            sbWhere.Append(UTIL.GetWhere(row, "@PLT_CODE", " P.PLT_CODE = @PLT_CODE"));
                            sbWhere.Append(UTIL.GetWhere(row, "@EMP_CODE", " P.REG_EMP = @EMP_CODE"));
                            sbWhere.Append(UTIL.GetWhere(row, "@TITLE_LIKE", "P.TITLE LIKE '%' + @TITLE_LIKE + '%'"));
                            sbWhere.Append(UTIL.GetWhere(row, "@S_PROPS_DATE, @E_PROPS_DATE", " P.PROPS_DATE BETWEEN @S_PROPS_DATE AND @E_PROPS_DATE "));
                            sbWhere.Append(UTIL.GetWhere(row, "@S_FINISH_DATE, @E_FINISH_DATE", " P.FINISH_DATE BETWEEN @S_FINISH_DATE AND @E_FINISH_DATE "));

                            string sQuery = "((ISNULL(P.APP_EMP1,APP.APP_EMP1) = @REG_EMP AND ISNULL(P.APP_EMP_FLAG1,'0') = '2' AND ISNULL(P.APP_EMP_FLAG2,'0') = '0' AND ISNULL(P.APP_EMP_FLAG3,'0') = '0' AND ISNULL(P.APP_EMP_FLAG4,'0') = '0' )";
                            sQuery += " OR (ISNULL(P.APP_EMP2,APP.APP_EMP2) = @REG_EMP AND ISNULL(P.APP_EMP_FLAG2,'0') = '2' AND ISNULL(P.APP_EMP_FLAG3,'0') = '0' AND ISNULL(P.APP_EMP_FLAG4,'0') = '0')";
                            sQuery += " OR (ISNULL(P.APP_EMP3,APP.APP_EMP3) = @REG_EMP AND ISNULL(P.APP_EMP_FLAG3,'0') = '2' AND ISNULL(P.APP_EMP_FLAG4,'0') = '0')";
                            sQuery += " OR (ISNULL(P.APP_EMP4,APP.APP_EMP4) = @REG_EMP AND ISNULL(P.APP_EMP_FLAG4,'0') = '2'))";

                            sbWhere.Append(UTIL.GetWhere(row, "@REG_EMP", sQuery));

                            sbWhere.Append(" ORDER BY P.PROPS_DATE DESC ");

                            DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString() + sbWhere.ToString()).Copy();

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
}
