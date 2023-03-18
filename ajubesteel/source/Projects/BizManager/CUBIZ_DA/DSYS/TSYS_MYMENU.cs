using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace DSYS
{
    public class TSYS_MYMENU
    {
        public static DataTable TSYS_MYMENU_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("  SELECT  ");
                    sbQuery.Append("   PLT_CODE ");
                    sbQuery.Append(" , EMP_CODE ");
                    sbQuery.Append(" , MENU_CODE ");
                    sbQuery.Append(" , REG_DATE ");
                    sbQuery.Append("  FROM TSYS_MYMENU  ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("    AND EMP_CODE = @EMP_CODE  ");
                    sbQuery.Append("    AND MENU_CODE = @MENU_CODE  ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "EMP_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "MENU_CODE")) isHasColumn = false;

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

        public static void TSYS_MYMENU_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" INSERT INTO TSYS_MYMENU (  ");
                    sbQuery.Append(" PLT_CODE       ");
                    sbQuery.Append(" , EMP_CODE     ");
                    sbQuery.Append(" , MENU_CODE    ");
                    sbQuery.Append(" , REG_DATE     ");
                    sbQuery.Append("  ) VALUES (    ");
                    sbQuery.Append(" @PLT_CODE      ");
                    sbQuery.Append(" ,@EMP_CODE     ");
                    sbQuery.Append(" ,@MENU_CODE    ");
                    sbQuery.Append(" ,GETDATE()     ");
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

        public static void TSYS_MYMENU_DEL(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" DELETE FROM TSYS_MYMENU ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("    AND EMP_CODE = @EMP_CODE  ");
                    sbQuery.Append("    AND MENU_CODE = @MENU_CODE  ");


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


    public class TSYS_MYMENU_QUERY
    {

        public static DataTable TSYS_MYMENU_QUERY1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();


                    sbQuery.Append(" SELECT ");
                    sbQuery.Append(" A.MENU_CODE, ");
                    sbQuery.Append(" S.RES_CONTENTS AS MENU_NAME, ");
                    sbQuery.Append(" A.MENU_PARENT, ");
                    sbQuery.Append(" A.SCOMMENT,  ");
                    sbQuery.Append(" A.MENU_SEQ, ");
                    sbQuery.Append(" A.RES_ID,  ");
                    sbQuery.Append(" A.ICON, ");
                    sbQuery.Append(" A.CLASSNAME,  ");
                    sbQuery.Append(" A.ASSEMBLY, ");
                    sbQuery.Append(" 2 AS ACC_LEVEL, ");
                    sbQuery.Append(" 0 AS IS_DEFAULT_MENU, ");
                    sbQuery.Append(" A.IS_POP_MENU ");
                    sbQuery.Append(" ,A.HEADER_COLOR ");
                    sbQuery.Append(" FROM TSYS_MYMENU M JOIN TSYS_MENULIST A ");
                    sbQuery.Append(" ON M.PLT_CODE = A.PLT_CODE ");
                    sbQuery.Append(" AND M.MENU_CODE = A.MENU_CODE ");
                    sbQuery.Append(" LEFT JOIN TSYS_STRINGTABLE S ");
                    sbQuery.Append(" ON A.PLT_CODE = S.PLT_CODE ");
                    sbQuery.Append(" AND A.RES_ID = S.RES_ID ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder();

                        sbWhere.Append(" WHERE M.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@EMP_CODE", "M.EMP_CODE = @EMP_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@RES_LANG", "S.RES_LANG = @RES_LANG"));
                        sbWhere.Append(UTIL.GetWhere(row, "@STD_MENU", "A.IS_STD_MENU = 1"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PRO_MENU", "A.IS_PRO_MENU = 1"));
                        sbWhere.Append(UTIL.GetWhere(row, "@SYS_MENU", "A.IS_SYS_MENU = 0"));

                        sbWhere.Append(" ORDER BY A.MENU_SEQ");

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
