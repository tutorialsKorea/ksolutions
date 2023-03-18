using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace DORD
{
    public class TORD_PROJECT
    {


        public static DataTable TSTD_VENDOR_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {

            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT PLT_CODE ");
                    sbQuery.Append(" , VEN_CODE");
                    sbQuery.Append(" , VEN_NAME");
                    sbQuery.Append(" , VEN_TYPE");
                    sbQuery.Append(" , VEN_CAT_CODE");
                    sbQuery.Append(" , VEN_COUNTRY ");
                    sbQuery.Append(" , VEN_CEO ");
                    sbQuery.Append(" , VEN_BIZ_NO");
                    sbQuery.Append(" , VEN_ID_NO ");
                    sbQuery.Append(" , VEN_START_DATE");
                    sbQuery.Append(" , VEN_BANK");
                    sbQuery.Append(" , VEN_CREDIT");
                    sbQuery.Append(" , VEN_ZIP ");
                    sbQuery.Append(" , VEN_ADDRESS ");
                    sbQuery.Append(" , VEN_TEL ");
                    sbQuery.Append(" , VEN_FAX ");
                    sbQuery.Append(" , VEN_EMAIL ");
                    sbQuery.Append(" , VEN_PRODUCTS");
                    sbQuery.Append(" , VEN_CHARGE_EMP");
                    sbQuery.Append(" , VEN_CHARGE_TEL");
                    sbQuery.Append(" , VEN_CHARGE_HP ");
                    sbQuery.Append(" , VEN_BANK_NO ");
                    sbQuery.Append(" , IS_MYVENDOR ");
                    sbQuery.Append(" , SCOMMENT");
                    sbQuery.Append(" , REG_DATE");
                    sbQuery.Append(" , REG_EMP ");
                    sbQuery.Append(" , MDFY_DATE ");
                    sbQuery.Append(" , MDFY_EMP");
                    sbQuery.Append(" , DEL_DATE");
                    sbQuery.Append(" , DEL_EMP ");
                    sbQuery.Append(" , DEL_REASON");
                    sbQuery.Append(" , DATA_FLAG ");
                    sbQuery.Append(" FROM TSTD_VENDOR");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND VEN_CODE = @VEN_CODE");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "VEN_CODE")) isHasColumn = false;

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

        public static void TSTD_VENDOR_UPD(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" UPDATE TSTD_VENDOR");
                    sbQuery.Append(" SET VEN_NAME = @VEN_NAME");
                    sbQuery.Append(" , VEN_TYPE = @VEN_TYPE");
                    sbQuery.Append(" , VEN_CAT_CODE = @VEN_CAT_CODE");
                    sbQuery.Append(" , VEN_COUNTRY = @VEN_COUNTRY");
                    sbQuery.Append(" , VEN_CEO = @VEN_CEO");
                    sbQuery.Append(" , VEN_BIZ_NO = @VEN_BIZ_NO");
                    sbQuery.Append(" , VEN_ID_NO = @VEN_ID_NO");
                    sbQuery.Append(" , VEN_START_DATE = @VEN_START_DATE");
                    sbQuery.Append(" , VEN_BANK = @VEN_BANK");
                    sbQuery.Append(" , VEN_CREDIT = @VEN_CREDIT");
                    sbQuery.Append(" , VEN_ZIP = @VEN_ZIP");
                    sbQuery.Append(" , VEN_ADDRESS = @VEN_ADDRESS");
                    sbQuery.Append(" , VEN_TEL = @VEN_TEL");
                    sbQuery.Append(" , VEN_FAX = @VEN_FAX");
                    sbQuery.Append(" , VEN_EMAIL = @VEN_EMAIL");
                    sbQuery.Append(" , VEN_PRODUCTS = @VEN_PRODUCTS");
                    sbQuery.Append(" , VEN_CHARGE_EMP = @VEN_CHARGE_EMP");
                    sbQuery.Append(" , VEN_CHARGE_TEL = @VEN_CHARGE_TEL");
                    sbQuery.Append(" , VEN_CHARGE_HP = @VEN_CHARGE_HP");
                    sbQuery.Append(" , VEN_BANK_NO = @VEN_BANK_NO");
                    sbQuery.Append(" , IS_MYVENDOR = @IS_MYVENDOR");
                    sbQuery.Append(" , IF_VEN_CODE = @IF_VEN_CODE");
                    sbQuery.Append(" , SCOMMENT = @SCOMMENT");
                    sbQuery.Append(" , MDFY_DATE = @MDFY_DATE");
                    sbQuery.Append(" , MDFY_EMP = @MDFY_EMP");
                    sbQuery.Append(" , DATA_FLAG = @DATA_FLAG");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND VEN_CODE = @VEN_CODE");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "VEN_CODE")) isHasColumn = false;

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

        public static void TSTD_VENDOR_UDE(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {

                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append("UPDATE TSTD_VENDOR SET");
                    sbQuery.Append("  DEL_REASON = @DEL_REASON");
                    sbQuery.Append("  DEL_DATE = GETDATE()");
                    sbQuery.Append(" , DEL_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" , DATA_FLAG = 2");

                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND VEN_CODE = @VEN_CODE");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "VEN_CODE")) isHasColumn = false;

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

        public static void TSTD_VENDOR_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" INSERT INTO TSTD_VENDOR");
                    sbQuery.Append(" (");
                    sbQuery.Append(" PLT_CODE ");
                    sbQuery.Append(" , VEN_CODE ");
                    sbQuery.Append(" , VEN_NAME ");
                    sbQuery.Append(" , VEN_TYPE ");
                    sbQuery.Append(" , VEN_CAT_CODE ");
                    sbQuery.Append(" , VEN_COUNTRY");
                    sbQuery.Append(" , VEN_CEO");
                    sbQuery.Append(" , VEN_BIZ_NO ");
                    sbQuery.Append(" , VEN_ID_NO");
                    sbQuery.Append(" , VEN_START_DATE ");
                    sbQuery.Append(" , VEN_BANK ");
                    sbQuery.Append(" , VEN_CREDIT ");
                    sbQuery.Append(" , VEN_ZIP");
                    sbQuery.Append(" , VEN_ADDRESS");
                    sbQuery.Append(" , VEN_TEL");
                    sbQuery.Append(" , VEN_FAX");
                    sbQuery.Append(" , VEN_EMAIL");
                    sbQuery.Append(" , VEN_PRODUCTS ");
                    sbQuery.Append(" , VEN_CHARGE_EMP ");
                    sbQuery.Append(" , VEN_CHARGE_TEL ");
                    sbQuery.Append(" , VEN_CHARGE_HP");
                    sbQuery.Append(" , VEN_BANK_NO");
                    sbQuery.Append(" , IS_MYVENDOR");
                    sbQuery.Append(" , IF_VEN_CODE");
                    sbQuery.Append(" , SCOMMENT ");
                    sbQuery.Append(" , REG_DATE ");
                    sbQuery.Append(" , REG_EMP");
                    sbQuery.Append(" , DATA_FLAG");
                    sbQuery.Append(" )");
                    sbQuery.Append(" VALUES ");
                    sbQuery.Append(" (");
                    sbQuery.Append(" @PLT_CODE");
                    sbQuery.Append(" , @VEN_CODE");
                    sbQuery.Append(" , @VEN_NAME");
                    sbQuery.Append(" , @VEN_TYPE");
                    sbQuery.Append(" , @VEN_CAT_CODE");
                    sbQuery.Append(" , @VEN_COUNTRY ");
                    sbQuery.Append(" , @VEN_CEO ");
                    sbQuery.Append(" , @VEN_BIZ_NO");
                    sbQuery.Append(" , @VEN_ID_NO ");
                    sbQuery.Append(" , @VEN_START_DATE");
                    sbQuery.Append(" , @VEN_BANK");
                    sbQuery.Append(" , @VEN_CREDIT");
                    sbQuery.Append(" , @VEN_ZIP ");
                    sbQuery.Append(" , @VEN_ADDRESS ");
                    sbQuery.Append(" , @VEN_TEL ");
                    sbQuery.Append(" , @VEN_FAX ");
                    sbQuery.Append(" , @VEN_EMAIL ");
                    sbQuery.Append(" , @VEN_PRODUCTS");
                    sbQuery.Append(" , @VEN_CHARGE_EMP");
                    sbQuery.Append(" , @VEN_CHARGE_TEL");
                    sbQuery.Append(" , @VEN_CHARGE_HP ");
                    sbQuery.Append(" , @VEN_BANK_NO ");
                    sbQuery.Append(" , @IS_MYVENDOR ");
                    sbQuery.Append(" , @IF_VEN_CODE ");
                    sbQuery.Append(" , @SCOMMENT");
                    sbQuery.Append(" , @REG_DATE");
                    sbQuery.Append(" , @REG_EMP ");
                    sbQuery.Append(" , @DATA_FLAG ");
                    sbQuery.Append(" )");

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


        public static DataTable TORD_PROJECT_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("SELECT   PLT_CODE ");
                    sbQuery.Append("       , PRJ_CODE ");
                    sbQuery.Append("       , PRJ_STATE ");
                    sbQuery.Append("       , PRJ_NAME ");
                    sbQuery.Append("       , REQ_DATE ");
                    sbQuery.Append("       , CVND_CODE ");
                    sbQuery.Append("       , CHARGE_EMP ");
                    sbQuery.Append("       , BUSINESS_EMP ");
                    sbQuery.Append("       , DESIGN_EMP ");
                    sbQuery.Append("       , DEV_GROUP");
                    sbQuery.Append("       , PLN_END_DATE ");
                    sbQuery.Append("       , PRJ_START_DATE ");
                    sbQuery.Append("       , PRJ_END_DATE ");
                    sbQuery.Append("       , SCOMMENT ");
                    sbQuery.Append("       , PROGRESS ");
                    sbQuery.Append("       , IS_CONFIRM ");
                    sbQuery.Append("       , REG_DATE ");
                    sbQuery.Append("       , REG_EMP ");
                    sbQuery.Append("       , MDFY_DATE ");
                    sbQuery.Append("       , MDFY_EMP ");
                    sbQuery.Append("       , DEL_DATE ");
                    sbQuery.Append("       , DEL_EMP ");
                    sbQuery.Append("       , DATA_FLAG ");
                    sbQuery.Append("  FROM TORD_PROJECT ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("   AND PRJ_CODE = @PRJ_CODE");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PRJ_CODE")) isHasColumn = false;

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

        public static void TORD_PROJECT_UPD(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("UPDATE TORD_PROJECT ");
                    sbQuery.Append("   SET   PRJ_STATE = @PRJ_STATE ");
                    sbQuery.Append("       , PRJ_NAME = @PRJ_NAME ");
                    sbQuery.Append("       , REQ_DATE = @REQ_DATE ");
                    sbQuery.Append("       , CVND_CODE = @CVND_CODE ");
                    sbQuery.Append("       , CHARGE_EMP = @CHARGE_EMP ");
                    sbQuery.Append("       , BUSINESS_EMP = @BUSINESS_EMP ");
                    sbQuery.Append("       , DESIGN_EMP = @DESIGN_EMP ");
                    sbQuery.Append("       , DEV_GROUP = @DEV_GROUP ");
                    sbQuery.Append("       , PLN_END_DATE = @PLN_END_DATE ");
                    sbQuery.Append("       , PRJ_START_DATE = @PRJ_START_DATE ");
                    sbQuery.Append("       , PRJ_END_DATE = @PRJ_END_DATE ");
                    sbQuery.Append("       , SCOMMENT = @SCOMMENT ");
                    sbQuery.Append("       , PROGRESS = @PROGRESS ");
                    sbQuery.Append("       , IS_CONFIRM = @IS_CONFIRM ");
                    sbQuery.Append("       , MDFY_DATE = GETDATE() ");
                    sbQuery.Append("       , MDFY_EMP = @MDFY_EMP ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("   AND PRJ_CODE = @PRJ_CODE ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크                        
                        if (!UTIL.ValidColumn(row, "PRJ_CODE")) isHasColumn = false;

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

        public static void TORD_PROJECT_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();


                    sbQuery.Append("INSERT INTO TORD_PROJECT ");
                    sbQuery.Append("( ");
                    sbQuery.Append("         PLT_CODE ");
                    sbQuery.Append("       , PRJ_CODE ");
                    sbQuery.Append("       , PRJ_STATE ");
                    sbQuery.Append("       , PRJ_NAME ");
                    sbQuery.Append("       , REQ_DATE ");
                    sbQuery.Append("       , CVND_CODE ");
                    sbQuery.Append("       , CHARGE_EMP ");
                    sbQuery.Append("       , BUSINESS_EMP ");
                    sbQuery.Append("       , DESIGN_EMP ");
                    sbQuery.Append("       , DEV_GROUP");
                    sbQuery.Append("       , PLN_END_DATE ");
                    sbQuery.Append("       , PRJ_START_DATE ");
                    sbQuery.Append("       , PRJ_END_DATE ");
                    sbQuery.Append("       , SCOMMENT ");
                    sbQuery.Append("       , PROGRESS ");
                    sbQuery.Append("       , IS_CONFIRM ");
                    sbQuery.Append("       , REG_DATE ");
                    sbQuery.Append("       , REG_EMP ");
                    sbQuery.Append("       , DATA_FLAG ");
                    sbQuery.Append(") ");
                    sbQuery.Append("VALUES ");
                    sbQuery.Append("( ");
                    sbQuery.Append("         @PLT_CODE ");
                    sbQuery.Append("       , @PRJ_CODE ");
                    sbQuery.Append("       , @PRJ_STATE ");
                    sbQuery.Append("       , @PRJ_NAME ");
                    sbQuery.Append("       , @REQ_DATE ");
                    sbQuery.Append("       , @CVND_CODE ");
                    sbQuery.Append("       , @CHARGE_EMP ");
                    sbQuery.Append("       , @BUSINESS_EMP ");
                    sbQuery.Append("       , @DESIGN_EMP ");
                    sbQuery.Append("       , @DEV_GROUP");
                    sbQuery.Append("       , @PLN_END_DATE ");
                    sbQuery.Append("       , @PRJ_START_DATE ");
                    sbQuery.Append("       , @PRJ_END_DATE ");
                    sbQuery.Append("       , @SCOMMENT ");
                    sbQuery.Append("       , @PROGRESS ");
                    sbQuery.Append("       , @IS_CONFIRM ");
                    sbQuery.Append("       , GETDATE() ");
                    sbQuery.Append("       , @REG_EMP ");
                    sbQuery.Append("       , 0 ");
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

        public static void TORD_PROJECT_UDE(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("UPDATE TORD_PROJECT ");
                    sbQuery.Append("  SET   DEL_DATE = GETDATE() ");
                    sbQuery.Append("      , DEL_EMP = @DEL_EMP ");
                    sbQuery.Append("      , DATA_FLAG = 2 ");
                    sbQuery.Append("WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("  AND PRJ_CODE = @PRJ_CODE ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크                        
                        if (!UTIL.ValidColumn(row, "PRJ_CODE")) isHasColumn = false;

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

    public class TORD_PROJECT_QUERY
    {
        /// <summary>
        /// 프로젝트 진행 이력 조회 
        /// </summary>
        /// <param name="dtParam"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataTable TORD_PROJECT_QUERY1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("SELECT   PLT_CODE ");
                    sbQuery.Append("       , PRJ_CODE ");
                    sbQuery.Append("       , PRJ_STATE ");
                    sbQuery.Append("       , PRJ_NAME ");
                    sbQuery.Append("       , REQ_DATE ");
                    sbQuery.Append("       , CVND_CODE ");
                    sbQuery.Append("       , CHARGE_EMP ");
                    sbQuery.Append("       , PROGRESS ");
                    sbQuery.Append("       , BUSINESS_EMP ");
                    sbQuery.Append("       , DESIGN_EMP ");
                    sbQuery.Append("       , DEV_GROUP");
                    sbQuery.Append("       , PLN_END_DATE ");
                    sbQuery.Append("       , PRJ_START_DATE ");
                    sbQuery.Append("       , PRJ_END_DATE ");
                    sbQuery.Append("       , SCOMMENT ");
                    sbQuery.Append("       , IS_CONFIRM ");
                    sbQuery.Append("       , REG_DATE ");
                    sbQuery.Append("       , REG_EMP ");
                    sbQuery.Append("       , MDFY_DATE ");
                    sbQuery.Append("       , MDFY_EMP ");
                    sbQuery.Append("       , DEL_DATE ");
                    sbQuery.Append("       , DEL_EMP ");
                    sbQuery.Append("       , DATA_FLAG ");
                    sbQuery.Append("  FROM TORD_PROJECT ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;

                        if (isHasColumn == true)
                        {
                            StringBuilder sbWhere = new StringBuilder();

                            sbWhere.Append(" WHERE DATA_FLAG = 0 ");

                            sbWhere.Append(UTIL.GetWhere(row, "@PLT_CODE", " PLT_CODE = @PLT_CODE"));
                            // sbWhere.Append(UTIL.GetWhere(row, "@EMP_CODE", " REG_EMP = @EMP_CODE"));
                            sbWhere.Append(UTIL.GetWhere(row, "@PRJ_LIKE", "PRJ_NAME LIKE '%' + @PRJ_LIKE + '%' "));
                            sbWhere.Append(UTIL.GetWhere(row, "@PRJ_STATE", "PRJ_STATE = @PRJ_STATE "));
                            sbWhere.Append(UTIL.GetWhere(row, "@S_REQ_DATE, @E_REQ_DATE", " REQ_DATE BETWEEN @S_REQ_DATE AND @E_REQ_DATE ")); // 고객요청
                            sbWhere.Append(UTIL.GetWhere(row, "@S_PRJ_START_DATE, @E_PRJ_START_DATE", " PRJ_START_DATE BETWEEN @S_PRJ_START_DATE AND @E_PRJ_START_DATE ")); //프로젝트 시작일
                            sbWhere.Append(UTIL.GetWhere(row, "@S_PLN_END_DATE, @E_PLN_END_DATE", " PLN_END_DATE BETWEEN @S_PLN_END_DATE AND @E_PLN_END_DATE "));  // 완료예정일
                            sbWhere.Append(UTIL.GetWhere(row, "@S_PRJ_END_DATE, @E_PRJ_END_DATE", " PRJ_END_DATE BETWEEN @S_PRJ_END_DATE AND @E_PRJ_END_DATE "));  // 프로젝트 완료일

                            sbWhere.Append(" ORDER BY REQ_DATE DESC ");

                            DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString() + sbWhere.ToString()).Copy();

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


        //공통 컨트롤 거래처 검색
        public static DataTable TORD_PROJECT_QUERY2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    
                    sbQuery.Append("       SELECT P.PLT_CODE ");
                    sbQuery.Append("       ,P.PRJ_CODE ");
                    sbQuery.Append("       ,P.PRJ_NAME ");
                    sbQuery.Append("       ,P.CVND_CODE ");
                    sbQuery.Append("       ,CVND_NAME = V.VEN_NAME ");
                    sbQuery.Append("       ,P.SCOMMENT ");
                    sbQuery.Append("       ,P.REG_DATE ");
                    sbQuery.Append("       ,P.REG_EMP ");
                    sbQuery.Append("       ,REG.EMP_NAME AS REG_EMP_NAME ");
                    sbQuery.Append("       ,P.MDFY_DATE ");
                    sbQuery.Append("       ,P.MDFY_EMP ");
                    sbQuery.Append("       ,MDFY.EMP_NAME AS MDFY_EMP_NAME ");
                    sbQuery.Append("   FROM TORD_PROJECT P ");
                    sbQuery.Append(" LEFT JOIN TSTD_VENDOR V  ");
                    sbQuery.Append(" ON P.PLT_CODE = V.PLT_CODE  ");
                    sbQuery.Append(" AND P.CVND_CODE = V.VEN_CODE ");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE REG ");
                    sbQuery.Append(" ON P.PLT_CODE = REG.PLT_CODE ");
                    sbQuery.Append(" AND P.REG_EMP = REG.EMP_CODE ");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE MDFY ");
                    sbQuery.Append(" ON P.PLT_CODE = MDFY.PLT_CODE ");
                    sbQuery.Append(" AND P.MDFY_EMP = MDFY.EMP_CODE ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder();

                        sbWhere.Append(" WHERE P.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@PRJ_CODE", "P.PRJ_CODE = @PRJ_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "DATA_FLAG = @DATA_FLAG"));
                        sbWhere.Append(UTIL.GetWhere(row, "@CVND_CODE", "P.CVND_CODE = @CVND_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PRJ_LIKE", "(P.PRJ_CODE LIKE '%' + @PRJ_LIKE + '%' OR P.PRJ_NAME LIKE '%' + @PRJ_LIKE + '%')"));
                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "P.DATA_FLAG = @DATA_FLAG"));

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
