using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace DMAT
{
    public class TMAT_BALJU_MASTER
    {
        public static DataTable TMAT_BALJU_MASTER_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("  SELECT  ");
                    sbQuery.Append("  PLT_CODE ");
                    sbQuery.Append(" ,BALJU_NUM ");
                    sbQuery.Append(" ,MVND_CODE ");
                    sbQuery.Append(" ,BALJU_DATE ");
                    sbQuery.Append(" ,BAL_STAT ");
                    sbQuery.Append(" ,BAL_TYPE ");
                    sbQuery.Append(" ,CONFIRM_DATE ");
                    sbQuery.Append(" ,CONFIRM_EMP ");
                    sbQuery.Append(" ,INCL_VAT ");
                    sbQuery.Append(" ,SPLIT ");
                    sbQuery.Append(" ,DELIVERY_LOCATION ");
                    sbQuery.Append(" ,PAY_CONDITION ");
                    sbQuery.Append(" ,YPGO_CHARGE ");
                    sbQuery.Append(" ,CHK_MEASURE ");
                    sbQuery.Append(" ,CHK_PERFORM ");
                    sbQuery.Append(" ,CHK_ATTEND ");
                    sbQuery.Append(" ,CHK_TEST ");
                    sbQuery.Append(" ,CHK_MEEL ");
                    sbQuery.Append(" ,CHK_ADD1 ");
                    sbQuery.Append(" ,CHK_ADD2 ");
                    sbQuery.Append(" ,CHK_ADD3 ");
                    sbQuery.Append(" ,CHARGE_EMP ");
                    sbQuery.Append(" ,CHARGE_PHONE ");
                    sbQuery.Append(" ,CHARGE_EMAIL ");
                    sbQuery.Append(" ,SCOMMENT ");
                    sbQuery.Append(" ,CHK_RD");
                    sbQuery.Append(" ,APP_STATUS ");
                    sbQuery.Append(" ,APP_EMP1 ");
                    sbQuery.Append(" ,APP_EMP_FLAG1 ");
                    sbQuery.Append(" ,APP_EMP2 ");
                    sbQuery.Append(" ,APP_EMP_FLAG2 ");
                    sbQuery.Append(" ,APP_EMP3 ");
                    sbQuery.Append(" ,APP_EMP_FLAG3 ");
                    sbQuery.Append(" ,APP_EMP4 ");
                    sbQuery.Append(" ,APP_EMP_FLAG4 ");
                    sbQuery.Append(" ,REG_DATE ");
                    sbQuery.Append(" ,REG_EMP ");
                    sbQuery.Append("  FROM TMAT_BALJU_MASTER  ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("  AND BALJU_NUM = @BALJU_NUM  ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "BALJU_NUM")) isHasColumn = false;

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


        public static void TMAT_BALJU_MASTER_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" INSERT INTO TMAT_BALJU_MASTER ");
                    sbQuery.Append(" ( ");
                    sbQuery.Append("        PLT_CODE ");
                    sbQuery.Append("      , BALJU_NUM ");
                    sbQuery.Append("      , MVND_CODE ");
                    sbQuery.Append("      , BALJU_DATE ");
                    sbQuery.Append("      , BAL_STAT ");
                    sbQuery.Append("      , BAL_TYPE ");
                    sbQuery.Append("      , INCL_VAT ");
                    sbQuery.Append("      , SPLIT ");
                    sbQuery.Append("      , DELIVERY_LOCATION ");
                    sbQuery.Append("      , PAY_CONDITION ");
                    sbQuery.Append("      , YPGO_CHARGE ");
                    sbQuery.Append("      , CHK_MEASURE ");
                    sbQuery.Append("      , CHK_PERFORM ");
                    sbQuery.Append("      , CHK_ATTEND ");
                    sbQuery.Append("      , CHK_TEST ");
                    sbQuery.Append("      , CHK_MEEL ");
                    sbQuery.Append("      , CHK_ADD1 ");
                    sbQuery.Append("      , CHK_ADD2 ");
                    sbQuery.Append("      , CHK_ADD3 ");
                    sbQuery.Append("      , CHARGE_EMP ");
                    sbQuery.Append("      , CHARGE_PHONE ");
                    sbQuery.Append("      , CHARGE_EMAIL ");
                    sbQuery.Append("      , SCOMMENT ");
                    sbQuery.Append("      , CHK_RD ");
                    sbQuery.Append("      , APP_ORG ");
                    sbQuery.Append("      , APP_EMP1 ");
                    sbQuery.Append("      , APP_EMP2 ");
                    sbQuery.Append("      , APP_EMP3 ");
                    sbQuery.Append("      , APP_EMP4 ");
                    sbQuery.Append("      , REG_DATE ");
                    sbQuery.Append("      , REG_EMP ");
                    sbQuery.Append(" ) ");
                    sbQuery.Append(" VALUES ");
                    sbQuery.Append(" ( ");
                    sbQuery.Append("        @PLT_CODE ");
                    sbQuery.Append("      , @BALJU_NUM ");
                    sbQuery.Append("      , @MVND_CODE ");
                    sbQuery.Append("      , @BALJU_DATE ");
                    sbQuery.Append("      , @BAL_STAT ");
                    sbQuery.Append("      , @BAL_TYPE ");
                    sbQuery.Append("      , @INCL_VAT ");
                    sbQuery.Append("      , @SPLIT ");
                    sbQuery.Append("      , @DELIVERY_LOCATION ");
                    sbQuery.Append("      , @PAY_CONDITION ");
                    sbQuery.Append("      , @YPGO_CHARGE ");
                    sbQuery.Append("      , @CHK_MEASURE ");
                    sbQuery.Append("      , @CHK_PERFORM ");
                    sbQuery.Append("      , @CHK_ATTEND ");
                    sbQuery.Append("      , @CHK_TEST ");
                    sbQuery.Append("      , @CHK_MEEL ");
                    sbQuery.Append("      , @CHK_ADD1 ");
                    sbQuery.Append("      , @CHK_ADD2 ");
                    sbQuery.Append("      , @CHK_ADD3 ");
                    sbQuery.Append("      , @CHARGE_EMP ");
                    sbQuery.Append("      , @CHARGE_PHONE ");
                    sbQuery.Append("      , @CHARGE_EMAIL ");
                    sbQuery.Append("      , @SCOMMENT ");
                    sbQuery.Append("      , @CHK_RD ");
                    sbQuery.Append("      , @APP_ORG ");
                    sbQuery.Append("      , @APP_EMP1 ");
                    sbQuery.Append("      , @APP_EMP2 ");
                    sbQuery.Append("      , @APP_EMP3 ");
                    sbQuery.Append("      , @APP_EMP4 ");
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

        public static void TMAT_BALJU_MASTER_UPD(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    
                    sbQuery.Append(" UPDATE TMAT_BALJU_MASTER ");
                    sbQuery.Append("    SET   BAL_STAT = @BAL_STAT ");
                    sbQuery.Append("        , CONFIRM_DATE = @CONFIRM_DATE ");
                    sbQuery.Append("        , CONFIRM_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("    AND BALJU_NUM = @BALJU_NUM ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "BALJU_NUM")) isHasColumn = false;

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


        public static void TMAT_BALJU_MASTER_UPD2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TMAT_BALJU_MASTER ");
                    sbQuery.Append("    SET   BAL_STAT = @BAL_STAT ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("    AND BALJU_NUM = @BALJU_NUM ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "BALJU_NUM")) isHasColumn = false;

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

        public static void TMAT_BALJU_MASTER_UPD3(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TMAT_BALJU_MASTER SET");
                    sbQuery.Append("  APP_STATUS = @APP_STATUS ");
                    sbQuery.Append(" ,APP_EMP1 = @APP_EMP1 ");
                    sbQuery.Append(" ,APP_EMP_FLAG1 = @APP_EMP_FLAG1 ");
                    sbQuery.Append(" ,APP_EMP2 = @APP_EMP2 ");
                    sbQuery.Append(" ,APP_EMP_FLAG2 = @APP_EMP_FLAG2 ");
                    sbQuery.Append(" ,APP_EMP3 = @APP_EMP3 ");
                    sbQuery.Append(" ,APP_EMP_FLAG3 = @APP_EMP_FLAG3 ");
                    sbQuery.Append(" ,APP_EMP4 = @APP_EMP4 ");
                    sbQuery.Append(" ,APP_EMP_FLAG4 = @APP_EMP_FLAG4 ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("    AND BALJU_NUM = @BALJU_NUM ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "BALJU_NUM")) isHasColumn = false;

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

        public static void TMAT_BALJU_MASTER_UPD4(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TMAT_BALJU_MASTER SET");
                    sbQuery.Append("  DELIVERY = @DELIVERY ");
                    sbQuery.Append(" ,SHIP_DATE = @SHIP_DATE ");
                    sbQuery.Append(" ,SHIPMENT = @SHIPMENT ");
                    sbQuery.Append(" ,PO_NO = @PO_NO ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("    AND BALJU_NUM = @BALJU_NUM ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "BALJU_NUM")) isHasColumn = false;

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


        public static void TMAT_BALJU_MASTER_UPD5(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TMAT_BALJU_MASTER SET");
                    sbQuery.Append("  SCOMMENT = @SCOMMENT ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("    AND BALJU_NUM = @BALJU_NUM ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "BALJU_NUM")) isHasColumn = false;

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

    public class TMAT_BALJU_MASTER_QUERY
    {

        public static DataTable TMAT_BALJU_MASTER_QUERY1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT DISTINCT BM.PLT_CODE ");
                    sbQuery.Append("       ,BM.BAL_TYPE ");
                    sbQuery.Append("       ,BM.MVND_CODE AS VEN_CODE ");
                    sbQuery.Append("       ,V.VEN_NAME ");
                    sbQuery.Append("       ,V.VEN_EMAIL ");
                    sbQuery.Append(" FROM TMAT_BALJU_MASTER BM ");
                    sbQuery.Append("  JOIN TSTD_VENDOR V ");
                    sbQuery.Append(" ON BM.PLT_CODE = V.PLT_CODE ");
                    sbQuery.Append(" AND BM.MVND_CODE = V.VEN_CODE ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE BM.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@S_BALJU_DATE,@E_BALJU_DATE", " (BM.BALJU_DATE BETWEEN @S_BALJU_DATE AND @E_BALJU_DATE)"));
                        sbWhere.Append(UTIL.GetWhere(row, "@BAL_STAT", " BAL_STAT = @BAL_STAT "));
                        sbWhere.Append(UTIL.GetWhere(row, "@PUR", " BAL_STAT IN ('11', '19', '21', '22', '43') "));

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

        public static DataTable TMAT_BALJU_MASTER_QUERY2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT BM.PLT_CODE ");
                    sbQuery.Append("       ,BM.MVND_CODE ");
                    sbQuery.Append("       ,BM.BALJU_NUM ");
                    sbQuery.Append("       ,BM.BALJU_DATE ");
                    sbQuery.Append("       ,BM.CONFIRM_DATE ");
                    sbQuery.Append("       ,BM.BAL_STAT ");
                    sbQuery.Append("       ,BM.REG_EMP ");
                    sbQuery.Append("       ,E.EMP_NAME AS REG_EMP_NAME ");
                    sbQuery.Append("       ,BM.SCOMMENT ");
                    sbQuery.Append("       ,BM.BAL_TYPE ");
                    sbQuery.Append("       ,BM.INCL_VAT ");
                    sbQuery.Append("       ,BM.SPLIT ");
                    sbQuery.Append("       ,BM.DELIVERY_LOCATION ");
                    sbQuery.Append("       ,BM.PAY_CONDITION ");
                    sbQuery.Append("       ,BM.YPGO_CHARGE ");
                    sbQuery.Append("       ,BM.CHK_MEASURE ");
                    sbQuery.Append("       ,BM.CHK_PERFORM ");
                    sbQuery.Append("       ,BM.CHK_ATTEND ");
                    sbQuery.Append("       ,BM.CHK_TEST ");
                    sbQuery.Append("       ,BM.CHK_MEEL ");
                    sbQuery.Append("       ,BM.CHK_ADD1 ");
                    sbQuery.Append("       ,BM.CHK_ADD2 ");
                    sbQuery.Append("       ,BM.CHK_ADD3 ");
                    sbQuery.Append("       ,BM.CHARGE_EMP ");
                    sbQuery.Append("       ,BM.CHARGE_PHONE ");
                    sbQuery.Append("       ,BM.CHARGE_EMAIL ");
                    sbQuery.Append("       ,BM.SCOMMENT ");
                    sbQuery.Append("       ,BM.CHK_RD");
                    sbQuery.Append("       ,V.VEN_NAME ");
                    sbQuery.Append("       ,V.VEN_CEO ");
                    sbQuery.Append("       ,V.VEN_CHARGE_EMP ");
                    sbQuery.Append("       ,V.VEN_CHARGE_TEL ");
                    sbQuery.Append("       ,V.VEN_CHARGE_HP ");
                    sbQuery.Append("       ,V.VEN_EMAIL ");
                    sbQuery.Append("       ,V.VEN_EMAIL_CC ");
                    sbQuery.Append("       ,V.USE_GLOBAL ");
                    sbQuery.Append("       ,V.ENG_VEN_NAME ");
                    sbQuery.Append("       ,V.ENG_VEN_ADDR ");
                    sbQuery.Append("       ,V.ENG_VEN_ADDR2 ");
                    sbQuery.Append("       ,V.VEN_TEL ");
                    sbQuery.Append("       ,V.VEN_FAX ");

                    sbQuery.Append(" ,BM.DELIVERY");
                    sbQuery.Append(" ,BM.SHIP_DATE");
                    sbQuery.Append(" ,BM.SHIPMENT");
                    sbQuery.Append(" ,BM.PO_NO");

                    sbQuery.Append(" ,BM.APP_STATUS");
                    sbQuery.Append(" ,BM.APP_EMP1 AS APP_EMP1 ");
                    sbQuery.Append(" ,ISNULL(BM.APP_EMP_FLAG1,'0') AS APP_EMP_FLAG1 ");
                    sbQuery.Append(" ,BM.APP_EMP2 AS APP_EMP2 ");
                    sbQuery.Append(" ,ISNULL(BM.APP_EMP_FLAG2,'0') AS APP_EMP_FLAG2 ");
                    sbQuery.Append(" ,BM.APP_EMP3 AS APP_EMP3 ");
                    sbQuery.Append(" ,ISNULL(BM.APP_EMP_FLAG3,'0') AS APP_EMP_FLAG3 ");
                    sbQuery.Append(" ,BM.APP_EMP4 AS APP_EMP4 ");
                    sbQuery.Append(" ,ISNULL(BM.APP_EMP_FLAG4,'0') AS APP_EMP_FLAG4 ");
                    sbQuery.Append(" FROM TMAT_BALJU_MASTER BM ");
                    sbQuery.Append("  JOIN TSTD_EMPLOYEE E ");
                    sbQuery.Append(" ON BM.PLT_CODE = E.PLT_CODE  ");
                    sbQuery.Append(" AND BM.REG_EMP = E.EMP_CODE ");
                    sbQuery.Append("  JOIN TSTD_VENDOR V ");
                    sbQuery.Append(" ON BM.PLT_CODE = V.PLT_CODE  ");
                    sbQuery.Append(" AND BM.MVND_CODE = V.VEN_CODE ");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE BM.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@S_BALJU_DATE,@E_BALJU_DATE", " (BM.BALJU_DATE BETWEEN @S_BALJU_DATE AND @E_BALJU_DATE)"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_DUE_DATE,@E_DUE_DATE", " BM.BALJU_NUM IN (SELECT BALJU_NUM FROM TMAT_BALJU WHERE PLT_CODE = BM.PLT_CODE AND DUE_DATE BETWEEN @S_DUE_DATE AND @E_DUE_DATE)"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_CONFIRM_DATE,@E_CONFIRM_DATE", " (BM.CONFIRM_DATE BETWEEN @S_CONFIRM_DATE AND @E_CONFIRM_DATE) "));
                        sbWhere.Append(UTIL.GetWhere(row, "@BALJU_NUM", " BM.BALJU_NUM = @BALJU_NUM"));
                        sbWhere.Append(UTIL.GetWhere(row, "@VEN_CODE", " BM.MVND_CODE = @VEN_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@BAL_TYPE", " BM.BAL_TYPE = @BAL_TYPE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@BAL_STAT", " BM.BAL_STAT = @BAL_STAT"));

                        sbWhere.Append(" ORDER BY BM.BALJU_DATE DESC ");
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

        public static DataTable TMAT_BALJU_MASTER_QUERY2_1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT BM.PLT_CODE ");
                    sbQuery.Append("       ,BM.MVND_CODE AS VEN_CODE ");
                    sbQuery.Append("       ,V.VEN_NAME ");
                    sbQuery.Append("       ,'M' AS BAL_TYPE ");
                    sbQuery.Append("       ,BM.BALJU_NUM ");
                    sbQuery.Append("       ,BM.BALJU_DATE ");
                    sbQuery.Append("       ,BM.CONFIRM_DATE ");
                    sbQuery.Append("       ,BM.BAL_STAT ");
                    sbQuery.Append("       ,BM.REG_EMP ");
                    sbQuery.Append("       ,E.EMP_NAME AS REG_EMP_NAME ");
                    sbQuery.Append("       ,BM.CONFIRM_EMP ");
                    sbQuery.Append("       ,CE.EMP_NAME AS CONFIRM_EMP_NAME ");
                    sbQuery.Append("       ,BM.SCOMMENT ");
                    sbQuery.Append(" FROM TMAT_BALJU_MASTER BM ");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE E ");
                    sbQuery.Append(" ON BM.PLT_CODE = E.PLT_CODE  ");
                    sbQuery.Append(" AND BM.REG_EMP = E.EMP_CODE ");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE CE ");
                    sbQuery.Append(" ON BM.PLT_CODE = CE.PLT_CODE  ");
                    sbQuery.Append(" AND BM.CONFIRM_EMP = CE.EMP_CODE ");
                    sbQuery.Append(" LEFT JOIN TSTD_VENDOR V ");
                    sbQuery.Append(" ON BM.PLT_CODE = V.PLT_CODE ");
                    sbQuery.Append(" AND BM.MVND_CODE = V.VEN_CODE ");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE BM.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@S_BALJU_DATE,@E_BALJU_DATE", " (BM.BALJU_DATE BETWEEN @S_BALJU_DATE AND @E_BALJU_DATE)"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_DUE_DATE,@E_DUE_DATE", " BM.BALJU_NUM IN (SELECT BALJU_NUM FROM TMAT_BALJU WHERE PLT_CODE = BM.PLT_CODE AND DUE_DATE BETWEEN @S_DUE_DATE AND @E_DUE_DATE)"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_CONFIRM_DATE,@E_CONFIRM_DATE", " (BM.CONFIRM_DATE BETWEEN @S_CONFIRM_DATE AND @E_CONFIRM_DATE) "));
                        sbWhere.Append(UTIL.GetWhere(row, "@BALJU_NUM", " BM.BALJU_NUM = @BALJU_NUM"));
                        sbWhere.Append(UTIL.GetWhere(row, "@CONFIRM_EMP", " BM.CONFIRM_EMP = @CONFIRM_EMP"));
                        sbWhere.Append(UTIL.GetWhere(row, "@VEN_CODE", " BM.MVND_CODE = @VEN_CODE "));

                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_CODE", " BM.BALJU_NUM IN (SELECT BALJU_NUM  FROM TMAT_BALJU B , TMAT_PUR_PARTLIST PT WHERE  PT.PLT_CODE = B.PLT_CODE AND PT.REQUEST_NO = B.REQUEST_NO AND PT.REQUEST_SEQ = B.REQUEST_SEQ AND PT.PLT_CODE = BM.PLT_CODE AND PT.PROD_CODE = @PROD_CODE ) "));
                        sbWhere.Append(UTIL.GetWhere(row, "@BAL_STAT", " (SELECT COUNT(*) FROM TMAT_BALJU WHERE PLT_CODE = BM.PLT_CODE AND BALJU_NUM = BM.BALJU_NUM AND BAL_STAT IN @BAL_STAT) > 0  ", UTIL.SqlCondType.IN));
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

        //자재발주 마스터
        public static DataTable TMAT_BALJU_MASTER_QUERY3(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT							   ");
                    sbQuery.Append(" BM.PLT_CODE					   ");
                    sbQuery.Append(" ,'M' AS BAL_TYPE				   ");
                    sbQuery.Append(" ,BM.MVND_CODE AS VEN_CODE		   ");
                    sbQuery.Append(" ,V.VEN_NAME AS VEN_NAME		   ");
                    sbQuery.Append(" ,BM.BALJU_NUM					   ");
                    sbQuery.Append(" ,BM.BALJU_DATE					   ");
                    sbQuery.Append(" ,BM.DELIVERY_LOCATION			   ");
                    sbQuery.Append(" ,BM.REG_EMP					   ");
                    sbQuery.Append(" ,E.EMP_NAME AS REG_EMP_NAME	   ");
                    sbQuery.Append(" ,BM.SCOMMENT       			   ");
                    sbQuery.Append(" FROM TMAT_BALJU_MASTER BM		   ");
                    sbQuery.Append(" LEFT JOIN TMAT_BALJU B			   ");
                    sbQuery.Append(" ON BM.PLT_CODE = B.PLT_CODE	   ");
                    sbQuery.Append(" AND BM.BALJU_NUM = B.BALJU_NUM	   ");
                    sbQuery.Append(" 								   ");
                    sbQuery.Append(" LEFT JOIN TMAT_REQUEST RQ		   ");
                    sbQuery.Append(" ON B.PLT_CODE = RQ.PLT_CODE	   ");
                    sbQuery.Append(" AND B.REQUEST_NO = RQ.REQUEST_NO  ");
                    sbQuery.Append(" AND B.REQUEST_SEQ = RQ.REQUEST_SEQ");
                    sbQuery.Append(" 								   ");
                    sbQuery.Append(" LEFT JOIN TSTD_VENDOR V		   ");
                    sbQuery.Append(" ON BM.PLT_CODE = V.PLT_CODE	   ");
                    sbQuery.Append(" AND BM.MVND_CODE = V.VEN_CODE	   ");
                    sbQuery.Append(" 								   ");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE E		   ");
                    sbQuery.Append(" ON BM.PLT_CODE = E.PLT_CODE	   ");
                    sbQuery.Append(" AND BM.REG_EMP = E.EMP_CODE	   ");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE BM.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@S_BALJU_DATE,@E_BALJU_DATE", " (BM.BALJU_DATE BETWEEN @S_BALJU_DATE AND @E_BALJU_DATE)"));
                        sbWhere.Append(UTIL.GetWhere(row, "@BAL_STAT", " B.BAL_STAT = @BAL_STAT"));
                        sbWhere.Append(" AND RQ.PROD_CODE IS NOT NULL");

                        sbWhere.Append(" GROUP BY BM.PLT_CODE");
                        sbWhere.Append(" ,BM.MVND_CODE		 ");
                        sbWhere.Append(" ,V.VEN_NAME		 ");
                        sbWhere.Append(" ,BM.BALJU_NUM		 ");
                        sbWhere.Append(" ,BM.BALJU_DATE		 ");
                        sbWhere.Append(" ,BM.REG_EMP		 ");
                        sbWhere.Append(" ,E.EMP_NAME		 ");
                        sbWhere.Append(" ,BM.SCOMMENT		 ");
                        sbWhere.Append(" ,BM.DELIVERY_LOCATION");

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

        //구매품발주 마스터
        public static DataTable TMAT_BALJU_MASTER_QUERY4(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT							   ");
                    sbQuery.Append(" BM.PLT_CODE					   ");
                    sbQuery.Append(" ,'PM' AS BAL_TYPE				   ");
                    sbQuery.Append(" ,BM.MVND_CODE AS VEN_CODE		   ");
                    sbQuery.Append(" ,V.VEN_NAME AS VEN_NAME		   ");
                    sbQuery.Append(" ,BM.BALJU_NUM					   ");
                    sbQuery.Append(" ,BM.BALJU_DATE					   ");
                    sbQuery.Append(" ,BM.DELIVERY_LOCATION			   ");
                    sbQuery.Append(" ,BM.REG_EMP					   ");
                    sbQuery.Append(" ,E.EMP_NAME AS REG_EMP_NAME	   ");
                    sbQuery.Append(" ,BM.SCOMMENT					   ");
                    sbQuery.Append(" FROM TMAT_BALJU_MASTER BM		   ");
                    sbQuery.Append(" LEFT JOIN TMAT_BALJU B			   ");
                    sbQuery.Append(" ON BM.PLT_CODE = B.PLT_CODE	   ");
                    sbQuery.Append(" AND BM.BALJU_NUM = B.BALJU_NUM	   ");
                    sbQuery.Append(" 								   ");
                    sbQuery.Append(" LEFT JOIN TMAT_REQUEST RQ		   ");
                    sbQuery.Append(" ON B.PLT_CODE = RQ.PLT_CODE	   ");
                    sbQuery.Append(" AND B.REQUEST_NO = RQ.REQUEST_NO  ");
                    sbQuery.Append(" AND B.REQUEST_SEQ = RQ.REQUEST_SEQ");
                    sbQuery.Append(" 								   ");
                    sbQuery.Append(" LEFT JOIN TSTD_VENDOR V		   ");
                    sbQuery.Append(" ON BM.PLT_CODE = V.PLT_CODE	   ");
                    sbQuery.Append(" AND BM.MVND_CODE = V.VEN_CODE	   ");
                    sbQuery.Append(" 								   ");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE E		   ");
                    sbQuery.Append(" ON BM.PLT_CODE = E.PLT_CODE	   ");
                    sbQuery.Append(" AND BM.REG_EMP = E.EMP_CODE	   ");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE BM.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@S_BALJU_DATE,@E_BALJU_DATE", " (BM.BALJU_DATE BETWEEN @S_BALJU_DATE AND @E_BALJU_DATE)"));
                        sbWhere.Append(UTIL.GetWhere(row, "@BAL_STAT", " B.BAL_STAT = @BAL_STAT"));
                        sbWhere.Append(" AND RQ.PROD_CODE IS NULL");

                        sbWhere.Append(" GROUP BY BM.PLT_CODE");
                        sbWhere.Append(" ,BM.MVND_CODE		 ");
                        sbWhere.Append(" ,V.VEN_NAME		 ");
                        sbWhere.Append(" ,BM.BALJU_NUM		 ");
                        sbWhere.Append(" ,BM.BALJU_DATE		 ");
                        sbWhere.Append(" ,BM.REG_EMP		 ");
                        sbWhere.Append(" ,E.EMP_NAME		 ");
                        sbWhere.Append(" ,BM.SCOMMENT		 ");
                        sbWhere.Append(" ,BM.DELIVERY_LOCATION");

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

        public static DataTable TMAT_BALJU_MASTER_QUERY5(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT");
                    sbQuery.Append(" BM.PLT_CODE");
                    sbQuery.Append(" ,BM.BALJU_NUM");
                    sbQuery.Append(" ,BM.BAL_TYPE");
                    sbQuery.Append(" ,BM.BALJU_DATE");
                    sbQuery.Append(" ,BM.MVND_CODE");
                    sbQuery.Append(" ,V.VEN_NAME");
                    sbQuery.Append(" ,BM.INCL_VAT");
                    sbQuery.Append(" ,BM.SPLIT");
                    sbQuery.Append(" ,BM.DELIVERY_LOCATION");
                    sbQuery.Append(" ,BM.PAY_CONDITION");
                    sbQuery.Append(" ,BM.YPGO_CHARGE");
                    sbQuery.Append(" ,BM.CHK_MEASURE");
                    sbQuery.Append(" ,BM.CHK_PERFORM");
                    sbQuery.Append(" ,BM.CHK_ATTEND");
                    sbQuery.Append(" ,BM.CHK_TEST");
                    sbQuery.Append(" ,BM.CHK_MEEL");
                    sbQuery.Append(" ,BM.CHK_ADD1");
                    sbQuery.Append(" ,BM.CHK_ADD2");
                    sbQuery.Append(" ,BM.CHK_ADD3");
                    sbQuery.Append(" ,BM.CHARGE_EMP");
                    sbQuery.Append(" ,BM.CHARGE_PHONE");
                    sbQuery.Append(" ,BM.CHARGE_EMAIL");
                    sbQuery.Append(" ,BM.SCOMMENT");
                    sbQuery.Append(" ,BM.BAL_STAT");
                    sbQuery.Append(" ,BM.APP_STATUS");
                    sbQuery.Append(" ,BM.APP_ORG");
                    sbQuery.Append(" ,BM.CHK_RD");

                    sbQuery.Append(" ,ISNULL(BM.APP_EMP1,APP.APP_EMP1) AS APP_EMP1 ");
                    sbQuery.Append(" ,ISNULL(BM.APP_EMP_FLAG1,'0') AS APP_EMP_FLAG1 ");

                    sbQuery.Append(" ,ISNULL(BM.APP_EMP2,APP.APP_EMP2) AS APP_EMP2 ");
                    sbQuery.Append(" ,ISNULL(BM.APP_EMP_FLAG2,'0') AS APP_EMP_FLAG2 ");

                    sbQuery.Append(" ,ISNULL(BM.APP_EMP3,APP.APP_EMP3) AS APP_EMP3 ");
                    sbQuery.Append(" ,ISNULL(BM.APP_EMP_FLAG3,'0') AS APP_EMP_FLAG3 ");

                    sbQuery.Append(" ,ISNULL(BM.APP_EMP4,APP.APP_EMP4) AS APP_EMP4 ");
                    sbQuery.Append(" ,ISNULL(BM.APP_EMP_FLAG4,'0') AS APP_EMP_FLAG4 ");

                    sbQuery.Append(" ,BM.REG_EMP");
                    sbQuery.Append(" ,E.EMP_NAME AS REG_EMP_NAME");

                    sbQuery.Append(" FROM TMAT_BALJU_MASTER BM");
                    sbQuery.Append(" LEFT JOIN TSTD_VENDOR V");
                    sbQuery.Append(" ON BM.PLT_CODE = V.PLT_CODE");
                    sbQuery.Append(" AND BM.MVND_CODE = V.VEN_CODE");

                    sbQuery.Append(" LEFT JOIN TSTD_APP_EMP APP ");
                    sbQuery.Append(" ON BM.PLT_CODE = APP.PLT_CODE");
                    sbQuery.Append(" AND APP.APP_TYPE = 'PUR' ");
                    sbQuery.Append(" AND BM.APP_ORG = APP.ORG_CODE ");

                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE E");
                    sbQuery.Append(" ON BM.PLT_CODE = E.PLT_CODE");
                    sbQuery.Append(" AND BM.REG_EMP = E.EMP_CODE");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE BM.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                        sbWhere.Append(UTIL.GetWhere(row, "@S_BALJU_DATE,@E_BALJU_DATE", " (BM.BALJU_DATE BETWEEN @S_BALJU_DATE AND @E_BALJU_DATE)"));
                        sbWhere.Append(UTIL.GetWhere(row, "@BALJU_NUM_LIKE", " BM.BALJU_NUM LIKE '%' + @BALJU_NUM_LIKE + '%' "));
                        sbWhere.Append(UTIL.GetWhere(row, "@BALJU_NUM", " BM.BALJU_NUM = @BALJU_NUM"));
                        sbWhere.Append(UTIL.GetWhere(row, "@BAL_STAT", " BM.BAL_STAT = @BAL_STAT"));
                        sbWhere.Append(UTIL.GetWhere(row, "@IS_CANCEL", " BM.BAL_STAT <> '14'"));

                        string sQuery = "((ISNULL(BM.APP_EMP1,APP.APP_EMP1) = @REG_EMP AND ISNULL(BM.APP_EMP_FLAG1,'0') = '0')";
                        sQuery += " OR (ISNULL(BM.APP_EMP2,APP.APP_EMP2) = @REG_EMP AND ISNULL(BM.APP_EMP_FLAG1,'0') = '1' AND ISNULL(BM.APP_EMP_FLAG2,'0') = '0')";
                        sQuery += " OR (ISNULL(BM.APP_EMP3,APP.APP_EMP3) = @REG_EMP AND ISNULL(BM.APP_EMP_FLAG1,'0') = '1' AND ISNULL(BM.APP_EMP_FLAG2,'0') = '1' AND ISNULL(BM.APP_EMP_FLAG3,'0') = '0')";

                        if (dtParam.Columns.Contains("IS_SAN_PUR"))
                        {
                            if (row["IS_SAN_PUR"].ToString() == "1")
                            {
                                sQuery += " OR ISNULL(BM.APP_STATUS, '0') NOT IN ('2','3')";
                            }
                        }

                        sQuery += " OR (ISNULL(BM.APP_EMP4,APP.APP_EMP4) = @REG_EMP AND ISNULL(BM.APP_EMP_FLAG1,'0') = '1' AND ISNULL(BM.APP_EMP_FLAG2,'0') = '1' AND ISNULL(BM.APP_EMP_FLAG3,'0') = '1' AND ISNULL(BM.APP_EMP_FLAG4,'0') = '0'))";




                        sbWhere.Append(UTIL.GetWhere(row, "@REG_EMP", sQuery));

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

        public static DataTable TMAT_BALJU_MASTER_QUERY6(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT");
                    sbQuery.Append(" BM.PLT_CODE");
                    sbQuery.Append(" ,BM.BALJU_NUM");
                    sbQuery.Append(" ,BM.BAL_TYPE");
                    sbQuery.Append(" ,BM.BALJU_DATE");
                    sbQuery.Append(" ,BM.MVND_CODE");
                    sbQuery.Append(" ,V.VEN_NAME");
                    sbQuery.Append(" ,BM.INCL_VAT");
                    sbQuery.Append(" ,BM.SPLIT");
                    sbQuery.Append(" ,BM.DELIVERY_LOCATION");
                    sbQuery.Append(" ,BM.PAY_CONDITION");
                    sbQuery.Append(" ,BM.YPGO_CHARGE");
                    sbQuery.Append(" ,BM.CHK_MEASURE");
                    sbQuery.Append(" ,BM.CHK_PERFORM");
                    sbQuery.Append(" ,BM.CHK_ATTEND");
                    sbQuery.Append(" ,BM.CHK_TEST");
                    sbQuery.Append(" ,BM.CHK_MEEL");
                    sbQuery.Append(" ,BM.CHK_ADD1");
                    sbQuery.Append(" ,BM.CHK_ADD2");
                    sbQuery.Append(" ,BM.CHK_ADD3");
                    sbQuery.Append(" ,BM.CHARGE_EMP");
                    sbQuery.Append(" ,BM.CHARGE_PHONE");
                    sbQuery.Append(" ,BM.CHARGE_EMAIL");
                    sbQuery.Append(" ,BM.SCOMMENT");
                    sbQuery.Append(" ,BM.BAL_STAT");
                    sbQuery.Append(" ,BM.APP_STATUS");
                    sbQuery.Append(" ,BM.CHK_RD");

                    sbQuery.Append(" ,ISNULL(BM.APP_EMP1,APP.APP_EMP1) AS APP_EMP1 ");
                    sbQuery.Append(" ,ISNULL(BM.APP_EMP_FLAG1,'0') AS APP_EMP_FLAG1 ");

                    sbQuery.Append(" ,ISNULL(BM.APP_EMP2,APP.APP_EMP2) AS APP_EMP2 ");
                    sbQuery.Append(" ,ISNULL(BM.APP_EMP_FLAG2,'0') AS APP_EMP_FLAG2 ");

                    sbQuery.Append(" ,ISNULL(BM.APP_EMP3,APP.APP_EMP3) AS APP_EMP3 ");
                    sbQuery.Append(" ,ISNULL(BM.APP_EMP_FLAG3,'0') AS APP_EMP_FLAG3 ");

                    sbQuery.Append(" ,ISNULL(BM.APP_EMP4,APP.APP_EMP4) AS APP_EMP4 ");
                    sbQuery.Append(" ,ISNULL(BM.APP_EMP_FLAG4,'0') AS APP_EMP_FLAG4 ");

                    sbQuery.Append(" ,BM.REG_EMP");
                    sbQuery.Append(" ,E.EMP_NAME AS REG_EMP_NAME");

                    sbQuery.Append(" FROM TMAT_BALJU_MASTER BM");
                    sbQuery.Append(" LEFT JOIN TSTD_VENDOR V");
                    sbQuery.Append(" ON BM.PLT_CODE = V.PLT_CODE");
                    sbQuery.Append(" AND BM.MVND_CODE = V.VEN_CODE");

                    sbQuery.Append(" LEFT JOIN TSTD_APP_EMP APP ");
                    sbQuery.Append(" ON BM.PLT_CODE = APP.PLT_CODE");
                    sbQuery.Append(" AND APP.APP_TYPE = 'PUR' ");
                    sbQuery.Append(" AND BM.APP_ORG = APP.ORG_CODE ");

                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE E");
                    sbQuery.Append(" ON BM.PLT_CODE = E.PLT_CODE");
                    sbQuery.Append(" AND BM.REG_EMP = E.EMP_CODE");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE BM.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                        sbWhere.Append(UTIL.GetWhere(row, "@S_BALJU_DATE,@E_BALJU_DATE", " (BM.BALJU_DATE BETWEEN @S_BALJU_DATE AND @E_BALJU_DATE)"));
                        sbWhere.Append(UTIL.GetWhere(row, "@BALJU_NUM", " BM.BALJU_NUM = @BALJU_NUM"));
                        sbWhere.Append(UTIL.GetWhere(row, "@BALJU_NUM_LIKE", " BM.BALJU_NUM LIKE '%' + @BALJU_NUM_LIKE + '%' "));
                        sbWhere.Append(UTIL.GetWhere(row, "@BAL_STAT", " BM.BAL_STAT = @BAL_STAT"));
                        sbWhere.Append(UTIL.GetWhere(row, "@IS_CANCEL", " BM.BAL_STAT <> '14'"));

                        string sQuery = "((ISNULL(BM.APP_EMP1,APP.APP_EMP1) = @REG_EMP AND ISNULL(BM.APP_EMP_FLAG1,'0') = '1' AND ISNULL(BM.APP_EMP_FLAG2,'0') = '0' AND ISNULL(BM.APP_EMP_FLAG3,'0') = '0' AND ISNULL(BM.APP_EMP_FLAG4,'0') = '0' )";
                        sQuery += " OR (ISNULL(BM.APP_EMP2,APP.APP_EMP2) = @REG_EMP AND ISNULL(BM.APP_EMP_FLAG2,'0') = '1' AND ISNULL(BM.APP_EMP_FLAG3,'0') = '0' AND ISNULL(BM.APP_EMP_FLAG4,'0') = '0')";
                        sQuery += " OR (ISNULL(BM.APP_EMP3,APP.APP_EMP3) = @REG_EMP AND ISNULL(BM.APP_EMP_FLAG3,'0') = '1' AND ISNULL(BM.APP_EMP_FLAG4,'0') = '0')";
                        sQuery += " OR (ISNULL(BM.APP_EMP4,APP.APP_EMP4) = @REG_EMP AND ISNULL(BM.APP_EMP_FLAG4,'0') = '1'))";

                        sbWhere.Append(UTIL.GetWhere(row, "@REG_EMP", sQuery));

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

        public static DataTable TMAT_BALJU_MASTER_QUERY7(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT");
                    sbQuery.Append(" BM.PLT_CODE");
                    sbQuery.Append(" ,BM.BALJU_NUM");
                    sbQuery.Append(" ,BM.BAL_TYPE");
                    sbQuery.Append(" ,BM.BALJU_DATE");
                    sbQuery.Append(" ,BM.MVND_CODE");
                    sbQuery.Append(" ,V.VEN_NAME");
                    sbQuery.Append(" ,BM.INCL_VAT");
                    sbQuery.Append(" ,BM.SPLIT");
                    sbQuery.Append(" ,BM.DELIVERY_LOCATION");
                    sbQuery.Append(" ,BM.PAY_CONDITION");
                    sbQuery.Append(" ,BM.YPGO_CHARGE");
                    sbQuery.Append(" ,BM.CHK_MEASURE");
                    sbQuery.Append(" ,BM.CHK_PERFORM");
                    sbQuery.Append(" ,BM.CHK_ATTEND");
                    sbQuery.Append(" ,BM.CHK_TEST");
                    sbQuery.Append(" ,BM.CHK_MEEL");
                    sbQuery.Append(" ,BM.CHK_ADD1");
                    sbQuery.Append(" ,BM.CHK_ADD2");
                    sbQuery.Append(" ,BM.CHK_ADD3");
                    sbQuery.Append(" ,BM.CHARGE_EMP");
                    sbQuery.Append(" ,BM.CHARGE_PHONE");
                    sbQuery.Append(" ,BM.CHARGE_EMAIL");
                    sbQuery.Append(" ,BM.SCOMMENT");
                    sbQuery.Append(" ,BM.BAL_STAT");
                    sbQuery.Append(" ,BM.APP_STATUS");
                    sbQuery.Append(" ,BM.CHK_RD");

                    sbQuery.Append(" ,BM.REG_EMP");
                    sbQuery.Append(" ,E.EMP_NAME AS REG_EMP_NAME");

                    sbQuery.Append(" ,ISNULL(BM.APP_EMP1,APP.APP_EMP1) AS APP_EMP1 ");
                    sbQuery.Append(" ,ISNULL(BM.APP_EMP_FLAG1,'0') AS APP_EMP_FLAG1 ");

                    sbQuery.Append(" ,ISNULL(BM.APP_EMP2,APP.APP_EMP2) AS APP_EMP2 ");
                    sbQuery.Append(" ,ISNULL(BM.APP_EMP_FLAG2,'0') AS APP_EMP_FLAG2 ");

                    sbQuery.Append(" ,ISNULL(BM.APP_EMP3,APP.APP_EMP3) AS APP_EMP3 ");
                    sbQuery.Append(" ,ISNULL(BM.APP_EMP_FLAG3,'0') AS APP_EMP_FLAG3 ");

                    sbQuery.Append(" ,ISNULL(BM.APP_EMP4,APP.APP_EMP4) AS APP_EMP4 ");
                    sbQuery.Append(" ,ISNULL(BM.APP_EMP_FLAG4,'0') AS APP_EMP_FLAG4 ");
                    sbQuery.Append(" FROM TMAT_BALJU_MASTER BM");
                    sbQuery.Append(" LEFT JOIN TSTD_VENDOR V");
                    sbQuery.Append(" ON BM.PLT_CODE = V.PLT_CODE");
                    sbQuery.Append(" AND BM.MVND_CODE = V.VEN_CODE");

                    sbQuery.Append(" LEFT JOIN TSTD_APP_EMP APP ");
                    sbQuery.Append(" ON BM.PLT_CODE = APP.PLT_CODE");
                    sbQuery.Append(" AND APP.APP_TYPE = 'PUR' ");
                    sbQuery.Append(" AND BM.APP_ORG = APP.ORG_CODE ");

                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE E");
                    sbQuery.Append(" ON BM.PLT_CODE = E.PLT_CODE");
                    sbQuery.Append(" AND BM.REG_EMP = E.EMP_CODE");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE BM.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                        sbWhere.Append(UTIL.GetWhere(row, "@S_BALJU_DATE,@E_BALJU_DATE", " (BM.BALJU_DATE BETWEEN @S_BALJU_DATE AND @E_BALJU_DATE)"));
                        sbWhere.Append(UTIL.GetWhere(row, "@BALJU_NUM", " BM.BALJU_NUM = @BALJU_NUM"));
                        sbWhere.Append(UTIL.GetWhere(row, "@BALJU_NUM_LIKE", " BM.BALJU_NUM LIKE '%' + @BALJU_NUM_LIKE + '%' "));
                        sbWhere.Append(UTIL.GetWhere(row, "@BAL_STAT", " BM.BAL_STAT = @BAL_STAT"));
                        sbWhere.Append(UTIL.GetWhere(row, "@IS_CANCEL", " BM.BAL_STAT <> '14'"));

                        string sQuery = "((ISNULL(BM.APP_EMP1,APP.APP_EMP1) = @REG_EMP AND ISNULL(BM.APP_EMP_FLAG1,'0') = '2' AND ISNULL(BM.APP_EMP_FLAG2,'0') = '0' AND ISNULL(BM.APP_EMP_FLAG3,'0') = '0' AND ISNULL(BM.APP_EMP_FLAG4,'0') = '0' )";
                        sQuery += " OR (ISNULL(BM.APP_EMP2,APP.APP_EMP2) = @REG_EMP AND ISNULL(BM.APP_EMP_FLAG2,'0') = '2' AND ISNULL(BM.APP_EMP_FLAG3,'0') = '0' AND ISNULL(BM.APP_EMP_FLAG4,'0') = '0')";
                        sQuery += " OR (ISNULL(BM.APP_EMP3,APP.APP_EMP3) = @REG_EMP AND ISNULL(BM.APP_EMP_FLAG3,'0') = '2' AND ISNULL(BM.APP_EMP_FLAG4,'0') = '0')";
                        sQuery += " OR (ISNULL(BM.APP_EMP4,APP.APP_EMP4) = @REG_EMP AND ISNULL(BM.APP_EMP_FLAG4,'0') = '2'))";

                        sbWhere.Append(UTIL.GetWhere(row, "@REG_EMP", sQuery));

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
