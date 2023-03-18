using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace DSYS
{
    public class TSYS_UPDATE
    {

        public static DataTable TSYS_UPDATE_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                DataTable dtResult = new DataTable("RSLTDT");

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("SELECT  ");
                    sbQuery.Append("       PLT_CODE  ");
                    sbQuery.Append("     , UPD_TITLE ");
                    sbQuery.Append("     , UPD_CONT  ");
                    sbQuery.Append("     , UPD_VER   ");
                    sbQuery.Append("     , UPD_DATE  ");
                    sbQuery.Append("FROM TSYS_UPDATE ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append("  AND UPD_ID = @UPD_ID ");
                    

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

        public static void TSYS_UPDATE_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("INSERT INTO TSYS_UPDATE ");
                    sbQuery.Append("( ");
                    sbQuery.Append("       PLT_CODE  ");
                    sbQuery.Append("     , UPD_TITLE ");
                    sbQuery.Append("     , UPD_CONT  ");
                    sbQuery.Append("     , UPD_VER   ");
                    sbQuery.Append("     , UPD_DATE  ");
                    sbQuery.Append(") ");
                    sbQuery.Append("VALUES ");
                    sbQuery.Append("( ");
                    sbQuery.Append("       @PLT_CODE ");
                    sbQuery.Append("     , @UPD_TITLE ");
                    sbQuery.Append("     , @UPD_CONT ");
                    sbQuery.Append("     , @UPD_VER ");                    
                    sbQuery.Append("     , GETDATE() ");
                    sbQuery.Append(") ");

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


        public static void TSYS_UPDATE_UPD(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TSYS_UPDATE ");
                    sbQuery.Append("   SET UPD_CONT = @UPD_CONT, ");
                    sbQuery.Append("    UPD_TITLE = @UPD_TITLE, ");
                    sbQuery.Append("    UPD_VER = @UPD_VER ");
                    sbQuery.Append("  WHERE UPD_ID = @UPD_ID ");

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

        public static void TSYS_UPDATE_DEL(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" DELETE FROM TSYS_UPDATE ");
                    sbQuery.Append("  WHERE UPD_ID = @UPD_ID ");

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
    }

    public class TSYS_UPDATE_QUERY
    {
        public static DataTable TSYS_UPDATE_QUERY1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT UPD_ID  ");
                    sbQuery.Append(" 	, PLT_CODE  ");
                    sbQuery.Append(" 	, UPD_TITLE  ");
                    sbQuery.Append(" 	, UPD_CONT  ");
                    sbQuery.Append(" 	, UPD_DATE  ");
                    sbQuery.Append(" 	, UPD_VER  ");
                    sbQuery.Append(" FROM TSYS_UPDATE  ");

                    DataRow row = dtParam.Rows[0];

                    StringBuilder sbWhere = new StringBuilder();

                    sbWhere.Append(" WHERE 1=1 ");

                    sbWhere.Append(UTIL.GetWhere(row, "@PLT_CODE", " PLT_CODE = @PLT_CODE"));
                    sbWhere.Append(UTIL.GetWhere(row, "@S_REG_DATE,@E_REG_DATE", " dbo.fn_dm_date(UPD_DATE) BETWEEN @S_REG_DATE AND @E_REG_DATE "));

                    sbWhere.Append(" ORDER BY UPD_DATE DESC ");

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
    }
}
