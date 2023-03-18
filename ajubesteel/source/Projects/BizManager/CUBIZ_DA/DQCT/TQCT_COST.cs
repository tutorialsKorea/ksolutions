using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace DQCT
{
    public class TQCT_COST
    {
        public static DataTable TQCT_COST_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT PLT_CODE ");
                    sbQuery.Append("      , QCT_NO ");
                    sbQuery.Append("      , QCT_DATE ");
                    sbQuery.Append("      , QCT_EMP ");
                    sbQuery.Append("      , QCT_CAT ");
                    sbQuery.Append("      , QCT_CODE ");
                    sbQuery.Append("      , QCT_COST ");
                    sbQuery.Append("      , SCOMMENT ");
                    sbQuery.Append("      , REG_DATE ");
                    sbQuery.Append("      , REG_EMP ");
                    sbQuery.Append("      , MDFY_DATE ");
                    sbQuery.Append("      , MDFY_EMP ");
                    sbQuery.Append("   FROM TQCT_COST ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("    AND QCT_NO = @QCT_NO  ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "QCT_NO")) isHasColumn = false;

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

        public static void TQCT_COST_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();


                    sbQuery.Append(" INSERT INTO TQCT_COST ");
                    sbQuery.Append(" ( ");
                    sbQuery.Append("        PLT_CODE ");
                    sbQuery.Append("      , QCT_NO ");
                    sbQuery.Append("      , QCT_DATE ");
                    sbQuery.Append("      , QCT_EMP ");
                    sbQuery.Append("      , QCT_CAT ");
                    sbQuery.Append("      , QCT_CODE ");
                    sbQuery.Append("      , QCT_COST ");
                    sbQuery.Append("      , SCOMMENT ");
                    sbQuery.Append("      , REG_DATE ");
                    sbQuery.Append("      , REG_EMP ");
                    sbQuery.Append(" ) ");
                    sbQuery.Append(" VALUES ");
                    sbQuery.Append(" ( ");
                    sbQuery.Append("        @PLT_CODE ");
                    sbQuery.Append("      , @QCT_NO ");
                    sbQuery.Append("      , @QCT_DATE ");
                    sbQuery.Append("      , @QCT_EMP ");
                    sbQuery.Append("      , @QCT_CAT ");
                    sbQuery.Append("      , @QCT_CODE ");
                    sbQuery.Append("      , @QCT_COST ");
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

        public static void TQCT_COST_UPD(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" UPDATE TQCT_COST ");
                    sbQuery.Append("    SET QCT_DATE = @QCT_DATE ");
                    sbQuery.Append("      , QCT_EMP = @QCT_EMP ");
                    sbQuery.Append("      , QCT_CAT = @QCT_CAT ");
                    sbQuery.Append("      , QCT_CODE = @QCT_CODE ");
                    sbQuery.Append("      , QCT_COST = @QCT_COST ");
                    sbQuery.Append("      , SCOMMENT = @SCOMMENT ");
                    sbQuery.Append("        , MDFY_DATE =  GETDATE() ");
                    sbQuery.Append("        , MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("    AND QCT_NO = @QCT_NO  ");
                                        
                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "QCT_NO")) isHasColumn = false;

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

        public static void TQCT_COST_UPD2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" UPDATE TQCT_COST ");
                    sbQuery.Append("    SET QCT_COST = @QCT_COST ");
                    sbQuery.Append("        , MDFY_DATE =  GETDATE() ");
                    sbQuery.Append("        , MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("    AND QCT_NO = @QCT_NO  ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "QCT_NO")) isHasColumn = false;

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

        public static void TQCT_COST_DEL(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" DELETE FROM TQCT_COST ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("    AND QCT_NO = @QCT_NO  ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "QCT_NO")) isHasColumn = false;

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



    public class TQCT_COST_QUERY
    {
        public static DataTable TQCT_COST_QUERY1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT COST.PLT_CODE ");
                    sbQuery.Append("      , COST.QCT_NO ");
                    sbQuery.Append("      , COST.QCT_DATE ");
                    sbQuery.Append("      , COST.QCT_EMP ");
                    sbQuery.Append("      , COST.QCT_CAT ");
                    sbQuery.Append("      , COST.QCT_CODE ");
                    sbQuery.Append("      , COST.QCT_COST ");
                    sbQuery.Append("      , COST.SCOMMENT ");
                    sbQuery.Append("      , COST.REG_DATE ");
                    sbQuery.Append("      , COST.REG_EMP ");
                    sbQuery.Append("      , COST.MDFY_DATE ");
                    sbQuery.Append("      , COST.MDFY_EMP ");
                    sbQuery.Append("   FROM TQCT_COST COST					");
                    //sbQuery.Append(" 	INNER JOIN TOUT_TEMP_YPGO TYP			");
                    //sbQuery.Append(" 		ON NG.PLT_CODE = TYP.PLT_CODE		");
                    //sbQuery.Append(" 		AND NG.TYP_ID = TYP.TYP_ID			");
                   

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder();

                        sbWhere.Append(" WHERE COST.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@S_QCT_DATE,@E_QCT_DATE", "COST.QCT_DATE BETWEEN @S_QCT_DATE AND @E_QCT_DATE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_REG_DATE,@E_REG_DATE", "COST.REG_DATE BETWEEN @S_REG_DATE AND @E_REG_DATE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@QCT_CAT", "COST.QCT_CAT = @QCT_CAT"));
                        sbWhere.Append(UTIL.GetWhere(row, "@QCT_NO", "COST.QCT_NO = @QCT_NO"));

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

        public static DataTable TQCT_COST_QUERY2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT COST.PLT_CODE "); 
                    sbQuery.Append("      , COST.QCT_CAT AS MGUBUN ");
                    sbQuery.Append("      , COST.QCT_CODE AS GUBUN ");
                    sbQuery.Append("      , SUBSTRING(COST.QCT_DATE,5,2) as MONTH  ");
                    sbQuery.Append("      , COST.QCT_COST AS COST ");
                    sbQuery.Append("   FROM TQCT_COST COST					");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder();

                        sbWhere.Append(" WHERE COST.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@YEAR", "LEFT(QCT_DATE,4) = @YEAR"));

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
