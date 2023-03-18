using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BizExecute;
using System.Data;

namespace DOUT
{
    public class TOUT_SETREQUEST
    {
        public static DataTable TSTD_CODES_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {

            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append("SELECT PLT_CODE");
                    sbQuery.Append(" , CAT_CODE");
                    sbQuery.Append(" , CD_CODE ");
                    sbQuery.Append(" , CD_NAME ");
                    sbQuery.Append(" , VALUE ");
                    sbQuery.Append(" , CD_PARENT ");
                    sbQuery.Append(" , CD_SEQ");
                    sbQuery.Append(" , IS_DEFAULT");
                    sbQuery.Append(" , SCOMMENT");
                    sbQuery.Append(" , REG_DATE");
                    sbQuery.Append(" , REG_EMP ");
                    sbQuery.Append(" , MDFY_DATE ");
                    sbQuery.Append(" , MDFY_EMP");
                    sbQuery.Append(" , DEL_DATE");
                    sbQuery.Append(" , DEL_EMP ");
                    sbQuery.Append(" , DEL_REASON");
                    sbQuery.Append(" , DATA_FLAG ");
                    sbQuery.Append(" FROM TSTD_CODES ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append(" AND CAT_CODE = @CAT_CODE ");
                    sbQuery.Append(" AND CD_CODE = @CD_CODE ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "CAT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "CD_CODE")) isHasColumn = false;

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

        public static void TSTD_CODES_UPD(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" UPDATE TSTD_CODES ");
                    sbQuery.Append(" SET CAT_CODE = @CAT_CODE");
                    sbQuery.Append(" , CD_CODE = @CD_CODE");
                    sbQuery.Append(" , CD_NAME = @CD_NAME");
                    sbQuery.Append(" , VALUE = @VALUE");
                    sbQuery.Append(" , CD_PARENT = @CD_PARENT");
                    sbQuery.Append(" , CD_SEQ = @CD_SEQ");
                    sbQuery.Append(" , IS_DEFAULT = @IS_DEFAULT");
                    sbQuery.Append(" , SCOMMENT = @SCOMMENT");
                    sbQuery.Append(" , MDFY_DATE = GETDATE()");
                    sbQuery.Append(" , MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" , DATA_FLAG = 0");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND CAT_CODE = @CAT_CODE");
                    sbQuery.Append(" AND CD_CODE = @CD_CODE");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "CAT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "CD_CODE")) isHasColumn = false;

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

        public static void TORD_ITEM_UDE(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {

                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TORD_ITEM ");
                    sbQuery.Append(" SET   DEL_DATE = GETDATE() ");
                    sbQuery.Append(" , DEL_EMP = '" + ConnInfo.UserID + "'");
                    sbQuery.Append(" , DATA_FLAG = @DATA_FLAG ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append(" AND ITEM_CODE = @ITEM_CODE");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "ITEM_CODE")) isHasColumn = false;
                        //if (!UTIL.ValidColumn(row, "CD_CODE")) isHasColumn = false;

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

        public static void TSTD_CODES_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" INSERT INTO TSTD_CODES");
                    sbQuery.Append(" ( ");
                    sbQuery.Append(" PLT_CODE");
                    sbQuery.Append(" , CAT_CODE");
                    sbQuery.Append(" , CD_CODE ");
                    sbQuery.Append(" , CD_NAME ");
                    sbQuery.Append(" , VALUE ");
                    sbQuery.Append(" , CD_PARENT ");
                    sbQuery.Append(" , CD_SEQ");
                    sbQuery.Append(" , IS_DEFAULT");
                    sbQuery.Append(" , SCOMMENT");
                    sbQuery.Append(" , REG_DATE");
                    sbQuery.Append(" , REG_EMP ");
                    sbQuery.Append(" , DATA_FLAG ");
                    sbQuery.Append(" ) ");
                    sbQuery.Append(" VALUES");
                    sbQuery.Append(" ( ");
                    sbQuery.Append(" @PLT_CODE ");
                    sbQuery.Append(" , @CAT_CODE ");
                    sbQuery.Append(" , @CD_CODE");
                    sbQuery.Append(" , @CD_NAME");
                    sbQuery.Append(" , @VALUE");
                    sbQuery.Append(" , @CD_PARENT");
                    sbQuery.Append(" , @CD_SEQ ");
                    sbQuery.Append(" , @IS_DEFAULT ");
                    sbQuery.Append(" , @SCOMMENT ");
                    sbQuery.Append(" ,GETDATE()");
                    sbQuery.Append(" ," + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" ,0");
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
    }

    public class TORD_SET_REQUEST_QUERY
    {
        public static DataTable TORD_SETREQUEST_QUERY7(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {


                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    
                    sbQuery.Append("       SELECT PLT_CODE");
                    sbQuery.Append("      ,REQUEST_NO");
                    sbQuery.Append("      ,REQUEST_SEQ");
                    sbQuery.Append("      ,PROD_CODE");
                    sbQuery.Append("      ,PRG_CODE");
                    sbQuery.Append("      ,REQ_STAT");
                    sbQuery.Append("      ,C_REASON");
                    sbQuery.Append("      ,REG_DATE");
                    sbQuery.Append("      ,REG_EMP");
                    sbQuery.Append("      ,MDFY_DATE");
                    sbQuery.Append("      ,MDFY_EMP");
                    sbQuery.Append("      ,QTY");
                    sbQuery.Append("  FROM TOUT_SETREQUEST");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_CODE", "PROD_CODE = @PROD_CODE"));
                        sbWhere.Append(" AND REQ_STAT IN ('01' , '03' , '11') ");

                        //sbWhere.Append(" ORDER BY CD.CD_SEQ");

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
