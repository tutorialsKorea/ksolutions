using BizExecute;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSTD
{
    public class TSTD_EMP_WORKTYPE
    {
        public static DataTable TSTD_EMP_WORKTYPE_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("  SELECT  ");
                    sbQuery.Append("  PLT_CODE ");
                    sbQuery.Append(" ,EWT_NO ");
                    sbQuery.Append(" ,WORK_YEAR ");
                    sbQuery.Append(" ,EMP_CODE ");
                    sbQuery.Append(" ,REG_DATE ");
                    sbQuery.Append(" ,REG_EMP ");
                    sbQuery.Append(" ,MDFY_DATE ");
                    sbQuery.Append(" ,MDFY_EMP ");
                    sbQuery.Append(" ,DEL_DATE ");
                    sbQuery.Append(" ,DEL_EMP ");
                    sbQuery.Append(" ,DATA_FLAG ");
                    sbQuery.Append("  FROM TSTD_EMP_WORKTYPE  ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("  AND EWT_NO = @EWT_NO  ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "EWT_NO")) isHasColumn = false;

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

        public static void TSTD_EMP_WORKTYPE_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" INSERT INTO TSTD_EMP_WORKTYPE (  ");
                    sbQuery.Append("  PLT_CODE ");
                    sbQuery.Append(" ,EWT_NO ");
                    sbQuery.Append(" ,WORK_YEAR ");
                    sbQuery.Append(" ,EMP_CODE ");
                    sbQuery.Append(" ,REG_DATE ");
                    sbQuery.Append(" ,REG_EMP ");
                    sbQuery.Append(" ,DATA_FLAG ");
                    sbQuery.Append("  ) VALUES (  ");
                    sbQuery.Append("  @PLT_CODE ");
                    sbQuery.Append(" ,@EWT_NO ");
                    sbQuery.Append(" ,@WORK_YEAR ");
                    sbQuery.Append(" ,@EMP_CODE ");
                    sbQuery.Append(" ,GETDATE() ");
                    sbQuery.Append(" ,'" + ConnInfo.UserID + "' ");
                    sbQuery.Append(" ,@DATA_FLAG ");
                    sbQuery.Append("  ) ");

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

        public static void TSTD_EMP_WORKTYPE_UPD(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TSTD_EMP_WORKTYPE SET  ");
                    sbQuery.Append("  WORK_YEAR = @WORK_YEAR ");
                    sbQuery.Append(" ,EMP_CODE = @EMP_CODE ");
                    sbQuery.Append(" ,MDFY_DATE = GETDATE() ");
                    sbQuery.Append(" ,MDFY_EMP = '" + ConnInfo.UserID + "' ");
                    sbQuery.Append(" ,DATA_FLAG = @DATA_FLAG ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append("  AND EWT_NO = @EWT_NO ");
                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "EWT_NO")) isHasColumn = false;

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

        public static void TSTD_EMP_WORKTYPE_UDE(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TSTD_EMP_WORKTYPE SET  ");
                    sbQuery.Append("  DEL_DATE = GETDATE() ");
                    sbQuery.Append(" ,DEL_EMP = '" + ConnInfo.UserID + "' ");
                    sbQuery.Append(" ,DATA_FLAG = @DATA_FLAG ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append("  AND EWT_NO = @EWT_NO ");
                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "EWT_NO")) isHasColumn = false;

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

    public class TSTD_EMP_WORKTYPE_QUERY
    {
        public static DataTable TSTD_EMP_WORKTYPE_QUERY1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT");
                    sbQuery.Append(" EWT.PLT_CODE");
                    sbQuery.Append(" ,EWT.EWT_NO");
                    sbQuery.Append(" ,EWT.WORK_YEAR");
                    sbQuery.Append(" ,EWT.EMP_CODE");
                    sbQuery.Append(" ,E.EMP_NAME");
                    sbQuery.Append(" ,E.ORG_CODE");
                    sbQuery.Append(" ,O.ORG_NAME");
                    sbQuery.Append(" ,EWT.REG_DATE");
                    sbQuery.Append(" ,EWT.REG_EMP");
                    sbQuery.Append(" ,EWT.MDFY_DATE");
                    sbQuery.Append(" ,EWT.MDFY_EMP");
                    sbQuery.Append(" ,EWT.DEL_DATE");
                    sbQuery.Append(" ,EWT.DEL_EMP");
                    sbQuery.Append(" ,EWT.DATA_FLAG");
                    sbQuery.Append(" FROM TSTD_EMP_WORKTYPE EWT");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE E");
                    sbQuery.Append(" ON EWT.PLT_CODE = E.PLT_CODE");
                    sbQuery.Append(" AND EWT.EMP_CODE = E.EMP_CODE");

                    sbQuery.Append(" LEFT JOIN TSTD_ORG O ");
                    sbQuery.Append(" ON E.PLT_CODE = O.PLT_CODE");
                    sbQuery.Append(" AND E.ORG_CODE = O.ORG_CODE ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        StringBuilder sbWhere = new StringBuilder();
                        sbWhere.Append(" WHERE EWT.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                        sbWhere.Append(UTIL.GetWhere(row, "@EWT_NO", "EWT.EWT_NO = @EWT_NO"));
                        sbWhere.Append(UTIL.GetWhere(row, "@WORK_YEAR", "EWT.WORK_YEAR = @WORK_YEAR"));
                        sbWhere.Append(UTIL.GetWhere(row, "@EMP_CODE", "EWT.EMP_CODE = @EMP_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "EWT.DATA_FLAG = @DATA_FLAG"));

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

        public static DataTable TSTD_EMP_WORKTYPE_QUERY2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT");
                    sbQuery.Append(" @PLT_CODE AS PLT_CODE");
                    sbQuery.Append(" ,@WORK_MON AS WORK_MONTH");
                    sbQuery.Append(" , LEFT(@WORK_MONTH,4) + '.' + SUBSTRING(@WORK_MONTH, 6, 2) + '.01~' + SUBSTRING(@WORK_MONTH, 6, 2) + '.15' AS DATE_PERIOD");
                    sbQuery.Append(" , '1' AS '1', '2' AS '2', '3' AS '3', '4' AS '4'");
                    sbQuery.Append(" , '5' AS '5', '6' AS '6', '7' AS '7', '8' AS '8'");
                    sbQuery.Append(" , '9' AS '9', '10' AS '10', '11' AS '11', '12' AS '12'");
                    sbQuery.Append(" , '13' AS '13', '14' AS '14', '15' AS '15', '' AS '16'");
                    sbQuery.Append(" UNION ALL");
                    sbQuery.Append(" SELECT");
                    sbQuery.Append(" @PLT_CODE AS PLT_CODE");
                    sbQuery.Append(" ,@WORK_MON");
                    sbQuery.Append(" , LEFT(@WORK_MONTH,4) + '.' + SUBSTRING(@WORK_MONTH, 6, 2) + '.16~' + SUBSTRING(@WORK_MONTH, 6, 2) + '.' +  RIGHT(CONVERT(VARCHAR(10), DATEADD(MONTH, DATEDIFF(MONTH, 0, '2021-05' + '-01') + 1, 0) - 1, 23), 2)");
                    sbQuery.Append(" , '16', '17', '18', '19'");
                    sbQuery.Append(" , '20', '21', '22', '23'");
                    sbQuery.Append(" , '24', '25', '26', '27'");
                    sbQuery.Append(" , '28'");
                    sbQuery.Append(" , CASE WHEN DAY(DATEADD(MONTH, DATEDIFF(MONTH, 0, @WORK_MONTH + '-01') + 1, 0) - 3) != 29 AND RIGHT(@WORK_MON ,2) = '02' THEN '' ELSE '29' END");
                    sbQuery.Append(" , CASE WHEN DAY(DATEADD(MONTH, DATEDIFF(MONTH, 0, @WORK_MONTH + '-01') + 1, 0) - 2) != 30 AND RIGHT(@WORK_MON ,2) = '02' THEN '' ELSE '30' END");
                    sbQuery.Append(" , CASE WHEN DAY(DATEADD(MONTH, DATEDIFF(MONTH, 0, @WORK_MONTH + '-01') + 1, 0) - 1) != 31 THEN '' ELSE '31' END");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        StringBuilder sbWhere = new StringBuilder();
                        //sbWhere.Append(" WHERE PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

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

        public static DataTable TSTD_EMP_WORKTYPE_QUERY3(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT");
                    sbQuery.Append(" EW.PLT_CODE");
                    sbQuery.Append(" ,EW.EWT_NO");
                    sbQuery.Append(" ,EW.WORK_YEAR");
                    sbQuery.Append(" ,EW.EMP_CODE");
                    sbQuery.Append(" ,EWT.EWT_DATE");
                    sbQuery.Append(" ,EWT.EWT_TYPE");
                    sbQuery.Append(" FROM TSTD_EMP_WORKTYPE EW");
                    sbQuery.Append(" LEFT JOIN TSTD_EMP_WORKTYPE_DETAIL EWT");
                    sbQuery.Append(" ON EW.PLT_CODE = EWT.PLT_CODE");
                    sbQuery.Append(" AND EW.EWT_NO = EWT.EWT_NO");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        StringBuilder sbWhere = new StringBuilder();
                        sbWhere.Append(" WHERE EW.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                        sbWhere.Append(UTIL.GetWhere(row, "@EWT_NO", "EW.EWT_NO = @EWT_NO"));
                        sbWhere.Append(UTIL.GetWhere(row, "@WORK_YEAR", "EW.WORK_YEAR = @WORK_YEAR"));
                        sbWhere.Append(UTIL.GetWhere(row, "@EMP_CODE", "EW.EMP_CODE = @EMP_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@EWT_DATE", "EWT.EWT_DATE = @EWT_DATE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "EW.DATA_FLAG = @DATA_FLAG"));

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
