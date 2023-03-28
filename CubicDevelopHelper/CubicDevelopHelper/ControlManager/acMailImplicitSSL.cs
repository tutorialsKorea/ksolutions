using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using BizManager;
using System.Data;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;

namespace ControlManager
{
    public class acMailImplicitSSL
    {
        private MimeMessage mail = null;

        private string _serverIP = string.Empty;

        private string _password = string.Empty;

        private string _id = string.Empty;

        private int _port = 465;

        string _LINK_NO = string.Empty;

        public string LINK_NO
        {
            get { return this._LINK_NO; }
            set { this._LINK_NO = value; }
        }

        public acMailImplicitSSL(string sendMail, string sendName)
        {
            /*
             인증방식
              TLS/SSL Explicit Port
              SMTP : 25 / 587
              
              TLS/SSL Implicit Port
              STMP : 465

              -> system.net.mail에서는 ImplicitPort방식을 지원하지 않음
              -> Nuget - MailKit 사용해서 처리함
            */
            mail = new MimeMessage();

            

            this._serverIP = acInfo.SysConfig.GetSysConfigByMemory("SMTP_ADDRESS");

            this._id = acInfo.SysConfig.GetSysConfigByMemory("SMTP_USERID");

            this._password = acInfo.SysConfig.GetSysConfigByMemory("SMTP_PASSWORD");

            this._port = acInfo.SysConfig.GetSysConfigByMemory("SMTP_PORT").toInt();

            //this.sendAddress = new MailAddress("mes@lsmtron.com","사출사업부 MES",System.Text.Encoding.UTF8);
            MailboxAddress from = new MailboxAddress(Encoding.UTF8, sendName, sendMail);
            mail.From.Add(from);


        }

        public void SetToAddressList(string[] toAddress)
        {
            foreach (string address in toAddress)
            {
                if (address != null && address != string.Empty)
                    mail.To.Add(MailboxAddress.Parse(address));
            }
        }

        public void SetCcAddressList(string[] ccAddress)
        {
            foreach (string address in ccAddress)
            {
                if (address != null && address != string.Empty)
                    mail.Cc.Add(MailboxAddress.Parse(address));
            }
        }

        //public void SetBccAddressList(string[] bccAddress)
        //{
        //    foreach (string address in bccAddress)
        //    {
        //        mail.To.Add(address);
        //    }
        //}

        //public void SetAttatchFileList(string[] files, string type = "", string strClass = "", string linkKey = "")
        //{
        //    foreach (string file in files)
        //    {
        //        if (!File.Exists(file))
        //            throw new Exception(string.Format("첨부 파일을 찾을수 없습니다.[{0}]", file));

        //        mail.Attachments.Add(new Attachment(new FileStream(file, FileMode.Open, FileAccess.Read), Path.GetFileName(file)));
        //    }

        //    if (type != "")
        //    {
        //        DataTable paramTable = new DataTable("RQSTDT");
        //        paramTable.Columns.Add("PLT_CODE", typeof(string));
        //        paramTable.Columns.Add("UPLOAD_CLASS", typeof(string));
        //        paramTable.Columns.Add("LINK_KEY", typeof(string));

        //        DataRow paramRow = paramTable.NewRow();
        //        paramRow["PLT_CODE"] = acInfo.PLT_CODE;
        //        paramRow["UPLOAD_CLASS"] = strClass;
        //        paramRow["LINK_KEY"] = linkKey;

        //        paramTable.Rows.Add(paramRow);

        //        DataSet paramSet = new DataSet();
        //        paramSet.Tables.Add(paramTable);


        //        DataSet resultSet = BizRun.QBizRun.ExecuteService(this, "CTRL", "ATTACH_FILE_MASTER_SER3", paramSet, "RQSTDT", "RSLTDT");

        //        //DataSet resultSet = BizRun.QBizRun.ExecuteService(this, "ATTACH_FILE_MASTER_SER3", paramSet, "RQSTDT", "RSLTDT");

        //        acFTP acFtp1 = new acFTP();
        //        acFtp1.Server = acInfo.SysConfig.GetSysConfigByServer("FTP_ADDRESS");
        //        acFtp1.ServerPort = acInfo.SysConfig.GetSysConfigByServer("FTP_PORT").toInt();
        //        acFtp1.Username = acInfo.SysConfig.GetSysConfigByServer("FTP_USERID");
        //        acFtp1.Password = acInfo.SysConfig.GetSysConfigByServer("FTP_PASSWORD");

