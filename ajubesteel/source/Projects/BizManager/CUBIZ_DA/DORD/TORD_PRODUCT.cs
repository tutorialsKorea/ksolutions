using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BizExecute;
using System.Data;

namespace DORD
{
    public class TORD_PRODUCT
    {
        public static DataTable TORD_PRODUCT_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
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
                    sbQuery.Append(" ,ITEM_CODE ");
                    sbQuery.Append(" ,PROD_NAME ");
                    sbQuery.Append(" ,PROD_VERSION ");
                    sbQuery.Append(" ,PROC_FLAG ");
                    sbQuery.Append(" ,PROD_FLAG ");
                    sbQuery.Append(" ,INS_YN ");
                    sbQuery.Append(" ,SOCKET_YN ");
                    sbQuery.Append(" ,PROD_TYPE ");
                    sbQuery.Append(" ,PROD_CATEGORY ");
                    sbQuery.Append(" ,BUSINESS_EMP ");
                    sbQuery.Append(" ,CUSTOMER_EMP ");
                    sbQuery.Append(" ,CUSTDESIGN_EMP ");
                    sbQuery.Append(" ,ACTUATOR_YN ");
                    sbQuery.Append(" ,CVND_CODE ");
                    sbQuery.Append(" ,TVND_CODE ");
                    sbQuery.Append(" ,PROBE_PIN ");
                    sbQuery.Append(" ,CURR_UNIT ");
                    sbQuery.Append(" ,ORD_DATE ");
                    sbQuery.Append(" ,INDUE_DATE ");
                    sbQuery.Append(" ,DUE_DATE ");
                    sbQuery.Append(" ,CHG_DUE_DATE ");
                    sbQuery.Append(" ,END_DATE ");
                    sbQuery.Append(" ,DELIVERY_DATE ");
                    sbQuery.Append(" ,PROD_QTY ");
                    sbQuery.Append(" ,LOAD_FLAG ");
                    sbQuery.Append(" ,LOCK_FLAG ");
                    sbQuery.Append(" ,LOCK_ID ");
                    sbQuery.Append(" ,LOCK_EMP ");
                    sbQuery.Append(" ,PROD_STATE ");
                    sbQuery.Append(" ,INOUT_FLAG ");
                    sbQuery.Append(" ,PO_NO ");
                    sbQuery.Append(" ,ORD_VAT ");
                    sbQuery.Append(" ,PROD_UC ");
                    sbQuery.Append(" ,PROD_COST ");
                    sbQuery.Append(" ,PROD_VAT ");
                    sbQuery.Append(" ,PROD_AMT ");
                    sbQuery.Append(" ,PROD_KIND ");
                    sbQuery.Append(" ,PROD_TYPE1 ");
                    sbQuery.Append(" ,PROD_TYPE2 ");
                    sbQuery.Append(" ,BALJU_TYPE ");
                    sbQuery.Append(" ,INS_FLAG ");
                    sbQuery.Append(" ,TRADE_YN ");
                    sbQuery.Append(" ,TAX_YN ");
                    sbQuery.Append(" ,BILL_YN ");
                    sbQuery.Append(" ,SCOMMENT ");
                    sbQuery.Append(" ,REMARK ");
                    sbQuery.Append(" ,SHIP_FLAG ");
                    sbQuery.Append(" ,PRJ_CODE ");
                    sbQuery.Append(" ,REG_DATE ");
                    sbQuery.Append(" ,REG_EMP ");
                    sbQuery.Append(" ,MDFY_DATE ");
                    sbQuery.Append(" ,MDFY_EMP ");
                    sbQuery.Append(" ,DEL_DATE ");
                    sbQuery.Append(" ,DEL_EMP ");
                    sbQuery.Append(" ,DATA_FLAG ");
                    sbQuery.Append(" ,TRADE_DATE ");
                    sbQuery.Append(" ,TAX_DATE ");
                    sbQuery.Append(" ,PROC_TYPE ");
                    sbQuery.Append(" ,MODULE_TYPE ");
                    sbQuery.Append(" ,PIN_TYPE ");
                    sbQuery.Append(" ,VISION_CLAMP ");
                    sbQuery.Append(" ,VISION_CONNECTOR ");
                    sbQuery.Append(" ,VISION_OPEN ");
                    sbQuery.Append(" ,CLAMP_DIRECTION ");
                    sbQuery.Append(" ,CONNECTOR_DIRECTION ");
                    sbQuery.Append(" ,OPEN_DIRECTION ");
                    sbQuery.Append(" ,GND_PIN ");
                    sbQuery.Append(" ,FIDUCIAL_MARK ");
                    sbQuery.Append(" ,CROSS_MARKING ");
                    sbQuery.Append(" ,VACUUM ");
                    sbQuery.Append(" ,SOCKET_MARKING ");
                    sbQuery.Append(" ,MODULE_IN_TYPE ");
                    sbQuery.Append(" ,IF_PIN_BLOCK ");
                    sbQuery.Append(" ,SOCKET_OPEN_DIRECTION ");
                    sbQuery.Append(" ,DFM_YN ");
                    sbQuery.Append(" ,DFM_DATE ");
                    sbQuery.Append(" ,MSOP_YN ");
                    sbQuery.Append(" ,MSOP_DATE ");
                    sbQuery.Append(" ,DRAW_DATE ");
                    sbQuery.Append(" ,DRAW_TYPE ");
                    sbQuery.Append(" ,MODEL_TYPE ");
                    sbQuery.Append(" ,VISION_TYPE ");
                    sbQuery.Append(" ,VISION_DIRECTION ");
                    sbQuery.Append(" ,PART_CODE ");
                    sbQuery.Append(" ,MODEL_CODE ");
                    sbQuery.Append(" ,IF_FLAG ");
                    sbQuery.Append(" ,ITEM_FLAG ");
                    sbQuery.Append(" ,PROD_PRIORITY ");
                    sbQuery.Append(" ,REV_EMP ");
                    sbQuery.Append(" ,OLD_PROD_STATE ");
                    sbQuery.Append(" ,BALJU_TYPE ");
                    sbQuery.Append(" ,PO_NO ");
                    sbQuery.Append(" ,ISNULL(ASSY_CHG_FLAG, '0') AS ASSY_CHG_FLAG ");
                    sbQuery.Append("  FROM TORD_PRODUCT  ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("  AND PROD_CODE = @PROD_CODE  ");

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


        /// <summary>
        /// 동일한 모델명의 가장 최근 Prod_code 가져오기
        /// </summary>
        /// <param name="dtParam"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataTable TORD_PRODUCT_SER2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("  SELECT TOP 1 ");
                    sbQuery.Append("  PLT_CODE ");
                    sbQuery.Append(" ,PROD_CODE ");
                    sbQuery.Append(" ,ITEM_CODE ");
                    sbQuery.Append(" ,PROD_NAME "); 
                    sbQuery.Append("  FROM TORD_PRODUCT A ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("  AND PROD_NAME = @PROD_NAME  ");
                    sbQuery.Append("  AND (SELECT COUNT(*) FROM TMAT_PARTLIST WHERE PLT_CODE = A.PLT_CODE AND PROD_CODE = A.PROD_CODE AND DATA_FLAG = 0) > 0  ");
                    sbQuery.Append("  AND DATA_FLAG = 0  ");
                    sbQuery.Append("  ORDER BY REG_DATE DESC  ");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PROD_NAME")) isHasColumn = false;

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

        public static void TORD_PRODUCT_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" INSERT INTO TORD_PRODUCT (  ");
                    sbQuery.Append("  PLT_CODE ");
                    sbQuery.Append(" ,PROD_CODE ");
                    sbQuery.Append(" ,ITEM_CODE ");
                    sbQuery.Append(" ,PROD_NAME ");
                    sbQuery.Append(" ,MODEL_TYPE ");
                    sbQuery.Append(" ,MODEL_CODE ");
                    sbQuery.Append(" ,PROD_VERSION ");
                    sbQuery.Append(" ,PROC_TYPE ");
                    sbQuery.Append(" ,PROC_FLAG ");
                    sbQuery.Append(" ,PROD_FLAG ");
                    sbQuery.Append(" ,INS_YN ");
                    sbQuery.Append(" ,SOCKET_YN ");
                    sbQuery.Append(" ,PROD_TYPE ");
                    sbQuery.Append(" ,PROD_CATEGORY ");
                    sbQuery.Append(" ,BUSINESS_EMP ");
                    sbQuery.Append(" ,CUSTOMER_EMP ");
                    sbQuery.Append(" ,CUSTDESIGN_EMP ");
                    sbQuery.Append(" ,ACTUATOR_YN ");
                    sbQuery.Append(" ,CVND_CODE ");
                    sbQuery.Append(" ,TVND_CODE ");
                    sbQuery.Append(" ,PROBE_PIN ");
                    sbQuery.Append(" ,CURR_UNIT ");
                    sbQuery.Append(" ,ORD_DATE ");
                    sbQuery.Append(" ,INDUE_DATE ");
                    sbQuery.Append(" ,DUE_DATE ");
                    sbQuery.Append(" ,CHG_DUE_DATE ");
                    sbQuery.Append(" ,END_DATE ");
                    sbQuery.Append(" ,DELIVERY_DATE ");
                    sbQuery.Append(" ,PROD_QTY ");
                    sbQuery.Append(" ,LOAD_FLAG ");
                    sbQuery.Append(" ,LOCK_FLAG ");
                    sbQuery.Append(" ,LOCK_EMP ");
                    sbQuery.Append(" ,PROD_STATE ");
                    sbQuery.Append(" ,INOUT_FLAG ");
                    sbQuery.Append(" ,ORD_VAT ");
                    sbQuery.Append(" ,PROD_UC ");
                    sbQuery.Append(" ,PROD_COST ");
                    sbQuery.Append(" ,PROD_VAT ");
                    sbQuery.Append(" ,PROD_AMT ");
                    sbQuery.Append(" ,PROD_KIND ");
                    sbQuery.Append(" ,PROD_TYPE1 ");
                    sbQuery.Append(" ,PROD_TYPE2 ");
                    sbQuery.Append(" ,INS_FLAG ");
                    sbQuery.Append(" ,TRADE_YN ");
                    sbQuery.Append(" ,TAX_YN ");
                    sbQuery.Append(" ,BILL_YN ");
                    sbQuery.Append(" ,SCOMMENT ");
                    sbQuery.Append(" ,REMARK ");
                    sbQuery.Append(" ,SHIP_FLAG ");
                    sbQuery.Append(" ,PRJ_CODE ");
                    sbQuery.Append(" ,REG_DATE ");
                    sbQuery.Append(" ,REG_EMP ");
                    sbQuery.Append(" ,DATA_FLAG ");
                    sbQuery.Append(" ,TRADE_DATE ");
                    sbQuery.Append(" ,TAX_DATE ");
                    sbQuery.Append(" ,MODULE_TYPE ");
                    sbQuery.Append(" ,PIN_TYPE ");
                    sbQuery.Append(" ,VISION_TYPE ");
                    sbQuery.Append(" ,VISION_DIRECTION ");
                    sbQuery.Append(" ,GND_PIN ");
                    sbQuery.Append(" ,FIDUCIAL_MARK ");
                    sbQuery.Append(" ,CROSS_MARKING ");
                    sbQuery.Append(" ,VACUUM ");
                    sbQuery.Append(" ,SOCKET_MARKING ");
                    sbQuery.Append(" ,MODULE_IN_TYPE ");
                    sbQuery.Append(" ,IF_PIN_BLOCK ");
                    sbQuery.Append(" ,SOCKET_OPEN_DIRECTION ");
                    sbQuery.Append(" ,DFM_YN ");
                    sbQuery.Append(" ,DFM_DATE ");
                    sbQuery.Append(" ,MSOP_YN ");
                    sbQuery.Append(" ,MSOP_DATE ");
                    sbQuery.Append(" ,DRAW_DATE ");
                    sbQuery.Append(" ,DRAW_TYPE ");
                    sbQuery.Append(" ,PART_CODE ");
                    sbQuery.Append(" ,IF_FLAG ");
                    sbQuery.Append(" ,ITEM_FLAG ");
                    sbQuery.Append(" ,PROD_PRIORITY ");
                    sbQuery.Append(" ,MNG_EMP1 ");
                    sbQuery.Append(" ,MNG_EMP2 ");
                    sbQuery.Append(" ,PO_NO    ");
                    sbQuery.Append(" ,BALJU_TYPE    ");
                    sbQuery.Append(" ,EST_COST    ");
                    sbQuery.Append(" ,SEND_DEV_EMP1 ");
                    sbQuery.Append(" ,SEND_DEV_EMP2 ");
                    sbQuery.Append(" ,DEV_EMP ");
                    sbQuery.Append(" ,OLD_PROD_CODE    ");
                    sbQuery.Append("  ) VALUES (  ");
                    sbQuery.Append("  @PLT_CODE ");
                    sbQuery.Append(" ,@PROD_CODE ");
                    sbQuery.Append(" ,@ITEM_CODE ");
                    sbQuery.Append(" ,@PROD_NAME ");
                    sbQuery.Append(" ,@MODEL_TYPE ");
                    sbQuery.Append(" ,@MODEL_CODE ");
                    sbQuery.Append(" ,@PROD_VERSION ");
                    sbQuery.Append(" ,@PROC_TYPE ");
                    sbQuery.Append(" ,@PROC_FLAG ");
                    sbQuery.Append(" ,@PROD_FLAG ");
                    sbQuery.Append(" ,@INS_YN ");
                    sbQuery.Append(" ,@SOCKET_YN ");
                    sbQuery.Append(" ,@PROD_TYPE ");
                    sbQuery.Append(" ,@PROD_CATEGORY ");
                    sbQuery.Append(" ,@BUSINESS_EMP ");
                    sbQuery.Append(" ,@CUSTOMER_EMP ");
                    sbQuery.Append(" ,@CUSTDESIGN_EMP ");
                    sbQuery.Append(" ,@ACTUATOR_YN ");
                    sbQuery.Append(" ,@CVND_CODE ");
                    sbQuery.Append(" ,@TVND_CODE ");
                    sbQuery.Append(" ,@PROBE_PIN ");
                    sbQuery.Append(" ,@CURR_UNIT ");
                    sbQuery.Append(" ,@ORD_DATE ");
                    sbQuery.Append(" ,@INDUE_DATE ");
                    sbQuery.Append(" ,@DUE_DATE ");
                    sbQuery.Append(" ,@CHG_DUE_DATE ");
                    sbQuery.Append(" ,@END_DATE ");
                    sbQuery.Append(" ,@DELIVERY_DATE ");
                    sbQuery.Append(" ,@PROD_QTY ");
                    sbQuery.Append(" ,@LOAD_FLAG ");
                    sbQuery.Append(" ,@LOCK_FLAG ");
                    sbQuery.Append(" ,@LOCK_EMP ");
                    sbQuery.Append(" ,@PROD_STATE ");
                    sbQuery.Append(" ,@INOUT_FLAG ");
                    sbQuery.Append(" ,@ORD_VAT ");
                    sbQuery.Append(" ,@PROD_UC ");
                    sbQuery.Append(" ,@PROD_COST ");
                    sbQuery.Append(" ,@PROD_VAT ");
                    sbQuery.Append(" ,@PROD_AMT ");
                    sbQuery.Append(" ,@PROD_KIND ");
                    sbQuery.Append(" ,@PROD_TYPE1 ");
                    sbQuery.Append(" ,@PROD_TYPE2 ");
                    sbQuery.Append(" ,@INS_FLAG ");
                    sbQuery.Append(" ,@TRADE_YN ");
                    sbQuery.Append(" ,@TAX_YN ");
                    sbQuery.Append(" ,@BILL_YN ");
                    sbQuery.Append(" ,@SCOMMENT ");
                    sbQuery.Append(" ,@REMARK ");
                    sbQuery.Append(" ,@SHIP_FLAG ");
                    sbQuery.Append(" ,@PRJ_CODE ");
                    sbQuery.Append(" ,GETDATE() ");
                    sbQuery.Append(" ,'" + ConnInfo.UserID + "' ");
                    sbQuery.Append(" ,@DATA_FLAG ");
                    sbQuery.Append(" ,@TRADE_DATE ");
                    sbQuery.Append(" ,@TAX_DATE ");
                    sbQuery.Append(" ,@MODULE_TYPE ");
                    sbQuery.Append(" ,@PIN_TYPE ");
                    sbQuery.Append(" ,@VISION_TYPE ");
                    sbQuery.Append(" ,@VISION_DIRECTION ");
                    sbQuery.Append(" ,@GND_PIN ");
                    sbQuery.Append(" ,@FIDUCIAL_MARK ");
                    sbQuery.Append(" ,@CROSS_MARKING ");
                    sbQuery.Append(" ,@VACUUM ");
                    sbQuery.Append(" ,@SOCKET_MARKING ");
                    sbQuery.Append(" ,@MODULE_IN_TYPE ");
                    sbQuery.Append(" ,@IF_PIN_BLOCK ");
                    sbQuery.Append(" ,@SOCKET_OPEN_DIRECTION ");
                    sbQuery.Append(" ,@DFM_YN ");
                    sbQuery.Append(" ,@DFM_DATE ");
                    sbQuery.Append(" ,@MSOP_YN ");
                    sbQuery.Append(" ,@MSOP_DATE ");
                    sbQuery.Append(" ,@DRAW_DATE ");
                    sbQuery.Append(" ,@DRAW_TYPE ");
                    sbQuery.Append(" ,@PART_CODE ");
                    sbQuery.Append(" ,'0' ");
                    sbQuery.Append(" ,@ITEM_FLAG ");
                    sbQuery.Append(" ,@PROD_PRIORITY ");
                    sbQuery.Append(" ,@MNG_EMP1 ");
                    sbQuery.Append(" ,@MNG_EMP2 ");
                    sbQuery.Append(" ,@PO_NO    ");
                    sbQuery.Append(" ,@BALJU_TYPE    ");
                    sbQuery.Append(" ,@EST_COST    ");
                    sbQuery.Append(" ,@SEND_DEV_EMP1 ");
                    sbQuery.Append(" ,@SEND_DEV_EMP2 ");
                    sbQuery.Append(" ,@DEV_EMP ");
                    sbQuery.Append(" ,@OLD_PROD_CODE    ");
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

        public static void TORD_PRODUCT_UPD(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TORD_PRODUCT SET  ");
                    sbQuery.Append(" PROD_NAME = @PROD_NAME ");
                    sbQuery.Append(" ,PROD_VERSION = @PROD_VERSION ");
                    sbQuery.Append(" ,PROC_TYPE = @PROC_TYPE ");
                    sbQuery.Append(" ,PROC_FLAG = @PROC_FLAG ");
                    sbQuery.Append(" ,PROD_FLAG = @PROD_FLAG ");
                    sbQuery.Append(" ,MODEL_TYPE = @MODEL_TYPE");
                    sbQuery.Append(" ,MODEL_CODE = @MODEL_CODE");
                    sbQuery.Append(" ,INS_YN = @INS_YN ");
                    sbQuery.Append(" ,SOCKET_YN = @SOCKET_YN ");
                    sbQuery.Append(" ,PROD_TYPE = @PROD_TYPE ");
                    sbQuery.Append(" ,PROD_CATEGORY = @PROD_CATEGORY ");
                    sbQuery.Append(" ,BUSINESS_EMP = @BUSINESS_EMP ");
                    sbQuery.Append(" ,CUSTOMER_EMP = @CUSTOMER_EMP ");
                    sbQuery.Append(" ,CUSTDESIGN_EMP = @CUSTDESIGN_EMP ");
                    sbQuery.Append(" ,ACTUATOR_YN = @ACTUATOR_YN ");
                    sbQuery.Append(" ,CVND_CODE = @CVND_CODE ");
                    sbQuery.Append(" ,TVND_CODE = @TVND_CODE ");
                    sbQuery.Append(" ,PROBE_PIN = @PROBE_PIN ");
                    sbQuery.Append(" ,CURR_UNIT = @CURR_UNIT ");
                    sbQuery.Append(" ,ORD_DATE = @ORD_DATE ");
                    sbQuery.Append(" ,INDUE_DATE = @INDUE_DATE ");
                    sbQuery.Append(" ,DUE_DATE = @DUE_DATE ");
                    sbQuery.Append(" ,CHG_DUE_DATE = @CHG_DUE_DATE ");
                    sbQuery.Append(" ,END_DATE = @END_DATE ");
                    //sbQuery.Append(" ,DELIVERY_DATE = @DELIVERY_DATE ");
                    sbQuery.Append(" ,PROD_QTY = @PROD_QTY ");
                    //sbQuery.Append(" ,LOAD_FLAG = @LOAD_FLAG ");
                    //sbQuery.Append(" ,LOCK_FLAG = @LOCK_FLAG ");
                    //sbQuery.Append(" ,LOCK_EMP = @LOCK_EMP ");
                    sbQuery.Append(" ,PROD_STATE = @PROD_STATE ");
                    sbQuery.Append(" ,INOUT_FLAG = @INOUT_FLAG ");
                    sbQuery.Append(" ,ORD_VAT = @ORD_VAT ");
                    sbQuery.Append(" ,PROD_UC = @PROD_UC ");
                    sbQuery.Append(" ,PROD_COST = @PROD_COST ");
                    sbQuery.Append(" ,PROD_VAT = @PROD_VAT ");
                    sbQuery.Append(" ,PROD_AMT = @PROD_AMT ");
                    sbQuery.Append(" ,PROD_KIND = @PROD_KIND ");
                    sbQuery.Append(" ,PROD_TYPE1 = @PROD_TYPE1 ");
                    sbQuery.Append(" ,PROD_TYPE2 = @PROD_TYPE2 ");
                    sbQuery.Append(" ,INS_FLAG = @INS_FLAG ");
                    sbQuery.Append(" ,TRADE_YN = @TRADE_YN ");
                    sbQuery.Append(" ,TAX_YN = @TAX_YN ");
                    sbQuery.Append(" ,BILL_YN = @BILL_YN ");
                    sbQuery.Append(" ,SCOMMENT = @SCOMMENT ");
                    //sbQuery.Append(" ,REMARK = @REMARK ");
                    sbQuery.Append(" ,MODULE_TYPE = @MODULE_TYPE ");
                    sbQuery.Append(" ,PIN_TYPE = @PIN_TYPE ");
                    sbQuery.Append(" ,VISION_TYPE = @VISION_TYPE ");
                    sbQuery.Append(" ,VISION_DIRECTION = @VISION_DIRECTION ");
                    sbQuery.Append(" ,GND_PIN = @GND_PIN ");
                    sbQuery.Append(" ,FIDUCIAL_MARK = @FIDUCIAL_MARK ");
                    sbQuery.Append(" ,CROSS_MARKING = @CROSS_MARKING ");
                    sbQuery.Append(" ,VACUUM = @VACUUM ");
                    sbQuery.Append(" ,SOCKET_MARKING = @SOCKET_MARKING ");
                    sbQuery.Append(" ,MODULE_IN_TYPE = @MODULE_IN_TYPE ");
                    sbQuery.Append(" ,IF_PIN_BLOCK = @IF_PIN_BLOCK ");
                    sbQuery.Append(" ,SOCKET_OPEN_DIRECTION = @SOCKET_OPEN_DIRECTION ");
                    sbQuery.Append(" ,DFM_YN = @DFM_YN ");
                    sbQuery.Append(" ,DFM_DATE = @DFM_DATE ");
                    sbQuery.Append(" ,MSOP_YN = @MSOP_YN ");
                    sbQuery.Append(" ,MSOP_DATE = @MSOP_DATE ");
                    sbQuery.Append(" ,DRAW_DATE = @DRAW_DATE ");
                    sbQuery.Append(" ,DRAW_TYPE = @DRAW_TYPE ");
                    sbQuery.Append(" ,PART_CODE = @PART_CODE ");
                    sbQuery.Append(" ,PROD_PRIORITY = @PROD_PRIORITY ");
                    //sbQuery.Append(" ,IF_FLAG = '0' ");
                    sbQuery.Append(" ,ITEM_FLAG = @ITEM_FLAG");
                    sbQuery.Append(" ,MDFY_DATE = GETDATE() ");
                    sbQuery.Append(" ,MDFY_EMP = '" + ConnInfo.UserID + "'");
                    sbQuery.Append(" ,REV_EMP = '" + ConnInfo.UserID + "'");
                    sbQuery.Append(" ,MNG_EMP1 = @MNG_EMP1 ");
                    sbQuery.Append(" ,MNG_EMP2 = @MNG_EMP2 ");
                    sbQuery.Append(" ,PO_NO = @PO_NO ");
                    sbQuery.Append(" ,BALJU_TYPE = @BALJU_TYPE ");
                    sbQuery.Append(" ,EST_COST = @EST_COST ");
                    sbQuery.Append(" ,SEND_DEV_EMP1 = @SEND_DEV_EMP1 ");
                    sbQuery.Append(" ,SEND_DEV_EMP2 = @SEND_DEV_EMP2 ");
                    sbQuery.Append(" ,OLD_PROD_CODE = @OLD_PROD_CODE ");
                    //sbQuery.Append(" ,DATA_FLAG = @DATA_FLAG ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append("  AND PROD_CODE = @PROD_CODE ");
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

        /// <summary>
        /// 수주상태 변경
        /// </summary>
        /// <param name="dtParam"></param>
        /// <param name="bizExecute"></param>
        public static void TORD_PRODUCT_UPD2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TORD_PRODUCT SET  ");
                    sbQuery.Append(" PROD_STATE = @PROD_STATE ");
                    sbQuery.Append(" ,OLD_PROD_STATE = PROD_STATE ");
                    //sbQuery.Append(" ,IF_FLAG = '0' ");
                    sbQuery.Append(" ,MDFY_DATE = GETDATE() ");
                    sbQuery.Append(" ,MDFY_EMP = '" + ConnInfo.UserID + "'");
                    //sbQuery.Append(" ,DATA_FLAG = @DATA_FLAG ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append("  AND PROD_CODE = @PROD_CODE ");
                    sbQuery.Append("  AND PROD_STATE <> '9' ");
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

        public static void TORD_PRODUCT_UPD2_1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TORD_PRODUCT SET  ");
                    sbQuery.Append(" PROD_STATE = @PROD_STATE ");
                    sbQuery.Append(" ,OLD_PROD_STATE = PROD_STATE ");
                    //sbQuery.Append(" ,IF_FLAG = '0' ");
                    sbQuery.Append(" ,MDFY_DATE = GETDATE() ");
                    sbQuery.Append(" ,MDFY_EMP = '" + ConnInfo.UserID + "'");
                    //sbQuery.Append(" ,DATA_FLAG = @DATA_FLAG ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append("  AND PROD_CODE = @PROD_CODE ");
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

        public static void TORD_PRODUCT_UPD2_2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TORD_PRODUCT SET  ");
                    sbQuery.Append(" PROD_STATE = @PROD_STATE ");
                    sbQuery.Append(" ,OLD_PROD_STATE = PROD_STATE ");
                    sbQuery.Append(" ,IF_FLAG = '0' ");
                    sbQuery.Append(" ,MDFY_DATE = GETDATE() ");
                    sbQuery.Append(" ,MDFY_EMP = '" + ConnInfo.UserID + "'");
                    //sbQuery.Append(" ,DATA_FLAG = @DATA_FLAG ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append("  AND PROD_CODE = @PROD_CODE ");
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


        /// <summary>
        /// 출하지시
        /// </summary>
        /// <param name="dtParam"></param>
        /// <param name="bizExecute"></param>
        public static void TORD_PRODUCT_UPD3(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TORD_PRODUCT SET  ");
                    sbQuery.Append(" SHIP_FLAG = @SHIP_FLAG ");
                    sbQuery.Append(" ,PROD_STATE = @PROD_STATE ");                    
                    sbQuery.Append(" ,OLD_PROD_STATE = PROD_STATE ");
                    sbQuery.Append(" ,MDFY_DATE = GETDATE() ");
                    sbQuery.Append(" ,MDFY_EMP = '" + ConnInfo.UserID + "'");
                    //sbQuery.Append(" ,DATA_FLAG = @DATA_FLAG ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append("  AND PROD_CODE = @PROD_CODE ");
                    sbQuery.Append("  AND PROD_STATE <> '9' ");
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


        /// <summary>
        /// 수주 잠금
        /// </summary>
        /// <param name="dtParam"></param>
        /// <param name="bizExecute"></param>
        public static void TORD_PRODUCT_UPD4(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TORD_PRODUCT SET  ");
                    sbQuery.Append(" LOCK_FLAG = @LOCK_FLAG ");
                    sbQuery.Append(" ,LOCK_EMP = @LOCK_EMP ");
                    sbQuery.Append(" ,MDFY_DATE = GETDATE() ");
                    sbQuery.Append(" ,MDFY_EMP = '" + ConnInfo.UserID + "'");
                    //sbQuery.Append(" ,DATA_FLAG = @DATA_FLAG ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append("  AND PROD_CODE = @PROD_CODE ");
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

        /// <summary>
        /// 수주 잠금 해제
        /// </summary>
        /// <param name="dtParam"></param>
        /// <param name="bizExecute"></param>
        public static void TORD_PRODUCT_UPD5(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TORD_PRODUCT SET  ");
                    sbQuery.Append(" LOCK_FLAG = @LOCK_FLAG ");
                    sbQuery.Append(" ,LOCK_EMP = null ");
                    sbQuery.Append(" ,MDFY_DATE = GETDATE() ");
                    sbQuery.Append(" ,MDFY_EMP = '" + ConnInfo.UserID + "'");
                    //sbQuery.Append(" ,DATA_FLAG = @DATA_FLAG ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append("  AND PROD_CODE = @PROD_CODE ");
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


        /// <summary>
        /// 거래명세표,세금계산서 발행일 관리
        /// </summary>
        /// <param name="dtParam"></param>
        /// <param name="bizExecute"></param>
        public static void TORD_PRODUCT_UPD6(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TORD_PRODUCT SET  ");
                    sbQuery.Append(" TRADE_DATE = @TRADE_DATE ");
                    sbQuery.Append(" ,TAX_DATE = @TAX_DATE ");
                    sbQuery.Append(" ,COL_DATE = @COL_DATE ");
                    sbQuery.Append(" ,COL_PLAN_DATE = @COL_PLAN_DATE ");
                    sbQuery.Append(" ,MDFY_DATE = GETDATE() ");
                    sbQuery.Append(" ,MDFY_EMP = '" + ConnInfo.UserID + "'");
                    //sbQuery.Append(" ,DATA_FLAG = @DATA_FLAG ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append("  AND PROD_CODE = @PROD_CODE ");
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

        public static void TORD_PRODUCT_UPD6_2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TORD_PRODUCT SET  ");
                    sbQuery.Append(" COL_DATE = @COL_DATE ");
                    sbQuery.Append(" ,MDFY_DATE = GETDATE() ");
                    sbQuery.Append(" ,MDFY_EMP = '" + ConnInfo.UserID + "'");
                    //sbQuery.Append(" ,DATA_FLAG = @DATA_FLAG ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append("  AND PROD_CODE = @PROD_CODE ");
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


        /// <summary>
        /// 수주상태 복구
        /// </summary>
        /// <param name="dtParam"></param>
        /// <param name="bizExecute"></param>
        public static void TORD_PRODUCT_UPD7(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TORD_PRODUCT SET  ");
                    sbQuery.Append(" PROD_STATE = OLD_PROD_STATE ");
                    sbQuery.Append(" ,OLD_PROD_STATE = PROD_STATE ");
                    //sbQuery.Append(" ,IF_FLAG = '0' ");
                    sbQuery.Append(" ,MDFY_DATE = GETDATE() ");
                    sbQuery.Append(" ,MDFY_EMP = '" + ConnInfo.UserID + "'");
                    //sbQuery.Append(" ,DATA_FLAG = @DATA_FLAG ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append("  AND PROD_CODE = @PROD_CODE ");
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


        /// <summary>
        /// 출하지시취소
        /// </summary>
        /// <param name="dtParam"></param>
        /// <param name="bizExecute"></param>
        public static void TORD_PRODUCT_UPD8(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TORD_PRODUCT SET  ");
                    sbQuery.Append(" SHIP_FLAG = @SHIP_FLAG ");
                    sbQuery.Append(" ,PROD_STATE = @PROD_STATE ");
                    sbQuery.Append(" ,OLD_PROD_STATE = PROD_STATE ");
                    sbQuery.Append(" ,MDFY_DATE = GETDATE() ");
                    sbQuery.Append(" ,MDFY_EMP = '" + ConnInfo.UserID + "'");
                    //sbQuery.Append(" ,DATA_FLAG = @DATA_FLAG ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append("  AND PROD_CODE = @PROD_CODE ");
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



        /// <summary>
        /// 개발담당자 등록
        /// </summary>
        /// <param name="dtParam"></param>
        /// <param name="bizExecute"></param>
        public static void TORD_PRODUCT_UPD9(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TORD_PRODUCT SET  ");
                    sbQuery.Append(" DEV_EMP = @DEV_EMP ");
                    sbQuery.Append(" ,SEND_DEV_EMP1 = @SEND_DEV_EMP1 ");
                    sbQuery.Append(" ,PLN_DATE = @PLN_DATE ");
                    sbQuery.Append(" ,FIN_DATE = @FIN_DATE ");
                    sbQuery.Append(" ,IS_DRAW = @IS_DRAW ");
                    sbQuery.Append(" ,DRAW_DIR = @DRAW_DIR ");
                    sbQuery.Append(" ,ASSY_CHG_FLAG = @ASSY_CHG_FLAG ");
                    sbQuery.Append(" ,MDFY_DATE = GETDATE() ");
                    sbQuery.Append(" ,MDFY_EMP = '" + ConnInfo.UserID + "'");
                    //sbQuery.Append(" ,DATA_FLAG = @DATA_FLAG ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append("  AND PROD_CODE = @PROD_CODE ");
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


        public static void TORD_PRODUCT_UPD10(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TORD_PRODUCT SET  ");
                    sbQuery.Append(" DES_DATE = @DES_DATE ");
                    sbQuery.Append(" ,MDFY_DATE = GETDATE() ");
                    sbQuery.Append(" ,MDFY_EMP = '" + ConnInfo.UserID + "'");
                    //sbQuery.Append(" ,DATA_FLAG = @DATA_FLAG ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append("  AND PROD_CODE = @PROD_CODE ");
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

        public static void TORD_PRODUCT_UPD11(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TORD_PRODUCT SET  ");
                    sbQuery.Append(" TVND_CODE = @TVND_CODE ");
                    sbQuery.Append(" ,MDFY_DATE = GETDATE() ");
                    sbQuery.Append(" ,MDFY_EMP = '" + ConnInfo.UserID + "'");
                    //sbQuery.Append(" ,DATA_FLAG = @DATA_FLAG ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append("  AND PROD_CODE = @PROD_CODE ");
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

        public static void TORD_PRODUCT_UPD12(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TORD_PRODUCT SET  ");
                    sbQuery.Append(" PROD_BILL_NO = @PROD_BILL_NO ");
                    sbQuery.Append(" ,MDFY_DATE = GETDATE() ");
                    sbQuery.Append(" ,MDFY_EMP = '" + ConnInfo.UserID + "'");
                    //sbQuery.Append(" ,DATA_FLAG = @DATA_FLAG ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append("  AND PROD_CODE = @PROD_CODE ");
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

        public static void TORD_PRODUCT_UPD13(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TORD_PRODUCT SET  ");
                    sbQuery.Append(" COL_DATE = @COL_DATE ");
                    sbQuery.Append(" ,MDFY_DATE = GETDATE() ");
                    sbQuery.Append(" ,MDFY_EMP = '" + ConnInfo.UserID + "'");
                    //sbQuery.Append(" ,DATA_FLAG = @DATA_FLAG ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append("  AND PROD_CODE = @PROD_CODE ");
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

        public static void TORD_PRODUCT_UPD14(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TORD_PRODUCT SET  ");
                    sbQuery.Append(" CHK_FLAG = @CHK_FLAG ");
                    sbQuery.Append(" ,CHK_EMP = @CHK_EMP ");
                    sbQuery.Append(" ,CHK_DATE = @CHK_DATE ");
                    sbQuery.Append(" ,CHK_DEL_EMP = @CHK_DEL_EMP ");
                    sbQuery.Append(" ,CHK_DEL_DATE = @CHK_DEL_DATE ");
                    sbQuery.Append(" ,MDFY_DATE = GETDATE() ");
                    sbQuery.Append(" ,MDFY_EMP = '" + ConnInfo.UserID + "'");
                    //sbQuery.Append(" ,DATA_FLAG = @DATA_FLAG ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append("  AND PROD_CODE = @PROD_CODE ");
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

        /// <summary>
        /// 영업기밀사항 업데이트
        /// </summary>
        /// <param name="dtParam"></param>
        /// <param name="bizExecute"></param>
        public static void TORD_PRODUCT_UPD15(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TORD_PRODUCT SET  ");
                    sbQuery.Append(" REMARK = @REMARK ");
                    sbQuery.Append(" ,MDFY_DATE = GETDATE() ");
                    sbQuery.Append(" ,MDFY_EMP = '" + ConnInfo.UserID + "'");
                    //sbQuery.Append(" ,DATA_FLAG = @DATA_FLAG ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append("  AND PROD_CODE = @PROD_CODE ");
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

        //
        public static void TORD_PRODUCT_UPD16(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TORD_PRODUCT SET  ");
                    sbQuery.Append(" PO_NO = @PO_NO ");
                    sbQuery.Append(" ,MDFY_DATE = GETDATE() ");
                    sbQuery.Append(" ,MDFY_EMP = '" + ConnInfo.UserID + "'");
                    //sbQuery.Append(" ,DATA_FLAG = @DATA_FLAG ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append("  AND PROD_CODE = @PROD_CODE ");
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

        public static void TORD_PRODUCT_UPD17(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TORD_PRODUCT SET  ");
                    sbQuery.Append(" REPEAT_STOP = @REPEAT_STOP ");
                    sbQuery.Append(" ,REPEAT_STOP_EMP = @REPEAT_STOP_EMP ");
                    sbQuery.Append(" ,REPEAT_STOP_DATE = @REPEAT_STOP_DATE ");
                    sbQuery.Append(" ,MDFY_DATE = GETDATE() ");
                    sbQuery.Append(" ,MDFY_EMP = '" + ConnInfo.UserID + "'");
                    //sbQuery.Append(" ,DATA_FLAG = @DATA_FLAG ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append("  AND PROD_CODE = @PROD_CODE ");
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

        public static void TORD_PRODUCT_UDE(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TORD_PRODUCT SET  ");           
                    sbQuery.Append(" DEL_DATE = GETDATE() ");
                    sbQuery.Append(" ,DEL_EMP = '" + ConnInfo.UserID +"'");
                    sbQuery.Append(" ,DATA_FLAG = 2 ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append("  AND PROD_CODE = @PROD_CODE ");
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
    }

    public class TORD_PRODUCT_QUERY
    {
        public static DataTable TORD_PRODUCT_QUERY1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {


                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT P.PLT_CODE");
                    sbQuery.Append(" ,P.PROD_CODE");
                    sbQuery.Append(" ,P.ITEM_CODE");
                    sbQuery.Append(" ,P.PROD_NAME");
                    sbQuery.Append(" ,P.MODEL_TYPE");
                    sbQuery.Append(" ,P.MODEL_CODE");
                    sbQuery.Append(" ,P.PROD_VERSION");
                    sbQuery.Append(" ,P.PROC_TYPE");
                    sbQuery.Append(" ,P.PROC_FLAG");
                    sbQuery.Append(" ,P.PROD_FLAG");
                    sbQuery.Append(" ,P.INS_YN");
                    sbQuery.Append(" ,P.SOCKET_YN");
                    sbQuery.Append(" ,P.PROD_TYPE");
                    sbQuery.Append(" ,P.PROD_CATEGORY");
                    sbQuery.Append(" ,P.BUSINESS_EMP");
                    sbQuery.Append(" ,BSN.EMP_NAME AS BUSINESS_EMP_NAME");
                    sbQuery.Append(" ,P.CUSTOMER_EMP");
                    sbQuery.Append(" ,P.CUSTDESIGN_EMP");
                    sbQuery.Append(" ,P.ACTUATOR_YN");
                    sbQuery.Append(" ,P.CVND_CODE");
                    sbQuery.Append(" ,CVND.VEN_NAME AS CVND_NAME");
                    sbQuery.Append(" ,P.TVND_CODE");
                    sbQuery.Append(" ,TVND.BVEN_NAME AS TVND_NAME");
                    sbQuery.Append(" ,P.PROBE_PIN");
                    sbQuery.Append(" ,P.CURR_UNIT");
                    sbQuery.Append(" ,P.ORD_DATE");
                    sbQuery.Append(" ,P.INDUE_DATE");
                    sbQuery.Append(" ,P.DUE_DATE");
                    sbQuery.Append(" ,P.CHG_DUE_DATE");
                    sbQuery.Append(" ,P.END_DATE");
                    sbQuery.Append(" ,P.DELIVERY_DATE");
                    sbQuery.Append(" ,P.PROD_QTY");
                    sbQuery.Append(" ,P.LOAD_FLAG");
                    sbQuery.Append(" ,P.LOCK_FLAG");
                    sbQuery.Append(" ,P.LOCK_EMP");                    
                    sbQuery.Append(" ,P.SHIP_FLAG");
                    sbQuery.Append(" ,P.PROD_STATE");
                    sbQuery.Append(" ,P.INOUT_FLAG");
                    sbQuery.Append(" ,P.ORD_VAT");
                    sbQuery.Append(" ,P.PROD_UC");
                    sbQuery.Append(" ,P.PROD_COST");
                    sbQuery.Append(" ,P.PROD_VAT");
                    sbQuery.Append(" ,P.PROD_AMT");
                    sbQuery.Append(" ,P.PROD_KIND");
                    sbQuery.Append(" ,P.PROD_TYPE1");
                    sbQuery.Append(" ,P.PROD_TYPE2");
                    sbQuery.Append(" ,P.INS_FLAG");
                    sbQuery.Append(" ,P.TAX_DATE");
                    sbQuery.Append(" ,P.TRADE_DATE");
                    sbQuery.Append(" ,P.TRADE_YN");
                    sbQuery.Append(" ,P.TAX_YN");
                    sbQuery.Append(" ,P.BILL_YN");
                    sbQuery.Append(" ,P.SCOMMENT");
                    sbQuery.Append(" ,P.REMARK");
                    sbQuery.Append(" ,P.MODULE_TYPE ");
                    sbQuery.Append(" ,P.PIN_TYPE ");
                    sbQuery.Append(" ,P.VISION_TYPE ");
                    sbQuery.Append(" ,P.VISION_DIRECTION ");
                    sbQuery.Append(" ,P.GND_PIN ");
                    sbQuery.Append(" ,P.FIDUCIAL_MARK ");
                    sbQuery.Append(" ,P.CROSS_MARKING ");
                    sbQuery.Append(" ,P.VACUUM ");
                    sbQuery.Append(" ,P.SOCKET_MARKING ");
                    sbQuery.Append(" ,P.MODULE_IN_TYPE ");
                    sbQuery.Append(" ,P.IF_PIN_BLOCK ");
                    sbQuery.Append(" ,P.SOCKET_OPEN_DIRECTION ");
                    sbQuery.Append(" ,P.MSOP_DFM ");
                    sbQuery.Append(" ,P.MSOP_DFM_DATE ");
                    sbQuery.Append(" ,P.DRAW_DATE ");
                    sbQuery.Append(" ,P.DRAW_TYPE ");
                    sbQuery.Append(" ,P.REG_DATE");
                    sbQuery.Append(" ,P.REG_EMP");
                    sbQuery.Append(" ,REG.EMP_NAME AS REG_EMP_NAME");
                    sbQuery.Append(" ,P.MDFY_DATE");
                    sbQuery.Append(" ,P.MDFY_EMP");
                    sbQuery.Append(" ,MDFY.EMP_NAME AS MDFY_EMP_NAME");
                    sbQuery.Append(", P.PART_CODE");
                    sbQuery.Append(", PT.PART_NAME");
                    sbQuery.Append(" ,P.ITEM_FLAG ");
                    sbQuery.Append(" ,P.PROD_PRIORITY ");
                    sbQuery.Append(" ,P.DFM_YN ");
                    sbQuery.Append(" ,P.DFM_DATE ");
                    sbQuery.Append(" ,P.MSOP_YN ");
                    sbQuery.Append(" ,P.MSOP_DATE ");
                    sbQuery.Append(" ,P.REV_EMP ");
                    sbQuery.Append(" ,REV.EMP_NAME AS REV_NAME ");
                    //sbQuery.Append(" ,(SELECT CASE WHEN PROD_CODE IS NULL THEN 0 ELSE 1 END FROM TMAT_PARTLIST WHERE PLT_CODE = P.PLT_CODE AND PROD_CODE = P.PROD_CODE AND DATA_FLAG = 0 GROUP BY PROD_CODE) AS BOM_FLAG ");
                    sbQuery.Append(" ,CASE WHEN BOM.PROD_CODE IS NULL THEN 0 ELSE 1 END AS BOM_FLAG ");
                    sbQuery.Append(" ,ISNULL(SH.SHIP_QTY,0) AS SHIP_QTY ");
                    sbQuery.Append(" ,SH.SHIP_DATE ");
                    sbQuery.Append(" ,SH.SHIP_END_DATE ");
                    sbQuery.Append(" ,(CASE WHEN (P.PROD_QTY - ISNULL(SH.SHIP_QTY,0)) > 0 THEN (P.PROD_QTY - ISNULL(SH.SHIP_QTY,0)) ELSE 0 END) AS REMAIN_QTY ");
                    sbQuery.Append(" ,P.MNG_EMP1 ");
                    sbQuery.Append(" ,P.MNG_EMP2 ");
                    sbQuery.Append(" ,P.PO_NO ");
                    sbQuery.Append(" ,P.BALJU_TYPE ");
                    sbQuery.Append(" ,P.DEV_EMP  ");
                    sbQuery.Append(" ,PR.DESIGN_DATE ");
                    sbQuery.Append(" ,P.EST_COST ");
                    sbQuery.Append(" ,P.PLN_DATE     ");
                    sbQuery.Append(" ,P.FIN_DATE ");
                    sbQuery.Append(" ,AD.DRAW_EMP ");
                    sbQuery.Append(" ,P.IS_DRAW ");
                    sbQuery.Append(" ,P.DRAW_DIR ");
                    sbQuery.Append(" ,P.EX_BOM ");
                    sbQuery.Append(" ,P.OLD_PROD_CODE ");
                    sbQuery.Append(" ,P.REPEAT_STOP ");
                    sbQuery.Append(" ,P.REPEAT_STOP_EMP ");
                    sbQuery.Append(" ,RST.EMP_NAME AS REPEAT_STOP_EMP_NAME ");
                    sbQuery.Append(" ,P.REPEAT_STOP_DATE ");

                    sbQuery.Append(" ,P.COL_DATE ");

                    sbQuery.Append(" ,P.SEND_DEV_EMP1 ");
                    sbQuery.Append(" ,DEV.EMP_NAME AS SEND_DEV_EMP_NAME1 ");
                    sbQuery.Append(" ,P.SEND_DEV_EMP2 ");
                    sbQuery.Append(" ,DEVV.EMP_NAME AS SEND_DEV_EMP_NAME2 ");

                    sbQuery.Append(" ,ISNULL(P.ASSY_CHG_FLAG, '0') AS ASSY_CHG_FLAG ");

                    sbQuery.Append(" FROM TORD_PRODUCT P");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE REG");
                    sbQuery.Append(" ON P.PLT_CODE = REG.PLT_CODE");
                    sbQuery.Append(" AND P.REG_EMP = REG.EMP_CODE");
                    
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE MDFY");
                    sbQuery.Append(" ON P.PLT_CODE = MDFY.PLT_CODE");
                    sbQuery.Append(" AND P.MDFY_EMP = MDFY.EMP_CODE");
                    
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE BSN");
                    sbQuery.Append(" ON P.PLT_CODE = BSN.PLT_CODE");
                    sbQuery.Append(" AND P.BUSINESS_EMP = BSN.EMP_CODE");
                    
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE REV");
                    sbQuery.Append(" ON P.PLT_CODE = REV.PLT_CODE");
                    sbQuery.Append(" AND P.REV_EMP = REV.EMP_CODE");

                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE RST");
                    sbQuery.Append(" ON P.PLT_CODE = RST.PLT_CODE");
                    sbQuery.Append(" AND P.REPEAT_STOP_EMP = RST.EMP_CODE");

                    sbQuery.Append(" LEFT JOIN TSTD_VENDOR CVND");
                    sbQuery.Append(" ON P.PLT_CODE = CVND.PLT_CODE");
                    sbQuery.Append(" AND P.CVND_CODE = CVND.VEN_CODE");
                    
                    sbQuery.Append(" LEFT JOIN TSTD_BILL_VENDOR TVND");
                    sbQuery.Append(" ON P.PLT_CODE = TVND.PLT_CODE");
                    sbQuery.Append(" AND P.TVND_CODE = TVND.BVEN_CODE");
                    
                    sbQuery.Append(" LEFT JOIN LSE_STD_PART PT");
                    sbQuery.Append(" ON P.PLT_CODE = PT.PLT_CODE");
                    sbQuery.Append(" AND P.PART_CODE = PT.PART_CODE");
                    
                    sbQuery.Append(" LEFT JOIN (SELECT PLT_CODE,PROD_CODE,MAX(SHIP_DATE) AS SHIP_DATE ,SUM(SHIP_QTY) AS SHIP_QTY, MAX(SHIP_END_DATE) AS SHIP_END_DATE FROM TORD_SHIP WHERE DATA_FLAG = 0 GROUP BY PLT_CODE,PROD_CODE) SH");
                    sbQuery.Append(" ON P.PLT_CODE = SH.PLT_CODE");
                    sbQuery.Append(" AND P.PROD_CODE = SH.PROD_CODE");
                    
                    sbQuery.Append(" LEFT JOIN (SELECT PLT_CODE,PROD_CODE,SUM(CASE WO_FLAG WHEN '0' THEN 1 ELSE 0 END) AS NONE_CNT FROM TSHP_WORKORDER WHERE DATA_FLAG = 0 GROUP BY PLT_CODE,PROD_CODE) WO");
                    sbQuery.Append(" ON P.PLT_CODE = WO.PLT_CODE");
                    sbQuery.Append(" AND P.PROD_CODE = WO.PROD_CODE");
                    
                    sbQuery.Append(" LEFT JOIN (SELECT PLT_CODE, PROD_CODE, MIN(REG_DATE) AS DESIGN_DATE FROM TMAT_PARTLIST WHERE DATA_FLAG = 0 GROUP BY PLT_CODE, PROD_CODE) PR");
                    sbQuery.Append(" ON P.PLT_CODE = PR.PLT_CODE ");
                    sbQuery.Append(" AND P.PROD_CODE = PR.PROD_CODE ");

                    sbQuery.Append(" LEFT JOIN (SELECT PLT_CODE, PROD_CODE FROM TMAT_PARTLIST WHERE DATA_FLAG = 0 GROUP BY PLT_CODE, PROD_CODE) BOM");
                    sbQuery.Append(" ON P.PLT_CODE = BOM.PLT_CODE");
                    sbQuery.Append(" AND P.PROD_CODE = BOM.PROD_CODE");

                    sbQuery.Append(" LEFT JOIN (");
                    sbQuery.Append(" SELECT PLT_CODE, PROD_CODE, MAX(DRAW_EMP) AS DRAW_EMP FROM TMAT_PARTLIST");
                    sbQuery.Append(" WHERE ISNULL(O_PT_ID,'') = '' AND DATA_FLAG = '0' AND LEFT(PART_CODE,1) = 'A'");
                    sbQuery.Append(" GROUP BY PLT_CODE, PROD_CODE");
                    sbQuery.Append(" ) AD");
                    sbQuery.Append(" ON P.PLT_CODE = AD.PLT_CODE");
                    sbQuery.Append(" AND P.PROD_CODE = AD.PROD_CODE");

                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE DEV");
                    sbQuery.Append(" ON P.PLT_CODE = DEV.PLT_CODE");
                    sbQuery.Append(" AND P.SEND_DEV_EMP1 = DEV.EMP_CODE");

                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE DEVV");
                    sbQuery.Append(" ON P.PLT_CODE = DEVV.PLT_CODE");
                    sbQuery.Append(" AND P.SEND_DEV_EMP2 = DEVV.EMP_CODE");



                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE P.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_CODE", "P.PROD_CODE = @PROD_CODE"));

                        sbWhere.Append(UTIL.GetWhere(row, "@S_REG_DATE, @E_REG_DATE", "(CONVERT(nvarchar(8),P.REG_DATE,112) BETWEEN @S_REG_DATE AND @E_REG_DATE)"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_ORD_DATE, @E_ORD_DATE", "(P.ORD_DATE BETWEEN @S_ORD_DATE AND @E_ORD_DATE)"));
                        //sbWhere.Append(UTIL.GetWhere(row, "@S_DUE_DATE, @E_DUE_DATE", "(P.DUE_DATE BETWEEN @S_DUE_DATE AND @E_DUE_DATE)"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_DUE_DATE, @E_DUE_DATE", "ISNULL(P.CHG_DUE_DATE, P.DUE_DATE) BETWEEN @S_DUE_DATE AND @E_DUE_DATE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_DELIVERY_DATE, @E_DELIVERY_DATE", "(P.DELIVERY_DATE BETWEEN @S_DELIVERY_DATE AND @E_DELIVERY_DATE)"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_SHIP_DATE, @E_SHIP_DATE", "P.PROD_CODE IN (SELECT PROD_CODE FROM TORD_SHIP WHERE SHIP_DATE BETWEEN @S_SHIP_DATE AND @E_SHIP_DATE AND DATA_FLAG = '0')"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_LIKE", "P.PROD_CODE LIKE '%' + @PROD_LIKE + '%' OR P.PROD_NAME LIKE '%' + @PROD_LIKE + '%'"));
                        sbWhere.Append(UTIL.GetWhere(row, "@BUSINESS_EMP", "P.BUSINESS_EMP = @BUSINESS_EMP"));
                        sbWhere.Append(UTIL.GetWhere(row, "@CVND_LIKE", "P.CVND_CODE LIKE '%' + @CVND_LIKE + '%' OR CVND.VEN_NAME LIKE '%' + @CVND_LIKE + '%'"));
                        sbWhere.Append(UTIL.GetWhere(row, "@CVND_CODE", "P.CVND_CODE = @CVND_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@SHIP_FLAG", "P.SHIP_FLAG = @SHIP_FLAG"));
                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "P.DATA_FLAG = @DATA_FLAG"));
                        sbWhere.Append(UTIL.GetWhere(row, "@ITEM_FLAG", "P.ITEM_FLAG = @ITEM_FLAG"));

                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_FLAG", "P.PROD_FLAG = @PROD_FLAG"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_STATE", "P.PROD_STATE = @PROD_STATE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_STATE_IN", "P.PROD_STATE IN @PROD_STATE_IN", UTIL.SqlCondType.IN));

                        sbWhere.Append(UTIL.GetWhere(row, "@BOM_FLAG", "ISNULL(P.IF_FLAG,0) = '0' "));
                        sbWhere.Append(UTIL.GetWhere(row, "@IS_END", "P.FIN_DATE IS NULL "));
                        sbWhere.Append(UTIL.GetWhere(row, "@IS_REPEAT", "P.PROD_FLAG IN ('NE','RE')"));
                        sbWhere.Append(UTIL.GetWhere(row, "@IS_NEW", "P.PROD_FLAG IN ('NE')"));
                        sbWhere.Append(UTIL.GetWhere(row, "@MODEL", "P.MODEL_TYPE = @MODEL OR P.MODEL_CODE = @MODEL "));
                        
                        sbWhere.Append(UTIL.GetWhere(row, "@HAS_NONE_WO", " WO.NONE_CNT > 0 OR WO.PROD_CODE IS NULL "));

                        sbWhere.Append(UTIL.GetWhere(row, "@SCOMMENT_LIKE", "P.SCOMMENT LIKE '%' + @SCOMMENT_LIKE + '%'"));

                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_KIND", "P.PROD_KIND = @PROD_KIND"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_KINDS", "P.PROD_KIND IN @PROD_KINDS", UTIL.SqlCondType.IN));

                        sbWhere.Append(" ORDER BY P.PROD_CODE ");

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


        public static DataTable TORD_PRODUCT_QUERY2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {


                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT P.PLT_CODE");
                    sbQuery.Append(" ,CASE WHEN (P.PROD_QTY - ISNULL(SH.SHIP_QTY,0))  > 0 THEN '부분출하' ELSE '출하' END AS SHIP_STATE");
                    sbQuery.Append(" ,P.PROD_CODE");
                    sbQuery.Append(" ,P.ITEM_CODE");
                    sbQuery.Append(" ,P.PROD_NAME");
                    sbQuery.Append(" ,P.MODEL_TYPE");
                    sbQuery.Append(" ,P.MODEL_CODE");
                    sbQuery.Append(" ,P.PROD_VERSION");
                    sbQuery.Append(" ,P.PROC_TYPE");
                    sbQuery.Append(" ,P.PROC_FLAG");
                    sbQuery.Append(" ,P.PROD_FLAG");
                    sbQuery.Append(" ,P.INS_YN");
                    sbQuery.Append(" ,P.SOCKET_YN");
                    sbQuery.Append(" ,P.PROD_TYPE");
                    sbQuery.Append(" ,P.PROD_CATEGORY");
                    sbQuery.Append(" ,P.BUSINESS_EMP");
                    sbQuery.Append(" ,P.CUSTOMER_EMP");
                    sbQuery.Append(" ,P.CUSTDESIGN_EMP");
                    sbQuery.Append(" ,P.ACTUATOR_YN");
                    sbQuery.Append(" ,P.CVND_CODE");
                    sbQuery.Append(" ,CVND.VEN_NAME AS CVND_NAME");
                    sbQuery.Append(" ,P.TVND_CODE");
                    sbQuery.Append(" ,TVND.BVEN_NAME AS TVND_NAME");
                    sbQuery.Append(" ,P.PROBE_PIN");
                    sbQuery.Append(" ,P.CURR_UNIT");
                    sbQuery.Append(" ,P.ORD_DATE");
                    sbQuery.Append(" ,P.INDUE_DATE");
                    sbQuery.Append(" ,P.DUE_DATE");
                    sbQuery.Append(" ,P.CHG_DUE_DATE");
                    sbQuery.Append(" ,P.END_DATE");
                    sbQuery.Append(" ,P.DELIVERY_DATE");
                    sbQuery.Append(" ,P.PROD_QTY");
                    sbQuery.Append(" ,P.LOAD_FLAG");
                    sbQuery.Append(" ,P.LOCK_FLAG");
                    sbQuery.Append(" ,P.LOCK_EMP");
                    sbQuery.Append(" ,P.SHIP_FLAG");
                    sbQuery.Append(" ,P.PROD_STATE");
                    sbQuery.Append(" ,P.INOUT_FLAG");
                    sbQuery.Append(" ,P.ORD_VAT");
                    sbQuery.Append(" ,P.PROD_UC");
                    sbQuery.Append(" ,P.PROD_COST");
                    sbQuery.Append(" ,P.PROD_VAT");
                    sbQuery.Append(" ,P.PROD_AMT");
                    sbQuery.Append(" ,P.PROD_KIND");
                    sbQuery.Append(" ,P.PROD_TYPE1");
                    sbQuery.Append(" ,P.PROD_TYPE2");
                    sbQuery.Append(" ,P.INS_FLAG");
                    sbQuery.Append(" ,P.TRADE_YN");
                    sbQuery.Append(" ,P.TAX_YN");
                    sbQuery.Append(" ,P.BILL_YN");
                    sbQuery.Append(" ,P.PART_CODE");
                    sbQuery.Append(" ,(P.PROD_QTY - ISNULL(SH.SHIP_QTY,0)) AS REMAIN_QTY");
                    sbQuery.Append(" ,(P.PROD_QTY - ISNULL(SH.SHIP_QTY,0)) AS SHIP_QTY");
                    sbQuery.Append(" ,ISNULL(SH.SHIP_QTY,0) AS OLD_SHIP_QTY ");
                    sbQuery.Append(" ,'0' AS PROD_LOCATION");
                    sbQuery.Append(" ,P.SCOMMENT");
                    sbQuery.Append(" ,P.REMARK");
                    sbQuery.Append(" ,P.MODULE_TYPE ");
                    sbQuery.Append(" ,P.PIN_TYPE ");
                    sbQuery.Append(" ,P.VISION_TYPE ");
                    sbQuery.Append(" ,P.VISION_DIRECTION ");
                    sbQuery.Append(" ,P.GND_PIN ");
                    sbQuery.Append(" ,P.FIDUCIAL_MARK ");
                    sbQuery.Append(" ,P.CROSS_MARKING ");
                    sbQuery.Append(" ,P.VACUUM ");
                    sbQuery.Append(" ,P.SOCKET_MARKING ");
                    sbQuery.Append(" ,P.MODULE_IN_TYPE ");
                    sbQuery.Append(" ,P.IF_PIN_BLOCK ");
                    sbQuery.Append(" ,P.SOCKET_OPEN_DIRECTION ");
                    sbQuery.Append(" ,P.MSOP_DFM ");
                    sbQuery.Append(" ,P.MSOP_DFM_DATE ");
                    sbQuery.Append(" ,P.DRAW_DATE ");
                    sbQuery.Append(" ,P.DRAW_TYPE ");
                    sbQuery.Append(" ,P.REG_DATE");
                    sbQuery.Append(" ,P.REG_EMP");
                    sbQuery.Append(" ,REG.EMP_NAME AS REG_EMP_NAME");
                    sbQuery.Append(" ,P.MDFY_DATE");
                    sbQuery.Append(" ,P.MDFY_EMP");
                    sbQuery.Append(" ,MDFY.EMP_NAME AS MDFY_EMP_NAME");
                    sbQuery.Append(" ,P.TRADE_DATE");
                    sbQuery.Append(" ,P.TAX_DATE");
                    sbQuery.Append(" ,P.ITEM_FLAG ");
                    sbQuery.Append(" ,P.PROD_PRIORITY ");
                    sbQuery.Append(" ,P.DFM_YN ");
                    sbQuery.Append(" ,P.DFM_DATE ");
                    sbQuery.Append(" ,P.MSOP_YN ");
                    sbQuery.Append(" ,P.MSOP_DATE ");
                    sbQuery.Append(" ,P.PO_NO ");
                    sbQuery.Append(" ,TRADE.BILL_QTY AS TRADE_BILL_QTY ");
                    sbQuery.Append(" ,TAX.BILL_QTY AS TAX_BILL_QTY ");
                    sbQuery.Append(" ,P.EST_COST ");
                    sbQuery.Append(" ,P.BALJU_TYPE ");
                    sbQuery.Append(" FROM TORD_PRODUCT P");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE REG");
                    sbQuery.Append(" ON P.PLT_CODE = REG.PLT_CODE");
                    sbQuery.Append(" AND P.REG_EMP = REG.EMP_CODE");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE MDFY");
                    sbQuery.Append(" ON P.PLT_CODE = MDFY.PLT_CODE");
                    sbQuery.Append(" AND P.MDFY_EMP = MDFY.EMP_CODE");
                    sbQuery.Append(" LEFT JOIN TSTD_VENDOR CVND");
                    sbQuery.Append(" ON P.PLT_CODE = CVND.PLT_CODE");
                    sbQuery.Append(" AND P.CVND_CODE = CVND.VEN_CODE");
                    sbQuery.Append(" LEFT JOIN TSTD_BILL_VENDOR TVND");
                    sbQuery.Append(" ON P.PLT_CODE = TVND.PLT_CODE");
                    sbQuery.Append(" AND P.TVND_CODE = TVND.BVEN_CODE");
                    sbQuery.Append(" LEFT JOIN (SELECT PLT_CODE,PROD_CODE, SUM(ISNULL(SHIP_QTY,0)) AS SHIP_QTY FROM TORD_SHIP WHERE DATA_FLAG = 0 GROUP BY PLT_CODE,PROD_CODE) SH");
                    sbQuery.Append(" ON P.PLT_CODE = SH.PLT_CODE");
                    sbQuery.Append(" AND P.PROD_CODE = SH.PROD_CODE");
                    sbQuery.Append(" LEFT JOIN (SELECT PLT_CODE, PROD_CODE, SUM(BILL_QTY) AS BILL_QTY FROM TORD_PRODUCT_BILL WHERE DATA_FLAG = 0 AND BILL_TYPE = 'TRADE' GROUP BY PLT_CODE,PROD_CODE) TRADE");
                    sbQuery.Append(" ON P.PLT_CODE = TRADE.PLT_CODE");
                    sbQuery.Append(" AND P.PROD_CODE = TRADE.PROD_CODE");
                    sbQuery.Append(" LEFT JOIN (SELECT PLT_CODE, PROD_CODE, SUM(BILL_QTY) AS BILL_QTY FROM TORD_PRODUCT_BILL WHERE DATA_FLAG = 0 AND BILL_TYPE = 'TAX' GROUP BY PLT_CODE,PROD_CODE) TAX");
                    sbQuery.Append(" ON P.PLT_CODE = TAX.PLT_CODE");
                    sbQuery.Append(" AND P.PROD_CODE = TAX.PROD_CODE");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE P.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_CODE", "P.PROD_CODE = @PROD_CODE"));

                        sbWhere.Append(UTIL.GetWhere(row, "@S_REG_DATE, @E_REG_DATE", "(CONVERT(nvarchar(8),P.REG_DATE,112) BETWEEN @S_REG_DATE AND @E_REG_DATE)"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_ORD_DATE, @E_ORD_DATE", "(P.ORD_DATE BETWEEN @S_ORD_DATE AND @E_ORD_DATE)"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_DUE_DATE, @E_DUE_DATE", "(P.DUE_DATE BETWEEN @S_DUE_DATE AND @E_DUE_DATE)"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_DELIVERY_DATE, @E_DELIVERY_DATE", "(P.DELIVERY_DATE BETWEEN @S_DELIVERY_DATE AND @E_DELIVERY_DATE)"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_LIKE", "P.PROD_CODE LIKE '%' + @PROD_LIKE + '%' OR P.PROD_NAME LIKE '%' + @PROD_LIKE + '%'"));
                        sbWhere.Append(UTIL.GetWhere(row, "@CVND_LIKE", "P.CVND_CODE LIKE '%' + @CVND_LIKE + '%' OR CVND.VEN_NAME LIKE '%' + @CVND_LIKE + '%'"));
                        sbWhere.Append(UTIL.GetWhere(row, "@BUSINESS_EMP", "P.BUSINESS_EMP = @BUSINESS_EMP"));
                        sbWhere.Append(UTIL.GetWhere(row, "@SHIP_FLAG", "P.SHIP_FLAG = @SHIP_FLAG"));
                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "P.DATA_FLAG = @DATA_FLAG"));

                        sbWhere.Append(UTIL.GetWhere(row, "@NOT_PROD_KIND", "P.PROD_KIND NOT IN @NOT_PROD_KIND", UTIL.SqlCondType.IN));

                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_KIND", "P.PROD_KIND IN @PROD_KIND", UTIL.SqlCondType.IN));

                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_STATE_IN", "P.PROD_STATE IN @PROD_STATE_IN", UTIL.SqlCondType.IN));

                        sbWhere.Append(" AND (P.PROD_QTY - ISNULL(SH.SHIP_QTY,0)) > 0");

                        sbWhere.Append(" ORDER BY P.PROD_CODE ");

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

        public static DataTable TORD_PRODUCT_QUERY2_1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {


                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT P.PLT_CODE");
                    sbQuery.Append(" ,CASE WHEN (P.PROD_QTY - ISNULL(SH.SHIP_QTY,0))  > 0 THEN '부분출하' ELSE '출하' END AS SHIP_STATE");
                    sbQuery.Append(" ,P.PROD_CODE");
                    sbQuery.Append(" ,P.ITEM_CODE");
                    sbQuery.Append(" ,P.PROD_NAME");
                    sbQuery.Append(" ,P.MODEL_TYPE");
                    sbQuery.Append(" ,P.MODEL_CODE");
                    sbQuery.Append(" ,P.PROD_VERSION");
                    sbQuery.Append(" ,P.PROC_TYPE");
                    sbQuery.Append(" ,P.PROC_FLAG");
                    sbQuery.Append(" ,P.PROD_FLAG");
                    sbQuery.Append(" ,P.INS_YN");
                    sbQuery.Append(" ,P.SOCKET_YN");
                    sbQuery.Append(" ,P.PROD_TYPE");
                    sbQuery.Append(" ,P.PROD_CATEGORY");
                    sbQuery.Append(" ,P.BUSINESS_EMP");
                    sbQuery.Append(" ,P.CUSTOMER_EMP");
                    sbQuery.Append(" ,P.CUSTDESIGN_EMP");
                    sbQuery.Append(" ,P.ACTUATOR_YN");
                    sbQuery.Append(" ,P.CVND_CODE");
                    sbQuery.Append(" ,CVND.VEN_NAME AS CVND_NAME");
                    sbQuery.Append(" ,P.TVND_CODE");
                    sbQuery.Append(" ,TVND.BVEN_NAME AS TVND_NAME");
                    sbQuery.Append(" ,P.PROBE_PIN");
                    sbQuery.Append(" ,P.CURR_UNIT");
                    sbQuery.Append(" ,P.ORD_DATE");
                    sbQuery.Append(" ,P.INDUE_DATE");
                    sbQuery.Append(" ,P.DUE_DATE");
                    sbQuery.Append(" ,P.CHG_DUE_DATE");
                    sbQuery.Append(" ,P.END_DATE");
                    sbQuery.Append(" ,P.DELIVERY_DATE");
                    sbQuery.Append(" ,P.PROD_QTY");
                    sbQuery.Append(" ,P.LOAD_FLAG");
                    sbQuery.Append(" ,P.LOCK_FLAG");
                    sbQuery.Append(" ,P.LOCK_EMP");
                    sbQuery.Append(" ,P.SHIP_FLAG");
                    sbQuery.Append(" ,P.PROD_STATE");
                    sbQuery.Append(" ,P.INOUT_FLAG");
                    sbQuery.Append(" ,P.ORD_VAT");
                    sbQuery.Append(" ,P.PROD_UC");
                    sbQuery.Append(" ,P.PROD_COST");
                    sbQuery.Append(" ,P.PROD_VAT");
                    sbQuery.Append(" ,P.PROD_AMT");
                    sbQuery.Append(" ,P.PROD_KIND");
                    sbQuery.Append(" ,P.PROD_TYPE1");
                    sbQuery.Append(" ,P.PROD_TYPE2");
                    sbQuery.Append(" ,P.INS_FLAG");
                    sbQuery.Append(" ,P.TRADE_YN");
                    sbQuery.Append(" ,P.TAX_YN");
                    sbQuery.Append(" ,P.BILL_YN");
                    sbQuery.Append(" ,P.PART_CODE");

                    sbQuery.Append(" ,(P.PROD_QTY - ISNULL(SH.SHIP_QTY,0)) AS SHIP_QTY");
                    sbQuery.Append(" ,ISNULL(SH.SHIP_QTY,0) AS OLD_SHIP_QTY ");

                    sbQuery.Append(" ,ISNULL(SH.SHIP_QTY,0) * P.PROD_COST AS SHIP_AMT");

                    sbQuery.Append(" ,null AS PROD_LOCATION");
                    sbQuery.Append(" ,P.SCOMMENT");
                    sbQuery.Append(" ,P.REMARK");
                    sbQuery.Append(" ,P.MODULE_TYPE ");
                    sbQuery.Append(" ,P.PIN_TYPE ");
                    sbQuery.Append(" ,P.VISION_TYPE ");
                    sbQuery.Append(" ,P.VISION_DIRECTION ");
                    sbQuery.Append(" ,P.GND_PIN ");
                    sbQuery.Append(" ,P.FIDUCIAL_MARK ");
                    sbQuery.Append(" ,P.CROSS_MARKING ");
                    sbQuery.Append(" ,P.VACUUM ");
                    sbQuery.Append(" ,P.SOCKET_MARKING ");
                    sbQuery.Append(" ,P.MODULE_IN_TYPE ");
                    sbQuery.Append(" ,P.IF_PIN_BLOCK ");
                    sbQuery.Append(" ,P.SOCKET_OPEN_DIRECTION ");
                    sbQuery.Append(" ,P.MSOP_DFM ");
                    sbQuery.Append(" ,P.MSOP_DFM_DATE ");
                    sbQuery.Append(" ,P.DRAW_DATE ");
                    sbQuery.Append(" ,P.DRAW_TYPE ");
                    sbQuery.Append(" ,P.REG_DATE");
                    sbQuery.Append(" ,P.REG_EMP");
                    sbQuery.Append(" ,REG.EMP_NAME AS REG_EMP_NAME");
                    sbQuery.Append(" ,P.MDFY_DATE");
                    sbQuery.Append(" ,P.MDFY_EMP");
                    sbQuery.Append(" ,MDFY.EMP_NAME AS MDFY_EMP_NAME");
                    sbQuery.Append(" ,P.TRADE_DATE");
                    sbQuery.Append(" ,P.TAX_DATE");
                    sbQuery.Append(" ,P.COL_PLAN_DATE");
                    sbQuery.Append(" ,P.ITEM_FLAG ");
                    sbQuery.Append(" ,P.PROD_PRIORITY ");
                    sbQuery.Append(" ,P.DFM_YN ");
                    sbQuery.Append(" ,P.DFM_DATE ");
                    sbQuery.Append(" ,P.MSOP_YN ");
                    sbQuery.Append(" ,P.MSOP_DATE ");
                    sbQuery.Append(" ,TRADE.BILL_QTY AS TRADE_BILL_QTY ");
                    sbQuery.Append(" ,TRADE.BILL_AMT AS TRADE_BILL_AMT ");
                    sbQuery.Append(" ,TAX.BILL_QTY AS TAX_BILL_QTY ");
                    sbQuery.Append(" ,TAX.BILL_AMT AS TAX_BILL_AMT ");

                    sbQuery.Append(" ,COL.BILL_QTY AS COL_BILL_QTY ");
                    sbQuery.Append(" ,COL.BILL_AMT AS COL_BILL_AMT ");

                    sbQuery.Append(" ,P.PROD_BILL_NO ");
                    sbQuery.Append(" ,P.COL_DATE ");
                    sbQuery.Append(" ,P.EST_COST ");
                    sbQuery.Append(" ,P.PO_NO ");
                    sbQuery.Append(" ,SH.SHIP_DATE ");
                    sbQuery.Append(" ,SH.SHIP_END_DATE ");
                    sbQuery.Append(" ,SC.SCOMMENT AS SHIP_SCOMMENT ");

                    sbQuery.Append(" ,P.MNG_EMP1");
                    sbQuery.Append(" ,P.MNG_EMP2");
                    sbQuery.Append(" ,P.BALJU_TYPE");
                    sbQuery.Append(" ,P.DEV_EMP");
                    sbQuery.Append(" ,P.EST_COST");
                    sbQuery.Append(" ,P.PLN_DATE");
                    sbQuery.Append(" ,P.FIN_DATE");
                    sbQuery.Append(" ,P.IS_DRAW");
                    sbQuery.Append(" ,P.DRAW_DIR");
                    sbQuery.Append(" ,P.EX_BOM");
                    sbQuery.Append(" ,P.OLD_PROD_CODE");


                    sbQuery.Append(" FROM TORD_PRODUCT P");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE REG");
                    sbQuery.Append(" ON P.PLT_CODE = REG.PLT_CODE");
                    sbQuery.Append(" AND P.REG_EMP = REG.EMP_CODE");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE MDFY");
                    sbQuery.Append(" ON P.PLT_CODE = MDFY.PLT_CODE");
                    sbQuery.Append(" AND P.MDFY_EMP = MDFY.EMP_CODE");
                    sbQuery.Append(" LEFT JOIN TSTD_VENDOR CVND");
                    sbQuery.Append(" ON P.PLT_CODE = CVND.PLT_CODE");
                    sbQuery.Append(" AND P.CVND_CODE = CVND.VEN_CODE");
                    sbQuery.Append(" LEFT JOIN TSTD_BILL_VENDOR TVND");
                    sbQuery.Append(" ON P.PLT_CODE = TVND.PLT_CODE");
                    sbQuery.Append(" AND P.TVND_CODE = TVND.BVEN_CODE");
                    sbQuery.Append(" LEFT JOIN (SELECT PLT_CODE,PROD_CODE, SUM(ISNULL(SHIP_QTY,0)) AS SHIP_QTY, MAX(SHIP_DATE) AS SHIP_DATE, MAX(SHIP_END_DATE) AS SHIP_END_DATE FROM TORD_SHIP WHERE DATA_FLAG = 0 GROUP BY PLT_CODE,PROD_CODE) SH");
                    sbQuery.Append(" ON P.PLT_CODE = SH.PLT_CODE");
                    sbQuery.Append(" AND P.PROD_CODE = SH.PROD_CODE");
                    sbQuery.Append(" LEFT JOIN (SELECT PLT_CODE, PROD_CODE, SUM(BILL_QTY) AS BILL_QTY, SUM(BILL_AMT) AS BILL_AMT FROM TORD_PRODUCT_BILL WHERE DATA_FLAG = 0 AND BILL_TYPE = 'TRADE' GROUP BY PLT_CODE,PROD_CODE) TRADE");
                    sbQuery.Append(" ON P.PLT_CODE = TRADE.PLT_CODE");
                    sbQuery.Append(" AND P.PROD_CODE = TRADE.PROD_CODE");
                    
                    sbQuery.Append(" LEFT JOIN (SELECT PLT_CODE, PROD_CODE, SUM(BILL_QTY) AS BILL_QTY, SUM(BILL_AMT) AS BILL_AMT FROM TORD_PRODUCT_BILL WHERE DATA_FLAG = 0 AND BILL_TYPE = 'TAX' GROUP BY PLT_CODE,PROD_CODE) TAX");
                    sbQuery.Append(" ON P.PLT_CODE = TAX.PLT_CODE");
                    sbQuery.Append(" AND P.PROD_CODE = TAX.PROD_CODE");

                    sbQuery.Append(" LEFT JOIN (SELECT PLT_CODE, PROD_CODE, SUM(BILL_QTY) AS BILL_QTY, SUM(BILL_AMT) AS BILL_AMT FROM TORD_PRODUCT_BILL WHERE DATA_FLAG = 0 AND BILL_TYPE = 'COL' GROUP BY PLT_CODE,PROD_CODE) COL");
                    sbQuery.Append(" ON P.PLT_CODE = COL.PLT_CODE");
                    sbQuery.Append(" AND P.PROD_CODE = COL.PROD_CODE");

                    sbQuery.Append(" LEFT JOIN (");
                    sbQuery.Append(" SELECT PLT_CODE, PROD_CODE, SCOMMENT FROM");
                    sbQuery.Append(" (");
                    sbQuery.Append(" SELECT PLT_CODE, PROD_CODE, SCOMMENT");
                    sbQuery.Append(" ,ROW_NUMBER() OVER(PARTITION BY PROD_CODE ORDER BY REG_DATE DESC) AS SEQ FROM TORD_SHIP");
                    sbQuery.Append(" WHERE DATA_FLAG = '0'");
                    sbQuery.Append(" ) A");
                    sbQuery.Append(" WHERE SEQ = 1");
                    sbQuery.Append(" ) SC");
                    sbQuery.Append(" ON P.PLT_CODE = SC.PLT_CODE");
                    sbQuery.Append(" AND P.PROD_CODE = SC.PROD_CODE");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE P.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_CODE", "P.PROD_CODE = @PROD_CODE"));

                        sbWhere.Append(UTIL.GetWhere(row, "@S_REG_DATE, @E_REG_DATE", "(CONVERT(nvarchar(8),P.REG_DATE,112) BETWEEN @S_REG_DATE AND @E_REG_DATE)"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_ORD_DATE, @E_ORD_DATE", "(P.ORD_DATE BETWEEN @S_ORD_DATE AND @E_ORD_DATE)"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_DUE_DATE, @E_DUE_DATE", "(P.DUE_DATE BETWEEN @S_DUE_DATE AND @E_DUE_DATE)"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_DELIVERY_DATE, @E_DELIVERY_DATE", "(P.DELIVERY_DATE BETWEEN @S_DELIVERY_DATE AND @E_DELIVERY_DATE)"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_LIKE", "P.PROD_CODE LIKE '%' + @PROD_LIKE + '%' OR P.PROD_NAME LIKE '%' + @PROD_LIKE + '%'"));
                        sbWhere.Append(UTIL.GetWhere(row, "@CVND_LIKE", "P.CVND_CODE LIKE '%' + @CVND_LIKE + '%' OR CVND.VEN_NAME LIKE '%' + @CVND_LIKE + '%'"));
                        sbWhere.Append(UTIL.GetWhere(row, "@BUSINESS_EMP", "P.BUSINESS_EMP = @BUSINESS_EMP"));
                        sbWhere.Append(UTIL.GetWhere(row, "@SHIP_FLAG", "P.SHIP_FLAG = @SHIP_FLAG"));
                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "P.DATA_FLAG = @DATA_FLAG"));

                        sbWhere.Append(UTIL.GetWhere(row, "@S_SHIP_DATE, @E_SHIP_DATE", "P.PROD_CODE IN (SELECT PROD_CODE FROM TORD_SHIP WHERE SHIP_DATE BETWEEN @S_SHIP_DATE AND @E_SHIP_DATE AND DATA_FLAG = '0')"));

                        sbWhere.Append(UTIL.GetWhere(row, "@S_TAX_DATE, @E_TAX_DATE, @BILL_TYPE", "P.PROD_CODE IN (SELECT PROD_CODE FROM TORD_PRODUCT_BILL WHERE BILL_DATE BETWEEN @S_TAX_DATE AND @E_TAX_DATE AND BILL_TYPE = @BILL_TYPE AND DATA_FLAG = '0')"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_TRADE_DATE, @E_TRADE_DATE, @BILL_TYPE", "P.PROD_CODE IN (SELECT PROD_CODE FROM TORD_PRODUCT_BILL WHERE BILL_DATE BETWEEN @S_TRADE_DATE AND @E_TRADE_DATE AND BILL_TYPE = @BILL_TYPE AND DATA_FLAG = '0')"));
                        
                        sbWhere.Append(UTIL.GetWhere(row, "@S_COL_PLAN_DATE, @E_COL_PLAN_DATE, @BILL_TYPE", "P.PROD_CODE IN (SELECT PROD_CODE FROM TORD_PRODUCT_BILL WHERE COL_PLAN_DATE BETWEEN @S_COL_PLAN_DATE AND @E_COL_PLAN_DATE AND BILL_TYPE = @BILL_TYPE AND DATA_FLAG = '0')"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_COL_DATE, @E_COL_DATE, @BILL_TYPE", "P.PROD_CODE IN (SELECT PROD_CODE FROM TORD_PRODUCT_BILL WHERE BILL_DATE BETWEEN @S_COL_DATE AND @E_COL_DATE AND BILL_TYPE = @BILL_TYPE AND DATA_FLAG = '0')"));

                        sbWhere.Append(UTIL.GetWhere(row, "@NOT_PROD_KIND", "P.PROD_KIND NOT IN @NOT_PROD_KIND", UTIL.SqlCondType.IN));

                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_KIND", "P.PROD_KIND IN @PROD_KIND", UTIL.SqlCondType.IN));

                        sbWhere.Append("  AND PROD_STATE IN ('2','8','9') ");

                        sbWhere.Append("  ORDER BY P.PROD_CODE ");

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



        public static DataTable TORD_PRODUCT_QUERY3(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {


                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT P.CVND_CODE");
                    sbQuery.Append(" ,CVND.VEN_NAME AS CVND_NAME");
                    sbQuery.Append(" ,SUM(ISNULL(W.WO_CNT,0)) AS WO_CNT");
                    sbQuery.Append(" ,SUM(ISNULL(WE.WO_CNT,0)) AS WO_END_CNT");
                    sbQuery.Append(" FROM TORD_PRODUCT P");
                    sbQuery.Append(" LEFT JOIN TSTD_VENDOR CVND");
                    sbQuery.Append(" ON P.PLT_CODE = CVND.PLT_CODE");
                    sbQuery.Append(" AND P.CVND_CODE = CVND.VEN_CODE");
                    sbQuery.Append(" LEFT JOIN (SELECT PLT_CODE,PROD_CODE,COUNT(*) AS WO_CNT FROM TSHP_WORKORDER WHERE DATA_FLAG = 0 GROUP BY PLT_CODE,PROD_CODE) W");
                    sbQuery.Append(" ON P.PLT_CODE = W.PLT_CODE");
                    sbQuery.Append(" AND P.PROD_CODE = W.PROD_CODE");

                    sbQuery.Append(" LEFT JOIN (SELECT PLT_CODE,PROD_CODE,COUNT(*) AS WO_CNT FROM TSHP_WORKORDER WHERE DATA_FLAG = 0 AND WO_FLAG = '4' GROUP BY PLT_CODE,PROD_CODE) WE");
                    sbQuery.Append(" ON P.PLT_CODE = WE.PLT_CODE");
                    sbQuery.Append(" AND P.PROD_CODE = WE.PROD_CODE");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE P.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_CODE", "P.PROD_CODE = @PROD_CODE"));

                        sbWhere.Append(UTIL.GetWhere(row, "@S_REG_DATE, @E_REG_DATE", "(CONVERT(nvarchar(8),P.REG_DATE,112) BETWEEN @S_REG_DATE AND @E_REG_DATE)"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_ORD_DATE, @E_ORD_DATE", "(P.ORD_DATE BETWEEN @S_ORD_DATE AND @E_ORD_DATE)"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_DUE_DATE, @E_DUE_DATE", "(P.DUE_DATE BETWEEN @S_DUE_DATE AND @E_DUE_DATE)"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_DELIVERY_DATE, @E_DELIVERY_DATE", "(P.DELIVERY_DATE BETWEEN @S_DELIVERY_DATE AND @E_DELIVERY_DATE)"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_LIKE", "P.PROD_CODE LIKE '%' + @PROD_LIKE + '%' OR P.PROD_NAME LIKE '%' + @PROD_LIKE + '%'"));
                        sbWhere.Append(UTIL.GetWhere(row, "@CVND_LIKE", "P.CVND_CODE LIKE '%' + @CVND_LIKE + '%' OR CVND.VEN_NAME LIKE '%' + @CVND_LIKE + '%'"));
                        sbWhere.Append(UTIL.GetWhere(row, "@BUSINESS_EMP", "P.BUSINESS_EMP = @BUSINESS_EMP"));
                        sbWhere.Append(UTIL.GetWhere(row, "@SHIP_FLAG", "P.SHIP_FLAG = @SHIP_FLAG"));
                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "P.DATA_FLAG = @DATA_FLAG"));
                        sbWhere.Append(" AND P.CVND_CODE IS NOT NULL ");
                        sbWhere.Append(" GROUP BY P.CVND_CODE,CVND.VEN_NAME  ");
                        sbWhere.Append(" ORDER BY P.CVND_CODE  ");

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
        /// 생산계획 수주 정보 조회
        /// </summary>
        /// <param name="dtParam"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataTable TORD_PRODUCT_QUERY4(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {


                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT P.PLT_CODE");
                    sbQuery.Append(" ,P.PROD_CODE");
                    sbQuery.Append(" ,P.ITEM_CODE");
                    sbQuery.Append(" ,P.PROD_NAME");
                    sbQuery.Append(" ,P.MODEL_TYPE");
                    sbQuery.Append(" ,P.MODEL_CODE");
                    sbQuery.Append(" ,P.PROD_VERSION");
                    sbQuery.Append(" ,P.PROC_TYPE");
                    sbQuery.Append(" ,P.PROC_FLAG");
                    sbQuery.Append(" ,P.PROD_FLAG");
                    sbQuery.Append(" ,P.INS_YN");
                    sbQuery.Append(" ,P.SOCKET_YN");
                    sbQuery.Append(" ,P.PROD_TYPE");
                    sbQuery.Append(" ,P.PROD_CATEGORY");
                    sbQuery.Append(" ,P.BUSINESS_EMP");
                    sbQuery.Append(" ,P.CUSTOMER_EMP");
                    sbQuery.Append(" ,P.CUSTDESIGN_EMP");
                    sbQuery.Append(" ,P.ACTUATOR_YN");
                    sbQuery.Append(" ,P.CVND_CODE");
                    sbQuery.Append(" ,CVND.VEN_NAME AS CVND_NAME");
                    sbQuery.Append(" ,P.TVND_CODE");
                    sbQuery.Append(" ,TVND.BVEN_NAME AS TVND_NAME");
                    sbQuery.Append(" ,P.PROBE_PIN");
                    sbQuery.Append(" ,P.CURR_UNIT");
                    sbQuery.Append(" ,P.ORD_DATE");
                    sbQuery.Append(" ,P.INDUE_DATE");
                    sbQuery.Append(" ,P.DUE_DATE");
                    sbQuery.Append(" ,P.CHG_DUE_DATE");
                    sbQuery.Append(" ,P.END_DATE");
                    sbQuery.Append(" ,P.DELIVERY_DATE");
                    sbQuery.Append(" ,P.PROD_QTY");
                    sbQuery.Append(" ,P.LOAD_FLAG");
                    sbQuery.Append(" ,P.LOCK_FLAG");
                    sbQuery.Append(" ,P.LOCK_EMP");
                    sbQuery.Append(" ,P.SHIP_FLAG");
                    sbQuery.Append(" ,P.PROD_STATE");
                    sbQuery.Append(" ,P.INOUT_FLAG");
                    sbQuery.Append(" ,P.ORD_VAT");
                    sbQuery.Append(" ,P.PROD_UC");
                    sbQuery.Append(" ,P.PROD_COST");
                    sbQuery.Append(" ,P.PROD_VAT");
                    sbQuery.Append(" ,P.PROD_AMT");
                    sbQuery.Append(" ,P.PROD_KIND");
                    sbQuery.Append(" ,P.PROD_TYPE1");
                    sbQuery.Append(" ,P.PROD_TYPE2");
                    sbQuery.Append(" ,P.INS_FLAG");
                    sbQuery.Append(" ,P.TRADE_YN");
                    sbQuery.Append(" ,P.TAX_YN");
                    sbQuery.Append(" ,P.BILL_YN");
                    sbQuery.Append(" ,P.SCOMMENT");
                    sbQuery.Append(" ,P.REMARK");
                    sbQuery.Append(" ,P.MODULE_TYPE ");
                    sbQuery.Append(" ,P.PIN_TYPE ");
                    sbQuery.Append(" ,P.VISION_TYPE ");
                    sbQuery.Append(" ,P.VISION_DIRECTION ");
                    sbQuery.Append(" ,P.GND_PIN ");
                    sbQuery.Append(" ,P.FIDUCIAL_MARK ");
                    sbQuery.Append(" ,P.CROSS_MARKING ");
                    sbQuery.Append(" ,P.VACUUM ");
                    sbQuery.Append(" ,P.SOCKET_MARKING ");
                    sbQuery.Append(" ,P.MODULE_IN_TYPE ");
                    sbQuery.Append(" ,P.IF_PIN_BLOCK ");
                    sbQuery.Append(" ,P.SOCKET_OPEN_DIRECTION ");
                    sbQuery.Append(" ,P.MSOP_DFM ");
                    sbQuery.Append(" ,P.MSOP_DFM_DATE ");
                    sbQuery.Append(" ,P.DRAW_DATE ");
                    sbQuery.Append(" ,P.DRAW_TYPE ");
                    sbQuery.Append(" ,P.REG_DATE");
                    sbQuery.Append(" ,P.REG_EMP");
                    sbQuery.Append(" ,REG.EMP_NAME AS REG_EMP_NAME");
                    sbQuery.Append(" ,P.MDFY_DATE");
                    sbQuery.Append(" ,P.MDFY_EMP");
                    sbQuery.Append(" ,MDFY.EMP_NAME AS MDFY_EMP_NAME");
                    sbQuery.Append(", P.PART_CODE");
                    sbQuery.Append(", PT.PART_NAME");
                    sbQuery.Append(" ,P.ITEM_FLAG ");
                    sbQuery.Append(" ,P.PROD_PRIORITY ");
                    sbQuery.Append(" ,P.DFM_YN ");
                    sbQuery.Append(" ,P.DFM_DATE ");
                    sbQuery.Append(" ,P.MSOP_YN ");
                    sbQuery.Append(" ,P.MSOP_DATE ");
                    sbQuery.Append(" ,P.DES_DATE ");
                    //sbQuery.Append(" ,(SELECT CASE WHEN PROD_CODE IS NULL THEN 0 ELSE 1 END FROM TMAT_PARTLIST WHERE PLT_CODE = P.PLT_CODE AND PROD_CODE = P.PROD_CODE AND DATA_FLAG = 0 GROUP BY PROD_CODE) AS BOM_FLAG ");
                    sbQuery.Append(" ,CASE WHEN BOM.PROD_CODE IS NULL THEN 0 ELSE 1 END AS BOM_FLAG ");
                    sbQuery.Append(" ,ISNULL(SH.SHIP_QTY,0) AS SHIP_QTY ");
                    sbQuery.Append(" ,SH.SHIP_DATE ");
                    sbQuery.Append(" ,(CASE WHEN (P.PROD_QTY - ISNULL(SH.SHIP_QTY,0)) > 0 THEN (P.PROD_QTY - ISNULL(SH.SHIP_QTY,0)) ELSE 0 END) AS REMAIN_QTY ");
                    sbQuery.Append(" ,AD.DRAW_EMP ");

                    sbQuery.Append(" ,P.CHK_FLAG ");
                    sbQuery.Append(" ,P.CHK_EMP ");
                    sbQuery.Append(" ,CHK.EMP_NAME AS CHK_EMP_NAME ");
                    sbQuery.Append(" ,P.CHK_DATE ");
                    sbQuery.Append(" ,P.CHK_DEL_EMP ");
                    sbQuery.Append(" ,CHKD.EMP_NAME AS CHK_DEL_EMP_NAME ");
                    sbQuery.Append(" ,P.CHK_DEL_DATE ");

                    sbQuery.Append(" ,P.LAST_DES_DATETIME ");
                    sbQuery.Append(" ,P.PREV_DES_DATETIME ");

                    sbQuery.Append(" FROM TORD_PRODUCT P");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE REG");
                    sbQuery.Append(" ON P.PLT_CODE = REG.PLT_CODE");
                    sbQuery.Append(" AND P.REG_EMP = REG.EMP_CODE");
                    
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE MDFY");
                    sbQuery.Append(" ON P.PLT_CODE = MDFY.PLT_CODE");
                    sbQuery.Append(" AND P.MDFY_EMP = MDFY.EMP_CODE");
                    
                    sbQuery.Append(" LEFT JOIN TSTD_VENDOR CVND");
                    sbQuery.Append(" ON P.PLT_CODE = CVND.PLT_CODE");
                    sbQuery.Append(" AND P.CVND_CODE = CVND.VEN_CODE");
                    
                    sbQuery.Append(" LEFT JOIN TSTD_BILL_VENDOR TVND");
                    sbQuery.Append(" ON P.PLT_CODE = TVND.PLT_CODE");
                    sbQuery.Append(" AND P.TVND_CODE = TVND.BVEN_CODE");
                    
                    sbQuery.Append(" LEFT JOIN LSE_STD_PART PT");
                    sbQuery.Append(" ON P.PLT_CODE = PT.PLT_CODE");
                    sbQuery.Append(" AND P.PART_CODE = PT.PART_CODE");
                    
                    sbQuery.Append(" LEFT JOIN (SELECT PLT_CODE,PROD_CODE,MAX(SHIP_DATE) AS SHIP_DATE ,SUM(SHIP_QTY) AS SHIP_QTY FROM TORD_SHIP WHERE DATA_FLAG = 0 GROUP BY PLT_CODE,PROD_CODE) SH");
                    sbQuery.Append(" ON P.PLT_CODE = SH.PLT_CODE");
                    sbQuery.Append(" AND P.PROD_CODE = SH.PROD_CODE");
                    
                    sbQuery.Append(" LEFT JOIN (SELECT PLT_CODE,PROD_CODE,SUM(CASE WO_FLAG WHEN '0' THEN 1 ELSE 0 END) AS NONE_CNT FROM TSHP_WORKORDER WHERE DATA_FLAG = 0 GROUP BY PLT_CODE,PROD_CODE) WO");
                    sbQuery.Append(" ON P.PLT_CODE = WO.PLT_CODE");
                    sbQuery.Append(" AND P.PROD_CODE = WO.PROD_CODE");

                    sbQuery.Append(" LEFT JOIN (SELECT PLT_CODE, PROD_CODE FROM TMAT_PARTLIST WHERE DATA_FLAG = 0 GROUP BY PLT_CODE, PROD_CODE) BOM");
                    sbQuery.Append(" ON P.PLT_CODE = BOM.PLT_CODE");
                    sbQuery.Append(" AND P.PROD_CODE = BOM.PROD_CODE");

                    sbQuery.Append(" LEFT JOIN (");
                    sbQuery.Append(" SELECT PLT_CODE, PROD_CODE, MAX(DRAW_EMP) AS DRAW_EMP FROM TMAT_PARTLIST");
                    sbQuery.Append(" WHERE ISNULL(O_PT_ID,'') = '' AND DATA_FLAG = '0' AND LEFT(PART_CODE,1) = 'A'");
                    sbQuery.Append(" GROUP BY PLT_CODE, PROD_CODE");
                    sbQuery.Append(" ) AD");
                    sbQuery.Append(" ON P.PLT_CODE = AD.PLT_CODE");
                    sbQuery.Append(" AND P.PROD_CODE = AD.PROD_CODE");

                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE CHK");
                    sbQuery.Append(" ON P.PLT_CODE = CHK.PLT_CODE");
                    sbQuery.Append(" AND P.CHK_EMP = CHK.EMP_CODE");

                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE CHKD");
                    sbQuery.Append(" ON P.PLT_CODE = CHKD.PLT_CODE");
                    sbQuery.Append(" AND P.CHK_DEL_EMP = CHKD.EMP_CODE");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE P.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_CODE", "P.PROD_CODE = @PROD_CODE"));

                        sbWhere.Append(UTIL.GetWhere(row, "@S_REG_DATE, @E_REG_DATE", "(CONVERT(nvarchar(8),P.REG_DATE,112) BETWEEN @S_REG_DATE AND @E_REG_DATE)"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_ORD_DATE, @E_ORD_DATE", "(P.ORD_DATE BETWEEN @S_ORD_DATE AND @E_ORD_DATE)"));
                        //sbWhere.Append(UTIL.GetWhere(row, "@S_DUE_DATE, @E_DUE_DATE", "(P.DUE_DATE BETWEEN @S_DUE_DATE AND @E_DUE_DATE)"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_DUE_DATE, @E_DUE_DATE", "ISNULL(P.CHG_DUE_DATE, P.DUE_DATE) BETWEEN @S_DUE_DATE AND @E_DUE_DATE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_DELIVERY_DATE, @E_DELIVERY_DATE", "(P.DELIVERY_DATE BETWEEN @S_DELIVERY_DATE AND @E_DELIVERY_DATE)"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_LIKE", "P.PROD_CODE LIKE '%' + @PROD_LIKE + '%' OR P.PROD_NAME LIKE '%' + @PROD_LIKE + '%'"));
                        sbWhere.Append(UTIL.GetWhere(row, "@BUSINESS_EMP", "P.BUSINESS_EMP = @BUSINESS_EMP"));
                        sbWhere.Append(UTIL.GetWhere(row, "@CVND_LIKE", "P.CVND_CODE LIKE '%' + @CVND_LIKE + '%' OR CVND.VEN_NAME LIKE '%' + @CVND_LIKE + '%'"));
                        sbWhere.Append(UTIL.GetWhere(row, "@CVND_CODE", "P.CVND_CODE = @CVND_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@SHIP_FLAG", "P.SHIP_FLAG = @SHIP_FLAG"));
                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "P.DATA_FLAG = @DATA_FLAG"));
                        sbWhere.Append(UTIL.GetWhere(row, "@ITEM_FLAG", "P.ITEM_FLAG = @ITEM_FLAG"));

                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_FLAG", "P.PROD_FLAG = @PROD_FLAG"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_STATE", "P.PROD_STATE = @PROD_STATE"));

                        sbWhere.Append(UTIL.GetWhere(row, "@BOM_FLAG", "ISNULL(P.IF_FLAG,0) = '0' "));

                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_KIND_NOT_IE", "P.PROD_KIND <> 'IE'"));


                        sbWhere.Append(UTIL.GetWhere(row, "@HAS_NONE_WO", " WO.NONE_CNT > 0 OR WO.PROD_CODE IS NULL "));


                        sbWhere.Append(" ORDER BY P.PROD_PRIORITY ,P.DUE_DATE ");

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

        public static DataTable TORD_PRODUCT_QUERY8(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT 							");
                    sbQuery.Append(" I.PLT_CODE							");
                    sbQuery.Append(" ,I.ITEM_CODE						");
                    sbQuery.Append(" ,I.ITEM_CODE AS GROUP_CODE			");
                    sbQuery.Append(" ,I.ITEM_NAME						");
                    sbQuery.Append(" ,I.SALECONFM_DATE					");
                    sbQuery.Append(" ,I.BUSINESS_EMP					");
                    sbQuery.Append(" ,BEMP.EMP_NAME AS BUSINESS_EMP_NAME");
                    sbQuery.Append(" ,I.CVND_CODE						");
                    sbQuery.Append(" ,V.VEN_NAME AS CVND_NAME			");
                    sbQuery.Append(" ,I.ORD_VAT							");
                    sbQuery.Append(" ,P.PROD_CODE						");
                    sbQuery.Append(" ,P.PART_CODE						");
                    sbQuery.Append(" ,SP.PART_NAME						");
                    sbQuery.Append(" ,P.PROD_STATE						");
                    sbQuery.Append(" ,SP.DRAW_NO						");
                    sbQuery.Append(" ,SP.MAT_TYPE						");
                    sbQuery.Append(" ,SP.MAT_LTYPE						");
                    sbQuery.Append(" ,SP.MAT_MTYPE						");
                    sbQuery.Append(" ,SP.MAT_STYPE						");
                    sbQuery.Append(" ,SP.MAT_SPEC						");
                    sbQuery.Append(" ,SP.MAT_SPEC1						");
                    sbQuery.Append(" ,SP.MAT_UNIT						");
                    sbQuery.Append(" ,I.ORD_DATE						");
                    sbQuery.Append(" ,P.DUE_DATE						");
                    sbQuery.Append(" ,P.PROD_QTY						");
                    sbQuery.Append(" ,P.PROD_UC							");
                    sbQuery.Append(" ,P.PROD_COST						");
                    sbQuery.Append(" ,P.PROD_VAT						");
                    sbQuery.Append(" ,P.PROD_AMT						");
                    sbQuery.Append(" ,P.DFM_YN ");
                    sbQuery.Append(" ,P.DFM_DATE ");
                    sbQuery.Append(" ,P.MSOP_YN ");
                    sbQuery.Append(" ,P.MSOP_DATE ");
                    sbQuery.Append(" FROM TORD_PRODUCT P				");
                    sbQuery.Append(" LEFT JOIN TORD_ITEM I				");
                    sbQuery.Append(" ON I.PLT_CODE = P.PLT_CODE			");
                    sbQuery.Append(" AND I.ITEM_CODE = P.ITEM_CODE		");
                    sbQuery.Append(" AND I.DATA_FLAG = '0'				");
                    sbQuery.Append(" 									");
                    sbQuery.Append(" LEFT JOIN TSTD_VENDOR V			");
                    sbQuery.Append(" ON I.PLT_CODE = V.PLT_CODE			");
                    sbQuery.Append(" AND I.CVND_CODE = V.VEN_CODE		");
                    sbQuery.Append(" 									");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE BEMP		");
                    sbQuery.Append(" ON I.PLT_CODE = BEMP.PLT_CODE		");
                    sbQuery.Append(" AND I.BUSINESS_EMP = BEMP.EMP_CODE	");
                    sbQuery.Append(" 									");
                    sbQuery.Append(" LEFT JOIN LSE_STD_PART SP			");
                    sbQuery.Append(" ON P.PLT_CODE = SP.PLT_CODE		");
                    sbQuery.Append(" AND P.PART_CODE = SP.PART_CODE		");
 

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE P.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                        sbWhere.Append(UTIL.GetWhere(row, "@ITEM_LIKE", "(I.ITEM_CODE LIKE '%' + @ITEM_LIKE + '%' OR I.ITEM_NAME LIKE '%' + @ITEM_LIKE + '%')"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_LIKE", "(P.PART_CODE LIKE '%' + @PART_LIKE + '%' OR SP.PART_NAME LIKE '%' + @PART_LIKE + '%')"));
                        sbWhere.Append(UTIL.GetWhere(row, "@CVND_CODE", "I.CVND_CODE = @CVND_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_CODE", "P.PROD_CODE = @PROD_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_STATE_FLAG_WT", "A.PROD_STATE NOT IN ('WT')"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_STATE_FLAG_WK", "A.PROD_STATE NOT IN ('WK')"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_STATE_FLAG_PG", "A.PROD_STATE NOT IN ('PG')"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_STATE_FLAG_SH", "A.PROD_STATE NOT IN ('SH')"));
                        sbWhere.Append(UTIL.GetWhere(row, "@VEN_LIKE", "(I.CVND_CODE LIKE '%' + @VEN_LIKE + '%' OR V.VEN_NAME LIKE '%' + @VEN_LIKE + '%')"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_STATE", "P.PROD_STATE IN @PROD_STATE", UTIL.SqlCondType.IN));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_ORD_DATE, @E_ORD_DATE", "(I.ORD_DATE BETWEEN @S_ORD_DATE AND @E_ORD_DATE)"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_DUE_DATE, @E_DUE_DATE", "(P.DUE_DATE BETWEEN @S_DUE_DATE AND @E_DUE_DATE)"));
                        
                        string cond = "(SP.PART_CODE LIKE '%' + @SEARCH_CON + '%' OR V.VEN_NAME LIKE '%' + @SEARCH_CON + '%' OR I.ITEM_CODE LIKE '%' + @SEARCH_CON + '%' OR SP.PART_NAME LIKE '%' + @SEARCH_CON + '%' )";
                        sbWhere.Append(UTIL.GetWhere(row, "@SEARCH_CON", cond));

                        sbWhere.Append(" AND P.DATA_FLAG = '0'");
                        sbWhere.Append(" AND P.PARENT_PART IS NULL");

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



        public static DataTable TORD_PRODUCT_QUERY13(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {


                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT P.PLT_CODE");
                    sbQuery.Append(" ,P.PROD_CODE");
                    sbQuery.Append(" ,P.ITEM_CODE");
                    sbQuery.Append(" ,P.PROD_NAME");
                    sbQuery.Append(" ,P.MODEL_TYPE");
                    sbQuery.Append(" ,P.MODEL_CODE");
                    sbQuery.Append(" ,P.PART_CODE");
                    sbQuery.Append(" ,P.PROD_VERSION");
                    sbQuery.Append(" ,P.PROC_FLAG");
                    sbQuery.Append(" ,P.PROD_FLAG");
                    sbQuery.Append(" ,P.INS_YN");
                    sbQuery.Append(" ,P.SOCKET_YN");
                    sbQuery.Append(" ,P.PROD_TYPE");
                    sbQuery.Append(" ,P.PROD_CATEGORY");
                    sbQuery.Append(" ,P.BUSINESS_EMP");
                    sbQuery.Append(" ,P.CUSTOMER_EMP");
                    sbQuery.Append(" ,P.CUSTDESIGN_EMP");
                    sbQuery.Append(" ,P.ACTUATOR_YN");
                    sbQuery.Append(" ,P.CVND_CODE");
                    sbQuery.Append(" ,CVND.VEN_NAME AS CVND_NAME");
                    sbQuery.Append(" ,P.TVND_CODE");
                    sbQuery.Append(" ,TVND.BVEN_NAME AS TVND_NAME");
                    sbQuery.Append(" ,P.PROBE_PIN");
                    sbQuery.Append(" ,P.CURR_UNIT");
                    sbQuery.Append(" ,P.ORD_DATE");
                    sbQuery.Append(" ,P.INDUE_DATE");
                    sbQuery.Append(" ,P.DUE_DATE");
                    sbQuery.Append(" ,P.CHG_DUE_DATE");
                    sbQuery.Append(" ,P.END_DATE");
                    sbQuery.Append(" ,P.DELIVERY_DATE");
                    sbQuery.Append(" ,P.PROD_QTY");
                    sbQuery.Append(" ,P.LOAD_FLAG");
                    sbQuery.Append(" ,P.LOCK_FLAG");
                    sbQuery.Append(" ,P.LOCK_EMP");
                    sbQuery.Append(" ,P.SHIP_FLAG");
                    sbQuery.Append(" ,P.PROD_STATE");
                    sbQuery.Append(" ,P.INOUT_FLAG");
                    sbQuery.Append(" ,P.ORD_VAT");
                    sbQuery.Append(" ,P.PROD_UC");
                    sbQuery.Append(" ,P.PROD_COST");
                    sbQuery.Append(" ,P.PROD_VAT");
                    sbQuery.Append(" ,P.PROD_AMT");
                    sbQuery.Append(" ,P.PROD_KIND");
                    sbQuery.Append(" ,P.PROD_TYPE1");
                    sbQuery.Append(" ,P.PROD_TYPE2");
                    sbQuery.Append(" ,P.INS_FLAG");
                    sbQuery.Append(" ,P.TRADE_YN");
                    sbQuery.Append(" ,P.TAX_YN");
                    sbQuery.Append(" ,P.BILL_YN");
                    sbQuery.Append(" ,P.SCOMMENT");
                    sbQuery.Append(" ,P.SCOMMENT AS ORD_SCOMMENT");
                    sbQuery.Append(" ,P.REMARK");
                    sbQuery.Append(" ,P.MODULE_TYPE ");
                    sbQuery.Append(" ,P.PIN_TYPE ");
                    sbQuery.Append(" ,P.VISION_TYPE ");
                    sbQuery.Append(" ,P.VISION_DIRECTION ");
                    sbQuery.Append(" ,P.GND_PIN ");
                    sbQuery.Append(" ,P.FIDUCIAL_MARK ");
                    sbQuery.Append(" ,P.CROSS_MARKING ");
                    sbQuery.Append(" ,P.VACUUM ");
                    sbQuery.Append(" ,P.SOCKET_MARKING ");
                    sbQuery.Append(" ,P.MODULE_IN_TYPE ");
                    sbQuery.Append(" ,P.IF_PIN_BLOCK ");
                    sbQuery.Append(" ,P.SOCKET_OPEN_DIRECTION ");
                    sbQuery.Append(" ,P.MSOP_DFM ");
                    sbQuery.Append(" ,P.MSOP_DFM_DATE ");
                    sbQuery.Append(" ,P.DRAW_DATE ");
                    sbQuery.Append(" ,P.DRAW_TYPE ");
                    sbQuery.Append(" ,P.REG_DATE");
                    sbQuery.Append(" ,P.REG_EMP");
                    sbQuery.Append(" ,REG.EMP_NAME AS REG_EMP_NAME");
                    sbQuery.Append(" ,P.MDFY_DATE");
                    sbQuery.Append(" ,P.MDFY_EMP");
                    sbQuery.Append(" ,MDFY.EMP_NAME AS MDFY_EMP_NAME");
                    sbQuery.Append(" ,P.PROD_PRIORITY ");
                    sbQuery.Append(" ,P.DFM_YN ");
                    sbQuery.Append(" ,P.DFM_DATE ");
                    sbQuery.Append(" ,P.MSOP_YN ");
                    sbQuery.Append(" ,P.MSOP_DATE ");
                    sbQuery.Append(" ,CONVERT(nvarchar(10),CAM.WO_CNT - CAM.NONE_CNT) + '/' + CONVERT(nvarchar(10),CAM.NONE_CNT) AS CAM_CNT ");

                    sbQuery.Append(" ,(SELECT ISNULL(MIN(PROC_STAT),'0') FROM TSHP_ACTUAL_CAM WHERE PLT_CODE = P.PLT_CODE AND WO_NO IN (SELECT WO_NO FROM TSHP_WORKORDER WHERE PROD_CODE = P.PROD_CODE)) AS CAM_STATE  ");
                    sbQuery.Append(" ,P.ITEM_FLAG ");
                    //sbQuery.Append(" ,CAM.END_TIME ");
                    sbQuery.Append(" ,AD.DRAW_EMP ");
                    sbQuery.Append(" FROM TORD_PRODUCT P");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE REG");
                    sbQuery.Append(" ON P.PLT_CODE = REG.PLT_CODE");
                    sbQuery.Append(" AND P.REG_EMP = REG.EMP_CODE");
                    
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE MDFY");
                    sbQuery.Append(" ON P.PLT_CODE = MDFY.PLT_CODE");
                    sbQuery.Append(" AND P.MDFY_EMP = MDFY.EMP_CODE");
                    
                    sbQuery.Append(" LEFT JOIN TSTD_VENDOR CVND");
                    sbQuery.Append(" ON P.PLT_CODE = CVND.PLT_CODE");
                    sbQuery.Append(" AND P.CVND_CODE = CVND.VEN_CODE");
                    
                    sbQuery.Append(" LEFT JOIN TSTD_BILL_VENDOR TVND");
                    sbQuery.Append(" ON P.PLT_CODE = TVND.PLT_CODE");
                    sbQuery.Append(" AND P.TVND_CODE = TVND.BVEN_CODE");

                    sbQuery.Append(" LEFT JOIN (SELECT PLT_CODE,PROD_CODE,SUM(CASE WHEN CAM_EMP IS NULL THEN 1 ELSE 0 END) AS NONE_CNT,COUNT(*) AS WO_CNT,MAX(ACT_END_TIME) AS END_TIME ");
                    sbQuery.Append(" FROM TSHP_WORKORDER WHERE DATA_FLAG = 0 AND PROC_CODE IN (SELECT PROC_CODE FROM LSE_STD_PROC WHERE PLT_CODE = @PLT_CODE AND WO_TYPE = @WO_TYPE) GROUP BY PLT_CODE,PROD_CODE) CAM");
                    sbQuery.Append(" ON P.PLT_CODE = CAM.PLT_CODE");
                    sbQuery.Append(" AND P.PROD_CODE = CAM.PROD_CODE");
                    //sbQuery.Append(" LEFT JOIN (SELECT PLT_CODE,WO_NO,ACT_START_TIME,ACT_END_TIME FROM TSHP_ACTUAL_CAM GROUP BY PLT_CODE,WO_NO) CA");
                    //sbQuery.Append(" ON P.PLT_CODE = CA.PLT_CODE");
                    //sbQuery.Append(" AND P.TVND_CODE = CA.VEN_CODE");

                    sbQuery.Append(" LEFT JOIN (");
                    sbQuery.Append(" SELECT PLT_CODE, PROD_CODE, MAX(DRAW_EMP) AS DRAW_EMP FROM TMAT_PARTLIST");
                    sbQuery.Append(" WHERE ISNULL(O_PT_ID,'') = '' AND DATA_FLAG = '0' AND LEFT(PART_CODE,1) = 'A'");
                    sbQuery.Append(" GROUP BY PLT_CODE, PROD_CODE");
                    sbQuery.Append(" ) AD");
                    sbQuery.Append(" ON P.PLT_CODE = AD.PLT_CODE");
                    sbQuery.Append(" AND P.PROD_CODE = AD.PROD_CODE");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE P.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_CODE", "P.PROD_CODE = @PROD_CODE"));

                        sbWhere.Append(UTIL.GetWhere(row, "@S_REG_DATE, @E_REG_DATE", "(CONVERT(nvarchar(8),P.REG_DATE,112) BETWEEN @S_REG_DATE AND @E_REG_DATE)"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_ORD_DATE, @E_ORD_DATE", "(P.ORD_DATE BETWEEN @S_ORD_DATE AND @E_ORD_DATE)"));
                        //sbWhere.Append(UTIL.GetWhere(row, "@S_DUE_DATE, @E_DUE_DATE", "(P.DUE_DATE BETWEEN @S_DUE_DATE AND @E_DUE_DATE)"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_DUE_DATE, @E_DUE_DATE", "ISNULL(P.CHG_DUE_DATE, P.DUE_DATE) BETWEEN @S_DUE_DATE AND @E_DUE_DATE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_DELIVERY_DATE, @E_DELIVERY_DATE", "(P.DELIVERY_DATE BETWEEN @S_DELIVERY_DATE AND @E_DELIVERY_DATE)"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_LIKE", "P.PROD_CODE LIKE '%' + @PROD_LIKE + '%' OR P.PROD_NAME LIKE '%' + @PROD_LIKE + '%'"));
                        sbWhere.Append(UTIL.GetWhere(row, "@BUSINESS_EMP", "P.BUSINESS_EMP = @BUSINESS_EMP"));
                        sbWhere.Append(UTIL.GetWhere(row, "@CVND_LIKE", "P.CVND_CODE LIKE '%' + @CVND_LIKE + '%' OR CVND.VEN_NAME LIKE '%' + @CVND_LIKE + '%'"));
                        sbWhere.Append(UTIL.GetWhere(row, "@CVND_CODE", "P.CVND_CODE = @CVND_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@SHIP_FLAG", "P.SHIP_FLAG = @SHIP_FLAG"));
                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "P.DATA_FLAG = @DATA_FLAG"));
                        sbWhere.Append(" AND ISNULL(P.PROD_STATE,'') <> '5' ");
                        sbWhere.Append(" ORDER BY P.PROD_CODE ");

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


        public static DataTable TORD_PRODUCT_QUERY14(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {


                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT P.PLT_CODE");
                    sbQuery.Append(" ,P.PROD_CODE");
                    sbQuery.Append(" ,P.ITEM_CODE");
                    sbQuery.Append(" ,P.PROD_NAME");
                    sbQuery.Append(" ,P.MODEL_TYPE");
                    sbQuery.Append(" ,P.MODEL_CODE");
                    sbQuery.Append(" ,P.PROD_VERSION");
                    sbQuery.Append(" ,P.PROC_FLAG");
                    sbQuery.Append(" ,P.PROD_FLAG");
                    sbQuery.Append(" ,P.INS_YN");
                    sbQuery.Append(" ,P.SOCKET_YN");
                    sbQuery.Append(" ,P.PROD_TYPE");
                    sbQuery.Append(" ,P.PROD_CATEGORY");
                    sbQuery.Append(" ,P.BUSINESS_EMP");
                    sbQuery.Append(" ,P.CUSTOMER_EMP");
                    sbQuery.Append(" ,P.CUSTDESIGN_EMP");
                    sbQuery.Append(" ,P.ACTUATOR_YN");
                    sbQuery.Append(" ,P.CVND_CODE");
                    sbQuery.Append(" ,CVND.VEN_NAME AS CVND_NAME");
                    sbQuery.Append(" ,P.TVND_CODE");
                    sbQuery.Append(" ,TVND.BVEN_NAME AS TVND_NAME");
                    sbQuery.Append(" ,P.PROBE_PIN");
                    sbQuery.Append(" ,P.CURR_UNIT");
                    sbQuery.Append(" ,P.ORD_DATE");
                    sbQuery.Append(" ,P.INDUE_DATE");
                    sbQuery.Append(" ,P.DUE_DATE");
                    sbQuery.Append(" ,P.CHG_DUE_DATE");
                    sbQuery.Append(" ,P.END_DATE");
                    sbQuery.Append(" ,P.DELIVERY_DATE");
                    sbQuery.Append(" ,P.PROD_QTY");
                    sbQuery.Append(" ,(SELECT ISNULL(SUM(ASSY_QTY),0) FROM TSHP_ACTUAL_ASSY A WHERE P.PLT_CODE = A.PLT_CODE AND P.PROD_CODE = A.PROD_CODE ) AS OLD_ASSY_QTY");
                    sbQuery.Append(" ,0 AS ASSY_QTY");
                    sbQuery.Append(" ,P.LOAD_FLAG");
                    sbQuery.Append(" ,P.LOCK_FLAG");
                    sbQuery.Append(" ,P.LOCK_EMP");
                    sbQuery.Append(" ,P.SHIP_FLAG");
                    sbQuery.Append(" ,P.PROD_STATE");
                    sbQuery.Append(" ,P.INOUT_FLAG");
                    sbQuery.Append(" ,P.ORD_VAT");
                    sbQuery.Append(" ,P.PROD_UC");
                    sbQuery.Append(" ,P.PROD_COST");
                    sbQuery.Append(" ,P.PROD_VAT");
                    sbQuery.Append(" ,P.PROD_AMT");
                    sbQuery.Append(" ,P.PROD_KIND");
                    sbQuery.Append(" ,P.PROD_TYPE1");
                    sbQuery.Append(" ,P.PROD_TYPE2");
                    sbQuery.Append(" ,P.INS_FLAG");
                    sbQuery.Append(" ,P.TRADE_YN");
                    sbQuery.Append(" ,P.TAX_YN");
                    sbQuery.Append(" ,P.BILL_YN");
                    sbQuery.Append(" ,P.SCOMMENT");
                    sbQuery.Append(" ,P.REMARK");
                    sbQuery.Append(" ,P.MODULE_TYPE ");
                    sbQuery.Append(" ,P.PIN_TYPE ");
                    sbQuery.Append(" ,P.VISION_TYPE ");
                    sbQuery.Append(" ,P.VISION_DIRECTION ");
                    sbQuery.Append(" ,P.GND_PIN ");
                    sbQuery.Append(" ,P.FIDUCIAL_MARK ");
                    sbQuery.Append(" ,P.CROSS_MARKING ");
                    sbQuery.Append(" ,P.VACUUM ");
                    sbQuery.Append(" ,P.SOCKET_MARKING ");
                    sbQuery.Append(" ,P.MODULE_IN_TYPE ");
                    sbQuery.Append(" ,P.IF_PIN_BLOCK ");
                    sbQuery.Append(" ,P.SOCKET_OPEN_DIRECTION ");
                    sbQuery.Append(" ,P.MSOP_DFM ");
                    sbQuery.Append(" ,P.MSOP_DFM_DATE ");
                    sbQuery.Append(" ,P.DRAW_DATE ");
                    sbQuery.Append(" ,P.DRAW_TYPE ");
                    sbQuery.Append(" ,P.REG_DATE");
                    sbQuery.Append(" ,P.REG_EMP");
                    sbQuery.Append(" ,REG.EMP_NAME AS REG_EMP_NAME");
                    sbQuery.Append(" ,P.MDFY_DATE");
                    sbQuery.Append(" ,P.MDFY_EMP");
                    sbQuery.Append(" ,MDFY.EMP_NAME AS MDFY_EMP_NAME");
                    sbQuery.Append(" ,P.ITEM_FLAG ");
                    sbQuery.Append(" ,P.PROD_PRIORITY ");
                    sbQuery.Append(" ,P.DFM_YN ");
                    sbQuery.Append(" ,P.DFM_DATE ");
                    sbQuery.Append(" ,P.MSOP_YN ");
                    sbQuery.Append(" ,P.MSOP_DATE ");
                    //sbQuery.Append(" ,CONVERT(nvarchar(10),CAM.WO_CNT - CAM.NONE_CNT) + '/' + CONVERT(nvarchar(10),CAM.NONE_CNT) AS CAM_CNT ");

                    //sbQuery.Append(" ,(SELECT ISNULL(MIN(PROC_STAT),'0') FROM TSHP_ACTUAL_CAM WHERE PLT_CODE = P.PLT_CODE AND PROD_CODE = P.PROD_CODE) AS CAM_STATE ");

                    sbQuery.Append(" FROM TORD_PRODUCT P");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE REG");
                    sbQuery.Append(" ON P.PLT_CODE = REG.PLT_CODE");
                    sbQuery.Append(" AND P.REG_EMP = REG.EMP_CODE");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE MDFY");
                    sbQuery.Append(" ON P.PLT_CODE = MDFY.PLT_CODE");
                    sbQuery.Append(" AND P.MDFY_EMP = MDFY.EMP_CODE");
                    sbQuery.Append(" LEFT JOIN TSTD_VENDOR CVND");
                    sbQuery.Append(" ON P.PLT_CODE = CVND.PLT_CODE");
                    sbQuery.Append(" AND P.CVND_CODE = CVND.VEN_CODE");
                    sbQuery.Append(" LEFT JOIN TSTD_BILL_VENDOR TVND");
                    sbQuery.Append(" ON P.PLT_CODE = TVND.PLT_CODE");
                    sbQuery.Append(" AND P.TVND_CODE = TVND.BVEN_CODE");
                    sbQuery.Append(" LEFT JOIN (SELECT PLT_CODE,PROD_CODE,SUM(CASE WHEN CAM_EMP IS NULL THEN 1 ELSE 0 END) AS NONE_CNT,COUNT(*) AS WO_CNT FROM TSHP_WORKORDER WHERE DATA_FLAG = 0 GROUP BY PLT_CODE,PROD_CODE) CAM");
                    sbQuery.Append(" ON P.PLT_CODE = CAM.PLT_CODE");
                    sbQuery.Append(" AND P.PROD_CODE = CAM.PROD_CODE");
                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE P.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_CODE", "P.PROD_CODE = @PROD_CODE"));

                        sbWhere.Append(UTIL.GetWhere(row, "@S_REG_DATE, @E_REG_DATE", "(CONVERT(nvarchar(8),P.REG_DATE,112) BETWEEN @S_REG_DATE AND @E_REG_DATE)"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_ORD_DATE, @E_ORD_DATE", "(P.ORD_DATE BETWEEN @S_ORD_DATE AND @E_ORD_DATE)"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_DUE_DATE, @E_DUE_DATE", "(P.DUE_DATE BETWEEN @S_DUE_DATE AND @E_DUE_DATE)"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_DELIVERY_DATE, @E_DELIVERY_DATE", "(P.DELIVERY_DATE BETWEEN @S_DELIVERY_DATE AND @E_DELIVERY_DATE)"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_LIKE", "P.PROD_CODE LIKE '%' + @PROD_LIKE + '%' OR P.PROD_NAME LIKE '%' + @PROD_LIKE + '%'"));
                        sbWhere.Append(UTIL.GetWhere(row, "@BUSINESS_EMP", "P.BUSINESS_EMP = @BUSINESS_EMP"));
                        sbWhere.Append(UTIL.GetWhere(row, "@CVND_LIKE", "P.CVND_CODE LIKE '%' + @CVND_LIKE + '%' OR CVND.VEN_NAME LIKE '%' + @CVND_LIKE + '%'"));
                        sbWhere.Append(UTIL.GetWhere(row, "@CVND_CODE", "P.CVND_CODE = @CVND_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@SHIP_FLAG", "P.SHIP_FLAG = @SHIP_FLAG"));
                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "P.DATA_FLAG = @DATA_FLAG"));
                        sbWhere.Append(" AND P.PROD_STATE <> '5' ");
                        sbWhere.Append(" ORDER BY P.PROD_CODE ");

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
        public static DataTable TORD_PRODUCT_QUERY15(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {


                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT P.PLT_CODE");
                    sbQuery.Append(" ,P.PROD_CODE");
                    sbQuery.Append(" ,P.ITEM_CODE");
                    sbQuery.Append(" ,P.PROD_NAME");
                    sbQuery.Append(" ,P.MODEL_TYPE");
                    sbQuery.Append(" ,P.MODEL_CODE");
                    sbQuery.Append(" ,P.PROD_VERSION");
                    sbQuery.Append(" ,P.PROC_FLAG");
                    sbQuery.Append(" ,P.PROD_FLAG");
                    sbQuery.Append(" ,P.INS_YN");
                    sbQuery.Append(" ,P.SOCKET_YN");
                    sbQuery.Append(" ,P.PROD_TYPE");
                    sbQuery.Append(" ,P.PROD_CATEGORY");
                    sbQuery.Append(" ,P.BUSINESS_EMP");
                    sbQuery.Append(" ,P.CUSTOMER_EMP");
                    sbQuery.Append(" ,P.CUSTDESIGN_EMP");
                    sbQuery.Append(" ,P.ACTUATOR_YN");
                    sbQuery.Append(" ,P.CVND_CODE");
                    sbQuery.Append(" ,CVND.VEN_NAME AS CVND_NAME");
                    sbQuery.Append(" ,P.TVND_CODE");
                    sbQuery.Append(" ,TVND.BVEN_NAME AS TVND_NAME");
                    sbQuery.Append(" ,P.PROBE_PIN");
                    sbQuery.Append(" ,P.CURR_UNIT");
                    sbQuery.Append(" ,P.ORD_DATE");
                    sbQuery.Append(" ,P.INDUE_DATE");
                    sbQuery.Append(" ,P.DUE_DATE");
                    sbQuery.Append(" ,P.CHG_DUE_DATE");
                    sbQuery.Append(" ,P.END_DATE");
                    sbQuery.Append(" ,P.DELIVERY_DATE");
                    sbQuery.Append(" ,P.PROD_QTY");
                    sbQuery.Append(" ,P.LOAD_FLAG");
                    sbQuery.Append(" ,P.LOCK_FLAG");
                    sbQuery.Append(" ,P.LOCK_EMP");
                    sbQuery.Append(" ,P.SHIP_FLAG");
                    sbQuery.Append(" ,P.PROD_STATE");
                    sbQuery.Append(" ,P.INOUT_FLAG");
                    sbQuery.Append(" ,P.ORD_VAT");
                    sbQuery.Append(" ,P.PROD_UC");
                    sbQuery.Append(" ,P.PROD_COST");
                    sbQuery.Append(" ,P.PROD_VAT");
                    sbQuery.Append(" ,P.PROD_AMT");
                    sbQuery.Append(" ,P.PROD_KIND");
                    sbQuery.Append(" ,P.PROD_TYPE1");
                    sbQuery.Append(" ,P.PROD_TYPE2");
                    sbQuery.Append(" ,P.INS_FLAG");
                    sbQuery.Append(" ,P.TRADE_YN");
                    sbQuery.Append(" ,P.TAX_YN");
                    sbQuery.Append(" ,P.BILL_YN");
                    sbQuery.Append(" ,P.SCOMMENT");
                    sbQuery.Append(" ,P.REMARK");
                    sbQuery.Append(" ,P.MODULE_TYPE ");
                    sbQuery.Append(" ,P.PIN_TYPE ");
                    sbQuery.Append(" ,P.VISION_TYPE ");
                    sbQuery.Append(" ,P.VISION_DIRECTION ");
                    sbQuery.Append(" ,P.GND_PIN ");
                    sbQuery.Append(" ,P.FIDUCIAL_MARK ");
                    sbQuery.Append(" ,P.CROSS_MARKING ");
                    sbQuery.Append(" ,P.VACUUM ");
                    sbQuery.Append(" ,P.SOCKET_MARKING ");
                    sbQuery.Append(" ,P.MODULE_IN_TYPE ");
                    sbQuery.Append(" ,P.IF_PIN_BLOCK ");
                    sbQuery.Append(" ,P.SOCKET_OPEN_DIRECTION ");
                    sbQuery.Append(" ,P.MSOP_DFM ");
                    sbQuery.Append(" ,P.MSOP_DFM_DATE ");
                    sbQuery.Append(" ,P.DRAW_DATE ");
                    sbQuery.Append(" ,P.DRAW_TYPE ");
                    sbQuery.Append(" ,P.REG_DATE");
                    sbQuery.Append(" ,P.REG_EMP");
                    sbQuery.Append(" ,P.ITEM_FLAG ");
                    sbQuery.Append(" ,REG.EMP_NAME AS REG_EMP_NAME");
                    sbQuery.Append(" ,P.MDFY_DATE");
                    sbQuery.Append(" ,P.MDFY_EMP");
                    sbQuery.Append(" ,MDFY.EMP_NAME AS MDFY_EMP_NAME");
                    sbQuery.Append(" ,P.PROD_PRIORITY ");
                    sbQuery.Append(" ,P.DFM_YN ");
                    sbQuery.Append(" ,P.DFM_DATE ");
                    sbQuery.Append(" ,P.MSOP_YN ");
                    sbQuery.Append(" ,P.MSOP_DATE ");
                    sbQuery.Append(" FROM TORD_PRODUCT P");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE REG");
                    sbQuery.Append(" ON P.PLT_CODE = REG.PLT_CODE");
                    sbQuery.Append(" AND P.REG_EMP = REG.EMP_CODE");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE MDFY");
                    sbQuery.Append(" ON P.PLT_CODE = MDFY.PLT_CODE");
                    sbQuery.Append(" AND P.MDFY_EMP = MDFY.EMP_CODE");
                    sbQuery.Append(" LEFT JOIN TSTD_VENDOR CVND");
                    sbQuery.Append(" ON P.PLT_CODE = CVND.PLT_CODE");
                    sbQuery.Append(" AND P.CVND_CODE = CVND.VEN_CODE");
                    sbQuery.Append(" LEFT JOIN TSTD_BILL_VENDOR TVND");
                    sbQuery.Append(" ON P.PLT_CODE = TVND.PLT_CODE");
                    sbQuery.Append(" AND P.TVND_CODE = TVND.BVEN_CODE");
                    sbQuery.Append(" INNER JOIN (SELECT TP.PLT_CODE, TP.PROD_CODE FROM TMAT_PARTLIST TP  ");
                    //sbQuery.Append("            	INNER JOIN TMAT_OUT_REQ_PT RPT									   ");
                    //sbQuery.Append("            		ON TP.PT_ID = RPT.PT_ID										   ");
                    //sbQuery.Append("            		AND TP.PLT_CODE = RPT.PLT_CODE								   ");
                    sbQuery.Append("            	INNER JOIN TMAT_OUT_REQ REQ										   ");
                    sbQuery.Append("            		ON TP.PT_ID = REQ.PT_ID							   ");
                    sbQuery.Append("            		AND TP.PLT_CODE = REQ.PLT_CODE								   ");
                    sbQuery.Append("            	INNER JOIN TMAT_OUT OUT										   ");
                    sbQuery.Append("            		ON REQ.OUT_REQ_ID = OUT.OUT_REQ_ID							   ");
                    sbQuery.Append("            		AND REQ.PLT_CODE = OUT.PLT_CODE								   ");
                    sbQuery.Append("            		AND OUT.DATA_FLAG = '0'								   ");
                    sbQuery.Append("            	LEFT JOIN (SELECT PLT_CODE, PT_ID, SUM(RET_REQ_QTY) AS RET_REQ_QTY FROM TMAT_RET_REQ WHERE DATA_FLAG = '0' GROUP BY PLT_CODE, PT_ID ) RREQ										   ");
                    sbQuery.Append("            		ON TP.PLT_CODE = RREQ.PLT_CODE							   ");
                    sbQuery.Append("            		AND TP.PT_ID = RREQ.PT_ID							   ");
                    sbQuery.Append("            	LEFT JOIN LSE_STD_PART TP_PART										   ");
                    sbQuery.Append("            		ON TP.PART_CODE = TP_PART.PART_CODE							   ");
                    sbQuery.Append("            		AND TP.PLT_CODE = TP_PART.PLT_CODE								   ");
                    //sbQuery.Append("               WHERE REQ.STOCK_CODE = @FIELD_CODE							   ");
                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder ptWhere = new StringBuilder(" WHERE TP.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                        ptWhere.Append(UTIL.GetWhere(row, "@PART_LIKE", "TP.PART_CODE LIKE '%' + @PART_LIKE + '%' OR TP_PART.PART_NAME LIKE '%' + @PART_LIKE + '%'"));
                        ptWhere.Append(UTIL.GetWhere(row, "@SPEC_LIKE", "TP_PART.MAT_SPEC LIKE '%' + @SPEC_LIKE + '%' OR TP_PART.MAT_SPEC1 LIKE '%' + @SPEC_LIKE + '%'"));
                        ptWhere.Append(UTIL.GetWhere(row, "@STOCK_CODE", "OUT.OUT_LOC = @STOCK_CODE"));
                        ptWhere.Append("            AND OUT.OUT_QTY <> ISNULL(RREQ.RET_REQ_QTY,0)					   ");
                        ptWhere.Append("            GROUP BY TP.PLT_CODE, TP.PROD_CODE) MP					   ");
                        ptWhere.Append(" ON P.PROD_CODE = MP.PROD_CODE");
                        ptWhere.Append(" AND P.PLT_CODE = MP.PLT_CODE");

                        StringBuilder sbWhere = new StringBuilder(" WHERE P.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_CODE", "P.PROD_CODE = @PROD_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_REG_DATE, @E_REG_DATE", "(CONVERT(nvarchar(8),P.REG_DATE,112) BETWEEN @S_REG_DATE AND @E_REG_DATE)"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_ORD_DATE, @E_ORD_DATE", "(P.ORD_DATE BETWEEN @S_ORD_DATE AND @E_ORD_DATE)"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_DUE_DATE, @E_DUE_DATE", "(P.DUE_DATE BETWEEN @S_DUE_DATE AND @E_DUE_DATE)"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_DELIVERY_DATE, @E_DELIVERY_DATE", "(P.DELIVERY_DATE BETWEEN @S_DELIVERY_DATE AND @E_DELIVERY_DATE)"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_LIKE", "P.PROD_CODE LIKE '%' + @PROD_LIKE + '%' OR P.PROD_NAME LIKE '%' + @PROD_LIKE + '%'"));
                        sbWhere.Append(UTIL.GetWhere(row, "@BUSINESS_EMP", "P.BUSINESS_EMP = @BUSINESS_EMP"));
                        sbWhere.Append(UTIL.GetWhere(row, "@CVND_LIKE", "P.CVND_CODE LIKE '%' + @CVND_LIKE + '%' OR CVND.VEN_NAME LIKE '%' + @CVND_LIKE + '%'"));
                        sbWhere.Append(UTIL.GetWhere(row, "@CVND_CODE", "P.CVND_CODE = @CVND_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@SHIP_FLAG", "P.SHIP_FLAG = @SHIP_FLAG"));
                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "P.DATA_FLAG = @DATA_FLAG"));

                        sbWhere.Append(" ORDER BY P.PROD_CODE ");

                        DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString() + ptWhere.ToString() + sbWhere.ToString()).Copy();

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

        public static DataTable TORD_PRODUCT_QUERY16(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {


                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT P.PLT_CODE");
                    sbQuery.Append(" ,P.TVND_CODE");
                    sbQuery.Append(" ,BV.BVEN_NAME AS TVND_NAME");
                    sbQuery.Append(" ,BV.BVEN_TYPE");
                    sbQuery.Append(" ,P.PROD_CATEGORY");
                    sbQuery.Append(" ,P.PROD_TYPE");
                    sbQuery.Append(" ,P.BUSINESS_EMP");
                    //sbQuery.Append(" ,P.PROD_COST * ISNULL(TAX.BILL_QTY,0) AS PROD_AMT");
                    sbQuery.Append(" ,TAX.BILL_AMT AS PROD_AMT ");
                    //sbQuery.Append(" ,CASE WHEN BV.BVEN_CURRENCY = '01' THEN TAX.BILL_AMT ");
                    //sbQuery.Append("       WHEN BV.BVEN_CURRENCY = '02' THEN TAX.BILL_AMT * ISNULL(CE.DOLLAR, 1) END  AS PROD_AMT");
                    sbQuery.Append(" ,P.ORD_DATE");
                    sbQuery.Append(" ,TAX.BILL_DATE");
                    sbQuery.Append(" ,BV.BVEN_CURRENCY AS CURR_UNIT");
                    sbQuery.Append(" FROM TORD_PRODUCT P");
                    //sbQuery.Append(" LEFT JOIN (SELECT PLT_CODE, PROD_CODE, SUM(BILL_QTY) AS BILL_QTY FROM TORD_PRODUCT_BILL WHERE DATA_FLAG = 0 AND BILL_TYPE = 'TAX' GROUP BY PLT_CODE,PROD_CODE) TAX");
                    //sbQuery.Append(" ON P.PLT_CODE = TAX.PLT_CODE");
                    //sbQuery.Append(" AND P.PROD_CODE = TAX.PROD_CODE");

                    sbQuery.Append(" LEFT JOIN TORD_PRODUCT_BILL TAX");
                    sbQuery.Append(" ON P.PLT_CODE = TAX.PLT_CODE");
                    sbQuery.Append(" AND P.PROD_CODE = TAX.PROD_CODE");
                    sbQuery.Append(" AND TAX.BILL_TYPE = 'TAX'");
                    sbQuery.Append(" AND TAX.DATA_FLAG = '0'");

                    //sbQuery.Append(" LEFT JOIN TSTD_COST_EXCHANGE CE");
                    //sbQuery.Append(" ON TAX.PLT_CODE = CE.PLT_CODE");
                    //sbQuery.Append(" AND LEFT(TAX.BILL_DATE, 6) = CE.MONTH");

                    sbQuery.Append(" LEFT JOIN TSTD_BILL_VENDOR BV");
                    sbQuery.Append(" ON P.PLT_CODE = BV.PLT_CODE");
                    sbQuery.Append(" AND P.TVND_CODE = BV.BVEN_CODE");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE P.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_CAT", "P.PROD_CATEGORY =  @PROD_CAT "));
                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_TYPE", "P.PROD_TYPE =  @PROD_TYPE "));
                        sbWhere.Append(UTIL.GetWhere(row, "@TVND_CODE", "P.TVND_CODE =  @TVND_CODE "));
                        sbWhere.Append(UTIL.GetWhere(row, "@EMP_CODE", "P.BUSINESS_EMP = @EMP_CODE"));
                        //sbWhere.Append(UTIL.GetWhere(row, "@WORK_YEAR", "LEFT(P.ORD_DATE,4) = @WORK_YEAR "));
                        sbWhere.Append(UTIL.GetWhere(row, "@WORK_YEAR", "LEFT(TAX.BILL_DATE,4) = @WORK_YEAR "));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_MONTH", "LEFT(TAX.BILL_DATE,6) = @S_MONTH "));
                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "P.DATA_FLAG = @DATA_FLAG"));

                        sbWhere.Append(" AND ISNULL(P.TVND_CODE,'') <> '' ");

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
        /// 개발현황 조회
        /// </summary>
        /// <param name="dtParam"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataTable TORD_PRODUCT_QUERY17(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {


                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT P.PLT_CODE");
                    sbQuery.Append(" ,P.PROD_CODE");
                    sbQuery.Append(" ,P.ITEM_CODE");
                    sbQuery.Append(" ,P.PROD_NAME");
                    sbQuery.Append(" ,P.MODEL_TYPE");
                    sbQuery.Append(" ,P.MODEL_CODE");
                    sbQuery.Append(" ,P.PROD_VERSION");
                    sbQuery.Append(" ,P.PROC_TYPE");
                    sbQuery.Append(" ,P.PROC_FLAG");
                    sbQuery.Append(" ,P.PROD_FLAG");
                    sbQuery.Append(" ,P.INS_YN");
                    sbQuery.Append(" ,P.SOCKET_YN");
                    sbQuery.Append(" ,P.PROD_TYPE");
                    sbQuery.Append(" ,P.PROD_CATEGORY");
                    sbQuery.Append(" ,P.BUSINESS_EMP");
                    sbQuery.Append(" ,P.CUSTOMER_EMP");
                    sbQuery.Append(" ,P.CUSTDESIGN_EMP");
                    sbQuery.Append(" ,P.ACTUATOR_YN");
                    sbQuery.Append(" ,P.CVND_CODE");
                    sbQuery.Append(" ,CVND.VEN_NAME AS CVND_NAME");
                    sbQuery.Append(" ,P.TVND_CODE");
                    sbQuery.Append(" ,TVND.BVEN_NAME AS TVND_NAME");
                    sbQuery.Append(" ,P.PROBE_PIN");
                    sbQuery.Append(" ,P.CURR_UNIT");
                    sbQuery.Append(" ,P.ORD_DATE");
                    sbQuery.Append(" ,P.INDUE_DATE");
                    sbQuery.Append(" ,P.DUE_DATE");
                    sbQuery.Append(" ,P.CHG_DUE_DATE");
                    sbQuery.Append(" ,P.END_DATE");
                    sbQuery.Append(" ,P.DELIVERY_DATE");
                    sbQuery.Append(" ,P.PROD_QTY");
                    sbQuery.Append(" ,P.LOAD_FLAG");
                    sbQuery.Append(" ,P.LOCK_FLAG");
                    sbQuery.Append(" ,P.LOCK_EMP");
                    sbQuery.Append(" ,P.SHIP_FLAG");
                    sbQuery.Append(" ,P.PROD_STATE");
                    sbQuery.Append(" ,P.INOUT_FLAG");
                    sbQuery.Append(" ,P.ORD_VAT");
                    sbQuery.Append(" ,P.PROD_UC");
                    sbQuery.Append(" ,P.PROD_COST");
                    sbQuery.Append(" ,P.PROD_VAT");
                    sbQuery.Append(" ,P.PROD_AMT");
                    sbQuery.Append(" ,P.PROD_KIND");
                    sbQuery.Append(" ,P.PROD_TYPE1");
                    sbQuery.Append(" ,P.PROD_TYPE2");
                    sbQuery.Append(" ,P.INS_FLAG");
                    sbQuery.Append(" ,P.TRADE_YN");
                    sbQuery.Append(" ,P.TAX_YN");
                    sbQuery.Append(" ,P.BILL_YN");
                    sbQuery.Append(" ,P.SCOMMENT");
                    sbQuery.Append(" ,P.REMARK");
                    sbQuery.Append(" ,P.MODULE_TYPE ");
                    sbQuery.Append(" ,P.PIN_TYPE ");
                    sbQuery.Append(" ,P.VISION_TYPE ");
                    sbQuery.Append(" ,P.VISION_DIRECTION ");
                    sbQuery.Append(" ,P.GND_PIN ");
                    sbQuery.Append(" ,P.FIDUCIAL_MARK ");
                    sbQuery.Append(" ,P.CROSS_MARKING ");
                    sbQuery.Append(" ,P.VACUUM ");
                    sbQuery.Append(" ,P.SOCKET_MARKING ");
                    sbQuery.Append(" ,P.MODULE_IN_TYPE ");
                    sbQuery.Append(" ,P.IF_PIN_BLOCK ");
                    sbQuery.Append(" ,P.SOCKET_OPEN_DIRECTION ");
                    sbQuery.Append(" ,P.MSOP_DFM ");
                    sbQuery.Append(" ,P.MSOP_DFM_DATE ");
                    sbQuery.Append(" ,P.DRAW_DATE ");
                    sbQuery.Append(" ,P.DRAW_TYPE ");
                    sbQuery.Append(" ,P.REG_DATE");
                    sbQuery.Append(" ,P.REG_EMP");
                    sbQuery.Append(" ,REG.EMP_NAME AS REG_EMP_NAME");
                    sbQuery.Append(" ,P.MDFY_DATE");
                    sbQuery.Append(" ,P.MDFY_EMP");
                    sbQuery.Append(" ,MDFY.EMP_NAME AS MDFY_EMP_NAME");
                    sbQuery.Append(", P.PART_CODE");
                    sbQuery.Append(", PT.PART_NAME");
                    sbQuery.Append(" ,P.ITEM_FLAG ");
                    sbQuery.Append(" ,P.PROD_PRIORITY ");
                    sbQuery.Append(" ,P.DFM_YN ");
                    sbQuery.Append(" ,P.DFM_DATE ");
                    sbQuery.Append(" ,P.MSOP_YN ");
                    sbQuery.Append(" ,P.MSOP_DATE ");
                    sbQuery.Append(" ,(SELECT CASE WHEN PROD_CODE IS NULL THEN 0 ELSE 1 END FROM TMAT_PARTLIST WHERE PLT_CODE = P.PLT_CODE AND PROD_CODE = P.PROD_CODE AND DATA_FLAG = 0 GROUP BY PROD_CODE) AS BOM_FLAG ");
                    sbQuery.Append(" FROM TORD_PRODUCT P");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE REG");
                    sbQuery.Append(" ON P.PLT_CODE = REG.PLT_CODE");
                    sbQuery.Append(" AND P.REG_EMP = REG.EMP_CODE");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE MDFY");
                    sbQuery.Append(" ON P.PLT_CODE = MDFY.PLT_CODE");
                    sbQuery.Append(" AND P.MDFY_EMP = MDFY.EMP_CODE");
                    sbQuery.Append(" LEFT JOIN TSTD_VENDOR CVND");
                    sbQuery.Append(" ON P.PLT_CODE = CVND.PLT_CODE");
                    sbQuery.Append(" AND P.CVND_CODE = CVND.VEN_CODE");
                    sbQuery.Append(" LEFT JOIN TSTD_BILL_VENDOR TVND");
                    sbQuery.Append(" ON P.PLT_CODE = TVND.PLT_CODE");
                    sbQuery.Append(" AND P.TVND_CODE = TVND.BVEN_CODE");
                    sbQuery.Append(" LEFT JOIN LSE_STD_PART PT");
                    sbQuery.Append(" ON P.PLT_CODE = PT.PLT_CODE");
                    sbQuery.Append(" AND P.PART_CODE = PT.PART_CODE");
                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE P.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_CODE", "P.PROD_CODE = @PROD_CODE"));

                        sbWhere.Append(UTIL.GetWhere(row, "@S_REG_DATE, @E_REG_DATE", "(CONVERT(nvarchar(8),P.REG_DATE,112) BETWEEN @S_REG_DATE AND @E_REG_DATE)"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_ORD_DATE, @E_ORD_DATE", "(P.ORD_DATE BETWEEN @S_ORD_DATE AND @E_ORD_DATE)"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_DUE_DATE, @E_DUE_DATE", "(P.DUE_DATE BETWEEN @S_DUE_DATE AND @E_DUE_DATE)"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_DELIVERY_DATE, @E_DELIVERY_DATE", "(P.DELIVERY_DATE BETWEEN @S_DELIVERY_DATE AND @E_DELIVERY_DATE)"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_LIKE", "P.PROD_CODE LIKE '%' + @PROD_LIKE + '%' OR P.PROD_NAME LIKE '%' + @PROD_LIKE + '%'"));
                        sbWhere.Append(UTIL.GetWhere(row, "@BUSINESS_EMP", "P.BUSINESS_EMP = @BUSINESS_EMP"));
                        sbWhere.Append(UTIL.GetWhere(row, "@CVND_LIKE", "P.CVND_CODE LIKE '%' + @CVND_LIKE + '%' OR CVND.VEN_NAME LIKE '%' + @CVND_LIKE + '%'"));
                        sbWhere.Append(UTIL.GetWhere(row, "@CVND_CODE", "P.CVND_CODE = @CVND_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@SHIP_FLAG", "P.SHIP_FLAG = @SHIP_FLAG"));
                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "P.DATA_FLAG = @DATA_FLAG"));
                        sbWhere.Append(UTIL.GetWhere(row, "@ITEM_FLAG", "P.ITEM_FLAG = @ITEM_FLAG"));

                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_FLAG", "P.PROD_FLAG = @PROD_FLAG"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_STATE", "P.PROD_STATE = @PROD_STATE"));

                        sbWhere.Append(UTIL.GetWhere(row, "@BOM_FLAG", "ISNULL(P.IF_FLAG,0) = '0' "));

                        sbWhere.Append(" AND P.PROD_STATE IN ('1','2','3','7','8','9','10') ");

                        sbWhere.Append(" ORDER BY P.PROD_CODE ");

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

        public static DataTable TORD_PRODUCT_QUERY18(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {


                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED");
                    sbQuery.Append(" SELECT P.PLT_CODE");
                    sbQuery.Append(" ,LEFT(P.ORD_DATE,6) AS ORD_MONTH");
                    sbQuery.Append(" ,ISNULL(E.EMP_CODE, P.DEV_EMP) AS EMP_CODE");
                    sbQuery.Append(" ,BE.EMP_NAME");
                    sbQuery.Append(" ,BE.WORK_LOC");
                    sbQuery.Append(" ,C.CD_NAME AS WORK_LOC_NAME");
                    sbQuery.Append(" ,P.PROD_TYPE");
                    sbQuery.Append(" ,C2.CD_NAME AS PROD_TYPE_NAME");
                    sbQuery.Append(" ,COUNT(P.PROD_CODE) AS ORD_QTY");
                    sbQuery.Append(" ,SUM(PQ.PART_QTY) AS PART_QTY");
                    sbQuery.Append(" FROM TORD_PRODUCT P");
                    sbQuery.Append(" LEFT JOIN (SELECT PLT_CODE, PROD_CODE FROM TMAT_PARTLIST WHERE DATA_FLAG = 0 GROUP BY PLT_CODE, PROD_CODE) BOM");
                    sbQuery.Append(" ON P.PLT_CODE = BOM.PLT_CODE");
                    sbQuery.Append(" AND P.PROD_CODE = BOM.PROD_CODE");
                    
                    sbQuery.Append(" LEFT JOIN (");
                    sbQuery.Append(" SELECT PLT_CODE, PROD_CODE, MAX(DRAW_EMP) AS DRAW_EMP FROM TMAT_PARTLIST");
                    sbQuery.Append(" WHERE ISNULL(O_PT_ID,'') = '' AND DATA_FLAG = '0' AND LEFT(PART_CODE,1) = 'A'");
                    sbQuery.Append(" GROUP BY PLT_CODE, PROD_CODE");
                    sbQuery.Append(" ) AD");
                    sbQuery.Append(" ON P.PLT_CODE = AD.PLT_CODE");
                    sbQuery.Append(" AND P.PROD_CODE = AD.PROD_CODE");
                    
                    sbQuery.Append(" LEFT JOIN (SELECT PLT_CODE, PROD_CODE, COUNT(PART_CODE) AS PART_QTY FROM TMAT_PARTLIST WHERE DATA_FLAG = '0' GROUP BY PLT_CODE, PROD_CODE) PQ");
                    sbQuery.Append(" ON P.PLT_CODE = PQ.PLT_CODE");
                    sbQuery.Append(" AND P.PROD_CODE = PQ.PROD_CODE");
                    
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE E");
                    sbQuery.Append(" ON AD.PLT_CODE = E.PLT_CODE");
                    sbQuery.Append(" AND AD.DRAW_EMP = E.EMP_NAME");
                    
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE BE");
                    sbQuery.Append(" ON BE.PLT_CODE = P.PLT_CODE");
                    sbQuery.Append(" AND BE.EMP_CODE = ISNULL(E.EMP_CODE, P.DEV_EMP)");
                    
                    sbQuery.Append(" LEFT JOIN TSTD_CODES C");
                    sbQuery.Append(" ON BE.PLT_CODE = C.PLT_CODE");
                    sbQuery.Append(" AND BE.WORK_LOC = C.CD_CODE");
                    sbQuery.Append(" AND C.CAT_CODE = 'E001'");
                    
                    sbQuery.Append(" LEFT JOIN TSTD_CODES C2");
                    sbQuery.Append(" ON P.PLT_CODE = C2.PLT_CODE");
                    sbQuery.Append(" AND P.PROD_TYPE = C2.CD_CODE");
                    sbQuery.Append(" AND C2.CAT_CODE = 'P010'");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE P.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@YEAR", "LEFT(P.ORD_DATE,4) = @YEAR"));
                        sbWhere.Append(UTIL.GetWhere(row, "@EMP_CODE", "BE.EMP_CODE = @EMP_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@WORK_LOC", "BE.WORK_LOC = @WORK_LOC"));
                        sbWhere.Append(" AND CASE WHEN BOM.PROD_CODE IS NULL THEN 0 ELSE 1 END = 1");
                        sbWhere.Append(" AND P.DATA_FLAG = '0'");
                        sbWhere.Append(" AND BE.EMP_CODE IS NOT NULL");

                        sbWhere.Append(" GROUP BY P.PLT_CODE");
                        sbWhere.Append(" ,LEFT(P.ORD_DATE,6)");
                        sbWhere.Append(" ,ISNULL(E.EMP_CODE, P.DEV_EMP)");
                        sbWhere.Append(" ,BE.EMP_NAME");
                        sbWhere.Append(" ,BE.WORK_LOC");
                        sbWhere.Append(" ,C.CD_NAME");
                        sbWhere.Append(" ,P.PROD_TYPE");
                        sbWhere.Append(" ,C2.CD_NAME");

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

        public static DataTable TORD_PRODUCT_QUERY19(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {


                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED");
                    sbQuery.Append(" SELECT");
                    sbQuery.Append(" P.PLT_CODE");
                    sbQuery.Append(" ,LEFT(P.ORD_DATE, 6) AS ORD_MONTH");
                    sbQuery.Append(" ,P.ITEM_FLAG");
                    sbQuery.Append(" ,C.CD_NAME AS ITEM_FLAG_NAME");
                    sbQuery.Append(" ,SUM(ISNULL(P.PROD_QTY, 0)) AS PROD_QTY");
                    sbQuery.Append(" FROM TORD_PRODUCT P");
                    sbQuery.Append(" LEFT JOIN TSTD_CODES C");
                    sbQuery.Append(" ON P.PLT_CODE = C.PLT_CODE");
                    sbQuery.Append(" AND P.ITEM_FLAG = C.CD_CODE");
                    sbQuery.Append(" AND C.CAT_CODE = 'P027'");
                    sbQuery.Append(" WHERE P.ITEM_FLAG IN ('3','5','6','7')");
                    sbQuery.Append(" AND P.DATA_FLAG = '0'");
                    sbQuery.Append(" AND LEFT(P.ORD_DATE, 4) = @YEAR");
                    sbQuery.Append(" GROUP BY");
                    sbQuery.Append(" P.PLT_CODE");
                    sbQuery.Append(" ,LEFT(P.ORD_DATE, 6)");
                    sbQuery.Append(" ,P.ITEM_FLAG");
                    sbQuery.Append(" ,C.CD_NAME");

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

        public static DataTable TORD_PRODUCT_QUERY20(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {


                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED");
                    sbQuery.Append(" SELECT");
                    sbQuery.Append(" S.PLT_CODE");
                    sbQuery.Append(" ,LEFT(SHIP_DATE, 6) AS SHIP_MONTH");
                    sbQuery.Append(" ,COUNT(P.PROD_CODE) AS SHIP_CNT");
                    sbQuery.Append(" FROM TORD_SHIP S");
                    sbQuery.Append(" LEFT JOIN TORD_PRODUCT P");
                    sbQuery.Append(" ON S.PLT_CODE = P.PLT_CODE");
                    sbQuery.Append(" AND S.PROD_CODE = P.PROD_CODE");
                    sbQuery.Append(" WHERE S.DATA_FLAG = '0'");
                    sbQuery.Append(" AND P.DATA_FLAG = '0'");
                    sbQuery.Append(" AND LEFT(SHIP_DATE, 4) = @YEAR");
                    sbQuery.Append(" GROUP BY");
                    sbQuery.Append(" S.PLT_CODE");
                    sbQuery.Append(" ,LEFT(SHIP_DATE, 6)");
                    sbQuery.Append(" ORDER BY LEFT(SHIP_DATE, 6)");



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

        public static DataTable TORD_PRODUCT_QUERY21(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {


                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED");
                    sbQuery.Append(" SELECT");
                    sbQuery.Append(" P.PLT_CODE");
                    sbQuery.Append(" ,P.CVND_CODE");
                    sbQuery.Append(" ,V.VEN_NAME AS CVND_NAME");
                    sbQuery.Append(" ,LEFT(P.ORD_DATE, 6) AS ORD_MONTH");
                    sbQuery.Append(" ,COUNT(P.PROD_CODE) AS PROD_CNT");
                    sbQuery.Append(" FROM TORD_PRODUCT P");
                    sbQuery.Append(" LEFT JOIN TSTD_CODES C");
                    sbQuery.Append(" ON P.PLT_CODE = C.PLT_CODE");
                    sbQuery.Append(" AND P.ITEM_FLAG = C.CD_CODE");
                    sbQuery.Append(" AND C.CAT_CODE = 'P027'");
                    sbQuery.Append(" LEFT JOIN TSTD_VENDOR V");
                    sbQuery.Append(" ON P.PLT_CODE = V.PLT_CODE");
                    sbQuery.Append(" AND P.CVND_CODE = V.VEN_CODE");
                    sbQuery.Append(" WHERE P.ITEM_FLAG IN ('3','5','6','7')");
                    sbQuery.Append(" AND P.DATA_FLAG = '0'");
                    sbQuery.Append(" AND P.PROD_STATE <> '5'");
                    sbQuery.Append(" AND LEFT(P.ORD_DATE, 4) = @YEAR");
                    sbQuery.Append(" GROUP BY");
                    sbQuery.Append(" P.PLT_CODE");
                    sbQuery.Append(" ,P.CVND_CODE");
                    sbQuery.Append(" ,V.VEN_NAME");
                    sbQuery.Append(" ,LEFT(P.ORD_DATE, 6)");


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

        public static DataTable TORD_PRODUCT_QUERY22(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {


                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    //sbQuery.Append(" SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED");
                    //sbQuery.Append(" SELECT");
                    //sbQuery.Append(" P.PLT_CODE");
                    //sbQuery.Append(" ,P.PROD_CODE");
                    //sbQuery.Append(" ,P.PROD_FLAG");
                    //sbQuery.Append(" ,P.ITEM_FLAG");
                    //sbQuery.Append(" ,P.PROD_TYPE");
                    //sbQuery.Append(" ,P.PROD_NAME");
                    //sbQuery.Append(" ,P.ORD_DATE");
                    //sbQuery.Append(" ,P.DUE_DATE");
                    //sbQuery.Append(" ,P.CHG_DUE_DATE");
                    //sbQuery.Append(" ,SH.SHIP_DATE");
                    //sbQuery.Append(" ,SH.SHIP_END_DATE");
                    //sbQuery.Append(" ,P.TAX_DATE");
                    //sbQuery.Append(" ,P.TRADE_DATE");

                    //sbQuery.Append(" ,P.EST_COST");
                    //sbQuery.Append(" ,P.PROD_COST");
                    //sbQuery.Append(" ,P.PROD_AMT");
                    //sbQuery.Append(" ,P.ORD_VAT");
                    //sbQuery.Append(" ,P.CURR_UNIT");

                    //sbQuery.Append(" ,P.PROD_QTY");
                    //sbQuery.Append(" ,SH.SHIP_QTY");

                    //sbQuery.Append(" ,CASE WHEN ASSY.PROD_CODE IS NOT NULL THEN 0 ELSE P.PROD_QTY END AS WIP");
                    //sbQuery.Append(" ,CASE WHEN ASSY.PROD_CODE IS NULL THEN 0 ELSE P.PROD_QTY END AS STK");
                    //sbQuery.Append(" FROM TORD_PRODUCT P");
                    //sbQuery.Append(" LEFT JOIN");
                    //sbQuery.Append(" (");
                    //sbQuery.Append(" SELECT");
                    //sbQuery.Append(" PLT_CODE");
                    //sbQuery.Append(" ,PROD_CODE");
                    //sbQuery.Append(" FROM TSHP_WORKORDER");
                    //sbQuery.Append(" WHERE PROC_CODE = 'P-09'");
                    //sbQuery.Append(" AND DATA_FLAG = '0'");
                    //sbQuery.Append(" AND WO_FLAG = '4'");
                    //sbQuery.Append(" )");
                    //sbQuery.Append(" ASSY");
                    //sbQuery.Append(" ON P.PLT_CODE = ASSY.PLT_CODE");
                    //sbQuery.Append(" AND P.PROD_CODE = ASSY.PROD_CODE");

                    //sbQuery.Append(" LEFT JOIN (SELECT PLT_CODE,PROD_CODE,MAX(SHIP_DATE) AS SHIP_DATE ,SUM(SHIP_QTY) AS SHIP_QTY, MAX(SHIP_END_DATE) AS SHIP_END_DATE FROM TORD_SHIP WHERE DATA_FLAG = 0 GROUP BY PLT_CODE,PROD_CODE) SH");
                    //sbQuery.Append(" ON P.PLT_CODE = SH.PLT_CODE");
                    //sbQuery.Append(" AND P.PROD_CODE = SH.PROD_CODE");

                    //sbQuery.Append(" WHERE P.DATA_FLAG = '0'");
                    //sbQuery.Append(" AND P.PROD_KIND = 'PD'");
                    ////sbQuery.Append(" AND LEFT(P.ORD_DATE,4) = @YEAR");
                    //sbQuery.Append(" AND LEFT(P.ORD_DATE,6) BETWEEN @S_MONTH AND @E_MONTH");
                    //sbQuery.Append(" AND PROD_STATE <> '5'");
                    //sbQuery.Append(" ORDER BY PROD_CODE");

                    sbQuery.Append(" SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED");
                    sbQuery.Append(" SELECT");
                    sbQuery.Append(" P.PLT_CODE");
                    sbQuery.Append(" ,P.PROD_CODE");
                    sbQuery.Append(" ,P.PROD_FLAG");
                    sbQuery.Append(" ,P.ITEM_FLAG");
                    sbQuery.Append(" ,P.PROD_TYPE");
                    sbQuery.Append(" ,P.PROD_NAME");
                    sbQuery.Append(" ,P.ORD_DATE");
                    sbQuery.Append(" ,P.DUE_DATE");
                    sbQuery.Append(" ,P.CHG_DUE_DATE");
                    sbQuery.Append(" ,SH.SHIP_DATE");
                    sbQuery.Append(" ,SH.SHIP_END_DATE");
                    sbQuery.Append(" ,P.TAX_DATE");
                    sbQuery.Append(" ,P.TRADE_DATE");
                    sbQuery.Append(" ,P.EST_COST");
                    sbQuery.Append(" ,P.PROD_COST");
                    sbQuery.Append(" ,P.PROD_AMT");
                    sbQuery.Append(" ,P.ORD_VAT");
                    sbQuery.Append(" ,P.CURR_UNIT");
                    sbQuery.Append(" ,P.PROD_KIND");
                    sbQuery.Append(" ,P.PROD_QTY");
                    sbQuery.Append(" ,SH.SHIP_QTY");
                    sbQuery.Append(" ,P.CVND_CODE");
                    sbQuery.Append(" ,V.VEN_NAME AS CVND_NAME");

                    sbQuery.Append(" ,P.TVND_CODE");
                    sbQuery.Append(" ,TVND.BVEN_NAME AS TVND_NAME");


                    sbQuery.Append(" ,ISNULL(CASE WHEN CASE WHEN BILL.BILL_QTY >= P.PROD_QTY THEN BILL.BILL_DATE ELSE NULL END IS NOT NULL THEN 0");
                    sbQuery.Append(" WHEN WSH.SHIP_DATE IS NOT NULL THEN 0");
                    sbQuery.Append(" WHEN P.PROD_KIND <> 'IE' AND INS.ACT_END_DATE IS NULL THEN P.PROD_QTY");
                    sbQuery.Append(" WHEN CASE WHEN OU.OUT_QTY >= P.PROD_QTY THEN OU.OUT_DATE ELSE NULL END IS NOT NULL THEN 0 END, 0) WIP");
                    sbQuery.Append(" ,CASE WHEN CASE WHEN BILL.BILL_QTY >= P.PROD_QTY THEN BILL.BILL_DATE ELSE NULL END IS NOT NULL THEN 0");
                    sbQuery.Append(" ELSE P.PROD_QTY -");
                    sbQuery.Append(" (ISNULL(CASE WHEN CASE WHEN BILL.BILL_QTY >= P.PROD_QTY THEN BILL.BILL_DATE ELSE NULL END IS NOT NULL THEN 0");
                    sbQuery.Append(" WHEN WSH.SHIP_DATE IS NOT NULL THEN 0");
                    sbQuery.Append(" WHEN P.PROD_KIND <> 'IE' AND INS.ACT_END_DATE IS NULL THEN P.PROD_QTY");
                    sbQuery.Append(" WHEN CASE WHEN OU.OUT_QTY >= P.PROD_QTY THEN OU.OUT_DATE ELSE NULL END IS NOT NULL THEN 0 END,0))");
                    sbQuery.Append(" END STK");


                    sbQuery.Append(" FROM TORD_PRODUCT P");

                    sbQuery.Append(" LEFT JOIN");
                    sbQuery.Append(" (");
                    sbQuery.Append(" SELECT PLT_CODE, PROD_CODE, MAX(SHIP_DATE) AS SHIP_DATE FROM TORD_SHIP WHERE DATA_FLAG = '0'");
                    sbQuery.Append(" GROUP BY PLT_CODE, PROD_CODE HAVING LEFT(MAX(SHIP_DATE), 6) <= @STD_MONTH");
                    sbQuery.Append(" ) WSH");
                    sbQuery.Append(" ON P.PLT_CODE = WSH.PLT_CODE");
                    sbQuery.Append(" AND P.PROD_CODE = WSH.PROD_CODE");
                    sbQuery.Append(" LEFT JOIN");
                    sbQuery.Append(" (");
                    sbQuery.Append(" SELECT PLT_CODE, PROD_CODE, MAX(SHIP_DATE) AS SHIP_DATE, MAX(SHIP_END_DATE) AS SHIP_END_DATE, SUM(SHIP_QTY) AS SHIP_QTY FROM TORD_SHIP WHERE DATA_FLAG = '0'");
                    sbQuery.Append(" GROUP BY PLT_CODE, PROD_CODE");
                    sbQuery.Append(" ) SH");
                    sbQuery.Append(" ON P.PLT_CODE = SH.PLT_CODE");
                    sbQuery.Append(" AND P.PROD_CODE = SH.PROD_CODE");
                    sbQuery.Append(" LEFT JOIN");
                    sbQuery.Append(" (");
                    sbQuery.Append(" SELECT PLT_CODE, PROD_CODE, SUM(BILL_QTY) AS BILL_QTY, MAX(BILL_DATE) AS BILL_DATE FROM TORD_PRODUCT_BILL");
                    sbQuery.Append(" WHERE DATA_FLAG = '0'");
                    sbQuery.Append(" GROUP BY PLT_CODE, PROD_CODE HAVING LEFT(MAX(BILL_DATE), 6) <= @STD_MONTH");
                    sbQuery.Append(" ) BILL");
                    sbQuery.Append(" ON P.PLT_CODE = BILL.PLT_CODE");
                    sbQuery.Append(" AND P.PROD_CODE = BILL.PROD_CODE");
                    sbQuery.Append(" LEFT JOIN");
                    sbQuery.Append(" (");
                    sbQuery.Append(" SELECT PLT_CODE, PROD_CODE, CONVERT(VARCHAR(8), ACT_END_TIME, 112) AS ACT_END_DATE FROM TSHP_WORKORDER");
                    sbQuery.Append(" WHERE DATA_FLAG = '0' AND PROC_CODE = 'P-12' AND WO_FLAG = '4'");
                    sbQuery.Append(" AND LEFT(CONVERT(VARCHAR(8), ACT_END_TIME , 112), 6) < @STD_MONTH");
                    sbQuery.Append(" ) INS");
                    sbQuery.Append(" ON P.PLT_CODE = INS.PLT_CODE");
                    sbQuery.Append(" AND P.PROD_CODE = INS.PROD_CODE");
                    sbQuery.Append(" LEFT JOIN");
                    sbQuery.Append(" (");
                    sbQuery.Append(" SELECT O.PLT_CODE, PT.PROD_CODE, MAX(O.OUT_DATE) AS OUT_DATE, SUM(O.OUT_QTY) AS OUT_QTY FROM TMAT_OUT O");
                    sbQuery.Append(" LEFT JOIN TMAT_OUT_REQ OREQ");
                    sbQuery.Append(" ON O.PLT_CODE = OREQ.PLT_CODE");
                    sbQuery.Append(" AND O.OUT_REQ_ID = OREQ.OUT_REQ_ID");
                    sbQuery.Append(" LEFT JOIN TMAT_PARTLIST PT");
                    sbQuery.Append(" ON OREQ.PLT_CODE = PT.PLT_CODE");
                    sbQuery.Append(" AND OREQ.PT_ID = PT.PT_ID");
                    sbQuery.Append(" LEFT JOIN TORD_PRODUCT P");
                    sbQuery.Append(" ON PT.PLT_CODE = P.PLT_CODE");
                    sbQuery.Append(" AND PT.PROD_CODE = P.PROD_CODE");
                    sbQuery.Append(" WHERE O.DATA_FLAG = '0' AND OREQ.DATA_FLAG = '0' AND P.PROD_KIND = 'IE'");
                    sbQuery.Append(" GROUP BY O.PLT_CODE, PT.PROD_CODE HAVING LEFT(MAX(O.OUT_DATE), 6) <= @STD_MONTH");
                    sbQuery.Append(" ) OU");
                    sbQuery.Append(" ON P.PLT_CODE = OU.PLT_CODE");
                    sbQuery.Append(" AND P.PROD_CODE = OU.PROD_CODE");

                    sbQuery.Append(" LEFT JOIN TSTD_VENDOR V");
                    sbQuery.Append(" ON P.PLT_CODE = V.PLT_CODE");
                    sbQuery.Append(" AND P.CVND_CODE = V.VEN_CODE");

                    sbQuery.Append(" LEFT JOIN TSTD_BILL_VENDOR TVND");
                    sbQuery.Append(" ON P.PLT_CODE = TVND.PLT_CODE");
                    sbQuery.Append(" AND P.TVND_CODE = TVND.BVEN_CODE");

                    sbQuery.Append(" WHERE LEFT(P.ORD_DATE,6) BETWEEN @S_MONTH AND @E_MONTH");
                    sbQuery.Append(" AND P.PROD_STATE <> '5' AND P.DATA_FLAG = '0'");

                    sbQuery.Append(" GROUP BY");
                    sbQuery.Append(" P.PLT_CODE");
                    sbQuery.Append(" ,P.PROD_CODE");
                    sbQuery.Append(" ,P.PROD_FLAG");
                    sbQuery.Append(" ,P.ITEM_FLAG");
                    sbQuery.Append(" ,P.PROD_TYPE");
                    sbQuery.Append(" ,P.PROD_NAME");
                    sbQuery.Append(" ,P.ORD_DATE");
                    sbQuery.Append(" ,P.DUE_DATE");
                    sbQuery.Append(" ,P.CHG_DUE_DATE");
                    sbQuery.Append(" ,SH.SHIP_DATE");
                    sbQuery.Append(" ,SH.SHIP_END_DATE");
                    sbQuery.Append(" ,P.TAX_DATE");
                    sbQuery.Append(" ,P.TRADE_DATE");
                    sbQuery.Append(" ,P.EST_COST");
                    sbQuery.Append(" ,P.PROD_COST");
                    sbQuery.Append(" ,P.PROD_AMT");
                    sbQuery.Append(" ,P.ORD_VAT");
                    sbQuery.Append(" ,P.CURR_UNIT");
                    sbQuery.Append(" ,P.PROD_KIND");
                    sbQuery.Append(" ,P.PROD_QTY");
                    sbQuery.Append(" ,SH.SHIP_QTY");
                    sbQuery.Append(" ,P.CVND_CODE");
                    sbQuery.Append(" ,V.VEN_NAME");

                    sbQuery.Append(" ,P.TVND_CODE");
                    sbQuery.Append(" ,TVND.BVEN_NAME");

                    sbQuery.Append(" ,ISNULL(CASE WHEN CASE WHEN BILL.BILL_QTY >= P.PROD_QTY THEN BILL.BILL_DATE ELSE NULL END IS NOT NULL THEN 0");
                    sbQuery.Append(" WHEN WSH.SHIP_DATE IS NOT NULL THEN 0");
                    sbQuery.Append(" WHEN P.PROD_KIND <> 'IE' AND INS.ACT_END_DATE IS NULL THEN P.PROD_QTY");
                    sbQuery.Append(" WHEN CASE WHEN OU.OUT_QTY >= P.PROD_QTY THEN OU.OUT_DATE ELSE NULL END IS NOT NULL THEN 0 END, 0)");

                    sbQuery.Append(" ,CASE WHEN CASE WHEN BILL.BILL_QTY >= P.PROD_QTY THEN BILL.BILL_DATE ELSE NULL END IS NOT NULL THEN 0");
                    sbQuery.Append(" ELSE P.PROD_QTY -");
                    sbQuery.Append(" (ISNULL(CASE WHEN CASE WHEN BILL.BILL_QTY >= P.PROD_QTY THEN BILL.BILL_DATE ELSE NULL END IS NOT NULL THEN 0");
                    sbQuery.Append(" WHEN WSH.SHIP_DATE IS NOT NULL THEN 0");
                    sbQuery.Append(" WHEN P.PROD_KIND <> 'IE' AND INS.ACT_END_DATE IS NULL THEN P.PROD_QTY");
                    sbQuery.Append(" WHEN CASE WHEN OU.OUT_QTY >= P.PROD_QTY THEN OU.OUT_DATE ELSE NULL END IS NOT NULL THEN 0 END,0))");
                    sbQuery.Append(" END");

                    sbQuery.Append(" ORDER BY P.PROD_CODE");

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

        public static DataTable TORD_PRODUCT_QUERY22_2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {


                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    //sbQuery.Append(" SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED");
                    //sbQuery.Append(" SELECT");
                    //sbQuery.Append(" P.PLT_CODE");
                    //sbQuery.Append(" ,P.PROD_CODE");
                    //sbQuery.Append(" ,P.PROD_FLAG");
                    //sbQuery.Append(" ,P.ITEM_FLAG");
                    //sbQuery.Append(" ,P.PROD_TYPE");
                    //sbQuery.Append(" ,P.PROD_NAME");
                    //sbQuery.Append(" ,P.ORD_DATE");
                    //sbQuery.Append(" ,P.DUE_DATE");
                    //sbQuery.Append(" ,P.CHG_DUE_DATE");
                    //sbQuery.Append(" ,SH.SHIP_DATE");
                    //sbQuery.Append(" ,SH.SHIP_END_DATE");
                    //sbQuery.Append(" ,P.TAX_DATE");
                    //sbQuery.Append(" ,P.TRADE_DATE");

                    //sbQuery.Append(" ,P.EST_COST");
                    //sbQuery.Append(" ,P.PROD_COST");
                    //sbQuery.Append(" ,P.PROD_AMT");
                    //sbQuery.Append(" ,P.ORD_VAT");
                    //sbQuery.Append(" ,P.CURR_UNIT");

                    //sbQuery.Append(" ,P.PROD_QTY");
                    //sbQuery.Append(" ,SH.SHIP_QTY");

                    //sbQuery.Append(" ,CASE WHEN ASSY.PROD_CODE IS NOT NULL THEN 0 ELSE P.PROD_QTY END AS WIP");
                    //sbQuery.Append(" ,CASE WHEN ASSY.PROD_CODE IS NULL THEN 0 ELSE P.PROD_QTY END AS STK");
                    //sbQuery.Append(" FROM TORD_PRODUCT P");
                    //sbQuery.Append(" LEFT JOIN");
                    //sbQuery.Append(" (");
                    //sbQuery.Append(" SELECT");
                    //sbQuery.Append(" PLT_CODE");
                    //sbQuery.Append(" ,PROD_CODE");
                    //sbQuery.Append(" FROM TSHP_WORKORDER");
                    //sbQuery.Append(" WHERE PROC_CODE = 'P-09'");
                    //sbQuery.Append(" AND DATA_FLAG = '0'");
                    //sbQuery.Append(" AND WO_FLAG = '4'");
                    //sbQuery.Append(" )");
                    //sbQuery.Append(" ASSY");
                    //sbQuery.Append(" ON P.PLT_CODE = ASSY.PLT_CODE");
                    //sbQuery.Append(" AND P.PROD_CODE = ASSY.PROD_CODE");

                    //sbQuery.Append(" LEFT JOIN (SELECT PLT_CODE,PROD_CODE,MAX(SHIP_DATE) AS SHIP_DATE ,SUM(SHIP_QTY) AS SHIP_QTY, MAX(SHIP_END_DATE) AS SHIP_END_DATE FROM TORD_SHIP WHERE DATA_FLAG = 0 GROUP BY PLT_CODE,PROD_CODE) SH");
                    //sbQuery.Append(" ON P.PLT_CODE = SH.PLT_CODE");
                    //sbQuery.Append(" AND P.PROD_CODE = SH.PROD_CODE");

                    //sbQuery.Append(" WHERE P.DATA_FLAG = '0'");
                    //sbQuery.Append(" AND P.PROD_KIND = 'PD'");
                    ////sbQuery.Append(" AND LEFT(P.ORD_DATE,4) = @YEAR");
                    //sbQuery.Append(" AND LEFT(P.ORD_DATE,6) BETWEEN @S_MONTH AND @E_MONTH");
                    //sbQuery.Append(" AND PROD_STATE <> '5'");
                    //sbQuery.Append(" ORDER BY PROD_CODE");

                    sbQuery.Append(" SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED");
                    sbQuery.Append(" SELECT");
                    sbQuery.Append(" P.PLT_CODE");
                    sbQuery.Append(" ,P.PROD_CODE");
                    sbQuery.Append(" ,P.PROD_FLAG");
                    sbQuery.Append(" ,P.ITEM_FLAG");
                    sbQuery.Append(" ,P.PROD_TYPE");
                    sbQuery.Append(" ,P.PROD_NAME");
                    sbQuery.Append(" ,P.ORD_DATE");
                    sbQuery.Append(" ,P.DUE_DATE");
                    sbQuery.Append(" ,P.CHG_DUE_DATE");
                    sbQuery.Append(" ,SH.SHIP_DATE");
                    sbQuery.Append(" ,SH.SHIP_END_DATE");
                    sbQuery.Append(" ,P.TAX_DATE");
                    sbQuery.Append(" ,P.TRADE_DATE");
                    sbQuery.Append(" ,P.EST_COST");
                    sbQuery.Append(" ,P.PROD_COST");
                    sbQuery.Append(" ,P.PROD_AMT");
                    sbQuery.Append(" ,P.ORD_VAT");
                    sbQuery.Append(" ,P.CURR_UNIT");
                    sbQuery.Append(" ,P.PROD_KIND");
                    sbQuery.Append(" ,P.PROD_QTY");
                    sbQuery.Append(" ,SH.SHIP_QTY");
                    sbQuery.Append(" ,P.CVND_CODE");
                    sbQuery.Append(" ,V.VEN_NAME AS CVND_NAME");

                    sbQuery.Append(" ,ISNULL(CASE WHEN CASE WHEN BILL.BILL_QTY >= P.PROD_QTY THEN BILL.BILL_DATE ELSE NULL END IS NOT NULL THEN 0");
                    sbQuery.Append(" WHEN WSH.SHIP_DATE IS NOT NULL THEN 0");
                    sbQuery.Append(" WHEN P.PROD_KIND <> 'IE' AND INS.ACT_END_DATE IS NULL THEN P.PROD_QTY");
                    sbQuery.Append(" WHEN CASE WHEN OU.OUT_QTY >= P.PROD_QTY THEN OU.OUT_DATE ELSE NULL END IS NOT NULL THEN 0 END, 0) WIP");
                    sbQuery.Append(" ,CASE WHEN CASE WHEN BILL.BILL_QTY >= P.PROD_QTY THEN BILL.BILL_DATE ELSE NULL END IS NOT NULL THEN 0");
                    sbQuery.Append(" ELSE P.PROD_QTY -");
                    sbQuery.Append(" (ISNULL(CASE WHEN CASE WHEN BILL.BILL_QTY >= P.PROD_QTY THEN BILL.BILL_DATE ELSE NULL END IS NOT NULL THEN 0");
                    sbQuery.Append(" WHEN WSH.SHIP_DATE IS NOT NULL THEN 0");
                    sbQuery.Append(" WHEN P.PROD_KIND <> 'IE' AND INS.ACT_END_DATE IS NULL THEN P.PROD_QTY");
                    sbQuery.Append(" WHEN CASE WHEN OU.OUT_QTY >= P.PROD_QTY THEN OU.OUT_DATE ELSE NULL END IS NOT NULL THEN 0 END,0))");
                    sbQuery.Append(" END STK");


                    sbQuery.Append(" FROM TORD_PRODUCT P");

                    sbQuery.Append(" LEFT JOIN");
                    sbQuery.Append(" (");
                    sbQuery.Append(" SELECT PLT_CODE, PROD_CODE, MAX(SHIP_DATE) AS SHIP_DATE FROM TORD_SHIP WHERE DATA_FLAG = '0'");
                    sbQuery.Append(" GROUP BY PLT_CODE, PROD_CODE HAVING LEFT(MAX(SHIP_DATE), 6) <= @S_MONTH");
                    sbQuery.Append(" ) WSH");
                    sbQuery.Append(" ON P.PLT_CODE = WSH.PLT_CODE");
                    sbQuery.Append(" AND P.PROD_CODE = WSH.PROD_CODE");
                    sbQuery.Append(" LEFT JOIN");
                    sbQuery.Append(" (");
                    sbQuery.Append(" SELECT PLT_CODE, PROD_CODE, MAX(SHIP_DATE) AS SHIP_DATE, MAX(SHIP_END_DATE) AS SHIP_END_DATE, SUM(SHIP_QTY) AS SHIP_QTY FROM TORD_SHIP WHERE DATA_FLAG = '0'");
                    sbQuery.Append(" GROUP BY PLT_CODE, PROD_CODE");
                    sbQuery.Append(" ) SH");
                    sbQuery.Append(" ON P.PLT_CODE = SH.PLT_CODE");
                    sbQuery.Append(" AND P.PROD_CODE = SH.PROD_CODE");
                    sbQuery.Append(" LEFT JOIN");
                    sbQuery.Append(" (");
                    sbQuery.Append(" SELECT PLT_CODE, PROD_CODE, SUM(BILL_QTY) AS BILL_QTY, MAX(BILL_DATE) AS BILL_DATE FROM TORD_PRODUCT_BILL");
                    sbQuery.Append(" WHERE DATA_FLAG = '0'");
                    sbQuery.Append(" GROUP BY PLT_CODE, PROD_CODE HAVING LEFT(MAX(BILL_DATE), 6) <= @S_MONTH");
                    sbQuery.Append(" ) BILL");
                    sbQuery.Append(" ON P.PLT_CODE = BILL.PLT_CODE");
                    sbQuery.Append(" AND P.PROD_CODE = BILL.PROD_CODE");
                    sbQuery.Append(" LEFT JOIN");
                    sbQuery.Append(" (");
                    sbQuery.Append(" SELECT PLT_CODE, PROD_CODE, CONVERT(VARCHAR(8), ACT_END_TIME, 112) AS ACT_END_DATE FROM TSHP_WORKORDER");
                    sbQuery.Append(" WHERE DATA_FLAG = '0' AND PROC_CODE = 'P-12' AND WO_FLAG = '4'");
                    sbQuery.Append(" AND LEFT(CONVERT(VARCHAR(8), ACT_END_TIME , 112), 6) < @S_MONTH");
                    sbQuery.Append(" ) INS");
                    sbQuery.Append(" ON P.PLT_CODE = INS.PLT_CODE");
                    sbQuery.Append(" AND P.PROD_CODE = INS.PROD_CODE");
                    sbQuery.Append(" LEFT JOIN");
                    sbQuery.Append(" (");
                    sbQuery.Append(" SELECT O.PLT_CODE, PT.PROD_CODE, MAX(O.OUT_DATE) AS OUT_DATE, SUM(O.OUT_QTY) AS OUT_QTY FROM TMAT_OUT O");
                    sbQuery.Append(" LEFT JOIN TMAT_OUT_REQ OREQ");
                    sbQuery.Append(" ON O.PLT_CODE = OREQ.PLT_CODE");
                    sbQuery.Append(" AND O.OUT_REQ_ID = OREQ.OUT_REQ_ID");
                    sbQuery.Append(" LEFT JOIN TMAT_PARTLIST PT");
                    sbQuery.Append(" ON OREQ.PLT_CODE = PT.PLT_CODE");
                    sbQuery.Append(" AND OREQ.PT_ID = PT.PT_ID");
                    sbQuery.Append(" LEFT JOIN TORD_PRODUCT P");
                    sbQuery.Append(" ON PT.PLT_CODE = P.PLT_CODE");
                    sbQuery.Append(" AND PT.PROD_CODE = P.PROD_CODE");
                    sbQuery.Append(" WHERE O.DATA_FLAG = '0' AND OREQ.DATA_FLAG = '0' AND P.PROD_KIND = 'IE'");
                    sbQuery.Append(" GROUP BY O.PLT_CODE, PT.PROD_CODE HAVING LEFT(MAX(O.OUT_DATE), 6) <= @S_MONTH");
                    sbQuery.Append(" ) OU");
                    sbQuery.Append(" ON P.PLT_CODE = OU.PLT_CODE");
                    sbQuery.Append(" AND P.PROD_CODE = OU.PROD_CODE");

                    sbQuery.Append(" LEFT JOIN TSTD_VENDOR V");
                    sbQuery.Append(" ON P.PLT_CODE = V.PLT_CODE");
                    sbQuery.Append(" AND P.CVND_CODE = V.VEN_CODE");

                    sbQuery.Append(" AND P.PROD_STATE <> '5' AND P.DATA_FLAG = '0'");

                    sbQuery.Append(" GROUP BY");
                    sbQuery.Append(" P.PLT_CODE");
                    sbQuery.Append(" ,P.PROD_CODE");
                    sbQuery.Append(" ,P.PROD_FLAG");
                    sbQuery.Append(" ,P.ITEM_FLAG");
                    sbQuery.Append(" ,P.PROD_TYPE");
                    sbQuery.Append(" ,P.PROD_NAME");
                    sbQuery.Append(" ,P.ORD_DATE");
                    sbQuery.Append(" ,P.DUE_DATE");
                    sbQuery.Append(" ,P.CHG_DUE_DATE");
                    sbQuery.Append(" ,SH.SHIP_DATE");
                    sbQuery.Append(" ,SH.SHIP_END_DATE");
                    sbQuery.Append(" ,P.TAX_DATE");
                    sbQuery.Append(" ,P.TRADE_DATE");
                    sbQuery.Append(" ,P.EST_COST");
                    sbQuery.Append(" ,P.PROD_COST");
                    sbQuery.Append(" ,P.PROD_AMT");
                    sbQuery.Append(" ,P.ORD_VAT");
                    sbQuery.Append(" ,P.CURR_UNIT");
                    sbQuery.Append(" ,P.PROD_KIND");
                    sbQuery.Append(" ,P.PROD_QTY");
                    sbQuery.Append(" ,SH.SHIP_QTY");
                    sbQuery.Append(" ,P.CVND_CODE");
                    sbQuery.Append(" ,V.VEN_NAME");

                    sbQuery.Append(" ,ISNULL(CASE WHEN CASE WHEN BILL.BILL_QTY >= P.PROD_QTY THEN BILL.BILL_DATE ELSE NULL END IS NOT NULL THEN 0");
                    sbQuery.Append(" WHEN WSH.SHIP_DATE IS NOT NULL THEN 0");
                    sbQuery.Append(" WHEN P.PROD_KIND <> 'IE' AND INS.ACT_END_DATE IS NULL THEN P.PROD_QTY");
                    sbQuery.Append(" WHEN CASE WHEN OU.OUT_QTY >= P.PROD_QTY THEN OU.OUT_DATE ELSE NULL END IS NOT NULL THEN 0 END, 0)");

                    sbQuery.Append(" ,CASE WHEN CASE WHEN BILL.BILL_QTY >= P.PROD_QTY THEN BILL.BILL_DATE ELSE NULL END IS NOT NULL THEN 0");
                    sbQuery.Append(" ELSE P.PROD_QTY -");
                    sbQuery.Append(" (ISNULL(CASE WHEN CASE WHEN BILL.BILL_QTY >= P.PROD_QTY THEN BILL.BILL_DATE ELSE NULL END IS NOT NULL THEN 0");
                    sbQuery.Append(" WHEN WSH.SHIP_DATE IS NOT NULL THEN 0");
                    sbQuery.Append(" WHEN P.PROD_KIND <> 'IE' AND INS.ACT_END_DATE IS NULL THEN P.PROD_QTY");
                    sbQuery.Append(" WHEN CASE WHEN OU.OUT_QTY >= P.PROD_QTY THEN OU.OUT_DATE ELSE NULL END IS NOT NULL THEN 0 END,0))");
                    sbQuery.Append(" END");

                    sbQuery.Append(" ORDER BY P.PROD_CODE");

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


        public static DataTable TORD_PRODUCT_QUERY23(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED");
                    //sbQuery.Append(" SELECT");
                    //sbQuery.Append(" P.PLT_CODE");
                    //sbQuery.Append(" ,P.PROD_CODE");
                    //sbQuery.Append(" ,ISNULL(C.CD_PARENT, '1') AS CD_PARENT");
                    //sbQuery.Append(" ,ACT_END_DATE");
                    //sbQuery.Append(" ,P.PROD_QTY");
                    //sbQuery.Append(" ,WO.PART_QTY");
                    //sbQuery.Append(" FROM TORD_PRODUCT P");
                    //sbQuery.Append(" JOIN");
                    //sbQuery.Append(" (");
                    //sbQuery.Append(" SELECT DISTINCT PLT_CODE, PROD_CODE FROM");
                    //sbQuery.Append(" (");
                    //sbQuery.Append(" SELECT * FROM TMAT_PARTLIST");
                    //sbQuery.Append(" WHERE MATERIAL LIKE '%AL%'");
                    //sbQuery.Append(" AND DATA_FLAG = '0'");
                    //sbQuery.Append(" UNION ALL");
                    //sbQuery.Append(" SELECT * FROM TMAT_PARTLIST");
                    //sbQuery.Append(" WHERE MATERIAL LIKE '%BE-CU%'");
                    //sbQuery.Append(" AND DATA_FLAG = '0'");
                    //sbQuery.Append(" UNION ALL");
                    //sbQuery.Append(" SELECT * FROM TMAT_PARTLIST");
                    //sbQuery.Append(" WHERE MATERIAL LIKE '%BRASS%'");
                    //sbQuery.Append(" AND DATA_FLAG = '0'");
                    //sbQuery.Append(" ) A");
                    //sbQuery.Append(" ) W");
                    //sbQuery.Append(" ON P.PLT_CODE = W.PLT_CODE");
                    //sbQuery.Append(" AND P.PROD_CODE = W.PROD_CODE");
                    //sbQuery.Append(" LEFT JOIN TSTD_CODES C");
                    //sbQuery.Append(" ON P.PLT_CODE = C.PLT_CODE");
                    //sbQuery.Append(" AND P.PROD_TYPE = C.CD_CODE");
                    //sbQuery.Append(" AND C.CAT_CODE = 'P010'");
                    //sbQuery.Append(" JOIN (SELECT PLT_CODE, PROD_CODE, PART_CODE, CONVERT(VARCHAR(8), ACT_END_TIME, 112) ACT_END_DATE");
                    //sbQuery.Append(" , PART_QTY FROM TSHP_WORKORDER");
                    //sbQuery.Append(" WHERE PLT_CODE = '100' AND CONVERT(VARCHAR(8), ACT_END_TIME, 112) BETWEEN @S_DATE AND @E_DATE");
                    //sbQuery.Append(" AND WO_FLAG = '4' AND PROC_CODE = @PROC_CODE AND DATA_FLAG = '0') WO");
                    //sbQuery.Append(" ON WO.PLT_CODE = P.PLT_CODE");
                    //sbQuery.Append(" AND WO.PROD_CODE = P.PROD_CODE");
                    //sbQuery.Append(" ORDER BY ACT_END_DATE");


                    sbQuery.Append(" SELECT");
                    sbQuery.Append(" A.PLT_CODE");
                    sbQuery.Append(" ,A.PROD_CODE");
                    sbQuery.Append(" ,ISNULL(D.CD_PARENT, '1') AS CD_PARENT");
                    sbQuery.Append(" ,CONVERT(VARCHAR(8), ACT_END_TIME, 112) AS ACT_END_DATE");
                    sbQuery.Append(" ,C.PROD_QTY");
                    sbQuery.Append(" ,A.PART_QTY");
                    sbQuery.Append(" ,B.MATERIAL");
                    sbQuery.Append(" FROM TSHP_WORKORDER A");
                    sbQuery.Append(" LEFT JOIN TMAT_PARTLIST B");
                    sbQuery.Append(" ON A.PLT_CODE = B.PLT_CODE");
                    sbQuery.Append(" AND A.PT_ID = B.PT_ID");
                    sbQuery.Append(" LEFT JOIN TORD_PRODUCT C");
                    sbQuery.Append(" ON A.PLT_CODE = C.PLT_CODE");
                    sbQuery.Append(" AND A.PROD_CODE = C.PROD_CODE");
                    sbQuery.Append(" LEFT JOIN TSTD_CODES D");
                    sbQuery.Append(" ON C.PLT_CODE = D.PLT_CODE");
                    sbQuery.Append(" AND C.PROD_TYPE = D.CD_CODE");
                    sbQuery.Append(" AND D.CAT_CODE = 'P010'");
                    sbQuery.Append(" WHERE A.PLT_CODE = '100' AND CONVERT(VARCHAR(8), A.ACT_END_TIME, 112) BETWEEN @S_DATE AND @E_DATE");
                    sbQuery.Append(" AND A.WO_FLAG = '4' AND A.PROC_CODE = @PROC_CODE AND A.DATA_FLAG = '0'");
                    sbQuery.Append(" AND (B.MATERIAL LIKE '%AL%' OR B.MATERIAL LIKE '%BE-CU%' OR B.MATERIAL LIKE '%BRASS%')");
                    sbQuery.Append(" ORDER BY CONVERT(VARCHAR(8), ACT_END_TIME, 112)");


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

        public static DataTable TORD_PRODUCT_QUERY24(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED");
                    //sbQuery.Append(" SELECT");
                    //sbQuery.Append(" P.PLT_CODE");
                    //sbQuery.Append(" ,P.PROD_CODE");
                    //sbQuery.Append(" ,ISNULL(C.CD_PARENT, '1') AS CD_PARENT");
                    //sbQuery.Append(" ,ACT_END_DATE");
                    //sbQuery.Append(" ,P.PROD_QTY");
                    //sbQuery.Append(" ,WO.PART_QTY");
                    //sbQuery.Append(" FROM TORD_PRODUCT P");
                    //sbQuery.Append(" JOIN");
                    //sbQuery.Append(" (");
                    //sbQuery.Append(" SELECT DISTINCT PLT_CODE, PROD_CODE FROM");
                    //sbQuery.Append(" (");
                    //sbQuery.Append(" SELECT * FROM TMAT_PARTLIST");
                    //sbQuery.Append(" WHERE ISNULL(MATERIAL,'0') NOT LIKE '%AL%'");
                    //sbQuery.Append(" AND DATA_FLAG = '0'");
                    //sbQuery.Append(" UNION ALL");
                    //sbQuery.Append(" SELECT * FROM TMAT_PARTLIST");
                    //sbQuery.Append(" WHERE ISNULL(MATERIAL,'0') NOT LIKE '%BE-CU%'");
                    //sbQuery.Append(" AND DATA_FLAG = '0'");
                    //sbQuery.Append(" UNION ALL");
                    //sbQuery.Append(" SELECT * FROM TMAT_PARTLIST");
                    //sbQuery.Append(" WHERE ISNULL(MATERIAL,'0') NOT LIKE '%BRASS%'");
                    //sbQuery.Append(" AND DATA_FLAG = '0'");
                    //sbQuery.Append(" UNION ALL");
                    //sbQuery.Append(" SELECT * FROM TMAT_PARTLIST");
                    //sbQuery.Append(" WHERE ISNULL(MATERIAL,'0') NOT LIKE '%SKD11%'");
                    //sbQuery.Append(" AND DATA_FLAG = '0'");
                    //sbQuery.Append(" UNION ALL");
                    //sbQuery.Append(" SELECT * FROM TMAT_PARTLIST");
                    //sbQuery.Append(" WHERE ISNULL(MATERIAL,'0') NOT LIKE '%STEEL%'");
                    //sbQuery.Append(" AND DATA_FLAG = '0'");
                    //sbQuery.Append(" UNION ALL");
                    //sbQuery.Append(" SELECT * FROM TMAT_PARTLIST");
                    //sbQuery.Append(" WHERE ISNULL(MATERIAL,'0') NOT LIKE '%SUS%'");
                    //sbQuery.Append(" AND DATA_FLAG = '0'");
                    //sbQuery.Append(" )A");
                    //sbQuery.Append(" WHERE PROD_CODE NOT IN");
                    //sbQuery.Append(" (");
                    //sbQuery.Append(" SELECT DISTINCT PROD_CODE FROM");
                    //sbQuery.Append(" (");
                    //sbQuery.Append(" SELECT * FROM TMAT_PARTLIST");
                    //sbQuery.Append(" WHERE MATERIAL LIKE '%AL%'");
                    //sbQuery.Append(" AND DATA_FLAG = '0'");
                    //sbQuery.Append(" UNION ALL");
                    //sbQuery.Append(" SELECT * FROM TMAT_PARTLIST");
                    //sbQuery.Append(" WHERE MATERIAL LIKE '%BE-CU%'");
                    //sbQuery.Append(" AND DATA_FLAG = '0'");
                    //sbQuery.Append(" UNION ALL");
                    //sbQuery.Append(" SELECT * FROM TMAT_PARTLIST");
                    //sbQuery.Append(" WHERE MATERIAL LIKE '%BRASS%'");
                    //sbQuery.Append(" AND DATA_FLAG = '0'");
                    //sbQuery.Append(" ) A");
                    //sbQuery.Append(" )");
                    //sbQuery.Append(" )W");
                    //sbQuery.Append(" ON P.PLT_CODE = W.PLT_CODE");
                    //sbQuery.Append(" AND P.PROD_CODE = W.PROD_CODE");
                    //sbQuery.Append(" LEFT JOIN TSTD_CODES C");
                    //sbQuery.Append(" ON P.PLT_CODE = C.PLT_CODE");
                    //sbQuery.Append(" AND P.PROD_TYPE = C.CD_CODE");
                    //sbQuery.Append(" AND C.CAT_CODE = 'P010'");
                    //sbQuery.Append(" JOIN (SELECT PLT_CODE, PROD_CODE, PART_CODE, CONVERT(VARCHAR(8), ACT_END_TIME, 112) ACT_END_DATE");
                    //sbQuery.Append(" , PART_QTY FROM TSHP_WORKORDER");
                    //sbQuery.Append(" WHERE PLT_CODE = '100' AND CONVERT(VARCHAR(8), ACT_END_TIME, 112) BETWEEN @S_DATE AND @E_DATE");
                    //sbQuery.Append(" AND WO_FLAG = '4' AND PROC_CODE = @PROC_CODE AND DATA_FLAG = '0') WO");
                    //sbQuery.Append(" ON WO.PLT_CODE = P.PLT_CODE");
                    //sbQuery.Append(" AND WO.PROD_CODE = P.PROD_CODE");
                    //sbQuery.Append(" ORDER BY ACT_END_DATE");

                    sbQuery.Append(" SELECT");
                    sbQuery.Append(" A.PLT_CODE");
                    sbQuery.Append(" ,A.PROD_CODE");
                    sbQuery.Append(" ,ISNULL(D.CD_PARENT, '1') AS CD_PARENT");
                    sbQuery.Append(" ,CONVERT(VARCHAR(8), ACT_END_TIME, 112) AS ACT_END_DATE");
                    sbQuery.Append(" ,C.PROD_QTY");
                    sbQuery.Append(" ,A.PART_QTY");
                    sbQuery.Append(" ,B.MATERIAL");
                    sbQuery.Append(" FROM TSHP_WORKORDER A");
                    sbQuery.Append(" LEFT JOIN TMAT_PARTLIST B");
                    sbQuery.Append(" ON A.PLT_CODE = B.PLT_CODE");
                    sbQuery.Append(" AND A.PT_ID = B.PT_ID");
                    sbQuery.Append(" LEFT JOIN TORD_PRODUCT C");
                    sbQuery.Append(" ON A.PLT_CODE = C.PLT_CODE");
                    sbQuery.Append(" AND A.PROD_CODE = C.PROD_CODE");
                    sbQuery.Append(" LEFT JOIN TSTD_CODES D");
                    sbQuery.Append(" ON C.PLT_CODE = D.PLT_CODE");
                    sbQuery.Append(" AND C.PROD_TYPE = D.CD_CODE");
                    sbQuery.Append(" AND D.CAT_CODE = 'P010'");
                    sbQuery.Append(" WHERE A.PLT_CODE = '100' AND CONVERT(VARCHAR(8), A.ACT_END_TIME, 112) BETWEEN @S_DATE AND @E_DATE");
                    sbQuery.Append(" AND A.WO_FLAG = '4' AND A.PROC_CODE = @PROC_CODE AND A.DATA_FLAG = '0'");
                    sbQuery.Append(" AND (ISNULL(B.MATERIAL,'11') NOT LIKE '%AL%' AND ISNULL(B.MATERIAL,'11') NOT LIKE '%BE-CU%' AND ISNULL(B.MATERIAL,'11') NOT LIKE '%BRASS%')");
                    sbQuery.Append(" ORDER BY CONVERT(VARCHAR(8), ACT_END_TIME, 112)");


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

        public static DataTable TORD_PRODUCT_QUERY25(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED");
                    //sbQuery.Append(" SELECT");
                    //sbQuery.Append(" P.PLT_CODE");
                    //sbQuery.Append(" ,P.PROD_CODE");
                    //sbQuery.Append(" ,ISNULL(C.CD_PARENT, '1') AS CD_PARENT");
                    //sbQuery.Append(" ,ACT_END_DATE");
                    //sbQuery.Append(" ,P.PROD_QTY");
                    //sbQuery.Append(" ,WO.PART_QTY");
                    //sbQuery.Append(" ,ISNULL(P.CHG_DUE_DATE, P.DUE_DATE) AS DUE_DATE");
                    //sbQuery.Append(" FROM TORD_PRODUCT P");

                    //sbQuery.Append(" JOIN");
                    //sbQuery.Append(" (");
                    //sbQuery.Append(" SELECT DISTINCT PLT_CODE, PROD_CODE FROM");
                    //sbQuery.Append(" (");
                    //sbQuery.Append(" SELECT * FROM TMAT_PARTLIST");
                    //sbQuery.Append(" WHERE MATERIAL LIKE '%AL%'");
                    //sbQuery.Append(" AND DATA_FLAG = '0'");
                    //sbQuery.Append(" UNION ALL");
                    //sbQuery.Append(" SELECT * FROM TMAT_PARTLIST");
                    //sbQuery.Append(" WHERE MATERIAL LIKE '%BE-CU%'");
                    //sbQuery.Append(" AND DATA_FLAG = '0'");
                    //sbQuery.Append(" UNION ALL");
                    //sbQuery.Append(" SELECT * FROM TMAT_PARTLIST");
                    //sbQuery.Append(" WHERE MATERIAL LIKE '%BRASS%'");
                    //sbQuery.Append(" AND DATA_FLAG = '0'");
                    //sbQuery.Append(" ) A");
                    //sbQuery.Append(" ) W");
                    //sbQuery.Append(" ON P.PLT_CODE = W.PLT_CODE");
                    //sbQuery.Append(" AND P.PROD_CODE = W.PROD_CODE");

                    //sbQuery.Append(" LEFT JOIN TSTD_CODES C");
                    //sbQuery.Append(" ON P.PLT_CODE = C.PLT_CODE");
                    //sbQuery.Append(" AND P.PROD_TYPE = C.CD_CODE");
                    //sbQuery.Append(" AND C.CAT_CODE = 'P010'");

                    //sbQuery.Append(" JOIN (SELECT PLT_CODE, PROD_CODE, PART_CODE, CONVERT(VARCHAR(8), ACT_END_TIME, 112) ACT_END_DATE");
                    //sbQuery.Append(" , PART_QTY FROM TSHP_WORKORDER");
                    //sbQuery.Append(" WHERE PLT_CODE = '100' AND PROC_CODE = 'P-04' AND DATA_FLAG = '0') WO");
                    //sbQuery.Append(" ON WO.PLT_CODE = P.PLT_CODE");
                    //sbQuery.Append(" AND WO.PROD_CODE = P.PROD_CODE");

                    //sbQuery.Append(" WHERE ISNULL(P.CHG_DUE_DATE, P.DUE_DATE) < ISNULL(WO.ACT_END_DATE, P.DUE_DATE + 1)");
                    //sbQuery.Append(" AND ISNULL(P.CHG_DUE_DATE, P.DUE_DATE) BETWEEN @S_DATE AND @E_DATE");
                    //sbQuery.Append(" AND P.DATA_FLAG = '0'");
                    //sbQuery.Append(" ORDER BY DUE_DATE");


                    sbQuery.Append(" SELECT");
                    sbQuery.Append(" A.PLT_CODE");
                    sbQuery.Append(" ,A.PROD_CODE");
                    sbQuery.Append(" ,ISNULL(D.CD_PARENT, '1') AS CD_PARENT");
                    sbQuery.Append(" ,CONVERT(VARCHAR(8), B.ACT_END_TIME, 112) AS ACT_END_DATE");
                    sbQuery.Append(" ,ISNULL(A.CHG_DUE_DATE, A.DUE_DATE) AS DUE_DATE");
                    sbQuery.Append(" ,A.PROD_QTY");
                    sbQuery.Append(" ,B.PART_QTY");
                    sbQuery.Append(" ,C.MATERIAL");
                    sbQuery.Append(" FROM TORD_PRODUCT A");
                    sbQuery.Append(" LEFT JOIN TSHP_WORKORDER B");
                    sbQuery.Append(" ON A.PLT_CODE = B.PLT_CODE");
                    sbQuery.Append(" AND A.PROD_CODE = B.PROD_CODE");
                    sbQuery.Append(" LEFT JOIN TMAT_PARTLIST C");
                    sbQuery.Append(" ON B.PLT_CODE = C.PLT_CODE");
                    sbQuery.Append(" AND B.PT_ID = C.PT_ID");
                    sbQuery.Append(" LEFT JOIN TSTD_CODES D");
                    sbQuery.Append(" ON A.PLT_CODE = D.PLT_CODE");
                    sbQuery.Append(" AND A.PROD_TYPE = D.CD_CODE");
                    sbQuery.Append(" AND D.CAT_CODE = 'P010'");
                    sbQuery.Append(" WHERE A.PLT_CODE = '100'");
                    sbQuery.Append(" AND ISNULL(A.CHG_DUE_DATE, A.DUE_DATE) < ISNULL(CONVERT(VARCHAR(8), B.ACT_END_TIME, 112), ISNULL(A.CHG_DUE_DATE, A.DUE_DATE) + 1)");
                    sbQuery.Append(" AND ISNULL(A.CHG_DUE_DATE, A.DUE_DATE) BETWEEN @S_DATE AND @E_DATE");
                    sbQuery.Append(" AND A.DATA_FLAG = '0'");
                    sbQuery.Append(" AND B.PROC_CODE = 'P-04' AND B.DATA_FLAG = '0'");
                    sbQuery.Append(" AND (C.MATERIAL LIKE '%AL%' OR C.MATERIAL LIKE '%BE-CU%' OR C.MATERIAL LIKE '%BRASS%')");
                    sbQuery.Append(" AND A.PROD_STATE IN ('1','7','11','12')");
                    sbQuery.Append(" ORDER BY ISNULL(A.CHG_DUE_DATE, A.DUE_DATE)");



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

        public static DataTable TORD_PRODUCT_QUERY26(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED");
                    //sbQuery.Append(" SELECT");
                    //sbQuery.Append(" P.PLT_CODE");
                    //sbQuery.Append(" ,P.PROD_CODE");
                    //sbQuery.Append(" ,ISNULL(C.CD_PARENT, '1') AS CD_PARENT");
                    //sbQuery.Append(" ,ACT_END_DATE");
                    //sbQuery.Append(" ,P.PROD_QTY");
                    //sbQuery.Append(" ,WO.PART_QTY");
                    //sbQuery.Append(" ,ISNULL(P.CHG_DUE_DATE, P.DUE_DATE) AS DUE_DATE");
                    //sbQuery.Append(" FROM TORD_PRODUCT P");
                    //sbQuery.Append(" JOIN");
                    //sbQuery.Append(" (");
                    //sbQuery.Append(" SELECT DISTINCT PLT_CODE, PROD_CODE FROM");
                    //sbQuery.Append(" (");
                    //sbQuery.Append(" SELECT * FROM TMAT_PARTLIST");
                    //sbQuery.Append(" WHERE MATERIAL NOT LIKE '%AL%'");
                    //sbQuery.Append(" AND DATA_FLAG = '0'");
                    //sbQuery.Append(" UNION ALL");
                    //sbQuery.Append(" SELECT * FROM TMAT_PARTLIST");
                    //sbQuery.Append(" WHERE MATERIAL NOT LIKE '%BE-CU%'");
                    //sbQuery.Append(" AND DATA_FLAG = '0'");
                    //sbQuery.Append(" UNION ALL");
                    //sbQuery.Append(" SELECT * FROM TMAT_PARTLIST");
                    //sbQuery.Append(" WHERE MATERIAL NOT LIKE '%BRASS%'");
                    //sbQuery.Append(" AND DATA_FLAG = '0'");
                    //sbQuery.Append(" UNION ALL");
                    //sbQuery.Append(" SELECT * FROM TMAT_PARTLIST");
                    //sbQuery.Append(" WHERE MATERIAL NOT LIKE '%SKD11%'");
                    //sbQuery.Append(" AND DATA_FLAG = '0'");
                    //sbQuery.Append(" UNION ALL");
                    //sbQuery.Append(" SELECT * FROM TMAT_PARTLIST");
                    //sbQuery.Append(" WHERE MATERIAL NOT LIKE '%STEEL%'");
                    //sbQuery.Append(" AND DATA_FLAG = '0'");
                    //sbQuery.Append(" UNION ALL");
                    //sbQuery.Append(" SELECT * FROM TMAT_PARTLIST");
                    //sbQuery.Append(" WHERE MATERIAL NOT LIKE '%SUS%'");
                    //sbQuery.Append(" AND DATA_FLAG = '0'");
                    //sbQuery.Append(" )A");
                    //sbQuery.Append(" WHERE PROD_CODE NOT IN");
                    //sbQuery.Append(" (");
                    //sbQuery.Append(" SELECT DISTINCT PROD_CODE FROM");
                    //sbQuery.Append(" (");
                    //sbQuery.Append(" SELECT * FROM TMAT_PARTLIST");
                    //sbQuery.Append(" WHERE MATERIAL LIKE '%AL%'");
                    //sbQuery.Append(" AND DATA_FLAG = '0'");
                    //sbQuery.Append(" UNION ALL");
                    //sbQuery.Append(" SELECT * FROM TMAT_PARTLIST");
                    //sbQuery.Append(" WHERE MATERIAL LIKE '%BE-CU%'");
                    //sbQuery.Append(" AND DATA_FLAG = '0'");
                    //sbQuery.Append(" UNION ALL");
                    //sbQuery.Append(" SELECT * FROM TMAT_PARTLIST");
                    //sbQuery.Append(" WHERE MATERIAL LIKE '%BRASS%'");
                    //sbQuery.Append(" AND DATA_FLAG = '0'");
                    //sbQuery.Append(" ) A");
                    //sbQuery.Append(" )");
                    //sbQuery.Append(" )W");
                    //sbQuery.Append(" ON P.PLT_CODE = W.PLT_CODE");
                    //sbQuery.Append(" AND P.PROD_CODE = W.PROD_CODE");
                    //sbQuery.Append(" LEFT JOIN TSTD_CODES C");
                    //sbQuery.Append(" ON P.PLT_CODE = C.PLT_CODE");
                    //sbQuery.Append(" AND P.PROD_TYPE = C.CD_CODE");
                    //sbQuery.Append(" AND C.CAT_CODE = 'P010'");
                    //sbQuery.Append(" JOIN (SELECT PLT_CODE, PROD_CODE, PART_CODE, CONVERT(VARCHAR(8), ACT_END_TIME, 112) ACT_END_DATE");
                    //sbQuery.Append(" , PART_QTY FROM TSHP_WORKORDER");
                    //sbQuery.Append(" WHERE PLT_CODE = '100' AND PROC_CODE = 'P-04' AND DATA_FLAG = '0') WO");
                    //sbQuery.Append(" ON WO.PLT_CODE = P.PLT_CODE");
                    //sbQuery.Append(" AND WO.PROD_CODE = P.PROD_CODE");
                    //sbQuery.Append(" WHERE ISNULL(P.CHG_DUE_DATE, P.DUE_DATE) < ISNULL(WO.ACT_END_DATE, P.DUE_DATE + 1)");
                    //sbQuery.Append(" AND ISNULL(P.CHG_DUE_DATE, P.DUE_DATE) BETWEEN @S_DATE AND @E_DATE");
                    //sbQuery.Append(" AND P.DATA_FLAG = '0'");
                    //sbQuery.Append(" ORDER BY DUE_DATE");

                    sbQuery.Append(" SELECT");
                    sbQuery.Append(" A.PLT_CODE");
                    sbQuery.Append(" ,A.PROD_CODE");
                    sbQuery.Append(" ,ISNULL(D.CD_PARENT, '1') AS CD_PARENT");
                    sbQuery.Append(" ,CONVERT(VARCHAR(8), B.ACT_END_TIME, 112) AS ACT_END_DATE");
                    sbQuery.Append(" ,ISNULL(A.CHG_DUE_DATE, A.DUE_DATE) AS DUE_DATE");
                    sbQuery.Append(" ,A.PROD_QTY");
                    sbQuery.Append(" ,B.PART_QTY");
                    sbQuery.Append(" ,C.MATERIAL");
                    sbQuery.Append(" FROM TORD_PRODUCT A");
                    sbQuery.Append(" LEFT JOIN TSHP_WORKORDER B");
                    sbQuery.Append(" ON A.PLT_CODE = B.PLT_CODE");
                    sbQuery.Append(" AND A.PROD_CODE = B.PROD_CODE");
                    sbQuery.Append(" LEFT JOIN TMAT_PARTLIST C");
                    sbQuery.Append(" ON B.PLT_CODE = C.PLT_CODE");
                    sbQuery.Append(" AND B.PT_ID = C.PT_ID");
                    sbQuery.Append(" LEFT JOIN TSTD_CODES D");
                    sbQuery.Append(" ON A.PLT_CODE = D.PLT_CODE");
                    sbQuery.Append(" AND A.PROD_TYPE = D.CD_CODE");
                    sbQuery.Append(" AND D.CAT_CODE = 'P010'");
                    sbQuery.Append(" WHERE A.PLT_CODE = '100'");
                    sbQuery.Append(" AND ISNULL(A.CHG_DUE_DATE, A.DUE_DATE) < ISNULL(CONVERT(VARCHAR(8), B.ACT_END_TIME, 112), ISNULL(A.CHG_DUE_DATE, A.DUE_DATE) + 1)");
                    sbQuery.Append(" AND ISNULL(A.CHG_DUE_DATE, A.DUE_DATE) BETWEEN @S_DATE AND @E_DATE");
                    sbQuery.Append(" AND A.DATA_FLAG = '0'");
                    sbQuery.Append(" AND B.PROC_CODE = 'P-04' AND B.DATA_FLAG = '0'");
                    sbQuery.Append(" AND (ISNULL(C.MATERIAL,'11') NOT LIKE '%AL%' AND ISNULL(C.MATERIAL,'11') NOT LIKE '%BE-CU%' AND ISNULL(C.MATERIAL,'11') NOT LIKE '%BRASS%')");
                    sbQuery.Append(" AND A.PROD_STATE IN ('1','7','11','12')");
                    sbQuery.Append(" ORDER BY ISNULL(A.CHG_DUE_DATE, A.DUE_DATE)");


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

        public static DataTable TORD_PRODUCT_QUERY27(DataTable dtParam, BizExecute.BizExecute bizExecute)
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
                    sbQuery.Append(" ,W.PART_QTY");
                    sbQuery.Append(" ,P.PROD_QTY");
                    sbQuery.Append(" ,P.PROD_TYPE");
                    sbQuery.Append(" ,C.CD_NAME");
                    sbQuery.Append(" ,ISNULL(P.CHG_DUE_DATE, P.DUE_DATE) AS DUE_DATE");
                    sbQuery.Append(" ,CONVERT(VARCHAR(8), ACT_END_TIME, 112) ACT_END_DATE");
                    sbQuery.Append(" FROM TSHP_WORKORDER W");
                    sbQuery.Append(" LEFT JOIN TORD_PRODUCT P");
                    sbQuery.Append(" ON W.PLT_CODE = P.PLT_CODE");
                    sbQuery.Append(" AND W.PROD_CODE = P.PROD_CODE");
                    sbQuery.Append(" LEFT JOIN TSTD_CODES C");
                    sbQuery.Append(" ON P.PLT_CODE = C.PLT_CODE");
                    sbQuery.Append(" AND P.PROD_TYPE = C.CD_CODE");
                    sbQuery.Append(" AND C.CAT_CODE = 'P010'");
                    sbQuery.Append(" WHERE W.PROC_CODE = 'P-09'");
                    sbQuery.Append(" AND W.DATA_FLAG = '0'");
                    sbQuery.Append(" AND ISNULL(P.CHG_DUE_DATE, P.DUE_DATE) < ISNULL(CONVERT(VARCHAR(8), ACT_END_TIME, 112), ISNULL(P.CHG_DUE_DATE, P.DUE_DATE) + 1)");
                    sbQuery.Append(" AND ISNULL(P.CHG_DUE_DATE, P.DUE_DATE) BETWEEN @S_DATE AND @E_DATE");
                    sbQuery.Append(" AND P.PROD_STATE IN ('1','7','11','12')");
                    sbQuery.Append(" GROUP BY W.PLT_CODE");
                    sbQuery.Append(" ,W.PROD_CODE");
                    sbQuery.Append(" ,W.PART_QTY");
                    sbQuery.Append(" ,P.PROD_QTY");
                    sbQuery.Append(" ,P.PROD_TYPE");
                    sbQuery.Append(" ,C.CD_NAME");
                    sbQuery.Append(" ,ISNULL(P.CHG_DUE_DATE, P.DUE_DATE)");
                    sbQuery.Append(" ,CONVERT(VARCHAR(8), ACT_END_TIME, 112)");
                    sbQuery.Append(" ORDER BY P.PROD_TYPE, ISNULL(P.CHG_DUE_DATE, P.DUE_DATE)");

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

        public static DataTable TORD_PRODUCT_QUERY28(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED");
                    sbQuery.Append(" SELECT");
                    sbQuery.Append(" COUNT(P.PROD_CODE) AS PROD_CNT");
                    sbQuery.Append(" FROM TORD_PRODUCT P");
                    sbQuery.Append(" WHERE P.PROD_STATE NOT IN ('3','4','5')");
                    sbQuery.Append(" AND P.DATA_FLAG = '0'");
                    sbQuery.Append(" AND LEFT(CONVERT(VARCHAR(8), P.REG_DATE, 112), 6) = @S_MONTH");

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

        public static DataTable TORD_PRODUCT_QUERY29(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED");
                    sbQuery.Append(" SELECT");
                    sbQuery.Append(" PLT_CODE, PROD_CODE, PROD_QTY");
                    sbQuery.Append(" FROM TORD_PRODUCT P");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE 1=1 ");

                        sbWhere.Append(UTIL.GetWhere(row, "@S_ORD_DATE, @E_ORD_DATE", " (P.ORD_DATE BETWEEN @S_ORD_DATE AND @E_ORD_DATE)"));

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

        public static DataTable TORD_PRODUCT_QUERY30(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT");
                    sbQuery.Append(" PROD_CODE");
                    sbQuery.Append(" ,PROD_NAME");
                    sbQuery.Append(" ,PROD_FLAG");
                    sbQuery.Append(" ,PROD_TYPE");
                    sbQuery.Append(" ,CUSTDESIGN_EMP");
                    sbQuery.Append(" ,E.EMP_NAME AS BUSINESS_EMP");
                    sbQuery.Append(" ,V.VEN_NAME AS CVND_NAME");
                    sbQuery.Append(" ,PROD_QTY");
                    sbQuery.Append(" FROM TORD_PRODUCT A");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE E");
                    sbQuery.Append(" ON A.PLT_CODE = E.PLT_CODE");
                    sbQuery.Append(" AND A.BUSINESS_EMP = E.EMP_CODE");
                    sbQuery.Append(" LEFT JOIN TSTD_VENDOR V");
                    sbQuery.Append(" ON A.PLT_CODE = V.PLT_CODE");
                    sbQuery.Append(" AND A.CVND_CODE = V.VEN_CODE");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE 1=1 ");

                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_CODE", " A.PROD_CODE = @PROD_CODE"));

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
