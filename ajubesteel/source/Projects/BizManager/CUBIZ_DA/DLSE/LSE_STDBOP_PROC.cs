using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using BizExecute;

namespace DLSE
{
    public class LSE_STDBOP_PROC
    {
        /// <summary>
        /// 표준 BOP 공정 조회
        /// </summary>
        /// <param name="dtParam"></param>
        /// <returns></returns>
        public static DataTable LSE_STDBOP_PROC_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT PLT_CODE ");
                    sbQuery.Append(" , PROD_CODE ");
                    sbQuery.Append(" , PART_ID ");
                    sbQuery.Append(" , PROC_ID ");
                    sbQuery.Append(" , PROC_STDC ");
                    sbQuery.Append(" , PROC_CODE ");
                    sbQuery.Append(" , SUCC_PROC_ID");
                    sbQuery.Append(" , SPLIT_PROC_ID ");
                    sbQuery.Append(" , SAMC_PART_ID");
                    sbQuery.Append(" , SAMC_PROC_ID");
                    sbQuery.Append(" , PROC_TYPE ");
                    sbQuery.Append(" , LOADABLE_MC ");
                    sbQuery.Append(" , SCOMMENT");
                    sbQuery.Append(" , PLN_PROC_SELF_TIME");
                    sbQuery.Append(" , PLN_PROC_MAN_TIME ");
                    sbQuery.Append(" FROM LSE_STDBOP_PROC");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND PROD_CODE = @PROD_CODE");
                    sbQuery.Append(" AND PART_ID = @PART_ID");
                    sbQuery.Append(" AND PROC_ID = @PROC_ID");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PROD_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PART_ID")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PROC_ID")) isHasColumn = false;

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
            catch(Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }    
        }

        public static DataTable LSE_STDBOP_PROC_SER2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT PLT_CODE ");
                    sbQuery.Append(" , PROD_CODE ");
                    sbQuery.Append(" , PART_ID ");
                    sbQuery.Append(" , PROC_ID ");
                    sbQuery.Append(" , PROC_STDC ");
                    sbQuery.Append(" , PROC_CODE ");
                    sbQuery.Append(" , SUCC_PROC_ID");
                    sbQuery.Append(" , SPLIT_PROC_ID ");
                    sbQuery.Append(" , SAMC_PART_ID");
                    sbQuery.Append(" , SAMC_PROC_ID");
                    sbQuery.Append(" , PROC_TYPE ");
                    sbQuery.Append(" , LOADABLE_MC ");
                    sbQuery.Append(" , SCOMMENT");
                    sbQuery.Append(" , PLN_PROC_SELF_TIME");
                    sbQuery.Append(" , PLN_PROC_MAN_TIME ");
                    sbQuery.Append(" FROM LSE_STDBOP_PROC");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND PROD_CODE = @PROD_CODE");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PROD_CODE")) isHasColumn = false;

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


        public static DataTable LSE_STDBOP_PROC_SER3(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT PLT_CODE ");
                    sbQuery.Append(" , PROD_CODE ");
                    sbQuery.Append(" , PART_ID ");
                    sbQuery.Append(" , PROC_ID ");
                    sbQuery.Append(" , SUCC_PROC_ID");
                    sbQuery.Append(" , LOADABLE_MC ");
                    sbQuery.Append(" FROM LSE_STDBOP_PROC");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND PROC_CODE = @PROC_CODE");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PROC_CODE")) isHasColumn = false;

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

        /// <summary>
        /// 해당공정이 표준BOP 에 사용되고있는지 조회
        /// </summary>
        /// <param name="dtParam"></param>
        /// <returns></returns>
        public static DataTable LSE_STDBOP_PROC_SER4(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT P.PLT_CODE ");
                    sbQuery.Append(" , P.PROD_CODE ");
                    sbQuery.Append(" FROM LSE_STDBOP_PROC P");
                    sbQuery.Append(" LEFT JOIN LSE_STDBOP_PROD PM");
                    sbQuery.Append(" ON P.PLT_CODE = PM.PLT_CODE ");
                    sbQuery.Append(" AND P.PROD_CODE = PM.PROD_CODE");
                    sbQuery.Append(" WHERE P.PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND P.PROC_CODE = @PROC_CODE");
                    sbQuery.Append(" AND PM.DATA_FLAG = 0");
                    sbQuery.Append(" GROUP BY P.PLT_CODE , P.PROD_CODE ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PROC_CODE")) isHasColumn = false;

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

        /// <summary>
        /// 각 부품별 공정수를 부품별로 조회함
        /// </summary>
        /// <param name="dtParam"></param>
        /// <returns></returns>
        public static DataTable LSE_STDBOP_PROC_SER5(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT PLT_CODE ");
                    sbQuery.Append(" , PROD_CODE ");
                    sbQuery.Append(" , PART_ID ");
                    sbQuery.Append(" , COUNT(*) AS CNT ");
                    sbQuery.Append(" FROM LSE_STDBOP_PROC ");                    
                    sbQuery.Append(" WHERE P.PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND PROD_CODE = @PROD_CODE");
                    sbQuery.Append(" GROUP BY PLT_CODE , PROD_CODE, PART_ID ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PROD_CODE")) isHasColumn = false;

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

        /// <summary>
        /// 표준BOP_공정(수정)
        /// </summary>
        /// <param name="dtParam"></param>
        public static void LSE_STDBOP_PROC_UPD(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" UPDATE LSE_STDBOP_PROC");
                    sbQuery.Append(" SET PROD_CODE = @PROD_CODE");
                    sbQuery.Append(" , PART_ID = @PART_ID");
                    sbQuery.Append(" , PROC_ID = @PROC_ID");
                    sbQuery.Append(" , SUCC_PROC_ID = @SUCC_PROC_ID");
                    sbQuery.Append(" , SPLIT_PROC_ID = @SPLIT_PROC_ID");
                    sbQuery.Append(" , SAMC_PART_ID = @SAMC_PART_ID");
                    sbQuery.Append(" , SAMC_PROC_ID = @SAMC_PROC_ID");
                    sbQuery.Append(" , PROC_TYPE = @PROC_TYPE");
                    sbQuery.Append(" , LOADABLE_MC = @LOADABLE_MC");
                    sbQuery.Append(" , SCOMMENT = @SCOMMENT");
                    sbQuery.Append(" , PLN_PROC_SELF_TIME = @PLN_PROC_SELF_TIME");
                    sbQuery.Append(" , PLN_PROC_MAN_TIME = @PLN_PROC_MAN_TIME");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND PROD_CODE = @PROD_CODE");
                    sbQuery.Append(" AND PART_ID = @PART_ID");
                    sbQuery.Append(" AND PROC_ID = @PROC_ID");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;


                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PROD_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PART_ID")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PROC_ID")) isHasColumn = false;

                        if (isHasColumn == true)
                        {
                            bizExecute.executeUpdateQuery(sbQuery.ToString(),row);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }

        /// <summary>
        /// 표준공정 가용설비 수정으로인한 로딩설비 수정
        /// </summary>
        /// <param name="dtParam"></param>
        public static void LSE_STDBOP_PROC_UPD2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" UPDATE LSE_STDBOP_PROC");
                    sbQuery.Append(" SET LOADABLE_MC = @LOADABLE_MC");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND PROD_CODE = @PROD_CODE");
                    sbQuery.Append(" AND PART_ID = @PART_ID");
                    sbQuery.Append(" AND PROC_ID = @PROC_ID");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;


                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PROD_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PART_ID")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PROC_ID")) isHasColumn = false;

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
        /// 표준BOP_공정(삭제)
        /// </summary>
        /// <param name="dtParam"></param>
        public static void LSE_STDBOP_PROC_DEL(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" DELETE FROM LSE_STDBOP_PROC ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND PROD_CODE = @PROD_CODE");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PROD_CODE")) isHasColumn = false;

                        if (isHasColumn == true)
                        {
                            bizExecute.executeUpdateQuery(sbQuery.ToString(),row);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }

        /// <summary>
        /// 표준BOP_공정(삭제)
        /// </summary>
        /// <param name="dtParam"></param>
        public static void LSE_STDBOP_PROC_DEL2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" DELETE FROM LSE_STDBOP_PROC ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND PROD_CODE = @PROD_CODE");
                    sbQuery.Append(" AND PART_ID  = @PART_ID ");
                    sbQuery.Append(" AND PROC_ID  = @PROC_ID ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PROD_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PART_ID")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PROC_ID")) isHasColumn = false;

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
        /// 표쥰BOP_공정(추가)
        /// </summary>
        /// <param name="dtParam"></param>
        public static void LSE_STDBOP_PROC_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" INSERT INTO LSE_STDBOP_PROC");
                    sbQuery.Append(" (");
                    sbQuery.Append(" PLT_CODE ");
                    sbQuery.Append(" , PROD_CODE");
                    sbQuery.Append(" , PART_ID");
                    sbQuery.Append(" , PROC_ID");
                    sbQuery.Append(" , PROC_STDC");
                    sbQuery.Append(" , PROC_CODE");
                    sbQuery.Append(" , SUCC_PROC_ID ");
                    sbQuery.Append(" , SPLIT_PROC_ID");
                    sbQuery.Append(" , SAMC_PART_ID ");
                    sbQuery.Append(" , SAMC_PROC_ID ");
                    sbQuery.Append(" , PROC_TYPE");
                    sbQuery.Append(" , LOADABLE_MC");
                    sbQuery.Append(" , SCOMMENT ");
                    sbQuery.Append(" , PLN_PROC_SELF_TIME ");
                    sbQuery.Append(" , PLN_PROC_MAN_TIME");
                    sbQuery.Append(" )");
                    sbQuery.Append(" VALUES ");
                    sbQuery.Append(" (");
                    sbQuery.Append(" @PLT_CODE");
                    sbQuery.Append(" , @PROD_CODE ");
                    sbQuery.Append(" , @PART_ID ");
                    sbQuery.Append(" , @PROC_ID ");
                    sbQuery.Append(" , @PROC_STDC ");
                    sbQuery.Append(" , @PROC_CODE ");
                    sbQuery.Append(" , @SUCC_PROC_ID");
                    sbQuery.Append(" , @SPLIT_PROC_ID ");
                    sbQuery.Append(" , @SAMC_PART_ID");
                    sbQuery.Append(" , @SAMC_PROC_ID");
                    sbQuery.Append(" , @PROC_TYPE ");
                    sbQuery.Append(" , @LOADABLE_MC ");
                    sbQuery.Append(" , @SCOMMENT");
                    sbQuery.Append(" , @PLN_PROC_SELF_TIME");
                    sbQuery.Append(" , @PLN_PROC_MAN_TIME ");
                    sbQuery.Append(" )");

                    foreach (DataRow row in dtParam.Rows)
                    {                       
                        bizExecute.executeInsertQuery(sbQuery.ToString(), row);
                    }
                }
            }
            catch(Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }        

    }

    public class LSE_STDBOP_PROC_QUERY
    {
        public static DataTable LSE_STDBOP_PROC_QUERY2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {

                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("SELECT P.PLT_CODE ");
                    sbQuery.Append(" ,P.PART_CODE ");
                    sbQuery.Append(" ,P.PART_NAME ");
                    sbQuery.Append(" ,P.PART_ENAME ");
                    sbQuery.Append(" ,P.PART_SEQ ");
                    sbQuery.Append(" ,P.MAT_TYPE ");
                    sbQuery.Append(" ,P.PART_PRODTYPE ");
                    sbQuery.Append(" ,P.MAT_LTYPE ");
                    sbQuery.Append(" ,P.MAT_MTYPE ");
                    sbQuery.Append(" ,P.MAT_UNIT ");
                    sbQuery.Append(" ,P.MAT_COST ");
                    sbQuery.Append(" ,P.MAT_QLTY ");
                    sbQuery.Append(" ,QLTY.MQLTY_NAME AS MAT_QLTY_NAME ");
                    sbQuery.Append(" ,P.MAIN_VND ");
                    sbQuery.Append(" ,VEN.VEN_NAME AS MAIN_VND_NAME ");
                    sbQuery.Append(" ,P.STD_PT_NUM ");
                    sbQuery.Append(" ,P.SCOMMENT ");
                    sbQuery.Append(" ,P.REG_DATE ");
                    sbQuery.Append(" ,P.REG_EMP ");
                    sbQuery.Append(" ,REG_EMP.EMP_NAME AS REG_EMP_NAME ");
                    sbQuery.Append(" ,P.MDFY_DATE ");
                    sbQuery.Append(" ,P.MDFY_EMP ");
                    sbQuery.Append(" ,MDFY_EMP.EMP_NAME AS MDFY_EMP_NAME ");
                    sbQuery.Append(" ,P.DATA_FLAG ");
                    sbQuery.Append(" ,P.SPEC_TYPE ");
                    sbQuery.Append(" ,P.MAT_STYPE ");
                    sbQuery.Append(" ,P.MAT_SPEC ");
                    sbQuery.Append(" ,P.MAT_SPEC1 ");
                    sbQuery.Append(" ,P.SCH_METHOD ");
                    sbQuery.Append(" ,P.LOAD_FLAG ");
                    sbQuery.Append(" ,P.INS_FLAG ");
                    sbQuery.Append(" ,P.ACT_CODE ");
                    sbQuery.Append(" ,P.SAFE_STK_QTY ");
                    sbQuery.Append(" ,P.STK_LOCATION ");
                    sbQuery.Append(" ,P.AUTO_CREATE ");
                    sbQuery.Append(" ,P.AUTO_MARGIN ");
                    sbQuery.Append(" ,P.AUTO_MARGIN_SPEC ");
                    sbQuery.Append(" ,P.STK_MNG ");
                    sbQuery.Append(" ,P.IF_PART_CODE ");
                    sbQuery.Append(" FROM LSE_STDBOP_PROC P ");
                    sbQuery.Append("LEFT JOIN TMAT_QUC_MASTER QLTY ");
                    sbQuery.Append("ON P.PLT_CODE = QLTY.PLT_CODE AND P.MAT_QLTY = QLTY.MQLTY_CODE ");
                    sbQuery.Append("LEFT JOIN TSTD_VENDOR VEN ");
                    sbQuery.Append("ON P.PLT_CODE = VEN.PLT_CODE AND P.MAIN_VND = VEN.VEN_CODE ");
                    sbQuery.Append("LEFT JOIN TSTD_MC_AVAILEEMP REG_EMP ");
                    sbQuery.Append("ON P.PLT_CODE = REG_EMP.PLT_CODE AND P.REG_EMP = REG_EMP.EMP_CODE ");
                    sbQuery.Append("LEFT JOIN TSTD_MC_AVAILEEMP MDFY_EMP ");
                    sbQuery.Append("ON P.PLT_CODE = MDFY_EMP.PLT_CODE AND P.MDFY_EMP = MDFY_EMP.EMP_CODE");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder();

                        sbWhere.Append(" WHERE P.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@PART_CODE", "P.PART_CODE = @PART_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_REG_DATE,@E_REG_DATE", "(P.REG_DATE BETWEEN @S_REG_DATE AND @E_REG_DATE)"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_LIKE", "(P.PART_CODE LIKE '%' +  @PART_LIKE + '%' OR P.PART_NAME  LIKE '%' +  @PART_LIKE + '%')"));
                        sbWhere.Append(UTIL.GetWhere(row, "@STD_PT_NUM_LIKE", "(P.STD_PT_NUM LIKE '%' + @STD_PT_NUM_LIKE + '%')"));
                        sbWhere.Append(UTIL.GetWhere(row, "@SPEC_LIKE", "(P.MAT_SPEC LIKE '%' + @SPEC_LIKE + '%' OR P.MAT_SPEC1 LIKE '%' + @SPEC_LIKE + '%')"));
                        sbWhere.Append(UTIL.GetWhere(row, "@MAT_TYPE", "P.MAT_TYPE = @MAT_TYPE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@MAT_LTYPE", "P.MAT_LTYPE = @MAT_LTYPE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@MAT_MTYPE", "P.MAT_MTYPE = @MAT_MTYPE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@MAT_STYPE", "P.MAT_STYPE = @MAT_STYPE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@STK_MNG", "P.STK_MNG = @STK_MNG"));
                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "P.DATA_FLAG = @DATA_FLAG"));
                        
                        DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString() + sbWhere.ToString()).Copy();

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
