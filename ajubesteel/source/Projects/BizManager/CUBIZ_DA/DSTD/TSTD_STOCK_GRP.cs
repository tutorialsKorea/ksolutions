using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BizExecute;
using System.Data;
using System.Data.SqlClient;

namespace DSTD
{
    public class TSTD_STOCK_GRP
    {

        public static DataTable TSTD_STOCK_GRP_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {

            try
            {
                DataSet dsResult = new DataSet();
                DataTable dtResult = new DataTable("RSLTDT");

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT S.PLT_CODE ");
                    sbQuery.Append(" , S.CD_CODE AS STK_GROUP ");
                    sbQuery.Append(" , S.CD_NAME AS STK_GROUP_NAME ");
                    sbQuery.Append(" , S.SCOMMENT ");
                    sbQuery.Append(" , S.REG_DATE");
                    //sbQuery.Append(" , S.REG_EMP ");
                    sbQuery.Append(" , REG.EMP_NAME AS REG_EMP ");
                    sbQuery.Append(" , S.MDFY_DATE ");
                    //sbQuery.Append(" , S.MDFY_EMP");
                    sbQuery.Append(" , MDFY.EMP_NAME AS MDFY_EMP ");
                    sbQuery.Append(" FROM TSTD_CODES S JOIN TSTD_EMPLOYEE REG ");
                    sbQuery.Append("  ON S.PLT_CODE = REG.PLT_CODE AND S.REG_EMP = REG.EMP_CODE ");
                    sbQuery.Append("  LEFT OUTER JOIN TSTD_EMPLOYEE MDFY ");
                    sbQuery.Append("  ON S.PLT_CODE = MDFY.PLT_CODE AND S.MDFY_EMP = MDFY.EMP_CODE ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder();

                        sbWhere.Append(" WHERE S.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append("  AND S.CAT_CODE = 'S089' ");
                        sbWhere.Append("  AND S.DATA_FLAG = 0 ");

                        

                        DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString() + sbWhere.ToString()).Copy();

                        sourceTable.TableName = "RSLTDT";
                        dsResult.Merge(sourceTable);
                    }

                    dtResult = bizExecute.executeSelectQuery(sbQuery.ToString(), dtParam.Rows[0]).Copy();
   
                }

                return UTIL.GetDsToDt(dsResult);

            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        /// <summary>
        /// 특정 그룹에 해당하는 품목 정보 표시
        /// </summary>
        /// <param name="dtParam"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataTable TSTD_STOCK_GRP_SER1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {

            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT S.PLT_CODE ");
                    sbQuery.Append(" , S.STK_GROUP ");
                    sbQuery.Append(" , C.CD_NAME AS STK_GROUP_NAME ");
                    sbQuery.Append(" , C.SCOMMENT ");

                    sbQuery.Append(" , S.PART_CODE ");
                    sbQuery.Append(" , P.PART_PRODTYPE ");
                    sbQuery.Append(" , P.PART_NAME ");
                    sbQuery.Append(" , P.MAT_SPEC1");
                    sbQuery.Append(" , P.MAT_SPEC ");
                    sbQuery.Append(" , P.MAT_WEIGHT ");
                    sbQuery.Append(" , P.MAT_WEIGHT1 ");
                    sbQuery.Append(" , P.DRAW_NO ");
                    sbQuery.Append(" , P.MAT_LTYPE ");
                    sbQuery.Append(" , P.MAT_MTYPE ");
                    sbQuery.Append(" , P.MAT_STYPE ");
                    sbQuery.Append(" , P.MAT_TYPE ");
                    sbQuery.Append(" , P.SCOMMENT AS PART_SCOMMENT ");
                    sbQuery.Append(" , ISNULL(P.STK_COMPLETE, 0) STK_COMPLETE ");
                    sbQuery.Append(" , ISNULL(P.STK_TURNING, 0) STK_TURNING ");
                    sbQuery.Append(" , ISNULL(P.STK_COMPLETE, 0) AS O_STK_COMPLETE");
                    sbQuery.Append(" , ISNULL(P.STK_TURNING, 0) AS O_STK_TURNING ");
                    sbQuery.Append(" , ISNULL(P.STK_TOTAL, 0) STK_TOTAL ");
                    sbQuery.Append("      , ISNULL(W.PLN_QTY, 0) - ISNULL(W.FNS_QTY, 0) - ISNULL(W.NG_QTY, 0) AS WIP_QTY ");
                    sbQuery.Append("      , ISNULL(P.STK_COMPLETE, 0) + ISNULL(P.STK_TURNING, 0) + (ISNULL(W.PLN_QTY, 0) - ISNULL(W.FNS_QTY, 0) - ISNULL(W.NG_QTY, 0)) AS STK_SUM ");

                    sbQuery.Append(" , C.REG_DATE");
                    
                    sbQuery.Append(" , REG.EMP_NAME AS REG_EMP ");
                    sbQuery.Append(" , C.MDFY_DATE ");
                    
                    sbQuery.Append(" , MDFY.EMP_NAME AS MDFY_EMP ");

                    sbQuery.Append(" , S.ASSY_PART_NAME ");
                    sbQuery.Append(" , S.SUB_QTY ");
                    sbQuery.Append(" , S.USE_QTY ");
                    sbQuery.Append(" , S.STK_SEQ ");
                    sbQuery.Append(" , S.SCOMMENT AS STK_SCOMMENT ");
                    sbQuery.Append(" , S.ASSY_PART_NAME						");
                    sbQuery.Append(" , S.SUB_QTY						");

                    sbQuery.Append(" FROM TSTD_STOCK_GRP S JOIN TSTD_CODES C ");
                    sbQuery.Append("    ON S.PLT_CODE = C.PLT_CODE ");
                    sbQuery.Append("   AND S.STK_GROUP = C.CD_CODE ");
                    sbQuery.Append("   AND C.CAT_CODE = 'S089' ");
                    sbQuery.Append("    JOIN LSE_STD_PART P ");
                    sbQuery.Append("   ON S.PLT_CODE = P.PLT_CODE AND S.PART_CODE = P.PART_CODE ");

                    sbQuery.Append("    LEFT JOIN (SELECT W.PLT_CODE, W.PART_CODE, ");
                    sbQuery.Append("              SUM(W.PART_QTY) AS PLN_QTY,     ");
                    sbQuery.Append("              SUM(W.FNS_QTY) AS FNS_QTY,      ");
                    sbQuery.Append("              SUM(W.NG_QTY) AS NG_QTY         ");
                    sbQuery.Append("    	FROM TSHP_WORKORDER W JOIN TORD_PRODUCT P       ");
                    sbQuery.Append("    	 ON W.PLT_CODE = P.PLT_CODE           ");
                    sbQuery.Append("    	 AND W.PROD_CODE = P.PROD_CODE        ");
                    sbQuery.Append("    	 AND W.PART_CODE = P.PART_CODE        ");
                    sbQuery.Append("    	  JOIN TORD_ITEM I                    ");
                    sbQuery.Append("    	  ON P.PLT_CODE = I.PLT_CODE          ");
                    sbQuery.Append("    	  AND P.ITEM_CODE = I.ITEM_CODE       ");
                    sbQuery.Append("    	  JOIN TSTD_VENDOR V                  ");
                    sbQuery.Append("    	  ON I.PLT_CODE = V.PLT_CODE          ");
                    sbQuery.Append("    	  AND I.CVND_CODE = V.VEN_CODE        ");
                    sbQuery.Append("    	WHERE W.DATA_FLAG = 0                 ");
                    sbQuery.Append("    	  AND I.DATA_FLAG = 0                 ");
                    sbQuery.Append("    	  AND V.ITEM_AUTO_CODE IN ('H', 'S')   ");
                    sbQuery.Append("    	  AND W.WO_FLAG <> '4'                ");
                    sbQuery.Append("    	  AND W.IS_LAST = '1'                 ");
                    sbQuery.Append("    	  GROUP BY W.PLT_CODE, W.PART_CODE    ");
                    sbQuery.Append("    	  ) W                                  ");

                    sbQuery.Append("    ON P.PLT_CODE = W.PLT_CODE ");
                    sbQuery.Append("    AND P.PART_CODE = W.PART_CODE ");

                    sbQuery.Append("  LEFT OUTER JOIN TSTD_EMPLOYEE REG ");
                    sbQuery.Append("  ON C.PLT_CODE = REG.PLT_CODE AND C.REG_EMP = REG.EMP_CODE ");
                    sbQuery.Append("  LEFT OUTER JOIN TSTD_EMPLOYEE MDFY ");
                    sbQuery.Append("  ON C.PLT_CODE = MDFY.PLT_CODE AND C.MDFY_EMP = MDFY.EMP_CODE ");

                    sbQuery.Append(" WHERE S.PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND S.STK_GROUP = @STK_GROUP");

                    foreach (DataRow row in dtParam.Rows)
                    {                                                                   
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "STK_GROUP")) isHasColumn = false;

