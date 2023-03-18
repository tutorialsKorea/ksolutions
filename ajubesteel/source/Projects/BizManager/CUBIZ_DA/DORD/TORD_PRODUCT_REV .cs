using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BizExecute;
using System.Data;

namespace DORD
{
    public class TORD_PRODUCT_REV
    {
        public static DataTable TORD_PRODUCT_REV_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("  SELECT  ");
                    sbQuery.Append("  PLT_CODE ");
                    sbQuery.Append(" ,REV_ID ");
                    sbQuery.Append(" ,REV_NO ");
                    sbQuery.Append(" ,REV_EMP ");
                    sbQuery.Append(" ,PROD_CODE ");
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
                    sbQuery.Append(" ,DELIVERY_DATE ");
                    sbQuery.Append(" ,PROD_QTY ");
                    sbQuery.Append(" ,PROD_STATE ");
                    sbQuery.Append(" ,ORD_VAT ");
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
                    sbQuery.Append(" ,MSOP_YN ");
                    sbQuery.Append(" ,DFM_DATE ");
                    sbQuery.Append(" ,MSOP_DATE ");
                    sbQuery.Append(" ,DRAW_DATE ");
                    sbQuery.Append(" ,DRAW_TYPE ");
                    sbQuery.Append(" ,MODEL_TYPE ");
                    sbQuery.Append(" ,VISION_TYPE ");
                    sbQuery.Append(" ,VISION_DIRECTION ");
                    sbQuery.Append(" ,PART_CODE ");
                    sbQuery.Append(" ,MODEL_CODE ");
                    sbQuery.Append(" ,ITEM_FLAG ");
                    sbQuery.Append(" ,PROD_PRIORITY ");
                    sbQuery.Append(" ,MSOP_DFM ");
                    sbQuery.Append(" ,GUBUN    ");
                    sbQuery.Append("  FROM TORD_PRODUCT_REV  ");
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



        public static DataTable TORD_PRODUCT_REV_SER2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("  SELECT MAX(REV_NO) AS REV_MAX ");
                    sbQuery.Append("  FROM TORD_PRODUCT_REV  ");
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



