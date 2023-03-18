using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace DCST
{
    public class TCST_UNIT_COST_DATE
    {
        public static DataTable TCST_UNIT_COST_DATE_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT   UID ");
                    sbQuery.Append("        , PLT_CODE ");
                    sbQuery.Append("        , UTC_CODE ");
                    sbQuery.Append("        , UTC_DATE ");
                    sbQuery.Append("        , MAN ");
                    sbQuery.Append("        , SELF ");
                    sbQuery.Append("        , OT ");
                    sbQuery.Append("        , SCOMMENT ");
                    sbQuery.Append("        , REG_DATE ");
                    sbQuery.Append("        , REG_EMP ");
                    sbQuery.Append("        , MDFY_DATE ");
                    sbQuery.Append("        , MDFY_EMP ");
                    sbQuery.Append("        , DEL_DATE ");
                    sbQuery.Append("        , DEL_EMP ");
                    sbQuery.Append("        , DATA_FLAG ");
                    sbQuery.Append("   FROM TCST_UNIT_COST_DATE ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("    AND UTC_CODE = @UTC_CODE  ");
                    sbQuery.Append("    AND UTC_DATE = @UTC_DATE  ");
                    sbQuery.Append("    AND DATA_FLAG = @DATA_FLAG ");

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

        public static void TCST_UNIT_COST_DATE_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" INSERT INTO TCST_UNIT_COST_DATE ");
                    sbQuery.Append(" ( ");
                    sbQuery.Append("        PLT_CODE ");
                    sbQuery.Append("      , UTC_CODE ");
                    sbQuery.Append("      , UTC_DATE ");
                    sbQuery.Append("      , MAN ");
                    sbQuery.Append("      , SELF ");
                    sbQuery.Append("      , OT ");
                    sbQuery.Append("      , SCOMMENT ");
                    sbQuery.Append("      , REG_DATE ");
                    sbQuery.Append("      , REG_EMP ");
                    sbQuery.Append("      , DATA_FLAG ");
                    sbQuery.Append(" ) ");
                    sbQuery.Append(" VALUES ");
                    sbQuery.Append(" ( ");
                    sbQuery.Append("        @PLT_CODE ");
                    sbQuery.Append("      , @UTC_CODE ");
                    sbQuery.Append("      , @UTC_DATE ");
                    sbQuery.Append("      , @MAN ");
                    sbQuery.Append("      , @SELF ");
                    sbQuery.Append("      , @OT ");
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

        public static void TCST_UNIT_COST_DATE_UPD(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TCST_UNIT_COST_DATE ");
                    sbQuery.Append("    SET   MAN = @MAN ");
                    sbQuery.Append("        , SELF = @SELF ");
                    sbQuery.Append("        , OT = @OT ");
                    sbQuery.Append("        , SCOMMENT = @SCOMMENT ");
                    sbQuery.Append("        , MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append("        , MDFY_DATE = GETDATE() ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("    AND UTC_CODE = @UTC_CODE  ");
                    sbQuery.Append("    AND UTC_DATE = @UTC_DATE  ");
                    sbQuery.Append("    AND DATA_FLAG = 0 ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "UTC_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "UTC_DATE")) isHasColumn = false;

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

        public static void TCST_UNIT_COST_DATE_UPD2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TCST_UNIT_COST_DATE ");
                    sbQuery.Append("    SET   MAN = @MAN ");
                    sbQuery.Append("        , SELF = @SELF ");
                    sbQuery.Append("        , OT = @OT ");
                    sbQuery.Append("        , SCOMMENT = @SCOMMENT ");
                    sbQuery.Append("        , MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append("        , MDFY_DATE = GETDATE() ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("    AND UID = @UID  ");
                    sbQuery.Append("    AND DATA_FLAG = 0 ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "UID")) isHasColumn = false;

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

        public static void TCST_UNIT_COST_DATE_UDE(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" UPDATE TCST_UNIT_COST_DATE ");
                    sbQuery.Append("    SET   DEL_DATE = GETDATE() ");
                    sbQuery.Append("        , DEL_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append("        , DATA_FLAG = 2 ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("    AND UID = @UID ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "UID")) isHasColumn = false;

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

    public class TCST_UNIT_COST_DATE_QUERY
    {
        //기준정보
        public static DataTable TCST_UNIT_COST_DATE_QUERY1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT C.PLT_CODE ");
                    sbQuery.Append("       ,C.UID ");
                    sbQuery.Append("       ,C.UTC_CODE ");
                    sbQuery.Append("       ,M.UTC_NAME ");
                    sbQuery.Append("       ,C.UTC_DATE ");
                    sbQuery.Append("       ,C.MAN ");
                    sbQuery.Append("       ,C.SELF ");
                    sbQuery.Append("       ,C.OT ");
                    sbQuery.Append("       ,C.SCOMMENT ");
                    sbQuery.Append("       ,C.REG_DATE ");
                    sbQuery.Append("       ,C.REG_EMP ");
                    sbQuery.Append("   ,REG.EMP_NAME AS REG_EMP_NAME ");
                    sbQuery.Append("       ,C.MDFY_DATE ");
                    sbQuery.Append("       ,C.MDFY_EMP ");
                    sbQuery.Append("   ,MDFY.EMP_NAME AS MDFY_EMP_NAME ");
                    sbQuery.Append("       ,C.DEL_DATE ");
                    sbQuery.Append("       ,C.DEL_EMP ");
                    sbQuery.Append("       ,C.DATA_FLAG ");
                    sbQuery.Append("   FROM TCST_UNIT_COST_DATE C ");
                    sbQuery.Append(" LEFT JOIN TCST_UNIT_COST_MASTER M ");
                    sbQuery.Append(" ON C.PLT_CODE = M.PLT_CODE ");
                    sbQuery.Append(" AND C.UTC_CODE= M.UTC_CODE ");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE REG ");
                    sbQuery.Append(" ON C.PLT_CODE = REG.PLT_CODE ");
                    sbQuery.Append(" AND C.REG_EMP = REG.EMP_CODE ");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE MDFY ");
                    sbQuery.Append(" ON C.PLT_CODE = MDFY.PLT_CODE ");
                    sbQuery.Append(" AND C.MDFY_EMP = MDFY.EMP_CODE ");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder();

                        sbWhere.Append(" WHERE C.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@UID", "C.UID = @UID"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_UTC_DATE,@E_UTC_DATE", "(C.UTC_DATE BETWEEN @S_UTC_DATE AND @E_UTC_DATE)"));
                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "C.DATA_FLAG = @DATA_FLAG"));

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

        public static DataTable TCST_UNIT_COST_DATE_QUERY2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT C.PLT_CODE ");
                    sbQuery.Append("       ,C.UID ");
                    sbQuery.Append("       ,C.UTC_CODE ");
                    sbQuery.Append("       ,M.UTC_NAME ");
                    sbQuery.Append("       ,C.UTC_DATE ");
                    sbQuery.Append("       ,C.MAN ");
                    sbQuery.Append("       ,C.SELF ");
                    sbQuery.Append("       ,C.OT ");
                    sbQuery.Append("       ,C.SCOMMENT ");
                    sbQuery.Append("       ,C.REG_DATE ");
                    sbQuery.Append("       ,C.REG_EMP ");
                    sbQuery.Append("   ,REG.EMP_NAME AS REG_EMP_NAME ");
                    sbQuery.Append("       ,C.MDFY_DATE ");
                    sbQuery.Append("       ,C.MDFY_EMP ");
                    sbQuery.Append("   ,MDFY.EMP_NAME AS MDFY_EMP_NAME ");
                    sbQuery.Append("       ,C.DEL_DATE ");
                    sbQuery.Append("       ,C.DEL_EMP ");
                    sbQuery.Append("       ,C.DATA_FLAG ");
                    sbQuery.Append("   FROM TCST_UNIT_COST_DATE C ");
                    sbQuery.Append(" LEFT JOIN TCST_UNIT_COST_MASTER M ");
                    sbQuery.Append(" ON C.PLT_CODE = M.PLT_CODE ");
                    sbQuery.Append(" AND C.UTC_CODE= M.UTC_CODE ");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE REG ");
                    sbQuery.Append(" ON C.PLT_CODE = REG.PLT_CODE ");
                    sbQuery.Append(" AND C.REG_EMP = REG.EMP_CODE ");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE MDFY ");
                    sbQuery.Append(" ON C.PLT_CODE = MDFY.PLT_CODE ");
                    sbQuery.Append(" AND C.MDFY_EMP = MDFY.EMP_CODE ");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder();

                        sbWhere.Append(" WHERE C.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@UID", "C.UID = @UID"));
                        sbWhere.Append(UTIL.GetWhere(row, "@UTC_DATE", "C.UTC_DATE = @UTC_DATE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "C.DATA_FLAG = @DATA_FLAG"));

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
