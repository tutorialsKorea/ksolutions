using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace DSHP
{
    public class TSHP_ACTUAL
    {
        public static DataTable TSHP_ACTUAL_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT");
                    sbQuery.Append(" PLT_CODE");
                    sbQuery.Append(" ,ACTUAL_ID");
                    sbQuery.Append(" ,WORK_DATE");
                    sbQuery.Append(" ,WO_NO");
                    sbQuery.Append(" ,EMP_CODE");
                    sbQuery.Append(" ,MC_CODE");
                    sbQuery.Append(" ,MC_NM_CHECK");
                    sbQuery.Append(" ,PROC_STAT");
                    sbQuery.Append(" ,PANEL_STAT");
                    sbQuery.Append(" ,ACT_START_TIME");
                    sbQuery.Append(" ,CONVERT(NVARCHAR(8),ACT_START_TIME,112) AS S_DATE");
                    sbQuery.Append(" ,CASE WHEN DATEPART(HOUR,ACT_START_TIME) < 12 THEN 1 ELSE 2 END AS SN_FLAG");
                    sbQuery.Append(" ,CASE WHEN DATEPART(HOUR,ACT_START_TIME) = 12 THEN 12");
                    sbQuery.Append("       WHEN DATEPART(HOUR,ACT_START_TIME) < 12 THEN DATEPART(HOUR,ACT_START_TIME)");
                    sbQuery.Append("       ELSE DATEPART(HOUR,ACT_START_TIME) - 12 END AS SH_DATE");
                    sbQuery.Append(" ,DATEPART(MINUTE,ACT_START_TIME) AS SM_DATE");
                    sbQuery.Append(" ,CONVERT(NVARCHAR(8),GETDATE(),112) AS E_DATE");
                    sbQuery.Append(" ,CASE WHEN DATEPART(HOUR,GETDATE()) < 12 THEN 1 ELSE 2 END AS EN_FLAG");
                    sbQuery.Append(" ,CASE WHEN DATEPART(HOUR,GETDATE()) = 12 THEN 12");
                    sbQuery.Append("       WHEN DATEPART(HOUR,GETDATE()) < 12 THEN DATEPART(HOUR,GETDATE())");
                    sbQuery.Append("       ELSE DATEPART(HOUR,GETDATE()) - 12 END AS EH_DATE");
                    sbQuery.Append(" ,DATEPART(MINUTE,GETDATE()) AS EM_DATE");
                    sbQuery.Append(" FROM TSHP_ACTUAL");
                    sbQuery.Append(" WHERE WO_NO = @WO_NO");
                    sbQuery.Append(" AND ACT_END_TIME IS NULL");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "WO_NO")) isHasColumn = false;

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

        public static DataTable TSHP_ACTUAL_SER2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT   PLT_CODE");
                    sbQuery.Append(" , ACTUAL_ID");
                    sbQuery.Append(" , WORK_DATE");
                    sbQuery.Append(" , WO_NO");
                    sbQuery.Append(" , EMP_CODE");
                    sbQuery.Append(" , MC_CODE");
                    sbQuery.Append(" , MC_NM_CHECK");
                    sbQuery.Append(" , PROC_STAT");
                    sbQuery.Append(" , PANEL_STAT");
                    sbQuery.Append(" , ACT_START_TIME");
                    sbQuery.Append(" , ACT_END_TIME");
                    sbQuery.Append(" , SELF_TIME");
                    sbQuery.Append(" , SELF_START_TIME");
                    sbQuery.Append(" , SELF_END_TIME");
                    sbQuery.Append(" , MAN_TIME");
                    sbQuery.Append(" , MAN_START_TIME");
                    sbQuery.Append(" , MAN_END_TIME");
                    sbQuery.Append(" , OT_TIME");
                    sbQuery.Append(" , PAUSE_TIME");
                    sbQuery.Append(" , PAUSE_START_TIME");
                    sbQuery.Append(" , PAUSE_END_TIME");
                    sbQuery.Append(" , OK_QTY");
                    sbQuery.Append(" , NG_QTY");
                    sbQuery.Append(" , MULTI_START_CNT");
                    sbQuery.Append(" , ACT_TL_NO");
                    sbQuery.Append(" , INPUT_FLAG");
                    sbQuery.Append(" , STK_ID");
                    sbQuery.Append(" , REG_DATE");
                    sbQuery.Append(" , REG_EMP");
                    sbQuery.Append(" , MDFY_DATE");
                    sbQuery.Append(" , MDFY_EMP");
                    sbQuery.Append(" FROM TSHP_ACTUAL");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append(" AND ACTUAL_ID = @ACTUAL_ID");
                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "ACTUAL_ID")) isHasColumn = false;

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
        /// 작업지시의 특정작업자의 최종실적을 조회한다.
        /// </summary>
        /// <param name="dtParam"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataTable TSHP_ACTUAL_SER5(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT");
                    sbQuery.Append(" PLT_CODE");
                    sbQuery.Append(" , ACTUAL_ID");
                    sbQuery.Append(" , WORK_DATE");
                    sbQuery.Append(" , WO_NO");
                    sbQuery.Append(" , EMP_CODE");
                    sbQuery.Append(" , MC_CODE");
                    sbQuery.Append(" , MC_NM_CHECK");
                    sbQuery.Append(" , PROC_STAT");
                    sbQuery.Append(" , PANEL_STAT");
                    sbQuery.Append(" , ACT_START_TIME");
                    sbQuery.Append(" , ACT_END_TIME");
                    sbQuery.Append(" , SELF_TIME");
                    sbQuery.Append(" , SELF_START_TIME");
                    sbQuery.Append(" , SELF_END_TIME");
                    sbQuery.Append(" , MAN_TIME");
                    sbQuery.Append(" , MAN_START_TIME");
                    sbQuery.Append(" , MAN_END_TIME");
                    sbQuery.Append(" , OT_TIME");
                    sbQuery.Append(" , PAUSE_TIME");
                    sbQuery.Append(" , PAUSE_START_TIME");
                    sbQuery.Append(" , PAUSE_END_TIME");
                    sbQuery.Append(" , MC_TIME");
                    sbQuery.Append(" , MC_START_TIME");
                    sbQuery.Append(" , MC_END_TIME");
                    sbQuery.Append(" , MCP_TIME");
                    sbQuery.Append(" , MCP_START_TIME");
                    sbQuery.Append(" , MCP_END_TIME");
                    sbQuery.Append(" , INPUT_FLAG");
                    sbQuery.Append(" , REG_DATE");
                    sbQuery.Append(" , REG_EMP");
                    sbQuery.Append(" , MDFY_DATE");
                    sbQuery.Append(" , MDFY_EMP");
                    sbQuery.Append(" , OK_QTY");
                    sbQuery.Append(" , NG_QTY");
                    sbQuery.Append(" , ACT_TL_NO");
                    sbQuery.Append(" FROM TSHP_ACTUAL");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND WO_NO = @WO_NO");
                    sbQuery.Append(" AND EMP_CODE = @EMP_CODE");
                    sbQuery.Append(" AND ACT_START_TIME = (SELECT MAX(ACT_START_TIME) FROM TSHP_ACTUAL WHERE WO_NO = @WO_NO AND PROC_STAT IN (2,3,4) GROUP BY WO_NO)");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "WO_NO")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "EMP_CODE")) isHasColumn = false;

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

        public static DataTable TSHP_ACTUAL_SER6(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT");
                    sbQuery.Append(" PLT_CODE");
                    sbQuery.Append(" , ACTUAL_ID");
                    sbQuery.Append(" , WORK_DATE");
                    sbQuery.Append(" , WO_NO");
                    sbQuery.Append(" , EMP_CODE");
                    sbQuery.Append(" , MC_CODE");
                    sbQuery.Append(" , MC_NM_CHECK");
                    sbQuery.Append(" , PROC_STAT");
                    sbQuery.Append(" , PANEL_STAT");
                    sbQuery.Append(" , ACT_START_TIME");
                    sbQuery.Append(" , ACT_END_TIME");
                    sbQuery.Append(" , SELF_TIME");
                    sbQuery.Append(" , SELF_START_TIME");
                    sbQuery.Append(" , SELF_END_TIME");
                    sbQuery.Append(" , MAN_TIME");
                    sbQuery.Append(" , MAN_START_TIME");
                    sbQuery.Append(" , MAN_END_TIME");
                    sbQuery.Append(" , OT_TIME");
                    sbQuery.Append(" , PAUSE_TIME");
                    sbQuery.Append(" , PAUSE_START_TIME");
                    sbQuery.Append(" , PAUSE_END_TIME");
                    sbQuery.Append(" , MC_TIME");
                    sbQuery.Append(" , MC_START_TIME");
                    sbQuery.Append(" , MC_END_TIME");
                    sbQuery.Append(" , MCP_TIME");
                    sbQuery.Append(" , MCP_START_TIME");
                    sbQuery.Append(" , MCP_END_TIME");
                    sbQuery.Append(" , INPUT_FLAG");
                    sbQuery.Append(" , REG_DATE");
                    sbQuery.Append(" , REG_EMP");
                    sbQuery.Append(" , MDFY_DATE");
                    sbQuery.Append(" , MDFY_EMP");
                    sbQuery.Append(" , OK_QTY");
                    sbQuery.Append(" , NG_QTY");
                    sbQuery.Append(" , ACT_TL_NO");
                    sbQuery.Append(" FROM TSHP_ACTUAL");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND WO_NO = @WO_NO");
                    sbQuery.Append(" AND ACT_END_TIME IS NOT NULL");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "WO_NO")) isHasColumn = false;

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


        public static void TSHP_ACTUAL_UPD(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" UPDATE TSHP_ACTUAL");
                    sbQuery.Append(" SET   PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" , WORK_DATE = @WORK_DATE");
                    sbQuery.Append(" , WO_NO = @WO_NO");
                    sbQuery.Append(" , EMP_CODE = @EMP_CODE");
                    sbQuery.Append(" , MC_CODE = @MC_CODE");
                    sbQuery.Append(" , PROC_STAT = @PROC_STAT");
                    sbQuery.Append(" , ACT_START_TIME = @ACT_START_TIME");
                    sbQuery.Append(" , ACT_END_TIME = @ACT_END_TIME");
                    sbQuery.Append(" , SELF_TIME = @SELF_TIME");
                    sbQuery.Append(" , MAN_TIME = @MAN_TIME");
                    sbQuery.Append(" , OT_TIME = @OT_TIME");
                    sbQuery.Append(" , OK_QTY = @OK_QTY");
                    sbQuery.Append(" , NG_QTY = @NG_QTY");
                    sbQuery.Append(" , MDFY_DATE = GETDATE()");
                    sbQuery.Append(" , MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append(" AND ACTUAL_ID = @ACTUAL_ID");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "WO_NO")) isHasColumn = false;

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


        public static void TSHP_ACTUAL_UPD4(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {

            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TSHP_ACTUAL");
                    sbQuery.Append(" SET  NG_QTY = @NG_QTY");
                    sbQuery.Append(" , MDFY_DATE = GETDATE()");
                    sbQuery.Append(" , MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append("   AND ACTUAL_ID = @ACTUAL_ID");

                    foreach (DataRow dr in dtParam.Rows)
                    {
                        bizExecute.executeUpdateQuery(sbQuery.ToString(), dr);
                    }
                }

            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static void TSHP_ACTUAL_UPD5(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {

            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TSHP_ACTUAL");
                    sbQuery.Append(" SET  OK_QTY = @OK_QTY");
                    sbQuery.Append(" , MDFY_DATE = GETDATE()");
                    sbQuery.Append(" , MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append("   AND ACTUAL_ID = @ACTUAL_ID");

                    foreach (DataRow dr in dtParam.Rows)
                    {
                        bizExecute.executeUpdateQuery(sbQuery.ToString(), dr);
                    }
                }

            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static void TSHP_ACTUAL_UPD6(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {

            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" UPDATE TSHP_ACTUAL");
                    sbQuery.Append(" SET  STK_ID = @STK_ID");
                    sbQuery.Append(" , MDFY_DATE = GETDATE()");
                    sbQuery.Append(" , MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append("   AND ACTUAL_ID = @ACTUAL_ID");

                    foreach (DataRow dr in dtParam.Rows)
                    {
                        bizExecute.executeUpdateQuery(sbQuery.ToString(), dr);
                    }
                }

            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static void TSHP_ACTUAL_UPD7(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {

            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" UPDATE TSHP_ACTUAL");
                    sbQuery.Append(" SET  STK_ID = NULL");
                    sbQuery.Append(" , MDFY_DATE = GETDATE()");
                    sbQuery.Append(" , MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append("   AND ACTUAL_ID = @ACTUAL_ID");

                    foreach (DataRow dr in dtParam.Rows)
                    {
                        bizExecute.executeUpdateQuery(sbQuery.ToString(), dr);
                    }
                }

            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static void TSHP_ACTUAL_UPD8(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" UPDATE TSHP_ACTUAL SET ");
                    sbQuery.Append("   OK_QTY = @OK_QTY");
                    sbQuery.Append(" , NG_QTY = @NG_QTY");
                    sbQuery.Append(" , ACT_END_TIME = @ACT_END_TIME");
                    sbQuery.Append(" , ACT_TIME = @ACT_TIME");
                    sbQuery.Append(" , MAN_END_TIME = @MAN_END_TIME");
                    sbQuery.Append(" , MAN_TIME = @MAN_TIME");
                    sbQuery.Append(" , PROC_STAT = @PROC_STAT");
                    sbQuery.Append(" , PANEL_STAT = @PANEL_STAT");
                    sbQuery.Append(" , MDFY_DATE = GETDATE()");
                    sbQuery.Append(" , MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append(" AND ACTUAL_ID = @ACTUAL_ID");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "ACTUAL_ID")) isHasColumn = false;

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

        public static void TSHP_ACTUAL_UPD9(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" UPDATE TSHP_ACTUAL SET ");
                    sbQuery.Append("  NG_QTY = @NG_QTY");
                    sbQuery.Append(" , MDFY_DATE = GETDATE()");
                    sbQuery.Append(" , MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append(" AND ACTUAL_ID = @ACTUAL_ID");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "ACTUAL_ID")) isHasColumn = false;

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


        public static void TSHP_ACTUAL_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" INSERT INTO TSHP_ACTUAL");
                    sbQuery.Append(" (");
                    sbQuery.Append(" PLT_CODE");
                    sbQuery.Append(" , ACTUAL_ID");
                    sbQuery.Append(" , WORK_DATE");
                    sbQuery.Append(" , WO_NO");
                    sbQuery.Append(" , EMP_CODE");
                    sbQuery.Append(" , MC_CODE");
                    sbQuery.Append(" , MC_NM_CHECK");
                    sbQuery.Append(" , PROC_STAT");
                    sbQuery.Append(" , PANEL_STAT");
                    sbQuery.Append(" , ACT_START_TIME");
                    sbQuery.Append(" , MAN_START_TIME");
                    sbQuery.Append(" , PLN_QTY ");
                    //sbQuery.Append(" , ACT_END_TIME");
                    //sbQuery.Append(" , SELF_TIME");
                    //sbQuery.Append(" , MAN_TIME");
                    //sbQuery.Append(" , OT_TIME");
                    //sbQuery.Append(" , OK_QTY");
                    //sbQuery.Append(" , NG_QTY");
                    sbQuery.Append(" , MULTI_START_CNT");
                    sbQuery.Append(" , INPUT_FLAG");
                    sbQuery.Append(" , REG_DATE");
                    sbQuery.Append(" , REG_EMP");
                    sbQuery.Append(" )");
                    sbQuery.Append(" VALUES");
                    sbQuery.Append(" (");
                    sbQuery.Append(" @PLT_CODE");
                    sbQuery.Append(" , @ACTUAL_ID");
                    sbQuery.Append(" , @WORK_DATE");
                    sbQuery.Append(" , @WO_NO");
                    sbQuery.Append(" , @EMP_CODE");
                    sbQuery.Append(" , @MC_CODE");
                    sbQuery.Append(" , @MC_NM_CHECK");
                    sbQuery.Append(" , @PROC_STAT");
                    sbQuery.Append(" , @PANEL_STAT");
                    sbQuery.Append(" , @ACT_START_TIME");
                    sbQuery.Append(" , @MAN_START_TIME");
                    sbQuery.Append(" , @PLN_QTY ");
                    //sbQuery.Append(" , @ACT_END_TIME");
                    //sbQuery.Append(" , @SELF_TIME");
                    //sbQuery.Append(" , @MAN_TIME");
                    //sbQuery.Append(" , @OT_TIME");
                    //sbQuery.Append(" , @OK_QTY");
                    //sbQuery.Append(" , @NG_QTY");
                    sbQuery.Append(" , @MULTI_START_CNT");
                    sbQuery.Append(" , @INPUT_FLAG");
                    sbQuery.Append(" , GETDATE()");
                    sbQuery.Append(" , " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" )");

                    
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


        public static void TSHP_ACTUAL_DEL(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" DELETE FROM TSHP_ACTUAL");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND ACTUAL_ID = @ACTUAL_ID");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "ACTUAL_ID")) isHasColumn = false;

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

        public static void TSHP_ACTUAL_DEL2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" DELETE FROM TSHP_ACTUAL");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND WO_NO = @WO_NO");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "WO_NO")) isHasColumn = false;

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

    public class TSHP_ACTUAL_QUERY
    {

        //실적합계
        public static DataTable SHP_ACTUAL_SER2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();
                if (dtParam.Rows.Count > 0)
                {
                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbQuery = new StringBuilder();
                        sbQuery.Append(" SELECT ");
                        sbQuery.Append(" PLT_CODE, ");
                        sbQuery.Append(" SUM(MAN_TIME) AS MAN_TIME, ");
                        sbQuery.Append(" SUM(OT_TIME) AS OT_TIME, ");
                        sbQuery.Append(" SUM(SELF_TIME) AS SELF_TIME, ");
                        sbQuery.Append(" SUM(MAN_TIME + OT_TIME) AS MAN_SUM, ");
                        sbQuery.Append(" SUM(MAN_TIME + OT_TIME + SELF_TIME) AS TOT_SUM , ");
                        sbQuery.Append(" SUM(OK_QTY) AS OK_QTY, ");
                        sbQuery.Append(" SUM(NG_QTY) AS NG_QTY, ");
                        sbQuery.Append(" MIN(ACT_START_TIME) AS ACT_START_TIME,  ");
                        sbQuery.Append(" MAX(ACT_END_TIME) AS ACT_END_TIME  ");
                        sbQuery.Append(" FROM TSHP_ACTUAL ");

                        StringBuilder sbWhere = new StringBuilder(" WHERE PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@WO_NO", "WO_NO = @WO_NO"));

                        sbWhere.Append("GROUP BY PLT_CODE");

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




        //실적 기본쿼리
        public static DataTable TSHP_ACTUAL_QUERY1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT   PLT_CODE");
                    sbQuery.Append(" , ACTUAL_ID");
                    sbQuery.Append(" , WORK_DATE");
                    sbQuery.Append(" , WO_NO");
                    sbQuery.Append(" , EMP_CODE");
                    sbQuery.Append(" , MC_CODE");
                    sbQuery.Append(" , MC_NM_CHECK");
                    sbQuery.Append(" , PROC_STAT");
                    sbQuery.Append(" , PANEL_STAT");
                    sbQuery.Append(" , ACT_START_TIME");
                    sbQuery.Append(" , ACT_END_TIME");
                    sbQuery.Append(" , SELF_TIME");
                    sbQuery.Append(" , SELF_START_TIME");
                    sbQuery.Append(" , SELF_END_TIME");
                    sbQuery.Append(" , MAN_TIME");
                    sbQuery.Append(" , MAN_START_TIME");
                    sbQuery.Append(" , MAN_END_TIME");
                    sbQuery.Append(" , OT_TIME");
                    sbQuery.Append(" , PAUSE_TIME");
                    sbQuery.Append(" , PAUSE_START_TIME");
                    sbQuery.Append(" , PAUSE_END_TIME");
                    sbQuery.Append(" , INPUT_FLAG");
                    sbQuery.Append(" , REG_DATE");
                    sbQuery.Append(" , REG_EMP");
                    sbQuery.Append(" , MDFY_DATE");
                    sbQuery.Append(" , MDFY_EMP");
                    sbQuery.Append(" , OK_QTY");
                    sbQuery.Append(" , NG_QTY");
                    sbQuery.Append(" FROM TSHP_ACTUAL");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@WO_NO", "WO_NO = @WO_NO"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PROC_STAT", "PROC_STAT = @PROC_STAT"));

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

        public static DataTable TSHP_ACTUAL_QUERY2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT              ");
                    //sbQuery.Append(" ACT.ACT_TYPE        ");
                    sbQuery.Append(" ACT.ACTUAL_ID      ");
                    sbQuery.Append(" ,W.WO_TYPE          ");
                    sbQuery.Append(" ,W.WO_NO            ");

                    sbQuery.Append(" ,P.CVND_CODE    ");
                    sbQuery.Append(" ,V.VEN_NAME AS CVND_NAME  ");

                    sbQuery.Append(" ,P.PROD_CODE        ");

                    sbQuery.Append(" ,SP.PART_CODE       ");
                    sbQuery.Append(" ,SP.PART_NAME       ");
                    sbQuery.Append(" ,SP.DRAW_NO       ");
                    sbQuery.Append(" ,ACT.WORK_DATE      ");
                    sbQuery.Append(" ,PRC.PROC_CODE      ");
                    sbQuery.Append(" ,PRC.PROC_NAME      ");
                    sbQuery.Append(" ,ACT.EMP_CODE       ");
                    sbQuery.Append(" ,E.EMP_NAME         ");
                    sbQuery.Append(" ,ACT.MC_CODE        ");
                    sbQuery.Append(" ,M.MC_NAME          ");
                    sbQuery.Append(" ,ACT.ACT_START_TIME ");
                    sbQuery.Append(" ,ACT.ACT_END_TIME   ");
                    sbQuery.Append(" ,ACT.MAN_TIME       ");
                    sbQuery.Append(" ,ACT.OT_TIME        ");
                    sbQuery.Append(" ,ACT.SELF_TIME      ");
                    sbQuery.Append(" ,ACT.PAUSE_TIME     ");
                    sbQuery.Append(" ,ACT.SELF_TIME + ACT.MAN_TIME + ACT.OT_TIME AS WORK_TIME ");
                    sbQuery.Append(" ,ACT.OK_QTY + ACT.NG_QTY AS WORK_QTY ");
                    sbQuery.Append(" ,ACT.OK_QTY ");
                    sbQuery.Append(" ,ACT.NG_QTY ");
                    sbQuery.Append(" ,SP.MAT_COST ");
                    sbQuery.Append(" FROM TSHP_ACTUAL ACT         ");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE E       ");
                    sbQuery.Append(" ON ACT.PLT_CODE = E.PLT_CODE    ");
                    sbQuery.Append(" AND ACT.EMP_CODE = E.EMP_CODE   ");

                    sbQuery.Append(" LEFT JOIN LSE_MACHINE M         ");
                    sbQuery.Append(" ON ACT.PLT_CODE = E.PLT_CODE    ");
                    sbQuery.Append(" AND ACT.MC_CODE = M.MC_CODE     ");

                    sbQuery.Append(" LEFT JOIN TSHP_WORKORDER W      ");
                    sbQuery.Append(" ON ACT.PLT_CODE = W.PLT_CODE    ");
                    sbQuery.Append(" AND ACT.WO_NO = W.WO_NO         ");

                    sbQuery.Append(" LEFT JOIN TORD_PRODUCT P      ");
                    sbQuery.Append(" ON W.PLT_CODE = P.PLT_CODE    ");
                    sbQuery.Append(" AND W.PROD_CODE = P.PROD_CODE  ");

                    sbQuery.Append(" LEFT JOIN TSTD_VENDOR V      ");
                    sbQuery.Append(" ON P.PLT_CODE = V.PLT_CODE    ");
                    sbQuery.Append(" AND P.CVND_CODE = V.VEN_CODE  ");

                    sbQuery.Append(" LEFT JOIN LSE_STD_PART SP       ");
                    sbQuery.Append(" ON W.PLT_CODE = SP.PLT_CODE     ");
                    sbQuery.Append(" AND W.PART_CODE = SP.PART_CODE  ");
                    sbQuery.Append(" LEFT JOIN LSE_STD_PROC PRC      ");
                    sbQuery.Append(" ON W.PLT_CODE = PRC.PLT_CODE    ");
                    sbQuery.Append(" AND W.PROC_CODE = PRC.PROC_CODE ");
                    sbQuery.Append(" LEFT JOIN TSTD_ORG O            ");
                    sbQuery.Append(" ON E.PLT_CODE = O.PLT_CODE      ");
                    sbQuery.Append(" AND E.ORG_CODE = O.ORG_CODE     ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE ACT.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@S_WORK_DATE,@E_WORK_DATE", "ACT.WORK_DATE BETWEEN @S_WORK_DATE AND @E_WORK_DATE "));
                        sbWhere.Append(UTIL.GetWhere(row, "@EMP_CODE", "ACT.EMP_CODE = @EMP_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@ORG_CODE", "ACT.ORG_CODE = @ORG_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@ACTUAL_ID", "ACT.ACTUAL_ID = @ACTUAL_ID "));

                        sbWhere.Append(" AND ACT.PROC_STAT IN (3, 4)");

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

                /// <summary>
                /// 현재 진행 중인 실적
                /// </summary>
                /// <param name="dtParam">PLT_CODE,EMP_CODE</param>
                /// <param name="bizExecute"></param>
                /// <returns></returns>
        public static DataTable TSHP_ACTUAL_QUERY3(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("  SELECT A.ACTUAL_ID         ");
                    sbQuery.Append(" 		, A.WORK_DATE           ");
                    sbQuery.Append(" 		, A.WO_NO                 ");
                    sbQuery.Append(" 		, A.EMP_CODE             ");
                    sbQuery.Append(" 		, A.MC_CODE              ");
                    sbQuery.Append(" 		, W.WO_NO                ");
                    sbQuery.Append(" 		, W.PROD_CODE           ");
                    sbQuery.Append(" 		, W.PART_CODE           ");
                    sbQuery.Append(" 		, P.PART_NAME            ");
                    sbQuery.Append(" 		, P.MAT_SPEC1             ");
                    sbQuery.Append(" 		, P.MAT_SPEC              ");
                    sbQuery.Append(" 		, W.PROC_CODE           ");
                    sbQuery.Append(" 		, PR.PROC_NAME          ");
                    sbQuery.Append("  FROM TSHP_ACTUAL A      ");     
                    sbQuery.Append("  JOIN TSHP_WORKORDER W  ");
                    sbQuery.Append("  ON A.PLT_CODE = W.PLT_CODE  ");
                    sbQuery.Append("  AND A.WO_NO = W.WO_NO    ");
                    sbQuery.Append("  JOIN LSE_STD_PART P ");
                    sbQuery.Append("  ON W.PLT_CODE = P.PLT_CODE ");
                    sbQuery.Append("  AND W.PART_CODE = P.PART_CODE ");
                    sbQuery.Append("  JOIN LSE_STD_PROC PR ");
                    sbQuery.Append("  ON W.PLT_CODE = PR.PLT_CODE ");
                    sbQuery.Append("  AND W.PROC_CODE = PR.PROC_CODE ");
                    sbQuery.Append("  JOIN TORD_PRODUCT PROD ");
                    sbQuery.Append("    ON W.PLT_CODE = PROD.PLT_CODE ");
                    sbQuery.Append("  AND W.PROD_CODE = PROD.PROD_CODE ");
                    sbQuery.Append("  AND W.PART_CODE = PROD.PART_CODE ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder();

                        sbWhere.Append(" WHERE A.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                        sbWhere.Append("   AND W.DATA_FLAG = 0 ");
                        sbWhere.Append("   AND PROD.DATA_FLAG = 0 AND PROD.PROD_STATE IN ('WK', 'PG') ");
                        sbWhere.Append("   AND PROD.PARENT_PART IS NOT NULL ");
                        
                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_CODE", "W.PROD_CODE = @PROD_CODE"));
                        //sbWhere.Append(UTIL.GetWhere(row, "@PART_CODE", "W.PART_CODE = @PART_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_CODE", "PROD.PARENT_PART = @PART_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@WO_NO", "A.WO_NO = @WO_NO"));
                        sbWhere.Append(UTIL.GetWhere(row, "@EMP_CODE", "A.EMP_CODE = @EMP_CODE"));

                        sbWhere.Append(" AND  A.ACT_END_TIME IS  NULL");
                        //sbWhere.Append(" ORDER BY  A.ACT_START_TIME");

                        DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString() + sbWhere.ToString(), row).Copy();

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

        public static DataTable TSHP_ACTUAL_QUERY5(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED");
                    sbQuery.Append(" SELECT");
                    sbQuery.Append(" W.PLT_CODE");
                    sbQuery.Append(" ,SUM(ISNULL(A.OK_QTY,0)) AS OK_QTY");
                    sbQuery.Append(" ,CONVERT(VARCHAR(6), A.ACT_END_TIME, 112) AS ACT_END_TIME");
                    sbQuery.Append(" FROM TSHP_ACTUAL A");
                    sbQuery.Append(" LEFT JOIN TSHP_WORKORDER W");
                    sbQuery.Append(" ON W.PLT_CODE = A.PLT_CODE");
                    sbQuery.Append(" AND W.WO_NO = A.WO_NO");
                    sbQuery.Append(" LEFT JOIN TORD_PRODUCT P");
                    sbQuery.Append(" ON W.PLT_CODE = P.PLT_CODE");
                    sbQuery.Append(" AND W.PROD_CODE = P.PROD_CODE");
                    sbQuery.Append(" LEFT JOIN TMAT_PARTLIST TP");
                    sbQuery.Append(" ON W.PLT_CODE = TP.PLT_CODE");
                    sbQuery.Append(" AND W.PT_ID = TP.PT_ID");
                    sbQuery.Append(" LEFT JOIN LSE_STD_PART SP");
                    sbQuery.Append(" ON W.PLT_CODE = SP.PLT_CODE");
                    sbQuery.Append(" AND W.PART_CODE = SP.PART_CODE");
                    sbQuery.Append(" LEFT JOIN LSE_MACHINE M");
                    sbQuery.Append(" ON A.PLT_CODE = M.PLT_CODE");
                    sbQuery.Append(" AND A.MC_CODE = M.MC_CODE");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder();

                        sbWhere.Append(" WHERE A.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                        sbWhere.Append("   AND W.DATA_FLAG = 0 ");
                        sbWhere.Append("   AND W.WO_FLAG = '4' ");
                        sbWhere.Append("   AND W.PROC_CODE = 'P-04' ");
                        sbWhere.Append("   AND ISNULL(A.OK_QTY, 0) > 0 ");
                        sbWhere.Append("   AND A.ACT_END_TIME IS NOT NULL ");
                        sbWhere.Append("   AND ISNULL(A.MC_CODE, '') <> '' ");

                        sbWhere.Append(UTIL.GetWhere(row, "@YEAR", "CONVERT(VARCHAR(4), A.ACT_END_TIME, 112) = @YEAR"));
                        sbWhere.Append("   GROUP BY W.PLT_CODE, CONVERT(VARCHAR(6), A.ACT_END_TIME, 112) ");
                        sbWhere.Append("   ORDER BY CONVERT(VARCHAR(6), A.ACT_END_TIME, 112) ");

                        DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString() + sbWhere.ToString(), row).Copy();

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

        public static DataTable TSHP_ACTUAL_QUERY5_2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED");
                    sbQuery.Append(" SELECT");
                    sbQuery.Append(" W.PLT_CODE");
                    sbQuery.Append(" ,W.PROD_CODE");
                    sbQuery.Append(" ,P.PROD_NAME");
                    sbQuery.Append(" ,W.PART_CODE");
                    sbQuery.Append(" ,A.MC_CODE");
                    sbQuery.Append(" ,M.MC_NAME");
                    sbQuery.Append(" ,SP.PART_NAME");
                    sbQuery.Append(" ,TP.DRAW_NO");
                    sbQuery.Append(" ,TP.MATERIAL");
                    sbQuery.Append(" ,TP.SURFACE_TREAT");
                    sbQuery.Append(" ,TP.AFTER_TREAT");
                    sbQuery.Append(" ,SUM(ISNULL(A.OK_QTY,0)) AS OK_QTY");
                    sbQuery.Append(" ,CONVERT(VARCHAR(8), A.ACT_END_TIME, 112) AS ACT_END_TIME");
                    sbQuery.Append(" FROM TSHP_ACTUAL A");
                    sbQuery.Append(" LEFT JOIN TSHP_WORKORDER W");
                    sbQuery.Append(" ON W.PLT_CODE = A.PLT_CODE");
                    sbQuery.Append(" AND W.WO_NO = A.WO_NO");
                    sbQuery.Append(" LEFT JOIN TORD_PRODUCT P");
                    sbQuery.Append(" ON W.PLT_CODE = P.PLT_CODE");
                    sbQuery.Append(" AND W.PROD_CODE = P.PROD_CODE");
                    sbQuery.Append(" LEFT JOIN TMAT_PARTLIST TP");
                    sbQuery.Append(" ON W.PLT_CODE = TP.PLT_CODE");
                    sbQuery.Append(" AND W.PT_ID = TP.PT_ID");
                    sbQuery.Append(" LEFT JOIN LSE_STD_PART SP");
                    sbQuery.Append(" ON W.PLT_CODE = SP.PLT_CODE");
                    sbQuery.Append(" AND W.PART_CODE = SP.PART_CODE");
                    sbQuery.Append(" LEFT JOIN LSE_MACHINE M");
                    sbQuery.Append(" ON A.PLT_CODE = M.PLT_CODE");
                    sbQuery.Append(" AND A.MC_CODE = M.MC_CODE");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder();

                        sbWhere.Append(" WHERE A.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                        sbWhere.Append("   AND W.DATA_FLAG = 0 ");
                        sbWhere.Append("   AND W.WO_FLAG = '4' ");
                        sbWhere.Append("   AND W.PROC_CODE = 'P-04' ");
                        sbWhere.Append("   AND ISNULL(A.OK_QTY, 0) > 0 ");
                        sbWhere.Append("   AND A.ACT_END_TIME IS NOT NULL ");
                        sbWhere.Append("   AND ISNULL(A.MC_CODE, '') <> '' ");

                        sbWhere.Append(UTIL.GetWhere(row, "@YEAR", "CONVERT(VARCHAR(4), A.ACT_END_TIME, 112) = @YEAR"));

                        sbWhere.Append(" GROUP BY W.PLT_CODE");
                        sbWhere.Append(" ,W.PROD_CODE");
                        sbWhere.Append(" ,P.PROD_NAME");
                        sbWhere.Append(" ,W.PART_CODE");
                        sbWhere.Append(" ,SP.PART_NAME");
                        sbWhere.Append(" ,TP.DRAW_NO");
                        sbWhere.Append(" ,TP.MATERIAL");
                        sbWhere.Append(" ,TP.SURFACE_TREAT");
                        sbWhere.Append(" ,TP.AFTER_TREAT");
                        sbWhere.Append(" ,A.MC_CODE");
                        sbWhere.Append(" ,M.MC_NAME");
                        sbWhere.Append(" ,W.PLT_CODE, CONVERT(VARCHAR(8), A.ACT_END_TIME, 112)");
                        sbWhere.Append(" ,M.MC_SEQ");


                        sbWhere.Append("   ORDER BY CONVERT(VARCHAR(8), A.ACT_END_TIME, 112) ");

                        DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString() + sbWhere.ToString(), row).Copy();

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

        public static DataTable TSHP_ACTUAL_QUERY6(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED");
                    sbQuery.Append(" SELECT");
                    sbQuery.Append(" W.PLT_CODE");
                    sbQuery.Append(" ,SUM(ISNULL(W.ACT_QTY,0)) AS ACT_QTY");
                    sbQuery.Append(" ,CONVERT(VARCHAR(6), W.ACT_END_TIME, 112) AS ACT_END_TIME");
                    sbQuery.Append(" FROM TSHP_WORKORDER W");
                    sbQuery.Append(" LEFT JOIN TORD_PRODUCT P");
                    sbQuery.Append(" ON W.PLT_CODE = P.PLT_CODE");
                    sbQuery.Append(" AND W.PROD_CODE = P.PROD_CODE");
                    sbQuery.Append(" LEFT JOIN TMAT_PARTLIST TP");
                    sbQuery.Append(" ON W.PLT_CODE = TP.PLT_CODE");
                    sbQuery.Append(" AND W.PT_ID = TP.PT_ID");
                    sbQuery.Append(" LEFT JOIN LSE_STD_PART SP");
                    sbQuery.Append(" ON W.PLT_CODE = SP.PLT_CODE");
                    sbQuery.Append(" AND W.PART_CODE = SP.PART_CODE");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder();

                        sbWhere.Append(" WHERE W.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                        sbWhere.Append("   AND W.DATA_FLAG = 0 ");
                        sbWhere.Append("   AND W.WO_FLAG = '4' ");
                        sbWhere.Append("   AND W.PROC_CODE = 'P-06' ");
                        sbWhere.Append("   AND ISNULL(W.ACT_QTY, 0) > 0 ");
                        sbWhere.Append("   AND W.ACT_END_TIME IS NOT NULL ");

                        sbWhere.Append(UTIL.GetWhere(row, "@YEAR", "CONVERT(VARCHAR(4), W.ACT_END_TIME, 112) = @YEAR"));
                        sbWhere.Append("   GROUP BY W.PLT_CODE, CONVERT(VARCHAR(6), W.ACT_END_TIME, 112) ");
                        sbWhere.Append("   ORDER BY CONVERT(VARCHAR(6), W.ACT_END_TIME, 112) ");

                        DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString() + sbWhere.ToString(), row).Copy();

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

        public static DataTable TSHP_ACTUAL_QUERY6_2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED");
                    sbQuery.Append(" SELECT");
                    sbQuery.Append(" W.PLT_CODE");
                    sbQuery.Append(" ,W.PROD_CODE");
                    sbQuery.Append(" ,P.PROD_NAME");
                    sbQuery.Append(" ,W.PART_CODE");
                    sbQuery.Append(" ,SP.PART_NAME");
                    sbQuery.Append(" ,TP.DRAW_NO");
                    sbQuery.Append(" ,TP.MATERIAL");
                    sbQuery.Append(" ,TP.SURFACE_TREAT");
                    sbQuery.Append(" ,TP.AFTER_TREAT");
                    sbQuery.Append(" ,SUM(ISNULL(W.ACT_QTY,0)) AS ACT_QTY");
                    sbQuery.Append(" ,CONVERT(VARCHAR(8), W.ACT_END_TIME, 112) AS ACT_END_TIME");
                    sbQuery.Append(" FROM TSHP_WORKORDER W");
                    sbQuery.Append(" LEFT JOIN TORD_PRODUCT P");
                    sbQuery.Append(" ON W.PLT_CODE = P.PLT_CODE");
                    sbQuery.Append(" AND W.PROD_CODE = P.PROD_CODE");
                    sbQuery.Append(" LEFT JOIN TMAT_PARTLIST TP");
                    sbQuery.Append(" ON W.PLT_CODE = TP.PLT_CODE");
                    sbQuery.Append(" AND W.PT_ID = TP.PT_ID");
                    sbQuery.Append(" LEFT JOIN LSE_STD_PART SP");
                    sbQuery.Append(" ON W.PLT_CODE = SP.PLT_CODE");
                    sbQuery.Append(" AND W.PART_CODE = SP.PART_CODE");



                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder();

                        sbWhere.Append(" WHERE W.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                        sbWhere.Append("   AND W.DATA_FLAG = 0 ");
                        sbWhere.Append("   AND W.WO_FLAG = '4' ");
                        sbWhere.Append("   AND W.PROC_CODE = 'P-06' ");
                        sbWhere.Append("   AND ISNULL(W.ACT_QTY, 0) > 0 ");
                        sbWhere.Append("   AND W.ACT_END_TIME IS NOT NULL ");

                        sbWhere.Append(UTIL.GetWhere(row, "@YEAR", "CONVERT(VARCHAR(4), W.ACT_END_TIME, 112) = @YEAR"));

                        sbWhere.Append(" GROUP BY W.PLT_CODE");
                        sbWhere.Append(" ,W.PROD_CODE");
                        sbWhere.Append(" ,W.PART_CODE");
                        sbWhere.Append(" ,P.PROD_NAME");
                        sbWhere.Append(" ,SP.PART_NAME");
                        sbWhere.Append(" ,TP.DRAW_NO");
                        sbWhere.Append(" ,TP.MATERIAL");
                        sbWhere.Append(" ,TP.SURFACE_TREAT");
                        sbWhere.Append(" ,TP.AFTER_TREAT");
                        sbWhere.Append(" ,W.PLT_CODE, CONVERT(VARCHAR(8), W.ACT_END_TIME, 112)");



                        sbWhere.Append("   ORDER BY CONVERT(VARCHAR(8), W.ACT_END_TIME, 112) ");

                        DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString() + sbWhere.ToString(), row).Copy();

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

        public static DataTable TSHP_ACTUAL_QUERY7(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED");
                    sbQuery.Append(" SELECT");
                    sbQuery.Append(" ISNULL(A.PLT_CODE, B.PLT_CODE) AS PLT_CODE");
                    sbQuery.Append(" ,ISNULL(A.PROD_CODE, B.PROD_CODE) AS PROD_CODE");
                    sbQuery.Append(" ,ISNULL(A.PROD_NAME, B.PROD_NAME) AS PROD_NAME");
                    sbQuery.Append(" ,ISNULL(A.PART_CODE, B.PART_CODE) AS PART_CODE");
                    sbQuery.Append(" ,ISNULL(A.PART_NAME, B.PART_NAME) AS PART_NAME");
                    sbQuery.Append(" ,ISNULL(A.DRAW_NO, B.DRAW_NO) AS DRAW_NO");
                    sbQuery.Append(" ,ISNULL(A.MATERIAL, B.MATERIAL) AS MATERIAL");
                    sbQuery.Append(" ,ISNULL(A.SURFACE_TREAT, B.SURFACE_TREAT) AS SURFACE_TREAT");
                    sbQuery.Append(" ,ISNULL(A.AFTER_TREAT, B.AFTER_TREAT) AS AFTER_TREAT");
                    //sbQuery.Append(" ,A.ACT_QTY AS MCT_ACT_QTY");
                    sbQuery.Append(" ,CASE WHEN A.PROC_CODE = 'P-04' THEN A.ACT_QTY ELSE 0 END AS MCT_ACT_QTY");
                    sbQuery.Append(" ,CASE WHEN A.PROC_CODE = 'P14' THEN A.ACT_QTY ELSE 0 END AS OUT_ACT_QTY");
                    sbQuery.Append(" ,A.ACT_END_TIME AS MCT_ACT_END_TIME");
                    sbQuery.Append(" ,LEFT(A.ACT_END_TIME, 6) AS MCT_ACT_END_MONTH");
                    sbQuery.Append(" ,B.ACT_QTY AS INS_ACT_QTY");
                    sbQuery.Append(" ,B.ACT_END_TIME AS INS_ACT_END_TIME");
                    sbQuery.Append(" ,LEFT(B.ACT_END_TIME, 6) AS INS_ACT_END_MONTH");
                    sbQuery.Append(" ,A.PROC_CODE");
                    sbQuery.Append(" ,SP.PROC_NAME");
                    sbQuery.Append(" FROM");
                    sbQuery.Append(" (");
                    sbQuery.Append(" SELECT");
                    sbQuery.Append(" W.PLT_CODE");
                    sbQuery.Append(" ,W.PROD_CODE");
                    sbQuery.Append(" ,P.PROD_NAME");
                    sbQuery.Append(" ,W.PART_CODE");
                    sbQuery.Append(" ,SP.PART_NAME");
                    sbQuery.Append(" ,TP.DRAW_NO");
                    sbQuery.Append(" ,TP.MATERIAL");
                    sbQuery.Append(" ,TP.SURFACE_TREAT");
                    sbQuery.Append(" ,TP.AFTER_TREAT");
                    sbQuery.Append(" ,SUM(ISNULL(W.ACT_QTY,0)) AS ACT_QTY");
                    sbQuery.Append(" ,CONVERT(VARCHAR(8), W.ACT_END_TIME, 112) AS ACT_END_TIME");
                    sbQuery.Append(" ,W.RE_WO_NO");
                    sbQuery.Append(" ,W.PROC_CODE");
                    sbQuery.Append(" FROM TSHP_WORKORDER W");
                    sbQuery.Append(" LEFT JOIN TORD_PRODUCT P");
                    sbQuery.Append(" ON W.PLT_CODE = P.PLT_CODE");
                    sbQuery.Append(" AND W.PROD_CODE = P.PROD_CODE");
                    sbQuery.Append(" LEFT JOIN TMAT_PARTLIST TP");
                    sbQuery.Append(" ON W.PLT_CODE = TP.PLT_CODE");
                    sbQuery.Append(" AND W.PT_ID = TP.PT_ID");
                    sbQuery.Append(" LEFT JOIN LSE_STD_PART SP");
                    sbQuery.Append(" ON W.PLT_CODE = SP.PLT_CODE");
                    sbQuery.Append(" AND W.PART_CODE = SP.PART_CODE");
                    sbQuery.Append(" WHERE W.DATA_FLAG = 0");
                    sbQuery.Append(" AND W.WO_FLAG = '4'");
                    sbQuery.Append(" AND W.PROC_CODE IN ('P-04', 'P14')");
                    sbQuery.Append(" AND ISNULL(W.ACT_QTY, 0) > 0");
                    sbQuery.Append(" AND W.ACT_END_TIME IS NOT NULL");
                    sbQuery.Append(" AND CONVERT(VARCHAR(4), W.ACT_END_TIME, 112) = @YEAR");
                    sbQuery.Append(" GROUP BY W.PLT_CODE");
                    sbQuery.Append(" ,W.PROD_CODE");
                    sbQuery.Append(" ,W.PART_CODE");
                    sbQuery.Append(" ,P.PROD_NAME");
                    sbQuery.Append(" ,SP.PART_NAME");
                    sbQuery.Append(" ,TP.DRAW_NO");
                    sbQuery.Append(" ,TP.MATERIAL");
                    sbQuery.Append(" ,TP.SURFACE_TREAT");
                    sbQuery.Append(" ,TP.AFTER_TREAT");
                    sbQuery.Append(" ,W.PLT_CODE, CONVERT(VARCHAR(8), W.ACT_END_TIME, 112)");
                    sbQuery.Append(" ,W.RE_WO_NO");
                    sbQuery.Append(" ,W.PROC_CODE");
                    sbQuery.Append(" )A");
                    sbQuery.Append(" FULL JOIN");
                    sbQuery.Append(" (");
                    sbQuery.Append(" SELECT");
                    sbQuery.Append(" W.PLT_CODE");
                    sbQuery.Append(" ,W.PROD_CODE");
                    sbQuery.Append(" ,P.PROD_NAME");
                    sbQuery.Append(" ,W.PART_CODE");
                    sbQuery.Append(" ,SP.PART_NAME");
                    sbQuery.Append(" ,TP.DRAW_NO");
                    sbQuery.Append(" ,TP.MATERIAL");
                    sbQuery.Append(" ,TP.SURFACE_TREAT");
                    sbQuery.Append(" ,TP.AFTER_TREAT");
                    sbQuery.Append(" ,SUM(ISNULL(W.ACT_QTY,0)) AS ACT_QTY");
                    sbQuery.Append(" ,CONVERT(VARCHAR(8), W.ACT_END_TIME, 112) AS ACT_END_TIME");
                    sbQuery.Append(" ,W.RE_WO_NO");
                    sbQuery.Append(" FROM TSHP_WORKORDER W");
                    sbQuery.Append(" LEFT JOIN TORD_PRODUCT P");
                    sbQuery.Append(" ON W.PLT_CODE = P.PLT_CODE");
                    sbQuery.Append(" AND W.PROD_CODE = P.PROD_CODE");
                    sbQuery.Append(" LEFT JOIN TMAT_PARTLIST TP");
                    sbQuery.Append(" ON W.PLT_CODE = TP.PLT_CODE");
                    sbQuery.Append(" AND W.PT_ID = TP.PT_ID");
                    sbQuery.Append(" LEFT JOIN LSE_STD_PART SP");
                    sbQuery.Append(" ON W.PLT_CODE = SP.PLT_CODE");
                    sbQuery.Append(" AND W.PART_CODE = SP.PART_CODE");
                    sbQuery.Append(" WHERE W.DATA_FLAG = 0");
                    sbQuery.Append(" AND W.WO_FLAG = '4'");
                    sbQuery.Append(" AND W.PROC_CODE = 'P-06'");
                    sbQuery.Append(" AND ISNULL(W.ACT_QTY, 0) > 0");
                    sbQuery.Append(" AND W.ACT_END_TIME IS NOT NULL");
                    sbQuery.Append(" AND CONVERT(VARCHAR(4), W.ACT_END_TIME, 112) = @YEAR");
                    sbQuery.Append(" GROUP BY W.PLT_CODE");
                    sbQuery.Append(" ,W.PROD_CODE");
                    sbQuery.Append(" ,W.PART_CODE");
                    sbQuery.Append(" ,P.PROD_NAME");
                    sbQuery.Append(" ,SP.PART_NAME");
                    sbQuery.Append(" ,TP.DRAW_NO");
                    sbQuery.Append(" ,TP.MATERIAL");
                    sbQuery.Append(" ,TP.SURFACE_TREAT");
                    sbQuery.Append(" ,TP.AFTER_TREAT");
                    sbQuery.Append(" ,CONVERT(VARCHAR(8), W.ACT_END_TIME, 112)");
                    sbQuery.Append(" ,W.RE_WO_NO");
                    sbQuery.Append(" )B");
                    sbQuery.Append(" ON A.PLT_CODE = B.PLT_CODE");
                    sbQuery.Append(" AND A.PROD_CODE = B.PROD_CODE");
                    sbQuery.Append(" AND A.PART_CODE = B.PART_CODE");
                    sbQuery.Append(" AND ISNULL(A.RE_WO_NO, '0') = ISNULL(B.RE_WO_NO, '0')");

                    sbQuery.Append(" LEFT JOIN LSE_STD_PROC SP");
                    sbQuery.Append(" ON A.PLT_CODE = SP.PLT_CODE");
                    sbQuery.Append(" AND A.PROC_CODE = SP.PROC_CODE");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder();

                        DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString() + sbWhere.ToString(), row).Copy();

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




        public static DataTable TSHP_ACTUAL_QUERY9(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {

                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT ACT.PLT_CODE");
                    sbQuery.Append(" ,ACT.ACTUAL_ID");
                    sbQuery.Append(" ,ACT.WORK_DATE");
                    sbQuery.Append(" ,ACT.WO_NO");
                    sbQuery.Append(" ,ACT.EMP_CODE");
                    sbQuery.Append(" ,W.PROD_CODE");
                    sbQuery.Append(" ,PR.PROD_NAME");
                    sbQuery.Append(" ,PR.CVND_CODE");
                    sbQuery.Append(" ,W.PART_CODE");
                    sbQuery.Append(" ,SP.PART_NAME");
                    sbQuery.Append(" ,E.EMP_NAME");
                    sbQuery.Append(" ,ACT.MC_CODE");
                    sbQuery.Append(" ,M.MC_NAME");
                    sbQuery.Append(" ,ACT.MC_NM_CHECK");
                    sbQuery.Append(" ,ACT.PROC_STAT");
                    sbQuery.Append(" ,ACT.PANEL_STAT");
                    sbQuery.Append(" ,ACT.ACT_START_TIME");
                    sbQuery.Append(" ,ACT.ACT_END_TIME");
                    sbQuery.Append(" ,ACT.SELF_TIME");
                    sbQuery.Append(" ,ACT.SELF_START_TIME");
                    sbQuery.Append(" ,ACT.SELF_END_TIME");
                    sbQuery.Append(" ,ACT.MAN_TIME");
                    sbQuery.Append(" ,ACT.MAN_START_TIME");
                    sbQuery.Append(" ,ACT.MAN_END_TIME");
                    sbQuery.Append(" ,ACT.OT_TIME");
                    sbQuery.Append(" ,ACT.PRE_START_TIME");
                    sbQuery.Append(" ,ACT.PRE_END_TIME");
                    sbQuery.Append(" ,ACT.PRE_TIME");
                    sbQuery.Append(" ,ACT.PAUSE_TIME");
                    sbQuery.Append(" ,ACT.PAUSE_START_TIME");
                    sbQuery.Append(" ,ACT.PAUSE_END_TIME");
                    sbQuery.Append(" ,(ISNULL(ACT.SELF_TIME, 0) + ISNULL(ACT.MAN_TIME, 0) + ISNULL(ACT.OT_TIME, 0) + ISNULL(ACT.PRE_TIME, 0)) AS WORK_TIME");
                    sbQuery.Append(" ,ACT.INPUT_FLAG");
                    sbQuery.Append(" ,W.PART_QTY AS PLN_QTY ");
                    sbQuery.Append(" ,(ISNULL(ACT.OK_QTY, 0)) AS WORK_QTY");
                    sbQuery.Append(" ,ACT.OK_QTY");
                    sbQuery.Append(" ,ACT.NG_QTY");
                    sbQuery.Append(" ,ACT.PAUSE_REASON");
                    sbQuery.Append(" ,ACT.REG_EMP");
                    sbQuery.Append(" ,REG.EMP_NAME AS REG_EMP_NAME");
                    sbQuery.Append(" ,ACT.REG_DATE");
                    sbQuery.Append(" ,ACT.MDFY_EMP");
                    sbQuery.Append(" ,MDFY.EMP_NAME AS MDFY_EMP_NAME");
                    sbQuery.Append(" ,ACT.MDFY_DATE");
                    sbQuery.Append(" ,ID.IDLE_CODE");

                    sbQuery.Append(" FROM TSHP_ACTUAL ACT");
                    sbQuery.Append(" LEFT JOIN TSHP_WORKORDER W");
                    sbQuery.Append(" ON ACT.PLT_CODE = W.PLT_CODE");
                    sbQuery.Append(" AND ACT.WO_NO = W.WO_NO");
                   
                    sbQuery.Append(" LEFT JOIN TORD_PRODUCT PR");
                    sbQuery.Append(" ON W.PLT_CODE = PR.PLT_CODE");
                    sbQuery.Append(" AND W.PROD_CODE = PR.PROD_CODE");

                    sbQuery.Append(" LEFT JOIN LSE_STD_PART SP");
                    sbQuery.Append(" ON W.PLT_CODE = SP.PLT_CODE");
                    sbQuery.Append(" AND W.PART_CODE = SP.PART_CODE");

                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE E");
                    sbQuery.Append(" ON ACT.PLT_CODE = E.PLT_CODE");
                    sbQuery.Append(" AND ACT.EMP_CODE = E.EMP_CODE");

                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE REG");
                    sbQuery.Append(" ON ACT.PLT_CODE = REG.PLT_CODE");
                    sbQuery.Append(" AND ACT.REG_EMP = REG.EMP_CODE");

                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE MDFY");
                    sbQuery.Append(" ON ACT.PLT_CODE = MDFY.PLT_CODE");
                    sbQuery.Append(" AND ACT.MDFY_EMP = MDFY.EMP_CODE");

                    sbQuery.Append(" LEFT JOIN LSE_MACHINE M");
                    sbQuery.Append(" ON ACT.PLT_CODE = E.PLT_CODE");
                    sbQuery.Append(" AND ACT.MC_CODE = M.MC_CODE");

                    sbQuery.Append(" LEFT JOIN TSHP_IDLETIME ID ");
                    sbQuery.Append(" ON ACT.PLT_CODE = ID.PLT_CODE");
                    sbQuery.Append(" AND ACT.ACTUAL_ID = ID.ACTUAL_ID");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE ACT.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@EMP_CODE", "ACT.EMP_CODE = @EMP_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_WORK_DATE,@E_WORK_DATE", " ACT.WORK_DATE BETWEEN @S_WORK_DATE AND @E_WORK_DATE "));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_PLAN_DATE,@E_PLAN_DATE", " ACT.WORK_DATE BETWEEN @S_PLAN_DATE AND @E_PLAN_DATE "));

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




        public static DataTable TSHP_ACTUAL_QUERY10(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {

                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("    SELECT M.MC_CODE ");
                    sbQuery.Append("     , M.MC_NAME    ");
                    sbQuery.Append("  , MS.DEPT_INFO    ");
                    sbQuery.Append(" 	, W.CVND_CODE    ");
                    sbQuery.Append(" 	, W.CVND_NAME    ");
                    sbQuery.Append("  , W.ITEM_CODE    ");
                    sbQuery.Append(" 	, W.PROD_CODE    ");
                    sbQuery.Append(" 	, W.PART_CODE    ");
                    sbQuery.Append(" 	, W.PART_NAME    ");

                    sbQuery.Append(" 	, W.DRAW_NO    ");
                    sbQuery.Append(" 	, ISNULL((SELECT SUM(ISNULL(OK_QTY, 0)) FROM TSHP_ACTUAL A WHERE W.PLT_CODE = A.PLT_CODE AND W.WO_NO = A.WO_NO ), 0)  AS ACT_QTY    ");
                    sbQuery.Append(" 	, W.PART_QTY    ");
                    sbQuery.Append(" 	, CASE S.GUBUN WHEN 'A' THEN (SELECT CD_NAME FROM TSTD_CODES WHERE CAT_CODE = 'S032' AND CD_CODE = W.WO_FLAG )    ");
                    sbQuery.Append(" 		WHEN 'I' THEN S.W_STATE END W_STATE    ");
                    sbQuery.Append(" 	, S.W_DESC    ");
                    sbQuery.Append(" 	, W.PLN_END_TIME    ");
                    sbQuery.Append(" 	, W.PLN_START_TIME    ");
                    sbQuery.Append(" 	, S.WO_NO    ");
                    sbQuery.Append(" 	, S.ACTUAL_ID     ");
                    sbQuery.Append(" FROM LSE_MACHINE M LEFT OUTER JOIN     ");
                    sbQuery.Append(" 	(    ");
                    sbQuery.Append(" 	SELECT A.PLT_CODE    ");
                    sbQuery.Append(" 	  , A.MC_CODE    ");
                    sbQuery.Append(" 	  , A.WO_NO    ");
                    sbQuery.Append(" 	  , A.ACTUAL_ID    ");
                    sbQuery.Append(" 	  , NULL AS IDLE_CODE    ");
                    sbQuery.Append(" 	  , 'A' AS GUBUN    ");
                    sbQuery.Append(" 	  , '' AS W_STATE    ");
                    sbQuery.Append(" 	  , '' AS W_DESC    ");
                    sbQuery.Append(" 	 FROM TSHP_ACTUAL A     ");
                    sbQuery.Append(" 	 WHERE A.PLT_CODE = '100'    ");
                    sbQuery.Append(" 	   AND A.ACT_END_TIME IS  NULL     ");
                    sbQuery.Append("       ");
                    sbQuery.Append(" 	  UNION ALL     ");
                    sbQuery.Append(" 	  SELECT I.PLT_CODE    ");
                    sbQuery.Append(" 	   , I.MC_CODE    ");
                    sbQuery.Append(" 	   , I.WO_NO    ");
                    sbQuery.Append(" 	   , I.ACTUAL_ID     ");
                    sbQuery.Append(" 	   , I.IDLE_CODE    ");
                    sbQuery.Append(" 	   , 'I' AS GUBUN    ");
                    sbQuery.Append(" 	   , CASE ISNULL(I.ACTUAL_ID, '') WHEN '' THEN '비가동' ELSE '중단' END W_STATE    ");
                    sbQuery.Append(" 	   , CASE ISNULL(I.ACTUAL_ID, '') WHEN '' THEN (SELECT CD_NAME FROM TSTD_CODES WHERE CAT_CODE = 'C010' AND CD_CODE = I.IDLE_CODE )     ");
                    sbQuery.Append(" 			ELSE (SELECT CD_NAME FROM TSTD_CODES WHERE CAT_CODE = 'C009' AND CD_CODE = I.IDLE_CODE )  END W_DESC    ");
                    sbQuery.Append(" 	  FROM TSHP_IDLETIME I    ");
                    sbQuery.Append(" 	  WHERE I.IDLE_STATE = 1    ");
                    sbQuery.Append(" 	  ) S     ");
                    sbQuery.Append("   ON M.PLT_CODE = S.PLT_CODE    ");
                    sbQuery.Append("   AND M.MC_CODE = S.MC_CODE    ");
                    sbQuery.Append("   LEFT OUTER JOIN     ");
                    sbQuery.Append("   (SELECT W.PLT_CODE, W.WO_NO,     ");
                    sbQuery.Append("   I.CVND_CODE, V.VEN_NAME AS CVND_NAME,     ");
                    sbQuery.Append("   P.ITEM_CODE, W.PROD_CODE, W.PART_CODE, PT.PART_NAME, PT.DRAW_NO,    ");
                    sbQuery.Append("   W.PART_QTY, WO_FLAG, W.PLN_START_TIME, W.PLN_END_TIME    ");
                    sbQuery.Append("    FROM TSHP_WORKORDER W JOIN TORD_PRODUCT P    ");
                    sbQuery.Append("      ON W.PLT_CODE = P.PLT_CODE    ");
                    sbQuery.Append(" 	 AND W.PROD_CODE = P.PROD_CODE    ");
                    sbQuery.Append(" 	 AND W.PART_CODE = P.PART_CODE    ");
                    sbQuery.Append(" 	 JOIN LSE_STD_PART PT     ");
                    sbQuery.Append(" 	 ON W.PLT_CODE = PT.PLT_CODE    ");
                    sbQuery.Append(" 	 AND W.PART_CODE = PT.PART_CODE    ");
                    sbQuery.Append(" 	 JOIN TORD_ITEM I     ");
                    sbQuery.Append(" 	 ON P.PLT_CODE = I.PLT_CODE    ");
                    sbQuery.Append(" 	 AND P.ITEM_CODE = I.ITEM_CODE    ");
                    sbQuery.Append(" 	 JOIN TSTD_VENDOR V    ");
                    sbQuery.Append(" 	 ON I.PLT_CODE = V.PLT_CODE    ");
                    sbQuery.Append(" 	 AND I.CVND_CODE = V.VEN_CODE ) W    ");
                    sbQuery.Append("   ON S.PLT_CODE = W.PLT_CODE    ");
                    sbQuery.Append("   AND S.WO_NO = W.WO_NO    ");

                    sbQuery.Append("    LEFT JOIN TPOP_MC_STATUS MS     ");
                    sbQuery.Append("      ON M.PLT_CODE = MS.PLT_CODE   ");
                    sbQuery.Append("    AND M.MC_CODE = MS.MC_CODE  ");

                    sbQuery.Append("   WHERE M.DATA_FLAG = 0    ");
                    sbQuery.Append("    AND M.MC_GROUP = 'MCT'    ");
                    sbQuery.Append("   ORDER BY M.MC_SEQ    ");

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


        public static DataTable TSHP_ACTUAL_QUERY11(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {

                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT  ");
                    sbQuery.Append(" PLT_CODE ");
                    sbQuery.Append(" ,ACTUAL_ID ");
                    sbQuery.Append(" ,WO_NO ");
                    sbQuery.Append(" ,PROC_STAT ");
                    sbQuery.Append(" ,PANEL_STAT ");
                    sbQuery.Append(" ,INPUT_FLAG ");
                    sbQuery.Append(" ,ACT_TIME ");
                    sbQuery.Append(" ,ACT_START_TIME ");
                    sbQuery.Append(" ,ACT_END_TIME ");
                    sbQuery.Append(" ,MAN_TIME ");
                    sbQuery.Append(" ,MAN_START_TIME ");
                    sbQuery.Append(" ,MAN_END_TIME ");
                    sbQuery.Append(" ,OK_QTY");
                    sbQuery.Append(" ,NG_QTY");

                    sbQuery.Append(" FROM TSHP_ACTUAL ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@WO_NO", "WO_NO = @WO_NO"));
                        // sbWhere.Append(UTIL.GetWhere(row, "@EMP_CODE", "EMP_CODE = @EMP_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@MC_CODE", "MC_CODE = @MC_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@NULL_END_TIME", "ACT_END_TIME IS NULL "));
                        //sbWhere.Append(UTIL.GetWhere(row, "@PROC_STAT_IN", "PROC_STAT IN ('2','3') "));

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


        //작업지시에 대한 실적조회
        public static DataTable TSHP_ACTUAL_QUERY12(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT   ");
                    sbQuery.Append(" AC.PLT_CODE");
                    sbQuery.Append(" , WK.WO_FLAG");
                    sbQuery.Append(" , AC.ACTUAL_ID");
                    sbQuery.Append(" , AC.WORK_DATE");
                    sbQuery.Append(" , AC.WO_NO");
                    sbQuery.Append(" , AC.EMP_CODE");
                    sbQuery.Append(" , EMP.EMP_NAME");
                    sbQuery.Append(" , AC.MC_CODE");
                    sbQuery.Append(" , MC.MC_NAME");
                    sbQuery.Append(" , WK.PROC_CODE");
                    sbQuery.Append(" , SP.PROC_NAME");
                    sbQuery.Append(" , WK.PART_CODE");
                    sbQuery.Append(" , PT.PART_NAME");
                    sbQuery.Append(" , AC.MC_NM_CHECK");
                    sbQuery.Append(" , AC.PROC_STAT");
                    sbQuery.Append(" , AC.PANEL_STAT");
                    sbQuery.Append(" , AC.ACT_START_TIME");
                    sbQuery.Append(" , AC.ACT_END_TIME");
                    sbQuery.Append(" , AC.SELF_TIME");
                    sbQuery.Append(" , AC.SELF_START_TIME");
                    sbQuery.Append(" , AC.SELF_END_TIME");
                    sbQuery.Append(" , AC.MAN_TIME");
                    sbQuery.Append(" , AC.MAN_START_TIME");
                    sbQuery.Append(" , AC.MAN_END_TIME");
                    sbQuery.Append(" , AC.OT_TIME");
                    sbQuery.Append(" , AC.PAUSE_TIME");
                    sbQuery.Append(" , AC.PAUSE_START_TIME");
                    sbQuery.Append(" , AC.PAUSE_END_TIME");
                    sbQuery.Append(" , AC.INPUT_FLAG");
                    sbQuery.Append(" , AC.REG_DATE");
                    sbQuery.Append(" , AC.REG_EMP");
                    sbQuery.Append(" , AC.MDFY_DATE");
                    sbQuery.Append(" , AC.MDFY_EMP");
                    sbQuery.Append(" , AC.OK_QTY");
                    sbQuery.Append(" , AC.NG_QTY");
                    sbQuery.Append(" , WK.CAUTION");
                    sbQuery.Append(" FROM TSHP_ACTUAL AC");
                    sbQuery.Append(" JOIN TSHP_WORKORDER  WK");
                    sbQuery.Append(" ON AC.PLT_CODE = WK.PLT_CODE ");
                    sbQuery.Append(" AND AC.WO_NO = WK.WO_NO ");
                    sbQuery.Append("                            ");
                    sbQuery.Append(" LEFT JOIN LSE_MACHINE MC ");
                    sbQuery.Append(" ON WK.PLT_CODE = MC.PLT_CODE ");
                    sbQuery.Append(" AND WK.MC_CODE = MC.MC_CODE ");
                    sbQuery.Append("                            ");
                    sbQuery.Append(" LEFT JOIN LSE_STD_PART PT");
                    sbQuery.Append(" ON WK.PLT_CODE = PT.PLT_CODE ");
                    sbQuery.Append(" AND WK.PART_CODE = PT.PART_CODE ");
                    sbQuery.Append("                            ");
                    sbQuery.Append(" LEFT JOIN LSE_STD_PROC SP ");
                    sbQuery.Append(" ON WK.PLT_CODE = SP.PLT_CODE ");
                    sbQuery.Append(" AND WK.PROC_CODE = SP.PROC_CODE ");
                    sbQuery.Append("                            ");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE EMP ");
                    sbQuery.Append(" ON AC.PLT_CODE = EMP.PLT_CODE ");
                    sbQuery.Append(" AND AC.EMP_CODE = EMP.EMP_CODE ");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE AC.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@WO_NO", "AC.WO_NO = @WO_NO"));
                        sbWhere.Append(" ORDER BY AC.ACT_START_TIME DESC");



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


        // 단말기 가공 완료/진행/잔여 수량 조회
        public static DataTable TSHP_ACTUAL_QUERY13(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {

                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT ISNULL(SUM(A.OK_QTY),0) AS ACT_QTY ");
                    sbQuery.Append(" ,SUM(CASE WHEN PROC_STAT = 2 THEN PLN_QTY ELSE 0 END) AS ING_QTY ");
                    sbQuery.Append(" ,W.PART_QTY - ISNULL(SUM(A.OK_QTY),0) AS LEFT_QTY ");
                    sbQuery.Append(" FROM TSHP_ACTUAL A ");
                    sbQuery.Append(" LEFT JOIN TSHP_WORKORDER W ");
                    sbQuery.Append(" ON A.PLT_CODE = W.PLT_CODE ");
                    sbQuery.Append(" AND A.WO_NO = W.WO_NO      ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        StringBuilder sbWhere = new StringBuilder(" WHERE A.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, " @WO_NO", "A.WO_NO = @WO_NO "));
                        sbWhere.Append(UTIL.GetWhere(row, " @CHAIN_WO_NO", "W.CHAIN_WO_NO = @CHAIN_WO_NO "));
                        sbWhere.Append(UTIL.GetWhere(row, " @DATA_FLAG", "W.DATA_FLAG = @DATA_FLAG "));
                        sbWhere.Append(" GROUP BY W.PART_QTY");


                        DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString() + sbWhere.ToString(), row).Copy();

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

        public static DataTable TSHP_ACTUAL_QUERY13_2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {

                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT W.WO_NO, ISNULL(SUM(A.OK_QTY),0) AS ACT_QTY");
                    sbQuery.Append(" ,SUM(CASE WHEN PROC_STAT = 2 THEN PLN_QTY ELSE 0 END) AS ING_QTY");
                    sbQuery.Append(" ,W.PART_QTY - ISNULL(SUM(A.OK_QTY),0) AS LEFT_QTY");
                    sbQuery.Append(" FROM TSHP_WORKORDER W");
                    sbQuery.Append(" LEFT JOIN TSHP_ACTUAL A");
                    sbQuery.Append(" ON A.PLT_CODE = W.PLT_CODE");
                    sbQuery.Append(" AND A.WO_NO = W.WO_NO");


                    foreach (DataRow row in dtParam.Rows)
                    {

                        StringBuilder sbWhere = new StringBuilder(" WHERE W.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, " @WO_NO", "A.WO_NO = @WO_NO "));
                        sbWhere.Append(UTIL.GetWhere(row, " @CHAIN_WO_NO", "W.CHAIN_WO_NO = @CHAIN_WO_NO "));
                        sbWhere.Append(UTIL.GetWhere(row, " @PROC_CODE", "W.PROC_CODE = @PROC_CODE "));
                        sbWhere.Append(UTIL.GetWhere(row, " @DATA_FLAG", "W.DATA_FLAG = @DATA_FLAG "));

                        sbWhere.Append(" GROUP BY W.PART_QTY, W.WO_NO");


                        DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString() + sbWhere.ToString(), row).Copy();

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


        // 특정 작업지시를 진행중인 설비 조회
        public static DataTable TSHP_ACTUAL_QUERY15(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT  ");
                    sbQuery.Append(" PLT_CODE ");
                    sbQuery.Append(" ,WO_NO ");
                    sbQuery.Append(" ,MC_CODE ");
                    sbQuery.Append(" ,PROC_STAT ");
                    sbQuery.Append(" FROM TSHP_ACTUAL ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@WO_NO", "WO_NO = @WO_NO"));
                        sbWhere.Append(UTIL.GetWhere(row, "@MC_CODE", "MC_CODE = @MC_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, " @PROC_STAT", "PROC_STAT = @PROC_STAT"));

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



        //실적조인쿼리
        public static DataTable TSHP_ACTUAL_QUERY14(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT");
                    sbQuery.Append("  A.PLT_CODE");
                    sbQuery.Append(" , A.WORK_DATE");
                    sbQuery.Append(" , A.WO_NO");
                    sbQuery.Append(" , W.PROD_CODE");
                    sbQuery.Append(" , P.PROD_NAME");
                    sbQuery.Append(" , W.PART_CODE");
                    sbQuery.Append(" , PT.PT_NAME AS PART_NAME");
                    sbQuery.Append(" , W.PART_NUM");
                    sbQuery.Append(" , W.PROC_CODE");
                    sbQuery.Append(" , PRC.PROC_NAME");
                    sbQuery.Append(" , A.EMP_CODE");
                    sbQuery.Append(" , E.EMP_NAME");
                    sbQuery.Append(" , A.MC_CODE");
                    sbQuery.Append(" , M.MC_NAME");
                    sbQuery.Append(" , A.MC_NM_CHECK");
                    sbQuery.Append(" , A.PROC_STAT");
                    sbQuery.Append(" , A.PANEL_STAT");
                    sbQuery.Append(" , A.ACT_START_TIME");
                    sbQuery.Append(" , A.ACT_END_TIME");
                    sbQuery.Append(" , A.SELF_TIME");
                    sbQuery.Append(" , A.SELF_START_TIME");
                    sbQuery.Append(" , A.SELF_END_TIME");
                    sbQuery.Append(" , A.MAN_TIME");
                    sbQuery.Append(" , A.MAN_START_TIME");
                    sbQuery.Append(" , A.MAN_END_TIME");
                    sbQuery.Append(" , A.OT_TIME");
                    sbQuery.Append(" , A.PAUSE_TIME");
                    sbQuery.Append(" , A.PAUSE_START_TIME");
                    sbQuery.Append(" , A.PAUSE_END_TIME");
                    sbQuery.Append(" , A.INPUT_FLAG");
                    sbQuery.Append(" , A.OK_QTY");
                    sbQuery.Append(" , A.NG_QTY");
                    sbQuery.Append(" , A.ACTUAL_ID");
                    sbQuery.Append(" , M.IS_MULTI_START");
                    sbQuery.Append(" FROM TSHP_ACTUAL A");
                    sbQuery.Append(" LEFT JOIN TSHP_WORKORDER W");
                    sbQuery.Append(" ON A.PLT_CODE = W.PLT_CODE");
                    sbQuery.Append(" AND A.WO_NO = W.WO_NO");
                    sbQuery.Append(" LEFT JOIN TORD_PRODUCT P");
                    sbQuery.Append(" ON W.PLT_CODE = P.PLT_CODE");
                    sbQuery.Append(" AND W.PROD_CODE = P.PROD_CODE");
                    sbQuery.Append(" LEFT JOIN TMAT_PARTLIST PT");
                    sbQuery.Append(" ON W.PLT_CODE = PT.PLT_CODE");
                    sbQuery.Append(" AND W.PROD_CODE = PT.PROD_CODE");
                    sbQuery.Append(" AND W.PART_CODE = PT.PART_CODE");
                    sbQuery.Append(" AND W.PART_NUM = PT.PART_NUM");
                    sbQuery.Append(" LEFT JOIN LSE_MACHINE M");
                    sbQuery.Append(" ON A.PLT_CODE = M.PLT_CODE");
                    sbQuery.Append(" AND A.MC_CODE = M.MC_CODE");
                    sbQuery.Append(" LEFT JOIN LSE_STD_PROC PRC"); ;
                    sbQuery.Append(" ON W.PLT_CODE = PRC.PLT_CODE");
                    sbQuery.Append(" AND W.PROC_CODE = PRC.PROC_CODE");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE E");
                    sbQuery.Append(" ON A.PLT_CODE = E.PLT_CODE");
                    sbQuery.Append(" AND A.EMP_CODE = E.EMP_CODE");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE A.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@WO_NO", "A.WO_NO = @WO_NO"));
                        sbWhere.Append(UTIL.GetWhere(row, "@MC_CODE", "A.MC_CODE = @MC_CODE"));
                        sbWhere.Append(" AND A.PROC_STAT = 2 AND A.PANEL_STAT IN (1,3,5,6)");


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



        //작업지시의 최근 실적을 알아온다
        public static DataTable TSHP_ACTUAL_QUERY20(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT  TOP 1 ");
                    sbQuery.Append(" PLT_CODE");
                    sbQuery.Append(" , ACTUAL_ID");
                    sbQuery.Append(" , WORK_DATE");
                    sbQuery.Append(" , WO_NO");
                    sbQuery.Append(" , EMP_CODE");
                    sbQuery.Append(" , MC_CODE");
                    sbQuery.Append(" , MC_NM_CHECK");
                    sbQuery.Append(" , PROC_STAT");
                    sbQuery.Append(" , PANEL_STAT");
                    sbQuery.Append(" , ACT_START_TIME");
                    sbQuery.Append(" , ACT_END_TIME");
                    sbQuery.Append(" , SELF_TIME");
                    sbQuery.Append(" , SELF_START_TIME");
                    sbQuery.Append(" , SELF_END_TIME");
                    sbQuery.Append(" , MAN_TIME");
                    sbQuery.Append(" , MAN_START_TIME");
                    sbQuery.Append(" , MAN_END_TIME");
                    sbQuery.Append(" , OT_TIME");
                    sbQuery.Append(" , PAUSE_TIME");
                    sbQuery.Append(" , PAUSE_START_TIME");
                    sbQuery.Append(" , PAUSE_END_TIME");
                    sbQuery.Append(" , INPUT_FLAG");
                    sbQuery.Append(" , REG_DATE");
                    sbQuery.Append(" , REG_EMP");
                    sbQuery.Append(" , MDFY_DATE");
                    sbQuery.Append(" , MDFY_EMP");
                    sbQuery.Append(" , OK_QTY");
                    sbQuery.Append(" , NG_QTY");
                    sbQuery.Append(" FROM TSHP_ACTUAL");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@WO_NO", "WO_NO = @WO_NO"));
                        sbWhere.Append(" ORDER BY ACT_START_TIME DESC");



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



        public static DataTable TSHP_ACTUAL_QUERY23(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {

                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT ACT.PLT_CODE");
                    sbQuery.Append(" ,ACT.ACTUAL_ID");
                    sbQuery.Append(" ,ACT.WORK_DATE");
                    sbQuery.Append(" ,W.PROD_CODE");
                    sbQuery.Append(" ,W.PART_CODE");
                    sbQuery.Append(" ,ACT.WO_NO");
                    sbQuery.Append(" ,ACT.EMP_CODE");
                    sbQuery.Append(" ,E.EMP_NAME");
                    sbQuery.Append(" ,ACT.MC_CODE");
                    sbQuery.Append(" ,M.MC_NAME");
                    sbQuery.Append(" ,ACT.MC_NM_CHECK");
                    sbQuery.Append(" ,ACT.PROC_STAT");
                    sbQuery.Append(" ,ACT.PANEL_STAT");
                    sbQuery.Append(" ,ACT.ACT_TIME");
                    sbQuery.Append(" ,ACT.ACT_START_TIME");
                    sbQuery.Append(" ,ACT.ACT_END_TIME");
                    sbQuery.Append(" ,ACT.SELF_TIME");
                    sbQuery.Append(" ,ACT.SELF_START_TIME");
                    sbQuery.Append(" ,ACT.SELF_END_TIME");
                    sbQuery.Append(" ,ACT.MAN_TIME");
                    sbQuery.Append(" ,ACT.MAN_START_TIME");
                    sbQuery.Append(" ,ACT.MAN_END_TIME");
                    sbQuery.Append(" ,ACT.OT_TIME");
                    sbQuery.Append(" ,ACT.PRE_START_TIME");
                    sbQuery.Append(" ,ACT.PRE_END_TIME");
                    sbQuery.Append(" ,ACT.PRE_TIME");
                    sbQuery.Append(" ,ACT.PAUSE_TIME");
                    sbQuery.Append(" ,ACT.PAUSE_START_TIME");
                    sbQuery.Append(" ,ACT.PAUSE_END_TIME");
                    sbQuery.Append(" ,(ISNULL(ACT.SELF_TIME, 0) + ISNULL(ACT.MAN_TIME, 0) + ISNULL(ACT.OT_TIME, 0) + ISNULL(ACT.PRE_TIME, 0)) AS WORK_TIME");
                    sbQuery.Append(" ,ACT.INPUT_FLAG");
                    sbQuery.Append(" ,W.PART_QTY AS PLN_QTY ");
                    //sbQuery.Append(" ,(ISNULL(ACT.OK_QTY, 0) + ISNULL(ACT.NG_QTY, 0)) AS WORK_QTY");
                    //작업수량은 양품 수량으로만 조회
                    sbQuery.Append(" ,(ISNULL(ACT.OK_QTY, 0)) AS WORK_QTY");
                    sbQuery.Append(" ,ACT.OK_QTY");
                    sbQuery.Append(" ,ACT.NG_QTY");
                    sbQuery.Append(" ,ACT.PAUSE_REASON");
                    sbQuery.Append(" ,ACT.REG_EMP");
                    sbQuery.Append(" ,REG.EMP_NAME AS REG_EMP_NAME");
                    sbQuery.Append(" ,ACT.REG_DATE");
                    sbQuery.Append(" ,ACT.MDFY_EMP");
                    sbQuery.Append(" ,MDFY.EMP_NAME AS MDFY_EMP_NAME");
                    sbQuery.Append(" ,ACT.MDFY_DATE");
                    sbQuery.Append(" ,ID.IDLE_CODE");

                    sbQuery.Append(" FROM TSHP_ACTUAL ACT");
                    sbQuery.Append(" LEFT JOIN TSHP_WORKORDER W");
                    sbQuery.Append(" ON ACT.PLT_CODE = W.PLT_CODE");
                    sbQuery.Append(" AND ACT.WO_NO = W.WO_NO");
                    
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE E");
                    sbQuery.Append(" ON ACT.PLT_CODE = E.PLT_CODE");
                    sbQuery.Append(" AND ACT.EMP_CODE = E.EMP_CODE");
                    
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE REG");
                    sbQuery.Append(" ON ACT.PLT_CODE = REG.PLT_CODE");
                    sbQuery.Append(" AND ACT.REG_EMP = REG.EMP_CODE");
                    
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE MDFY");
                    sbQuery.Append(" ON ACT.PLT_CODE = MDFY.PLT_CODE");
                    sbQuery.Append(" AND ACT.MDFY_EMP = MDFY.EMP_CODE");
                    
                    sbQuery.Append(" LEFT JOIN LSE_MACHINE M");
                    sbQuery.Append(" ON ACT.PLT_CODE = E.PLT_CODE");
                    sbQuery.Append(" AND ACT.MC_CODE = M.MC_CODE");
                    
                    sbQuery.Append(" LEFT JOIN TSHP_IDLETIME ID ");
                    sbQuery.Append(" ON ACT.PLT_CODE = ID.PLT_CODE");
                    sbQuery.Append(" AND ACT.ACTUAL_ID = ID.ACTUAL_ID");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE ACT.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@WO_NO", "ACT.WO_NO = @WO_NO"));
                        //sbWhere.Append(UTIL.GetWhere(row, "@S_ORD_DATE, @E_ORD_DATE", "(I.ORD_DATE BETWEEN @S_ORD_DATE AND @E_ORD_DATE)"));
                        sbWhere.Append(UTIL.GetWhere(row, "@ACTUAL_ID", "ACT.ACTUAL_ID = @ACTUAL_ID"));
                        sbWhere.Append("ORDER BY ACT.ACT_END_TIME");

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

        //모니터링 화면 실적 정보 조회 
        public static DataTable TSHP_ACTUAL_QUERY31(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {

                DataSet dsResult = new DataSet();
               
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT");
                    sbQuery.Append(" A.PLT_CODE");
                    sbQuery.Append(" ,'진행' AS MC_STATUS");
                    sbQuery.Append(" ,A.MC_CODE");
                    sbQuery.Append(" ,M.MC_NAME");
                    sbQuery.Append(" ,P.PROD_CODE");
                    sbQuery.Append(" ,P.PROD_NAME");
                    sbQuery.Append(" ,P.CVND_CODE");
                    sbQuery.Append(" ,V.VEN_NAME AS CVND_NAME");
                    sbQuery.Append(" ,W.PART_CODE");
                    sbQuery.Append(" ,SP.PART_NAME");
                    sbQuery.Append(" ,A.ACT_START_TIME");
                    sbQuery.Append(" ,DATEDIFF(MINUTE, A.ACT_START_TIME, GETDATE()) AS ACT_TIME");
                    sbQuery.Append(" ,M.MC_SEQ");
                    sbQuery.Append(" ,M.MC_MNT_NAME");
                    sbQuery.Append(" ,NULL AS IDLE_CODE");
                    sbQuery.Append(" FROM TSHP_ACTUAL A");
                    sbQuery.Append(" LEFT JOIN TSHP_WORKORDER W");
                    sbQuery.Append(" ON A.PLT_CODE = W.PLT_CODE");
                    sbQuery.Append(" AND A.WO_NO = W.WO_NO");
                    
                    sbQuery.Append(" LEFT JOIN TORD_PRODUCT P");
                    sbQuery.Append(" ON W.PLT_CODE = P.PLT_CODE");
                    sbQuery.Append(" AND W.PROD_CODE = P.PROD_CODE");
                    
                    sbQuery.Append(" LEFT JOIN LSE_MACHINE M");
                    sbQuery.Append(" ON A.PLT_CODE = M.PLT_CODE");
                    sbQuery.Append(" AND A.MC_CODE = M.MC_CODE");
                    
                    sbQuery.Append(" LEFT JOIN TSTD_VENDOR V");
                    sbQuery.Append(" ON P.PLT_CODE = V.PLT_CODE");
                    sbQuery.Append(" AND P.CVND_CODE = V.VEN_CODE");
                    
                    sbQuery.Append(" LEFT JOIN LSE_STD_PART SP");
                    sbQuery.Append(" ON W.PLT_CODE = SP.PLT_CODE");
                    sbQuery.Append(" AND W.PART_CODE = SP.PART_CODE");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE A.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(" AND A.PROC_STAT = '2' ORDER BY M.MC_SEQ");

                        DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString() + sbWhere.ToString(), row).Copy();

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

        public static DataTable TSHP_ACTUAL_QUERY32(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {

                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT");
                    sbQuery.Append(" PLT_CODE");
                    sbQuery.Append(" ,'중지' AS MC_STATUS");
                    sbQuery.Append(" ,MC_CODE");
                    sbQuery.Append(" ,MC_NAME");
                    sbQuery.Append(" ,PROD_CODE");
                    sbQuery.Append(" ,PROD_NAME");
                    sbQuery.Append(" ,CVND_CODE");
                    sbQuery.Append(" ,CVND_NAME");
                    sbQuery.Append(" ,PART_CODE");
                    sbQuery.Append(" ,PART_NAME");
                    sbQuery.Append(" ,ACT_END_TIME AS ACT_START_TIME");
                    sbQuery.Append(" ,ACT_TIME");
                    sbQuery.Append(" ,MC_SEQ");
                    sbQuery.Append(" ,MC_MNT_NAME");
                    sbQuery.Append(" ,NULL AS IDLE_CODE");
                    sbQuery.Append(" FROM");
                    sbQuery.Append(" (");
                    sbQuery.Append(" SELECT");
                    sbQuery.Append(" A.PLT_CODE");
                    sbQuery.Append(" ,ROW_NUMBER() OVER(PARTITION BY A.MC_CODE ORDER BY A.ACT_END_TIME) AS ROW_SEQ");
                    sbQuery.Append(" ,A.MC_CODE");
                    sbQuery.Append(" ,M.MC_NAME");
                    sbQuery.Append(" ,P.PROD_CODE");
                    sbQuery.Append(" ,P.PROD_NAME");
                    sbQuery.Append(" ,P.CVND_CODE");
                    sbQuery.Append(" ,V.VEN_NAME AS CVND_NAME");
                    sbQuery.Append(" ,W.PART_CODE");
                    sbQuery.Append(" ,SP.PART_NAME");
                    sbQuery.Append(" ,A.ACT_END_TIME");
                    sbQuery.Append(" ,DATEDIFF(MINUTE, A.ACT_END_TIME, GETDATE()) AS ACT_TIME");
                    sbQuery.Append(" ,M.MC_SEQ");
                    sbQuery.Append(" ,M.MC_MNT_NAME");
                    sbQuery.Append(" FROM TSHP_ACTUAL A");
                    sbQuery.Append(" LEFT JOIN TSHP_WORKORDER W");
                    sbQuery.Append(" ON A.PLT_CODE = W.PLT_CODE");
                    sbQuery.Append(" AND A.WO_NO = W.WO_NO");
                    
                    sbQuery.Append(" LEFT JOIN TORD_PRODUCT P");
                    sbQuery.Append(" ON W.PLT_CODE = P.PLT_CODE");
                    sbQuery.Append(" AND W.PROD_CODE = P.PROD_CODE");
                    
                    sbQuery.Append(" LEFT JOIN LSE_MACHINE M");
                    sbQuery.Append(" ON A.PLT_CODE = M.PLT_CODE");
                    sbQuery.Append(" AND A.MC_CODE = M.MC_CODE");
                    
                    sbQuery.Append(" LEFT JOIN TSTD_VENDOR V");
                    sbQuery.Append(" ON P.PLT_CODE = V.PLT_CODE");
                    sbQuery.Append(" AND P.CVND_CODE = V.VEN_CODE");
                    
                    sbQuery.Append(" LEFT JOIN LSE_STD_PART SP");
                    sbQuery.Append(" ON W.PLT_CODE = SP.PLT_CODE");
                    sbQuery.Append(" AND W.PART_CODE = SP.PART_CODE");
                    sbQuery.Append(" WHERE A.PROC_STAT IN ('3')");
                    sbQuery.Append(" ) S");



                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE S.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(" AND S.ROW_SEQ = 1 ORDER BY S.MC_SEQ");

                        DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString() + sbWhere.ToString(), row).Copy();

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

        public static DataTable TSHP_ACTUAL_QUERY33(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {

                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT");
                    sbQuery.Append(" TOP 1");
                    sbQuery.Append(" PLT_CODE");
                    sbQuery.Append(" ,ACTUAL_ID");
                    sbQuery.Append(" ,NG_QTY");
                    sbQuery.Append(" FROM TSHP_ACTUAL");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                        sbWhere.Append(UTIL.GetWhere(row, "@WO_NO", "WO_NO = @WO_NO"));
                        sbWhere.Append(" AND ACT_END_TIME IS NOT NULL ORDER BY ACT_START_TIME DESC");

                        DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString() + sbWhere.ToString(), row).Copy();

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

        public static DataTable TSHP_ACTUAL_QUERY34(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {

                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT");
                    sbQuery.Append(" A.PLT_CODE, A.MC_CODE, M.MC_NAME, SUM(A.OK_QTY) AS OK_QTY, A.WORK_DATE");
                    sbQuery.Append(" ,W.PROD_CODE, P.PROD_NAME, P.CVND_CODE, V.VEN_NAME AS CVND_NAME, SUM(DATEDIFF(MINUTE, A.ACT_START_TIME, A.ACT_END_TIME)) AS ACT_TIME");
                    sbQuery.Append(" ,W.PART_CODE, SP.PART_NAME");//, A.ACT_START_TIME, A.ACT_END_TIME, A.ACT_TIME");
                    sbQuery.Append(" FROM TSHP_ACTUAL A WITH(NOLOCK)");
                    sbQuery.Append(" LEFT JOIN TSHP_WORKORDER W WITH(NOLOCK)");
                    sbQuery.Append(" ON A.PLT_CODE = W.PLT_CODE");
                    sbQuery.Append(" AND A.WO_NO = W.WO_NO");
                    sbQuery.Append(" LEFT JOIN TORD_PRODUCT P");
                    sbQuery.Append(" ON W.PLT_CODE = P.PLT_CODE");
                    sbQuery.Append(" AND W.PROD_CODE = P.PROD_CODE");
                    sbQuery.Append(" LEFT JOIN LSE_MACHINE M");
                    sbQuery.Append(" ON A.PLT_CODE = M.PLT_CODE");
                    sbQuery.Append(" AND A.MC_CODE = M.MC_CODE");
                    sbQuery.Append(" LEFT JOIN TSTD_VENDOR V");
                    sbQuery.Append(" ON P.PLT_CODE = V.PLT_CODE");
                    sbQuery.Append(" AND P.CVND_CODE = V.VEN_CODE");
                    sbQuery.Append(" LEFT JOIN LSE_STD_PART SP");
                    sbQuery.Append(" ON W.PLT_CODE = SP.PLT_CODE");
                    sbQuery.Append(" AND W.PART_CODE = SP.PART_CODE");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE A.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                        sbWhere.Append(UTIL.GetWhere(row, "@MC_CODE", "A.MC_CODE = @MC_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_WORK_DATE, @E_WORK_DATE", "A.WORK_DATE BETWEEN @S_WORK_DATE AND @E_WORK_DATE"));
                        sbWhere.Append(" AND W.DATA_FLAG = '0' AND P.DATA_FLAG = '0' AND A.OK_QTY > 0");

                        sbWhere.Append(" GROUP BY A.PLT_CODE, A.MC_CODE, M.MC_NAME");
                        sbWhere.Append(" ,W.PROD_CODE, P.PROD_NAME, P.CVND_CODE, V.VEN_NAME");
                        sbWhere.Append(" ,W.PART_CODE, SP.PART_NAME, A.WORK_DATE  ORDER BY A.WORK_DATE DESC");

                        DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString() + sbWhere.ToString(), row).Copy();

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

        public static DataTable TSHP_ACTUAL_QUERY35(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {

                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED");
                    sbQuery.Append(" SELECT PLT_CODE, LEFT(WORK_DATE, 6) AS WORK_MONTH, SUM(ISNULL(OK_QTY, 0)) AS OK_QTY FROM TSHP_ACTUAL A");
                    sbQuery.Append(" WHERE LEFT(WORK_DATE, 6) = @S_MONTH");
                    sbQuery.Append(" GROUP BY PLT_CODE, LEFT(WORK_DATE, 6)");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder();

                        DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString() + sbWhere.ToString(), row).Copy();

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
