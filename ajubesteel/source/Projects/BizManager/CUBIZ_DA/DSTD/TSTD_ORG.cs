using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BizExecute;
using System.Data;
using System.Data.SqlClient;

namespace DSTD
{
    public class TSTD_ORG
    {
        public static DataTable TSTD_ORG_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {

            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT PLT_CODE ");
                    sbQuery.Append(" , ORG_CODE");
                    sbQuery.Append(" , ORG_NAME");
                    sbQuery.Append(" , ORG_PARENT");
                    sbQuery.Append(" , ORG_LEADER");
                    sbQuery.Append(" , ORG_SEQ ");
                    sbQuery.Append(" , CC_EMP ");
                    sbQuery.Append(" , REG_DATE");
                    sbQuery.Append(" , REG_EMP ");
                    sbQuery.Append(" , MDFY_DATE ");
                    sbQuery.Append(" , MDFY_EMP");
                    sbQuery.Append(" , DEL_DATE");
                    sbQuery.Append(" , DEL_EMP ");
                    sbQuery.Append(" , DEL_REASON");
                    sbQuery.Append(" , DATA_FLAG ");
                    sbQuery.Append(" FROM TSTD_ORG ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND ORG_CODE = @ORG_CODE");

                    foreach (DataRow row in dtParam.Rows)
                    {                                                                   
                        bool isHasColumn = true;
                        
                        if (!UTIL.ValidColumn(row, "ORG_CODE")) isHasColumn = false;

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

        public static void TSTD_ORG_UPD(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {

                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" UPDATE TSTD_ORG ");
                    sbQuery.Append(" SET ORG_NAME = @ORG_NAME");
                    sbQuery.Append(" , ORG_PARENT = @ORG_PARENT");
                    sbQuery.Append(" , ORG_LEADER = @ORG_LEADER");
                    sbQuery.Append(" , ORG_SEQ = @ORG_SEQ");
                    sbQuery.Append(" , CC_EMP = @CC_EMP");
                    sbQuery.Append(" , IS_DEV = @IS_DEV");
                    sbQuery.Append(" , IS_SECRET = @IS_SECRET");
                    sbQuery.Append(" , IS_ADMIN = @IS_ADMIN");
                    sbQuery.Append(" , MDFY_DATE = GETDATE()");
                    sbQuery.Append(" , MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" , DATA_FLAG = 0");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND ORG_CODE = @ORG_CODE");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "ORG_CODE")) isHasColumn = false;                        

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

        public static void TSTD_ORG_UDE(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" UPDATE TSTD_ORG SET ");
                    sbQuery.Append("  DEL_DATE = GETDATE()");
                    sbQuery.Append(" , DEL_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" , DATA_FLAG = 2");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND ORG_CODE = @ORG_CODE");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "ORG_CODE")) isHasColumn = false;

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

        public static void TSTD_ORG_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {

                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" INSERT INTO  TSTD_ORG");
                    sbQuery.Append(" ( ");
                    sbQuery.Append(" PLT_CODE");
                    sbQuery.Append(" , ORG_CODE");
                    sbQuery.Append(" , ORG_NAME");
                    sbQuery.Append(" , ORG_PARENT");
                    sbQuery.Append(" , ORG_LEADER");
                    sbQuery.Append(" , ORG_SEQ ");
                    sbQuery.Append(" , CC_EMP ");
                    sbQuery.Append(" , IS_DEV ");
                    sbQuery.Append(" , IS_SECRET ");
                    sbQuery.Append(" , IS_ADMIN ");
                    sbQuery.Append(" , REG_DATE");
                    sbQuery.Append(" , REG_EMP ");
                    sbQuery.Append(" , DATA_FLAG ");
                    sbQuery.Append(" ) ");
                    sbQuery.Append(" VALUES");
                    sbQuery.Append(" ( ");
                    sbQuery.Append(" @PLT_CODE ");
                    sbQuery.Append(" , @ORG_CODE ");
                    sbQuery.Append(" , @ORG_NAME ");
                    sbQuery.Append(" , @ORG_PARENT ");
                    sbQuery.Append(" , @ORG_LEADER ");
                    sbQuery.Append(" , @ORG_SEQ");
                    sbQuery.Append(" , @CC_EMP");
                    sbQuery.Append(" , @IS_DEV ");
                    sbQuery.Append(" , @IS_ADMIN ");
                    sbQuery.Append(" , @IS_SECRET ");
                    sbQuery.Append(" , GETDATE() ");
                    sbQuery.Append(" , "+ UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" , 0");
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

