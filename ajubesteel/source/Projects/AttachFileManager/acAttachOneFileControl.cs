using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ControlManager;
using System.Threading;
using BizManager;
using System.IO;

namespace AttachFileManager
{
    public partial class acAttachOneFileControl : UserControl
    {
        private string _FileID = null;
        private string _FileKey = null;
        private string _LinkKey = null;
        public string LinkKey
        {
            get => _LinkKey;
            set { 
                _LinkKey = value;
                this.RefreshFile();
            }
        }

        private Control _ParentControl = null;
        public Control ParentControl
        {
            get { return _ParentControl; }

            set
            {
                _ParentControl = value;
            }
        }

        public acAttachOneFileControl()
        {
            InitializeComponent();

            txtFileName.MouseDown += TxtFileName_MouseDown;
        }

        #region 다운로드
        private void TxtFileName_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if(e.Button == MouseButtons.Left && e.Clicks == 2)
                {
                    //링크키가 존재하며, 파일명이 존재할때
                    if(LinkKey != null && _FileID.isNullOrEmpty() == false)
                    {
                        //다운로드 및 실행
                        ThreadPool.QueueUserWorkItem(new WaitCallback(DownLoadMasterThreadStarter), _FileID);
                    }
                }
            }
            catch(Exception ex)
            {

            }
        }

        private void DownLoadMasterThreadStarter(object args)
        {

            string fileId = args as string;

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("FILE_ID", typeof(String)); //

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["FILE_ID"] = fileId;

            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.NONE, "CTRL",
                "ATTACH_FILE_MASTER_SER2", paramSet, "RQSTDT", "RSLTDT", fileId,
                DownLoadMasterThreadCallBack,
                QuickMasterException);
        }

        void DownLoadMasterThreadCallBack(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                Thread t = new Thread(new ParameterizedThreadStart(FtpDownloadCallBack));

                t.Start(e);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this.ParentControl, ex);
            }

        }

        void FtpDownloadCallBack(object args)
        {
            QBiz.ExcuteCompleteArgs e = args as BizManager.QBiz.ExcuteCompleteArgs;

            string fileId = e.parameter as string;

            DataSet fileSet = e.result;

            DataRow resultRow = fileSet.Tables["RSLTDT"].Rows[0];

            //FileInfo fi = new FileInfo(fileRow["FILE_FULL_NAME"].ToString());

            acFTP acFtp1 = new acFTP();

            acFtp1.Progress += new FtpProgressEventHandler(acFtp1_Progress);

            acFtp1.FileID = resultRow["FILE_ID"].ToString();

            acFtp1.Server = acInfo.SysConfig.GetSysConfigByServer("FTP_ADDRESS");
            acFtp1.ServerPort = acInfo.SysConfig.GetSysConfigByServer("FTP_PORT").toInt();
            acFtp1.Username = acInfo.SysConfig.GetSysConfigByServer("FTP_USERID");
            acFtp1.Password = acInfo.SysConfig.GetSysConfigByServer("FTP_PASSWORD");


            acFtp1.FileType = FileType.Image;
            acFtp1.DoEvents = true;
            acFtp1.Passive = true;
            acFtp1.Restart = false;

            try
            {
                string fileDir = string.Format(@"{0}\{1}", acInfo.GetTempSystemDirectory(), resultRow["FILE_ID"]);

                if (!Directory.Exists(fileDir))
                {
                    Directory.CreateDirectory(fileDir);
                }


                string fileName = string.Format(@"{0}\{1}", fileDir, resultRow["FILE_NAME"]);

                string dir = resultRow["REG_DATE"].ToString().Substring(0, 10);
                //string filename = resultRow["FILE_ID"].ToString() + "_" + resultRow["FILE_NAME"].ToString();
                string filename = resultRow["FILE_ID"].ToString() + getExtName(resultRow["FILE_NAME"].ToString());
                //FtpFile ftpResult = acFtp1.Get(string.Format(@"{0}\{1}\{2}", acInfo.PLT_CODE, resultRow["FILE_ID"], resultRow["FILE_NAME"]), fileRow["FILE_FULL_NAME"].ToString());
                FtpFile ftpResult = acFtp1.Get(string.Format(@"{0}\{1}\{2}", acInfo.PLT_CODE, dir, filename), fileName);

                this.FtpDownloadResult(acFtp1, ftpResult);

            }
            catch (Exception ex)
            {
                this.Invoke(new FtpTransferExceptionDeleteInvoker(FtpTransferExceptionDelete), acFtp1, ex);
            }

        }
        private delegate void FtpDownloadCancelInvoker(string ftpKey);

        private void FtpDownloadResult(acFTP ftp, FtpFile file)
        {
            try
            {
                if (file.Exception != null)
                {
                    //전송예외
                    this.Invoke(new FtpDownloadCancelInvoker(FtpDownloadCancel), ftp.TransferKey);
                    acMessageBox.Show(this._ParentControl, file.Exception);
                }
                else if (file.Count == -1)
                {
                    //중단
                    this.Invoke(new FtpDownloadCancelInvoker(FtpDownloadCancel), ftp.TransferKey);
                }
                else if (file.Position != file.Length)
                {
                    //전송취소는 파일삭제 
                    FileInfo fi = new FileInfo(file.LocalFileName);
                    fi.Delete();
                    this.Invoke(new FtpDownloadCancelInvoker(FtpDownloadCancel), ftp.TransferKey);
                }
                else
                {
                    //전송 성공
                    this.Invoke(new FtpSuccessInvoker(FtpDownloadSuccess), ftp, file);
                }

            }
            catch (Exception ex)
            {
                this.Invoke(new FtpTransferExceptionDeleteInvoker(FtpTransferExceptionDelete), ftp, ex);
            }
            finally
            {
                ftp.Close();
            }
        }

        /// <summary>
        /// FTP전송 키 삭제
        /// </summary>
        /// <param name="key"></param>
        void FtpDownloadCancel(string ftpKey)
        {
            if (this.IsDisposed == false)
            {

            }
        }

        void FtpDownloadSuccess(acFTP ftp, FtpFile file)
        {
            try
            {
                if (this.IsDisposed == false)
                {
                    //열기모드
                    System.Diagnostics.Process.Start(file.LocalFileName);
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this.ParentControl, ex);
            }


        }

        #endregion

        #region 업로드
        private void btnUpload_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "*.PDF(문서) | *.PDF;";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    //업로드
                    if (LinkKey != null)
                    {
                        ThreadPool.QueueUserWorkItem(new WaitCallback(UpLoadMasterThreadStarter), ofd.FileName);
                    }
                }
            }
            catch(Exception ex)
            {

            }
        }
        void acFtp1_Progress(object sender, FtpProgressEventArgs e)
        {
            this.Invoke(new FtpProgressInvoker(FtpProgress), sender, e);

        }
        void FtpProgress(object sender, FtpProgressEventArgs e)
        {
            acFTP ftp = sender as acFTP;

            if (e.Length > 0)
            {

                double per = (e.Position.toDouble() / e.Length.toDouble());

                //textbox 채우는거 보여주기
            }
        }
        private delegate void FtpTransferExceptionDeleteInvoker(acFTP ftp, Exception ex);

        private void UpLoadMasterThreadStarter(object args)
        {
            string fileName = args as string;

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("FILE_KEY", typeof(String)); //
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("FILE_NAME", typeof(String)); //
            paramTable.Columns.Add("FILE_SIZE", typeof(Decimal)); //
            paramTable.Columns.Add("LINK_KEY", typeof(String)); //
            paramTable.Columns.Add("REG_EMP", typeof(String)); //
            paramTable.Columns.Add("UPLOAD_MENU", typeof(String)); //
            paramTable.Columns.Add("UPLOAD_CLASS", typeof(String)); //
            paramTable.Columns.Add("FILE_FULL_NAME", typeof(String)); //
            
            FileInfo fInfo = new FileInfo(fileName);

            DataRow paramRow = paramTable.NewRow();
            paramRow["FILE_KEY"] = System.Guid.NewGuid().ToString();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["FILE_NAME"] = fInfo.Name;
            paramRow["FILE_SIZE"] = fInfo.Length;
            paramRow["LINK_KEY"] = this.LinkKey;
            paramRow["REG_EMP"] = acInfo.UserID;
            paramRow["FILE_FULL_NAME"] = fInfo.FullName;
            paramRow["UPLOAD_MENU"] = (BaseMenu.GetBaseControl(this._ParentControl) as IBase).MenuCode;
            paramRow["UPLOAD_CLASS"] = this._ParentControl.Name;


            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            BizRun.QBizRun.ExecuteService(
                    this, QBiz.emExecuteType.NONE, "CTRL", "ATTACH_FILE_MASTER_INS_T", paramSet, "RQSTDT", "RSLTDT",
                    UpLoadMasterThreadCallBack,
                    QuickMasterException);
        }


        void UpLoadMasterThreadCallBack(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                Thread t = new Thread(new ParameterizedThreadStart(FtpUploadCallBack));
                t.Start(e.result);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this.ParentControl, ex);
            }
        }

        void FtpUploadCallBack(object args)
        {
            DataSet fileSet = args as DataSet;

            DataRow paramRow = fileSet.Tables["RQSTDT"].Rows[0];
            DataRow resultRow = fileSet.Tables["RSLTDT"].Rows[0];

            string dir = resultRow["REG_DATE"].ToString().Substring(0, 10);

            FileInfo fi = new FileInfo(paramRow["FILE_FULL_NAME"].ToString());

            //string remoteFullFileName = string.Format(@"{0}\{1}\{2}", acInfo.PLT_CODE, resultRow["FILE_ID"], paramRow["FILE_NAME"]);

            string extname = getExtName(paramRow["FILE_NAME"].ToString());

            string filename = resultRow["FILE_ID"].ToString() + extname;

            string remoteFullFileName = string.Format(@"{0}\{1}\{2}", acInfo.PLT_CODE, dir, filename);

            acFTP acFtp1 = new acFTP();

            //this._FtpDic.Add(paramRow["FILE_KEY"].ToString(), acFtp1);

            acFtp1.Progress += new FtpProgressEventHandler(acFtp1_Progress);

            acFtp1.FileID = resultRow["FILE_ID"].ToString();
            acFtp1.TransferKey = paramRow["FILE_KEY"].ToString();

            acFtp1.LinkData = paramRow.NewCopy();

            acFtp1.Server = acInfo.SysConfig.GetSysConfigByServer("FTP_ADDRESS");
            acFtp1.ServerPort = acInfo.SysConfig.GetSysConfigByServer("FTP_PORT").toInt();
            acFtp1.Username = acInfo.SysConfig.GetSysConfigByServer("FTP_USERID");
            acFtp1.Password = acInfo.SysConfig.GetSysConfigByServer("FTP_PASSWORD");


            acFtp1.FileType = FileType.Image;
            acFtp1.DoEvents = true;
            acFtp1.Passive = true;
            acFtp1.Restart = false;

            try
            {
                FtpFile ftpResult = acFtp1.Put(fi.FullName, remoteFullFileName);

                this.FtpUploadResult(acFtp1, ftpResult);
            }
            catch (Exception ex)
            {
                this.Invoke(new FtpTransferExceptionDeleteInvoker(FtpTransferExceptionDelete), acFtp1, ex);
            }

        }

        private delegate void FtpProgressInvoker(object sender, FtpProgressEventArgs e);

        /// <summary>
        /// FTP전송 키 삭제
        /// </summary>
        /// <param name="key"></param>
        void FtpTransferExceptionDelete(acFTP ftp, Exception ex)
        {
        }

        private void FtpUploadResult(acFTP ftp, FtpFile file)
        {
            try
            {
                if (file.Exception != null)
                {
                    //전송예외
                    this.Invoke(new FtpUploadCancelInvoker(FtpUploadCancel), ftp);
                    acMessageBox.Show(this._ParentControl, file.Exception);
                }
                else if (file.Count == -1)
                {
                    //중단
                    this.Invoke(new FtpUploadCancelInvoker(FtpUploadCancel), ftp);
                }
                else if (file.Position != file.Length)
                {
                    //전송취소
                    this.Invoke(new FtpUploadCancelInvoker(FtpUploadCancel), ftp);
                }
                else
                {
                    //전송 성공
                    this.Invoke(new FtpSuccessInvoker(FtpUploadSuccess), ftp, file);
                }

            }
            catch (Exception ex)
            {
                this.Invoke(new FtpTransferExceptionDeleteInvoker(FtpTransferExceptionDelete), ftp, ex);
            }
            finally
            {
                ftp.Close();
            }
        }

        void QuickMasterException(object sender, QBiz qBiz, BizManager.BizException ex)
        {

            DataRow row = qBiz.RefData.Tables["RQSTDT"].Rows[0];

            if(row != null)
            {
                qBiz.Start();
            }

            //DataRow keyRow = FileTransferGridView.GetRow("FILE_KEY = '" + row["FILE_KEY"] + "'");


            //if (keyRow != null)
            //{
            //    qBiz.Start();
            //}
        }

        private delegate void FtpUploadCancelInvoker(acFTP ftp);

        /// <summary>
        /// Upload중 취소
        /// </summary>
        /// <param name="ftp"></param>
        void FtpUploadCancel(acFTP ftp)
        {

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("FILE_ID", typeof(String)); //

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["FILE_ID"] = ftp.FileID;
            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            BizRun.QBizRun.ExecuteService(this, "CTRL", "ATTACH_FILE_MASTER_DEL2", paramSet, "RQSTDT", "");

            if (this.IsDisposed == false)
            {
                DataRow linkRow = ftp.LinkData as DataRow;

                string filename = linkRow["FILE_NAME"].ToString();
                string remoteFileName = ftp.FileID + getExtName(filename);
                string remoteFullPath = string.Format(@"{0}\{1}\{2}", acInfo.PLT_CODE, linkRow["REG_DATE"].ToString().Substring(0, 10), remoteFileName);
                ftp.Delete(remoteFullPath);
            }
        }

        private delegate void FtpSuccessInvoker(acFTP ftp, FtpFile file);

        void FtpUploadSuccess(acFTP ftp, FtpFile file)
        {

            try
            {
                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("FILE_ID", typeof(String)); //

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["FILE_ID"] = ftp.FileID;
                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(this, "CTRL", "ATTACH_FILE_MASTER_COMPLETE", paramSet, "RQSTDT", "");

                //ftp.LinkData
                DataRow linkRow = ftp.LinkData as DataRow;
            }

            catch (Exception ex)
            {
                acMessageBox.Show(this.ParentControl, ex);
            }

        }
        #endregion

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

        /// <summary>
        /// 첨부된 파일을 갱신한다.
        /// </summary>
        private void RefreshFile()
        {
            if (_LinkKey == null)
                return;

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("LINK_KEY", typeof(String)); //
            paramTable.Columns.Add("LANG", typeof(String)); //

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["LINK_KEY"] = LinkKey;
            paramRow["LANG"] = acInfo.Lang;
            paramTable.Rows.Add(paramRow);

            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            DataSet dsResult = BizRun.QBizRun.ExecuteService(this, "CTRL", "ATTACH_FILE_MASTER_SER", paramSet, "RQSTDT", "RSLTDT,RSLTDT2");

            if (dsResult.Tables["RSLTDT"].AsEnumerable()
                                .OrderByDescending(o => o["REG_DATE"])
                                .FirstOrDefault()
                       is DataRow row)
            {
                txtFileName.Text = row["FILE_NAME"].toStringEmpty();
                _FileID = row["FILE_ID"].toStringEmpty();
            }
            else
            {
                txtFileName.Text = null;
                _FileID = null;
            }
        }
    }
}
