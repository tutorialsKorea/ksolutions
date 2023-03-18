using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BizExecute;
using System.Data;
using System.Data.SqlClient;

namespace DSTD
{
    public class TSTD_VENDOR_GRP
    {

        public static DataTable TSTD_VENDOR_GRP_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {

            try
            {
                DataSet dsResult = new DataSet();
                DataTable dtResult = new DataTable("RSLTDT");

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT S.PLT_CODE ");
                    sbQuery.Append(" , S.CD_CODE AS VEN_GROUP ");
                    sbQuery.Append(" , S.CD_NAME AS VEN_GROUP_NAME ");
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

                        sbWhere.Append("  AND S.CAT_CODE = 'S090' ");
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
        public static DataTable TSTD_VENDOR_GRP_SER1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {

            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT S.PLT_CODE ");
                    sbQuery.Append(" , S.VEN_GROUP ");
                    sbQuery.Append(" , C.CD_NAME AS VEN_GROUP_NAME ");
                    sbQuery.Append(" , C.SCOMMENT ");

                    sbQuery.Append(" , S.PART_CODE ");
                    sbQuery.Append(" , S.IS_VISIBLE ");
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
                    sbQuery.Append(" , S.GRP_ID ");
                    sbQuery.Append(" , S.VEN_SEQ ");
                    sbQuery.Append(" , S.SCOMMENT AS VEN_SCOMMENT ");

                    sbQuery.Append(" FROM TSTD_VENDOR_GRP S JOIN TSTD_CODES C ");
                    sbQuery.Append("    ON S.PLT_CODE = C.PLT_CODE ");
                    sbQuery.Append("   AND S.VEN_GROUP = C.CD_CODE ");
                    sbQuery.Append("   AND C.CAT_CODE = 'S090' ");
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
                    sbQuery.Append(" AND S.VEN_GROUP = @VEN_GROUP");

                    foreach (DataRow row in dtParam.Rows)
                    {                                                                   
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "VEN_GROUP")) isHasColumn = false;

                        if (isHasColumn == true)
                        {

                            StringBuilder sbWhere = new StringBuilder();

                            sbWhere.Append(UTIL.GetWhere(row, "@PART_LIKE", "(P.PART_CODE LIKE '%' + @PART_LIKE + '%' OR P.PART_NAME LIKE '%' + @PART_LIKE + '%')"));

                            sbWhere.Append(" ORDER BY S.VEN_SEQ");

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
        /// 선택한 그룹의 품목 삭제 _ PUR55B_D0A 재고 그룹 리스트에서 삭제
        /// </summary>
        /// <param name="dtParam"></param>
        /// <param name="bizExecute"></param>
        public static void TSTD_VENDOR_GRP_DEL(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" DELETE FROM  TSTD_VENDOR_GRP  ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append("  AND GRP_ID = @GRP_ID");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "GRP_ID")) isHasColumn = false;

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

        public static object TSTD_VENDOR_GRP_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {

                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" INSERT INTO TSTD_VENDOR_GRP");
                    sbQuery.Append(" ( ");
                    sbQuery.Append(" PLT_CODE");
                    sbQuery.Append(" , VEN_GROUP");
                    sbQuery.Append(" , PART_CODE");
                    sbQuery.Append(" , VEN_SEQ");
                    sbQuery.Append(" , SCOMMENT");
                    sbQuery.Append(" , IS_VISIBLE ");
                    sbQuery.Append(" ) ");
                    sbQuery.Append(" VALUES");
                    sbQuery.Append(" ( ");
                    sbQuery.Append(" @PLT_CODE ");
                    sbQuery.Append(" , @VEN_GROUP ");
                    sbQuery.Append(" , @PART_CODE ");
                    sbQuery.Append(" , @VEN_SEQ ");
                    sbQuery.Append(" , @SCOMMENT ");
                    sbQuery.Append(" , @IS_VISIBLE ");
                    sbQuery.Append(" );                         ");
                    sbQuery.Append(" SELECT CAST(SCOPE_IDENTITY() AS INT);             ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        return bizExecute.executeScalarQuery(sbQuery.ToString(), row);
                    }
                }

            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
            return null;
        }

        public static void TSTD_VENDOR_GRP_UPD(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {

                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" UPDATE TSTD_VENDOR_GRP ");
                    sbQuery.Append(" SET VEN_SEQ = @VEN_SEQ");
                    sbQuery.Append(" , SCOMMENT = @SCOMMENT");
                    sbQuery.Append(" , IS_VISIBLE = @IS_VISIBLE");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND GRP_ID = @GRP_ID");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "GRP_ID")) isHasColumn = false;

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

    public class TSTD_VENDOR_GRP_QUERY
    {

        public static DataTable TSTD_VENDOR_GRP_QUERY_QUERY1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT VG.PLT_CODE																				 ");
                    sbQuery.Append("  	, PR.PROD_CODE																				 ");
                    sbQuery.Append("  	, VG.PART_CODE																				 ");
                    sbQuery.Append("  	, LEFT(PR.PROD_CODE,1) AS PROD_TYPE																				 ");
                    sbQuery.Append("  	, CODE.CD_NAME AS PART_PRODTYPE																 ");
                    sbQuery.Append("  	, VG.SCOMMENT																				 ");
                    sbQuery.Append("    , VG.IS_VISIBLE                                                 ");
                    sbQuery.Append("  	, VEN.VEN_CODE																				 ");
                    sbQuery.Append("  	, VEN.VEN_NAME																				 ");
                    sbQuery.Append("  	, PR.PROD_QTY																				 ");
                    sbQuery.Append("  	, SHIP.SHIP_QTY																				 ");
                    sbQuery.Append(" 	, ISNULL(TW.MIN_STATE,'') AS MIN_STATE														 ");
                    sbQuery.Append(" 	, ISNULL(TW.MAX_STATE,'') AS MAX_STATE														 ");
                    sbQuery.Append(" 	, ISNULL(TW.ASSY_MIN_STATE,'') AS ASSY_MIN_STATE											 ");
                    sbQuery.Append(" 	, ISNULL(TW.ASSY_MAX_STATE,'') AS ASSY_MAX_STATE											 ");
                    sbQuery.Append("  	, PR.DUE_DATE																				 ");
                    sbQuery.Append("  	, VG.VEN_GROUP																				 ");
                    sbQuery.Append("  	, VG.VEN_SEQ																				 ");
                    sbQuery.Append("  	, ISNULL(P.STK_COMPLETE,0) AS STK_COMPLETE													 ");
                    sbQuery.Append("    FROM TSTD_VENDOR_GRP VG																		 ");
                    sbQuery.Append("  	INNER JOIN LSE_STD_PART P																	 ");
                    sbQuery.Append("  		ON VG.PLT_CODE = P.PLT_CODE																 ");
                    sbQuery.Append("  		AND VG.PART_CODE = P.PART_CODE															 ");
                    sbQuery.Append("  	LEFT JOIN (SELECT PLT_CODE																	 ");
                    sbQuery.Append("  					, ITEM_CODE																	 ");
                    sbQuery.Append("  					, PROD_CODE																	 ");
                    sbQuery.Append("  					, PART_CODE																	 ");
                    sbQuery.Append("  					, DUE_DATE																	 ");
                    sbQuery.Append(" 					, ORD_DATE					                                                 ");
                    sbQuery.Append("  					, PROD_QTY 																	 ");
                    sbQuery.Append("  				  FROM TORD_PRODUCT 															 ");
                    sbQuery.Append("  				 WHERE PARENT_PART IS NULL 														 ");
                    sbQuery.Append("  				   AND DATA_FLAG =0) PR															 ");
                    sbQuery.Append("  		ON VG.PLT_CODE = PR.PLT_CODE															 ");
                    sbQuery.Append("  		AND VG.PART_CODE = PR.PART_CODE															 ");
                    sbQuery.Append("        AND LEFT(PR.PROD_CODE,1) = 'C'                                                           ");
                    sbQuery.Append("        AND PR.ORD_DATE BETWEEN @S_DATE AND @E_DATE                                              ");
                    sbQuery.Append("  	LEFT JOIN TORD_ITEM T																		 ");
                    sbQuery.Append("  		ON PR.PLT_CODE = T.PLT_CODE																 ");
                    sbQuery.Append("  		AND PR.ITEM_CODE = T.ITEM_CODE															 ");
                    sbQuery.Append("  	LEFT JOIN (                            														 ");
                    sbQuery.Append("  		SELECT PLT_CODE                     													 ");
                    sbQuery.Append("  			 , PROD_CODE                    													 ");
                    sbQuery.Append("  			 , SUM(SHIP_QTY) AS SHIP_QTY    													 ");
                    sbQuery.Append("  		  FROM TORD_SHIP                    													 ");
                    sbQuery.Append("  	    WHERE DATA_FLAG = 0                    													 ");
                    sbQuery.Append("  		GROUP BY PLT_CODE, PROD_CODE) SHIP  													 ");
                    sbQuery.Append("  		ON PR.PLT_CODE = SHIP.PLT_CODE      													 ");
                    sbQuery.Append("  		AND PR.PROD_CODE = SHIP.PROD_CODE   													 ");
                    sbQuery.Append(" 	LEFT JOIN (SELECT W.PLT_CODE																 ");
                    sbQuery.Append(" 					, W.PROD_CODE																 ");
                    sbQuery.Append(" 					, MIN(CASE WHEN SP.PROC_CODE IS NOT NULL THEN W.WO_FLAG END) AS MIN_STATE	 ");
                    sbQuery.Append(" 					, MAX(CASE WHEN SP.PROC_CODE IS NOT NULL THEN W.WO_FLAG END) AS MAX_STATE	 ");
                    sbQuery.Append(" 					, MIN(CASE WHEN SP.PROC_CODE IS NULL THEN W.WO_FLAG END) AS ASSY_MIN_STATE	 ");
                    sbQuery.Append(" 					, MAX(CASE WHEN SP.PROC_CODE IS NULL THEN W.WO_FLAG END) AS ASSY_MAX_STATE	 ");
                    sbQuery.Append(" 				FROM TSHP_WORKORDER W															 ");
                    sbQuery.Append(" 					INNER JOIN (SELECT LSP.PLT_CODE												 ");
                    sbQuery.Append(" 									 , LSP.PROC_CODE											 ");
                    sbQuery.Append(" 									 , LSP.PROC_SEQ												 ");
                    sbQuery.Append(" 									 , LSP.PROC_NAME											 ");
                    sbQuery.Append(" 								  FROM LSE_STD_PROC LSP											 ");
                    sbQuery.Append(" 								INNER JOIN (SELECT PLT_CODE										 ");
                    sbQuery.Append(" 												 , MIN(PROC_SEQ) AS PROC_SEQ					 ");
                    sbQuery.Append(" 											  FROM LSE_STD_PROC									 ");
                    sbQuery.Append(" 											 WHERE IS_ASSY = 1									 ");
                    sbQuery.Append(" 											GROUP BY PLT_CODE									 ");
                    sbQuery.Append(" 											 ) ASSY_SP											 ");
                    sbQuery.Append(" 									ON LSP.PLT_CODE = ASSY_SP.PLT_CODE							 ");
                    sbQuery.Append(" 									AND LSP.PROC_SEQ < ASSY_SP.PROC_SEQ) SP						 ");
                    sbQuery.Append(" 						ON W.PLT_CODE = SP.PLT_CODE												 ");
                    sbQuery.Append(" 						AND W.PROC_CODE = SP.PROC_CODE											 ");
                    sbQuery.Append(" 				WHERE W.DATA_FLAG = 0															 ");
                    //자재발주 제외
                    sbQuery.Append(" 				    AND W.PROC_CODE <> 'P-02'															 ");
                    sbQuery.Append(" 				GROUP BY W.PLT_CODE, W.PROD_CODE) TW											 ");
                    sbQuery.Append(" 		ON VG.PLT_CODE = TW.PLT_CODE											 				 ");
                    sbQuery.Append(" 		AND PR.PROD_CODE = TW.PROD_CODE											 				 ");
                    sbQuery.Append("  	LEFT JOIN TSTD_VENDOR VEN																	 ");
                    sbQuery.Append("  		ON T.PLT_CODE = VEN.PLT_CODE															 ");
                    sbQuery.Append("  		AND T.CVND_CODE = VEN.VEN_CODE															 ");
                    sbQuery.Append("  	LEFT JOIN TSTD_CODES CODE																	 ");
                    sbQuery.Append("  		ON P.PLT_CODE = CODE.PLT_CODE															 ");
                    sbQuery.Append("  		AND P.PART_PRODTYPE = CODE.CD_CODE														 ");
                    sbQuery.Append("  		AND CODE.CAT_CODE = 'M007'																 ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE VG.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@VEN_GROUP", "VG.VEN_GROUP = @VEN_GROUP "));
                        //sbWhere.Append(UTIL.GetWhere(row, "@S_DATE,@E_DATE", "PR.DUE_DATE BETWEEN @S_DATE AND @E_DATE "));

                        sbWhere.Append(" AND ISNULL(VG.IS_VISIBLE,0) <> 1   ");
                        sbWhere.Append(" ORDER BY VG.VEN_SEQ   ");
                        DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString() + sbWhere.ToString(),row).Copy();

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

        public static DataTable TSTD_VENDOR_GRP_QUERY_QUERY2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT VG.PLT_CODE								");
                    sbQuery.Append(" 	, PR.PROD_CODE								");
                    sbQuery.Append("  	, LEFT(PR.PROD_CODE,1) AS PROD_TYPE			");
                    sbQuery.Append(" 	, VG.PART_CODE								");
                    sbQuery.Append(" 	, CODE.CD_NAME AS PART_PRODTYPE				");
                    sbQuery.Append(" 	, VG.SCOMMENT								");
                    sbQuery.Append("    , VG.IS_VISIBLE                                                 ");
                    sbQuery.Append(" 	, PR.PROD_QTY								");
                    sbQuery.Append(" 	, PR.DUE_DATE								");
                    sbQuery.Append(" 	, VG.VEN_GROUP								");
                    sbQuery.Append(" 	, VGD.PART_CODE AS DETAIL_PART_CODE			");
                    //sbQuery.Append(" 	, TW.PART_QTY								");
                    sbQuery.Append(" 	, WP.PLN_QTY AS PART_QTY								");
                    sbQuery.Append(" 	, ISNULL(TW.MIN_STATE,'') AS MIN_STATE														 ");
                    sbQuery.Append(" 	, ISNULL(TW.MAX_STATE,'') AS MAX_STATE														 ");
                    sbQuery.Append(" 	, ISNULL(TW.ASSY_MIN_STATE,'') AS ASSY_MIN_STATE											 ");
                    sbQuery.Append(" 	, ISNULL(TW.ASSY_MAX_STATE,'') AS ASSY_MAX_STATE											 ");
                    sbQuery.Append(" 	, VGD.SCOMMENT AS DETAIL_SCOMMENT			");
                    sbQuery.Append(" 	, VGD.VIEW_FLAG								");
                    sbQuery.Append(" 	, VG.VEN_SEQ								");
                    sbQuery.Append("  	, ISNULL(P.STK_COMPLETE,0) AS STK_COMPLETE	");
                    sbQuery.Append("   FROM TSTD_VENDOR_GRP VG						");
                    sbQuery.Append("	INNER JOIN TSTD_VENDOR_GRP_DETAIL VGD		");
                    sbQuery.Append(" 		ON VG.PLT_CODE = VGD.PLT_CODE			");
                    sbQuery.Append(" 		AND VG.GRP_ID = VGD.GRP_ID				");
                    sbQuery.Append("        AND VGD.VIEW_FLAG = 1      				");
                    sbQuery.Append(" 	INNER JOIN LSE_STD_PART MP					");
                    sbQuery.Append(" 		ON VG.PLT_CODE = MP.PLT_CODE			");
                    sbQuery.Append(" 		AND VG.PART_CODE = MP.PART_CODE			");
                    sbQuery.Append(" 	INNER JOIN LSE_STD_PART P					");
                    sbQuery.Append(" 		ON VGD.PLT_CODE = P.PLT_CODE			");
                    sbQuery.Append(" 		AND VGD.PART_CODE = P.PART_CODE			");
                    sbQuery.Append(" 	LEFT JOIN (SELECT PLT_CODE					");
                    sbQuery.Append(" 					, ITEM_CODE					");
                    sbQuery.Append(" 					, PROD_CODE					");
                    sbQuery.Append(" 					, PART_CODE					");
                    sbQuery.Append(" 					, DUE_DATE					");
                    sbQuery.Append(" 					, ORD_DATE					");
                    sbQuery.Append(" 					, PROD_QTY 					");
                    sbQuery.Append(" 				  FROM TORD_PRODUCT 			");
                    sbQuery.Append(" 				 WHERE DATA_FLAG =0) PR			");
                    sbQuery.Append(" 		ON VGD.PLT_CODE = PR.PLT_CODE			");
                    sbQuery.Append(" 		AND VGD.PART_CODE = PR.PART_CODE			");
                    sbQuery.Append("        AND LEFT(PR.PROD_CODE,1) <> 'C'                                                           ");
                    sbQuery.Append("        AND PR.ORD_DATE BETWEEN @S_DATE AND @E_DATE                                              ");
                    sbQuery.Append("	LEFT JOIN (SELECT W.PLT_CODE				");
                    sbQuery.Append("					, W.PROD_CODE				");
                    sbQuery.Append("					, W.PART_CODE				");
                    sbQuery.Append("					, W.PART_QTY				");
                    sbQuery.Append("					, MIN(CASE WHEN SP.PROC_CODE IS NOT NULL THEN W.WO_FLAG END) AS MIN_STATE		");
                    sbQuery.Append("					, MAX(CASE WHEN SP.PROC_CODE IS NOT NULL THEN W.WO_FLAG END) AS MAX_STATE		");
                    sbQuery.Append("					, MIN(CASE WHEN SP.PROC_CODE IS NULL THEN W.WO_FLAG END) AS ASSY_MIN_STATE		");
                    sbQuery.Append("					, MAX(CASE WHEN SP.PROC_CODE IS NULL THEN W.WO_FLAG END) AS ASSY_MAX_STATE		");
                    sbQuery.Append("				FROM TSHP_WORKORDER W																");
                    sbQuery.Append("					LEFT JOIN (SELECT LSP.PLT_CODE													");
                    sbQuery.Append("									 , LSP.PROC_CODE												");
                    sbQuery.Append("									 , LSP.PROC_SEQ													");
                    sbQuery.Append("									 , LSP.PROC_NAME												");
                    sbQuery.Append("								  FROM LSE_STD_PROC LSP												");
                    sbQuery.Append("								INNER JOIN (SELECT PLT_CODE											");
                    sbQuery.Append("												 , MIN(PROC_SEQ) AS PROC_SEQ						");
                    sbQuery.Append("											  FROM LSE_STD_PROC										");
                    sbQuery.Append("											 WHERE IS_ASSY = 1										");
                    sbQuery.Append("											GROUP BY PLT_CODE										");
                    sbQuery.Append("											 ) ASSY_SP												");
                    sbQuery.Append("									ON LSP.PLT_CODE = ASSY_SP.PLT_CODE								");
                    sbQuery.Append("									AND LSP.PROC_SEQ < ASSY_SP.PROC_SEQ) SP							");
                    sbQuery.Append("						ON W.PLT_CODE = SP.PLT_CODE													");
                    sbQuery.Append("						AND W.PROC_CODE = SP.PROC_CODE												");
                    sbQuery.Append("				WHERE W.DATA_FLAG = 0																");
                    sbQuery.Append("				GROUP BY W.PLT_CODE, W.PROD_CODE, W.PART_CODE, W.PART_QTY) TW						");
                    sbQuery.Append("		ON VG.PLT_CODE = TW.PLT_CODE											 					");
                    sbQuery.Append("		AND PR.PROD_CODE = TW.PROD_CODE																");
                    sbQuery.Append("		AND PR.PART_CODE = TW.PART_CODE																");
                    sbQuery.Append(" 	LEFT JOIN TSHP_WORKPLAN WP																		");
                    sbQuery.Append(" 		ON PR.PLT_CODE = WP.PLT_CODE																");
                    sbQuery.Append(" 		AND PR.PROD_CODE = WP.PROD_CODE															");
                    sbQuery.Append(" 		AND PR.PART_CODE = WP.PART_CODE															");
                    sbQuery.Append(" 	LEFT JOIN TSTD_CODES CODE																		");
                    sbQuery.Append(" 		ON MP.PLT_CODE = CODE.PLT_CODE																");
                    sbQuery.Append(" 		AND MP.PART_PRODTYPE = CODE.CD_CODE															");
                    sbQuery.Append(" 		AND CODE.CAT_CODE = 'M007'																    ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE VG.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@VEN_GROUP", "VG.VEN_GROUP = @VEN_GROUP "));
                        //sbWhere.Append(UTIL.GetWhere(row, "@S_DATE,@E_DATE", "PR.DUE_DATE BETWEEN @S_DATE AND @E_DATE "));
                        //sbWhere.Append("    AND LEFT(PR.PROD_CODE,1) <> 'C' ");
                        sbWhere.Append(" AND ISNULL(VG.IS_VISIBLE,0) <> 1   ");
                        sbWhere.Append(" ORDER BY VG.VEN_SEQ   ");
                        DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString() + sbWhere.ToString(),row).Copy();

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

