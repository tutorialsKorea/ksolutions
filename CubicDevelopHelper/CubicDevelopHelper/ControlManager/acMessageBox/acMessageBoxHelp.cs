using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Reflection;
using System.IO;
using System.Net;
using System.Threading;

namespace ControlManager
{
    public partial class acMessageBoxHelp : ControlManager.acForm
    {

        private string _ClassName = null;
        
        public acMessageBoxHelp(string className)
        {

            InitializeComponent();

            this._ClassName = className;



        }

        private QThread _HelpFileDownloadThread = null;


        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            string downloadFileName = string.Format(@"{0}\{1}.xps", acInfo.GetTempSystemDirectory(), this._ClassName);

            FileInfo fi = new FileInfo(downloadFileName);

            if (fi.Exists == false)
            {
                this._HelpFileDownloadThread = new QThread(this, QThread.emExecuteType.DOWNLOAD);

                this._HelpFileDownloadThread.Execute(quckSupportThreadStarter, downloadFileName);

            }
            else
            {
                webBrowser1.Navigate(downloadFileName);
            }


 

        }

        void quckSupportThreadStarter(object args)
        {

            string downloadFileName = args as string;

            try
            {
                WebClient webClient = new WebClient();

                string helpFile = string.Format(@"{0}/{1}.{2}", acInfo.SysConfig.GetSysConfigByMemory("HELP_URL"), this._ClassName, "xps");

                webClient.DownloadFile(new Uri(helpFile), downloadFileName);

                this.BeginInvoke((MethodInvoker)delegate
                {

                    if (this._HelpFileDownloadThread.IsThreadAbort == false)
                    {
                        webBrowser1.Navigate(downloadFileName);
                    }

                });

            }
            catch (Exception ex)
            {

                if (ex is ThreadAbortException)
                {
                    FileInfo fi = new FileInfo(downloadFileName);

                    fi.Delete();

                    this.Close();
                }
                else if (ex is WebException)
                {
                    this.BeginInvoke((MethodInvoker)delegate
                    {
                        acMessageBox.Show(this, ex.Message, string.Empty, false, acMessageBox.emMessageBoxType.CONFIRM);

                        this.Close();
                    });
                    
                }
                else
                {
                    this.BeginInvoke((MethodInvoker)delegate
                    {
                        acMessageBox.Show(this, ex);

                        this.Close();

                    });

                }
            }

        }

        protected override void OnHandleDestroyed(EventArgs e)
        {
            webBrowser1.Dispose();


            base.OnHandleDestroyed(e);
        }

        protected override void OnClosed(EventArgs e)
        {
            acInfo.HelpForms.Remove(this._ClassName);
            
            base.OnClosed(e);
        }


    }
}