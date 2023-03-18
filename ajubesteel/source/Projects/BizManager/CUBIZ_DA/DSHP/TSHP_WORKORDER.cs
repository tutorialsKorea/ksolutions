using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace DSHP
{
    public class TSHP_WORKORDER
    {

        public static DataTable TSHP_WORKORDER_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("  SELECT  ");
                    sbQuery.Append("  PLT_CODE ");
                    sbQuery.Append(" ,WO_NO ");
                    sbQuery.Append(" ,PT_ID ");
                    sbQuery.Append(" ,PROD_CODE ");
                    sbQuery.Append(" ,PART_CODE ");
                    sbQuery.Append(" ,PART_ID ");
                    sbQuery.Append(" ,PART_NUM ");
                    sbQuery.Append(" ,PROC_CODE ");
                    sbQuery.Append(" ,PROC_ID ");
                    sbQuery.Append(" ,MC_CODE ");
                    sbQuery.Append(" ,EMP_CODE ");
                    sbQuery.Append(" ,PLN_PROC_TIME ");
                    sbQuery.Append(" ,PLN_PROC_SELF_TIME ");
                    sbQuery.Append(" ,PLN_PROC_MAN_TIME ");
                    sbQuery.Append(" ,WORK_CODE ");
                    sbQuery.Append(" ,PART_QTY ");
                    sbQuery.Append(" ,PLN_START_TIME ");
                    sbQuery.Append(" ,PLN_END_TIME ");
                    sbQuery.Append(" ,WORK_SCOMMENT ");
                    sbQuery.Append(" ,UPD_SCOMMENT ");
                    sbQuery.Append(" ,SCOMMENT ");
                    sbQuery.Append(" ,CAUTION ");
                    sbQuery.Append(" ,WO_FLAG ");
                    sbQuery.Append(" ,ACT_START_TIME ");
                    sbQuery.Append(" ,ACT_END_TIME ");
                    sbQuery.Append(" ,ACT_MC_TIME ");
                    sbQuery.Append(" ,ACT_MAN_TIME ");
                    sbQuery.Append(" ,ACT_PRE_TIME ");
                    sbQuery.Append(" ,ACT_QTY ");
                    sbQuery.Append(" ,FNS_QTY ");
                    sbQuery.Append(" ,NG_QTY ");
                    sbQuery.Append(" ,WO_TYPE ");
                    sbQuery.Append(" ,JOB_PRIORITY ");
                    sbQuery.Append(" ,PRE_CAM ");
                    sbQuery.Append(" ,PRE_MAT ");
                    sbQuery.Append(" ,PRE_PGM ");
                    sbQuery.Append(" ,PRE_TOOL ");
                    sbQuery.Append(" ,PGM_TIME ");
                    sbQuery.Append(" ,O_WO_NO ");
                    sbQuery.Append(" ,SEQ ");
                    sbQuery.Append(" ,ACT_INPUT_TYPE ");
                    sbQuery.Append(" ,PLN_WORK_DATE ");
                    sbQuery.Append(" ,STD_PLN_START_TIME ");
                    sbQuery.Append(" ,STD_PLN_END_TIME ");
                    sbQuery.Append(" ,NG_ID ");
                    sbQuery.Append(" ,PUR_STAT ");
                    sbQuery.Append(" ,OS_VND ");
                    sbQuery.Append(" ,REG_DATE ");
                    sbQuery.Append(" ,REG_EMP ");
                    sbQuery.Append(" ,MDFY_DATE ");
                    sbQuery.Append(" ,MDFY_EMP ");
                    sbQuery.Append(" ,DEL_DATE ");
                    sbQuery.Append(" ,DEL_EMP ");
                    sbQuery.Append(" ,DATA_FLAG ");
                    sbQuery.Append(" ,WP_NO ");
                    sbQuery.Append(" ,IS_LAST ");
                    sbQuery.Append(" ,PROC_SEQ ");
                    sbQuery.Append(" ,IS_OS ");
                    sbQuery.Append(" ,PLN_STD_TIME ");
                    sbQuery.Append(" ,IS_SAVE_EACH_ROW ");
                    sbQuery.Append(" ,IS_VALIDATE ");
                    sbQuery.Append(" ,IS_SAMPLING ");
                    sbQuery.Append(" ,SAMPLING_QTY ");
                    sbQuery.Append(" ,INS_FLAG ");
                    sbQuery.Append(" ,ACT_EMP_CODE ");
                    sbQuery.Append(" ,ACT_MC_CODE ");
                    sbQuery.Append(" ,IS_FIX ");
                    sbQuery.Append(" ,IS_YPGO ");
                    sbQuery.Append(" ,MC_GROUP ");
                    sbQuery.Append("  FROM TSHP_WORKORDER  ");
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

        public static DataTable TSHP_WORKORDER_SER1_1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("  SELECT  ");
                    sbQuery.Append("  PLT_CODE ");
                    sbQuery.Append(" ,WO_NO ");
                    sbQuery.Append(" ,PT_ID ");
                    sbQuery.Append(" ,PROD_CODE ");
                    sbQuery.Append(" ,PART_CODE ");
                    sbQuery.Append(" ,PART_ID ");
                    sbQuery.Append(" ,PART_NUM ");
                    sbQuery.Append(" ,PROC_CODE ");
                    sbQuery.Append(" ,PROC_ID ");
                    sbQuery.Append(" ,MC_CODE ");
                    sbQuery.Append(" ,EMP_CODE ");
                    sbQuery.Append(" ,PLN_PROC_TIME ");
                    sbQuery.Append(" ,PLN_PROC_SELF_TIME ");
                    sbQuery.Append(" ,PLN_PROC_MAN_TIME ");
                    sbQuery.Append(" ,WORK_CODE ");
                    sbQuery.Append(" ,PART_QTY ");
                    sbQuery.Append(" ,PLN_START_TIME ");
                    sbQuery.Append(" ,PLN_END_TIME ");
                    sbQuery.Append(" ,WORK_SCOMMENT ");
                    sbQuery.Append(" ,UPD_SCOMMENT ");
                    sbQuery.Append(" ,SCOMMENT ");
                    sbQuery.Append(" ,CAUTION ");
                    sbQuery.Append(" ,WO_FLAG ");
                    sbQuery.Append(" ,ACT_START_TIME ");
                    sbQuery.Append(" ,ACT_END_TIME ");
                    sbQuery.Append(" ,ACT_MC_TIME ");
                    sbQuery.Append(" ,ACT_MAN_TIME ");
                    sbQuery.Append(" ,ACT_PRE_TIME ");
                    sbQuery.Append(" ,ACT_QTY ");
                    sbQuery.Append(" ,FNS_QTY ");
                    sbQuery.Append(" ,NG_QTY ");
                    sbQuery.Append(" ,WO_TYPE ");
                    sbQuery.Append(" ,JOB_PRIORITY ");
                    sbQuery.Append(" ,PRE_CAM ");
                    sbQuery.Append(" ,PRE_MAT ");
                    sbQuery.Append(" ,PRE_PGM ");
                    sbQuery.Append(" ,PRE_TOOL ");
                    sbQuery.Append(" ,PGM_TIME ");
                    sbQuery.Append(" ,O_WO_NO ");
                    sbQuery.Append(" ,SEQ ");
                    sbQuery.Append(" ,ACT_INPUT_TYPE ");
                    sbQuery.Append(" ,PLN_WORK_DATE ");
                    sbQuery.Append(" ,STD_PLN_START_TIME ");
                    sbQuery.Append(" ,STD_PLN_END_TIME ");
                    sbQuery.Append(" ,NG_ID ");
                    sbQuery.Append(" ,PUR_STAT ");
                    sbQuery.Append(" ,OS_VND ");
                    sbQuery.Append(" ,REG_DATE ");
                    sbQuery.Append(" ,REG_EMP ");
                    sbQuery.Append(" ,MDFY_DATE ");
                    sbQuery.Append(" ,MDFY_EMP ");
                    sbQuery.Append(" ,DEL_DATE ");
                    sbQuery.Append(" ,DEL_EMP ");
                    sbQuery.Append(" ,DATA_FLAG ");
                    sbQuery.Append(" ,WP_NO ");
                    sbQuery.Append(" ,IS_LAST ");
                    sbQuery.Append(" ,PROC_SEQ ");
                    sbQuery.Append(" ,IS_OS ");
                    sbQuery.Append(" ,PLN_STD_TIME ");
                    sbQuery.Append(" ,IS_SAVE_EACH_ROW ");
                    sbQuery.Append(" ,IS_VALIDATE ");
                    sbQuery.Append(" ,IS_SAMPLING ");
                    sbQuery.Append(" ,SAMPLING_QTY ");
                    sbQuery.Append(" ,INS_FLAG ");
                    sbQuery.Append(" ,ACT_EMP_CODE ");
                    sbQuery.Append(" ,ACT_MC_CODE ");
                    sbQuery.Append(" ,IS_FIX ");
                    sbQuery.Append(" ,IS_YPGO ");
                    sbQuery.Append(" ,MC_GROUP ");
                    sbQuery.Append("  FROM TSHP_WORKORDER  ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("  AND PT_ID = @PT_ID  ");
                    sbQuery.Append("  AND WO_FLAG IN ('0','1') ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PT_ID")) isHasColumn = false;

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



        public static DataTable TSHP_WORKORDER_SER2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("  SELECT  ");
                    sbQuery.Append("  PLT_CODE ");
                    sbQuery.Append(" ,WO_NO ");
                    sbQuery.Append(" ,PT_ID ");
                    sbQuery.Append(" ,PROD_CODE ");
                    sbQuery.Append(" ,PART_CODE ");
                    sbQuery.Append(" ,PART_ID ");
                    sbQuery.Append(" ,PART_NUM ");
                    sbQuery.Append(" ,PROC_CODE ");
                    sbQuery.Append(" ,PROC_ID ");
                    sbQuery.Append(" ,MC_CODE ");
                    sbQuery.Append(" ,EMP_CODE ");
                    sbQuery.Append(" ,PLN_PROC_TIME ");
                    sbQuery.Append(" ,PLN_PROC_SELF_TIME ");
                    sbQuery.Append(" ,PLN_PROC_MAN_TIME ");
                    sbQuery.Append(" ,WORK_CODE ");
                    sbQuery.Append(" ,PART_QTY ");
                    sbQuery.Append(" ,PLN_START_TIME ");
                    sbQuery.Append(" ,PLN_END_TIME ");
                    sbQuery.Append(" ,WORK_SCOMMENT ");
                    sbQuery.Append(" ,UPD_SCOMMENT ");
                    sbQuery.Append(" ,SCOMMENT ");
                    sbQuery.Append(" ,CAUTION ");
                    sbQuery.Append(" ,WO_FLAG ");
                    sbQuery.Append(" ,ACT_START_TIME ");
                    sbQuery.Append(" ,ACT_END_TIME ");
                    sbQuery.Append(" ,ACT_MC_TIME ");
                    sbQuery.Append(" ,ACT_MAN_TIME ");
                    sbQuery.Append(" ,ACT_PRE_TIME ");
                    sbQuery.Append(" ,ACT_QTY ");
                    sbQuery.Append(" ,FNS_QTY ");
                    sbQuery.Append(" ,NG_QTY ");
                    sbQuery.Append(" ,WO_TYPE ");
                    sbQuery.Append(" ,JOB_PRIORITY ");
                    sbQuery.Append(" ,PRE_CAM ");
                    sbQuery.Append(" ,PRE_MAT ");
                    sbQuery.Append(" ,PRE_PGM ");
                    sbQuery.Append(" ,PRE_TOOL ");
                    sbQuery.Append(" ,PGM_TIME ");
                    sbQuery.Append(" ,O_WO_NO ");
                    sbQuery.Append(" ,SEQ ");
                    sbQuery.Append(" ,ACT_INPUT_TYPE ");
                    sbQuery.Append(" ,PLN_WORK_DATE ");
                    sbQuery.Append(" ,STD_PLN_START_TIME ");
                    sbQuery.Append(" ,STD_PLN_END_TIME ");
                    sbQuery.Append(" ,NG_ID ");
                    sbQuery.Append(" ,PUR_STAT ");
                    sbQuery.Append(" ,OS_VND ");
                    sbQuery.Append(" ,REG_DATE ");
                    sbQuery.Append(" ,REG_EMP ");
                    sbQuery.Append(" ,MDFY_DATE ");
                    sbQuery.Append(" ,MDFY_EMP ");
                    sbQuery.Append(" ,DEL_DATE ");
                    sbQuery.Append(" ,DEL_EMP ");
                    sbQuery.Append(" ,DATA_FLAG ");
                    sbQuery.Append(" ,WP_NO ");
                    sbQuery.Append(" ,IS_LAST ");
                    sbQuery.Append(" ,PROC_SEQ ");
                    sbQuery.Append(" ,IS_OS ");
                    sbQuery.Append(" ,PLN_STD_TIME ");
                    sbQuery.Append(" ,IS_SAVE_EACH_ROW ");
                    sbQuery.Append(" ,IS_VALIDATE ");
                    sbQuery.Append(" ,IS_SAMPLING ");
                    sbQuery.Append(" ,SAMPLING_QTY ");
                    sbQuery.Append(" ,INS_FLAG ");
                    sbQuery.Append(" ,ACT_EMP_CODE ");
                    sbQuery.Append(" ,ACT_MC_CODE ");
                    sbQuery.Append(" ,IS_FIX ");
                    sbQuery.Append(" ,IS_YPGO ");
                    sbQuery.Append(" ,MC_GROUP ");
                    sbQuery.Append(" ,OLD_WO_FLAG ");
                    sbQuery.Append("  FROM TSHP_WORKORDER  ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("  AND PT_ID = @PT_ID  ");
                    sbQuery.Append("  AND PROC_CODE = @PROC_CODE  ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PT_ID")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PROC_CODE")) isHasColumn = false;

                        if (isHasColumn == true)
                        {
                            if (row["RE_WO_NO"].toStringEmpty() != "")
                            {
                                sbQuery.Append("  AND RE_WO_NO = @RE_WO_NO ");
                            }
                            else
                            {
                                sbQuery.Append("  AND RE_WO_NO IS NULL ");
                            }

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

        public static DataTable TSHP_WORKORDER_SER3(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("  SELECT  ");
                    sbQuery.Append("  PLT_CODE ");
                    sbQuery.Append(" ,WO_NO ");
                    sbQuery.Append(" ,CHAIN_WO_NO ");
                    sbQuery.Append(" ,PT_ID ");
                    sbQuery.Append(" ,PROD_CODE ");
                    sbQuery.Append(" ,PART_CODE ");
                    sbQuery.Append(" ,PART_ID ");
                    sbQuery.Append(" ,PART_NUM ");
                    sbQuery.Append(" ,PROC_CODE ");
                    sbQuery.Append(" ,PROC_ID ");
                    sbQuery.Append(" ,MC_CODE ");
                    sbQuery.Append(" ,EMP_CODE ");
                    sbQuery.Append(" ,PLN_PROC_TIME ");
                    sbQuery.Append(" ,PLN_PROC_SELF_TIME ");
                    sbQuery.Append(" ,PLN_PROC_MAN_TIME ");
                    sbQuery.Append(" ,WORK_CODE ");
                    sbQuery.Append(" ,PART_QTY ");
                    sbQuery.Append(" ,PLN_START_TIME ");
                    sbQuery.Append(" ,PLN_END_TIME ");
                    sbQuery.Append(" ,WORK_SCOMMENT ");
                    sbQuery.Append(" ,UPD_SCOMMENT ");
                    sbQuery.Append(" ,SCOMMENT ");
                    sbQuery.Append(" ,CAUTION ");
                    sbQuery.Append(" ,WO_FLAG ");
                    sbQuery.Append(" ,ACT_START_TIME ");
                    sbQuery.Append(" ,ACT_END_TIME ");
                    sbQuery.Append(" ,ACT_MC_TIME ");
                    sbQuery.Append(" ,ACT_MAN_TIME ");
                    sbQuery.Append(" ,ACT_PRE_TIME ");
                    sbQuery.Append(" ,ACT_QTY ");
                    sbQuery.Append(" ,FNS_QTY ");
                    sbQuery.Append(" ,NG_QTY ");
                    sbQuery.Append(" ,WO_TYPE ");
                    sbQuery.Append(" ,JOB_PRIORITY ");
                    sbQuery.Append(" ,PRE_CAM ");
                    sbQuery.Append(" ,PRE_MAT ");
                    sbQuery.Append(" ,PRE_PGM ");
                    sbQuery.Append(" ,PRE_TOOL ");
                    sbQuery.Append(" ,PGM_TIME ");
                    sbQuery.Append(" ,O_WO_NO ");
                    sbQuery.Append(" ,SEQ ");
                    sbQuery.Append(" ,ACT_INPUT_TYPE ");
                    sbQuery.Append(" ,PLN_WORK_DATE ");
                    sbQuery.Append(" ,STD_PLN_START_TIME ");
                    sbQuery.Append(" ,STD_PLN_END_TIME ");
                    sbQuery.Append(" ,NG_ID ");
                    sbQuery.Append(" ,PUR_STAT ");
                    sbQuery.Append(" ,OS_VND ");
                    sbQuery.Append(" ,REG_DATE ");
                    sbQuery.Append(" ,REG_EMP ");
                    sbQuery.Append(" ,MDFY_DATE ");
                    sbQuery.Append(" ,MDFY_EMP ");
                    sbQuery.Append(" ,DEL_DATE ");
                    sbQuery.Append(" ,DEL_EMP ");
                    sbQuery.Append(" ,DATA_FLAG ");
                    sbQuery.Append(" ,WP_NO ");
                    sbQuery.Append(" ,IS_LAST ");
                    sbQuery.Append(" ,PROC_SEQ ");
                    sbQuery.Append(" ,IS_OS ");
                    sbQuery.Append(" ,PLN_STD_TIME ");
                    sbQuery.Append(" ,IS_SAVE_EACH_ROW ");
                    sbQuery.Append(" ,IS_VALIDATE ");
                    sbQuery.Append(" ,IS_SAMPLING ");
                    sbQuery.Append(" ,SAMPLING_QTY ");
                    sbQuery.Append(" ,INS_FLAG ");
                    sbQuery.Append(" ,ACT_EMP_CODE ");
                    sbQuery.Append(" ,ACT_MC_CODE ");
                    sbQuery.Append(" ,IS_FIX ");
                    sbQuery.Append(" ,IS_YPGO ");
                    sbQuery.Append(" ,CAM_EMP ");
                    sbQuery.Append("  FROM TSHP_WORKORDER  ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("  AND PT_ID = @PT_ID  ");
                    sbQuery.Append("  AND DATA_FLAG = '0'  ");
                    //sbQuery.Append("  AND PROC_CODE = @PROC_CODE  ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PT_ID")) isHasColumn = false;
                        //if (!UTIL.ValidColumn(row, "PROC_CODE")) isHasColumn = false;

                        if (isHasColumn == true)
                        {
                            if (dtParam.Columns.Contains("RE_WO_NO"))
                            {
                                if (row["RE_WO_NO"].ToString() != "")
                                {
                                    sbQuery.Append("  AND RE_WO_NO = @RE_WO_NO  ");
                                }
                                else
                                {
                                    sbQuery.Append("  AND RE_WO_NO IS NULL  ");
                                }
                            }

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




        public static DataTable TSHP_WORKORDER_SER4(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT PLT_CODE ");
                    sbQuery.Append(" , WP_NO ");
                    sbQuery.Append(" , WO_NO ");
                    sbQuery.Append(" , PROD_CODE ");
                    sbQuery.Append(" , PART_CODE ");
                    sbQuery.Append(" , PART_ID ");
                    sbQuery.Append(" , PROC_CODE");
                    sbQuery.Append(" , PROC_SEQ  ");
                    sbQuery.Append(" , PROC_ID");
                    sbQuery.Append(" , PROC_CODE + ':' + MC_CODE AS MC_CODE ");
                    sbQuery.Append(" , MC_CODE + ':' + EMP_CODE AS EMP_CODE ");
                    sbQuery.Append(" , PLN_START_TIME");
                    sbQuery.Append(" , PLN_END_TIME");
                    sbQuery.Append(" , WO_FLAG ");
                    sbQuery.Append(" , WO_TYPE ");
                    sbQuery.Append(" , PART_QTY");
                    sbQuery.Append(" , PART_QTY AS PLN_QTY");
                    sbQuery.Append(" , JOB_PRIORITY");
                    //sbQuery.Append(" , WORK_SCOMMENT");
                    sbQuery.Append(" , SCOMMENT");
                    sbQuery.Append(" , IS_LAST");
                    sbQuery.Append(" , IS_FIX");
                    sbQuery.Append(" , IS_OS");
                    sbQuery.Append(" ,REG_DATE");
                    sbQuery.Append(" ,REG_EMP");
                    sbQuery.Append(" ,MDFY_DATE");
                    sbQuery.Append(" ,MDFY_EMP");
                    sbQuery.Append(" ,DATA_FLAG");
                    sbQuery.Append(" ,DEL_DATE");
                    sbQuery.Append(" ,DEL_EMP");
                    sbQuery.Append(" FROM TSHP_WORKORDER ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND PROD_CODE = @PROD_CODE");
                    sbQuery.Append(" AND WO_FLAG <> @WO_FLAG");
                    sbQuery.Append(" AND DATA_FLAG = @DATA_FLAG");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PROD_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "WO_FLAG")) isHasColumn = false;

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

        public static DataTable TSHP_WORKORDER_SER5(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT TW.PLT_CODE																					   ");
                    sbQuery.Append(" 	, TW.WO_NO																						   ");
                    sbQuery.Append(" 	, TI.CVND_CODE AS VEN_CODE																		   ");
                    sbQuery.Append(" 	, TW.PROD_CODE																					   ");
                    sbQuery.Append(" 	, TW.PART_CODE																					   ");
                    sbQuery.Append(" 	, PART.PART_NAME																				   ");
                    sbQuery.Append(" 	, TW.WO_FLAG																					   ");
                    sbQuery.Append(" 	, TW.PART_CODE +'\n' + PART.PART_NAME AS PART_CODE_NAME											   ");
                    sbQuery.Append(" 	, CONVERT(VARCHAR,TW.ACT_QTY) + '/' + CONVERT(VARCHAR,TW.PART_QTY) AS QTY_COMP_TOTAL			   ");
                    sbQuery.Append(" 	, TWP.PLN_START_TIME AS PLN_END_TIME															   ");
                    sbQuery.Append(" 	, PRO.PROC_NAME AS PRE_PROC_NAME																   ");
                    sbQuery.Append(" 	, @PROC_CODE AS PROC_CODE																   ");
                    sbQuery.Append(" 	, TWS.SCOMMENT  ");
                    sbQuery.Append(" FROM TSHP_WORKORDER TW																				   ");
                    sbQuery.Append(" 	INNER JOIN (																					   ");
                    sbQuery.Append(" 				SELECT TW.PLT_CODE																	   ");
                    sbQuery.Append(" 					, TW.PROD_CODE																	   ");
                    sbQuery.Append(" 					, TW.PART_CODE																	   ");
                    sbQuery.Append(" 					, TWP.PLN_START_TIME															   ");
                    sbQuery.Append(" 					, MAX(TW.PROC_SEQ) AS PROC_SEQ													   ");
                    sbQuery.Append(" 				FROM TSHP_WORKORDER TW																   ");
                    sbQuery.Append(" 				INNER JOIN (SELECT PLT_CODE, PROD_CODE, PART_CODE, PROC_SEQ, PROC_CODE, PLN_START_TIME ");
                    sbQuery.Append(" 						FROM TSHP_WORKORDER															   ");
                    sbQuery.Append(" 						WHERE PROC_CODE = @PROC_CODE												   ");
                    sbQuery.Append(" 						AND DATA_FLAG = 0															   ");
                    sbQuery.Append(" 						AND PROC_SEQ IS NOT NULL													   ");
                    sbQuery.Append(" 						AND ACT_START_TIME IS NULL) TWP												   ");
                    sbQuery.Append(" 					ON TW.PLT_CODE = TWP.PLT_CODE													   ");
                    sbQuery.Append(" 					AND TW.PROD_CODE = TWP.PROD_CODE												   ");
                    sbQuery.Append(" 					AND TW.PART_CODE = TWP.PART_CODE												   ");
                    sbQuery.Append(" 					AND TWP.PROC_SEQ > TW.PROC_SEQ													   ");
                    sbQuery.Append(" 				GROUP BY TW.PLT_CODE																   ");
                    sbQuery.Append(" 					, TW.PROD_CODE																	   ");
                    sbQuery.Append(" 					, TW.PART_CODE																	   ");
                    sbQuery.Append(" 					, TWP.PLN_START_TIME															   ");
                    sbQuery.Append(" 			) TWP																					   ");
                    sbQuery.Append(" 		ON TW.PLT_CODE = TWP.PLT_CODE																   ");
                    sbQuery.Append(" 		AND TW.PROD_CODE = TWP.PROD_CODE															   ");
                    sbQuery.Append(" 		AND TW.PART_CODE = TWP.PART_CODE															   ");
                    sbQuery.Append(" 		AND TW.PROC_SEQ = TWP.PROC_SEQ																   ");
                    sbQuery.Append(" 	INNER JOIN LSE_STD_PART PART																	   ");
                    sbQuery.Append(" 		ON TW.PLT_CODE = PART.PLT_CODE																   ");
                    sbQuery.Append(" 		AND TW.PART_CODE = PART.PART_CODE															   ");
                    sbQuery.Append(" 	INNER JOIN LSE_STD_PROC PRO																		   ");
                    sbQuery.Append(" 		ON TW.PLT_CODE = PRO.PLT_CODE																   ");
                    sbQuery.Append(" 		AND TW.PROC_CODE = PRO.PROC_CODE															   ");
                    sbQuery.Append(" 	INNER JOIN TORD_PRODUCT TP																		   ");
                    sbQuery.Append(" 		ON TW.PLT_CODE = TP.PLT_CODE																   ");
                    sbQuery.Append(" 		AND TW.PROD_CODE = TP.PROD_CODE																   ");
                    sbQuery.Append(" 		AND TW.PART_CODE = TP.PART_CODE																   ");
                    sbQuery.Append(" 	INNER JOIN TORD_ITEM TI																			   ");
                    sbQuery.Append(" 		ON TP.PLT_CODE = TI.PLT_CODE																   ");
                    sbQuery.Append(" 		AND TP.ITEM_CODE = TI.ITEM_CODE																   ");
                    sbQuery.Append(" 	LEFT JOIN TSHP_WORKORDER TWS																	   ");
                    sbQuery.Append(" 		ON TW.PLT_CODE = TWS.PLT_CODE																   ");
                    sbQuery.Append(" 		AND TW.PROD_CODE = TWS.PROD_CODE															   ");
                    sbQuery.Append(" 		AND TW.PART_CODE = TWS.PART_CODE															   ");
                    sbQuery.Append(" 		AND @PROC_CODE = TWS.PROC_CODE																   ");
                    sbQuery.Append(" WHERE TW.PLT_CODE = @PLT_CODE																			   ");
                    sbQuery.Append(" ORDER BY TW.WO_FLAG DESC																			   ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PROC_CODE")) isHasColumn = false;

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

      
        public static DataTable TSHP_WORKORDER_SER6(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT TW.PLT_CODE ");
                    sbQuery.Append(" 	, TW.WO_NO ");
                    sbQuery.Append(" 	, TI.CVND_CODE AS VEN_CODE ");
                    sbQuery.Append(" 	, TW.PROD_CODE ");
                    sbQuery.Append(" 	, TW.PART_CODE ");
                    sbQuery.Append(" 	, TW.WO_FLAG ");
                    sbQuery.Append(" 	, CASE TW.WO_FLAG WHEN '2' THEN '5' ELSE TW.WO_FLAG END AS WO_SEQ");
                    sbQuery.Append(" 	, TW.PROC_CODE ");
                    sbQuery.Append(" 	, PART.PART_NAME ");
                    sbQuery.Append(" 	, TW.PART_CODE +'\n' + PART.PART_NAME AS PART_CODE_NAME ");
                    sbQuery.Append(" 	, CONVERT(VARCHAR,TW.ACT_QTY) + '/' + CONVERT(VARCHAR,TW.PART_QTY) AS QTY_COMP_TOTAL ");
                    sbQuery.Append(" 	, TW.PLN_END_TIME ");
                    sbQuery.Append(" 	, TWW.PROC_NAME AS NEXT_PROC_NAME ");
                    sbQuery.Append(" 	, TWW.ACT_START_TIME AS NEXT_ACT_START_TIME ");
                    sbQuery.Append(" 	, TW.SCOMMENT ");
                    sbQuery.Append(" FROM TSHP_WORKORDER TW ");
                    sbQuery.Append(" 	INNER JOIN LSE_STD_PART PART ");
                    sbQuery.Append(" 		ON TW.PLT_CODE = PART.PLT_CODE ");
                    sbQuery.Append(" 		AND TW.PART_CODE = PART.PART_CODE ");
                    sbQuery.Append(" 	INNER JOIN TORD_PRODUCT TP ");
                    sbQuery.Append(" 		ON TW.PLT_CODE = TP.PLT_CODE ");
                    sbQuery.Append(" 		AND TW.PROD_CODE = TP.PROD_CODE ");
                    sbQuery.Append(" 		AND TW.PART_CODE = TP.PART_CODE ");
                    sbQuery.Append(" 	INNER JOIN TORD_ITEM TI ");
                    sbQuery.Append(" 		ON TP.PLT_CODE = TI.PLT_CODE ");
                    sbQuery.Append(" 		AND TP.ITEM_CODE = TI.ITEM_CODE ");
                    sbQuery.Append(" 	LEFT JOIN ( ");
                    sbQuery.Append(" 			SELECT TWM.PLT_CODE ");
                    sbQuery.Append(" 				, TWM.WO_NO ");
                    sbQuery.Append(" 				, TWM.PROD_CODE ");
                    sbQuery.Append(" 				, TWM.PART_CODE ");
                    sbQuery.Append(" 				, PRO.PROC_NAME ");
                    sbQuery.Append(" 				, TWM.ACT_START_TIME ");
                    sbQuery.Append(" 			FROM TSHP_WORKORDER TWM ");
                    sbQuery.Append(" 			INNER JOIN (SELECT TW.PLT_CODE ");
                    sbQuery.Append(" 							, TW.PROD_CODE ");
                    sbQuery.Append(" 							, TW.PART_CODE ");
                    sbQuery.Append(" 							, MIN(TW.PROC_SEQ) AS PROC_SEQ ");
                    sbQuery.Append(" 						FROM TSHP_WORKORDER TW ");
                    sbQuery.Append(" 						INNER JOIN (SELECT PLT_CODE, PROD_CODE, PART_CODE, PROC_SEQ ");
                    sbQuery.Append(" 								FROM TSHP_WORKORDER ");
                    sbQuery.Append(" 								WHERE PROC_CODE = @PROC_CODE ");
                    sbQuery.Append(" 								AND DATA_FLAG = 0 ");
                    sbQuery.Append(" 								AND PROC_SEQ IS NOT NULL) TWP ");
                    sbQuery.Append(" 							ON TW.PLT_CODE = TWP.PLT_CODE ");
                    sbQuery.Append(" 							AND TW.PROD_CODE = TWP.PROD_CODE ");
                    sbQuery.Append(" 							AND TW.PART_CODE = TWP.PART_CODE ");
                    sbQuery.Append(" 							AND TWP.PROC_SEQ < TW.PROC_SEQ ");
                    sbQuery.Append(" 						GROUP BY TW.PLT_CODE ");
                    sbQuery.Append(" 								, TW.PROD_CODE ");
                    sbQuery.Append(" 								, TW.PART_CODE) TWPM ");
                    sbQuery.Append(" 				ON TWM.PLT_CODE = TWPM.PLT_CODE ");
                    sbQuery.Append(" 				AND TWM.PROD_CODE = TWPM.PROD_CODE ");
                    sbQuery.Append(" 				AND TWM.PART_CODE = TWPM.PART_CODE ");
                    sbQuery.Append(" 				AND TWM.PROC_SEQ = TWPM.PROC_SEQ ");
                    sbQuery.Append(" 			INNER JOIN LSE_STD_PROC PRO ");
                    sbQuery.Append(" 				ON TWM.PLT_CODE = PRO.PLT_CODE ");
                    sbQuery.Append(" 				AND TWM.PROC_CODE = PRO.PROC_CODE ");
                    sbQuery.Append(" 	) TWW ");
                    sbQuery.Append(" 	ON TW.PLT_CODE = TWW.PLT_CODE ");
                    sbQuery.Append(" 	AND TW.PROD_CODE = TWW.PROD_CODE ");
                    sbQuery.Append(" 	AND TW.PART_CODE = TWW.PART_CODE ");
                    sbQuery.Append(" WHERE TW.PLT_CODE = @PLT_CODE ");
                    sbQuery.Append(" AND TW.PROC_CODE = @PROC_CODE ");
                    sbQuery.Append(" AND TW.DATA_FLAG = 0 ");
                    sbQuery.Append(" AND TW.PROC_SEQ IS NOT NULL ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PROC_CODE")) isHasColumn = false;

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
        /// 이전공정의 계획 완료시간 가져오기
        /// </summary>
        /// <param name="dtParam"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataTable TSHP_WORKORDER_SER7(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT W.PLT_CODE ");
                    sbQuery.Append(" ,W.WO_NO ");
                    sbQuery.Append(" ,W.WO_FLAG ");
                    sbQuery.Append(" ,W.PT_ID ");
                    sbQuery.Append(" ,W.PROC_ID ");
                    sbQuery.Append(" ,W.PART_ID ");
                    sbQuery.Append(" ,W.PROC_CODE");
                    sbQuery.Append(" ,W.PLN_START_TIME  ");
                    sbQuery.Append(" ,W.PLN_END_TIME  ");
                    sbQuery.Append(" ,SP.WO_TYPE ");
                    sbQuery.Append(" FROM TSHP_WORKORDER W ");
                    sbQuery.Append(" LEFT JOIN LSE_STD_PROC SP ");
                    sbQuery.Append(" ON W.PLT_CODE = SP.PLT_CODE ");
                    sbQuery.Append(" AND W.PROC_CODE = SP.PROC_CODE ");
                    sbQuery.Append(" WHERE W.PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND W.PT_ID = @PT_ID");
                    sbQuery.Append(" AND W.PROC_ID = @PROC_ID - 1");
                    sbQuery.Append(" AND W.DATA_FLAG = 0 ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PT_ID")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PROC_ID")) isHasColumn = false;

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
        /// 이전공정의 계획 완료시간 가져오기
        /// </summary>
        /// <param name="dtParam"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataTable TSHP_WORKORDER_SER8(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT W.PLT_CODE ");

                    sbQuery.Append(" ,W.PT_ID");
                    sbQuery.Append(" ,W.PROD_CODE");
                    sbQuery.Append(" ,W.PART_CODE");
                    sbQuery.Append(" ,W.PART_ID");
                    sbQuery.Append(" ,W.PART_NUM");
                    sbQuery.Append(" ,W.PROC_CODE");
                    sbQuery.Append(" ,W.PROC_ID");
                    sbQuery.Append(" ,W.MC_CODE");
                    sbQuery.Append(" ,W.MC_GROUP");
                    sbQuery.Append(" ,W.EMP_CODE");
                    sbQuery.Append(" ,W.PLN_PROC_TIME");
                    sbQuery.Append(" ,W.PLN_PROC_SELF_TIME");
                    sbQuery.Append(" ,W.PLN_PROC_MAN_TIME");
                    sbQuery.Append(" ,W.WORK_CODE");
                    sbQuery.Append(" ,W.PART_QTY");
                    sbQuery.Append(" ,W.PLN_START_TIME");
                    sbQuery.Append(" ,W.PLN_END_TIME");
                    sbQuery.Append(" ,W.WORK_SCOMMENT");
                    sbQuery.Append(" ,W.UPD_SCOMMENT");
                    sbQuery.Append(" ,W.SCOMMENT");
                    sbQuery.Append(" ,W.CAUTION");
                    sbQuery.Append(" ,W.WO_FLAG");
                    sbQuery.Append(" ,W.WO_NO ");
                    sbQuery.Append(" ,W.ACT_START_TIME");
                    sbQuery.Append(" ,W.ACT_END_TIME");
                    sbQuery.Append(" ,W.ACT_MC_TIME");
                    sbQuery.Append(" ,W.ACT_MAN_TIME");
                    sbQuery.Append(" ,W.ACT_PRE_TIME");
                    sbQuery.Append(" ,W.ACT_QTY");
                    sbQuery.Append(" ,W.FNS_QTY");
                    sbQuery.Append(" ,W.NG_QTY");
                    //sbQuery.Append(" ,W.WO_TYPE");
                    sbQuery.Append(" ,W.JOB_PRIORITY");
                    sbQuery.Append(" ,W.PRE_CAM");
                    sbQuery.Append(" ,W.PRE_MAT");
                    sbQuery.Append(" ,W.PRE_PGM");
                    sbQuery.Append(" ,W.PRE_TOOL");
                    sbQuery.Append(" ,W.PGM_TIME");
                    sbQuery.Append(" ,W.O_WO_NO");
                    sbQuery.Append(" ,W.SEQ");
                    sbQuery.Append(" ,W.ACT_INPUT_TYPE");
                    sbQuery.Append(" ,W.PLN_WORK_DATE");
                    sbQuery.Append(" ,W.STD_PLN_START_TIME");
                    sbQuery.Append(" ,W.STD_PLN_END_TIME");
                    sbQuery.Append(" ,W.NG_ID");
                    sbQuery.Append(" ,W.PUR_STAT");
                    sbQuery.Append(" ,W.OS_VND");
                    sbQuery.Append(" ,W.MDFY_DATE");
                    sbQuery.Append(" ,W.MDFY_EMP");
                    sbQuery.Append(" ,W.DATA_FLAG");
                    sbQuery.Append(" ,W.WP_NO");
                    sbQuery.Append(" ,W.IS_LAST");
                   // sbQuery.Append(" ,W.PROC_SEQ");
                    sbQuery.Append(" ,W.IS_OS");
                    sbQuery.Append(" ,W.PLN_STD_TIME");
                    sbQuery.Append(" ,W.IS_SAVE_EACH_ROW");
                    sbQuery.Append(" ,W.IS_VALIDATE");
                    sbQuery.Append(" ,W.IS_SAMPLING");
                    sbQuery.Append(" ,W.SAMPLING_QTY");
                    sbQuery.Append(" ,W.INS_FLAG");
                    sbQuery.Append(" ,W.ACT_EMP_CODE");
                    sbQuery.Append(" ,W.ACT_MC_CODE");
                    sbQuery.Append(" ,W.IS_FIX");
                    sbQuery.Append(" ,W.IS_YPGO");

                    sbQuery.Append(" ,SP.WO_TYPE ");
                    sbQuery.Append(" ,SP.PROC_SEQ ");
                    sbQuery.Append(" FROM TSHP_WORKORDER W ");
                    sbQuery.Append(" LEFT JOIN LSE_STD_PROC SP ");
                    sbQuery.Append(" ON W.PLT_CODE = SP.PLT_CODE ");
                    sbQuery.Append(" AND W.PROC_CODE = SP.PROC_CODE ");
                    sbQuery.Append(" WHERE W.PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND W.PT_ID = @PT_ID");
                    sbQuery.Append(" AND W.DATA_FLAG = 0 ");
                    sbQuery.Append(" AND SP.DATA_FLAG = 0 ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PT_ID")) isHasColumn = false;

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

        public static DataTable TSHP_WORKORDER_SER8_2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT W.PLT_CODE ");
                    sbQuery.Append(" ,W.PT_ID");
                    sbQuery.Append(" ,W.PROD_CODE");
                    sbQuery.Append(" ,W.PART_CODE");
                    sbQuery.Append(" ,W.PART_ID");
                    sbQuery.Append(" ,W.PART_NUM");
                    sbQuery.Append(" ,W.PROC_CODE");
                    sbQuery.Append(" ,W.PROC_ID");
                    sbQuery.Append(" ,W.MC_CODE");
                    sbQuery.Append(" ,W.MC_GROUP");
                    sbQuery.Append(" ,W.EMP_CODE");
                    sbQuery.Append(" ,W.PLN_PROC_TIME");
                    sbQuery.Append(" ,W.PLN_PROC_SELF_TIME");
                    sbQuery.Append(" ,W.PLN_PROC_MAN_TIME");
                    sbQuery.Append(" ,W.WORK_CODE");
                    sbQuery.Append(" ,W.PART_QTY");
                    sbQuery.Append(" ,W.PLN_START_TIME");
                    sbQuery.Append(" ,W.PLN_END_TIME");
                    sbQuery.Append(" ,W.WORK_SCOMMENT");
                    sbQuery.Append(" ,W.UPD_SCOMMENT");
                    sbQuery.Append(" ,W.SCOMMENT");
                    sbQuery.Append(" ,W.CAUTION");
                    sbQuery.Append(" ,W.WO_FLAG");
                    sbQuery.Append(" ,W.WO_NO ");
                    sbQuery.Append(" ,W.ACT_START_TIME");
                    sbQuery.Append(" ,W.ACT_END_TIME");
                    sbQuery.Append(" ,W.ACT_MC_TIME");
                    sbQuery.Append(" ,W.ACT_MAN_TIME");
                    sbQuery.Append(" ,W.ACT_PRE_TIME");
                    sbQuery.Append(" ,W.ACT_QTY");
                    sbQuery.Append(" ,W.FNS_QTY");
                    sbQuery.Append(" ,W.NG_QTY");
                    //sbQuery.Append(" ,W.WO_TYPE");
                    sbQuery.Append(" ,W.JOB_PRIORITY");
                    sbQuery.Append(" ,W.PRE_CAM");
                    sbQuery.Append(" ,W.PRE_MAT");
                    sbQuery.Append(" ,W.PRE_PGM");
                    sbQuery.Append(" ,W.PRE_TOOL");
                    sbQuery.Append(" ,W.PGM_TIME");
                    sbQuery.Append(" ,W.O_WO_NO");
                    sbQuery.Append(" ,W.SEQ");
                    sbQuery.Append(" ,W.ACT_INPUT_TYPE");
                    sbQuery.Append(" ,W.PLN_WORK_DATE");
                    sbQuery.Append(" ,W.STD_PLN_START_TIME");
                    sbQuery.Append(" ,W.STD_PLN_END_TIME");
                    sbQuery.Append(" ,W.NG_ID");
                    sbQuery.Append(" ,W.PUR_STAT");
                    sbQuery.Append(" ,W.OS_VND");
                    sbQuery.Append(" ,W.MDFY_DATE");
                    sbQuery.Append(" ,W.MDFY_EMP");
                    sbQuery.Append(" ,W.DATA_FLAG");
                    sbQuery.Append(" ,W.WP_NO");
                    sbQuery.Append(" ,W.IS_LAST");
                    // sbQuery.Append(" ,W.PROC_SEQ");
                    sbQuery.Append(" ,W.IS_OS");
                    sbQuery.Append(" ,W.PLN_STD_TIME");
                    sbQuery.Append(" ,W.IS_SAVE_EACH_ROW");
                    sbQuery.Append(" ,W.IS_VALIDATE");
                    sbQuery.Append(" ,W.IS_SAMPLING");
                    sbQuery.Append(" ,W.SAMPLING_QTY");
                    sbQuery.Append(" ,W.INS_FLAG");
                    sbQuery.Append(" ,W.ACT_EMP_CODE");
                    sbQuery.Append(" ,W.ACT_MC_CODE");
                    sbQuery.Append(" ,W.IS_FIX");
                    sbQuery.Append(" ,W.IS_YPGO");

                    sbQuery.Append(" ,SP.WO_TYPE ");
                    sbQuery.Append(" ,SP.PROC_SEQ ");
                    sbQuery.Append(" FROM TSHP_WORKORDER W ");
                    sbQuery.Append(" LEFT JOIN LSE_STD_PROC SP ");
                    sbQuery.Append(" ON W.PLT_CODE = SP.PLT_CODE ");
                    sbQuery.Append(" AND W.PROC_CODE = SP.PROC_CODE ");
                    sbQuery.Append(" WHERE W.PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND W.PT_ID = @PT_ID");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PT_ID")) isHasColumn = false;

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

        public static DataTable TSHP_WORKORDER_SER9(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("  SELECT  ");
                    sbQuery.Append("  PLT_CODE ");
                    sbQuery.Append(" ,WO_NO ");
                    sbQuery.Append(" ,PART_QTY ");
                    sbQuery.Append(" ,ACT_QTY ");
                    sbQuery.Append("  FROM TSHP_WORKORDER  ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("  AND CHAIN_WO_NO = @CHAIN_WO_NO  ");
                    sbQuery.Append("  AND PROC_CODE = @PROC_CODE  ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "CHAIN_WO_NO")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PROC_CODE")) isHasColumn = false;

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

        public static DataTable TSHP_WORKORDER_SER10(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("  SELECT  ");
                    sbQuery.Append("  PLT_CODE ");
                    sbQuery.Append(" ,WO_NO ");
                    sbQuery.Append(" ,PLN_PROC_TIME ");
                    sbQuery.Append(" ,PLN_START_TIME ");
                    sbQuery.Append(" ,PLN_END_TIME ");
                    sbQuery.Append("  FROM TSHP_WORKORDER  ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("  AND PROD_CODE = @PROD_CODE  ");
                    sbQuery.Append("  AND PROC_CODE = @PROC_CODE  ");
                    sbQuery.Append("  AND DATA_FLAG = '0'  ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PROD_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PROC_CODE")) isHasColumn = false;

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

        public static DataTable TSHP_WORKORDER_SER11(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("  SELECT  ");
                    sbQuery.Append("  PLT_CODE ");
                    sbQuery.Append(" ,WO_NO ");
                    sbQuery.Append(" ,CAM_EMP ");
                    sbQuery.Append(" ,PLN_START_TIME ");
                    sbQuery.Append(" ,PLN_END_TIME ");
                    sbQuery.Append("  FROM TSHP_WORKORDER  ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("  AND PROD_CODE = @PROD_CODE  ");
                    sbQuery.Append("  AND PART_CODE = @PART_CODE  ");
                    sbQuery.Append("  AND PROC_CODE = @PROC_CODE  ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PROD_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PART_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PROC_CODE")) isHasColumn = false;

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


        public static DataTable TSHP_WORKORDER_SER11_2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("  SELECT  ");
                    sbQuery.Append("  PLT_CODE ");
                    sbQuery.Append(" ,WO_NO ");
                    sbQuery.Append(" ,CAM_EMP ");
                    sbQuery.Append(" ,PLN_START_TIME ");
                    sbQuery.Append(" ,PLN_END_TIME ");
                    sbQuery.Append("  FROM TSHP_WORKORDER  ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("  AND PROD_CODE = @PROD_CODE  ");
                    sbQuery.Append("  AND PART_CODE = @PART_CODE  ");
                    sbQuery.Append("  AND PROC_CODE = @PROC_CODE  ");
                    sbQuery.Append("  AND PT_ID = @PT_ID  ");
                    sbQuery.Append("  AND DATA_FLAG = 0  ");
                    sbQuery.Append("  AND WO_FLAG = 4  ");
                    sbQuery.Append("  ORDER BY REG_DATE DESC  ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PROD_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PART_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PROC_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PT_ID")) isHasColumn = false;

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

        public static DataTable TSHP_WORKORDER_SER12(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("  SELECT  ");
                    sbQuery.Append("  PLT_CODE ");
                    sbQuery.Append(" ,WO_NO ");
                    sbQuery.Append("  FROM TSHP_WORKORDER  ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("  AND CHAIN_WO_NO = @CHAIN_WO_NO  ");
                    sbQuery.Append("  AND PROC_CODE = @PROC_CODE  ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "CHAIN_WO_NO")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PROC_CODE")) isHasColumn = false;

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

        public static DataTable TSHP_WORKORDER_SER13(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("  SELECT  ");
                    sbQuery.Append("  PLT_CODE ");
                    sbQuery.Append(" ,WO_NO ");
                    sbQuery.Append("  FROM TSHP_WORKORDER  ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("  AND PROD_CODE = @PROD_CODE  ");
                    sbQuery.Append("  AND PART_CODE = @PART_CODE  ");
                    sbQuery.Append("  AND PROC_CODE = @PROC_CODE  ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PROD_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PART_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PROC_CODE")) isHasColumn = false;

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

        public static DataTable TSHP_WORKORDER_SER14(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("  SELECT  ");
                    sbQuery.Append("  PLT_CODE ");
                    sbQuery.Append(" ,WO_NO ");
                    sbQuery.Append(" ,WO_FLAG ");
                    sbQuery.Append("  FROM TSHP_WORKORDER  ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("  AND PT_ID = @PT_ID  ");
                    sbQuery.Append("  AND PROC_CODE = @PROC_CODE  ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PT_ID")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PROC_CODE")) isHasColumn = false;

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

        public static DataTable TSHP_WORKORDER_SER15(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("  SELECT  ");
                    sbQuery.Append("  PLT_CODE ");
                    sbQuery.Append(" ,MAX(PART_ID) AS PART_ID ");
                    sbQuery.Append("  FROM TSHP_WORKORDER  ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("  AND PROD_CODE = @PROD_CODE  ");

                    sbQuery.Append("  GROUP BY PLT_CODE");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PROD_CODE")) isHasColumn = false;

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

        public static DataTable TSHP_WORKORDER_SER16(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("  SELECT  ");
                    sbQuery.Append("  PLT_CODE ");
                    sbQuery.Append(" ,WO_NO ");
                    sbQuery.Append(" ,CHAIN_WO_NO ");
                    sbQuery.Append(" ,PT_ID ");
                    sbQuery.Append(" ,PROD_CODE ");
                    sbQuery.Append(" ,PART_CODE ");
                    sbQuery.Append(" ,PART_ID ");
                    sbQuery.Append(" ,PART_NUM ");
                    sbQuery.Append(" ,PROC_CODE ");
                    sbQuery.Append(" ,PROC_ID ");
                    sbQuery.Append(" ,MC_CODE ");
                    sbQuery.Append(" ,EMP_CODE ");
                    sbQuery.Append(" ,PLN_PROC_TIME ");
                    sbQuery.Append(" ,PLN_PROC_SELF_TIME ");
                    sbQuery.Append(" ,PLN_PROC_MAN_TIME ");
                    sbQuery.Append(" ,WORK_CODE ");
                    sbQuery.Append(" ,PART_QTY ");
                    sbQuery.Append(" ,PLN_START_TIME ");
                    sbQuery.Append(" ,PLN_END_TIME ");
                    sbQuery.Append(" ,WORK_SCOMMENT ");
                    sbQuery.Append(" ,UPD_SCOMMENT ");
                    sbQuery.Append(" ,SCOMMENT ");
                    sbQuery.Append(" ,CAUTION ");
                    sbQuery.Append(" ,WO_FLAG ");
                    sbQuery.Append(" ,ACT_START_TIME ");
                    sbQuery.Append(" ,ACT_END_TIME ");
                    sbQuery.Append(" ,ACT_MC_TIME ");
                    sbQuery.Append(" ,ACT_MAN_TIME ");
                    sbQuery.Append(" ,ACT_PRE_TIME ");
                    sbQuery.Append(" ,ACT_QTY ");
                    sbQuery.Append(" ,FNS_QTY ");
                    sbQuery.Append(" ,NG_QTY ");
                    sbQuery.Append(" ,WO_TYPE ");
                    sbQuery.Append(" ,JOB_PRIORITY ");
                    sbQuery.Append(" ,PRE_CAM ");
                    sbQuery.Append(" ,PRE_MAT ");
                    sbQuery.Append(" ,PRE_PGM ");
                    sbQuery.Append(" ,PRE_TOOL ");
                    sbQuery.Append(" ,PGM_TIME ");
                    sbQuery.Append(" ,O_WO_NO ");
                    sbQuery.Append(" ,SEQ ");
                    sbQuery.Append(" ,ACT_INPUT_TYPE ");
                    sbQuery.Append(" ,PLN_WORK_DATE ");
                    sbQuery.Append(" ,STD_PLN_START_TIME ");
                    sbQuery.Append(" ,STD_PLN_END_TIME ");
                    sbQuery.Append(" ,NG_ID ");
                    sbQuery.Append(" ,PUR_STAT ");
                    sbQuery.Append(" ,OS_VND ");
                    sbQuery.Append(" ,REG_DATE ");
                    sbQuery.Append(" ,REG_EMP ");
                    sbQuery.Append(" ,MDFY_DATE ");
                    sbQuery.Append(" ,MDFY_EMP ");
                    sbQuery.Append(" ,DEL_DATE ");
                    sbQuery.Append(" ,DEL_EMP ");
                    sbQuery.Append(" ,DATA_FLAG ");
                    sbQuery.Append(" ,WP_NO ");
                    sbQuery.Append(" ,IS_LAST ");
                    sbQuery.Append(" ,PROC_SEQ ");
                    sbQuery.Append(" ,IS_OS ");
                    sbQuery.Append(" ,PLN_STD_TIME ");
                    sbQuery.Append(" ,IS_SAVE_EACH_ROW ");
                    sbQuery.Append(" ,IS_VALIDATE ");
                    sbQuery.Append(" ,IS_SAMPLING ");
                    sbQuery.Append(" ,SAMPLING_QTY ");
                    sbQuery.Append(" ,INS_FLAG ");
                    sbQuery.Append(" ,ACT_EMP_CODE ");
                    sbQuery.Append(" ,ACT_MC_CODE ");
                    sbQuery.Append(" ,IS_FIX ");
                    sbQuery.Append(" ,IS_YPGO ");
                    sbQuery.Append(" ,CAM_EMP ");
                    sbQuery.Append("  FROM TSHP_WORKORDER  ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("  AND PT_ID = @PT_ID  ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PT_ID")) isHasColumn = false;

                        if (isHasColumn == true)
                        {
                            if (dtParam.Columns.Contains("RE_WO_NO"))
                            {
                                if (row["RE_WO_NO"].ToString() != "")
                                {
                                    sbQuery.Append("  AND RE_WO_NO = @RE_WO_NO  ");
                                }
                                else
                                {
                                    sbQuery.Append("  AND RE_WO_NO IS NULL  ");
                                }
                            }

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

        public static DataTable TSHP_WORKORDER_SER17(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("  SELECT  ");
                    sbQuery.Append("  PLT_CODE ");
                    sbQuery.Append(" ,WO_NO ");
                    sbQuery.Append("  FROM TSHP_WORKORDER  ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("  AND PROD_CODE = @PROD_CODE  ");
                    sbQuery.Append("  AND PT_ID = @PT_ID  ");
                    //sbQuery.Append("  AND PART_CODE = @PART_CODE  ");
                    sbQuery.Append("  AND WO_FLAG IN ('2','3','4')");
                    sbQuery.Append("  AND PROC_CODE <> 'P-01'");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PROD_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PT_ID")) isHasColumn = false;
                        //if (!UTIL.ValidColumn(row, "PART_CODE")) isHasColumn = false;

                        if (isHasColumn == true)
                        {
                            if (dtParam.Columns.Contains("RE_WO_NO"))
                            {
                                if (row["RE_WO_NO"].ToString() != "")
                                {
                                    sbQuery.Append("  AND RE_WO_NO = @RE_WO_NO  ");
                                }
                                else
                                {
                                    sbQuery.Append("  AND RE_WO_NO IS NULL  ");
                                }
                            }

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

        public static DataTable TSHP_WORKORDER_SER18(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("  SELECT  ");
                    sbQuery.Append("  PLT_CODE ");
                    sbQuery.Append(" ,PROD_CODE ");
                    sbQuery.Append(" ,PT_ID ");
                    sbQuery.Append(" ,RE_WO_NO ");
                    sbQuery.Append("  FROM TSHP_WORKORDER  ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE  ");
                    //sbQuery.Append("  AND PROD_CODE = @PROD_CODE  ");
                    //sbQuery.Append("  AND PT_ID = @PT_ID  ");
                    sbQuery.Append("  AND PREV_CHAIN_WO_NO = @PREV_CHAIN_WO_NO  ");

                    sbQuery.Append("  GROUP BY PLT_CODE, PROD_CODE, PT_ID, RE_WO_NO");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PROD_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PT_ID")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PREV_CHAIN_WO_NO")) isHasColumn = false;

                        if (isHasColumn == true)
                        {
                            //if (dtParam.Columns.Contains("RE_WO_NO"))
                            //{
                            //    if (row["RE_WO_NO"].ToString() != "")
                            //    {
                            //        sbQuery.Append("  AND RE_WO_NO = @RE_WO_NO  ");
                            //    }
                            //    else
                            //    {
                            //        sbQuery.Append("  AND RE_WO_NO IS NULL  ");
                            //    }
                            //}

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

        public static DataTable TSHP_WORKORDER_SER19(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("  SELECT  ");
                    sbQuery.Append("  PLT_CODE ");
                    sbQuery.Append(" ,PROD_CODE ");
                    sbQuery.Append(" ,PT_ID ");
                    sbQuery.Append(" ,WO_NO ");
                    sbQuery.Append(" ,RE_WO_NO ");
                    sbQuery.Append("  FROM TSHP_WORKORDER  ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("  AND PROD_CODE = @PROD_CODE  ");
                    sbQuery.Append("  AND PT_ID = @PT_ID  ");
                    sbQuery.Append("  AND DATA_FLAG = '0'  ");
                    sbQuery.Append("  AND WO_FLAG IN ('0','1')  ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PROD_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PT_ID")) isHasColumn = false;

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

        public static DataTable TSHP_WORKORDER_SER20(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("  SELECT  ");
                    sbQuery.Append("  PLT_CODE ");
                    sbQuery.Append(" ,PROD_CODE ");
                    sbQuery.Append(" ,PT_ID ");
                    sbQuery.Append(" ,WO_NO ");
                    sbQuery.Append(" ,RE_WO_NO ");
                    sbQuery.Append("  FROM TSHP_WORKORDER  ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("  AND PROD_CODE = @PROD_CODE  ");
                    sbQuery.Append("  AND PT_ID = @PT_ID  ");
                    sbQuery.Append("  ORDER BY RE_WO_NO DESC  ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PROD_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PT_ID")) isHasColumn = false;

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

        public static DataTable TSHP_WORKORDER_SER21(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("  SELECT  ");
                    sbQuery.Append("  W.PLT_CODE ");
                    sbQuery.Append(" ,W.PROD_CODE ");
                    sbQuery.Append(" ,W.PT_ID ");
                    sbQuery.Append(" ,W.PART_CODE ");
                    sbQuery.Append(" ,W.PROC_CODE ");
                    sbQuery.Append(" ,W.PART_QTY ");
                    sbQuery.Append(" ,W.WO_NO ");
                    sbQuery.Append(" ,W.RE_WO_NO ");
                    sbQuery.Append(" ,W.DES_STOP ");
                    sbQuery.Append(" ,W.PLN_PROC_TIME ");
                    sbQuery.Append(" ,W.PLN_PROC_MAN_TIME ");
                    sbQuery.Append(" ,W.DATA_FLAG ");
                    sbQuery.Append("  FROM TSHP_WORKORDER W ");

                    sbQuery.Append("  LEFT JOIN LSE_STD_PROC SP ");
                    sbQuery.Append("  ON W.PLT_CODE = SP.PLT_CODE ");
                    sbQuery.Append("  AND W.PROC_CODE = SP.PROC_CODE ");

                    sbQuery.Append("  WHERE W.PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("  AND W.PROD_CODE = @PROD_CODE  ");
                    sbQuery.Append("  AND W.PT_ID = @PT_ID  ");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PROD_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PT_ID")) isHasColumn = false;

                        if (isHasColumn == true)
                        {
                            if (dtParam.Columns.Contains("RE_WO_NO"))
                            {
                                if (row["RE_WO_NO"].ToString() != "")
                                {
                                    sbQuery.Append("  AND W.RE_WO_NO = @RE_WO_NO  ");
                                }
                                else
                                {
                                    sbQuery.Append("  AND W.RE_WO_NO IS NULL  ");
                                }
                            }


                            sbQuery.Append("  ORDER BY SP.PROC_SEQ  ");

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

        public static DataTable TSHP_WORKORDER_SER22(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("  SELECT  ");
                    sbQuery.Append("  W.PLT_CODE ");
                    sbQuery.Append(" ,W.PROD_CODE ");
                    sbQuery.Append(" ,W.PT_ID ");
                    sbQuery.Append(" ,W.PART_CODE ");
                    sbQuery.Append(" ,W.PROC_CODE ");
                    sbQuery.Append(" ,W.PART_QTY ");
                    sbQuery.Append(" ,W.WO_NO ");
                    sbQuery.Append(" ,W.RE_WO_NO ");
                    sbQuery.Append(" ,W.DES_STOP ");
                    sbQuery.Append(" ,W.PLN_PROC_TIME ");
                    sbQuery.Append(" ,W.PLN_PROC_MAN_TIME ");
                    sbQuery.Append(" ,W.DATA_FLAG ");
                    sbQuery.Append("  FROM TSHP_WORKORDER W ");

                    sbQuery.Append("  WHERE W.PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("  AND W.PROD_CODE = @PROD_CODE  ");
                    sbQuery.Append("  AND W.PT_ID = @PT_ID  ");
                    sbQuery.Append("  AND W.PROC_CODE = 'P-02'  ");
                    sbQuery.Append("  AND DATA_FLAG = '0' AND WO_FLAG <> '4'  ");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PROD_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PT_ID")) isHasColumn = false;

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

        public static DataTable TSHP_WORKORDER_SER23(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("  SELECT  ");
                    sbQuery.Append("  W.PLT_CODE ");
                    sbQuery.Append(" ,W.PROD_CODE ");
                    sbQuery.Append(" ,W.PT_ID ");
                    sbQuery.Append(" ,W.PART_CODE ");
                    sbQuery.Append(" ,W.PROC_CODE ");
                    sbQuery.Append(" ,W.PART_QTY ");
                    sbQuery.Append(" ,W.WO_NO ");
                    sbQuery.Append(" ,W.RE_WO_NO ");
                    sbQuery.Append(" ,W.DES_STOP ");
                    sbQuery.Append(" ,W.PLN_PROC_TIME ");
                    sbQuery.Append(" ,W.PLN_PROC_MAN_TIME ");
                    sbQuery.Append(" ,W.DATA_FLAG ");
                    sbQuery.Append("  FROM TSHP_WORKORDER W ");

                    sbQuery.Append("  WHERE W.PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("  AND W.PROD_CODE = @PROD_CODE  ");
                    sbQuery.Append("  AND W.PT_ID = @PT_ID  ");
                    sbQuery.Append("  AND W.PROC_CODE <> 'P-01' ");
                    sbQuery.Append("  AND DATA_FLAG = '0' AND WO_FLAG IN ('2','3','4')");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PROD_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PT_ID")) isHasColumn = false;

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

        public static DataTable TSHP_WORKORDER_SER24(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("  SELECT  ");
                    sbQuery.Append("  PLT_CODE ");
                    sbQuery.Append(" ,WO_NO ");
                    sbQuery.Append(" ,PART_QTY ");
                    sbQuery.Append(" ,ACT_QTY ");
                    sbQuery.Append("  FROM TSHP_WORKORDER  ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("  AND PROD_CODE = @PROD_CODE  ");
                    sbQuery.Append("  AND PART_CODE = @PART_CODE  ");
                    sbQuery.Append("  AND PROC_CODE = @PROC_CODE  ");
                    sbQuery.Append("  AND PT_ID = @PT_ID  ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PROD_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PART_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PROC_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PT_ID")) isHasColumn = false;

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

        public static DataTable TSHP_WORKORDER_SER25(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("  SELECT  ");
                    sbQuery.Append("  PLT_CODE ");
                    sbQuery.Append(" ,WO_NO ");
                    sbQuery.Append(" ,PART_QTY ");
                    sbQuery.Append(" ,ACT_QTY ");
                    sbQuery.Append(" ,WO_FLAG ");
                    sbQuery.Append(" ,CHAIN_WO_NO ");
                    sbQuery.Append(" ,RE_WO_NO ");
                    sbQuery.Append("  FROM TSHP_WORKORDER  ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("  AND PROD_CODE = @PROD_CODE  ");
                    sbQuery.Append("  AND PART_CODE = @PART_CODE  ");
                    sbQuery.Append("  AND PROC_CODE = 'P-02'  ");
                    sbQuery.Append("  AND PT_ID = @PT_ID  ");
                    sbQuery.Append("  AND DATA_FLAG = 0  ");
                    sbQuery.Append("  ORDER BY REG_DATE DESC ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PROD_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PART_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PT_ID")) isHasColumn = false;

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

        public static DataTable TSHP_WORKORDER_SER25_2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("  SELECT  ");
                    sbQuery.Append("  PLT_CODE ");
                    sbQuery.Append(" ,WO_NO ");
                    sbQuery.Append(" ,PART_QTY ");
                    sbQuery.Append(" ,ACT_QTY ");
                    sbQuery.Append(" ,WO_FLAG ");
                    sbQuery.Append(" ,CHAIN_WO_NO ");
                    sbQuery.Append(" ,RE_WO_NO ");
                    sbQuery.Append("  FROM TSHP_WORKORDER  ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("  AND PROD_CODE = @PROD_CODE  ");
                    sbQuery.Append("  AND PART_CODE = @PART_CODE  ");
                    sbQuery.Append("  AND PROC_CODE = 'P-02'  ");
                    sbQuery.Append("  AND PT_ID = @PT_ID  ");
                    sbQuery.Append("  AND DATA_FLAG = 2  ");
                    sbQuery.Append("  AND WO_FLAG IN (0,1)  ");
                    sbQuery.Append("  ORDER BY REG_DATE DESC ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PROD_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PART_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PT_ID")) isHasColumn = false;

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

        public static DataTable TSHP_WORKORDER_SER26(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("  SELECT  ");
                    sbQuery.Append("  PLT_CODE ");
                    sbQuery.Append(" ,WO_NO ");
                    sbQuery.Append(" ,PART_QTY ");
                    sbQuery.Append(" ,ACT_QTY ");
                    sbQuery.Append(" ,WO_FLAG ");
                    sbQuery.Append(" ,CHAIN_WO_NO ");
                    sbQuery.Append(" ,RE_WO_NO ");
                    sbQuery.Append("  FROM TSHP_WORKORDER  ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("  AND PROD_CODE = @PROD_CODE  ");
                    sbQuery.Append("  AND PART_CODE = @PART_CODE  ");
                    sbQuery.Append("  AND PROC_CODE = 'P-02'  ");
                    sbQuery.Append("  AND PT_ID = @PT_ID  ");
                    sbQuery.Append("  AND WO_FLAG = 4  ");
                    sbQuery.Append("  AND DATA_FLAG = 0  ");
                    sbQuery.Append("  ORDER BY REG_DATE DESC ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PROD_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PART_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PT_ID")) isHasColumn = false;

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

        public static DataTable TSHP_WORKORDER_SER27(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("  SELECT  ");
                    sbQuery.Append("  PLT_CODE ");
                    sbQuery.Append(" ,WO_NO ");
                    sbQuery.Append(" ,PART_QTY ");
                    sbQuery.Append(" ,ACT_QTY ");
                    sbQuery.Append(" ,WO_FLAG ");
                    sbQuery.Append(" ,CHAIN_WO_NO ");
                    sbQuery.Append(" ,RE_WO_NO ");
                    sbQuery.Append(" ,DES_STOP ");
                    sbQuery.Append("  FROM TSHP_WORKORDER  ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("  AND PROD_CODE = @PROD_CODE  ");
                    sbQuery.Append("  AND PROC_CODE = @PROC_CODE  ");
                    sbQuery.Append("  AND PT_ID = @PT_ID  ");
                    sbQuery.Append("  AND RE_WO_NO IS NULL  ");
                    sbQuery.Append("  ORDER BY REG_DATE DESC ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PROD_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PROC_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PT_ID")) isHasColumn = false;

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

        public static DataTable TSHP_WORKORDER_SER27_2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("  SELECT  ");
                    sbQuery.Append("  PLT_CODE ");
                    sbQuery.Append(" ,WO_NO ");
                    sbQuery.Append(" ,PART_QTY ");
                    sbQuery.Append(" ,ACT_QTY ");
                    sbQuery.Append(" ,WO_FLAG ");
                    sbQuery.Append(" ,CHAIN_WO_NO ");
                    sbQuery.Append(" ,RE_WO_NO ");
                    sbQuery.Append(" ,DES_STOP ");
                    sbQuery.Append("  FROM TSHP_WORKORDER  ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("  AND PROD_CODE = @PROD_CODE  ");
                    sbQuery.Append("  AND PROC_CODE = @PROC_CODE  ");
                    sbQuery.Append("  AND PT_ID = @PT_ID  ");
                    sbQuery.Append("  AND RE_WO_NO = @OLD_RE_WO  ");
                    sbQuery.Append("  ORDER BY REG_DATE DESC ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PROD_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PROC_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PT_ID")) isHasColumn = false;

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

        //데이터 삭제 상태 처리
        public static void TSHP_WORKORDER_UDE(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append("UPDATE TSHP_WORKORDER SET");
                    sbQuery.Append("  DEL_DATE = GETDATE()");
                    sbQuery.Append(" , DEL_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" , PROC_ID = -1");
                    sbQuery.Append(" , DATA_FLAG = 2");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND WO_NO = @WO_NO");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
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

        public static void TSHP_WORKORDER_UDE2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append("UPDATE TSHP_WORKORDER SET");
                    sbQuery.Append("  DEL_DATE = GETDATE()");
                    sbQuery.Append(" , DEL_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" , PROC_ID = -1");
                    sbQuery.Append(" , DATA_FLAG = 2");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND PROD_CODE = @PROD_CODE");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PROD_CODE")) isHasColumn = false;

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

        public static void TSHP_WORKORDER_UDE3(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append("UPDATE TSHP_WORKORDER SET");
                    sbQuery.Append("  DEL_DATE = GETDATE()");
                    sbQuery.Append(" , DEL_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" , OLD_WO_FLAG = WO_FLAG");
                    sbQuery.Append(" , WO_FLAG = '0'");
                    sbQuery.Append(" , PROC_ID = -1");
                    sbQuery.Append(" , DATA_FLAG = 2");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND PROD_CODE = @PROD_CODE");
                    sbQuery.Append(" AND PT_ID = @PT_ID");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PROD_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PT_ID")) isHasColumn = false;

                        if (isHasColumn == true)
                        {
                            if (dtParam.Columns.Contains("RE_WO_NO"))
                            {
                                if (row["RE_WO_NO"].ToString() != "")
                                {
                                    sbQuery.Append("  AND RE_WO_NO = @RE_WO_NO  ");
                                }
                                else
                                {
                                    sbQuery.Append("  AND RE_WO_NO IS NULL  ");
                                }
                            }

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

        public static void TSHP_WORKORDER_UDE4(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append("UPDATE TSHP_WORKORDER SET");
                    sbQuery.Append("  DEL_DATE = GETDATE()");
                    sbQuery.Append(" , DEL_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" , PROC_ID = -1");
                    sbQuery.Append(" , DATA_FLAG = 2");
                    sbQuery.Append(" , DES_STOP = 1");
                    sbQuery.Append(" , DES_STOP_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" , DES_STOP_DATE = GETDATE()");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND WO_NO = @WO_NO");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
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

        public static void TSHP_WORKORDER_DEL(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append("DELETE FROM TSHP_WORKORDER");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND PROD_CODE = @PROD_CODE");
                    sbQuery.Append(" AND PT_ID = @PT_ID");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PT_ID")) isHasColumn = false;

                        if (isHasColumn == true)
                        {

                            if (dtParam.Columns.Contains("RE_WO_NO"))
                            {
                                if (row["RE_WO_NO"].ToString() != "")
                                {
                                    sbQuery.Append("  AND RE_WO_NO = @RE_WO_NO  ");
                                }
                                else
                                {
                                    sbQuery.Append("  AND RE_WO_NO IS NULL  ");
                                }
                            }

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

        public static void TSHP_WORKORDER_DEL2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append("DELETE FROM TSHP_WORKORDER ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND PROD_CODE = @PROD_CODE");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PROD_CODE")) isHasColumn = false;

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

        public static void TSHP_WORKORDER_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" INSERT INTO TSHP_WORKORDER (  ");
                    sbQuery.Append("  PLT_CODE ");
                    sbQuery.Append(" ,WO_NO ");
                    sbQuery.Append(" ,PT_ID ");
                    sbQuery.Append(" ,PROD_CODE ");
                    sbQuery.Append(" ,PART_CODE ");
                    sbQuery.Append(" ,PART_ID ");
                    sbQuery.Append(" ,PART_NUM ");
                    sbQuery.Append(" ,PROC_CODE ");
                    sbQuery.Append(" ,PROC_ID ");
                    sbQuery.Append(" ,MC_CODE ");
                    sbQuery.Append(" ,MC_GROUP ");
                    sbQuery.Append(" ,EMP_CODE ");
                    sbQuery.Append(" ,PLN_PROC_TIME ");
                    sbQuery.Append(" ,PLN_PROC_SELF_TIME ");
                    sbQuery.Append(" ,PLN_PROC_MAN_TIME ");
                    sbQuery.Append(" ,WORK_CODE ");
                    sbQuery.Append(" ,PART_QTY ");
                    sbQuery.Append(" ,PLN_START_TIME ");
                    sbQuery.Append(" ,PLN_END_TIME ");
                    sbQuery.Append(" ,WORK_SCOMMENT ");
                    sbQuery.Append(" ,UPD_SCOMMENT ");
                    sbQuery.Append(" ,SCOMMENT ");
                    sbQuery.Append(" ,CAUTION ");
                    sbQuery.Append(" ,WO_FLAG ");
                    sbQuery.Append(" ,ACT_START_TIME ");
                    sbQuery.Append(" ,ACT_END_TIME ");
                    sbQuery.Append(" ,ACT_MC_TIME ");
                    sbQuery.Append(" ,ACT_MAN_TIME ");
                    sbQuery.Append(" ,ACT_PRE_TIME ");
                    sbQuery.Append(" ,ACT_QTY ");
                    sbQuery.Append(" ,FNS_QTY ");
                    sbQuery.Append(" ,NG_QTY ");
                    sbQuery.Append(" ,WO_TYPE ");
                    sbQuery.Append(" ,JOB_PRIORITY ");
                    sbQuery.Append(" ,PRE_CAM ");
                    sbQuery.Append(" ,PRE_MAT ");
                    sbQuery.Append(" ,PRE_PGM ");
                    sbQuery.Append(" ,PRE_TOOL ");
                    sbQuery.Append(" ,PGM_TIME ");
                    sbQuery.Append(" ,O_WO_NO ");
                    sbQuery.Append(" ,SEQ ");
                    sbQuery.Append(" ,ACT_INPUT_TYPE ");
                    sbQuery.Append(" ,PLN_WORK_DATE ");
                    sbQuery.Append(" ,STD_PLN_START_TIME ");
                    sbQuery.Append(" ,STD_PLN_END_TIME ");
                    sbQuery.Append(" ,NG_ID ");
                    sbQuery.Append(" ,PUR_STAT ");
                    sbQuery.Append(" ,OS_VND ");
                    sbQuery.Append(" ,REG_DATE ");
                    sbQuery.Append(" ,REG_EMP ");
                    sbQuery.Append(" ,DATA_FLAG ");
                    sbQuery.Append(" ,WP_NO ");
                    sbQuery.Append(" ,IS_LAST ");
                    sbQuery.Append(" ,PROC_SEQ ");
                    sbQuery.Append(" ,IS_OS ");
                    sbQuery.Append(" ,PLN_STD_TIME ");
                    sbQuery.Append(" ,IS_SAVE_EACH_ROW ");
                    sbQuery.Append(" ,IS_VALIDATE ");
                    sbQuery.Append(" ,IS_SAMPLING ");
                    sbQuery.Append(" ,SAMPLING_QTY ");
                    sbQuery.Append(" ,INS_FLAG ");
                    sbQuery.Append(" ,ACT_EMP_CODE ");
                    sbQuery.Append(" ,ACT_MC_CODE ");
                    sbQuery.Append(" ,IS_FIX ");
                    sbQuery.Append(" ,IS_YPGO ");
                    sbQuery.Append(" ,RE_WO_NO ");
                    sbQuery.Append(" ,CAM_EMP ");
                    sbQuery.Append(" ,CAM_EMP_DATE ");
                    sbQuery.Append(" ,IS_ORD ");
                    sbQuery.Append(" ,OS_ORD_EMP ");
                    sbQuery.Append(" ,OS_ORD_DATE ");


                    sbQuery.Append(" ,PREV_CHAIN_WO_NO ");
                    sbQuery.Append(" ,IS_PREV_CHAIN ");
                    sbQuery.Append(" ,IS_DES_CHANGE ");
                    sbQuery.Append(" ,IS_REMCT ");
                    sbQuery.Append(" ,IS_MODIFY ");

                    sbQuery.Append("  ) VALUES (  ");
                    sbQuery.Append("  @PLT_CODE ");
                    sbQuery.Append(" ,@WO_NO ");
                    sbQuery.Append(" ,@PT_ID ");
                    sbQuery.Append(" ,@PROD_CODE ");
                    sbQuery.Append(" ,@PART_CODE ");
                    sbQuery.Append(" ,@PART_ID ");
                    sbQuery.Append(" ,@PART_NUM ");
                    sbQuery.Append(" ,@PROC_CODE ");
                    sbQuery.Append(" ,@PROC_ID ");
                    sbQuery.Append(" ,@MC_CODE ");
                    sbQuery.Append(" ,@MC_GROUP ");
                    sbQuery.Append(" ,@EMP_CODE ");
                    sbQuery.Append(" ,@PLN_PROC_TIME ");
                    sbQuery.Append(" ,@PLN_PROC_SELF_TIME ");
                    sbQuery.Append(" ,@PLN_PROC_MAN_TIME ");
                    sbQuery.Append(" ,@WORK_CODE ");
                    sbQuery.Append(" ,@PART_QTY ");
                    sbQuery.Append(" ,@PLN_START_TIME ");
                    sbQuery.Append(" ,@PLN_END_TIME ");
                    sbQuery.Append(" ,@WORK_SCOMMENT ");
                    sbQuery.Append(" ,@UPD_SCOMMENT ");
                    sbQuery.Append(" ,@SCOMMENT ");
                    sbQuery.Append(" ,@CAUTION ");
                    sbQuery.Append(" ,@WO_FLAG ");
                    sbQuery.Append(" ,@ACT_START_TIME ");
                    sbQuery.Append(" ,@ACT_END_TIME ");
                    sbQuery.Append(" ,@ACT_MC_TIME ");
                    sbQuery.Append(" ,@ACT_MAN_TIME ");
                    sbQuery.Append(" ,@ACT_PRE_TIME ");
                    sbQuery.Append(" ,@ACT_QTY ");
                    sbQuery.Append(" ,@FNS_QTY ");
                    sbQuery.Append(" ,@NG_QTY ");
                    sbQuery.Append(" ,@WO_TYPE ");
                    sbQuery.Append(" ,@JOB_PRIORITY ");
                    sbQuery.Append(" ,@PRE_CAM ");
                    sbQuery.Append(" ,@PRE_MAT ");
                    sbQuery.Append(" ,@PRE_PGM ");
                    sbQuery.Append(" ,@PRE_TOOL ");
                    sbQuery.Append(" ,@PGM_TIME ");
                    sbQuery.Append(" ,@O_WO_NO ");
                    sbQuery.Append(" ,@SEQ ");
                    sbQuery.Append(" ,@ACT_INPUT_TYPE ");
                    sbQuery.Append(" ,@PLN_WORK_DATE ");
                    sbQuery.Append(" ,@STD_PLN_START_TIME ");
                    sbQuery.Append(" ,@STD_PLN_END_TIME ");
                    sbQuery.Append(" ,@NG_ID ");
                    sbQuery.Append(" ,@PUR_STAT ");
                    sbQuery.Append(" ,@OS_VND ");
                    sbQuery.Append(" ,GETDATE() ");
                    sbQuery.Append(" ," + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" ,0 ");
                    sbQuery.Append(" ,@WP_NO ");
                    sbQuery.Append(" ,@IS_LAST ");
                    sbQuery.Append(" ,@PROC_SEQ ");
                    sbQuery.Append(" ,@IS_OS ");
                    sbQuery.Append(" ,@PLN_STD_TIME ");
                    sbQuery.Append(" ,@IS_SAVE_EACH_ROW ");
                    sbQuery.Append(" ,@IS_VALIDATE ");
                    sbQuery.Append(" ,@IS_SAMPLING ");
                    sbQuery.Append(" ,@SAMPLING_QTY ");
                    sbQuery.Append(" ,@INS_FLAG ");
                    sbQuery.Append(" ,@ACT_EMP_CODE ");
                    sbQuery.Append(" ,@ACT_MC_CODE ");
                    sbQuery.Append(" ,@IS_FIX ");
                    sbQuery.Append(" ,@IS_YPGO ");
                    sbQuery.Append(" ,@RE_WO_NO ");
                    sbQuery.Append(" ,@CAM_EMP ");
                    sbQuery.Append(" ,@CAM_EMP_DATE ");
                    sbQuery.Append(" ,@IS_ORD ");
                    sbQuery.Append(" ,@OS_ORD_EMP ");
                    sbQuery.Append(" ,@OS_ORD_DATE ");

                    sbQuery.Append(" ,@PREV_CHAIN_WO_NO ");
                    sbQuery.Append(" ,@IS_PREV_CHAIN ");
                    sbQuery.Append(" ,@IS_DES_CHANGE ");
                    sbQuery.Append(" ,@IS_REMCT ");
                    sbQuery.Append(" ,@IS_MODIFY ");

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

        public static void TSHP_WORKORDER_COPY(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" INSERT INTO TSHP_WORKORDER_LOG");
                    sbQuery.Append("( PLT_CODE			   ");
                    sbQuery.Append("      , WO_NO			   ");
                    sbQuery.Append("      , PROD_CODE		   ");
                    sbQuery.Append("      , PART_CODE		   ");
                    sbQuery.Append("      , PART_ID			   ");
                    sbQuery.Append("      , PART_NUM		   ");
                    sbQuery.Append("      , PROC_CODE		   ");
                    sbQuery.Append("      , PROC_ID			   ");
                    sbQuery.Append("      , MC_CODE			   ");
                    sbQuery.Append("      , MC_GROUP			   ");
                    sbQuery.Append("      , EMP_CODE		   ");
                    sbQuery.Append("      , PLN_PROC_TIME	   ");
                    sbQuery.Append("      , PLN_PROC_SELF_TIME ");
                    sbQuery.Append("      , PLN_PROC_MAN_TIME  ");
                    sbQuery.Append("      , WORK_CODE		   ");
                    sbQuery.Append("      , PART_QTY		   ");
                    sbQuery.Append("      , PLN_START_TIME	   ");
                    sbQuery.Append("      , PLN_END_TIME	   ");
                    sbQuery.Append("      , WORK_SCOMMENT	   ");
                    sbQuery.Append("      , UPD_SCOMMENT	   ");
                    sbQuery.Append("      , SCOMMENT		   ");
                    sbQuery.Append("      , CAUTION			   ");
                    sbQuery.Append("      , WO_FLAG			   ");
                    sbQuery.Append("      , ACT_START_TIME	   ");
                    sbQuery.Append("      , ACT_END_TIME	   ");
                    sbQuery.Append("      , ACT_MC_TIME		   ");
                    sbQuery.Append("      , ACT_MAN_TIME	   ");
                    sbQuery.Append("      , ACT_PRE_TIME	   ");
                    sbQuery.Append("      , ACT_QTY			   ");
                    sbQuery.Append("      , FNS_QTY			   ");
                    sbQuery.Append("      , NG_QTY			   ");
                    sbQuery.Append("      , WO_TYPE			   ");
                    sbQuery.Append("      , JOB_PRIORITY	   ");
                    sbQuery.Append("      , PRE_CAM			   ");
                    sbQuery.Append("      , PRE_MAT			   ");
                    sbQuery.Append("      , PRE_PGM			   ");
                    sbQuery.Append("      , PRE_TOOL		   ");
                    sbQuery.Append("      , PGM_TIME		   ");
                    sbQuery.Append("      , O_WO_NO			   ");
                    sbQuery.Append("      , SEQ				   ");
                    sbQuery.Append("      , ACT_INPUT_TYPE	   ");
                    sbQuery.Append("      , PLN_WORK_DATE	   ");
                    sbQuery.Append("      , STD_PLN_START_TIME ");
                    sbQuery.Append("      , STD_PLN_END_TIME   ");
                    sbQuery.Append("      , NG_ID			   ");
                    sbQuery.Append("      , PUR_STAT		   ");
                    sbQuery.Append("      , OS_VND			   ");
                    sbQuery.Append("      , REG_DATE		   ");
                    sbQuery.Append("      , REG_EMP			   ");
                    sbQuery.Append("      , MDFY_DATE		   ");
                    sbQuery.Append("      , MDFY_EMP		   ");
                    sbQuery.Append("      , DEL_DATE		   ");
                    sbQuery.Append("      , DEL_EMP			   ");
                    sbQuery.Append("      , DATA_FLAG		   ");
                    sbQuery.Append("      , WP_NO			   ");
                    sbQuery.Append("      , IS_LAST			   ");
                    sbQuery.Append("      , PLN_STD_TIME	   ");
                    sbQuery.Append("      , PROC_SEQ		   ");
                    sbQuery.Append("      , IS_OS			   ");
                    //sbQuery.Append("      , IS_FIX");
                    sbQuery.Append("      , IS_SAVE_EACH_ROW   ");
                    sbQuery.Append("      , IS_VALIDATE		   ");
                    sbQuery.Append("      , IS_SAMPLING		   ");
                    sbQuery.Append("      , SAMPLING_QTY	   ");
                    sbQuery.Append("      , INS_FLAG		   ");
                    sbQuery.Append("      , ACT_EMP_CODE	   ");
                    sbQuery.Append("      , ACT_MC_CODE	)	   ");
                    sbQuery.Append(" SELECT PLT_CODE			   ");
                    sbQuery.Append("      , WO_NO			   ");
                    sbQuery.Append("      , PROD_CODE		   ");
                    sbQuery.Append("      , PART_CODE		   ");
                    sbQuery.Append("      , PART_ID			   ");
                    sbQuery.Append("      , PART_NUM		   ");
                    sbQuery.Append("      , PROC_CODE		   ");
                    sbQuery.Append("      , PROC_ID			   ");
                    sbQuery.Append("      , MC_CODE			   ");
                    sbQuery.Append("      , MC_GROUP			   ");
                    sbQuery.Append("      , EMP_CODE		   ");
                    sbQuery.Append("      , PLN_PROC_TIME	   ");
                    sbQuery.Append("      , PLN_PROC_SELF_TIME ");
                    sbQuery.Append("      , PLN_PROC_MAN_TIME  ");
                    sbQuery.Append("      , WORK_CODE		   ");
                    sbQuery.Append("      , PART_QTY		   ");
                    sbQuery.Append("      , PLN_START_TIME	   ");
                    sbQuery.Append("      , PLN_END_TIME	   ");
                    sbQuery.Append("      , WORK_SCOMMENT	   ");
                    sbQuery.Append("      , UPD_SCOMMENT	   ");
                    sbQuery.Append("      , SCOMMENT		   ");
                    sbQuery.Append("      , CAUTION			   ");
                    sbQuery.Append("      , WO_FLAG			   ");
                    sbQuery.Append("      , ACT_START_TIME	   ");
                    sbQuery.Append("      , ACT_END_TIME	   ");
                    sbQuery.Append("      , ACT_MC_TIME		   ");
                    sbQuery.Append("      , ACT_MAN_TIME	   ");
                    sbQuery.Append("      , ACT_PRE_TIME	   ");
                    sbQuery.Append("      , ACT_QTY			   ");
                    sbQuery.Append("      , FNS_QTY			   ");
                    sbQuery.Append("      , NG_QTY			   ");
                    sbQuery.Append("      , WO_TYPE			   ");
                    sbQuery.Append("      , JOB_PRIORITY	   ");
                    sbQuery.Append("      , PRE_CAM			   ");
                    sbQuery.Append("      , PRE_MAT			   ");
                    sbQuery.Append("      , PRE_PGM			   ");
                    sbQuery.Append("      , PRE_TOOL		   ");
                    sbQuery.Append("      , PGM_TIME		   ");
                    sbQuery.Append("      , O_WO_NO			   ");
                    sbQuery.Append("      , SEQ				   ");
                    sbQuery.Append("      , ACT_INPUT_TYPE	   ");
                    sbQuery.Append("      , PLN_WORK_DATE	   ");
                    sbQuery.Append("      , STD_PLN_START_TIME ");
                    sbQuery.Append("      , STD_PLN_END_TIME   ");
                    sbQuery.Append("      , NG_ID			   ");
                    sbQuery.Append("      , PUR_STAT		   ");
                    sbQuery.Append("      , OS_VND			   ");
                    sbQuery.Append("      , REG_DATE		   ");
                    sbQuery.Append("      , REG_EMP			   ");
                    sbQuery.Append("      , MDFY_DATE		   ");
                    sbQuery.Append("      , MDFY_EMP		   ");
                    sbQuery.Append("      , DEL_DATE		   ");
                    sbQuery.Append("      , DEL_EMP			   ");
                    sbQuery.Append("      , DATA_FLAG		   ");
                    sbQuery.Append("      , WP_NO			   ");
                    sbQuery.Append("      , IS_LAST			   ");
                    sbQuery.Append("      , PLN_STD_TIME	   ");
                    sbQuery.Append("      , PROC_SEQ		   ");
                    sbQuery.Append("      , IS_OS			   ");
                    //sbQuery.Append("      , IS_FIX			   ");
                    sbQuery.Append("      , IS_SAVE_EACH_ROW   ");
                    sbQuery.Append("      , IS_VALIDATE		   ");
                    sbQuery.Append("      , IS_SAMPLING		   ");
                    sbQuery.Append("      , SAMPLING_QTY	   ");
                    sbQuery.Append("      , INS_FLAG		   ");
                    sbQuery.Append("      , ACT_EMP_CODE	   ");
                    sbQuery.Append("      , ACT_MC_CODE		   ");
                    sbQuery.Append("   FROM TSHP_WORKORDER");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append("    AND PROD_CODE = @PROD_CODE");
                    sbQuery.Append("    AND PART_CODE = @PART_CODE");
                    sbQuery.Append("    AND PROC_CODE = @PROC_CODE");

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

        public static void TSHP_WORKORDER_UPD(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TSHP_WORKORDER SET  ");
                    sbQuery.Append("  PT_ID = @PT_ID ");
                    sbQuery.Append(" ,PROD_CODE = @PROD_CODE ");
                    sbQuery.Append(" ,PART_CODE = @PART_CODE ");
                    sbQuery.Append(" ,PART_ID = @PART_ID ");
                    sbQuery.Append(" ,PART_NUM = @PART_NUM ");
                    sbQuery.Append(" ,PROC_CODE = @PROC_CODE ");
                    sbQuery.Append(" ,PROC_ID = @PROC_ID ");
                    sbQuery.Append(" ,MC_CODE = @MC_CODE ");
                    sbQuery.Append(" ,MC_GROUP = @MC_GROUP ");
                    sbQuery.Append(" ,EMP_CODE = @EMP_CODE ");
                    sbQuery.Append(" ,PLN_PROC_TIME = @PLN_PROC_TIME ");
                    sbQuery.Append(" ,PLN_PROC_SELF_TIME = @PLN_PROC_SELF_TIME ");
                    sbQuery.Append(" ,PLN_PROC_MAN_TIME = @PLN_PROC_MAN_TIME ");
                    sbQuery.Append(" ,WORK_CODE = @WORK_CODE ");
                    sbQuery.Append(" ,PART_QTY = @PART_QTY ");
                    sbQuery.Append(" ,PLN_START_TIME = @PLN_START_TIME ");
                    sbQuery.Append(" ,PLN_END_TIME = @PLN_END_TIME ");
                    sbQuery.Append(" ,WORK_SCOMMENT = @WORK_SCOMMENT ");//비고
                    sbQuery.Append(" ,UPD_SCOMMENT = @UPD_SCOMMENT ");
                    sbQuery.Append(" ,SCOMMENT = @SCOMMENT ");
                    sbQuery.Append(" ,CAUTION = @CAUTION ");
                    sbQuery.Append(" ,WO_FLAG = @WO_FLAG ");
                    sbQuery.Append(" ,ACT_START_TIME = @ACT_START_TIME ");
                    sbQuery.Append(" ,ACT_END_TIME = @ACT_END_TIME ");
                    sbQuery.Append(" ,ACT_MC_TIME = @ACT_MC_TIME ");
                    sbQuery.Append(" ,ACT_MAN_TIME = @ACT_MAN_TIME ");
                    sbQuery.Append(" ,ACT_PRE_TIME = @ACT_PRE_TIME ");
                    sbQuery.Append(" ,ACT_QTY = @ACT_QTY ");
                    sbQuery.Append(" ,FNS_QTY = @FNS_QTY ");
                    sbQuery.Append(" ,NG_QTY = @NG_QTY ");
                    sbQuery.Append(" ,WO_TYPE = @WO_TYPE ");
                    sbQuery.Append(" ,JOB_PRIORITY = @JOB_PRIORITY ");
                    sbQuery.Append(" ,PRE_CAM = @PRE_CAM ");
                    sbQuery.Append(" ,PRE_MAT = @PRE_MAT ");
                    sbQuery.Append(" ,PRE_PGM = @PRE_PGM ");
                    sbQuery.Append(" ,PRE_TOOL = @PRE_TOOL ");
                    sbQuery.Append(" ,PGM_TIME = @PGM_TIME ");
                    sbQuery.Append(" ,O_WO_NO = @O_WO_NO ");
                    sbQuery.Append(" ,SEQ = @SEQ ");
                    sbQuery.Append(" ,ACT_INPUT_TYPE = @ACT_INPUT_TYPE ");
                    sbQuery.Append(" ,PLN_WORK_DATE = @PLN_WORK_DATE ");
                    sbQuery.Append(" ,STD_PLN_START_TIME = @STD_PLN_START_TIME ");
                    sbQuery.Append(" ,STD_PLN_END_TIME = @STD_PLN_END_TIME ");
                    sbQuery.Append(" ,NG_ID = @NG_ID ");
                    sbQuery.Append(" ,PUR_STAT = @PUR_STAT ");
                    sbQuery.Append(" ,OS_VND = @OS_VND ");
                    sbQuery.Append(" ,MDFY_DATE = GETDATE() ");
                    sbQuery.Append(" ,MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" ,DATA_FLAG = @DATA_FLAG ");
                    sbQuery.Append(" ,WP_NO = @WP_NO ");
                    sbQuery.Append(" ,IS_LAST = @IS_LAST ");
                    sbQuery.Append(" ,PROC_SEQ = @PROC_SEQ ");
                    sbQuery.Append(" ,IS_OS = @IS_OS ");
                    sbQuery.Append(" ,PLN_STD_TIME = @PLN_STD_TIME ");
                    sbQuery.Append(" ,IS_SAVE_EACH_ROW = @IS_SAVE_EACH_ROW ");
                    sbQuery.Append(" ,IS_VALIDATE = @IS_VALIDATE ");
                    sbQuery.Append(" ,IS_SAMPLING = @IS_SAMPLING ");
                    sbQuery.Append(" ,SAMPLING_QTY = @SAMPLING_QTY ");
                    sbQuery.Append(" ,INS_FLAG = @INS_FLAG ");
                    sbQuery.Append(" ,ACT_EMP_CODE = @ACT_EMP_CODE ");
                    sbQuery.Append(" ,ACT_MC_CODE = @ACT_MC_CODE ");
                    sbQuery.Append(" ,IS_FIX = @IS_FIX ");
                    sbQuery.Append(" ,IS_YPGO = @IS_YPGO ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append("  AND WO_NO = @WO_NO ");
                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
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


        public static void TSHP_WORKORDER_UPD3(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TSHP_WORKORDER SET  ");
                    sbQuery.Append(" PLN_START_TIME = @PLN_START_TIME ");
                    sbQuery.Append(" ,PLN_END_TIME = @PLN_END_TIME ");
                    //sbQuery.Append(" ,WO_TYPE = @WO_TYPE ");
                    sbQuery.Append(" ,PROC_ID = @PROC_ID ");
                    sbQuery.Append(" ,SEQ = @SEQ ");                    
                    sbQuery.Append(" ,MDFY_DATE = GETDATE() ");
                    sbQuery.Append(" ,MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    //sbQuery.Append(" ,DATA_FLAG = @DATA_FLAG ");
                    sbQuery.Append(" ,IS_LAST = @IS_LAST ");
                    sbQuery.Append(" ,PROC_SEQ = @PROC_SEQ ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append("  AND WO_NO = @WO_NO ");
                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
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

        public static void TSHP_WORKORDER_UPD3_2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TSHP_WORKORDER SET  ");
                    sbQuery.Append(" PLN_START_TIME = @PLN_START_TIME ");
                    sbQuery.Append(" ,PLN_END_TIME = @PLN_END_TIME ");
                    //sbQuery.Append(" ,WO_TYPE = @WO_TYPE ");
                    sbQuery.Append(" ,PROC_ID = @PROC_ID ");
                    sbQuery.Append(" ,SEQ = @SEQ ");
                    sbQuery.Append(" ,DATA_FLAG = 0 ");
                    sbQuery.Append(" ,MDFY_DATE = GETDATE() ");
                    sbQuery.Append(" ,MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    //sbQuery.Append(" ,DATA_FLAG = @DATA_FLAG ");
                    sbQuery.Append(" ,IS_LAST = @IS_LAST ");
                    sbQuery.Append(" ,PROC_SEQ = @PROC_SEQ ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append("  AND WO_NO = @WO_NO ");
                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
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

        public static void TSHP_WORKORDER_UPD2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TSHP_WORKORDER SET  ");
                    sbQuery.Append(" PROC_ID = @PROC_ID ");
                    sbQuery.Append(" ,WO_FLAG = @WO_FLAG ");
                    sbQuery.Append(" ,WORK_SCOMMENT = @WORK_SCOMMENT "); //211022 pkd
                    sbQuery.Append(" ,MDFY_DATE = GETDATE() ");
                    sbQuery.Append(" ,MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" ,DATA_FLAG = @DATA_FLAG ");                    
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append("  AND PT_ID = @PT_ID ");
                    sbQuery.Append("  AND PROC_CODE = @PROC_CODE ");
                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PT_ID")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PROC_CODE")) isHasColumn = false;

                        if (isHasColumn == true)
                        {
                            if (row["RE_WO_NO"].toStringEmpty() != "")
                            {
                                sbQuery.Append("  AND RE_WO_NO = @RE_WO_NO ");
                            }
                            else
                            {
                                sbQuery.Append("  AND RE_WO_NO IS NULL ");
                            }

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

        public static void TSHP_WORKORDER_UPD2_3(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TSHP_WORKORDER SET  ");
                    sbQuery.Append(" DEL_DATE = GETDATE() ");
                    sbQuery.Append(" ,DEL_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append("  AND PT_ID = @PT_ID ");
                    sbQuery.Append("  AND PROC_CODE = @PROC_CODE ");
                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PT_ID")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PROC_CODE")) isHasColumn = false;

                        if (isHasColumn == true)
                        {
                            if (row["RE_WO_NO"].toStringEmpty() != "")
                            {
                                sbQuery.Append("  AND RE_WO_NO = @RE_WO_NO ");
                            }
                            else
                            {
                                sbQuery.Append("  AND RE_WO_NO IS NULL ");
                            }

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

        public static void TSHP_WORKORDER_UPD4_3(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TSHP_WORKORDER SET  ");
                    sbQuery.Append("  MDFY_DATE = GETDATE() ");
                    sbQuery.Append(" ,MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" ,WO_FLAG = '1' ");
                    sbQuery.Append(" ,DATA_FLAG = '0' ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append("  AND WO_NO = @WO_NO ");
                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
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

        public static void TSHP_WORKORDER_UPD2_2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TSHP_WORKORDER SET  ");
                    sbQuery.Append(" IS_DES_CHANGE = @IS_DES_CHANGE ");
                    sbQuery.Append(" ,IS_REMCT = @IS_REMCT ");
                    sbQuery.Append(" ,IS_MODIFY = @IS_MODIFY ");
                    sbQuery.Append(" ,MDFY_DATE = GETDATE() ");
                    sbQuery.Append(" ,MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" ,DATA_FLAG = @DATA_FLAG ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append("  AND PT_ID = @PT_ID ");
                    sbQuery.Append("  AND PROC_CODE = @PROC_CODE ");
                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PT_ID")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PROC_CODE")) isHasColumn = false;

                        if (isHasColumn == true)
                        {
                            if (row["RE_WO_NO"].toStringEmpty() != "")
                            {
                                sbQuery.Append("  AND RE_WO_NO = @RE_WO_NO ");
                            }
                            else
                            {
                                sbQuery.Append("  AND RE_WO_NO IS NULL ");
                            }

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

        public static void TSHP_WORKORDER_UPD2_1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TSHP_WORKORDER SET  ");
                    sbQuery.Append(" PROC_ID = @PROC_ID ");
                    sbQuery.Append(" ,WO_FLAG = @WO_FLAG ");
                    sbQuery.Append(" ,WORK_SCOMMENT = @WORK_SCOMMENT "); //211022 pkd
                    sbQuery.Append(" ,MDFY_DATE = GETDATE() ");
                    sbQuery.Append(" ,MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" ,DATA_FLAG = @DATA_FLAG ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append("  AND WO_NO = @WO_NO ");
                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "WO_NO")) isHasColumn = false;

                        if (isHasColumn == true)
                        {
                            if (row["RE_WO_NO"].toStringEmpty() != "")
                            {
                                sbQuery.Append("  AND RE_WO_NO = @RE_WO_NO ");
                            }
                            else
                            {
                                sbQuery.Append("  AND RE_WO_NO IS NULL ");
                            }

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
        /// 작업지시 상태 변경
        /// </summary>
        /// <param name="dtParam"></param>
        /// <param name="bizExecute"></param>
        public static void TSHP_WORKORDER_UPD4(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" UPDATE TSHP_WORKORDER");
                    sbQuery.Append(" SET   WO_FLAG = @WO_FLAG");                    
                    sbQuery.Append(" , ACT_START_TIME = (SELECT MIN(ACT_START_TIME) FROM TSHP_ACTUAL WHERE PLT_CODE = @PLT_CODE AND WO_NO = @WO_NO) ");
                    //sbQuery.Append(" , ACT_END_TIME = (SELECT MAX(ACT_END_TIME) FROM TSHP_ACTUAL WHERE PLT_CODE = @PLT_CODE AND WO_NO = @WO_NO) ");
                    sbQuery.Append(" , MDFY_DATE = GETDATE() ");
                    sbQuery.Append(" , MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE ");
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

        /// <summary>
        /// 발주시 상태 : 진행으로 변경, 시작예정일 (발주일), 완료예정일 ( 입고예정일), 실적 시작일 (발주일) 로 업데이트
        /// </summary>
        /// <param name="dtParam"></param>
        /// <param name="bizExecute"></param>
        public static void TSHP_WORKORDER_UPD5(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" UPDATE TSHP_WORKORDER");
                    sbQuery.Append(" SET   WO_FLAG = @WO_FLAG");
                    sbQuery.Append(" , PLN_START_TIME = @PLN_START_TIME ");
                    sbQuery.Append(" , PLN_END_TIME = @PLN_END_TIME ");
                    sbQuery.Append(" , ACT_START_TIME = @ACT_START_TIME ");

                    sbQuery.Append(" , MDFY_DATE = GETDATE() ");
                    sbQuery.Append(" , MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE ");
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

        public static void TSHP_WORKORDER_UPD5_1_1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" UPDATE TSHP_WORKORDER");
                    sbQuery.Append(" SET   WO_FLAG = @WO_FLAG");
                    sbQuery.Append(" , ACT_END_TIME = @ACT_END_TIME ");
                    sbQuery.Append(" , ACT_QTY = @ACT_QTY ");
                    sbQuery.Append(" , MDFY_DATE = GETDATE() ");
                    sbQuery.Append(" , MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE ");
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

        /// <summary>
        /// 작업지시의 계획 설비 없는 경우, 외주 발주 보낼 때 발주처로 설정된 설비로 업데이트.
        /// </summary>
        /// <param name="dtParam"></param>
        /// <param name="bizExecute"></param>
        public static void TSHP_WORKORDER_UPD5_4(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" UPDATE TSHP_WORKORDER");
                    sbQuery.Append(" SET   WO_FLAG = @WO_FLAG");
                    sbQuery.Append(" , PLN_START_TIME = @PLN_START_TIME ");
                    sbQuery.Append(" , PLN_END_TIME = @PLN_END_TIME ");
                    sbQuery.Append(" , ACT_START_TIME = @ACT_START_TIME ");
                    sbQuery.Append(" , MC_CODE = @MC_CODE ");
                    sbQuery.Append(" , MDFY_DATE = GETDATE() ");
                    sbQuery.Append(" , MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE ");
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


        /// <summary>
        /// 입고예정일 변경
        /// </summary>
        /// <param name="dtParam"></param>
        /// <param name="bizExecute"></param>
        public static void TSHP_WORKORDER_UPD5_3(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" UPDATE TSHP_WORKORDER");
                    sbQuery.Append(" SET   PLN_END_TIME = @PLN_END_TIME");
                    sbQuery.Append(" , MDFY_DATE = GETDATE() ");
                    sbQuery.Append(" , MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE ");
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

        /// <summary>
        /// 발주 취소 시 상태 : 확정으로 변경, 시작예정일 (발주일), 완료예정일 ( 입고예정일), 실적 시작일 (발주일) 로 업데이트
        /// </summary>
        /// <param name="dtParam"></param>
        /// <param name="bizExecute"></param>
        public static void TSHP_WORKORDER_UPD5_2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" UPDATE TSHP_WORKORDER");
                    sbQuery.Append(" SET   WO_FLAG = @WO_FLAG");
                    sbQuery.Append(" , PLN_START_TIME = NULL ");
                    sbQuery.Append(" , PLN_END_TIME = NULL ");
                    sbQuery.Append(" , ACT_START_TIME = NULL ");
                    sbQuery.Append(" , MDFY_DATE = GETDATE() ");
                    sbQuery.Append(" , MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE ");
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

        /// <summary>
        /// 입고시 상태 : 완료으로 변경, 
        /// </summary>
        /// <param name="dtParam"></param>
        /// <param name="bizExecute"></param>
        public static void TSHP_WORKORDER_UPD5_5(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" UPDATE TSHP_WORKORDER");
                    sbQuery.Append(" SET   WO_FLAG = @WO_FLAG");
                    sbQuery.Append(" , MDFY_DATE = GETDATE() ");
                    sbQuery.Append(" , MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE ");
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

        public static void TSHP_WORKORDER_UPD5_1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" UPDATE TSHP_WORKORDER");
                    sbQuery.Append(" SET   WO_FLAG = @WO_FLAG");
                    sbQuery.Append(" , ACT_QTY = (SELECT SUM(ISNULL(OK_QTY,0)) FROM TSHP_ACTUAL WHERE PLT_CODE = @PLT_CODE AND WO_NO = @WO_NO) ");
                    sbQuery.Append(" , NG_QTY = (SELECT SUM(ISNULL(NG_QTY,0)) FROM TSHP_ACTUAL WHERE PLT_CODE = @PLT_CODE AND WO_NO = @WO_NO) ");
                    sbQuery.Append(" , ACT_START_TIME = (SELECT MIN(ACT_START_TIME) FROM TSHP_ACTUAL WHERE PLT_CODE = @PLT_CODE AND WO_NO = @WO_NO) ");
                    sbQuery.Append(" , ACT_END_TIME = (SELECT MAX(ACT_END_TIME) FROM TSHP_ACTUAL WHERE PLT_CODE = @PLT_CODE AND WO_NO = @WO_NO) ");
                    sbQuery.Append(" , MDFY_DATE = GETDATE() ");
                    sbQuery.Append(" , MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE ");
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

        public static void TSHP_WORKORDER_UPD5_6(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" UPDATE TSHP_WORKORDER");
                    sbQuery.Append(" SET   WO_FLAG = @WO_FLAG");
                    sbQuery.Append(" , INS_FLAG = @INS_FLAG ");
                    sbQuery.Append(" , IS_YPGO = @IS_YPGO ");
                    sbQuery.Append(" , MDFY_DATE = GETDATE() ");
                    sbQuery.Append(" , MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE ");
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

        public static void TSHP_WORKORDER_UPD6(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" UPDATE TSHP_WORKORDER");
                    sbQuery.Append(" SET   WO_FLAG = @WO_FLAG");
                    sbQuery.Append(" , ACT_START_TIME = @ACT_START_TIME");
                    sbQuery.Append(" , ACT_END_TIME = @ACT_END_TIME");
                    sbQuery.Append(" , ACT_MC_TIME = @ACT_MC_TIME");
                    sbQuery.Append(" , ACT_MAN_TIME = @ACT_MAN_TIME");
                    sbQuery.Append(" , ACT_QTY = @ACT_QTY");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE ");
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


        public static void TSHP_WORKORDER_UPD6_1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" UPDATE TSHP_WORKORDER");
                    sbQuery.Append(" SET   WO_FLAG = @WO_FLAG");
                    sbQuery.Append(" , ACT_START_TIME = @ACT_START_TIME");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE ");
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









        //작업중인 작업지시를 완료로 모두 변경
        public static void TSHP_WORKORDER_UPD7(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" UPDATE TSHP_WORKORDER");
                    sbQuery.Append(" SET   WO_FLAG = '4' ");
                    sbQuery.Append(" , MDFY_DATE = GETDATE() ");
                    sbQuery.Append(" , MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append(" AND WO_FLAG IN ('2', '3') ");
                    sbQuery.Append(" AND DATA_FLAG = 0 ");
                    //sbQuery.Append(" AND PROD_CODE IN (SELECT PROD_CODE FROM TORD_PRODUCT WHERE ITEM_CODE = @ITEM_CODE)");
                    sbQuery.Append(" AND PROD_CODE = @PROD_CODE");
                    sbQuery.Append(" AND PART_CODE = @PART_CODE");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bizExecute.executeUpdateQuery(sbQuery.ToString(), row);
                    }
                }
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }



        //미확정/확정 작업지시를 모두 삭제
        public static void TSHP_WORKORDER_UPD8(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" UPDATE TSHP_WORKORDER");
                    sbQuery.Append(" SET   DATA_FLAG = 2 ");
                    sbQuery.Append(" , DEL_DATE = GETDATE() ");
                    sbQuery.Append(" , DEL_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append(" AND WO_FLAG IN ('0', '1') ");
                    //sbQuery.Append(" AND PROD_CODE IN (SELECT PROD_CODE FROM TORD_PRODUCT WHERE ITEM_CODE = @ITEM_CODE)");
                    sbQuery.Append(" AND PROD_CODE = @PROD_CODE");
                    sbQuery.Append(" AND PART_CODE = @PART_CODE");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bizExecute.executeUpdateQuery(sbQuery.ToString(), row);
                    }
                }
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }

        //생산실적완료 수량 업데이트
        public static void TSHP_WORKORDER_UPD9(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" UPDATE TSHP_WORKORDER");
                    sbQuery.Append(" SET   FNS_QTY = ISNULL(FNS_QTY, 0) + @FNS_QTY ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append(" AND WO_NO = @WO_NO");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        bizExecute.executeUpdateQuery(sbQuery.ToString(), row);
                    }
                }
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }

        //생산실적완료 취소 수량 업데이트
        public static void TSHP_WORKORDER_UPD9_2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" UPDATE TSHP_WORKORDER");
                    sbQuery.Append(" SET   FNS_QTY = ISNULL(FNS_QTY, 0) - @FNS_QTY ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append(" AND WO_NO = @WO_NO");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        bizExecute.executeUpdateQuery(sbQuery.ToString(), row);
                    }
                }
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }

        //불량 수량 업데이트
        public static void TSHP_WORKORDER_UPD10(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TSHP_WORKORDER");
                    sbQuery.Append(" SET   NG_QTY = ISNULL(NG_QTY, 0) + @WK_NG_QTY ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append(" AND WO_NO = @WO_NO");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        bizExecute.executeUpdateQuery(sbQuery.ToString(), row);
                    }
                }
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }

        //불량 수량 업데이트
        public static void TSHP_WORKORDER_UPD11(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TSHP_WORKORDER");
                    sbQuery.Append(" SET   NG_QTY = @WK_NG_QTY ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append(" AND WO_NO = @WO_NO");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        bizExecute.executeUpdateQuery(sbQuery.ToString(), row);
                    }
                }
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }
        //설비일정표에서 작업지시 정보 변경
        public static void TSHP_WORKORDER_UPD12(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TSHP_WORKORDER ");
                    sbQuery.Append("    SET   MC_CODE = @MC_CODE ");
                    sbQuery.Append("        , PLN_START_TIME = @PLN_START_TIME ");
                    sbQuery.Append("        , PLN_END_TIME = @PLN_END_TIME ");
                    sbQuery.Append("        , WO_FLAG = @WO_FLAG ");
                    sbQuery.Append("        , MDFY_DATE = GETDATE() ");
                    sbQuery.Append("        , MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("    AND WO_NO = @WO_NO ");


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




        public static void TSHP_WORKORDER_UPD14(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TSHP_WORKORDER ");
                    sbQuery.Append("    SET   MC_CODE = @MC_CODE ");
                    sbQuery.Append("        , EMP_CODE = @EMP_CODE ");
                    sbQuery.Append("        , PLN_START_TIME = @PLN_START_TIME ");
                    sbQuery.Append("        , PLN_END_TIME = @PLN_END_TIME ");
                    sbQuery.Append("        , PLN_PROC_TIME = @PROC_MAN_TIME ");
                    sbQuery.Append("        , PLN_PROC_MAN_TIME = @PROC_MAN_TIME ");
                    sbQuery.Append("        , SCOMMENT = @SCOMMENT ");
                    sbQuery.Append("        , MDFY_DATE = GETDATE() ");
                    sbQuery.Append("        , MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("    AND WO_NO = @WO_NO ");


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

        //공정외주 발주승인. 승인취소 해당 작업지시 정보 변경
        public static void TSHP_WORKORDER_UPD15(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" UPDATE TSHP_WORKORDER ");
                    sbQuery.Append("    SET   WO_FLAG = @WO_FLAG ");
                    sbQuery.Append("        , ACT_START_TIME = @ACT_START_TIME ");
                    sbQuery.Append("        , ACT_INPUT_TYPE = @ACT_INPUT_TYPE ");
                    sbQuery.Append("        , OS_VND = @OS_VND ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("    AND WO_NO = @WO_NO ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
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

        public static void TSHP_WORKORDER_UPD16(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("UPDATE TSHP_WORKORDER ");
                    sbQuery.Append(" SET PART_QTY = ISNULL(B.PROD_QTY, 1) * ISNULL(B.BOM_QTY, 1) ");

                    sbQuery.Append(" FROM TSHP_WORKORDER W JOIN TORD_PRODUCT B ");
                    sbQuery.Append("   ON W.PLT_CODE = B.PLT_CODE ");
                    sbQuery.Append(" AND W.PROD_CODE = B.PROD_CODE ");
                    sbQuery.Append(" AND W.PART_CODE = B.PART_CODE  ");
                    sbQuery.Append(" WHERE W.PLT_CODE = @PLT_CODE ");
                    sbQuery.Append("  AND W.PROD_CODE = @PROD_CODE ");
                    sbQuery.Append("  AND W.PART_CODE = @PART_CODE ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PROD_CODE")) isHasColumn = false;
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

        public static void TSHP_WORKORDER_UPD17(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("UPDATE TSHP_WORKORDER ");
                    sbQuery.Append("    SET   PLN_START_TIME = @PLN_START_TIME ");
                    sbQuery.Append("        , PLN_END_TIME = @PLN_END_TIME ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append("  AND WO_NO = @WO_NO ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
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

        public static void TSHP_WORKORDER_UPD22(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" UPDATE TSHP_WORKORDER		");
                    sbQuery.Append(" SET   ");
                    sbQuery.Append("  EMP_CODE = @EMP_CODE		");
                    sbQuery.Append(" , WO_FLAG = @WO_FLAG		");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append(" AND WO_NO = @WO_NO			");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
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

        public static void TSHP_WORKORDER_UPD23(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" UPDATE TSHP_WORKORDER		");
                    sbQuery.Append(" SET  PRE_CAM = @PRE_CAM	");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append(" AND WO_NO = @WO_NO			");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
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

        public static void TSHP_WORKORDER_UPD24(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TSHP_WORKORDER     ");
                    sbQuery.Append(" SET   PUR_STAT = @PUR_STAT");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND WO_NO = @WO_NO        ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
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

        public static void TSHP_WORKORDER_UPD25(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" UPDATE TSHP_WORKORDER");
                    sbQuery.Append(" SET PART_CODE = @PART_CODE");
                    foreach (DataRow row in dtParam.Rows)
                    {
                        if (UTIL.ValidColumn(row, "PART_ID"))sbQuery.Append(" , PART_ID = @PART_ID");
                        if (UTIL.ValidColumn(row, "PROC_CODE"))sbQuery.Append(" , PROC_CODE= @PROC_CODE");
                        if (UTIL.ValidColumn(row, "PROC_ID"))sbQuery.Append(" , PROC_ID = @PROC_ID");
                        if (UTIL.ValidColumn(row, "PROC_SEQ")) sbQuery.Append(" , PROC_SEQ = @PROC_SEQ");
                        //sbQuery.Append(" , MC_CODE = @MC_CODE");
                        //sbQuery.Append(" , EMP_CODE = @EMP_CODE");
                        //sbQuery.Append(" , WO_FLAG = @WO_FLAG");
                        //sbQuery.Append(" , WO_TYPE = @WO_TYPE");
                        if (UTIL.ValidColumn(row, "PART_QTY")) sbQuery.Append(" , PART_QTY = @PART_QTY");
                        //sbQuery.Append(" , JOB_PRIORITY = @JOB_PRIORITY");
                        if (UTIL.ValidColumn(row, "IS_LAST"))sbQuery.Append(" , IS_LAST = @IS_LAST");
                        if (UTIL.ValidColumn(row, "IS_OS"))sbQuery.Append(" , IS_OS = @IS_OS");
                        if (UTIL.ValidColumn(row, "IS_VALIDATE"))sbQuery.Append(" , IS_VALIDATE = @IS_VALIDATE");
                        if (UTIL.ValidColumn(row, "IS_SAMPLING"))sbQuery.Append(" , IS_SAMPLING = @IS_SAMPLING");
                        if (UTIL.ValidColumn(row, "SAMPLING_QTY"))sbQuery.Append(" , SAMPLING_QTY = @SAMPLING_QTY");
                        if (UTIL.ValidColumn(row, "INS_FLAG")) sbQuery.Append(" , INS_FLAG = @INS_FLAG");
                        sbQuery.Append(" , MDFY_DATE = GETDATE() ");
                        sbQuery.Append(" , MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                        sbQuery.Append(" , DATA_FLAG = 0 ");
                        sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE ");
                        sbQuery.Append(" AND WO_NO = @WO_NO ");


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

        public static void TSHP_WORKORDER_UPD26(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" UPDATE TSHP_WORKORDER");
                    sbQuery.Append(" SET CAUTION = @CAUTION");
                    sbQuery.Append(" , MDFY_DATE = GETDATE() ");
                    sbQuery.Append(" , MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append(" AND WO_NO = @WO_NO ");

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

        /// <summary>
        /// 계획 저장 (고정 추가)
        /// </summary>
        /// <param name="dtParam"></param>
        /// <param name="bizExecute"></param>
        public static void TSHP_WORKORDER_UPD27(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" UPDATE TSHP_WORKORDER");
                    sbQuery.Append(" SET MC_CODE = @PLN_MC_CODE");
                    sbQuery.Append(" , PLN_START_TIME = @PLN_START_TIME");
                    sbQuery.Append(" , PLN_END_TIME = @PLN_END_TIME");
                    sbQuery.Append(" , IS_FIX = @IS_FIX");
                    sbQuery.Append(" , WO_FLAG = '1'");
                    sbQuery.Append(" , MDFY_DATE = GETDATE() ");
                    sbQuery.Append(" , MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" , DATA_FLAG = 0 ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append(" AND PROD_CODE = @PROD_CODE ");
                    sbQuery.Append(" AND PART_CODE = @PART_CODE ");
                    sbQuery.Append(" AND PROC_CODE = @PROC_CODE ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PROD_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PART_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PROC_CODE")) isHasColumn = false;

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
        /// 계획 고정
        /// </summary>
        /// <param name="dtParam"></param>
        /// <param name="bizExecute"></param>
        public static void TSHP_WORKORDER_UPD28(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" UPDATE TSHP_WORKORDER		");
                    sbQuery.Append(" SET   ");
                    sbQuery.Append("    IS_FIX = @IS_FIX		");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append(" AND WO_NO = @WO_NO			");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
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

        /// <summary>
        /// 캠작업자 지정
        /// </summary>
        /// <param name="dtParam"></param>
        /// <param name="bizExecute"></param>
        public static void TSHP_WORKORDER_UPD29(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" UPDATE TSHP_WORKORDER		");
                    sbQuery.Append(" SET   ");
                    sbQuery.Append("    CAM_EMP = @CAM_EMP		");
                    sbQuery.Append("   , CAM_EMP_DATE = @CAM_EMP_DATE	");
                    sbQuery.Append("   , MDFY_DATE = GETDATE()	");
                    sbQuery.Append("   , MDFY_EMP = "+ UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append(" AND WO_NO = @WO_NO			");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
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


        /// <summary>
        /// 검사수량 작업지시에 업데이트(검사 시작)
        /// </summary>
        /// <param name="dtParam"></param>
        /// <param name="bizExecute"></param>
        public static void TSHP_WORKORDER_UPD30(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" UPDATE TSHP_WORKORDER		");
                    sbQuery.Append(" SET   ");
                    sbQuery.Append("    INS_QTY = (SELECT SUM(ISNULL(INS_QTY,0)) FROM TSHP_ACTUAL_INS WHERE PLT_CODE = @PLT_CODE AND WO_NO = @WO_NO) ");
                    sbQuery.Append("   , ACT_QTY = (SELECT SUM(ISNULL(INS_QTY,0)) FROM TSHP_ACTUAL_INS WHERE PLT_CODE = @PLT_CODE AND WO_NO = @WO_NO) ");
                    sbQuery.Append("   , WO_FLAG = @WO_FLAG	");
                    sbQuery.Append("   , ACT_START_TIME = GETDATE()	");
                    sbQuery.Append("   , INS_DATE = NULL	");
                    sbQuery.Append("   , MDFY_DATE = GETDATE()	");
                    sbQuery.Append("   , MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append(" AND WO_NO = @WO_NO			");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
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

        public static void TSHP_WORKORDER_UPD30_1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" UPDATE TSHP_WORKORDER		");
                    sbQuery.Append(" SET   ");
                    sbQuery.Append("    INS_QTY = (SELECT SUM(ISNULL(INS_QTY,0)) FROM TSHP_ACTUAL_INS WHERE PLT_CODE = @PLT_CODE AND WO_NO = @WO_NO) ");
                    sbQuery.Append("   , ACT_QTY = (SELECT SUM(ISNULL(INS_QTY,0)) FROM TSHP_ACTUAL_INS WHERE PLT_CODE = @PLT_CODE AND WO_NO = @WO_NO) ");
                    sbQuery.Append("   , WO_FLAG = @WO_FLAG	");
                    sbQuery.Append("   , INS_DATE = NULL	");
                    sbQuery.Append("   , MDFY_DATE = GETDATE()	");
                    sbQuery.Append("   , MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append(" AND WO_NO = @WO_NO			");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
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

        public static void TSHP_WORKORDER_UPD30_2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" UPDATE TSHP_WORKORDER		");
                    sbQuery.Append(" SET   ");
                    sbQuery.Append("    INS_QTY = (SELECT SUM(ISNULL(INS_QTY,0)) FROM TSHP_ACTUAL_INS WHERE PLT_CODE = @PLT_CODE AND WO_NO = @WO_NO) ");
                    sbQuery.Append("   , ACT_QTY = (SELECT SUM(ISNULL(INS_QTY,0)) FROM TSHP_ACTUAL_INS WHERE PLT_CODE = @PLT_CODE AND WO_NO = @WO_NO) ");
                    sbQuery.Append("   , WO_FLAG = @WO_FLAG	");
                    sbQuery.Append("   , ACT_START_TIME = NULL	");
                    sbQuery.Append("   , ACT_END_TIME = NULL	");
                    sbQuery.Append("   , INS_DATE = NULL	");
                    sbQuery.Append("   , MDFY_DATE = GETDATE()	");
                    sbQuery.Append("   , MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append(" AND WO_NO = @WO_NO			");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
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


        /// <summary>
        /// 검사완료일 작업지시에 업데이트(검사완료)
        /// </summary>
        /// <param name="dtParam"></param>
        /// <param name="bizExecute"></param>
        public static void TSHP_WORKORDER_UPD31(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" UPDATE TSHP_WORKORDER		");
                    sbQuery.Append(" SET   ");
                    sbQuery.Append("    INS_DATE = @INS_DATE ");
                    sbQuery.Append("    ,WO_FLAG = @WO_FLAG ");
                    sbQuery.Append("    ,INS_WORK = @INS_WORK ");
                    sbQuery.Append("   , ACT_END_TIME = GETDATE()	");
                    sbQuery.Append("   , MDFY_DATE = GETDATE()	");
                    sbQuery.Append("   , MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append(" AND WO_NO = @WO_NO			");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
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

        public static void TSHP_WORKORDER_UPD31_1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" UPDATE TSHP_WORKORDER		");
                    sbQuery.Append(" SET   ");
                    sbQuery.Append("    INS_DATE = @INS_DATE ");
                    sbQuery.Append("    ,WO_FLAG = @WO_FLAG ");
                    sbQuery.Append("   , ACT_END_TIME = GETDATE()	");
                    sbQuery.Append("   , MDFY_DATE = GETDATE()	");
                    sbQuery.Append("   , MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append(" AND WO_NO = @WO_NO			");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
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



        /// <summary>
        /// 작업지시에 실적 업데이트(시작)
        /// </summary>
        /// <param name="dtParam"></param>
        /// <param name="bizExecute"></param>
        public static void TSHP_WORKORDER_UPD32(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" UPDATE TSHP_WORKORDER		");
                    sbQuery.Append(" SET   ");
                    sbQuery.Append("    WO_FLAG = @WO_FLAG ");
                    sbQuery.Append("    ,ACT_START_TIME = GETDATE() ");
                    sbQuery.Append("    ,ACT_END_TIME = GETDATE() ");
                    sbQuery.Append("    ,ACT_QTY = @ACT_QTY ");
                    sbQuery.Append("   , MDFY_DATE = GETDATE()	");
                    sbQuery.Append("   , MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append(" AND WO_NO = @WO_NO			");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
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

        /// <summary>
        /// 작업지시에 실적 업데이트(실적)
        /// </summary>
        /// <param name="dtParam"></param>
        /// <param name="bizExecute"></param>
        public static void TSHP_WORKORDER_UPD33(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" UPDATE TSHP_WORKORDER		");
                    sbQuery.Append(" SET   ");                    
                    sbQuery.Append("    ACT_QTY = @ACT_QTY ");
                    sbQuery.Append("    ,WO_FLAG = @WO_FLAG ");
                    sbQuery.Append("    ,ACT_END_TIME = GETDATE() ");
                    sbQuery.Append("   , MDFY_DATE = GETDATE()	");
                    sbQuery.Append("   , MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append(" AND WO_NO = @WO_NO			");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
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

        /// <summary>
        /// 작업지시에 실적 업데이트(종료)
        /// </summary>
        /// <param name="dtParam"></param>
        /// <param name="bizExecute"></param>
        public static void TSHP_WORKORDER_UPD34(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" UPDATE TSHP_WORKORDER		");
                    sbQuery.Append(" SET   ");
                    sbQuery.Append("    WO_FLAG = @WO_FLAG ");
                    sbQuery.Append("    ,ACT_END_TIME = GETDATE() ");
                    sbQuery.Append("    ,ACT_QTY = @ACT_QTY ");
                    sbQuery.Append("   , MDFY_DATE = GETDATE()	");
                    sbQuery.Append("   , MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append(" AND WO_NO = @WO_NO			");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
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


        public static void TSHP_WORKORDER_UPD34_1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" UPDATE TSHP_WORKORDER		");
                    sbQuery.Append(" SET   ");
                    sbQuery.Append("    WO_FLAG = @WO_FLAG ");
                    sbQuery.Append("    ,ACT_END_TIME = NULL ");
                    sbQuery.Append("    ,ACT_QTY = 0 ");
                    sbQuery.Append("   , MDFY_DATE = GETDATE()	");
                    sbQuery.Append("   , MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append(" AND WO_NO = @WO_NO			");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
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

        /// <summary>
        /// 가공 파트 기준 설비 그룹 변경(일괄)
        /// </summary>
        /// <param name="dtParam"></param>
        /// <param name="bizExecute"></param>
        public static void TSHP_WORKORDER_UPD35(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" UPDATE TSHP_WORKORDER		");
                    sbQuery.Append(" SET   ");
                    sbQuery.Append("    MC_GROUP = @MC_GROUP ");                    
                    sbQuery.Append("   , MDFY_DATE = GETDATE()	");
                    sbQuery.Append("   , MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append(" AND PT_ID = @PT_ID			");
                    sbQuery.Append(" AND PROC_CODE <> 'P-07'			");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PT_ID")) isHasColumn = false;

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

        public static void TSHP_WORKORDER_UPD35_1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" UPDATE TSHP_WORKORDER		");
                    sbQuery.Append(" SET   ");
                    sbQuery.Append("    MC_GROUP = @MC_GROUP ");
                    sbQuery.Append("   , MDFY_DATE = GETDATE()	");
                    sbQuery.Append("   , MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append(" AND PT_ID = @PT_ID			");
                    sbQuery.Append(" AND RE_WO_NO = @RE_WO_NO			");
                    sbQuery.Append(" AND PROC_CODE <> 'P-07'");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PT_ID")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "RE_WO_NO")) isHasColumn = false;

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
        /// 작업지시 실적 취소 (업데이트)
        /// </summary>
        /// <param name="dtParam"></param>
        /// <param name="bizExecute"></param>

        public static void TSHP_WORKORDER_UPD36(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" UPDATE TSHP_WORKORDER		");
                    sbQuery.Append(" SET   ");
                    sbQuery.Append("    WO_FLAG = @WO_FLAG ");
                    sbQuery.Append("    ,ACT_END_TIME = null ");
                    sbQuery.Append("    ,ACT_QTY = null ");
                    sbQuery.Append("   , MDFY_DATE = GETDATE()	");
                    sbQuery.Append("   , MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append(" AND WO_NO = @WO_NO			");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
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

        public static void TSHP_WORKORDER_UPD37(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" UPDATE TSHP_WORKORDER		");
                    sbQuery.Append(" SET   ");
                    sbQuery.Append("    CHAIN_WO_NO = @CHAIN_WO_NO ");
                    sbQuery.Append("   , CHAIN_EMP = @CHAIN_EMP");
                    sbQuery.Append("   , MDFY_DATE = GETDATE()	");
                    sbQuery.Append("   , MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append(" AND PT_ID = @PT_ID			");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PT_ID")) isHasColumn = false;

                        if (isHasColumn == true)
                        {
                            if (dtParam.Columns.Contains("RE_WO_NO"))
                            {
                                if (row["RE_WO_NO"].ToString() != "")
                                {
                                    sbQuery.Append("  AND RE_WO_NO = @RE_WO_NO  ");
                                }
                                else
                                {
                                    sbQuery.Append("  AND RE_WO_NO IS NULL  ");
                                }
                            }

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

        public static void TSHP_WORKORDER_UPD37_2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" UPDATE TSHP_WORKORDER		");
                    sbQuery.Append(" SET   ");
                    sbQuery.Append("    CHAIN_WO_NO = @CHAIN_WO_NO ");
                    sbQuery.Append("   , IS_PREV_CHAIN = @IS_PREV_CHAIN ");
                    sbQuery.Append("   , MDFY_DATE = GETDATE()	");
                    sbQuery.Append("   , MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append(" AND PT_ID = @PT_ID			");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PT_ID")) isHasColumn = false;

                        if (isHasColumn == true)
                        {
                            if (dtParam.Columns.Contains("RE_WO_NO"))
                            {
                                if (row["RE_WO_NO"].ToString() != "")
                                {
                                    sbQuery.Append("  AND RE_WO_NO = @RE_WO_NO  ");
                                }
                                else
                                {
                                    sbQuery.Append("  AND RE_WO_NO IS NULL  ");
                                }
                            }

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

        public static void TSHP_WORKORDER_UPD38(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" UPDATE TSHP_WORKORDER		");
                    sbQuery.Append(" SET   ");
                    sbQuery.Append("    WO_FLAG = @WO_FLAG ");
                    sbQuery.Append("    ,ACT_START_TIME = @ACT_START_TIME ");
                    sbQuery.Append("    ,ACT_END_TIME = @ACT_END_TIME ");
                    sbQuery.Append("    ,ACT_QTY = @ACT_QTY ");
                    sbQuery.Append("   , MDFY_DATE = GETDATE()	");
                    sbQuery.Append("   , MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append(" AND WO_NO = @WO_NO			");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
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

        public static void TSHP_WORKORDER_UPD39(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" UPDATE TSHP_WORKORDER		");
                    sbQuery.Append(" SET   ");
                    sbQuery.Append("    NG_QTY = @NG_QTY ");
                    sbQuery.Append("   , MDFY_DATE = GETDATE()	");
                    sbQuery.Append("   , MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append(" AND WO_NO = @WO_NO			");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
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

        public static void TSHP_WORKORDER_UPD40(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" UPDATE TSHP_WORKORDER		");
                    sbQuery.Append(" SET   ");
                    sbQuery.Append("    INS_WORK = @INS_WORK ");
                    sbQuery.Append("   , MDFY_DATE = GETDATE()	");
                    sbQuery.Append("   , MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append(" AND WO_NO = @WO_NO			");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
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

        public static void TSHP_WORKORDER_UPD41(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" UPDATE TSHP_WORKORDER		");
                    sbQuery.Append(" SET   ");
                    sbQuery.Append("    WO_FLAG = @WO_FLAG ");
                    sbQuery.Append("   , ACT_START_TIME = NULL ");
                    sbQuery.Append("   , ACT_END_TIME = NULL ");
                    sbQuery.Append("   , ACT_QTY = NULL ");
                    sbQuery.Append("   , MDFY_DATE = GETDATE()	");
                    sbQuery.Append("   , MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append(" AND WO_NO = @WO_NO			");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
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

        public static void TSHP_WORKORDER_UPD42(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TSHP_WORKORDER SET  ");
                    sbQuery.Append(" IS_ORD = '1' ");
                    sbQuery.Append(" ,MDFY_DATE = GETDATE() ");
                    sbQuery.Append(" ,MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append("  AND WO_NO = @WO_NO ");
                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
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

        public static void TSHP_WORKORDER_UPD43(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TSHP_WORKORDER SET  ");
                    sbQuery.Append(" WO_FLAG = @WO_FLAG ");
                    sbQuery.Append(" ,PLN_START_TIME = @PLN_START_TIME ");
                    sbQuery.Append(" ,PLN_END_TIME = @PLN_END_TIME ");
                    sbQuery.Append(" ,PLN_PROC_TIME = @PLN_PROC_TIME ");
                    sbQuery.Append(" ,PLN_PROC_MAN_TIME = @PLN_PROC_MAN_TIME ");
                    sbQuery.Append(" ,IS_OS = @IS_OS ");
                    sbQuery.Append(" ,PART_QTY = @PART_QTY ");
                    sbQuery.Append(" ,PART_ID = @PART_ID ");
                    sbQuery.Append(" ,PROC_ID = @PROC_ID ");
                    sbQuery.Append(" ,IS_ORD = @IS_ORD ");
                    sbQuery.Append(" ,OS_ORD_EMP = @OS_ORD_EMP ");
                    sbQuery.Append(" ,OS_ORD_DATE = @OS_ORD_DATE ");
                    sbQuery.Append(" ,MC_GROUP = @MC_GROUP ");
                    sbQuery.Append(" ,MDFY_DATE = GETDATE() ");
                    sbQuery.Append(" ,MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" ,DEL_DATE = NULL ");
                    sbQuery.Append(" ,DEL_EMP = NULL ");
                    sbQuery.Append(" ,DATA_FLAG = @DATA_FLAG ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append("  AND WO_NO = @WO_NO ");
                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
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

        public static void TSHP_WORKORDER_UPD44(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TSHP_WORKORDER SET  ");
                    sbQuery.Append(" PART_QTY = @PART_QTY ");
                    sbQuery.Append(" ,ACT_QTY = @ACT_QTY ");
                    sbQuery.Append(" ,DATA_FLAG = @DATA_FLAG ");
                    sbQuery.Append(" ,MDFY_DATE = GETDATE() ");
                    sbQuery.Append(" ,MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append("  AND WO_NO = @WO_NO ");
                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
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

        public static void TSHP_WORKORDER_UPD44_1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TSHP_WORKORDER SET  ");
                    sbQuery.Append(" WO_FLAG = @WO_FLAG ");
                    sbQuery.Append(" ,PART_ID = @PART_ID ");
                    sbQuery.Append(" ,PROC_ID = @PROC_ID ");
                    sbQuery.Append(" ,DATA_FLAG = @DATA_FLAG ");
                    sbQuery.Append(" ,MDFY_DATE = GETDATE() ");
                    sbQuery.Append(" ,MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append("  AND WO_NO = @WO_NO ");
                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
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

        public static void TSHP_WORKORDER_UPD45(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TSHP_WORKORDER SET  ");
                    sbQuery.Append(" IS_PREV_CHAIN = @IS_PREV_CHAIN ");
                    sbQuery.Append(" ,MDFY_DATE = GETDATE() ");
                    sbQuery.Append(" ,MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append("  AND PROD_CODE = @PROD_CODE ");
                    sbQuery.Append("  AND PT_ID = @PT_ID ");
                    sbQuery.Append("  AND RE_WO_NO = @RE_WO_NO ");
                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PROD_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PT_ID")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "RE_WO_NO")) isHasColumn = false;

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

        public static void TSHP_WORKORDER_UPD46(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TSHP_WORKORDER SET  ");
                    sbQuery.Append(" PROC_ID = @PROC_ID ");
                    sbQuery.Append(" ,WO_FLAG = @WO_FLAG ");

                    sbQuery.Append(" ,PLN_START_TIME = @PLN_START_TIME ");
                    sbQuery.Append(" ,PLN_END_TIME = @PLN_END_TIME ");
                    sbQuery.Append(" ,PLN_PROC_TIME = @PLN_PROC_TIME ");
                    sbQuery.Append(" ,PLN_PROC_MAN_TIME = @PLN_PROC_MAN_TIME ");

                    sbQuery.Append(" ,DATA_FLAG = @DATA_FLAG ");
                    sbQuery.Append(" ,DES_STOP = 0 ");
                    sbQuery.Append(" ,DES_STOP_CANCEL = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" ,DES_STOP_CANCEL_DATE = GETDATE() ");
                    sbQuery.Append(" ,MDFY_DATE = GETDATE() ");
                    sbQuery.Append(" ,MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append("  AND WO_NO = @WO_NO ");
                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
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

        public static void TSHP_WORKORDER_UPD47(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TSHP_WORKORDER SET  ");
                    sbQuery.Append(" PROC_ID = @PROC_ID ");
                    sbQuery.Append(" ,MDFY_DATE = GETDATE() ");
                    sbQuery.Append(" ,MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append("  AND WO_NO = @WO_NO ");
                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
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

        public static void TSHP_WORKORDER_UPD48(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" UPDATE TSHP_WORKORDER");
                    sbQuery.Append(" SET   PART_QTY = @PART_QTY ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append(" AND WO_NO = @WO_NO");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        bizExecute.executeUpdateQuery(sbQuery.ToString(), row);
                    }
                }
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }


        public static void TSHP_WORKORDER_UPD48_2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" UPDATE TSHP_WORKORDER");
                    sbQuery.Append(" SET   ACT_QTY = @PART_QTY ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append(" AND WO_NO = @WO_NO");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        bizExecute.executeUpdateQuery(sbQuery.ToString(), row);
                    }
                }
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }

        public static void TSHP_WORKORDER_UPD49(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" UPDATE TSHP_WORKORDER");
                    sbQuery.Append(" SET   PROC_ID = @PROC_ID ");
                    sbQuery.Append(" ,   DATA_FLAG = '0' ");
                    sbQuery.Append(" ,   DES_STOP = '0' ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append(" AND WO_NO = @WO_NO");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        bizExecute.executeUpdateQuery(sbQuery.ToString(), row);
                    }
                }
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }
    }

    public class TSHP_WORKORDER_QUERY
    {
        public static DataTable TSHP_WORKORDER_QUERY1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT");
                    sbQuery.Append(" W.PLT_CODE");
                    sbQuery.Append(" ,W.WO_NO");
                    sbQuery.Append(" ,W.PT_ID");
                    sbQuery.Append(" ,W.PROD_CODE");
                    sbQuery.Append(" ,P.PROD_NAME");
                    sbQuery.Append(" ,W.PART_CODE");
                    sbQuery.Append(" ,PT.PART_NAME");
                    sbQuery.Append(" ,W.PROC_CODE");
                    sbQuery.Append(" ,PR.PROC_NAME");
                    sbQuery.Append(" ,W.PART_QTY");
                    //sbQuery.Append(" ,CASE WHEN RE_WO_NO IS NULL THEN '0' ELSE '1' END AS IS_REWORK");

                    sbQuery.Append(" ,CASE WHEN W.RE_WO_NO IS NULL THEN '0'");
                    sbQuery.Append("   ELSE CASE WHEN W.IS_DES_CHANGE = 1 AND ISNULL(W.IS_REMCT, 0) = 0 AND ISNULL(W.IS_MODIFY, 0) = 0 THEN '2' ");
                    sbQuery.Append("             WHEN W.IS_DES_CHANGE = 1 AND ISNULL(W.IS_REMCT, 0) = 0 AND ISNULL(W.IS_MODIFY, 0) = 1 THEN '3'");
                    sbQuery.Append("             WHEN W.IS_DES_CHANGE = 1 AND ISNULL(W.IS_REMCT, 0) = 1 AND ISNULL(W.IS_MODIFY, 0) = 0 THEN '4'");
                    sbQuery.Append("             WHEN N.NG_TYPE = 'P' THEN '5' ELSE '6' END END AS IS_REWORK");

                    sbQuery.Append(" ,PT.MAT_COST");

                    sbQuery.Append(" FROM TSHP_WORKORDER W");
                    sbQuery.Append(" LEFT JOIN LSE_STD_PART PT");
                    sbQuery.Append(" ON W.PLT_CODE = PT.PLT_CODE");
                    sbQuery.Append(" AND W.PART_CODE = PT.PART_CODE");
                    sbQuery.Append(" LEFT JOIN LSE_STD_PROC PR");
                    sbQuery.Append(" ON W.PLT_CODE = PR.PLT_CODE");
                    sbQuery.Append(" AND W.PROC_CODE = PR.PROC_CODE");

                    sbQuery.Append(" LEFT JOIN TSHP_NG N");
                    sbQuery.Append(" ON W.PLT_CODE = N.PLT_CODE");
                    sbQuery.Append(" AND W.RE_WO_NO = N.RE_WO_NO");

                    sbQuery.Append(" LEFT JOIN TORD_PRODUCT P");
                    sbQuery.Append(" ON W.PLT_CODE = P.PLT_CODE");
                    sbQuery.Append(" AND W.PROD_CODE = P.PROD_CODE");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder();

                        sbWhere.Append(" WHERE W.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@WO_NO", "W.WO_NO = @WO_NO"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_CODE", "W.PROD_CODE = @PROD_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_LIKE", "(W.PROD_CODE LIKE '%' + @PROD_LIKE + '%')"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_CODE", "W.PART_CODE = @PART_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_LIKE", "(W.PART_CODE LIKE '%' + @PART_LIKE + '%' OR PT.PART_NAME LIKE '%' + @PART_LIKE + '%')"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PROC_CODE_IN", "W.PROC_CODE IN @PROC_CODE_IN", UTIL.SqlCondType.IN));
                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "W.DATA_FLAG = @DATA_FLAG"));

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

        public static DataTable TSHP_WORKORDER_QUERY2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT W.PLT_CODE");
                    sbQuery.Append(" ,W.WP_NO ");
                    sbQuery.Append(" ,W.WO_NO ");
                    sbQuery.Append(" ,W.PT_ID ");
                    sbQuery.Append(" ,W.PART_CODE");
                    sbQuery.Append(" ,W.PROC_CODE ");
                    sbQuery.Append(" ,W.PART_QTY ");
                    sbQuery.Append(" ,W.PROC_SEQ  ");
                    sbQuery.Append(" ,W.PLN_START_TIME  ");
                    sbQuery.Append(" ,W.PLN_END_TIME  ");
                    sbQuery.Append(" ,W.ACT_START_TIME  ");
                    sbQuery.Append(" ,W.ACT_END_TIME  ");
                    sbQuery.Append(" ,W.ACT_QTY  ");
                    sbQuery.Append(" ,W.WO_FLAG  ");
                    sbQuery.Append(" ,W.IS_OS");
                    sbQuery.Append(" ,W.RE_WO_NO");
                    //sbQuery.Append(" ,CASE WHEN W.RE_WO_NO IS NULL THEN '0' ELSE '1' END AS IS_REWORK");

                    sbQuery.Append(" ,CASE WHEN W.RE_WO_NO IS NULL THEN '0'");
                    sbQuery.Append("   ELSE CASE WHEN W.IS_DES_CHANGE = 1 AND ISNULL(W.IS_REMCT, 0) = 0 AND ISNULL(W.IS_MODIFY, 0) = 0 THEN '2' ");
                    sbQuery.Append("             WHEN W.IS_DES_CHANGE = 1 AND ISNULL(W.IS_REMCT, 0) = 0 AND ISNULL(W.IS_MODIFY, 0) = 1 THEN '3'");
                    sbQuery.Append("             WHEN W.IS_DES_CHANGE = 1 AND ISNULL(W.IS_REMCT, 0) = 1 AND ISNULL(W.IS_MODIFY, 0) = 0 THEN '4'");
                    sbQuery.Append("             WHEN N.NG_TYPE = 'P' THEN '5' ELSE '6' END END AS IS_REWORK");

                    sbQuery.Append(" ,CASE WHEN ISNULL(W.IS_ORD, '0') = '1' THEN '선외주' ELSE '' END AS OS_TYPE");
                    sbQuery.Append(" FROM TSHP_WORKORDER W");
                    //sbQuery.Append(" LEFT JOIN (SELECT PLT_CODE, WO_NO, MAX(DUE_DATE) AS DUE_DATE,SUM(OK_QTY) AS OK_QTY FROM TOUT_PROCBALJU GROUP BY PLT_CODE,WO_NO) B ");
                    //sbQuery.Append(" ON W.PLT_CODE = B.PLT_CODE ");
                    //sbQuery.Append(" AND W.WO_NO = B.WO_NO ");

                    sbQuery.Append(" LEFT JOIN TSHP_NG N");
                    sbQuery.Append(" ON W.PLT_CODE = N.PLT_CODE");
                    sbQuery.Append(" AND W.RE_WO_NO = N.RE_WO_NO");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder();

                        sbWhere.Append(" WHERE W.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@WP_NO", "W.WP_NO = @WP_NO"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_CODE", "W.PROD_CODE = @PROD_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_CODE", "W.PART_CODE = @PART_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PT_ID", "W.PT_ID = @PT_ID"));
                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "W.DATA_FLAG = @DATA_FLAG"));

                        sbWhere.Append(" ORDER BY W.PART_ID, W.PROC_ID");

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


        /// <summary>
        /// 
        /// </summary>
        /// <param name="dtParam"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataTable TSHP_WORKORDER_QUERY3(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT SP.PLT_CODE");
                    sbQuery.Append(" ,CASE WHEN W.WO_NO IS NOT NULL THEN '1' ELSE '0' END SEL ");
                    sbQuery.Append(" ,W.WP_NO");
                    sbQuery.Append(" ,W.WO_NO");
                    sbQuery.Append(" ,S.PART_PRODTYPE");
                    sbQuery.Append(" ,S.PART_NAME");
                    sbQuery.Append(" ,S.STD_PT_NUM ");
                    sbQuery.Append(" ,S.MAT_SPEC");
                    sbQuery.Append(" ,W.PART_CODE");
                    sbQuery.Append(" ,SP.PROC_CODE ");
                    sbQuery.Append(" ,SP.PROC_NAME ");
                    //sbQuery.Append(" ,W.PROC_CODE+':'+W.MC_GROUP AS MC_GROUP ");
                    sbQuery.Append(" ,CASE WHEN SP.WO_TYPE = 'PRC' THEN W.MC_GROUP ELSE NULL END MC_GROUP");
                    sbQuery.Append(" ,CD.CD_NAME AS MC_GROUP_NAME ");
                    sbQuery.Append(" ,W.JOB_PRIORITY ");
                    //sbQuery.Append(" ,W.EMP_CODE");
                    sbQuery.Append(" ,W.MC_GROUP+':'+W.EMP_CODE AS EMP_CODE ");
                    sbQuery.Append(" ,E.EMP_NAME");
                    sbQuery.Append(" ,ISNULL(W.PART_QTY,P.PROD_QTY * PT.PART_QTY * ISNULL(PT.O_PART_QTY, 1)) AS PLN_QTY ");
                    //sbQuery.Append(" ,(SELECT SUM(OK_QTY) FROM TSHP_ACTUAL A WHERE W.PLT_CODE = A.PLT_CODE AND W.WO_NO = A.WO_NO ) AS ACT_QTY");
                    sbQuery.Append(" ,W.ACT_QTY");
                    sbQuery.Append(" ,W.NG_QTY ");
                    sbQuery.Append(" ,WO_FLAG  ");
                    sbQuery.Append(" ,W.PT_ID  ");                    
                    sbQuery.Append(" ,W.SEQ  ");                    
                    sbQuery.Append(" ,SP.PROC_SEQ  ");
                    sbQuery.Append(" ,W.JOB_PRIORITY  ");
                    sbQuery.Append(" ,W.PART_ID  ");
                    sbQuery.Append(" ,W.PROC_ID  ");
                    sbQuery.Append(" ,W.PLN_START_TIME  ");
                    sbQuery.Append(" ,W.PLN_END_TIME  ");
                    sbQuery.Append(" ,W.ACT_START_TIME  ");
                    sbQuery.Append(" ,W.ACT_END_TIME  ");
                    sbQuery.Append(" ,W.SCOMMENT  ");
                    sbQuery.Append(" ,W.CAUTION  ");
                    sbQuery.Append(" ,W.WORK_SCOMMENT  ");
                    sbQuery.Append(" ,SP.IS_OS  ");
                    sbQuery.Append(" ,W.PLN_PROC_TIME  ");
                    sbQuery.Append(" ,W.PLN_STD_TIME ");

                    sbQuery.Append(" ,SP.WO_TYPE ");

                    sbQuery.Append(" FROM LSE_STD_PROC SP ");
                    sbQuery.Append(" LEFT JOIN TMAT_PARTLIST PT ");
                    sbQuery.Append(" ON SP.PLT_CODE = PT.PLT_CODE ");                    
                    sbQuery.Append(" AND PT.PT_ID = @PT_ID ");
                    sbQuery.Append(" AND PT.DATA_FLAG = 0 ");
                    
                    sbQuery.Append(" LEFT JOIN TORD_PRODUCT P ");
                    sbQuery.Append(" ON PT.PLT_CODE = P.PLT_CODE ");
                    sbQuery.Append(" AND PT.PROD_CODE = P.PROD_CODE ");
                    
                    sbQuery.Append(" LEFT JOIN TSHP_WORKORDER W ");
                    sbQuery.Append(" ON W.PLT_CODE = SP.PLT_CODE ");
                    sbQuery.Append(" AND W.PROC_CODE = SP.PROC_CODE ");
                    sbQuery.Append(" AND W.DATA_FLAG = 0 ");
                    sbQuery.Append(" AND W.PT_ID = PT.PT_ID ");

                    if (dtParam.Rows[0]["RE_WO_NO"].toStringEmpty() != "")
                    {
                        sbQuery.Append(" AND W.RE_WO_NO = @RE_WO_NO ");
                    }
                    else
                    {
                        sbQuery.Append(" AND W.RE_WO_NO IS NULL ");
                    }
                    
                    sbQuery.Append(" LEFT JOIN LSE_STD_PART S ON W.PLT_CODE = S.PLT_CODE AND  W.PART_CODE = S.PART_CODE  ");                    
                    //sbQuery.Append(" LEFT JOIN LSE_MACHINE M ON W.PLT_CODE = M.PLT_CODE AND W.MC_CODE = M.MC_CODE ");
                    
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE E ON W.PLT_CODE = E.PLT_CODE AND W.EMP_CODE = E.EMP_CODE ");
                    
                    sbQuery.Append(" LEFT JOIN TSTD_CODES CD ON W.PLT_CODE = CD.PLT_CODE AND W.MC_GROUP = CD.CD_CODE AND CD.CAT_CODE = 'C020' ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder();

                        sbWhere.Append(" WHERE SP.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                        //sbWhere.Append(UTIL.GetWhere(row, "@PT_ID", "PT.PT_ID = @PT_ID "));

                        //sbWhere.Append(UTIL.GetWhere(row, "@PROC_CODE", "W.PROC_CODE = @PROC_CODE"));

                        //sbWhere.Append(UTIL.GetWhere(row, "@WO_NO", "W.WO_NO = @WO_NO"));

                        //sbWhere.Append(UTIL.GetWhere(row, "@PROD_CODE", "W.PROD_CODE = @PROD_CODE"));

                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "SP.DATA_FLAG = @DATA_FLAG"));
                        sbWhere.Append(" ORDER BY SP.PROC_SEQ");

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

        /// <summary>
        /// 작업지시 가져오기
        /// </summary>
        /// <param name="dtParam"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataTable TSHP_WORKORDER_QUERY4(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT W.PLT_CODE");
                    sbQuery.Append(" ,W.WP_NO");
                    sbQuery.Append(" ,W.WO_NO");
                    sbQuery.Append(" ,S.PART_PRODTYPE");
                    sbQuery.Append(" ,TP.ITEM_CODE");
                    sbQuery.Append(" ,W.PROD_CODE");
                    sbQuery.Append(" ,TP.PROD_NAME");
                    sbQuery.Append(" ,W.PART_CODE");
                    sbQuery.Append(" ,S.PART_NAME");
                    sbQuery.Append(" ,S.STD_PT_NUM ");
                    sbQuery.Append(" ,ISNULL(SP.IS_MAT, 0) IS_MAT");
                    sbQuery.Append(" ,ISNULL(SP.IS_OS, 0) IS_OS");
                    sbQuery.Append(" ,S.MAT_SPEC");
                    sbQuery.Append(" ,S.MAT_SPEC1");
                    sbQuery.Append(" ,S.BAL_SPEC");
                    sbQuery.Append(" ,S.BAL_WEIGHT");
                    sbQuery.Append(" ,S.DRAW_NO");
                    sbQuery.Append(" ,W.PROC_CODE ");
                    sbQuery.Append(" ,W.PROC_SEQ  ");
                    sbQuery.Append(" ,SP.PROC_NAME ");
                    sbQuery.Append(" ,W.MC_CODE ");
                    sbQuery.Append(" ,M.MC_NAME ");
                    sbQuery.Append(" ,W.MC_GROUP ");
                    sbQuery.Append(" ,W.EMP_CODE");
                    sbQuery.Append(" ,E.EMP_NAME");
                    sbQuery.Append(" ,W.PART_QTY AS PLN_QTY ");
                    sbQuery.Append(" ,(SELECT ISNULL(SUM(OK_QTY),0) FROM TSHP_ACTUAL A WHERE W.PLT_CODE = A.PLT_CODE AND W.WO_NO = A.WO_NO ) AS ACT_QTY");
                    sbQuery.Append(" ,(SELECT ISNULL(SUM(NG_QTY),0) FROM TSHP_ACTUAL A WHERE W.PLT_CODE = A.PLT_CODE AND W.WO_NO = A.WO_NO ) AS NG_QTY");
                    sbQuery.Append(" ,W.WO_FLAG  ");
                    sbQuery.Append(" ,dbo.fnCharToDate(W.PLN_START_TIME) AS PLN_START  ");
                    sbQuery.Append(" ,dbo.fnCharToDate(W.PLN_END_TIME) AS PLN_END ");
                    sbQuery.Append(" ,W.PLN_START_TIME  ");
                    sbQuery.Append(" ,W.PLN_END_TIME  ");
                    sbQuery.Append(" ,W.ACT_START_TIME  ");
                    sbQuery.Append(" ,W.ACT_END_TIME  ");
                    sbQuery.Append(" ,W.CAUTION  ");
                    sbQuery.Append(" ,W.JOB_PRIORITY  ");
                    sbQuery.Append(" ,W.WORK_CODE  ");
                    sbQuery.Append(" ,SP.IS_MAT  ");
                    sbQuery.Append(" ,W.CAM_EMP  ");
                    sbQuery.Append(" ,W.CAM_DATE  ");
                    sbQuery.Append(" ,W.PLN_PROC_TIME  ");
                    sbQuery.Append(" ,PL.SCOMMENT  ");
                    sbQuery.Append(" ,TP.PROD_PRIORITY");
                    sbQuery.Append(" FROM TSHP_WORKORDER W ");
                    sbQuery.Append(" LEFT JOIN TORD_PRODUCT TP ON TP.PLT_CODE = W.PLT_CODE AND TP.PROD_CODE = W.PROD_CODE ");
                    sbQuery.Append("  JOIN LSE_STD_PART S ON W.PLT_CODE = S.PLT_CODE AND  W.PART_CODE = S.PART_CODE  ");
                    sbQuery.Append("  JOIN LSE_STD_PROC SP ON W.PLT_CODE = SP.PLT_CODE AND W.PROC_CODE = SP.PROC_CODE ");
                    sbQuery.Append("  JOIN TMAT_PARTLIST PL ON W.PLT_CODE = PL.PLT_CODE AND W.PART_CODE = PL.PART_CODE AND W.PROD_CODE = PL.PROD_CODE AND W.PT_ID = PL.PT_ID ");
                    sbQuery.Append(" LEFT JOIN LSE_MACHINE M ON W.PLT_CODE = M.PLT_CODE AND W.MC_CODE = M.MC_CODE ");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE E ON W.PLT_CODE = E.PLT_CODE AND W.EMP_CODE = E.EMP_CODE ");
                


                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder();

                        sbWhere.Append(" WHERE W.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                        sbWhere.Append(UTIL.GetWhere(row, "@WO_NO", "W.WO_NO = @WO_NO"));                        
                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_CODE", "W.PROD_CODE = @PROD_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_CODE", "W.PART_CODE = @PART_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@MC_CODE", "W.MC_CODE = @MC_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PROC_CODE", "W.PROC_CODE = @PROC_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@EMP_CODE", "W.EMP_CODE = @EMP_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "W.DATA_FLAG = @DATA_FLAG"));
                        sbWhere.Append(" ORDER BY W.JOB_PRIORITY, W.PART_CODE, W.PT_ID, W.RE_WO_NO ,W.PART_ID, W.PROC_ID");

                        DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString() + sbWhere.ToString(), row).Copy();

                        sourceTable.TableName = "RSLTDT";
                        dsResult.Merge(sourceTable, false, MissingSchemaAction.Add);
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
        ///  단말기 작업지시 불러오기 [가공] 21.05.12
        /// </summary>
        /// <param name="dtParam"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataTable TSHP_WORKORDER_QUERY4_1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED"); 
                    sbQuery.Append(" SELECT W.PLT_CODE");
                    sbQuery.Append(" ,W.PT_ID");
                    sbQuery.Append(" ,W.CHAIN_WO_NO");
                    sbQuery.Append(" ,W.WO_NO");
                    sbQuery.Append(" ,W.PROD_CODE ");
                    sbQuery.Append(" ,P.PROD_NAME "); 
                    sbQuery.Append(" ,W.PART_CODE");
                    sbQuery.Append(" ,S.PART_NAME");
                    sbQuery.Append(" ,S.MAT_SPEC ");
                    sbQuery.Append(" ,S.MAT_SPEC1");
                    sbQuery.Append(" ,W.PROC_CODE ");
                    sbQuery.Append(" ,SP.PROC_NAME ");
                    sbQuery.Append(" ,P.PROD_FLAG "); 
                    sbQuery.Append(" ,P.PROD_CATEGORY "); 
                    sbQuery.Append(" ,W.MC_CODE ");
                    sbQuery.Append(" ,W.MC_GROUP ");
                    sbQuery.Append(" ,W.EMP_CODE ");
                    sbQuery.Append(" ,S.DRAW_NO ");
                    sbQuery.Append(" ,W.PART_QTY ");
                    sbQuery.Append(" ,W.WO_FLAG  ");  
                    sbQuery.Append(" ,W.PART_QTY ");
                    sbQuery.Append(" ,W.WORK_SCOMMENT ");
                    sbQuery.Append(" ,P.PROD_PRIORITY ");
                    sbQuery.Append(" ,(SELECT ISNULL(SUM(OK_QTY),0) FROM TSHP_ACTUAL A WHERE W.PLT_CODE = A.PLT_CODE AND W.WO_NO = A.WO_NO) AS ACT_QTY");
                    sbQuery.Append(" ,(SELECT ISNULL(SUM(PLN_QTY),0) FROM TSHP_ACTUAL A WHERE W.PLT_CODE = A.PLT_CODE AND W.WO_NO = A.WO_NO AND A.ACT_END_TIME IS NULL) AS ING_QTY");
                    sbQuery.Append(" ,(SELECT STUFF((SELECT ',' + AE.EMP_NAME + ':' + AE.MC_NAME + '(' + AE.MC_CODE + ')' " +
                                                   "FROM (SELECT E.EMP_NAME,A.MC_CODE, M.MC_NAME FROM TSHP_ACTUAL A " +
                                                   "LEFT JOIN TSTD_EMPLOYEE E " +
                                                   "ON A.PLT_CODE = E.PLT_CODE AND A.EMP_CODE = E.EMP_CODE " +
                                                   "LEFT JOIN LSE_MACHINE M " +
                                                   "ON A.PLT_CODE = M.PLT_CODE AND A.MC_CODE = M.MC_CODE " +
                                                   "WHERE W.PLT_CODE = A.PLT_CODE AND W.WO_NO = A.WO_NO AND A.ACT_END_TIME IS NULL AND W.WO_FLAG = '2') AE " +
                                                   "FOR XML PATH('')),1,1,'')) AS ING_EMP  "); // 현재 작업을 진행중인 조업자 
                    sbQuery.Append(" ,P.CVND_CODE  ");
                    sbQuery.Append(" ,AC.X_VALUE  ");
                    sbQuery.Append(" ,AC.Y_VALUE  ");
                    sbQuery.Append(" ,AC.T_VALUE  ");
                    sbQuery.Append(" ,AC.MAT_CODE AS CAM_MAT_CODE ");
                    sbQuery.Append(" ,SC.PART_NAME AS CAM_MAT_NAME  ");
                    sbQuery.Append(" ,AC.EMP_CODE AS CAM_EMP  ");
                    sbQuery.Append(" ,AE.EMP_NAME AS CAM_EMP_NAME  ");
                    sbQuery.Append(" ,W.CAUTION  ");
                    sbQuery.Append(" ,W.PLN_START_TIME  ");
                    sbQuery.Append(" ,W.PLN_END_TIME  ");
                    sbQuery.Append(" ,P.DUE_DATE  ");

                    sbQuery.Append(" ,ISNULL(AM.MAT_CODE,AC.MAT_CODE) AS MILL_MAT_CODE ");
                    sbQuery.Append(" ,SM.PART_NAME AS MILL_MAT_NAME  ");
                    sbQuery.Append(" ,AC.MAT_QLTY ");

                    sbQuery.Append(" ,QLTY.MQLTY_NAME AS MAT_QLTY_NAME ");
                    //sbQuery.Append(" ,PT.SCOMMENT");
                    sbQuery.Append(" ,AC.SCOMMENT");
                    //sbQuery.Append(" ,CASE WHEN W.RE_WO_NO IS NULL THEN '0' ELSE '1' END IS_REWORK  ");

                    sbQuery.Append(" ,CASE WHEN W.RE_WO_NO IS NULL THEN '0'");
                    sbQuery.Append("   ELSE CASE WHEN W.IS_DES_CHANGE = 1 AND ISNULL(W.IS_REMCT, 0) = 0 AND ISNULL(W.IS_MODIFY, 0) = 0 THEN '2' ");
                    sbQuery.Append("             WHEN W.IS_DES_CHANGE = 1 AND ISNULL(W.IS_REMCT, 0) = 0 AND ISNULL(W.IS_MODIFY, 0) = 1 THEN '3'");
                    sbQuery.Append("             WHEN W.IS_DES_CHANGE = 1 AND ISNULL(W.IS_REMCT, 0) = 1 AND ISNULL(W.IS_MODIFY, 0) = 0 THEN '4'");
                    sbQuery.Append("             WHEN N.NG_TYPE = 'P' THEN '5' ELSE '6' END END AS IS_REWORK");

                    sbQuery.Append(" FROM TSHP_WORKORDER W         ");

                    //sbQuery.Append(" LEFT JOIN (SELECT A.PLT_CODE, A.PT_ID, A.WO_FLAG FROM TSHP_WORKORDER A ");
                    //sbQuery.Append(" LEFT JOIN LSE_STD_PROC B ON A.PLT_CODE = B.PLT_CODE AND A.PROC_CODE = B.PROC_CODE ");
                    //sbQuery.Append(" WHERE B.WO_TYPE = 'MIL' GROUP BY A.PLT_CODE, A.PT_ID, A.WO_FLAG ) ML ");
                    //sbQuery.Append(" ON W.PLT_CODE = ML.PLT_CODE   ");
                    //sbQuery.Append(" AND W.PT_ID = ML.PT_ID        ");

                    sbQuery.Append(" 	LEFT JOIN TSHP_WORKORDER PRE_W   ");
                    sbQuery.Append(" 		ON W.PLT_CODE = PRE_W.PLT_CODE      ");
                    sbQuery.Append(" 		AND W.PT_ID = PRE_W.PT_ID           ");
                    sbQuery.Append(" 		AND W.PROD_CODE = PRE_W.PROD_CODE   ");
                    sbQuery.Append(" 		AND W.PART_CODE = PRE_W.PART_CODE   ");
                    sbQuery.Append(" 		AND ISNULL(W.PROC_ID,0) - 1 = PRE_W.PROC_ID   ");
                    sbQuery.Append(" 		AND ISNULL(W.RE_WO_NO,'1') = ISNULL(PRE_W.RE_WO_NO,'1')  ");

                    sbQuery.Append(" LEFT JOIN TSHP_ACTUAL_CAM AC  ");
                    sbQuery.Append(" ON W.PLT_CODE = AC.PLT_CODE  ");
                    sbQuery.Append(" AND W.PT_ID = AC.PT_ID        ");
                    sbQuery.Append(" AND ISNULL(W.RE_WO_NO,'1') = ISNULL(AC.RE_WO_NO,'1')  ");

                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE AE      ");
                    sbQuery.Append(" ON AC.PLT_CODE = AE.PLT_CODE    ");
                    sbQuery.Append(" AND AC.EMP_CODE = AE.EMP_CODE ");

                    sbQuery.Append(" LEFT JOIN TSHP_ACTUAL_MILL AM  ");
                    sbQuery.Append(" ON W.PLT_CODE = AM.PLT_CODE  ");
                    sbQuery.Append(" AND W.PT_ID = AM.PT_ID        ");
                    sbQuery.Append(" AND ISNULL(W.RE_WO_NO,'1') = ISNULL(AM.RE_WO_NO,'1')  ");

                    sbQuery.Append(" LEFT JOIN TORD_PRODUCT P      ");
                    sbQuery.Append(" ON W.PLT_CODE = P.PLT_CODE    ");
                    sbQuery.Append(" AND W.PROD_CODE = P.PROD_CODE ");

                    sbQuery.Append(" LEFT JOIN LSE_STD_PART S       ");
                    sbQuery.Append(" ON W.PLT_CODE = S.PLT_CODE     ");
                    sbQuery.Append(" AND  W.PART_CODE = S.PART_CODE ");

                    sbQuery.Append(" LEFT JOIN LSE_STD_PART SC       ");
                    sbQuery.Append(" ON AC.PLT_CODE = SC.PLT_CODE     ");
                    sbQuery.Append(" AND  AC.MAT_CODE = SC.PART_CODE ");

                    sbQuery.Append(" LEFT JOIN LSE_STD_PART SM       ");
                    sbQuery.Append(" ON AM.PLT_CODE = SM.PLT_CODE     ");
                    sbQuery.Append(" AND  AM.MAT_CODE = SM.PART_CODE ");

                    sbQuery.Append(" LEFT JOIN LSE_STD_PROC SP      ");
                    sbQuery.Append(" ON W.PLT_CODE = SP.PLT_CODE    ");
                    sbQuery.Append(" AND W.PROC_CODE = SP.PROC_CODE ");

                    sbQuery.Append("LEFT JOIN TMAT_QUC_MASTER QLTY ");
                    sbQuery.Append("ON S.PLT_CODE = QLTY.PLT_CODE  ");
                    sbQuery.Append(" AND S.MAT_QLTY = QLTY.MQLTY_CODE ");

                    sbQuery.Append("LEFT JOIN TMAT_PARTLIST PT ");
                    sbQuery.Append("ON W.PLT_CODE = PT.PLT_CODE  ");
                    sbQuery.Append("AND W.PT_ID = PT.PT_ID ");

                    sbQuery.Append(" LEFT JOIN TSHP_NG N");
                    sbQuery.Append(" ON W.PLT_CODE = N.PLT_CODE");
                    sbQuery.Append(" AND W.RE_WO_NO = N.RE_WO_NO");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder();

                        sbWhere.Append(" WHERE W.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        string where = "";

                        sbWhere.Append(UTIL.GetWhere(row, "@MC_GROUP", "W.MC_GROUP = @MC_GROUP ")); //설비그룹 
                        where += " " + UTIL.GetWhere(row, "@MC_GROUP", "W.MC_GROUP = @MC_GROUP ");

                       // sbWhere.Append(UTIL.GetWhere(row, "@MC_CODE", "W.MC_CODE = @MC_CODE ")); 
                        sbWhere.Append(UTIL.GetWhere(row, "@WO_TYPE", "SP.WO_TYPE = @WO_TYPE "));
                        where += " " + UTIL.GetWhere(row, "@WO_TYPE", "SP.WO_TYPE = @WO_TYPE ");

                        sbWhere.Append(UTIL.GetWhere(row, "@PROC_STAT", "W.PROC_STAT = @PROC_STAT "));
                        where += " " + UTIL.GetWhere(row, "@PROC_STAT", "W.PROC_STAT = @PROC_STAT ");

                        //sbWhere.Append(UTIL.GetWhere(row, "@WO_FLAG", "ML.WO_FLAG = @WO_FLAG "));
                        sbWhere.Append(UTIL.GetWhere(row, "@WO_FLAG", "PRE_W.WO_FLAG = @WO_FLAG "));    //이전공정의 상태
                        where += " " + UTIL.GetWhere(row, "@WO_FLAG", "PRE_W.WO_FLAG = @WO_FLAG ");

                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "W.DATA_FLAG = @DATA_FLAG "));
                        where += " " + UTIL.GetWhere(row, "@DATA_FLAG", "W.DATA_FLAG = @DATA_FLAG ");


                        // 작업상태가 [확정,진행,중지]인것만 표시 
                        string cond1 = " AND  W.WO_FLAG IN  ('1', '2', '3')  ";


                        // 작업상태가 완료인것도 포함 
                        string cond2 = " AND  W.WO_FLAG IN  ('1', '2', '3' )";
                        cond2 += " OR  (W.WO_FLAG = '4' " + where + UTIL.GetWhere(row, "@S_FIN_DATE,@E_FIN_DATE", "CONVERT(VARCHAR(8), W.ACT_END_TIME, 112) BETWEEN @S_FIN_DATE AND @E_FIN_DATE ") + ")";
                        // cond2 += "  OR (WO_FLAG = '4' AND dbo.fn_dm_date(ACT_END_TIME) = CONVERT(varchar, GETDATE(), 112))  )  ";
                     

                        if (row["IS_FINISH"].toBoolean() == false)
                        {
                            //완료작업 미포함
                            sbWhere.Append(cond1);
                        }
                        else
                        {
                            // 완료작업포함
                            sbWhere.Append(cond2);

                            //sbWhere.Append(UTIL.GetWhere(row, "@S_FIN_DATE,@E_FIN_DATE", "CONVERT(VARCHAR(8), W.ACT_END_TIME, 112) BETWEEN @S_FIN_DATE AND @E_FIN_DATE "));
                        }


                        //// 그리드뷰에 진행,정지,완료,확정 순서로 정렬
                        //sbWhere.Append(" ORDER BY CASE WHEN W.WO_FLAG = '2' THEN 1 " +
                        //                              "WHEN W.WO_FLAG = '3' THEN 2 " +
                        //                              "WHEN W.WO_FLAG = '4' THEN 3 " +
                        //                              "WHEN W.WO_FLAG = '1' THEN 4 " +
                        //                              "END ASC; ");

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

        public static DataTable TSHP_WORKORDER_QUERY4_2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT W.PLT_CODE");
                    sbQuery.Append(" ,W.PT_ID");
                    sbQuery.Append(" ,W.CHAIN_WO_NO");
                    sbQuery.Append(" ,W.WO_NO");
                    sbQuery.Append(" ,W.PROD_CODE ");
                    sbQuery.Append(" ,P.PROD_NAME ");
                    sbQuery.Append(" ,W.PART_CODE");
                    sbQuery.Append(" ,S.PART_NAME");
                    sbQuery.Append(" ,S.MAT_SPEC ");
                    sbQuery.Append(" ,S.MAT_SPEC1");
                    sbQuery.Append(" ,W.PROC_CODE ");
                    sbQuery.Append(" ,SP.PROC_NAME ");
                    sbQuery.Append(" ,P.PROD_FLAG ");
                    sbQuery.Append(" ,P.PROD_CATEGORY ");
                    sbQuery.Append(" ,W.MC_CODE ");
                    sbQuery.Append(" ,W.MC_GROUP ");
                    sbQuery.Append(" ,W.EMP_CODE ");
                    sbQuery.Append(" ,S.DRAW_NO ");
                    sbQuery.Append(" ,W.PART_QTY ");
                    sbQuery.Append(" ,W.WO_FLAG  ");
                    sbQuery.Append(" ,W.PART_QTY ");
                    sbQuery.Append(" ,W.WORK_SCOMMENT ");
                    sbQuery.Append(" ,P.PROD_PRIORITY ");
                    sbQuery.Append(" ,(SELECT ISNULL(SUM(OK_QTY),0) FROM TSHP_ACTUAL A WHERE W.PLT_CODE = A.PLT_CODE AND W.WO_NO = A.WO_NO) AS ACT_QTY");
                    sbQuery.Append(" ,(SELECT ISNULL(SUM(PLN_QTY),0) FROM TSHP_ACTUAL A WHERE W.PLT_CODE = A.PLT_CODE AND W.WO_NO = A.WO_NO AND A.ACT_END_TIME IS NULL) AS ING_QTY");
                    sbQuery.Append(" ,(SELECT STUFF((SELECT ',' + AE.EMP_NAME + ':' + AE.MC_NAME + '(' + AE.MC_CODE + ')' " +
                                                   "FROM (SELECT E.EMP_NAME,A.MC_CODE, M.MC_NAME FROM TSHP_ACTUAL A " +
                                                   "LEFT JOIN TSTD_EMPLOYEE E " +
                                                   "ON A.PLT_CODE = E.PLT_CODE AND A.EMP_CODE = E.EMP_CODE " +
                                                   "LEFT JOIN LSE_MACHINE M " +
                                                   "ON A.PLT_CODE = M.PLT_CODE AND A.MC_CODE = M.MC_CODE " +
                                                   "WHERE W.PLT_CODE = A.PLT_CODE AND W.WO_NO = A.WO_NO AND A.ACT_END_TIME IS NULL AND W.WO_FLAG = '2') AE " +
                                                   "FOR XML PATH('')),1,1,'')) AS ING_EMP  "); // 현재 작업을 진행중인 조업자 
                    sbQuery.Append(" ,P.CVND_CODE  ");
                    sbQuery.Append(" ,AC.X_VALUE  ");
                    sbQuery.Append(" ,AC.Y_VALUE  ");
                    sbQuery.Append(" ,AC.T_VALUE  ");
                    sbQuery.Append(" ,AC.MAT_CODE AS CAM_MAT_CODE ");
                    sbQuery.Append(" ,SC.PART_NAME AS CAM_MAT_NAME  ");
                    sbQuery.Append(" ,AC.EMP_CODE AS CAM_EMP  ");
                    sbQuery.Append(" ,AE.EMP_NAME AS CAM_EMP_NAME  ");
                    sbQuery.Append(" ,W.CAUTION  ");
                    sbQuery.Append(" ,W.PLN_START_TIME  ");
                    sbQuery.Append(" ,W.PLN_END_TIME  ");
                    sbQuery.Append(" ,P.DUE_DATE  ");

                    sbQuery.Append(" ,ISNULL(AM.MAT_CODE,AC.MAT_CODE) AS MILL_MAT_CODE ");
                    sbQuery.Append(" ,SM.PART_NAME AS MILL_MAT_NAME  ");
                    sbQuery.Append(" ,AC.MAT_QLTY ");

                    sbQuery.Append(" ,QLTY.MQLTY_NAME AS MAT_QLTY_NAME ");
                    sbQuery.Append(" ,PT.SCOMMENT");
                    //sbQuery.Append(" ,CASE WHEN W.RE_WO_NO IS NULL THEN '0' ELSE '1' END IS_REWORK  ");

                    sbQuery.Append(" ,CASE WHEN W.RE_WO_NO IS NULL THEN '0'");
                    sbQuery.Append("   ELSE CASE WHEN W.IS_DES_CHANGE = 1 AND ISNULL(W.IS_REMCT, 0) = 0 AND ISNULL(W.IS_MODIFY, 0) = 0 THEN '2' ");
                    sbQuery.Append("             WHEN W.IS_DES_CHANGE = 1 AND ISNULL(W.IS_REMCT, 0) = 0 AND ISNULL(W.IS_MODIFY, 0) = 1 THEN '3'");
                    sbQuery.Append("             WHEN W.IS_DES_CHANGE = 1 AND ISNULL(W.IS_REMCT, 0) = 1 AND ISNULL(W.IS_MODIFY, 0) = 0 THEN '4'");
                    sbQuery.Append("             WHEN N.NG_TYPE = 'P' THEN '5' ELSE '6' END END AS IS_REWORK");

                    sbQuery.Append(" FROM TSHP_WORKORDER W         ");

                    //sbQuery.Append(" LEFT JOIN (SELECT A.PLT_CODE, A.PT_ID, A.WO_FLAG FROM TSHP_WORKORDER A ");
                    //sbQuery.Append(" LEFT JOIN LSE_STD_PROC B ON A.PLT_CODE = B.PLT_CODE AND A.PROC_CODE = B.PROC_CODE ");
                    //sbQuery.Append(" WHERE B.WO_TYPE = 'MIL' GROUP BY A.PLT_CODE, A.PT_ID, A.WO_FLAG ) ML ");
                    //sbQuery.Append(" ON W.PLT_CODE = ML.PLT_CODE   ");
                    //sbQuery.Append(" AND W.PT_ID = ML.PT_ID        ");

                    sbQuery.Append(" 	LEFT JOIN TSHP_WORKORDER PRE_W   ");
                    sbQuery.Append(" 		ON W.PLT_CODE = PRE_W.PLT_CODE      ");
                    sbQuery.Append(" 		AND W.PT_ID = PRE_W.PT_ID           ");
                    sbQuery.Append(" 		AND W.PROD_CODE = PRE_W.PROD_CODE   ");
                    sbQuery.Append(" 		AND W.PART_CODE = PRE_W.PART_CODE   ");
                    sbQuery.Append(" 		AND ISNULL(W.PROC_ID,0) - 1 = PRE_W.PROC_ID   ");
                    sbQuery.Append(" 		AND ISNULL(W.RE_WO_NO,'1') = ISNULL(PRE_W.RE_WO_NO,'1')  ");

                    sbQuery.Append(" LEFT JOIN TSHP_ACTUAL_CAM AC  ");
                    sbQuery.Append(" ON W.PLT_CODE = AC.PLT_CODE  ");
                    sbQuery.Append(" AND W.PT_ID = AC.PT_ID        ");
                    sbQuery.Append(" AND ISNULL(W.RE_WO_NO,'1') = ISNULL(AC.RE_WO_NO,'1')  ");

                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE AE      ");
                    sbQuery.Append(" ON AC.PLT_CODE = AE.PLT_CODE    ");
                    sbQuery.Append(" AND AC.EMP_CODE = AE.EMP_CODE ");

                    sbQuery.Append(" LEFT JOIN TSHP_ACTUAL_MILL AM  ");
                    sbQuery.Append(" ON W.PLT_CODE = AM.PLT_CODE  ");
                    sbQuery.Append(" AND W.PT_ID = AM.PT_ID        ");
                    sbQuery.Append(" AND ISNULL(W.RE_WO_NO,'1') = ISNULL(AM.RE_WO_NO,'1')  ");

                    sbQuery.Append(" LEFT JOIN TORD_PRODUCT P      ");
                    sbQuery.Append(" ON W.PLT_CODE = P.PLT_CODE    ");
                    sbQuery.Append(" AND W.PROD_CODE = P.PROD_CODE ");

                    sbQuery.Append(" LEFT JOIN LSE_STD_PART S       ");
                    sbQuery.Append(" ON W.PLT_CODE = S.PLT_CODE     ");
                    sbQuery.Append(" AND  W.PART_CODE = S.PART_CODE ");

                    sbQuery.Append(" LEFT JOIN LSE_STD_PART SC       ");
                    sbQuery.Append(" ON AC.PLT_CODE = SC.PLT_CODE     ");
                    sbQuery.Append(" AND  AC.MAT_CODE = SC.PART_CODE ");

                    sbQuery.Append(" LEFT JOIN LSE_STD_PART SM       ");
                    sbQuery.Append(" ON AM.PLT_CODE = SM.PLT_CODE     ");
                    sbQuery.Append(" AND  AM.MAT_CODE = SM.PART_CODE ");

                    sbQuery.Append(" LEFT JOIN LSE_STD_PROC SP      ");
                    sbQuery.Append(" ON W.PLT_CODE = SP.PLT_CODE    ");
                    sbQuery.Append(" AND W.PROC_CODE = SP.PROC_CODE ");

                    sbQuery.Append("LEFT JOIN TMAT_QUC_MASTER QLTY ");
                    sbQuery.Append("ON S.PLT_CODE = QLTY.PLT_CODE  ");
                    sbQuery.Append(" AND S.MAT_QLTY = QLTY.MQLTY_CODE ");

                    sbQuery.Append("LEFT JOIN TMAT_PARTLIST PT ");
                    sbQuery.Append("ON W.PLT_CODE = PT.PLT_CODE  ");
                    sbQuery.Append("AND W.PT_ID = PT.PT_ID ");

                    sbQuery.Append(" LEFT JOIN TSHP_NG N");
                    sbQuery.Append(" ON W.PLT_CODE = N.PLT_CODE");
                    sbQuery.Append(" AND W.RE_WO_NO = N.RE_WO_NO");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder();

                        sbWhere.Append(" WHERE W.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                        sbWhere.Append(UTIL.GetWhere(row, "@WO_NO", "W.WO_NO = @WO_NO "));
                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "W.DATA_FLAG = @DATA_FLAG "));
                        
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



        ////20160520 김준구 - 단말기 작업지시 조회(일)
        //public static DataTable TSHP_WORKORDER_QUERY5(DataTable dtParam, BizExecute.BizExecute bizExecute)
        //{
        //    try
        //    {
        //        DataSet dsResult = new DataSet();

        //        if (dtParam.Rows.Count > 0)
        //        {
        //            StringBuilder sbQuery = new StringBuilder();

        //            sbQuery.Append(" SELECT W.PLT_CODE");
        //            sbQuery.Append(" ,W.WO_NO");
        //            sbQuery.Append(" ,W.PROD_CODE ");
        //            sbQuery.Append(" ,S.PART_PRODTYPE");
        //            sbQuery.Append(" ,S.PART_NAME");
        //            sbQuery.Append(" ,S.STD_PT_NUM ");
        //            sbQuery.Append(" ,S.MAT_SPEC");
        //            sbQuery.Append(" ,S.MAT_SPEC1");
        //            sbQuery.Append(" ,P.ITEM_CODE");
        //            sbQuery.Append(" ,W.PART_CODE");
        //            sbQuery.Append(" ,W.PROC_CODE ");
        //            sbQuery.Append(" ,SP.PROC_NAME ");
        //            sbQuery.Append(" ,W.MC_CODE ");
        //            sbQuery.Append(" ,W.EMP_CODE ");
        //            sbQuery.Append(" ,S.DRAW_NO ");
        //            sbQuery.Append(" ,W.PART_QTY ");
        //            sbQuery.Append(" ,(SELECT SUM(OK_QTY) FROM TSHP_ACTUAL A WHERE W.PLT_CODE = A.PLT_CODE AND W.WO_NO = A.WO_NO ) AS ACT_QTY");
        //            sbQuery.Append(" ,WO_FLAG  ");
        //            sbQuery.Append(" ,W.SEQ  ");
        //            sbQuery.Append(" ,W.PROC_SEQ  ");
        //            sbQuery.Append(" ,W.JOB_PRIORITY  ");
        //            sbQuery.Append(" ,I.CVND_CODE  ");
        //            sbQuery.Append(" ,V.VEN_NAME AS CVND_NAME  ");
        //            sbQuery.Append(" ,W.SCOMMENT  ");
        //            sbQuery.Append(" ,WP.SCOMMENT AS WP_SCOMMENT ");
        //            //sbQuery.Append(" ,CASE ISNULL(FM.LINK_KEY, '') WHEN '' THEN 'X' ELSE 'O' END colATTACH   ");
        //            //sbQuery.Append(" ,FM.LINK_KEY ");

        //            sbQuery.Append(" ,CASE WHEN ISNULL(S.ATT_QTY, 0) > 0 THEN 'O' ELSE 'X' END colATTACH   ");
        //            sbQuery.Append(" ,S.ATT_QTY ");

        //            sbQuery.Append(" ,W.PLN_START_TIME");
        //            sbQuery.Append(" ,W.PLN_END_TIME");
        //            sbQuery.Append(" ,SUBSTRING(PLN_START_TIME, 1, 8) PLN_START_DATE ");
        //            sbQuery.Append(" ,SUBSTRING(PLN_END_TIME, 1, 8) PLN_END_DATE ");
        //            sbQuery.Append(" ,WP.PLN_QTY");

        //            sbQuery.Append(" FROM TSHP_WORKORDER W ");
        //            sbQuery.Append("  JOIN LSE_STD_PART S ON W.PLT_CODE = S.PLT_CODE AND  W.PART_CODE = S.PART_CODE  ");
        //            sbQuery.Append("  JOIN LSE_STD_PROC SP ON W.PLT_CODE = SP.PLT_CODE AND W.PROC_CODE = SP.PROC_CODE ");
        //            sbQuery.Append("  JOIN TORD_PRODUCT P ON W.PLT_CODE = P.PLT_CODE AND W.PROD_CODE = P.PROD_CODE AND W.PART_CODE = P.PART_CODE ");
        //            sbQuery.Append("  JOIN TORD_ITEM I ON P.PLT_CODE = I.PLT_CODE AND P.ITEM_CODE = I.ITEM_CODE ");
        //            sbQuery.Append("  JOIN TSTD_VENDOR V ON I.PLT_CODE = V.PLT_CODE AND I.CVND_CODE = V.VEN_CODE ");
        //            sbQuery.Append("  JOIN TSHP_WORKPLAN WP ON W.PLT_CODE = WP.PLT_CODE AND  W.WP_NO = WP.WP_NO  ");
        //            sbQuery.Append(" LEFT OUTER JOIN (SELECT PLT_CODE, LINK_KEY ");
        //            sbQuery.Append("             FROM TSYS_FILELIST_MASTER WHERE IS_UPLOAD = 1 AND UPLOAD_MENU = 'PLN01A' AND DATA_FLAG = 0 GROUP BY PLT_CODE, LINK_KEY) FM ");
        //            sbQuery.Append(" ON W.PLT_CODE = FM.PLT_CODE AND W.PART_CODE = FM.LINK_KEY ");

        //            foreach (DataRow row in dtParam.Rows)
        //            {
        //                StringBuilder sbWhere = new StringBuilder();

        //                sbWhere.Append(" WHERE W.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

        //                sbWhere.Append(UTIL.GetWhere(row, "@MC_CODE", "W.MC_CODE = @MC_CODE"));
        //                sbWhere.Append(UTIL.GetWhere(row, "@EMP_CODE", "W.EMP_CODE = @EMP_CODE"));
        //                sbWhere.Append(UTIL.GetWhere(row, "@WO_NO", "W.WO_NO = @WO_NO"));

        //                //당일작업
        //                //1.일정 계획 없는 항목이 지연으로 표시됩니다 ==> 대기로 표시
        //                //2.완료항목은 당일 완료된 항목만 표시되게 수정해주세요
        //                //3.당일 작업 에는 일정 계획 없는 항목은 표시되지않게 해주세요  
        //                string cond1 = "   ( ";
        //                //cond1 += " ( WO_FLAG IN  ('1', '2', '3') AND  @W_DATE BETWEEN LEFT(PLN_START_TIME, 8) AND LEFT(PLN_END_TIME, 8) ) ";
        //                //cond1 += " OR ( WO_FLAG = '1' AND ISNULL(PLN_START_TIME, '') <> '' )  ";
        //                cond1 += " ( WO_FLAG = '1' AND  @W_DATE BETWEEN LEFT(PLN_START_TIME, 8) AND LEFT(PLN_END_TIME, 8) ";
        //                cond1 += "    AND ISNULL(PLN_START_TIME, '') <> '' ) ";
        //                cond1 += " OR ( WO_FLAG IN ('2', '3' ) ) ";
        //                cond1 += " ) ";
        //                cond1 += "  OR (WO_FLAG = '4' AND dbo.fn_dm_date(ACT_END_TIME) = CONVERT(varchar, GETDATE(), 112)) ";

        //                //전체작업
        //                string cond2 = " AND  (     WO_FLAG IN  ('1', '2', '3')  ";
        //                cond2 += "  OR (WO_FLAG = '4' AND dbo.fn_dm_date(ACT_END_TIME) = CONVERT(varchar, GETDATE(), 112))  )  ";

        //                if (row.Table.Columns.Contains("W_DATE"))
        //                {
        //                    if (row["W_DATE"].ToString() == "")
        //                    {
        //                        //전체작업
        //                        sbWhere.Append(cond2);
        //                    }
        //                    else
        //                    {
        //                        //당일작업
        //                        sbWhere.Append(UTIL.GetWhere(row, "@W_DATE", cond1));
        //                    }
        //                }


        //                sbWhere.Append(" AND W.DATA_FLAG = 0");
        //                sbWhere.Append(" ORDER BY W.PLN_START_TIME, JOB_PRIORITY");

        //                DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString() + sbWhere.ToString(), row).Copy();

        //                sourceTable.TableName = "RSLTDT";
        //                dsResult.Merge(sourceTable);
        //            }
        //        }

        //        return UTIL.GetDsToDt(dsResult);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
        //    }
        //}

        ////20160524 김준구 - 단말기 작업지시 조회(일) - 조립
        //public static DataTable TSHP_WORKORDER_QUERY6(DataTable dtParam, BizExecute.BizExecute bizExecute)
        //{
        //    try
        //    {
        //        DataSet dsResult = new DataSet();

        //        if (dtParam.Rows.Count > 0)
        //        {
        //            StringBuilder sbQuery = new StringBuilder();

        //            sbQuery.Append(" SELECT  ");
        //            sbQuery.Append(" TP.PLT_CODE, ");
        //            sbQuery.Append(" TP.ITEM_CODE, ");
        //            sbQuery.Append(" I.ITEM_NAME, ");
        //            sbQuery.Append(" I.CVND_CODE, ");
        //            sbQuery.Append(" V.VEN_NAME AS CVND_NAME, ");
        //            sbQuery.Append(" TP.PROD_CODE, ");
        //            sbQuery.Append(" TP.PART_CODE, ");
        //            sbQuery.Append(" LPT.PART_PRODTYPE, ");
        //            sbQuery.Append(" LPT.PART_NAME, ");
        //            sbQuery.Append(" LPT.DRAW_NO, ");
        //            sbQuery.Append(" LPT.MAT_SPEC1, ");
        //            sbQuery.Append(" TWP.PLN_QTY, ");
        //            sbQuery.Append(" 0 AS SEQ, ");
        //            sbQuery.Append(" TP.DUE_DATE, ");
        //            sbQuery.Append(" CASE ISNULL(APLAN.REG_EMP, '') WHEN '' THEN '' ELSE '▼' END AP ");

        //            sbQuery.Append(" FROM TORD_PRODUCT TP ");
        //            sbQuery.Append(" JOIN TSHP_WORKORDER TW ");
        //            sbQuery.Append(" ON TP.PLT_CODE = TW.PLT_CODE ");
        //            sbQuery.Append(" AND TP.PROD_CODE = TW.PROD_CODE ");
        //            sbQuery.Append(" AND TP.PART_CODE = TW.PART_CODE ");
        //            sbQuery.Append(" JOIN LSE_STD_PART LPT ");
        //            sbQuery.Append(" ON TW.PLT_CODE = LPT.PLT_CODE ");
        //            sbQuery.Append(" AND TW.PART_CODE = LPT.PART_CODE ");
        //            sbQuery.Append(" JOIN TSHP_WORKPLAN TWP ");
        //            sbQuery.Append(" ON TP.PLT_CODE = TWP.PLT_CODE ");
        //            sbQuery.Append(" AND TP.PROD_CODE = TWP.PROD_CODE ");
        //            sbQuery.Append(" AND TP.PART_CODE = TWP.PART_CODE ");
        //            sbQuery.Append(" JOIN TORD_ITEM I ");
        //            sbQuery.Append(" ON TP.PLT_CODE = I.PLT_CODE ");
        //            sbQuery.Append(" AND TP.ITEM_CODE = I.ITEM_CODE ");
        //            sbQuery.Append(" JOIN TSTD_VENDOR V ");
        //            sbQuery.Append(" ON I.PLT_CODE = V.PLT_CODE ");
        //            sbQuery.Append(" AND I.CVND_CODE = V.VEN_CODE ");

        //            sbQuery.Append(" LEFT OUTER JOIN TSHP_ASSPLAN APLAN ");
        //            sbQuery.Append("  ON TW.PLT_CODE = APLAN.PLT_CODE   ");
        //            sbQuery.Append("    AND TW.PROD_CODE = APLAN.PROD_CODE   ");
        //            sbQuery.Append("    AND TW.PART_CODE = APLAN.PART_CODE   ");
        //            sbQuery.Append("    AND TW.EMP_CODE = APLAN.REG_EMP   ");

        //            foreach (DataRow row in dtParam.Rows)
        //            {
        //                StringBuilder sbWhere = new StringBuilder();

        //                sbWhere.Append(" WHERE TP.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

        //                sbWhere.Append(" AND TW.WO_FLAG IN ('1', '2', '3') ");

        //                //sbWhere.Append(UTIL.GetWhere(row, "@W_DATE", "  TW.WO_FLAG IN ('1', '2', '3') OR (TW.WO_FLAG = 4 and dbo.fn_dm_date(TW.ACT_END_TIME) = @W_DATE ) "));

        //                //당일작업
        //                string cond1 = "   (    ( WO_FLAG IN  ('1', '2', '3') AND  @W_DATE BETWEEN LEFT(PLN_START_TIME, 8) AND LEFT(PLN_END_TIME, 8) ";
        //                cond1 += " OR ISNULL(PLN_START_TIME, '') = '')  ) ";
        //                cond1 += "  OR (WO_FLAG = '4' AND dbo.fn_dm_date(ACT_END_TIME) = CONVERT(varchar, GETDATE(), 112)) ";

        //                //전체작업
        //                string cond2 = " AND  (     WO_FLAG IN  ('1', '2', '3')  ";
        //                cond2 += "  OR (WO_FLAG = '4' AND dbo.fn_dm_date(ACT_END_TIME) = CONVERT(varchar, GETDATE(), 112)) ) ";

        //                if (row.Table.Columns.Contains("W_DATE"))
        //                {
        //                    if (row["W_DATE"].ToString() == "")
        //                    {
        //                        //전체작업
        //                        sbWhere.Append(cond2);
        //                    }
        //                    else
        //                    {
        //                        //당일작업
        //                        sbWhere.Append(UTIL.GetWhere(row, "@W_DATE", cond1));
        //                    }
        //                }


        //                //sbWhere.Append(UTIL.GetWhere(row, "@W_DATE", "  (1  = 1) OR (TW.WO_FLAG = 4 and dbo.fn_dm_date(TW.ACT_END_TIME) = @W_DATE ) "));
        //                //sbWhere.Append(UTIL.GetWhere(row, "@W_DATE", "  LEFT(TW.PLN_END_TIME, 8) <= @W_DATE "));

        //                sbWhere.Append(UTIL.GetWhere(row, "@EMP_CODE", "  TW.EMP_CODE = @EMP_CODE  "));
        //                sbWhere.Append(" GROUP BY ");
        //                sbWhere.Append(" TP.PLT_CODE, ");
        //                sbWhere.Append(" TP.ITEM_CODE, ");
        //                sbWhere.Append(" I.ITEM_NAME, ");
        //                sbWhere.Append(" I.CVND_CODE, ");
        //                sbWhere.Append(" V.VEN_NAME, ");
        //                sbWhere.Append(" TP.PROD_CODE, ");
        //                sbWhere.Append(" TP.PART_CODE, ");
        //                sbWhere.Append(" LPT.PART_PRODTYPE, ");
        //                sbWhere.Append(" LPT.PART_NAME, ");
        //                sbWhere.Append(" LPT.DRAW_NO, ");
        //                sbWhere.Append(" LPT.MAT_SPEC1, ");
        //                sbWhere.Append(" TWP.PLN_QTY, ");
        //                sbWhere.Append(" TP.DUE_DATE, ");
        //                sbWhere.Append(" APLAN.REG_EMP");

        //                DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString() + sbWhere.ToString()).Copy();


        //                sourceTable.TableName = "RSLTDT";
        //                dsResult.Merge(sourceTable);
        //            }
        //        }

        //        return UTIL.GetDsToDt(dsResult);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
        //    }
        //}

        //public static DataTable TSHP_WORKORDER_QUERY6_1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        //{
        //    try
        //    {
        //        DataSet dsResult = new DataSet();

        //        if (dtParam.Rows.Count > 0)
        //        {
        //            StringBuilder sbQuery = new StringBuilder();

        //            sbQuery.Append(" SELECT  ");
        //            sbQuery.Append(" TP.PLT_CODE, ");
        //            sbQuery.Append(" TP.ITEM_CODE, ");
        //            sbQuery.Append(" I.ITEM_NAME, ");
        //            sbQuery.Append(" I.CVND_CODE, ");
        //            sbQuery.Append(" V.VEN_NAME AS CVND_NAME, ");
        //            sbQuery.Append(" TP.PROD_CODE, ");
        //            sbQuery.Append(" TP.PART_CODE, ");
        //            sbQuery.Append(" TW.PROC_CODE, ");
        //            sbQuery.Append(" PR.PROC_NAME, ");
        //            sbQuery.Append(" TW.WO_NO, ");
        //            sbQuery.Append(" TW.WO_FLAG, ");
        //            sbQuery.Append(" TW.MC_CODE, ");
        //            sbQuery.Append(" LPT.PART_PRODTYPE, ");
        //            sbQuery.Append(" LPT.PART_NAME, ");
        //            sbQuery.Append(" LPT.DRAW_NO, ");
        //            sbQuery.Append(" LPT.MAT_SPEC1, ");
        //            sbQuery.Append(" TWP.PLN_QTY, ");
        //            sbQuery.Append(" TW.PART_QTY, ");
        //            sbQuery.Append(" 0 AS SEQ, ");
        //            sbQuery.Append(" TP.DUE_DATE, ");
        //            sbQuery.Append(" PRA.ASSY_TIME, ");
        //            sbQuery.Append(" CASE WHEN PRA.PART_CODE IS NOT NULL THEN '○' ELSE 'X' END IS_PARTPROC_ASSY, ");
        //            sbQuery.Append(" TW.ACT_START_TIME, ");
        //            sbQuery.Append(" TW.ACT_END_TIME, ");
        //            sbQuery.Append(" DATEDIFF(minute, ACT_START_TIME, CASE WHEN ACT_END_TIME IS NULL THEN GETDATE() ELSE ACT_END_TIME END) AS JOB_TIME ");
        //            //sbQuery.Append(" CASE ISNULL(APLAN.REG_EMP, '') WHEN '' THEN '' ELSE '▼' END AP ");

        //            sbQuery.Append(" FROM TORD_PRODUCT TP ");
        //            sbQuery.Append(" JOIN TSHP_WORKORDER TW ");
        //            sbQuery.Append(" ON TP.PLT_CODE = TW.PLT_CODE ");
        //            sbQuery.Append(" AND TP.PROD_CODE = TW.PROD_CODE ");
        //            sbQuery.Append(" AND TP.PART_CODE = TW.PART_CODE ");
        //            sbQuery.Append(" JOIN LSE_STD_PART LPT ");
        //            sbQuery.Append(" ON TW.PLT_CODE = LPT.PLT_CODE ");
        //            sbQuery.Append(" AND TW.PART_CODE = LPT.PART_CODE ");
        //            sbQuery.Append(" JOIN TSHP_WORKPLAN TWP ");
        //            sbQuery.Append(" ON TP.PLT_CODE = TWP.PLT_CODE ");
        //            sbQuery.Append(" AND TP.PROD_CODE = TWP.PROD_CODE ");
        //            sbQuery.Append(" AND TP.PART_CODE = TWP.PART_CODE ");
        //            sbQuery.Append(" JOIN TORD_ITEM I ");
        //            sbQuery.Append(" ON TP.PLT_CODE = I.PLT_CODE ");
        //            sbQuery.Append(" AND TP.ITEM_CODE = I.ITEM_CODE ");
        //            sbQuery.Append(" JOIN TSTD_VENDOR V ");
        //            sbQuery.Append(" ON I.PLT_CODE = V.PLT_CODE ");
        //            sbQuery.Append(" AND I.CVND_CODE = V.VEN_CODE ");
        //            sbQuery.Append(" LEFT JOIN LSE_STD_PROC PR ");
        //            sbQuery.Append(" ON TW.PLT_CODE = PR.PLT_CODE ");
        //            sbQuery.Append(" AND TW.PROC_CODE = PR.PROC_CODE ");

        //            sbQuery.Append(" LEFT JOIN LSE_STD_PARTPROC_ASSY PRA ");
        //            sbQuery.Append("     ON TW.PLT_CODE = PRA.PLT_CODE");
        //            sbQuery.Append("     AND TW.PART_CODE = PRA.PART_CODE");
        //            sbQuery.Append("     AND TW.PROC_CODE = PRA.PROC_CODE");

        //            //sbQuery.Append(" LEFT OUTER JOIN TSHP_ASSPLAN APLAN ");
        //            //sbQuery.Append("  ON TW.PLT_CODE = APLAN.PLT_CODE   ");
        //            //sbQuery.Append("    AND TW.PROD_CODE = APLAN.PROD_CODE   ");
        //            //sbQuery.Append("    AND TW.PART_CODE = APLAN.PART_CODE   ");
        //            //sbQuery.Append("    AND TW.EMP_CODE = APLAN.REG_EMP   ");

        //            foreach (DataRow row in dtParam.Rows)
        //            {
        //                StringBuilder sbWhere = new StringBuilder();

        //                sbWhere.Append(" WHERE TP.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

        //                //sbWhere.Append(" AND TW.WO_FLAG IN ('1', '2', '3') ");

        //                sbWhere.Append(" AND PR.IS_ASSY = 1");
        //                //sbWhere.Append(UTIL.GetWhere(row, "@W_DATE", "  TW.WO_FLAG IN ('1', '2', '3') OR (TW.WO_FLAG = 4 and dbo.fn_dm_date(TW.ACT_END_TIME) = @W_DATE ) "));

        //                //당일작업
        //                //string cond1 = "   (    ( WO_FLAG IN  ('1', '2', '3') AND  @W_DATE BETWEEN LEFT(PLN_START_TIME, 8) AND LEFT(PLN_END_TIME, 8) ";
        //                //cond1 += " OR ISNULL(PLN_START_TIME, '') = '')  ) ";
        //                //cond1 += "  OR (WO_FLAG = '4' AND dbo.fn_dm_date(ACT_END_TIME) = CONVERT(varchar, GETDATE(), 112)) ";
        //                string cond1 = " (( WO_FLAG = '1' AND  @W_DATE BETWEEN LEFT(PLN_START_TIME, 8) AND LEFT(PLN_END_TIME, 8) ";
        //                cond1 += "    AND ISNULL(PLN_START_TIME, '') <> '' ) ";
        //                cond1 += " OR ( WO_FLAG IN ('2', '3' ) ) ";
        //                cond1 += " ) ";
        //                cond1 += "  OR (WO_FLAG = '4' AND dbo.fn_dm_date(ACT_END_TIME) = CONVERT(varchar, GETDATE(), 112)) ";

        //                //전체작업
        //                string cond2 = " AND  (     WO_FLAG IN  ('1', '2', '3')  ";
        //                cond2 += "  OR (WO_FLAG = '4' AND dbo.fn_dm_date(ACT_END_TIME) = CONVERT(varchar, GETDATE(), 112)) ) ";

        //                if (row.Table.Columns.Contains("W_DATE"))
        //                {
        //                    if (row["W_DATE"].ToString() == "")
        //                    {
        //                        //전체작업
        //                        sbWhere.Append(cond2);
        //                    }
        //                    else
        //                    {
        //                        //당일작업
        //                        sbWhere.Append(UTIL.GetWhere(row, "@W_DATE", cond1));
        //                    }
        //                }


        //                //sbWhere.Append(UTIL.GetWhere(row, "@W_DATE", "  (1  = 1) OR (TW.WO_FLAG = 4 and dbo.fn_dm_date(TW.ACT_END_TIME) = @W_DATE ) "));
        //                //sbWhere.Append(UTIL.GetWhere(row, "@W_DATE", "  LEFT(TW.PLN_END_TIME, 8) <= @W_DATE "));

        //                sbWhere.Append(UTIL.GetWhere(row, "@EMP_CODE", "  TW.EMP_CODE = @EMP_CODE  "));
        //                //sbWhere.Append(" GROUP BY ");
        //                //sbWhere.Append(" TP.PLT_CODE, ");
        //                //sbWhere.Append(" TP.ITEM_CODE, ");
        //                //sbWhere.Append(" I.ITEM_NAME, ");
        //                //sbWhere.Append(" I.CVND_CODE, ");
        //                //sbWhere.Append(" V.VEN_NAME, ");
        //                //sbWhere.Append(" TP.PROD_CODE, ");
        //                //sbWhere.Append(" TP.PART_CODE, ");
        //                //sbWhere.Append(" LPT.PART_PRODTYPE, ");
        //                //sbWhere.Append(" LPT.PART_NAME, ");
        //                //sbWhere.Append(" LPT.DRAW_NO, ");
        //                //sbWhere.Append(" LPT.MAT_SPEC1, ");
        //                //sbWhere.Append(" TWP.PLN_QTY, ");
        //                //sbWhere.Append(" TP.DUE_DATE, ");
        //                //sbWhere.Append(" APLAN.REG_EMP");

        //                DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString() + sbWhere.ToString()).Copy();


        //                sourceTable.TableName = "RSLTDT";
        //                dsResult.Merge(sourceTable);
        //            }
        //        }

        //        return UTIL.GetDsToDt(dsResult);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
        //    }
        //}

        /// <summary>
        /// 현황판- 조립현황 쿼리
        /// </summary>
        /// <param name="dtParam"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataTable TSHP_WORKORDER_QUERY7(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {

                DataSet dsResult = new DataSet();
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT         ");
                    sbQuery.Append("  W.PLT_CODE   ");
                    sbQuery.Append("  , I.ITEM_CODE   ");
                    sbQuery.Append("  , I.CVND_CODE   ");
                    sbQuery.Append("  , V.VEN_NAME CVND_NAME   ");
                    sbQuery.Append("  , W.PROD_CODE   ");
                    sbQuery.Append("  , P.PROD_NAME   ");
                    sbQuery.Append("  , P.DUE_DATE    ");
                    sbQuery.Append("  , P.PROD_QTY   ");
                    sbQuery.Append("  , W.PART_CODE   ");
                    sbQuery.Append("  , W.PART_QTY   ");
                    sbQuery.Append("  , D.OK_QTY    ");
                    sbQuery.Append("  , W.PROC_CODE   ");
                    sbQuery.Append("  ,W.PROC_SEQ  ");
                    sbQuery.Append("  , PR.PROC_NAME   ");
                    sbQuery.Append("  , W.PLN_END_TIME   ");
                    sbQuery.Append("  , dbo.fn_dm_date(D.ACT_END_TIME) AS ACT_END_TIME   ");
                    sbQuery.Append("  , W.WO_FLAG   ");
                    sbQuery.Append("  , CASE W.PROC_CODE WHEN 'P-23' THEN dbo.fn_dm_date(D.ACT_END_TIME) WHEN 'P-22' THEN dbo.fn_dm_date(D.ACT_END_TIME) END END_DATE ");

                    sbQuery.Append("    FROM TSHP_WORKORDER W ");
                    sbQuery.Append("          LEFT JOIN (SELECT PLT_CODE, PROD_CODE, PART_CODE, PROC_CODE, SUM(OK_QTY) OK_QTY, MAX(ACT_END_TIME) AS ACT_END_TIME ");
                    sbQuery.Append("                     FROM TSHP_DAILYWORK GROUP BY PLT_CODE, PROD_CODE, PART_CODE, PROC_CODE ) D    ");
                    sbQuery.Append("     ON W.PLT_CODE = D.PLT_CODE   ");
                    sbQuery.Append("    AND W.PROD_CODE = D.PROD_CODE  ");
                    sbQuery.Append("    AND W.PART_CODE = D.PART_CODE  ");
                    sbQuery.Append("    AND W.PROC_CODE = D.PROC_CODE  ");
                    sbQuery.Append("    LEFT JOIN LSE_STD_PROC PR   ");
                    sbQuery.Append("     ON W.PLT_CODE = PR.PLT_CODE   ");
                    sbQuery.Append("    AND W.PROC_CODE = PR.PROC_CODE   ");
                    sbQuery.Append("    AND PR.MPROC_CODE = 'C001'   ");
                    sbQuery.Append("    LEFT JOIN TORD_PRODUCT P   ");
                    sbQuery.Append("     ON W.PLT_CODE = P.PLT_CODE   ");
                    sbQuery.Append(" 	AND W.PROD_CODE = P.PROD_CODE   ");
                    sbQuery.Append(" 	AND W.PART_CODE = P.PART_CODE   ");
                    sbQuery.Append("    LEFT JOIN TORD_ITEM I    ");
                    sbQuery.Append(" 	 ON P.PLT_CODE = I.PLT_CODE   ");
                    sbQuery.Append(" 	 AND P.ITEM_CODE = I.ITEM_CODE   ");
                    sbQuery.Append("    LEFT JOIN TSTD_VENDOR V   ");
                    sbQuery.Append("     ON I.PLT_CODE = V.PLT_CODE   ");
                    sbQuery.Append(" 	AND I.CVND_CODE = V.VEN_CODE   ");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder();

                        sbWhere.Append(" WHERE W.DATA_FLAG = 0 AND PR.DATA_FLAG = 0   ");

                        sbWhere.Append("   AND W.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                        sbWhere.Append("   AND PR.MPROC_CODE = 'C001' ");
                        //sbWhere.Append("   and i.cvnd_code = '530'");
                        sbWhere.Append("   AND P.PROD_STATE IN ('WK', 'PG') ");

                        sbWhere.Append(UTIL.GetWhere(row, "@WORK_DATE", "    (W.WO_FLAG IN ('1', '2', '3', '4')   OR (W.PROC_CODE IN ('P-22', 'P-23') AND W.WO_FLAG = '4' AND dbo.fn_dm_date(W.ACT_END_TIME) = @WORK_DATE)) "));

                        sbWhere.Append(" ORDER BY W.PROD_CODE, W.PART_CODE  ");

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

        /// <summary>
        /// 현황판 - 출하현황 : 출하공정이 있는 품목 조회
        /// </summary>
        /// <param name="dtParam"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataTable TSHP_WORKORDER_QUERY8(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {

                DataSet dsResult = new DataSet();
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT DISTINCT W.PLT_CODE   ");
                    sbQuery.Append("    , W.PROD_CODE         ");
                    sbQuery.Append(" 	, W.PART_CODE                    ");
                    sbQuery.Append(" 	, SH.SHIP_DATE                    ");
                    sbQuery.Append(" 	, ISNULL(SH.SHIP_QTY, 0) AS SHIP_QTY     ");
                    sbQuery.Append(" 	, W.PART_QTY AS PROD_QTY     ");
                    sbQuery.Append(" FROM TSHP_WORKORDER W JOIN TORD_PRODUCT P   ");
                    sbQuery.Append("   ON W.PLT_CODE = P.PLT_CODE            ");
                    sbQuery.Append("   AND W.PROD_CODE = P.PROD_CODE           ");
                    sbQuery.Append("   AND W.PART_CODE = P.PART_CODE           ");
                    sbQuery.Append("   LEFT JOIN (  SELECT PLT_CODE, PROD_CODE, MAX(SHIP_DATE) SHIP_DATE, SUM(SHIP_QTY) AS SHIP_QTY  ");
                    sbQuery.Append("   FROM TORD_SHIP                          ");
                    sbQuery.Append("   WHERE DATA_FLAG = 0                     ");
                    sbQuery.Append("   GROUP BY PLT_CODE, PROD_CODE ) SH       ");
                    sbQuery.Append("    ON P.PLT_CODE = SH.PLT_CODE            ");
                    sbQuery.Append("    AND P.PROD_CODE = SH.PROD_CODE         ");



                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder();

                        sbWhere.Append(" WHERE W.DATA_FLAG = 0                     ");
                        sbWhere.Append("   AND W.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                        sbWhere.Append("   AND P.DATA_FLAG = 0                     ");

                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_CODE", "W.PROD_CODE = @PROD_CODE"));

                        sbWhere.Append(UTIL.GetWhere(row, "@WORK_DATE", " P.PROD_STATE IN ('WK', 'PG')   OR (P.PROD_STATE = 'SH' AND SH.SHIP_DATE = @WORK_DATE)     "));


                        sbWhere.Append("   AND W.PROC_CODE = 'P-25' ");
                        sbWhere.Append("   AND W.WO_FLAG IN ('1','2','3','4') ");
                        sbWhere.Append("   AND P.PARENT_PART IS NULL ");


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


        public static DataTable TSHP_WORKORDER_QUERY8_2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {

                DataSet dsResult = new DataSet();
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("  SELECT           ");
                    sbQuery.Append("   CV.VEN_NAME AS CVND_NAME  ");
                    sbQuery.Append("  , I.ITEM_CODE     ");
                    sbQuery.Append("  , W.PROD_CODE     ");
                    sbQuery.Append("  , P.PROD_NAME    ");
                    sbQuery.Append("  , W.PROC_SEQ  ");
                    sbQuery.Append("  , P.DUE_DATE     ");
                    sbQuery.Append("  , P.PROD_QTY     ");
                    sbQuery.Append("  , W.PART_CODE    ");
                    sbQuery.Append("  , W.PART_QTY     ");
                    sbQuery.Append("  , D.OK_QTY       ");
                    sbQuery.Append("  , W.PROC_CODE    ");
                    sbQuery.Append("  , W.PLN_END_TIME ");
                    sbQuery.Append("  , dbo.fn_dm_date(D.ACT_END_TIME  ) ACT_END_TIME   ");
                    sbQuery.Append("  , W.WO_FLAG      ");

                    sbQuery.Append("  FROM TSHP_WORKORDER W  ");
                    sbQuery.Append("    LEFT JOIN (SELECT PLT_CODE, PROD_CODE, PART_CODE, PROC_CODE, SUM(OK_QTY) OK_QTY, MAX(ACT_END_TIME) AS ACT_END_TIME  ");
                    sbQuery.Append("					FROM TSHP_DAILYWORK GROUP BY PLT_CODE, PROD_CODE, PART_CODE, PROC_CODE ) D                          ");
                    sbQuery.Append("     ON W.PLT_CODE = D.PLT_CODE   ");
                    sbQuery.Append("    AND W.PROD_CODE = D.PROD_CODE ");
                    sbQuery.Append("	AND W.PART_CODE = D.PART_CODE ");
                    sbQuery.Append("	AND W.PROC_CODE = D.PROC_CODE ");

                    sbQuery.Append("    LEFT JOIN TORD_PRODUCT P      ");
                    sbQuery.Append("     ON W.PLT_CODE = P.PLT_CODE   ");
                    sbQuery.Append(" 	AND W.PROD_CODE = P.PROD_CODE ");
                    sbQuery.Append(" 	AND W.PART_CODE = P.PART_CODE ");

                    sbQuery.Append("    LEFT JOIN TORD_ITEM I      ");
                    sbQuery.Append("     ON P.PLT_CODE = I.PLT_CODE   ");
                    sbQuery.Append(" 	AND P.ITEM_CODE = I.ITEM_CODE ");

                    sbQuery.Append("    LEFT JOIN TSTD_VENDOR CV      ");
                    sbQuery.Append("     ON I.PLT_CODE = CV.PLT_CODE   ");
                    sbQuery.Append(" 	AND I.CVND_CODE = CV.VEN_CODE ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder();

                        sbWhere.Append(" WHERE W.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                        sbWhere.Append("   AND W.DATA_FLAG = 0 AND P.DATA_FLAG = 0   ");

                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_CODE", "W.PROD_CODE = @PROD_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_CODE", "W.PART_CODE = @PART_CODE"));

                        sbWhere.Append("   AND W.PROC_CODE IN ('P-19', 'P-23', 'P-24', 'P-25') ");

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



        /// <summary>
        /// 작업지시 가져오기
        /// </summary>
        /// <param name="dtParam"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataTable TSHP_WORKORDER_QUERY9(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT W.PLT_CODE");
                    sbQuery.Append(" ,TP.MODEL_TYPE");
                    sbQuery.Append(" ,TP.MODEL_CODE");
                    sbQuery.Append(" ,TP.PROD_VERSION");
                    sbQuery.Append(" ,TP.PROC_FLAG");
                    sbQuery.Append(" ,TP.PROD_FLAG");
                    sbQuery.Append(" ,TP.INS_YN");
                    sbQuery.Append(" ,TP.SOCKET_YN");
                    sbQuery.Append(" ,TP.PROD_TYPE");
                    sbQuery.Append(" ,TP.PROD_CATEGORY");
                    sbQuery.Append(" ,TP.BUSINESS_EMP");
                    sbQuery.Append(" ,TP.CUSTOMER_EMP");
                    sbQuery.Append(" ,TP.CUSTDESIGN_EMP");
                    sbQuery.Append(" ,TP.ACTUATOR_YN");
                    sbQuery.Append(" ,TP.CVND_CODE");
                    sbQuery.Append(" ,TP.TVND_CODE");
                    sbQuery.Append(" ,TP.PROBE_PIN");
                    sbQuery.Append(" ,TP.CURR_UNIT");
                    sbQuery.Append(" ,TP.ORD_DATE");
                    sbQuery.Append(" ,TP.INDUE_DATE");
                    sbQuery.Append(" ,TP.DUE_DATE");
                    sbQuery.Append(" ,TP.CHG_DUE_DATE");
                    sbQuery.Append(" ,TP.END_DATE");
                    sbQuery.Append(" ,TP.DELIVERY_DATE");
                    sbQuery.Append(" ,TP.PROD_QTY");
                    sbQuery.Append(" ,TP.LOAD_FLAG");
                    sbQuery.Append(" ,TP.LOCK_FLAG");
                    sbQuery.Append(" ,TP.LOCK_EMP");
                    sbQuery.Append(" ,TP.SHIP_FLAG");
                    sbQuery.Append(" ,TP.PROD_STATE");
                    sbQuery.Append(" ,TP.INOUT_FLAG");
                    sbQuery.Append(" ,TP.ORD_VAT");
                    sbQuery.Append(" ,TP.PROD_UC");
                    sbQuery.Append(" ,TP.PROD_COST");
                    sbQuery.Append(" ,TP.PROD_VAT");
                    sbQuery.Append(" ,TP.PROD_AMT");
                    sbQuery.Append(" ,TP.PROD_KIND");
                    sbQuery.Append(" ,TP.PROD_TYPE1");
                    sbQuery.Append(" ,TP.PROD_TYPE2");
                    sbQuery.Append(" ,TP.INS_FLAG");
                    sbQuery.Append(" ,TP.TRADE_YN");
                    sbQuery.Append(" ,TP.TAX_YN");
                    sbQuery.Append(" ,TP.BILL_YN");
                    sbQuery.Append(" ,PT.SCOMMENT");
                    sbQuery.Append(" ,TP.SCOMMENT AS ORD_SCOMMENT");
                    sbQuery.Append(" ,TP.REMARK");
                    sbQuery.Append(" ,TP.MODULE_TYPE ");
                    sbQuery.Append(" ,TP.PIN_TYPE ");
                    sbQuery.Append(" ,TP.VISION_TYPE ");
                    sbQuery.Append(" ,TP.VISION_DIRECTION ");
                    sbQuery.Append(" ,TP.GND_PIN ");
                    sbQuery.Append(" ,TP.FIDUCIAL_MARK ");
                    sbQuery.Append(" ,TP.CROSS_MARKING ");
                    sbQuery.Append(" ,TP.VACUUM ");
                    sbQuery.Append(" ,TP.SOCKET_MARKING ");
                    sbQuery.Append(" ,TP.MODULE_IN_TYPE ");
                    sbQuery.Append(" ,TP.IF_PIN_BLOCK ");
                    sbQuery.Append(" ,TP.SOCKET_OPEN_DIRECTION ");
                    sbQuery.Append(" ,TP.MSOP_DFM ");
                    sbQuery.Append(" ,TP.MSOP_DFM_DATE ");
                    sbQuery.Append(" ,TP.DRAW_DATE ");
                    sbQuery.Append(" ,TP.DRAW_TYPE ");

                    sbQuery.Append(" ,W.WP_NO");
                    sbQuery.Append(" ,W.WO_NO");
                    sbQuery.Append(" ,S.PART_PRODTYPE");
                    sbQuery.Append(" ,TP.ITEM_CODE");
                    sbQuery.Append(" ,W.PROD_CODE");
                    sbQuery.Append(" ,TP.PROD_NAME");
                    sbQuery.Append(" ,W.PART_CODE");
                    sbQuery.Append(" ,S.PART_NAME");
                    sbQuery.Append(" ,PT.MAT_CODE");
                    sbQuery.Append(" ,ST.PART_NAME AS MAT_NAME ");
                    sbQuery.Append(" ,S.STD_PT_NUM ");
                    sbQuery.Append(" ,ISNULL(SP.IS_MAT, 0) IS_MAT");
                    //sbQuery.Append(" ,ISNULL(SP.IS_OS, 0) IS_OS");
                    sbQuery.Append(" ,S.MAT_SPEC");
                    sbQuery.Append(" ,S.MAT_SPEC1");
                    sbQuery.Append(" ,S.BAL_SPEC");
                    sbQuery.Append(" ,S.BAL_WEIGHT");
                    sbQuery.Append(" ,S.DRAW_NO");
                    sbQuery.Append(" ,W.PROC_CODE ");
                    sbQuery.Append(" ,W.PROC_SEQ  ");
                    sbQuery.Append(" ,SP.PROC_NAME ");
                    sbQuery.Append(" ,W.MC_CODE ");
                    sbQuery.Append(" ,W.MC_GROUP");
                    sbQuery.Append(" ,M.MC_NAME ");
                    sbQuery.Append(" ,W.EMP_CODE");
                    sbQuery.Append(" ,E.EMP_NAME");
                    sbQuery.Append(" ,W.PART_QTY AS PLN_QTY ");
                    sbQuery.Append(" ,W.PART_QTY ");
                    sbQuery.Append(" ,(SELECT ISNULL(SUM(OK_QTY),0) FROM TSHP_ACTUAL A WHERE W.PLT_CODE = A.PLT_CODE AND W.WO_NO = A.WO_NO ) AS ACT_QTY");
                    sbQuery.Append(" ,(SELECT ISNULL(SUM(NG_QTY),0) FROM TSHP_ACTUAL A WHERE W.PLT_CODE = A.PLT_CODE AND W.WO_NO = A.WO_NO ) AS NG_QTY");
                    sbQuery.Append(" ,W.WO_FLAG  ");
                    sbQuery.Append(" ,W.ACT_START_TIME  ");
                    sbQuery.Append(" ,W.ACT_END_TIME  ");
                    sbQuery.Append(" ,W.CAUTION  ");
                    sbQuery.Append(" ,W.JOB_PRIORITY  ");
                    sbQuery.Append(" ,W.WORK_CODE  ");
                    sbQuery.Append(" ,ISNULL(W.IS_OS,0) AS IS_OS  ");
                    //sbQuery.Append(" ,SP.IS_MAT  ");
                    sbQuery.Append(" ,W.CAM_EMP  ");
                    sbQuery.Append(" ,W.CAM_EMP AS CAM_EMP_SUB  ");
                    sbQuery.Append(" ,WE.EMP_NAME AS CAM_EMP_SUB_NAME  ");
                    sbQuery.Append(" ,W.CAM_EMP_DATE  ");
                    sbQuery.Append(" ,W.CAM_DATE  ");
                    sbQuery.Append(" ,W.ACT_END_TIME AS END_TIME  ");
                    sbQuery.Append(" ,W.CHAIN_WO_NO  ");
                    sbQuery.Append(" ,W.PT_ID  ");
                    sbQuery.Append(" ,PT.PART_PUID  ");
                    sbQuery.Append(" ,SPT.PART_NAME AS PART_PUID_NAME  ");
                    ////sbQuery.Append(" ,CASE WHEN W.RE_WO_NO IS NULL THEN '0' ELSE '1' END IS_REWORK  ");
                    //sbQuery.Append(" ,CASE WHEN W.RE_WO_NO IS NULL THEN '0'");
                    //sbQuery.Append("   ELSE CASE WHEN W.IS_DES_CHANGE = 1 THEN '2' ELSE '1' END END AS IS_REWORK");

                    sbQuery.Append(" ,CASE WHEN W.RE_WO_NO IS NULL THEN '0'");
                    sbQuery.Append("   ELSE CASE WHEN W.IS_DES_CHANGE = 1 AND ISNULL(W.IS_REMCT, 0) = 0 AND ISNULL(W.IS_MODIFY, 0) = 0 THEN '2' ");
                    sbQuery.Append("             WHEN W.IS_DES_CHANGE = 1 AND ISNULL(W.IS_REMCT, 0) = 0 AND ISNULL(W.IS_MODIFY, 0) = 1 THEN '3'");
                    sbQuery.Append("             WHEN W.IS_DES_CHANGE = 1 AND ISNULL(W.IS_REMCT, 0) = 1 AND ISNULL(W.IS_MODIFY, 0) = 0 THEN '4'");
                    sbQuery.Append("             WHEN N.NG_TYPE = 'P' THEN '5' ELSE '6' END END AS IS_REWORK");

                    sbQuery.Append(" ,W.RE_WO_NO");
                    //sbQuery.Append(" ,ISNULL(PT.Material, S.MAT_QLTY) AS MAT_QLTY");
                    sbQuery.Append(" ,PT.Material AS MAT_QLTY");
                    sbQuery.Append(" ,TP.PROD_PRIORITY");
                    sbQuery.Append(" ,AD.DRAW_EMP ");

                    sbQuery.Append(" ,W.PREV_CHAIN_WO_NO");
                    sbQuery.Append(" ,W.IS_PREV_CHAIN");

                    sbQuery.Append(" FROM TSHP_WORKORDER W ");
                    sbQuery.Append(" LEFT JOIN TORD_PRODUCT TP ON TP.PLT_CODE = W.PLT_CODE AND TP.PROD_CODE = W.PROD_CODE ");
                    
                    sbQuery.Append(" LEFT JOIN LSE_STD_PART S ON W.PLT_CODE = S.PLT_CODE AND  W.PART_CODE = S.PART_CODE  ");
                    
                    sbQuery.Append(" LEFT JOIN LSE_STD_PROC SP ON W.PLT_CODE = SP.PLT_CODE AND W.PROC_CODE = SP.PROC_CODE ");
                    
                    sbQuery.Append(" LEFT JOIN LSE_MACHINE M ON W.PLT_CODE = M.PLT_CODE AND W.MC_CODE = M.MC_CODE ");
                    
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE E ON W.PLT_CODE = E.PLT_CODE AND W.EMP_CODE = E.EMP_CODE ");
                    
                    sbQuery.Append(" LEFT JOIN TMAT_PARTLIST PT ON W.PLT_CODE = PT.PLT_CODE AND W.PT_ID = PT.PT_ID ");
                    
                    sbQuery.Append(" LEFT JOIN LSE_STD_PART ST ON PT.PLT_CODE = ST.PLT_CODE AND  PT.MAT_CODE = ST.PART_CODE  ");

                    sbQuery.Append(" LEFT JOIN LSE_STD_PART SPT ON PT.PLT_CODE = SPT.PLT_CODE AND  PT.PART_PUID = SPT.PART_CODE  ");
                    
                    sbQuery.Append(" LEFT JOIN TSTD_VENDOR CVND");
                    sbQuery.Append(" ON TP.PLT_CODE = CVND.PLT_CODE");
                    sbQuery.Append(" AND TP.CVND_CODE = CVND.VEN_CODE");
                    
                    sbQuery.Append(" LEFT JOIN TSTD_BILL_VENDOR TVND");
                    sbQuery.Append(" ON TP.PLT_CODE = TVND.PLT_CODE");
                    sbQuery.Append(" AND TP.TVND_CODE = TVND.BVEN_CODE");

                    sbQuery.Append(" LEFT JOIN (");
                    sbQuery.Append(" SELECT PLT_CODE, PROD_CODE, MAX(DRAW_EMP) AS DRAW_EMP FROM TMAT_PARTLIST");
                    sbQuery.Append(" WHERE ISNULL(O_PT_ID,'') = '' AND DATA_FLAG = '0' AND LEFT(PART_CODE,1) = 'A'");
                    sbQuery.Append(" GROUP BY PLT_CODE, PROD_CODE");
                    sbQuery.Append(" ) AD");
                    sbQuery.Append(" ON TP.PLT_CODE = AD.PLT_CODE");
                    sbQuery.Append(" AND TP.PROD_CODE = AD.PROD_CODE");

                    sbQuery.Append(" LEFT JOIN TSHP_NG N");
                    sbQuery.Append(" ON W.PLT_CODE = N.PLT_CODE");
                    sbQuery.Append(" AND W.RE_WO_NO = N.RE_WO_NO");

                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE WE");
                    sbQuery.Append(" ON W.PLT_CODE = WE.PLT_CODE");
                    sbQuery.Append(" AND W.CAM_EMP = WE.EMP_CODE");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder();

                        sbWhere.Append(" WHERE W.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());


                        sbWhere.Append(UTIL.GetWhere(row, "@S_REG_DATE, @E_REG_DATE", "(CONVERT(nvarchar(8),TP.REG_DATE,112) BETWEEN @S_REG_DATE AND @E_REG_DATE)"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_ORD_DATE, @E_ORD_DATE", "(TP.ORD_DATE BETWEEN @S_ORD_DATE AND @E_ORD_DATE)"));
                        //sbWhere.Append(UTIL.GetWhere(row, "@S_DUE_DATE, @E_DUE_DATE", "(TP.DUE_DATE BETWEEN @S_DUE_DATE AND @E_DUE_DATE)"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_DUE_DATE, @E_DUE_DATE", "ISNULL(TP.CHG_DUE_DATE, TP.DUE_DATE) BETWEEN @S_DUE_DATE AND @E_DUE_DATE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_DELIVERY_DATE, @E_DELIVERY_DATE", "(TP.DELIVERY_DATE BETWEEN @S_DELIVERY_DATE AND @E_DELIVERY_DATE)"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_LIKE", "W.PROD_CODE LIKE '%' + @PROD_LIKE + '%' OR TP.PROD_NAME LIKE '%' + @PROD_LIKE + '%'"));
                        sbWhere.Append(UTIL.GetWhere(row, "@BUSINESS_EMP", "TP.BUSINESS_EMP = @BUSINESS_EMP"));
                        sbWhere.Append(UTIL.GetWhere(row, "@CVND_LIKE", "TP.CVND_CODE LIKE '%' + @CVND_LIKE + '%' OR CVND.VEN_NAME LIKE '%' + @CVND_LIKE + '%'"));
                        sbWhere.Append(UTIL.GetWhere(row, "@CVND_CODE", "TP.CVND_CODE = @CVND_CODE"));

                        sbWhere.Append(UTIL.GetWhere(row, "@WO_NO", "W.WO_NO = @WO_NO"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_CODE", "W.PROD_CODE = @PROD_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_CODE", "W.PART_CODE = @PART_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_LIKE", "W.PART_CODE LIKE '%' + @PART_LIKE + '%' OR S.PART_NAME LIKE '%' + @PART_LIKE + '%' "));
                        sbWhere.Append(UTIL.GetWhere(row, "@MC_CODE", "W.MC_CODE = @MC_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PROC_CODE", "W.PROC_CODE = @PROC_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@EMP_CODE", "W.EMP_CODE = @EMP_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@WO_TYPE", "SP.WO_TYPE = @WO_TYPE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "W.DATA_FLAG = @DATA_FLAG"));
                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "TP.DATA_FLAG = @DATA_FLAG"));

                        sbWhere.Append(UTIL.GetWhere(row, "@NOT_WO_NO", "W.WO_NO <> @NOT_WO_NO"));
                        sbWhere.Append(UTIL.GetWhere(row, "@CHAIN_WO_NO", "W.CHAIN_WO_NO = @CHAIN_WO_NO"));
                        sbWhere.Append(UTIL.GetWhere(row, "@MAT_QLTY", "PT.Material LIKE '%' + @MAT_QLTY + '%'"));                        

                        sbWhere.Append(UTIL.GetWhere(row, "@WO_LIKE", "W.WO_FLAG IN @WO_LIKE", UTIL.SqlCondType.IN));
                        sbWhere.Append(UTIL.GetWhere(row, "@PT_ID_NOT_IN", "W.PT_ID NOT IN @PT_ID_NOT_IN", UTIL.SqlCondType.IN));

                        sbWhere.Append(UTIL.GetWhere(row, "@CAM_EMP_ALL", "(W.CAM_EMP = @CAM_EMP_ALL OR ISNULL(CAM_EMP,'') = '')"));

                        sbWhere.Append(UTIL.GetWhere(row, "@CHAIN_WO_LIKE", "W.CHAIN_WO_NO LIKE '%' + @CHAIN_WO_LIKE + '%'"));

                        sbWhere.Append(" AND TP.PROD_CODE IS NOT NULL AND TP.PROD_STATE <> '5'");

                        sbWhere.Append(" ORDER BY W.PART_ID, W.PROC_ID");

                        DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString() + sbWhere.ToString(), row).Copy();

                        sourceTable.TableName = "RSLTDT";
                        dsResult.Merge(sourceTable, false, MissingSchemaAction.Add);
                    }
                }

                return UTIL.GetDsToDt(dsResult);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }


        public static DataTable TSHP_WORKORDER_QUERY9_1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT W.PLT_CODE");
                    sbQuery.Append(" ,TP.MODEL_TYPE");
                    sbQuery.Append(" ,TP.MODEL_CODE");
                    sbQuery.Append(" ,TP.PROD_VERSION");
                    sbQuery.Append(" ,TP.PROC_FLAG");
                    sbQuery.Append(" ,TP.PROD_FLAG");
                    sbQuery.Append(" ,TP.INS_YN");
                    sbQuery.Append(" ,TP.SOCKET_YN");
                    sbQuery.Append(" ,TP.PROD_TYPE");
                    sbQuery.Append(" ,TP.PROD_CATEGORY");
                    sbQuery.Append(" ,TP.BUSINESS_EMP");
                    sbQuery.Append(" ,TP.CUSTOMER_EMP");
                    sbQuery.Append(" ,TP.CUSTDESIGN_EMP");
                    sbQuery.Append(" ,TP.ACTUATOR_YN");
                    sbQuery.Append(" ,TP.CVND_CODE");
                    sbQuery.Append(" ,TP.TVND_CODE");
                    sbQuery.Append(" ,TP.PROBE_PIN");
                    sbQuery.Append(" ,TP.CURR_UNIT");
                    sbQuery.Append(" ,TP.ORD_DATE");
                    sbQuery.Append(" ,TP.INDUE_DATE");
                    sbQuery.Append(" ,TP.DUE_DATE");
                    sbQuery.Append(" ,TP.CHG_DUE_DATE");
                    sbQuery.Append(" ,TP.END_DATE");
                    sbQuery.Append(" ,TP.DELIVERY_DATE");
                    sbQuery.Append(" ,TP.PROD_QTY");
                    sbQuery.Append(" ,TP.LOAD_FLAG");
                    sbQuery.Append(" ,TP.LOCK_FLAG");
                    sbQuery.Append(" ,TP.LOCK_EMP");
                    sbQuery.Append(" ,TP.SHIP_FLAG");
                    sbQuery.Append(" ,TP.PROD_STATE");
                    sbQuery.Append(" ,TP.INOUT_FLAG");
                    sbQuery.Append(" ,TP.ORD_VAT");
                    sbQuery.Append(" ,TP.PROD_UC");
                    sbQuery.Append(" ,TP.PROD_COST");
                    sbQuery.Append(" ,TP.PROD_VAT");
                    sbQuery.Append(" ,TP.PROD_AMT");
                    sbQuery.Append(" ,TP.PROD_KIND");
                    sbQuery.Append(" ,TP.PROD_TYPE1");
                    sbQuery.Append(" ,TP.PROD_TYPE2");
                    sbQuery.Append(" ,TP.INS_FLAG");
                    sbQuery.Append(" ,TP.TRADE_YN");
                    sbQuery.Append(" ,TP.TAX_YN");
                    sbQuery.Append(" ,TP.BILL_YN");
                    sbQuery.Append(" ,PT.SCOMMENT");
                    sbQuery.Append(" ,TP.REMARK");
                    sbQuery.Append(" ,TP.MODULE_TYPE ");
                    sbQuery.Append(" ,TP.PIN_TYPE ");
                    sbQuery.Append(" ,TP.VISION_TYPE ");
                    sbQuery.Append(" ,TP.VISION_DIRECTION ");
                    sbQuery.Append(" ,TP.GND_PIN ");
                    sbQuery.Append(" ,TP.FIDUCIAL_MARK ");
                    sbQuery.Append(" ,TP.CROSS_MARKING ");
                    sbQuery.Append(" ,TP.VACUUM ");
                    sbQuery.Append(" ,TP.SOCKET_MARKING ");
                    sbQuery.Append(" ,TP.MODULE_IN_TYPE ");
                    sbQuery.Append(" ,TP.IF_PIN_BLOCK ");
                    sbQuery.Append(" ,TP.SOCKET_OPEN_DIRECTION ");
                    sbQuery.Append(" ,TP.MSOP_DFM ");
                    sbQuery.Append(" ,TP.MSOP_DFM_DATE ");
                    sbQuery.Append(" ,TP.DRAW_DATE ");
                    sbQuery.Append(" ,TP.DRAW_TYPE ");

                    sbQuery.Append(" ,W.WP_NO");
                    sbQuery.Append(" ,W.WO_NO");
                    sbQuery.Append(" ,S.PART_PRODTYPE");
                    sbQuery.Append(" ,TP.ITEM_CODE");
                    sbQuery.Append(" ,W.PROD_CODE");
                    sbQuery.Append(" ,TP.PROD_NAME");
                    sbQuery.Append(" ,W.PART_CODE");
                    sbQuery.Append(" ,S.PART_NAME");
                    sbQuery.Append(" ,PT.MAT_CODE");
                    sbQuery.Append(" ,ST.PART_NAME AS MAT_NAME ");
                    sbQuery.Append(" ,S.STD_PT_NUM ");
                    sbQuery.Append(" ,ISNULL(SP.IS_MAT, 0) IS_MAT");
                    //sbQuery.Append(" ,ISNULL(SP.IS_OS, 0) IS_OS");
                    sbQuery.Append(" ,S.MAT_SPEC");
                    sbQuery.Append(" ,S.MAT_SPEC1");
                    sbQuery.Append(" ,S.BAL_SPEC");
                    sbQuery.Append(" ,S.BAL_WEIGHT");
                    sbQuery.Append(" ,S.DRAW_NO");
                    sbQuery.Append(" ,W.PROC_CODE ");
                    sbQuery.Append(" ,W.PROC_SEQ  ");
                    sbQuery.Append(" ,SP.PROC_NAME ");
                    sbQuery.Append(" ,W.MC_CODE ");
                    sbQuery.Append(" ,W.MC_GROUP");
                    sbQuery.Append(" ,M.MC_NAME ");
                    sbQuery.Append(" ,W.EMP_CODE");
                    sbQuery.Append(" ,E.EMP_NAME");
                    sbQuery.Append(" ,W.PART_QTY AS PLN_QTY ");
                    sbQuery.Append(" ,W.PART_QTY ");
                    sbQuery.Append(" ,(SELECT ISNULL(SUM(OK_QTY),0) FROM TSHP_ACTUAL A WHERE W.PLT_CODE = A.PLT_CODE AND W.WO_NO = A.WO_NO ) AS ACT_QTY");
                    sbQuery.Append(" ,(SELECT ISNULL(SUM(NG_QTY),0) FROM TSHP_ACTUAL A WHERE W.PLT_CODE = A.PLT_CODE AND W.WO_NO = A.WO_NO ) AS NG_QTY");
                    sbQuery.Append(" ,W.WO_FLAG  ");
                    sbQuery.Append(" ,W.ACT_START_TIME  ");
                    sbQuery.Append(" ,W.ACT_END_TIME  ");
                    sbQuery.Append(" ,W.CAUTION  ");
                    sbQuery.Append(" ,W.JOB_PRIORITY  ");
                    sbQuery.Append(" ,W.WORK_CODE  ");
                    sbQuery.Append(" ,ISNULL(W.IS_OS,0) AS IS_OS  ");
                    //sbQuery.Append(" ,SP.IS_MAT  ");
                    sbQuery.Append(" ,W.CAM_EMP  ");
                    sbQuery.Append(" ,W.CAM_EMP AS CAM_EMP_SUB  ");
                    sbQuery.Append(" ,WE.EMP_NAME AS CAM_EMP_SUB_NAME  ");
                    sbQuery.Append(" ,W.CAM_EMP_DATE  ");
                    sbQuery.Append(" ,W.CAM_DATE  ");
                    sbQuery.Append(" ,W.ACT_END_TIME AS END_TIME  ");
                    sbQuery.Append(" ,W.CHAIN_WO_NO  ");
                    sbQuery.Append(" ,W.PT_ID  ");
                    sbQuery.Append(" ,PT.PART_PUID  ");
                    sbQuery.Append(" ,SPT.PART_NAME AS PART_PUID_NAME  ");
                    //sbQuery.Append(" ,CASE WHEN W.RE_WO_NO IS NULL THEN '0' ELSE '1' END IS_REWORK  ");

                    sbQuery.Append(" ,CASE WHEN W.RE_WO_NO IS NULL THEN '0'");
                    sbQuery.Append("   ELSE CASE WHEN W.IS_DES_CHANGE = 1 AND ISNULL(W.IS_REMCT, 0) = 0 AND ISNULL(W.IS_MODIFY, 0) = 0 THEN '2' ");
                    sbQuery.Append("             WHEN W.IS_DES_CHANGE = 1 AND ISNULL(W.IS_REMCT, 0) = 0 AND ISNULL(W.IS_MODIFY, 0) = 1 THEN '3'");
                    sbQuery.Append("             WHEN W.IS_DES_CHANGE = 1 AND ISNULL(W.IS_REMCT, 0) = 1 AND ISNULL(W.IS_MODIFY, 0) = 0 THEN '4'");
                    sbQuery.Append("             WHEN N.NG_TYPE = 'P' THEN '5' ELSE '6' END END AS IS_REWORK");

                    sbQuery.Append(" ,W.RE_WO_NO");
                    //sbQuery.Append(" ,ISNULL(PT.Material, S.MAT_QLTY) AS MAT_QLTY");
                    sbQuery.Append(" ,PT.Material AS MAT_QLTY");
                    sbQuery.Append(" ,TP.PROD_PRIORITY");
                    sbQuery.Append(" ,AD.DRAW_EMP ");
                    sbQuery.Append(" FROM TSHP_WORKORDER W ");
                    sbQuery.Append(" LEFT JOIN TORD_PRODUCT TP ON TP.PLT_CODE = W.PLT_CODE AND TP.PROD_CODE = W.PROD_CODE ");

                    sbQuery.Append(" LEFT JOIN LSE_STD_PART S ON W.PLT_CODE = S.PLT_CODE AND  W.PART_CODE = S.PART_CODE  ");

                    sbQuery.Append(" LEFT JOIN LSE_STD_PROC SP ON W.PLT_CODE = SP.PLT_CODE AND W.PROC_CODE = SP.PROC_CODE ");

                    sbQuery.Append(" LEFT JOIN LSE_MACHINE M ON W.PLT_CODE = M.PLT_CODE AND W.MC_CODE = M.MC_CODE ");

                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE E ON W.PLT_CODE = E.PLT_CODE AND W.EMP_CODE = E.EMP_CODE ");

                    sbQuery.Append(" LEFT JOIN TMAT_PARTLIST PT ON W.PLT_CODE = PT.PLT_CODE AND W.PT_ID = PT.PT_ID ");

                    sbQuery.Append(" LEFT JOIN LSE_STD_PART ST ON PT.PLT_CODE = ST.PLT_CODE AND  PT.MAT_CODE = ST.PART_CODE  ");

                    sbQuery.Append(" LEFT JOIN LSE_STD_PART SPT ON PT.PLT_CODE = SPT.PLT_CODE AND  PT.PART_PUID = SPT.PART_CODE  ");

                    sbQuery.Append(" LEFT JOIN TSTD_VENDOR CVND");
                    sbQuery.Append(" ON TP.PLT_CODE = CVND.PLT_CODE");
                    sbQuery.Append(" AND TP.CVND_CODE = CVND.VEN_CODE");

                    sbQuery.Append(" LEFT JOIN TSTD_BILL_VENDOR TVND");
                    sbQuery.Append(" ON TP.PLT_CODE = TVND.PLT_CODE");
                    sbQuery.Append(" AND TP.TVND_CODE = TVND.BVEN_CODE");

                    sbQuery.Append(" LEFT JOIN (");
                    sbQuery.Append(" SELECT PLT_CODE, PROD_CODE, MAX(DRAW_EMP) AS DRAW_EMP FROM TMAT_PARTLIST");
                    sbQuery.Append(" WHERE ISNULL(O_PT_ID,'') = '' AND DATA_FLAG = '0' AND LEFT(PART_CODE,1) = 'A'");
                    sbQuery.Append(" GROUP BY PLT_CODE, PROD_CODE");
                    sbQuery.Append(" ) AD");
                    sbQuery.Append(" ON TP.PLT_CODE = AD.PLT_CODE");
                    sbQuery.Append(" AND TP.PROD_CODE = AD.PROD_CODE");

                    sbQuery.Append(" LEFT JOIN (SELECT PLT_CODE, PT_ID, PROD_CODE FROM TSHP_WORKORDER WHERE DATA_FLAG = '0' AND PROC_CODE = 'P-02') CWO");
                    sbQuery.Append(" ON W.PLT_CODE = CWO.PLT_CODE");
                    sbQuery.Append(" AND W.PROD_CODE = CWO.PROD_CODE");
                    sbQuery.Append(" AND W.PT_ID = CWO.PT_ID");

                    sbQuery.Append(" LEFT JOIN TSHP_NG N");
                    sbQuery.Append(" ON W.PLT_CODE = N.PLT_CODE");
                    sbQuery.Append(" AND W.RE_WO_NO = N.RE_WO_NO");

                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE WE");
                    sbQuery.Append(" ON W.PLT_CODE = WE.PLT_CODE");
                    sbQuery.Append(" AND W.CAM_EMP = WE.EMP_CODE");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder();

                        sbWhere.Append(" WHERE W.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());


                        sbWhere.Append(UTIL.GetWhere(row, "@S_REG_DATE, @E_REG_DATE", "(CONVERT(nvarchar(8),TP.REG_DATE,112) BETWEEN @S_REG_DATE AND @E_REG_DATE)"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_ORD_DATE, @E_ORD_DATE", "(TP.ORD_DATE BETWEEN @S_ORD_DATE AND @E_ORD_DATE)"));
                        //sbWhere.Append(UTIL.GetWhere(row, "@S_DUE_DATE, @E_DUE_DATE", "(TP.DUE_DATE BETWEEN @S_DUE_DATE AND @E_DUE_DATE)"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_DUE_DATE, @E_DUE_DATE", "ISNULL(TP.CHG_DUE_DATE, TP.DUE_DATE) BETWEEN @S_DUE_DATE AND @E_DUE_DATE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_DELIVERY_DATE, @E_DELIVERY_DATE", "(TP.DELIVERY_DATE BETWEEN @S_DELIVERY_DATE AND @E_DELIVERY_DATE)"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_LIKE", "W.PROD_CODE LIKE '%' + @PROD_LIKE + '%' OR TP.PROD_NAME LIKE '%' + @PROD_LIKE + '%'"));
                        sbWhere.Append(UTIL.GetWhere(row, "@BUSINESS_EMP", "TP.BUSINESS_EMP = @BUSINESS_EMP"));
                        sbWhere.Append(UTIL.GetWhere(row, "@CVND_LIKE", "TP.CVND_CODE LIKE '%' + @CVND_LIKE + '%' OR CVND.VEN_NAME LIKE '%' + @CVND_LIKE + '%'"));
                        sbWhere.Append(UTIL.GetWhere(row, "@CVND_CODE", "TP.CVND_CODE = @CVND_CODE"));

                        sbWhere.Append(UTIL.GetWhere(row, "@WO_NO", "W.WO_NO = @WO_NO"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_CODE", "W.PROD_CODE = @PROD_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_CODE", "W.PART_CODE = @PART_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_LIKE", "W.PART_CODE LIKE '%' + @PART_LIKE + '%' OR S.PART_NAME LIKE '%' + @PART_LIKE + '%' "));
                        sbWhere.Append(UTIL.GetWhere(row, "@MC_CODE", "W.MC_CODE = @MC_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PROC_CODE", "W.PROC_CODE = @PROC_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@EMP_CODE", "W.EMP_CODE = @EMP_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@WO_TYPE", "SP.WO_TYPE = @WO_TYPE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "W.DATA_FLAG = @DATA_FLAG"));
                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "TP.DATA_FLAG = @DATA_FLAG"));

                        sbWhere.Append(UTIL.GetWhere(row, "@NOT_WO_NO", "W.WO_NO <> @NOT_WO_NO"));
                        sbWhere.Append(UTIL.GetWhere(row, "@CHAIN_WO_NO", "W.CHAIN_WO_NO = @CHAIN_WO_NO"));
                        sbWhere.Append(UTIL.GetWhere(row, "@MAT_QLTY", "PT.Material LIKE '%' + @MAT_QLTY + '%'"));

                        sbWhere.Append(UTIL.GetWhere(row, "@WO_LIKE", "W.WO_FLAG IN @WO_LIKE", UTIL.SqlCondType.IN));
                        sbWhere.Append(UTIL.GetWhere(row, "@PT_ID_NOT_IN", "W.PT_ID NOT IN @PT_ID_NOT_IN", UTIL.SqlCondType.IN));

                        sbWhere.Append(UTIL.GetWhere(row, "@CAM_EMP_ALL", "(W.CAM_EMP = @CAM_EMP_ALL OR ISNULL(CAM_EMP,'') = '')"));


                        sbWhere.Append(UTIL.GetWhere(row, "@CHAIN_WO_LIKE", "W.CHAIN_WO_NO LIKE '%' + @CHAIN_WO_LIKE + '%'"));

                        sbWhere.Append(" AND TP.PROD_CODE IS NOT NULL ");
                        sbWhere.Append(" AND CWO.PT_ID IS NULL AND TP.PROD_STATE <> '5'");

                        sbWhere.Append(" ORDER BY W.PART_ID, W.PROC_ID");

                        DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString() + sbWhere.ToString(), row).Copy();

                        sourceTable.TableName = "RSLTDT";
                        dsResult.Merge(sourceTable, false, MissingSchemaAction.Add);
                    }
                }

                return UTIL.GetDsToDt(dsResult);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }



        //작업지시 조회()
        public static DataTable TSHP_WORKORDER_QUERY10(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT ");
                    sbQuery.Append(" W.PLT_CODE, ");
                    sbQuery.Append(" W.WO_FLAG,  ");
                    sbQuery.Append(" W.JOB_PRIORITY, ");
                    sbQuery.Append(" (SELECT CD_NAME FROM TSTD_CODES WHERE CAT_CODE = 'S032' AND CD_CODE = W.WO_FLAG) AS WO_FLAG_NAME,  ");
                    sbQuery.Append(" I.CVND_CODE,  ");
                    sbQuery.Append(" V.VEN_NAME AS CVND_NAME,  ");
                    sbQuery.Append(" I.ITEM_CODE,  ");
                    sbQuery.Append(" I.ITEM_NAME,  ");
                    sbQuery.Append(" W.PROD_CODE, ");
                    sbQuery.Append(" P.PROD_NAME, ");
                    sbQuery.Append(" P.DUE_DATE, ");
                    sbQuery.Append(" P.PARENT_PART, ");
                    sbQuery.Append(" W.PART_CODE, ");
                    sbQuery.Append(" R.PART_NAME, ");
                    sbQuery.Append(" W.PART_NUM, ");
                    sbQuery.Append(" R.DRAW_NO, ");
                    sbQuery.Append(" R.MAT_SPEC AS PART_SPEC,  ");
                    sbQuery.Append(" R.MAT_SPEC1 AS PART_SPEC1, ");
                    sbQuery.Append(" R.MAT_QLTY AS PART_QLTY,  ");
                    sbQuery.Append(" QLTY.MQLTY_NAME AS PART_QLTY_NAME, ");
                    sbQuery.Append(" R.PART_PRODTYPE, ");
                    sbQuery.Append(" W.PROC_CODE, ");
                    sbQuery.Append(" W.PROC_SEQ,  ");
                    sbQuery.Append(" W.WORK_CODE, ");
                    sbQuery.Append(" PR.PROC_NAME, ");

                    sbQuery.Append(" W.PROC_CODE + ':' + W.MC_CODE AS W_MC_CODE, ");
                    sbQuery.Append(" W.MC_CODE + ':' + W.EMP_CODE AS W_EMP_CODE, ");
                    sbQuery.Append(" W.MC_CODE, ");
                    sbQuery.Append(" W.EMP_CODE, ");

                    sbQuery.Append(" W.MC_CODE, ");
                    sbQuery.Append(" M.MC_NAME, ");
                    sbQuery.Append(" M.MC_GROUP, ");
                    sbQuery.Append(" W.EMP_CODE, ");
                    sbQuery.Append(" E.EMP_NAME, ");
                    sbQuery.Append(" W.PLN_START_TIME,  ");
                    sbQuery.Append(" W.PLN_END_TIME,  ");
                    sbQuery.Append(" dbo.fnCharToDate(W.PLN_START_TIME) AS PLN_START ,   ");
                    sbQuery.Append(" dbo.fnCharToDate(W.PLN_END_TIME) AS PLN_END ,   ");
                    sbQuery.Append(" W.PLN_PROC_TIME,  ");
                    sbQuery.Append(" ISNULL(W.PLN_PROC_TIME, PR.PROC_MAN_TIME) AS PROC_MAN_TIME ,  ");
                    sbQuery.Append(" W.ACT_START_TIME, ");
                    sbQuery.Append(" W.ACT_END_TIME, ");
                    sbQuery.Append(" W.ACT_MC_TIME, ");
                    sbQuery.Append(" dbo.fn_dm_datetime(W.ACT_END_TIME) AS ACT_END, ");
                    sbQuery.Append(" W.ACT_MAN_TIME, ");
                    sbQuery.Append(" (ISNULL(W.ACT_MC_TIME, 0) + ISNULL(W.ACT_MAN_TIME, 0) + ISNULL(W.ACT_PRE_TIME, 0)) AS ACT_TIME , ");
                    sbQuery.Append(" W.PART_QTY,  ");
                    sbQuery.Append(" W.ACT_QTY,   ");
                    sbQuery.Append(" W.SCOMMENT, ");
                    sbQuery.Append(" WP.SCOMMENT AS WP_SCOMMENT, ");

                    sbQuery.Append(" W.CAUTION, ");
                    sbQuery.Append(" W.REG_DATE, W.REG_EMP,  ");
                    sbQuery.Append(" REG_EMP.EMP_NAME AS REG_EMP_NAME ,  ");
                    sbQuery.Append(" W.MDFY_DATE, W.MDFY_EMP ,  ");
                    sbQuery.Append(" MDFY_EMP.EMP_NAME AS MDFY_EMP_NAME ,  ");
                    sbQuery.Append(" W.PART_ID, W.PROC_ID,  ");
                    sbQuery.Append(" W.WO_NO,  ");
                    sbQuery.Append(" W.WP_NO,  ");
                    sbQuery.Append(" W.WO_TYPE,  ");
                    sbQuery.Append(" W.PRE_CAM, ");
                    sbQuery.Append(" W.ACT_INPUT_TYPE , ");
                    sbQuery.Append(" W.IS_FIX, ");
                    sbQuery.Append(" P.ORD_DATE, ");
                    sbQuery.Append(" P.INDUE_DATE, ");
                    sbQuery.Append(" P.DUE_DATE, ");
                    sbQuery.Append(" P.PROD_STATE, ");
                    sbQuery.Append(" PR.PROC_COLOR, ");
                    sbQuery.Append(" W.PUR_STAT , ");
                    sbQuery.Append(" W.OS_VND ,  ");
                    sbQuery.Append(" PR.IS_ASSY,  ");
                    sbQuery.Append(" W.IS_YPGO  ");
                    sbQuery.Append(" FROM TSHP_WORKORDER W  ");
                    sbQuery.Append(" LEFT JOIN TSHP_WORKPLAN WP  ");
                    sbQuery.Append(" ON W.PLT_CODE = WP.PLT_CODE  ");
                    sbQuery.Append(" AND W.WP_NO = WP.WP_NO  ");
                    sbQuery.Append(" LEFT JOIN TORD_PRODUCT P  ");
                    sbQuery.Append(" ON W.PLT_CODE = P.PLT_CODE  ");
                    sbQuery.Append(" AND W.PROD_CODE = P.PROD_CODE  ");
                    sbQuery.Append(" AND W.PART_CODE = P.PART_CODE  ");

                    sbQuery.Append(" LEFT JOIN TORD_ITEM I ");
                    sbQuery.Append("  ON P.PLT_CODE = I.PLT_CODE ");
                    sbQuery.Append("  AND P.ITEM_CODE = I.ITEM_CODE  ");

                    sbQuery.Append(" LEFT JOIN TSTD_VENDOR V ");
                    sbQuery.Append("  ON I.PLT_CODE = V.PLT_CODE ");
                    sbQuery.Append("  AND I.CVND_CODE = V.VEN_CODE  ");

                    sbQuery.Append(" LEFT JOIN LSE_STD_PART R  ");
                    sbQuery.Append(" ON W.PLT_CODE = R.PLT_CODE ");
                    sbQuery.Append(" AND W.PART_CODE = R.PART_CODE  ");

                    sbQuery.Append(" LEFT JOIN LSE_STD_PROC PR ");
                    sbQuery.Append(" ON W.PLT_CODE = PR.PLT_CODE ");
                    sbQuery.Append(" AND W.PROC_CODE = PR.PROC_CODE  ");

                    sbQuery.Append(" LEFT JOIN LSE_MACHINE M  ");
                    sbQuery.Append(" ON W.PLT_CODE = M.PLT_CODE  ");
                    sbQuery.Append(" AND W.MC_CODE = M.MC_CODE  ");

                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE E ");
                    sbQuery.Append(" ON W.PLT_CODE = E.PLT_CODE ");
                    sbQuery.Append(" AND W.EMP_CODE = E.EMP_CODE ");

                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE REG_EMP ");
                    sbQuery.Append(" ON W.PLT_CODE = REG_EMP.PLT_CODE ");
                    sbQuery.Append(" AND W.REG_EMP= REG_EMP.EMP_CODE ");

                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE MDFY_EMP ");
                    sbQuery.Append(" ON W.PLT_CODE = MDFY_EMP.PLT_CODE ");
                    sbQuery.Append(" AND W.MDFY_EMP = MDFY_EMP.EMP_CODE ");

                    sbQuery.Append(" LEFT JOIN TMAT_QUC_MASTER QLTY ");
                    sbQuery.Append(" ON R.PLT_CODE = QLTY.PLT_CODE ");
                    sbQuery.Append(" AND R.MAT_QLTY = QLTY.MQLTY_CODE ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder();

                        sbWhere.Append(" WHERE W.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@WO_NO", "W.WO_NO = @WO_NO"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PLN_START_DATE, @PLN_END_DATE", "(W.PLN_START_TIME BETWEEN @PLN_START_DATE + '0000' AND @PLN_END_DATE + '9999') "));

                        sbWhere.Append(UTIL.GetWhere(row, "@FINISH_PLAN",
                            "(W.PLN_START_TIME BETWEEN @FI_PLN_START_DATE + '0000' AND @FI_PLN_END_DATE + '9999') OR  " +
                            "(dbo.fn_dm_datetime(W.ACT_START_TIME) BETWEEN @FI_PLN_START_DATE + '0000' AND @FI_PLN_END_DATE + '9999' AND W.WO_FLAG = '4') "));

                        //설비별 작업현황 조건 - 일정 미수립 조회
                        sbWhere.Append(UTIL.GetWhere(row, "@NO_PLAN", "W.WO_FLAG IN ('0', '1') AND ( ISNULL(W.PLN_START_TIME, '000101010000') = '000101010000' OR ISNULL(W.PLN_END_TIME, '000101010000') = '000101010000' ) "));
                        sbWhere.Append(UTIL.GetWhere(row, "@PROC_GRP", "PR.MPROC_CODE = @PROC_GRP"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_CODE", "W.PROD_CODE = @PROD_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@MC_GRP", "M.MC_GROUP = @MC_GRP"));
                        sbWhere.Append(UTIL.GetWhere(row, "@ORG_CODE", "E.ORG_CODE = @ORG_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_CODE", "W.PART_CODE = @PART_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@WO_FLAG_OPT0", "W.WO_FLAG NOT IN ('0')"));
                        sbWhere.Append(UTIL.GetWhere(row, "@WO_FLAG_OPT1", "W.WO_FLAG NOT IN ('1')"));
                        sbWhere.Append(UTIL.GetWhere(row, "@WO_FLAG_OPT2", "W.WO_FLAG NOT IN ('2')"));
                        sbWhere.Append(UTIL.GetWhere(row, "@WO_FLAG_OPT3", "W.WO_FLAG NOT IN ('3')"));
                        sbWhere.Append(UTIL.GetWhere(row, "@WO_FLAG_OPT4", "W.WO_FLAG NOT IN ('4')"));
                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "W.DATA_FLAG = @DATA_FLAG AND P.DATA_FLAG = @DATA_FLAG AND R.DATA_FLAG = 0 "));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_WORK_DATE,@E_WORK_DATE", "W.WO_NO IN (SELECT WO_NO FROM TSHP_ACTUAL ACT WHERE ACT.PLT_CODE = W.PLT_CODE AND ACT.WORK_DATE BETWEEN @S_WORK_DATE AND @E_WORK_DATE)"));
                        sbWhere.Append(UTIL.GetWhere(row, "@WORK_EMP_CODE", "W.WO_NO IN (SELECT WO_NO FROM TSHP_WORKORDER WHERE PLT_CODE = W.PLT_CODE AND MC_CODE IN (SELECT MC_CODE FROM TSTD_MC_AVAILEMP WHERE PLT_CODE = W.PLT_CODE AND EMP_CODE = @WORK_EMP_CODE))"));
                        sbWhere.Append(UTIL.GetWhere(row, "@ACT_ORG_CODE", "W.WO_NO IN (SELECT WO_NO FROM TSHP_ACTUAL ACT LEFT JOIN TSTD_EMPLOYEE EMP ON ACT.PLT_CODE = EMP.PLT_CODE AND ACT.EMP_CODE = EMP.EMP_CODE WHERE ACT.PLT_CODE = W.PLT_CODE AND EMP.ORG_CODE = @ACT_ORG_CODE)"));
                        sbWhere.Append(UTIL.GetWhere(row, "@ACT_EMP_CODE", "W.WO_NO IN (SELECT WO_NO FROM TSHP_ACTUAL ACT WHERE ACT.PLT_CODE = W.PLT_CODE AND ACT.EMP_CODE = @ACT_EMP_CODE)"));
                        sbWhere.Append(UTIL.GetWhere(row, "@START_PLN_ERR", "(W.PLN_START_TIME < @START_PLN_ERR AND W.WO_FLAG = '1')"));
                        sbWhere.Append(UTIL.GetWhere(row, "@END_PLN_ERR", "(W.PLN_END_TIME < @END_PLN_ERR AND W.WO_FLAG IN ('2','3'))"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_ID", "W.PART_ID = @PART_ID"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PROC_ID", "W.PROC_ID = @PROC_ID"));
                        sbWhere.Append(UTIL.GetWhere(row, "@ACT_INPUT_TYPE", "W.ACT_INPUT_TYPE = @ACT_INPUT_TYPE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@EMP_CODE", "W.EMP_CODE = @EMP_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@WO_TYPE", "PR.WO_TYPE = @WO_TYPE"));

                        //계획일 + 작업일 조회
                        //작업지시 상태에 따라 미확정, 확정은 계획일 기준
                        //진행 이후는 작업일 기준으로 조회됨.
                        sbWhere.Append(UTIL.GetWhere(row, "@WO_START_TIME,@WO_END_TIME,@WO_START_DATETIME,@WO_END_DATETIME", "((W.WO_FLAG = '0' AND W.PLN_START_TIME BETWEEN @WO_START_TIME + '0000' AND @WO_END_TIME + '9999') OR (W.WO_FLAG = '1' AND W.PLN_START_TIME BETWEEN @WO_START_TIME + '0000' AND @WO_END_TIME + '9999') OR (W.WO_FLAG = '2' AND W.ACT_START_TIME BETWEEN @WO_START_DATETIME AND @WO_END_DATETIME) OR (W.WO_FLAG = '3' AND W.ACT_START_TIME BETWEEN @WO_START_DATETIME AND @WO_END_DATETIME) OR (W.WO_FLAG = '4' AND W.ACT_START_TIME BETWEEN @WO_START_DATETIME AND @WO_END_DATETIME) )"));

                        //sbWhere.Append(UTIL.GetWhere(row, "@WO_START_DATE_TIME,@WO_END_DATE_TIME", "W.ACT_START_TIME BETWEEN @WO_START_DATE_TIME AND @WO_END_DATE_TIME "));
                        sbWhere.Append(UTIL.GetWhere(row, "@PROC_CODE", "W.PROC_CODE = @PROC_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@SHIP_PROC_CODE", "W.PROC_CODE = @SHIP_PROC_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PROC_GRP", "PR.MPROC_CODE = @PROC_GRP"));
                        sbWhere.Append(UTIL.GetWhere(row, "@ITEM_CODE", "P.ITEM_CODE = @ITEM_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@MC_CODE", "W.MC_CODE = @MC_CODE"));

                        sbWhere.Append(UTIL.GetWhere(row, "@EXCEPT_STOCK", "V.ITEM_AUTO_CODE NOT IN ('H', 'S') "));

                        sbWhere.Append(" ORDER BY W.PROD_CODE, P.PART_SEQ, PR.PROC_SEQ ");

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

        ///// <summary>
        ///// 출하 현황판에 보여지는 출하 공정 대상 리스트
        ///// </summary>
        ///// <param name="dtParam"></param>
        ///// <param name="bizExecute"></param>
        ///// <returns></returns>
        //public static DataTable TSHP_WORKORDER_QUERY10_2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        //{
        //    try
        //    {
        //        DataSet dsResult = new DataSet();

        //        if (dtParam.Rows.Count > 0)
        //        {
        //            StringBuilder sbQuery = new StringBuilder();

        //            sbQuery.Append(" SELECT ");
        //            sbQuery.Append(" W.PLT_CODE, ");
        //            sbQuery.Append(" W.WO_FLAG,  ");
        //            sbQuery.Append(" W.JOB_PRIORITY, ");
        //            sbQuery.Append(" I.CVND_CODE,  ");
        //            sbQuery.Append(" I.ITEM_CODE,  ");
        //            sbQuery.Append(" I.ITEM_NAME,  ");
        //            sbQuery.Append(" W.PROD_CODE, ");
        //            sbQuery.Append(" P.PROD_NAME, ");
        //            sbQuery.Append(" W.PROC_SEQ,  ");
        //            sbQuery.Append(" P.DUE_DATE, ");
        //            sbQuery.Append(" P.PARENT_PART, ");
        //            sbQuery.Append(" W.PART_CODE, ");
        //            sbQuery.Append(" W.PART_NUM, ");
        //            sbQuery.Append(" W.PROC_CODE ");

        //            sbQuery.Append(" FROM TSHP_WORKORDER W  ");
        //            sbQuery.Append("  JOIN TORD_PRODUCT P  ");
        //            sbQuery.Append(" ON W.PLT_CODE = P.PLT_CODE  ");
        //            sbQuery.Append(" AND W.PROD_CODE = P.PROD_CODE  ");
        //            sbQuery.Append(" AND W.PART_CODE = P.PART_CODE  ");

        //            sbQuery.Append("  JOIN TORD_ITEM I ");
        //            sbQuery.Append("  ON P.PLT_CODE = I.PLT_CODE ");
        //            sbQuery.Append("  AND P.ITEM_CODE = I.ITEM_CODE  ");


        //            foreach (DataRow row in dtParam.Rows)
        //            {
        //                StringBuilder sbWhere = new StringBuilder();

        //                sbWhere.Append(" WHERE W.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

        //                sbWhere.Append(UTIL.GetWhere(row, "@ASSY_PROC", "(P.PROD_STATE IN ('WK', 'PG')) AND  W.PROC_CODE = @ASSY_PROC"));
        //                sbWhere.Append(UTIL.GetWhere(row, "@SHIP_DATE", "(P.PROD_STATE IN ('WK', 'PG')) OR (P.PROD_STATE = 'SH' AND P.SHIP_DATE = @SHIP_DATE )"));
        //                sbWhere.Append(UTIL.GetWhere(row, "@WO_FLAG_OPT0", "W.WO_FLAG NOT IN ('0')"));
        //                sbWhere.Append(UTIL.GetWhere(row, "@WO_FLAG_OPT1", "W.WO_FLAG NOT IN ('1')"));
        //                sbWhere.Append(UTIL.GetWhere(row, "@WO_FLAG_OPT2", "W.WO_FLAG NOT IN ('2')"));
        //                sbWhere.Append(UTIL.GetWhere(row, "@WO_FLAG_OPT3", "W.WO_FLAG NOT IN ('3')"));
        //                sbWhere.Append(UTIL.GetWhere(row, "@WO_FLAG_OPT4", "W.WO_FLAG NOT IN ('4')"));
        //                sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "W.DATA_FLAG = @DATA_FLAG AND P.DATA_FLAG = @DATA_FLAG "));

        //                sbWhere.Append(UTIL.GetWhere(row, "@PROC_CODE", "W.PROC_CODE = @PROC_CODE"));

        //                sbWhere.Append(" ORDER BY W.PROD_CODE, P.PART_SEQ ");

        //                DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString() + sbWhere.ToString(), row).Copy();

        //                sourceTable.TableName = "RSLTDT";
        //                dsResult.Merge(sourceTable);
        //            }
        //        }

        //        return UTIL.GetDsToDt(dsResult);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
        //    }
        //}

        //public static DataTable TSHP_WORKORDER_QUERY10_3(DataTable dtParam, BizExecute.BizExecute bizExecute)
        //{
        //    try
        //    {
        //        DataSet dsResult = new DataSet();

        //        if (dtParam.Rows.Count > 0)
        //        {
        //            StringBuilder sbQuery = new StringBuilder();

        //            sbQuery.Append(" SELECT ");
        //            sbQuery.Append(" W.PLT_CODE, ");
        //            sbQuery.Append(" W.WO_FLAG,  ");
        //            sbQuery.Append(" W.JOB_PRIORITY, ");
        //            sbQuery.Append(" I.CVND_CODE,  ");
        //            sbQuery.Append(" I.ITEM_CODE,  ");
        //            sbQuery.Append(" I.ITEM_NAME,  ");
        //            sbQuery.Append(" W.PROD_CODE, ");
        //            sbQuery.Append(" P.PROD_NAME, ");
        //            sbQuery.Append(" W.PROC_SEQ,  ");
        //            sbQuery.Append(" P.DUE_DATE, ");
        //            sbQuery.Append(" P.PARENT_PART, ");
        //            sbQuery.Append(" W.PART_CODE, ");
        //            sbQuery.Append(" W.PART_NUM, ");
        //            sbQuery.Append(" W.PROC_CODE, ");
        //            sbQuery.Append(" LPT.MAT_SPEC1, ");
        //            sbQuery.Append(" LPT.DRAW_NO ");

        //            sbQuery.Append(" FROM TSHP_WORKORDER W  ");
        //            sbQuery.Append("  JOIN TORD_PRODUCT P  ");
        //            sbQuery.Append(" ON W.PLT_CODE = P.PLT_CODE  ");
        //            sbQuery.Append(" AND W.PROD_CODE = P.PROD_CODE  ");
        //            sbQuery.Append(" AND W.PART_CODE = P.PART_CODE  ");

        //            sbQuery.Append("  JOIN TORD_ITEM I ");
        //            sbQuery.Append("  ON P.PLT_CODE = I.PLT_CODE ");
        //            sbQuery.Append("  AND P.ITEM_CODE = I.ITEM_CODE  ");

        //            sbQuery.Append(" LEFT JOIN LSE_STD_PART LPT	   ");
        //            sbQuery.Append(" ON W.PLT_CODE = LPT.PLT_CODE   ");
        //            sbQuery.Append(" AND W.PART_CODE = LPT.PART_CODE");


        //            foreach (DataRow row in dtParam.Rows)
        //            {
        //                StringBuilder sbWhere = new StringBuilder();

        //                sbWhere.Append(" WHERE W.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

        //                sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "W.DATA_FLAG = @DATA_FLAG AND P.DATA_FLAG = @DATA_FLAG "));

        //                sbWhere.Append(UTIL.GetWhere(row, "@PROD_CODE", "W.PROD_CODE = @PROD_CODE"));
        //                sbWhere.Append(UTIL.GetWhere(row, "@PROC_CODE", "W.PROC_CODE = @PROC_CODE"));

        //                sbWhere.Append(" ORDER BY W.PROD_CODE, P.PART_SEQ ");

        //                DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString() + sbWhere.ToString(), row).Copy();

        //                sourceTable.TableName = "RSLTDT";
        //                dsResult.Merge(sourceTable);
        //            }
        //        }

        //        return UTIL.GetDsToDt(dsResult);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
        //    }
        //}

        
        /// <summary>
        /// 공정외주 발주 대상 목록
        /// HJKIM /21.05.04
        /// </summary>
        /// <param name="dtParam"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataTable TSHP_WORKORDER_QUERY11(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT W.PLT_CODE, W.PROD_CODE");
                    sbQuery.Append(" , PR.PROD_NAME");
                    sbQuery.Append(" , W.WO_NO");
                    sbQuery.Append(" , W.PART_CODE");
                    sbQuery.Append(" , P.PART_NAME");
                    sbQuery.Append(" , P.PART_PRODTYPE");
                    sbQuery.Append(" , P.MAT_LTYPE");
                    sbQuery.Append(" , P.MAT_MTYPE");
                    sbQuery.Append(" , ISNULL(P.INS_FLAG, 1) AS INS_FLAG ");
                    sbQuery.Append(" , W.PROC_CODE");
                    sbQuery.Append(" , SP.PROC_NAME");
                    sbQuery.Append(" , W.PART_QTY");
                    sbQuery.Append(" , CASE WHEN W.PROC_CODE = 'P14' THEN ISNULL(P.PROC_COST, 0) WHEN W.PROC_CODE = 'P-08' THEN ISNULL(P.PROC_COST2,0) ELSE 0 END AS PROC_COST");
                    sbQuery.Append(" , ISNULL(W.PART_QTY, 0) * CASE WHEN W.PROC_CODE = 'P14' THEN ISNULL(P.PROC_COST, 0) WHEN W.PROC_CODE = 'P-08' THEN ISNULL(P.PROC_COST2,0) ELSE 0 END AS PROC_AMT");
                    sbQuery.Append(" , CASE WHEN W.PROC_CODE = 'P14' THEN  P.MAIN_VND WHEN W.PROC_CODE = 'P-08' THEN P.MAIN_VND2 ELSE NULL END AS MAIN_VND");
                    sbQuery.Append(" , P.SUPP_VND");
                    sbQuery.Append(" , W.SCOMMENT");
                    sbQuery.Append(" , W.PROD_CODE");
                    sbQuery.Append(" , W2.ACT_END_TIME AS 'PROC_END_TIME' "); //가공완료
                    sbQuery.Append(" , W3.ACT_END_TIME AS 'INS_END_TIME'  "); //중간검사완료
                    //sbQuery.Append(" , VP.MARTERIAL"); // 인터페이스 항목 재질,표면가공,후처리
                    //sbQuery.Append(" , ISNULL(PT.MATERIAL, P.MAT_QLTY) AS MAT_QLTY");
                    //sbQuery.Append(" , ISNULL(PT.AFTER_TREAT, P.AFTER_TREAT) AS AFTER_TREAT");
                    sbQuery.Append(" , PT.MATERIAL AS MAT_QLTY");
                    sbQuery.Append(" , PT.SURFACE_TREAT AS SURFACE_TREAT");                    
                    sbQuery.Append(" , PT.AFTER_TREAT AS AFTER_TREAT");
                    //sbQuery.Append(" , VP.SURFACE_TREAT");
                    //sbQuery.Append(" , P.AFTER_TREAT");


                    sbQuery.Append(" ,PR.ORD_DATE ");
                    sbQuery.Append(" ,PR.DUE_DATE AS ORD_DUE_DATE");
                    sbQuery.Append(" ,PR.CHG_DUE_DATE ");

                    sbQuery.Append(" FROM TSHP_WORKORDER W JOIN LSE_STD_PART P");
                    sbQuery.Append(" ON W.PLT_CODE = P.PLT_CODE");
                    sbQuery.Append(" AND W.PART_CODE = P.PART_CODE");

                    sbQuery.Append(" LEFT JOIN TORD_PRODUCT PR ");
                    sbQuery.Append(" ON W.PLT_CODE = PR.PLT_CODE ");
                    sbQuery.Append(" AND W.PROD_CODE = PR.PROD_CODE");

                    //sbQuery.Append(" LEFT JOIN VIF_PLM_PART VP");
                    //sbQuery.Append(" ON P.PART_CODE = VP.PART_CODE");

                    sbQuery.Append(" LEFT JOIN LSE_STD_PROC SP ");
                    sbQuery.Append(" ON W.PLT_CODE = SP.PLT_CODE ");
                    sbQuery.Append(" AND W.PROC_CODE = SP.PROC_CODE");

                    sbQuery.Append(" LEFT JOIN TMAT_PARTLIST PT ");
                    sbQuery.Append(" ON W.PLT_CODE = PT.PLT_CODE ");
                    sbQuery.Append(" AND W.PT_ID = PT.PT_ID");


                    // 해당 수주의 품목에 대해 외주여부 관계없이 가공(1차,2차)공정이 완료된 시간을 가져온다.
                    sbQuery.Append(" LEFT JOIN (SELECT PLT_CODE, PROD_CODE, PART_CODE, ACT_END_TIME FROM TSHP_WORKORDER WHERE PROC_CODE = 'P-04' AND WO_FLAG = '4' AND DATA_FLAG = 0) W2 ");
                    sbQuery.Append(" ON W.PLT_CODE = W2.PLT_CODE ");
                    sbQuery.Append(" AND W.PROD_CODE = W2.PROD_CODE ");
                    sbQuery.Append(" AND W.PART_CODE = W2.PART_CODE ");

                    // 해당 수주의 품목에 대해 외주여부 관계없이 중간검사 공정이 완료된 시간을 가져온다.
                    sbQuery.Append(" LEFT JOIN (SELECT PLT_CODE, PROD_CODE, PART_CODE, ACT_END_TIME FROM TSHP_WORKORDER WHERE PROC_CODE = 'P-06' AND WO_FLAG = '4' AND DATA_FLAG = 0) W3 ");
                    sbQuery.Append(" ON W.PLT_CODE = W3.PLT_CODE ");
                    sbQuery.Append(" AND W.PROD_CODE = W3.PROD_CODE ");
                    sbQuery.Append(" AND W.PART_CODE = W3.PART_CODE ");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder();

                        sbWhere.Append(" WHERE W.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                        sbWhere.Append(" AND W.DATA_FLAG = 0 AND W.WO_FLAG = '1' AND ISNULL(W.IS_OS, 0) = 1 AND PR.DATA_FLAG = '0' AND PR.PROD_STATE <> '5' ");

                        sbWhere.Append(UTIL.GetWhere(row, "@WO_LIKE", "W.WO_NO LIKE ('%' + @WO_LIKE + '%') "));
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_LIKE", "(W.PART_CODE LIKE '%' + @PART_LIKE + '%' OR P.PART_NAME LIKE '%' + @PART_LIKE + '%' )"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_LIKE", "(PR.PROD_CODE LIKE '%' + @PROD_LIKE + '%' OR PR.PROD_NAME LIKE '%' + @PROD_LIKE + '%' )"));
                        sbWhere.Append(UTIL.GetWhere(row, "@WO_NO", "W.WO_NO = @WO_NO"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_CODE", "W.PROD_CODE = @PROD_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_PRODTYPE", "PT.PART_PRODTYPE = @PART_PRODTYPE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PLN_START_TIME,@PLN_END_TIME", "W.PLN_START_TIME BETWEEN @PLN_START_TIME + '0000' AND @PLN_END_TIME + '9999'"));
                        
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

        //마지막 공정 작업지시 찾기
        public static DataTable TSHP_WORKORDER_QUERY12(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT 					   ");
                    sbQuery.Append("    W.PLT_CODE				   ");
                    sbQuery.Append(" ,W.WO_NO 					   ");
                    sbQuery.Append(" ,W.WO_FLAG					   ");
                    sbQuery.Append(" ,W.PROD_CODE				   ");
                    sbQuery.Append(" ,W.PART_CODE				   ");
                    sbQuery.Append(" ,W.PART_NUM				   ");
                    sbQuery.Append(" ,W.PROC_CODE				   ");
                    sbQuery.Append(" ,W.PLN_PROC_TIME			   ");
                    sbQuery.Append(" ,W.PART_QTY AS QTY 		   ");
                    sbQuery.Append(" ,W.PART_ID					   ");
                    sbQuery.Append(" ,W.PROC_ID					   ");
                    sbQuery.Append(" ,W.PROC_SEQ  ");
                    sbQuery.Append(" FROM TSHP_WORKORDER W		   ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder();

                        sbWhere.Append(" WHERE W.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                        sbWhere.Append(" AND W.DATA_FLAG = 0    ");
                        sbWhere.Append(" AND W.IS_LAST = 1      ");

                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_CODE", "W.PROD_CODE = @PROD_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_CODE", "W.PART_CODE = @PART_CODE"));

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

        /// <summary>
        /// CAM 작업지시 조회
        /// SJK 2021-05-14
        /// </summary>
        /// <param name="dtParam"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataTable TSHP_WORKORDER_QUERY13(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT W.PLT_CODE");
                    sbQuery.Append(" ,W.CHAIN_WO_NO");
                    sbQuery.Append(" ,W.WP_NO");
                    sbQuery.Append(" ,W.WO_NO");
                    sbQuery.Append(" ,W.PT_ID");
                    sbQuery.Append(" ,S.PART_PRODTYPE");
                    sbQuery.Append(" ,TP.ITEM_CODE");
                    sbQuery.Append(" ,W.PROD_CODE");
                    sbQuery.Append(" ,TP.PROD_NAME");
                    sbQuery.Append(" ,W.PART_CODE");
                    sbQuery.Append(" ,S.PART_NAME");
                    sbQuery.Append(" ,S.STD_PT_NUM ");
                    sbQuery.Append(" ,ISNULL(SP.IS_MAT, 0) IS_MAT");
                    //sbQuery.Append(" ,ISNULL(SP.IS_OS, 0) IS_OS");
                    sbQuery.Append(" ,S.MAT_SPEC");
                    sbQuery.Append(" ,S.MAT_SPEC1");
                    sbQuery.Append(" ,S.BAL_SPEC");
                    sbQuery.Append(" ,S.BAL_WEIGHT");
                    sbQuery.Append(" ,S.DRAW_NO");
                    sbQuery.Append(" ,W.PROC_CODE ");
                    sbQuery.Append(" ,W.PROC_SEQ  ");
                    sbQuery.Append(" ,SP.PROC_NAME ");
                    sbQuery.Append(" ,W.MC_GROUP ");
                    sbQuery.Append(" ,W.MC_CODE ");
                    sbQuery.Append(" ,M.MC_NAME ");
                    sbQuery.Append(" ,W.EMP_CODE");
                    sbQuery.Append(" ,E.EMP_NAME");
                    sbQuery.Append(" ,W.PART_QTY AS PLN_QTY ");
                    sbQuery.Append(" ,W.PART_QTY ");
                    sbQuery.Append(" ,(SELECT ISNULL(SUM(OK_QTY),0) FROM TSHP_ACTUAL A WHERE W.PLT_CODE = A.PLT_CODE AND W.WO_NO = A.WO_NO ) AS ACT_QTY");
                    sbQuery.Append(" ,(SELECT ISNULL(SUM(NG_QTY),0) FROM TSHP_ACTUAL A WHERE W.PLT_CODE = A.PLT_CODE AND W.WO_NO = A.WO_NO ) AS NG_QTY");
                    sbQuery.Append(" ,W.WO_FLAG  ");
                    //sbQuery.Append(" ,W.ACT_START_TIME  ");
                    //sbQuery.Append(" ,W.ACT_END_TIME  ");
                    sbQuery.Append(" ,W.CAUTION  ");
                    sbQuery.Append(" ,W.JOB_PRIORITY  ");
                    sbQuery.Append(" ,W.WORK_CODE  ");
                    sbQuery.Append(" ,ISNULL(W.IS_OS,0) AS IS_OS  ");
                    //sbQuery.Append(" ,SP.IS_MAT  ");
                    sbQuery.Append(" ,W.CAM_EMP  ");
                    sbQuery.Append(" ,CE.EMP_NAME AS CAM_EMP_NAME  ");
                    sbQuery.Append(" ,W.CAM_EMP_DATE  ");
                    sbQuery.Append(" ,W.CAM_DATE  ");

                    sbQuery.Append(" ,TP.PROD_VERSION");
                    sbQuery.Append(" ,TP.PROC_FLAG");
                    sbQuery.Append(" ,TP.PROD_FLAG");
                    sbQuery.Append(" ,TP.INS_YN");
                    sbQuery.Append(" ,TP.SOCKET_YN");
                    sbQuery.Append(" ,TP.PROD_TYPE");
                    sbQuery.Append(" ,TP.PROD_CATEGORY");
                    sbQuery.Append(" ,TP.BUSINESS_EMP");
                    sbQuery.Append(" ,TP.CUSTOMER_EMP");
                    sbQuery.Append(" ,TP.CUSTDESIGN_EMP");
                    sbQuery.Append(" ,TP.ACTUATOR_YN");
                    sbQuery.Append(" ,TP.CVND_CODE");
                    sbQuery.Append(" ,CVND.VEN_NAME AS CVND_NAME");
                    sbQuery.Append(" ,TP.TVND_CODE");
                    sbQuery.Append(" ,TVND.BVEN_NAME AS TVND_NAME");
                    sbQuery.Append(" ,TP.PROBE_PIN");
                    sbQuery.Append(" ,TP.CURR_UNIT");
                    sbQuery.Append(" ,TP.ORD_DATE");
                    sbQuery.Append(" ,TP.INDUE_DATE");
                    sbQuery.Append(" ,TP.DUE_DATE");
                    sbQuery.Append(" ,TP.CHG_DUE_DATE");
                    sbQuery.Append(" ,TP.END_DATE");
                    sbQuery.Append(" ,TP.DELIVERY_DATE");
                    sbQuery.Append(" ,TP.PROD_QTY");

                    sbQuery.Append(" 	, PT.PART_QTY AS BOM_PART_QTY  ");
                    sbQuery.Append(" 	, PT.O_PART_QTY ");
                    sbQuery.Append(" 	, CASE WHEN ISNULL(PT.ORD_QTY, 0) > 0 THEN PT.ORD_QTY ELSE TP.PROD_QTY END AS ORD_PROD_QTY  ");
                    

                    sbQuery.Append(" ,TP.LOAD_FLAG");
                    sbQuery.Append(" ,TP.LOCK_FLAG");
                    sbQuery.Append(" ,TP.LOCK_EMP");
                    sbQuery.Append(" ,TP.SHIP_FLAG");
                    sbQuery.Append(" ,TP.PROD_STATE");
                    sbQuery.Append(" ,TP.INOUT_FLAG");
                    sbQuery.Append(" ,TP.ORD_VAT");
                    sbQuery.Append(" ,TP.PROD_UC");
                    sbQuery.Append(" ,TP.PROD_COST");
                    sbQuery.Append(" ,TP.PROD_VAT");
                    sbQuery.Append(" ,TP.PROD_AMT");
                    sbQuery.Append(" ,TP.PROD_KIND");

                    sbQuery.Append(" ,A.ACT_START_TIME");
                    sbQuery.Append(" ,A.ACT_END_TIME");
                    sbQuery.Append(" ,A.ACT_TIME");

                    sbQuery.Append(" ,A.X_VALUE");
                    sbQuery.Append(" ,A.Y_VALUE");
                    sbQuery.Append(" ,A.T_VALUE");
                    sbQuery.Append(" ,A.P_CNT");
                    sbQuery.Append(" ,A.MIL_REQ_DATE");
                    sbQuery.Append(" ,A.SCOMMENT");
                    sbQuery.Append(" ,ISNULL(A.MAT_CODE,S.MAT_CODE) AS MAT_CODE ");
                    sbQuery.Append(" ,ISNULL(A.MAT_QLTY,S.MAT_QLTY) AS MAT_QLTY ");
                    sbQuery.Append(" ,MAT.PART_NAME AS MAT_CODE_NAME");
                    sbQuery.Append(" ,A.LOT_ID");
                    sbQuery.Append(" ,A.ACTUAL_ID");

                    sbQuery.Append(" ,PT.SCOMMENT AS PT_SCOMMENT ");
                    sbQuery.Append(" ,TP.SCOMMENT AS PD_SCOMMENT ");
                    sbQuery.Append(" ,ISNULL(A.PROC_STAT,'1') AS CAM_STATE");
                    sbQuery.Append(" ,A.PROC_STAT");

                    sbQuery.Append(" ,(SELECT COUNT(*) FROM TSYS_FILELIST_MASTER WHERE PLT_CODE = W.PLT_CODE AND LINK_KEY = W.PT_ID AND DATA_FLAG = '0' AND IS_UPLOAD = '1') AS FILE_CNT ");

                    sbQuery.Append(" ,PT.PART_PUID  ");
                    sbQuery.Append(" ,SPT.PART_NAME AS PART_PUID_NAME  ");
                    sbQuery.Append(" ,SPT.DRAW_NO  ");

                    //sbQuery.Append(" ,CASE WHEN W.RE_WO_NO IS NULL THEN '0' ELSE '1' END IS_REWORK  ");
                    //sbQuery.Append(" ,CASE WHEN W.RE_WO_NO IS NULL THEN '0'");
                    //sbQuery.Append("   ELSE CASE WHEN W.IS_DES_CHANGE = 1 THEN '2' ELSE '1' END END AS IS_REWORK");

                    sbQuery.Append(" ,CASE WHEN W.RE_WO_NO IS NULL THEN '0'");
                    sbQuery.Append("   ELSE CASE WHEN W.IS_DES_CHANGE = 1 AND ISNULL(W.IS_REMCT, 0) = 0 AND ISNULL(W.IS_MODIFY, 0) = 0 THEN '2' ");
                    sbQuery.Append("             WHEN W.IS_DES_CHANGE = 1 AND ISNULL(W.IS_REMCT, 0) = 0 AND ISNULL(W.IS_MODIFY, 0) = 1 THEN '3'");
                    sbQuery.Append("             WHEN W.IS_DES_CHANGE = 1 AND ISNULL(W.IS_REMCT, 0) = 1 AND ISNULL(W.IS_MODIFY, 0) = 0 THEN '4'");
                    sbQuery.Append("             WHEN N.NG_TYPE = 'P' THEN '5' ELSE '6' END END AS IS_REWORK");

                    sbQuery.Append(" ,W.RE_WO_NO");

                    sbQuery.Append(" ,PT.DRAW_EMP  ");
                    //sbQuery.Append(" ,ISNULL(PT.Material, S.MAT_QLTY) AS PART_MAT_QLTY");
                    sbQuery.Append(" ,PT.Material AS PART_MAT_QLTY");
                    sbQuery.Append(" ,AD.DRAW_EMP AS ASY_DRAW_EMP ");
                    sbQuery.Append(" ,TP.PROD_PRIORITY");

                    sbQuery.Append(" ,W.PREV_CHAIN_WO_NO");
                    sbQuery.Append(" ,W.IS_PREV_CHAIN");
                    sbQuery.Append(" ,S.MAT_COST");

                    sbQuery.Append(" ,NN.NG_ID");
                    sbQuery.Append(" ,CASE WHEN NN.NG_ID IS NOT NULL THEN 'O' ELSE 'X' END IS_PREV_NG");

                    sbQuery.Append(" FROM TSHP_WORKORDER W ");
                    
                    sbQuery.Append(" LEFT JOIN TORD_PRODUCT TP ON TP.PLT_CODE = W.PLT_CODE AND TP.PROD_CODE = W.PROD_CODE ");
                    
                    sbQuery.Append(" LEFT JOIN LSE_STD_PART S ON W.PLT_CODE = S.PLT_CODE AND  W.PART_CODE = S.PART_CODE  ");
                    
                    sbQuery.Append(" LEFT JOIN LSE_STD_PROC SP ON W.PLT_CODE = SP.PLT_CODE AND W.PROC_CODE = SP.PROC_CODE ");
                    
                    sbQuery.Append(" LEFT JOIN LSE_MACHINE M ON W.PLT_CODE = M.PLT_CODE AND W.MC_CODE = M.MC_CODE ");
                    
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE E ON W.PLT_CODE = E.PLT_CODE AND W.EMP_CODE = E.EMP_CODE ");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE CE ON W.PLT_CODE = CE.PLT_CODE AND W.CAM_EMP = CE.EMP_CODE ");

                    sbQuery.Append(" LEFT JOIN TSHP_ACTUAL_CAM A ON W.PLT_CODE = A.PLT_CODE AND W.WO_NO = A.WO_NO ");

                    sbQuery.Append(" LEFT JOIN TSTD_VENDOR CVND");
                    sbQuery.Append(" ON TP.PLT_CODE = CVND.PLT_CODE");
                    sbQuery.Append(" AND TP.CVND_CODE = CVND.VEN_CODE");
                    
                    sbQuery.Append(" LEFT JOIN TSTD_BILL_VENDOR TVND");
                    sbQuery.Append(" ON TP.PLT_CODE = TVND.PLT_CODE");
                    sbQuery.Append(" AND TP.TVND_CODE = TVND.BVEN_CODE");
                    
                    
                    sbQuery.Append(" LEFT JOIN LSE_STD_PART MAT ON ISNULL(A.PLT_CODE,S.PLT_CODE) = MAT.PLT_CODE AND  ISNULL(A.MAT_CODE,S.MAT_CODE) = MAT.PART_CODE  ");

                    sbQuery.Append(" LEFT JOIN TMAT_PARTLIST PT ");
                    sbQuery.Append(" ON W.PLT_CODE = PT.PLT_CODE");
                    sbQuery.Append(" AND W.PT_ID = PT.PT_ID");

                    sbQuery.Append(" LEFT JOIN LSE_STD_PART SPT ON PT.PLT_CODE = SPT.PLT_CODE AND  PT.PART_PUID = SPT.PART_CODE  ");

                    sbQuery.Append(" LEFT JOIN (");
                    sbQuery.Append(" SELECT PLT_CODE, PROD_CODE, MAX(DRAW_EMP) AS DRAW_EMP FROM TMAT_PARTLIST");
                    sbQuery.Append(" WHERE ISNULL(O_PT_ID,'') = '' AND DATA_FLAG = '0' AND LEFT(PART_CODE,1) = 'A'");
                    sbQuery.Append(" GROUP BY PLT_CODE, PROD_CODE");
                    sbQuery.Append(" ) AD");
                    sbQuery.Append(" ON TP.PLT_CODE = AD.PLT_CODE");
                    sbQuery.Append(" AND TP.PROD_CODE = AD.PROD_CODE");

                    sbQuery.Append(" LEFT JOIN TSHP_NG N");
                    sbQuery.Append(" ON W.PLT_CODE = N.PLT_CODE");
                    sbQuery.Append(" AND W.RE_WO_NO = N.RE_WO_NO");

                    sbQuery.Append(" LEFT JOIN (");
                    sbQuery.Append(" SELECT * FROM");
                    sbQuery.Append(" (");
                    sbQuery.Append(" SELECT");
                    sbQuery.Append(" ROW_NUMBER() OVER(PARTITION BY W.PART_CODE ORDER BY N.NG_DATE DESC, N.MDFY_DATE DESC) AS NG_SEQ");
                    sbQuery.Append(" ,N.PLT_CODE");
                    sbQuery.Append(" ,N.NG_ID");
                    sbQuery.Append(" ,W.PART_CODE");
                    sbQuery.Append(" FROM TSHP_NG N");
                    sbQuery.Append(" LEFT JOIN TSHP_WORKORDER W");
                    sbQuery.Append(" ON N.LINK_KEY = W.WO_NO");
                    sbQuery.Append(" WHERE W.DATA_FLAG = '0'");
                    sbQuery.Append(" ) NG");
                    sbQuery.Append(" WHERE NG.NG_SEQ = 1");
                    sbQuery.Append(" ) NN");
                    sbQuery.Append(" ON W.PLT_CODE = NN.PLT_CODE");
                    sbQuery.Append(" AND W.PART_CODE = NN.PART_CODE");




                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder();

                        sbWhere.Append(" WHERE W.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                        sbWhere.Append(UTIL.GetWhere(row, "@WO_NO", "W.WO_NO = @WO_NO"));
                        sbWhere.Append(UTIL.GetWhere(row, "@NOT_WO_NO", "W.WO_NO <> @NOT_WO_NO"));
                        sbWhere.Append(UTIL.GetWhere(row, "@CHAIN_WO_NO", "W.CHAIN_WO_NO = @CHAIN_WO_NO"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_CODE", "W.PROD_CODE = @PROD_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_CODE", "W.PART_CODE = @PART_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@MC_CODE", "W.MC_CODE = @MC_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PROC_CODE", "W.PROC_CODE = @PROC_CODE"));
                        //sbWhere.Append(UTIL.GetWhere(row, "@EMP_CODE", "W.EMP_CODE = @EMP_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@CAM_EMP", "W.CAM_EMP = @CAM_EMP"));
                        sbWhere.Append(UTIL.GetWhere(row, "@IS_END", "ISNULL(A.PROC_STAT,'0') <> 4"));
                        sbWhere.Append(UTIL.GetWhere(row, "@CAM_END", "ISNULL(A.PROC_STAT,'0') = 4"));                        
                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "W.DATA_FLAG = @DATA_FLAG"));
                        sbWhere.Append(UTIL.GetWhere(row, "@WO_TYPE", "SP.WO_TYPE = @WO_TYPE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_LIKE", "TP.PROD_CODE LIKE '%' + @PROD_LIKE + '%' OR TP.PROD_NAME LIKE '%' + @PROD_LIKE + '%'"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_LIKE", "(W.PART_CODE LIKE '%' + @PART_LIKE + '%' OR S.PART_NAME LIKE '%' + @PART_LIKE + '%')"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_REG_DATE, @E_REG_DATE", "(CONVERT(nvarchar(8),TP.REG_DATE,112) BETWEEN @S_REG_DATE AND @E_REG_DATE)"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_ORD_DATE, @E_ORD_DATE", "(TP.ORD_DATE BETWEEN @S_ORD_DATE AND @E_ORD_DATE)"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_DUE_DATE, @E_DUE_DATE", "(TP.DUE_DATE BETWEEN @S_DUE_DATE AND @E_DUE_DATE)"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_DELIVERY_DATE, @E_DELIVERY_DATE", "(TP.DELIVERY_DATE BETWEEN @S_DELIVERY_DATE AND @E_DELIVERY_DATE)"));

                        sbWhere.Append(UTIL.GetWhere(row, "@S_PLN_DATE, @E_PLN_DATE", "(SUBSTRING(W.PLN_START_TIME,1,8) BETWEEN @S_PLN_DATE AND @E_PLN_DATE)"));

                        sbWhere.Append(UTIL.GetWhere(row, "@S_ACT_DATE, @E_ACT_DATE", "ISNULL(A.PROC_STAT,'0') <> 4 OR (CONVERT(nvarchar(8),A.ACT_END_TIME,112) BETWEEN @S_ACT_DATE AND @E_ACT_DATE)"));

                        sbWhere.Append(UTIL.GetWhere(row, "@CHAIN_WO_LIKE", "W.CHAIN_WO_NO LIKE '%' + @CHAIN_WO_LIKE + '%'"));

                        sbWhere.Append(" AND TP.PROD_STATE <> '5' AND W.WO_FLAG <> '0' AND TP.DATA_FLAG = 0 AND PT.DATA_FLAG = 0 ");
                        sbWhere.Append(" ORDER BY W.PART_ID, W.PROC_ID");

                        DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString() + sbWhere.ToString(), row).Copy();

                        sourceTable.TableName = "RSLTDT";
                        dsResult.Merge(sourceTable, false, MissingSchemaAction.Add);
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
        /// 밀링 작업지시 조회
        /// SJK 2021-05-18
        /// </summary>
        /// <param name="dtParam"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataTable TSHP_WORKORDER_QUERY14(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {

                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT W.PLT_CODE");
                    sbQuery.Append(" ,BW.WO_FLAG");
                    sbQuery.Append(" ,W.PROC_ID");
                    sbQuery.Append(" ,W.WP_NO");
                    sbQuery.Append(" ,W.CHAIN_WO_NO");
                    sbQuery.Append(" ,W.WO_NO");
                    sbQuery.Append(" ,W.PT_ID");
                    sbQuery.Append(" ,S.PART_PRODTYPE");
                    sbQuery.Append(" ,TP.ITEM_CODE");
                    sbQuery.Append(" ,W.PROD_CODE");
                    sbQuery.Append(" ,TP.PROD_NAME");
                    sbQuery.Append(" ,W.PART_CODE");
                    sbQuery.Append(" ,S.PART_NAME");
                    sbQuery.Append(" ,S.STD_PT_NUM");
                    sbQuery.Append(" ,ISNULL(SP.IS_MAT, 0) IS_MAT");
                    sbQuery.Append(" ,ISNULL(SP.IS_OS, 0) IS_OS");
                    sbQuery.Append(" ,S.MAT_SPEC");
                    sbQuery.Append(" ,S.MAT_SPEC1");
                    sbQuery.Append(" ,S.BAL_SPEC");
                    sbQuery.Append(" ,S.BAL_WEIGHT");
                    sbQuery.Append(" ,S.DRAW_NO");
                    sbQuery.Append(" ,W.PROC_CODE");
                    sbQuery.Append(" ,W.PROC_SEQ");
                    sbQuery.Append(" ,SP.PROC_NAME");
                    sbQuery.Append(" ,W.MC_CODE");
                    sbQuery.Append(" ,W.MC_GROUP");
                    sbQuery.Append(" ,M.MC_NAME");
                    sbQuery.Append(" ,W.EMP_CODE");
                    sbQuery.Append(" ,E.EMP_NAME");
                    sbQuery.Append(" ,W.PART_QTY AS PLN_QTY");
                    sbQuery.Append(" ,W.PART_QTY");
                    sbQuery.Append(" ,W.WO_FLAG");
                    sbQuery.Append(" ,W.ACT_START_TIME");
                    sbQuery.Append(" ,W.ACT_END_TIME");
                    sbQuery.Append(" ,W.CAUTION");
                    sbQuery.Append(" ,W.JOB_PRIORITY");
                    sbQuery.Append(" ,W.WORK_CODE");
                    sbQuery.Append(" ,ISNULL(W.IS_OS,0) AS IS_OS");
                    sbQuery.Append(" ,SP.IS_MAT");
                    //sbQuery.Append(" ,W.CAM_EMP");
                    //sbQuery.Append(" ,W.CAM_EMP_DATE");
                    sbQuery.Append(" ,W.CAM_DATE");
                    sbQuery.Append(" ,W.WORK_SCOMMENT");
                    sbQuery.Append(" ,TP.PROD_VERSION");
                    sbQuery.Append(" ,TP.PROC_FLAG");
                    sbQuery.Append(" ,TP.PROD_FLAG");
                    sbQuery.Append(" ,TP.INS_YN");
                    sbQuery.Append(" ,TP.SOCKET_YN");
                    sbQuery.Append(" ,TP.PROD_TYPE");
                    sbQuery.Append(" ,TP.PROD_CATEGORY");
                    sbQuery.Append(" ,TP.BUSINESS_EMP");
                    sbQuery.Append(" ,TP.CUSTOMER_EMP");
                    sbQuery.Append(" ,TP.CUSTDESIGN_EMP");
                    sbQuery.Append(" ,TP.ACTUATOR_YN");
                    sbQuery.Append(" ,TP.CVND_CODE");
                    sbQuery.Append(" ,CVND.VEN_NAME AS CVND_NAME");
                    sbQuery.Append(" ,TP.TVND_CODE");
                    sbQuery.Append(" ,TVND.BVEN_NAME AS TVND_NAME");
                    sbQuery.Append(" ,TP.PROBE_PIN");
                    sbQuery.Append(" ,TP.CURR_UNIT");
                    sbQuery.Append(" ,TP.ORD_DATE");
                    sbQuery.Append(" ,TP.INDUE_DATE");
                    sbQuery.Append(" ,TP.DUE_DATE");
                    sbQuery.Append(" ,TP.CHG_DUE_DATE");
                    sbQuery.Append(" ,TP.END_DATE");
                    sbQuery.Append(" ,TP.DELIVERY_DATE");
                    sbQuery.Append(" ,TP.PROD_QTY");
                    sbQuery.Append(" ,TP.LOAD_FLAG");
                    sbQuery.Append(" ,TP.LOCK_FLAG");
                    sbQuery.Append(" ,TP.LOCK_EMP");
                    sbQuery.Append(" ,TP.SHIP_FLAG");
                    sbQuery.Append(" ,TP.PROD_STATE");
                    sbQuery.Append(" ,TP.INOUT_FLAG");
                    sbQuery.Append(" ,TP.ORD_VAT");
                    sbQuery.Append(" ,TP.PROD_UC");
                    sbQuery.Append(" ,TP.PROD_COST");
                    sbQuery.Append(" ,TP.PROD_VAT");
                    sbQuery.Append(" ,TP.PROD_AMT");
                    sbQuery.Append(" ,TP.PROD_KIND");
                    sbQuery.Append(" ,CA.X_VALUE");
                    sbQuery.Append(" ,CA.Y_VALUE");
                    sbQuery.Append(" ,CA.T_VALUE");
                    sbQuery.Append(" ,CA.P_CNT");
                    sbQuery.Append(" ,CA.MIL_REQ_DATE"); 
                    sbQuery.Append(" ,CA.SCOMMENT");
                    sbQuery.Append(" ,CA.MAT_CODE AS CAM_MAT_CODE ");
                    sbQuery.Append(" ,CA.MAT_QLTY");
                    sbQuery.Append(" ,CAM.CAM_EMP");
                    sbQuery.Append(" ,CAM.CAM_EMP_NAME");
                    sbQuery.Append(" ,CP.PART_NAME AS CAM_MAT_NAME ");
                    sbQuery.Append(" ,ISNULL(MA.PROC_STAT,'1') AS MILL_STATE ");
                    sbQuery.Append(" ,MA.EMP_CODE AS MILL_EMP");
                    sbQuery.Append(" ,ISNULL(MA.ACT_QTY,0) AS ACT_QTY ");
                    sbQuery.Append(" ,MA.LOT_ID");
                    sbQuery.Append(" ,ISNULL(MA.MAT_CODE,CA.MAT_CODE)  AS MAT_CODE ");
                    sbQuery.Append(" ,MP.PART_NAME  AS MAT_NAME");
                    sbQuery.Append(" ,MA.OUT_QTY");
                    sbQuery.Append(" ,MA.MAT_OUT");
                    sbQuery.Append(" ,MA.OUT_MAT_CODE");
                    sbQuery.Append(" ,MA.ACTUAL_ID");
                    sbQuery.Append(" ,SP.WO_TYPE");
                    sbQuery.Append(" ,PT.SCOMMENT AS PT_SCOMMENT");
                    sbQuery.Append(" ,W.RE_WO_NO");
                    //sbQuery.Append(" ,CASE WHEN W.RE_WO_NO IS NULL THEN '0' ELSE '1' END IS_REWORK  ");

                    sbQuery.Append(" ,CASE WHEN W.RE_WO_NO IS NULL THEN '0'");
                    sbQuery.Append("   ELSE CASE WHEN W.IS_DES_CHANGE = 1 AND ISNULL(W.IS_REMCT, 0) = 0 AND ISNULL(W.IS_MODIFY, 0) = 0 THEN '2' ");
                    sbQuery.Append("             WHEN W.IS_DES_CHANGE = 1 AND ISNULL(W.IS_REMCT, 0) = 0 AND ISNULL(W.IS_MODIFY, 0) = 1 THEN '3'");
                    sbQuery.Append("             WHEN W.IS_DES_CHANGE = 1 AND ISNULL(W.IS_REMCT, 0) = 1 AND ISNULL(W.IS_MODIFY, 0) = 0 THEN '4'");
                    sbQuery.Append("             WHEN N.NG_TYPE = 'P' THEN '5' ELSE '6' END END AS IS_REWORK");

                    sbQuery.Append(" ,TP.PROD_PRIORITY");
                    sbQuery.Append(" FROM TSHP_WORKORDER W");
                    sbQuery.Append(" LEFT JOIN TORD_PRODUCT TP ON TP.PLT_CODE = W.PLT_CODE AND TP.PROD_CODE = W.PROD_CODE ");
                    sbQuery.Append(" LEFT JOIN LSE_STD_PART S ON W.PLT_CODE = S.PLT_CODE AND  W.PART_CODE = S.PART_CODE ");
                    sbQuery.Append(" LEFT JOIN LSE_STD_PROC SP ON W.PLT_CODE = SP.PLT_CODE AND W.PROC_CODE = SP.PROC_CODE  ");
                    sbQuery.Append(" LEFT JOIN LSE_MACHINE M ON W.PLT_CODE = M.PLT_CODE AND W.MC_CODE = M.MC_CODE  ");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE E ON W.PLT_CODE = E.PLT_CODE AND W.EMP_CODE = E.EMP_CODE ");
                    sbQuery.Append(" LEFT JOIN TSHP_WORKORDER BW ON W.PLT_CODE = BW.PLT_CODE AND W.PT_ID = BW.PT_ID AND (W.PROC_ID-1) = BW.PROC_ID AND ISNULL(W.RE_WO_NO,'1') = ISNULL(BW.RE_WO_NO,'1') AND BW.DATA_FLAG = '0'");
                    sbQuery.Append(" LEFT JOIN TSHP_ACTUAL_CAM CA ON BW.PLT_CODE = CA.PLT_CODE AND BW.WO_NO = CA.WO_NO ");
                    sbQuery.Append(" LEFT JOIN LSE_STD_PART CP ON CA.PLT_CODE = CP.PLT_CODE AND  CA.MAT_CODE = CP.PART_CODE ");
                    sbQuery.Append(" LEFT JOIN TSHP_ACTUAL_MILL MA ON W.PLT_CODE = MA.PLT_CODE AND W.WO_NO = MA.WO_NO ");
                    sbQuery.Append(" LEFT JOIN LSE_STD_PART MP ON ISNULL(MA.PLT_CODE,CA.PLT_CODE) = MP.PLT_CODE AND  ISNULL(MA.MAT_CODE,CA.MAT_CODE) = MP.PART_CODE ");
                    sbQuery.Append(" LEFT JOIN TSTD_VENDOR CVND");
                    sbQuery.Append(" ON TP.PLT_CODE = CVND.PLT_CODE");
                    sbQuery.Append(" AND TP.CVND_CODE = CVND.VEN_CODE");
                    sbQuery.Append(" LEFT JOIN TSTD_BILL_VENDOR TVND");
                    sbQuery.Append(" ON TP.PLT_CODE = TVND.PLT_CODE");
                    sbQuery.Append(" AND TP.TVND_CODE = TVND.BVEN_CODE");
                    sbQuery.Append(" LEFT JOIN TMAT_PARTLIST PT");
                    sbQuery.Append(" ON W.PLT_CODE = PT.PLT_CODE");
                    sbQuery.Append(" AND W.PT_ID = PT.PT_ID");

                    sbQuery.Append(" LEFT JOIN");
                    sbQuery.Append(" (");
                    sbQuery.Append(" SELECT");
                    sbQuery.Append(" PLT_CODE");
                    sbQuery.Append(" , WO_FLAG");
                    sbQuery.Append(" , PROD_CODE");
                    sbQuery.Append(" , PT_ID");
                    sbQuery.Append(" , RE_WO_NO");
                    sbQuery.Append(" FROM TSHP_WORKORDER");
                    sbQuery.Append(" WHERE PROC_CODE = 'P-06'");
                    sbQuery.Append(" AND DATA_FLAG = '0'");
                    sbQuery.Append(" ) IWC");
                    sbQuery.Append(" ON W.PLT_CODE = IWC.PLT_CODE");
                    sbQuery.Append(" AND W.PROD_CODE = IWC.PROD_CODE");
                    sbQuery.Append(" AND W.PT_ID = IWC.PT_ID");
                    sbQuery.Append(" AND ISNULL(W.RE_WO_NO,'1') = ISNULL(IWC.RE_WO_NO,'1')");

                    sbQuery.Append(" LEFT JOIN");
                    sbQuery.Append(" (");
                    sbQuery.Append(" SELECT CW.PLT_CODE, CW.PROD_CODE, CW.PART_CODE ,CW.PT_ID, CW.CAM_EMP, E.EMP_NAME AS CAM_EMP_NAME, CW.RE_WO_NO FROM TSHP_WORKORDER CW");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE E ON CW.PLT_CODE = E.PLT_CODE AND CW.CAM_EMP = E.EMP_CODE");
                    sbQuery.Append(" WHERE CW.DATA_FLAG = '0' AND CW.PROC_CODE = 'P-02' AND CW.CAM_EMP IS NOT NULL");
                    sbQuery.Append(" GROUP BY CW.PLT_CODE, CW.PROD_CODE, CW.PART_CODE ,CW.PT_ID, CW.CAM_EMP, E.EMP_NAME, CW.RE_WO_NO");
                    sbQuery.Append(" ) CAM");
                    sbQuery.Append(" ON W.PLT_CODE = CAM.PLT_CODE");
                    sbQuery.Append(" AND W.PT_ID = CAM.PT_ID");
                    sbQuery.Append(" AND ISNULL(W.RE_WO_NO,'1') = ISNULL(CAM.RE_WO_NO,'1')");

                    sbQuery.Append(" LEFT JOIN TSHP_NG N");
                    sbQuery.Append(" ON W.PLT_CODE = N.PLT_CODE");
                    sbQuery.Append(" AND W.RE_WO_NO = N.RE_WO_NO");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder();

                        sbWhere.Append(" WHERE W.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                        sbWhere.Append(UTIL.GetWhere(row, "@WO_NO", "W.WO_NO = @WO_NO"));
                        sbWhere.Append(UTIL.GetWhere(row, "@NOT_WO_NO", "W.WO_NO <> @NOT_WO_NO"));
                        sbWhere.Append(UTIL.GetWhere(row, "@CHAIN_WO_NO", "W.CHAIN_WO_NO = @CHAIN_WO_NO"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_CODE", "W.PROD_CODE = @PROD_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_CODE", "W.PART_CODE = @PART_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@MC_CODE", "W.MC_CODE = @MC_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PROC_CODE", "W.PROC_CODE = @PROC_CODE"));
                        //sbWhere.Append(UTIL.GetWhere(row, "@EMP_CODE", "W.EMP_CODE = @EMP_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@CAM_EMP", "W.CAM_EMP = @CAM_EMP"));
                        sbWhere.Append(UTIL.GetWhere(row, "@MILL_EMP", "MA.MILL_EMP = @MILL_EMP"));
                        sbWhere.Append(UTIL.GetWhere(row, "@IS_END", "ISNULL(MA.PROC_STAT,'0') <> 4"));
                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "W.DATA_FLAG = @DATA_FLAG"));
                        sbWhere.Append(UTIL.GetWhere(row, "@WO_TYPE", "SP.WO_TYPE = @WO_TYPE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_LIKE", "TP.PROD_CODE LIKE '%' + @PROD_LIKE + '%' OR TP.PROD_NAME LIKE '%' + @PROD_LIKE + '%'"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_REG_DATE, @E_REG_DATE", "(CONVERT(nvarchar(8),TP.REG_DATE,112) BETWEEN @S_REG_DATE AND @E_REG_DATE)"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_ORD_DATE, @E_ORD_DATE", "(TP.ORD_DATE BETWEEN @S_ORD_DATE AND @E_ORD_DATE)"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_DUE_DATE, @E_DUE_DATE", "(TP.DUE_DATE BETWEEN @S_DUE_DATE AND @E_DUE_DATE)"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_DELIVERY_DATE, @E_DELIVERY_DATE", "(TP.DELIVERY_DATE BETWEEN @S_DELIVERY_DATE AND @E_DELIVERY_DATE)"));
                        sbWhere.Append(UTIL.GetWhere(row, "@CVND_LIKE", "TP.CVND_CODE LIKE '%' + @CVND_LIKE + '%' OR CVND.VEN_NAME LIKE '%' + @CVND_LIKE + '%'"));
                        sbWhere.Append(UTIL.GetWhere(row, "@IS_MID_INS", "ISNULL(IWC.WO_FLAG, '0') <> '4'"));
                        sbWhere.Append(" AND (BW.WO_FLAG = '4' OR BW.WO_NO IS NULL ) ");
                        sbWhere.Append(" AND TP.PROD_STATE <> '5' AND W.WO_FLAG <> '0' AND TP.DATA_FLAG = 0 AND PT.DATA_FLAG = 0 ");                        
                        sbWhere.Append(" ORDER BY W.PART_ID, W.PROC_ID");

                        DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString() + sbWhere.ToString(), row).Copy();

                        sourceTable.TableName = "RSLTDT";
                        dsResult.Merge(sourceTable, false, MissingSchemaAction.Add);
                    }
                }

                return UTIL.GetDsToDt(dsResult);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        ///// <summary>
        ///// 품질 검사결과 관리 조회
        ///// SJK 2021-05-14
        ///// </summary>
        ///// <param name="dtParam"></param>
        ///// <param name="bizExecute"></param>
        ///// <returns></returns>
        //public static DataTable TSHP_WORKORDER_QUERY15(DataTable dtParam, BizExecute.BizExecute bizExecute)
        //{
        //    try
        //    {
        //        DataSet dsResult = new DataSet();

        //        if (dtParam.Rows.Count > 0)
        //        {
        //            StringBuilder sbQuery = new StringBuilder();

        //            sbQuery.Append(" SELECT W.PLT_CODE");
        //            sbQuery.Append(" ,W.WP_NO");
        //            sbQuery.Append(" ,W.WO_NO");
        //            sbQuery.Append(" ,S.PART_PRODTYPE");
        //            sbQuery.Append(" ,TP.ITEM_CODE");
        //            sbQuery.Append(" ,W.PROD_CODE");
        //            sbQuery.Append(" ,TP.PROD_NAME");
        //            sbQuery.Append(" ,W.PART_CODE");
        //            sbQuery.Append(" ,S.PART_NAME");
        //            sbQuery.Append(" ,S.STD_PT_NUM ");
        //            sbQuery.Append(" ,ISNULL(SP.IS_MAT, 0) IS_MAT");
        //            //sbQuery.Append(" ,ISNULL(SP.IS_OS, 0) IS_OS");
        //            sbQuery.Append(" ,S.MAT_SPEC");
        //            sbQuery.Append(" ,S.MAT_SPEC1");
        //            sbQuery.Append(" ,S.BAL_SPEC");
        //            sbQuery.Append(" ,S.BAL_WEIGHT");
        //            sbQuery.Append(" ,S.DRAW_NO");
        //            sbQuery.Append(" ,W.PROC_CODE ");
        //            sbQuery.Append(" ,W.PROC_SEQ  ");
        //            sbQuery.Append(" ,SP.PROC_NAME ");
        //            sbQuery.Append(" ,W.MC_CODE ");
        //            sbQuery.Append(" ,M.MC_NAME ");
        //            sbQuery.Append(" ,W.EMP_CODE");
        //            sbQuery.Append(" ,E.EMP_NAME");
        //            sbQuery.Append(" ,W.PART_QTY AS PLN_QTY ");
        //            sbQuery.Append(" ,W.PART_QTY ");
        //            sbQuery.Append(" ,(SELECT ISNULL(SUM(OK_QTY),0) FROM TSHP_ACTUAL A WHERE W.PLT_CODE = A.PLT_CODE AND W.WO_NO = A.WO_NO ) AS ACT_QTY");
        //            sbQuery.Append(" ,(SELECT ISNULL(SUM(NG_QTY),0) FROM TSHP_ACTUAL A WHERE W.PLT_CODE = A.PLT_CODE AND W.WO_NO = A.WO_NO ) AS NG_QTY");
        //            sbQuery.Append(" ,W.WO_FLAG  ");
        //            //sbQuery.Append(" ,W.ACT_START_TIME  ");
        //            //sbQuery.Append(" ,W.ACT_END_TIME  ");
        //            sbQuery.Append(" ,W.CAUTION  ");
        //            sbQuery.Append(" ,W.JOB_PRIORITY  ");
        //            sbQuery.Append(" ,W.WORK_CODE  ");
        //            sbQuery.Append(" ,ISNULL(W.IS_OS,0) AS IS_OS  ");
        //            //sbQuery.Append(" ,SP.IS_MAT  ");   

        //            sbQuery.Append(" ,TP.PROD_VERSION");
        //            sbQuery.Append(" ,TP.PROC_FLAG");
        //            sbQuery.Append(" ,TP.PROD_FLAG");
        //            sbQuery.Append(" ,TP.INS_YN");
        //            sbQuery.Append(" ,TP.SOCKET_YN");
        //            sbQuery.Append(" ,TP.PROD_TYPE");
        //            sbQuery.Append(" ,TP.PROD_CATEGORY");
        //            sbQuery.Append(" ,TP.BUSINESS_EMP");
        //            sbQuery.Append(" ,TP.CUSTOMER_EMP");
        //            sbQuery.Append(" ,TP.CUSTDESIGN_EMP");
        //            sbQuery.Append(" ,TP.ACTUATOR_YN");
        //            sbQuery.Append(" ,TP.CVND_CODE");
        //            sbQuery.Append(" ,CVND.VEN_NAME AS CVND_NAME");
        //            sbQuery.Append(" ,TP.TVND_CODE");
        //            sbQuery.Append(" ,TVND.VEN_NAME AS TVND_NAME");
        //            sbQuery.Append(" ,TP.PROBE_PIN");
        //            sbQuery.Append(" ,TP.CURR_UNIT");
        //            sbQuery.Append(" ,TP.ORD_DATE");
        //            sbQuery.Append(" ,TP.INDUE_DATE");
        //            sbQuery.Append(" ,TP.DUE_DATE");
        //            sbQuery.Append(" ,TP.CHG_DUE_DATE");
        //            sbQuery.Append(" ,TP.END_DATE");
        //            sbQuery.Append(" ,TP.DELIVERY_DATE");
        //            sbQuery.Append(" ,TP.PROD_QTY");
        //            sbQuery.Append(" ,TP.LOAD_FLAG");
        //            sbQuery.Append(" ,TP.LOCK_FLAG");
        //            sbQuery.Append(" ,TP.LOCK_EMP");
        //            sbQuery.Append(" ,TP.SHIP_FLAG");
        //            sbQuery.Append(" ,TP.PROD_STATE");
        //            sbQuery.Append(" ,TP.INOUT_FLAG");
        //            sbQuery.Append(" ,TP.ORD_VAT");
        //            sbQuery.Append(" ,TP.PROD_UC");
        //            sbQuery.Append(" ,TP.PROD_COST");
        //            sbQuery.Append(" ,TP.PROD_VAT");
        //            sbQuery.Append(" ,TP.PROD_AMT");
        //            sbQuery.Append(" ,TP.PROD_KIND");

        //            sbQuery.Append(" ,W.CAM_EMP  ");//cam 담당자
        //            sbQuery.Append(" ,A.ACT_END_TIME AS CAM_END_DATE ");//cam 오나료일


        //            sbQuery.Append(" FROM TSHP_WORKORDER W ");
        //            sbQuery.Append(" LEFT JOIN TORD_PRODUCT TP ON TP.PLT_CODE = W.PLT_CODE AND TP.PROD_CODE = W.PROD_CODE ");
        //            sbQuery.Append("  JOIN LSE_STD_PART S ON W.PLT_CODE = S.PLT_CODE AND  W.PART_CODE = S.PART_CODE  ");
        //            sbQuery.Append("  JOIN LSE_STD_PROC SP ON W.PLT_CODE = SP.PLT_CODE AND W.PROC_CODE = SP.PROC_CODE ");
        //            sbQuery.Append(" LEFT JOIN LSE_MACHINE M ON W.PLT_CODE = M.PLT_CODE AND W.MC_CODE = M.MC_CODE ");
        //            sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE E ON W.PLT_CODE = E.PLT_CODE AND W.EMP_CODE = E.EMP_CODE ");
        //            sbQuery.Append(" LEFT JOIN TSHP_ACTUAL_CAM A ON W.PLT_CODE = A.PLT_CODE AND W.WO_NO = A.WO_NO ");
        //            sbQuery.Append(" LEFT JOIN TSTD_VENDOR CVND");
        //            sbQuery.Append(" ON TP.PLT_CODE = CVND.PLT_CODE");
        //            sbQuery.Append(" AND TP.CVND_CODE = CVND.VEN_CODE");
        //            sbQuery.Append(" LEFT JOIN TSTD_VENDOR TVND");
        //            sbQuery.Append(" ON TP.PLT_CODE = TVND.PLT_CODE");
        //            sbQuery.Append(" AND TP.TVND_CODE = TVND.VEN_CODE");

        //            foreach (DataRow row in dtParam.Rows)
        //            {
        //                StringBuilder sbWhere = new StringBuilder();

        //                sbWhere.Append(" WHERE W.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
        //                sbWhere.Append(UTIL.GetWhere(row, "@WO_NO", "W.WO_NO = @WO_NO"));
        //                sbWhere.Append(UTIL.GetWhere(row, "@PROD_CODE", "W.PROD_CODE = @PROD_CODE"));
        //                sbWhere.Append(UTIL.GetWhere(row, "@PART_CODE", "W.PART_CODE = @PART_CODE"));
        //                sbWhere.Append(UTIL.GetWhere(row, "@MC_CODE", "W.MC_CODE = @MC_CODE"));
        //                sbWhere.Append(UTIL.GetWhere(row, "@PROC_CODE", "W.PROC_CODE = @PROC_CODE"));
        //                //sbWhere.Append(UTIL.GetWhere(row, "@EMP_CODE", "W.EMP_CODE = @EMP_CODE"));
        //                sbWhere.Append(UTIL.GetWhere(row, "@CAM_EMP", "W.CAM_EMP = @CAM_EMP"));
        //                sbWhere.Append(UTIL.GetWhere(row, "@IS_END", "ISNULL(A.PROC_STAT,'0') <> 4"));
        //                sbWhere.Append(UTIL.GetWhere(row, "@CAM_END", "ISNULL(A.PROC_STAT,'0') = 4"));
        //                sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "W.DATA_FLAG = @DATA_FLAG"));
        //                sbWhere.Append(UTIL.GetWhere(row, "@WO_TYPE", "SP.WO_TYPE = @WO_TYPE"));
        //                sbWhere.Append(UTIL.GetWhere(row, "@PROD_LIKE", "TP.PROD_CODE LIKE '%' + @PROD_LIKE + '%' OR TP.PROD_NAME LIKE '%' + @PROD_LIKE + '%'"));
        //                sbWhere.Append(UTIL.GetWhere(row, "@S_REG_DATE, @E_REG_DATE", "(CONVERT(nvarchar(8),P.REG_DATE,112) BETWEEN @S_REG_DATE AND @E_REG_DATE)"));
        //                sbWhere.Append(UTIL.GetWhere(row, "@S_ORD_DATE, @E_ORD_DATE", "(P.ORD_DATE BETWEEN @S_ORD_DATE AND @E_ORD_DATE)"));
        //                sbWhere.Append(UTIL.GetWhere(row, "@S_DUE_DATE, @E_DUE_DATE", "(P.DUE_DATE BETWEEN @S_DUE_DATE AND @E_DUE_DATE)"));
        //                sbWhere.Append(UTIL.GetWhere(row, "@S_DELIVERY_DATE, @E_DELIVERY_DATE", "(P.DELIVERY_DATE BETWEEN @S_DELIVERY_DATE AND @E_DELIVERY_DATE)"));
        //                sbWhere.Append(" AND TP.PROD_STATE <> '5' ");
        //                sbWhere.Append(" ORDER BY W.PART_ID, W.PROC_ID");

        //                DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString() + sbWhere.ToString(), row).Copy();

        //                sourceTable.TableName = "RSLTDT";
        //                dsResult.Merge(sourceTable, false, MissingSchemaAction.Add);
        //            }
        //        }

        //        return UTIL.GetDsToDt(dsResult);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
        //    }
        //}


        //작업지시 공정정보
        public static DataTable TSHP_WORKORDER_QUERY16(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT W.PLT_CODE");
                    sbQuery.Append(" ,W.WP_NO");
                    sbQuery.Append(" ,W.WO_NO");
                    sbQuery.Append(" ,W.PART_CODE");
                    sbQuery.Append(" ,W.PROC_CODE ");
                    sbQuery.Append(" ,W.PART_QTY ");
                    sbQuery.Append(" ,ISNULL(W.PROC_SEQ,0) AS PROC_SEQ  ");
                    sbQuery.Append(" ,W.PLN_START_TIME  ");
                    sbQuery.Append(" ,W.PLN_END_TIME  ");
                    sbQuery.Append(" ,W.PLN_STD_TIME  ");
                    sbQuery.Append(" ,W.IS_OS ");
                    sbQuery.Append(" ,W.WO_FLAG  ");
                    sbQuery.Append(" FROM TSHP_WORKORDER W");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder();

                        sbWhere.Append(" WHERE W.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@WP_NO", "W.WP_NO = @WP_NO"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_CODE", "W.PROD_CODE = @PROD_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_CODE", "W.PART_CODE = @PART_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PROC_CODE", "W.PROC_CODE = @PROC_CODE"));
                        sbWhere.Append(" AND W.DATA_FLAG = 0");

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

        //public static DataTable TSHP_WORKORDER_QUERY16_1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        //{
        //    try
        //    {
        //        DataSet dsResult = new DataSet();

        //        if (dtParam.Rows.Count > 0)
        //        {
        //            StringBuilder sbQuery = new StringBuilder();

        //            sbQuery.Append(" SELECT W.PLT_CODE");
        //            sbQuery.Append(" ,W.WP_NO");
        //            sbQuery.Append(" ,W.WO_NO");
        //            sbQuery.Append(" ,W.PART_CODE");
        //            sbQuery.Append(" ,W.PROC_CODE ");
        //            sbQuery.Append(" ,W.PART_QTY ");
        //            sbQuery.Append(" ,ISNULL(W.PROC_SEQ,0) AS PROC_SEQ  ");
        //            sbQuery.Append(" ,W.PLN_START_TIME  ");
        //            sbQuery.Append(" ,W.PLN_END_TIME  ");
        //            sbQuery.Append(" ,W.PLN_STD_TIME  ");
        //            sbQuery.Append(" ,W.IS_OS ");
        //            sbQuery.Append(" ,W.WO_FLAG  ");
        //            sbQuery.Append(" FROM TSHP_WORKORDER W");

        //            foreach (DataRow row in dtParam.Rows)
        //            {
        //                StringBuilder sbWhere = new StringBuilder();

        //                sbWhere.Append(" WHERE W.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

        //                sbWhere.Append(UTIL.GetWhere(row, "@WP_NO", "W.WP_NO = @WP_NO"));
        //                sbWhere.Append(UTIL.GetWhere(row, "@PROD_CODE", "W.PROD_CODE = @PROD_CODE"));
        //                sbWhere.Append(UTIL.GetWhere(row, "@PART_CODE", "W.PART_CODE = @PART_CODE"));
        //                sbWhere.Append(" AND W.DATA_FLAG = 0");

        //                DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString() + sbWhere.ToString(), row).Copy();

        //                sourceTable.TableName = "RSLTDT";
        //                dsResult.Merge(sourceTable);
        //            }
        //        }

        //        return UTIL.GetDsToDt(dsResult);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
        //    }
        //}

        public static DataTable TSHP_WORKORDER_QUERY17(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT ");
                    sbQuery.Append(" TP.PROD_CODE, ");
                    sbQuery.Append(" TP.PART_CODE, ");
                    sbQuery.Append(" TP.PROD_NAME, ");
                    sbQuery.Append(" TW.PROC_CODE, ");
                    sbQuery.Append(" TW.MC_CODE, ");
                    sbQuery.Append(" LM.MC_NAME, ");
                    sbQuery.Append(" SP.PROC_NAME, ");
                    sbQuery.Append(" SP.PROC_COLOR, ");
                    sbQuery.Append(" LSP.PART_NAME, ");
                    sbQuery.Append("  ");
                    sbQuery.Append(" TW.PLN_START_TIME, ");
                    sbQuery.Append(" TW.PLN_END_TIME, ");
                    sbQuery.Append(" TW.ACT_START_TIME, ");
                    sbQuery.Append(" TW.ACT_END_TIME, ");
                    sbQuery.Append(" TW.WO_FLAG ");
                    sbQuery.Append("  ");
                    sbQuery.Append(" FROM TORD_PRODUCT TP ");
                    sbQuery.Append(" JOIN TSHP_WORKORDER TW ");
                    sbQuery.Append(" ON TP.PLT_CODE = TW.PLT_CODE ");
                    sbQuery.Append(" AND TP.PROD_CODE = TW.PROD_CODE ");
                    sbQuery.Append(" AND TP.PART_CODE = TW.PART_CODE ");
                    sbQuery.Append(" AND TW.DATA_FLAG = 0 ");

                    sbQuery.Append(" JOIN LSE_STD_PROC SP ");
                    sbQuery.Append(" ON TW.PLT_CODE = SP.PLT_CODE ");
                    sbQuery.Append(" AND TW.PROC_CODE = SP.PROC_CODE ");
                    sbQuery.Append(" JOIN LSE_STD_PART LSP ");
                    sbQuery.Append(" ON TW.PLT_CODE = LSP.PLT_CODE ");
                    sbQuery.Append(" AND TW.PART_CODE = LSP.PART_CODE ");
                    sbQuery.Append(" LEFT JOIN LSE_MACHINE LM ");
                    sbQuery.Append(" ON TW.PLT_CODE = LM.PLT_CODE ");
                    sbQuery.Append(" AND TW.MC_CODE = LM.MC_CODE ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder();

                        sbWhere.Append(" WHERE TP.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        //sbWhere.Append(UTIL.GetWhere(row, "@PROD_CODE", "TP.PROD_CODE = @PROD_CODE"));
                        //sbWhere.Append(UTIL.GetWhere(row, "@PART_CODE", "TP.PART_CODE = @PART_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_CODE", "TP.PROD_CODE LIKE '%' + @PROD_CODE + '%'"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_CODE", "TP.PART_CODE LIKE '%' + @PART_CODE + '%'"));

                        sbWhere.Append(" AND TP.DATA_FLAG = 0");
                        sbWhere.Append(" AND TP.LOAD_FLAG <> 1 ");
                        sbWhere.Append(" AND NOT (TW.PLN_START_TIME IS NULL ");
                        sbWhere.Append(" AND TW.PLN_END_TIME IS NULL ");
                        sbWhere.Append(" AND TW.ACT_START_TIME IS NULL ");
                        sbWhere.Append(" AND TW.ACT_END_TIME IS NULL) ");

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

        /// <summary>
        /// 검사 작업지시 조회
        /// SJK 2021-05-18
        /// </summary>
        /// <param name="dtParam"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataTable TSHP_WORKORDER_QUERY18(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT W.PLT_CODE");
                    sbQuery.Append(" ,W.WP_NO");
                    sbQuery.Append(" ,W.CHAIN_WO_NO");
                    sbQuery.Append(" ,W.WO_NO");
                    //sbQuery.Append(" ,CASE WHEN W.INS_DATE IS NOT NULL THEN '4' WHEN W.INS_QTY > '0' THEN '2' ELSE '1' END  AS INS_STATE");
                    sbQuery.Append(" ,CASE WHEN W.INS_DATE IS NOT NULL AND W.PART_QTY <= W.INS_QTY THEN '4'");
                    sbQuery.Append("       WHEN W.INS_QTY > '0' THEN '2'");
                    sbQuery.Append("       ELSE '1' END  AS INS_STATE");
                    sbQuery.Append(" ,S.PART_PRODTYPE");
                    sbQuery.Append(" ,TP.ITEM_CODE");
                    sbQuery.Append(" ,W.PROD_CODE");
                    sbQuery.Append(" ,TP.PROD_NAME");
                    sbQuery.Append(" ,W.PART_CODE");
                    sbQuery.Append(" ,S.PART_NAME");
                    sbQuery.Append(" ,S.STD_PT_NUM");
                    sbQuery.Append(" ,ISNULL(SP.IS_MAT, 0) IS_MAT");
                    sbQuery.Append(" ,S.MAT_SPEC");
                    sbQuery.Append(" ,S.MAT_SPEC1");
                    sbQuery.Append(" ,S.BAL_SPEC");
                    sbQuery.Append(" ,S.BAL_WEIGHT");
                    sbQuery.Append(" ,S.DRAW_NO");
                    sbQuery.Append(" ,W.PROC_CODE");
                    sbQuery.Append(" ,W.PROC_SEQ");
                    sbQuery.Append(" ,SP.PROC_NAME");
                    sbQuery.Append(" ,W.MC_CODE");
                    sbQuery.Append(" ,M.MC_NAME");
                    sbQuery.Append(" ,W.MC_GROUP");
                    sbQuery.Append(" ,W.EMP_CODE");
                    sbQuery.Append(" ,E.EMP_NAME");
                    sbQuery.Append(" ,TP.PROD_QTY");
                    sbQuery.Append(" ,W.PART_QTY AS PLN_QTY");
                    sbQuery.Append(" ,W.PART_QTY");
                    sbQuery.Append(" ,CASE WHEN CASE WHEN BW.WO_NO IS NULL THEN W.PART_QTY ELSE ISNULL(BW.ACT_QTY,0) END < ISNULL(W.INS_QTY,0) THEN 0 ELSE CASE WHEN BW.WO_NO IS NULL THEN W.PART_QTY ELSE ISNULL(BW.ACT_QTY,0) END - ISNULL(W.INS_QTY,0) END AS INS_QTY");
                    sbQuery.Append(" ,ISNULL(W.INS_QTY,0) AS OLD_INS_QTY");//검사완료수량
                    sbQuery.Append(" ,CASE WHEN BW.WO_NO IS NULL THEN W.PART_QTY ELSE ISNULL(BW.ACT_QTY,0) END AS ACT_QTY");//이전공정 완료 수량
                    sbQuery.Append(" ,W.WO_FLAG");
                    sbQuery.Append(" ,W.CAUTION");
                    sbQuery.Append(" ,W.JOB_PRIORITY");
                    sbQuery.Append(" ,W.WORK_CODE");
                    //sbQuery.Append(" ,ISNULL(W.IS_OS,0) AS IS_OS");
                    sbQuery.Append(" ,CASE WHEN OW.PROD_CODE IS NULL THEN '0' ELSE '1' END AS IS_OS");
                    sbQuery.Append(" ,CASE WHEN OW.PROD_CODE IS NULL THEN BW.ACT_END_TIME ELSE OW.ACT_END_TIME END AS PREV_ACT_END_TIME");
                    sbQuery.Append(" ,OW.OVND_CODE");
                    sbQuery.Append(" ,OW.OVND_NAME");
                    sbQuery.Append(" ,OW.UNIT_COST");
                    sbQuery.Append(" ,OW.AMT");
                    sbQuery.Append(" ,OW.REG_EMP AS O_EMP_CODE");
                    sbQuery.Append(" ,OW.EMP_NAME AS O_EMP_NAME");
                    sbQuery.Append(" ,SP.IS_MAT");
                    sbQuery.Append(" ,CA.EMP_CODE AS CAM_EMP");
                    sbQuery.Append(" ,W.CAM_EMP_DATE");
                    sbQuery.Append(" ,W.CAM_DATE");
                    sbQuery.Append(" ,MA.MAT_CODE");
                    sbQuery.Append(" ,MS.PART_NAME AS MAT_NAME ");
                    sbQuery.Append(" ,TP.PROD_VERSION");
                    sbQuery.Append(" ,TP.PROD_KIND");
                    sbQuery.Append(" ,TP.PROC_FLAG");
                    sbQuery.Append(" ,TP.PROD_FLAG");
                    sbQuery.Append(" ,TP.INS_YN");
                    sbQuery.Append(" ,TP.SOCKET_YN");
                    sbQuery.Append(" ,TP.PROD_TYPE");
                    sbQuery.Append(" ,TP.PROD_CATEGORY");
                    sbQuery.Append(" ,TP.BUSINESS_EMP");
                    sbQuery.Append(" ,TP.CUSTOMER_EMP");
                    sbQuery.Append(" ,TP.CUSTDESIGN_EMP");
                    sbQuery.Append(" ,TP.ACTUATOR_YN");
                    sbQuery.Append(" ,TP.CVND_CODE");
                    sbQuery.Append(" ,CVND.VEN_NAME AS CVND_NAME");
                    sbQuery.Append(" ,TP.TVND_CODE");
                    sbQuery.Append(" ,TVND.BVEN_NAME AS TVND_NAME");
                    sbQuery.Append(" ,TP.PROBE_PIN");
                    sbQuery.Append(" ,TP.PIN_TYPE");
                    sbQuery.Append(" ,TP.CURR_UNIT");
                    sbQuery.Append(" ,TP.ORD_DATE");
                    sbQuery.Append(" ,TP.INDUE_DATE");
                    sbQuery.Append(" ,TP.DUE_DATE");
                    sbQuery.Append(" ,TP.CHG_DUE_DATE");
                    sbQuery.Append(" ,TP.END_DATE");
                    sbQuery.Append(" ,TP.DELIVERY_DATE");
                    sbQuery.Append(" ,TP.PROD_QTY");
                    sbQuery.Append(" ,TP.LOAD_FLAG");
                    sbQuery.Append(" ,TP.LOCK_FLAG");
                    sbQuery.Append(" ,TP.LOCK_EMP");
                    sbQuery.Append(" ,TP.SHIP_FLAG");
                    sbQuery.Append(" ,TP.PROD_STATE");
                    sbQuery.Append(" ,TP.INOUT_FLAG");
                    sbQuery.Append(" ,TP.ORD_VAT");
                    sbQuery.Append(" ,TP.PROD_UC");
                    sbQuery.Append(" ,CA.ACT_START_TIME");
                    sbQuery.Append(" ,CA.ACT_END_TIME");
                    sbQuery.Append(" ,CA.ACT_TIME");
                    sbQuery.Append(" ,CA.X_VALUE");
                    sbQuery.Append(" ,CA.Y_VALUE");
                    sbQuery.Append(" ,CA.T_VALUE");
                    sbQuery.Append(" ,CA.P_CNT");
                    sbQuery.Append(" ,CA.MIL_REQ_DATE"); 
                    sbQuery.Append(" ,CA.SCOMMENT");
                    sbQuery.Append(" ,CA.MAT_CODE AS CAM_MAT_CODE");
                    sbQuery.Append(" ,BW.ACT_QTY");
                    sbQuery.Append(" ,W.PT_ID");
                    sbQuery.Append(" ,PT.SCOMMENT AS PT_SCOMMENT");
                    sbQuery.Append(" ,TP.SCOMMENT AS ORD_SCOMMENT");
                    sbQuery.Append(" ,W.WORK_SCOMMENT");
                    //sbQuery.Append(" ,CASE WHEN W.RE_WO_NO IS NULL THEN '0' ELSE '1' END IS_REWORK  ");

                    sbQuery.Append(" ,CASE WHEN W.RE_WO_NO IS NULL THEN '0'");
                    sbQuery.Append("   ELSE CASE WHEN W.IS_DES_CHANGE = 1 AND ISNULL(W.IS_REMCT, 0) = 0 AND ISNULL(W.IS_MODIFY, 0) = 0 THEN '2' ");
                    sbQuery.Append("             WHEN W.IS_DES_CHANGE = 1 AND ISNULL(W.IS_REMCT, 0) = 0 AND ISNULL(W.IS_MODIFY, 0) = 1 THEN '3'");
                    sbQuery.Append("             WHEN W.IS_DES_CHANGE = 1 AND ISNULL(W.IS_REMCT, 0) = 1 AND ISNULL(W.IS_MODIFY, 0) = 0 THEN '4'");
                    sbQuery.Append("             WHEN N.NG_TYPE = 'P' THEN '5' ELSE '6' END END AS IS_REWORK");

                    sbQuery.Append(" ,W.ACT_START_TIME AS INS_ACT_START_TIME");
                    sbQuery.Append(" ,DBO.fn_Get_InsEmp(W.PLT_CODE, W.WO_NO) AS INS_EMP");
                    //sbQuery.Append(" ,CAM.X_VALUE");
                    //sbQuery.Append(" ,CAM.Y_VALUE");
                    //sbQuery.Append(" ,CAM.T_VALUE");
                    //sbQuery.Append(" ,CAM.P_CNT");
                    sbQuery.Append(" ,CASE WHEN F.LINK_KEY IS NULL THEN '0' ELSE '1' END AS IS_ATTACH");
                    sbQuery.Append(" ,SP.IS_SHIP");
                    sbQuery.Append(" ,TP.PROD_PRIORITY");
                    //sbQuery.Append(" ,ISNULL(W.INS_WORK, '10') AS INS_WORK");
                    sbQuery.Append(" ,W.INS_WORK");
                    sbQuery.Append(" ,W.INS_DATE");
                    sbQuery.Append(" ,AD.DRAW_EMP ");
                    sbQuery.Append(" ,S.MAT_COST ");

                    sbQuery.Append(" ,INS.SCOMMENT AS INS_SCOMMENT ");
                    sbQuery.Append(" ,ASSY.SCOMMENT AS ASSY_SCOMMENT ");

                    sbQuery.Append(" FROM TSHP_WORKORDER W");
                    sbQuery.Append(" LEFT JOIN TORD_PRODUCT TP ON TP.PLT_CODE = W.PLT_CODE AND TP.PROD_CODE = W.PROD_CODE");
                    sbQuery.Append(" LEFT JOIN LSE_STD_PART S ON W.PLT_CODE = S.PLT_CODE AND  W.PART_CODE = S.PART_CODE");
                    sbQuery.Append(" LEFT JOIN LSE_STD_PROC SP ON W.PLT_CODE = SP.PLT_CODE AND W.PROC_CODE = SP.PROC_CODE");
                    sbQuery.Append(" LEFT JOIN LSE_MACHINE M ON W.PLT_CODE = M.PLT_CODE AND W.MC_CODE = M.MC_CODE");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE E ON W.PLT_CODE = E.PLT_CODE AND W.EMP_CODE = E.EMP_CODE");
                    sbQuery.Append(" LEFT JOIN TSHP_ACTUAL_CAM CA ON W.PLT_CODE = CA.PLT_CODE AND W.PT_ID = CA.PT_ID AND ISNULL(W.RE_WO_NO, '1') = ISNULL(CA.RE_WO_NO, '1')");
                    sbQuery.Append(" LEFT JOIN TSHP_ACTUAL_MILL MA ON W.PLT_CODE = MA.PLT_CODE AND W.PT_ID = MA.PT_ID AND ISNULL(W.RE_WO_NO, '1') = ISNULL(MA.RE_WO_NO, '1')");
                    sbQuery.Append(" LEFT JOIN LSE_STD_PART MS ON MA.PLT_CODE = MS.PLT_CODE AND  MA.MAT_CODE = MS.PART_CODE");
                    //sbQuery.Append(" LEFT JOIN");
                    //sbQuery.Append(" (SELECT PLT_CODE, PT_ID, MIN(OK_QTY) AS OK_QTY FROM");
                    //sbQuery.Append(" (SELECT A.PLT_CODE,A.PT_ID,A.WO_FLAG,SUM(ISNULL(C.OK_QTY,0)) AS OK_QTY,SUM(ISNULL(C.NG_QTY,0)) AS NG_QTY FROM TSHP_WORKORDER A");
                    //sbQuery.Append(" LEFT JOIN LSE_STD_PROC B ON A.PLT_CODE = B.PLT_CODE AND A.PROC_CODE = B.PROC_CODE");
                    //sbQuery.Append(" LEFT JOIN TSHP_ACTUAL C ON  A.PLT_CODE = B.PLT_CODE AND A.WO_NO = C.WO_NO");
                    //sbQuery.Append(" WHERE B.WO_TYPE = 'PRC' GROUP BY A.PLT_CODE,A.PT_ID,A.WO_FLAG) A");
                    //sbQuery.Append(" GROUP BY PLT_CODE, PT_ID)");
                    //sbQuery.Append(" ACT");
                    //sbQuery.Append(" ON W.PLT_CODE = ACT.PLT_CODE AND W.PT_ID = ACT.PT_ID");
                    //이전 공정 작업지시의 실적
                    sbQuery.Append(" LEFT JOIN TSHP_WORKORDER BW ON W.PLT_CODE = BW.PLT_CODE AND W.PT_ID = BW.PT_ID AND (W.PROC_ID -1) = BW.PROC_ID AND ISNULL(W.RE_WO_NO, '1') = ISNULL(BW.RE_WO_NO, '1') AND BW.DATA_FLAG = '0'");
                    //sbQuery.Append(" LEFT JOIN (SELECT PLT_CODE, WO_NO,SUM(OK_QTY) AS OK_QTY, SUM(NG_QTY) AS NG_QTY FROM TSHP_ACTUAL GROUP BY PLT_CODE, WO_NO) ACT");
                    //sbQuery.Append(" ON BW.PLT_CODE = ACT.PLT_CODE AND BW.WO_NO = ACT.WO_NO");

                    sbQuery.Append(" LEFT JOIN (");
                    sbQuery.Append(" SELECT O.PLT_CODE, O.PROD_CODE, O.PART_CODE, O.PT_ID, O.RE_WO_NO, PRM.OVND_CODE, V.VEN_NAME AS OVND_NAME, PR.UNIT_COST, PR.AMT, PRM.REG_EMP, E.EMP_NAME, O.ACT_END_TIME FROM TSHP_WORKORDER O");
                    sbQuery.Append(" LEFT JOIN TOUT_PROCBALJU PR ON O.PLT_CODE = PR.PLT_CODE AND O.WO_NO = PR.WO_NO AND PR.BAL_STAT <> '14'");
                    sbQuery.Append(" LEFT JOIN TOUT_PROCBALJU_MASTER PRM ON PR.PLT_CODE = PRM.PLT_CODE AND PR.BALJU_NUM = PRM.BALJU_NUM");
                    sbQuery.Append(" LEFT JOIN TSTD_VENDOR V ON PRM.PLT_CODE = V.PLT_CODE AND PRM.OVND_CODE = V.VEN_CODE");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE E ON PRM.PLT_CODE = E.PLT_CODE AND PRM.REG_EMP = E.EMP_CODE");
                    sbQuery.Append(" WHERE O.PLT_CODE = '100' AND O.PROC_CODE = 'P14' AND O.DATA_FLAG = '0'");
                    sbQuery.Append(" ) OW");
                    sbQuery.Append(" ON OW.PLT_CODE = W.PLT_CODE");
                    sbQuery.Append(" AND OW.PROD_CODE = W.PROD_CODE");
                    sbQuery.Append(" AND OW.PT_ID = W.PT_ID");
                    sbQuery.Append(" AND ISNULL(OW.RE_WO_NO, '1') = ISNULL(W.RE_WO_NO, '1')");

                    sbQuery.Append(" LEFT JOIN TSTD_VENDOR CVND");
                    sbQuery.Append(" ON TP.PLT_CODE = CVND.PLT_CODE");
                    sbQuery.Append(" AND TP.CVND_CODE = CVND.VEN_CODE");
                    sbQuery.Append(" LEFT JOIN TSTD_BILL_VENDOR TVND");
                    sbQuery.Append(" ON TP.PLT_CODE = TVND.PLT_CODE");
                    sbQuery.Append(" AND TP.TVND_CODE = TVND.BVEN_CODE");
                    sbQuery.Append(" LEFT JOIN TMAT_PARTLIST PT ");
                    sbQuery.Append(" ON W.PLT_CODE = PT.PLT_CODE");
                    sbQuery.Append(" AND W.PT_ID = PT.PT_ID");

                    //sbQuery.Append(" LEFT JOIN ");
                    //sbQuery.Append(" ( ");
                    //sbQuery.Append(" SELECT");
                    //sbQuery.Append(" W.PLT_CODE");
                    //sbQuery.Append(" ,W.WO_NO");
                    //sbQuery.Append(" ,W.PROD_CODE");
                    //sbQuery.Append(" ,W.PART_CODE");
                    //sbQuery.Append(" ,AC.X_VALUE");
                    //sbQuery.Append(" ,AC.Y_VALUE");
                    //sbQuery.Append(" ,AC.T_VALUE");
                    //sbQuery.Append(" ,AC.P_CNT");
                    //sbQuery.Append(" ,AC.MAT_CODE");
                    //sbQuery.Append(" ,PT.PART_NAME");
                    //sbQuery.Append(" ,AC.MAT_QLTY");
                    //sbQuery.Append(" ,ISNULL(W.RE_WO_NO, '1') AS RE_WO_NO");
                    //sbQuery.Append(" FROM TSHP_WORKORDER W");
                    //sbQuery.Append(" LEFT JOIN TSHP_ACTUAL_CAM AC");
                    //sbQuery.Append(" ON W.PLT_CODE = AC.PLT_CODE");
                    //sbQuery.Append(" AND W.WO_NO = AC.WO_NO");
                    //sbQuery.Append(" AND ISNULL(W.RE_WO_NO, '1') = ISNULL(AC.RE_WO_NO, '1')");
                    //sbQuery.Append(" LEFT JOIN LSE_STD_PROC SP");
                    //sbQuery.Append(" ON W.PLT_CODE = SP.PLT_CODE");
                    //sbQuery.Append(" AND W.PROC_CODE = SP.PROC_CODE");
                    //sbQuery.Append(" LEFT JOIN LSE_STD_PART PT");
                    //sbQuery.Append(" ON AC.PLT_CODE = PT.PLT_CODE");
                    //sbQuery.Append(" AND AC.MAT_CODE = PT.PART_CODE");
                    //sbQuery.Append(" WHERE SP.WO_TYPE = 'CAM'");
                    //sbQuery.Append(" AND W.DATA_FLAG = '0'");
                    //sbQuery.Append(" AND W.WO_FLAG = '4'");
                    //sbQuery.Append(" ) CAM");
                    //sbQuery.Append(" ON CAM.PLT_CODE = W.PLT_CODE");
                    //sbQuery.Append(" AND CAM.PROD_CODE = W.PROD_CODE");
                    //sbQuery.Append(" AND CAM.PART_CODE = W.PART_CODE");
                    //sbQuery.Append(" AND ISNULL(CAM.RE_WO_NO, '1') = ISNULL(W.RE_WO_NO, '1')");

                    sbQuery.Append(" LEFT JOIN");
                    sbQuery.Append(" (");
                    sbQuery.Append(" SELECT PLT_CODE, LINK_KEY FROM TSYS_FILELIST_MASTER");
                    sbQuery.Append(" WHERE DATA_FLAG = '0'");
                    sbQuery.Append(" GROUP BY PLT_CODE, LINK_KEY");
                    sbQuery.Append(" ) F");
                    sbQuery.Append(" ON W.PLT_CODE = F.PLT_CODE");
                    sbQuery.Append(" AND 'INS' + W.WO_NO = F.LINK_KEY");

                    sbQuery.Append(" LEFT JOIN (");
                    sbQuery.Append(" SELECT PLT_CODE, PROD_CODE, MAX(DRAW_EMP) AS DRAW_EMP FROM TMAT_PARTLIST");
                    sbQuery.Append(" WHERE ISNULL(O_PT_ID,'') = '' AND DATA_FLAG = '0' AND LEFT(PART_CODE,1) = 'A'");
                    sbQuery.Append(" GROUP BY PLT_CODE, PROD_CODE");
                    sbQuery.Append(" ) AD");
                    sbQuery.Append(" ON TP.PLT_CODE = AD.PLT_CODE");
                    sbQuery.Append(" AND TP.PROD_CODE = AD.PROD_CODE");

                    sbQuery.Append(" LEFT JOIN TSHP_NG N");
                    sbQuery.Append(" ON W.PLT_CODE = N.PLT_CODE");
                    sbQuery.Append(" AND W.RE_WO_NO = N.RE_WO_NO");

                    sbQuery.Append(" LEFT JOIN TPOP_INS_SCOMMENT INS");
                    sbQuery.Append(" ON W.PLT_CODE = INS.PLT_CODE");
                    sbQuery.Append(" AND W.PROD_CODE = INS.PROD_CODE");
                    sbQuery.Append(" AND W.PT_ID = INS.PT_ID");
                    //sbQuery.Append(" AND W.WO_NO = INS.WO_NO");

                    sbQuery.Append(" LEFT JOIN TPOP_ASSY_SCOMMENT ASSY");
                    sbQuery.Append(" ON W.PLT_CODE = ASSY.PLT_CODE");
                    sbQuery.Append(" AND W.PROD_CODE = ASSY.PROD_CODE");
                    sbQuery.Append(" AND W.PT_ID = ASSY.PT_ID");
                    //sbQuery.Append(" AND W.WO_NO = ASSY.WO_NO");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder();

                        sbWhere.Append(" WHERE W.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                        sbWhere.Append(UTIL.GetWhere(row, "@WO_NO", "W.WO_NO = @WO_NO"));
                        sbWhere.Append(UTIL.GetWhere(row, "@NOT_WO_NO", "W.WO_NO <> @NOT_WO_NO"));
                        sbWhere.Append(UTIL.GetWhere(row, "@CHAIN_WO_NO", "W.CHAIN_WO_NO = @CHAIN_WO_NO"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_CODE", "W.PROD_CODE = @PROD_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_CODE", "W.PART_CODE = @PART_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@MC_CODE", "W.MC_CODE = @MC_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PROC_CODE", "W.PROC_CODE = @PROC_CODE"));
                        //sbWhere.Append(UTIL.GetWhere(row, "@EMP_CODE", "W.EMP_CODE = @EMP_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@CAM_EMP", "W.CAM_EMP = @CAM_EMP"));
                        //sbWhere.Append(UTIL.GetWhere(row, "@MILL_EMP", "MA.MILL_EMP = @MILL_EMP"));
                        sbWhere.Append(UTIL.GetWhere(row, "@IS_END", "W.INS_DATE IS NULL"));
                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "W.DATA_FLAG = @DATA_FLAG"));
                        sbWhere.Append(UTIL.GetWhere(row, "@WO_TYPE", "SP.WO_TYPE = @WO_TYPE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_LIKE", "W.PROD_CODE LIKE '%' + @PROD_LIKE + '%' OR TP.PROD_NAME LIKE '%' + @PROD_LIKE + '%'"));
                        sbWhere.Append(UTIL.GetWhere(row, "@CVND_LIKE", "TP.CVND_CODE LIKE '%' + @CVND_LIKE + '%' OR CVND.VEN_NAME LIKE '%' + @CVND_LIKE + '%'"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_REG_DATE, @E_REG_DATE", "(CONVERT(nvarchar(8),TP.REG_DATE,112) BETWEEN @S_REG_DATE AND @E_REG_DATE)"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_ORD_DATE, @E_ORD_DATE", "(TP.ORD_DATE BETWEEN @S_ORD_DATE AND @E_ORD_DATE)"));
                        //sbWhere.Append(UTIL.GetWhere(row, "@S_DUE_DATE, @E_DUE_DATE", "(TP.DUE_DATE BETWEEN @S_DUE_DATE AND @E_DUE_DATE)"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_DUE_DATE, @E_DUE_DATE", "ISNULL(TP.CHG_DUE_DATE, TP.DUE_DATE) BETWEEN @S_DUE_DATE AND @E_DUE_DATE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_DELIVERY_DATE, @E_DELIVERY_DATE", "(TP.DELIVERY_DATE BETWEEN @S_DELIVERY_DATE AND @E_DELIVERY_DATE)"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_INS_DATE, @E_INS_DATE", "(W.INS_DATE BETWEEN @S_INS_DATE AND @E_INS_DATE)"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PROC_CODE_IN", "W.PROC_CODE IN @PROC_CODE_IN", UTIL.SqlCondType.IN));

                        //sbWhere.Append(" AND ( ISNULL( ACT.OK_QTY,0) > ISNULL(W.INS_QTY,0) OR BW.WO_NO IS NULL )");
                        sbWhere.Append(" AND ( ISNULL( BW.ACT_QTY,0) > 0 OR BW.WO_NO IS NULL )");
                        sbWhere.Append(" AND TP.PROD_STATE <> '5' AND W.WO_FLAG <> '0' AND TP.DATA_FLAG = 0 AND PT.DATA_FLAG = 0 ");
                        sbWhere.Append(" ORDER BY W.PART_ID, W.PROC_ID");

                        DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString() + sbWhere.ToString(), row).Copy();

                        sourceTable.TableName = "RSLTDT";
                        dsResult.Merge(sourceTable, false, MissingSchemaAction.Add);
                    }
                }

                return UTIL.GetDsToDt(dsResult);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }


        public static DataTable TSHP_WORKORDER_QUERY19(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT ");
                    sbQuery.Append("  TWO.PLT_CODE ");
                    sbQuery.Append(" , TWO.WP_NO ");
                    sbQuery.Append(" , TWO.WO_NO ");
                    sbQuery.Append(" , TWO.PROD_CODE ");
                    sbQuery.Append(" , TWO.PART_CODE ");
                    sbQuery.Append(" , TWO.PART_ID ");
                    sbQuery.Append(" , TWO.PROC_CODE");
                    sbQuery.Append(" , TWO.PROC_SEQ  ");
                    sbQuery.Append(" , TWO.PROC_ID");
                    sbQuery.Append(" , TWO.MC_CODE ");
                    sbQuery.Append(" , TWO.EMP_CODE ");
                    sbQuery.Append(" , TWO.PLN_START_TIME");
                    sbQuery.Append(" , TWO.PLN_END_TIME");
                    sbQuery.Append(" , ISNULL(PLN_START_TIME,DBO.FNCHARTODATE(TWO.PLN_START_TIME)) AS PLN_START    ");
                    sbQuery.Append(" , ISNULL(PLN_START_TIME,DBO.FNCHARTODATE(TWO.PLN_END_TIME)) AS PLN_END    ");
                    sbQuery.Append(" , DATEDIFF(minute, ACT_START_TIME, CASE WHEN ACT_END_TIME IS NULL THEN GETDATE() ELSE ACT_END_TIME END) AS JOB_TIME ");

                    sbQuery.Append(" , TWO.ACT_END_TIME AS ACT_END    ");
                    sbQuery.Append(" , TWO.WO_FLAG ");
                    //sbQuery.Append(" , (SELECT CD_NAME FROM TSTD_CODES WHERE CAT_CODE = 'S032' AND CD_CODE = W.WO_FLAG) AS WO_FLAG_NAME ");
                    sbQuery.Append(" , TWO.WO_TYPE ");
                    sbQuery.Append(" , TWO.PART_QTY");
                    sbQuery.Append(" , TWO.ACT_QTY");
                    sbQuery.Append(" , TWO.JOB_PRIORITY");
                    sbQuery.Append(" , TWO.IS_LAST");
                    sbQuery.Append(" , TWO.IS_OS");
                    sbQuery.Append(" , TP.PROD_QTY");
                    sbQuery.Append(" , LSP.MPROC_CODE AS PRG_CODE");
                    sbQuery.Append(" , ASSY.IMPORTANCE");

                    sbQuery.Append("  FROM TORD_PRODUCT TP																					 ");
                    sbQuery.Append("	INNER JOIN TORD_ITEM TI																		 ");
                    sbQuery.Append("		ON TP.PLT_CODE = TI.PLT_CODE																	 ");
                    sbQuery.Append("		AND TP.ITEM_CODE = TI.ITEM_CODE																 ");
                    sbQuery.Append("		AND TP.DATA_FLAG = TI.DATA_FLAG																 ");
                    sbQuery.Append("	LEFT JOIN TSTD_VENDOR TV");
                    sbQuery.Append("		ON TP.PLT_CODE = TI.PLT_CODE            ");
                    sbQuery.Append("	    AND TI.CVND_CODE = TV.VEN_CODE");
                    sbQuery.Append("	    AND TP.DATA_FLAG = TV.DATA_FLAG");
                    //sbQuery.Append("	INNER JOIN (SELECT PLT_CODE, PROD_CODE, PART_CODE FROM TORD_PRODUCT WHERE PARENT_PART IS NULL		 ");
                    //sbWhere.Append(" AND DATA_FLAG = 0");
                    //sbWhere.Append("	) TPP	 ");
                    //sbWhere.Append("		ON TP.PLT_CODE = TPP.PLT_CODE																	 ");
                    //sbWhere.Append("		AND TP.PROD_CODE = TPP.PROD_CODE																 ");
                    //sbWhere.Append("		AND (TP.PARENT_PART = TPP.PART_CODE OR TP.PART_CODE = TPP.PART_CODE)							 ");
                    sbQuery.Append("	INNER JOIN TSHP_WORKPLAN TWP																		 ");
                    sbQuery.Append("		ON TP.PLT_CODE = TWP.PLT_CODE																	 ");
                    sbQuery.Append("		AND TP.PROD_CODE = TWP.PROD_CODE																 ");
                    sbQuery.Append("		AND TP.PART_CODE = TWP.PART_CODE																 ");
                    sbQuery.Append("		AND TP.DATA_FLAG = TWP.DATA_FLAG																 ");
                    sbQuery.Append("	INNER JOIN TSHP_WORKORDER TWO																		 ");
                    sbQuery.Append("		ON TP.PLT_CODE = TWO.PLT_CODE																	 ");
                    sbQuery.Append("		AND TWP.WP_NO = TWO.WP_NO																		 ");
                    sbQuery.Append("		AND TP.DATA_FLAG = TWO.DATA_FLAG																 ");
                    sbQuery.Append("	INNER JOIN LSE_STD_PROC LSP																		 ");
                    sbQuery.Append("		ON TP.PLT_CODE = LSP.PLT_CODE																	 ");
                    sbQuery.Append("		AND TWO.PROC_CODE = LSP.PROC_CODE																		 ");
                    sbQuery.Append("		AND LSP.IS_ASSY = 1																 ");
                    sbQuery.Append("		AND TP.DATA_FLAG = LSP.DATA_FLAG																 ");
                    sbQuery.Append("	LEFT JOIN LSE_STD_PARTPROC_ASSY ASSY																		 ");
                    sbQuery.Append("		ON TP.PLT_CODE = ASSY.PLT_CODE																	 ");
                    sbQuery.Append("		AND TP.PART_CODE = ASSY.PART_CODE																		 ");
                    sbQuery.Append("		AND TWO.PROC_CODE = ASSY.PROC_CODE																		 ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder();
                        
                        sbWhere.Append(" WHERE TP.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                        
                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_STATE", "TP.PROD_STATE IN @PROD_STATE", UTIL.SqlCondType.IN));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_ORD_DATE, @E_ORD_DATE", "(TP.ORD_DATE BETWEEN @S_ORD_DATE AND @E_ORD_DATE)"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_DUE_DATE, @E_DUE_DATE", "(TP.DUE_DATE BETWEEN @S_DUE_DATE AND @E_DUE_DATE)"));
                        sbWhere.Append(UTIL.GetWhere(row, "@VEN_LIKE", "(TI.CVND_CODE LIKE '%' + @VEN_LIKE + '%' OR TV.VEN_NAME LIKE '%' + @VEN_LIKE + '%')"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_CODE", "TP.PROD_CODE = @PROD_CODE"));
                        sbWhere.Append(" AND PARENT_PART IS NULL");
                        sbWhere.Append(" AND TP.DATA_FLAG = 0");
                        //sbWhere.Append(" AND TW.WO_FLAG IN ('2', '3', '4') ");

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

        public static DataTable TSHP_WORKORDER_QUERY20(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("  SELECT TW.PLT_CODE	    ");
                    sbQuery.Append("   	 , @ACTUAL_ID AS ACTUAL_ID    ");
                    sbQuery.Append("   	 , TW.PROD_CODE    ");
                    sbQuery.Append("   	 , TW.PART_CODE  ");
                    sbQuery.Append("   	 , P.PROC_SEQ  ");
                    sbQuery.Append("   	 , P.IS_OS  ");
                    sbQuery.Append("   	 , PP.PROC_COST");
                    sbQuery.Append("    FROM TSHP_WORKORDER TW  ");
                    sbQuery.Append("  	INNER JOIN LSE_STD_PARTPROC PP									       ");
                    sbQuery.Append("   		ON TW.PLT_CODE = PP.PLT_CODE						       ");
                    sbQuery.Append("   		AND TW.PART_CODE = PP.PART_CODE						       ");
                    sbQuery.Append("   		AND TW.PROC_CODE = PP.PROC_CODE	  ");
                    sbQuery.Append("   	INNER JOIN LSE_STD_PROC P							       ");
                    sbQuery.Append("   		ON PP.PLT_CODE = P.PLT_CODE						       ");
                    sbQuery.Append("   		AND PP.PROC_CODE = P.PROC_CODE						       ");



                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE TW.PLT_CODE = " + ConnInfo.PLT_CODE);
                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_CODE", "TW.PROD_CODE = @PROD_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_CODE", "TW.PART_CODE = @PART_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "TW.DATA_FLAG = @DATA_FLAG"));
                        if (UTIL.ValidColumn(row, "PROC_SEQ"))
                        {
                            sbWhere.Append(" AND P.PROC_SEQ <= " + UTIL.GetValidValue(row, "PROC_SEQ") );
                        }

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

        public static DataTable TSHP_WORKORDER_QUERY21(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("  SELECT TW.PLT_CODE	    ");
                    sbQuery.Append("   	 , @NG_ID AS NG_ID    ");
                    sbQuery.Append("   	 , TW.PROD_CODE    ");
                    sbQuery.Append("   	 , TW.PART_CODE  ");
                    sbQuery.Append("   	 , P.PROC_SEQ  ");
                    sbQuery.Append("   	 , P.IS_OS  ");
                    sbQuery.Append("   	 , PP.PROC_COST");
                    sbQuery.Append("    FROM TSHP_WORKORDER TW  ");
                    sbQuery.Append("  	INNER JOIN LSE_STD_PARTPROC PP									       ");
                    sbQuery.Append("   		ON TW.PLT_CODE = PP.PLT_CODE						       ");
                    sbQuery.Append("   		AND TW.PART_CODE = PP.PART_CODE						       ");
                    sbQuery.Append("   		AND TW.PROC_CODE = PP.PROC_CODE	  ");
                    sbQuery.Append("   	INNER JOIN LSE_STD_PROC P							       ");
                    sbQuery.Append("   		ON PP.PLT_CODE = P.PLT_CODE						       ");
                    sbQuery.Append("   		AND PP.PROC_CODE = P.PROC_CODE						       ");



                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE TW.PLT_CODE = " + ConnInfo.PLT_CODE);
                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_CODE", "TW.PROD_CODE = @PROD_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_CODE", "TW.PART_CODE = @PART_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "TW.DATA_FLAG = @DATA_FLAG"));
                        if (UTIL.ValidColumn(row, "PROC_SEQ"))
                        {
                            sbWhere.Append(" AND P.PROC_SEQ <= " + UTIL.GetValidValue(row, "PROC_SEQ"));
                        }

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

        /// <summary>
        ///  조립 작업지시 조회
        /// SJK 2021-05-18
        /// </summary>
        /// <param name="dtParam"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataTable TSHP_WORKORDER_QUERY22(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT W.PLT_CODE");
                    sbQuery.Append(" ,W.WP_NO");
                    sbQuery.Append(" ,W.WO_NO");
                    sbQuery.Append(" ,S.PART_PRODTYPE");
                    sbQuery.Append(" ,TP.ITEM_CODE");
                    sbQuery.Append(" ,W.PROD_CODE");
                    sbQuery.Append(" ,TP.PROD_NAME");
                    sbQuery.Append(" ,W.PART_CODE");
                    sbQuery.Append(" ,S.PART_NAME");
                    sbQuery.Append(" ,S.STD_PT_NUM");
                    sbQuery.Append(" ,ISNULL(SP.IS_MAT, 0) IS_MAT");
                    sbQuery.Append(" ,S.MAT_SPEC");
                    sbQuery.Append(" ,S.MAT_SPEC1");
                    sbQuery.Append(" ,S.BAL_SPEC");
                    sbQuery.Append(" ,S.BAL_WEIGHT");
                    sbQuery.Append(" ,S.DRAW_NO");
                    sbQuery.Append(" ,W.PROC_CODE");
                    sbQuery.Append(" ,W.PROC_SEQ");
                    sbQuery.Append(" ,S.MAT_COST");
                    sbQuery.Append(" ,SP.PROC_NAME");
                    sbQuery.Append(" ,W.MC_CODE");
                    sbQuery.Append(" ,M.MC_NAME");
                    sbQuery.Append(" ,W.EMP_CODE");
                    sbQuery.Append(" ,E.EMP_NAME");
                    sbQuery.Append(" ,TP.PROD_QTY");
                    sbQuery.Append(" ,W.PART_QTY AS PLN_QTY");
                    sbQuery.Append(" ,W.PART_QTY");
                    sbQuery.Append(" ,W.WO_FLAG");
                    sbQuery.Append(" ,W.CAUTION");
                    sbQuery.Append(" ,W.JOB_PRIORITY");
                    sbQuery.Append(" ,W.WORK_CODE");
                    sbQuery.Append(" ,ISNULL(W.IS_OS,0) AS IS_OS");
                    sbQuery.Append(" ,SP.IS_MAT");
                    sbQuery.Append(" ,W.CAM_EMP");
                    sbQuery.Append(" ,W.CAM_EMP_DATE");
                    sbQuery.Append(" ,W.CAM_DATE");
                    sbQuery.Append(" ,TP.PROD_VERSION");
                    sbQuery.Append(" ,TP.PROD_KIND");
                    sbQuery.Append(" ,TP.PROC_FLAG");
                    sbQuery.Append(" ,TP.PROD_FLAG");
                    sbQuery.Append(" ,TP.INS_YN");
                    sbQuery.Append(" ,TP.SOCKET_YN");
                    sbQuery.Append(" ,TP.PROD_TYPE");
                    sbQuery.Append(" ,TP.PROD_CATEGORY");
                    sbQuery.Append(" ,TP.BUSINESS_EMP");
                    sbQuery.Append(" ,TP.CUSTOMER_EMP");
                    sbQuery.Append(" ,TP.CUSTDESIGN_EMP");
                    sbQuery.Append(" ,TP.ACTUATOR_YN");
                    sbQuery.Append(" ,TP.CVND_CODE");
                    sbQuery.Append(" ,CVND.VEN_NAME AS CVND_NAME");
                    sbQuery.Append(" ,TP.TVND_CODE");
                    sbQuery.Append(" ,TVND.BVEN_NAME AS TVND_NAME");
                    sbQuery.Append(" ,TP.PROBE_PIN");
                    sbQuery.Append(" ,TP.PIN_TYPE");
                    sbQuery.Append(" ,TP.CURR_UNIT");
                    sbQuery.Append(" ,TP.ORD_DATE");
                    sbQuery.Append(" ,TP.INDUE_DATE");
                    sbQuery.Append(" ,TP.DUE_DATE");
                    sbQuery.Append(" ,TP.CHG_DUE_DATE");
                    sbQuery.Append(" ,TP.END_DATE");
                    sbQuery.Append(" ,TP.DELIVERY_DATE");
                    sbQuery.Append(" ,TP.PROD_QTY");
                    sbQuery.Append(" ,TP.LOAD_FLAG");
                    sbQuery.Append(" ,TP.LOCK_FLAG");
                    sbQuery.Append(" ,TP.LOCK_EMP");
                    sbQuery.Append(" ,TP.SHIP_FLAG");
                    sbQuery.Append(" ,TP.PROD_STATE");
                    sbQuery.Append(" ,TP.INOUT_FLAG");
                    sbQuery.Append(" ,TP.ORD_VAT");
                    sbQuery.Append(" ,TP.PROD_UC");
                    sbQuery.Append(" ,CA.ACT_START_TIME");
                    sbQuery.Append(" ,CA.ACT_END_TIME");
                    sbQuery.Append(" ,CA.ACT_TIME");
                    sbQuery.Append(" ,CA.X_VALUE");
                    sbQuery.Append(" ,CA.Y_VALUE");
                    sbQuery.Append(" ,CA.T_VALUE");
                    sbQuery.Append(" ,CA.SCOMMENT AS CAM_SCOMMENT");
                    sbQuery.Append(" ,PT.SCOMMENT AS SCOMMENT");
                    sbQuery.Append(" ,TP.SCOMMENT AS ORD_SCOMMENT");
                    sbQuery.Append(" ,CA.MAT_CODE AS CAM_MAT_CODE");
                    sbQuery.Append(" ,ISNULL(BW.ACT_QTY,0) AS INS_QTY ");
                    sbQuery.Append(" ,W.PT_ID");
                    sbQuery.Append(" ,YA.ACTUAL_ID");
                    sbQuery.Append(" ,YA.ASSY_RATE");
                    sbQuery.Append(" ,TP.PROD_PRIORITY");
                    sbQuery.Append(" ,AD.DRAW_EMP ");
                    sbQuery.Append(" ,PT.ASSY_EMPS ");
                    sbQuery.Append(" ,PT.PIN_EMPS ");

                    sbQuery.Append(" ,INS.SCOMMENT AS INS_SCOMMENT ");
                    sbQuery.Append(" ,ASSY.SCOMMENT AS ASSY_SCOMMENT ");

                    sbQuery.Append(" FROM TSHP_WORKORDER W");
                    sbQuery.Append(" LEFT JOIN TORD_PRODUCT TP ON TP.PLT_CODE = W.PLT_CODE AND TP.PROD_CODE = W.PROD_CODE");
                    
                    sbQuery.Append(" LEFT JOIN LSE_STD_PART S ON W.PLT_CODE = S.PLT_CODE AND  W.PART_CODE = S.PART_CODE");
                    
                    sbQuery.Append(" LEFT JOIN LSE_STD_PROC SP ON W.PLT_CODE = SP.PLT_CODE AND W.PROC_CODE = SP.PROC_CODE");
                    
                    sbQuery.Append(" LEFT JOIN LSE_MACHINE M ON W.PLT_CODE = M.PLT_CODE AND W.MC_CODE = M.MC_CODE");
                    
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE E ON W.PLT_CODE = E.PLT_CODE AND W.EMP_CODE = E.EMP_CODE");
                    
                    sbQuery.Append(" LEFT JOIN TSHP_ACTUAL_CAM CA ON W.PLT_CODE = CA.PLT_CODE AND W.PT_ID = CA.PT_ID");
                    
                    sbQuery.Append(" LEFT JOIN TSHP_ACTUAL_ASSY YA ON W.PLT_CODE = YA.PLT_CODE AND W.WO_NO = YA.WO_NO");

                    sbQuery.Append(" LEFT JOIN TSHP_WORKORDER BW ON W.PLT_CODE = BW.PLT_CODE AND W.PT_ID = BW.PT_ID AND (W.PROC_ID -1) = BW.PROC_ID AND BW.DATA_FLAG = '0'");
                    
                    sbQuery.Append(" LEFT JOIN TSTD_VENDOR CVND");
                    sbQuery.Append(" ON TP.PLT_CODE = CVND.PLT_CODE");
                    sbQuery.Append(" AND TP.CVND_CODE = CVND.VEN_CODE");
                    
                    sbQuery.Append(" LEFT JOIN TSTD_BILL_VENDOR TVND");
                    sbQuery.Append(" ON TP.PLT_CODE = TVND.PLT_CODE");
                    sbQuery.Append(" AND TP.TVND_CODE = TVND.BVEN_CODE");
                    
                    sbQuery.Append(" LEFT JOIN TMAT_PARTLIST PT ");
                    sbQuery.Append(" ON W.PLT_CODE = PT.PLT_CODE");
                    sbQuery.Append(" AND W.PT_ID = PT.PT_ID");

                    sbQuery.Append(" LEFT JOIN (");
                    sbQuery.Append(" SELECT PLT_CODE, PROD_CODE, MAX(DRAW_EMP) AS DRAW_EMP FROM TMAT_PARTLIST");
                    sbQuery.Append(" WHERE ISNULL(O_PT_ID,'') = '' AND DATA_FLAG = '0' AND LEFT(PART_CODE,1) = 'A'");
                    sbQuery.Append(" GROUP BY PLT_CODE, PROD_CODE");
                    sbQuery.Append(" ) AD");
                    sbQuery.Append(" ON TP.PLT_CODE = AD.PLT_CODE");
                    sbQuery.Append(" AND TP.PROD_CODE = AD.PROD_CODE");

                    sbQuery.Append(" LEFT JOIN TPOP_INS_SCOMMENT INS");
                    sbQuery.Append(" ON W.PLT_CODE = INS.PLT_CODE");
                    sbQuery.Append(" AND W.PROD_CODE = INS.PROD_CODE");
                    sbQuery.Append(" AND W.PT_ID = INS.PT_ID");
                    //sbQuery.Append(" AND W.WO_NO = INS.WO_NO");

                    sbQuery.Append(" LEFT JOIN TPOP_ASSY_SCOMMENT ASSY");
                    sbQuery.Append(" ON W.PLT_CODE = ASSY.PLT_CODE");
                    sbQuery.Append(" AND W.PROD_CODE = ASSY.PROD_CODE");
                    sbQuery.Append(" AND W.PT_ID = ASSY.PT_ID");
                    //sbQuery.Append(" AND W.WO_NO = ASSY.WO_NO");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder();

                        sbWhere.Append(" WHERE W.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                        sbWhere.Append(UTIL.GetWhere(row, "@WO_NO", "W.WO_NO = @WO_NO"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_CODE", "W.PROD_CODE = @PROD_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_CODE", "W.PART_CODE = @PART_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@MC_CODE", "W.MC_CODE = @MC_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PROC_CODE", "W.PROC_CODE = @PROC_CODE"));
                        //sbWhere.Append(UTIL.GetWhere(row, "@EMP_CODE", "W.EMP_CODE = @EMP_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@CAM_EMP", "W.CAM_EMP = @CAM_EMP"));
                        //sbWhere.Append(UTIL.GetWhere(row, "@MILL_EMP", "MA.MILL_EMP = @MILL_EMP"));
                        //sbWhere.Append(UTIL.GetWhere(row, "@IS_END", "W.INS_DATE IS NULL"));
                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "W.DATA_FLAG = @DATA_FLAG"));
                        sbWhere.Append(UTIL.GetWhere(row, "@WO_TYPE", "SP.WO_TYPE = @WO_TYPE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_LIKE", "W.PROD_CODE LIKE '%' + @PROD_LIKE + '%' OR TP.PROD_NAME LIKE '%' + @PROD_LIKE + '%'"));
                        sbWhere.Append(UTIL.GetWhere(row, "@CVND_LIKE", "TP.CVND_CODE LIKE '%' + @CVND_LIKE + '%' OR CVND.VEN_NAME LIKE '%' + @CVND_LIKE + '%'"));

                        sbWhere.Append(UTIL.GetWhere(row, "@S_REG_DATE, @E_REG_DATE", "(CONVERT(nvarchar(8),TP.REG_DATE,112) BETWEEN @S_REG_DATE AND @E_REG_DATE)"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_ORD_DATE, @E_ORD_DATE", "(TP.ORD_DATE BETWEEN @S_ORD_DATE AND @E_ORD_DATE)"));
                        //sbWhere.Append(UTIL.GetWhere(row, "@S_DUE_DATE, @E_DUE_DATE", "(TP.DUE_DATE BETWEEN @S_DUE_DATE AND @E_DUE_DATE)"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_DUE_DATE, @E_DUE_DATE", "ISNULL(TP.CHG_DUE_DATE, TP.DUE_DATE) BETWEEN @S_DUE_DATE AND @E_DUE_DATE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_DELIVERY_DATE, @E_DELIVERY_DATE", "(TP.DELIVERY_DATE BETWEEN @S_DELIVERY_DATE AND @E_DELIVERY_DATE)"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PROC_CODE_IN", "W.PROC_CODE IN @PROC_CODE_IN", UTIL.SqlCondType.IN));
                        //sbWhere.Append(" AND (ISNULL(BW.WO_FLAG,'0') = '4' OR BW.WO_NO IS NULL) ");
                        sbWhere.Append(" AND TP.PROD_STATE <> '5'  AND W.WO_FLAG <> '0' AND TP.DATA_FLAG = 0 AND PT.DATA_FLAG = 0 ");
                        sbWhere.Append(" AND (BW.ACT_QTY > 0 OR BW.WO_NO IS NULL) ");
                        sbWhere.Append(" ORDER BY W.PART_ID, W.PROC_ID");

                        DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString() + sbWhere.ToString(), row).Copy();

                        sourceTable.TableName = "RSLTDT";
                        dsResult.Merge(sourceTable, false, MissingSchemaAction.Add);
                    }
                }

                return UTIL.GetDsToDt(dsResult);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataTable TSHP_WORKORDER_QUERY23(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT ");
                    sbQuery.Append(" TP.PROD_CODE, ");
                    sbQuery.Append(" TP.PART_CODE, ");
                    sbQuery.Append(" TP.PROD_NAME, ");
                    sbQuery.Append(" TW.PROC_CODE, ");
                    sbQuery.Append(" TW.MC_CODE, ");
                    sbQuery.Append(" LM.MC_NAME, ");
                    sbQuery.Append(" SP.PROC_NAME, ");
                    sbQuery.Append(" SP.PROC_COLOR, ");
                    sbQuery.Append(" LSP.PART_NAME, ");
                    sbQuery.Append("  ");
                    //sbQuery.Append(" TW.PLN_START_TIME, ");
                    //sbQuery.Append(" TW.PLN_END_TIME, ");
                    sbQuery.Append(" TW.ACT_START_TIME AS PLN_START_TIME, ");
                    sbQuery.Append(" DATEADD(MINUTE,(TW.PART_QTY - TW.ACT_QTY) * TW.PLN_STD_TIME,TW.ACT_START_TIME) AS PLN_END_TIME, ");
                    sbQuery.Append(" TW.WO_FLAG AS WIP_STATE");

                    sbQuery.Append("  ");
                    sbQuery.Append(" FROM TORD_PRODUCT TP ");
                    sbQuery.Append(" JOIN TSHP_WORKORDER TW ");
                    sbQuery.Append(" ON TP.PLT_CODE = TW.PLT_CODE ");
                    sbQuery.Append(" AND TP.PROD_CODE = TW.PROD_CODE ");
                    sbQuery.Append(" AND TP.PART_CODE = TW.PART_CODE ");
                    sbQuery.Append(" AND TW.DATA_FLAG = 0 ");

                    sbQuery.Append(" JOIN LSE_STD_PROC SP ");
                    sbQuery.Append(" ON TW.PLT_CODE = SP.PLT_CODE ");
                    sbQuery.Append(" AND TW.PROC_CODE = SP.PROC_CODE ");
                    sbQuery.Append(" JOIN LSE_STD_PART LSP ");
                    sbQuery.Append(" ON TW.PLT_CODE = LSP.PLT_CODE ");
                    sbQuery.Append(" AND TW.PART_CODE = LSP.PART_CODE ");
                    sbQuery.Append(" LEFT JOIN LSE_MACHINE LM ");
                    sbQuery.Append(" ON TW.PLT_CODE = LM.PLT_CODE ");
                    sbQuery.Append(" AND TW.MC_CODE = LM.MC_CODE ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder();

                        sbWhere.Append(" WHERE TP.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        //sbWhere.Append(UTIL.GetWhere(row, "@PROD_CODE", "TP.PROD_CODE = @PROD_CODE"));
                        //sbWhere.Append(UTIL.GetWhere(row, "@PART_CODE", "TP.PART_CODE = @PART_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_CODE", "TP.PROD_CODE LIKE '%' + @PROD_CODE + '%'"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_CODE", "TP.PART_CODE LIKE '%' + @PART_CODE + '%'"));

                        sbWhere.Append(" AND TP.DATA_FLAG = 0");
                        sbWhere.Append(" AND TP.LOAD_FLAG <> 1 ");
                        sbWhere.Append(" AND TW.WO_FLAG IN ('2','3') ");
                        sbWhere.Append(" AND TW.IS_OS = 0 ");

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


        /// <summary>
        /// 일일작업지시 조회
        /// SJK 2021-09-01
        /// </summary>
        /// <param name="dtParam"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataTable TSHP_WORKORDER_QUERY24(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT W.PLT_CODE");
                    sbQuery.Append(" ,W.WP_NO");
                    sbQuery.Append(" ,W.WO_NO");
                    sbQuery.Append(" ,S.PART_PRODTYPE");
                    sbQuery.Append(" ,TP.ITEM_CODE");
                    sbQuery.Append(" ,W.PROD_CODE");
                    sbQuery.Append(" ,TP.PROD_NAME");
                    sbQuery.Append(" ,W.PART_CODE");
                    sbQuery.Append(" ,S.PART_NAME");
                    sbQuery.Append(" ,S.STD_PT_NUM");
                    sbQuery.Append(" ,ISNULL(SP.IS_MAT, 0) IS_MAT");
                    sbQuery.Append(" ,S.MAT_SPEC");
                    sbQuery.Append(" ,S.MAT_SPEC1");
                    sbQuery.Append(" ,S.BAL_SPEC");
                    sbQuery.Append(" ,S.BAL_WEIGHT");
                    sbQuery.Append(" ,S.DRAW_NO");
                    sbQuery.Append(" ,W.PROC_CODE");
                    sbQuery.Append(" ,W.PROC_SEQ");
                    sbQuery.Append(" ,SP.PROC_NAME");
                    sbQuery.Append(" ,W.MC_CODE");
                    sbQuery.Append(" ,M.MC_NAME");
                    sbQuery.Append(" ,W.EMP_CODE");
                    sbQuery.Append(" ,E.EMP_NAME");
                    sbQuery.Append(" ,TP.PROD_QTY");
                    sbQuery.Append(" ,W.PART_QTY AS PLN_QTY");
                    sbQuery.Append(" ,W.PART_QTY");
                    sbQuery.Append(" ,W.WO_FLAG");                    
                    sbQuery.Append(" ,W.CAUTION");
                    sbQuery.Append(" ,W.JOB_PRIORITY");
                    sbQuery.Append(" ,W.WORK_CODE");
                    sbQuery.Append(" ,W.MC_GROUP");
                    sbQuery.Append(" ,ISNULL(W.IS_OS,0) AS IS_OS");
                    sbQuery.Append(" ,SP.IS_MAT");
                    sbQuery.Append(" ,W.CAM_EMP");
                    sbQuery.Append(" ,W.CAM_EMP_DATE");
                    sbQuery.Append(" ,W.CAM_DATE");
                    sbQuery.Append(" ,W.PLN_START_TIME ");
                    sbQuery.Append(" ,W.PLN_END_TIME ");
                    sbQuery.Append(" ,dbo.fnCharToDate(W.PLN_START_TIME) AS PLN_START ");
                    sbQuery.Append(" ,dbo.fnCharToDate(W.PLN_END_TIME) AS PLN_END ");
                    sbQuery.Append(" ,W.PLN_PROC_TIME ");
                    sbQuery.Append(" ,TP.PROD_VERSION");
                    sbQuery.Append(" ,TP.PROC_FLAG");
                    sbQuery.Append(" ,TP.PROD_FLAG");
                    sbQuery.Append(" ,TP.INS_YN");
                    sbQuery.Append(" ,TP.SOCKET_YN");
                    sbQuery.Append(" ,TP.PROD_TYPE");
                    sbQuery.Append(" ,TP.PROD_CATEGORY");
                    sbQuery.Append(" ,TP.BUSINESS_EMP");
                    sbQuery.Append(" ,TP.CUSTOMER_EMP");
                    sbQuery.Append(" ,TP.CUSTDESIGN_EMP");
                    sbQuery.Append(" ,TP.ACTUATOR_YN");
                    sbQuery.Append(" ,TP.CVND_CODE");
                    sbQuery.Append(" ,CVND.VEN_NAME AS CVND_NAME");
                    sbQuery.Append(" ,TP.TVND_CODE");
                    sbQuery.Append(" ,TVND.BVEN_NAME AS TVND_NAME");
                    sbQuery.Append(" ,TP.PROBE_PIN");
                    sbQuery.Append(" ,TP.CURR_UNIT");
                    sbQuery.Append(" ,TP.ORD_DATE");
                    sbQuery.Append(" ,TP.INDUE_DATE");
                    sbQuery.Append(" ,TP.DUE_DATE");
                    sbQuery.Append(" ,TP.CHG_DUE_DATE");
                    sbQuery.Append(" ,TP.END_DATE");
                    sbQuery.Append(" ,TP.DELIVERY_DATE");
                    sbQuery.Append(" ,TP.PROD_QTY");
                    sbQuery.Append(" ,TP.LOAD_FLAG");
                    sbQuery.Append(" ,TP.LOCK_FLAG");
                    sbQuery.Append(" ,TP.LOCK_EMP");
                    sbQuery.Append(" ,TP.SHIP_FLAG");
                    sbQuery.Append(" ,TP.PROD_STATE");
                    sbQuery.Append(" ,TP.INOUT_FLAG");
                    sbQuery.Append(" ,TP.ORD_VAT");
                    sbQuery.Append(" ,TP.PROD_UC");
                    sbQuery.Append(" ,CA.ACT_START_TIME");
                    sbQuery.Append(" ,CA.ACT_END_TIME");
                    sbQuery.Append(" ,CA.ACT_TIME");
                    sbQuery.Append(" ,CA.X_VALUE");
                    sbQuery.Append(" ,CA.Y_VALUE");
                    sbQuery.Append(" ,CA.T_VALUE");
                    sbQuery.Append(" ,CA.SCOMMENT");
                    sbQuery.Append(" ,CA.MAT_CODE AS CAM_MAT_CODE");
                    sbQuery.Append(" ,ISNULL(BW.ACT_QTY,0) AS INS_QTY ");
                    sbQuery.Append(" ,W.PT_ID");
                    sbQuery.Append(" ,YA.ACTUAL_ID");
                    sbQuery.Append(" ,YA.ASSY_RATE");
                    sbQuery.Append(" FROM TSHP_WORKORDER W");
                    sbQuery.Append(" LEFT JOIN TORD_PRODUCT TP ON TP.PLT_CODE = W.PLT_CODE AND TP.PROD_CODE = W.PROD_CODE");
                    sbQuery.Append(" LEFT JOIN LSE_STD_PART S ON W.PLT_CODE = S.PLT_CODE AND  W.PART_CODE = S.PART_CODE");
                    sbQuery.Append(" LEFT JOIN LSE_STD_PROC SP ON W.PLT_CODE = SP.PLT_CODE AND W.PROC_CODE = SP.PROC_CODE");
                    sbQuery.Append(" LEFT JOIN LSE_MACHINE M ON W.PLT_CODE = M.PLT_CODE AND W.MC_CODE = M.MC_CODE");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE E ON W.PLT_CODE = E.PLT_CODE AND W.EMP_CODE = E.EMP_CODE");
                    sbQuery.Append(" LEFT JOIN TSHP_ACTUAL_CAM CA ON W.PLT_CODE = CA.PLT_CODE AND W.PT_ID = CA.PT_ID");
                    sbQuery.Append(" LEFT JOIN TSHP_ACTUAL_ASSY YA ON W.PLT_CODE = YA.PLT_CODE AND W.WO_NO = YA.WO_NO");
                    //sbQuery.Append(" LEFT JOIN");
                    //sbQuery.Append(" (SELECT PLT_CODE, PT_ID, MIN(INS_QTY) AS INS_QTY FROM");
                    //sbQuery.Append(" (SELECT A.PLT_CODE,A.PT_ID,A.WO_FLAG,SUM(ISNULL(A.INS_QTY,0)) AS INS_QTY FROM TSHP_WORKORDER A");
                    //sbQuery.Append(" LEFT JOIN LSE_STD_PROC B ON A.PLT_CODE = B.PLT_CODE AND A.PROC_CODE = B.PROC_CODE");
                    //sbQuery.Append(" WHERE B.WO_TYPE = 'INS' GROUP BY A.PLT_CODE,A.PT_ID,A.WO_FLAG) A");
                    //sbQuery.Append(" GROUP BY PLT_CODE, PT_ID) INS");
                    //sbQuery.Append(" ON W.PLT_CODE = INS.PLT_CODE AND W.PT_ID = INS.PT_ID");

                    sbQuery.Append(" LEFT JOIN TSHP_WORKORDER BW ON W.PLT_CODE = BW.PLT_CODE AND W.PT_ID = BW.PT_ID AND (W.PROC_ID -1) = BW.PROC_ID AND ISNULL(W.RE_WO_NO,'1') = ISNULL(BW.RE_WO_NO,'1') AND BW.DATA_FLAG = '0'");
                    //sbQuery.Append(" LEFT JOIN (SELECT PLT_CODE, WO_NO,SUM(INS_QTY) AS INS_QTY FROM TSHP_ACTUAL_INS GROUP BY PLT_CODE, WO_NO) INS ");
                    //sbQuery.Append(" ON BW.PLT_CODE = INS.PLT_CODE AND BW.WO_NO = INS.WO_NO");

                    sbQuery.Append(" LEFT JOIN TSTD_VENDOR CVND");
                    sbQuery.Append(" ON TP.PLT_CODE = CVND.PLT_CODE");
                    sbQuery.Append(" AND TP.CVND_CODE = CVND.VEN_CODE");
                    sbQuery.Append(" LEFT JOIN TSTD_BILL_VENDOR TVND");
                    sbQuery.Append(" ON TP.PLT_CODE = TVND.PLT_CODE");
                    sbQuery.Append(" AND TP.TVND_CODE = TVND.BVEN_CODE");
                    sbQuery.Append(" LEFT JOIN TMAT_PARTLIST PT ");
                    sbQuery.Append(" ON W.PLT_CODE = PT.PLT_CODE");
                    sbQuery.Append(" AND W.PT_ID = PT.PT_ID");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder();

                        sbWhere.Append(" WHERE W.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                        sbWhere.Append(UTIL.GetWhere(row, "@WO_NO", "W.WO_NO = @WO_NO"));
                        sbWhere.Append(UTIL.GetWhere(row, "@WO_FLAG", "W.WO_FLAG = @WO_FLAG"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_CODE", "W.PROD_CODE = @PROD_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_CODE", "W.PART_CODE = @PART_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@MC_CODE", "W.MC_CODE = @MC_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PROC_CODE", "W.PROC_CODE = @PROC_CODE"));
                        //sbWhere.Append(UTIL.GetWhere(row, "@EMP_CODE", "W.EMP_CODE = @EMP_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@CAM_EMP", "W.CAM_EMP = @CAM_EMP"));
                        //sbWhere.Append(UTIL.GetWhere(row, "@MILL_EMP", "MA.MILL_EMP = @MILL_EMP"));
                        //sbWhere.Append(UTIL.GetWhere(row, "@IS_END", "W.INS_DATE IS NULL"));
                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "W.DATA_FLAG = @DATA_FLAG"));
                        sbWhere.Append(UTIL.GetWhere(row, "@WO_TYPE", "SP.WO_TYPE = @WO_TYPE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_LIKE", "W.PROD_CODE LIKE '%' + @PROD_LIKE + '%' OR TP.PROD_NAME LIKE '%' + @PROD_LIKE + '%'"));
                        sbWhere.Append(UTIL.GetWhere(row, "@CVND_LIKE", "TP.CVND_CODE LIKE '%' + @CVND_LIKE + '%' OR CVND.VEN_NAME LIKE '%' + @CVND_LIKE + '%'"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_WO_DATE,@E_WO_DATE", "(LEFT(W.PLN_START_TIME,8)  BETWEEN @S_WO_DATE AND @E_WO_DATE) OR (LEFT(W.PLN_END_TIME,8) BETWEEN @S_WO_DATE AND @E_WO_DATE)"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_REG_DATE,@E_REG_DATE", "(CONVERT(nvarchar(8),TP.REG_DATE,112) BETWEEN @S_REG_DATE AND @E_REG_DATE)"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_ORD_DATE,@E_ORD_DATE", "(TP.ORD_DATE BETWEEN @S_ORD_DATE AND @E_ORD_DATE)"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_DUE_DATE,@E_DUE_DATE", "(TP.DUE_DATE BETWEEN @S_DUE_DATE AND @E_DUE_DATE)"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_DELIVERY_DATE, @E_DELIVERY_DATE", "(TP.DELIVERY_DATE BETWEEN @S_DELIVERY_DATE AND @E_DELIVERY_DATE)"));
                        //sbWhere.Append(" AND (ISNULL(BW.WO_FLAG,'0') = '4' OR BW.WO_NO IS NULL) ");
                        sbWhere.Append(" AND TP.PROD_STATE <> '5' AND TP.DATA_FLAG = 0 AND PT.DATA_FLAG = 0 ");
                        //sbWhere.Append(" AND BW.ACT_QTY > 0 ");
                        sbWhere.Append(" ORDER BY W.PART_ID, W.PROC_ID");

                        DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString() + sbWhere.ToString(), row).Copy();

                        sourceTable.TableName = "RSLTDT";
                        dsResult.Merge(sourceTable, false, MissingSchemaAction.Add);
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
        /// 월별 부하율
        /// </summary>
        /// <param name="dtParam"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataTable TSHP_WORKORDER_QUERY25(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT A.PLT_CODE");
                    sbQuery.Append(" ,A.MC_GROUP");
                    sbQuery.Append(" ,CD.CD_NAME AS MC_GROUP_NAME");
                    sbQuery.Append(" ,SUM(ISNULL(A.CAPA,1440)) AS CAPA");
                    sbQuery.Append(" ,SUM(ISNULL(A.PLN_TIME,0)) AS ACT_TIME");
                    sbQuery.Append(" ,CASE WHEN SUM(ISNULL(A.CAPA,1440)) < SUM(ISNULL(A.PLN_TIME,0)) THEN 0 ELSE SUM(ISNULL(A.CAPA,1440)) - SUM(ISNULL(A.PLN_TIME,0)) END AS NONE_TIME");
                    sbQuery.Append(" ,0 AS IDLE_TIME");
                    sbQuery.Append(" ,CASE WHEN SUM(ISNULL(A.CAPA,1440)) = 0 THEN 1 ELSE SUM(ISNULL(A.PLN_TIME,0)) / SUM(ISNULL(A.CAPA,1440)) END AS ACT_RATE");
                    sbQuery.Append(" FROM");
                    sbQuery.Append(" (SELECT D.PLT_CODE");
                    sbQuery.Append(" ,D.WORK_DATE");
                    sbQuery.Append(" ,D.MC_GROUP");
                    sbQuery.Append(" ,D.CAPA");
                    sbQuery.Append(" ,SUM(ISNULL(W.PLN_PROC_TIME,0)) AS PLN_TIME");
                    sbQuery.Append(" ,SUM(ISNULL(W.PLN_PROC_SELF_TIME,0)) AS SELF_TIME");
                    sbQuery.Append(" ,SUM(ISNULL(W.PLN_PROC_MAN_TIME,0)) AS MAN_TIME");
                    sbQuery.Append(" FROM DBO.FN_MC_GROUP_CAPA(@PLT_CODE,@S_DATE,@E_DATE) D");
                    sbQuery.Append(" LEFT JOIN TSHP_WORKORDER W");
                    sbQuery.Append(" ON D.PLT_CODE = W.PLT_CODE");
                    sbQuery.Append(" AND D.MC_GROUP = W.MC_GROUP");
                    sbQuery.Append(" AND D.WORK_DATE = DBO.GETWORKDATE(W.PLT_CODE,DBO.FN_DM_STRTODATE_M(W.PLN_END_TIME))");
                    sbQuery.Append(" AND D.CAPA > 0");
                    sbQuery.Append(" AND W.DATA_FLAG = 0");
                    sbQuery.Append(" GROUP BY  D.PLT_CODE");
                    sbQuery.Append(" ,D.WORK_DATE");
                    sbQuery.Append(" ,D.MC_GROUP");
                    sbQuery.Append(" ,D.CAPA) A");
                    sbQuery.Append(" LEFT JOIN TSTD_CODES CD ");
                    sbQuery.Append(" ON A.PLT_CODE = CD.PLT_CODE");
                    sbQuery.Append(" AND A.MC_GROUP = CD.CD_CODE");
                    sbQuery.Append(" AND CD.CAT_CODE = 'C020' ");



                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder();

                        sbWhere.Append(" WHERE 1 = 1 ");
                        sbWhere.Append(UTIL.GetWhere(row, "@PLT_CODE", " A.PLT_CODE = @PLT_CODE "));
                        sbWhere.Append(UTIL.GetWhere(row, "@MC_GROUP", " A.MC_GROUP IN @MC_GROUP ", UTIL.SqlCondType.IN));
                        //sbWhere.Append(UTIL.GetWhere(row, "@MC_GROUP", "A.MC_CODE IN (SELECT MC_CODE FROM LSE_MACHINE WHERE PLT_CODE = A.PLT_CODE AND MC_GROUP IN (@MC_GROUP)) ", UTIL.SqlCondType.IN));
                        //sbWhere.Append(UTIL.GetWhere(row, "@MC_GROUP", "A.MC_CODE IN (SELECT MC_CODE FROM LSE_MACHINE WHERE PLT_CODE = A.PLT_CODE AND MC_GROUP IN (@MC_GROUP)) ", UTIL.SqlCondType.IN));
                        //sbWhere.Append(UTIL.GetWhere(row, "@YEAR_MONTH", " SUBSTRING(A.WORK_DATE,1,6)  = @YEAR_MONTH "));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_DATE,@E_DATE", " A.WORK_DATE BETWEEN @S_DATE AND @E_DATE "));
                        //sbWhere.Append(" AND A.CAPA > 0 ");
                        sbWhere.Append(" GROUP BY A.PLT_CODE,A.MC_GROUP,CD.CD_NAME,CD.CD_SEQ  ");
                        sbWhere.Append(" ORDER BY A.PLT_CODE,CD.CD_SEQ ");

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

        /// <summary>
        /// 생산진행현황 
        /// </summary>
        /// <param name="dtParam"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataTable TSHP_WORKORDER_QUERY26(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT W.PLT_CODE");
                    sbQuery.Append(" ,W.WP_NO ");
                    sbQuery.Append(" ,W.WO_NO ");
                    sbQuery.Append(" ,W.PT_ID ");
                    sbQuery.Append(" ,W.PART_CODE");
                    sbQuery.Append(" ,W.PROC_CODE ");
                    sbQuery.Append(" ,W.PART_QTY ");
                    sbQuery.Append(" ,W.PROC_SEQ  ");
                    sbQuery.Append(" ,W.PLN_START_TIME  ");
                    sbQuery.Append(" ,W.PLN_END_TIME  ");
                    sbQuery.Append(" ,W.ACT_START_TIME  ");
                    sbQuery.Append(" ,W.ACT_END_TIME  ");
                    sbQuery.Append(" ,W.WO_FLAG  ");
                    sbQuery.Append(" ,W.IS_OS");
                    sbQuery.Append(" ,W.PART_QTY AS PLN_QTY ");
                    sbQuery.Append(" ,CASE WHEN PRC.WO_TYPE = 'DES' THEN W.PART_QTY ELSE  W.ACT_QTY END AS OK_QTY ");
                    sbQuery.Append(" ,W.RE_WO_NO");
                    //sbQuery.Append(" ,CASE WHEN W.RE_WO_NO IS NULL THEN '0' ELSE '1' END AS IS_REWORK");

                    sbQuery.Append(" ,CASE WHEN W.RE_WO_NO IS NULL THEN '0'");
                    sbQuery.Append("   ELSE CASE WHEN W.IS_DES_CHANGE = 1 AND ISNULL(W.IS_REMCT, 0) = 0 AND ISNULL(W.IS_MODIFY, 0) = 0 THEN '2' ");
                    sbQuery.Append("             WHEN W.IS_DES_CHANGE = 1 AND ISNULL(W.IS_REMCT, 0) = 0 AND ISNULL(W.IS_MODIFY, 0) = 1 THEN '3'");
                    sbQuery.Append("             WHEN W.IS_DES_CHANGE = 1 AND ISNULL(W.IS_REMCT, 0) = 1 AND ISNULL(W.IS_MODIFY, 0) = 0 THEN '4'");
                    sbQuery.Append("             WHEN N.NG_TYPE = 'P' THEN '5' ELSE '6' END END AS IS_REWORK");

                    sbQuery.Append(" ,W.MC_GROUP  ");
                    sbQuery.Append(" ,W.CAM_EMP  ");
                    sbQuery.Append(" ,E.EMP_NAME AS CAM_EMP_NAME  ");
                    sbQuery.Append(" FROM TSHP_WORKORDER W");

                    sbQuery.Append(" LEFT JOIN TORD_PRODUCT P");
                    sbQuery.Append(" ON W.PLT_CODE = P.PLT_CODE");
                    sbQuery.Append(" AND W.PROD_CODE = P.PROD_CODE");

                    sbQuery.Append(" LEFT JOIN LSE_STD_PART S");
                    sbQuery.Append(" ON W.PLT_CODE = S.PLT_CODE");
                    sbQuery.Append(" AND W.PART_CODE = S.PART_CODE");

                    sbQuery.Append(" LEFT JOIN LSE_STD_PROC PRC");
                    sbQuery.Append(" ON W.PLT_CODE = PRC.PLT_CODE");
                    sbQuery.Append(" AND W.PROC_CODE = PRC.PROC_CODE");

                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE E");
                    sbQuery.Append(" ON W.PLT_CODE = E.PLT_CODE");
                    sbQuery.Append(" AND W.CAM_EMP = E.EMP_CODE");

                    sbQuery.Append(" LEFT JOIN TSHP_NG N");
                    sbQuery.Append(" ON W.PLT_CODE = N.PLT_CODE");
                    sbQuery.Append(" AND W.RE_WO_NO = N.RE_WO_NO");

                    //sbQuery.Append(" LEFT JOIN");
                    //sbQuery.Append(" (");
                    //sbQuery.Append(" SELECT");
                    //sbQuery.Append(" PLT_CODE, WO_NO, SUM(OK_QTY) AS OK_QTY");
                    //sbQuery.Append(" FROM TSHP_ACTUAL");
                    //sbQuery.Append(" GROUP BY PLT_CODE, WO_NO");
                    //sbQuery.Append(" ) A");
                    //sbQuery.Append(" ON W.PLT_CODE = A.PLT_CODE");
                    //sbQuery.Append(" AND W.WO_NO = A.WO_NO");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder();

                        sbWhere.Append(" WHERE W.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@WP_NO", "W.WP_NO = @WP_NO"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_CODE", "W.PROD_CODE = @PROD_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_CODE", "W.PART_CODE = @PART_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PT_ID", "W.PT_ID = @PT_ID"));
                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "W.DATA_FLAG = @DATA_FLAG"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_ORD_DATE, @E_ORD_DATE", "P.ORD_DATE BETWEEN @S_ORD_DATE AND @E_ORD_DATE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_DUE_DATE, @E_DUE_DATE", "ISNULL(P.CHG_DUE_DATE, P.DUE_DATE) BETWEEN @S_DUE_DATE AND @E_DUE_DATE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_LIKE", "(P.PROD_CODE LIKE '%' + @PROD_LIKE + '%' OR P.PROD_NAME LIKE '%' + @PROD_LIKE + '%')"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_LIKE", "(W.PART_CODE LIKE '%' + @PART_LIKE + '%' OR S.PART_NAME LIKE '%' + @PART_LIKE + '%')"));
                        sbWhere.Append(UTIL.GetWhere(row, "@IS_NOT_SHIP_FINISH", "P.PROD_STATE NOT IN ('9', '5')"));

                        sbWhere.Append(" AND P.DATA_FLAG = '0'");

                        sbWhere.Append(" ORDER BY W.PART_ID, W.PROC_ID");

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


        /// <summary>
        /// 일별 설비 그룹별 부하율
        /// </summary>
        /// <param name="dtParam"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataTable TSHP_WORKORDER_QUERY27(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT A.PLT_CODE");
                    sbQuery.Append(" ,A.MC_GROUP");
                    sbQuery.Append(" ,A.WORK_DATE");
                    sbQuery.Append(" ,CD.CD_NAME AS MC_GROUP_NAME");
                    sbQuery.Append(" ,SUM(ISNULL(A.CAPA,1440)) AS CAPA");
                    sbQuery.Append(" ,SUM(ISNULL(A.PLN_TIME,0)) AS ACT_TIME");
                    sbQuery.Append(" ,CASE WHEN SUM(ISNULL(A.CAPA,1440)) < SUM(ISNULL(A.PLN_TIME,0)) THEN 0 ELSE SUM(ISNULL(A.CAPA,1440)) - SUM(ISNULL(A.PLN_TIME,0)) END AS NONE_TIME");
                    sbQuery.Append(" ,0 AS IDLE_TIME");
                    sbQuery.Append(" ,CASE WHEN SUM(ISNULL(A.CAPA,1440)) = 0 THEN 1 ELSE SUM(ISNULL(A.PLN_TIME,0)) / SUM(ISNULL(A.CAPA,1440)) END AS PLAN_RATE");
                    sbQuery.Append(" FROM");
                    sbQuery.Append(" (SELECT D.PLT_CODE");
                    sbQuery.Append(" ,D.WORK_DATE");
                    sbQuery.Append(" ,D.MC_GROUP");
                    sbQuery.Append(" ,D.CAPA");
                    sbQuery.Append(" ,SUM(ISNULL(W.PLN_PROC_TIME,0)) AS PLN_TIME");
                    sbQuery.Append(" ,SUM(ISNULL(W.PLN_PROC_SELF_TIME,0)) AS SELF_TIME");
                    sbQuery.Append(" ,SUM(ISNULL(W.PLN_PROC_MAN_TIME,0)) AS MAN_TIME");
                    sbQuery.Append(" FROM DBO.FN_MC_GROUP_CAPA(@PLT_CODE,@S_DATE,@E_DATE) D");
                    sbQuery.Append(" LEFT JOIN TSHP_WORKORDER W");
                    sbQuery.Append(" ON D.PLT_CODE = W.PLT_CODE");
                    sbQuery.Append(" AND D.MC_GROUP = W.MC_GROUP");
                    sbQuery.Append(" AND D.WORK_DATE = DBO.GETWORKDATE(W.PLT_CODE,DBO.FN_DM_STRTODATE_M(W.PLN_END_TIME))");
                    sbQuery.Append(" AND D.CAPA > 0");
                    sbQuery.Append(" AND W.DATA_FLAG = 0");
                    sbQuery.Append(" LEFT JOIN LSE_STD_PROC SP");
                    sbQuery.Append(" ON W.PLT_CODE = SP.PLT_CODE");
                    sbQuery.Append(" AND W.PROC_CODE = SP.PROC_CODE");
                    sbQuery.Append(" WHERE SP.WO_TYPE = 'PRC' ");
                    sbQuery.Append(" GROUP BY  D.PLT_CODE");
                    sbQuery.Append(" ,D.WORK_DATE");
                    sbQuery.Append(" ,D.MC_GROUP");
                    sbQuery.Append(" ,D.CAPA) A");
                    sbQuery.Append(" LEFT JOIN TSTD_CODES CD ");
                    sbQuery.Append(" ON A.PLT_CODE = CD.PLT_CODE");
                    sbQuery.Append(" AND A.MC_GROUP = CD.CD_CODE");
                    sbQuery.Append(" AND CD.CAT_CODE = 'C020' ");



                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder();

                        sbWhere.Append(" WHERE 1 = 1 ");
                        sbWhere.Append(UTIL.GetWhere(row, "@PLT_CODE", " A.PLT_CODE = @PLT_CODE "));                        
                        sbWhere.Append(UTIL.GetWhere(row, "@MC_GROUP", "A.MC_GROUP IN (@MC_GROUP) ", UTIL.SqlCondType.IN));
                        sbWhere.Append(UTIL.GetWhere(row, "@YEAR_MONTH", " SUBSTRING(A.WORK_DATE,1,6)  = @YEAR_MONTH "));                        
                        //sbWhere.Append(" AND A.CAPA > 0 ");
                        sbWhere.Append(" GROUP BY A.PLT_CODE,A.MC_GROUP,A.WORK_DATE,CD.CD_NAME,CD.CD_SEQ  ");
                        sbWhere.Append(" ORDER BY A.PLT_CODE,A.WORK_DATE,CD.CD_SEQ ");

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

        /// <summary>
        /// 가공품의 가공작업지시의 시작예정일 가져오기, 가공 공정만 체크
        /// </summary>
        /// <param name="dtParam"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataTable TSHP_WORKORDER_QUERY28(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT W.PLT_CODE");
                    sbQuery.Append(" ,W.MC_GROUP ");
                    sbQuery.Append(" ,DBO.GETWORKDATE(W.PLT_CODE,DBO.FN_DM_STRTODATE_M(W.PLN_START_TIME)) AS PLN_START_DATE");
                    sbQuery.Append(" ,DBO.GETWORKDATE(W.PLT_CODE,DBO.FN_DM_STRTODATE_M(W.PLN_END_TIME)) AS PLN_END_DATE");
                    sbQuery.Append(" FROM TSHP_WORKORDER W ");                    
                    sbQuery.Append(" LEFT JOIN LSE_STD_PROC SP ON W.PLT_CODE = SP.PLT_CODE AND W.PROC_CODE = SP.PROC_CODE ");
                   
                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder();

                        sbWhere.Append(" WHERE W.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        //sbWhere.Append(UTIL.GetWhere(row, "@WO_TYPE", "SP.WO_TYPE = @WO_TYPE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PT_ID", "W.PT_ID = @PT_ID"));
                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "W.DATA_FLAG = @DATA_FLAG"));
                        sbWhere.Append(" AND SP.WO_TYPE  = 'PRC'");

                        sbWhere.Append(" GROUP BY W.PLT_CODE,W.MC_GROUP,DBO.GETWORKDATE(W.PLT_CODE,DBO.FN_DM_STRTODATE_M(W.PLN_START_TIME)),DBO.GETWORKDATE(W.PLT_CODE,DBO.FN_DM_STRTODATE_M(W.PLN_END_TIME)) ");                        

                        DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString() + sbWhere.ToString(), row).Copy();

                        sourceTable.TableName = "RSLTDT";
                        dsResult.Merge(sourceTable, false, MissingSchemaAction.Add);
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
        /// 밀링(P-03) 이후의 모든 공정에 대한 작업지시를 읽어옴
        /// </summary>
        /// <param name="dtParam"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataTable TSHP_WORKORDER_QUERY29(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("  SELECT  ");
                    sbQuery.Append("  W.PLT_CODE ");
                    sbQuery.Append(" ,W.WO_NO ");
                    sbQuery.Append(" ,W.PT_ID ");
                    sbQuery.Append(" ,W.PROD_CODE ");
                    sbQuery.Append(" ,W.PART_CODE ");
                    sbQuery.Append(" ,W.PART_ID ");
                    sbQuery.Append(" ,W.PART_NUM ");
                    sbQuery.Append(" ,W.PROC_CODE ");
                    sbQuery.Append(" ,W.PROC_ID ");
                    sbQuery.Append(" ,W.MC_GROUP ");
                    sbQuery.Append(" ,W.MC_CODE ");
                    sbQuery.Append(" ,W.EMP_CODE ");
                    sbQuery.Append(" ,W.PLN_PROC_TIME ");
                    sbQuery.Append(" ,W.PLN_PROC_SELF_TIME ");
                    sbQuery.Append(" ,W.PLN_PROC_MAN_TIME ");
                    sbQuery.Append(" ,W.WORK_CODE ");
                    sbQuery.Append(" ,W.PART_QTY ");
                    sbQuery.Append(" ,W.PLN_START_TIME ");
                    sbQuery.Append(" ,W.PLN_END_TIME ");
                    sbQuery.Append(" ,W.WORK_SCOMMENT ");
                    sbQuery.Append(" ,W.UPD_SCOMMENT ");
                    sbQuery.Append(" ,W.SCOMMENT ");
                    sbQuery.Append(" ,W.CAUTION ");
                    sbQuery.Append(" ,W.WO_FLAG ");
                    sbQuery.Append(" ,W.ACT_START_TIME ");
                    sbQuery.Append(" ,W.ACT_END_TIME ");
                    sbQuery.Append(" ,W.ACT_MC_TIME ");
                    sbQuery.Append(" ,W.ACT_MAN_TIME ");
                    sbQuery.Append(" ,W.ACT_PRE_TIME ");
                    sbQuery.Append(" ,W.ACT_QTY ");
                    sbQuery.Append(" ,W.FNS_QTY ");
                    sbQuery.Append(" ,W.NG_QTY ");
                    sbQuery.Append(" ,W.WO_TYPE ");
                    sbQuery.Append(" ,W.JOB_PRIORITY ");
                    sbQuery.Append(" ,W.PRE_CAM ");
                    sbQuery.Append(" ,W.PRE_MAT ");
                    sbQuery.Append(" ,W.PRE_PGM ");
                    sbQuery.Append(" ,W.PRE_TOOL ");
                    sbQuery.Append(" ,W.PGM_TIME ");
                    sbQuery.Append(" ,W.O_WO_NO ");
                    sbQuery.Append(" ,W.SEQ ");
                    sbQuery.Append(" ,W.ACT_INPUT_TYPE ");
                    sbQuery.Append(" ,W.PLN_WORK_DATE ");
                    sbQuery.Append(" ,W.STD_PLN_START_TIME ");
                    sbQuery.Append(" ,W.STD_PLN_END_TIME ");
                    sbQuery.Append(" ,W.NG_ID ");
                    sbQuery.Append(" ,W.PUR_STAT ");
                    sbQuery.Append(" ,W.OS_VND ");
                    sbQuery.Append(" ,W.REG_DATE ");
                    sbQuery.Append(" ,W.REG_EMP ");
                    sbQuery.Append(" ,W.MDFY_DATE ");
                    sbQuery.Append(" ,W.MDFY_EMP ");
                    sbQuery.Append(" ,W.DEL_DATE ");
                    sbQuery.Append(" ,W.DEL_EMP ");
                    sbQuery.Append(" ,W.DATA_FLAG ");
                    sbQuery.Append(" ,W.WP_NO ");
                    sbQuery.Append(" ,W.IS_LAST ");
                    sbQuery.Append(" ,W.PROC_SEQ ");
                    sbQuery.Append(" ,W.IS_OS ");
                    sbQuery.Append(" ,W.PLN_STD_TIME ");
                    sbQuery.Append(" ,W.IS_SAVE_EACH_ROW ");
                    sbQuery.Append(" ,W.IS_VALIDATE ");
                    sbQuery.Append(" ,W.IS_SAMPLING ");
                    sbQuery.Append(" ,W.SAMPLING_QTY ");
                    sbQuery.Append(" ,W.INS_FLAG ");
                    sbQuery.Append(" ,W.ACT_EMP_CODE ");
                    sbQuery.Append(" ,W.ACT_MC_CODE ");
                    sbQuery.Append(" ,W.IS_FIX ");
                    sbQuery.Append(" ,W.IS_YPGO ");
                    sbQuery.Append(" ,W.IS_MILLING ");
                    sbQuery.Append(" ,W.CAM_EMP ");
                    sbQuery.Append(" ,W.CAM_DATE ");
                    sbQuery.Append(" ,W.CAM_EMP_DATE ");
                    sbQuery.Append(" ,W.INS_DATE ");
                    sbQuery.Append(" ,W.INS_QTY ");
                    sbQuery.Append(" FROM TSHP_WORKORDER W ");
                  
                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder();

                        sbWhere.Append(" WHERE W.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_CODE", "W.PROD_CODE = @PROD_CODE "));
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_CODE", "W.PART_CODE = @PART_CODE "));
                        //sbWhere.Append(UTIL.GetWhere(row, "@POP03A", "W.PROC_ID > (SELECT TOP 1 PROC_ID FROM TSHP_WORKORDER WHERE PROD_CODE = @PROD_CODE AND PART_CODE = @PART_CODE AND PROC_CODE = 'P-03') "));
                        sbWhere.Append(UTIL.GetWhere(row, "@RE_WO_NO", "W.RE_WO_NO = @RE_WO_NO "));
                        sbWhere.Append(UTIL.GetWhere(row, "@NON_RE_WO_NO", "W.RE_WO_NO IS NULL "));

                        sbWhere.Append(" ORDER BY W.WO_NO, W.PROC_ID");

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



        /// <summary>
        /// 금일 작업지시 조회 
        /// </summary>
        /// <param name="dtParam"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataTable TSHP_WORKORDER_QUERY30(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT W.PLT_CODE");
                    sbQuery.Append(" ,P.PROD_CODE ");
                    sbQuery.Append(" ,P.PROD_NAME ");
                    sbQuery.Append(" ,W.PART_CODE ");
                    sbQuery.Append(" ,S.PART_NAME ");
                    sbQuery.Append(" ,W.WO_FLAG ");
                    sbQuery.Append(" ,W.WO_NO");
                    sbQuery.Append(" ,W.PROC_CODE ");
                    sbQuery.Append(" ,PRC.PROC_NAME ");
                    sbQuery.Append(" ,W.JOB_PRIORITY ");
                    sbQuery.Append(" ,W.WORK_CODE ");
                    sbQuery.Append(" ,W.MC_GROUP ");
                    sbQuery.Append(" ,W.PART_QTY AS 'PLN_QTY' ");
                    sbQuery.Append(" ,dbo.fnCharToDate(W.PLN_START_TIME) AS PLN_START ");
                    sbQuery.Append(" ,dbo.fnCharToDate(W.PLN_END_TIME) AS PLN_END ");
                    sbQuery.Append(" ,W.CAUTION  ");
                    sbQuery.Append(" ,W.SCOMMENT  ");
                    sbQuery.Append(" FROM TSHP_WORKORDER W");
                    sbQuery.Append(" LEFT JOIN TORD_PRODUCT P");
                    sbQuery.Append(" ON W.PLT_CODE = P.PLT_CODE");
                    sbQuery.Append(" AND W.PROD_CODE = P.PROD_CODE");

                    sbQuery.Append(" LEFT JOIN LSE_STD_PART S");
                    sbQuery.Append(" ON W.PLT_CODE = S.PLT_CODE");
                    sbQuery.Append(" AND W.PART_CODE = S.PART_CODE");

                    sbQuery.Append(" LEFT JOIN LSE_STD_PROC PRC");
                    sbQuery.Append(" ON W.PLT_CODE = PRC.PLT_CODE");
                    sbQuery.Append(" AND W.PROC_CODE = PRC.PROC_CODE");

 
                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder();

                        sbWhere.Append(" WHERE W.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                        sbWhere.Append(UTIL.GetWhere(row, "@WO_FLAG", "W.WO_FLAG = @WO_FLAG "));
                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "W.DATA_FLAG = @DATA_FLAG "));
                        sbWhere.Append("AND LEFT(W.PLN_START_TIME,8) = CONVERT(varchar(8),getdate(),112) ");
                     
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

        public static DataTable TSHP_WORKORDER_QUERY31(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT");
                    sbQuery.Append(" W.PLT_CODE");
                    sbQuery.Append(" ,W.CHAIN_WO_NO");
                    sbQuery.Append(" ,P.PROD_PRIORITY");
                    sbQuery.Append(" ,W.PART_CODE");
                    sbQuery.Append(" ,SP.PART_NAME");
                    sbQuery.Append(" ,W.PROD_CODE");
                    sbQuery.Append(" ,P.PROD_NAME");
                    sbQuery.Append(" ,P.PROD_VERSION");
                    sbQuery.Append(" ,P.PROC_FLAG");
                    sbQuery.Append(" ,P.PROD_FLAG");
                    sbQuery.Append(" ,P.INS_YN");
                    sbQuery.Append(" ,P.SOCKET_YN");
                    sbQuery.Append(" ,P.PROD_CATEGORY");
                    sbQuery.Append(" ,P.BUSINESS_EMP");
                    sbQuery.Append(" ,P.CUSTOMER_EMP");
                    sbQuery.Append(" ,P.CUSTDESIGN_EMP");
                    sbQuery.Append(" ,P.ACTUATOR_YN");
                    sbQuery.Append(" ,P.CVND_CODE");
                    sbQuery.Append(" ,CV.VEN_NAME AS CVND_NAME");
                    sbQuery.Append(" ,P.TVND_CODE");
                    sbQuery.Append(" ,TV.BVEN_NAME AS TVND_NAME");
                    sbQuery.Append(" ,P.ORD_DATE");
                    sbQuery.Append(" ,P.DUE_DATE");
                    sbQuery.Append(" ,P.CHG_DUE_DATE");
                    sbQuery.Append(" ,P.DELIVERY_DATE");
                    sbQuery.Append(" ,P.PROBE_PIN");
                    sbQuery.Append(" ,P.PIN_TYPE");
                    sbQuery.Append(" ,P.PROD_TYPE");
                    sbQuery.Append(" ,P.PROD_QTY");
                    sbQuery.Append(" ,P.REMARK");
                    sbQuery.Append(" ,PT.SCOMMENT");
                    sbQuery.Append(" ,W.PT_ID");
                    sbQuery.Append(" ,W.RE_WO_NO");
                    sbQuery.Append(" ,ISNULL(W.RE_WO_NO, '99') AS RE_WO_KEY");
                    sbQuery.Append(" ,PT.PART_PUID");
                    sbQuery.Append(" ,SPT.PART_NAME AS PART_PUID_NAME");
                    sbQuery.Append(" ,AD.DRAW_EMP ");
                    sbQuery.Append(" ,PT.Material AS MAT_QLTY");

                    //sbQuery.Append(" ,CASE WHEN W.RE_WO_NO IS NULL THEN '0'");
                    //sbQuery.Append("   ELSE CASE WHEN W.IS_DES_CHANGE = 1 THEN '2' ELSE '1' END END AS IS_REWORK");

                    sbQuery.Append(" ,CASE WHEN W.RE_WO_NO IS NULL THEN '0'");
                    sbQuery.Append("   ELSE CASE WHEN W.IS_DES_CHANGE = 1 AND ISNULL(W.IS_REMCT, 0) = 0 AND ISNULL(W.IS_MODIFY, 0) = 0 THEN '2' ");
                    sbQuery.Append("             WHEN W.IS_DES_CHANGE = 1 AND ISNULL(W.IS_REMCT, 0) = 0 AND ISNULL(W.IS_MODIFY, 0) = 1 THEN '3'");
                    sbQuery.Append("             WHEN W.IS_DES_CHANGE = 1 AND ISNULL(W.IS_REMCT, 0) = 1 AND ISNULL(W.IS_MODIFY, 0) = 0 THEN '4'");
                    sbQuery.Append("             WHEN N.NG_TYPE = 'P' THEN '5' ELSE '6' END END AS IS_REWORK");

                    sbQuery.Append(" FROM TSHP_WORKORDER W");
                    sbQuery.Append(" LEFT JOIN TORD_PRODUCT P");
                    sbQuery.Append(" ON W.PLT_CODE = P.PLT_CODE");
                    sbQuery.Append(" AND W.PROD_CODE = P.PROD_CODE");
                    
                    sbQuery.Append(" LEFT JOIN LSE_STD_PART SP");
                    sbQuery.Append(" ON W.PLT_CODE = SP.PLT_CODE");
                    sbQuery.Append(" AND W.PART_CODE = SP.PART_CODE");
                    
                    sbQuery.Append(" LEFT JOIN TSTD_VENDOR CV");
                    sbQuery.Append(" ON P.PLT_CODE = CV.PLT_CODE");
                    sbQuery.Append(" AND P.CVND_CODE = CV.VEN_CODE");
                    
                    sbQuery.Append(" LEFT JOIN TSTD_BILL_VENDOR TV");
                    sbQuery.Append(" ON P.PLT_CODE = TV.PLT_CODE");
                    sbQuery.Append(" AND P.TVND_CODE = TV.BVEN_CODE");

                    sbQuery.Append(" LEFT JOIN LSE_STD_PROC PR");
                    sbQuery.Append(" ON W.PLT_CODE = PR.PLT_CODE");
                    sbQuery.Append(" AND W.PROC_CODE = PR.PROC_CODE");

                    sbQuery.Append(" LEFT JOIN TMAT_PARTLIST PT");
                    sbQuery.Append(" ON W.PLT_CODE = PT.PLT_CODE");
                    sbQuery.Append(" AND W.PT_ID = PT.PT_ID");

                    sbQuery.Append(" LEFT JOIN LSE_STD_PART SPT");
                    sbQuery.Append(" ON PT.PLT_CODE = SPT.PLT_CODE");
                    sbQuery.Append(" AND PT.PART_PUID = SPT.PART_CODE");

                    sbQuery.Append(" LEFT JOIN (");
                    sbQuery.Append(" SELECT WC.PLT_CODE, WC.PROD_CODE, WC.PT_ID FROM TSHP_WORKORDER WC");
                    sbQuery.Append(" LEFT JOIN LSE_STD_PROC PR");
                    sbQuery.Append(" ON WC.PLT_CODE = PR.PLT_CODE");
                    sbQuery.Append(" AND WC.PROC_CODE = PR.PROC_CODE");
                    sbQuery.Append(" WHERE PR.WO_TYPE = 'PRC' AND WC.DATA_FLAG = '0'");
                    sbQuery.Append(" GROUP BY WC.PLT_CODE, WC.PROD_CODE, WC.PT_ID");
                    sbQuery.Append(" ) PRC");
                    sbQuery.Append(" ON PRC.PLT_CODE = W.PLT_CODE");
                    sbQuery.Append(" AND PRC.PROD_CODE = W.PROD_CODE");
                    sbQuery.Append(" AND PRC.PT_ID = W.PT_ID");

                    sbQuery.Append(" LEFT JOIN (");
                    sbQuery.Append(" SELECT PLT_CODE, PROD_CODE, MAX(DRAW_EMP) AS DRAW_EMP FROM TMAT_PARTLIST");
                    sbQuery.Append(" WHERE ISNULL(O_PT_ID,'') = '' AND DATA_FLAG = '0' AND LEFT(PART_CODE,1) = 'A'");
                    sbQuery.Append(" GROUP BY PLT_CODE, PROD_CODE");
                    sbQuery.Append(" ) AD");
                    sbQuery.Append(" ON P.PLT_CODE = AD.PLT_CODE");
                    sbQuery.Append(" AND P.PROD_CODE = AD.PROD_CODE");

                    sbQuery.Append(" LEFT JOIN (");
                    sbQuery.Append(" SELECT W.PLT_CODE, W.PROD_CODE, W.PT_ID, COUNT(MA.ACTUAL_ID) AS ACTUAL_CNT FROM TSHP_WORKORDER W");
                    sbQuery.Append(" JOIN TSHP_ACTUAL_MILL MA ON MA.PLT_CODE = W.PLT_CODE AND MA.WO_NO = W.WO_NO WHERE W.DATA_FLAG = '0'");
                    sbQuery.Append(" GROUP BY W.PLT_CODE ,W.PROD_CODE, W.PT_ID");
                    sbQuery.Append(" ) MACT");
                    sbQuery.Append(" ON W.PLT_CODE = MACT.PLT_CODE");
                    sbQuery.Append(" AND W.PROD_CODE = MACT.PROD_CODE");
                    sbQuery.Append(" AND W.PT_ID = MACT.PT_ID");

                    sbQuery.Append(" LEFT JOIN TSHP_NG N");
                    sbQuery.Append(" ON W.PLT_CODE = N.PLT_CODE");
                    sbQuery.Append(" AND W.RE_WO_NO = N.RE_WO_NO");

                    //sbQuery.Append(" LEFT JOIN");
                    //sbQuery.Append(" (");
                    //sbQuery.Append(" SELECT PLT_CODE, PROD_CODE, PART_CODE, RE_WO_NO, PT_ID, IS_DES_CHANGE FROM TSHP_WORKORDER");
                    //sbQuery.Append(" WHERE DATA_FLAG = '0'");
                    //sbQuery.Append(" GROUP BY PLT_CODE, PROD_CODE, PART_CODE, RE_WO_NO, IS_DES_CHANGE, PT_ID");
                    //sbQuery.Append(" ) WPT");
                    //sbQuery.Append(" ON W.PLT_CODE = WPT.PLT_CODE");
                    //sbQuery.Append(" AND W.PROD_CODE = WPT.PROD_CODE");
                    //sbQuery.Append(" AND W.PART_CODE = WPT.PART_CODE");
                    //sbQuery.Append(" AND W.PT_ID = WPT.PT_ID");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder();

                        sbWhere.Append(" WHERE W.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                        sbWhere.Append(UTIL.GetWhere(row, "@S_ORD_DATE, @E_ORD_DATE", "(P.ORD_DATE BETWEEN @S_ORD_DATE AND @E_ORD_DATE)"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_DUE_DATE, @E_DUE_DATE", "(P.DUE_DATE BETWEEN @S_DUE_DATE AND @E_DUE_DATE)"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_DELIVERY_DATE, @E_DELIVERY_DATE", "(P.DELIVERY_DATE BETWEEN @S_DELIVERY_DATE AND @E_DELIVERY_DATE)"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_LIKE", "P.PROD_CODE LIKE '%' + @PROD_LIKE + '%' OR P.PROD_NAME LIKE '%' + @PROD_LIKE + '%'"));
                        sbWhere.Append(UTIL.GetWhere(row, "@CVND_LIKE", "P.CVND_CODE LIKE '%' + @CVND_LIKE + '%' OR CV.VEN_NAME LIKE '%' + @CVND_LIKE + '%'"));
                        sbWhere.Append(UTIL.GetWhere(row, "@BUSINESS_EMP", "P.BUSINESS_EMP = @BUSINESS_EMP"));
                        sbWhere.Append(UTIL.GetWhere(row, "@CHAIN_WO_NO", "W.CHAIN_WO_NO = @CHAIN_WO_NO"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PT_ID", "W.PT_ID = @PT_ID"));
                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "W.DATA_FLAG = @DATA_FLAG "));
                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "P.DATA_FLAG = @DATA_FLAG "));
                        sbWhere.Append(UTIL.GetWhere(row, "@PRC_ISNULL", "PRC.PT_ID IS NULL"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PRC_ISNOTNULL", "PRC.PT_ID IS NOT NULL"));
                        sbWhere.Append(UTIL.GetWhere(row, "@NOT_WO_NO", "W.WO_NO <> @NOT_WO_NO"));
                        sbWhere.Append(UTIL.GetWhere(row, "@NOT_PT_ID", "W.PT_ID <> @NOT_PT_ID"));

                        sbWhere.Append(UTIL.GetWhere(row, "@IS_MILL", "ISNULL(MACT.ACTUAL_CNT, 0) < 1 "));
                        //sbWhere.Append(" AND ISNULL(MACT.WO_FLAG,0) IN ('0','1') ");
                        sbWhere.Append(" AND (LEFT(W.PART_CODE, 1) = 'M' OR LEFT(W.PART_CODE, 1) = 'A') ");
                        //sbWhere.Append(" AND RE_WO_NO IS NULL ");

                        StringBuilder sbGroupBy = new StringBuilder();
                        sbGroupBy.Append(" GROUP BY W.PLT_CODE, W.CHAIN_WO_NO, P.PROD_PRIORITY, W.PART_CODE, SP.PART_NAME, W.PROD_CODE, P.PROD_NAME, P.PROD_VERSION, P.PROC_FLAG, P.PROD_FLAG,");
                        sbGroupBy.Append(" P.INS_YN, P.SOCKET_YN, P.PROD_CATEGORY, P.BUSINESS_EMP, P.CUSTOMER_EMP, P.CUSTDESIGN_EMP, P.ACTUATOR_YN, P.CVND_CODE, CV.VEN_NAME, P.TVND_CODE,");
                        sbGroupBy.Append(" TV.BVEN_NAME, P.ORD_DATE, P.DUE_DATE, P.CHG_DUE_DATE, P.DELIVERY_DATE, P.PROBE_PIN, P.PROD_TYPE, P.PROD_QTY, P.REMARK, PT.SCOMMENT,");
                        sbGroupBy.Append(" W.PT_ID, PT.PART_PUID, SPT.PART_NAME, P.PIN_TYPE, W.RE_WO_NO, AD.DRAW_EMP, PT.Material");

                        sbGroupBy.Append(" ,CASE WHEN W.RE_WO_NO IS NULL THEN '0'");
                        sbGroupBy.Append("   ELSE CASE WHEN W.IS_DES_CHANGE = 1 AND ISNULL(W.IS_REMCT, 0) = 0 AND ISNULL(W.IS_MODIFY, 0) = 0 THEN '2' ");
                        sbGroupBy.Append("             WHEN W.IS_DES_CHANGE = 1 AND ISNULL(W.IS_REMCT, 0) = 0 AND ISNULL(W.IS_MODIFY, 0) = 1 THEN '3'");
                        sbGroupBy.Append("             WHEN W.IS_DES_CHANGE = 1 AND ISNULL(W.IS_REMCT, 0) = 1 AND ISNULL(W.IS_MODIFY, 0) = 0 THEN '4'");
                        sbGroupBy.Append("             WHEN N.NG_TYPE = 'P' THEN '5' ELSE '6' END END ");

                        //sbGroupBy.Append(" ,CASE WHEN W.RE_WO_NO IS NULL THEN '0'");
                        //sbGroupBy.Append("   ELSE CASE WHEN W.IS_DES_CHANGE = 1 THEN '2' ELSE '1' END END");

                        sbGroupBy.Append(" ORDER BY W.PART_CODE");


                        DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString() + sbWhere.ToString() + sbGroupBy.ToString(), row).Copy();

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

        public static DataTable TSHP_WORKORDER_QUERY32(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT W.PLT_CODE");
                    sbQuery.Append(" ,W.PROD_CODE");
                    sbQuery.Append(" ,W.WO_NO");
                    sbQuery.Append(" ,W.PT_ID");
                    sbQuery.Append(" ,W.PART_CODE");
                    sbQuery.Append(" ,W.PROC_CODE ");
                    sbQuery.Append(" ,W.PART_QTY ");
                    sbQuery.Append(" ,W.PART_ID ");
                    sbQuery.Append(" ,W.MC_GROUP ");
                    sbQuery.Append(" ,W.WO_FLAG  ");
                    sbQuery.Append(" ,W.SEQ  ");
                    sbQuery.Append(" ,W.PROC_SEQ  ");
                    sbQuery.Append(" ,W.IS_OS");
                    sbQuery.Append(" ,W.JOB_PRIORITY  ");
                    sbQuery.Append(" ,W.WO_TYPE  ");
                    sbQuery.Append(" ,W.ACT_INPUT_TYPE  ");
                    sbQuery.Append(" ,W.CAM_EMP  ");
                    sbQuery.Append(" ,W.RE_WO_NO  "); 
                    sbQuery.Append(" FROM TSHP_WORKORDER W ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder();

                        sbWhere.Append(" WHERE W.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@PT_ID_IN", "W.PT_ID IN @PT_ID_IN", UTIL.SqlCondType.IN));
                        sbWhere.Append(UTIL.GetWhere(row, "@PT_ID", "W.PT_ID = @PT_ID"));
                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "W.DATA_FLAG = @DATA_FLAG"));
                        //sbWhere.Append(" AND RE_WO_NO IS NULL");
                        sbWhere.Append(" ORDER BY PROC_ID");

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

        public static DataTable TSHP_WORKORDER_QUERY32_2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT W.PLT_CODE");
                    sbQuery.Append(" ,W.PROD_CODE");
                    sbQuery.Append(" ,W.WO_NO");
                    sbQuery.Append(" ,W.PT_ID");
                    sbQuery.Append(" ,W.PART_CODE");
                    sbQuery.Append(" ,W.PROC_CODE ");
                    sbQuery.Append(" ,W.PART_QTY ");
                    sbQuery.Append(" ,W.PART_ID ");
                    sbQuery.Append(" ,W.MC_GROUP ");
                    sbQuery.Append(" ,W.WO_FLAG  ");
                    sbQuery.Append(" ,W.SEQ  ");
                    sbQuery.Append(" ,W.PROC_SEQ  ");
                    sbQuery.Append(" ,W.IS_OS");
                    sbQuery.Append(" ,W.JOB_PRIORITY  ");
                    sbQuery.Append(" ,W.WO_TYPE  ");
                    sbQuery.Append(" ,W.ACT_INPUT_TYPE  ");
                    sbQuery.Append(" ,W.CAM_EMP  ");
                    sbQuery.Append(" ,W.RE_WO_NO  ");
                    sbQuery.Append(" FROM TSHP_WORKORDER W ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder();

                        sbWhere.Append(" WHERE W.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@PT_ID_IN", "W.PT_ID IN @PT_ID_IN", UTIL.SqlCondType.IN));
                        sbWhere.Append(UTIL.GetWhere(row, "@PT_ID", "W.PT_ID = @PT_ID"));
                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "W.DATA_FLAG = @DATA_FLAG"));
                        sbWhere.Append(" AND RE_WO_NO IS NULL");
                        sbWhere.Append(" ORDER BY PROC_ID");

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

        public static DataTable TSHP_WORKORDER_QUERY33(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT");
                    sbQuery.Append(" W.PLT_CODE");
                    sbQuery.Append(" ,W.PROD_CODE");
                    sbQuery.Append(" ,W.WO_NO");
                    sbQuery.Append(" ,W.WO_FLAG");
                    sbQuery.Append(" ,W.ACT_START_TIME");
                    sbQuery.Append(" ,W.ACT_END_TIME");
                    sbQuery.Append(" ,ISNULL(W.ACT_QTY, 0) AS ACT_QTY");
                    sbQuery.Append(" FROM TSHP_WORKORDER W");
                    sbQuery.Append(" LEFT JOIN LSE_STD_PROC SP");
                    sbQuery.Append(" ON W.PLT_CODE = SP.PLT_CODE");
                    sbQuery.Append(" AND W.PROC_CODE = SP.PROC_CODE");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder();

                        sbWhere.Append(" WHERE W.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_CODE", "W.PROD_CODE = @PROD_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@WO_TYPE", "SP.WO_TYPE = @WO_TYPE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "W.DATA_FLAG = @DATA_FLAG"));

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

        public static DataTable TSHP_WORKORDER_QUERY34(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT TOP 1");
                    sbQuery.Append(" W.PLT_CODE");
                    sbQuery.Append(" ,W.PROD_CODE");
                    sbQuery.Append(" ,W.PART_CODE");
                    sbQuery.Append(" ,W.PT_ID");
                    sbQuery.Append(" ,W.PLN_START_TIME");
                    sbQuery.Append(" FROM TSHP_WORKORDER W");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder();

                        sbWhere.Append(" WHERE W.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_CODE", "W.PROD_CODE = @PROD_CODE"));
                        sbWhere.Append(" AND LEFT(PART_CODE, 1) = 'A'");
                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "W.DATA_FLAG = @DATA_FLAG"));
                        sbWhere.Append(" ORDER BY PLN_START_TIME");

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

        public static DataTable TSHP_WORKORDER_QUERY35(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT TOP 1");
                    sbQuery.Append(" W.PLT_CODE");
                    sbQuery.Append(" ,W.PROD_CODE");
                    sbQuery.Append(" ,W.PART_CODE");
                    sbQuery.Append(" ,W.PT_ID");
                    sbQuery.Append(" ,W.PLN_START_TIME");
                    sbQuery.Append(" ,W.PLN_END_TIME");
                    sbQuery.Append(" FROM TSHP_WORKORDER W");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder();

                        sbWhere.Append(" WHERE W.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@PT_ID", "W.PT_ID = @PT_ID"));

                        if (row["RE_WO_NO"].toStringEmpty() != "")
                        {
                            sbWhere.Append(UTIL.GetWhere(row, "@RE_WO_NO", "W.RE_WO_NO = @RE_WO_NO"));
                        }
                        else
                        {
                            sbWhere.Append(" AND RE_WO_NO IS NULL");
                        }

                        sbWhere.Append(" AND PROC_CODE = 'P-07'");

                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "W.DATA_FLAG = @DATA_FLAG"));

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

        public static DataTable TSHP_WORKORDER_QUERY36(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT W.PLT_CODE");
                    sbQuery.Append(" ,W.WP_NO");
                    sbQuery.Append(" ,W.CHAIN_WO_NO");
                    sbQuery.Append(" ,W.WO_NO");
                    sbQuery.Append(" ,CASE WHEN W.INS_DATE IS NOT NULL THEN '4' WHEN W.INS_QTY > '0' THEN '2' ELSE '1' END  AS INS_STATE");
                    sbQuery.Append(" ,S.PART_PRODTYPE");
                    sbQuery.Append(" ,TP.ITEM_CODE");
                    sbQuery.Append(" ,W.PROD_CODE");
                    sbQuery.Append(" ,TP.PROD_NAME");
                    sbQuery.Append(" ,W.PART_CODE");
                    sbQuery.Append(" ,S.PART_NAME");
                    sbQuery.Append(" ,S.STD_PT_NUM");
                    sbQuery.Append(" ,ISNULL(SP.IS_MAT, 0) IS_MAT");
                    sbQuery.Append(" ,S.MAT_SPEC");
                    sbQuery.Append(" ,S.MAT_SPEC1");
                    sbQuery.Append(" ,S.BAL_SPEC");
                    sbQuery.Append(" ,S.BAL_WEIGHT");
                    sbQuery.Append(" ,S.DRAW_NO");
                    sbQuery.Append(" ,W.PROC_CODE");
                    sbQuery.Append(" ,W.PROC_SEQ");
                    sbQuery.Append(" ,SP.PROC_NAME");
                    sbQuery.Append(" ,W.MC_CODE");
                    sbQuery.Append(" ,M.MC_NAME");
                    sbQuery.Append(" ,W.MC_GROUP");
                    sbQuery.Append(" ,W.EMP_CODE");
                    sbQuery.Append(" ,E.EMP_NAME");
                    sbQuery.Append(" ,TP.PROD_QTY");
                    sbQuery.Append(" ,W.PART_QTY AS PLN_QTY");
                    sbQuery.Append(" ,W.PART_QTY");
                    sbQuery.Append(" ,CASE WHEN ISNULL(BW.ACT_QTY,0) < ISNULL(W.INS_QTY,0) THEN 0 ELSE ISNULL(BW.ACT_QTY,0) - ISNULL(W.INS_QTY,0) END AS INS_QTY");
                    sbQuery.Append(" ,ISNULL(W.INS_QTY,0) AS OLD_INS_QTY");//검사완료수량
                    sbQuery.Append(" ,ISNULL(BW.ACT_QTY,0) AS ACT_QTY");//이전공정 완료 수량
                    sbQuery.Append(" ,W.WO_FLAG");
                    sbQuery.Append(" ,W.CAUTION");
                    sbQuery.Append(" ,W.JOB_PRIORITY");
                    sbQuery.Append(" ,W.WORK_CODE");
                    sbQuery.Append(" ,ISNULL(W.IS_OS,0) AS IS_OS");
                    sbQuery.Append(" ,SP.IS_MAT");
                    sbQuery.Append(" ,CA.EMP_CODE AS CAM_EMP");
                    sbQuery.Append(" ,W.CAM_EMP_DATE");
                    sbQuery.Append(" ,W.CAM_DATE");
                    sbQuery.Append(" ,MA.MAT_CODE");
                    sbQuery.Append(" ,MS.PART_NAME AS MAT_NAME ");
                    sbQuery.Append(" ,TP.PROD_VERSION");
                    sbQuery.Append(" ,TP.PROC_FLAG");
                    sbQuery.Append(" ,TP.PROD_FLAG");
                    sbQuery.Append(" ,TP.INS_YN");
                    sbQuery.Append(" ,TP.SOCKET_YN");
                    sbQuery.Append(" ,TP.PROD_TYPE");
                    sbQuery.Append(" ,TP.PROD_CATEGORY");
                    sbQuery.Append(" ,TP.BUSINESS_EMP");
                    sbQuery.Append(" ,TP.CUSTOMER_EMP");
                    sbQuery.Append(" ,TP.CUSTDESIGN_EMP");
                    sbQuery.Append(" ,TP.ACTUATOR_YN");
                    sbQuery.Append(" ,TP.CVND_CODE");
                    sbQuery.Append(" ,CVND.VEN_NAME AS CVND_NAME");
                    sbQuery.Append(" ,TP.TVND_CODE");
                    sbQuery.Append(" ,TVND.BVEN_NAME AS TVND_NAME");
                    sbQuery.Append(" ,TP.PROBE_PIN");
                    sbQuery.Append(" ,TP.PIN_TYPE");
                    sbQuery.Append(" ,TP.CURR_UNIT");
                    sbQuery.Append(" ,TP.ORD_DATE");
                    sbQuery.Append(" ,TP.INDUE_DATE");
                    sbQuery.Append(" ,TP.DUE_DATE");
                    sbQuery.Append(" ,TP.CHG_DUE_DATE");
                    sbQuery.Append(" ,TP.END_DATE");
                    sbQuery.Append(" ,TP.DELIVERY_DATE");
                    sbQuery.Append(" ,TP.PROD_QTY");
                    sbQuery.Append(" ,TP.LOAD_FLAG");
                    sbQuery.Append(" ,TP.LOCK_FLAG");
                    sbQuery.Append(" ,TP.LOCK_EMP");
                    sbQuery.Append(" ,TP.SHIP_FLAG");
                    sbQuery.Append(" ,TP.PROD_STATE");
                    sbQuery.Append(" ,TP.INOUT_FLAG");
                    sbQuery.Append(" ,TP.ORD_VAT");
                    sbQuery.Append(" ,TP.PROD_UC");
                    sbQuery.Append(" ,CA.ACT_START_TIME");
                    sbQuery.Append(" ,CA.ACT_END_TIME");
                    sbQuery.Append(" ,CA.ACT_TIME");
                    sbQuery.Append(" ,CA.X_VALUE");
                    sbQuery.Append(" ,CA.Y_VALUE");
                    sbQuery.Append(" ,CA.T_VALUE");
                    sbQuery.Append(" ,CA.SCOMMENT");
                    sbQuery.Append(" ,CA.MAT_CODE AS CAM_MAT_CODE");
                    sbQuery.Append(" ,BW.ACT_QTY");
                    sbQuery.Append(" ,W.PT_ID");
                    sbQuery.Append(" ,PT.SCOMMENT");
                    sbQuery.Append(" ,W.WORK_SCOMMENT");
                    //sbQuery.Append(" ,CASE WHEN W.RE_WO_NO IS NULL THEN '0' ELSE '1' END IS_REWORK  ");

                    sbQuery.Append(" ,CASE WHEN W.RE_WO_NO IS NULL THEN '0'");
                    sbQuery.Append("   ELSE CASE WHEN W.IS_DES_CHANGE = 1 AND ISNULL(W.IS_REMCT, 0) = 0 AND ISNULL(W.IS_MODIFY, 0) = 0 THEN '2' ");
                    sbQuery.Append("             WHEN W.IS_DES_CHANGE = 1 AND ISNULL(W.IS_REMCT, 0) = 0 AND ISNULL(W.IS_MODIFY, 0) = 1 THEN '3'");
                    sbQuery.Append("             WHEN W.IS_DES_CHANGE = 1 AND ISNULL(W.IS_REMCT, 0) = 1 AND ISNULL(W.IS_MODIFY, 0) = 0 THEN '4'");
                    sbQuery.Append("             WHEN N.NG_TYPE = 'P' THEN '5' ELSE '6' END END AS IS_REWORK");

                    sbQuery.Append(" FROM TSHP_WORKORDER W");
                    sbQuery.Append(" LEFT JOIN TORD_PRODUCT TP ON TP.PLT_CODE = W.PLT_CODE AND TP.PROD_CODE = W.PROD_CODE");
                    sbQuery.Append(" LEFT JOIN LSE_STD_PART S ON W.PLT_CODE = S.PLT_CODE AND  W.PART_CODE = S.PART_CODE");
                    sbQuery.Append(" LEFT JOIN LSE_STD_PROC SP ON W.PLT_CODE = SP.PLT_CODE AND W.PROC_CODE = SP.PROC_CODE");
                    sbQuery.Append(" LEFT JOIN LSE_MACHINE M ON W.PLT_CODE = M.PLT_CODE AND W.MC_CODE = M.MC_CODE");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE E ON W.PLT_CODE = E.PLT_CODE AND W.EMP_CODE = E.EMP_CODE");
                    sbQuery.Append(" LEFT JOIN TSHP_ACTUAL_CAM CA ON W.PLT_CODE = CA.PLT_CODE AND W.PT_ID = CA.PT_ID AND ISNULL(W.RE_WO_NO, '1') = ISNULL(CA.RE_WO_NO, '1')");
                    sbQuery.Append(" LEFT JOIN TSHP_ACTUAL_MILL MA ON W.PLT_CODE = MA.PLT_CODE AND W.PT_ID = MA.PT_ID AND ISNULL(W.RE_WO_NO, '1') = ISNULL(MA.RE_WO_NO, '1')");
                    sbQuery.Append(" LEFT JOIN LSE_STD_PART MS ON MA.PLT_CODE = MS.PLT_CODE AND  MA.MAT_CODE = MS.PART_CODE");
                    //이전 공정 작업지시의 실적
                    sbQuery.Append(" LEFT JOIN TSHP_WORKORDER BW ON W.PLT_CODE = BW.PLT_CODE AND W.PT_ID = BW.PT_ID AND (W.PROC_ID -1) = BW.PROC_ID AND ISNULL(W.RE_WO_NO, '1') = ISNULL(BW.RE_WO_NO, '1') AND BW.DATA_FLAG = '0'");

                    sbQuery.Append(" LEFT JOIN TSTD_VENDOR CVND");
                    sbQuery.Append(" ON TP.PLT_CODE = CVND.PLT_CODE");
                    sbQuery.Append(" AND TP.CVND_CODE = CVND.VEN_CODE");
                    sbQuery.Append(" LEFT JOIN TSTD_BILL_VENDOR TVND");
                    sbQuery.Append(" ON TP.PLT_CODE = TVND.PLT_CODE");
                    sbQuery.Append(" AND TP.TVND_CODE = TVND.BVEN_CODE");
                    sbQuery.Append(" LEFT JOIN TMAT_PARTLIST PT ");
                    sbQuery.Append(" ON W.PLT_CODE = PT.PLT_CODE");
                    sbQuery.Append(" AND W.PT_ID = PT.PT_ID");

                    sbQuery.Append(" LEFT JOIN TSHP_NG N");
                    sbQuery.Append(" ON W.PLT_CODE = N.PLT_CODE");
                    sbQuery.Append(" AND W.RE_WO_NO = N.RE_WO_NO");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder();

                        sbWhere.Append(" WHERE W.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                        //sbWhere.Append(UTIL.GetWhere(row, "@WO_NO", "W.WO_NO = @WO_NO"));
                        sbWhere.Append(UTIL.GetWhere(row, "@NOT_WO_NO", "W.WO_NO <> @NOT_WO_NO"));
                        //sbWhere.Append(UTIL.GetWhere(row, "@PART_CODE", "W.PART_CODE = @PART_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PROC_CODE", "W.PROC_CODE = @PROC_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "W.DATA_FLAG = @DATA_FLAG"));
                        sbWhere.Append(UTIL.GetWhere(row, "@CHAIN_WO_NO", "W.CHAIN_WO_NO = @CHAIN_WO_NO"));


                        DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString() + sbWhere.ToString(), row).Copy();

                        sourceTable.TableName = "RSLTDT";
                        dsResult.Merge(sourceTable, false, MissingSchemaAction.Add);
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
        /// 수주기준 작업 실적조회
        /// </summary>
        /// <param name="dtParam"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataTable TSHP_WORKORDER_QUERY37(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT AC.PLT_CODE");
                    sbQuery.Append(" ,AC.ACTUAL_ID");
                    sbQuery.Append(" ,AC.WO_NO");
                    sbQuery.Append(" ,AC.WORK_DATE ");
                    sbQuery.Append(" FROM TSHP_WORKORDER WO");
                    sbQuery.Append(" JOIN TSHP_ACTUAL AC");
                    sbQuery.Append(" ON WO.PLT_CODE = AC.PLT_CODE ");
                    sbQuery.Append(" AND WO.WO_NO = AC.WO_NO ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder();

                        sbWhere.Append(" WHERE AC.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_CODE", "WO.PROD_CODE = @PROD_CODE"));
                     
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

        public static DataTable TSHP_WORKORDER_QUERY38(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT W.PLT_CODE");
                    sbQuery.Append(" ,W.PT_ID");
                    sbQuery.Append(" ,W.WO_NO");
                    sbQuery.Append(" FROM TSHP_WORKORDER W");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder();

                        sbWhere.Append(" WHERE W.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                        sbWhere.Append(UTIL.GetWhere(row, "@CHAIN_WO_NO", "W.CHAIN_WO_NO = @CHAIN_WO_NO"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PROC_CODE", "W.PROC_CODE = @PROC_CODE"));

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


        public static DataTable TSHP_WORKORDER_QUERY39(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED");
                    sbQuery.Append(" SELECT * FROM");
                    sbQuery.Append(" (");
                    sbQuery.Append(" SELECT");
                    sbQuery.Append(" PLT_CODE");
                    sbQuery.Append(" ,PROD_FLAG");
                    sbQuery.Append(" ,PROD_FLAG_NAME");
                    sbQuery.Append(" ,CAM_EMP");
                    sbQuery.Append(" ,CAM_EMP_NAME");
                    sbQuery.Append(" ,WORK_LOC");
                    sbQuery.Append(" ,WORK_LOC_NAME");
                    sbQuery.Append(" ,ACT_END_MONTH");
                    sbQuery.Append(" ,SUM(PART_QTY) AS PART_CNT");
                    sbQuery.Append(" FROM");
                    sbQuery.Append(" (");
                    sbQuery.Append(" SELECT");
                    sbQuery.Append(" W.PLT_CODE");
                    sbQuery.Append(" ,P.PROD_FLAG");
                    sbQuery.Append(" ,C.CD_NAME AS PROD_FLAG_NAME");
                    sbQuery.Append(" ,W.CAM_EMP");
                    sbQuery.Append(" ,E.EMP_NAME AS CAM_EMP_NAME");
                    sbQuery.Append(" ,E.WORK_LOC");
                    sbQuery.Append(" ,C2.CD_NAME AS WORK_LOC_NAME");
                    sbQuery.Append(" ,LEFT(CONVERT(VARCHAR(8), W.ACT_END_TIME, 112), 6) AS ACT_END_MONTH");
                    sbQuery.Append(" ,COUNT(W.PART_CODE) AS PART_QTY");
                    sbQuery.Append(" FROM TSHP_WORKORDER W");
                    sbQuery.Append(" LEFT JOIN TORD_PRODUCT P");
                    sbQuery.Append(" ON W.PLT_CODE = P.PLT_CODE");
                    sbQuery.Append(" AND W.PROD_CODE = P.PROD_CODE");
                    sbQuery.Append(" LEFT JOIN TSTD_CODES C");
                    sbQuery.Append(" ON P.PLT_CODE = C.PLT_CODE");
                    sbQuery.Append(" AND P.PROD_FLAG = C.CD_CODE");
                    sbQuery.Append(" AND C.CAT_CODE = 'P006'");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE E");
                    sbQuery.Append(" ON W.PLT_CODE = E.PLT_CODE");
                    sbQuery.Append(" AND W.CAM_EMP = E.EMP_CODE");
                    sbQuery.Append(" LEFT JOIN TSTD_CODES C2");
                    sbQuery.Append(" ON E.PLT_CODE = C2.PLT_CODE");
                    sbQuery.Append(" AND E.WORK_LOC = C2.CD_CODE");
                    sbQuery.Append(" AND C2.CAT_CODE = 'E001'");
                    sbQuery.Append(" WHERE W.PROC_CODE = 'P-02'");
                    sbQuery.Append(" AND W.DATA_FLAG = '0' AND P.DATA_FLAG = '0'");
                    sbQuery.Append(" AND ISNULL(CAM_EMP,'') <> ''");
                    sbQuery.Append(" AND W.WO_FLAG = '4'");
                    sbQuery.Append(" AND W.ACT_END_TIME IS NOT NULL");
                    sbQuery.Append(" AND W.CHAIN_WO_NO IS NULL");
                    sbQuery.Append(" AND P.PROD_FLAG IN('NE', 'RE')");
                    sbQuery.Append(" AND LEFT(CONVERT(VARCHAR(8), W.ACT_END_TIME, 112),4) = @YEAR");
                    sbQuery.Append(" GROUP BY W.PLT_CODE");
                    sbQuery.Append(" ,P.PROD_FLAG");
                    sbQuery.Append(" ,C.CD_NAME");
                    sbQuery.Append(" ,W.CAM_EMP");
                    sbQuery.Append(" ,E.EMP_NAME");
                    sbQuery.Append(" ,E.WORK_LOC");
                    sbQuery.Append(" ,C2.CD_NAME");
                    sbQuery.Append(" ,LEFT(CONVERT(VARCHAR(8), W.ACT_END_TIME, 112), 6)");
                    sbQuery.Append(" UNION ALL");
                    sbQuery.Append(" SELECT W.PLT_CODE");
                    sbQuery.Append(" ,P.PROD_FLAG");
                    sbQuery.Append(" ,C.CD_NAME AS PROD_FLAG_NAME");
                    sbQuery.Append(" ,W.CAM_EMP");
                    sbQuery.Append(" ,E.EMP_NAME AS CAM_EMP_NAME");
                    sbQuery.Append(" ,E.WORK_LOC");
                    sbQuery.Append(" ,C2.CD_NAME AS WORK_LOC_NAME");
                    sbQuery.Append(" ,LEFT(CONVERT(VARCHAR(8), W.ACT_END_TIME, 112), 6) AS ACT_END_MONTH");
                    sbQuery.Append(" ,COUNT(W.PART_CODE) AS PART_QTY FROM");
                    sbQuery.Append(" (");
                    sbQuery.Append(" SELECT * FROM");
                    sbQuery.Append(" (");
                    sbQuery.Append(" SELECT");
                    sbQuery.Append(" PLT_CODE");
                    sbQuery.Append(" ,CHAIN_WO_NO");
                    sbQuery.Append(" ,PROD_CODE");
                    sbQuery.Append(" ,PART_CODE");
                    sbQuery.Append(" ,ACT_END_TIME");
                    sbQuery.Append(" ,CAM_EMP");
                    sbQuery.Append(" ,ROW_NUMBER() OVER(PARTITION BY  CHAIN_WO_NO ORDER BY PROD_CODE DESC) AS SEQ");
                    sbQuery.Append(" FROM TSHP_WORKORDER");
                    sbQuery.Append(" WHERE CHAIN_WO_NO IS NOT NULL");
                    sbQuery.Append(" AND PROC_CODE = 'P-02'");
                    sbQuery.Append(" AND DATA_FLAG = '0'");
                    sbQuery.Append(" AND ISNULL(CAM_EMP,'') <> ''");
                    sbQuery.Append(" AND WO_FLAG = '4'");
                    sbQuery.Append(" AND ACT_END_TIME IS NOT NULL");
                    sbQuery.Append(" ) A");
                    sbQuery.Append(" WHERE SEQ = 1");
                    sbQuery.Append(" ) W");
                    sbQuery.Append(" LEFT JOIN TORD_PRODUCT P");
                    sbQuery.Append(" ON W.PLT_CODE = P.PLT_CODE");
                    sbQuery.Append(" AND W.PROD_CODE = P.PROD_CODE");
                    sbQuery.Append(" LEFT JOIN TSTD_CODES C");
                    sbQuery.Append(" ON P.PLT_CODE = C.PLT_CODE");
                    sbQuery.Append(" AND P.PROD_FLAG = C.CD_CODE");
                    sbQuery.Append(" AND C.CAT_CODE = 'P006'");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE E");
                    sbQuery.Append(" ON W.PLT_CODE = E.PLT_CODE");
                    sbQuery.Append(" AND W.CAM_EMP = E.EMP_CODE");
                    sbQuery.Append(" LEFT JOIN TSTD_CODES C2");
                    sbQuery.Append(" ON E.PLT_CODE = C2.PLT_CODE");
                    sbQuery.Append(" AND E.WORK_LOC = C2.CD_CODE");
                    sbQuery.Append(" AND C2.CAT_CODE = 'E001'");
                    sbQuery.Append(" WHERE P.DATA_FLAG = '0'");
                    sbQuery.Append(" AND P.PROD_FLAG IN('NE', 'RE')");
                    sbQuery.Append(" AND LEFT(CONVERT(VARCHAR(8), W.ACT_END_TIME, 112),4) = @YEAR");
                    sbQuery.Append(" GROUP BY W.PLT_CODE");
                    sbQuery.Append(" ,P.PROD_FLAG");
                    sbQuery.Append(" ,C.CD_NAME");
                    sbQuery.Append(" ,W.CAM_EMP");
                    sbQuery.Append(" ,E.EMP_NAME");
                    sbQuery.Append(" ,E.WORK_LOC");
                    sbQuery.Append(" ,C2.CD_NAME");
                    sbQuery.Append(" ,LEFT(CONVERT(VARCHAR(8), W.ACT_END_TIME, 112), 6)");
                    sbQuery.Append(" ) A");
                    sbQuery.Append(" GROUP BY");
                    sbQuery.Append(" PLT_CODE");
                    sbQuery.Append(" ,PROD_FLAG");
                    sbQuery.Append(" ,PROD_FLAG_NAME");
                    sbQuery.Append(" ,CAM_EMP");
                    sbQuery.Append(" ,CAM_EMP_NAME");
                    sbQuery.Append(" ,WORK_LOC");
                    sbQuery.Append(" ,WORK_LOC_NAME");
                    sbQuery.Append(" ,ACT_END_MONTH");
                    sbQuery.Append(" ) C");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder();

                        sbWhere.Append(" WHERE C.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                        sbWhere.Append(UTIL.GetWhere(row, "@EMP_CODE", "C.CAM_EMP = @EMP_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@WORK_LOC", "C.WORK_LOC = @WORK_LOC"));

                        sbWhere.Append(" ORDER BY ACT_END_MONTH, PROD_FLAG, CAM_EMP"); 

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

        public static DataTable TSHP_WORKORDER_QUERY40(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED");
                    sbQuery.Append(" SELECT");
                    sbQuery.Append(" A.PLT_CODE");
                    sbQuery.Append(" ,A.CVND_CODE");
                    sbQuery.Append(" ,V.VEN_NAME AS CVND_NAME");
                    sbQuery.Append(" ,A.ORD_MONTH");
                    sbQuery.Append(" ,SUM( CASE WHEN");
                    sbQuery.Append(" CASE WHEN  DATEDIFF(DAY, A.ACT_START_TIME, B.ACT_END_TIME) < 0 THEN DATEDIFF(DAY, CONVERT(DATETIME, SUBSTRING(A.PLN_START_TIME,1,4) + '-' + SUBSTRING(A.PLN_START_TIME,5,2) + '-' + SUBSTRING(A.PLN_START_TIME,7,2)), B.ACT_END_TIME)");
                    sbQuery.Append(" ELSE DATEDIFF(DAY, A.ACT_START_TIME, B.ACT_END_TIME) END = 0 THEN 1");
                    sbQuery.Append(" ELSE");
                    sbQuery.Append(" CASE WHEN  DATEDIFF(DAY, A.ACT_START_TIME, B.ACT_END_TIME) < 0 THEN DATEDIFF(DAY, CONVERT(DATETIME, SUBSTRING(A.PLN_START_TIME,1,4) + '-' + SUBSTRING(A.PLN_START_TIME,5,2) + '-' + SUBSTRING(A.PLN_START_TIME,7,2)), B.ACT_END_TIME)");
                    sbQuery.Append(" ELSE DATEDIFF(DAY, A.ACT_START_TIME, B.ACT_END_TIME) END");
                    sbQuery.Append(" END) AS LT");
                    sbQuery.Append(" ,COUNT(A.PROD_CODE) AS PROD_CNT");
                    sbQuery.Append(" ,SUM( CASE WHEN");
                    sbQuery.Append(" CASE WHEN  DATEDIFF(DAY, A.ACT_START_TIME, B.ACT_END_TIME) < 0 THEN DATEDIFF(DAY, CONVERT(DATETIME, SUBSTRING(A.PLN_START_TIME,1,4) + '-' + SUBSTRING(A.PLN_START_TIME,5,2) + '-' + SUBSTRING(A.PLN_START_TIME,7,2)), B.ACT_END_TIME)");
                    sbQuery.Append(" ELSE DATEDIFF(DAY, A.ACT_START_TIME, B.ACT_END_TIME) END = 0 THEN 1");
                    sbQuery.Append(" ELSE");
                    sbQuery.Append(" CASE WHEN  DATEDIFF(DAY, A.ACT_START_TIME, B.ACT_END_TIME) < 0 THEN DATEDIFF(DAY, CONVERT(DATETIME, SUBSTRING(A.PLN_START_TIME,1,4) + '-' + SUBSTRING(A.PLN_START_TIME,5,2) + '-' + SUBSTRING(A.PLN_START_TIME,7,2)), B.ACT_END_TIME)");
                    sbQuery.Append(" ELSE DATEDIFF(DAY, A.ACT_START_TIME, B.ACT_END_TIME) END");
                    sbQuery.Append(" END)");
                    sbQuery.Append(" / COUNT(A.PROD_CODE) AS LT_AVG");
                    sbQuery.Append(" FROM");
                    sbQuery.Append(" (");
                    sbQuery.Append(" SELECT");
                    sbQuery.Append(" W.PLT_CODE");
                    sbQuery.Append(" ,P.CVND_CODE");
                    sbQuery.Append(" ,W.PROD_CODE");
                    sbQuery.Append(" ,LEFT(P.ORD_DATE,6) AS ORD_MONTH");
                    sbQuery.Append(" ,W.PROC_CODE");
                    sbQuery.Append(" ,MIN(W.PLN_START_TIME) AS PLN_START_TIME");
                    sbQuery.Append(" ,MAX(W.PLN_END_TIME) AS PLN_END_TIME");
                    sbQuery.Append(" ,MIN(ISNULL(W.ACT_START_TIME, W.ACT_END_TIME)) AS ACT_START_TIME");
                    sbQuery.Append(" ,MAX(ISNULL(W.ACT_END_TIME, W.ACT_START_TIME)) AS ACT_END_TIME");
                    sbQuery.Append(" FROM TSHP_WORKORDER W WITH(NOLOCK)");
                    sbQuery.Append(" LEFT JOIN TORD_PRODUCT P WITH(NOLOCK)");
                    sbQuery.Append(" ON P.PLT_CODE = W.PLT_CODE");
                    sbQuery.Append(" AND P.PROD_CODE = W.PROD_CODE");
                    sbQuery.Append(" WHERE W.PROC_CODE = 'P-01'");
                    sbQuery.Append(" AND WO_FLAG = '4'");
                    sbQuery.Append(" AND W.DATA_FLAG = '0' AND P.DATA_FLAG = '0'");
                    sbQuery.Append(" AND LEFT(P.ORD_DATE, 4) = @YEAR");
                    sbQuery.Append(" GROUP BY");
                    sbQuery.Append(" W.PLT_CODE");
                    sbQuery.Append(" ,P.CVND_CODE");
                    sbQuery.Append(" ,W.PROD_CODE");
                    sbQuery.Append(" ,LEFT(P.ORD_DATE,6)");
                    sbQuery.Append(" ,W.PROC_CODE");
                    sbQuery.Append(" ) A");
                    sbQuery.Append(" JOIN");
                    sbQuery.Append(" (");
                    sbQuery.Append(" SELECT");
                    sbQuery.Append(" W.PLT_CODE");
                    sbQuery.Append(" ,P.CVND_CODE");
                    sbQuery.Append(" ,W.PROD_CODE");
                    sbQuery.Append(" ,LEFT(P.ORD_DATE,6) AS ORD_MONTH");
                    sbQuery.Append(" ,W.PROC_CODE");
                    sbQuery.Append(" ,MIN(W.PLN_START_TIME) AS PLN_START_TIME");
                    sbQuery.Append(" ,MAX(W.PLN_END_TIME) AS PLN_END_TIME");
                    sbQuery.Append(" ,MIN(ISNULL(W.ACT_START_TIME, W.ACT_END_TIME)) AS ACT_START_TIME");
                    sbQuery.Append(" ,MAX(ISNULL(W.ACT_END_TIME, W.ACT_START_TIME)) AS ACT_END_TIME");
                    sbQuery.Append(" FROM TSHP_WORKORDER W WITH(NOLOCK)");
                    sbQuery.Append(" LEFT JOIN TORD_PRODUCT P WITH(NOLOCK)");
                    sbQuery.Append(" ON P.PLT_CODE = W.PLT_CODE");
                    sbQuery.Append(" AND P.PROD_CODE = W.PROD_CODE");
                    sbQuery.Append(" WHERE W.PROC_CODE = 'P-12'");
                    sbQuery.Append(" AND WO_FLAG = '4'");
                    sbQuery.Append(" AND W.DATA_FLAG = '0' AND P.DATA_FLAG = '0'");
                    sbQuery.Append(" AND LEFT(P.ORD_DATE, 4) = @YEAR");
                    sbQuery.Append(" GROUP BY");
                    sbQuery.Append(" W.PLT_CODE");
                    sbQuery.Append(" ,P.CVND_CODE");
                    sbQuery.Append(" ,W.PROD_CODE");
                    sbQuery.Append(" ,LEFT(P.ORD_DATE,6)");
                    sbQuery.Append(" ,W.PROC_CODE");
                    sbQuery.Append(" )");
                    sbQuery.Append(" B");
                    sbQuery.Append(" ON A.PLT_CODE = B.PLT_CODE");
                    sbQuery.Append(" AND A.PROD_CODE = B.PROD_CODE");
                    sbQuery.Append(" LEFT JOIN TSTD_VENDOR V");
                    sbQuery.Append(" ON A.PLT_CODE = V.PLT_CODE");
                    sbQuery.Append(" AND A.CVND_CODE = V.VEN_CODE");
                    sbQuery.Append(" GROUP BY");
                    sbQuery.Append(" A.PLT_CODE");
                    sbQuery.Append(" ,A.CVND_CODE");
                    sbQuery.Append(" ,V.VEN_NAME");
                    sbQuery.Append(" ,A.ORD_MONTH");
                    sbQuery.Append(" ORDER BY A.ORD_MONTH DESC");



                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder();

                        //sbWhere.Append(" WHERE A.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

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

        public static DataTable TSHP_WORKORDER_QUERY41(DataTable dtParam, BizExecute.BizExecute bizExecute)
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
                    sbQuery.Append(" ,P.PROD_QTY");
                    sbQuery.Append(" ,P.PROD_FLAG");
                    sbQuery.Append(" ,P.PROD_TYPE");
                    sbQuery.Append(" ,C.CD_NAME AS PROD_TYPE_NAME");
                    sbQuery.Append(" ,CASE WHEN PROD_TYPE = '0' THEN A.SOCKET");
                    sbQuery.Append(" WHEN PROD_TYPE = '1' THEN A.PIN_BLOCK");
                    sbQuery.Append(" WHEN PROD_TYPE = '4' THEN A.PARTS");
                    sbQuery.Append(" WHEN PROD_TYPE = '6' THEN A.ACTUATOR");
                    sbQuery.Append(" END ST");
                    sbQuery.Append(" ,LEFT(CONVERT(VARCHAR(8), MAX(W.ACT_END_TIME), 112),6) AS END_TIME");
                    sbQuery.Append(" ,");
                    sbQuery.Append(" (SELECT COUNT(EMP_CODE) FROM TSTD_EMPLOYEE");
                    sbQuery.Append(" WHERE ORG_CODE = 'P008'");
                    sbQuery.Append(" AND DATA_FLAG = '0'");
                    sbQuery.Append(" AND ISNULL(EMP_TYPE,0) <> '5') AS EMP_COUNT");
                    sbQuery.Append(" ,CASE WHEN PROD_TYPE = '0' THEN A.SOCKET");
                    sbQuery.Append(" WHEN PROD_TYPE = '1' THEN A.PIN_BLOCK");
                    sbQuery.Append(" WHEN PROD_TYPE = '4' THEN A.PARTS");
                    sbQuery.Append(" WHEN PROD_TYPE = '6' THEN A.ACTUATOR");
                    sbQuery.Append(" END");
                    sbQuery.Append(" * P.PROD_QTY");
                    sbQuery.Append(" * CASE WHEN P.PROD_FLAG = 'NE' THEN 1.1 ELSE 1 END");
                    sbQuery.Append(" * 1");
                    sbQuery.Append(" /");
                    sbQuery.Append(" (SELECT COUNT(EMP_CODE) FROM TSTD_EMPLOYEE");
                    sbQuery.Append(" WHERE ORG_CODE = 'P008'");
                    sbQuery.Append(" AND DATA_FLAG = '0'");
                    sbQuery.Append(" AND ISNULL(EMP_TYPE,0) <> '5') AS LT");
                    sbQuery.Append(" FROM TSHP_WORKORDER W");
                    sbQuery.Append(" LEFT JOIN TORD_PRODUCT P");
                    sbQuery.Append(" ON W.PLT_CODE = P.PLT_CODE");
                    sbQuery.Append(" AND W.PROD_CODE = P.PROD_CODE");
                    sbQuery.Append(" LEFT JOIN TSTD_CODES C");
                    sbQuery.Append(" ON P.PLT_CODE = C.PLT_CODE");
                    sbQuery.Append(" AND P.PROD_TYPE = C.CD_CODE");
                    sbQuery.Append(" AND C.CAT_CODE = 'P010'");
                    sbQuery.Append(" LEFT JOIN TREP_ASSY_AT A");
                    sbQuery.Append(" ON P.PLT_CODE = A.PLT_CODE");
                    sbQuery.Append(" AND P.CVND_CODE = A.VEN_CODE");
                    sbQuery.Append(" WHERE W.PROC_CODE = 'P-06'");
                    sbQuery.Append(" AND W.DATA_FLAG = '0'");
                    sbQuery.Append(" AND W.WO_FLAG = '4'");
                    sbQuery.Append(" AND W.ACT_END_TIME IS NOT NULL");
                    sbQuery.Append(" AND P.DATA_FLAG = '0'");
                    sbQuery.Append(" AND P.PROD_FLAG IN('NE', 'RE')");
                    sbQuery.Append(" AND P.PROD_TYPE IN ('0','1','4','6')");
                    sbQuery.Append(" AND P.PROD_KIND = 'PD'");
                    sbQuery.Append(" GROUP BY W.PLT_CODE");
                    sbQuery.Append(" ,W.PROD_CODE");
                    sbQuery.Append(" ,P.PROD_QTY");
                    sbQuery.Append(" ,P.PROD_KIND");
                    sbQuery.Append(" ,P.PROD_FLAG");
                    sbQuery.Append(" ,P.PROD_TYPE");
                    sbQuery.Append(" ,C.CD_NAME");
                    sbQuery.Append(" ,CASE WHEN PROD_TYPE = '0' THEN A.SOCKET");
                    sbQuery.Append(" WHEN PROD_TYPE = '1' THEN A.PIN_BLOCK");
                    sbQuery.Append(" WHEN PROD_TYPE = '4' THEN A.PARTS");
                    sbQuery.Append(" WHEN PROD_TYPE = '6' THEN A.ACTUATOR");
                    sbQuery.Append(" END");
                    sbQuery.Append(" HAVING LEFT(CONVERT(VARCHAR(8), MAX(W.ACT_END_TIME), 112),4) = @YEAR");



                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder();

                        //sbWhere.Append(" WHERE A.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

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


        public static DataTable TSHP_WORKORDER_QUERY42(DataTable dtParam, BizExecute.BizExecute bizExecute)
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
                    sbQuery.Append(" ,LEFT(CONVERT(VARCHAR(8), W.ACT_END_TIME, 112), 6) AS ACT_MONTH");
                    sbQuery.Append(" , SUM(CASE WHEN DATEDIFF(HOUR, AW.END_TIME, W.ACT_END_TIME) <= 0 THEN 1.0");
                    sbQuery.Append(" ELSE DATEDIFF(HOUR, AW.END_TIME, W.ACT_END_TIME) END) / 24.0 / COUNT(W.PROD_CODE)  AS LT");
                    sbQuery.Append(" FROM TSHP_WORKORDER W");
                    sbQuery.Append(" LEFT JOIN TORD_PRODUCT P");
                    sbQuery.Append(" ON W.PLT_CODE = P.PLT_CODE");
                    sbQuery.Append(" AND W.PROD_CODE = P.PROD_CODE");
                    sbQuery.Append(" LEFT JOIN");
                    sbQuery.Append(" (");
                    sbQuery.Append(" SELECT");
                    sbQuery.Append(" W.PLT_CODE");
                    sbQuery.Append(" ,W.PROD_CODE");
                    sbQuery.Append(" ,MAX(W.ACT_END_TIME) AS END_TIME");
                    sbQuery.Append(" FROM TSHP_WORKORDER W");
                    sbQuery.Append(" LEFT JOIN TORD_PRODUCT P");
                    sbQuery.Append(" ON W.PLT_CODE = P.PLT_CODE");
                    sbQuery.Append(" AND W.PROD_CODE = P.PROD_CODE");
                    sbQuery.Append(" WHERE W.PROC_CODE = 'P-06'");
                    sbQuery.Append(" AND W.DATA_FLAG = '0'");
                    sbQuery.Append(" AND W.WO_FLAG = '4'");
                    sbQuery.Append(" AND W.ACT_END_TIME IS NOT NULL");
                    sbQuery.Append(" AND P.DATA_FLAG = '0'");
                    sbQuery.Append(" AND P.PROD_FLAG IN('NE', 'RE')");
                    sbQuery.Append(" AND P.PROD_TYPE IN ('0','1','4','6')");
                    sbQuery.Append(" GROUP BY W.PLT_CODE");
                    sbQuery.Append(" ,W.PROD_CODE");
                    sbQuery.Append(" ) AW");
                    sbQuery.Append(" ON W.PLT_CODE = AW.PLT_CODE");
                    sbQuery.Append(" AND W.PROD_CODE = AW.PROD_CODE");
                    sbQuery.Append(" WHERE W.PROC_CODE = 'P-09'");
                    sbQuery.Append(" AND W.DATA_FLAG = '0'");
                    sbQuery.Append(" AND W.WO_FLAG = '4'");
                    sbQuery.Append(" AND W.ACT_END_TIME IS NOT NULL");
                    sbQuery.Append(" AND P.DATA_FLAG = '0'");
                    sbQuery.Append(" AND P.PROD_FLAG IN('NE', 'RE')");
                    sbQuery.Append(" AND P.PROD_TYPE IN ('0','1','4','6')");
                    sbQuery.Append(" AND P.PROD_KIND = 'PD'");
                    sbQuery.Append(" AND AW.END_TIME IS NOT NULL");
                    sbQuery.Append(" AND LEFT(CONVERT(VARCHAR(8), W.ACT_END_TIME, 112),4) = @YEAR");
                    sbQuery.Append(" GROUP BY W.PLT_CODE");
                    sbQuery.Append(" ,LEFT(CONVERT(VARCHAR(8), W.ACT_END_TIME, 112),6)");
                    sbQuery.Append(" ORDER BY LEFT(CONVERT(VARCHAR(8), W.ACT_END_TIME, 112),6)");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder();

                        //sbWhere.Append(" WHERE A.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

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

        public static DataTable TSHP_WORKORDER_QUERY43(DataTable dtParam, BizExecute.BizExecute bizExecute)
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
                    sbQuery.Append(" ,LEFT(CONVERT(VARCHAR(8), W.ACT_END_TIME, 112),6) AS END_MONTH");
                    sbQuery.Append(" ,SUM(ISNULL(W.PART_QTY, 0)) AS PART_QTY");
                    sbQuery.Append(" ,SUM(ISNULL(W.ACT_QTY, 0)) AS ACT_QTY");
                    sbQuery.Append(" FROM TSHP_WORKORDER W");
                    sbQuery.Append(" WHERE W.PROC_CODE = 'P-06'");
                    sbQuery.Append(" AND W.WO_FLAG = '4'");
                    sbQuery.Append(" AND W.ACT_END_TIME IS NOT NULL");
                    sbQuery.Append(" AND W.DATA_FLAG = '0'");
                    sbQuery.Append(" AND LEFT(CONVERT(VARCHAR(8), W.ACT_END_TIME, 112),4) = @YEAR");
                    sbQuery.Append(" GROUP BY");
                    sbQuery.Append(" W.PLT_CODE");
                    sbQuery.Append(" ,LEFT(CONVERT(VARCHAR(8), W.ACT_END_TIME, 112),6)");
                    sbQuery.Append(" ORDER BY LEFT(CONVERT(VARCHAR(8), W.ACT_END_TIME, 112),6)");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder();

                        //sbWhere.Append(" WHERE A.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

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

        public static DataTable TSHP_WORKORDER_QUERY44(DataTable dtParam, BizExecute.BizExecute bizExecute)
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
                    sbQuery.Append(" ,LEFT(CONVERT(VARCHAR(8), W.ACT_END_TIME, 112),6) AS END_MONTH");
                    sbQuery.Append(" ,SUM(ISNULL(W.PART_QTY, 0)) AS PART_QTY");
                    sbQuery.Append(" ,CASE WHEN W.RE_WO_NO IS NULL THEN '0'");
                    sbQuery.Append(" ELSE CASE WHEN W.IS_DES_CHANGE = 1 AND ISNULL(W.IS_REMCT, 0) = 0 AND ISNULL(W.IS_MODIFY, 0) = 0 THEN '2'");
                    sbQuery.Append(" WHEN W.IS_DES_CHANGE = 1 AND ISNULL(W.IS_REMCT, 0) = 0 AND ISNULL(W.IS_MODIFY, 0) = 1 THEN '3'");
                    sbQuery.Append(" WHEN W.IS_DES_CHANGE = 1 AND ISNULL(W.IS_REMCT, 0) = 1 AND ISNULL(W.IS_MODIFY, 0) = 0 THEN '4'");
                    sbQuery.Append(" WHEN N.NG_TYPE = 'P' THEN '5' ELSE '6' END END AS IS_REWORK");
                    sbQuery.Append(" FROM TSHP_WORKORDER W");
                    sbQuery.Append(" LEFT JOIN TSHP_NG N");
                    sbQuery.Append(" ON W.PLT_CODE = N.PLT_CODE");
                    sbQuery.Append(" AND W.RE_WO_NO = N.RE_WO_NO");
                    sbQuery.Append(" WHERE W.PROC_CODE = 'P-06'");
                    sbQuery.Append(" AND W.WO_FLAG = '4'");
                    sbQuery.Append(" AND W.ACT_END_TIME IS NOT NULL");
                    sbQuery.Append(" AND W.RE_WO_NO IS NOT NULL");
                    sbQuery.Append(" AND W.DATA_FLAG = '0'");
                    sbQuery.Append(" AND LEFT(CONVERT(VARCHAR(8), W.ACT_END_TIME, 112),4) = @YEAR");

                    sbQuery.Append(" GROUP BY");
                    sbQuery.Append(" W.PLT_CODE");
                    sbQuery.Append(" ,LEFT(CONVERT(VARCHAR(8), W.ACT_END_TIME, 112),6)");
                    sbQuery.Append(" ,CASE WHEN W.RE_WO_NO IS NULL THEN '0'");
                    sbQuery.Append(" ELSE CASE WHEN W.IS_DES_CHANGE = 1 AND ISNULL(W.IS_REMCT, 0) = 0 AND ISNULL(W.IS_MODIFY, 0) = 0 THEN '2'");
                    sbQuery.Append(" WHEN W.IS_DES_CHANGE = 1 AND ISNULL(W.IS_REMCT, 0) = 0 AND ISNULL(W.IS_MODIFY, 0) = 1 THEN '3'");
                    sbQuery.Append(" WHEN W.IS_DES_CHANGE = 1 AND ISNULL(W.IS_REMCT, 0) = 1 AND ISNULL(W.IS_MODIFY, 0) = 0 THEN '4'");
                    sbQuery.Append(" WHEN N.NG_TYPE = 'P' THEN '5' ELSE '6' END END");
                    sbQuery.Append(" ORDER BY LEFT(CONVERT(VARCHAR(8), W.ACT_END_TIME, 112),6)");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder();

                        //sbWhere.Append(" WHERE A.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

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

        public static DataTable TSHP_WORKORDER_QUERY45(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED");
                    sbQuery.Append(" SELECT COUNT(PROD_CODE) AS PROD_CNT FROM");
                    sbQuery.Append(" (");
                    sbQuery.Append(" SELECT W.PLT_CODE, W.PROD_CODE FROM TSHP_WORKORDER W");
                    sbQuery.Append(" LEFT JOIN TORD_PRODUCT P");
                    sbQuery.Append(" ON W.PLT_CODE = P.PLT_CODE");
                    sbQuery.Append(" AND W.PROD_CODE = P.PROD_CODE");
                    sbQuery.Append(" WHERE W.WO_FLAG = '4' AND W.PROC_CODE = 'P-09' AND P.PROD_TYPE = '0'");
                    sbQuery.Append(" AND LEFT(CONVERT(VARCHAR(8), W.ACT_END_TIME, 112) ,6) = @S_MONTH");
                    sbQuery.Append(" GROUP BY W.PLT_CODE, W.PROD_CODE");
                    sbQuery.Append(" ) A");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder();

                        //sbWhere.Append(" WHERE A.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

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

        public static DataTable TSHP_WORKORDER_QUERY46(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED");
                    sbQuery.Append(" SELECT PLT_CODE");
                    sbQuery.Append(" , PROD_CODE");
                    sbQuery.Append(" , PART_CODE");
                    sbQuery.Append(" , IS_DES_CHANGE");
                    sbQuery.Append(" , IS_MODIFY");
                    sbQuery.Append(" , IS_REMCT");
                    sbQuery.Append(" , PART_QTY");
                    sbQuery.Append(" , CONVERT(VARCHAR(8), REG_DATE, 112) AS REG_DATE");
                    sbQuery.Append(" FROM TSHP_WORKORDER");



                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder();

                        sbWhere.Append(" WHERE PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                        sbWhere.Append(" AND IS_DES_CHANGE = '1'");
                        sbWhere.Append(" AND PROC_CODE = 'P-01'");
                        sbWhere.Append(" AND DATA_FLAG = '0'");
                        sbWhere.Append(" AND IS_REMCT IS NOT NULL");
                        sbWhere.Append(" AND IS_MODIFY IS NOT NULL");

                        sbWhere.Append(UTIL.GetWhere(row, "@YEAR", "LEFT(CONVERT(VARCHAR(8), REG_DATE, 112), 4) = @YEAR"));

                        sbWhere.Append(" ORDER BY REG_DATE DESC");

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

        public static DataTable TSHP_WORKORDER_QUERY47(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED");
                    sbQuery.Append(" SELECT COUNT(PLT_CODE) AS SIDE_CNT");
                    sbQuery.Append(" FROM TSHP_WORKORDER");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder();

                        sbWhere.Append(" WHERE PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                        sbWhere.Append(" AND PROC_CODE = 'P-07'");
                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_CODE", "PROD_CODE = @PROD_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PT_ID", "PT_ID = @PT_ID"));
                        sbWhere.Append(" AND DATA_FLAG = '0'");

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