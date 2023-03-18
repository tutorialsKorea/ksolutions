using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BizExecute;
using System.Data;

namespace DORD
{
    public class TORD_SHIP
    {

        public static DataTable TORD_SHIP_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {

            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT PLT_CODE			 ");
                    sbQuery.Append(" ,SHIP_ID					 ");
                    sbQuery.Append(" ,ITEM_CODE					 ");
                    sbQuery.Append(" ,PROD_CODE					 ");
                    sbQuery.Append(" ,SHIP_DATE					 ");
                    sbQuery.Append(" ,SHIP_EMP					 ");
                    sbQuery.Append(" ,SHIP_QTY					 ");
                    sbQuery.Append(" ,SCOMMENT					 ");
                    sbQuery.Append(" ,REG_DATE					 ");
                    sbQuery.Append(" ,REG_EMP					 ");
                    sbQuery.Append(" ,DEL_DATE					 ");
                    sbQuery.Append(" ,DEL_EMP					 ");
                    sbQuery.Append(" ,DATA_FLAG					 ");
                    sbQuery.Append(" FROM TORD_SHIP				 ");
                    sbQuery.Append(" WHERE SHIP_ID = @SHIP_ID");
                    //sbQuery.Append(" AND DATA_FLAG = @DATA_FLAG	 ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "SHIP_ID")) isHasColumn = false;
                        //if (!UTIL.ValidColumn(row, "DATA_FLAG")) isHasColumn = false;

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

        public static DataTable TORD_SHIP_SER2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {

            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT PLT_CODE			 ");
                    sbQuery.Append(" ,SHIP_ID					 ");
                    sbQuery.Append(" ,ITEM_CODE					 ");
                    sbQuery.Append(" ,PROD_CODE					 ");
                    sbQuery.Append(" ,SHIP_DATE					 ");
                    sbQuery.Append(" ,SHIP_EMP					 ");
                    sbQuery.Append(" ,SHIP_QTY					 ");
                    sbQuery.Append(" ,SCOMMENT					 ");
                    sbQuery.Append(" ,SHIP_PO_NO				 ");
                    sbQuery.Append(" ,REG_DATE					 ");
                    sbQuery.Append(" ,REG_EMP					 ");
                    sbQuery.Append(" ,DEL_DATE					 ");
                    sbQuery.Append(" ,DEL_EMP					 ");
                    sbQuery.Append(" ,DATA_FLAG					 ");
                    sbQuery.Append(" FROM TORD_SHIP				 ");
                    sbQuery.Append(" WHERE PROD_CODE = @PROD_CODE");
                    sbQuery.Append(" AND DATA_FLAG = '0'");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

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

        public static void TORD_SHIP_UPD(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {

                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TORD_SHIP ");
                    sbQuery.Append(" SET   SHIP_END_DATE = @SHIP_END_DATE ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append(" AND SHIP_ID = @SHIP_ID");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "SHIP_ID")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "SHIP_END_DATE")) isHasColumn = false;


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

        public static void TORD_SHIP_UPD2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {

                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TORD_SHIP ");
                    sbQuery.Append(" SET   SHIP_DATE = @SHIP_DATE ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append(" AND SHIP_ID = @SHIP_ID");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "SHIP_ID")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "SHIP_DATE")) isHasColumn = false;


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

        public static void TORD_SHIP_UPD3(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {

                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TORD_SHIP ");
                    sbQuery.Append(" SET   SHIP_PO_NO = @SHIP_PO_NO ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append(" AND SHIP_ID = @SHIP_ID");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "SHIP_ID")) isHasColumn = false;


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

        public static void TORD_SHIP_UDE(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {

                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TORD_SHIP ");
                    sbQuery.Append(" SET   DEL_DATE = GETDATE() ");
                    sbQuery.Append(" , DEL_EMP = '" + ConnInfo.UserID + "'");
                    sbQuery.Append(" , DATA_FLAG = @DATA_FLAG ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append(" AND SHIP_ID = @SHIP_ID");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "SHIP_ID")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;

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

        public static void TORD_SHIP_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append("INSERT INTO TORD_SHIP");
                    sbQuery.Append("(");
                    sbQuery.Append("       PLT_CODE");
                    sbQuery.Append("     , SHIP_ID");
                    sbQuery.Append("     , ITEM_CODE");
                    sbQuery.Append("     , PROD_CODE");
                    sbQuery.Append("     , SHIP_DATE");
                    sbQuery.Append("     , SHIP_EMP");
                    sbQuery.Append("     , SHIP_QTY");
                    sbQuery.Append("     , DELIVERY");
                    sbQuery.Append("     , PROD_LOCATION");
                    sbQuery.Append("     , SCOMMENT");
                    sbQuery.Append("     , SHIP_PO_NO");
                    sbQuery.Append("     , REG_DATE");
                    sbQuery.Append("     , REG_EMP");
                    sbQuery.Append("     , DATA_FLAG");
                    sbQuery.Append(")");
                    sbQuery.Append("VALUES");
                    sbQuery.Append("(");
                    sbQuery.Append("       @PLT_CODE");
                    sbQuery.Append("     , @SHIP_ID");
                    sbQuery.Append("     , @ITEM_CODE");
                    sbQuery.Append("     , @PROD_CODE");
                    sbQuery.Append("     , @SHIP_DATE");
                    sbQuery.Append("     , @SHIP_EMP");
                    sbQuery.Append("     , @SHIP_QTY");
                    sbQuery.Append("     , @DELIVERY ");
                    sbQuery.Append("     , @PROD_LOCATION");
                    sbQuery.Append("     , @SCOMMENT");
                    sbQuery.Append("     , @SHIP_PO_NO");
                    sbQuery.Append(" ,GETDATE()");
                    sbQuery.Append(" ," + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append("     , 0");
                    sbQuery.Append(") ");
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

    public class TORD_SHIP_QUERY
    {
        public static DataTable TORD_SHIP_QUERY1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {


                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT SH.PLT_CODE");
                    sbQuery.Append(" ,SH.SHIP_ID");
                    sbQuery.Append(" ,SH.PROD_CODE");
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

                    sbQuery.Append(" ,P.PROD_QTY ");
                    sbQuery.Append(" ,(P.PROD_QTY - ISNULL(SHS.SHIP_QTY,0)) AS REMAIN_QTY");
                    sbQuery.Append(" ,SH.SHIP_QTY ");
                    sbQuery.Append(" ,SH.PROD_LOCATION");
                    sbQuery.Append(" ,SH.SHIP_DATE");
                    sbQuery.Append(" ,SH.SHIP_EMP");
                    sbQuery.Append(" ,SH.SHIP_PO_NO");
                    sbQuery.Append(" ,SH.SCOMMENT AS SHIP_SCOMMENT");
                    sbQuery.Append(" ,P.SCOMMENT");
                    sbQuery.Append(" ,P.REMARK");
                    sbQuery.Append(" ,P.REG_DATE");
                    sbQuery.Append(" ,P.REG_EMP");
                    sbQuery.Append(" ,REG.EMP_NAME AS REG_EMP_NAME");
                    sbQuery.Append(" ,P.MDFY_DATE");
                    sbQuery.Append(" ,P.MDFY_EMP");
                    sbQuery.Append(" ,MDFY.EMP_NAME AS MDFY_EMP_NAME");
                    sbQuery.Append(" ,P.MNG_EMP1");
                    sbQuery.Append(" ,P.MNG_EMP2");



                    sbQuery.Append(" ,P.PROC_TYPE");
                    sbQuery.Append(" ,P.TAX_DATE");
                    sbQuery.Append(" ,P.TRADE_DATE");
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
                    
                    
                    
                    sbQuery.Append(" ,P.PO_NO ");
                    sbQuery.Append(" ,P.BALJU_TYPE ");
                    sbQuery.Append(" ,P.DEV_EMP  ");
                    sbQuery.Append(" ,P.DES_DATE  ");
                    //sbQuery.Append(" ,PR.DESIGN_DATE ");

                    sbQuery.Append(" ,SH.SHIP_END_DATE ");

                    sbQuery.Append(" ,CASE WHEN P.COL_DATE IS NULL THEN 'X' ELSE 'O' END AS IS_COL");

                    sbQuery.Append(" ,P.EST_COST  ");

                    sbQuery.Append(" FROM TORD_SHIP SH");
                    sbQuery.Append(" LEFT JOIN TORD_PRODUCT P");
                    sbQuery.Append(" ON P.PLT_CODE = SH.PLT_CODE");
                    sbQuery.Append(" AND P.PROD_CODE = SH.PROD_CODE");                    
                    
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
                    
                    sbQuery.Append(" LEFT JOIN (SELECT PLT_CODE,PROD_CODE, SUM(ISNULL(SHIP_QTY,0)) AS SHIP_QTY FROM TORD_SHIP WHERE DATA_FLAG = 0 GROUP BY PLT_CODE,PROD_CODE) SHS");
                    sbQuery.Append(" ON P.PLT_CODE = SHS.PLT_CODE");
                    sbQuery.Append(" AND P.PROD_CODE = SHS.PROD_CODE");
                    
                    //sbQuery.Append(" LEFT JOIN (SELECT PLT_CODE, PROD_CODE, MIN(REG_DATE) AS DESIGN_DATE FROM TMAT_PARTLIST WHERE DATA_FLAG = 0 GROUP BY PLT_CODE, PROD_CODE) PR");
                    //sbQuery.Append(" ON P.PLT_CODE = PR.PLT_CODE ");
                    //sbQuery.Append(" AND P.PROD_CODE = PR.PROD_CODE ");

                    sbQuery.Append(" LEFT JOIN LSE_STD_PART PT");
                    sbQuery.Append(" ON P.PLT_CODE = PT.PLT_CODE");
                    sbQuery.Append(" AND P.PART_CODE = PT.PART_CODE");

                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE REV");
                    sbQuery.Append(" ON P.PLT_CODE = REV.PLT_CODE");
                    sbQuery.Append(" AND P.REV_EMP = REV.EMP_CODE");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE SH.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_CODE", "SH.PROD_CODE = @PROD_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@SHIP_ID", "SH.SHIP_ID = @SHIP_ID"));

                        sbWhere.Append(UTIL.GetWhere(row, "@S_REG_DATE, @E_REG_DATE", "(CONVERT(nvarchar(8),P.REG_DATE,112) BETWEEN @S_REG_DATE AND @E_REG_DATE)"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_ORD_DATE, @E_ORD_DATE", "(P.ORD_DATE BETWEEN @S_ORD_DATE AND @E_ORD_DATE)"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_DUE_DATE, @E_DUE_DATE", "(P.DUE_DATE BETWEEN @S_DUE_DATE AND @E_DUE_DATE)"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_DELIVERY_DATE, @E_DELIVERY_DATE", "(P.DELIVERY_DATE BETWEEN @S_DELIVERY_DATE AND @E_DELIVERY_DATE)"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_SHIP_DATE, @E_SHIP_DATE", "(SH.SHIP_DATE BETWEEN @S_SHIP_DATE AND @E_SHIP_DATE)"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_LIKE", "P.PROD_CODE LIKE '%' + @PROD_LIKE + '%' OR P.PROD_NAME LIKE '%' + @PROD_LIKE + '%'"));
                        sbWhere.Append(UTIL.GetWhere(row, "@CVND_LIKE", "P.CVND_CODE LIKE '%' + @CVND_LIKE + '%' OR CVND.VEN_NAME LIKE '%' + @CVND_LIKE + '%'"));
                        sbWhere.Append(UTIL.GetWhere(row, "@BUSINESS_EMP", "P.BUSINESS_EMP = @BUSINESS_EMP"));
                        sbWhere.Append(UTIL.GetWhere(row, "@SHIP_FLAG", "P.SHIP_FLAG = @SHIP_FLAG"));
                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "P.DATA_FLAG = @DATA_FLAG"));
                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "SH.DATA_FLAG = @DATA_FLAG"));


                        //sbWhere.Append(" AND (P.PROD_QTY - ISNULL(SH.SHIP_QTY,0)) > 0");

                        sbWhere.Append(" ORDER BY P.PROD_CODE,SH.SHIP_ID ");

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

        public static DataTable TORD_SHIP_QUERY5(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {


                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT 		");
                    sbQuery.Append(" PLT_CODE		");
                    sbQuery.Append(" ,ITEM_CODE		");
                    sbQuery.Append(" ,PROD_CODE     ");
                    sbQuery.Append(" ,SUM(SHIP_QTY) AS SHIP_QTY	");
                    sbQuery.Append(" FROM TORD_SHIP	");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@ITEM_CODE", "ITEM_CODE = @ITEM_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_CODE", "PROD_CODE = @PROD_CODE"));
                       
                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "DATA_FLAG = @DATA_FLAG"));

                        sbWhere.Append(" GROUP BY PLT_CODE, ITEM_CODE, PROD_CODE ");

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
       

        //출하 취소 조회
        public static DataTable TORD_SHIP_QUERY9(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {


                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT							");
                    sbQuery.Append(" TS.PLT_CODE,					");
                    sbQuery.Append(" TS.SHIP_ID,					");
                    sbQuery.Append(" TS.SHIP_DATE,					");
                    sbQuery.Append(" TS.SHIP_DATE AS DATE,			");
                    sbQuery.Append(" TS.SHIP_EMP,					");
                    sbQuery.Append(" E.EMP_NAME AS SHIP_EMP_NAME,	");
                    sbQuery.Append(" TS.SHIP_QTY,					");
                    sbQuery.Append(" TS.SHIP_QTY AS QTY,			");
                    sbQuery.Append(" TS.DELIVERY,			");

                    sbQuery.Append(" ISNULL(TS.SHIP_QTY * (TP.PROD_UC + TP.PROD_VAT),0) AS SHIP_COST ,");
                    sbQuery.Append(" ISNULL(TS.SHIP_QTY * (TP.PROD_UC),0) AS SHIP_COST2 ,");
                    sbQuery.Append(" TS.SCOMMENT,					");
                    sbQuery.Append(" TS.REG_DATE,					");
                    sbQuery.Append(" TS.REG_EMP,					");
                    sbQuery.Append(" TP.ITEM_CODE,					");
                    sbQuery.Append(" A.ITEM_NAME,					");
                    sbQuery.Append(" TP.PROD_CODE,					");
                    sbQuery.Append(" SP.MAT_TYPE,					");
                    sbQuery.Append(" TP.PART_CODE,					");
                    sbQuery.Append(" SP.PART_NAME,					");
                    sbQuery.Append(" SP.MAT_SPEC,					");
                    sbQuery.Append(" SP.MAT_SPEC1,					");
                    sbQuery.Append(" SP.MAT_SPEC1 AS B_MAT_SPEC,    ");
                    sbQuery.Append(" SP.MAT_WEIGHT,					");
                    sbQuery.Append(" SP.MAT_UNIT,					");
                    sbQuery.Append(" SP.DRAW_NO,					");
                    sbQuery.Append(" TP.PROD_UC AS UNIT_COST,");
                    sbQuery.Append(" TP.PROD_QTY AS PART_QTY,");
                    sbQuery.Append(" TS.SHIP_QTY * TP.PROD_UC AS AMT,");
                    sbQuery.Append(" CASE WHEN A.ORD_VAT = '1' THEN TS.SHIP_QTY * (TP.PROD_UC / 10) ELSE 0 END AS PROD_VAT,");
                    sbQuery.Append(" A.CVND_CODE,					");
                    sbQuery.Append(" B.VEN_NAME AS CVND_NAME,		");
                    sbQuery.Append(" A.CVND_CODE AS VEN_CODE,   	");
                    sbQuery.Append(" B.VEN_NAME,            		");
                    sbQuery.Append(" A.ORD_DATE AS ITEM_ORD_DATE,					");
                    sbQuery.Append(" TP.ORD_DATE,					");
                    sbQuery.Append(" TP.DUE_DATE,					");
                    sbQuery.Append(" A.BALJU_NUM,	  ");
                    sbQuery.Append(" A.SCOMMENT AS ITEM_SCOMMENT	  ");

                    sbQuery.Append(" ,B.VEN_BIZ_NO	  ");
                    sbQuery.Append(" ,B.VEN_ADDRESS	  ");
                    sbQuery.Append(" ,B.VEN_TEL		  ");
                    sbQuery.Append(" ,B.VEN_FAX		  ");
                    sbQuery.Append(" ,B.VEN_CEO		  ");
                    sbQuery.Append(" ,B.VEN_CONDITIONS");
                    sbQuery.Append(" ,B.VEN_PRODUCTS  ");
                    sbQuery.Append(" ,B.VEN_EMAIL	  ");
                    sbQuery.Append(" ,B.VEN_CHARGE_EMP	  ");
                    sbQuery.Append(" ,B.VEN_CHARGE_TEL	  ");
                    sbQuery.Append(" ,B.VEN_CHARGE_HP	  ");
                    sbQuery.Append(" ,B.VEN_ADDRESS3	  ");

                    sbQuery.Append(" FROM TORD_SHIP TS				");
                    sbQuery.Append(" LEFT JOIN TORD_PRODUCT TP		");
                    sbQuery.Append(" ON TS.PLT_CODE = TP.PLT_CODE	");
                    sbQuery.Append(" AND TS.PROD_CODE = TP.PROD_CODE");
                    sbQuery.Append(" AND TP.PARENT_PART IS NULL		");
                    sbQuery.Append(" 								");
                    sbQuery.Append(" LEFT JOIN LSE_STD_PART SP		");
                    sbQuery.Append(" ON TP.PLT_CODE = SP.PLT_CODE	");
                    sbQuery.Append(" AND TP.PART_CODE = SP.PART_CODE");
                    sbQuery.Append(" 								");
                    sbQuery.Append(" LEFT JOIN TORD_ITEM A			");
                    sbQuery.Append(" ON TP.PLT_CODE = A.PLT_CODE 	");
                    sbQuery.Append(" AND TP.ITEM_CODE = A.ITEM_CODE	");
                    sbQuery.Append(" 								");
                    sbQuery.Append(" LEFT JOIN TSTD_VENDOR B		");
                    sbQuery.Append(" ON A.PLT_CODE = B.PLT_CODE 	");
                    sbQuery.Append(" AND A.CVND_CODE = B.VEN_CODE	");
                    sbQuery.Append(" 								");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE E 		");
                    sbQuery.Append(" ON E.PLT_CODE = TS.PLT_CODE 	");
                    sbQuery.Append(" AND E.EMP_CODE = TS.SHIP_EMP	");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE TS.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(" AND TP.PROD_STATE IN ('PG', 'SH') ");

                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "TS.DATA_FLAG = @DATA_FLAG"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_ORD_DATE, @E_ORD_DATE", "TP.ORD_DATE BETWEEN @S_ORD_DATE AND @E_ORD_DATE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_DUE_DATE, @E_DUE_DATE", "TP.DUE_DATE BETWEEN @S_DUE_DATE AND @E_DUE_DATE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_SHIP_DATE, @E_SHIP_DATE", "TS.SHIP_DATE BETWEEN @S_SHIP_DATE AND @E_SHIP_DATE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_STATE", "TP.PROD_STATE = @PROD_STATE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@CVND_CODE", "A.CVND_CODE = @CVND_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@ITEM_CODE", "A.ITEM_CODE = @ITEM_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@YEAR", "LEFT(TS.SHIP_DATE,4) = @YEAR"));

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

        //매출장 - 거래처 조회
        public static DataTable TORD_SHIP_QUERY10(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {


                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT							");
                    sbQuery.Append(" TS.PLT_CODE,		");
                    sbQuery.Append(" A.CVND_CODE AS VEN_CODE,		");
                    sbQuery.Append(" B.VEN_NAME");
                    
                    sbQuery.Append(" FROM TORD_SHIP TS				");
                    sbQuery.Append("  JOIN TORD_PRODUCT TP		");
                    sbQuery.Append(" ON TS.PLT_CODE = TP.PLT_CODE	");
                    sbQuery.Append(" AND TS.PROD_CODE = TP.PROD_CODE");
                    sbQuery.Append(" AND TP.PARENT_PART IS NULL		");
                    
                    sbQuery.Append(" LEFT JOIN TORD_ITEM A			");
                    sbQuery.Append(" ON TP.PLT_CODE = A.PLT_CODE 	");
                    sbQuery.Append(" AND TP.ITEM_CODE = A.ITEM_CODE	");
                    
                    sbQuery.Append(" LEFT JOIN TSTD_VENDOR B		");
                    sbQuery.Append(" ON A.PLT_CODE = B.PLT_CODE 	");
                    sbQuery.Append(" AND A.CVND_CODE = B.VEN_CODE	");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE TS.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(" AND TP.PROD_STATE IN ('PG', 'SH') ");

                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "TS.DATA_FLAG = @DATA_FLAG"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_ORD_DATE, @E_ORD_DATE", "TP.ORD_DATE BETWEEN @S_ORD_DATE AND @E_ORD_DATE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_DUE_DATE, @E_DUE_DATE", "TP.DUE_DATE BETWEEN @S_DUE_DATE AND @E_DUE_DATE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_SHIP_DATE, @E_SHIP_DATE", "TS.SHIP_DATE BETWEEN @S_SHIP_DATE AND @E_SHIP_DATE"));
                        
                        sbWhere.Append(UTIL.GetWhere(row, "@CVND_CODE", "A.CVND_CODE = @CVND_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@ITEM_CODE", "A.ITEM_CODE = @ITEM_CODE"));

                        sbWhere.Append(" GROUP BY TS.PLT_CODE, A.CVND_CODE, B.VEN_NAME");

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

        public static DataTable TORD_SHIP_QUERY11(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {


                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT 		");
                    sbQuery.Append(" PLT_CODE		");
                    sbQuery.Append(" , SUBSTRING(SHIP_DATE,5,2) as MONTH       ");
                    sbQuery.Append(" , SHIP_QTY       ");
                    sbQuery.Append(" FROM TORD_SHIP	");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@YEAR", "LEFT(SHIP_DATE,4) = @YEAR"));
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


        public static DataTable TORD_SHIP_QUERY12(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {


                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT 		");
                    sbQuery.Append(" PLT_CODE		");
                    sbQuery.Append(" , SUBSTRING(SHIP_DATE,5,2) as MONTH       ");
                    sbQuery.Append(" , SHIP_QTY       ");
                    sbQuery.Append(" FROM TORD_SHIP	");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@YEAR", "LEFT(SHIP_DATE,4) = (@YEAR-1)"));
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

        public static DataTable TORD_SHIP_QUERY13(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {

            try
            {


                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT TS.PLT_CODE						   ");
                    sbQuery.Append(" 	 , TI.ITEM_CODE						   ");
                    sbQuery.Append(" 	 , TP.PROD_CODE						   ");
                    sbQuery.Append(" 	 , TP.PART_CODE					   ");
                    sbQuery.Append(" 	 , LSP.PART_NAME					   ");
                    sbQuery.Append(" 	 , LSP.MAT_SPEC1					   ");
                    sbQuery.Append(" 	 , TI.CVND_CODE						   ");
                    sbQuery.Append(" 	 , VEN.VEN_NAME AS CVND_NAME		   ");
                    sbQuery.Append(" 	 , TS.SHIP_DATE						   ");
                    sbQuery.Append(" 	 , TP.PROD_QTY AS PART_QTY			   ");
                    sbQuery.Append(" 	 , TS.SHIP_QTY						   ");
                    sbQuery.Append(" 	 , CODE.CD_NAME						   ");
                    sbQuery.Append(" FROM TORD_SHIP TS						   ");
                    sbQuery.Append(" 	INNER JOIN TORD_PRODUCT TP			   ");
                    sbQuery.Append(" 		ON TS.PLT_CODE = TP.PLT_CODE 	   ");
                    sbQuery.Append(" 		AND TS.PROD_CODE = TP.PROD_CODE	   ");
                    sbQuery.Append(" 		AND TS.DATA_FLAG = TP.DATA_FLAG	   ");
                    sbQuery.Append(" 		AND TP.PARENT_PART IS NULL		   ");
                    sbQuery.Append(" 	INNER JOIN TORD_ITEM TI				   ");
                    sbQuery.Append(" 		ON TP.PLT_CODE = TI.PLT_CODE	   ");
                    sbQuery.Append(" 		AND TP.ITEM_CODE = TI.ITEM_CODE	   ");
                    sbQuery.Append(" 		AND TP.DATA_FLAG = TI.DATA_FLAG	   ");
                    sbQuery.Append(" 	INNER JOIN (SELECT SG.PLT_CODE,SG.STK_GROUP,TP.PROD_CODE		   ");
                    sbQuery.Append(" 			     FROM TSTD_STOCK_GRP SG              ");
                    sbQuery.Append(" 			   	INNER JOIN TORD_PRODUCT TP              ");
                    sbQuery.Append(" 			   		ON SG.PLT_CODE = TP.PLT_CODE              ");
                    sbQuery.Append(" 			   		AND SG.PART_CODE = TP.PART_CODE              ");
                    sbQuery.Append(" 			   GROUP BY SG.PLT_CODE,SG.STK_GROUP,TP.PROD_CODE) TSG              ");
                    sbQuery.Append(" 		ON TP.PLT_CODE = TSG.PLT_CODE	   ");
                    sbQuery.Append(" 		AND TP.PROD_CODE = TSG.PROD_CODE   ");
                    sbQuery.Append(" 	LEFT JOIN LSE_STD_PART LSP			   ");
                    sbQuery.Append(" 		ON TP.PLT_CODE = LSP.PLT_CODE	   ");
                    sbQuery.Append(" 		AND TP.PART_CODE = LSP.PART_CODE  ");
                    sbQuery.Append(" 	LEFT JOIN TSTD_VENDOR VEN			   ");
                    sbQuery.Append(" 		ON TI.PLT_CODE = VEN.PLT_CODE	   ");
                    sbQuery.Append(" 		AND TI.CVND_CODE = VEN.VEN_CODE	   ");
                    sbQuery.Append(" 	LEFT JOIN TSTD_CODES CODE			   ");
                    sbQuery.Append(" 		ON LSP.PLT_CODE = CODE.PLT_CODE	   ");
                    sbQuery.Append(" 		AND LSP.MAT_MTYPE = CODE.CD_CODE	   ");
                    sbQuery.Append(" 		AND CODE.CAT_CODE = 'M002'	   ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE TS.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                        sbWhere.Append(UTIL.GetWhere(row, "@S_REG_DATE,@E_REG_DATE", "TS.REG_DATE BETWEEN @S_REG_DATE AND @E_REG_DATE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_DATE,@E_DATE", "TS.SHIP_DATE BETWEEN @S_DATE AND @E_DATE"));
                        //sbWhere.Append(UTIL.GetWhere(row, "@MAT_TYPE", "LSP.MAT_TYPE IN @MAT_TYPE", UTIL.SqlCondType.IN));
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_LIKE", "(LSP.PART_CODE LIKE '%' + @PART_LIKE + '%' OR LSP.PART_NAME LIKE '%' + @PART_LIKE + '%')"));
                        sbWhere.Append(UTIL.GetWhere(row, "@MAT_LTYPE", "LSP.MAT_LTYPE = @MAT_LTYPE "));
                        sbWhere.Append(UTIL.GetWhere(row, "@MAT_MTYPE", "LSP.MAT_MTYPE = @MAT_MTYPE "));
                        sbWhere.Append(UTIL.GetWhere(row, "@MAT_STYPE", "LSP.MAT_STYPE = @MAT_STYPE "));
                        sbWhere.Append(UTIL.GetWhere(row, "@STK_GROUP", "TSG.STK_GROUP = @STK_GROUP "));
                        sbWhere.Append(UTIL.GetWhere(row, "@STK_GROUP_NAME", "CODE.CD_NAME LIKE '%' + @STK_GROUP_NAME + '%'"));

                        sbWhere.Append(" AND TS.DATA_FLAG = 0");

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

        public static DataTable TORD_SHIP_QUERY14(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {


                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT COUNT(PROD_CODE) AS PROD_CNT FROM");
                    sbQuery.Append(" (");
                    sbQuery.Append(" SELECT PLT_CODE, PROD_CODE, SHIP_DATE FROM TORD_SHIP");
                    sbQuery.Append(" WHERE LEFT(SHIP_DATE, 6) = @S_MONTH");
                    sbQuery.Append(" GROUP BY PLT_CODE, PROD_CODE, SHIP_DATE");
                    sbQuery.Append(" ) A");


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
