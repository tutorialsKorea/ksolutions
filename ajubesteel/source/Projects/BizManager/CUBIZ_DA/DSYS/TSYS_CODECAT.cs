using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace DSYS
{
    public class TSYS_CODECAT
    {
        public static DataTable TSYS_CODECAT_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {

            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT PLT_CODE ");
                    sbQuery.Append(" , CAT_CODE");
                    sbQuery.Append(" , CAT_NAME");
                    sbQuery.Append(" , CAT_PARENT");
                    sbQuery.Append(" , IS_FIXED_CD ");
                    sbQuery.Append(" , SCOMMENT");
                    sbQuery.Append(" , REG_DATE");
                    sbQuery.Append(" , REG_EMP ");
                    sbQuery.Append(" , MDFY_DATE ");
                    sbQuery.Append(" , MDFY_EMP");
                    sbQuery.Append(" , DEL_DATE");
                    sbQuery.Append(" , DEL_EMP ");
                    sbQuery.Append(" , DEL_REASON");
                    sbQuery.Append(" , DATA_FLAG ");
                    sbQuery.Append(" FROM TSYS_CODECAT ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND CAT_CODE = @CAT_CODE");

                    foreach (DataRow row in dtParam.Rows)
                    {                        

                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "CAT_CODE")) isHasColumn = false;                        

                        if (isHasColumn == true)
                        {

                            DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString(),row).Copy();

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

        public static DataTable TSYS_CODECAT_SER2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {

            try
            {
                
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT PLT_CODE ");
                    sbQuery.Append(" , CAT_CODE");
                    sbQuery.Append(" , CAT_NAME");
                    sbQuery.Append(" , CAT_PARENT");
                    sbQuery.Append(" , IS_FIXED_CD ");
                    sbQuery.Append(" , SCOMMENT");
                    sbQuery.Append(" , REG_DATE");
                    sbQuery.Append(" , REG_EMP ");
                    sbQuery.Append(" , MDFY_DATE ");
                    sbQuery.Append(" , MDFY_EMP");
                    sbQuery.Append(" , DEL_DATE");
                    sbQuery.Append(" , DEL_EMP ");
                    sbQuery.Append(" , DEL_REASON");
                    sbQuery.Append(" , DATA_FLAG ");
                    sbQuery.Append(" FROM TSYS_CODECAT ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND CAT_CODE = @CAT_CODE");
                    sbQuery.Append(" AND DATA_FLAG = 0 ");

                    foreach (DataRow row in dtParam.Rows)
                    {                        
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "CAT_CODE")) isHasColumn = false;

                        if (isHasColumn == true)
                        {                            

                            DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString(),row).Copy();

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

        public static void TSYS_CODECAT_UPD(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TSYS_CODECAT ");
                    sbQuery.Append(" SET CAT_NAME = @CAT_NAME");
                    sbQuery.Append(" , CAT_PARENT = @CAT_PARENT");
                    sbQuery.Append(" , IS_FIXED_CD = @IS_FIXED_CD");
                    sbQuery.Append(" , SCOMMENT = @SCOMMENT");
                    sbQuery.Append(" , MDFY_DATE = GETDATE()");
                    sbQuery.Append(" , MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" , DATA_FLAG = 0");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND CAT_CODE = @CAT_CODE");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크                        
                        if (!UTIL.ValidColumn(row, "CAT_CODE")) isHasColumn = false;
 
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

        public static void TSYS_CODECAT_UDE(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TSYS_CODECAT ");
                    sbQuery.Append(" SET DEL_DATE = GETDATE()");
                    sbQuery.Append(" , DEL_EMP = '" + ConnInfo.UserID + "'");
                    sbQuery.Append(" , DATA_FLAG = 2");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND CAT_CODE = @CAT_CODE");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;
                        //검색 조건 유무 체크                        
                        if (!UTIL.ValidColumn(row, "CAT_CODE")) isHasColumn = false;

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

        public static void TSYS_CODECAT_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" INSERT INTO TSYS_CODECAT");
                    sbQuery.Append(" ( ");
                    sbQuery.Append(" PLT_CODE");
                    sbQuery.Append(" , CAT_CODE");
                    sbQuery.Append(" , CAT_NAME");
                    sbQuery.Append(" , CAT_PARENT");
                    sbQuery.Append(" , IS_FIXED_CD ");
                    sbQuery.Append(" , SCOMMENT");
                    sbQuery.Append(" , REG_DATE");
                    sbQuery.Append(" , REG_EMP ");
                    sbQuery.Append(" , DATA_FLAG ");
                    sbQuery.Append(" ) ");
                    sbQuery.Append(" VALUES");
                    sbQuery.Append(" ( ");
                    sbQuery.Append(" @PLT_CODE ");
                    sbQuery.Append(" , @CAT_CODE ");
                    sbQuery.Append(" , @CAT_NAME ");
                    sbQuery.Append(" , @CAT_PARENT ");
                    sbQuery.Append(" , @IS_FIXED_CD");
                    sbQuery.Append(" , @SCOMMENT ");
                    sbQuery.Append(" ,GETDATE()");
                    sbQuery.Append(" ," + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" ,0");
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
    }

    public class TSYS_CODECAT_QUERY
    {
        public static DataTable TSYS_CODECAT_QUERY1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {

                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT PLT_CODE");
                    sbQuery.Append(" ,CAT_CODE");
                    sbQuery.Append(" ,CAT_NAME");
                    sbQuery.Append(" ,CAT_PARENT");
                    sbQuery.Append(" ,IS_FIXED_CD ");
                    sbQuery.Append(" ,SCOMMENT");
                    sbQuery.Append(" ,REG_DATE");
                    sbQuery.Append(" ,REG_EMP ");
                    sbQuery.Append(" ,MDFY_DATE ");
                    sbQuery.Append(" ,MDFY_EMP");
                    sbQuery.Append(" ,DATA_FLAG ");
                    sbQuery.Append(" ,DEL_DATE");
                    sbQuery.Append(" ,DEL_EMP ");
                    sbQuery.Append(" FROM TSYS_CODECAT");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder();

                        sbWhere.Append(" WHERE PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@CAT_CODE", "CAT_CODE = @CAT_CODE"));                        
                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "DATA_FLAG = @DATA_FLAG"));

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

        public static DataTable TSYS_CODECAT_QUERY2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {

                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    foreach (DataRow row in dtParam.Rows)
                    {
                        string strQuery = " SELECT C.PLT_CODE " +
                                            " ,C.CAT_CODE " +
                                            " ,C.CAT_NAME " +
                                            " ,C.CAT_PARENT " +
                                            " ,PC.CAT_NAME AS CAT_PARENT_NAME " +
                                            " ,C.SCOMMENT " +
                                            " ,C.IS_FIXED_CD" +
                                            " ,C.REG_DATE " +
                                            " ,C.REG_EMP" +
                                            " ,REG.EMP_NAME AS REG_EMP_NAME " +
                                            " ,C.MDFY_DATE" +
                                            " ,C.MDFY_EMP " +
                                            " ,MDFY.EMP_NAME AS MDFY_EMP_NAME " +
                                            " FROM TSYS_CODECAT C " +
                                            " LEFT JOIN TSYS_CODECAT PC " +
                                            " ON C.PLT_CODE = PC.PLT_CODE " +
                                            " AND C.CAT_PARENT = PC.CAT_CODE" +
                                            " LEFT JOIN TSTD_EMPLOYEE REG " +
                                            " ON C.PLT_CODE = REG.PLT_CODE" +
                                            " AND C.REG_EMP = REG.EMP_CODE" +
                                            " LEFT JOIN TSTD_EMPLOYEE MDFY" +
                                            " ON C.PLT_CODE = MDFY.PLT_CODE " +
                                            " AND C.MDFY_EMP = MDFY.EMP_CODE";

                        string strWhere = " WHERE C.PLT_CODE = '" + ConnInfo.PLT_CODE + "'";

                        strWhere += UTIL.GetWhere(row, "@CAT_CODE", "C.CAT_CODE = @CAT_CODE");
                        strWhere += UTIL.GetWhere(row, "@CAT_LIKE", "(C.CAT_CODE LIKE '%' + @CAT_LIKE + '%' OR C.CAT_NAME LIKE '%' + @CAT_LIKE + '%')");
                        strWhere += UTIL.GetWhere(row, "@DATA_FLAG", "C.DATA_FLAG = @DATA_FLAG");

                        DataTable sourceTable = bizExecute.executeSelectQuery(strQuery + strWhere).Copy();

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
