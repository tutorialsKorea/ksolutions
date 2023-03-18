using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BizExecute;
using System.Data;

namespace DORD
{
    public class TORD_ITEM
    {
        public static DataTable TORD_ITEM_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("  SELECT  ");
                    sbQuery.Append("  PLT_CODE ");
                    sbQuery.Append(" ,ITEM_CODE ");
                    sbQuery.Append(" ,ITEM_NAME ");
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
                    sbQuery.Append(" ,MDFY_DATE ");
                    sbQuery.Append(" ,MDFY_EMP ");
                    sbQuery.Append(" ,DEL_DATE ");
                    sbQuery.Append(" ,DEL_EMP ");
                    sbQuery.Append(" ,DATA_FLAG ");
                    sbQuery.Append(" ,TRADE_DATE ");
                    sbQuery.Append(" ,TAX_DATE ");
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
                    sbQuery.Append(" ,MSOP_DFM ");
                    sbQuery.Append(" ,MSOP_DFM_DATE ");
                    sbQuery.Append(" ,DRAW_DATE ");
                    sbQuery.Append(" ,DRAW_TYPE ");
                    sbQuery.Append("  FROM TORD_ITEM  ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("  AND ITEM_CODE = @ITEM_CODE  ");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "ITEM_CODE")) isHasColumn = false;

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


        public static void TORD_ITEM_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" INSERT INTO TORD_ITEM (  ");
                    sbQuery.Append("  PLT_CODE ");
                    sbQuery.Append(" ,ITEM_CODE ");
                    sbQuery.Append(" ,ITEM_NAME ");
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
                    sbQuery.Append(" ,MSOP_DFM ");
                    sbQuery.Append(" ,MSOP_DFM_DATE ");
                    sbQuery.Append(" ,DRAW_DATE ");
                    sbQuery.Append(" ,DRAW_TYPE ");
                    sbQuery.Append("  ) VALUES (  ");
                    sbQuery.Append("  @PLT_CODE ");
                    sbQuery.Append(" ,@ITEM_CODE ");
                    sbQuery.Append(" ,@ITEM_NAME ");
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
                    sbQuery.Append(" ,@VISION_CLAMP ");
                    sbQuery.Append(" ,@VISION_CONNECTOR ");
                    sbQuery.Append(" ,@VISION_OPEN ");
                    sbQuery.Append(" ,@CLAMP_DIRECTION ");
                    sbQuery.Append(" ,@CONNECTOR_DIRECTION ");
                    sbQuery.Append(" ,@OPEN_DIRECTION ");
                    sbQuery.Append(" ,@GND_PIN ");
                    sbQuery.Append(" ,@FIDUCIAL_MARK ");
                    sbQuery.Append(" ,@CROSS_MARKING ");
                    sbQuery.Append(" ,@VACUUM ");
                    sbQuery.Append(" ,@SOCKET_MARKING ");
                    sbQuery.Append(" ,@MODULE_IN_TYPE ");
                    sbQuery.Append(" ,@IF_PIN_BLOCK ");
                    sbQuery.Append(" ,@SOCKET_OPEN_DIRECTION ");
                    sbQuery.Append(" ,@MSOP_DFM ");
                    sbQuery.Append(" ,@MSOP_DFM_DATE ");
                    sbQuery.Append(" ,@DRAW_DATE ");
                    sbQuery.Append(" ,@DRAW_TYPE ");
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

