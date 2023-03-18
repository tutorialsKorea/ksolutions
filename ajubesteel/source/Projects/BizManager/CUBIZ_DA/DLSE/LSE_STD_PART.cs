using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using BizExecute;

namespace DLSE
{
    public class LSE_STD_PART
    {
        public static DataTable LSE_STD_PART_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();
                        
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("  SELECT  ");
                    sbQuery.Append("  PLT_CODE ");
                    sbQuery.Append(" ,PART_CODE ");
                    sbQuery.Append(" ,PART_NAME ");
                    sbQuery.Append(" ,PART_ENAME ");
                    sbQuery.Append(" ,PART_SEQ ");
                    sbQuery.Append(" ,MAT_TYPE ");
                    sbQuery.Append(" ,PART_PRODTYPE ");
                    sbQuery.Append(" ,MAT_TYPE1 ");
                    sbQuery.Append(" ,MAT_TYPE2 ");
                    sbQuery.Append(" ,DRAW_NO ");
                    sbQuery.Append(" ,ATT_QTY ");
                    sbQuery.Append(" ,MAT_LTYPE ");
                    sbQuery.Append(" ,MAT_MTYPE ");
                    sbQuery.Append(" ,MAT_STYPE ");
                    sbQuery.Append(" ,MAT_UNIT ");
                    sbQuery.Append(" ,PACK_UNIT ");
                    sbQuery.Append(" ,UNIT_QTY ");
                    sbQuery.Append(" ,MAT_UC ");
                    sbQuery.Append(" ,MAT_COST ");
                    sbQuery.Append(" ,SPEC_TYPE ");
                    sbQuery.Append(" ,MAT_SPEC ");
                    sbQuery.Append(" ,MAT_SPEC1 ");
                    sbQuery.Append(" ,BAL_SPEC ");
                    sbQuery.Append(" ,MAT_QLTY ");
                    sbQuery.Append(" ,MAT_WEIGHT ");
                    sbQuery.Append(" ,MAT_WEIGHT1 ");
                    sbQuery.Append(" ,BAL_WEIGHT ");
                    sbQuery.Append(" ,MAIN_VND ");
                    sbQuery.Append(" ,SUPP_VND ");
                    sbQuery.Append(" ,STD_PT_NUM ");
                    sbQuery.Append(" ,REV_PART_CODE ");
                    sbQuery.Append(" ,LOAD_FLAG ");
                    sbQuery.Append(" ,STK_MNG ");
                    sbQuery.Append(" ,STK_LOCATION ");
                    sbQuery.Append(" ,SAFE_STK_QTY ");
                    sbQuery.Append(" ,STK_TURNING ");
                    sbQuery.Append(" ,STK_COMPLETE ");
                    sbQuery.Append(" ,STK_TOTAL ");
                    sbQuery.Append(" ,INS_FLAG ");
                    sbQuery.Append(" ,ACT_CODE ");
                    sbQuery.Append(" ,AUTO_CREATE ");
                    sbQuery.Append(" ,AUTO_MARGIN ");
                    sbQuery.Append(" ,AUTO_MARGIN_SPEC ");
                    sbQuery.Append(" ,IF_PART_CODE ");
                    sbQuery.Append(" ,FAC_PRICE ");
                    sbQuery.Append(" ,PROC_COST ");
                    sbQuery.Append(" ,MNG_COST ");
                    sbQuery.Append(" ,PROD_COST ");
                    sbQuery.Append(" ,PROFIT_PRICE ");
                    sbQuery.Append(" ,PROFIT_RATIO ");
                    sbQuery.Append(" ,JIG_CONTENTS ");
                    sbQuery.Append(" ,JIG_COST ");
                    sbQuery.Append(" ,ETC_CONTENTS ");
                    sbQuery.Append(" ,ETC_COST ");
                    sbQuery.Append(" ,SCOMMENT ");
                    sbQuery.Append(" ,REV_COMMENT ");
                    sbQuery.Append(" ,REG_DATE ");
                    sbQuery.Append(" ,REG_EMP ");
                    sbQuery.Append(" ,MDFY_DATE ");
                    sbQuery.Append(" ,MDFY_EMP ");
                    sbQuery.Append(" ,DEL_DATE ");
                    sbQuery.Append(" ,DEL_EMP ");
                    sbQuery.Append(" ,DEL_REASON ");
                    sbQuery.Append(" ,DATA_FLAG ");
                    sbQuery.Append(" ,OLD_SPEC1 ");
                    sbQuery.Append(" ,OLD_SPEC ");
                    sbQuery.Append(" ,OLD_BAL ");
                    sbQuery.Append(" ,ZIG_NO ");
                    sbQuery.Append(" ,IS_TOOL ");
                    sbQuery.Append(" ,IS_TURNING ");
                    sbQuery.Append(" ,STK_LOCATION_IMG ");
                    sbQuery.Append(" ,ASSY_FILE_NAME ");
                    sbQuery.Append(" ,ASSY_FILE_CONTENT ");
                    sbQuery.Append(" ,STK_LOCATION_DETAIL ");
                    sbQuery.Append(" ,CUTTING_CNT ");
                    sbQuery.Append(" ,Part_Rev_ID ");
                    sbQuery.Append(" ,Part_Puid ");
                    sbQuery.Append(" ,MAT_CODE ");
                    sbQuery.Append(" ,MakeSideHole ");
                    sbQuery.Append(" ,Tab_Machine ");
                    sbQuery.Append(" ,Slit_Division ");
                    sbQuery.Append(" ,AFTER_TREAT ");                    
                    sbQuery.Append(" ,MNG_FLAG ");
                    sbQuery.Append(" ,PART_CAT ");

