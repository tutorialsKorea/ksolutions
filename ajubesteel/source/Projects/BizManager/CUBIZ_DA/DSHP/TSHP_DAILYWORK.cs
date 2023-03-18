using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace DSHP
{
    public class TSHP_DAILYWORK
    {
        /// <summary>
        /// 가공반제품 재고 등록 시 STK_ID UPDATE.
        /// </summary>
        /// <param name="dtParam"></param>
        /// <param name="bizExecute"></param>
        public static void TSHP_DAILYWORK_UPD(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {

            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" UPDATE TSHP_DAILYWORK ");
                    sbQuery.Append(" SET  STK_ID = @STK_ID ");
                    sbQuery.Append(" , MDFY_DATE = GETDATE() ");
                    sbQuery.Append(" , MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append("   AND ACTUAL_ID = @ACTUAL_ID");

                    foreach (DataRow dr in dtParam.Rows)
                    {
                        bizExecute.executeUpdateQuery(sbQuery.ToString(), dr);
                    }
                }

            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        /// <summary>
        /// 가공반제품 출하 취소 시 STK_ID IS NULL UPDATE.
        /// </summary>
        /// <param name="dtParam"></param>
        /// <param name="bizExecute"></param>
        public static void TSHP_DAILYWORK_UPD2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {

            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" UPDATE TSHP_DAILYWORK ");
                    sbQuery.Append(" SET  STK_ID = NULL ");
                    sbQuery.Append(" , MDFY_DATE = GETDATE() ");
                    sbQuery.Append(" , MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append("   AND ACTUAL_ID = @ACTUAL_ID");

                    foreach (DataRow dr in dtParam.Rows)
                    {
                        bizExecute.executeUpdateQuery(sbQuery.ToString(), dr);
                    }
                }

            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }
        
    }

    public class TSHP_DAILYWORK_QUERY
    {
        /// <summary>
        /// 가공반제품 등록 시 조회용

        /// </summary>
        /// <param name="dtParam"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataTable TSHP_DAILYWORK_QUERY1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT A.ACTUAL_ID, ");
                    sbQuery.Append(" 	A.WORK_DATE,  ");
                    sbQuery.Append(" 	A.EMP_CODE,  ");
                    sbQuery.Append(" 	A.MC_CODE,  ");
                    sbQuery.Append(" 	A.PART_CODE,  ");
                    sbQuery.Append(" 	P.PART_NAME,  ");
                    sbQuery.Append(" 	P.MAT_SPEC,  ");
                    sbQuery.Append(" 	P.DRAW_NO,  ");
                    sbQuery.Append(" 	P.PART_PRODTYPE,  ");
                    sbQuery.Append(" 	A.PROC_CODE,  ");
                    sbQuery.Append(" 	PR.PROC_NAME,  ");
                    sbQuery.Append(" 	A.WO_NO,  ");
                    sbQuery.Append(" 	A.OK_QTY,  ");
                    sbQuery.Append(" 	A.NG_QTY ");
                    sbQuery.Append(" FROM TSHP_DAILYWORK A  ");
                    sbQuery.Append(" JOIN LSE_STD_PART P ");
                    sbQuery.Append(" ON A.PLT_CODE = P.PLT_CODE ");
                    sbQuery.Append("   AND A.PART_CODE = P.PART_CODE ");
                    sbQuery.Append(" JOIN LSE_STD_PROC PR ");
                    sbQuery.Append(" ON A.PLT_CODE = PR.PLT_CODE ");
                    sbQuery.Append("   AND A.PROC_CODE = PR.PROC_CODE ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE A.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                        sbWhere.Append("   AND A.IS_LAST = 1 ");
                        sbWhere.Append("   AND A.STK_ID IS NULL ");

                        sbWhere.Append(UTIL.GetWhere(row, "@START_DATE,@END_DATE", "A.WORK_DATE BETWEEN @START_DATE AND @END_DATE "));

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
        /// 가공반제품 재고 조회용 
        /// </summary>
        /// <param name="dtParam"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataTable TSHP_DAILYWORK_QUERY2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT S.STK_ID, ");
                    sbQuery.Append(" 	A.ACTUAL_ID,  ");
                    sbQuery.Append("  	A.WORK_DATE,   ");
                    sbQuery.Append("  	A.EMP_CODE,   ");
                    sbQuery.Append("  	A.MC_CODE,   ");
                    sbQuery.Append("  	A.PART_CODE,   ");
                    sbQuery.Append("  	P.PART_NAME,   ");
                    sbQuery.Append("  	P.MAT_SPEC,   ");
                    sbQuery.Append("  	P.DRAW_NO,   ");
                    sbQuery.Append("  	P.PART_PRODTYPE, ");
                    sbQuery.Append("  	A.PROC_CODE,   ");
                    sbQuery.Append("  	PR.PROC_NAME,   ");
                    sbQuery.Append("  	A.WO_NO,   ");
                    sbQuery.Append("  	A.OK_QTY,   ");
                    sbQuery.Append("  	A.NG_QTY  ");
                    sbQuery.Append("  FROM TSHP_STOCK S JOIN TSHP_DAILYWORK A   ");
                    sbQuery.Append("   ON S.PLT_CODE = A.PLT_CODE ");
                    sbQuery.Append("  AND S.STK_ID = A.STK_ID ");
                    sbQuery.Append("  JOIN LSE_STD_PART P  ");
                    sbQuery.Append("  ON A.PLT_CODE = P.PLT_CODE  ");
                    sbQuery.Append("    AND A.PART_CODE = P.PART_CODE  ");
                    sbQuery.Append("  JOIN LSE_STD_PROC PR  ");
                    sbQuery.Append("  ON A.PLT_CODE = PR.PLT_CODE  ");
                    sbQuery.Append("    AND A.PROC_CODE = PR.PROC_CODE  ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        StringBuilder sbWhere = new StringBuilder(" WHERE A.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@W_START_DATE,@W_END_DATE", "A.WORK_DATE BETWEEN @W_START_DATE AND @W_END_DATE "));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_START_DATE,@S_END_DATE", "S.STOCK_DATE BETWEEN @S_START_DATE AND @S_END_DATE "));
                        
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
        /// 재고등록일-부품별 재고수량 SUM
        /// </summary>
        /// <param name="dtParam"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataTable TSHP_DAILYWORK_QUERY3(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT S.STOCK_DATE, ");
                    sbQuery.Append(" 	P.PART_PRODTYPE,  ");
                    sbQuery.Append("   	A.PART_CODE,    ");
                    sbQuery.Append("   	P.PART_NAME,    ");
                    sbQuery.Append("   	P.MAT_SPEC,    ");
                    sbQuery.Append("   	P.DRAW_NO,    ");
                    sbQuery.Append("   	A.PROC_CODE,    ");
                    sbQuery.Append("   	PR.PROC_NAME,    ");
                    sbQuery.Append("   	SUM(A.OK_QTY) AS OK_QTY    ");
                    sbQuery.Append("   FROM TSHP_STOCK S JOIN TSHP_DAILYWORK A    ");
                    sbQuery.Append("    ON S.PLT_CODE = A.PLT_CODE  ");
                    sbQuery.Append("   AND S.STK_ID = A.STK_ID  ");
                    sbQuery.Append("   JOIN LSE_STD_PART P   ");
                    sbQuery.Append("   ON A.PLT_CODE = P.PLT_CODE   ");
                    sbQuery.Append("     AND A.PART_CODE = P.PART_CODE  ");
                    sbQuery.Append("   JOIN LSE_STD_PROC PR   ");
                    sbQuery.Append("   ON A.PLT_CODE = PR.PLT_CODE   ");
                    sbQuery.Append("     AND A.PROC_CODE = PR.PROC_CODE  ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        StringBuilder sbWhere = new StringBuilder(" WHERE S.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@W_START_DATE,@W_END_DATE ", "A.WORK_DATE BETWEEN @W_START_DATE AND @W_END_DATE "));
                        //sbWhere.Append(UTIL.GetWhere(row, "@S_START_DATE,@S_END_DATE", "S.STOCK_DATE BETWEEN @S_START_DATE AND @S_END_DATE "));

                        sbWhere.Append(" GROUP BY S.STOCK_DATE, A.PART_CODE, P.PART_NAME, P.MAT_SPEC, P.DRAW_NO, P.PART_PRODTYPE, A.PROC_CODE, PR.PROC_NAME ");

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
        /// 주간 실적 조회
        /// </summary>
        /// <param name="dtParam"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataTable TSHP_DAILYWORK_QUERY4(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT D.MC_CODE");
                    sbQuery.Append(" ,M.MC_NAME");
                    sbQuery.Append(" ,PT.PART_PRODTYPE");
                    sbQuery.Append(" ,D.PART_CODE");
                    sbQuery.Append(" ,PT.PART_NAME");
                    sbQuery.Append(" ,D.PROC_CODE");
                    sbQuery.Append(" ,PR.PROC_NAME");
                    sbQuery.Append(" ,ISNULL(MAX(W.PART_QTY),0) AS PLN_QTY");
                    sbQuery.Append(" ,SUM(D.OK_QTY) AS OK_QTY");
                    sbQuery.Append(" ,SUM(D.NG_QTY) AS NG_QTY");
                    sbQuery.Append(" ,CONVERT(DECIMAL(18,2)");
                    sbQuery.Append(" ,CASE WHEN ISNULL(MAX(W.PART_QTY),0) = 0 THEN 0 ELSE CONVERT(FLOAT,SUM(D.OK_QTY)) / CONVERT(FLOAT,ISNULL(MAX(W.PART_QTY),0)) * 100 END) AS RATE");
                    sbQuery.Append(" FROM TSHP_DAILYWORK D");
                    sbQuery.Append(" LEFT JOIN TSHP_WORKORDER W");
                    sbQuery.Append(" ON D.PLT_CODE = W.PLT_CODE");
                    sbQuery.Append(" AND D.WO_NO = W.WO_NO");
                    sbQuery.Append(" LEFT JOIN LSE_MACHINE M");
                    sbQuery.Append(" ON D.PLT_CODE = M.PLT_CODE");
                    sbQuery.Append(" AND D.MC_CODE = M.MC_CODE");
                    sbQuery.Append(" LEFT JOIN LSE_STD_PART PT");
                    sbQuery.Append(" ON D.PLT_CODE = PT.PLT_CODE");
                    sbQuery.Append(" AND D.PART_CODE = PT.PART_CODE");
                    sbQuery.Append(" LEFT JOIN LSE_STD_PROC PR");
                    sbQuery.Append(" ON D.PLT_CODE = PR.PLT_CODE");
                    sbQuery.Append(" AND D.PROC_CODE = PR.PROC_CODE"); 

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE D.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@PLN_START_DATE,@PLN_END_DATE", "D.WORK_DATE BETWEEN @PLN_START_DATE AND @PLN_END_DATE "));

                        sbWhere.Append(" GROUP BY D.MC_CODE,M.MC_NAME,PT.PART_PRODTYPE,D.PART_CODE,PT.PART_NAME,D.PROC_CODE,PR.PROC_NAME");

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

        //실적완료 가능한 리스트
        public static DataTable TSHP_DAILYWORK_QUERY5(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT  ");
                    //sbQuery.Append(" '0' AS SEL");
                    sbQuery.Append(" TD.ACTUAL_ID, ");
                    sbQuery.Append(" TD.WO_NO, ");
                    sbQuery.Append(" I.CVND_CODE, ");
                    sbQuery.Append(" V.VEN_NAME AS CVND_NAME, ");
                    sbQuery.Append(" I.ITEM_CODE, ");
                    sbQuery.Append(" TD.PROD_CODE, ");
                    sbQuery.Append(" TD.PART_CODE, ");
                    sbQuery.Append(" LSP.MAT_TYPE, ");
                    sbQuery.Append(" LSP.PART_NAME, ");
                    sbQuery.Append(" LSP.DRAW_NO, ");
                    sbQuery.Append(" LSP.MAT_SPEC, ");
                    sbQuery.Append(" LSP.MAT_SPEC1, ");
                    sbQuery.Append(" TD.PROC_CODE, ");
                    sbQuery.Append(" LSPR.PROC_NAME, ");
                    sbQuery.Append(" TD.EMP_CODE,  ");
                    sbQuery.Append(" E.EMP_NAME,  ");
                    sbQuery.Append(" TWP.STOCK_CODE, ");
                    sbQuery.Append(" TWP.STOCK_TYPE, ");
                    sbQuery.Append(" TWP.P_QTY, ");
                    sbQuery.Append(" TWP.USE_P_QTY, ");
                    sbQuery.Append(" TWP.T_QTY, ");
                    sbQuery.Append(" TWP.USE_T_QTY, ");
                    sbQuery.Append(" TWP.B_QTY, ");
                    sbQuery.Append(" TD.WORK_DATE, ");
                    sbQuery.Append(" TD.OK_QTY AS PART_QTY, ");
                    sbQuery.Append(" TD.PLN_QTY, ");
                    sbQuery.Append(" TD.ACT_START_TIME,");
                    sbQuery.Append(" TD.ACT_END_TIME ");

                    sbQuery.Append(" FROM TSHP_DAILYWORK TD ");
                    sbQuery.Append("    JOIN TSHP_WORKORDER TW ");
                    sbQuery.Append(" ON TD.PLT_CODE = TW.PLT_CODE ");
                    sbQuery.Append(" AND TD.WO_NO = TW.WO_NO ");
                    sbQuery.Append("    JOIN TSHP_WORKPLAN TWP ");
                    sbQuery.Append(" ON TWP.PLT_CODE = TW.PLT_CODE ");
                    sbQuery.Append(" AND TWP.WP_NO = TW.WP_NO ");
                    sbQuery.Append("    JOIN LSE_STD_PART LSP ");
                    sbQuery.Append(" ON TD.PLT_CODE = LSP.PLT_CODE ");
                    sbQuery.Append(" AND TD.PART_CODE = LSP.PART_CODE ");
                    sbQuery.Append("    JOIN LSE_STD_PROC LSPR ");
                    sbQuery.Append(" ON TD.PLT_CODE = LSPR.PLT_CODE ");
                    sbQuery.Append(" AND TD.PROC_CODE = LSPR.PROC_CODE ");
                    sbQuery.Append("    JOIN TORD_PRODUCT P ");
                    sbQuery.Append(" ON TWP.PLT_CODE = P.PLT_CODE ");
                    sbQuery.Append(" AND TWP.PROD_CODE = P.PROD_CODE");
                    sbQuery.Append(" AND TWP.PART_CODE = P.PART_CODE");
                    sbQuery.Append("    JOIN TORD_ITEM I ");
                    sbQuery.Append(" ON P.PLT_CODE = I.PLT_CODE ");
                    sbQuery.Append(" AND P.ITEM_CODE = I.ITEM_CODE");
                    sbQuery.Append("    JOIN TSTD_VENDOR V ");
                    sbQuery.Append(" ON I.PLT_CODE = V.PLT_CODE ");
                    sbQuery.Append(" AND I.CVND_CODE = V.VEN_CODE ");
                    sbQuery.Append("    LEFT JOIN TSTD_EMPLOYEE E ");
                    sbQuery.Append(" ON TD.PLT_CODE = E.PLT_CODE ");
                    sbQuery.Append(" AND TD.EMP_CODE = E.EMP_CODE ");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE TD.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@S_WORK_DATE,@E_WORK_DATE", "TD.WORK_DATE BETWEEN @S_WORK_DATE AND @E_WORK_DATE "));
                        sbWhere.Append(UTIL.GetWhere(row, "@PLN_START_DATE,@PLN_END_DATE", "TD.WORK_DATE BETWEEN @PLN_START_DATE AND @PLN_END_DATE "));
                        sbWhere.Append(UTIL.GetWhere(row, "@WO_NO", "TD.WO_NO = @WO_NO "));
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_CODE", "TD.PART_CODE = @PART_CODE "));
                        sbWhere.Append(UTIL.GetWhere(row, "@ACTUAL_ID", "TD.ACTUAL_ID = @ACTUAL_ID "));
                        sbWhere.Append(UTIL.GetWhere(row, "@ITEM_CODE", "P.ITEM_CODE = @ITEM_CODE "));

                        //sbWhere.Append(" AND TD.IS_LAST = 1 ");
                        sbWhere.Append(" AND TW.IS_LAST = 1 ");
                        sbWhere.Append(" AND TD.STK_ID is null ");
                        sbWhere.Append(" AND TD.OK_QTY > 0 ");

                        //재고등록 없음은 실적 완료 대상 제외
                        if (UTIL.GetValidValue(row,"IS_NOT_REG_STOCK_QTY").toStringEmpty() != "'1'")
                        {
                            sbWhere.Append(" AND ISNULL(P.STOCK_TYPE, '') <> 'S03' ");
                        }
                        
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

        //실적완료 취소 가능한 리스트
        public static DataTable TSHP_DAILYWORK_QUERY6(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT  ");
                    sbQuery.Append(" TD.PLT_CODE, ");
                    sbQuery.Append(" TD.ACTUAL_ID, ");
                    sbQuery.Append(" TD.WO_NO, ");
                    sbQuery.Append(" TS.STK_ID, ");
                    sbQuery.Append(" TI.CVND_CODE, ");
                    sbQuery.Append(" TV.VEN_NAME AS CVND_NAME, ");
                    sbQuery.Append(" TP.ITEM_CODE, ");
                    sbQuery.Append(" TD.PROD_CODE, ");
                    sbQuery.Append(" TD.PART_CODE, ");
                    sbQuery.Append(" LSP.MAT_TYPE, ");
                    sbQuery.Append(" LSP.PART_NAME, ");
                    sbQuery.Append(" LSP.DRAW_NO, ");
                    sbQuery.Append(" LSP.MAT_SPEC, ");
                    sbQuery.Append(" LSP.MAT_SPEC1, ");
                    sbQuery.Append(" TD.PROC_CODE, ");
                    sbQuery.Append(" LSPR.PROC_NAME, ");
                    sbQuery.Append(" TD.EMP_CODE,  ");
                    sbQuery.Append(" E.EMP_NAME,  ");
                    sbQuery.Append(" TS.STOCK_CODE, ");
                    sbQuery.Append(" TS.STOCK_TYPE, ");
                    sbQuery.Append(" TD.WORK_DATE, ");
                    sbQuery.Append(" TS.PART_QTY, ");
                    sbQuery.Append(" TP.PROD_UC, ");
                    sbQuery.Append(" TS.PART_QTY * ISNULL(TP.PROD_UC, 1) AS PROD_AMT, ");
                    sbQuery.Append(" TS.STOCK_DATE, ");
                    sbQuery.Append(" TS.REG_EMP, ");
                    sbQuery.Append(" TWP.P_QTY, ");
                    sbQuery.Append(" TWP.T_QTY, ");
                    sbQuery.Append(" TS.REG_EMP ");

                    sbQuery.Append(" FROM TSHP_DAILYWORK TD ");
                    sbQuery.Append("    JOIN TSHP_WORKORDER TW ");
                    sbQuery.Append(" ON TD.PLT_CODE = TW.PLT_CODE ");
                    sbQuery.Append(" AND TD.WO_NO = TW.WO_NO ");

                    sbQuery.Append("    JOIN TSHP_WORKPLAN TWP ");
                    sbQuery.Append(" ON TWP.PLT_CODE = TW.PLT_CODE ");
                    sbQuery.Append(" AND TWP.WP_NO = TW.WP_NO ");

                    sbQuery.Append("    JOIN LSE_STD_PART LSP ");
                    sbQuery.Append(" ON TD.PLT_CODE = LSP.PLT_CODE ");
                    sbQuery.Append(" AND TD.PART_CODE = LSP.PART_CODE ");

                    sbQuery.Append("    JOIN LSE_STD_PROC LSPR ");
                    sbQuery.Append(" ON TD.PLT_CODE = LSPR.PLT_CODE ");
                    sbQuery.Append(" AND TD.PROC_CODE = LSPR.PROC_CODE ");

                    sbQuery.Append("    JOIN TSHP_STOCK TS ");
                    sbQuery.Append(" ON TD.PLT_CODE = TS.PLT_CODE ");
                    sbQuery.Append(" AND TD.STK_ID = TS.STK_ID ");

                    sbQuery.Append(" JOIN TORD_PRODUCT TP ");
                    sbQuery.Append(" ON TD.PLT_CODE = TP.PLT_CODE ");
                    sbQuery.Append(" AND TD.PROD_CODE = TP.PROD_CODE ");
                    sbQuery.Append(" AND TD.PART_CODE = TP.PART_CODE ");

                    sbQuery.Append(" JOIN TORD_ITEM TI ");
                    sbQuery.Append(" ON TP.PLT_CODE = TI.PLT_CODE ");
                    sbQuery.Append(" AND TP.ITEM_CODE = TI.ITEM_CODE ");

                    sbQuery.Append(" JOIN TSTD_VENDOR TV ");
                    sbQuery.Append(" ON TI.PLT_CODE = TV.PLT_CODE ");
                    sbQuery.Append(" AND TI.CVND_CODE = TV.VEN_CODE ");

                    sbQuery.Append(" JOIN TSTD_EMPLOYEE E ");
                    sbQuery.Append(" ON TD.PLT_CODE = E.PLT_CODE ");
                    sbQuery.Append(" AND TD.EMP_CODE = E.EMP_CODE ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE TD.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@S_STOCK_DATE,@E_STOCK_DATE", "TS.STOCK_DATE BETWEEN @S_STOCK_DATE AND @E_STOCK_DATE "));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_ORD_DATE, @E_ORD_DATE", "TI.ORD_DATE BETWEEN @S_ORD_DATE AND @E_ORD_DATE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_DUE_DATE,@E_DUE_DATE", "TI.DUE_DATE BETWEEN @S_DUE_DATE AND @E_DUE_DATE "));
                        sbWhere.Append(UTIL.GetWhere(row, "@WO_NO", "TD.WO_NO = @WO_NO "));
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_CODE", "TD.PART_CODE = @PART_CODE "));
                        sbWhere.Append(UTIL.GetWhere(row, "@ACTUAL_ID", "TD.ACTUAL_ID = @ACTUAL_ID "));
                        sbWhere.Append(UTIL.GetWhere(row, "@STK_ID", "TS.STK_ID = @STK_ID "));
                        sbWhere.Append(UTIL.GetWhere(row, "@ITEM_CODE", "TP.ITEM_CODE = @ITEM_CODE "));
                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_CODE", "TP.PROD_CODE = @PROD_CODE "));
                        sbWhere.Append(UTIL.GetWhere(row, "@SHIP", "TP.PARENT_PART IS NULL "));
                        sbWhere.Append(UTIL.GetWhere(row, "@CVND_CODE", "TI.CVND_CODE = @CVND_CODE "));

                        sbWhere.Append(UTIL.GetWhere(row, "@SHIP_PROC", "TD.PROC_CODE = @SHIP_PROC "));

                        sbWhere.Append(" AND TW.IS_LAST = 1 ");
                        sbWhere.Append(" AND TD.STK_ID is not null ");
                        sbWhere.Append(" AND TS.SHIP_ID IS NULL ");
                        //sbWhere.Append(" AND (TP.PROD_QTY > 
                        //    (SELECT ISNULL(SUM(SHIP_QTY),0) FROM TORD_SHIP SHP WHERE TP.PROD_CODE = SHP.PROD_CODE AND DATA_FLAG = '0') OR PROD_STATE <> 'SH')");

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


        public static DataTable TSHP_DAILYWORK_QUERY7(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT						  ");
                    sbQuery.Append(" DW.PART_CODE				  ");
                    sbQuery.Append(" ,SUM(TS.PART_QTY) AS PART_QTY");
                    sbQuery.Append(" ,TS.STOCK_TYPE				  ");

                    sbQuery.Append(" FROM TSHP_DAILYWORK DW		  ");
                    sbQuery.Append("  JOIN TORD_PRODUCT P   ");
                    sbQuery.Append("   ON DW.PLT_CODE = P.PLT_CODE ");
                    sbQuery.Append("   AND DW.PROD_CODE = P.PROD_CODE ");
                    sbQuery.Append("   AND DW.PART_CODE = P.PART_CODE ");

                    sbQuery.Append(" LEFT JOIN TSHP_STOCK TS	  ");
                    sbQuery.Append(" ON DW.PLT_CODE = TS.PLT_CODE ");
                    sbQuery.Append(" AND DW.STK_ID = TS.STK_ID	  ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE DW.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_CODE", "DW.PROD_CODE <> @PROD_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_CODE", "DW.PART_CODE = @PART_CODE "));
                        sbWhere.Append(" AND P.PROD_STATE IN ('WK', 'PG') ");
                        sbWhere.Append(" AND DW.STK_ID IS NOT NULL");
                        sbWhere.Append(" GROUP BY DW.PART_CODE,TS.STOCK_TYPE");


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

        public static DataTable TSHP_DAILYWORK_QUERY7_1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT						  ");
                    sbQuery.Append(" DW.PART_CODE				  ");
                    sbQuery.Append(" ,SUM(TS.PART_QTY) AS PART_QTY");
                    sbQuery.Append(" ,TS.STOCK_TYPE				  ");

                    sbQuery.Append(" FROM TSHP_DAILYWORK DW		  ");
                    sbQuery.Append("  JOIN TORD_PRODUCT P   ");
                    sbQuery.Append("   ON DW.PLT_CODE = P.PLT_CODE ");
                    sbQuery.Append("   AND DW.PROD_CODE = P.PROD_CODE ");
                    sbQuery.Append("   AND DW.PART_CODE = P.PART_CODE ");

                    sbQuery.Append(" LEFT JOIN TSHP_STOCK TS	  ");
                    sbQuery.Append(" ON DW.PLT_CODE = TS.PLT_CODE ");
                    sbQuery.Append(" AND DW.STK_ID = TS.STK_ID	  ");

                    StringBuilder sbWhere = new StringBuilder(" WHERE DW.PLT_CODE = " + ConnInfo.PLT_CODE);
                    foreach (DataRow row in dtParam.Rows)
                    {
                        if (dtParam.Rows.IndexOf(row) == 0)
                        {
                            sbWhere.Append(" AND (");
                        }

                        sbWhere.Append("(DW.PROD_CODE <> " + UTIL.GetValidValue(row, "PROD_CODE").ToString()
                                + " AND DW.PART_CODE = " + UTIL.GetValidValue(row, "PART_CODE").ToString() + ") ");

                        if (dtParam.Rows.IndexOf(row) != dtParam.Rows.Count - 1)
                        {
                            sbWhere.Append(" OR ");
                        }
                    }

                    sbWhere.Append(" ) AND P.PROD_STATE IN ('WK', 'PG') ");
                    sbWhere.Append(" AND DW.STK_ID IS NOT NULL");
                    sbWhere.Append(" GROUP BY DW.PART_CODE,TS.STOCK_TYPE");
                    
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

        public static DataTable TSHP_DAILYWORK_QUERY8(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT              ");
                    sbQuery.Append(" ACT.ACT_TYPE        ");
                    sbQuery.Append(" ,ACT.ACTUAL_ID      ");
                    sbQuery.Append(" ,W.WO_TYPE          ");
                    sbQuery.Append(" ,W.WO_NO            ");

                    sbQuery.Append(" ,P.CVND_CODE    ");
                    sbQuery.Append(" ,V.VEN_NAME AS CVND_NAME  ");
                    
                    sbQuery.Append(" ,P.PROD_CODE        ");

                    sbQuery.Append(" ,SP.PART_CODE       ");
                    sbQuery.Append(" ,SP.PART_NAME       ");
                    sbQuery.Append(" ,SP.DRAW_NO       ");
                    sbQuery.Append(" ,ACT.WORK_DATE      ");
                    sbQuery.Append(" ,PRC.PROC_CODE      ");
                    sbQuery.Append(" ,PRC.PROC_NAME      ");
                    sbQuery.Append(" ,ACT.EMP_CODE       ");
                    sbQuery.Append(" ,E.EMP_NAME         ");
                    sbQuery.Append(" ,ACT.MC_CODE        ");
                    sbQuery.Append(" ,M.MC_NAME          ");
                    sbQuery.Append(" ,ACT.ACT_START_TIME ");
                    sbQuery.Append(" ,ACT.ACT_END_TIME   ");
                    sbQuery.Append(" ,ACT.MAN_TIME       ");
                    sbQuery.Append(" ,ACT.OT_TIME        ");
                    sbQuery.Append(" ,ACT.SELF_TIME      ");
                    sbQuery.Append(" ,ACT.PAUSE_TIME     ");
                    sbQuery.Append(" ,ACT.SELF_TIME + ACT.MAN_TIME + ACT.OT_TIME AS WORK_TIME ");
                    sbQuery.Append(" ,ACT.OK_QTY + ACT.NG_QTY AS WORK_QTY ");
                    sbQuery.Append(" ,ACT.OK_QTY ");
                    sbQuery.Append(" ,ACT.NG_QTY ");

                    sbQuery.Append(" FROM TSHP_DAILYWORK ACT         ");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE E       ");
                    sbQuery.Append(" ON ACT.PLT_CODE = E.PLT_CODE    ");
                    sbQuery.Append(" AND ACT.EMP_CODE = E.EMP_CODE   ");

                    sbQuery.Append(" LEFT JOIN LSE_MACHINE M         ");
                    sbQuery.Append(" ON ACT.PLT_CODE = E.PLT_CODE    ");
                    sbQuery.Append(" AND ACT.MC_CODE = M.MC_CODE     ");

                    sbQuery.Append(" LEFT JOIN TSHP_WORKORDER W      ");
                    sbQuery.Append(" ON ACT.PLT_CODE = W.PLT_CODE    ");
                    sbQuery.Append(" AND ACT.WO_NO = W.WO_NO         ");

                    sbQuery.Append(" LEFT JOIN TORD_PRODUCT P      ");
                    sbQuery.Append(" ON W.PLT_CODE = P.PLT_CODE    ");
                    sbQuery.Append(" AND W.PROD_CODE = P.PROD_CODE  ");
 
                    sbQuery.Append(" LEFT JOIN TSTD_VENDOR V      ");
                    sbQuery.Append(" ON P.PLT_CODE = V.PLT_CODE    ");
                    sbQuery.Append(" AND P.CVND_CODE = V.VEN_CODE  ");

                    sbQuery.Append(" LEFT JOIN LSE_STD_PART SP       ");
                    sbQuery.Append(" ON W.PLT_CODE = SP.PLT_CODE     ");
                    sbQuery.Append(" AND W.PART_CODE = SP.PART_CODE  ");
                    sbQuery.Append(" LEFT JOIN LSE_STD_PROC PRC      ");
                    sbQuery.Append(" ON W.PLT_CODE = PRC.PLT_CODE    ");
                    sbQuery.Append(" AND W.PROC_CODE = PRC.PROC_CODE ");
                    sbQuery.Append(" LEFT JOIN TSTD_ORG O            ");
                    sbQuery.Append(" ON E.PLT_CODE = O.PLT_CODE      ");
                    sbQuery.Append(" AND E.ORG_CODE = O.ORG_CODE     ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE ACT.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@S_WORK_DATE,@E_WORK_DATE", "ACT.WORK_DATE BETWEEN @S_WORK_DATE AND @E_WORK_DATE "));
                        sbWhere.Append(UTIL.GetWhere(row, "@EMP_CODE", "ACT.EMP_CODE = @EMP_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@ORG_CODE", "ACT.ORG_CODE = @ORG_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@ACTUAL_ID", "ACT.ACTUAL_ID = @ACTUAL_ID "));

                        sbWhere.Append(" AND ACT.PROC_STATE IN (3, 4)");

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


        public static DataTable TSHP_DAILYWORK_QUERY9(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT																										  ");
                    sbQuery.Append(" DW.PLT_CODE																								  ");
                    sbQuery.Append(" ,I.CVND_CODE																								  ");
                    sbQuery.Append(" ,V.VEN_NAME AS CVND_NAME																					  ");
                    sbQuery.Append(" ,I.ITEM_CODE																								  ");
                    sbQuery.Append(" ,SP.PART_PRODTYPE																							  ");
                    sbQuery.Append(" ,SP.MAT_TYPE																								  ");
                    sbQuery.Append(" ,SP.PART_CODE																								  ");
                    sbQuery.Append(" ,SP.PART_NAME																								  ");
                    sbQuery.Append(" ,SP.DRAW_NO																								  ");
                    sbQuery.Append(" ,DW.PLN_QTY																								  ");
                    sbQuery.Append(" , 0 AS DUMMY_PLN_QTY           ");
                    sbQuery.Append(" ,ISNULL(DW.OK_QTY,0) AS OK_QTY																				  ");
                    sbQuery.Append(" ,(SELECT SUM(ISNULL(TDW.OK_QTY,0)) FROM TSHP_DAILYWORK TDW WHERE TDW.PLT_CODE = DW.PLT_CODE 				  ");
                    sbQuery.Append("                                                            AND TDW.WO_NO = DW.WO_NO) AS TOTAL_OK_QTY		  ");
                    sbQuery.Append(" ,MAT_WEIGHT1																								  ");
                    sbQuery.Append(" ,DW.PROC_CODE																								  ");
                    sbQuery.Append(" ,SR.PROC_NAME																								  ");
                    sbQuery.Append(" ,MAT_WEIGHT1																								  ");
                    sbQuery.Append(" ,DW.MC_CODE																								  ");
                    sbQuery.Append(" ,M.MC_NAME										                                            				  ");
                    sbQuery.Append(" ,dbo.fn_GetFormattedSeq2(ISNULL(M.MC_SEQ,0)) + '. ' + M.MC_NAME AS G_MC_NAME			        						  ");
                    sbQuery.Append(" ,M.MC_SEQ																									  ");
                    sbQuery.Append(" ,DW.EMP_CODE																								  ");
                    sbQuery.Append(" ,E.EMP_NAME																								  ");
                    sbQuery.Append(" ,E.ORG_CODE																								  ");
                    sbQuery.Append(" ,E.EMP_SEQ																								  ");
                    sbQuery.Append(" ,O.ORG_SEQ																								  ");
                    sbQuery.Append(" ,dbo.fn_GetFormattedSeq2(ISNULL(O.ORG_SEQ,0)) + '. ' + O.ORG_NAME AS ORG_NAME										  ");
                    sbQuery.Append(" ,O.ORG_NAME AS G_ORG_NAME																					  ");
                    sbQuery.Append(" ,DW.ACT_START_TIME																							  ");
                    sbQuery.Append(" ,DW.ACT_END_TIME																							  ");
                    sbQuery.Append(" ,A.PRE_START_TIME																							  ");
                    sbQuery.Append(" ,A.PRE_END_TIME																							  ");
                    sbQuery.Append(" ,PPR.PROC_TIME             ");
                    sbQuery.Append(" ,CASE ISNULL(DW.OK_QTY, 0) WHEN 0 THEN 0 ELSE ((ISNULL(DW.MAN_TIME,0) + ISNULL(DW.OT_TIME,0)) / DW.OK_QTY) END AS ACT_TIME  ");

                    sbQuery.Append(" ,(ISNULL(DW.MAN_TIME,0) + ISNULL(DW.OT_TIME,0)) AS MAN_TIME												  ");
                    sbQuery.Append(" ,ISNULL(A.PRE_TIME,0) AS PRE_TIME																			  ");
                    sbQuery.Append(" ,ISNULL(ID.IDLE_TIME,0) AS IDLE_TIME																		  ");
                    sbQuery.Append(" ,(ISNULL(DW.MAN_TIME,0) + ISNULL(DW.OT_TIME,0) + ISNULL(A.PRE_TIME,0) + ISNULL(ID.IDLE_TIME,0)) AS TOTAL_TIME");
                    sbQuery.Append(" ,CONVERT(VARCHAR(5), ID.START_TIME, 114) + '~' + CONVERT(VARCHAR(5), ID.END_TIME, 114) 					  ");
                    sbQuery.Append("   + ' (' + CONVERT(VARCHAR,CONVERT(INT,ID.IDLE_TIME)) + ') ' + C.CD_NAME AS IDLE_CAUSE						  ");
                    sbQuery.Append(" 																											  ");
                    sbQuery.Append(" FROM TSHP_DAILYWORK DW																						  ");
                    sbQuery.Append("  JOIN TSHP_ACTUAL A																					  ");
                    sbQuery.Append(" ON DW.PLT_CODE = A.PLT_CODE																				  ");
                    sbQuery.Append(" AND DW.ACTUAL_ID = A.ACTUAL_ID																				  ");
                    sbQuery.Append(" 																											  ");
                    sbQuery.Append("  JOIN TORD_PRODUCT P																					  ");
                    sbQuery.Append(" ON DW.PLT_CODE = P.PLT_CODE																				  ");
                    sbQuery.Append(" AND DW.PROD_CODE = P.PROD_CODE																				  ");
                    sbQuery.Append(" AND P.PARENT_PART IS NULL																					  ");
                    sbQuery.Append(" 																											  ");
                    sbQuery.Append("  JOIN TORD_ITEM I																						  ");
                    sbQuery.Append(" ON P.PLT_CODE = I.PLT_CODE																					  ");
                    sbQuery.Append(" AND P.ITEM_CODE = I.ITEM_CODE																				  ");
                    sbQuery.Append(" 																											  ");
                    sbQuery.Append("  JOIN TSTD_VENDOR V																					  ");
                    sbQuery.Append(" ON I.PLT_CODE = V.PLT_CODE																					  ");
                    sbQuery.Append(" AND I.CVND_CODE = V.VEN_CODE																				  ");
                    sbQuery.Append(" 																											  ");
                    sbQuery.Append("  JOIN LSE_STD_PART SP																					  ");
                    sbQuery.Append(" ON DW.PLT_CODE = SP.PLT_CODE																				  ");
                    sbQuery.Append(" AND DW.PART_CODE = SP.PART_CODE																			  ");

                    sbQuery.Append(" LEFT JOIN LSE_STD_PARTPROC PPR         ");
                    sbQuery.Append("  ON DW.PLT_CODE = PPR.PLT_CODE         ");
                    sbQuery.Append("    AND DW.PART_CODE = PPR.PART_CODE        ");
                    sbQuery.Append("    AND DW.PROC_CODE = PPR.PROC_CODE        ");

                    sbQuery.Append(" LEFT JOIN LSE_MACHINE M																					  ");
                    sbQuery.Append(" ON DW.PLT_CODE = M.PLT_CODE																				  ");
                    sbQuery.Append(" AND DW.MC_CODE = M.MC_CODE																					  ");
                    sbQuery.Append(" 																											  ");
                    sbQuery.Append(" LEFT JOIN LSE_STD_PROC SR																					  ");
                    sbQuery.Append(" ON DW.PLT_CODE = SR.PLT_CODE																				  ");
                    sbQuery.Append(" AND DW.PROC_CODE = SR.PROC_CODE																			  ");
                    sbQuery.Append(" 																											  ");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE E																					  ");
                    sbQuery.Append(" ON DW.PLT_CODE = E.PLT_CODE																				  ");
                    sbQuery.Append(" AND DW.EMP_CODE = E.EMP_CODE																				  ");
                    sbQuery.Append(" 																											  ");
                    sbQuery.Append(" LEFT JOIN TSTD_ORG O																						  ");
                    sbQuery.Append(" ON E.PLT_CODE = O.PLT_CODE																					  ");
                    sbQuery.Append(" AND E.ORG_CODE = O.ORG_CODE																				  ");
                    sbQuery.Append(" 																											  ");
                    sbQuery.Append(" LEFT JOIN TSHP_IDLETIME ID																					  ");
                    sbQuery.Append(" ON DW.PLT_CODE = ID.PLT_CODE																				  ");
                    sbQuery.Append(" AND DW.ACTUAL_ID = ID.ACTUAL_ID																			  ");
                    sbQuery.Append(" 																											  ");
                    sbQuery.Append(" LEFT JOIN TSTD_CODES C																						  ");
                    sbQuery.Append(" ON ID.PLT_CODE = C.PLT_CODE																				  ");
                    sbQuery.Append(" AND ID.IDLE_CODE = C.CD_CODE																				  ");
                    sbQuery.Append(" AND C.CAT_CODE = 'C009'																					  ");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE DW.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        //sbWhere.Append(UTIL.GetWhere(row, "@WORK_DATE", "DW.WORK_DATE = @WORK_DATE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@WORK_DATE", "dbo.fn_dm_date(DW.ACT_END_TIME) = @WORK_DATE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@ORG_LIKE", "(E.ORG_CODE LIKE '%' + @ORG_LIKE + '%' OR O.ORG_NAME LIKE '%' + @ORG_LIKE + '%')"));
                        sbWhere.Append(UTIL.GetWhere(row, "@MC_LIKE", "(DW.MC_CODE LIKE '%' + @MC_LIKE + '%' OR M.MC_NAME LIKE '%' + @MC_LIKE + '%')"));

                        sbWhere.Append("ORDER BY CASE E.ORG_CODE WHEN '생산부3' THEN E.EMP_SEQ ELSE M.MC_SEQ END");

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
        /// 업무현황 페이지 - 실적조회
        /// </summary>
        /// <param name="dtParam"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataTable TSHP_DAILYWORK_QUERY9_1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT																										  ");
                    sbQuery.Append(" A.PLT_CODE																								      ");
                    sbQuery.Append(" ,A.WO_NO																								      ");
                    sbQuery.Append(" ,I.CVND_CODE																								  ");
                    sbQuery.Append(" ,V.VEN_NAME AS CVND_NAME																					  ");
                    sbQuery.Append(" ,I.ITEM_CODE																								  ");
                    sbQuery.Append(" ,SP.PART_CODE																								  ");
                    sbQuery.Append(" ,SP.PART_NAME																								  ");
                    sbQuery.Append(" ,SP.DRAW_NO																								  ");
                    sbQuery.Append(" ,DW.PLN_QTY																								  ");
                    sbQuery.Append(" ,ISNULL(A.OK_QTY,0) AS OK_QTY																				  ");
                    sbQuery.Append(" ,W.PROC_CODE																								  ");
                    sbQuery.Append(" ,SR.PROC_NAME																								  ");
                    sbQuery.Append(" ,W.MC_CODE																								      ");
                    sbQuery.Append(" ,M.MC_NAME										                                            				  ");   
                    sbQuery.Append(" ,W.EMP_CODE																								  ");
                    sbQuery.Append(" ,E.EMP_NAME																								  ");
                    sbQuery.Append(" ,E.ORG_CODE																								  ");
                    sbQuery.Append(" ,O.ORG_NAME																					              ");
                    sbQuery.Append(" ,A.ACT_START_TIME																							  ");
                    sbQuery.Append(" ,A.ACT_END_TIME																							  ");
                    
                    sbQuery.Append(" FROM TSHP_ACTUAL A																							      ");
                    sbQuery.Append("    LEFT JOIN TSHP_WORKORDER_TEST W																		      ");
                    sbQuery.Append(" ON A.PLT_CODE = W.PLT_CODE																				      ");
                    sbQuery.Append(" AND A.WO_NO = W.WO_NO																				          ");
                    sbQuery.Append(" 																											  ");
                    sbQuery.Append("   LEFT JOIN TSHP_DAILYWORK DW 																		          ");
                    sbQuery.Append(" ON A.PLT_CODE = DW.PLT_CODE																				      ");
                    sbQuery.Append(" AND A.WO_NO = DW.WO_NO																				          ");
                    sbQuery.Append(" 																											  ");
                    sbQuery.Append("   LEFT JOIN TORD_PRODUCT_TEST P 																		      ");
                    sbQuery.Append(" ON W.PLT_CODE = P.PLT_CODE																				      ");
                    sbQuery.Append(" AND W.PROD_CODE = P.PROD_CODE																				          ");
                    sbQuery.Append(" 																											  ");
                    sbQuery.Append("   LEFT JOIN TORD_ITEM I																				      ");
                    sbQuery.Append(" ON P.PLT_CODE = I.PLT_CODE																				      ");
                    sbQuery.Append(" AND P.ITEM_CODE = I.ITEM_CODE																				          ");
                    sbQuery.Append(" 																											  ");
                    sbQuery.Append("   LEFT JOIN TSTD_VENDOR V																					      ");
                    sbQuery.Append(" ON I.PLT_CODE = V.PLT_CODE																			      ");
                    sbQuery.Append(" AND I.CVND_CODE = V.VEN_CODE																				          ");
                    sbQuery.Append(" 																											  ");
                    sbQuery.Append("   LEFT JOIN LSE_STD_PART SP																					      ");
                    sbQuery.Append(" ON W.PLT_CODE = SP.PLT_CODE																				      ");
                    sbQuery.Append(" AND W.PART_CODE = SP.PART_CODE																				          ");
                    sbQuery.Append(" 																											  ");
                    sbQuery.Append("   LEFT JOIN LSE_MACHINE M																						      ");
                    sbQuery.Append(" ON W.PLT_CODE = M.PLT_CODE																				      ");
                    sbQuery.Append(" AND W.MC_CODE = M.MC_CODE																				          ");
                    sbQuery.Append(" 																											  ");
                    sbQuery.Append("   LEFT JOIN LSE_STD_PROC SR																						      ");
                    sbQuery.Append(" ON W.PLT_CODE = SR.PLT_CODE																				      ");
                    sbQuery.Append(" AND W.PROC_CODE = SR.PROC_CODE																				          ");
                    sbQuery.Append(" 																											  ");
                    sbQuery.Append("   LEFT JOIN TSTD_EMPLOYEE E																						      ");
                    sbQuery.Append(" ON W.PLT_CODE = E.PLT_CODE																				      ");
                    sbQuery.Append(" AND W.EMP_CODE = E.EMP_CODE																				          ");
                    sbQuery.Append(" 																											  ");
                    sbQuery.Append("   LEFT JOIN TSTD_ORG O																							      ");
                    sbQuery.Append(" ON E.PLT_CODE = O.PLT_CODE																					      ");
                    sbQuery.Append(" AND E.ORG_CODE = O.ORG_CODE																				          ");
                    sbQuery.Append(" 																											  ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE A.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@EMP_CODE", "A.EMP_CODE = @EMP_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_WORK_DATE,@E_WORK_DATE", "dbo.fn_dm_date(A.WORK_DATE) BETWEEN @S_WORK_DATE AND @E_WORK_DATE "));

              
                       // sbWhere.Append("GROUP BY A.PLT_CODE, A.WO_NO, I.CVND_CODE, V.VEN_NAME, I.ITEM_CODE,  SP.PART_NAME,  SP.PART_CODE,  SP.DRAW_NO, DW.PLN_QTY, A.OK_QTY, W.PROC_CODE, SR.PROC_NAME, W.MC_CODE, M.MC_NAME, W.EMP_CODE, E.EMP_NAME, E.ORG_CODE, O.ORG_NAME, A.ACT_START_TIME, A.ACT_END_TIME ");

                        sbWhere.Append("GROUP BY A.PLT_CODE,A.WO_NO, I.CVND_CODE, V.VEN_NAME, I.ITEM_CODE,  SP.PART_NAME,  SP.PART_CODE,  SP.DRAW_NO, DW.PLN_QTY, A.OK_QTY, W.PROC_CODE, SR.PROC_NAME, W.MC_CODE, M.MC_NAME, W.EMP_CODE, E.EMP_NAME, E.ORG_CODE,O.ORG_NAME, A.ACT_START_TIME, A.ACT_END_TIME ");

                        sbWhere.Append("ORDER BY A.ACT_END_TIME");

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




        public static DataTable TSHP_DAILYWORK_QUERY10(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("  SELECT D.PART_CODE,              ");
                    sbQuery.Append("	P.PART_NAME,                   ");
                    sbQuery.Append("	D.PROC_CODE,                   ");
                    sbQuery.Append("	PR.PROC_NAME,                  ");
                    sbQuery.Append("	D.ACT_START_TIME,              ");
                    sbQuery.Append("	D.ACT_END_TIME                 ");
                    sbQuery.Append("  FROM TSHP_DAILYWORK D            ");
                    sbQuery.Append("   JOIN LSE_STD_PART P             ");
                    sbQuery.Append("    ON D.PLT_CODE = P.PLT_CODE     ");
                    sbQuery.Append("	AND D.PART_CODE = P.PART_CODE  ");
                    sbQuery.Append("   JOIN LSE_STD_PROC PR            ");
                    sbQuery.Append("   ON D.PLT_CODE = PR.PLT_CODE     ");
                    sbQuery.Append("   AND D.PROC_CODE = PR.PROC_CODE  ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE D.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append("    AND D.STK_ID IS NULL");
                        sbWhere.Append("    AND D.IS_LAST = '1'");
                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_CODE", "D.PROD_CODE = @PROD_CODE"));

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

        public static DataTable TSHP_DAILYWORK_QUERY11(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("  SELECT  ");
                    sbQuery.Append("		TD.PLT_CODE  ");
                    sbQuery.Append("		, SUBSTRING(WORK_DATE,5,2) as MONTH  ");
                    sbQuery.Append("		, ISNULL(TD.OK_QTY,0) AS OK_QTY  ");
                    sbQuery.Append("		, ISNULL(NG.QUANTITY,0) AS QUANTITY  ");
                    sbQuery.Append("		, ISNULL(TW.NG_QTY,0) AS NG_QTY  ");
                    sbQuery.Append("    FROM TSHP_DAILYWORK TD  ");
                    sbQuery.Append("		LEFT JOIN TSHP_NG NG  ");
                    sbQuery.Append("  		ON TD.PLT_CODE = NG.PLT_CODE  ");
                    sbQuery.Append("  		AND TD.ACTUAL_ID = NG.LINK_KEY  ");
                    sbQuery.Append("  LEFT JOIN (SELECT PLT_CODE, PROD_CODE, PART_CODE, SUM(ISNULL(NG_QTY, 0)) NG_QTY ");
                    sbQuery.Append("       FROM TSHP_WORKORDER  ");
                    sbQuery.Append("       WHERE DATA_FLAG = 0 AND IS_LAST = 1 ");
                    sbQuery.Append("       GROUP BY  PLT_CODE, PROD_CODE, PART_CODE) TW ");
                    sbQuery.Append("  ON TD.PLT_CODE = TW.PLT_CODE      ");
                    sbQuery.Append("  AND TD.PROD_CODE = TW.PROD_CODE    ");
                    sbQuery.Append("  AND TD.PART_CODE = TW.PART_CODE    ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE TD.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                        
                        sbWhere.Append(UTIL.GetWhere(row, "@YEAR", "LEFT(WORK_DATE,4) = @YEAR"));
                        //sbWhere.Append("  GROUP BY TD.PLT_CODE, SUBSTRING(WORK_DATE,5,2)  ");
                        //sbWhere.Append("  ORDER BY SUBSTRING(WORK_DATE,5,2)  ");
                        sbWhere.Append(" AND NG_CAT = 'IN' ");
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

        public static DataTable TSHP_DAILYWORK_QUERY12(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("  SELECT  ");
                    sbQuery.Append("		TD.PLT_CODE  ");
                    sbQuery.Append("		, SUBSTRING(WORK_DATE,5,2) as MONTH  ");
                    sbQuery.Append("		, ISNULL(TD.OK_QTY,0) AS OK_QTY  ");
                    sbQuery.Append("		, ISNULL(NG.QUANTITY,0) AS QUANTITY  ");
                    sbQuery.Append("		, ISNULL(TW.NG_QTY,0) AS NG_QTY  ");
                    sbQuery.Append("    FROM TSHP_DAILYWORK TD  ");
                    sbQuery.Append("		LEFT JOIN TSHP_NG NG  ");
                    sbQuery.Append("  		ON TD.PLT_CODE = NG.PLT_CODE  ");
                    sbQuery.Append("  		AND TD.ACTUAL_ID = NG.LINK_KEY  ");
                    sbQuery.Append("  LEFT JOIN (SELECT PLT_CODE, PROD_CODE, PART_CODE, SUM(ISNULL(NG_QTY, 0)) NG_QTY ");
                    sbQuery.Append("       FROM TSHP_WORKORDER  ");
                    sbQuery.Append("       WHERE DATA_FLAG = 0 AND IS_LAST = 1 ");
                    sbQuery.Append("       GROUP BY  PLT_CODE, PROD_CODE, PART_CODE) TW ");
                    sbQuery.Append("  ON TD.PLT_CODE = TW.PLT_CODE      ");
                    sbQuery.Append("  AND TD.PROD_CODE = TW.PROD_CODE    ");
                    sbQuery.Append("  AND TD.PART_CODE = TW.PART_CODE    ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE TD.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@YEAR", "LEFT(WORK_DATE,4) = (@YEAR-1)"));
                        sbWhere.Append(" AND NG_CAT = 'IN' ");

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
