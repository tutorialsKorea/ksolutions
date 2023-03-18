using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace DSTD
{
    public class TSTD_EMPLOYEE
    {

        //로그인된 사용자 정보 조회
        public static DataTable TSTD_EMPLOYEE_SER(BizExecute.BizExecute bizExecute)
        {
            DataTable dtParam = new DataTable();
            dtParam.Columns.Add("PLT_CODE", typeof(String));
            dtParam.Columns.Add("EMP_CODE", typeof(String));

            DataRow row = dtParam.NewRow();
            row["PLT_CODE"] = ConnInfo.PLT_CODE;
            row["EMP_CODE"] = ConnInfo.UserID;

            dtParam.Rows.Add(row);

            return TSTD_EMPLOYEE_SER(dtParam, bizExecute);
        }

        public static DataTable TSTD_EMPLOYEE_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {

            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT PLT_CODE");
                    sbQuery.Append(" , EMP_CODE ");
                    sbQuery.Append(" , EMP_NAME ");
                    sbQuery.Append(" , EMP_TYPE ");
                    sbQuery.Append(" , EMP_TITLE");
                    sbQuery.Append(" , EMP_SEQ");
                    sbQuery.Append(" , ORG_CODE ");
                    sbQuery.Append(" , CPROC_CODE ");
                    sbQuery.Append(" , USRGRP_CODE");
                    sbQuery.Append(" , ACC_PWD");
                    sbQuery.Append(" , EMAIL");
                    sbQuery.Append(" , MOBILE_PHONE ");
                    sbQuery.Append(" , IS_SYSTEM");
                    sbQuery.Append(" , ISNULL(INS_DIRECTION,0) AS INS_DIRECTION");
                    sbQuery.Append(" , HIRE_DATE");
                    sbQuery.Append(" , RETIRE_DATE");
                    sbQuery.Append(" , IS_PROC");
                    sbQuery.Append(" , IS_CAM");
                    sbQuery.Append(" , IS_DAILY");
                    sbQuery.Append(" , EMP_REG_NUMBER");
                    sbQuery.Append(" , EMP_ADDRESS");
                    sbQuery.Append(" , WORK_LOC");
                    sbQuery.Append(" , PAY_CONTRACT");
                    sbQuery.Append(" , WORK_CONTRACT");
                    sbQuery.Append(" , EMP_NATIONAL");
                    sbQuery.Append(" , BIRTH_DATE");
                    sbQuery.Append(" , SCOMMENT");
                    sbQuery.Append(" , REG_DATE ");
                    sbQuery.Append(" , REG_EMP");
                    sbQuery.Append(" , MDFY_DATE");
                    sbQuery.Append(" , MDFY_EMP ");
                    sbQuery.Append(" , DEL_DATE ");
                    sbQuery.Append(" , DEL_EMP");
                    sbQuery.Append(" , DEL_REASON ");
                    sbQuery.Append(" , DATA_FLAG");
                    sbQuery.Append(" , ISNULL(IS_SAN_PUR, 0) AS IS_SAN_PUR");
                    sbQuery.Append(" , LEADER_EMP_CODE");
                    sbQuery.Append("  FROM TSTD_EMPLOYEE ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append(" AND EMP_CODE = @EMP_CODE");

                    foreach (DataRow row in dtParam.Rows)
                    {                        
                        bool isHasColumn = true;
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false; 
                        if (!UTIL.ValidColumn(row, "EMP_CODE")) isHasColumn = false;                        

                        if (isHasColumn == true)
                        {                                                       
                            DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString(),row).Copy();

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

        //로그인시 
        public static DataTable TSTD_EMPLOYEE_SER2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT E.PLT_CODE ");
                    sbQuery.Append(", E.EMP_CODE ");
                    sbQuery.Append(", E.EMP_NAME ");
                    sbQuery.Append(", E.EMP_TYPE ");
                    sbQuery.Append(", E.EMP_TITLE");
                    sbQuery.Append(", E.EMP_SEQ");
                    sbQuery.Append(", E.ORG_CODE ");
                    sbQuery.Append(", E.INS_DIRECTION");
                    sbQuery.Append(", O.ORG_NAME ");
                    sbQuery.Append(", E.CPROC_CODE ");
                    sbQuery.Append(", E.USRGRP_CODE");
                    sbQuery.Append(", UG.USRGRP_NAME ");
                    sbQuery.Append(", E.MOBILE_PHONE ");
                    sbQuery.Append(", E.EMAIL");
                    sbQuery.Append(", E.IS_SYSTEM");
                    sbQuery.Append(", E.HIRE_DATE");
                    sbQuery.Append(", E.RETIRE_DATE");
                    sbQuery.Append(", E.BIRTH_DATE");
                    sbQuery.Append(", E.IS_CAM");
                    sbQuery.Append(" ,E.IS_DAILY");
                    sbQuery.Append(", E.IS_PROC");
                    sbQuery.Append(", E.EMP_REG_NUMBER");
                    sbQuery.Append(", E.EMP_ADDRESS");
                    sbQuery.Append(", E.WORK_LOC");
                    sbQuery.Append(", E.PAY_CONTRACT");
                    sbQuery.Append(", E.WORK_CONTRACT");
                    sbQuery.Append(", E.EMP_NATIONAL");
                    sbQuery.Append(", E.SCOMMENT");
                    sbQuery.Append(" FROM TSTD_EMPLOYEE E");
                    sbQuery.Append(" LEFT JOIN TSTD_ORG O");
                    sbQuery.Append(" ON E.PLT_CODE = O.PLT_CODE");
                    sbQuery.Append(" AND E.ORG_CODE = O.ORG_CODE ");
                    sbQuery.Append(" LEFT JOIN TSYS_USERGRP UG ");
                    sbQuery.Append(" ON E.PLT_CODE = UG.PLT_CODE ");
                    sbQuery.Append(" AND E.USRGRP_CODE= UG.USRGRP_CODE ");
                    sbQuery.Append(" WHERE E.PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND E.EMP_CODE = @EMP_CODE ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false; 
                        if (!UTIL.ValidColumn(row, "EMP_CODE")) isHasColumn = false;

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

        /// <summary>
        /// LOG_IN시 ID / 비밀번호 체크
        /// </summary>
        /// <param name="dtParam"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataTable TSTD_EMPLOYEE_SER3(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT E.PLT_CODE ");
                    sbQuery.Append(", E.EMP_CODE ");
                    sbQuery.Append(", E.EMP_NAME ");
                    sbQuery.Append(", E.EMP_TYPE ");
                    sbQuery.Append(", E.EMP_TITLE");
                    sbQuery.Append(", E.EMP_SEQ");
                    sbQuery.Append(", E.ORG_CODE ");
                    sbQuery.Append(", E.INS_DIRECTION");
                    sbQuery.Append(", O.ORG_NAME ");
                    sbQuery.Append(", E.CPROC_CODE ");
                    sbQuery.Append(", E.USRGRP_CODE");
                    sbQuery.Append(", UG.USRGRP_NAME ");
                    sbQuery.Append(", E.MOBILE_PHONE ");
                    sbQuery.Append(", E.EMAIL");
                    sbQuery.Append(", E.IS_SYSTEM");
                    sbQuery.Append(", E.IS_CAM");
                    sbQuery.Append(" ,E.IS_DAILY");
                    sbQuery.Append(", E.IS_PROC");
                    sbQuery.Append(", E.EMP_REG_NUMBER");
                    sbQuery.Append(", E.EMP_ADDRESS");
                    sbQuery.Append(", E.WORK_LOC");
                    sbQuery.Append(", E.PAY_CONTRACT");
                    sbQuery.Append(", E.WORK_CONTRACT");
                    sbQuery.Append(", E.EMP_NATIONAL");
                    sbQuery.Append(" , ISNULL(E.PWD_CHANGED_DT,GETDATE()) AS PWD_CHANGED_DT ");
                    sbQuery.Append(" , E.PWD_FAILED_CNT");
                    sbQuery.Append(" , E.ACC_PWD");
                    sbQuery.Append(" , GETDATE() AS SERVER_TIME ");
                    sbQuery.Append(" , (SELECT TOP 1 CONF_VALUE FROM TSYS_CONF WHERE PLT_CODE = E.PLT_CODE AND CONF_NAME = 'PWD_POLICY_USE') AS PWD_POLICY_USE");
                    sbQuery.Append(" , (SELECT TOP 1 CONF_VALUE FROM TSYS_CONF WHERE PLT_CODE = E.PLT_CODE AND CONF_NAME = 'PWD_FAIL_LIMITED_CNT') AS PWD_FAIL_LIMITED_CNT");
                    sbQuery.Append(" , (SELECT TOP 1 CONF_VALUE FROM TSYS_CONF WHERE PLT_CODE = E.PLT_CODE AND CONF_NAME = 'PWD_CHANGE_PERIOD') AS PWD_CHANGE_PERIOD");
                    sbQuery.Append(" , (SELECT TOP 1 CONF_VALUE FROM TSYS_CONF WHERE PLT_CODE = E.PLT_CODE AND CONF_NAME = 'PWD_CHANGE_REMAIN_DAY') AS PWD_CHANGE_REMAIN_DAY");
                    sbQuery.Append(" FROM TSTD_EMPLOYEE E");
                    sbQuery.Append(" LEFT JOIN TSTD_ORG O");
                    sbQuery.Append(" ON E.PLT_CODE = O.PLT_CODE");
                    sbQuery.Append(" AND E.ORG_CODE = O.ORG_CODE ");
                    sbQuery.Append(" LEFT JOIN TSYS_USERGRP UG ");
                    sbQuery.Append(" ON E.PLT_CODE = UG.PLT_CODE ");
                    sbQuery.Append(" AND E.USRGRP_CODE= UG.USRGRP_CODE ");
                    

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "EMP_CODE")) isHasColumn = false;

                        if (isHasColumn == true)
                        {
                            StringBuilder sbWhere = new StringBuilder();
                            sbWhere.Append(" WHERE E.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                            sbWhere.Append(UTIL.GetWhere(row, "@EMP_CODE", "E.EMP_CODE = @EMP_CODE "));
                            //sbWhere.Append(UTIL.GetWhere(row, "@ACC_PWD", "E.ACC_PWD = @ACC_PWD "));
                            sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG",  "E.DATA_FLAG = @DATA_FLAG"));
                                
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

        public static DataTable TSTD_EMPLOYEE_SER4(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {

            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT PLT_CODE");
                    sbQuery.Append(" , EMP_CODE ");
                    sbQuery.Append(" , SIGN_IMG ");
                    sbQuery.Append("  FROM TSTD_EMPLOYEE ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append(" AND EMP_CODE = @EMP_CODE");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "EMP_CODE")) isHasColumn = false;

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




        // 업무일지를 작성했거나 실적이 존재하는 직원 조회
        public static DataTable TSTD_EMPLOYEE_SER5(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT E.PLT_CODE ");
                    sbQuery.Append(", E.EMP_CODE ");
                    sbQuery.Append(", E.EMP_NAME ");
                    sbQuery.Append(", E.EMP_TYPE ");
                    sbQuery.Append(", E.EMP_TITLE");
                    sbQuery.Append(", E.EMP_SEQ");
                    sbQuery.Append(", E.ORG_CODE ");
                    sbQuery.Append(", E.INS_DIRECTION");
                    sbQuery.Append(", O.ORG_NAME ");
                    sbQuery.Append(", E.CPROC_CODE ");
                    sbQuery.Append(", E.USRGRP_CODE");
                    sbQuery.Append(", UG.USRGRP_NAME ");
                    sbQuery.Append(", E.MOBILE_PHONE ");
                    sbQuery.Append(", E.EMAIL");
                    sbQuery.Append(", E.IS_SYSTEM");
                    sbQuery.Append(", E.HIRE_DATE");
                    sbQuery.Append(", E.RETIRE_DATE");
                    sbQuery.Append(", E.BIRTH_DATE");
                    sbQuery.Append(", E.IS_CAM");
                    sbQuery.Append(", O.IS_DEV");
                    sbQuery.Append(" ,E.IS_DAILY");
                    sbQuery.Append(", E.IS_PROC");
                    sbQuery.Append(", E.EMP_REG_NUMBER");
                    sbQuery.Append(", E.EMP_ADDRESS");
                    sbQuery.Append(", E.WORK_LOC");
                    sbQuery.Append(", E.PAY_CONTRACT");
                    sbQuery.Append(", E.WORK_CONTRACT");
                    sbQuery.Append(", E.EMP_NATIONAL");
                    sbQuery.Append(", E.SCOMMENT");
                    sbQuery.Append(" FROM TSTD_EMPLOYEE E");
                    //sbQuery.Append(" INNER JOIN (SELECT PLT_CODE, EMP_CODE FROM TSHP_ACTUAL GROUP BY PLT_CODE,EMP_CODE  " +
                    //                             "UNION " +
                    //                            "SELECT PLT_CODE, REG_EMP FROM TSYS_DAILY_LOG GROUP BY PLT_CODE, REG_EMP) TMP  ");
                    //sbQuery.Append(" ON E.PLT_CODE = TMP.PLT_CODE");
                    //sbQuery.Append(" AND E.EMP_CODE = TMP.EMP_CODE ");
                    sbQuery.Append(" LEFT JOIN TSTD_ORG O");
                    sbQuery.Append(" ON E.PLT_CODE = O.PLT_CODE");
                    sbQuery.Append(" AND E.ORG_CODE = O.ORG_CODE ");
                    sbQuery.Append(" LEFT JOIN TSYS_USERGRP UG ");
                    sbQuery.Append(" ON E.PLT_CODE = UG.PLT_CODE ");
                    sbQuery.Append(" AND E.USRGRP_CODE= UG.USRGRP_CODE ");
                    sbQuery.Append(" WHERE E.PLT_CODE = @PLT_CODE");
               

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;

                        if (dtParam.Columns.Contains("ORG_CODE"))
                        {
                            if (row["ORG_CODE"].toStringEmpty() != "")
                            {
                                sbQuery.Append(" AND ((E.ORG_CODE = @ORG_CODE OR O.ORG_PARENT = @ORG_CODE) AND E.DATA_FLAG = '0' )");
                            }
                        }

                        sbQuery.Append(UTIL.GetWhere(row, "@IS_RETIRE", "ISNULL(E.EMP_TYPE, '0') <> '5'"));

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

        public static DataTable TSTD_EMPLOYEE_SER6(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {

            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT PLT_CODE");
                    sbQuery.Append(" , EMP_CODE ");
                    sbQuery.Append(" , EMP_NAME ");
                    sbQuery.Append("  FROM TSTD_EMPLOYEE ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append(" AND EMP_NAME = @EMP_NAME");
                    sbQuery.Append(" AND DATA_FLAG = '0'");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "EMP_NAME")) isHasColumn = false;

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

        public static DataTable TSTD_EMPLOYEE_SER7(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {

            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT PLT_CODE");
                    sbQuery.Append(" , EMP_CODE ");
                    sbQuery.Append(" , EMP_NAME ");
                    sbQuery.Append("  FROM TSTD_EMPLOYEE ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append(" AND IS_MODIFY_EMP = 1");
                    sbQuery.Append(" AND DATA_FLAG = '0'");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;

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


        public static void TSTD_EMPLOYEE_UPD(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" UPDATE TSTD_EMPLOYEE");
                    sbQuery.Append(" SET EMP_NAME = @EMP_NAME");
                    sbQuery.Append(" , EMP_TYPE = @EMP_TYPE");
                    sbQuery.Append(" , EMP_TITLE = @EMP_TITLE");
                    sbQuery.Append(" , EMP_SEQ = @EMP_SEQ");
                    sbQuery.Append(" , ORG_CODE = @ORG_CODE");
                    sbQuery.Append(" , CPROC_CODE = @CPROC_CODE");
                    sbQuery.Append(" , USRGRP_CODE = @USRGRP_CODE");
                    sbQuery.Append(" , EMAIL = @EMAIL");
                    sbQuery.Append(" , MOBILE_PHONE = @MOBILE_PHONE");
                    sbQuery.Append(" , IF_EMP_CODE = @IF_EMP_CODE");
                    sbQuery.Append(" , IS_VND = @IS_VND");
                    sbQuery.Append(" , EMP_VND = @EMP_VND");

                    sbQuery.Append(" , HIRE_DATE = @HIRE_DATE");
                    sbQuery.Append(" , RETIRE_DATE = @RETIRE_DATE");
                    sbQuery.Append(" , BIRTH_DATE = @BIRTH_DATE");
                    sbQuery.Append(" , IS_PROC = @IS_PROC");
                    sbQuery.Append(" , IS_CAM = @IS_CAM");
                    sbQuery.Append(" , IS_DAILY = @IS_DAILY");
                    sbQuery.Append(" , SIGN_IMG = @SIGN_IMG");
                    sbQuery.Append(" , SCOMMENT = @SCOMMENT");

                    sbQuery.Append(" , EMP_REG_NUMBER = @EMP_REG_NUMBER");
                    sbQuery.Append(" , EMP_ADDRESS = @EMP_ADDRESS");

                    sbQuery.Append(", WORK_LOC = @WORK_LOC");
                    sbQuery.Append(", PAY_CONTRACT = @PAY_CONTRACT");
                    sbQuery.Append(", WORK_CONTRACT = @WORK_CONTRACT");
                    sbQuery.Append(", EMP_NATIONAL = @EMP_NATIONAL");

                    sbQuery.Append(", LEADER_EMP_CODE = @LEADER_EMP_CODE");

                    sbQuery.Append(" , MDFY_DATE = GETDATE()");
                    sbQuery.Append(" , MDFY_EMP = "+ UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" , DATA_FLAG = 0");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND EMP_CODE = @EMP_CODE");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false; 
                        if (!UTIL.ValidColumn(row, "EMP_CODE")) isHasColumn = false;                        

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

        public static void TSTD_EMPLOYEE_UPD2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" UPDATE TSTD_EMPLOYEE");
                    sbQuery.Append(" SET USRGRP_CODE = @USRGRP_CODE");
                    sbQuery.Append(" ,MDFY_DATE = @MDFY_DATE");
                    sbQuery.Append(" ,MDFY_EMP = @MDFY_EMP");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND EMP_CODE = @EMP_CODE");
   
                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false; 
                        if (!UTIL.ValidColumn(row, "EMP_CODE")) isHasColumn = false;

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
        /// 비밀번호 변경
        /// </summary>
        /// <param name="dtParam"></param>
        /// <param name="bizExecute"></param>
        public static void TSTD_EMPLOYEE_UPD3(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append("UPDATE TSTD_EMPLOYEE ");
                    sbQuery.Append("   SET   ACC_PWD = @NEW_PASSWORD ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("   AND EMP_CODE = @EMP_CODE");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "EMP_CODE")) isHasColumn = false;

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
        /// 자주검사 자동 이동 방향 설정
        /// </summary>
        /// <param name="dtParam"></param>
        /// <param name="bizExecute"></param>
        public static void TSTD_EMPLOYEE_UPD4(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append("UPDATE TSTD_EMPLOYEE ");
                    sbQuery.Append("   SET INS_DIRECTION = @INS_DIRECTION ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("   AND EMP_CODE = @EMP_CODE");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "EMP_CODE")) isHasColumn = false;

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

        public static void TSTD_EMPLOYEE_UPD5(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append("UPDATE TSTD_EMPLOYEE ");
                    sbQuery.Append("   SET EMP_TITLE = @EMP_TITLE ");
                    sbQuery.Append(" , HIRE_DATE = @HIRE_DATE");
                    sbQuery.Append(" , EMP_REG_NUMBER = @EMP_REG_NUMBER");
                    sbQuery.Append(" , EMP_ADDRESS = @EMP_ADDRESS");
                    sbQuery.Append(" , MDFY_DATE = GETDATE()");
                    sbQuery.Append(" , MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" , DATA_FLAG = @DATA_FLAG");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("   AND EMP_CODE = @EMP_CODE");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "EMP_CODE")) isHasColumn = false;

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
        /// 비밀번호 실패
        /// </summary>
        /// <param name="dtParam"></param>
        /// <param name="bizExecute"></param>
        public static void TSTD_EMPLOYEE_UPD6(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append("UPDATE TSTD_EMPLOYEE ");
                    sbQuery.Append("   SET   PWD_FAILED_CNT = ISNULL(PWD_FAILED_CNT,0) + 1 ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("   AND EMP_CODE = @EMP_CODE");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "EMP_CODE")) isHasColumn = false;

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

        //비밀번호 실패 초기화
        public static void TSTD_EMPLOYEE_UPD7(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" UPDATE TSTD_EMPLOYEE");
                    sbQuery.Append("   SET   PWD_FAILED_CNT = 0");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND EMP_CODE = @EMP_CODE");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "EMP_CODE")) isHasColumn = false;

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

        public static void TSTD_EMPLOYEE_UDE(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {

                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append("UPDATE TSTD_EMPLOYEE SET");
                    sbQuery.Append("  DEL_DATE = GETDATE()");
                    sbQuery.Append(" , DEL_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" , DATA_FLAG = 2");

                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND EMP_CODE = @EMP_CODE");                    

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "EMP_CODE")) isHasColumn = false;                        

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


        public static void TSTD_EMPLOYEE_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" INSERT INTO TSTD_EMPLOYEE");
                    sbQuery.Append(" (");
                    sbQuery.Append(" PLT_CODE ");
                    sbQuery.Append(" , EMP_CODE ");
                    sbQuery.Append(" , EMP_NAME ");
                    sbQuery.Append(" , EMP_TYPE ");
                    sbQuery.Append(" , EMP_TITLE");
                    sbQuery.Append(" , EMP_SEQ");
                    sbQuery.Append(" , ORG_CODE ");
                    sbQuery.Append(" , CPROC_CODE ");
                    sbQuery.Append(" , USRGRP_CODE");
                    sbQuery.Append(" , ACC_PWD");
                    sbQuery.Append(" , EMAIL");
                    sbQuery.Append(" , MOBILE_PHONE ");
                    sbQuery.Append(" , IS_SYSTEM");
                    sbQuery.Append(" , IF_EMP_CODE");
                    sbQuery.Append(" , IS_VND ");
                    sbQuery.Append(" , EMP_VND");
                    sbQuery.Append(" , HIRE_DATE");
                    sbQuery.Append(" , RETIRE_DATE");
                    sbQuery.Append(" , BIRTH_DATE");
                    sbQuery.Append(" , IS_PROC");
                    sbQuery.Append(" , SIGN_IMG");
                    sbQuery.Append(" , EMP_REG_NUMBER");
                    sbQuery.Append(" , EMP_ADDRESS");
                    sbQuery.Append(" , WORK_LOC");
                    sbQuery.Append(" , PAY_CONTRACT");
                    sbQuery.Append(" , WORK_CONTRACT");
                    sbQuery.Append(" , EMP_NATIONAL");
                    sbQuery.Append(" , IS_CAM");
                    sbQuery.Append(" , IS_DAILY"); 
                    sbQuery.Append(" , SCOMMENT");
                    sbQuery.Append(" , LEADER_EMP_CODE"); 
                    sbQuery.Append(" , REG_DATE ");
                    sbQuery.Append(" , REG_EMP");
                    sbQuery.Append(" , DATA_FLAG");
                    sbQuery.Append(" )");
                    sbQuery.Append(" VALUES ");
                    sbQuery.Append(" (");
                    sbQuery.Append(" @PLT_CODE");
                    sbQuery.Append(" , @EMP_CODE");
                    sbQuery.Append(" , @EMP_NAME");
                    sbQuery.Append(" , @EMP_TYPE");
                    sbQuery.Append(" , @EMP_TITLE ");
                    sbQuery.Append(" , @EMP_SEQ ");
                    sbQuery.Append(" , @ORG_CODE");
                    sbQuery.Append(" , @CPROC_CODE");
                    sbQuery.Append(" , @USRGRP_CODE ");
                    sbQuery.Append(" , @ACC_PWD ");
                    sbQuery.Append(" , @EMAIL ");
                    sbQuery.Append(" , @MOBILE_PHONE");
                    sbQuery.Append(" , @IS_SYSTEM ");
                    sbQuery.Append(" , @IF_EMP_CODE ");
                    sbQuery.Append(" , @IS_VND");
                    sbQuery.Append(" , @EMP_VND ");
                    sbQuery.Append(" , @HIRE_DATE");
                    sbQuery.Append(" , @RETIRE_DATE");
                    sbQuery.Append(" , @BIRTH_DATE");
                    sbQuery.Append(" , @IS_PROC");
                    sbQuery.Append(" , @SIGN_IMG");
                    sbQuery.Append(" , @EMP_REG_NUMBER");
                    sbQuery.Append(" , @EMP_ADDRESS");
                    sbQuery.Append(" , @WORK_LOC");
                    sbQuery.Append(" , @PAY_CONTRACT");
                    sbQuery.Append(" , @WORK_CONTRACT");
                    sbQuery.Append(" , @EMP_NATIONAL");
                    sbQuery.Append(" , @IS_CAM");
                    sbQuery.Append(" , @IS_DAILY");
                    sbQuery.Append(" , @SCOMMENT");
                    sbQuery.Append(" , @LEADER_EMP_CODE");
                    sbQuery.Append(" , GETDATE()");
                    sbQuery.Append(" , " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" , 0 ");
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

    public class TSTD_EMPLOYEE_QUERY
    {
        //기준정보
        public static DataTable TSTD_EMPLOYEE_QUERY1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT E.PLT_CODE");
                    sbQuery.Append(" ,E.EMP_CODE");
                    sbQuery.Append(" ,E.EMP_NAME");
                    sbQuery.Append(" ,E.EMP_TYPE");
                    sbQuery.Append(" ,E.EMP_TITLE ");
                    sbQuery.Append(" ,E.EMP_SEQ ");
                    sbQuery.Append(" ,E.ORG_CODE");
                    sbQuery.Append(" ,E.CPROC_CODE");
                    sbQuery.Append(" ,E.USRGRP_CODE ");
                    sbQuery.Append(" ,E.MOBILE_PHONE");
                    sbQuery.Append(" ,E.EMAIL ");
                    sbQuery.Append(" ,E.ACC_PWD ");
                    sbQuery.Append(" ,E.IS_SYSTEM ");
                    sbQuery.Append(" ,E.REG_DATE");
                    sbQuery.Append(" ,E.REG_EMP ");
                    sbQuery.Append(" ,E.MDFY_DATE ");
                    sbQuery.Append(" ,E.MDFY_EMP");
                    sbQuery.Append(" ,E.DATA_FLAG ");
                    sbQuery.Append(" ,E.DEL_DATE");
                    sbQuery.Append(" ,E.DEL_EMP ");
                    sbQuery.Append(" ,O.ORG_NAME");
                    sbQuery.Append(" ,E.IS_VND");
                    sbQuery.Append(" ,E.HIRE_DATE");
                    sbQuery.Append(" ,E.IS_PROC");
                    sbQuery.Append(" ,E.IS_CAM");
                    sbQuery.Append(" ,E.IS_DAILY");
                    sbQuery.Append(" ,E.SCOMMENT");
                    sbQuery.Append(" ,E.RETIRE_DATE");
                    sbQuery.Append(" ,E.BIRTH_DATE");
                    sbQuery.Append(" ,E.EMP_REG_NUMBER");
                    sbQuery.Append(" ,E.EMP_ADDRESS");
                    sbQuery.Append(", E.WORK_LOC");
                    sbQuery.Append(", E.PAY_CONTRACT");
                    sbQuery.Append(", E.WORK_CONTRACT");
                    sbQuery.Append(", E.EMP_NATIONAL");
                    sbQuery.Append(" ,G.USRGRP_NAME ");
                    sbQuery.Append(" ,O.IS_DEV ");
                    sbQuery.Append(" ,E.LEADER_EMP_CODE ");
                    sbQuery.Append(" ,LE.EMP_NAME AS LEADER_EMP_NAME ");
                    sbQuery.Append(" FROM TSTD_EMPLOYEE E LEFT JOIN TSTD_ORG O");
                    sbQuery.Append(" ON E.PLT_CODE = O.PLT_CODE ");
                    sbQuery.Append(" AND E.ORG_CODE = O.ORG_CODE");
                    sbQuery.Append(" LEFT JOIN TSYS_USERGRP G ");
                    sbQuery.Append(" ON E.PLT_CODE = G.PLT_CODE ");
                    sbQuery.Append(" AND E.USRGRP_CODE = G.USRGRP_CODE");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE LE ");
                    sbQuery.Append(" ON E.PLT_CODE = LE.PLT_CODE ");
                    sbQuery.Append(" AND E.LEADER_EMP_CODE = LE.EMP_CODE");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder();

                        sbWhere.Append(" WHERE E.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@EMP_CODE", "E.EMP_CODE = @EMP_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@EMP_NAME", "E.EMP_NAME = @EMP_NAME"));
                        sbWhere.Append(UTIL.GetWhere(row, "@ORG_CODE", "E.ORG_CODE = @ORG_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@USRGRP_CODE", "E.USRGRP_CODE = @USRGRP_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@ACC_PWD", "E.ACC_PWD = @ACC_PWD"));
                        sbWhere.Append(UTIL.GetWhere(row, "@AVAILMC", "E.EMP_CODE IN (SELECT EMP_CODE FROM TSTD_MC_AVAILEMP WHERE MC_CODE = @AVAILMC)"));
                        sbWhere.Append(UTIL.GetWhere(row, "@EMP_LIKE", "(E.EMP_CODE LIKE '%' + @EMP_LIKE + '%' OR E.EMP_NAME LIKE '%' + @EMP_LIKE + '%')"));
                        sbWhere.Append(UTIL.GetWhere(row, "@EMP_TYPE", "E.EMP_TYPE = @EMP_TYPE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "E.DATA_FLAG = @DATA_FLAG"));                                                
                        sbWhere.Append(" ORDER BY E.EMP_SEQ ");

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

        

        //acEmpForm 조회 가용설비 있을경우
        public static DataTable TSTD_EMPLOYEE_QUERY5(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbQuery = new StringBuilder();
                        sbQuery.Append(" SELECT ");
                        sbQuery.Append(" E.PLT_CODE ");
                        sbQuery.Append(" ,E.EMP_CODE");
                        sbQuery.Append(" ,E.EMP_NAME");
                        sbQuery.Append(" ,E.EMP_TYPE");
                        sbQuery.Append(" ,E.EMP_TITLE ");
                        sbQuery.Append(" ,E.EMP_SEQ ");
                        sbQuery.Append(" ,E.ORG_CODE");
                        sbQuery.Append(" ,O.ORG_NAME");
                        sbQuery.Append(" ,O.ORG_SEQ ");
                        sbQuery.Append(" ,E.CPROC_CODE");
                        sbQuery.Append(" ,E.USRGRP_CODE ");
                        sbQuery.Append(" ,CM.UTC_NAME AS CPROC_NAME ");
                        sbQuery.Append(" ,G.USRGRP_NAME ");
                        sbQuery.Append(" ,E.MOBILE_PHONE");
                        sbQuery.Append(" ,E.EMAIL ");
                        sbQuery.Append(" ,E.REG_DATE");
                        sbQuery.Append(" ,E.REG_EMP ");
                        sbQuery.Append(" ,REG.EMP_NAME AS REG_EMP_NAME");
                        sbQuery.Append(" ,E.MDFY_DATE ");
                        sbQuery.Append(" ,E.MDFY_EMP");
                        sbQuery.Append(" ,MDFY.EMP_NAME AS MDFY_EMP_NAME");
                        sbQuery.Append(" ,E.IS_VND");
                        sbQuery.Append(" ,E.EMP_VND ");
                        sbQuery.Append(" ,E.IF_EMP_CODE ");
                        sbQuery.Append(" ,CASE WHEN (SELECT MAIN_EMP FROM LSE_MACHINE WHERE PLT_CODE = E.PLT_CODE AND MAIN_EMP = E.EMP_CODE AND MC_CODE = '" + row["AVAILMC"] + "') IS NULL THEN '' ");
                        sbQuery.Append(" ELSE '1' ");
                        sbQuery.Append(" END AS IS_MAIN_EMP ");
                        sbQuery.Append("");
                        sbQuery.Append(" ,E.HIRE_DATE ");
                        sbQuery.Append(" ,E.RETIRE_DATE ");
                        sbQuery.Append(" ,E.BIRTH_DATE ");
                        sbQuery.Append(" ,E.EMP_REG_NUMBER ");
                        sbQuery.Append(" ,E.EMP_ADDRESS ");
                        sbQuery.Append(", E.WORK_LOC");
                        sbQuery.Append(", E.PAY_CONTRACT");
                        sbQuery.Append(", E.WORK_CONTRACT");
                        sbQuery.Append(", E.EMP_NATIONAL");
                        sbQuery.Append(", E.SCOMMENT");
                        sbQuery.Append(" FROM TSTD_EMPLOYEE E ");
                        sbQuery.Append(" LEFT JOIN TSTD_ORG O ");
                        sbQuery.Append(" ON E.PLT_CODE = O.PLT_CODE ");
                        sbQuery.Append(" AND E.ORG_CODE = O.ORG_CODE");
                        sbQuery.Append(" LEFT JOIN TSYS_USERGRP G");
                        sbQuery.Append(" ON E.PLT_CODE = G.PLT_CODE ");
                        sbQuery.Append(" AND E.USRGRP_CODE = G.USRGRP_CODE");
                        sbQuery.Append(" LEFT JOIN TCST_UNIT_COST_MASTER CM ");
                        sbQuery.Append(" ON E.PLT_CODE = CM.PLT_CODE");
                        sbQuery.Append(" AND E.CPROC_CODE = CM.UTC_CODE ");
                        sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE REG");
                        sbQuery.Append(" ON E.PLT_CODE = REG.PLT_CODE ");
                        sbQuery.Append(" AND E.REG_EMP = REG.EMP_CODE ");
                        sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE MDFY ");
                        sbQuery.Append(" ON E.PLT_CODE = MDFY.PLT_CODE");
                        sbQuery.Append(" AND E.MDFY_EMP = MDFY.EMP_CODE "); 

                        StringBuilder sbWhere = new StringBuilder();

                        sbWhere.Append(" WHERE E.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@EMP_CODE", "E.EMP_CODE = @EMP_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@EMP_NAME", "E.EMP_NAME = @EMP_NAME"));
                        sbWhere.Append(UTIL.GetWhere(row, "@ORG_CODE", "E.ORG_CODE = @ORG_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@AVAILMC", "E.EMP_CODE IN (SELECT EMP_CODE FROM TSTD_MC_AVAILEMP WHERE MC_CODE = @AVAILMC)"));
                        sbWhere.Append(UTIL.GetWhere(row, "@EMP_LIKE", "(E.EMP_CODE LIKE '%' + @EMP_LIKE + '%' OR E.EMP_NAME LIKE '%' + @EMP_LIKE + '%')"));
                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "E.DATA_FLAG = @DATA_FLAG"));
                        sbWhere.Append(UTIL.GetWhere(row, "@IS_SYSTEM", "E.IS_SYSTEM = @IS_SYSTEM"));
                        sbWhere.Append(UTIL.GetWhere(row, "@IS_ORG", "E.ORG_CODE IS NOT NULL"));
                        sbWhere.Append(UTIL.GetWhere(row, "@IS_PROC", "E.IS_PROC = @IS_PROC"));
                        sbWhere.Append(" ORDER BY E.EMP_SEQ ");

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


        //acEmpForm 조회 가용설비 없을경우
        public static DataTable TSTD_EMPLOYEE_QUERY6(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {

                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append("SELECT E.PLT_CODE");
                    sbQuery.Append(" ,E.EMP_CODE");
                    sbQuery.Append(" ,E.EMP_NAME");
                    sbQuery.Append(" ,E.EMP_TYPE");
                    sbQuery.Append(" ,E.EMP_TITLE ");
                    sbQuery.Append(" ,E.EMP_SEQ ");
                    sbQuery.Append(" ,E.ORG_CODE");
                    sbQuery.Append(" ,ORG_NAME = O.ORG_NAME");
                    sbQuery.Append(" ,E.CPROC_CODE");
                    sbQuery.Append(" ,E.USRGRP_CODE ");
                    sbQuery.Append("	,CPROC_NAME = CM.UTC_NAME ");
                    sbQuery.Append(" ,USRGRP_NAME = G.USRGRP_NAME");
                    sbQuery.Append(" ,E.MOBILE_PHONE");
                    sbQuery.Append(" ,E.EMAIL ");
                    sbQuery.Append(" ,E.ACC_PWD ");
                    //sb.Append(" --,E.INITIAL ");
                    //sb.Append(" --,E.MY_ITEM_ACCRUE_CNT");
                    sbQuery.Append(" ,E.REG_DATE");
                    sbQuery.Append(" ,E.REG_EMP ");
                    sbQuery.Append(" ,E.MDFY_DATE ");
                    sbQuery.Append(" ,E.MDFY_EMP");
                    sbQuery.Append(" ,E.DATA_FLAG ");
                    sbQuery.Append(" ,E.DEL_DATE");
                    sbQuery.Append(" ,E.DEL_EMP ");
                    sbQuery.Append(" ,'' AS IS_MAIN_EMP ");
                    sbQuery.Append(" ,E.HIRE_DATE ");
                    sbQuery.Append(" ,E.RETIRE_DATE ");
                    sbQuery.Append(" ,E.EMP_REG_NUMBER ");
                    sbQuery.Append(" ,E.EMP_ADDRESS ");
                    sbQuery.Append(", E.WORK_LOC");
                    sbQuery.Append(", E.PAY_CONTRACT");
                    sbQuery.Append(", E.WORK_CONTRACT");
                    sbQuery.Append(", E.EMP_NATIONAL");
                    sbQuery.Append(" FROM TSTD_EMPLOYEE E ");
                    sbQuery.Append(" LEFT JOIN TSTD_ORG O ON E.PLT_CODE = O.PLT_CODE AND E.ORG_CODE = O.ORG_CODE");
                    sbQuery.Append(" LEFT JOIN TSYS_USERGRP G ON E.PLT_CODE = G.PLT_CODE AND E.USRGRP_CODE = G.USRGRP_CODE ");
                    sbQuery.Append(" LEFT JOIN TCST_UNIT_COST_MASTER CM ON E.PLT_CODE = CM.PLT_CODE AND E.CPROC_CODE = CM.UTC_CODE ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        StringBuilder sbWhere = new StringBuilder();

                        sbWhere.Append(" WHERE E.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        if (!dtParam.Columns.Contains("IS_RETIRE"))
                        {
                            sbWhere.Append(" AND E.RETIRE_DATE IS NULL ");
                        }

                        sbWhere.Append(UTIL.GetWhere(row, "@EMP_CODE", "E.EMP_CODE = @EMP_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@ORG_CODE", "E.ORG_CODE = @ORG_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@EMP_TYPE", "E.EMP_TYPE = @EMP_TYPE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@EMP_TYPE", "E.EMP_TYPE = @EMP_TYPE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@AVAILMC", "E.EMP_CODE IN (SELECT EMP_CODE FROM TSTD_MC_AVAILEMP WHERE MC_CODE = @AVAILMC)"));
                        sbWhere.Append(UTIL.GetWhere(row, "@EMP_LIKE", "(E.EMP_CODE LIKE '%' + @EMP_LIKE + '%' OR E.EMP_NAME LIKE '%' + @EMP_LIKE + '%')"));
                        sbWhere.Append(UTIL.GetWhere(row, "@IS_PROC", "E.IS_PROC = @IS_PROC"));
                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "E.DATA_FLAG = @DATA_FLAG"));
                        sbWhere.Append(UTIL.GetWhere(row, "@IS_DEV", "O.IS_DEV = @IS_DEV"));
                        sbWhere.Append(UTIL.GetWhere(row, "@WORK_LOC", "E.WORK_LOC = @WORK_LOC"));
                        sbWhere.Append(UTIL.GetWhere(row, "@IS_CAM", "E.IS_CAM = @IS_CAM"));
                        sbWhere.Append(UTIL.GetWhere(row, "@IS_RETIRE", "ISNULL(E.EMP_TYPE, '0') <> '5'"));

                        sbWhere.Append(" ORDER BY E.EMP_NAME ");

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

        public static DataTable TSTD_EMPLOYEE_QUERY7(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("SELECT E.PLT_CODE ");
                    sbQuery.Append("      ,E.EMP_CODE ");
                    sbQuery.Append("  FROM TSTD_EMPLOYEE E ");
                    sbQuery.Append("LEFT JOIN TSYS_EMP_CONF EC ");
                    sbQuery.Append("ON E.PLT_CODE = EC.PLT_CODE ");
                    sbQuery.Append("AND E.EMP_CODE = EC.EMP_CODE ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        StringBuilder sbWhere = new StringBuilder();

                        sbWhere.Append(" WHERE E.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@EMP_CODE", "E.EMP_CODE = @EMP_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@ORG_CODE", "E.ORG_CODE = @ORG_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@REG_EMP", "E.EMP_CODE <> @REG_EMP"));

                        string con = "E.DATA_FLAG = 0 ";
                        con += " AND EC.CONF_NAME = @VAR ";
                        con += " AND EC.CONF_VALUE = '1' ";

                        sbWhere.Append(UTIL.GetWhere(row, "@VAR", con));

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

        public static DataTable TSTD_EMPLOYEE_QUERY8(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT");
                    sbQuery.Append(" E.PLT_CODE");
                    sbQuery.Append(" ,E.EMP_CODE");
                    sbQuery.Append(" ,E.EMP_NAME");
                    sbQuery.Append(" ,E.HIRE_DATE");
                    sbQuery.Append(" ,E.RETIRE_DATE");
                    sbQuery.Append(" ,E.ORG_CODE");
                    sbQuery.Append(" ,O.ORG_NAME");
                    sbQuery.Append(" ,E.PAY_CONTRACT"); 
                    sbQuery.Append(" FROM TSTD_EMPLOYEE E");
                    sbQuery.Append(" LEFT JOIN TSTD_ORG O");
                    sbQuery.Append(" ON E.PLT_CODE = O.PLT_CODE");
                    sbQuery.Append(" AND E.ORG_CODE = O.ORG_CODE");


                    foreach (DataRow row in dtParam.Rows)
                    {

                        StringBuilder sbWhere = new StringBuilder();

                        sbWhere.Append(" WHERE E.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@EMP_CODE", "E.EMP_CODE = @EMP_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@ORG_CODE", "E.ORG_CODE = @ORG_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@IS_RETIRE", "ISNULL(E.EMP_TYPE, '0') <> '5'"));
                        sbWhere.Append(UTIL.GetWhere(row, "@RETIRE_DATE_MONTH", "LEFT(E.RETIRE_DATE, 6) >= @RETIRE_DATE_MONTH OR RETIRE_DATE IS NULL"));
                        sbWhere.Append(UTIL.GetWhere(row, "@HIRE_DATE_MONTH", "LEFT(E.HIRE_DATE, 6) <= @HIRE_DATE_MONTH"));
                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "E.DATA_FLAG = @DATA_FLAG"));

                        StringBuilder sbOrderBy = new StringBuilder();
                        sbOrderBy.Append(" ORDER BY E.ORG_CODE, E.EMP_NAME");

                        DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString() + sbWhere.ToString() + sbOrderBy.ToString()).Copy();

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

        public static DataTable TSTD_EMPLOYEE_QUERY9(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT");
                    sbQuery.Append(" E.PLT_CODE");
                    sbQuery.Append(" ,E.EMP_CODE");
                    sbQuery.Append(" ,E.EMP_NAME");
                    sbQuery.Append(" ,E.ORG_CODE");
                    sbQuery.Append(" ,O.ORG_NAME");
                    sbQuery.Append(" ,EW.EWT_NO");
                    sbQuery.Append(" ,ISNULL(EW.WORK_YEAR, @WORK_YEAR) AS WORK_YEAR");
                    sbQuery.Append(" ,ISNULL(CASE WHEN EW.DATA_FLAG = '0' THEN '1' ELSE '0' END, '0') AS IS_REG");
                    sbQuery.Append(" FROM TSTD_EMPLOYEE E");
                    sbQuery.Append(" LEFT JOIN TSTD_ORG O");
                    sbQuery.Append(" ON E.PLT_CODE = O.PLT_CODE");
                    sbQuery.Append(" AND E.ORG_CODE = O.ORG_CODE");
                    
                    sbQuery.Append(" LEFT JOIN TSTD_EMP_WORKTYPE EW");
                    sbQuery.Append(" ON E.PLT_CODE = EW.PLT_CODE");
                    sbQuery.Append(" AND E.EMP_CODE = EW.EMP_CODE");
                    sbQuery.Append(" AND EW.WORK_YEAR = @WORK_YEAR");


                    foreach (DataRow row in dtParam.Rows)
                    {

                        StringBuilder sbWhere = new StringBuilder();

                        sbWhere.Append(" WHERE E.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@EMP_CODE", "E.EMP_CODE = @EMP_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@ORG_CODE", "E.ORG_CODE = @ORG_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@IS_RETIRE", "ISNULL(E.EMP_TYPE, '0') <> '5'"));
                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "E.DATA_FLAG = @DATA_FLAG"));

                        StringBuilder sbOrderBy = new StringBuilder();
                        sbOrderBy.Append(" ORDER BY E.ORG_CODE, E.EMP_NAME");

                        DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString() + sbWhere.ToString() + sbOrderBy.ToString(), row).Copy();

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

        public static DataTable TSTD_EMPLOYEE_QUERY10(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT COUNT(EMP_CODE) AS EMP_CNT FROM TSTD_EMPLOYEE");
                    sbQuery.Append(" WHERE DATA_FLAG = '0'");
                    sbQuery.Append(" AND LEFT(ISNULL(HIRE_DATE,'000000'), 6) <= @S_MONTH");
                    sbQuery.Append(" AND LEFT(ISNULL(RETIRE_DATE,'999999'), 6) >= @S_MONTH");



                    foreach (DataRow row in dtParam.Rows)
                    {

                        StringBuilder sbWhere = new StringBuilder();

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
