using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using BizExecute;

namespace BSYS
{
    public class SYS03A
    {
        /// <summary>
        /// 공지사항 등록
        /// 1. TSYS_NOTICE_SER 공지사항 조회하여 
        /// 2. 데이터가 있으면 UPDATE
        /// 3. 데이터 없으면 INSERT. -> 알림 생성
        /// 
        /// </summary>
        /// <param name="paramDS"></param>
        /// <returns></returns>
        public static DataSet SYS03A_INS(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {                
                if (paramDS.Tables["RQSTDT"].Rows.Count < 1) return null;

                string sr_code = "NTC";
                DataSet dsRslt = new DataSet();

                if (!paramDS.Tables["RQSTDT"].Columns.Contains("DATA_FLAG")) paramDS.Tables["RQSTDT"].Columns.Add("DATA_FLAG", typeof(Int32));
                if (!paramDS.Tables["RQSTDT"].Columns.Contains("ORG_CODE")) paramDS.Tables["RQSTDT"].Columns.Add("ORG_CODE", typeof(String));
                if (!paramDS.Tables["RQSTDT"].Columns.Contains("REG_DATE")) paramDS.Tables["RQSTDT"].Columns.Add("REG_DATE", typeof(DateTime));
                if (!paramDS.Tables["RQSTDT"].Columns.Contains("MDFY_EMP")) paramDS.Tables["RQSTDT"].Columns.Add("MDFY_EMP", typeof(String));
                if (!paramDS.Tables["RQSTDT"].Columns.Contains("NOTICE_ID")) paramDS.Tables["RQSTDT"].Columns.Add("NOTICE_ID", typeof(String));

                DataRow row = paramDS.Tables["RQSTDT"].Rows[0];

                //1.공지사항 조회
                DataTable dtEmpparam = ExtensionMethod.CreateSchema("RQSTDT", new string[] {"PLT_CODE", "EMP_CODE"}, 
                    new Type[] {typeof(String), typeof(String)});

                //등록자 사원 정보 조회
                dtEmpparam.Rows.Add(row["PLT_CODE"], row["REG_EMP"]);
                DataTable dtEmp = DSTD.TSTD_EMPLOYEE.TSTD_EMPLOYEE_SER(dtEmpparam, bizExecute);

                if (dtEmp.Rows.Count > 0)
                {
                    //부서 공지일 경우, 등록자의 부서 정보 가져온다.
                    if (row["ACC_LEVEL"].Equals("O"))
                        row["ORG_CODE"] = dtEmp.Rows[0]["ORG_CODE"];
                }

                //기존 공지사항 데이터 있는지 조회
                DataTable dtNoticeparam = ExtensionMethod.CreateSchema("RQSTDT", new string[] { "PLT_CODE", "NOTICE_ID" },
                    new Type[] { typeof(String), typeof(String) });

                dtNoticeparam.Rows.Add(row["PLT_CODE"], row["NOTICE_ID"]);

                DataTable dtNotice = DSYS.TSYS_NOTICE.TSYS_NOTICE_SER(dtNoticeparam, bizExecute);

                if (dtNotice.Rows.Count > 0)
                {
                    //등록자와 같은 경우 update 가능
                    if (dtNotice.Rows[0]["REG_EMP"].Equals(row["REG_EMP"]))
                    {
                        dtNotice.Rows[0]["MDFY_EMP"] = dtNotice.Rows[0]["REG_EMP"];
                        DSYS.TSYS_NOTICE.TSYS_NOTICE_UPD(paramDS.Tables["RQSTDT"], bizExecute);
                    }
                    else
                        throw UTIL.SetException("해당 공지사항을 등록한 사용자만 수정/삭제할 수 있습니다."
                            , new System.Diagnostics.StackFrame().GetMethod().Name);
                }
                else
                {
                    //공지사항 insert
                    string serial = UTIL.UTILITY_GET_SERIALNO(row["PLT_CODE"].ToString(), sr_code, bizExecute);
                    row["NOTICE_ID"] = serial;
                    
                    DSYS.TSYS_NOTICE.TSYS_NOTICE_INS(paramDS.Tables["RQSTDT"], bizExecute);

                    //**********알림 설정***************//
                    if (!paramDS.Tables["RQSTDT"].Columns.Contains("TYPE")) paramDS.Tables["RQSTDT"].Columns.Add("TYPE", typeof(String));
                    if (!paramDS.Tables["RQSTDT"].Columns.Contains("KEY")) paramDS.Tables["RQSTDT"].Columns.Add("KEY", typeof(String));
                    if (!paramDS.Tables["RQSTDT"].Columns.Contains("MESSAGE")) paramDS.Tables["RQSTDT"].Columns.Add("MESSAGE", typeof(String));
                    if (!paramDS.Tables["RQSTDT"].Columns.Contains("VAR")) paramDS.Tables["RQSTDT"].Columns.Add("VAR", typeof(String));
                    if (!paramDS.Tables["RQSTDT"].Columns.Contains("MENU_CODE")) paramDS.Tables["RQSTDT"].Columns.Add("MENU_CODE", typeof(String));
                    if (!paramDS.Tables["RQSTDT"].Columns.Contains("SEARCH_KEY")) paramDS.Tables["RQSTDT"].Columns.Add("SEARCH_KEY", typeof(String));

                    paramDS.Tables["RQSTDT"].Rows[0]["TYPE"] = paramDS.Tables["RQSTDT"].Rows[0]["ACC_LEVEL"];
                    paramDS.Tables["RQSTDT"].Rows[0]["KEY"] = paramDS.Tables["RQSTDT"].Rows[0]["ORG_CODE"];
                    paramDS.Tables["RQSTDT"].Rows[0]["MESSAGE"] = paramDS.Tables["RQSTDT"].Rows[0]["CONTENTS"];
                    paramDS.Tables["RQSTDT"].Rows[0]["VAR"] = "NOTIFY_NOTICE";
                    paramDS.Tables["RQSTDT"].Rows[0]["SEARCH_KEY"] = serial;
                    paramDS.Tables["RQSTDT"].Rows[0]["MENU_CODE"] = "SYS03A";

                    CTRL.CTRL.CREATE_NOTIFY(paramDS, bizExecute);

                    //dsRslt = SYS03A_SER(paramDS, bizExecute);
                }

                return SYS03A_SER(paramDS, bizExecute);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }



        /// <summary>
        ///  공지사항 등록 (다수의 수신 부서를 저장할 수 있는 경우)
        /// </summary>
        /// <param name="paramDS"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataSet SYS03A_INS2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (paramDS.Tables["RQSTDT"].Rows.Count < 1) return null;

                string sr_code = "NTC";
                DataSet dsRslt = new DataSet();

                if (!paramDS.Tables["RQSTDT"].Columns.Contains("DATA_FLAG")) paramDS.Tables["RQSTDT"].Columns.Add("DATA_FLAG", typeof(Int32));
                if (!paramDS.Tables["RQSTDT"].Columns.Contains("REG_DATE")) paramDS.Tables["RQSTDT"].Columns.Add("REG_DATE", typeof(DateTime));
                if (!paramDS.Tables["RQSTDT"].Columns.Contains("MDFY_EMP")) paramDS.Tables["RQSTDT"].Columns.Add("MDFY_EMP", typeof(String));
                if (!paramDS.Tables["RQSTDT"].Columns.Contains("NOTICE_ID")) paramDS.Tables["RQSTDT"].Columns.Add("NOTICE_ID", typeof(String));
                if (!paramDS.Tables["RQSTDT"].Columns.Contains("ORG_CODES")) paramDS.Tables["RQSTDT"].Columns.Add("ORG_CODES", typeof(String));

                DataRow row = paramDS.Tables["RQSTDT"].Rows[0];

                //1.공지사항 조회
                DataTable dtEmpparam = ExtensionMethod.CreateSchema("RQSTDT", new string[] { "PLT_CODE", "EMP_CODE" },
                    new Type[] { typeof(String), typeof(String) });


                #region 수정용
                ////등록자 사원 정보 조회
                //dtEmpparam.Rows.Add(row["PLT_CODE"], row["REG_EMP"]);
                //DataTable dtEmp = DSTD.TSTD_EMPLOYEE.TSTD_EMPLOYEE_SER(dtEmpparam, bizExecute);

                //if (dtEmp.Rows.Count > 0)
                //{
                //    //부서 공지일 경우, 등록자의 부서 정보 가져온다.
                //    if (row["ACC_LEVEL"].Equals("O"))
                //        row["ORG_CODE"] = dtEmp.Rows[0]["ORG_CODE"];
                //}


                // 부서코드 추가 
                //if(paramDS.Tables["RQSTDT2"].Rows.Count > 0)
                //{
                //    if (row["ACC_LEVEL"].Equals("O"))
                //    {
                //        foreach(DataRow dr in paramDS.Tables["RQSTDT2"].Rows)
                //        {
                //            row["ORG_CODES"] += dr["ORG_CODE"].ToString() + ", ";

                //        }

                //        row["ORG_CODES"] = row["ORG_CODES"].ToString().Substring(0, row["ORG_CODES"].ToString().Length - 2);

                //    }

                //}
                #endregion


                //기존 공지사항 데이터 있는지 조회
                DataTable dtNoticeparam = ExtensionMethod.CreateSchema("RQSTDT", new string[] { "PLT_CODE", "NOTICE_ID" },
                    new Type[] { typeof(String), typeof(String) });

                dtNoticeparam.Rows.Add(row["PLT_CODE"], row["NOTICE_ID"]);

                DataTable dtNotice = DSYS.TSYS_NOTICE.TSYS_NOTICE_SER(dtNoticeparam, bizExecute);

                if (dtNotice.Rows.Count > 0)
                {
                    //등록자와 같은 경우 update 가능
                    if (dtNotice.Rows[0]["REG_EMP"].Equals(row["REG_EMP"]))
                    {
                        dtNotice.Rows[0]["MDFY_EMP"] = dtNotice.Rows[0]["REG_EMP"];
                        DSYS.TSYS_NOTICE.TSYS_NOTICE_UPD2(paramDS.Tables["RQSTDT"], bizExecute);
                    }
                    else
                        throw UTIL.SetException("해당 공지사항을 등록한 사용자만 수정/삭제할 수 있습니다."
                            , new System.Diagnostics.StackFrame().GetMethod().Name);
                }
                else
                {
                    //공지사항 insert
                    string serial = UTIL.UTILITY_GET_SERIALNO(row["PLT_CODE"].ToString(), sr_code, bizExecute);
                    row["NOTICE_ID"] = serial;

                    DSYS.TSYS_NOTICE.TSYS_NOTICE_INS2(paramDS.Tables["RQSTDT"], bizExecute);

                    //**********알림 설정***************//
                    if (!paramDS.Tables["RQSTDT"].Columns.Contains("TYPE")) paramDS.Tables["RQSTDT"].Columns.Add("TYPE", typeof(String));
                    if (!paramDS.Tables["RQSTDT"].Columns.Contains("KEY")) paramDS.Tables["RQSTDT"].Columns.Add("KEY", typeof(String));
                    if (!paramDS.Tables["RQSTDT"].Columns.Contains("MESSAGE")) paramDS.Tables["RQSTDT"].Columns.Add("MESSAGE", typeof(String));
                    if (!paramDS.Tables["RQSTDT"].Columns.Contains("VAR")) paramDS.Tables["RQSTDT"].Columns.Add("VAR", typeof(String));
                    if (!paramDS.Tables["RQSTDT"].Columns.Contains("MENU_CODE")) paramDS.Tables["RQSTDT"].Columns.Add("MENU_CODE", typeof(String));
                    if (!paramDS.Tables["RQSTDT"].Columns.Contains("SEARCH_KEY")) paramDS.Tables["RQSTDT"].Columns.Add("SEARCH_KEY", typeof(String));

                    paramDS.Tables["RQSTDT"].Rows[0]["TYPE"] = paramDS.Tables["RQSTDT"].Rows[0]["ACC_LEVEL"];
                    paramDS.Tables["RQSTDT"].Rows[0]["KEY"] = paramDS.Tables["RQSTDT"].Rows[0]["ORG_CODES"];
                    paramDS.Tables["RQSTDT"].Rows[0]["MESSAGE"] = paramDS.Tables["RQSTDT"].Rows[0]["CONTENTS"];
                    paramDS.Tables["RQSTDT"].Rows[0]["VAR"] = "NOTIFY_NOTICE";
                    paramDS.Tables["RQSTDT"].Rows[0]["SEARCH_KEY"] = serial;
                    paramDS.Tables["RQSTDT"].Rows[0]["MENU_CODE"] = "SYS03A";

                    CTRL.CTRL.CREATE_NOTIFY(paramDS, bizExecute);

                    //dsRslt = SYS03A_SER(paramDS, bizExecute);
                }

                return SYS03A_SER(paramDS, bizExecute);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }








