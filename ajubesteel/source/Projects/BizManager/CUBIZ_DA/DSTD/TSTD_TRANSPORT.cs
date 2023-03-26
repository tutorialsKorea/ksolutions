using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BizExecute;
using System.Data;

namespace DSTD
{
    public class TSTD_TRANSPORT
    {
        public static DataTable TSTD_TRANSPORT_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {

            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT ");
                    sbQuery.Append("  PLT_CODE");
                    sbQuery.Append(" , TRP_CODE");
                    sbQuery.Append(" , TRP_TYPE");
                    sbQuery.Append(" , TRP_NAME");
                    sbQuery.Append(" , TRP_OWNER");
                    sbQuery.Append(" , TRP_TEL");
                    sbQuery.Append(" , TRP_ACCT_HOLDR");
                    sbQuery.Append(" , TRP_BANK");
                    sbQuery.Append(" , TRP_ACCT_NO");
                    sbQuery.Append(" , TRP_BIZ_NO");
                    sbQuery.Append(" , TRP_COMPANY");
                    sbQuery.Append(" , TRP_CEO");
                    sbQuery.Append(" , TRP_REGION");
                    sbQuery.Append(" , TRP_TAX_INVOICE");
                    sbQuery.Append(" , TRP_RECEIPT");
                    sbQuery.Append(" , TRP_ACTIVE");
                    sbQuery.Append(" , SCOMMENT");
                    sbQuery.Append(" , REG_DATE");
                    sbQuery.Append(" , REG_EMP");
                    sbQuery.Append(" , MDFY_DATE");
                    sbQuery.Append(" , MDFY_EMP");
                    sbQuery.Append(" , DEL_DATE");
                    sbQuery.Append(" , DEL_EMP");
                    sbQuery.Append(" , DATA_FLAG");
                    sbQuery.Append(" FROM TSTD_TRANSPORT");
                    sbQuery.Append(" WHERE");
                    sbQuery.Append(" PLT_CODE=@PLT_CODE");
                    sbQuery.Append(" AND TRP_CODE=@TRP_CODE");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "TRP_CODE")) isHasColumn = false;

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

