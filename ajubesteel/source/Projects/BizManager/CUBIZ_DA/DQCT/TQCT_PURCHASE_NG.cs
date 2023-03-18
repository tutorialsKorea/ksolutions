using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace DQCT
{
    public class TQCT_PURCHASE_NG
    {
        public static DataTable TQCT_PURCHASE_NG_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT PLT_CODE ");
                    sbQuery.Append("      , NG_ID ");
                    
                    sbQuery.Append("      , MASTER_CAUSE ");
                    sbQuery.Append("      , DETAIL_CAUSE ");
                    sbQuery.Append("      , NG_QTY ");
                    
                    sbQuery.Append("      , NG_STATE ");
                    sbQuery.Append("      , NG_MAT_COST  ");
                    sbQuery.Append("      , NG_OTHER_OUT_COST ");
                    sbQuery.Append("      , NG_PROC_COST  ");
                    sbQuery.Append("      , NG_THIS_OUT_COST  ");
                    sbQuery.Append("      , NG_PRE_COST  ");
                    sbQuery.Append("      , NG_COST ");
                    sbQuery.Append("      , NG_CONTENTS ");
                    sbQuery.Append("      , NG_CAUSE ");
                    sbQuery.Append("      , NG_MEASURE ");
                    sbQuery.Append("      , REG_DATE ");
                    sbQuery.Append("      , REG_EMP ");
                    sbQuery.Append("      , MDFY_DATE ");
                    sbQuery.Append("      , MDFY_EMP ");
                    sbQuery.Append("   FROM TQCT_PURCHASE_NG ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("    AND NG_ID = @NG_ID  ");
                    sbQuery.Append("    AND DATA_FLAG = 0  ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "NG_ID")) isHasColumn = false;

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

        public static void TQCT_PURCHASE_NG_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();


                    sbQuery.Append(" INSERT INTO TQCT_PURCHASE_NG ");
                    sbQuery.Append(" ( ");
                    sbQuery.Append("        PLT_CODE ");
                    sbQuery.Append("      , NG_ID ");
                    sbQuery.Append("      , BALJU_NUM ");
                    sbQuery.Append("      , BALJU_SEQ ");
                    sbQuery.Append("      , INS_DATE ");
                    sbQuery.Append("      , MASTER_CAUSE ");
                    sbQuery.Append("      , DETAIL_CAUSE ");
                    sbQuery.Append("      , NG_QTY ");
                    sbQuery.Append("      , NG_CONTENTS ");
                    sbQuery.Append("      , NG_STATE ");
                    sbQuery.Append("      , REG_DATE ");
                    sbQuery.Append("      , REG_EMP ");
                    sbQuery.Append("      , DATA_FLAG ");
                    sbQuery.Append(" ) ");
                    sbQuery.Append(" VALUES ");
                    sbQuery.Append(" ( ");
                    sbQuery.Append("        @PLT_CODE ");
                    sbQuery.Append("      , @NG_ID ");
                    sbQuery.Append("      , @BALJU_NUM ");
                    sbQuery.Append("      , @BALJU_SEQ ");
                    sbQuery.Append("      , @INS_DATE ");
                    sbQuery.Append("      , @MASTER_CAUSE ");
                    sbQuery.Append("      , @DETAIL_CAUSE ");
                    sbQuery.Append("      , @NG_QTY ");
                    sbQuery.Append("      , @NG_CONTENTS ");
                    sbQuery.Append("      , @NG_STATE ");
                    sbQuery.Append("      , GETDATE() ");
                    sbQuery.Append(" ," + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" , 0 ");
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
        public static void TQCT_PURCHASE_NG_UPD(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" UPDATE TQCT_PURCHASE_NG ");
                    sbQuery.Append("    SET   MASTER_CAUSE = @MASTER_CAUSE ");
                    sbQuery.Append("      , DETAIL_CAUSE = @DETAIL_CAUSE ");
                    sbQuery.Append("      , NG_QTY = @NG_QTY ");
                    sbQuery.Append("      , NG_CONTENTS = @NG_CONTENTS ");

                    //sbQuery.Append("      , NG_TYPE = @NG_TYPE ");
                    //sbQuery.Append("      , NG_STATE = @NG_STATE ");
                    //sbQuery.Append("      , NG_CAUSE = @NG_CAUSE ");
                    //sbQuery.Append("      , NG_MEASURE = @NG_MEASURE ");
                    //sbQuery.Append("      , NG_MAT_COST  = @NG_MAT_COST  ");
                    //sbQuery.Append("      , NG_OTHER_OUT_COST = @NG_OTHER_OUT_COST ");
                    //sbQuery.Append("      , NG_PROC_COST  = @NG_PROC_COST  ");
                    //sbQuery.Append("      , NG_THIS_OUT_COST  = @NG_THIS_OUT_COST  ");
                    //sbQuery.Append("      , NG_PRE_COST  = @NG_PRE_COST  ");
                    //sbQuery.Append("      , NG_COST  = @NG_COST  ");
                    sbQuery.Append("        , MDFY_DATE =  GETDATE() ");
                    sbQuery.Append("        , MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("    AND NG_ID = @NG_ID  ");
                                        
                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "NG_ID")) isHasColumn = false;

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

        public static void TQCT_PURCHASE_NG_UPD2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" UPDATE TQCT_PURCHASE_NG ");
                    sbQuery.Append("    SET   NG_PROD_CODE = @NG_PROD_CODE ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("    AND NG_ID = @NG_ID  ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "NG_ID")) isHasColumn = false;

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

        public static void TQCT_PURCHASE_NG_UPD3(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" UPDATE TQCT_PURCHASE_NG ");
                    sbQuery.Append("    SET   NG_STATE = @NG_STATE ");
                    sbQuery.Append("        , MDFY_DATE =  GETDATE() ");
                    sbQuery.Append("        , MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("    AND NG_ID = @NG_ID  ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "NG_ID")) isHasColumn = false;

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

        public static void TQCT_PURCHASE_NG_UPD4(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TQCT_PURCHASE_NG ");
                    sbQuery.Append("    SET   MASTER_CAUSE = @MASTER_CAUSE ");
                    sbQuery.Append("      , NG_STATE = @NG_STATE ");
                    sbQuery.Append("      , NG_CONTENTS = @NG_CONTENTS ");
                    sbQuery.Append("      , NG_CAUSE = @NG_CAUSE ");
                    sbQuery.Append("      , NG_MEASURE = @NG_MEASURE ");
                    sbQuery.Append("      , NG_MAT_COST  = @NG_MAT_COST  ");
                    sbQuery.Append("      , MDFY_DATE =  GETDATE() ");
                    sbQuery.Append("      , MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("    AND NG_ID = @NG_ID  ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "NG_ID")) isHasColumn = false;

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


        public static void TQCT_PURCHASE_NG_UDE(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" UPDATE TQCT_PURCHASE_NG ");
                    sbQuery.Append(" SET DATA_FLAG = 2 ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("    AND NG_ID = @NG_ID  ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "NG_ID")) isHasColumn = false;

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

        public static void TQCT_PURCHASE_NG_DEL(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" DELETE FROM TQCT_PURCHASE_NG ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("    AND NG_ID = @NG_ID  ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "NG_ID")) isHasColumn = false;

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



    public class TQCT_PURCHASE_NG_QUERY
    {
        public static DataTable TQCT_PURCHASE_NG_QUERY1(DataTable dtParam, BizExecute.BizExecute bizExecute)
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
                    sbQuery.Append(" ,B.BAL_STAT");
                    sbQuery.Append(" ,BM.BALJU_DATE");
                    sbQuery.Append(" ,B.DUE_DATE");
                    sbQuery.Append(" ,BM.OVND_CODE AS VND_CODE");
                    sbQuery.Append(" ,B.REG_EMP");
                    sbQuery.Append(" ,P.PROD_CODE");
                    sbQuery.Append(" ,P.PROD_NAME");
                    sbQuery.Append(" ,P.ORD_DATE");
                    sbQuery.Append(" ,P.DUE_DATE AS ORD_DUE_DATE");
                    sbQuery.Append(" ,P.CHG_DUE_DATE");
                    sbQuery.Append(" ,TW.PART_CODE");
                    sbQuery.Append(" ,SP.PART_NAME");
                    sbQuery.Append(" ,SP.MAT_LTYPE");
                    sbQuery.Append(" ,SP.MAT_MTYPE");
                    sbQuery.Append(" ,SP.MAT_STYPE");
                    sbQuery.Append(" ,SP.PART_PRODTYPE");
                    sbQuery.Append(" ,SP.MAT_UNIT");
                    sbQuery.Append(" ,B.UNIT_COST");
                    sbQuery.Append(" ,B.QTY");
                    sbQuery.Append(" ,B.INS_DATE");
                    sbQuery.Append(" ,ISNULL(N.NG_QTY, 0) AS NG_QTY ");
                    sbQuery.Append(" ,B.OK_QTY");
                    sbQuery.Append(" ,N.MASTER_CAUSE");
                    sbQuery.Append(" ,N.DETAIL_CAUSE");
                    sbQuery.Append(" ,N.NG_CONTENTS");
                    sbQuery.Append(" ,B.QTY AS INS_QTY");
                    sbQuery.Append(" ,B.AMT");
                    sbQuery.Append(" ,B.SCOMMENT");
                    sbQuery.Append(" ,TW.WO_NO");
                    sbQuery.Append(" ,TW.PROC_CODE");
                    sbQuery.Append(" ,N.NG_ID");
                    sbQuery.Append(" FROM TOUT_PROCBALJU B");
                    sbQuery.Append(" LEFT JOIN TQCT_PURCHASE_NG N");
                    sbQuery.Append(" ON B.BALJU_NUM = N.BALJU_NUM");
                    sbQuery.Append(" AND B.BALJU_SEQ = N.BALJU_SEQ");
                    sbQuery.Append(" AND N.DATA_FLAG = 0 ");
                    sbQuery.Append(" AND ISNULL(N.NG_STATE, '') <> 'C'");
                    //sbQuery.Append(" FROM TQCT_PURCHASE_NG N");
                    //sbQuery.Append(" JOIN TOUT_PROCYPGO Y");
                    //sbQuery.Append(" ON N.PLT_CODE = Y.PLT_CODE");
                    //sbQuery.Append(" AND N.YPGO_ID = Y.YPGO_ID");
                    //sbQuery.Append(" JOIN TOUT_PROCBALJU B");

                    sbQuery.Append(" LEFT JOIN TOUT_PROCBALJU_MASTER BM");
                    sbQuery.Append("   ON B.PLT_CODE = BM.PLT_CODE");
                    sbQuery.Append("  AND B.BALJU_NUM = BM.BALJU_NUM");
                    sbQuery.Append(" LEFT JOIN TSHP_WORKORDER TW");
                    sbQuery.Append("   ON TW.PLT_CODE = B.PLT_CODE");
                    sbQuery.Append("  AND TW.WO_NO = B.WO_NO");
                    sbQuery.Append(" LEFT JOIN TORD_PRODUCT P");
                    sbQuery.Append("   ON TW.PLT_CODE = P.PLT_CODE");
                    sbQuery.Append("  AND TW.PROD_CODE = P.PROD_CODE");
                    sbQuery.Append(" LEFT JOIN LSE_STD_PART SP");
                    sbQuery.Append("   ON TW.PLT_CODE = SP.PLT_CODE ");
                    sbQuery.Append("  AND TW.PART_CODE = SP.PART_CODE");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder();

                        sbWhere.Append(" WHERE B.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@S_INS_DATE,@E_INS_DATE", "B.INS_DATE BETWEEN @S_INS_DATE AND @E_INS_DATE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@BAL_STAT", "B.BAL_STAT = @BAL_STAT"));

                        sbWhere.Append(UTIL.GetWhere(row, "@PART_LIKE", "R.PART_CODE LIKE '%' + @PART_LIKE + '%' OR PART.PART_NAME LIKE '%' + @PART_LIKE + '%'"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PROC_CODE", "R.PROC_CODE = @PROC_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@MPROC_CODE", "PR.MPROC_CODE = @MPROC_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_CODE", "R.PART_CODE = @PART_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@NG_ID", "NG.NG_ID = @NG_ID"));
                        sbWhere.Append(UTIL.GetWhere(row, "@BALJU_NUM", "B.BALJU_NUM = @BALJU_NUM"));
                        sbWhere.Append(UTIL.GetWhere(row, "@BALJU_SEQ", "B.BALJU_SEQ = @BALJU_SEQ"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PUR06A", "(B.BAL_STAT IN ('21','22','23','43') AND B.INS_FLAG = '2')"));


                        sbWhere.Append("    ");

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

        public static DataTable TQCT_PURCHASE_NG_QUERY5(DataTable dtParam, BizExecute.BizExecute bizExecute)
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
                    sbQuery.Append(" ,'' AS WO_NO");
                    sbQuery.Append(" ,B.BAL_STAT");
                    sbQuery.Append(" ,BM.BALJU_DATE");
                    sbQuery.Append(" ,B.DUE_DATE");
                    sbQuery.Append(" ,BM.MVND_CODE AS VND_CODE");
                    sbQuery.Append(" ,B.REG_EMP");
                    sbQuery.Append(" , '' AS PROD_CODE");
                    sbQuery.Append(" , '' AS PROD_NAME");
                    sbQuery.Append(" ,B.PART_CODE");
                    sbQuery.Append(" ,SP.PART_NAME");
                    sbQuery.Append(" ,SP.MAT_LTYPE");
                    sbQuery.Append(" ,SP.MAT_MTYPE");
                    sbQuery.Append(" ,SP.MAT_STYPE");
                    sbQuery.Append(" ,SP.PART_PRODTYPE");
                    sbQuery.Append(" ,SP.MAT_UNIT");
                    sbQuery.Append(" ,B.UNIT_COST");
                    sbQuery.Append(" ,B.QTY");
                    sbQuery.Append(" ,B.INS_DATE");
                    sbQuery.Append(" ,ISNULL(N.NG_QTY, 0) AS NG_QTY ");
                    sbQuery.Append(" ,B.OK_QTY");
                    sbQuery.Append(" ,N.MASTER_CAUSE");
                    sbQuery.Append(" ,N.DETAIL_CAUSE");
                    sbQuery.Append(" ,N.NG_CONTENTS");
                    sbQuery.Append(" ,B.QTY AS INS_QTY");
                    sbQuery.Append(" ,B.AMT");
                    sbQuery.Append(" ,B.SCOMMENT");
                    sbQuery.Append(" ,N.NG_ID");

                    sbQuery.Append(" FROM TMAT_BALJU B");
                    sbQuery.Append(" LEFT JOIN TQCT_PURCHASE_NG N");
                    sbQuery.Append(" ON B.BALJU_NUM = N.BALJU_NUM");
                    sbQuery.Append(" AND B.BALJU_SEQ = N.BALJU_SEQ");
                    sbQuery.Append(" AND N.DATA_FLAG = 0 ");
                    sbQuery.Append(" AND ISNULL(N.NG_STATE, '') <> 'C'");

                    sbQuery.Append(" LEFT JOIN TMAT_BALJU_MASTER BM");
                    sbQuery.Append("   ON B.PLT_CODE = BM.PLT_CODE");
                    sbQuery.Append("  AND B.BALJU_NUM = BM.BALJU_NUM");
                    
                    sbQuery.Append(" LEFT JOIN LSE_STD_PART SP");
                    sbQuery.Append("   ON B.PLT_CODE = SP.PLT_CODE ");
                    sbQuery.Append("  AND B.PART_CODE = SP.PART_CODE");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder();

                        sbWhere.Append(" WHERE B.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@S_INS_DATE,@E_INS_DATE", "B.INS_DATE BETWEEN @S_INS_DATE AND @E_INS_DATE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@BAL_STAT", "B.BAL_STAT = @BAL_STAT"));

                        sbWhere.Append(UTIL.GetWhere(row, "@PART_LIKE", "B.PART_CODE LIKE '%' + @PART_LIKE + '%' OR SP.PART_NAME LIKE '%' + @PART_LIKE + '%'"));
                        
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_CODE", "B.PART_CODE = @PART_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@NG_ID", "NG.NG_ID = @NG_ID"));
                        sbWhere.Append(UTIL.GetWhere(row, "@BALJU_NUM", "B.BALJU_NUM = @BALJU_NUM"));
                        sbWhere.Append(UTIL.GetWhere(row, "@BALJU_SEQ", "B.BALJU_SEQ = @BALJU_SEQ"));

                        sbWhere.Append(UTIL.GetWhere(row, "@PUR06A", "(B.BAL_STAT IN ('21','22','23','43') AND B.INS_FLAG = '2')"));

                        sbWhere.Append("    ");

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
        public static DataTable TQCT_PURCHASE_NG_QUERY2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT PLT_CODE							");
                    sbQuery.Append("      , NG_COST_CODE AS GUBUN  ");
                    sbQuery.Append("      , SUBSTRING(CHECK_DATE,5,2) as MONTH  ");
                    sbQuery.Append("      , NG_COST AS COST ");
                    sbQuery.Append("   FROM TQCT_PURCHASE_NG					");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder();

                        sbWhere.Append(" WHERE PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append("  AND DATA_FLAG = 0  ");
                        sbWhere.Append(UTIL.GetWhere(row, "@YEAR", "LEFT(CHECK_DATE,4) = @YEAR"));

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

        public static DataTable TQCT_PURCHASE_NG_QUERY3(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT PLT_CODE							");
                    sbQuery.Append("      , MASTER_CAUSE  ");
                    sbQuery.Append("      , DETAIL_CAUSE  ");
                    sbQuery.Append("      , SUM(ISNULL(NG_QTY,0)) AS TOT_QTY    ");
                    sbQuery.Append("   FROM TQCT_PURCHASE_NG					");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder();

                        sbWhere.Append(" WHERE PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@S_WORK_DATE,@E_WORK_DATE", "(CHECK_DATE BETWEEN @S_WORK_DATE AND @E_WORK_DATE)"));
                        sbWhere.Append("  AND DATA_FLAG = 0  ");
                        sbWhere.Append("  GROUP BY PLT_CODE  ");
                        sbWhere.Append("  	 , MASTER_CAUSE  ");
                        sbWhere.Append("  	 , DETAIL_CAUSE  ");

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

        public static DataTable TQCT_PURCHASE_NG_QUERY4(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT NG.PLT_CODE	");
                    sbQuery.Append(" 	, BAL.OVND_CODE AS VEN_CODE    ");
                    sbQuery.Append(" 	, SUM(ISNULL(NG.NG_QTY,0)) AS TOT_QTY    ");
                    sbQuery.Append(" 	, SUM(ISNULL(NG.NG_COST ,0)) AS TOT_COST   ");
                    sbQuery.Append("   FROM TQCT_PURCHASE_NG NG	");
                    sbQuery.Append(" 	INNER JOIN TOUT_TEMP_YPGO YPGO	");
                    sbQuery.Append(" 		ON NG.PLT_CODE = YPGO.PLT_CODE	");
                    sbQuery.Append(" 		AND NG.TYP_ID = YPGO.TYP_ID	");
                    sbQuery.Append(" 	INNER JOIN TOUT_PROCBALJU_MASTER BAL	");
                    sbQuery.Append(" 		ON YPGO.PLT_CODE = BAL.PLT_CODE	");
                    sbQuery.Append(" 		AND YPGO.BALJU_NUM = BAL.BALJU_NUM	");
                    
                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder();

                        sbWhere.Append(" WHERE NG.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@S_WORK_DATE,@E_WORK_DATE", "(NG.CHECK_DATE BETWEEN @S_WORK_DATE AND @E_WORK_DATE)"));
                        sbWhere.Append("  AND NG.DATA_FLAG = 0  ");
                        sbWhere.Append("  GROUP BY NG.PLT_CODE  ");
                        sbWhere.Append("  	 , BAL.OVND_CODE  ");

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
