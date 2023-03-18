using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using BizExecute;

namespace DSHP
{
    public class TSHP_WORKPLAN
    {
        public static DataTable TSHP_WORKPLAN_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT PLT_CODE ");
                    sbQuery.Append(" ,WP_NO");
                    sbQuery.Append(" ,WEEK_YEAR");
                    sbQuery.Append(" ,WEEK_NO");
                    sbQuery.Append(" ,PLN_START_DATE");
                    sbQuery.Append(" ,PLN_END_DATE");
                    sbQuery.Append(" ,PART_ID");
                    sbQuery.Append(" ,PART_CODE");
                    sbQuery.Append(" ,PLN_QTY");
                    sbQuery.Append(" ,ACT_QTY");
                    sbQuery.Append(" ,LAST_PROC_ID");
                    sbQuery.Append(" ,REG_DATE");
                    sbQuery.Append(" ,REG_EMP");
                    sbQuery.Append(" ,MDFY_DATE");
                    sbQuery.Append(" ,MDFY_EMP");
                    sbQuery.Append(" ,DATA_FLAG");
                    sbQuery.Append(" ,DEL_DATE");
                    sbQuery.Append(" ,DEL_EMP");
                    sbQuery.Append(" ,DEL_REASON");
                    sbQuery.Append(" FROM TSHP_WORKPLAN ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND WP_NO = @WP_NO");
                    
                    foreach (DataRow row in dtParam.Rows)
                    {
                        
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "WP_NO")) isHasColumn = false;

                        if (isHasColumn == true)
                        {                            

                            DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString(),row).Copy();

