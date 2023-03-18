using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace DMAT
{
    public class TMAT_STOCK_LOG
    {
       
        


        public static object TMAT_STOCK_LOG_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" INSERT INTO TMAT_STOCK_LOG ");
                    sbQuery.Append(" (PLT_CODE,     ");
                    sbQuery.Append(" PART_CODE,  ");
                    sbQuery.Append(" DETAIL_PART_NAME,  ");
                    sbQuery.Append(" EVENT_TIME,  ");
                    sbQuery.Append(" GUBUN,  ");
                    sbQuery.Append(" STOCK_LOC,  ");
                    sbQuery.Append(" STOCK_FLAG,  ");
                    sbQuery.Append(" PREV_QTY,  ");
                    sbQuery.Append(" PREV_AMT,  ");
                    sbQuery.Append(" IN_QTY,  ");
                    sbQuery.Append(" IN_COST,  ");
                    sbQuery.Append(" IN_AMT,  ");
                    sbQuery.Append(" OUT_QTY,  ");
                    sbQuery.Append(" OUT_COST,  ");
                    sbQuery.Append(" OUT_AMT,  ");
                    sbQuery.Append(" NEXT_QTY,  ");
                    sbQuery.Append(" NEXT_AMT,  ");
                    sbQuery.Append(" STK_ID,  ");
                    sbQuery.Append(" REG_EMP,  ");
                    sbQuery.Append(" PROD_CODE,  ");
                    sbQuery.Append(" CVND_CODE,  ");
                    sbQuery.Append(" SCOMMENT) ");
                    sbQuery.Append(" VALUES ");
                    sbQuery.Append(" (@PLT_CODE ");
                    sbQuery.Append(" , @PART_CODE ");
                    sbQuery.Append(" , @DETAIL_PART_NAME  ");
                    sbQuery.Append(" , GETDATE() ");
                    sbQuery.Append(" , @GUBUN  ");
                    sbQuery.Append(" , @STOCK_LOC  ");
                    sbQuery.Append(" , @STOCK_FLAG  ");
                    sbQuery.Append(" , @PREV_QTY  ");
                    sbQuery.Append(" , @PREV_AMT  ");
                    sbQuery.Append(" , @IN_QTY  ");
                    sbQuery.Append(" , @IN_COST  ");
                    sbQuery.Append(" , @IN_AMT  ");
                    sbQuery.Append(" , @OUT_QTY  ");
                    sbQuery.Append(" , @OUT_COST  ");
                    sbQuery.Append(" , @OUT_AMT  ");
                    sbQuery.Append(" , @NEXT_QTY  ");
                    sbQuery.Append(" , @NEXT_AMT  ");
                    sbQuery.Append(" , @STK_ID  ");
                    sbQuery.Append(" , @REG_EMP ");
                    sbQuery.Append(" , @PROD_CODE  ");
                    sbQuery.Append(" , @CVND_CODE  ");
                    sbQuery.Append(" , @SCOMMENT); ");
                    sbQuery.Append(" SELECT CAST(SCOPE_IDENTITY() AS INT);             ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        return bizExecute.executeScalarQuery(sbQuery.ToString(), row);
                        //bizExecute.executeInsertQuery(sbQuery.ToString(), row);
                    }
                }
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
            return null;
        }

        public static void TMAT_STOCK_LOG_INS2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" INSERT INTO TMAT_STOCK_LOG ");
                    sbQuery.Append(" (PLT_CODE,     ");
                    sbQuery.Append(" PART_CODE,  ");
                    sbQuery.Append(" EVENT_TIME,  ");
                    sbQuery.Append(" GUBUN,  ");
                    sbQuery.Append(" PREV_QTY,  ");
                    sbQuery.Append(" IN_QTY,  ");
                    sbQuery.Append(" OUT_QTY,  ");
                    sbQuery.Append(" NEXT_QTY,  ");
                    sbQuery.Append(" STOCK_TYPE,  ");
                    sbQuery.Append(" STOCK_CODE,  ");
                    sbQuery.Append(" STK_ID,  ");
                    sbQuery.Append(" REG_EMP,  ");
                    sbQuery.Append(" SCOMMENT) ");
                    sbQuery.Append(" VALUES ");
                    sbQuery.Append(" (@PLT_CODE ");
                    sbQuery.Append(" , @PART_CODE ");
                    sbQuery.Append(" , @EVENT_TIME ");
                    sbQuery.Append(" , @GUBUN ");
                    sbQuery.Append(" , @PREV_QTY ");
                    sbQuery.Append(" , @IN_QTY ");
                    sbQuery.Append(" , @OUT_QTY ");
                    sbQuery.Append(" , @NEXT_QTY ");
                    sbQuery.Append(" , @STOCK_TYPE ");
                    sbQuery.Append(" , @STOCK_CODE ");
                    sbQuery.Append(" , @STK_ID ");
                    sbQuery.Append(" , @REG_EMP ");
                    sbQuery.Append(" , @SCOMMENT) ");

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


        public static void TMAT_STOCK_LOG_INS3(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" INSERT INTO TMAT_STOCK_LOG ");
                    sbQuery.Append(" (PLT_CODE,     ");
                    sbQuery.Append(" PART_CODE,  ");
                    sbQuery.Append(" EVENT_TIME,  ");
                    sbQuery.Append(" GUBUN,  ");
                    sbQuery.Append(" PREV_QTY,  ");
                    sbQuery.Append(" IN_QTY,  ");
                    sbQuery.Append(" OUT_QTY,  ");
                    sbQuery.Append(" NEXT_QTY,  ");
                    sbQuery.Append(" STOCK_TYPE,  ");
                    sbQuery.Append(" STOCK_CODE,  ");
                    sbQuery.Append(" STK_ID,  ");
                    sbQuery.Append(" REG_EMP,  ");
                    sbQuery.Append(" SCOMMENT) ");
                    sbQuery.Append(" VALUES ");
                    sbQuery.Append(" (@PLT_CODE ");
                    sbQuery.Append(" , @PART_CODE ");
                    sbQuery.Append(" , GETDATE() ");
                    sbQuery.Append(" , @GUBUN ");
                    sbQuery.Append(" , @PREV_QTY ");
                    sbQuery.Append(" , @IN_QTY ");
                    sbQuery.Append(" , @OUT_QTY ");
                    sbQuery.Append(" , @NEXT_QTY ");
                    sbQuery.Append(" , @STOCK_TYPE ");
                    sbQuery.Append(" , @STOCK_CODE ");
                    sbQuery.Append(" , @STK_ID ");
                    sbQuery.Append(" , @REG_EMP ");
                    sbQuery.Append(" , @SCOMMENT) ");

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

        public static void TMAT_STOCK_LOG_UPD(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TMAT_STOCK_LOG ");
                    sbQuery.Append(" SET PREV_QTY = @PREV_QTY ");
		            sbQuery.Append("    , NEXT_QTY = @PREV_QTY + ISNULL(IN_QTY, 0) - ISNULL(OUT_QTY, 0) " );
                    sbQuery.Append("    WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("    AND PART_CODE = @PART_CODE " );
                    sbQuery.Append("    AND EVENT_TIME = @EVENT_TIME ");
	
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

        public static void TMAT_STOCK_LOG_UPD2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TMAT_STOCK_LOG ");
                    sbQuery.Append(" SET SCOMMENT = @SCOMMENT ");
                    sbQuery.Append(" , MDFY_DATE = GETDATE() ");
                    sbQuery.Append(" ,MDFY_EMP ='" + ConnInfo.UserID + "'");
                    sbQuery.Append("    WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("    AND UID = @UID ");

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
    }


    public class TMAT_STOCK_LOG_QUERY
    {

        public static DataTable TMAT_STOCK_LOG_QUERY1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {

                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT  L.PLT_CODE   ");
                    sbQuery.Append(" , L.PART_CODE  ");
                    sbQuery.Append(" , L.DETAIL_PART_NAME  ");
                    sbQuery.Append(" , L.EVENT_TIME  ");
                    sbQuery.Append(" , L.GUBUN  ");
                    sbQuery.Append(" , L.PREV_QTY  ");
                    sbQuery.Append(" , L.PREV_AMT  ");
                    sbQuery.Append(" , L.STOCK_LOC  ");
                    //sbQuery.Append(" , L.STOCK_FLAG  ");
                    sbQuery.Append(" , CASE WHEN ISNULL(L.GUBUN, '') = 'OC' THEN 'OC' ELSE L.STOCK_FLAG END AS STOCK_FLAG  ");
                    sbQuery.Append(" , L.IN_QTY  ");
                    sbQuery.Append(" , L.IN_COST  ");
                    sbQuery.Append(" , L.IN_AMT  ");
                    sbQuery.Append(" , L.OUT_QTY  ");
                    sbQuery.Append(" , L.OUT_COST  ");
                    sbQuery.Append(" , L.OUT_AMT  ");
                    sbQuery.Append(" , L.NEXT_QTY  ");
                    sbQuery.Append(" , L.NEXT_AMT  ");
                    sbQuery.Append(" , L.STK_ID  ");
                    sbQuery.Append(" , L.REG_EMP  ");
                    sbQuery.Append(" 	, L.REG_EMP            ");
                    sbQuery.Append("  , E.EMP_NAME AS REG_EMP_NAME ");
                    sbQuery.Append(" 	, L.SCOMMENT        ");
                    sbQuery.Append(" 	, L.PROD_CODE        ");
                    sbQuery.Append(" 	, P.PART_NAME        ");
                    sbQuery.Append(" 	, P.DRAW_NO        ");
                    sbQuery.Append(" 	, P.MAT_LTYPE         ");
                    sbQuery.Append(" 	, P.MAT_MTYPE        ");
                    sbQuery.Append(" 	, P.MAT_STYPE         ");
                    sbQuery.Append(" 	, P.MAT_TYPE          ");
                    sbQuery.Append(" 	, P.PART_PRODTYPE   ");
                    sbQuery.Append(" 	, P.MAT_SPEC1   ");
                    sbQuery.Append(" 	, P.MAT_SPEC   ");
                    sbQuery.Append(" 	, P.MAT_UNIT   ");
                    sbQuery.Append(" 	, P.MNG_FLAG   ");

                    sbQuery.Append(" 	, L.CVND_CODE   ");
                    sbQuery.Append(" 	, V.VEN_NAME AS CVND_NAME   ");

                    sbQuery.Append(" , L.UID  ");
                    sbQuery.Append(" FROM TMAT_STOCK_LOG L JOIN LSE_STD_PART P      ");
                    sbQuery.Append("   ON L.PLT_CODE = P.PLT_CODE     ");
                    sbQuery.Append("   AND L.PART_CODE = P.PART_CODE      ");
                    sbQuery.Append("  LEFT JOIN TSTD_EMPLOYEE E  ");
                    sbQuery.Append("   ON L.PLT_CODE = E.PLT_CODE ");
                    sbQuery.Append("   AND L.REG_EMP = E.EMP_CODE ");

                    sbQuery.Append("  LEFT JOIN TSTD_VENDOR V  ");
                    sbQuery.Append("   ON L.PLT_CODE = V.PLT_CODE ");
                    sbQuery.Append("   AND L.CVND_CODE = V.VEN_CODE ");

                    //sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE  ");
                    //sbQuery.Append(" AND PART_CODE = @PART_CODE  ");
                    //sbQuery.Append(" AND STK_ID = @STK_ID  ");
                    //sbQuery.Append(" AND EVENT_TIME = (SELECT MAX(EVENT_TIME) FROM TMAT_STOCK_LOG WHERE PLT_CODE = @PLT_CODE AND PART_CODE = @PART_CODE )  ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        StringBuilder sbWhere = new StringBuilder(" WHERE P.DATA_FLAG = 0   ");

                        sbWhere.Append(UTIL.GetWhere(row, "@PLT_CODE", " P.PLT_CODE = @PLT_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_LIKE", " P.PART_CODE LIKE '%' + @PART_LIKE + '%' OR P.PART_NAME LIKE '%' + @PART_LIKE + '%'"));
                        sbWhere.Append(UTIL.GetWhere(row, "@DRAW_LIKE", " P.DRAW_NO LIKE '%' + @DRAW_LIKE + '%' "));
                        sbWhere.Append(UTIL.GetWhere(row, "@SPEC_LIKE", " P.MAT_SPEC LIKE '%' + @SPEC_LIKE + '%' "));
                        sbWhere.Append(UTIL.GetWhere(row, "@STOCK_LOC", " L.STOCK_LOC = @STOCK_LOC "));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_DATE,@E_DATE", " dbo.fn_dm_date(L.EVENT_TIME) BETWEEN @S_DATE AND @E_DATE "));
                        sbWhere.Append(UTIL.GetWhere(row, "@MNG_FLAG", " P.MNG_FLAG = @MNG_FLAG "));


                        sbWhere.Append(UTIL.GetWhere(row, "@UID", " L.UID = @UID"));

                        sbWhere.Append(" ORDER BY L.EVENT_TIME DESC");

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

        public static DataTable TMAT_STOCK_LOG_QUERY2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {

                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT  PLT_CODE   ");
                    sbQuery.Append(" , PART_CODE  ");
                    sbQuery.Append(" , EVENT_TIME  ");
                    sbQuery.Append(" , STOCK_FLAG  ");
                    sbQuery.Append(" , PREV_QTY  ");

                    sbQuery.Append(" , PREV_AMT  ");
                    sbQuery.Append(" , IN_QTY  ");
                    sbQuery.Append(" , IN_COST  ");
                    sbQuery.Append(" , IN_AMT  ");
                    sbQuery.Append(" , OUT_QTY  ");
                    sbQuery.Append(" , OUT_COST  ");
                    sbQuery.Append(" , OUT_AMT  ");
                    sbQuery.Append(" , NEXT_QTY  ");

                    sbQuery.Append(" , NEXT_AMT  ");
                    sbQuery.Append(" , REG_EMP  ");
                    sbQuery.Append(" FROM TMAT_STOCK_LOG  ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append(" AND PART_CODE = @PART_CODE  ");
                    sbQuery.Append(" AND ISNULL(DETAIL_PART_NAME, 'N') = @DETAIL_PART_NAME  ");
                    sbQuery.Append(" AND STOCK_LOC = @STOCK_LOC  ");
                    sbQuery.Append(" AND EVENT_TIME = (SELECT MAX(EVENT_TIME) FROM TMAT_STOCK_LOG WHERE PLT_CODE = @PLT_CODE AND PART_CODE = @PART_CODE AND ISNULL(DETAIL_PART_NAME, 'N') = @DETAIL_PART_NAME  AND STOCK_LOC = @STOCK_LOC )  ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString(), row).Copy();

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

        public static DataTable TMAT_STOCK_LOG_QUERY3(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {

                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT L.PLT_CODE    ");
                    sbQuery.Append(" 	, L.STOCK_LOC         ");
                    sbQuery.Append(" FROM TMAT_STOCK_LOG L JOIN LSE_STD_PART P      ");
                    sbQuery.Append("   ON L.PLT_CODE = P.PLT_CODE     ");
                    sbQuery.Append("   AND L.PART_CODE = P.PART_CODE      ");
                    sbQuery.Append("  LEFT JOIN TSTD_EMPLOYEE E  ");
                    sbQuery.Append("   ON L.PLT_CODE = E.PLT_CODE ");
                    sbQuery.Append("   AND L.REG_EMP = E.EMP_CODE ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        StringBuilder sbWhere = new StringBuilder(" WHERE P.DATA_FLAG = 0   ");

                        sbWhere.Append(UTIL.GetWhere(row, "@PLT_CODE", " P.PLT_CODE = @PLT_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_LIKE", " P.PART_CODE LIKE '%' + @PART_LIKE + '%' OR P.PART_NAME LIKE '%' + @PART_LIKE + '%'"));
                        sbWhere.Append(UTIL.GetWhere(row, "@DRAW_LIKE", " P.DRAW_NO LIKE '%' + @DRAW_LIKE + '%' "));
                        sbWhere.Append(UTIL.GetWhere(row, "@SPEC_LIKE", " P.MAT_SPEC LIKE '%' + @SPEC_LIKE + '%' "));
                        sbWhere.Append(UTIL.GetWhere(row, "@STOCK_LOC", " L.STOCK_LOC = @STOCK_LOC "));
                        //sbWhere.Append(UTIL.GetWhere(row, "@S_DATE,@E_DATE", " dbo.fn_dm_date(L.EVENT_TIME) BETWEEN @S_DATE AND @E_DATE "));
                        sbWhere.Append(UTIL.GetWhere(row, "@MNG_FLAG", " P.MNG_FLAG = @MNG_FLAG"));
                        sbWhere.Append(" GROUP BY L.PLT_CODE, L.STOCK_LOC");

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

        public static DataTable TMAT_STOCK_LOG_QUERY4(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {

                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT L.PLT_CODE    ");
                    sbQuery.Append(" 	, L.PART_CODE         ");
                    sbQuery.Append(" 	, L.EVENT_TIME        ");
                    sbQuery.Append(" 	, L.GUBUN              ");
                    sbQuery.Append(" 	, L.PREV_QTY           ");
                    sbQuery.Append(" 	, L.IN_QTY              ");
                    sbQuery.Append(" 	, L.OUT_QTY            ");
                    sbQuery.Append(" 	, L.NEXT_QTY          ");
                    sbQuery.Append(" 	, L.STOCK_TYPE        ");
                    sbQuery.Append(" 	, L.STOCK_CODE       ");
                    sbQuery.Append(" 	, L.REG_EMP            ");
                    sbQuery.Append("  , E.EMP_NAME AS REG_EMP_NAME ");
                    sbQuery.Append(" 	, L.SCOMMENT        ");
                    sbQuery.Append(" 	, P.PART_NAME        ");
                    sbQuery.Append(" 	, P.DRAW_NO        ");
                    sbQuery.Append(" 	, P.MAT_LTYPE         ");
                    sbQuery.Append(" 	, P.MAT_MTYPE        ");
                    sbQuery.Append(" 	, P.MAT_STYPE         ");
                    sbQuery.Append(" 	, P.MAT_TYPE          ");
                    sbQuery.Append(" 	, P.PART_PRODTYPE   ");
                    sbQuery.Append(" 	, P.MAT_SPEC1   ");
                    sbQuery.Append(" 	, P.MAT_SPEC   ");
                    sbQuery.Append(" FROM TMAT_STOCK_LOG L JOIN LSE_STD_PART P      ");
                    sbQuery.Append("   ON L.PLT_CODE = P.PLT_CODE     ");
                    sbQuery.Append("   AND L.PART_CODE = P.PART_CODE      ");
                    sbQuery.Append("  JOIN TSTD_STOCK_GRP TSG           ");
                    sbQuery.Append("  	ON P.PLT_CODE = TSG.PLT_CODE    ");
                    sbQuery.Append("  	AND P.PART_CODE = TSG.PART_CODE ");
                    sbQuery.Append("  LEFT JOIN TSTD_EMPLOYEE E  ");
                    sbQuery.Append("   ON L.PLT_CODE = E.PLT_CODE ");
                    sbQuery.Append("   AND L.REG_EMP = E.EMP_CODE ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder();

                        sbWhere.Append(" WHERE L.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@STK_GROUP", "TSG.STK_GROUP = @STK_GROUP"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_DATE,@E_DATE", "CONVERT(varchar(10), L.EVENT_TIME, 120) BETWEEN @S_DATE AND @E_DATE "));

                        sbWhere.Append(" ORDER BY L.PART_CODE, L.EVENT_TIME ");

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

        public static DataTable TMAT_STOCK_LOG_QUERY5(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {

                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("SELECT L.PLT_CODE    					");
                    sbQuery.Append("	, L.PART_CODE         				");
                    sbQuery.Append("	, L.EVENT_TIME        				");
                    sbQuery.Append("	, L.GUBUN              				");
                    sbQuery.Append("	, L.PREV_QTY           				");
                    sbQuery.Append("	, L.IN_QTY              			");
                    sbQuery.Append("	, L.OUT_QTY            				");
                    sbQuery.Append("	, L.NEXT_QTY          				");
                    sbQuery.Append("	, L.STOCK_TYPE        				");
                    sbQuery.Append("	, L.STOCK_CODE       				");
                    sbQuery.Append("	, L.REG_EMP            				");
                    sbQuery.Append("	, E.EMP_NAME						");
                    sbQuery.Append("	, L.SCOMMENT        				");
                    sbQuery.Append("	, P.PART_NAME        				");
                    sbQuery.Append("	, P.DRAW_NO        					");
                    sbQuery.Append("	, P.MAT_LTYPE         				");
                    sbQuery.Append("	, P.MAT_MTYPE        				");
                    sbQuery.Append("	, P.MAT_STYPE         				");
                    sbQuery.Append("	, P.MAT_TYPE          				");
                    sbQuery.Append("	, P.PART_PRODTYPE   				");
                    sbQuery.Append("	, P.MAT_SPEC1   					");
                    sbQuery.Append("	, P.MAT_SPEC 						");
                    sbQuery.Append("	, SH.SHIP_DATE						");
                    sbQuery.Append("	, TSG.ASSY_PART_NAME						");
                    sbQuery.Append("	, TSG.SUB_QTY						");
                    sbQuery.Append("FROM TMAT_STOCK_LOG L 					");
                    sbQuery.Append("	JOIN LSE_STD_PART P      			");
                    sbQuery.Append("		ON L.PLT_CODE = P.PLT_CODE     	");
                    sbQuery.Append("		AND L.PART_CODE = P.PART_CODE   ");
                    sbQuery.Append("	JOIN TSTD_STOCK_GRP TSG           	");
                    sbQuery.Append("	 	ON P.PLT_CODE = TSG.PLT_CODE    ");
                    sbQuery.Append(" 		AND P.PART_CODE = TSG.PART_CODE ");
                    sbQuery.Append("	JOIN (SELECT * FROM TSTD_CODES WHERE CAT_CODE = 'S089' AND DATA_FLAG = 0) GRP_CODE           	");
                    sbQuery.Append("	 	ON TSG.PLT_CODE = GRP_CODE.PLT_CODE    ");
                    sbQuery.Append(" 		AND TSG.STK_GROUP = GRP_CODE.CD_CODE ");
                    sbQuery.Append("	LEFT JOIN TSHP_STOCK ST				");
                    sbQuery.Append("		ON L.PLT_CODE = ST.PLT_CODE		");
                    sbQuery.Append("		AND L.STK_ID = ST.STK_ID		");
                    sbQuery.Append("	LEFT JOIN TORD_SHIP SH				");
                    sbQuery.Append("		ON ST.PLT_CODE = SH.PLT_CODE	");
                    sbQuery.Append("		AND ST.SHIP_ID = SH.SHIP_ID		");
                    sbQuery.Append("		AND SH.DATA_FLAG = 0			");
                    sbQuery.Append("	LEFT JOIN TSTD_EMPLOYEE E  			");
                    sbQuery.Append("		ON L.PLT_CODE = E.PLT_CODE 		");
                    sbQuery.Append("		AND L.REG_EMP = E.EMP_CODE 		");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder();

                        sbWhere.Append(" WHERE L.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@STK_GROUP", "TSG.STK_GROUP = @STK_GROUP"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_DATE,@E_DATE", "CONVERT(varchar(10), L.EVENT_TIME, 120) BETWEEN @S_DATE AND @E_DATE "));



                        sbWhere.Append(" ORDER BY L.PART_CODE, L.EVENT_TIME ");

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

        public static DataTable TMAT_STOCK_LOG_QUERY6(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {

                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT L.PLT_CODE    ");
                    sbQuery.Append(" 	, L.PART_CODE         ");
                    sbQuery.Append(" 	, L.EVENT_TIME        ");
                    sbQuery.Append(" 	, L.GUBUN              ");
                    sbQuery.Append(" 	, L.PREV_QTY           ");
                    sbQuery.Append(" 	, L.IN_QTY              ");
                    sbQuery.Append(" 	, L.OUT_QTY            ");
                    sbQuery.Append(" 	, L.NEXT_QTY          ");
                    sbQuery.Append(" 	, L.STOCK_TYPE        ");
                    sbQuery.Append(" 	, L.STOCK_CODE       ");
                    sbQuery.Append(" 	, L.REG_EMP            ");
                    sbQuery.Append("  , E.EMP_NAME AS REG_EMP_NAME ");
                    sbQuery.Append(" 	, L.SCOMMENT        ");
                    sbQuery.Append(" 	, P.PART_NAME        ");
                    sbQuery.Append(" 	, P.DRAW_NO        ");
                    sbQuery.Append(" 	, P.MAT_LTYPE         ");
                    sbQuery.Append(" 	, P.MAT_MTYPE        ");
                    sbQuery.Append(" 	, P.MAT_STYPE         ");
                    sbQuery.Append(" 	, P.MAT_TYPE          ");
                    sbQuery.Append(" 	, P.PART_PRODTYPE   ");
                    sbQuery.Append(" 	, P.MAT_SPEC1   ");
                    sbQuery.Append(" 	, P.MAT_SPEC   ");
                    sbQuery.Append(" FROM TMAT_STOCK_LOG L JOIN LSE_STD_PART P      ");
                    sbQuery.Append("   ON L.PLT_CODE = P.PLT_CODE     ");
                    sbQuery.Append("   AND L.PART_CODE = P.PART_CODE      ");
                    sbQuery.Append("  LEFT JOIN TSTD_EMPLOYEE E  ");
                    sbQuery.Append("   ON L.PLT_CODE = E.PLT_CODE ");
                    sbQuery.Append("   AND L.REG_EMP = E.EMP_CODE ");
                    sbQuery.Append("  LEFT JOIN TSTD_CODES PP           	");
                    sbQuery.Append("	ON P.PLT_CODE = PP.PLT_CODE    ");
                    sbQuery.Append(" 	AND P.PART_PRODTYPE = PP.CD_CODE ");
                    sbQuery.Append(" 	AND PP.CAT_CODE = 'M007' ");
                    sbQuery.Append(" 	AND PP.DATA_FLAG = 0 ");
                    //sbQuery.Append("  LEFT JOIN TSTD_CODES GUBUN           	");
                    //sbQuery.Append("	ON L.PLT_CODE = GUBUN.PLT_CODE    ");
                    //sbQuery.Append(" 	AND L.GUBUN = GUBUN.CD_CODE ");
                    //sbQuery.Append(" 	AND GUBUN.CAT_CODE = 'S087' ");
                    //sbQuery.Append(" 	AND GUBUN.DATA_FLAG = 0 ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder();

                        sbWhere.Append(" WHERE L.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@STK_GROUP_NAME", "PP.CD_NAME LIKE '%' + @STK_GROUP_NAME + '%'"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_DATE,@E_DATE", "CONVERT(varchar(10), L.EVENT_TIME, 120) BETWEEN @S_DATE AND @E_DATE "));

                        sbWhere.Append(" AND P.MAT_TYPE = '제품' ");
                        sbWhere.Append(" AND L.GUBUN = 'PF' ");
                        sbWhere.Append(" ORDER BY L.PART_CODE, L.EVENT_TIME ");

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