        public static void TORD_PRODUCT_REV_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" INSERT INTO TORD_PRODUCT_REV (  ");
                    sbQuery.Append("  PLT_CODE ");
                    sbQuery.Append(" ,REV_ID ");
                    sbQuery.Append(" ,REV_NO ");
                    sbQuery.Append(" ,REV_EMP ");
                    sbQuery.Append(" ,PROD_CODE ");
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
                    sbQuery.Append(" ,DELIVERY_DATE ");
                    sbQuery.Append(" ,PROD_QTY ");
                    sbQuery.Append(" ,PROD_STATE ");
                    sbQuery.Append(" ,ORD_VAT ");
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
                    sbQuery.Append(" ,PRJ_CODE ");
                    sbQuery.Append(" ,REG_DATE ");
                    sbQuery.Append(" ,REG_EMP ");
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
                    sbQuery.Append(" ,MSOP_YN ");
                    sbQuery.Append(" ,DFM_DATE ");
                    sbQuery.Append(" ,MSOP_DATE ");
                    sbQuery.Append(" ,DRAW_DATE ");
                    sbQuery.Append(" ,DRAW_TYPE ");
                    sbQuery.Append(" ,MODEL_TYPE ");
                    sbQuery.Append(" ,VISION_TYPE ");
                    sbQuery.Append(" ,VISION_DIRECTION ");
                    sbQuery.Append(" ,PART_CODE ");
                    sbQuery.Append(" ,MODEL_CODE ");
                    sbQuery.Append(" ,ITEM_FLAG ");
                    sbQuery.Append(" ,PROD_PRIORITY ");
                    sbQuery.Append(" ,MSOP_DFM ");
                    sbQuery.Append(" ,GUBUN ");
                    sbQuery.Append(" ,BALJU_TYPE ");
                    sbQuery.Append(" ,PO_NO ");
                    sbQuery.Append("  ) VALUES (  ");
                    sbQuery.Append("  @PLT_CODE ");
                    sbQuery.Append(" ,@REV_ID ");
                    sbQuery.Append(" ,@REV_NO ");
                    sbQuery.Append(" ,@REV_EMP ");
                    sbQuery.Append(" ,@PROD_CODE ");
                    sbQuery.Append(" ,@PROD_NAME ");
                    sbQuery.Append(" ,@PROD_VERSION ");
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
                    sbQuery.Append(" ,@DELIVERY_DATE ");
                    sbQuery.Append(" ,@PROD_QTY ");
                    sbQuery.Append(" ,@PROD_STATE ");
                    sbQuery.Append(" ,@ORD_VAT ");
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
                    sbQuery.Append(" ,@PRJ_CODE ");
                    sbQuery.Append(" ,GETDATE() ");
                    sbQuery.Append(" ,'" + ConnInfo.UserID + "' ");
                    sbQuery.Append(" ,@DATA_FLAG ");
                    sbQuery.Append(" ,@TRADE_DATE ");
                    sbQuery.Append(" ,@TAX_DATE ");
                    sbQuery.Append(" ,@PROC_TYPE ");
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
                    sbQuery.Append(" ,@DFM_YN ");
                    sbQuery.Append(" ,@MSOP_YN ");
                    sbQuery.Append(" ,@DFM_DATE ");
                    sbQuery.Append(" ,@MSOP_DATE ");
                    sbQuery.Append(" ,@DRAW_DATE ");
                    sbQuery.Append(" ,@DRAW_TYPE ");
                    sbQuery.Append(" ,@MODEL_TYPE ");
                    sbQuery.Append(" ,@VISION_TYPE ");
                    sbQuery.Append(" ,@VISION_DIRECTION ");
                    sbQuery.Append(" ,@PART_CODE ");
                    sbQuery.Append(" ,@MODEL_CODE ");
                    sbQuery.Append(" ,@ITEM_FLAG ");
                    sbQuery.Append(" ,@PROD_PRIORITY ");
                    sbQuery.Append(" ,@MSOP_DFM ");
                    sbQuery.Append(" ,@GUBUN ");
                    sbQuery.Append(" ,@BALJU_TYPE ");
                    sbQuery.Append(" ,@PO_NO ");
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
    }

    public class TORD_PRODUCT_REV_QUERY
    {
        public static DataTable TORD_PRODUCT_REV_QUERY1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {


                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("  SELECT  ");
                    sbQuery.Append("  PV.PLT_CODE ");
                    sbQuery.Append(" ,PV.REV_ID ");
                    sbQuery.Append(" ,PV.REV_NO ");
                    sbQuery.Append(" ,PV.REV_EMP ");
                    sbQuery.Append(" ,REV.EMP_NAME AS REV_NAME ");
                    sbQuery.Append(" ,PV.PROD_CODE ");
                    sbQuery.Append(" ,PV.PROD_NAME ");
                    sbQuery.Append(" ,PV.PROD_VERSION ");
                    sbQuery.Append(" ,PV.PROC_FLAG ");
                    sbQuery.Append(" ,PV.PROD_FLAG ");
                    sbQuery.Append(" ,PV.INS_YN ");
                    sbQuery.Append(" ,PV.SOCKET_YN ");
                    sbQuery.Append(" ,PV.PROD_TYPE ");
                    sbQuery.Append(" ,PV.PROD_CATEGORY ");
                    sbQuery.Append(" ,PV.BUSINESS_EMP ");
                    sbQuery.Append(" ,EMP.EMP_NAME AS BUSINESS_EMP_NAME ");
                    sbQuery.Append(" ,PV.CUSTOMER_EMP ");
                    sbQuery.Append(" ,PV.CUSTDESIGN_EMP ");
                    sbQuery.Append(" ,PV.ACTUATOR_YN ");
                    sbQuery.Append(" ,PV.CVND_CODE ");
                    sbQuery.Append(" ,CVND.VEN_NAME AS CVND_NAME");
                    sbQuery.Append(" ,PV.TVND_CODE ");
                    sbQuery.Append(" ,TVND.BVEN_NAME AS TVND_NAME");
                    sbQuery.Append(" ,PV.PROBE_PIN ");
                    sbQuery.Append(" ,PV.CURR_UNIT ");
                    sbQuery.Append(" ,CONVERT(DATETIME,PV.ORD_DATE) AS ORD_DATE ");
                    sbQuery.Append(" ,CONVERT(DATETIME,PV.INDUE_DATE) AS INDUE_DATE ");
                    sbQuery.Append(" ,CONVERT(DATETIME,PV.DUE_DATE) AS DUE_DATE ");
                    sbQuery.Append(" ,CONVERT(DATETIME,PV.CHG_DUE_DATE) AS CHG_DUE_DATE ");
                    sbQuery.Append(" ,CONVERT(DATETIME,PV.DELIVERY_DATE) AS DELIVERY_DATE ");
                    sbQuery.Append(" ,PV.PROD_QTY ");
                    sbQuery.Append(" ,PV.PROD_STATE ");
                    sbQuery.Append(" ,PV.ORD_VAT ");
                    sbQuery.Append(" ,PV.PROD_COST ");
                    sbQuery.Append(" ,PV.PROD_VAT ");
                    sbQuery.Append(" ,PV.PROD_AMT ");
                    sbQuery.Append(" ,PV.PROD_KIND ");
                    sbQuery.Append(" ,PV.PROD_TYPE1 ");
                    sbQuery.Append(" ,PV.PROD_TYPE2 ");
                    sbQuery.Append(" ,PV.INS_FLAG ");
                    sbQuery.Append(" ,PV.TRADE_YN ");
                    sbQuery.Append(" ,PV.TAX_YN ");
                    sbQuery.Append(" ,PV.BILL_YN ");
                    sbQuery.Append(" ,PV.SCOMMENT ");
                    sbQuery.Append(" ,PV.REMARK ");
                    sbQuery.Append(" ,PV.PRJ_CODE ");
                    sbQuery.Append(" ,PV.REG_DATE ");
                    sbQuery.Append(" ,PV.REG_EMP ");
                    sbQuery.Append(" ,REG.EMP_NAME AS REG_EMP_NAME");
                    sbQuery.Append(" ,PV.MDFY_DATE ");
                    sbQuery.Append(" ,PV.MDFY_EMP ");
                    sbQuery.Append(" ,MDFY.EMP_NAME AS MDFY_EMP_NAME");
                    sbQuery.Append(" ,PV.DATA_FLAG ");
                    sbQuery.Append(" ,PV.TRADE_DATE ");
                    sbQuery.Append(" ,PV.TAX_DATE ");
                    sbQuery.Append(" ,PV.PROC_TYPE ");
                    sbQuery.Append(" ,PV.MODULE_TYPE ");
                    sbQuery.Append(" ,PV.PIN_TYPE ");
                    sbQuery.Append(" ,PV.VISION_CLAMP ");
                    sbQuery.Append(" ,PV.VISION_CONNECTOR ");
                    sbQuery.Append(" ,PV.VISION_OPEN ");
                    sbQuery.Append(" ,PV.CLAMP_DIRECTION ");
                    sbQuery.Append(" ,PV.CONNECTOR_DIRECTION ");
                    sbQuery.Append(" ,PV.OPEN_DIRECTION ");
                    sbQuery.Append(" ,PV.GND_PIN ");
                    sbQuery.Append(" ,PV.FIDUCIAL_MARK ");
                    sbQuery.Append(" ,PV.CROSS_MARKING ");
                    sbQuery.Append(" ,PV.VACUUM ");
                    sbQuery.Append(" ,PV.SOCKET_MARKING ");
                    sbQuery.Append(" ,PV.MODULE_IN_TYPE ");
                    sbQuery.Append(" ,PV.IF_PIN_BLOCK ");
                    sbQuery.Append(" ,PV.SOCKET_OPEN_DIRECTION ");
                    sbQuery.Append(" ,PV.DFM_YN ");
                    sbQuery.Append(" ,PV.MSOP_YN ");
                    sbQuery.Append(" ,CONVERT(DATETIME,PV.DFM_DATE) AS DFM_DATE ");
                    sbQuery.Append(" ,CONVERT(DATETIME,PV.MSOP_DATE) AS MSOP_DATE ");
                    sbQuery.Append(" ,CONVERT(DATETIME,PV.DRAW_DATE) AS DRAW_DATE ");
                    sbQuery.Append(" ,PV.DRAW_TYPE ");
                    sbQuery.Append(" ,PV.MODEL_TYPE ");
                    sbQuery.Append(" ,PV.VISION_TYPE ");
                    sbQuery.Append(" ,PV.VISION_DIRECTION ");
                    sbQuery.Append(" ,PV.PART_CODE ");
                    sbQuery.Append(" ,PT.PART_NAME ");
                    sbQuery.Append(" ,PV.MODEL_CODE ");
                    sbQuery.Append(" ,PV.ITEM_FLAG ");
                    sbQuery.Append(" ,PV.PROD_PRIORITY ");
                    sbQuery.Append(" ,PV.MSOP_DFM ");
                    sbQuery.Append(" ,PV.GUBUN ");

                    sbQuery.Append(" FROM TORD_PRODUCT_REV PV ");

                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE REG");
                    sbQuery.Append(" ON PV.PLT_CODE = REG.PLT_CODE");
                    sbQuery.Append(" AND PV.REG_EMP = REG.EMP_CODE");
                   
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE MDFY");
                    sbQuery.Append(" ON PV.PLT_CODE = MDFY.PLT_CODE");
                    sbQuery.Append(" AND PV.MDFY_EMP = MDFY.EMP_CODE");

                    sbQuery.Append(" LEFT JOIN TSTD_VENDOR CVND");
                    sbQuery.Append(" ON PV.PLT_CODE = CVND.PLT_CODE");
                    sbQuery.Append(" AND PV.CVND_CODE = CVND.VEN_CODE");

                    sbQuery.Append(" LEFT JOIN TSTD_BILL_VENDOR TVND");
                    sbQuery.Append(" ON PV.PLT_CODE = TVND.PLT_CODE");
                    sbQuery.Append(" AND PV.TVND_CODE = TVND.BVEN_CODE");

                    sbQuery.Append(" LEFT JOIN LSE_STD_PART PT");
                    sbQuery.Append(" ON PV.PLT_CODE = PT.PLT_CODE");
                    sbQuery.Append(" AND PV.PART_CODE = PT.PART_CODE");

                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE EMP");
                    sbQuery.Append(" ON PV.PLT_CODE = EMP.PLT_CODE");
                    sbQuery.Append(" AND PV.BUSINESS_EMP = EMP.EMP_CODE");

                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE REV");
                    sbQuery.Append(" ON PV.PLT_CODE = REV.PLT_CODE");
                    sbQuery.Append(" AND PV.REV_EMP = REV.EMP_CODE");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE PV.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_CODE", "PV.PROD_CODE = @PROD_CODE"));

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


        public static DataTable TORD_PRODUCT_REV_QUERY2(DataTable dtParam, BizExecute.BizExecute bizExecute)
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
                    sbQuery.Append(" ,CONVERT(DATETIME,P.ORD_DATE) AS ORD_DATE ");
                    sbQuery.Append(" ,CONVERT(DATETIME,P.INDUE_DATE) AS INDUE_DATE ");
                    sbQuery.Append(" ,CONVERT(DATETIME,P.DUE_DATE) AS DUE_DATE ");
                    sbQuery.Append(" ,CONVERT(DATETIME,P.CHG_DUE_DATE) AS CHG_DUE_DATE ");
                    sbQuery.Append(" ,CONVERT(DATETIME,P.DELIVERY_DATE) AS DELIVERY_DATE ");
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
                    sbQuery.Append(" ,CONVERT(DATETIME,P.MSOP_DFM_DATE) AS MSOP_DATE ");
                    sbQuery.Append(" ,CONVERT(DATETIME,P.DRAW_DATE) AS DRAW_DATE ");
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
                    sbQuery.Append(" ,CONVERT(DATETIME,P.DFM_DATE) AS DFM_DATE ");
                    sbQuery.Append(" ,P.MSOP_YN ");
                    sbQuery.Append(" ,CONVERT(DATETIME,P.MSOP_DATE) AS MSOP_DATE ");
                    sbQuery.Append(" ,P.REV_EMP ");
                    sbQuery.Append(" ,REV.EMP_NAME AS REV_NAME ");
                            
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








    }

}
