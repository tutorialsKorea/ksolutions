using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace DSYS
{
    public class TSYS_STRINGTABLE
    {
        public static DataTable TSYS_STRINGTABLE_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT   PLT_CODE  ");
                    sbQuery.Append(" , RES_ID  ");
                    sbQuery.Append(" , RES_LANG ");
                    sbQuery.Append(" , RES_TYPE ");
                    sbQuery.Append(" , RES_CONTENTS ");
                    sbQuery.Append(" FROM TSYS_STRINGTABLE ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append(" AND RES_LANG = @RES_LANG ");
                    sbQuery.Append(" AND RES_ID = @RES_ID ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "RES_LANG")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "RES_ID")) isHasColumn = false;
                        
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

        public static void TSYS_STRINGTABLE_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("INSERT INTO TSYS_STRINGTABLE");
                    sbQuery.Append("(");
                    sbQuery.Append("  PLT_CODE");
                    sbQuery.Append("  , RES_ID");
                    sbQuery.Append("  , RES_LANG");
                    sbQuery.Append("  , RES_TYPE");
                    sbQuery.Append("  , RES_CONTENTS");
                    sbQuery.Append(")");
                    sbQuery.Append("VALUES");
                    sbQuery.Append("(");
                    sbQuery.Append("  @PLT_CODE");
                    sbQuery.Append("  , @RES_ID");
                    sbQuery.Append("  , @RES_LANG");
                    sbQuery.Append("  , @RES_TYPE");
                    sbQuery.Append("  , @RES_CONTENTS");
                    sbQuery.Append(")");

                    foreach(DataRow row in dtParam.Rows)
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

        public static void TSYS_STRINGTABLE_UPD(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("UPDATE TSYS_STRINGTABLE");
                    sbQuery.Append("  SET   PLT_CODE = @PLT_CODE");
                    sbQuery.Append("      , RES_ID = @RES_ID");
                    sbQuery.Append("      , RES_LANG = @RES_LANG");
                    sbQuery.Append("      , RES_CONTENTS = @RES_CONTENTS ");
                    sbQuery.Append("WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append("  AND RES_ID = @RES_ID ");
                    sbQuery.Append("  AND RES_LANG = @RES_LANG");
                    
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

        /// <summary>
        /// resource 일괄변경

        /// </summary>
        /// <param name="dtParam"></param>
        /// <param name="bizExecute"></param>
        public static void TSYS_STRINGTABLE_UPD3(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("UPDATE TSYS_STRINGTABLE");
                    sbQuery.Append(" SET   ");
                    sbQuery.Append("  RES_CONTENTS = REPLACE(RES_CONTENTS, '" + dtParam.Rows[0]["ORIGINAL_CONTENTS"].ToString() + "', '" + dtParam.Rows[0]["CHANGE_CONTENTS"].ToString() + "') ");
                    sbQuery.Append(" WHERE PLT_CODE = '" + dtParam.Rows [0]["PLT_CODE"].ToString() + "'");
                    sbQuery.Append("  AND RES_LANG = '" + dtParam.Rows[0]["LANG"].ToString() + "'");

                    bizExecute.executeInsertQuery(sbQuery.ToString());

                }
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }


        public static void TSYS_STRINGTABLE_DEL(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try 
            { 
                StringBuilder sbQuery = new StringBuilder();

                sbQuery.Append("DELETE FROM TSYS_STRINGTABLE ");
                sbQuery.Append("WHERE PLT_CODE = @PLT_CODE  ");
                sbQuery.Append("  AND RES_ID = @RES_ID  ");
                sbQuery.Append("  AND RES_LANG = @RES_LANG ");

                foreach (DataRow row in dtParam.Rows)
                {
                    bizExecute.executeInsertQuery(sbQuery.ToString(), row);
                }

            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }
    }


    public class TSYS_STRINGTABLE_QUERY
    {
        //기본 조회
        public static DataTable TSYS_STRINGTABLE_QUERY1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT   PLT_CODE  ");
                    sbQuery.Append(" , RES_ID  ");
                    sbQuery.Append(" , RES_LANG ");
                    sbQuery.Append(" , RES_TYPE ");
                    sbQuery.Append(" , RES_CONTENTS ");
                    sbQuery.Append(" FROM TSYS_STRINGTABLE ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "RES_LANG")) isHasColumn = false;

                        StringBuilder sbWhere = new StringBuilder();

                        sbWhere.Append(" WHERE 1 = 1 ");

                        sbWhere.Append(UTIL.GetWhere(row, "@PLT_CODE", "PLT_CODE = @PLT_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@RES_LANG", "RES_LANG = @RES_LANG"));
                        sbWhere.Append(UTIL.GetWhere(row, "@RES_ID", "RES_ID = @RES_ID"));
                        sbWhere.Append(UTIL.GetWhere(row, "@RES_CONTENTS_LIKE", "RES_CONTENTS LIKE '%' + @RES_CONTENTS_LIKE + '%'"));

                        //string strWhere = UTIL.GetWhere(row, "@RES_CONTENTS_LIKE", "RES_CONTENTS LIKE '%' + @RES_CONTENTS_LIKE + '%'");
                        //sbQuery.Append(" AND RES_ID = @RES_ID ");

                        if (isHasColumn == true)
                        {
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

        /// <summary>
        /// 다국어 복사용 조회
        /// </summary>
        /// <param name="dtParam"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataTable TSYS_STRINGTABLE_QUERY2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT S.PLT_CODE ");
                    sbQuery.Append("       ,S.RES_ID ");
                    sbQuery.Append("       ,S.RES_LANG ");
                    sbQuery.Append("       ,S.RES_TYPE ");
                    sbQuery.Append("       ,S.RES_CONTENTS ");
                    sbQuery.Append(" FROM TSYS_STRINGTABLE S ");
                    sbQuery.Append(" WHERE S.PLT_CODE = @PLT_CODE ");
                    sbQuery.Append(" AND S.RES_LANG = @ORIGINAL_LANG ");
                    sbQuery.Append(" AND S.RES_ID NOT IN (SELECT RES_ID FROM TSYS_STRINGTABLE ");
                    sbQuery.Append(" WHERE PLT_CODE = S.PLT_CODE AND RES_LANG = @TARGET_LANG) ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "ORIGINAL_LANG")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "TARGET_LANG")) isHasColumn = false;

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

        
    }
}
