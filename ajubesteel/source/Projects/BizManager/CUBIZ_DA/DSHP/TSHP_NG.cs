using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace DSHP
{
    public class TSHP_NG
    {
        public static DataTable TSHP_NG_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT   PLT_CODE       ");
                    sbQuery.Append("       , NG_ID           ");
                    sbQuery.Append("       , NG_STATE        ");
                    sbQuery.Append("       , LINK_KEY        ");
                    sbQuery.Append("       , MASTER_CAUSE    ");
                    sbQuery.Append("       , DETAIL_CAUSE    ");
                    sbQuery.Append("       , EMP_CODE       ");
                    sbQuery.Append("       , QUANTITY        ");
                    sbQuery.Append("       , ACT_TYPE        ");
                    sbQuery.Append("       , NG_TYPE         ");
                    sbQuery.Append("       , NG_CONTENTS     ");
                    sbQuery.Append("       , NG_CAUSE        ");
                    sbQuery.Append("       , NG_MEASURE      ");
                    sbQuery.Append("       , NG_MEASURE_DATE ");
                    sbQuery.Append("       , NG_MEASURE_EMP  ");
                    sbQuery.Append("       , MDFY_EMP        ");
                    sbQuery.Append("       , MDFY_DATE       ");
                    sbQuery.Append("  FROM TSHP_NG           ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append("   AND NG_ID = @NG_ID ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "NG_ID")) isHasColumn = false;

                        if (isHasColumn)
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

        public static DataTable TSHP_NG_SER2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT  Row_Number() OVER (ORDER BY NG_ID ASC) AS SEQ ");
                    sbQuery.Append(" , N.PLT_CODE");
                    sbQuery.Append(" , N.NG_ID");
                    sbQuery.Append(" , A.WORK_DATE");
                    sbQuery.Append(" , N.LINK_KEY");
                    sbQuery.Append(" , A.MC_CODE");
                    sbQuery.Append(" , A.EMP_CODE");
                    sbQuery.Append(" , N.ACT_TYPE");
                    sbQuery.Append(" , N.MASTER_CAUSE");
                    sbQuery.Append(" , N.DETAIL_CAUSE");
                    sbQuery.Append(" , N.QUANTITY");
                    sbQuery.Append(" FROM TSHP_NG N");
                    sbQuery.Append(" LEFT JOIN TSHP_ACTUAL A");
                    sbQuery.Append(" ON N.PLT_CODE = A.PLT_CODE");
                    sbQuery.Append(" AND N.LINK_KEY = A.ACTUAL_ID");
                    sbQuery.Append(" WHERE N.PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND N.LINK_KEY = @LINK_KEY");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "LINK_KEY")) isHasColumn = false;

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
        /// 선택된 실적번호에 해당되는 불량수량 합계를 알아옴
        /// </summary>
        /// <param name="dtParam"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataTable TSHP_NG_SER4(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT   PLT_CODE ");
                    sbQuery.Append(" , SUM(QUANTITY) AS TOT_QTY   ");
                    sbQuery.Append("   FROM TSHP_NG               ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE   ");
                    sbQuery.Append(" AND LINK_KEY = @LINK_KEY     ");
                    sbQuery.Append(" GROUP BY PLT_CODE , LINK_KEY ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "LINK_KEY")) isHasColumn = false;

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

        public static DataTable TSHP_NG_SER5(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT   PLT_CODE ");
                    sbQuery.Append(" , NG_IMG   ");
                    sbQuery.Append("   FROM TSHP_NG               ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE   ");
                    sbQuery.Append(" AND NG_ID = @NG_ID     ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "NG_ID")) isHasColumn = false;

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

        public static void TSHP_NG_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" INSERT INTO TSHP_NG");
                    sbQuery.Append(" (");
                    sbQuery.Append(" PLT_CODE");
                    sbQuery.Append(" , NG_ID");
                    sbQuery.Append(" , NG_STATE");
                    sbQuery.Append(" , LINK_KEY");
                    sbQuery.Append(" , MASTER_CAUSE");
                    sbQuery.Append(" , DETAIL_CAUSE");
                    //sbQuery.Append(" , NG_PROC_COST");
                    //sbQuery.Append(" , NG_OUT_COST");
                    sbQuery.Append(" , EMP_CODE");
                    sbQuery.Append(" , MC_CODE");
                    sbQuery.Append(" , QUANTITY");
                    sbQuery.Append(" , ACT_TYPE");
                    sbQuery.Append(" , NG_DATE");
                    sbQuery.Append(" )");
                    sbQuery.Append(" VALUES");
                    sbQuery.Append(" (");
                    sbQuery.Append(" @PLT_CODE");
                    sbQuery.Append(" , @NG_ID");
                    sbQuery.Append(" , @NG_STATE");
                    sbQuery.Append(" , @LINK_KEY");
                    sbQuery.Append(" , @MASTER_CAUSE");
                    sbQuery.Append(" , @DETAIL_CAUSE");
                    //sbQuery.Append(" , @NG_PROC_COST");
                    //sbQuery.Append(" , @NG_OUT_COST");
                    sbQuery.Append(" , @EMP_CODE");
                    sbQuery.Append(" , @MC_CODE");
                    sbQuery.Append(" , @QUANTITY");
                    sbQuery.Append(" , @ACT_TYPE");
                    sbQuery.Append(" , CONVERT(VARCHAR(8), GETDATE(), 112)");
                    sbQuery.Append(" )");


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

        public static void TSHP_NG_INS2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" INSERT INTO TSHP_NG");
                    sbQuery.Append(" (");
                    sbQuery.Append(" PLT_CODE");
                    sbQuery.Append(" , NG_ID");
                    sbQuery.Append(" , NG_STATE");
                    sbQuery.Append(" , LINK_KEY");
                    sbQuery.Append(" , MASTER_CAUSE");
                    sbQuery.Append(" , DETAIL_CAUSE");
                    sbQuery.Append(" , QUANTITY");
                    sbQuery.Append(" , ACT_TYPE");
                    sbQuery.Append(" , NG_TYPE      ");
                    sbQuery.Append(" , NG_CONTENTS  ");
                    sbQuery.Append(" , NG_CAUSE     ");
                    sbQuery.Append(" , NG_MEASURE   ");
                    sbQuery.Append(" , NG_MEASURE_EMP   ");
                    sbQuery.Append(" , NG_CAT   ");
                    sbQuery.Append(" , NG_OCCUR   ");
                    sbQuery.Append(" , NG_OUT_COST   ");
                    sbQuery.Append(" , NG_PROC_COST   ");
                    sbQuery.Append(" , NG_COST   ");
                    sbQuery.Append(" , NG_COST_CODE   "); 
                    sbQuery.Append(" , NG_MAT_COST   ");
                    sbQuery.Append(" , NG_LAB_COST   ");
                    sbQuery.Append(" , NG_DIST_COST   ");
                    sbQuery.Append(" , EMP_CODE");
                    sbQuery.Append(" , BUSINESS_EMP");
                    sbQuery.Append(" , DEV_EMP");
                    sbQuery.Append(" , MC_CODE");
                    sbQuery.Append(" , NG_IMG");
                    sbQuery.Append(" , NG_DATE");
                    sbQuery.Append(" , MDFY_DATE");
                    sbQuery.Append(" , MDFY_EMP");
                    sbQuery.Append(" )");
                    sbQuery.Append(" VALUES");
                    sbQuery.Append(" (");
                    sbQuery.Append(" @PLT_CODE");
                    sbQuery.Append(" , @NG_ID");
                    sbQuery.Append(" , @NG_STATE");
                    sbQuery.Append(" , @LINK_KEY");
                    sbQuery.Append(" , @MASTER_CAUSE");
                    sbQuery.Append(" , @DETAIL_CAUSE");
                    sbQuery.Append(" , @QUANTITY");
                    sbQuery.Append(" , @ACT_TYPE     ");
                    sbQuery.Append(" , @NG_TYPE      ");
                    sbQuery.Append(" , @NG_CONTENTS  ");
                    sbQuery.Append(" , @NG_CAUSE     ");
                    sbQuery.Append(" , @NG_MEASURE   ");
                    sbQuery.Append(" , @NG_MEASURE_EMP   ");
                    sbQuery.Append(" , @NG_CAT   ");
                    sbQuery.Append(" , @NG_OCCUR   ");
                    sbQuery.Append(" , @NG_OUT_COST   ");
                    sbQuery.Append(" , @NG_PROC_COST   ");
                    sbQuery.Append(" , @NG_COST   ");
                    sbQuery.Append(" , @NG_COST_CODE   ");
                    sbQuery.Append(" , @NG_MAT_COST   ");
                    sbQuery.Append(" , @NG_LAB_COST   ");
                    sbQuery.Append(" , @NG_DIST_COST   ");
                    sbQuery.Append(" , @EMP_CODE");
                    sbQuery.Append(" , @BUSINESS_EMP");
                    sbQuery.Append(" , @DEV_EMP");
                    sbQuery.Append(" , @MC_CODE");
                    sbQuery.Append(" , @NG_IMG");
                    sbQuery.Append(" , CONVERT(VARCHAR(8), GETDATE(), 112)");
                    sbQuery.Append(" , GETDATE()");
                    sbQuery.Append(" ,'" + ConnInfo.UserID + "' ");
                    sbQuery.Append(" )");


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



        public static void TSHP_NG_INS3(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" INSERT INTO TSHP_NG");
                    sbQuery.Append(" (");
                    sbQuery.Append(" PLT_CODE");
                    sbQuery.Append(" , NG_ID");
                    sbQuery.Append(" , NG_STATE");
                    sbQuery.Append(" , LINK_KEY");
                    sbQuery.Append(" , MASTER_CAUSE");
                    sbQuery.Append(" , DETAIL_CAUSE");
                    sbQuery.Append(" , QUANTITY");
                    sbQuery.Append(" , ACT_TYPE");
                    sbQuery.Append(" , NG_TYPE      ");
                    sbQuery.Append(" , NG_CONTENTS  ");
                    sbQuery.Append(" , NG_CAUSE     ");
                    sbQuery.Append(" , NG_MEASURE   ");
                    sbQuery.Append(" , NG_MEASURE_EMP   ");
                    sbQuery.Append(" , NG_CAT   ");
                    sbQuery.Append(" , NG_OCCUR   ");
                    sbQuery.Append(" , NG_OUT_COST   ");
                    sbQuery.Append(" , NG_PROC_COST   ");
                    sbQuery.Append(" , NG_COST   ");
                    sbQuery.Append(" , NG_COST_CODE   ");
                    sbQuery.Append(" , NG_MAT_COST   ");
                    sbQuery.Append(" , NG_LAB_COST   ");
                    sbQuery.Append(" , NG_DIST_COST   ");
                    sbQuery.Append(" , NG_MC          ");
                    sbQuery.Append(" , NG_PART        ");
                    sbQuery.Append(" , NG_PROC        ");
                    sbQuery.Append(" , NG_DATE        ");

                    sbQuery.Append(" , MDFY_DATE");
                    sbQuery.Append(" , MDFY_EMP");
                    sbQuery.Append(" )");
                    sbQuery.Append(" VALUES");
                    sbQuery.Append(" (");
                    sbQuery.Append(" @PLT_CODE");
                    sbQuery.Append(" , @NG_ID");
                    sbQuery.Append(" , @NG_STATE");
                    sbQuery.Append(" , @LINK_KEY");
                    sbQuery.Append(" , @MASTER_CAUSE");
                    sbQuery.Append(" , @DETAIL_CAUSE");
                    sbQuery.Append(" , @QUANTITY");
                    sbQuery.Append(" , @ACT_TYPE     ");
                    sbQuery.Append(" , @NG_TYPE      ");
                    sbQuery.Append(" , @NG_CONTENTS  ");
                    sbQuery.Append(" , @NG_CAUSE     ");
                    sbQuery.Append(" , @NG_MEASURE   ");
                    sbQuery.Append(" , @NG_MEASURE_EMP   ");
                    sbQuery.Append(" , @NG_CAT   ");
                    sbQuery.Append(" , @NG_OCCUR   ");
                    sbQuery.Append(" , @NG_OUT_COST   ");
                    sbQuery.Append(" , @NG_PROC_COST   ");
                    sbQuery.Append(" , @NG_COST   ");
                    sbQuery.Append(" , @NG_COST_CODE   ");
                    sbQuery.Append(" , @NG_MAT_COST   ");
                    sbQuery.Append(" , @NG_LAB_COST   ");
                    sbQuery.Append(" , @NG_DIST_COST   ");
                    sbQuery.Append(" , @NG_MC          ");
                    sbQuery.Append(" , @NG_PART        ");
                    sbQuery.Append(" , @NG_PROC        ");
                    sbQuery.Append(" , @NG_DATE        ");
                    sbQuery.Append(" , GETDATE()");
                    sbQuery.Append(" ,'" + ConnInfo.UserID + "' ");
                    sbQuery.Append(" )");


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






        public static void TSHP_NG_UPD(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" UPDATE TSHP_NG ");
                    sbQuery.Append("   SET   MASTER_CAUSE = @MASTER_CAUSE");
                    sbQuery.Append("       , DETAIL_CAUSE = @DETAIL_CAUSE");
                    sbQuery.Append("       , QUANTITY = @QUANTITY        ");
                    sbQuery.Append("       , NG_TYPE = @NG_TYPE          ");
                    sbQuery.Append("       , NG_CONTENTS = @NG_CONTENTS  ");
                    sbQuery.Append("       , NG_CAUSE = @NG_CAUSE        ");
                    sbQuery.Append("       , NG_MEASURE = @NG_MEASURE    ");
                    sbQuery.Append("       , NG_MEASURE_EMP = @NG_MEASURE_EMP ");
                    sbQuery.Append("       , NG_CAT = @NG_CAT            ");
                    sbQuery.Append("       , NG_OCCUR = @NG_OCCUR        ");
                    sbQuery.Append("       , NG_OUT_COST = @NG_OUT_COST  ");
                    sbQuery.Append("       , NG_PROC_COST = @NG_PROC_COST  ");
                    sbQuery.Append("       , NG_COST = @NG_COST          ");
                    sbQuery.Append("       , NG_COST_CODE = @NG_COST_CODE          ");
                    sbQuery.Append("       , NG_MAT_COST  = @NG_MAT_COST  ");
                    sbQuery.Append("       , NG_LAB_COST  = @NG_LAB_COST  ");
                    sbQuery.Append("       , NG_DIST_COST = @NG_DIST_COST  ");
                    sbQuery.Append("       , EMP_CODE = @EMP_CODE  ");
                    sbQuery.Append("       , BUSINESS_EMP = @BUSINESS_EMP  ");
                    sbQuery.Append("       , DEV_EMP = @DEV_EMP  ");
                    sbQuery.Append("       , NG_IMG = @NG_IMG  ");
                    sbQuery.Append("       , MDFY_EMP = @MDFY_EMP        ");
                    sbQuery.Append("       , MDFY_DATE = GETDATE()      ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE          ");
                    sbQuery.Append("   AND NG_ID = @NG_ID                ");

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

        public static void TSHP_NG_UPD2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" UPDATE TSHP_NG                             ");
                    sbQuery.Append("   SET   NG_STATE = @NG_STATE               ");
                    sbQuery.Append("       , NG_MEASURE_DATE = CONVERT(nvarchar(8), GETDATE(), 112) ");
                    sbQuery.Append("       ,MDFY_DATE = GETDATE() ");
                    sbQuery.Append("       , MDFY_EMP = '" + ConnInfo.UserID + "'");
                    sbQuery.Append("       , NG_MEASURE_EMP = @NG_MEASURE_EMP   ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE                 ");
                    sbQuery.Append("   AND NG_ID = @NG_ID                       ");

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

        public static void TSHP_NG_UPD3(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" UPDATE TSHP_NG                             ");
                    sbQuery.Append("   SET   WK_NG_QTY = @WK_NG_QTY               ");
                    sbQuery.Append("       ,MDFY_DATE = GETDATE() ");
                    sbQuery.Append("       ,MDFY_EMP = '" + ConnInfo.UserID + "'");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE                 ");
                    sbQuery.Append("   AND NG_ID = @NG_ID                       ");

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

        public static void TSHP_NG_UPD4(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" UPDATE TSHP_NG                             ");
                    sbQuery.Append("   SET   IS_NG_REWORK = @IS_NG_REWORK               ");
                    sbQuery.Append("       ,RE_WO_NO = @RE_WO_NO               ");
                    sbQuery.Append("       ,MDFY_DATE = GETDATE() ");
                    sbQuery.Append("       ,MDFY_EMP = '" + ConnInfo.UserID + "'");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE                 ");
                    sbQuery.Append("   AND NG_ID = @NG_ID                       ");

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

        public static void TSHP_NG_DEL(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" DELETE FROM TSHP_NG ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND NG_ID = @NG_ID");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "NG_ID")) isHasColumn = false;

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

        public static void TSHP_NG_DEL2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" DELETE FROM TSHP_NG ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND LINK_KEY = @LINK_KEY");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "LINK_KEY")) isHasColumn = false;

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

    public class TSHP_NG_QUERY
    {
        public static DataTable TSHP_NG_QUERY1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("SELECT NG.PLT_CODE                 ");
                    sbQuery.Append("      , NG.NG_COST_CODE AS GUBUN  ");
                    sbQuery.Append("      , SUBSTRING(D.WORK_DATE,5,2) as MONTH  ");
                    sbQuery.Append("      , NG.NG_COST AS COST ");
                    sbQuery.Append("  FROM TSHP_NG NG            ");
                    sbQuery.Append("    JOIN TSHP_DAILYWORK D            ");
                    sbQuery.Append("      ON NG.PLT_CODE = D.PLT_CODE     ");
                    sbQuery.Append("      AND NG.LINK_KEY = D.ACTUAL_ID   ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder();

                        sbWhere.Append(" WHERE NG.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                        
                        sbWhere.Append(UTIL.GetWhere(row, "@YEAR", "LEFT(D.WORK_DATE,4) = @YEAR"));

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

        public static DataTable TSHP_NG_QUERY2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT");
                    sbQuery.Append(" N.PLT_CODE");
                    sbQuery.Append(" ,N.NG_ID");
                    sbQuery.Append(" ,N.LINK_KEY");
                    sbQuery.Append(" ,W.WO_NO");
                    sbQuery.Append(" ,P.CVND_CODE");
                    sbQuery.Append(" ,V.VEN_NAME AS CVND_NAME");
                    sbQuery.Append(" ,W.PROD_CODE");
                    sbQuery.Append(" ,P.PROD_NAME");
                    sbQuery.Append(" ,W.PART_CODE");
                    sbQuery.Append(" ,SP.PART_NAME");
                    sbQuery.Append(" ,SP.DRAW_NO");
                    sbQuery.Append(" ,N.MC_CODE");
                    sbQuery.Append(" ,M.MC_NAME");
                    sbQuery.Append(" ,W.PROC_CODE");
                    sbQuery.Append(" ,PR.PROC_NAME");
                    sbQuery.Append(" ,N.EMP_CODE");
                    sbQuery.Append(" ,E.EMP_NAME");
                    sbQuery.Append(" ,N.BUSINESS_EMP");
                    sbQuery.Append(" ,BE.EMP_NAME AS BUSINESS_EMP_NAME");
                    sbQuery.Append(" ,N.DEV_EMP");
                    sbQuery.Append(" ,DE.EMP_NAME AS DEV_EMP_NAME");
                    sbQuery.Append(" ,N.NG_DATE");
                    sbQuery.Append(" ,N.ACT_TYPE");
                    sbQuery.Append(" ,N.MASTER_CAUSE");
                    sbQuery.Append(" ,N.DETAIL_CAUSE");
                    sbQuery.Append(" ,N.NG_CAT");
                    sbQuery.Append(" ,N.NG_OCCUR");
                    sbQuery.Append(" ,N.NG_MEASURE_EMP");
                    sbQuery.Append(" ,NE.EMP_NAME AS NG_MEASURE_EMP_NAME");
                    //sbQuery.Append(" ,ISNULL(N.NG_MAT_COST,SP.MAT_COST * N.QUANTITY) AS NG_MAT_COST");
                    sbQuery.Append(" ,N.NG_MAT_COST");
                    sbQuery.Append(" ,N.NG_OUT_COST");
                    sbQuery.Append(" ,N.NG_PROC_COST");
                    sbQuery.Append(" ,N.NG_LAB_COST");
                    sbQuery.Append(" ,N.NG_DIST_COST");
                    sbQuery.Append(" ,N.NG_COST");
                    sbQuery.Append(" ,N.NG_COST_CODE");
                    sbQuery.Append(" ,N.QUANTITY");
                    sbQuery.Append(" ,N.WK_NG_QTY"); 
                    sbQuery.Append(" ,N.NG_STATE");
                    sbQuery.Append(" ,N.NG_TYPE");
                    sbQuery.Append(" ,N.NG_CONTENTS");
                    sbQuery.Append(" ,N.NG_CAUSE");
                    sbQuery.Append(" ,N.NG_MEASURE");
                    sbQuery.Append(" ,AD.DRAW_EMP ");
                    sbQuery.Append(" ,P.DUE_DATE ");

                    sbQuery.Append(" ,PM.OVND_CODE ");
                    sbQuery.Append(" ,PV.VEN_NAME AS OVND_NAME ");

                    sbQuery.Append(" FROM TSHP_NG N");
                    sbQuery.Append(" LEFT JOIN TSHP_WORKORDER W");
                    sbQuery.Append(" ON N.PLT_CODE = W.PLT_CODE");
                    sbQuery.Append(" AND N.LINK_KEY = W.WO_NO");
                    
                    sbQuery.Append(" LEFT JOIN TORD_PRODUCT  P");
                    sbQuery.Append(" ON  W.PLT_CODE = P.PLT_CODE");
                    sbQuery.Append(" AND W.PROD_CODE = P.PROD_CODE");
                    
                    sbQuery.Append(" LEFT JOIN TSTD_VENDOR V");
                    sbQuery.Append(" ON  P.PLT_CODE = V.PLT_CODE");
                    sbQuery.Append(" AND P.CVND_CODE = V.VEN_CODE");
                    
                    sbQuery.Append(" LEFT JOIN LSE_STD_PART SP");
                    sbQuery.Append(" ON W.PLT_CODE = SP.PLT_CODE");
                    sbQuery.Append(" AND W.PART_CODE = SP.PART_CODE");
                    
                    sbQuery.Append(" LEFT JOIN LSE_STD_PROC PR");
                    sbQuery.Append(" ON W.PLT_CODE = PR.PLT_CODE");
                    sbQuery.Append(" AND W.PROC_CODE = PR.PROC_CODE");
                    
                    sbQuery.Append(" LEFT JOIN LSE_MACHINE M");
                    sbQuery.Append(" ON N.PLT_CODE = M.PLT_CODE");
                    sbQuery.Append(" AND N.MC_CODE = M.MC_CODE");
                    
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE E");
                    sbQuery.Append(" ON N.PLT_CODE = E.PLT_CODE");
                    sbQuery.Append(" AND N.EMP_CODE = E.EMP_CODE");
                    
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE NE");
                    sbQuery.Append(" ON N.PLT_CODE = NE.PLT_CODE");
                    sbQuery.Append(" AND N.NG_MEASURE_EMP = NE.EMP_CODE");

                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE BE");
                    sbQuery.Append(" ON N.PLT_CODE = BE.PLT_CODE");
                    sbQuery.Append(" AND N.BUSINESS_EMP = BE.EMP_CODE");

                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE DE");
                    sbQuery.Append(" ON N.PLT_CODE = DE.PLT_CODE");
                    sbQuery.Append(" AND N.DEV_EMP = DE.EMP_CODE");


                    sbQuery.Append(" LEFT JOIN (");
                    sbQuery.Append(" SELECT PLT_CODE, PROD_CODE, MAX(DRAW_EMP) AS DRAW_EMP FROM TMAT_PARTLIST");
                    sbQuery.Append(" WHERE ISNULL(O_PT_ID,'') = '' AND DATA_FLAG = '0' AND LEFT(PART_CODE,1) = 'A'");
                    sbQuery.Append(" GROUP BY PLT_CODE, PROD_CODE");
                    sbQuery.Append(" ) AD");
                    sbQuery.Append(" ON P.PLT_CODE = AD.PLT_CODE");
                    sbQuery.Append(" AND P.PROD_CODE = AD.PROD_CODE");


                    sbQuery.Append(" LEFT JOIN (");

                    sbQuery.Append(" SELECT PO.PLT_CODE, PO.BALJU_NUM, PO.WO_NO, PM.OVND_CODE");
                    sbQuery.Append(" FROM TOUT_PROCBALJU_MASTER PM");
                    sbQuery.Append(" LEFT JOIN TOUT_PROCBALJU PO");
                    sbQuery.Append(" ON PM.PLT_CODE = PO.PLT_CODE");
                    sbQuery.Append(" AND PM.BALJU_NUM = PO.BALJU_NUM");
                    sbQuery.Append(" LEFT JOIN TSHP_WORKORDER W");
                    sbQuery.Append(" ON PO.PLT_CODE = W.PLT_CODE");
                    sbQuery.Append(" AND PO.WO_NO = W.WO_NO");
                    sbQuery.Append(" WHERE PO.BAL_STAT <> '14'");
                    sbQuery.Append(" AND W.PROC_CODE = 'P14'");
                    sbQuery.Append(" GROUP BY PO.PLT_CODE, PO.BALJU_NUM, PO.WO_NO, PM.OVND_CODE");

                    sbQuery.Append(" ) PM");
                    sbQuery.Append(" ON  PM.PLT_CODE = N.PLT_CODE");
                    sbQuery.Append(" AND PM.WO_NO = N.LINK_KEY");

                    sbQuery.Append(" LEFT JOIN TSTD_VENDOR PV");
                    sbQuery.Append(" ON  PM.PLT_CODE = PV.PLT_CODE");
                    sbQuery.Append(" AND PM.OVND_CODE = PV.VEN_CODE");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder();

                        sbWhere.Append(" WHERE N.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@S_WORK_DATE,@E_WORK_DATE", "N.NG_DATE BETWEEN @S_WORK_DATE AND @E_WORK_DATE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_DUE_DATE,@E_DUE_DATE", "P.DUE_DATE BETWEEN @S_DUE_DATE AND @E_DUE_DATE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_DUE_DATE, @E_DUE_DATE", "ISNULL(P.CHG_DUE_DATE, P.DUE_DATE) BETWEEN @S_DUE_DATE AND @E_DUE_DATE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_LIKE", "W.PART_CODE LIKE '%' + @PART_LIKE + '%' OR SP.PART_NAME LIKE '%' + @PART_LIKE + '%'"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PROC_CODE", "W.PROC_CODE = @PROC_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@MPROC_CODE", "PR.MPROC_CODE = @MPROC_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_CODE", "W.PART_CODE = @PART_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_NAME", "P.PROD_NAME = @PROD_NAME"));
                        sbWhere.Append(UTIL.GetWhere(row, "@NG_ID", "N.NG_ID = @NG_ID"));
                        sbWhere.Append(UTIL.GetWhere(row, "@WO_NO", "W.WO_NO = @WO_NO"));

                        sbWhere.Append(UTIL.GetWhere(row, "@YEAR", "LEFT(N.NG_DATE,4) = @YEAR"));

                        sbWhere.Append(" ORDER BY N.NG_DATE DESC, N.MDFY_DATE DESC");

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


        public static DataTable TSHP_NG_QUERY3(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT  								");
                    sbQuery.Append(" U.PLT_CODE 							");
                    sbQuery.Append(" ,U.PROD_CODE 							");
                    sbQuery.Append(" ,P.PROD_NAME 							");
                    sbQuery.Append(" ,U.PART_CODE 							");
                    sbQuery.Append(" ,U.PART_NUM 							");
                    sbQuery.Append(" ,U.PART_NAME 							");
                    sbQuery.Append(" ,U.PROC_CODE 							");
                    sbQuery.Append(" ,PR.PROC_NAME 							");
                    sbQuery.Append(" ,U.NG_ID 								");
                    sbQuery.Append(" ,U.WO_NO 								");
                    sbQuery.Append(" ,U.PART_ID 							");
                    sbQuery.Append(" ,U.PROC_ID 							");
                    sbQuery.Append(" ,U.PT_ID 								");
                    sbQuery.Append(" ,U.WORK_DATE 							");
                    sbQuery.Append(" ,U.LINK_KEY 							");
                    sbQuery.Append(" ,U.MC_CODE 							");
                    sbQuery.Append(" ,M.MC_NAME 							");
                    sbQuery.Append(" ,U.EMP_CODE 							");
                    sbQuery.Append(" ,E.EMP_NAME 							");
                    sbQuery.Append(" ,U.ACT_TYPE 							");
                    sbQuery.Append(" ,U.MASTER_CAUSE 						");
                    sbQuery.Append(" ,U.DETAIL_CAUSE 						");
                    sbQuery.Append(" ,U.QUANTITY 							");
                    sbQuery.Append(" ,U.NG_CAUSE 							");
                    sbQuery.Append(" ,U.NG_TYPE 							");
                    sbQuery.Append(" ,U.NG_CONTENTS 						");
                    sbQuery.Append(" ,U.NG_MEASURE 							");
                    sbQuery.Append(" ,U.NG_MEASURE_DATE 					");
                    sbQuery.Append(" ,U.NG_MEASURE_EMP 						");
                    sbQuery.Append(" ,NGME.EMP_NAME AS NG_MEASURE_EMP_NAME 	");
                    sbQuery.Append(" ,U.NG_STATE 							");
                    sbQuery.Append(" ,U.DRAW_NO 							");
                    sbQuery.Append(" ,U.MDFY_EMP 							");
                    sbQuery.Append(" ,U.NG_CAT                            ");
                    sbQuery.Append(" ,U.NG_OCCUR                            ");
                    sbQuery.Append(" FROM ( 								");
                    sbQuery.Append(" SELECT N.PLT_CODE 						");
                    sbQuery.Append(" ,W.PROD_CODE 							");
                    sbQuery.Append(" ,PT.PART_CODE 							");
                    sbQuery.Append(" ,NULL AS PART_NUM 						");
                    sbQuery.Append(" ,PT.PART_NAME 							");
                    sbQuery.Append(" ,W.PROC_CODE 							");
                    sbQuery.Append(" ,N.NG_ID 								");
                    sbQuery.Append(" ,W.WO_NO 								");
                    sbQuery.Append(" ,W.PART_ID 							");
                    sbQuery.Append(" ,W.PROC_ID 							");
                    sbQuery.Append(" ,NULL AS PT_ID 						");
                    sbQuery.Append(" ,A.WORK_DATE 							");
                    sbQuery.Append(" ,N.LINK_KEY 							");
                    sbQuery.Append(" ,A.MC_CODE 							");
                    sbQuery.Append(" ,A.EMP_CODE 							");
                    sbQuery.Append(" ,N.ACT_TYPE 							");
                    sbQuery.Append(" ,N.MASTER_CAUSE 						");
                    sbQuery.Append(" ,N.DETAIL_CAUSE 						");
                    sbQuery.Append(" ,N.QUANTITY 							");
                    sbQuery.Append(" ,N.NG_CAUSE 							");
                    sbQuery.Append(" ,N.NG_TYPE 							");
                    sbQuery.Append(" ,N.NG_CONTENTS 						");
                    sbQuery.Append(" ,N.NG_MEASURE 							");
                    sbQuery.Append(" ,N.NG_MEASURE_DATE 					");
                    sbQuery.Append(" ,N.NG_MEASURE_EMP 						");
                    sbQuery.Append(" ,N.NG_STATE 							");
                    sbQuery.Append(" ,PT.DRAW_NO							");
                    sbQuery.Append(" ,N.MDFY_EMP                            ");
                    sbQuery.Append(" ,N.NG_CAT                            ");
                    sbQuery.Append(" ,N.NG_OCCUR                            ");
                    sbQuery.Append(" FROM TSHP_NG N 						");
                    sbQuery.Append(" JOIN TSHP_ACTUAL A 					");
                    sbQuery.Append(" ON N.PLT_CODE = A.PLT_CODE 			");
                    sbQuery.Append(" AND N.LINK_KEY = A.ACTUAL_ID 			");
                    sbQuery.Append(" LEFT JOIN TSHP_WORKORDER W 			");
                    sbQuery.Append(" ON A.PLT_CODE = W.PLT_CODE 			");
                    sbQuery.Append(" AND A.WO_NO = W.WO_NO 					");
                    sbQuery.Append(" LEFT JOIN LSE_STD_PART PT 				");
                    sbQuery.Append(" ON W.PLT_CODE = PT.PLT_CODE 			");
                    sbQuery.Append(" AND W.PART_CODE = PT.PART_CODE 		");
                    sbQuery.Append(" WHERE W.PROD_CODE IS NOT NULL 			");
                    sbQuery.Append(" AND N.ACT_TYPE = 'W' 					");
                    sbQuery.Append(" UNION ALL 								");
                    sbQuery.Append(" SELECT N.PLT_CODE 						");
                    sbQuery.Append(" ,NULL AS PROD_CODE 					");
                    sbQuery.Append(" ,SP.PART_CODE 							");
                    sbQuery.Append(" ,SP.PART_NAME 							");
                    sbQuery.Append(" ,SP.STD_PT_NUM AS PART_NUM 			");
                    sbQuery.Append(" ,W.PROC_CODE 							");
                    sbQuery.Append(" ,N.NG_ID 								");
                    sbQuery.Append(" ,A.WO_NO 								");
                    sbQuery.Append(" ,NULL AS PART_ID 						");
                    sbQuery.Append(" ,NULL AS PROC_ID 						");
                    sbQuery.Append(" ,NULL AS PT_ID 						");
                    sbQuery.Append(" ,A.WORK_DATE 							");
                    sbQuery.Append(" ,N.LINK_KEY 							");
                    sbQuery.Append(" ,A.MC_CODE 							");
                    sbQuery.Append(" ,A.EMP_CODE 							");
                    sbQuery.Append(" ,N.ACT_TYPE 							");
                    sbQuery.Append(" ,N.MASTER_CAUSE 						");
                    sbQuery.Append(" ,N.DETAIL_CAUSE 						");
                    sbQuery.Append(" ,N.QUANTITY 							");
                    sbQuery.Append(" ,N.NG_TYPE 							");
                    sbQuery.Append(" ,N.NG_CONTENTS 						");
                    sbQuery.Append(" ,N.NG_CAUSE 							");
                    sbQuery.Append(" ,N.NG_MEASURE 							");
                    sbQuery.Append(" ,N.NG_MEASURE_DATE 					");
                    sbQuery.Append(" ,N.NG_MEASURE_EMP 						");
                    sbQuery.Append(" ,N.NG_STATE 							");
                    sbQuery.Append(" ,NULL AS DRAW_NO						");
                    sbQuery.Append(" ,N.MDFY_EMP                            ");
                    sbQuery.Append(" ,N.NG_CAT                            ");
                    sbQuery.Append(" ,N.NG_OCCUR                            ");
                    sbQuery.Append(" FROM TSHP_NG N 						");
                    sbQuery.Append(" JOIN TSHP_ACTUAL A 					");
                    sbQuery.Append(" ON N.PLT_CODE = A.PLT_CODE 			");
                    sbQuery.Append(" AND N.LINK_KEY = A.ACTUAL_ID 			");
                    sbQuery.Append(" LEFT JOIN TSHP_WORKORDER W 			");
                    sbQuery.Append(" ON A.PLT_CODE = W.PLT_CODE 			");
                    sbQuery.Append(" AND A.WO_NO = W.WO_NO 					");
                    sbQuery.Append(" LEFT JOIN LSE_STD_PART SP 				");
                    sbQuery.Append(" ON W.PLT_CODE = SP.PLT_CODE 			");
                    sbQuery.Append(" AND W.PART_CODE = SP.PART_CODE 		");
                    sbQuery.Append(" WHERE W.PROD_CODE IS NULL 				");
                    sbQuery.Append(" AND N.ACT_TYPE = 'W' 					");
                    sbQuery.Append(" UNION ALL 								");
                    sbQuery.Append(" SELECT N.PLT_CODE 						");
                    sbQuery.Append(" ,A.PROD_CODE 							");
                    sbQuery.Append(" ,PT.PART_CODE 							");
                    sbQuery.Append(" ,PT.PT_NAME AS PART_NAME 				");
                    sbQuery.Append(" ,PT.PART_NUM 							");
                    sbQuery.Append(" ,A.PROC_CODE 							");
                    sbQuery.Append(" ,N.NG_ID 								");
                    sbQuery.Append(" ,NULL AS WO_NO 						");
                    sbQuery.Append(" ,NULL AS PART_ID 						");
                    sbQuery.Append(" ,NULL AS PROC_ID 						");
                    sbQuery.Append(" ,NULL AS PT_ID 						");
                    sbQuery.Append(" ,A.WORK_DATE 							");
                    sbQuery.Append(" ,N.LINK_KEY 							");
                    sbQuery.Append(" ,A.MC_CODE 							");
                    sbQuery.Append(" ,A.EMP_CODE 							");
                    sbQuery.Append(" ,N.ACT_TYPE 							");
                    sbQuery.Append(" ,N.MASTER_CAUSE 						");
                    sbQuery.Append(" ,N.DETAIL_CAUSE 						");
                    sbQuery.Append(" ,N.QUANTITY 							");
                    sbQuery.Append(" ,N.NG_CAUSE 							");
                    sbQuery.Append(" ,N.NG_TYPE 							");
                    sbQuery.Append(" ,N.NG_CONTENTS 						");
                    sbQuery.Append(" ,N.NG_MEASURE 							");
                    sbQuery.Append(" ,N.NG_MEASURE_DATE 					");
                    sbQuery.Append(" ,N.NG_MEASURE_EMP 						");
                    sbQuery.Append(" ,N.NG_STATE 							");
                    sbQuery.Append(" ,NULL AS DRAW_NO						");
                    sbQuery.Append(" ,N.MDFY_EMP                            ");
                    sbQuery.Append(" ,N.NG_CAT                            ");
                    sbQuery.Append(" ,N.NG_OCCUR                            ");
                    sbQuery.Append(" FROM TSHP_NG N 						");
                    sbQuery.Append(" JOIN TSHP_MANACTUAL A 					");
                    sbQuery.Append(" ON N.PLT_CODE = A.PLT_CODE 			");
                    sbQuery.Append(" AND N.LINK_KEY = A.ACTUAL_ID 			");
                    sbQuery.Append(" LEFT JOIN TMAT_PARTLIST PT 			");
                    sbQuery.Append(" ON A.PLT_CODE = PT.PLT_CODE 			");
                    sbQuery.Append(" AND A.PT_ID = PT.PT_ID 				");
                    sbQuery.Append(" WHERE N.ACT_TYPE = 'M' 				");
                    sbQuery.Append(" ) AS U 								");
                    sbQuery.Append(" LEFT JOIN TORD_PRODUCT P 				");
                    sbQuery.Append(" ON U.PLT_CODE = P.PLT_CODE 			");
                    sbQuery.Append(" AND U.PROD_CODE =P.PROD_CODE 			");
                    sbQuery.Append(" AND U.PART_CODE =P.PART_CODE 			");
                    sbQuery.Append(" LEFT JOIN LSE_STD_PROC PR 				");
                    sbQuery.Append(" ON U.PLT_CODE = PR.PLT_CODE 			");
                    sbQuery.Append(" AND U.PROC_CODE = PR.PROC_CODE 		");
                    sbQuery.Append(" LEFT JOIN LSE_MACHINE M 				");
                    sbQuery.Append(" ON U.PLT_CODE = M.PLT_CODE 			");
                    sbQuery.Append(" AND U.MC_CODE = M.MC_CODE 				");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE E 				");
                    sbQuery.Append(" ON U.PLT_CODE = E.PLT_CODE 			");
                    sbQuery.Append(" AND U.EMP_CODE = E.EMP_CODE 			");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE NGME 			");
                    sbQuery.Append(" ON U.PLT_CODE = NGME.PLT_CODE 			");
                    sbQuery.Append(" AND U.NG_MEASURE_EMP = NGME.EMP_CODE 	");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder();

                        sbWhere.Append(" WHERE U.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_CODE", "U.PROD_CODE = @PROD_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@NG_ID", "U.NG_ID = @NG_ID"));
                        sbWhere.Append(UTIL.GetWhere(row, "@WO_NO", "U.WO_NO = @WO_NO"));
                        sbWhere.Append(UTIL.GetWhere(row, "@MC_CODE", "U.MC_CODE = @MC_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@MC_GROUP", "M.MC_GROUP = @MC_GROUP"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_WORK_DATE,@E_WORK_DATE", "(U.WORK_DATE BETWEEN @S_WORK_DATE AND @E_WORK_DATE)"));

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

        public static DataTable TSHP_NG_QUERY4(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("  SELECT PP.PLT_CODE	    ");
                    sbQuery.Append("   	 , TW.PROD_CODE    ");
                    sbQuery.Append("   	 , TW.PART_CODE  ");
                    sbQuery.Append("   	 , P.PROC_SEQ  ");
                    //sbQuery.Append("   	 , SUM(CASE ISNULL(P.IS_OS,0) WHEN 0 THEN (NG.QUANTITY * PP.PROC_COST) END) AS IN_COST    ");
                    //sbQuery.Append("   	 , SUM(CASE ISNULL(P.IS_OS,0) WHEN 1 THEN (NG.QUANTITY * PP.PROC_COST) END) AS OUT_COST    ");
                    //sbQuery.Append("   	 , SUM(NG.QUANTITY * PP.PROC_COST) AS NG_COST    ");
                    sbQuery.Append("   	 , (CASE ISNULL(P.IS_OS,0) WHEN 0 THEN (NG.QUANTITY * PP.PROC_COST) END) AS IN_COST    ");
                    sbQuery.Append("   	 , (CASE ISNULL(P.IS_OS,0) WHEN 1 THEN (NG.QUANTITY * PP.PROC_COST) END) AS OUT_COST    ");
                    sbQuery.Append("   	 , (NG.QUANTITY * PP.PROC_COST) AS NG_COST    ");
                    sbQuery.Append("    FROM TSHP_NG NG  ");
                    sbQuery.Append("  	INNER JOIN TSHP_DAILYWORK ACT	  ");
                    sbQuery.Append("  		ON ACT.PLT_CODE = NG.PLT_CODE  ");
                    sbQuery.Append("  		AND ACT.ACTUAL_ID = NG.LINK_KEY  ");
                    sbQuery.Append("  	 INNER JOIN TSHP_WORKORDER TW							       ");
                    sbQuery.Append("   		ON TW.PLT_CODE = ACT.PLT_CODE						       ");
                    sbQuery.Append("   		AND TW.WO_NO = ACT.WO_NO    ");
                    sbQuery.Append("  	INNER JOIN LSE_STD_PARTPROC PP									       ");
                    sbQuery.Append("   		ON PP.PLT_CODE = TW.PLT_CODE						       ");
                    sbQuery.Append("   		AND PP.PART_CODE = TW.PART_CODE						       ");
                    sbQuery.Append("   		AND PP.PROC_CODE = TW.PROC_CODE	  ");
                    sbQuery.Append("   	INNER JOIN LSE_STD_PROC P							       ");
                    sbQuery.Append("   		ON PP.PLT_CODE = P.PLT_CODE						       ");
                    sbQuery.Append("   		AND PP.PROC_CODE = P.PROC_CODE						       ");


                    StringBuilder sbWhere = new StringBuilder(" WHERE NG.PLT_CODE = " + ConnInfo.PLT_CODE);

                    for (int i = 0; i < dtParam.Rows.Count; i++)
                    {
                        if (i == 0)
                        {
                            sbWhere.Append(" AND (");
                        }

                        DataRow row = dtParam.Rows[i];
                        sbWhere.Append("(TW.PROD_CODE = " + UTIL.GetValidValue(row, "PROD_CODE").ToString()
                                + " AND TW.PART_CODE = " + UTIL.GetValidValue(row, "PART_CODE").ToString() + ") ");
                        //+ " AND P.PROC_SEQ <= " + UTIL.GetValidValue(row, "PROC_SEQ") + ") ");

                        if (i != dtParam.Rows.Count - 1)
                        {
                            sbWhere.Append(" OR ");
                        }
                    }

                    sbWhere.Append(" )");
                    //sbWhere.Append("  GROUP BY PP.PLT_CODE	    ");
                    //sbWhere.Append(" 	 , TW.PROD_CODE    ");
                    //sbWhere.Append("  	 , TW.PART_CODE  ");

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

        public static DataTable TSHP_NG_QUERY5(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("SELECT NG.PLT_CODE                 ");
                    sbQuery.Append("      , NG.MASTER_CAUSE ");
                    sbQuery.Append("      , NG.DETAIL_CAUSE ");
                    sbQuery.Append("      , SUM(ISNULL(NG.QUANTITY,0)) AS TOT_QTY ");
                    sbQuery.Append("  FROM TSHP_NG NG            ");
                    sbQuery.Append("    JOIN TSHP_DAILYWORK D            ");
                    sbQuery.Append("      ON NG.PLT_CODE = D.PLT_CODE     ");
                    sbQuery.Append("      AND NG.LINK_KEY = D.ACTUAL_ID   ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder();

                        sbWhere.Append(" WHERE NG.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@S_WORK_DATE,@E_WORK_DATE", "(D.WORK_DATE BETWEEN @S_WORK_DATE AND @E_WORK_DATE)"));
                        sbWhere.Append("  GROUP BY NG.PLT_CODE  ");
                        sbWhere.Append("  	 , NG.MASTER_CAUSE  ");
                        sbWhere.Append("  	 , NG.DETAIL_CAUSE  ");

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

        public static DataTable TSHP_NG_QUERY6(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT N.NG_ID");
                    sbQuery.Append(" , N.BALJU_NUM");
                    sbQuery.Append(" , N.BALJU_SEQ");
                    sbQuery.Append(" , N.INS_DATE");
                    sbQuery.Append(" , N.MASTER_CAUSE");
                    sbQuery.Append(" , N.DETAIL_CAUSE");
                    sbQuery.Append(" , N.NG_QTY");
                    sbQuery.Append(" , N.NG_CONTENTS");
                    sbQuery.Append(" , N.NG_CAUSE");
                    sbQuery.Append(" , N.NG_MEASURE");
                    sbQuery.Append(" , N.NG_STATE");

                    sbQuery.Append(" , ISNULL(MB.PART_CODE, WO.PART_CODE) PART_CODE");
                    sbQuery.Append(" , ISNULL(P.PART_NAME, P2.PART_NAME) PART_NAME ");
                    sbQuery.Append(" , ISNULL(MB.QTY, OB.QTY) BAL_QTY");
                    sbQuery.Append(" , ISNULL(ISNULL(MB.CHG_UNIT_COST, MB.UNIT_COST), ISNULL(OB.CHG_UNIT_COST, OB.UNIT_COST)) UNIT_COST");
                    sbQuery.Append(" , ISNULL(MBM.MVND_CODE, OBM.OVND_CODE) AS VND_CODE");
                    sbQuery.Append(" , ISNULL(MBM.REG_EMP, OBM.REG_EMP) AS BAL_EMP");
                    sbQuery.Append(" , ISNULL(MBM.BALJU_DATE, OBM.BALJU_DATE) AS BALJU_DATE");

                    sbQuery.Append(" , WO.WO_NO");
                    sbQuery.Append(" , N.MDFY_DATE");
                    sbQuery.Append(" , N.MDFY_EMP");

                    sbQuery.Append(" FROM TQCT_PURCHASE_NG N");
                    sbQuery.Append(" LEFT JOIN TMAT_BALJU MB");
                    sbQuery.Append(" ON N.PLT_CODE = MB.PLT_CODE");
                    sbQuery.Append(" AND N.BALJU_NUM = MB.BALJU_NUM");
                    sbQuery.Append(" AND N.BALJU_SEQ = MB.BALJU_SEQ");
                    sbQuery.Append(" LEFT JOIN TMAT_BALJU_MASTER MBM");
                    sbQuery.Append(" ON MB.PLT_CODE = MBM.PLT_CODE");
                    sbQuery.Append(" AND MB.BALJU_NUM = MBM.BALJU_NUM");
                    sbQuery.Append(" LEFT JOIN TOUT_PROCBALJU OB");
                    sbQuery.Append(" ON N.PLT_CODE = OB.PLT_CODE");
                    sbQuery.Append(" AND N.BALJU_NUM = OB.BALJU_NUM");
                    sbQuery.Append(" AND N.BALJU_SEQ = OB.BALJU_SEQ");
                    sbQuery.Append(" LEFT JOIN TSHP_WORKORDER WO");
                    sbQuery.Append(" ON OB.PLT_CODE = WO.PLT_CODE");
                    sbQuery.Append(" AND OB.WO_NO = WO.WO_NO");
                    sbQuery.Append(" LEFT JOIN TOUT_PROCBALJU_MASTER OBM");
                    sbQuery.Append(" ON OB.PLT_CODE = OBM.PLT_CODE");
                    sbQuery.Append(" AND OB.BALJU_NUM = OBM.BALJU_NUM");

                    sbQuery.Append(" LEFT JOIN LSE_STD_PART P   ");
                    sbQuery.Append(" ON MB.PLT_CODE = P.PLT_CODE ");
                    sbQuery.Append(" AND MB.PART_CODE = P.PART_CODE ");
                    
                    sbQuery.Append(" LEFT JOIN LSE_STD_PART P2 ");
                    sbQuery.Append(" ON WO.PLT_CODE = P2.PLT_CODE ");
                    sbQuery.Append(" AND WO.PART_CODE = P2.PART_CODE ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder();

                        sbWhere.Append(" WHERE N.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@S_INS_DATE,@E_INS_DATE", "N.INS_DATE BETWEEN @S_INS_DATE AND @E_INS_DATE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_LIKE", "P.PART_CODE LIKE '%' + @PART_LIKE + '%' OR P.PART_NAME LIKE '%' + @PART_LIKE + '%' OR P2.PART_CODE  LIKE '%' + @PART_LIKE + '%' OR P2.PART_NAME LIKE '%' + @PART_LIKE + '%' "));
                        
                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "N.DATA_FLAG = @DATA_FLAG"));
                        //sbWhere.Append(UTIL.GetWhere(row, "@MPROC_CODE", "PR.MPROC_CODE = @MPROC_CODE"));
                        //sbWhere.Append(UTIL.GetWhere(row, "@PART_CODE", "D.PART_CODE = @PART_CODE"));
                        //sbWhere.Append(UTIL.GetWhere(row, "@NG_ID", "N.NG_ID = @NG_ID"));
                        //sbWhere.Append(UTIL.GetWhere(row, "@WO_NO", "D.WO_NO = @WO_NO"));

                        //sbWhere.Append(UTIL.GetWhere(row, "@YEAR", "LEFT(D.WORK_DATE,4) = @YEAR"));

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

        public static DataTable TSHP_NG_QUERY7(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT");
                    sbQuery.Append(" N.PLT_CODE");
                    sbQuery.Append(" ,N.NG_ID");
                    sbQuery.Append(" ,N.LINK_KEY");
                    sbQuery.Append(" ,N.WK_NG_QTY");
                    sbQuery.Append(" ,N.IS_NG_REWORK");
                    sbQuery.Append(" ,W.WO_NO");
                    sbQuery.Append(" ,W.PT_ID");
                    sbQuery.Append(" ,P.PROD_PRIORITY");
                    sbQuery.Append(" ,W.PART_CODE");
                    sbQuery.Append(" ,SP.PART_NAME");
                    sbQuery.Append(" ,W.PROD_CODE");
                    sbQuery.Append(" ,P.PROD_NAME");
                    sbQuery.Append(" ,P.PROD_VERSION");
                    sbQuery.Append(" ,P.PROC_FLAG");
                    sbQuery.Append(" ,P.PROD_FLAG");
                    sbQuery.Append(" ,P.INS_YN");
                    sbQuery.Append(" ,P.SOCKET_YN");
                    sbQuery.Append(" ,P.PROD_CATEGORY");
                    sbQuery.Append(" ,P.BUSINESS_EMP");
                    sbQuery.Append(" ,P.CUSTOMER_EMP");
                    sbQuery.Append(" ,P.CUSTDESIGN_EMP");
                    sbQuery.Append(" ,P.ACTUATOR_YN");
                    sbQuery.Append(" ,P.CVND_CODE");
                    sbQuery.Append(" ,CV.VEN_NAME AS CVND_NAME");
                    sbQuery.Append(" ,P.TVND_CODE");
                    sbQuery.Append(" ,TV.BVEN_NAME AS TVND_NAME");
                    sbQuery.Append(" ,P.ORD_DATE");
                    sbQuery.Append(" ,P.DUE_DATE");
                    sbQuery.Append(" ,P.CHG_DUE_DATE");
                    sbQuery.Append(" ,P.DELIVERY_DATE");
                    sbQuery.Append(" ,P.PROBE_PIN");
                    sbQuery.Append(" ,P.PIN_TYPE");
                    sbQuery.Append(" ,P.PROD_TYPE");
                    sbQuery.Append(" ,P.PROD_QTY");
                    sbQuery.Append(" ,P.REMARK");
                    sbQuery.Append(" ,P.SCOMMENT");
                    sbQuery.Append(" ,N.NG_TYPE");
                    sbQuery.Append(" ,N.NG_CAT");
                    sbQuery.Append(" FROM TSHP_NG N");
                    sbQuery.Append(" LEFT JOIN TSHP_WORKORDER W");
                    sbQuery.Append(" ON N.PLT_CODE = W.PLT_CODE");
                    sbQuery.Append(" AND N.LINK_KEY = W.WO_NO");

                    sbQuery.Append(" LEFT JOIN TORD_PRODUCT P");
                    sbQuery.Append(" ON W.PLT_CODE = P.PLT_CODE");
                    sbQuery.Append(" AND W.PROD_CODE = P.PROD_CODE");
                    
                    sbQuery.Append(" LEFT JOIN LSE_STD_PART SP");
                    sbQuery.Append(" ON W.PLT_CODE = SP.PLT_CODE");
                    sbQuery.Append(" AND W.PART_CODE = SP.PART_CODE");
                    
                    sbQuery.Append(" LEFT JOIN TSTD_VENDOR CV");
                    sbQuery.Append(" ON P.PLT_CODE = CV.PLT_CODE");
                    sbQuery.Append(" AND P.CVND_CODE = CV.VEN_CODE");
                    
                    sbQuery.Append(" LEFT JOIN TSTD_BILL_VENDOR TV");
                    sbQuery.Append(" ON P.PLT_CODE = TV.PLT_CODE");
                    sbQuery.Append(" AND P.TVND_CODE = TV.BVEN_CODE");
                    
                    sbQuery.Append(" LEFT JOIN LSE_STD_PROC PR");
                    sbQuery.Append(" ON W.PLT_CODE = PR.PLT_CODE");
                    sbQuery.Append(" AND W.PROC_CODE = PR.PROC_CODE");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder();

                        sbWhere.Append(" WHERE N.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@NG_ID", "N.NG_ID = @NG_ID"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_NG_DATE,@E_NG_DATE", "N.NG_DATE BETWEEN @S_NG_DATE AND @E_NG_DATE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_ORD_DATE, @E_ORD_DATE", "(P.ORD_DATE BETWEEN @S_ORD_DATE AND @E_ORD_DATE)"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_DUE_DATE, @E_DUE_DATE", "(P.DUE_DATE BETWEEN @S_DUE_DATE AND @E_DUE_DATE)"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_DELIVERY_DATE, @E_DELIVERY_DATE", "(P.DELIVERY_DATE BETWEEN @S_DELIVERY_DATE AND @E_DELIVERY_DATE)"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_LIKE", "P.PROD_CODE LIKE '%' + @PROD_LIKE + '%' OR P.PROD_NAME LIKE '%' + @PROD_LIKE + '%'"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_LIKE", "P.PART_CODE LIKE '%' + @PART_LIKE + '%' OR P.PART_NAME LIKE '%' + @PART_LIKE + '%' OR P2.PART_CODE  LIKE '%' + @PART_LIKE + '%' OR P2.PART_NAME LIKE '%' + @PART_LIKE + '%' "));
                        sbWhere.Append(UTIL.GetWhere(row, "@NG_STATE", "N.NG_STATE = @NG_STATE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@NG_TYPE_CON", "N.NG_TYPE NOT IN ('N','S')"));
                        sbWhere.Append(UTIL.GetWhere(row, "@IS_NON_NG_REWORK", "N.IS_NG_REWORK IS NULL"));
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

        public static DataTable TSHP_NG_QUERY8(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED");
                    sbQuery.Append(" SELECT");
                    sbQuery.Append(" N.PLT_CODE");
                    sbQuery.Append(" ,LEFT(N.NG_DATE, 6) AS NG_MONTH");
                    sbQuery.Append(" ,N.DETAIL_CAUSE");
                    sbQuery.Append(" ,C.CD_NAME AS DETAIL_CAUSE_NAME");
                    sbQuery.Append(" ,COUNT(N.NG_ID) AS NG_CNT");
                    sbQuery.Append(" ,CW.CAM_EMP");
                    sbQuery.Append(" ,E.EMP_NAME AS CAM_EMP_NAME");
                    sbQuery.Append(" ,E.WORK_LOC");
                    sbQuery.Append(" ,C2.CD_NAME AS WORK_LOC_NAME");
                    sbQuery.Append(" FROM TSHP_NG N");
                    sbQuery.Append(" LEFT JOIN TSTD_CODES C");
                    sbQuery.Append(" ON N.PLT_CODE = C.PLT_CODE");
                    sbQuery.Append(" AND N.DETAIL_CAUSE = C.CD_CODE");
                    sbQuery.Append(" AND C.CAT_CODE = 'C401'");
                    sbQuery.Append(" LEFT JOIN TSHP_WORKORDER W");
                    sbQuery.Append(" ON N.PLT_CODE = W.PLT_CODE");
                    sbQuery.Append(" AND N.LINK_KEY = W.WO_NO");
                    sbQuery.Append(" LEFT JOIN");
                    sbQuery.Append(" ( SELECT PLT_CODE, PROD_CODE, PT_ID , PART_CODE, RE_WO_NO, CAM_EMP FROM TSHP_WORKORDER");
                    sbQuery.Append(" WHERE DATA_FLAG = '0' AND PROC_CODE = 'P-02' AND CAM_EMP IS NOT NULL");
                    sbQuery.Append(" GROUP BY PLT_CODE, PROD_CODE, PT_ID, PART_CODE, RE_WO_NO, CAM_EMP");
                    sbQuery.Append(" ) CW");
                    sbQuery.Append(" ON W.PLT_CODE = CW.PLT_CODE");
                    sbQuery.Append(" AND W.PROD_CODE = CW.PROD_CODE");
                    sbQuery.Append(" AND W.PT_ID = CW.PT_ID");
                    sbQuery.Append(" AND W.PART_CODE = CW.PART_CODE");
                    sbQuery.Append(" AND ISNULL(W.RE_WO_NO,'1') = ISNULL(CW.RE_WO_NO, '1')");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE E");
                    sbQuery.Append(" ON CW.PLT_CODE = E.PLT_CODE");
                    sbQuery.Append(" AND CW.CAM_EMP = E.EMP_CODE");
                    sbQuery.Append(" LEFT JOIN TSTD_CODES C2");
                    sbQuery.Append(" ON E.PLT_CODE = C2.PLT_CODE");
                    sbQuery.Append(" AND E.WORK_LOC = C2.CD_CODE");
                    sbQuery.Append(" AND C2.CAT_CODE = 'E001'");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder();

                        sbWhere.Append(" WHERE N.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@YEAR", "LEFT(N.NG_DATE, 4) = @YEAR"));
                        sbWhere.Append(UTIL.GetWhere(row, "@EMP_CODE", "CW.CAM_EMP = @EMP_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@WORK_LOC", "E.WORK_LOC = @WORK_LOC"));

                        sbWhere.Append(" AND N.NG_TYPE <> 'N'");
                        sbWhere.Append(" AND N.MASTER_CAUSE IN ( 'A','B','I')");
                        sbWhere.Append(" AND N.NG_DATE IS NOT NULL");
                        sbWhere.Append(" AND W.DATA_FLAG = '0'");
                        sbWhere.Append(" AND ISNULL(CW.CAM_EMP,'') <> ''");


                        sbWhere.Append(" GROUP BY N.PLT_CODE");
                        sbWhere.Append(" ,LEFT(N.NG_DATE, 6)");
                        sbWhere.Append(" ,N.DETAIL_CAUSE");
                        sbWhere.Append(" ,C.CD_NAME");
                        sbWhere.Append(" ,CW.CAM_EMP");
                        sbWhere.Append(" ,E.EMP_NAME");
                        sbWhere.Append(" ,E.WORK_LOC");
                        sbWhere.Append(" ,C2.CD_NAME");


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
        public static DataTable TSHP_NG_QUERY9(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED");
                    sbQuery.Append(" SELECT");
                    sbQuery.Append(" PLT_CODE");
                    sbQuery.Append(" ,LEFT(NG_DATE,6) AS NG_MONTH");
                    sbQuery.Append(" ,NG_TYPE");
                    sbQuery.Append(" ,SUM(QUANTITY) AS QUANTITY");
                    sbQuery.Append(" FROM TSHP_NG");
                    sbQuery.Append(" WHERE IS_NG_REWORK = '1'");
                    sbQuery.Append(" AND NG_TYPE IN ('S')");
                    sbQuery.Append(" AND LEFT(CONVERT(VARCHAR(8),NG_DATE, 112),4) = @YEAR");
                    sbQuery.Append(" GROUP BY");
                    sbQuery.Append(" PLT_CODE");
                    sbQuery.Append(" ,LEFT(NG_DATE,6)");
                    sbQuery.Append(" ,NG_TYPE");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder();

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


        public static DataTable TSHP_NG_QUERY10(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED");
                    sbQuery.Append(" SELECT");
                    sbQuery.Append(" PLT_CODE");
                    sbQuery.Append(" ,LEFT(NG_DATE, 6) AS NG_MONTH");
                    sbQuery.Append(" ,NG_CAT");
                    sbQuery.Append(" ,SUM(ISNULL(NG_COST, 0)) AS NG_COST");
                    sbQuery.Append(" FROM TSHP_NG");
                    sbQuery.Append(" WHERE NG_CAT IS NOT NULL");
                    sbQuery.Append(" AND LEFT(NG_DATE,4) = @YEAR");
                    sbQuery.Append(" GROUP BY PLT_CODE");
                    sbQuery.Append(" ,LEFT(NG_DATE, 6)");
                    sbQuery.Append(" ,NG_CAT");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder();

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


        public static DataTable TSHP_NG_QUERY11(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED");
                    sbQuery.Append(" SELECT");
                    sbQuery.Append(" N.PLT_CODE");
                    sbQuery.Append(" ,LEFT(N.NG_DATE, 6) AS NG_MONTH");
                    sbQuery.Append(" ,N.DETAIL_CAUSE");
                    sbQuery.Append(" ,C.CD_NAME AS NG_NAME");
                    sbQuery.Append(" ,NG_CAT");
                    sbQuery.Append(" ,PM.OVND_CODE");
                    sbQuery.Append(" ,V.VEN_NAME AS OVND_NAME");
                    sbQuery.Append(" ,SUM(ISNULL(QUANTITY,0)) AS QUANTITY");
                    sbQuery.Append(" ,SUM(ISNULL(NG_COST, 0)) AS NG_COST");
                    sbQuery.Append(" FROM TSHP_NG N");
                    sbQuery.Append(" LEFT JOIN TSTD_CODES C");
                    sbQuery.Append(" ON N.PLT_CODE = C.PLT_CODE");
                    sbQuery.Append(" AND N.DETAIL_CAUSE = C.CD_CODE");
                    sbQuery.Append(" AND C.CAT_CODE = 'C401'");
                    sbQuery.Append(" LEFT JOIN TOUT_PROCBALJU PO");
                    sbQuery.Append(" ON PO.PLT_CODE = N.PLT_CODE");
                    sbQuery.Append(" AND PO.WO_NO = N.LINK_KEY");
                    sbQuery.Append(" LEFT JOIN TOUT_PROCBALJU_MASTER PM");
                    sbQuery.Append(" ON PO.PLT_CODE = PM.PLT_CODE");
                    sbQuery.Append(" AND PO.BALJU_NUM = PM.BALJU_NUM");
                    sbQuery.Append(" LEFT JOIN TSTD_VENDOR V");
                    sbQuery.Append(" ON PM.PLT_CODE = V.PLT_CODE");
                    sbQuery.Append(" AND PM.OVND_CODE = V.VEN_CODE");
                    sbQuery.Append(" WHERE LEFT(N.NG_DATE, 4) = @YEAR");
                    sbQuery.Append(" AND ISNULL(N.NG_TYPE, '0') <> 'N'");
                    sbQuery.Append(" GROUP BY");
                    sbQuery.Append(" N.PLT_CODE");
                    sbQuery.Append(" ,LEFT(N.NG_DATE, 6)");
                    sbQuery.Append(" ,C.CD_NAME");
                    sbQuery.Append(" ,NG_CAT");
                    sbQuery.Append(" ,PM.OVND_CODE");
                    sbQuery.Append(" ,V.VEN_NAME");
                    sbQuery.Append(" ,N.DETAIL_CAUSE");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder();

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

        public static DataTable TSHP_NG_QUERY12(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append("  SELECT  ");
                    sbQuery.Append("  N.PLT_CODE ");
                    sbQuery.Append(" ,NE.NG_ID ");
                    sbQuery.Append(" ,N.NG_STATE ");
                    sbQuery.Append(" ,N.LINK_KEY ");
                    sbQuery.Append(" ,N.NG_DATE ");
                    sbQuery.Append(" ,N.EMP_CODE ");
                    sbQuery.Append(" ,N.BUSINESS_EMP ");
                    sbQuery.Append(" ,N.DEV_EMP ");
                    sbQuery.Append(" ,N.MC_CODE ");
                    sbQuery.Append(" ,N.MASTER_CAUSE ");
                    sbQuery.Append(" ,N.DETAIL_CAUSE ");
                    sbQuery.Append(" ,N.QUANTITY ");
                    sbQuery.Append(" ,N.WK_NG_QTY ");
                    sbQuery.Append(" ,N.ACT_TYPE ");
                    sbQuery.Append(" ,N.NG_TYPE ");
                    sbQuery.Append(" ,N.NG_CONTENTS ");
                    sbQuery.Append(" ,N.NG_CAUSE ");
                    sbQuery.Append(" ,N.NG_MEASURE ");
                    sbQuery.Append(" ,N.NG_MEASURE_DATE ");
                    sbQuery.Append(" ,N.NG_MEASURE_EMP ");
                    sbQuery.Append(" ,N.NG_CAT ");
                    sbQuery.Append(" ,N.NG_OCCUR ");
                    sbQuery.Append(" ,N.NG_OUT_COST ");
                    sbQuery.Append(" ,N.NG_MAT_COST ");
                    sbQuery.Append(" ,N.NG_LAB_COST ");
                    sbQuery.Append(" ,N.NG_DIST_COST ");
                    sbQuery.Append(" ,N.NG_PROC_COST ");
                    sbQuery.Append(" ,N.NG_COST ");
                    sbQuery.Append(" ,N.IS_NG_REWORK ");
                    sbQuery.Append(" ,N.RE_WO_NO ");
                    sbQuery.Append(" ,N.MDFY_DATE ");
                    sbQuery.Append(" ,N.MDFY_EMP ");
                    sbQuery.Append(" ,N.NG_COST_CODE ");
                    sbQuery.Append("  FROM  TSHP_NG_EMP NE   ");
                    sbQuery.Append("  LEFT JOIN TSHP_NG N  ");
                    sbQuery.Append("  ON NE.PLT_CODE = N.PLT_CODE  ");
                    sbQuery.Append("  AND NE.NG_ID = N.NG_ID  ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder();
                        sbWhere.Append(" WHERE NE.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                        sbWhere.Append(UTIL.GetWhere(row, "@NG_ID", "NE.NG_ID = @NG_ID"));
                        sbWhere.Append(UTIL.GetWhere(row, "@EMP_CODE", "NE.EMP_CODE = @EMP_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@IS_POPUP", "ISNULL(NE.IS_POPUP, 0) = @IS_POPUP"));

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

    }
}

