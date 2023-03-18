using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace DSYS
{
    public class TSYS_USERCONFIG_USE
    {
        public static DataTable TSYS_USERCONFIG_USE_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    foreach (DataRow row in dtParam.Rows)
                    {
                        string strQuery = "SELECT   PLT_CODE " +
                                        " , EMP_CODE " +
                                        " , CLASS_NAME " +
                                        " , CONTROL_NAME " +
                                        " , USE_CONFIG_NAME " +
                                        " , USE_CONFIG_MAKER " +
                                        " FROM TSYS_USERCONFIG_USE ";

                        string strWhere = " WHERE ";

                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "EMP_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "CLASS_NAME")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "CONTROL_NAME")) isHasColumn = false;

                        if (isHasColumn == true)
                        {
                            strWhere += "PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString();
                            strWhere += "AND EMP_CODE = " + UTIL.GetValidValue(row, "EMP_CODE");
                            strWhere += "AND CLASS_NAME = " + UTIL.GetValidValue(row, "CLASS_NAME");
                            strWhere += "AND CONTROL_NAME = " + UTIL.GetValidValue(row, "CONTROL_NAME");

                            DataTable sourceTable = bizExecute.executeSelectQuery(strQuery + strWhere).Copy();

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

        public static void TSYS_USERCONFIG_USE_UPD(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "EMP_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "CLASS_NAME")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "CONTROL_NAME")) isHasColumn = false;

                        if (isHasColumn == true)
                        {
                            string strQuery = "UPDATE TSYS_USERCONFIG_USE SET " +
                                          "USE_CONFIG_NAME = " + UTIL.GetValidValue(row, "USE_CONFIG_NAME") +
                                          ",USE_CONFIG_MAKER = " + UTIL.GetValidValue(row, "USE_CONFIG_MAKER");

                            string strWhere = " WHERE ";

                            strWhere += " PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString();
                            strWhere += "AND EMP_CODE = " + UTIL.GetValidValue(row, "EMP_CODE");
                            strWhere += "AND CLASS_NAME = " + UTIL.GetValidValue(row, "CLASS_NAME");
                            strWhere += "AND CONTROL_NAME = " + UTIL.GetValidValue(row, "CONTROL_NAME");

                            bizExecute.executeUpdateQuery(strQuery + strWhere);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }


        public static void TSYS_USERCONFIG_USE_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" INSERT INTO TSYS_USERCONFIG_USE");
                    sbQuery.Append(" (");
                    sbQuery.Append(" PLT_CODE ");
                    sbQuery.Append(" , EMP_CODE");
                    sbQuery.Append(" , CLASS_NAME");
                    sbQuery.Append(" , CONTROL_NAME");
                    sbQuery.Append(" , USE_CONFIG_NAME ");
                    sbQuery.Append(" , USE_CONFIG_MAKER ");
                    sbQuery.Append(" )");
                    sbQuery.Append(" VALUES ");
                    sbQuery.Append(" (");
                    sbQuery.Append(" @PLT_CODE");
                    sbQuery.Append(" , @EMP_CODE ");
                    sbQuery.Append(" , @CLASS_NAME ");
                    sbQuery.Append(" , @CONTROL_NAME");
                    sbQuery.Append(" , @USE_CONFIG_NAME");
                    sbQuery.Append(" , @USE_CONFIG_MAKER");
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

        /// <summary>
        /// 사용자중인 기본설정 삭제
        /// </summary>
        /// <param name="dtParam"></param>
        public static void TSYS_USERCONFIG_USE_DEL(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" DELETE FROM TSYS_USERCONFIG_USE ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND EMP_CODE = @EMP_CODE");
                    sbQuery.Append(" AND CLASS_NAME = @CLASS_NAME");
                    sbQuery.Append(" AND CONTROL_NAME = @CONTROL_NAME");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "EMP_CODE")) isHasColumn = false;
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

        /// <summary>
        /// 특정컨트롤의 사용자환경 삭제
        /// </summary>
        /// <param name="dtParam"></param>
        public static void TSYS_USERCONFIG_USE_DEL2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" DELETE FROM TSYS_USERCONFIG_USE ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND EMP_CODE = @EMP_CODE");                    
                    sbQuery.Append(" AND CONTROL_NAME = @CONTROL_NAME");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "EMP_CODE")) isHasColumn = false;                        
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

        /// <summary>
        /// 사용자 전체 삭제
        /// </summary>
        /// <param name="dtParam"></param>
        public static void TSYS_USERCONFIG_USE_DEL3(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" DELETE FROM TSYS_USERCONFIG_USE ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND EMP_CODE = @EMP_CODE");                    

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;
                        //검색 조건 유무 체크
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

        public static void TSYS_USERCONFIG_USE_DEL4(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" DELETE FROM TSYS_USERCONFIG_USE ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("   AND EMP_CODE = @EMP_CODE  ");
                    //sbQuery.Append("   AND USE_CONFIG_NAME = @USE_CONFIG_NAME ");

                    
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

        public static void TSYS_USERCONFIG_USE_DEL6(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    
                    sbQuery.Append(" DELETE FROM TSYS_USERCONFIG_USE ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("   AND EMP_CODE = @EMP_CODE  ");
                    sbQuery.Append("   AND CLASS_NAME = @CLASS_NAME  ");
                    //sbQuery.Append("   AND USE_CONFIG_NAME = @USE_CONFIG_NAME ");

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

    public class TSYS_USERCONFIG_USE_QUERY
    {
        public static DataTable TSYS_USERCONFIG_USE_QUERY1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    foreach (DataRow row in dtParam.Rows)
                    {
                        string strQuery = "SELECT U.PLT_CODE " +
                                                ",U.EMP_CODE " +
                                                ",E.EMP_NAME " +
                                                ",U.CLASS_NAME " +
                                                ",U.CONTROL_NAME " +
                                                ",U.USE_CONFIG_NAME " +
                                                ",U.USE_CONFIG_MAKER " +
                                            "FROM TSYS_USERCONFIG_USE U " +
                                        "LEFT JOIN TSTD_EMPLOYEE E " +
                                        "ON  U.PLT_CODE = E.PLT_CODE  " +
                                        "AND U.EMP_CODE = E.EMP_CODE ";

                        string strWhere = " WHERE U.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString();

                        strWhere += UTIL.GetWhere(ConnInfo.UserID,"@EMP_CODE", "U.EMP_CODE = @EMP_CODE");
                        strWhere += UTIL.GetWhere(row, "@CLASS_NAME", "U.CLASS_NAME = @CLASS_NAME");
                        strWhere += UTIL.GetWhere(row, "@CONTROL_NAME", "U.CONTROL_NAME = @CONTROL_NAME");
                        strWhere += UTIL.GetWhere(row, "@CONFIG_NAME", "U.USE_CONFIG_NAME = @CONFIG_NAME");
                        strWhere += UTIL.GetWhere(row, "@USE_CONFIG_MAKER", "U.USE_CONFIG_MAKER = @USE_CONFIG_MAKER");

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

        public static DataTable TSYS_USERCONFIG_USE_QUERY1(DataRow row, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                string strQuery = "SELECT U.PLT_CODE " +
                                        ",U.EMP_CODE " +
                                        ",E.EMP_NAME " +
                                        ",U.CLASS_NAME " +
                                        ",U.CONTROL_NAME " +
                                        ",U.USE_CONFIG_NAME " +
                                        ",U.USE_CONFIG_MAKER " +
                                    "FROM TSYS_USERCONFIG_USE U " +
                                "LEFT JOIN TSTD_EMPLOYEE E " +
                                "ON  U.PLT_CODE = E.PLT_CODE  " +
                                "AND U.EMP_CODE = E.EMP_CODE ";

                string strWhere = " WHERE U.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString();

                strWhere += UTIL.GetWhere(ConnInfo.UserID, "@EMP_CODE", "U.EMP_CODE = @EMP_CODE");
                strWhere += UTIL.GetWhere(row, "@CLASS_NAME", "U.CLASS_NAME = @CLASS_NAME");
                strWhere += UTIL.GetWhere(row, "@CONTROL_NAME", "U.CONTROL_NAME = @CONTROL_NAME");
                strWhere += UTIL.GetWhere(row, "@CONFIG_NAME", "U.USE_CONFIG_NAME = @CONFIG_NAME");
                strWhere += UTIL.GetWhere(row, "@USE_CONFIG_MAKER", "U.USE_CONFIG_MAKER = @USE_CONFIG_MAKER");

                DataTable sourceTable = bizExecute.executeSelectQuery(strQuery + strWhere).Copy();

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
