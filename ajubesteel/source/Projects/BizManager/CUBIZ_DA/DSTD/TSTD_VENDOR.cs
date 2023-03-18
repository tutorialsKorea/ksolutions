using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace DSTD
{
    public class TSTD_VENDOR
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
                    sbQuery.Append(" , VEN_ACCOUNT ");
                    sbQuery.Append(" , VEN_CEO ");
                    sbQuery.Append(" , VEN_BIZ_NO");
                    sbQuery.Append(" , VEN_CONDITIONS");
                    sbQuery.Append(" , VEN_ID_NO ");
                    sbQuery.Append(" , VEN_START_DATE");
                    sbQuery.Append(" , VEN_BANK");
                    sbQuery.Append(" , VEN_CREDIT");
                    sbQuery.Append(" , VEN_ZIP ");
                    sbQuery.Append(" , VEN_ADDRESS ");
                    sbQuery.Append(" , VEN_ZIP2 ");
                    sbQuery.Append(" , VEN_ADDRESS2 ");
                    sbQuery.Append(" , VEN_ZIP3 ");
                    sbQuery.Append(" , VEN_ADDRESS3 ");
                    sbQuery.Append(" , VEN_TEL ");
                    sbQuery.Append(" , VEN_FAX ");
                    sbQuery.Append(" , VEN_EMAIL ");
                    sbQuery.Append(" , VEN_PRODUCTS");
                    sbQuery.Append(" , VEN_CHARGE_EMP");
                    sbQuery.Append(" , VEN_CHARGE_TEL");
                    sbQuery.Append(" , VEN_CHARGE_HP ");
                    sbQuery.Append(" , VEN_BANK_NO ");

                    sbQuery.Append(" , ENG_VEN_NAME");
                    sbQuery.Append(" , ENG_VEN_ADDR");
                    sbQuery.Append(" , ENG_VEN_ADDR2");

                    sbQuery.Append(" , VEN_HOMEPAGE ");
                    sbQuery.Append(" , VEN_PAYMENT ");
                    sbQuery.Append(" , VEN_DEADLINE ");
                    sbQuery.Append(" , VEN_TAX ");

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
                    sbQuery.Append(" , ITEM_AUTO_CODE ");
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
                            DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString(),row).Copy();

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


        // 사업자등록번호 중복조회
        public static DataTable TSTD_VENDOR_SER2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {

            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT PLT_CODE ");
                    sbQuery.Append(" , VEN_CODE");
                    sbQuery.Append(" , VEN_BIZ_NO");
                    sbQuery.Append(" FROM TSTD_VENDOR");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND VEN_BIZ_NO = @VEN_BIZ_NO");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "VEN_BIZ_NO")) isHasColumn = false;

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
                    sbQuery.Append(" , VEN_CONDITIONS = @VEN_CONDITIONS");
                    sbQuery.Append(" , VEN_COUNTRY = @VEN_COUNTRY");
                    sbQuery.Append(" , VEN_ACCOUNT = @VEN_ACCOUNT");
                    sbQuery.Append(" , VEN_CEO = @VEN_CEO");
                    sbQuery.Append(" , VEN_BIZ_NO = @VEN_BIZ_NO");
                    sbQuery.Append(" , VEN_ID_NO = @VEN_ID_NO");
                    sbQuery.Append(" , VEN_START_DATE = @VEN_START_DATE");
                    sbQuery.Append(" , VEN_BANK = @VEN_BANK");
                    sbQuery.Append(" , VEN_CREDIT = @VEN_CREDIT");
                    sbQuery.Append(" , VEN_ZIP = @VEN_ZIP");
                    sbQuery.Append(" , VEN_ADDRESS = @VEN_ADDRESS");
                    sbQuery.Append(" , VEN_ZIP2 = @VEN_ZIP2");
                    sbQuery.Append(" , VEN_ADDRESS2 = @VEN_ADDRESS2");
                    sbQuery.Append(" , VEN_ZIP3 = @VEN_ZIP3");
                    sbQuery.Append(" , VEN_ADDRESS3 = @VEN_ADDRESS3");
                    sbQuery.Append(" , VEN_TEL = @VEN_TEL");
                    sbQuery.Append(" , VEN_FAX = @VEN_FAX");
                    sbQuery.Append(" , VEN_EMAIL = @VEN_EMAIL");
                    sbQuery.Append(" , VEN_EMAIL_CC = @VEN_EMAIL_CC");
                    sbQuery.Append(" , VEN_PRODUCTS = @VEN_PRODUCTS");
                    sbQuery.Append(" , VEN_CHARGE_EMP = @VEN_CHARGE_EMP");
                    sbQuery.Append(" , VEN_CHARGE_TEL = @VEN_CHARGE_TEL");
                    sbQuery.Append(" , VEN_CHARGE_HP = @VEN_CHARGE_HP");
                    sbQuery.Append(" , VEN_BANK_NO = @VEN_BANK_NO");
                    sbQuery.Append(" , IS_MYVENDOR = @IS_MYVENDOR");
                    sbQuery.Append(" , USE_GLOBAL = @USE_GLOBAL");

                    sbQuery.Append(" , ENG_VEN_NAME = @ENG_VEN_NAME");
                    sbQuery.Append(" , ENG_VEN_ADDR = @ENG_VEN_ADDR");
                    sbQuery.Append(" , ENG_VEN_ADDR2 = @ENG_VEN_ADDR2");

                    sbQuery.Append(" , VEN_HOMEPAGE = @VEN_HOMEPAGE");
                    sbQuery.Append(" , VEN_PAYMENT = @VEN_PAYMENT");
                    sbQuery.Append(" , VEN_DEADLINE = @VEN_DEADLINE");
                    sbQuery.Append(" , VEN_TAX = @VEN_TAX");

                    sbQuery.Append(" , IF_VEN_CODE = @IF_VEN_CODE");
                    sbQuery.Append(" , SCOMMENT = @SCOMMENT");
                    sbQuery.Append(" , MDFY_DATE = GETDATE()");
                    sbQuery.Append(" , MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" , DATA_FLAG = 0");
                    sbQuery.Append(" , ITEM_AUTO_CODE = @ITEM_AUTO_CODE");
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
                    sbQuery.Append(" , DEL_DATE = GETDATE()");
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
                    sbQuery.Append(" , VEN_CONDITIONS ");
                    sbQuery.Append(" , VEN_COUNTRY");
                    sbQuery.Append(" , VEN_ACCOUNT");
                    sbQuery.Append(" , VEN_CEO");
                    sbQuery.Append(" , VEN_BIZ_NO ");
                    sbQuery.Append(" , VEN_ID_NO");
                    sbQuery.Append(" , VEN_START_DATE ");
                    sbQuery.Append(" , VEN_BANK ");
                    sbQuery.Append(" , VEN_CREDIT ");
                    sbQuery.Append(" , VEN_ZIP");
                    sbQuery.Append(" , VEN_ADDRESS");
                    sbQuery.Append(" , VEN_ZIP2");
                    sbQuery.Append(" , VEN_ADDRESS2");
                    sbQuery.Append(" , VEN_ZIP3");
                    sbQuery.Append(" , VEN_ADDRESS3");
                    sbQuery.Append(" , VEN_TEL");
                    sbQuery.Append(" , VEN_FAX");
                    sbQuery.Append(" , VEN_EMAIL");
                    sbQuery.Append(" , VEN_EMAIL_CC");
                    sbQuery.Append(" , VEN_PRODUCTS ");
                    sbQuery.Append(" , VEN_CHARGE_EMP ");
                    sbQuery.Append(" , VEN_CHARGE_TEL ");
                    sbQuery.Append(" , VEN_CHARGE_HP");
                    sbQuery.Append(" , VEN_BANK_NO");
                    sbQuery.Append(" , IS_MYVENDOR");
                    sbQuery.Append(" , USE_GLOBAL");

                    sbQuery.Append(" , ENG_VEN_NAME");
                    sbQuery.Append(" , ENG_VEN_ADDR");
                    sbQuery.Append(" , ENG_VEN_ADDR2");

                    sbQuery.Append(" , VEN_HOMEPAGE");
                    sbQuery.Append(" , VEN_PAYMENT");
                    sbQuery.Append(" , VEN_DEADLINE");
                    sbQuery.Append(" , VEN_TAX");


                    sbQuery.Append(" , IF_VEN_CODE");
                    sbQuery.Append(" , SCOMMENT ");
                    sbQuery.Append(" , REG_DATE ");
                    sbQuery.Append(" , REG_EMP");
                    sbQuery.Append(" , DATA_FLAG");
                    sbQuery.Append(" , ITEM_AUTO_CODE ");
                    sbQuery.Append(" )");
                    sbQuery.Append(" VALUES ");
                    sbQuery.Append(" (");
                    sbQuery.Append(" @PLT_CODE");
                    sbQuery.Append(" , @VEN_CODE");
                    sbQuery.Append(" , @VEN_NAME");
                    sbQuery.Append(" , @VEN_TYPE");
                    sbQuery.Append(" , @VEN_CAT_CODE");
                    sbQuery.Append(" , @VEN_CONDITIONS");
                    sbQuery.Append(" , @VEN_COUNTRY ");
                    sbQuery.Append(" , @VEN_ACCOUNT ");
                    sbQuery.Append(" , @VEN_CEO ");
                    sbQuery.Append(" , @VEN_BIZ_NO");
                    sbQuery.Append(" , @VEN_ID_NO ");
                    sbQuery.Append(" , @VEN_START_DATE");
                    sbQuery.Append(" , @VEN_BANK");
                    sbQuery.Append(" , @VEN_CREDIT");
                    sbQuery.Append(" , @VEN_ZIP ");
                    sbQuery.Append(" , @VEN_ADDRESS ");
                    sbQuery.Append(" , @VEN_ZIP2 ");
                    sbQuery.Append(" , @VEN_ADDRESS2 ");
                    sbQuery.Append(" , @VEN_ZIP3 ");
                    sbQuery.Append(" , @VEN_ADDRESS3 ");
                    sbQuery.Append(" , @VEN_TEL ");
                    sbQuery.Append(" , @VEN_FAX ");
                    sbQuery.Append(" , @VEN_EMAIL ");
                    sbQuery.Append(" , @VEN_EMAIL_CC");
                    sbQuery.Append(" , @VEN_PRODUCTS");
                    sbQuery.Append(" , @VEN_CHARGE_EMP");
                    sbQuery.Append(" , @VEN_CHARGE_TEL");
                    sbQuery.Append(" , @VEN_CHARGE_HP ");
                    sbQuery.Append(" , @VEN_BANK_NO ");
                    sbQuery.Append(" , @IS_MYVENDOR ");
                    sbQuery.Append(" , @USE_GLOBAL ");

                    sbQuery.Append(" , @ENG_VEN_NAME ");
                    sbQuery.Append(" , @ENG_VEN_ADDR ");
                    sbQuery.Append(" , @ENG_VEN_ADDR2 ");

                    sbQuery.Append(" , @VEN_HOMEPAGE ");
                    sbQuery.Append(" , @VEN_PAYMENT ");
                    sbQuery.Append(" , @VEN_DEADLINE ");
                    sbQuery.Append(" , @VEN_TAX ");

                    sbQuery.Append(" , @IF_VEN_CODE ");
                    sbQuery.Append(" , @SCOMMENT");
                    sbQuery.Append("      , GETDATE() ");
                    sbQuery.Append(" ," + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append("      , 0 ");
                    sbQuery.Append(" , @ITEM_AUTO_CODE ");

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
    }

    public class TSTD_VENDOR_QUERY
    {
        //공통 컨트롤 거래처 검색
        public static DataTable TSTD_VENDOR_QUERY1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT PLT_CODE ");
                    sbQuery.Append(" ,VEN_CODE ");
                    sbQuery.Append(" ,VEN_NAME ");
                    sbQuery.Append(" ,VEN_TYPE ");
                    sbQuery.Append(" ,VEN_CAT_CODE ");
                    sbQuery.Append(" ,VEN_CONDITIONS ");
                    sbQuery.Append(" ,VEN_COUNTRY");
                    sbQuery.Append(" ,VEN_ACCOUNT");
                    sbQuery.Append(" ,VEN_CEO");
                    sbQuery.Append(" ,VEN_BIZ_NO ");
                    sbQuery.Append(" ,VEN_ID_NO");
                    sbQuery.Append(" ,VEN_START_DATE ");
                    sbQuery.Append(" ,VEN_BANK ");
                    sbQuery.Append(" ,VEN_BANK_NO");
                    sbQuery.Append(" ,VEN_CREDIT ");
                    sbQuery.Append(" ,VEN_ZIP");
                    sbQuery.Append(" ,VEN_ADDRESS");
                    sbQuery.Append(" ,VEN_ZIP2");
                    sbQuery.Append(" ,VEN_ADDRESS2");
                    sbQuery.Append(" ,VEN_ZIP3");
                    sbQuery.Append(" ,VEN_ADDRESS3");
                    sbQuery.Append(" ,VEN_TEL");
                    sbQuery.Append(" ,VEN_FAX");
                    sbQuery.Append(" ,VEN_EMAIL");
                    sbQuery.Append(" ,VEN_HOMEPAGE ");
                    sbQuery.Append(" ,VEN_PAYMENT ");
                    sbQuery.Append(" ,VEN_DEADLINE ");
                    sbQuery.Append(" ,VEN_TAX");
                    sbQuery.Append(" ,VEN_PRODUCTS ");
                    sbQuery.Append(" ,VEN_CHARGE_EMP ");
                    sbQuery.Append(" ,VEN_CHARGE_TEL ");
                    sbQuery.Append(" ,VEN_CHARGE_HP");

                    sbQuery.Append(" ,ENG_VEN_NAME ");
                    sbQuery.Append(" ,ENG_VEN_ADDR ");
                    sbQuery.Append(" ,ENG_VEN_ADDR2");

                    sbQuery.Append(" ,SCOMMENT ");
                    sbQuery.Append(" ,IS_MYVENDOR");
                    sbQuery.Append(" ,REG_DATE ");
                    sbQuery.Append(" ,REG_EMP");
                    sbQuery.Append(" ,MDFY_DATE");
                    sbQuery.Append(" ,MDFY_EMP ");
                    sbQuery.Append(" ,DATA_FLAG");
                    sbQuery.Append(" ,DEL_DATE ");
                    sbQuery.Append(" ,DEL_EMP");
                    sbQuery.Append(" ,ITEM_AUTO_CODE");
                    sbQuery.Append(" FROM TSTD_VENDOR");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder();

                        sbWhere.Append(" WHERE PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@VEN_CODE", "VEN_CODE = @VEN_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "DATA_FLAG = @DATA_FLAG"));
                        sbWhere.Append(UTIL.GetWhere(row, "@VEN_CAT_CODE", "VEN_CAT_CODE = @VEN_CAT_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@VEN_LIKE", "(VEN_CODE LIKE '%' + @VEN_LIKE + '%' OR VEN_NAME LIKE '%' + @VEN_LIKE + '%')"));
                        sbWhere.Append(UTIL.GetWhere(row, "@VEN_TYPE", "VEN_TYPE = @VEN_TYPE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@VEN_TYPE_IN", "VEN_TYPE IN @VEN_TYPE_IN", UTIL.SqlCondType.IN));
                        sbWhere.Append(UTIL.GetWhere(row, "@IS_MYVENDOR", "IS_MYVENDOR = @IS_MYVENDOR"));
                        sbWhere.Append(UTIL.GetWhere(row, "@VEN_NAME", "VEN_NAME = @VEN_NAME"));
                        sbWhere.Append(UTIL.GetWhere(row, "@ORD02A", "VEN_TYPE IN ('1','3') "));

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

        public static DataTable TSTD_VENDOR_QUERY2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT V.PLT_CODE ");
                    sbQuery.Append("       ,V.VEN_CODE ");
                    sbQuery.Append("       ,V.VEN_NAME ");
                    sbQuery.Append("       ,V.VEN_TYPE ");
                    sbQuery.Append("       ,V.VEN_CAT_CODE ");
                    sbQuery.Append("       ,V.VEN_CONDITIONS ");
                    sbQuery.Append("       ,V.VEN_COUNTRY ");
                    sbQuery.Append("       ,V.VEN_ACCOUNT ");
                    sbQuery.Append("       ,V.VEN_CEO ");
                    sbQuery.Append("       ,V.VEN_BIZ_NO ");
                    sbQuery.Append("       ,V.VEN_ID_NO ");
                    sbQuery.Append("       ,V.VEN_START_DATE ");
                    sbQuery.Append("       ,V.VEN_BANK ");
                    sbQuery.Append("       ,V.VEN_BANK_NO ");
                    sbQuery.Append("       ,V.VEN_CREDIT ");
                    sbQuery.Append("       ,V.VEN_ZIP ");
                    sbQuery.Append("       ,V.VEN_ADDRESS ");
                    sbQuery.Append("       ,V.VEN_ZIP2 ");
                    sbQuery.Append("       ,V.VEN_ADDRESS2 ");
                    sbQuery.Append("       ,V.VEN_ZIP3 ");
                    sbQuery.Append("       ,V.VEN_ADDRESS3 ");
                    sbQuery.Append("       ,V.VEN_TEL ");
                    sbQuery.Append("       ,V.VEN_FAX ");
                    sbQuery.Append("       ,V.VEN_EMAIL ");
                    sbQuery.Append("       ,V.VEN_EMAIL_CC ");
                    sbQuery.Append("       ,V.VEN_HOMEPAGE ");
                    sbQuery.Append("       ,V.VEN_PAYMENT ");
                    sbQuery.Append("       ,V.VEN_DEADLINE ");
                    sbQuery.Append("       ,V.VEN_TAX ");
                    sbQuery.Append("       ,V.VEN_PRODUCTS ");
                    sbQuery.Append("       ,V.VEN_CHARGE_EMP ");
                    sbQuery.Append("       ,V.VEN_CHARGE_TEL ");
                    sbQuery.Append("       ,V.VEN_CHARGE_HP ");
                    sbQuery.Append("       ,V.SCOMMENT ");
                    sbQuery.Append("       ,V.IS_MYVENDOR ");
                    sbQuery.Append("       ,V.USE_GLOBAL ");
                    sbQuery.Append("       ,V.REG_DATE ");
                    sbQuery.Append("       ,V.REG_EMP ");
                    sbQuery.Append("       ,REG.EMP_NAME AS REG_EMP_NAME ");
                    sbQuery.Append("       ,V.MDFY_DATE ");
                    sbQuery.Append("       ,V.MDFY_EMP ");
                    sbQuery.Append("       ,MDFY.EMP_NAME AS MDFY_EMP_NAME ");
                    sbQuery.Append("       ,V.DATA_FLAG ");
                    sbQuery.Append("       ,V.IF_VEN_CODE ");
                    sbQuery.Append("       ,V.ITEM_AUTO_CODE ");
                    sbQuery.Append("       ,V.ENG_VEN_NAME ");
                    sbQuery.Append("       ,V.ENG_VEN_ADDR ");
                    sbQuery.Append("       ,V.ENG_VEN_ADDR2 ");
                    sbQuery.Append("   FROM TSTD_VENDOR V ");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE REG ");
                    sbQuery.Append(" ON V.PLT_CODE = REG.PLT_CODE ");
                    sbQuery.Append(" AND V.REG_EMP = REG.EMP_CODE ");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE MDFY ");
                    sbQuery.Append(" ON V.PLT_CODE = MDFY.PLT_CODE ");
                    sbQuery.Append(" AND V.MDFY_EMP = MDFY.EMP_CODE ");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder();

                        sbWhere.Append(" WHERE V.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@VEN_CODE", "V.VEN_CODE = @VEN_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "V.DATA_FLAG = @DATA_FLAG"));
                        sbWhere.Append(UTIL.GetWhere(row, "@VEN_CAT_CODE", "V.VEN_CAT_CODE = @VEN_CAT_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@VEN_LIKE", "(V.VEN_CODE LIKE '%' + @VEN_LIKE + '%' OR V.VEN_NAME LIKE '%' + @VEN_LIKE + '%')"));
                        sbWhere.Append(UTIL.GetWhere(row, "@VEN_TYPE", "V.VEN_TYPE = @VEN_TYPE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@IS_MYVENDOR", "V.IS_MYVENDOR = @IS_MYVENDOR"));
                        sbWhere.Append(UTIL.GetWhere(row, "@VEN_NAME", "V.VEN_NAME = @VEN_NAME"));


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

        //내회사정보가 하나이상이면 저장할수없습니다.
        public static DataTable TSTD_VENDOR_QUERY3(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT PLT_CODE ");
                    sbQuery.Append(" ,VEN_CODE ");
                    sbQuery.Append(" ,VEN_NAME ");
                    sbQuery.Append(" ,VEN_TYPE ");
                    sbQuery.Append(" ,VEN_CAT_CODE ");
                    sbQuery.Append(" ,VEN_CONDITIONS ");
                    sbQuery.Append(" ,VEN_COUNTRY");
                    sbQuery.Append(" ,VEN_ACCOUNT");
                    sbQuery.Append(" ,VEN_CEO");
                    sbQuery.Append(" ,VEN_BIZ_NO ");
                    sbQuery.Append(" ,VEN_ID_NO");
                    sbQuery.Append(" ,VEN_START_DATE ");
                    sbQuery.Append(" ,VEN_BANK ");
                    sbQuery.Append(" ,VEN_BANK_NO");
                    sbQuery.Append(" ,VEN_CREDIT ");
                    sbQuery.Append(" ,VEN_ZIP");
                    sbQuery.Append(" ,VEN_ADDRESS");
                    sbQuery.Append(" ,VEN_TEL");
                    sbQuery.Append(" ,VEN_FAX");
                    sbQuery.Append(" ,VEN_EMAIL");
                    sbQuery.Append(" ,VEN_HOMEPAGE ");
                    sbQuery.Append(" ,VEN_PAYMENT ");
                    sbQuery.Append(" ,VEN_DEADLINE ");
                    sbQuery.Append(" ,VEN_TAX");
                    sbQuery.Append(" ,VEN_PRODUCTS ");
                    sbQuery.Append(" ,VEN_CHARGE_EMP ");
                    sbQuery.Append(" ,VEN_CHARGE_TEL ");
                    sbQuery.Append(" ,VEN_CHARGE_HP");
                    sbQuery.Append(" ,SCOMMENT ");

                    sbQuery.Append(" ,ENG_VEN_NAME ");
                    sbQuery.Append(" ,ENG_VEN_ADDR ");
                    sbQuery.Append(" ,ENG_VEN_ADDR2 ");

                    sbQuery.Append(" ,IS_MYVENDOR");
                    sbQuery.Append(" ,REG_DATE ");
                    sbQuery.Append(" ,REG_EMP");
                    sbQuery.Append(" ,MDFY_DATE");
                    sbQuery.Append(" ,MDFY_EMP ");
                    sbQuery.Append(" ,DATA_FLAG");
                    sbQuery.Append(" ,DEL_DATE ");
                    sbQuery.Append(" ,DEL_EMP ");
                    sbQuery.Append(" ,ITEM_AUTO_CODE ");
                    sbQuery.Append(" FROM TSTD_VENDOR");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder();

                        sbWhere.Append(" WHERE PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString() + " AND IS_MYVENDOR = 1 ");

                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "DATA_FLAG = @DATA_FLAG"));

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

        //수주건이 포함된 거래처
        public static DataTable TSTD_VENDOR_QUERY4(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT  ");
                    sbQuery.Append(" TV.VEN_CODE, ");
                    sbQuery.Append(" TV.VEN_NAME, ");
                    sbQuery.Append(" COUNT( TP.PROD_CODE) AS WORK_CNT  ");

                    sbQuery.Append(" FROM TSTD_VENDOR TV ");
                    sbQuery.Append(" JOIN TORD_ITEM TI ");
                    sbQuery.Append(" ON TV.PLT_CODE = TI.PLT_CODE ");
                    sbQuery.Append(" AND TV.VEN_CODE = TI.CVND_CODE ");
                    sbQuery.Append(" JOIN TORD_PRODUCT TP ");
                    sbQuery.Append(" ON TI.PLT_CODE = TP.PLT_CODE ");
                    sbQuery.Append(" AND TI.ITEM_CODE = TP.ITEM_CODE ");
                    sbQuery.Append(" JOIN LSE_STD_PART PT ");
                    sbQuery.Append(" ON TP.PLT_CODE = PT.PLT_CODE ");
                    sbQuery.Append(" AND TP.PART_CODE = PT.PART_CODE ");

                    //search_con : 검색 통합 수주코드,수주처,품목코드,품목명, 규격
                    //item_code, cvnd_code, prod_code, prod_name 
                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder();

                        sbWhere.Append(" WHERE TV.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(" AND TP.PARENT_PART IS NULL ");
                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "TV.DATA_FLAG = @DATA_FLAG"));
                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "TI.DATA_FLAG = @DATA_FLAG"));
                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "TP.DATA_FLAG = @DATA_FLAG"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_ORD_DATE,@E_ORD_DATE", "TI.ORD_DATE BETWEEN @S_ORD_DATE AND @E_ORD_DATE "));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_DUE_DATE,@E_DUE_DATE", "TI.DUE_DATE BETWEEN @S_DUE_DATE AND @E_DUE_DATE "));
                        sbWhere.Append(UTIL.GetWhere(row, "@VEN_LIKE", "(TV.VEN_CODE LIKE '%' + @VEN_LIKE + '%' OR TV.VEN_NAME LIKE '%' + @VEN_LIKE + '%')"));
                        sbWhere.Append(UTIL.GetWhere(row, "@ORD_STATE", "TI.ORD_STATE = @ORD_STATE"));
                        //sbWhere.Append(UTIL.GetWhere(row, "@PROD_STATE", "TP.PROD_STATE IN (@PROD_STATE)"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_STATE", "TP.PROD_STATE IN @PROD_STATE", UTIL.SqlCondType.IN));
                        sbWhere.Append(UTIL.GetWhere(row, "@NOT_ORD_STATE", "TI.ORD_STATE <> @NOT_ORD_STATE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_LIKE", "(TP.PART_CODE LIKE '%' + @PART_LIKE + '%')"));
                        sbWhere.Append(UTIL.GetWhere(row, "@INC_WK", "TP.PROD_STATE IN ( 'WT', 'WK', 'PG' )"));

                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_CODE", "TP.PROD_CODE = @PROD_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_CODE", "TP.PART_CODE = @PART_CODE"));

                        string cond = "(PT.PART_CODE LIKE '%' + @SEARCH_CON + '%' OR TV.VEN_NAME LIKE '%' + @SEARCH_CON + '%' OR TI.ITEM_CODE LIKE '%' + @SEARCH_CON + '%' OR PT.PART_NAME LIKE '%' + @SEARCH_CON + '%' )";
                        sbWhere.Append(UTIL.GetWhere(row, "@SEARCH_CON", cond));

                        sbWhere.Append(" GROUP BY TV.VEN_CODE, TV.VEN_NAME ");
                        sbWhere.Append(" ORDER BY TV.VEN_NAME  ");

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

        //수주건이 포함된 거래처 토탈
        public static DataTable TSTD_VENDOR_QUERY5(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT  ");
                    sbQuery.Append(" COUNT(TB.VEN_CODE) AS VEN_CNT, ");
                    sbQuery.Append(" SUM(TB.WORK_CNT) AS WORK_SUM ");
                    sbQuery.Append(" FROM ");
                    sbQuery.Append(" (SELECT  ");
                    sbQuery.Append(" TV.VEN_CODE, ");
                    sbQuery.Append(" TV.VEN_NAME, ");
                    //sbQuery.Append(" COUNT(DISTINCT TI.ITEM_CODE) AS WORK_CNT  ");
                    sbQuery.Append(" COUNT(DISTINCT TP.PROD_CODE) AS WORK_CNT  ");
                    sbQuery.Append(" FROM TSTD_VENDOR TV ");
                    sbQuery.Append(" JOIN TORD_ITEM TI ");
                    sbQuery.Append(" ON TV.PLT_CODE = TI.PLT_CODE ");
                    sbQuery.Append(" AND TV.VEN_CODE = TI.CVND_CODE ");
                    sbQuery.Append(" JOIN TORD_PRODUCT TP ");
                    sbQuery.Append(" ON TI.PLT_CODE = TP.PLT_CODE ");
                    sbQuery.Append(" AND TI.ITEM_CODE = TP.ITEM_CODE ");
                    sbQuery.Append(" JOIN LSE_STD_PART PT ");
                    sbQuery.Append(" ON TP.PLT_CODE = PT.PLT_CODE ");
                    sbQuery.Append(" AND TP.PART_CODE = PT.PART_CODE ");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder();

                        sbWhere.Append(" WHERE TV.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append("  AND TP.PARENT_PART IS NULL");

                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "TV.DATA_FLAG = @DATA_FLAG"));
                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "TI.DATA_FLAG = @DATA_FLAG"));
                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "TP.DATA_FLAG = @DATA_FLAG"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_ORD_DATE,@E_ORD_DATE", "TI.ORD_DATE BETWEEN @S_ORD_DATE AND @E_ORD_DATE "));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_DUE_DATE,@E_DUE_DATE", "TI.DUE_DATE BETWEEN @S_DUE_DATE AND @E_DUE_DATE "));
                        sbWhere.Append(UTIL.GetWhere(row, "@VEN_LIKE", "(TV.VEN_CODE LIKE '%' + @VEN_LIKE + '%' OR TV.VEN_NAME LIKE '%' + @VEN_LIKE + '%')"));
                        sbWhere.Append(UTIL.GetWhere(row, "@ORD_STATE", "TI.ORD_STATE = @ORD_STATE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_STATE", "TP.PROD_STATE IN @PROD_STATE", UTIL.SqlCondType.IN));
                        sbWhere.Append(UTIL.GetWhere(row, "@INC_WK", "TP.PROD_STATE IN ( 'WT', 'WK', 'PG' )"));
                        sbWhere.Append(UTIL.GetWhere(row, "@NOT_ORD_STATE", "TI.ORD_STATE <> @NOT_ORD_STATE"));

                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_CODE", "TP.PROD_CODE = @PROD_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_CODE", "TP.PART_CODE = @PART_CODE"));

                        string cond = "(PT.PART_CODE LIKE '%' + @SEARCH_CON + '%' OR TV.VEN_NAME LIKE '%' + @SEARCH_CON + '%' OR TI.ITEM_CODE LIKE '%' + @SEARCH_CON + '%' OR PT.PART_NAME LIKE '%' + @SEARCH_CON + '%' )";
                        sbWhere.Append(UTIL.GetWhere(row, "@SEARCH_CON", cond));

                        sbWhere.Append(" GROUP BY TV.VEN_CODE, TV.VEN_NAME) TB ");

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
