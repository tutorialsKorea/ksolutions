using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Net;
using System.IO;
using BizManager;
using System.Data;

namespace ControlManager
{
    public class acMail
    {
        private MailMessage mail = null;
        //보내는 사람 주소
        private MailAddress sendAddress = null;

        private string _serverIP = string.Empty;

        private string _password = string.Empty;

        private string _id = string.Empty;

        private int _port = 25;

        private bool _useSSL = false;

        string _LINK_NO = string.Empty;

        public string LINK_NO
        {
            get { return this._LINK_NO; }
            set { this._LINK_NO = value; }
        }

        public acMail(string sendMail, string sendName)
        {
            mail = new MailMessage();

            this._serverIP = acInfo.SysConfig.GetSysConfigByMemory("SMTP_ADDRESS");

            this._id = acInfo.SysConfig.GetSysConfigByMemory("SMTP_USERID");

            this._password = acInfo.SysConfig.GetSysConfigByMemory("SMTP_PASSWORD");

            this._port = acInfo.SysConfig.GetSysConfigByMemory("SMTP_PORT").toInt();

            //this._useSSL = acInfo.SysConfig.GetSysConfigByMemory("SMTP_SSL").toBoolean();

            this._useSSL = true; 
            //this.sendAddress = new MailAddress("mes@lsmtron.com","사출사업부 MES",System.Text.Encoding.UTF8);
            this.sendAddress = new MailAddress(sendMail, sendName, System.Text.Encoding.UTF8);

            mail.From = this.sendAddress;


        }

        public void SetToAddressList(string[] toAddress)
        {
            foreach (string address in toAddress)
            {
                if (address != null && address != string.Empty)
                    mail.To.Add(address);
            }
        }

        public void SetCcAddressList(string[] ccAddress)
        {
            foreach (string address in ccAddress)
            {
                if (address != null && address != string.Empty)
                    mail.CC.Add(address);
            }
        }

        public void SetBccAddressList(string[] bccAddress)
        {
            foreach (string address in bccAddress)
            {
                mail.Bcc.Add(address);
            }
        }

        public void SetAttatchFileList(string[] files, string type = "", string strClass = "", string linkKey = "")
        {
            foreach (string file in files)
            {
                if (!File.Exists(file))
                    throw new Exception(string.Format("첨부 파일을 찾을수 없습니다.[{0}]", file));

                mail.Attachments.Add(new Attachment(new FileStream(file, FileMode.Open, FileAccess.Read), Path.GetFileName(file)));
            }

            if (type != "")
            {
                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(string));
                paramTable.Columns.Add("UPLOAD_CLASS", typeof(string));
                paramTable.Columns.Add("LINK_KEY", typeof(string));

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["UPLOAD_CLASS"] = strClass;
                paramRow["LINK_KEY"] = linkKey;

                paramTable.Rows.Add(paramRow);

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);


                DataSet resultSet = BizRun.QBizRun.ExecuteService(this, "CTRL", "ATTACH_FILE_MASTER_SER3", paramSet, "RQSTDT", "RSLTDT");

                //DataSet resultSet = BizRun.QBizRun.ExecuteService(this, "ATTACH_FILE_MASTER_SER3", paramSet, "RQSTDT", "RSLTDT");

                acFTP acFtp1 = new acFTP();
                acFtp1.Server = acInfo.SysConfig.GetSysConfigByServer("FTP_ADDRESS");
                acFtp1.ServerPort = acInfo.SysConfig.GetSysConfigByServer("FTP_PORT").toInt();
                acFtp1.Username = acInfo.SysConfig.GetSysConfigByServer("FTP_USERID");
                acFtp1.Password = acInfo.SysConfig.GetSysConfigByServer("FTP_PASSWORD");

                acFtp1.FileType = FileType.Image;
                acFtp1.DoEvents = true;
                acFtp1.Passive = true;
                acFtp1.Restart = false;


                string dir = "";

                string orginfilename = "";
                string filename = "";
                string fileID = "";

