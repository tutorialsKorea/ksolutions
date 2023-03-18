using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace DHIS
{
    public class THIS_STD_PM
    {
        public static DataTable THIS_STD_PM_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT  PLT_CODE      ");
                    sbQuery.Append("        , MTN_CODE ");
                    sbQuery.Append("        , MTN_NAME ");
                    sbQuery.Append("        , STD_PERIOD ");
                    sbQuery.Append("        , MTN_SEQ ");
                    sbQuery.Append("        , SCOMMENT ");
                    sbQuery.Append("        , REG_DATE ");
                    sbQuery.Append("        , REG_EMP ");
                    sbQuery.Append("        , MDFY_DATE ");
                    sbQuery.Append("        , MDFY_EMP ");
                    sbQuery.Append("  FROM THIS_STD_PM       ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append("   AND MTN_CODE = @MTN_CODE      ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "MTN_CODE")) isHasColumn = false;

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
        public static void THIS_STD_PM_UPD(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE THIS_STD_PM                      ");
                    sbQuery.Append("    SET  MTN_NAME   = @MTN_NAME     ");
                    sbQuery.Append("        , STD_PERIOD = @STD_PERIOD   ");
                    sbQuery.Append("        , MTN_SEQ    = @MTN_SEQ      ");
                    sbQuery.Append("        , SCOMMENT   = @SCOMMENT     ");
                    sbQuery.Append("        , MDFY_DATE = GETDATE() ");
                    sbQuery.Append("        , MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE           ");
                    sbQuery.Append("    AND MTN_CODE = @MTN_CODE             ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "MTN_CODE")) isHasColumn = false;

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
        public static void THIS_STD_PM_DEL(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" DELETE FROM  THIS_STD_PM                  ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE           ");
                    sbQuery.Append("    AND MTN_CODE = @MTN_CODE             ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "MTN_CODE")) isHasColumn = false;

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

        public static void THIS_STD_PM_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" INSERT INTO THIS_STD_PM ");
                    sbQuery.Append(" (                         ");
                    sbQuery.Append("        PLT_CODE      ");
                    sbQuery.Append("        , MTN_CODE ");
                    sbQuery.Append("        , MTN_NAME ");
                    sbQuery.Append("        , STD_PERIOD ");
                    sbQuery.Append("        , MTN_SEQ ");
                    sbQuery.Append("        , SCOMMENT ");
                    sbQuery.Append("        , REG_DATE ");
                    sbQuery.Append("        , REG_EMP ");
                    sbQuery.Append(" )                         ");
                    sbQuery.Append(" VALUES                    ");
                    sbQuery.Append(" (                         ");
                    sbQuery.Append("        @PLT_CODE      ");
                    sbQuery.Append("        , @MTN_CODE ");
                    sbQuery.Append("        , @MTN_NAME ");
                    sbQuery.Append("        , @STD_PERIOD ");
                    sbQuery.Append("        , @MTN_SEQ ");
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

    public class THIS_STD_PM_QUERY
    {
        /// <summary>
        /// 계측기 목록
        /// </summary>
        /// <param name="dtParam"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataTable THIS_STD_PM_QUERY1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT SP.PLT_CODE      ");
                    sbQuery.Append("        , SP.MTN_CODE ");
                    sbQuery.Append("        , SP.MTN_NAME ");
                    sbQuery.Append("        , SP.STD_PERIOD ");
                    sbQuery.Append("        , SP.MTN_SEQ ");
                    sbQuery.Append("        , SP.SCOMMENT AS MTN_SCOMMENT");
                    sbQuery.Append("        , SPP.MTN_CODE AS FK_MTN_CODE");
                    sbQuery.Append("        , SPP.PART_CODE ");
                    sbQuery.Append("        , SPP.USE_QTY ");
                    sbQuery.Append("        , SPP.SCOMMENT AS MTN_PART_SCOMMENT");
                    sbQuery.Append("        , SPP.MTN_MC_APPLY ");
                    sbQuery.Append("        , LSP.PART_CODE ");
                    sbQuery.Append("        , LSP.PART_NAME ");
                    sbQuery.Append("        , LSP.MAT_SPEC ");
                    sbQuery.Append("  FROM THIS_STD_PM SP      ");
                    sbQuery.Append("    LEFT JOIN THIS_STD_PM_PARTS SPP     ");
                    sbQuery.Append("        ON SP.PLT_CODE = SPP.PLT_CODE     ");
                    sbQuery.Append("        AND SP.MTN_CODE = SPP.MTN_CODE     ");
                    sbQuery.Append("    LEFT JOIN LSE_STD_PART LSP     ");
                    sbQuery.Append("        ON SPP.PLT_CODE = LSP.PLT_CODE     ");
                    sbQuery.Append("        AND SPP.PART_CODE = LSP.PART_CODE     ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE SP.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@MTN_CODE", "SP.MTN_CODE = @MTN_CODE "));
                        
                        sbWhere.Append(UTIL.GetWhere(row, "@MTN_LIKE", "(SP.MTN_CODE LIKE '%' + @MTN_LIKE + '%' OR SP.MTN_NAME LIKE '%' + @MTN_LIKE + '%')"));


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
