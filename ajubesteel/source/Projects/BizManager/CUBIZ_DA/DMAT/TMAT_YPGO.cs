using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace DMAT
{
    public class TMAT_YPGO
    {
        public static void TMAT_YPGO_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();


                    sbQuery.Append(" INSERT INTO TMAT_YPGO ");
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
                    sbQuery.Append("      , YPGO_LOC ");
                    sbQuery.Append("      , YPGO_LOC_DETAIL ");
                    sbQuery.Append("      , INS_FLAG ");
                    sbQuery.Append("      , INS_DATE ");
                    sbQuery.Append("      , INS_EMP ");
                    sbQuery.Append("      , EX_RATE ");
                    sbQuery.Append("      , SCOMMENT ");
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
                    sbQuery.Append("      , @YPGO_LOC ");
                    sbQuery.Append("      , @YPGO_LOC_DETAIL ");
                    sbQuery.Append("      , @INS_FLAG ");
                    sbQuery.Append("      , @INS_DATE ");
                    sbQuery.Append("      , @INS_EMP ");
                    sbQuery.Append("      , @EX_RATE ");
                    sbQuery.Append("      , @SCOMMENT ");
                    sbQuery.Append("      , GETDATE() ");
                    sbQuery.Append(" ," + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" ) ");

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

        //상태변경
        public static void TMAT_YPGO_UPD(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" UPDATE TMAT_YPGO ");
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


        //상태변경
        public static void TMAT_YPGO_UPD2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TMAT_YPGO ");
                    sbQuery.Append("    SET   YPGO_STAT = @YPGO_STAT ");
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

        //취소/반려 사유
        public static void TMAT_YPGO_UPD3(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TMAT_YPGO ");
                    sbQuery.Append("    SET   BAL_STAT = @BAL_STAT ");
                    sbQuery.Append("        , C_REASON = @C_REASON ");
                    sbQuery.Append("        , MDFY_DATE =  GETDATE() ");
                    sbQuery.Append("        , MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("    AND BALJU_NUM = @BALJU_NUM  ");
                    sbQuery.Append("    AND BALJU_SEQ = @BALJU_SEQ ");


                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "BALJU_NUM")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "BALJU_SEQ")) isHasColumn = false;

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

        //입고취소 사유
        public static void TMAT_YPGO_UPD5(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    
                    sbQuery.Append(" UPDATE TMAT_YPGO ");
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

        public static void TMAT_YPGO_UPD6(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TMAT_YPGO ");
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

        public static void TMAT_YPGO_UPD7(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TMAT_YPGO ");
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

        public static void TMAT_YPGO_UPD8(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TMAT_YPGO SET  ");
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

    }



    public class TMAT_YPGO_QUERY
    {
        //입고 현황 조회
        public static DataTable TMAT_YPGO_QUERY1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {

                DataSet dsResult = new DataSet();
                StringBuilder sbQuery = new StringBuilder();

                sbQuery.Append(" SELECT");
                sbQuery.Append(" B.PLT_CODE");
                sbQuery.Append(" ,BM.BAL_TYPE");
                sbQuery.Append(" ,B.BALJU_NUM");
                sbQuery.Append(" ,B.BALJU_NUM AS GROUP_BALJU_NUM");
                sbQuery.Append(" ,B.BALJU_SEQ");
                sbQuery.Append(" ,B.PART_CODE");
                sbQuery.Append(" ,SP.PART_NAME");
                sbQuery.Append(" ,SP.PART_NAME AS PART_NAME2");
                sbQuery.Append(" ,SP.MAT_LTYPE");
                sbQuery.Append(" ,SP.MAT_MTYPE");
                sbQuery.Append(" ,SP.MAT_SPEC");
                sbQuery.Append(" ,SP.MAT_UNIT");
                sbQuery.Append(" ,SP.STK_LOCATION");
                sbQuery.Append(" ,ISNULL(B.INS_FLAG, 1) AS INS_FLAG");
                sbQuery.Append(" ,B.BAL_STAT");
                sbQuery.Append(" ,BM.BALJU_DATE");
                sbQuery.Append(" ,B.DUE_DATE");
                sbQuery.Append(" ,BM.MVND_CODE AS VEN_CODE");
                sbQuery.Append(" ,B.QTY AS BAL_QTY");
                sbQuery.Append(" ,Y.QTY AS YPGO_QTY");
                sbQuery.Append(" ,B.UNIT_COST AS BAL_COST");
                sbQuery.Append(" ,Y.UNIT_COST AS YPGO_COST");
                sbQuery.Append(" ,ISNULL(Y.QTY, 0) * ISNULL(Y.UNIT_COST, 0) AS AMT");
                sbQuery.Append(" ,Y.YPGO_DATE");
                sbQuery.Append(" ,Y.CLOSE_DATE");
                sbQuery.Append(" ,Y.YPGO_ID");
                sbQuery.Append(" ,Y.YPGO_LOC");
                sbQuery.Append(" ,B.BAL_UNIT");
                sbQuery.Append(" ,B.DETAIL_PART_NAME");

                sbQuery.Append(" ,B.SCOMMENT AS BALJU_SCOMMENT");
                sbQuery.Append(" ,Y.SCOMMENT AS YPGO_SCOMMENT");
                sbQuery.Append(" ,Y.CLOSE_SCOMMENT");

                sbQuery.Append(" ,B.REG_EMP AS BALJU_REG_EMP");
                sbQuery.Append(" ,E.EMP_NAME AS BALJU_REG_EMP_NAME");

                sbQuery.Append(" ,BM.CHK_RD");

                sbQuery.Append(" ,ISNULL(Y.CHECK_FLAG, '0') AS CHECK_FLAG ");
                sbQuery.Append(" ,Y.CHECK_EMP ");
                sbQuery.Append(" ,CHK.EMP_NAME AS CHECK_EMP_NAME ");
                sbQuery.Append(" ,Y.CHECK_DATE ");
                sbQuery.Append(" ,Y.CHECK_DEL_EMP ");
                sbQuery.Append(" ,CHKD.EMP_NAME AS CHECK_DEL_EMP_NAME ");
                sbQuery.Append(" ,Y.CHECK_DEL_DATE ");

                sbQuery.Append(" ,SP.DRAW_NO");

                sbQuery.Append(" FROM TMAT_YPGO Y");
                sbQuery.Append(" JOIN TMAT_BALJU B");
                sbQuery.Append(" ON Y.PLT_CODE = B.PLT_CODE");
                sbQuery.Append(" AND Y.BALJU_NUM = B.BALJU_NUM");
                sbQuery.Append(" AND Y.BALJU_SEQ = B.BALJU_SEQ");
                
                sbQuery.Append(" JOIN TMAT_BALJU_MASTER BM");
                sbQuery.Append(" ON B.PLT_CODE = BM.PLT_CODE");
                sbQuery.Append(" AND B.BALJU_NUM = BM.BALJU_NUM");
                
                sbQuery.Append(" LEFT JOIN LSE_STD_PART SP");
                sbQuery.Append(" ON B.PLT_CODE = SP.PLT_CODE");
                sbQuery.Append(" AND B.PART_CODE = SP.PART_CODE");

                sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE E");
                sbQuery.Append(" ON B.PLT_CODE = E.PLT_CODE");
                sbQuery.Append(" AND B.REG_EMP = E.EMP_CODE");

                sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE CHK");
                sbQuery.Append(" ON Y.PLT_CODE = CHK.PLT_CODE");
                sbQuery.Append(" AND Y.CHECK_EMP = CHK.EMP_CODE");

                sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE CHKD");
                sbQuery.Append(" ON Y.PLT_CODE = CHKD.PLT_CODE");
                sbQuery.Append(" AND Y.CHECK_DEL_EMP = CHKD.EMP_CODE");

                foreach (DataRow row in dtParam.Rows)
                {
                    StringBuilder sbWhere = new StringBuilder(" WHERE Y.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                    sbWhere.Append(UTIL.GetWhere(row, "@BALJU_NUM", " Y.BALJU_NUM = @BALJU_NUM "));
                    sbWhere.Append(UTIL.GetWhere(row, "@S_BALJU_DATE,@E_BALJU_DATE", " (BM.BALJU_DATE BETWEEN @S_BALJU_DATE AND @E_BALJU_DATE) "));
                    sbWhere.Append(UTIL.GetWhere(row, "@S_DUE_DATE,@E_DUE_DATE", " (B.DUE_DATE BETWEEN @S_DUE_DATE AND @E_DUE_DATE) "));
                    sbWhere.Append(UTIL.GetWhere(row, "@S_YPGO_DATE,@E_YPGO_DATE", " (Y.YPGO_DATE BETWEEN @S_YPGO_DATE AND @E_YPGO_DATE) "));
                    sbWhere.Append(UTIL.GetWhere(row, "@BALJU_NUM_LIKE", "Y.BALJU_NUM LIKE '%' + @BALJU_NUM_LIKE + '%'"));
                    sbWhere.Append(UTIL.GetWhere(row, "@PART_LIKE", "(B.PART_CODE LIKE '%' + @PART_LIKE + '%' OR SP.PART_NAME LIKE '%' + @PART_LIKE + '%')"));
                    sbWhere.Append(UTIL.GetWhere(row, "@MAT_LTYPE", " SP.MAT_LTYPE = @MAT_LTYPE "));
                    sbWhere.Append(UTIL.GetWhere(row, "@MVND_CODE", " BM.MVND_CODE = @MVND_CODE "));
                    sbWhere.Append(UTIL.GetWhere(row, "@REG_EMP", " B.REG_EMP = @REG_EMP "));
                    sbWhere.Append(UTIL.GetWhere(row, "@YPGO_ID", " Y.YPGO_ID = @YPGO_ID "));
                    sbWhere.Append(UTIL.GetWhere(row, "@YPGO", " Y.YPGO_STAT = '19' AND B.BAL_STAT IN ('21', '22') "));

                    DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString() + sbWhere.ToString()).Copy();

                    sourceTable.TableName = "RSLTDT";
                    dsResult.Merge(sourceTable);
                }

                return UTIL.GetDsToDt(dsResult); 

            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }
        //자재 입고취소(금형자재)
        public static DataTable TMAT_YPGO_QUERY2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT ");
                    sbQuery.Append(" U.PLT_CODE ");
                    sbQuery.Append(" ,U.YPGO_ID ");
                    sbQuery.Append(" ,U.REQUEST_NO ");
                    sbQuery.Append(" ,U.REQUEST_SEQ ");
                    sbQuery.Append(" ,U.WO_NO ");
                    sbQuery.Append(" ,U.BALJU_NUM ");
                    sbQuery.Append(" ,U.BALJU_SEQ ");
                    sbQuery.Append(" ,U.BAL_STAT ");
                    sbQuery.Append(" ,U.YPGO_STAT ");
                    sbQuery.Append(" ,U.BALJU_DATE ");
                    sbQuery.Append(" ,U.DUE_DATE ");
                    sbQuery.Append(" ,U.YPGO_DATE ");
                    sbQuery.Append(" ,U.YPGO_DATE AS DATE");
                    sbQuery.Append(" ,U.YPGO_LOC ");
                    sbQuery.Append(" ,U.YPGO_LOC_DETAIL ");
                    sbQuery.Append(" ,U.CLOSE_DATE ");
                    sbQuery.Append(" ,U.VEN_CODE ");
                    sbQuery.Append(" ,V.VEN_NAME ");
                    sbQuery.Append(" ,CV.VEN_NAME AS CVND_NAME ");
                    sbQuery.Append(" ,U.ITEM_CODE ");
                    sbQuery.Append(" ,U.ITEM_NAME ");
                    sbQuery.Append(" ,U.PROD_CODE ");
                    sbQuery.Append(" ,U.PROD_NAME ");
                    sbQuery.Append(" ,U.PART_CODE ");
                    sbQuery.Append(" ,U.PART_NAME ");
                    sbQuery.Append(" ,U.DRAW_NO ");
                    sbQuery.Append(" ,U.MAT_LTYPE ");
                    sbQuery.Append(" ,U.MAT_MTYPE ");
                    sbQuery.Append(" ,U.MAT_STYPE ");
                    sbQuery.Append(" ,U.MAT_UNIT ");
                    sbQuery.Append(" ,U.PART_PRODTYPE ");
                    sbQuery.Append(" ,U.PART_QLTY ");
                    sbQuery.Append(" ,Q.MQLTY_NAME AS PART_QLTY_NAME ");
                    sbQuery.Append(" ,U.PART_SPEC ");
                    sbQuery.Append(" ,U.PART_SPEC1 ");
                    sbQuery.Append(" ,U.BAL_SPEC ");
                    sbQuery.Append(" ,U.B_MAT_SPEC ");
                    sbQuery.Append(" ,U.B_WEIGHT ");
                    sbQuery.Append(" ,U.BAL_QTY ");
                    sbQuery.Append(" ,U.QTY ");
                    sbQuery.Append(" ,U.UNIT_COST ");
                    sbQuery.Append(" ,U.UNIT_COST * U.QTY AS AMT ");
                    sbQuery.Append(" ,U.SCOMMENT ");
                    sbQuery.Append(" ,U.INS_FLAG ");
                    sbQuery.Append(" ,U.BALJU_REG_EMP ");
                    sbQuery.Append(" ,U.REQ_REG_EMP ");
                    sbQuery.Append(" ,U.REG_EMP ");
                    sbQuery.Append(" ,YPGO_REG.EMP_NAME AS REG_EMP_NAME ");
                    sbQuery.Append(" ,BALJU_REG.EMP_NAME AS BALJU_REG_EMP_NAME ");
                    sbQuery.Append(" ,'M' AS BAL_FLAG");

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
                    sbQuery.Append(" FROM ");
                    sbQuery.Append(" ( ");
                    sbQuery.Append(" SELECT  ");
                    sbQuery.Append(" B.PLT_CODE ");
                    sbQuery.Append(" ,Y.YPGO_ID ");
                    sbQuery.Append(" ,B.REQUEST_NO ");
                    sbQuery.Append(" ,B.REQUEST_SEQ ");
                    sbQuery.Append(" ,B.BALJU_NUM ");
                    sbQuery.Append(" ,B.BALJU_SEQ ");
                    sbQuery.Append(" ,B.BAL_STAT ");
                    sbQuery.Append(" ,Y.YPGO_STAT ");
                    sbQuery.Append(" ,Y.YPGO_LOC ");
                    sbQuery.Append(" ,Y.YPGO_LOC_DETAIL ");
                    sbQuery.Append(" ,BM.BALJU_DATE ");
                    sbQuery.Append(" ,B.DUE_DATE ");
                    sbQuery.Append(" ,Y.YPGO_DATE ");
                    sbQuery.Append(" ,BM.MVND_CODE AS VEN_CODE ");
                    sbQuery.Append(" ,I.ITEM_CODE ");
                    sbQuery.Append(" ,I.ITEM_NAME ");
                    sbQuery.Append(" ,P.PROD_CODE ");
                    sbQuery.Append(" ,P.PROD_NAME ");
                    sbQuery.Append(" ,R.WO_NO ");
                    sbQuery.Append(" ,SP.PART_CODE ");
                    sbQuery.Append(" ,SP.PART_NAME ");
                    sbQuery.Append(" ,SP.DRAW_NO ");
                    sbQuery.Append(" ,SP.MAT_LTYPE ");
                    sbQuery.Append(" ,SP.MAT_MTYPE ");
                    sbQuery.Append(" ,SP.MAT_STYPE ");
                    sbQuery.Append(" ,SP.MAT_UNIT ");
                    sbQuery.Append(" ,SP.PART_PRODTYPE ");
                    sbQuery.Append(" ,SP.MAT_QLTY AS PART_QLTY ");
                    sbQuery.Append(" ,SP.MAT_SPEC AS PART_SPEC ");
                    sbQuery.Append(" ,SP.MAT_SPEC1 AS PART_SPEC1 ");
                    sbQuery.Append(" ,SP.BAL_SPEC ");
                    sbQuery.Append(" ,B.QTY AS BAL_QTY ");
                    sbQuery.Append(" ,B.MAT_SPEC AS B_MAT_SPEC ");
                    sbQuery.Append(" ,B.MAT_WEIGHT AS B_WEIGHT ");
                    sbQuery.Append(" ,Y.QTY ");
                    sbQuery.Append(" ,B.UNIT_COST ");
                    sbQuery.Append(" ,Y.SCOMMENT ");
                    sbQuery.Append(" ,Y.CLOSE_DATE ");
                    sbQuery.Append(" ,Y.INS_FLAG ");
                    sbQuery.Append(" ,B.REG_EMP AS BALJU_REG_EMP ");
                    sbQuery.Append(" ,R.REG_EMP AS REQ_REG_EMP ");
                    sbQuery.Append(" ,Y.REG_EMP ");
                    sbQuery.Append(" ,I.CVND_CODE ");
                    sbQuery.Append(" FROM TMAT_YPGO Y ");
                    sbQuery.Append("  JOIN TMAT_BALJU B ");
                    sbQuery.Append(" ON Y.PLT_CODE = B.PLT_CODE ");
                    sbQuery.Append(" AND Y.BALJU_NUM = B.BALJU_NUM ");
                    sbQuery.Append(" AND Y.BALJU_SEQ = B.BALJU_SEQ ");
                    sbQuery.Append(" JOIN TMAT_BALJU_MASTER BM ");
                    sbQuery.Append(" ON B.PLT_CODE = BM.PLT_CODE ");
                    sbQuery.Append(" AND B.BALJU_NUM = BM.BALJU_NUM ");
                    sbQuery.Append("  JOIN TMAT_REQUEST R  ");
                    sbQuery.Append(" ON B.PLT_CODE = R.PLT_CODE ");
                    sbQuery.Append(" AND B.REQUEST_NO = R.REQUEST_NO ");
                    sbQuery.Append(" AND B.REQUEST_SEQ = R.REQUEST_SEQ ");
                    sbQuery.Append("  JOIN TMAT_REQUEST_MASTER RM ");
                    sbQuery.Append(" ON R.PLT_CODE = RM.PLT_CODE ");
                    sbQuery.Append(" AND R.REQUEST_NO = RM.REQUEST_NO ");
                    sbQuery.Append(" LEFT JOIN TORD_PRODUCT P ");
                    sbQuery.Append(" ON R.PLT_CODE = P.PLT_CODE ");
                    sbQuery.Append(" AND R.PROD_CODE = P.PROD_CODE ");
                    sbQuery.Append(" AND R.PART_CODE = P.PART_CODE ");
                    sbQuery.Append(" LEFT JOIN TORD_ITEM I ");
                    sbQuery.Append(" ON P.PLT_CODE = I.PLT_CODE ");
                    sbQuery.Append(" AND P.ITEM_CODE = I.ITEM_CODE ");
                    sbQuery.Append(" LEFT JOIN LSE_STD_PART SP ");
                    sbQuery.Append(" ON R.PLT_CODE = SP.PLT_CODE ");
                    sbQuery.Append(" AND R.PART_CODE = SP.PART_CODE ");
                    sbQuery.Append(" WHERE ");
                    sbQuery.Append(" Y.YPGO_STAT IN ('19','24','25') ");
                    sbQuery.Append(" AND B.BAL_STAT IN ('20','21','22') ");
                    sbQuery.Append(" ) AS U ");

                    sbQuery.Append(" LEFT JOIN TMAT_QUC_MASTER Q ");
                    sbQuery.Append(" ON U.PLT_CODE = Q.PLT_CODE  ");
                    sbQuery.Append(" AND U.PART_QLTY = Q.MQLTY_CODE ");

                    sbQuery.Append(" LEFT JOIN TSTD_VENDOR V ");
                    sbQuery.Append(" ON U.PLT_CODE = V.PLT_CODE ");
                    sbQuery.Append(" AND U.VEN_CODE = V.VEN_CODE ");

                    sbQuery.Append(" LEFT JOIN TSTD_VENDOR CV ");
                    sbQuery.Append(" ON U.PLT_CODE = CV.PLT_CODE ");
                    sbQuery.Append(" AND U.CVND_CODE = CV.VEN_CODE ");

                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE YPGO_REG ");
                    sbQuery.Append(" ON U.PLT_CODE = YPGO_REG.PLT_CODE ");
                    sbQuery.Append(" AND U.REG_EMP = YPGO_REG.EMP_CODE ");

                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE BALJU_REG ");
                    sbQuery.Append(" ON U.PLT_CODE = BALJU_REG.PLT_CODE ");
                    sbQuery.Append(" AND U.BALJU_REG_EMP = BALJU_REG.EMP_CODE ");
                    

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE U.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@BALJU_NUM", " U.BALJU_NUM = @BALJU_NUM "));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_BALJU_DATE, @E_BALJU_DATE ", " (U.BALJU_DATE BETWEEN @S_BALJU_DATE AND @E_BALJU_DATE) "));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_DUE_DATE, @E_DUE_DATE", " (U.DUE_DATE BETWEEN @S_DUE_DATE AND @E_DUE_DATE) "));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_YPGO_DATE, @E_YPGO_DATE", " (U.YPGO_DATE BETWEEN @S_YPGO_DATE AND @E_YPGO_DATE) "));
                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_CODE", " U.PROD_CODE = @PROD_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@ITEM_CODE", " U.ITEM_CODE = @ITEM_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@MVND_CODE", " U.VEN_CODE = @MVND_CODE "));
                        sbWhere.Append(UTIL.GetWhere(row, "@REG_EMP", " U.REG_EMP = @REG_EMP "));
                        sbWhere.Append(UTIL.GetWhere(row, "@YPGO_ID", " U.YPGO_ID = @YPGO_ID "));


                        //search_con : 검색 통합 거래처,발주번호,공정명,수주코드,수주처명,품목코드,도면번호,품목명,제품규격,형식,재질,제품규격,소재규격,발주규격
                        //V.VEN_NAME, BALJU_NUM, PROC_NAME, ITEM_CODE, CV.VEN_NAME, PART_CODE, DRAW_NO, PART_NAME, MAT_SPEC1, PART_PRODTYPE, MAT_QLTY, MAT_SPEC, BAL_SPEC
                        string cond = "(V.VEN_NAME LIKE '%' + @SEARCH_CON + '%' OR U.BALJU_NUM LIKE '%' + @SEARCH_CON + '%' OR ";
                        cond += " U.ITEM_CODE LIKE '%' + @SEARCH_CON + '%' OR CV.VEN_NAME LIKE '%' + @SEARCH_CON + '%' OR ";
                        cond += " U.PART_CODE LIKE '%' + @SEARCH_CON + '%' OR U.PART_NAME LIKE '%' + @SEARCH_CON + '%' OR ";
                        cond += " U.PART_SPEC1 LIKE '%' + @SEARCH_CON + '%' OR U.PART_SPEC LIKE '%' + @SEARCH_CON + '%' OR U.BAL_SPEC LIKE '%' + @SEARCH_CON + '%'";
                        cond += " OR U.PART_PRODTYPE LIKE '%' + @SEARCH_CON + '%' ";
                        cond += " OR Q.MQLTY_NAME LIKE '%' + @SEARCH_CON + '%' ) ";
                        sbWhere.Append(UTIL.GetWhere(row, "@SEARCH_CON", cond));



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

        //자재 입고 거래처
        public static DataTable TMAT_YPGO_QUERY3(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT O.PLT_CODE													   ");
                    sbQuery.Append(" ,O.VEN_CODE														   ");
                    sbQuery.Append(" ,O.VEN_NAME														   ");
                    sbQuery.Append(" FROM																   ");
                    sbQuery.Append(" (																	   ");
                    sbQuery.Append(" SELECT 															   ");
                    sbQuery.Append(" U.PLT_CODE															   ");
                    sbQuery.Append(" ,U.VEN_CODE 														   ");
                    sbQuery.Append(" ,V.VEN_NAME 														   ");
                    sbQuery.Append(" ,U.BALJU_NUM														   ");
                    sbQuery.Append(" ,U.BALJU_DATE														   ");
                    sbQuery.Append(" ,U.DUE_DATE														   ");
                    sbQuery.Append(" ,U.YPGO_DATE														   ");
                    sbQuery.Append(" ,U.PROD_CODE														   ");
                    sbQuery.Append(" ,U.ITEM_CODE														   ");
                    sbQuery.Append(" ,U.YPGO_ID															   ");
                    sbQuery.Append(" FROM 																   ");
                    sbQuery.Append(" ( 																	   ");
                    sbQuery.Append(" SELECT  															   ");
                    sbQuery.Append(" B.PLT_CODE 														   ");
                    sbQuery.Append(" ,Y.YPGO_ID 														   ");
                    sbQuery.Append(" ,B.REQUEST_NO 														   ");
                    sbQuery.Append(" ,B.REQUEST_SEQ 													   ");
                    sbQuery.Append(" ,B.BALJU_NUM 														   ");
                    sbQuery.Append(" ,B.BALJU_SEQ 														   ");
                    sbQuery.Append(" ,B.BAL_STAT 														   ");
                    sbQuery.Append(" ,Y.YPGO_STAT 														   ");
                    sbQuery.Append(" ,BM.BALJU_DATE 													   ");
                    sbQuery.Append(" ,B.DUE_DATE 														   ");
                    sbQuery.Append(" ,Y.YPGO_DATE 														   ");
                    sbQuery.Append(" ,BM.MVND_CODE AS VEN_CODE 											   ");
                    sbQuery.Append(" ,I.ITEM_CODE 														   ");
                    sbQuery.Append(" ,I.ITEM_NAME 														   ");
                    sbQuery.Append(" ,P.PROD_CODE 														   ");
                    sbQuery.Append(" ,P.PROD_NAME 														   ");
                    sbQuery.Append(" ,R.WO_NO 															   ");
                    sbQuery.Append(" ,B.QTY AS BAL_QTY 													   ");
                    sbQuery.Append(" ,B.MAT_SPEC AS B_MAT_SPEC 											   ");
                    sbQuery.Append(" ,B.MAT_WEIGHT AS B_WEIGHT 											   ");
                    sbQuery.Append(" ,Y.QTY 															   ");
                    sbQuery.Append(" ,Y.SCOMMENT 														   ");
                    sbQuery.Append(" ,Y.INS_FLAG 														   ");
                    sbQuery.Append(" ,B.REG_EMP AS BALJU_REG_EMP 										   ");
                    sbQuery.Append(" ,R.REG_EMP AS REQ_REG_EMP 											   ");
                    sbQuery.Append(" ,Y.REG_EMP 														   ");
                    sbQuery.Append(" FROM TMAT_YPGO Y 													   ");
                    sbQuery.Append("  JOIN TMAT_BALJU B 												   ");
                    sbQuery.Append(" ON Y.PLT_CODE = B.PLT_CODE 										   ");
                    sbQuery.Append(" AND Y.BALJU_NUM = B.BALJU_NUM 										   ");
                    sbQuery.Append(" AND Y.BALJU_SEQ = B.BALJU_SEQ 										   ");
                    sbQuery.Append(" JOIN TMAT_BALJU_MASTER BM 											   ");
                    sbQuery.Append(" ON B.PLT_CODE = BM.PLT_CODE 										   ");
                    sbQuery.Append(" AND B.BALJU_NUM = BM.BALJU_NUM 									   ");
                    sbQuery.Append("  JOIN TMAT_REQUEST R  												   ");
                    sbQuery.Append(" ON B.PLT_CODE = R.PLT_CODE 										   ");
                    sbQuery.Append(" AND B.REQUEST_NO = R.REQUEST_NO 									   ");
                    sbQuery.Append(" AND B.REQUEST_SEQ = R.REQUEST_SEQ 									   ");
                    sbQuery.Append("  JOIN TMAT_REQUEST_MASTER RM 										   ");
                    sbQuery.Append(" ON R.PLT_CODE = RM.PLT_CODE 										   ");
                    sbQuery.Append(" AND R.REQUEST_NO = RM.REQUEST_NO 									   ");
                    sbQuery.Append(" LEFT JOIN TORD_PRODUCT P 											   ");
                    sbQuery.Append(" ON R.PLT_CODE = P.PLT_CODE 										   ");
                    sbQuery.Append(" AND R.PROD_CODE = P.PROD_CODE 										   ");
                    sbQuery.Append(" AND R.PART_CODE = P.PART_CODE 										   ");
                    sbQuery.Append(" LEFT JOIN TORD_ITEM I 												   ");
                    sbQuery.Append(" ON P.PLT_CODE = I.PLT_CODE 										   ");
                    sbQuery.Append(" AND P.ITEM_CODE = I.ITEM_CODE 										   ");
                    sbQuery.Append(" WHERE 																   ");
                    sbQuery.Append(" Y.YPGO_STAT IN ('19','24','25') 									   ");
                    sbQuery.Append(" AND B.BAL_STAT IN ('20','21','22') 								   ");
                    sbQuery.Append(" ) AS U 															   ");
                    sbQuery.Append(" 																	   ");
                    sbQuery.Append(" LEFT JOIN TSTD_VENDOR V 											   ");
                    sbQuery.Append(" ON U.PLT_CODE = V.PLT_CODE 										   ");
                    sbQuery.Append(" AND U.VEN_CODE = V.VEN_CODE 										   ");
                    sbQuery.Append(" 																	   ");
                    sbQuery.Append(" WHERE U.PLT_CODE = '100'											   ");
                    sbQuery.Append(" 																	   ");
                    sbQuery.Append(" GROUP BY   U.PLT_CODE												   ");
                    sbQuery.Append(" ,U.VEN_CODE 														   ");
                    sbQuery.Append(" ,V.VEN_NAME 														   ");
                    sbQuery.Append(" ,U.BALJU_NUM														   ");
                    sbQuery.Append(" ,U.BALJU_DATE														   ");
                    sbQuery.Append(" ,U.DUE_DATE														   ");
                    sbQuery.Append(" ,U.YPGO_DATE														   ");
                    sbQuery.Append(" ,U.PROD_CODE														   ");
                    sbQuery.Append(" ,U.ITEM_CODE														   ");
                    sbQuery.Append(" ,U.YPGO_ID															   ");
                    sbQuery.Append(" 																	   ");
                    sbQuery.Append(" UNION ALL															   ");
                    sbQuery.Append(" 																	   ");
                    sbQuery.Append("  SELECT  															   ");
                    sbQuery.Append(" B.PLT_CODE 														   ");
                    sbQuery.Append(" ,BM.OVND_CODE AS VEN_CODE 											   ");
                    sbQuery.Append(" ,V.VEN_NAME 														   ");
                    sbQuery.Append(" ,BM.BALJU_NUM														   ");
                    sbQuery.Append(" ,BM.BALJU_DATE														   ");
                    sbQuery.Append(" ,B.DUE_DATE														   ");
                    sbQuery.Append(" ,Y.YPGO_DATE														   ");
                    sbQuery.Append(" ,P.PROD_CODE														   ");
                    sbQuery.Append(" ,I.ITEM_CODE														   ");
                    sbQuery.Append(" ,Y.YPGO_ID															   ");
                    sbQuery.Append(" FROM TOUT_PROCYPGO Y 												   ");
                    sbQuery.Append(" LEFT JOIN TOUT_PROCBALJU B 										   ");
                    sbQuery.Append(" ON Y.PLT_CODE = B.PLT_CODE 										   ");
                    sbQuery.Append(" AND Y.BALJU_NUM = B.BALJU_NUM 										   ");
                    sbQuery.Append(" AND Y.BALJU_SEQ = B.BALJU_SEQ 										   ");
                    sbQuery.Append(" 																	   ");
                    sbQuery.Append(" JOIN TOUT_PROCBALJU_MASTER BM 										   ");
                    sbQuery.Append(" ON B.PLT_CODE = BM.PLT_CODE 										   ");
                    sbQuery.Append(" AND B.BALJU_NUM = BM.BALJU_NUM 									   ");
                    sbQuery.Append(" 																	   ");
                    sbQuery.Append(" LEFT JOIN TOUT_REQUEST R  											   ");
                    sbQuery.Append(" ON B.PLT_CODE = R.PLT_CODE 										   ");
                    sbQuery.Append(" AND B.REQUEST_NO = R.REQUEST_NO 									   ");
                    sbQuery.Append(" AND B.REQUEST_SEQ = R.REQUEST_SEQ 									   ");
                    sbQuery.Append(" 																	   ");
                    sbQuery.Append(" LEFT JOIN TOUT_REQUEST_MASTER RM 									   ");
                    sbQuery.Append(" ON R.PLT_CODE = RM.PLT_CODE 										   ");
                    sbQuery.Append(" AND R.REQUEST_NO = RM.REQUEST_NO 									   ");
                    sbQuery.Append(" 																	   ");
                    sbQuery.Append(" LEFT JOIN TSHP_WORKORDER W 										   ");
                    sbQuery.Append(" ON R.PLT_CODE = W.PLT_CODE 										   ");
                    sbQuery.Append(" AND R.WO_NO = W.WO_NO 												   ");
                    sbQuery.Append(" 																	   ");
                    sbQuery.Append(" LEFT JOIN TORD_PRODUCT P 											   ");
                    sbQuery.Append(" ON W.PLT_CODE = P.PLT_CODE 										   ");
                    sbQuery.Append(" AND W.PROD_CODE = P.PROD_CODE 										   ");
                    sbQuery.Append(" AND W.PART_CODE = P.PART_CODE 										   ");
                    sbQuery.Append(" 																	   ");
                    sbQuery.Append(" LEFT JOIN TORD_ITEM I 												   ");
                    sbQuery.Append(" ON P.PLT_CODE = I.PLT_CODE 										   ");
                    sbQuery.Append(" AND P.ITEM_CODE = I.ITEM_CODE 										   ");
                    sbQuery.Append(" 																	   ");
                    sbQuery.Append(" LEFT JOIN TSTD_VENDOR V 											   ");
                    sbQuery.Append(" ON B.PLT_CODE = V.PLT_CODE 										   ");
                    sbQuery.Append(" AND BM.OVND_CODE = V.VEN_CODE 										   ");
                    sbQuery.Append(" 																	   ");
                    sbQuery.Append(" WHERE Y.PLT_CODE = '100'											   ");
                    sbQuery.Append(" AND Y.YPGO_STAT IN ('19','24','25') AND B.BAL_STAT IN ('20','21','22')");
                    sbQuery.Append(" 																	   ");
                    sbQuery.Append(" 																	   ");
                    sbQuery.Append(" GROUP BY  B.PLT_CODE 												   ");
                    sbQuery.Append(" ,BM.OVND_CODE														   ");
                    sbQuery.Append(" ,V.VEN_NAME 														   ");
                    sbQuery.Append(" ,BM.BALJU_NUM														   ");
                    sbQuery.Append(" ,BM.BALJU_DATE														   ");
                    sbQuery.Append(" ,B.DUE_DATE														   ");
                    sbQuery.Append(" ,Y.YPGO_DATE														   ");
                    sbQuery.Append(" ,P.PROD_CODE														   ");
                    sbQuery.Append(" ,I.ITEM_CODE														   ");
                    sbQuery.Append(" ,Y.YPGO_ID															   ");
                    sbQuery.Append(" ) O																   ");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE O.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@BALJU_NUM", " O.BALJU_NUM = @BALJU_NUM "));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_BALJU_DATE,@E_BALJU_DATE", " (O.BALJU_DATE BETWEEN @S_BALJU_DATE AND @E_BALJU_DATE) "));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_DUE_DATE,@E_DUE_DATE", " (O.DUE_DATE BETWEEN @S_DUE_DATE AND @E_DUE_DATE) "));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_YPGO_DATE, @E_YPGO_DATE", " (O.YPGO_DATE BETWEEN @S_YPGO_DATE AND @E_YPGO_DATE) "));
                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_CODE", " O.PROD_CODE = @PROD_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@ITEM_CODE", " O.ITEM_CODE = @ITEM_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@MVND_CODE", " O.VEN_CODE = @MVND_CODE "));
                        sbWhere.Append(UTIL.GetWhere(row, "@YPGO_ID", " O.YPGO_ID = @YPGO_ID "));

                        sbWhere.Append(" GROUP BY O.PLT_CODE, O.VEN_CODE, O.VEN_NAME");

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

        public static DataTable TMAT_YPGO_QUERY4(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT TP.PLT_CODE ");
                    sbQuery.Append("    , TBM.BALJU_NUM ");
                    sbQuery.Append("    , DATEPART(YYYY,TP.CLOSE_DATE) AS DATE_YEAR ");
                    sbQuery.Append(" 	, DATEPART(MM,TP.CLOSE_DATE) AS DATE_MONTH	  ");
                    sbQuery.Append(" 	, DATEPART(DD,TP.CLOSE_DATE) AS DATE_DAY	  ");
                    sbQuery.Append(" 	, MAX(VEN.VEN_CODE) AS VEN_CODE								  ");
                    sbQuery.Append(" 	, MAX(VEN.VEN_NAME)	AS VEN_NAME							  ");
                    sbQuery.Append(" 	, MAX(TBM.SCOMMENT)	AS SCOMMENT							  ");
                    sbQuery.Append(" 	, SUM(TB.AMT / TB.QTY * TP.QTY) AS TOTAL_COST	");//입고 금액이 없기 때문에 > 발주금액 / 발주수량 * 입고수량
                    sbQuery.Append("   FROM TMAT_YPGO TP							  ");
                    sbQuery.Append("   INNER JOIN TMAT_BALJU TB						  ");
                    sbQuery.Append(" 	ON TP.PLT_CODE = TB.PLT_CODE				  ");
                    sbQuery.Append(" 	AND TP.BALJU_NUM = TB.BALJU_NUM				  ");
                    sbQuery.Append(" 	AND TP.BALJU_SEQ = TB.BALJU_SEQ				  ");
                    sbQuery.Append("   INNER JOIN TMAT_BALJU_MASTER TBM				  ");
                    sbQuery.Append(" 	ON TB.PLT_CODE = TBM.PLT_CODE				  ");
                    sbQuery.Append(" 	AND TB.BALJU_NUM = TBM.BALJU_NUM				  ");
                    sbQuery.Append("   INNER JOIN TSTD_VENDOR VEN					  ");
                    sbQuery.Append(" 	ON TBM.PLT_CODE = VEN.PLT_CODE				  ");
                    sbQuery.Append(" 	AND TBM.MVND_CODE = VEN.VEN_CODE			  ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE TP.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@DATE_YEAR", " DATEPART(YYYY,TP.CLOSE_DATE) = @DATE_YEAR "));
                        sbWhere.Append(UTIL.GetWhere(row, "@DATE_MONTH", " DATEPART(MM,TP.CLOSE_DATE) = @DATE_MONTH "));

                        //sbWhere.Append(" GROUP BY TP.CLOSE_DATE, VEN.VEN_CODE, VEN.VEN_NAME		  ");
                        sbWhere.Append(" GROUP BY TP.PLT_CODE, TP.CLOSE_DATE, TBM.BALJU_NUM ");

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

        public static DataTable TMAT_YPGO_QUERY5(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT TP.PLT_CODE ");
                    sbQuery.Append("    , TBM.BALJU_NUM ");
                    sbQuery.Append("    , DATEPART(YYYY,TP.CLOSE_DATE) AS DATE_YEAR ");
                    sbQuery.Append(" 	, DATEPART(MM,TP.CLOSE_DATE) AS DATE_MONTH	  ");
                    sbQuery.Append(" 	, DATEPART(DD,TP.CLOSE_DATE) AS DATE_DAY	  ");
                    sbQuery.Append(" 	, MAX(VEN.VEN_CODE) AS VEN_CODE								  ");
                    sbQuery.Append(" 	, MAX(VEN.VEN_NAME)	AS VEN_NAME							  ");
                    sbQuery.Append(" 	, SUM(TB.AMT / TB.QTY * TP.QTY) AS TOTAL_COST	");//입고 금액이 없기 때문에 > 발주금액 / 발주수량 * 입고수량
                    sbQuery.Append(" 	, MAX(CASE WHEN TP.CLOSE_DATE > GETDATE() THEN 1 ELSE 0 END) AS IS_CLOSE					  ");
                    sbQuery.Append("   FROM TMAT_YPGO TP							  ");
                    sbQuery.Append("   INNER JOIN TMAT_BALJU TB						  ");
                    sbQuery.Append(" 	ON TP.PLT_CODE = TB.PLT_CODE				  ");
                    sbQuery.Append(" 	AND TP.BALJU_NUM = TB.BALJU_NUM				  ");
                    sbQuery.Append(" 	AND TP.BALJU_SEQ = TB.BALJU_SEQ				  ");
                    sbQuery.Append("   INNER JOIN TMAT_BALJU_MASTER TBM				  ");
                    sbQuery.Append(" 	ON TB.PLT_CODE = TBM.PLT_CODE				  ");
                    sbQuery.Append(" 	AND TB.BALJU_NUM = TBM.BALJU_NUM				  ");
                    sbQuery.Append("   INNER JOIN TSTD_VENDOR VEN					  ");
                    sbQuery.Append(" 	ON TBM.PLT_CODE = VEN.PLT_CODE				  ");
                    sbQuery.Append(" 	AND TBM.MVND_CODE = VEN.VEN_CODE			  ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE TP.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@DATE_YEAR", " DATEPART(YYYY,TP.CLOSE_DATE) = @DATE_YEAR "));

                        //sbWhere.Append(" GROUP BY TP.CLOSE_DATE, VEN.VEN_CODE, VEN.VEN_NAME		  ");
                        sbWhere.Append(" GROUP BY TP.PLT_CODE, TP.CLOSE_DATE, TBM.BALJU_NUM ");

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

        public static DataTable TMAT_YPGO_QUERY6(DataTable dtParam, BizExecute.BizExecute bizExecute)
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
                    sbQuery.Append(" FROM TMAT_YPGO Y");


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

        public static DataTable TMAT_YPGO_QUERY7(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    //sbQuery.Append(" SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED");
                    //sbQuery.Append(" SELECT");
                    //sbQuery.Append(" Y.PLT_CODE");
                    //sbQuery.Append(" ,LEFT(Y.YPGO_DATE,6) AS CLOSE_MONTH");
                    //sbQuery.Append(" ,SP.MAT_LTYPE");
                    //sbQuery.Append(" ,SP.MAT_MTYPE");
                    //sbQuery.Append(" ,SP.MAT_STYPE");
                    //sbQuery.Append(" ,BM.MVND_CODE");
                    //sbQuery.Append(" ,V.VEN_NAME AS MVND_NAME");
                    //sbQuery.Append(" ,SUM(ISNULL(Y.QTY, 0)) AS QTY");
                    //sbQuery.Append(" ,SUM(ISNULL(Y.AMT, 0)) AS AMT");
                    //sbQuery.Append(" FROM TMAT_YPGO Y");
                    //sbQuery.Append(" LEFT JOIN TMAT_BALJU_MASTER BM");
                    //sbQuery.Append(" ON Y.PLT_CODE = BM.PLT_CODE");
                    //sbQuery.Append(" AND Y.BALJU_NUM = BM.BALJU_NUM");
                    //sbQuery.Append(" LEFT JOIN TMAT_BALJU B");
                    //sbQuery.Append(" ON Y.PLT_CODE = B.PLT_CODE");
                    //sbQuery.Append(" AND Y.BALJU_NUM = B.BALJU_NUM");
                    //sbQuery.Append(" AND Y.BALJU_SEQ = B.BALJU_SEQ");
                    //sbQuery.Append(" LEFT JOIN LSE_STD_PART SP");
                    //sbQuery.Append(" ON B.PLT_CODE = SP.PLT_CODE");
                    //sbQuery.Append(" AND B.PART_CODE = SP.PART_CODE");
                    //sbQuery.Append(" LEFT JOIN TSTD_VENDOR V");
                    //sbQuery.Append(" ON BM.PLT_CODE = V.PLT_CODE");
                    //sbQuery.Append(" AND BM.MVND_CODE = V.VEN_CODE");
                    //sbQuery.Append(" WHERE LEFT(Y.YPGO_DATE, 4) = @YEAR");
                    //sbQuery.Append(" AND BM.BAL_STAT <> '14' AND B.BAL_STAT <> '14'");
                    //sbQuery.Append(" AND SP.MAT_LTYPE IS NOT NULL");
                    //sbQuery.Append(" AND SP.MAT_MTYPE IS NOT NULL");
                    //sbQuery.Append(" AND ISNULL(MVND_CODE, '0') <> '0'");

                    //sbQuery.Append(" GROUP BY");
                    //sbQuery.Append(" Y.PLT_CODE");
                    //sbQuery.Append(" ,LEFT(Y.YPGO_DATE,6)");
                    //sbQuery.Append(" ,SP.MAT_LTYPE");
                    //sbQuery.Append(" ,SP.MAT_MTYPE");
                    //sbQuery.Append(" ,SP.MAT_STYPE");
                    //sbQuery.Append(" ,BM.MVND_CODE");
                    //sbQuery.Append(" ,V.VEN_NAME");

                    sbQuery.Append(" SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED");
                    sbQuery.Append(" SELECT");
                    sbQuery.Append(" A.PLT_CODE");
                    sbQuery.Append(" ,A.CLOSE_MONTH");
                    sbQuery.Append(" ,A.MAT_LTYPE");
                    sbQuery.Append(" ,A.MAT_MTYPE");
                    sbQuery.Append(" ,A.MVND_CODE");
                    sbQuery.Append(" ,A.MVND_NAME");
                    sbQuery.Append(" ,SUM(A.QTY) AS QTY");
                    sbQuery.Append(" ,SUM(A.AMT) AS AMT");
                    sbQuery.Append(" FROM");
                    sbQuery.Append(" (");
                    sbQuery.Append(" SELECT");
                    sbQuery.Append(" Y.PLT_CODE");
                    sbQuery.Append(" ,LEFT(Y.YPGO_DATE,6) AS CLOSE_MONTH");
                    sbQuery.Append(" ,SP.MAT_LTYPE");
                    sbQuery.Append(" ,SP.MAT_MTYPE");
                    sbQuery.Append(" ,SP.MAT_STYPE");
                    sbQuery.Append(" ,BM.MVND_CODE");
                    sbQuery.Append(" ,V.VEN_NAME AS MVND_NAME");
                    sbQuery.Append(" ,SUM(ISNULL(Y.QTY, 0)) AS QTY");
                    sbQuery.Append(" ,SUM(ISNULL(Y.AMT, 0)) AS AMT");
                    sbQuery.Append(" FROM TMAT_YPGO Y");
                    sbQuery.Append(" LEFT JOIN TMAT_BALJU_MASTER BM");
                    sbQuery.Append(" ON Y.PLT_CODE = BM.PLT_CODE");
                    sbQuery.Append(" AND Y.BALJU_NUM = BM.BALJU_NUM");
                    sbQuery.Append(" LEFT JOIN TMAT_BALJU B");
                    sbQuery.Append(" ON Y.PLT_CODE = B.PLT_CODE");
                    sbQuery.Append(" AND Y.BALJU_NUM = B.BALJU_NUM");
                    sbQuery.Append(" AND Y.BALJU_SEQ = B.BALJU_SEQ");
                    sbQuery.Append(" LEFT JOIN LSE_STD_PART SP");
                    sbQuery.Append(" ON B.PLT_CODE = SP.PLT_CODE");
                    sbQuery.Append(" AND B.PART_CODE = SP.PART_CODE");
                    sbQuery.Append(" LEFT JOIN TSTD_VENDOR V");
                    sbQuery.Append(" ON BM.PLT_CODE = V.PLT_CODE");
                    sbQuery.Append(" AND BM.MVND_CODE = V.VEN_CODE");
                    sbQuery.Append(" WHERE LEFT(Y.YPGO_DATE, 4) = @YEAR");
                    sbQuery.Append(" AND BM.BAL_STAT <> '14' AND B.BAL_STAT <> '14'");
                    sbQuery.Append(" AND SP.MAT_LTYPE IS NOT NULL");
                    sbQuery.Append(" AND SP.MAT_MTYPE IS NOT NULL");
                    sbQuery.Append(" AND ISNULL(MVND_CODE, '0') <> '0'");
                    sbQuery.Append(" GROUP BY");
                    sbQuery.Append(" Y.PLT_CODE");
                    sbQuery.Append(" ,LEFT(Y.YPGO_DATE,6)");
                    sbQuery.Append(" ,SP.MAT_LTYPE");
                    sbQuery.Append(" ,SP.MAT_MTYPE");
                    sbQuery.Append(" ,SP.MAT_STYPE");
                    sbQuery.Append(" ,BM.MVND_CODE");
                    sbQuery.Append(" ,V.VEN_NAME");
                    sbQuery.Append(" UNION ALL");
                    sbQuery.Append(" SELECT");
                    sbQuery.Append(" PY.PLT_CODE");
                    sbQuery.Append(" ,PY.YPGO_DATE");
                    sbQuery.Append(" ,'7' AS MAT_LTYPE");
                    sbQuery.Append(" ,'32' AS MAT_MTYPE");
                    sbQuery.Append(" ,NULL AS MAT_STYPE");
                    sbQuery.Append(" ,BM.OVND_CODE");
                    sbQuery.Append(" ,V.VEN_NAME");
                    sbQuery.Append(" ,SUM(ISNULL(PY.QTY, 0)) AS QTY");
                    sbQuery.Append(" ,SUM(ISNULL(PY.AMT, 0)) AS AMT");
                    sbQuery.Append(" FROM TOUT_PROCYPGO PY");
                    sbQuery.Append(" LEFT JOIN TOUT_PROCBALJU_MASTER BM");
                    sbQuery.Append(" ON PY.PLT_CODE = BM.PLT_CODE");
                    sbQuery.Append(" AND PY.BALJU_NUM = BM.BALJU_NUM");
                    sbQuery.Append(" LEFT JOIN TOUT_PROCBALJU B");
                    sbQuery.Append(" ON PY.PLT_CODE = B.PLT_CODE");
                    sbQuery.Append(" AND PY.BALJU_NUM = B.BALJU_NUM");
                    sbQuery.Append(" AND PY.BALJU_SEQ = B.BALJU_SEQ");
                    sbQuery.Append(" LEFT JOIN TSHP_WORKORDER W");
                    sbQuery.Append(" ON B.PLT_CODE = W.PLT_CODE");
                    sbQuery.Append(" AND B.WO_NO = W.WO_NO");
                    sbQuery.Append(" LEFT JOIN TSTD_VENDOR V");
                    sbQuery.Append(" ON BM.PLT_CODE = V.PLT_CODE");
                    sbQuery.Append(" AND BM.OVND_CODE = V.VEN_CODE");
                    sbQuery.Append(" WHERE LEFT(PY.YPGO_DATE, 4) = @YEAR");
                    sbQuery.Append(" AND PY.YPGO_STAT <> '23'");
                    sbQuery.Append(" AND ISNULL(OVND_CODE, '0') <> '0'");
                    sbQuery.Append(" GROUP BY");
                    sbQuery.Append(" PY.PLT_CODE");
                    sbQuery.Append(" ,PY.YPGO_DATE");
                    sbQuery.Append(" ,BM.OVND_CODE");
                    sbQuery.Append(" ,V.VEN_NAME");
                    sbQuery.Append(" )A");
                    sbQuery.Append(" GROUP BY A.PLT_CODE");
                    sbQuery.Append(" ,A.CLOSE_MONTH");
                    sbQuery.Append(" ,A.MAT_LTYPE");
                    sbQuery.Append(" ,A.MAT_MTYPE");
                    sbQuery.Append(" ,A.MVND_CODE");
                    sbQuery.Append(" ,A.MVND_NAME");


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

        public static DataTable TMAT_YPGO_QUERY8(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    //sbQuery.Append(" SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED");
                    //sbQuery.Append(" SELECT");
                    //sbQuery.Append(" Y.PLT_CODE");
                    //sbQuery.Append(" ,LEFT(Y.YPGO_DATE,6) AS CLOSE_MONTH");
                    //sbQuery.Append(" ,SP.MAT_LTYPE");
                    //sbQuery.Append(" ,SP.MAT_MTYPE");
                    //sbQuery.Append(" ,SP.MAT_STYPE");
                    //sbQuery.Append(" ,BM.MVND_CODE");
                    //sbQuery.Append(" ,V.VEN_NAME AS MVND_NAME");
                    //sbQuery.Append(" ,SUM(ISNULL(Y.QTY, 0)) AS QTY");
                    //sbQuery.Append(" ,SUM(ISNULL(Y.AMT, 0)) AS AMT");
                    //sbQuery.Append(" FROM TMAT_YPGO Y");
                    //sbQuery.Append(" LEFT JOIN TMAT_BALJU_MASTER BM");
                    //sbQuery.Append(" ON Y.PLT_CODE = BM.PLT_CODE");
                    //sbQuery.Append(" AND Y.BALJU_NUM = BM.BALJU_NUM");
                    //sbQuery.Append(" LEFT JOIN TMAT_BALJU B");
                    //sbQuery.Append(" ON Y.PLT_CODE = B.PLT_CODE");
                    //sbQuery.Append(" AND Y.BALJU_NUM = B.BALJU_NUM");
                    //sbQuery.Append(" AND Y.BALJU_SEQ = B.BALJU_SEQ");
                    //sbQuery.Append(" LEFT JOIN LSE_STD_PART SP");
                    //sbQuery.Append(" ON B.PLT_CODE = SP.PLT_CODE");
                    //sbQuery.Append(" AND B.PART_CODE = SP.PART_CODE");
                    //sbQuery.Append(" LEFT JOIN TSTD_VENDOR V");
                    //sbQuery.Append(" ON BM.PLT_CODE = V.PLT_CODE");
                    //sbQuery.Append(" AND BM.MVND_CODE = V.VEN_CODE");
                    //sbQuery.Append(" WHERE LEFT(Y.YPGO_DATE, 4) = @YEAR");
                    //sbQuery.Append(" AND BM.BAL_STAT <> '14' AND B.BAL_STAT <> '14'");
                    //sbQuery.Append(" AND SP.MAT_LTYPE IS NOT NULL");
                    //sbQuery.Append(" AND SP.MAT_MTYPE IS NOT NULL");
                    //sbQuery.Append(" AND ISNULL(MVND_CODE, '0') <> '0'");

                    //sbQuery.Append(" GROUP BY");
                    //sbQuery.Append(" Y.PLT_CODE");
                    //sbQuery.Append(" ,LEFT(Y.YPGO_DATE,6)");
                    //sbQuery.Append(" ,SP.MAT_LTYPE");
                    //sbQuery.Append(" ,SP.MAT_MTYPE");
                    //sbQuery.Append(" ,SP.MAT_STYPE");
                    //sbQuery.Append(" ,BM.MVND_CODE");
                    //sbQuery.Append(" ,V.VEN_NAME");

                    sbQuery.Append(" SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED");
                    sbQuery.Append(" SELECT");
                    sbQuery.Append(" A.PLT_CODE");
                    sbQuery.Append(" ,A.CLOSE_MONTH");
                    sbQuery.Append(" ,A.MAT_LTYPE");
                    sbQuery.Append(" ,A.MAT_MTYPE");
                    sbQuery.Append(" ,A.MVND_CODE");
                    sbQuery.Append(" ,A.MVND_NAME");
                    sbQuery.Append(" ,SUM(A.QTY) AS QTY");
                    sbQuery.Append(" ,SUM(A.AMT) AS AMT");
                    sbQuery.Append(" FROM");
                    sbQuery.Append(" (");
                    sbQuery.Append(" SELECT");
                    sbQuery.Append(" Y.PLT_CODE");
                    sbQuery.Append(" ,LEFT(Y.YPGO_DATE,6) AS CLOSE_MONTH");
                    sbQuery.Append(" ,SP.MAT_LTYPE");
                    sbQuery.Append(" ,SP.MAT_MTYPE");
                    sbQuery.Append(" ,SP.MAT_STYPE");
                    sbQuery.Append(" ,BM.MVND_CODE");
                    sbQuery.Append(" ,V.VEN_NAME AS MVND_NAME");
                    sbQuery.Append(" ,SUM(ISNULL(Y.QTY, 0)) AS QTY");
                    sbQuery.Append(" ,SUM(ISNULL(Y.AMT, 0)) AS AMT");
                    sbQuery.Append(" FROM TMAT_YPGO Y");
                    sbQuery.Append(" LEFT JOIN TMAT_BALJU_MASTER BM");
                    sbQuery.Append(" ON Y.PLT_CODE = BM.PLT_CODE");
                    sbQuery.Append(" AND Y.BALJU_NUM = BM.BALJU_NUM");
                    sbQuery.Append(" LEFT JOIN TMAT_BALJU B");
                    sbQuery.Append(" ON Y.PLT_CODE = B.PLT_CODE");
                    sbQuery.Append(" AND Y.BALJU_NUM = B.BALJU_NUM");
                    sbQuery.Append(" AND Y.BALJU_SEQ = B.BALJU_SEQ");
                    sbQuery.Append(" LEFT JOIN LSE_STD_PART SP");
                    sbQuery.Append(" ON B.PLT_CODE = SP.PLT_CODE");
                    sbQuery.Append(" AND B.PART_CODE = SP.PART_CODE");
                    sbQuery.Append(" LEFT JOIN TSTD_VENDOR V");
                    sbQuery.Append(" ON BM.PLT_CODE = V.PLT_CODE");
                    sbQuery.Append(" AND BM.MVND_CODE = V.VEN_CODE");
                    sbQuery.Append(" WHERE LEFT(Y.YPGO_DATE, 6) = @S_MONTH");
                    sbQuery.Append(" AND BM.BAL_STAT <> '14' AND B.BAL_STAT <> '14'");
                    sbQuery.Append(" AND SP.MAT_LTYPE IS NOT NULL");
                    sbQuery.Append(" AND SP.MAT_MTYPE IS NOT NULL");
                    sbQuery.Append(" AND ISNULL(MVND_CODE, '0') <> '0'");
                    sbQuery.Append(" GROUP BY");
                    sbQuery.Append(" Y.PLT_CODE");
                    sbQuery.Append(" ,LEFT(Y.YPGO_DATE,6)");
                    sbQuery.Append(" ,SP.MAT_LTYPE");
                    sbQuery.Append(" ,SP.MAT_MTYPE");
                    sbQuery.Append(" ,SP.MAT_STYPE");
                    sbQuery.Append(" ,BM.MVND_CODE");
                    sbQuery.Append(" ,V.VEN_NAME");
                    sbQuery.Append(" UNION ALL");
                    sbQuery.Append(" SELECT");
                    sbQuery.Append(" PY.PLT_CODE");
                    sbQuery.Append(" ,PY.YPGO_DATE");
                    sbQuery.Append(" ,'7' AS MAT_LTYPE");
                    sbQuery.Append(" ,'32' AS MAT_MTYPE");
                    sbQuery.Append(" ,NULL AS MAT_STYPE");
                    sbQuery.Append(" ,BM.OVND_CODE");
                    sbQuery.Append(" ,V.VEN_NAME");
                    sbQuery.Append(" ,SUM(ISNULL(PY.QTY, 0)) AS QTY");
                    sbQuery.Append(" ,SUM(ISNULL(PY.AMT, 0)) AS AMT");
                    sbQuery.Append(" FROM TOUT_PROCYPGO PY");
                    sbQuery.Append(" LEFT JOIN TOUT_PROCBALJU_MASTER BM");
                    sbQuery.Append(" ON PY.PLT_CODE = BM.PLT_CODE");
                    sbQuery.Append(" AND PY.BALJU_NUM = BM.BALJU_NUM");
                    sbQuery.Append(" LEFT JOIN TOUT_PROCBALJU B");
                    sbQuery.Append(" ON PY.PLT_CODE = B.PLT_CODE");
                    sbQuery.Append(" AND PY.BALJU_NUM = B.BALJU_NUM");
                    sbQuery.Append(" AND PY.BALJU_SEQ = B.BALJU_SEQ");
                    sbQuery.Append(" LEFT JOIN TSHP_WORKORDER W");
                    sbQuery.Append(" ON B.PLT_CODE = W.PLT_CODE");
                    sbQuery.Append(" AND B.WO_NO = W.WO_NO");
                    sbQuery.Append(" LEFT JOIN TSTD_VENDOR V");
                    sbQuery.Append(" ON BM.PLT_CODE = V.PLT_CODE");
                    sbQuery.Append(" AND BM.OVND_CODE = V.VEN_CODE");
                    sbQuery.Append(" WHERE LEFT(PY.YPGO_DATE, 6) = @S_MONTH");
                    sbQuery.Append(" AND PY.YPGO_STAT <> '23'");
                    sbQuery.Append(" AND ISNULL(OVND_CODE, '0') <> '0'");
                    sbQuery.Append(" GROUP BY");
                    sbQuery.Append(" PY.PLT_CODE");
                    sbQuery.Append(" ,PY.YPGO_DATE");
                    sbQuery.Append(" ,BM.OVND_CODE");
                    sbQuery.Append(" ,V.VEN_NAME");
                    sbQuery.Append(" )A");
                    sbQuery.Append(" GROUP BY A.PLT_CODE");
                    sbQuery.Append(" ,A.CLOSE_MONTH");
                    sbQuery.Append(" ,A.MAT_LTYPE");
                    sbQuery.Append(" ,A.MAT_MTYPE");
                    sbQuery.Append(" ,A.MVND_CODE");
                    sbQuery.Append(" ,A.MVND_NAME");


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
