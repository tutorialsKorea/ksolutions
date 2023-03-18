using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace DHIS
{
    public class THIS_PM_PLAN
    {
        public static DataTable THIS_PM_PLAN_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT  PLT_CODE      ");
                    sbQuery.Append("        , MTN_CODE ");
                    sbQuery.Append("        , MC_CODE ");
                    sbQuery.Append("        , PLN_DATE ");
                    sbQuery.Append("        , ACT_DATE ");
                    sbQuery.Append("        , ACT_DATE  AS PM_DATE");
                    sbQuery.Append("        , NEXT_PLN_DATE ");
                    sbQuery.Append("        , REG_DATE ");
                    sbQuery.Append("        , REG_EMP ");
                    sbQuery.Append("        , MDFY_DATE ");
                    sbQuery.Append("        , MDFY_EMP ");
                    sbQuery.Append("  FROM THIS_PM_PLAN       ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append("   AND MTN_CODE = @MTN_CODE      ");
                    sbQuery.Append("   AND MC_CODE = @MC_CODE      ");
                    sbQuery.Append("   AND PLN_DATE = @PLN_DATE      ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "MTN_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "MC_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PLN_DATE")) isHasColumn = false;

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

        public static DataTable THIS_PM_PLAN_SER2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT  PLT_CODE      ");
                    sbQuery.Append("        , MTN_CODE ");
                    sbQuery.Append("        , MC_CODE ");
                    sbQuery.Append("        , PLN_DATE ");
                    sbQuery.Append("        , ACT_DATE ");
                    sbQuery.Append("        , ACT_DATE  AS PM_DATE");
                    sbQuery.Append("        , NEXT_PLN_DATE ");
                    sbQuery.Append("        , REG_DATE ");
                    sbQuery.Append("        , REG_EMP ");
                    sbQuery.Append("        , MDFY_DATE ");
                    sbQuery.Append("        , MDFY_EMP ");
                    sbQuery.Append("  FROM THIS_PM_PLAN       ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append("   AND MTN_CODE = @MTN_CODE      ");
                    sbQuery.Append("   AND MC_CODE = @MC_CODE      ");
                    sbQuery.Append("   AND ACT_DATE IS NULL      ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "MTN_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "MC_CODE")) isHasColumn = false;

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
        /// 상태변경
        /// </summary>
        /// <param name="dtParam"></param>
        /// <param name="bizExecute"></param>
        public static void THIS_PM_PLAN_UPD(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE THIS_PM_PLAN                      ");
                    sbQuery.Append("    SET  ACT_DATE   = @PLN_DATE     ");
                    sbQuery.Append("        , MDFY_DATE = GETDATE() ");
                    sbQuery.Append("        , MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append("   AND MTN_CODE = @MTN_CODE      ");
                    sbQuery.Append("   AND MC_CODE = @MC_CODE      ");
                    sbQuery.Append("   AND PLN_DATE = @PLN_DATE      ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "MTN_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "MC_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PLN_DATE")) isHasColumn = false;

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

      
        /// <summary>
        /// 계획 삭제(해당 설비 전체)
        /// </summary>
        /// <param name="dtParam"></param>
        /// <param name="bizExecute"></param>
        public static void THIS_PM_PLAN_DEL(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" DELETE FROM  THIS_PM_PLAN                  ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append("   AND MTN_CODE = @MTN_CODE      ");
                    sbQuery.Append("   AND MC_CODE = @MC_CODE      ");
                    sbQuery.Append("   AND ACT_DATE IS NULL      ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "MTN_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "MC_CODE")) isHasColumn = false;

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
        public static void THIS_PM_PLAN_DEL2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" DELETE FROM  THIS_PM_PLAN                  ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append("   AND MTN_CODE = @MTN_CODE      ");
                    sbQuery.Append("   AND MC_CODE = @MC_CODE      ");
                    sbQuery.Append("   AND PLN_DATE = @PLN_DATE      ");
                    sbQuery.Append("   AND ACT_DATE IS NULL      ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "MTN_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "MC_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PLN_DATE")) isHasColumn = false;

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

        public static void THIS_PM_PLAN_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" INSERT INTO THIS_PM_PLAN ");
                    sbQuery.Append(" (                         ");
                    sbQuery.Append("        PLT_CODE      ");
                    sbQuery.Append("        , MTN_CODE ");
                    sbQuery.Append("        , MC_CODE ");
                    sbQuery.Append("        , PLN_DATE ");
                    sbQuery.Append("        , ACT_DATE ");
                    sbQuery.Append("        , NEXT_PLN_DATE ");
                    sbQuery.Append("        , REG_DATE ");
                    sbQuery.Append("        , REG_EMP ");
                    sbQuery.Append(" )                         ");
                    sbQuery.Append(" VALUES                    ");
                    sbQuery.Append(" (                         ");
                    sbQuery.Append("        @PLT_CODE      ");
                    sbQuery.Append("        , @MTN_CODE ");
                    sbQuery.Append("        , @MC_CODE ");
                    sbQuery.Append("        , @PLN_DATE ");
                    sbQuery.Append("        , @ACT_DATE ");
                    sbQuery.Append("        , @NEXT_PLN_DATE ");
                    sbQuery.Append("        , GETDATE()");
                    sbQuery.Append("        , " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" )                         ");

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

    public class THIS_PM_PLAN_QUERY
    {
        /// <summary>
        /// 계측기 목록
        /// </summary>
        /// <param name="dtParam"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataTable THIS_PM_PLAN_QUERY1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT PP.PLT_CODE      ");
                    sbQuery.Append("        , PP.MTN_CODE ");
                    sbQuery.Append("        , SP.MTN_NAME ");
                    sbQuery.Append("        , PP.MC_CODE ");
                    sbQuery.Append("        , MC.MC_NAME ");
                    sbQuery.Append("        , PP.PLN_DATE ");
                    sbQuery.Append("        , PP.ACT_DATE ");
                    sbQuery.Append("        , PP.NEXT_PLN_DATE ");
                    sbQuery.Append("        , PP.REG_DATE ");
                    sbQuery.Append("        , PP.REG_EMP ");
                    sbQuery.Append("        , PP.MDFY_DATE ");
                    sbQuery.Append("        , PP.MDFY_EMP ");
                    sbQuery.Append("        , PA.PM_ACT_CODE  ");
                    sbQuery.Append("        , PA.PM_DATE      ");
                    sbQuery.Append("        , PA.PM_TYPE      ");
                    sbQuery.Append("        , PA.PM_GUBUN     ");
                    sbQuery.Append("        , PA.PART_SUPPLY  ");
                    sbQuery.Append("        , PA.PM_TIME      ");
                    sbQuery.Append("        , PA.PM_CONTENTS  ");
                    sbQuery.Append("        , PA.PM_COST      ");
                    sbQuery.Append("        , PA.PM_VND       ");
                    sbQuery.Append("        , PA.PM_CHARGE    ");
                    sbQuery.Append("        , PPP.PART_CODE    ");
                    sbQuery.Append("        , PPP.USE_QTY    ");
                    sbQuery.Append("        , PPP.SCOMMENT    ");
                    sbQuery.Append("        , LSP.PART_NAME    ");
                    sbQuery.Append("  FROM THIS_PM_PLAN PP      ");
                    sbQuery.Append("    LEFT JOIN THIS_PM_ACT PA     ");
                    sbQuery.Append("        ON PP.PLT_CODE = PA.PLT_CODE     ");
                    sbQuery.Append("        AND PP.MTN_CODE = PA.MTN_CODE     ");
                    sbQuery.Append("        AND PP.MC_CODE = PA.MC_CODE     ");
                    sbQuery.Append("        AND PP.PLN_DATE = PA.PLN_DATE     ");
                    sbQuery.Append("    LEFT JOIN THIS_STD_PM SP     ");
                    sbQuery.Append("        ON PP.PLT_CODE = SP.PLT_CODE     ");
                    sbQuery.Append("        AND PP.MTN_CODE = SP.MTN_CODE     ");
                    sbQuery.Append("    LEFT JOIN LSE_MACHINE MC     ");
                    sbQuery.Append("        ON PP.PLT_CODE = MC.PLT_CODE     ");
                    sbQuery.Append("        AND PP.MC_CODE = MC.MC_CODE     ");

                    sbQuery.Append("    LEFT JOIN THIS_PM_PLAN_PARTS PPP     ");
                    sbQuery.Append("        ON PP.PLT_CODE = PPP.PLT_CODE     ");
                    sbQuery.Append("        AND PP.MTN_CODE = PPP.MTN_CODE     ");
                    sbQuery.Append("        AND PP.MC_CODE = PPP.MC_CODE     ");
                    sbQuery.Append("        AND PP.PLN_DATE = PPP.PLAN_DATE     ");
                    sbQuery.Append("    LEFT JOIN LSE_STD_PART LSP     ");
                    sbQuery.Append("        ON PPP.PLT_CODE = LSP.PLT_CODE     ");
                    sbQuery.Append("        AND PPP.PART_CODE = LSP.PART_CODE     ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE PP.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@MTN_CODE", "PP.MTN_CODE = @MTN_CODE "));
                        sbWhere.Append(UTIL.GetWhere(row, "@MC_CODE", "PP.MC_CODE = @MC_CODE "));
                        sbWhere.Append(UTIL.GetWhere(row, "@YEAR", "YEAR(PP.PLN_DATE) = @YEAR "));

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

        public static DataTable THIS_PM_PLAN_QUERY2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    //sbQuery.Append(" SELECT PP.PLT_CODE															  ");
                    //sbQuery.Append(" 	 , PP.MTN_CODE															  ");
                    //sbQuery.Append(" 	 , SP.MTN_NAME															  ");
                    //sbQuery.Append(" 	 , LM.MC_CODE															  ");
                    //sbQuery.Append(" 	 , LM.MC_NAME															  ");
                    //sbQuery.Append(" 	 , PP.PLN_DATE															  ");
                    //sbQuery.Append(" 	 , PP.ACT_DATE															  ");
                    //sbQuery.Append(" 	 , PP.NEXT_PLN_DATE														  ");
                    //sbQuery.Append(" 	 , ISNULL(MP.IS_NOT_ENOUGH,0) AS IS_NOT_ENOUGH  						  ");
                    //sbQuery.Append("   FROM THIS_PM_PLAN PP														  ");
                    //sbQuery.Append(" 	INNER JOIN (SELECT PLT_CODE, MTN_CODE, MC_CODE, MIN(PLN_DATE) AS PLN_DATE ");
                    //sbQuery.Append(" 				  FROM THIS_PM_PLAN											  ");
                    //sbQuery.Append(" 				 WHERE DATEPART(YEAR,PLN_DATE) = @YEAR						  ");
                    //sbQuery.Append(" 				    AND ((CONVERT(VARCHAR(8), GETDATE(),112) >= PLN_DATE AND ACT_DATE IS NULL)		  ");
                    //sbQuery.Append(" 				        OR (CONVERT(VARCHAR(8), GETDATE(),112) < PLN_DATE))		  ");
                    //sbQuery.Append(" 				    AND PLT_CODE = @PLT_CODE		  ");
                    //sbQuery.Append(" 				 GROUP BY PLT_CODE, MTN_CODE, MC_CODE) MPP					  ");
                    //sbQuery.Append(" 		ON PP.PLT_CODE = MPP.PLT_CODE										  ");
                    //sbQuery.Append(" 		AND PP.MTN_CODE = MPP.MTN_CODE										  ");
                    //sbQuery.Append(" 		AND PP.MC_CODE = MPP.MC_CODE										  ");
                    //sbQuery.Append(" 		AND PP.PLN_DATE = MPP.PLN_DATE										  ");
                    //sbQuery.Append(" 	INNER JOIN THIS_STD_PM SP												  ");
                    //sbQuery.Append(" 		ON PP.PLT_CODE = SP.PLT_CODE										  ");
                    //sbQuery.Append(" 		AND PP.MTN_CODE = SP.MTN_CODE										  ");
                    //sbQuery.Append(" 	INNER JOIN LSE_MACHINE LM												  ");
                    //sbQuery.Append(" 		ON PP.PLT_CODE = LM.PLT_CODE										  ");
                    //sbQuery.Append(" 		AND PP.MC_CODE = LM.MC_CODE											  ");
                    //sbQuery.Append(" 	LEFT JOIN (SELECT PMP.PLT_CODE	");
                    //sbQuery.Append(" 					 , PMP.MTN_CODE	");
                    //sbQuery.Append(" 					 , PMP.MC_CODE	");
                    //sbQuery.Append(" 					 , MAX(CASE WHEN SP.STK_COMPLETE - PMP.USE_QTY < 0 THEN 1 ELSE 0 END) AS IS_NOT_ENOUGH	");
                    //sbQuery.Append(" 					FROM THIS_PM_MC_PARTS PMP	");
                    //sbQuery.Append(" 						INNER JOIN LSE_STD_PART SP	");
                    //sbQuery.Append(" 							ON PMP.PLT_CODE = SP.PLT_CODE	");
                    //sbQuery.Append(" 							AND PMP.PART_CODE = SP.PART_CODE	");
                    //sbQuery.Append(" 				GROUP BY PMP.PLT_CODE	");
                    //sbQuery.Append(" 					   , PMP.MTN_CODE	");
                    //sbQuery.Append(" 					   , PMP.MC_CODE) AS MP	");
                    //sbQuery.Append(" 		ON PP.PLT_CODE = MP.PLT_CODE	");
                    //sbQuery.Append(" 		AND PP.MTN_CODE = MP.MTN_CODE	");
                    //sbQuery.Append(" 		AND PP.MC_CODE = MP.MC_CODE	");

                    sbQuery.Append(" SELECT PP.PLT_CODE													");
                    sbQuery.Append(" 	 , PP.MTN_CODE													");
                    sbQuery.Append(" 	 , SP.MTN_NAME													");
                    sbQuery.Append(" 	 , LM.MC_CODE													");
                    sbQuery.Append(" 	 , LM.MC_NAME													");
                    sbQuery.Append(" 	 , PP.PLN_DATE													");
                    sbQuery.Append(" 	 , PP.ACT_DATE													");
                    sbQuery.Append(" 	 , PP.ACT_DATE AS PM_DATE													");
                    sbQuery.Append(" 	 , PP.NEXT_PLN_DATE												");
                    sbQuery.Append(" 	 , ISNULL(MP.IS_NOT_ENOUGH,0) AS IS_NOT_ENOUGH  				");
                    sbQuery.Append("   FROM THIS_PM_PLAN PP												");
                    sbQuery.Append(" 	INNER JOIN (SELECT  PLT_CODE									");
                    sbQuery.Append(" 					, MTN_CODE										");
                    sbQuery.Append(" 					, MC_CODE										");
                    sbQuery.Append(" 					, MIN(PLN_DATE) AS PLN_DATE						");
                    sbQuery.Append(" 				FROM 												");
                    sbQuery.Append(" 						(SELECT PLT_CODE							");
                    sbQuery.Append(" 							, MTN_CODE								");
                    sbQuery.Append(" 							, MC_CODE								");
                    sbQuery.Append(" 							, MAX(PLN_DATE) AS PLN_DATE 			");
                    sbQuery.Append(" 						  FROM THIS_PM_PLAN							");
                    sbQuery.Append(" 						 WHERE DATEPART(YEAR,PLN_DATE) = @YEAR		");
                    sbQuery.Append(" 							AND (CONVERT(VARCHAR(8), GETDATE(),112) >= PLN_DATE AND ACT_DATE IS NULL)		");
                    sbQuery.Append(" 							AND PLT_CODE = @PLT_CODE		  			");
                    sbQuery.Append(" 						 GROUP BY PLT_CODE, MTN_CODE, MC_CODE		");
                    sbQuery.Append(" 						 UNION										");
                    sbQuery.Append(" 						 SELECT PLT_CODE							");
                    sbQuery.Append(" 							, MTN_CODE								");
                    sbQuery.Append(" 							, MC_CODE								");
                    sbQuery.Append(" 							, MIN(PLN_DATE) AS PLN_DATE 			");
                    sbQuery.Append(" 						  FROM THIS_PM_PLAN							");
                    sbQuery.Append(" 						 WHERE DATEPART(YEAR,PLN_DATE) = @YEAR		");
                    sbQuery.Append(" 							AND (CONVERT(VARCHAR(8), GETDATE(),112) < PLN_DATE)	  							");
                    sbQuery.Append(" 							AND PLT_CODE = @PLT_CODE		  			");
                    sbQuery.Append(" 						 GROUP BY PLT_CODE, MTN_CODE, MC_CODE) SMP	");
                    sbQuery.Append(" 					GROUP BY PLT_CODE, MTN_CODE, MC_CODE			");
                    sbQuery.Append(" 				 ) MPP					  							");
                    sbQuery.Append(" 		ON PP.PLT_CODE = MPP.PLT_CODE								");
                    sbQuery.Append(" 		AND PP.MTN_CODE = MPP.MTN_CODE								");
                    sbQuery.Append(" 		AND PP.MC_CODE = MPP.MC_CODE								");
                    sbQuery.Append(" 		AND PP.PLN_DATE = MPP.PLN_DATE								");
                    sbQuery.Append(" 	INNER JOIN THIS_STD_PM SP										");
                    sbQuery.Append(" 		ON PP.PLT_CODE = SP.PLT_CODE								");
                    sbQuery.Append(" 		AND PP.MTN_CODE = SP.MTN_CODE								");
                    sbQuery.Append(" 	INNER JOIN LSE_MACHINE LM										");
                    sbQuery.Append(" 		ON PP.PLT_CODE = LM.PLT_CODE								");
                    sbQuery.Append(" 		AND PP.MC_CODE = LM.MC_CODE									");
                    sbQuery.Append(" 	LEFT JOIN (SELECT PMP.PLT_CODE									");
                    sbQuery.Append(" 					 , PMP.MTN_CODE									");
                    sbQuery.Append(" 					 , PMP.MC_CODE									");
                    sbQuery.Append(" 					 , MAX(CASE WHEN SP.STK_COMPLETE - PMP.USE_QTY < 0 THEN 1 ELSE 0 END) AS IS_NOT_ENOUGH	");
                    sbQuery.Append(" 					FROM THIS_PM_MC_PARTS PMP						");
                    sbQuery.Append(" 						INNER JOIN LSE_STD_PART SP					");
                    sbQuery.Append(" 							ON PMP.PLT_CODE = SP.PLT_CODE			");
                    sbQuery.Append(" 							AND PMP.PART_CODE = SP.PART_CODE		");
                    sbQuery.Append(" 				GROUP BY PMP.PLT_CODE								");
                    sbQuery.Append(" 					   , PMP.MTN_CODE								");
                    sbQuery.Append(" 					   , PMP.MC_CODE) AS MP							");
                    sbQuery.Append(" 		ON PP.PLT_CODE = MP.PLT_CODE								");
                    sbQuery.Append(" 		AND PP.MTN_CODE = MP.MTN_CODE								");
                    sbQuery.Append(" 		AND PP.MC_CODE = MP.MC_CODE									");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "YEAR")) isHasColumn = false;

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

        public static DataTable THIS_PM_PLAN_QUERY3(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT 														  ");
                    sbQuery.Append(" 	STUFF((														  ");
                    sbQuery.Append(" 	 SELECT CAST(',' AS VARCHAR(MAX)) + SP.MTN_NAME				  ");
                    sbQuery.Append(" 		FROM THIS_PM_PLAN PP									  ");
                    sbQuery.Append(" 			INNER JOIN THIS_STD_PM SP							  ");
                    sbQuery.Append(" 				ON PP.PLT_CODE = SP.PLT_CODE					  ");
                    sbQuery.Append(" 				AND PP.MTN_CODE = SP.MTN_CODE					  ");
                    sbQuery.Append(" 		WHERE PP.PLT_CODE = @PLT_CODE AND PP.MC_CODE = @MC_CODE 								  ");
                    sbQuery.Append(" 			AND CONVERT(VARCHAR, GETDATE(), 112) > dateadd(HH,9,convert(datetime,pln_date))  ");
                    sbQuery.Append(" 			AND PP.ACT_DATE IS NULL								  ");
                    sbQuery.Append(" 	 GROUP BY SP.MTN_NAME										  ");
                    sbQuery.Append(" FOR XML PATH('')), 1, 1, '') AS MTN_NAMES						  ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "MC_CODE")) isHasColumn = false;

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

    }
}
