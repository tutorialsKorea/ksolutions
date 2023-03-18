using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Resources;
using System.IO;
using mshtml;


namespace AppManager
{



    [ClassInterface(ClassInterfaceType.None), ComSourceInterfaces(typeof(IEvent))]
    public sealed partial class Core : DevExpress.XtraEditors.XtraUserControl, IProperty
    {

        public delegate void LogInHandler();

        public event LogInHandler LogIn;

        public delegate void LogOutHandler();

        public event LogOutHandler LogOut;

        public delegate void ErrorHandler(string errorMessage);

        public event ErrorHandler Error;

        public Core()
        {
            InitializeComponent();


        }

        public static ResourceManager ResManager = null;

        protected override void OnLoad(EventArgs e)
        {

            //지역화
            switch (this._LCID)
            {

                case 1042:

                    //한국어
                    ResManager = LangPack_ko_KR.ResourceManager;



                    break;

                case 1041:

                    //일본어
                    ResManager = LangPack_ja_JP.ResourceManager;

                    break;

                case 2052:

                    //중국어

                    ResManager = LangPack_zh_CHS.ResourceManager;

                    break;

            }

            base.OnLoad(e);
        }

        void mainViewer_LogOut(string userInfo)
        {


            if (this.LogOut != null)
            {
                this.LogOut();
            }
        }

        #region IProperty 멤버

        private int _LCID = 1042;

        public int LCID
        {
            get
            {
                return _LCID;
            }
            set
            {

                this._LCID = value;

            }
        }


        private SHDocVw.IWebBrowser2 _IEWebBrowser2 = null;

        public void ShowViewer(string url, string userAgent, string desLogin)
        {
            try
            {

                if (ControlManager.acInfo.ApplicationCnt > 0)
                {
                    if (this.Error != null)
                    {
                        //중복실행오류

                        this.Error(ResManager.GetString("APP_OVERLAP"));

                        return;
                    }
                }

                //여러개 url로 했을경우 문제생길수있음


                SHDocVw.ShellWindows shellWindows = new SHDocVw.ShellWindowsClass();


                foreach (SHDocVw.IWebBrowser2 ie in shellWindows)
                {
                    if (ie.LocationURL.Contains(url))
                    {
                        if (ie.Visible == true)
                        {
                            HTMLDocumentClass doc = (HTMLDocumentClass)ie.Document;

                            if (doc.IHTMLDocument2_title == url)
                            {
                                this._IEWebBrowser2 = ie;

                                ie.Visible = false;

                                break;
                            }


                        }

                    }
                }



                Viewer mainViewer = new Viewer(desLogin);

                mainViewer.HandleDestroyed += new EventHandler(mainViewer_HandleDestroyed);

                mainViewer.LogOut += new Viewer.LogOutHandler(mainViewer_LogOut);


                if (this.LogIn != null)
                {
                    this.LogIn();
                }



                mainViewer.ShowDialog();

            }
            catch (Exception ex)
            {
                if (this.Error != null)
                {
                    this.Error(ex.Message);
                }
            }

        }



        void mainViewer_HandleDestroyed(object sender, EventArgs e)
        {
            if (_IEWebBrowser2 != null)
            {
                this._IEWebBrowser2.Visible = true;
            }
        }



        #endregion
    }
}