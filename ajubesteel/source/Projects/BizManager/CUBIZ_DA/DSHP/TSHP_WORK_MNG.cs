using BizExecute;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSHP
{
    public class TSHP_WORK_MNG
    {
        public static DataTable TSHP_WORK_MNG_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("  SELECT  ");
                    sbQuery.Append("  PLT_CODE ");
                    sbQuery.Append(" ,WORK_ID ");
                    sbQuery.Append(" ,WORK_CODE ");
                    sbQuery.Append(" ,EMP_CODE ");
                    sbQuery.Append(" ,REQ_STATUS ");
                    sbQuery.Append(" ,REQ_DATE ");
                    sbQuery.Append(" ,REQ_START_DATE ");
                    sbQuery.Append(" ,REQ_END_DATE ");
                    sbQuery.Append(" ,REQ_TIME ");
                    sbQuery.Append(" ,REQ_AMPM ");
                    sbQuery.Append(" ,CC_EMP ");
                    sbQuery.Append(" ,REQ_SCOMMENT ");
                    sbQuery.Append(" ,APP_SCOMMENT ");
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
                    sbQuery.Append("  FROM TSHP_WORK_MNG  ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("  AND WORK_ID = @WORK_ID  ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "WORK_ID")) isHasColumn = false;

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

        public static void TSHP_WORK_MNG_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" INSERT INTO TSHP_WORK_MNG (  ");
                    sbQuery.Append("  PLT_CODE ");
                    sbQuery.Append(" ,WORK_ID ");
                    sbQuery.Append(" ,WORK_CODE ");
                    sbQuery.Append(" ,EMP_CODE ");
                    sbQuery.Append(" ,REQ_STATUS ");
                    sbQuery.Append(" ,REQ_DATE ");
                    sbQuery.Append(" ,REQ_START_DATE ");
                    sbQuery.Append(" ,REQ_END_DATE ");
                    sbQuery.Append(" ,REQ_TIME ");
                    sbQuery.Append(" ,REQ_AMPM ");
                    sbQuery.Append(" ,CC_EMP ");
                    sbQuery.Append(" ,REQ_SCOMMENT ");
                    sbQuery.Append(" ,APP_SCOMMENT ");
                    sbQuery.Append(" ,IS_DIR_IN ");
                    sbQuery.Append(" ,IS_DIR_OUT ");
                    sbQuery.Append(" ,OUT_TYPE ");
                    sbQuery.Append(" ,OUT_VEN_CODE ");
                    sbQuery.Append(" ,APP_EMP1 ");
                    sbQuery.Append(" ,APP_EMP2 ");
                    sbQuery.Append(" ,APP_EMP3 ");
                    sbQuery.Append(" ,APP_EMP4 ");
                    sbQuery.Append(" ,REG_DATE ");
                    sbQuery.Append(" ,REG_EMP ");
                    sbQuery.Append(" ,DATA_FLAG ");
                    sbQuery.Append("  ) VALUES (  ");
                    sbQuery.Append("  @PLT_CODE ");
                    sbQuery.Append(" ,@WORK_ID ");
                    sbQuery.Append(" ,@WORK_CODE ");
                    sbQuery.Append(" ,@EMP_CODE ");
                    sbQuery.Append(" ,@REQ_STATUS ");
                    sbQuery.Append(" ,@REQ_DATE ");
                    sbQuery.Append(" ,@REQ_START_DATE ");
                    sbQuery.Append(" ,@REQ_END_DATE ");
                    sbQuery.Append(" ,@REQ_TIME ");
                    sbQuery.Append(" ,@REQ_AMPM ");
                    sbQuery.Append(" ,@CC_EMP ");
                    sbQuery.Append(" ,@REQ_SCOMMENT ");
                    sbQuery.Append(" ,@APP_SCOMMENT ");
                    sbQuery.Append(" ,@IS_DIR_IN ");
                    sbQuery.Append(" ,@IS_DIR_OUT ");
                    sbQuery.Append(" ,@OUT_TYPE ");
                    sbQuery.Append(" ,@OUT_VEN_CODE ");
                    sbQuery.Append(" ,@APP_EMP1 ");
                    sbQuery.Append(" ,@APP_EMP2 ");
                    sbQuery.Append(" ,@APP_EMP3 ");
                    sbQuery.Append(" ,@APP_EMP4 ");
                    sbQuery.Append(" ,GETDATE() ");
                    sbQuery.Append(" ," + UTIL.GetValidValue(ConnInfo.UserID));
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

        public static void TSHP_WORK_MNG_UPD(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TSHP_WORK_MNG SET  ");
                    sbQuery.Append("  WORK_CODE = @WORK_CODE ");
                    sbQuery.Append(" ,EMP_CODE = @EMP_CODE ");
                    sbQuery.Append(" ,REQ_STATUS = @REQ_STATUS ");
                    sbQuery.Append(" ,REQ_DATE = @REQ_DATE ");
                    sbQuery.Append(" ,REQ_START_DATE = @REQ_START_DATE ");
                    sbQuery.Append(" ,REQ_END_DATE = @REQ_END_DATE ");
                    sbQuery.Append(" ,REQ_TIME = @REQ_TIME ");
                    sbQuery.Append(" ,REQ_AMPM = @REQ_AMPM ");
                    sbQuery.Append(" ,CC_EMP = @CC_EMP ");
                    sbQuery.Append(" ,REQ_SCOMMENT = @REQ_SCOMMENT ");
                    sbQuery.Append(" ,APP_SCOMMENT = @APP_SCOMMENT ");
                    sbQuery.Append(" ,IS_DIR_IN = @IS_DIR_IN ");
                    sbQuery.Append(" ,IS_DIR_OUT = @IS_DIR_OUT ");
                    sbQuery.Append(" ,OUT_TYPE = @OUT_TYPE ");
                    sbQuery.Append(" ,OUT_VEN_CODE = @OUT_VEN_CODE ");
                    sbQuery.Append(" ,MDFY_DATE = GETDATE()");
                    sbQuery.Append(" ,MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" ,DATA_FLAG = @DATA_FLAG ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append("  AND WORK_ID = @WORK_ID ");
                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "WORK_ID")) isHasColumn = false;

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

        public static void TSHP_WORK_MNG_UPD2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TSHP_WORK_MNG SET  ");
                    sbQuery.Append("  REQ_STATUS = @REQ_STATUS ");
                    sbQuery.Append("  ,APP_EMP1 = @APP_EMP1 ");
                    sbQuery.Append("  ,APP_EMP_FLAG1 = @APP_EMP_FLAG1 ");
                    sbQuery.Append("  ,APP_EMP2 = @APP_EMP2 ");
                    sbQuery.Append("  ,APP_EMP_FLAG2 = @APP_EMP_FLAG2 ");
                    sbQuery.Append("  ,APP_EMP3 = @APP_EMP3 ");
                    sbQuery.Append("  ,APP_EMP_FLAG3 = @APP_EMP_FLAG3 ");
                    sbQuery.Append("  ,APP_EMP4 = @APP_EMP4 ");
                    sbQuery.Append("  ,APP_EMP_FLAG4 = @APP_EMP_FLAG4 ");
                    sbQuery.Append(" ,APP_SCOMMENT = @APP_SCOMMENT ");
                    sbQuery.Append(" ,MDFY_DATE = GETDATE()");
                    sbQuery.Append(" ,MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append("  AND WORK_ID = @WORK_ID ");
                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "WORK_ID")) isHasColumn = false;

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

        public static void TSHP_WORK_MNG_UPD3(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TSHP_WORK_MNG SET  ");
                    sbQuery.Append("  REQ_STATUS = @REQ_STATUS ");
                    sbQuery.Append("  ,APP_EMP1 = @APP_EMP1 ");
                    sbQuery.Append("  ,APP_EMP_FLAG1 = @APP_EMP_FLAG1 ");
                    sbQuery.Append("  ,APP_EMP2 = @APP_EMP2 ");
                    sbQuery.Append("  ,APP_EMP_FLAG2 = @APP_EMP_FLAG2 ");
                    sbQuery.Append("  ,APP_EMP3 = @APP_EMP3 ");
                    sbQuery.Append("  ,APP_EMP_FLAG3 = @APP_EMP_FLAG3 ");
                    sbQuery.Append("  ,APP_EMP4 = @APP_EMP4 ");
                    sbQuery.Append("  ,APP_EMP_FLAG4 = @APP_EMP_FLAG4 ");
                    sbQuery.Append(" ,APP_SCOMMENT = @APP_SCOMMENT ");
                    sbQuery.Append(" ,REJECT_DATE = @REJECT_DATE ");
                    sbQuery.Append(" ,REJECT_REASON = @REJECT_REASON ");
                    sbQuery.Append(" ,MDFY_DATE = GETDATE()");
                    sbQuery.Append(" ,MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append("  AND WORK_ID = @WORK_ID ");
                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "WORK_ID")) isHasColumn = false;

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

        public static void TSHP_WORK_MNG_UDE(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TSHP_WORK_MNG SET  ");
                    sbQuery.Append("  DEL_DATE = GETDATE()");
                    sbQuery.Append(" ,DEL_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" ,DATA_FLAG = @DATA_FLAG ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append("  AND WORK_ID = @WORK_ID ");
                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "WORK_ID")) isHasColumn = false;

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

    public class TSHP_WORK_MNG_QUERY
    {
        public static DataTable TSHP_WORK_MNG_QUERY1(DataTable dtParam, BizExecute.BizExecute bizExecute)
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
                    //sbQuery.Append(" ,CASE WHEN WM.WORK_CODE = 'W05' THEN 1 WHEN WM.WORK_CODE = 'W06' THEN 0.5 ELSE NULL END AS REQ_DAY");
                    sbQuery.Append(" ,CASE WHEN WM.WORK_CODE = 'W05' THEN CONVERT(DECIMAL(18,1), REQ_TIME / 480) WHEN WM.WORK_CODE = 'W06' THEN 0.5 ELSE NULL END AS REQ_DAY");
                    //sbQuery.Append(" ,ISNULL(WM.APP_EMP1,APP.APP_EMP1) AS APP_EMP1 ");
                    sbQuery.Append(" ,WM.APP_EMP1 ");
                    sbQuery.Append(" ,ISNULL(WM.APP_EMP_FLAG1,'0') AS APP_EMP_FLAG1 ");

                    //sbQuery.Append(" ,ISNULL(WM.APP_EMP2,APP.APP_EMP2) AS APP_EMP2 ");
                    sbQuery.Append(" ,WM.APP_EMP2 ");
                    sbQuery.Append(" ,ISNULL(WM.APP_EMP_FLAG2,'0') AS APP_EMP_FLAG2 ");

                    //sbQuery.Append(" ,ISNULL(WM.APP_EMP3,APP.APP_EMP3) AS APP_EMP3 ");
                    sbQuery.Append(" ,WM.APP_EMP3 ");
                    sbQuery.Append(" ,ISNULL(WM.APP_EMP_FLAG3,'0') AS APP_EMP_FLAG3 ");

                    //sbQuery.Append(" ,ISNULL(WM.APP_EMP4,APP.APP_EMP4) AS APP_EMP4 ");
                    sbQuery.Append(" ,WM.APP_EMP4 ");
                    sbQuery.Append(" ,ISNULL(WM.APP_EMP_FLAG4,'0') AS APP_EMP_FLAG4 ");

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
                    sbQuery.Append(" ,(SELECT CASE WHEN  COUNT(FM.FILE_ID) > 0 THEN '1' ELSE '0' END FROM TSYS_FILELIST_MASTER FM WHERE FM.PLT_CODE = WM.PLT_CODE AND FM.LINK_KEY = WM.WORK_ID AND FM.IS_UPLOAD = '1' AND FM.DATA_FLAG = '0') AS HAS_ATTACH");
                    sbQuery.Append(" FROM TSHP_WORK_MNG WM");
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
                        sbWhere.Append(UTIL.GetWhere(row, "@EMP_CODE", "WM.EMP_CODE = @EMP_CODE"));
                        //sbWhere.Append(UTIL.GetWhere(row, "@S_REQ_DATE,@E_REQ_DATE", "CONVERT(VARCHAR(8), WM.REQ_DATE, 112) BETWEEN @S_REQ_DATE AND @E_REQ_DATE"));
                        //sbWhere.Append(UTIL.GetWhere(row, "@REQ_YEAR", "LEFT(CONVERT(VARCHAR(8), WM.REQ_DATE, 112),4) = @REQ_YEAR"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_REQ_DATE,@E_REQ_DATE", "WM.STR_REQ_DATE BETWEEN @S_REQ_DATE AND @E_REQ_DATE"));

                        sbWhere.Append(UTIL.GetWhere(row, "@S_REQ_DATETIME,@E_REQ_DATETIME", "CONVERT(VARCHAR(8), WM.REQ_DATE, 112) BETWEEN @S_REQ_DATETIME AND @E_REQ_DATETIME"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_REQ_START_DATE,@E_REQ_START_DATE", "CONVERT(VARCHAR(8), WM.REQ_START_DATE, 112) BETWEEN @S_REQ_START_DATE AND @E_REQ_START_DATE"));

                        sbWhere.Append(UTIL.GetWhere(row, "@WORK_CODE_IN", "WM.WORK_CODE IN @WORK_CODE_IN", UTIL.SqlCondType.IN));

                        sbWhere.Append(UTIL.GetWhere(row, "@REQ_YEAR", "LEFT(WM.STR_REQ_DATE,4) = @REQ_YEAR"));
                        sbWhere.Append(UTIL.GetWhere(row, "@WORK_CODE", "WM.WORK_CODE = @WORK_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@IS_OUT", "WC.IS_OUT = '1'"));
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

        public static DataTable TSHP_WORK_MNG_QUERY2(DataTable dtParam, BizExecute.BizExecute bizExecute)
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
                    sbQuery.Append(" ,E.ORG_CODE");
                    sbQuery.Append(" ,O.ORG_NAME");
                    sbQuery.Append(" ,WM.EMP_CODE");
                    sbQuery.Append(" ,E.EMP_NAME");
                    sbQuery.Append(" ,WM.REQ_DATE");
                    sbQuery.Append(" ,WM.REQ_START_DATE");
                    sbQuery.Append(" ,LEFT(CONVERT(VARCHAR(8), WM.REQ_START_DATE, 112),6) AS REQ_START_MONTH");
                    sbQuery.Append(" ,WM.REQ_END_DATE");
                    sbQuery.Append(" ,WM.REQ_TIME");
                    sbQuery.Append(" ,CONVERT(decimal(18,1), REQ_TIME / 60) AS REQ_HOUR");
                    sbQuery.Append(" ,CASE WHEN WM.WORK_CODE = 'W05' THEN CONVERT(DECIMAL(18,1), REQ_TIME / 480) WHEN WM.WORK_CODE = 'W06' THEN 0.5 ELSE NULL END AS REQ_DAY");
                    sbQuery.Append(" ,WM.REQ_AMPM");
                    sbQuery.Append(" ,WM.CC_EMP");
                    sbQuery.Append(" ,WM.REQ_SCOMMENT");
                    sbQuery.Append(" ,WM.APP_SCOMMENT");

                    sbQuery.Append(" ,WM.IS_DIR_IN");
                    sbQuery.Append(" ,WM.IS_DIR_OUT");
                    sbQuery.Append(" ,WM.OUT_TYPE");
                    sbQuery.Append(" ,WM.OUT_VEN_CODE");
                    sbQuery.Append(" ,V.VEN_NAME AS OUT_VEN_NAME");
                    sbQuery.Append(" ,WM.REJECT_DATE");
                    sbQuery.Append(" ,WM.REJECT_REASON");

                    //sbQuery.Append(" ,ISNULL(WM.APP_EMP1,APP.APP_EMP1) AS APP_EMP1 ");
                    sbQuery.Append(" ,WM.APP_EMP1 ");
                    sbQuery.Append(" ,ISNULL(WM.APP_EMP_FLAG1,'0') AS APP_EMP_FLAG1 ");

                    //sbQuery.Append(" ,ISNULL(WM.APP_EMP2,APP.APP_EMP2) AS APP_EMP2 ");
                    sbQuery.Append(" ,WM.APP_EMP2 ");
                    sbQuery.Append(" ,ISNULL(WM.APP_EMP_FLAG2,'0') AS APP_EMP_FLAG2 ");

                    //sbQuery.Append(" ,ISNULL(WM.APP_EMP3,APP.APP_EMP3) AS APP_EMP3 ");
                    sbQuery.Append(" ,WM.APP_EMP3 ");
                    sbQuery.Append(" ,ISNULL(WM.APP_EMP_FLAG3,'0') AS APP_EMP_FLAG3 ");

                    //sbQuery.Append(" ,ISNULL(WM.APP_EMP4,APP.APP_EMP4) AS APP_EMP4 ");
                    sbQuery.Append(" ,WM.APP_EMP4 ");
                    sbQuery.Append(" ,ISNULL(WM.APP_EMP_FLAG4,'0') AS APP_EMP_FLAG4 ");

                    sbQuery.Append(" ,WM.REG_DATE");
                    sbQuery.Append(" ,WM.REG_EMP");
                    sbQuery.Append(" ,WM.MDFY_DATE");
                    sbQuery.Append(" ,WM.MDFY_EMP");
                    sbQuery.Append(" ,WM.DEL_DATE");
                    sbQuery.Append(" ,WM.DEL_EMP");
                    sbQuery.Append(" ,WM.DATA_FLAG");
                    sbQuery.Append(" ,WC.IS_OUT");
                    sbQuery.Append(" FROM TSHP_WORK_MNG WM");
                    sbQuery.Append(" LEFT JOIN TSTD_WORKCODE WC");
                    sbQuery.Append(" ON WM.PLT_CODE = WC.PLT_CODE");
                    sbQuery.Append(" AND WM.WORK_CODE = WC.WORK_CODE");

                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE E");
                    sbQuery.Append(" ON WM.PLT_CODE = E.PLT_CODE");
                    sbQuery.Append(" AND WM.EMP_CODE = E.EMP_CODE");

                    sbQuery.Append(" LEFT JOIN TSTD_VENDOR V");
                    sbQuery.Append(" ON WM.PLT_CODE = V.PLT_CODE");
                    sbQuery.Append(" AND WM.OUT_VEN_CODE = V.VEN_CODE");

                    sbQuery.Append(" LEFT JOIN TSTD_APP_EMP APP ");
                    sbQuery.Append(" ON WM.PLT_CODE = APP.PLT_CODE");
                    sbQuery.Append(" AND APP.APP_TYPE = 'ATD' ");

                    sbQuery.Append(" LEFT JOIN TSTD_ORG O");
                    sbQuery.Append(" ON E.PLT_CODE = O.PLT_CODE");
                    sbQuery.Append(" AND E.ORG_CODE = O.ORG_CODE");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder();

                        sbWhere.Append(" WHERE WM.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@WORK_ID", "WM.WORK_ID = @WORK_ID"));
                        sbWhere.Append(UTIL.GetWhere(row, "@EMP_LIKE", "(WM.EMP_CODE LIKE '%' + @EMP_LIKE + '%' OR E.EMP_NAME LIKE '%' + @EMP_LIKE + '%')"));

                        string sQuery = "((ISNULL(WM.APP_EMP1,APP.APP_EMP1) = @REG_EMP AND ISNULL(WM.APP_EMP_FLAG1,'0') = '0')";
                        sQuery += " OR (ISNULL(WM.APP_EMP2,APP.APP_EMP2) = @REG_EMP AND ISNULL(WM.APP_EMP_FLAG1,'0') = '1' AND ISNULL(WM.APP_EMP_FLAG2,'0') = '0')";
                        sQuery += " OR (ISNULL(WM.APP_EMP3,APP.APP_EMP3) = @REG_EMP AND ISNULL(WM.APP_EMP_FLAG1,'0') = '1' AND ISNULL(WM.APP_EMP_FLAG2,'0') = '1' AND ISNULL(WM.APP_EMP_FLAG3,'0') = '0')";
                        sQuery += " OR (ISNULL(WM.APP_EMP4,APP.APP_EMP4) = @REG_EMP AND ISNULL(WM.APP_EMP_FLAG1,'0') = '1' AND ISNULL(WM.APP_EMP_FLAG2,'0') = '1' AND ISNULL(WM.APP_EMP_FLAG3,'0') = '1' AND ISNULL(WM.APP_EMP_FLAG4,'0') = '0'))";

                        sbWhere.Append(UTIL.GetWhere(row, "@REG_EMP", sQuery));
                        sbWhere.Append(UTIL.GetWhere(row, "@WORK_CODE", "WM.WORK_CODE = @WORK_CODE"));

                        //sbWhere.Append(UTIL.GetWhere(row, "@S_REQ_DATE,@E_REQ_DATE", "CONVERT(VARCHAR(8), WM.REQ_DATE, 112) BETWEEN @S_REQ_DATE AND @E_REQ_DATE"));
                        //sbWhere.Append(UTIL.GetWhere(row, "@REQ_YEAR", "LEFT(CONVERT(VARCHAR(8), WM.REQ_DATE, 112),4) = @REQ_YEAR"));
                        //sbWhere.Append(UTIL.GetWhere(row, "@S_REQ_DATE,@E_REQ_DATE", "WM.STR_REQ_DATE BETWEEN @S_REQ_DATE AND @E_REQ_DATE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_REQ_DATE,@E_REQ_DATE", "CONVERT(varchar(8), WM.REQ_DATE, 112) BETWEEN @S_REQ_DATE AND @E_REQ_DATE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_REQ_START_DATE,@E_REQ_START_DATE", "CONVERT(varchar(8), WM.REQ_START_DATE, 112) BETWEEN @S_REQ_START_DATE AND @E_REQ_START_DATE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@REQ_YEAR", "LEFT(WM.STR_REQ_DATE,4) = @REQ_YEAR"));
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

        public static DataTable TSHP_WORK_MNG_QUERY3(DataTable dtParam, BizExecute.BizExecute bizExecute)
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
                    sbQuery.Append(" ,E.ORG_CODE");
                    sbQuery.Append(" ,O.ORG_NAME");
                    sbQuery.Append(" ,WM.EMP_CODE");
                    sbQuery.Append(" ,E.EMP_NAME");
                    sbQuery.Append(" ,WM.REQ_DATE");
                    sbQuery.Append(" ,WM.REQ_START_DATE");
                    sbQuery.Append(" ,LEFT(CONVERT(VARCHAR(8), WM.REQ_START_DATE, 112),6) AS REQ_START_MONTH");
                    sbQuery.Append(" ,WM.REQ_END_DATE");
                    sbQuery.Append(" ,WM.REQ_TIME");
                    sbQuery.Append(" ,CONVERT(decimal(18,1), REQ_TIME / 60) AS REQ_HOUR");
                    sbQuery.Append(" ,CASE WHEN WM.WORK_CODE = 'W05' THEN CONVERT(DECIMAL(18,1), REQ_TIME / 480) WHEN WM.WORK_CODE = 'W06' THEN 0.5 ELSE NULL END AS REQ_DAY");
                    sbQuery.Append(" ,WM.REQ_AMPM");
                    sbQuery.Append(" ,WM.CC_EMP");
                    sbQuery.Append(" ,WM.REQ_SCOMMENT");
                    sbQuery.Append(" ,WM.APP_SCOMMENT");

                    sbQuery.Append(" ,WM.IS_DIR_IN");
                    sbQuery.Append(" ,WM.IS_DIR_OUT");
                    sbQuery.Append(" ,WM.OUT_TYPE");
                    sbQuery.Append(" ,WM.OUT_VEN_CODE");
                    sbQuery.Append(" ,V.VEN_NAME AS OUT_VEN_NAME");
                    sbQuery.Append(" ,WM.REJECT_DATE");
                    sbQuery.Append(" ,WM.REJECT_REASON");

                    //sbQuery.Append(" ,ISNULL(WM.APP_EMP1,APP.APP_EMP1) AS APP_EMP1 ");
                    sbQuery.Append(" ,WM.APP_EMP1 ");
                    sbQuery.Append(" ,ISNULL(WM.APP_EMP_FLAG1,'0') AS APP_EMP_FLAG1 ");

                    //sbQuery.Append(" ,ISNULL(WM.APP_EMP2,APP.APP_EMP2) AS APP_EMP2 ");
                    sbQuery.Append(" ,WM.APP_EMP2 ");
                    sbQuery.Append(" ,ISNULL(WM.APP_EMP_FLAG2,'0') AS APP_EMP_FLAG2 ");

                    //sbQuery.Append(" ,ISNULL(WM.APP_EMP3,APP.APP_EMP3) AS APP_EMP3 ");
                    sbQuery.Append(" ,WM.APP_EMP3 ");
                    sbQuery.Append(" ,ISNULL(WM.APP_EMP_FLAG3,'0') AS APP_EMP_FLAG3 ");

                    //sbQuery.Append(" ,ISNULL(WM.APP_EMP4,APP.APP_EMP4) AS APP_EMP4 ");
                    sbQuery.Append(" ,WM.APP_EMP4 ");
                    sbQuery.Append(" ,ISNULL(WM.APP_EMP_FLAG4,'0') AS APP_EMP_FLAG4 ");

                    sbQuery.Append(" ,WM.REG_DATE");
                    sbQuery.Append(" ,WM.REG_EMP");
                    sbQuery.Append(" ,WM.MDFY_DATE");
                    sbQuery.Append(" ,WM.MDFY_EMP");
                    sbQuery.Append(" ,WM.DEL_DATE");
                    sbQuery.Append(" ,WM.DEL_EMP");
                    sbQuery.Append(" ,WM.DATA_FLAG");
                    sbQuery.Append(" ,WC.IS_OUT");
                    sbQuery.Append(" FROM TSHP_WORK_MNG WM");
                    sbQuery.Append(" LEFT JOIN TSTD_WORKCODE WC");
                    sbQuery.Append(" ON WM.PLT_CODE = WC.PLT_CODE");
                    sbQuery.Append(" AND WM.WORK_CODE = WC.WORK_CODE");

                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE E");
                    sbQuery.Append(" ON WM.PLT_CODE = E.PLT_CODE");
                    sbQuery.Append(" AND WM.EMP_CODE = E.EMP_CODE");

                    sbQuery.Append(" LEFT JOIN TSTD_VENDOR V");
                    sbQuery.Append(" ON WM.PLT_CODE = V.PLT_CODE");
                    sbQuery.Append(" AND WM.OUT_VEN_CODE = V.VEN_CODE");

                    sbQuery.Append(" LEFT JOIN TSTD_APP_EMP APP ");
                    sbQuery.Append(" ON WM.PLT_CODE = APP.PLT_CODE");
                    sbQuery.Append(" AND APP.APP_TYPE = 'ATD' ");

                    sbQuery.Append(" LEFT JOIN TSTD_ORG O");
                    sbQuery.Append(" ON E.PLT_CODE = O.PLT_CODE");
                    sbQuery.Append(" AND E.ORG_CODE = O.ORG_CODE");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder();

                        sbWhere.Append(" WHERE WM.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@WORK_ID", "WM.WORK_ID = @WORK_ID"));
                        sbWhere.Append(UTIL.GetWhere(row, "@EMP_LIKE", "(WM.EMP_CODE LIKE '%' + @EMP_LIKE + '%' OR E.EMP_NAME LIKE '%' + @EMP_LIKE + '%')"));

                        string sQuery = "((ISNULL(WM.APP_EMP1,APP.APP_EMP1) = @REG_EMP AND ISNULL(WM.APP_EMP_FLAG1,'0') = '1' AND ISNULL(WM.APP_EMP_FLAG2,'0') = '0' AND ISNULL(WM.APP_EMP_FLAG3,'0') = '0' AND ISNULL(WM.APP_EMP_FLAG4,'0') = '0' )";
                        sQuery += " OR (ISNULL(WM.APP_EMP2,APP.APP_EMP2) = @REG_EMP AND ISNULL(WM.APP_EMP_FLAG2,'0') = '1' AND ISNULL(WM.APP_EMP_FLAG3,'0') = '0' AND ISNULL(WM.APP_EMP_FLAG4,'0') = '0')";
                        sQuery += " OR (ISNULL(WM.APP_EMP3,APP.APP_EMP3) = @REG_EMP AND ISNULL(WM.APP_EMP_FLAG3,'0') = '1' AND ISNULL(WM.APP_EMP_FLAG4,'0') = '0')";
                        sQuery += " OR (ISNULL(WM.APP_EMP4,APP.APP_EMP4) = @REG_EMP AND ISNULL(WM.APP_EMP_FLAG4,'0') = '1'))";

                        sbWhere.Append(UTIL.GetWhere(row, "@REG_EMP", sQuery));
                        sbWhere.Append(UTIL.GetWhere(row, "@WORK_CODE", "WM.WORK_CODE = @WORK_CODE"));

                        //sbWhere.Append(UTIL.GetWhere(row, "@S_REQ_DATE,@E_REQ_DATE", "CONVERT(VARCHAR(8), WM.REQ_DATE, 112) BETWEEN @S_REQ_DATE AND @E_REQ_DATE"));
                        //sbWhere.Append(UTIL.GetWhere(row, "@REQ_YEAR", "LEFT(CONVERT(VARCHAR(8), WM.REQ_DATE, 112),4) = @REQ_YEAR"));
                        //sbWhere.Append(UTIL.GetWhere(row, "@S_REQ_DATE,@E_REQ_DATE", "WM.STR_REQ_DATE BETWEEN @S_REQ_DATE AND @E_REQ_DATE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_REQ_DATE,@E_REQ_DATE", "CONVERT(varchar(8), WM.REQ_DATE, 112) BETWEEN @S_REQ_DATE AND @E_REQ_DATE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_REQ_START_DATE,@E_REQ_START_DATE", "CONVERT(varchar(8), WM.REQ_START_DATE, 112) BETWEEN @S_REQ_START_DATE AND @E_REQ_START_DATE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@REQ_YEAR", "LEFT(WM.STR_REQ_DATE,4) = @REQ_YEAR"));
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

        public static DataTable TSHP_WORK_MNG_QUERY4(DataTable dtParam, BizExecute.BizExecute bizExecute)
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
                    sbQuery.Append(" ,E.ORG_CODE");
                    sbQuery.Append(" ,O.ORG_NAME");
                    sbQuery.Append(" ,WM.EMP_CODE");
                    sbQuery.Append(" ,E.EMP_NAME");
                    sbQuery.Append(" ,WM.REQ_DATE");
                    sbQuery.Append(" ,WM.REQ_START_DATE");
                    sbQuery.Append(" ,LEFT(CONVERT(VARCHAR(8), WM.REQ_START_DATE, 112),6) AS REQ_START_MONTH");
                    sbQuery.Append(" ,WM.REQ_END_DATE");
                    sbQuery.Append(" ,WM.REQ_TIME");
                    sbQuery.Append(" ,CONVERT(decimal(18,1), REQ_TIME / 60) AS REQ_HOUR");
                    sbQuery.Append(" ,CASE WHEN WM.WORK_CODE = 'W05' THEN CONVERT(DECIMAL(18,1), REQ_TIME / 480) WHEN WM.WORK_CODE = 'W06' THEN 0.5 ELSE NULL END AS REQ_DAY");
                    sbQuery.Append(" ,WM.REQ_AMPM");
                    sbQuery.Append(" ,WM.CC_EMP");
                    sbQuery.Append(" ,WM.REQ_SCOMMENT");
                    sbQuery.Append(" ,WM.APP_SCOMMENT");

                    sbQuery.Append(" ,WM.IS_DIR_IN");
                    sbQuery.Append(" ,WM.IS_DIR_OUT");
                    sbQuery.Append(" ,WM.OUT_TYPE");
                    sbQuery.Append(" ,WM.OUT_VEN_CODE");
                    sbQuery.Append(" ,V.VEN_NAME AS OUT_VEN_NAME");
                    sbQuery.Append(" ,WM.REJECT_DATE");
                    sbQuery.Append(" ,WM.REJECT_REASON");

                    //sbQuery.Append(" ,ISNULL(WM.APP_EMP1,APP.APP_EMP1) AS APP_EMP1 ");
                    sbQuery.Append(" ,WM.APP_EMP1 ");
                    sbQuery.Append(" ,ISNULL(WM.APP_EMP_FLAG1,'0') AS APP_EMP_FLAG1 ");

                    //sbQuery.Append(" ,ISNULL(WM.APP_EMP2,APP.APP_EMP2) AS APP_EMP2 ");
                    sbQuery.Append(" ,WM.APP_EMP2 ");
                    sbQuery.Append(" ,ISNULL(WM.APP_EMP_FLAG2,'0') AS APP_EMP_FLAG2 ");

                    //sbQuery.Append(" ,ISNULL(WM.APP_EMP3,APP.APP_EMP3) AS APP_EMP3 ");
                    sbQuery.Append(" ,WM.APP_EMP3 ");
                    sbQuery.Append(" ,ISNULL(WM.APP_EMP_FLAG3,'0') AS APP_EMP_FLAG3 ");

                    //sbQuery.Append(" ,ISNULL(WM.APP_EMP4,APP.APP_EMP4) AS APP_EMP4 ");
                    sbQuery.Append(" ,WM.APP_EMP4 ");
                    sbQuery.Append(" ,ISNULL(WM.APP_EMP_FLAG4,'0') AS APP_EMP_FLAG4 ");

                    sbQuery.Append(" ,WM.REG_DATE");
                    sbQuery.Append(" ,WM.REG_EMP");
                    sbQuery.Append(" ,WM.MDFY_DATE");
                    sbQuery.Append(" ,WM.MDFY_EMP");
                    sbQuery.Append(" ,WM.DEL_DATE");
                    sbQuery.Append(" ,WM.DEL_EMP");
                    sbQuery.Append(" ,WM.DATA_FLAG");
                    sbQuery.Append(" ,WC.IS_OUT");
                    sbQuery.Append(" FROM TSHP_WORK_MNG WM");
                    sbQuery.Append(" LEFT JOIN TSTD_WORKCODE WC");
                    sbQuery.Append(" ON WM.PLT_CODE = WC.PLT_CODE");
                    sbQuery.Append(" AND WM.WORK_CODE = WC.WORK_CODE");

                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE E");
                    sbQuery.Append(" ON WM.PLT_CODE = E.PLT_CODE");
                    sbQuery.Append(" AND WM.EMP_CODE = E.EMP_CODE");

                    sbQuery.Append(" LEFT JOIN TSTD_VENDOR V");
                    sbQuery.Append(" ON WM.PLT_CODE = V.PLT_CODE");
                    sbQuery.Append(" AND WM.OUT_VEN_CODE = V.VEN_CODE");

                    sbQuery.Append(" LEFT JOIN TSTD_APP_EMP APP ");
                    sbQuery.Append(" ON WM.PLT_CODE = APP.PLT_CODE");
                    sbQuery.Append(" AND APP.APP_TYPE = 'ATD' ");

                    sbQuery.Append(" LEFT JOIN TSTD_ORG O");
                    sbQuery.Append(" ON E.PLT_CODE = O.PLT_CODE");
                    sbQuery.Append(" AND E.ORG_CODE = O.ORG_CODE");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder();

                        sbWhere.Append(" WHERE WM.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@WORK_ID", "WM.WORK_ID = @WORK_ID"));
                        sbWhere.Append(UTIL.GetWhere(row, "@EMP_LIKE", "(WM.EMP_CODE LIKE '%' + @EMP_LIKE + '%' OR E.EMP_NAME LIKE '%' + @EMP_LIKE + '%')"));

                        string sQuery = "((ISNULL(WM.APP_EMP1,APP.APP_EMP1) = @REG_EMP AND ISNULL(WM.APP_EMP_FLAG1,'0') = '2' AND ISNULL(WM.APP_EMP_FLAG2,'0') = '0' AND ISNULL(WM.APP_EMP_FLAG3,'0') = '0' AND ISNULL(WM.APP_EMP_FLAG4,'0') = '0' )";
                        sQuery += " OR (ISNULL(WM.APP_EMP2,APP.APP_EMP2) = @REG_EMP AND ISNULL(WM.APP_EMP_FLAG2,'0') = '2' AND ISNULL(WM.APP_EMP_FLAG3,'0') = '0' AND ISNULL(WM.APP_EMP_FLAG4,'0') = '0')";
                        sQuery += " OR (ISNULL(WM.APP_EMP3,APP.APP_EMP3) = @REG_EMP AND ISNULL(WM.APP_EMP_FLAG3,'0') = '2' AND ISNULL(WM.APP_EMP_FLAG4,'0') = '0')";
                        sQuery += " OR (ISNULL(WM.APP_EMP4,APP.APP_EMP4) = @REG_EMP AND ISNULL(WM.APP_EMP_FLAG4,'0') = '2'))";

                        sbWhere.Append(UTIL.GetWhere(row, "@REG_EMP", sQuery));
                        sbWhere.Append(UTIL.GetWhere(row, "@WORK_CODE", "WM.WORK_CODE = @WORK_CODE"));

                        //sbWhere.Append(UTIL.GetWhere(row, "@S_REQ_DATE,@E_REQ_DATE", "CONVERT(VARCHAR(8), WM.REQ_DATE, 112) BETWEEN @S_REQ_DATE AND @E_REQ_DATE"));
                        //sbWhere.Append(UTIL.GetWhere(row, "@REQ_YEAR", "LEFT(CONVERT(VARCHAR(8), WM.REQ_DATE, 112),4) = @REQ_YEAR"));
                        //sbWhere.Append(UTIL.GetWhere(row, "@S_REQ_DATE,@E_REQ_DATE", "WM.STR_REQ_DATE BETWEEN @S_REQ_DATE AND @E_REQ_DATE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_REQ_DATE,@E_REQ_DATE", "CONVERT(varchar(8), WM.REQ_DATE, 112) BETWEEN @S_REQ_DATE AND @E_REQ_DATE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_REQ_START_DATE,@E_REQ_START_DATE", "CONVERT(varchar(8), WM.REQ_START_DATE, 112) BETWEEN @S_REQ_START_DATE AND @E_REQ_START_DATE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@REQ_YEAR", "LEFT(WM.STR_REQ_DATE,4) = @REQ_YEAR"));
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

        public static DataTable TSHP_WORK_MNG_QUERY5(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT");
                    sbQuery.Append(" PLT_CODE");
                    sbQuery.Append(" ,WORK_CODE");
                    sbQuery.Append(" ,EMP_CODE");
                    sbQuery.Append(" ,REQ_AMPM");
                    sbQuery.Append(" ,STR_REQ_DATE");
                    sbQuery.Append(" ,REQ_START_DATE");
                    sbQuery.Append(" ,REQ_END_DATE");
                    sbQuery.Append(" ,REQ_TIME");
                    sbQuery.Append(" FROM TSHP_WORK_MNG");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder();

                        sbWhere.Append(" WHERE PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@EMP_CODE", "EMP_CODE = @EMP_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@WORK_CODE", "WORK_CODE = @WORK_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@OR_WORK_CODE1,@OR_WORK_CODE2", "(WORK_CODE = @OR_WORK_CODE1 OR WORK_CODE = @OR_WORK_CODE2)"));
                        sbWhere.Append(UTIL.GetWhere(row, "@EMP_CODE", "EMP_CODE = @EMP_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@REQ_STATUS", "REQ_STATUS = @REQ_STATUS"));
                        sbWhere.Append(UTIL.GetWhere(row, "@REQ_YEAR", "LEFT(STR_REQ_DATE,4) = @REQ_YEAR"));
                        sbWhere.Append(UTIL.GetWhere(row, "@REQ_MONTH", "LEFT(STR_REQ_DATE,6) = @REQ_MONTH"));
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

        public static DataTable TSHP_WORK_MNG_QUERY6(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT");
                    sbQuery.Append(" PLT_CODE");
                    sbQuery.Append(" ,EMP_CODE");
                    sbQuery.Append(" ,CONVERT(decimal(18,1), SUM(REQ_TIME) / 480) AS HOLI_DAY");
                    sbQuery.Append(" FROM TSHP_WORK_MNG");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder();

                        sbWhere.Append(" WHERE PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@EMP_CODE", "EMP_CODE = @EMP_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@WORK_CODE", "WORK_CODE = @WORK_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@IN_WORK_CODE1,@IN_WORK_CODE2", "WORK_CODE IN (@IN_WORK_CODE1, @IN_WORK_CODE2)"));
                        sbWhere.Append(UTIL.GetWhere(row, "@REQ_STATUS", "REQ_STATUS = @REQ_STATUS"));
                        sbWhere.Append(UTIL.GetWhere(row, "@REQ_YEAR", "LEFT(STR_REQ_DATE,4) = @REQ_YEAR"));
                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "DATA_FLAG = @DATA_FLAG"));

                        StringBuilder sbGroupBy = new StringBuilder();
                        sbGroupBy.Append(" GROUP BY PLT_CODE, EMP_CODE");

                        DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString() + sbWhere.ToString() + sbGroupBy.ToString()).Copy();

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

        public static DataTable TSHP_WORK_MNG_QUERY7(DataTable dtParam, BizExecute.BizExecute bizExecute)
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
                    sbQuery.Append(" ,WM.STR_REQ_DATE");
                    sbQuery.Append(" ,WM.REQ_DATE");
                    sbQuery.Append(" ,WM.REQ_START_DATE");
                    sbQuery.Append(" ,LEFT(CONVERT(VARCHAR(8), WM.REQ_START_DATE, 112),6) AS REQ_START_MONTH");
                    sbQuery.Append(" ,WM.REQ_END_DATE");
                    sbQuery.Append(" ,WM.REQ_TIME");
                    sbQuery.Append(" ,CONVERT(decimal(18,1), REQ_TIME / 60) AS REQ_HOUR");
                    sbQuery.Append(" ,WM.CC_EMP");
                    sbQuery.Append(" ,WM.REQ_AMPM");
                    sbQuery.Append(" ,WM.REQ_SCOMMENT");
                    sbQuery.Append(" ,WM.APP_SCOMMENT");

                    sbQuery.Append(" ,WM.IS_DIR_IN");
                    sbQuery.Append(" ,WM.IS_DIR_OUT");
                    sbQuery.Append(" ,WM.OUT_TYPE");
                    sbQuery.Append(" ,WM.OUT_VEN_CODE");
                    sbQuery.Append(" ,V.VEN_NAME AS OUT_VEN_NAME");
                    sbQuery.Append(" ,WM.REJECT_DATE");
                    sbQuery.Append(" ,WM.REJECT_REASON");

                    sbQuery.Append(" ,WM.APP_EMP1 ");
                    sbQuery.Append(" ,ISNULL(WM.APP_EMP_FLAG1,'0') AS APP_EMP_FLAG1 ");

                    sbQuery.Append(" ,WM.APP_EMP2 ");
                    sbQuery.Append(" ,ISNULL(WM.APP_EMP_FLAG2,'0') AS APP_EMP_FLAG2 ");

                    sbQuery.Append(" ,WM.APP_EMP3 ");
                    sbQuery.Append(" ,ISNULL(WM.APP_EMP_FLAG3,'0') AS APP_EMP_FLAG3 ");

                    sbQuery.Append(" ,WM.APP_EMP4 ");
                    sbQuery.Append(" ,ISNULL(WM.APP_EMP_FLAG4,'0') AS APP_EMP_FLAG4 ");

                    sbQuery.Append(" ,WM.REG_DATE");
                    sbQuery.Append(" ,WM.REG_EMP");
                    sbQuery.Append(" ,RE.EMP_NAME AS REG_EMP_NAME");
                    sbQuery.Append(" ,WM.MDFY_DATE");
                    sbQuery.Append(" ,WM.MDFY_EMP");
                    sbQuery.Append(" ,ME.EMP_NAME AS MDFY_EMP_NAME");

                    sbQuery.Append(" ,WM.DEL_DATE");
                    sbQuery.Append(" ,WM.DEL_EMP");
                    sbQuery.Append(" ,WM.DATA_FLAG");
                    sbQuery.Append(" FROM TSHP_WORK_MNG WM");
                    sbQuery.Append(" LEFT JOIN TSTD_WORKCODE WC");
                    sbQuery.Append(" ON WM.PLT_CODE = WC.PLT_CODE");
                    sbQuery.Append(" AND WM.WORK_CODE = WC.WORK_CODE");

                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE E");
                    sbQuery.Append(" ON WM.PLT_CODE = E.PLT_CODE");
                    sbQuery.Append(" AND WM.EMP_CODE = E.EMP_CODE");

                    sbQuery.Append(" LEFT JOIN TSHP_WORK_MNG_EMP WME ");
                    sbQuery.Append(" ON WM.PLT_CODE = WME.PLT_CODE");
                    sbQuery.Append(" AND WM.WORK_ID = WME.WORK_ID ");

                    sbQuery.Append(" LEFT JOIN TSTD_VENDOR V");
                    sbQuery.Append(" ON WM.PLT_CODE = V.PLT_CODE");
                    sbQuery.Append(" AND WM.OUT_VEN_CODE = V.VEN_CODE");

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
                        sbWhere.Append(UTIL.GetWhere(row, "@EMP_CODE", "WM.EMP_CODE = @EMP_CODE"));
                        //sbWhere.Append(UTIL.GetWhere(row, "@S_REQ_DATE,@E_REQ_DATE", "CONVERT(VARCHAR(8), WM.REQ_DATE, 112) BETWEEN @S_REQ_DATE AND @E_REQ_DATE"));
                        //sbWhere.Append(UTIL.GetWhere(row, "@REQ_YEAR", "LEFT(CONVERT(VARCHAR(8), WM.REQ_DATE, 112),4) = @REQ_YEAR"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_REQ_DATE,@E_REQ_DATE", "WM.STR_REQ_DATE BETWEEN @S_REQ_DATE AND @E_REQ_DATE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@REQ_YEAR", "LEFT(WM.STR_REQ_DATE,4) = @REQ_YEAR"));
                        sbWhere.Append(UTIL.GetWhere(row, "@WORK_CODE", "WM.WORK_CODE = @WORK_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "WM.DATA_FLAG = @DATA_FLAG"));
                        sbWhere.Append(UTIL.GetWhere(row, "@CC_EMP_CODE", "WME.EMP_CODE = @CC_EMP_CODE"));


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

        public static DataTable TSHP_WORK_MNG_QUERY8(DataTable dtParam, BizExecute.BizExecute bizExecute)
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

                    sbQuery.Append(" ,WM.APP_EMP1 ");
                    sbQuery.Append(" ,ISNULL(WM.APP_EMP_FLAG1,'0') AS APP_EMP_FLAG1 ");

                    sbQuery.Append(" ,WM.APP_EMP2 ");
                    sbQuery.Append(" ,ISNULL(WM.APP_EMP_FLAG2,'0') AS APP_EMP_FLAG2 ");

                    sbQuery.Append(" ,WM.APP_EMP3 ");
                    sbQuery.Append(" ,ISNULL(WM.APP_EMP_FLAG3,'0') AS APP_EMP_FLAG3 ");

                    sbQuery.Append(" ,WM.APP_EMP4 ");
                    sbQuery.Append(" ,ISNULL(WM.APP_EMP_FLAG4,'0') AS APP_EMP_FLAG4 ");

                    sbQuery.Append(" ,WM.IS_DIR_IN");
                    sbQuery.Append(" ,WM.IS_DIR_OUT");
                    sbQuery.Append(" ,WM.OUT_TYPE");
                    sbQuery.Append(" ,WM.OUT_VEN_CODE");
                    sbQuery.Append(" ,V.VEN_NAME AS OUT_VEN_NAME");
                    sbQuery.Append(" ,WM.REJECT_DATE");
                    sbQuery.Append(" ,WM.REJECT_REASON");

                    sbQuery.Append(" ,WM.REG_DATE");
                    sbQuery.Append(" ,WM.REG_EMP");
                    sbQuery.Append(" ,WM.MDFY_DATE");
                    sbQuery.Append(" ,WM.MDFY_EMP");
                    sbQuery.Append(" ,WM.DEL_DATE");
                    sbQuery.Append(" ,WM.DEL_EMP");
                    sbQuery.Append(" ,WM.DATA_FLAG");
                    sbQuery.Append(" FROM TSHP_WORK_MNG WM");
                    sbQuery.Append(" LEFT JOIN TSTD_WORKCODE WC");
                    sbQuery.Append(" ON WM.PLT_CODE = WC.PLT_CODE");
                    sbQuery.Append(" AND WM.WORK_CODE = WC.WORK_CODE");

                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE E");
                    sbQuery.Append(" ON WM.PLT_CODE = E.PLT_CODE");
                    sbQuery.Append(" AND WM.EMP_CODE = E.EMP_CODE");

                    sbQuery.Append(" LEFT JOIN TSTD_ORG O");
                    sbQuery.Append(" ON E.PLT_CODE = O.PLT_CODE");
                    sbQuery.Append(" AND E.ORG_CODE = O.ORG_CODE");

                    sbQuery.Append(" LEFT JOIN TSTD_VENDOR V");
                    sbQuery.Append(" ON WM.PLT_CODE = V.PLT_CODE");
                    sbQuery.Append(" AND WM.OUT_VEN_CODE = V.VEN_CODE");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder();

                        sbWhere.Append(" WHERE WM.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@WORK_ID", "WM.WORK_ID = @WORK_ID"));
                        sbWhere.Append(UTIL.GetWhere(row, "@REQ_STATUS", "WM.REQ_STATUS = @REQ_STATUS"));
                        sbWhere.Append(UTIL.GetWhere(row, "@EMP_CODE", "WM.EMP_CODE = @EMP_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@ORG_CODE", "E.ORG_CODE = @ORG_CODE"));
                        //sbWhere.Append(UTIL.GetWhere(row, "@S_REQ_DATE,@E_REQ_DATE", "CONVERT(VARCHAR(8), WM.REQ_DATE, 112) BETWEEN @S_REQ_DATE AND @E_REQ_DATE"));
                        //sbWhere.Append(UTIL.GetWhere(row, "@REQ_YEAR", "LEFT(CONVERT(VARCHAR(8), WM.REQ_DATE, 112),4) = @REQ_YEAR"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_STR_REQ_DATE,@E_STR_REQ_DATE", "WM.STR_REQ_DATE BETWEEN @S_STR_REQ_DATE AND @E_STR_REQ_DATE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_REQ_DATE,@E_REQ_DATE", "CONVERT(VARCHAR(8), WM.REQ_DATE, 112) BETWEEN @S_REQ_DATE AND @E_REQ_DATE"));

                        sbWhere.Append(UTIL.GetWhere(row, "@S_OUT_DATE,@E_OUT_DATE", "(@S_OUT_DATE BETWEEN CONVERT(VARCHAR(8), REQ_START_DATE, 112) AND CONVERT(VARCHAR(8), REQ_END_DATE, 112) OR @E_OUT_DATE BETWEEN CONVERT(VARCHAR(8), REQ_START_DATE, 112) AND CONVERT(VARCHAR(8), REQ_END_DATE, 112))"));

                        sbWhere.Append(UTIL.GetWhere(row, "@REQ_YEAR", "LEFT(WM.STR_REQ_DATE,4) = @REQ_YEAR"));
                        sbWhere.Append(UTIL.GetWhere(row, "@WORK_CODE", "WM.WORK_CODE = @WORK_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@IS_OUT", "WC.IS_OUT = '1'"));
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

        public static DataTable TSHP_WORK_MNG_QUERY9(DataTable dtParam, BizExecute.BizExecute bizExecute)
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
                    sbQuery.Append(" ,WM.REQ_STATUS");
                    sbQuery.Append(" ,WM.EMP_CODE");
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
                    sbQuery.Append(" ,WM.REG_DATE");
                    sbQuery.Append(" ,WM.REG_EMP");
                    sbQuery.Append(" ,WM.MDFY_DATE");
                    sbQuery.Append(" ,WM.MDFY_EMP");
                    sbQuery.Append(" ,WM.DEL_DATE");
                    sbQuery.Append(" ,WM.DEL_EMP");
                    sbQuery.Append(" ,WM.DATA_FLAG");
                    sbQuery.Append(" FROM TSHP_WORK_MNG WM");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder();

                        sbWhere.Append(" WHERE WM.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        //sbWhere.Append(UTIL.GetWhere(row, "@WORK_ID", "WM.WORK_ID = @WORK_ID"));
                        sbWhere.Append(UTIL.GetWhere(row, "@NON_WORK_ID", "WM.WORK_ID <> @NON_WORK_ID"));
                        sbWhere.Append(UTIL.GetWhere(row, "@EMP_CODE", "WM.EMP_CODE = @EMP_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@COMPARE_DATE", "@COMPARE_DATE BETWEEN CONVERT(VARCHAR(8), REQ_START_DATE, 112) AND CONVERT(VARCHAR(8), REQ_END_DATE, 112)"));
                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "WM.DATA_FLAG = @DATA_FLAG"));
                        sbWhere.Append(" AND WM.WORK_CODE IN ('W05', 'W06')");


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

        public static DataTable TSHP_WORK_MNG_QUERY10(DataTable dtParam, BizExecute.BizExecute bizExecute)
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
                    sbQuery.Append(" ,WM.REQ_STATUS");
                    sbQuery.Append(" ,WM.EMP_CODE");
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
                    sbQuery.Append(" ,WM.REG_DATE");
                    sbQuery.Append(" ,WM.REG_EMP");
                    sbQuery.Append(" ,WM.MDFY_DATE");
                    sbQuery.Append(" ,WM.MDFY_EMP");
                    sbQuery.Append(" ,WM.DEL_DATE");
                    sbQuery.Append(" ,WM.DEL_EMP");
                    sbQuery.Append(" ,WM.DATA_FLAG");
                    sbQuery.Append(" FROM TSHP_WORK_MNG WM");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder();

                        sbWhere.Append(" WHERE WM.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        //sbWhere.Append(UTIL.GetWhere(row, "@WORK_ID", "WM.WORK_ID = @WORK_ID"));
                        sbWhere.Append(UTIL.GetWhere(row, "@EMP_CODE", "WM.EMP_CODE = @EMP_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@WORK_CODE", "WM.WORK_CODE = @WORK_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@REQ_START_DATE", "CONVERT(VARCHAR(8), WM.REQ_START_DATE, 112) = @REQ_START_DATE"));
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
