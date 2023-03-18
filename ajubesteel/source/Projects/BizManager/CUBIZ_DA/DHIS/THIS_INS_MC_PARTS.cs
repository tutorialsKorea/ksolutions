using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace DHIS
{
    public class THIS_INS_MC_PARTS
    {
        public static DataTable THIS_INS_MC_PARTS_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT  PLT_CODE      ");
                    sbQuery.Append("        , MRI_CODE ");
                    sbQuery.Append("        , MC_CODE ");
                    sbQuery.Append("        , PART_CODE ");
                    sbQuery.Append("        , USE_QTY ");
                    sbQuery.Append("        , SCOMMENT ");
                    sbQuery.Append("        , REG_DATE ");
                    sbQuery.Append("        , REG_EMP ");
                    sbQuery.Append("        , MDFY_DATE ");
                    sbQuery.Append("        , MDFY_EMP ");
                    sbQuery.Append("  FROM THIS_INS_MC_PARTS       ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append("   AND MRI_CODE = @MRI_CODE      ");
                    sbQuery.Append("   AND MC_CODE = @MC_CODE      ");
                    sbQuery.Append("   AND PART_CODE = @PART_CODE      ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "MRI_CODE")) isHasColumn = false;
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
        public static void THIS_INS_MC_PARTS_UPD(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE THIS_INS_MC_PARTS                      ");
                    sbQuery.Append("    SET  USE_QTY   = @USE_QTY     ");
                    sbQuery.Append("        , SCOMMENT   = @SCOMMENT     ");
                    sbQuery.Append("        , MDFY_DATE = GETDATE() ");
                    sbQuery.Append("        , MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE           ");
                    sbQuery.Append("    AND MRI_CODE = @MRI_CODE             ");
                    sbQuery.Append("    AND MC_CODE = @MC_CODE             ");
                    sbQuery.Append("   AND PART_CODE = @PART_CODE      ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "MRI_CODE")) isHasColumn = false;
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
        public static void THIS_INS_MC_PARTS_DEL(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" DELETE FROM  THIS_INS_MC_PARTS                  ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE           ");
                    sbQuery.Append("    AND MRI_CODE = @MRI_CODE             ");
                    sbQuery.Append("    AND MC_CODE = @MC_CODE             ");
                    sbQuery.Append("    AND PART_CODE = @PART_CODE             ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "MRI_CODE")) isHasColumn = false;
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

        public static void THIS_INS_MC_PARTS_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" INSERT INTO THIS_INS_MC_PARTS ");
                    sbQuery.Append(" (                         ");
                    sbQuery.Append("        PLT_CODE      ");
                    sbQuery.Append("        , MRI_CODE ");
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
                    sbQuery.Append("        , @MRI_CODE ");
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

    }




    public class THIS_INS_MC_PARTS_QUERY
    {

        public static DataTable THIS_PM_MC_PARTS_QUERY1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT TIMP.PLT_CODE      ");
                    sbQuery.Append("        , TIMP.MRI_CODE ");
                    sbQuery.Append("        , TIMP.MC_CODE ");
                    sbQuery.Append("        , TIMP.PART_CODE ");
                    sbQuery.Append("        , PART.PART_NAME ");
                    sbQuery.Append("        , PART.MAT_SPEC ");
                    sbQuery.Append("        , TIMP.USE_QTY ");
                    sbQuery.Append("        , TIMP.SCOMMENT ");
                    sbQuery.Append("        , TIMP.REG_DATE ");
                    sbQuery.Append("        , TIMP.REG_EMP ");
                    sbQuery.Append("        , TIMP.MDFY_DATE ");
                    sbQuery.Append("        , TIMP.MDFY_EMP ");
                    sbQuery.Append("  FROM THIS_INS_MC_PARTS TIMP      ");
                    sbQuery.Append("    INNER JOIN LSE_STD_PART PART     ");
                    sbQuery.Append("        ON TIMP.PLT_CODE = PART.PLT_CODE     ");
                    sbQuery.Append("        AND TIMP.PART_CODE = PART.PART_CODE     ");
                    sbQuery.Append("        AND PART.DATA_FLAG = 0    ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE TIMP.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@MRI_CODE", "TIMP.MRI_CODE = @MRI_CODE "));
                        sbWhere.Append(UTIL.GetWhere(row, "@MC_CODE", "TIMP.MC_CODE = @MC_CODE "));
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_CODE", "TIMP.PART_CODE = @PART_CODE "));

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