        /// <summary>
        /// 공지사항 조회
        /// </summary>
        /// <param name="paramDS"></param>
        /// <returns></returns>
        public static DataSet SYS03A_SER(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (!paramDS.Tables["RQSTDT"].Columns.Contains("NOTICE_ID")) paramDS.Tables["RQSTDT"].Columns.Add("NOTICE_ID", typeof(String));
                
                //DataTable dt = SQL.SQL_GETDATA("TSYS_NOTICE_QUERY2", paramDS.Tables["RQSTDT"],  bizExecute);
                //DataTable dt = DSYS.TSYS_NOTICE_QUERY.TSYS_NOTICE_QUERY2(paramDS.Tables["RQSTDT"], bizExecute);
                DataTable dt = DSYS.TSYS_NOTICE_QUERY.TSYS_NOTICE_QUERY3(paramDS.Tables["RQSTDT"], bizExecute);
                dt.Columns.Add("SEL");
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
        /// 공지사항 삭제
        /// 해당 공지를 등록한 사람만 삭제 가능.
        /// </summary>
        /// <param name="paramDS"></param>
        /// <returns></returns>
        public static DataSet SYS03A_DEL(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable dtNow = UTIL.UTILITY_GET_DTNOW(bizExecute);
                string dt = ((DateTime)dtNow.Rows[0]["NOW_DT"]).ToString("yyyy-MM-dd HH:mm:ss");

                //paramDS.Tables["RQSTDT"].Columns.Add("DEL_DATE");
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

                bool bDeletable = false;

                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
    
                    DataTable dtInparam = paramDS.Tables["RQSTDT"].Clone();
                    DataRow newRow = dtInparam.NewRow();
                    newRow.ItemArray = row.ItemArray;
                    dtInparam.Rows.Add(newRow);

                    DataTable dtSer = DSYS.TSYS_NOTICE.TSYS_NOTICE_SER(dtInparam, bizExecute);

                    if (dtSer.Rows.Count > 0)
                    {
                        //등록자와 삭제자가 같은지 확인
                        if (dtSer.Rows[0]["REG_EMP"].Equals(row["DEL_EMP"]))
                            bDeletable = true;
                        else                            
                            throw UTIL.SetException("등록자만 삭제할 수 있습니다."
                                , new System.Diagnostics.StackFrame().GetMethod().Name);
                    }


                    if (bDeletable)
                    {
                        DSYS.TSYS_NOTICE.TSYS_NOTICE_UDE(dtInparam, bizExecute);
                    }
                }

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }

      

    }
}
