using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using BizExecute;

namespace DLSE
{
    public class LSE_STD_PARTPROC
    {
        public static DataTable LSE_STD_PARTPROC_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT PLT_CODE ");
                    sbQuery.Append(" , PART_CODE ");
                    sbQuery.Append(" , PROC_CODE");
                    sbQuery.Append(" , PROC_SEQ");
                    sbQuery.Append(" , IS_OS");
                    sbQuery.Append(" , MC_CODE");
                    sbQuery.Append(" , EMP_CODE");
                    sbQuery.Append(" , PROC_TIME");
                    sbQuery.Append(" , STD_TIME");
                    sbQuery.Append(" , SCOMMENT");
                    sbQuery.Append(" , PUR_SCOMMENT");

                    sbQuery.Append(" , PROC_FILE_NAME ");
                    //sbQuery.Append(" , PROC_FILE_CONTENT ");
                    
                    sbQuery.Append(" , REG_EMP ");
                    sbQuery.Append(" , REG_DATE");
                    sbQuery.Append(" FROM LSE_STD_PARTPROC ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND PART_CODE = @PART_CODE");
                    sbQuery.Append(" AND PROC_CODE = @PROC_CODE");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PART_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PROC_CODE")) isHasColumn = false;                        

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

        public static DataTable LSE_STD_PARTPROC_SER2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT PP.PLT_CODE ");
                    sbQuery.Append(" , PP.PART_CODE ");
                    sbQuery.Append(" , PP.PROC_CODE");
                    sbQuery.Append(" , PP.PROC_SEQ");
                    sbQuery.Append(" , PP.IS_OS");
                    sbQuery.Append(" , PP.MC_CODE");
                    sbQuery.Append(" , M.MC_NAME");
                    sbQuery.Append(" , PP.EMP_CODE");
                    sbQuery.Append(" , E.EMP_NAME");
                    sbQuery.Append(" , PP.PROC_TIME");
                    sbQuery.Append(" , PP.PROC_UC");
                    sbQuery.Append(" , PP.PROC_COST");
                    sbQuery.Append(" , PP.SCOMMENT");
                    sbQuery.Append(" , PP.PUR_SCOMMENT");
                    sbQuery.Append(" , PP.REG_EMP ");
                    sbQuery.Append(" , PP.REG_DATE");
                    sbQuery.Append(" FROM LSE_STD_PARTPROC PP LEFT JOIN LSE_MACHINE M");
                    sbQuery.Append("  ON PP.PLT_CODE = M.PLT_CODE AND PP.MC_CODE = M.MC_CODE ");
                    sbQuery.Append("  LEFT JOIN LSE_STD_PROC PR ");
                    sbQuery.Append("  ON PP.PLT_CODE = PR.PLT_CODE AND PP.PROC_CODE = PR.PROC_CODE ");
                    sbQuery.Append("  LEFT JOIN TSTD_EMPLOYEE E ON PP.PLT_CODE = E.PLT_CODE AND PP.EMP_CODE = E.EMP_CODE ");
                    sbQuery.Append(" WHERE PP.PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND PP.PART_CODE = @PART_CODE");
                    sbQuery.Append(" AND PR.DATA_FLAG = 0");

                    
                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PART_CODE")) isHasColumn = false;

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

        public static DataTable LSE_STD_PARTPROC_SER3(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();
                DataTable dtResult = new DataTable();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT PLT_CODE ");
                    sbQuery.Append(" , PART_CODE ");
                    sbQuery.Append(" , PROC_CODE");
                    sbQuery.Append(" , PROC_SEQ");
                    sbQuery.Append(" , IS_OS");
                    sbQuery.Append(" , MC_CODE");
                    sbQuery.Append(" , EMP_CODE");
                    sbQuery.Append(" , REG_EMP ");
                    sbQuery.Append(" , REG_DATE");
                    sbQuery.Append(" FROM LSE_STD_PARTPROC ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND PART_CODE = @PART_CODE");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PART_CODE")) isHasColumn = false;

                        if (isHasColumn == true)
                        {
                            dtResult = bizExecute.executeSelectQuery(sbQuery.ToString(), row).Copy();

                            dtResult.TableName = "RSLTDT";
                            //DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString(), row).Copy();

                            //sourceTable.TableName = "RSLTDT";
                            //dsResult.Merge(sourceTable);
                        }
                    }
                }

