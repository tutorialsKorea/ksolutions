using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ControlManager;

namespace AppManager
{
    public sealed partial class Viewer : DevExpress.XtraEditors.XtraForm
    {
        public delegate void LogOutHandler(string userInfo);

        public event LogOutHandler LogOut;

        //private MainForm.MainForm _MainControl = null;

        public Viewer(string desLogin)
        {
            InitializeComponent();

            //_MainControl = new MainForm.MainForm();

            //_MainControl.DesLogin = desLogin;
            
            //_MainControl.ParentControl = this;

            //_MainControl.IsDevMode = false;

            //_MainControl.Dock = DockStyle.Fill;

            //_MainControl.LogOut += new MainForm.MainForm.LogOutHandler(MainControl_LogOut);

         
            //this.Controls.Add(_MainControl);

            this.WindowState = FormWindowState.Maximized;

        }
        
        protected override void OnClosing(CancelEventArgs e)
        {


            //if (_MainControl.IsProcessingPage() == true)
            //{
            //    e.Cancel = true;

            //    return;
            //}

            //if (_MainControl.InitUserConfig == false)
            //{

            //    if (acMessageBox.Show(acInfo.Resource.GetString("정말 종료하시겠습니까?", "XPCDAJOT"), acInfo.SystemName, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
            //    {
            //        e.Cancel = true;

            //        return;
            //    }
            //}



            //if (_MainControl.DestoryAllMenuPage() == false)
            //{
            //    e.Cancel = true;

            //    return;
            //}

            //_MainControl.SaveControlUserConfigs();


            base.OnClosing(e);
        }

        protected override void WndProc(ref Message m)
        {

            switch (m.Msg)
            {


                case WIN32API.WM_COPYDATA:
                    {
                        WIN32API.COPYDATASTRUCT mystr = new WIN32API.COPYDATASTRUCT();

                        Type mytype = mystr.GetType();

                        mystr = (WIN32API.COPYDATASTRUCT)m.GetLParam(mytype);

                        //_MainControl.ReceiveWindowMessage(mystr.lpData);
                    }


                    break;
            }

            base.WndProc(ref m);

        }

        void MainControl_LogOut(string userInfo)
        {

            if (this.LogOut != null)
            {
                this.LogOut(null);
            }
        }

    }
}