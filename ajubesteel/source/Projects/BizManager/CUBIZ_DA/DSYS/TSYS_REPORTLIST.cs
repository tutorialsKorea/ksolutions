using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace DSYS
{
    public class TSYS_REPORTLIST
    {
        public static DataTable TSYS_REPORTLIST_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {

            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT   PLT_CODE ");
                    sbQuery.Append("        , RPT_CLASS ");
                    sbQuery.Append("        , MENU_CODE ");
                    sbQuery.Append("        , RPT_CATEGORY_ID ");
                    sbQuery.Append("        , RPT_NAME ");
                    sbQuery.Append("        , SCOMMENT ");
                    sbQuery.Append("        , IS_USE ");
                    sbQuery.Append("   FROM TSYS_REPORTLIST ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("    AND RPT_CLASS = @RPT_CLASS ");


                    foreach (DataRow row in dtParam.Rows)
                    {                        

                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "RPT_CLASS")) isHasColumn = false;                        

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
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static void TSYS_REPORTLIST_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" INSERT INTO TSYS_REPORTLIST");
                    sbQuery.Append(" (PLT_CODE					");
                    sbQuery.Append(" ,RPT_CLASS					");
                    sbQuery.Append(" ,MENU_CODE					");
                    sbQuery.Append(" ,RPT_CATEGORY_ID			");
                    sbQuery.Append(" ,RPT_NAME					");
                    sbQuery.Append(" ,SCOMMENT					");
                    sbQuery.Append(" ,IS_USE)					");
                    sbQuery.Append(" VALUES						");
                    sbQuery.Append(" (@PLT_CODE					");
                    sbQuery.Append(" ,@RPT_CLASS				");
                    sbQuery.Append(" ,@MENU_CODE				");
                    sbQuery.Append(" ,@RPT_CATEGORY_ID			");
                    sbQuery.Append(" ,@RPT_NAME					");
                    sbQuery.Append(" ,@SCOMMENT					");
                    sbQuery.Append(" ,@IS_USE)					");

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


        public static void TSYS_REPORTLIST_UPD(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TSYS_REPORTLIST				");
                    sbQuery.Append(" SET MENU_CODE = @MENU_CODE			");
                    sbQuery.Append(" ,RPT_CATEGORY_ID = @RPT_CATEGORY_ID");
                    sbQuery.Append(" ,RPT_NAME = @RPT_NAME				");
                    sbQuery.Append(" ,SCOMMENT = @SCOMMENT				");
                    sbQuery.Append(" ,IS_USE = @IS_USE					");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE			");
                    sbQuery.Append(" AND RPT_CLASS = @RPT_CLASS			");


                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "RPT_CLASS")) isHasColumn = false;

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

        public static void TSYS_REPORTLIST_DEL(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" DELETE FROM TSYS_REPORTLIST    	");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE			");
                    sbQuery.Append(" AND RPT_CLASS = @RPT_CLASS			");


                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "RPT_CLASS")) isHasColumn = false;

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
    public class TSYS_REPORTLIST_QUERY
    {
        public static DataTable TSYS_REPORTLIST_QUERY1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT PLT_CODE	 ");
                    sbQuery.Append(" ,RPT_CATEGORY_ID	 ");
                    sbQuery.Append(" ,RPT_NAME			 ");
                    sbQuery.Append(" ,RPT_CLASS			 ");
                    sbQuery.Append(" ,RPT_ASSEMBLY			 ");
                    sbQuery.Append(" ,SCOMMENT			 ");
                    sbQuery.Append(" ,IS_USE			 ");
                    sbQuery.Append(" FROM TSYS_REPORTLIST");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@RPT_CATEGORY_ID", "RPT_CATEGORY_ID = @RPT_CATEGORY_ID"));
                        sbWhere.Append(UTIL.GetWhere(row, "@MENU_CODE", "MENU_CODE = @MENU_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@IS_USE", "IS_USE = @IS_USE"));

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

        public static DataTable TSYS_REPORTLIST_QUERY2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT R.PLT_CODE			  ");
                    sbQuery.Append(" ,R.RPT_CLASS				  ");
                    sbQuery.Append(" ,R.RPT_NAME				  ");
                    sbQuery.Append(" ,R.MENU_CODE				  ");
                    sbQuery.Append(" ,B.RES_CONTENTS AS MENU_NAME ");
                    sbQuery.Append(" ,R.RPT_CATEGORY_ID			  ");
                    sbQuery.Append(" ,R.SCOMMENT				  ");
                    sbQuery.Append(" ,R.IS_USE					  ");
                    sbQuery.Append(" FROM TSYS_REPORTLIST R		  ");
                    sbQuery.Append(" LEFT JOIN TSYS_MENULIST M	  ");
                    sbQuery.Append(" ON R.PLT_CODE = M.PLT_CODE	  ");
                    sbQuery.Append(" AND R.MENU_CODE = M.MENU_CODE");
                    sbQuery.Append(" LEFT JOIN TSYS_STRINGTABLE B ");
                    sbQuery.Append(" ON M.PLT_CODE = B.PLT_CODE	  ");
                    sbQuery.Append(" AND M.RES_ID = B.RES_ID	  ");
                    sbQuery.Append(" AND B.RES_LANG = @LANG		  ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE R.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@RPT_CLASS", "R.RPT_CLASS = @RPT_CLASS"));
                        sbWhere.Append(UTIL.GetWhere(row, "@RPT_NAME_LIKE", "R.RPT_NAME LIKE '%' + @RPT_NAME_LIKE + '%'"));
                        sbWhere.Append(" ORDER BY M.MENU_SEQ");

                        DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString() + sbWhere.ToString(), row).Copy();

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
