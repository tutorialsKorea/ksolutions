using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace DSYS
{
    public class TSYS_LOGIN_LOG
    {
        public static DataTable TSYS_LOGIN_LOG_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT TOP 1 PLT_CODE  ");
                    sbQuery.Append(" ,ISNULL(UID,0) AS UID  ");
                    sbQuery.Append(" FROM TSYS_LOGIN_LOG  ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append("   AND EMP_CODE = @EMP_CODE ");
                    //sbQuery.Append("   AND LOG_TYPE = @LOG_TYPE ");
                    sbQuery.Append("   AND MAC_ADDR = @MAC_ADDR ");
                    sbQuery.Append("   AND LOGOUT_TIME IS NULL ");
                    sbQuery.Append("   ORDER BY UID DESC ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        //if (!UTIL.ValidColumn(row, "LOG_TYPE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "EMP_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "MAC_ADDR")) isHasColumn = false;

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


        public static void TSYS_LOGIN_LOG_UPD(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TSYS_LOGIN_LOG ");
                    sbQuery.Append(" SET LOGOUT_TIME = GETDATE() ");
                    sbQuery.Append(" WHERE UID = @UID ");
                    //sbQuery.Append("   AND UID = @UID ");
                    //sbQuery.Append("   AND MAC_ADDR = @MAC_ADDR ");
                    //sbQuery.Append("   AND LOGOUT_TIME IS NULL ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;
                        //검색 조건 유무 체크                        
                        //if (!UTIL.ValidColumn(row, "EMP_CODE")) isHasColumn = false;
                        //if (!UTIL.ValidColumn(row, "MAC_ADDR")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "UID")) isHasColumn = false;

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

        public static void TSYS_LOGIN_LOG_INS1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" INSERT INTO TSYS_LOGIN_LOG");
                    sbQuery.Append(" (");
                    sbQuery.Append(" PLT_CODE ");
                    sbQuery.Append(" , EMP_CODE");
                    sbQuery.Append(" , CLASS_NAME");
                    sbQuery.Append(" , CLASS_OPEN_TIME ");
                    sbQuery.Append(" )");
                    sbQuery.Append(" VALUES ");
                    sbQuery.Append(" (");
                    sbQuery.Append(" @PLT_CODE");
                    sbQuery.Append(" , @EMP_CODE ");
                    sbQuery.Append(" , @CLASS_NAME ");
                    sbQuery.Append(" , @CLASS_OPEN_TIME");
                    //sbQuery.Append(" ,GETDATE()");
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
        /// 로그인 이력
        /// </summary>
        /// <param name="dtParam"></param>
        /// <param name="bizExecute"></param>
        public static void TSYS_LOGIN_LOG_INS2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" INSERT INTO TSYS_LOGIN_LOG");
                    sbQuery.Append(" ( ");
                    sbQuery.Append(" PLT_CODE");
                    sbQuery.Append(" , EMP_CODE ");
                    sbQuery.Append(" , LAN_ADDR");
                    sbQuery.Append(" , WAN_ADDR");
                    sbQuery.Append(" , MAC_ADDR");
                    sbQuery.Append(" , VERSION");
                    sbQuery.Append(" , LOGIN_TIME");
                    sbQuery.Append(" ) ");
                    sbQuery.Append(" VALUES");
                    sbQuery.Append(" ( ");
                    sbQuery.Append(" @PLT_CODE ");
                    sbQuery.Append(" , @EMP_CODE");
                    sbQuery.Append(" , @LAN_ADDR");
                    sbQuery.Append(" , @WAN_ADDR");
                    sbQuery.Append(" , @MAC_ADDR");
                    sbQuery.Append(" , @VERSION");
                    sbQuery.Append(" , GETDATE() ");
                    sbQuery.Append(" ) ");

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
    }

    public class TSYS_LOGIN_LOG_QUERY
    {

        public static DataTable TSYS_LOGIN_LOG_QUERY2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {

            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT L.PLT_CODE ");
                    sbQuery.Append(" ,E.EMP_CODE ");
                    sbQuery.Append(" ,E.EMP_NAME ");
                    sbQuery.Append(" ,S.RES_CONTENTS ");
                    sbQuery.Append(" ,L.LAN_ADDR ");
                    sbQuery.Append(" ,L.WAN_ADDR ");
                    sbQuery.Append(" ,L.MAC_ADDR ");
                    sbQuery.Append(" ,ISNULL(L.LOGIN_TIME,L.CLASS_OPEN_TIME) AS LOGIN_TIME");

                    sbQuery.Append(" ,L.CLASS_NAME");
                    sbQuery.Append(" ,L.CLASS_OPEN_TIME");                    
                    sbQuery.Append(" FROM TSYS_LOGIN_LOG L");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE E ");
                    sbQuery.Append(" ON L.PLT_CODE = E.PLT_CODE ");
                    sbQuery.Append(" AND L.EMP_CODE = E.EMP_CODE");
                    sbQuery.Append(" LEFT JOIN TSYS_MENULIST M");
                    sbQuery.Append(" ON L.PLT_CODE = M.PLT_CODE");
                    sbQuery.Append(" AND L.CLASS_NAME = M.CLASSNAME");
                    sbQuery.Append(" LEFT JOIN TSYS_STRINGTABLE S");
                    sbQuery.Append(" ON M.PLT_CODE = S.PLT_CODE");
                    sbQuery.Append(" AND M.RES_ID = S.RES_ID");
                    sbQuery.Append(" AND S.RES_LANG = 'KR'");
                    //sbQuery.Append(" WHERE L.CLASS_OPEN_TIME IS NOT NULL");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE L.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@EMP_CODE", "L.EMP_CODE = @EMP_CODE"));   
                        sbWhere.Append(UTIL.GetWhere(row, "@S_LOGIN_TIME,@E_LOGIN_TIME", "(ISNULL(L.LOGIN_TIME,L.CLASS_OPEN_TIME) BETWEEN @S_LOGIN_TIME AND @E_LOGIN_TIME)"));

                        //sbWhere.Append(UTIL.GetWhere(row, "@LAN_ADDR_LIKE", "L.LAN_ADDR LIKE '%' + @LAN_ADDR_LIKE + '%'"));
                        //sbWhere.Append(UTIL.GetWhere(row, "@WAN_ADDR_LIKE", "L.WAN_ADDR LIKE '%' + @WAN_ADDR_LIKE + '%'"));
                        //sbWhere.Append(UTIL.GetWhere(row, "@MAC_ADDR", "L.MAC_ADDR = @MAC_ADDR"));
                        //sbWhere.Append(" AND L.CLASS_OPEN_TIME IS NULL");

                        sbWhere.Append(" ORDER BY ISNULL(L.LOGIN_TIME,L.CLASS_OPEN_TIME) DESC");

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
    }
}
