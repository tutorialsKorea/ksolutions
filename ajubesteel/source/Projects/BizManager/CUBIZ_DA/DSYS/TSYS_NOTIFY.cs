using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace DSYS
{
    public class TSYS_NOTIFY
    {
        public static void TSYS_NOTIFY_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("INSERT INTO TSYS_NOTIFY ");
                    sbQuery.Append("( ");
                    sbQuery.Append("       PLT_CODE ");
                    sbQuery.Append("     , EMP_CODE ");
                    sbQuery.Append("     , TITLE ");
                    sbQuery.Append("     , MESSAGE ");
                    sbQuery.Append("     , MENU_CODE ");
                    sbQuery.Append("     , SEARCH_KEY ");
                    sbQuery.Append("     , REG_DATE ");
                    sbQuery.Append("     , REG_EMP ");
                    sbQuery.Append(") ");
                    sbQuery.Append("VALUES ");
                    sbQuery.Append("( ");
                    sbQuery.Append("       @PLT_CODE ");
                    sbQuery.Append("     , @EMP_CODE ");
                    sbQuery.Append("     , @TITLE ");
                    sbQuery.Append("     , @MESSAGE ");
                    sbQuery.Append("     , @MENU_CODE ");
                    sbQuery.Append("     , @SEARCH_KEY ");
                    sbQuery.Append("     , GETDATE() ");
                    sbQuery.Append("     , @REG_EMP ");
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


        public static void TSYS_NOTIFY_DEL(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" DELETE FROM TSYS_NOTIFY ");
                    sbQuery.Append("  WHERE UID = @UID");

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

        public static void TSYS_NOTIFY_DEL2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" DELETE FROM TSYS_NOTIFY ");
                    sbQuery.Append("  WHERE SEARCH_KEY = @SEARCH_KEY");

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

    public class TSYS_NOTIFY_QUERY
    {
        public static DataTable TSYS_NOTIFY_QUERY1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT UID ");
                    sbQuery.Append("     ,PLT_CODE ");
                    sbQuery.Append("     ,EMP_CODE ");
                    sbQuery.Append("     ,TITLE ");
                    sbQuery.Append("     ,MESSAGE ");
                    sbQuery.Append("     ,MENU_CODE ");
                    sbQuery.Append("     ,SEARCH_KEY ");
                    sbQuery.Append("     ,REG_DATE ");
                    sbQuery.Append("     ,REG_EMP ");
                    sbQuery.Append(" FROM TSYS_NOTIFY ");

                    DataRow row = dtParam.Rows[0];

                    bool isHasColumn = true;
                    //검색 조건 유무 체크                        
                    if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                    if (!UTIL.ValidColumn(row, "EMP_CODE")) isHasColumn = false;

                    if (isHasColumn == true)
                    {
                        StringBuilder sbWhere = new StringBuilder();

                        sbWhere.Append(" WHERE 1=1 ");

                        sbWhere.Append(UTIL.GetWhere(row, "@PLT_CODE", " PLT_CODE = @PLT_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@EMP_CODE", " EMP_CODE = @EMP_CODE "));

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
