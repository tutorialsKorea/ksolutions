using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace DHIS
{
    public class THIS_PM_MC
    {
        public static DataTable THIS_PM_MC_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT  PLT_CODE      ");
                    sbQuery.Append("        , MTN_CODE ");
                    sbQuery.Append("        , MC_CODE ");
                    sbQuery.Append("        , MC_PERIOD ");
                    sbQuery.Append("        , SCOMMENT ");
                    sbQuery.Append("        , REG_DATE ");
                    sbQuery.Append("        , REG_EMP ");
                    sbQuery.Append("        , MDFY_DATE ");
                    sbQuery.Append("        , MDFY_EMP ");
                    sbQuery.Append("  FROM THIS_PM_MC       ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append("   AND MTN_CODE = @MTN_CODE      ");
                    sbQuery.Append("   AND MC_CODE = @MC_CODE      ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "MTN_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "MC_CODE")) isHasColumn = false;

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
        /// 상태변경
        /// </summary>
        /// <param name="dtParam"></param>
        /// <param name="bizExecute"></param>
        public static void THIS_PM_MC_UPD(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE THIS_PM_MC                      ");
                    sbQuery.Append("    SET  MC_PERIOD   = @MC_PERIOD     ");
                    sbQuery.Append("        , SCOMMENT   = @SCOMMENT     ");
                    sbQuery.Append("        , MDFY_DATE = GETDATE() ");
                    sbQuery.Append("        , MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE           ");
                    sbQuery.Append("    AND MTN_CODE = @MTN_CODE             ");
                    sbQuery.Append("    AND MC_CODE = @MC_CODE             ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "MTN_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "MC_CODE")) isHasColumn = false;

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
        /// 계측기 삭제
        /// </summary>
        /// <param name="dtParam"></param>
        /// <param name="bizExecute"></param>
        public static void THIS_PM_MC_DEL(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" DELETE FROM  THIS_PM_MC                  ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE           ");
                    sbQuery.Append("    AND MTN_CODE = @MTN_CODE             ");
                    sbQuery.Append("    AND MC_CODE = @MC_CODE             ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "MTN_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "MC_CODE")) isHasColumn = false;

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

        public static void THIS_PM_MC_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" INSERT INTO THIS_PM_MC ");
                    sbQuery.Append(" (                         ");
                    sbQuery.Append("        PLT_CODE      ");
                    sbQuery.Append("        , MTN_CODE ");
                    sbQuery.Append("        , MC_CODE ");
                    sbQuery.Append("        , MC_PERIOD ");
                    sbQuery.Append("        , SCOMMENT ");
                    sbQuery.Append("        , REG_DATE ");
                    sbQuery.Append("        , REG_EMP ");
                    sbQuery.Append(" )                         ");
                    sbQuery.Append(" VALUES                    ");
                    sbQuery.Append(" (                         ");
                    sbQuery.Append("        @PLT_CODE      ");
                    sbQuery.Append("        , @MTN_CODE ");
                    sbQuery.Append("        , @MC_CODE ");
                    sbQuery.Append("        , @MC_PERIOD ");
                    sbQuery.Append("        , @SCOMMENT ");
                    sbQuery.Append("        , GETDATE()");
                    sbQuery.Append("        , " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" )                         ");

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

    public class THIS_PM_MC_QUERY
    {
        /// <summary>
        /// 계측기 목록
        /// </summary>
        /// <param name="dtParam"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataTable THIS_PM_MC_QUERY1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT PM.PLT_CODE      ");
                    sbQuery.Append("        , PM.MTN_CODE ");
                    sbQuery.Append("        , SP.MTN_NAME ");
                    sbQuery.Append("        , PM.MC_CODE ");
                    sbQuery.Append("        , MC.MC_NAME "); 
                    sbQuery.Append("        , MC.MC_GROUP "); 
                    sbQuery.Append("        , MC.MC_MAKER ");
                    sbQuery.Append("        , PM.MC_PERIOD ");
                    sbQuery.Append("        , ISNULL(PM.ACT_DATE,FORMAT(getdate(), 'yyyyMMdd')) AS ACT_DATE ");
                    sbQuery.Append("        , PM.SCOMMENT ");
                    sbQuery.Append("        , MC.SCOMMENT AS M_SCOMMENT ");
                    sbQuery.Append("        , SP.SCOMMENT AS P_SCOMMENT");
                    sbQuery.Append("        , PM.REG_DATE ");
                    sbQuery.Append("        , PM.REG_EMP ");
                    sbQuery.Append("        , PM.MDFY_DATE ");
                    sbQuery.Append("        , PM.MDFY_EMP ");
                    sbQuery.Append("  FROM THIS_PM_MC PM      ");
                    sbQuery.Append("    INNER JOIN THIS_STD_PM SP     ");
                    sbQuery.Append("        ON PM.PLT_CODE = SP.PLT_CODE     ");
                    sbQuery.Append("        AND PM.MTN_CODE = SP.MTN_CODE     ");
                    sbQuery.Append("    LEFT JOIN LSE_MACHINE MC     ");
                    sbQuery.Append("        ON PM.PLT_CODE = MC.PLT_CODE     ");
                    sbQuery.Append("        AND PM.MC_CODE = MC.MC_CODE     ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE PM.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@MTN_CODE", "PM.MTN_CODE = @MTN_CODE "));
                        sbWhere.Append(UTIL.GetWhere(row, "@MC_CODE", "PM.MC_CODE = @MC_CODE "));

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