                foreach (DataRow row in resultSet.Tables["RSLTDT"].Rows)
                {
                    dir = row["REG_DATE"].ToString().Substring(0, 10);

                    orginfilename = row["FILE_NAME"].ToString();
                    filename = row["FILE_ID"].ToString() + getExtName(row["FILE_NAME"].ToString());
                    fileID = row["FILE_ID"].ToString();

                    ////string fileDir = string.Format(@"{0}\{1}\{2}", acInfo.GetTempSystemDirectory(), fileID, orginfilename);

                    //Stream ftpResult = acFtp1.Get(string.Format(@"{0}\{1}\{2}", acInfo.PLT_CODE, dir, filename), false);

                    ////System.Diagnostics.Process.Start(ftpResult.LocalFileName);
                    //mail.Attachments.Add(new Attachment(ftpResult, orginfilename));

                    string fileDir = string.Format(@"{0}\{1}\{2}", acInfo.GetTempSystemDirectory(), fileID, orginfilename);

                    FtpFile ftpResult = acFtp1.Get(string.Format(@"{0}\{1}\{2}", acInfo.PLT_CODE, dir, filename), fileDir);

                    //System.Diagnostics.Process.Start(ftpResult.LocalFileName);
                    mail.Attachments.Add(new Attachment(new FileStream(ftpResult.LocalFileName, FileMode.Open, FileAccess.Read), Path.GetFileName(ftpResult.LocalFileName)));

                }

