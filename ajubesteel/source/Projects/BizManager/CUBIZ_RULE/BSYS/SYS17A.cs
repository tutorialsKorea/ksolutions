using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace BSYS
{
    public class SYS17A
    {

        public static DataSet SYS17A_INS(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsRslt = new DataSet();
                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {

                    DataTable dtEmpSer = UTIL.GetRowToDt(row).Copy();

                    UTIL.SetBizAddColumnToValue(dtEmpSer, "EMP_CODE", row["REG_EMP"], typeof(String));

                    UTIL.SetBizAddColumnToValue(dtEmpSer, "DATA_FLAG", 0, typeof(Byte));

                    DataTable dtEmp = DSTD.TSTD_EMPLOYEE.TSTD_EMPLOYEE_SER(dtEmpSer, bizExecute);

                    DataTable dtMeeting = DSYS.TSYS_MEETING.TSYS_MEETING_SER(dtEmpSer, bizExecute);


                    if (dtMeeting.Rows.Count != 0)
                    {
                        //등록자와 같은경우  (게시글에 있는 등록자명과 신규 등록하는 게시글의 작성자가 똑같은 경우 ---> 업데이트)
                        if (object.Equals(dtMeeting.Rows[0]["REG_EMP"], row["REG_EMP"]))
                        {
                            //UPDATE
                            DSYS.TSYS_MEETING.TSYS_MEETING_UPD(UTIL.GetRowToDt(row), bizExecute);
                        }
                        else
                        {   
                            throw UTIL.SetException("해당 회의록은 등록한 사용자만 수정하거나 삭제할 수 있습니다."
                                    , new System.Diagnostics.StackFrame().GetMethod().Name
                                    , 200093);
                        }
                    }
                    else
                    {
                        //INSERT (게시글이 없으면 게시글 ID 생성한 후 INSERT 처리)

                        string serial = UTIL.UTILITY_GET_SERIALNO(row["PLT_CODE"].ToString(), "MET", bizExecute);

                        UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "MEETING_ID", serial, typeof(String));

                        DataTable dtMeetIns = UTIL.GetRowToDt(row).Copy();

                        UTIL.SetBizAddColumnToValue(dtMeetIns, "MEETING_ID", serial, typeof(String));

                        DSYS.TSYS_MEETING.TSYS_MEETING_INS(dtMeetIns, bizExecute);

                    }
                       
                    UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "SEARCH_KEY", row["MEETING_ID"].ToString(), typeof(String));
                    DSYS.TSYS_NOTIFY.TSYS_NOTIFY_DEL2(paramDS.Tables["RQSTDT"], bizExecute);

                    
                    DSYS.TSYS_MEETING_EMP.TSYS_MEETING_EMP_DEL(UTIL.GetRowToDt(row), bizExecute);

                    if (paramDS.Tables["RQSTDT"].Columns.Contains("ACC_LEVEL"))
                    {
                        if (paramDS.Tables["RQSTDT2"].Rows.Count != 0)
                        {

                            foreach (DataRow row2 in paramDS.Tables["RQSTDT2"].Rows)
                            {
                                string serial = UTIL.UTILITY_GET_SERIALNO(row2["PLT_CODE"].ToString(), "METE", bizExecute);

                                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT2"], "MEETING_EMP_ID", serial, typeof(String));
                                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT2"], "MEETING_ID", row["MEETING_ID"].ToString(), typeof(String));

                                DSYS.TSYS_MEETING_EMP.TSYS_MEETING_EMP_INS(UTIL.GetRowToDt(row2), bizExecute);

                                DataTable dtNotify = new DataTable("RQSTDT");

                                if (!dtNotify.Columns.Contains("PLT_CODE")) dtNotify.Columns.Add("PLT_CODE", typeof(String));
                                if (!dtNotify.Columns.Contains("TITLE")) dtNotify.Columns.Add("TITLE", typeof(String));
                                if (!dtNotify.Columns.Contains("TYPE")) dtNotify.Columns.Add("TYPE", typeof(String));
                                if (!dtNotify.Columns.Contains("KEY")) dtNotify.Columns.Add("KEY", typeof(String));
                                if (!dtNotify.Columns.Contains("MESSAGE")) dtNotify.Columns.Add("MESSAGE", typeof(String));
                                if (!dtNotify.Columns.Contains("VAR")) dtNotify.Columns.Add("VAR", typeof(String));
                                if (!dtNotify.Columns.Contains("MENU_CODE")) dtNotify.Columns.Add("MENU_CODE", typeof(String));
                                if (!dtNotify.Columns.Contains("SEARCH_KEY")) dtNotify.Columns.Add("SEARCH_KEY", typeof(String));
                                if (!dtNotify.Columns.Contains("REG_EMP")) dtNotify.Columns.Add("REG_EMP", typeof(String));

                                DataRow NotifyRow = dtNotify.NewRow();

                                NotifyRow["PLT_CODE"] = paramDS.Tables["RQSTDT"].Rows[0]["PLT_CODE"];
                                NotifyRow["TITLE"] = paramDS.Tables["RQSTDT"].Rows[0]["TITLE"];
                                NotifyRow["TYPE"] = paramDS.Tables["RQSTDT"].Rows[0]["ACC_LEVEL"];

                                switch (paramDS.Tables["RQSTDT"].Rows[0]["ACC_LEVEL"].ToString())
                                {
                                    case "E":
                                        NotifyRow["KEY"] = row2["EMP_CODE"];
                                        break;

                                    case "O":
                                        NotifyRow["KEY"] = paramDS.Tables["RQSTDT"].Rows[0]["ORG_CODE"];
                                        break;

                                    case "P":

                                        break;
                                }
                                NotifyRow["MESSAGE"] = paramDS.Tables["RQSTDT"].Rows[0]["CONTENTS"];
                                NotifyRow["VAR"] = "NOTIFY_NOTICE";
                                NotifyRow["SEARCH_KEY"] = row["MEETING_ID"];
                                NotifyRow["MENU_CODE"] = "SYS17A";
                                NotifyRow["REG_EMP"] = ConnInfo.UserID;

                                dtNotify.Rows.Add(NotifyRow);

                                DataSet dsNotify = new DataSet();
                                dsNotify.Tables.Add(dtNotify);

                                CTRL.CTRL.CREATE_NOTIFY(dsNotify, bizExecute);
                            }
                        }
                        else
                        {
                            DataTable dtNotify = new DataTable("RQSTDT");

                            if (!dtNotify.Columns.Contains("PLT_CODE")) dtNotify.Columns.Add("PLT_CODE", typeof(String));
                            if (!dtNotify.Columns.Contains("TITLE")) dtNotify.Columns.Add("TITLE", typeof(String));
                            if (!dtNotify.Columns.Contains("TYPE")) dtNotify.Columns.Add("TYPE", typeof(String));
                            if (!dtNotify.Columns.Contains("KEY")) dtNotify.Columns.Add("KEY", typeof(String));
                            if (!dtNotify.Columns.Contains("MESSAGE")) dtNotify.Columns.Add("MESSAGE", typeof(String));
                            if (!dtNotify.Columns.Contains("VAR")) dtNotify.Columns.Add("VAR", typeof(String));
                            if (!dtNotify.Columns.Contains("MENU_CODE")) dtNotify.Columns.Add("MENU_CODE", typeof(String));
                            if (!dtNotify.Columns.Contains("SEARCH_KEY")) dtNotify.Columns.Add("SEARCH_KEY", typeof(String));
                            if (!dtNotify.Columns.Contains("REG_EMP")) dtNotify.Columns.Add("REG_EMP", typeof(String));

                            DataRow NotifyRow = dtNotify.NewRow();

                            NotifyRow["PLT_CODE"] = paramDS.Tables["RQSTDT"].Rows[0]["PLT_CODE"];
                            NotifyRow["TITLE"] = paramDS.Tables["RQSTDT"].Rows[0]["TITLE"];
                            NotifyRow["TYPE"] = paramDS.Tables["RQSTDT"].Rows[0]["ACC_LEVEL"];

                            switch (paramDS.Tables["RQSTDT"].Rows[0]["ACC_LEVEL"].ToString())
                            {
                                case "E":
                                    //NotifyRow["KEY"] = row2["EMP_CODE"];
                                    break;

                                case "O":
                                    NotifyRow["KEY"] = paramDS.Tables["RQSTDT"].Rows[0]["ORG_CODE"];
                                    break;

                                case "P":

                                    break;
                            }
                            NotifyRow["MESSAGE"] = paramDS.Tables["RQSTDT"].Rows[0]["CONTENTS"];
                            NotifyRow["VAR"] = "NOTIFY_NOTICE";
                            NotifyRow["SEARCH_KEY"] = row["MEETING_ID"];
                            NotifyRow["MENU_CODE"] = "SYS17A";
                            NotifyRow["REG_EMP"] = ConnInfo.UserID;

                            dtNotify.Rows.Add(NotifyRow);

                            DataSet dsNotify = new DataSet();
                            dsNotify.Tables.Add(dtNotify);

                            CTRL.CTRL.CREATE_NOTIFY(dsNotify, bizExecute);
                        }
                    }

                    

                }


                return SYS17A_SER(paramDS, bizExecute);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
               
            }
        }

        public static DataSet SYS17A_SER(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable dtMeetingRslt = DSYS.TSYS_MEETING_QUERY.TSYS_MEETING_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);

                DataTable dtReplySer = dtMeetingRslt.Copy();

                for (int i = 0; i < dtReplySer.Rows.Count; i++)
                {
                    dtReplySer.Rows[i]["LINK_ID"] = dtReplySer.Rows[i]["MEETING_ID"];
                }

                DataTable dtReplyRslt = DSYS.TSYS_MEETING_QUERY.TSYS_MEETING_QUERY2(dtReplySer, bizExecute);

                dtMeetingRslt.TableName = "RSLTDT";
                dtMeetingRslt.Columns.Add("SEL");

                dtReplyRslt.TableName = "RSLTDT_REPLY";

                DataSet dsRslt = new DataSet();
                dsRslt.Tables.Add(dtMeetingRslt);
                dsRslt.Tables.Add(dtReplyRslt);

                
                return dsRslt;


            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }


        public static DataSet SYS17A_SER2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable dtRslt = DSYS.TSYS_MEETING_EMP_QUERY.TSYS_MEETING_EMP_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);

                DataSet dsRslt = new DataSet();
                dsRslt.Tables.Add(dtRslt);
                
                return dsRslt;

            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }



        public static DataSet SYS17A_UPD(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                // 회의록 읽은사람 업데이트 

                DSYS.TSYS_MEETING_EMP.TSYS_MEETING_EMP_UPD(paramDS.Tables["RQSTDT"], bizExecute);

                DSYS.TSYS_MEETING.TSYS_MEETING_UPD2(paramDS.Tables["RQSTDT"], bizExecute);

                return SYS17A_SER(paramDS, bizExecute);

            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }



        public static DataSet SYS17A_DEL(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsRslt = new DataSet();
                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    DSYS.TSYS_MEETING.TSYS_MEETING_UDE(UTIL.GetRowToDt(row), bizExecute);

                    DataTable dtReplyUde = UTIL.GetRowToDt(row).Copy();

                    dtReplyUde.Columns.Add("LINK_ID");

                    for (int i = 0; i < dtReplyUde.Rows.Count; i++)
                    {
                        dtReplyUde.Rows[i]["LINK_ID"] = dtReplyUde.Rows[i]["MEETING_ID"];
                    }

                    DSYS.TSYS_MEETING.TSYS_MEETING_UDE2(UTIL.GetRowToDt(row), bizExecute);
                }

                dsRslt.Tables.Add(paramDS.Tables["RQSTDT"].Copy());
                return dsRslt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }
}
