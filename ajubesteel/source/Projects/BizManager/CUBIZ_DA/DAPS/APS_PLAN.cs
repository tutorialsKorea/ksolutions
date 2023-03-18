using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace DAPS
{
    public class APS_PLAN
    {
        public static DataTable APS_PLAN_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {

            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" select  "); 
                    sbQuery.Append(" AP.SCH_UID, ");
                    sbQuery.Append(" AP.VERSION_NO, ");
                    sbQuery.Append(" AP.PLT_CODE, ");
                    sbQuery.Append(" AP.PROD_CODE, ");
                    sbQuery.Append(" AP.PART_CODE, ");
                    sbQuery.Append(" AP.PROC_CODE, ");
                    sbQuery.Append(" AP.PLN_MC_CODE, ");
                    sbQuery.Append(" AP.IS_OS, ");
                    sbQuery.Append(" LM.MC_NAME, ");
                    sbQuery.Append("  ");
                    sbQuery.Append(" CASE WHEN PR.ACT_START_TIME IS NULL ");
                    sbQuery.Append(" THEN AP.PLN_START_TIME ");
                    sbQuery.Append(" ELSE PR.ACT_START_TIME ");
                    sbQuery.Append(" END AS PLN_START_TIME, ");
                    sbQuery.Append(" CASE WHEN PR.ACT_END_TIME IS NULL ");
                    sbQuery.Append(" THEN AP.PLN_END_TIME ");
                    sbQuery.Append(" ELSE PR.ACT_END_TIME ");
                    sbQuery.Append(" END AS PLN_END_TIME, ");
                    sbQuery.Append("  ");
                    sbQuery.Append(" SP.PROC_NAME, ");
                    sbQuery.Append(" SP.PROC_COLOR, ");
                    sbQuery.Append(" CASE WHEN LSP.PART_CODE IS NULL THEN LSPP.PART_NAME ");
                    sbQuery.Append(" ELSE LSP.PART_NAME ");
                    sbQuery.Append(" END AS PART_NAME ");
                    sbQuery.Append("  ");
                    sbQuery.Append(" ,PR.ACT_START_TIME ");
                    sbQuery.Append(" ,PR.ACT_END_TIME ");
                    sbQuery.Append("  ");
                    sbQuery.Append(" ,CASE WHEN PR.ACT_START_TIME IS NULL AND PR.ACT_END_TIME IS NULL ");
                    sbQuery.Append(" THEN '0' ");
                    sbQuery.Append(" WHEN PR.ACT_START_TIME IS NOT NULL AND PR.ACT_END_TIME IS NULL ");
                    sbQuery.Append(" THEN '1' ");
                    sbQuery.Append(" WHEN PR.ACT_START_TIME IS NOT NULL AND PR.ACT_END_TIME IS NOT NULL ");
                    sbQuery.Append(" THEN '2' ");
                    sbQuery.Append(" END AS WIP_STATE ");
                    sbQuery.Append("  ");
                    sbQuery.Append(" from APS_PLAN AP ");
                    sbQuery.Append(" JOIN APS_PROC PR ");
                    sbQuery.Append(" ON AP.PLT_CODE = PR.PLT_CODE ");
                    sbQuery.Append(" AND AP.PROD_CODE = PR.PROD_CODE ");
                    sbQuery.Append(" AND AP.PART_CODE = PR.PART_CODE ");
                    sbQuery.Append(" AND AP.PROC_CODE = PR.PROC_CODE ");
                    sbQuery.Append(" JOIN APS_PART PT ");
                    sbQuery.Append(" ON AP.PLT_CODE = PT.PLT_CODE ");
                    sbQuery.Append(" AND AP.PROD_CODE = PT.PROD_CODE ");
                    sbQuery.Append(" AND AP.PART_CODE = PT.PART_CODE ");
                    sbQuery.Append(" LEFT JOIN LSE_STD_PROC SP ");
                    sbQuery.Append(" ON AP.PLT_CODE = SP.PLT_CODE ");
                    sbQuery.Append(" AND AP.PROC_CODE = SP.PROC_CODE ");
                    sbQuery.Append(" LEFT JOIN LSE_STD_PART LSP ");
                    sbQuery.Append(" ON AP.PLT_CODE = LSP.PLT_CODE ");
                    sbQuery.Append(" AND AP.PART_CODE = LSP.PART_CODE ");
                    sbQuery.Append(" LEFT JOIN LSE_STD_PART LSPP ");
                    sbQuery.Append(" ON PT.PLT_CODE = LSPP.PLT_CODE ");
                    sbQuery.Append(" AND PT.PARENT_PART = LSPP.PART_CODE ");
                    sbQuery.Append(" LEFT JOIN LSE_MACHINE LM ");
                    sbQuery.Append(" ON AP.PLT_CODE = LM.PLT_CODE ");
                    sbQuery.Append(" AND AP.PLN_MC_CODE = LM.MC_CODE ");


                    sbQuery.Append(" WHERE AP.PLT_CODE = @PLT_CODE ");
                    sbQuery.Append(" AND AP.VERSION_NO = @VERSION_NO ");
                    sbQuery.Append(" ORDER BY AP.PLN_END_TIME ASC");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "VERSION_NO")) isHasColumn = false;

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
    }

    public class APS_PLAN_QUERY
    {
        public static DataTable APS_PLAN_QUERY1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    
                    sbQuery.Append(" SELECT ");
                    sbQuery.Append(" TOP 1 VERSION_NO ");
                    sbQuery.Append(" FROM APS_PLAN ");
                    foreach (DataRow row in dtParam.Rows)
                    {

                        StringBuilder sbWhere = new StringBuilder(" WHERE PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(" GROUP BY VERSION_NO ");
                        sbWhere.Append(" ORDER BY VERSION_NO DESC");

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

        public static DataTable APS_PLAN_QUERY2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" select  ");
                    sbQuery.Append(" AP.PLN_MC_CODE AS MC_CODE, ");
                    sbQuery.Append(" LM.MC_NAME, ");
                    sbQuery.Append(" LM.MC_SEQ ");
                    sbQuery.Append(" from APS_PLAN AP ");
                    sbQuery.Append(" JOIN LSE_MACHINE LM ");
                    sbQuery.Append(" ON AP.PLT_CODE = LM.PLT_CODE ");
                    sbQuery.Append(" AND AP.PLN_MC_CODE = LM.MC_CODE ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        StringBuilder sbWhere = new StringBuilder(" WHERE AP.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@SCH_UID", "AP.SCH_UID = @SCH_UID"));
                        sbWhere.Append(UTIL.GetWhere(row, "@MC_GRP", "LM.MC_GROUP = @MC_GRP"));
                        //sbWhere.Append(UTIL.GetWhere(row, "@PROD_CODE", "AP.PROD_CODE = @PROD_CODE"));
                        //sbWhere.Append(UTIL.GetWhere(row, "@PART_CODE", "AP.PART_CODE = @PART_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_CODE", "AP.PROD_CODE LIKE '%' + @PROD_CODE + '%'"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_CODE", "AP.PART_CODE LIKE '%' + @PART_CODE + '%'"));

                        sbWhere.Append(" GROUP BY AP.PLN_MC_CODE, LM.MC_NAME, LM.MC_SEQ ");
                        sbWhere.Append(" ORDER BY LM.MC_SEQ ASC ");

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

        public static DataTable APS_PLAN_QUERY3(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();


                    sbQuery.Append(" select  "); 
                    sbQuery.Append(" AP.SCH_UID, ");
                    sbQuery.Append(" AP.VERSION_NO, ");
                    sbQuery.Append(" AP.PLT_CODE, ");
                    sbQuery.Append(" AP.PROD_CODE, ");
                    sbQuery.Append(" AP.ORIGIN_PART_CODE AS PART_CODE, ");
                    sbQuery.Append(" AP.PROC_CODE, ");
                    sbQuery.Append(" AP.PLN_MC_CODE, ");
                    sbQuery.Append(" AP.PLN_QTY, ");
                    sbQuery.Append(" TW.ACT_QTY, ");
                    sbQuery.Append(" AP.IS_OS, ");
                    sbQuery.Append(" LM.MC_NAME, ");
                    sbQuery.Append("  ");
                    //sbQuery.Append(" CASE WHEN TW.WO_FLAG IN('0', '1') AND(ISNULL(TW.PLN_START_TIME, '000101010000') = '000101010000' OR ISNULL(TW.PLN_END_TIME, '000101010000') = '000101010000')");
                    //sbQuery.Append("        THEN '미수립'");
                    //sbQuery.Append("        ELSE '수립' END IS_PLAN,");
                    sbQuery.Append(" CASE WHEN PR.ACT_START_TIME IS NULL ");
                    sbQuery.Append(" THEN AP.PLN_START_TIME ");
                    sbQuery.Append(" ELSE PR.ACT_START_TIME ");
                    sbQuery.Append(" END AS PLN_START_TIME, ");
                    sbQuery.Append(" CASE WHEN TW.WO_FLAG <> '2' AND PR.ACT_START_TIME IS NOT NULL AND PR.ACT_END_TIME IS NOT NULL ");
                    sbQuery.Append(" THEN PR.ACT_END_TIME ");
                    sbQuery.Append(" ELSE AP.PLN_END_TIME ");
                    sbQuery.Append(" END AS PLN_END_TIME, ");
                    sbQuery.Append("  ");
                    sbQuery.Append(" SP.PROC_NAME, ");
                    sbQuery.Append(" SP.PROC_COLOR, ");
                    sbQuery.Append(" CASE WHEN LSP.PART_CODE IS NULL THEN LSPP.PART_NAME ");
                    sbQuery.Append(" ELSE LSP.PART_NAME ");
                    sbQuery.Append(" END AS PART_NAME ");
                    sbQuery.Append("  ");
                    sbQuery.Append(" ,PR.ACT_START_TIME ");
                    sbQuery.Append(" ,PR.ACT_END_TIME ");
                    sbQuery.Append("  ");
                    //sbQuery.Append(" ,CASE WHEN PR.ACT_START_TIME IS NULL AND PR.ACT_END_TIME IS NULL ");
                    ////sbQuery.Append(" THEN '0' ");
                    //sbQuery.Append(" THEN CASE WHEN PR.PLN_IS_FIXED = 1 THEN '3' ELSE '0'  END ");
                    //sbQuery.Append(" WHEN PR.ACT_START_TIME IS NOT NULL AND PR.ACT_END_TIME IS NULL ");
                    //sbQuery.Append(" THEN '1' ");
                    //sbQuery.Append(" WHEN PR.ACT_START_TIME IS NOT NULL AND PR.ACT_END_TIME IS NOT NULL ");
                    //sbQuery.Append(" THEN '2' ");
                    //sbQuery.Append(" END AS WIP_STATE, ");
                    sbQuery.Append(" ,TW.WO_FLAG AS WIP_STATE, ");
                    sbQuery.Append(" PR.TOTAL_TAT, ");
                    sbQuery.Append(" (PR.TOTAL_TAT * 1.0 / 60 / 24) AS TOTAL_TAT_DAY, ");
                    sbQuery.Append("  ");
                    sbQuery.Append(" TP.ITEM_CODE, ");
                    sbQuery.Append(" TW.IS_FIX, ");

                    sbQuery.Append(" TP.PROD_STATE, ");
                    sbQuery.Append(" TI.CVND_CODE, ");
                    sbQuery.Append(" TP.DUE_DATE, ");
                    sbQuery.Append(" ISNULL(TP.TARGET_DUE_DATE, PARENT_TP.TARGET_DUE_DATE) as TARGET_DUE_DATE,  ");
                    sbQuery.Append(" VEN.VEN_CHARGE_EMP ");

                    sbQuery.Append(" from APS_PLAN AP ");
                    sbQuery.Append(" JOIN APS_PROC PR ");
                    sbQuery.Append(" ON AP.PLT_CODE = PR.PLT_CODE ");
                    sbQuery.Append(" AND AP.PROD_CODE = PR.PROD_CODE ");
                    sbQuery.Append(" AND AP.PART_CODE = PR.PART_CODE ");
                    sbQuery.Append(" AND AP.PROC_CODE = PR.PROC_CODE ");
                    sbQuery.Append(" JOIN APS_PART PT ");
                    sbQuery.Append(" ON AP.PLT_CODE = PT.PLT_CODE ");
                    sbQuery.Append(" AND AP.PROD_CODE = PT.PROD_CODE ");
                    sbQuery.Append(" AND AP.PART_CODE = PT.PART_CODE ");
                    sbQuery.Append(" LEFT JOIN LSE_STD_PROC SP ");
                    sbQuery.Append(" ON AP.PLT_CODE = SP.PLT_CODE ");
                    sbQuery.Append(" AND AP.PROC_CODE = SP.PROC_CODE ");
                    sbQuery.Append(" LEFT JOIN LSE_STD_PART LSP ");
                    sbQuery.Append(" ON AP.PLT_CODE = LSP.PLT_CODE ");
                    sbQuery.Append(" AND AP.PART_CODE = LSP.PART_CODE ");
                    sbQuery.Append(" LEFT JOIN LSE_STD_PART LSPP ");
                    sbQuery.Append(" ON PT.PLT_CODE = LSPP.PLT_CODE ");
                    sbQuery.Append(" AND PT.PARENT_PART = LSPP.PART_CODE ");
                    sbQuery.Append(" LEFT JOIN LSE_MACHINE LM ");
                    sbQuery.Append(" ON AP.PLT_CODE = LM.PLT_CODE ");
                    sbQuery.Append(" AND AP.PLN_MC_CODE = LM.MC_CODE ");
                    sbQuery.Append(" JOIN TORD_PRODUCT TP   ");
                    sbQuery.Append(" ON PT.PLT_CODE = TP.PLT_CODE   ");
                    sbQuery.Append(" AND PT.PROD_CODE = TP.PROD_CODE   ");
                    sbQuery.Append(" AND PT.ORIGIN_PART_CODE = TP.PART_CODE   ");
                    sbQuery.Append(" JOIN TORD_ITEM TI   ");
                    sbQuery.Append(" ON TP.PLT_CODE = TI.PLT_CODE   ");
                    sbQuery.Append(" AND TP.ITEM_CODE = TI.ITEM_CODE   ");
                    sbQuery.Append(" JOIN TSHP_WORKORDER TW   ");
                    sbQuery.Append(" ON AP.PLT_CODE = TW.PLT_CODE   ");
                    sbQuery.Append(" AND AP.PROD_CODE = TW.PROD_CODE   ");
                    sbQuery.Append(" AND AP.ORIGIN_PART_CODE = TW.PART_CODE   ");
                    sbQuery.Append(" AND AP.PROC_CODE = TW.PROC_CODE   ");
                    sbQuery.Append(" LEFT JOIN TSTD_VENDOR VEN   ");
                    sbQuery.Append(" ON TI.PLT_CODE = VEN.PLT_CODE   ");
                    sbQuery.Append(" AND TI.CVND_CODE = VEN.VEN_CODE   ");
                    sbQuery.Append(" LEFT JOIN TORD_PRODUCT PARENT_TP   ");
                    sbQuery.Append(" ON TP.PLT_CODE = PARENT_TP.PLT_CODE   ");
                    sbQuery.Append(" AND TP.PROD_CODE = PARENT_TP.PROD_CODE   ");
                    sbQuery.Append(" AND TP.PARENT_PART = TP.PART_CODE   ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        StringBuilder sbWhere = new StringBuilder(" WHERE AP.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@SCH_UID", "AP.SCH_UID = @SCH_UID"));
                        //sbWhere.Append(UTIL.GetWhere(row, "@PROD_CODE", "AP.PROD_CODE = @PROD_CODE"));
                        //sbWhere.Append(UTIL.GetWhere(row, "@PART_CODE", "AP.PART_CODE = @PART_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_CODE", "AP.PROD_CODE LIKE '%' + @PROD_CODE + '%'"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_CODE", "AP.ORIGIN_PART_CODE LIKE '%' + @PART_CODE + '%'"));

                        sbWhere.Append(" ORDER BY AP.PLN_END_TIME ASC");

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

        public static DataTable APS_PLAN_QUERY4(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT   ");
                    sbQuery.Append(" AP.PROD_CODE,  ");
                    sbQuery.Append(" AP.ORIGIN_PART_CODE AS PART_CODE, ");
                    sbQuery.Append(" TP.PROD_NAME AS PART_NAME, ");
                    sbQuery.Append(" TV.VEN_NAME ");
                    sbQuery.Append(" FROM APS_PLAN AP  ");
                    sbQuery.Append(" LEFT JOIN TORD_PRODUCT TP ");
                    sbQuery.Append(" ON AP.PLT_CODE = TP.PLT_CODE ");
                    sbQuery.Append(" AND AP.PROD_CODE = TP.PROD_CODE ");
                    sbQuery.Append(" AND AP.ORIGIN_PART_CODE = TP.PART_CODE ");
                    sbQuery.Append(" LEFT JOIN TORD_ITEM TI ");
                    sbQuery.Append(" ON TP.PLT_CODE = TI.PLT_CODE ");
                    sbQuery.Append(" AND TP.ITEM_CODE = TI.ITEM_CODE ");
                    sbQuery.Append(" LEFT JOIN TSTD_VENDOR TV ");
                    sbQuery.Append(" ON TI.PLT_CODE = TV.PLT_CODE ");
                    sbQuery.Append(" AND TI.CVND_CODE = TV.VEN_CODE ");
                    sbQuery.Append(" JOIN LSE_MACHINE LM  ");
                    sbQuery.Append(" ON AP.PLT_CODE = LM.PLT_CODE  ");
                    sbQuery.Append(" AND AP.PLN_MC_CODE = LM.MC_CODE  ");


                    foreach (DataRow row in dtParam.Rows)
                    {

                        StringBuilder sbWhere = new StringBuilder(" WHERE AP.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@SCH_UID", "AP.SCH_UID = @SCH_UID"));
                        sbWhere.Append(UTIL.GetWhere(row, "@MC_GRP", "LM.MC_GROUP = @MC_GRP"));
                        //sbWhere.Append(UTIL.GetWhere(row, "@PROD_CODE", "AP.PROD_CODE = @PROD_CODE"));
                        //sbWhere.Append(UTIL.GetWhere(row, "@PART_CODE", "AP.PART_CODE = @PART_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_CODE", "AP.PROD_CODE LIKE '%' + @PROD_CODE + '%'"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_CODE", "AP.ORIGIN_PART_CODE LIKE '%' + @PART_CODE + '%'"));

                        sbWhere.Append(" GROUP BY AP.PROD_CODE, AP.ORIGIN_PART_CODE, TP.PROD_NAME, TV.VEN_NAME ");

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