                    sbQuery.Append(" ,MC_TIME ");
                    sbQuery.Append(" ,CAM_TIME ");
                    sbQuery.Append(" ,MIL_TIME ");
                    sbQuery.Append(" ,MID_INS_TIME ");
                    sbQuery.Append(" ,SHIP_INS_TIME ");
                    sbQuery.Append(" ,ASSEY_TIME ");
                    sbQuery.Append(" ,SLIT_TIME ");
                    sbQuery.Append(" ,SIDE_TIME ");
                    sbQuery.Append(" ,MSOP_TIME ");
                    sbQuery.Append(" ,ACT_ASSEY_TIME ");
                    sbQuery.Append("  FROM LSE_STD_PART  ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("  AND PART_CODE = @PART_CODE  ");



                    foreach (DataRow row in dtParam.Rows)
                    {
                        
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PART_CODE")) isHasColumn = false;

                        if (isHasColumn == true)
                        {                            

                            DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString(),row).Copy();
                                                        
                            sourceTable.TableName = "RSLTDT";
                            dsResult.Merge(sourceTable);                            
                        }
                    }
                }
                return UTIL.GetDsToDt(dsResult);
            }
            catch(Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }    
        }

        /// <summary>
        /// 보관 위치 이미지
        /// </summary>
        public static DataTable LSE_STD_PART_SER2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT PLT_CODE ");
                    sbQuery.Append(" , PART_CODE ");
                    sbQuery.Append(" , STK_LOCATION_IMG");
                    sbQuery.Append(" , DATA_FLAG ");
                    sbQuery.Append(" FROM LSE_STD_PART ");
                    sbQuery.Append(" WHERE PART_CODE = @PART_CODE");
                    sbQuery.Append(" AND PLT_CODE = @PLT_CODE");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PART_CODE")) isHasColumn = false;

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

        public static DataTable LSE_STD_PART_SER3(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("SELECT 									 ");
                    sbQuery.Append("	LSP.PLT_CODE						 ");
                    sbQuery.Append("	, LSP.PART_CODE						 ");
                    sbQuery.Append("  FROM LSE_STD_PART LSP					 ");
                    sbQuery.Append("	INNER JOIN TORD_PRODUCT TP			 ");
                    sbQuery.Append("		ON LSP.PLT_CODE = TP.PLT_CODE	 ");
                    sbQuery.Append("		AND LSP.PART_CODE = TP.PART_CODE ");
                    sbQuery.Append("		AND LSP.DATA_FLAG = TP.DATA_FLAG ");
                    sbQuery.Append("	INNER JOIN TORD_ITEM TI				 ");
                    sbQuery.Append("		ON TP.PLT_CODE = TI.PLT_CODE	 ");
                    sbQuery.Append("		AND TP.ITEM_CODE = TI.ITEM_CODE	 ");
                    sbQuery.Append("		AND TP.DATA_FLAG = TI.DATA_FLAG	 ");
                    sbQuery.Append(" WHERE TI.PLT_CODE = @PLT_CODE");
                    sbQuery.Append("   AND TI.CVND_CODE = @VEN_CODE");
                    sbQuery.Append("   AND TI.DATA_FLAG = 0");
                    sbQuery.Append("GROUP BY LSP.PLT_CODE, LSP.PART_CODE ");
                    
                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "VEN_CODE")) isHasColumn = false;

                        if (isHasColumn == true)
                        {

                            DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString(), row).Copy();

                            sourceTable.TableName = "RSLTDT_VEN";
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

        public static DataTable LSE_STD_PART_SER4(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT PLT_CODE ");
                    sbQuery.Append(" , ASSY_FILE_NAME ");
                    sbQuery.Append(" , ASSY_FILE_CONTENT");
                    sbQuery.Append(" FROM LSE_STD_PART ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND PART_CODE = @PART_CODE");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PART_CODE")) isHasColumn = false;

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

        public static DataTable LSE_STD_PART_SER5(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT PLT_CODE ");
                    sbQuery.Append(" , PART_CODE ");
                    sbQuery.Append(" , PART_NAME");
                    sbQuery.Append(" , MAT_LTYPE");
                    sbQuery.Append(" , MAT_MTYPE");
                    sbQuery.Append(" , MAT_STYPE");
                    sbQuery.Append(" FROM LSE_STD_PART ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND PART_NAME = @PART_NAME");
                    sbQuery.Append(" AND SUBSTRING(PART_CODE, 1,1) = @PART_CODE_SUBSTRING");
                    sbQuery.Append(" AND IS_MAIN_PART = '1'");
                    sbQuery.Append(" AND DATA_FLAG = '0'");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PART_NAME")) isHasColumn = false;

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

        public static void LSE_STD_PART_UPD(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" UPDATE LSE_STD_PART");
                    sbQuery.Append(" SET PART_NAME = @PART_NAME ");
                    sbQuery.Append(" , PART_ENAME = @PART_ENAME ");
                    sbQuery.Append(" , PART_SEQ = @PART_SEQ ");
                    sbQuery.Append(" , MAT_TYPE = @MAT_TYPE ");
                    sbQuery.Append(" , MAT_TYPE1 = @MAT_TYPE1 ");
                    sbQuery.Append(" , MAT_TYPE2 = @MAT_TYPE2 ");
                    sbQuery.Append(" , PART_PRODTYPE = @PART_PRODTYPE ");
                    sbQuery.Append(" , MAT_LTYPE = @MAT_LTYPE ");
                    sbQuery.Append(" , MAT_MTYPE = @MAT_MTYPE ");
                    sbQuery.Append(" , MAT_STYPE = @MAT_STYPE ");
                    sbQuery.Append(" , MAT_UNIT = @MAT_UNIT ");
                    sbQuery.Append(" , PACK_UNIT = @PACK_UNIT ");
                    sbQuery.Append(" , MAT_UC = @MAT_UC ");
                    sbQuery.Append(" , MAT_COST = @MAT_COST ");
                    sbQuery.Append(" , DRAW_NO = @DRAW_NO ");
                    sbQuery.Append(" , ZIG_NO = @ZIG_NO ");
                    sbQuery.Append(" , SPEC_TYPE = @SPEC_TYPE ");
                    sbQuery.Append(" , MAT_SPEC = @MAT_SPEC ");
                    sbQuery.Append(" , MAT_SPEC1 = @MAT_SPEC1 ");
                    sbQuery.Append(" , BAL_SPEC = @BAL_SPEC ");
                    sbQuery.Append(" , MAT_WEIGHT = @MAT_WEIGHT ");
                    sbQuery.Append(" , MAT_WEIGHT1 = @MAT_WEIGHT1 ");
                    sbQuery.Append(" , BAL_WEIGHT = @BAL_WEIGHT ");
                    sbQuery.Append(" , MAT_QLTY = @MAT_QLTY ");
                    sbQuery.Append(" , MAIN_VND = @MAIN_VND ");
                    sbQuery.Append(" , SUPP_VND = @SUPP_VND ");
                    sbQuery.Append(" , STD_PT_NUM = @STD_PT_NUM ");
                    sbQuery.Append(" , REV_PART_CODE = @REV_PART_CODE ");
                    sbQuery.Append(" , LOAD_FLAG = @LOAD_FLAG ");
                    sbQuery.Append(" , STK_MNG = @STK_MNG ");
                    sbQuery.Append(" , STK_LOCATION = @STK_LOCATION ");
                    sbQuery.Append(" , STK_LOCATION_DETAIL = @STK_LOCATION_DETAIL");
                    //sbQuery.Append(" , STK_LOCATION_IMG = @STK_LOCATION_IMG ");
                    sbQuery.Append(" , SAFE_STK_QTY = @SAFE_STK_QTY ");
                    sbQuery.Append(" , IS_TURNING = @IS_TURNING");
                    sbQuery.Append(" , INS_FLAG = @INS_FLAG ");
                    sbQuery.Append(" , ACT_CODE = @ACT_CODE ");
                    sbQuery.Append(" , AUTO_CREATE = @AUTO_CREATE ");
                    sbQuery.Append(" , AUTO_MARGIN = @AUTO_MARGIN ");
                    sbQuery.Append(" , AUTO_MARGIN_SPEC = @AUTO_MARGIN_SPEC ");
                    sbQuery.Append(" , IF_PART_CODE = @IF_PART_CODE ");

                    sbQuery.Append(" , FAC_PRICE = @FAC_PRICE ");
                    sbQuery.Append(" , PROC_COST = @PROC_COST ");
                    sbQuery.Append(" , MNG_COST = @MNG_COST ");
                    sbQuery.Append(" , PROD_COST = @PROD_COST ");
                    sbQuery.Append(" , PROFIT_PRICE = @PROFIT_PRICE ");
                    sbQuery.Append(" , PROFIT_RATIO = @PROFIT_RATIO ");

                    sbQuery.Append(" , PART_CAT = @PART_CAT ");

                    sbQuery.Append(" , JIG_CONTENTS = @JIG_CONTENTS ");
                    sbQuery.Append(" , JIG_COST = @JIG_COST ");
                    sbQuery.Append(" , ETC_CONTENTS = @ETC_CONTENTS ");
                    sbQuery.Append(" , ETC_COST = @ETC_COST ");
                    sbQuery.Append(" , CUTTING_CNT = @CUTTING_CNT ");
                    sbQuery.Append(" , SCOMMENT = @SCOMMENT ");
                    sbQuery.Append(" , REV_COMMENT = @REV_COMMENT ");
                    sbQuery.Append(" , MNG_FLAG = @MNG_FLAG ");
                    sbQuery.Append(" , BALJU_QTY = @BALJU_QTY ");
                    sbQuery.Append(" , IS_MAIN_PART = @IS_MAIN_PART ");
                    sbQuery.Append(" , IS_MAIN_SEARCH = @IS_MAIN_SEARCH ");

                    sbQuery.Append(" , PROC_COST2 = @PROC_COST2 ");
                    sbQuery.Append(" , MAIN_VND2 = @MAIN_VND2 ");

                    sbQuery.Append(" , CAM_TIME = @CAM_TIME ");
                    sbQuery.Append(" , MIL_TIME = @MIL_TIME ");
                    sbQuery.Append(" , MC_TIME = @MC_TIME ");
                    sbQuery.Append(" , MID_INS_TIME = @MID_INS_TIME ");
                    sbQuery.Append(" , ASSEY_TIME = @ASSEY_TIME ");
                    sbQuery.Append(" , SHIP_INS_TIME = @SHIP_INS_TIME ");

                    sbQuery.Append(" , MDFY_DATE = GETDATE() ");
                    sbQuery.Append(" , MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" , DATA_FLAG = 0 ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append(" AND PART_CODE = @PART_CODE ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;


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


        public static void LSE_STD_PART_UPD7(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" UPDATE LSE_STD_PART");
                    sbQuery.Append(" SET PROC_COST = @PROC_COST ");
                    sbQuery.Append("   , MNG_COST = (ISNULL(MAT_COST, 0) + @PROC_COST) * 0.15 ");
                    sbQuery.Append("   , PROD_COST = ISNULL(MAT_COST, 0) + @PROC_COST + (ISNULL(MAT_COST, 0) + @PROC_COST) * 0.15 ");
                    sbQuery.Append("   , PROFIT_PRICE = CASE WHEN ISNULL(FAC_PRICE, 0) > 0 THEN ISNULL(FAC_PRICE, 0) - (ISNULL(MAT_COST, 0) + @PROC_COST + (ISNULL(MAT_COST, 0) + @PROC_COST) * 0.15 ) ELSE 0 END  ");
                    sbQuery.Append("   , PROFIT_RATIO = ");
                    sbQuery.Append("      CASE WHEN ISNULL(FAC_PRICE, 0) > 0    ");
                    sbQuery.Append("         THEN (ISNULL(FAC_PRICE, 0) - (ISNULL(MAT_COST, 0) + @PROC_COST + (ISNULL(MAT_COST, 0) + @PROC_COST) * 0.15 )) / ISNULL(FAC_PRICE, 0) * 100 ELSE 0 END  ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append(" AND PART_CODE = @PART_CODE ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;


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

        public static void LSE_STD_PART_UPD8(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE LSE_STD_PART        ");
                    sbQuery.Append(" SET ATT_QTY = F.QTY        ");
                    sbQuery.Append(" FROM LSE_STD_PART P JOIN ( ");
                    sbQuery.Append(" 	SELECT PLT_CODE, LINK_KEY, COUNT(*) QTY     ");
                    sbQuery.Append(" 	FROM TSYS_FILELIST_MASTER   ");
                    sbQuery.Append(" 	WHERE DATA_FLAG = 0         ");
                    sbQuery.Append(" 	GROUP BY PLT_CODE, LINK_KEY ");
                    sbQuery.Append(" 	) F                         ");
                    sbQuery.Append(" ON P.PLT_CODE = F.PLT_CODE     ");
                    sbQuery.Append(" AND P.PART_CODE = F.LINK_KEY   ");
                    sbQuery.Append(" WHERE P.PLT_CODE = @PLT_CODE   ");
                    sbQuery.Append("   AND P.PART_CODE = @PART_CODE ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;


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


        /// <summary>
        /// 재질별 적용 중 단가로 일괄 업데이트
        /// </summary>
        /// <param name="dtParam"></param>
        /// <param name="bizExecute"></param>
        public static void LSE_STD_PART_UPD9(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE LSE_STD_PART        ");
                    sbQuery.Append(" SET MAT_UC = @MAT_UC       ");
                    sbQuery.Append("   , MAT_COST = ISNULL(BAL_WEIGHT, 1) * @MAT_UC       ");
                    sbQuery.Append("   , MDFY_DATE = GETDATE() ");
                    sbQuery.Append("   , MDFY_EMP = 'SYS(QLTY)'");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE   ");
                    sbQuery.Append("   AND MAT_QLTY = @MQLTY_CODE   ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "MQLTY_CODE")) isHasColumn = false;

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
        /// 재고 조정(완재고)
        /// </summary>
        /// <param name="dtParam"></param>
        /// <param name="bizExecute"></param>
        public static void LSE_STD_PART_UPD10(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE LSE_STD_PART        ");
                    sbQuery.Append(" SET STK_COMPLETE = @STK_QTY  ");
                    sbQuery.Append("   , STK_TOTAL = @STK_QTY  ");
                    sbQuery.Append("   , MDFY_DATE = GETDATE() ");
                    sbQuery.Append("   , MDFY_EMP = 'SYS(STOCK)'");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE   ");
                    sbQuery.Append("   AND PART_CODE = @PART_CODE   ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;

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


        /// <summary>
        /// 재고 조정(선삭재고)
        /// </summary>
        /// <param name="dtParam"></param>
        /// <param name="bizExecute"></param>
        public static void LSE_STD_PART_UPD11(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE LSE_STD_PART        ");
                    sbQuery.Append(" SET STK_TURNING = @STK_QTY  ");
                    sbQuery.Append("   , STK_TOTAL = @STK_QTY  ");
                    sbQuery.Append("   , MDFY_DATE = GETDATE() ");
                    sbQuery.Append("   , MDFY_EMP = 'SYS(STOCK)'");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE   ");
                    sbQuery.Append("   AND PART_CODE = @PART_CODE   ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;

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

        public static void LSE_STD_PART_UPD12(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE LSE_STD_PART        ");
                    foreach(DataColumn dc in dtParam.Columns)
                    {
                        if (dc.ColumnName.Equals("PLT_CODE") || dc.ColumnName.Equals("PART_CODE"))
                            continue;

                        sbQuery.Append(" SET " + dc.ColumnName + " = @" + dc.ColumnName + "  ");
                    }
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE   ");
                    sbQuery.Append("   AND PART_CODE = @PART_CODE   ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;

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

        public static void LSE_STD_PART_UPD13(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" UPDATE LSE_STD_PART");
                    sbQuery.Append(" SET ASSY_FILE_NAME = @ASSY_FILE_NAME");
                    sbQuery.Append(" , ASSY_FILE_CONTENT = @ASSY_FILE_CONTENT ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append(" AND PART_CODE = @PART_CODE ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;


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
        public static void LSE_STD_PART_UPD14(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" UPDATE LSE_STD_PART");
                    sbQuery.Append(" SET STK_LOCATION = @YPGO_LOC");
                    sbQuery.Append("    , STK_LOCATION_DETAIL = @YPGO_LOC_DETAIL");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append(" AND PART_CODE = @PART_CODE ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;


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

        public static void LSE_STD_PART_UPD15(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE PART											 ");
                    sbQuery.Append(" 	SET PART.STK_COMPLETE = PART.STK_COMPLETE - TW.T_QTY ");
                    sbQuery.Append("   FROM TORD_PRODUCT TP									 ");
                    sbQuery.Append(" 	INNER JOIN LSE_STD_PART PART						 ");
                    sbQuery.Append(" 		ON TP.PLT_CODE = PART.PLT_CODE					 ");
                    sbQuery.Append(" 		AND TP.PART_CODE = PART.PART_CODE				 ");
                    sbQuery.Append(" 		AND PART.DATA_FLAG = 0							 ");
                    sbQuery.Append(" 	INNER JOIN TSHP_WORKPLAN TW							 ");
                    sbQuery.Append(" 		ON TP.PLT_CODE = TW.PLT_CODE					 ");
                    sbQuery.Append(" 		AND TP.PROD_CODE = TW.PROD_CODE					 ");
                    sbQuery.Append(" 		AND TP.PARENT_PART = TW.PART_CODE				 ");
                    sbQuery.Append("  WHERE TP.PLT_CODE = @PLT_CODE					 ");
                    sbQuery.Append(" 	AND TP.PROD_CODE = @PROD_CODE			 ");
                    sbQuery.Append(" 	AND TP.PARENT_PART = @PART_CODE			 ");
                    sbQuery.Append(" 	AND PART.IS_TURNING = 1								 ");

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



        public static void LSE_STD_PART_UPD16(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE LSE_STD_PART");
                    sbQuery.Append(" SET MAT_TYPE = @MAT_TYPE ");
                    sbQuery.Append(" , MAT_LTYPE = @MAT_LTYPE ");
                    sbQuery.Append(" , MAT_MTYPE = @MAT_MTYPE ");
                    sbQuery.Append(" , MAT_STYPE = @MAT_STYPE ");
                    sbQuery.Append(" , MAT_UNIT = @MAT_UNIT ");
                    sbQuery.Append(" , PACK_UNIT = @PACK_UNIT ");
                    sbQuery.Append(" , MAIN_VND = @MAIN_VND ");
                    sbQuery.Append(" , SUPP_VND = @SUPP_VND ");
                    sbQuery.Append(" , INS_FLAG = @INS_FLAG ");
                    sbQuery.Append(" , PART_CAT = @PART_CAT ");
                    sbQuery.Append(" , PROC_COST = @PROC_COST ");
                    sbQuery.Append(" , PROC_COST2 = @PROC_COST2 ");
                    sbQuery.Append(" , MAT_COST = @MAT_COST ");

                    sbQuery.Append(" , CAM_TIME = @CAM_TIME ");
                    sbQuery.Append(" , MIL_TIME = @MIL_TIME ");
                    sbQuery.Append(" , MC_TIME = @MC_TIME ");
                    sbQuery.Append(" , MID_INS_TIME = @MID_INS_TIME ");
                    sbQuery.Append(" , ASSEY_TIME = @ASSEY_TIME ");
                    sbQuery.Append(" , SHIP_INS_TIME = @SHIP_INS_TIME ");

                    sbQuery.Append(" , MNG_FLAG = @MNG_FLAG ");

                    sbQuery.Append(" , MDFY_DATE = GETDATE() ");
                    sbQuery.Append(" , MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" , DATA_FLAG = 0 ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append(" AND PART_CODE = @PART_CODE ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;


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


        public static void LSE_STD_PART_UPD17(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE LSE_STD_PART");
                    sbQuery.Append(" SET MAT_CODE = @MAT_CODE ");
                    sbQuery.Append(" , MDFY_DATE = GETDATE() ");
                    sbQuery.Append(" , MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" , DATA_FLAG = 0 ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append(" AND PART_CODE = @PART_CODE ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;


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

        public static void LSE_STD_PART_UPD18(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE LSE_STD_PART");
                    sbQuery.Append(" SET SAFE_STK_QTY = @SAFE_STK_QTY ");
                    //sbQuery.Append(" SET TAB_MACHINE = @TAB_MACHINE ");
                    //sbQuery.Append(" , MakeSideHole = @MakeSideHole ");
                    //sbQuery.Append(" , 도금 = @도금 ");
                    //sbQuery.Append(" , Slit_Division = @Slit_Division ");
                    //sbQuery.Append(" , SAFE_STK_QTY = @SAFE_STK_QTY ");
                    sbQuery.Append(" , MAT_QLTY = @MAT_QLTY ");
                    //sbQuery.Append(" , AFTER_TREAT = @AFTER_TREAT ");
                    sbQuery.Append(" , MAT_LTYPE = @MAT_LTYPE ");
                    sbQuery.Append(" , MDFY_DATE = GETDATE() ");
                    sbQuery.Append(" , MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" , DATA_FLAG = 0 ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append(" AND PART_CODE = @PART_CODE ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;


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

        public static void LSE_STD_PART_UPD19(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE LSE_STD_PART");
                    sbQuery.Append(" SET IS_MAIN_PART = @IS_MAIN_PART ");
                    sbQuery.Append(" , MDFY_DATE = GETDATE() ");
                    sbQuery.Append(" , MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" , DATA_FLAG = 0 ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append(" AND PART_CODE = @PART_CODE ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;


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

        public static void LSE_STD_PART_UPD20(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE LSE_STD_PART");
                    sbQuery.Append(" SET COST_DES_TIME = @COST_DES_TIME ");
                    sbQuery.Append(" , COST_CAM_TIME = @COST_CAM_TIME ");
                    sbQuery.Append(" , COST_MILL_TIME = @COST_MILL_TIME ");
                    sbQuery.Append(" , COST_SIDE_TIME = @COST_SIDE_TIME ");
                    sbQuery.Append(" , COST_INS_TIME = @COST_INS_TIME ");
                    sbQuery.Append(" , COST_ASSY_TIME = @COST_ASSY_TIME ");
                    sbQuery.Append(" , COST_SHIP_TIME = @COST_SHIP_TIME ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append(" AND PART_CODE = @PART_CODE ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;


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

        public static void LSE_STD_PART_UDE(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" UPDATE LSE_STD_PART ");
                    sbQuery.Append(" SET DEL_DATE = GETDATE()");
                    sbQuery.Append(" , DEL_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" , DEL_REASON = @DEL_REASON");
                    sbQuery.Append(" , DATA_FLAG = 2");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND PART_CODE = @PART_CODE");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PART_CODE")) isHasColumn = false;

                        if (isHasColumn == true)
                        {
                            bizExecute.executeUpdateQuery(sbQuery.ToString(),row);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }


        public static void LSE_STD_PART_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" INSERT INTO LSE_STD_PART");
                    sbQuery.Append("(");
                    sbQuery.Append(" PLT_CODE");
                    sbQuery.Append(" , PART_CODE ");
                    sbQuery.Append(" , PART_NAME ");
                    sbQuery.Append(" , PART_ENAME");
                    sbQuery.Append(" , PART_SEQ");
                    sbQuery.Append(" , MAT_TYPE");
                    sbQuery.Append(" , MAT_TYPE1");
                    sbQuery.Append(" , MAT_TYPE2");
                    sbQuery.Append(" , PART_PRODTYPE ");
                    sbQuery.Append(" , MAT_LTYPE ");
                    sbQuery.Append(" , MAT_MTYPE ");
                    sbQuery.Append(" , MAT_STYPE ");
                    sbQuery.Append(" , MAT_UNIT");
                    sbQuery.Append(" , PACK_UNIT");
                    sbQuery.Append(" , MAT_UC");
                    sbQuery.Append(" , MAT_COST");
                    sbQuery.Append(" , SPEC_TYPE ");
                    sbQuery.Append(" , MAT_SPEC");
                    sbQuery.Append(" , MAT_SPEC1 ");
                    sbQuery.Append(" , MAT_QLTY");
                    sbQuery.Append(" , MAIN_VND");
                    sbQuery.Append(" , SUPP_VND");
                    sbQuery.Append(" , STD_PT_NUM");
                    sbQuery.Append(" , REV_PART_CODE");
                    sbQuery.Append(" , LOAD_FLAG ");
                    sbQuery.Append(" , STK_MNG ");
                    sbQuery.Append(" , STK_LOCATION");
                    sbQuery.Append(" , STK_LOCATION_DETAIL"); 
                    //sbQuery.Append(" , STK_LOCATION_IMG");
                    sbQuery.Append(" , SAFE_STK_QTY");
                    sbQuery.Append(" , IS_TURNING");
                    sbQuery.Append(" , INS_FLAG");
                    sbQuery.Append(" , ACT_CODE");
                    sbQuery.Append(" , AUTO_CREATE ");
                    sbQuery.Append(" , AUTO_MARGIN ");
                    sbQuery.Append(" , AUTO_MARGIN_SPEC");
                    sbQuery.Append(" , IF_PART_CODE");

                    sbQuery.Append(" , FAC_PRICE");
                    sbQuery.Append(" , PROC_COST");
                    sbQuery.Append(" , MNG_COST");
                    sbQuery.Append(" , PROD_COST");
                    sbQuery.Append(" , PROFIT_PRICE");
                    sbQuery.Append(" , PROFIT_RATIO");

                    sbQuery.Append(" , PART_CAT ");

                    sbQuery.Append(" , JIG_CONTENTS");
                    sbQuery.Append(" , JIG_COST");
                    sbQuery.Append(" , ETC_CONTENTS");
                    sbQuery.Append(" , ETC_COST");
                    sbQuery.Append(" , CUTTING_CNT ");
                    sbQuery.Append(" , MNG_FLAG ");
                    sbQuery.Append(" , SCOMMENT");
                    sbQuery.Append(" , REV_COMMENT");
                    sbQuery.Append(" , REG_DATE");
                    sbQuery.Append(" , REG_EMP ");
                    sbQuery.Append(" , DATA_FLAG ");
                    sbQuery.Append(" , TAB_MACHINE ");
                    sbQuery.Append(" , MakeSideHole ");
                    sbQuery.Append(" , Slit_Division ");
                    sbQuery.Append(" , AFTER_TREAT ");
                    sbQuery.Append(" , BALJU_QTY ");
                    sbQuery.Append(" , IS_MAIN_PART ");
                    sbQuery.Append(" , IS_MAIN_SEARCH ");
                    sbQuery.Append(" , PROC_COST2 ");
                    sbQuery.Append(" , MAIN_VND2 ");
                    sbQuery.Append(" , CAM_TIME ");
                    sbQuery.Append(" , MIL_TIME ");
                    sbQuery.Append(" , MC_TIME ");
                    sbQuery.Append(" , MID_INS_TIME ");
                    sbQuery.Append(" , ASSEY_TIME ");
                    sbQuery.Append(" , SHIP_INS_TIME ");
                    sbQuery.Append(")");
                    sbQuery.Append(" VALUES");
                    sbQuery.Append("(");
                    sbQuery.Append(" @PLT_CODE ");
                    sbQuery.Append(" , @PART_CODE");
                    sbQuery.Append(" , @PART_NAME");
                    sbQuery.Append(" , @PART_ENAME ");
                    sbQuery.Append(" , @PART_SEQ ");
                    sbQuery.Append(" , @MAT_TYPE");
                    sbQuery.Append(" , @MAT_TYPE1");
                    sbQuery.Append(" , @MAT_TYPE2");
                    sbQuery.Append(" , @PART_PRODTYPE ");
                    sbQuery.Append(" , @MAT_LTYPE ");
                    sbQuery.Append(" , @MAT_MTYPE ");
                    sbQuery.Append(" , @MAT_STYPE ");
                    sbQuery.Append(" , @MAT_UNIT");
                    sbQuery.Append(" , @PACK_UNIT");
                    sbQuery.Append(" , @MAT_UC");
                    sbQuery.Append(" , @MAT_COST ");
                    sbQuery.Append(" , @SPEC_TYPE");
                    sbQuery.Append(" , @MAT_SPEC ");
                    sbQuery.Append(" , @MAT_SPEC1");
                    sbQuery.Append(" , @MAT_QLTY ");
                    sbQuery.Append(" , @MAIN_VND ");
                    sbQuery.Append(" , @SUPP_VND");
                    sbQuery.Append(" , @STD_PT_NUM ");
                    sbQuery.Append(" , @REV_PART_CODE ");
                    sbQuery.Append(" , @LOAD_FLAG");
                    sbQuery.Append(" , @STK_MNG");
                    sbQuery.Append(" , @STK_LOCATION ");
                    sbQuery.Append(" , @STK_LOCATION_DETAIL");
                    //sbQuery.Append(" , @STK_LOCATION_IMG");
                    sbQuery.Append(" , @SAFE_STK_QTY ");
                    sbQuery.Append(" , @IS_TURNING");
                    sbQuery.Append(" , @INS_FLAG ");
                    sbQuery.Append(" , @ACT_CODE ");
                    sbQuery.Append(" , @AUTO_CREATE");
                    sbQuery.Append(" , @AUTO_MARGIN");
                    sbQuery.Append(" , @AUTO_MARGIN_SPEC ");
                    sbQuery.Append(" , @IF_PART_CODE ");

                    sbQuery.Append(" , @FAC_PRICE");
                    sbQuery.Append(" , @PROC_COST");
                    sbQuery.Append(" , @MNG_COST");
                    sbQuery.Append(" , @PROD_COST");
                    sbQuery.Append(" , @PROFIT_PRICE");
                    sbQuery.Append(" , @PROFIT_RATIO");

                    sbQuery.Append(" , @PART_CAT");

                    sbQuery.Append(" , @JIG_CONTENTS");
                    sbQuery.Append(" , @JIG_COST");
                    sbQuery.Append(" , @ETC_CONTENTS");
                    sbQuery.Append(" , @ETC_COST");
                    sbQuery.Append(" , @CUTTING_CNT ");
                    sbQuery.Append(" , @MNG_FLAG ");
                    sbQuery.Append(" , @SCOMMENT ");
                    sbQuery.Append(" , @REV_COMMENT");
                    sbQuery.Append(" , GETDATE() ");
                    sbQuery.Append(" , " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" , 0");
                    sbQuery.Append(" , @TAB_MACHINE ");
                    sbQuery.Append(" , @MakeSideHole ");
                    sbQuery.Append(" , @Slit_Division ");
                    sbQuery.Append(" , @AFTER_TREAT ");
                    sbQuery.Append(" , @BALJU_QTY ");
                    sbQuery.Append(" , @IS_MAIN_PART ");
                    sbQuery.Append(" , @IS_MAIN_SEARCH ");
                    sbQuery.Append(" , @PROC_COST2 ");
                    sbQuery.Append(" , @MAIN_VND2 ");
                    sbQuery.Append(" , @CAM_TIME ");
                    sbQuery.Append(" , @MIL_TIME ");
                    sbQuery.Append(" , @MC_TIME ");
                    sbQuery.Append(" , @MID_INS_TIME ");
                    sbQuery.Append(" , @ASSEY_TIME ");
                    sbQuery.Append(" , @SHIP_INS_TIME ");
                    sbQuery.Append(")");

                    foreach (DataRow row in dtParam.Rows)
                    {                       
                        bizExecute.executeInsertQuery(sbQuery.ToString(), row);
                    }
                }
            }
            catch(Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static void LSE_STD_PART_INS2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" INSERT INTO LSE_STD_PART");
                    sbQuery.Append("(");
                    sbQuery.Append(" PLT_CODE");
                    sbQuery.Append(" , PART_CODE ");
                    sbQuery.Append(" , PART_NAME ");
                    sbQuery.Append(" , MAT_TYPE");
                    sbQuery.Append(" , MAT_LTYPE");
                    sbQuery.Append(" , SPEC_TYPE");
                    sbQuery.Append(" , MAT_SPEC1");
                    sbQuery.Append(" , BAL_SPEC");
                    sbQuery.Append(" , DRAW_NO");
                    sbQuery.Append(" , MAIN_VND");
                    sbQuery.Append(" , STK_MNG ");
                    sbQuery.Append(" , SAFE_STK_QTY");
                    sbQuery.Append(" , MAT_UC");
                    sbQuery.Append(" , MAT_COST");
                    sbQuery.Append(" , STK_LOCATION");
                    sbQuery.Append(" , STK_LOCATION_DETAIL");
                    sbQuery.Append(" , SCOMMENT");
                    sbQuery.Append(" , REV_COMMENT");
                    sbQuery.Append(" , IS_TOOL");
                    sbQuery.Append(" , REG_DATE");
                    sbQuery.Append(" , REG_EMP ");
                    sbQuery.Append(" , DATA_FLAG ");
                    sbQuery.Append(")");
                    sbQuery.Append(" VALUES");
                    sbQuery.Append("(");
                    sbQuery.Append(" @PLT_CODE");
                    sbQuery.Append(" , @PART_CODE ");
                    sbQuery.Append(" , @PART_NAME ");
                    sbQuery.Append(" , @MAT_TYPE");
                    sbQuery.Append(" , @MAT_LTYPE");
                    sbQuery.Append(" , @SPEC_TYPE");
                    sbQuery.Append(" , @MAT_SPEC1");
                    sbQuery.Append(" , @MAT_SPEC1");
                    sbQuery.Append(" , @MAT_SPEC1");
                    sbQuery.Append(" , @MAIN_VND");
                    sbQuery.Append(" , @STK_MNG ");
                    sbQuery.Append(" , @SAFE_STK_QTY");
                    sbQuery.Append(" , @MAT_COST");
                    sbQuery.Append(" , @MAT_COST");
                    sbQuery.Append(" , @STK_LOCATION");
                    sbQuery.Append(" , @STK_LOCATION_DETAIL");
                    sbQuery.Append(" , @SCOMMENT");
                    sbQuery.Append(" , @REV_COMMENT");
                    sbQuery.Append(" , @IS_TOOL");
                    sbQuery.Append(" , GETDATE() ");
                    sbQuery.Append(" , " + UTIL.GetValidValue(ConnInfo.UserID));
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
    }

    public class LSE_STD_PART_QUERY
    {

        public static DataTable LSE_STD_PART_QUERY1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {

                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("       SELECT PR.PLT_CODE");
                    sbQuery.Append("      ,PR.PART_CODE");
                    sbQuery.Append("      ,PR.PART_NAME");
                    sbQuery.Append("      ,PR.PART_ENAME");
                    sbQuery.Append("      ,PR.PART_SEQ");
                    sbQuery.Append("      ,PR.MAT_TYPE");
                    sbQuery.Append("      ,PR.MAT_TYPE1");
                    sbQuery.Append("      ,PR.MAT_TYPE2");
                    sbQuery.Append("      ,PR.PART_PRODTYPE");
                    sbQuery.Append("      ,PR.MAT_LTYPE");
                    sbQuery.Append("      ,PR.MAT_MTYPE");
                    sbQuery.Append("      ,PR.MAT_STYPE");
                    sbQuery.Append("      ,PR.MAT_UNIT");
                    sbQuery.Append("      ,PR.PACK_UNIT");
                    sbQuery.Append("      ,PR.MAT_COST");
                    sbQuery.Append("      ,PR.SPEC_TYPE");
                    sbQuery.Append("      ,PR.MAT_SPEC");
                    sbQuery.Append("      ,PR.MAT_SPEC1");
                    sbQuery.Append("      ,PR.DRAW_NO");
                    sbQuery.Append("      ,PR.ZIG_NO ");
                    sbQuery.Append("      ,PR.MAT_QLTY");
                    sbQuery.Append("      ,PR.MAIN_VND");
                    sbQuery.Append("      ,PR.STD_PT_NUM");
                    sbQuery.Append("      ,PR.STK_LOCATION");
                    sbQuery.Append("      ,PR.STK_LOCATION_DETAIL");
                    sbQuery.Append("      ,PR.STK_COMPLETE");
                    sbQuery.Append("      ,PR.STK_TURNING");
                    sbQuery.Append("      ,PR.STK_TOTAL");
                    sbQuery.Append("      ,PR.MAT_STYPE");
                    sbQuery.Append("      ,PR.LOAD_FLAG");
                    sbQuery.Append("      ,PR.SAFE_STK_QTY");
                    sbQuery.Append("      ,PR.INS_FLAG");
                    sbQuery.Append("      ,PR.ACT_CODE");
                    sbQuery.Append("      ,PR.AUTO_CREATE");
                    sbQuery.Append("      ,PR.AUTO_MARGIN");
                    sbQuery.Append("      ,PR.AUTO_MARGIN_SPEC");
                    sbQuery.Append("      ,PR.STK_MNG");
                    sbQuery.Append("      ,PR.SCOMMENT");
                    sbQuery.Append("      ,PR.REV_COMMENT");
                    sbQuery.Append("      ,PR.REG_DATE");
                    sbQuery.Append("      ,PR.REG_EMP");
                    sbQuery.Append("      ,PR.MDFY_DATE");
                    sbQuery.Append("      ,PR.MDFY_EMP");
                    sbQuery.Append("      ,PR.DATA_FLAG");
                    sbQuery.Append("      ,PR.DEL_DATE");
                    sbQuery.Append("      ,PR.DEL_EMP");
                    sbQuery.Append("      ,PR.DEL_REASON");
                    sbQuery.Append("      ,CASE ISNULL(PF.LINK_KEY, '') WHEN '' THEN 'X' ELSE 'O' END colATTACH   ");
                    sbQuery.Append("      ,PF.LINK_KEY ");
                    sbQuery.Append("      ,CASE WHEN ISNULL(PR.REV_PART_CODE, '') = '' THEN 'X' ELSE 'O' END REV_PART ");
                    sbQuery.Append("      ,PR.REV_PART_CODE ");
                    sbQuery.Append(" , PR.CUTTING_CNT ");
                    sbQuery.Append("  FROM LSE_STD_PART PR");
                    sbQuery.Append("   LEFT JOIN (SELECT DISTINCT P.PLT_CODE																																		 ");
                    sbQuery.Append("				   , P.PART_CODE																																				 ");
                    sbQuery.Append("				   , FM.LINK_KEY																																				 ");
                    sbQuery.Append("				FROM TORD_PRODUCT P																																				 ");
                    sbQuery.Append("			   INNER JOIN (SELECT PLT_CODE, LINK_KEY FROM TSYS_FILELIST_MASTER WHERE IS_UPLOAD = 1 AND UPLOAD_MENU = 'PLN01A' AND DATA_FLAG = 0 GROUP BY PLT_CODE, LINK_KEY) FM  ");
                    sbQuery.Append("				   ON P.PLT_CODE = FM.PLT_CODE AND P.PART_CODE = FM.LINK_KEY) PF																								 ");
                    sbQuery.Append("		ON PR.PLT_CODE = PF.PLT_CODE 																																			 ");
                    sbQuery.Append("			AND PR.PART_CODE = PF.PART_CODE 																																	 ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE PR.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@PART_CODE", "PR.PART_CODE = @PART_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@MAT_TYPE", "PR.MAT_TYPE = @MAT_TYPE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_PRODTYPE", "PR.PART_PRODTYPE = @PART_PRODTYPE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@MAT_LTYPE", "PR.MAT_LTYPE = @MAT_LTYPE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@MAT_MTYPE", "PR.MAT_MTYPE = @MAT_MTYPE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@MAT_STYPE", "PR.MAT_STYPE = @MAT_STYPE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@MAT_QLTY", "PR.MAT_QLTY = @MAT_QLTY"));
                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "PR.DATA_FLAG = @DATA_FLAG"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_LIKE", "(PR.PART_CODE LIKE '%' + @PART_LIKE + '%' OR PR.PART_NAME LIKE '%' + @PART_LIKE + '%')"));
                        sbWhere.Append(UTIL.GetWhere(row, "@SPEC_LIKE", "(PR.MAT_SPEC LIKE '%' + @SPEC_LIKE + '%' OR PR.MAT_SPEC1 LIKE '%' + @SPEC_LIKE + '%')"));
                        sbWhere.Append(UTIL.GetWhere(row, "@DRAW_LIKE", " PR.DRAW_NO LIKE '%' + @DRAW_LIKE + '%'"));
                        sbWhere.Append(UTIL.GetWhere(row, "@AUTO_CREATE", "PR.AUTO_CREATE = @AUTO_CREATE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@LOAD_FLAG", "PR.LOAD_FLAG = @LOAD_FLAG"));
                        sbWhere.Append(UTIL.GetWhere(row, "@REV_PART_CODE", "PR.REV_PART_CODE = @REV_PART_CODE"));

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

        public static DataTable LSE_STD_PART_QUERY2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {

                DataSet dsResult = new DataSet();
                
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("SELECT P.PLT_CODE ");
                    sbQuery.Append(" ,P.PART_CODE ");
                    sbQuery.Append(" ,P.PART_NAME ");
                    sbQuery.Append(" ,P.PART_ENAME ");
                    sbQuery.Append(" ,P.PART_SEQ ");
                    sbQuery.Append(" ,P.MAT_TYPE ");
                    sbQuery.Append(" ,P.MAT_TYPE1 ");
                    sbQuery.Append(" ,P.MAT_TYPE2 ");
                    sbQuery.Append(" ,P.PART_PRODTYPE ");
                    sbQuery.Append(" ,P.DRAW_NO ");
                    sbQuery.Append(" ,P.ZIG_NO ");
                    sbQuery.Append(" ,P.MAT_LTYPE ");
                    sbQuery.Append(" ,P.MAT_MTYPE ");
                    sbQuery.Append(" ,P.MAT_STYPE ");
                    sbQuery.Append(" ,P.MAT_UNIT ");
                    sbQuery.Append(" ,P.PACK_UNIT ");
                    sbQuery.Append(" ,P.MAT_UC ");
                    sbQuery.Append(" ,P.MAT_COST ");
                    sbQuery.Append(" ,P.MAT_UC AS UNIT_COST ");
                    sbQuery.Append(" ,P.MAT_COST AS AMT ");
                    sbQuery.Append(" ,P.MAT_QLTY ");
                    sbQuery.Append(" ,P.MAT_QLTY AS PART_QLTY ");
                    sbQuery.Append(" ,QLTY.MQLTY_NAME AS MAT_QLTY_NAME ");
                    sbQuery.Append(" ,P.MAT_QLTY AS PART_QTY");
                    sbQuery.Append(" ,QLTY.MQLTY_NAME AS PART_QLTY_NAME ");
                    sbQuery.Append(" ,P.MAIN_VND ");
                    sbQuery.Append(" ,P.SUPP_VND ");
                    sbQuery.Append(" ,VEN.VEN_NAME AS MAIN_VND_NAME ");
                    sbQuery.Append(" ,P.STD_PT_NUM ");
                    sbQuery.Append(" ,P.SCOMMENT ");
                    sbQuery.Append(" ,P.REV_COMMENT ");
                    sbQuery.Append(" ,P.REG_DATE ");
                    sbQuery.Append(" ,P.REG_EMP ");
                    sbQuery.Append(" ,REG_EMP.EMP_NAME AS REG_EMP_NAME ");
                    sbQuery.Append(" ,P.MDFY_DATE ");
                    sbQuery.Append(" ,P.MDFY_EMP ");
                    sbQuery.Append(" ,MDFY_EMP.EMP_NAME AS MDFY_EMP_NAME ");
                    sbQuery.Append(" ,P.DATA_FLAG ");
                    sbQuery.Append(" ,P.SPEC_TYPE ");
                    sbQuery.Append(" ,P.MAT_STYPE ");
                    sbQuery.Append(" ,P.MAT_SPEC ");
                    sbQuery.Append(" ,P.MAT_SPEC1 ");
                    sbQuery.Append(" ,P.BAL_SPEC AS BALJU_SPEC ");
                    sbQuery.Append(" ,P.MAT_WEIGHT");
                    sbQuery.Append(" ,P.MAT_WEIGHT1");
                    sbQuery.Append(" ,P.BAL_WEIGHT");
                    sbQuery.Append(" ,P.LOAD_FLAG ");
                    sbQuery.Append(" ,P.INS_FLAG ");
                    sbQuery.Append(" ,P.ACT_CODE ");
                    sbQuery.Append(" ,P.SAFE_STK_QTY ");
                    sbQuery.Append(" ,P.STK_LOCATION ");
                    sbQuery.Append(" ,P.STK_LOCATION_DETAIL");
                    sbQuery.Append(" ,P.AUTO_CREATE ");
                    sbQuery.Append(" ,P.AUTO_MARGIN ");
                    sbQuery.Append(" ,P.AUTO_MARGIN_SPEC ");
                    sbQuery.Append(" ,P.STK_MNG ");
                    sbQuery.Append(" ,P.IF_PART_CODE ");
                    sbQuery.Append(" ,P.UNIT_QTY");
                    sbQuery.Append(" ,P.UNIT_QTY AS QTY");
                    sbQuery.Append(" ,P.UNIT_QTY AS BOM_QTY");
                    sbQuery.Append(" ,0 AS BOM_SEQ ");

                    sbQuery.Append(" ,P.FAC_PRICE ");
                    sbQuery.Append(" ,P.PROC_COST ");
                    sbQuery.Append(" ,P.MNG_COST ");
                    sbQuery.Append(" ,P.PROD_COST ");
                    sbQuery.Append(" ,P.PROFIT_PRICE ");
                    sbQuery.Append(" ,P.PROFIT_RATIO ");

                    sbQuery.Append(" ,P.REV_PART_CODE");
                    sbQuery.Append(" ,P.STK_COMPLETE");
                    sbQuery.Append(" ,P.STK_TURNING");
                    sbQuery.Append(" ,P.IS_TURNING");
                    sbQuery.Append(" ,ISNULL(P.STK_TURNING, 0) + ISNULL(P.STK_COMPLETE, 0) AS STK_TOTAL");
                    //sbQuery.Append(" ,ISNULL(W.WIP_QTY, 0) AS WIP_QTY ");
                    sbQuery.Append(" , P.CUTTING_CNT ");
                    sbQuery.Append(" , P.MNG_FLAG ");
                    sbQuery.Append(" , P.BALJU_QTY ");
                    sbQuery.Append(" , P.IS_MAIN_PART ");
                    sbQuery.Append(" , P.IS_MAIN_SEARCH ");
                    sbQuery.Append(" ,VP.DWG_NAME");
                    sbQuery.Append(" ,VP.PROJECT_NAME");
                    sbQuery.Append(" ,VP.CMS_NO");
                    sbQuery.Append(" ,VP.ORDERCOUNT");
                    sbQuery.Append(" ,VP.SPECIFICATION");
                    sbQuery.Append(" ,VP.CONNECTOR_NO");
                    sbQuery.Append(" ,VP.CONNECTOR_ANGLE");
                    sbQuery.Append(" ,VP.CONTACT_PIN1");
                    sbQuery.Append(" ,VP.CONTACT_PIN2");
                    sbQuery.Append(" ,VP.CONTACT_PIN3");
                    sbQuery.Append(" ,VP.CONTACT_PIN4");
                    sbQuery.Append(" ,VP.CORE_HOUSING1");
                    sbQuery.Append(" ,VP.CORE_HOUSING2");
                    sbQuery.Append(" ,VP.CORE_HOUSING3");
                    sbQuery.Append(" ,VP.CORE_HOUSING4");
                    sbQuery.Append(" ,VP.CONTACT_DIRECTION");
                    sbQuery.Append(" ,VP.CONNECTOR_DIRECTION");
                    sbQuery.Append(" ,VP.IMAGE_DIRECTION");
                    sbQuery.Append(" ,VP.APPLY_INTERFACE");
                    sbQuery.Append(" ,VP.INTERFACE_PIN");
                    sbQuery.Append(" ,VP.APPLY_INTERFACE_PIN");
                    sbQuery.Append(" ,VP.GND_PIN");
                    sbQuery.Append(" ,VP.IMAGE_ANGLE1");
                    sbQuery.Append(" ,VP.IMAGE_ANGLE2");
                    sbQuery.Append(" ,VP.IMAGE_ANGLE3");
                    sbQuery.Append(" ,VP.IMAGE_ANGLE4");
                    sbQuery.Append(" ,VP.PART_REV_ID");
                    sbQuery.Append(" ,VP.PART_PUID");
                    sbQuery.Append(" ,VP.DIVISION_P");
                    sbQuery.Append(" ,VP.DIVISION");
                    sbQuery.Append(" ,VP.MARTERIAL");
                    sbQuery.Append(" ,VP.SURFACE_TREAT");
                    sbQuery.Append(" ,P.AFTER_TREAT");
                    sbQuery.Append(" ,P.MAKESIDEHOLE");
                    sbQuery.Append(" ,P.TAB_MACHINE");
                    sbQuery.Append(" ,VP.MACHINE_TIME");
                    //sbQuery.Append(" ,(SELECT SUM(PART_QTY) FROM TMAT_STOCK WHERE PART_CODE = P.PART_CODE) AS STK_QTY ");
                    sbQuery.Append(" ,STK.STK_QTY");
                    sbQuery.Append(" ,PROC_COST2 ");
                    sbQuery.Append(" ,MAIN_VND2 ");
                    sbQuery.Append(" , P.PART_CAT ");

                    sbQuery.Append(" , P.CAM_TIME ");
                    sbQuery.Append(" , P.MIL_TIME ");
                    sbQuery.Append(" , P.MC_TIME ");
                    sbQuery.Append(" , P.MID_INS_TIME ");
                    sbQuery.Append(" , P.ASSEY_TIME ");
                    sbQuery.Append(" , P.SHIP_INS_TIME ");

                    sbQuery.Append(" FROM LSE_STD_PART P ");
                    sbQuery.Append("LEFT JOIN TMAT_QUC_MASTER QLTY ");
                    sbQuery.Append("ON P.PLT_CODE = QLTY.PLT_CODE AND P.MAT_QLTY = QLTY.MQLTY_CODE ");
                    
                    sbQuery.Append("LEFT JOIN TSTD_VENDOR VEN ");
                    sbQuery.Append("ON P.PLT_CODE = VEN.PLT_CODE AND P.MAIN_VND = VEN.VEN_CODE ");
                    
                    sbQuery.Append("LEFT JOIN TSTD_EMPLOYEE  REG_EMP ");
                    sbQuery.Append("ON P.PLT_CODE = REG_EMP.PLT_CODE AND P.REG_EMP = REG_EMP.EMP_CODE ");
                    
                    sbQuery.Append("LEFT JOIN TSTD_EMPLOYEE  MDFY_EMP ");
                    sbQuery.Append("ON P.PLT_CODE = MDFY_EMP.PLT_CODE AND P.MDFY_EMP = MDFY_EMP.EMP_CODE");

                    sbQuery.Append(" LEFT JOIN VIF_PLM_PART VP");
                    sbQuery.Append(" ON P.PART_CODE = VP.PART_CODE");

                    sbQuery.Append(" LEFT JOIN ");
                    sbQuery.Append(" (");
                    sbQuery.Append(" SELECT PLT_CODE, PART_CODE, SUM(PART_QTY) AS STK_QTY FROM TMAT_STOCK GROUP BY PLT_CODE, PART_CODE");                    
                    sbQuery.Append(" ) STK");
                    sbQuery.Append(" ON STK.PLT_CODE = P.PLT_CODE");
                    sbQuery.Append(" AND STK.PART_CODE = P.PART_CODE");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE P.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@PART_CODE", "P.PART_CODE = @PART_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_REG_DATE,@E_REG_DATE", "(CONVERT(nvarchar(8),P.REG_DATE,112) BETWEEN @S_REG_DATE AND @E_REG_DATE)"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_LIKE", "(P.PART_CODE LIKE '%' +  @PART_LIKE + '%' OR P.PART_NAME  LIKE '%' +  @PART_LIKE + '%')"));
                        sbWhere.Append(UTIL.GetWhere(row, "@FILTER_LIKE", "(P.PART_CODE LIKE '%' +  @FILTER_LIKE + '%' OR P.PART_NAME  LIKE '%' +  @FILTER_LIKE + '%')"));
                        //sbWhere.Append(UTIL.GetWhere(row, "@PART_PRODTYPE_LIKE", "(P.PART_PRODTYPE LIKE '%' +  @PART_PRODTYPE_LIKE + '%' OR P.PART_NAME  LIKE '%' +  @PART_PRODTYPE_LIKE + '%')"));//모델
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_PRODTYPE", "P.PART_PRODTYPE = @PART_PRODTYPE"));//부품제작구분
                        sbWhere.Append(UTIL.GetWhere(row, "@STD_PT_NUM_LIKE", "(P.STD_PT_NUM LIKE '%' + @STD_PT_NUM_LIKE + '%')"));
                        sbWhere.Append(UTIL.GetWhere(row, "@SPEC_LIKE", "(P.MAT_SPEC LIKE '%' + @SPEC_LIKE + '%' OR P.MAT_SPEC1 LIKE '%' + @SPEC_LIKE + '%')"));
                        sbWhere.Append(UTIL.GetWhere(row, "@MAT_TYPE", "P.MAT_TYPE = @MAT_TYPE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@MAT_LTYPE", "P.MAT_LTYPE = @MAT_LTYPE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@MAT_MTYPE", "P.MAT_MTYPE = @MAT_MTYPE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@MAT_STYPE", "P.MAT_STYPE = @MAT_STYPE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@STK_MNG", "P.STK_MNG = @STK_MNG"));
                        sbWhere.Append(UTIL.GetWhere(row, "@IS_TURNING", "P.IS_TURNING = @IS_TURNING"));
                        sbWhere.Append(UTIL.GetWhere(row, "@MAT_LTYPE_IN", "P.MAT_LTYPE IN (@MAT_LTYPE_IN)"));
                        sbWhere.Append(UTIL.GetWhere(row, "@DRAW_NO", "P.DRAW_NO LIKE '%' + @DRAW_NO + '%'"));
                        sbWhere.Append(UTIL.GetWhere(row, "@FILTER", "P.PART_NAME LIKE '%' + @FILTER + '%'"));

                        sbWhere.Append(UTIL.GetWhere(row, "@IS_MAIN_PART", "ISNULL(P.IS_MAIN_PART, '0') = @IS_MAIN_PART"));
                        sbWhere.Append(UTIL.GetWhere(row, "@VEN_CODE", "P.SUPP_VND = @VEN_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "P.DATA_FLAG = @DATA_FLAG"));
                        
                        DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString() + sbWhere.ToString()).Copy();                    

                        sourceTable.TableName = "RSLTDT";
                        dsResult.Merge(sourceTable);    
                    }
                }


                return UTIL.GetDsToDt(dsResult);
            }
            catch(Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }

        public static DataTable LSE_STD_PART_QUERY3(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {

                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("SELECT P.PLT_CODE ");
                    sbQuery.Append(" ,P.PART_CODE ");
                    sbQuery.Append(" ,P.PART_NAME ");
                    sbQuery.Append(" ,P.PART_ENAME ");
                    sbQuery.Append(" ,P.MAT_TYPE ");
                    sbQuery.Append(" ,P.PART_PRODTYPE ");
                    sbQuery.Append(" ,P.MAT_LTYPE ");
                    sbQuery.Append(" ,P.MAT_UNIT ");
                    sbQuery.Append(" ,P.MAT_COST ");
                    sbQuery.Append(" ,P.STD_PT_NUM ");
                    sbQuery.Append(" ,P.SPEC_TYPE ");
                    sbQuery.Append(" ,P.MAT_STYPE ");
                    sbQuery.Append(" ,P.MAT_SPEC ");
                    sbQuery.Append(" FROM LSE_STD_PART P ");

                    //sbQuery.Remove(0, sbQuery.Length);
                    //sbQuery.Append("select * from active_pheng..TPURCHASE_EVENT P");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE P.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@PART_LIKE", "(P.PART_CODE LIKE '%' +  @PART_LIKE + '%' OR P.PART_NAME  LIKE '%' +  @PART_LIKE + '%')"));
                        sbWhere.Append(UTIL.GetWhere(row, "@MAT_LTYPE_IN", "P.MAT_LTYPE IN (@MAT_LTYPE_IN)"));

                        sbWhere.Append(" AND DATA_FLAG = 0");

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

        public static DataTable LSE_STD_PART_QUERY4(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {

                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("SELECT ");
                    sbQuery.Append("   SP.PLT_CODE ");
                    sbQuery.Append(" , SP.PART_CODE ");
                    sbQuery.Append(" , SP.MAT_LTYPE ");
                    sbQuery.Append(" , SP.MAT_MTYPE ");
                    sbQuery.Append(" , SP.PART_PRODTYPE");
                    sbQuery.Append(" , SP.PART_NAME ");
                    sbQuery.Append(" , SP.DRAW_NO ");
                    sbQuery.Append(" , SP.MAT_UNIT ");
                    sbQuery.Append(" , SP.MAT_TYPE ");
                    sbQuery.Append(" , SP.INS_FLAG ");
                    //sbQuery.Append(" , SP.CUR_UNIT ");
                    //sbQuery.Append(" , SP.UNIT_COST ");
                    //sbQuery.Append(" , SP.MVND_CODE ");
                    sbQuery.Append(" , SP.SCOMMENT ");

                    sbQuery.Append(" ,CASE WHEN BM.BM_KEY IS NULL THEN 0 ELSE 1 END AS IS_BOM_REG	");
                    sbQuery.Append(" ,BM.REV_NO	");
                    sbQuery.Append(" ,BM.BM_STATE	");
                    sbQuery.Append(" ,BM.LOCK_EMP	");
                    sbQuery.Append(" ,BM.REG_DATE ");
                    sbQuery.Append(" ,BM.REG_EMP ");
                    sbQuery.Append(" ,BM.MDFY_DATE ");
                    sbQuery.Append(" ,BM.MDFY_EMP ");

                    sbQuery.Append("  FROM LSE_STD_PART SP ");

                    sbQuery.Append(" LEFT JOIN TSTD_BOM_MASTER AS BM ");
                    sbQuery.Append(" ON (BM.BM_CODE = SP.PART_CODE) ");
                    sbQuery.Append(" AND BM.REV_NO = (SELECT ");
                    sbQuery.Append(" MAX(BM2.REV_NO) ");
                    sbQuery.Append(" FROM ");
                    sbQuery.Append(" TSTD_BOM_MASTER AS BM2 ");
                    sbQuery.Append(" WHERE ");
                    sbQuery.Append(" BM2.BM_CODE = SP.PART_CODE ");
                    sbQuery.Append(" AND BM2.DATA_FLAG = 0) ");
                    sbQuery.Append(" AND BM.DATA_FLAG = 0 ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE SP.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                       
                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "SP.DATA_FLAG = @DATA_FLAG"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_LIKE", "(SP.PART_CODE LIKE '%' + @PART_LIKE + '%' OR SP.PART_NAME LIKE '%' + @PART_LIKE + '%')"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_CODE", "SP.PART_CODE = @PART_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@MAT_LTYPE", "SP.MAT_LTYPE = @MAT_LTYPE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@MAT_MTYPE", "SP.MAT_MTYPE = @MAT_MTYPE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@IS_REG", "BM.BM_CODE IS NOT NULL "));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_PART_CODE", "(SELECT COUNT(*) FROM TSTD_BOM WHERE BM_CODE = SP.PART_CODE AND PART_CODE = @S_PART_CODE ) > 0"));


                        sbWhere.Append("  ORDER BY SP.PART_CODE   ");

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
        /// D-PLUS : 구매 발주 조회용
        /// hjkim
        /// </summary>
        /// <param name="dtParam"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataTable LSE_STD_PART_QUERY6(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT P.PLT_CODE");
                    sbQuery.Append(" , P.MAT_TYPE");
                    sbQuery.Append(" , P.MAT_TYPE1");
                    sbQuery.Append(" , P.MAT_TYPE2");
                    sbQuery.Append(" , P.PART_PRODTYPE");
                    sbQuery.Append(" , P.MAT_LTYPE");
                    sbQuery.Append(" , P.MAT_MTYPE");
                    sbQuery.Append(" , P.MAT_STYPE");
                    sbQuery.Append(" , P.PART_CODE");
                    sbQuery.Append(" , P.PART_NAME");
                    sbQuery.Append(" , P.MAIN_VND");
                    sbQuery.Append(" , P.SUPP_VND");
                    sbQuery.Append(" , P.SUPP_VND AS MVND_CODE");
                    sbQuery.Append(" , V.VEN_ACCOUNT");
                    sbQuery.Append(" , P.SAFE_STK_QTY");
                    sbQuery.Append(" , ISNULL(S.PART_QTY, 0) AS STK_QTY ");
                    sbQuery.Append(" , P.MAT_COST");
                    sbQuery.Append(" , P.MAT_UNIT");
                    sbQuery.Append(" , ISNULL(P.INS_FLAG, 1) AS INS_FLAG");
                    sbQuery.Append(" , P.MAT_SPEC");
                    sbQuery.Append(" , P.REG_DATE");
                    sbQuery.Append(" , P.REG_EMP");
                    sbQuery.Append(" , P.MDFY_DATE");
                    sbQuery.Append(" , P.MDFY_EMP");

                    sbQuery.Append(" FROM LSE_STD_PART P");
                    //sbQuery.Append("   LEFT JOIN TMAT_STOCK S ");
                    //sbQuery.Append("   ON P.PLT_CODE = S.PLT_CODE ");
                    //sbQuery.Append("   AND P.PART_CODE = S.PART_CODE ");
                    sbQuery.Append(" LEFT JOIN (SELECT PLT_CODE, PART_CODE, SUM(PART_QTY) AS PART_QTY FROM TMAT_STOCK GROUP BY PLT_CODE, PART_CODE) S ");
                    sbQuery.Append("   ON P.PLT_CODE = S.PLT_CODE ");
                    sbQuery.Append("   AND P.PART_CODE = S.PART_CODE ");

                    sbQuery.Append("   LEFT JOIN TSTD_VENDOR V ");
                    sbQuery.Append("   ON P.PLT_CODE = V.PLT_CODE ");
                    sbQuery.Append("   AND P.SUPP_VND = V.VEN_CODE ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE P.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                        //구매품, 소모품 제외
                        sbWhere.Append("  AND P.DATA_FLAG = 0 ");

                        sbWhere.Append(UTIL.GetWhere(row, "@PUR01A", "P.MAT_TYPE IN ('PUR') "));
                        sbWhere.Append(UTIL.GetWhere(row, "@PUR02A", "P.MAT_TYPE IN ('SUP') "));
                        
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_PRODTYPE", "P.PART_PRODTYPE = @PART_PRODTYPE  "));

                        sbWhere.Append(UTIL.GetWhere(row, "@MAT_TYPE1", " P.MAT_TYPE1 = @MAT_TYPE1             ")); //자재구분
                        sbWhere.Append(UTIL.GetWhere(row, "@MAT_TYPE2", " P.MAT_TYPE2 = @MAT_TYPE2             ")); //자재유형

                        sbWhere.Append(UTIL.GetWhere(row, "@MAT_LTYPE", " P.MAT_LTYPE = @MAT_LTYPE             ")); //대분류
                        sbWhere.Append(UTIL.GetWhere(row, "@MAT_MTYPE", " P.MAT_MTYPE = @MAT_MTYPE             ")); //중분류
                        sbWhere.Append(UTIL.GetWhere(row, "@MAT_STYPE", " P.MAT_STYPE = @MAT_STYPE             ")); //소분류
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_LIKE", "(P.PART_CODE LIKE '%' + @PART_LIKE + '%' OR P.PART_NAME LIKE '%' + @PART_LIKE + '%')"));

                        sbWhere.Append(UTIL.GetWhere(row, "@UNDER_SAFE", " (ISNULL(P.SAFE_STK_QTY, 0) > 0) AND (ISNULL(S.PART_QTY, 0) < ISNULL(P.SAFE_STK_QTY, 0)) "));

                        sbWhere.Append(UTIL.GetWhere(row, "@IS_MAIN", "ISNULL(P.IS_MAIN_PART, '0') = '1'  "));

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



        public static DataTable LSE_STD_PART_QUERY6_1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT");
                    sbQuery.Append(" SP.PLT_CODE");
                    sbQuery.Append(" , SP.PART_CODE");

                    sbQuery.Append(" , SP.PROD_NAME");
                    sbQuery.Append(" , SP.ITEM");
                    sbQuery.Append(" , SP.DRAW_NO");
                    sbQuery.Append(" , SP.PROD_GROUP");
                    sbQuery.Append(" , SP.PART_DESC");
                    sbQuery.Append(" , SP.PART_UNIT");
                    sbQuery.Append(" , SP.PROD_TYPE");
                    sbQuery.Append(" , SP.PART_PROC");
                    sbQuery.Append(" , SP.NET_WEIGHT");
                    sbQuery.Append(" , SP.GROSS_WEIGHT");
                    sbQuery.Append(" , SP.PART_CBM");
                    sbQuery.Append(" , SP.CT_QTY");
                    sbQuery.Append(" , SP.INS_FLAG");
                    sbQuery.Append(" , CASE ISNULL(SP.INS_FLAG, 0) WHEN 0 THEN 'X' ELSE 'O' END INS_FLAG_NAME");
                    sbQuery.Append(" , SP.CUR_UNIT");
                    sbQuery.Append(" , SP.UNIT_COST");
                    sbQuery.Append(" , SP.MVND_CODE");
                    sbQuery.Append(" , SP.CUR_UNIT2");
                    sbQuery.Append(" , SP.UNIT_COST2");
                    sbQuery.Append(" , SP.MVND_CODE2");
                    sbQuery.Append(" , SP.CUR_UNIT3");
                    sbQuery.Append(" , SP.UNIT_COST3");
                    sbQuery.Append(" , SP.MVND_CODE3");
                    sbQuery.Append(" , SP.SAFE_QTY");
                    sbQuery.Append(" , SP.YPGO_DAYS");
                    sbQuery.Append(" , SP.MOQ");
                    sbQuery.Append(" , SP.HS_CODE");
                    sbQuery.Append(" , SP.ORIGIN");
                    sbQuery.Append(" , SP.ORIGIN_CRIT");

                    sbQuery.Append(" , SP.SCOMMENT");
                    sbQuery.Append(" , SP.STOCK_LOC");
                    sbQuery.Append(" , SP.PART_TYPE");
                    sbQuery.Append(" , SP.NG_RATE");
                    sbQuery.Append(" , SP.REG_DATE");
                    sbQuery.Append(" , SP.REG_EMP");
                    sbQuery.Append(" , SP.MDFY_DATE");
                    sbQuery.Append(" , SP.MDFY_EMP");
                    sbQuery.Append(" , SP.DEL_DATE");
                    sbQuery.Append(" , SP.DEL_EMP");
                    sbQuery.Append(" , SP.DATA_FLAG");
                    sbQuery.Append(" , (SELECT VALUE FROM TSTD_CODES WHERE PLT_CODE = SP.PLT_CODE AND CAT_CODE = '0A01' AND CD_CODE = SP.PART_CAT1) AS CD_VALUE");
                    sbQuery.Append(" FROM LSE_STD_PART SP");

                    sbQuery.Append(" LEFT JOIN TSTD_VENDOR V ");
                    sbQuery.Append(" ON SP.PLT_CODE = V.PLT_CODE ");
                    sbQuery.Append(" AND SP.MVND_CODE = V.VEN_CODE ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE SP.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@S_DATE,@E_DATE", "(CONVERT(varchar,SP.REG_DATE,112) BETWEEN @S_DATE AND @E_DATE)"));
                        sbWhere.Append(UTIL.GetWhere(row, "@DESC_LIKE", " SP.PART_DESC LIKE '%' + @DESC_LIKE + '%' "));
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_OLD_LIKE", " SP.PART_CODE_OLD LIKE '%' + @PART_OLD_LIKE + '%' "));
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_CAT1", "SP.PART_CAT1 = @PART_CAT1"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_CAT2", "SP.PART_CAT2 = @PART_CAT2"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_LIKE", " (SP.PART_CODE LIKE '%' + @PART_LIKE + '%') "));
                        sbWhere.Append(UTIL.GetWhere(row, "@MVND_LIKE", " V.VEN_NAME LIKE '%' + @MVND_LIKE + '%' "));

                        sbWhere.Append(UTIL.GetWhere(row, "@PART_CODE", "SP.PART_CODE = @PART_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "SP.DATA_FLAG = @DATA_FLAG"));
                        sbWhere.Append(UTIL.GetWhere(row, "@ITEM_LIKE", " SP.ITEM LIKE '%' + @ITEM_LIKE + '%' "));
                        sbWhere.Append(UTIL.GetWhere(row, "@ITEM", " SP.ITEM = @ITEM "));

                        sbWhere.Append(UTIL.GetWhere(row, "@PART_N_OLD_LIKE", " (SP.PART_CODE LIKE '%' + @PART_N_OLD_LIKE + '%' OR SP.PART_CODE_OLD LIKE '%' + @PART_N_OLD_LIKE + '%') "));

                        sbWhere.Append(" ORDER BY SP.PART_CAT1, SP.PART_CAT2, SP.PART_CODE ");
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


        //모델별 품목 정보(주간 생산 계획 수립시)
        public static DataTable LSE_STD_PART_QUERY7(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT PLT_CODE");
                    sbQuery.Append(" ,PART_CODE");
                    sbQuery.Append(" ,PART_NAME");
                    sbQuery.Append(" ,PART_PRODTYPE");
                    sbQuery.Append(" ,MAT_SPEC");
                    sbQuery.Append(" ,DRAW_NO");
                    sbQuery.Append(" ,ZIG_NO");
                    sbQuery.Append(" ,MAT_UNIT");
                    sbQuery.Append(" ,UNIT_QTY");
                    sbQuery.Append(" ,SAFE_STK_QTY");
                    sbQuery.Append(" ,MAT_LTYPE");
                    sbQuery.Append(" ,ACT_CODE");
                    sbQuery.Append(" ,MAT_TYPE");
                    sbQuery.Append(" FROM LSE_STD_PART ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@PART_PRODTYPE", "PART_PRODTYPE = @PART_PRODTYPE"));
                        sbWhere.Append(" AND MAT_LTYPE IN ('A1','A2') AND DATA_FLAG = 0 ");                        

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


        //품목 정보 가져오기 (트리구조로 변경 처리)
        public static DataTable LSE_STD_PART_QUERY8(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT A.PLT_CODE, 								   ");
                    sbQuery.Append("  A.PARENT 											   ");
                    sbQuery.Append("  , A.PART_PRODTYPE + A.PART_CODE AS KEYVALUE		   ");
                    sbQuery.Append("  , A.PART_PRODTYPE 								   ");
                    sbQuery.Append("  , A.PART_CODE 									   ");
                    sbQuery.Append("  , A.PART_NAME 									   ");
                    sbQuery.Append("  , A.DRAW_NO 										   ");
                    sbQuery.Append("  , A.MAT_SPEC  									   ");
                    sbQuery.Append("  , A.REG_DATE  									   ");
                    sbQuery.Append("  FROM  											   ");
                    sbQuery.Append(" (SELECT SP.PLT_CODE, 								   ");
                    sbQuery.Append("  PART_PRODTYPE AS PARENT 							   ");
                    sbQuery.Append("  , '' AS PART_PRODTYPE 							   ");
                    sbQuery.Append("  , PART_CODE 										   ");
                    sbQuery.Append("  , PART_NAME 										   ");
                    sbQuery.Append("  , DRAW_NO 										   ");
                    sbQuery.Append("  , MAT_SPEC  										   ");
                    sbQuery.Append("  , SP.REG_DATE  									   ");
                    sbQuery.Append("  , PART_PRODTYPE AS PART_SER  						   ");
                    sbQuery.Append("  FROM LSE_STD_PART SP								   ");
                    sbQuery.Append("  LEFT JOIN TSTD_CODES C							   ");
                    sbQuery.Append("  ON SP.PLT_CODE = C.PLT_CODE						   ");
                    sbQuery.Append("  AND C.CAT_CODE = 'S016'							   ");
                    sbQuery.Append("  AND SP.MAT_TYPE = C.CD_CODE						   ");
                    sbQuery.Append("  WHERE MAT_LTYPE IN ('A1','A2')  AND SP.DATA_FLAG = 0 ");
                    sbQuery.Append("  AND PART_PRODTYPE <> '' AND PART_PRODTYPE IS NOT NULL");
                    sbQuery.Append("  AND C.VALUE = 'PROD'								   ");
                    sbQuery.Append("  UNION ALL 										   ");
                    sbQuery.Append("  SELECT SP.PLT_CODE 								   ");
                    sbQuery.Append("  , '' AS PARENT 									   ");
                    sbQuery.Append("  , PART_PRODTYPE 									   ");
                    sbQuery.Append("  ,'' ,'','',''  									   ");
                    sbQuery.Append("  , MAX(SP.REG_DATE) 								   ");
                    sbQuery.Append("  , PART_PRODTYPE AS PART_SER  						   ");
                    sbQuery.Append("  FROM LSE_STD_PART SP								   ");
                    sbQuery.Append("  LEFT JOIN TSTD_CODES C							   ");
                    sbQuery.Append("  ON SP.PLT_CODE = C.PLT_CODE						   ");
                    sbQuery.Append("  AND C.CAT_CODE = 'S016'							   ");
                    sbQuery.Append("  AND SP.MAT_TYPE = C.CD_CODE						   ");
                    sbQuery.Append("  WHERE MAT_LTYPE IN ('A1','A2') AND SP.DATA_FLAG = 0  ");
                    sbQuery.Append("  AND PART_PRODTYPE <> '' AND PART_PRODTYPE IS NOT NULL");
                    sbQuery.Append("  AND C.VALUE = 'PROD'								   ");
                    sbQuery.Append("  GROUP BY SP.PLT_CODE,PART_PRODTYPE) A 			   ");

                    //sbQuery.Remove(0, sbQuery.Length);
                    //sbQuery.Append("select * from active_pheng..TPURCHASE_EVENT P");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE A.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@S_REG_DATE,@E_REG_DATE", "A.REG_DATE BETWEEN @S_REG_DATE AND @E_REG_DATE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_PRODTYPE_LIKE", "A.PART_SER LIKE '%' + @PART_PRODTYPE_LIKE  + '%'"));

                        sbWhere.Append("ORDER BY A.PART_PRODTYPE, A.PART_CODE");

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

        public static DataTable LSE_STD_PART_QUERY9(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {

                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("       SELECT PLT_CODE");
                    sbQuery.Append("      ,isnull(STK_TURNING,0) AS STK_TURNING ");
                    sbQuery.Append("      ,isnull(STK_COMPLETE,0) AS STK_COMPLETE ");
                    sbQuery.Append("      ,isnull(STK_TOTAL,0) AS STK_TOTAL ");
                    sbQuery.Append("  FROM LSE_STD_PART");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@PART_CODE", "PART_CODE = @PART_CODE"));
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

        //품목가져오기(그리드용)
        public static DataTable LSE_STD_PART_QUERY10(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT P.PLT_CODE");
                    sbQuery.Append(" ,P.PART_CODE");
                    sbQuery.Append(" ,P.PART_NAME");
                    sbQuery.Append(" ,P.PART_PRODTYPE");
                    sbQuery.Append(" ,P.MAT_SPEC");
                    sbQuery.Append(" ,P.MAT_SPEC1");
                    sbQuery.Append(" ,P.BAL_SPEC");
                    sbQuery.Append(" ,P.AUTO_MARGIN_SPEC");
                    sbQuery.Append(" ,P.MAT_TYPE");
                    sbQuery.Append(" ,P.DRAW_NO");
                    sbQuery.Append(" ,P.ZIG_NO");
                    sbQuery.Append(" ,P.MAT_UNIT");
                    sbQuery.Append(" ,P.UNIT_QTY");
                    sbQuery.Append(" ,P.MAT_WEIGHT");
                    sbQuery.Append(" ,P.MAT_WEIGHT1");
                    sbQuery.Append(" ,P.BAL_WEIGHT");
                    sbQuery.Append(" ,P.MAT_UC");
                    sbQuery.Append(" ,P.MAT_COST");
                    sbQuery.Append(" ,P.SPEC_TYPE");
                    sbQuery.Append(" ,P.SAFE_STK_QTY");
                    sbQuery.Append(" ,P.MAT_LTYPE");
                    sbQuery.Append(" ,P.MAT_MTYPE");
                    sbQuery.Append(" ,P.MAT_STYPE");
                    sbQuery.Append(" ,P.ACT_CODE");
                    sbQuery.Append(" ,P.MAT_QLTY");
                    sbQuery.Append(" ,Q.MQLTY_NAME");
                    sbQuery.Append(" ,P.MAIN_VND");
                    sbQuery.Append(" ,P.STK_TURNING");
                    sbQuery.Append(" ,P.STK_COMPLETE");

                    sbQuery.Append(" ,P.FAC_PRICE");
                    sbQuery.Append(" ,P.PROC_COST");
                    sbQuery.Append(" ,P.MNG_COST");
                    sbQuery.Append(" ,P.PROD_COST");
                    sbQuery.Append(" ,P.PROFIT_PRICE");
                    sbQuery.Append(" ,P.PROFIT_RATIO");

                    sbQuery.Append(" ,P.SCOMMENT");
                    sbQuery.Append(" ,P.REV_COMMENT");
                    sbQuery.Append(" ,P.STK_LOCATION");
                    sbQuery.Append(" ,P.REV_PART_CODE");
                    sbQuery.Append(" ,P.REG_DATE");
                    sbQuery.Append(" ,P.REG_EMP");
                    sbQuery.Append(" ,P.PART_SEQ");
                    sbQuery.Append(" , P.CUTTING_CNT ");
                    sbQuery.Append(" ,(SELECT COUNT(*) FROM TSTD_BOM WHERE PLT_CODE = P.PLT_CODE AND BOM_PART_CODE = P.PART_CODE AND PARENT_ID IS NOT NULL) PART_CNT");
                    sbQuery.Append("  FROM LSE_STD_PART P");
                    sbQuery.Append("  LEFT JOIN TMAT_QUC_MASTER Q ");
                    sbQuery.Append("  ON P.PLT_CODE = Q.PLT_CODE ");
                    sbQuery.Append("  AND P.MAT_QLTY = Q.MQLTY_CODE ");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE P.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                        sbWhere.Append(UTIL.GetWhere(row, "@S_REG_DATE,@E_REG_DATE", "P.REG_DATE BETWEEN @S_REG_DATE AND @E_REG_DATE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_LIKE", "(P.PART_CODE LIKE '%' + @PART_LIKE + '%' OR PART_NAME LIKE '%' + @PART_LIKE + '%')"));


                        //search_con : 검색 통합 품목코드,도면번호,품목명,제품규격,형식,재질
                        //part_code, draw_no, part_name, mat_spec1, part_prodtype, mat_qlty
                        string cond = "(P.PART_CODE LIKE '%' + @SEARCH_CON + '%' OR P.DRAW_NO LIKE '%' + @SEARCH_CON + '%' OR ";
                        cond += " P.PART_NAME LIKE '%' + @SEARCH_CON + '%' OR P.MAT_SPEC1 LIKE '%' + @SEARCH_CON + '%' OR P.PART_PRODTYPE LIKE '%' + @SEARCH_CON + '%' OR P.MAT_QLTY LIKE '%' + @SEARCH_CON + '%' ";
                        cond += " OR Q.MQLTY_NAME LIKE '%' + @SEARCH_CON + '%' ) ";
                        sbWhere.Append(UTIL.GetWhere(row, "@SEARCH_CON", cond));

                        //sbWhere.Append(UTIL.GetWhere(row, "@PART_LIKE", "(P.PART_CODE LIKE '%' + @PART_LIKE + '%' OR PART_NAME LIKE '%' + @PART_LIKE + '%')"));


                        sbWhere.Append(UTIL.GetWhere(row, "@PART_CODE", "P.PART_CODE = @PART_CODE "));
                        sbWhere.Append(UTIL.GetWhere(row, "@MAT_LTYPE", "P.MAT_LTYPE = @MAT_LTYPE "));
                        sbWhere.Append(UTIL.GetWhere(row, "@MAT_MTYPE", "P.MAT_MTYPE = @MAT_MTYPE "));
                        sbWhere.Append(UTIL.GetWhere(row, "@MAT_STYPE", "P.MAT_STYPE = @MAT_STYPE "));
                        sbWhere.Append(" AND P.DATA_FLAG = 0");

                        sbWhere.Append(" ORDER BY P.PART_CODE");

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


        public static DataTable LSE_STD_PART_QUERY11(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT 						 ");
                    sbQuery.Append(" MAT_TYPE						 ");
                    sbQuery.Append(" ,MAT_LTYPE						 ");
                    sbQuery.Append(" ,PART_CODE						 ");
                    sbQuery.Append(" ,PART_NAME						 ");
                    sbQuery.Append(" ,MAT_SPEC						 ");
                    sbQuery.Append(" ,MAT_UNIT						 ");
                    sbQuery.Append(" ,PART_PRODTYPE					 ");
                    sbQuery.Append(" ,STK_COMPLETE					 ");
                    sbQuery.Append(" ,STK_TURNING					 ");
                    sbQuery.Append(" ,STK_TOTAL						 ");
                    sbQuery.Append(" FROM LSE_STD_PART				 ");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_LIKE", "(PART_CODE LIKE '%' + @PART_LIKE  + '%' OR PART_NAME LIKE '%' + @PART_LIKE + '%')"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_CODE", "PART_CODE = @PART_CODE "));
                        sbWhere.Append(UTIL.GetWhere(row, "@MAT_TYPE", "MAT_TYPE = @MAT_TYPE "));
                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "DATA_FLAG = @DATA_FLAG "));
                        sbWhere.Append(" AND ISNULL(STK_TURNING,0) <> 0");

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

        public static DataTable LSE_STD_PART_QUERY12(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT 						 ");
                    sbQuery.Append(" MAT_TYPE						 ");
                    sbQuery.Append(" ,MAT_LTYPE						 ");
                    sbQuery.Append(" ,PART_CODE						 ");
                    sbQuery.Append(" ,PART_NAME						 ");
                    sbQuery.Append(" ,MAT_SPEC						 ");
                    sbQuery.Append(" ,MAT_UNIT						 ");
                    sbQuery.Append(" ,PART_PRODTYPE					 ");
                    sbQuery.Append(" ,STK_COMPLETE					 ");
                    sbQuery.Append(" ,STK_TURNING					 ");
                    sbQuery.Append(" ,STK_TOTAL						 ");
                    sbQuery.Append(" FROM LSE_STD_PART				 ");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_LIKE", "(PART_CODE LIKE '%' + @PART_LIKE  + '%' OR PART_NAME LIKE '%' + @PART_LIKE + '%')"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_CODE", "PART_CODE = @PART_CODE "));
                        sbWhere.Append(UTIL.GetWhere(row, "@MAT_TYPE", "MAT_TYPE = @MAT_TYPE "));
                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "DATA_FLAG = @DATA_FLAG "));

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

        public static DataTable LSE_STD_PART_QUERY13(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {

                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("SELECT P.PLT_CODE ");
                    sbQuery.Append(" ,P.PART_CODE ");
                    sbQuery.Append(" ,P.PART_NAME ");
                    sbQuery.Append(" ,P.PART_ENAME ");
                    sbQuery.Append(" ,P.PART_SEQ ");
                    sbQuery.Append(" ,P.MAT_TYPE ");
                    sbQuery.Append(" ,P.PART_PRODTYPE ");
                    sbQuery.Append(" ,P.DRAW_NO ");
                    sbQuery.Append(" ,P.ZIG_NO ");
                    sbQuery.Append(" ,P.MAT_LTYPE ");
                    sbQuery.Append(" ,P.MAT_MTYPE ");
                    sbQuery.Append(" ,P.MAT_UNIT ");
                    sbQuery.Append(" ,P.MAT_UC ");
                    sbQuery.Append(" ,P.MAT_COST ");
                    sbQuery.Append(" ,P.MAT_UC AS UNIT_COST ");
                    sbQuery.Append(" ,P.MAT_COST AS AMT ");
                    sbQuery.Append(" ,P.MAT_QLTY ");
                    sbQuery.Append(" ,P.MAT_QLTY AS PART_QLTY ");
                    sbQuery.Append(" ,QLTY.MQLTY_NAME AS MAT_QLTY_NAME ");
                    sbQuery.Append(" ,P.MAT_QLTY AS PART_QTY");
                    sbQuery.Append(" ,QLTY.MQLTY_NAME AS PART_QLTY_NAME ");
                    sbQuery.Append(" ,P.MAIN_VND ");
                    sbQuery.Append(" ,VEN.VEN_NAME AS MAIN_VND_NAME ");
                    sbQuery.Append(" ,P.STD_PT_NUM ");
                    sbQuery.Append(" ,P.SCOMMENT AS PT_SCOMMENT ");
                    sbQuery.Append(" ,NULL AS SCOMMENT ");
                    sbQuery.Append(" ,P.REG_DATE ");
                    sbQuery.Append(" ,P.REG_EMP ");
                    sbQuery.Append(" ,REG_EMP.EMP_NAME AS REG_EMP_NAME ");
                    sbQuery.Append(" ,P.MDFY_DATE ");
                    sbQuery.Append(" ,P.MDFY_EMP ");
                    sbQuery.Append(" ,MDFY_EMP.EMP_NAME AS MDFY_EMP_NAME ");
                    sbQuery.Append(" ,P.DATA_FLAG ");
                    sbQuery.Append(" ,P.SPEC_TYPE ");
                    sbQuery.Append(" ,P.MAT_STYPE ");
                    sbQuery.Append(" ,P.MAT_SPEC ");
                    sbQuery.Append(" ,P.MAT_SPEC1 ");
                    sbQuery.Append(" ,P.BAL_SPEC AS BALJU_SPEC ");
                    sbQuery.Append(" ,P.MAT_WEIGHT");
                    sbQuery.Append(" ,P.MAT_WEIGHT1");
                    sbQuery.Append(" ,P.BAL_WEIGHT");
                    sbQuery.Append(" ,P.LOAD_FLAG ");
                    sbQuery.Append(" ,P.INS_FLAG ");
                    sbQuery.Append(" ,P.ACT_CODE ");
                    sbQuery.Append(" ,P.SAFE_STK_QTY ");
                    sbQuery.Append(" ,P.STK_LOCATION ");
                    sbQuery.Append(" ,P.AUTO_CREATE ");
                    sbQuery.Append(" ,P.AUTO_MARGIN ");
                    sbQuery.Append(" ,P.AUTO_MARGIN_SPEC ");
                    sbQuery.Append(" ,P.STK_MNG ");
                    sbQuery.Append(" ,P.IF_PART_CODE ");
                    sbQuery.Append(" ,P.UNIT_QTY");
                    sbQuery.Append(" ,P.UNIT_QTY AS QTY");
                    sbQuery.Append(" ,P.UNIT_QTY AS COMPARE_QTY");
                    sbQuery.Append(" ,P.UNIT_QTY AS BOM_QTY");
                    sbQuery.Append(" ,0 AS BOM_SEQ ");
                    sbQuery.Append(" ,P.REV_PART_CODE");
                    sbQuery.Append(" ,P.CUTTING_CNT ");
                    sbQuery.Append(" FROM LSE_STD_PART P ");
                    sbQuery.Append("LEFT JOIN TMAT_QUC_MASTER QLTY ");
                    sbQuery.Append("ON P.PLT_CODE = QLTY.PLT_CODE AND P.MAT_QLTY = QLTY.MQLTY_CODE ");
                    sbQuery.Append("LEFT JOIN TSTD_VENDOR VEN ");
                    sbQuery.Append("ON P.PLT_CODE = VEN.PLT_CODE AND P.MAIN_VND = VEN.VEN_CODE ");
                    sbQuery.Append("LEFT JOIN TSTD_EMPLOYEE  REG_EMP ");
                    sbQuery.Append("ON P.PLT_CODE = REG_EMP.PLT_CODE AND P.REG_EMP = REG_EMP.EMP_CODE ");
                    sbQuery.Append("LEFT JOIN TSTD_EMPLOYEE  MDFY_EMP ");
                    sbQuery.Append("ON P.PLT_CODE = MDFY_EMP.PLT_CODE AND P.MDFY_EMP = MDFY_EMP.EMP_CODE");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE P.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@PART_CODE", "P.PART_CODE = @PART_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_REG_DATE,@E_REG_DATE", "(P.REG_DATE BETWEEN @S_REG_DATE AND @E_REG_DATE)"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_LIKE", "(P.PART_CODE LIKE '%' +  @PART_LIKE + '%' OR P.PART_NAME  LIKE '%' +  @PART_LIKE + '%')"));
                        //sbWhere.Append(UTIL.GetWhere(row, "@PART_PRODTYPE_LIKE", "(P.PART_PRODTYPE LIKE '%' +  @PART_PRODTYPE_LIKE + '%' OR P.PART_NAME  LIKE '%' +  @PART_PRODTYPE_LIKE + '%')"));//모델
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_PRODTYPE", "P.PART_PRODTYPE = @PART_PRODTYPE"));//부품제작구분
                        sbWhere.Append(UTIL.GetWhere(row, "@STD_PT_NUM_LIKE", "(P.STD_PT_NUM LIKE '%' + @STD_PT_NUM_LIKE + '%')"));
                        sbWhere.Append(UTIL.GetWhere(row, "@SPEC_LIKE", "(P.MAT_SPEC LIKE '%' + @SPEC_LIKE + '%' OR P.MAT_SPEC1 LIKE '%' + @SPEC_LIKE + '%')"));
                        sbWhere.Append(UTIL.GetWhere(row, "@MAT_TYPE", "P.MAT_TYPE = @MAT_TYPE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@MAT_LTYPE", "P.MAT_LTYPE = @MAT_LTYPE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@MAT_MTYPE", "P.MAT_MTYPE = @MAT_MTYPE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@MAT_STYPE", "P.MAT_STYPE = @MAT_STYPE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@STK_MNG", "P.STK_MNG = @STK_MNG"));
                        sbWhere.Append(UTIL.GetWhere(row, "@MAT_LTYPE_IN", "P.MAT_LTYPE IN (@MAT_LTYPE_IN)"));
                        sbWhere.Append(UTIL.GetWhere(row, "@DRAW_NO", "P.DRAW_NO LIKE '%' + @DRAW_NO + '%'"));
                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "P.DATA_FLAG = @DATA_FLAG"));

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

        public static DataTable LSE_STD_PART_QUERY14(DataTable dtParam, BizExecute.BizExecute bizExecute )
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT P.PLT_CODE");
                    sbQuery.Append(" ,P.PART_CODE");
                    sbQuery.Append(" ,P.PART_NAME");
                    sbQuery.Append(" ,P.PART_PRODTYPE");
                    sbQuery.Append(" ,P.MAT_SPEC");
                    sbQuery.Append(" ,P.MAT_SPEC1");
                    sbQuery.Append(" ,P.BAL_SPEC");
                    sbQuery.Append(" ,P.AUTO_MARGIN_SPEC");
                    sbQuery.Append(" ,P.MAT_TYPE");
                    sbQuery.Append(" ,P.DRAW_NO");
                    sbQuery.Append(" ,P.ZIG_NO");
                    sbQuery.Append(" ,P.MAT_UNIT");
                    sbQuery.Append(" ,P.UNIT_QTY");
                    sbQuery.Append(" ,P.MAT_WEIGHT");
                    sbQuery.Append(" ,P.MAT_WEIGHT1");
                    sbQuery.Append(" ,P.BAL_WEIGHT");
                    sbQuery.Append(" ,P.MAT_UC");
                    sbQuery.Append(" ,P.MAT_COST");
                    sbQuery.Append(" ,P.SPEC_TYPE");
                    sbQuery.Append(" ,P.SAFE_STK_QTY");
                    sbQuery.Append(" ,P.MAT_LTYPE");
                    sbQuery.Append(" ,P.MAT_MTYPE");
                    sbQuery.Append(" ,P.MAT_STYPE");
                    sbQuery.Append(" ,P.ACT_CODE");
                    sbQuery.Append(" ,P.MAT_QLTY");
                    sbQuery.Append(" ,Q.MQLTY_NAME");
                    sbQuery.Append(" ,P.MAIN_VND");
                    sbQuery.Append(" ,MV.VEN_NAME AS MAIN_VND_NAME");
                    sbQuery.Append(" ,P.STK_TURNING");
                    sbQuery.Append(" ,P.STK_COMPLETE");

                    sbQuery.Append(" ,P.FAC_PRICE");
                    sbQuery.Append(" ,P.PROC_COST");
                    sbQuery.Append(" ,P.MNG_COST");
                    sbQuery.Append(" ,P.PROD_COST");
                    sbQuery.Append(" ,P.PROFIT_PRICE");
                    sbQuery.Append(" ,P.PROFIT_RATIO");

                    sbQuery.Append(" ,P.JIG_CONTENTS");
                    sbQuery.Append(" ,P.JIG_COST");
                    sbQuery.Append(" ,P.ETC_CONTENTS");
                    sbQuery.Append(" ,P.ETC_COST");

                    sbQuery.Append(" ,P.SCOMMENT");
                    sbQuery.Append(" ,P.REV_COMMENT");
                    sbQuery.Append(" ,P.STK_LOCATION");
                    sbQuery.Append(" ,P.REV_PART_CODE");
                    sbQuery.Append(" ,P.REG_DATE");
                    sbQuery.Append(" ,P.REG_EMP");
                    sbQuery.Append(" ,P.PART_SEQ");
                    sbQuery.Append(" ,P.IS_TURNING");
                    sbQuery.Append(" ,P.CUTTING_CNT ");
                    sbQuery.Append(" ,(SELECT COUNT(*) FROM TSTD_BOM WHERE PLT_CODE = P.PLT_CODE AND BOM_PART_CODE = P.PART_CODE AND PARENT_ID IS NOT NULL) PART_CNT");
                    sbQuery.Append("  FROM LSE_STD_PART P");
                    sbQuery.Append("  LEFT JOIN TMAT_QUC_MASTER Q ");
                    sbQuery.Append("  ON P.PLT_CODE = Q.PLT_CODE ");
                    sbQuery.Append("  AND P.MAT_QLTY = Q.MQLTY_CODE ");

                    sbQuery.Append("  LEFT JOIN TSTD_CODES CD ");
                    sbQuery.Append("  ON P.PLT_CODE = CD.PLT_CODE ");
                    sbQuery.Append("  AND P.PART_PRODTYPE = CD.CD_CODE ");
                    sbQuery.Append("  AND CD.CAT_CODE = 'M007' ");

                    sbQuery.Append("  LEFT JOIN TSTD_VENDOR MV ");
                    sbQuery.Append("  ON P.PLT_CODE = MV.PLT_CODE ");
                    sbQuery.Append("  AND P.MAIN_VND = MV.VEN_CODE ");
                    

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE P.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                        sbWhere.Append(UTIL.GetWhere(row, "@S_REG_DATE,@E_REG_DATE", "P.REG_DATE BETWEEN @S_REG_DATE AND @E_REG_DATE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_LIKE", "(P.PART_CODE LIKE '%' + @PART_LIKE + '%' OR PART_NAME LIKE '%' + @PART_LIKE + '%')"));


                        //search_con : 검색 통합 품목코드,도면번호,품목명,제품규격,형식,재질
                        //part_code, draw_no, part_name, mat_spec1, part_prodtype, mat_qlty
                        string cond = "(P.PART_CODE LIKE '%' + @SEARCH_CON + '%' OR P.DRAW_NO LIKE '%' + @SEARCH_CON + '%' OR ";
                        cond += " P.PART_NAME LIKE '%' + @SEARCH_CON + '%' OR P.MAT_SPEC1 LIKE '%' + @SEARCH_CON + '%' OR CD.CD_NAME LIKE '%' + @SEARCH_CON + '%'  ";
                        cond += " OR Q.MQLTY_NAME LIKE '%' + @SEARCH_CON + '%'  ";

                        cond += " OR P.SCOMMENT LIKE '%' + @SEARCH_CON + '%' OR P.REV_COMMENT LIKE '%' + @SEARCH_CON + '%' OR MV.VEN_NAME LIKE '%' + @SEARCH_CON + '%' ) ";
                        sbWhere.Append(UTIL.GetWhere(row, "@SEARCH_CON", cond));

                        //sbWhere.Append(UTIL.GetWhere(row, "@PART_LIKE", "(P.PART_CODE LIKE '%' + @PART_LIKE + '%' OR PART_NAME LIKE '%' + @PART_LIKE + '%')"));


                        sbWhere.Append(UTIL.GetWhere(row, "@PART_CODE", "P.PART_CODE = @PART_CODE "));
                        sbWhere.Append(UTIL.GetWhere(row, "@MAT_LTYPE", "P.MAT_LTYPE = @MAT_LTYPE "));
                        sbWhere.Append(UTIL.GetWhere(row, "@MAT_MTYPE", "P.MAT_MTYPE = @MAT_MTYPE "));
                        sbWhere.Append(UTIL.GetWhere(row, "@MAT_STYPE", "P.MAT_STYPE = @MAT_STYPE "));
                        sbWhere.Append(" AND P.DATA_FLAG = 0");

                        sbWhere.Append(" ORDER BY P.PART_CODE");

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
        public static DataTable LSE_STD_PART_QUERY15(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {

                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("  SELECT P.PART_CODE      ");
                    sbQuery.Append("  	, P.PART_NAME         ");
                    sbQuery.Append("  	, P.PART_PRODTYPE    ");
                    sbQuery.Append("  	, P.MAT_SPEC1          ");
                    sbQuery.Append("  	, P.MAT_SPEC           ");
                    sbQuery.Append("  	, P.MAT_WEIGHT           ");
                    sbQuery.Append("  	, P.MAT_WEIGHT1           ");
                    sbQuery.Append("  	, P.DRAW_NO           ");
                    sbQuery.Append("  	, P.ZIG_NO           ");
                    sbQuery.Append("  	, P.MAT_LTYPE          ");
                    sbQuery.Append("  	, P.MAT_MTYPE         ");
                    sbQuery.Append("  	, P.MAT_STYPE          ");
                    sbQuery.Append("  	, P.STK_LOCATION      ");
                    sbQuery.Append("    , P.STK_LOCATION_DETAIL");
                    sbQuery.Append("  	, ISNULL(P.STK_COMPLETE, 0) AS STK_COMPLETE      ");
                    sbQuery.Append("  	, ISNULL(P.STK_TURNING, 0) AS STK_TURNING      ");
                    sbQuery.Append("  	, ISNULL(P.STK_COMPLETE, 0) AS O_STK_COMPLETE     ");
                    sbQuery.Append("  	, ISNULL(P.STK_TURNING, 0)  AS O_STK_TURNING     ");
                    sbQuery.Append("  	, ISNULL(P.STK_TOTAL, 0) AS STK_TOTAL           ");
                    sbQuery.Append("  	, P.MAT_TYPE            ");
                    sbQuery.Append("  	, P.PART_SEQ            ");
                    sbQuery.Append("      , ISNULL(W.PLN_QTY, 0) - ISNULL(W.FNS_QTY, 0) - ISNULL(W.NG_QTY, 0) AS WIP_QTY ");
                    sbQuery.Append("      , ISNULL(P.STK_COMPLETE, 0) + ISNULL(P.STK_TURNING, 0) + (ISNULL(W.PLN_QTY, 0) - ISNULL(W.FNS_QTY, 0) - ISNULL(W.NG_QTY, 0)) AS STK_SUM ");
                    sbQuery.Append("  FROM LSE_STD_PART P ");

                    sbQuery.Append("    LEFT JOIN (SELECT W.PLT_CODE, W.PART_CODE, ");
                    sbQuery.Append("              SUM(W.PART_QTY) AS PLN_QTY,     ");
                    sbQuery.Append("              SUM(W.FNS_QTY) AS FNS_QTY,      ");
                    sbQuery.Append("              SUM(W.NG_QTY) AS NG_QTY         ");
                    sbQuery.Append("    	FROM TSHP_WORKORDER W JOIN TORD_PRODUCT P       ");
                    sbQuery.Append("    	 ON W.PLT_CODE = P.PLT_CODE           ");
                    sbQuery.Append("    	 AND W.PROD_CODE = P.PROD_CODE        ");
                    sbQuery.Append("    	 AND W.PART_CODE = P.PART_CODE        ");
                    sbQuery.Append("    	  JOIN TORD_ITEM I                    ");
                    sbQuery.Append("    	  ON P.PLT_CODE = I.PLT_CODE          ");
                    sbQuery.Append("    	  AND P.ITEM_CODE = I.ITEM_CODE       ");
                    sbQuery.Append("    	  JOIN TSTD_VENDOR V                  ");
                    sbQuery.Append("    	  ON I.PLT_CODE = V.PLT_CODE          ");
                    sbQuery.Append("    	  AND I.CVND_CODE = V.VEN_CODE        ");
                    sbQuery.Append("    	WHERE W.DATA_FLAG = 0                 ");
                    sbQuery.Append("    	  AND I.DATA_FLAG = 0                 ");
                    sbQuery.Append("    	  AND V.ITEM_AUTO_CODE IN ('H', 'S')   ");
                    sbQuery.Append("    	  AND W.WO_FLAG <> '4'                ");
                    sbQuery.Append("    	  AND W.IS_LAST = '1'                 ");
                    sbQuery.Append("    	  GROUP BY W.PLT_CODE, W.PART_CODE    ");
                    sbQuery.Append("    	  ) W                                  ");

                    sbQuery.Append("    ON P.PLT_CODE = W.PLT_CODE ");
                    sbQuery.Append("    AND P.PART_CODE = W.PART_CODE ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE P.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "P.DATA_FLAG = @DATA_FLAG"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_LIKE", "(P.PART_CODE LIKE '%' + @PART_LIKE + '%' OR P.PART_NAME LIKE '%' + @PART_LIKE + '%')"));
                        sbWhere.Append(UTIL.GetWhere(row, "@SPEC_LIKE", "(P.MAT_SPEC LIKE '%' + @SPEC_LIKE + '%' OR P.MAT_SPEC1 LIKE '%' + @SPEC_LIKE + '%')"));
                        sbWhere.Append(UTIL.GetWhere(row, "@DRAW_LIKE", " P.DRAW_NO LIKE '%' + @DRAW_LIKE + '%'"));

                        sbWhere.Append("  ORDER BY P.PART_CODE   ");

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


        public static DataTable LSE_STD_PART_QUERY16(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT ");
                    sbQuery.Append(" PT.MAT_TYPE ");
                    sbQuery.Append(" ,PT.MAT_LTYPE ");
                    sbQuery.Append(" ,PT.PART_CODE ");
                    sbQuery.Append(" ,PT.PART_NAME ");
                    sbQuery.Append(" ,PT.MAT_SPEC ");
                    sbQuery.Append(" ,PT.MAT_UNIT ");
                    sbQuery.Append(" ,PT.PART_PRODTYPE ");
                    sbQuery.Append(" ,PT.STK_COMPLETE ");
                    sbQuery.Append(" ,PT.STK_TURNING ");
                    sbQuery.Append(" ,PT.STK_TOTAL ");

                    sbQuery.Append(" ,CASE WHEN BM.PART_CODE IS NULL THEN 0 ELSE 1 END AS IS_BOM_REG ");

                    sbQuery.Append(" FROM LSE_STD_PART PT ");
                    sbQuery.Append(" LEFT JOIN (SELECT PLT_CODE,PART_CODE FROM TORD_BOM_MASTER GROUP BY PLT_CODE,PART_CODE) BM ");
                    sbQuery.Append(" ON PT.PLT_CODE = BM.PLT_CODE ");
                    sbQuery.Append(" AND PT.PART_CODE = BM.PART_CODE ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE PT.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_LIKE", "(PT.PART_CODE LIKE '%' + @PART_LIKE  + '%' OR PT.PART_NAME LIKE '%' + @PART_LIKE + '%')"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_CODE", "PT.PART_CODE = @PART_CODE "));
                        sbWhere.Append(UTIL.GetWhere(row, "@MAT_TYPE", "PT.MAT_TYPE = @MAT_TYPE "));
                        sbWhere.Append(UTIL.GetWhere(row, "@MAT_LTYPE", "PT.MAT_LTYPE = @MAT_LTYPE "));
                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "PT.DATA_FLAG = @DATA_FLAG "));
                        sbWhere.Append(UTIL.GetWhere(row, "@IS_REG", "BM.PART_CODE IS NOT NULL "));

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

        public static DataTable LSE_STD_PART_QUERY17(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT A.PROD_CODE, A.PART_CODE, B.PART_NAME, B.PLT_CODE AS PART_CHECK");
                    sbQuery.Append(" FROM (SELECT PROD_CODE, PART_CODE FROM");
                    sbQuery.Append(" (SELECT PROD_CODE, CHILD_PART_NO AS PART_CODE FROM IF_MES_BOM WHERE IF_RULT = 1 AND LEN(PROD_CODE) > 12");
                    sbQuery.Append(" UNION");
                    sbQuery.Append(" SELECT PROD_CODE, PARENT_PART_NO  AS PART_CODE FROM IF_MES_BOM ");
                    sbQuery.Append(" WHERE IF_RULT = 1 AND LEN(PROD_CODE) > 12 AND PARENT_PART_NO IS NOT NULL) A");
                    sbQuery.Append(" GROUP BY PROD_CODE, PART_CODE) A");
                    sbQuery.Append(" LEFT JOIN LSE_STD_PART B");
                    sbQuery.Append(" ON A.PART_CODE = B.PART_CODE");


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

        public static DataTable LSE_STD_PART_QUERY18(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT");
                    sbQuery.Append(" S.PLT_CODE");
                    sbQuery.Append(" ,S.PART_CODE");
                    sbQuery.Append(" ,S.PART_NAME");
                    sbQuery.Append(" ,S.MAT_LTYPE");
                    sbQuery.Append(" ,S.MAT_MTYPE");
                    sbQuery.Append(" ,S.MAT_STYPE");
                    sbQuery.Append(" ,S.MAT_QLTY");
                    sbQuery.Append(" ,STOCK.STOCK_QTY");
                    sbQuery.Append(" ,S.SAFE_STK_QTY");
                    sbQuery.Append(" ,S.SUPP_VND");
                    sbQuery.Append(" ,V.VEN_NAME AS SUPP_VND_NAME");
                    sbQuery.Append(" FROM LSE_STD_PART S");
                    sbQuery.Append(" LEFT JOIN (SELECT PLT_CODE, PART_CODE, SUM(PART_QTY) AS STOCK_QTY FROM TMAT_STOCK");
                    sbQuery.Append(" GROUP BY PLT_CODE, PART_CODE) STOCK");
                    sbQuery.Append(" ON S.PART_CODE = STOCK.PART_CODE");
                    sbQuery.Append(" AND S.PLT_CODE = STOCK.PLT_CODE");

                    sbQuery.Append(" LEFT JOIN TSTD_VENDOR V");
                    sbQuery.Append(" ON S.PLT_CODE = V.PLT_CODE");
                    sbQuery.Append(" AND S.SUPP_VND = V.VEN_CODE");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE S.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_CODE", "S.PART_CODE = @PART_CODE "));
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_LIKE", "(S.PART_CODE LIKE '%' + @PART_LIKE + '%' OR S.PART_NAME LIKE '%' + @PART_LIKE + '%')"));
                        sbWhere.Append(UTIL.GetWhere(row, "@MAT_LTYPE", "S.MAT_LTYPE = @MAT_LTYPE "));
                        sbWhere.Append(UTIL.GetWhere(row, "@MAT_MTYPE", "S.MAT_MTYPE = @MAT_MTYPE "));
                        sbWhere.Append(UTIL.GetWhere(row, "@MAT_STYPE", "S.MAT_STYPE = @MAT_STYPE "));
                        sbWhere.Append(UTIL.GetWhere(row, "@IS_MAIN_PART", "S.IS_MAIN_PART = @IS_MAIN_PART "));

                        sbWhere.Append(UTIL.GetWhere(row, "@IS_MAIN", "ISNULL(S.IS_MAIN_PART, '0') = '1'  "));

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

        public static DataTable LSE_STD_PART_QUERY19(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT");
                    sbQuery.Append(" PLT_CODE");
                    sbQuery.Append(" ,PART_CODE");
                    sbQuery.Append(" ,PART_NAME");
                    sbQuery.Append(" ,MAT_QLTY");
                    sbQuery.Append(" ,COST_DES_TIME");
                    sbQuery.Append(" ,COST_CAM_TIME");
                    sbQuery.Append(" ,COST_MILL_TIME");
                    sbQuery.Append(" ,COST_SIDE_TIME");
                    sbQuery.Append(" ,COST_INS_TIME");
                    sbQuery.Append(" ,COST_ASSY_TIME");
                    sbQuery.Append(" ,COST_SHIP_TIME");
                    sbQuery.Append(" FROM LSE_STD_PART ");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_CODE", "PART_CODE = @PART_CODE "));

                        sbWhere.Append(" AND MAT_LTYPE = '33' AND DATA_FLAG = '0'");

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