        public static void TORD_ITEM_UPD(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TORD_ITEM SET  ");
                    sbQuery.Append(" ITEM_NAME = @ITEM_NAME ");
                    sbQuery.Append(" ,PROD_VERSION = @PROD_VERSION ");
                    sbQuery.Append(" ,PROC_TYPE = @PROC_TYPE ");
                    sbQuery.Append(" ,PROC_FLAG = @PROC_FLAG ");
                    sbQuery.Append(" ,PROD_FLAG = @PROD_FLAG ");
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
                    sbQuery.Append(" ,DELIVERY_DATE = @DELIVERY_DATE ");
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
                    sbQuery.Append(" ,REMARK = @REMARK ");
                    sbQuery.Append(" ,MODULE_TYPE = @MODULE_TYPE ");
                    sbQuery.Append(" ,PIN_TYPE = @PIN_TYPE ");
                    sbQuery.Append(" ,VISION_CLAMP = @VISION_CLAMP ");
                    sbQuery.Append(" ,VISION_CONNECTOR = @VISION_CONNECTOR ");
                    sbQuery.Append(" ,VISION_OPEN = @VISION_OPEN ");
                    sbQuery.Append(" ,CLAMP_DIRECTION = @CLAMP_DIRECTION ");
                    sbQuery.Append(" ,CONNECTOR_DIRECTION = @CONNECTOR_DIRECTION ");
                    sbQuery.Append(" ,OPEN_DIRECTION = @OPEN_DIRECTION ");
                    sbQuery.Append(" ,GND_PIN = @GND_PIN ");
                    sbQuery.Append(" ,FIDUCIAL_MARK = @FIDUCIAL_MARK ");
                    sbQuery.Append(" ,CROSS_MARKING = @CROSS_MARKING ");
                    sbQuery.Append(" ,VACUUM = @VACUUM ");
                    sbQuery.Append(" ,SOCKET_MARKING = @SOCKET_MARKING ");
                    sbQuery.Append(" ,MODULE_IN_TYPE = @MODULE_IN_TYPE ");
                    sbQuery.Append(" ,IF_PIN_BLOCK = @IF_PIN_BLOCK ");
                    sbQuery.Append(" ,SOCKET_OPEN_DIRECTION = @SOCKET_OPEN_DIRECTION ");
                    sbQuery.Append(" ,MSOP_DFM = @MSOP_DFM ");
                    sbQuery.Append(" ,MSOP_DFM_DATE = @MSOP_DFM_DATE ");
                    sbQuery.Append(" ,DRAW_DATE = @DRAW_DATE ");
                    sbQuery.Append(" ,DRAW_TYPE = @DRAW_TYPE ");
                    sbQuery.Append(" ,MDFY_DATE = GETDATE() ");
                    sbQuery.Append(" ,MDFY_EMP = '" + ConnInfo.UserID + "'");
                    //sbQuery.Append(" ,DATA_FLAG = @DATA_FLAG ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append("  AND ITEM_CODE = @ITEM_CODE ");
                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;


                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "ITEM_CODE")) isHasColumn = false;

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
        public static void TORD_ITEM_UPD2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TORD_ITEM SET  ");
                    sbQuery.Append(" PROD_STATE = @PROD_STATE ");
                    sbQuery.Append(" ,MDFY_DATE = GETDATE() ");
                    sbQuery.Append(" ,MDFY_EMP = '" + ConnInfo.UserID + "'");
                    //sbQuery.Append(" ,DATA_FLAG = @DATA_FLAG ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append("  AND ITEM_CODE = @ITEM_CODE ");
                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;


                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "ITEM_CODE")) isHasColumn = false;

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
        public static void TORD_ITEM_UPD3(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TORD_ITEM SET  ");
                    sbQuery.Append(" SHIP_FLAG = @SHIP_FLAG ");
                    sbQuery.Append(" ,MDFY_DATE = GETDATE() ");
                    sbQuery.Append(" ,MDFY_EMP = '" + ConnInfo.UserID + "'");
                    //sbQuery.Append(" ,DATA_FLAG = @DATA_FLAG ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append("  AND ITEM_CODE = @ITEM_CODE ");
                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;


                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "ITEM_CODE")) isHasColumn = false;

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
        public static void TORD_ITEM_UPD4(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TORD_ITEM SET  ");
                    sbQuery.Append(" LOCK_FLAG = @LOCK_FLAG ");
                    sbQuery.Append(" ,LOCK_EMP = @LOCK_EMP ");
                    sbQuery.Append(" ,MDFY_DATE = GETDATE() ");
                    sbQuery.Append(" ,MDFY_EMP = '" + ConnInfo.UserID + "'");
                    //sbQuery.Append(" ,DATA_FLAG = @DATA_FLAG ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append("  AND ITEM_CODE = @ITEM_CODE ");
                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;


                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "ITEM_CODE")) isHasColumn = false;

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
        public static void TORD_ITEM_UPD5(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TORD_ITEM SET  ");
                    sbQuery.Append(" LOCK_FLAG = @LOCK_FLAG ");
                    sbQuery.Append(" ,LOCK_EMP = null ");
                    sbQuery.Append(" ,MDFY_DATE = GETDATE() ");
                    sbQuery.Append(" ,MDFY_EMP = '" + ConnInfo.UserID + "'");
                    //sbQuery.Append(" ,DATA_FLAG = @DATA_FLAG ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append("  AND ITEM_CODE = @ITEM_CODE ");
                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;


                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "ITEM_CODE")) isHasColumn = false;

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
        public static void TORD_ITEM_UPD6(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TORD_ITEM SET  ");
                    sbQuery.Append(" TRADE_DATE = @TRADE_DATE ");
                    sbQuery.Append(" ,TAX_DATE = @TAX_DATE ");
                    sbQuery.Append(" ,MDFY_DATE = GETDATE() ");
                    sbQuery.Append(" ,MDFY_EMP = '" + ConnInfo.UserID + "'");
                    //sbQuery.Append(" ,DATA_FLAG = @DATA_FLAG ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append("  AND ITEM_CODE = @ITEM_CODE ");
                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;


                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "ITEM_CODE")) isHasColumn = false;

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
        public static void TORD_ITEM_UDE(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TORD_ITEM SET  ");
                    sbQuery.Append(" DEL_DATE = GETDATE() ");
                    sbQuery.Append(" ,DEL_EMP = '" + ConnInfo.UserID + "'");
                    sbQuery.Append(" ,DATA_FLAG = 2 ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append("  AND ITEM_CODE = @ITEM_CODE ");
                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;


                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "ITEM_CODE")) isHasColumn = false;

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

    public class TORD_ITEM_QUERY
    {
        public static DataTable TORD_ITEM_QUERY1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {


                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT P.PLT_CODE");
                    sbQuery.Append(" ,I.ITEM_CODE");
                    sbQuery.Append(" ,I.ITEM_NAME");
                    sbQuery.Append(" ,I.PROD_VERSION");
                    sbQuery.Append(" ,I.PROC_TYPE");
                    sbQuery.Append(" ,I.PROC_FLAG");
                    sbQuery.Append(" ,I.PROD_FLAG");
                    sbQuery.Append(" ,I.INS_YN");
                    sbQuery.Append(" ,I.SOCKET_YN");
                    sbQuery.Append(" ,I.PROD_TYPE");
                    sbQuery.Append(" ,I.PROD_CATEGORY");
                    sbQuery.Append(" ,I.BUSINESS_EMP");
                    sbQuery.Append(" ,I.CUSTOMER_EMP");
                    sbQuery.Append(" ,I.CUSTDESIGN_EMP");
                    sbQuery.Append(" ,I.ACTUATOR_YN");
                    sbQuery.Append(" ,I.CVND_CODE");
                    sbQuery.Append(" ,CVND.VEN_NAME AS CVND_NAME");
                    sbQuery.Append(" ,I.TVND_CODE");
                    sbQuery.Append(" ,TVND.BVEN_NAME AS TVND_NAME");
                    sbQuery.Append(" ,I.PROBE_PIN");
                    sbQuery.Append(" ,I.CURR_UNIT");
                    sbQuery.Append(" ,I.ORD_DATE");
                    sbQuery.Append(" ,I.INDUE_DATE");
                    sbQuery.Append(" ,I.DUE_DATE");
                    sbQuery.Append(" ,I.CHG_DUE_DATE");
                    sbQuery.Append(" ,I.END_DATE");
                    sbQuery.Append(" ,I.DELIVERY_DATE");
                    sbQuery.Append(" ,I.PROD_QTY");
                    sbQuery.Append(" ,I.LOAD_FLAG");
                    sbQuery.Append(" ,I.LOCK_FLAG");
                    sbQuery.Append(" ,I.LOCK_EMP");
                    sbQuery.Append(" ,I.SHIP_FLAG");
                    sbQuery.Append(" ,I.PROD_STATE");
                    sbQuery.Append(" ,I.INOUT_FLAG");
                    sbQuery.Append(" ,I.ORD_VAT");
                    sbQuery.Append(" ,I.PROD_UC");
                    sbQuery.Append(" ,I.PROD_COST");
                    sbQuery.Append(" ,I.PROD_VAT");
                    sbQuery.Append(" ,I.PROD_AMT");
                    sbQuery.Append(" ,I.PROD_KIND");
                    sbQuery.Append(" ,I.PROD_TYPE1");
                    sbQuery.Append(" ,I.PROD_TYPE2");
                    sbQuery.Append(" ,I.INS_FLAG");
                    sbQuery.Append(" ,I.TRADE_YN");
                    sbQuery.Append(" ,I.TAX_YN");
                    sbQuery.Append(" ,I.BILL_YN");
                    sbQuery.Append(" ,I.SCOMMENT");
                    sbQuery.Append(" ,I.REMARK");
                    sbQuery.Append(" ,I.MODULE_TYPE ");
                    sbQuery.Append(" ,I.PIN_TYPE ");
                    sbQuery.Append(" ,I.VISION_CLAMP ");
                    sbQuery.Append(" ,I.VISION_CONNECTOR ");
                    sbQuery.Append(" ,I.VISION_OPEN ");
                    sbQuery.Append(" ,I.CLAMP_DIRECTION ");
                    sbQuery.Append(" ,I.CONNECTOR_DIRECTION ");
                    sbQuery.Append(" ,I.OPEN_DIRECTION ");
                    sbQuery.Append(" ,I.GND_PIN ");
                    sbQuery.Append(" ,I.FIDUCIAL_MARK ");
                    sbQuery.Append(" ,I.CROSS_MARKING ");
                    sbQuery.Append(" ,I.VACUUM ");
                    sbQuery.Append(" ,I.SOCKET_MARKING ");
                    sbQuery.Append(" ,I.MODULE_IN_TYPE ");
                    sbQuery.Append(" ,I.IF_PIN_BLOCK ");
                    sbQuery.Append(" ,I.SOCKET_OPEN_DIRECTION ");
                    sbQuery.Append(" ,I.MSOP_DFM ");
                    sbQuery.Append(" ,I.MSOP_DFM_DATE ");
                    sbQuery.Append(" ,I.DRAW_DATE ");
                    sbQuery.Append(" ,I.DRAW_TYPE ");
                    sbQuery.Append(" ,I.REG_DATE");
                    sbQuery.Append(" ,I.REG_EMP");
                    sbQuery.Append(" ,REG.EMP_NAME AS REG_EMP_NAME");
                    sbQuery.Append(" ,I.MDFY_DATE");
                    sbQuery.Append(" ,I.MDFY_EMP");
                    sbQuery.Append(" ,MDFY.EMP_NAME AS MDFY_EMP_NAME");
                    sbQuery.Append(" FROM TORD_ITEM P");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE REG");
                    sbQuery.Append(" ON P.PLT_CODE = REG.PLT_CODE");
                    sbQuery.Append(" AND I.REG_EMP = REG.EMP_CODE");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE MDFY");
                    sbQuery.Append(" ON P.PLT_CODE = MDFY.PLT_CODE");
                    sbQuery.Append(" AND I.MDFY_EMP = MDFY.EMP_CODE");
                    sbQuery.Append(" LEFT JOIN TSTD_VENDOR CVND");
                    sbQuery.Append(" ON P.PLT_CODE = CVND.PLT_CODE");
                    sbQuery.Append(" AND I.CVND_CODE = CVND.VEN_CODE");
                    sbQuery.Append(" LEFT JOIN TSTD_BILL_VENDOR TVND");
                    sbQuery.Append(" ON P.PLT_CODE = TVND.PLT_CODE");
                    sbQuery.Append(" AND I.TVND_CODE = TVND.BVEN_CODE");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE P.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@ITEM_CODE", "I.ITEM_CODE = @ITEM_CODE"));

                        sbWhere.Append(UTIL.GetWhere(row, "@S_REG_DATE, @E_REG_DATE", "(CONVERT(nvarchar(8),I.REG_DATE,112) BETWEEN @S_REG_DATE AND @E_REG_DATE)"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_ORD_DATE, @E_ORD_DATE", "(I.ORD_DATE BETWEEN @S_ORD_DATE AND @E_ORD_DATE)"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_DUE_DATE, @E_DUE_DATE", "(I.DUE_DATE BETWEEN @S_DUE_DATE AND @E_DUE_DATE)"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_DELIVERY_DATE, @E_DELIVERY_DATE", "(I.DELIVERY_DATE BETWEEN @S_DELIVERY_DATE AND @E_DELIVERY_DATE)"));
                        sbWhere.Append(UTIL.GetWhere(row, "@ITEM_LIKE", "I.ITEM_CODE LIKE '%' + @ITEM_LIKE + '%' OR P.ITEM_NAME LIKE '%' + @ITEM_LIKE + '%'"));
                        sbWhere.Append(UTIL.GetWhere(row, "@BUSINESS_EMP", "I.BUSINESS_EMP = @BUSINESS_EMP"));
                        sbWhere.Append(UTIL.GetWhere(row, "@CVND_LIKE", "I.CVND_CODE LIKE '%' + @CVND_LIKE + '%' OR CVND.VEN_NAME LIKE '%' + @CVND_LIKE + '%'"));
                        sbWhere.Append(UTIL.GetWhere(row, "@CVND_CODE", "I.CVND_CODE = @CVND_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@SHIP_FLAG", "I.SHIP_FLAG = @SHIP_FLAG"));
                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "I.DATA_FLAG = @DATA_FLAG"));

                        sbWhere.Append(" ORDER BY P.ITEM_CODE ");

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


        public static DataTable TORD_ITEM_QUERY2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {


                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT P.PLT_CODE");
                    sbQuery.Append(" ,CASE WHEN (P.PROD_QTY - ISNULL(SH.SHIP_QTY,0))  > 0 THEN '부분출하' ELSE '출하' END AS SHIP_STATE");
                    sbQuery.Append(" ,I.ITEM_CODE");
                    sbQuery.Append(" ,I.ITEM_NAME");
                    sbQuery.Append(" ,I.PROD_VERSION");
                    sbQuery.Append(" ,I.PROC_TYPE");
                    sbQuery.Append(" ,I.PROC_FLAG");
                    sbQuery.Append(" ,I.PROD_FLAG");
                    sbQuery.Append(" ,I.INS_YN");
                    sbQuery.Append(" ,I.SOCKET_YN");
                    sbQuery.Append(" ,I.PROD_TYPE");
                    sbQuery.Append(" ,I.PROD_CATEGORY");
                    sbQuery.Append(" ,I.BUSINESS_EMP");
                    sbQuery.Append(" ,I.CUSTOMER_EMP");
                    sbQuery.Append(" ,I.CUSTDESIGN_EMP");
                    sbQuery.Append(" ,I.ACTUATOR_YN");
                    sbQuery.Append(" ,I.CVND_CODE");
                    sbQuery.Append(" ,CVND.VEN_NAME AS CVND_NAME");
                    sbQuery.Append(" ,I.TVND_CODE");
                    sbQuery.Append(" ,TVND.BVEN_NAME AS TVND_NAME");
                    sbQuery.Append(" ,I.PROBE_PIN");
                    sbQuery.Append(" ,I.CURR_UNIT");
                    sbQuery.Append(" ,I.ORD_DATE");
                    sbQuery.Append(" ,I.INDUE_DATE");
                    sbQuery.Append(" ,I.DUE_DATE");
                    sbQuery.Append(" ,I.CHG_DUE_DATE");
                    sbQuery.Append(" ,I.END_DATE");
                    sbQuery.Append(" ,I.DELIVERY_DATE");
                    sbQuery.Append(" ,I.PROD_QTY");
                    sbQuery.Append(" ,I.LOAD_FLAG");
                    sbQuery.Append(" ,I.LOCK_FLAG");
                    sbQuery.Append(" ,I.LOCK_EMP");
                    sbQuery.Append(" ,I.SHIP_FLAG");
                    sbQuery.Append(" ,I.PROD_STATE");
                    sbQuery.Append(" ,I.INOUT_FLAG");
                    sbQuery.Append(" ,I.ORD_VAT");
                    sbQuery.Append(" ,I.PROD_UC");
                    sbQuery.Append(" ,I.PROD_COST");
                    sbQuery.Append(" ,I.PROD_VAT");
                    sbQuery.Append(" ,I.PROD_AMT");
                    sbQuery.Append(" ,I.PROD_KIND");
                    sbQuery.Append(" ,I.PROD_TYPE1");
                    sbQuery.Append(" ,I.PROD_TYPE2");
                    sbQuery.Append(" ,I.INS_FLAG");
                    sbQuery.Append(" ,I.TRADE_YN");
                    sbQuery.Append(" ,I.TAX_YN");
                    sbQuery.Append(" ,I.BILL_YN");

                    sbQuery.Append(" ,(P.PROD_QTY - ISNULL(SH.SHIP_QTY,0)) AS SHIP_QTY");
                    sbQuery.Append(" ,ISNULL(SH.SHIP_QTY,0) AS OLD_SHIP_QTY ");

                    sbQuery.Append(" ,I.SCOMMENT");
                    sbQuery.Append(" ,I.REMARK");
                    sbQuery.Append(" ,I.REG_DATE");
                    sbQuery.Append(" ,I.REG_EMP");
                    sbQuery.Append(" ,REG.EMP_NAME AS REG_EMP_NAME");
                    sbQuery.Append(" ,I.MDFY_DATE");
                    sbQuery.Append(" ,I.MDFY_EMP");
                    sbQuery.Append(" ,MDFY.EMP_NAME AS MDFY_EMP_NAME");
                    sbQuery.Append(" ,I.TRADE_DATE");
                    sbQuery.Append(" ,I.TAX_DATE");
                    sbQuery.Append(" FROM TORD_ITEM P");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE REG");
                    sbQuery.Append(" ON P.PLT_CODE = REG.PLT_CODE");
                    sbQuery.Append(" AND I.REG_EMP = REG.EMP_CODE");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE MDFY");
                    sbQuery.Append(" ON P.PLT_CODE = MDFY.PLT_CODE");
                    sbQuery.Append(" AND I.MDFY_EMP = MDFY.EMP_CODE");
                    sbQuery.Append(" LEFT JOIN TSTD_VENDOR CVND");
                    sbQuery.Append(" ON P.PLT_CODE = CVND.PLT_CODE");
                    sbQuery.Append(" AND I.CVND_CODE = CVND.VEN_CODE");
                    sbQuery.Append(" LEFT JOIN TSTD_BILL_VENDOR TVND");
                    sbQuery.Append(" ON P.PLT_CODE = TVND.PLT_CODE");
                    sbQuery.Append(" AND I.TVND_CODE = TVND.BVEN_CODE");
                    sbQuery.Append(" LEFT JOIN (SELECT PLT_CODE,ITEM_CODE, SUM(ISNULL(SHIP_QTY,0)) AS SHIP_QTY FROM TORD_SHIP WHERE DATA_FLAG = 0 GROUP BY PLT_CODE,ITEM_CODE) SH");
                    sbQuery.Append(" ON P.PLT_CODE = SH.PLT_CODE");
                    sbQuery.Append(" AND I.ITEM_CODE = SH.ITEM_CODE");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE P.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@ITEM_CODE", "I.ITEM_CODE = @ITEM_CODE"));

                        sbWhere.Append(UTIL.GetWhere(row, "@S_REG_DATE, @E_REG_DATE", "(CONVERT(nvarchar(8),I.REG_DATE,112) BETWEEN @S_REG_DATE AND @E_REG_DATE)"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_ORD_DATE, @E_ORD_DATE", "(I.ORD_DATE BETWEEN @S_ORD_DATE AND @E_ORD_DATE)"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_DUE_DATE, @E_DUE_DATE", "(I.DUE_DATE BETWEEN @S_DUE_DATE AND @E_DUE_DATE)"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_DELIVERY_DATE, @E_DELIVERY_DATE", "(I.DELIVERY_DATE BETWEEN @S_DELIVERY_DATE AND @E_DELIVERY_DATE)"));
                        sbWhere.Append(UTIL.GetWhere(row, "@ITEM_LIKE", "I.ITEM_CODE LIKE '%' + @ITEM_LIKE + '%' OR P.ITEM_NAME LIKE '%' + @ITEM_LIKE + '%'"));
                        sbWhere.Append(UTIL.GetWhere(row, "@CVND_LIKE", "I.CVND_CODE LIKE '%' + @CVND_LIKE + '%' OR CVND.VEN_NAME LIKE '%' + @CVND_LIKE + '%'"));
                        sbWhere.Append(UTIL.GetWhere(row, "@BUSINESS_EMP", "I.BUSINESS_EMP = @BUSINESS_EMP"));
                        sbWhere.Append(UTIL.GetWhere(row, "@SHIP_FLAG", "I.SHIP_FLAG = @SHIP_FLAG"));
                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "I.DATA_FLAG = @DATA_FLAG"));


                        sbWhere.Append(" AND (P.PROD_QTY - ISNULL(SH.SHIP_QTY,0)) > 0");

                        sbWhere.Append(" ORDER BY P.ITEM_CODE ");

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



        public static DataTable TORD_ITEM_QUERY3(DataTable dtParam, BizExecute.BizExecute bizExecute)
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
                    sbQuery.Append(" FROM TORD_ITEM P");
                    sbQuery.Append(" LEFT JOIN TSTD_VENDOR CVND");
                    sbQuery.Append(" ON P.PLT_CODE = CVND.PLT_CODE");
                    sbQuery.Append(" AND I.CVND_CODE = CVND.VEN_CODE");
                    sbQuery.Append(" LEFT JOIN (SELECT PLT_CODE,ITEM_CODE,COUNT(*) AS WO_CNT FROM TSHP_WORKORDER WHERE DATA_FLAG = 0 GROUP BY PLT_CODE,ITEM_CODE) W");
                    sbQuery.Append(" ON P.PLT_CODE = W.PLT_CODE");
                    sbQuery.Append(" AND I.ITEM_CODE = W.ITEM_CODE");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE P.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@ITEM_CODE", "I.ITEM_CODE = @ITEM_CODE"));

                        sbWhere.Append(UTIL.GetWhere(row, "@S_REG_DATE, @E_REG_DATE", "(CONVERT(nvarchar(8),I.REG_DATE,112) BETWEEN @S_REG_DATE AND @E_REG_DATE)"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_ORD_DATE, @E_ORD_DATE", "(I.ORD_DATE BETWEEN @S_ORD_DATE AND @E_ORD_DATE)"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_DUE_DATE, @E_DUE_DATE", "(I.DUE_DATE BETWEEN @S_DUE_DATE AND @E_DUE_DATE)"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_DELIVERY_DATE, @E_DELIVERY_DATE", "(I.DELIVERY_DATE BETWEEN @S_DELIVERY_DATE AND @E_DELIVERY_DATE)"));
                        sbWhere.Append(UTIL.GetWhere(row, "@ITEM_LIKE", "I.ITEM_CODE LIKE '%' + @ITEM_LIKE + '%' OR P.ITEM_NAME LIKE '%' + @ITEM_LIKE + '%'"));
                        sbWhere.Append(UTIL.GetWhere(row, "@CVND_LIKE", "I.CVND_CODE LIKE '%' + @CVND_LIKE + '%' OR CVND.VEN_NAME LIKE '%' + @CVND_LIKE + '%'"));
                        sbWhere.Append(UTIL.GetWhere(row, "@BUSINESS_EMP", "I.BUSINESS_EMP = @BUSINESS_EMP"));
                        sbWhere.Append(UTIL.GetWhere(row, "@SHIP_FLAG", "I.SHIP_FLAG = @SHIP_FLAG"));
                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "I.DATA_FLAG = @DATA_FLAG"));
                        sbWhere.Append(" AND I.CVND_CODE IS NOT NULL ");
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


        public static DataTable TORD_ITEM_QUERY8(DataTable dtParam, BizExecute.BizExecute bizExecute)
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
                    sbQuery.Append(" ,I.ITEM_CODE						");
                    sbQuery.Append(" ,I.PART_CODE						");
                    sbQuery.Append(" ,SP.PART_NAME						");
                    sbQuery.Append(" ,I.PROD_STATE						");
                    sbQuery.Append(" ,SP.DRAW_NO						");
                    sbQuery.Append(" ,SP.MAT_TYPE						");
                    sbQuery.Append(" ,SP.MAT_LTYPE						");
                    sbQuery.Append(" ,SP.MAT_MTYPE						");
                    sbQuery.Append(" ,SP.MAT_STYPE						");
                    sbQuery.Append(" ,SP.MAT_SPEC						");
                    sbQuery.Append(" ,SP.MAT_SPEC1						");
                    sbQuery.Append(" ,SP.MAT_UNIT						");
                    sbQuery.Append(" ,I.ORD_DATE						");
                    sbQuery.Append(" ,I.DUE_DATE						");
                    sbQuery.Append(" ,I.PROD_QTY						");
                    sbQuery.Append(" ,I.PROD_UC							");
                    sbQuery.Append(" ,I.PROD_COST						");
                    sbQuery.Append(" ,I.PROD_VAT						");
                    sbQuery.Append(" ,I.PROD_AMT						");
                    sbQuery.Append(" FROM TORD_ITEM P				");
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
                    sbQuery.Append(" AND I.PART_CODE = SP.PART_CODE		");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE P.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                        sbWhere.Append(UTIL.GetWhere(row, "@ITEM_LIKE", "(I.ITEM_CODE LIKE '%' + @ITEM_LIKE + '%' OR I.ITEM_NAME LIKE '%' + @ITEM_LIKE + '%')"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_LIKE", "(I.PART_CODE LIKE '%' + @PART_LIKE + '%' OR SP.PART_NAME LIKE '%' + @PART_LIKE + '%')"));
                        sbWhere.Append(UTIL.GetWhere(row, "@CVND_CODE", "I.CVND_CODE = @CVND_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@ITEM_CODE", "I.ITEM_CODE = @ITEM_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_STATE_FLAG_WT", "A.PROD_STATE NOT IN ('WT')"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_STATE_FLAG_WK", "A.PROD_STATE NOT IN ('WK')"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_STATE_FLAG_PG", "A.PROD_STATE NOT IN ('PG')"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_STATE_FLAG_SH", "A.PROD_STATE NOT IN ('SH')"));
                        sbWhere.Append(UTIL.GetWhere(row, "@VEN_LIKE", "(I.CVND_CODE LIKE '%' + @VEN_LIKE + '%' OR V.VEN_NAME LIKE '%' + @VEN_LIKE + '%')"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_STATE", "I.PROD_STATE IN @PROD_STATE", UTIL.SqlCondType.IN));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_ORD_DATE, @E_ORD_DATE", "(I.ORD_DATE BETWEEN @S_ORD_DATE AND @E_ORD_DATE)"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_DUE_DATE, @E_DUE_DATE", "(I.DUE_DATE BETWEEN @S_DUE_DATE AND @E_DUE_DATE)"));

                        string cond = "(SP.PART_CODE LIKE '%' + @SEARCH_CON + '%' OR V.VEN_NAME LIKE '%' + @SEARCH_CON + '%' OR I.ITEM_CODE LIKE '%' + @SEARCH_CON + '%' OR SP.PART_NAME LIKE '%' + @SEARCH_CON + '%' )";
                        sbWhere.Append(UTIL.GetWhere(row, "@SEARCH_CON", cond));

                        sbWhere.Append(" AND I.DATA_FLAG = '0'");
                        sbWhere.Append(" AND I.PARENT_PART IS NULL");

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




        public static DataTable TORD_ITEM_QUERY12(DataTable dtParam, BizExecute.BizExecute bizExecute)
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
                    sbQuery.Append(" ,I.ITEM_CODE						");
                    sbQuery.Append(" ,I.PART_CODE						");
                    sbQuery.Append(" ,SP.PART_NAME						");
                    sbQuery.Append(" ,I.PROD_STATE						");
                    sbQuery.Append(" ,SP.DRAW_NO						");
                    sbQuery.Append(" ,SP.MAT_TYPE						");
                    sbQuery.Append(" ,SP.MAT_LTYPE						");
                    sbQuery.Append(" ,SP.MAT_MTYPE						");
                    sbQuery.Append(" ,SP.MAT_STYPE						");
                    sbQuery.Append(" ,SP.MAT_SPEC						");
                    sbQuery.Append(" ,SP.MAT_SPEC1						");
                    sbQuery.Append(" ,SP.MAT_UNIT						");
                    sbQuery.Append(" ,I.ORD_DATE						");
                    sbQuery.Append(" ,I.DUE_DATE						");
                    sbQuery.Append(" ,I.PROD_QTY						");
                    sbQuery.Append(" ,I.PROD_UC							");
                    sbQuery.Append(" ,I.PROD_COST						");
                    sbQuery.Append(" ,I.PROD_VAT						");
                    sbQuery.Append(" ,I.PROD_AMT						");
                    sbQuery.Append(" FROM TORD_ITEM P				");
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
                    sbQuery.Append(" AND I.PART_CODE = SP.PART_CODE		");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE P.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                        sbWhere.Append(UTIL.GetWhere(row, "@CVND_CODE", "I.CVND_CODE = @CVND_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@ITEM_CODE", "I.ITEM_CODE = @ITEM_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_CODE", "I.PART_CODE = @PART_CODE"));

                        sbWhere.Append(" AND I.PARENT_PART IS NULL");
                        sbWhere.Append(" AND I.DATA_FLAG = '0'");

                        sbWhere.Append(" ORDER BY ORD_DATE DESC");
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




        public static DataTable TORD_ITEM_QUERY13(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {


                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT P.PLT_CODE");
                    sbQuery.Append(" ,I.ITEM_CODE");
                    sbQuery.Append(" ,I.ITEM_CODE");
                    sbQuery.Append(" ,I.ITEM_NAME");
                    sbQuery.Append(" ,I.PROD_VERSION");
                    sbQuery.Append(" ,I.PROC_FLAG");
                    sbQuery.Append(" ,I.PROD_FLAG");
                    sbQuery.Append(" ,I.INS_YN");
                    sbQuery.Append(" ,I.SOCKET_YN");
                    sbQuery.Append(" ,I.PROD_TYPE");
                    sbQuery.Append(" ,I.PROD_CATEGORY");
                    sbQuery.Append(" ,I.BUSINESS_EMP");
                    sbQuery.Append(" ,I.CUSTOMER_EMP");
                    sbQuery.Append(" ,I.CUSTDESIGN_EMP");
                    sbQuery.Append(" ,I.ACTUATOR_YN");
                    sbQuery.Append(" ,I.CVND_CODE");
                    sbQuery.Append(" ,CVND.VEN_NAME AS CVND_NAME");
                    sbQuery.Append(" ,I.TVND_CODE");
                    sbQuery.Append(" ,TVND.BVEN_NAME AS TVND_NAME");
                    sbQuery.Append(" ,I.PROBE_PIN");
                    sbQuery.Append(" ,I.CURR_UNIT");
                    sbQuery.Append(" ,I.ORD_DATE");
                    sbQuery.Append(" ,I.INDUE_DATE");
                    sbQuery.Append(" ,I.DUE_DATE");
                    sbQuery.Append(" ,I.CHG_DUE_DATE");
                    sbQuery.Append(" ,I.END_DATE");
                    sbQuery.Append(" ,I.DELIVERY_DATE");
                    sbQuery.Append(" ,I.PROD_QTY");
                    sbQuery.Append(" ,I.LOAD_FLAG");
                    sbQuery.Append(" ,I.LOCK_FLAG");
                    sbQuery.Append(" ,I.LOCK_EMP");
                    sbQuery.Append(" ,I.SHIP_FLAG");
                    sbQuery.Append(" ,I.PROD_STATE");
                    sbQuery.Append(" ,I.INOUT_FLAG");
                    sbQuery.Append(" ,I.ORD_VAT");
                    sbQuery.Append(" ,I.PROD_UC");
                    sbQuery.Append(" ,I.PROD_COST");
                    sbQuery.Append(" ,I.PROD_VAT");
                    sbQuery.Append(" ,I.PROD_AMT");
                    sbQuery.Append(" ,I.PROD_KIND");
                    sbQuery.Append(" ,I.PROD_TYPE1");
                    sbQuery.Append(" ,I.PROD_TYPE2");
                    sbQuery.Append(" ,I.INS_FLAG");
                    sbQuery.Append(" ,I.TRADE_YN");
                    sbQuery.Append(" ,I.TAX_YN");
                    sbQuery.Append(" ,I.BILL_YN");
                    sbQuery.Append(" ,I.SCOMMENT");
                    sbQuery.Append(" ,I.REMARK");
                    sbQuery.Append(" ,I.REG_DATE");
                    sbQuery.Append(" ,I.REG_EMP");
                    sbQuery.Append(" ,REG.EMP_NAME AS REG_EMP_NAME");
                    sbQuery.Append(" ,I.MDFY_DATE");
                    sbQuery.Append(" ,I.MDFY_EMP");
                    sbQuery.Append(" ,MDFY.EMP_NAME AS MDFY_EMP_NAME");

                    sbQuery.Append(" ,CONVERT(nvarchar(10),CAM.WO_CNT - CAM.NONE_CNT) + '/' + CONVERT(nvarchar(10),CAM.NONE_CNT) AS CAM_CNT ");

                    sbQuery.Append(" ,(SELECT ISNULL(MIN(PROC_STAT),'0') FROM TSHP_ACTUAL_CAM WHERE PLT_CODE = P.PLT_CODE AND WO_NO IN (SELECT WO_NO FROM TSHP_WORKORDER WHERE ITEM_CODE = P.ITEM_CODE)) AS CAM_STATE  ");

                    sbQuery.Append(" FROM TORD_ITEM P");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE REG");
                    sbQuery.Append(" ON P.PLT_CODE = REG.PLT_CODE");
                    sbQuery.Append(" AND I.REG_EMP = REG.EMP_CODE");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE MDFY");
                    sbQuery.Append(" ON P.PLT_CODE = MDFY.PLT_CODE");
                    sbQuery.Append(" AND I.MDFY_EMP = MDFY.EMP_CODE");
                    sbQuery.Append(" LEFT JOIN TSTD_VENDOR CVND");
                    sbQuery.Append(" ON P.PLT_CODE = CVND.PLT_CODE");
                    sbQuery.Append(" AND I.CVND_CODE = CVND.VEN_CODE");
                    sbQuery.Append(" LEFT JOIN TSTD_BILL_VENDOR TVND");
                    sbQuery.Append(" ON P.PLT_CODE = TVND.PLT_CODE");
                    sbQuery.Append(" AND I.TVND_CODE = TVND.BVEN_CODE");
                    sbQuery.Append(" LEFT JOIN (SELECT PLT_CODE,ITEM_CODE,SUM(CASE WHEN CAM_EMP IS NULL THEN 1 ELSE 0 END) AS NONE_CNT,COUNT(*) AS WO_CNT FROM TSHP_WORKORDER WHERE DATA_FLAG = 0 GROUP BY PLT_CODE,ITEM_CODE) CAM");
                    sbQuery.Append(" ON P.PLT_CODE = CAM.PLT_CODE");
                    sbQuery.Append(" AND I.ITEM_CODE = CAM.ITEM_CODE");
                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE P.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@ITEM_CODE", "I.ITEM_CODE = @ITEM_CODE"));

                        sbWhere.Append(UTIL.GetWhere(row, "@S_REG_DATE, @E_REG_DATE", "(CONVERT(nvarchar(8),I.REG_DATE,112) BETWEEN @S_REG_DATE AND @E_REG_DATE)"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_ORD_DATE, @E_ORD_DATE", "(I.ORD_DATE BETWEEN @S_ORD_DATE AND @E_ORD_DATE)"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_DUE_DATE, @E_DUE_DATE", "(I.DUE_DATE BETWEEN @S_DUE_DATE AND @E_DUE_DATE)"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_DELIVERY_DATE, @E_DELIVERY_DATE", "(I.DELIVERY_DATE BETWEEN @S_DELIVERY_DATE AND @E_DELIVERY_DATE)"));
                        sbWhere.Append(UTIL.GetWhere(row, "@ITEM_LIKE", "I.ITEM_CODE LIKE '%' + @ITEM_LIKE + '%' OR P.ITEM_NAME LIKE '%' + @ITEM_LIKE + '%'"));
                        sbWhere.Append(UTIL.GetWhere(row, "@BUSINESS_EMP", "I.BUSINESS_EMP = @BUSINESS_EMP"));
                        sbWhere.Append(UTIL.GetWhere(row, "@CVND_LIKE", "I.CVND_CODE LIKE '%' + @CVND_LIKE + '%' OR CVND.VEN_NAME LIKE '%' + @CVND_LIKE + '%'"));
                        sbWhere.Append(UTIL.GetWhere(row, "@CVND_CODE", "I.CVND_CODE = @CVND_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@SHIP_FLAG", "I.SHIP_FLAG = @SHIP_FLAG"));
                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "I.DATA_FLAG = @DATA_FLAG"));
                        sbWhere.Append(" AND I.PROD_STATE <> '5' ");
                        sbWhere.Append(" ORDER BY I.ITEM_CODE ");

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


        public static DataTable TORD_ITEM_QUERY14(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {


                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT P.PLT_CODE");
                    sbQuery.Append(" ,I.ITEM_CODE");
                    sbQuery.Append(" ,I.ITEM_CODE");
                    sbQuery.Append(" ,I.ITEM_NAME");
                    sbQuery.Append(" ,I.PROD_VERSION");
                    sbQuery.Append(" ,I.PROC_FLAG");
                    sbQuery.Append(" ,I.PROD_FLAG");
                    sbQuery.Append(" ,I.INS_YN");
                    sbQuery.Append(" ,I.SOCKET_YN");
                    sbQuery.Append(" ,I.PROD_TYPE");
                    sbQuery.Append(" ,I.PROD_CATEGORY");
                    sbQuery.Append(" ,I.BUSINESS_EMP");
                    sbQuery.Append(" ,I.CUSTOMER_EMP");
                    sbQuery.Append(" ,I.CUSTDESIGN_EMP");
                    sbQuery.Append(" ,I.ACTUATOR_YN");
                    sbQuery.Append(" ,I.CVND_CODE");
                    sbQuery.Append(" ,CVND.VEN_NAME AS CVND_NAME");
                    sbQuery.Append(" ,I.TVND_CODE");
                    sbQuery.Append(" ,TVND.BVEN_NAME AS TVND_NAME");
                    sbQuery.Append(" ,I.PROBE_PIN");
                    sbQuery.Append(" ,I.CURR_UNIT");
                    sbQuery.Append(" ,I.ORD_DATE");
                    sbQuery.Append(" ,I.INDUE_DATE");
                    sbQuery.Append(" ,I.DUE_DATE");
                    sbQuery.Append(" ,I.CHG_DUE_DATE");
                    sbQuery.Append(" ,I.END_DATE");
                    sbQuery.Append(" ,I.DELIVERY_DATE");
                    sbQuery.Append(" ,I.PROD_QTY");
                    sbQuery.Append(" ,(SELECT ISNULL(SUM(ASSY_QTY),0) FROM TSHP_ACTUAL_ASSY A WHERE P.PLT_CODE = A.PLT_CODE AND I.ITEM_CODE = A.ITEM_CODE ) AS OLD_ASSY_QTY");
                    sbQuery.Append(" ,0 AS ASSY_QTY");
                    sbQuery.Append(" ,I.LOAD_FLAG");
                    sbQuery.Append(" ,I.LOCK_FLAG");
                    sbQuery.Append(" ,I.LOCK_EMP");
                    sbQuery.Append(" ,I.SHIP_FLAG");
                    sbQuery.Append(" ,I.PROD_STATE");
                    sbQuery.Append(" ,I.INOUT_FLAG");
                    sbQuery.Append(" ,I.ORD_VAT");
                    sbQuery.Append(" ,I.PROD_UC");
                    sbQuery.Append(" ,I.PROD_COST");
                    sbQuery.Append(" ,I.PROD_VAT");
                    sbQuery.Append(" ,I.PROD_AMT");
                    sbQuery.Append(" ,I.PROD_KIND");
                    sbQuery.Append(" ,I.PROD_TYPE1");
                    sbQuery.Append(" ,I.PROD_TYPE2");
                    sbQuery.Append(" ,I.INS_FLAG");
                    sbQuery.Append(" ,I.TRADE_YN");
                    sbQuery.Append(" ,I.TAX_YN");
                    sbQuery.Append(" ,I.BILL_YN");
                    sbQuery.Append(" ,I.SCOMMENT");
                    sbQuery.Append(" ,I.REMARK");
                    sbQuery.Append(" ,I.REG_DATE");
                    sbQuery.Append(" ,I.REG_EMP");
                    sbQuery.Append(" ,REG.EMP_NAME AS REG_EMP_NAME");
                    sbQuery.Append(" ,I.MDFY_DATE");
                    sbQuery.Append(" ,I.MDFY_EMP");
                    sbQuery.Append(" ,MDFY.EMP_NAME AS MDFY_EMP_NAME");


                    //sbQuery.Append(" ,CONVERT(nvarchar(10),CAM.WO_CNT - CAM.NONE_CNT) + '/' + CONVERT(nvarchar(10),CAM.NONE_CNT) AS CAM_CNT ");

                    //sbQuery.Append(" ,(SELECT ISNULL(MIN(PROC_STAT),'0') FROM TSHP_ACTUAL_CAM WHERE PLT_CODE = P.PLT_CODE AND ITEM_CODE = P.ITEM_CODE) AS CAM_STATE ");

                    sbQuery.Append(" FROM TORD_ITEM P");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE REG");
                    sbQuery.Append(" ON P.PLT_CODE = REG.PLT_CODE");
                    sbQuery.Append(" AND I.REG_EMP = REG.EMP_CODE");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE MDFY");
                    sbQuery.Append(" ON P.PLT_CODE = MDFY.PLT_CODE");
                    sbQuery.Append(" AND I.MDFY_EMP = MDFY.EMP_CODE");
                    sbQuery.Append(" LEFT JOIN TSTD_VENDOR CVND");
                    sbQuery.Append(" ON P.PLT_CODE = CVND.PLT_CODE");
                    sbQuery.Append(" AND I.CVND_CODE = CVND.VEN_CODE");
                    sbQuery.Append(" LEFT JOIN TSTD_BILL_VENDOR TVND");
                    sbQuery.Append(" ON P.PLT_CODE = TVND.PLT_CODE");
                    sbQuery.Append(" AND I.TVND_CODE = TVND.BVEN_CODE");
                    sbQuery.Append(" LEFT JOIN (SELECT PLT_CODE,ITEM_CODE,SUM(CASE WHEN CAM_EMP IS NULL THEN 1 ELSE 0 END) AS NONE_CNT,COUNT(*) AS WO_CNT FROM TSHP_WORKORDER WHERE DATA_FLAG = 0 GROUP BY PLT_CODE,ITEM_CODE) CAM");
                    sbQuery.Append(" ON P.PLT_CODE = CAM.PLT_CODE");
                    sbQuery.Append(" AND I.ITEM_CODE = CAM.ITEM_CODE");
                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE P.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@ITEM_CODE", "I.ITEM_CODE = @ITEM_CODE"));

                        sbWhere.Append(UTIL.GetWhere(row, "@S_REG_DATE, @E_REG_DATE", "(CONVERT(nvarchar(8),I.REG_DATE,112) BETWEEN @S_REG_DATE AND @E_REG_DATE)"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_ORD_DATE, @E_ORD_DATE", "(I.ORD_DATE BETWEEN @S_ORD_DATE AND @E_ORD_DATE)"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_DUE_DATE, @E_DUE_DATE", "(I.DUE_DATE BETWEEN @S_DUE_DATE AND @E_DUE_DATE)"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_DELIVERY_DATE, @E_DELIVERY_DATE", "(I.DELIVERY_DATE BETWEEN @S_DELIVERY_DATE AND @E_DELIVERY_DATE)"));
                        sbWhere.Append(UTIL.GetWhere(row, "@ITEM_LIKE", "I.ITEM_CODE LIKE '%' + @ITEM_LIKE + '%' OR P.ITEM_NAME LIKE '%' + @ITEM_LIKE + '%'"));
                        sbWhere.Append(UTIL.GetWhere(row, "@BUSINESS_EMP", "I.BUSINESS_EMP = @BUSINESS_EMP"));
                        sbWhere.Append(UTIL.GetWhere(row, "@CVND_LIKE", "I.CVND_CODE LIKE '%' + @CVND_LIKE + '%' OR CVND.VEN_NAME LIKE '%' + @CVND_LIKE + '%'"));
                        sbWhere.Append(UTIL.GetWhere(row, "@CVND_CODE", "I.CVND_CODE = @CVND_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@SHIP_FLAG", "I.SHIP_FLAG = @SHIP_FLAG"));
                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "I.DATA_FLAG = @DATA_FLAG"));
                        sbWhere.Append(" AND I.PROD_STATE <> '5' ");
                        sbWhere.Append(" ORDER BY P.ITEM_CODE ");

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
        public static DataTable TORD_ITEM_QUERY15(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {


                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT P.PLT_CODE");
                    sbQuery.Append(" ,I.ITEM_CODE");
                    sbQuery.Append(" ,I.ITEM_CODE");
                    sbQuery.Append(" ,I.ITEM_NAME");
                    sbQuery.Append(" ,I.PROD_VERSION");
                    sbQuery.Append(" ,I.PROC_FLAG");
                    sbQuery.Append(" ,I.PROD_FLAG");
                    sbQuery.Append(" ,I.INS_YN");
                    sbQuery.Append(" ,I.SOCKET_YN");
                    sbQuery.Append(" ,I.PROD_TYPE");
                    sbQuery.Append(" ,I.PROD_CATEGORY");
                    sbQuery.Append(" ,I.BUSINESS_EMP");
                    sbQuery.Append(" ,I.CUSTOMER_EMP");
                    sbQuery.Append(" ,I.CUSTDESIGN_EMP");
                    sbQuery.Append(" ,I.ACTUATOR_YN");
                    sbQuery.Append(" ,I.CVND_CODE");
                    sbQuery.Append(" ,CVND.VEN_NAME AS CVND_NAME");
                    sbQuery.Append(" ,I.TVND_CODE");
                    sbQuery.Append(" ,TVND.BVEN_NAME AS TVND_NAME");
                    sbQuery.Append(" ,I.PROBE_PIN");
                    sbQuery.Append(" ,I.CURR_UNIT");
                    sbQuery.Append(" ,I.ORD_DATE");
                    sbQuery.Append(" ,I.INDUE_DATE");
                    sbQuery.Append(" ,I.DUE_DATE");
                    sbQuery.Append(" ,I.CHG_DUE_DATE");
                    sbQuery.Append(" ,I.END_DATE");
                    sbQuery.Append(" ,I.DELIVERY_DATE");
                    sbQuery.Append(" ,I.PROD_QTY");
                    sbQuery.Append(" ,I.LOAD_FLAG");
                    sbQuery.Append(" ,I.LOCK_FLAG");
                    sbQuery.Append(" ,I.LOCK_EMP");
                    sbQuery.Append(" ,I.SHIP_FLAG");
                    sbQuery.Append(" ,I.PROD_STATE");
                    sbQuery.Append(" ,I.INOUT_FLAG");
                    sbQuery.Append(" ,I.ORD_VAT");
                    sbQuery.Append(" ,I.PROD_UC");
                    sbQuery.Append(" ,I.PROD_COST");
                    sbQuery.Append(" ,I.PROD_VAT");
                    sbQuery.Append(" ,I.PROD_AMT");
                    sbQuery.Append(" ,I.PROD_KIND");
                    sbQuery.Append(" ,I.PROD_TYPE1");
                    sbQuery.Append(" ,I.PROD_TYPE2");
                    sbQuery.Append(" ,I.INS_FLAG");
                    sbQuery.Append(" ,I.TRADE_YN");
                    sbQuery.Append(" ,I.TAX_YN");
                    sbQuery.Append(" ,I.BILL_YN");
                    sbQuery.Append(" ,I.SCOMMENT");
                    sbQuery.Append(" ,I.REMARK");
                    sbQuery.Append(" ,I.REG_DATE");
                    sbQuery.Append(" ,I.REG_EMP");
                    sbQuery.Append(" ,REG.EMP_NAME AS REG_EMP_NAME");
                    sbQuery.Append(" ,I.MDFY_DATE");
                    sbQuery.Append(" ,I.MDFY_EMP");
                    sbQuery.Append(" ,MDFY.EMP_NAME AS MDFY_EMP_NAME");
                    sbQuery.Append(" FROM TORD_ITEM P");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE REG");
                    sbQuery.Append(" ON P.PLT_CODE = REG.PLT_CODE");
                    sbQuery.Append(" AND I.REG_EMP = REG.EMP_CODE");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE MDFY");
                    sbQuery.Append(" ON P.PLT_CODE = MDFY.PLT_CODE");
                    sbQuery.Append(" AND I.MDFY_EMP = MDFY.EMP_CODE");
                    sbQuery.Append(" LEFT JOIN TSTD_VENDOR CVND");
                    sbQuery.Append(" ON P.PLT_CODE = CVND.PLT_CODE");
                    sbQuery.Append(" AND I.CVND_CODE = CVND.VEN_CODE");
                    sbQuery.Append(" LEFT JOIN TSTD_BILL_VENDOR TVND");
                    sbQuery.Append(" ON P.PLT_CODE = TVND.PLT_CODE");
                    sbQuery.Append(" AND I.TVND_CODE = TVND.BVEN_CODE");
                    sbQuery.Append(" INNER JOIN (SELECT TP.PLT_CODE, TP.ITEM_CODE FROM TMAT_PARTLIST TP  ");
                    sbQuery.Append("            	INNER JOIN TMAT_OUT_REQ_PT RPT									   ");
                    sbQuery.Append("            		ON TP.PT_ID = RPT.PT_ID										   ");
                    sbQuery.Append("            		AND TP.PLT_CODE = RPT.PLT_CODE								   ");
                    sbQuery.Append("            	INNER JOIN TMAT_OUT_REQ REQ										   ");
                    sbQuery.Append("            		ON RPT.OUT_REQ_ID = REQ.OUT_REQ_ID							   ");
                    sbQuery.Append("            		AND RPT.PLT_CODE = REQ.PLT_CODE								   ");
                    sbQuery.Append("               WHERE REQ.FIELD_CODE = @FIELD_CODE							   ");
                    sbQuery.Append("            GROUP BY TP.PLT_CODE, TP.ITEM_CODE) MP					   ");
                    sbQuery.Append(" ON P.ITEM_CODE = MP.ITEM_CODE");
                    sbQuery.Append(" AND I.PLT_CODE = MP.PLT_CODE");
                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;
                        if (!UTIL.ValidColumn(row, "FIELD_CODE")) isHasColumn = false;

                        StringBuilder sbWhere = new StringBuilder(" WHERE P.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@ITEM_CODE", "I.ITEM_CODE = @ITEM_CODE"));

                        sbWhere.Append(UTIL.GetWhere(row, "@S_REG_DATE, @E_REG_DATE", "(CONVERT(nvarchar(8),I.REG_DATE,112) BETWEEN @S_REG_DATE AND @E_REG_DATE)"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_ORD_DATE, @E_ORD_DATE", "(I.ORD_DATE BETWEEN @S_ORD_DATE AND @E_ORD_DATE)"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_DUE_DATE, @E_DUE_DATE", "(I.DUE_DATE BETWEEN @S_DUE_DATE AND @E_DUE_DATE)"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_DELIVERY_DATE, @E_DELIVERY_DATE", "(I.DELIVERY_DATE BETWEEN @S_DELIVERY_DATE AND @E_DELIVERY_DATE)"));
                        sbWhere.Append(UTIL.GetWhere(row, "@ITEM_LIKE", "I.ITEM_CODE LIKE '%' + @ITEM_LIKE + '%' OR P.ITEM_NAME LIKE '%' + @ITEM_LIKE + '%'"));
                        sbWhere.Append(UTIL.GetWhere(row, "@BUSINESS_EMP", "I.BUSINESS_EMP = @BUSINESS_EMP"));
                        sbWhere.Append(UTIL.GetWhere(row, "@CVND_LIKE", "I.CVND_CODE LIKE '%' + @CVND_LIKE + '%' OR CVND.VEN_NAME LIKE '%' + @CVND_LIKE + '%'"));
                        sbWhere.Append(UTIL.GetWhere(row, "@CVND_CODE", "I.CVND_CODE = @CVND_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@SHIP_FLAG", "I.SHIP_FLAG = @SHIP_FLAG"));
                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "I.DATA_FLAG = @DATA_FLAG"));

                        sbWhere.Append(" ORDER BY P.ITEM_CODE ");

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
    }
}