                return dtResult;
                //return UTIL.GetDsToDt(dsResult);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataTable LSE_STD_PARTPROC_SER4(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT PLT_CODE ");
                    sbQuery.Append(" , PROC_FILE_NAME ");
                    sbQuery.Append(" , PROC_FILE_CONTENT");
                    sbQuery.Append(" FROM LSE_STD_PARTPROC ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND PART_CODE = @PART_CODE");
                    sbQuery.Append(" AND PROC_CODE = @PROC_CODE");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PART_CODE")) isHasColumn = false;
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

        public static void LSE_STD_PARTPROC_DEL(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" DELETE FROM LSE_STD_PARTPROC ");                    
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND PART_CODE = @PART_CODE");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PART_CODE")) isHasColumn = false;

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

        public static void LSE_STD_PARTPROC_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" INSERT INTO LSE_STD_PARTPROC");
                    sbQuery.Append(" ( ");
                    sbQuery.Append(" PLT_CODE");
                    sbQuery.Append(" , PART_CODE ");
                    sbQuery.Append(" , PROC_CODE ");
                    sbQuery.Append(" , PROC_SEQ");
                    sbQuery.Append(" , IS_SAMPLING");
                    sbQuery.Append(" , IS_OS");
                    sbQuery.Append(" , INS_FLAG");
                    sbQuery.Append(" , MC_CODE");
                    sbQuery.Append(" , EMP_CODE");
                    sbQuery.Append(" , STD_TIME");
                    sbQuery.Append(" , PROC_TIME");
                    sbQuery.Append(" , PROC_UC");
                    sbQuery.Append(" , PROC_COST");
                    sbQuery.Append(" , SCOMMENT");
                    sbQuery.Append(" , PUR_SCOMMENT");
                    sbQuery.Append(" , REG_DATE");
                    sbQuery.Append(" , REG_EMP ");                    
                    sbQuery.Append(" ) ");
                    sbQuery.Append(" VALUES");
                    sbQuery.Append(" ( ");
                    sbQuery.Append(" @PLT_CODE ");
                    sbQuery.Append(" , @PART_CODE");
                    sbQuery.Append(" , @PROC_CODE");
                    sbQuery.Append(" , @PROC_SEQ");
                    sbQuery.Append(" , @IS_SAMPLING");
                    sbQuery.Append(" , @IS_OS");
                    sbQuery.Append(" , @INS_FLAG");
                    sbQuery.Append(" , @MC_CODE");
                    sbQuery.Append(" , @EMP_CODE");
                    sbQuery.Append(" , @STD_TIME");
                    sbQuery.Append(" , @PROC_TIME");
                    sbQuery.Append(" , @PROC_UC");
                    sbQuery.Append(" , @PROC_COST");
                    sbQuery.Append(" , @SCOMMENT");
                    sbQuery.Append(" , @PUR_SCOMMENT");
                    sbQuery.Append(" , GETDATE() ");
                    sbQuery.Append(" , " + UTIL.GetValidValue(ConnInfo.UserID));
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

        public static void LSE_STD_PARTPROC_INS2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" INSERT INTO LSE_STD_PARTPROC");
                    sbQuery.Append(" ( ");
                    sbQuery.Append(" PLT_CODE");
                    sbQuery.Append(" , PART_CODE ");
                    sbQuery.Append(" , PROC_CODE ");
                    sbQuery.Append(" , PROC_SEQ");
                    sbQuery.Append(" , IS_OS");
                    sbQuery.Append(" , IS_SAMPLING");
                    sbQuery.Append(" , INS_FLAG");
                    sbQuery.Append(" , STD_TIME");
                    sbQuery.Append(" , MC_CODE");
                    sbQuery.Append(" , EMP_CODE");
                    sbQuery.Append(" , PROC_TIME");
                    sbQuery.Append(" , PROC_UC");
                    sbQuery.Append(" , PROC_COST");
                    sbQuery.Append(" , SCOMMENT");
                    sbQuery.Append(" , REG_DATE");
                    sbQuery.Append(" , REG_EMP ");
                    sbQuery.Append(" ) ");
                    sbQuery.Append(" SELECT ");
                    sbQuery.Append(" PLT_CODE   ");
                    sbQuery.Append(" , @PART_CODE ");
                    sbQuery.Append(" , PROC_CODE ");   
                    sbQuery.Append(" , PROC_SEQ  ");
                    sbQuery.Append(" , IS_OS");
                    sbQuery.Append(" , IS_SAMPLING");
                    sbQuery.Append(" , INS_FLAG");
                    sbQuery.Append(" , STD_TIME");
                    sbQuery.Append(" , MC_CODE   ");
                    sbQuery.Append(" , EMP_CODE  ");
                    sbQuery.Append(" , PROC_TIME ");
                    sbQuery.Append(" , PROC_UC   ");
                    sbQuery.Append(" , PROC_COST ");
                    sbQuery.Append(" , SCOMMENT  ");
                    sbQuery.Append(" , GETDATE() ");
                    sbQuery.Append(" , " + UTIL.GetValidValue(ConnInfo.UserID));
                    
                    sbQuery.Append(" FROM LSE_STD_PARTPROC ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append("   AND PART_CODE = @O_PART_CODE ");

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


        public static void LSE_STD_PARTPROC_UPD(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE  LSE_STD_PARTPROC SET");
                    sbQuery.Append(" MC_CODE = @MC_CODE");
                    sbQuery.Append(" , EMP_CODE = @EMP_CODE");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND PART_CODE = @PART_CODE");
                    sbQuery.Append(" AND PROC_CODE = @PROC_CODE");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PART_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PROC_CODE")) isHasColumn = false;

                        if (isHasColumn == true)
                        {
                            bizExecute.executeInsertQuery(sbQuery.ToString(), row);
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
        /// 자재발주 공정에 공수계, 단가, 소재비 업데이트
        /// </summary>
        /// <param name="dtParam"></param>
        /// <param name="bizExecute"></param>
        public static void LSE_STD_PARTPROC_UPD2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE  LSE_STD_PARTPROC SET");
                    sbQuery.Append("  PROC_TIME = @PROC_TIME");
                    sbQuery.Append(" , PROC_UC = @PROC_UC");
                    sbQuery.Append(" , PROC_COST = @PROC_COST");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND PART_CODE = @PART_CODE");
                    sbQuery.Append(" AND PROC_CODE = @PROC_CODE");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PART_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PROC_CODE")) isHasColumn = false;

                        if (isHasColumn == true)
                        {
                            bizExecute.executeInsertQuery(sbQuery.ToString(), row);
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static void LSE_STD_PARTPROC_UPD3(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" UPDATE LSE_STD_PARTPROC");
                    sbQuery.Append(" SET PROC_FILE_NAME = @PROC_FILE_NAME");
                    sbQuery.Append(" , PROC_FILE_CONTENT = @PROC_FILE_CONTENT ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append(" AND PART_CODE = @PART_CODE ");
                    sbQuery.Append(" AND PROC_CODE = @PROC_CODE ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;


                        if (!UTIL.ValidColumn(row, "PART_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PROC_CODE")) isHasColumn = false;

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

    public class LSE_STD_PARTPROC_QUERY
    {        

        //부품별 공정
        public static DataTable LSE_STD_PARTPROC_QUERY2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("  SELECT ");
                    sbQuery.Append("  P.PLT_CODE ");
                    sbQuery.Append("  ,P.PART_CODE ");
                    sbQuery.Append("  ,P.PROC_CODE ");
                    sbQuery.Append(" , P.IS_OS");
                    sbQuery.Append(" , P.IS_SAMPLING");
                    sbQuery.Append("  ,P.STD_TIME ");
                    sbQuery.Append("  ,SP.PROC_NAME ");
                    sbQuery.Append("  ,SP.IS_ASSY ");
                    sbQuery.Append("  ,P.PROC_SEQ ");
                    sbQuery.Append("  ,SP.PROC_SEQ AS STD_PROC_SEQ");
                    sbQuery.Append("  FROM LSE_STD_PARTPROC P ");
                    sbQuery.Append("  LEFT JOIN LSE_STD_PROC SP ");
                    sbQuery.Append("  ON P.PLT_CODE = SP.PLT_CODE ");
                    sbQuery.Append("  AND P.PROC_CODE = SP.PROC_CODE ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE P.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                        sbWhere.Append(" AND SP.DATA_FLAG = 0 ");

                        sbWhere.Append(UTIL.GetWhere(row, "@PART_CODE", "PART_CODE = @PART_CODE"));

                        sbWhere.Append(" ORDER BY P.PROC_SEQ");

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

        public static DataTable LSE_STD_PARTPROC_QUERY2_1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("  SELECT ");
                    sbQuery.Append("  P.PLT_CODE ");
                    sbQuery.Append("  ,P.PART_CODE ");
                    sbQuery.Append("  ,P.PROC_CODE ");
                    sbQuery.Append(" , P.IS_SAMPLING");
                    sbQuery.Append(" , P.IS_OS");
                    sbQuery.Append(" , P.INS_FLAG");
                    sbQuery.Append("  ,P.STD_TIME ");
                    sbQuery.Append("  ,SP.PROC_NAME ");
                    sbQuery.Append("  ,SP.IS_ASSY ");
                    sbQuery.Append("  ,P.PROC_SEQ ");
                    sbQuery.Append("  ,SP.PROC_SEQ AS STD_PROC_SEQ");
                    sbQuery.Append("  FROM LSE_STD_PARTPROC P ");
                    sbQuery.Append("  LEFT JOIN LSE_STD_PROC SP ");
                    sbQuery.Append("  ON P.PLT_CODE = SP.PLT_CODE ");
                    sbQuery.Append("  AND P.PROC_CODE = SP.PROC_CODE ");


                    StringBuilder sbWhere = new StringBuilder(" WHERE P.PLT_CODE = " + ConnInfo.PLT_CODE);
                    sbWhere.Append(" AND PART_CODE IN (");
                    foreach (DataRow row in dtParam.Rows)
                    {
                        sbWhere.Append(UTIL.GetValidValue(row, "PART_CODE").ToString());
                        if (dtParam.Rows.IndexOf(row) != dtParam.Rows.Count - 1)
                        {
                            sbWhere.Append(",");
                        }
                    }

                    sbWhere.Append(" ) AND SP.DATA_FLAG = 0 ");
                    sbWhere.Append(" ORDER BY P.PROC_SEQ");

                    DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString() + sbWhere.ToString()).Copy();

                    sourceTable.TableName = "RSLTDT";
                    dsResult.Merge(sourceTable);
                }


                return UTIL.GetDsToDt(dsResult);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }

        public static DataTable LSE_STD_PARTPROC_QUERY2_2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("  SELECT ");
                    sbQuery.Append("  P.PLT_CODE ");
                    sbQuery.Append("  ,P.PART_CODE ");
                    sbQuery.Append("  ,P.PROC_CODE ");
                    sbQuery.Append(" , P.IS_SAMPLING");
                    sbQuery.Append(" , P.IS_OS");
                    sbQuery.Append(" , P.INS_FLAG");
                    sbQuery.Append("  ,P.STD_TIME ");
                    sbQuery.Append("  ,SP.PROC_NAME ");
                    sbQuery.Append("  ,SP.IS_ASSY ");
                    sbQuery.Append("  ,P.PROC_SEQ ");
                    sbQuery.Append("  ,SP.PROC_SEQ AS STD_PROC_SEQ");
                    sbQuery.Append("  FROM LSE_STD_PARTPROC P ");
                    sbQuery.Append("  LEFT JOIN LSE_STD_PROC SP ");
                    sbQuery.Append("  ON P.PLT_CODE = SP.PLT_CODE ");
                    sbQuery.Append("  AND P.PROC_CODE = SP.PROC_CODE ");


                    StringBuilder sbWhere = new StringBuilder(" WHERE P.PLT_CODE = " + ConnInfo.PLT_CODE);
                    sbWhere.Append(" AND PART_CODE IN (");
                    foreach (DataRow row in dtParam.Rows)
                    {
                        sbWhere.Append(UTIL.GetValidValue(row, "PART_CODE").ToString());
                        if (dtParam.Rows.IndexOf(row) != dtParam.Rows.Count - 1)
                        {
                            sbWhere.Append(",");
                        }
                    }

                    sbWhere.Append(" ) AND SP.DATA_FLAG = 0 ");
                    sbWhere.Append(" AND SP.IS_ASSY = 0 ");
                    sbWhere.Append(" ORDER BY P.PROC_SEQ");

                    DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString() + sbWhere.ToString()).Copy();

                    sourceTable.TableName = "RSLTDT";
                    dsResult.Merge(sourceTable);
                }


                return UTIL.GetDsToDt(dsResult);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }

        public static DataTable  LSE_STD_PARTPROC_QUERY3(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT ROW_NUMBER() OVER (ORDER BY SP.PLT_CODE ASC) AS ROW_NUM, ");
                    sbQuery.Append("  SP.PROC_CODE, ");
                    sbQuery.Append("  SP.PROC_NAME, ");
                    sbQuery.Append("  SPP.PROC_CODE, ");
                    sbQuery.Append("  SPP.PROC_SEQ, ");
                    sbQuery.Append("  SPP.IS_SAMPLING, ");
                    sbQuery.Append("  SPP.IS_OS, ");
                    sbQuery.Append("  SPP.INS_FLAG, ");
                    sbQuery.Append("  SPP.PROC_CODE + ':' + SPP.MC_CODE AS MC_CODE, ");
                    sbQuery.Append("  SPP.MC_CODE + ':' + SPP.EMP_CODE AS EMP_CODE, ");
                    sbQuery.Append("  CASE WHEN SP.PROC_CODE = SPP.PROC_CODE THEN 1 ELSE 0 END SEL ");
                    sbQuery.Append("  , ISNULL(SP.IS_MAT, 0) IS_MAT");
                    sbQuery.Append("  , SPP.STD_TIME ");
                    sbQuery.Append("  , CAST(SPP.STD_TIME / 1440 AS NUMERIC(7,2)) AS STD_TIME_DAY ");
                    sbQuery.Append("  , SPP.PROC_TIME ");
                    sbQuery.Append("  , SPP.PROC_UC ");
                    sbQuery.Append("  , SPP.PROC_COST ");
                    sbQuery.Append("  , SPP.SCOMMENT ");
                    sbQuery.Append("  , SPP.PUR_SCOMMENT ");
                    //sbQuery.Append("  , SP.PROC_MAN_TIME ");
                    //sbQuery.Append("  , SP.PROC_UC ");
                    //sbQuery.Append("  , SP.PROC_COST ");
                    sbQuery.Append(" FROM LSE_STD_PROC SP  ");
                    sbQuery.Append("  LEFT OUTER JOIN LSE_STD_PARTPROC SPP ");
                    sbQuery.Append("  ON SP.PLT_CODE = SPP.PLT_CODE ");
                    sbQuery.Append("  AND SP.PROC_CODE = SPP.PROC_CODE ");
                    sbQuery.Append("  AND SPP.PART_CODE = @PART_CODE ");
                    sbQuery.Append(" WHERE SP.PLT_CODE = @PLT_CODE ");
                    sbQuery.Append("   AND SP.DATA_FLAG = 0 ");
                    sbQuery.Append("   AND SP.IS_BOP_PROC = 1 ");
                    sbQuery.Append(" ORDER BY SP.PROC_SEQ ");

                    DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString(), dtParam.Rows[0]).Copy();

                    sourceTable.TableName = "RSLTDT";
                    dsResult.Tables.Add(sourceTable);

                }


                return UTIL.GetDsToDt(dsResult);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }


        public static DataTable LSE_STD_PARTPROC_QUERY4(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT PP.PLT_CODE, PP.PART_CODE, SUM(ISNULL(PP.PROC_COST, 0)) + ISNULL(P.JIG_COST,0) + ISNULL(P.ETC_COST,0) AS PROC_COST FROM LSE_STD_PARTPROC  PP ");
                    sbQuery.Append(" LEFT JOIN LSE_STD_PART P ON PP.PLT_CODE = P.PLT_CODE AND PP.PART_CODE = P.PART_CODE     ");
                    sbQuery.Append(" WHERE PP.PLT_CODE = @PLT_CODE     ");
                    sbQuery.Append("    AND PP.PART_CODE = @PART_CODE  ");
                    sbQuery.Append("    AND PP.PROC_CODE NOT IN         ");
                    sbQuery.Append("   (SELECT PROC_CODE FROM LSE_STD_PROC  ");
                    sbQuery.Append(" 	WHERE DATA_FLAG = 0         ");
                    sbQuery.Append(" 	AND IS_MAT = 1)             ");
                    sbQuery.Append(" GROUP BY PP.PLT_CODE, PP.PART_CODE, P.JIG_COST, P.ETC_COST ");


                    DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString(), dtParam.Rows[0]).Copy();

                    sourceTable.TableName = "RSLTDT";
                    dsResult.Tables.Add(sourceTable);

                }


                return UTIL.GetDsToDt(dsResult);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }

        public static DataTable LSE_STD_PARTPROC_QUERY5(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT PP.PLT_CODE											   ");
                    sbQuery.Append(" 	 , ACT.SELF_TIME + ACT.MAN_TIME + ACT.OT_TIME AS WORK_TIME ");
                    sbQuery.Append(" 	 , PP.PROC_UC											   ");
                    sbQuery.Append(" 	 , P.IS_OS											   ");
                    sbQuery.Append("   FROM LSE_STD_PARTPROC PP									   ");
                    sbQuery.Append(" 	INNER JOIN LSE_STD_PROC P							   ");
                    sbQuery.Append(" 		ON PP.PLT_CODE = P.PLT_CODE						   ");
                    sbQuery.Append(" 		AND PP.PROC_CODE = P.PROC_CODE						   ");
                    sbQuery.Append(" 	INNER JOIN TSHP_WORKORDER TW							   ");
                    sbQuery.Append(" 		ON PP.PLT_CODE = TW.PLT_CODE						   ");
                    sbQuery.Append(" 		AND PP.PART_CODE = TW.PART_CODE						   ");
                    sbQuery.Append(" 		AND PP.PROC_CODE = TW.PROC_CODE						   ");
                    sbQuery.Append(" 	INNER JOIN TORD_PRODUCT TP							   ");
                    sbQuery.Append(" 		ON TW.PLT_CODE = TP.PLT_CODE						   ");
                    sbQuery.Append(" 		AND TW.PROD_CODE = TP.PROD_CODE						   ");
                    sbQuery.Append(" 		AND TW.PART_CODE = TP.PART_CODE						   ");
                    sbQuery.Append(" 	INNER JOIN TSHP_DAILYWORK ACT							   ");
                    sbQuery.Append(" 		ON TW.PLT_CODE = ACT.PLT_CODE						   ");
                    sbQuery.Append(" 		AND TW.WO_NO = ACT.WO_NO							   ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE PP.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_CODE", "TP.PROD_CODE = @PROD_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_CODE", "TP.PART_CODE = @PART_CODE"));
                        //sbWhere.Append(" AND TP.PARENT_PART IS NULL ");
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
