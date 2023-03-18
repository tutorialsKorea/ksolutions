using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using BizExecute;

namespace DLSE
{
    public class LSE_STD_AVAILMC
    {
        /// <summary>
        /// 특정 설비의 공정 조회
        /// </summary>
        /// <param name="dtParam"></param>
        /// <returns></returns>
        public static DataTable LSE_STD_AVAILMC_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT PLT_CODE ");
                    sbQuery.Append(" , PROC_CODE ");
                    sbQuery.Append(" , MC_CODE ");
                    sbQuery.Append(" , MC_SEQ");                    
                    sbQuery.Append(" FROM LSE_STD_AVAILMC ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND MC_CODE  = @MC_CODE ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "MC_CODE ")) isHasColumn = false;

                        if (isHasColumn == true)
                        {                            

                            DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString(),row).Copy();

                            sourceTable.TableName = "RSLTDT";
                            dsResult.Merge(sourceTable);  
                        }
                    }
                }
                return dsResult.Tables[0].Copy();
            }
            catch(Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }    
        }

        /// <summary>
        /// 특정 공정의 설비
        /// </summary>
        /// <param name="dtParam"></param>
        /// <returns></returns>
        public static DataTable LSE_STD_AVAILMC_SER2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT PLT_CODE ");
                    sbQuery.Append(" , PROC_CODE ");
                    sbQuery.Append(" , MC_CODE ");
                    sbQuery.Append(" , MC_SEQ");
                    sbQuery.Append(" FROM LSE_STD_AVAILMC ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND PROC_CODE  = @PROC_CODE ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PROC_CODE ")) isHasColumn = false;

                        if (isHasColumn == true)
                        {

                            DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString(), row).Copy();

                            sourceTable.TableName = "RSLTDT";
                            dsResult.Merge(sourceTable);  
                        }
                    }
                }
                return dsResult.Tables[0].Copy();
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }        

        /// <summary>
        /// 가용기계 삭제 공정기준
        /// </summary>
        /// <param name="dtParam"></param>
        public static void LSE_STD_AVAILMC_DEL(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" DELETE FROM LSE_STD_AVAILMC ");                    
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND PROC_CODE = @PROC_CODE");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PROC_CODE")) isHasColumn = false;

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
        /// 가용기계 삭제 설비기준
        /// </summary>
        /// <param name="dtParam"></param>
        public static void LSE_STD_AVAILMC_DEL2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" DELETE FROM LSE_STD_AVAILMC ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND MC_CODE = @MC_CODE");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "MC_CODE")) isHasColumn = false;

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
        /// 가용기계 삭제
        /// </summary>
        /// <param name="dtParam"></param>
        public static void LSE_STD_AVAILMC_DEL3(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" DELETE FROM LSE_STD_AVAILMC ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;

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

        public static void LSE_STD_AVAILMC_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" INSERT INTO LSE_STD_AVAILMC");
                    sbQuery.Append(" ( ");
                    sbQuery.Append(" PLT_CODE");
                    sbQuery.Append(" , PROC_CODE ");
                    sbQuery.Append(" , MC_CODE ");
                    sbQuery.Append(" , MC_SEQ");            
                    sbQuery.Append(" ) ");
                    sbQuery.Append(" VALUES");
                    sbQuery.Append(" ( ");
                    sbQuery.Append(" @PLT_CODE ");
                    sbQuery.Append(" , @PROC_CODE");
                    sbQuery.Append(" , @MC_CODE");
                    sbQuery.Append(" , @MC_SEQ ");          
                    sbQuery.Append(")");

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

    public class LSE_STD_AVAILMC_QUERY
    {

        public static DataTable LSE_STD_AVAILMC_QUERY1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {

                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT PLT_CODE ");
                    sbQuery.Append(" , PROC_CODE ");
                    sbQuery.Append(" , MC_CODE ");
                    sbQuery.Append(" , MC_SEQ");
                    sbQuery.Append(" FROM LSE_STD_AVAILMC ");                   

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@MC_CODE", "MC_CODE = @MC_CODE"));                        

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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dtParam"></param>
        /// <returns></returns>
        public static DataTable LSE_STD_AVAILMC_QUERY2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {

                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {                    
                        

                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT AV.PLT_CODE");
                    sbQuery.Append(" ,AV.PROC_CODE ");
                    sbQuery.Append(" ,AV.MC_CODE ");
                    sbQuery.Append(" ,M.MC_NAME");
                    sbQuery.Append(" ,AV.MC_SEQ");
                    sbQuery.Append(" ,M.MAIN_EMP ");
                    sbQuery.Append(" ,MAIN_EMP_NAME = EMP.EMP_NAME ");
                    sbQuery.Append(" ,M.MC_GROUP ");
                    sbQuery.Append(" ,M.MC_AUTOMATED ");
                    sbQuery.Append(" ,M.MC_OS");
                    sbQuery.Append(" ,M.MC_MGT_FLAG");
                    sbQuery.Append(" ,M.MC_OPEN_DATE ");
                    sbQuery.Append(" ,M.MC_CLOSE_DATE");
                    sbQuery.Append(" ,M.SCOMMENT ");
                    sbQuery.Append(" FROM LSE_STD_AVAILMC AV ");
                    sbQuery.Append(" LEFT JOIN LSE_MACHINE M ON AV.PLT_CODE = M.PLT_CODE AND AV.MC_CODE = M.MC_CODE");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE EMP ON M.PLT_CODE = EMP.PLT_CODE AND M.MAIN_EMP = EMP.EMP_CODE");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        
                        if (!UTIL.ValidColumn(row, "PROC_CODE ")) isHasColumn = false;

                        if (isHasColumn == true)
                        {
                            StringBuilder sbWhere = new StringBuilder(" WHERE AV.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                            
                            sbWhere.Append(UTIL.GetWhere(row, "@PROC_CODE", "AV.PROC_CODE = @PROC_CODE"));

                            sbWhere.Append(" ORDER BY AV.MC_SEQ ");

                            DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString() + sbWhere.ToString()).Copy();

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


        /// <summary>
        /// 표준설비 조회
        /// </summary>
        /// <param name="dtParam"></param>
        /// <returns></returns>
        public static DataTable LSE_STD_AVAILMC_QUERY3(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {

                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {


                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT A.PLT_CODE,");
                    sbQuery.Append(" A.MC_CODE,");
                    sbQuery.Append(" A.MC_NAME,");
                    sbQuery.Append(" A.MC_MODEL, ");
                    sbQuery.Append(" A.MC_GROUP, ");
                    sbQuery.Append(" A.MC_AUTOMATED, ");
                    sbQuery.Append(" A.MC_OS , ");
                    sbQuery.Append(" A.MC_MGT_FLAG,");
                    sbQuery.Append(" A.MC_OPEN_DATE, ");
                    sbQuery.Append(" A.MC_CLOSE_DATE,");
                    //sbQuery.Append(" A.MC_SEQ, ");
                    sbQuery.Append(" A.MAIN_EMP, ");
                    sbQuery.Append(" B.EMP_NAME AS MAIN_EMP_NAME,");
                    sbQuery.Append(" A.MC_TYPE,");
                    sbQuery.Append(" A.CPROC_CODE, ");
                    sbQuery.Append(" UM.UTC_NAME AS CPROC_NAME,");
                    sbQuery.Append(" A.MC_EFFICIENCY,");
                    sbQuery.Append(" A.SCOMMENT, ");
                    sbQuery.Append(" A.REG_DATE, ");
                    sbQuery.Append(" A.REG_EMP,");
                    sbQuery.Append(" REG.EMP_NAME AS REG_EMP_NAME, ");
                    sbQuery.Append(" A.MDFY_DATE,");
                    sbQuery.Append(" A.MDFY_EMP, ");
                    sbQuery.Append(" MDFY.EMP_NAME AS MDFY_EMP_NAME, ");
                    sbQuery.Append(" A.MC_SHIFT, ");
                    sbQuery.Append(" A.IS_SIGNAL,");
                    sbQuery.Append(" A.MC_IP,");
                    sbQuery.Append(" A.PLC_IP ,");
                    sbQuery.Append(" A.IS_OPERATE_STATE");
                    sbQuery.Append(" FROM LSE_STD_AVAILMC AV ");
                    sbQuery.Append(" LEFT JOIN LSE_MACHINE A ");
                    sbQuery.Append(" ON AV.PLT_CODE = A.PLT_CODE ");
                    sbQuery.Append(" AND AV.MC_CODE = A.MC_CODE");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE B ");
                    sbQuery.Append(" ON A.PLT_CODE = B.PLT_CODE AND A.MAIN_EMP = B.EMP_CODE");
                    sbQuery.Append(" LEFT JOIN TCST_UNIT_COST_MASTER UM");
                    sbQuery.Append(" ON A.PLT_CODE = UM.PLT_CODE AND A.CPROC_CODE = UM.UTC_CODE");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE REG ");
                    sbQuery.Append(" ON A.PLT_CODE = REG.PLT_CODE AND A.REG_EMP = REG.EMP_CODE ");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE MDFY");
                    sbQuery.Append(" ON A.PLT_CODE = MDFY.PLT_CODE AND A.MDFY_EMP = MDFY.EMP_CODE");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        StringBuilder sbWhere = new StringBuilder(" WHERE A.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@MC_CODE", "A.MC_CODE = @MC_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PROC_CODE", "AV.PROC_CODE = @PROC_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@MC_GROUP", "A.MC_GROUP = @MC_GROUP"));
                        sbWhere.Append(UTIL.GetWhere(row, "@AVAILEMP", "A.MC_CODE IN (SELECT MC_CODE FROM TSTD_MC_AVAILEMP WHERE EMP_CODE = @AVAILEMP)"));
                        sbWhere.Append(UTIL.GetWhere(row, "@MC_LIKE", "(A.MC_CODE LIKE '%' + @MC_LIKE + '%' OR A.MC_NAME LIKE '%' + @MC_LIKE + '%')"));
                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "A.DATA_FLAG = @DATA_FLAG"));                        

                        sbWhere.Append(" ORDER BY A.MC_SEQ ");

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

        /// <summary>
        /// 로딩 가능 설비 가져오기(공정별)
        /// </summary>
        /// <param name="dtParam"></param>
        /// <returns></returns>
        public static DataTable LSE_STD_AVAILMC_QUERY4(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {

                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {

                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT A.PLT_CODE, ");
	                sbQuery.Append(" A.MC_CODE, ");
	                sbQuery.Append(" M.MC_NAME, ");
	                sbQuery.Append(" A.PLT_CODE, ");
	                sbQuery.Append(" A.PROC_CODE ");
                    sbQuery.Append(" FROM LSE_STD_AVAILMC A  ");
                    sbQuery.Append(" LEFT JOIN LSE_MACHINE M ");
                    sbQuery.Append(" ON A.PLT_CODE = M.PLT_CODE ");
	                sbQuery.Append(" AND A.MC_CODE = M.MC_CODE ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE A.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@PROC_CODE", "A.PROC_CODE = @PROC_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "", "M.DATA_FLAG = 0 ORDER BY A.PLT_CODE, A.MC_SEQ"));                        

                        sbWhere.Append(" ORDER BY AV.MC_SEQ ");

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

        public static DataTable LSE_STD_AVAILMC_QUERY5(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {

                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT ");
                    sbQuery.Append(" A.PLT_CODE");
                    sbQuery.Append(" ,A.PROC_CODE");
                    sbQuery.Append(" ,P.PROC_NAME");
                    sbQuery.Append(" FROM LSE_STD_AVAILMC A");
                    sbQuery.Append(" LEFT JOIN LSE_STD_PROC P");
                    sbQuery.Append(" ON A.PROC_CODE = P.PROC_CODE");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE A.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@MC_CODE", "MC_CODE = @MC_CODE"));

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

        //그리드 설비 리스트 LookupEdit 바인딩시 추가(공정별 필터링 필요)
        public static DataTable LSE_STD_AVAILMC_QUERY6(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {

                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    
                    sbQuery.Append(" SELECT AM.PLT_CODE ");
                    sbQuery.Append(" ,AM.PROC_CODE ");
                    sbQuery.Append(" ,AM.MC_CODE ");
                    //sbQuery.Append(" ,AM.MC_CODE AS W_MC_CODE ");
                    sbQuery.Append(" ,AM.PROC_CODE+':'+AM.MC_CODE AS PROC_MC_CODE  ");
                    sbQuery.Append(" ,MC.MC_NAME ");
                    sbQuery.Append(" ,MC.MC_OS ");
                    sbQuery.Append(" FROM LSE_STD_AVAILMC AM ");
                    sbQuery.Append(" LEFT JOIN LSE_MACHINE MC ");
                    sbQuery.Append(" ON AM.PLT_CODE = MC.PLT_CODE ");
                    sbQuery.Append(" AND AM.MC_CODE = MC.MC_CODE ");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE AM.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@MC_CODE", "MC_CODE = @MC_CODE"));
                        sbWhere.Append(" ORDER BY MC.MC_SEQ ");
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
