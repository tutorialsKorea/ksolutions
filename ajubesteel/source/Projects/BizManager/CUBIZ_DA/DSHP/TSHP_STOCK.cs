using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace DSHP
{
    public class TSHP_STOCK
    {
        public static DataTable TSHP_STOCK_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT S.PLT_CODE, ");
                    sbQuery.Append(" 	S.PART_CODE, ");
                    sbQuery.Append(" 	P.PART_NAME, ");
                    sbQuery.Append(" 	P.PART_PRODTYPE, ");
                    sbQuery.Append(" 	P.MAT_SPEC, ");
                    sbQuery.Append(" 	P.DRAW_NO, ");
                    sbQuery.Append(" 	S.WORK_DATE, ");
                    sbQuery.Append(" 	S.PART_QTY ");
                    sbQuery.Append(" FROM TSHP_STOCK S JOIN LSE_STD_PART P ");
                    sbQuery.Append(" ON S.PLT_CODE = P.PLT_CODE ");
                    sbQuery.Append("  AND S.PART_CODE = P.PART_CODE ");
                    sbQuery.Append(" WHERE S.PLT_CODE = @PLT_CODE ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;

                        if (isHasColumn == true)
                        {
                            StringBuilder sbWhere = new StringBuilder();

                            sbWhere.Append(UTIL.GetWhere(row, "@START_DATE", "S.WORK_DATE BETWEEN @START_DATE AND @END_DATE "));
                            
                            DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString() + sbWhere.ToString(), row).Copy();

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

        public static DataTable TSHP_STOCK_SER2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT S.PLT_CODE, ");
                    sbQuery.Append(" 	S.PROD_CODE, ");
                    sbQuery.Append(" 	S.PART_CODE, ");
                    sbQuery.Append(" 	S.STK_ID, ");
                    sbQuery.Append(" 	S.SHIP_ID, ");
                    sbQuery.Append(" 	S.STOCK_CODE, ");
                    sbQuery.Append(" 	S.STOCK_TYPE, ");
                    sbQuery.Append(" 	S.PART_QTY ");
                    sbQuery.Append(" FROM TSHP_STOCK S ");
                    sbQuery.Append(" WHERE S.SHIP_ID = @SHIP_ID ");
                    
                    DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString(), dtParam.Rows[0]).Copy();

                    dsResult.Tables.Add(sourceTable);

                }
                return UTIL.GetDsToDt(dsResult);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }


        public static DataTable TSHP_STOCK_SER3(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {

                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT S.PLT_CODE, ");
                    sbQuery.Append(" 	S.PROD_CODE, ");
                    sbQuery.Append(" 	S.PART_CODE, ");
                    sbQuery.Append(" 	S.STK_ID, ");
                    sbQuery.Append(" 	S.SHIP_ID, ");
                    sbQuery.Append(" 	S.STOCK_CODE, ");
                    sbQuery.Append(" 	S.STOCK_TYPE, ");
                    sbQuery.Append(" 	S.PART_QTY ");
                    sbQuery.Append(" FROM TSHP_STOCK S ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append("   AND PART_CODE = @PART_CODE ");

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

        public static void TSHP_STOCK_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" INSERT INTO TSHP_STOCK ");
                    sbQuery.Append(" (PLT_CODE,  ");
                    sbQuery.Append(" STK_ID,  ");
                    sbQuery.Append(" PROD_CODE,  ");
                    sbQuery.Append(" PART_CODE,  ");
                    sbQuery.Append(" STOCK_DATE,  ");
                    sbQuery.Append(" STOCK_CODE,  ");
                    sbQuery.Append(" STOCK_TYPE,  ");
                    sbQuery.Append(" PART_QTY,  ");
                    sbQuery.Append(" REG_DATE,  ");
                    sbQuery.Append(" REG_EMP ) ");
                    sbQuery.Append(" VALUES ");
                    sbQuery.Append(" (@PLT_CODE,  ");
                    sbQuery.Append(" @STK_ID,  ");
                    sbQuery.Append(" @PROD_CODE,  ");
                    sbQuery.Append(" @PART_CODE,  ");
                    sbQuery.Append(" convert(varchar,getdate(),112),  ");
                    sbQuery.Append(" @STOCK_CODE,  ");
                    sbQuery.Append(" @STOCK_TYPE,  ");
                    sbQuery.Append(" @PART_QTY,  ");
                    sbQuery.Append(" GETDATE(),  ");
                    sbQuery.Append(" " + UTIL.GetValidValue(ConnInfo.UserID) + " ) ");

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

        public static void TSHP_STOCK_UPD(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE  TSHP_STOCK ");
                    sbQuery.Append(" SET SHIP_ID = @SHIP_ID  ");
                    sbQuery.Append("   , MDFY_DATE = GETDATE() ");
                    sbQuery.Append("   , MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("   AND STK_ID = @STK_ID  ");
                    
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

        public static void TSHP_STOCK_DEL(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" DELETE FROM TSHP_STOCK ");
                    sbQuery.Append(" WHERE STK_ID = @STK_ID ");
                    
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

    
}