        //        acFtp1.FileType = FileType.Image;
        //        acFtp1.DoEvents = true;
        //        acFtp1.Passive = true;
        //        acFtp1.Restart = false;


        //        string dir = "";

        //        string orginfilename = "";
        //        string filename = "";
        //        string fileID = "";

        //        foreach (DataRow row in resultSet.Tables["RSLTDT"].Rows)
        //        {
        //            dir = row["REG_DATE"].ToString().Substring(0, 10);

        //            orginfilename = row["FILE_NAME"].ToString();
        //            filename = row["FILE_ID"].ToString() + getExtName(resultSet.Tables["RSLTDT"].Rows[0]["FILE_NAME"].ToString());
        //            fileID = row["FILE_ID"].ToString();

        //            //string fileDir = string.Format(@"{0}\{1}\{2}", acInfo.GetTempSystemDirectory(), fileID, orginfilename);

        //            Stream ftpResult = acFtp1.Get(string.Format(@"{0}\{1}\{2}", acInfo.PLT_CODE, dir, filename));

        //            //System.Diagnostics.Process.Start(ftpResult.LocalFileName);
        //            mail.Attachments.Add(new Attachment(ftpResult, orginfilename));
        //        }

        //        acFtp1.Close();
        //        acFtp1 = null;
        //    }
        //}

        Dictionary<string, string> dirDic = new Dictionary<string, string>();
        public void SetBodyAttatchFileList(FileStream fsAttach, string type = "", string strClass = "", string linkKey = "", string body = "")
        {

            var builder = new BodyBuilder();
            builder.TextBody = body;
            
            string path = fsAttach.Name;

            fsAttach.Dispose();
            fsAttach.Close();

            fsAttach = null;

            fsAttach = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

            builder.Attachments.Add(fsAttach.Name);

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

                    string fileDir = string.Format(@"{0}\{1}\{2}", acInfo.GetTempSystemDirectory(), fileID, orginfilename);



                    if (File.Exists(fileDir))
                    {
                        FileInfo fInfo = new FileInfo(fileDir);

                        string dirInfo = fInfo.DirectoryName;

                        File.Delete(fileDir);

                        DirectoryInfo dInfo = new DirectoryInfo(dirInfo);
                        if (dInfo.Exists)
                        {
                            dInfo.Delete();
                        }

                    }

                    FtpFile ftpResult = acFtp1.Get(string.Format(@"{0}\{1}\{2}", acInfo.PLT_CODE, dir, filename), fileDir);


                    FileStream fsAttach2 = new FileStream(fileDir, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

                    path = fsAttach2.Name;

                    fsAttach2.Close();
                    fsAttach2.Dispose();

                    fsAttach2 = null;

                    var attachment = builder.Attachments.Add(path);

                    foreach (var parameter in attachment.ContentType.Parameters)
                    {
                        parameter.EncodingMethod = ParameterEncodingMethod.Rfc2047;
                    }

                    foreach (var parameter in attachment.ContentDisposition.Parameters)
                    {
                        parameter.EncodingMethod = ParameterEncodingMethod.Rfc2047;
                    }

                    if (!dirDic.ContainsKey(fileDir))
                    {
                        dirDic.Add(fileDir, fileDir);
                    }
                }

                acFtp1.Close();
                acFtp1 = null;


            }

            mail.Body = builder.ToMessageBody();
            


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


        public bool SendEmail(object sender, string subject)
        {
            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String));
            paramTable.Columns.Add("LINK_NO", typeof(String));
            paramTable.Columns.Add("FROM", typeof(String));
            paramTable.Columns.Add("TO", typeof(String));
            paramTable.Columns.Add("CC", typeof(String));
            paramTable.Columns.Add("SUBJECT", typeof(String));
            paramTable.Columns.Add("BODY", typeof(String));
            paramTable.Columns.Add("ATTATCH_FILE", typeof(String));
            paramTable.Columns.Add("RESULT", typeof(String));

            string result = "SUCCESS";

