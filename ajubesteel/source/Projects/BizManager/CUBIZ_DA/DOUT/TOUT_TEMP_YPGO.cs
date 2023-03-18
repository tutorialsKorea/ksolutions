using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace DOUT
{
    public class TOUT_TEMP_YPGO
    {
        public static DataTable TOUT_TEMP_YPGO_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT PLT_CODE ");
                    sbQuery.Append("      , TYP_ID ");
                    sbQuery.Append("      , BALJU_NUM ");
                    sbQuery.Append("      , BALJU_SEQ ");
                    sbQuery.Append("      , TYP_DATE ");
                    sbQuery.Append("      , TYP_QTY ");
                    sbQuery.Append("      , TYP_STAT ");
                    sbQuery.Append("      , TYP_LOC ");
                    sbQuery.Append("      , TYP_LOC_DETAIL ");
                    sbQuery.Append("      , REG_DATE ");
                    sbQuery.Append("      , REG_EMP ");
                    sbQuery.Append("      , MDFY_DATE ");
                    sbQuery.Append("      , MDFY_EMP ");
                    sbQuery.Append("   FROM TOUT_TEMP_YPGO ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("    AND TYP_ID = @TYP_ID  ");
                    sbQuery.Append("    AND TYP_STAT IN ('20','42')  ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "TYP_ID")) isHasColumn = false;

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

        public static void TOUT_TEMP_YPGO_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();


                    sbQuery.Append(" INSERT INTO TOUT_TEMP_YPGO ");
                    sbQuery.Append(" ( ");
                    sbQuery.Append("        PLT_CODE ");
                    sbQuery.Append("      , TYP_ID ");
                    sbQuery.Append("      , BALJU_NUM ");
                    sbQuery.Append("      , BALJU_SEQ ");
                    sbQuery.Append("      , TYP_DATE ");
                    //sbQuery.Append("      , CLOSE_DATE ");
                    sbQuery.Append("      , INS_DATE ");
                    sbQuery.Append("      , TYP_QTY ");
                    sbQuery.Append("      , TYP_STAT ");
                    sbQuery.Append("      , TYP_LOC ");
                    sbQuery.Append("      , TYP_LOC_DETAIL ");
                    sbQuery.Append("      , SCOMMENT ");
                    sbQuery.Append("      , INS_FLAG ");
                    sbQuery.Append("      , REG_DATE ");
                    sbQuery.Append("      , REG_EMP ");
                    sbQuery.Append(" ) ");
                    sbQuery.Append(" VALUES ");
                    sbQuery.Append(" ( ");
                    sbQuery.Append("        @PLT_CODE ");
                    sbQuery.Append("      , @TYP_ID ");
                    sbQuery.Append("      , @BALJU_NUM ");
                    sbQuery.Append("      , @BALJU_SEQ ");
                    sbQuery.Append("      , @TYP_DATE ");
                    //sbQuery.Append("      , @CLOSE_DATE ");
                    sbQuery.Append("      , @INS_DATE ");
                    sbQuery.Append("      , @TYP_QTY ");
                    sbQuery.Append("      , @TYP_STAT ");
                    sbQuery.Append("      , @TYP_LOC ");
                    sbQuery.Append("      , @TYP_LOC_DETAIL ");
                    sbQuery.Append("      , @SCOMMENT ");
                    sbQuery.Append("      , @INS_FLAG ");
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
        public static void TOUT_TEMP_YPGO_UPD(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" UPDATE TOUT_TEMP_YPGO ");
                    sbQuery.Append("    SET   TYP_STAT = @TYP_STAT ");
                    sbQuery.Append("        , MDFY_DATE =  GETDATE() ");
                    sbQuery.Append("        , MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("    AND TYP_ID = @TYP_ID  ");
                                        
                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "TYP_ID")) isHasColumn = false;

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

        public static void TOUT_TEMP_YPGO_UPD2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" UPDATE TOUT_TEMP_YPGO ");
                    sbQuery.Append("    SET   CLOSE_DATE = @CLOSE_DATE ");
                    sbQuery.Append("        , MDFY_DATE =  GETDATE() ");
                    sbQuery.Append("        , MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("    AND TYP_ID = @TYP_ID  ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "TYP_ID")) isHasColumn = false;

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

        public static void TOUT_TEMP_YPGO_UPD3(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TOUT_TEMP_YPGO ");
                    sbQuery.Append("    SET   TYP_STAT = @BAL_STAT ");
                    sbQuery.Append("        , MDFY_DATE =  GETDATE() ");
                    sbQuery.Append("        , MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("    AND TYP_ID = @TYP_ID  ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "TYP_ID")) isHasColumn = false;

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
        public static void TOUT_TEMP_YPGO_UPD4(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" UPDATE TOUT_TEMP_YPGO ");
                    sbQuery.Append("    SET   TYP_STAT = @TYP_STAT ");
                    sbQuery.Append("        , CHECK_DATE = @CHECK_DATE ");
                    sbQuery.Append("        , INS_DATE = @INS_DATE ");
                    sbQuery.Append("        , MDFY_DATE =  GETDATE() ");
                    sbQuery.Append("        , MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("    AND TYP_ID = @TYP_ID  ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "TYP_ID")) isHasColumn = false;

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
        public static void TOUT_TEMP_YPGO_DEL(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" DELETE FROM TOUT_TEMP_YPGO ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("    AND TYP_ID = @TYP_ID  ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "TYP_ID")) isHasColumn = false;

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



    public class TOUT_TEMP_YPGO_QUERY
    {
        public static DataTable TOUT_TEMP_YPGO_QUERY2(DataTable dtParam, BizExecute.BizExecute bizExecute)
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
                    sbQuery.Append(" ,Y.INS_FLAG ");
                    sbQuery.Append(" ,B.REG_EMP AS BALJU_REG_EMP ");
                    sbQuery.Append(" ,R.REG_EMP AS REQ_REG_EMP ");
                    sbQuery.Append(" ,Y.REG_EMP ");
                    sbQuery.Append(" ,I.CVND_CODE ");
                    sbQuery.Append(" FROM TOUT_TEMP_YPGO Y ");
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
        public static DataTable TOUT_TEMP_YPGO_QUERY3(DataTable dtParam, BizExecute.BizExecute bizExecute)
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
                    sbQuery.Append(" FROM TOUT_TEMP_YPGO Y 													   ");
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


    }
}