                        if (isHasColumn == true)
                        {

                            StringBuilder sbWhere = new StringBuilder();

                            sbWhere.Append(UTIL.GetWhere(row, "@PART_LIKE", "(P.PART_CODE LIKE '%' + @PART_LIKE + '%' OR P.PART_NAME LIKE '%' + @PART_LIKE + '%')"));
                            sbWhere.Append(UTIL.GetWhere(row, "@MAT_TYPE", "P.MAT_TYPE IN @MAT_TYPE", UTIL.SqlCondType.IN));

                            //sbWhere.Append(UTIL.GetWhere(row, "@S_REG_DATE,@E_REG_DATE", "P.REG_DATE BETWEEN @S_REG_DATE AND @E_REG_DATE"));
                            sbWhere.Append(UTIL.GetWhere(row, "@PART_LIKE", "(P.PART_CODE LIKE '%' + @PART_LIKE + '%' OR P.PART_NAME LIKE '%' + @PART_LIKE + '%')"));
                            sbWhere.Append(UTIL.GetWhere(row, "@MAT_LTYPE", "P.MAT_LTYPE = @MAT_LTYPE "));
                            sbWhere.Append(UTIL.GetWhere(row, "@MAT_MTYPE", "P.MAT_MTYPE = @MAT_MTYPE "));
                            sbWhere.Append(UTIL.GetWhere(row, "@MAT_STYPE", "P.MAT_STYPE = @MAT_STYPE "));

                            sbWhere.Append(" ORDER BY S.STK_SEQ");

                            DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString() + sbWhere.ToString(),row).Copy();

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
        /// 해당 데이터 있는지 검색

