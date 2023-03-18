using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace DSYS
{
    public class TSYS_TOOLTIP
    {
        public static DataTable TSYS_TOOLTIP_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT   PLT_CODE ");
                    sbQuery.Append("       , TT_GUID ");
                    sbQuery.Append("       , LANG ");
                    sbQuery.Append("       , TITLE ");
                    sbQuery.Append("       , CONTENTS ");                    
                    sbQuery.Append("  FROM TSYS_TOOLTIP ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("   AND TT_GUID  = @TT_GUID   ");
                    sbQuery.Append("   AND LANG  = @LANG  ");
                    
                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;                        
                        if (!UTIL.ValidColumn(row, "TT_GUID")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "LANG")) isHasColumn = false;

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

        public static void TSYS_TOOLTIP_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" INSERT INTO TSYS_TOOLTIP ");
                    sbQuery.Append(" ( ");
                    sbQuery.Append("        PLT_CODE ");
                    sbQuery.Append("      , TT_GUID ");
                    sbQuery.Append("      , LANG ");
                    sbQuery.Append("      , TITLE ");
                    sbQuery.Append("      , CONTENTS ");
                    sbQuery.Append(" ) ");
                    sbQuery.Append(" VALUES ");
                    sbQuery.Append(" ( ");
                    sbQuery.Append("        @PLT_CODE ");
                    sbQuery.Append("      , @TT_GUID ");
                    sbQuery.Append("      , @LANG ");
                    sbQuery.Append("      , @TITLE ");                    
                    sbQuery.Append("      , @CONTENTS ");
                    sbQuery.Append(" ) ");

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

        public static void TSYS_TOOLTIP_UPD(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TSYS_TOOLTIP ");
                    sbQuery.Append("   SET   TT_GUID  = @TT_GUID  ");
                    sbQuery.Append("       , LANG   = @LANG   ");
                    sbQuery.Append("       , TITLE  = @TITLE  ");
                    sbQuery.Append("       , CONTENTS  = @CONTENTS  ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("   AND TT_GUID  = @TT_GUID   ");
                    sbQuery.Append("   AND LANG  = @LANG  ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크                        
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "TT_GUID")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "LANG")) isHasColumn = false;

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

        public static void TSYS_TOOLTIP_DEL(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" DELETE FROM TSYS_TOOLTIP ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append("   AND TT_GUID  = @TT_GUID   ");
                    sbQuery.Append("   AND LANG  = @LANG  ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크                        
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "TT_GUID")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "LANG")) isHasColumn = false;

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

        public static void TSYS_TOOLTIP_DEL2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" DELETE FROM TSYS_TOOLTIP ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크   
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        
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

    public class TSYS_TOOLTIP_QUERY
    {

        public static DataTable TSYS_TOOLTIP_QUERY1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT PLT_CODE ");
                    sbQuery.Append(" ,TT_GUID ");
                    sbQuery.Append(" ,LANG ");
                    sbQuery.Append(" ,TITLE ");
                    sbQuery.Append(" ,CONTENTS ");                    
                    sbQuery.Append(" FROM TSYS_TOOLTIP ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;

                        if (isHasColumn == true)
                        {

                            StringBuilder sbWhere = new StringBuilder();

                            sbWhere.Append(" WHERE 1 = 1 ");
                            sbWhere.Append(UTIL.GetWhere(row, "@PLT_CODE", "PLT_CODE = @PLT_CODE"));
                            sbWhere.Append(UTIL.GetWhere(row, "@TT_GUID", "TT_GUID = @TT_GUID"));
                            sbWhere.Append(UTIL.GetWhere(row, "@CONTENTS_LIKE", "CONTENTS LIKE '%' + @CONTENTS_LIKE + '%'"));
                            sbWhere.Append(UTIL.GetWhere(row, "@LANG", "LANG = @LANG"));

                            DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString() + sbWhere.ToString()).Copy();

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
