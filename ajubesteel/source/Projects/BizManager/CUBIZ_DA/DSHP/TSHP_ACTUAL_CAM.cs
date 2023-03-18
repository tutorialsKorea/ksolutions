using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace DSHP
{
    public class TSHP_ACTUAL_CAM
    {
        public static DataTable TSHP_ACTUAL_CAM_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("  SELECT  ");
                    sbQuery.Append("  PLT_CODE ");
                    sbQuery.Append(" ,ACTUAL_ID ");
                    sbQuery.Append(" ,WORK_DATE ");
                    sbQuery.Append(" ,WO_NO ");
                    sbQuery.Append(" ,EMP_CODE ");
                    sbQuery.Append(" ,PROC_STAT ");
                    sbQuery.Append(" ,ACT_TIME ");
                    sbQuery.Append(" ,ACT_START_TIME ");
                    sbQuery.Append(" ,ACT_END_TIME ");
                    sbQuery.Append(" ,X_VALUE ");
                    sbQuery.Append(" ,Y_VALUE ");
                    sbQuery.Append(" ,T_VALUE ");
                    sbQuery.Append(" ,P_CNT ");
                    sbQuery.Append(" ,MIL_REQ_DATE ");
                    sbQuery.Append(" ,SCOMMENT ");
                    sbQuery.Append(" ,MAT_CODE ");
                    sbQuery.Append(" ,STK_ID ");
                    sbQuery.Append(" ,LOT_ID ");
                    sbQuery.Append(" ,REG_DATE ");
                    sbQuery.Append(" ,REG_EMP ");
                    sbQuery.Append(" ,MDFY_DATE ");
                    sbQuery.Append(" ,MDFY_EMP ");
                    sbQuery.Append(" ,PT_ID ");
                    sbQuery.Append("  FROM TSHP_ACTUAL_CAM  ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("  AND ACTUAL_ID = @ACTUAL_ID  ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
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

        public static DataTable TSHP_ACTUAL_CAM_SER2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("  SELECT  ");
                    sbQuery.Append("  PLT_CODE ");
                    sbQuery.Append(" ,ACTUAL_ID ");
                    sbQuery.Append(" ,WORK_DATE ");
                    sbQuery.Append(" ,WO_NO ");
                    sbQuery.Append(" ,EMP_CODE ");
                    sbQuery.Append(" ,PROC_STAT ");
                    sbQuery.Append(" ,ACT_TIME ");
                    sbQuery.Append(" ,ACT_START_TIME ");
                    sbQuery.Append(" ,ACT_END_TIME ");
                    sbQuery.Append(" ,X_VALUE ");
                    sbQuery.Append(" ,Y_VALUE ");
                    sbQuery.Append(" ,T_VALUE ");
                    sbQuery.Append(" ,P_CNT ");
                    sbQuery.Append(" ,MIL_REQ_DATE ");
                    sbQuery.Append(" ,SCOMMENT ");
                    sbQuery.Append(" ,MAT_CODE ");
                    sbQuery.Append(" ,STK_ID ");
                    sbQuery.Append(" ,LOT_ID ");
                    sbQuery.Append(" ,REG_DATE ");
                    sbQuery.Append(" ,REG_EMP ");
                    sbQuery.Append(" ,MDFY_DATE ");
                    sbQuery.Append(" ,MDFY_EMP ");
                    sbQuery.Append(" ,PT_ID ");
                    sbQuery.Append("  FROM TSHP_ACTUAL_CAM  ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("  AND WO_NO = @WO_NO  ");

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


        public static void TSHP_ACTUAL_CAM_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" INSERT INTO TSHP_ACTUAL_CAM (  ");
                    sbQuery.Append("  PLT_CODE ");
                    sbQuery.Append(" ,ACTUAL_ID ");
                    sbQuery.Append(" ,WORK_DATE ");
                    sbQuery.Append(" ,WO_NO ");
                    sbQuery.Append(" ,EMP_CODE ");
                    sbQuery.Append(" ,PROC_STAT ");
                    sbQuery.Append(" ,ACT_TIME ");
                    sbQuery.Append(" ,PT_ID ");
                    sbQuery.Append(" ,ACT_START_TIME ");
                    //sbQuery.Append(" ,ACT_END_TIME ");
                    sbQuery.Append(" ,X_VALUE ");
                    sbQuery.Append(" ,Y_VALUE ");
                    sbQuery.Append(" ,T_VALUE ");
                    sbQuery.Append(" ,P_CNT ");
                    sbQuery.Append(" ,MIL_REQ_DATE ");
                    sbQuery.Append(" ,SCOMMENT ");
                    sbQuery.Append(" ,MAT_QLTY ");
                    sbQuery.Append(" ,MAT_CODE ");
                    sbQuery.Append(" ,STK_ID ");
                    sbQuery.Append(" ,LOT_ID ");
                    sbQuery.Append(" ,RE_WO_NO ");
                    sbQuery.Append(" ,REG_DATE ");
                    sbQuery.Append(" ,REG_EMP ");
                    sbQuery.Append("  ) VALUES (  ");
                    sbQuery.Append("  @PLT_CODE ");
                    sbQuery.Append(" ,@ACTUAL_ID ");
                    sbQuery.Append(" ,@WORK_DATE ");
                    sbQuery.Append(" ,@WO_NO ");
                    sbQuery.Append(" ,@EMP_CODE ");
                    sbQuery.Append(" ,@PROC_STAT ");
                    sbQuery.Append(" ,@ACT_TIME ");
                    sbQuery.Append(" ,@PT_ID ");
                    sbQuery.Append(" ,GETDATE() ");
                    //sbQuery.Append(" ,@ACT_END_TIME ");
                    sbQuery.Append(" ,@X_VALUE ");
                    sbQuery.Append(" ,@Y_VALUE ");
                    sbQuery.Append(" ,@T_VALUE ");
                    sbQuery.Append(" ,@P_CNT ");
                    sbQuery.Append(" ,@MIL_REQ_DATE ");
                    sbQuery.Append(" ,@SCOMMENT ");
                    sbQuery.Append(" ,@MAT_QLTY ");
                    sbQuery.Append(" ,@MAT_CODE ");
                    sbQuery.Append(" ,@STK_ID ");
                    sbQuery.Append(" ,@LOT_ID ");
                    sbQuery.Append(" ,@RE_WO_NO ");
                    sbQuery.Append(" ,GETDATE() ");
                    sbQuery.Append(" ,'" + ConnInfo.UserID + "' ");
                    sbQuery.Append("  ) ");

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

        public static void TSHP_ACTUAL_CAM_INS2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" INSERT INTO TSHP_ACTUAL_CAM (  ");
                    sbQuery.Append("  PLT_CODE ");
                    sbQuery.Append(" ,ACTUAL_ID ");
                    sbQuery.Append(" ,WORK_DATE ");
                    sbQuery.Append(" ,WO_NO ");
                    sbQuery.Append(" ,EMP_CODE ");
                    sbQuery.Append(" ,PROC_STAT ");
                    sbQuery.Append(" ,ACT_TIME ");
                    sbQuery.Append(" ,PT_ID ");
                    sbQuery.Append(" ,ACT_START_TIME ");
                    sbQuery.Append(" ,ACT_END_TIME ");
                    sbQuery.Append(" ,X_VALUE ");
                    sbQuery.Append(" ,Y_VALUE ");
                    sbQuery.Append(" ,T_VALUE ");
                    sbQuery.Append(" ,P_CNT ");
                    sbQuery.Append(" ,MIL_REQ_DATE ");
                    sbQuery.Append(" ,SCOMMENT ");
                    sbQuery.Append(" ,MAT_QLTY ");
                    sbQuery.Append(" ,MAT_CODE ");
                    sbQuery.Append(" ,STK_ID ");
                    sbQuery.Append(" ,LOT_ID ");
                    sbQuery.Append(" ,RE_WO_NO ");
                    sbQuery.Append(" ,REG_DATE ");
                    sbQuery.Append(" ,REG_EMP ");
                    sbQuery.Append("  ) VALUES (  ");
                    sbQuery.Append("  @PLT_CODE ");
                    sbQuery.Append(" ,@ACTUAL_ID ");
                    sbQuery.Append(" ,@WORK_DATE ");
                    sbQuery.Append(" ,@WO_NO ");
                    sbQuery.Append(" ,@EMP_CODE ");
                    sbQuery.Append(" ,@PROC_STAT ");
                    sbQuery.Append(" ,@ACT_TIME ");
                    sbQuery.Append(" ,@PT_ID ");
                    sbQuery.Append(" ,GETDATE() ");
                    sbQuery.Append(" ,GETDATE() ");
                    sbQuery.Append(" ,@X_VALUE ");
                    sbQuery.Append(" ,@Y_VALUE ");
                    sbQuery.Append(" ,@T_VALUE ");
                    sbQuery.Append(" ,@P_CNT ");
                    sbQuery.Append(" ,@MIL_REQ_DATE ");
                    sbQuery.Append(" ,@SCOMMENT ");
                    sbQuery.Append(" ,@MAT_QLTY ");
                    sbQuery.Append(" ,@MAT_CODE ");
                    sbQuery.Append(" ,@STK_ID ");
                    sbQuery.Append(" ,@LOT_ID ");
                    sbQuery.Append(" ,@RE_WO_NO ");
                    sbQuery.Append(" ,GETDATE() ");
                    sbQuery.Append(" ,'" + ConnInfo.UserID + "' ");
                    sbQuery.Append("  ) ");

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


        public static void TSHP_ACTUAL_CAM_UPD(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TSHP_ACTUAL_CAM SET  ");
                    sbQuery.Append("  WORK_DATE = @WORK_DATE ");
                    sbQuery.Append(" ,WO_NO = @WO_NO ");
                    sbQuery.Append(" ,EMP_CODE = @EMP_CODE ");
                    //sbQuery.Append(" ,PROC_STAT = @PROC_STAT ");
                    sbQuery.Append(" ,ACT_TIME = @ACT_TIME ");
                    //sbQuery.Append(" ,ACT_START_TIME = @ACT_START_TIME ");
                    //sbQuery.Append(" ,ACT_END_TIME = @ACT_END_TIME ");
                    sbQuery.Append(" ,X_VALUE = @X_VALUE ");
                    sbQuery.Append(" ,Y_VALUE = @Y_VALUE ");
                    sbQuery.Append(" ,T_VALUE = @T_VALUE ");
                    sbQuery.Append(" ,P_CNT = @P_CNT ");
                    sbQuery.Append(" ,MIL_REQ_DATE = @MIL_REQ_DATE "); 
                    sbQuery.Append(" ,MAT_QLTY = @MAT_QLTY ");
                    sbQuery.Append(" ,SCOMMENT = @SCOMMENT ");
                    sbQuery.Append(" ,MAT_CODE = @MAT_CODE ");
                    sbQuery.Append(" ,STK_ID = @STK_ID ");
                    sbQuery.Append(" ,LOT_ID = @LOT_ID ");
                    sbQuery.Append(" ,RE_WO_NO = @RE_WO_NO ");
                    sbQuery.Append(" ,MDFY_DATE = GETDATE() ");
                    sbQuery.Append(" ,MDFY_EMP = '" + ConnInfo.UserID + "' ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append("  AND ACTUAL_ID = @ACTUAL_ID ");
                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
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


        public static void TSHP_ACTUAL_CAM_UPD2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TSHP_ACTUAL_CAM SET  ");
                    sbQuery.Append("  WORK_DATE = @WORK_DATE ");
                    sbQuery.Append(" ,WO_NO = @WO_NO ");
                    sbQuery.Append(" ,EMP_CODE = @EMP_CODE ");
                    sbQuery.Append(" ,PROC_STAT = @PROC_STAT ");
                    sbQuery.Append(" ,ACT_TIME = @ACT_TIME ");
                    //sbQuery.Append(" ,ACT_START_TIME = @ACT_START_TIME ");
                    sbQuery.Append(" ,ACT_END_TIME = GETDATE() ");
                    sbQuery.Append(" ,X_VALUE = @X_VALUE ");
                    sbQuery.Append(" ,Y_VALUE = @Y_VALUE ");
                    sbQuery.Append(" ,T_VALUE = @T_VALUE ");
                    sbQuery.Append(" ,P_CNT = @P_CNT ");
                    sbQuery.Append(" ,MIL_REQ_DATE = @MIL_REQ_DATE ");
                    sbQuery.Append(" ,MAT_QLTY = @MAT_QLTY ");
                    sbQuery.Append(" ,SCOMMENT = @SCOMMENT ");
                    sbQuery.Append(" ,MAT_CODE = @MAT_CODE ");
                    sbQuery.Append(" ,STK_ID = @STK_ID ");
                    sbQuery.Append(" ,LOT_ID = @LOT_ID ");
                    sbQuery.Append(" ,RE_WO_NO = @RE_WO_NO ");
                    sbQuery.Append(" ,MDFY_DATE = GETDATE() ");
                    sbQuery.Append(" ,MDFY_EMP = '" + ConnInfo.UserID + "' ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append("  AND ACTUAL_ID = @ACTUAL_ID ");
                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
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

        public static void TSHP_ACTUAL_CAM_UPD3(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TSHP_ACTUAL_CAM SET  ");
                    sbQuery.Append(" PROC_STAT = @PROC_STAT ");
                    sbQuery.Append(" ,ACT_TIME = 0 ");
                    sbQuery.Append(" ,ACT_END_TIME = NULL ");
                    sbQuery.Append(" ,MDFY_DATE = GETDATE() ");
                    sbQuery.Append(" ,MDFY_EMP = '" + ConnInfo.UserID + "' ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append("  AND ACTUAL_ID = @ACTUAL_ID ");
                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
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

    }

    public class TSHP_ACTUAL_CAM_QUERY
    {

        


        //실적 기본쿼리
        public static DataTable TSHP_ACTUAL_CAM_QUERY1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append("  SELECT  ");
                    sbQuery.Append("  PLT_CODE ");
                    sbQuery.Append(" ,ACTUAL_ID ");
                    sbQuery.Append(" ,WORK_DATE ");
                    sbQuery.Append(" ,WO_NO ");
                    sbQuery.Append(" ,EMP_CODE ");
                    sbQuery.Append(" ,PROC_STAT ");
                    sbQuery.Append(" ,ACT_TIME ");
                    sbQuery.Append(" ,ACT_START_TIME ");
                    sbQuery.Append(" ,ACT_END_TIME ");
                    sbQuery.Append(" ,X_VALUE ");
                    sbQuery.Append(" ,Y_VALUE ");
                    sbQuery.Append(" ,T_VALUE ");
                    sbQuery.Append(" ,P_CNT ");
                    sbQuery.Append(" ,MIL_REQ_DATE");
                    sbQuery.Append(" ,SCOMMENT ");
                    sbQuery.Append(" ,MAT_QLTY ");
                    sbQuery.Append(" ,MAT_CODE ");
                    sbQuery.Append(" ,STK_ID ");
                    sbQuery.Append(" ,LOT_ID ");
                    sbQuery.Append(" ,REG_DATE ");
                    sbQuery.Append(" ,REG_EMP ");
                    sbQuery.Append(" ,MDFY_DATE ");
                    sbQuery.Append(" ,MDFY_EMP ");
                    sbQuery.Append(" FROM TSHP_ACTUAL_CAM");


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

        public static DataTable TSHP_ACTUAL_CAM_QUERY2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT");
                    sbQuery.Append(" AC.PLT_CODE");
                    sbQuery.Append(" ,AC.WO_NO");
                    sbQuery.Append(" ,CONVERT(TINYINT, '0') AS INPUT_FLAG");
                    sbQuery.Append(" ,AC.WORK_DATE");
                    sbQuery.Append(" ,AC.EMP_CODE");
                    sbQuery.Append(" ,E.EMP_NAME");
                    sbQuery.Append(" ,AC.ACT_START_TIME");
                    sbQuery.Append(" ,AC.ACT_END_TIME");
                    //sbQuery.Append(" ,NULL AS ACT_TIME");
                    sbQuery.Append(" FROM TSHP_ACTUAL_CAM AC");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE E");
                    sbQuery.Append(" ON AC.PLT_CODE = E.PLT_CODE");
                    sbQuery.Append(" AND AC.EMP_CODE = E.EMP_CODE");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE AC.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@WO_NO", "AC.WO_NO = @WO_NO"));
                        sbWhere.Append(" ORDER BY AC.ACT_START_TIME");


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
