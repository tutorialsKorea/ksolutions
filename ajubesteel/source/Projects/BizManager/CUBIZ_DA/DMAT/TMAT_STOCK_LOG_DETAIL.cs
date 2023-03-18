using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace DMAT
{
    public class TMAT_STOCK_LOG_DETAIL
    {
        public static DataTable TMAT_STOCK_LOG_DETAIL_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("  SELECT  ");
                    sbQuery.Append("  PLT_CODE ");
                    sbQuery.Append(" ,LOG_DETAIL_ID ");
                    sbQuery.Append(" ,LOT_ID ");
                    sbQuery.Append(" ,STK_ID ");
                    sbQuery.Append(" ,LOG_ID ");
                    sbQuery.Append(" ,IN_QTY ");
                    sbQuery.Append(" ,OUT_QTY ");
                    sbQuery.Append(" ,STOCK_FLAG ");
                    sbQuery.Append(" ,YPGO_ID ");
                    sbQuery.Append(" ,OUT_ID ");
                    sbQuery.Append(" ,REG_DATE ");
                    sbQuery.Append(" ,REG_EMP ");
                    sbQuery.Append("  FROM TMAT_STOCK_LOG_DETAIL  ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("  AND LOG_DETAIL_ID = @LOG_DETAIL_ID  ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "LOG_DETAIL_ID")) isHasColumn = false;

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

        public static void TMAT_STOCK_LOG_DETAIL_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" INSERT INTO TMAT_STOCK_LOG_DETAIL (  ");
                    sbQuery.Append("  PLT_CODE ");
                    sbQuery.Append(" ,LOG_DETAIL_ID ");
                    sbQuery.Append(" ,LOT_ID ");
                    sbQuery.Append(" ,STK_ID ");
                    sbQuery.Append(" ,LOG_ID ");
                    sbQuery.Append(" ,UNIT_COST ");
                    sbQuery.Append(" ,IN_QTY ");
                    sbQuery.Append(" ,OUT_QTY ");
                    sbQuery.Append(" ,STOCK_FLAG ");
                    sbQuery.Append(" ,YPGO_ID ");
                    sbQuery.Append(" ,OUT_ID ");
                    sbQuery.Append(" ,REG_DATE ");
                    sbQuery.Append(" ,REG_EMP ");
                    sbQuery.Append("  ) VALUES (  ");
                    sbQuery.Append("  @PLT_CODE ");
                    sbQuery.Append(" ,@LOG_DETAIL_ID ");
                    sbQuery.Append(" ,@LOT_ID ");
                    sbQuery.Append(" ,@STK_ID ");
                    sbQuery.Append(" ,@LOG_ID ");
                    sbQuery.Append(" ,@UNIT_COST ");
                    sbQuery.Append(" ,@IN_QTY ");
                    sbQuery.Append(" ,@OUT_QTY ");
                    sbQuery.Append(" ,@STOCK_FLAG ");
                    sbQuery.Append(" ,@YPGO_ID ");
                    sbQuery.Append(" ,@OUT_ID ");
                    sbQuery.Append(" ,GETDATE() ");
                    sbQuery.Append(" ,'" + ConnInfo.UserID + "' ");
                    sbQuery.Append("  ) ");

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

    public class TMAT_STOCK_LOG_DETAIL_QUERY
    {
        public static DataTable TMAT_STOCK_LOG_DETAIL_QUERY1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {

                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT");
                    sbQuery.Append(" SL.PLT_CODE");
                    sbQuery.Append(" ,SL.LOT_ID");
                    sbQuery.Append(" ,S.PART_CODE");
                    sbQuery.Append(" ,S.DETAIL_PART_NAME");
                    sbQuery.Append(" ,S.STOCK_LOC");
                    sbQuery.Append(" ,S.PART_QTY");
                    sbQuery.Append(" ,SL.YPGO_ID");
                    sbQuery.Append(" ,SL.UNIT_COST");
                    sbQuery.Append(" ,S.STK_ID");
                    sbQuery.Append(" ,S.TOT_YPGO_AMT");
                    sbQuery.Append(" ,S.PART_QTY");
                    sbQuery.Append(" ,SUM(SL.IN_QTY) AS IN_QTY");
                    sbQuery.Append(" ,SUM(SL.OUT_QTY) AS OUT_QTY");
                    sbQuery.Append(" ,SUM(SL.IN_QTY) - SUM(SL.OUT_QTY) AS REMAIN_QTY");
                    sbQuery.Append(" ,MIN(SL.REG_DATE) AS REG_DATE");
                    sbQuery.Append(" FROM TMAT_STOCK_LOG_DETAIL SL");
                    sbQuery.Append(" JOIN TMAT_STOCK S");
                    sbQuery.Append(" ON SL.PLT_CODE = S.PLT_CODE");
                    sbQuery.Append(" AND SL.STK_ID = S.STK_ID");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE SL.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                        sbWhere.Append(UTIL.GetWhere(row, "@YPGO_ID", " SL.YPGO_ID = @YPGO_ID"));
                        sbWhere.Append(UTIL.GetWhere(row, "@STK_ID", " S.STK_ID = @STK_ID"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_CODE", " S.PART_CODE = @PART_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@DETAIL_PART_NAME", " S.DETAIL_PART_NAME = @DETAIL_PART_NAME"));

                        StringBuilder sbGroupBy = new StringBuilder();

                        sbGroupBy.Append(" GROUP BY SL.PLT_CODE");
                        sbGroupBy.Append(" ,SL.LOT_ID");
                        sbGroupBy.Append(" ,S.PART_CODE");
                        sbGroupBy.Append(" ,S.DETAIL_PART_NAME");
                        sbGroupBy.Append(" ,S.STOCK_LOC");
                        sbGroupBy.Append(" ,S.PART_QTY");
                        sbGroupBy.Append(" ,SL.YPGO_ID");
                        sbGroupBy.Append(" ,SL.UNIT_COST");
                        sbGroupBy.Append(" ,S.STK_ID");
                        sbGroupBy.Append(" ,S.TOT_YPGO_AMT");
                        sbGroupBy.Append(" ,S.PART_QTY");

                        sbGroupBy.Append(" HAVING SUM(SL.IN_QTY) - SUM(SL.OUT_QTY) > 0");

                        sbGroupBy.Append(" ORDER BY MIN(SL.REG_DATE)");

                        DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString() + sbWhere.ToString() + sbGroupBy.ToString()).Copy();

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

        public static DataTable TMAT_STOCK_LOG_DETAIL_QUERY2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {

                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT");
                    sbQuery.Append(" SL.PLT_CODE");
                    sbQuery.Append(" ,SL.LOT_ID");
                    sbQuery.Append(" ,S.PART_CODE");
                    sbQuery.Append(" ,S.DETAIL_PART_NAME");
                    sbQuery.Append(" ,S.STOCK_LOC");
                    sbQuery.Append(" ,S.PART_QTY");
                    sbQuery.Append(" ,SL.YPGO_ID");
                    sbQuery.Append(" ,SL.UNIT_COST");
                    sbQuery.Append(" ,S.STK_ID");
                    sbQuery.Append(" ,S.TOT_YPGO_AMT");
                    sbQuery.Append(" ,S.PART_QTY");
                    sbQuery.Append(" ,SUM(SL.IN_QTY) AS IN_QTY");
                    sbQuery.Append(" ,SUM(SL.OUT_QTY) AS OUT_QTY");
                    sbQuery.Append(" ,SUM(SL.IN_QTY) - SUM(SL.OUT_QTY) AS REMAIN_QTY");
                    sbQuery.Append(" ,MIN(SL.REG_DATE) AS REG_DATE");
                    sbQuery.Append(" FROM TMAT_STOCK_LOG_DETAIL SL");
                    sbQuery.Append(" JOIN TMAT_STOCK S");
                    sbQuery.Append(" ON SL.PLT_CODE = S.PLT_CODE");
                    sbQuery.Append(" AND SL.STK_ID = S.STK_ID");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE SL.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                        sbWhere.Append(UTIL.GetWhere(row, "@YPGO_ID", " SL.YPGO_ID = @YPGO_ID"));
                        sbWhere.Append(UTIL.GetWhere(row, "@STK_ID", " S.STK_ID = @STK_ID"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_CODE", " S.PART_CODE = @PART_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@DETAIL_PART_NAME", " S.DETAIL_PART_NAME = @DETAIL_PART_NAME"));
                        sbWhere.Append(UTIL.GetWhere(row, "@OUT_ID", " SL.OUT_ID = @OUT_ID"));

                        StringBuilder sbGroupBy = new StringBuilder();

                        sbGroupBy.Append(" GROUP BY SL.PLT_CODE");
                        sbGroupBy.Append(" ,SL.LOT_ID");
                        sbGroupBy.Append(" ,S.PART_CODE");
                        sbGroupBy.Append(" ,S.DETAIL_PART_NAME");
                        sbGroupBy.Append(" ,S.STOCK_LOC");
                        sbGroupBy.Append(" ,S.PART_QTY");
                        sbGroupBy.Append(" ,SL.YPGO_ID");
                        sbGroupBy.Append(" ,SL.UNIT_COST");
                        sbGroupBy.Append(" ,S.STK_ID");
                        sbGroupBy.Append(" ,S.TOT_YPGO_AMT");
                        sbGroupBy.Append(" ,S.PART_QTY");

                        sbGroupBy.Append(" ORDER BY MIN(SL.REG_DATE)");

                        DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString() + sbWhere.ToString() + sbGroupBy.ToString()).Copy();

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

        public static DataTable TMAT_STOCK_LOG_DETAIL_QUERY3(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {

                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT");
                    sbQuery.Append(" SL.PLT_CODE");
                    sbQuery.Append(" ,SL.LOT_ID");
                    sbQuery.Append(" ,S.PART_CODE");
                    sbQuery.Append(" ,S.DETAIL_PART_NAME");
                    sbQuery.Append(" ,S.STOCK_LOC");
                    sbQuery.Append(" ,S.PART_QTY");
                    sbQuery.Append(" ,SL.YPGO_ID");
                    sbQuery.Append(" ,SL.UNIT_COST");
                    sbQuery.Append(" ,S.STK_ID");
                    sbQuery.Append(" ,S.TOT_YPGO_AMT");
                    sbQuery.Append(" ,S.PART_QTY");
                    sbQuery.Append(" ,SUM(SL.IN_QTY) AS IN_QTY");
                    sbQuery.Append(" ,SUM(SL.OUT_QTY) AS OUT_QTY");
                    sbQuery.Append(" ,SUM(SL.IN_QTY) - SUM(SL.OUT_QTY) AS REMAIN_QTY");
                    sbQuery.Append(" ,MIN(SL.REG_DATE) AS REG_DATE");
                    sbQuery.Append(" FROM TMAT_STOCK_LOG_DETAIL SL");
                    sbQuery.Append(" JOIN TMAT_STOCK S");
                    sbQuery.Append(" ON SL.PLT_CODE = S.PLT_CODE");
                    sbQuery.Append(" AND SL.STK_ID = S.STK_ID");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE SL.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                        sbWhere.Append(UTIL.GetWhere(row, "@YPGO_ID", " SL.YPGO_ID = @YPGO_ID"));
                        sbWhere.Append(UTIL.GetWhere(row, "@STK_ID", " S.STK_ID = @STK_ID"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_CODE", " S.PART_CODE = @PART_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@DETAIL_PART_NAME", " S.DETAIL_PART_NAME = @DETAIL_PART_NAME"));

                        StringBuilder sbGroupBy = new StringBuilder();

                        sbGroupBy.Append(" GROUP BY SL.PLT_CODE");
                        sbGroupBy.Append(" ,SL.LOT_ID");
                        sbGroupBy.Append(" ,S.PART_CODE");
                        sbGroupBy.Append(" ,S.DETAIL_PART_NAME");
                        sbGroupBy.Append(" ,S.STOCK_LOC");
                        sbGroupBy.Append(" ,S.PART_QTY");
                        sbGroupBy.Append(" ,SL.YPGO_ID");
                        sbGroupBy.Append(" ,SL.UNIT_COST");
                        sbGroupBy.Append(" ,S.STK_ID");
                        sbGroupBy.Append(" ,S.TOT_YPGO_AMT");
                        sbGroupBy.Append(" ,S.PART_QTY");

                        sbGroupBy.Append(" ORDER BY MIN(SL.REG_DATE)");

                        DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString() + sbWhere.ToString() + sbGroupBy.ToString()).Copy();

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

        public static DataTable TMAT_STOCK_LOG_DETAIL_QUERY4(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {

                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT");
                    sbQuery.Append(" SL.PLT_CODE");
                    sbQuery.Append(" ,SL.LOT_ID");
                    sbQuery.Append(" ,S.PART_CODE");
                    sbQuery.Append(" ,S.DETAIL_PART_NAME");
                    sbQuery.Append(" ,S.STOCK_LOC");
                    sbQuery.Append(" ,S.PART_QTY");
                    sbQuery.Append(" ,SL.YPGO_ID");
                    sbQuery.Append(" ,SL.UNIT_COST");
                    sbQuery.Append(" ,S.STK_ID");
                    sbQuery.Append(" ,S.TOT_YPGO_AMT");
                    sbQuery.Append(" ,S.PART_QTY");
                    sbQuery.Append(" ,SUM(SL.IN_QTY) AS IN_QTY");
                    sbQuery.Append(" ,SUM(SL.OUT_QTY) AS OUT_QTY");
                    sbQuery.Append(" ,SUM(SL.IN_QTY) - SUM(SL.OUT_QTY) AS REMAIN_QTY");
                    sbQuery.Append(" ,MIN(SL.REG_DATE) AS REG_DATE");
                    sbQuery.Append(" 	, P.PART_NAME     ");
                    sbQuery.Append(" 	, P.MAT_UNIT     ");
                    sbQuery.Append(" 	, P.MAT_LTYPE     ");
                    sbQuery.Append(" 	, P.MAT_MTYPE     ");
                    sbQuery.Append(" 	, P.MAT_STYPE     ");

                    sbQuery.Append(" FROM TMAT_STOCK_LOG_DETAIL SL");
                    sbQuery.Append(" JOIN TMAT_STOCK S");
                    sbQuery.Append(" ON SL.PLT_CODE = S.PLT_CODE");
                    sbQuery.Append(" AND SL.STK_ID = S.STK_ID");

                    sbQuery.Append(" LEFT JOIN LSE_STD_PART P");
                    sbQuery.Append(" ON S.PLT_CODE = P.PLT_CODE");
                    sbQuery.Append(" AND S.PART_CODE = P.PART_CODE");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE SL.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                        sbWhere.Append(UTIL.GetWhere(row, "@YPGO_ID", " SL.YPGO_ID = @YPGO_ID"));
                        sbWhere.Append(UTIL.GetWhere(row, "@STK_ID", " S.STK_ID = @STK_ID"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_CODE", " S.PART_CODE = @PART_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@DETAIL_PART_NAME", " S.DETAIL_PART_NAME = @DETAIL_PART_NAME"));

                        StringBuilder sbGroupBy = new StringBuilder();

                        sbGroupBy.Append(" GROUP BY SL.PLT_CODE");
                        sbGroupBy.Append(" ,SL.LOT_ID");
                        sbGroupBy.Append(" ,S.PART_CODE");
                        sbGroupBy.Append(" ,S.DETAIL_PART_NAME");
                        sbGroupBy.Append(" ,S.STOCK_LOC");
                        sbGroupBy.Append(" ,S.PART_QTY");
                        sbGroupBy.Append(" ,SL.YPGO_ID");
                        sbGroupBy.Append(" ,SL.UNIT_COST");
                        sbGroupBy.Append(" ,S.STK_ID");
                        sbGroupBy.Append(" ,S.TOT_YPGO_AMT");
                        sbGroupBy.Append(" ,S.PART_QTY");
                        sbGroupBy.Append(" 	, P.PART_NAME     ");
                        sbGroupBy.Append(" 	, P.MAT_UNIT     ");
                        sbGroupBy.Append(" 	, P.MAT_LTYPE     ");
                        sbGroupBy.Append(" 	, P.MAT_MTYPE     ");
                        sbGroupBy.Append(" 	, P.MAT_STYPE     ");

                        sbGroupBy.Append(" HAVING SUM(SL.IN_QTY) - SUM(SL.OUT_QTY) > 0");

                        sbGroupBy.Append(" ORDER BY MIN(SL.REG_DATE)");

                        DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString() + sbWhere.ToString() + sbGroupBy.ToString()).Copy();

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
