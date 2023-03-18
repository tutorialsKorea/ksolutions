using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace DORD
{
    public class TORD_GOAL_YEAR
    {
        public static DataTable TORD_GOAL_YEAR_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {

            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT PLT_CODE ");
                    sbQuery.Append(" ,CVND_CODE ");
                    sbQuery.Append(" ,GOAL_Y ");                    
                    sbQuery.Append(" ,EX_DL ");
                    sbQuery.Append(" ,EX_YEN ");
                    sbQuery.Append(" ,EX_DONG ");
                    sbQuery.Append(" ,REG_DATE ");
                    sbQuery.Append(" ,REG_EMP ");                    
                    sbQuery.Append(" FROM TORD_GOAL_YEAR ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND GOAL_YM = @GOAL_YM ");
                    sbQuery.Append(" AND CVND_CODE = @CVND_CODE ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "GOAL_Y")) isHasColumn = false;

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
        /// 2022.01.28 pkd 
        /// </summary>
        /// <param name="dtParam"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataTable TORD_GOAL_YEAR_SER2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {

            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT PLT_CODE ");
                    sbQuery.Append(" ,PLT_CODE ");
                    sbQuery.Append(" ,GOAL_EMP ");
                    sbQuery.Append(" ,GOAL_Y ");
                    sbQuery.Append(" ,REG_DATE ");
                    sbQuery.Append(" ,REG_EMP ");
                    sbQuery.Append(" FROM TORD_GOAL_YEAR ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND GOAL_Y = @GOAL_Y ");
                    sbQuery.Append(" AND GOAL_EMP = @GOAL_EMP ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "GOAL_Y")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "GOAL_EMP")) isHasColumn = false;

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





        public static void TORD_GOAL_YEAR_UPD(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" UPDATE TORD_GOAL_YEAR		   ");
                    sbQuery.Append(" SET EX_DL = @EX_DL			   ");
                    sbQuery.Append(" , EX_YEN = @EX_YEN			   ");
                    sbQuery.Append(" , EX_DONG = @EX_DONG		   ");
                    sbQuery.Append(" , MDFY_DATE = GETDATE()	   ");
                    sbQuery.Append(" , MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE	   ");
                    sbQuery.Append(" AND GOAL_Y = @GOAL_Y");


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



        public static void TORD_GOAL_YEAR_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" INSERT INTO TORD_GOAL_YEAR");
                    sbQuery.Append(" (PLT_CODE				  ");
                    sbQuery.Append(" ,GOAL_Y				  ");
                    sbQuery.Append(" ,GOAL_EMP		          ");
                    sbQuery.Append(" ,REG_DATE				  ");
                    sbQuery.Append(" ,REG_EMP)				  ");
                    sbQuery.Append(" VALUES					  ");
                    sbQuery.Append(" (@PLT_CODE				  ");
                    sbQuery.Append(" ,@GOAL_Y				  ");
                    sbQuery.Append(" ,@GOAL_EMP			      ");
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



        public static void TORD_GOAL_YEAR_INS_OLD(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" INSERT INTO TORD_GOAL_YEAR");
                    sbQuery.Append(" (PLT_CODE				  ");                    
                    sbQuery.Append(" ,GOAL_Y				  ");
                    sbQuery.Append(" ,EX_DL					  ");
                    sbQuery.Append(" ,EX_YEN				  ");
                    sbQuery.Append(" ,EX_DONG				  ");
                    sbQuery.Append(" ,REG_DATE				  ");
                    sbQuery.Append(" ,REG_EMP)				  ");
                    sbQuery.Append(" VALUES					  ");
                    sbQuery.Append(" (@PLT_CODE				  ");
                    sbQuery.Append(" ,@GOAL_Y				  ");                    
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


        public static void TORD_GOAL_YEAR_DEL(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {

            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" DELETE FROM TORD_GOAL_YEAR	   ");                   
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND GOAL_Y = @GOAL_Y	   ");

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


        /// <summary>
        /// 22.01.28 pkd
        /// </summary>
        /// <param name="dtParam"></param>
        /// <param name="bizExecute"></param>
        public static void TORD_GOAL_YEAR_DEL2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {

            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" DELETE FROM TORD_GOAL_YEAR	  ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append(" AND GOAL_EMP = @GOAL_EMP	");
                    sbQuery.Append(" AND GOAL_Y = @GOAL_Y	   ");

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


    }

    public class TORD_GOAL_YEAR_QUERY
    {
        //연도별 목표금액 조회
        public static DataTable TORD_GOAL_YEAR_QUERY1_OLD(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT ");
                    sbQuery.Append(" Y.PLT_CODE ");
                    sbQuery.Append(" ,Y.GOAL_Y ");
                    sbQuery.Append(" ,SUM(G.GOAL_AMT) AS Y_GOAL_AMT");
                    sbQuery.Append(" ,Y.EX_DL ");
                    sbQuery.Append(" ,Y.EX_YEN ");
                    sbQuery.Append(" ,Y.EX_DONG ");
                    sbQuery.Append(" FROM TORD_GOAL_YEAR Y ");
                    sbQuery.Append(" LEFT JOIN TORD_GOAL_AMT G ");
                    sbQuery.Append(" ON Y.PLT_CODE = G.PLT_CODE ");
                    sbQuery.Append(" AND Y.GOAL_Y = substring(G.GOAL_YM,1,4) ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE Y.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                        sbWhere.Append(UTIL.GetWhere(row, "@S_GOAL_Y,@E_GOAL_Y", "Y.GOAL_Y BETWEEN @S_GOAL_Y AND @E_GOAL_Y"));                        
                        sbWhere.Append(UTIL.GetWhere(row, "@GOAL_Y", "Y.GOAL_Y = @GOAL_Y"));
                        sbWhere.Append(UTIL.GetWhere(row, "@YEAR", "Y.GOAL_Y = @YEAR"));

                        sbWhere.Append(" GROUP BY Y.PLT_CODE");
                        sbWhere.Append(" ,Y.GOAL_Y ");
                        sbWhere.Append(" ,Y.EX_DL ");
                        sbWhere.Append(" ,Y.EX_YEN ");
                        sbWhere.Append(" ,Y.EX_DONG ");

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



        //연도별 목표금액 조회
        public static DataTable TORD_GOAL_YEAR_QUERY1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT ");
                    sbQuery.Append(" G.PLT_CODE  ");
                    sbQuery.Append(" ,G.GOAL_EMP  ");
                    sbQuery.Append(" ,V.BVEN_NAME AS GOAL_EMP_NAME  ");
                    sbQuery.Append(" ,LEFT(G.GOAL_YM,4) AS GOAL_Y ");
                    sbQuery.Append(" ,SUM(G.WON) AS WON ");
                    sbQuery.Append(" ,SUM(G.EX_DL) AS EX_DL ");
                    sbQuery.Append(" ,SUM(G.EX_YEN) AS EX_YEN ");
                    sbQuery.Append(" ,SUM(G.EX_DONG) AS EX_DONG ");
                    sbQuery.Append(" FROM TORD_GOAL_AMT G ");

                    sbQuery.Append(" LEFT JOIN TSTD_BILL_VENDOR V ");
                    sbQuery.Append(" ON G.PLT_CODE = V.PLT_CODE ");
                    sbQuery.Append(" AND G.GOAL_EMP = V.BVEN_CODE ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE G.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                        sbWhere.Append(UTIL.GetWhere(row, "@S_GOAL_Y,@E_GOAL_Y", "LEFT(G.GOAL_YM,4) BETWEEN @S_GOAL_Y AND @E_GOAL_Y"));

                        sbWhere.Append(" GROUP BY G.PLT_CODE");
                        sbWhere.Append(" ,G.GOAL_EMP ");
                        sbWhere.Append(" ,V.BVEN_NAME ");
                        sbWhere.Append(" ,LEFT(G.GOAL_YM,4)");

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





        public static DataTable TORD_GOAL_YEAR_QUERY2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT						 ");
                    sbQuery.Append(" PLT_CODE					 ");
                    sbQuery.Append(" ,GOAL_Y	 ");
                    sbQuery.Append(" FROM TORD_GOAL_YEAR			 ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                        sbWhere.Append(UTIL.GetWhere(row, "@S_GOAL_Y,@E_GOAL_Y", "GOAL_Y BETWEEN @S_GOAL_Y AND @E_GOAL_Y"));
                        sbWhere.Append(UTIL.GetWhere(row, "@GOAL_Y", "GOAL_Y = @GOAL_Y"));

                        sbWhere.Append(" GROUP BY PLT_CODE");
                        sbWhere.Append(" ,GOAL_Y ");

                        sbWhere.Append(" ORDER BY GOAL_Y DESC ");

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

        public static DataTable TORD_GOAL_YEAR_QUERY3(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT ");
                    sbQuery.Append(" G.PLT_CODE  ");
                    sbQuery.Append(" ,LEFT(G.GOAL_YM,4) AS GOAL_Y ");
                    sbQuery.Append(" ,SUM(G.WON) AS WON ");
                    sbQuery.Append(" ,SUM(G.EX_DL) AS EX_DL ");
                    sbQuery.Append(" ,SUM(G.EX_YEN) AS EX_YEN ");
                    sbQuery.Append(" ,SUM(G.EX_DONG) AS EX_DONG ");
                    sbQuery.Append(" FROM TORD_GOAL_AMT G ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE G.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                        sbWhere.Append(UTIL.GetWhere(row, "@S_GOAL_Y,@E_GOAL_Y", "LEFT(G.GOAL_YM,4) BETWEEN @S_GOAL_Y AND @E_GOAL_Y"));

                        sbWhere.Append(" GROUP BY G.PLT_CODE");
                        sbWhere.Append(" ,LEFT(G.GOAL_YM,4)");

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
