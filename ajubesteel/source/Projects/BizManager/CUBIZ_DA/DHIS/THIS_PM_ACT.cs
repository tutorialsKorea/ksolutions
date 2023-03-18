using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace DHIS
{
    public class THIS_PM_ACT
    {
        public static DataTable THIS_PM_ACT_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT    ");
                    sbQuery.Append(" PLT_CODE     ");
                    sbQuery.Append(" , PM_ACT_CODE  ");
                    sbQuery.Append(" , MC_CODE      ");
                    sbQuery.Append(" , PM_DATE      ");
                    sbQuery.Append(" , PM_TYPE      ");
                    sbQuery.Append(" , MTN_CODE     ");
                    sbQuery.Append(" , PLN_DATE     ");
                    sbQuery.Append(" , PM_GUBUN     ");
                    sbQuery.Append(" , PART_SUPPLY  ");
                    sbQuery.Append(" , PM_TIME      ");
                    sbQuery.Append(" , PM_CONTENTS  ");
                    sbQuery.Append(" , PM_COST      ");
                    sbQuery.Append(" , PM_VND       ");
                    sbQuery.Append(" , PM_CHARGE    ");
                    sbQuery.Append(" , REG_DATE     ");
                    sbQuery.Append(" , REG_EMP      ");
                    sbQuery.Append(" , MDFY_DATE    ");
                    sbQuery.Append(" , MDFY_EMP     ");
                    sbQuery.Append("  FROM THIS_PM_ACT       ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append("   AND PM_ACT_CODE = @PM_ACT_CODE      ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PM_ACT_CODE")) isHasColumn = false;

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
        public static void THIS_PM_ACT_UPD(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE THIS_PM_ACT                      ");
                    sbQuery.Append("    SET  ");
                    sbQuery.Append("         PM_DATE     = @PM_DATE     ");
                    sbQuery.Append("        , MTN_CODE    = @MTN_CODE    ");
                    sbQuery.Append("        , PM_GUBUN    = @PM_GUBUN    ");
                    sbQuery.Append("        , PART_SUPPLY = @PART_SUPPLY ");
                    sbQuery.Append("        , PM_TIME     = @PM_TIME     ");
                    sbQuery.Append("        , PM_CONTENTS = @PM_CONTENTS ");
                    sbQuery.Append("        , PM_COST     = @PM_COST     ");
                    sbQuery.Append("        , PM_VND      = @PM_VND      ");
                    sbQuery.Append("        , PM_CHARGE   = @PM_CHARGE   ");
                    sbQuery.Append("        , MDFY_DATE = GETDATE() ");
                    sbQuery.Append("        , MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append("   AND PM_ACT_CODE = @PM_ACT_CODE      ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PM_ACT_CODE")) isHasColumn = false;

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
        public static void THIS_PM_ACT_DEL(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" DELETE FROM  THIS_PM_ACT                  ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append("   AND PM_ACT_CODE = @PM_ACT_CODE      ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PM_ACT_CODE")) isHasColumn = false;

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

        public static void THIS_PM_ACT_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" INSERT INTO THIS_PM_ACT ");
                    sbQuery.Append(" (                         ");
                    sbQuery.Append("        PLT_CODE     ");
                    sbQuery.Append("        , PM_ACT_CODE  ");
                    sbQuery.Append("        , MC_CODE      ");
                    sbQuery.Append("        , PM_DATE      ");
                    sbQuery.Append("        , PM_TYPE      ");
                    sbQuery.Append("        , MTN_CODE     ");
                    sbQuery.Append("        , PLN_DATE     ");
                    sbQuery.Append("        , PM_GUBUN     ");
                    sbQuery.Append("        , PART_SUPPLY  ");
                    sbQuery.Append("        , PM_TIME      ");
                    sbQuery.Append("        , PM_CONTENTS  ");
                    sbQuery.Append("        , PM_COST      ");
                    sbQuery.Append("        , PM_VND       ");
                    sbQuery.Append("        , PM_CHARGE    ");
                    sbQuery.Append("        , REG_DATE ");
                    sbQuery.Append("        , REG_EMP ");
                    sbQuery.Append(" )                         ");
                    sbQuery.Append(" VALUES                    ");
                    sbQuery.Append(" (                         ");
                    sbQuery.Append("        @PLT_CODE     ");
                    sbQuery.Append("        , @PM_ACT_CODE  ");
                    sbQuery.Append("        , @MC_CODE      ");
                    sbQuery.Append("        , @PM_DATE      ");
                    sbQuery.Append("        , @PM_TYPE      ");
                    sbQuery.Append("        , @MTN_CODE     ");
                    sbQuery.Append("        , @PLN_DATE     ");
                    sbQuery.Append("        , @PM_GUBUN     ");
                    sbQuery.Append("        , @PART_SUPPLY  ");
                    sbQuery.Append("        , @PM_TIME      ");
                    sbQuery.Append("        , @PM_CONTENTS  ");
                    sbQuery.Append("        , @PM_COST      ");
                    sbQuery.Append("        , @PM_VND       ");
                    sbQuery.Append("        , @PM_CHARGE    ");
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

    public class THIS_PM_ACT_QUERY
    {
        public static DataTable THIS_PM_ACT_QUERY1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT PA.PLT_CODE      ");
                    sbQuery.Append("        , PA.PM_ACT_CODE  ");
                    sbQuery.Append("        , PA.MC_CODE      ");
                    sbQuery.Append("        , PA.PM_DATE      ");
                    sbQuery.Append("        , PA.PM_TYPE      ");
                    sbQuery.Append("        , PA.MTN_CODE     ");
                    sbQuery.Append("        , PA.PLN_DATE     ");
                    sbQuery.Append("        , PA.PM_GUBUN     ");
                    sbQuery.Append("        , PA.PART_SUPPLY  ");
                    sbQuery.Append("        , PA.PM_TIME      ");
                    sbQuery.Append("        , PA.PM_CONTENTS  ");
                    sbQuery.Append("        , PA.PM_COST      ");
                    sbQuery.Append("        , PA.PM_VND       ");
                    sbQuery.Append("        , PA.PM_CHARGE    ");
                    sbQuery.Append("        , PA.REG_DATE     ");
                    sbQuery.Append("        , PA.REG_EMP      ");
                    sbQuery.Append("        , PA.MDFY_DATE    ");
                    sbQuery.Append("        , PA.MDFY_EMP     ");
                    sbQuery.Append("  FROM THIS_PM_ACT PA      ");
                    //sbQuery.Append("    LEFT JOIN THIS_PM_ACT_PARTS SPP     ");
                    //sbQuery.Append("        ON SP.PLT_CODE = SPP.PLT_CODE     ");
                    //sbQuery.Append("        AND SP.MTN_CODE = SPP.MTN_CODE     ");
                    //sbQuery.Append("    LEFT JOIN LSE_STD_PART LSP     ");
                    //sbQuery.Append("        ON SPP.PLT_CODE = LSP.PLT_CODE     ");
                    //sbQuery.Append("        AND SPP.PART_CODE = LSP.PART_CODE     ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE PA.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@PM_ACT_CODE", "PA.PM_ACT_CODE = @PM_ACT_CODE "));
                        sbWhere.Append(UTIL.GetWhere(row, "@MTN_CODE", "PA.MTN_CODE = @MTN_CODE "));
                        sbWhere.Append(UTIL.GetWhere(row, "@MC_CODE", "PA.MC_CODE = @MC_CODE "));
                        sbWhere.Append(UTIL.GetWhere(row, "@PLN_DATE", "PA.PLN_DATE = @PLN_DATE "));
                        //sbWhere.Append(UTIL.GetWhere(row, "@PM_TYPE", "PA.PM_TYPE = @PM_TYPE "));
                        sbWhere.Append(" AND PA.PM_TYPE = 'A'");    //돌발
                        sbWhere.Append(" ORDER BY PA.PM_DATE DESC");

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

        public static DataTable THIS_PM_ACT_QUERY2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT PA.PLT_CODE      ");
                    sbQuery.Append("        , PA.PM_ACT_CODE  ");
                    sbQuery.Append("        , PA.MC_CODE      ");
                    sbQuery.Append("        , PA.PM_DATE      ");
                    sbQuery.Append("        , PA.PM_TYPE      ");
                    sbQuery.Append("        , PA.MTN_CODE     ");
                    sbQuery.Append("        , PA.PLN_DATE     ");
                    sbQuery.Append("        , PA.PM_GUBUN     ");
                    sbQuery.Append("        , PA.PART_SUPPLY  ");
                    sbQuery.Append("        , PA.PM_TIME      ");
                    sbQuery.Append("        , PA.PM_CONTENTS  ");
                    sbQuery.Append("        , PA.PM_COST      ");
                    sbQuery.Append("        , PA.PM_VND       ");
                    sbQuery.Append("        , PA.PM_CHARGE    ");
                    sbQuery.Append("        , PA.REG_DATE     ");
                    sbQuery.Append("        , PA.REG_EMP      ");
                    sbQuery.Append("        , PA.MDFY_DATE    ");
                    sbQuery.Append("        , PA.MDFY_EMP     ");
                    sbQuery.Append("  FROM THIS_PM_ACT PA      ");
                    //sbQuery.Append("    LEFT JOIN THIS_PM_ACT_PARTS SPP     ");
                    //sbQuery.Append("        ON SP.PLT_CODE = SPP.PLT_CODE     ");
                    //sbQuery.Append("        AND SP.MTN_CODE = SPP.MTN_CODE     ");
                    //sbQuery.Append("    LEFT JOIN LSE_STD_PART LSP     ");
                    //sbQuery.Append("        ON SPP.PLT_CODE = LSP.PLT_CODE     ");
                    //sbQuery.Append("        AND SPP.PART_CODE = LSP.PART_CODE     ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE PA.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@PM_ACT_CODE", "PA.PM_ACT_CODE = @PM_ACT_CODE "));
                        sbWhere.Append(UTIL.GetWhere(row, "@MTN_CODE", "PA.MTN_CODE = @MTN_CODE "));
                        sbWhere.Append(UTIL.GetWhere(row, "@MC_CODE", "PA.MC_CODE = @MC_CODE "));
                        sbWhere.Append(UTIL.GetWhere(row, "@PLN_DATE", "PA.PLN_DATE = @PLN_DATE "));
                        sbWhere.Append(UTIL.GetWhere(row, "@PM_TYPE", "PA.PM_TYPE = @PM_TYPE "));
                        sbWhere.Append(" ORDER BY PA.PM_DATE DESC");

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