        public static void TSTD_TRANSPORT_UPD(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" UPDATE TSTD_TRANSPORT");
                    sbQuery.Append(" SET ");
                    sbQuery.Append(" TRP_TYPE = @TRP_TYPE");
                    sbQuery.Append(" , TRP_NAME = @TRP_NAME");
                    sbQuery.Append(" , TRP_OWNER = @TRP_OWNER");
                    sbQuery.Append(" , TRP_TEL = @TRP_TEL");
                    sbQuery.Append(" , TRP_ACCT_HOLDR = @TRP_ACCT_HOLDR");
                    sbQuery.Append(" , TRP_BANK = @TRP_BANK");
                    sbQuery.Append(" , TRP_ACCT_NO = @TRP_ACCT_NO");
                    sbQuery.Append(" , TRP_BIZ_NO = @TRP_BIZ_NO");
                    sbQuery.Append(" , TRP_COMPANY = @TRP_COMPANY");
                    sbQuery.Append(" , TRP_CEO = @TRP_CEO");
                    sbQuery.Append(" , TRP_REGION = @TRP_REGION");
                    sbQuery.Append(" , TRP_TAX_INVOICE = @TRP_TAX_INVOICE");
                    sbQuery.Append(" , TRP_RECEIPT = @TRP_RECEIPT");
                    sbQuery.Append(" , TRP_ACTIVE = @TRP_ACTIVE");
                    sbQuery.Append(" , SCOMMENT = @SCOMMENT");
                    sbQuery.Append(" , MDFY_DATE = GETDATE()");
                    sbQuery.Append(" , MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" , DATA_FLAG = @DATA_FLAG");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND TRP_CODE = @TRP_CODE");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "TRP_CODE")) isHasColumn = false;

                        if (isHasColumn == true)
                        {                            
                            bizExecute.executeUpdateQuery(sbQuery.ToString(),row );
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }

        public static void TSTD_TRANSPORT_UDE(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {

                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append("UPDATE TSTD_TRANSPORT SET");
                    sbQuery.Append("  DEL_DATE = GETDATE()");
                    sbQuery.Append(" , DEL_EMP = '" + ConnInfo.UserID + "'");
                    sbQuery.Append(" , DATA_FLAG = 2");

                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND TRP_CODE = @TRP_CODE");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "TRP_CODE")) isHasColumn = false;

                        if (isHasColumn == true)
                        {
                            bizExecute.executeUpdateQuery(sbQuery.ToString(),row );
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }

        public static void TSTD_TRANSPORT_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" INSERT INTO TSTD_TRANSPORT");
                    sbQuery.Append("  ( ");
                    sbQuery.Append("  PLT_CODE");
                    sbQuery.Append("  , TRP_CODE");
                    sbQuery.Append("  , TRP_TYPE");
                    sbQuery.Append("  , TRP_NAME");
                    sbQuery.Append("  , TRP_OWNER");
                    sbQuery.Append("  , TRP_TEL");
                    sbQuery.Append("  , TRP_ACCT_HOLDR");
                    sbQuery.Append("  , TRP_BANK");
                    sbQuery.Append("  , TRP_ACCT_NO");
                    sbQuery.Append("  , TRP_BIZ_NO");
                    sbQuery.Append("  , TRP_COMPANY");
                    sbQuery.Append("  , TRP_CEO");
                    sbQuery.Append("  , TRP_REGION");
                    sbQuery.Append("  , TRP_TAX_INVOICE");
                    sbQuery.Append("  , TRP_RECEIPT");
                    sbQuery.Append("  , TRP_ACTIVE");
                    sbQuery.Append("  , SCOMMENT");
                    sbQuery.Append("  , REG_DATE");
                    sbQuery.Append("  , REG_EMP");
                    sbQuery.Append("  , DATA_FLAG");
                    sbQuery.Append(" ) ");
                    sbQuery.Append(" VALUES");
                    sbQuery.Append(" ( ");
                    sbQuery.Append(" @PLT_CODE ");
                    sbQuery.Append("  , @TRP_CODE");
                    sbQuery.Append("  , @TRP_TYPE");
                    sbQuery.Append("  , @TRP_NAME");
                    sbQuery.Append("  , @TRP_OWNER");
                    sbQuery.Append("  , @TRP_TEL");
                    sbQuery.Append("  , @TRP_ACCT_HOLDR");
                    sbQuery.Append("  , @TRP_BANK");
                    sbQuery.Append("  , @TRP_ACCT_NO");
                    sbQuery.Append("  , @TRP_BIZ_NO");
                    sbQuery.Append("  , @TRP_COMPANY");
                    sbQuery.Append("  , @TRP_CEO");
                    sbQuery.Append("  , @TRP_REGION");
                    sbQuery.Append("  , @TRP_TAX_INVOICE");
                    sbQuery.Append("  , @TRP_RECEIPT");
                    sbQuery.Append("  , @TRP_ACTIVE");
                    sbQuery.Append("  , @SCOMMENT");
                    sbQuery.Append("  , GETDATE()");
                    sbQuery.Append("  ," + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" , 0");
                    sbQuery.Append(") ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        
                        bizExecute.executeInsertQuery(sbQuery.ToString(),row);
                    }
                }

            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }
    }

    public class TSTD_TRANSPORT_QUERY
    {
        public static DataTable TSTD_CODES_QUERY2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {


                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT");
                    sbQuery.Append(" 	TS.PLT_CODE");
                    sbQuery.Append(" 	, TS.TRP_CODE");
                    sbQuery.Append(" 	, TS.TRP_TYPE");
                    sbQuery.Append(" 	, TS.TRP_NAME");
                    sbQuery.Append(" 	, TS.TRP_OWNER");
                    sbQuery.Append(" 	, TS.TRP_TEL");
                    sbQuery.Append(" 	, TS.TRP_ACCT_HOLDR");
                    sbQuery.Append(" 	, TS.TRP_BANK");
                    sbQuery.Append(" 	, TS.TRP_ACCT_NO");
                    sbQuery.Append(" 	, TS.TRP_BIZ_NO");
                    sbQuery.Append(" 	, TS.TRP_COMPANY");
                    sbQuery.Append(" 	, TS.TRP_CEO");
                    sbQuery.Append(" 	, TS.TRP_REGION");
                    sbQuery.Append(" 	, TS.TRP_TAX_INVOICE");
                    sbQuery.Append(" 	, TS.TRP_RECEIPT");
                    sbQuery.Append(" 	, TS.TRP_ACTIVE");
                    sbQuery.Append(" 	, TS.SCOMMENT");
                    sbQuery.Append(" 	, TS.REG_DATE");
                    sbQuery.Append(" 	, TS.REG_EMP");
                    sbQuery.Append(" 	, REG.EMP_NAME AS REG_EMP_NAME");
                    sbQuery.Append(" 	, TS.MDFY_DATE");
                    sbQuery.Append(" 	, TS.MDFY_EMP");
                    sbQuery.Append(" 	, MDFY.EMP_NAME AS MDFY_EMP_NAME");
                    sbQuery.Append(" 	, TS.DEL_DATE");
                    sbQuery.Append(" 	, TS.DEL_EMP");
                    sbQuery.Append(" 	, TS.DATA_FLAG");
                    sbQuery.Append(" FROM TSTD_TRANSPORT TS");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE  REG ");
                    sbQuery.Append(" ON TS.PLT_CODE = REG.PLT_CODE ");
                    sbQuery.Append(" AND TS.REG_EMP = REG.EMP_CODE ");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE  MDFY");
                    sbQuery.Append(" ON TS.PLT_CODE = MDFY.PLT_CODE ");
                    sbQuery.Append(" AND TS.MDFY_EMP = MDFY.EMP_CODE ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE TS.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@TRP_CODE", "TS.TRP_CODE = @TRP_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "TS.DATA_FLAG = @DATA_FLAG"));

                        sbWhere.Append(" ORDER BY TS.PLT_CODE, TS.TRP_CODE");

                        DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString() + sbWhere.ToString() ).Copy();

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
