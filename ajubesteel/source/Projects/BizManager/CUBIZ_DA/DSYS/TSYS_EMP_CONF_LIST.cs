using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace DSYS
{
    public class TSYS_EMP_CONF_LIST
    {
        public static DataTable TSYS_EMP_CONF_LIST_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {

            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT CONF_NAME");
                    sbQuery.Append(" , DEF_VALUE ");
                    sbQuery.Append(" , DESCRIPTION ");
                    sbQuery.Append(" FROM TSYS_EMP_CONF_LIST ");
                    sbQuery.Append(" WHERE CONF_NAME = @CONF_NAME");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

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

        public static DataTable TSYS_EMP_CONF_LIST_SER2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {

            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT                             ");
                    sbQuery.Append(" CONF_NAME                          ");
                    sbQuery.Append(" ,DEF_VALUE                         ");
                    sbQuery.Append(" FROM TSYS_EMP_CONF_LIST            ");
                    sbQuery.Append(" WHERE CONF_NAME NOT IN(            ");
                    sbQuery.Append(" SELECT CONF_NAME FROM TSYS_EMP_CONF"); 
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE         ");
                    sbQuery.Append(" AND EMP_CODE = @EMP_CODE           ");
                    sbQuery.Append(" )                                  ");

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

        public static void TSYS_EMP_CONF_LIST_UPD(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TSYS_EMP_CONF_LIST ");
                    sbQuery.Append(" SET CONF_NAME = @CONF_NAME");
                    sbQuery.Append(" , DEF_VALUE = @DEF_VALUE");
                    sbQuery.Append(" , DESCRIPTION = @DESCRIPTION");
                    sbQuery.Append(" WHERE CONF_NAME = @CONF_NAME");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크
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

        public static void TSYS_EMP_CONF_LIST_UDE(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append("UPDATE TSYS_EMP_CONF_LIST SET");
                    sbQuery.Append("  DEL_DATE = GETDATE()");
                    sbQuery.Append(" , DEL_EMP = '" + ConnInfo.UserID + "'");
                    sbQuery.Append(" , DATA_FLAG = 2");

                    sbQuery.Append(" WHERE CONF_NAME = @CONF_NAME");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크
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

        public static void TSYS_EMP_CONF_LIST_DEL(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append("DELETE FROM TSYS_EMP_CONF_LIST");
                    sbQuery.Append(" WHERE CONF_NAME = @CONF_NAME");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크
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

        public static void TSYS_EMP_CONF_LIST_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" INSERT INTO TSYS_EMP_CONF_LIST");
                    sbQuery.Append(" ( ");
                    sbQuery.Append(" CONF_NAME ");
                    sbQuery.Append(" , DEF_VALUE ");
                    sbQuery.Append(" , DESCRIPTION ");
                    sbQuery.Append(" ) ");
                    sbQuery.Append(" VALUES");
                    sbQuery.Append(" ( ");
                    sbQuery.Append(" @CONF_NAME");
                    sbQuery.Append(" , @DEF_VALUE");
                    sbQuery.Append(" , @DESCRIPTION");
                    sbQuery.Append(" ) ");

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
    }

    public class TSYS_EMP_CONF_LIST_QUERY
    {

        public static DataTable TSYS_EMP_CONF_LIST_QUERY1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT CONF_NAME ");
                    sbQuery.Append(" ,DEF_VALUE ");
                    sbQuery.Append(" ,DESCRIPTION ");
                    sbQuery.Append(" FROM TSYS_EMP_CONF_LIST");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder();

                        //sbWhere.Append(" WHERE PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                        sbWhere.Append(" WHERE CONF_NAME LIKE '%' + " + UTIL.GetValidValue(row, "@CONF_NAME_LIKE").ToString() + " + '%'");
                        //sbWhere.Append(UTIL.GetWhere(row, "@CONF_NAME", "CONF_NAME = @CONF_NAME"));
                        //sbWhere.Append(UTIL.GetWhere(row, "@CONF_NAME_LIKE", "CONF_NAME LIKE '%' + @CONF_NAME_LIKE + '%'"));

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

        public static DataTable TSYS_EMP_CONF_LIST_QUERY2(BizExecute.BizExecute bizExecute)
        {   
            try
            {

                DataSet dsResult = new DataSet();
                
                StringBuilder sbQuery = new StringBuilder();
                sbQuery.Append(" SELECT CONF_NAME ");
                sbQuery.Append(" ,DEF_VALUE ");
                sbQuery.Append(" ,DESCRIPTION ");
                sbQuery.Append(" FROM TSYS_EMP_CONF_LIST");


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
