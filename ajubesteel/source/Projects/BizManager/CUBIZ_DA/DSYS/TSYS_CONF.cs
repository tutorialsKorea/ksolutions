using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace DSYS
{
    public class TSYS_CONF
    {
        public static DataTable TSYS_CONF_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {

            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT PLT_CODE ");
                    sbQuery.Append(" , CONF_SECTION");
                    sbQuery.Append(" , CONF_NAME ");
                    sbQuery.Append(" , CONF_VALUE");
                    sbQuery.Append(" , REG_DATE");
                    sbQuery.Append(" , REG_EMP ");
                    sbQuery.Append(" , MDFY_DATE ");
                    sbQuery.Append(" , MDFY_EMP");
                    sbQuery.Append(" FROM TSYS_CONF");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND CONF_SECTION = @CONF_SECTION");
                    sbQuery.Append(" AND CONF_NAME = @CONF_NAME");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "CONF_SECTION")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "CONF_NAME")) isHasColumn = false;

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

        public static DataTable TSYS_CONF_SER2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {

            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT PLT_CODE ");
                    sbQuery.Append(" , CONF_SECTION");
                    sbQuery.Append(" , CONF_NAME ");
                    sbQuery.Append(" , CONF_VALUE");
                    sbQuery.Append(" , REG_DATE");
                    sbQuery.Append(" , REG_EMP ");
                    sbQuery.Append(" , MDFY_DATE ");
                    sbQuery.Append(" , MDFY_EMP");
                    sbQuery.Append(" FROM TSYS_CONF");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND CONF_SECTION = @CONF_SECTION");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "CONF_SECTION")) isHasColumn = false;
              
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

        public static void TSYS_CONF_DEL(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("DELETE FROM TSYS_CONF");                    
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND CONF_SECTION = @CONF_SECTION");
                    sbQuery.Append(" AND CONF_NAME = @CONF_NAME");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "CONF_SECTION")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "CONF_NAME")) isHasColumn = false;

                        if (isHasColumn == true)
                        {                                                        
                            bizExecute.executeUpdateQuery(sbQuery.ToString(),row);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }        

        public static void TSYS_CONF_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" INSERT INTO TSYS_CONF");
                    sbQuery.Append(" (");
                    sbQuery.Append(" PLT_CODE ");
                    sbQuery.Append(" , CONF_SECTION ");
                    sbQuery.Append(" , CONF_NAME");
                    sbQuery.Append(" , CONF_VALUE ");
                    sbQuery.Append(" , REG_DATE ");
                    sbQuery.Append(" , REG_EMP");
                    sbQuery.Append(" )");
                    sbQuery.Append(" VALUES ");
                    sbQuery.Append(" (");
                    sbQuery.Append(" @PLT_CODE");
                    sbQuery.Append(" , @CONF_SECTION");
                    sbQuery.Append(" , @CONF_NAME ");
                    sbQuery.Append(" , @CONF_VALUE");
                    sbQuery.Append(" ,GETDATE()");
                    sbQuery.Append(" ," + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(") ");

                    foreach (DataRow row in dtParam.Rows)
                    {                                                
                        bizExecute.executeInsertQuery(sbQuery.ToString(),row);
                    }
                }

            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }


        public static void TSYS_CONF_UPD(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TSYS_CONF");
                    sbQuery.Append(" SET CONF_VALUE = @CONF_VALUE");
                    sbQuery.Append(" , MDFY_DATE = GETDATE()");
                    sbQuery.Append(" , MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND CONF_SECTION = @CONF_SECTION");
                    sbQuery.Append(" AND CONF_NAME = @CONF_NAME");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "CONF_SECTION")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "CONF_NAME")) isHasColumn = false;

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

    public class TSYS_CONF_QUERY
    {
        public static DataTable TSYS_CONF_QUERY1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT PLT_CODE ");
                    sbQuery.Append("       ,CONF_SECTION ");
                    sbQuery.Append("       ,CONF_NAME ");
                    sbQuery.Append("       ,CONF_VALUE ");
                    sbQuery.Append("       ,REG_DATE ");
                    sbQuery.Append("       ,REG_EMP ");
                    sbQuery.Append("       ,MDFY_DATE ");
                    sbQuery.Append("       ,MDFY_EMP ");
                    sbQuery.Append("   FROM TSYS_CONF ");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@EMP_CODE", "CONF_SECTION = @CONF_SECTION"));
                        sbWhere.Append(UTIL.GetWhere(row, "@CONF_NAME", "CONF_NAME = @CONF_NAME"));
                        sbWhere.Append(UTIL.GetWhere(row, "@CONF_NAME_LIKE", "CONF_NAME LIKE '%' + @CONF_NAME_LIKE + '%'"));

                        DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString() + sbWhere.ToString()).Copy();

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

        public static DataTable TSYS_CONF_QUERY2(BizExecute.BizExecute bizExecute)
        {
            try
            {

                DataSet dsResult = new DataSet();
                
                StringBuilder sbQuery = new StringBuilder();
                sbQuery.Append(" SELECT CONF_NAME ");
                sbQuery.Append(" ,DEF_VALUE ");
                sbQuery.Append(" ,DESCRIPTION ");
                sbQuery.Append(" FROM TSYS_CONF");


                DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString()).Copy();

                sourceTable.TableName = "RSLTDT";
                dsResult.Merge(sourceTable);  


                return UTIL.GetDsToDt(dsResult);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }
    }
}
