using BizExecute;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSTD
{
    public class TSTD_EMP_HOLIPLAN
    {
        public static DataTable TSTD_EMP_HOLIPLAN_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("  SELECT  ");
                    sbQuery.Append("  PLT_CODE ");
                    sbQuery.Append(" ,PLAN_NO ");
                    sbQuery.Append(" ,PLAN_YEAR ");
                    sbQuery.Append(" ,PLAN_SEQ ");
                    sbQuery.Append(" ,EMP_CODE ");
                    sbQuery.Append(" ,PLAN_STATUS ");
                    sbQuery.Append(" ,APP_EMP1 ");
                    sbQuery.Append(" ,APP_EMP_FLAG1 ");
                    sbQuery.Append(" ,APP_EMP2 ");
                    sbQuery.Append(" ,APP_EMP_FLAG2 ");
                    sbQuery.Append(" ,APP_EMP3 ");
                    sbQuery.Append(" ,APP_EMP_FLAG3 ");
                    sbQuery.Append(" ,APP_EMP4 ");
                    sbQuery.Append(" ,APP_EMP_FLAG4 ");
                    sbQuery.Append(" ,REG_DATE ");
                    sbQuery.Append(" ,REG_EMP ");
                    sbQuery.Append(" ,MDFY_DATE ");
                    sbQuery.Append(" ,MDFY_EMP ");
                    sbQuery.Append(" ,DEL_DATE ");
                    sbQuery.Append(" ,DEL_EMP ");
                    sbQuery.Append(" ,DATA_FLAG ");
                    sbQuery.Append("  FROM TSTD_EMP_HOLIPLAN  ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("  AND PLAN_NO = @PLAN_NO  ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PLAN_NO")) isHasColumn = false;

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

        public static DataTable TSTD_EMP_HOLIPLAN_SER2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("  SELECT  ");
                    sbQuery.Append("  PLT_CODE ");
                    sbQuery.Append(" ,PLAN_NO ");
                    sbQuery.Append(" ,PLAN_YEAR ");
                    sbQuery.Append(" ,PLAN_SEQ ");
                    sbQuery.Append(" ,EMP_CODE ");
                    sbQuery.Append(" ,PLAN_STATUS ");
                    sbQuery.Append(" ,APP_EMP1 ");
                    sbQuery.Append(" ,APP_EMP_FLAG1 ");
                    sbQuery.Append(" ,APP_EMP2 ");
                    sbQuery.Append(" ,APP_EMP_FLAG2 ");
                    sbQuery.Append(" ,APP_EMP3 ");
                    sbQuery.Append(" ,APP_EMP_FLAG3 ");
                    sbQuery.Append(" ,APP_EMP4 ");
                    sbQuery.Append(" ,APP_EMP_FLAG4 ");
                    sbQuery.Append(" ,REG_DATE ");
                    sbQuery.Append(" ,REG_EMP ");
                    sbQuery.Append(" ,MDFY_DATE ");
                    sbQuery.Append(" ,MDFY_EMP ");
                    sbQuery.Append(" ,DEL_DATE ");
                    sbQuery.Append(" ,DEL_EMP ");
                    sbQuery.Append(" ,DATA_FLAG ");
                    sbQuery.Append("  FROM TSTD_EMP_HOLIPLAN  ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("  AND PLAN_YEAR = @PLAN_YEAR  ");
                    sbQuery.Append("  AND EMP_CODE = @EMP_CODE  ");
                    sbQuery.Append("  AND DATA_FLAG = @DATA_FLAG  ");
                    sbQuery.Append("  ORDER BY PLAN_SEQ DESC  ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PLAN_YEAR")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "EMP_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "DATA_FLAG")) isHasColumn = false;

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

        public static void TSTD_EMP_HOLIPLAN_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" INSERT INTO TSTD_EMP_HOLIPLAN (  ");
                    sbQuery.Append("  PLT_CODE ");
                    sbQuery.Append(" ,PLAN_NO ");
                    sbQuery.Append(" ,PLAN_YEAR ");
                    sbQuery.Append(" ,PLAN_SEQ ");
                    sbQuery.Append(" ,EMP_CODE ");
                    sbQuery.Append(" ,YEAR_HOLI ");
                    sbQuery.Append(" ,USE_HOLI ");
                    sbQuery.Append(" ,POS_HOLI ");
                    sbQuery.Append(" ,REQ_HOLI ");
                    sbQuery.Append(" ,PLAN_STATUS ");
                    sbQuery.Append(" ,APP_EMP1 ");
                    sbQuery.Append(" ,APP_EMP_FLAG1 ");
                    sbQuery.Append(" ,APP_EMP2 ");
                    sbQuery.Append(" ,APP_EMP_FLAG2 ");
                    sbQuery.Append(" ,APP_EMP3 ");
                    sbQuery.Append(" ,APP_EMP_FLAG3 ");
                    sbQuery.Append(" ,APP_EMP4 ");
                    sbQuery.Append(" ,APP_EMP_FLAG4 ");
                    sbQuery.Append(" ,REG_DATE ");
                    sbQuery.Append(" ,REG_EMP ");
                    sbQuery.Append(" ,DATA_FLAG ");
                    sbQuery.Append("  ) VALUES (  ");
                    sbQuery.Append("  @PLT_CODE ");
                    sbQuery.Append(" ,@PLAN_NO ");
                    sbQuery.Append(" ,@PLAN_YEAR ");
                    sbQuery.Append(" ,@PLAN_SEQ ");
                    sbQuery.Append(" ,@EMP_CODE ");
                    sbQuery.Append(" ,@YEAR_HOLI ");
                    sbQuery.Append(" ,@USE_HOLI ");
                    sbQuery.Append(" ,@POS_HOLI ");
                    sbQuery.Append(" ,@REQ_HOLI ");
                    sbQuery.Append(" ,@PLAN_STATUS ");
                    sbQuery.Append(" ,@APP_EMP1 ");
                    sbQuery.Append(" ,@APP_EMP_FLAG1 ");
                    sbQuery.Append(" ,@APP_EMP2 ");
                    sbQuery.Append(" ,@APP_EMP_FLAG2 ");
                    sbQuery.Append(" ,@APP_EMP3 ");
                    sbQuery.Append(" ,@APP_EMP_FLAG3 ");
                    sbQuery.Append(" ,@APP_EMP4 ");
                    sbQuery.Append(" ,@APP_EMP_FLAG4 ");
                    sbQuery.Append(" , GETDATE()");
                    sbQuery.Append(" , " + UTIL.GetValidValue(ConnInfo.UserID));
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

        public static void TSTD_EMP_HOLIPLAN_UPD(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TSTD_EMP_HOLIPLAN SET  ");
                    sbQuery.Append("  PLAN_STATUS = @PLAN_STATUS ");
                    sbQuery.Append(" ,APP_EMP1 = @APP_EMP1 ");
                    sbQuery.Append(" ,APP_EMP_FLAG1 = @APP_EMP_FLAG1 ");
                    sbQuery.Append(" ,APP_EMP2 = @APP_EMP2 ");
                    sbQuery.Append(" ,APP_EMP_FLAG2 = @APP_EMP_FLAG2 ");
                    sbQuery.Append(" ,APP_EMP3 = @APP_EMP3 ");
                    sbQuery.Append(" ,APP_EMP_FLAG3 = @APP_EMP_FLAG3 ");
                    sbQuery.Append(" ,APP_EMP4 = @APP_EMP4 ");
                    sbQuery.Append(" ,APP_EMP_FLAG4 = @APP_EMP_FLAG4 ");
                    sbQuery.Append(" ,MDFY_DATE = GETDATE()");
                    sbQuery.Append(" ,MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" ,DATA_FLAG = @DATA_FLAG ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append("  AND PLAN_NO = @PLAN_NO ");
                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PLAN_NO")) isHasColumn = false;

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

        public static void TSTD_EMP_HOLIPLAN_UPD2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TSTD_EMP_HOLIPLAN SET  ");
                    sbQuery.Append("  YEAR_HOLI = @YEAR_HOLI ");
                    sbQuery.Append(" ,USE_HOLI = @USE_HOLI ");
                    sbQuery.Append(" ,POS_HOLI = @POS_HOLI ");
                    sbQuery.Append(" ,REQ_HOLI = @REQ_HOLI ");
                    sbQuery.Append(" ,MDFY_DATE = GETDATE()");
                    sbQuery.Append(" ,MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" ,DATA_FLAG = @DATA_FLAG ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append("  AND PLAN_NO = @PLAN_NO ");
                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PLAN_NO")) isHasColumn = false;

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


        public static void TSTD_EMP_HOLIPLAN_UDE(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TSTD_EMP_HOLIPLAN SET  ");
                    sbQuery.Append("  DEL_DATE = GETDATE()");
                    sbQuery.Append(" ,DEL_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" ,DATA_FLAG = @DATA_FLAG ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append("  AND PLAN_NO = @PLAN_NO ");
                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PLAN_NO")) isHasColumn = false;

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

    public class TSTD_EMP_HOLIPLAN_QUERY
    {
        public static DataTable TSTD_EMP_HOLIPLAN_QUERY1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT");
                    sbQuery.Append(" EHP.PLT_CODE");
                    sbQuery.Append(" ,EHP.PLAN_NO");
                    sbQuery.Append(" ,EHP.PLAN_YEAR");
                    sbQuery.Append(" ,EHP.PLAN_SEQ");
                    sbQuery.Append(" ,EHP.EMP_CODE");
                    sbQuery.Append(" ,E.EMP_NAME");
                    sbQuery.Append(" ,E.ORG_CODE");
                    sbQuery.Append(" ,O.ORG_NAME");
                    sbQuery.Append(" ,E.EMP_TITLE");
                    sbQuery.Append(" ,E.HIRE_DATE");
                    sbQuery.Append(" ,EHP.YEAR_HOLI");
                    sbQuery.Append(" ,EHP.USE_HOLI");
                    sbQuery.Append(" ,EHP.POS_HOLI");
                    sbQuery.Append(" ,EHP.REQ_HOLI");
                    sbQuery.Append(" ,EHP.PLAN_STATUS");
                    //sbQuery.Append(" ,EHP.APP_EMP1");
                    //sbQuery.Append(" ,EHP.APP_EMP_FLAG1");
                    //sbQuery.Append(" ,EHP.APP_EMP2");
                    //sbQuery.Append(" ,EHP.APP_EMP_FLAG2");
                    //sbQuery.Append(" ,EHP.APP_EMP3");
                    //sbQuery.Append(" ,EHP.APP_EMP_FLAG3");
                    //sbQuery.Append(" ,EHP.APP_EMP4");
                    //sbQuery.Append(" ,EHP.APP_EMP_FLAG4");

                    sbQuery.Append(" ,ISNULL(EHP.APP_EMP1,APP.APP_EMP1) AS APP_EMP1 ");
                    sbQuery.Append(" ,ISNULL(EHP.APP_EMP_FLAG1,'0') AS APP_EMP_FLAG1 ");

                    sbQuery.Append(" ,ISNULL(EHP.APP_EMP2,APP.APP_EMP2) AS APP_EMP2 ");
                    sbQuery.Append(" ,ISNULL(EHP.APP_EMP_FLAG2,'0') AS APP_EMP_FLAG2 ");

                    sbQuery.Append(" ,ISNULL(EHP.APP_EMP3,APP.APP_EMP3) AS APP_EMP3 ");
                    sbQuery.Append(" ,ISNULL(EHP.APP_EMP_FLAG3,'0') AS APP_EMP_FLAG3 ");

                    sbQuery.Append(" ,ISNULL(EHP.APP_EMP4,APP.APP_EMP4) AS APP_EMP4 ");
                    sbQuery.Append(" ,ISNULL(EHP.APP_EMP_FLAG4,'0') AS APP_EMP_FLAG4 ");

                    sbQuery.Append(" ,EHP.REG_DATE");
                    sbQuery.Append(" ,EHP.REG_EMP");
                    sbQuery.Append(" ,EHP.MDFY_DATE");
                    sbQuery.Append(" ,EHP.MDFY_EMP");
                    sbQuery.Append(" ,EHP.DEL_DATE");
                    sbQuery.Append(" ,EHP.DEL_EMP");
                    sbQuery.Append(" ,EHP.DATA_FLAG");
                    sbQuery.Append(" FROM TSTD_EMP_HOLIPLAN EHP");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE E");
                    sbQuery.Append(" ON EHP.PLT_CODE = E.PLT_CODE");
                    sbQuery.Append(" AND EHP.EMP_CODE = E.EMP_CODE");

                    sbQuery.Append(" LEFT JOIN TSTD_APP_EMP APP ");
                    sbQuery.Append(" ON EHP.PLT_CODE = APP.PLT_CODE");
                    sbQuery.Append(" AND APP.APP_TYPE = 'HOL' ");

                    sbQuery.Append(" LEFT JOIN TSTD_ORG O ");
                    sbQuery.Append(" ON E.PLT_CODE = O.PLT_CODE");
                    sbQuery.Append(" AND E.ORG_CODE = O.ORG_CODE ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        StringBuilder sbWhere = new StringBuilder();
                        sbWhere.Append(" WHERE EHP.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                        sbWhere.Append(UTIL.GetWhere(row, "@PLAN_NO", "EHP.PLAN_NO = @PLAN_NO"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PLAN_YEAR", "EHP.PLAN_YEAR = @PLAN_YEAR"));
                        sbWhere.Append(UTIL.GetWhere(row, "@EMP_CODE", "EHP.EMP_CODE = @EMP_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "EHP.DATA_FLAG = @DATA_FLAG"));

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

        public static DataTable TSTD_EMP_HOLIPLAN_QUERY2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT");
                    sbQuery.Append(" @PLT_CODE AS PLT_CODE");
                    sbQuery.Append(" ,@PLAN_MON AS PLAN_MONTH");
                    sbQuery.Append(" , LEFT(@PLAN_MONTH,4) + '.' + SUBSTRING(@PLAN_MONTH, 6, 2) + '.01~' + SUBSTRING(@PLAN_MONTH, 6, 2) + '.15' AS DATE_PERIOD");
                    sbQuery.Append(" , '1' AS '1', '2' AS '2', '3' AS '3', '4' AS '4'");
                    sbQuery.Append(" , '5' AS '5', '6' AS '6', '7' AS '7', '8' AS '8'");
                    sbQuery.Append(" , '9' AS '9', '10' AS '10', '11' AS '11', '12' AS '12'");
                    sbQuery.Append(" , '13' AS '13', '14' AS '14', '15' AS '15', '' AS '16'");
                    sbQuery.Append(" UNION ALL");
                    sbQuery.Append(" SELECT");
                    sbQuery.Append(" @PLT_CODE AS PLT_CODE");
                    sbQuery.Append(" ,@PLAN_MON");
                    sbQuery.Append(" , LEFT(@PLAN_MONTH,4) + '.' + SUBSTRING(@PLAN_MONTH, 6, 2) + '.16~' + SUBSTRING(@PLAN_MONTH, 6, 2) + '.' +  RIGHT(CONVERT(VARCHAR(10), DATEADD(MONTH, DATEDIFF(MONTH, 0, '2021-05' + '-01') + 1, 0) - 1, 23), 2)");
                    sbQuery.Append(" , '16', '17', '18', '19'");
                    sbQuery.Append(" , '20', '21', '22', '23'");
                    sbQuery.Append(" , '24', '25', '26', '27'");
                    sbQuery.Append(" , '28'");
                    sbQuery.Append(" , CASE WHEN DAY(DATEADD(MONTH, DATEDIFF(MONTH, 0, @PLAN_MONTH + '-01') + 1, 0) - 3) != 29 AND RIGHT(@PLAN_MON ,2) = '02' THEN '' ELSE '29' END");
                    sbQuery.Append(" , CASE WHEN DAY(DATEADD(MONTH, DATEDIFF(MONTH, 0, @PLAN_MONTH + '-01') + 1, 0) - 2) != 30 AND RIGHT(@PLAN_MON ,2) = '02' THEN '' ELSE '30' END");
                    sbQuery.Append(" , CASE WHEN DAY(DATEADD(MONTH, DATEDIFF(MONTH, 0, @PLAN_MONTH + '-01') + 1, 0) - 1) != 31 THEN '' ELSE '31' END");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        StringBuilder sbWhere = new StringBuilder();
                        //sbWhere.Append(" WHERE PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString() ,row).Copy();

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

        public static DataTable TSTD_EMP_HOLIPLAN_QUERY3(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT");
                    sbQuery.Append(" EHP.PLT_CODE");
                    sbQuery.Append(" ,EHP.PLAN_NO");
                    sbQuery.Append(" ,EHP.PLAN_YEAR");
                    sbQuery.Append(" ,EHP.PLAN_SEQ");
                    sbQuery.Append(" ,EHP.EMP_CODE");
                    sbQuery.Append(" ,E.EMP_NAME");
                    sbQuery.Append(" ,E.ORG_CODE");
                    sbQuery.Append(" ,O.ORG_NAME");
                    sbQuery.Append(" ,E.EMP_TITLE");
                    sbQuery.Append(" ,E.HIRE_DATE");
                    sbQuery.Append(" ,EHP.PLAN_STATUS");

                    sbQuery.Append(" ,ISNULL(EHP.APP_EMP1,APP.APP_EMP1) AS APP_EMP1 ");
                    sbQuery.Append(" ,ISNULL(EHP.APP_EMP_FLAG1,'0') AS APP_EMP_FLAG1 ");

                    sbQuery.Append(" ,ISNULL(EHP.APP_EMP2,APP.APP_EMP2) AS APP_EMP2 ");
                    sbQuery.Append(" ,ISNULL(EHP.APP_EMP_FLAG2,'0') AS APP_EMP_FLAG2 ");

                    sbQuery.Append(" ,ISNULL(EHP.APP_EMP3,APP.APP_EMP3) AS APP_EMP3 ");
                    sbQuery.Append(" ,ISNULL(EHP.APP_EMP_FLAG3,'0') AS APP_EMP_FLAG3 ");

                    sbQuery.Append(" ,ISNULL(EHP.APP_EMP4,APP.APP_EMP4) AS APP_EMP4 ");
                    sbQuery.Append(" ,ISNULL(EHP.APP_EMP_FLAG4,'0') AS APP_EMP_FLAG4 ");

                    sbQuery.Append(" ,EHP.REG_DATE");
                    sbQuery.Append(" ,EHP.REG_EMP");
                    sbQuery.Append(" ,EHP.MDFY_DATE");
                    sbQuery.Append(" ,EHP.MDFY_EMP");
                    sbQuery.Append(" ,EHP.DEL_DATE");
                    sbQuery.Append(" ,EHP.DEL_EMP");
                    sbQuery.Append(" ,EHP.DATA_FLAG");
                    sbQuery.Append(" FROM TSTD_EMP_HOLIPLAN EHP");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE E");
                    sbQuery.Append(" ON EHP.PLT_CODE = E.PLT_CODE");
                    sbQuery.Append(" AND EHP.EMP_CODE = E.EMP_CODE");

                    sbQuery.Append(" LEFT JOIN TSTD_APP_EMP APP ");
                    sbQuery.Append(" ON EHP.PLT_CODE = APP.PLT_CODE");
                    sbQuery.Append(" AND APP.APP_TYPE = 'HOL' ");

                    sbQuery.Append(" LEFT JOIN TSTD_ORG O ");
                    sbQuery.Append(" ON E.PLT_CODE = O.PLT_CODE");
                    sbQuery.Append(" AND E.ORG_CODE = O.ORG_CODE ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        StringBuilder sbWhere = new StringBuilder();
                        sbWhere.Append(" WHERE EHP.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                        sbWhere.Append(UTIL.GetWhere(row, "@PLAN_NO", "EHP.PLAN_NO = @PLAN_NO"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PLAN_YEAR", "EHP.PLAN_YEAR = @PLAN_YEAR"));
                        sbWhere.Append(UTIL.GetWhere(row, "@EMP_CODE", "EHP.EMP_CODE = @EMP_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "EHP.DATA_FLAG = @DATA_FLAG"));

                        string sQuery = "((ISNULL(EHP.APP_EMP1,APP.APP_EMP1) = @REG_EMP AND ISNULL(EHP.APP_EMP_FLAG1,'0') = '0')";
                        sQuery += " OR (ISNULL(EHP.APP_EMP2,APP.APP_EMP2) = @REG_EMP AND ISNULL(EHP.APP_EMP_FLAG1,'0') = '1' AND ISNULL(EHP.APP_EMP_FLAG2,'0') = '0')";
                        sQuery += " OR (ISNULL(EHP.APP_EMP3,APP.APP_EMP3) = @REG_EMP AND ISNULL(EHP.APP_EMP_FLAG1,'0') = '1' AND ISNULL(EHP.APP_EMP_FLAG2,'0') = '1' AND ISNULL(EHP.APP_EMP_FLAG3,'0') = '0')";
                        sQuery += " OR (ISNULL(EHP.APP_EMP4,APP.APP_EMP4) = @REG_EMP AND ISNULL(EHP.APP_EMP_FLAG1,'0') = '1' AND ISNULL(EHP.APP_EMP_FLAG2,'0') = '1' AND ISNULL(EHP.APP_EMP_FLAG3,'0') = '1' AND ISNULL(EHP.APP_EMP_FLAG4,'0') = '0'))";

                        sbWhere.Append(UTIL.GetWhere(row, "@REG_EMP", sQuery));

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

        public static DataTable TSTD_EMP_HOLIPLAN_QUERY4(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT");
                    sbQuery.Append(" EHP.PLT_CODE");
                    sbQuery.Append(" ,EHP.PLAN_NO");
                    sbQuery.Append(" ,EHP.PLAN_YEAR");
                    sbQuery.Append(" ,EHP.PLAN_SEQ");
                    sbQuery.Append(" ,EHP.EMP_CODE");
                    sbQuery.Append(" ,E.EMP_NAME");
                    sbQuery.Append(" ,E.ORG_CODE");
                    sbQuery.Append(" ,O.ORG_NAME");
                    sbQuery.Append(" ,E.EMP_TITLE");
                    sbQuery.Append(" ,E.HIRE_DATE");
                    sbQuery.Append(" ,EHP.PLAN_STATUS");

                    sbQuery.Append(" ,ISNULL(EHP.APP_EMP1,APP.APP_EMP1) AS APP_EMP1 ");
                    sbQuery.Append(" ,ISNULL(EHP.APP_EMP_FLAG1,'0') AS APP_EMP_FLAG1 ");

                    sbQuery.Append(" ,ISNULL(EHP.APP_EMP2,APP.APP_EMP2) AS APP_EMP2 ");
                    sbQuery.Append(" ,ISNULL(EHP.APP_EMP_FLAG2,'0') AS APP_EMP_FLAG2 ");

                    sbQuery.Append(" ,ISNULL(EHP.APP_EMP3,APP.APP_EMP3) AS APP_EMP3 ");
                    sbQuery.Append(" ,ISNULL(EHP.APP_EMP_FLAG3,'0') AS APP_EMP_FLAG3 ");

                    sbQuery.Append(" ,ISNULL(EHP.APP_EMP4,APP.APP_EMP4) AS APP_EMP4 ");
                    sbQuery.Append(" ,ISNULL(EHP.APP_EMP_FLAG4,'0') AS APP_EMP_FLAG4 ");

                    sbQuery.Append(" ,EHP.REG_DATE");
                    sbQuery.Append(" ,EHP.REG_EMP");
                    sbQuery.Append(" ,EHP.MDFY_DATE");
                    sbQuery.Append(" ,EHP.MDFY_EMP");
                    sbQuery.Append(" ,EHP.DEL_DATE");
                    sbQuery.Append(" ,EHP.DEL_EMP");
                    sbQuery.Append(" ,EHP.DATA_FLAG");
                    sbQuery.Append(" FROM TSTD_EMP_HOLIPLAN EHP");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE E");
                    sbQuery.Append(" ON EHP.PLT_CODE = E.PLT_CODE");
                    sbQuery.Append(" AND EHP.EMP_CODE = E.EMP_CODE");

                    sbQuery.Append(" LEFT JOIN TSTD_APP_EMP APP ");
                    sbQuery.Append(" ON EHP.PLT_CODE = APP.PLT_CODE");
                    sbQuery.Append(" AND APP.APP_TYPE = 'HOL' ");

                    sbQuery.Append(" LEFT JOIN TSTD_ORG O ");
                    sbQuery.Append(" ON E.PLT_CODE = O.PLT_CODE");
                    sbQuery.Append(" AND E.ORG_CODE = O.ORG_CODE ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        StringBuilder sbWhere = new StringBuilder();
                        sbWhere.Append(" WHERE EHP.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                        sbWhere.Append(UTIL.GetWhere(row, "@PLAN_NO", "EHP.PLAN_NO = @PLAN_NO"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PLAN_YEAR", "EHP.PLAN_YEAR = @PLAN_YEAR"));
                        sbWhere.Append(UTIL.GetWhere(row, "@EMP_CODE", "EHP.EMP_CODE = @EMP_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "EHP.DATA_FLAG = @DATA_FLAG"));

                        string sQuery = "((ISNULL(EHP.APP_EMP1,APP.APP_EMP1) = @REG_EMP AND ISNULL(EHP.APP_EMP_FLAG1,'0') = '1' AND ISNULL(EHP.APP_EMP_FLAG2,'0') = '0' AND ISNULL(EHP.APP_EMP_FLAG3,'0') = '0' AND ISNULL(EHP.APP_EMP_FLAG4,'0') = '0' )";
                        sQuery += " OR (ISNULL(EHP.APP_EMP2,APP.APP_EMP2) = @REG_EMP AND ISNULL(EHP.APP_EMP_FLAG2,'0') = '1' AND ISNULL(EHP.APP_EMP_FLAG3,'0') = '0' AND ISNULL(EHP.APP_EMP_FLAG4,'0') = '0')";
                        sQuery += " OR (ISNULL(EHP.APP_EMP3,APP.APP_EMP3) = @REG_EMP AND ISNULL(EHP.APP_EMP_FLAG3,'0') = '1' AND ISNULL(EHP.APP_EMP_FLAG4,'0') = '0')";
                        sQuery += " OR (ISNULL(EHP.APP_EMP4,APP.APP_EMP4) = @REG_EMP AND ISNULL(EHP.APP_EMP_FLAG4,'0') = '1'))";

                        sbWhere.Append(UTIL.GetWhere(row, "@REG_EMP", sQuery));

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

        public static DataTable TSTD_EMP_HOLIPLAN_QUERY5(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT");
                    sbQuery.Append(" EHP.PLT_CODE");
                    sbQuery.Append(" ,EHP.PLAN_NO");
                    sbQuery.Append(" ,EHP.PLAN_YEAR");
                    sbQuery.Append(" ,EHP.PLAN_SEQ");
                    sbQuery.Append(" ,EHP.EMP_CODE");
                    sbQuery.Append(" ,E.EMP_NAME");
                    sbQuery.Append(" ,E.ORG_CODE");
                    sbQuery.Append(" ,O.ORG_NAME");
                    sbQuery.Append(" ,E.EMP_TITLE");
                    sbQuery.Append(" ,E.HIRE_DATE");
                    sbQuery.Append(" ,EHP.PLAN_STATUS");

                    sbQuery.Append(" ,ISNULL(EHP.APP_EMP1,APP.APP_EMP1) AS APP_EMP1 ");
                    sbQuery.Append(" ,ISNULL(EHP.APP_EMP_FLAG1,'0') AS APP_EMP_FLAG1 ");

                    sbQuery.Append(" ,ISNULL(EHP.APP_EMP2,APP.APP_EMP2) AS APP_EMP2 ");
                    sbQuery.Append(" ,ISNULL(EHP.APP_EMP_FLAG2,'0') AS APP_EMP_FLAG2 ");

                    sbQuery.Append(" ,ISNULL(EHP.APP_EMP3,APP.APP_EMP3) AS APP_EMP3 ");
                    sbQuery.Append(" ,ISNULL(EHP.APP_EMP_FLAG3,'0') AS APP_EMP_FLAG3 ");

                    sbQuery.Append(" ,ISNULL(EHP.APP_EMP4,APP.APP_EMP4) AS APP_EMP4 ");
                    sbQuery.Append(" ,ISNULL(EHP.APP_EMP_FLAG4,'0') AS APP_EMP_FLAG4 ");

                    sbQuery.Append(" ,EHP.REG_DATE");
                    sbQuery.Append(" ,EHP.REG_EMP");
                    sbQuery.Append(" ,EHP.MDFY_DATE");
                    sbQuery.Append(" ,EHP.MDFY_EMP");
                    sbQuery.Append(" ,EHP.DEL_DATE");
                    sbQuery.Append(" ,EHP.DEL_EMP");
                    sbQuery.Append(" ,EHP.DATA_FLAG");
                    sbQuery.Append(" FROM TSTD_EMP_HOLIPLAN EHP");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE E");
                    sbQuery.Append(" ON EHP.PLT_CODE = E.PLT_CODE");
                    sbQuery.Append(" AND EHP.EMP_CODE = E.EMP_CODE");

                    sbQuery.Append(" LEFT JOIN TSTD_APP_EMP APP ");
                    sbQuery.Append(" ON EHP.PLT_CODE = APP.PLT_CODE");
                    sbQuery.Append(" AND APP.APP_TYPE = 'HOL' ");

                    sbQuery.Append(" LEFT JOIN TSTD_ORG O ");
                    sbQuery.Append(" ON E.PLT_CODE = O.PLT_CODE");
                    sbQuery.Append(" AND E.ORG_CODE = O.ORG_CODE ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        StringBuilder sbWhere = new StringBuilder();
                        sbWhere.Append(" WHERE EHP.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                        sbWhere.Append(UTIL.GetWhere(row, "@PLAN_NO", "EHP.PLAN_NO = @PLAN_NO"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PLAN_YEAR", "EHP.PLAN_YEAR = @PLAN_YEAR"));
                        sbWhere.Append(UTIL.GetWhere(row, "@EMP_CODE", "EHP.EMP_CODE = @EMP_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "EHP.DATA_FLAG = @DATA_FLAG"));

                        string sQuery = "((ISNULL(EHP.APP_EMP1,APP.APP_EMP1) = @REG_EMP AND ISNULL(EHP.APP_EMP_FLAG1,'0') = '2' AND ISNULL(EHP.APP_EMP_FLAG2,'0') = '0' AND ISNULL(EHP.APP_EMP_FLAG3,'0') = '0' AND ISNULL(EHP.APP_EMP_FLAG4,'0') = '0' )";
                        sQuery += " OR (ISNULL(EHP.APP_EMP2,APP.APP_EMP2) = @REG_EMP AND ISNULL(EHP.APP_EMP_FLAG2,'0') = '2' AND ISNULL(EHP.APP_EMP_FLAG3,'0') = '0' AND ISNULL(EHP.APP_EMP_FLAG4,'0') = '0')";
                        sQuery += " OR (ISNULL(EHP.APP_EMP3,APP.APP_EMP3) = @REG_EMP AND ISNULL(EHP.APP_EMP_FLAG3,'0') = '2' AND ISNULL(EHP.APP_EMP_FLAG4,'0') = '0')";
                        sQuery += " OR (ISNULL(EHP.APP_EMP4,APP.APP_EMP4) = @REG_EMP AND ISNULL(EHP.APP_EMP_FLAG4,'0') = '2'))";

                        sbWhere.Append(UTIL.GetWhere(row, "@REG_EMP", sQuery));

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