        /// </summary>
        /// <param name="dtParam"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataTable TSTD_STOCK_GRP_SER2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {

            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT S.PLT_CODE ");
                    sbQuery.Append(" , S.STK_GRP_NAME ");
                    sbQuery.Append(" , S.PART_CODE ");
                    sbQuery.Append(" , S.SCOMMENT ");
                    sbQuery.Append(" , S.REG_DATE");
                    sbQuery.Append(" , S.REG_EMP ");
                    sbQuery.Append(" , S.MDFY_DATE ");
                    sbQuery.Append(" , S.MDFY_EMP");
                    sbQuery.Append(" FROM TSTD_STOCK_GRP S ");
                    sbQuery.Append(" WHERE S.PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND S.STK_GRP_NAME = @STK_GRP_NAME");
                    sbQuery.Append(" AND S.PART_CODE = @PART_CODE");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "GRP_NAME")) isHasColumn = false;

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

        public static DataTable TSTD_STOCK_GRP_SER3(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {

            try
            {
                DataSet dsResult = new DataSet();
                DataTable dtResult = new DataTable("RSLTDT");

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT S.PLT_CODE ");
                    sbQuery.Append(" , S.CD_CODE AS STK_GROUP ");
                    sbQuery.Append(" , S.CD_NAME AS STK_GROUP_NAME ");
                    sbQuery.Append(" , S.SCOMMENT ");
                    sbQuery.Append(" , S.REG_DATE");
                    sbQuery.Append(" , REG.EMP_NAME AS REG_EMP ");
                    sbQuery.Append(" , S.MDFY_DATE ");
                    sbQuery.Append(" , MDFY.EMP_NAME AS MDFY_EMP ");

                    sbQuery.Append(" , @S_DATE AS S_DATE ");
                    sbQuery.Append(" , @E_DATE AS E_DATE ");
                    sbQuery.Append(" , @PART_LIKE  AS PART_LIKE  ");
                    sbQuery.Append(" , @MAT_LTYPE  AS MAT_LTYPE  ");
                    sbQuery.Append(" , @MAT_MTYPE  AS MAT_MTYPE  ");
                    sbQuery.Append(" , @MAT_STYPE  AS MAT_STYPE  ");

                    sbQuery.Append(" FROM TSTD_CODES S JOIN TSTD_EMPLOYEE REG ");
                    sbQuery.Append("  ON S.PLT_CODE = REG.PLT_CODE AND S.REG_EMP = REG.EMP_CODE ");
                    sbQuery.Append("  LEFT OUTER JOIN TSTD_EMPLOYEE MDFY ");
                    sbQuery.Append("  ON S.PLT_CODE = MDFY.PLT_CODE AND S.MDFY_EMP = MDFY.EMP_CODE ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder();

                        sbWhere.Append(" WHERE S.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append("  AND S.CAT_CODE = 'S089' ");
                        sbWhere.Append("  AND S.DATA_FLAG = 0 ");


                        DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString() + sbWhere.ToString(),row).Copy();

                        sourceTable.TableName = "RSLTDT";
                        dsResult.Merge(sourceTable);
                    }

                    dtResult = bizExecute.executeSelectQuery(sbQuery.ToString(), dtParam.Rows[0]).Copy();

                }

                return UTIL.GetDsToDt(dsResult);

            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        /// <summary>
        /// 선택한 그룹의 품목 삭제 _ PUR55B_D0A 재고 그룹 리스트에서 삭제
        /// </summary>
        /// <param name="dtParam"></param>
        /// <param name="bizExecute"></param>
        public static void TSTD_STOCK_GRP_DEL(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" DELETE FROM  TSTD_STOCK_GRP  ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append("  AND STK_GROUP = @STK_GROUP");
                    sbQuery.Append("  AND PART_CODE = @PART_CODE");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "STK_GROUP")) isHasColumn = false;

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

        /// <summary>
        /// 특정 그룹 전체 삭제
        /// </summary>
        /// <param name="dtParam"></param>
        /// <param name="bizExecute"></param>
        public static void TSTD_STOCK_GRP_DEL2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" DELETE FROM  TSTD_STOCK_GRP  ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append("  AND STK_GRP_NAME = @GRP_NAME");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "GRP_NAME")) isHasColumn = false;

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

        public static void TSTD_STOCK_GRP_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {

                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" INSERT INTO TSTD_STOCK_GRP");
                    sbQuery.Append(" ( ");
                    sbQuery.Append(" PLT_CODE");
                    sbQuery.Append(" , STK_GROUP");
                    sbQuery.Append(" , PART_CODE");
                    sbQuery.Append(" , ASSY_PART_NAME");
                    sbQuery.Append(" , SUB_QTY");
                    sbQuery.Append(" , USE_QTY");
                    sbQuery.Append(" , STK_SEQ");
                    sbQuery.Append(" , SCOMMENT");
                    sbQuery.Append(" ) ");
                    sbQuery.Append(" VALUES");
                    sbQuery.Append(" ( ");
                    sbQuery.Append(" @PLT_CODE ");
                    sbQuery.Append(" , @STK_GROUP ");
                    sbQuery.Append(" , @PART_CODE ");
                    sbQuery.Append(" , @ASSY_PART_NAME");
                    sbQuery.Append(" , @SUB_QTY");
                    sbQuery.Append(" , @USE_QTY ");
                    sbQuery.Append(" , @STK_SEQ ");
                    sbQuery.Append(" , @SCOMMENT ");
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

        public static void TSTD_STOCK_GRP_UPD(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {

                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" UPDATE TSTD_STOCK_GRP ");
                    sbQuery.Append(" SET USE_QTY = @USE_QTY");
                    sbQuery.Append(" , ASSY_PART_NAME = @ASSY_PART_NAME");
                    sbQuery.Append(" , SUB_QTY = @SUB_QTY");
                    sbQuery.Append(" , STK_SEQ = @STK_SEQ");
                    sbQuery.Append(" , SCOMMENT = @SCOMMENT");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND STK_GROUP = @STK_GROUP");
                    sbQuery.Append(" AND PART_CODE = @PART_CODE");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "STK_GROUP")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PART_CODE")) isHasColumn = false;

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

    public class TSTD_STOCK_GRP_QUERY
    {
        

    }
}

