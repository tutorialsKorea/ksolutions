using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace DSTD
{
    public class TSTD_VENDOR_CHARGE
    {


        public static DataTable TSTD_VENDOR_CHARGE_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {

            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT  VEN_CHARGE_ID  ");
                    sbQuery.Append(" 	, PLT_CODE         ");
                    sbQuery.Append(" 	, VEN_CODE        ");
                    sbQuery.Append(" 	, CHARGE_EMP     ");
                    sbQuery.Append(" 	, CHARGE_TEL      ");
                    sbQuery.Append(" 	, CHARGE_HP       ");
                    sbQuery.Append(" 	, CHARGE_DEPT       ");
                    sbQuery.Append(" 	, CHARGE_EMAIL       ");
                    sbQuery.Append(" 	, SCOMMENT      ");
                    sbQuery.Append(" 	, SCOMMENT  AS CHARGE_SCOMMENT    ");
                    sbQuery.Append(" 	, REG_DATE         ");
                    sbQuery.Append(" 	, REG_EMP          ");
                    sbQuery.Append(" 	, MDFY_DATE       ");
                    sbQuery.Append(" 	, MDFY_EMP        ");
                    sbQuery.Append(" FROM TSTD_VENDOR_CHARGE ");
                    //sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    //sbQuery.Append("   AND VEN_CODE = @VEN_CODE");

                    foreach (DataRow row in dtParam.Rows)
                    {                        
                        
                        StringBuilder sbWhere = new StringBuilder();

                        sbWhere.Append(" WHERE PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                        sbWhere.Append(UTIL.GetWhere(row, "@VEN_CODE", " VEN_CODE = @VEN_CODE "));
                        sbWhere.Append(UTIL.GetWhere(row, "@CHARGE_EMP", " CHARGE_EMP = @CHARGE_EMP"));

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

        public static void TSTD_VENDOR_CHARGE_UPD(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" UPDATE TSTD_VENDOR_CHARGE ");
                    sbQuery.Append(" SET CHARGE_EMP = @CHARGE_EMP");
                    sbQuery.Append(" , CHARGE_GUBUN = @CHARGE_GUBUN");
                    sbQuery.Append(" , CHARGE_TEL = @CHARGE_TEL");
                    sbQuery.Append(" , CHARGE_HP = @CHARGE_HP");
                    sbQuery.Append(" , CHARGE_DEPT = @CHARGE_DEPT");
                    sbQuery.Append(" , CHARGE_EMAIL = @CHARGE_EMAIL");
                    sbQuery.Append(" , SCOMMENT = @SCOMMENT");
                    sbQuery.Append(" , MDFY_DATE = GETDATE()");
                    sbQuery.Append(" , MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" WHERE VEN_CHARGE_ID = @VEN_CHARGE_ID ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "VEN_CHARGE_ID")) isHasColumn = false;

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

        public static void TSTD_VENDOR_CHARGE_DEL(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {

                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append("DELETE TSTD_VENDOR_CHARGE ");
                    sbQuery.Append(" WHERE VEN_CHARGE_ID = @VEN_CHARGE_ID ");      

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "VEN_CHARGE_ID")) isHasColumn = false;
                        
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


        public static void TSTD_VENDOR_CHARGE_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" INSERT INTO TSTD_VENDOR_CHARGE");
                    sbQuery.Append(" (");
                    sbQuery.Append(" PLT_CODE ");
                    sbQuery.Append(" , VEN_CODE ");
                    sbQuery.Append(" , CHARGE_EMP ");
                    sbQuery.Append(" , CHARGE_GUBUN "); 
                    sbQuery.Append(" , CHARGE_TEL ");
                    sbQuery.Append(" , CHARGE_HP ");
                    sbQuery.Append(" , CHARGE_DEPT ");
                    sbQuery.Append(" , CHARGE_EMAIL ");
                    sbQuery.Append(" , SCOMMENT");
                    sbQuery.Append(" , REG_DATE");
                    sbQuery.Append(" , REG_EMP");
                    sbQuery.Append(" )");
                    sbQuery.Append(" VALUES ");
                    sbQuery.Append(" (");
                    sbQuery.Append(" @PLT_CODE");
                    sbQuery.Append(" , @VEN_CODE");
                    sbQuery.Append(" , @CHARGE_EMP");
                    sbQuery.Append(" , @CHARGE_GUBUN ");
                    sbQuery.Append(" , @CHARGE_TEL");
                    sbQuery.Append(" , @CHARGE_HP");
                    sbQuery.Append(" , @CHARGE_DEPT");
                    sbQuery.Append(" , @CHARGE_EMAIL");
                    sbQuery.Append(" , @SCOMMENT ");
                    sbQuery.Append("      , GETDATE() ");
                    sbQuery.Append(" ," + UTIL.GetValidValue(ConnInfo.UserID));
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

    public class TSTD_VENDOR_CHARGE_QUERY
    {
        //공통 컨트롤 거래처 검색
        public static DataTable TSTD_VENDOR_CHARGE_QUERY1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT  VEN_CHARGE_ID  ");
                    sbQuery.Append(" 	, PLT_CODE         ");
                    sbQuery.Append(" 	, VEN_CODE        ");
                    sbQuery.Append(" 	, CHARGE_EMP     ");
                    sbQuery.Append(" 	, CHARGE_TEL      ");
                    sbQuery.Append(" 	, CHARGE_HP       ");
                    sbQuery.Append(" 	, CHARGE_DEPT       ");
                    sbQuery.Append(" 	, CHARGE_EMAIL       ");
                    sbQuery.Append(" 	, SCOMMENT      ");
                    sbQuery.Append(" 	, SCOMMENT  AS CHARGE_SCOMMENT    ");
                    sbQuery.Append("    , CHARGE_GUBUN");
                    sbQuery.Append(" 	, REG_DATE         ");
                    sbQuery.Append(" 	, REG_EMP          ");
                    sbQuery.Append(" 	, MDFY_DATE       ");
                    sbQuery.Append(" 	, MDFY_EMP        ");
                    sbQuery.Append(" FROM TSTD_VENDOR_CHARGE");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder();

                        sbWhere.Append(" WHERE PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@VEN_CODE", "VEN_CODE = @VEN_CODE"));
                        sbWhere.Append("ORDER BY CHARGE_EMP");
                        //sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "DATA_FLAG = @DATA_FLAG"));                                    

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
