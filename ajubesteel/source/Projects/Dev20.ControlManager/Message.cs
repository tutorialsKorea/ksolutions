using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace ControlManager
{
    public interface IMessage
    {
        void Send();
        void Log(string is_success);
    }

    /// <summary>
    /// EMAIL CLASS
    /// </summary>
    public class Email : IMessage, IDisposable
    {
        MailMessage _mail;

        public string[] ATTACH
        {
            set
            {
                foreach (string path in value)
                {
                    this._mail.Attachments.Add(new Attachment(path));
                }
            }
        }
        public string _category;

        public bool IS_HTML { get; set; }

        /// <summary>
        /// SMTP URL
        /// </summary>
        public string SMTP_URL { get; set; }

        /// <summary>
        /// SMTP PORT
        /// </summary>
        public int SMTP_PORT { get; set; }

        /// <summary>
        /// 받는사람 <key:email, value: string[] - [0]이름 [1]ID>
        /// </summary>
        public Dictionary<string, string[]> TO
        {
            set
            {
                foreach (KeyValuePair<string, string[]> item in value)
                {
                    if (RegexEx.CheckRegex(item.Key, RegexEx.RegexType.EMAIL))
                    {
                        this._mail.To.Add(new MailAddress(item.Key, item.Value[0]));

                        if (_log_recipient_id.ContainsKey(item.Key) == false)
                            this._log_recipient_id.Add(item.Key, item.Value[1]);
                    }
                    else
                    {
                        EmailErrorLog(item.Value[1], item.Key);
                    }
                }
            }
        }

        /// <summary>
        /// 받는사람 ID(로그에 사용)
        /// </summary>
        public Dictionary<string, string> _log_recipient_id = null;

        /// <summary>
        /// 참조<key:email, value: string[] - [0]이름 [1]ID>
        /// </summary>
        public Dictionary<string, string[]> CC
        {
            set
            {
                foreach (KeyValuePair<string, string[]> item in value)
                {
                    if (RegexEx.CheckRegex(item.Key, RegexEx.RegexType.EMAIL))
                    {
                        this._mail.CC.Add(new MailAddress(item.Key, item.Value[0]));

                        if (_log_recipient_id.ContainsKey(item.Key) == false)
                            this._log_recipient_id.Add(item.Key, item.Value[1]);
                    }
                    else
                    {
                        EmailErrorLog(item.Value[1], item.Key);
                    }
                }
            }
        }

        /// <summary>
        /// 숨은참조<key:email, value: string[] - [0]이름 [1]ID>
        /// </summary>
        public Dictionary<string, string[]> BCC
        {
            set
            {
                foreach (KeyValuePair<string, string[]> item in value)
                {
                    if (RegexEx.CheckRegex(item.Key, RegexEx.RegexType.EMAIL))
                    {
                        this._mail.Bcc.Add(new MailAddress(item.Key, item.Value[0]));

                        if (_log_recipient_id.ContainsKey(item.Key) == false)
                            this._log_recipient_id.Add(item.Key, item.Value[1]);
                    }
                    else
                    {
                        EmailErrorLog(item.Value[1], item.Key);
                    }
                }
            }
        }

        /// <summary>
        /// 제목
        /// </summary>
        public string SUBJECT
        {
            set
            {
                this._mail.Subject = value;
            }
        }


        public string MVND_CODE { get; set; }

        /// <summary>
        /// 본문
        /// </summary>
        public string BODY
        {
            set
            {
                this._mail.Body = value;
            }
        }

        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="category">보내는 자료 분류</param>
        /// <param name="fromEmail">보내는 사람 EMAIL</param>
        public Email(string category, string fromEmail)
        {
            _category = category;
            this._mail = new MailMessage();
            this._mail.From = new MailAddress(fromEmail);
            _log_recipient_id = new Dictionary<string, string>();
        }

        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="category">보내는 자료 분류</param>
        /// <param name="fromEmail">보내는 사람 EMAIL</param>
        /// <param name="fromName">보내는 사람 이름</param>
        public Email(string category, string fromEmail, string fromName)
        {
            this.SMTP_URL = acInfo.SysConfig.GetSysConfigByServer("SMTP_ADDRESS");
            this.SMTP_PORT = acInfo.SysConfig.GetSysConfigByServer("SMTP_PORT").toInt();

            _category = category;
            this._mail = new MailMessage();
            this._mail.From = new MailAddress(fromEmail, fromName);
            _log_recipient_id = new Dictionary<string, string>();
        }

        /// <summary>
        /// SEND
        /// </summary>
        public void Send()
        {
          

            if (this.SMTP_URL.isNullOrEmpty()) this.SMTP_URL = "smtp.cubictek.co.kr";
            if (this.SMTP_PORT.isNullOrEmpty()) this.SMTP_PORT = 25;

            SmtpClient smtp = new SmtpClient(this.SMTP_URL, this.SMTP_PORT);

            smtp.EnableSsl = false; //SSL 사용
            smtp.Timeout = 10000;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential("mes@creslite.com", "cres6870!");//보내는 사람 메일 서버접속계정, 암호, Anonymous이용시 생략
            //client.Send(message);

            string is_Success = "0"; //0 - 실패, 1 - 성공</param>
            try
            {
                this._mail.IsBodyHtml = this.IS_HTML;

                smtp.Send(this._mail);
                is_Success = "1";
            }
            catch (Exception ex)
            {
                is_Success = "0";
                throw ex;
            }
            finally
            {
                Log(is_Success);
            }
        }

        /// <summary>
        /// 이메일 전송 로그
        /// </summary>
        /// <param name="category">보내는 곳 페이지</param>
        /// <param name="is_success">0 - 실패, 1 - 성공</param>
        public void Log(string is_success)
        {
            try
            {
                DataSet paramSet = new DataSet();

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("MAIL_ID", typeof(String));
                paramTable.Columns.Add("TITLE", typeof(String));
                paramTable.Columns.Add("MVND_CODE", typeof(String));
                paramTable.Columns.Add("MAIL_ADDRESS", typeof(String));
                paramTable.Columns.Add("SUCCESS", typeof(String));

                DataRow paramRow = paramTable.NewRow();

                paramRow["TITLE"] = this._mail.Subject;
                paramRow["MVND_CODE"] = MVND_CODE;
                paramRow["SUCCESS"] = is_success;
                foreach (MailAddress ma in this._mail.To)
                {
                    paramRow["MAIL_ADDRESS"] += ma.Address + ";";
                }

                paramTable.Rows.Add(paramRow);
                paramSet.Tables.Add(paramTable);

                BizManager.BizRun.QBizRun.ExecuteService(this, "CTRL", "INSERT_MAIL_LOG", paramSet, "RQSTDT", "RSLTDT");
            }
            catch { }
        }

        public void EmailErrorLog(string recipient_id, string address)
        {
            try
            {
                DataSet paramSet = new DataSet();

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("RECIPIENT_ID", typeof(String));
                paramTable.Columns.Add("CATEGORY", typeof(String));
                paramTable.Columns.Add("TITLE", typeof(String));
                paramTable.Columns.Add("SEND_TYPE", typeof(Int32));
                paramTable.Columns.Add("IN_OUT_SIDE_TYPE", typeof(Int32));
                paramTable.Columns.Add("IS_SUCCESS", typeof(Int32));
                paramTable.Columns.Add("SENDER_PROCESS_TYPE", typeof(Int32));
                paramTable.Columns.Add("CREATED_BY", typeof(String));

                DataRow paramRow = paramTable.NewRow();


                paramRow["RECIPIENT_ID"] = recipient_id;

                paramRow["CATEGORY"] = _category;
                paramRow["TITLE"] = string.Format("메일주소 오류 - {0} ", address);
                paramRow["SEND_TYPE"] = "1"; //1 - EMAIL, 2 - SMS

                if (address.Contains("@lge.com"))
                    paramRow["IN_OUT_SIDE_TYPE"] = "1"; //1 - 내부, 2 - 외부
                else
                    paramRow["IN_OUT_SIDE_TYPE"] = "2"; //1 - 내부, 2 - 외부

                paramRow["IS_SUCCESS"] = 0; //0 - 실패, 1 - 성공
                paramRow["SENDER_PROCESS_TYPE"] = "1"; //1 - EPMS, 2 - SERVICE, 3 - AGENT
                paramRow["CREATED_BY"] = acInfo.UserID;

                paramTable.Rows.Add(paramRow);

                paramSet.Tables.Add(paramTable);

                BizManager.BizRun.QBizRun.ExecuteService(this, "CTRL", "INSERT_SEND_LOG", paramSet, "RQSTDT", "RSLTDT");
            }
            catch { }
        }

        public void SendIssueMail(string pjtCode, string issueName, string issueContents, string bigIssue)
        {
            try
            {
                DataSet paramSet = new DataSet();
                DataTable empDT = BizManager.BizRun.QBizRun.ExecuteService(this, "PJT01A_EMAIL", paramSet, "", "RSLTDT").Tables["RSLTDT"];
                Dictionary<string, string[]> sendList = new Dictionary<string, string[]>();
                foreach (DataRow row in empDT.Rows)
                {
                    if (sendList.ContainsKey(row["EMAIL"].ToString()) == false)
                    {
                        sendList.Add(row["EMAIL"].ToString(), new string[] { row["EMP_NAME"].ToString(), row["EMP_CODE"].ToString() });
                    }
                }

                paramSet = new DataSet();

                DataTable paramDT = new DataTable("RQSTDT");
                paramDT.Columns.Add("PJT_CODE", typeof(String));

                DataRow paramRow = paramDT.NewRow();
                paramRow["PJT_CODE"] = pjtCode;

                paramDT.Rows.Add(paramRow);

                paramSet.Tables.Add(paramDT);

                DataTable plDT = BizManager.BizRun.QBizRun.ExecuteService(this, "MYW03A_PLMAIL", paramSet, "RQSTDT", "RSLTDT").Tables["RSLTDT"];
                foreach (DataRow row in plDT.Rows)
                {
                    if (sendList.ContainsKey(row["EMAIL"].ToString()) == false)
                    {
                        sendList.Add(row["EMAIL"].ToString(), new string[] { row["EMP_NAME"].ToString(), row["EMP_CODE"].ToString() });
                    }
                }

                DataTable resultDT = BizManager.BizRun.QBizRun.ExecuteService(this, "MYW03A_SER4", paramSet, "RQSTDT", "RSLTDT").Tables["RSLTDT"];

                this.TO = sendList;
                this.SUBJECT = "메일제목: [EPMS] 조립 이슈 등록 안내";
                this.IS_HTML = true;
                this.BODY = "<html>안녕하십니까?<br/>"
                            + "LG생산기술원 장비제작관리 시스템(EPMS)입니다.<br/>"
                            + "<br/>"
                            + "아래의 PJT에 대한 조립 이슈가 등록되었습니다.<br/>"
                            + "<br/>"
                            + "상세한 내용은 EPMS에 접속해서 확인하시기 바랍니다.<br/>"
                            + "<br/>"
                            + "감사합니다.<br/>"
                            + "<br/>"
                            + "- 아래 -<br/>"
                            + "\n"
                            + "PJT Name: " + resultDT.Rows[0]["PJT_NAME"] + "<br/>"
                            + "개발 PL: " + resultDT.Rows[0]["PJT_LEADER_NAME"] + "<br/>"
                            + "이슈명: " + issueName + "<br/>"
                            + "이슈 중요도: " + issueContents + "<br/>"
                            + "이슈 내용: " + bigIssue + "<br/>"
                            + "\n"
                            + "※ 본 메일은 발신 전용 메일입니다.<br/>";

                this.SMTP_PORT = 25;
                this.Send();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(ex.Message + "\n" + ex.StackTrace, "에러", acMessageBox.emMessageBoxType.CONFIRM);
            }
        }

        public void Dispose()
        {
            this._mail.Dispose();
            this._mail = null;
        }
    }

    public enum SMS_TYPE : int
    {
        SMS = 1,
        LMS
    }

    public enum SMS_TITLE : int
    {
        ISSUE_ALAM = 0
    }

    /// <summary>
    /// SMS CLASS
    /// </summary>
    public class Sms : IMessage, IDisposable
    {


        string _type = "SMS";

        /// <summary>
        /// SMS URL
        /// </summary>
        public string URL { get; set; }

        /// <summary>
        /// 받는사람 전화번호
        /// 여러명일땐 , 로 구분
        /// </summary>
        public string TO { get; set; }

        /// <summary>
        /// 받는사람 이름
        /// 여러명일땐 , 로 구분
        /// </summary>
        public string TO_NAME { get; set; }

        /// <summary>
        /// 메시지 내용 90byte
        /// </summary>
        public string TEXT { get; set; }

        string GetFullParameters()
        {
            if (this.TO.isNullOrEmpty()) throw new Exception("To is null or empty.");
            if (this.TO_NAME.isNullOrEmpty()) throw new Exception("Name is null or empty.");
            if (this.TEXT.isNullOrEmpty()) throw new Exception("Message is null or empty.");

            return string.Format(@"{
    ""to"": ""{0}"",
    ""to_name"": ""{1}"",
    ""type"": ""{2}"",
    ""text"": ""{3}""
}", this.TO, this.TO_NAME, this._type, this.TEXT);
        }

        /// <summary>
        /// SEND
        /// </summary>
        public void Send()
        {
            // TODO: SMS URL Setting
            if (this.URL.isNullOrEmpty()) this.URL = "http://p5collect.lge.com:8280/rest/sendsmd.do";

            try
            {
                string data = GetFullParameters();

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(this.URL + GetFullParameters());
                request.Method = "POST";
                request.ContentType = "application/json";
                request.ContentLength = data.Length;
                using (Stream webStream = request.GetRequestStream())
                {
                    using (StreamWriter requestWriter = new StreamWriter(webStream, System.Text.Encoding.ASCII))
                    {
                        requestWriter.Write(data);
                    }
                }

                WebResponse webResponse = request.GetResponse();
                string response = string.Empty;

                using (Stream webStream = webResponse.GetResponseStream())
                {
                    if (webStream != null)
                    {
                        using (StreamReader responseReader = new StreamReader(webStream))
                        {
                            response = responseReader.ReadToEnd();
                        }
                    }
                }

                if (!response.Contains("success"))
                {
                    throw new Exception(response);
                }
            }
            catch { throw; }
        }


        public void SendIssueSMS(string pjtCode, string message, SMS_TYPE emType, SMS_TITLE emTitle)
        {
            try
            {
                DataSet paramSet = new DataSet();
                DataTable empDT = BizManager.BizRun.QBizRun.ExecuteService(this, "PJT01A_EMAIL", paramSet, "", "RSLTDT").Tables["RSLTDT"];
                HashSet<string> sendList = new HashSet<string>();
                foreach (DataRow row in empDT.Rows)
                {
                    if (sendList.Contains(row["EMAIL"].ToString()) == false)
                    {
                        sendList.Add(row["EMP_CODE"].ToString());
                    }
                }

                paramSet = new DataSet();

                DataTable paramDT = new DataTable("RQSTDT");
                paramDT.Columns.Add("PJT_CODE", typeof(String));

                DataRow paramRow = paramDT.NewRow();
                paramRow["PJT_CODE"] = pjtCode;

                paramDT.Rows.Add(paramRow);

                paramSet.Tables.Add(paramDT);

                DataTable plDT = BizManager.BizRun.QBizRun.ExecuteService(this, "MYW03A_PLMAIL", paramSet, "RQSTDT", "RSLTDT").Tables["RSLTDT"];
                foreach (DataRow row in plDT.Rows)
                {
                    if (sendList.Contains(row["EMAIL"].ToString()) == false)
                    {
                        sendList.Add(row["EMP_CODE"].ToString());
                    }
                }

                DataTable paramTable_SMS = new DataTable("RQSTDT");
                paramTable_SMS.Columns.Add("EMP_CODE", typeof(String));
                paramTable_SMS.Columns.Add("MSG_TYPE", typeof(String));
                paramTable_SMS.Columns.Add("MSG_TITLE", typeof(String));
                paramTable_SMS.Columns.Add("MESSAGE", typeof(String));

                foreach (string empCode in sendList)
                {
                    DataRow paramRow_SMS = paramTable_SMS.NewRow();
                    paramRow_SMS["EMP_CODE"] = empCode;

                    switch (emType)
                    {
                        case SMS_TYPE.SMS:
                            paramRow_SMS["MSG_TYPE"] = "SMS";
                            break;
                        case SMS_TYPE.LMS:
                            paramRow_SMS["MSG_TYPE"] = "LMS";
                            break;
                        default:
                            break;
                    }

                    switch (emTitle)
                    {
                        case SMS_TITLE.ISSUE_ALAM:
                            paramRow_SMS["MSG_TITLE"] = "이슈 등록 알림";
                            break;
                        default:
                            break;
                    }

                    paramRow_SMS["MESSAGE"] = message;

                    paramTable_SMS.Rows.Add(paramRow_SMS);
                }

                DataSet paramSet_SMS = new DataSet();
                paramSet_SMS.Tables.Add(paramTable_SMS);

                BizManager.BizRun.QBizRun.ExecuteService(this, "MYW04A_INS4", paramSet_SMS, "RQSTDT", "RSLTDT");
            }
            catch (Exception ex)
            {
                acMessageBox.Show(ex.Message + "\n" + ex.StackTrace, "에러", acMessageBox.emMessageBoxType.CONFIRM);
            }
        }

        public void Log(string is_success)
        {

        }

        public void Dispose()
        {

        }
    }
}
