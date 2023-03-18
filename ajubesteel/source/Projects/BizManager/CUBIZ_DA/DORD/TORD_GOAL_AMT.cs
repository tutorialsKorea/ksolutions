using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace DORD
{
    public class TORD_GOAL_AMT
    {
        public static DataTable TORD_GOAL_AMT_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {

            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT PLT_CODE ");
                    sbQuery.Append(" ,CVND_CODE ");
                    sbQuery.Append(" ,GOAL_YM ");
                    sbQuery.Append(" ,GOAL_AMT ");
                    sbQuery.Append(" ,EX_DL ");
                    sbQuery.Append(" ,EX_YEN ");
                    sbQuery.Append(" ,EX_DONG ");
                    sbQuery.Append(" ,REG_DATE ");
                    sbQuery.Append(" ,REG_EMP ");                    
                    sbQuery.Append(" FROM TORD_GOAL_AMT ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND GOAL_YM = @GOAL_YM ");
                    sbQuery.Append(" AND CVND_CODE = @CVND_CODE ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "GOAL_YM")) isHasColumn = false;

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
        /// 22.01.28 pkd
        /// </summary>
        /// <param name="dtParam"></param>
        /// <param name="bizExecute"></param>
        public static void TORD_GOAL_AMT_DEL2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {

            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" DELETE FROM TORD_GOAL_AMT	   ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND GOAL_EMP = @GOAL_EMP ");
                    sbQuery.Append(" AND LEFT(GOAL_YM,4) = @GOAL_Y ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "GOAL_EMP")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "GOAL_Y")) isHasColumn = false;

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





        public static void TORD_GOAL_AMT_UPD(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" UPDATE TORD_GOAL_AMT		   ");
                    sbQuery.Append(" SET EX_DL = @EX_DL			   ");
                    sbQuery.Append(" , EX_YEN = @EX_YEN			   ");
                    sbQuery.Append(" , EX_DONG = @EX_DONG		   ");
                    sbQuery.Append(" , MDFY_DATE = GETDATE()	   ");
                    sbQuery.Append(" , MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE	   ");
                    sbQuery.Append(" AND LEFT(GOAL_YM,4) = @GOAL_Y");


                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "GOAL_Y")) isHasColumn = false;

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

        public static void TORD_GOAL_AMT_UPD2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {

            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" UPDATE TORD_GOAL_AMT	   ");
                    sbQuery.Append(" SET GOAL_AMT = @GOAL_AMT  ");
                    sbQuery.Append(" , MDFY_DATE = GETDATE()	   ");
                    sbQuery.Append(" , MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND GOAL_YM = @GOAL_YM	   ");
                    sbQuery.Append(" AND GROUP_CODE = @GROUP_CODE	   ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "GOAL_YM")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "GROUP_CODE")) isHasColumn = false;

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



        public static void TORD_GOAL_AMT_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" INSERT INTO TORD_GOAL_AMT");
                    sbQuery.Append(" (PLT_CODE				  ");
                    sbQuery.Append(" ,GOAL_EMP				  ");
                    sbQuery.Append(" ,GOAL_YM				  ");
                    sbQuery.Append(" ,WON					  ");
                    sbQuery.Append(" ,EX_DL					  ");
                    sbQuery.Append(" ,EX_YEN				  ");
                    sbQuery.Append(" ,EX_DONG				  ");
                    sbQuery.Append(" ,REG_DATE				  ");
                    sbQuery.Append(" ,REG_EMP)				  ");
                    sbQuery.Append(" VALUES					  ");
                    sbQuery.Append(" (@PLT_CODE				  ");
                    sbQuery.Append(" ,@GOAL_EMP			      ");
                    sbQuery.Append(" ,@GOAL_YM				  ");
                    sbQuery.Append(" ,@WON  				  ");
                    sbQuery.Append(" ,@EX_DL				  ");
                    sbQuery.Append(" ,@EX_YEN				  ");
                    sbQuery.Append(" ,@EX_DONG				  ");
                    sbQuery.Append(" ,GETDATE()				  ");
                    sbQuery.Append("     , " + UTIL.GetValidValue(ConnInfo.UserID));
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




        public static void TORD_GOAL_AMT_INS_OLD(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" INSERT INTO TORD_GOAL_AMT");
                    sbQuery.Append(" (PLT_CODE				  ");                    
                    sbQuery.Append(" ,CVND_CODE				  ");
                    sbQuery.Append(" ,GOAL_YM				  ");
                    sbQuery.Append(" ,GOAL_AMT				  ");
                    sbQuery.Append(" ,EX_DL					  ");
                    sbQuery.Append(" ,EX_YEN				  ");
                    sbQuery.Append(" ,EX_DONG				  ");
                    sbQuery.Append(" ,REG_DATE				  ");
                    sbQuery.Append(" ,REG_EMP)				  ");
                    sbQuery.Append(" VALUES					  ");
                    sbQuery.Append(" (@PLT_CODE				  ");
                    sbQuery.Append(" ,@CVND_CODE			  ");
                    sbQuery.Append(" ,@GOAL_YM				  ");
                    sbQuery.Append(" ,@GOAL_AMT				  ");
                    sbQuery.Append(" ,@EX_DL				  ");
                    sbQuery.Append(" ,@EX_YEN				  ");
                    sbQuery.Append(" ,@EX_YURO				  ");
                    sbQuery.Append(" ,GETDATE()				  ");
                    sbQuery.Append("     , " + UTIL.GetValidValue(ConnInfo.UserID));
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


        public static void TORD_GOAL_AMT_DEL(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {

            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" DELETE FROM TORD_GOAL_AMT	   ");                   
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND SUBSTRING(GOAL_YM,1,4) = @GOAL_Y	   ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "GOAL_Y")) isHasColumn = false;
                        
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

    public class TORD_GOAL_AMT_QUERY
    {
        /// <summary>
        /// 연도별 목표금액 조회
        /// </summary>
        /// <param name="dtParam"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataTable TORD_GOAL_AMT_QUERY1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT ");
                    sbQuery.Append(" G.PLT_CODE ");
                    sbQuery.Append(" ,LEFT(G.GOAL_YM,4) AS GOAL_Y	 ");
                    sbQuery.Append(" ,SUM(G.GOAL_AMT) AS Y_GOAL_AMT");
                    sbQuery.Append(" ,Y.EX_DL ");
                    sbQuery.Append(" ,Y.EX_YEN ");
                    sbQuery.Append(" ,Y.EX_DONG ");
                    sbQuery.Append(" FROM TORD_GOAL_AMT	G ");
                    sbQuery.Append(" LEFT JOIN TORD_GOAL_YEAR Y ");
                    sbQuery.Append(" ON Y.PLT_CODE = G.PLT_CODE ");
                    sbQuery.Append(" AND Y.GOAL_Y = substring(G.GOAL_YM,1,4) ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE G.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                        sbWhere.Append(UTIL.GetWhere(row, "@S_GOAL_Y,@E_GOAL_Y", "LEFT(G.GOAL_YM,4) BETWEEN @S_GOAL_Y AND @E_GOAL_Y"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_SALECONFM_DATE,@E_SALECONFM_DATE", "LEFT(G.GOAL_YM,4) BETWEEN LEFT(@S_SALECONFM_DATE,4) AND LEFT(@E_SALECONFM_DATE,4) "));
                        sbWhere.Append(UTIL.GetWhere(row, "@GOAL_Y", "LEFT(G.GOAL_YM,4) = @GOAL_Y"));
                        sbWhere.Append(UTIL.GetWhere(row, "@YEAR", "LEFT(G.GOAL_YM,4) = @YEAR"));

                        sbWhere.Append(" GROUP BY G.PLT_CODE");
                        sbWhere.Append(" ,LEFT(G.GOAL_YM,4) ");
                        sbWhere.Append(" ,Y.EX_DL			  ");
                        sbWhere.Append(" ,Y.EX_YEN		  ");
                        sbWhere.Append(" ,Y.EX_DONG		  ");

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
        /// 월별 목표금액 조회
        /// </summary>
        /// <param name="dtParam"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataTable TORD_GOAL_AMT_QUERY2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT ");
                    sbQuery.Append(" G.PLT_CODE ");
                    sbQuery.Append(" ,G.GOAL_YM	 ");
                    sbQuery.Append(" ,G.GOAL_YM	AS GOAL_M ");
                    sbQuery.Append(" ,SUM(G.GOAL_AMT) AS M_GOAL_AMT");
                    sbQuery.Append(" ,Y.EX_DL ");
                    sbQuery.Append(" ,Y.EX_YEN ");
                    sbQuery.Append(" ,Y.EX_DONG ");
                    sbQuery.Append(" FROM TORD_GOAL_AMT	G ");
                    sbQuery.Append(" LEFT JOIN TORD_GOAL_YEAR Y ");
                    sbQuery.Append(" ON Y.PLT_CODE = G.PLT_CODE ");
                    sbQuery.Append(" AND Y.GOAL_Y = substring(G.GOAL_YM,1,4) ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE G.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                        sbWhere.Append(UTIL.GetWhere(row, "@S_GOAL_Y,@E_GOAL_Y", "LEFT(G.GOAL_YM,4) BETWEEN @S_GOAL_Y AND @E_GOAL_Y"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_SALECONFM_DATE,@E_SALECONFM_DATE", "LEFT(G.GOAL_YM,4) BETWEEN LEFT(@S_SALECONFM_DATE,4) AND LEFT(@E_SALECONFM_DATE,4) "));
                        sbWhere.Append(UTIL.GetWhere(row, "@GOAL_Y", "LEFT(G.GOAL_YM,4) = @GOAL_Y"));
                        sbWhere.Append(UTIL.GetWhere(row, "@YEAR", "LEFT(G.GOAL_YM,4) = @YEAR"));

                        sbWhere.Append(" GROUP BY G.PLT_CODE");
                        sbWhere.Append(" ,G.GOAL_YM ");
                        sbWhere.Append(" ,Y.EX_DL			  ");
                        sbWhere.Append(" ,Y.EX_YEN		  ");
                        sbWhere.Append(" ,Y.EX_DONG		  ");

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
        /// 업체별 월별 목표금액 조회
        /// </summary>
        /// <param name="dtParam"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataTable TORD_GOAL_AMT_QUERY3(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT ");
                    sbQuery.Append(" G.PLT_CODE ");
                    sbQuery.Append(" ,G.CVND_CODE ");
                    sbQuery.Append(" ,V.VEN_NAME AS CVND_NAME ");
                    sbQuery.Append(" ,G.GOAL_YM ");
                    sbQuery.Append(" ,G.GOAL_AMT ");
                    sbQuery.Append(" ,Y.EX_DL ");
                    sbQuery.Append(" ,Y.EX_YEN ");
                    sbQuery.Append(" ,Y.EX_DONG ");
                    sbQuery.Append(" FROM TORD_GOAL_AMT G ");
                    sbQuery.Append(" LEFT JOIN TORD_GOAL_YEAR Y ");
                    sbQuery.Append(" ON Y.PLT_CODE = G.PLT_CODE ");
                    sbQuery.Append(" AND Y.GOAL_Y = substring(G.GOAL_YM,1,4) ");
                    sbQuery.Append(" LEFT JOIN TSTD_VENDOR V ");
                    sbQuery.Append(" ON G.PLT_CODE = V.PLT_CODE ");
                    sbQuery.Append(" AND G.CVND_CODE = V.VEN_CODE ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE G.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                        sbWhere.Append(UTIL.GetWhere(row, "@S_GOAL_Y,@E_GOAL_Y", "LEFT(G.GOAL_YM,4) BETWEEN @S_GOAL_Y AND @E_GOAL_Y"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_SALECONFM_DATE,@E_SALECONFM_DATE", "LEFT(G.GOAL_YM,4) BETWEEN LEFT(@S_SALECONFM_DATE,4) AND LEFT(@E_SALECONFM_DATE,4) "));
                        sbWhere.Append(UTIL.GetWhere(row, "@GOAL_Y", "LEFT(G.GOAL_YM,4) = @GOAL_Y"));
                        sbWhere.Append(UTIL.GetWhere(row, "@YEAR", "LEFT(G.GOAL_YM,4) = @YEAR"));


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
        /// 월별 목표금액 조회 22.01.28 pkd (신규추가)
        /// </summary>
        /// <param name="dtParam"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataTable TORD_GOAL_AMT_QUERY4(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT ");
                    sbQuery.Append("  G.PLT_CODE   ");
                    sbQuery.Append(" ,G.GOAL_EMP   ");
                    sbQuery.Append(" ,G.GOAL_YM    ");
                    sbQuery.Append(" ,G.WON        ");
                    sbQuery.Append(" ,G.EX_DL      ");
                    sbQuery.Append(" ,G.EX_YEN     ");
                    sbQuery.Append(" ,G.EX_DONG    ");
                    sbQuery.Append(" FROM TORD_GOAL_AMT	G ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE G.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@GOAL_EMP", "G.GOAL_EMP = @GOAL_EMP"));
                        sbWhere.Append(UTIL.GetWhere(row, "@YEAR", "LEFT(G.GOAL_YM,4) = @YEAR"));

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




        ////최근 연도 조회
        //public static DataTable TORD_GOAL_AMT_QUERY3(DataTable dtParam, BizExecute.BizExecute bizExecute)
        //{
        //    try
        //    {
        //        DataSet dsResult = new DataSet();

        //        if (dtParam.Rows.Count > 0)
        //        {
        //            StringBuilder sbQuery = new StringBuilder();

        //            sbQuery.Append(" SELECT						 ");
        //            sbQuery.Append(" PLT_CODE					 ");
        //            sbQuery.Append(" ,LEFT(GOAL_YM,4) AS GOAL_Y	 ");
        //            sbQuery.Append(" FROM TORD_GOAL_			 ");

        //            foreach (DataRow row in dtParam.Rows)
        //            {
        //                StringBuilder sbWhere = new StringBuilder(" WHERE PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
        //                sbWhere.Append(UTIL.GetWhere(row, "@S_GOAL_Y,@E_GOAL_Y", "LEFT(GOAL_YM,4) BETWEEN @S_GOAL_Y AND @E_GOAL_Y"));
        //                sbWhere.Append(UTIL.GetWhere(row, "@GOAL_Y", "LEFT(GOAL_YM,4) = @GOAL_Y"));

        //                sbWhere.Append(" GROUP BY PLT_CODE");
        //                sbWhere.Append(" ,LEFT(GOAL_YM,4) ");

        //                sbWhere.Append(" ORDER BY LEFT(GOAL_YM,4) DESC");

        //                DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString() + sbWhere.ToString()).Copy();

        //                sourceTable.TableName = "RSLTDT";
        //                dsResult.Merge(sourceTable);
        //            }
        //        }


        //        return UTIL.GetDsToDt(dsResult);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
        //    }
        //}

        ///// <summary>
        ///// 해당 연도 환율 가져오기        
        ///// 신재경 2017.08.22
        ///// </summary>
        ///// <param name="dtParam"></param>
        ///// <param name="bizExecute"></param>
        ///// <returns></returns>
        //public static DataTable TORD_GOAL_AMT_QUERY4(DataTable dtParam, BizExecute.BizExecute bizExecute)
        //{
        //    try
        //    {
        //        DataSet dsResult = new DataSet();

        //        if (dtParam.Rows.Count > 0)
        //        {
        //            StringBuilder sbQuery = new StringBuilder();

        //            sbQuery.Append(" SELECT TOP 1 ");
        //            sbQuery.Append(" EX_DL ");
        //            sbQuery.Append(" ,EX_YEN ");
        //            sbQuery.Append(" ,EX_DONG ");
        //            sbQuery.Append(" FROM TORD_GOAL_AMT ");

        //            foreach (DataRow row in dtParam.Rows)
        //            {
        //                StringBuilder sbWhere = new StringBuilder(" WHERE PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
        //                sbWhere.Append(UTIL.GetWhere(row, "@YEAR", "LEFT(GOAL_YM,4) = @YEAR"));

        //                DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString() + sbWhere.ToString()).Copy();

        //                sourceTable.TableName = "RSLTDT";
        //                dsResult.Merge(sourceTable);
        //            }
        //        }


        //        return UTIL.GetDsToDt(dsResult);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
        //    }
        //}


        ////월별 목표금액 조회
        //public static DataTable TORD_GOAL_AMT_QUERY5(DataTable dtParam, BizExecute.BizExecute bizExecute)
        //{
        //    try
        //    {
        //        DataSet dsResult = new DataSet();

        //        if (dtParam.Rows.Count > 0)
        //        {
        //            StringBuilder sbQuery = new StringBuilder();

        //            sbQuery.Append(" SELECT						");
        //            sbQuery.Append(" PLT_CODE					");
        //            sbQuery.Append(" ,GROUP_CODE				");
        //            sbQuery.Append(" ,GOAL_YM					");
        //            sbQuery.Append(" ,RIGHT(GOAL_YM,2) AS GOAL_M");
        //            sbQuery.Append(" ,GOAL_AMT					");
        //            sbQuery.Append(" FROM TORD_GOAL_AMT			");

        //            foreach (DataRow row in dtParam.Rows)
        //            {
        //                StringBuilder sbWhere = new StringBuilder(" WHERE PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
        //                sbWhere.Append(UTIL.GetWhere(row, "@GOAL_Y", "LEFT(GOAL_YM,4) = @GOAL_Y"));

        //                DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString() + sbWhere.ToString()).Copy();

        //                sourceTable.TableName = "RSLTDT";
        //                dsResult.Merge(sourceTable);
        //            }
        //        }


        //        return UTIL.GetDsToDt(dsResult);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
        //    }
        //}

        //public static DataTable TORD_GOAL_AMT_QUERY6(DataTable dtParam, BizExecute.BizExecute bizExecute)
        //{
        //    try
        //    {
        //        DataSet dsResult = new DataSet();

        //        if (dtParam.Rows.Count > 0)
        //        {
        //            StringBuilder sbQuery = new StringBuilder();

        //            sbQuery.Append(" SELECT						 ");
        //            sbQuery.Append(" PLT_CODE					 ");
        //            sbQuery.Append(" ,LEFT(GOAL_YM,6) AS GOAL_YM	 ");
        //            sbQuery.Append(" ,SUM(GOAL_AMT) AS Y_GOAL_AMT");
        //            sbQuery.Append(" ,EX_DL						 ");
        //            sbQuery.Append(" ,EX_YEN					 ");
        //            sbQuery.Append(" ,EX_DONG					 ");
        //            sbQuery.Append(" FROM TORD_GOAL_AMT			 ");

        //            foreach (DataRow row in dtParam.Rows)
        //            {
        //                StringBuilder sbWhere = new StringBuilder(" WHERE PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
        //                sbWhere.Append(UTIL.GetWhere(row, "@S_GOAL_Y,@E_GOAL_Y", "LEFT(GOAL_YM,4) BETWEEN @S_GOAL_Y AND @E_GOAL_Y"));
        //                sbWhere.Append(UTIL.GetWhere(row, "@S_SALECONFM_DATE,@E_SALECONFM_DATE", "LEFT(GOAL_YM,4) BETWEEN LEFT(@S_SALECONFM_DATE,4) AND LEFT(@E_SALECONFM_DATE,4) "));
        //                sbWhere.Append(UTIL.GetWhere(row, "@GOAL_Y", "LEFT(GOAL_YM,4) = @GOAL_Y"));
        //                sbWhere.Append(UTIL.GetWhere(row, "@YEAR", "LEFT(GOAL_YM,4) = @YEAR"));

        //                if (UTIL.GetValidValue(row, "GROUP_GUBUN").ToString().Equals("'ALL'") == false)
        //                    sbWhere.Append(UTIL.GetWhere(row, "@GROUP_GUBUN", "GROUP_CODE = @GROUP_GUBUN"));

        //                sbWhere.Append(" GROUP BY PLT_CODE");
        //                sbWhere.Append(" ,LEFT(GOAL_YM,6) ");
        //                sbWhere.Append(" ,EX_DL			  ");
        //                sbWhere.Append(" ,EX_YEN		  ");
        //                sbWhere.Append(" ,EX_DONG		  ");

        //                DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString() + sbWhere.ToString()).Copy();

        //                sourceTable.TableName = "RSLTDT";
        //                dsResult.Merge(sourceTable);
        //            }
        //        }


        //        return UTIL.GetDsToDt(dsResult);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
        //    }
        //}


        ////업체별 월별 목표금액 조회
        //public static DataTable TORD_GOAL_AMT_QUERY7(DataTable dtParam, BizExecute.BizExecute bizExecute)
        //{
        //    try
        //    {
        //        DataSet dsResult = new DataSet();

        //        if (dtParam.Rows.Count > 0)
        //        {
        //            StringBuilder sbQuery = new StringBuilder();

        //            sbQuery.Append(" SELECT ");
        //            sbQuery.Append(" G.PLT_CODE ");
        //            sbQuery.Append(" ,G.CVND_CODE ");
        //            sbQuery.Append(" ,V.VEN_NAME AS CVND_NAME ");
        //            sbQuery.Append(" ,G.GOAL_YM ");
        //            sbQuery.Append(" ,G.GOAL_AMT ");
        //            sbQuery.Append(" ,G.EX_DL ");
        //            sbQuery.Append(" ,G.EX_YEN ");
        //            sbQuery.Append(" ,G.EX_DONG ");
        //            sbQuery.Append(" FROM TORD_GOAL_AMT G ");
        //            sbQuery.Append(" LEFT JOIN TSTD_VENDOR V ");
        //            sbQuery.Append(" ON G.PLT_CODE = V.PLT_CODE ");
        //            sbQuery.Append(" AND G.CVND_CODE = V.VEN_CODE ");

        //            foreach (DataRow row in dtParam.Rows)
        //            {
        //                StringBuilder sbWhere = new StringBuilder(" WHERE PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
        //                sbWhere.Append(UTIL.GetWhere(row, "@S_GOAL_Y,@E_GOAL_Y", "LEFT(GOAL_YM,4) BETWEEN @S_GOAL_Y AND @E_GOAL_Y"));
        //                sbWhere.Append(UTIL.GetWhere(row, "@S_SALECONFM_DATE,@E_SALECONFM_DATE", "LEFT(GOAL_YM,4) BETWEEN LEFT(@S_SALECONFM_DATE,4) AND LEFT(@E_SALECONFM_DATE,4) "));
        //                sbWhere.Append(UTIL.GetWhere(row, "@GOAL_Y", "LEFT(GOAL_YM,4) = @GOAL_Y"));
        //                sbWhere.Append(UTIL.GetWhere(row, "@YEAR", "LEFT(GOAL_YM,4) = @YEAR"));


        //                DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString() + sbWhere.ToString()).Copy();

        //                sourceTable.TableName = "RSLTDT";
        //                dsResult.Merge(sourceTable);
        //            }
        //        }


        //        return UTIL.GetDsToDt(dsResult);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
        //    }
        //}
    }

}
