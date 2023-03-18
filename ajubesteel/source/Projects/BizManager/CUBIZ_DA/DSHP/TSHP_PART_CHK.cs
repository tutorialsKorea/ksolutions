using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace DSHP
{
    public class TSHP_PART_CHK
    {
        public static DataTable TSHP_PART_CHK_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT  ");
                    sbQuery.Append(" PLT_CODE, ");
                    sbQuery.Append(" WO_NO, ");
                    sbQuery.Append(" PART_CODE, ");
                    sbQuery.Append(" INS_CODE, ");
                    sbQuery.Append(" CHK_NO, ");
                    sbQuery.Append(" CHK_VALUE ");
                    sbQuery.Append(" FROM TSHP_PART_CHK ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                        
                        sbWhere.Append(UTIL.GetWhere(row, "@WO_NO", "WO_NO = @WO_NO"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_CODE", "PART_CODE = @PART_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@INS_CODE", "INS_CODE = @INS_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@CHK_NO", "CHK_NO = @CHK_NO"));

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


        public static void TSHP_PART_CHK_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" INSERT INTO TSHP_PART_CHK");
                    sbQuery.Append(" (");
                    sbQuery.Append(" PLT_CODE");
                    sbQuery.Append(" , WO_NO");
                    sbQuery.Append(" , PART_CODE");
                    sbQuery.Append(" , INS_CODE");
                    sbQuery.Append(" , CHK_NO");
                    sbQuery.Append(" , CHK_VALUE");
                    sbQuery.Append(" , REG_DATE");
                    sbQuery.Append(" , REG_EMP");
                    sbQuery.Append(" )");
                    sbQuery.Append(" VALUES");
                    sbQuery.Append(" (");
                    sbQuery.Append(" @PLT_CODE");
                    sbQuery.Append(" , @WO_NO");
                    sbQuery.Append(" , @PART_CODE");
                    sbQuery.Append(" , @INS_CODE");
                    sbQuery.Append(" , @CHK_NO");
                    sbQuery.Append(" , @CHK_VALUE");
                    sbQuery.Append(" , GETDATE()");
                    sbQuery.Append(" , " + UTIL.GetValidValue(ConnInfo.UserID));
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


        public static void TSHP_PART_CHK_UPD(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" UPDATE TSHP_PART_CHK");
                    sbQuery.Append(" SET   CHK_VALUE = @CHK_VALUE");
                    sbQuery.Append(" , MDFY_DATE = GETDATE()");
                    sbQuery.Append(" , MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append(" AND WO_NO = @WO_NO");
                    sbQuery.Append(" AND PART_CODE = @PART_CODE");
                    sbQuery.Append(" AND INS_CODE = @INS_CODE");
                    sbQuery.Append(" AND CHK_NO = @CHK_NO");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "WO_NO")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PART_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "INS_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "CHK_NO")) isHasColumn = false;

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

    public class TSHP_PART_CHK_QUERY
    {
        public static DataTable TSHP_PART_CHK_QUERY1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" exec PC_TSHP_PART_CHK @PLT_CODE, @WO_NO, @PART_CODE ");

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

        public static DataTable TSHP_PART_CHK_QUERY2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT  ");
                    sbQuery.Append(" MAX(CHK_NO) AS CHK_MAX_NO ");
                    sbQuery.Append(" FROM TSHP_PART_CHK ");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "WO_NO")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PART_CODE")) isHasColumn = false;

                        if (isHasColumn == true)
                        {
                            StringBuilder sbWhere = new StringBuilder(" WHERE PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                            sbWhere.Append(UTIL.GetWhere(row, "@WO_NO", "WO_NO = @WO_NO"));
                            sbWhere.Append(UTIL.GetWhere(row, "@PART_CODE", "PART_CODE = @PART_CODE"));

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

        public static DataTable TSHP_PART_CHK_QUERY3(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" exec PC_TSHP_PART_CHK2 @PLT_CODE, @WO_NO, @PROD_CODE, @PART_CODE ");

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
    }
}
