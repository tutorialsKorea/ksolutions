using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace DSTD
{
    public class TSTD_BOM
    {

        public static DataTable TSTD_BOM_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT PLT_CODE");
                    sbQuery.Append(" ,BM_KEY		");
                    sbQuery.Append(" ,BOM_ID		");
                    sbQuery.Append(" ,BM_CODE	");
                    sbQuery.Append(" ,PARENT_ID	");
                    sbQuery.Append(" ,PART_CODE		");
                    
                    sbQuery.Append(" ,BOM_QTY		");
                    sbQuery.Append(" ,BOM_SEQ		");
                    sbQuery.Append(" ,REG_DATE		");
                    sbQuery.Append(" ,REG_EMP		");
                    sbQuery.Append(" ,MDFY_DATE		");
                    sbQuery.Append(" ,MDFY_EMP		");
                    sbQuery.Append(" FROM TSTD_BOM	");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND BM_KEY = @BM_KEY	   ");
                    sbQuery.Append(" AND BM_CODE = @BM_CODE	   ");
                    sbQuery.Append(" AND BOM_ID = @BOM_ID	   ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "BOM_ID")) isHasColumn = false;

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

        public static DataTable TSTD_BOM_SER_1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT C.PLT_CODE");
                    sbQuery.Append(" ,C.BM_KEY		");
                    sbQuery.Append(" ,A.REV_NO	");
                    sbQuery.Append(" ,C.BOM_ID		");
                    sbQuery.Append(" ,C.BM_CODE	");
                    sbQuery.Append(" ,C.PARENT_ID	");
                    sbQuery.Append(" ,C.PART_CODE		");

                    sbQuery.Append(" ,D.PART_PROC AS PROC_CODE ");

                    sbQuery.Append(" ,C.PROC_GRP		");
                    sbQuery.Append(" ,C.BOM_QTY		");
                    sbQuery.Append(" ,C.BOM_QTY AS ORI_BOM_QTY 		");
                    sbQuery.Append(" ,ISNULL(C.BOM_SEQ, 1) AS BOM_SEQ ");
                    sbQuery.Append(" ,C.REG_DATE		");
                    sbQuery.Append(" ,C.REG_EMP		");
                    sbQuery.Append(" ,C.MDFY_DATE		");
                    sbQuery.Append(" ,C.MDFY_EMP		");
                    sbQuery.Append(" ,D.PART_CODE_OLD		");
                    sbQuery.Append(" ,D.PROD_NAME ");
                    sbQuery.Append(" ,D.PART_DESC ");
                    sbQuery.Append(" ,D.CUR_UNIT ");
                    sbQuery.Append(" ,D.UNIT_COST ");
                    sbQuery.Append(" ,D.MVND_CODE ");
                    sbQuery.Append(" ,C.PROC_CODE AS PART_PROC ");
                    sbQuery.Append(" ,ISNULL(CD.VALUE,'NULL') AS CD_VALUE ");
                    sbQuery.Append(" ,D.PART_TYPE				   ");
                    sbQuery.Append(" ,D.PART_CAT1				   ");
                    sbQuery.Append(" ,D.PART_CAT2				   ");
                    sbQuery.Append(" FROM TSTD_BOM_MASTER A	");
                    sbQuery.Append(" JOIN (SELECT BM_CODE, MAX(REV_NO) AS REV_NO FROM TSTD_BOM_MASTER WHERE DATA_FLAG = 0 GROUP BY BM_CODE) B ON A.BM_CODE = B.BM_CODE AND A.REV_NO = B.REV_NO ");
                    sbQuery.Append(" LEFT JOIN TSTD_BOM C ON A.BM_KEY = C.BM_KEY ");
                    sbQuery.Append(" LEFT JOIN LSE_STD_PART D ON C.PART_CODE = D.PART_CODE ");
                    sbQuery.Append("  LEFT JOIN TSTD_CODES CD ON CD.CAT_CODE = '0A01' AND D.PART_CAT1 = CD.CD_CODE			");
                    sbQuery.Append(" WHERE A.BM_CODE = @BM_CODE ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "BM_CODE")) isHasColumn = false;

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

        public static DataTable TSTD_BOM_SER2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT PLT_CODE");
                    sbQuery.Append(" ,BOM_ID		");
                    sbQuery.Append(" ,BOM_PART_CODE	");
                    sbQuery.Append(" ,PARENT_ID	");
                    sbQuery.Append(" ,PART_CODE		");
                    sbQuery.Append(" ,BOM_QTY		");
                    sbQuery.Append(" ,STOCK_CODE	");
                    sbQuery.Append(" ,STOCK_TYPE	");
                    sbQuery.Append(" ,BOM_SEQ	");
                    sbQuery.Append(" ,REG_DATE		");
                    sbQuery.Append(" ,REG_EMP		");
                    sbQuery.Append(" ,MDFY_DATE		");
                    sbQuery.Append(" ,MDFY_EMP		");
                    sbQuery.Append(" FROM TSTD_BOM	");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND BOM_PART_CODE = @BOM_PART_CODE	   ");
                    sbQuery.Append(" AND PARENT_ID = @PARENT_ID	   ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "BOM_PART_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PARENT_ID")) isHasColumn = false;

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

        public static DataTable TSTD_BOM_SER3(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT PLT_CODE");
                    sbQuery.Append(" ,BOM_ID		");
                    sbQuery.Append(" ,BOM_PART_CODE	");
                    sbQuery.Append(" ,PARENT_ID	");
                    sbQuery.Append(" ,PART_CODE		");
                    sbQuery.Append(" ,BOM_QTY		");
                    sbQuery.Append(" ,STOCK_CODE	");
                    sbQuery.Append(" ,STOCK_TYPE	");
                    sbQuery.Append(" ,BOM_SEQ   	");
                    sbQuery.Append(" ,REG_DATE		");
                    sbQuery.Append(" ,REG_EMP		");
                    sbQuery.Append(" ,MDFY_DATE		");
                    sbQuery.Append(" ,MDFY_EMP		");
                    sbQuery.Append(" FROM TSTD_BOM	");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND BOM_PART_CODE = @BOM_PART_CODE	   ");
                    sbQuery.Append(" AND PARENT_ID = @BOM_ID	   ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "BOM_PART_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "BOM_ID")) isHasColumn = false;

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


        public static DataTable TSTD_BOM_SER4(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT PLT_CODE");
                    sbQuery.Append(" ,BOM_ID		");
                    sbQuery.Append(" ,BOM_PART_CODE	");
                    sbQuery.Append(" ,PARENT_ID	");
                    sbQuery.Append(" ,PART_CODE		");
                    sbQuery.Append(" ,BOM_QTY		");
                    sbQuery.Append(" ,STOCK_CODE	");
                    sbQuery.Append(" ,STOCK_TYPE	");
                    sbQuery.Append(" ,BOM_SEQ	");
                    sbQuery.Append(" ,REG_DATE		");
                    sbQuery.Append(" ,REG_EMP		");
                    sbQuery.Append(" ,MDFY_DATE		");
                    sbQuery.Append(" ,MDFY_EMP		");
                    sbQuery.Append(" FROM TSTD_BOM	");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND BOM_PART_CODE = @BOM_PART_CODE	   ");
                    sbQuery.Append(" AND PARENT_ID IS NULL	   ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "BOM_PART_CODE")) isHasColumn = false;

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


        public static void TSTD_BOM_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" INSERT INTO TSTD_BOM");
                    sbQuery.Append(" (PLT_CODE			 ");
                    sbQuery.Append(" ,BM_KEY		");
                    sbQuery.Append(" ,BOM_ID			 ");
                    sbQuery.Append(" ,BM_CODE		 ");
                    sbQuery.Append(" ,PARENT_ID		 ");
                    sbQuery.Append(" ,PART_CODE			 ");
                    sbQuery.Append(" ,BOM_QTY			 ");
                    sbQuery.Append(" ,BOM_SEQ			 ");
                    sbQuery.Append(" ,REG_DATE			 ");
                    sbQuery.Append(" ,REG_EMP)			 ");
                    sbQuery.Append(" VALUES				 ");
                    sbQuery.Append(" (@PLT_CODE			 ");
                    sbQuery.Append(" ,@BM_KEY		");
                    sbQuery.Append(" ,@BOM_ID			 ");
                    sbQuery.Append(" ,@BM_CODE	 ");
                    sbQuery.Append(" ,@PARENT_ID		 ");
                    sbQuery.Append(" ,@PART_CODE		 ");
                    sbQuery.Append(" ,@BOM_QTY			 ");
                    sbQuery.Append(" ,@BOM_SEQ			 ");
                    sbQuery.Append(" ,GETDATE()			 ");
                    sbQuery.Append(" ," + UTIL.GetValidValue(ConnInfo.UserID));
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
        public static void TSTD_BOM_UPD(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" UPDATE TSTD_BOM		   ");
                    sbQuery.Append(" SET BOM_QTY = @BOM_QTY	   ");
                    sbQuery.Append(" ,BOM_SEQ = @BOM_SEQ ");
                    //sbQuery.Append(" ,PROC_GRP = @PROC_GRP ");
                    //sbQuery.Append(" ,PROC_CODE = @PROC_CODE ");
                    sbQuery.Append(" ,PARENT_ID = @PARENT_ID	   ");
                    sbQuery.Append(" , MDFY_DATE = GETDATE()");
                    sbQuery.Append(" , MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND BOM_ID = @BOM_ID	   ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "BOM_ID")) isHasColumn = false;

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

        public static int TSTD_BOM_UPD2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();
                int result = 0;

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" UPDATE TSTD_BOM		   ");
                    sbQuery.Append(" SET PART_CODE = @AFT_PART_CODE	   ");
                    sbQuery.Append(" , MDFY_DATE = GETDATE()");
                    sbQuery.Append(" , MDFY_EMP = @MDFY_EMP");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND PART_CODE = @BEF_PART_CODE ");

                    result = bizExecute.executeUpdateQuery2(sbQuery.ToString(), dtParam.Rows[0]);

                }

                return result;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }

        public static void TSTD_BOM_DEL2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" DELETE FROM TSTD_BOM	   ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND BM_CODE = @BM_CODE	   ");
                    sbQuery.Append(" AND BM_KEY = @BM_KEY	   ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "BM_CODE")) isHasColumn = false;

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

        public static void TSTD_BOM_COPY(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" INSERT INTO TSTD_BOM  ");
                    sbQuery.Append(" (					   ");
                    sbQuery.Append(" 	PLT_CODE		   ");
                    sbQuery.Append(" 	, BOM_ID		   ");
                    sbQuery.Append(" 	, BOM_PART_CODE	   ");
                    sbQuery.Append(" 	, PARENT_ID		   ");
                    sbQuery.Append(" 	, PART_CODE		   ");
                    sbQuery.Append(" 	, BOM_QTY		   ");
                    sbQuery.Append(" 	, BOM_SEQ		   ");
                    sbQuery.Append(" 	, REG_DATE		   ");
                    sbQuery.Append(" 	, REG_EMP		   ");
                    sbQuery.Append(" )					   ");
                    sbQuery.Append(" SELECT PLT_CODE	   ");
                    sbQuery.Append(" 	 , @BOM_ID		   ");
                    sbQuery.Append(" 	 , BOM_PART_CODE   ");
                    sbQuery.Append(" 	 , BOM_ID		   ");
                    sbQuery.Append(" 	 , @PART_CODE	   ");
                    sbQuery.Append(" 	 , @BOM_QTY		   ");
                    sbQuery.Append(" 	 , @BOM_SEQ		   ");
                    sbQuery.Append(" 	 , GETDATE()	   ");
                    sbQuery.Append(" 	 , " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" FROM TSTD_BOM	");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND BOM_ID = @BOM_ID	   ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "BOM_ID")) isHasColumn = false;

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
        public static void TSTD_BOM_DEL(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" DELETE FROM TSTD_BOM	   ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND BOM_ID = @BOM_ID	   ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "BOM_ID")) isHasColumn = false;

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

    public class TSTD_BOM_QUERY
    {
        public static DataTable TSTD_BOM_QUERY1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT B.PLT_CODE			   ");
                    sbQuery.Append(" ,B.BOM_ID					   ");
                    sbQuery.Append(" ,B.BOM_PART_CODE					   ");
                    sbQuery.Append(" ,B.PARENT_ID				   ");
                    sbQuery.Append(" ,B.PART_CODE				   ");
                    sbQuery.Append(" ,SP.PART_NAME				   ");
                    sbQuery.Append(" ,SP.DRAW_NO				   ");
                    sbQuery.Append(" ,SP.MAT_SPEC				   ");
                    sbQuery.Append(" ,SP.MAT_SPEC1				   ");
                    sbQuery.Append(" ,SP.MAT_UNIT				   ");
                    sbQuery.Append(" ,SP.IS_TURNING				   ");
                    sbQuery.Append(" ,B.BOM_QTY					   ");
                    sbQuery.Append(" ,B.STOCK_CODE				   ");
                    sbQuery.Append(" ,B.STOCK_TYPE				   ");
                    sbQuery.Append(" ,B.BOM_SEQ				   ");
                    sbQuery.Append(" FROM TSTD_BOM B			   ");
                    sbQuery.Append(" LEFT JOIN LSE_STD_PART SP	   ");
                    sbQuery.Append(" ON B.PLT_CODE = SP.PLT_CODE   ");
                    sbQuery.Append(" AND B.PART_CODE = SP.PART_CODE");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE B.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@BOM_PART_CODE", "B.BOM_PART_CODE = @BOM_PART_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@BOM_ID", "B.PARENT_ID = @BOM_ID"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PARENT_PART_CODE", "dbo.fn_get_parentBom(BOM_PART_CODE, PARENT_ID) = @PARENT_PART_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@IS_TURNING", "SP.IS_TURNING = @IS_TURNING"));
                        sbWhere.Append(" AND B.PARENT_ID IS NOT NULL");

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

        public static DataTable TSTD_BOM_QUERY2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT B.PLT_CODE													 ");
                    sbQuery.Append(" ,B.BOM_ID															 ");
                    sbQuery.Append(" ,B.BOM_PART_CODE													 ");
                    sbQuery.Append(" ,B.PARENT_ID														 ");
                    sbQuery.Append(" ,dbo.fn_get_parentBom(B.BOM_PART_CODE, B.PARENT_ID) AS PARENT_PART_CODE");
                    sbQuery.Append(" ,SPT.PART_NAME AS PARENT_PART_NAME									 ");
                    sbQuery.Append(" ,B.PART_CODE														 ");
                    sbQuery.Append(" ,SP.PART_NAME														 ");
                    sbQuery.Append(" ,SP.MAT_SPEC														 ");
                    sbQuery.Append(" ,SP.MAT_SPEC1														 ");
                    sbQuery.Append(" ,SP.DRAW_NO														 ");
                    sbQuery.Append(" ,SP.MAT_UNIT														 ");
                    sbQuery.Append(" ,SP.MAT_LTYPE														 ");
                    sbQuery.Append(" ,SP.MAT_TYPE														 ");
                    sbQuery.Append(" ,B.BOM_QTY															 ");
                    sbQuery.Append(" ,B.STOCK_CODE														 ");
                    sbQuery.Append(" ,B.STOCK_TYPE														 ");
                    sbQuery.Append(" ,ISNULL(B.BOM_SEQ, 0) AS BOM_SEQ          ");
                    sbQuery.Append(" ,B.REG_DATE														 ");
                    sbQuery.Append(" ,B.REG_EMP															 ");
                    sbQuery.Append(" ,B.MDFY_DATE														 ");
                    sbQuery.Append(" ,B.MDFY_EMP														 ");
                    sbQuery.Append(" FROM TSTD_BOM B													 ");
                    sbQuery.Append(" LEFT JOIN LSE_STD_PART SP											 ");
                    sbQuery.Append(" ON B.PLT_CODE = SP.PLT_CODE										 ");
                    sbQuery.Append(" AND B.PART_CODE = SP.PART_CODE										 ");

                    sbQuery.Append(" LEFT JOIN LSE_STD_PART SPT											 ");
                    sbQuery.Append(" ON B.PLT_CODE = SPT.PLT_CODE										 ");
                    sbQuery.Append(" AND dbo.fn_get_parentBom(BOM_PART_CODE, PARENT_ID) = SPT.PART_CODE");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE B.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@BOM_PART_CODE", "B.BOM_PART_CODE = @BOM_PART_CODE"));

                        sbWhere.Append(" ORDER BY B.BOM_SEQ ");

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



        public static DataTable TSTD_BOM_QUERY3(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT B.PLT_CODE					 ");
                    sbQuery.Append(" ,B.BOM_ID							 ");
                    sbQuery.Append(" ,B.BOM_PART_CODE					 ");
                    sbQuery.Append(" ,B.PARENT_ID		    			 ");
                    sbQuery.Append(" ,B.PART_CODE						 ");
                    sbQuery.Append(" ,SP.PART_NAME                  	 ");
                    sbQuery.Append(" ,SP.MAT_SPEC						 ");
                    sbQuery.Append(" ,SP.DRAW_NO						 ");
                    sbQuery.Append(" ,SP.MAT_UNIT						 ");
                    sbQuery.Append(" ,SP.MAT_LTYPE						 ");
                    sbQuery.Append(" ,SP.MAT_TYPE						 ");
                    sbQuery.Append(" ,B.BOM_QTY							 ");
                    sbQuery.Append(" ,B.STOCK_CODE						 ");
                    sbQuery.Append(" ,B.STOCK_TYPE						 ");
                    sbQuery.Append(" ,B.BOM_SEQ						 ");
                    sbQuery.Append(" ,B.REG_DATE						 ");
                    sbQuery.Append(" ,B.REG_EMP							 ");
                    sbQuery.Append(" ,B.MDFY_DATE						 ");
                    sbQuery.Append(" ,B.MDFY_EMP						 ");
                    sbQuery.Append(" FROM TSTD_BOM B					 ");
                    sbQuery.Append(" LEFT JOIN LSE_STD_PART SP			 ");
                    sbQuery.Append(" ON B.PLT_CODE = SP.PLT_CODE		 ");
                    sbQuery.Append(" AND B.PART_CODE = SP.PART_CODE      ");	

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE B.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@BOM_ID", "B.BOM_ID = @BOM_ID"));

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
        public static DataTable TSTD_BOM_QUERY4(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT B.PLT_CODE		");
                    sbQuery.Append(" ,B.BM_KEY		");
                    sbQuery.Append(" ,B.BOM_ID				");
                    sbQuery.Append(" ,B.BM_CODE				");
                    sbQuery.Append(" ,M.REV_NO				");
                    sbQuery.Append(" ,B.PARENT_ID			");
                    sbQuery.Append(" ,B.PART_CODE						");
                    sbQuery.Append(" ,ISNULL(B.BOM_SEQ, 0) AS BOM_SEQ   ");

                    sbQuery.Append(" ,SP.PART_NAME			   ");
                    sbQuery.Append(" ,SP.DRAW_NO				   ");
                    sbQuery.Append(" ,SP.MAT_UNIT				   ");
                    sbQuery.Append(" ,SP.DRAW_NO				   ");
                    //sbQuery.Append(" ,SP.CUR_UNIT				   ");
                    //sbQuery.Append(" ,SP.UNIT_COST				   ");
                    //sbQuery.Append(" ,SP.MVND_CODE				   ");
                    //sbQuery.Append(" ,SP.PART_PROC				   ");
                    //sbQuery.Append(" ,SP.PART_TYPE				   ");
                    sbQuery.Append(" ,SP.MAT_LTYPE  ");
                    sbQuery.Append(" ,SP.MAT_MTYPE  ");
                    sbQuery.Append(" ,SP.PART_PRODTYPE ");

                    sbQuery.Append(" ,B.BOM_QTY							");
                    sbQuery.Append(" ,B.BOM_QTY	AS UNIT_QTY             ");
                    sbQuery.Append(" ,B.BOM_QTY	AS ORI_BOM_QTY             ");
                    sbQuery.Append(" ,B.REG_DATE						");
                    sbQuery.Append(" ,B.REG_EMP							");
                    sbQuery.Append(" ,B.MDFY_DATE						");
                    sbQuery.Append(" ,B.MDFY_EMP						");
                    
                    //sbQuery.Append(" ,ISNULL(SP.UNIT_COST, 0) * ISNULL(B.BOM_QTY, 0) AS UNIT_AMT ");
                    //sbQuery.Append(" ,B.BAN_REV					");

                    sbQuery.Append(" FROM TSTD_BOM B					");
                    sbQuery.Append("  JOIN TSTD_BOM_MASTER M			");
                    sbQuery.Append("  ON B.PLT_CODE = M.PLT_CODE AND B.BM_KEY = M.BM_KEY 	");

                    sbQuery.Append("  LEFT JOIN LSE_STD_PART SP			");
                    sbQuery.Append(" ON B.PLT_CODE = SP.PLT_CODE		");
                    sbQuery.Append(" AND B.PART_CODE = SP.PART_CODE		");
                    sbQuery.Append(" AND SP.DATA_FLAG = 0 										 ");
                    
                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE B.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());


                        sbWhere.Append(UTIL.GetWhere(row, "@BM_CODE", "B.BM_CODE = @BM_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@BM_KEY", "B.BM_KEY = @BM_KEY"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PARENT_ID", "B.PARENT_ID = @PARENT_ID"));
                        sbWhere.Append(UTIL.GetWhere(row, "@BOM_ID", "B.BOM_ID = @BOM_ID"));

                        sbWhere.Append(" ORDER BY B.BOM_SEQ ");

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

        public static DataTable TSTD_BOM_QUERY5(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT B.PLT_CODE													 ");
                    sbQuery.Append(" ,B.BOM_ID															 ");
                    sbQuery.Append(" ,B.BOM_PART_CODE													 ");
                    sbQuery.Append(" ,B.PARENT_ID														 ");
                    sbQuery.Append(" ,dbo.fn_get_parentBom(B.BOM_PART_CODE, B.PARENT_ID) AS PARENT_PART_CODE");
                    sbQuery.Append(" ,SPT.PART_NAME AS PARENT_PART_NAME									 ");
                    sbQuery.Append(" ,B.PART_CODE														 ");
                    sbQuery.Append(" ,SP.PART_NAME														 ");
                    sbQuery.Append(" ,SP.MAT_SPEC														 ");
                    sbQuery.Append(" ,SP.MAT_SPEC1														 ");
                    sbQuery.Append(" ,SP.DRAW_NO														 ");
                    sbQuery.Append(" ,SP.MAT_UNIT														 ");
                    sbQuery.Append(" ,SP.MAT_LTYPE														 ");
                    sbQuery.Append(" ,SP.MAT_TYPE														 ");
                    sbQuery.Append(" ,SP.MAT_WEIGHT														 ");
                    sbQuery.Append(" ,B.BOM_QTY															 ");
                    sbQuery.Append(" ,B.STOCK_CODE														 ");
                    sbQuery.Append(" ,B.STOCK_TYPE														 ");
                    sbQuery.Append(" ,ISNULL(BAL.BAL_QTY,0) AS BAL_QTY														 ");
                    sbQuery.Append(" ,SP.STK_COMPLETE														 ");
                    sbQuery.Append(" ,ISNULL(B.BOM_SEQ, 0) AS BOM_SEQ          ");
                    sbQuery.Append(" ,B.REG_DATE														 ");
                    sbQuery.Append(" ,B.REG_EMP															 ");
                    sbQuery.Append(" ,B.MDFY_DATE														 ");
                    sbQuery.Append(" ,B.MDFY_EMP														 ");
                    sbQuery.Append(" ,SP.SCOMMENT														 ");
                    sbQuery.Append(" FROM TSTD_BOM B													 ");
                    sbQuery.Append(" LEFT JOIN LSE_STD_PART SP											 ");
                    sbQuery.Append(" ON B.PLT_CODE = SP.PLT_CODE										 ");
                    sbQuery.Append(" AND B.PART_CODE = SP.PART_CODE										 ");

                    sbQuery.Append(" LEFT JOIN LSE_STD_PART SPT											 ");
                    sbQuery.Append(" ON B.PLT_CODE = SPT.PLT_CODE										 ");
                    sbQuery.Append(" AND dbo.fn_get_parentBom(BOM_PART_CODE, PARENT_ID) = SPT.PART_CODE");

                    sbQuery.Append("    LEFT JOIN (SELECT  B.PLT_CODE           ");
                    sbQuery.Append("                     , R.PART_CODE       ");
                    sbQuery.Append("                     , B.QTY AS BAL_QTY ");
                    sbQuery.Append("                 FROM TMAT_BALJU B         ");
                    sbQuery.Append("                    INNER JOIN TMAT_REQUEST R        ");
                    sbQuery.Append("                       ON B.PLT_CODE = R.PLT_CODE     ");
                    sbQuery.Append("                       AND B.REQUEST_NO = R.REQUEST_NO AND B.REQUEST_SEQ = R.REQUEST_SEQ ");
                    sbQuery.Append("                WHERE B.BAL_STAT IN ('11', '13')   ");
                    sbQuery.Append("               UNION           ");
                    sbQuery.Append("                 SELECT B.PLT_CODE           ");
                    sbQuery.Append("                     , R.PART_CODE       ");
                    sbQuery.Append("                     , B.QTY AS BAL_QTY ");
                    sbQuery.Append("                 FROM TOUT_PROCBALJU B         ");
                    sbQuery.Append("                    INNER JOIN TOUT_REQUEST R        ");
                    sbQuery.Append("                       ON B.PLT_CODE = R.PLT_CODE     ");
                    sbQuery.Append("                       AND B.REQUEST_NO = R.REQUEST_NO AND B.REQUEST_SEQ = R.REQUEST_SEQ ");
                    sbQuery.Append("                WHERE B.BAL_STAT IN ('11', '13') ) BAL    ");
                    sbQuery.Append("        ON SP.PLT_CODE = BAL.PLT_CODE         ");
                    sbQuery.Append("        AND SP.PART_CODE = BAL.PART_CODE        ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE B.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@BOM_PART_CODE", "B.BOM_PART_CODE = @BOM_PART_CODE"));

                        sbWhere.Append(" ORDER BY B.BOM_SEQ ");

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


        public static DataTable TSTD_BOM_QUERY7(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT CASE WHEN B.BOM_QTY = 0 THEN 0 ELSE A.BOM_QTY/(ISNULL(B.BOM_QTY,1)) END AS BOM_QTY ");
                    sbQuery.Append(" FROM TSTD_BOM A");
                    sbQuery.Append(" LEFT JOIN TSTD_BOM B ON A.PARENT_ID = B.BOM_ID");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE A.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@BOM_ID", "A.BOM_ID = @BOM_ID"));

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


        public static DataTable TSTD_BOM_QUERY8(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT B.BOM_QTY AS BOM_QTY ");
                    sbQuery.Append(" FROM TSTD_BOM A ");
                    sbQuery.Append(" LEFT JOIN TSTD_BOM B ON A.PLT_CODE = B.PLT_CODE AND A.BOM_ID = B.PARENT_ID AND A.BM_CODE = B.BM_CODE ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE A.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@PARENT_PART_CODE", "A.PART_CODE = @PARENT_PART_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PARENT_PART_CODE", "A.BM_CODE = @PARENT_PART_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_CODE", "B.PART_CODE = @PART_CODE"));

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

