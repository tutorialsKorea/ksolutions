using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace DMAT
{
    public class TMAT_STOCK
    {
        public static DataTable TMAT_STOCK_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT PLT_CODE   ");
                    sbQuery.Append(" 	, STK_ID    ");
                    sbQuery.Append(" 	, PART_CODE    ");
                    sbQuery.Append(" 	, STOCK_LOC    ");
                    sbQuery.Append(" 	, PART_QTY     ");
                    sbQuery.Append(" 	, TOT_YPGO_AMT     ");
                    sbQuery.Append(" 	, REG_DATE    ");
                    sbQuery.Append(" 	, REG_EMP     ");
                    sbQuery.Append(" 	, MDFY_DATE    ");
                    sbQuery.Append(" 	, MDFY_EMP     ");
                    sbQuery.Append(" FROM TMAT_STOCK   ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append("   AND STK_ID = @STK_ID ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "STK_ID")) isHasColumn = false;

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

        public static DataTable TMAT_STOCK_SER2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT S.PLT_CODE   ");
                    sbQuery.Append(" 	, S.STK_ID    ");
                    sbQuery.Append(" 	, S.PART_CODE    ");
                    sbQuery.Append(" 	, S.DETAIL_PART_NAME    ");
                    sbQuery.Append(" 	, S.STOCK_LOC    ");
                    sbQuery.Append(" 	, S.PART_QTY     ");
                    sbQuery.Append(" 	, S.TOT_YPGO_AMT     ");
                    sbQuery.Append(" 	, S.REG_DATE    ");
                    sbQuery.Append(" 	, S.REG_EMP     ");
                    sbQuery.Append(" 	, S.MDFY_DATE    ");
                    sbQuery.Append(" 	, S.MDFY_EMP     ");
                    sbQuery.Append("    , P.PART_NAME ");
                    sbQuery.Append("    , ISNULL(P.CUTTING_CNT,1) AS CUTTING_CNT ");
                    sbQuery.Append(" FROM TMAT_STOCK S  ");
                    sbQuery.Append("    LEFT JOIN LSE_STD_PART P");
                    sbQuery.Append("        ON S.PLT_CODE = P.PLT_CODE");
                    sbQuery.Append("        AND S.PART_CODE = P.PART_CODE");
                    sbQuery.Append(" WHERE S.PLT_CODE = @PLT_CODE ");
                    sbQuery.Append("   AND S.PART_CODE = @PART_CODE ");
                    //sbQuery.Append("   AND S.STOCK_LOC = @STOCK_LOC ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PART_CODE")) isHasColumn = false;

                        if (!UTIL.ValidColumn(row, "STOCK_LOC"))
                        {
                            sbQuery.Append("   AND S.STOCK_LOC = '' ");
                        }
                        else
                        {
                            sbQuery.Append("   AND S.STOCK_LOC = @STOCK_LOC ");
                        }

                        if (!UTIL.ValidColumn(row, "DETAIL_PART_NAME"))
                        {
                            sbQuery.Append("   AND S.DETAIL_PART_NAME IS NULL "); 
                        }
                        else
                        {
                            sbQuery.Append("   AND S.DETAIL_PART_NAME = @DETAIL_PART_NAME ");
                        }

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

        public static DataTable TMAT_STOCK_SER3(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT PLT_CODE   ");
                    sbQuery.Append(" 	, STK_ID    ");
                    sbQuery.Append(" 	, PART_CODE    ");
                    sbQuery.Append(" 	, STOCK_LOC    ");
                    sbQuery.Append(" 	, PART_QTY     ");
                    sbQuery.Append(" 	, TOT_YPGO_AMT     ");
                    sbQuery.Append(" 	, REG_DATE    ");
                    sbQuery.Append(" 	, REG_EMP     ");
                    sbQuery.Append(" 	, MDFY_DATE    ");
                    sbQuery.Append(" 	, MDFY_EMP     ");
                    sbQuery.Append(" FROM TMAT_STOCK   ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append("   AND PART_CODE = @PART_CODE ");
                    sbQuery.Append("   AND STOCK_LOC = @MOVE_STOCK_LOC ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PART_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "MOVE_STOCK_LOC")) isHasColumn = false;

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

        public static DataTable TMAT_STOCK_SER4(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT PLT_CODE   ");
                    sbQuery.Append(" 	, STK_ID    ");
                    sbQuery.Append(" 	, PART_CODE    ");
                    sbQuery.Append(" 	, STOCK_LOC    ");
                    sbQuery.Append(" 	, PART_QTY     ");
                    sbQuery.Append(" 	, TOT_YPGO_AMT     ");
                    sbQuery.Append(" 	, REG_DATE    ");
                    sbQuery.Append(" 	, REG_EMP     ");
                    sbQuery.Append(" 	, MDFY_DATE    ");
                    sbQuery.Append(" 	, MDFY_EMP     ");
                    sbQuery.Append(" FROM TMAT_STOCK   ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append("   AND PART_CODE = @PART_CODE ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
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

        public static void TMAT_STOCK_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" INSERT INTO TMAT_STOCK             ");
                    sbQuery.Append(" (  PLT_CODE			            	  ");
                    sbQuery.Append(" 	, STK_ID    ");
                    sbQuery.Append(" 	, PART_CODE    ");
                    sbQuery.Append(" 	, DETAIL_PART_NAME    ");
                    sbQuery.Append(" 	, STOCK_LOC    ");
                    sbQuery.Append(" 	, PART_QTY     ");
                    sbQuery.Append(" 	, TOT_YPGO_AMT     ");
                    sbQuery.Append(" 	, REG_DATE    ");
                    sbQuery.Append("    , REG_EMP    ) 		                 ");
                    sbQuery.Append(" VALUES				              ");
                    sbQuery.Append(" (  @PLT_CODE			            	  ");
                    sbQuery.Append(" 	, @STK_ID    ");
                    sbQuery.Append(" 	, @PART_CODE    ");
                    sbQuery.Append(" 	, @DETAIL_PART_NAME    ");
                    sbQuery.Append(" 	, @STOCK_LOC    ");
                    sbQuery.Append(" 	, @PART_QTY     ");
                    sbQuery.Append(" 	, @TOT_YPGO_AMT     ");
                    sbQuery.Append("    , GETDATE()		                  ");
                    sbQuery.Append("    , " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" )			  ");


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

        public static void TMAT_STOCK_DEL(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TMAT_STOCK ");
                    sbQuery.Append(" SET PART_QTY = PART_QTY - @QTY ");
                    sbQuery.Append(" , STOCK_AMT = STOCK_AMT - @STOCK_AMT ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append("  AND PART_CODE = @PART_CODE ");
                    sbQuery.Append("  AND STOCK_LOC = @STOCK_LOC ");
                    sbQuery.Append("  AND STOCK_RACK = @STOCK_RACK ");


                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PART_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "STOCK_LOC")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "STOCK_RACK")) isHasColumn = false;

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

        public static void TMAT_STOCK_UPD(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TMAT_STOCK	   ");
                    sbQuery.Append(" SET PART_QTY = @PART_QTY ");
                    sbQuery.Append("   , TOT_YPGO_AMT = @TOT_YPGO_AMT ");
                    sbQuery.Append("   , MDFY_DATE = GETDATE() ");
                    sbQuery.Append("   , MDFY_EMP =  " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append("   AND STK_ID = @STK_ID     ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "STK_ID")) isHasColumn = false;

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

        public static void TMAT_STOCK_UPD2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE A																				  ");
                    sbQuery.Append(" SET A.PART_QTY = ISNULL(B.PART_QTY,0), A.TOT_YPGO_AMT = ISNULL(B.SUM_AMT,0)								  ");
                    sbQuery.Append(" FROM TMAT_STOCK A																		  ");
                    //sbQuery.Append(" 	LEFT JOIN (SELECT PLT_CODE, STK_ID, COUNT(*) AS PART_QTY, SUM(UNIT_COST) AS SUM_AMT  ");
                    //sbQuery.Append(" 				FROM TMAT_STOCK_LOT 													  ");
                    //sbQuery.Append(" 				WHERE PLT_CODE = @PLT_CODE AND STK_ID = @STK_ID AND STOCK_FLAG IN ('NE','YP') 					  ");
                    //sbQuery.Append(" 				GROUP BY PLT_CODE, STK_ID) B											  ");
                    sbQuery.Append(" 	LEFT JOIN (SELECT PLT_CODE, STK_ID, SUM(IN_QTY) - SUM(OUT_QTY) AS PART_QTY, SUM((IN_QTY * UNIT_COST)) - SUM((OUT_QTY * UNIT_COST)) AS SUM_AMT  ");
                    sbQuery.Append(" 				FROM TMAT_STOCK_LOG_DETAIL 													  ");
                    sbQuery.Append(" 				WHERE PLT_CODE = @PLT_CODE AND STK_ID = @STK_ID					  ");
                    sbQuery.Append(" 				GROUP BY PLT_CODE, STK_ID) B											  ");
                    sbQuery.Append(" 	ON A.PLT_CODE = B.PLT_CODE															  ");
                    sbQuery.Append(" 	AND A.STK_ID = B.STK_ID																  ");
                    sbQuery.Append(" WHERE A.STK_ID = @STK_ID																  ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "STK_ID")) isHasColumn = false;

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

    public class TMAT_STOCK_QUERY
    {
        public static DataTable TMAT_STOCK_QUERY1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {

                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT P.PLT_CODE");
                    sbQuery.Append(" ,S.STK_ID");
                    sbQuery.Append(" ,P.PART_CODE");
                    sbQuery.Append(" ,S.DETAIL_PART_NAME");
                    sbQuery.Append(" ,S.STOCK_LOC");
                    sbQuery.Append(" ,S.TOT_YPGO_AMT");

                    sbQuery.Append(" ,P.PART_CODE");
                    sbQuery.Append(" ,ISNULL(P.SAFE_STK_QTY,0) AS SAFE_STK_QTY");
                    sbQuery.Append(" ,ISNULL(S.PART_QTY,0) AS PART_QTY");
                    sbQuery.Append(" ,CASE WHEN ISNULL(S.PART_QTY,0) - ISNULL(P.SAFE_STK_QTY,0) <= 0 THEN '1' ELSE '0' END AS QTY_CHK");
                    sbQuery.Append(" ,0 AS OUT_QTY");
                    sbQuery.Append(" ,P.PART_NAME");
                    sbQuery.Append(" ,P.MAT_LTYPE");
                    sbQuery.Append(" ,P.MAT_MTYPE");
                    sbQuery.Append(" ,P.MAT_STYPE");
                    sbQuery.Append(" ,P.MAT_TYPE");
                    sbQuery.Append(" ,P.SUPP_VND");
                    //sbQuery.Append(",P.PART_TYPE");
                    sbQuery.Append(" ,P.PART_PRODTYPE");
                    sbQuery.Append(" ,P.DRAW_NO");
                    sbQuery.Append(" ,P.MAT_SPEC");
                    sbQuery.Append(" ,P.MAT_UNIT");
                    sbQuery.Append(" ,ISNULL(S.PART_QTY,0) AS ADJ_QTY");
                    sbQuery.Append(" ,0 AS PART_AMT");
                    sbQuery.Append(" ,0 AS MV_QTY");
                    sbQuery.Append(" ,'' AS MV_LOC");
                    sbQuery.Append(" ,0 AS DEL_QTY");
                    sbQuery.Append(" ,S.REG_DATE");
                    sbQuery.Append(" ,S.REG_EMP");
                    sbQuery.Append(" ,RE.EMP_NAME AS REG_EMP_NAME");
                    sbQuery.Append(" ,S.MDFY_DATE");
                    sbQuery.Append(" ,S.MDFY_EMP");
                    sbQuery.Append(" ,ME.EMP_NAME AS MDFY_EMP_NAME");
                    //sbQuery.Append(",P.STK_UNIT");
                    //sbQuery.Append(",LSP.PART_SAP_CODE");
                    //sbQuery.Append(",P.CHANGE_VALUE");
                    //sbQuery.Append(",S.PART_QTY/ISNULL(P.CHANGE_VALUE,1)ASMAT_QTY");
                    sbQuery.Append(" ,P.MNG_FLAG");
                    sbQuery.Append(" ,P.SCOMMENT");
                    sbQuery.Append(" FROM LSE_STD_PART P");
                    sbQuery.Append(" LEFT JOIN TMAT_STOCK S");
                    sbQuery.Append(" ON P.PLT_CODE=S.PLT_CODE");
                    sbQuery.Append(" AND P.PART_CODE=S.PART_CODE");

                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE RE");
                    sbQuery.Append(" ON S.PLT_CODE = RE.PLT_CODE");
                    sbQuery.Append(" AND S.REG_EMP = RE.EMP_CODE");

                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE ME");
                    sbQuery.Append(" ON S.PLT_CODE = ME.PLT_CODE");
                    sbQuery.Append(" AND S.MDFY_EMP = ME.EMP_CODE");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE P.DATA_FLAG = 0   ");
                        sbWhere.Append(UTIL.GetWhere(row, "@PLT_CODE", " P.PLT_CODE = @PLT_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_LIKE", " P.PART_CODE LIKE '%' + @PART_LIKE + '%' OR P.PART_NAME LIKE '%' + @PART_LIKE + '%'"));
                        sbWhere.Append(UTIL.GetWhere(row, "@SPEC_LIKE", " P.MAT_SPEC LIKE '%' + @SPEC_LIKE + '%' "));
                        sbWhere.Append(UTIL.GetWhere(row, "@DRAW_LIKE", "P.DRAW_NO LIKE '%' + @DRAW_LIKE + '%'"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_PROD_LIKE", " P.PART_PRODTYPE LIKE '%' + @PART_PROD_LIKE + '%'"));
                        sbWhere.Append(UTIL.GetWhere(row, "@STK_LOC", " S.STOCK_LOC = @STK_LOC "));
                        sbWhere.Append(UTIL.GetWhere(row, "@MAT_LTYPE", " P.MAT_LTYPE = @MAT_LTYPE "));
                        sbWhere.Append(UTIL.GetWhere(row, "@MAT_MTYPE", " P.MAT_MTYPE = @MAT_MTYPE "));
                        sbWhere.Append(UTIL.GetWhere(row, "@MAT_STYPE", " P.MAT_STYPE = @MAT_STYPE "));
                        sbWhere.Append(UTIL.GetWhere(row, "@STOCK_ZERO", " ISNULL(S.PART_QTY,0) > 0 "));
                        sbWhere.Append(UTIL.GetWhere(row, "@ALL_LOC", " S.STOCK_LOC <> '' "));
                        sbWhere.Append(UTIL.GetWhere(row, "@MNG_FLAG", " ISNULL(P.MNG_FLAG, 'N') = @MNG_FLAG "));
                        sbWhere.Append(UTIL.GetWhere(row, "@IS_MAIN", "ISNULL(P.IS_MAIN_PART, '0') = '1'  "));


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
        public static DataTable TMAT_STOCK_QUERY2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {

                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT S.PLT_CODE     ");
                    sbQuery.Append(" 	, S.STK_ID    ");
                    sbQuery.Append(" 	, S.PART_CODE    ");
                    sbQuery.Append(" 	, S.STOCK_LOC    ");
                    sbQuery.Append(" 	, S.TOT_YPGO_AMT     ");
                    sbQuery.Append(", P.PART_CODE                                 ");
                    sbQuery.Append(", ISNULL(P.SAFE_STK_QTY, 0) AS SAFE_STK_QTY   ");
                    sbQuery.Append(", ISNULL(S.PART_QTY, 0) AS PART_QTY      ");
                    sbQuery.Append(", P.PART_NAME                                 ");
                    sbQuery.Append(", P.MAT_LTYPE                                 ");
                    sbQuery.Append(", P.MAT_MTYPE                                 ");
                    sbQuery.Append(", P.MAT_STYPE                                 ");
                    sbQuery.Append(", P.MAT_TYPE                                  ");
                    //sbQuery.Append(", P.PART_TYPE                                 ");
                    sbQuery.Append(", P.PART_PRODTYPE                             ");
                    sbQuery.Append(", P.DRAW_NO                                   ");
                    sbQuery.Append(", P.MAT_SPEC                                  ");
                    sbQuery.Append(", P.MAT_UNIT                                  ");
                    //sbQuery.Append(", P.STK_UNIT                                  ");
                    //sbQuery.Append(", LSP.PART_SAP_CODE                           ");
                    //sbQuery.Append(", P.CHANGE_VALUE                           ");
                    //sbQuery.Append(", S.PART_QTY / ISNULL(P.CHANGE_VALUE,1) AS MAT_QTY   ");

                    sbQuery.Append(" FROM LSE_STD_PART P ");
                    sbQuery.Append("    INNER JOIN TMAT_STOCK S  ");
                    sbQuery.Append("        ON P.PLT_CODE = S.PLT_CODE       ");
                    sbQuery.Append("        AND P.PART_CODE = S.PART_CODE     ");

                    sbQuery.Append("    LEFT JOIN (SELECT PLT_CODE, PART_CODE, STOCK_LOC, EVENT_TIME ");
                    sbQuery.Append("                FROM TMAT_STOCK_LOG WHERE STOCK_FLAG = 'OT'  ");
                    sbQuery.Append("                AND CONVERT(VARCHAR(8),EVENT_TIME,112) > @BEFORE_DATE) TL  ");
                    sbQuery.Append("        ON S.PLT_CODE = TL.PLT_CODE       ");
                    sbQuery.Append("        AND S.PART_CODE = TL.PART_CODE     ");
                    sbQuery.Append("        AND S.STOCK_LOC = TL.STOCK_LOC     ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE P.DATA_FLAG = 0   ");
                        sbWhere.Append(UTIL.GetWhere(row, "@PLT_CODE", " P.PLT_CODE = @PLT_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_LIKE", " P.PART_CODE LIKE '%' + @PART_LIKE + '%' OR P.PART_NAME LIKE '%' + @PART_LIKE + '%'"));
                        sbWhere.Append(UTIL.GetWhere(row, "@SPEC_LIKE", " P.MAT_SPEC LIKE '%' + @SPEC_LIKE + '%' "));
                        sbWhere.Append(UTIL.GetWhere(row, "@STK_LOC", " S.STOCK_LOC = @STK_LOC "));
                        //sbWhere.Append(UTIL.GetWhere(row, "@BEFORE_DATE", " CONVERT(VARCHAR(8),EVENT_TIME,112) < @BEFORE_DATE "));
                        sbWhere.Append(" AND TL.PART_CODE IS NULL ");
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

        public static DataTable TMAT_STOCK_QUERY3(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {

                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT     ");
                    sbQuery.Append(" 	S.STOCK_LOC AS 창고코드   ");
                    sbQuery.Append(" 	, S.PART_CODE AS 품목코드   ");
                    sbQuery.Append(" 	, P.PART_NAME AS 품목명   ");
                    sbQuery.Append(" 	, STK.CD_NAME AS 자재창고    ");
                    sbQuery.Append(" 	, CAST(S.PART_QTY AS INT) AS 수량     ");

                    sbQuery.Append(" FROM (SELECT * FROM TSTD_CODES WHERE CAT_CODE = 'M005') STK ");
                    sbQuery.Append("    LEFT JOIN TMAT_STOCK S  ");
                    sbQuery.Append("        ON STK.CD_CODE = S.STOCK_LOC       ");
                    sbQuery.Append("        AND STK.PLT_CODE = S.PLT_CODE     ");
                    sbQuery.Append("    LEFT JOIN LSE_STD_PART P ");
                    sbQuery.Append("        ON S.PART_CODE = P.PART_CODE     ");
                    sbQuery.Append("        AND S.PLT_CODE = P.PLT_CODE       ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE P.DATA_FLAG = 0   ");
                        sbWhere.Append(UTIL.GetWhere(row, "@PLT_CODE", " P.PLT_CODE = @PLT_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_CODE", " P.PART_CODE = @PART_CODE"));
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

        public static DataTable TMAT_STOCK_QUERY_CREATE1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {

                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT '100' AS PLT_CODE");
                    sbQuery.Append(" , '' AS STK_ID");
                    sbQuery.Append(" ,A.PART_CODE");
                    sbQuery.Append(" ,'0' AS STOCK_LOC");
                    sbQuery.Append(" , CONVERT(DECIMAL(18,2), STOCK_QTY) AS PART_QTY");
                    sbQuery.Append(" , (CONVERT(DECIMAL(18,2), ISNULL(CONVERT(DECIMAL(18,2), STOCK_QTY), 0) * ISNULL(CONVERT(DECIMAL(18,2), COST),0))) AS TOT_YPGO_AMT");
                    sbQuery.Append(" ,GETDATE() AS REG_DATE");
                    sbQuery.Append(" ,'ACTIVE' AS REG_EMP");
                    sbQuery.Append(" ,NULL AS MDFY_DATE");
                    sbQuery.Append(" ,NULL AS MDFY_EMP");
                    sbQuery.Append(" FROM 재고업로드 A");
                    sbQuery.Append(" LEFT JOIN TMAT_STOCK B");
                    sbQuery.Append(" ON A.PART_CODE = B.PART_CODE");
                    sbQuery.Append(" WHERE B.PART_CODE IS NULL");
                    sbQuery.Append(" AND CONVERT(DECIMAL(18,2), STOCK_QTY) > 0");
                    sbQuery.Append(" AND LEN(A.PART_CODE) < 31");
                    sbQuery.Append(" ORDER BY A.PART_CODE DESC");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString()).Copy();

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

        public static DataTable TMAT_STOCK_QUERY_CREATE2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {

                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT");
                    sbQuery.Append(" '100' AS PLT_CODE");
                    sbQuery.Append(" ,A.PART_CODE");
                    sbQuery.Append(" ,GETDATE() AS EVENT_TIME");
                    sbQuery.Append(" ,'NE' AS GUBUN");
                    sbQuery.Append(" ,'0' AS STOCK_LOC");
                    sbQuery.Append(" ,'NE' AS STOCK_FLAG");
                    sbQuery.Append(" ,0 AS PREV_QTY");
                    sbQuery.Append(" ,0 AS PREV_AMT");
                    sbQuery.Append(" , CONVERT(DECIMAL(18,2), STOCK_QTY) AS IN_QTY");
                    sbQuery.Append(" , CONVERT(DECIMAL(18,2), COST) AS IN_COST");
                    sbQuery.Append(" , (CONVERT(DECIMAL(18,2), ISNULL(CONVERT(DECIMAL(18,2), STOCK_QTY), 0) * ISNULL(CONVERT(DECIMAL(18,2), COST),0))) AS IN_AMT");
                    sbQuery.Append(" ,0 AS OUT_QTY");
                    sbQuery.Append(" ,0 AS OUT_COST");
                    sbQuery.Append(" ,0 AS OUT_AMT");
                    sbQuery.Append(" ,CONVERT(DECIMAL(18,2), STOCK_QTY) AS NEXT_QTY");
                    sbQuery.Append(" ,(CONVERT(DECIMAL(18,2), ISNULL(CONVERT(DECIMAL(18,2), STOCK_QTY), 0) * ISNULL(CONVERT(DECIMAL(18,2), COST),0))) AS NEXT_AMT");
                    sbQuery.Append(" ,NULL AS STOCK_TYPE");
                    sbQuery.Append(" ,NULL AS STOCK_CODE");
                    sbQuery.Append(" ,'' AS STK_ID");
                    sbQuery.Append(" ,'ACTIVE' AS REG_EMP");
                    sbQuery.Append(" ,NULL AS SCOMMENT");
                    sbQuery.Append(" FROM 재고업로드 A");
                    sbQuery.Append(" LEFT JOIN TMAT_STOCK B");
                    sbQuery.Append(" ON A.PART_CODE = B.PART_CODE");
                    sbQuery.Append(" WHERE B.PART_CODE IS NULL");
                    sbQuery.Append(" AND CONVERT(DECIMAL(18,2), STOCK_QTY) > 0");
                    sbQuery.Append(" AND LEN(A.PART_CODE) < 31");
                    sbQuery.Append(" ORDER BY A.PART_CODE DESC");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString()).Copy();

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
