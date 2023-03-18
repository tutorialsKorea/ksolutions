using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace DAPS
{
    public class APS_PART
    {
        public static void APS_PART_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" INSERT INTO APS_PART");
                    sbQuery.Append("(");
                    sbQuery.Append(" PLT_CODE");
                    sbQuery.Append(" , PROD_CODE ");
                    sbQuery.Append(" , PART_CODE ");
                    sbQuery.Append(" , PARENT_PART");
                    sbQuery.Append(" , ORIGIN_PART_CODE ");
                    sbQuery.Append(" , BOM_QTY");
                    sbQuery.Append(" , BOM_PLN_QTY");
                    sbQuery.Append(" , PLN_QTY");
                    //sbQuery.Append(" , STOCK_USE ");
                    sbQuery.Append(" , LOAD_FLAG");
                    sbQuery.Append(")");
                    sbQuery.Append(" VALUES");
                    sbQuery.Append("(");
                    sbQuery.Append(" @PLT_CODE");
                    sbQuery.Append(" , @PROD_CODE ");
                    sbQuery.Append(" , @PART_CODE ");
                    sbQuery.Append(" , @PARENT_PART");
                    sbQuery.Append(" , @ORIGIN_PART_CODE ");
                    sbQuery.Append(" , @BOM_QTY");
                    sbQuery.Append(" , @BOM_PLN_QTY");
                    sbQuery.Append(" , @PLN_QTY");
                    //sbQuery.Append(" , @STOCK_USE ");
                    sbQuery.Append(" , 0");
                    sbQuery.Append(")");

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

        public static void APS_PART_DEL(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {

                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append("DELETE FROM APS_PART");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND PROD_CODE = @PROD_CODE");
                    //sbQuery.Append(" AND PART_CODE = @PART_CODE");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PROD_CODE")) isHasColumn = false;
                        //if (!UTIL.ValidColumn(row, "PART_CODE")) isHasColumn = false;

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

        public static void APS_PART_UPD(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE  APS_PROC SET");
                    //sbQuery.Append(" PROC_SEQ = @PROC_SEQ");
                    sbQuery.Append(" TOTAL_TAT = @TOTAL_TAT");
                    sbQuery.Append(" , RUN_TAT = @RUN_TAT");
                    sbQuery.Append(" , IS_OS = @IS_OS");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND PROD_CODE = @PROD_CODE");
                    sbQuery.Append(" AND PART_CODE = @PART_CODE");
                    sbQuery.Append(" AND PROC_CODE = @PROC_CODE");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PROD_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PART_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PROC_CODE")) isHasColumn = false;

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

        /// <summary>
        /// PRESEET UPDATE
        /// </summary>
        /// <param name="dtParam"></param>
        /// <param name="bizExecute"></param>
        public static void APS_PART_UPD2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE  [smartaps_sungwon]..PRESET_INFO SET");
                    sbQuery.Append(" SEQUENCE = @SEQUENCE");
                    sbQuery.Append(" , IS_USE = @IS_USE");
                    sbQuery.Append(" WHERE FACTOR_ID = @FACTOR_ID");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "FACTOR_ID")) isHasColumn = false;

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


    public class APS_PART_QUERY
    {
        public static DataTable APS_PART_QUERY1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT ");
                    sbQuery.Append(" TP.ITEM_CODE, ");
                    sbQuery.Append(" TP.PROD_CODE, ");
                    sbQuery.Append(" TP.PROD_NAME, ");
                    sbQuery.Append(" TP.ORD_DATE, ");
                    sbQuery.Append(" TP.INDUE_DATE, ");
                    sbQuery.Append(" TP.DUE_DATE, ");
                    sbQuery.Append(" TP.PROD_STATE, ");
                    sbQuery.Append("  ");
                    sbQuery.Append(" AP.PROD_CODE, ");
                    sbQuery.Append(" AP.PART_CODE, ");
                    sbQuery.Append(" DM.DEMAND_QTY, ");
                    sbQuery.Append(" DM.PRIORITY, ");
                    sbQuery.Append(" TI.CVND_CODE, ");
                    sbQuery.Append(" ISNULL((SELECT MAX(ISNULL(WO.IS_VALIDATE,1)) FROM TSHP_WORKORDER WO WHERE WO.PLT_CODE = AP.PLT_CODE AND WO.PROD_CODE = AP.PROD_CODE AND WO.PART_CODE = AP.PART_CODE AND WO.DATA_FLAG = 0),1) AS IS_VALIDATE ");
                    sbQuery.Append(" FROM APS_PART AP ");
                    sbQuery.Append(" JOIN [smartaps_sungwon]..DEMAND DM ");
                    sbQuery.Append(" ON AP.PROD_CODE + '|' + PART_CODE = DM.PRODUCT_ID ");
                    sbQuery.Append(" JOIN TORD_PRODUCT TP ");
                    sbQuery.Append(" ON AP.PLT_CODE = TP.PLT_CODE ");
                    sbQuery.Append(" AND AP.PROD_CODE = TP.PROD_CODE ");
                    sbQuery.Append(" AND AP.PART_CODE = TP.PART_CODE ");
                    sbQuery.Append(" JOIN TORD_ITEM TI ");
                    sbQuery.Append(" ON TP.PLT_CODE = TI.PLT_CODE ");
                    sbQuery.Append(" AND TP.ITEM_CODE = TI.ITEM_CODE ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE AP.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

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
        public static DataTable APS_PART_QUERY2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT   ");
                    sbQuery.Append(" TP.ITEM_CODE,   ");
                    sbQuery.Append(" TP.PROD_NAME,  ");
                    sbQuery.Append(" AP.PROD_CODE,   ");
                    sbQuery.Append(" AP.PART_CODE,   ");
                    sbQuery.Append(" DM.STEP_ID,   ");
                    sbQuery.Append(" DM.UNIT_QTY,  ");
                    sbQuery.Append(" DM.EQP_ID,  ");
                    sbQuery.Append(" DM.STATE,  ");
                    sbQuery.Append(" DM.OUT_QTY,  ");
                    sbQuery.Append(" LM.MC_NAME, ");
                    sbQuery.Append(" TI.CVND_CODE, ");
                    sbQuery.Append(" TW.ACT_START_TIME, ");
                    sbQuery.Append(" TW.ACT_END_TIME ");
                    //sbQuery.Append(" PR.PLN_IS_FIXED ");
                    sbQuery.Append(" FROM APS_PART AP   ");
                    sbQuery.Append(" JOIN [smartaps_sungwon]..WIP DM   ");
                    sbQuery.Append(" ON AP.PROD_CODE + '|' + AP.PART_CODE = DM.PRODUCT_ID   ");
                    sbQuery.Append(" JOIN TORD_PRODUCT TP   ");
                    sbQuery.Append(" ON AP.PLT_CODE = TP.PLT_CODE   ");
                    sbQuery.Append(" AND AP.PROD_CODE = TP.PROD_CODE   ");
                    sbQuery.Append(" AND AP.PART_CODE = TP.PART_CODE   ");
                    sbQuery.Append(" LEFT JOIN LSE_MACHINE LM  ");
                    sbQuery.Append(" ON DM.EQP_ID = LM.MC_CODE ");
                    sbQuery.Append(" JOIN TORD_ITEM TI ");
                    sbQuery.Append(" ON TP.PLT_CODE = TI.PLT_CODE ");
                    sbQuery.Append(" AND TP.ITEM_CODE = TI.ITEM_CODE ");
                    sbQuery.Append(" LEFT JOIN TSHP_WORKORDER TW ");
                    sbQuery.Append(" ON TP.PLT_CODE = TW.PLT_CODE ");
                    sbQuery.Append(" AND TP.PROD_CODE = TW.PROD_CODE ");
                    sbQuery.Append(" AND TP.PART_CODE = TW.PART_CODE ");
                    sbQuery.Append(" AND DM.STEP_ID = TW.PROC_CODE ");
                    //sbQuery.Append(" JOIN APS_PROC PR  ");
                    //sbQuery.Append(" ON DM.PRODUCT_ID   = PR.PROD_CODE + '|' + PR.PART_CODE ");
                    //sbQuery.Append(" AND DM.STEP_ID = PR.PROC_CODE ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE 1 = 1 ");
                        sbWhere.Append(" order by dm.STATE asc ");

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
        public static DataTable APS_PART_QUERY3(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT ");
                    sbQuery.Append(" MAT_TYPE, ");
                    sbQuery.Append(" QTY");
                    sbQuery.Append(" from [smartaps_sungwon]..MATERIAL ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE 1=1 ");
                        sbWhere.Append(" and QTY > 0 ");
                        sbWhere.Append(" order by MAT_TYPE asc ");

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
        public static DataTable APS_PART_QUERY4(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT ");
                    sbQuery.Append(" PI.FACTOR_ID, ");
                    sbQuery.Append(" PI.SEQUENCE, ");
                    sbQuery.Append(" PI.FACTOR_DESC, ");
                    sbQuery.Append(" PI.IS_USE ");
                    sbQuery.Append(" FROM [smartaps_sungwon]..PRESET_INFO PI ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE 1=1");
                        sbWhere.Append(" ORDER BY PI.SEQUENCE ASC ");

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

        public static DataTable APS_PART_QUERY5(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT ");
                    sbQuery.Append(" MAT_TYPE, ");
                    sbQuery.Append(" QTY, ");
                    sbQuery.Append(" REPLENISH_DATE ");
                    sbQuery.Append(" from [smartaps_sungwon]..REPLENISH_PLAN ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE 1=1 ");
                        sbWhere.Append(" order by REPLENISH_DATE asc ");

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
