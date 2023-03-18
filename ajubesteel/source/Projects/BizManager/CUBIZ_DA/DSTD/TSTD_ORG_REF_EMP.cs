using BizExecute;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSTD
{
    public class TSTD_ORG_REF_EMP
    {
        public static DataTable TSTD_ORG_REF_EMP_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT");
                    sbQuery.Append(" PLT_CODE");
                    sbQuery.Append(" ,ORG_CODE");
                    sbQuery.Append(" ,REF_EMP_CODE");
                    sbQuery.Append(" ,REG_DATE");
                    sbQuery.Append(" ,REG_EMP");
                    sbQuery.Append(" ,DATA_FLAG");
                    sbQuery.Append(" FROM TSHP_WORK_MNG_REF");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("  AND ORG_CODE = @ORG_CODE  ");
                    sbQuery.Append("  AND REF_EMP_CODE = @REF_EMP_CODE  ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "ORG_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "REF_EMP_CODE")) isHasColumn = false;

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

        public static DataTable TSTD_ORG_REF_EMP_SER2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT");
                    sbQuery.Append(" PLT_CODE");
                    sbQuery.Append(" ,ORG_CODE");
                    sbQuery.Append(" ,REF_EMP_CODE");
                    sbQuery.Append(" ,REG_DATE");
                    sbQuery.Append(" ,REG_EMP");
                    sbQuery.Append(" ,DATA_FLAG");
                    sbQuery.Append(" FROM TSHP_WORK_MNG_REF");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("  AND ORG_CODE = @ORG_CODE  ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "ORG_CODE")) isHasColumn = false;

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

        public static void TSTD_ORG_REF_EMP_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" INSERT INTO TSTD_ORG_REF_EMP (");
                    sbQuery.Append(" PLT_CODE");
                    sbQuery.Append(" ,ORG_CODE");
                    sbQuery.Append(" ,REF_EMP_CODE");
                    sbQuery.Append(" ,REG_DATE");
                    sbQuery.Append(" ,REG_EMP");
                    sbQuery.Append(" ,DATA_FLAG");
                    sbQuery.Append(" ) VALUES (");
                    sbQuery.Append(" @PLT_CODE");
                    sbQuery.Append(" ,@ORG_CODE");
                    sbQuery.Append(" ,@EMP_CODE");
                    sbQuery.Append(" ,GETDATE() ");
                    sbQuery.Append(" ," + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" ,@DATA_FLAG");
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

        public static void TSTD_ORG_REF_EMP_UPD(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TSTD_ORG_REF_EMP SET");
                    sbQuery.Append(" DATA_FLAG = @DATA_FLAG");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND ORG_CODE = @ORG_CODE");
                    sbQuery.Append(" AND REF_EMP_CODE = @REF_EMP_CODE");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "ORG_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "REF_EMP_CODE")) isHasColumn = false;

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


        public static void TSTD_ORG_REF_EMP_DEL(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" DELETE FROM TSTD_ORG_REF_EMP ");
                    sbQuery.Append("  WHERE ORG_CODE = @ORG_CODE");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bizExecute.executeUpdateQuery(sbQuery.ToString(), row);
                    }
                }
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }
    }




    public class TSTD_ORG_REF_EMP_QUERY
    {
        public static DataTable TSTD_ORG_REF_EMP_QUERY1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT");
                    sbQuery.Append(" RE.PLT_CODE");
                    sbQuery.Append(" ,RE.REF_EMP_CODE AS EMP_CODE");
                    sbQuery.Append(" ,E.EMP_NAME");
                    sbQuery.Append(" ,RE.ORG_CODE");
                    sbQuery.Append(" ,O.ORG_NAME");
                    sbQuery.Append(" FROM TSTD_ORG_REF_EMP RE");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE E");
                    sbQuery.Append(" ON RE.PLT_CODE = E.PLT_CODE");
                    sbQuery.Append(" AND RE.REF_EMP_CODE = E.EMP_CODE");
                    sbQuery.Append(" LEFT JOIN TSTD_ORG O");
                    sbQuery.Append(" ON E.PLT_CODE = O.PLT_CODE");
                    sbQuery.Append(" AND E.ORG_CODE = O.ORG_CODE");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder();

                        sbWhere.Append(" WHERE RE.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@EMP_CODE", "RE.EMP_CODE = @EMP_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@REF_EMP_CODE", "RE.REF_EMP_CODE = @REF_EMP_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@ORG_CODE", "RE.ORG_CODE = @ORG_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "RE.DATA_FLAG = @DATA_FLAG"));

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

        public static DataTable TSTD_ORG_REF_EMP_QUERY2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT");
                    sbQuery.Append(" WM.PLT_CODE");
                    sbQuery.Append(" ,WM.WORK_ID");
                    sbQuery.Append(" ,WM.WORK_CODE");
                    sbQuery.Append(" ,WC.WORK_NAME");
                    sbQuery.Append(" ,WM.REQ_STATUS");
                    sbQuery.Append(" ,WM.EMP_CODE");
                    sbQuery.Append(" ,E.EMP_NAME");
                    sbQuery.Append(" ,E.ORG_CODE");
                    sbQuery.Append(" ,O.ORG_NAME");
                    sbQuery.Append(" ,WM.STR_REQ_DATE");
                    sbQuery.Append(" ,WM.REQ_DATE");
                    sbQuery.Append(" ,WM.REQ_START_DATE");
                    sbQuery.Append(" ,LEFT(CONVERT(VARCHAR(8), WM.REQ_START_DATE, 112),6) AS REQ_START_MONTH");
                    sbQuery.Append(" ,WM.REQ_END_DATE");
                    sbQuery.Append(" ,WM.REQ_TIME");
                    sbQuery.Append(" ,WM.CC_EMP");
                    sbQuery.Append(" ,WM.REQ_AMPM");
                    sbQuery.Append(" ,WM.REQ_SCOMMENT");
                    sbQuery.Append(" ,WM.APP_SCOMMENT");
                    sbQuery.Append(" ,WM.REQ_TIME");
                    sbQuery.Append(" ,CONVERT(decimal(18,1), REQ_TIME / 60) AS REQ_HOUR");
                    sbQuery.Append(" ,CASE WHEN WM.WORK_CODE = 'W05' THEN 1 WHEN WM.WORK_CODE = 'W06' THEN 0.5 ELSE NULL END AS REQ_DAY");
                    sbQuery.Append(" ,WM.IS_DIR_IN");
                    sbQuery.Append(" ,WM.IS_DIR_OUT");
                    sbQuery.Append(" ,WM.OUT_TYPE");
                    sbQuery.Append(" ,WM.OUT_VEN_CODE");
                    sbQuery.Append(" ,V.VEN_NAME AS OUT_VEN_NAME");
                    sbQuery.Append(" ,WM.REJECT_DATE");
                    sbQuery.Append(" ,WM.REJECT_REASON");
                    sbQuery.Append(" ,WC.IS_UPD");

                    sbQuery.Append(" ,WM.REG_DATE");
                    sbQuery.Append(" ,WM.REG_EMP");
                    sbQuery.Append(" ,RE.EMP_NAME AS REG_EMP_NAME");
                    sbQuery.Append(" ,WM.MDFY_DATE");
                    sbQuery.Append(" ,WM.MDFY_EMP");
                    sbQuery.Append(" ,ME.EMP_NAME AS MDFY_EMP_NAME");

                    sbQuery.Append(" ,WM.DEL_DATE");
                    sbQuery.Append(" ,WM.DEL_EMP");
                    sbQuery.Append(" ,WM.DATA_FLAG");
                    sbQuery.Append(" FROM TSHP_WORK_MNG_EMP REF");
                    sbQuery.Append(" LEFT JOIN TSHP_WORK_MNG WM");
                    sbQuery.Append(" ON REF.PLT_CODE = WM.PLT_CODE");
                    sbQuery.Append(" AND REF.WORK_ID = WM.WORK_ID");

                    sbQuery.Append(" LEFT JOIN TSTD_WORKCODE WC");
                    sbQuery.Append(" ON WM.PLT_CODE = WC.PLT_CODE");
                    sbQuery.Append(" AND WM.WORK_CODE = WC.WORK_CODE");

                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE E");
                    sbQuery.Append(" ON WM.PLT_CODE = E.PLT_CODE");
                    sbQuery.Append(" AND WM.EMP_CODE = E.EMP_CODE");

                    sbQuery.Append(" LEFT JOIN TSTD_VENDOR V");
                    sbQuery.Append(" ON WM.PLT_CODE = V.PLT_CODE");
                    sbQuery.Append(" AND WM.OUT_VEN_CODE = V.VEN_CODE");

                    sbQuery.Append(" LEFT JOIN TSTD_ORG O");
                    sbQuery.Append(" ON E.PLT_CODE = O.PLT_CODE");
                    sbQuery.Append(" AND E.ORG_CODE = O.ORG_CODE");

                    sbQuery.Append(" LEFT JOIN TSTD_APP_EMP APP ");
                    sbQuery.Append(" ON WM.PLT_CODE = APP.PLT_CODE");
                    sbQuery.Append(" AND APP.APP_TYPE = 'ATD' ");

                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE RE");
                    sbQuery.Append(" ON WM.PLT_CODE = RE.PLT_CODE");
                    sbQuery.Append(" AND WM.REG_EMP = RE.EMP_CODE");

                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE ME");
                    sbQuery.Append(" ON WM.PLT_CODE = ME.PLT_CODE");
                    sbQuery.Append(" AND WM.MDFY_EMP = ME.EMP_CODE");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder();

                        sbWhere.Append(" WHERE WM.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@WORK_ID", "WM.WORK_ID = @WORK_ID"));
                        sbWhere.Append(UTIL.GetWhere(row, "@REQ_STATUS", "WM.REQ_STATUS = @REQ_STATUS"));
                        sbWhere.Append(UTIL.GetWhere(row, "@EMP_CODE", "REF.EMP_CODE = @EMP_CODE"));
                        //sbWhere.Append(UTIL.GetWhere(row, "@S_REQ_DATE,@E_REQ_DATE", "CONVERT(VARCHAR(8), WM.REQ_DATE, 112) BETWEEN @S_REQ_DATE AND @E_REQ_DATE"));
                        //sbWhere.Append(UTIL.GetWhere(row, "@REQ_YEAR", "LEFT(CONVERT(VARCHAR(8), WM.REQ_DATE, 112),4) = @REQ_YEAR"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_REQ_DATE,@E_REQ_DATE", "WM.STR_REQ_DATE BETWEEN @S_REQ_DATE AND @E_REQ_DATE"));

                        sbWhere.Append(UTIL.GetWhere(row, "@S_REQ_DATETIME,@E_REQ_DATETIME", "CONVERT(VARCHAR(8), WM.REQ_DATE, 112) BETWEEN @S_REQ_DATETIME AND @E_REQ_DATETIME"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_REQ_START_DATE,@E_REQ_START_DATE", "CONVERT(VARCHAR(8), WM.REQ_START_DATE, 112) BETWEEN @S_REQ_START_DATE AND @E_REQ_START_DATE"));

                        sbWhere.Append(UTIL.GetWhere(row, "@WORK_CODE_IN", "WM.WORK_CODE IN @WORK_CODE_IN", UTIL.SqlCondType.IN));

                        sbWhere.Append(UTIL.GetWhere(row, "@REQ_YEAR", "LEFT(WM.STR_REQ_DATE,4) = @REQ_YEAR"));
                        sbWhere.Append(UTIL.GetWhere(row, "@WORK_CODE", "WM.WORK_CODE = @WORK_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@IS_OUT", "WC.IS_OUT = '1'"));
                        sbWhere.Append(UTIL.GetWhere(row, "@IS_POPUP", "ISNULL(REF.IS_POPUP, 0) = @IS_POPUP"));
                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "WM.DATA_FLAG = @DATA_FLAG"));


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
