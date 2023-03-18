using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace DCST
{
    public class TCST_UNIT_COST_DETAIL
    {
        public static DataTable TCST_UNIT_COST_DETAIL_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT   PLT_CODE ");
                    sbQuery.Append("        , UCD_ID ");
                    sbQuery.Append("        , UTC_CODE ");
                    sbQuery.Append("        , UTC_START ");
                    sbQuery.Append("        , UTC_END ");
                    sbQuery.Append("        , MON_MAN ");
                    sbQuery.Append("        , MON_SELF ");
                    sbQuery.Append("        , MON_OT ");
                    sbQuery.Append("        , TUE_MAN ");
                    sbQuery.Append("        , TUE_SELF ");
                    sbQuery.Append("        , TUE_OT ");
                    sbQuery.Append("        , WED_MAN ");
                    sbQuery.Append("        , WED_SELF ");
                    sbQuery.Append("        , WED_OT ");
                    sbQuery.Append("        , THR_MAN ");
                    sbQuery.Append("        , THR_SELF ");
                    sbQuery.Append("        , THR_OT ");
                    sbQuery.Append("        , FRI_MAN ");
                    sbQuery.Append("        , FRI_SELF ");
                    sbQuery.Append("        , FRI_OT ");
                    sbQuery.Append("        , SAT_MAN ");
                    sbQuery.Append("        , SAT_SELF ");
                    sbQuery.Append("        , SAT_OT ");
                    sbQuery.Append("        , SUN_MAN ");
                    sbQuery.Append("        , SUN_SELF ");
                    sbQuery.Append("        , SUN_OT ");
                    sbQuery.Append("        , REG_DATE ");
                    sbQuery.Append("        , REG_EMP ");
                    sbQuery.Append("        , MDFY_DATE ");
                    sbQuery.Append("        , MDFY_EMP ");
                    sbQuery.Append("        , DEL_DATE ");
                    sbQuery.Append("        , DEL_EMP ");
                    sbQuery.Append("        , DATA_FLAG ");
                    sbQuery.Append("   FROM TCST_UNIT_COST_DETAIL ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("    AND UCD_ID = @UCD_ID ");


                    foreach (DataRow row in dtParam.Rows)
                    {


                        DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString(), row).Copy();

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

        public static void TCST_UNIT_COST_DETAIL_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" INSERT INTO TCST_UNIT_COST_DETAIL ");
                    sbQuery.Append(" ( ");
                    sbQuery.Append("        PLT_CODE ");
                    sbQuery.Append("      , UCD_ID ");
                    sbQuery.Append("      , UTC_CODE ");
                    sbQuery.Append("      , UTC_START ");
                    sbQuery.Append("      , UTC_END ");
                    sbQuery.Append("      , MON_MAN ");
                    sbQuery.Append("      , MON_SELF ");
                    sbQuery.Append("      , MON_OT ");
                    sbQuery.Append("      , TUE_MAN ");
                    sbQuery.Append("      , TUE_SELF ");
                    sbQuery.Append("      , TUE_OT ");
                    sbQuery.Append("      , WED_MAN ");
                    sbQuery.Append("      , WED_SELF ");
                    sbQuery.Append("      , WED_OT ");
                    sbQuery.Append("      , THR_MAN ");
                    sbQuery.Append("      , THR_SELF ");
                    sbQuery.Append("      , THR_OT ");
                    sbQuery.Append("      , FRI_MAN ");
                    sbQuery.Append("      , FRI_SELF ");
                    sbQuery.Append("      , FRI_OT ");
                    sbQuery.Append("      , SAT_MAN ");
                    sbQuery.Append("      , SAT_SELF ");
                    sbQuery.Append("      , SAT_OT ");
                    sbQuery.Append("      , SUN_MAN ");
                    sbQuery.Append("      , SUN_SELF ");
                    sbQuery.Append("      , SUN_OT ");
                    sbQuery.Append("      , REG_DATE ");
                    sbQuery.Append("      , REG_EMP ");
                    sbQuery.Append("      , DATA_FLAG ");
                    sbQuery.Append(" ) ");
                    sbQuery.Append(" VALUES ");
                    sbQuery.Append(" ( ");
                    sbQuery.Append("        @PLT_CODE ");
                    sbQuery.Append("      , @UCD_ID ");
                    sbQuery.Append("      , @UTC_CODE ");
                    sbQuery.Append("      , @UTC_START ");
                    sbQuery.Append("      , @UTC_END ");
                    sbQuery.Append("      , @MON_MAN ");
                    sbQuery.Append("      , @MON_SELF ");
                    sbQuery.Append("      , @MON_OT ");
                    sbQuery.Append("      , @TUE_MAN ");
                    sbQuery.Append("      , @TUE_SELF ");
                    sbQuery.Append("      , @TUE_OT ");
                    sbQuery.Append("      , @WED_MAN ");
                    sbQuery.Append("      , @WED_SELF ");
                    sbQuery.Append("      , @WED_OT ");
                    sbQuery.Append("      , @THR_MAN ");
                    sbQuery.Append("      , @THR_SELF ");
                    sbQuery.Append("      , @THR_OT ");
                    sbQuery.Append("      , @FRI_MAN ");
                    sbQuery.Append("      , @FRI_SELF ");
                    sbQuery.Append("      , @FRI_OT ");
                    sbQuery.Append("      , @SAT_MAN ");
                    sbQuery.Append("      , @SAT_SELF ");
                    sbQuery.Append("      , @SAT_OT ");
                    sbQuery.Append("      , @SUN_MAN ");
                    sbQuery.Append("      , @SUN_SELF ");
                    sbQuery.Append("      , @SUN_OT ");
                    sbQuery.Append("      , GETDATE() ");
                    sbQuery.Append(" ," + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append("      , 0 ");
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

        public static void TCST_UNIT_COST_DETAIL_UPD(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TCST_UNIT_COST_DETAIL ");
                    sbQuery.Append("    SET   UTC_START = @UTC_START ");
                    sbQuery.Append("        , UTC_END = @UTC_END ");
                    sbQuery.Append("        , MON_MAN = @MON_MAN ");
                    sbQuery.Append("        , MON_SELF = @MON_SELF ");
                    sbQuery.Append("        , MON_OT = @MON_OT ");
                    sbQuery.Append("        , TUE_MAN = @TUE_MAN ");
                    sbQuery.Append("        , TUE_SELF = @TUE_SELF ");
                    sbQuery.Append("        , TUE_OT = @TUE_OT ");
                    sbQuery.Append("        , WED_MAN = @WED_MAN ");
                    sbQuery.Append("        , WED_SELF = @WED_SELF ");
                    sbQuery.Append("        , WED_OT = @WED_OT ");
                    sbQuery.Append("        , THR_MAN = @THR_MAN ");
                    sbQuery.Append("        , THR_SELF = @THR_SELF ");
                    sbQuery.Append("        , THR_OT = @THR_OT ");
                    sbQuery.Append("        , FRI_MAN = @FRI_MAN ");
                    sbQuery.Append("        , FRI_SELF = @FRI_SELF ");
                    sbQuery.Append("        , FRI_OT = @FRI_OT ");
                    sbQuery.Append("        , SAT_MAN = @SAT_MAN ");
                    sbQuery.Append("        , SAT_SELF = @SAT_SELF ");
                    sbQuery.Append("        , SAT_OT = @SAT_OT ");
                    sbQuery.Append("        , SUN_MAN = @SUN_MAN ");
                    sbQuery.Append("        , SUN_SELF = @SUN_SELF ");
                    sbQuery.Append("        , SUN_OT = @SUN_OT ");
                    sbQuery.Append("        , MDFY_DATE = GETDATE() ");
                    sbQuery.Append("        , MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append("        , DATA_FLAG = 0 ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("    AND UCD_ID = @UCD_ID ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "UCD_ID")) isHasColumn = false;

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


        public static void TCST_UNIT_COST_DETAIL_UDE(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" UPDATE TCST_UNIT_COST_DETAIL ");
                    sbQuery.Append("    SET   DEL_DATE = GETDATE() ");
                    sbQuery.Append(" , DEL_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append("        , DATA_FLAG = 2 ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("    AND UCD_ID = @UCD_ID ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "UCD_ID")) isHasColumn = false;

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
    public class TCST_UNIT_COST_DETAIL_QUERY
    {
        public static DataTable TCST_UNIT_COST_DETAIL_QUERY1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT D.PLT_CODE ");
                    sbQuery.Append("       ,D.UCD_ID ");
                    sbQuery.Append("       ,D.UTC_CODE ");
                    sbQuery.Append("       ,D.UTC_START ");
                    sbQuery.Append("       ,D.UTC_END ");
                    sbQuery.Append("       ,D.MON_MAN ");
                    sbQuery.Append("       ,D.MON_SELF ");
                    sbQuery.Append("       ,D.MON_OT ");
                    sbQuery.Append("       ,D.TUE_MAN ");
                    sbQuery.Append("       ,D.TUE_SELF ");
                    sbQuery.Append("       ,D.TUE_OT ");
                    sbQuery.Append("       ,D.WED_MAN ");
                    sbQuery.Append("       ,D.WED_SELF ");
                    sbQuery.Append("       ,D.WED_OT ");
                    sbQuery.Append("       ,D.THR_MAN ");
                    sbQuery.Append("       ,D.THR_SELF ");
                    sbQuery.Append("       ,D.THR_OT ");
                    sbQuery.Append("       ,D.FRI_MAN ");
                    sbQuery.Append("       ,D.FRI_SELF ");
                    sbQuery.Append("       ,D.FRI_OT ");
                    sbQuery.Append("       ,D.SAT_MAN ");
                    sbQuery.Append("       ,D.SAT_SELF ");
                    sbQuery.Append("       ,D.SAT_OT ");
                    sbQuery.Append("       ,D.SUN_MAN ");
                    sbQuery.Append("       ,D.SUN_SELF ");
                    sbQuery.Append("       ,D.SUN_OT ");
                    sbQuery.Append("       ,D.REG_DATE ");
                    sbQuery.Append("       ,D.REG_EMP ");
                    sbQuery.Append("       ,REG.EMP_NAME AS REG_EMP_NAME ");
                    sbQuery.Append("       ,D.MDFY_DATE ");
                    sbQuery.Append("       ,D.MDFY_EMP ");
                    sbQuery.Append("       ,MDFY.EMP_NAME AS MDFY_EMP_NAME ");
                    sbQuery.Append("       ,D.DATA_FLAG ");
                    sbQuery.Append("   FROM TCST_UNIT_COST_DETAIL D ");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE REG ");
                    sbQuery.Append(" ON D.PLT_CODE = REG.PLT_CODE ");
                    sbQuery.Append(" AND D.REG_EMP = REG.EMP_CODE ");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE MDFY ");
                    sbQuery.Append(" ON D.PLT_CODE = MDFY.PLT_CODE ");
                    sbQuery.Append(" AND D.REG_EMP = MDFY.EMP_CODE ");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder();

                        sbWhere.Append(" WHERE D.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@UTC_CODE", "D.UTC_CODE = @UTC_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "D.DATA_FLAG = @DATA_FLAG"));

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

        public static DataTable TCST_UNIT_COST_DETAIL_QUERY2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT PLT_CODE ");
                    sbQuery.Append("       ,UCD_ID ");
                    sbQuery.Append("       ,UTC_CODE ");
                    sbQuery.Append("       ,UTC_START ");
                    sbQuery.Append("       ,UTC_END ");
                    sbQuery.Append("       ,MON_MAN ");
                    sbQuery.Append("       ,MON_SELF ");
                    sbQuery.Append("       ,MON_OT ");
                    sbQuery.Append("       ,TUE_MAN ");
                    sbQuery.Append("       ,TUE_SELF ");
                    sbQuery.Append("       ,TUE_OT ");
                    sbQuery.Append("       ,WED_MAN ");
                    sbQuery.Append("       ,WED_SELF ");
                    sbQuery.Append("       ,WED_OT ");
                    sbQuery.Append("       ,THR_MAN ");
                    sbQuery.Append("       ,THR_SELF ");
                    sbQuery.Append("       ,THR_OT ");
                    sbQuery.Append("       ,FRI_MAN ");
                    sbQuery.Append("       ,FRI_SELF ");
                    sbQuery.Append("       ,FRI_OT ");
                    sbQuery.Append("       ,SAT_MAN ");
                    sbQuery.Append("       ,SAT_SELF ");
                    sbQuery.Append("       ,SAT_OT ");
                    sbQuery.Append("       ,SUN_MAN ");
                    sbQuery.Append("       ,SUN_SELF ");
                    sbQuery.Append("       ,SUN_OT ");
                    sbQuery.Append("   FROM TCST_UNIT_COST_DETAIL ");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder();

                        sbWhere.Append(" WHERE PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@UTC_CODE", "UTC_CODE =@UTC_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@UTC_DATE", "@UTC_DATE BETWEEN UTC_START AND UTC_END"));
                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "DATA_FLAG = @DATA_FLAG"));
                        sbWhere.Append(UTIL.GetWhere(row, "@UCD_ID", "UCD_ID <> @UCD_ID"));

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
