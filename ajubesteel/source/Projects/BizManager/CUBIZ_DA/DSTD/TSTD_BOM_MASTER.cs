using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace DSTD
{
    public class TSTD_BOM_MASTER
    {

        public static DataTable TSTD_BOM_MASTER_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT PLT_CODE");
                    sbQuery.Append(" ,BM_CODE		");
                    sbQuery.Append(" ,BM_KEY				   ");
                    sbQuery.Append(" ,REV_NO	");
                    sbQuery.Append(" ,BM_STATE	");
                    sbQuery.Append(" ,SCOMMENT	");
                    sbQuery.Append(" ,REV_DATE		");
                    sbQuery.Append(" ,REG_DATE		");
                    sbQuery.Append(" ,REG_EMP		");
                    sbQuery.Append(" ,MDFY_DATE		");
                    sbQuery.Append(" ,MDFY_EMP		");
                    sbQuery.Append(" ,DATA_FLAG		");
                    sbQuery.Append(" ,DEL_DATE		");
                    sbQuery.Append(" ,DEL_EMP		");
                    sbQuery.Append(" FROM TSTD_BOM_MASTER	");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND BM_CODE = @BM_CODE	   ");

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

        public static DataTable TSTD_BOM_MASTER_SER3(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT ISNULL(max(REV_NO)+1,0) AS NEXT_REV_NO ");
                    sbQuery.Append(" ,ISNULL(max(REV_NO),0) AS REV_NO ");
                    sbQuery.Append(" FROM TSTD_BOM_MASTER	");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND BM_CODE = @BM_CODE ");
                    sbQuery.Append(" AND DATA_FLAG = 0 ");

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

        public static DataTable TSTD_BOM_MASTER_SER4(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT PLT_CODE");
                    sbQuery.Append(" ,BM_CODE		");
                    sbQuery.Append(" ,BM_KEY				   ");
                    sbQuery.Append(" ,REV_NO	");
                    sbQuery.Append(" ,BM_STATE	");
                    sbQuery.Append(" ,SCOMMENT	");
                    sbQuery.Append(" ,REV_DATE		");
                    sbQuery.Append(" ,LOCK_EMP		");
                    sbQuery.Append(" ,REG_DATE		");
                    sbQuery.Append(" ,REG_EMP		");
                    sbQuery.Append(" ,MDFY_DATE		");
                    sbQuery.Append(" ,MDFY_EMP		");
                    sbQuery.Append(" ,DATA_FLAG		");
                    sbQuery.Append(" ,DEL_DATE		");
                    sbQuery.Append(" ,DEL_EMP		");
                    sbQuery.Append(" FROM TSTD_BOM_MASTER	");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND BM_KEY = @BM_KEY	   ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "BM_KEY")) isHasColumn = false;

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

        public static DataTable TSTD_BOM_MASTER_SER5(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT PLT_CODE");
                    sbQuery.Append(" ,BM_CODE		");
                    sbQuery.Append(" ,BM_KEY				   ");
                    sbQuery.Append(" ,REV_NO	");
                    sbQuery.Append(" ,BM_STATE	");
                    sbQuery.Append(" ,SCOMMENT	");
                    sbQuery.Append(" ,REV_COMMENT	");
                    sbQuery.Append(" ,REV_DATE		");
                    sbQuery.Append(" ,REG_DATE		");
                    sbQuery.Append(" ,REG_EMP		");
                    sbQuery.Append(" ,MDFY_DATE		");
                    sbQuery.Append(" ,MDFY_EMP		");
                    sbQuery.Append(" ,DATA_FLAG		");
                    sbQuery.Append(" ,DEL_DATE		");
                    sbQuery.Append(" ,DEL_EMP		");
                    sbQuery.Append(" FROM TSTD_BOM_MASTER	");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND BM_CODE = @BM_CODE	   ");
                    sbQuery.Append(" AND BM_STATE IN (SELECT CD_CODE FROM TSTD_CODES WHERE CAT_CODE = @CAT_CODE AND VALUE = @VALUE AND DATA_FLAG = @DATA_FLAG)   ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "BM_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "CAT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "VALUE")) isHasColumn = false;

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


        public static DataTable TSTD_BOM_MASTER_SER6(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT PLT_CODE");
                    sbQuery.Append(" ,BM_CODE		");
                    sbQuery.Append(" ,BM_KEY				   ");
                    sbQuery.Append(" ,REV_NO	");
                    sbQuery.Append(" ,BM_STATE	");
                    sbQuery.Append(" ,SCOMMENT	");
                    sbQuery.Append(" ,REV_DATE		");
                    sbQuery.Append(" ,REG_DATE		");
                    sbQuery.Append(" ,REG_EMP		");
                    sbQuery.Append(" ,MDFY_DATE		");
                    sbQuery.Append(" ,MDFY_EMP		");
                    sbQuery.Append(" ,DATA_FLAG		");
                    sbQuery.Append(" ,DEL_DATE		");
                    sbQuery.Append(" ,DEL_EMP		");
                    sbQuery.Append(" ,ISNULL((SELECT TOP 1 CD_CODE FROM TSTD_CODES WHERE CAT_CODE = @CAT_CODE AND VALUE = @VALUE AND DATA_FLAG = @DATA_FLAG),'') AS NOT_DEL_BOM_STATE ");

                    sbQuery.Append(" ,( SELECT B.VALUE AS CAT_VALUE");
                    sbQuery.Append(" FROM LSE_STD_PART A");
                    sbQuery.Append(" LEFT JOIN TSTD_CODES B ON B.CAT_CODE = '0A01' AND A.PART_CAT1 = B.CD_CODE");
                    sbQuery.Append(" WHERE A.PART_CODE = X.BM_CODE ) AS CAT_VALUE");

                    sbQuery.Append(" FROM TSTD_BOM_MASTER X	");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND BM_KEY = @BM_KEY	   ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "BM_KEY")) isHasColumn = false;

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


        public static DataTable TSTD_BOM_MASTER_SER7(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT  ");
                    sbQuery.Append(" TOP 1  ");
                    sbQuery.Append(" BM.PLT_CODE, ");
                    sbQuery.Append(" BM.BM_KEY, ");
                    sbQuery.Append(" BM.BM_CODE, ");
                    sbQuery.Append(" BM.REV_NO, ");
                    sbQuery.Append(" BM.BM_STATE, ");
                    sbQuery.Append(" BM.SCOMMENT, ");
                    sbQuery.Append(" BM.REV_DATE ");
                    sbQuery.Append(" FROM TSTD_BOM_MASTER BM ");
                    sbQuery.Append(" JOIN TSTD_CODES TC ");
                    sbQuery.Append(" ON BM.PLT_CODE = TC.PLT_CODE ");
                    sbQuery.Append(" AND BM.BM_STATE = TC.CD_CODE ");
                    sbQuery.Append(" AND TC.CAT_CODE = @CAT_CODE ");
                    sbQuery.Append(" AND TC.VALUE = @VALUE ");
                    sbQuery.Append(" AND TC.DATA_FLAG = 0 ");
                    sbQuery.Append(" WHERE BM.PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND BM.BM_CODE = @PART_CODE ");
                    sbQuery.Append(" AND BM.DATA_FLAG = 0 ");

                    sbQuery.Append(" ORDER BY REV_NO DESC ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PART_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "CAT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "VALUE")) isHasColumn = false;

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

        public static DataTable TSTD_BOM_MASTER_SER7_2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT  ");
                    sbQuery.Append(" TOP 1  ");
                    sbQuery.Append(" BM.PLT_CODE, ");
                    sbQuery.Append(" BM.BM_KEY, ");
                    sbQuery.Append(" BM.BM_CODE, ");
                    sbQuery.Append(" BM.REV_NO, ");
                    sbQuery.Append(" BM.BM_STATE, ");
                    sbQuery.Append(" BM.SCOMMENT, ");
                    sbQuery.Append(" BM.REV_DATE ");
                    sbQuery.Append(" FROM TSTD_BOM_MASTER BM ");
                    sbQuery.Append(" JOIN TSTD_CODES TC ");
                    sbQuery.Append(" ON BM.PLT_CODE = TC.PLT_CODE ");
                    sbQuery.Append(" AND BM.BM_STATE = TC.CD_CODE ");
                    sbQuery.Append(" AND TC.CAT_CODE = @CAT_CODE ");
                    sbQuery.Append(" AND TC.VALUE = @VALUE ");
                    sbQuery.Append(" AND TC.DATA_FLAG = 0 ");
                    sbQuery.Append(" WHERE BM.PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND BM.BM_CODE = @PART_CODE ");
                    sbQuery.Append(" AND BM.DATA_FLAG = 0 ");
                    sbQuery.Append(" AND BM.BM_STATE = 'MAS' ");


                    sbQuery.Append(" ORDER BY REV_NO DESC ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PART_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "CAT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "VALUE")) isHasColumn = false;

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

        public static DataTable TSTD_BOM_MASTER_SER7_3(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT  ");
                    sbQuery.Append(" BM.PLT_CODE, ");
                    sbQuery.Append(" BM.BM_KEY, ");
                    sbQuery.Append(" BM.BM_CODE, ");
                    sbQuery.Append(" BM.REV_NO, ");
                    sbQuery.Append(" BM.BM_STATE, ");
                    sbQuery.Append(" BM.SCOMMENT, ");
                    
                    sbQuery.Append(" BM.REV_DATE ");
                    sbQuery.Append(" FROM TSTD_BOM_MASTER BM ");
                    sbQuery.Append(" JOIN TSTD_CODES TC ");
                    sbQuery.Append(" ON BM.PLT_CODE = TC.PLT_CODE ");
                    sbQuery.Append(" AND BM.BM_STATE = TC.CD_CODE ");
                    sbQuery.Append(" AND TC.CAT_CODE = @CAT_CODE ");
                    sbQuery.Append(" AND TC.VALUE = @VALUE ");
                    sbQuery.Append(" AND TC.DATA_FLAG = 0 ");
                    sbQuery.Append(" WHERE BM.PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND BM.BM_CODE = @PART_CODE ");
                    sbQuery.Append(" AND BM.DATA_FLAG = 0 ");
                    sbQuery.Append(" AND BM.BM_STATE = 'MAS' ");


                    sbQuery.Append(" ORDER BY REV_NO DESC ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PART_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "CAT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "VALUE")) isHasColumn = false;

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
        public static DataTable TSTD_BOM_MASTER_SER7_4(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT  ");
                    sbQuery.Append(" TOP 1  ");
                    sbQuery.Append(" BM.PLT_CODE, ");
                    sbQuery.Append(" BM.BM_KEY, ");
                    sbQuery.Append(" BM.BM_CODE, ");
                    sbQuery.Append(" BM.REV_NO, ");
                    sbQuery.Append(" BM.BM_STATE, ");
                    sbQuery.Append(" BM.SCOMMENT, ");
                    sbQuery.Append(" BM.REV_COMMENT, ");
                    sbQuery.Append(" BM.REV_DATE ");
                    sbQuery.Append(" FROM TSTD_BOM_MASTER BM ");
                    sbQuery.Append(" WHERE BM.PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND BM.BM_CODE = @PART_CODE ");
                    sbQuery.Append(" AND BM.REV_NO = @REV_NO ");
                    sbQuery.Append(" AND BM.DATA_FLAG = 0 ");

                    sbQuery.Append(" ORDER BY REV_NO DESC ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PART_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "REV_NO")) isHasColumn = false;

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

        public static DataTable TSTD_BOM_MASTER_SER8(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT  ");
                    sbQuery.Append(" ISNULL(MAX(REV_NO),-1) + 1 AS REV_NO ");
                    sbQuery.Append(" FROM TSTD_BOM_MASTER ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append("  AND BM_CODE = @BM_CODE");
                    sbQuery.Append("  AND DATA_FLAG = 0 ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
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


        public static void TSTD_BOM_MASTER_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" INSERT INTO TSTD_BOM_MASTER ");
                    sbQuery.Append(" (PLT_CODE			 ");
                    sbQuery.Append(" ,BM_CODE			 ");
                    sbQuery.Append(" ,BM_KEY				   ");
                    sbQuery.Append(" ,REV_NO	");
                    sbQuery.Append(" ,BM_STATE	");
                    sbQuery.Append(" ,SCOMMENT		 ");
                    sbQuery.Append(" ,DATA_FLAG		 ");
                    sbQuery.Append(" ,REV_DATE		");
                    sbQuery.Append(" ,REG_DATE			 ");
                    sbQuery.Append(" ,REG_EMP)			 ");
                    sbQuery.Append(" VALUES				 ");
                    sbQuery.Append(" (@PLT_CODE			 ");
                    sbQuery.Append(" ,@BM_CODE			 ");
                    sbQuery.Append(" ,@BM_KEY				   ");
                    sbQuery.Append(" ,@REV_NO	");
                    sbQuery.Append(" ,@BM_STATE	");
                    sbQuery.Append(" ,@SCOMMENT          ");
                    sbQuery.Append(" ,0		 ");
                    sbQuery.Append(" ,@REV_DATE		");
                    sbQuery.Append(" ,GETDATE()			 ");
                    sbQuery.Append(" ," + UTIL.GetValidValue(ConnInfo.UserID));
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
        public static void TSTD_BOM_MASTER_UPD(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" UPDATE TSTD_BOM_MASTER		   ");
                    sbQuery.Append(" SET DATA_FLAG = @DATA_FLAG	   ");
                    sbQuery.Append(" ,BM_STATE = @BM_STATE	   ");
                    sbQuery.Append(" ,LOCK_EMP = @LOCK_EMP ");
                    sbQuery.Append(" ,SCOMMENT = @SCOMMENT	   ");
                    sbQuery.Append(" , MDFY_DATE = GETDATE()");
                    sbQuery.Append(" , MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND BM_KEY = @BM_KEY	   ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "BM_KEY")) isHasColumn = false;

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

        public static void TSTD_BOM_MASTER_UPD2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" UPDATE TSTD_BOM_MASTER		   ");
                    sbQuery.Append(" SET LOCK_EMP = @LOCK_EMP ");
                    sbQuery.Append(" , MDFY_DATE = GETDATE()");
                    sbQuery.Append(" , MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND BM_KEY = @BM_KEY	   ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "BM_KEY")) isHasColumn = false;

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


        public static void TSTD_BOM_MASTER_DEL(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" UPDATE TSTD_BOM_MASTER  ");
                    sbQuery.Append("   SET DATA_FLAG = @DATA_FLAG ");
                    sbQuery.Append(" , DEL_DATE = GETDATE()");
                    sbQuery.Append(" , DEL_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND BM_KEY = @BM_KEY	   ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "BM_KEY")) isHasColumn = false;

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

    public class TSTD_BOM_MASTER_QUERY
    {
        public static DataTable TSTD_BOM_MASTER_QUERY1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT B.PLT_CODE			   ");
                    sbQuery.Append(" ,B.BM_CODE AS PART_CODE					   ");
                    sbQuery.Append(" ,B.BM_CODE					   ");
                    sbQuery.Append(" ,B.BM_KEY				   ");
                    sbQuery.Append(" ,B.REV_NO	");
                    sbQuery.Append(" ,B.BM_STATE	");
                    sbQuery.Append(" ,B.SCOMMENT     			   ");
                    sbQuery.Append(" ,B.REV_DATE		");
                    sbQuery.Append(" ,B.LOCK_EMP		");
                    sbQuery.Append(" ,B.REG_DATE				   ");
                    sbQuery.Append(" ,B.REG_EMP				   ");
                    sbQuery.Append(" ,B.MDFY_DATE				   ");
                    sbQuery.Append(" ,B.MDFY_EMP				   ");
                    //sbQuery.Append(" ,P.PART_DESC				   ");
                    sbQuery.Append(" FROM TSTD_BOM_MASTER B			   ");
                    sbQuery.Append("  JOIN LSE_STD_PART P ON B.PLT_CODE = P.PLT_CODE AND B.BM_CODE = P.PART_CODE ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE B.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "B.DATA_FLAG = @DATA_FLAG"));
                        sbWhere.Append(UTIL.GetWhere(row, "@BM_CODE", "B.BM_CODE = @BM_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@BM_KEY", "B.BM_KEY = @BM_KEY"));
                        sbWhere.Append(UTIL.GetWhere(row, "@BM_STATE", "B.BM_STATE = @BM_STATE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@CAT_CODE,@VALUE,@DATA_FLAG", "B.BM_STATE IN (SELECT CD_CODE FROM TSTD_CODES WHERE CAT_CODE = @CAT_CODE AND VALUE = @VALUE AND DATA_FLAG = @DATA_FLAG)"));

                        sbWhere.Append(" ORDER By REV_NO DESC");

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


        public static DataTable TSTD_BOM_MASTER_QUERY2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT TOP 1 B.PLT_CODE			   ");
                    sbQuery.Append(" ,B.BM_KEY				   ");
                    sbQuery.Append(" FROM TSTD_BOM_MASTER B			   ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE B.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "B.DATA_FLAG = @DATA_FLAG"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_CODE", "B.BM_CODE = @PART_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@CAT_CODE,@VALUE,@DATA_FLAG", "B.BM_STATE IN (SELECT CD_CODE FROM TSTD_CODES WHERE CAT_CODE = @CAT_CODE AND VALUE = @VALUE AND DATA_FLAG = @DATA_FLAG)"));

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

        public static DataTable TSTD_BOM_MASTER_QUERY3(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT ");
                    sbQuery.Append(" BP.PART_CODE AS PARENT_CODE, ");
                    sbQuery.Append(" B.PART_CODE, ");
                    sbQuery.Append(" ISNULL(SP.MOQ,0) AS MOQ ");
                    sbQuery.Append(" FROM TSTD_BOM_MASTER BM ");
                    sbQuery.Append(" JOIN TSTD_BOM B ");
                    sbQuery.Append(" ON BM.PLT_CODE = B.PLT_CODE ");
                    sbQuery.Append(" AND BM.BM_KEY = B.BM_KEY ");
                    sbQuery.Append(" AND BM.BM_CODE != B.PART_CODE ");
                    sbQuery.Append(" LEFT JOIN TSTD_BOM BP ");
                    sbQuery.Append(" ON B.PLT_CODE = BP.PLT_CODE ");
                    sbQuery.Append(" AND B.BM_KEY = BP.BM_KEY ");
                    sbQuery.Append(" AND B.PARENT_ID = BP.BOM_ID ");
                    sbQuery.Append(" JOIN LSE_STD_PART SP ");
                    sbQuery.Append(" ON B.PLT_CODE = SP.PLT_CODE ");
                    sbQuery.Append(" AND B.BM_CODE = SP.PART_CODE ");
                    sbQuery.Append(" AND SP.DATA_FLAG = 0 ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE BM.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "BM.DATA_FLAG = @DATA_FLAG"));
                        sbWhere.Append(UTIL.GetWhere(row, "@BM_KEY", "B.BM_KEY = @BM_KEY"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_QTY", "ISNULL(SP.MOQ,0) > @PART_QTY"));

                        sbWhere.Append(" ORDER BY B.PART_CODE ASC");

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