                acFtp1.Close();
                acFtp1 = null;
            }
        }


        public void SetAttatchFileList(FileStream fsAttach, string type = "", string strClass = "", string linkKey = "")
        {
            //foreach (string file in files)
            //{
            //    if (!File.Exists(file))
            //        throw new Exception(string.Format("첨부 파일을 찾을수 없습니다.[{0}]", file));

            //    mail.Attachments.Add(new Attachment(new FileStream(file, FileMode.Open, FileAccess.Read), Path.GetFileName(file)));
            //}

            //FileStream fsAttachCopy = new FileStream(fsAttach.Name, FileMode.Open, FileAccess.Read, FileShare.Read);

            //fsAttach.CopyTo(fsAttachCopy);

            string path = fsAttach.Name;

            fsAttach.Dispose();
            fsAttach.Close();

            fsAttach = null;

            fsAttach = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

            mail.Attachments.Add(new Attachment(fsAttach, "발주서.pdf"));

            if (type != "")
            {
                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(string));
                paramTable.Columns.Add("UPLOAD_CLASS", typeof(string));
                paramTable.Columns.Add("LINK_KEY", typeof(string));

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["UPLOAD_CLASS"] = strClass;
                paramRow["LINK_KEY"] = linkKey;

                paramTable.Rows.Add(paramRow);

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);


                DataSet resultSet = BizRun.QBizRun.ExecuteService(this, "CTRL", "ATTACH_FILE_MASTER_SER3", paramSet, "RQSTDT", "RSLTDT");

                //DataSet resultSet = BizRun.QBizRun.ExecuteService(this, "ATTACH_FILE_MASTER_SER3", paramSet, "RQSTDT", "RSLTDT");

                acFTP acFtp1 = new acFTP();
                acFtp1.Server = acInfo.SysConfig.GetSysConfigByServer("FTP_ADDRESS");
                acFtp1.ServerPort = acInfo.SysConfig.GetSysConfigByServer("FTP_PORT").toInt();
                acFtp1.Username = acInfo.SysConfig.GetSysConfigByServer("FTP_USERID");
                acFtp1.Password = acInfo.SysConfig.GetSysConfigByServer("FTP_PASSWORD");

                acFtp1.FileType = FileType.Image;
                acFtp1.DoEvents = true;
                acFtp1.Passive = true;
                acFtp1.Restart = false;


                string dir = "";

                string orginfilename = "";
                string filename = "";
                string fileID = "";

                foreach (DataRow row in resultSet.Tables["RSLTDT"].Rows)
                {
                    dir = row["REG_DATE"].ToString().Substring(0, 10);

                    orginfilename = row["FILE_NAME"].ToString();
                    filename = row["FILE_ID"].ToString() + getExtName(row["FILE_NAME"].ToString());
                    fileID = row["FILE_ID"].ToString();

                    //string fileDir = string.Format(@"{0}\{1}\{2}", acInfo.GetTempSystemDirectory(), fileID, orginfilename);

                    Stream ftpResult = acFtp1.GetMemoryStream(string.Format(@"{0}\{1}\{2}", acInfo.PLT_CODE, dir, filename));

                    //System.Diagnostics.Process.Start(ftpResult.LocalFileName);
                    mail.Attachments.Add(new Attachment(ftpResult, orginfilename));
                }

                acFtp1.Close();
                acFtp1 = null;
            }
        }


        string getExtName(string filename)
        {

            string[] str = filename.Split('.');

            if (str.Length > 1)
            {
                string extname = str[str.Length - 1];
                return "." + extname;
            }
            else
            {
                return "";
            }
        }


        public bool SendEmail(object sender, string subject, string body)
        {
            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String));
            paramTable.Columns.Add("LINK_NO", typeof(String));
            paramTable.Columns.Add("FROM", typeof(String));
            paramTable.Columns.Add("TO", typeof(String));
            paramTable.Columns.Add("SUBJECT", typeof(String));
            paramTable.Columns.Add("BODY", typeof(String));
            paramTable.Columns.Add("ATTATCH_FILE", typeof(String));
            paramTable.Columns.Add("RESULT", typeof(String));

            string result = "SUCCESS";

            try
            {

                mail.Subject = subject;

                mail.Body = body;

                mail.IsBodyHtml = false;

                mail.SubjectEncoding = System.Text.Encoding.UTF8;

                mail.BodyEncoding = System.Text.Encoding.UTF8;

                
                SmtpClient smtpServer = new SmtpClient();
                smtpServer.Host = this._serverIP;
                smtpServer.Port = _port;
                smtpServer.UseDefaultCredentials = false;
                //smtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;

                smtpServer.Credentials = new System.Net.NetworkCredential(this._id, this._password);
                //smtpServer.Host = this._serverIP;
                smtpServer.EnableSsl = _useSSL;
                //smtpServer.TargetName = "STARTTLS/smtp.office365.com";


                smtpServer.Send(mail);

                return true;
            }
            catch (Exception ex)
           {
                //if (ex.Message.ToString().Contains("Too many recipients")
                //    || ex.InnerException.ToString().Contains("Too many recipients")
                //    || ex.Message.ToString().Contains("받는 사람에게 보낼 수 없습니다"))
                //{
                //    return true;
                //}

                result = ex.Message;
                
                return false;
            }
            finally
            {
                

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["LINK_NO"] = this._LINK_NO;
                paramRow["FROM"] = mail.From.ToString();
                paramRow["TO"] = mail.To.ToString();
                paramRow["SUBJECT"] = mail.Subject;
                paramRow["BODY"] = mail.Body;
                if (mail.Attachments.Count > 0)
                    paramRow["ATTATCH_FILE"] = mail.Attachments[0].Name;

                paramRow["BODY"] = mail.Body;
                paramRow["RESULT"] = result;
                paramTable.Rows.Add(paramRow);

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(sender, "CTRL", "SET_EMAILSEND_LOG", paramSet, "RQSTDT", "RSLTDT");

                if (mail != null) mail.Dispose();
            }


        }

        public bool SendEmail(object sender, string subject, string body, bool isBotyHtml)
        {

            try
            {

                mail.Subject = subject;

                mail.Body = body;

                mail.IsBodyHtml = isBotyHtml;

                mail.SubjectEncoding = System.Text.Encoding.UTF8;

                mail.BodyEncoding = System.Text.Encoding.UTF8;

                //SmtpClient smtpServer = new SmtpClient("smtp.cubictek.co.kr");
                SmtpClient smtpServer = new SmtpClient(this._serverIP);

                //smtpServer.Port = 25;
                smtpServer.Port = _port;

                //smtpServer.Credentials = new System.Net.NetworkCredential(this._id, this._password);
                smtpServer.Credentials = new System.Net.NetworkCredential(this._id, this._password);

                //smtpServer.EnableSsl = false;
                smtpServer.EnableSsl = _useSSL;

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String));
                paramTable.Columns.Add("LINK_NO", typeof(String));
                paramTable.Columns.Add("TO", typeof(String));
                paramTable.Columns.Add("SUBJECT", typeof(String));
                paramTable.Columns.Add("BODY", typeof(String));
                paramTable.Columns.Add("ATTATCH_FILE", typeof(String));

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["LINK_NO"] = this._LINK_NO;
                paramRow["TO"] = mail.To.ToString();
                paramRow["SUBJECT"] = mail.Subject;
                paramRow["BODY"] = mail.Body;
                if (mail.Attachments.Count > 0)
                    paramRow["ATTATCH_FILE"] = mail.Attachments[0].Name;

                paramRow["BODY"] = mail.Body;
                paramTable.Rows.Add(paramRow);

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(sender, "CTRL", "SET_EMAILSEND_LOG", paramSet, "RQSTDT", "RSLTDT");

                smtpServer.Send(mail);

                return true;
            }
            catch (Exception ex)
            {
                if (ex.Message.ToString().Contains("Too many recipients")
                    || ex.InnerException.ToString().Contains("Too many recipients")
                    || ex.Message.ToString().Contains("받는 사람에게 보낼 수 없습니다"))
                {
                    return true;
                }
                return false;
            }
            finally
            {
                if (mail != null) mail.Dispose();
            }


        }
    }
}