    public class TSTD_ORG_QUERY
    {
        public static DataTable TSTD_ORG_QUERY1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT ");
                    sbQuery.Append(" O.PLT_CODE");
                    sbQuery.Append(" ,O.ORG_CODE");
                    sbQuery.Append(" ,O.ORG_NAME");
                    sbQuery.Append(" ,O.ORG_PARENT");
                    sbQuery.Append(" ,O.CC_EMP");
                    sbQuery.Append(" FROM TSTD_ORG O");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder();

                        sbWhere.Append(" WHERE O.PLT_CODE = @PLT_CODE ").Replace("@PLT_CODE", UTIL.GetValidValue(row, "PLT_CODE").ToString());
                        sbWhere.Append(" AND O.DATA_FLAG = 0");
                        sbWhere.Append(" ORDER BY O.ORG_SEQ,O.ORG_NAME");

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

        public static DataTable TSTD_ORG_QUERY2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT ");
                    sbQuery.Append(" O.PLT_CODE");
                    sbQuery.Append(" ,O.ORG_CODE");
                    sbQuery.Append(" ,O.ORG_NAME");
                    sbQuery.Append(" ,O.ORG_PARENT");
                    sbQuery.Append(" ,O.ORG_LEADER");
                    sbQuery.Append(" ,ORG_LEADER_NAME = E.EMP_NAME");
                    sbQuery.Append(" ,O.ORG_SEQ");
                    sbQuery.Append(" ,O.CC_EMP");
                    sbQuery.Append(" ,O.IS_DEV");
                    sbQuery.Append(" ,O.IS_SECRET");
                    sbQuery.Append(" ,O.IS_ADMIN");
                    sbQuery.Append(" ,O.REG_DATE");
                    sbQuery.Append(" ,O.REG_EMP");
                    sbQuery.Append(" ,REG.EMP_NAME AS REG_EMP_NAME");
                    sbQuery.Append(" ,O.MDFY_DATE");
                    sbQuery.Append(" ,O.MDFY_EMP");
                    sbQuery.Append(" ,MDFY.EMP_NAME AS MDFY_EMP_NAME");
                    sbQuery.Append(" FROM TSTD_ORG O");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE E");
                    sbQuery.Append(" ON O.PLT_CODE = E.PLT_CODE ");
                    sbQuery.Append(" AND O.ORG_LEADER = E.EMP_CODE");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE REG");
                    sbQuery.Append(" ON O.PLT_CODE = REG.PLT_CODE ");
                    sbQuery.Append(" AND O.REG_EMP = REG.EMP_CODE");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE MDFY");
                    sbQuery.Append(" ON O.PLT_CODE = MDFY.PLT_CODE ");
                    sbQuery.Append(" AND O.MDFY_EMP = MDFY.EMP_CODE ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder();

                        sbWhere.Append(" WHERE O.PLT_CODE = @PLT_CODE ").Replace("@PLT_CODE", UTIL.GetValidValue(row, "PLT_CODE").ToString());
                        sbWhere.Append(UTIL.GetWhere(row, "@ORG_CODE", "O.ORG_CODE = @ORG_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PLT_CODE,@EMP_TYPE", "O.ORG_CODE IN (SELECT ORG_CODE FROM TSTD_EMPLOYEE WHERE PLT_CODE = @PLT_CODE AND EMP_TYPE = @EMP_TYPE)"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PLT_CODE,@EMP_LIKE", "O.ORG_CODE IN (SELECT ORG_CODE FROM TSTD_EMPLOYEE WHERE PLT_CODE = @PLT_CODE AND (EMP_CODE LIKE '%' + @EMP_LIKE + '%' OR EMP_NAME LIKE '%' + @EMP_LIKE + '%') AND DATA_FLAG = 0)"));
                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "O.DATA_FLAG = @DATA_FLAG"));
                        sbWhere.Append(UTIL.GetWhere(row, "@IS_DEV", "O.IS_DEV = @IS_DEV"));

                        //sbQuery.Append(" ORDER BY CD.CD_SEQ");

                        DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString()+ sbWhere.ToString()).Copy();

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
