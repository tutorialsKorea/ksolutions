using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BizExecute;
using System.Data;

namespace DORD
{
    public class TORD_PRODUCT_BILL
    {

        public static DataTable TORD_PRODUCT_BILL_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("  SELECT  ");
                    sbQuery.Append("  PLT_CODE ");
                    sbQuery.Append(" ,BILL_NO ");
                    sbQuery.Append(" ,PROD_CODE ");
                    sbQuery.Append(" ,BILL_DATE ");
                    sbQuery.Append(" ,BILL_EMP ");
                    sbQuery.Append(" ,SCOMMENT ");
                    sbQuery.Append(" ,REG_DATE ");
                    sbQuery.Append(" ,REG_EMP ");
                    sbQuery.Append(" ,MDFY_DATE ");
                    sbQuery.Append(" ,MDFY_EMP ");
                    sbQuery.Append(" ,DEL_DATE ");
                    sbQuery.Append(" ,DEL_EMP ");
                    sbQuery.Append(" ,DATA_FLAG ");
                    sbQuery.Append("  FROM TORD_PRODUCT_BILL  ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("  AND BILL_NO = @BILL_NO  ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "BILL_NO")) isHasColumn = false;

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
        /// 해당수저건의 발행정보
        /// </summary>
        /// <param name="dtParam"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataTable TORD_PRODUCT_BILL_SER2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("  SELECT  ");
                    sbQuery.Append("  PLT_CODE ");
                    sbQuery.Append(" ,BILL_NO ");
                    sbQuery.Append(" ,BILL_TYPE ");
                    sbQuery.Append(" ,PROD_CODE ");
                    sbQuery.Append(" ,BILL_DATE ");
                    sbQuery.Append(" ,BILL_EMP ");
                    sbQuery.Append(" ,BILL_QTY ");
                    sbQuery.Append(" ,BILL_AMT ");
                    sbQuery.Append(" ,SCOMMENT ");
                    sbQuery.Append(" ,COLLECT_DATE ");
                    sbQuery.Append(" ,COL_PLAN_DATE ");
                    sbQuery.Append(" ,REG_DATE ");
                    sbQuery.Append(" ,REG_EMP ");
                    sbQuery.Append(" ,MDFY_DATE ");
                    sbQuery.Append(" ,MDFY_EMP ");
                    sbQuery.Append(" ,DEL_DATE ");
                    sbQuery.Append(" ,DEL_EMP ");
                    sbQuery.Append(" ,DATA_FLAG ");
                    sbQuery.Append("  FROM TORD_PRODUCT_BILL  ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("  AND PROD_CODE = @PROD_CODE  ");
                    //sbQuery.Append("  AND BILL_TYPE = @BILL_TYPE  ");
                    sbQuery.Append("  AND DATA_FLAG = 0  ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PROD_CODE")) isHasColumn = false;
                        //if (!UTIL.ValidColumn(row, "BILL_TYPE")) isHasColumn = false;

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
        /// 해당수저건의 발행정보
        /// </summary>
        /// <param name="dtParam"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataTable TORD_PRODUCT_BILL_SER3(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("  SELECT  ");
                    sbQuery.Append("  PLT_CODE ");
                    sbQuery.Append(" ,BILL_NO ");
                    sbQuery.Append(" ,BILL_TYPE ");
                    sbQuery.Append(" ,PROD_CODE ");
                    sbQuery.Append(" ,BILL_DATE ");
                    sbQuery.Append(" ,BILL_EMP ");
                    sbQuery.Append(" ,BILL_QTY ");
                    sbQuery.Append(" ,BILL_AMT ");
                    sbQuery.Append(" ,SCOMMENT ");
                    sbQuery.Append(" ,COLLECT_DATE ");
                    sbQuery.Append(" ,COL_PLAN_DATE ");
                    sbQuery.Append(" ,REG_DATE ");
                    sbQuery.Append(" ,REG_EMP ");
                    sbQuery.Append(" ,MDFY_DATE ");
                    sbQuery.Append(" ,MDFY_EMP ");
                    sbQuery.Append(" ,DEL_DATE ");
                    sbQuery.Append(" ,DEL_EMP ");
                    sbQuery.Append(" ,DATA_FLAG ");
                    sbQuery.Append("  FROM TORD_PRODUCT_BILL  ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("  AND PROD_CODE = @PROD_CODE  ");
                    sbQuery.Append("  AND BILL_TYPE = @BILL_TYPE  ");
                    sbQuery.Append("  AND DATA_FLAG = 0  ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PROD_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "BILL_TYPE")) isHasColumn = false;

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


        public static DataTable TORD_PRODUCT_BILL_SER4(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("  SELECT  ");
                    sbQuery.Append("  PLT_CODE ");
                    sbQuery.Append(" ,PROD_CODE ");
                    sbQuery.Append(" ,BILL_TYPE ");
                    sbQuery.Append(" ,SUM(BILL_QTY) AS BILL_QTY ");
                    sbQuery.Append(" ,SUM(BILL_AMT) AS BILL_AMT ");
                    sbQuery.Append("  FROM TORD_PRODUCT_BILL  ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("  AND PROD_CODE = @PROD_CODE  ");
                    sbQuery.Append("  AND BILL_TYPE = @BILL_TYPE  ");
                    sbQuery.Append("  AND DATA_FLAG = 0  ");

                    sbQuery.Append("  GROUP BY PLT_CODE, PROD_CODE, BILL_TYPE ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PROD_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "BILL_TYPE")) isHasColumn = false;

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

        public static DataTable TORD_PRODUCT_BILL_SER5(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("  SELECT  ");
                    sbQuery.Append("  PLT_CODE ");
                    sbQuery.Append(" ,PROD_CODE ");
                    sbQuery.Append(" ,BILL_NO ");
                    sbQuery.Append(" ,BILL_TYPE ");
                    sbQuery.Append(" ,COLLECT_DATE ");
                    sbQuery.Append(" ,DATA_FLAG ");
                    sbQuery.Append("  FROM TORD_PRODUCT_BILL  ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("  AND PROD_CODE = @PROD_CODE  ");
                    sbQuery.Append("  AND BILL_TYPE = @BILL_TYPE  ");
                    sbQuery.Append("  AND COLLECT_DATE IS NULL  ");
                    sbQuery.Append("  AND DATA_FLAG = 0  ");

                    sbQuery.Append("  ORDER BY BILL_DATE ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PROD_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "BILL_TYPE")) isHasColumn = false;

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

        public static void TORD_PRODUCT_BILL_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" INSERT INTO TORD_PRODUCT_BILL (  ");
                    sbQuery.Append("  PLT_CODE ");
                    sbQuery.Append(" ,BILL_NO ");
                    sbQuery.Append(" ,BILL_TYPE ");
                    sbQuery.Append(" ,PROD_CODE ");
                    sbQuery.Append(" ,BILL_DATE ");
                    sbQuery.Append(" ,BILL_EMP ");
                    sbQuery.Append(" ,BILL_QTY ");
                    sbQuery.Append(" ,BILL_AMT ");
                    sbQuery.Append(" ,COL_PLAN_DATE ");
                    sbQuery.Append(" ,SCOMMENT ");
                    sbQuery.Append(" ,REG_DATE ");
                    sbQuery.Append(" ,REG_EMP ");
                    sbQuery.Append(" ,DATA_FLAG ");
                    sbQuery.Append("  ) VALUES (  ");
                    sbQuery.Append("  @PLT_CODE ");
                    sbQuery.Append(" ,@BILL_NO ");
                    sbQuery.Append(" ,@BILL_TYPE ");
                    sbQuery.Append(" ,@PROD_CODE ");
                    sbQuery.Append(" ,@BILL_DATE ");
                    sbQuery.Append(" ,@BILL_EMP ");
                    sbQuery.Append(" ,@BILL_QTY ");
                    sbQuery.Append(" ,@BILL_AMT ");
                    sbQuery.Append(" ,@COL_PLAN_DATE ");
                    sbQuery.Append(" ,@SCOMMENT ");
                    sbQuery.Append(" ,GETDATE() ");
                    sbQuery.Append(" ,'"+ ConnInfo.UserID +"'");
                    sbQuery.Append(" ,0 ");
                    sbQuery.Append("  ) ");

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


        public static void TORD_PRODUCT_BILL_UPD(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TORD_PRODUCT_BILL SET  ");
                    sbQuery.Append("  PROD_CODE = @PROD_CODE ");
                    sbQuery.Append(" ,BILL_DATE = @BILL_DATE ");
                    sbQuery.Append(" ,BILL_TYPE = @BILL_TYPE ");
                    sbQuery.Append(" ,BILL_EMP = @BILL_EMP ");
                    sbQuery.Append(" ,BILL_QTY = @BILL_QTY ");
                    sbQuery.Append(" ,BILL_AMT = @BILL_AMT ");
                    sbQuery.Append(" ,SCOMMENT = @SCOMMENT ");
                    sbQuery.Append(" ,COL_PLAN_DATE = @COL_PLAN_DATE ");
                    sbQuery.Append(" ,MDFY_DATE = GETDATE() ");
                    sbQuery.Append(" ,MDFY_EMP ='" + ConnInfo.UserID + "'");
                    sbQuery.Append(" ,DATA_FLAG = @DATA_FLAG ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append("  AND BILL_NO = @BILL_NO ");
                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "BILL_NO")) isHasColumn = false;

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

        public static void TORD_PRODUCT_BILL_UPD2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TORD_PRODUCT_BILL SET  ");
                    sbQuery.Append("  PROD_CODE = @PROD_CODE ");
                    sbQuery.Append(" ,COLLECT_DATE = @COLLECT_DATE ");
                    sbQuery.Append(" ,MDFY_DATE = GETDATE() ");
                    sbQuery.Append(" ,MDFY_EMP ='" + ConnInfo.UserID + "'");
                    sbQuery.Append(" ,DATA_FLAG = @DATA_FLAG ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append("  AND BILL_NO = @BILL_NO ");
                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "BILL_NO")) isHasColumn = false;

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

        public static void TORD_PRODUCT_BILL_UDE(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TORD_PRODUCT_BILL SET  ");                    
                    sbQuery.Append(" DEL_DATE = GETDATE() ");
                    sbQuery.Append(" ,DEL_EMP ='" + ConnInfo.UserID + "'");
                    sbQuery.Append(" ,DATA_FLAG = 2 ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append("  AND BILL_NO = @BILL_NO ");
                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "BILL_NO")) isHasColumn = false;

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

    public class TORD_PRODUCT_BILL_QUERY
    {
        public static DataTable TORD_PRODUCT_BILL_QUERY1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {


                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT");
                    sbQuery.Append(" PLT_CODE");
                    sbQuery.Append(" ,BILL_NO");
                    sbQuery.Append(" ,BILL_TYPE");
                    sbQuery.Append(" ,PROD_CODE");
                    sbQuery.Append(" ,BILL_DATE");
                    sbQuery.Append(" ,BILL_EMP");
                    sbQuery.Append(" ,BILL_QTY");
                    sbQuery.Append(" ,BILL_AMT");
                    sbQuery.Append(" FROM TORD_PRODUCT_BILL");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_CODE", "PROD_CODE = @PROD_CODE"));

                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_CODE_IN", "PROD_CODE IN @PROD_CODE_IN", UTIL.SqlCondType.IN));

                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "DATA_FLAG = @DATA_FLAG"));


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

        public static DataTable TORD_PRODUCT_BILL_QUERY2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {


                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    //sbQuery.Append(" SELECT");
                    //sbQuery.Append(" TAX.PLT_CODE");
                    //sbQuery.Append(" ,LEFT(TAX.BILL_DATE, 6) AS BILL_DATE");
                    //sbQuery.Append(" ,TAX.BVEN_NAME");
                    //sbQuery.Append(" ,TAX.BVEN_CURRENCY");
                    //sbQuery.Append(" ,SUM(TAX.BILL_AMT) AS BILL_AMT");
                    //sbQuery.Append(" FROM");
                    //sbQuery.Append(" (");
                    //sbQuery.Append(" SELECT");
                    //sbQuery.Append(" B.PLT_CODE");
                    //sbQuery.Append(" ,ROW_NUMBER() OVER(PARTITION BY B.PROD_CODE ORDER BY B.BILL_DATE) AS BILL_SEQ");
                    //sbQuery.Append(" ,B.BILL_NO");
                    //sbQuery.Append(" ,B.BILL_TYPE");
                    //sbQuery.Append(" ,B.PROD_CODE");
                    //sbQuery.Append(" ,B.BILL_DATE");
                    //sbQuery.Append(" ,B.BILL_QTY");
                    //sbQuery.Append(" ,ISNULL(B.BILL_AMT, 0) AS BILL_AMT");
                    //sbQuery.Append(" ,V.BVEN_NAME");
                    //sbQuery.Append(" ,V.BVEN_CURRENCY");
                    //sbQuery.Append(" FROM TORD_PRODUCT_BILL B");
                    //sbQuery.Append(" LEFT JOIN TORD_PRODUCT P");
                    //sbQuery.Append(" ON B.PLT_CODE = P.PLT_CODE");
                    //sbQuery.Append(" AND B.PROD_CODE = P.PROD_CODE");
                    //sbQuery.Append(" LEFT JOIN TSTD_BILL_VENDOR V");
                    //sbQuery.Append(" ON P.PLT_CODE = V.PLT_CODE");
                    //sbQuery.Append(" AND P.TVND_CODE = V.BVEN_CODE");
                    //sbQuery.Append(" WHERE B.DATA_FLAG = '0'");
                    //sbQuery.Append(" AND B.BILL_TYPE = 'TAX'");
                    //sbQuery.Append(" AND P.DATA_FLAG = '0'");
                    //sbQuery.Append(" ) TAX");
                    //sbQuery.Append(" LEFT JOIN");
                    //sbQuery.Append(" (");
                    //sbQuery.Append(" SELECT");
                    //sbQuery.Append(" B.PLT_CODE");
                    //sbQuery.Append(" ,ROW_NUMBER() OVER(PARTITION BY B.PROD_CODE ORDER BY B.BILL_DATE) AS BILL_SEQ");
                    //sbQuery.Append(" ,B.BILL_NO");
                    //sbQuery.Append(" ,B.BILL_TYPE");
                    //sbQuery.Append(" ,B.PROD_CODE");
                    //sbQuery.Append(" ,B.BILL_DATE");
                    //sbQuery.Append(" ,B.BILL_QTY");
                    //sbQuery.Append(" ,ISNULL(B.BILL_AMT, 0) AS BILL_AMT");
                    //sbQuery.Append(" ,V.BVEN_NAME");
                    //sbQuery.Append(" ,V.BVEN_CURRENCY");
                    //sbQuery.Append(" FROM TORD_PRODUCT_BILL B");
                    //sbQuery.Append(" LEFT JOIN TORD_PRODUCT P");
                    //sbQuery.Append(" ON B.PLT_CODE = P.PLT_CODE");
                    //sbQuery.Append(" AND B.PROD_CODE = P.PROD_CODE");
                    //sbQuery.Append(" LEFT JOIN TSTD_BILL_VENDOR V");
                    //sbQuery.Append(" ON P.PLT_CODE = V.PLT_CODE");
                    //sbQuery.Append(" AND P.TVND_CODE = V.BVEN_CODE");
                    //sbQuery.Append(" WHERE B.DATA_FLAG = '0'");
                    //sbQuery.Append(" AND B.BILL_TYPE = 'COL'");
                    //sbQuery.Append(" AND P.DATA_FLAG = '0'");
                    //sbQuery.Append(" )COL");
                    //sbQuery.Append(" ON TAX.PLT_CODE = COL.PLT_CODE");
                    //sbQuery.Append(" AND TAX.PROD_CODE = COL.PROD_CODE");
                    //sbQuery.Append(" AND TAX.BILL_SEQ = COL.BILL_SEQ");

                    sbQuery.Append(" SELECT D.PLT_CODE, BILL_DATE, ISNULL(BVEN_NAME, '') AS BVEN_NAME, ISNULL(BVEN_CURRENCY,'01') AS BVEN_CURRENCY, D.BILL_AMT - CASE WHEN D.COL_AMT < 0 THEN 0 ELSE D.COL_AMT END AS BILL_AMT FROM");
                    sbQuery.Append(" (");
                    sbQuery.Append(" SELECT");
                    sbQuery.Append(" B.PLT_CODE, B.BILL_SEQ, B.BILL_DATE, B.PROD_CODE, B.BILL_AMT");
                    sbQuery.Append(" ,CASE WHEN SUM(C.BILL_AMT) - ISNULL((SELECT SUM(ISNULL(BILL_AMT,0)) FROM TORD_PRODUCT_BILL WHERE PROD_CODE = B.PROD_CODE AND BILL_TYPE = 'COL' AND DATA_FLAG = '0' ), 0) < 0 THEN B.BILL_AMT");
                    sbQuery.Append(" ELSE B.BILL_AMT - ISNULL((SUM(C.BILL_AMT) - ISNULL((SELECT SUM(ISNULL(BILL_AMT,0)) FROM TORD_PRODUCT_BILL WHERE PROD_CODE = B.PROD_CODE AND BILL_TYPE = 'COL' AND DATA_FLAG = '0'), 0)), 0) END COL_AMT");
                    sbQuery.Append(" FROM");
                    sbQuery.Append(" (");
                    sbQuery.Append(" SELECT");
                    sbQuery.Append(" PLT_CODE");
                    sbQuery.Append(" ,ROW_NUMBER() OVER(PARTITION BY A.PROD_CODE ORDER BY A.BILL_DATE) AS BILL_SEQ");
                    sbQuery.Append(" ,PROD_CODE, BILL_DATE, BILL_AMT FROM TORD_PRODUCT_BILL A");
                    sbQuery.Append(" WHERE A.BILL_TYPE = 'TAX'");
                    sbQuery.Append(" AND A.DATA_FLAG = '0'");
                    sbQuery.Append(" AND LEFT(BILL_DATE, 4) = @YEAR");
                    sbQuery.Append(" ) B");
                    sbQuery.Append(" LEFT JOIN");
                    sbQuery.Append(" (");
                    sbQuery.Append(" SELECT * FROM");
                    sbQuery.Append(" (");
                    sbQuery.Append(" SELECT");
                    sbQuery.Append(" PLT_CODE");
                    sbQuery.Append(" ,ROW_NUMBER() OVER(PARTITION BY A.PROD_CODE ORDER BY A.BILL_DATE) AS BILL_SEQ");
                    sbQuery.Append(" ,PROD_CODE, BILL_DATE, BILL_AMT FROM TORD_PRODUCT_BILL A");
                    sbQuery.Append(" WHERE A.BILL_TYPE = 'TAX'");
                    sbQuery.Append(" AND A.DATA_FLAG = '0'");
                    sbQuery.Append(" AND LEFT(BILL_DATE, 4) = @YEAR");
                    sbQuery.Append(" ) B");
                    sbQuery.Append(" ) C");
                    sbQuery.Append(" ON B.PROD_CODE = C.PROD_CODE");
                    sbQuery.Append(" AND B.BILL_SEQ >= C.BILL_SEQ");
                    sbQuery.Append(" GROUP BY B.PLT_CODE, B.BILL_SEQ, B.BILL_DATE, B.PROD_CODE, B.BILL_AMT");
                    sbQuery.Append(" ) D");
                    sbQuery.Append(" JOIN TORD_PRODUCT P");
                    sbQuery.Append(" ON D.PLT_CODE = P.PLT_CODE");
                    sbQuery.Append(" AND D.PROD_CODE = P.PROD_CODE");
                    sbQuery.Append(" LEFT JOIN TSTD_BILL_VENDOR V");
                    sbQuery.Append(" ON P.PLT_CODE = V.PLT_CODE");
                    sbQuery.Append(" AND P.TVND_CODE = V.BVEN_CODE");



                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE D.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(" AND D.BILL_AMT - D.COL_AMT > 0");
                        sbWhere.Append(" AND P.DATA_FLAG = '0'");
                        sbWhere.Append(" ORDER BY BILL_DATE");


                        //sbWhere.Append(UTIL.GetWhere(row, "@YEAR", "LEFT(TAX.BILL_DATE, 4) = @YEAR"));

                        //sbWhere.Append(" AND COL.BILL_NO IS NULL");
                        //sbWhere.Append(" AND TAX.BVEN_NAME IS NOT NULL");

                        //sbWhere.Append(" GROUP BY TAX.PLT_CODE");
                        //sbWhere.Append(" ,LEFT(TAX.BILL_DATE, 6)");
                        //sbWhere.Append(" ,TAX.BVEN_NAME");
                        //sbWhere.Append(" ,TAX.BVEN_CURRENCY");


                        DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString() + sbWhere.ToString(), row).Copy();

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

        public static DataTable TORD_PRODUCT_BILL_QUERY3(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {


                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT");
                    sbQuery.Append(" SH.PLT_CODE");
                    sbQuery.Append(" ,SH.BVEN_NAME");
                    sbQuery.Append(" ,SH.BVEN_CURRENCY");
                    sbQuery.Append(" ,LEFT(SH.SHIP_DATE, 6) AS SHIP_DATE");
                    sbQuery.Append(" ,SUM((SH.SHIP_QTY - ISNULL(B.BILL_QTY, 0)) * SH.PROD_COST) AS REMAIN_AMT");
                    sbQuery.Append(" FROM");
                    sbQuery.Append(" (");
                    sbQuery.Append(" SELECT");
                    sbQuery.Append(" S.PLT_CODE");
                    sbQuery.Append(" ,S.PROD_CODE");
                    sbQuery.Append(" ,V.BVEN_NAME");
                    sbQuery.Append(" ,MAX(S.SHIP_DATE) AS SHIP_DATE");
                    sbQuery.Append(" ,CASE WHEN SUM(S.SHIP_QTY) > P.PROD_QTY THEN PROD_QTY ELSE SUM(S.SHIP_QTY) END AS SHIP_QTY");
                    sbQuery.Append(" ,P.PROD_COST");
                    sbQuery.Append(" ,V.BVEN_CURRENCY");
                    sbQuery.Append(" FROM TORD_SHIP S");
                    sbQuery.Append(" LEFT JOIN TORD_PRODUCT P");
                    sbQuery.Append(" ON S.PLT_CODE = P.PLT_CODE");
                    sbQuery.Append(" AND S.PROD_CODE = P.PROD_CODE");
                    sbQuery.Append(" LEFT JOIN TSTD_BILL_VENDOR V");
                    sbQuery.Append(" ON P.PLT_CODE = V.PLT_CODE");
                    sbQuery.Append(" AND P.TVND_CODE = V.BVEN_CODE");
                    sbQuery.Append(" WHERE S.DATA_FLAG = '0'");
                    sbQuery.Append(" AND P.DATA_FLAG = '0'");
                    sbQuery.Append(" AND P.PROD_STATE <> '5'");
                    sbQuery.Append(" AND BVEN_CODE IS NOT NULL");
                    sbQuery.Append(" GROUP BY S.PLT_CODE");
                    sbQuery.Append(" ,S.PROD_CODE");
                    sbQuery.Append(" ,V.BVEN_NAME");
                    sbQuery.Append(" ,P.PROD_QTY");
                    sbQuery.Append(" ,P.PROD_COST");
                    sbQuery.Append(" ,V.BVEN_CURRENCY");
                    sbQuery.Append(" ) SH");
                    sbQuery.Append(" LEFT JOIN");
                    sbQuery.Append(" (");
                    sbQuery.Append(" SELECT");
                    sbQuery.Append(" B.PLT_CODE");
                    sbQuery.Append(" ,B.PROD_CODE");
                    sbQuery.Append(" ,V.BVEN_NAME");
                    sbQuery.Append(" ,MAX(B.BILL_DATE) AS BILL_DATE");
                    sbQuery.Append(" ,SUM(ISNULL(B.BILL_QTY, 0)) AS BILL_QTY");
                    sbQuery.Append(" FROM TORD_PRODUCT_BILL B");
                    sbQuery.Append(" LEFT JOIN TORD_PRODUCT P");
                    sbQuery.Append(" ON B.PLT_CODE = P.PLT_CODE");
                    sbQuery.Append(" AND B.PROD_CODE = P.PROD_CODE");
                    sbQuery.Append(" LEFT JOIN TSTD_BILL_VENDOR V");
                    sbQuery.Append(" ON P.PLT_CODE = V.PLT_CODE");
                    sbQuery.Append(" AND P.TVND_CODE = V.BVEN_CODE");
                    sbQuery.Append(" WHERE B.DATA_FLAG = '0'");
                    sbQuery.Append(" AND B.BILL_TYPE = 'TAX'");
                    sbQuery.Append(" AND P.DATA_FLAG = '0'");
                    sbQuery.Append(" AND BVEN_CODE IS NOT NULL");
                    sbQuery.Append(" GROUP BY B.PLT_CODE");
                    sbQuery.Append(" ,B.PROD_CODE");
                    sbQuery.Append(" ,V.BVEN_NAME");
                    sbQuery.Append(" )B");
                    sbQuery.Append(" ON SH.PLT_CODE = B.PLT_CODE");
                    sbQuery.Append(" AND SH.PROD_CODE = B.PROD_CODE");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE SH.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@YEAR", "LEFT(SH.SHIP_DATE, 4) = @YEAR"));

                        sbWhere.Append(" AND SH.SHIP_QTY > ISNULL(B.BILL_QTY, 0)");

                        sbWhere.Append(" GROUP BY SH.PLT_CODE");
                        sbWhere.Append(" ,SH.BVEN_NAME");
                        sbWhere.Append(" ,SH.BVEN_CURRENCY");
                        sbWhere.Append(" ,LEFT(SH.SHIP_DATE, 6)");

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
