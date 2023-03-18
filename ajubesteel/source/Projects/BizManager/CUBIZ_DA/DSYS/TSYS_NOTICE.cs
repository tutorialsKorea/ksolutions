using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace DSYS
{
    public class TSYS_NOTICE_QUERY
    {
        public static DataTable TSYS_NOTICE_QUERY2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("  SELECT N.PLT_CODE ");
                    sbQuery.Append("       ,N.NOTICE_ID ");
                    sbQuery.Append("       ,N.ACC_LEVEL ");
                    sbQuery.Append("       ,N.TITLE ");
                    sbQuery.Append("       ,N.CONTENTS ");
                    sbQuery.Append("       ,N.REG_DATE ");
                    sbQuery.Append("       ,N.REG_EMP ");
                    sbQuery.Append("       ,REG.EMP_NAME AS REG_EMP_NAME ");
                    sbQuery.Append("       ,N.MDFY_DATE ");
                    sbQuery.Append("       ,N.MDFY_EMP ");
                    sbQuery.Append("       ,MDFY.EMP_NAME AS MDFY_EMP_NAME ");
                    sbQuery.Append("   FROM TSYS_NOTICE N ");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE REG ");
                    sbQuery.Append(" ON N.PLT_CODE = REG.PLT_CODE ");
                    sbQuery.Append(" AND N.REG_EMP = REG.EMP_CODE ");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE MDFY ");
                    sbQuery.Append(" ON N.PLT_CODE = MDFY.PLT_CODE ");
                    sbQuery.Append(" AND N.MDFY_EMP = MDFY.EMP_CODE ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;

                        if (isHasColumn == true)
                        {

                            sbQuery.Replace("@PLT_CODE", UTIL.GetValidValue(row, "PLT_CODE").ToString());
                            sbQuery.Replace("@NOTICE_ID", UTIL.GetValidValue(row, "NOTICE_ID").ToString());
                            sbQuery.Replace("@TITLE_LIKE", UTIL.GetValidValue(row, "TITLE_LIKE").ToString());
                            sbQuery.Replace("@VIEW_EMP", UTIL.GetValidValue(row, "VIEW_EMP").ToString());

                            StringBuilder sbWhere = new StringBuilder();

                            sbWhere.Append(" WHERE N.DATA_FLAG = 0 ");

                            sbWhere.Append(UTIL.GetWhere(row, "@PLT_CODE", "N.PLT_CODE = @PLT_CODE"));
                            sbWhere.Append(UTIL.GetWhere(row, "@NOTICE_ID", "N.NOTICE_ID = @NOTICE_ID"));
                            sbWhere.Append(UTIL.GetWhere(row, "@TITLE_LIKE", "N.TITLE LIKE '%' + @TITLE_LIKE + '%'"));
                            sbWhere.Append(UTIL.GetWhere(row, "@S_REG_DATE", " N.REG_DATE BETWEEN @S_REG_DATE AND @E_REG_DATE "));

                            string conView = " ( N.ACC_LEVEL = 'P' ";
                            conView += " OR ";
                            conView += " N.ORG_CODE IN ";                           
                            conView += " ( SELECT ORG_CODE FROM TSTD_EMPLOYEE ";
                            conView += "   WHERE PLT_CODE = N.PLT_CODE ";
                            conView += "     AND EMP_CODE = @VIEW_EMP ";
                            conView += "  )) ";
                                                                                
                            sbWhere.Append(UTIL.GetWhere(row, "@VIEW_EMP", conView));

                            
                            DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString() + sbWhere.ToString(), row).Copy();

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


        public static DataTable TSYS_NOTICE_QUERY3(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("  SELECT N.PLT_CODE ");
                    sbQuery.Append("       ,N.NOTICE_ID ");
                    sbQuery.Append("       ,N.ACC_LEVEL ");
                    sbQuery.Append("       ,N.TITLE ");
                    sbQuery.Append("       ,N.CONTENTS ");
                    sbQuery.Append("       ,N.ORG_CODES ");
                    sbQuery.Append("       ,N.REG_DATE ");
                    sbQuery.Append("       ,N.REG_EMP ");
                    sbQuery.Append("       ,REG.EMP_NAME AS REG_EMP_NAME ");
                    sbQuery.Append("       ,N.MDFY_DATE ");
                    sbQuery.Append("       ,N.MDFY_EMP ");
                    sbQuery.Append("       ,MDFY.EMP_NAME AS MDFY_EMP_NAME ");
                    sbQuery.Append("   FROM TSYS_NOTICE N ");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE REG ");
                    sbQuery.Append(" ON N.PLT_CODE = REG.PLT_CODE ");
                    sbQuery.Append(" AND N.REG_EMP = REG.EMP_CODE ");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE MDFY ");
                    sbQuery.Append(" ON N.PLT_CODE = MDFY.PLT_CODE ");
                    sbQuery.Append(" AND N.MDFY_EMP = MDFY.EMP_CODE ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;

                        if (isHasColumn == true)
                        {

                            sbQuery.Replace("@PLT_CODE", UTIL.GetValidValue(row, "PLT_CODE").ToString());
                            sbQuery.Replace("@NOTICE_ID", UTIL.GetValidValue(row, "NOTICE_ID").ToString());
                            sbQuery.Replace("@TITLE_LIKE", UTIL.GetValidValue(row, "TITLE_LIKE").ToString());
                            sbQuery.Replace("@VIEW_EMP", UTIL.GetValidValue(row, "VIEW_EMP").ToString());

                            StringBuilder sbWhere = new StringBuilder();

                            sbWhere.Append(" WHERE N.DATA_FLAG = 0 ");

                            sbWhere.Append(UTIL.GetWhere(row, "@PLT_CODE", "N.PLT_CODE = @PLT_CODE"));
                            sbWhere.Append(UTIL.GetWhere(row, "@NOTICE_ID", "N.NOTICE_ID = @NOTICE_ID"));
                            sbWhere.Append(UTIL.GetWhere(row, "@TITLE_LIKE", "N.TITLE LIKE '%' + @TITLE_LIKE + '%'"));
                            sbWhere.Append(UTIL.GetWhere(row, "@S_REG_DATE", " N.REG_DATE BETWEEN @S_REG_DATE AND @E_REG_DATE "));

                            string conView = " ( N.ACC_LEVEL = 'P' ";
                            conView += " OR ";
                            conView += " N.ORG_CODES LIKE '%' + ";
                            conView += " ( SELECT ORG_CODE FROM TSTD_EMPLOYEE ";
                            conView += "   WHERE PLT_CODE = N.PLT_CODE ";
                            conView += "     AND EMP_CODE = @VIEW_EMP ";
                            conView += "  )+ '%') ";

                            sbWhere.Append(UTIL.GetWhere(row, "@VIEW_EMP", conView));


                            DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString() + sbWhere.ToString(), row).Copy();

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


    public class TSYS_NOTICE
    {
        public static DataTable TSYS_NOTICE_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("SELECT   PLT_CODE ");
                    sbQuery.Append("       , NOTICE_ID ");
                    sbQuery.Append("       , TITLE ");
                    sbQuery.Append("       , CONTENTS ");
                    sbQuery.Append("       , ACC_LEVEL ");
                    sbQuery.Append("       , ORG_CODE ");
                    sbQuery.Append("       , REG_DATE ");
                    sbQuery.Append("       , REG_EMP ");
                    sbQuery.Append("       , MDFY_DATE ");
                    sbQuery.Append("       , MDFY_EMP ");
                    sbQuery.Append("       , DEL_DATE ");
                    sbQuery.Append("       , DEL_EMP ");
                    sbQuery.Append("       , DATA_FLAG ");
                    sbQuery.Append("  FROM TSYS_NOTICE ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("   AND NOTICE_ID = @NOTICE_ID ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "NOTICE_ID")) isHasColumn = false;

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


        public static void TSYS_NOTICE_UPD(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("UPDATE TSYS_NOTICE ");
                    sbQuery.Append("   SET   TITLE = @TITLE ");
                    sbQuery.Append("       , CONTENTS = @CONTENTS ");
                    sbQuery.Append("       , ACC_LEVEL = @ACC_LEVEL ");
                    sbQuery.Append("       , ORG_CODE = @ORG_CODE ");
                    sbQuery.Append("       , MDFY_DATE = GETDATE() ");
                    sbQuery.Append("       , MDFY_EMP = @MDFY_EMP ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("   AND NOTICE_ID = @NOTICE_ID ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크                        
                        if (!UTIL.ValidColumn(row, "NOTICE_ID")) isHasColumn = false;

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

        
        /// 수신부서 다수 등록 pkd
        public static void TSYS_NOTICE_UPD2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("UPDATE TSYS_NOTICE ");
                    sbQuery.Append("   SET   TITLE = @TITLE ");
                    sbQuery.Append("       , CONTENTS = @CONTENTS ");
                    sbQuery.Append("       , ACC_LEVEL = @ACC_LEVEL ");
                    sbQuery.Append("       , ORG_CODES = @ORG_CODES ");
                    sbQuery.Append("       , MDFY_DATE = GETDATE() ");
                    sbQuery.Append("       , MDFY_EMP = @MDFY_EMP ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("   AND NOTICE_ID = @NOTICE_ID ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크                        
                        if (!UTIL.ValidColumn(row, "NOTICE_ID")) isHasColumn = false;

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


        public static void TSYS_NOTICE_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();


                    sbQuery.Append("INSERT INTO TSYS_NOTICE ");
                    sbQuery.Append("( ");
                    sbQuery.Append("       PLT_CODE ");
                    sbQuery.Append("     , NOTICE_ID ");
                    sbQuery.Append("     , TITLE ");
                    sbQuery.Append("     , CONTENTS ");
                    sbQuery.Append("     , ACC_LEVEL ");
                    sbQuery.Append("     , ORG_CODE ");
                    sbQuery.Append("     , REG_DATE ");
                    sbQuery.Append("     , REG_EMP ");
                    sbQuery.Append("     , DATA_FLAG ");
                    sbQuery.Append(") ");
                    sbQuery.Append("VALUES ");
                    sbQuery.Append("( ");
                    sbQuery.Append("       @PLT_CODE ");
                    sbQuery.Append("     , @NOTICE_ID ");
                    sbQuery.Append("     , @TITLE ");
                    sbQuery.Append("     , @CONTENTS ");
                    sbQuery.Append("     , @ACC_LEVEL ");
                    sbQuery.Append("     , @ORG_CODE ");
                    sbQuery.Append("     , GETDATE() ");
                    sbQuery.Append("     , @REG_EMP ");
                    sbQuery.Append("     , 0 ");
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



        // 수신부서 
        public static void TSYS_NOTICE_INS2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();


                    sbQuery.Append("INSERT INTO TSYS_NOTICE ");
                    sbQuery.Append("( ");
                    sbQuery.Append("       PLT_CODE ");
                    sbQuery.Append("     , NOTICE_ID ");
                    sbQuery.Append("     , TITLE ");
                    sbQuery.Append("     , CONTENTS ");
                    sbQuery.Append("     , ACC_LEVEL ");
                    sbQuery.Append("     , ORG_CODES ");
                    sbQuery.Append("     , REG_DATE ");
                    sbQuery.Append("     , REG_EMP ");
                    sbQuery.Append("     , DATA_FLAG ");
                    sbQuery.Append(") ");
                    sbQuery.Append("VALUES ");
                    sbQuery.Append("( ");
                    sbQuery.Append("       @PLT_CODE ");
                    sbQuery.Append("     , @NOTICE_ID ");
                    sbQuery.Append("     , @TITLE ");
                    sbQuery.Append("     , @CONTENTS ");
                    sbQuery.Append("     , @ACC_LEVEL ");
                    sbQuery.Append("     , @ORG_CODES ");
                    sbQuery.Append("     , GETDATE() ");
                    sbQuery.Append("     , @REG_EMP ");
                    sbQuery.Append("     , 0 ");
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



        public static void TSYS_NOTICE_UDE(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                     sbQuery.Append("UPDATE TSYS_NOTICE ");
                     sbQuery.Append("  SET   DEL_DATE = GETDATE() ");
                     sbQuery.Append("      , DEL_EMP = @DEL_EMP ");
                     sbQuery.Append("      , DATA_FLAG = 2 ");
                     sbQuery.Append("WHERE PLT_CODE = @PLT_CODE  ");
                     sbQuery.Append("  AND NOTICE_ID = @NOTICE_ID ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크                        
                        if (!UTIL.ValidColumn(row, "NOTICE_ID")) isHasColumn = false;

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
