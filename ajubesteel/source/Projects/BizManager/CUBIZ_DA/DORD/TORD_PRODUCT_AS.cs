using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BizExecute;
using System.Data;

namespace DORD
{
    public class TORD_PRODUCT_AS
    {

        public static DataTable TORD_PRODUCT_AS_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("  SELECT  ");
                    sbQuery.Append("  PLT_CODE ");
                    sbQuery.Append(" ,AS_NO ");
                    sbQuery.Append(" ,AS_EMP ");
                    sbQuery.Append(" ,ACCEPT_DATE ");
                    sbQuery.Append(" ,REQ_DATE ");
                    sbQuery.Append(" ,PROD_NAME ");
                    sbQuery.Append(" ,AS_DATE ");
                    sbQuery.Append(" ,CUSTOMER_EMP ");
                    sbQuery.Append(" ,CVND_CODE ");
                    sbQuery.Append(" ,AS_CHECK ");
                    sbQuery.Append(" ,AS_CONTENTS ");
                    sbQuery.Append(" ,PROD_CONTENTS ");
                    sbQuery.Append(" ,GUBUN_CHECK ");
                    sbQuery.Append(" ,CAUSE_CHECK ");
                    sbQuery.Append(" ,CAUSE_CONTENTS ");
                    sbQuery.Append(" ,WORK_CHECK ");
                    sbQuery.Append(" ,WORK_CONTENTS ");
                    sbQuery.Append(" ,WORK_IMG1 ");
                    sbQuery.Append(" ,WORK_IMG2 ");
                    sbQuery.Append(" ,WORK_IMG3 ");
                    sbQuery.Append(" ,WORK_IMG4 ");
                    sbQuery.Append(" ,RESULT_CHECK ");
                    sbQuery.Append(" ,RESULT_CONTENTS ");
                    sbQuery.Append(" ,CONFIRM_DATE ");
                    sbQuery.Append(" ,WORK_DATE ");
                    sbQuery.Append(" ,OCCUR_DATE ");
                    sbQuery.Append(" ,PLAN_CONTENTS ");
                    sbQuery.Append(" ,LAST_CHECK ");
                    sbQuery.Append(" ,LAST_CONTENTS ");
                    sbQuery.Append(" ,APP_STATUS ");
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
                    sbQuery.Append(" ,APP_ORG ");
                    sbQuery.Append("  FROM TORD_PRODUCT_AS  ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("  AND AS_NO = @AS_NO  ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "AS_NO")) isHasColumn = false;

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



