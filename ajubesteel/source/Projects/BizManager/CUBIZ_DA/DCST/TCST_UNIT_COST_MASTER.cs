using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace DCST
{
    public class TCST_UNIT_COST_MASTER
    {
        public static DataTable TCST_UNIT_COST_MASTER_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {

            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT   PLT_CODE ");
                    sbQuery.Append("        , UTC_CODE ");
                    sbQuery.Append("        , UTC_NAME ");
                    sbQuery.Append("        , SCOMMENT ");
                    sbQuery.Append("        , REG_DATE ");
                    sbQuery.Append("        , REG_EMP ");
                    sbQuery.Append("        , MDFY_DATE ");
                    sbQuery.Append("        , MDFY_EMP ");
                    sbQuery.Append("        , DEL_DATE ");
                    sbQuery.Append("        , DEL_EMP ");
                    sbQuery.Append("        , DEL_REASON ");
                    sbQuery.Append("        , DATA_FLAG ");
                    sbQuery.Append("   FROM TCST_UNIT_COST_MASTER ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("    AND UTC_CODE = @UTC_CODE ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "UTC_CODE")) isHasColumn = false;

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

        public static void TCST_UNIT_COST_MASTER_UPD(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TCST_UNIT_COST_MASTER ");
                    sbQuery.Append("    SET   UTC_NAME = @UTC_NAME ");
                    sbQuery.Append("        , SCOMMENT = @SCOMMENT ");
                    sbQuery.Append("        , MDFY_DATE = GETDATE() ");
                    sbQuery.Append("        , MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append("        , DATA_FLAG = 0 ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("    AND UTC_CODE = @UTC_CODE ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "UTC_CODE")) isHasColumn = false;

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

        public static void TCST_UNIT_COST_MASTER_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" INSERT INTO TCST_UNIT_COST_MASTER ");
                    sbQuery.Append(" ( ");
                    sbQuery.Append("        PLT_CODE ");
                    sbQuery.Append("      , UTC_CODE ");
                    sbQuery.Append("      , UTC_NAME ");
                    sbQuery.Append("      , SCOMMENT ");
                    sbQuery.Append("      , REG_DATE ");
                    sbQuery.Append("      , REG_EMP ");
                    sbQuery.Append("      , DATA_FLAG ");
                    sbQuery.Append(" ) ");
                    sbQuery.Append(" VALUES ");
                    sbQuery.Append(" ( ");
                    sbQuery.Append("        @PLT_CODE ");
                    sbQuery.Append("      , @UTC_CODE ");
                    sbQuery.Append("      , @UTC_NAME ");
                    sbQuery.Append("      , @SCOMMENT ");
                    sbQuery.Append("      , GETDATE() ");
                    sbQuery.Append(" ," + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append("     , 0");
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

        public static void TCST_UNIT_COST_MASTER_UDE(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" UPDATE TCST_UNIT_COST_MASTER ");
                    sbQuery.Append("    SET   DEL_DATE = GETDATE() ");
                    sbQuery.Append(" , DEL_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append("        , DEL_REASON = @DEL_REASON ");
                    sbQuery.Append(" , DATA_FLAG = 2");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("    AND UTC_CODE = @UTC_CODE ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "UTC_CODE")) isHasColumn = false;

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

    public class TCST_UNIT_COST_MASTER_QUERY
    {
        public static DataTable TCST_UNIT_COST_MASTER_QUERY1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT M.PLT_CODE ");
                    sbQuery.Append("       ,M.UTC_CODE ");
                    sbQuery.Append("       ,M.UTC_NAME ");
                    sbQuery.Append("       ,M.SCOMMENT ");
                    sbQuery.Append("       ,M.REG_DATE ");
                    sbQuery.Append("       ,M.REG_EMP ");
                    sbQuery.Append("       ,REG.EMP_NAME AS REG_EMP_NAME ");
                    sbQuery.Append("       ,M.MDFY_DATE ");
                    sbQuery.Append("       ,M.MDFY_EMP ");
                    sbQuery.Append("       ,MDFY.EMP_NAME AS MDFY_EMP_NAME ");
                    sbQuery.Append("       ,M.DATA_FLAG ");
                    sbQuery.Append("   FROM TCST_UNIT_COST_MASTER M ");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE REG ");
                    sbQuery.Append(" ON M.PLT_CODE = REG.PLT_CODE ");
                    sbQuery.Append(" AND M.REG_EMP = REG.EMP_CODE ");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE MDFY ");
                    sbQuery.Append(" ON M.PLT_CODE = MDFY.PLT_CODE ");
                    sbQuery.Append(" AND M.MDFY_EMP = MDFY.EMP_CODE ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder();

                        sbWhere.Append(" WHERE M.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@UTC_CODE", "M.UTC_CODE = @UTC_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@UTC_LIKE", "(M.UTC_CODE LIKE '%' + @UTC_LIKE + '%' OR M.UTC_NAME LIKE '%' + @UTC_LIKE + '%')"));
                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "M.DATA_FLAG = @DATA_FLAG"));

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

        public static DataTable TCST_UNIT_COST_MASTER_QUERY2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT PLT_CODE ");
                    sbQuery.Append("       ,UTC_CODE ");
                    sbQuery.Append("       ,UTC_NAME ");
                    sbQuery.Append("       ,SCOMMENT ");
                    sbQuery.Append("       ,REG_DATE ");
                    sbQuery.Append("       ,REG_EMP ");
                    sbQuery.Append("       ,MDFY_DATE ");
                    sbQuery.Append("       ,MDFY_EMP ");
                    sbQuery.Append("       ,DEL_DATE ");
                    sbQuery.Append("       ,DEL_EMP ");
                    sbQuery.Append("       ,DATA_FLAG ");
                    sbQuery.Append("   FROM TCST_UNIT_COST_MASTER ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder();

                        sbWhere.Append(" WHERE PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@UTC_CODE", "UTC_CODE = @UTC_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "DATA_FLAG = @DATA_FLAG"));

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

        public static DataTable TCST_UNIT_COST_MASTER_QUERY3(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT M.PLT_CODE ");
                    sbQuery.Append("       ,M.UTC_CODE ");
                    sbQuery.Append("       ,M.UTC_NAME ");
                    sbQuery.Append("       ,M.SCOMMENT ");
                    sbQuery.Append("       ,M.REG_DATE ");
                    sbQuery.Append("       ,M.REG_EMP ");
                    sbQuery.Append("       ,M.MDFY_DATE ");
                    sbQuery.Append("       ,M.MDFY_EMP ");
                    sbQuery.Append("       ,ISNULL(D.MON_MAN,0) AS NOW_MON_MAN ");
                    sbQuery.Append("       ,ISNULL(D.MON_SELF,0) AS NOW_MON_SELF ");
                    sbQuery.Append("       ,ISNULL(D.MON_OT,0) AS NOW_MON_OT ");
                    sbQuery.Append("       ,ISNULL(D.TUE_MAN,0) AS NOW_TUE_MAN ");
                    sbQuery.Append("       ,ISNULL(D.TUE_SELF,0) AS NOW_TUE_SELF ");
                    sbQuery.Append("       ,ISNULL(D.TUE_OT,0) AS NOW_TUE_OT ");
                    sbQuery.Append("       ,ISNULL(D.WED_MAN,0) AS NOW_WED_MAN ");
                    sbQuery.Append("       ,ISNULL(D.WED_SELF,0) AS NOW_WED_SELF ");
                    sbQuery.Append("       ,ISNULL(D.WED_OT,0) AS NOW_WED_OT ");
                    sbQuery.Append("       ,ISNULL(D.THR_MAN,0) AS NOW_THR_MAN ");
                    sbQuery.Append("       ,ISNULL(D.THR_SELF,0) AS NOW_THR_SELF ");
                    sbQuery.Append("       ,ISNULL(D.THR_OT,0) AS NOW_THR_OT ");
                    sbQuery.Append("       ,ISNULL(D.FRI_MAN,0) AS NOW_FRI_MAN ");
                    sbQuery.Append("       ,ISNULL(D.FRI_SELF,0) AS NOW_FRI_SELF ");
                    sbQuery.Append("       ,ISNULL(D.FRI_OT,0) AS NOW_FRI_OT ");
                    sbQuery.Append("       ,ISNULL(D.SAT_MAN,0) AS NOW_SAT_MAN ");
                    sbQuery.Append("       ,ISNULL(D.SAT_SELF,0) AS NOW_SAT_SELF ");
                    sbQuery.Append("       ,ISNULL(D.SAT_OT,0) AS NOW_SAT_OT ");
                    sbQuery.Append("       ,ISNULL(D.SUN_MAN,0) AS NOW_SUN_MAN ");
                    sbQuery.Append("       ,ISNULL(D.SUN_SELF,0) AS NOW_SUN_SELF ");
                    sbQuery.Append("       ,ISNULL(D.SUN_OT,0) AS NOW_SUN_OT ");
                    sbQuery.Append("       ,((ISNULL(D.MON_MAN,0) + ISNULL(D.MON_SELF,0) + ISNULL(D.MON_OT,0) +  ");
                    sbQuery.Append("        ISNULL(D.TUE_MAN,0) + ISNULL(D.TUE_SELF,0) + ISNULL(D.TUE_OT,0) +  ");
                    sbQuery.Append("    ISNULL(D.WED_MAN,0) + ISNULL(D.WED_SELF,0) + ISNULL(D.WED_OT,0) +  ");
                    sbQuery.Append("    ISNULL(D.THR_MAN,0) + ISNULL(D.THR_SELF,0) + ISNULL(D.THR_OT,0) + ");
                    sbQuery.Append("        ISNULL(D.FRI_MAN,0) + ISNULL(D.FRI_SELF,0) + ISNULL(D.FRI_OT,0) + ");
                    sbQuery.Append("        ISNULL(D.SAT_MAN,0) + ISNULL(D.SAT_SELF,0) + ISNULL(D.SAT_OT,0) + ");                    
                    sbQuery.Append("        ISNULL(D.SUN_MAN,0) + ISNULL(D.SUN_SELF,0) + ISNULL(D.SUN_OT,0))/21) AS AVR ");
                    sbQuery.Append("   FROM TCST_UNIT_COST_MASTER M ");
                    sbQuery.Append(" LEFT JOIN TCST_UNIT_COST_DETAIL D ON M.PLT_CODE = D.PLT_CODE AND M.UTC_CODE = D.UTC_CODE ");                    
                    sbQuery.Append(" AND @UTC_DATE BETWEEN D.UTC_START AND D.UTC_END ");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder();                        

                        sbWhere.Append(" WHERE M.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                                                sbWhere.Append(UTIL.GetWhere(row, "@UTC_CODE", "M.UTC_CODE = @UTC_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@UTC_NAME", "M.UTC_NAME = @UTC_NAME"));
                        sbWhere.Append(UTIL.GetWhere(row, "@UTC_LIKE", "(M.UTC_CODE LIKE '%' + @UTC_LIKE + '%' OR M.UTC_NAME LIKE '%' + @UTC_LIKE + '%')"));
                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "M.DATA_FLAG = @DATA_FLAG AND D.DATA_FLAG = @DATA_FLAG"));

                        
                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "UTC_DATE")) isHasColumn = false;

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

        public static DataTable TCST_UNIT_COST_MASTER_QUERY4(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT M.PLT_CODE ");
                    sbQuery.Append("       ,M.UTC_CODE ");
                    sbQuery.Append("       ,M.UTC_NAME ");
                    sbQuery.Append("       ,M.SCOMMENT ");
                    sbQuery.Append("       ,M.REG_DATE ");
                    sbQuery.Append("       ,M.REG_EMP ");
                    sbQuery.Append("       ,M.MDFY_DATE ");
                    sbQuery.Append("       ,M.MDFY_EMP ");
                    sbQuery.Append("       ,ISNULL(D.MON_MAN,0) AS NOW_MON_MAN ");
                    sbQuery.Append("       ,ISNULL(D.MON_SELF,0) AS NOW_MON_SELF ");
                    sbQuery.Append("       ,ISNULL(D.MON_OT,0) AS NOW_MON_OT ");
                    sbQuery.Append("       ,ISNULL(D.TUE_MAN,0) AS NOW_TUE_MAN ");
                    sbQuery.Append("       ,ISNULL(D.TUE_SELF,0) AS NOW_TUE_SELF ");
                    sbQuery.Append("       ,ISNULL(D.TUE_OT,0) AS NOW_TUE_OT ");
                    sbQuery.Append("       ,ISNULL(D.WED_MAN,0) AS NOW_WED_MAN ");
                    sbQuery.Append("       ,ISNULL(D.WED_SELF,0) AS NOW_WED_SELF ");
                    sbQuery.Append("       ,ISNULL(D.WED_OT,0) AS NOW_WED_OT ");
                    sbQuery.Append("       ,ISNULL(D.THR_MAN,0) AS NOW_THR_MAN ");
                    sbQuery.Append("       ,ISNULL(D.THR_SELF,0) AS NOW_THR_SELF ");
                    sbQuery.Append("       ,ISNULL(D.THR_OT,0) AS NOW_THR_OT ");
                    sbQuery.Append("       ,ISNULL(D.FRI_MAN,0) AS NOW_FRI_MAN ");
                    sbQuery.Append("       ,ISNULL(D.FRI_SELF,0) AS NOW_FRI_SELF ");
                    sbQuery.Append("       ,ISNULL(D.FRI_OT,0) AS NOW_FRI_OT ");
                    sbQuery.Append("       ,ISNULL(D.SAT_MAN,0) AS NOW_SAT_MAN ");
                    sbQuery.Append("       ,ISNULL(D.SAT_SELF,0) AS NOW_SAT_SELF ");
                    sbQuery.Append("       ,ISNULL(D.SAT_OT,0) AS NOW_SAT_OT ");
                    sbQuery.Append("       ,ISNULL(D.SUN_MAN,0) AS NOW_SUN_MAN ");
                    sbQuery.Append("       ,ISNULL(D.SUN_SELF,0) AS NOW_SUN_SELF ");
                    sbQuery.Append("       ,ISNULL(D.SUN_OT,0) AS NOW_SUN_OT ");
                    sbQuery.Append("       ,((ISNULL(D.MON_MAN,0) + ISNULL(D.MON_SELF,0) + ISNULL(D.MON_OT,0) +  ");
                    sbQuery.Append("        ISNULL(D.TUE_MAN,0) + ISNULL(D.TUE_SELF,0) + ISNULL(D.TUE_OT,0) +  ");
                    sbQuery.Append("    ISNULL(D.WED_MAN,0) + ISNULL(D.WED_SELF,0) + ISNULL(D.WED_OT,0) +  ");
                    sbQuery.Append("    ISNULL(D.THR_MAN,0) + ISNULL(D.THR_SELF,0) + ISNULL(D.THR_OT,0) + ");
                    sbQuery.Append("        ISNULL(D.FRI_MAN,0) + ISNULL(D.FRI_SELF,0) + ISNULL(D.FRI_OT,0) + ");
                    sbQuery.Append("        ISNULL(D.SAT_MAN,0) + ISNULL(D.SAT_SELF,0) + ISNULL(D.SAT_OT,0) + ");
                    sbQuery.Append("        ISNULL(D.SUN_MAN,0) + ISNULL(D.SUN_SELF,0) + ISNULL(D.SUN_OT,0))/21) AS AVR ");
                    sbQuery.Append("   FROM TCST_UNIT_COST_MASTER M ");
                    sbQuery.Append(" LEFT JOIN TCST_UNIT_COST_DETAIL D ON M.PLT_CODE = D.PLT_CODE AND M.UTC_CODE = D.UTC_CODE ");
                    sbQuery.Append(" AND convert(nvarchar,GETDATE(),112) BETWEEN D.UTC_START AND D.UTC_END ");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder();

                        sbWhere.Append(" WHERE M.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                        sbWhere.Append(UTIL.GetWhere(row, "@UTC_CODE", "M.UTC_CODE = @UTC_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@UTC_NAME", "M.UTC_NAME = @UTC_NAME"));
                        sbWhere.Append(UTIL.GetWhere(row, "@UTC_LIKE", "(M.UTC_CODE LIKE '%' + @UTC_LIKE + '%' OR M.UTC_NAME LIKE '%' + @UTC_LIKE + '%')"));
                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "M.DATA_FLAG = @DATA_FLAG AND D.DATA_FLAG = @DATA_FLAG"));

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
