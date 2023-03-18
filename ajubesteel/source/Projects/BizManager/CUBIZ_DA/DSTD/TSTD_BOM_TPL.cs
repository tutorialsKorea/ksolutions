using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BizExecute;
using System.Data;
using System.Data.SqlClient;

namespace DSTD
{
    public class TSTD_BOM_TPL
    {
        public static DataTable TSTD_BOM_TPL_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {

            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT PLT_CODE ");
                    sbQuery.Append(" , TPL_NAME");
                    sbQuery.Append(" , PART_CODE");
                    sbQuery.Append(" , PARENT_PART");
                    sbQuery.Append(" , BOM_QTY");
                    sbQuery.Append(" , BOM_SEQ");
                    sbQuery.Append(" , REG_DATE");
                    sbQuery.Append(" , REG_EMP ");
                    sbQuery.Append(" , MDFY_DATE ");
                    sbQuery.Append(" , MDFY_EMP");
                    sbQuery.Append(" , DEL_DATE");
                    sbQuery.Append(" , DEL_EMP ");
                    sbQuery.Append(" , DATA_FLAG ");
                    sbQuery.Append(" FROM TSTD_BOM_TPL ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND TPL_NAME = @TPL_NAME");

                    foreach (DataRow row in dtParam.Rows)
                    {                                                                   
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "TPL_NAME")) isHasColumn = false;

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

        
        public static void TSTD_BOM_TPL_UDE(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" UPDATE TSTD_BOM_TPL SET ");
                    sbQuery.Append("  DEL_DATE = GETDATE()");
                    sbQuery.Append(" , DEL_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" , DATA_FLAG = 2");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND TPL_NAME = @TPL_NAME");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "TPL_NAME")) isHasColumn = false;

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

        public static void TSTD_BOM_TPL_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {

                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" INSERT INTO TSTD_BOM_TPL");
                    sbQuery.Append(" ( ");
                    sbQuery.Append(" PLT_CODE");
                    sbQuery.Append(" , TPL_NAME");
                    sbQuery.Append(" , PART_CODE");
                    sbQuery.Append(" , PARENT_PART");
                    sbQuery.Append(" , BOM_QTY");
                    sbQuery.Append(" , BOM_SEQ");
                    sbQuery.Append(" , REG_DATE");
                    sbQuery.Append(" , REG_EMP ");
                    sbQuery.Append(" , DATA_FLAG ");
                    sbQuery.Append(" ) ");
                    sbQuery.Append(" VALUES");
                    sbQuery.Append(" ( ");
                    sbQuery.Append(" @PLT_CODE ");
                    sbQuery.Append(" , @TPL_NAME ");
                    sbQuery.Append(" , @PART_CODE ");
                    sbQuery.Append(" , @PARENT_PART ");
                    sbQuery.Append(" , @BOM_QTY ");
                    sbQuery.Append(" , @BOM_SEQ ");
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

    public class TSTD_BOM_TPL_QUERY
    {
        public static DataTable TSTD_BOM_TPL_QUERY1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                
                DataTable dtResult = new DataTable("RSLTDT");

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT ");
                    sbQuery.Append("  T.TPL_NAME ");
                    sbQuery.Append("  , T.REG_DATE ");
                    sbQuery.Append("  , T.REG_EMP ");
                    sbQuery.Append("  , E.EMP_NAME AS REG_EMP_NAME ");
                    sbQuery.Append("  , T.PART_CODE ");
                    sbQuery.Append(" FROM TSTD_BOM_TPL T JOIN TSTD_EMPLOYEE E ");
                    sbQuery.Append("  ON T.PLT_CODE = E.PLT_CODE ");
                    sbQuery.Append("  AND T.REG_EMP = E.EMP_CODE ");
                    sbQuery.Append(" WHERE PARENT_PART IS NULL");
                    sbQuery.Append("   AND T.DATA_FLAG = 0 ");
                    dtResult = bizExecute.executeSelectQuery(sbQuery.ToString()).Copy();
                }

                return dtResult;
               
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }

        public static DataTable TSTD_BOM_TPL_QUERY2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {

                DataTable dtResult = new DataTable("RSLTDT");

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT T.PLT_CODE	");
                    sbQuery.Append("  ,T.TPL_NAME      	");
                    sbQuery.Append("  ,T.PARENT_PART 	");
                    sbQuery.Append("  ,T.PART_CODE	 	");
                    sbQuery.Append("  ,S.PART_NAME	");
                    sbQuery.Append("  ,S.MAT_SPEC	    ");
                    sbQuery.Append("  ,S.MAT_SPEC1  	");
                    sbQuery.Append("  ,T.BOM_QTY  	");
                    sbQuery.Append("  ,T.BOM_SEQ  	"); 		
                    sbQuery.Append("  ,T.REG_DATE			");									
                    sbQuery.Append("  ,T.REG_EMP			");								
                    sbQuery.Append("  ,T.MDFY_DATE		");						
                    sbQuery.Append("  ,T.MDFY_EMP			");			
                    sbQuery.Append("  FROM TSTD_BOM_TPL T JOIN LSE_STD_PART S	");
                    sbQuery.Append("   ON T.PLT_CODE = S.PLT_CODE	");
                    sbQuery.Append("  AND T.PART_CODE = S.PART_CODE	");

                    StringBuilder sbWhere = new StringBuilder(" WHERE T.PLT_CODE = " + UTIL.GetValidValue(dtParam.Rows[0], "PLT_CODE").ToString());

                    sbWhere.Append(UTIL.GetWhere(dtParam.Rows[0], "@TPL_NAME", "T.TPL_NAME = @TPL_NAME"));

                    sbWhere.Append(" AND S.DATA_FLAG = 0 AND T.DATA_FLAG = 0");
                    sbWhere.Append(" ORDER BY ISNULL(T.BOM_SEQ, 0) ");

                    dtResult = bizExecute.executeSelectQuery(sbQuery.ToString() +sbWhere.ToString()).Copy();

                }

                return dtResult;

            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }
    }
}

