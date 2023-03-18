using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Collections;
using System.Reflection;
using System.Xml;
using System.Net;

using DevExpress.XtraEditors;
using DevExpress.XtraNavBar;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraTab;
using DevExpress.XtraVerticalGrid.Rows;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraBars;
using DevExpress.Utils;
using ControlManager;
using GemBox.Spreadsheet;
using BizManager;
using DevExpress.XtraEditors.ColorWheel;
using DevExpress.XtraBars.Navigation;
using DevExpress.XtraBars.Docking2010.Views.Tabbed;

namespace LogInForm
{
    public partial class MainForm_V2 : DevExpress.XtraEditors.XtraForm, IMainControl
    {
        private int childFormNumber = 0;

        private bool bDoExit = false;

        /// <summary>
        /// 알람 목록
        /// </summary>
        public Dictionary<int, acMessageBoxNotify> _NotifyList = new Dictionary<int, acMessageBoxNotify>();

        /// <summary>
        /// 로드된 어셈블리 목록
        /// </summary>
        private Dictionary<string, Assembly> _LoadAssemblysDic = new Dictionary<string, Assembly>();

        /// <summary>
        /// 열어진 탭페이지
        /// </summary>
        //private Dictionary<string, XtraTabPage> _OpenDocumentDic = new Dictionary<string, XtraTabPage>();


        private Dictionary<string, Document> _OpenDocumentDic = new Dictionary<string, Document>();

        private Dictionary<string, DataRow> _MyMenu = new Dictionary<string, DataRow>();

        /// <summary>
        /// 기본 탭페이지
        /// </summary>
        //private Dictionary<string, XtraTabPage> _DefaultTabPageDic = new Dictionary<string, XtraTabPage>();

        private Dictionary<string, Document> _DefaultDocumentDic = new Dictionary<string, Document>();

        private System.Threading.Timer _SystemVersionChecker = null;

        private System.Threading.Timer _VersionChecker = null;

        private bool _IsNotifyLoop = false;

        private bool _NotifyUpdate = false;

        private System.Threading.Timer _NotifyChecker = null;

        private ConnectMember _ConnectMember = null;

        public ConnectMember ConnectMember
        {
            get { return _ConnectMember; }
            set { _ConnectMember = value; }
        }

        private DataTable _MenuList = null;

        public DataTable serverItemsTable = null;

        private const string CONFIG_FULLPATH = @"C:\CubicTek\Config.xml";

        public MainForm_V2(string serverIP,
            string databaseName,
            string plant,
            string lang,
            string userID,
            string skin,
            string assembly)
        {
            InitializeComponent();

            ConfigMember tmpConfig = new ConfigMember();

            ControlManager.acInfo.ServerIp = serverIP;
            ControlManager.acInfo.PLT_CODE = plant;
            ControlManager.acInfo.Lang = lang;
            ControlManager.acInfo.UserID = userID;
            ControlManager.acInfo.Skin = skin;
            ControlManager.acInfo.DatabaseName = databaseName;
            ControlManager.acInfo.IsRunTime = true;

            LoadMainForm_V2(userID);
        }

        public MainForm_V2(string userID)
        {
            InitializeComponent();

            LoadMainForm_V2(userID);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (acInfo.SysConfig.GetSysConfigByMemory("IS_FORM_ICON_COLOR_USE").toStringEmpty().Equals("1"))
            {
                navMenuChildButtonIconChange(navMenu, acInfo.SysConfig.GetSysConfigByMemory("ICON_COLOR").toColor());
                BarManagerChildButtonIconChange(acBarManager1, acInfo.SysConfig.GetSysConfigByMemory("ICON_COLOR").toColor());
            }

            if (acInfo.MenuLocation.Equals("H"))
            {
                acDockPanel1.SendToBack();
                acDockPanel1.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Hidden;

            }

            chkMymenu.Enabled = false;

        }


        void navMenuChildButtonIconChange(NavBarControl nbc, Color iconColor)
        {
            if (nbc == null)
                return;
            foreach (NavBarGroup ngc in nbc.Groups)
            {
                if (ngc.LargeImage != null)
                {
                    ngc.LargeImage = ChangeIconColor(ngc.LargeImage, iconColor);
                }
            }
        }

        void BarManagerChildButtonIconChange(acBarManager barManage, Color iconColor)
        {
            if (barManage == null)
                return;
            foreach (BarItem item in barManage.Items)
            {
                if (item.Glyph != null)
                {
                    item.Glyph = ChangeIconColor(item.Glyph, iconColor);
                }
            }
        }

