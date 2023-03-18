using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace DOUT
{
    public class TOUT_PROCBALJU
    {
        public static DataTable TOUT_PROCBALJU_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
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
                    sbQuery.Append(" ,WO_NO ");
                    sbQuery.Append(" ,DUE_DATE ");
                    sbQuery.Append(" ,QTY ");
                    sbQuery.Append(" ,OK_QTY ");
                    sbQuery.Append(" ,UNIT_COST ");
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
                    sbQuery.Append("  FROM TOUT_PROCBALJU  ");
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
        public static DataTable TOUT_PROCBALJU_SER2(DataTable dtParam, BizExecute.BizExecute bizExecute)
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
                    sbQuery.Append(" FROM TOUT_PROCBALJU B ");
                    sbQuery.Append(" JOIN TOUT_PROCBALJU_MASTER BM ");
                    sbQuery.Append(" ON B.PLT_CODE = BM.PLT_CODE ");
                    sbQuery.Append(" AND B.BALJU_NUM = BM.BALJU_NUM ");
                    sbQuery.Append(" LEFT JOIN  ");
                    sbQuery.Append(" ( ");
                    sbQuery.Append(" SELECT PLT_CODE , BALJU_NUM , BALJU_SEQ , ISNULL(SUM(QTY),0) AS QTY FROM TOUT_PROCYPGO  ");
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

        public static DataTable TOUT_PROCBALJU_SER3(DataTable dtParam, BizExecute.BizExecute bizExecute)
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
                    sbQuery.Append(" ,TYPGO.TYP_QTY AS TYPGO_QTY ");
                    //sbQuery.Append(" ,ISNULL(Y.QTY,0) AS YPGO_QTY ");
                    sbQuery.Append(" FROM TOUT_PROCBALJU B ");
                    sbQuery.Append(" JOIN TOUT_PROCBALJU_MASTER BM ");
                    sbQuery.Append(" ON B.PLT_CODE = BM.PLT_CODE ");
                    sbQuery.Append(" AND B.BALJU_NUM = BM.BALJU_NUM ");
                    sbQuery.Append(" LEFT JOIN TOUT_PROCYPGO YPGO ");
                    sbQuery.Append(" ON B.PLT_CODE = YPGO.PLT_CODE ");
                    sbQuery.Append(" AND B.BALJU_NUM = YPGO.BALJU_NUM ");
                    sbQuery.Append(" AND B.BALJU_SEQ = YPGO.BALJU_SEQ ");
                    sbQuery.Append(" LEFT JOIN TOUT_TEMP_YPGO TYPGO ");
                    sbQuery.Append(" ON YPGO.PLT_CODE = TYPGO.PLT_CODE ");
                    sbQuery.Append(" AND YPGO.TYP_ID = TYPGO.TYP_ID ");
                    sbQuery.Append(" WHERE B.PLT_CODE = @PLT_CODE ");
                    sbQuery.Append(" AND B.BALJU_NUM = @BALJU_NUM ");
                    sbQuery.Append(" AND B.BALJU_SEQ = @BALJU_SEQ ");
                    sbQuery.Append(" AND TYPGO.TYP_ID = @TYP_ID ");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "BALJU_NUM")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "BALJU_SEQ")) isHasColumn = false;
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


        public static void TOUT_PROCBALJU_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" INSERT INTO TOUT_PROCBALJU ");
                    sbQuery.Append(" ( ");
                    sbQuery.Append("        PLT_CODE ");
                    sbQuery.Append("      , BALJU_NUM ");
                    sbQuery.Append("      , BALJU_SEQ ");
                    sbQuery.Append("      , REQUEST_NO ");
                    sbQuery.Append("      , REQUEST_SEQ ");
                    sbQuery.Append("      , WO_NO ");
                    sbQuery.Append("      , DUE_DATE ");
                    sbQuery.Append("      , QTY ");
                    sbQuery.Append("      , UNIT_COST ");
                    sbQuery.Append("      , AMT ");
                    sbQuery.Append("      , MAT_SPEC ");
                    sbQuery.Append("      , MAT_WEIGHT ");
                    sbQuery.Append("      , BAL_STAT ");
                    sbQuery.Append("      , INS_FLAG ");
                    sbQuery.Append("      , BAL_UNIT ");
                    sbQuery.Append("      , REAL_AMT ");
                    sbQuery.Append("      , BANK ");
                    sbQuery.Append("      , BANK_NO ");
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
                    sbQuery.Append("      , @WO_NO ");
                    sbQuery.Append("      , @DUE_DATE ");
                    sbQuery.Append("      , @QTY ");
                    sbQuery.Append("      , @UNIT_COST ");
                    sbQuery.Append("      , @AMT ");
                    sbQuery.Append("      , @MAT_SPEC ");
                    sbQuery.Append("      , @MAT_WEIGHT ");
                    sbQuery.Append("      , @BAL_STAT ");
                    sbQuery.Append("      , @INS_FLAG ");
                    sbQuery.Append("      , @BAL_UNIT ");
                    sbQuery.Append("      , @REAL_AMT ");
                    sbQuery.Append("      , @BANK ");
                    sbQuery.Append("      , @BANK_NO ");
                    sbQuery.Append("      , @SCOMMENT ");
                    sbQuery.Append(" , GETDATE()					");
                    sbQuery.Append(" ," + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" )								");

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

        public static void TOUT_PROCBALJU_UPD(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" UPDATE TOUT_PROCBALJU ");
                    sbQuery.Append("    SET   UNIT_COST = @UNIT_COST ");
                    sbQuery.Append("        , QTY = @QTY ");
                    sbQuery.Append("        , AMT = @AMT ");
                    sbQuery.Append("        , DUE_DATE = @DUE_DATE ");
                    sbQuery.Append("        , SCOMMENT = @BALJU_SCOMMENT ");
                    sbQuery.Append("        , INS_FLAG = @INS_FLAG ");
                    sbQuery.Append("        , BAL_STAT = @BAL_STAT ");
                    sbQuery.Append("        , REAL_AMT = @REAL_AMT ");
                    sbQuery.Append("        , BANK = @BANK ");
                    sbQuery.Append("        , BANK_NO = @BANK_NO ");
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

        //공정외주 상태변경
        public static void TOUT_PROCBALJU_UPD2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TOUT_PROCBALJU ");
                    sbQuery.Append("    SET   BAL_STAT = @BAL_STAT ");
                    sbQuery.Append(" , MDFY_DATE = GETDATE()      ");
                    sbQuery.Append(" , MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
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


        //공정외주 발주 취소/반려 상태변경
        public static void TOUT_PROCBALJU_UPD3(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TOUT_PROCBALJU ");
                    sbQuery.Append("    SET   BAL_STAT = @BAL_STAT ");
                    sbQuery.Append("        , C_REASON = @C_REASON ");
                    sbQuery.Append(" , MDFY_DATE = GETDATE()      ");
                    sbQuery.Append(" , MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
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

        //공정외주 입고예정일 변경
        public static void TOUT_PROCBALJU_UPD4(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TOUT_PROCBALJU ");
                    sbQuery.Append("    SET   DUE_DATE = @DUE_DATE ");
                    sbQuery.Append(" , MDFY_DATE = GETDATE()      ");
                    sbQuery.Append(" , MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
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

        //공정외주 상태 변경
        public static void TOUT_PROCBALJU_UPD5(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TOUT_PROCBALJU ");
                    sbQuery.Append("    SET   CHG_UNIT_COST = @UNIT_COST ");
                    sbQuery.Append("    , AMT = QTY * @UNIT_COST      ");
                    sbQuery.Append("    , MDFY_DATE = GETDATE()      ");
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

        //수입검사 정보 변경
        public static void TOUT_PROCBALJU_UPD6(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TOUT_PROCBALJU ");
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

    public class TOUT_PROCBALJU_QUERY
    {
        //발주시 같은 작업지시 공정외주 발주,발주승인 상태를 확인한다.
        public static DataTable TOUT_PROCBALJU_QUERY2(DataTable dtParam, BizExecute.BizExecute bizExecute)
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
                    sbQuery.Append("       ,B.QTY ");
                    sbQuery.Append("       ,B.UNIT_COST ");
                    sbQuery.Append("       ,B.AMT ");
                    sbQuery.Append("       ,B.BAL_STAT ");
                    sbQuery.Append("       ,B.REG_DATE ");
                    sbQuery.Append("       ,B.REG_EMP ");
                    sbQuery.Append("       ,B.MDFY_DATE ");
                    sbQuery.Append("       ,B.MDFY_EMP ");
                    sbQuery.Append("       ,R.REG_EMP AS REQ_REG_EMP ");
                    sbQuery.Append("       ,R.WO_NO ");
                    sbQuery.Append("   FROM TOUT_PROCBALJU B ");
                    sbQuery.Append(" LEFT JOIN TOUT_REQUEST R ");
                    sbQuery.Append(" ON B.PLT_CODE = R.PLT_CODE ");
                    sbQuery.Append(" AND B.REQUEST_NO = R.REQUEST_NO ");
                    sbQuery.Append(" AND B.REQUEST_SEQ = R.REQUEST_SEQ ");



                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE B.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                        sbWhere.Append(UTIL.GetWhere(row, "@BALJU_NUM", " B.BALJU_NUM = @BALJU_NUM "));
                        sbWhere.Append(UTIL.GetWhere(row, "@BALJU_SEQ", " B.BALJU_SEQ = @BALJU_SEQ "));
                        sbWhere.Append(UTIL.GetWhere(row, "@BAL_STAT", " B.BAL_STAT = @BAL_STAT "));

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

        //공정외주 발주된건을 조회한다.
        /// <summary>
        /// 공정외주 발주 내역 조회
        /// </summary>
        /// <param name="dtParam"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataTable TOUT_PROCBALJU_QUERY3(DataTable dtParam, BizExecute.BizExecute bizExecute)
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
                    sbQuery.Append(" ,B.WO_NO ");
                    sbQuery.Append(" ,B.BAL_STAT ");
                    sbQuery.Append(" ,BM.BALJU_DATE ");
                    sbQuery.Append(" ,B.DUE_DATE ");
                    sbQuery.Append(" ,BM.OVND_CODE AS VND_CODE");

                    sbQuery.Append(" ,BM.OVND_CODE");
                    //sbQuery.Append(" ,V.VEN_NAME ");
                    sbQuery.Append(" ,B.REG_EMP ");

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
                    sbQuery.Append("       ,BM.CHK_RD ");

                    sbQuery.Append(" ,P.PROD_CODE ");
                    sbQuery.Append(" ,P.PROD_NAME ");

                    sbQuery.Append(" ,P.ORD_DATE ");
                    sbQuery.Append(" ,P.DUE_DATE AS ORD_DUE_DATE");
                    sbQuery.Append(" ,P.CHG_DUE_DATE ");

                    sbQuery.Append(" ,TW.PART_CODE ");
                    sbQuery.Append(" ,SP.PART_NAME ");
                    sbQuery.Append(" ,SP.MAT_SPEC ");
                    sbQuery.Append(" ,SP.PART_CAT ");
                    sbQuery.Append(" ,SP.MAT_TYPE ");
                    sbQuery.Append(" ,SP.MAT_LTYPE ");
                    sbQuery.Append(" ,SP.MAT_MTYPE ");
                    sbQuery.Append(" ,SP.MAT_STYPE ");
                    sbQuery.Append(" ,SP.PART_PRODTYPE ");
                    sbQuery.Append(" ,SP.MAT_UNIT ");
                    sbQuery.Append(" ,B.INS_FLAG ");
                    sbQuery.Append(" ,SP.STK_LOCATION   ");
                    sbQuery.Append(" ,B.UNIT_COST ");
                    //sbQuery.Append(" ,B.QTY ");
                    sbQuery.Append(" ,B.QTY AS BAL_QTY ");
                    sbQuery.Append(" ,B.QTY AS INS_QTY ");
                    sbQuery.Append(" ,ISNULL(YPGO.QTY, 0) AS YPGO_QTY ");
                    sbQuery.Append(" ,(ISNULL(B.QTY,0) - ISNULL(YPGO.QTY,0) - ISNULL(Q.NG_QTY, 0)) AS QTY");
                    sbQuery.Append(" ,B.UNIT_COST AS YPGO_COST");
                    sbQuery.Append(" ,(ISNULL(B.QTY,0) - ISNULL(YPGO.QTY,0) - ISNULL(Q.NG_QTY, 0)) * B.UNIT_COST AS YPGO_AMT");

                    sbQuery.Append(" ,B.OK_QTY ");
                    sbQuery.Append(" ,Q.NG_QTY ");
                    sbQuery.Append(" ,B.AMT ");
                    sbQuery.Append(" ,B.SCOMMENT AS BALJU_SCOMMENT  ");
                    sbQuery.Append(" ,B.INS_DATE ");
                    sbQuery.Append(" ,B.INS_EMP ");
                    sbQuery.Append(" ,B.BAL_UNIT ");
                    sbQuery.Append(" , B.REAL_AMT");
                    sbQuery.Append(" , B.BANK");
                    sbQuery.Append(" , B.BANK_NO");
                    sbQuery.Append(" ,TW.WO_NO ");
                    sbQuery.Append(" ,TW.PROC_CODE ");
                    sbQuery.Append(" ,LSP.PROC_NAME ");

                    sbQuery.Append(" ,ISNULL(BM.APP_STATUS, '0') AS APP_STATUS");
                    sbQuery.Append(" ,BM.APP_ORG");
                    sbQuery.Append(" ,ISNULL(BM.APP_EMP1,APP.APP_EMP1) AS APP_EMP1 ");
                    sbQuery.Append(" ,ISNULL(BM.APP_EMP_FLAG1,'0') AS APP_EMP_FLAG1 ");
                    sbQuery.Append(" ,ISNULL(BM.APP_EMP2,APP.APP_EMP2) AS APP_EMP2 ");
                    sbQuery.Append(" ,ISNULL(BM.APP_EMP_FLAG2,'0') AS APP_EMP_FLAG2 ");
                    sbQuery.Append(" ,ISNULL(BM.APP_EMP3,APP.APP_EMP3) AS APP_EMP3 ");
                    sbQuery.Append(" ,ISNULL(BM.APP_EMP_FLAG3,'0') AS APP_EMP_FLAG3 ");
                    sbQuery.Append(" ,ISNULL(BM.APP_EMP4,APP.APP_EMP4) AS APP_EMP4 ");
                    sbQuery.Append(" ,ISNULL(BM.APP_EMP_FLAG4,'0') AS APP_EMP_FLAG4 ");

                    sbQuery.Append(" FROM TOUT_PROCBALJU B ");
                    sbQuery.Append(" JOIN TOUT_PROCBALJU_MASTER BM ");
                    sbQuery.Append(" ON B.PLT_CODE = BM.PLT_CODE ");
                    sbQuery.Append(" AND B.BALJU_NUM = BM.BALJU_NUM ");

                    sbQuery.Append(" LEFT JOIN");
                    sbQuery.Append(" (");
                    sbQuery.Append(" SELECT PLT_CODE , BALJU_NUM , BALJU_SEQ , ISNULL(SUM(QTY),0) AS QTY FROM TOUT_PROCYPGO ");
                    sbQuery.Append(" WHERE YPGO_STAT IN ('19','31','32')");
                    sbQuery.Append(" GROUP BY PLT_CODE , BALJU_NUM ,BALJU_SEQ");
                    sbQuery.Append(" ) YPGO");
                    sbQuery.Append(" ON B.PLT_CODE = YPGO.PLT_CODE");
                    sbQuery.Append(" AND B.BALJU_NUM = YPGO.BALJU_NUM");
                    sbQuery.Append(" AND B.BALJU_SEQ = YPGO.BALJU_SEQ");

                    sbQuery.Append(" LEFT JOIN TSHP_WORKORDER TW  ");
                    sbQuery.Append(" ON TW.PLT_CODE = B.PLT_CODE ");
                    sbQuery.Append(" AND TW.WO_NO = B.WO_NO ");

                    sbQuery.Append(" LEFT JOIN TORD_PRODUCT P ");
                    sbQuery.Append(" ON TW.PLT_CODE = P.PLT_CODE ");
                    sbQuery.Append(" AND TW.PROD_CODE = P.PROD_CODE ");

                    sbQuery.Append(" LEFT JOIN TQCT_PURCHASE_NG Q ");
                    sbQuery.Append(" ON B.PLT_CODE = Q.PLT_CODE ");
                    sbQuery.Append(" AND B.BALJU_NUM = Q.BALJU_NUM ");
                    sbQuery.Append(" AND B.BALJU_SEQ = Q.BALJU_SEQ ");
                    sbQuery.Append(" AND Q.DATA_FLAG = 0 ");

                    sbQuery.Append(" LEFT JOIN LSE_STD_PART SP ");
                    sbQuery.Append(" ON TW.PLT_CODE = SP.PLT_CODE ");
                    sbQuery.Append(" AND TW.PART_CODE = SP.PART_CODE ");

                    sbQuery.Append(" LEFT JOIN LSE_STD_PROC LSP ");
                    sbQuery.Append(" ON TW.PLT_CODE = LSP.PLT_CODE ");
                    sbQuery.Append(" AND TW.PROC_CODE = LSP.PROC_CODE");

                    sbQuery.Append(" LEFT JOIN TSTD_APP_EMP APP ");
                    sbQuery.Append(" ON BM.PLT_CODE = APP.PLT_CODE");
                    sbQuery.Append(" AND APP.APP_TYPE = 'PUR' ");
                    sbQuery.Append(" AND BM.APP_ORG = APP.ORG_CODE ");


                    sbQuery.Append(" LEFT JOIN TSTD_VENDOR V ");
                    sbQuery.Append(" ON BM.PLT_CODE = V.PLT_CODE");
                    sbQuery.Append(" AND BM.OVND_CODE = V.VEN_CODE");

                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE E ");
                    sbQuery.Append(" ON BM.PLT_CODE = E.PLT_CODE");
                    sbQuery.Append(" AND B.REG_EMP = E.EMP_CODE");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE B.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                        sbWhere.Append(UTIL.GetWhere(row, "@BALJU_NUM", " B.BALJU_NUM = @BALJU_NUM "));
                        sbWhere.Append(UTIL.GetWhere(row, "@BALJU_NUM_LIKE", "(B.BALJU_NUM LIKE '%' + @BALJU_NUM_LIKE + '%') "));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_BALJU_DATE, @E_BALJU_DATE", " (BM.BALJU_DATE BETWEEN @S_BALJU_DATE AND @E_BALJU_DATE) "));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_DUE_DATE, @E_DUE_DATE", " (B.DUE_DATE BETWEEN @S_DUE_DATE AND @E_DUE_DATE) "));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_MDFY_DATE,@E_MDFY_DATE", " CONVERT(CHAR(19), B.MDFY_DATE, 120) BETWEEN @S_MDFY_DATE AND @E_MDFY_DATE "));
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_CODE", " TW.PART_CODE = @PART_CODE "));
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_LIKE", " TW.PART_CODE = @PART_LIKE "));
                        sbWhere.Append(UTIL.GetWhere(row, "@VEN_CODE", " BM.OVND_CODE = @VEN_CODE "));
                        sbWhere.Append(UTIL.GetWhere(row, "@OVND_CODE", " BM.OVND_CODE = @OVND_CODE "));
                        sbWhere.Append(UTIL.GetWhere(row, "@BAL_STAT", " B.BAL_STAT = @BAL_STAT "));
                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_LIKE", "(P.PROD_CODE LIKE '%' + @PROD_LIKE + '%' OR P.PROD_NAME LIKE '%' + @PROD_LIKE + '%' )"));

                        sbWhere.Append(UTIL.GetWhere(row, "@VND_LIKE", "(BM.OVND_CODE LIKE '%' + @VND_LIKE + '%' OR V.VEN_NAME LIKE '%' + @VND_LIKE + '%' )"));
                        sbWhere.Append(UTIL.GetWhere(row, "@REG_LIKE", "(B.REG_EMP LIKE '%' + @REG_LIKE + '%' OR E.EMP_NAME LIKE '%' + @REG_LIKE + '%' )"));

                        //입고 화면(입고 대상)
                        sbWhere.Append(UTIL.GetWhere(row, "@PUR05A", " B.BAL_STAT IN ('11', '43', '21') "));
                        sbWhere.Append(UTIL.GetWhere(row, "@PUR01", " B.BAL_STAT IN ('11', '13', '19', '20', '21', '22', '43') "));
                        
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

        
        public static DataTable TOUT_PROCBALJU_QUERY4(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable dtResult = new DataTable("RSLTDT");

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT  ");
                    sbQuery.Append("  ISNULL(MAX(BALJU_SEQ), 0) + 1 AS SEQ");
                    sbQuery.Append(" FROM TOUT_PROCBALJU   ");
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

        //[입고처리] 공정외주 발주데이터를 조회
        public static DataTable TOUT_PROCBALJU_QUERY5(DataTable dtParam, BizExecute.BizExecute bizExecute)
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
                    sbQuery.Append(" ,RM.REQ_DATE ");
                    sbQuery.Append(" ,RM.DUE_DATE AS REQ_DUE_DATE ");
                    sbQuery.Append(" ,R.WO_NO ");
                    sbQuery.Append(" ,W.WO_FLAG ");
                    sbQuery.Append(" ,B.BALJU_NUM ");
                    sbQuery.Append(" ,B.BALJU_SEQ ");
                    sbQuery.Append(" ,B.BAL_STAT ");
                    sbQuery.Append(" ,BM.BALJU_DATE ");
                    sbQuery.Append(" ,B.DUE_DATE ");
                    sbQuery.Append(" ,BM.OVND_CODE AS VEN_CODE ");
                    sbQuery.Append(" ,V.VEN_NAME ");
                    sbQuery.Append(" ,I.ITEM_CODE ");
                    sbQuery.Append(" ,I.ITEM_NAME ");
                    sbQuery.Append(" ,I.CVND_CODE ");
                    sbQuery.Append(" ,CV.VEN_NAME AS CVND_NAME");
                    sbQuery.Append(" ,P.PROD_CODE ");
                    sbQuery.Append(" ,P.PROD_NAME ");
                    sbQuery.Append(" ,SP.PART_CODE ");
                    sbQuery.Append(" ,SP.PART_NAME ");
                    sbQuery.Append(" ,SP.MAT_LTYPE ");
                    sbQuery.Append(" ,SP.MAT_MTYPE ");
                    sbQuery.Append(" ,SP.MAT_STYPE ");
                    sbQuery.Append(" ,SP.MAT_UNIT ");
                    sbQuery.Append(" ,SP.PART_PRODTYPE ");
                    sbQuery.Append(" ,SP.MAT_QLTY AS PART_QLTY ");
                    sbQuery.Append(" ,Q.MQLTY_NAME AS PART_QLTY_NAME ");
                    sbQuery.Append(" ,SP.MAT_SPEC AS PART_SPEC ");
                    sbQuery.Append(" ,SP.MAT_SPEC1 AS PART_SPEC1 ");
                    sbQuery.Append(" ,R.PROC_CODE ");
                    sbQuery.Append(" ,PRC.PROC_NAME ");
                    sbQuery.Append(" ,B.QTY AS BAL_QTY ");
                    sbQuery.Append(" ,B.UNIT_COST ");
                    sbQuery.Append(" ,B.AMT ");
                    sbQuery.Append(" ,ISNULL(YPGO.QTY,0) AS YPGO_QTY ");
                    sbQuery.Append(" ,ISNULL(CHK_YPGO.QTY,0) AS CHK_YPGO_QTY ");
                    sbQuery.Append(" ,ISNULL(NG_YPGO.QTY,0) AS NG_YPGO_QTY ");
                    sbQuery.Append(" ,ISNULL(TMP_YPGO.QTY,0) AS TMP_YPGO_QTY ");
                    sbQuery.Append(" ,(ISNULL(YPGO.QTY,0) + ISNULL(NG_YPGO.QTY,0)) AS TOT_YPGO_QTY ");
                    sbQuery.Append(" ,(ISNULL(B.QTY,0) - (ISNULL(YPGO.QTY,0) + ISNULL(CHK_YPGO.QTY,0) + ISNULL(NG_YPGO.QTY,0) + ISNULL(TMP_YPGO.QTY,0))) AS QTY ");
                    sbQuery.Append(" ,(ISNULL(B.QTY,0) - (ISNULL(YPGO.QTY,0) + ISNULL(CHK_YPGO.QTY,0) + ISNULL(NG_YPGO.QTY,0) + ISNULL(TMP_YPGO.QTY,0))) AS REMAIN_QTY ");
                    sbQuery.Append(" ,BM.SCOMMENT ");
                    sbQuery.Append(" ,ISNULL(W.INS_FLAG,0) AS INS_FLAG ");
                    sbQuery.Append(" ,SP.STK_LOCATION ");
                    sbQuery.Append(" ,SP.STK_LOCATION_DETAIL ");
                    sbQuery.Append(" ,B.REG_EMP AS BALJU_REG_EMP ");
                    sbQuery.Append(" ,REG_EMP.EMP_NAME AS BALJU_REG_EMP_NAME ");
                    sbQuery.Append(" ,B.REG_DATE AS BALJU_REG_DATE ");
                    sbQuery.Append(" ,R.REG_EMP AS REQ_REG_EMP ");
                    sbQuery.Append(" ,CASE ISNULL(FM.LINK_KEY, '') WHEN '' THEN 'X' ELSE 'O' END colATTACH   ");
                    sbQuery.Append(" ,FM.LINK_KEY ");
                    sbQuery.Append(" , ISNULL(NULL,GETDATE()) AS INS_DATE ");
                    sbQuery.Append(" FROM TOUT_PROCBALJU B ");
                    sbQuery.Append(" JOIN TOUT_PROCBALJU_MASTER BM ");
                    sbQuery.Append(" ON B.PLT_CODE = BM.PLT_CODE ");
                    sbQuery.Append(" AND B.BALJU_NUM = BM.BALJU_NUM ");
                    sbQuery.Append(" LEFT JOIN TOUT_REQUEST R  ");
                    sbQuery.Append(" ON B.PLT_CODE = R.PLT_CODE ");
                    sbQuery.Append(" AND B.REQUEST_NO = R.REQUEST_NO ");
                    sbQuery.Append(" AND B.REQUEST_SEQ = R.REQUEST_SEQ ");
                    sbQuery.Append(" LEFT JOIN TOUT_REQUEST_MASTER RM ");
                    sbQuery.Append(" ON R.PLT_CODE = RM.PLT_CODE ");
                    sbQuery.Append(" AND R.REQUEST_NO = RM.REQUEST_NO ");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE REG_EMP ");
                    sbQuery.Append(" ON B.PLT_CODE = REG_EMP.PLT_CODE ");
                    sbQuery.Append(" AND B.REG_EMP = REG_EMP.EMP_CODE ");
                    sbQuery.Append(" LEFT JOIN TSHP_WORKORDER W ");
                    sbQuery.Append(" ON R.PLT_CODE = W.PLT_CODE ");
                    sbQuery.Append(" AND R.WO_NO = W.WO_NO ");
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
                    sbQuery.Append(" LEFT JOIN  ");
                    sbQuery.Append(" ( ");
                    sbQuery.Append(" SELECT PLT_CODE , BALJU_NUM , BALJU_SEQ , ISNULL(SUM(QTY),0) AS QTY FROM TOUT_PROCYPGO   ");
                    sbQuery.Append(" WHERE YPGO_STAT IN ('19','31','32') ");
                    sbQuery.Append(" GROUP BY PLT_CODE , BALJU_NUM ,BALJU_SEQ ");
                    sbQuery.Append(" ) YPGO ");
                    sbQuery.Append(" ON B.PLT_CODE = YPGO.PLT_CODE ");
                    sbQuery.Append(" AND B.BALJU_NUM = YPGO.BALJU_NUM ");
                    sbQuery.Append(" AND B.BALJU_SEQ = YPGO.BALJU_SEQ ");
                    sbQuery.Append(" LEFT JOIN  ");
                    sbQuery.Append(" ( ");
                    sbQuery.Append(" SELECT PLT_CODE , BALJU_NUM , BALJU_SEQ , ISNULL(SUM(TYP_QTY),0) AS QTY FROM TOUT_TEMP_YPGO   ");
                    sbQuery.Append(" WHERE TYP_STAT IN ('20','42') ");
                    sbQuery.Append(" GROUP BY PLT_CODE , BALJU_NUM ,BALJU_SEQ ");
                    sbQuery.Append(" ) CHK_YPGO ");
                    sbQuery.Append(" ON B.PLT_CODE = CHK_YPGO.PLT_CODE ");
                    sbQuery.Append(" AND B.BALJU_NUM = CHK_YPGO.BALJU_NUM ");
                    sbQuery.Append(" AND B.BALJU_SEQ = CHK_YPGO.BALJU_SEQ ");
                    sbQuery.Append(" LEFT JOIN  ");
                    sbQuery.Append(" ( ");
                    sbQuery.Append(" SELECT PLT_CODE , BALJU_NUM , BALJU_SEQ , ISNULL(SUM(QTY),0) AS QTY FROM TOUT_PROCYPGO   ");
                    sbQuery.Append(" WHERE YPGO_STAT IN ('24','25') ");
                    sbQuery.Append(" GROUP BY PLT_CODE , BALJU_NUM ,BALJU_SEQ ");
                    sbQuery.Append(" ) NG_YPGO ");
                    sbQuery.Append(" ON B.PLT_CODE = NG_YPGO.PLT_CODE ");
                    sbQuery.Append(" AND B.BALJU_NUM = NG_YPGO.BALJU_NUM ");
                    sbQuery.Append(" AND B.BALJU_SEQ = NG_YPGO.BALJU_SEQ ");
                    sbQuery.Append(" LEFT JOIN  ");
                    sbQuery.Append(" ( ");//발주내용은 발주수량만큼 입고처리하면 표시할 필요가 없으므로 전체 검사대기(20), 전체 정입고(41)은 제외
                    sbQuery.Append(" SELECT PLT_CODE , BALJU_NUM , BALJU_SEQ , ISNULL(SUM(TYP_QTY),0) AS QTY FROM TOUT_TEMP_YPGO   ");
                    sbQuery.Append(" WHERE TYP_STAT IN ('40','41') ");
                    sbQuery.Append(" GROUP BY PLT_CODE , BALJU_NUM ,BALJU_SEQ ");
                    sbQuery.Append(" ) TMP_YPGO ");
                    sbQuery.Append(" ON B.PLT_CODE = TMP_YPGO.PLT_CODE ");
                    sbQuery.Append(" AND B.BALJU_NUM = TMP_YPGO.BALJU_NUM ");
                    sbQuery.Append(" AND B.BALJU_SEQ = TMP_YPGO.BALJU_SEQ ");

                    sbQuery.Append(" LEFT OUTER JOIN (SELECT PLT_CODE, LINK_KEY FROM TSYS_FILELIST_MASTER WHERE IS_UPLOAD = 1 AND UPLOAD_MENU = 'PLN01A' AND DATA_FLAG = 0 GROUP BY PLT_CODE, LINK_KEY) FM ");
                    sbQuery.Append(" ON P.PLT_CODE = FM.PLT_CODE AND P.PART_CODE = FM.LINK_KEY ");

                    sbQuery.Append("  LEFT JOIN TSTD_CODES CD ");
                    sbQuery.Append("  ON SP.PLT_CODE = CD.PLT_CODE ");
                    sbQuery.Append("  AND SP.PART_PRODTYPE = CD.CD_CODE ");
                    sbQuery.Append("  AND CD.CAT_CODE = 'M007' ");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE B.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                        sbWhere.Append(UTIL.GetWhere(row, "@BALJU_NUM", " B.BALJU_NUM = @BALJU_NUM "));
                        sbWhere.Append(UTIL.GetWhere(row, "@BALJU_NUM_LIKE", " (B.BALJU_NUM LIKE '%' + @BALJU_NUM_LIKE + '%') "));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_BALJU_DATE, @E_BALJU_DATE", " (BM.BALJU_DATE BETWEEN @S_BALJU_DATE AND @E_BALJU_DATE) "));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_DUE_DATE, @E_DUE_DATE", " (B.DUE_DATE BETWEEN @S_DUE_DATE AND @E_DUE_DATE) "));
                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_CODE", " W.PROD_CODE = @PROD_CODE "));
                        sbWhere.Append(UTIL.GetWhere(row, "@ITEM_CODE", " I.ITEM_CODE = @ITEM_CODE "));
                        sbWhere.Append(UTIL.GetWhere(row, "@OVND_CODE", " BM.OVND_CODE = @OVND_CODE "));
                        sbWhere.Append(UTIL.GetWhere(row, "@BALJU_SEQ", " B.BALJU_SEQ = @BALJU_SEQ "));
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_CODE", " W.PART_CODE = @PART_CODE "));
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_NUM_LIKE", " (PT.PART_NUM LIKE '%' + @PART_NUM_LIKE + '%') "));


                        //search_con : 검색 통합 거래처,발주번호,공정명,수주코드,수주처명,품목코드,도면번호,품목명,제품규격,형식,재질,제품규격,소재규격,발주규격
                        //V.VEN_NAME, BALJU_NUM, PROC_NAME, ITEM_CODE, CV.VEN_NAME, PART_CODE, DRAW_NO, PART_NAME, MAT_SPEC1, PART_PRODTYPE, MAT_QLTY, MAT_SPEC, BAL_SPEC
                        string cond = "(V.VEN_NAME LIKE '%' + @SEARCH_CON + '%' OR B.BALJU_NUM LIKE '%' + @SEARCH_CON + '%' OR ";
                        cond += " I.ITEM_CODE LIKE '%' + @SEARCH_CON + '%' OR CV.VEN_NAME LIKE '%' + @SEARCH_CON + '%' OR ";
                        cond += " W.PART_CODE LIKE '%' + @SEARCH_CON + '%' OR SP.PART_NAME LIKE '%' + @SEARCH_CON + '%' OR PRC.PROC_NAME LIKE '%' + @SEARCH_CON + '%' ";
                        cond += " OR SP.MAT_SPEC1 LIKE '%' + @SEARCH_CON + '%' OR SP.MAT_SPEC LIKE '%' + @SEARCH_CON + '%' OR SP.BAL_SPEC LIKE '%' + @SEARCH_CON + '%'";

                        cond += " OR CD.CD_NAME LIKE '%' + @SEARCH_CON + '%' ";
                        //cond += " OR SP.PART_PRODTYPE LIKE '%' + @SEARCH_CON + '%' ";
                        cond += " OR Q.MQLTY_NAME LIKE '%' + @SEARCH_CON + '%' ) ";
                        sbWhere.Append(UTIL.GetWhere(row, "@SEARCH_CON", cond));

                        sbWhere.Append(" AND B.BAL_STAT IN ('13','21','42','40') ");
                        sbWhere.Append(" AND (ISNULL(B.QTY,0) - (ISNULL(YPGO.QTY,0) + ISNULL(CHK_YPGO.QTY,0) + ISNULL(NG_YPGO.QTY,0) + ISNULL(TMP_YPGO.QTY,0))) > 0 ");

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

        public static DataTable TOUT_PROCBALJU_QUERY17(DataTable dtParam, BizExecute.BizExecute bizExecute)
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
                    sbQuery.Append(" ,RM.REQ_DATE ");
                    sbQuery.Append(" ,RM.DUE_DATE AS REQ_DUE_DATE ");
                    sbQuery.Append(" ,R.WO_NO ");
                    sbQuery.Append(" ,B.BALJU_NUM ");
                    sbQuery.Append(" ,B.BALJU_SEQ ");
                    sbQuery.Append(" ,TY.TYP_STAT AS BAL_STAT ");
                    sbQuery.Append(" ,BM.BALJU_DATE ");
                    sbQuery.Append(" ,B.DUE_DATE ");
                    sbQuery.Append(" ,BM.OVND_CODE AS VEN_CODE ");
                    sbQuery.Append(" ,V.VEN_NAME ");
                    sbQuery.Append(" ,I.ITEM_CODE ");
                    sbQuery.Append(" ,I.ITEM_NAME ");
                    sbQuery.Append(" ,I.CVND_CODE ");
                    sbQuery.Append(" , CASE WHEN PNG.NG_PROD_CODE IS NOT NULL THEN '재작업' ELSE '금액 차감' END AS NG_STATE	");
                    sbQuery.Append(" ,CV.VEN_NAME AS CVND_NAME");
                    sbQuery.Append(" ,P.PROD_CODE ");
                    sbQuery.Append(" ,P.PROD_NAME ");
                    sbQuery.Append(" ,SP.PART_CODE ");
                    sbQuery.Append(" ,SP.PART_NAME ");
                    sbQuery.Append(" ,SP.MAT_LTYPE ");
                    sbQuery.Append(" ,SP.MAT_MTYPE ");
                    sbQuery.Append(" ,SP.MAT_STYPE ");
                    sbQuery.Append(" ,SP.MAT_UNIT ");
                    sbQuery.Append(" ,SP.PART_PRODTYPE ");
                    sbQuery.Append(" ,SP.MAT_QLTY AS PART_QLTY ");
                    sbQuery.Append(" ,Q.MQLTY_NAME AS PART_QLTY_NAME ");
                    sbQuery.Append(" ,SP.MAT_SPEC AS PART_SPEC ");
                    sbQuery.Append(" ,SP.MAT_SPEC1 AS PART_SPEC1 ");
                    sbQuery.Append(" ,R.PROC_CODE ");
                    sbQuery.Append(" ,PRC.PROC_NAME ");
                    sbQuery.Append(" ,B.QTY AS BAL_QTY ");
                    sbQuery.Append(" ,B.UNIT_COST ");
                    sbQuery.Append(" ,B.AMT ");
                    sbQuery.Append(" ,ISNULL(TAT_YPGO.TAT_YPGO_QTY,0) AS TAT_YPGO_QTY ");
                    sbQuery.Append(" ,ISNULL(YPGO.QTY,0) AS YPGO_QTY ");
                    sbQuery.Append(" ,ISNULL(CHK_YPGO.QTY,0) AS CHK_YPGO_QTY ");
                    sbQuery.Append(" ,ISNULL(NG_YPGO.QTY,0) AS NG_YPGO_QTY ");
                    sbQuery.Append(" ,(ISNULL(YPGO.QTY,0) + ISNULL(NG_YPGO.QTY,0)) AS TOT_YPGO_QTY ");
                    //sbQuery.Append(" ,(ISNULL(B.QTY,0) - (ISNULL(YPGO.QTY,0) + ISNULL(CHK_YPGO.QTY,0) + ISNULL(NG_YPGO.QTY,0))) AS QTY ");
                    //sbQuery.Append(" ,(ISNULL(B.QTY,0) - (ISNULL(YPGO.QTY,0) + ISNULL(CHK_YPGO.QTY,0) + ISNULL(NG_YPGO.QTY,0))) AS REMAIN_QTY ");
                    sbQuery.Append(" ,ISNULL(PNG.NG_QTY,0) AS NG_QTY");
                    sbQuery.Append(" ,TY.TYP_ID ");
                    sbQuery.Append(" ,TY.TYP_QTY - ISNULL(PNG.NG_QTY,0) AS QTY");
                    sbQuery.Append(" ,TY.TYP_QTY - ISNULL(PNG.NG_QTY,0) AS REMAIN_QTY");
                    sbQuery.Append(" ,TY.SCOMMENT ");
                    sbQuery.Append(" ,TY.INS_FLAG ");
                    sbQuery.Append(" ,TY.TYP_DATE AS YPGO_DATE");
                    sbQuery.Append(" ,TY.CLOSE_DATE ");
                    sbQuery.Append(" ,TY.INS_DATE ");
                    sbQuery.Append(" ,TY.CHECK_DATE ");
                    sbQuery.Append(" ,W.PART_QTY ");
                    sbQuery.Append(" ,TY.TYP_LOC AS STK_LOCATION ");
                    sbQuery.Append(" ,TY.TYP_LOC_DETAIL AS STK_LOCATION_DETAIL ");
                    sbQuery.Append(" ,B.REG_EMP AS BALJU_REG_EMP ");
                    sbQuery.Append(" ,REG_EMP.EMP_NAME AS BALJU_REG_EMP_NAME ");
                    sbQuery.Append(" ,B.REG_DATE AS BALJU_REG_DATE ");
                    sbQuery.Append(" ,R.REG_EMP AS REQ_REG_EMP ");
                    sbQuery.Append(" ,CASE ISNULL(FM.LINK_KEY, '') WHEN '' THEN 'X' ELSE 'O' END colATTACH   ");
                    sbQuery.Append(" ,FM.LINK_KEY ");
                    sbQuery.Append(" , ISNULL(NULL,GETDATE()) AS INS_DATE ");
                    sbQuery.Append(" FROM TOUT_PROCBALJU B ");
                    sbQuery.Append(" JOIN TOUT_PROCBALJU_MASTER BM ");
                    sbQuery.Append(" ON B.PLT_CODE = BM.PLT_CODE ");
                    sbQuery.Append(" AND B.BALJU_NUM = BM.BALJU_NUM ");
                    sbQuery.Append(" JOIN TOUT_TEMP_YPGO TY ");
                    sbQuery.Append("    ON B.PLT_CODE = TY.PLT_CODE ");
                    sbQuery.Append("    AND B.BALJU_NUM = TY.BALJU_NUM ");
                    sbQuery.Append("    AND B.BALJU_SEQ = TY.BALJU_SEQ ");
                    sbQuery.Append(" LEFT JOIN (SELECT PLT_CODE ");
                    sbQuery.Append("            	, TYP_ID");
                    sbQuery.Append("            	, SUM(NG_QTY) AS NG_QTY");
                    sbQuery.Append("            	, MAX(NG_PROD_CODE) AS NG_PROD_CODE");
                    sbQuery.Append("            	, MAX(NG_TYPE) AS NG_TYPE");
                    sbQuery.Append("              FROM TQCT_PURCHASE_NG");
                    sbQuery.Append("             WHERE NG_TYPE <> 'S'");
                    sbQuery.Append("             AND DATA_FLAG = 0 ");
                    sbQuery.Append("            GROUP BY PLT_CODE, TYP_ID) PNG");
                    sbQuery.Append("    ON TY.PLT_CODE = PNG.PLT_CODE ");
                    sbQuery.Append("    AND TY.TYP_ID = PNG.TYP_ID ");
                    sbQuery.Append(" LEFT JOIN TOUT_REQUEST R  ");
                    sbQuery.Append(" ON B.PLT_CODE = R.PLT_CODE ");
                    sbQuery.Append(" AND B.REQUEST_NO = R.REQUEST_NO ");
                    sbQuery.Append(" AND B.REQUEST_SEQ = R.REQUEST_SEQ ");
                    sbQuery.Append(" LEFT JOIN TOUT_REQUEST_MASTER RM ");
                    sbQuery.Append(" ON R.PLT_CODE = RM.PLT_CODE ");
                    sbQuery.Append(" AND R.REQUEST_NO = RM.REQUEST_NO ");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE REG_EMP ");
                    sbQuery.Append(" ON B.PLT_CODE = REG_EMP.PLT_CODE ");
                    sbQuery.Append(" AND B.REG_EMP = REG_EMP.EMP_CODE ");
                    sbQuery.Append(" LEFT JOIN TSHP_WORKORDER W ");
                    sbQuery.Append(" ON R.PLT_CODE = W.PLT_CODE ");
                    sbQuery.Append(" AND R.WO_NO = W.WO_NO ");
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
                    sbQuery.Append(" ON W.PLT_CODE = TAT_YPGO.PLT_CODE ");
                    sbQuery.Append(" AND W.WO_NO = TAT_YPGO.WO_NO ");
                    sbQuery.Append(" LEFT JOIN  ");
                    sbQuery.Append(" ( ");
                    sbQuery.Append(" SELECT PLT_CODE , BALJU_NUM , BALJU_SEQ , ISNULL(SUM(QTY),0) AS QTY FROM TOUT_PROCYPGO   ");
                    sbQuery.Append(" WHERE YPGO_STAT IN ('19','31','32') ");
                    sbQuery.Append(" GROUP BY PLT_CODE , BALJU_NUM ,BALJU_SEQ ");
                    sbQuery.Append(" ) YPGO ");
                    sbQuery.Append(" ON B.PLT_CODE = YPGO.PLT_CODE ");
                    sbQuery.Append(" AND B.BALJU_NUM = YPGO.BALJU_NUM ");
                    sbQuery.Append(" AND B.BALJU_SEQ = YPGO.BALJU_SEQ ");
                    sbQuery.Append(" LEFT JOIN  ");
                    sbQuery.Append(" ( ");//검사대기중인 수량
                    sbQuery.Append(" SELECT PLT_CODE , BALJU_NUM , BALJU_SEQ , ISNULL(SUM(TYP_QTY),0) AS QTY FROM TOUT_TEMP_YPGO   ");
                    sbQuery.Append(" WHERE TYP_STAT IN ('20','42') ");
                    sbQuery.Append(" GROUP BY PLT_CODE , BALJU_NUM ,BALJU_SEQ ");
                    sbQuery.Append(" ) CHK_YPGO ");
                    sbQuery.Append(" ON B.PLT_CODE = CHK_YPGO.PLT_CODE ");
                    sbQuery.Append(" AND B.BALJU_NUM = CHK_YPGO.BALJU_NUM ");
                    sbQuery.Append(" AND B.BALJU_SEQ = CHK_YPGO.BALJU_SEQ ");
                    sbQuery.Append(" LEFT JOIN  ");
                    sbQuery.Append(" ( ");
                    sbQuery.Append(" SELECT PLT_CODE , BALJU_NUM , BALJU_SEQ , ISNULL(SUM(QTY),0) AS QTY FROM TOUT_PROCYPGO   ");
                    sbQuery.Append(" WHERE YPGO_STAT IN ('24','25') ");
                    sbQuery.Append(" GROUP BY PLT_CODE , BALJU_NUM ,BALJU_SEQ ");
                    sbQuery.Append(" ) NG_YPGO ");
                    sbQuery.Append(" ON B.PLT_CODE = NG_YPGO.PLT_CODE ");
                    sbQuery.Append(" AND B.BALJU_NUM = NG_YPGO.BALJU_NUM ");
                    sbQuery.Append(" AND B.BALJU_SEQ = NG_YPGO.BALJU_SEQ ");

                    //sbQuery.Append(" LEFT JOIN  ");
                    //sbQuery.Append(" ( ");
                    //sbQuery.Append(" SELECT PLT_CODE , BALJU_NUM , BALJU_SEQ , ISNULL(SUM(QTY),0) AS QTY FROM TOUT_PROCYPGO   ");
                    //sbQuery.Append(" WHERE YPGO_STAT IN ('40','41') ");
                    //sbQuery.Append(" GROUP BY PLT_CODE , BALJU_NUM ,BALJU_SEQ ");
                    //sbQuery.Append(" ) YPGO ");
                    //sbQuery.Append(" ON B.PLT_CODE = YPGO.PLT_CODE ");
                    //sbQuery.Append(" AND B.BALJU_NUM = YPGO.BALJU_NUM ");
                    //sbQuery.Append(" AND B.BALJU_SEQ = YPGO.BALJU_SEQ ");
                    //sbQuery.Append(" LEFT JOIN  ");
                    //sbQuery.Append(" ( ");
                    //sbQuery.Append(" SELECT PLT_CODE , BALJU_NUM , BALJU_SEQ , ISNULL(SUM(QTY),0) AS QTY FROM TOUT_PROCYPGO   ");
                    //sbQuery.Append(" WHERE YPGO_STAT IN ('42','20') ");//검사완료, 검사대기
                    //sbQuery.Append(" GROUP BY PLT_CODE , BALJU_NUM ,BALJU_SEQ ");
                    //sbQuery.Append(" ) CHK_YPGO ");
                    //sbQuery.Append(" ON B.PLT_CODE = CHK_YPGO.PLT_CODE ");
                    //sbQuery.Append(" AND B.BALJU_NUM = CHK_YPGO.BALJU_NUM ");
                    //sbQuery.Append(" AND B.BALJU_SEQ = CHK_YPGO.BALJU_SEQ ");
                    //sbQuery.Append(" LEFT JOIN  ");
                    //sbQuery.Append(" ( ");
                    //sbQuery.Append(" SELECT PLT_CODE , BALJU_NUM , BALJU_SEQ , ISNULL(SUM(QTY),0) AS QTY FROM TOUT_PROCYPGO   ");
                    //sbQuery.Append(" WHERE YPGO_STAT IN ('24','25') ");
                    //sbQuery.Append(" GROUP BY PLT_CODE , BALJU_NUM ,BALJU_SEQ ");
                    //sbQuery.Append(" ) NG_YPGO ");
                    //sbQuery.Append(" ON B.PLT_CODE = NG_YPGO.PLT_CODE ");
                    //sbQuery.Append(" AND B.BALJU_NUM = NG_YPGO.BALJU_NUM ");
                    //sbQuery.Append(" AND B.BALJU_SEQ = NG_YPGO.BALJU_SEQ ");

                    sbQuery.Append(" LEFT OUTER JOIN (SELECT PLT_CODE, LINK_KEY FROM TSYS_FILELIST_MASTER WHERE IS_UPLOAD = 1 AND UPLOAD_MENU = 'PLN01A' AND DATA_FLAG = 0 GROUP BY PLT_CODE, LINK_KEY) FM ");
                    sbQuery.Append(" ON P.PLT_CODE = FM.PLT_CODE AND P.PART_CODE = FM.LINK_KEY ");

                    sbQuery.Append("  LEFT JOIN TSTD_CODES CD ");
                    sbQuery.Append("  ON SP.PLT_CODE = CD.PLT_CODE ");
                    sbQuery.Append("  AND SP.PART_PRODTYPE = CD.CD_CODE ");
                    sbQuery.Append("  AND CD.CAT_CODE = 'M007' ");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE B.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                        sbWhere.Append(UTIL.GetWhere(row, "@BALJU_NUM", " B.BALJU_NUM = @BALJU_NUM "));
                        sbWhere.Append(UTIL.GetWhere(row, "@BALJU_NUM_LIKE", " (B.BALJU_NUM LIKE '%' + @BALJU_NUM_LIKE + '%') "));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_BALJU_DATE, @E_BALJU_DATE", " (BM.BALJU_DATE BETWEEN @S_BALJU_DATE AND @E_BALJU_DATE) "));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_DUE_DATE, @E_DUE_DATE", " (B.DUE_DATE BETWEEN @S_DUE_DATE AND @E_DUE_DATE) "));
                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_CODE", " W.PROD_CODE = @PROD_CODE "));
                        sbWhere.Append(UTIL.GetWhere(row, "@ITEM_CODE", " I.ITEM_CODE = @ITEM_CODE "));
                        sbWhere.Append(UTIL.GetWhere(row, "@OVND_CODE", " BM.OVND_CODE = @OVND_CODE "));
                        sbWhere.Append(UTIL.GetWhere(row, "@BALJU_SEQ", " B.BALJU_SEQ = @BALJU_SEQ "));
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_CODE", " W.PART_CODE = @PART_CODE "));
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_NUM_LIKE", " (PT.PART_NUM LIKE '%' + @PART_NUM_LIKE + '%') "));


                        //search_con : 검색 통합 거래처,발주번호,공정명,수주코드,수주처명,품목코드,도면번호,품목명,제품규격,형식,재질,제품규격,소재규격,발주규격
                        //V.VEN_NAME, BALJU_NUM, PROC_NAME, ITEM_CODE, CV.VEN_NAME, PART_CODE, DRAW_NO, PART_NAME, MAT_SPEC1, PART_PRODTYPE, MAT_QLTY, MAT_SPEC, BAL_SPEC
                        string cond = "(V.VEN_NAME LIKE '%' + @SEARCH_CON + '%' OR B.BALJU_NUM LIKE '%' + @SEARCH_CON + '%' OR ";
                        cond += " I.ITEM_CODE LIKE '%' + @SEARCH_CON + '%' OR CV.VEN_NAME LIKE '%' + @SEARCH_CON + '%' OR ";
                        cond += " W.PART_CODE LIKE '%' + @SEARCH_CON + '%' OR SP.PART_NAME LIKE '%' + @SEARCH_CON + '%' OR PRC.PROC_NAME LIKE '%' + @SEARCH_CON + '%' ";
                        cond += " OR SP.MAT_SPEC1 LIKE '%' + @SEARCH_CON + '%' OR SP.MAT_SPEC LIKE '%' + @SEARCH_CON + '%' OR SP.BAL_SPEC LIKE '%' + @SEARCH_CON + '%'";

                        cond += " OR CD.CD_NAME LIKE '%' + @SEARCH_CON + '%' ";
                        //cond += " OR SP.PART_PRODTYPE LIKE '%' + @SEARCH_CON + '%' ";
                        cond += " OR Q.MQLTY_NAME LIKE '%' + @SEARCH_CON + '%' ) ";
                        sbWhere.Append(UTIL.GetWhere(row, "@SEARCH_CON", cond));

                        //sbWhere.Append(" AND B.BAL_STAT IN ('40','41') ");
                        sbWhere.Append(" AND TY.TYP_STAT IN ('40','41') ");
                        sbWhere.Append(" AND B.QTY > (ISNULL(PNG.NG_QTY,0) + ISNULL(YPGO.QTY, 0)) "); 
                        //sbWhere.Append(" AND (TY.TYP_QTY - ISNULL(PNG.NG_QTY,0)) >= 0");
                        //sbWhere.Append(" AND (ISNULL(B.QTY,0) - (ISNULL(YPGO.QTY,0) + ISNULL(CHK_YPGO.QTY,0) + ISNULL(NG_YPGO.QTY,0))) >= 0 ");

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

        public static DataTable TOUT_PROCBALJU_QUERY18(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT  ");
                    sbQuery.Append(" B.PLT_CODE ");
                    sbQuery.Append(" ,TY.TYP_ID ");
                    sbQuery.Append(" ,TY.TYP_STAT ");
                    sbQuery.Append(" ,B.REQUEST_NO ");
                    sbQuery.Append(" ,B.REQUEST_SEQ ");
                    sbQuery.Append(" ,RM.REQ_DATE ");
                    sbQuery.Append(" ,RM.DUE_DATE AS REQ_DUE_DATE ");
                    sbQuery.Append(" ,R.WO_NO ");
                    sbQuery.Append(" ,B.BALJU_NUM ");
                    sbQuery.Append(" ,B.BALJU_SEQ ");
                    sbQuery.Append(" ,B.BAL_STAT ");
                    sbQuery.Append(" ,BM.BALJU_DATE ");
                    sbQuery.Append(" ,B.DUE_DATE ");
                    sbQuery.Append(" ,BM.OVND_CODE AS VEN_CODE ");
                    sbQuery.Append(" ,V.VEN_NAME ");
                    sbQuery.Append(" ,I.ITEM_CODE ");
                    sbQuery.Append(" ,I.ITEM_NAME ");
                    sbQuery.Append(" ,I.CVND_CODE ");
                    sbQuery.Append(" ,CV.VEN_NAME AS CVND_NAME");
                    sbQuery.Append(" ,P.PROD_CODE ");
                    sbQuery.Append(" ,P.PROD_NAME ");
                    sbQuery.Append(" ,SP.PART_CODE ");
                    sbQuery.Append(" ,SP.PART_NAME ");
                    sbQuery.Append(" ,SP.MAT_LTYPE ");
                    sbQuery.Append(" ,SP.MAT_MTYPE ");
                    sbQuery.Append(" ,SP.MAT_STYPE ");
                    sbQuery.Append(" ,SP.MAT_UNIT ");
                    sbQuery.Append(" ,SP.PART_PRODTYPE ");
                    sbQuery.Append(" ,SP.MAT_QLTY AS PART_QLTY ");
                    sbQuery.Append(" ,Q.MQLTY_NAME AS PART_QLTY_NAME ");
                    sbQuery.Append(" ,SP.MAT_SPEC AS PART_SPEC ");
                    sbQuery.Append(" ,SP.MAT_SPEC1 AS PART_SPEC1 ");
                    sbQuery.Append(" ,R.PROC_CODE ");
                    sbQuery.Append(" ,PRC.PROC_NAME ");
                    sbQuery.Append(" ,B.QTY AS BAL_QTY ");
                    sbQuery.Append(" ,B.UNIT_COST ");
                    sbQuery.Append(" ,B.AMT ");
                    //sbQuery.Append(" ,ISNULL(YPGO.QTY,0) AS YPGO_QTY ");
                    //sbQuery.Append(" ,ISNULL(CHK_YPGO.QTY,0) AS CHK_YPGO_QTY ");
                    //sbQuery.Append(" ,ISNULL(NG_YPGO.QTY,0) AS NG_YPGO_QTY ");
                    //sbQuery.Append(" ,(ISNULL(YPGO.QTY,0) + ISNULL(NG_YPGO.QTY,0)) AS TOT_YPGO_QTY ");
                    //sbQuery.Append(" ,(ISNULL(B.QTY,0) - (ISNULL(YPGO.QTY,0) + ISNULL(CHK_YPGO.QTY,0) + ISNULL(NG_YPGO.QTY,0))) AS QTY ");
                    //sbQuery.Append(" ,(ISNULL(B.QTY,0) - (ISNULL(YPGO.QTY,0) + ISNULL(CHK_YPGO.QTY,0) + ISNULL(NG_YPGO.QTY,0))) AS REMAIN_QTY ");
                    sbQuery.Append(" ,TY.TYP_QTY ");
                    sbQuery.Append(" ,BM.SCOMMENT ");
                    //sbQuery.Append(" ,SP.INS_FLAG AS SCH_INS_DATE ");
                    //sbQuery.Append(" ,SP.INS_FLAG ");
                    sbQuery.Append(" ,TY.TYP_LOC AS STK_LOCATION ");
                    sbQuery.Append(" ,B.REG_EMP AS BALJU_REG_EMP ");
                    sbQuery.Append(" ,REG_EMP.EMP_NAME AS BALJU_REG_EMP_NAME ");
                    sbQuery.Append(" ,B.REG_DATE AS BALJU_REG_DATE ");
                    sbQuery.Append(" ,R.REG_EMP AS REQ_REG_EMP ");
                    sbQuery.Append(" ,CASE ISNULL(FM.LINK_KEY, '') WHEN '' THEN 'X' ELSE 'O' END colATTACH   ");
                    sbQuery.Append(" ,FM.LINK_KEY ");
                    sbQuery.Append(" , TY.INS_DATE AS SCH_INS_DATE");
                    sbQuery.Append(" FROM TOUT_PROCBALJU B ");
                    sbQuery.Append(" JOIN TOUT_PROCBALJU_MASTER BM ");
                    sbQuery.Append(" ON B.PLT_CODE = BM.PLT_CODE ");
                    sbQuery.Append(" AND B.BALJU_NUM = BM.BALJU_NUM ");
                    sbQuery.Append(" LEFT JOIN TOUT_REQUEST R  ");
                    sbQuery.Append(" ON B.PLT_CODE = R.PLT_CODE ");
                    sbQuery.Append(" AND B.REQUEST_NO = R.REQUEST_NO ");
                    sbQuery.Append(" AND B.REQUEST_SEQ = R.REQUEST_SEQ ");
                    sbQuery.Append(" LEFT JOIN TOUT_TEMP_YPGO TY  ");
                    sbQuery.Append(" ON B.PLT_CODE = TY.PLT_CODE ");
                    sbQuery.Append(" AND B.BALJU_NUM = TY.BALJU_NUM ");
                    sbQuery.Append(" AND B.BALJU_SEQ = TY.BALJU_SEQ ");
                    sbQuery.Append(" LEFT JOIN TOUT_REQUEST_MASTER RM ");
                    sbQuery.Append(" ON R.PLT_CODE = RM.PLT_CODE ");
                    sbQuery.Append(" AND R.REQUEST_NO = RM.REQUEST_NO ");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE REG_EMP ");
                    sbQuery.Append(" ON B.PLT_CODE = REG_EMP.PLT_CODE ");
                    sbQuery.Append(" AND B.REG_EMP = REG_EMP.EMP_CODE ");
                    sbQuery.Append(" LEFT JOIN TSHP_WORKORDER W ");
                    sbQuery.Append(" ON R.PLT_CODE = W.PLT_CODE ");
                    sbQuery.Append(" AND R.WO_NO = W.WO_NO ");
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
                    sbQuery.Append(" LEFT JOIN  ");
                    sbQuery.Append(" ( ");
                    sbQuery.Append(" SELECT PLT_CODE , BALJU_NUM , BALJU_SEQ , ISNULL(SUM(QTY),0) AS QTY FROM TOUT_PROCYPGO   ");
                    sbQuery.Append(" WHERE YPGO_STAT IN ('19','31','32') ");
                    sbQuery.Append(" GROUP BY PLT_CODE , BALJU_NUM ,BALJU_SEQ ");
                    sbQuery.Append(" ) YPGO ");
                    sbQuery.Append(" ON B.PLT_CODE = YPGO.PLT_CODE ");
                    sbQuery.Append(" AND B.BALJU_NUM = YPGO.BALJU_NUM ");
                    sbQuery.Append(" AND B.BALJU_SEQ = YPGO.BALJU_SEQ ");
                    sbQuery.Append(" LEFT JOIN  ");
                    sbQuery.Append(" ( ");
                    sbQuery.Append(" SELECT PLT_CODE , BALJU_NUM , BALJU_SEQ , ISNULL(SUM(QTY),0) AS QTY FROM TOUT_PROCYPGO   ");
                    sbQuery.Append(" WHERE YPGO_STAT IN ('20','42') ");
                    sbQuery.Append(" GROUP BY PLT_CODE , BALJU_NUM ,BALJU_SEQ ");
                    sbQuery.Append(" ) CHK_YPGO ");
                    sbQuery.Append(" ON B.PLT_CODE = CHK_YPGO.PLT_CODE ");
                    sbQuery.Append(" AND B.BALJU_NUM = CHK_YPGO.BALJU_NUM ");
                    sbQuery.Append(" AND B.BALJU_SEQ = CHK_YPGO.BALJU_SEQ ");
                    sbQuery.Append(" LEFT JOIN  ");
                    sbQuery.Append(" ( ");
                    sbQuery.Append(" SELECT PLT_CODE , BALJU_NUM , BALJU_SEQ , ISNULL(SUM(QTY),0) AS QTY FROM TOUT_PROCYPGO   ");
                    sbQuery.Append(" WHERE YPGO_STAT IN ('24','25') ");
                    sbQuery.Append(" GROUP BY PLT_CODE , BALJU_NUM ,BALJU_SEQ ");
                    sbQuery.Append(" ) NG_YPGO ");
                    sbQuery.Append(" ON B.PLT_CODE = NG_YPGO.PLT_CODE ");
                    sbQuery.Append(" AND B.BALJU_NUM = NG_YPGO.BALJU_NUM ");
                    sbQuery.Append(" AND B.BALJU_SEQ = NG_YPGO.BALJU_SEQ ");

                    sbQuery.Append(" LEFT OUTER JOIN (SELECT PLT_CODE, LINK_KEY FROM TSYS_FILELIST_MASTER WHERE IS_UPLOAD = 1 AND UPLOAD_MENU = 'PLN01A' AND DATA_FLAG = 0 GROUP BY PLT_CODE, LINK_KEY) FM ");
                    sbQuery.Append(" ON P.PLT_CODE = FM.PLT_CODE AND P.PART_CODE = FM.LINK_KEY ");

                    sbQuery.Append("  LEFT JOIN TSTD_CODES CD ");
                    sbQuery.Append("  ON SP.PLT_CODE = CD.PLT_CODE ");
                    sbQuery.Append("  AND SP.PART_PRODTYPE = CD.CD_CODE ");
                    sbQuery.Append("  AND CD.CAT_CODE = 'M007' ");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE B.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                        sbWhere.Append(UTIL.GetWhere(row, "@BALJU_NUM", " B.BALJU_NUM = @BALJU_NUM "));
                        sbWhere.Append(UTIL.GetWhere(row, "@BALJU_NUM_LIKE", " (B.BALJU_NUM LIKE '%' + @BALJU_NUM_LIKE + '%') "));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_TYP_DATE, @E_TYP_DATE", " (TY.TYP_DATE BETWEEN @S_TYP_DATE AND @E_TYP_DATE) "));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_BALJU_DATE, @E_BALJU_DATE", " (BM.BALJU_DATE BETWEEN @S_BALJU_DATE AND @E_BALJU_DATE) "));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_DUE_DATE, @E_DUE_DATE", " (B.DUE_DATE BETWEEN @S_DUE_DATE AND @E_DUE_DATE) "));
                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_CODE", " W.PROD_CODE = @PROD_CODE "));
                        sbWhere.Append(UTIL.GetWhere(row, "@ITEM_CODE", " I.ITEM_CODE = @ITEM_CODE "));
                        sbWhere.Append(UTIL.GetWhere(row, "@OVND_CODE", " BM.OVND_CODE = @OVND_CODE "));
                        sbWhere.Append(UTIL.GetWhere(row, "@BALJU_SEQ", " B.BALJU_SEQ = @BALJU_SEQ "));
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_CODE", " W.PART_CODE = @PART_CODE "));
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_NUM_LIKE", " (PT.PART_NUM LIKE '%' + @PART_NUM_LIKE + '%') "));


                        //search_con : 검색 통합 거래처,발주번호,공정명,수주코드,수주처명,품목코드,도면번호,품목명,제품규격,형식,재질,제품규격,소재규격,발주규격
                        //V.VEN_NAME, BALJU_NUM, PROC_NAME, ITEM_CODE, CV.VEN_NAME, PART_CODE, DRAW_NO, PART_NAME, MAT_SPEC1, PART_PRODTYPE, MAT_QLTY, MAT_SPEC, BAL_SPEC
                        string cond = "(V.VEN_NAME LIKE '%' + @SEARCH_CON + '%' OR B.BALJU_NUM LIKE '%' + @SEARCH_CON + '%' OR ";
                        cond += " I.ITEM_CODE LIKE '%' + @SEARCH_CON + '%' OR CV.VEN_NAME LIKE '%' + @SEARCH_CON + '%' OR ";
                        cond += " W.PART_CODE LIKE '%' + @SEARCH_CON + '%' OR SP.PART_NAME LIKE '%' + @SEARCH_CON + '%' OR PRC.PROC_NAME LIKE '%' + @SEARCH_CON + '%' ";
                        cond += " OR SP.MAT_SPEC1 LIKE '%' + @SEARCH_CON + '%' OR SP.MAT_SPEC LIKE '%' + @SEARCH_CON + '%' OR SP.BAL_SPEC LIKE '%' + @SEARCH_CON + '%'";

                        cond += " OR CD.CD_NAME LIKE '%' + @SEARCH_CON + '%' ";
                        //cond += " OR SP.PART_PRODTYPE LIKE '%' + @SEARCH_CON + '%' ";
                        cond += " OR Q.MQLTY_NAME LIKE '%' + @SEARCH_CON + '%' ) ";
                        sbWhere.Append(UTIL.GetWhere(row, "@SEARCH_CON", cond));

                        sbWhere.Append(" AND TY.TYP_STAT IN ('20','42') ");
                        //sbWhere.Append(" AND (ISNULL(B.QTY,0) - (ISNULL(YPGO.QTY,0) + ISNULL(CHK_YPGO.QTY,0) + ISNULL(NG_YPGO.QTY,0))) >= 0 ");

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
        public static DataTable TOUT_PROCBALJU_QUERY9(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable dtResult = new DataTable("RSLTDT");

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT  ");
                    sbQuery.Append(" B.PLT_CODE ");
                    sbQuery.Append(" ,R.REQUEST_NO ");
                    sbQuery.Append(" ,R.REQUEST_SEQ ");
                    sbQuery.Append(" ,B.BALJU_NUM ");
                    sbQuery.Append(" ,B.BALJU_SEQ ");
                    sbQuery.Append(" ,B.BAL_STAT ");
                    sbQuery.Append(" ,B.DUE_DATE ");
                    sbQuery.Append(" ,B.BAL_STAT ");

                    sbQuery.Append(" FROM TOUT_REQUEST R JOIN TOUT_PROCBALJU B  ");
                    sbQuery.Append("   ON R.PLT_CODE = B.PLT_CODE           ");
                    sbQuery.Append(" AND R.REQUEST_NO = B.REQUEST_NO        ");
                    sbQuery.Append(" AND R.REQUEST_SEQ = B.REQUEST_SEQ      ");
                    sbQuery.Append(" WHERE R.PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("   AND R.WO_NO = @WO_NO        ");
                    sbQuery.Append("   AND B.BAL_STAT IN ('11', '13', '21', '22')       ");

                    dtResult = bizExecute.executeSelectQuery(sbQuery.ToString(), dtParam.Rows[0]);

                }

                return dtResult;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }

        //발주시 같은 작업지시 공정외주 발주,발주승인 상태를 확인한다.
        public static DataTable TOUT_PROCBALJU_QUERY8(DataTable dtParam, BizExecute.BizExecute bizExecute)
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
                    sbQuery.Append("       ,BM.OVND_CODE AS VEN_CODE ");
                    sbQuery.Append("       ,MV.VEN_NAME ");
                    sbQuery.Append("       ,PT.PROD_CODE ");
                    sbQuery.Append("       ,PT.PART_CODE ");
                    sbQuery.Append("       ,PT.PART_NUM ");
                    sbQuery.Append("       ,PT.PT_NAME AS PART_NAME ");
                    sbQuery.Append("       ,PT.PT_ID ");
                    sbQuery.Append("       ,R.WO_NO ");
                    sbQuery.Append("       ,R.PROC_CODE ");
                    sbQuery.Append("       ,SP.PROC_NAME ");
                    sbQuery.Append("   FROM TOUT_PROCBALJU B ");
                    sbQuery.Append(" LEFT JOIN TOUT_PROCBALJU_MASTER BM ");
                    sbQuery.Append(" ON B.PLT_CODE = BM.PLT_CODE ");
                    sbQuery.Append(" AND B.BALJU_NUM = BM.BALJU_NUM ");
                    sbQuery.Append(" LEFT JOIN TSTD_VENDOR MV ");
                    sbQuery.Append(" ON BM.PLT_CODE = MV.PLT_CODE ");
                    sbQuery.Append(" AND BM.OVND_CODE = MV.VEN_CODE ");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE BE ");
                    sbQuery.Append(" ON BM.PLT_CODE = BE.PLT_CODE ");
                    sbQuery.Append(" AND BM.REG_EMP = BE.EMP_CODE ");
                    sbQuery.Append(" LEFT JOIN TOUT_REQUEST R ");
                    sbQuery.Append(" ON B.PLT_CODE = R.PLT_CODE ");
                    sbQuery.Append(" AND B.REQUEST_NO = R.REQUEST_NO ");
                    sbQuery.Append(" AND B.REQUEST_SEQ = R.REQUEST_SEQ ");
                    sbQuery.Append(" LEFT JOIN LSE_STD_PROC SP ");
                    sbQuery.Append(" ON R.PLT_CODE = SP.PLT_CODE ");
                    sbQuery.Append(" AND R.PROC_CODE = SP.PROC_CODE ");
                    sbQuery.Append(" LEFT JOIN TMAT_PUR_PARTLIST PT ");
                    sbQuery.Append(" ON B.PLT_CODE = PT.PLT_CODE ");
                    sbQuery.Append(" AND B.REQUEST_NO = PT.REQUEST_NO ");
                    sbQuery.Append(" AND B.REQUEST_SEQ = PT.REQUEST_SEQ ");



                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE B.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                        sbWhere.Append(UTIL.GetWhere(row, "@WO_NO", " R.WO_NO = @WO_NO "));
                        sbWhere.Append(" AND B.BAL_STAT IN ('11','13')");

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

        public static DataTable TOUT_PROCBALJU_QUERY15(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT              ");
                    sbQuery.Append(" B.PLT_CODE          ");
                    sbQuery.Append(" ,'PO' AS PUR_TYPE   ");
                    sbQuery.Append(" ,I.CVND_CODE ");
                    sbQuery.Append(" ,V.VEN_NAME AS CVND_NAME ");
                    sbQuery.Append(" ,I.ITEM_CODE        ");
                    sbQuery.Append(" ,I.ITEM_NAME        ");
                    sbQuery.Append(" ,P.PROD_CODE        ");
                    sbQuery.Append(" ,P.PROD_NAME        ");
                    sbQuery.Append(" ,I.SALECONFM_DATE   ");
                    sbQuery.Append(" ,P.PART_CODE        ");
                    sbQuery.Append(" ,SP.PART_NAME       ");
                    sbQuery.Append(" ,SP.MAT_LTYPE       ");
                    sbQuery.Append(" ,SP.MAT_MTYPE       ");
                    sbQuery.Append(" ,SP.MAT_STYPE       ");
                    sbQuery.Append(" ,SP.MAT_UNIT        ");
                    sbQuery.Append(" ,SP.PART_PRODTYPE   ");
                    sbQuery.Append(" ,SP.MAT_QLTY        ");
                    sbQuery.Append(" ,Q.MQLTY_NAME AS PART_QLTY_NAME ");
                    sbQuery.Append(" ,SP.MAT_SPEC    ");
                    sbQuery.Append(" ,SP.MAT_SPEC1   ");
                    sbQuery.Append(" ,R.REQUEST_NO   ");
                    sbQuery.Append(" ,R.REQUEST_SEQ  ");
                    sbQuery.Append(" ,RM.REQ_DATE    ");
                    sbQuery.Append(" ,RM.DUE_DATE AS REQ_DUE_DATE ");
                    sbQuery.Append(" ,R.QTY AS REQ_QTY                        ");
                    sbQuery.Append(" ,R.REG_EMP AS REQ_REG_EMP                ");
                    sbQuery.Append(" ,REQ_EMP.EMP_NAME AS REQ_REG_EMP_NAME    ");
                    sbQuery.Append(" ,B.BAL_STAT                              ");
                    sbQuery.Append(" ,B.BALJU_NUM                             ");
                    sbQuery.Append(" ,B.BALJU_SEQ                             ");
                    sbQuery.Append(" ,BM.BALJU_DATE                           ");
                    sbQuery.Append(" ,BM.OVND_CODE AS BALJU_VEN_CODE          ");
                    sbQuery.Append(" ,BAL_VEN.VEN_NAME AS BALJU_VEN_NAME      ");
                    sbQuery.Append(" ,B.DUE_DATE AS BALJU_DUE_DATE            ");
                    sbQuery.Append(" ,B.UNIT_COST AS BAL_UNIT_COST            ");
                    sbQuery.Append(" ,B.QTY AS BAL_QTY                        ");
                    sbQuery.Append(" ,B.AMT AS BAL_AMT                        ");
                    
                    sbQuery.Append(" ,B.MAT_SPEC AS B_MAT_SPEC  ");
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
                    sbQuery.Append(" ,Y.SCOMMENT AS YPGO_SCOMMENT             ");
                    sbQuery.Append(" ,R.PROC_CODE                             ");
                    sbQuery.Append(" ,PRC.PROC_NAME                           ");
                    sbQuery.Append(" ,SPR.SCOMMENT                            ");
                    sbQuery.Append(" ,SPR.PUR_SCOMMENT                        ");
                    sbQuery.Append(" ,B.SCOMMENT    AS BAL_SCOMMENT           ");   //발주비고
                    sbQuery.Append(" FROM                                     ");
                    sbQuery.Append(" TOUT_PROCBALJU B                         ");
                    sbQuery.Append(" LEFT JOIN TOUT_PROCBALJU_MASTER BM       ");
                    sbQuery.Append(" ON B.PLT_CODE = BM.PLT_CODE              ");
                    sbQuery.Append(" AND B.BALJU_NUM = BM.BALJU_NUM           ");
                    sbQuery.Append("                                          ");
                    sbQuery.Append(" LEFT JOIN TOUT_REQUEST R                 ");
                    sbQuery.Append(" ON B.PLT_CODE = R.PLT_CODE               ");
                    sbQuery.Append(" AND B.REQUEST_NO = R.REQUEST_NO          ");
                    sbQuery.Append(" AND B.REQUEST_SEQ = R.REQUEST_SEQ        ");
                    sbQuery.Append("                                          ");
                    sbQuery.Append(" LEFT JOIN TOUT_REQUEST_MASTER RM         ");
                    sbQuery.Append(" ON R.PLT_CODE = RM.PLT_CODE              ");
                    sbQuery.Append(" AND R.REQUEST_NO = RM.REQUEST_NO         ");
                    sbQuery.Append("                                          ");
                    sbQuery.Append(" LEFT JOIN TOUT_PROCYPGO Y                ");
                    sbQuery.Append(" ON B.PLT_CODE = Y.PLT_CODE ");
                    sbQuery.Append(" AND B.BALJU_NUM = Y.BALJU_NUM ");
                    sbQuery.Append(" AND B.BALJU_SEQ = Y.BALJU_SEQ ");
                    sbQuery.Append(" AND Y.YPGO_STAT IN ('19','20','24','25','31','32') ");

                    sbQuery.Append(" LEFT JOIN TSHP_WORKORDER W          ");
                    sbQuery.Append(" ON R.PLT_CODE = W.PLT_CODE          ");
                    sbQuery.Append(" AND R.WO_NO = W.WO_NO               ");

                    sbQuery.Append(" LEFT JOIN TORD_PRODUCT P            ");
                    sbQuery.Append(" ON W.PLT_CODE = P.PLT_CODE          ");
                    sbQuery.Append(" AND W.PROD_CODE = P.PROD_CODE       ");
                    sbQuery.Append(" AND W.PART_CODE = P.PART_CODE       ");

                    sbQuery.Append(" LEFT JOIN TORD_ITEM I               ");
                    sbQuery.Append(" ON P.PLT_CODE = I.PLT_CODE          ");
                    sbQuery.Append(" AND P.ITEM_CODE = I.ITEM_CODE       ");

                    sbQuery.Append(" LEFT JOIN TSTD_VENDOR V       ");
                    sbQuery.Append(" ON I.PLT_CODE = V.PLT_CODE   ");
                    sbQuery.Append(" AND I.CVND_CODE = V.VEN_CODE ");

                    sbQuery.Append(" LEFT JOIN LSE_STD_PART SP           ");
                    sbQuery.Append(" ON P.PLT_CODE = SP.PLT_CODE         ");
                    sbQuery.Append(" AND P.PART_CODE = SP.PART_CODE      ");

                    sbQuery.Append(" LEFT JOIN TMAT_QUC_MASTER Q         ");
                    sbQuery.Append(" ON SP.PLT_CODE = Q.PLT_CODE         ");
                    sbQuery.Append(" AND SP.MAT_QLTY = Q.MQLTY_CODE      ");

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
                    sbQuery.Append(" AND BM.OVND_CODE = BAL_VEN.VEN_CODE ");
                    sbQuery.Append(" LEFT JOIN LSE_STD_PROC PRC          ");
                    sbQuery.Append(" ON R.PLT_CODE = PRC.PLT_CODE        ");
                    sbQuery.Append(" AND R.PROC_CODE = PRC.PROC_CODE     ");
                    sbQuery.Append(" LEFT JOIN LSE_STD_PARTPROC SPR          ");
                    sbQuery.Append(" ON R.PLT_CODE = SPR.PLT_CODE        ");
                    sbQuery.Append(" AND R.PART_CODE = SPR.PART_CODE     ");
                    sbQuery.Append(" AND R.PROC_CODE = SPR.PROC_CODE     ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE B.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@BALJU_NUM", " B.BALJU_NUM = @BALJU_NUM "));
                        sbWhere.Append(UTIL.GetWhere(row, "@BALJU_NUM_LIKE", " (B.BALJU_NUM LIKE '%' + @BALJU_NUM_LIKE + '%') "));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_BALJU_DATE,@E_BALJU_DATE", " (BM.BALJU_DATE BETWEEN @S_BALJU_DATE AND @E_BALJU_DATE) "));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_DUE_DATE,@E_DUE_DATE", " (B.DUE_DATE BETWEEN @S_DUE_DATE AND @E_DUE_DATE) "));
                        sbWhere.Append(UTIL.GetWhere(row, "@ITEM_CODE", " I.ITEM_CODE = @ITEM_CODE "));
                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_CODE", " R.PROD_CODE = @PROD_CODE "));
                        sbWhere.Append(UTIL.GetWhere(row, "@MVND_CODE", " B.VEN_CODE = @MVND_CODE "));

                        sbWhere.Append(UTIL.GetWhere(row, "@BALJU_SEQ", " B.BALJU_SEQ = @BALJU_SEQ "));
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_CODE", " R.PART_CODE = @PART_CODE "));
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_LIKE", "(R.PART_CODE LIKE '%' + @PART_LIKE + '%' OR SP.PART_NAME LIKE '%' + @PART_LIKE + '%')"));

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

        //외주 발주 품목별 발주 이력 보기
        public static DataTable TOUT_PROCBALJU_QUERY16(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT TOP 10       ");
                    sbQuery.Append(" B.PLT_CODE          ");
                    sbQuery.Append(" ,'PO' AS PUR_TYPE   ");
                    //sbQuery.Append(" ,I.CVND_CODE ");
                    sbQuery.Append(" ,V.VEN_NAME AS CVND_NAME ");
                    //sbQuery.Append(" ,I.ITEM_CODE        ");
                    //sbQuery.Append(" ,I.ITEM_NAME        ");
                    //sbQuery.Append(" ,P.PROD_CODE        ");
                    //sbQuery.Append(" ,P.PROD_NAME        ");
                    //sbQuery.Append(" ,I.SALECONFM_DATE   ");
                    //sbQuery.Append(" ,P.PART_CODE        ");
                    sbQuery.Append(" ,SP.PART_NAME       ");
                    //sbQuery.Append(" ,SP.MAT_LTYPE       ");
                    //sbQuery.Append(" ,SP.MAT_MTYPE       ");
                    //sbQuery.Append(" ,SP.MAT_STYPE       ");
                    //sbQuery.Append(" ,SP.MAT_UNIT        ");
                    //sbQuery.Append(" ,SP.PART_PRODTYPE   ");
                    //sbQuery.Append(" ,SP.MAT_QLTY        ");
                    //sbQuery.Append(" ,Q.MQLTY_NAME AS PART_QLTY_NAME ");
                    //sbQuery.Append(" ,SP.MAT_SPEC    ");
                    //sbQuery.Append(" ,SP.MAT_SPEC1   ");
                    //sbQuery.Append(" ,R.REQUEST_NO   ");
                    //sbQuery.Append(" ,R.REQUEST_SEQ  ");
                    //sbQuery.Append(" ,RM.REQ_DATE    ");
                    //sbQuery.Append(" ,RM.DUE_DATE AS REQ_DUE_DATE ");
                    //sbQuery.Append(" ,R.QTY AS REQ_QTY                        ");
                    //sbQuery.Append(" ,R.REG_EMP AS REQ_REG_EMP                ");
                    //sbQuery.Append(" ,REQ_EMP.EMP_NAME AS REQ_REG_EMP_NAME    ");
                    //sbQuery.Append(" ,B.BAL_STAT                              ");
                    //sbQuery.Append(" ,B.BALJU_NUM                             ");
                    //sbQuery.Append(" ,B.BALJU_SEQ                             ");
                    sbQuery.Append(" ,BM.BALJU_DATE                           ");
                    //sbQuery.Append(" ,BM.OVND_CODE AS BALJU_VEN_CODE          ");
                    sbQuery.Append(" ,BAL_VEN.VEN_NAME AS BALJU_VEN_NAME      ");
                    //sbQuery.Append(" ,B.DUE_DATE AS BALJU_DUE_DATE            ");
                    sbQuery.Append(" ,B.UNIT_COST AS BAL_UNIT_COST            ");
                    sbQuery.Append(" ,B.QTY AS BAL_QTY                        ");
                    sbQuery.Append(" ,B.AMT AS BAL_AMT                        ");

                    //sbQuery.Append(" ,B.MAT_SPEC AS B_MAT_SPEC  ");
                    //sbQuery.Append(" ,B.MAT_WEIGHT AS B_WEIGHT  ");

                    //sbQuery.Append(" ,B.REG_EMP AS BAL_REG_EMP                ");
                    //sbQuery.Append(" ,BAL_EMP.EMP_NAME AS BAL_REG_EMP_NAME    ");
                    //sbQuery.Append(" ,B.C_REASON ");
                    //sbQuery.Append(" ,Y.YPGO_ID                               ");
                    sbQuery.Append(" ,Y.YPGO_DATE                             ");
                    //sbQuery.Append(" ,Y.QTY AS YPGO_QTY                       ");
                    //sbQuery.Append(" ,Y.YPGO_STAT                             ");
                    //sbQuery.Append(" ,Y.REG_EMP AS YPGO_REG_EMP               ");
                    //sbQuery.Append(" ,YPGO_EMP.EMP_NAME AS YPGO_REG_EMP_NAME  ");
                    //sbQuery.Append("                                          ");
                    //sbQuery.Append(" ,R.PROC_CODE                             ");
                    //sbQuery.Append(" ,PRC.PROC_NAME                           ");
                    sbQuery.Append("                                          ");
                    sbQuery.Append(" FROM                                     ");
                    sbQuery.Append(" TOUT_PROCBALJU B                         ");
                    sbQuery.Append(" LEFT JOIN TOUT_PROCBALJU_MASTER BM       ");
                    sbQuery.Append(" ON B.PLT_CODE = BM.PLT_CODE              ");
                    sbQuery.Append(" AND B.BALJU_NUM = BM.BALJU_NUM           ");
                    sbQuery.Append("                                          ");
                    sbQuery.Append(" LEFT JOIN TOUT_REQUEST R                 ");
                    sbQuery.Append(" ON B.PLT_CODE = R.PLT_CODE               ");
                    sbQuery.Append(" AND B.REQUEST_NO = R.REQUEST_NO          ");
                    sbQuery.Append(" AND B.REQUEST_SEQ = R.REQUEST_SEQ        ");
                    sbQuery.Append("                                          ");
                    sbQuery.Append(" LEFT JOIN TOUT_REQUEST_MASTER RM         ");
                    sbQuery.Append(" ON R.PLT_CODE = RM.PLT_CODE              ");
                    sbQuery.Append(" AND R.REQUEST_NO = RM.REQUEST_NO         ");
                    sbQuery.Append("                                          ");
                    sbQuery.Append(" LEFT JOIN TOUT_PROCYPGO Y                ");
                    sbQuery.Append(" ON B.PLT_CODE = Y.PLT_CODE ");
                    sbQuery.Append(" AND B.BALJU_NUM = Y.BALJU_NUM ");
                    sbQuery.Append(" AND B.BALJU_SEQ = Y.BALJU_SEQ ");
                    sbQuery.Append(" AND Y.YPGO_STAT IN ('19','20','24','25','31','32') ");

                    sbQuery.Append(" LEFT JOIN TSHP_WORKORDER W          ");
                    sbQuery.Append(" ON R.PLT_CODE = W.PLT_CODE          ");
                    sbQuery.Append(" AND R.WO_NO = W.WO_NO               ");

                    sbQuery.Append(" LEFT JOIN TORD_PRODUCT P            ");
                    sbQuery.Append(" ON W.PLT_CODE = P.PLT_CODE          ");
                    sbQuery.Append(" AND W.PROD_CODE = P.PROD_CODE       ");
                    sbQuery.Append(" AND W.PART_CODE = P.PART_CODE       ");

                    sbQuery.Append(" LEFT JOIN TORD_ITEM I               ");
                    sbQuery.Append(" ON P.PLT_CODE = I.PLT_CODE          ");
                    sbQuery.Append(" AND P.ITEM_CODE = I.ITEM_CODE       ");

                    sbQuery.Append(" LEFT JOIN TSTD_VENDOR V       ");
                    sbQuery.Append(" ON I.PLT_CODE = V.PLT_CODE   ");
                    sbQuery.Append(" AND I.CVND_CODE = V.VEN_CODE ");

                    sbQuery.Append(" LEFT JOIN LSE_STD_PART SP           ");
                    sbQuery.Append(" ON P.PLT_CODE = SP.PLT_CODE         ");
                    sbQuery.Append(" AND P.PART_CODE = SP.PART_CODE      ");

                    //sbQuery.Append(" LEFT JOIN TMAT_QUC_MASTER Q         ");
                    //sbQuery.Append(" ON SP.PLT_CODE = Q.PLT_CODE         ");
                    //sbQuery.Append(" AND SP.MAT_QLTY = Q.MQLTY_CODE      ");

                    //sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE REQ_EMP     ");
                    //sbQuery.Append(" ON R.PLT_CODE = REQ_EMP.PLT_CODE    ");
                    //sbQuery.Append(" AND R.REG_EMP = REQ_EMP.EMP_CODE    ");

                    //sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE BAL_EMP     ");
                    //sbQuery.Append(" ON B.PLT_CODE = BAL_EMP.PLT_CODE    ");
                    //sbQuery.Append(" AND B.REG_EMP = BAL_EMP.EMP_CODE    ");

                    //sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE YPGO_EMP    ");
                    //sbQuery.Append(" ON Y.PLT_CODE = YPGO_EMP.PLT_CODE   ");
                    //sbQuery.Append(" AND Y.REG_EMP = YPGO_EMP.EMP_CODE   ");

                    sbQuery.Append(" LEFT JOIN TSTD_VENDOR BAL_VEN       ");
                    sbQuery.Append(" ON BM.PLT_CODE = BAL_VEN.PLT_CODE   ");
                    sbQuery.Append(" AND BM.OVND_CODE = BAL_VEN.VEN_CODE ");
                    //sbQuery.Append(" LEFT JOIN LSE_STD_PROC PRC          ");
                    //sbQuery.Append(" ON R.PLT_CODE = PRC.PLT_CODE        ");
                    //sbQuery.Append(" AND R.PROC_CODE = PRC.PROC_CODE     ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE B.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        //sbWhere.Append(UTIL.GetWhere(row, "@BALJU_NUM", " B.BALJU_NUM = @BALJU_NUM "));
                        //sbWhere.Append(UTIL.GetWhere(row, "@BALJU_NUM_LIKE", " (B.BALJU_NUM LIKE '%' + @BALJU_NUM_LIKE + '%') "));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_BALJU_DATE,@E_BALJU_DATE", " (BM.BALJU_DATE BETWEEN @S_BALJU_DATE AND @E_BALJU_DATE) "));
                        //sbWhere.Append(UTIL.GetWhere(row, "@S_DUE_DATE,@E_DUE_DATE", " (B.DUE_DATE BETWEEN @S_DUE_DATE AND @E_DUE_DATE) "));
                        //sbWhere.Append(UTIL.GetWhere(row, "@ITEM_CODE", " I.ITEM_CODE = @ITEM_CODE "));
                        //sbWhere.Append(UTIL.GetWhere(row, "@PROD_CODE", " R.PROD_CODE = @PROD_CODE "));
                        //sbWhere.Append(UTIL.GetWhere(row, "@MVND_CODE", " B.VEN_CODE = @MVND_CODE "));

                        //sbWhere.Append(UTIL.GetWhere(row, "@BALJU_SEQ", " B.BALJU_SEQ = @BALJU_SEQ "));
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_CODE", " R.PART_CODE = @PART_CODE "));
                        //sbWhere.Append(UTIL.GetWhere(row, "@PART_LIKE", "(R.PART_CODE LIKE '%' + @PART_LIKE + '%' OR SP.PART_NAME LIKE '%' + @PART_LIKE + '%')"));

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

        public static DataTable TOUT_PROCBALJU_QUERY19(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT  B.PLT_CODE           			  ");
                    sbQuery.Append("         , R.PART_CODE       			  ");
                    sbQuery.Append("         , B.QTY AS BAL_QTY				  ");
                    sbQuery.Append("         , YP.QTY AS YPGO_QTY				  ");
                    sbQuery.Append(" 		, BM.BALJU_DATE					  ");
                    sbQuery.Append(" 		, YP.YPGO_DATE					  ");
                    sbQuery.Append(" 	  , B.BALJU_NUM					   ");
                    sbQuery.Append(" 	  , B.BALJU_SEQ					   ");
                    sbQuery.Append("     FROM TOUT_PROCBALJU B         		  ");
                    sbQuery.Append("     INNER JOIN TOUT_REQUEST R        	  ");
                    sbQuery.Append("         ON B.PLT_CODE = R.PLT_CODE       ");
                    sbQuery.Append("         AND B.REQUEST_NO = R.REQUEST_NO  ");
                    sbQuery.Append(" 		AND B.REQUEST_SEQ = R.REQUEST_SEQ ");
                    sbQuery.Append(" 	INNER JOIN TOUT_PROCBALJU_MASTER BM	  ");
                    sbQuery.Append(" 		ON B.PLT_CODE = BM.PLT_CODE		  ");
                    sbQuery.Append(" 		AND B.BALJU_NUM = BM.BALJU_NUM	  ");
                    sbQuery.Append(" 	LEFT JOIN TOUT_PROCYPGO YP			  ");
                    sbQuery.Append(" 		ON B.PLT_CODE = YP.PLT_CODE		  ");
                    sbQuery.Append(" 		AND B.BALJU_NUM = YP.BALJU_NUM	  ");
                    sbQuery.Append(" 		AND B.BALJU_SEQ = YP.BALJU_SEQ	  ");
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
        public static DataTable TOUT_PROCBALJU_QUERY20(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT  ");
                    sbQuery.Append(" B.PLT_CODE ");
                    sbQuery.Append(" ,TY.TYP_ID ");
                    sbQuery.Append(" ,TY.TYP_STAT AS BAL_STAT ");
                    sbQuery.Append(" ,B.REQUEST_NO ");
                    sbQuery.Append(" ,B.REQUEST_SEQ ");
                    sbQuery.Append(" ,RM.REQ_DATE ");
                    sbQuery.Append(" ,RM.DUE_DATE AS REQ_DUE_DATE ");
                    sbQuery.Append(" ,R.WO_NO ");
                    sbQuery.Append(" ,PCHECK.WO_NO AS PART_CHK_WO_NO ");
                    sbQuery.Append(" ,B.BALJU_NUM ");
                    sbQuery.Append(" ,B.BALJU_SEQ ");
                    //sbQuery.Append(" ,B.BAL_STAT ");
                    sbQuery.Append(" ,BM.BALJU_DATE ");
                    sbQuery.Append(" ,B.DUE_DATE ");
                    sbQuery.Append(" ,BM.OVND_CODE AS VEN_CODE ");
                    sbQuery.Append(" ,V.VEN_NAME ");
                    sbQuery.Append(" ,I.ITEM_CODE ");
                    sbQuery.Append(" ,I.ITEM_NAME ");
                    sbQuery.Append(" ,I.CVND_CODE ");
                    sbQuery.Append(" ,CV.VEN_NAME AS CVND_NAME");
                    sbQuery.Append(" ,P.PROD_CODE ");
                    sbQuery.Append(" ,P.PROD_NAME ");
                    sbQuery.Append(" ,SP.PART_CODE ");
                    sbQuery.Append(" ,SP.PART_NAME ");
                    sbQuery.Append(" ,SP.MAT_LTYPE ");
                    sbQuery.Append(" ,SP.MAT_MTYPE ");
                    sbQuery.Append(" ,SP.MAT_STYPE ");
                    sbQuery.Append(" ,SP.MAT_UNIT ");
                    sbQuery.Append(" ,SP.PART_PRODTYPE ");
                    sbQuery.Append(" ,SP.MAT_QLTY AS PART_QLTY ");
                    sbQuery.Append(" ,Q.MQLTY_NAME AS PART_QLTY_NAME ");
                    sbQuery.Append(" ,SP.MAT_SPEC AS PART_SPEC ");
                    sbQuery.Append(" ,SP.MAT_SPEC1 AS PART_SPEC1 ");
                    sbQuery.Append(" ,R.PROC_CODE ");
                    sbQuery.Append(" ,PRC.PROC_NAME ");
                    sbQuery.Append(" ,B.QTY AS BAL_QTY ");
                    sbQuery.Append(" ,B.UNIT_COST ");
                    sbQuery.Append(" ,B.AMT ");
                    //sbQuery.Append(" ,ISNULL(YPGO.QTY,0) AS YPGO_QTY ");
                    //sbQuery.Append(" ,ISNULL(CHK_YPGO.QTY,0) AS CHK_YPGO_QTY ");
                    //sbQuery.Append(" ,ISNULL(NG_YPGO.QTY,0) AS NG_YPGO_QTY ");
                    //sbQuery.Append(" ,(ISNULL(YPGO.QTY,0) + ISNULL(NG_YPGO.QTY,0)) AS TOT_YPGO_QTY ");
                    //sbQuery.Append(" ,(ISNULL(B.QTY,0) - (ISNULL(YPGO.QTY,0) + ISNULL(CHK_YPGO.QTY,0) + ISNULL(NG_YPGO.QTY,0))) AS QTY ");
                    //sbQuery.Append(" ,(ISNULL(B.QTY,0) - (ISNULL(YPGO.QTY,0) + ISNULL(CHK_YPGO.QTY,0) + ISNULL(NG_YPGO.QTY,0))) AS REMAIN_QTY ");
                    sbQuery.Append(" ,TY.TYP_QTY ");
                    sbQuery.Append(" ,ISNULL(PNG.NG_QTY,0) AS NG_QTY ");
                    sbQuery.Append(" ,BM.SCOMMENT ");
                    //sbQuery.Append(" ,SP.INS_FLAG AS SCH_INS_DATE ");
                    sbQuery.Append(" ,TY.INS_FLAG ");
                    sbQuery.Append(" ,TY.TYP_LOC AS STK_LOCATION ");
                    sbQuery.Append(" ,B.REG_EMP AS BALJU_REG_EMP ");
                    sbQuery.Append(" ,REG_EMP.EMP_NAME AS BALJU_REG_EMP_NAME ");
                    sbQuery.Append(" ,B.REG_DATE AS BALJU_REG_DATE ");
                    sbQuery.Append(" ,R.REG_EMP AS REQ_REG_EMP ");
                    sbQuery.Append(" ,CASE ISNULL(FM.LINK_KEY, '') WHEN '' THEN 'X' ELSE 'O' END colATTACH   ");
                    sbQuery.Append(" ,FM.LINK_KEY ");
                    sbQuery.Append(" , TY.INS_DATE AS SCH_INS_DATE");
                    sbQuery.Append(" , TY.INS_DATE ");
                    sbQuery.Append(" FROM TOUT_PROCBALJU B ");
                    sbQuery.Append(" JOIN TOUT_PROCBALJU_MASTER BM ");
                    sbQuery.Append(" ON B.PLT_CODE = BM.PLT_CODE ");
                    sbQuery.Append(" AND B.BALJU_NUM = BM.BALJU_NUM ");
                    sbQuery.Append(" LEFT JOIN TOUT_REQUEST R  ");
                    sbQuery.Append(" ON B.PLT_CODE = R.PLT_CODE ");
                    sbQuery.Append(" AND B.REQUEST_NO = R.REQUEST_NO ");
                    sbQuery.Append(" AND B.REQUEST_SEQ = R.REQUEST_SEQ ");
                    sbQuery.Append(" INNER JOIN TOUT_TEMP_YPGO TY  ");
                    sbQuery.Append(" ON B.PLT_CODE = TY.PLT_CODE ");
                    sbQuery.Append(" AND B.BALJU_NUM = TY.BALJU_NUM ");
                    sbQuery.Append(" AND B.BALJU_SEQ = TY.BALJU_SEQ ");
                    sbQuery.Append(" LEFT JOIN (SELECT PLT_CODE ");
                    sbQuery.Append("            	, TYP_ID");
                    sbQuery.Append("            	, SUM(NG_QTY) AS NG_QTY");
                    sbQuery.Append("              FROM TQCT_PURCHASE_NG");
                    sbQuery.Append("             WHERE NG_TYPE <> 'S'");
                    sbQuery.Append("             AND DATA_FLAG = 0 ");
                    sbQuery.Append("            GROUP BY PLT_CODE, TYP_ID) PNG");
                    sbQuery.Append("    ON TY.PLT_CODE = PNG.PLT_CODE ");
                    sbQuery.Append("    AND TY.TYP_ID = PNG.TYP_ID ");
                    sbQuery.Append(" LEFT JOIN TOUT_REQUEST_MASTER RM ");
                    sbQuery.Append(" ON R.PLT_CODE = RM.PLT_CODE ");
                    sbQuery.Append(" AND R.REQUEST_NO = RM.REQUEST_NO ");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE REG_EMP ");
                    sbQuery.Append(" ON B.PLT_CODE = REG_EMP.PLT_CODE ");
                    sbQuery.Append(" AND B.REG_EMP = REG_EMP.EMP_CODE ");
                    sbQuery.Append(" LEFT JOIN TSHP_WORKORDER W ");
                    sbQuery.Append(" ON R.PLT_CODE = W.PLT_CODE ");
                    sbQuery.Append(" AND R.WO_NO = W.WO_NO ");
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
                    sbQuery.Append(" LEFT JOIN  ");
                    sbQuery.Append(" ( ");
                    sbQuery.Append(" SELECT PLT_CODE , BALJU_NUM , BALJU_SEQ , ISNULL(SUM(QTY),0) AS QTY FROM TOUT_PROCYPGO   ");
                    sbQuery.Append(" WHERE YPGO_STAT IN ('19','31','32') ");
                    sbQuery.Append(" GROUP BY PLT_CODE , BALJU_NUM ,BALJU_SEQ ");
                    sbQuery.Append(" ) YPGO ");
                    sbQuery.Append(" ON B.PLT_CODE = YPGO.PLT_CODE ");
                    sbQuery.Append(" AND B.BALJU_NUM = YPGO.BALJU_NUM ");
                    sbQuery.Append(" AND B.BALJU_SEQ = YPGO.BALJU_SEQ ");
                    sbQuery.Append(" LEFT JOIN  ");
                    sbQuery.Append(" ( ");
                    sbQuery.Append(" SELECT PLT_CODE , BALJU_NUM , BALJU_SEQ , ISNULL(SUM(QTY),0) AS QTY FROM TOUT_PROCYPGO   ");
                    sbQuery.Append(" WHERE YPGO_STAT IN ('20','42') ");
                    sbQuery.Append(" GROUP BY PLT_CODE , BALJU_NUM ,BALJU_SEQ ");
                    sbQuery.Append(" ) CHK_YPGO ");
                    sbQuery.Append(" ON B.PLT_CODE = CHK_YPGO.PLT_CODE ");
                    sbQuery.Append(" AND B.BALJU_NUM = CHK_YPGO.BALJU_NUM ");
                    sbQuery.Append(" AND B.BALJU_SEQ = CHK_YPGO.BALJU_SEQ ");
                    sbQuery.Append(" LEFT JOIN  ");
                    sbQuery.Append(" ( ");
                    sbQuery.Append(" SELECT PLT_CODE , BALJU_NUM , BALJU_SEQ , ISNULL(SUM(QTY),0) AS QTY FROM TOUT_PROCYPGO   ");
                    sbQuery.Append(" WHERE YPGO_STAT IN ('24','25') ");
                    sbQuery.Append(" GROUP BY PLT_CODE , BALJU_NUM ,BALJU_SEQ ");
                    sbQuery.Append(" ) NG_YPGO ");
                    sbQuery.Append(" ON B.PLT_CODE = NG_YPGO.PLT_CODE ");
                    sbQuery.Append(" AND B.BALJU_NUM = NG_YPGO.BALJU_NUM ");
                    sbQuery.Append(" AND B.BALJU_SEQ = NG_YPGO.BALJU_SEQ ");

                    sbQuery.Append(" LEFT OUTER JOIN (SELECT PLT_CODE, LINK_KEY FROM TSYS_FILELIST_MASTER WHERE IS_UPLOAD = 1 AND UPLOAD_MENU = 'PLN01A' AND DATA_FLAG = 0 GROUP BY PLT_CODE, LINK_KEY) FM ");
                    sbQuery.Append(" ON P.PLT_CODE = FM.PLT_CODE AND P.PART_CODE = FM.LINK_KEY ");

                    sbQuery.Append("  LEFT JOIN TSTD_CODES CD ");
                    sbQuery.Append("  ON SP.PLT_CODE = CD.PLT_CODE ");
                    sbQuery.Append("  AND SP.PART_PRODTYPE = CD.CD_CODE ");
                    sbQuery.Append("  AND CD.CAT_CODE = 'M007' ");
                    
                    sbQuery.Append("  LEFT JOIN (SELECT PLT_CODE, WO_NO FROM TSHP_PART_CHK GROUP BY PLT_CODE, WO_NO) PCHECK ");
                    sbQuery.Append("  ON W.PLT_CODE = PCHECK.PLT_CODE ");
                    sbQuery.Append("  AND W.WO_NO = PCHECK.WO_NO ");



                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE B.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                        sbWhere.Append(UTIL.GetWhere(row, "@BALJU_NUM", " B.BALJU_NUM = @BALJU_NUM "));
                        sbWhere.Append(UTIL.GetWhere(row, "@BALJU_NUM_LIKE", " (B.BALJU_NUM LIKE '%' + @BALJU_NUM_LIKE + '%') "));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_TYP_DATE, @E_TYP_DATE", " (TY.TYP_DATE BETWEEN @S_TYP_DATE AND @E_TYP_DATE) "));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_BALJU_DATE, @E_BALJU_DATE", " (BM.BALJU_DATE BETWEEN @S_BALJU_DATE AND @E_BALJU_DATE) "));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_DUE_DATE, @E_DUE_DATE", " (B.DUE_DATE BETWEEN @S_DUE_DATE AND @E_DUE_DATE) "));
                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_CODE", " W.PROD_CODE = @PROD_CODE "));
                        sbWhere.Append(UTIL.GetWhere(row, "@ITEM_CODE", " I.ITEM_CODE = @ITEM_CODE "));
                        sbWhere.Append(UTIL.GetWhere(row, "@OVND_CODE", " BM.OVND_CODE = @OVND_CODE "));
                        sbWhere.Append(UTIL.GetWhere(row, "@BALJU_SEQ", " B.BALJU_SEQ = @BALJU_SEQ "));
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_CODE", " W.PART_CODE = @PART_CODE "));
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_NUM_LIKE", " (PT.PART_NUM LIKE '%' + @PART_NUM_LIKE + '%') "));


                        //search_con : 검색 통합 거래처,발주번호,공정명,수주코드,수주처명,품목코드,도면번호,품목명,제품규격,형식,재질,제품규격,소재규격,발주규격
                        //V.VEN_NAME, BALJU_NUM, PROC_NAME, ITEM_CODE, CV.VEN_NAME, PART_CODE, DRAW_NO, PART_NAME, MAT_SPEC1, PART_PRODTYPE, MAT_QLTY, MAT_SPEC, BAL_SPEC
                        string cond = "(V.VEN_NAME LIKE '%' + @SEARCH_CON + '%' OR B.BALJU_NUM LIKE '%' + @SEARCH_CON + '%' OR ";
                        cond += " I.ITEM_CODE LIKE '%' + @SEARCH_CON + '%' OR CV.VEN_NAME LIKE '%' + @SEARCH_CON + '%' OR ";
                        cond += " W.PART_CODE LIKE '%' + @SEARCH_CON + '%' OR SP.PART_NAME LIKE '%' + @SEARCH_CON + '%' OR PRC.PROC_NAME LIKE '%' + @SEARCH_CON + '%' ";
                        cond += " OR SP.MAT_SPEC1 LIKE '%' + @SEARCH_CON + '%' OR SP.MAT_SPEC LIKE '%' + @SEARCH_CON + '%' OR SP.BAL_SPEC LIKE '%' + @SEARCH_CON + '%'";

                        cond += " OR CD.CD_NAME LIKE '%' + @SEARCH_CON + '%' ";
                        //cond += " OR SP.PART_PRODTYPE LIKE '%' + @SEARCH_CON + '%' ";
                        cond += " OR Q.MQLTY_NAME LIKE '%' + @SEARCH_CON + '%' ) ";
                        sbWhere.Append(UTIL.GetWhere(row, "@SEARCH_CON", cond));
                        //sbWhere.Append(" AND PCHECK.WO_NO IS NOT NULL");  //자주검사 내역 없어도 나오게 변경
                        sbWhere.Append(" AND TY.INS_FLAG = 1");
                        //sbWhere.Append(" AND (ISNULL(B.QTY,0) - (ISNULL(YPGO.QTY,0) + ISNULL(CHK_YPGO.QTY,0) + ISNULL(NG_YPGO.QTY,0))) >= 0 ");

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

        public static DataTable TOUT_PROCBALJU_QUERY21(DataTable dtParam, BizExecute.BizExecute bizExecute)
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
                    sbQuery.Append(" ,B.WO_NO");
                    sbQuery.Append(" ,P.PROD_CODE");
                    sbQuery.Append(" ,P.PROD_NAME");
                    sbQuery.Append(" ,W.PART_CODE");
                    sbQuery.Append(" ,PT.PART_NAME");
                    sbQuery.Append(" ,B.DUE_DATE");
                    sbQuery.Append(" ,B.SCOMMENT");
                    sbQuery.Append(" ,B.UNIT_COST");
                    sbQuery.Append(" ,B.AMT");
                    sbQuery.Append(" ,ISNULL(B.QTY, 0) QTY");
                    sbQuery.Append(" ,ISNULL(YP.QTY, 0) AS YPGO_QTY");
                    sbQuery.Append(" ,ISNULL(NG.NG_QTY, 0) NG_QTY");
                    sbQuery.Append(" ,ISNULL(B.QTY, 0) - ISNULL(YP.QTY, 0) - ISNULL(NG.NG_QTY, 0) AS REMAIN_QTY");
                    sbQuery.Append(" ,ISNULL(STK.PART_QTY, 0) AS PART_QTY");
                    sbQuery.Append(" FROM TOUT_PROCBALJU B");
                    sbQuery.Append(" LEFT JOIN TOUT_PROCBALJU_MASTER BM");
                    sbQuery.Append(" ON B.PLT_CODE = BM.PLT_CODE");
                    sbQuery.Append(" AND B.BALJU_NUM = BM.BALJU_NUM");

                    sbQuery.Append(" LEFT JOIN TSHP_WORKORDER W");
                    sbQuery.Append(" ON B.PLT_CODE = W.PLT_CODE");
                    sbQuery.Append(" AND B.WO_NO = W.WO_NO");
                    sbQuery.Append(" LEFT JOIN TORD_PRODUCT P");
                    sbQuery.Append(" ON W.PLT_CODE = P.PLT_CODE");
                    sbQuery.Append(" AND W.PROD_CODE = P.PROD_CODE");
                    sbQuery.Append(" LEFT JOIN LSE_STD_PART PT");
                    sbQuery.Append(" ON W.PLT_CODE = PT.PLT_CODE");
                    sbQuery.Append(" AND W.PART_CODE = PT.PART_CODE");
                    sbQuery.Append(" LEFT JOIN (");
                    sbQuery.Append(" SELECT PLT_CODE, BALJU_NUM, BALJU_SEQ, SUM(QTY) AS QTY FROM TOUT_PROCYPGO WHERE YPGO_STAT IN ('19','31','32') GROUP BY PLT_CODE, BALJU_NUM, BALJU_SEQ)");
                    sbQuery.Append(" YP");
                    sbQuery.Append(" ON B.PLT_CODE = YP.PLT_CODE");
                    sbQuery.Append(" AND B.BALJU_NUM = YP.BALJU_NUM");
                    sbQuery.Append(" AND B.BALJU_SEQ = YP.BALJU_SEQ");
                    sbQuery.Append(" LEFT JOIN (");
                    sbQuery.Append(" SELECT PLT_CODE, BALJU_NUM, BALJU_SEQ, SUM(NG_QTY) AS NG_QTY FROM TQCT_PURCHASE_NG WHERE DATA_FLAG = '0' GROUP BY PLT_CODE, BALJU_NUM, BALJU_SEQ)");
                    sbQuery.Append(" NG");
                    sbQuery.Append(" ON B.PLT_CODE = NG.PLT_CODE");
                    sbQuery.Append(" AND B.BALJU_NUM = NG.BALJU_NUM");
                    sbQuery.Append(" AND B.BALJU_SEQ = NG.BALJU_SEQ");
                    sbQuery.Append(" LEFT JOIN (");
                    sbQuery.Append(" SELECT PLT_CODE, PART_CODE, SUM(PART_QTY) AS PART_QTY FROM TMAT_STOCK GROUP BY PLT_CODE, PART_CODE");
                    sbQuery.Append(" ) STK");
                    sbQuery.Append(" ON W.PLT_CODE = STK.PLT_CODE");
                    sbQuery.Append(" AND W.PART_CODE = STK.PART_CODE");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE B.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                        sbWhere.Append(UTIL.GetWhere(row, "@BAL_STAT", "B.BAL_STAT = @BAL_STAT"));
                        sbWhere.Append(UTIL.GetWhere(row, "@NOT_BAL_STAT", "B.BAL_STAT <> @NOT_BAL_STAT"));
                        sbWhere.Append(UTIL.GetWhere(row, "@NOT_BALJU_NUM", "B.BALJU_NUM <> @NOT_BALJU_NUM"));
                        sbWhere.Append(UTIL.GetWhere(row, "@BALJU_NUM", "B.BALJU_NUM = @BALJU_NUM"));
                        sbWhere.Append(UTIL.GetWhere(row, "@BALJU_SEQ", "B.BALJU_SEQ = @BALJU_SEQ"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_CODE", "W.PART_CODE = @PART_CODE"));

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
