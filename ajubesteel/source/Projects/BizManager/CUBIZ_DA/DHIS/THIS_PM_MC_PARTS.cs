using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace DHIS
{
    public class THIS_PM_MC_PARTS
    {
        public static DataTable THIS_PM_MC_PARTS_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
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
                    sbQuery.Append("        , PART_CODE ");
                    sbQuery.Append("        , USE_QTY ");
                    sbQuery.Append("        , SCOMMENT ");
                    sbQuery.Append("        , REG_DATE ");
                    sbQuery.Append("        , REG_EMP ");
                    sbQuery.Append("        , MDFY_DATE ");
                    sbQuery.Append("        , MDFY_EMP ");
                    sbQuery.Append("  FROM THIS_PM_MC_PARTS       ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append("   AND MTN_CODE = @MTN_CODE      ");
                    sbQuery.Append("   AND MC_CODE = @MC_CODE      ");
                    sbQuery.Append("   AND PART_CODE = @PART_CODE      ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "MTN_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "MC_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PART_CODE")) isHasColumn = false;

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
        public static void THIS_PM_MC_PARTS_UPD(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE THIS_PM_MC_PARTS                      ");
                    sbQuery.Append("    SET  USE_QTY   = @USE_QTY     ");
                    sbQuery.Append("        , SCOMMENT   = @SCOMMENT     ");
                    sbQuery.Append("        , MDFY_DATE = GETDATE() ");
                    sbQuery.Append("        , MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE           ");
                    sbQuery.Append("    AND MTN_CODE = @MTN_CODE             ");
                    sbQuery.Append("    AND MC_CODE = @MC_CODE             ");
                    sbQuery.Append("   AND PART_CODE = @PART_CODE      ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "MTN_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "MC_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PART_CODE")) isHasColumn = false;

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
        public static void THIS_PM_MC_PARTS_DEL(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" DELETE FROM  THIS_PM_MC_PARTS                  ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE           ");
                    sbQuery.Append("    AND MTN_CODE = @MTN_CODE             ");
                    sbQuery.Append("    AND MC_CODE = @MC_CODE             ");
                    sbQuery.Append("    AND PART_CODE = @PART_CODE             ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "MTN_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "MC_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PART_CODE")) isHasColumn = false;

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

        public static void THIS_PM_MC_PARTS_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" INSERT INTO THIS_PM_MC_PARTS ");
                    sbQuery.Append(" (                         ");
                    sbQuery.Append("        PLT_CODE      ");
                    sbQuery.Append("        , MTN_CODE ");
                    sbQuery.Append("        , MC_CODE ");
                    sbQuery.Append("        , PART_CODE ");
                    sbQuery.Append("        , USE_QTY ");
                    sbQuery.Append("        , SCOMMENT ");
                    sbQuery.Append("        , REG_DATE ");
                    sbQuery.Append("        , REG_EMP ");
                    sbQuery.Append(" )                         ");
                    sbQuery.Append(" VALUES                    ");
                    sbQuery.Append(" (                         ");
                    sbQuery.Append("        @PLT_CODE      ");
                    sbQuery.Append("        , @MTN_CODE ");
                    sbQuery.Append("        , @MC_CODE ");
                    sbQuery.Append("        , @PART_CODE ");
                    sbQuery.Append("        , @USE_QTY ");
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
        public static void THIS_PM_MC_PARTS_COPY(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" INSERT INTO THIS_PM_MC_PARTS ");
                    sbQuery.Append(" (                         ");
                    sbQuery.Append("        PLT_CODE      ");
                    sbQuery.Append("        , MTN_CODE ");
                    sbQuery.Append("        , MC_CODE ");
                    sbQuery.Append("        , PART_CODE ");
                    sbQuery.Append("        , USE_QTY ");
                    sbQuery.Append("        , SCOMMENT ");
                    sbQuery.Append("        , REG_DATE ");
                    sbQuery.Append("        , REG_EMP ");
                    sbQuery.Append(" )                         ");
                    sbQuery.Append(" SELECT                    ");
                    sbQuery.Append("        PLT_CODE                ");
                    sbQuery.Append("        , @MTN_CODE             ");
                    sbQuery.Append("        , @MC_CODE             ");
                    sbQuery.Append("        , PART_CODE             ");
                    sbQuery.Append("        , USE_QTY             ");
                    sbQuery.Append("        , SCOMMENT             ");
                    sbQuery.Append("        , GETDATE()             ");
                    sbQuery.Append("        , " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" FROM THIS_STD_PM_PARTS                    ");
                    sbQuery.Append("    WHERE PLT_CODE = @PLT_CODE                    ");
                    sbQuery.Append("    AND MTN_CODE = @MTN_CODE                    ");
                    sbQuery.Append("    AND MTN_MC_APPLY = 1                    ");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "MTN_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "MC_CODE")) isHasColumn = false;

                        if (isHasColumn == true)
                        {
                            bizExecute.executeInsertQuery(sbQuery.ToString(), row);
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

    public class THIS_PM_MC_PARTS_QUERY
    {
        /// <summary>
        /// 계측기 목록
        /// </summary>
        /// <param name="dtParam"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataTable THIS_PM_MC_PARTS_QUERY1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT PMP.PLT_CODE      ");
                    sbQuery.Append("        , PMP.MTN_CODE ");
                    sbQuery.Append("        , SP.MTN_NAME ");
                    sbQuery.Append("        , PMP.MC_CODE ");
                    sbQuery.Append("        , MC.MC_NAME ");
                    sbQuery.Append("        , PMP.PART_CODE ");
                    sbQuery.Append("        , PART.PART_NAME ");
                    sbQuery.Append("        , PART.MAT_SPEC ");
                    sbQuery.Append("        , PMP.USE_QTY ");
                    sbQuery.Append("        , PMP.SCOMMENT ");
                    sbQuery.Append("        , PMP.REG_DATE ");
                    sbQuery.Append("        , PMP.REG_EMP ");
                    sbQuery.Append("        , PMP.MDFY_DATE ");
                    sbQuery.Append("        , PMP.MDFY_EMP ");
                    sbQuery.Append("  FROM THIS_PM_MC_PARTS PMP      ");
                    sbQuery.Append("    INNER JOIN THIS_STD_PM SP     ");
                    sbQuery.Append("        ON PMP.PLT_CODE = SP.PLT_CODE     ");
                    sbQuery.Append("        AND PMP.MTN_CODE = SP.MTN_CODE     ");
                    sbQuery.Append("    INNER JOIN LSE_MACHINE MC     ");
                    sbQuery.Append("        ON PMP.PLT_CODE = MC.PLT_CODE     ");
                    sbQuery.Append("        AND PMP.MC_CODE = MC.MC_CODE     ");
                    sbQuery.Append("    INNER JOIN LSE_STD_PART PART     ");
                    sbQuery.Append("        ON PMP.PLT_CODE = PART.PLT_CODE     ");
                    sbQuery.Append("        AND PMP.PART_CODE = PART.PART_CODE     ");
                    sbQuery.Append("        AND PART.DATA_FLAG = 0    ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE PMP.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@MTN_CODE", "PMP.MTN_CODE = @MTN_CODE "));
                        sbWhere.Append(UTIL.GetWhere(row, "@MC_CODE", "PMP.MC_CODE = @MC_CODE "));
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_CODE", "PMP.PART_CODE = @PART_CODE "));

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