        Bitmap ChangeIconColor(Image img, Color iconColor)
        {

            Bitmap bmp = new Bitmap(img);

            int width = bmp.Width;
            int height = bmp.Height;

            //총 사이즈만큼 반복을 하면서 하나하나의 픽셀을 변경한다.
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    //get pixel value
                    Color p = bmp.GetPixel(x, y);

                    //extract ARGB value from p
                    int a = p.A;

                    if (!(p.R == 255 && p.G == 255 && p.B == 255))
                        bmp.SetPixel(x, y, Color.FromArgb(a, iconColor));
                    //else if(p.R.Equals(p.G) && p.G.Equals(p.B))
                    //    bmp.SetPixel(x, y, Color.FromArgb(a, iconColor));
                    //else
                    //{

                    //}
                }
            }
            return bmp;
        }

        //void acTabControl1_SelectedPageChanged(object sender, TabPageChangedEventArgs e)
        //{
        //    XtraTabPage currentTabPage = (XtraTabPage)e.Page;
        //    if (currentTabPage != null)
        //    {
        //        BaseMenu currentMenuControl = (BaseMenu)FindBaseTypeControl(currentTabPage);

        //        if (currentMenuControl != null)
        //        {

        //            currentMenuControl.MenuGotFocus();
        //        }

        //    }

        //}

        //void acTabControl1_SelectedPageChanging(object sender, TabPageChangingEventArgs e)
        //{
        //    XtraTabPage currentTabPage = (XtraTabPage)e.Page;
        //    XtraTabPage prevTabPage = (XtraTabPage)e.PrevPage;

        //    DataRow row = (DataRow)currentTabPage.Tag;

        //    if (row != null)
        //    {
        //        acInfo.IsPopMenu = row["IS_POP_MENU"].ToString();
        //    }

        //    //기본페이지는 닫지못함
        //    if (currentTabPage != null && prevTabPage != null)
        //    {
        //        if (_DefaultTabPageDic.ContainsValue(currentTabPage))
        //        {
        //            acTabControl1.ClosePageButtonShowMode = ClosePageButtonShowMode.InTabControlHeader;
        //        }
        //        else
        //        {
        //            acTabControl1.ClosePageButtonShowMode = ClosePageButtonShowMode.InActiveTabPageAndTabControlHeader;
        //        }
        //    }

        //    if (currentTabPage != null)
        //    {
        //        BaseMenu currentMenuControl = (BaseMenu)FindBaseTypeControl(currentTabPage);

        //        if (currentMenuControl != null)
        //        {

        //            currentMenuControl.MenuGotFocus();
        //        }

        //    }

        //    if (prevTabPage != null)
        //    {


        //        BaseMenu prevMenuControl = (BaseMenu)FindBaseTypeControl(prevTabPage);

        //        if (prevMenuControl != null)
        //        {
        //            prevMenuControl.MenuLostFocus();
        //        }
        //    }
        //}

        Control FindBaseTypeControl(Control parent)
        {
            foreach (Control child in parent.Controls)
            {
                if (child is BaseMenu)
                {
                    return child;
                }
            }

            return null;
        }

        //void acTabControl1_CloseButtonClick(object sender, EventArgs e)
        //{
        //    //탭 삭제
        //    DevExpress.XtraTab.ViewInfo.ClosePageButtonEventArgs args = (DevExpress.XtraTab.ViewInfo.ClosePageButtonEventArgs)e;

        //    XtraTabPage menuTabPage = (XtraTabPage)args.PrevPage;

        //    if (menuTabPage != null)
        //    {
        //        this.CloseTabPage(menuTabPage);


        //    }
        //    else
        //    {
        //        //전체 탭닫기


        //        if (acMessageBox.Show(this, "열린 모든메뉴를 닫습니까?", "D1LEEIXW", true, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
        //        {
        //            return;
        //        }



        //        List<XtraTabPage> tabPageList = new List<XtraTabPage>();


        //        //열린 모든페이지 목록
        //        foreach (XtraTabPage tabPage in acTabControl1.TabPages)
        //        {
        //            if (!_DefaultTabPageDic.ContainsValue(tabPage))
        //            {

        //                tabPageList.Add(tabPage);

        //            }

        //        }


        //        int idx = this.acTabControl1.SelectedTabPageIndex - 1;

        //        foreach (XtraTabPage tabPage in tabPageList)
        //        {

        //            foreach (Control ctrl in tabPage.Controls)
        //            {
        //                if (ctrl is BaseMenu)
        //                {
        //                    BaseMenu menuControl = ctrl as BaseMenu;

        //                    if (menuControl.MenuDestory(menuControl) == true)
        //                    {

        //                        DataRow menuRow = (DataRow)tabPage.Tag;

        //                        _OpenDocumentDic.Remove(menuRow["CLASSNAME"].ToString());

        //                        acTabControl1.TabPages.Remove(tabPage);

        //                        menuControl.Dispose();

        //                    }

        //                    acTabControl1.SelectedTabPageIndex = idx;

        //                    break;
        //                }

        //            }

        //        }

        //        SaveControlUserConfigs();
        //    }

        //}



        protected override void OnClosing(CancelEventArgs e)
        {

            if (acMessageBox.Show(acInfo.Resource.GetString("정말 종료하시겠습니까?", "XPCDAJOT"), acInfo.SystemName, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
            {
                
                e.Cancel = true;
                bDoExit = false;

                return;
            }
            else
            {
                try
                {
                    BizRun.QBizRun.ExecuteService(this, "MAINFORM_LOG_OUT", ExtensionMethods.GetCubizParam("UID:" + acInfo.LOG_UID), "RQSTDT", "");
                }
                catch { }

                bDoExit = true;
                Application.Exit();
                base.OnClosing(e);
            }

        }

        private void SaveControlUserConfigs()
        {

            if (this.InitUserConfig == false)
            {
                //acDockManager1.SaveDefaultLayout();

                acBarManager1.SaveDefaultLayout();
            }



            acDockManager.SaveUserConfig();

            acBarManager.SaveUserConfig();

            acForm.SaveUserConfig();

            acSplitContainerControl.SaveUserConfig();

        }


        public void LoadMainForm_V2(string userID)
        {            

            SpreadsheetInfo.SetLicense("EORI-HF5T-MS0D-LVMH");

            DevExpress.Skins.SkinManager.EnableFormSkins();
            DevExpress.UserSkins.BonusSkins.Register();

            DevExpress.Skins.SkinManager.Default.RegisterAssembly(typeof(DevExpress.UserSkins.BonusSkins).Assembly);
            DevExpress.Skins.SkinManager.Default.RegisterAssembly(typeof(DevExpress.UserSkins.OfficeSkins).Assembly);

            //지역화
            DevExpress.XtraPivotGrid.Localization.PivotGridLocalizer.Active = new LocalizationManager.MyPivotGridLocalizer();
            DevExpress.XtraGrid.Localization.GridLocalizer.Active = new LocalizationManager.MyGridLocalizer();
            DevExpress.XtraNavBar.NavBarLocalizer.Active = new LocalizationManager.MyNavBarLocalizer();
            DevExpress.XtraEditors.Controls.Localizer.Active = new LocalizationManager.MyEditorsLocalizer();
            DevExpress.XtraPrinting.Localization.PreviewLocalizer.Active = new LocalizationManager.MyPrintingLocalizer();
            DevExpress.XtraTreeList.Localization.TreeListLocalizer.Active = new LocalizationManager.MyTreeListLocalizer();
            DevExpress.XtraBars.Docking2010.DocumentManagerLocalizer.Active = new LocalizationManager.MyDocumentManagerLocalizer();


            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("LANG", typeof(String)); //
            paramTable.Columns.Add("EMP_CODE", typeof(String)); //

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["LANG"] = acInfo.Lang;
            paramRow["EMP_CODE"] = acInfo.UserID;

            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);


            BizRun.QBizRun = new QBizRun(ControlManager.acInfo.ServerIp, ControlManager.acInfo.DatabaseName, acInfo.PLT_CODE, acInfo.UserID, acNetWork.GetWanIPAddress(), acInfo.ApiUrl);

            DataSet resultSet = BizRun.QBizRun.ExecuteService(this, "MAINFORM_INIT_SYSTEM", paramSet,
                "RQSTDT", "MENU_LIST,RESOURCE,BIZERROR,SYS_CONF,MENU_CONF,EMP,TOOLTIP,CODES,PLANT,VERSION,EMP_CONF,BIZERROR,MYMENU");


            DataRow plantRow = resultSet.Tables["PLANT"].Rows[0];
            DataRow empRow = resultSet.Tables["EMP"].Rows[0];
            DataRow verRow = resultSet.Tables["VERSION"].Rows[0];

            //패키지 형태
            acInfo.PackageType = (acInfo.emPackageEditionType)Enum.Parse(typeof(acInfo.emPackageEditionType), (string)verRow["TYPE"]);
            acDockManager1.SaveSystemDefaultLayout();

            //acInfo.PackageType = acInfo.emPackageEditionType.Standard;

            //사업장, 로그인 유저 정보(부서명, 사원명, 사용자그룹명), System Type, 언어 표시
            acBarStaticItemPlant.Caption = plantRow["PLT_NAME"].toStringNull();
            acBarSubItemUser.Caption = string.Format("{0} | {1}", empRow["ORG_NAME"].toStringNull(), empRow["EMP_NAME"].toStringNull());
            acBarStaticItemAuth.Caption = empRow["USRGRP_NAME"].toStringNull();
            acBarStaticItemSystem.Caption = string.Format("{0} Edition", acInfo.PackageType.ToString());
            acBarStaticItemLang.Caption = acInfo.Lang;

            acBarStaticItemSysVersion.Caption = "Ver. [" + Properties.Settings.Default.VERSION.ToString() + "]";

            this._MenuList = resultSet.Tables["MENU_LIST"];

            ControlManager.acInfo.IsSystemUser = empRow["IS_SYSTEM"].toBoolean();

            ControlManager.acInfo.UserName = empRow["EMP_NAME"].toStringNull();

            ControlManager.acInfo.UserORG = empRow["ORG_CODE"].toStringNull();

            ControlManager.acInfo.UserORG_Name = empRow["ORG_NAME"].toStringNull();

            ControlManager.acInfo.UserPhone = empRow["MOBILE_PHONE"].toStringNull();

            ControlManager.acInfo.EmailAddr = empRow["EMAIL"].toStringNull();

            ControlManager.acInfo.PLT_NAME = plantRow["PLT_NAME"].toStringNull();

            ControlManager.acInfo.ToolTip = new acToolTip(resultSet.Tables["TOOLTIP"]);

            ControlManager.acInfo.StdCodes = new acStdCodes(resultSet.Tables["CODES"]);

            ControlManager.acInfo.BizError = new acBizError(resultSet.Tables["BIZERROR"]);

            ControlManager.acInfo.Resource = new acResource(resultSet.Tables["RESOURCE"]);

            ControlManager.acInfo.SysConfig = new acSysConfig(resultSet.Tables["SYS_CONF"]);

            ControlManager.acInfo.MenuConfig = new acMenuConfig(resultSet.Tables["MENU_CONF"]);

            ControlManager.acInfo.EmpConfig = new acEmpConfig(resultSet.Tables["EMP_CONF"]);

            if (!Directory.Exists(acInfo.GetTempSystemDirectory()))
            {
                Directory.CreateDirectory(acInfo.GetTempSystemDirectory());
            }

            //스킨설정
            this.SetSkin(ControlManager.acInfo.Skin);

            acBarManager1.LoadDefaultLayout();

            //개발모드 기본메뉴로 설정
            if (!string.IsNullOrEmpty(""))
            {
                foreach (DataRow row in resultSet.Tables["MENU_LIST"].Rows)
                {
                    if (row["MENU_CODE"].EqualsEx(""))
                    {
                        row["IS_DEFAULT_MENU"] = 1;

                        break;
                    }
                }

                resultSet.Tables["MENU_LIST"].AcceptChanges();
            }

            //메뉴리스트 추가
            //this.LoadMenuList(resultSet.Tables["MENU_LIST"]);


            //컨트롤 색상 설정
            acInfo.StandardBackColor = acInfo.SysConfig.GetSysConfigByMemory("STANDARD_EDIT_BACKCOLOR").toColor();
            acInfo.StandardForeColor = acInfo.SysConfig.GetSysConfigByMemory("STANDARD_EDIT_FORECOLOR").toColor();

            acInfo.ReadOnlyBackColor = acInfo.SysConfig.GetSysConfigByMemory("READONLY_EDIT_BACKCOLOR").toColor();
            acInfo.ReadOnlyForeColor = acInfo.SysConfig.GetSysConfigByMemory("READONLY_EDIT_FORECOLOR").toColor();

            acInfo.RequiredBackColor = acInfo.SysConfig.GetSysConfigByMemory("REQUIRED_EDIT_BACKCOLOR").toColor();
            acInfo.RequiredForeColor = acInfo.SysConfig.GetSysConfigByMemory("REQUIRED_EDIT_FORECOLOR").toColor();

            //시스템 기본 폰트 변경
            if (acFontDialogEdit.IsInstallFontName(acInfo.SysConfig.GetSysConfigByMemory("DEFAULT_FONT")))
            {
                DevExpress.Utils.AppearanceObject.DefaultFont = new Font(acInfo.SysConfig.GetSysConfigByMemory("DEFAULT_FONT"),
                    acInfo.SysConfig.GetSysConfigByMemory("DEFAULT_FONT_SIZE").toInt(),
                    FontStyle.Regular, GraphicsUnit.Point);
            }

            if (acInfo.MenuLocation.isNullOrEmpty() || acInfo.MenuLocation.Equals("V") || acInfo.MenuLocation.Equals("V2"))
            {
                if(acInfo.MenuLocation.Equals("V2"))
                    navMenu.PaintStyleName = "SkinNavigationPane";

                //MYMENU 추가
                this.LoadMyMenuList(resultSet.Tables["MYMENU"]);

                //메뉴리스트 추가
                this.LoadMenuList(resultSet.Tables["MENU_LIST"]);

                if (this.navMenu.Groups.Count > 0)
                    this.navMenu.Groups[0].Expanded = true;

                navMenu.Appearance.NavigationPaneHeader.Font = DevExpress.Utils.AppearanceObject.DefaultFont;
                navMenu.Appearance.GroupHeader.Font = DevExpress.Utils.AppearanceObject.DefaultFont;
                navMenu.Appearance.Item.Font = DevExpress.Utils.AppearanceObject.DefaultFont;

                acDockPanel1.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left;
                if (acDockPanel1.Visibility != DevExpress.XtraBars.Docking.DockVisibility.Visible)
                {
                    acDockPanel1.RootPanel.Show();
                }

                this.bar1.Visible = false;
                navMenu.MouseDown += NavMenu_MouseDown;
                //this.navMenu.CustomDrawLink += NavMenu_CustomDrawLink;
                
            }
            else if (acInfo.MenuLocation.Equals("H"))
            {
                if (acDockPanel1.Visibility == DevExpress.XtraBars.Docking.DockVisibility.Visible)
                {
                    acDockPanel1.RootPanel.Hide();
                    //acDockPanel1.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Hidden;
                    navMenu.Visible = false;
                }

                this.bar1.Visible = true;
                this.bar1.OptionsBar.UseWholeRow = true;

                //MYMENU 추가
                this.LoadBarMyMenuList(resultSet.Tables["MYMENU"]);

                //메뉴리스트 추가
                this.LoadBarMenuList(resultSet.Tables["MENU_LIST"]);
            }

            defaultToolTipController1.DefaultController.Appearance.Font = DevExpress.Utils.AppearanceObject.DefaultFont;
            defaultBarAndDockingController1.Controller.AppearancesBar.ItemsFont = DevExpress.Utils.AppearanceObject.DefaultFont;

            //acTabControl1.AppearancePage.Header.Font = DevExpress.Utils.AppearanceObject.DefaultFont;

            tabbedView1.AppearancePage.Header.Font = DevExpress.Utils.AppearanceObject.DefaultFont;

            acDockManager1.LoadDefaultLayout();
            //acTabControl1.ClosePageButtonShowMode = ClosePageButtonShowMode.InActiveTabPageAndTabControlHeader;


            //acTabControl1.CloseButtonClick += acTabControl1_CloseButtonClick;
            tabbedView1.DocumentClosing += tabbedView1_DocumentClosing; ;
            tabbedView1.BeginDocking += (s, e) => { ControlManager.acInfo.IsRunTime = false; };
            tabbedView1.BeginFloating += (s, e) => { ControlManager.acInfo.IsRunTime = false; };
            tabbedView1.BeginDocumentsHostDocking += (s, e) => { ControlManager.acInfo.IsRunTime = false; };
            tabbedView1.EndDocking += (s, e) => { ControlManager.acInfo.IsRunTime = true; };
            tabbedView1.EndFloating += (s, e) => { ControlManager.acInfo.IsRunTime = true; };
            tabbedView1.EndDocumentsHostDocking += (s, e) => { ControlManager.acInfo.IsRunTime = true; };

            tabbedView1.DocumentActivated += TabbedView1_DocumentActivated;
            
            //acTabControl1.SelectedPageChanging += acTabControl1_SelectedPageChanging;

            //acTabControl1.SelectedPageChanged += acTabControl1_SelectedPageChanged;

            //acTabControl1.TabPages.CollectionChanged += TabPages_CollectionChanged;

            this.acBarManager1.InitBarItem();

            this.Text = string.Format("{0} - {1}", acInfo.SystemName, acInfo.PLT_NAME);

            //시스템 실행시 로드되는 항목 
            DataRow[] autoLoadMenus = resultSet.Tables["MENU_LIST"].Select("IS_DEFAULT_MENU = 1");

            foreach (DataRow autoLoadMenu in autoLoadMenus)
            {
                this.LoadMenu(autoLoadMenu, emMenuType.DEFAULT, null);
            }

            //acTabControl1.SelectedTabPageIndex = 0;

            //acTabControl1.ClosePageButtonShowMode = ClosePageButtonShowMode.InTabControlHeader;

            alertControl1.AlertClick += alertControl1_AlertClick;
            //버전 체크
            //TimerCallback systemVersionCheckerTimer = new TimerCallback(SystemVersionCheckerCallBack);
            //this._SystemVersionChecker = new System.Threading.Timer(systemVersionCheckerTimer, null, 0, 60000);

            //알림 메시지 
            if (!Properties.Settings.Default.DEV.Equals("1"))
            {
                TimerCallback notifyCheckerTimer = new TimerCallback(NotifyCheckerCallBack);
                this._NotifyChecker = new System.Threading.Timer(notifyCheckerTimer, null, 0, acInfo.SysConfig.GetSysConfigByMemory("NOTIFY_REFRESH_TIME").toInt() * 1000);
            }

            TimerCallback systemUpdateCheckerTimer = new TimerCallback(SystemUpdateChcekerCallBack);
            this._VersionChecker = new System.Threading.Timer(systemUpdateCheckerTimer, null, 0, 60000);

            _NotifyUpdate = false;

            //AddDocument();
            //AddDocument();
            //AddDocument();
            //AddDocument();
            //AddDocument();
        }

        private void NavMenu_CustomDrawLink(object sender, DevExpress.XtraNavBar.ViewInfo.CustomDrawNavBarElementEventArgs e)
        {
            try
            {
                NavBarControl nav = sender as NavBarControl;

                //NavBarItemLink link = e.ObjectInfo as NavBarItemLink;
               
                 
                Rectangle rect = e.RealBounds;
                rect.Width = 20;
                rect.Offset(e.RealBounds.Width - 20, 3);
                rect.Inflate(0, 2);
                Image img = Resource.feature_16x16;
                
                e.Graphics.DrawImage(img, rect.Location);
            }
            catch { }

        }

        private void TabbedView1_DocumentActivated(object sender, DevExpress.XtraBars.Docking2010.Views.DocumentEventArgs e)
        {
            try
            {
                Document document = (Document)e.Document;

                if (document != null)
                {
                    DataRow menuRow = document.Tag as DataRow;

                    SetMymenuStatus(menuRow);

                    //BaseMenu currentMenuControl = (BaseMenu)FindBaseTypeControl(document.Control);
                    BaseMenu currentMenuControl = (BaseMenu)document.Control;

                    if (currentMenuControl != null)
                    {

                        currentMenuControl.MenuGotFocus();
                    }
                }

            }
            catch (Exception ex) 
            {
                acMessageBox.Show(this, ex);
            }

        }

        private void tabbedView1_DocumentClosing(object sender, DevExpress.XtraBars.Docking2010.Views.DocumentCancelEventArgs e)
        {
            Document document = (Document)e.Document;

            if (document != null)
            {
                if (!this.CloseDocument(document))
                    e.Cancel = true;
            }
            else
            {
                //전체 탭닫기


                if (acMessageBox.Show(this, "열린 모든메뉴를 닫습니까?", "D1LEEIXW", true, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
                {
                    return;
                }



                List<Document> DocumentList = new List<Document>();


                //열린 모든페이지 목록
                foreach (Document doc in tabbedView1.Documents)
                {
                    if (!_DefaultDocumentDic.ContainsValue(doc))
                    {

                        DocumentList.Add(doc);

                    }

                }


                //int idx = this.acTabControl1.SelectedTabPageIndex - 1;

                foreach (Document doc in DocumentList)
                {

                    //foreach (Control ctrl in doc.Control.Controls)
                    {
                        if (doc.Control is BaseMenu)
                        {
                            BaseMenu menuControl = doc.Control as BaseMenu;

                            if (menuControl.MenuDestory(menuControl) == true)
                            {

                                DataRow menuRow = (DataRow)doc.Tag;

                                _OpenDocumentDic.Remove(menuRow["CLASSNAME"].ToString());

                                tabbedView1.Documents.Remove(doc);
                                //acTabControl1.TabPages.Remove(tabPage);

                                menuControl.Dispose();

                            }

                            //acTabControl1.SelectedTabPageIndex = idx;

                            //break;
                        }

                    }

                }

                SaveControlUserConfigs();
            }
        }

        //=================사용 안함 주석 처리

        //private void tabbedView1_DocumentClosed(object sender, DevExpress.XtraBars.Docking2010.Views.DocumentEventArgs e)
        //{
        //    //탭 삭제
        //    //DevExpress.XtraTab.ViewInfo.ClosePageButtonEventArgs args = (DevExpress.XtraTab.ViewInfo.ClosePageButtonEventArgs)e.;

        //    Document document = (Document)e.Document;

        //    if (document != null)
        //    {
        //        this.CloseDocument(document);


        //    }
        //    else
        //    {
        //        //전체 탭닫기


        //        if (acMessageBox.Show(this, "열린 모든메뉴를 닫습니까?", "D1LEEIXW", true, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
        //        {
        //            return;
        //        }



        //        List<Document> DocumentList = new List<Document>();


        //        //열린 모든페이지 목록
        //        foreach (Document doc in tabbedView1.Documents)
        //        {
        //            if (!_DefaultDocumentDic.ContainsValue(doc))
        //            {

        //                DocumentList.Add(doc);

        //            }

        //        }


        //        //int idx = this.acTabControl1.SelectedTabPageIndex - 1;

        //        foreach (Document doc in DocumentList)
        //        {

        //            //foreach (Control ctrl in doc.Control.Controls)
        //            {
        //                if (doc.Control is BaseMenu)
        //                {
        //                    BaseMenu menuControl = doc.Control as BaseMenu;

        //                    if (menuControl.MenuDestory(menuControl) == true)
        //                    {

        //                        DataRow menuRow = (DataRow)doc.Tag;

        //                        _OpenDocumentDic.Remove(menuRow["CLASSNAME"].ToString());

        //                        tabbedView1.Documents.Remove(doc);
        //                        //acTabControl1.TabPages.Remove(tabPage);

        //                        menuControl.Dispose();

        //                    }

        //                    //acTabControl1.SelectedTabPageIndex = idx;

        //                    break;
        //                }

        //            }

        //        }

        //        SaveControlUserConfigs();
        //    }
        //}

        //=================사용 안함 주석 처리
        private void NavMenu_MouseDown(object sender, MouseEventArgs e)
        {
            NavBarHitInfo hi = navMenu.CalcHitInfo(e.Location);
            if (hi != null && hi.InGroupCaption)
            {
                if (!hi.InGroupButton)
                    hi.Group.Expanded = !hi.Group.Expanded;
            }

        }

        void alertControl1_AlertClick(object sender, DevExpress.XtraBars.Alerter.AlertClickEventArgs e)
        {
            this.MoveMenu(emMenuType.NOTIFY, "SYS13A", null);
        }



        //void TabPages_CollectionChanged(object sender, CollectionChangeEventArgs e)
        //{
        //    if (_DefaultTabPageDic.ContainsValue(acTabControl1.SelectedTabPage))
        //    {
        //        acTabControl1.ClosePageButtonShowMode = ClosePageButtonShowMode.InTabControlHeader;
        //    }
        //    else
        //    {
        //        acTabControl1.ClosePageButtonShowMode = ClosePageButtonShowMode.InActiveTabPageAndTabControlHeader;
        //    }
        //}
        private void LoadMenuList(DataTable menuList)
        {

            if (this.navMenu.Groups.Count > 1) return;

            DataRow[] groupMenuRows = menuList.Select("MENU_PARENT IS NULL");

            foreach (DataRow groupMenuRow in groupMenuRows)
            {
                string groupMenuCode = groupMenuRow["MENU_CODE"].toStringNull();

                string groupMenuName = acInfo.Resource.GetString(groupMenuCode, (string)groupMenuRow["RES_ID"]);


                NavBarGroup grp = new NavBarGroup(groupMenuName);

                //grp.NavigationPaneVisible = false;

                //grp.SmallImage = groupMenuRow["ICON"].toImage();
                grp.LargeImage = groupMenuRow["ICON"].toImage();

                this.navMenu.Groups.Add(grp);

                this.AddMenu(grp, menuList, groupMenuCode);
            }
        }

        private void LoadMyMenuList(DataTable menuList)
        {
            foreach(DataRow dr in menuList.Rows)
            {
                this.AddMyMenu(dr);

                if (!this._MyMenu.ContainsKey(dr["MENU_CODE"].ToString()))
                    this._MyMenu.Add(dr["MENU_CODE"].ToString(), dr);
            }

            if (navMenu.Groups.Count == 0)
            {
                NavBarGroup grpMymenu = new NavBarGroup("즐겨찾기");
                grpMymenu.LargeImage = Resource.feature_16x16;
                this.navMenu.Groups.Add(grpMymenu);
            }
            
        }

        private void LoadBarMyMenuList(DataTable menuList)
        {
            foreach (DataRow dr in menuList.Rows)
            {
                this.AddBarMyMenu(dr);

                if (!this._MyMenu.ContainsKey(dr["MENU_CODE"].ToString()))
                    this._MyMenu.Add(dr["MENU_CODE"].ToString(), dr);
            }

            if (this.bar1.ItemLinks.Count == 0)
            {
                acBarSubItem subItem = new acBarSubItem();
                subItem.Caption = "즐겨찾기";
                subItem.PaintStyle = BarItemPaintStyle.CaptionGlyph;
                subItem.Glyph = Resource.feature_16x16;
                subItem.Name = "myMenu";
                this.bar1.AddItem(subItem);
            }

        }
        private void LoadBarMenuList(DataTable menuList)
        {

            //if (this.bar1.ItemLinks.Count > 1) return;

            bool iVisible = acInfo.SysConfig.GetSysConfigByMemory("IS_ICON_VISIBLE").toStringEmpty().Equals("1") ? true : false;

            DataRow[] groupMenuRows = menuList.Select("MENU_PARENT IS NULL");

            foreach (DataRow groupMenuRow in groupMenuRows)
            {
                string groupMenuCode = groupMenuRow["MENU_CODE"].toStringNull();

                string groupMenuName = acInfo.Resource.GetString(groupMenuCode, (string)groupMenuRow["RES_ID"]);

                acBarSubItem subItem = new acBarSubItem();
                subItem.Caption = groupMenuName;
                if (iVisible)
                {
                    subItem.PaintStyle = BarItemPaintStyle.CaptionGlyph;
                    subItem.Glyph = groupMenuRow["ICON"].toImage();
                }
                subItem.Name = groupMenuCode;
                this.bar1.AddItem(subItem);

                this.AddBarMenu(subItem, menuList, groupMenuCode);

            }
        }

        private void AddBarMenu(acBarSubItem subItem, DataTable menuList, string menuParent)
        {
            try
            {
                DataRow[] menuRows = menuList.Select("MENU_PARENT = '" + menuParent + "' AND ISNULL(IS_DEFAULT_MENU, 0) = 0");

                foreach (DataRow menuRow in menuRows)
                {
                    string className = menuRow["CLASSNAME"].toStringNull();
                    string menuCode = menuRow["MENU_CODE"].toStringNull();
                    string menuName = acInfo.Resource.GetString(menuCode, (string)menuRow["RES_ID"]);

                    if (!string.IsNullOrEmpty(className))
                    {
                        acBarButtonItem item = new acBarButtonItem();
                        item.Caption = menuName.toStringNull();
                        item.Glyph = menuRow["ICON"].toImage();
                        item.Tag = menuRow;
                        item.Hint = menuRow["SCOMMENT"].toStringNull();
                        item.ItemClick += Item_ItemClick;

                        subItem.ItemLinks.Add(item);
                    }
                    else
                    {
                        //서브메뉴 지원안함
                    }
                }

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        private void AddBarMyMenu(DataRow menuRow)
        {
            try
            {
                acBarSubItem subItem = new acBarSubItem();

                if (this.bar1.ItemLinks.Count > 0)
                {
                    subItem = this.bar1.ItemLinks[0].Item as acBarSubItem;
                    subItem.Glyph = Resource.feature_16x16;
                    subItem.Caption = "즐겨찾기";
                    subItem.PaintStyle = BarItemPaintStyle.CaptionGlyph;
                }
                else
                {
                    subItem.Caption = "즐겨찾기";
                    subItem.PaintStyle = BarItemPaintStyle.CaptionGlyph;
                    subItem.Glyph = Resource.feature_16x16;
                    subItem.Name = "myMenu";
                    this.bar1.AddItem(subItem);
                }
                
                string className = menuRow["CLASSNAME"].toStringNull();
                string menuCode = menuRow["MENU_CODE"].toStringNull();
                string menuName = acInfo.Resource.GetString(menuCode, (string)menuRow["RES_ID"]);

                if (!string.IsNullOrEmpty(className))
                {
                    acBarButtonItem item = new acBarButtonItem();
                    item.Caption = menuName.toStringNull();
                    item.Glyph = menuRow["ICON"].toImage();
                    item.Tag = menuRow;
                    item.Hint = menuRow["SCOMMENT"].toStringNull();
                    item.ItemClick += Item_ItemClick;

                    subItem.ItemLinks.Add(item);
                }
                else
                {
                    //서브메뉴 지원안함
                }
                

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }
        private void Item_ItemClick(object sender, ItemClickEventArgs e)
        {
            acBarButtonItem item = e.Item as acBarButtonItem;


            DataRow menuRow = (DataRow)item.Tag;

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("EMP_CODE", typeof(String)); //
            paramTable.Columns.Add("MENU_CODE", typeof(String)); //

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["EMP_CODE"] = acInfo.UserID;
            paramRow["MENU_CODE"] = menuRow["MENU_CODE"];

            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.CHECK,
                        "MAINFORM_CHECK_ACCESSMENU", paramSet, "RQSTDT", "", menuRow,
                        QuickMenuOpen,
                        QuickMenuOpenException);
        }

        private enum emMenuType
        {
            /// <summary>
            /// 기본메뉴 시스템 실행시 바로 불러옴 닫을수없음

            /// </summary>
            DEFAULT,

            /// <summary>
            /// 일반메뉴 로드
            /// </summary>
            STANDARD,

            /// <summary>
            /// 링크 이동
            /// </summary>
            LINK,

            /// <summary>
            /// 알림 이동
            /// </summary>
            NOTIFY
        }


        private void LoadMenu(DataRow menuRow, emMenuType menuType, object data)
        {
            try
            {
                string loadAssemName = menuRow["ASSEMBLY"].toStringNull();

                string className = menuRow["CLASSNAME"].toStringNull();

                acInfo.MenuClassName = menuRow["CLASSNAME"].toStringNull();

                acInfo.IsPopMenu = menuRow["IS_POP_MENU"].toStringNull();

                string loadMenuName = acInfo.Resource.GetString(loadAssemName, menuRow["RES_ID"].toStringNull());

                if (!_LoadAssemblysDic.ContainsKey(loadAssemName))
                {
                    if (loadAssemName != "LogInForm")
                    {
                        Assembly assemDLL = Assembly.Load(loadAssemName);

                        _LoadAssemblysDic.Add(loadAssemName, assemDLL);
                    }
                    else
                    {
                        _LoadAssemblysDic.Add(loadAssemName, Assembly.GetExecutingAssembly());
                    }
                }

                if (!_OpenDocumentDic.ContainsKey(className))
                {
                    //열어진 탭페이지 없음

                    Type assemType = _LoadAssemblysDic[loadAssemName].GetType(loadAssemName + "." + className, true, true);

                    ConstructorInfo loadCtorInfo = assemType.GetConstructor(Type.EmptyTypes);

                    object loadControl = loadCtorInfo.Invoke(null);
                    
                    if (loadControl is BaseMenu)
                    {
                        BaseMenu menu = (BaseMenu)loadControl;

                        if (menu.GetType() == typeof(WebView))
                        {
                            //(menu as WebView).URL = "https://211.238.138.160:7862/CUST_MONI/";
                            (menu as WebView).URL = menuRow["SCOMMENT"].ToString();
                        }

                        menu.MenuCode = menuRow["MENU_CODE"].ToString();

                        //시스템 환경설정 업데이트
                        acInfo.SysConfig.UpdateMemorySysConfig();

                        //메뉴 환경설정 업데이트
                        acInfo.MenuConfig.UpdateMemoryMenuConfig(menu.MenuCode);

                        //표준코드 업데이트
                        acInfo.StdCodes.UpdateMemoryStdCodes();

                        //오류 업데이트
                        acInfo.BizError.UpdateMemoryBizError();

                        menu.MenuInit();

                        menu.Menu.MainControl = this;

                        menu.Dock = DockStyle.Fill;

                        DocumentSettings settings = new DocumentSettings();
                        try
                        {                            

                            if (acInfo.IsSystemUser)
                                settings.Caption = loadMenuName + "[" + className + "]";
                            else
                                settings.Caption = loadMenuName;

                            //XtraUserControl child = new XtraUserControl();
                            settings.Image = menuRow["ICON"].toImage();
                            DocumentSettings.Attach(menu, settings);
                            //child.Padding = new Padding(0);
                            //menu.Parent = child;
                            //menu.Dock = DockStyle.Fill;
                            tabbedView1.AddDocument(menu);
                            Document document = ((Document)tabbedView1.Documents[tabbedView1.Documents.Count - 1]);
                            ((Document)tabbedView1.Documents[tabbedView1.Documents.Count - 1]).Tag = menuRow;

                            _OpenDocumentDic.Add(className, document);

                            //기본메뉴면 추가
                            if (menuType == emMenuType.DEFAULT)
                            {
                                _DefaultDocumentDic.Add(className, document);
                            }
                            ((Document)tabbedView1.Documents[tabbedView1.Documents.Count - 1]).Appearance.Header.BackColor = menuRow["HEADER_COLOR"].toColor();

                            menu.MenuLoadManager();

                            menu.MenuLoadBarManager();

                            menu.MenuLoadDockManager();

                            menu.MenuInitComplete();

                            menu.Focus();

                            if (menuType == emMenuType.LINK)
                            {
                                menu.MenuLink(data);
                            }
                            else if (menuType == emMenuType.NOTIFY)
                            {
                                menu.MenuNotify(data);
                            }

                            menu.Visible = true;

                            tabbedView1.Controller.Activate(((Document)tabbedView1.Documents[tabbedView1.Documents.Count - 1]));

                            //EnableColoredTabs();                            

                            
                        }
                        catch (Exception ex)
                        {
                            //this.CloseTabPage(menuTabPage);

                            acMessageBox.Show(this, ex);
                        }

                        if (!acInfo.IsSystemUser)
                        {
                            DataTable paramTable = new DataTable("RQSTDT");
                            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                            paramTable.Columns.Add("EMP_CODE", typeof(String)); //
                            paramTable.Columns.Add("CLASS_NAME", typeof(String)); //


                            DataRow paramRow = paramTable.NewRow();
                            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                            paramRow["EMP_CODE"] = acInfo.UserID;
                            paramRow["CLASS_NAME"] = className;

                            paramTable.Rows.Add(paramRow);


                            DataSet paramSet = new DataSet();
                            paramSet.Tables.Add(paramTable);

                            DataSet resultSet = BizRun.QBizRun.ExecuteService(this, "SYS05A_INS", paramSet, "RQSTDT", "RSLTDT");
                        }


                    }
                    else if (loadControl is BaseMenuDialog)
                    {
                        BaseMenuDialog menu = (BaseMenuDialog)loadControl;

                        menu.ParentControl = this;

                        menu.Text = menuRow["MENU_NAME"].ToString();

                        menu.ShowDialog();

                    }

                }
                else
                {
                    //열어진 탭페이지 존재

                    //_OpenDocumentDic[className].PageEnabled = true;

                    //this.acTabControl1.SelectedTabPage = _OpenDocumentDic[className];

                    tabbedView1.ActivateDocument(_OpenDocumentDic[className].Control);

                    if (menuType == emMenuType.LINK)
                    {
                        //foreach (Control ctrl in _OpenDocumentDic[className].Control.Controls)
                        {

                            if (_OpenDocumentDic[className].Control is BaseMenu)
                            {
                                BaseMenu menu = _OpenDocumentDic[className].Control as BaseMenu;

                                menu.MenuLink(data);

                                //break;
                            }

                        }

                    }
                    else if (menuType == emMenuType.NOTIFY)
                    {
                        //foreach (Control ctrl in _OpenDocumentDic[className].Control.Controls)
                        {

                            if (_OpenDocumentDic[className].Control is BaseMenu)
                            {
                                BaseMenu menu = _OpenDocumentDic[className].Control as BaseMenu;

                                menu.MenuNotify(data);

                                //break;
                            }

                        }

                    }

                }


                SetMymenuStatus(menuRow);


            }
            catch (Exception ex)
            {
                if (ex is TypeLoadException)
                {
                    acMessageBox.Show(acInfo.Resource.GetString("해당 메뉴가 존재하지않거나, 오류가 발생하여 불러올수없습니다.", "UGQ8D5F8"), acInfo.SystemName, acMessageBox.emMessageBoxType.CONFIRM);
                }
                else
                {
                    acMessageBox.Show(this, ex);
                }

            }

        }

        void SetMymenuStatus(DataRow menuRow)
        {
            if (menuRow == null) return;
            //즐겨찾기 메뉴인지 여부 
            if (this._MyMenu.ContainsKey(menuRow["MENU_CODE"].ToString()))
            {
                chkMymenu.Enabled = true;
                //chkMymenu.Checked = true;
                chkMymenu.Caption = "즐겨찾기 제거";
                chkMymenu.Tag = "DEL";
            }
            else
            {
                chkMymenu.Enabled = true;
                //chkMymenu.Checked = false;
                chkMymenu.Caption = "즐겨찾기 추가";
                chkMymenu.Tag = "ADD";
            }
        }

        void NotifyCheckerCallBack(object stateInfo)
        {
            while (this._IsNotifyLoop == true)
            {
                return;
            }

            this._IsNotifyLoop = true;

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("EMP_CODE", typeof(String)); //

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["EMP_CODE"] = acInfo.UserID;
            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            //BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.NONE,"CTRL", "GET_NOTIFY", paramSet, "RQSTDT", "RSLTDT",QuickNotify,
            //            QuickException);

            try
            {

                DataSet resultSet = BizRun.QBizRun.ExecuteService(this, "CTRL", "GET_NOTIFY", paramSet, "RQSTDT", "RSLTDT,RSLTDT_BOARD");

                foreach (DataRow row in resultSet.Tables["RSLTDT"].Rows)
                {

                    if (!this._NotifyList.ContainsKey(row["UID"].toInt()))
                    {
                        while (true)
                        {
                            bool isNotifyWindow = false;

                            foreach (KeyValuePair<int, acMessageBoxNotify> ny in this._NotifyList)
                            {
                                if (ny.Value.IsShow == true)
                                {
                                    isNotifyWindow = true;

                                    break;
                                }
                            }

                            if (isNotifyWindow == false)
                            {
                                break;
                            }

                            Thread.Sleep(100);
                        }

                        this.Invoke((MethodInvoker)delegate
                        {
                            acRichEdit re = new acRichEdit();
                            re.HtmlText = row["MESSAGE"].toStringEmpty().GetStringByMaskScript();

                            acMessageBoxNotify notifyMessage = new acMessageBoxNotify(row["TITLE"].toStringEmpty().GetStringByMaskScript(), re.Text);
                            //창크기조절
                            //notifyMessage.SetDimensions(500, 500);
                            notifyMessage.Data = row;

                            notifyMessage.TextClicked += new EventHandler(NotifyMessage_TextClicked);
                            notifyMessage.NotifyClose += new EventHandler(NotifyMessage_NotifyClose);

                            notifyMessage.Notify();

                            this._NotifyList.Add(row["UID"].toInt(), notifyMessage);

                        });
                    }
                }
                foreach (DataRow row in resultSet.Tables["RSLTDT_BOARD"].Rows)
                {



                    //if(true)                        
                    //    frm.BeginInvoke(new Action(() => frm.Show(this)));
                    //else
                    //    frm.Show(this);
                    this.Invoke((MethodInvoker)delegate
                    {
                        SYS.SYS12A_D0A frm = new SYS.SYS12A_D0A(null, row, true);

                        frm.DialogMode = BaseMenuDialog.emDialogMode.OPEN;

                        frm.ParentControl = this;

                        frm.Show(this);
                    });

                    DataTable paramTableRead = new DataTable("RQSTDT");
                    paramTableRead.Columns.Add("PLT_CODE", typeof(String)); //
                    paramTableRead.Columns.Add("EMP_CODE", typeof(String)); //
                    paramTableRead.Columns.Add("BOARD_ID", typeof(String)); //
                    paramTableRead.Columns.Add("READER", typeof(String)); //

                    DataRow paramRowRead = paramTableRead.NewRow();
                    paramRowRead["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRowRead["EMP_CODE"] = acInfo.UserID;
                    paramRowRead["BOARD_ID"] = row["BOARD_ID"];
                    paramRowRead["READER"] = acInfo.UserName + "(" + acInfo.UserID + ")";
                    paramTableRead.Rows.Add(paramRowRead);
                    DataSet paramSetRead = new DataSet();
                    paramSetRead.Tables.Add(paramTableRead);

                    BizRun.QBizRun.ExecuteService(this, "CTRL", "SET_BOARD_READ", paramSetRead, "RQSTDT", "");
                    //this._IsNotifyLoop = true;
                }

                foreach (DataRow row in resultSet.Tables["RSLTDT_BOARD_REPLY"].Rows)
                {



                    //if(true)                        
                    //    frm.BeginInvoke(new Action(() => frm.Show(this)));
                    //else
                    //    frm.Show(this);
                    this.Invoke((MethodInvoker)delegate
                    {
                        SYS.SYS12A_D1A frm = new SYS.SYS12A_D1A(null, row, true);

                        frm.DialogMode = BaseMenuDialog.emDialogMode.OPEN;

                        frm.ParentControl = this;

                        frm.Show(this);
                    });

                    DataTable paramTableRead = new DataTable("RQSTDT");
                    paramTableRead.Columns.Add("PLT_CODE", typeof(String)); //
                    paramTableRead.Columns.Add("EMP_CODE", typeof(String)); //
                    paramTableRead.Columns.Add("BOARD_ID", typeof(String)); //
                    paramTableRead.Columns.Add("READER", typeof(String)); //

                    DataRow paramRowRead = paramTableRead.NewRow();
                    paramRowRead["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRowRead["EMP_CODE"] = acInfo.UserID;
                    paramRowRead["BOARD_ID"] = row["BOARD_ID"];
                    paramRowRead["READER"] = acInfo.UserName + "(" + acInfo.UserID + ")";
                    paramTableRead.Rows.Add(paramRowRead);
                    DataSet paramSetRead = new DataSet();
                    paramSetRead.Tables.Add(paramTableRead);

                    BizRun.QBizRun.ExecuteService(this, "CTRL", "SET_BOARD_READ", paramSetRead, "RQSTDT", "");
                    //this._IsNotifyLoop = true;
                }

                foreach (DataRow row in resultSet.Tables["RSLTDT_WORK"].Rows)
                {
                    //if(true)                        
                    //    frm.BeginInvoke(new Action(() => frm.Show(this)));
                    //else
                    //    frm.Show(this);
                    this.Invoke((MethodInvoker)delegate
                    {
                        WOR.WOR01A_D0A frm = new WOR.WOR01A_D0A(null, row, row["EMP_CODE"].ToString(), true);

                        frm.DialogMode = BaseMenuDialog.emDialogMode.OPEN;

                        frm.ParentControl = this;

                        frm.Text = "근태신청";

                        frm.Show(this);
                    });

                    DataTable paramTableRead = new DataTable("RQSTDT");
                    paramTableRead.Columns.Add("PLT_CODE", typeof(String)); //
                    paramTableRead.Columns.Add("EMP_CODE", typeof(String)); //
                    paramTableRead.Columns.Add("WORK_ID", typeof(String)); //

                    DataRow paramRowRead = paramTableRead.NewRow();
                    paramRowRead["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRowRead["EMP_CODE"] = acInfo.UserID;
                    paramRowRead["WORK_ID"] = row["WORK_ID"];
                    paramTableRead.Rows.Add(paramRowRead);
                    DataSet paramSetRead = new DataSet();
                    paramSetRead.Tables.Add(paramTableRead);

                    BizRun.QBizRun.ExecuteService(this, "CTRL", "SET_WORK_READ", paramSetRead, "RQSTDT", "");
                }

                if (resultSet.Tables["RSLTDT_OUT_REQ"].Rows.Count > 0)
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        ORD.ORD10A_D3A frm = new ORD.ORD10A_D3A(resultSet.Tables["RSLTDT_OUT_REQ"]);

                        frm.DialogMode = BaseMenuDialog.emDialogMode.OPEN;

                        frm.ParentControl = this;

                        frm.Text = "불출요청";

                        frm.Show(this);
                    });

                    DataTable paramTableRead = new DataTable("RQSTDT");
                    paramTableRead.Columns.Add("PLT_CODE", typeof(String)); //
                    paramTableRead.Columns.Add("EMP_CODE", typeof(String)); //
                    paramTableRead.Columns.Add("OUT_REQ_ID", typeof(String)); //

                    foreach (DataRow row in resultSet.Tables["RSLTDT_OUT_REQ"].Rows)
                    {
                        DataRow paramRowRead = paramTableRead.NewRow();
                        paramRowRead["PLT_CODE"] = acInfo.PLT_CODE;
                        paramRowRead["EMP_CODE"] = acInfo.UserID;
                        paramRowRead["OUT_REQ_ID"] = row["OUT_REQ_ID"];
                        paramTableRead.Rows.Add(paramRowRead);
                    }

                    DataSet paramSetRead = new DataSet();
                    paramSetRead.Tables.Add(paramTableRead);

                    BizRun.QBizRun.ExecuteService(this, "CTRL", "SET_OUT_REQ_READ", paramSetRead, "RQSTDT", "");
                }


                if (resultSet.Tables["RSLTDT_NG"].Rows.Count > 0)
                {
                    foreach (DataRow row in resultSet.Tables["RSLTDT_NG"].Rows)
                    {
                        this.Invoke((MethodInvoker)delegate
                        {
                            QCT.QCT01A_D0A frm = new QCT.QCT01A_D0A(null, null, row, true);

                            frm.DialogMode = BaseMenuDialog.emDialogMode.OPEN;

                            frm.ParentControl = this;

                            frm.Text = "불량";

                            frm.Show(this);
                        });

                        DataTable paramTableRead = new DataTable("RQSTDT");
                        paramTableRead.Columns.Add("PLT_CODE", typeof(String)); //
                        paramTableRead.Columns.Add("EMP_CODE", typeof(String)); //
                        paramTableRead.Columns.Add("NG_ID", typeof(String)); //

                        DataRow paramRowRead = paramTableRead.NewRow();
                        paramRowRead["PLT_CODE"] = acInfo.PLT_CODE;
                        paramRowRead["EMP_CODE"] = acInfo.UserID;
                        paramRowRead["NG_ID"] = row["NG_ID"];
                        paramTableRead.Rows.Add(paramRowRead);

                        DataSet paramSetRead = new DataSet();
                        paramSetRead.Tables.Add(paramTableRead);

                        BizRun.QBizRun.ExecuteService(this, "CTRL", "SET_NG_READ", paramSetRead, "RQSTDT", "");
                    }
                }

                if (resultSet.Tables["RSLTDT_PROD"].Rows.Count > 0)
                {
                    foreach (DataRow row in resultSet.Tables["RSLTDT_PROD"].Rows)
                    {
                        this.Invoke((MethodInvoker)delegate
                        {
                            PLN21A_D9A frm = new PLN21A_D9A(row);

                            frm.DialogMode = BaseMenuDialog.emDialogMode.OPEN;

                            frm.ParentControl = this;

                            frm.Text = "BOM I/F";

                            frm.Show(this);
                        });

                        DataTable paramTableRead = new DataTable("RQSTDT");
                        paramTableRead.Columns.Add("PLT_CODE", typeof(String)); //
                        paramTableRead.Columns.Add("EMP_CODE", typeof(String)); //
                        paramTableRead.Columns.Add("PROD_IF_NO", typeof(String)); //

                        DataRow paramRowRead = paramTableRead.NewRow();
                        paramRowRead["PLT_CODE"] = acInfo.PLT_CODE;
                        paramRowRead["EMP_CODE"] = acInfo.UserID;
                        paramRowRead["PROD_IF_NO"] = row["PROD_IF_NO"];
                        paramTableRead.Rows.Add(paramRowRead);

                        DataSet paramSetRead = new DataSet();
                        paramSetRead.Tables.Add(paramTableRead);

                        BizRun.QBizRun.ExecuteService(this, "CTRL", "SET_PROD_READ", paramSetRead, "RQSTDT", "");
                    }
                }

                if (resultSet.Tables["RSLTDT_DEV"].Rows.Count > 0)
                {
                    foreach (DataRow row in resultSet.Tables["RSLTDT_DEV"].Rows)
                    {
                        this.Invoke((MethodInvoker)delegate
                        {
                            PLN21A_D10A frm = new PLN21A_D10A(row);

                            frm.DialogMode = BaseMenuDialog.emDialogMode.OPEN;

                            frm.ParentControl = this;

                            frm.Text = "수주 확정";

                            frm.Show(this);
                        });

                        DataTable paramTableRead = new DataTable("RQSTDT");
                        paramTableRead.Columns.Add("PLT_CODE", typeof(String)); //
                        paramTableRead.Columns.Add("EMP_CODE", typeof(String)); //
                        paramTableRead.Columns.Add("SEND_NO", typeof(String)); //

                        DataRow paramRowRead = paramTableRead.NewRow();
                        paramRowRead["PLT_CODE"] = acInfo.PLT_CODE;
                        paramRowRead["EMP_CODE"] = acInfo.UserID;
                        paramRowRead["SEND_NO"] = row["SEND_NO"];
                        paramTableRead.Rows.Add(paramRowRead);

                        DataSet paramSetRead = new DataSet();
                        paramSetRead.Tables.Add(paramTableRead);

                        BizRun.QBizRun.ExecuteService(this, "CTRL", "SET_DEV_READ", paramSetRead, "RQSTDT", "");
                    }
                }

            }
            catch (Exception ex)
            { }
            this._IsNotifyLoop = false;
        }


        void NotifyMessage_NotifyClose(object sender, EventArgs e)
        {

            acMessageBoxNotify notifyMessage = sender as acMessageBoxNotify;


            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("UID", typeof(Int32)); //

            DataRow paramRow = paramTable.NewRow();
            paramRow["UID"] = notifyMessage.Data["UID"];
            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            DataSet resultSet = BizRun.QBizRun.ExecuteService(this, "CTRL", "DELETE_NOTIFY", paramSet, "RQSTDT", "");

            //DataSet resultSet = BizRun.QBizRun.ExecuteService(this, "DELETE_NOTIFY", paramSet, "RQSTDT", "");

            this._NotifyList.Remove(notifyMessage.Data["UID"].toInt());

        }


        void NotifyMessage_TextClicked(object sender, EventArgs e)
        {
            acMessageBoxNotify notifyMessage = sender as acMessageBoxNotify;

            //if (notifyMessage.Data["MENU_CODE"].isNull() == false)
            if (notifyMessage.Data["MENU_CODE"] != null)
            {
                if (CodeHelperManager.acMenuList.IsUse(notifyMessage.Data["MENU_CODE"]) == true)
                {
                    this.MoveMenu(emMenuType.NOTIFY, notifyMessage.Data["MENU_CODE"].ToString(), notifyMessage.Data);
                }

            }
        }

        //메뉴 이동
        private void MoveMenu(emMenuType moveType, string menuCode, object data)
        {


            DataRow[] menuRow = _MenuList.Select("MENU_CODE = '" + menuCode + "'");

            if (menuRow.Length != 0)
            {
                LoadMenu(menuRow[0], moveType, data);
            }

        }

        public void MoveMenu2(string menuCode, object data)
        {
            DataRow[] menuRow = _MenuList.Select("MENU_CODE = '" + menuCode + "'");

            if (menuRow.Length != 0)
            {
                LoadMenu(menuRow[0], emMenuType.LINK, data);
            }

        }

        private void AddMenu(NavBarGroup group, DataTable menuList, string menuParent)
        {

            try
            {

                DataRow[] menuRows = menuList.Select("MENU_PARENT = '" + menuParent + "' AND ISNULL(IS_DEFAULT_MENU, 0) = 0");


                foreach (DataRow menuRow in menuRows)
                {

                    string className = menuRow["CLASSNAME"].toStringNull();


                    string menuCode = menuRow["MENU_CODE"].toStringNull();


                    string menuName = acInfo.Resource.GetString(menuCode, (string)menuRow["RES_ID"]);


                    if (!string.IsNullOrEmpty(className))
                    {

                        NavBarItem item = new NavBarItem(menuName.toStringNull());

                        item.SmallImage = menuRow["ICON"].toImage();

                        item.Tag = menuRow;

                        item.CanDrag = false;


                        item.Hint = menuRow["SCOMMENT"].toStringNull();

                        item.LinkClicked += new NavBarLinkEventHandler(item_LinkClicked);

                        group.ItemLinks.Add(item);


                    }
                    else
                    {
                        //서브메뉴 지원안함


                    }



                }

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        private void AddMyMenu(DataRow menuRow)
        {
            try
            {

                NavBarGroup grpMymenu = new NavBarGroup("즐겨찾기");

                if (navMenu.Groups.Count > 0)
                {
                    grpMymenu = navMenu.Groups[0];
                    grpMymenu.Expanded = true;
                }
                else
                {
                    grpMymenu.LargeImage = Resource.feature_16x16;
                    this.navMenu.Groups.Add(grpMymenu);
                }
                
                string className = menuRow["CLASSNAME"].toStringNull();


                string menuCode = menuRow["MENU_CODE"].toStringNull();


                string menuName = acInfo.Resource.GetString(menuCode, (string)menuRow["RES_ID"]);


                if (!string.IsNullOrEmpty(className))
                {

                    NavBarItem item = new NavBarItem(menuName.toStringNull());

                    item.SmallImage = menuRow["ICON"].toImage();

                    item.Tag = menuRow;

                    item.CanDrag = false;

                    

                    item.Hint = menuRow["SCOMMENT"].toStringNull();


                    item.LinkClicked += new NavBarLinkEventHandler(item_LinkClicked);

                    grpMymenu.ItemLinks.Add(item);


                }
                
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }
        bool CloseDocument(Document menuDocument)
        {
            DataRow menuRow = (DataRow)menuDocument.Tag;

            //menuDocument
            //foreach (Control ctrl in menuDocument.Control.Controls)
            //{
                if (menuDocument.Control is BaseMenu)
                {
                    BaseMenu menuControl = menuDocument.Control as BaseMenu;


                    //탭닫기

                    if (menuControl.MenuDestory(menuControl) == true)
                    {

                        menuControl.IsMenuDestroy = true;

                        //int idx = this.tabbedView1.sele.SelectedTabPageIndex - 1;

                        this.tabbedView1.Documents.Remove(menuDocument);

                        _OpenDocumentDic.Remove(menuRow["CLASSNAME"].ToString());

                        //acTabControl1.SelectedTabPageIndex = idx;

                        if (_OpenDocumentDic.Count > 0)
                        {
                            BaseMenu currentMenuControl = (BaseMenu)FindBaseTypeControl(menuDocument.Control);


                            if (currentMenuControl != null)
                            {

                                currentMenuControl.MenuGotFocus();
                            }

                        }

                        menuControl.Dispose();

                        return true;

                    }
                    else
                        return false;

                    //break;

                }
            return true;
            //}
        }

        void item_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            NavBarItem item = sender as NavBarItem;


            DataRow menuRow = (DataRow)item.Tag;

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("EMP_CODE", typeof(String)); //
            paramTable.Columns.Add("MENU_CODE", typeof(String)); //

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["EMP_CODE"] = acInfo.UserID;
            paramRow["MENU_CODE"] = menuRow["MENU_CODE"];

            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.CHECK,
                        "MAINFORM_CHECK_ACCESSMENU", paramSet, "RQSTDT", "", menuRow,
                        QuickMenuOpen,
                        QuickMenuOpenException);

        }

        void QuickMenuOpen(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                DataRow menuRow = e.parameter as DataRow;

                this.LoadMenu(menuRow, emMenuType.STANDARD, null);

                if (acInfo.MenuLocation.Equals("H"))
                {
                    this.acDockPanel1.SendToBack();
                    this.acDockPanel1.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Hidden;
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void QuickMenuOpenException(object sender, QBiz QBiz, BizException ex)
        {
            if (ex.ErrNumber > 0)
            {
                acMessageBox.Show(acInfo.BizError.GetDesc(ex.ErrNumber), acInfo.SystemName, acMessageBox.emMessageBoxType.CONFIRM);
            }
            else
            {
                //acMessageBoxGridConfirm frm = new acMessageBoxGridConfirm(this, "acMessageBoxGridConfirm1", acInfo.BizError.GetDesc(100016), string.Empty, false, this.Caption, ex.ParameterData);
                acMessageBox.Show(this, ex);
            }
        }

        void SystemUpdateChcekerCallBack(object stateInfo)
        {
            try
            {
                //현재버전과 DB의 업데이트 버전 check
                string fullVersion = Properties.Settings.Default.VERSION.ToString();

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;

                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                DataSet dsResult = BizRun.QBizRun.ExecuteService(this, "SYS13A_SER", paramSet, "RQSTDT", "");

                Thread.Sleep(1000);

                if (dsResult.Tables["RSLTDT"].Rows.Count > 0)
                {
                    if (fullVersion == dsResult.Tables["RSLTDT"].Rows[0]["UPD_VER"].ToString()) return;

                    this.Invoke((MethodInvoker)delegate
                    {
                        if (!_NotifyUpdate)
                        {
                            //alertControl1.Images = Resource.dialog_information_x22;
                            alertControl1.AutoFormDelay = 10000;
                            alertControl1.Show(this, dsResult.Tables["RSLTDT"].Rows[0]["UPD_TITLE"].ToString(),
                                dsResult.Tables["RSLTDT"].Rows[0]["UPD_CONT"].ToString(),
                                Resource.publish_32x32);

                            acBarStaticItemSysVersion.Caption = acBarStaticItemSysVersion.Caption +
                                " [새로운 버전(" + dsResult.Tables["RSLTDT"].Rows[0]["UPD_VER"].ToString() + ")이 업데이트되었습니다. ]";
                            acBarStaticItemSysVersion.Appearance.ForeColor = Color.Aqua;

                            _NotifyUpdate = true;
                        }
                    });

                }

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void SystemVersionCheckerCallBack(object stateInfo)
        {
            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("APP_ID", typeof(String)); //
            paramTable.Columns.Add("VERSION", typeof(String)); //

            DataRow paramRow = paramTable.NewRow();
            paramRow["APP_ID"] = acInfo.SystemName;
            paramRow["VERSION"] = acInfo.Version;
            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);


            BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.NONE,
                    "CHECK_VERSION", paramSet, "RQSTDT", "",
                    QuickSystemVersionCheck,
                    QuickException);

        }

        void QuickSystemVersionCheck(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {


        }

        private bool _IsShowErrorMessageBox = false;


        void QuickException(object sender, QBiz QBiz, BizException ex)
        {
            if (this._IsShowErrorMessageBox == true)
            {
                return;
            }

            this._IsShowErrorMessageBox = true;


            if (ex.ErrNumber == 200062)
            {
                acMessageBox.Show(this, "새 버전이 배포되었습니다. 다시 실행해주시기 바랍니다.", "W8O2G9BP", true, acMessageBox.emMessageBoxType.CONFIRM);
            }
            else
            {

                acMessageBox.Show(this, ex);
            }

            this._IsShowErrorMessageBox = false;

        }


        private void SetSkin(string skinCode)
        {

            defaultLookAndFeel1.LookAndFeel.SkinName = skinCode;

            defaultLookAndFeel1.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;

        }
        public bool InitUserConfig = false;

        private void LoadConfigItem(string ConfigFileName)
        {
            //string Login(string userID, string userPW);

            FileInfo configFile = new FileInfo(ConfigFileName);

            if (configFile.Exists == true)
            {

                serverItemsTable = new DataTable();

                serverItemsTable.Columns.Add("Check", typeof(string));
                serverItemsTable.Columns.Add("ServerName", typeof(string));
                serverItemsTable.Columns.Add("ConfigMember", typeof(ConfigMember));


                XmlDocument newDoc = new XmlDocument();

                newDoc.Load(ConfigFileName);

                XmlNode config = newDoc.DocumentElement;

                string userid = string.Empty;

                foreach (XmlElement serverItem in config.ChildNodes)
                {
                    ConfigMember member = new ConfigMember();

                    member.ServerName = serverItem.GetAttribute("name");
                    member.Use = serverItem.GetAttribute("use");
                    member.UserID = serverItem.GetAttribute("userID");

                    member.ServerIP = GetXmlNodeValue(serverItem.GetElementsByTagName("ServerIP").Item(0));
                    member.ServerPort = GetXmlNodeValue(serverItem.GetElementsByTagName("ServerPort").Item(0));
                    member.ServerNum = GetXmlNodeValue(serverItem.GetElementsByTagName("ServerNum").Item(0));
                    member.Language = GetXmlNodeValue(serverItem.GetElementsByTagName("Language").Item(0));
                    member.Plant = GetXmlNodeValue(serverItem.GetElementsByTagName("Plant").Item(0));
                    member.Skin = GetXmlNodeValue(serverItem.GetElementsByTagName("Skin").Item(0));
                    member.DatabaseName = GetXmlNodeValue(serverItem.GetElementsByTagName("DatabaseName").Item(0));


                    userid = member.UserID;

                    DataRow serverItemRow = serverItemsTable.NewRow();

                    if (member.Use == "true")
                    {
                        serverItemRow["Check"] = "1";
                    }
                    else
                    {
                        serverItemRow["Check"] = "0";
                    }

                    serverItemRow["ServerName"] = member.ServerName;

                    serverItemRow["ConfigMember"] = member;

                    serverItemsTable.Rows.Add(serverItemRow);

                }

                //if (userid != "" && txtUserID.Text == "") txtUserID.Text = userid;
            }


        }

        private string GetXmlNodeValue(XmlNode node)
        {
            if (node == null) return string.Empty;


            if (node.FirstChild != null)
            {
                return node.FirstChild.Value;
            }
            else
            {
                return string.Empty;
            }

        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "창 " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "텍스트 파일 (*.txt)|*.txt|모든 파일 (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "텍스트 파일 (*.txt)|*.txt|모든 파일 (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private ControlManager.QThread _QuickSupportThread = null;

        private void acBarButtonItemSupport_ItemClick(object sender, ItemClickEventArgs e)
        {
            //원격지원
            try
            {
                if (acMessageBox.Show(this, "원격지원 서비스를 시작하시겠습니까?", "KV98UM6U", true, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
                {
                    return;
                }


                string quickSupport = Path.GetFileName(acInfo.SysConfig.GetSysConfigByMemory("QUICK_SUPPORT_URL"));

                string downloadFileName = string.Format(@"{0}\{1}", acInfo.GetTempSystemDirectory(), quickSupport);

                FileInfo fi = new FileInfo(downloadFileName);

                if (fi.Exists == false)
                {
                    this._QuickSupportThread = new ControlManager.QThread(this, ControlManager.QThread.emExecuteType.DOWNLOAD);

                    this._QuickSupportThread.Execute(quckSupportThreadStarter, downloadFileName);

                }
                else
                {
                    System.Diagnostics.Process.Start(downloadFileName);
                }

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);

            }
        }

        void quckSupportThreadStarter(object args)
        {

            string downloadFileName = args as string;

            try
            {
                WebClient webClient = new WebClient();

                webClient.DownloadFile(new Uri(acInfo.SysConfig.GetSysConfigByMemory("QUICK_SUPPORT_URL")), downloadFileName);

                this.BeginInvoke((MethodInvoker)delegate
                {

                    if (this._QuickSupportThread.IsThreadAbort == false)
                    {
                        System.Diagnostics.Process.Start(downloadFileName);

                    }

                });

            }
            catch (Exception ex)
            {
                if (ex is ThreadAbortException)
                {
                    FileInfo fi = new FileInfo(downloadFileName);

                    fi.Delete();
                }
                else
                {
                    this.BeginInvoke((MethodInvoker)delegate
                    {
                        acMessageBox.Show(this, ex);

                    });

                }
            }

        }

        private void acBarButtonItemHelp_ItemClick(object sender, ItemClickEventArgs e)
        {



            acMessageBoxHelp frm = new acMessageBoxHelp("HELP_MAIN_SYSTEM");

            frm.ParentControl = this;

            frm.Show();
        }

        private void btnEmpConf_ItemClick(object sender, ItemClickEventArgs e)
        {
            EmpConf frm = new EmpConf();

            frm.Text = e.Item.Caption;

            frm.ParentControl = this;

            frm.ShowDialog();
        }

        private void btnChangePwd_ItemClick(object sender, ItemClickEventArgs e)
        {
            //비밀번호 변경

            ChangePassword frm = new ChangePassword();

            frm.Text = e.Item.Caption;

            frm.ParentControl = this;

            frm.ShowDialog();

        }

        private void btnInitMenu_ItemClick(object sender, ItemClickEventArgs e)
        {
            //현재 활성메뉴 자동UI 설정 초기화

            if (acMessageBox.Show(acInfo.Resource.GetString("정말 현재 활성메뉴 자동UI 설정 초기화 하시겠습니까?", "XQ7Z4CFU"), acInfo.SystemName, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
            {
                return;
            }

            BaseMenu menu = tabbedView1.ActiveDocument.Control as BaseMenu;

            bool result = menu.MenuDestory(this);

            if (result == true)
            {
                this.CloseDocument(tabbedView1.ActiveDocument as Document);
            }
            else
            {
                return;
            }

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String));
            paramTable.Columns.Add("EMP_CODE", typeof(String));
            paramTable.Columns.Add("CLASS_NAME", typeof(String));
            paramTable.Columns.Add("USE_CONFIG_NAME", typeof(String));

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["EMP_CODE"] = acInfo.UserID;
            paramRow["CLASS_NAME"] = menu.Name;
            //paramRow["USE_CONFIG_NAME"] = acInfo.DefaultConfigName;

            paramTable.Rows.Add(paramRow);

            for (int i = 0; i < 10; i++)
            {
                paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["EMP_CODE"] = acInfo.UserID;
                paramRow["CLASS_NAME"] = menu.Name.Substring(0,6) + "_D" + i.ToString() + "A";
                //paramRow["USE_CONFIG_NAME"] = acInfo.DefaultConfigName;


                paramTable.Rows.Add(paramRow);
            }



            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.PROCESS, "SYS07A_DEL3", paramSet, "RQSTDT", "", QuickProcess2, QuickException);
            //BizRun.QBizRun.ExecuteService(
            //this, QBiz.emExecuteType.PROCESS,
            //"SYS07A_DEL3", paramSet, "RQSTDT", "",
            //QuickProcess2,
            //QuickException);
        }

        void QuickProcess2(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                foreach (DataRow row in e.result.Tables["RQSTDT"].Rows)
                {

                    acDockManager.RemoveUserConifg(row["CLASS_NAME"].ToString());

                    acBarManager.RemoveUserConifg(row["CLASS_NAME"].ToString());

                    acForm.RemoveUserConifg(row["CLASS_NAME"].ToString());

                    acSplitContainerControl.RemoveUserConifg(row["CLASS_NAME"].ToString());


                }

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        protected override void OnHandleDestroyed(EventArgs e)
        {
            if (bDoExit)
            {
                if (DestroyAllMenuPage())
                {

                    SaveControlUserConfigs();
                    //SaveControlUserConfigs
                }
            }


        }

        public bool DestroyAllMenuPage()
        {

            foreach (KeyValuePair<string, Document> open in this._OpenDocumentDic)
            {

                Document menuPage = (Document)open.Value;

                //foreach (Control ctrl in menuPage.Control.Controls)
                {
                    if (menuPage.Control is BaseMenu)
                    {
                        BaseMenu menu = menuPage.Control as BaseMenu;

                        bool r = menu.MenuDestory(this);


                        if (r == false)
                        {
                            return false;
                        }
                        else
                        {
                            menu.Dispose();

                            //break;
                        }
                    }


                }

            }

            tabbedView1.Dispose();
            this._OpenDocumentDic.Clear();

            return true;

        }

        private void btnInitAll_ItemClick(object sender, ItemClickEventArgs e)
        {
            //전체 자동UI 설정 초기화

            if (acMessageBox.Show(acInfo.Resource.GetString("정말 전체 자동UI 설정 초기화 하시겠습니까?", "UW5M4I89"), acInfo.SystemName, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
            {
                return;
            }

            if (this.DestroyAllMenuPage() == true)
            {

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String));
                paramTable.Columns.Add("EMP_CODE", typeof(String));
                paramTable.Columns.Add("USE_CONFIG_NAME", typeof(String));


                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["EMP_CODE"] = acInfo.UserID;
                //paramRow["USE_CONFIG_NAME"] = acInfo.DefaultConfigName;

                paramTable.Rows.Add(paramRow);


                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.PROCESS, "SYS07A_DEL2", paramSet, "RQSTDT", "",
                    QuickProcess, QuickException);

            }
        }

        void QuickProcess(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                this.InitUserConfig = true;

                acDockManager.ClearUserConfig();

                acBarManager.ClearUserConfig();

                acForm.ClearUserConfig();

                acSplitContainerControl.ClearUserConfig();

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        public void ReceiveWindowMessage(string msg)
        {
            if (tabbedView1.ActiveDocument != null)
            {
                //foreach (Control ctrl in acTabControl1.SelectedTabPage.Controls)
                {

                    if (tabbedView1.ActiveDocument.Control is BaseMenu)
                    {
                        BaseMenu menu = tabbedView1.ActiveDocument.Control as BaseMenu;

                        menu.ReceiveWindowMessage(msg);

                        //break;
                    }

                }
            }

        }
        int i = 0;
        void AddDocument()
        {
            XtraUserControl child = new XtraUserControl();
            DocumentSettings settings = new DocumentSettings();
            settings.Caption = "Document" + (i++).ToString();
            //settings.Image = svgImageCollection1.GetImage(i % (svgImageCollection1.Count - 1));
            DocumentSettings.Attach(child, settings);
            child.Padding = new Padding(16);
            LabelControl label = new LabelControl();
            label.Text = i.ToString();
            label.AutoSizeMode = LabelAutoSizeMode.Vertical;
            label.Parent = child;
            label.Dock = DockStyle.Fill;
            tabbedView1.AddDocument(child);
            EnableColoredTabs();
        }
        Color[] TabColors = new Color[]{
            Color.FromArgb(35,83,194),
            Color.FromArgb(64,168,19),
            Color.FromArgb(245,121,10),
            Color.FromArgb(141,62,168),
            Color.FromArgb(70,155,183),
            Color.FromArgb(196,19,19)
        };
        void EnableColoredTabs()
        {
            System.Random rand = new System.Random();

            ((Document)tabbedView1.Documents[tabbedView1.Documents.Count - 1]).Appearance.Header.BackColor = TabColors[(rand.Next(1, 6) - 1) % 6];
        }

        #region IProperty 멤버

        private string _DesLogin = null;

        public string DesLogin
        {
            get
            {
                return _DesLogin;
            }
            set
            {
                _DesLogin = value;
            }
        }

        #endregion

        #region IMainMenu 멤버

        void IMainControl.MoveLinkMenu(string menuCode, object data)
        {
            this.MoveMenu(emMenuType.LINK, menuCode, data);
        }

        void IMainControl.MoveNotifyMenu(string menuCode, object data)
        {
            this.MoveMenu(emMenuType.NOTIFY, menuCode, data);

        }
        void IMainControl.ReceiveWindowMessage(string msg)
        {
            this.ReceiveWindowMessage(msg);
        }

        void IMainControl.CloseMenu(string className)
        {
            if (_OpenDocumentDic.ContainsKey(className))
            {
                this.CloseDocument(_OpenDocumentDic[className]);

            }
        }


        void IMainControl.Exit()
        {
            (this.Parent as XtraForm).Close();
        }



        #endregion

        private void acBarButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
        {
           

        }

        void QuickMymenu(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {

            DataRow row = tabbedView1.ActiveDocument.Tag as DataRow;

            try
            {
                

                if (e.result.Tables["RSLTDT"].Rows.Count > 0)
                {
                    
                    if (e.result.Tables["RSLTDT"].Rows[0]["RESULT"].ToString() == "ADD")
                    {
                        DataRow[] drMenu = this._MenuList.Select(string.Format("MENU_CODE = '{0}'",  e.result.Tables["RQSTDT"].Rows[0]["MENU_CODE"].ToString()));

                        DataRow dr = drMenu[0];

                        if (acInfo.MenuLocation.Equals("V2"))
                        {
                            this.AddMyMenu(row);
                        }
                        else
                        {
                            this.AddBarMyMenu(row);
                        }

                        if (!this._MyMenu.ContainsKey(dr["MENU_CODE"].ToString()))
                            this._MyMenu.Add(dr["MENU_CODE"].ToString(), dr);

                        acAlert.Show(this, "즐겨찾기에 추가되었습니다.", acAlertForm.enmType.Success);

                        SetMymenuStatus(dr);

                        //chkMymenu.Caption = "즐겨찾기 제거";
                        //chkMymenu.Tag = "DEL";

                    }
                    else
                    {
                        acAlert.Show(this, "이미 즐겨찾기에 추가된 메뉴입니다. ", acAlertForm.enmType.Success);
                    }
                    
                }    
            }
            catch (Exception ex)
            {

                acMessageBox.Show(this, ex);
            }
            finally
            {
                SetMymenuStatus(row);
            }
        }

        
        void QuickDelMymenu(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                if (e.result.Tables["RQSTDT"].Rows.Count > 0)
                {
                    if (acInfo.MenuLocation.Equals("V2"))
                    {
                        foreach (NavBarItemLink itemLink in this.navMenu.Groups[0].ItemLinks)
                        {
                            if (itemLink.Caption == e.result.Tables["RQSTDT"].Rows[0]["MENU_NAME"].ToString())
                            {
                                this.navMenu.Groups[0].ItemLinks.Remove(itemLink);
                                this._MyMenu.Remove(e.result.Tables["RQSTDT"].Rows[0]["MENU_CODE"].ToString());

                                acAlert.Show(this, "즐겨찾기에서 제거하였습니다. ", acAlertForm.enmType.Success);
                                return;
                            }
                        }

                        acAlert.Show(this, "이미 즐겨찾기에서 제거하였습니다. ", acAlertForm.enmType.Success);
                    }
                    else
                    {
                        acBarSubItem subitem = this.bar1.ItemLinks[0].Item as acBarSubItem;

                        foreach(BarItemLink item in subitem.ItemLinks)
                        {
                            if (item.Caption == e.result.Tables["RQSTDT"].Rows[0]["MENU_NAME"].ToString())
                            {
                                subitem.ItemLinks.Remove(item);

                                this._MyMenu.Remove(e.result.Tables["RQSTDT"].Rows[0]["MENU_CODE"].ToString());

                                acAlert.Show(this, "즐겨찾기에서 제거하였습니다. ", acAlertForm.enmType.Success);
                                return;
                            }
                        }

                        acAlert.Show(this, "이미 즐겨찾기에서 제거하였습니다. ", acAlertForm.enmType.Success);
                        
                    }
                        


                }
            }
            catch (Exception ex)
            {

                acMessageBox.Show(this, ex);
            }
            finally
            {
                SetMymenuStatus(e.result.Tables["RQSTDT"].Rows[0]);
            }

        }

        private void chkMymenu_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (tabbedView1.ActiveDocument == null) return;

                BarCheckItem item = e.Item as BarCheckItem;

                DataRow row = tabbedView1.ActiveDocument.Tag as DataRow;

                if (item.Tag.ToString() == "ADD")
                {
                    

                    DataTable dtparam = new DataTable("RQSTDT");
                    dtparam.Columns.Add("PLT_CODE", typeof(string));
                    dtparam.Columns.Add("MENU_CODE", typeof(string));
                    dtparam.Columns.Add("EMP_CODE", typeof(string));

                    DataRow drparam = dtparam.NewRow();
                    drparam["PLT_CODE"] = acInfo.PLT_CODE;
                    drparam["MENU_CODE"] = row["MENU_CODE"];
                    drparam["EMP_CODE"] = acInfo.UserID;
                    dtparam.Rows.Add(drparam);

                    DataSet paramSet = new DataSet();
                    paramSet.Tables.Add(dtparam);

                    BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.NONE,
                        "MAINFORM_SAVE_MYMENU", paramSet, "RQSTDT", "",
                        QuickMymenu,
                        QuickException);
                    
                    //item.LargeGlyph = Resource.feature_16x16;
                }
                else if (item.Tag.ToString() == "DEL")
                {
                    
                    DataTable dtparam = new DataTable("RQSTDT");
                    dtparam.Columns.Add("PLT_CODE", typeof(string));
                    dtparam.Columns.Add("MENU_CODE", typeof(string));
                    dtparam.Columns.Add("MENU_NAME", typeof(string));
                    dtparam.Columns.Add("EMP_CODE", typeof(string));

                    DataRow drparam = dtparam.NewRow();
                    drparam["PLT_CODE"] = acInfo.PLT_CODE;
                    drparam["MENU_CODE"] = row["MENU_CODE"];
                    drparam["MENU_NAME"] = row["MENU_NAME"];
                    drparam["EMP_CODE"] = acInfo.UserID;
                    dtparam.Rows.Add(drparam);

                    DataSet paramSet = new DataSet();
                    paramSet.Tables.Add(dtparam);

                    BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.NONE,
                        "MAINFORM_DEL_MYMENU", paramSet, "RQSTDT", "",
                        QuickDelMymenu,
                        QuickException);

                }
                
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }
    }
}
