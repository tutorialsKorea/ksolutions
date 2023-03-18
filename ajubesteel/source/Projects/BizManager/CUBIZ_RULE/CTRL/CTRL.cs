using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace CTRL
{
    public class CTRL
    {
        public const string SHIP_PROC = "P-25";


        private static string _serverIP;
        private static string _databaseName;

        public static string ServerIP
        {
            get { return _serverIP; }
            set { _serverIP = value; }
        }

        public static string DatabaseName
        {
            get { return _databaseName; }
            set { _databaseName = value; }
        }

        /// <summary>
        /// 새로운 리소스 ID를 생성하여 반환한다.
        /// </summary>
        /// <param name="paramDS">PLT_CODE, LANG</param>
        /// <returns>RES_ID</returns>
        public static string CreateResourceID(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable dtParam = paramDS.Tables["RQSTDT"];

                DataTable dtRows;

                while (true)
                {
                    Random rnd = new Random();

                    string tmpGUID = null;

                    string keyString = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";

                    for (int tmpCounter = 0; tmpCounter < 8; tmpCounter++)
                    {
                        tmpGUID = tmpGUID + keyString.Substring((int)(rnd.NextDouble() * keyString.Length), 1);
                    }

                    DataTable dtStr = new DataTable();
                    dtStr.Columns.Add("PLT_CODE");
                    dtStr.Columns.Add("RES_ID");
                    dtStr.Columns.Add("RES_LANG");
                    dtStr.Columns.Add("RES_TYPE");
                    dtStr.Columns.Add("RES_CONTENTS");

                    DataRow drRow = dtStr.NewRow();
                    drRow["PLT_CODE"] = dtParam.Rows[0]["PLT_CODE"];
                    drRow["RES_ID"] = tmpGUID;
                    drRow["RES_LANG"] = dtParam.Rows[0]["RES_LANG"];
                    drRow["RES_TYPE"] = dtParam.Rows[0]["RES_TYPE"];
                    drRow["RES_CONTENTS"] = dtParam.Rows[0]["RES_CONTENTS"];
                    dtStr.Rows.Add(drRow);

                    dtRows = DSYS.TSYS_STRINGTABLE.TSYS_STRINGTABLE_SER(dtStr, bizExecute);

                    if (dtRows.Rows.Count == 0)
                    {
                        DSYS.TSYS_STRINGTABLE.TSYS_STRINGTABLE_INS(dtStr, bizExecute);
                        return tmpGUID;
                    }
                }

            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }


        }

        /// <summary>
        /// 알림 생성
        /// </summary>
        /// <param name="paramDS"></param>
        /// <param name="bizExecute"></param>
        public static void CreateNotify(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable dtParam = paramDS.Tables["RQSTDT"];

                if (!dtParam.Columns.Contains("EMP_CODE")) dtParam.Columns.Add("EMP_CODE", typeof(String));
                if (!dtParam.Columns.Contains("ORG_CODE")) dtParam.Columns.Add("ORG_CODE", typeof(String));


                switch (dtParam.Rows[0]["TYPE"].ToString())
                {
                    case "E":

                        dtParam.Rows[0]["EMP_CODE"] = dtParam.Rows[0]["KEY"];

                        break;
                    case "O":
                        dtParam.Rows[0]["ORG_CODE"] = dtParam.Rows[0]["KEY"];

                        break;
                    case "P":
                        break;
                }

                DataTable dtResult = DSTD.TSTD_EMPLOYEE_QUERY.TSTD_EMPLOYEE_QUERY7(dtParam, bizExecute);

                if (dtResult.Rows.Count > 0)
                {
                    if (!dtParam.Columns.Contains("VAR")) dtParam.Columns.Add("VAR", typeof(String));
                    if (!dtParam.Columns.Contains("MENU_CODE")) dtParam.Columns.Add("MENU_CODE", typeof(String));

                    dtParam.Rows[0]["VAR"] = "NOTIFY_NOTICE";
                    dtParam.Rows[0]["MENU_CODE"] = "SYS03A";

                    DSYS.TSYS_NOTICE.TSYS_NOTICE_INS(paramDS.Tables["RQSTDT"], bizExecute);
                }

            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }
        /// <summary>
        /// 1.TSYS_USERCONFIG_LIST TABLE에 데이터 있는지 확인, 있으면 덮어쓰기
        /// 2.TSYS_USERCONFIG_USE TABLE에 데이터 있는지 확인, 있으면 덮어쓰기
        /// 3.TSYS_USERCONFIG_USE 저장된 LAYOUT, OBJECT 가져오기.
        /// </summary>
        /// <param name="paramDS"></param>
        /// <returns></returns>
        public static DataSet SET_USERCONFIG_SAVE(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable dtNow = UTIL.UTILITY_GET_DTNOW(bizExecute);
                string dt = ((DateTime)dtNow.Rows[0]["NOW_DT"]).ToString("yyyy-MM-dd HH:mm:ss");

                if (paramDS.Tables["RQSTDT"].Rows.Count <= 0) return null;

                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    DataTable dtParam = paramDS.Tables["RQSTDT"].Clone();
                    DataRow newRow = dtParam.NewRow();
                    newRow.ItemArray = row.ItemArray;
                    dtParam.Rows.Add(newRow);
                    dtParam.Columns.Add("REG_DATE", typeof(String));
                    dtParam.Columns.Add("MDFY_DATE", typeof(String));

                    //1. 해당 환경명이 있는지 확인
                    DataTable dtConfig = DSYS.TSYS_USERCONFIG_LIST.TSYS_USERCONFIG_LIST_SER(dtParam, bizExecute);

                    if (dtConfig.Rows.Count > 0)
                    {
                        if (row["OVERWRITE"].Equals("1"))
                        {
                            dtParam.Rows[0]["REG_DATE"] = dt;
                            dtParam.Rows[0]["MDFY_DATE"] = dt;
                            DSYS.TSYS_USERCONFIG_LIST.TSYS_USERCONFIG_LIST_UPD(dtParam, bizExecute);
                        }
                    }
                    else
                    {
                        dtParam.Rows[0]["REG_DATE"] = dt;
                        DSYS.TSYS_USERCONFIG_LIST.TSYS_USERCONFIG_LIST_INS(dtParam, bizExecute);
                    }


                    if (row["DEFAULT_USE"].Equals("1"))
                    {
                        if (!dtParam.Columns.Contains("USE_CONFIG_NAME")) dtParam.Columns.Add("USE_CONFIG_NAME");
                        if (!dtParam.Columns.Contains("USE_CONFIG_MAKER")) dtParam.Columns.Add("USE_CONFIG_MAKER");

                        dtParam.Rows[0]["USE_CONFIG_NAME"] = row["CONFIG_NAME"];
                        dtParam.Rows[0]["USE_CONFIG_MAKER"] = row["EMP_CODE"];

                        DataSet dsRslt = new DataSet();
                        dsRslt.Tables.Add(dtParam);

                        SET_USERCONFIG_DEFAULT_USE(dsRslt, bizExecute);
                    }
                }
                return GET_USERCONFIG_DEFAULT_USE(paramDS, bizExecute);

            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        /// <summary>
        /// 사용자 환경 저장 (사용자 환경명이 예약어일경우 허용안함)
        /// 1.TSYS_USERCONFIG_LIST TABLE에 데이터 있는지 확인, 있으면 덮어쓰기
        /// 2.TSYS_USERCONFIG_USE TABLE에 데이터 있는지 확인, 있으면 덮어쓰기
        /// 3.TSYS_USERCONFIG_USE 저장된 LAYOUT, OBJECT 가져오기.
        /// </summary>
        /// <param name="paramDS"></param>
        /// <returns></returns>
        public static DataSet SET_USERCONFIG_SAVE2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (paramDS.Tables["RQSTDT"].Rows.Count <= 0) return null;

                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    DataTable dtParam = paramDS.Tables["RQSTDT"].Clone();
                    DataRow newRow = dtParam.NewRow();
                    newRow.ItemArray = row.ItemArray;
                    dtParam.Rows.Add(newRow);
                    dtParam.Columns.Add("REG_DATE", typeof(String));
                    dtParam.Columns.Add("MDFY_DATE", typeof(String));

                    if (!dtParam.Columns.Contains("DEFAULT_USE")) dtParam.Columns.Add("DEFAULT_USE", typeof(String));

                    string config_name = row["CONFIG_NAME"].ToString();

                    if (config_name == "@DEFAULT")
                        throw UTIL.SetException("@DEFAULT는 예약어입니다. 다른 환경명을 사용하세요."
                            , new System.Diagnostics.StackFrame().GetMethod().Name);

                    //1. 해당 환경명이 있는지 확인
                    DataTable dtConfig = DSYS.TSYS_USERCONFIG_LIST.TSYS_USERCONFIG_LIST_SER(dtParam, bizExecute);

                    if (dtConfig.Rows.Count > 0)
                    {

                        if (row["OVERWRITE"].Equals("1"))
                        {
                            DSYS.TSYS_USERCONFIG_LIST.TSYS_USERCONFIG_LIST_UPD(dtParam, bizExecute);
                        }
                        else
                        {
                            throw UTIL.SetException("동일 데이터가 존재할때 발생"
                                , new System.Diagnostics.StackFrame().GetMethod().Name
                                , BizException.OVERWRITE);
                        }
                    }
                    else
                    {
                        DSYS.TSYS_USERCONFIG_LIST.TSYS_USERCONFIG_LIST_INS(dtParam, bizExecute);
                    }


                    if (dtParam.Rows[0]["DEFAULT_USE"].Equals("1"))
                    {
                        if (!dtParam.Columns.Contains("USE_CONFIG_NAME")) dtParam.Columns.Add("USE_CONFIG_NAME");
                        if (!dtParam.Columns.Contains("USE_CONFIG_MAKER")) dtParam.Columns.Add("USE_CONFIG_MAKER");

                        dtParam.Rows[0]["USE_CONFIG_NAME"] = row["CONFIG_NAME"];
                        dtParam.Rows[0]["USE_CONFIG_MAKER"] = row["EMP_CODE"];

                        DataSet dsRslt = new DataSet();
                        dsRslt.Tables.Add(dtParam);

                        SET_USERCONFIG_DEFAULT_USE(dsRslt, bizExecute);
                    }
                }

                DataSet dsResult = GET_USERCONFIG_DEFAULT_USE(paramDS, bizExecute);
                DataTable dtResult = paramDS.Tables["RQSTDT"].Copy();
                dtResult.TableName = "RQSTDT";
                dsResult.Tables.Add(dtResult);

                return dsResult;

            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        /// <summary>
        /// 사용자환경 목록을 가져온다.
        /// </summary>
        /// <param name="paramDS">
        /// PLT_CODE
        /// EMP_CODE
        /// CLASS_NAME
        /// CONTROL_NAME</param>
        /// <returns></returns>
        public static DataSet GET_USERCONFIG_LIST(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable dtRslt = new DataTable();

                dtRslt = DSYS.TSYS_USERCONFIG_LIST_QUERY.TSYS_USERCONFIG_LIST_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);

                dtRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }
        /// <summary>
        /// 사용자 기본 환경설정 가져오기
        /// </summary>
        /// <param name="paramDS"></param>
        /// <returns></returns>
        public static DataSet GET_USERCONFIG_DEFAULT_USE(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable dtUse = DSYS.TSYS_USERCONFIG_USE_QUERY.TSYS_USERCONFIG_USE_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);

                DataTable dtList = new DataTable();
                dtList.TableName = "RSLTDT";

                if (dtUse.Rows.Count > 0)
                {
                    if (!dtUse.Columns.Contains("CONFIG_NAME")) dtUse.Columns.Add("CONFIG_NAME");

                    dtUse.Rows[0]["CONFIG_NAME"] = dtUse.Rows[0]["USE_CONFIG_NAME"];
                    dtUse.Rows[0]["EMP_CODE"] = dtUse.Rows[0]["USE_CONFIG_MAKER"];
                    dtList = DSYS.TSYS_USERCONFIG_LIST_QUERY.TSYS_USERCONFIG_LIST_QUERY1(dtUse, bizExecute);
                }

                DataSet reportSet = GET_USER_USED_CUSTOM_EXCEL(paramDS, bizExecute);
                DataTable dtReport = reportSet.Tables.Contains("RSLTDT") ? reportSet.Tables["RSLTDT"].Copy() : null;
                dtReport.TableName = "RSLTDT_REPORT";

                DataSet dsRslt = new DataSet();
                dsRslt.Tables.Add(dtList);
                dsRslt.Tables.Add(dtReport);

                return dsRslt;

            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        /// <summary>
        /// 사용자 환경 기본설정 삭제
        /// </summary>
        /// <param name="paramDS">
        /// PLT_CODE
        /// EMP_CODE
        /// CLASS_NAME
        /// CONTROL_NAME</param>
        /// <returns></returns>
        public static void SET_USERCONFIG_DEFAULT_USE_DEL(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable dtParam = paramDS.Tables["RQSTDT"];

                if (dtParam.Rows.Count > 0)
                {
                    DSYS.TSYS_USERCONFIG_USE.TSYS_USERCONFIG_USE_DEL(dtParam, bizExecute);
                }
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        /// <summary>
        /// 그리드 사용자 환경 삭제
        /// </summary>
        /// <param name="paramDS"></param>
        public static void SET_USERCONFIG_DEL(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    DataTable dtSer = DSYS.TSYS_USERCONFIG_USE_QUERY.TSYS_USERCONFIG_USE_QUERY1(UTIL.GetRowToDt(row), bizExecute);

                    if (dtSer.Rows.Count > 0)
                    {
                        //사용자중인 기본설정 삭제
                        DSYS.TSYS_USERCONFIG_USE.TSYS_USERCONFIG_USE_DEL(dtSer, bizExecute);
                    }
                    DSYS.TSYS_USERCONFIG_LIST.TSYS_USERCONFIG_LIST_DEL(UTIL.GetRowToDt(row), bizExecute);
                }
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        /// <summary>
        /// 사용자 환경 삭제
        /// </summary>
        /// <param name="paramDS"></param>
        public static DataSet SET_USERCONFIG_DEL2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {

                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    DataTable dtSer = DSYS.TSYS_USERCONFIG_USE_QUERY.TSYS_USERCONFIG_USE_QUERY1(UTIL.GetRowToDt(row), bizExecute);

                    if (dtSer.Rows.Count > 0)
                    {
                        //사용자중인 기본설정 삭제
                        DSYS.TSYS_USERCONFIG_USE.TSYS_USERCONFIG_USE_DEL(dtSer, bizExecute);
                    }

                    DSYS.TSYS_USERCONFIG_USE.TSYS_USERCONFIG_USE_DEL3(UTIL.GetRowToDt(row), bizExecute);
                    DSYS.TSYS_USERCONFIG_LIST.TSYS_USERCONFIG_LIST_DEL3(UTIL.GetRowToDt(row), bizExecute);
                }

                return paramDS;

            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }


        /// <summary>
        /// 그리드 환경을 기본사용으로 설정
        /// </summary>
        /// <param name="paramDS"></param>
        public static DataSet SET_USERCONFIG_DEFAULT_USE(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                //1. 사용하고자 하는 그리드 환경이 존재하는지 확인.
                DataTable dtParam = paramDS.Tables["RQSTDT"];

                if (dtParam.Rows.Count > 0)
                {
                    if (!dtParam.Columns.Contains("CONFIG_NAME")) dtParam.Columns.Add("CONFIG_NAME");
                    dtParam.Rows[0]["CONFIG_NAME"] = dtParam.Rows[0]["USE_CONFIG_NAME"];

                    //로그인 유저
                    string login_emp = dtParam.Rows[0]["EMP_CODE"].ToString();

                    dtParam.Rows[0]["EMP_CODE"] = dtParam.Rows[0]["USE_CONFIG_MAKER"];
                    DataTable dtConfig = DSYS.TSYS_USERCONFIG_LIST.TSYS_USERCONFIG_LIST_SER(dtParam, bizExecute);
                    

                    //DataTable dtConfig = DSYS.TSYS_USERCONFIG_USE.TSYS_USERCONFIG_USE_SER(dtParam, bizExecute);

                    if (dtConfig.Rows.Count > 0)
                    {
                        //2. 사용자 환경 확인
                        dtParam.Rows[0]["EMP_CODE"] = login_emp;
                        DataTable dtConfigUse = DSYS.TSYS_USERCONFIG_USE.TSYS_USERCONFIG_USE_SER(dtParam, bizExecute);

                        
                        if (dtConfigUse.Rows.Count > 0)
                        {

                            DSYS.TSYS_USERCONFIG_USE.TSYS_USERCONFIG_USE_UPD(dtParam, bizExecute);
                        }
                        else
                        {
                            DSYS.TSYS_USERCONFIG_USE.TSYS_USERCONFIG_USE_INS(dtParam, bizExecute);
                        }
                    }
                }

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }

        public static void CREATE_NOTIFY(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable dtParam = paramDS.Tables["RQSTDT"];
                DataTable dtResult = new DataTable();

                DataTable dtNotice = new DataTable("RQSTDT");
                dtNotice.Columns.Add("PLT_CODE", typeof(String));
                dtNotice.Columns.Add("EMP_CODE", typeof(String));
                dtNotice.Columns.Add("TITLE", typeof(String));
                dtNotice.Columns.Add("MESSAGE", typeof(String));
                dtNotice.Columns.Add("MENU_CODE", typeof(String));
                dtNotice.Columns.Add("SEARCH_KEY", typeof(String));
                dtNotice.Columns.Add("REG_EMP", typeof(String));

                if (dtParam.Rows.Count > 0)
                {
                    if (!dtParam.Columns.Contains("DATA_FLAG")) dtParam.Columns.Add("DATA_FLAG", typeof(Int32));
                    if (!dtParam.Columns.Contains("EMP_CODE")) dtParam.Columns.Add("EMP_CODE", typeof(String));
                    if (!dtParam.Columns.Contains("ORG_CODE")) dtParam.Columns.Add("ORG_CODE", typeof(String));
                    //E- 개인 , O-부서 , P-전체
                    string type = dtParam.Rows[0]["TYPE"].ToString();

                    switch (type)
                    {
                        case "E":
                            dtParam.Rows[0]["EMP_CODE"] = dtParam.Rows[0]["KEY"];
                            dtResult = DSTD.TSTD_EMPLOYEE_QUERY.TSTD_EMPLOYEE_QUERY7(dtParam, bizExecute);
                            break;
                        case "O":
                            dtParam.Rows[0]["ORG_CODE"] = dtParam.Rows[0]["KEY"];
                            dtResult = DSTD.TSTD_EMPLOYEE_QUERY.TSTD_EMPLOYEE_QUERY7(dtParam, bizExecute);
                            break;
                        case "P":
                            dtResult = DSTD.TSTD_EMPLOYEE_QUERY.TSTD_EMPLOYEE_QUERY7(dtParam, bizExecute);
                            break;
                    }

                    foreach(DataRow dr in dtResult.Rows)
                    {
                        DataRow drNew = dtNotice.NewRow();
                        drNew["PLT_CODE"] = dr["PLT_CODE"];
                        drNew["EMP_CODE"] = dr["EMP_CODE"];
                        drNew["TITLE"] = dtParam.Rows[0]["TITLE"];
                        drNew["MESSAGE"] = dtParam.Rows[0]["MESSAGE"];
                        drNew["MENU_CODE"] = dtParam.Rows[0]["MENU_CODE"];
                        drNew["SEARCH_KEY"] = dtParam.Rows[0]["SEARCH_KEY"];
                        drNew["REG_EMP"] = dtParam.Rows[0]["REG_EMP"];
                        dtNotice.Rows.Add(drNew);

                        //DSYS.TSYS_NOTICE.TSYS_NOTICE_INS(dtNotice, bizExecute);
                    }
                    DSYS.TSYS_NOTIFY.TSYS_NOTIFY_INS(dtNotice, bizExecute);

                }
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        /// <summary>
        /// 알림 가져오기
        /// </summary>
        /// <param name="paramDS">
        /// PLT_CODE
        /// EMP_CODE
        /// </param>
        public static DataSet GET_NOTIFY(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable dt = DSYS.TSYS_NOTIFY_QUERY.TSYS_NOTIFY_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);

                DataTable dt_board = DSYS.TSYS_BOARD_QUERY.TSYS_BOARD_QUERY3(paramDS.Tables["RQSTDT"], bizExecute);

                DataTable dt_boardReply = DSYS.TSYS_BOARD_QUERY.TSYS_BOARD_QUERY4(paramDS.Tables["RQSTDT"], bizExecute);

                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "IS_POPUP", 0, typeof(byte));

                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(byte));

                DataTable dt_work = DSTD.TSTD_ORG_REF_EMP_QUERY.TSTD_ORG_REF_EMP_QUERY2(paramDS.Tables["RQSTDT"], bizExecute);

                DataTable dt_out_req = DMAT.TMAT_OUT_REQ_EMP_QUERY.TMAT_OUT_REQ_EMP_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);

                DataTable dt_ng = DSHP.TSHP_NG_QUERY.TSHP_NG_QUERY12(paramDS.Tables["RQSTDT"], bizExecute);

                DataTable dt_prod = DORD.TORD_PRODUCT_IF.TORD_PRODUCT_IF_SER2(paramDS.Tables["RQSTDT"], bizExecute);

                DataTable dt_dev = DORD.TORD_PRODUCT_SEND_DEV.TORD_PRODUCT_SEND_DEV_SER2(paramDS.Tables["RQSTDT"], bizExecute);

                DataSet ds = new DataSet();

                dt.TableName = "RSLTDT";

                dt_board.TableName = "RSLTDT_BOARD";

                dt_boardReply.TableName = "RSLTDT_BOARD_REPLY";

                dt_work.TableName = "RSLTDT_WORK";

                dt_out_req.TableName = "RSLTDT_OUT_REQ";

                dt_ng.TableName = "RSLTDT_NG";

                dt_prod.TableName = "RSLTDT_PROD";

                dt_dev.TableName = "RSLTDT_DEV"; 


                ds.Tables.Add(dt);
                ds.Tables.Add(dt_board);
                ds.Tables.Add(dt_boardReply);
                ds.Tables.Add(dt_work);
                ds.Tables.Add(dt_out_req);
                ds.Tables.Add(dt_ng);
                ds.Tables.Add(dt_prod);
                ds.Tables.Add(dt_dev);

                return ds;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet DELETE_NOTIFY(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DSYS.TSYS_NOTIFY.TSYS_NOTIFY_DEL(paramDS.Tables["RQSTDT"], bizExecute);

                DataSet dsResult = new DataSet();

                return dsResult;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        /// <summary>
        /// 사용자정보 조회
        /// </summary>
        /// <param name="paramDS">
        /// PLT_CODE
        /// EMP_CODE
        /// ORG_CODE
        /// DATA_FLAG
        /// AVAILMC
        /// EMP_LIKE
        /// USRGRP_CODE
        /// ACC_PWD
        /// EMP_TYPE
        /// </param>
        /// <returns></returns>
        public static DataSet GET_EMPLOYEE(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (!paramDS.Tables["RQSTDT"].Columns.Contains("DATA_FLAG"))
                {
                    paramDS.Tables["RQSTDT"].Columns.Add("DATA_FLAG", typeof(Int32));
                    paramDS.Tables["RQSTDT"].Columns.Add("IS_SYSTEM", typeof(Int32));
                    paramDS.Tables["RQSTDT"].Columns.Add("IS_ORG", typeof(String));

                    //paramDS.Tables["RQSTDT"].Rows[0]["DATA_FLAG"] = 0;
                    paramDS.Tables["RQSTDT"].Rows[0]["IS_SYSTEM"] = 0;
                    paramDS.Tables["RQSTDT"].Rows[0]["IS_ORG"] = "1";
                }

                DataTable dtRslt = new DataTable();

                //UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

                dtRslt = DSTD.TSTD_EMPLOYEE_QUERY.TSTD_EMPLOYEE_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);

                dtRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet GET_ORG(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {

            try
            {
                if (paramDS.Tables.Contains("RSLTDT")) return paramDS;

                DataTable dtRslt = DSTD.TSTD_ORG_QUERY.TSTD_ORG_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);

                dtRslt.Columns.Add("SEL", typeof(string));
                dtRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }

        /// <summary>
        /// 사용자 환경설정 데이터를 설정한다.
        /// </summary>
        /// <param name="paramDS">PLT_CODE, EMP_CODE, CONF_NAME, CONF_VALUE, REG_EMP</param>
        /// <returns></returns>
        public static DataSet SET_EMP_CONFIG(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            //1. TSYS_EMP_CONF_SER
            //2. IF EXISTS(1) TSYS_EMP_CONF_UPD
            //3. ELSE TSYS_EMP_CONF_INS
            try
            {
                DataTable dtRqst = paramDS.Tables["RQSTDT"];
                if (!paramDS.Tables["RQSTDT"].Columns.Contains("MDFY_EMP")) paramDS.Tables["RQSTDT"].Columns.Add("MDFY_EMP", typeof(String));

                foreach (DataRow row in dtRqst.Rows)
                {

                    DataTable dtSer = DSYS.TSYS_EMP_CONF.TSYS_EMP_CONF_SER(UTIL.GetRowToDt(row), bizExecute);

                    if (dtSer.Rows.Count > 0)
                    {
                        DSYS.TSYS_EMP_CONF.TSYS_EMP_CONF_UPD(UTIL.GetRowToDt(row), bizExecute);
                    }
                    else
                    {
                        DSYS.TSYS_EMP_CONF.TSYS_EMP_CONF_INS(UTIL.GetRowToDt(row), bizExecute);
                    }
                }

                DataTable dtRslt = DSYS.TSYS_EMP_CONF.TSYS_EMP_CONF_SER(dtRqst, bizExecute);
                dtRslt.TableName = "RSLTDT";

                DataSet dsRslt = new DataSet();
                dsRslt.Tables.Add(dtRslt);

                return dsRslt;

            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        /// <summary>
        /// 외중 공정 정보를 가져온다
        /// </summary>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        internal static DataTable GetOsProc(BizExecute.BizExecute bizExecute)
        {
            DataTable dtParam = new DataTable("RQSTDT");
            UTIL.SetBizAddColumnToValue(dtParam, "PLT_CODE", ConnInfo.PLT_CODE, typeof(string));
            UTIL.SetBizAddColumnToValue(dtParam, "PROC_CODE", "P14", typeof(string));
            

            return DLSE.LSE_STD_PROC.LSE_STD_PROC_SER(dtParam, bizExecute);
        }

        /// <summary>
        /// 중간검사 공정 정보를 가져온다
        /// </summary>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        internal static DataTable GetMidInsProc(BizExecute.BizExecute bizExecute)
        {
            DataTable dtParam = new DataTable("RQSTDT");
            UTIL.SetBizAddColumnToValue(dtParam, "PLT_CODE", ConnInfo.PLT_CODE, typeof(string));
            UTIL.SetBizAddColumnToValue(dtParam, "PROC_CODE", "P-06", typeof(string));


            return DLSE.LSE_STD_PROC.LSE_STD_PROC_SER(dtParam, bizExecute);
        }

        //사용가능한 출력양식을 알아온다.
        public static DataSet GET_REPORTLIST(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable dtRslt = new DataTable();

                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "IS_USE", 1, typeof(Byte));

                dtRslt = DSYS.TSYS_REPORTLIST_QUERY.TSYS_REPORTLIST_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);

                if (dtRslt.Rows.Count == 0)
                {
                    throw UTIL.SetException("사용가능한 출력양식물이 존재하지않습니다."
                                , new System.Diagnostics.StackFrame().GetMethod().Name
                                , 100005);
                }

                dtRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        /// <summary>
        /// LIST에 존재하는 사용자 환경설정 생성
        /// </summary>
        /// <param name="paramDS"></param>
        /// <param name="bizExecute"></param>
        public static void CREATE_EMP_CONFIG_BY_LIST(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    DataTable dtEmpConfList = DSYS.TSYS_EMP_CONF_LIST.TSYS_EMP_CONF_LIST_SER2(UTIL.GetRowToDt(row), bizExecute);

                    if (dtEmpConfList.Rows.Count != 0)
                    {
                        DataTable dtIns = dtEmpConfList;

                        UTIL.SetBizAddColumnToValue(dtIns, "PLT_CODE", row["PLT_CODE"], typeof(String));
                        UTIL.SetBizAddColumnToValue(dtIns, "EMP_CODE", row["EMP_CODE"], typeof(String));
                        UTIL.SetBizAddColumnToValue(dtIns, "CONF_VALUE", "", typeof(String));

                        for (int i = 0; i < dtIns.Rows.Count; i++)
                        {
                            dtIns.Rows[i]["CONF_VALUE"] = dtIns.Rows[i]["DEF_VALUE"];
                        }

                        DSYS.TSYS_EMP_CONF.TSYS_EMP_CONF_INS(dtIns, bizExecute);
                    }

                }
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        /// <summary>
        /// 사용자 환경설정을 모두 알아온다.
        /// </summary>
        /// <param name="paramDS">PLT_CODE, EMP_CODE </param>
        /// <returns></returns>
        public static DataSet GET_EMP_CONFIG_ALL(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable dtRslt = new DataTable();

                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

                dtRslt = DSYS.TSYS_EMP_CONF_QUERY.TSYS_EMP_CONF_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);

                dtRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRslt);

                return paramDS;

            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        /// <summary>
        /// 사용자 환경설정을 알아온다.
        /// </summary>
        /// <param name="paramDS">PLT_CODE, EMP_CODE, CONF_NAME</param>
        /// <returns></returns>
        public static DataSet GET_EMP_CONFIG(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable dtRslt = new DataTable();

                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

                dtRslt = DSYS.TSYS_EMP_CONF.TSYS_EMP_CONF_SER(paramDS.Tables["RQSTDT"], bizExecute);

                dtRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        /// <summary>
        /// 시스템 환경설정을 알아온다.
        /// </summary>
        /// <param name="paramDS">PLT_CODE, CONF_SECTION, CONF_NAME</param>
        /// <returns></returns>
        public static DataSet GET_SYS_CONFIG(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable dtRslt = new DataTable();

                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

                dtRslt = DSYS.TSYS_CONF.TSYS_CONF_SER(paramDS.Tables["RQSTDT"], bizExecute);

                dtRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }

        /// <summary>
        /// 메뉴 환경설정 데이터를 설정한다.
        /// </summary>
        /// <param name="paramDS">PLT_CODE, MENU_CODE, CONF_NAME, CONF_VALUE, REG_EMP</param>
        public static DataSet SET_MENU_CONFIG(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            //1. TSYS_MENU_CONF_SER
            //2. IF EXISTS(1) TSYS_MENU_CONF_UPD
            //3. ELSE TSYS_MENU_CONF_INS
            try
            {
                DataTable dtRqst = paramDS.Tables["RQSTDT"];
                if (!paramDS.Tables["RQSTDT"].Columns.Contains("MDFY_EMP")) paramDS.Tables["RQSTDT"].Columns.Add("MDFY_EMP", typeof(String));

                foreach (DataRow row in dtRqst.Rows)
                {

                    DataTable dtSer = DSYS.TSYS_MENU_CONF.TSYS_MENU_CONF_SER(UTIL.GetRowToDt(row), bizExecute);

                    if (dtSer.Rows.Count > 0)
                    {
                        DSYS.TSYS_MENU_CONF.TSYS_MENU_CONF_UPD(UTIL.GetRowToDt(row), bizExecute);
                    }
                    else
                    {
                        DSYS.TSYS_MENU_CONF.TSYS_MENU_CONF_INS(UTIL.GetRowToDt(row), bizExecute);
                    }
                }

                DataTable dtRslt = DSYS.TSYS_MENU_CONF.TSYS_MENU_CONF_SER(dtRqst, bizExecute);
                dtRslt.TableName = "RSLTDT";

                DataSet dsRslt = new DataSet();
                dsRslt.Tables.Add(dtRslt);

                return dsRslt;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }

        /// <summary>
        /// 메뉴 환경설정을 알아온다.
        /// </summary>
        /// <returns></returns>
        public static DataSet GET_MENU_CONFIG(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable dtRslt = new DataTable();

                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    dtRslt = DSYS.TSYS_MENU_CONF.TSYS_MENU_CONF_SER(UTIL.GetRowToDt(row), bizExecute);

                    if (dtRslt.Rows.Count == 0)
                    {
                        throw UTIL.SetException("메뉴 환경설정값이 존재하지 않습니다."
                                    , new System.Diagnostics.StackFrame().GetMethod().Name
                                    , 100020);
                    }

                }


                dtRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRslt);

                return paramDS;

            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        /// <summary>
        /// 메뉴 환경설정을 모두 알아온다.
        /// </summary>
        /// <param name="paramDS">PLT_CODE, MENU_CODE</param>
        /// <returns></returns>
        public static DataSet GET_MENU_CONFIG_ALL(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable dtRslt = new DataTable();

                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

                dtRslt = DSYS.TSYS_MENU_CONF_QUERY.TSYS_MENU_CONF_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);

                dtRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRslt);

                return paramDS;

            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        /// <summary>
        /// 시스템 환경설정 데이터를 설정한다.
        /// </summary>
        /// <param name="paramDS">PLT_CODE, CONF_SECTION, CONF_NAME, CONF_VALUE, REG_EMP</param>
        public static DataSet SET_SYS_CONFIG(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            //1. TSYS_CONF_SER
            //2. IF EXISTS(1) TSYS_CONF_UPD
            //3. ELSE TSYS_CONF_INS
            //4. TSYS_CONF_SER
            try
            {
                DataTable dtRqst = paramDS.Tables["RQSTDT"];

                foreach (DataRow row in dtRqst.Rows)
                {

                    DataTable dtSer = DSYS.TSYS_CONF.TSYS_CONF_SER(UTIL.GetRowToDt(row), bizExecute);

                    if (dtSer.Rows.Count > 0)
                    {
                        DSYS.TSYS_CONF.TSYS_CONF_UPD(UTIL.GetRowToDt(row), bizExecute);
                    }
                    else
                    {
                        DSYS.TSYS_CONF.TSYS_CONF_INS(UTIL.GetRowToDt(row), bizExecute);
                    }
                }

                DataTable dtRslt = DSYS.TSYS_CONF.TSYS_CONF_SER(dtRqst, bizExecute);
                dtRslt.TableName = "RSLTDT";

                DataSet dsRslt = new DataSet();
                dsRslt.Tables.Add(dtRslt);

                return dsRslt;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        /// <summary>
        /// 시스템 환경설정을 모두 알아온다.
        /// </summary>
        /// <param name="paramDS">PLT_CODE, CONF_SECTION, CONF_NAME</param>
        /// <returns></returns>
        public static DataSet GET_SYS_CONFIG_ALL(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable dtRslt = new DataTable();

                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

                dtRslt = DSYS.TSYS_CONF_QUERY.TSYS_CONF_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);

                dtRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        /// <summary>
        /// 오류 이력 설정
        /// </summary>
        /// <param name="paramDS">PLT_CODE, SYSTEM_VERSION, CLASS_NAME, ERR_MESSAGE, COMMENT, REG_EMP</param>
        public static void SET_ERROR_LOG(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DSYS.TSYS_ERROR_LOG.TSYS_ERROR_LOG_INS(paramDS.Tables["RQSTDT"], bizExecute);

                DataTable dtBeforeLog = DSYS.TSYS_ERROR_LOG_QUERY.TSYS_ERROR_LOG_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);

                DSYS.TSYS_ERROR_LOG.TSYS_ERROR_LOG_DEL(dtBeforeLog, bizExecute);

            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        /// <summary>
        /// 리소스 정보를 모두 가져온다.
        /// </summary>
        /// <param name="paramDS"></param>
        /// <returns></returns>
        public static DataSet GET_RESOURCE_ALL(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable dtRslt = new DataTable();

                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

                dtRslt = DSYS.TSYS_STRINGTABLE_QUERY.TSYS_STRINGTABLE_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);

                dtRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        /// <summary>
        /// BIZACTOR 오류번호에 해당되는 메시지를 알아온다.
        /// </summary>
        /// <param name="paramDS"></param>
        /// <returns></returns>
        public static DataSet GET_BIZERROR(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable dtRslt = new DataTable();

                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

                dtRslt = DSYS.TSYS_BIZERROR_QUERY.TSYS_BIZERROR_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);

                dtRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        /// <summary>
        /// 서버의 현재 시간을 가져온다.
        /// </summary>
        /// <returns></returns>
        public static DataSet GetDateTimeNow(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                string strQuery = "SELECT GETDATE() AS NOW_DT ";

                DateTime dtNow = DateTime.Now;
                string yyyyMMdd = "", yyyyMMddHHmm = "", yyyyMMddHHmmss = "", yyyyMMddHHmmssfff = "";

                DataTable dt = bizExecute.executeSelectQuery(strQuery);

                if (dt.Rows.Count > 0)
                {
                    dtNow = (DateTime)dt.Rows[0]["NOW_DT"];

                    yyyyMMdd = dtNow.ToString("yyyyMMdd");
                    yyyyMMddHHmm = dtNow.ToString("yyyyMMddHHmm");
                    yyyyMMddHHmmss = dtNow.ToString("yyyyMMddHHmmss");
                    yyyyMMddHHmmssfff = dtNow.ToString("yyyyMMddHHmmssfff");

                }

                DataTable dtResult = new DataTable("RSLTDT");
                dtResult.Columns.Add("DATETIME", typeof(DateTime));
                dtResult.Columns.Add("YYYYMMDD", typeof(String));
                dtResult.Columns.Add("YYYYMMDDHHMM", typeof(String));
                dtResult.Columns.Add("YYYYMMDDHHMMSS", typeof(String));
                dtResult.Columns.Add("YYYYMMDDHHMMSSFFF", typeof(String));

                DataRow paramRow = dtResult.NewRow();
                paramRow["DATETIME"] = dtNow;
                paramRow["YYYYMMDD"] = yyyyMMdd;
                paramRow["YYYYMMDDHHMM"] = yyyyMMddHHmm;
                paramRow["YYYYMMDDHHMMSS"] = yyyyMMddHHmmss;
                paramRow["YYYYMMDDHHMMSSFFF"] = yyyyMMddHHmmssfff;
                dtResult.Rows.Add(paramRow);
                DataSet dsResult = new DataSet();
                dsResult.Tables.Add(dtResult);

                return dsResult;

            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static string GetDateStringWeek(string sTime, BizExecute.BizExecute bizExecute)
        {
            try
            {
                string sDateTime = "";
                sDateTime = sTime.Substring(0, 4) + "-" + sTime.Substring(4, 2) + "-" + sTime.Substring(6, 2);

                DateTime datetime = Convert.ToDateTime(sDateTime);

                var day = datetime.DayOfWeek;
                string week = string.Empty;
                switch (day)
                {
                    case DayOfWeek.Monday:

                        week = "Monday";
                        break;

                    case DayOfWeek.Tuesday:

                        week = "Tuesday";
                        break;

                    case DayOfWeek.Wednesday:

                        week = "Wednesday";
                        break;

                    case DayOfWeek.Thursday:

                        week = "Thursday";
                        break;

                    case DayOfWeek.Friday:

                        week = "Friday";
                        break;

                    case DayOfWeek.Saturday:

                        week = "Saturday";
                        break;

                    case DayOfWeek.Sunday:

                        week = "Sunday";
                        break;
                }

                return week;

            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        /// <summary>
        /// 공정의 가용설비 조회
        /// </summary>
        /// <param name="paramDS">PLT_CODE, PROC_CODE</param>
        /// <returns></returns>
        public static DataSet LOADABLEMC_SEARCH(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable dtRslt = new DataTable();

                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

                dtRslt = DLSE.LSE_STD_AVAILMC_QUERY.LSE_STD_AVAILMC_QUERY4(paramDS.Tables["RQSTDT"], bizExecute);

                dtRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        /// <summary>
        /// 레포트 리스트를 조회한다.
        /// </summary>
        /// <param name="paramDS"></param>
        /// <returns></returns>
        public static DataSet GET_REPORT(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable dtRslt = new DataTable();

                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

                dtRslt = DSYS.TSYS_REPORTLIST.TSYS_REPORTLIST_SER(paramDS.Tables["RQSTDT"], bizExecute);

                dtRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        /// <summary>
        /// 공통컨트롤 사용자 검색
        /// </summary>
        /// <param name="paramDS">PLT_CODE, EMP_CODE, EMP_NAME, DATA_FLAG, AVAILMC, EMP_LIKE, IS_SYSTEM, IS_ORG</param>
        /// <returns></returns>
        public static DataSet EMP_SEARCH(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                //1. 가용설비 입력값이 있으면 TSTD_EMPLOYEE_QUERY5
                //1-1. 없으면 TSTD_EMPLOYEE_QUERY6

                DataRow paramDr = paramDS.Tables["RQSTDT"].Rows[0];

                string availMc = paramDr["AVAILMC"].ToString();

                DataTable dt;
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

                if (availMc != "")
                    dt = DSTD.TSTD_EMPLOYEE_QUERY.TSTD_EMPLOYEE_QUERY5(paramDS.Tables["RQSTDT"], bizExecute);
                else
                    dt = DSTD.TSTD_EMPLOYEE_QUERY.TSTD_EMPLOYEE_QUERY6(paramDS.Tables["RQSTDT"], bizExecute);

                dt.TableName = "RSLTDT";

                DataSet dsRslt = new DataSet();
                dsRslt.Tables.Add(dt);

                return dsRslt;

            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        /// <summary>
        /// 공통컨트롤 거래처 검색
        /// </summary>
        /// <param name="paramDS">PLT_CODE, VEN_CODE, VEN_LIKE, VEN_CAT_CODE, VEN_TYPE, VEN_NAME</param>
        /// <returns></returns>
        public static DataSet VENDOR_SEARCH(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (!paramDS.Tables["RQSTDT"].Columns.Contains("DATA_FLAG"))
                {
                    paramDS.Tables["RQSTDT"].Columns.Add("DATA_FLAG", typeof(Int32));

                    paramDS.Tables["RQSTDT"].Rows[0]["DATA_FLAG"] = 0;
                }

                DataTable dt = DSTD.TSTD_VENDOR_QUERY.TSTD_VENDOR_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);
                dt.TableName = "RSLTDT";

                DataSet dsRslt = new DataSet();
                dsRslt.Tables.Add(dt);


                return dsRslt;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        /// <summary>
        /// 사용자의 회사 정보를 알아온다.
        /// </summary>
        /// <param name="paramDS">PLT_CODE</param>
        /// <returns></returns>
        public static DataSet GET_MYVENDOR(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (!paramDS.Tables["RQSTDT"].Columns.Contains("DATA_FLAG"))
                {
                    paramDS.Tables["RQSTDT"].Columns.Add("DATA_FLAG", typeof(Int32));
                    paramDS.Tables["RQSTDT"].Columns.Add("IS_MYVENDOR", typeof(Int32));

                    paramDS.Tables["RQSTDT"].Rows[0]["DATA_FLAG"] = 0;
                    paramDS.Tables["RQSTDT"].Rows[0]["IS_MYVENDOR"] = 1;
                }

                DataTable dt = DSTD.TSTD_VENDOR_QUERY.TSTD_VENDOR_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);

                DataSet dsRslt = new DataSet();
                dsRslt.Tables.Add(dt);
                dt.TableName = "RSLTDT";

                return dsRslt;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        /// <summary>
        /// 공통컨트롤 TORD_PRODUCT 정보 가져온다.
        /// </summary>
        /// <param name="paramDS"></param>
        /// <returns></returns>
        public static DataSet PROD_SEARCH(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (!paramDS.Tables["RQSTDT"].Columns.Contains("DATA_FLAG"))
                {
                    paramDS.Tables["RQSTDT"].Columns.Add("DATA_FLAG", typeof(Int32));

                    paramDS.Tables["RQSTDT"].Rows[0]["DATA_FLAG"] = 0;
                }

                DataTable dt = DORD.TORD_PRODUCT_QUERY.TORD_PRODUCT_QUERY2(paramDS.Tables["RQSTDT"], bizExecute);

                DataSet dsRslt = new DataSet();
                dsRslt.Tables.Add(dt);
                dt.TableName = "RSLTDT";

                return dsRslt;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        /// <summary>
        /// 표준코드 조회
        /// </summary>
        /// <param name="paramDS">PLT_CODE, CAT_CODE, CD_CODE, CD_PARENT, CD_NAME</param>
        /// <returns></returns>
        public static DataSet GET_STDCODES(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable dt = DSTD.TSTD_CODES_QUERY.TSTD_CODES_QUERY8(paramDS.Tables["RQSTDT"], bizExecute);

                DataSet dsRslt = new DataSet();
                dsRslt.Tables.Add(dt);
                dt.TableName = "RSLTDT";

                return dsRslt;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        /// <summary>
        /// 표준공정 조회
        /// </summary>
        /// <param name="paramDS"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataSet GET_STDPROCS(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                
                DataTable dt = DLSE.LSE_STD_PROC_QUERY.LSE_STD_PROC_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);

                DataSet dsRslt = new DataSet();
                dsRslt.Tables.Add(dt);
                dt.TableName = "RSLTDT";

                return dsRslt;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        /// <summary>
        /// 비밀번호 변경
        /// </summary>
        /// <param name="paramDS"></param>
        /// <param name="bizExecute"></param>
        public static void CHANGE_PASSWORD(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable dtParam = paramDS.Tables["RQSTDT"];

                if (dtParam.Rows.Count > 0)
                {
                    if (!dtParam.Rows[0]["NEW_PASSWORD"].Equals(dtParam.Rows[0]["NEW_PASSWORD_CFM"]))
                    {
                        throw UTIL.SetException("새 비밀번호와 새 비밀번호 확인이 일치하지 않습니다."
                                    , new System.Diagnostics.StackFrame().GetMethod().Name
                                    , 200058);

                    }
                    else
                    {
                        DataTable dt = DSTD.TSTD_EMPLOYEE.TSTD_EMPLOYEE_SER(bizExecute);

                        if (!dt.Rows[0]["ACC_PWD"].Equals(dtParam.Rows[0]["OLD_PASSWORD"]))
                        {
                            throw UTIL.SetException("기존 비밀번호가 일치하지 않습니다."
                                    , new System.Diagnostics.StackFrame().GetMethod().Name
                                    , 200057);
                        }

                        DSTD.TSTD_EMPLOYEE.TSTD_EMPLOYEE_UPD3(dtParam, bizExecute);

                    }

                }
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        /// <summary>
        /// 버튼 동작 로그
        /// </summary>
        /// <param name="paramDS">PLT_CODE, SYSTEM_VERSION, CLASS_NAME, ERR_MESSAGE, COMMENT, REG_EMP</param>
        public static void ACTIVE_BUTTON_LOG(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DSYS.TSYS_BUTTON_ACTION_LOG.TSYS_BUTTON_ACTION_LOG_INS(paramDS.Tables["RQSTDT"], bizExecute);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        //SYS07A_DEL3
        public static void SYS07A_DEL3(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {

            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }
        /// <summary>
        /// 첨부파일 조회
        /// </summary>
        /// <param name="paramDS"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataSet ATTACH_FILE_MASTER_SER(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {

                if (paramDS.Tables["RQSTDT"].Rows.Count <= 0) return null;

                DataTable dtRslt = DSYS.TSYS_FILELIST_MASTER_QUERY.TSYS_FILELIST_MASTER_QUERY2(paramDS.Tables["RQSTDT"], bizExecute);

                DataTable dtRslt2 = DSYS.TSYS_FILELIST_MASTER_QUERY.TSYS_FILELIST_MASTER_QUERY3(paramDS.Tables["RQSTDT"], bizExecute);

                if (!dtRslt.Columns.Contains("SEL")) dtRslt.Columns.Add("SEL", typeof(String));
                if (!dtRslt2.Columns.Contains("SEL")) dtRslt2.Columns.Add("SEL", typeof(String));

                DataSet dsResult = new DataSet();
                dtRslt.TableName = "RSLTDT";
                dtRslt2.TableName = "RSLTDT2";

                dsResult.Tables.Add(dtRslt.Copy());
                dsResult.Tables.Add(dtRslt2.Copy());

                return dsResult;

            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }


        public static DataSet ATTACH_FILE_MASTER_SER2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (paramDS.Tables["RQSTDT"].Rows.Count <= 0) return null;

                DataTable dtRslt = DSYS.TSYS_FILELIST_MASTER.TSYS_FILELIST_MASTER_SER(paramDS.Tables["RQSTDT"], bizExecute);

                DataSet dsResult = new DataSet();
                dsResult.Tables.Add(dtRslt);

                dtRslt.TableName = "RSLTDT";

                return dsResult;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet ATTACH_FILE_MASTER_SER3(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (paramDS.Tables["RQSTDT"].Rows.Count <= 0) return null;

                paramDS.Tables["RQSTDT"].Columns.Add("IS_UPLOAD", typeof(Int32));
                paramDS.Tables["RQSTDT"].Columns.Add("DATA_FLAG", typeof(Int32));

                paramDS.Tables["RQSTDT"].Rows[0]["IS_UPLOAD"] = 1;
                paramDS.Tables["RQSTDT"].Rows[0]["DATA_FLAG"] = 0;

                DataTable dtRslt = DSYS.TSYS_FILELIST_MASTER_QUERY.TSYS_FILELIST_MASTER_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);

                DataSet dsResult = new DataSet();
                dsResult.Tables.Add(dtRslt);

                dtRslt.TableName = "RSLTDT";

                return dsResult;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        /// <summary>
        /// 첨부파일 이름 권한 확인
        /// </summary>
        /// <param name="paramDS"></param>
        public static void ATTACH_FILE_MASTER_SER4(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (paramDS.Tables["RQSTDT"].Rows.Count < 1) return;

                DataTable dtFile = DSYS.TSYS_FILELIST_MASTER.TSYS_FILELIST_MASTER_SER(paramDS.Tables["RQSTDT"], bizExecute);

                if (dtFile.Rows.Count > 0)
                {
                    if (!dtFile.Rows[0]["REG_EMP"].Equals(paramDS.Tables["RQSTDT"].Rows[0]["REG_EMP"]))
                    {
                        throw UTIL.SetException("해당 파일을 올린 사용자만 수정하거나 삭제할 수 있습니다."
                                    , dtFile.Rows[0]["FILE_NAME"].ToString()
                                    , new System.Diagnostics.StackFrame().GetMethod().Name
                                    , BizException.CHECK_DEL_AUTH);

                    }
                    else
                        return;
                }
                else
                    throw UTIL.SetException("이미 처리되거나 유효하지 않은 데이터입니다."
                                , new System.Diagnostics.StackFrame().GetMethod().Name
                                , BizException.UNVALID_DATA);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        /// <summary>
        /// 파일첨부 마스터 정보를 임시로 올린다.
        /// </summary>
        /// <param name="paramDS"></param>
        public static DataSet ATTACH_FILE_MASTER_INS_T(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (paramDS.Tables["RQSTDT"].Rows.Count < 1) return null;

                DataTable dtNow = UTIL.UTILITY_GET_DTNOW(bizExecute);
                string dt = ((DateTime)dtNow.Rows[0]["NOW_DT"]).ToString("yyyy-MM-dd HH:mm:ss");

                if (!paramDS.Tables["RQSTDT"].Columns.Contains("FILE_ID"))
                    paramDS.Tables["RQSTDT"].Columns.Add("FILE_ID", typeof(String));
                if (!paramDS.Tables["RQSTDT"].Columns.Contains("IS_UPLOAD"))
                    paramDS.Tables["RQSTDT"].Columns.Add("IS_UPLOAD", typeof(Int32));
                if (!paramDS.Tables["RQSTDT"].Columns.Contains("ACC_LEVEL"))
                    paramDS.Tables["RQSTDT"].Columns.Add("ACC_LEVEL", typeof(String));
                if (!paramDS.Tables["RQSTDT"].Columns.Contains("REG_DATE"))
                    paramDS.Tables["RQSTDT"].Columns.Add("REG_DATE", typeof(String));
                if (!paramDS.Tables["RQSTDT"].Columns.Contains("DATA_FLAG"))
                    paramDS.Tables["RQSTDT"].Columns.Add("DATA_FLAG", typeof(Int32));

                DataRow row = paramDS.Tables["RQSTDT"].Rows[0];

                //파일 id 시리얼 번호 취득
                row["FILE_ID"] = UTIL.UTILITY_GET_SERIALNO(row["PLT_CODE"].ToString(), "FL", bizExecute);

                row["IS_UPLOAD"] = 0;
                row["ACC_LEVEL"] = "I";
                row["REG_DATE"] = dt;
                row["DATA_FLAG"] = 0;

                DSYS.TSYS_FILELIST_MASTER.TSYS_FILELIST_MASTER_INS(paramDS.Tables["RQSTDT"], bizExecute);

                DataTable dtParam = ExtensionMethod.CreateSchema("RQSTDT", new string[] { "PLT_CODE", "FILE_ID" }, new Type[] { typeof(String), typeof(String) });

                DataRow dtRow = dtParam.NewRow();
                dtRow["PLT_CODE"] = row["PLT_CODE"];
                dtRow["FILE_ID"] = row["FILE_ID"];
                dtParam.Rows.Add(dtRow);

                DataTable dtResult = DSYS.TSYS_FILELIST_MASTER.TSYS_FILELIST_MASTER_SER(dtParam, bizExecute);

                DataTable dtRqst = new DataTable("RQSTDT");
                dtRqst = paramDS.Tables["RQSTDT"].Copy();

                DataSet dsResult = new DataSet();

                dsResult.Tables.Add(dtResult);
                dsResult.Tables.Add(dtRqst);

                return dsResult;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        /// <summary>
        /// 첨부파일 접근 권한 변경
        /// </summary>
        /// <param name="paramDS"></param>
        public static void ATTACH_FILE_MASTER_UPD2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable dtNow = UTIL.UTILITY_GET_DTNOW(bizExecute);
                string dt = ((DateTime)dtNow.Rows[0]["NOW_DT"]).ToString("yyyy-MM-dd HH:mm:ss");

                if (paramDS.Tables["RQSTDT"].Rows.Count < 1) return;

                if (!paramDS.Tables["RQSTDT"].Columns.Contains("MDFY_DATE"))
                    paramDS.Tables["RQSTDT"].Columns.Add("MDFY_DATE", typeof(String));

                DataTable dtFile = DSYS.TSYS_FILELIST_MASTER.TSYS_FILELIST_MASTER_SER(paramDS.Tables["RQSTDT"], bizExecute);

                if (dtFile.Rows.Count > 0)
                {
                    if (dtFile.Rows[0]["DATA_FLAG"].ToString() == "0" &&
                        dtFile.Rows[0]["REG_EMP"].Equals(paramDS.Tables["RQSTDT"].Rows[0]["MDFY_EMP"]))
                    {
                        paramDS.Tables["RQSTDT"].Rows[0]["MDFY_DATE"] = dt;
                        DSYS.TSYS_FILELIST_MASTER.TSYS_FILELIST_MASTER_UPD3(paramDS.Tables["RQSTDT"], bizExecute);
                    }
                    else
                        throw UTIL.SetException("이미 처리되거나 유효하지 않은 데이터입니다."
                                , new System.Diagnostics.StackFrame().GetMethod().Name
                                , BizException.UNVALID_DATA);
                }
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        /// <summary>
        /// 첨부파일 이름 변경
        /// </summary>
        /// <param name="paramDS"></param>
        public static DataSet ATTACH_FILE_MASTER_UPD(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (paramDS.Tables["RQSTDT"].Rows.Count < 1) return null;

                DataSet dsResult = new DataSet();

                if (!paramDS.Tables["RQSTDT"].Columns.Contains("MDFY_DATE"))
                    paramDS.Tables["RQSTDT"].Columns.Add("MDFY_DATE", typeof(String));

                DataTable dtFile = DSYS.TSYS_FILELIST_MASTER.TSYS_FILELIST_MASTER_SER(paramDS.Tables["RQSTDT"], bizExecute);

                if (dtFile.Rows.Count > 0)
                {
                    if (dtFile.Rows[0]["DATA_FLAG"].ToString() == "0" &&
                        dtFile.Rows[0]["REG_EMP"].Equals(paramDS.Tables["RQSTDT"].Rows[0]["MDFY_EMP"]))
                    {
                        DSYS.TSYS_FILELIST_MASTER.TSYS_FILELIST_MASTER_UPD(paramDS.Tables["RQSTDT"], bizExecute);
                    }
                    else
                    {
                        throw UTIL.SetException("이미 처리되거나 유효하지 않은 데이터입니다."
                                , new System.Diagnostics.StackFrame().GetMethod().Name
                                , BizException.UNVALID_DATA);
                    }
                }

                return dsResult;

            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        /// <summary>
        /// 순서변경
        /// </summary>
        /// <param name="paramDS"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataSet ATTACH_FILE_MASTER_UPD3(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (!paramDS.Tables["RQSTDT"].Columns.Contains("MDFY_DATE"))
                    paramDS.Tables["RQSTDT"].Columns.Add("MDFY_DATE", typeof(String));

                DSYS.TSYS_FILELIST_MASTER.TSYS_FILELIST_MASTER_UPD5(paramDS.Tables["RQSTDT"], bizExecute);
                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        /// <summary>
        /// 구분코드 변경
        /// </summary>
        /// <param name="paramDS"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataSet ATTACH_FILE_MASTER_UPD4(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (!paramDS.Tables["RQSTDT"].Columns.Contains("MDFY_DATE"))
                    paramDS.Tables["RQSTDT"].Columns.Add("MDFY_DATE", typeof(String));

                DSYS.TSYS_FILELIST_MASTER.TSYS_FILELIST_MASTER_UPD4(paramDS.Tables["RQSTDT"], bizExecute);
                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        /// <summary>
        /// 첨부파일 삭제
        /// </summary>
        /// <param name="paramDS"></param>
        public static void ATTACH_FILE_MASTER_DEL(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (paramDS.Tables["RQSTDT"].Rows.Count < 1) return;

                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "EMP_CODE", paramDS.Tables["RQSTDT"].Rows[0]["DEL_EMP"].ToString(), typeof(string));

                DataTable dtFile = DSYS.TSYS_FILELIST_MASTER.TSYS_FILELIST_MASTER_SER(paramDS.Tables["RQSTDT"], bizExecute);

                DataTable dtConf = DSYS.TSYS_CONF.TSYS_CONF_SER(paramDS.Tables["RQSTDT"], bizExecute);

                DataTable dtEmp = DSTD.TSTD_EMPLOYEE.TSTD_EMPLOYEE_SER(paramDS.Tables["RQSTDT"], bizExecute);

                if (dtFile.Rows.Count > 0)
                {
                    foreach (DataRow dr in dtFile.Rows)
                    {
                        if ((dr["DATA_FLAG"].ToString() == "0" &&
                            dr["REG_EMP"].Equals(paramDS.Tables["RQSTDT"].Rows[0]["DEL_EMP"]))
                            || dtConf.Rows[0]["CONF_VALUE"].Equals(dtEmp.Rows[0]["USRGRP_CODE"]))
                        {
                            DSYS.TSYS_FILELIST_MASTER.TSYS_FILELIST_MASTER_UDE(paramDS.Tables["RQSTDT"], bizExecute);
                        }
                        else
                        {
                            throw UTIL.SetException("해당 파일을 올린 사용자만 수정하거나 삭제할 수 있습니다."
                                    , dr["FILE_NAME"].ToString()
                                    , new System.Diagnostics.StackFrame().GetMethod().Name
                                    , BizException.CHECK_DEL_AUTH);
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
        /// 업로드 중 전송취소 마스터 삭제
        /// </summary>
        /// <param name="paramDS"></param>
        public static void ATTACH_FILE_MASTER_DEL2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {

                if (paramDS.Tables["RQSTDT"].Rows.Count < 1) return;
                DSYS.TSYS_FILELIST_MASTER.TSYS_FILELIST_MASTER_DEL(paramDS.Tables["RQSTDT"], bizExecute);

                //*******************물리적 파일 삭제*********************************//


            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name); ;
            }
        }

        /// <summary>
        /// 파일 전송 완료시 정보 업데이트
        /// </summary>
        /// <param name="paramDS"></param>
        public static void ATTACH_FILE_MASTER_COMPLETE(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable dtNow = UTIL.UTILITY_GET_DTNOW(bizExecute);
                string dt = ((DateTime)dtNow.Rows[0]["NOW_DT"]).ToString("yyyy-MM-dd HH:mm:ss");

                if (paramDS.Tables["RQSTDT"].Rows.Count < 1) return;

                paramDS.Tables["RQSTDT"].Columns.Add("IS_UPLOAD", typeof(Int32));

                paramDS.Tables["RQSTDT"].Rows[0]["IS_UPLOAD"] = 1;

                DSYS.TSYS_FILELIST_MASTER.TSYS_FILELIST_MASTER_UPD2(paramDS.Tables["RQSTDT"], bizExecute);

            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }

        /// <summary>
        /// acEmp
        /// </summary>
        /// <param name="paramDS"></param>
        public static DataSet CONTROL_EMP_SEARCH(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable dtRslt = new DataTable();
                //가용설비 입력값이 있으면
                //if(paramDS.Tables["RQSTDT"].Rows[0]["AVAILMC"] == null)
                if (UTIL.ValidColumn(paramDS.Tables["RQSTDT"].Rows[0], "AVAILMC"))
                {
                    dtRslt = DSTD.TSTD_EMPLOYEE_QUERY.TSTD_EMPLOYEE_QUERY5(paramDS.Tables["RQSTDT"], bizExecute);
                }
                else//가용설비 입력값이 없으면
                {
                    dtRslt = DSTD.TSTD_EMPLOYEE_QUERY.TSTD_EMPLOYEE_QUERY6(paramDS.Tables["RQSTDT"], bizExecute);
                }

                dtRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }



        /// <summary>
        /// acPart
        /// </summary>
        /// <param name="paramDS"></param>
        public static DataSet CONTROL_PART_SEARCH(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

                DataTable dtRslt = DLSE.LSE_STD_PART_QUERY.LSE_STD_PART_QUERY2(paramDS.Tables["RQSTDT"], bizExecute);
                if (!dtRslt.Columns.Contains("SEL")) dtRslt.Columns.Add("SEL", typeof(String));

                //DataTable dtRslt_Ven = DLSE.LSE_STD_PART.LSE_STD_PART_SER3(paramDS.Tables["RQSTDT"], bizExecute);

                //if (dtRslt_Ven.Rows.Count > 0 && dtRslt.Rows.Count > 0)
                //{
                //    var temp = dtRslt.AsEnumerable().Join(dtRslt_Ven.AsEnumerable()
                //                             , dt => dt["PART_CODE"]
                //                             , dtVen => dtVen["PART_CODE"]
                //                             , (dt, dtVen) => dt);

                //    DataTable dtJoin = temp.CopyToDataTable();

                //    dtJoin.TableName = "RSLTDT";

                //    paramDS.Tables.Add(dtJoin);
                //}
                //else
                //{
                //    dtRslt.TableName = "RSLTDT";

                //    paramDS.Tables.Add(dtRslt);
                //}
                dtRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }




        /// <summary>
        /// acORG/공통컨트롤(부서)
        /// </summary>
        /// <param name="paramDS"></param>
        public static DataSet CONTROL_ORG_SEARCH(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable dtRslt = new DataTable();

                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

                dtRslt = DSTD.TSTD_ORG_QUERY.TSTD_ORG_QUERY2(paramDS.Tables["RQSTDT"], bizExecute);

                dtRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }

        /// <summary>
        /// acUserGrp/공통컨트롤(사용자그룹)
        /// </summary>
        /// <param name="paramDS"></param>
        public static DataSet CONTROL_USRGRP_SEARCH(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable dtRslt = new DataTable();

                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

                dtRslt = DSYS.TSYS_USERGRP_QUERY.TSYS_USERGRP_QUERY2(paramDS.Tables["RQSTDT"], bizExecute);

                dtRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }


        /// <summary>
        /// acMachine / 설비
        /// </summary>
        /// <param name="paramDS"></param>
        public static DataSet CONTROL_MACHINE_SEARCH(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable dtRslt = new DataTable();

                dtRslt = DLSE.LSE_MACHINE_QUERY.LSE_MACHINE_QUERY2(paramDS.Tables["RQSTDT"], bizExecute);

                dtRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }

        /// <summary>
        /// acMachineForm / 설비
        /// </summary>
        /// <param name="paramDS"></param>
        public static DataSet CONTROL_AVAILMACHINE_SEARCH(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable dtRslt = new DataTable();

                dtRslt = DLSE.LSE_STD_AVAILMC_QUERY.LSE_STD_AVAILMC_QUERY3(paramDS.Tables["RQSTDT"], bizExecute);

                dtRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }

        public static DataSet CONTROL_ACTUAL_SEARCH(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable dtRslt = new DataTable();

                dtRslt = DSHP.TSHP_ACTUAL_QUERY.TSHP_ACTUAL_QUERY2(paramDS.Tables["RQSTDT"], bizExecute);
                dtRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }


        /// <summary>
        /// acPlanForm / 설비
        /// </summary>
        /// <param name="paramDS"></param>
        public static DataSet CONTROL_PLAN_SEARCH(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable dtRslt = new DataTable();

                //dtRslt = DLSE.LSE_STD_AVAILMC_QUERY.LSE_STD_AVAILMC_QUERY3(paramDS.Tables["RQSTDT"], bizExecute);

                dtRslt = DSTD.TSTD_PROCGRP_QUERY.TSTD_PROCGRP_QUERY3(paramDS.Tables["RQSTDT"], bizExecute);

                dtRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }

        /// <summary>
        /// 도구 찾기
        /// </summary>
        /// <param name="paramDS"></param>
        public static DataSet CONTROL_TOOL_SEARCH(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable dtRslt = new DataTable();
                dtRslt = DSTD.TSTD_TOOL_QUERY.TSTD_TOOL_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);
                dtRslt.TableName = "RSLTDT";
                paramDS.Tables.Add(dtRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }

        /// <summary>
        /// 도구 찾기
        /// </summary>
        /// <param name="paramDS"></param>
        public static DataSet CONTROL_TOOL_LOT_SEARCH(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable dtRslt = new DataTable();
                dtRslt = DSTD.TSTD_TOOL_QUERY.TSTD_TOOL_QUERY3(paramDS.Tables["RQSTDT"], bizExecute);

                dtRslt.TableName = "RSLTDT";
                paramDS.Tables.Add(dtRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }

        /// <summary>
        /// acMenulist  
        /// </summary>
        /// <param name="paramDS"></param>
        public static DataSet CONTROL_MENU_SEARCH(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {

                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "USE_FLAG", 1, typeof(Byte));
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "APP_ID", "Active#", typeof(String));
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "IS_SYS_MENU", 0, typeof(Byte));

                DataTable dtSerVer = DSYS.TSYS_VERSION.TSYS_VERSION_SER(paramDS.Tables["RQSTDT"], bizExecute);

                if (dtSerVer.Rows.Count == 0)
                {
                    throw UTIL.SetException("시스템 버전정보가 존재하지 않습니다."
                                    , new System.Diagnostics.StackFrame().GetMethod().Name
                                    , 100023);
                }

                if (dtSerVer.Rows[0]["TYPE"].ToString() == "Standard")
                {
                    UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "STD_MENU", "1", typeof(String));
                }
                else if (dtSerVer.Rows[0]["TYPE"].ToString() == "Professional")
                {
                    UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "PRO_MENU", "1", typeof(String));
                }

                DataTable dtRslt = new DataTable();

                dtRslt = DSYS.TSYS_MENULIST_QUERY.TSYS_MENULIST_QUERY4(paramDS.Tables["RQSTDT"], bizExecute);

                dtRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }

        /// <summary>
        /// acVendorCharge
        /// </summary>
        /// <param name="paramDS"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataSet CONTROL_VENDOR_CHARGE_SEARCH(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable dtRslt = new DataTable();

                dtRslt = DSTD.TSTD_VENDOR_CHARGE.TSTD_VENDOR_CHARGE_SER(paramDS.Tables["RQSTDT"], bizExecute);
                dtRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }
        /// <summary>
        /// 메뉴권한 반환 
        /// </summary>
        /// <param name="paramDS"></param>
        public static DataSet GET_MENU_AUTHORITY(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {

                DataTable dtRslt = new DataTable();
                dtRslt.Columns.Add("PLT_CODE", typeof(String));
                dtRslt.Columns.Add("MENU_CODE", typeof(String));
                dtRslt.Columns.Add("EMP_CODE", typeof(String));
                dtRslt.Columns.Add("RESULT", typeof(Int32));

                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    DataTable dtSerEmp = DSTD.TSTD_EMPLOYEE.TSTD_EMPLOYEE_SER(UTIL.GetRowToDt(row), bizExecute);
                    //사용자 정보 유무
                    if (dtSerEmp.Rows.Count > 0)
                    {
                        //사용자 정보 삭제 여부
                        if (!dtSerEmp.Rows[0]["DATA_FLAG"].Equals((byte)2))
                        {
                            UTIL.SetBizAddColumnToValue(UTIL.GetRowToDt(row), "", dtSerEmp.Rows[0]["USRGRP_CODE"].ToString());
                            DataTable dtSerAcc = DSYS.TSYS_ACCESS.TSYS_ACCESS_SER(UTIL.GetRowToDt(row), bizExecute);

                            if (dtSerAcc.Rows.Count > 0)
                            {
                                if (dtSerAcc.Rows[0]["ACC_LEVEL"].Equals("1"))
                                {
                                    //권한데이터 없음
                                    DataRow newRow = dtRslt.NewRow();
                                    newRow["PLT_CODE"] = row["PLT_CODE"];
                                    newRow["MENU_CODE"] = row["MENU_CODE"];
                                    newRow["EMP_CODE"] = row["EMP_CODE"];
                                    newRow["RESULT"] = 100010;
                                    dtRslt.Rows.Add(newRow);

                                }
                                else
                                {

                                    DataRow newRow = dtRslt.NewRow();
                                    newRow["PLT_CODE"] = row["PLT_CODE"];
                                    newRow["MENU_CODE"] = row["MENU_CODE"];
                                    newRow["EMP_CODE"] = row["EMP_CODE"];
                                    newRow["RESULT"] = 1;
                                    dtRslt.Rows.Add(newRow);

                                }
                            }
                            else
                            {
                                //권한데이터 없음
                                DataRow newRow = dtRslt.NewRow();
                                newRow["PLT_CODE"] = row["PLT_CODE"];
                                newRow["MENU_CODE"] = row["MENU_CODE"];
                                newRow["EMP_CODE"] = row["EMP_CODE"];
                                newRow["RESULT"] = 100010;
                                dtRslt.Rows.Add(newRow);

                            }
                        }
                        else
                        {
                            //사용자 계정 없음
                            DataRow newRow = dtRslt.NewRow();
                            newRow["PLT_CODE"] = row["PLT_CODE"];
                            newRow["MENU_CODE"] = row["MENU_CODE"];
                            newRow["EMP_CODE"] = row["EMP_CODE"];
                            newRow["RESULT"] = 100009;
                            dtRslt.Rows.Add(newRow);
                        }

                    }
                    else
                    {
                        //사용자 계정 없음
                        DataRow newRow = dtRslt.NewRow();
                        newRow["PLT_CODE"] = row["PLT_CODE"];
                        newRow["MENU_CODE"] = row["MENU_CODE"];
                        newRow["EMP_CODE"] = row["EMP_CODE"];
                        newRow["RESULT"] = 100009;
                        dtRslt.Rows.Add(newRow);
                    }

                }

                dtRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }


        /// <summary>
        /// acProc  
        /// </summary>
        /// <param name="paramDS"></param>
        public static DataSet CONTROL_PROC_SEARCH(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {

                DataTable dtRslt = new DataTable();

                dtRslt = DLSE.LSE_STD_PROC_QUERY.LSE_STD_PROC_QUERY2(paramDS.Tables["RQSTDT"], bizExecute);

                dtRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }

        /// <summary>
        /// acVendor  
        /// </summary>
        /// <param name="paramDS"></param>
        public static DataSet CONTROL_VENDOR_SEARCH(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {

                DataTable dtRslt = new DataTable();

                dtRslt = DSTD.TSTD_VENDOR_QUERY.TSTD_VENDOR_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);

                dtRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }

        public static DataSet CONTROL_BILL_VENDOR_SEARCH(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {

                DataTable dtRslt = new DataTable();

                dtRslt = DSTD.TSTD_BILL_VENDOR_QUERY.TSTD_BILL_VENDOR_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);

                dtRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }

        public static DataSet CONTROL_FIELD_SEARCH(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {

                DataTable dtRslt = new DataTable();

                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

                dtRslt = DSTD.TSTD_FIELD_QUERY.TSTD_FIELD_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);

                dtRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }

        public static DataSet CONTROL_PRJ_SEARCH(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {

                DataTable dtRslt = new DataTable();

                //UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

                dtRslt = DORD.TORD_PROJECT_QUERY.TORD_PROJECT_QUERY2(paramDS.Tables["RQSTDT"], bizExecute);

                dtRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }

        public static DataSet CONTROL_ITEM_SEARCH(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {

                DataTable dtRslt = new DataTable();

                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

                dtRslt = DORD.TORD_ITEM_QUERY.TORD_ITEM_QUERY2(paramDS.Tables["RQSTDT"], bizExecute);

                dtRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }


        public static DataSet CONTROL_PROD_SEARCH(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {

                DataTable dtRslt = new DataTable();

                //UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

                dtRslt = DORD.TORD_PRODUCT_QUERY.TORD_PRODUCT_QUERY2(paramDS.Tables["RQSTDT"], bizExecute);

                dtRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }

        public static DataSet CONTROL_WORKORDER_SEARCH(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));
                
                DataTable dtProdRslt = DSHP.TSHP_WORKORDER_QUERY.TSHP_WORKORDER_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);

                dtProdRslt.TableName = "RSLTDT";

                DataSet dsRslt = new DataSet();
                dsRslt.Merge(dtProdRslt);

                return dsRslt;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        /// <summary>
        /// 설비 이미지 변경
        /// </summary>
        /// <param name="paramDS"></param>
        /// <param name="bizExecute"></param>
        public static void MC_IMG_SAVE(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable dtParam = paramDS.Tables["RQSTDT"];

                if (dtParam.Rows.Count > 0)
                {
                    DLSE.LSE_MACHINE.LSE_MACHINE_SETIMG(dtParam, bizExecute);
                }
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }


        /// <summary>
        /// acWageRate/공통컨트롤(임율)
        /// </summary>
        /// <param name="paramDS"></param>
        public static DataSet CONTROL_WAGERATE_SEARCH(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable dtRslt = new DataTable();

                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

                dtRslt = DCST.TCST_UNIT_COST_MASTER_QUERY.TCST_UNIT_COST_MASTER_QUERY4(paramDS.Tables["RQSTDT"], bizExecute);

                dtRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }
        /// <summary>
        /// acMaterial/공통컨트롤(재질)
        /// </summary>
        /// <param name="paramDS"></param>
        public static DataSet CONTROL_MQLTY_SEARCH(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable dtRslt = new DataTable();

                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

                dtRslt = DMAT.TMAT_QUC_MASTER_QUERY.TMAT_QUC_MASTER_QUERY2(paramDS.Tables["RQSTDT"], bizExecute);

                dtRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }

        /// <summary>
        /// 구매프로세스 신청시 참조되는 부품을 생성한다.
        /// </summary>
        /// <param name="paramDS"></param>
        public static void CREATE_PUR_PART(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    DataTable dtPtRslt = DMAT.TMAT_PARTLIST.TMAT_PARTLIST_SER(UTIL.GetRowToDt(row), bizExecute);

                    if (dtPtRslt.Rows.Count != 0)
                    {
                        UTIL.SetBizAddColumnToValue(dtPtRslt, "PLT_CODE", row["PLT_CODE"], typeof(String));
                        UTIL.SetBizAddColumnToValue(dtPtRslt, "REQUEST_NO", row["REQUEST_NO"], typeof(String));
                        UTIL.SetBizAddColumnToValue(dtPtRslt, "REQUEST_SEQ", row["REQUEST_SEQ"], typeof(int));
                        UTIL.SetBizAddColumnToValue(dtPtRslt, "PT_ID", row["PT_ID"], typeof(int));

                        DMAT.TMAT_PUR_PARTLIST.TMAT_PUR_PARLIST_INS(dtPtRslt, bizExecute);
                    }
                    else
                    {
                        throw UTIL.SetException("이미처리되거나 유효하지 않는 데이터입니다. 새로고침합니다."
                                    , new System.Diagnostics.StackFrame().GetMethod().Name
                                    , BizException.UNVALID_DATA);
                        
                    }
                }

            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        /// <summary>
        /// 자신이 신청한 자재구매 알림 생성
        /// </summary>
        /// <param name="paramDS"></param>
        public static void CREATE_PUR_M_SELF_NOTIFY(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                string TYPE = "E";
                string CONF_NAME = "NOTIFY_SELF_M_PUR_EVENT";
                string PUR_TYPE = "M";
                string TITLE = "";
                string MESSAGE = "";
                string SEARCH_KEY = "";
                string REQ_MENU_CODE = "PUR50A";
                string BAL_MENU_CODE = "PUR53A";
                string MENU_CODE = "";

                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    //알림 대상자와 등록자가 다를경우만
                    if(!object.Equals(row["EMP_CODE"],row["REG_EMP"]))
                    {
                        if (object.Equals(row["PUR_NO_TYPE"], "REQ"))
                        {
                            MENU_CODE = REQ_MENU_CODE;
                        }
                        else if (object.Equals(row["PUR_NO_TYPE"], "BAL"))
                        {
                            MENU_CODE = BAL_MENU_CODE;
                        }

                        TITLE = string.Format("%&S(S043,{0})%(%&S(S047,{1})%)", row["PUR_STAT"].ToString(), PUR_TYPE);


                        if (row["PUR_SEQ"] != DBNull.Value)
                        {
                            SEARCH_KEY = string.Format("{0},{1},{2}", PUR_TYPE, row["PUR_NO"].ToString(), row["PUR_SEQ"].ToString());

                            MESSAGE = string.Format("{0}-{1}", row["PUR_NO"].ToString(), row["PUR_SEQ"].ToString());
                        }
                        else
                        {
                            SEARCH_KEY = string.Format("{0},{1}", PUR_TYPE, row["PUR_NO"].ToString());

                            MESSAGE = row["PUR_NO"].ToString();
                        }


                            DataTable paramTable = new DataTable("PURCHASE");
                            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                            paramTable.Columns.Add("TYPE", typeof(String)); //
                            paramTable.Columns.Add("KEY", typeof(String)); //
                            paramTable.Columns.Add("TITLE", typeof(String)); //
                            paramTable.Columns.Add("MESSAGE", typeof(String)); //
                            paramTable.Columns.Add("VAR", typeof(String)); //
                            paramTable.Columns.Add("MENU_CODE", typeof(String)); //
                            paramTable.Columns.Add("SEARCH_KEY", typeof(String)); //
                            paramTable.Columns.Add("REG_EMP", typeof(String)); //

                            DataRow paramRow = paramTable.NewRow();
                            paramRow["PLT_CODE"] = row["PLT_CODE"];
                            paramRow["TYPE"] = TYPE;
                            paramRow["KEY"] = row["EMP_CODE"];
                            paramRow["TITLE"] = TITLE;
                            paramRow["MESSAGE"] = MESSAGE;
                            paramRow["VAR"] = CONF_NAME;
                            paramRow["MENU_CODE"] = MENU_CODE;
                            paramRow["SEARCH_KEY"] = SEARCH_KEY;
                            paramRow["REG_EMP"] = row["REG_EMP"];
                                                                
                            paramTable.Rows.Add(paramRow);

                            CTRL.CREATE_NOTIFY(UTIL.GetDtToDs(paramTable), bizExecute);
                    }
                }
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        /// <summary>
        /// 자신이 신청한 자재구매 알림 생성
        /// </summary>
        /// <param name="paramDS"></param>
        public static void CREATE_PUR_PO_SELF_NOTIFY(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                string TYPE = "E";
                string CONF_NAME = "NOTIFY_SELF_PO_PUR_EVENT";
                string PUR_TYPE = "PO";
                string TITLE = "";
                string MESSAGE = "";
                string SEARCH_KEY = "";
                string REQ_MENU_CODE = "PUR50A";
                string BAL_MENU_CODE = "PUR53A";
                string MENU_CODE = "";

                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    //알림 대상자와 등록자가 다를경우만
                    if (!object.Equals(row["EMP_CODE"], row["REG_EMP"]))
                    {
                        if (object.Equals(row["PUR_NO_TYPE"], "REQ"))
                        {
                            MENU_CODE = REQ_MENU_CODE;
                        }
                        else if (object.Equals(row["PUR_NO_TYPE"], "BAL"))
                        {
                            MENU_CODE = BAL_MENU_CODE;
                        }

                        TITLE = string.Format("%&S(S043,{0})%(%&S(S047,{1})%)", row["PUR_STAT"].ToString(), PUR_TYPE);


                        if (row["PUR_SEQ"] != DBNull.Value)
                        {
                            SEARCH_KEY = string.Format("{0},{1},{2}", PUR_TYPE, row["PUR_NO"].ToString(), row["PUR_SEQ"].ToString());

                            MESSAGE = string.Format("{0}-{1}", row["PUR_NO"].ToString(), row["PUR_SEQ"].ToString());
                        }
                        else
                        {
                            SEARCH_KEY = string.Format("{0},{1}", PUR_TYPE, row["PUR_NO"].ToString());

                            MESSAGE = row["PUR_NO"].ToString();
                        }


                        DataTable paramTable = new DataTable("PURCHASE");
                        paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                        paramTable.Columns.Add("TYPE", typeof(String)); //
                        paramTable.Columns.Add("KEY", typeof(String)); //
                        paramTable.Columns.Add("TITLE", typeof(String)); //
                        paramTable.Columns.Add("MESSAGE", typeof(String)); //
                        paramTable.Columns.Add("VAR", typeof(String)); //
                        paramTable.Columns.Add("MENU_CODE", typeof(String)); //
                        paramTable.Columns.Add("SEARCH_KEY", typeof(String)); //
                        paramTable.Columns.Add("REG_EMP", typeof(String)); //

                        DataRow paramRow = paramTable.NewRow();
                        paramRow["PLT_CODE"] = row["PLT_CODE"];
                        paramRow["TYPE"] = TYPE;
                        paramRow["KEY"] = row["EMP_CODE"];
                        paramRow["TITLE"] = TITLE;
                        paramRow["MESSAGE"] = MESSAGE;
                        paramRow["VAR"] = CONF_NAME;
                        paramRow["MENU_CODE"] = MENU_CODE;
                        paramRow["SEARCH_KEY"] = SEARCH_KEY;
                        paramRow["REG_EMP"] = row["REG_EMP"]; 
                        
                        paramTable.Rows.Add(paramRow);

                        CTRL.CREATE_NOTIFY(UTIL.GetDtToDs(paramTable), bizExecute);
                    }
                }
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        /// <summary>
        /// 자재 구매 이벤트 저장
        /// </summary>
        /// <param name="paramDS"></param>
        public static void SET_PURCHASE_EVENT_M(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                //보류 - HJKIM, 16-09-02
                //foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                //{
                //    DPUR.TPURCHASE_EVENT.TPURCHASE_EVENT_INS(UTIL.GetRowToDt(row), bizExecute);

                //    DataTable dtRslt = DMAT.TMAT_PUR_PARTLIST.TMAT_PUR_PARTLIST_SER(UTIL.GetRowToDt(row), bizExecute);

                   
                //}
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        /// <summary>
        /// 공정외주 이벤트 저장
        /// </summary>
        /// <param name="paramDS"></param>
        public static void SET_PURCHASE_EVENT_PO(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    DPUR.TPURCHASE_EVENT.TPURCHASE_EVENT_INS(UTIL.GetRowToDt(row), bizExecute);

                    DataTable dtRslt = DOUT.TOUT_REQUEST.TOUT_REQUEST_SER(UTIL.GetRowToDt(row), bizExecute);

                    if (dtRslt.Rows.Count != 0)
                    {
                        UTIL.SetBizAddColumnToValue(dtRslt, "PUR_STAT", row["PUR_STAT"], typeof(String));

                        DSHP.TSHP_WORKORDER.TSHP_WORKORDER_UPD24(dtRslt, bizExecute);
                    }

                }
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }


        /// <summary>
        /// 데이터 형식으로 변환합니다.
        /// </summary>
        /// <returns></returns>
        public static DataSet ToDateTime(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                Nullable<DateTime> Result = null;
                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    Result = null;
                    if (row["Value"] != DBNull.Value)
                    {
                        string date = (string)row["Value"];

                        if (!string.IsNullOrEmpty(date))
                        {
                            if (date.Length == 8)
                            {
                                Result = new DateTime(
                                    System.Convert.ToInt32(date.Substring(0, 4)),
                                    System.Convert.ToInt32(date.Substring(4, 2)),
                                    System.Convert.ToInt32(date.Substring(6, 2)));

                            }
                            else if (date.Length == 12)
                            {
                                Result = new DateTime(
                                        System.Convert.ToInt32(date.Substring(0, 4)),
                                        System.Convert.ToInt32(date.Substring(4, 2)),
                                        System.Convert.ToInt32(date.Substring(6, 2)),
                                        System.Convert.ToInt32(date.Substring(8, 2)),
                                        System.Convert.ToInt32(date.Substring(10, 2)), 0);
                            }
                            else if (date.Length == 14)
                            {
                                Result = new DateTime(
                                        System.Convert.ToInt32(date.Substring(0, 4)),
                                        System.Convert.ToInt32(date.Substring(4, 2)),
                                        System.Convert.ToInt32(date.Substring(6, 2)),
                                        System.Convert.ToInt32(date.Substring(8, 2)),
                                        System.Convert.ToInt32(date.Substring(10, 2)),
                                        System.Convert.ToInt32(date.Substring(12, 2)));
                            }
                        }
                    }
                }

                DataTable paramTable = new DataTable("RSLTDT");
                paramTable.Columns.Add("Result", typeof(DateTime)); //

                DataRow paramRow = paramTable.NewRow();
                paramRow["Result"] = Result;
                paramTable.Rows.Add(paramRow);

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                return paramSet;

            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        /// <summary>
        /// 문자열 타입인 두날짜를 비교한다.
        /// </summary>
        /// <returns></returns>
        public static DataSet COMPARE_DATE(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable paramTable1 = new DataTable("RQSTDT");
                paramTable1.Columns.Add("Value", typeof(String)); //

                DataRow paramRow1 = paramTable1.NewRow();
                paramRow1["Value"] = paramDS.Tables["RQSTDT"].Rows[0]["DATE1"];
                paramTable1.Rows.Add(paramRow1);

                DataSet paramSet1 = new DataSet();
                paramSet1.Tables.Add(paramTable1);

                DataSet dsRslt1 = CTRL.ToDateTime(paramSet1, bizExecute);



                DataTable paramTable2 = new DataTable("RQSTDT");
                paramTable2.Columns.Add("Value", typeof(String)); //

                DataRow paramRow2 = paramTable2.NewRow();
                paramRow2["Value"] = paramDS.Tables["RQSTDT"].Rows[0]["DATE2"];
                paramTable2.Rows.Add(paramRow2);
                DataSet paramSet2 = new DataSet();
                paramSet2.Tables.Add(paramTable2);

                DataSet dsRslt2 = CTRL.ToDateTime(paramSet2, bizExecute);


                DateTime date1 = (DateTime)dsRslt1.Tables["RSLTDT"].Rows[0]["Result"];
                DateTime date2 = (DateTime)dsRslt2.Tables["RSLTDT"].Rows[0]["Result"];

                string newRow = "";

                if (date1 > date2)
                {
                    newRow = "DATE1";
                }
                else if (date1 < date2)
                {
                    newRow = "DATE2";
                }
                else if (date1 == date2)
                {
                    newRow = "SAME";
                }

                DataTable paramTableRESULT = new DataTable("RSLTDT");
                paramTableRESULT.Columns.Add("RESULT", typeof(String)); //

                DataRow paramRowRESULT = paramTableRESULT.NewRow();
                paramRowRESULT["RESULT"] = newRow;
                paramTableRESULT.Rows.Add(paramRowRESULT);

                DataSet paramSetRESULT = new DataSet();
                paramSetRESULT.Tables.Add(paramTableRESULT);


                return paramSetRESULT;

            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        #region 창고 수량 조절
        /// <summary>
        /// 
        /// </summary>
        /// <param name="row"></param>
        /// <param name="bizExecute"></param>
        /// <param name="part_code">부품 컬럼명</param>
        /// <param name="stockLoc"></param>
        /// <param name="partQty"></param>
        /// <param name="amt"></param>
        /// <param name="ypgoId"></param>
        /// <param name="outId"></param>
        public static void SET_STOCK_PROCESS(DataRow row, BizExecute.BizExecute bizExecute
                                                                ,string part_code="PART_CODE"
                                                                ,string stockLoc = "STOCK_LOC"
                                                                ,string partQty = "PART_QTY"
                                                                ,string amt = "AMT"
                                                                ,string ypgoId = null
                                                                ,string outId = null
                                                                ,string scomment = ""
                                                                ,string returnType = "")
        {
            #region 재고 테이블 생성
            DataTable dtStock = new DataTable();
            dtStock.Columns.Add("PLT_CODE", typeof(String));
            dtStock.Columns.Add("LOT_ID", typeof(String));
            dtStock.Columns.Add("STK_ID", typeof(String));
            dtStock.Columns.Add("PART_CODE", typeof(String));
            dtStock.Columns.Add("DETAIL_PART_NAME", typeof(String));
            dtStock.Columns.Add("STOCK_LOC", typeof(String));
            dtStock.Columns.Add("STOCK_FLAG", typeof(String));
            dtStock.Columns.Add("GUBUN", typeof(String));//생산완료 등록(PF / 생산완료 취소(PC / 출하 등록(SF / 출하 취소(SC / 재고조정(SA / 선삭재고 전환(-)(TMinus) / 선삭재고 전환(+) (TPlus)
            dtStock.Columns.Add("IN_QTY", typeof(decimal));
            dtStock.Columns.Add("IN_COST", typeof(decimal));
            dtStock.Columns.Add("IN_AMT", typeof(decimal));
            dtStock.Columns.Add("OUT_QTY", typeof(decimal));
            dtStock.Columns.Add("OUT_COST", typeof(decimal));
            dtStock.Columns.Add("OUT_AMT", typeof(decimal));
            dtStock.Columns.Add("TOT_YPGO_AMT", typeof(decimal));
            dtStock.Columns.Add("PART_QTY", typeof(decimal));
            dtStock.Columns.Add("SCOMMENT", typeof(String));
            dtStock.Columns.Add("REG_EMP", typeof(String));
            dtStock.Columns.Add("OUT_ID", typeof(String));
            dtStock.Columns.Add("YPGO_ID", typeof(String));
            dtStock.Columns.Add("PROD_CODE", typeof(String));
            dtStock.Columns.Add("CVND_CODE", typeof(String));
            #endregion


            string stk_id = string.Empty;//, barcode_no = string.Empty;

            //double out_qty = 0, tot_out_qty = 0, sum_qty = 0;

            //DataTable dtSerBarcode, dtSerLocBarcode;

            switch (row["TYPE"].ToString())
            {
                case "ADJ":     //재고조정
                    {
                        dtStock.Clear();
                        if (row[partQty].toInt() > 0)
                        {
                            //DataTable dtSerStock = DMAT.TMAT_STOCK.TMAT_STOCK_SER2(UTIL.GetRowToDt(row), bizExecute);

                            //재고생성
                            double stock_amt = 0;

                            stock_amt = row["PART_AMT"].toDbl() * row[partQty].toDbl();

                            DataRow drStock = dtStock.NewRow();
                            drStock["PLT_CODE"] = row["PLT_CODE"];
                            drStock["PART_CODE"] = row[part_code];
                            drStock["DETAIL_PART_NAME"] = row["DETAIL_PART_NAME"];
                            drStock["STOCK_LOC"] = row[stockLoc];
                            drStock["STOCK_FLAG"] = "SA";
                            drStock["GUBUN"] = "SA";
                            drStock["IN_QTY"] = row[partQty];
                            drStock["IN_COST"] = row["PART_AMT"].toDbl();
                            drStock["IN_AMT"] = stock_amt;
                            drStock["STK_ID"] = row["STK_ID"];
                            drStock["SCOMMENT"] = row["SCOMMENT"];
                            dtStock.Rows.Add(drStock);

                            //#region 생성되는 수량만큼 LOT 생성
                            //int pQty = row[partQty].toInt();
                            //if (pQty > 0)
                            //{
                            //    decimal unitCost = row["PART_AMT"].toDecimal();

                            //    for (int i = 0; i < pQty; i++)
                            //    {
                            //        DataRow dtStockLotRow = dtStockLot.NewRow();
                            //        dtStockLotRow["PLT_CODE"] = ConnInfo.PLT_CODE;
                            //        dtStockLotRow["LOT_ID"] = UTIL.UTILITY_GET_SERIALNO(ConnInfo.PLT_CODE, "SLOT", UTIL.emSerialFormat.YYMMDDHH, "", bizExecute);
                            //        dtStockLotRow["PART_CODE"] = row[part_code];
                            //        dtStockLotRow["DETAIL_PART_NAME"] = row["DETAIL_PART_NAME"];
                            //        dtStockLotRow["STK_ID"] = row["STK_ID"];
                            //        dtStockLotRow["UNIT_COST"] = unitCost;
                            //        dtStockLotRow["STOCK_FLAG"] = "NE";
                            //        dtStockLot.Rows.Add(dtStockLotRow);
                            //    }

                            //    DMAT.TMAT_STOCK_LOT.TMAT_STOCK_LOT_INS(dtStockLot, bizExecute);
                            //}
                            //#endregion

                            //STOCK 상태 바뀌기전에 입력
                            SET_STOCK_LOG(drStock, bizExecute);

                            DMAT.TMAT_STOCK.TMAT_STOCK_UPD2(UTIL.GetRowToDt(row), bizExecute);
                        }
                        else
                        {
                            //재고삭제
                            //DataTable rsltDt = DMAT.TMAT_STOCK_LOT_QUERY.TMAT_STOCK_LOT_QUERY1(UTIL.GetRowToDt(row), bizExecute);
                            //if (rsltDt.Rows.Count == 0)
                            //{
                            //    throw UTIL.SetException("입고인 상태인 LOT이 존재하지 않습니다."
                            //                                        , row[part_code].toStringEmpty()
                            //                                        , new System.Diagnostics.StackFrame().GetMethod().Name
                            //                                        , BizException.ABORT, row);
                            //}
                            ////PART_CODE로 탐색
                            ////REG_DATE로 순차(선입선출)
                            //var dtSer = rsltDt
                            //                .AsEnumerable()
                            //                .OrderBy(o => o["REG_DATE"])
                            //                .ToList()
                            //                .GetRange(0, Math.Abs(row[partQty].toInt()))
                            //                .GroupBy(g => new
                            //                {
                            //                    PLT_CODE = g["PLT_CODE"],
                            //                    PART_CODE = g["PART_CODE"],
                            //                    STK_ID = g["STK_ID"],
                            //                    STOCK_LOC = g["STOCK_LOC"]
                            //                })
                            //                .Select(r => new
                            //                {
                            //                    PLT_CODE = r.Key.PLT_CODE,
                            //                    PART_CODE = r.Key.PART_CODE,
                            //                    STK_ID = r.Key.STK_ID,
                            //                    STOCK_LOC = r.Key.STOCK_LOC,
                            //                    PART_QTY = r.Max(m => m["PART_QTY"].toDecimal()),
                            //                    TOT_YPGO_AMT = r.Max(m => m["TOT_YPGO_AMT"].toDecimal()),
                            //                    SUM_UNIT_COST = r.Sum(s => s["UNIT_COST"].toDecimal()),
                            //                    OUT_PART_QTY = r.Count(),
                            //                    LOT_LIST = r.ToList()
                            //                });

                            //foreach (var serRow in dtSer)
                            //{
                            //    DataRow drOut = dtStock.NewRow();
                            //    drOut["PLT_CODE"] = row["PLT_CODE"];
                            //    drOut["PART_CODE"] = row[part_code];
                            //    drOut["DETAIL_PART_NAME"] = row["DETAIL_PART_NAME"];
                            //    drOut["STK_ID"] = serRow.STK_ID;
                            //    drOut["STOCK_LOC"] = serRow.STOCK_LOC;
                            //    drOut["STOCK_FLAG"] = "SA";
                            //    drOut["GUBUN"] = "SA";
                            //    drOut["OUT_QTY"] = serRow.LOT_LIST.Count;
                            //    drOut["OUT_COST"] = serRow.SUM_UNIT_COST / serRow.LOT_LIST.Count;
                            //    drOut["OUT_AMT"] = serRow.SUM_UNIT_COST;
                            //    drOut["TOT_YPGO_AMT"] = serRow.TOT_YPGO_AMT - serRow.SUM_UNIT_COST;
                            //    drOut["PART_QTY"] = serRow.PART_QTY - serRow.OUT_PART_QTY;
                            //    dtStock.Rows.Add(drOut);

                            //    #region LOT 삭제

                            //    foreach (DataRow lotRow in serRow.LOT_LIST)
                            //    {
                            //        DataRow dtStockLotRow = dtStockLot.NewRow();
                            //        dtStockLotRow["PLT_CODE"] = ConnInfo.PLT_CODE;
                            //        dtStockLotRow["LOT_ID"] = lotRow["LOT_ID"];
                            //        dtStockLotRow["STK_ID"] = lotRow["STK_ID"];
                            //        dtStockLotRow["STOCK_FLAG"] = "OT";
                            //        if (!outId.isNullOrEmpty())
                            //        {
                            //            dtStockLotRow["OUT_ID"] = row[outId];
                            //        }
                            //        dtStockLot.Rows.Add(dtStockLotRow);
                            //    }

                            //    #endregion

                            //    //STOCK 상태 바뀌기전에 입력
                            //    SET_STOCK_LOG(drOut, dtStockLot, bizExecute);

                            //    DMAT.TMAT_STOCK.TMAT_STOCK_UPD(dtStock, bizExecute);
                            //    DMAT.TMAT_STOCK_LOT.TMAT_STOCK_LOT_DEL2(dtStockLot, bizExecute);
                            //}

                            DataTable rsltDt = DMAT.TMAT_STOCK_LOG_DETAIL_QUERY.TMAT_STOCK_LOG_DETAIL_QUERY1(UTIL.GetRowToDt(row), bizExecute);

                            if (rsltDt.Rows.Count == 0)
                            {
                                throw UTIL.SetException("입고인 상태인 LOT이 존재하지 않습니다."
                                                                    , row[part_code].toStringEmpty()
                                                                    , new System.Diagnostics.StackFrame().GetMethod().Name
                                                                    , BizException.ABORT, row);
                            }

                            //int qty = row["PART_QTY"].toInt();
                            int qty = Math.Abs(row[partQty].toInt());

                            //int stockQty = rsltDt.Rows[0]["PART_QTY"].toInt();

                            //decimal totYpgoAmt = rsltDt.Rows[0]["TOT_YPGO_AMT"].toDecimal2();


                            Dictionary<string, decimal> amtDic = new Dictionary<string, decimal>();
                            Dictionary<string, int> qtyDic = new Dictionary<string, int>();

                            foreach (DataRow rw in rsltDt.Rows)
                            {
                                string stkLoc = rw["STOCK_LOC"].ToString();

                                if (!amtDic.ContainsKey(stkLoc))
                                {
                                    amtDic.Add(stkLoc, rw["TOT_YPGO_AMT"].toDecimal());
                                }

                                if (!qtyDic.ContainsKey(stkLoc))
                                {
                                    qtyDic.Add(stkLoc, rw["PART_QTY"].toInt());
                                }

                                dtStock.Clear();
                                if (qty == 0) break;

                                int outQty = 0;

                                if ((rw["REMAIN_QTY"].toInt() - qty) >= 0)
                                {
                                    outQty = qty;
                                    qty = 0;
                                }
                                else
                                {
                                    outQty = rw["REMAIN_QTY"].toInt();
                                    qty = qty - rw["REMAIN_QTY"].toInt();
                                }

                                DataRow drOut = dtStock.NewRow();
                                drOut["PLT_CODE"] = row["PLT_CODE"];
                                drOut["PART_CODE"] = row[part_code];
                                drOut["DETAIL_PART_NAME"] = row["DETAIL_PART_NAME"];
                                drOut["STK_ID"] = rw["STK_ID"];
                                drOut["STOCK_LOC"] = rw["STOCK_LOC"];
                                drOut["STOCK_FLAG"] = "SA";
                                drOut["GUBUN"] = "SA";
                                drOut["OUT_QTY"] = outQty;
                                drOut["OUT_COST"] = rw["UNIT_COST"];
                                drOut["OUT_AMT"] = drOut["OUT_QTY"].toDecimal() * drOut["OUT_COST"].toDecimal();


                                amtDic[stkLoc] = amtDic[stkLoc] - drOut["OUT_AMT"].toDecimal();
                                qtyDic[stkLoc] = qtyDic[stkLoc] - outQty;

                                //totYpgoAmt = totYpgoAmt - drOut["OUT_AMT"].toDecimal();
                                //stockQty = stockQty - outQty;

                                drOut["TOT_YPGO_AMT"] = amtDic[stkLoc];
                                drOut["PART_QTY"] = qtyDic[stkLoc];
                                drOut["LOT_ID"] = rw["LOT_ID"];
                                drOut["YPGO_ID"] = rw["YPGO_ID"];
                                drOut["SCOMMENT"] = row["SCOMMENT"];
                                dtStock.Rows.Add(drOut);

                                //데이터 처리 전에 로그부터 입력
                                SET_STOCK_LOG(drOut, bizExecute);

                                DMAT.TMAT_STOCK.TMAT_STOCK_UPD(dtStock, bizExecute);
                            }

                            break;
                        }
                    }

                    break;
                case "ADD":     //재고생성
                    {
                        DataTable dtSerStock = DMAT.TMAT_STOCK.TMAT_STOCK_SER2(UTIL.GetRowToDt(row), bizExecute);
                        if (dtSerStock.Rows.Count > 0)
                        {
                            row["STK_ID"] = dtSerStock.Rows[0]["STK_ID"];
                        }
                        else
                        {
                            row["STK_ID"] = UTIL.UTILITY_GET_SERIALNO(ConnInfo.PLT_CODE, "STK", bizExecute);
                        }

                        DataRow drCreate = dtStock.NewRow();
                        drCreate["PLT_CODE"] = row["PLT_CODE"];
                        drCreate["PART_CODE"] = row[part_code];
                        drCreate["DETAIL_PART_NAME"] = row["DETAIL_PART_NAME"];
                        drCreate["STK_ID"] = row["STK_ID"];
                        drCreate["STOCK_LOC"] = row[stockLoc];
                        drCreate["STOCK_FLAG"] = "NE";
                        drCreate["GUBUN"] = "NE";
                        drCreate["IN_QTY"] = row[partQty];
                        drCreate["IN_COST"] = row[partQty].toInt() == 0 ? 0 : row[amt].toDecimal() / row[partQty].toDecimal();
                        drCreate["IN_AMT"] = row[amt];
                        drCreate["TOT_YPGO_AMT"] = row[amt];
                        drCreate["PART_QTY"] = row[partQty];
                        //drCreate["SCOMMENT"] = row["SCOMMENT"];
                        dtStock.Rows.Add(drCreate);


                        //#region 생성되는 수량만큼 LOT 생성
                        //int pQty = row[partQty].toInt();
                        //if (pQty > 0)
                        //{
                        //    decimal unitCost = row[amt].toDecimal() / row[partQty].toDecimal();

                        //    for (int i = 0; i < pQty; i++)
                        //    {
                        //        DataRow dtStockLotRow = dtStockLot.NewRow();
                        //        dtStockLotRow["PLT_CODE"] = ConnInfo.PLT_CODE;
                        //        dtStockLotRow["LOT_ID"] = UTIL.UTILITY_GET_SERIALNO(ConnInfo.PLT_CODE, "SLOT", UTIL.emSerialFormat.YYMMDDHH, "", bizExecute);
                        //        dtStockLotRow["PART_CODE"] = row[part_code];
                        //        dtStockLotRow["DETAIL_PART_NAME"] = row["DETAIL_PART_NAME"];
                        //        dtStockLotRow["STK_ID"] = drCreate["STK_ID"];
                        //        dtStockLotRow["UNIT_COST"] = unitCost;
                        //        dtStockLotRow["STOCK_FLAG"] = "NE";
                        //        if (!ypgoId.isNullOrEmpty())
                        //        {
                        //            dtStockLotRow["YPGO_ID"] = row[ypgoId];
                        //        }
                        //        dtStockLot.Rows.Add(dtStockLotRow);
                        //    }

                        //    DMAT.TMAT_STOCK_LOT.TMAT_STOCK_LOT_INS(dtStockLot, bizExecute);
                        //}
                        //#endregion

                        //STOCK 상태 바뀌기전에 입력
                        SET_STOCK_LOG(drCreate, bizExecute);

                        if (dtSerStock.Rows.Count == 0)
                        {
                            drCreate["TOT_YPGO_AMT"] = row[amt];
                            drCreate["PART_QTY"] = row[partQty].toDecimal();
                            DMAT.TMAT_STOCK.TMAT_STOCK_INS(dtStock, bizExecute);
                        }
                        else
                        {
                            drCreate["TOT_YPGO_AMT"] = row[amt].toDecimal() + dtSerStock.Rows[0]["TOT_YPGO_AMT"].toDecimal();
                            drCreate["PART_QTY"] = row[partQty].toDecimal() + dtSerStock.Rows[0]["PART_QTY"].toDecimal();
                            DMAT.TMAT_STOCK.TMAT_STOCK_UPD(dtStock, bizExecute);
                        }

                        break;
                    }
                case "IN":     //입고
                    {
                        #region 재고 검색조건
                        DataTable dtStockInfo = new DataTable();
                        dtStockInfo.Columns.Add("PLT_CODE", typeof(String));
                        dtStockInfo.Columns.Add("PART_CODE", typeof(String));
                        dtStockInfo.Columns.Add("DETAIL_PART_NAME", typeof(String));
                        dtStockInfo.Columns.Add("STOCK_LOC", typeof(String));

                        DataRow drStockInfo = dtStockInfo.NewRow();
                        drStockInfo["PLT_CODE"] = row["PLT_CODE"];
                        drStockInfo["PART_CODE"] = row[part_code];
                        drStockInfo["DETAIL_PART_NAME"] = row["DETAIL_PART_NAME"];
                        drStockInfo["STOCK_LOC"] = row[stockLoc];
                        dtStockInfo.Rows.Add(drStockInfo);
                        #endregion

                        DataTable dtSerStock = DMAT.TMAT_STOCK.TMAT_STOCK_SER2(dtStockInfo, bizExecute);
                        if(dtSerStock.Rows.Count >0)
                        {
                            row["STK_ID"] = dtSerStock.Rows[0]["STK_ID"];
                        }
                        else
                        {
                            row["STK_ID"] = UTIL.UTILITY_GET_SERIALNO(ConnInfo.PLT_CODE, "STK", bizExecute);
                        }

                        DataRow drYpgo = dtStock.NewRow();
                        drYpgo["PLT_CODE"] = row["PLT_CODE"];
                        drYpgo["PART_CODE"] = row[part_code];
                        drYpgo["DETAIL_PART_NAME"] = row["DETAIL_PART_NAME"];
                        drYpgo["STK_ID"] = row["STK_ID"];
                        drYpgo["STOCK_LOC"] = row[stockLoc];

                        string stockFlag = "YP";
                        if (returnType == "RE")
                        {
                            stockFlag = "RE";
                        }

                        drYpgo["STOCK_FLAG"] = stockFlag;
                        drYpgo["GUBUN"] = "YP";
                        drYpgo["IN_QTY"] = row[partQty];
                        drYpgo["IN_COST"] = row[partQty].toInt() == 0 ? 0 : row[amt].toDecimal() / row[partQty].toDecimal();
                        drYpgo["IN_AMT"] = row[amt];
                        if (!ypgoId.isNullOrEmpty())
                        {
                            drYpgo["YPGO_ID"] = row[ypgoId];
                        }
                        //drYpgo["SCOMMENT"] = row["SCOMMENT"];

                        if (scomment != "")
                        {
                            drYpgo["SCOMMENT"] = scomment;
                        }

                        //if (row.Table.Columns.Contains("CVND_CODE"))
                        //{
                        //    drYpgo["CVND_CODE"] = row["CVND_CODE"];
                        //}

                        dtStock.Rows.Add(drYpgo);


                        //#region 생성되는 수량만큼 LOT 생성
                        //int pQty = row[partQty].toInt();
                        //if (pQty > 0)
                        //{
                        //    decimal unitCost = row[amt].toDecimal() / row[partQty].toDecimal();

                        //    for (int i = 0; i < pQty; i++)
                        //    {
                        //        DataRow dtStockLotRow = dtStockLot.NewRow();
                        //        dtStockLotRow["PLT_CODE"] = ConnInfo.PLT_CODE;
                        //        dtStockLotRow["LOT_ID"] = UTIL.UTILITY_GET_SERIALNO(ConnInfo.PLT_CODE, "SLOT", UTIL.emSerialFormat.YYMMDDHH, "", bizExecute);
                        //        dtStockLotRow["PART_CODE"] = row[part_code];
                        //        dtStockLotRow["DETAIL_PART_NAME"] = row["DETAIL_PART_NAME"];
                        //        dtStockLotRow["STK_ID"] = drYpgo["STK_ID"];
                        //        dtStockLotRow["UNIT_COST"] = unitCost;
                        //        dtStockLotRow["STOCK_FLAG"] = "YP";
                        //        if (!ypgoId.isNullOrEmpty())
                        //        {
                        //            dtStockLotRow["YPGO_ID"] = row[ypgoId];
                        //        }
                        //        dtStockLot.Rows.Add(dtStockLotRow);
                        //    }

                        //    DMAT.TMAT_STOCK_LOT.TMAT_STOCK_LOT_INS(dtStockLot, bizExecute);
                        //}
                        //#endregion
                        
                        //STOCK 상태 바뀌기전에 입력
                        SET_STOCK_LOG(drYpgo, bizExecute);

                        if (dtSerStock.Rows.Count == 0)
                        {
                            drYpgo["TOT_YPGO_AMT"] = row[amt];
                            drYpgo["PART_QTY"] = row[partQty].toDecimal();
                            DMAT.TMAT_STOCK.TMAT_STOCK_INS(dtStock, bizExecute);
                        }
                        else
                        {
                            drYpgo["TOT_YPGO_AMT"] = row[amt].toDecimal() + dtSerStock.Rows[0]["TOT_YPGO_AMT"].toDecimal();
                            drYpgo["PART_QTY"] = row[partQty].toDecimal() + dtSerStock.Rows[0]["PART_QTY"].toDecimal();
                            DMAT.TMAT_STOCK.TMAT_STOCK_UPD(dtStock, bizExecute);
                        }

                        break;
                    }
                case "IN_CANCEL":     //입고취소
                    {

                        if (ypgoId.isNullOrEmpty())
                        {
                            throw UTIL.SetException("입고ID를 입력해주세요."
                                                            , null
                                                            , new System.Diagnostics.StackFrame().GetMethod().Name
                                                            , BizException.ABORT, row);
                        }

                        //DataTable dtSerStock = DMAT.TMAT_STOCK_LOT_QUERY.TMAT_STOCK_LOT_QUERY1(UTIL.GetRowToDt(row), bizExecute);

                        //if (dtSerStock.Select("STOCK_FLAG <> 'YP'").Any())
                        //{
                        //    throw UTIL.SetException("입고 상태가 아닌 LOT이 존재합니다. 취소하실수 없습니다."
                        //                                    , ypgoId
                        //                                    , new System.Diagnostics.StackFrame().GetMethod().Name
                        //                                    , BizException.ABORT, row);
                        //}
                        //int unitCntQty = dtSerStock.Rows.Count;
                        //decimal amtUnitSum = dtSerStock.AsEnumerable().Sum(s => s["UNIT_COST"].toDecimal());
                        //DataRow drYpgo = dtStock.NewRow();
                        //drYpgo["PLT_CODE"] = row["PLT_CODE"];
                        //drYpgo["PART_CODE"] = dtSerStock.Rows[0]["PART_CODE"];
                        //drYpgo["DETAIL_PART_NAME"] = dtSerStock.Rows[0]["DETAIL_PART_NAME"];
                        //drYpgo["STK_ID"] = dtSerStock.Rows[0]["STK_ID"];    //같은 입고 ID는 같은 STK_ID를 같는다
                        //drYpgo["STOCK_LOC"] = dtSerStock.Rows[0]["STOCK_LOC"];
                        //drYpgo["STOCK_FLAG"] = "YC";
                        //drYpgo["GUBUN"] = "YC";
                        //drYpgo["OUT_QTY"] = unitCntQty;
                        //drYpgo["OUT_COST"] = dtSerStock.Rows[0]["UNIT_COST"];
                        //drYpgo["OUT_AMT"] = amtUnitSum;
                        ////drYpgo["SCOMMENT"] = row["SCOMMENT"];
                        //dtStock.Rows.Add(drYpgo);

                        //#region LOT 삭제
                        //DMAT.TMAT_STOCK_LOT.TMAT_STOCK_LOT_DEL(UTIL.GetRowToDt(row), bizExecute);
                        //#endregion
                        ////STOCK 상태 바뀌기전에 입력
                        //SET_STOCK_LOG(drYpgo, dtStockLot, bizExecute);

                        //if (dtSerStock.Rows.Count > 0)
                        //{
                        //    drYpgo["TOT_YPGO_AMT"] = dtSerStock.Rows[0]["TOT_YPGO_AMT"].toDecimal() - drYpgo["OUT_AMT"].toDecimal();
                        //    drYpgo["PART_QTY"] = dtSerStock.Rows[0]["PART_QTY"].toDecimal() - drYpgo["OUT_QTY"].toDecimal();
                        //    DMAT.TMAT_STOCK.TMAT_STOCK_UPD(dtStock, bizExecute);
                        //}

                        DataTable rsltDT = DMAT.TMAT_STOCK_LOG_DETAIL_QUERY.TMAT_STOCK_LOG_DETAIL_QUERY3(UTIL.GetRowToDt(row), bizExecute);

                        if (rsltDT.Rows.Count == 0)
                        {
                            throw UTIL.SetException("입고 정보가 없습니다."
                                                            , ypgoId
                                                            , new System.Diagnostics.StackFrame().GetMethod().Name
                                                            , BizException.ABORT, row);
                        }


                        if (rsltDT.Rows.Count > 1)
                        {

                            throw UTIL.SetException("입고 상태가 아닌 LOT이 존재합니다. 취소하실수 없습니다."
                                                            , ypgoId
                                                            , new System.Diagnostics.StackFrame().GetMethod().Name
                                                            , BizException.ABORT, row);
                        }

                        if (rsltDT.Rows[0]["OUT_QTY"].toInt() > 0)
                        {
                            throw UTIL.SetException("해당 입고건으로 불출 처리된 내역이 존재합니다. 취소할 수 없습니다. "
                                                            , ypgoId
                                                            , new System.Diagnostics.StackFrame().GetMethod().Name
                                                            , BizException.ABORT, row);
                        }

                        //int stockQty = rsltDT.Rows[0]["PART_QTY"].toInt();

                        //decimal totYpgoAmt = rsltDT.Rows[0]["TOT_YPGO_AMT"].toDecimal2();

                        Dictionary<string, decimal> amtDic = new Dictionary<string, decimal>();
                        Dictionary<string, int> qtyDic = new Dictionary<string, int>();

                        foreach (DataRow rw in rsltDT.Rows)
                        {
                            string stkLoc = rw["STOCK_LOC"].ToString();

                            if (!amtDic.ContainsKey(stkLoc))
                            {
                                amtDic.Add(stkLoc, rw["TOT_YPGO_AMT"].toDecimal());
                            }

                            if (!qtyDic.ContainsKey(stkLoc))
                            {
                                qtyDic.Add(stkLoc, rw["PART_QTY"].toInt());
                            }

                            dtStock.Clear();
                            DataRow drYpgo = dtStock.NewRow();
                            drYpgo["PLT_CODE"] = row["PLT_CODE"];
                            drYpgo["PART_CODE"] = rw["PART_CODE"];
                            drYpgo["DETAIL_PART_NAME"] = rw["DETAIL_PART_NAME"];
                            drYpgo["STK_ID"] = rw["STK_ID"];
                            drYpgo["STOCK_LOC"] = rw["STOCK_LOC"];
                            drYpgo["STOCK_FLAG"] = "YC";
                            drYpgo["GUBUN"] = "YC";
                            drYpgo["OUT_QTY"] = rw["IN_QTY"];
                            drYpgo["OUT_COST"] = rw["UNIT_COST"];
                            //drYpgo["OUT_AMT"] = rw["PART_QTY"].toDecimal() * rw["UNIT_COST"].toDecimal();
                            //입고 취소니까 입고 수량 (part_qty 현 재고 수량)
                            drYpgo["OUT_AMT"] = rw["IN_QTY"].toDecimal() * rw["UNIT_COST"].toDecimal();
                            drYpgo["LOT_ID"] = rw["LOT_ID"];
                            drYpgo["YPGO_ID"] = rw["YPGO_ID"];
                            //drYpgo["SCOMMENT"] = row["SCOMMENT"];

                            //if (row.Table.Columns.Contains("CVND_CODE"))
                            //{
                            //    drYpgo["CVND_CODE"] = row["CVND_CODE"];
                            //}

                            dtStock.Rows.Add(drYpgo);

                            SET_STOCK_LOG(drYpgo, bizExecute);

                            amtDic[stkLoc] = amtDic[stkLoc] - drYpgo["OUT_AMT"].toDecimal();
                            qtyDic[stkLoc] = qtyDic[stkLoc] - drYpgo["OUT_QTY"].toInt();

                            drYpgo["TOT_YPGO_AMT"] = amtDic[stkLoc];
                            drYpgo["PART_QTY"] = qtyDic[stkLoc];

                            //totYpgoAmt = totYpgoAmt - drYpgo["OUT_AMT"].toDecimal();
                            //stockQty = stockQty - drYpgo["OUT_QTY"].toInt();

                            //drYpgo["TOT_YPGO_AMT"] = totYpgoAmt;
                            //drYpgo["PART_QTY"] = stockQty;

                            DMAT.TMAT_STOCK.TMAT_STOCK_UPD(dtStock, bizExecute);
                        }



                        break;
                    }
                case "OUT":
                case "SH"://출고    
                    {

                        //DataTable rsltDt = DMAT.TMAT_STOCK_LOT_QUERY.TMAT_STOCK_LOT_QUERY1(UTIL.GetRowToDt(row), bizExecute);
                        //if(rsltDt.Rows.Count ==0)
                        //{
                        //    throw UTIL.SetException("입고 상태인 LOT이 존재하지 않습니다."
                        //                                        , row[part_code].toStringEmpty()
                        //                                        , new System.Diagnostics.StackFrame().GetMethod().Name
                        //                                        , BizException.ABORT, row);
                        //}

                        //if(rsltDt.Rows.Count < row[partQty].toInt())
                        //{
                        //    throw UTIL.SetException(string.Format("재고 수량이 불출 요청 수량보다 부족합니다." +
                        //                                        "\r\n수량을 조정하여 주십시오.<현재고:{0}>", rsltDt.Rows.Count)
                        //                                        , row[part_code].toStringEmpty()
                        //                                        , new System.Diagnostics.StackFrame().GetMethod().Name
                        //                                        , BizException.ABORT, row);
                        //}

                        ////PART_CODE로 탐색
                        ////REG_DATE로 순차(선입선출)
                        //var dtSer = rsltDt
                        //                .AsEnumerable()
                        //                .OrderBy(o => o["REG_DATE"])
                        //                .ToList()
                        //                .GetRange(0, row[partQty].toInt())
                        //                .GroupBy(g => new
                        //                {
                        //                    PLT_CODE = g["PLT_CODE"],
                        //                    //REG_DATE = g["REG_DATE"],
                        //                    PART_CODE = g["PART_CODE"],
                        //                    STK_ID = g["STK_ID"],
                        //                    STOCK_LOC = g["STOCK_LOC"]
                        //                })
                        //                .Select(r => new
                        //                {
                        //                    PLT_CODE = r.Key.PLT_CODE,
                        //                    PART_CODE = r.Key.PART_CODE,
                        //                    STK_ID = r.Key.STK_ID,
                        //                    STOCK_LOC = r.Key.STOCK_LOC,
                        //                    PART_QTY = r.Max(m=> m["PART_QTY"].toDecimal()),
                        //                    TOT_YPGO_AMT = r.Max(m => m["TOT_YPGO_AMT"].toDecimal()),
                        //                    SUM_UNIT_COST = r.Sum(s => s["UNIT_COST"].toDecimal()),
                        //                    OUT_PART_QTY = r.Count(),
                        //                    LOT_LIST = r.ToList()
                        //                });

                        //foreach (var serRow in dtSer)
                        //{
                        //    DataRow drOut = dtStock.NewRow();
                        //    drOut["PLT_CODE"] = row["PLT_CODE"];
                        //    drOut["PART_CODE"] = row[part_code];
                        //    drOut["STK_ID"] = serRow.STK_ID;
                        //    drOut["STOCK_LOC"] = serRow.STOCK_LOC;
                        //    drOut["STOCK_FLAG"] = "OT";
                        //    drOut["GUBUN"] = "OT";
                        //    drOut["OUT_QTY"] = serRow.LOT_LIST.Count;
                        //    drOut["OUT_COST"] = serRow.SUM_UNIT_COST / serRow.LOT_LIST.Count;
                        //    drOut["OUT_AMT"] = serRow.SUM_UNIT_COST;
                        //    drOut["TOT_YPGO_AMT"] = serRow.TOT_YPGO_AMT - serRow.SUM_UNIT_COST;
                        //    drOut["PART_QTY"] = serRow.PART_QTY - serRow.OUT_PART_QTY;
                        //    dtStock.Rows.Add(drOut);

                        //    #region LOT 출고

                        //        foreach(DataRow lotRow in serRow.LOT_LIST)
                        //        { 
                        //            DataRow dtStockLotRow = dtStockLot.NewRow();
                        //            dtStockLotRow["PLT_CODE"] = ConnInfo.PLT_CODE;
                        //            dtStockLotRow["LOT_ID"] = lotRow["LOT_ID"];
                        //            dtStockLotRow["STK_ID"] = lotRow["STK_ID"];
                        //            dtStockLotRow["STOCK_FLAG"] = "OT";
                        //            if (!outId.isNullOrEmpty())
                        //            {
                        //                dtStockLotRow["OUT_ID"] = row[outId];
                        //            }
                        //            dtStockLot.Rows.Add(dtStockLotRow);
                        //        }

                        //    #endregion

                        //    //데이터 처리 전에 로그부터 입력
                        //    SET_STOCK_LOG(drOut, dtStockLot, bizExecute);

                        //    DMAT.TMAT_STOCK.TMAT_STOCK_UPD(dtStock, bizExecute);
                        //    DMAT.TMAT_STOCK_LOT.TMAT_STOCK_LOT_UPD(dtStockLot, bizExecute);
                        //    DMAT.TMAT_STOCK_LOT.TMAT_STOCK_LOT_UPD2(dtStockLot, bizExecute);
                        //}

                        DataTable rsltDT = DMAT.TMAT_STOCK_LOG_DETAIL_QUERY.TMAT_STOCK_LOG_DETAIL_QUERY1(UTIL.GetRowToDt(row), bizExecute);

                        if (rsltDT.Rows.Count == 0)
                        {
                            throw UTIL.SetException("입고된 재고가 없습니다."
                                                                , row[part_code].toStringEmpty()
                                                                , new System.Diagnostics.StackFrame().GetMethod().Name
                                                                , BizException.ABORT, row);
                        }

                        int qty = row["PART_QTY"].toInt();

                        //int stockQty = rsltDT.Rows[0]["PART_QTY"].toInt();
                        //decimal totYpgoAmt = rsltDT.Rows[0]["TOT_YPGO_AMT"].toDecimal();

                        Dictionary<string, decimal> amtDic = new Dictionary<string, decimal>();
                        Dictionary<string, int> qtyDic = new Dictionary<string, int>();

                        foreach (DataRow rw in rsltDT.Rows)
                        {
                            string stkLoc = rw["STOCK_LOC"].ToString();

                            if (!amtDic.ContainsKey(stkLoc))
                            {
                                amtDic.Add(stkLoc, rw["TOT_YPGO_AMT"].toDecimal());
                            }

                            if (!qtyDic.ContainsKey(stkLoc))
                            {
                                qtyDic.Add(stkLoc, rw["PART_QTY"].toInt());
                            }

                            dtStock.Clear();

                            if (qty == 0) break;

                            int outQty = 0;

                            if ((rw["REMAIN_QTY"].toInt() - qty) >= 0)
                            {
                                outQty = qty;
                                qty = 0;
                            }
                            else
                            {
                                outQty = rw["REMAIN_QTY"].toInt();
                                qty = qty - rw["REMAIN_QTY"].toInt();
                            }

                            DataRow drOut = dtStock.NewRow();
                            drOut["PLT_CODE"] = row["PLT_CODE"];
                            drOut["PART_CODE"] = row[part_code];
                            drOut["STK_ID"] = rw["STK_ID"];
                            drOut["LOT_ID"] = rw["LOT_ID"];
                            drOut["STOCK_LOC"] = rw["STOCK_LOC"];
                            drOut["STOCK_FLAG"] = "OT";
                            drOut["GUBUN"] = "OT";
                            drOut["OUT_QTY"] = outQty;
                            drOut["OUT_COST"] = rw["UNIT_COST"];
                            drOut["OUT_AMT"] = drOut["OUT_QTY"].toDecimal() * drOut["OUT_COST"].toDecimal();

                            //totYpgoAmt = totYpgoAmt - drOut["OUT_AMT"].toDecimal();
                            //stockQty = stockQty - outQty;

                            //drOut["TOT_YPGO_AMT"] = totYpgoAmt;                            
                            //drOut["PART_QTY"] = stockQty;

                            amtDic[stkLoc] = amtDic[stkLoc] - drOut["OUT_AMT"].toDecimal();
                            qtyDic[stkLoc] = qtyDic[stkLoc] - outQty;

                            drOut["TOT_YPGO_AMT"] = amtDic[stkLoc];
                            drOut["PART_QTY"] = qtyDic[stkLoc];

                            drOut["OUT_ID"] = row["OUT_ID"];
                            drOut["YPGO_ID"] = rw["YPGO_ID"];
                            drOut["PROD_CODE"] = row["PROD_CODE"];


                            DataTable dt = new DataTable("RQSTDT");
                            dt.Columns.Add("PLT_CODE", typeof(String));
                            dt.Columns.Add("YPGO_ID", typeof(String));

                            DataRow vRow = dt.NewRow();
                            vRow["PLT_CODE"] = rw["PLT_CODE"];
                            vRow["YPGO_ID"] = rw["YPGO_ID"];

                             //DataTable vTable = DMAT.TMAT_YPGO_QUERY.TMAT_YPGO_QUERY8(UTIL.GetRowToDt(vRow), bizExecute);


                            //if (row.Table.Columns.Contains("CVND_CODE"))
                            //{
                            //    drOut["CVND_CODE"] = row["CVND_CODE"];
                            //}

                            dtStock.Rows.Add(drOut);

                            //데이터 처리 전에 로그부터 입력
                            SET_STOCK_LOG(drOut, bizExecute);

                            DMAT.TMAT_STOCK.TMAT_STOCK_UPD(dtStock, bizExecute);
                        }

                        

                        break;
                    }
                case "OUT_CANCEL"://출고 취소
                    {
                        if (outId.isNullOrEmpty())
                        {
                            throw UTIL.SetException("출고ID를 입력해주세요."
                                                            , null
                                                            , new System.Diagnostics.StackFrame().GetMethod().Name
                                                            , BizException.ABORT, row);
                        }

                        //DataTable rsltDt = DMAT.TMAT_STOCK_LOT_QUERY.TMAT_STOCK_LOT_QUERY2(UTIL.GetRowToDt(row), bizExecute);

                        //if (rsltDt.Rows.Count == 0)
                        //{
                        //    throw UTIL.SetException("출고 상태인 LOT이 존재하지 않습니다."
                        //                                        , row[part_code].toStringEmpty()
                        //                                        , new System.Diagnostics.StackFrame().GetMethod().Name
                        //                                        , BizException.ABORT, row);
                        //}
                        ////PART_CODE로 탐색
                        ////REG_DATE로 순차(선입선출)
                        //var dtSer = rsltDt
                        //                .AsEnumerable()
                        //                .ToList()
                        //                .GroupBy(g => new
                        //                {
                        //                    PLT_CODE = g["PLT_CODE"],
                        //                    PART_CODE = g["PART_CODE"],
                        //                    STK_ID = g["STK_ID"],
                        //                    STOCK_LOC = g["STOCK_LOC"]
                        //                })
                        //                .Select(r => new
                        //                {
                        //                    PLT_CODE = r.Key.PLT_CODE,
                        //                    PART_CODE = r.Key.PART_CODE,
                        //                    STK_ID = r.Key.STK_ID,
                        //                    STOCK_LOC = r.Key.STOCK_LOC,
                        //                    PART_QTY = r.Max(m => m["PART_QTY"].toDecimal()),
                        //                    TOT_YPGO_AMT = r.Max(m => m["TOT_YPGO_AMT"].toDecimal()),
                        //                    SUM_UNIT_COST = r.Sum(s => s["UNIT_COST"].toDecimal()),
                        //                    IN_PART_QTY = r.Count(),
                        //                    LOT_LIST = r.ToList()
                        //                });

                        //foreach (var serRow in dtSer)
                        //{
                        //    DataRow drOut = dtStock.NewRow();
                        //    drOut["PLT_CODE"] = row["PLT_CODE"];
                        //    drOut["PART_CODE"] = serRow.PART_CODE;
                        //    drOut["STK_ID"] = serRow.STK_ID;
                        //    drOut["STOCK_LOC"] = serRow.STOCK_LOC;
                        //    drOut["STOCK_FLAG"] = "YP";
                        //    drOut["GUBUN"] = "OC";
                        //    drOut["IN_QTY"] = serRow.LOT_LIST.Count;
                        //    drOut["IN_COST"] = serRow.SUM_UNIT_COST / serRow.LOT_LIST.Count;
                        //    drOut["IN_AMT"] = serRow.SUM_UNIT_COST;
                        //    drOut["TOT_YPGO_AMT"] = serRow.TOT_YPGO_AMT + serRow.SUM_UNIT_COST;
                        //    drOut["PART_QTY"] = serRow.PART_QTY + serRow.IN_PART_QTY;
                        //    dtStock.Rows.Add(drOut);

                        //    #region LOT 입고상태로 변경

                        //    foreach (DataRow lotRow in serRow.LOT_LIST)
                        //    {
                        //        DataRow dtStockLotRow = dtStockLot.NewRow();
                        //        dtStockLotRow["PLT_CODE"] = ConnInfo.PLT_CODE;
                        //        dtStockLotRow["LOT_ID"] = lotRow["LOT_ID"];
                        //        dtStockLotRow["STK_ID"] = lotRow["STK_ID"];
                        //        dtStockLotRow["STOCK_FLAG"] = "YP";
                        //        dtStockLotRow["OUT_ID"] = null;
                        //        dtStockLot.Rows.Add(dtStockLotRow);
                        //    }

                        //    #endregion

                        //    //데이터 처리 전에 로그부터 입력
                        //    SET_STOCK_LOG(drOut, dtStockLot, bizExecute);

                        //    DMAT.TMAT_STOCK.TMAT_STOCK_UPD(dtStock, bizExecute);
                        //    DMAT.TMAT_STOCK_LOT.TMAT_STOCK_LOT_UPD(dtStockLot, bizExecute); //상태변경
                        //    DMAT.TMAT_STOCK_LOT.TMAT_STOCK_LOT_UPD2(dtStockLot, bizExecute); //OUT_ID 변경(취소에서는 삭제)
                        //}

                        DataTable rsltDt = DMAT.TMAT_STOCK_LOG_DETAIL_QUERY.TMAT_STOCK_LOG_DETAIL_QUERY2(UTIL.GetRowToDt(row), bizExecute);

                        if (rsltDt.Rows.Count == 0)
                        {
                            throw UTIL.SetException("출고 상태인 LOT이 존재하지 않습니다."
                                                                , row[part_code].toStringEmpty()
                                                                , new System.Diagnostics.StackFrame().GetMethod().Name
                                                                , BizException.ABORT, row);
                        }


                        //int stockQty = 0;
                        //decimal totYpgoAmt = 0;

                        if (rsltDt.Rows.Count > 0)
                        {
                            //stockQty = rsltDt.Rows[0]["PART_QTY"].toInt();

                            //totYpgoAmt = rsltDt.Rows[0]["TOT_YPGO_AMT"].toInt();
                        }

                        Dictionary<string, decimal> amtDic = new Dictionary<string, decimal>();
                        Dictionary<string, int> qtyDic = new Dictionary<string, int>();

                        foreach (DataRow rw in rsltDt.Rows)
                        {
                            string stkLoc = rw["STOCK_LOC"].ToString();

                            if (!amtDic.ContainsKey(stkLoc))
                            {
                                amtDic.Add(stkLoc, rw["TOT_YPGO_AMT"].toDecimal());
                            }

                            if (!qtyDic.ContainsKey(stkLoc))
                            {
                                qtyDic.Add(stkLoc, rw["PART_QTY"].toInt());
                            }


                            dtStock.Clear();

                            DataRow drOut = dtStock.NewRow();
                            drOut["PLT_CODE"] = row["PLT_CODE"];
                            drOut["PART_CODE"] = rw["PART_CODE"];
                            drOut["DETAIL_PART_NAME"] = rw["DETAIL_PART_NAME"];
                            drOut["STK_ID"] = rw["STK_ID"];
                            drOut["LOT_ID"] = rw["LOT_ID"];
                            drOut["STOCK_LOC"] = rw["STOCK_LOC"];
                            drOut["STOCK_FLAG"] = "YP";
                            drOut["GUBUN"] = "OC";
                            drOut["IN_QTY"] = rw["OUT_QTY"];
                            drOut["IN_COST"] = rw["UNIT_COST"];
                            drOut["IN_AMT"] = rw["OUT_QTY"].toDecimal() * rw["UNIT_COST"].toDecimal();

                            //totYpgoAmt = totYpgoAmt + drOut["IN_AMT"].toDecimal();
                            //stockQty = stockQty + rw["OUT_QTY"].toInt();

                            //drOut["TOT_YPGO_AMT"] = totYpgoAmt;
                            //drOut["PART_QTY"] = stockQty;

                            amtDic[stkLoc] = amtDic[stkLoc] + drOut["IN_AMT"].toDecimal();
                            qtyDic[stkLoc] = qtyDic[stkLoc] + rw["OUT_QTY"].toInt();

                            drOut["TOT_YPGO_AMT"] = amtDic[stkLoc];
                            drOut["PART_QTY"] = qtyDic[stkLoc];

                            //drOut["TOT_YPGO_AMT"] = rw["TOT_YPGO_AMT"].toDecimal() + drOut["IN_AMT"].toDecimal();
                            //drOut["PART_QTY"] = rw["PART_QTY"].toInt() + drOut["IN_QTY"].toInt();

                            drOut["YPGO_ID"] = rw["YPGO_ID"];

                            //if (row.Table.Columns.Contains("CVND_CODE"))
                            //{
                            //    drOut["CVND_CODE"] = row["CVND_CODE"];
                            //}

                            dtStock.Rows.Add(drOut);

                            //데이터 처리 전에 로그부터 입력
                            SET_STOCK_LOG(drOut, bizExecute);

                            DMAT.TMAT_STOCK.TMAT_STOCK_UPD(dtStock, bizExecute);
                        }

                        break;
                    }
                case "OUT_CANCEL_MIL"://밀링실 출고 취소(임시 사용)
                    {
                        if (outId.isNullOrEmpty())
                        {
                            throw UTIL.SetException("출고ID를 입력해주세요."
                                                            , null
                                                            , new System.Diagnostics.StackFrame().GetMethod().Name
                                                            , BizException.ABORT, row);
                        }

                        //DataTable rsltDt = DMAT.TMAT_STOCK_LOT_QUERY.TMAT_STOCK_LOT_QUERY3(UTIL.GetRowToDt(row), bizExecute);

                        //if (rsltDt.Rows.Count == 0)
                        //{
                        //    throw UTIL.SetException("출고 상태인 LOT이 존재하지 않습니다."
                        //                                        , row[part_code].toStringEmpty()
                        //                                        , new System.Diagnostics.StackFrame().GetMethod().Name
                        //                                        , BizException.ABORT, row);
                        //}
                        ////PART_CODE로 탐색
                        ////REG_DATE로 순차(선입선출)
                        //var dtSer = rsltDt
                        //                .AsEnumerable()                                        
                        //                .ToList()
                        //                .GetRange(0, row[partQty].toInt())
                        //                .GroupBy(g => new
                        //                {
                        //                    PLT_CODE = g["PLT_CODE"],
                        //                    PART_CODE = g["PART_CODE"],
                        //                    STK_ID = g["STK_ID"],
                        //                    STOCK_LOC = g["STOCK_LOC"]
                        //                })
                        //                .Select(r => new
                        //                {
                        //                    PLT_CODE = r.Key.PLT_CODE,
                        //                    PART_CODE = r.Key.PART_CODE,
                        //                    STK_ID = r.Key.STK_ID,
                        //                    STOCK_LOC = r.Key.STOCK_LOC,
                        //                    PART_QTY = r.Max(m => m["PART_QTY"].toDecimal()),
                        //                    TOT_YPGO_AMT = r.Max(m => m["TOT_YPGO_AMT"].toDecimal()),
                        //                    SUM_UNIT_COST = r.Sum(s => s["UNIT_COST"].toDecimal()),
                        //                    IN_PART_QTY = r.Count(),
                        //                    LOT_LIST = r.ToList()
                        //                });


                        //foreach (var serRow in dtSer)
                        //{
                        //    DataRow drOut = dtStock.NewRow();
                        //    drOut["PLT_CODE"] = row["PLT_CODE"];
                        //    drOut["PART_CODE"] = serRow.PART_CODE;
                        //    drOut["STK_ID"] = serRow.STK_ID;
                        //    drOut["STOCK_LOC"] = serRow.STOCK_LOC;
                        //    drOut["STOCK_FLAG"] = "YP";
                        //    drOut["GUBUN"] = "OC";
                        //    drOut["IN_QTY"] = serRow.LOT_LIST.Count;
                        //    drOut["IN_COST"] = serRow.SUM_UNIT_COST / serRow.LOT_LIST.Count;
                        //    drOut["IN_AMT"] = serRow.SUM_UNIT_COST;
                        //    drOut["TOT_YPGO_AMT"] = serRow.TOT_YPGO_AMT + serRow.SUM_UNIT_COST;
                        //    drOut["PART_QTY"] = serRow.PART_QTY + serRow.IN_PART_QTY;
                        //    dtStock.Rows.Add(drOut);

                        //    #region LOT 입고상태로 변경

                        //    foreach (DataRow lotRow in serRow.LOT_LIST)
                        //    {
                        //        DataRow dtStockLotRow = dtStockLot.NewRow();
                        //        dtStockLotRow["PLT_CODE"] = ConnInfo.PLT_CODE;
                        //        dtStockLotRow["LOT_ID"] = lotRow["LOT_ID"];
                        //        dtStockLotRow["STK_ID"] = lotRow["STK_ID"];
                        //        dtStockLotRow["STOCK_FLAG"] = "YP";
                        //        dtStockLotRow["OUT_ID"] = null;
                        //        //dtStockLotRow["CUTTING_CNT"] = lotRow["STD_CUTTING_CNT"];


                        //        // 아래 조건문 변경 2021-11-08 pkd
                        //        // 원본: lotRow["STD_CUTTING_CNT"].toInt() > lotRow["CUTTING_CNT"].toInt()

                        //        if(lotRow["CUTTING_CNT"].toInt() > lotRow["STD_CUTTING_CNT"].toInt())
                        //            throw UTIL.SetException("출고된 Lot이 이미 사용되었습니다."
                        //                                        , row[part_code].toStringEmpty()
                        //                                        , new System.Diagnostics.StackFrame().GetMethod().Name
                        //                                        , BizException.ABORT, row);

                        //        dtStockLot.Rows.Add(dtStockLotRow);
                        //    }

                        //    #endregion

                        //    SET_STOCK_LOG(drOut, dtStockLot, bizExecute);

                        //    DMAT.TMAT_STOCK.TMAT_STOCK_UPD(dtStock, bizExecute);
                        //    DMAT.TMAT_STOCK_LOT.TMAT_STOCK_LOT_UPD(dtStockLot, bizExecute); //상태변경
                        //    DMAT.TMAT_STOCK_LOT.TMAT_STOCK_LOT_UPD2(dtStockLot, bizExecute); //OUT_ID 변경(취소에서는 삭제)
                        //    DMAT.TMAT_STOCK_LOT.TMAT_STOCK_LOT_UPD5(dtStockLot, bizExecute); //cutting 수량 복권
                        //}


                        DataTable rsltDT = DMAT.TMAT_STOCK_LOG_DETAIL_QUERY.TMAT_STOCK_LOG_DETAIL_QUERY2(UTIL.GetRowToDt(row), bizExecute);

                        if (rsltDT.Rows.Count == 0)
                        {
                            throw UTIL.SetException("출고 상태인 LOT이 존재하지 않습니다."
                                                                , row[part_code].toStringEmpty()
                                                                , new System.Diagnostics.StackFrame().GetMethod().Name
                                                                , BizException.ABORT, row);
                        }

                        //int stockQty = rsltDT.Rows[0]["PART_QTY"].toInt();

                        //decimal totYpgoAmt = rsltDT.Rows[0]["TOT_YPGO_AMT"].toDecimal2();

                        Dictionary<string, decimal> amtDic = new Dictionary<string, decimal>();
                        Dictionary<string, int> qtyDic = new Dictionary<string, int>();

                        foreach (DataRow rw in rsltDT.Rows)
                        {
                            string stkLoc = rw["STOCK_LOC"].ToString();

                            if (!amtDic.ContainsKey(stkLoc))
                            {
                                amtDic.Add(stkLoc, rw["TOT_YPGO_AMT"].toDecimal());
                            }

                            if (!qtyDic.ContainsKey(stkLoc))
                            {
                                qtyDic.Add(stkLoc, rw["PART_QTY"].toInt());
                            }


                            dtStock.Clear();

                            DataRow drOut = dtStock.NewRow();
                            drOut["PLT_CODE"] = row["PLT_CODE"];
                            drOut["PART_CODE"] = row[part_code];
                            drOut["STK_ID"] = rw["STK_ID"];
                            drOut["LOT_ID"] = rw["LOT_ID"];
                            drOut["STOCK_LOC"] = rw["STOCK_LOC"];
                            drOut["STOCK_FLAG"] = "YP";
                            drOut["GUBUN"] = "OC";
                            drOut["IN_QTY"] = rw["OUT_QTY"];
                            drOut["IN_COST"] = rw["UNIT_COST"];
                            drOut["IN_AMT"] = drOut["IN_QTY"].toDecimal() * drOut["IN_COST"].toDecimal();

                            //totYpgoAmt = totYpgoAmt + drOut["IN_AMT"].toDecimal();
                            //stockQty = stockQty + drOut["IN_QTY"].toInt();

                            //drOut["TOT_YPGO_AMT"] = totYpgoAmt; 
                            //drOut["PART_QTY"] = stockQty;

                            amtDic[stkLoc] = amtDic[stkLoc] + drOut["IN_AMT"].toDecimal();
                            qtyDic[stkLoc] = qtyDic[stkLoc] + drOut["IN_QTY"].toInt();

                            drOut["TOT_YPGO_AMT"] = amtDic[stkLoc];
                            drOut["PART_QTY"] = qtyDic[stkLoc];

                            drOut["OUT_ID"] = row["OUT_ID"];
                            drOut["YPGO_ID"] = rw["YPGO_ID"];
                            dtStock.Rows.Add(drOut);

                            //데이터 처리 전에 로그부터 입력
                            SET_STOCK_LOG(drOut, bizExecute);

                            DMAT.TMAT_STOCK.TMAT_STOCK_UPD(dtStock, bizExecute);
                        }


                        break;
                    }

            }

        }
        #endregion
        /// <summary>
        /// 재고 내역 생성
        /// </summary>
        /// <param name="row">PLT_CODE, PART_CODE, GUBUN, STOCK_TYPE, STOCK_CODE, IN_QTY, OUT_QTY, GUBUN, SCOMMENT</param>
        /// <param name="bizExecute"></param>
        public static void SET_STOCK_LOG(DataRow row, BizExecute.BizExecute bizExecute)
        {
            try
            {
                int prev_qty = 0, next_qty = 0;
                int in_qty = row["IN_QTY"].toInt32();
                int out_qty = row["OUT_QTY"].toInt32();
                string scomment = string.Empty;

                decimal prev_cost = 0, next_cost = 0;
                decimal in_cost = row["IN_COST"].toDecimal2();
                decimal out_cost = row["OUT_COST"].toDecimal2();

                decimal prev_amt = 0, next_amt = 0;
                decimal in_amt = row["IN_AMT"].toDecimal2();
                decimal out_amt = row["OUT_AMT"].toDecimal2();

                if (row["DETAIL_PART_NAME"].ToString() == "")
                {
                    row["DETAIL_PART_NAME"] = "N";
                }

                DataTable dtPrevStock = DMAT.TMAT_STOCK_LOG_QUERY.TMAT_STOCK_LOG_QUERY2(UTIL.GetRowToDt(row), bizExecute);

                if (row["DETAIL_PART_NAME"].ToString() == "N")
                {
                    row["DETAIL_PART_NAME"] = null;
                }

                if (dtPrevStock.Rows.Count > 0)
                {
                    prev_qty = dtPrevStock.Rows[0]["NEXT_QTY"].toInt32();
                    prev_amt = dtPrevStock.Rows[0]["NEXT_AMT"].toDecimal2();

                    if(row["STOCK_FLAG"].ToString() == "NE")
                    {
                        //신규로 들어왔지만, 이전 기록이 존재한다면 재고조정으로 이력 변경
                        row["STOCK_FLAG"] = "SA"; 
                    }
                }
                else
                {
                    DataTable nowStock = DMAT.TMAT_STOCK.TMAT_STOCK_SER2(UTIL.GetRowToDt(row), bizExecute);
                    if (nowStock.Rows.Count > 0)
                    {
                        prev_qty = nowStock.Rows[0]["PART_QTY"].toInt32();
                        prev_amt = nowStock.Rows[0]["TOT_YPGO_AMT"].toDecimal2();
                    }
                }

                DataTable dtHisParam = new DataTable();
                dtHisParam.Columns.Add("PLT_CODE", typeof(String));
                dtHisParam.Columns.Add("PART_CODE", typeof(String));
                dtHisParam.Columns.Add("DETAIL_PART_NAME", typeof(String));
                dtHisParam.Columns.Add("EVENT_TIME", typeof(DateTime));
                dtHisParam.Columns.Add("STOCK_FLAG", typeof(String));
                dtHisParam.Columns.Add("STOCK_LOC", typeof(String));
                dtHisParam.Columns.Add("GUBUN", typeof(String));
                dtHisParam.Columns.Add("PREV_QTY", typeof(int));
                //dtHisParam.Columns.Add("PRE_COST", typeof(decimal));
                dtHisParam.Columns.Add("PREV_AMT", typeof(decimal));
                dtHisParam.Columns.Add("IN_QTY", typeof(int));
                dtHisParam.Columns.Add("IN_COST", typeof(decimal));
                dtHisParam.Columns.Add("IN_AMT", typeof(decimal));
                dtHisParam.Columns.Add("OUT_QTY", typeof(int));
                dtHisParam.Columns.Add("OUT_COST", typeof(decimal));
                dtHisParam.Columns.Add("OUT_AMT", typeof(decimal));
                dtHisParam.Columns.Add("NEXT_QTY", typeof(int));
                //dtHisParam.Columns.Add("NEXT_COST", typeof(decimal));
                dtHisParam.Columns.Add("NEXT_AMT", typeof(decimal));
                dtHisParam.Columns.Add("SCOMMENT", typeof(String));
                dtHisParam.Columns.Add("STK_ID", typeof(String));
                dtHisParam.Columns.Add("REG_EMP", typeof(String));

                dtHisParam.Columns.Add("LOG_DETAIL_ID", typeof(String));
                dtHisParam.Columns.Add("LOG_ID", typeof(String));
                dtHisParam.Columns.Add("UNIT_COST", typeof(String));
                dtHisParam.Columns.Add("YPGO_ID", typeof(String));
                dtHisParam.Columns.Add("OUT_ID", typeof(String));
                dtHisParam.Columns.Add("LOT_ID", typeof(String));
                dtHisParam.Columns.Add("PROD_CODE", typeof(String));
                dtHisParam.Columns.Add("CVND_CODE", typeof(String));

                DataRow drHisrow = dtHisParam.NewRow();
                drHisrow["PLT_CODE"] = row["PLT_CODE"];
                drHisrow["PART_CODE"] = row["PART_CODE"];
                drHisrow["DETAIL_PART_NAME"] = row["DETAIL_PART_NAME"];

                //입고(YP), 출고(OT), 재고생성(AD), 입고취소(YC)
                drHisrow["STOCK_FLAG"] = row["STOCK_FLAG"];
                drHisrow["STOCK_LOC"] = row["STOCK_LOC"];
                drHisrow["GUBUN"] = row["GUBUN"];

                next_qty = prev_qty + in_qty - out_qty;

                next_amt = prev_amt + in_amt - out_amt;

                switch (row["STOCK_FLAG"].ToString())
                {
                    case "OT":
                        drHisrow["SCOMMENT"] = string.Format("{0} → {1} ", prev_qty, next_qty);
                        break;
                    //case "MV":
                    //    drHisrow["SYS_COMMENT"] = "";
                    //    break;
                    case "NE":
                        next_qty = in_qty;
                        if (in_qty > 0)
                            next_cost = in_amt / in_qty;
                        else
                            next_cost = 0;
                        next_amt = in_amt;
                        break;
                }


                drHisrow["PREV_QTY"] = prev_qty;
                drHisrow["PREV_AMT"] = prev_amt;
                drHisrow["NEXT_QTY"] = next_qty;
                drHisrow["NEXT_AMT"] = next_amt;
                drHisrow["IN_QTY"] = in_qty;
                drHisrow["IN_COST"] = in_cost;
                drHisrow["IN_AMT"] = in_amt;
                drHisrow["OUT_QTY"] = out_qty;
                drHisrow["OUT_COST"] = out_cost;
                drHisrow["OUT_AMT"] = out_amt;
                drHisrow["REG_EMP"] = ConnInfo.UserID;
                drHisrow["STK_ID"] = row["STK_ID"];
                drHisrow["SCOMMENT"] = row["SCOMMENT"].ToString();

                //drHisrow["LOG_DETAIL_ID"] = row["LOG_DETAIL_ID"];
                //drHisrow["LOG_ID"] = row["LOG_ID"];
                drHisrow["UNIT_COST"] = in_cost == 0 ? out_cost : in_cost;
                drHisrow["YPGO_ID"] = row["YPGO_ID"];
                drHisrow["OUT_ID"] = row["OUT_ID"];
                drHisrow["LOT_ID"] = row["LOT_ID"];
                if (row.Table.Columns.Contains("PROD_CODE"))
                {

                    drHisrow["PROD_CODE"] = row["PROD_CODE"];
                }

                //if (row.Table.Columns.Contains("CVND_CODE"))
                //{

                //    drHisrow["CVND_CODE"] = row["CVND_CODE"];
                //}

                dtHisParam.Rows.Add(drHisrow);

                object identity = DMAT.TMAT_STOCK_LOG.TMAT_STOCK_LOG_INS(dtHisParam, bizExecute);

                //LOG DETAIL INSERT
                if (dtHisParam.Rows[0]["LOT_ID"].ToString() == "")
                {
                    dtHisParam.Rows[0]["LOT_ID"] = UTIL.UTILITY_GET_SERIALNO(ConnInfo.PLT_CODE, "SLOT", UTIL.emSerialFormat.YYMMDDHH, "W", bizExecute);
                }

                dtHisParam.Rows[0]["LOG_DETAIL_ID"] = UTIL.UTILITY_GET_SERIALNO(ConnInfo.PLT_CODE, "LD", UTIL.emSerialFormat.YYMMDDHH, "W", bizExecute);

                dtHisParam.Rows[0]["LOG_ID"] = identity;

                DMAT.TMAT_STOCK_LOG_DETAIL.TMAT_STOCK_LOG_DETAIL_INS(dtHisParam, bizExecute);

            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        /// <summary>
        /// 사용자별 게시판 읽음 표시
        /// </summary>
        /// <param name="paramDS">
        /// PLT_CODE
        /// EMP_CODE
        /// BOARD_ID
        /// </param>
        public static DataSet SET_BOARD_READ(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable dtSer = DSYS.TSYS_BOARD_EMP.TSYS_BOARD_EMP_SER(paramDS.Tables["RQSTDT"],bizExecute);

                if (dtSer.Rows.Count == 0)                                    
                {
                    DataRow row = paramDS.Tables["RQSTDT"].Rows[0];

                    string serial = UTIL.UTILITY_GET_SERIALNO(row["PLT_CODE"].ToString(), "BRDE", bizExecute);

                    UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "BOARD_EMP_ID", serial, typeof(String));
                    //UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "BOARD_ID", row["BOARD_ID"].ToString(), typeof(String));

                    DSYS.TSYS_BOARD_EMP.TSYS_BOARD_EMP_INS(UTIL.GetRowToDt(row), bizExecute);
                    //DSYS.TSYS_BOARD_EMP.TSYS_BOARD_EMP_INS(paramDS.Tables["RQSTDT"], bizExecute);
                }

                DSYS.TSYS_BOARD_EMP.TSYS_BOARD_EMP_UPD(paramDS.Tables["RQSTDT"], bizExecute);

                DSYS.TSYS_BOARD.TSYS_BOARD_UPD2(paramDS.Tables["RQSTDT"], bizExecute);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet SET_WORK_READ(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable dtSer = DSHP.TSHP_WORK_MNG_EMP.TSHP_WORK_MNG_EMP_SER(paramDS.Tables["RQSTDT"], bizExecute);

                if (dtSer.Rows.Count > 0)
                {
                    DSHP.TSHP_WORK_MNG_EMP.TSHP_WORK_MNG_EMP_UPD2(paramDS.Tables["RQSTDT"], bizExecute);
                }

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet SET_OUT_REQ_READ(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "IS_POPUP", "1", typeof(String));
                DataTable dtSer = DMAT.TMAT_OUT_REQ_EMP.TMAT_OUT_REQ_EMP_SER(paramDS.Tables["RQSTDT"], bizExecute);

                if (dtSer.Rows.Count > 0)
                {
                    DMAT.TMAT_OUT_REQ_EMP.TMAT_OUT_REQ_EMP_UPD(paramDS.Tables["RQSTDT"], bizExecute);
                }

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet SET_NG_READ(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "IS_POPUP", "1", typeof(String));
                DataTable dtSer = DSHP.TSHP_NG_EMP.TSHP_NG_EMP_SER(paramDS.Tables["RQSTDT"], bizExecute);

                if (dtSer.Rows.Count > 0)
                {
                    DSHP.TSHP_NG_EMP.TSHP_NG_EMP_UPD(paramDS.Tables["RQSTDT"], bizExecute);
                }

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet SET_PROD_READ(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                
                DataTable dtSer = DORD.TORD_PRODUCT_IF.TORD_PRODUCT_IF_SER(paramDS.Tables["RQSTDT"], bizExecute);

                if (dtSer.Rows.Count > 0)
                {
                    DORD.TORD_PRODUCT_IF.TORD_PRODUCT_IF_DEL(paramDS.Tables["RQSTDT"], bizExecute);
                }

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet SET_DEV_READ(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {

                DataTable dtSer = DORD.TORD_PRODUCT_SEND_DEV.TORD_PRODUCT_SEND_DEV_SER(paramDS.Tables["RQSTDT"], bizExecute);

                if (dtSer.Rows.Count > 0)
                {
                    DORD.TORD_PRODUCT_SEND_DEV.TORD_PRODUCT_SEND_DEV_DEL(paramDS.Tables["RQSTDT"], bizExecute);
                }

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static TimeSpan GetWorkStartTime(DateTime date, BizExecute.BizExecute bizExecute)
        {

            try
            {

                string confName = null;

                if (date.DayOfWeek == DayOfWeek.Sunday)
                {
                    //일요일

                    confName = "SUN_WORK_TIME";

                }
                else if (date.DayOfWeek == DayOfWeek.Saturday)
                {
                    //토요일
                    confName = "SAT_WORK_TIME";

                }
                else
                {
                    //평일

                    confName = "NOR_WORK_TIME";
                }

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("CONF_SECTION", typeof(String)); //
                paramTable.Columns.Add("CONF_NAME", typeof(String)); //

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = ConnInfo.PLT_CODE;
                paramRow["CONF_SECTION"] = "SYS";
                paramRow["CONF_NAME"] = confName;
                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);


                DataSet resultSet = GET_SYS_CONFIG(paramSet, bizExecute);

                //DataSet resultSet = BizManager.acControls.GET_SYS_CONFIG(paramSet);

                string value = resultSet.Tables["RSLTDT"].Rows[0]["CONF_VALUE"].toStringNull();

                string[] values = value.Split(',');

                return values[0].toTimeSpan();


            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public static DataSet SET_EMAILSEND_LOG(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {

            try
            {
                DSYS.TSYS_EMAILSEND_LOG.TSYS_EMAILSEND_LOG_INS(paramDS.Tables["RQSTDT"], bizExecute);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }


        public static DataSet SET_PRINT_LOG(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {

            try
            {
                DSYS.TSYS_PRINT_LOG.TSYS_PRINT_LOG_INS(paramDS.Tables["RQSTDT"], bizExecute);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet CTRL_EXECUTE_LOG(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {

            try
            {
                DSYS.TSYS_EXECUTE_LOG.TSYS_EXECUTE_LOG_INS(paramDS.Tables["RQSTDT"], bizExecute);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }


        public static void EXECUTE_LOG(string execut_type,BizExecute.BizExecute bizExecute)
        {

            try
            {
                DataTable dt = new DataTable("RQSTDT");
                dt.Columns.Add("useSe", typeof(string));
                DataRow row = dt.NewRow();
                row["useSe"] = execut_type;
                dt.Rows.Add(row);

                DSYS.TSYS_EXECUTE_LOG.TSYS_EXECUTE_LOG_INS(dt, bizExecute);
                
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }


        public static string GetPartToMcGroup(string part_code, string proc_code, string pt_id , BizExecute.BizExecute bizExecute)
        {

            DataTable dtParam = new DataTable("RQSTDT");
            UTIL.SetBizAddColumnToValue(dtParam, "PLT_CODE", ConnInfo.PLT_CODE, typeof(string));
            UTIL.SetBizAddColumnToValue(dtParam, "PART_CODE", part_code, typeof(string));
            UTIL.SetBizAddColumnToValue(dtParam, "PT_ID", pt_id, typeof(string));
            //UTIL.SetBizAddColumnToValue(dtParam, "PROC_CODE", proc_code, typeof(string));


            DataTable dtRlstPart = DLSE.LSE_STD_PART.LSE_STD_PART_SER(dtParam, bizExecute);
            DataTable dtRlstPartlist = DMAT.TMAT_PARTLIST.TMAT_PARTLIST_SER(dtParam, bizExecute);


            if (dtRlstPart.Rows.Count == 0)
                return "A";//임시로 'A' 

            if (proc_code != "")
            {
                if (proc_code == "P-07")
                {
                    return "F";
                }
            }

            DataTable dtCdParam = new DataTable("RQSTDT");
            dtCdParam.Columns.Add("PLT_CODE", typeof(String));
            dtCdParam.Columns.Add("CAT_CODE", typeof(String));
            dtCdParam.Columns.Add("DATA_FLAG", typeof(byte));

            DataRow CdRow = dtCdParam.NewRow();
            CdRow["PLT_CODE"] = ConnInfo.PLT_CODE;
            CdRow["CAT_CODE"] = "R001";
            CdRow["DATA_FLAG"] = 0;
            dtCdParam.Rows.Add(CdRow);

            DataTable dtMatSuji = DSTD.TSTD_CODES_QUERY.TSTD_CODES_QUERY7(dtCdParam, bizExecute);

            bool isMatSuji = true;

            string part_name = dtRlstPart.Rows[0]["PART_NAME"].ToString().ToUpper();

            string mat_qlty = dtRlstPartlist.Rows[0]["Material"].ToString().ToUpper();

            string tab_machine = dtRlstPartlist.Rows[0]["Tab_Machine"].ToString();

            string slit_division = dtRlstPartlist.Rows[0]["Slit_Division"].ToString();

            string make_sidehole = dtRlstPartlist.Rows[0]["MakeSideHole"].ToString();

            foreach (DataRow row in dtMatSuji.Rows)
            {
                if (mat_qlty.Contains(row["CD_CODE"].ToString().ToUpper()))
                {
                    isMatSuji = false;
                    break;
                }
            }


            //resin
            dtCdParam.Rows[0]["CAT_CODE"] = "R009";
            DataTable dtResin = DSTD.TSTD_CODES_QUERY.TSTD_CODES_QUERY7(dtCdParam, bizExecute);

            bool isResin = false;

            string upperMatQlty = mat_qlty;

            upperMatQlty = upperMatQlty.ToUpper();

            foreach (DataRow row in dtResin.Rows)
            {
                if (upperMatQlty.ToString() == "") continue;

                if (upperMatQlty.Contains(row["CD_NAME"].ToString().ToUpper()))
                {
                    isResin = true;
                    break;
                }
            }

            if (isResin)
            {
                return "F";
            }

            //if (isMatSuji && (new string[] { "Leaver", "Pusher" }).Contains(part_name))
            if (isMatSuji && (part_name.Contains("Leaver".ToUpper()) || part_name.Contains("Pusher".ToUpper())))
            {
                return "A";
            }
            else if (isMatSuji && tab_machine == "1")
            {
                return "B";
            }
            else if (isMatSuji && 
                (part_name.Contains("Floating Plate".ToUpper())
                || part_name.Contains("Bottom Plate".ToUpper())
                || part_name.Contains("Middle Plate".ToUpper())
                || part_name.Contains("Floating_Plate".ToUpper())
                || part_name.Contains("Bottom_Plate".ToUpper())
                || part_name.Contains("Middle_Plate".ToUpper())
                ))
            {
                return "C";
            }
            else if (isMatSuji)
            {
                return "D";
            }
            else if (mat_qlty.Contains("AL".ToUpper())
                    || mat_qlty.Contains("Brass".ToUpper())
                    || mat_qlty.Contains("Be-Cu".ToUpper()))
            {
                return "E";
            }
            else if (make_sidehole == "1" && slit_division == "1")
            {
                return "F";
            }


            //if ((new string[] { "Floating Plate", "Middle Plate", "Bottom Plate", "Pin Block Cover" }).Contains(part_name) && !mat_qlty.Contains("AL"))
            //{
            //    return "A";
            //}
            //else if ((new string[] { "Floating Plate", "Middle Plate", "Bottom Plate" }).Contains(part_name) && tab_machine == "1")
            //{
            //    return "B";
            //}
            //else if ((new string[] { "정의필요", "", "" }).Contains(part_name) && !mat_qlty.Contains("AL"))
            //{
            //    return "C";
            //}
            //else if (mat_qlty.Contains("플라스틱"))
            //{
            //    return "D";
            //}
            //else if (mat_qlty.Contains("AL"))
            //{
            //    return "E";
            //}
            //else if (slit_division == "1")
            //{
            //    return "F";
            //}

            return "A";//임시로 'A' 
        }

        public static string GetPartToRoutGroup(string prod_code, string part_code, string pt_id, BizExecute.BizExecute bizExecute)
        {

            DataTable dtParam = new DataTable("RQSTDT");
            UTIL.SetBizAddColumnToValue(dtParam, "PLT_CODE", ConnInfo.PLT_CODE, typeof(string));
            UTIL.SetBizAddColumnToValue(dtParam, "PROD_CODE", prod_code, typeof(string));
            UTIL.SetBizAddColumnToValue(dtParam, "PART_CODE", part_code, typeof(string));
            UTIL.SetBizAddColumnToValue(dtParam, "PT_ID", pt_id, typeof(string));

            DataTable dtRlstProd = DORD.TORD_PRODUCT.TORD_PRODUCT_SER(dtParam, bizExecute);

            DataTable dtRlstPart = DLSE.LSE_STD_PART.LSE_STD_PART_SER(dtParam, bizExecute);

            DataTable dtRlstPartlist = DMAT.TMAT_PARTLIST.TMAT_PARTLIST_SER(dtParam, bizExecute);

            if (dtRlstProd.Rows.Count == 0)
                return "4Group";//임시로 

            if (dtRlstPart.Rows.Count == 0)
                return "4Group";//임시로 

            string msop_yn = dtRlstProd.Rows[0]["MSOP_YN"].ToString();

            string actuator_yn = dtRlstProd.Rows[0]["ACTUATOR_YN"].ToString();

            string part_name = dtRlstPart.Rows[0]["PART_NAME"].ToString().ToUpper();

            string mat_qlty = dtRlstPartlist.Rows[0]["Material"].ToString().ToUpper();

            string tab_machine = dtRlstPartlist.Rows[0]["Tab_Machine"].ToString();

            string slit_division = dtRlstPartlist.Rows[0]["Slit_Division"].ToString();

            string makesidehole = dtRlstPartlist.Rows[0]["MakeSideHole"].ToString();

            string AfterTreat = dtRlstPartlist.Rows[0]["After_Treat"].ToString();

            string Surface_Treat = dtRlstPartlist.Rows[0]["Surface_Treat"].ToString();

            if (msop_yn == "")
            {
                msop_yn = "1";
            }

            if (actuator_yn == "")
            {
                actuator_yn = "0";
            }

            if (makesidehole == "")
            {
                makesidehole = "0";
            }

            DataTable dtCdParam = new DataTable("RQSTDT");
            dtCdParam.Columns.Add("PLT_CODE", typeof(String));
            dtCdParam.Columns.Add("CAT_CODE", typeof(String));
            dtCdParam.Columns.Add("DATA_FLAG", typeof(byte));

            DataRow CdRow = dtCdParam.NewRow();
            CdRow["PLT_CODE"] = ConnInfo.PLT_CODE;
            CdRow["CAT_CODE"] = "R001";
            CdRow["DATA_FLAG"] = 0;
            dtCdParam.Rows.Add(CdRow);

            //외주가공
            dtCdParam.Rows[0]["CAT_CODE"] = "R002";
            DataTable dtOutMat = DSTD.TSTD_CODES_QUERY.TSTD_CODES_QUERY7(dtCdParam, bizExecute);
            dtCdParam.Rows[0]["CAT_CODE"] = "R003";
            DataTable dtOutPart = DSTD.TSTD_CODES_QUERY.TSTD_CODES_QUERY7(dtCdParam, bizExecute);

            bool isOut = false;
            foreach (DataRow row in dtOutMat.Rows)
            {
                if (mat_qlty.ToString() == "") continue;

                if (mat_qlty.Contains(row["CD_NAME"].ToString().ToUpper()))
                {
                    isOut = true;
                    break;
                }
            }

            if (!isOut)
            {
                foreach (DataRow row in dtOutPart.Rows)
                {
                    if (part_name.ToString() == "") continue;

                    if (part_name.Contains(row["CD_NAME"].ToString().ToUpper()))
                    {
                        isOut = true;
                        break;
                    }
                }
            }

            //CAM
            dtCdParam.Rows[0]["CAT_CODE"] = "R004";
            DataTable dtCamMat = DSTD.TSTD_CODES_QUERY.TSTD_CODES_QUERY7(dtCdParam, bizExecute);
            dtCdParam.Rows[0]["CAT_CODE"] = "R005";
            DataTable dtCamPart = DSTD.TSTD_CODES_QUERY.TSTD_CODES_QUERY7(dtCdParam, bizExecute);

            bool isCam = false;
            foreach (DataRow row in dtCamMat.Rows)
            {
                if (mat_qlty.ToString() == "") continue;

                if (mat_qlty.Contains(row["CD_NAME"].ToString().ToUpper()))
                {
                    foreach (DataRow rw in dtCamPart.Rows)
                    {
                        if (part_name.ToString() == "") continue;

                        if (part_name.Contains(rw["CD_NAME"].ToString().ToUpper()))
                        {
                            isCam = true;
                            break;
                        }
                    }
                }
            }

            //도금
            dtCdParam.Rows[0]["CAT_CODE"] = "R006";
            DataTable dtPaintMat = DSTD.TSTD_CODES_QUERY.TSTD_CODES_QUERY7(dtCdParam, bizExecute);
            dtCdParam.Rows[0]["CAT_CODE"] = "R007";
            DataTable dtPaintPart = DSTD.TSTD_CODES_QUERY.TSTD_CODES_QUERY7(dtCdParam, bizExecute);

            bool isPaint = false;
            foreach (DataRow row in dtPaintMat.Rows)
            {
                if (mat_qlty.ToString() == "") continue;

                if (mat_qlty.Contains(row["CD_NAME"].ToString().ToUpper()))
                {
                    isPaint = true;
                    break;
                }
            }

            if (!isPaint)
            {
                foreach (DataRow row in dtPaintPart.Rows)
                {
                    if (part_name.ToString() == "") continue;

                    if (part_name.Contains(row["CD_NAME"].ToString().ToUpper()))
                    {
                        isPaint = true;
                        break;
                    }
                }
            }

            //슬릿
            dtCdParam.Rows[0]["CAT_CODE"] = "R008";
            DataTable dtSlitPart = DSTD.TSTD_CODES_QUERY.TSTD_CODES_QUERY7(dtCdParam, bizExecute);

            bool isSlit = false;
            foreach (DataRow row in dtSlitPart.Rows)
            {
                if (part_name.ToString() == "") continue;

                //if (part_name.Contains(row["CD_NAME"].ToString().ToUpper()))
                if (part_name == row["CD_NAME"].ToString().ToUpper())
                {
                    isSlit = true;
                    break;
                }
            }

            if (slit_division == "1")
            {
                isSlit = true;
            }


            //resin (injection)
            dtCdParam.Rows[0]["CAT_CODE"] = "R009";
            DataTable dtResinPart = DSTD.TSTD_CODES_QUERY.TSTD_CODES_QUERY7(dtCdParam, bizExecute);

            bool isResin = false;

            string upperMatQlty = mat_qlty;
            upperMatQlty = upperMatQlty.ToUpper();

            foreach (DataRow row in dtResinPart.Rows)
            {
                if (upperMatQlty.ToString() == "") continue;

                if (upperMatQlty.Contains(row["CD_NAME"].ToString().ToUpper()))
                {
                    isResin = true;
                    break;
                }
            }



            //조립품 존재여부
            //DataTable dtAssey = DIF.IF_MES_BOM_QUERY.IF_MES_BOM_QUERY1(dtParam, bizExecute);
            DataTable dtAssey =  DMAT.TMAT_PARTLIST.TMAT_PARTLIST_SER4(dtParam, bizExecute);



            string routGroup = "6Group";

            if (part_code.Substring(0, 1) == "A")
            {
                routGroup = "1Group";

                if (msop_yn.Contains("0") && actuator_yn == "1")
                {
                    routGroup = "1Group";
                }
                else if (msop_yn.Contains("1") && (actuator_yn == "0" || actuator_yn == "3" || actuator_yn == "2"))
                {
                    routGroup = "2Group";
                }
                else if (msop_yn.Contains("0") && (actuator_yn == "0" || actuator_yn == "3" || actuator_yn == "2"))
                {
                    routGroup = "12Group";
                }
                else if (msop_yn.Contains("1") && actuator_yn == "1")
                {
                    routGroup = "13Group";
                }
            }
            else if (part_code.Substring(0, 1) == "M")
            {

                if (dtAssey.Rows.Count == 0)
                {
                    routGroup = "3Group";
                }
                else if (isResin)
                {
                    routGroup = "14Group";
                }
                else if (isOut)
                {
                    routGroup = "4Group";
                }
                else if (isCam)
                {
                    routGroup = "5Group";
                }
                else if (isPaint && makesidehole == "1")
                {
                    if ((AfterTreat == "" || AfterTreat == "-")
                        && (Surface_Treat == "" || Surface_Treat == "-"))
                    {
                        routGroup = "10Group";
                    }
                    else
                    {
                        routGroup = "6Group";
                    }
                }
                else if (isPaint && makesidehole == "0")
                {
                    if ((AfterTreat == "" || AfterTreat == "-")
                        && (Surface_Treat == "" || Surface_Treat == "-"))
                    {
                        routGroup = "11Group";
                    }
                    else
                    {
                        routGroup = "7Group";
                    }
                }
                else if (isSlit && makesidehole == "1")
                {
                    if (upperMatQlty.Contains("ULTEM1000"))
                    {
                        routGroup = "15Group";
                    }
                    else
                    {
                        routGroup = "8Group";
                    }                    
                }
                else if (isSlit && makesidehole == "0")
                {
                    if (upperMatQlty.Contains("ULTEM1000"))
                    {
                        routGroup = "15Group";
                    }
                    else
                    {
                        routGroup = "9Group";
                    }
                }
                else if (makesidehole == "1")
                {
                    routGroup = "10Group";
                }
                else if (makesidehole == "0")
                {
                    routGroup = "11Group";
                }
                else
                {
                    routGroup = "11Group";
                }

                #region
                //if (part_name.Contains("Collet"))
                //{
                //    routGroup = "7Group";
                //}
                //else if (mat_qlty.Contains("SKD11")
                //        || mat_qlty.Contains("Steel")
                //        || mat_qlty.Contains("SUS"))
                //{
                //    routGroup = "8Group";
                //}
                //else if (part_name.Contains("PCB")
                //        || mat_qlty.Contains("ACRYLIC"))
                //{
                //    routGroup = "9Group";
                //}
                //else if (slit_division == "스톤" || slit_division == "브라운")
                //{
                //    routGroup = "3Group";
                //}
                //else if (mat_qlty.Contains("AL") && makesidehole == "1")
                //{
                //    routGroup = "4Group";
                //}
                //else if (makesidehole == "1")
                //{
                //    routGroup = "5Group";
                //}
                //else if (makesidehole == "0")
                //{
                //    routGroup = "6Group";
                //}
                #endregion
            }

            return routGroup;
        }

        /// <summary>
        /// 그리드 엑셀 등록
        /// </summary>
        /// <param name="paramDS"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataSet CONTROL_GRID_EXCEL_INPUT(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DSYS.TSYS_USER_CUSTOM_REPORT.TSYS_USER_CUSTOM_REPORT_CREATE(bizExecute);
                DSYS.TSYS_USER_CUSTOM_REPORT_DETAIL.TSYS_USER_CUSTOM_REPORT_DETAIL_CREATE(bizExecute);

                foreach (DataRow row in paramDS.Tables["RQSTDT_M"].Rows)
                {
                    if (row["CUS_ID"].isNullOrEmpty())
                    {
                        row["CUS_ID"] = UTIL.UTILITY_GET_SERIALNO(row["PLT_CODE"].toStringEmpty(), "GE", UTIL.emSerialFormat.YY, "", bizExecute);

                        UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT_D"], "CUS_ID", row["CUS_ID"].toStringEmpty(), typeof(String));
                    }

                    DataTable search = DSYS.TSYS_USER_CUSTOM_REPORT.TSYS_USER_CUSTOM_REPORT_SER(UTIL.GetRowToDt(row), bizExecute);
                    if (search.Rows.Count > 0)
                    {
                        DSYS.TSYS_USER_CUSTOM_REPORT.TSYS_USER_CUSTOM_REPORT_UPD(UTIL.GetRowToDt(row), bizExecute);
                    }
                    else
                    {
                        DSYS.TSYS_USER_CUSTOM_REPORT.TSYS_USER_CUSTOM_REPORT_INS(UTIL.GetRowToDt(row), bizExecute);
                    }
                    //DSYS.TSYS_USER_CUSTOM_REPORT.TSYS_USER_CUSTOM_REPORT_DEL2(UTIL.GetRowToDt(row), bizExecute);
                    //DSYS.TSYS_USER_CUSTOM_REPORT.TSYS_USER_CUSTOM_REPORT_INS(UTIL.GetRowToDt(row), bizExecute);

                    //ID로 삭제
                    DSYS.TSYS_USER_CUSTOM_REPORT_DETAIL.TSYS_USER_CUSTOM_REPORT_DETAIL_DEL(UTIL.GetRowToDt(row), bizExecute);
                    //전체 삽입
                    DSYS.TSYS_USER_CUSTOM_REPORT_DETAIL.TSYS_USER_CUSTOM_REPORT_DETAIL_INS(paramDS.Tables["RQSTDT_D"], bizExecute);
                }
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

            return paramDS;

        }

        /// <summary>
        /// 그리드 엑셀 조회
        /// </summary>
        /// <param name="paramDS"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataSet GET_USE_CUSTOM_EXCEL(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DSYS.TSYS_USER_CUSTOM_REPORT.TSYS_USER_CUSTOM_REPORT_CREATE(bizExecute);
                DSYS.TSYS_USER_CUSTOM_REPORT_DETAIL.TSYS_USER_CUSTOM_REPORT_DETAIL_CREATE(bizExecute);

                DataTable search = DSYS.TSYS_USER_CUSTOM_REPORT.TSYS_USER_CUSTOM_REPORT_SER2(paramDS.Tables["RQSTDT"], bizExecute);
                search.Columns.Add("SEL", typeof(String));
                search.TableName = "RSLTDT";

                paramDS.Tables.Add(search);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

            return paramDS;
        }

        /// <summary>
        /// 그리드 엑셀 파일조회
        /// </summary>
        /// <param name="paramDS"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataSet GET_USE_CUSTOM_EXCELFILE(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DSYS.TSYS_USER_CUSTOM_REPORT.TSYS_USER_CUSTOM_REPORT_CREATE(bizExecute);
                DSYS.TSYS_USER_CUSTOM_REPORT_DETAIL.TSYS_USER_CUSTOM_REPORT_DETAIL_CREATE(bizExecute);

                DataTable rsltM = DSYS.TSYS_USER_CUSTOM_REPORT.TSYS_USER_CUSTOM_REPORT_SER(paramDS.Tables["RQSTDT"], bizExecute);
                rsltM.TableName = "RSLTDT_M";

                DataTable rsltD = DSYS.TSYS_USER_CUSTOM_REPORT_DETAIL.TSYS_USER_CUSTOM_REPORT_DETAIL_SER(paramDS.Tables["RQSTDT"], bizExecute);
                rsltD.TableName = "RSLTDT_D";

                paramDS.Tables.Add(rsltM);
                paramDS.Tables.Add(rsltD);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

            return paramDS;
        }

        /// <summary>
        /// 커스텀 엑셀 양식 삭제
        /// </summary>
        /// <param name="paramDS"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataSet DEL_CUSTOM_EXCEL(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DSYS.TSYS_USER_CUSTOM_REPORT.TSYS_USER_CUSTOM_REPORT_DEL(paramDS.Tables["RQSTDT"], bizExecute);
                DSYS.TSYS_USER_CUSTOM_REPORT_DETAIL.TSYS_USER_CUSTOM_REPORT_DETAIL_DEL(paramDS.Tables["RQSTDT"], bizExecute);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

            return paramDS;
        }

        /// <summary>
        /// 사용자 양식 사용 등록
        /// </summary>
        /// <param name="paramDS"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataSet SET_CUSTOM_REPORT_TO_EXCEL(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DSYS.TSYS_USER_CUSTOM_REPORT_USE.TSYS_USER_CUSTOM_REPORT_USE_CREATE(bizExecute);

                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    DSYS.TSYS_USER_CUSTOM_REPORT_USE.TSYS_USER_CUSTOM_REPORT_USE_DEL2(UTIL.GetRowToDt(row), bizExecute);
                    DSYS.TSYS_USER_CUSTOM_REPORT_USE.TSYS_USER_CUSTOM_REPORT_USE_INS(UTIL.GetRowToDt(row), bizExecute);
                }
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

            return paramDS;

        }

        /// <summary>
        /// 그리드 엑셀 조회
        /// </summary>
        /// <param name="paramDS"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataSet GET_USER_USED_CUSTOM_EXCEL(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DSYS.TSYS_USER_CUSTOM_REPORT_USE.TSYS_USER_CUSTOM_REPORT_USE_CREATE(bizExecute);

                DataTable search = DSYS.TSYS_USER_CUSTOM_REPORT_USE.TSYS_USER_CUSTOM_REPORT_USE_SER(paramDS.Tables["RQSTDT"], bizExecute);
                search.Columns.Add("SEL", typeof(String));
                search.TableName = "RSLTDT";

                paramDS.Tables.Add(search);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

            return paramDS;
        }
    }

}
