using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace DSHP
{
    public class TSHP_ACTUAL_LOT_LOG
    {
        public static DataTable TSHP_ACTUAL_LOT_LOG_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("  SELECT  ");
                    sbQuery.Append("  UID ");
                    sbQuery.Append(" ,PLT_CODE ");
                    sbQuery.Append(" ,ACTUAL_ID ");
                    sbQuery.Append(" ,PART_CODE ");
                    sbQuery.Append(" ,LOT_ID ");
                    sbQuery.Append(" ,USE_AMT ");
                    sbQuery.Append(" ,DATA_FLAG ");
                    sbQuery.Append(" ,REG_EMP ");
                    sbQuery.Append(" ,REG_DATE ");
                    sbQuery.Append(" ,DEL_EMP ");
                    sbQuery.Append(" ,DEL_DATE ");
                    sbQuery.Append("  FROM TSHP_ACTUAL_LOT_LOG  ");
                    sbQuery.Append("  WHERE ACTUAL_ID = @ACTUAL_ID  ");
                    sbQuery.Append("  AND DATA_FLAG = @DATA_FLAG  ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "DATA_FLAG")) isHasColumn = false;

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




        public static void TSHP_ACTUAL_LOT_LOG_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" INSERT INTO TSHP_ACTUAL_LOT_LOG (  ");
                    sbQuery.Append(" PLT_CODE ");
                    sbQuery.Append(" ,ACTUAL_ID ");
                    sbQuery.Append(" ,PART_CODE ");
                    sbQuery.Append(" ,LOT_ID ");
                    sbQuery.Append(" ,USE_AMT ");
                    sbQuery.Append(" ,DATA_FLAG ");
                    sbQuery.Append(" ,REG_EMP ");
                    sbQuery.Append(" ,REG_DATE ");
                    sbQuery.Append("  ) VALUES (  ");
                    sbQuery.Append(" @PLT_CODE ");
                    sbQuery.Append(" ,@ACTUAL_ID ");
                    sbQuery.Append(" ,@PART_CODE ");
                    sbQuery.Append(" ,@LOT_ID ");
                    sbQuery.Append(" ,@USE_AMT ");
                    sbQuery.Append(" ,@DATA_FLAG ");
                    sbQuery.Append(" ,'" + ConnInfo.UserID + "' ");
                    sbQuery.Append(" ,GETDATE() ");
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


        public static void TSHP_ACTUAL_LOT_LOG_UDE(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TSHP_ACTUAL_LOT_LOG SET  ");
                    sbQuery.Append(" DATA_FLAG = 2 ");
                    sbQuery.Append(" ,DEL_DATE = GETDATE() ");
                    sbQuery.Append(" ,DEL_EMP = '" + ConnInfo.UserID + "' ");
                    sbQuery.Append("  WHERE ACTUAL_ID = @ACTUAL_ID ");
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
    }




    public class TSHP_ACTUAL_LOT_LOG_QUERY
    {




        //실적 기본쿼리
        public static DataTable TSHP_ACTUAL_LOT_LOG_QUERY1(DataTable dtParam, BizExecute.BizExecute bizExecute)
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
                    sbQuery.Append(" ,SCOMMENT ");
                    sbQuery.Append(" ,MAT_CODE ");
                    sbQuery.Append(" ,MAT_OUT ");
                    sbQuery.Append(" ,ACT_OUT ");
                    sbQuery.Append(" ,OUT_MAT_CODE ");
                    sbQuery.Append(" ,LOT_ID ");
                    sbQuery.Append(" ,OUT_QTY ");
                    sbQuery.Append(" ,REG_DATE ");
                    sbQuery.Append(" ,REG_EMP ");
                    sbQuery.Append(" ,DEL_DATE ");
                    sbQuery.Append(" ,MDFY_EMP ");
                    sbQuery.Append("  FROM TSHP_ACTUAL_LOT_LOG  ");


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
    }
}

