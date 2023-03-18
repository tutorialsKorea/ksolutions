using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace DMAT
{
    public class TMAT_BALJU
    {
        public static DataTable TMAT_BALJU_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
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
                    sbQuery.Append(" ,BALJU_SEQ ");
                    sbQuery.Append(" ,REQUEST_NO ");
                    sbQuery.Append(" ,REQUEST_SEQ ");
                    sbQuery.Append(" ,PART_CODE ");
                    sbQuery.Append(" ,DUE_DATE ");
                    sbQuery.Append(" ,UNIT_COST ");
                    sbQuery.Append(" ,QTY ");
                    sbQuery.Append(" ,OK_QTY ");
                    sbQuery.Append(" ,AMT ");
                    sbQuery.Append(" ,CHG_UNIT_COST ");
                    sbQuery.Append(" ,MAT_SPEC ");
                    sbQuery.Append(" ,MAT_WEIGHT ");
                    sbQuery.Append(" ,BAL_STAT ");
                    sbQuery.Append(" ,SCOMMENT ");
                    sbQuery.Append(" ,INS_FLAG ");
                    sbQuery.Append(" ,INS_DATE ");
                    sbQuery.Append(" ,INS_EMP ");
                    sbQuery.Append(" ,C_REASON ");
                    sbQuery.Append(" ,REG_DATE ");
                    sbQuery.Append(" ,REG_EMP ");
                    sbQuery.Append(" ,MDFY_DATE ");
                    sbQuery.Append(" ,MDFY_EMP ");
                    sbQuery.Append(" ,TYP_LOC ");
                    sbQuery.Append("  FROM TMAT_BALJU  ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("  AND BALJU_NUM = @BALJU_NUM  ");
                    sbQuery.Append("  AND BALJU_SEQ = @BALJU_SEQ  ");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "BALJU_NUM")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "BALJU_SEQ")) isHasColumn = false;

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

        //발주수량, 입고수량  확인
        public static DataTable TMAT_BALJU_SER2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {

            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT  ");
                    sbQuery.Append(" B.PLT_CODE ");
                    sbQuery.Append(" ,B.BALJU_NUM ");
                    sbQuery.Append(" ,B.BALJU_SEQ ");
                    sbQuery.Append(" ,B.QTY AS BAL_QTY ");
                    sbQuery.Append(" ,ISNULL(Y.QTY,0) AS YPGO_QTY ");
                    sbQuery.Append(" FROM TMAT_BALJU B ");
                    sbQuery.Append(" JOIN TMAT_BALJU_MASTER BM ");
                    sbQuery.Append(" ON B.PLT_CODE = BM.PLT_CODE ");
                    sbQuery.Append(" AND B.BALJU_NUM = BM.BALJU_NUM ");
                    sbQuery.Append(" LEFT JOIN  ");
                    sbQuery.Append(" ( ");
                    sbQuery.Append(" SELECT PLT_CODE , BALJU_NUM , BALJU_SEQ , ISNULL(SUM(QTY),0) AS QTY FROM TMAT_YPGO   ");
                    sbQuery.Append(" WHERE YPGO_STAT IN ('19','25','31','32') ");
                    sbQuery.Append(" GROUP BY PLT_CODE , BALJU_NUM ,BALJU_SEQ ");
                    sbQuery.Append(" ) Y ");
                    sbQuery.Append(" ON B.PLT_CODE = Y.PLT_CODE ");
                    sbQuery.Append(" AND B.BALJU_NUM = Y.BALJU_NUM ");
                    sbQuery.Append(" AND B.BALJU_SEQ = Y.BALJU_SEQ ");
                    sbQuery.Append(" WHERE B.PLT_CODE = @PLT_CODE ");
                    sbQuery.Append(" AND B.BALJU_NUM = @BALJU_NUM ");
                    sbQuery.Append(" AND B.BALJU_SEQ = @BALJU_SEQ ");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "BALJU_NUM")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "BALJU_SEQ")) isHasColumn = false;

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

        public static void TMAT_BALJU_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" INSERT INTO TMAT_BALJU ");
                    sbQuery.Append(" ( ");
                    sbQuery.Append("        PLT_CODE ");
                    sbQuery.Append("      , BALJU_NUM ");
                    sbQuery.Append("      , BALJU_SEQ ");
                    sbQuery.Append("      , REQUEST_NO ");
                    sbQuery.Append("      , REQUEST_SEQ ");
                    sbQuery.Append("      , PART_CODE ");
                    sbQuery.Append("      , DUE_DATE ");
                    sbQuery.Append("      , UNIT_COST ");
                    sbQuery.Append("      , QTY ");
                    sbQuery.Append("      , AMT ");
                    sbQuery.Append("      , MAT_SPEC ");
                    sbQuery.Append("      , MAT_WEIGHT ");
                    sbQuery.Append("      , BAL_STAT ");
                    sbQuery.Append("      , INS_FLAG ");
                    sbQuery.Append("      , BAL_UNIT ");
                    sbQuery.Append("      , REAL_AMT ");
                    sbQuery.Append("      , BANK ");
                    sbQuery.Append("      , BANK_NO ");
                    sbQuery.Append("      , DETAIL_PART_NAME ");
                    sbQuery.Append("      , PUR_VEN_ACCOUNT ");
                    sbQuery.Append("      , SCOMMENT ");
                    sbQuery.Append("      , REG_DATE ");
                    sbQuery.Append("      , REG_EMP ");
                    sbQuery.Append(" ) ");
                    sbQuery.Append(" VALUES ");
                    sbQuery.Append(" ( ");
                    sbQuery.Append("        @PLT_CODE ");
                    sbQuery.Append("      , @BALJU_NUM ");
                    sbQuery.Append("      , @BALJU_SEQ ");
                    sbQuery.Append("      , @REQUEST_NO ");
                    sbQuery.Append("      , @REQUEST_SEQ ");
                    sbQuery.Append("      , @PART_CODE ");
                    sbQuery.Append("      , @DUE_DATE ");
                    sbQuery.Append("      , @UNIT_COST ");
                    sbQuery.Append("      , @QTY ");
                    sbQuery.Append("      , @AMT ");
                    sbQuery.Append("      , @MAT_SPEC ");
                    sbQuery.Append("      , @MAT_WEIGHT ");
                    sbQuery.Append("      , @BAL_STAT ");
                    sbQuery.Append("      , @INS_FLAG ");
                    sbQuery.Append("      , @BAL_UNIT ");
                    sbQuery.Append("      , @REAL_AMT ");
                    sbQuery.Append("      , @BANK ");
                    sbQuery.Append("      , @BANK_NO ");
                    sbQuery.Append("      , @DETAIL_PART_NAME ");
                    sbQuery.Append("      , @PUR_VEN_ACCOUNT ");
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

        /// <summary>
        /// 발주내역 수정
        /// HJKIM
        /// </summary>
        /// <param name="dtParam"></param>
        /// <param name="bizExecute"></param>
        public static void TMAT_BALJU_UPD(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" UPDATE TMAT_BALJU ");
                    sbQuery.Append("    SET   UNIT_COST = @UNIT_COST ");
                    sbQuery.Append("        , QTY = @QTY ");
                    sbQuery.Append("        , AMT = @AMT ");
                    sbQuery.Append("        , SCOMMENT = @SCOMMENT ");
                    sbQuery.Append("        , INS_FLAG = @INS_FLAG ");
                    sbQuery.Append("        , BAL_STAT = @BAL_STAT ");
                    sbQuery.Append("        , REAL_AMT = @REAL_AMT ");
                    sbQuery.Append("        , BANK = @BANK ");
                    sbQuery.Append("        , BANK_NO = @BANK_NO ");
                    sbQuery.Append("        , DETAIL_PART_NAME = @DETAIL_PART_NAME ");
                    sbQuery.Append("        , PUR_VEN_ACCOUNT = @PUR_VEN_ACCOUNT ");
                    sbQuery.Append("        , MDFY_DATE =  GETDATE() ");
                    sbQuery.Append("        , MDFY_EMP = @REG_EMP ");
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


        //상태변경
        public static void TMAT_BALJU_UPD2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TMAT_BALJU ");
                    sbQuery.Append("    SET   BAL_STAT = @BAL_STAT ");
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

        //취소/반려 사유
        public static void TMAT_BALJU_UPD3(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TMAT_BALJU ");
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

        //입고예정일 변경
        public static void TMAT_BALJU_UPD4(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TMAT_BALJU ");
                    sbQuery.Append("    SET   DUE_DATE = @DUE_DATE ");
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


        public static void TMAT_BALJU_UPD5(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TMAT_BALJU ");
                    sbQuery.Append("    SET   CHG_UNIT_COST = @UNIT_COST ");
                    //sbQuery.Append("        , AMT = QTY * @UNIT_COST ");
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


        public static void TMAT_BALJU_UPD6(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TMAT_BALJU ");
                    sbQuery.Append("  SET INS_DATE = @INS_DATE ");
                    sbQuery.Append("    , INS_EMP = @INS_EMP   ");
                    sbQuery.Append("    , OK_QTY = @OK_QTY     ");
                    sbQuery.Append("    , BAL_STAT = @BAL_STAT ");
                    sbQuery.Append("    , MDFY_DATE = GETDATE() ");
                    sbQuery.Append("    , MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
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

    }


    public class TMAT_BALJU_QUERY
    {
        /// <summary>
        /// 발주 데이터 조회
        /// HJKIM
        /// </summary>
        /// <param name="dtParam"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataTable TMAT_BALJU_QUERY1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT");
                    sbQuery.Append(" BM.BALJU_NUM");
                    sbQuery.Append(" , BM.MVND_CODE");
                    sbQuery.Append(" , BM.BALJU_DATE");
                    sbQuery.Append(" , B.BALJU_SEQ");
                    sbQuery.Append(" , B.PART_CODE");
                    sbQuery.Append(" , P.PART_NAME");
                    sbQuery.Append(" , P.MAT_TYPE");
                    sbQuery.Append(" , P.MAT_TYPE1");
                    sbQuery.Append(" , P.MAT_TYPE2");
                    sbQuery.Append(" , P.MAT_LTYPE");
                    sbQuery.Append(" , P.MAT_UNIT");
                    sbQuery.Append(" , P.MAT_MTYPE");
                    sbQuery.Append(" , P.PART_PRODTYPE");
                    sbQuery.Append(" , P.MAT_SPEC");
                    sbQuery.Append(" , P.PART_CAT");
                    sbQuery.Append(" , B.DUE_DATE");
                    sbQuery.Append(" , B.QTY");
                    sbQuery.Append(" , B.UNIT_COST");
                    sbQuery.Append(" , B.AMT");
                    sbQuery.Append(" , B.SCOMMENT");
                    sbQuery.Append(" , B.BAL_STAT ");
                    sbQuery.Append(" , B.INS_FLAG ");
                    sbQuery.Append(" , B.REG_EMP");
                    sbQuery.Append(" , E.EMP_NAME AS REG_EMP_NAME");
                    sbQuery.Append(" , B.REG_DATE");
                    sbQuery.Append(" , B.BAL_UNIT");
                    sbQuery.Append(" , B.REAL_AMT");
                    sbQuery.Append(" , B.BANK");
                    sbQuery.Append(" , B.BANK_NO");
                    sbQuery.Append(" , B.DETAIL_PART_NAME ");
                    sbQuery.Append(" , B.PUR_VEN_ACCOUNT ");
                    sbQuery.Append(" ,BM.BAL_TYPE ");
                    sbQuery.Append(" ,BM.INCL_VAT ");
                    sbQuery.Append(" ,BM.SPLIT ");
                    sbQuery.Append(" ,BM.DELIVERY_LOCATION ");
                    sbQuery.Append(" ,BM.PAY_CONDITION ");
                    sbQuery.Append(" ,BM.YPGO_CHARGE ");
                    sbQuery.Append(" ,BM.CHK_MEASURE ");
                    sbQuery.Append(" ,BM.CHK_PERFORM ");
                    sbQuery.Append(" ,BM.CHK_ATTEND ");
                    sbQuery.Append(" ,BM.CHK_TEST ");
                    sbQuery.Append(" ,BM.CHK_MEEL ");
                    sbQuery.Append(" ,BM.CHK_ADD1 ");
                    sbQuery.Append(" ,BM.CHK_ADD2 ");
                    sbQuery.Append(" ,BM.CHK_ADD3 ");
                    sbQuery.Append(" ,BM.CHARGE_EMP ");
                    sbQuery.Append(" ,BM.CHARGE_PHONE ");
                    sbQuery.Append(" ,BM.CHARGE_EMAIL ");
                    sbQuery.Append(" ,BM.SCOMMENT AS M_SCOMMENT");
                    sbQuery.Append(" ,BM.APP_ORG");
                    sbQuery.Append(" ,BM.CHK_RD ");
                    sbQuery.Append(" ,ISNULL(BM.APP_STATUS, '0') AS APP_STATUS");
                    sbQuery.Append(" FROM TMAT_BALJU_MASTER BM");
                    sbQuery.Append(" JOIN TMAT_BALJU B");
                    sbQuery.Append(" ON BM.PLT_CODE = B.PLT_CODE");
                    sbQuery.Append(" AND BM.BALJU_NUM = B.BALJU_NUM");
                    
                    sbQuery.Append(" JOIN LSE_STD_PART P");
                    sbQuery.Append(" ON B.PLT_CODE = P.PLT_CODE");
                    sbQuery.Append(" AND B.PART_CODE = P.PART_CODE");

                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE E");
                    sbQuery.Append(" ON B.PLT_CODE = E.PLT_CODE");
                    sbQuery.Append(" AND B.REG_EMP = E.EMP_CODE");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE BM.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@BAL_TYPE", " BM.BAL_TYPE = @BAL_TYPE "));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_BALJU_DATE,@E_BALJU_DATE", " BM.BALJU_DATE BETWEEN @S_BALJU_DATE AND @E_BALJU_DATE "));
                        sbWhere.Append(UTIL.GetWhere(row, "@BALJU_NUM", " B.BALJU_NUM = @BALJU_NUM "));
                        sbWhere.Append(UTIL.GetWhere(row, "@BALJU_SEQ", " B.BALJU_SEQ = @BALJU_SEQ "));
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_CODE", " B.PART_CODE = @PART_CODE "));
                        sbWhere.Append(UTIL.GetWhere(row, "@BAL_STAT", " B.BAL_STAT = @BAL_STAT "));
                        sbWhere.Append(UTIL.GetWhere(row, "@BALJU_LIKE", " BM.BALJU_NUM LIKE '%' + @BALJU_LIKE + '%' "));
                        sbWhere.Append(UTIL.GetWhere(row, "@CHARGE_LIKE", " BM.CHARGE_EMP LIKE '%' + @CHARGE_LIKE + '%' "));
                        sbWhere.Append(UTIL.GetWhere(row, "@PUR01", " B.BAL_STAT IN ('11', '20')  "));
                        sbWhere.Append(UTIL.GetWhere(row, "@PUR", " B.BAL_STAT IN ('11', '13', '19', '20', '21', '22', '43')  "));
                        sbWhere.Append(UTIL.GetWhere(row, "@BALJU_NUM_LIKE", " B.BALJU_NUM LIKE '%' + @BALJU_NUM_LIKE + '%' "));
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_LIKE", "(B.PART_CODE LIKE '%' + @PART_LIKE + '%' OR P.PART_NAME LIKE '%' + @PART_LIKE + '%')"));

                        sbWhere.Append(UTIL.GetWhere(row, "@PUR01_CANCEL", " B.BAL_STAT <> '14'  "));

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


        //발주취소가 아닌 발주건이 있는지 조회
        public static DataTable TMAT_BALJU_QUERY2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT B.PLT_CODE ");
                    sbQuery.Append("       ,B.BALJU_NUM ");
                    sbQuery.Append("       ,B.BALJU_SEQ ");
                    sbQuery.Append("   FROM TMAT_BALJU B ");
                    sbQuery.Append("  WHERE B.PLT_CODE = @PLT_CODE ");
                    sbQuery.Append("    AND B.BALJU_NUM = @BALJU_NUM ");
                    sbQuery.Append("    AND B.BAL_STAT <> '14'");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "BALJU_NUM")) isHasColumn = false;

                        if (isHasColumn == true)
                        {
                            DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString(), row);

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
        /// 발주 데이터 : 입고 대상 목록 조회
        /// HJKIM
        /// </summary>
        /// <param name="dtParam"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataTable TMAT_BALJU_QUERY3(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {

                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT");
                    sbQuery.Append(" B.PLT_CODE");
                    sbQuery.Append(" ,BM.BAL_TYPE");
                    sbQuery.Append(" ,B.BALJU_NUM");
                    sbQuery.Append(" ,B.BALJU_SEQ");
                    sbQuery.Append(" ,B.PART_CODE");
                    sbQuery.Append(" ,B.DETAIL_PART_NAME");
                    sbQuery.Append(" ,SP.PART_NAME");
                    sbQuery.Append(" ,SP.MAT_LTYPE");
                    sbQuery.Append(" ,SP.MAT_MTYPE");
                    sbQuery.Append(" ,SP.MAT_SPEC");
                    sbQuery.Append(" ,SP.MAT_UNIT");
                    sbQuery.Append(" ,SP.STK_LOCATION ");
                    sbQuery.Append(" ,ISNULL(B.INS_FLAG, 1) AS INS_FLAG");
                    sbQuery.Append(" ,B.BAL_STAT");
                    sbQuery.Append(" ,BM.BALJU_DATE");
                    sbQuery.Append(" ,B.DUE_DATE");
                    sbQuery.Append(" ,BM.MVND_CODE AS VND_CODE");
                    sbQuery.Append(" ,B.SCOMMENT");

                    sbQuery.Append(" ,B.QTY AS BAL_QTY");
                    sbQuery.Append(" ,B.UNIT_COST AS BAL_COST");
                    sbQuery.Append(" ,B.AMT AS BAL_AMT");
                    sbQuery.Append(" ,ISNULL(YPGO.QTY,0) AS YPGO_QTY");

                    sbQuery.Append(" ,(ISNULL(B.QTY,0) - ISNULL(YPGO.QTY,0) - ISNULL(Q.NG_QTY, 0)) AS QTY");
                    sbQuery.Append(" ,ISNULL(B.CHG_UNIT_COST, B.UNIT_COST) AS YPGO_COST ");
                    sbQuery.Append(" ,(ISNULL(B.QTY,0) - ISNULL(YPGO.QTY,0) - ISNULL(Q.NG_QTY, 0)) * ISNULL(B.CHG_UNIT_COST, B.UNIT_COST) AS YPGO_AMT ");

                    sbQuery.Append(" ,B.OK_QTY ");
                    sbQuery.Append(" ,Q.NG_QTY ");

                    sbQuery.Append(" FROM TMAT_BALJU B");
                    sbQuery.Append(" JOIN TMAT_BALJU_MASTER BM");
                    sbQuery.Append(" ON B.PLT_CODE = BM.PLT_CODE");
                    sbQuery.Append(" AND B.BALJU_NUM = BM.BALJU_NUM");
                    sbQuery.Append(" JOIN LSE_STD_PART SP");
                    sbQuery.Append(" ON B.PLT_CODE = SP.PLT_CODE");
                    sbQuery.Append(" AND B.PART_CODE = SP.PART_CODE");
                    sbQuery.Append(" LEFT JOIN");
                    sbQuery.Append(" (");
                    sbQuery.Append(" SELECT PLT_CODE , BALJU_NUM , BALJU_SEQ , ISNULL(SUM(QTY),0) AS QTY FROM TMAT_YPGO");
                    sbQuery.Append(" WHERE YPGO_STAT IN ('19','31','32')");
                    sbQuery.Append(" GROUP BY PLT_CODE , BALJU_NUM ,BALJU_SEQ");
                    sbQuery.Append(" ) YPGO");
                    sbQuery.Append(" ON B.PLT_CODE = YPGO.PLT_CODE");
                    sbQuery.Append(" AND B.BALJU_NUM = YPGO.BALJU_NUM");
                    sbQuery.Append(" AND B.BALJU_SEQ = YPGO.BALJU_SEQ");

                    sbQuery.Append(" LEFT JOIN TQCT_PURCHASE_NG Q ");
                    sbQuery.Append(" ON B.PLT_CODE = Q.PLT_CODE ");
                    sbQuery.Append(" AND B.BALJU_NUM = Q.BALJU_NUM ");
                    sbQuery.Append(" AND B.BALJU_SEQ = Q.BALJU_SEQ ");
                    sbQuery.Append(" AND Q.DATA_FLAG = 0 ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE B.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(" AND B.BAL_STAT IN ('11', '43', '21')");

                        sbWhere.Append(UTIL.GetWhere(row, "@S_BALJU_DATE,@E_BALJU_DATE", " (BM.BALJU_DATE BETWEEN @S_BALJU_DATE AND @E_BALJU_DATE) "));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_DUE_DATE,@E_DUE_DATE", " (B.DUE_DATE BETWEEN @S_DUE_DATE AND @E_DUE_DATE) "));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_MDFY_DATE,@E_MDFY_DATE", " CONVERT(CHAR(19), B.MDFY_DATE, 120) BETWEEN @S_MDFY_DATE AND @E_MDFY_DATE "));

                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_CODE", " PT.PROD_CODE = @PROD_CODE "));
                        sbWhere.Append(UTIL.GetWhere(row, "@MVND_CODE", " BM.MVND_CODE = @MVND_CODE "));
                        sbWhere.Append(UTIL.GetWhere(row, "@BALJU_NUM_LIKE", " B.BALJU_NUM LIKE '%' + @BALJU_NUM_LIKE + '%' "));
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_LIKE", "(B.PART_CODE LIKE '%' + @PART_LIKE + '%' OR SP.PART_NAME LIKE '%' + @PART_LIKE + '%')"));
                        sbWhere.Append(UTIL.GetWhere(row, "@MAT_LTYPE", " SP.MAT_LTYPE = @MAT_LTYPE "));

                        sbWhere.Append(UTIL.GetWhere(row, "@BAL_STAT", " B.BAL_STAT = @BAL_STAT "));

                        sbWhere.Append(UTIL.GetWhere(row, "@REG_EMP", " B.REG_EMP = @REG_EMP "));
                        sbWhere.Append(UTIL.GetWhere(row, "@BALJU_NUM", " B.BALJU_NUM = @BALJU_NUM "));
                        sbWhere.Append(UTIL.GetWhere(row, "@BALJU_SEQ", " B.BALJU_SEQ = @BALJU_SEQ "));
                        
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

        public static DataTable TMAT_BALJU_QUERY4(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable dtResult = new DataTable("RSLTDT");

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT  ");
                    sbQuery.Append("  ISNULL(MAX(BALJU_SEQ), 0) + 1 AS SEQ");
                    sbQuery.Append(" FROM TMAT_BALJU   ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("   AND BALJU_NUM = @BALJU_NUM ");
                    
                    dtResult = bizExecute.executeSelectQuery(sbQuery.ToString(), dtParam.Rows[0]);
    
                }

                return dtResult;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }


        public static DataTable TMAT_BALJU_QUERY5(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT");
                    sbQuery.Append(" B.PLT_CODE");
                    sbQuery.Append(" ,B.REQUEST_NO");
                    sbQuery.Append(" ,B.REQUEST_SEQ");
                    sbQuery.Append(" ,B.BALJU_NUM");
                    sbQuery.Append(" ,B.BALJU_SEQ");
                    sbQuery.Append(" ,B.BAL_STAT");
                    sbQuery.Append(" ,BM.BALJU_DATE");
                    sbQuery.Append(" ,B.DUE_DATE");
                    sbQuery.Append(" ,BM.MVND_CODE AS VND_CODE");
                    sbQuery.Append(" ,V.VEN_NAME");
                    sbQuery.Append(" ,B.REG_EMP");
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
                    sbQuery.Append(" ,BM.CHK_RD ");
                    sbQuery.Append(" ,BM.CHARGE_EMP");
                    sbQuery.Append(" ,BM.CHARGE_PHONE");
                    sbQuery.Append(" ,BM.CHARGE_EMAIL");
                    sbQuery.Append(" ,BM.SCOMMENT");
                    sbQuery.Append(" , B.PART_CODE");
                    sbQuery.Append(" ,SP.PART_NAME");
                    sbQuery.Append(" ,SP.MAT_LTYPE");
                    sbQuery.Append(" ,SP.MAT_MTYPE");
                    sbQuery.Append(" ,SP.MAT_STYPE");
                    sbQuery.Append(" ,SP.PART_PRODTYPE");
                    sbQuery.Append(" ,SP.MAT_UNIT");
                    sbQuery.Append(" ,B.INS_FLAG");
                    sbQuery.Append(" ,SP.STK_LOCATION");
                    sbQuery.Append(" ,B.UNIT_COST");
                    //sbQuery.Append(" ,B.QTY");
                    sbQuery.Append(" ,B.QTY AS BAL_QTY");
                    sbQuery.Append(" ,B.QTY AS INS_QTY");
                    sbQuery.Append(" ,ISNULL(YPGO.QTY, 0) AS YPGO_QTY");
                    sbQuery.Append(" ,(ISNULL(B.QTY,0) - ISNULL(YPGO.QTY,0) - ISNULL(Q.NG_QTY, 0)) AS QTY");
                    sbQuery.Append(" ,B.UNIT_COST AS YPGO_COST");
                    sbQuery.Append(" ,(ISNULL(B.QTY,0) - ISNULL(YPGO.QTY,0) - ISNULL(Q.NG_QTY, 0)) * B.UNIT_COST AS YPGO_AMT");
                    sbQuery.Append(" ,B.OK_QTY");
                    sbQuery.Append(" ,Q.NG_QTY");
                    sbQuery.Append(" ,B.AMT");
                    sbQuery.Append(" ,B.SCOMMENT");
                    sbQuery.Append(" ,B.INS_DATE");
                    sbQuery.Append(" ,B.INS_EMP");
                    sbQuery.Append(" ,BM.APP_STATUS");
                    sbQuery.Append(" ,ISNULL(BM.APP_EMP1,APP.APP_EMP1) AS APP_EMP1");
                    sbQuery.Append(" ,ISNULL(BM.APP_EMP_FLAG1,'0') AS APP_EMP_FLAG1");
                    sbQuery.Append(" ,ISNULL(BM.APP_EMP2,APP.APP_EMP2) AS APP_EMP2");
                    sbQuery.Append(" ,ISNULL(BM.APP_EMP_FLAG2,'0') AS APP_EMP_FLAG2");
                    sbQuery.Append(" ,ISNULL(BM.APP_EMP3,APP.APP_EMP3) AS APP_EMP3");
                    sbQuery.Append(" ,ISNULL(BM.APP_EMP_FLAG3,'0') AS APP_EMP_FLAG3");
                    sbQuery.Append(" ,ISNULL(BM.APP_EMP4,APP.APP_EMP4) AS APP_EMP4");
                    sbQuery.Append(" ,ISNULL(BM.APP_EMP_FLAG4,'0') AS APP_EMP_FLAG4");
                    sbQuery.Append(" FROM TMAT_BALJU B");
                    sbQuery.Append(" JOIN TMAT_BALJU_MASTER BM");
                    sbQuery.Append(" ON B.PLT_CODE = BM.PLT_CODE");
                    sbQuery.Append(" AND B.BALJU_NUM = BM.BALJU_NUM");
                    sbQuery.Append(" LEFT JOIN");
                    sbQuery.Append(" (");
                    sbQuery.Append(" SELECT PLT_CODE , BALJU_NUM , BALJU_SEQ , ISNULL(SUM(QTY),0) AS QTY FROM TMAT_YPGO");
                    sbQuery.Append(" WHERE YPGO_STAT IN ('19','31','32')");
                    sbQuery.Append(" GROUP BY PLT_CODE , BALJU_NUM ,BALJU_SEQ");
                    sbQuery.Append(" ) YPGO");
                    sbQuery.Append(" ON B.PLT_CODE = YPGO.PLT_CODE");
                    sbQuery.Append(" AND B.BALJU_NUM = YPGO.BALJU_NUM");
                    sbQuery.Append(" AND B.BALJU_SEQ = YPGO.BALJU_SEQ");
                    sbQuery.Append(" LEFT JOIN TQCT_PURCHASE_NG Q");
                    sbQuery.Append(" ON B.PLT_CODE = Q.PLT_CODE");
                    sbQuery.Append(" AND B.BALJU_NUM = Q.BALJU_NUM");
                    sbQuery.Append(" AND B.BALJU_SEQ = Q.BALJU_SEQ");
                    sbQuery.Append(" AND Q.DATA_FLAG = 0");
                    sbQuery.Append(" LEFT JOIN LSE_STD_PART SP");
                    sbQuery.Append(" ON B.PLT_CODE = SP.PLT_CODE");
                    sbQuery.Append(" AND B.PART_CODE = SP.PART_CODE");
                    sbQuery.Append(" LEFT JOIN TSTD_APP_EMP APP");
                    sbQuery.Append(" ON BM.PLT_CODE = APP.PLT_CODE");
                    sbQuery.Append(" AND APP.APP_TYPE = 'PUR'");
                    sbQuery.Append(" AND APP.ORG_CODE = BM.APP_ORG ");
                    sbQuery.Append(" LEFT JOIN TSTD_VENDOR V");
                    sbQuery.Append(" ON BM.PLT_CODE = V.PLT_CODE");
                    sbQuery.Append(" AND BM.MVND_CODE = V.VEN_CODE");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE B.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                        sbWhere.Append(UTIL.GetWhere(row, "@BALJU_NUM", " B.BALJU_NUM = @BALJU_NUM "));
                        sbWhere.Append(UTIL.GetWhere(row, "@BALJU_NUM_LIKE", "(B.BALJU_NUM LIKE '%' + @BALJU_NUM_LIKE + '%') "));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_BALJU_DATE, @E_BALJU_DATE", " (BM.BALJU_DATE BETWEEN @S_BALJU_DATE AND @E_BALJU_DATE) "));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_DUE_DATE, @E_DUE_DATE", " (B.DUE_DATE BETWEEN @S_DUE_DATE AND @E_DUE_DATE) "));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_MDFY_DATE,@E_MDFY_DATE", " CONVERT(CHAR(19), B.MDFY_DATE, 120) BETWEEN @S_MDFY_DATE AND @E_MDFY_DATE "));
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_CODE", " B.PART_CODE = @PART_CODE "));
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_LIKE", " B.PART_CODE = @PART_LIKE "));
                        sbWhere.Append(UTIL.GetWhere(row, "@VEN_CODE", " BM.MVND_CODE = @VEN_CODE "));
                        sbWhere.Append(UTIL.GetWhere(row, "@OVND_CODE", " BM.MVND_CODE = @OVND_CODE "));
                        sbWhere.Append(UTIL.GetWhere(row, "@BAL_STAT", " B.BAL_STAT = @BAL_STAT "));
                        //sbWhere.Append(UTIL.GetWhere(row, "@INS_FLAG", " SP.INS_FLAG = @INS_FLAG "));
                        sbWhere.Append(UTIL.GetWhere(row, "@INS_FLAG", " B.INS_FLAG = @INS_FLAG "));
                        sbWhere.Append(UTIL.GetWhere(row, "@MAT_LTYPE", " SP.MAT_LTYPE = @MAT_LTYPE "));
                        sbWhere.Append(UTIL.GetWhere(row, "@REG_EMP", " B.REG_EMP = @REG_EMP "));
                        sbWhere.Append(UTIL.GetWhere(row, "@BALJU_SEQ", " B.BALJU_SEQ = @BALJU_SEQ "));

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


        //자재발주데이터를 조회 (일반자재)
        public static DataTable TMAT_BALJU_QUERY6(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT  ");
                    sbQuery.Append(" B.PLT_CODE ");
                    sbQuery.Append(" ,B.REQUEST_NO ");
                    sbQuery.Append(" ,B.REQUEST_SEQ ");
                    sbQuery.Append(" ,B.BALJU_NUM ");
                    sbQuery.Append(" ,B.BALJU_SEQ ");
                    sbQuery.Append(" ,B.BAL_STAT ");
                    sbQuery.Append(" ,BM.BALJU_DATE ");
                    sbQuery.Append(" ,B.DUE_DATE ");
                    sbQuery.Append(" ,BM.MVND_CODE AS VEN_CODE ");
                    sbQuery.Append(" ,V.VEN_NAME ");
                    
                    sbQuery.Append(" ,B.REG_EMP ");
                    sbQuery.Append(" ,REG_EMP.EMP_NAME AS REG_EMP_NAME ");
                    sbQuery.Append(" ,R.PART_CODE ");
                    sbQuery.Append(" ,SP.PART_NAME  ");
                    sbQuery.Append(" ,SP.PART_PRODTYPE ");
                    sbQuery.Append(" ,SP.DRAW_NO ");
                    sbQuery.Append(" ,SP.MAT_LTYPE ");
                    sbQuery.Append(" ,SP.MAT_MTYPE ");
                    sbQuery.Append(" ,SP.MAT_STYPE ");
                    sbQuery.Append(" ,SP.MAT_QLTY AS PART_QLTY ");
                    sbQuery.Append(" ,QUC.MQLTY_NAME AS PART_QLTY_NAME ");
                    sbQuery.Append(" ,SP.MAT_SPEC AS PART_SPEC ");
                    sbQuery.Append(" ,SP.MAT_SPEC1 AS PART_SPEC1 ");
                    sbQuery.Append(" ,SP.BAL_SPEC  ");
                    sbQuery.Append(" ,SP.MAT_WEIGHT1  ");
                    sbQuery.Append(" ,SP.MAT_WEIGHT  ");
                    sbQuery.Append(" ,SP.BAL_WEIGHT  ");
                    sbQuery.Append(" ,SP.MAT_UNIT ");
                    sbQuery.Append(" ,B.MAT_SPEC AS B_MAT_SPEC ");
                    sbQuery.Append(" ,B.MAT_WEIGHT AS B_WEIGHT ");

                    sbQuery.Append(" ,B.UNIT_COST ");
                    sbQuery.Append(" ,B.QTY ");
                    sbQuery.Append(" ,B.AMT ");
                    sbQuery.Append(" ,BM.SCOMMENT ");
                    sbQuery.Append(" ,B.SCOMMENT AS BAL_SCOMMENT ");
                    sbQuery.Append(" ,B.REG_EMP ");
                    sbQuery.Append(" ,REG.EMP_NAME AS REG_EMP_NAME ");

                    sbQuery.Append(" ,TI.CVND_CODE ");
                    sbQuery.Append(" ,CV.VEN_NAME AS CVND_NAME ");
                    //sbQuery.Append(" ,TI.ITEM_CODE ");
                    sbQuery.Append(" ,ISNULL(TI.ITEM_CODE, V.VEN_NAME) AS ITEM_CODE ");
                    sbQuery.Append(" ,R.PROD_CODE ");
                    sbQuery.Append(" ,R.WO_NO ");
                    sbQuery.Append(" ,SP.DRAW_NO ");
                    sbQuery.Append(" ,SP.PART_PRODTYPE ");
                    
                    sbQuery.Append(" FROM TMAT_BALJU B ");
                    sbQuery.Append(" JOIN TMAT_BALJU_MASTER BM ");
                    sbQuery.Append(" ON B.PLT_CODE = BM.PLT_CODE ");
                    sbQuery.Append(" AND B.BALJU_NUM = BM.BALJU_NUM ");
                    sbQuery.Append(" LEFT JOIN TMAT_REQUEST R  ");
                    sbQuery.Append(" ON B.PLT_CODE = R.PLT_CODE ");
                    sbQuery.Append(" AND B.REQUEST_NO = R.REQUEST_NO ");
                    sbQuery.Append(" AND B.REQUEST_SEQ = R.REQUEST_SEQ ");
                    sbQuery.Append(" LEFT JOIN TMAT_REQUEST_MASTER RM ");
                    sbQuery.Append(" ON R.PLT_CODE = RM.PLT_CODE ");
                    sbQuery.Append(" AND R.REQUEST_NO = RM.REQUEST_NO ");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE REG_EMP ");
                    sbQuery.Append(" ON B.PLT_CODE = REG_EMP.PLT_CODE ");
                    sbQuery.Append(" AND B.REG_EMP = REG_EMP.EMP_CODE ");
                    sbQuery.Append(" LEFT JOIN LSE_STD_PART SP ");
                    sbQuery.Append(" ON R.PLT_CODE = SP.PLT_CODE ");
                    sbQuery.Append(" AND R.PART_CODE = SP.PART_CODE ");
                    sbQuery.Append(" LEFT JOIN TSTD_VENDOR V ");
                    sbQuery.Append(" ON B.PLT_CODE = V.PLT_CODE ");
                    sbQuery.Append(" AND BM.MVND_CODE = V.VEN_CODE ");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE REG ");
                    sbQuery.Append(" ON B.PLT_CODE = REG.PLT_CODE ");
                    sbQuery.Append(" AND B.REG_EMP = REG.EMP_CODE ");
                    sbQuery.Append(" LEFT JOIN TMAT_QUC_MASTER QUC ");
                    sbQuery.Append(" ON SP.PLT_CODE = QUC.PLT_CODE ");
                    sbQuery.Append(" AND SP.MAT_QLTY = QUC.MQLTY_CODE ");

                    sbQuery.Append(" LEFT JOIN TORD_PRODUCT TP ");
                    sbQuery.Append(" ON R.PLT_CODE = TP.PLT_CODE ");
                    sbQuery.Append(" AND R.PROD_CODE = TP.PROD_CODE ");
                    sbQuery.Append(" AND R.PART_CODE = TP.PART_CODE ");
                    sbQuery.Append(" LEFT JOIN TORD_ITEM TI ");
                    sbQuery.Append(" ON TP.PLT_CODE = TI.PLT_CODE ");
                    sbQuery.Append(" AND TP.ITEM_CODE = TI.ITEM_CODE ");

                    sbQuery.Append(" LEFT JOIN TSTD_VENDOR CV ");
                    sbQuery.Append(" ON TI.PLT_CODE = CV.PLT_CODE ");
                    sbQuery.Append(" AND TI.CVND_CODE = CV.VEN_CODE ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE B.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@BALJU_NUM", " B.BALJU_NUM = @BALJU_NUM "));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_BALJU_DATE,@E_BALJU_DATE", " (BM.BALJU_DATE BETWEEN @S_BALJU_DATE AND @E_BALJU_DATE) "));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_DUE_DATE,@E_DUE_DATE", " (B.DUE_DATE BETWEEN @S_DUE_DATE AND @E_DUE_DATE) "));
                        sbWhere.Append(UTIL.GetWhere(row, "@MVND_CODE", " BM.MVND_CODE = @MVND_CODE "));
                        sbWhere.Append(UTIL.GetWhere(row, "@BAL_STAT", " B.BAL_STAT = @BAL_STAT "));

                        sbWhere.Append(UTIL.GetWhere(row, "@REG_EMP", " B.REG_EMP = @REG_EMP "));
                        sbWhere.Append(UTIL.GetWhere(row, "@BALJU_SEQ", " B.BALJU_SEQ = @BALJU_SEQ "));
                        sbWhere.Append(UTIL.GetWhere(row, "@ITEM_CODE", " TI.ITEM_CODE = @ITEM_CODE "));

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

        //자재발주데이터를 조회 (일반자재)
        public static DataTable TMAT_BALJU_QUERY6_2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("  SELECT TOP 10                        ");
                    sbQuery.Append("  B.PLT_CODE                           ");
                    sbQuery.Append("  ,V.VEN_NAME AS CVND_NAME             ");
                    sbQuery.Append("  ,SP.PART_NAME                        ");
                    sbQuery.Append("  ,BM.BALJU_DATE                       ");
                    sbQuery.Append("  ,BAL_VEN.VEN_NAME AS BALJU_VEN_NAME  ");
                    
                    sbQuery.Append("  ,B.UNIT_COST AS BAL_UNIT_COST        ");
                    sbQuery.Append("  ,B.QTY AS BAL_QTY                    ");
                    sbQuery.Append("  ,B.AMT AS BAL_AMT                    ");
                    sbQuery.Append("  ,Y.YPGO_DATE                         ");
                    sbQuery.Append("  FROM                                 ");
                    sbQuery.Append("  TMAT_BALJU B                         ");
                    sbQuery.Append("  LEFT JOIN TMAT_BALJU_MASTER BM       ");
                    sbQuery.Append("  ON B.PLT_CODE = BM.PLT_CODE          ");
                    sbQuery.Append("  AND B.BALJU_NUM = BM.BALJU_NUM       ");
                    
                    sbQuery.Append("  LEFT JOIN TMAT_REQUEST R             ");
                    sbQuery.Append("  ON B.PLT_CODE = R.PLT_CODE           ");
                    sbQuery.Append("  AND B.REQUEST_NO = R.REQUEST_NO      ");
                    sbQuery.Append("  AND B.REQUEST_SEQ = R.REQUEST_SEQ    ");
                    
                    sbQuery.Append("  LEFT JOIN TMAT_REQUEST_MASTER RM     ");
                    sbQuery.Append("  ON R.PLT_CODE = RM.PLT_CODE          ");
                    sbQuery.Append("  AND R.REQUEST_NO = RM.REQUEST_NO     ");
                    
                    sbQuery.Append("  LEFT JOIN TMAT_YPGO Y                ");
                    sbQuery.Append("  ON B.PLT_CODE = Y.PLT_CODE           ");
                    sbQuery.Append("  AND B.BALJU_NUM = Y.BALJU_NUM        ");
                    sbQuery.Append("  AND B.BALJU_SEQ = Y.BALJU_SEQ        ");
                    sbQuery.Append("  AND Y.YPGO_STAT IN('19','20','24','25','31','32')  ");
  
                    sbQuery.Append("  LEFT JOIN TORD_PRODUCT P              ");
                    sbQuery.Append("  ON R.PLT_CODE = P.PLT_CODE            ");
                    sbQuery.Append("  AND R.PROD_CODE = P.PROD_CODE         ");
                    sbQuery.Append("  AND R.PART_CODE = P.PART_CODE         ");
                   
                    sbQuery.Append("  LEFT JOIN TORD_ITEM I                 ");
                    sbQuery.Append("  ON P.PLT_CODE = I.PLT_CODE            ");
                    sbQuery.Append("  AND P.ITEM_CODE = I.ITEM_CODE         ");
                   
                    sbQuery.Append("  LEFT JOIN TSTD_VENDOR V               ");
                    sbQuery.Append("  ON I.PLT_CODE = V.PLT_CODE            ");
                    sbQuery.Append("  AND I.CVND_CODE = V.VEN_CODE          ");
                   
                    sbQuery.Append("  LEFT JOIN LSE_STD_PART SP             ");
                    sbQuery.Append("  ON P.PLT_CODE = SP.PLT_CODE           ");
                    sbQuery.Append("  AND P.PART_CODE = SP.PART_CODE        ");
                    
                    sbQuery.Append("  LEFT JOIN TSTD_VENDOR BAL_VEN         ");
                    sbQuery.Append("  ON BM.PLT_CODE = BAL_VEN.PLT_CODE     ");
                    sbQuery.Append("  AND BM.MVND_CODE = BAL_VEN.VEN_CODE   ");
                    
                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE B.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                        
                        sbWhere.Append(UTIL.GetWhere(row, "@S_BALJU_DATE,@E_BALJU_DATE", " (BM.BALJU_DATE BETWEEN @S_BALJU_DATE AND @E_BALJU_DATE) "));

                        sbWhere.Append(UTIL.GetWhere(row, "@PART_CODE", " R.PART_CODE = @PART_CODE "));
                        
                        sbWhere.Append("ORDER BY BM.BALJU_DATE DESC");
                        
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


        //[입고처리] 자재발주데이터를 조회
        public static DataTable TMAT_BALJU_QUERY7(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT  ");
                    sbQuery.Append(" U.PLT_CODE ");
                    sbQuery.Append(" ,U.REQUEST_NO ");
                    sbQuery.Append(" ,U.REQUEST_SEQ ");
                    sbQuery.Append(" ,U.WO_NO ");
                    sbQuery.Append(" ,U.BALJU_NUM ");
                    sbQuery.Append(" ,U.BALJU_SEQ ");
                    sbQuery.Append(" ,U.BAL_STAT ");
                    sbQuery.Append(" ,U.REQ_DATE ");
                    sbQuery.Append(" ,U.REQ_DUE_DATE ");
                    sbQuery.Append(" ,U.BALJU_DATE ");
                    sbQuery.Append(" ,U.DUE_DATE ");
                    sbQuery.Append(" ,U.VEN_CODE ");
                    sbQuery.Append(" ,V.VEN_NAME ");
                    sbQuery.Append(" ,U.ITEM_CODE ");
                    sbQuery.Append(" ,U.ITEM_NAME ");
                    sbQuery.Append(" ,U.CVND_CODE ");
                    sbQuery.Append(" ,CV.VEN_NAME AS CVND_NAME ");
                    sbQuery.Append(" ,U.PROD_CODE ");
                    sbQuery.Append(" ,U.PROD_NAME ");
                    sbQuery.Append(" ,U.STOCK_TYPE ");
                    sbQuery.Append(" ,U.PART_CODE ");
                    sbQuery.Append(" ,U.PART_NAME ");
                    sbQuery.Append(" ,U.DRAW_NO ");
                    sbQuery.Append(" ,U.MAT_TYPE ");
                    sbQuery.Append(" ,U.MAT_LTYPE ");
                    sbQuery.Append(" ,U.MAT_MTYPE ");
                    sbQuery.Append(" ,U.MAT_STYPE ");
                    sbQuery.Append(" ,U.MAT_UNIT ");
                    sbQuery.Append(" ,U.PART_PRODTYPE ");
                    sbQuery.Append(" ,U.PART_QLTY ");
                    sbQuery.Append(" ,U.PART_SPEC ");
                    sbQuery.Append(" ,U.PART_SPEC1 ");
                    sbQuery.Append(" ,U.BAL_SPEC ");
                    sbQuery.Append(" ,U.BAL_QTY ");
                    sbQuery.Append(" ,U.UNIT_COST ");
                    sbQuery.Append(" ,U.AMT ");
                    sbQuery.Append(" ,U.YPGO_QTY ");
                    sbQuery.Append(" ,U.PART_QTY ");
                    sbQuery.Append(" ,U.CHK_YPGO_QTY ");
                    sbQuery.Append(" ,U.NG_YPGO_QTY ");
                    sbQuery.Append(" ,U.TOT_YPGO_QTY ");
                    sbQuery.Append(" ,U.QTY ");
                    sbQuery.Append(" ,U.QTY AS REMAIN_QTY ");
                    sbQuery.Append(" ,U.SCOMMENT ");
                    sbQuery.Append(" ,U.INS_FLAG ");
                    sbQuery.Append(" ,U.BALJU_REG_EMP ");
                    sbQuery.Append(" ,BALJU_REG.EMP_NAME AS BALJU_REG_EMP_NAME ");
                    sbQuery.Append(" ,U.ACT_START_TIME ");
                    sbQuery.Append(" ,U.ACT_END_TIME ");
                    sbQuery.Append(" ,U.REQ_REG_EMP ");
                    sbQuery.Append(" ,U.STK_LOCATION ");
                    sbQuery.Append(" ,U.STK_LOCATION_DETAIL ");
                    sbQuery.Append(" ,U.IS_TOOL ");
                    sbQuery.Append(" ,U.PROD_CODE ");
                    sbQuery.Append(" ,U.STK_MNG ");
                    sbQuery.Append(" ,CASE ISNULL(FM.LINK_KEY, '') WHEN '' THEN 'X' ELSE 'O' END colATTACH   ");
                    sbQuery.Append(" ,FM.LINK_KEY ");

                    sbQuery.Append(" FROM ");
                    sbQuery.Append(" ( ");
                    sbQuery.Append(" SELECT  ");
                    sbQuery.Append(" B.PLT_CODE ");
                    sbQuery.Append(" ,B.REQUEST_NO ");
                    sbQuery.Append(" ,B.REQUEST_SEQ ");
                    sbQuery.Append(" ,B.BALJU_NUM ");
                    sbQuery.Append(" ,B.BALJU_SEQ ");
                    sbQuery.Append(" ,B.BAL_STAT ");
                    sbQuery.Append(" ,RM.REQ_DATE ");
                    sbQuery.Append(" ,RM.DUE_DATE AS REQ_DUE_DATE ");
                    sbQuery.Append(" ,BM.BALJU_DATE ");
                    sbQuery.Append(" ,B.DUE_DATE ");
                    sbQuery.Append(" ,BM.MVND_CODE AS VEN_CODE ");
                    sbQuery.Append(" ,I.ITEM_CODE ");
                    sbQuery.Append(" ,I.ITEM_NAME ");
                    sbQuery.Append(" ,I.CVND_CODE ");
                    sbQuery.Append(" ,P.PROD_CODE ");
                    sbQuery.Append(" ,P.PROD_NAME ");
                    sbQuery.Append(" ,P.STOCK_TYPE ");
                    sbQuery.Append(" ,R.WO_NO ");
                    sbQuery.Append(" ,TW.PART_QTY ");
                    sbQuery.Append(" ,TW.ACT_START_TIME ");
                    sbQuery.Append(" ,TW.ACT_END_TIME ");
                    //sbQuery.Append(" ,SP.PART_CODE ");
                    sbQuery.Append(" ,R.PART_CODE ");
                    sbQuery.Append(" ,ISNULL(SP.MAT_TYPE, SP2.MAT_TYPE) AS MAT_TYPE ");
                    sbQuery.Append(" ,ISNULL(SP.PART_NAME, SP2.PART_NAME) AS PART_NAME ");
                    sbQuery.Append(" ,ISNULL(SP.DRAW_NO, SP2.DRAW_NO) AS DRAW_NO ");
                    sbQuery.Append(" ,ISNULL(SP.MAT_LTYPE, SP2.MAT_LTYPE) AS MAT_LTYPE ");
                    sbQuery.Append(" ,ISNULL(SP.MAT_MTYPE, SP2.MAT_MTYPE) AS MAT_MTYPE ");
                    sbQuery.Append(" ,ISNULL(SP.MAT_STYPE, SP2.MAT_STYPE) AS MAT_STYPE ");
                    sbQuery.Append(" ,ISNULL(SP.MAT_UNIT, SP2.MAT_UNIT) AS MAT_UNIT ");
                    sbQuery.Append(" ,ISNULL(SP.PART_PRODTYPE, SP2.PART_PRODTYPE) AS PART_PRODTYPE ");
                    sbQuery.Append(" ,ISNULL(SP.MAT_QLTY, SP2.MAT_QLTY) AS PART_QLTY ");
                    sbQuery.Append(" ,ISNULL(SP.MAT_SPEC, SP2.MAT_SPEC) AS PART_SPEC ");
                    sbQuery.Append(" ,ISNULL(SP.MAT_SPEC1, SP2.MAT_SPEC1) AS PART_SPEC1 ");
                    sbQuery.Append(" ,ISNULL(SP.BAL_SPEC, SP2.BAL_SPEC) AS BAL_SPEC"); 
                    sbQuery.Append(" ,B.QTY AS BAL_QTY ");
                    sbQuery.Append(" ,B.UNIT_COST ");
                    sbQuery.Append(" ,B.AMT ");
                    sbQuery.Append(" ,ISNULL(YPGO.QTY,0) AS YPGO_QTY ");
                    sbQuery.Append(" ,ISNULL(CHK_YPGO.QTY,0) AS CHK_YPGO_QTY ");
                    sbQuery.Append(" ,ISNULL(NG_YPGO.QTY,0) AS NG_YPGO_QTY ");
                    sbQuery.Append(" ,(ISNULL(YPGO.QTY,0) + ISNULL(NG_YPGO.QTY,0)) AS TOT_YPGO_QTY ");
                    sbQuery.Append(" ,(ISNULL(B.QTY,0) - (ISNULL(YPGO.QTY,0) + ISNULL(CHK_YPGO.QTY,0) + ISNULL(NG_YPGO.QTY,0))) AS QTY ");
                    sbQuery.Append(" ,BM.SCOMMENT ");
                    sbQuery.Append(" ,SP.INS_FLAG ");
                    sbQuery.Append(" ,B.REG_EMP AS BALJU_REG_EMP ");
                    sbQuery.Append(" ,R.REG_EMP AS REQ_REG_EMP ");
                    sbQuery.Append(" ,ISNULL(SP.STK_LOCATION, SP2.STK_LOCATION) AS STK_LOCATION ");
                    sbQuery.Append(" ,ISNULL(SP.STK_LOCATION_DETAIL, SP2.STK_LOCATION_DETAIL) AS STK_LOCATION_DETAIL ");
                    sbQuery.Append(" ,ISNULL(SP.IS_TOOL, SP2.IS_TOOL) AS IS_TOOL ");
                    sbQuery.Append(" ,ISNULL(SP.STK_MNG, SP2.STK_MNG) AS STK_MNG ");
                    sbQuery.Append(" FROM TMAT_BALJU B ");
                    sbQuery.Append(" JOIN TMAT_BALJU_MASTER BM ");
                    sbQuery.Append(" ON B.PLT_CODE = BM.PLT_CODE ");
                    sbQuery.Append(" AND B.BALJU_NUM = BM.BALJU_NUM ");
                    sbQuery.Append("  JOIN TMAT_REQUEST R  ");
                    sbQuery.Append(" ON B.PLT_CODE = R.PLT_CODE ");
                    sbQuery.Append(" AND B.REQUEST_NO = R.REQUEST_NO ");
                    sbQuery.Append(" AND B.REQUEST_SEQ = R.REQUEST_SEQ ");
                    sbQuery.Append(" LEFT JOIN TSHP_WORKORDER TW  ");
                    sbQuery.Append(" ON R.PLT_CODE = TW.PLT_CODE ");
                    sbQuery.Append(" AND R.WO_NO = TW.WO_NO ");
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
                    sbQuery.Append(" ON P.PLT_CODE = SP.PLT_CODE ");
                    sbQuery.Append(" AND P.PART_CODE = SP.PART_CODE ");
                    sbQuery.Append(" LEFT JOIN LSE_STD_PART SP2 ");
                    sbQuery.Append(" ON R.PLT_CODE = SP2.PLT_CODE ");
                    sbQuery.Append(" AND R.PART_CODE = SP2.PART_CODE ");
                    sbQuery.Append(" LEFT JOIN TOUT_TEMP_YPGO Y ");
                    sbQuery.Append(" ON B.PLT_CODE = Y.PLT_CODE  ");
                    sbQuery.Append(" AND B.BALJU_NUM = Y.BALJU_NUM ");
                    sbQuery.Append(" AND B.BALJU_SEQ = Y.BALJU_SEQ ");
                    sbQuery.Append(" LEFT JOIN  ");
                    sbQuery.Append(" ( ");
                    sbQuery.Append(" SELECT RE.PLT_CODE							 ");
                    sbQuery.Append(" 	, RE.WO_NO								 ");
                    sbQuery.Append(" 	, ISNULL(SUM(YP.QTY),0) AS TAT_YPGO_QTY			 ");
                    sbQuery.Append(" 	FROM TOUT_REQUEST RE					 ");
                    sbQuery.Append(" 	INNER JOIN TOUT_PROCBALJU BAL			 ");
                    sbQuery.Append(" 		ON RE.PLT_CODE = BAL.PLT_CODE		 ");
                    sbQuery.Append(" 		AND RE.REQUEST_NO = BAL.REQUEST_NO	 ");
                    sbQuery.Append(" 		AND RE.REQUEST_SEQ = BAL.REQUEST_SEQ ");
                    sbQuery.Append(" 	INNER JOIN TOUT_PROCYPGO YP				 ");
                    sbQuery.Append(" 		ON BAL.PLT_CODE = YP.PLT_CODE		 ");
                    sbQuery.Append(" 		AND BAL.BALJU_NUM = YP.BALJU_NUM	 ");
                    sbQuery.Append(" 		AND BAL.BALJU_SEQ = YP.BALJU_SEQ	 ");
                    sbQuery.Append(" WHERE YP.YPGO_STAT IN ('19','31','32')		 ");
                    sbQuery.Append(" GROUP BY RE.PLT_CODE, RE.WO_NO				 ");
                    sbQuery.Append(" ) TAT_YPGO ");
                    sbQuery.Append(" ON TW.PLT_CODE = TAT_YPGO.PLT_CODE ");
                    sbQuery.Append(" AND TW.WO_NO = TAT_YPGO.WO_NO ");
                    sbQuery.Append(" LEFT JOIN  ");
                    sbQuery.Append(" ( ");
                    sbQuery.Append(" SELECT PLT_CODE , BALJU_NUM , BALJU_SEQ , ISNULL(SUM(QTY),0) AS QTY FROM TMAT_YPGO   ");
                    sbQuery.Append(" WHERE YPGO_STAT IN ('19','31','32') ");
                    sbQuery.Append(" GROUP BY PLT_CODE , BALJU_NUM ,BALJU_SEQ ");
                    sbQuery.Append(" ) YPGO ");
                    sbQuery.Append(" ON B.PLT_CODE = YPGO.PLT_CODE ");
                    sbQuery.Append(" AND B.BALJU_NUM = YPGO.BALJU_NUM ");
                    sbQuery.Append(" AND B.BALJU_SEQ = YPGO.BALJU_SEQ ");
                    sbQuery.Append(" LEFT JOIN  ");
                    sbQuery.Append(" ( ");
                    sbQuery.Append(" SELECT PLT_CODE , BALJU_NUM , BALJU_SEQ , ISNULL(SUM(QTY),0) AS QTY FROM TMAT_YPGO   ");
                    sbQuery.Append(" WHERE YPGO_STAT IN ('20') ");
                    sbQuery.Append(" GROUP BY PLT_CODE , BALJU_NUM ,BALJU_SEQ ");
                    sbQuery.Append(" ) CHK_YPGO ");
                    sbQuery.Append(" ON B.PLT_CODE = CHK_YPGO.PLT_CODE ");
                    sbQuery.Append(" AND B.BALJU_NUM = CHK_YPGO.BALJU_NUM ");
                    sbQuery.Append(" AND B.BALJU_SEQ = CHK_YPGO.BALJU_SEQ ");
                    sbQuery.Append(" LEFT JOIN  ");
                    sbQuery.Append(" ( ");
                    sbQuery.Append(" SELECT PLT_CODE , BALJU_NUM , BALJU_SEQ , ISNULL(SUM(QTY),0) AS QTY FROM TMAT_YPGO   ");
                    sbQuery.Append(" WHERE YPGO_STAT IN ('24','25') ");
                    sbQuery.Append(" GROUP BY PLT_CODE , BALJU_NUM ,BALJU_SEQ ");
                    sbQuery.Append(" ) NG_YPGO ");
                    sbQuery.Append(" ON B.PLT_CODE = NG_YPGO.PLT_CODE ");
                    sbQuery.Append(" AND B.BALJU_NUM = NG_YPGO.BALJU_NUM ");
                    sbQuery.Append(" AND B.BALJU_SEQ = NG_YPGO.BALJU_SEQ ");
                    sbQuery.Append(" WHERE ");
                    sbQuery.Append(" B.BAL_STAT IN ('13','21')");
                    sbQuery.Append(" AND (ISNULL(B.QTY,0) - (ISNULL(YPGO.QTY,0) + ISNULL(CHK_YPGO.QTY,0) + ISNULL(NG_YPGO.QTY,0))) > 0 ");
                    sbQuery.Append(" ) AS U ");

                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE BALJU_REG ");
                    sbQuery.Append(" ON U.PLT_CODE = BALJU_REG.PLT_CODE ");
                    sbQuery.Append(" AND U.BALJU_REG_EMP = BALJU_REG.EMP_CODE ");

                    sbQuery.Append(" LEFT JOIN TMAT_QUC_MASTER Q ");
                    sbQuery.Append(" ON U.PLT_CODE = Q.PLT_CODE  ");
                    sbQuery.Append(" AND U.PART_QLTY = Q.MQLTY_CODE ");

                    sbQuery.Append(" LEFT JOIN TSTD_VENDOR V ");
                    sbQuery.Append(" ON U.PLT_CODE = V.PLT_CODE ");
                    sbQuery.Append(" AND U.VEN_CODE = V.VEN_CODE ");

                    sbQuery.Append(" LEFT JOIN TSTD_VENDOR CV ");
                    sbQuery.Append(" ON U.PLT_CODE = CV.PLT_CODE ");
                    sbQuery.Append(" AND U.CVND_CODE = CV.VEN_CODE ");

                    sbQuery.Append(" LEFT OUTER JOIN (SELECT PLT_CODE, LINK_KEY FROM TSYS_FILELIST_MASTER WHERE IS_UPLOAD = 1 AND UPLOAD_MENU = 'PLN01A' AND DATA_FLAG = 0 GROUP BY PLT_CODE, LINK_KEY) FM ");
                    sbQuery.Append(" ON U.PLT_CODE = FM.PLT_CODE AND U.PART_CODE = FM.LINK_KEY ");

                    sbQuery.Append("  LEFT JOIN TSTD_CODES CD ");
                    sbQuery.Append("  ON U.PLT_CODE = CD.PLT_CODE ");
                    sbQuery.Append("  AND U.PART_PRODTYPE = CD.CD_CODE ");
                    sbQuery.Append("  AND CD.CAT_CODE = 'M007' ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE U.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@BALJU_NUM", " U.BALJU_NUM = @BALJU_NUM "));
                        sbWhere.Append(UTIL.GetWhere(row, "@BALJU_NUM_LIKE", " (U.BALJU_NUM LIKE '%' + @BALJU_NUM_LIKE + '%') "));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_BALJU_DATE,@E_BALJU_DATE", " (U.BALJU_DATE BETWEEN @S_BALJU_DATE AND @E_BALJU_DATE) "));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_DUE_DATE,@E_DUE_DATE", " (U.DUE_DATE BETWEEN @S_DUE_DATE AND @E_DUE_DATE) "));
                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_CODE", " U.PROD_CODE = @PROD_CODE "));
                        sbWhere.Append(UTIL.GetWhere(row, "@ITEM_CODE", " U.ITEM_CODE = @ITEM_CODE "));
                        sbWhere.Append(UTIL.GetWhere(row, "@MVND_CODE", " U.VEN_CODE = @MVND_CODE "));

                        sbWhere.Append(UTIL.GetWhere(row, "@BALJU_SEQ", " U.BALJU_SEQ = @BALJU_SEQ "));
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_CODE", " U.PART_CODE = @PART_CODE "));
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_NUM_LIKE", " (U.PART_NUM LIKE '%' + @PART_NUM_LIKE + '%') "));


                        //search_con : 검색 통합 거래처,발주번호,공정명,수주코드,수주처명,품목코드,도면번호,품목명,제품규격,형식,재질,제품규격,소재규격,발주규격
                        //V.VEN_NAME, BALJU_NUM, PROC_NAME, ITEM_CODE, CV.VEN_NAME, PART_CODE, DRAW_NO, PART_NAME, MAT_SPEC1, PART_PRODTYPE, MAT_QLTY, MAT_SPEC, BAL_SPEC
                        string cond = "(V.VEN_NAME LIKE '%' + @SEARCH_CON + '%' OR U.BALJU_NUM LIKE '%' + @SEARCH_CON + '%' OR ";
                        cond += " U.ITEM_CODE LIKE '%' + @SEARCH_CON + '%' OR CV.VEN_NAME LIKE '%' + @SEARCH_CON + '%' OR ";
                        cond += " U.PART_CODE LIKE '%' + @SEARCH_CON + '%' OR U.PART_NAME LIKE '%' + @SEARCH_CON + '%' OR ";
                        cond += " U.PART_SPEC1 LIKE '%' + @SEARCH_CON + '%' OR U.PART_SPEC LIKE '%' + @SEARCH_CON + '%' OR U.BAL_SPEC LIKE '%' + @SEARCH_CON + '%'";

                        cond += " OR CD.CD_NAME LIKE '%' + @SEARCH_CON + '%' ";
                        //cond += " OR U.PART_PRODTYPE LIKE '%' + @SEARCH_CON + '%' ";

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

        public static DataTable TMAT_BALJU_QUERY8(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT  ");
                    sbQuery.Append(" B.PLT_CODE ");
                    sbQuery.Append(" ,B.REQUEST_NO ");
                    sbQuery.Append(" ,B.REQUEST_SEQ ");
                    sbQuery.Append(" ,B.BALJU_NUM ");
                    sbQuery.Append(" ,B.BALJU_SEQ ");
                    sbQuery.Append(" ,B.BAL_STAT ");
                    sbQuery.Append(" ,BM.BALJU_DATE ");
                    sbQuery.Append(" ,B.DUE_DATE ");
                    sbQuery.Append(" ,BM.MVND_CODE AS VEN_CODE ");
                    sbQuery.Append(" ,V.VEN_NAME ");
                    sbQuery.Append(" ,B.REG_EMP ");
                    sbQuery.Append(" ,REG_EMP.EMP_NAME AS REG_EMP_NAME ");
                    sbQuery.Append(" ,R.PART_CODE ");
                    sbQuery.Append(" ,SP.PART_NAME  ");
                    sbQuery.Append(" ,SP.PART_PRODTYPE ");
                    sbQuery.Append(" ,SP.DRAW_NO ");
                    sbQuery.Append(" ,SP.MAT_LTYPE ");
                    sbQuery.Append(" ,SP.MAT_MTYPE ");
                    sbQuery.Append(" ,SP.MAT_STYPE ");
                    sbQuery.Append(" ,SP.MAT_QLTY AS PART_QLTY ");
                    sbQuery.Append(" ,QUC.MQLTY_NAME AS PART_QLTY_NAME ");
                    sbQuery.Append(" ,SP.MAT_SPEC AS PART_SPEC ");
                    sbQuery.Append(" ,SP.MAT_SPEC1 AS PART_SPEC1 ");
                    sbQuery.Append(" ,SP.BAL_SPEC  ");
                    sbQuery.Append(" ,SP.MAT_WEIGHT1  ");
                    sbQuery.Append(" ,SP.MAT_WEIGHT  ");
                    sbQuery.Append(" ,SP.BAL_WEIGHT  ");
                    sbQuery.Append(" ,SP.MAT_UNIT ");
                    sbQuery.Append(" ,B.MAT_SPEC AS B_MAT_SPEC ");
                    sbQuery.Append(" ,B.MAT_WEIGHT AS B_WEIGHT ");

                    sbQuery.Append(" ,B.UNIT_COST ");
                    sbQuery.Append(" ,B.QTY ");
                    sbQuery.Append(" ,ISNULL(B.QTY,0) AS COMPARE_QTY");
                    sbQuery.Append(" ,B.AMT ");
                    sbQuery.Append(" ,BM.SCOMMENT AS BAL_SCOMMENT ");
                    sbQuery.Append(" ,NULL AS SCOMMENT ");
                    sbQuery.Append(" ,B.REG_EMP ");
                    sbQuery.Append(" ,REG.EMP_NAME AS REG_EMP_NAME ");

                    sbQuery.Append(" ,TI.CVND_CODE ");
                    sbQuery.Append(" ,CV.VEN_NAME AS CVND_NAME ");

                    sbQuery.Append(" ,TI.ITEM_CODE ");
                    sbQuery.Append(" ,R.PROD_CODE ");
                    sbQuery.Append(" ,R.WO_NO ");
                    sbQuery.Append(" ,SP.DRAW_NO ");
                    sbQuery.Append(" ,SP.PART_PRODTYPE ");

                    sbQuery.Append(" FROM TMAT_BALJU B ");
                    sbQuery.Append(" JOIN TMAT_BALJU_MASTER BM ");
                    sbQuery.Append(" ON B.PLT_CODE = BM.PLT_CODE ");
                    sbQuery.Append(" AND B.BALJU_NUM = BM.BALJU_NUM ");
                    sbQuery.Append(" LEFT JOIN TMAT_REQUEST R  ");
                    sbQuery.Append(" ON B.PLT_CODE = R.PLT_CODE ");
                    sbQuery.Append(" AND B.REQUEST_NO = R.REQUEST_NO ");
                    sbQuery.Append(" AND B.REQUEST_SEQ = R.REQUEST_SEQ ");
                    sbQuery.Append(" LEFT JOIN TMAT_REQUEST_MASTER RM ");
                    sbQuery.Append(" ON R.PLT_CODE = RM.PLT_CODE ");
                    sbQuery.Append(" AND R.REQUEST_NO = RM.REQUEST_NO ");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE REG_EMP ");
                    sbQuery.Append(" ON B.PLT_CODE = REG_EMP.PLT_CODE ");
                    sbQuery.Append(" AND B.REG_EMP = REG_EMP.EMP_CODE ");
                    sbQuery.Append(" LEFT JOIN LSE_STD_PART SP ");
                    sbQuery.Append(" ON R.PLT_CODE = SP.PLT_CODE ");
                    sbQuery.Append(" AND R.PART_CODE = SP.PART_CODE ");
                    sbQuery.Append(" LEFT JOIN TSTD_VENDOR V ");
                    sbQuery.Append(" ON B.PLT_CODE = V.PLT_CODE ");
                    sbQuery.Append(" AND BM.MVND_CODE = V.VEN_CODE ");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE REG ");
                    sbQuery.Append(" ON B.PLT_CODE = REG.PLT_CODE ");
                    sbQuery.Append(" AND B.REG_EMP = REG.EMP_CODE ");
                    sbQuery.Append(" LEFT JOIN TMAT_QUC_MASTER QUC ");
                    sbQuery.Append(" ON SP.PLT_CODE = QUC.PLT_CODE ");
                    sbQuery.Append(" AND SP.MAT_QLTY = QUC.MQLTY_CODE ");

                    sbQuery.Append(" LEFT JOIN TORD_PRODUCT TP ");
                    sbQuery.Append(" ON R.PLT_CODE = TP.PLT_CODE ");
                    sbQuery.Append(" AND R.PROD_CODE = TP.PROD_CODE ");
                    sbQuery.Append(" AND R.PART_CODE = TP.PART_CODE ");
                    sbQuery.Append(" LEFT JOIN TORD_ITEM TI ");
                    sbQuery.Append(" ON TP.PLT_CODE = TI.PLT_CODE ");
                    sbQuery.Append(" AND TP.ITEM_CODE = TI.ITEM_CODE ");

                    sbQuery.Append(" LEFT JOIN TSTD_VENDOR CV ");
                    sbQuery.Append(" ON TI.PLT_CODE = CV.PLT_CODE ");
                    sbQuery.Append(" AND TI.CVND_CODE = CV.VEN_CODE ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE B.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@BALJU_NUM", " B.BALJU_NUM = @BALJU_NUM "));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_BALJU_DATE,@E_BALJU_DATE", " (BM.BALJU_DATE BETWEEN @S_BALJU_DATE AND @E_BALJU_DATE) "));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_DUE_DATE,@E_DUE_DATE", " (B.DUE_DATE BETWEEN @S_DUE_DATE AND @E_DUE_DATE) "));
                        sbWhere.Append(UTIL.GetWhere(row, "@MVND_CODE", " BM.MVND_CODE = @MVND_CODE "));
                        sbWhere.Append(UTIL.GetWhere(row, "@BAL_STAT", " B.BAL_STAT = @BAL_STAT "));

                        sbWhere.Append(UTIL.GetWhere(row, "@REG_EMP", " B.REG_EMP = @REG_EMP "));
                        sbWhere.Append(UTIL.GetWhere(row, "@BALJU_SEQ", " B.BALJU_SEQ = @BALJU_SEQ "));
                        sbWhere.Append(UTIL.GetWhere(row, "@ITEM_CODE", " TI.ITEM_CODE = @ITEM_CODE "));

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

        //발주시 같은부품으로 발주,발주승인 상태를 확인한다.
        public static DataTable TMAT_BALJU_QUERY13(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT B.PLT_CODE ");
                    sbQuery.Append("       ,B.BALJU_NUM ");
                    sbQuery.Append("       ,B.BALJU_SEQ ");
                    sbQuery.Append("       ,B.REQUEST_NO ");
                    sbQuery.Append("       ,B.REQUEST_SEQ ");
                    sbQuery.Append("       ,B.UNIT_COST ");
                    sbQuery.Append("       ,B.QTY ");
                    sbQuery.Append("       ,B.AMT ");
                    sbQuery.Append("       ,BM.BALJU_DATE ");
                    sbQuery.Append("       ,B.DUE_DATE ");
                    sbQuery.Append("       ,BM.REG_EMP AS BALJU_REG_EMP ");
                    sbQuery.Append("       ,BE.EMP_NAME AS BALJU_REG_EMP_NAME ");
                    sbQuery.Append("       ,B.BAL_STAT ");
                    sbQuery.Append("       ,BM.MVND_CODE AS VEN_CODE ");
                    sbQuery.Append("       ,MV.VEN_NAME ");
                    sbQuery.Append("       ,PT.PROD_CODE ");
                    sbQuery.Append("       ,PT.PART_CODE ");
                    sbQuery.Append("       ,PT.PART_NUM ");
                    sbQuery.Append("       ,PT.PT_NAME AS PART_NAME ");
                    sbQuery.Append("       ,PT.PT_ID ");
                    sbQuery.Append("   FROM TMAT_BALJU B ");
                    sbQuery.Append(" LEFT JOIN TMAT_BALJU_MASTER BM ");
                    sbQuery.Append(" ON B.PLT_CODE = BM.PLT_CODE ");
                    sbQuery.Append(" AND B.BALJU_NUM = BM.BALJU_NUM ");
                    sbQuery.Append(" LEFT JOIN TSTD_VENDOR MV ");
                    sbQuery.Append(" ON BM.PLT_CODE = MV.PLT_CODE ");
                    sbQuery.Append(" AND BM.MVND_CODE = MV.VEN_CODE ");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE BE ");
                    sbQuery.Append(" ON BM.PLT_CODE = BE.PLT_CODE ");
                    sbQuery.Append(" AND BM.REG_EMP = BE.EMP_CODE ");
                    sbQuery.Append(" LEFT JOIN TMAT_PUR_PARTLIST PT ");
                    sbQuery.Append(" ON B.PLT_CODE = PT.PLT_CODE ");
                    sbQuery.Append(" AND B.REQUEST_NO = PT.REQUEST_NO ");
                    sbQuery.Append(" AND B.REQUEST_SEQ = PT.REQUEST_SEQ ");
                    sbQuery.Append(" WHERE ");
                    sbQuery.Append(" B.PLT_CODE = @PLT_CODE ");
                    sbQuery.Append(" AND PT.PT_ID = @PT_ID ");
                    sbQuery.Append(" AND B.BAL_STAT IN ('11','13') ");



                    foreach (DataRow row in dtParam.Rows)
                    {
                        DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString(), row).Copy();

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

        public static DataTable TMAT_BALJU_QUERY15(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT             ");
                    sbQuery.Append(" B.PLT_CODE         ");
                    sbQuery.Append(" ,'M' AS PUR_TYPE   ");
                    sbQuery.Append(" ,I.CVND_CODE       ");
                    sbQuery.Append(" ,V.VEN_NAME AS CVND_NAME       ");
                    sbQuery.Append(" ,I.ITEM_CODE       ");
                    sbQuery.Append(" ,I.ITEM_NAME       ");
                    sbQuery.Append(" ,I.SALECONFM_DATE  ");
                    sbQuery.Append(" ,R.PROD_CODE       ");
                    sbQuery.Append(" ,P.PROD_NAME       ");
                    sbQuery.Append(" ,PT.PART_CODE      ");
                    sbQuery.Append(" ,PT.PART_NAME      ");
                    sbQuery.Append(" ,PT.MAT_LTYPE      ");
                    sbQuery.Append(" ,PT.MAT_MTYPE      ");
                    sbQuery.Append(" ,PT.MAT_STYPE      ");
                    sbQuery.Append(" ,PT.MAT_UNIT       ");
                    sbQuery.Append(" ,PT.PART_PRODTYPE  ");
                    sbQuery.Append(" ,PT.MAT_QLTY       ");
                    sbQuery.Append(" ,Q.MQLTY_NAME AS PART_QLTY_NAME ");
                    sbQuery.Append(" ,PT.MAT_SPEC      ");
                    sbQuery.Append(" ,PT.MAT_SPEC1     ");
                    sbQuery.Append(" ,PT.MAT_SPEC  AS PART_SPEC    ");
                    sbQuery.Append(" ,PT.MAT_SPEC1  AS PART_SPEC1   ");
                    sbQuery.Append(" ,PT.DRAW_NO     ");
                    sbQuery.Append(" ,R.REQUEST_NO     ");
                    sbQuery.Append(" ,R.REQUEST_SEQ    ");
                    sbQuery.Append(" ,RM.REQ_DATE      ");
                    sbQuery.Append(" ,RM.DUE_DATE AS REQ_DUE_DATE             ");
                    sbQuery.Append(" ,R.QTY AS REQ_QTY                        ");
                    sbQuery.Append(" ,R.REG_EMP AS REQ_REG_EMP                ");
                    sbQuery.Append(" ,REQ_EMP.EMP_NAME AS REQ_REG_EMP_NAME    ");
                    sbQuery.Append(" ,B.BAL_STAT                              ");
                    sbQuery.Append(" ,B.BALJU_NUM                             ");
                    sbQuery.Append(" ,B.BALJU_SEQ                             ");
                    sbQuery.Append(" ,BM.BALJU_DATE                           ");
                    sbQuery.Append(" ,BM.MVND_CODE AS BALJU_VEN_CODE          ");
                    sbQuery.Append(" ,BAL_VEN.VEN_NAME AS BALJU_VEN_NAME      ");
                    sbQuery.Append(" ,B.DUE_DATE AS BALJU_DUE_DATE            ");
                    sbQuery.Append(" ,B.UNIT_COST AS BAL_UNIT_COST            ");
                    sbQuery.Append(" ,B.QTY AS BAL_QTY                        ");
                    sbQuery.Append(" ,B.AMT AS BAL_AMT                        ");
                    sbQuery.Append(" ,B.MAT_SPEC AS B_MAT_SPEC ");
                    sbQuery.Append(" ,B.MAT_WEIGHT AS B_WEIGHT  ");
                    sbQuery.Append(" ,B.REG_EMP AS BAL_REG_EMP                ");
                    sbQuery.Append(" ,BAL_EMP.EMP_NAME AS BAL_REG_EMP_NAME    ");
                    sbQuery.Append(" ,B.C_REASON ");
                    sbQuery.Append(" ,B.SCOMMENT ");
                    sbQuery.Append(" ,Y.YPGO_ID                               ");
                    sbQuery.Append(" ,Y.YPGO_DATE                             ");
                    sbQuery.Append(" ,Y.QTY AS YPGO_QTY                       ");
                    sbQuery.Append(" ,Y.YPGO_STAT                             ");
                    sbQuery.Append(" ,Y.REG_EMP AS YPGO_REG_EMP               ");
                    sbQuery.Append(" ,YPGO_EMP.EMP_NAME AS YPGO_REG_EMP_NAME  ");
                    sbQuery.Append(" ,Y.INS_EMP                               ");
                    sbQuery.Append(" ,YI_EMP.EMP_NAME AS INS_EMP_NAME         ");
                    sbQuery.Append(" ,Y.INS_DATE                              ");
                    sbQuery.Append(" ,Y.SCOMMENT AS YPGO_SCOMMENT             ");
                    
                    sbQuery.Append(" ,SPR.PUR_SCOMMENT                        ");

                    sbQuery.Append(" FROM                                     ");
                    sbQuery.Append(" TMAT_BALJU B                             ");
                    sbQuery.Append("  JOIN TMAT_BALJU_MASTER BM           ");
                    sbQuery.Append(" ON B.PLT_CODE = BM.PLT_CODE              ");
                    sbQuery.Append(" AND B.BALJU_NUM = BM.BALJU_NUM           ");

                    sbQuery.Append("  JOIN TMAT_REQUEST R                 ");
                    sbQuery.Append(" ON B.PLT_CODE = R.PLT_CODE               ");
                    sbQuery.Append(" AND B.REQUEST_NO = R.REQUEST_NO          ");
                    sbQuery.Append(" AND B.REQUEST_SEQ = R.REQUEST_SEQ        ");

                    sbQuery.Append("  JOIN TMAT_REQUEST_MASTER RM         ");
                    sbQuery.Append(" ON R.PLT_CODE = RM.PLT_CODE              ");
                    sbQuery.Append(" AND R.REQUEST_NO = RM.REQUEST_NO         ");

                    sbQuery.Append("  JOIN LSE_STD_PART PT                ");
                    sbQuery.Append(" ON R.PLT_CODE = PT.PLT_CODE              ");
                    sbQuery.Append(" AND R.PART_CODE = PT.PART_CODE           ");

                    sbQuery.Append("  JOIN TORD_PRODUCT P                 ");
                    sbQuery.Append(" ON R.PLT_CODE = P.PLT_CODE               ");
                    sbQuery.Append(" AND R.PROD_CODE = P.PROD_CODE            ");
                    sbQuery.Append(" AND R.PART_CODE = P.PART_CODE            ");

                    sbQuery.Append("  JOIN TORD_ITEM I                    ");
                    sbQuery.Append(" ON P.PLT_CODE = I.PLT_CODE               ");
                    sbQuery.Append(" AND P.ITEM_CODE = I.ITEM_CODE            ");

                    sbQuery.Append("  JOIN TSTD_VENDOR V       ");
                    sbQuery.Append(" ON I.PLT_CODE = V.PLT_CODE   ");
                    sbQuery.Append(" AND I.CVND_CODE = V.VEN_CODE ");

                    sbQuery.Append("  JOIN LSE_STD_PARTPROC SPR      ");
                    sbQuery.Append(" ON R.PLT_CODE = SPR.PLT_CODE    ");
                    sbQuery.Append(" AND R.PART_CODE = SPR.PART_CODE ");
                    sbQuery.Append(" AND SPR.PROC_CODE = 'P-02' ");

                    sbQuery.Append(" LEFT JOIN TMAT_YPGO Y                    ");
                    sbQuery.Append(" ON B.PLT_CODE = Y.PLT_CODE               ");
                    sbQuery.Append(" AND B.BALJU_NUM = Y.BALJU_NUM            ");
                    sbQuery.Append(" AND B.BALJU_SEQ = Y.BALJU_SEQ            ");
                    sbQuery.Append(" AND Y.YPGO_STAT IN ('19','20','21','22','24','25','31','32') ");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE YI_EMP      ");
                    sbQuery.Append(" ON Y.PLT_CODE = YI_EMP.PLT_CODE     ");
                    sbQuery.Append(" AND Y.INS_EMP = YI_EMP.EMP_CODE     ");

                    sbQuery.Append(" LEFT JOIN TMAT_QUC_MASTER Q         ");
                    sbQuery.Append(" ON PT.PLT_CODE = Q.PLT_CODE         ");
                    sbQuery.Append(" AND PT.MAT_QLTY = Q.MQLTY_CODE      ");

                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE REQ_EMP     ");
                    sbQuery.Append(" ON R.PLT_CODE = REQ_EMP.PLT_CODE    ");
                    sbQuery.Append(" AND R.REG_EMP = REQ_EMP.EMP_CODE    ");

                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE BAL_EMP     ");
                    sbQuery.Append(" ON B.PLT_CODE = BAL_EMP.PLT_CODE    ");
                    sbQuery.Append(" AND B.REG_EMP = BAL_EMP.EMP_CODE    ");

                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE YPGO_EMP    ");
                    sbQuery.Append(" ON Y.PLT_CODE = YPGO_EMP.PLT_CODE   ");
                    sbQuery.Append(" AND Y.REG_EMP = YPGO_EMP.EMP_CODE   ");

                    sbQuery.Append(" LEFT JOIN TSTD_VENDOR BAL_VEN       ");
                    sbQuery.Append(" ON BM.PLT_CODE = BAL_VEN.PLT_CODE   ");
                    sbQuery.Append(" AND BM.MVND_CODE = BAL_VEN.VEN_CODE ");

                    
                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE B.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@BALJU_NUM", " B.BALJU_NUM = @BALJU_NUM "));
                        sbWhere.Append(UTIL.GetWhere(row, "@BALJU_NUM_LIKE", " (BM.BALJU_NUM LIKE '%' + @BALJU_NUM_LIKE + '%') "));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_BALJU_DATE,@E_BALJU_DATE", " (BM.BALJU_DATE BETWEEN @S_BALJU_DATE AND @E_BALJU_DATE) "));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_DUE_DATE,@E_DUE_DATE", " (B.DUE_DATE BETWEEN @S_DUE_DATE AND @E_DUE_DATE) "));
                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_CODE", " R.PROD_CODE = @PROD_CODE "));
                        sbWhere.Append(UTIL.GetWhere(row, "@MVND_CODE", " B.VEN_CODE = @MVND_CODE "));

                        sbWhere.Append(UTIL.GetWhere(row, "@BALJU_SEQ", " B.BALJU_SEQ = @BALJU_SEQ "));
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_CODE", " R.PART_CODE = @PART_CODE "));
                        sbWhere.Append(UTIL.GetWhere(row, "@ITEM_CODE", " I.ITEM_CODE = @ITEM_CODE "));
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_LIKE", "(R.PART_CODE LIKE '%' + @PART_LIKE + '%' OR PT.PART_NAME LIKE '%' + @PART_LIKE + '%')"));

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


        public static DataTable TMAT_BALJU_QUERY16(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT             ");
                    sbQuery.Append(" B.PLT_CODE         ");
                    sbQuery.Append(" ,'M' AS PUR_TYPE   ");
                    
                    sbQuery.Append(" ,PT.PART_CODE      ");
                    sbQuery.Append(" ,PT.PART_NAME      ");
                    sbQuery.Append(" ,PT.MAT_LTYPE      ");
                    sbQuery.Append(" ,PT.MAT_MTYPE      ");
                    sbQuery.Append(" ,PT.MAT_STYPE      ");
                    sbQuery.Append(" ,PT.MAT_UNIT       ");
                    sbQuery.Append(" ,PT.PART_PRODTYPE  ");
                    sbQuery.Append(" ,PT.MAT_QLTY       ");
                    sbQuery.Append(" ,Q.MQLTY_NAME AS PART_QLTY_NAME ");
                    sbQuery.Append(" ,PT.MAT_SPEC      ");
                    sbQuery.Append(" ,PT.MAT_SPEC1     ");
                    sbQuery.Append(" ,PT.MAT_SPEC  AS PART_SPEC    ");
                    sbQuery.Append(" ,PT.MAT_SPEC1  AS PART_SPEC1   ");
                    sbQuery.Append(" ,PT.DRAW_NO     ");
                    sbQuery.Append(" ,R.REQUEST_NO     ");
                    sbQuery.Append(" ,R.REQUEST_SEQ    ");
                    sbQuery.Append(" ,RM.REQ_DATE      ");
                    sbQuery.Append(" ,RM.DUE_DATE AS REQ_DUE_DATE             ");
                    sbQuery.Append(" ,R.QTY AS REQ_QTY                        ");
                    sbQuery.Append(" ,R.REG_EMP AS REQ_REG_EMP                ");
                    sbQuery.Append(" ,REQ_EMP.EMP_NAME AS REQ_REG_EMP_NAME    ");
                    sbQuery.Append(" ,B.BAL_STAT                              ");
                    sbQuery.Append(" ,B.BALJU_NUM                             ");
                    sbQuery.Append(" ,B.BALJU_SEQ                             ");
                    sbQuery.Append(" ,BM.BALJU_DATE                           ");
                    sbQuery.Append(" ,BM.MVND_CODE AS BALJU_VEN_CODE          ");
                    sbQuery.Append(" ,BAL_VEN.VEN_NAME AS BALJU_VEN_NAME      ");
                    sbQuery.Append(" ,B.DUE_DATE AS BALJU_DUE_DATE            ");
                    sbQuery.Append(" ,B.UNIT_COST AS BAL_UNIT_COST            ");
                    sbQuery.Append(" ,B.QTY AS BAL_QTY                        ");
                    sbQuery.Append(" ,B.AMT AS BAL_AMT                        ");
                    sbQuery.Append(" ,B.MAT_SPEC AS B_MAT_SPEC ");
                    sbQuery.Append(" ,B.MAT_WEIGHT AS B_WEIGHT  ");
                    sbQuery.Append(" ,B.REG_EMP AS BAL_REG_EMP                ");
                    sbQuery.Append(" ,BAL_EMP.EMP_NAME AS BAL_REG_EMP_NAME    ");
                    sbQuery.Append(" ,B.C_REASON ");
                    sbQuery.Append(" ,Y.YPGO_ID                               ");
                    sbQuery.Append(" ,Y.YPGO_DATE                             ");
                    sbQuery.Append(" ,Y.QTY AS YPGO_QTY                       ");
                    sbQuery.Append(" ,Y.YPGO_STAT                             ");
                    sbQuery.Append(" ,Y.REG_EMP AS YPGO_REG_EMP               ");
                    sbQuery.Append(" ,YPGO_EMP.EMP_NAME AS YPGO_REG_EMP_NAME  ");
                    sbQuery.Append(" ,Y.INS_EMP                               ");
                    sbQuery.Append(" ,YI_EMP.EMP_NAME AS INS_EMP_NAME         ");
                    sbQuery.Append(" ,Y.INS_DATE                              ");
                    sbQuery.Append(" ,Y.SCOMMENT AS YPGO_SCOMMENT             ");
                    sbQuery.Append(" ,SPR.SCOMMENT                            ");
                    sbQuery.Append(" ,SPR.PUR_SCOMMENT                        ");
                    sbQuery.Append(" ,B.SCOMMENT AS BAL_SCOMMENT              ");

                    sbQuery.Append(" FROM                                     ");
                    sbQuery.Append(" TMAT_BALJU B                             ");
                    sbQuery.Append("  JOIN TMAT_BALJU_MASTER BM           ");
                    sbQuery.Append(" ON B.PLT_CODE = BM.PLT_CODE              ");
                    sbQuery.Append(" AND B.BALJU_NUM = BM.BALJU_NUM           ");

                    sbQuery.Append("  JOIN TMAT_REQUEST R                 ");
                    sbQuery.Append(" ON B.PLT_CODE = R.PLT_CODE               ");
                    sbQuery.Append(" AND B.REQUEST_NO = R.REQUEST_NO          ");
                    sbQuery.Append(" AND B.REQUEST_SEQ = R.REQUEST_SEQ        ");

                    sbQuery.Append("  JOIN TMAT_REQUEST_MASTER RM         ");
                    sbQuery.Append(" ON R.PLT_CODE = RM.PLT_CODE              ");
                    sbQuery.Append(" AND R.REQUEST_NO = RM.REQUEST_NO         ");

                    sbQuery.Append("  JOIN LSE_STD_PART PT                ");
                    sbQuery.Append(" ON R.PLT_CODE = PT.PLT_CODE              ");
                    sbQuery.Append(" AND R.PART_CODE = PT.PART_CODE           ");

                    sbQuery.Append(" LEFT JOIN LSE_STD_PARTPROC SPR         ");
                    sbQuery.Append(" ON R.PLT_CODE = SPR.PLT_CODE           ");
                    sbQuery.Append(" AND R.PART_CODE = SPR.PART_CODE        ");
                    sbQuery.Append(" AND SPR.PROC_CODE = 'P-02'             ");


                    sbQuery.Append(" LEFT JOIN TMAT_YPGO Y                    ");
                    sbQuery.Append(" ON B.PLT_CODE = Y.PLT_CODE               ");
                    sbQuery.Append(" AND B.BALJU_NUM = Y.BALJU_NUM            ");
                    sbQuery.Append(" AND B.BALJU_SEQ = Y.BALJU_SEQ            ");
                    sbQuery.Append(" AND Y.YPGO_STAT IN ('19','20','21','22','24','25','31','32') ");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE YI_EMP      ");
                    sbQuery.Append(" ON Y.PLT_CODE = YI_EMP.PLT_CODE     ");
                    sbQuery.Append(" AND Y.INS_EMP = YI_EMP.EMP_CODE     ");

                    sbQuery.Append(" LEFT JOIN TMAT_QUC_MASTER Q         ");
                    sbQuery.Append(" ON PT.PLT_CODE = Q.PLT_CODE         ");
                    sbQuery.Append(" AND PT.MAT_QLTY = Q.MQLTY_CODE      ");

                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE REQ_EMP     ");
                    sbQuery.Append(" ON R.PLT_CODE = REQ_EMP.PLT_CODE    ");
                    sbQuery.Append(" AND R.REG_EMP = REQ_EMP.EMP_CODE    ");

                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE BAL_EMP     ");
                    sbQuery.Append(" ON B.PLT_CODE = BAL_EMP.PLT_CODE    ");
                    sbQuery.Append(" AND B.REG_EMP = BAL_EMP.EMP_CODE    ");

                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE YPGO_EMP    ");
                    sbQuery.Append(" ON Y.PLT_CODE = YPGO_EMP.PLT_CODE   ");
                    sbQuery.Append(" AND Y.REG_EMP = YPGO_EMP.EMP_CODE   ");

                    sbQuery.Append(" LEFT JOIN TSTD_VENDOR BAL_VEN       ");
                    sbQuery.Append(" ON BM.PLT_CODE = BAL_VEN.PLT_CODE   ");
                    sbQuery.Append(" AND BM.MVND_CODE = BAL_VEN.VEN_CODE ");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE B.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append("AND R.PROD_CODE IS NULL ");

                        sbWhere.Append(UTIL.GetWhere(row, "@BALJU_NUM", " B.BALJU_NUM = @BALJU_NUM "));
                        sbWhere.Append(UTIL.GetWhere(row, "@BALJU_NUM_LIKE", " (BM.BALJU_NUM LIKE '%' + @BALJU_NUM_LIKE + '%') "));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_BALJU_DATE,@E_BALJU_DATE", " (BM.BALJU_DATE BETWEEN @S_BALJU_DATE AND @E_BALJU_DATE) "));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_DUE_DATE,@E_DUE_DATE", " (B.DUE_DATE BETWEEN @S_DUE_DATE AND @E_DUE_DATE) "));
                        
                        sbWhere.Append(UTIL.GetWhere(row, "@MVND_CODE", " B.VEN_CODE = @MVND_CODE "));

                        sbWhere.Append(UTIL.GetWhere(row, "@BALJU_SEQ", " B.BALJU_SEQ = @BALJU_SEQ "));
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_CODE", " R.PART_CODE = @PART_CODE "));
                        
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_LIKE", "(R.PART_CODE LIKE '%' + @PART_LIKE + '%' OR PT.PART_NAME LIKE '%' + @PART_LIKE + '%')"));

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

        public static DataTable TMAT_BALJU_QUERY17(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT  B.PLT_CODE           			   ");
                    sbQuery.Append(" 	  , R.PART_CODE       				   ");
                    sbQuery.Append(" 	  , B.QTY AS BAL_QTY				   ");
                    sbQuery.Append("      , YP.QTY AS YPGO_QTY				  ");
                    sbQuery.Append(" 	  , BM.BALJU_DATE					   ");
                    sbQuery.Append(" 	  , YP.YPGO_DATE					   ");
                    sbQuery.Append(" 	  , B.BALJU_NUM					   ");
                    sbQuery.Append(" 	  , B.BALJU_SEQ					   ");
                    sbQuery.Append("   FROM TMAT_BALJU B         			   ");
                    sbQuery.Append(" 	INNER JOIN TMAT_REQUEST R        	   ");
                    sbQuery.Append(" 		ON B.PLT_CODE = R.PLT_CODE     	   ");
                    sbQuery.Append(" 		AND B.REQUEST_NO = R.REQUEST_NO    ");
                    sbQuery.Append(" 		AND B.REQUEST_SEQ = R.REQUEST_SEQ  ");
                    sbQuery.Append(" 	INNER JOIN TMAT_BALJU_MASTER BM		   ");
                    sbQuery.Append(" 		ON B.PLT_CODE = BM.PLT_CODE		   ");
                    sbQuery.Append(" 		AND B.BALJU_NUM = BM.BALJU_NUM	   ");
                    sbQuery.Append(" 	LEFT JOIN TMAT_YPGO YP				   ");
                    sbQuery.Append(" 		ON B.PLT_CODE = YP.PLT_CODE		   ");
                    sbQuery.Append(" 		AND B.BALJU_NUM = YP.BALJU_NUM	   ");
                    sbQuery.Append(" 		AND B.BALJU_SEQ = YP.BALJU_SEQ	   ");
                    //sbQuery.Append(" 		AND YP.YPGO_DATE IS NULL	   ");

                    //sbQuery.Append(" 	INNER JOIN TMAT_STOCK_LOG L				   ");
                    //sbQuery.Append(" 		ON R.PLT_CODE = L.PLT_CODE		   ");
                    //sbQuery.Append(" 		AND R.PART_CODE = L.PART_CODE	   ");
                    //sbQuery.Append(" 		AND ((L.EVENT_TIME BETWEEN BM.BALJU_DATE AND YP.YPGO_DATE)	   ");
                    //sbQuery.Append(" 			OR (YP.YPGO_DATE IS NULL AND L.EVENT_TIME > BM.BALJU_DATE))	   ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder();
                        if (UTIL.ValidColumn(row, "STK_GROUP"))
                        {
                            sbWhere.Append(" 	INNER JOIN TSTD_STOCK_GRP TSG				   ");
                            sbWhere.Append(" 		ON R.PLT_CODE = TSG.PLT_CODE   	   ");
                            sbWhere.Append(" 		AND R.PART_CODE = TSG.PART_CODE	   ");
                        }
                        else
                        {
                            sbWhere.Append(" WHERE B.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                        }

                        sbWhere.Append("    AND B.BAL_STAT NOT IN ('14', '15')  ");
                        sbWhere.Append(UTIL.GetWhere(row, "@STK_GROUP", "TSG.STK_GROUP = @STK_GROUP"));
                        //sbWhere.Append(UTIL.GetWhere(row, "@S_DATE,@E_DATE", "CONVERT(varchar(10), L.EVENT_TIME, 120) BETWEEN @S_DATE AND @E_DATE "));

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

        public static DataTable TMAT_BALJU_QUERY18(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT");
                    sbQuery.Append(" B.PLT_CODE");
                    sbQuery.Append(" ,B.BALJU_NUM");
                    sbQuery.Append(" ,B.BALJU_SEQ");
                    sbQuery.Append(" ,BM.BAL_TYPE");
                    sbQuery.Append(" ,B.PART_CODE");
                    sbQuery.Append(" ,PT.PART_NAME");
                    sbQuery.Append(" ,PT.PART_PRODTYPE");
                    sbQuery.Append(" ,PT.MAT_LTYPE");
                    sbQuery.Append(" ,PT.MAT_MTYPE");
                    sbQuery.Append(" ,B.DUE_DATE");
                    sbQuery.Append(" ,B.UNIT_COST");
                    sbQuery.Append(" ,B.AMT");
                    sbQuery.Append(" ,B.QTY");
                    sbQuery.Append(" ,B.DETAIL_PART_NAME");
                    sbQuery.Append(" ,B.REAL_AMT");
                    sbQuery.Append(" ,B.BANK");
                    sbQuery.Append(" ,B.BANK_NO");
                    sbQuery.Append(" ,B.SCOMMENT");
                    sbQuery.Append(" ,ISNULL(YP.QTY,0) AS YPGO_QTY");
                    sbQuery.Append(" ,B.QTY - ISNULL(YP.QTY,0) AS REMAIN_QTY");
                    sbQuery.Append(" ,ISNULL(STK.PART_QTY, 0) AS PART_QTY");
                    sbQuery.Append(" FROM TMAT_BALJU B");
                    sbQuery.Append(" LEFT JOIN TMAT_BALJU_MASTER BM");
                    sbQuery.Append(" ON B.PLT_CODE = BM.PLT_CODE");
                    sbQuery.Append(" AND B.BALJU_NUM = BM.BALJU_NUM");

                    sbQuery.Append(" LEFT JOIN LSE_STD_PART PT");
                    sbQuery.Append(" ON B.PLT_CODE = PT.PLT_CODE");
                    sbQuery.Append(" AND B.PART_CODE = PT.PART_CODE");
                    sbQuery.Append(" LEFT JOIN (");
                    sbQuery.Append(" SELECT PLT_CODE, BALJU_NUM, BALJU_SEQ, SUM(QTY) AS QTY FROM TMAT_YPGO WHERE YPGO_STAT IN ('19','31','32') GROUP BY PLT_CODE, BALJU_NUM, BALJU_SEQ)");
                    sbQuery.Append(" YP");
                    sbQuery.Append(" ON B.PLT_CODE = YP.PLT_CODE");
                    sbQuery.Append(" AND B.BALJU_NUM = YP.BALJU_NUM");
                    sbQuery.Append(" AND B.BALJU_SEQ = YP.BALJU_SEQ");
                    sbQuery.Append(" LEFT JOIN (");
                    sbQuery.Append(" SELECT PLT_CODE, PART_CODE, SUM(PART_QTY) AS PART_QTY FROM TMAT_STOCK GROUP BY PLT_CODE, PART_CODE");
                    sbQuery.Append(" ) STK");
                    sbQuery.Append(" ON B.PLT_CODE = STK.PLT_CODE");
                    sbQuery.Append(" AND B.PART_CODE = STK.PART_CODE");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE B.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                        sbWhere.Append(UTIL.GetWhere(row, "@BAL_STAT", "B.BAL_STAT = @BAL_STAT"));
                        sbWhere.Append(UTIL.GetWhere(row, "@BAL_TYPE", "BM.BAL_TYPE = @BAL_TYPE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@NOT_BAL_STAT", "B.BAL_STAT <> @NOT_BAL_STAT"));
                        sbWhere.Append(UTIL.GetWhere(row, "@NOT_BALJU_NUM", "B.BALJU_NUM <> @NOT_BALJU_NUM"));
                        sbWhere.Append(UTIL.GetWhere(row, "@BALJU_NUM", "B.BALJU_NUM = @BALJU_NUM"));
                        sbWhere.Append(UTIL.GetWhere(row, "@BALJU_SEQ", "B.BALJU_SEQ = @BALJU_SEQ"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_CODE", "B.PART_CODE = @PART_CODE"));

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
