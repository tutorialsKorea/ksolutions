using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace DSYS
{
    public class TSYS_USERCONFIG_LIST
    {
        public static void TSYS_USERCONFIG_LIST_UPD(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    bool isHasColumn = true;
                    
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TSYS_USERCONFIG_LIST");
                    sbQuery.Append(" SET   PLT_CODE = @PLT_CODE ");
                    sbQuery.Append(" , EMP_CODE = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" , CLASS_NAME = @CLASS_NAME ");
                    sbQuery.Append(" , CONTROL_NAME = @CONTROL_NAME ");
                    sbQuery.Append(" , CONFIG_NAME = @CONFIG_NAME ");
                    sbQuery.Append(" , LAYOUT = @LAYOUT ");
                    sbQuery.Append(" , OBJECT = @OBJECT ");
                    sbQuery.Append(" , REG_DATE = GETDATE() ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append(" AND EMP_CODE = @EMP_CODE  ");
                    sbQuery.Append(" AND CLASS_NAME = @CLASS_NAME  ");
                    sbQuery.Append(" AND CONTROL_NAME = @CONTROL_NAME  ");
                    sbQuery.Append(" AND CONFIG_NAME = @CONFIG_NAME ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        if (!UTIL.ValidColumn(row, "EMP_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "CLASS_NAME")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "CONTROL_NAME")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "CONFIG_NAME")) isHasColumn = false;

                        if (isHasColumn == true)
                        {

                            bizExecute.executeUpdateQuery(sbQuery.ToString(), row);
                        }
                                
                    }

                }
            }
            catch(Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }

        public static void TSYS_USERCONFIG_LIST_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" INSERT INTO TSYS_USERCONFIG_LIST");
                    sbQuery.Append(" (");
                    sbQuery.Append(" PLT_CODE ");
                    sbQuery.Append(" , EMP_CODE");
                    sbQuery.Append(" , CLASS_NAME");
                    sbQuery.Append(" , CONTROL_NAME");
                    sbQuery.Append(" , CONFIG_NAME ");
                    sbQuery.Append(" , LAYOUT ");
                    sbQuery.Append(" , OBJECT ");
                    sbQuery.Append(" , REG_DATE ");
                    sbQuery.Append(" )");
                    sbQuery.Append(" VALUES ");
                    sbQuery.Append(" (");
                    sbQuery.Append(" @PLT_CODE");
                    sbQuery.Append(" , " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" , @CLASS_NAME ");
                    sbQuery.Append(" , @CONTROL_NAME");
                    sbQuery.Append(" , @CONFIG_NAME");
                    sbQuery.Append(" , @LAYOUT");
                    sbQuery.Append(" , @OBJECT");
                    sbQuery.Append(" , GETDATE()");
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

        public static DataTable TSYS_USERCONFIG_LIST_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    foreach (DataRow row in dtParam.Rows)
                    {
                        string strQuery = "SELECT " +
                                          "PLT_CODE " +
                                          ",EMP_CODE " +
                                          ",CLASS_NAME " +
                                          ",CONTROL_NAME " +
                                          ",CONFIG_NAME " +
                                          ",LAYOUT " +
                                          ",OBJECT " +
                                          ",REG_DATE " +
                                      "FROM TSYS_USERCONFIG_LIST ";

                        string strWhere = " WHERE ";

                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "EMP_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "CLASS_NAME")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "CONTROL_NAME")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "CONFIG_NAME")) isHasColumn = false;

                        if (isHasColumn == true)
                        {
                            strWhere += " PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString();
                            strWhere += "AND EMP_CODE = " + UTIL.GetValidValue(row, "EMP_CODE");
                            strWhere += "AND CLASS_NAME = " + UTIL.GetValidValue(row, "CLASS_NAME");
                            strWhere += "AND CONTROL_NAME = " + UTIL.GetValidValue(row, "CONTROL_NAME");
                            strWhere += "AND CONFIG_NAME = " + UTIL.GetValidValue(row, "CONFIG_NAME");

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

        /// <summary>
        /// 사용자 컨트롤삭제
        /// </summary>
        /// <param name="dtParam"></param>
        public static void TSYS_USERCONFIG_LIST_DEL(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" DELETE FROM TSYS_USERCONFIG_LIST ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("    AND EMP_CODE = @EMP_CODE  ");
                    sbQuery.Append("    AND CLASS_NAME = @CLASS_NAME  ");
                    sbQuery.Append("    AND CONTROL_NAME = @CONTROL_NAME  ");
                    sbQuery.Append("    AND CONFIG_NAME = @CONFIG_NAME ");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "EMP_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "CLASS_NAME")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "CONTROL_NAME")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "CONFIG_NAME")) isHasColumn = false;

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
        public static void TSYS_USERCONFIG_LIST_DEL3(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" DELETE FROM TSYS_USERCONFIG_LIST ");
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

        public static void TSYS_USERCONFIG_LIST_DEL4(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" DELETE FROM TSYS_USERCONFIG_LIST ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND EMP_CODE = @EMP_CODE");
                    //sbQuery.Append(" AND CONFIG_NAME = @CONFIG_NAME");

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

        public static void TSYS_USERCONFIG_LIST_DEL6(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                
                    sbQuery.Append(" DELETE FROM TSYS_USERCONFIG_LIST ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("   AND EMP_CODE = @EMP_CODE  ");
                    sbQuery.Append("   AND CLASS_NAME = @CLASS_NAME  ");
                    //sbQuery.Append("   AND CONFIG_NAME = @CONFIG_NAME ");

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

    public class TSYS_USERCONFIG_LIST_QUERY
    {
        public static DataTable TSYS_USERCONFIG_LIST_QUERY1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    foreach (DataRow row in dtParam.Rows)
                    {
                        string strQuery = "SELECT " +
                                          "G.PLT_CODE " +
                                          ",G.EMP_CODE " +
                                          ",E.EMP_NAME " +
                                          ",G.CLASS_NAME " +
                                          ",G.CONTROL_NAME " +
                                          ",G.CONFIG_NAME " +
                                          ",G.LAYOUT " +
                                          ",G.OBJECT " +
                                          ",G.REG_DATE " +
                                          ",'0' AS SEL " +
                                      "FROM TSYS_USERCONFIG_LIST G " +
                                      "LEFT JOIN TSTD_EMPLOYEE E " +
                                      "ON  G.PLT_CODE = E.PLT_CODE  " +
                                      "AND G.EMP_CODE = E.EMP_CODE ";

                        string strWhere = " WHERE G.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString();

                        //strWhere += UTIL.GetWhere(ConnInfo.UserID, "@EMP_CODE", "G.EMP_CODE = @EMP_CODE");
                        strWhere += UTIL.GetWhere(row, "@EMP_CODE", "G.EMP_CODE = @EMP_CODE");
                        strWhere += UTIL.GetWhere(row, "@CLASS_NAME", "G.CLASS_NAME = @CLASS_NAME");
                        strWhere += UTIL.GetWhere(row, "@CONTROL_NAME", "G.CONTROL_NAME = @CONTROL_NAME");
                        strWhere += UTIL.GetWhere(row, "@CONFIG_NAME", "G.CONFIG_NAME = @CONFIG_NAME");

                        DataTable sourceTable = bizExecute.executeSelectQuery(strQuery + strWhere).Copy();

                        sourceTable.TableName = "RSLTDT";
                        dsResult.Merge(sourceTable);  
                    }
                }


                return UTIL.GetDsToDt(dsResult);
            }
            catch(Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }
    }
}
