using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace DOUT
{
    public class TOUT_PROCYPGO
    {
        //입고번호에 따른 입고수량 , 검사불량수량 확인
        public static DataTable TOUT_PROCYPGO_SER2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {

            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT    ");
                    sbQuery.Append(" Y.PLT_CODE ");
                    sbQuery.Append(" ,Y.YPGO_ID     ");
                    sbQuery.Append(" ,Y.QTY AS YPGO_QTY ");
                    sbQuery.Append(" ,ISNULL((SELECT SUM(QTY) FROM TQCT_PURCHASE_NG ");
                    sbQuery.Append(" WHERE PLT_CODE = Y.PLT_CODE AND YPGO_ID = Y.YPGO_ID AND DATA_FLAG = 0 ");
                    sbQuery.Append(" GROUP BY PLT_CODE , YPGO_ID ");
                    sbQuery.Append(" ),0) AS NG_QTY ");
                    sbQuery.Append(" FROM TOUT_PROCYPGO Y ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append(" AND YPGO_ID = @YPGO_ID ");



                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "YPGO_ID")) isHasColumn = false;

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

        public static void TOUT_PROCYPGO_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" INSERT INTO TOUT_PROCYPGO ");
                    sbQuery.Append(" ( ");
                    sbQuery.Append("        PLT_CODE ");
                    sbQuery.Append("      , YPGO_ID ");
                    sbQuery.Append("      , BALJU_NUM ");
                    sbQuery.Append("      , BALJU_SEQ ");
                    sbQuery.Append("      , YPGO_DATE ");
                    sbQuery.Append("      , CLOSE_DATE ");
                    sbQuery.Append("      , QTY ");
                    sbQuery.Append("      , UNIT_COST ");
                    sbQuery.Append("      , AMT ");
                    sbQuery.Append("      , YPGO_STAT ");
                    sbQuery.Append("      , INS_FLAG ");
                    sbQuery.Append("      , INS_DATE ");
                    sbQuery.Append("      , INS_EMP ");
                    sbQuery.Append("      , EX_RATE ");
                    sbQuery.Append("      , SCOMMENT ");
                    sbQuery.Append("      , YPGO_LOC ");
                    sbQuery.Append("      , REG_DATE ");
                    sbQuery.Append("      , REG_EMP ");
                    sbQuery.Append(" ) ");
                    sbQuery.Append(" VALUES ");
                    sbQuery.Append(" ( ");
                    sbQuery.Append("        @PLT_CODE ");
                    sbQuery.Append("      , @YPGO_ID ");
                    sbQuery.Append("      , @BALJU_NUM ");
                    sbQuery.Append("      , @BALJU_SEQ ");
                    sbQuery.Append("      , @YPGO_DATE ");
                    sbQuery.Append("      , @CLOSE_DATE ");
                    sbQuery.Append("      , @QTY ");
                    sbQuery.Append("      , @UNIT_COST ");
                    sbQuery.Append("      , @AMT ");
                    sbQuery.Append("      , @YPGO_STAT ");
                    sbQuery.Append("      , @INS_FLAG ");
                    sbQuery.Append("      , @INS_DATE ");
                    sbQuery.Append("      , @INS_EMP ");
                    sbQuery.Append("      , @EX_RATE ");
                    sbQuery.Append("      , @SCOMMENT ");
                    sbQuery.Append("      , @YPGO_LOC ");
                    sbQuery.Append(" , GETDATE()		");
                    sbQuery.Append(" ," + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" )					");

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

        //공정외주 취소사유
        public static void TOUT_PROCYPGO_UPD5(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TOUT_PROCYPGO ");
                    sbQuery.Append("    SET   YPGO_STAT = @YPGO_STAT ");
                    sbQuery.Append("        , C_REASON = @C_REASON ");
                    sbQuery.Append("        , MDFY_DATE =  GETDATE() ");
                    sbQuery.Append("        , MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("    AND YPGO_ID = @YPGO_ID ");


                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "YPGO_ID")) isHasColumn = false;

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

        public static void TOUT_PROCYPGO_UPD6(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TOUT_PROCYPGO ");
                    sbQuery.Append("    SET   YPGO_DATE = @YPGO_DATE ");
                    sbQuery.Append("        , MDFY_DATE =  GETDATE() ");
                    sbQuery.Append("        , MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("    AND YPGO_ID = @YPGO_ID ");


                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "YPGO_ID")) isHasColumn = false;

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

        public static void TOUT_PROCYPGO_UPD7(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TOUT_PROCYPGO SET  ");
                    sbQuery.Append(" CHECK_FLAG = @CHECK_FLAG ");
                    sbQuery.Append(" ,CHECK_EMP = @CHECK_EMP ");
                    sbQuery.Append(" ,CHECK_DATE = @CHECK_DATE ");
                    sbQuery.Append(" ,CHECK_DEL_EMP = @CHECK_DEL_EMP ");
                    sbQuery.Append(" ,CHECK_DEL_DATE = @CHECK_DEL_DATE ");
                    sbQuery.Append(" ,MDFY_DATE = GETDATE() ");
                    sbQuery.Append(" ,MDFY_EMP = '" + ConnInfo.UserID + "'");
                    //sbQuery.Append(" ,DATA_FLAG = @DATA_FLAG ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append("  AND YPGO_ID = @YPGO_ID ");


                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "YPGO_ID")) isHasColumn = false;

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

        public static void TOUT_PROCYPGO_UPD(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    
                    sbQuery.Append(" UPDATE TOUT_PROCYPGO ");
                    sbQuery.Append("    SET   UNIT_COST = @UNIT_COST ");
                    sbQuery.Append("        , QTY = @QTY ");
                    sbQuery.Append("        , AMT = @AMT ");
                    sbQuery.Append("        , YPGO_DATE = @YPGO_DATE ");
                    sbQuery.Append("        , CLOSE_DATE = @CLOSE_DATE ");
                    sbQuery.Append("        , CLOSE_SCOMMENT = @CLOSE_SCOMMENT ");
                    sbQuery.Append("        , MDFY_DATE =  GETDATE() ");
                    sbQuery.Append("        , MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("    AND YPGO_ID = @YPGO_ID ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "YPGO_ID")) isHasColumn = false;

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

        public static void TOUT_PROCYPGO_UPD2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TOUT_PROCYPGO ");
                    sbQuery.Append("    SET   CLOSE_DATE = @CLOSE_DATE ");
                    sbQuery.Append("        , MDFY_DATE =  GETDATE() ");
                    sbQuery.Append("        , MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("    AND YPGO_ID = @YPGO_ID ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "YPGO_ID")) isHasColumn = false;

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

    public class TOUT_PROCYPGO_QUERY
    {
        public static DataTable TOUT_PROCYPGO_QUERY1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT  ");
                    sbQuery.Append(" B.PLT_CODE ");
                    sbQuery.Append(" ,Y.YPGO_ID ");
                    sbQuery.Append(" ,B.WO_NO ");
                    sbQuery.Append(" ,B.BALJU_NUM ");
                    sbQuery.Append(" ,B.BALJU_NUM AS GROUP_BALJU_NUM ");
                    sbQuery.Append(" ,B.BALJU_SEQ ");
                    sbQuery.Append(" ,B.BAL_STAT ");
                    sbQuery.Append(" ,Y.YPGO_STAT ");
                    sbQuery.Append(" ,BM.BALJU_DATE ");
                    sbQuery.Append(" ,B.DUE_DATE ");
                    sbQuery.Append(" ,Y.YPGO_DATE ");
                    sbQuery.Append(" ,Y.CLOSE_DATE ");

                    sbQuery.Append(" ,BM.OVND_CODE AS VEN_CODE ");
                    sbQuery.Append(" ,W.PROD_CODE ");
                    sbQuery.Append(" ,W.PART_CODE ");
                    sbQuery.Append(" ,SP.PART_NAME ");
                    sbQuery.Append(" ,SP.PART_NAME AS PART_NAME2 ");
                    sbQuery.Append(" ,SP.MAT_LTYPE ");
                    sbQuery.Append(" ,SP.MAT_MTYPE ");
                    sbQuery.Append(" ,SP.MAT_STYPE ");
                    sbQuery.Append(" ,SP.MAT_UNIT ");
                    sbQuery.Append(" ,B.INS_FLAG ");
                    sbQuery.Append(" ,SP.MAT_SPEC  ");
                    
                    sbQuery.Append(" ,W.PROC_CODE ");
                    sbQuery.Append(" ,B.QTY AS BAL_QTY ");
                    sbQuery.Append(" ,Y.QTY AS YPGO_QTY");
                    sbQuery.Append(" ,B.UNIT_COST ");
                    sbQuery.Append(" ,Y.UNIT_COST AS YPGO_COST");
                    sbQuery.Append(" ,Y.UNIT_COST * Y.QTY AS AMT ");
                    //sbQuery.Append(" ,Y.INS_FLAG ");
                    sbQuery.Append(" ,Y.INS_DATE ");
                    sbQuery.Append(" ,Y.INS_EMP ");
                    sbQuery.Append(" ,B.REG_EMP AS BALJU_REG_EMP ");
                    sbQuery.Append(" ,Y.REG_EMP ");
                    sbQuery.Append(" ,Y.YPGO_LOC ");
                    sbQuery.Append(" ,'PO' AS BAL_FLAG");
                    sbQuery.Append(" ,B.BAL_UNIT");

                    sbQuery.Append(" ,B.SCOMMENT AS BALJU_SCOMMENT");
                    sbQuery.Append(" ,Y.SCOMMENT AS YPGO_SCOMMENT");
                    sbQuery.Append(" ,Y.CLOSE_SCOMMENT");


                    sbQuery.Append(" ,ISNULL(Y.CHECK_FLAG, '0') AS CHECK_FLAG ");
                    sbQuery.Append(" ,Y.CHECK_EMP ");
                    sbQuery.Append(" ,CHK.EMP_NAME AS CHECK_EMP_NAME ");
                    sbQuery.Append(" ,Y.CHECK_DATE ");
                    sbQuery.Append(" ,Y.CHECK_DEL_EMP ");
                    sbQuery.Append(" ,CHKD.EMP_NAME AS CHECK_DEL_EMP_NAME ");
                    sbQuery.Append(" ,Y.CHECK_DEL_DATE ");


                    sbQuery.Append(" ,SPR.PROC_NAME");
                    sbQuery.Append(" ,PT.DRAW_NO");

                    sbQuery.Append(" FROM TOUT_PROCYPGO Y ");
                    sbQuery.Append(" LEFT JOIN TOUT_PROCBALJU B ");
                    sbQuery.Append(" ON Y.PLT_CODE = B.PLT_CODE ");
                    sbQuery.Append(" AND Y.BALJU_NUM = B.BALJU_NUM ");
                    sbQuery.Append(" AND Y.BALJU_SEQ = B.BALJU_SEQ ");

                    sbQuery.Append(" JOIN TOUT_PROCBALJU_MASTER BM ");
                    sbQuery.Append(" ON B.PLT_CODE = BM.PLT_CODE ");
                    sbQuery.Append(" AND B.BALJU_NUM = BM.BALJU_NUM ");

                    
                    sbQuery.Append(" LEFT JOIN TSHP_WORKORDER W ");
                    sbQuery.Append(" ON B.PLT_CODE = W.PLT_CODE ");
                    sbQuery.Append(" AND B.WO_NO = W.WO_NO ");

                    sbQuery.Append(" LEFT JOIN TMAT_PARTLIST PT ");
                    sbQuery.Append(" ON W.PLT_CODE = PT.PLT_CODE ");
                    sbQuery.Append(" AND W.PT_ID = PT.PT_ID ");

                    sbQuery.Append(" LEFT JOIN LSE_STD_PART SP ");
                    sbQuery.Append(" ON W.PLT_CODE = SP.PLT_CODE ");
                    sbQuery.Append(" AND W.PART_CODE = SP.PART_CODE ");

                    sbQuery.Append(" LEFT JOIN LSE_STD_PROC SPR ");
                    sbQuery.Append(" ON W.PLT_CODE = SPR.PLT_CODE ");
                    sbQuery.Append(" AND W.PROC_CODE = SPR.PROC_CODE ");

                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE CHK");
                    sbQuery.Append(" ON Y.PLT_CODE = CHK.PLT_CODE");
                    sbQuery.Append(" AND Y.CHECK_EMP = CHK.EMP_CODE");

                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE CHKD");
                    sbQuery.Append(" ON Y.PLT_CODE = CHKD.PLT_CODE");
                    sbQuery.Append(" AND Y.CHECK_DEL_EMP = CHKD.EMP_CODE");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE Y.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@BALJU_NUM", " B.BALJU_NUM = @BALJU_NUM "));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_BALJU_DATE, @E_BALJU_DATE", " (BM.BALJU_DATE BETWEEN @S_BALJU_DATE AND @E_BALJU_DATE) "));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_DUE_DATE, @E_DUE_DATE", "  (B.DUE_DATE BETWEEN @S_DUE_DATE AND @E_DUE_DATE) "));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_YPGO_DATE, @E_YPGO_DATE", " (Y.YPGO_DATE BETWEEN @S_YPGO_DATE AND @E_YPGO_DATE) "));

                        sbWhere.Append(UTIL.GetWhere(row, "@BALJU_NUM_LIKE", "Y.BALJU_NUM LIKE '%' + @BALJU_NUM_LIKE + '%'"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_LIKE", "(B.PART_CODE LIKE '%' + @PART_LIKE + '%' OR SP.PART_NAME LIKE '%' + @PART_LIKE + '%')"));
                        sbWhere.Append(UTIL.GetWhere(row, "@MAT_LTYPE", " SP.MAT_LTYPE = @MAT_LTYPE "));
                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_CODE", " P.PROD_CODE = @PROD_CODE "));
                        sbWhere.Append(UTIL.GetWhere(row, "@ITEM_CODE", " I.ITEM_CODE = @ITEM_CODE "));
                        sbWhere.Append(UTIL.GetWhere(row, "@OVND_CODE", " BM.OVND_CODE = @OVND_CODE "));
                        sbWhere.Append(UTIL.GetWhere(row, "@REG_EMP", " Y.REG_EMP = @REG_EMP "));
                        sbWhere.Append(UTIL.GetWhere(row, "@YPGO_ID", " Y.YPGO_ID = @YPGO_ID "));

                        sbWhere.Append(" AND Y.YPGO_STAT IN ('19','24','25') "); // AND B.BAL_STAT IN ('20','21','22')");

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

        //공정외주 입고취소 조회
        public static DataTable TOUT_PROCYPGO_QUERY2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT  ");
                    sbQuery.Append(" B.PLT_CODE ");
                    sbQuery.Append(" ,Y.YPGO_ID ");
                    sbQuery.Append(" ,Y.TYP_ID ");
                    sbQuery.Append(" ,TYP.TYP_LOC AS YPGO_LOC ");
                    sbQuery.Append(" ,TYP.TYP_LOC_DETAIL AS YPGO_LOC_DETAIL ");
                    sbQuery.Append(" ,B.REQUEST_NO ");
                    sbQuery.Append(" ,B.REQUEST_SEQ ");
                    sbQuery.Append(" ,R.WO_NO ");
                    sbQuery.Append(" ,B.BALJU_NUM ");
                    sbQuery.Append(" ,B.BALJU_SEQ ");
                    sbQuery.Append(" ,B.BAL_STAT ");
                    sbQuery.Append(" ,Y.YPGO_STAT ");
                    sbQuery.Append(" ,BM.BALJU_DATE ");
                    sbQuery.Append(" ,B.DUE_DATE ");
                    sbQuery.Append(" ,Y.YPGO_DATE ");
                    sbQuery.Append(" ,Y.YPGO_DATE AS DATE ");
                    sbQuery.Append(" ,Y.CLOSE_DATE ");
                    sbQuery.Append(" ,BM.OVND_CODE AS VEN_CODE ");
                    sbQuery.Append(" ,V.VEN_NAME ");
                    sbQuery.Append(" ,I.ITEM_CODE ");
                    sbQuery.Append(" ,I.ITEM_NAME ");
                    sbQuery.Append(" ,P.PROD_CODE ");
                    sbQuery.Append(" ,P.PROD_NAME ");
                    sbQuery.Append(" ,SP.PART_CODE ");
                    sbQuery.Append(" ,SP.PART_NAME ");
                    sbQuery.Append(" ,SP.MAT_LTYPE ");
                    sbQuery.Append(" ,SP.MAT_MTYPE ");
                    sbQuery.Append(" ,SP.MAT_STYPE ");
                    sbQuery.Append(" ,SP.MAT_UNIT ");
                    sbQuery.Append(" ,SP.DRAW_NO ");
                    sbQuery.Append(" ,SP.PART_PRODTYPE ");
                    sbQuery.Append(" ,SP.MAT_QLTY AS PART_QLTY ");
                    sbQuery.Append(" ,Q.MQLTY_NAME AS PART_QLTY_NAME ");
                    sbQuery.Append(" ,SP.MAT_SPEC AS PART_SPEC ");
                    sbQuery.Append(" ,SP.MAT_SPEC1 AS PART_SPEC1 ");
                    sbQuery.Append(" ,B.MAT_SPEC AS B_MAT_SPEC ");
                    sbQuery.Append(" ,B.MAT_WEIGHT AS B_WEIGHT ");
                    sbQuery.Append(" ,R.PROC_CODE ");
                    sbQuery.Append(" ,PRC.PROC_NAME ");
                    sbQuery.Append(" ,B.QTY AS BAL_QTY ");
                    sbQuery.Append(" ,Y.QTY ");
                    sbQuery.Append(" ,B.UNIT_COST ");
                    sbQuery.Append(" ,B.UNIT_COST * Y.QTY AS AMT ");
                    sbQuery.Append(" ,Y.SCOMMENT ");
                    sbQuery.Append(" ,Y.INS_FLAG ");
                    sbQuery.Append(" ,B.REG_EMP AS BALJU_REG_EMP ");
                    sbQuery.Append(" ,BALJU_REG.EMP_NAME AS BALJU_REG_EMP_NAME ");
                    sbQuery.Append(" ,R.REG_EMP AS REQ_REG_EMP ");
                    sbQuery.Append(" ,Y.REG_EMP ");
                    sbQuery.Append(" ,REG.EMP_NAME AS REG_EMP_NAME ");
                    sbQuery.Append(" ,'PO' AS BAL_FLAG");

                    sbQuery.Append(" ,V.VEN_BIZ_NO	  ");
                    sbQuery.Append(" ,V.VEN_ADDRESS	  ");
                    sbQuery.Append(" ,V.VEN_TEL		  ");
                    sbQuery.Append(" ,V.VEN_FAX		  ");
                    sbQuery.Append(" ,V.VEN_CEO		  ");
                    sbQuery.Append(" ,V.VEN_CONDITIONS");
                    sbQuery.Append(" ,V.VEN_PRODUCTS  ");
                    sbQuery.Append(" ,V.VEN_EMAIL	  ");
                    sbQuery.Append(" ,V.VEN_CHARGE_EMP	  ");
                    sbQuery.Append(" ,V.VEN_CHARGE_TEL	  ");
                    sbQuery.Append(" ,V.VEN_CHARGE_HP	  ");
                    sbQuery.Append(" ,CV.VEN_NAME AS CVND_NAME	  ");


                    sbQuery.Append(" FROM TOUT_PROCYPGO Y ");
                    sbQuery.Append(" LEFT JOIN TOUT_PROCBALJU B ");
                    sbQuery.Append(" ON Y.PLT_CODE = B.PLT_CODE ");
                    sbQuery.Append(" AND Y.BALJU_NUM = B.BALJU_NUM ");
                    sbQuery.Append(" AND Y.BALJU_SEQ = B.BALJU_SEQ ");

                    sbQuery.Append(" JOIN TOUT_PROCBALJU_MASTER BM ");
                    sbQuery.Append(" ON B.PLT_CODE = BM.PLT_CODE ");
                    sbQuery.Append(" AND B.BALJU_NUM = BM.BALJU_NUM ");

                    sbQuery.Append(" LEFT JOIN TOUT_TEMP_YPGO TYP ");
                    sbQuery.Append(" ON Y.PLT_CODE = TYP.PLT_CODE ");
                    sbQuery.Append(" AND Y.TYP_ID = TYP.TYP_ID ");

                    sbQuery.Append(" LEFT JOIN TOUT_REQUEST R  ");
                    sbQuery.Append(" ON B.PLT_CODE = R.PLT_CODE ");
                    sbQuery.Append(" AND B.REQUEST_NO = R.REQUEST_NO ");
                    sbQuery.Append(" AND B.REQUEST_SEQ = R.REQUEST_SEQ ");

                    sbQuery.Append(" LEFT JOIN TOUT_REQUEST_MASTER RM ");
                    sbQuery.Append(" ON R.PLT_CODE = RM.PLT_CODE ");
                    sbQuery.Append(" AND R.REQUEST_NO = RM.REQUEST_NO ");

                    sbQuery.Append(" LEFT JOIN TSHP_WORKORDER W ");
                    sbQuery.Append(" ON R.PLT_CODE = W.PLT_CODE ");
                    sbQuery.Append(" AND R.WO_NO = W.WO_NO ");

                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE BALJU_REG ");
                    sbQuery.Append(" ON B.PLT_CODE = BALJU_REG.PLT_CODE ");
                    sbQuery.Append(" AND B.REG_EMP = BALJU_REG.EMP_CODE ");

                    sbQuery.Append(" LEFT JOIN TORD_PRODUCT P ");
                    sbQuery.Append(" ON W.PLT_CODE = P.PLT_CODE ");
                    sbQuery.Append(" AND W.PROD_CODE = P.PROD_CODE ");
                    sbQuery.Append(" AND W.PART_CODE = P.PART_CODE ");

                    sbQuery.Append(" LEFT JOIN TORD_ITEM I ");
                    sbQuery.Append(" ON P.PLT_CODE = I.PLT_CODE ");
                    sbQuery.Append(" AND P.ITEM_CODE = I.ITEM_CODE ");

                    sbQuery.Append(" LEFT JOIN LSE_STD_PART SP ");
                    sbQuery.Append(" ON P.PLT_CODE = SP.PLT_CODE ");
                    sbQuery.Append(" AND P.PART_CODE = SP.PART_CODE ");

                    sbQuery.Append(" LEFT JOIN TMAT_QUC_MASTER Q ");
                    sbQuery.Append(" ON SP.PLT_CODE = Q.PLT_CODE  ");
                    sbQuery.Append(" AND SP.MAT_QLTY = Q.MQLTY_CODE ");

                    sbQuery.Append(" LEFT JOIN TSTD_VENDOR V ");
                    sbQuery.Append(" ON B.PLT_CODE = V.PLT_CODE ");
                    sbQuery.Append(" AND BM.OVND_CODE = V.VEN_CODE ");

                    sbQuery.Append(" LEFT JOIN TSTD_VENDOR CV ");
                    sbQuery.Append(" ON I.PLT_CODE = CV.PLT_CODE ");
                    sbQuery.Append(" AND I.CVND_CODE = CV.VEN_CODE ");

                    sbQuery.Append(" LEFT JOIN LSE_STD_PROC PRC ");
                    sbQuery.Append(" ON R.PLT_CODE = PRC.PLT_CODE ");
                    sbQuery.Append(" AND R.PROC_CODE = PRC.PROC_CODE ");

                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE REG ");
                    sbQuery.Append(" ON Y.PLT_CODE = REG.PLT_CODE ");
                    sbQuery.Append(" AND Y.REG_EMP = REG.EMP_CODE ");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE Y.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@BALJU_NUM", " B.BALJU_NUM = @BALJU_NUM "));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_BALJU_DATE, @E_BALJU_DATE", " (BM.BALJU_DATE BETWEEN @S_BALJU_DATE AND @E_BALJU_DATE) "));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_DUE_DATE, @E_DUE_DATE", "  (B.DUE_DATE BETWEEN @S_DUE_DATE AND @E_DUE_DATE) "));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_YPGO_DATE, @E_YPGO_DATE", " (Y.YPGO_DATE BETWEEN @S_YPGO_DATE AND @E_YPGO_DATE) "));
                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_CODE", " P.PROD_CODE = @PROD_CODE "));
                        sbWhere.Append(UTIL.GetWhere(row, "@ITEM_CODE", " I.ITEM_CODE = @ITEM_CODE "));
                        sbWhere.Append(UTIL.GetWhere(row, "@OVND_CODE", " BM.OVND_CODE = @OVND_CODE "));
                        sbWhere.Append(UTIL.GetWhere(row, "@REG_EMP", " Y.REG_EMP = @REG_EMP "));
                        sbWhere.Append(UTIL.GetWhere(row, "@YPGO_ID", " Y.YPGO_ID = @YPGO_ID "));

                        //search_con : 검색 통합 거래처,발주번호,공정명,수주코드,수주처명,품목코드,도면번호,품목명,제품규격,형식,재질,제품규격,소재규격,발주규격
                        //V.VEN_NAME, BALJU_NUM, PROC_NAME, ITEM_CODE, CV.VEN_NAME, PART_CODE, DRAW_NO, PART_NAME, MAT_SPEC1, PART_PRODTYPE, MAT_QLTY, MAT_SPEC, BAL_SPEC
                        string cond = "(V.VEN_NAME LIKE '%' + @SEARCH_CON + '%' OR B.BALJU_NUM LIKE '%' + @SEARCH_CON + '%' OR ";
                        cond += " I.ITEM_CODE LIKE '%' + @SEARCH_CON + '%' OR CV.VEN_NAME LIKE '%' + @SEARCH_CON + '%' OR ";
                        cond += " W.PART_CODE LIKE '%' + @SEARCH_CON + '%' OR SP.PART_NAME LIKE '%' + @SEARCH_CON + '%' OR PRC.PROC_NAME LIKE '%' + @SEARCH_CON + '%' ";
                        cond += " OR SP.MAT_SPEC1 LIKE '%' + @SEARCH_CON + '%' OR SP.MAT_SPEC LIKE '%' + @SEARCH_CON + '%' OR SP.BAL_SPEC LIKE '%' + @SEARCH_CON + '%'";
                        cond += " OR SP.PART_PRODTYPE LIKE '%' + @SEARCH_CON + '%' ";
                        cond += " OR Q.MQLTY_NAME LIKE '%' + @SEARCH_CON + '%' ) ";
                        sbWhere.Append(UTIL.GetWhere(row, "@SEARCH_CON", cond));



                        sbWhere.Append(" AND Y.YPGO_STAT IN ('19','24','25') AND B.BAL_STAT IN ('20','21','22')");

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

        public static DataTable TOUT_PROCYPGO_QUERY3(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT TPY.PLT_CODE ");
                    sbQuery.Append("    , TPBM.BALJU_NUM ");
                    sbQuery.Append("    , DATEPART(YYYY,TPY.CLOSE_DATE) AS DATE_YEAR	");
                    sbQuery.Append(" 	, DATEPART(MM,TPY.CLOSE_DATE) AS DATE_MONTH		");
                    sbQuery.Append(" 	, DATEPART(DD,TPY.CLOSE_DATE) AS DATE_DAY		");
                    sbQuery.Append(" 	, TPBM.BALJU_NUM								");
                    sbQuery.Append(" 	, MAX(VEN.VEN_CODE) AS VEN_CODE					");
                    sbQuery.Append(" 	, MAX(VEN.VEN_NAME) AS VEN_NAME					");
                    sbQuery.Append(" 	, MAX(TPBM.SCOMMENT) AS SCOMMENT				");
                    sbQuery.Append(" 	, SUM(TPB.AMT / TPB.QTY * TPY.QTY) AS TOTAL_COST	");//입고 금액이 없기 때문에 > 발주금액 / 발주수량 * 입고수량
                    sbQuery.Append("   FROM TOUT_PROCYPGO TPY							");
                    sbQuery.Append("   INNER JOIN TOUT_PROCBALJU TPB					");
                    sbQuery.Append(" 	ON TPY.PLT_CODE = TPB.PLT_CODE					");
                    sbQuery.Append(" 	AND TPY.BALJU_NUM = TPB.BALJU_NUM				");
                    sbQuery.Append(" 	AND TPY.BALJU_SEQ = TPB.BALJU_SEQ				");
                    sbQuery.Append("   INNER JOIN TOUT_PROCBALJU_MASTER TPBM			");
                    sbQuery.Append(" 	ON TPB.PLT_CODE = TPBM.PLT_CODE					");
                    sbQuery.Append(" 	AND TPB.BALJU_NUM = TPBM.BALJU_NUM				");
                    sbQuery.Append("   INNER JOIN TSTD_VENDOR VEN						");
                    sbQuery.Append(" 	ON TPBM.PLT_CODE = VEN.PLT_CODE					");
                    sbQuery.Append(" 	AND TPBM.OVND_CODE = VEN.VEN_CODE				");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE TPY.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@DATE_YEAR", " DATEPART(YYYY,TPY.CLOSE_DATE) = @DATE_YEAR "));
                        sbWhere.Append(UTIL.GetWhere(row, "@DATE_MONTH", " DATEPART(MM,TPY.CLOSE_DATE) = @DATE_MONTH "));

                        //sbWhere.Append(" GROUP BY TP.CLOSE_DATE, VEN.VEN_CODE, VEN.VEN_NAME		  ");
                        sbWhere.Append(" GROUP BY TPY.PLT_CODE, TPY.CLOSE_DATE, TPBM.BALJU_NUM ");

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

        public static DataTable TOUT_PROCYPGO_QUERY4(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT TPY.PLT_CODE ");
                    sbQuery.Append("    , TPBM.BALJU_NUM ");
                    sbQuery.Append("    , DATEPART(YYYY,TPY.CLOSE_DATE) AS DATE_YEAR ");
                    sbQuery.Append(" 	, DATEPART(MM,TPY.CLOSE_DATE) AS DATE_MONTH	  ");
                    sbQuery.Append(" 	, DATEPART(DD,TPY.CLOSE_DATE) AS DATE_DAY	  ");
                    sbQuery.Append(" 	, TPBM.BALJU_NUM								");
                    sbQuery.Append(" 	, MAX(VEN.VEN_CODE) AS VEN_CODE					");
                    sbQuery.Append(" 	, MAX(VEN.VEN_NAME) AS VEN_NAME					");
                    sbQuery.Append(" 	, SUM(TPB.AMT / TPB.QTY * TPY.QTY) AS TOTAL_COST	");//입고 금액이 없기 때문에 > 발주금액 / 발주수량 * 입고수량
                    sbQuery.Append(" 	, MAX(CASE WHEN TPY.CLOSE_DATE > GETDATE() THEN 1 ELSE 0 END) AS IS_CLOSE					  ");
                    sbQuery.Append("   FROM TOUT_PROCYPGO TPY							");
                    sbQuery.Append("   INNER JOIN TOUT_PROCBALJU TPB					");
                    sbQuery.Append(" 	ON TPY.PLT_CODE = TPB.PLT_CODE					");
                    sbQuery.Append(" 	AND TPY.BALJU_NUM = TPB.BALJU_NUM				");
                    sbQuery.Append(" 	AND TPY.BALJU_SEQ = TPB.BALJU_SEQ				");
                    sbQuery.Append("   INNER JOIN TOUT_PROCBALJU_MASTER TPBM			");
                    sbQuery.Append(" 	ON TPB.PLT_CODE = TPBM.PLT_CODE					");
                    sbQuery.Append(" 	AND TPB.BALJU_NUM = TPBM.BALJU_NUM				");
                    sbQuery.Append("   INNER JOIN TSTD_VENDOR VEN						");
                    sbQuery.Append(" 	ON TPBM.PLT_CODE = VEN.PLT_CODE					");
                    sbQuery.Append(" 	AND TPBM.OVND_CODE = VEN.VEN_CODE				");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE TPY.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@DATE_YEAR", " DATEPART(YYYY,TPY.CLOSE_DATE) = @DATE_YEAR "));

                        //sbWhere.Append(" GROUP BY TP.CLOSE_DATE, VEN.VEN_CODE, VEN.VEN_NAME		  ");
                        sbWhere.Append(" GROUP BY TPY.PLT_CODE, TPY.CLOSE_DATE, TPBM.BALJU_NUM ");

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

        public static DataTable TOUT_PROCYPGO_QUERY5(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT Y.PLT_CODE");
                    sbQuery.Append(" , Y.YPGO_ID");
                    sbQuery.Append(" , Y.BALJU_NUM");
                    sbQuery.Append(" , Y.BALJU_SEQ");
                    sbQuery.Append(" FROM TOUT_PROCYPGO Y");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE Y.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                        sbWhere.Append(UTIL.GetWhere(row, "@NOT_YPGO_ID", "Y.YPGO_ID <> @NOT_YPGO_ID "));
                        sbWhere.Append(UTIL.GetWhere(row, "@NOT_YPGO_STAT", "Y.YPGO_STAT <> @NOT_YPGO_STAT "));
                        sbWhere.Append(UTIL.GetWhere(row, "@BALJU_NUM", "Y.BALJU_NUM = @BALJU_NUM "));
                        sbWhere.Append(UTIL.GetWhere(row, "@BALJU_SEQ", "Y.BALJU_SEQ = @BALJU_SEQ "));


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

        public static DataTable TOUT_PROCYPGO_QUERY6(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT");
                    sbQuery.Append(" PY.PLT_CODE");
                    sbQuery.Append(" ,LEFT(PY.YPGO_DATE, 6) AS YPGO_MONTH");
                    sbQuery.Append(" ,SUM(PY.QTY) AS QTY");
                    sbQuery.Append(" ,SUM(PY.UNIT_COST) AS UNIT_COST");
                    sbQuery.Append(" ,SUM(PY.AMT) AS AMT");
                    sbQuery.Append(" ,PM.OVND_CODE");
                    sbQuery.Append(" ,V.VEN_NAME AS OVND_NAME");
                    sbQuery.Append(" FROM TOUT_PROCYPGO PY");
                    sbQuery.Append(" LEFT JOIN TOUT_PROCBALJU_MASTER PM");
                    sbQuery.Append(" ON PY.PLT_CODE = PM.PLT_CODE");
                    sbQuery.Append(" AND PY.BALJU_NUM = PM.BALJU_NUM");
                    sbQuery.Append(" LEFT JOIN TSTD_VENDOR V");
                    sbQuery.Append(" ON PM.PLT_CODE = V.PLT_CODE");
                    sbQuery.Append(" AND PM.OVND_CODE = V.VEN_CODE");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE PY.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                        sbWhere.Append(UTIL.GetWhere(row, "@YEAR", "LEFT(PY.YPGO_DATE, 4) = @YEAR "));
                        sbWhere.Append(" AND YPGO_STAT IN('19', '21')");

                        sbWhere.Append(" GROUP BY PY.PLT_CODE");
                        sbWhere.Append(" ,LEFT(PY.YPGO_DATE, 6)");
                        sbWhere.Append(" ,PM.OVND_CODE");
                        sbWhere.Append(" ,V.VEN_NAME");

                        sbWhere.Append(" ORDER BY LEFT(PY.YPGO_DATE, 6)");

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