        public static void TORD_PRODUCT_AS_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" INSERT INTO TORD_PRODUCT_AS (  ");
                    sbQuery.Append("  PLT_CODE ");
                    sbQuery.Append(" ,AS_NO ");
                    sbQuery.Append(" ,PROD_CODE ");
                    sbQuery.Append(" ,AS_EMP ");
                    sbQuery.Append(" ,ACCEPT_DATE ");
                    sbQuery.Append(" ,REQ_DATE ");
                    sbQuery.Append(" ,PROD_NAME ");
                    sbQuery.Append(" ,AS_DATE ");
                    sbQuery.Append(" ,CUSTOMER_EMP ");
                    sbQuery.Append(" ,CVND_CODE ");
                    sbQuery.Append(" ,AS_CHECK ");
                    sbQuery.Append(" ,AS_CONTENTS ");
                    sbQuery.Append(" ,PROD_CONTENTS ");
                    sbQuery.Append(" ,GUBUN_CHECK ");
                    sbQuery.Append(" ,CAUSE_CHECK ");
                    sbQuery.Append(" ,CAUSE_CONTENTS ");
                    sbQuery.Append(" ,WORK_CHECK ");
                    sbQuery.Append(" ,WORK_CONTENTS ");
                    sbQuery.Append(" ,WORK_IMG1 ");
                    sbQuery.Append(" ,WORK_IMG2 ");
                    sbQuery.Append(" ,WORK_IMG3 ");
                    sbQuery.Append(" ,WORK_IMG4 ");
                    sbQuery.Append(" ,RESULT_CHECK ");
                    sbQuery.Append(" ,RESULT_CONTENTS ");
                    sbQuery.Append(" ,CONFIRM_DATE ");
                    sbQuery.Append(" ,WORK_DATE ");
                    sbQuery.Append(" ,OCCUR_DATE ");
                    sbQuery.Append(" ,PLAN_CONTENTS ");
                    sbQuery.Append(" ,LAST_CHECK ");
                    sbQuery.Append(" ,LAST_CONTENTS ");
                    sbQuery.Append(" ,APP_ORG ");
                    sbQuery.Append(" ,APP_EMP1 ");
                    sbQuery.Append(" ,APP_EMP2 ");
                    sbQuery.Append(" ,APP_EMP3 ");
                    sbQuery.Append(" ,APP_EMP4 ");
                    sbQuery.Append(" ,REG_DATE ");
                    sbQuery.Append(" ,REG_EMP ");
                    sbQuery.Append(" ,DATA_FLAG ");
                    sbQuery.Append("  ) VALUES (  ");
                    sbQuery.Append("  @PLT_CODE ");
                    sbQuery.Append(" ,@AS_NO ");
                    sbQuery.Append(" ,@PROD_CODE ");
                    sbQuery.Append(" ,@AS_EMP ");
                    sbQuery.Append(" ,@ACCEPT_DATE ");
                    sbQuery.Append(" ,@REQ_DATE ");
                    sbQuery.Append(" ,@PROD_NAME ");
                    sbQuery.Append(" ,@AS_DATE ");
                    sbQuery.Append(" ,@CUSTOMER_EMP ");
                    sbQuery.Append(" ,@CVND_CODE ");
                    sbQuery.Append(" ,@AS_CHECK ");
                    sbQuery.Append(" ,@AS_CONTENTS ");
                    sbQuery.Append(" ,@PROD_CONTENTS ");
                    sbQuery.Append(" ,@GUBUN_CHECK ");
                    sbQuery.Append(" ,@CAUSE_CHECK ");
                    sbQuery.Append(" ,@CAUSE_CONTENTS ");
                    sbQuery.Append(" ,@WORK_CHECK ");
                    sbQuery.Append(" ,@WORK_CONTENTS ");
                    sbQuery.Append(" ,@WORK_IMG1 ");
                    sbQuery.Append(" ,@WORK_IMG2 ");
                    sbQuery.Append(" ,@WORK_IMG3 ");
                    sbQuery.Append(" ,@WORK_IMG4 ");
                    sbQuery.Append(" ,@RESULT_CHECK ");
                    sbQuery.Append(" ,@RESULT_CONTENTS ");
                    sbQuery.Append(" ,@CONFIRM_DATE ");
                    sbQuery.Append(" ,@WORK_DATE ");
                    sbQuery.Append(" ,@OCCUR_DATE ");
                    sbQuery.Append(" ,@PLAN_CONTENTS ");
                    sbQuery.Append(" ,@LAST_CHECK ");
                    sbQuery.Append(" ,@LAST_CONTENTS ");
                    sbQuery.Append(" ,@APP_ORG ");
                    sbQuery.Append(" ,@APP_EMP1 ");
                    sbQuery.Append(" ,@APP_EMP2 ");
                    sbQuery.Append(" ,@APP_EMP3 ");
                    sbQuery.Append(" ,@APP_EMP4 ");
                    sbQuery.Append(" ,GETDATE() ");
                    sbQuery.Append(" ,'" + ConnInfo.UserID + "'");
                    sbQuery.Append(" ,0 ");
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

        public static void TORD_PRODUCT_AS_INS2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" INSERT INTO TORD_PRODUCT_AS (  ");
                    sbQuery.Append("  PLT_CODE ");
                    sbQuery.Append(" ,AS_NO ");
                    sbQuery.Append(" ,PROD_CODE ");
                    sbQuery.Append(" ,AS_EMP ");
                    sbQuery.Append(" ,ACCEPT_DATE ");
                    sbQuery.Append(" ,PROD_NAME ");
                    sbQuery.Append(" ,AS_DATE ");
                    sbQuery.Append(" ,CUSTOMER_EMP ");
                    sbQuery.Append(" ,CVND_CODE ");
                    sbQuery.Append(" ,REG_DATE ");
                    sbQuery.Append(" ,REG_EMP ");
                    sbQuery.Append(" ,DATA_FLAG ");
                    sbQuery.Append("  ) VALUES (  ");
                    sbQuery.Append("  @PLT_CODE ");
                    sbQuery.Append(" ,@AS_NO ");
                    sbQuery.Append(" ,@PROD_CODE ");
                    sbQuery.Append(" ,@AS_EMP ");
                    sbQuery.Append(" ,@ACCEPT_DATE ");
                    sbQuery.Append(" ,@PROD_NAME ");
                    sbQuery.Append(" ,@AS_DATE ");
                    sbQuery.Append(" ,@CUSTOMER_EMP ");
                    sbQuery.Append(" ,@CVND_CODE ");
                    sbQuery.Append(" ,GETDATE() ");
                    sbQuery.Append(" ,'" + ConnInfo.UserID + "'");
                    sbQuery.Append(" ,0 ");
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



        public static void TORD_PRODUCT_AS_UPD(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TORD_PRODUCT_AS SET  ");
                    sbQuery.Append("  AS_EMP = @AS_EMP ");
                    sbQuery.Append(" ,ACCEPT_DATE = @ACCEPT_DATE ");
                    sbQuery.Append(" ,REQ_DATE = @REQ_DATE ");
                    sbQuery.Append(" ,PROD_NAME = @PROD_NAME ");
                    sbQuery.Append(" ,AS_DATE = @AS_DATE ");
                    sbQuery.Append(" ,CUSTOMER_EMP = @CUSTOMER_EMP ");
                    sbQuery.Append(" ,CVND_CODE = @CVND_CODE ");
                    sbQuery.Append(" ,AS_CHECK = @AS_CHECK ");
                    sbQuery.Append(" ,AS_CONTENTS = @AS_CONTENTS ");
                    sbQuery.Append(" ,PROD_CONTENTS = @PROD_CONTENTS ");
                    sbQuery.Append(" ,GUBUN_CHECK = @GUBUN_CHECK ");
                    sbQuery.Append(" ,CAUSE_CHECK = @CAUSE_CHECK ");
                    sbQuery.Append(" ,CAUSE_CONTENTS = @CAUSE_CONTENTS ");
                    sbQuery.Append(" ,WORK_CHECK = @WORK_CHECK ");
                    sbQuery.Append(" ,WORK_CONTENTS = @WORK_CONTENTS ");
                    sbQuery.Append(" ,WORK_IMG1 = @WORK_IMG1 ");
                    sbQuery.Append(" ,WORK_IMG2 = @WORK_IMG2 ");
                    sbQuery.Append(" ,WORK_IMG3 = @WORK_IMG3 ");
                    sbQuery.Append(" ,WORK_IMG4 = @WORK_IMG4 ");
                    sbQuery.Append(" ,RESULT_CHECK = @RESULT_CHECK ");
                    sbQuery.Append(" ,RESULT_CONTENTS = @RESULT_CONTENTS ");
                    sbQuery.Append(" ,CONFIRM_DATE = @CONFIRM_DATE ");
                    sbQuery.Append(" ,WORK_DATE = @WORK_DATE ");
                    sbQuery.Append(" ,OCCUR_DATE = @OCCUR_DATE ");
                    sbQuery.Append(" ,PLAN_CONTENTS = @PLAN_CONTENTS ");
                    sbQuery.Append(" ,LAST_CHECK = @LAST_CHECK ");
                    sbQuery.Append(" ,LAST_CONTENTS = @LAST_CONTENTS ");
                    sbQuery.Append(" ,MDFY_DATE = GETDATE() ");
                    sbQuery.Append(" ,MDFY_EMP ='" + ConnInfo.UserID + "'");
                    sbQuery.Append(" ,DATA_FLAG = @DATA_FLAG ");

                    sbQuery.Append(" ,APP_EMP1 = @APP_EMP1 ");
                    sbQuery.Append(" ,APP_EMP2 = @APP_EMP2 ");
                    sbQuery.Append(" ,APP_EMP3 = @APP_EMP3 ");
                    sbQuery.Append(" ,APP_EMP4 = @APP_EMP4 ");
                    sbQuery.Append(" ,APP_ORG = @APP_ORG ");

                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append("  AND AS_NO = @AS_NO ");
                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "AS_NO")) isHasColumn = false;

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

        /// <summary>
        /// 승인자 업데이트
        /// </summary>
        /// <param name="dtParam"></param>
        /// <param name="bizExecute"></param>
        public static void TORD_PRODUCT_AS_UPD2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" UPDATE TORD_PRODUCT_AS ");
                    sbQuery.Append("    SET APP_STATUS   = @APP_STATUS   ");
                    sbQuery.Append("    ,APP_EMP1 = @APP_EMP1   ");
                    sbQuery.Append("    ,APP_EMP_FLAG1 = @APP_EMP_FLAG1   ");
                    sbQuery.Append("    ,APP_EMP2 = @APP_EMP2   ");
                    sbQuery.Append("    ,APP_EMP_FLAG2 = @APP_EMP_FLAG2   ");
                    sbQuery.Append("    ,APP_EMP3 = @APP_EMP3   ");
                    sbQuery.Append("    ,APP_EMP_FLAG3 = @APP_EMP_FLAG3   ");
                    sbQuery.Append("    ,APP_EMP4 = @APP_EMP4   ");
                    sbQuery.Append("    ,APP_EMP_FLAG4 = @APP_EMP_FLAG4   ");
                    sbQuery.Append("    ,MDFY_DATE = GETDATE() ");
                    sbQuery.Append("    ,MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("    AND AS_NO = @AS_NO  ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "AS_NO")) isHasColumn = false;

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


        public static void TORD_PRODUCT_AS_UDE(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TORD_PRODUCT_AS SET  ");                    
                    sbQuery.Append(" DEL_DATE = GETDATE() ");
                    sbQuery.Append(" ,DEL_EMP ='" + ConnInfo.UserID + "'");
                    sbQuery.Append(" ,DATA_FLAG = 2 ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append("  AND AS_NO = @AS_NO ");
                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "AS_NO")) isHasColumn = false;

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

    public class TORD_PRODUCT_AS_QUERY
    {
        public static DataTable TORD_PRODUCT_AS_QUERY1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {


                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("  SELECT  ");
                    sbQuery.Append("  A.PLT_CODE ");
                    sbQuery.Append(" ,A.AS_NO ");
                    sbQuery.Append(" ,A.PROD_CODE ");
                    sbQuery.Append(" ,A.AS_EMP ");
                    sbQuery.Append(" ,A.ACCEPT_DATE ");
                    sbQuery.Append(" ,A.REQ_DATE ");
                    sbQuery.Append(" ,A.PROD_NAME ");
                    sbQuery.Append(" ,A.AS_DATE ");
                    sbQuery.Append(" ,A.CUSTOMER_EMP ");
                    sbQuery.Append(" ,A.CVND_CODE ");
                    sbQuery.Append(" ,CVND.VEN_NAME AS CVND_NAME ");
                    sbQuery.Append(" ,A.AS_CHECK ");
                    sbQuery.Append(" ,A.AS_CONTENTS ");
                    sbQuery.Append(" ,A.PROD_CONTENTS ");
                    sbQuery.Append(" ,A.GUBUN_CHECK ");
                    sbQuery.Append(" ,A.CAUSE_CHECK ");
                    sbQuery.Append(" ,A.CAUSE_CONTENTS ");
                    sbQuery.Append(" ,A.WORK_CHECK ");
                    sbQuery.Append(" ,A.WORK_CONTENTS ");
                    //sbQuery.Append(" ,A.WORK_IMG1 ");
                    //sbQuery.Append(" ,A.WORK_IMG2 ");
                    //sbQuery.Append(" ,A.WORK_IMG3 ");
                    //sbQuery.Append(" ,A.WORK_IMG4 ");
                    sbQuery.Append(" ,A.RESULT_CHECK ");
                    sbQuery.Append(" ,A.RESULT_CONTENTS ");
                    sbQuery.Append(" ,A.CONFIRM_DATE ");
                    sbQuery.Append(" ,A.WORK_DATE ");
                    sbQuery.Append(" ,A.OCCUR_DATE ");
                    sbQuery.Append(" ,A.PLAN_CONTENTS ");
                    sbQuery.Append(" ,A.LAST_CHECK ");
                    sbQuery.Append(" ,A.LAST_CONTENTS ");
                    sbQuery.Append(" ,ISNULL(A.APP_EMP1,APP.APP_EMP1) AS APP_EMP1 ");
                    sbQuery.Append(" ,ISNULL(A.APP_EMP2,APP.APP_EMP2) AS APP_EMP2 ");
                    sbQuery.Append(" ,ISNULL(A.APP_EMP3,APP.APP_EMP3) AS APP_EMP3 ");
                    sbQuery.Append(" ,ISNULL(A.APP_EMP4,APP.APP_EMP4) AS APP_EMP4 ");
                    sbQuery.Append(" ,CASE WHEN A.APP_EMP1 IS NULL THEN '0' ELSE '1' END AS APP_EMP1_OK");
                    sbQuery.Append(" ,CASE WHEN A.APP_EMP2 IS NULL THEN '0' ELSE '1' END AS APP_EMP2_OK ");
                    sbQuery.Append(" ,CASE WHEN A.APP_EMP3 IS NULL THEN '0' ELSE '1' END AS APP_EMP3_OK ");
                    sbQuery.Append(" ,CASE WHEN A.APP_EMP4 IS NULL THEN '0' ELSE '1' END AS APP_EMP4_OK ");
                    sbQuery.Append(" ,A.APP_ORG ");
                    sbQuery.Append(" ,O.ORG_NAME AS APP_ORG_NAME ");
                    sbQuery.Append(" ,A.REG_DATE ");
                    sbQuery.Append(" ,REG.EMP_NAME AS REG_EMP_NAME");
                    sbQuery.Append(" ,A.MDFY_DATE");
                    sbQuery.Append(" ,A.MDFY_EMP");
                    sbQuery.Append(" ,MDFY.EMP_NAME AS MDFY_EMP_NAME");
                    sbQuery.Append("  FROM TORD_PRODUCT_AS  A ");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE REG");
                    sbQuery.Append(" ON A.PLT_CODE = REG.PLT_CODE");
                    sbQuery.Append(" AND A.REG_EMP = REG.EMP_CODE");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE MDFY");
                    sbQuery.Append(" ON A.PLT_CODE = MDFY.PLT_CODE");
                    sbQuery.Append(" AND A.MDFY_EMP = MDFY.EMP_CODE");
                    sbQuery.Append(" LEFT JOIN TSTD_VENDOR CVND");
                    sbQuery.Append(" ON A.PLT_CODE = CVND.PLT_CODE");
                    sbQuery.Append(" AND A.CVND_CODE = CVND.VEN_CODE");
                    sbQuery.Append(" LEFT JOIN TSTD_APP_EMP APP ");
                    sbQuery.Append(" ON A.PLT_CODE = APP.PLT_CODE");
                    sbQuery.Append(" AND APP.APP_TYPE = 'AS' ");
                    sbQuery.Append(" AND A.APP_ORG = APP.ORG_CODE ");
                    sbQuery.Append(" LEFT JOIN TSTD_ORG O ");
                    sbQuery.Append(" ON A.PLT_CODE = O.PLT_CODE");
                    sbQuery.Append(" AND A.APP_ORG = O.ORG_CODE ");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE A.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@AS_NO", "A.AS_NO = @AS_NO"));

                        sbWhere.Append(UTIL.GetWhere(row, "@S_ACCEPT_DATE, @E_ACCEPT_DATE", "A.ACCEPT_DATE BETWEEN @S_ACCEPT_DATE AND @E_ACCEPT_DATE"));                        
                        sbWhere.Append(UTIL.GetWhere(row, "@S_AS_DATE, @E_AS_DATE", "(A.AS_DATE BETWEEN @S_AS_DATE AND @E_AS_DATE)"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_LIKE", "A.PROD_NAME LIKE '%' + @PROD_LIKE + '%'"));
                        sbWhere.Append(UTIL.GetWhere(row, "@CVND_LIKE", "A.CVND_CODE LIKE '%' + @CVND_LIKE + '%' OR CVND.VEN_NAME LIKE '%' + @CVND_LIKE + '%'"));

                        sbWhere.Append(UTIL.GetWhere(row, "@AS_EMP", "A.AS_EMP = @AS_EMP"));
                        
                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "A.DATA_FLAG = @DATA_FLAG"));

                        sbWhere.Append(" ORDER BY A.AS_NO ");

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
        /// <summary>
        /// 사진 가져오기
        /// </summary>
        /// <param name="dtParam"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataTable TORD_PRODUCT_AS_QUERY2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {


                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("  SELECT  ");
                    sbQuery.Append("  A.PLT_CODE ");
                    //sbQuery.Append(" ,A.AS_NO ");
                    //sbQuery.Append(" ,A.AS_EMP ");
                    //sbQuery.Append(" ,A.ACCEPT_DATE ");
                    //sbQuery.Append(" ,A.REQ_DATE ");
                    //sbQuery.Append(" ,A.PROD_NAME ");
                    //sbQuery.Append(" ,A.AS_DATE ");
                    //sbQuery.Append(" ,A.CUSTOMER_EMP ");
                    //sbQuery.Append(" ,A.CVND_CODE ");
                    //sbQuery.Append(" ,A.AS_CHECK ");
                    //sbQuery.Append(" ,A.AS_CONTENTS ");
                    //sbQuery.Append(" ,A.PROD_CONTENTS ");
                    //sbQuery.Append(" ,A.GUBUN_CHECK ");
                    //sbQuery.Append(" ,A.CAUSE_CHECK ");
                    //sbQuery.Append(" ,A.CAUSE_CONTENTS ");
                    //sbQuery.Append(" ,A.WORK_CHECK ");
                    //sbQuery.Append(" ,A.WORK_CONTENTS ");
                    sbQuery.Append(" ,A.WORK_IMG1 ");
                    sbQuery.Append(" ,A.WORK_IMG2 ");
                    sbQuery.Append(" ,A.WORK_IMG3 ");
                    sbQuery.Append(" ,A.WORK_IMG4 ");
                    //sbQuery.Append(" ,A.RESULT_CHECK ");
                    //sbQuery.Append(" ,A.RESULT_CONTENTS ");
                    //sbQuery.Append(" ,A.CONFIRM_DATE ");
                    //sbQuery.Append(" ,A.WORK_DATE ");
                    //sbQuery.Append(" ,A.OCCUR_DATE ");
                    //sbQuery.Append(" ,A.PLAN_CONTENTS ");
                    //sbQuery.Append(" ,A.LAST_CHECK ");
                    //sbQuery.Append(" ,A.LAST_CONTENTS ");
                    //sbQuery.Append(" ,A.REG_DATE ");
                    //sbQuery.Append(" ,REG.EMP_NAME AS REG_EMP_NAME");
                    //sbQuery.Append(" ,A.MDFY_DATE");
                    //sbQuery.Append(" ,A.MDFY_EMP");
                    //sbQuery.Append(" ,MDFY.EMP_NAME AS MDFY_EMP_NAME");
                    sbQuery.Append("  FROM TORD_PRODUCT_AS  A ");
                    //sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE REG");
                    //sbQuery.Append(" ON A.PLT_CODE = REG.PLT_CODE");
                    //sbQuery.Append(" AND A.REG_EMP = REG.EMP_CODE");
                    //sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE MDFY");
                    //sbQuery.Append(" ON A.PLT_CODE = MDFY.PLT_CODE");
                    //sbQuery.Append(" AND A.MDFY_EMP = MDFY.EMP_CODE");
                    //sbQuery.Append(" LEFT JOIN TSTD_VENDOR CVND");
                    //sbQuery.Append(" ON A.PLT_CODE = CVND.PLT_CODE");
                    //sbQuery.Append(" AND A.CVND_CODE = CVND.VEN_CODE");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE A.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@AS_NO", "A.AS_NO = @AS_NO"));

                        //sbWhere.Append(UTIL.GetWhere(row, "@S_ACCEPT_DATE, @E_ACCEPT_DATE", "A.ACCEPT_DATE BETWEEN @S_ACCEPT_DATE AND @E_ACCEPT_DATE"));
                        //sbWhere.Append(UTIL.GetWhere(row, "@S_AS_DATE, @E_AS_DATE", "(A.AS_DATE BETWEEN @S_AS_DATE AND @E_AS_DATE)"));
                        //sbWhere.Append(UTIL.GetWhere(row, "@PROD_LIKE", "A.PROD_NAME LIKE '%' + @PROD_LIKE + '%'"));
                        //sbWhere.Append(UTIL.GetWhere(row, "@CVND_LIKE", "A.CVND_CODE LIKE '%' + @CVND_LIKE + '%' OR CVND.VEN_NAME LIKE '%' + @CVND_LIKE + '%'"));

                        //sbWhere.Append(UTIL.GetWhere(row, "@AS_EMP", "A.AS_EMP = @AS_EMP"));

                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "A.DATA_FLAG = @DATA_FLAG"));

                        sbWhere.Append(" ORDER BY A.AS_NO ");

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


        public static DataTable TORD_PRODUCT_AS_QUERY3(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {


                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("  SELECT  ");
                    sbQuery.Append("  A.PLT_CODE ");
                    sbQuery.Append(" ,A.AS_NO ");
                    sbQuery.Append(" ,A.AS_EMP ");
                    sbQuery.Append(" ,A.ACCEPT_DATE ");
                    sbQuery.Append(" ,A.REQ_DATE ");
                    sbQuery.Append(" ,A.PROD_NAME ");
                    sbQuery.Append(" ,A.AS_DATE ");
                    sbQuery.Append(" ,A.CUSTOMER_EMP ");
                    sbQuery.Append(" ,A.CVND_CODE ");
                    sbQuery.Append(" ,CVND.VEN_NAME AS CVND_NAME ");
                    sbQuery.Append(" ,A.AS_CHECK ");
                    sbQuery.Append(" ,A.AS_CONTENTS ");
                    sbQuery.Append(" ,A.PROD_CONTENTS ");
                    sbQuery.Append(" ,A.GUBUN_CHECK ");
                    sbQuery.Append(" ,A.CAUSE_CHECK ");
                    sbQuery.Append(" ,A.CAUSE_CONTENTS ");
                    sbQuery.Append(" ,A.WORK_CHECK ");
                    sbQuery.Append(" ,A.WORK_CONTENTS ");
                    //sbQuery.Append(" ,A.WORK_IMG1 ");
                    //sbQuery.Append(" ,A.WORK_IMG2 ");
                    //sbQuery.Append(" ,A.WORK_IMG3 ");
                    //sbQuery.Append(" ,A.WORK_IMG4 ");
                    sbQuery.Append(" ,A.RESULT_CHECK ");
                    sbQuery.Append(" ,A.RESULT_CONTENTS ");
                    sbQuery.Append(" ,A.CONFIRM_DATE ");
                    sbQuery.Append(" ,A.WORK_DATE ");
                    sbQuery.Append(" ,A.OCCUR_DATE ");
                    sbQuery.Append(" ,A.PLAN_CONTENTS ");
                    sbQuery.Append(" ,A.LAST_CHECK ");
                    sbQuery.Append(" ,A.LAST_CONTENTS ");
                    sbQuery.Append(" ,A.REG_DATE ");
                    sbQuery.Append(" ,REG.EMP_NAME AS REG_EMP_NAME");
                    sbQuery.Append(" ,A.MDFY_DATE");
                    sbQuery.Append(" ,A.MDFY_EMP");
                    sbQuery.Append(" ,MDFY.EMP_NAME AS MDFY_EMP_NAME");
                    sbQuery.Append(" ,A.APP_EMP1");
                    sbQuery.Append(" ,A.APP_EMP2");
                    sbQuery.Append(" ,A.APP_EMP3");
                    sbQuery.Append(" ,A.APP_EMP4");
                    sbQuery.Append(" ,A.APP_ORG");
                    sbQuery.Append("  FROM TORD_PRODUCT_AS  A ");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE REG");
                    sbQuery.Append(" ON A.PLT_CODE = REG.PLT_CODE");
                    sbQuery.Append(" AND A.REG_EMP = REG.EMP_CODE");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE MDFY");
                    sbQuery.Append(" ON A.PLT_CODE = MDFY.PLT_CODE");
                    sbQuery.Append(" AND A.MDFY_EMP = MDFY.EMP_CODE");
                    sbQuery.Append(" LEFT JOIN TSTD_VENDOR CVND");
                    sbQuery.Append(" ON A.PLT_CODE = CVND.PLT_CODE");
                    sbQuery.Append(" AND A.CVND_CODE = CVND.VEN_CODE");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE A.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@AS_NO", "A.AS_NO = @AS_NO"));

                        sbWhere.Append(UTIL.GetWhere(row, "@S_ACCEPT_DATE, @E_ACCEPT_DATE", "A.ACCEPT_DATE BETWEEN @S_ACCEPT_DATE AND @E_ACCEPT_DATE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_AS_DATE, @E_AS_DATE", "(A.AS_DATE BETWEEN @S_AS_DATE AND @E_AS_DATE)"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_LIKE", "A.PROD_NAME LIKE '%' + @PROD_LIKE + '%'"));
                        sbWhere.Append(UTIL.GetWhere(row, "@CVND_LIKE", "A.CVND_CODE LIKE '%' + @CVND_LIKE + '%' OR CVND.VEN_NAME LIKE '%' + @CVND_LIKE + '%'"));

                        sbWhere.Append(UTIL.GetWhere(row, "@AS_EMP", "A.AS_EMP = @AS_EMP"));

                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "A.DATA_FLAG = @DATA_FLAG"));

                        sbWhere.Append(" ORDER BY A.AS_NO ");

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

        public static DataTable TORD_PRODUCT_AS_QUERY4(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {


                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("  SELECT  ");
                    sbQuery.Append("  A.PLT_CODE ");
                    sbQuery.Append(" ,A.AS_NO ");
                    sbQuery.Append(" ,A.AS_EMP ");
                    sbQuery.Append(" ,A.ACCEPT_DATE ");
                    sbQuery.Append(" ,A.REQ_DATE ");
                    sbQuery.Append(" ,A.PROD_NAME ");
                    sbQuery.Append(" ,A.AS_DATE ");
                    sbQuery.Append(" ,A.CUSTOMER_EMP ");
                    sbQuery.Append(" ,A.CVND_CODE ");
                    sbQuery.Append(" ,CVND.VEN_NAME AS CVND_NAME ");
                    sbQuery.Append(" ,A.AS_CHECK ");
                    sbQuery.Append(" ,A.AS_CONTENTS ");
                    sbQuery.Append(" ,A.PROD_CONTENTS ");
                    sbQuery.Append(" ,A.GUBUN_CHECK ");
                    sbQuery.Append(" ,A.CAUSE_CHECK ");
                    sbQuery.Append(" ,A.CAUSE_CONTENTS ");
                    sbQuery.Append(" ,A.WORK_CHECK ");
                    sbQuery.Append(" ,A.WORK_CONTENTS ");
                    sbQuery.Append(" ,A.RESULT_CHECK ");
                    sbQuery.Append(" ,A.RESULT_CONTENTS ");
                    sbQuery.Append(" ,A.CONFIRM_DATE ");
                    sbQuery.Append(" ,A.WORK_DATE ");
                    sbQuery.Append(" ,A.OCCUR_DATE ");
                    sbQuery.Append(" ,A.PLAN_CONTENTS ");
                    sbQuery.Append(" ,A.LAST_CHECK ");
                    sbQuery.Append(" ,A.LAST_CONTENTS ");
                    sbQuery.Append(" ,ISNULL(A.APP_EMP1,APP.APP_EMP1) AS APP_EMP1");
                    sbQuery.Append(" ,ISNULL(A.APP_EMP_FLAG1,'0') AS APP_EMP_FLAG1");

                    sbQuery.Append(" ,ISNULL(A.APP_EMP2,APP.APP_EMP2) AS APP_EMP2");
                    sbQuery.Append(" ,ISNULL(A.APP_EMP_FLAG2,'0') AS APP_EMP_FLAG2");

                    sbQuery.Append(" ,ISNULL(A.APP_EMP3,APP.APP_EMP3) AS APP_EMP3");
                    sbQuery.Append(" ,ISNULL(A.APP_EMP_FLAG3,'0') AS APP_EMP_FLAG3");

                    sbQuery.Append(" ,ISNULL(A.APP_EMP4,APP.APP_EMP4) AS APP_EMP4");
                    sbQuery.Append(" ,ISNULL(A.APP_EMP_FLAG4,'0') AS APP_EMP_FLAG4");
                    sbQuery.Append(" ,A.APP_ORG ");
                    sbQuery.Append(" ,A.REG_DATE ");
                    sbQuery.Append(" ,REG.EMP_NAME AS REG_EMP_NAME");
                    sbQuery.Append(" ,A.MDFY_DATE");
                    sbQuery.Append(" ,A.MDFY_EMP");
                    sbQuery.Append(" ,MDFY.EMP_NAME AS MDFY_EMP_NAME");
                    sbQuery.Append("  FROM TORD_PRODUCT_AS  A ");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE REG");
                    sbQuery.Append(" ON A.PLT_CODE = REG.PLT_CODE");
                    sbQuery.Append(" AND A.REG_EMP = REG.EMP_CODE");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE MDFY");
                    sbQuery.Append(" ON A.PLT_CODE = MDFY.PLT_CODE");
                    sbQuery.Append(" AND A.MDFY_EMP = MDFY.EMP_CODE");
                    sbQuery.Append(" LEFT JOIN TSTD_VENDOR CVND");
                    sbQuery.Append(" ON A.PLT_CODE = CVND.PLT_CODE");
                    sbQuery.Append(" AND A.CVND_CODE = CVND.VEN_CODE");
                    sbQuery.Append(" LEFT JOIN TSTD_APP_EMP APP ");
                    sbQuery.Append(" ON A.PLT_CODE = APP.PLT_CODE");
                    sbQuery.Append(" AND APP.APP_TYPE = 'AS' ");
                    sbQuery.Append(" AND A.APP_ORG = APP.ORG_CODE ");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE A.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@AS_NO", "A.AS_NO = @AS_NO"));

                        sbWhere.Append(UTIL.GetWhere(row, "@S_ACCEPT_DATE, @E_ACCEPT_DATE", "A.ACCEPT_DATE BETWEEN @S_ACCEPT_DATE AND @E_ACCEPT_DATE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_AS_DATE, @E_AS_DATE", "(A.AS_DATE BETWEEN @S_AS_DATE AND @E_AS_DATE)"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_LIKE", "A.PROD_NAME LIKE '%' + @PROD_LIKE + '%'"));
                        sbWhere.Append(UTIL.GetWhere(row, "@CVND_LIKE", "A.CVND_CODE LIKE '%' + @CVND_LIKE + '%' OR CVND.VEN_NAME LIKE '%' + @CVND_LIKE + '%'"));

                        sbWhere.Append(UTIL.GetWhere(row, "@AS_EMP", "A.AS_EMP = @AS_EMP"));

                        string sQuery = "((ISNULL(A.APP_EMP1,APP.APP_EMP1) = @REG_EMP AND ISNULL(A.APP_EMP_FLAG1,'0') = '0')";
                        sQuery += " OR (ISNULL(A.APP_EMP2,APP.APP_EMP2) = @REG_EMP AND ISNULL(A.APP_EMP_FLAG1,'0') = '1' AND ISNULL(A.APP_EMP_FLAG2,'0') = '0')";
                        sQuery += " OR (ISNULL(A.APP_EMP3,APP.APP_EMP3) = @REG_EMP AND ISNULL(A.APP_EMP_FLAG1,'0') = '1' AND ISNULL(A.APP_EMP_FLAG2,'0') = '1' AND ISNULL(A.APP_EMP_FLAG3,'0') = '0')";
                        sQuery += " OR (ISNULL(A.APP_EMP4,APP.APP_EMP4) = @REG_EMP AND ISNULL(A.APP_EMP_FLAG1,'0') = '1' AND ISNULL(A.APP_EMP_FLAG2,'0') = '1' AND ISNULL(A.APP_EMP_FLAG3,'0') = '1' AND ISNULL(A.APP_EMP_FLAG4,'0') = '0'))";

                        sbWhere.Append(UTIL.GetWhere(row, "@REG_EMP", sQuery));

                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "A.DATA_FLAG = @DATA_FLAG"));

                        sbWhere.Append(" ORDER BY A.AS_NO ");

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

        public static DataTable TORD_PRODUCT_AS_QUERY5(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {


                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("  SELECT  ");
                    sbQuery.Append("  A.PLT_CODE ");
                    sbQuery.Append(" ,A.AS_NO ");
                    sbQuery.Append(" ,A.AS_EMP ");
                    sbQuery.Append(" ,A.ACCEPT_DATE ");
                    sbQuery.Append(" ,A.REQ_DATE ");
                    sbQuery.Append(" ,A.PROD_NAME ");
                    sbQuery.Append(" ,A.AS_DATE ");
                    sbQuery.Append(" ,A.CUSTOMER_EMP ");
                    sbQuery.Append(" ,A.CVND_CODE ");
                    sbQuery.Append(" ,CVND.VEN_NAME AS CVND_NAME ");
                    sbQuery.Append(" ,A.AS_CHECK ");
                    sbQuery.Append(" ,A.AS_CONTENTS ");
                    sbQuery.Append(" ,A.PROD_CONTENTS ");
                    sbQuery.Append(" ,A.GUBUN_CHECK ");
                    sbQuery.Append(" ,A.CAUSE_CHECK ");
                    sbQuery.Append(" ,A.CAUSE_CONTENTS ");
                    sbQuery.Append(" ,A.WORK_CHECK ");
                    sbQuery.Append(" ,A.WORK_CONTENTS ");
                    sbQuery.Append(" ,A.RESULT_CHECK ");
                    sbQuery.Append(" ,A.RESULT_CONTENTS ");
                    sbQuery.Append(" ,A.CONFIRM_DATE ");
                    sbQuery.Append(" ,A.WORK_DATE ");
                    sbQuery.Append(" ,A.OCCUR_DATE ");
                    sbQuery.Append(" ,A.PLAN_CONTENTS ");
                    sbQuery.Append(" ,A.LAST_CHECK ");
                    sbQuery.Append(" ,A.LAST_CONTENTS ");
                    sbQuery.Append(" ,ISNULL(A.APP_EMP1,APP.APP_EMP1) AS APP_EMP1");
                    sbQuery.Append(" ,ISNULL(A.APP_EMP_FLAG1,'0') AS APP_EMP_FLAG1");

                    sbQuery.Append(" ,ISNULL(A.APP_EMP2,APP.APP_EMP2) AS APP_EMP2");
                    sbQuery.Append(" ,ISNULL(A.APP_EMP_FLAG2,'0') AS APP_EMP_FLAG2");

                    sbQuery.Append(" ,ISNULL(A.APP_EMP3,APP.APP_EMP3) AS APP_EMP3");
                    sbQuery.Append(" ,ISNULL(A.APP_EMP_FLAG3,'0') AS APP_EMP_FLAG3");

                    sbQuery.Append(" ,ISNULL(A.APP_EMP4,APP.APP_EMP4) AS APP_EMP4");
                    sbQuery.Append(" ,ISNULL(A.APP_EMP_FLAG4,'0') AS APP_EMP_FLAG4");
                    sbQuery.Append(" ,A.APP_ORG ");
                    sbQuery.Append(" ,A.REG_DATE ");
                    sbQuery.Append(" ,REG.EMP_NAME AS REG_EMP_NAME");
                    sbQuery.Append(" ,A.MDFY_DATE");
                    sbQuery.Append(" ,A.MDFY_EMP");
                    sbQuery.Append(" ,MDFY.EMP_NAME AS MDFY_EMP_NAME");
                    sbQuery.Append("  FROM TORD_PRODUCT_AS  A ");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE REG");
                    sbQuery.Append(" ON A.PLT_CODE = REG.PLT_CODE");
                    sbQuery.Append(" AND A.REG_EMP = REG.EMP_CODE");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE MDFY");
                    sbQuery.Append(" ON A.PLT_CODE = MDFY.PLT_CODE");
                    sbQuery.Append(" AND A.MDFY_EMP = MDFY.EMP_CODE");
                    sbQuery.Append(" LEFT JOIN TSTD_VENDOR CVND");
                    sbQuery.Append(" ON A.PLT_CODE = CVND.PLT_CODE");
                    sbQuery.Append(" AND A.CVND_CODE = CVND.VEN_CODE");
                    sbQuery.Append(" LEFT JOIN TSTD_APP_EMP APP ");
                    sbQuery.Append(" ON A.PLT_CODE = APP.PLT_CODE");
                    sbQuery.Append(" AND APP.APP_TYPE = 'AS' ");
                    sbQuery.Append(" AND A.APP_ORG = APP.ORG_CODE ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE A.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@AS_NO", "A.AS_NO = @AS_NO"));

                        sbWhere.Append(UTIL.GetWhere(row, "@S_ACCEPT_DATE, @E_ACCEPT_DATE", "A.ACCEPT_DATE BETWEEN @S_ACCEPT_DATE AND @E_ACCEPT_DATE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_AS_DATE, @E_AS_DATE", "(A.AS_DATE BETWEEN @S_AS_DATE AND @E_AS_DATE)"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_LIKE", "A.PROD_NAME LIKE '%' + @PROD_LIKE + '%'"));
                        sbWhere.Append(UTIL.GetWhere(row, "@CVND_LIKE", "A.CVND_CODE LIKE '%' + @CVND_LIKE + '%' OR CVND.VEN_NAME LIKE '%' + @CVND_LIKE + '%'"));

                        sbWhere.Append(UTIL.GetWhere(row, "@AS_EMP", "A.AS_EMP = @AS_EMP"));

                        string sQuery = "((ISNULL(A.APP_EMP1,APP.APP_EMP1) = @REG_EMP AND ISNULL(A.APP_EMP_FLAG1,'0') = '1' AND ISNULL(A.APP_EMP_FLAG2,'0') = '0' AND ISNULL(A.APP_EMP_FLAG3,'0') = '0' AND ISNULL(A.APP_EMP_FLAG4,'0') = '0' )";
                        sQuery += " OR (ISNULL(A.APP_EMP2,APP.APP_EMP2) = @REG_EMP AND ISNULL(A.APP_EMP_FLAG2,'0') = '1' AND ISNULL(A.APP_EMP_FLAG3,'0') = '0' AND ISNULL(A.APP_EMP_FLAG4,'0') = '0')";
                        sQuery += " OR (ISNULL(A.APP_EMP3,APP.APP_EMP3) = @REG_EMP AND ISNULL(A.APP_EMP_FLAG3,'0') = '1' AND ISNULL(A.APP_EMP_FLAG4,'0') = '0')";
                        sQuery += " OR (ISNULL(A.APP_EMP4,APP.APP_EMP4) = @REG_EMP AND ISNULL(A.APP_EMP_FLAG4,'0') = '1'))";

                        sbWhere.Append(UTIL.GetWhere(row, "@REG_EMP", sQuery));

                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "A.DATA_FLAG = @DATA_FLAG"));

                        sbWhere.Append(" ORDER BY A.AS_NO ");

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

        public static DataTable TORD_PRODUCT_AS_QUERY6(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {


                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("  SELECT  ");
                    sbQuery.Append("  A.PLT_CODE ");
                    sbQuery.Append(" ,A.AS_NO ");
                    sbQuery.Append(" ,A.AS_EMP ");
                    sbQuery.Append(" ,A.ACCEPT_DATE ");
                    sbQuery.Append(" ,A.REQ_DATE ");
                    sbQuery.Append(" ,A.PROD_NAME ");
                    sbQuery.Append(" ,A.AS_DATE ");
                    sbQuery.Append(" ,A.CUSTOMER_EMP ");
                    sbQuery.Append(" ,A.CVND_CODE ");
                    sbQuery.Append(" ,CVND.VEN_NAME AS CVND_NAME ");
                    sbQuery.Append(" ,A.AS_CHECK ");
                    sbQuery.Append(" ,A.AS_CONTENTS ");
                    sbQuery.Append(" ,A.PROD_CONTENTS ");
                    sbQuery.Append(" ,A.GUBUN_CHECK ");
                    sbQuery.Append(" ,A.CAUSE_CHECK ");
                    sbQuery.Append(" ,A.CAUSE_CONTENTS ");
                    sbQuery.Append(" ,A.WORK_CHECK ");
                    sbQuery.Append(" ,A.WORK_CONTENTS ");
                    sbQuery.Append(" ,A.RESULT_CHECK ");
                    sbQuery.Append(" ,A.RESULT_CONTENTS ");
                    sbQuery.Append(" ,A.CONFIRM_DATE ");
                    sbQuery.Append(" ,A.WORK_DATE ");
                    sbQuery.Append(" ,A.OCCUR_DATE ");
                    sbQuery.Append(" ,A.PLAN_CONTENTS ");
                    sbQuery.Append(" ,A.LAST_CHECK ");
                    sbQuery.Append(" ,A.LAST_CONTENTS ");
                    sbQuery.Append(" ,ISNULL(A.APP_EMP1,APP.APP_EMP1) AS APP_EMP1");
                    sbQuery.Append(" ,ISNULL(A.APP_EMP_FLAG1,'0') AS APP_EMP_FLAG1");

                    sbQuery.Append(" ,ISNULL(A.APP_EMP2,APP.APP_EMP2) AS APP_EMP2");
                    sbQuery.Append(" ,ISNULL(A.APP_EMP_FLAG2,'0') AS APP_EMP_FLAG2");

                    sbQuery.Append(" ,ISNULL(A.APP_EMP3,APP.APP_EMP3) AS APP_EMP3");
                    sbQuery.Append(" ,ISNULL(A.APP_EMP_FLAG3,'0') AS APP_EMP_FLAG3");

                    sbQuery.Append(" ,ISNULL(A.APP_EMP4,APP.APP_EMP4) AS APP_EMP4");
                    sbQuery.Append(" ,ISNULL(A.APP_EMP_FLAG4,'0') AS APP_EMP_FLAG4");
                    sbQuery.Append(" ,A.APP_ORG ");
                    sbQuery.Append(" ,A.REG_DATE ");
                    sbQuery.Append(" ,REG.EMP_NAME AS REG_EMP_NAME");
                    sbQuery.Append(" ,A.MDFY_DATE");
                    sbQuery.Append(" ,A.MDFY_EMP");
                    sbQuery.Append(" ,MDFY.EMP_NAME AS MDFY_EMP_NAME");
                    sbQuery.Append("  FROM TORD_PRODUCT_AS  A ");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE REG");
                    sbQuery.Append(" ON A.PLT_CODE = REG.PLT_CODE");
                    sbQuery.Append(" AND A.REG_EMP = REG.EMP_CODE");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE MDFY");
                    sbQuery.Append(" ON A.PLT_CODE = MDFY.PLT_CODE");
                    sbQuery.Append(" AND A.MDFY_EMP = MDFY.EMP_CODE");
                    sbQuery.Append(" LEFT JOIN TSTD_VENDOR CVND");
                    sbQuery.Append(" ON A.PLT_CODE = CVND.PLT_CODE");
                    sbQuery.Append(" AND A.CVND_CODE = CVND.VEN_CODE");
                    sbQuery.Append(" LEFT JOIN TSTD_APP_EMP APP ");
                    sbQuery.Append(" ON A.PLT_CODE = APP.PLT_CODE");
                    sbQuery.Append(" AND APP.APP_TYPE = 'AS' ");
                    sbQuery.Append(" AND A.APP_ORG = APP.ORG_CODE ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE A.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@AS_NO", "A.AS_NO = @AS_NO"));

                        sbWhere.Append(UTIL.GetWhere(row, "@S_ACCEPT_DATE, @E_ACCEPT_DATE", "A.ACCEPT_DATE BETWEEN @S_ACCEPT_DATE AND @E_ACCEPT_DATE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_AS_DATE, @E_AS_DATE", "(A.AS_DATE BETWEEN @S_AS_DATE AND @E_AS_DATE)"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_LIKE", "A.PROD_NAME LIKE '%' + @PROD_LIKE + '%'"));
                        sbWhere.Append(UTIL.GetWhere(row, "@CVND_LIKE", "A.CVND_CODE LIKE '%' + @CVND_LIKE + '%' OR CVND.VEN_NAME LIKE '%' + @CVND_LIKE + '%'"));

                        sbWhere.Append(UTIL.GetWhere(row, "@AS_EMP", "A.AS_EMP = @AS_EMP"));

                        string sQuery = "((ISNULL(A.APP_EMP1,APP.APP_EMP1) = @REG_EMP AND ISNULL(A.APP_EMP_FLAG1,'0') = '2' AND ISNULL(A.APP_EMP_FLAG2,'0') = '0' AND ISNULL(A.APP_EMP_FLAG3,'0') = '0' AND ISNULL(A.APP_EMP_FLAG4,'0') = '0' )";
                        sQuery += " OR (ISNULL(A.APP_EMP2,APP.APP_EMP2) = @REG_EMP AND ISNULL(A.APP_EMP_FLAG2,'0') = '2' AND ISNULL(A.APP_EMP_FLAG3,'0') = '0' AND ISNULL(A.APP_EMP_FLAG4,'0') = '0')";
                        sQuery += " OR (ISNULL(A.APP_EMP3,APP.APP_EMP3) = @REG_EMP AND ISNULL(A.APP_EMP_FLAG3,'0') = '2' AND ISNULL(A.APP_EMP_FLAG4,'0') = '0')";
                        sQuery += " OR (ISNULL(A.APP_EMP4,APP.APP_EMP4) = @REG_EMP AND ISNULL(A.APP_EMP_FLAG4,'0') = '2'))";

                        sbWhere.Append(UTIL.GetWhere(row, "@REG_EMP", sQuery));

                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "A.DATA_FLAG = @DATA_FLAG"));

                        sbWhere.Append(" ORDER BY A.AS_NO ");

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