            try
            {

                mail.Subject = subject;

                var smtp = new SmtpClient();
                //smtp.Connect(acInfo.SysConfig.GetSysConfigByMemory("SMTP_ADDRESS"), acInfo.SysConfig.GetSysConfigByMemory("SMTP_PORT").toInt(), SecureSocketOptions.StartTls);
                //smtp.Authenticate(acInfo.SysConfig.GetSysConfigByMemory("SMTP_USERID"), acInfo.SysConfig.GetSysConfigByMemory("SMTP_PASSWORD"));

                smtp.Connect("smtp.office365.com", 587, SecureSocketOptions.StartTls);
                smtp.Authenticate("Gume@kyung-dong.co.kr", "kyungdong#1288105020");

                smtp.Send(mail);
                smtp.Disconnect(true);


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
                paramRow["CC"] = mail.Cc.ToString();
                paramRow["SUBJECT"] = mail.Subject;
                paramRow["BODY"] = mail.TextBody;
                //if (mail.Attachments.Count > 0)
                //    paramRow["ATTATCH_FILE"] = mail.Attachments[0].Name;

                paramRow["RESULT"] = result;
                paramTable.Rows.Add(paramRow);

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(sender, "CTRL", "SET_EMAILSEND_LOG", paramSet, "RQSTDT", "RSLTDT");

                if (mail != null) mail.Dispose();


                foreach (KeyValuePair<string, string> dic in dirDic)
                {
                    FileInfo fInfo = new FileInfo(dic.Key);

                    string dirInfo = fInfo.DirectoryName;


                    if (File.Exists(dic.Key))
                    {
                        File.Delete(dic.Key);
                    }

                    DirectoryInfo dInfo = new DirectoryInfo(dirInfo);
                    if (dInfo.Exists)
                    {
                        dInfo.Delete();
                    }

                }
            }


        }

        //public bool SendEmail(object sender, string subject, string body, bool isBotyHtml)
        //{

        //    try
        //    {

        //        mail.Subject = subject;

        //        mail.Body = body;

        //        mail.IsBodyHtml = isBotyHtml;

        //        mail.SubjectEncoding = System.Text.Encoding.UTF8;

        //        mail.BodyEncoding = System.Text.Encoding.UTF8;

        //        //SmtpClient smtpServer = new SmtpClient("smtp.cubictek.co.kr");
        //        SmtpClient smtpServer = new SmtpClient(this._serverIP);

        //        //smtpServer.Port = 25;
        //        smtpServer.Port = _port;

        //        //smtpServer.Credentials = new System.Net.NetworkCredential(this._id, this._password);
        //        smtpServer.Credentials = new System.Net.NetworkCredential(this._id, this._password);

        //        //smtpServer.EnableSsl = false;
        //        smtpServer.EnableSsl = _useSSL;

        //        DataTable paramTable = new DataTable("RQSTDT");
        //        paramTable.Columns.Add("PLT_CODE", typeof(String));
        //        paramTable.Columns.Add("LINK_NO", typeof(String));
        //        paramTable.Columns.Add("TO", typeof(String));
        //        paramTable.Columns.Add("SUBJECT", typeof(String));
        //        paramTable.Columns.Add("BODY", typeof(String));
        //        paramTable.Columns.Add("ATTATCH_FILE", typeof(String));

        //        DataRow paramRow = paramTable.NewRow();
        //        paramRow["PLT_CODE"] = acInfo.PLT_CODE;
        //        paramRow["LINK_NO"] = this._LINK_NO;
        //        paramRow["TO"] = mail.To.ToString();
        //        paramRow["SUBJECT"] = mail.Subject;
        //        paramRow["BODY"] = mail.Body;
        //        if (mail.Attachments.Count > 0)
        //            paramRow["ATTATCH_FILE"] = mail.Attachments[0].Name;

        //        paramRow["BODY"] = mail.Body;
        //        paramTable.Rows.Add(paramRow);

        //        DataSet paramSet = new DataSet();
        //        paramSet.Tables.Add(paramTable);

        //        BizRun.QBizRun.ExecuteService(sender, "CTRL", "SET_EMAILSEND_LOG", paramSet, "RQSTDT", "RSLTDT");

        //        smtpServer.Send(mail);

        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        if (ex.Message.ToString().Contains("Too many recipients")
        //            || ex.InnerException.ToString().Contains("Too many recipients")
        //            || ex.Message.ToString().Contains("받는 사람에게 보낼 수 없습니다"))
        //        {
        //            return true;
        //        }
        //        return false;
        //    }
        //    finally
        //    {
        //        if (mail != null) mail.Dispose();
        //    }


        //}
    }
}