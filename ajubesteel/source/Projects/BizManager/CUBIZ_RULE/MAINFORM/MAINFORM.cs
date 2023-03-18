using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using BizExecute;

namespace MAINFORM
{
    public class MAINFORM
    {
       
        //MENU_LIST,RESOURCE,BIZERROR,SYS_CONF,MENU_CONF,EMP,TOOLTIP,CODES,PLANT,VERSION,EMP_CONF
        public static DataSet MAINFORM_INIT_SYSTEM(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {

                string strQuery = string.Empty;

                DataTable dtRqst = paramDS.Tables["RQSTDT"];
                DataRow paramDr = dtRqst.Rows[0];

                string plt_code = paramDr["PLT_CODE"].ToString();
                string lang = paramDr["LANG"].ToString();
                string emp_code = paramDr["EMP_CODE"].ToString();

                //PLANTS 정보
                DataTable dtPlants = DSYS.TSYS_PLANTS.TSYS_PLANTS_SER(dtRqst, bizExecute);

                //VERSION 정보
                DataTable dtVerInfo = DSYS.TSYS_VERSION.TSYS_VERSION_SER2(bizExecute);

                //EMP 정보
                DataTable dtEmp = DSTD.TSTD_EMPLOYEE.TSTD_EMPLOYEE_SER2(dtRqst, bizExecute);


                CTRL.CTRL.CREATE_EMP_CONFIG_BY_LIST(UTIL.GetDtToDs(dtRqst), bizExecute);

                string usrGrp = dtEmp.Rows[0]["USRGRP_CODE"].ToString();
                bool isSystem = dtEmp.Rows[0]["IS_SYSTEM"].ToString() == "1" ? true: false;
                string sysVer = "";
                string sysType = "Standard";

                if (dtVerInfo.Rows.Count > 0)
                {
                    sysVer = dtVerInfo.Rows[0]["VERSION"].ToString();
                    sysType = dtVerInfo.Rows[0]["TYPE"].ToString();
                }

                //dev_system user(active)일 경우 메뉴리스트 전체(standard, profess. ver 포함)를 보여준다.
                //업체 system user(admin)일 경우, 시스템 메뉴를 제외한 메뉴리스트 전체를 보여준다. 
                //MENU_LIST 정보

                DataTable dtMenu = null;

                UTIL.SetBizAddColumnToValue(dtRqst, "USRGRP_CODE", dtEmp.Rows[0]["USRGRP_CODE"].ToString(), typeof(String));
                UTIL.SetBizAddColumnToValue(dtRqst, "RES_LANG","LANG");

                if ((emp_code.ToUpper().ToString() == "ADMIN") || isSystem)
                {
                    if (emp_code.ToUpper().ToString() == "ADMIN")
                    {
                        UTIL.SetBizAddColumnToValue(dtRqst, "SYS_MENU", "0", typeof(String));

                        if (sysType == "Standard")
                            UTIL.SetBizAddColumnToValue(dtRqst, "STD_MENU", "1", typeof(String));
                        else
                            UTIL.SetBizAddColumnToValue(dtRqst, "PRO_MENU", "1", typeof(String));
                    
                    }
                    dtMenu = DSYS.TSYS_MENULIST_QUERY.TSYS_MENULIST_QUERY7(dtRqst, bizExecute);
                }                
                else
                {
                    dtMenu = DSYS.TSYS_MENULIST_QUERY.TSYS_MENULIST_QUERY8(dtRqst, bizExecute);
                }

                //myMenu 정보
                DataTable dtMyMenu = DSYS.TSYS_MYMENU_QUERY.TSYS_MYMENU_QUERY1(dtRqst, bizExecute);

                //RESOURCE 정보                
                DataTable dtResource = DSYS.TSYS_STRINGTABLE_QUERY.TSYS_STRINGTABLE_QUERY1(dtRqst, bizExecute);

                //SYS_CONF 정보
                DataTable dtSysConf = DSYS.TSYS_CONF_QUERY.TSYS_CONF_QUERY1(UTIL.GetDtToDt(dtRqst, "PLT_CODE"), bizExecute);
                

                //MENU_CONF 정보
                DataTable dtMenuConf = DSYS.TSYS_MENU_CONF_QUERY.TSYS_MENU_CONF_QUERY1(UTIL.GetDtToDt(dtRqst, "PLT_CODE"), bizExecute);

                //TOOLTIP 정보
                DataTable dtTooltip = DSYS.TSYS_TOOLTIP_QUERY.TSYS_TOOLTIP_QUERY1(dtRqst, bizExecute);

                //BIZERROR 정보
                DataTable dtBizErr = DSYS.TSYS_BIZERROR_QUERY.TSYS_BIZERROR_QUERY1(dtRqst, bizExecute);


                //CODES 정보
                DataTable dtCodes = DSTD.TSTD_CODES_QUERY.TSTD_CODES_QUERY8(UTIL.GetDtToDt(dtRqst, "PLT_CODE"), bizExecute);

                //EMP_CONF 정보
                DataTable dtEmpConf = DSYS.TSYS_EMP_CONF_QUERY.TSYS_EMP_CONF_QUERY1(dtRqst, bizExecute);

                DataSet dsResult = new DataSet();

                dsResult.Tables.Add(dtCodes.Copy());
                dsResult.Tables[0].TableName = "CODES";
                dsResult.Tables.Add(dtEmp.Copy());
                dsResult.Tables[1].TableName = "EMP";
                dsResult.Tables.Add(dtEmpConf.Copy());
                dsResult.Tables[2].TableName = "EMP_CONF";
                dsResult.Tables.Add(dtMenu.Copy());
                dsResult.Tables[3].TableName = "MENU_LIST";
                dsResult.Tables.Add(dtMenuConf.Copy());
                dsResult.Tables[4].TableName = "MENU_CONF";
                dsResult.Tables.Add(dtPlants.Copy());
                dsResult.Tables[5].TableName = "PLANT";
                dsResult.Tables.Add(dtResource.Copy());
                dsResult.Tables[6].TableName = "RESOURCE";
                dsResult.Tables.Add(dtSysConf.Copy());
                dsResult.Tables[7].TableName = "SYS_CONF";
                dsResult.Tables.Add(dtTooltip.Copy());
                dsResult.Tables[8].TableName = "TOOLTIP";
                dsResult.Tables.Add(dtBizErr.Copy());
                dsResult.Tables[9].TableName = "BIZERROR";
                dsResult.Tables.Add(dtVerInfo.Copy());
                dsResult.Tables[10].TableName = "VERSION";
                dsResult.Tables.Add(dtMyMenu.Copy());
                dsResult.Tables[11].TableName = "MYMENU";

                return dsResult;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

     
        /// <summary>
        /// LOG_IN ID 및 PASSWORD 검사
        /// </summary>
        /// <param name="paramDS">PLT_CODE,EMP_CODE, ACC_PWD</param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataSet MAINFORM_LOG_IN(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                string strQuery = string.Empty;

                DataTable dtRqst = paramDS.Tables["RQSTDT"];

                string emp_code = dtRqst.Rows[0]["EMP_CODE"].ToString();

                UTIL.SetBizAddColumnToValue(dtRqst, "DATA_FLAG", "0", typeof(String));

                if (emp_code.ToUpper().Equals("ACTIVE") || emp_code.ToUpper().Equals("ADMIN"))
                    dtRqst.Rows[0]["DATA_FLAG"] = ""; 

                DataTable dtEmp = DSTD.TSTD_EMPLOYEE.TSTD_EMPLOYEE_SER3(dtRqst, bizExecute);

                if (dtEmp.Rows.Count == 0)
                {
                    throw UTIL.SetException("아이디 또는 비밀번호를 확인하세요."
                                    , new System.Diagnostics.StackFrame().GetMethod().Name
                                    , 200060);
                    //throw UTIL.SetException("아이디 또는 비밀번호를 확인하세요.");
                }
                else
                {
                    //비밀번호 정책 사용  1:사용 그외 미사용
                    string pwd_policy = dtEmp.Rows[0]["PWD_POLICY_USE"].ToString();

                    string in_pwd = dtRqst.Rows[0]["ACC_PWD"].ToString();// ExtensionMethod.GetStringToMD5(dtRqst.Rows[0]["ACC_PWD"].ToString());

                    string db_pwd = dtEmp.Rows[0]["ACC_PWD"].ToString();

                    int pwd_failed_cnt = dtEmp.Rows[0]["PWD_FAILED_CNT"].toInt();

                    int pwd_fail_limited_cnt = dtEmp.Rows[0]["PWD_FAIL_LIMITED_CNT"].toInt();


                    if (pwd_policy == "1" && pwd_fail_limited_cnt != 0 && pwd_failed_cnt >= pwd_fail_limited_cnt)
                    {//비밀번호 오류 허용횟수({0}회)를 초과 하였습니다.\r\n관리자에게 문의 하십시오.
                        throw UTIL.SetException(string.Format("비밀번호 오류 허용횟수({0}회)를 초과 하였습니다.\r\n관리자에게 문의 하십시오."
                                        , pwd_fail_limited_cnt)
                                        , new System.Diagnostics.StackFrame().GetMethod().Name
                                        , 200060);
                    }

                    if (in_pwd != db_pwd)
                    {
                        ++pwd_failed_cnt;

                        DSTD.TSTD_EMPLOYEE.TSTD_EMPLOYEE_UPD6(dtRqst, bizExecute);

                        bizExecute.commitClose();

                        if (pwd_policy != "1" || pwd_fail_limited_cnt == 0)
                        {
                            throw UTIL.SetException("아이디 또는 비밀번호를 확인하세요."
                                    , new System.Diagnostics.StackFrame().GetMethod().Name
                                    , 200060);
                        }
                        else
                        {
                            throw UTIL.SetException(string.Format("비밀번호가 틀렸습니다.현재 오류 횟수는 {0}회 입니다.\r\n"
                                                                + "{1}회를 초과하게 되면 계정이 잠금 상태가 됩니다.\r\n"
                                                                + "비밀번호를 정확히 입력하여 주십시오.", pwd_failed_cnt, pwd_fail_limited_cnt)
                                                                , new System.Diagnostics.StackFrame().GetMethod().Name
                                                                , 200060);
                        }

                    }


                    //if ( dtEmp.Rows[0]["IS_SYSTEM"].ToString() == "0" && dtEmp.Rows[0]["USRGRP_CODE"].ToString() == "")
                    //    throw UTIL.SetException("사용자 그룹이 설정되어 있지 않습니다. 관리자에게 문의하세요. "
                    //        , new System.Diagnostics.StackFrame().GetMethod().Name
                    //        , 200061);
                }

                dtEmp.TableName = "RSLTDT";
                paramDS.Tables.Add(dtEmp);

                DSTD.TSTD_EMPLOYEE.TSTD_EMPLOYEE_UPD7(dtRqst, bizExecute);

                DSYS.TSYS_LOGIN_LOG.TSYS_LOGIN_LOG_INS2(dtRqst, bizExecute);

                // UID 넘기기
                DataTable dtLog = DSYS.TSYS_LOGIN_LOG.TSYS_LOGIN_LOG_SER(dtRqst, bizExecute);
                dtLog.TableName = "RSLTDT_LOG";

                //LOG IN 이력 저장
                CTRL.CTRL.EXECUTE_LOG("접속",bizExecute);

                paramDS.Tables.Add(dtLog);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
            
        }

        public static DataSet MAINFORM_LOG_OUT(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {

                DataTable dtRqst = paramDS.Tables["RQSTDT"];

                DSYS.TSYS_LOGIN_LOG.TSYS_LOGIN_LOG_UPD(dtRqst, bizExecute);

                //LOG OUT 이력 저장
                CTRL.CTRL.EXECUTE_LOG("종료", bizExecute);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }

        public static DataSet MAINFORM_CHECK_ACCESSMENU(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable dtRqst = paramDS.Tables["RQSTDT"];

                DataRow paramDr = paramDS.Tables["RQSTDT"].Rows[0];

                if (ConnInfo.IsSysUser) return null;
                //if (paramDr["EMP_CODE"].ToString().ToUpper() == "ACTIVE") return null;

                DataTable dtUsrGrp = DSTD.TSTD_EMPLOYEE.TSTD_EMPLOYEE_SER(dtRqst, bizExecute);

                if (dtUsrGrp.Rows.Count > 0)
                {

                    UTIL.SetBizAddColumnToValue(dtRqst, "USRGRP_CODE", dtUsrGrp.Rows[0]["USRGRP_CODE"].ToString(), typeof(String));

                    DataTable dtAccess = DSYS.TSYS_ACCESS.TSYS_ACCESS_SER(dtRqst, bizExecute);

                    if (dtAccess.Rows.Count <= 0)
                        throw UTIL.SetException("메뉴 권한 없음"
                                    , ""
                                    , new System.Diagnostics.StackFrame().GetMethod().Name
                                    , 100010);
                        
                }
                else
                {
                    throw UTIL.SetException("unvalid id"
                                    , ""
                                    , new System.Diagnostics.StackFrame().GetMethod().Name
                                    , 100009);
                }
                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet MAINFORM_CHECK_VERSION(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {

                DataTable dtRqst = paramDS.Tables["RQSTDT"];

                DataRow paramDr = paramDS.Tables["RQSTDT"].Rows[0];

                DataTable dtRslt = DSYS.TSYS_VERSION.TSYS_VERSION_SER(dtRqst, bizExecute);

                if (dtRslt.Rows.Count == 0)
                    throw UTIL.SetException("메뉴 권한 없음"
                                    , ""
                                    , new System.Diagnostics.StackFrame().GetMethod().Name
                                    , 200061);
                else
                {
                    if (paramDr["VERSION"].ToString() != dtRslt.Rows[0]["VERSION"].ToString())
                    throw UTIL.SetException("메뉴 권한 없음"
                                    , ""
                                    , new System.Diagnostics.StackFrame().GetMethod().Name
                                    , 200062);
                    
                }
                return paramDS;

            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

            
        }

        public static DataSet MAINFORM_SAVE_MYMENU(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable dtParam = paramDS.Tables["RQSTDT"];

                DataTable dtResult = new DataTable("RSLTDT");
                dtResult.Columns.Add("RESULT", typeof(string));

                DataRow drResult = dtResult.NewRow();

                DataTable dtSer = DSYS.TSYS_MYMENU.TSYS_MYMENU_SER(dtParam, bizExecute);

                if (dtSer.Rows.Count < 1)
                {
                    drResult["RESULT"] = "ADD";
                    DSYS.TSYS_MYMENU.TSYS_MYMENU_INS(paramDS.Tables["RQSTDT"], bizExecute);
                }
                else
                {
                    drResult["RESULT"] = "NO";
                }

                dtResult.Rows.Add(drResult);

                paramDS.Tables.Add(dtResult.Copy());

                return paramDS;

            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }


        }

        public static DataSet MAINFORM_DEL_MYMENU(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable dtParam = paramDS.Tables["RQSTDT"];

                DSYS.TSYS_MYMENU.TSYS_MYMENU_DEL(dtParam, bizExecute);

                return paramDS;

            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }


        }

        //public static DataSet MAINFORM_GET_BIZERROR(DataSet paramDS, BizExecute.BizExecute bizExecute)
        //{
        //    DataRow paramDr = paramDS.Tables["RQSTDT"].Rows[0];

        //    string plt_code = paramDr["PLT_CODE"].ToString();
        //    int number = paramDr["EMP_CODE"].toInt32();
        //    string lang = paramDr["LANG"].ToString();

        //    string strQuery = " SELECT PLT_CODE, NUMBER, LANG, DESCRIPTION FROM TSYS_BIZERROR ";

        //    strQuery += "WHERE PLT_CODE = '" + plt_code + "'" +
        //        " AND NUMBER = " + number +
        //        " AND LANG = '" + lang + "'";

        //    DataTable dtRslt = bizExecute.executeSelectQuery(strQuery);

        //    DataSet dsRslt = new DataSet();
        //    dsRslt.Tables.Add(dtRslt);

        //    return dsRslt;

        //}

        public static DataSet MAINFORM_GET_PANEL(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {

            try
            {
                //UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

                DataTable dtRslt = DSTD.TSTD_MC_AVAILEMP_QUERY.TSTD_MC_AVAILEMP_QUERY1(paramDS.Tables["RQSTDT"],  bizExecute);

                dtRslt = dtRslt.AsEnumerable()
                            .GroupBy(g => new
                            {
                                MC_CODE = g["MC_CODE"],
                                MC_NAME = g["MC_NAME"]
                            })
                            .Select(r => new {
                                MC_CODE = r.Key.MC_CODE,
                                MC_NAME = r.Key.MC_NAME
                            })
                            .OrderBy(o=> o.MC_NAME)
                            .LINQToDataTable();
                DataSet dsRslt = new DataSet();

                dtRslt.TableName = "RSLTDT";

                dsRslt.Tables.Add(dtRslt);

                return dsRslt;

            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
                
        }

        public static DataSet MAINFORM_GET_EMP(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

                DataTable dtRslt = DSTD.TSTD_EMPLOYEE_QUERY.TSTD_EMPLOYEE_QUERY1(paramDS.Tables["RQSTDT"],  bizExecute);

                DataSet dsRslt = new DataSet();

                dtRslt.TableName = "RSLTDT";

                dsRslt.Tables.Add(dtRslt);

                return dsRslt;

            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }

        //public static DataSet MAINFORM_GET_NOTIFY(DataSet paramDS, BizExecute.BizExecute bizExecute)
        //{
        //    try
        //    {
        //        DataSet dsRslt = new DataSet();

        //        dtRslt.TableName = "RSLTDT";

        //        dsRslt.Tables.Add(dtRslt);

        //        return dsRslt;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
        //    }
        //}


        public static DataSet MAINFORM_GET_PANEL2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {

            try
            {
                //UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

                DataTable dtRslt = DSTD.TSTD_MC_AVAILEMP_QUERY.TSTD_MC_AVAILEMP_QUERY3(paramDS.Tables["RQSTDT"], bizExecute);

                dtRslt = dtRslt.AsEnumerable()
                            .GroupBy(g => new
                            {
                                MC_CODE = g["MC_CODE"],
                                MC_NAME = g["MC_NAME"]
                            })
                            .Select(r => new {
                                MC_CODE = r.Key.MC_CODE,
                                MC_NAME = r.Key.MC_NAME
                            })
                           // .OrderBy(o => o.MC_NAME)
                            .LINQToDataTable();
                DataSet dsRslt = new DataSet();

                dtRslt.TableName = "RSLTDT";

                dsRslt.Tables.Add(dtRslt);

                return dsRslt;

            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }

    }
}