                            sourceTable.TableName = "RSLTDT";
                            dsResult.Merge(sourceTable);  
                        }
                    }
                }
                return UTIL.GetDsToDt(dsResult);
            }
            catch(Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }    
        }


        public static DataTable TSHP_WORKPLAN_SER2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT WP.PLT_CODE ");
                    sbQuery.Append(" ,WP.WP_NO");
                    sbQuery.Append(" ,WP.PROD_CODE");
                    sbQuery.Append(" ,WP.PART_CODE");
                    sbQuery.Append(" ,WP.STOCK_TYPE");
                    sbQuery.Append(" ,WP.STOCK_CODE");
                    sbQuery.Append(" ,WP.WEEK_YEAR");
                    sbQuery.Append(" ,WP.WEEK_NO");
                    sbQuery.Append(" ,WP.PLN_START_DATE");
                    sbQuery.Append(" ,WP.PLN_END_DATE");
                    sbQuery.Append(" ,WP.PART_ID");
                    sbQuery.Append(" ,WP.PART_CODE");
                    sbQuery.Append(" ,WP.P_QTY");
                    sbQuery.Append(" ,WP.T_QTY");
                    sbQuery.Append(" ,WP.B_QTY");
                    sbQuery.Append(" ,WP.PLN_QTY");
                    sbQuery.Append(" ,WP.ACT_QTY");
                    sbQuery.Append(" ,WP.LAST_PROC_ID");
                    sbQuery.Append(" ,WP.REG_DATE");
                    sbQuery.Append(" ,WP.REG_EMP");
                    sbQuery.Append(" ,WP.MDFY_DATE");
                    sbQuery.Append(" ,WP.MDFY_EMP");
                    sbQuery.Append(" ,WP.DATA_FLAG");
                    sbQuery.Append(" ,WP.DEL_DATE");
                    sbQuery.Append(" ,WP.DEL_EMP");
                    sbQuery.Append(" ,WP.DEL_REASON");
                    sbQuery.Append(" ,PART.IS_TURNING");
                    sbQuery.Append(" FROM TSHP_WORKPLAN WP");
                    sbQuery.Append("    INNER JOIN LSE_STD_PART PART");
                    sbQuery.Append("        ON WP.PLT_CODE = PART.PLT_CODE");
                    sbQuery.Append("        AND WP.PART_CODE = PART.PART_CODE");
                    sbQuery.Append(" WHERE WP.PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND WP.PROD_CODE = @PROD_CODE");
                    sbQuery.Append(" AND WP.PART_CODE = @PART_CODE");
                    sbQuery.Append(" AND WP.DATA_FLAG = 0 ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PROD_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PART_CODE")) isHasColumn = false;

                        if (isHasColumn == true)
                        {

                            DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString(), row).Copy();

                            sourceTable.TableName = "RSLTDT";
                            dsResult.Merge(sourceTable,false, MissingSchemaAction.Add);                            
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


        //데이터 삭제 상태 처리
        public static void TSHP_WORKPLAN_UPD(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append("UPDATE TSHP_WORKPLAN SET");
                    sbQuery.Append("  WEEK_YEAR = @WEEK_YEAR");
                    sbQuery.Append(" , WEEK_NO = @WEEK_NO");
                    sbQuery.Append(" , PLN_START_DATE = @PLN_START_DATE");
                    sbQuery.Append(" , PLN_END_DATE = @PLN_END_DATE");
                    sbQuery.Append(" , PLN_QTY = @PLN_QTY");
                    sbQuery.Append(" , P_QTY = @P_QTY");
                    sbQuery.Append(" , T_QTY = @T_QTY");
                    sbQuery.Append(" , B_QTY = @B_QTY");
                    sbQuery.Append(" , STOCK_CODE = @STOCK_CODE");
                    sbQuery.Append(" , STOCK_TYPE = @STOCK_TYPE");
                    sbQuery.Append(" , SCOMMENT = @SCOMMENT");
                    sbQuery.Append(" , PART_ID = @PART_ID");
                    sbQuery.Append(" , LAST_PROC_ID = @LAST_PROC_ID");
                    sbQuery.Append(" , MDFY_DATE = GETDATE()");
                    sbQuery.Append(" , MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" , DATA_FLAG = 0");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND WP_NO = @WP_NO");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "WP_NO")) isHasColumn = false;

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

        public static void TSHP_WORKPLAN_UPD2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append("UPDATE TSHP_WORKPLAN SET");
                    sbQuery.Append("  B_QTY = @B_QTY");
                    sbQuery.Append(" , MDFY_DATE = GETDATE()");
                    sbQuery.Append(" , MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" , DATA_FLAG = 0");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND WP_NO = @WP_NO");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "WP_NO")) isHasColumn = false;

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

        public static void TSHP_WORKPLAN_UPD3(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append("UPDATE TSHP_WORKPLAN SET");
                    sbQuery.Append("   PLN_QTY = @PLN_QTY");
                    sbQuery.Append(" , STOCK_TYPE = @STOCK_TYPE");
                    sbQuery.Append(" , STOCK_CODE = @STOCK_CODE");
                    sbQuery.Append(" , P_QTY = @P_QTY");
                    sbQuery.Append(" , T_QTY = @T_QTY");
                    sbQuery.Append(" , B_QTY = @B_QTY");
                    sbQuery.Append(" , PART_ID = @PART_ID");
                    sbQuery.Append(" , LAST_PROC_ID = @LAST_PROC_ID");
                    sbQuery.Append(" , MDFY_DATE = GETDATE()");
                    sbQuery.Append(" , MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" , DATA_FLAG = 0");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND WP_NO = @WP_NO");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "WP_NO")) isHasColumn = false;

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

        public static void TSHP_WORKPLAN_UPD4(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("UPDATE TSHP_WORKPLAN ");
                    sbQuery.Append(" SET PLN_QTY = ISNULL(B.PROD_QTY, 1) * ISNULL(B.BOM_QTY, 1) ");
                    
                    sbQuery.Append(" FROM TSHP_WORKPLAN W JOIN TORD_PRODUCT B ");
                    sbQuery.Append("   ON W.PLT_CODE = B.PLT_CODE ");
                    sbQuery.Append(" AND W.PROD_CODE = B.PROD_CODE ");
                    sbQuery.Append(" AND W.PART_CODE = B.PART_CODE  ");
                    sbQuery.Append(" WHERE W.PLT_CODE = @PLT_CODE "); 
                    sbQuery.Append("  AND W.PROD_CODE = @PROD_CODE ");
                    sbQuery.Append("  AND W.PART_CODE = @PART_CODE ");

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

        public static void TSHP_WORKPLAN_UPD5(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append("UPDATE TSHP_WORKPLAN SET");
                    sbQuery.Append("  USE_T_QTY = USE_T_QTY+ @PART_QTY");
                    sbQuery.Append(" , MDFY_DATE = GETDATE()");
                    sbQuery.Append(" , MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append("  AND PROD_CODE = @PROD_CODE ");
                    sbQuery.Append("  AND PART_CODE = @PART_CODE ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PROD_CODE")) isHasColumn = false;
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


        public static void TSHP_WORKPLAN_UPD6(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append("UPDATE TSHP_WORKPLAN SET");
                    sbQuery.Append("  USE_T_QTY = USE_T_QTY- @PART_QTY");
                    sbQuery.Append(" , MDFY_DATE = GETDATE()");
                    sbQuery.Append(" , MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append("  AND PROD_CODE = @PROD_CODE ");
                    sbQuery.Append("  AND PART_CODE = @PART_CODE ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PROD_CODE")) isHasColumn = false;
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

        //데이터 삭제 상태 처리
        public static void TSHP_WORKPLAN_UDE(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append("UPDATE TSHP_WORKPLAN SET");
                    sbQuery.Append("  DEL_DATE = GETDATE()");
                    sbQuery.Append(" , DEL_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" , DATA_FLAG = 2");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND WP_NO = @WP_NO");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "WP_NO")) isHasColumn = false;

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

        public static void TSHP_WORKPLAN_UDE2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append("UPDATE TSHP_WORKPLAN SET");
                    sbQuery.Append("  DEL_DATE = GETDATE()");
                    sbQuery.Append(" , DEL_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" , DATA_FLAG = 2");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND PROD_CODE = @PROD_CODE");
                    sbQuery.Append(" AND PART_CODE = @PART_CODE");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PROD_CODE")) isHasColumn = false;
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

        public static void TSHP_WORKPLAN_DEL(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" UPDATE TSHP_WORKPLAN ");
                    sbQuery.Append("  SET DATA_FLAG = 2 ");
                    sbQuery.Append("  , DEL_DATE = GETDATE() ");
                    sbQuery.Append("  , DEL_EMP = @DEL_EMP ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append("  AND PROD_CODE = @PROD_CODE ");
                    sbQuery.Append("  AND PART_CODE = @PART_CODE ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "WP_NO")) isHasColumn = false;

                        if (isHasColumn == true)
                        {
                            bizExecute.executeUpdateQuery(sbQuery.ToString(),row);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }


        public static void TSHP_WORKPLAN_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" INSERT INTO TSHP_WORKPLAN");
                    sbQuery.Append(" ( ");
                    sbQuery.Append(" PLT_CODE");
                    sbQuery.Append(" , WP_NO ");
                    sbQuery.Append(" , WEEK_YEAR ");
                    sbQuery.Append(" , WEEK_NO ");
                    sbQuery.Append(" , PLN_START_DATE");
                    sbQuery.Append(" , PLN_END_DATE");
                    sbQuery.Append(" , PART_ID ");
                    sbQuery.Append(" , PROD_CODE ");
                    sbQuery.Append(" , PART_CODE ");
                    sbQuery.Append(" , PLN_QTY ");
                    sbQuery.Append(" , P_QTY ");
                    sbQuery.Append(" , T_QTY ");
                    sbQuery.Append(" , B_QTY ");
                    sbQuery.Append(" , STOCK_CODE ");
                    sbQuery.Append(" , STOCK_TYPE ");
                    sbQuery.Append(" , ACT_QTY ");
                    sbQuery.Append(" , LAST_PROC_ID ");
                    sbQuery.Append(" , SCOMMENT ");
                    sbQuery.Append(" , REG_DATE ");
                    sbQuery.Append(" , REG_EMP ");
                    sbQuery.Append(" , DATA_FLAG ");          
                    sbQuery.Append(" ) ");
                    sbQuery.Append(" VALUES");
                    sbQuery.Append(" ( ");
                    sbQuery.Append(" @PLT_CODE ");
                    sbQuery.Append(" , @WP_NO");
                    sbQuery.Append(" , @WEEK_YEAR");
                    sbQuery.Append(" , @WEEK_NO");
                    sbQuery.Append(" , @PLN_START_DATE");
                    sbQuery.Append(" , @PLN_END_DATE");
                    sbQuery.Append(" , @PART_ID");
                    sbQuery.Append(" , @PROD_CODE");
                    sbQuery.Append(" , @PART_CODE");
                    sbQuery.Append(" , @PLN_QTY");
                    sbQuery.Append(" , @P_QTY");
                    sbQuery.Append(" , @T_QTY");
                    sbQuery.Append(" , @B_QTY");
                    sbQuery.Append(" , @STOCK_CODE");
                    sbQuery.Append(" , @STOCK_TYPE");
                    sbQuery.Append(" , 0");
                    sbQuery.Append(" , @LAST_PROC_ID ");
                    sbQuery.Append(" , @SCOMMENT ");
                    sbQuery.Append(" , GETDATE() ");
                    sbQuery.Append(" , " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" , 0 ");
                    sbQuery.Append(")");

                    foreach (DataRow row in dtParam.Rows)
                    {                       
                        bizExecute.executeInsertQuery(sbQuery.ToString(), row);
                    }
                }
            }
            catch(Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }        

    }

    public class TSHP_WORKPLAN_QUERY
    {
        //품목 별 공정 정보
        public static DataTable TSHP_WORKPLAN_QUERY1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT WP.PLT_CODE ");
                    sbQuery.Append(" ,WP.WP_NO");
                    sbQuery.Append(" ,WP.WEEK_YEAR");
                    sbQuery.Append(" ,WP.WEEK_NO");
                    //sbQuery.Append(" ,CONVERT(varchar,WP.WEEK_YEAR) +'년 ' + CONVERT(varchar,WP.WEEK_NO) + '주차' AS [WEEK]");
                    sbQuery.Append(" ,WP.PLN_START_DATE");
                    sbQuery.Append(" ,WP.PLN_END_DATE");
                    sbQuery.Append(" ,WP.PART_ID");
                    sbQuery.Append(" ,WP.PROD_CODE");
                    sbQuery.Append(" ,WP.PART_CODE");
                    sbQuery.Append(" ,WP.PLN_QTY");
                    sbQuery.Append(" ,SP.PART_PRODTYPE");
                    sbQuery.Append(" ,SP.PART_NAME");
                    sbQuery.Append(" ,SP.MAT_SPEC");
                    sbQuery.Append(" ,SP.DRAW_NO");
                    sbQuery.Append(" ,(SELECT ISNULL(SUM(OK_QTY),0) AS ACT_QTY FROM TSHP_ACTUAL A WHERE A.PLT_CODE = W.PLT_CODE AND A.WO_NO = W.WO_NO ) AS ACT_QTY");     
                    sbQuery.Append(" FROM TSHP_WORKPLAN WP ");
                    sbQuery.Append(" LEFT JOIN LSE_STD_PART SP ");
                    sbQuery.Append(" ON WP.PLT_CODE = SP.PLT_CODE ");
                    sbQuery.Append(" AND WP.PART_CODE = SP.PART_CODE ");
                    sbQuery.Append(" LEFT JOIN TSHP_WORKORDER W ");
                    sbQuery.Append(" ON WP.PLT_CODE = W.PLT_CODE ");
                    sbQuery.Append(" AND WP.WP_NO = W.WP_NO ");
                    sbQuery.Append(" AND WP.LAST_PROC_ID = W.PROC_ID ");
                    sbQuery.Append(" AND W.DATA_FLAG = '0' ");
                    //sbQuery.Append(" LEFT JOIN (SELECT PLT_CODE,WO_NO,SUM(OK_QTY) AS ACT_QTY FROM TSHP_ACTUAL GROUP BY PLT_CODE,WO_NO) ACT ");
                    //sbQuery.Append(" ON W.PLT_CODE = ACT.PLT_CODE ");
                    //sbQuery.Append(" AND W.WO_NO = ACT.WO_NO ");
                    //sbQuery.Append(" LEFT JOIN TSHP_WORKORDER WO ");
                    //sbQuery.Append(" ON WP.PLT_CODE = WO.PLT_CODE ");
                    //sbQuery.Append(" AND WP.WP_NO = WO.WP_NO ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE WP.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        //sbWhere.Append(UTIL.GetWhere(row, "@WEEK_YEAR", "WP.WEEK_YEAR = @WEEK_YEAR"));
                        
                        //if (UTIL.ValidColumn(row, "E_WEEK_NO"))
                        //sbWhere.Append(UTIL.GetWhere(row, "@WEEK_YEAR,@WEEK_NO,@E_WEEK_YEAR,@E_WEEK_NO",
                        //                                  "WP.WEEK_YEAR + RIGHT('00' + WP.WEEK_NO ,2)  BETWEEN @WEEK_YEAR + RIGHT('00' + @WEEK_NO,2) AND @E_WEEK_YEAR + RIGHT('00' + @E_WEEK_NO,2)"));
                        //else
                        //    sbWhere.Append(UTIL.GetWhere(row, "@WEEK_NO", "WP.WEEK_NO = @WEEK_NO"));

                        sbWhere.Append(UTIL.GetWhere(row, "@YEAR_WEEK_NO_S,@YEAR_WEEK_NO_E",
                                                          "WP.WEEK_YEAR + RIGHT('00' + WP.WEEK_NO ,2)  BETWEEN @YEAR_WEEK_NO_S AND @YEAR_WEEK_NO_E"));

                        sbWhere.Append(" AND WP.DATA_FLAG = 0");
                        sbWhere.Append(" ORDER BY WP.WP_NO");

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

        public static DataTable TSHP_WORKPLAN_QUERY2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT WP.PLT_CODE ");
                    sbQuery.Append(" ,WP.WP_NO");
                    sbQuery.Append(" ,WP.WEEK_YEAR");
                    sbQuery.Append(" ,WP.WEEK_NO");
                    sbQuery.Append(" ,WP.PLN_START_DATE");
                    sbQuery.Append(" ,WP.PLN_END_DATE");
                    sbQuery.Append(" ,WP.PART_ID");
                    sbQuery.Append(" ,WP.PART_CODE");
                    sbQuery.Append(" ,WP.PLN_QTY");
                    sbQuery.Append(" ,WP.P_QTY");
                    sbQuery.Append(" ,WP.T_QTY");
                    sbQuery.Append(" ,WP.B_QTY");
                    sbQuery.Append(" ,WP.STOCK_CODE");
                    sbQuery.Append(" ,WP.STOCK_TYPE");
                    sbQuery.Append(" ,WP.PROD_CODE");
                    sbQuery.Append(" ,WP.SCOMMENT");
                    sbQuery.Append(" ,P.ITEM_CODE");
                    sbQuery.Append(" ,SP.PART_PRODTYPE");
                    sbQuery.Append(" ,SP.PART_NAME");
                    sbQuery.Append(" ,SP.MAT_SPEC");
                    sbQuery.Append(" ,SP.DRAW_NO");
                    sbQuery.Append(" ,SP.STK_COMPLETE");
                    sbQuery.Append(" ,SP.STK_TURNING");
                    sbQuery.Append(" ,(SELECT ISNULL(SUM(OK_QTY),0) AS ACT_QTY FROM TSHP_ACTUAL A WHERE A.PLT_CODE = W.PLT_CODE AND A.WO_NO = W.WO_NO ) AS ACT_QTY");

                    sbQuery.Append(" FROM TSHP_WORKPLAN WP ");
                    sbQuery.Append("   LEFT JOIN LSE_STD_PART SP ");
                    sbQuery.Append("   ON WP.PLT_CODE = SP.PLT_CODE ");
                    sbQuery.Append(" AND WP.PART_CODE = SP.PART_CODE ");

                    sbQuery.Append(" LEFT JOIN TSHP_WORKORDER W ");
                    sbQuery.Append(" ON WP.PLT_CODE = W.PLT_CODE ");
                    sbQuery.Append(" AND WP.WP_NO = W.WP_NO ");
                    sbQuery.Append(" AND WP.LAST_PROC_ID = W.PROC_ID ");
                    sbQuery.Append(" AND W.DATA_FLAG = '0' ");

                    sbQuery.Append(" LEFT JOIN TORD_PRODUCT P ");
                    sbQuery.Append("  ON WP.PLT_CODE = P.PLT_CODE");
                    sbQuery.Append(" AND WP.PROD_CODE = P.PROD_CODE ");
                    sbQuery.Append(" AND WP.PART_CODE = P.PART_CODE ");
                    

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE WP.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_CODE", "WP.PROD_CODE = @PROD_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_CODE", "WP.PART_CODE = @PART_CODE"));
                        sbWhere.Append(" AND WP.DATA_FLAG = 0");
                        //sbWhere.Append(" ORDER BY WP.WP_NO");

                        sbWhere.Append(" ORDER BY P.PART_SEQ");

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

        public static DataTable TSHP_WORKPLAN_QUERY2_1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT WP.PLT_CODE ");
                    sbQuery.Append(" ,WP.WP_NO");
                    sbQuery.Append(" ,WP.WEEK_YEAR");
                    sbQuery.Append(" ,WP.WEEK_NO");
                    sbQuery.Append(" ,WP.PLN_START_DATE");
                    sbQuery.Append(" ,WP.PLN_END_DATE");
                    sbQuery.Append(" ,WP.PART_ID");
                    sbQuery.Append(" ,WP.PART_CODE");
                    sbQuery.Append(" ,WP.PLN_QTY");
                    sbQuery.Append(" ,WP.P_QTY");
                    sbQuery.Append(" ,WP.T_QTY");
                    sbQuery.Append(" ,WP.B_QTY");
                    sbQuery.Append(" ,WP.STOCK_CODE");
                    sbQuery.Append(" ,WP.STOCK_TYPE");
                    sbQuery.Append(" ,WP.PROD_CODE");
                    sbQuery.Append(" ,WP.SCOMMENT");
                    sbQuery.Append(" ,P.ITEM_CODE");
                    sbQuery.Append(" ,SP.PART_PRODTYPE");
                    sbQuery.Append(" ,SP.PART_NAME");
                    sbQuery.Append(" ,SP.MAT_SPEC");
                    sbQuery.Append(" ,SP.DRAW_NO");
                    sbQuery.Append(" ,SP.STK_COMPLETE");
                    sbQuery.Append(" ,SP.STK_TURNING");
                    sbQuery.Append(" ,Q.MQLTY_NAME");
                    sbQuery.Append(" ,CASE WHEN ISNULL(SP.REV_PART_CODE, '') = '' THEN 'X' ELSE 'O' END REV_PART ");
                    sbQuery.Append(" ,SP.REV_PART_CODE ");

                    //sbQuery.Append(" ,(SELECT ISNULL(SUM(OK_QTY),0) AS ACT_QTY FROM TSHP_ACTUAL A WHERE A.PLT_CODE = W.PLT_CODE AND A.WO_NO = W.WO_NO ) AS ACT_QTY");

                    sbQuery.Append(" FROM TSHP_WORKPLAN WP ");
                    sbQuery.Append("   LEFT JOIN LSE_STD_PART SP ");
                    sbQuery.Append("   ON WP.PLT_CODE = SP.PLT_CODE ");
                    sbQuery.Append(" AND WP.PART_CODE = SP.PART_CODE ");

                    sbQuery.Append(" LEFT JOIN TSHP_WORKORDER W ");
                    sbQuery.Append(" ON WP.PLT_CODE = W.PLT_CODE ");
                    sbQuery.Append(" AND WP.WP_NO = W.WP_NO ");
                    sbQuery.Append(" AND WP.LAST_PROC_ID = W.PROC_ID ");
                    sbQuery.Append(" AND W.DATA_FLAG = '0' ");

                    sbQuery.Append(" LEFT JOIN TORD_PRODUCT P ");
                    sbQuery.Append("  ON WP.PLT_CODE = P.PLT_CODE");
                    sbQuery.Append(" AND WP.PROD_CODE = P.PROD_CODE ");
                    sbQuery.Append(" AND WP.PART_CODE = P.PART_CODE ");

                    sbQuery.Append(" LEFT JOIN LSE_STD_PART PT ");
                    sbQuery.Append("  ON P.PLT_CODE = PT.PLT_CODE");
                    sbQuery.Append(" AND P.PART_CODE = PT.PART_CODE ");

                    sbQuery.Append(" LEFT OUTER JOIN TMAT_QUC_MASTER Q ");
                    sbQuery.Append("  ON PT.PLT_CODE = Q.PLT_CODE   ");
                    sbQuery.Append(" AND PT.MAT_QLTY = Q.MQLTY_CODE     ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE WP.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_CODE", "WP.PROD_CODE = @PROD_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_CODE", "WP.PART_CODE = @PART_CODE"));
                        sbWhere.Append(" AND WP.DATA_FLAG = 0");
                        //sbWhere.Append(" ORDER BY WP.WP_NO");

                        sbWhere.Append(" ORDER BY P.PART_SEQ");

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

        public static DataTable TSHP_WORKPLAN_QUERY2_2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT WP.PLT_CODE ");
                    sbQuery.Append(" ,WP.WP_NO");
                    sbQuery.Append(" ,WP.WEEK_YEAR");
                    sbQuery.Append(" ,WP.WEEK_NO");
                    sbQuery.Append(" ,WP.PLN_START_DATE");
                    sbQuery.Append(" ,WP.PLN_END_DATE");
                    sbQuery.Append(" ,WP.PART_ID");
                    sbQuery.Append(" ,WP.PART_CODE");
                    sbQuery.Append(" ,WP.PLN_QTY");
                    sbQuery.Append(" ,WP.P_QTY");
                    sbQuery.Append(" ,WP.T_QTY");
                    sbQuery.Append(" ,WP.B_QTY");
                    sbQuery.Append(" ,WP.STOCK_CODE");
                    sbQuery.Append(" ,WP.STOCK_TYPE");
                    sbQuery.Append(" ,WP.PROD_CODE");
                    sbQuery.Append(" ,WP.SCOMMENT");
                    sbQuery.Append(" ,P.ITEM_CODE");
                    sbQuery.Append(" ,SP.PART_PRODTYPE");
                    sbQuery.Append(" ,SP.PART_NAME");
                    sbQuery.Append(" ,SP.MAT_SPEC");
                    sbQuery.Append(" ,SP.DRAW_NO");
                    sbQuery.Append(" ,SP.STK_COMPLETE");
                    sbQuery.Append(" ,0 AS STK_TURNING");
                    //sbQuery.Append(" ,SP.STK_TURNING");
                    sbQuery.Append(" ,Q.MQLTY_NAME");
                    sbQuery.Append(" ,CASE WHEN ISNULL(SP.REV_PART_CODE, '') = '' THEN 'X' ELSE 'O' END REV_PART ");
                    sbQuery.Append(" ,SP.REV_PART_CODE ");

                    //sbQuery.Append(" ,(SELECT ISNULL(SUM(OK_QTY),0) AS ACT_QTY FROM TSHP_ACTUAL A WHERE A.PLT_CODE = W.PLT_CODE AND A.WO_NO = W.WO_NO ) AS ACT_QTY");

                    sbQuery.Append(" FROM TSHP_WORKPLAN WP ");
                    sbQuery.Append("   LEFT JOIN LSE_STD_PART SP ");
                    sbQuery.Append("   ON WP.PLT_CODE = SP.PLT_CODE ");
                    sbQuery.Append(" AND WP.PART_CODE = SP.PART_CODE ");

                    sbQuery.Append(" LEFT JOIN TSHP_WORKORDER W ");
                    sbQuery.Append(" ON WP.PLT_CODE = W.PLT_CODE ");
                    sbQuery.Append(" AND WP.WP_NO = W.WP_NO ");
                    sbQuery.Append(" AND WP.LAST_PROC_ID = W.PROC_ID ");
                    sbQuery.Append(" AND W.DATA_FLAG = '0' ");

                    sbQuery.Append(" LEFT JOIN TORD_PRODUCT P ");
                    sbQuery.Append("  ON WP.PLT_CODE = P.PLT_CODE");
                    sbQuery.Append(" AND WP.PROD_CODE = P.PROD_CODE ");
                    sbQuery.Append(" AND WP.PART_CODE = P.PART_CODE ");

                    sbQuery.Append(" LEFT JOIN LSE_STD_PART PT ");
                    sbQuery.Append("  ON P.PLT_CODE = PT.PLT_CODE");
                    sbQuery.Append(" AND P.PART_CODE = PT.PART_CODE ");

                    sbQuery.Append(" LEFT OUTER JOIN TMAT_QUC_MASTER Q ");
                    sbQuery.Append("  ON PT.PLT_CODE = Q.PLT_CODE   ");
                    sbQuery.Append(" AND PT.MAT_QLTY = Q.MQLTY_CODE     ");

                    StringBuilder sbWhere = new StringBuilder(" WHERE WP.PLT_CODE = " + ConnInfo.PLT_CODE);

                    for (int i = 0; i < dtParam.Rows.Count; i++)
                    {
                        if (i == 0)
                        {
                            sbWhere.Append(" AND (");
                        }

                        DataRow row = dtParam.Rows[i];
                        sbWhere.Append("(WP.PROD_CODE = " + UTIL.GetValidValue(row, "PROD_CODE").ToString()
                                + " AND WP.PART_CODE = " + UTIL.GetValidValue(row, "PART_CODE").ToString() + ") ");

                        if (i != dtParam.Rows.Count - 1)
                        {
                            sbWhere.Append(" OR ");
                        }
                    }

                    sbWhere.Append(" ) AND WP.DATA_FLAG = 0");
                    sbWhere.Append(" ORDER BY P.PART_SEQ");

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


        public static DataTable TSHP_WORKPLAN_QUERY3(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT 							 ");
                    sbQuery.Append(" W.PART_CODE 							 ");
                    //sbQuery.Append(" ,ISNULL(SUM(T_QTY),0) + ISNULL(SUM(P_QTY),0) AS WORK_QTY");
                    sbQuery.Append(" ,ISNULL(SUM(P_QTY),0) AS WORK_QTY");
                    sbQuery.Append(" ,ISNULL(SUM(T_QTY),0) AS WORK_T_QTY ");
                    sbQuery.Append(" FROM TSHP_WORKPLAN W ");
                    sbQuery.Append("  JOIN TORD_PRODUCT P ");
                    sbQuery.Append("   ON W.PLT_CODE = P.PLT_CODE ");
                    sbQuery.Append("   AND W.PROD_CODE = P.PROD_CODE ");
                    sbQuery.Append("   AND W.PART_CODE = P.PART_CODE ");
                    
                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE W.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_CODE", "W.PROD_CODE <> @PROD_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_CODE", "W.PART_CODE = @PART_CODE"));
                        sbWhere.Append(" AND W.DATA_FLAG = 0");
                        sbWhere.Append(" AND P.PROD_STATE IN ('WK', 'PG') ");
                        sbWhere.Append(" GROUP BY W.PART_CODE");
 
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

        public static DataTable TSHP_WORKPLAN_QUERY3_1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT 							 ");
                    sbQuery.Append(" W.PART_CODE 							 ");
                    sbQuery.Append(" ,ISNULL(SUM(W.P_QTY),0) AS WORK_QTY");
                    sbQuery.Append(" ,ISNULL(SUM(W.T_QTY),0) AS WORK_T_QTY ");
                    sbQuery.Append(" FROM TSHP_WORKPLAN W ");
                    sbQuery.Append("  JOIN TORD_PRODUCT P ");
                    sbQuery.Append("   ON W.PLT_CODE = P.PLT_CODE ");
                    sbQuery.Append("   AND W.PROD_CODE = P.PROD_CODE ");
                    sbQuery.Append("   AND W.PART_CODE = P.PART_CODE ");

                    StringBuilder sbWhere = new StringBuilder(" WHERE W.PLT_CODE = " + ConnInfo.PLT_CODE);
                    foreach (DataRow row in dtParam.Rows)
                    {
                        if (dtParam.Rows.IndexOf(row) == 0)
                        {
                            sbWhere.Append(" AND (");
                        }

                        sbWhere.Append("(W.PROD_CODE <> " + UTIL.GetValidValue(row, "PROD_CODE").ToString()
                                + " AND W.PART_CODE = " + UTIL.GetValidValue(row, "PART_CODE").ToString() + ") ");

                        if (dtParam.Rows.IndexOf(row) != dtParam.Rows.Count - 1)
                        {
                            sbWhere.Append(" OR ");
                        }
                    }
                    sbWhere.Append(" ) AND W.DATA_FLAG = 0");
                    sbWhere.Append(" AND P.PROD_STATE IN ('WK', 'PG') ");
                    sbWhere.Append(" GROUP BY W.PART_CODE");

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

        public static DataTable TSHP_WORKPLAN_QUERY4(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT  ");
                    sbQuery.Append(" PART_CODE  ");
                    sbQuery.Append(" ,STK_COMPLETE	");
                    sbQuery.Append(" ,STK_TURNING	");
                    sbQuery.Append(" ,PART_NAME	");
                    sbQuery.Append(" ,MAT_SPEC	");
                    sbQuery.Append(" ,MAT_SPEC1	");
                    sbQuery.Append(" ,PART_PRODTYPE	");
                    

                    sbQuery.Append(" FROM LSE_STD_PART	");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_CODE", "PART_CODE = @PART_CODE"));
                        sbWhere.Append(" AND DATA_FLAG = 0");

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

        public static DataTable TSHP_WORKPLAN_QUERY5(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT							");
                    sbQuery.Append(" WP.PROD_CODE					");
                    sbQuery.Append(" ,WP.PART_CODE					");
                    sbQuery.Append(" ,SP.PART_NAME					");
                    sbQuery.Append(" ,SP.PART_PRODTYPE					");
                    sbQuery.Append(" ,SP.MAT_QLTY					");
                    sbQuery.Append(" ,SP.MAT_TYPE					");
                    sbQuery.Append(" ,SP.MAT_SPEC					");
                    sbQuery.Append(" ,SP.MAT_SPEC1					");
                    sbQuery.Append(" ,SP.MAT_WEIGHT1				");
                    sbQuery.Append(" ,SP.STK_COMPLETE				");
                    sbQuery.Append(" ,SP.STK_TURNING				");
                    sbQuery.Append(" ,WP.STOCK_TYPE					");
                    sbQuery.Append(" ,WP.STOCK_CODE					");
                    sbQuery.Append(" ,WP.P_QTY						");
                    sbQuery.Append(" ,WP.T_QTY						");
                    sbQuery.Append(" ,WP.B_QTY						");
                    sbQuery.Append(" ,WP.PLN_QTY					");
                    sbQuery.Append(" FROM TSHP_WORKPLAN WP			");
                    sbQuery.Append(" LEFT JOIN LSE_STD_PART SP		");
                    sbQuery.Append(" ON WP.PLT_CODE = SP.PLT_CODE	");
                    sbQuery.Append(" AND WP.PART_CODE = SP.PART_CODE");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE WP.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                        sbWhere.Append(UTIL.GetWhere(row, "@WP_NO", "WP.WP_NO = @WP_NO"));
                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "WP.DATA_FLAG = @DATA_FLAG"));

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

        public static DataTable TSHP_WORKPLAN_QUERY6(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT 															   ");
                    sbQuery.Append(" WP.PROD_CODE														   ");
                    sbQuery.Append(" ,TP.PROD_STATE														   ");
                    sbQuery.Append(" ,WP.PART_CODE														   ");
                    sbQuery.Append(" ,SP.PART_NAME														   ");
                    sbQuery.Append(" ,SP.MAT_SPEC														   ");
                    sbQuery.Append(" ,I.ORD_DATE														   ");
                    sbQuery.Append(" ,I.CVND_CODE														   ");
                    sbQuery.Append(" ,V.VEN_NAME AS CVND_NAME										   	   ");
                    sbQuery.Append(" ,TP.ITEM_CODE    ");
                    sbQuery.Append(" ,I.ITEM_NAME    ");
                    sbQuery.Append(" ,TP.DUE_DATE														   ");
                    sbQuery.Append(" ,WP.PLN_QTY						   ");
                    //sbQuery.Append(" ,ISNULL(T_QTY,0) + ISNULL(P_QTY,0) AS PLN_QTY						   ");
                    sbQuery.Append(" ,ISNULL(P_QTY,0) AS P_QTY											   ");
                    sbQuery.Append(" ,ISNULL(T_QTY,0) AS T_QTY											   ");
                    sbQuery.Append(" ,ISNULL(TS.PART_QTY,0) AS ACT_QTY									   ");
                    
                    //sbQuery.Append(" ,ISNULL(P_QTY,0) - ISNULL(TS.PART_QTY,0) AS WORK_QTY");
                    //sbQuery.Append(" ,CASE WP.STOCK_TYPE WHEN 'S02' THEN ISNULL(T_QTY, 0) - ISNULL(TS.PART_QTY,0)	   ");
                    //sbQuery.Append("                     ELSE ISNULL(T_QTY, 0) END AS WORK_T_QTY					   ");

                    sbQuery.Append(" ,ISNULL(P_QTY,0) AS WORK_QTY");
                    sbQuery.Append(" ,ISNULL(T_QTY, 0) AS WORK_T_QTY	");

                    sbQuery.Append(" , 0 AS WORK_B_QTY  ");

                    sbQuery.Append(" ,WP.STOCK_TYPE														   ");
                    sbQuery.Append(" ,WP.SCOMMENT														   ");

                    sbQuery.Append(" FROM TSHP_WORKPLAN WP												   ");
                    sbQuery.Append(" LEFT JOIN TSHP_DAILYWORK DW										   ");
                    sbQuery.Append(" ON WP.PLT_CODE = DW.PLT_CODE										   ");
                    sbQuery.Append(" AND WP.PROD_CODE = DW.PROD_CODE									   ");
                    sbQuery.Append(" AND WP.PART_CODE = DW.PART_CODE									   ");
                    sbQuery.Append(" AND STK_ID IS NOT NULL												   ");
                    
                    sbQuery.Append(" LEFT JOIN TSHP_STOCK TS											   ");
                    sbQuery.Append(" ON DW.PLT_CODE = TS.PLT_CODE										   ");
                    sbQuery.Append(" AND DW.STK_ID = TS.STK_ID											   ");
                    
                    sbQuery.Append(" LEFT JOIN LSE_STD_PART SP											   ");
                    sbQuery.Append(" ON WP.PLT_CODE = SP.PLT_CODE										   ");
                    sbQuery.Append(" AND WP.PART_CODE = SP.PART_CODE									   ");
                    
                    sbQuery.Append(" LEFT JOIN TORD_PRODUCT TP											   ");
                    sbQuery.Append(" ON WP.PLT_CODE = TP.PLT_CODE										   ");
                    sbQuery.Append(" AND WP.PROD_CODE = TP.PROD_CODE									   ");
                    sbQuery.Append(" AND WP.PART_CODE = TP.PART_CODE									   ");
                    
                    sbQuery.Append(" LEFT JOIN TORD_ITEM I												   ");
                    sbQuery.Append(" ON TP.PLT_CODE = I.PLT_CODE										   ");
                    sbQuery.Append(" AND TP.ITEM_CODE = I.ITEM_CODE										   ");
                    
                    sbQuery.Append(" LEFT JOIN TSTD_VENDOR V											   ");
                    sbQuery.Append(" ON I.PLT_CODE = V.PLT_CODE											   ");
                    sbQuery.Append(" AND I.CVND_CODE = V.VEN_CODE						   				   ");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE WP.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_CODE", "WP.PART_CODE = @PART_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_CODE", "WP.PROD_CODE <> @PROD_CODE"));

                        sbWhere.Append(UTIL.GetWhere(row, "@EX_SHIP", "TP.PROD_STATE IN ('WK', 'PG') "));       //출하제외
                        sbWhere.Append(UTIL.GetWhere(row, "@IN_SHIP", "TP.PROD_STATE IN ('WK', 'PG', 'SH') "));       //출하포함
                        //sbWhere.Append(" AND (ISNULL(T_QTY,0) + ISNULL(P_QTY,0) - ISNULL(TS.PART_QTY,0) > 0");
                        //sbWhere.Append(" AND (ISNULL(P_QTY,0) - ISNULL(TS.PART_QTY,0) > 0");
                        //sbWhere.Append("      OR (CASE WP.STOCK_TYPE WHEN 'S02' THEN T_QTY - ISNULL(TS.PART_QTY,0)");
                        //sbWhere.Append("                             ELSE T_QTY END) > 0)");
                        sbWhere.Append(" AND WP.DATA_FLAG = '0'");
                        

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

        public static DataTable TSHP_WORKPLAN_QUERY6_2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {

                DataTable dtResult = new DataTable("RSLTDT_WIP");

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT W.PLT_CODE,     ");
                    sbQuery.Append(" W.PROD_CODE,         ");
                    sbQuery.Append(" W.PART_CODE,         ");
                    sbQuery.Append(" SUM(W.PART_QTY) AS PLN_QTY,      ");
                    sbQuery.Append(" SUM(W.FNS_QTY) AS FNS_QTY,       ");
                    sbQuery.Append(" SUM(W.NG_QTY) AS NG_QTY,  ");
                    sbQuery.Append(" SUM(W.PART_QTY) - SUM(W.FNS_QTY) - SUM(W.NG_QTY) AS WIP_QTY         ");
                    sbQuery.Append(" FROM TSHP_WORKORDER W JOIN TORD_PRODUCT P        ");
                    sbQuery.Append("  	ON W.PLT_CODE = P.PLT_CODE            ");
                    sbQuery.Append("  	AND W.PROD_CODE = P.PROD_CODE         ");
                    sbQuery.Append("  	AND W.PART_CODE = P.PART_CODE         ");
                    sbQuery.Append("  	JOIN TORD_ITEM I                     ");
                    sbQuery.Append("  	ON P.PLT_CODE = I.PLT_CODE           ");
                    sbQuery.Append("  	AND P.ITEM_CODE = I.ITEM_CODE        ");
                    //sbQuery.Append("  	JOIN TSTD_VENDOR V                   ");
                    //sbQuery.Append("  	ON I.PLT_CODE = V.PLT_CODE           ");
                    //sbQuery.Append("  	AND I.CVND_CODE = V.VEN_CODE         ");
                    sbQuery.Append(" WHERE W.DATA_FLAG = 0                  ");
                    sbQuery.Append("  	AND I.DATA_FLAG = 0                  ");
                    //2020-10-12 홍건웅 이사 요청에 의해 "거래처 기준" -> "수주 기준"으로 변경
                    //sbQuery.Append("  	AND V.ITEM_AUTO_CODE IN ('H', 'S')    ");
                    sbQuery.Append("  	AND LEFT(I.ITEM_CODE,1) IN ('H','S')                  ");
                    sbQuery.Append("  	AND W.WO_FLAG <> '4'                 ");
                    sbQuery.Append("  	AND W.IS_LAST = '1'                  ");
                    sbQuery.Append("  	GROUP BY W.PLT_CODE, W.PROD_CODE, W.PART_CODE     ");


                    dtResult = bizExecute.executeSelectQuery(sbQuery.ToString()).Copy();

                    
                }

                return dtResult;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataTable TSHP_WORKPLAN_QUERY7(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT WP.PLT_CODE ");
                    sbQuery.Append(" ,WP.WP_NO");
                    sbQuery.Append(" ,WP.WEEK_YEAR");
                    sbQuery.Append(" ,WP.WEEK_NO");
                    sbQuery.Append(" ,WP.PLN_START_DATE");
                    sbQuery.Append(" ,WP.PLN_END_DATE");
                    sbQuery.Append(" ,WP.PART_ID");
                    sbQuery.Append(" ,WP.PART_CODE");
                    sbQuery.Append(" ,WP.PLN_QTY");
                    sbQuery.Append(" ,WP.P_QTY");
                    sbQuery.Append(" ,WP.T_QTY");
                    sbQuery.Append(" ,WP.B_QTY");
                    sbQuery.Append(" ,WP.STOCK_CODE");
                    sbQuery.Append(" ,WP.STOCK_TYPE");
                    sbQuery.Append(" ,WP.PROD_CODE");
                    sbQuery.Append(" ,WP.SCOMMENT");
                    sbQuery.Append(" ,P.ITEM_CODE");

                    sbQuery.Append(" ,P.PROD_CODE + '_' + P.PART_CODE AS PART_KEY				   ");
                    sbQuery.Append(" ,P.PROD_CODE + '_' + P.PARENT_PART AS PART_PARENT				   ");

                    sbQuery.Append(" ,P.PARENT_PART");
                    sbQuery.Append(" ,P.PART_APS_SEQ");
                    sbQuery.Append(" ,I.CVND_CODE");
                    sbQuery.Append(" ,V.VEN_NAME AS CVND_NAME");
                    sbQuery.Append(" ,I.ORD_DATE");
                    sbQuery.Append(" ,I.DUE_DATE");
                    sbQuery.Append(" ,P.DUE_DATE AS P_DUE_DATE ");
                    sbQuery.Append(" ,P.PROD_QTY ");
                    sbQuery.Append(" ,SP.PART_PRODTYPE");
                    sbQuery.Append(" ,SP.PART_NAME");
                    sbQuery.Append(" ,SP.MAT_SPEC1");
                    sbQuery.Append(" ,SP.MAT_SPEC");
                    sbQuery.Append(" ,SP.MAT_QLTY");
                    sbQuery.Append(" ,Q.MQLTY_NAME");
                    sbQuery.Append(" ,SP.DRAW_NO");
                    sbQuery.Append(" ,SP.STK_COMPLETE");
                    sbQuery.Append(" ,SP.STK_TURNING");
                    
                    sbQuery.Append(" ,(SELECT ISNULL(SUM(NG_QTY),0) AS NG_QTY FROM TSHP_DAILYWORK D ");
                    sbQuery.Append("     WHERE D.PLT_CODE = WP.PLT_CODE AND D.PROD_CODE = WP.PROD_CODE AND D.PART_CODE = WP.PART_CODE ) AS NG_QTY");
                    //sbQuery.Append(" ,CASE ISNULL(FM.LINK_KEY, '') WHEN '' THEN 'X' ELSE 'O' END colATTACH   ");
                    //sbQuery.Append(" ,FM.LINK_KEY ");
                    sbQuery.Append(" ,CASE WHEN SP.ATT_QTY > 0 THEN 'O' ELSE 'X' END colATTACH");
                    sbQuery.Append(" ,SP.ATT_QTY ");

                    sbQuery.Append(" ,CASE WHEN ISNULL(SP.REV_PART_CODE, '') = '' THEN 'X' ELSE 'O' END REV_PART ");
                    sbQuery.Append(" , SP.REV_PART_CODE ");

                    sbQuery.Append(" FROM TSHP_WORKPLAN WP ");
                    sbQuery.Append(" LEFT JOIN LSE_STD_PART SP ");
                    sbQuery.Append(" ON WP.PLT_CODE = SP.PLT_CODE ");
                    sbQuery.Append(" AND WP.PART_CODE = SP.PART_CODE ");

                    sbQuery.Append(" LEFT JOIN TORD_PRODUCT P ");
                    sbQuery.Append("  ON WP.PLT_CODE = P.PLT_CODE");
                    sbQuery.Append(" AND WP.PROD_CODE = P.PROD_CODE ");
                    sbQuery.Append(" AND WP.PART_CODE = P.PART_CODE ");

                    sbQuery.Append(" LEFT JOIN TORD_ITEM I ");
                    sbQuery.Append("  ON P.PLT_CODE = I.PLT_CODE");
                    sbQuery.Append(" AND P.ITEM_CODE = I.ITEM_CODE ");

                    sbQuery.Append(" LEFT JOIN TSTD_VENDOR V ");
                    sbQuery.Append("  ON I.PLT_CODE = V.PLT_CODE");
                    sbQuery.Append(" AND I.CVND_CODE = V.VEN_CODE ");

                    //sbQuery.Append(" LEFT OUTER JOIN (SELECT PLT_CODE, LINK_KEY FROM TSYS_FILELIST_MASTER WHERE IS_UPLOAD = 1 AND UPLOAD_MENU = 'PLN01A' AND DATA_FLAG = 0 GROUP BY PLT_CODE, LINK_KEY) FM ");
                    //sbQuery.Append(" ON SP.PLT_CODE = FM.PLT_CODE AND SP.PART_CODE = FM.LINK_KEY ");
                    
                    sbQuery.Append(" LEFT OUTER JOIN TMAT_QUC_MASTER Q ");
                    sbQuery.Append("  ON SP.PLT_CODE = Q.PLT_CODE   ");
                    sbQuery.Append(" AND SP.MAT_QLTY = Q.MQLTY_CODE     ");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE WP.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@CVND_CODE", "I.CVND_CODE = @CVND_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@ITEM_CODE", "P.ITEM_CODE = @ITEM_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_STATE", "P.PROD_STATE IN @PROD_STATE", UTIL.SqlCondType.IN));
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_LIKE", "SP.PART_CODE LIKE '%' + @PART_LIKE + '%'"));
                        sbWhere.Append(UTIL.GetWhere(row, "@VEN_LIKE", "(I.CVND_CODE LIKE '%' + @VEN_LIKE + '%' OR V.VEN_NAME LIKE '%' + @VEN_LIKE + '%')"));

                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_CODE", "WP.PROD_CODE = @PROD_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_CODE", "WP.PART_CODE = @PART_CODE"));

                        sbWhere.Append(UTIL.GetWhere(row, "@ONLY_PARENT", " P.PARENT_PART IS NULL"));
                        
                        //sbWhere.Append(" ");
                        sbWhere.Append(" AND WP.DATA_FLAG = 0");
                        sbWhere.Append(" ORDER BY P.ITEM_CODE, P.PROD_CODE, P.PART_SEQ ");

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
