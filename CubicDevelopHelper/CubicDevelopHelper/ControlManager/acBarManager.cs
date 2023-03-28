using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.ComponentModel;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Painters;
using DevExpress.XtraBars.Styles;
using DevExpress.XtraBars.ViewInfo;
using DevExpress.Utils.Drawing;
using DevExpress.Utils;
using BizManager;

namespace ControlManager
{

    public class acBarManager : DevExpress.XtraBars.BarManager
    {
        public static Dictionary<string, byte[]> _UserConfigs = new Dictionary<string, byte[]>();

        public static void ClearUserConfig()
        {
            acBarManager._UserConfigs.Clear();
        }

        public static void RemoveUserConifg(string parentClassName)
        {
            List<string> removeKey = new List<string>();

            foreach (KeyValuePair<string, byte[]> uc in acBarManager._UserConfigs)
            {
                string[] names = uc.Key.Split(',');

                string className = names[0];
                string controlName = names[1];

                if (className == parentClassName)
                {
                    removeKey.Add(uc.Key);
                }
            }

            foreach (string key in removeKey)
            {
                acBarManager._UserConfigs.Remove(key);

            }
        }

        public static void SaveUserConfig()
        {


            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("EMP_CODE", typeof(String)); //
            paramTable.Columns.Add("CLASS_NAME", typeof(String)); //
            paramTable.Columns.Add("CONTROL_NAME", typeof(String)); //
            paramTable.Columns.Add("CONFIG_NAME", typeof(String)); //
            paramTable.Columns.Add("DEFAULT_USE", typeof(String)); //기본UI로 설정
            paramTable.Columns.Add("LAYOUT", typeof(Byte[])); //
            paramTable.Columns.Add("OBJECT", typeof(Byte[])); //
            paramTable.Columns.Add("OVERWRITE", typeof(String)); //덮어쓰기 여부

            foreach (KeyValuePair<string, byte[]> uc in acBarManager._UserConfigs)
            {
                string[] names = uc.Key.Split(',');

                string className = names[0];
                string controlName = names[1];

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["EMP_CODE"] = acInfo.UserID;

                paramRow["CLASS_NAME"] = className;

                paramRow["CONTROL_NAME"] = GetClassName();
                paramRow["CONFIG_NAME"] = acInfo.DefaultConfigName;
                paramRow["DEFAULT_USE"] = "1";
                
                paramRow["LAYOUT"] = uc.Value;
                paramRow["OBJECT"] = null;
                paramRow["OVERWRITE"] = "1";
                paramTable.Rows.Add(paramRow);


            }

            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            DataSet resultSet = BizRun.QBizRun.ExecuteService(GetClassName(),"CTRL", "SET_USERCONFIG_SAVE", paramSet, "RQSTDT", "RSLTDT");
            
            //DataSet resultSet = BizManager.acControls.SET_USERCONFIG_SAVE(paramSet);

            acBarManager._UserConfigs.Clear();
        }

        public static string GetClassName()
        {
            return "acBarManager";
        }

        public enum emBarShortCutType
        {
            /// <summary>
            /// 없음
            /// </summary>
            NONE,

            /// <summary>
            /// 저장

            /// </summary>
            SAVE,

            /// <summary>
            /// 삭제
            /// </summary>
            DEL,

            /// <summary>
            /// 초기화

            /// </summary>
            CLEAR,

            /// <summary>
            /// 조회
            /// </summary>
            SEARCH,


            /// <summary>
            /// 도움말

            /// </summary>
            HELP,


            /// <summary>
            /// 예

            /// </summary>
            YES,

            /// <summary>
            /// 아니오

            /// </summary>
            NO,

            /// <summary>
            /// 메시지 확인
            /// </summary>
            MSG_CONFIRM,

            /// <summary>
            /// 선택 확인
            /// </summary>
            SELECT,

            /// <summary>
            /// 창고정

            /// </summary>
            WIN_LOCK,


            /// <summary>
            /// 열기
            /// </summary>
            FILE_OPEN,


            /// <summary>
            /// 출력
            /// </summary>
            PRINT,

            /// <summary>
            /// 기능1
            /// </summary>
            METHOD_1,

            /// <summary>
            /// 기능2
            /// </summary>
            METHOD_2,

            /// <summary>
            /// 기능3
            /// </summary>
            METHOD_3,

            /// <summary>
            /// 기능4
            /// </summary>
            METHOD_4,

            /// <summary>
            /// 기능5
            /// </summary>
            METHOD_5,

            /// <summary>
            /// 추가
            /// </summary>
            NEW

                //

        }






        public void SetShortCutType(emBarShortCutType shortCutType, BarBaseButtonItem item)
        {
            switch (shortCutType)
            {

                case acBarManager.emBarShortCutType.NONE:

                    this.RemoveShortCutToolTip(item);

                    break;

                case acBarManager.emBarShortCutType.SAVE:

                    this.SetShortCut(item, System.Windows.Forms.Shortcut.CtrlS);

                    break;

                case acBarManager.emBarShortCutType.SEARCH:

                    this.SetShortCut(item, System.Windows.Forms.Shortcut.CtrlQ);

                    break;

                case acBarManager.emBarShortCutType.CLEAR:

                    this.SetShortCut(item, System.Windows.Forms.Shortcut.CtrlShiftX);

                    break;

                case acBarManager.emBarShortCutType.DEL:

                    this.SetShortCut(item, System.Windows.Forms.Shortcut.CtrlD);

                    break;

                case acBarManager.emBarShortCutType.HELP:

                    this.SetShortCut(item, System.Windows.Forms.Shortcut.F1);

                    break;

                case acBarManager.emBarShortCutType.YES:

                    this.SetShortCut(item, System.Windows.Forms.Keys.Y);

                    break;

                case acBarManager.emBarShortCutType.NO:

                    this.SetShortCut(item, System.Windows.Forms.Keys.N);

                    break;

                case acBarManager.emBarShortCutType.MSG_CONFIRM:

                    this.SetShortCut(item, System.Windows.Forms.Keys.Enter);

                    break;


                case emBarShortCutType.SELECT:


                    this.SetShortCut(item, System.Windows.Forms.Shortcut.CtrlS);

                    break;

                case emBarShortCutType.WIN_LOCK:

                    this.SetShortCut(item, System.Windows.Forms.Shortcut.CtrlL);

                    break;

                case emBarShortCutType.FILE_OPEN:

                    this.SetShortCut(item, System.Windows.Forms.Shortcut.CtrlO);

                    break;

                case emBarShortCutType.PRINT:

                    this.SetShortCut(item, System.Windows.Forms.Shortcut.CtrlP);

                    break;

                case emBarShortCutType.METHOD_1:

                    this.SetShortCut(item, System.Windows.Forms.Shortcut.Ctrl1);

                    break;

                case emBarShortCutType.METHOD_2:

                    this.SetShortCut(item, System.Windows.Forms.Shortcut.Ctrl2);

                    break;


                case emBarShortCutType.METHOD_3:

                    this.SetShortCut(item, System.Windows.Forms.Shortcut.Ctrl3);

                    break;

                case emBarShortCutType.METHOD_4:

                    this.SetShortCut(item, System.Windows.Forms.Shortcut.Ctrl4);

                    break;

                case emBarShortCutType.METHOD_5:

                    this.SetShortCut(item, System.Windows.Forms.Shortcut.Ctrl5);

                    break;
                case emBarShortCutType.NEW:

                    this.SetShortCut(item, System.Windows.Forms.Shortcut.CtrlN);

                    break;


            }
        }

        private void SetShortCut(BarBaseButtonItem item, System.Windows.Forms.Shortcut keys)
        {


            this.RemoveShortCutToolTip(item);

            ToolTipTitleItem shorCutTT = new ToolTipTitleItem();

            shorCutTT.Appearance.Name = "ShortCut";

            shorCutTT.Image = Resource.keyboard_x16;

            shorCutTT.ImageToTextDistance = 3;

            shorCutTT.Text = acKey.GetShortCutName(keys);

            item.SuperTip.Items.Add(shorCutTT);

            item.ItemShortcut = new DevExpress.XtraBars.BarShortcut(keys);
        }

        private void SetShortCut(BarBaseButtonItem item, System.Windows.Forms.Keys keys)
        {


            this.RemoveShortCutToolTip(item);


            ToolTipTitleItem shorCutTT = new ToolTipTitleItem();

            shorCutTT.Appearance.Name = "ShortCut";

            shorCutTT.Image = Resource.keyboard_x16;

            shorCutTT.ImageToTextDistance = 3;

            shorCutTT.Text = acKey.GetShortCutName(keys);

            item.SuperTip.Items.Add(shorCutTT);

            item.ItemShortcut = new DevExpress.XtraBars.BarShortcut(keys);

        }





        private void RemoveShortCutToolTip(BarBaseButtonItem item)
        {


            if (item.SuperTip == null)
            {
                item.SuperTip = new SuperToolTip();
            }

            int shortCutIdx = -1;

            int cnt = 0;

            foreach (BaseToolTipItem ttItem in item.SuperTip.Items)
            {
                if (ttItem.Appearance.Name == "ShortCut")
                {
                    shortCutIdx = cnt;

                    break;
                }

                ++cnt;
            }


            if (shortCutIdx >= 0)
            {
                item.SuperTip.Items.RemoveAt(shortCutIdx);
            }

            item.ItemShortcut = new BarShortcut(System.Windows.Forms.Keys.None);

        }

        public acBarManager(IContainer container)
            : base(container)
        {

            this.HighlightedLinkChanged += new HighlightedLinkChangedEventHandler(acBarManager_HighlightedLinkChanged);
        }


        void acBarManager_HighlightedLinkChanged(object sender, HighlightedLinkChangedEventArgs e)
        {
            PropertyInfo pi = typeof(DevExpress.XtraBars.BarManager).GetProperty("SelectionInfo", BindingFlags.Instance | BindingFlags.NonPublic);

            BarSelectionInfo bsi = pi.GetValue(this, null) as BarSelectionInfo;

            
            //bsi.ToolTipTimer.Interval = 100;
        }



        public acBarManager()
            : base()
        {
            acBarButtonItem.Register();
            acBarStaticItem.Register();
            acBarSubItem.Register();
            acBarCheckItem.Register();
            acBarEditItem.Register();

            this.AllowCustomization = false;

            this.AllowQuickCustomization = false;

            this.AllowShowToolbarsPopup = false;

            this.CloseButtonAffectAllTabs = false;



        }


        private bool _IsLoadDefaultLayout = true;


        /// <summary>
        /// 기본레이아웃을 불러올지 여부를 설정합니다.
        /// </summary>
        public bool IsLoadDefaultLayout
        {
            get { return _IsLoadDefaultLayout; }
            set { _IsLoadDefaultLayout = value; }
        }



        protected override void OnEndInit()
        {


            base.OnEndInit();

            if (this._IsLoadDefaultLayout == true)
            {

                if (this.Form is BaseMenu)
                {
                    BaseMenu b = this.Form as BaseMenu;
                    b.OnMenuLoadManager += new BaseMenu.MenuLoadManagerEventHandler(acBarManager_OnMenuLoadManager);
                    b.OnMenuLoadBarManager += new BaseMenu.MenuLoadBarManagerEventHandler(acBarManager_OnMenuLoadBarManager);
                    b.OnMenuDestory += new BaseMenu.MenuDestoryEventHandler(acBarManager_OnMenuDestory);
                }
                else if (this.Form is BaseMenuDialog)
                {
                    BaseMenuDialog b = this.Form as BaseMenuDialog;

                    b.OnDialogLoadManager += new BaseMenuDialog.DialogLoadManagerEventHandler(acBarManager_OnDialogLoadManager);
                    b.OnDialogLoadBarManager += new BaseMenuDialog.DialogLoadBarManagerEventHandler(acBarManager_OnDialogLoadBarManager);
                    b.OnDialogDestory += new BaseMenuDialog.DialogDestoryEventHandler(acBarManager_OnDialogDestory);
                }

            }



        }

        void acBarManager_OnDialogLoadBarManager(object sender)
        {
            this.InitBarItem();

            this.LoadMenuDefaultLayout();
        }

        void acBarManager_OnDialogLoadManager(object sender)
        {
            this.SaveSystemDefaultLayout();
        }

        void acBarManager_OnMenuLoadManager(object sender)
        {
            this.SaveSystemDefaultLayout();
        }

        void acBarManager_OnDialogDestory(object sender)
        {
            this.SaveDefaultLayout();

        }

        void acBarManager_OnMenuDestory(object sender)
        {
            this.SaveDefaultLayout();
        }

        void acBarManager_OnMenuLoadBarManager(object sender)
        {

            this.InitBarItem();

            this.LoadMenuDefaultLayout();
        }


        public void InitBarItem()
        {
            foreach (object item in this.Items)
            {
                if (item is acBarButtonItem)
                {
                    acBarButtonItem b = item as acBarButtonItem;

                    //툴팁 설정
                    if (b.UseToolTipID == true)
                    {
                        if (!string.IsNullOrEmpty(b.ToolTipID))
                        {
                            if (acInfo.ToolTip.IsToolTip(b.ToolTipID))
                            {
                                b.SuperTip = acInfo.ToolTip.GetToolTip(b.ToolTipID);

                                ToolTipTitleItem title = acInfo.ToolTip.GetToolTip(b.ToolTipID).Items[0] as ToolTipTitleItem;

                                if (title != null)
                                {
                                    b.Caption = title.Text;
                                }

                            }

                        }
                    }
                    //리소스 설정
                    else if (b.UseResourceID == true)
                    {

                        if (acInfo.Resource != null)
                        {

                            b.Caption = acInfo.Resource.GetString(b.Caption, b.ResourceID);
                        }

                    }
                    
                    this.SetShortCutType(b.ButtonShortCutType, b);
                }
                else if (item is acBarCheckItem)
                {
                    acBarCheckItem b = item as acBarCheckItem;

                    //툴팁 설정
                    if (b.UseToolTipID == true)
                    {
                        if (!string.IsNullOrEmpty(b.ToolTipID))
                        {
                            if (acInfo.ToolTip.IsToolTip(b.ToolTipID))
                            {
                                b.SuperTip = acInfo.ToolTip.GetToolTip(b.ToolTipID);

                                ToolTipTitleItem title = acInfo.ToolTip.GetToolTip(b.ToolTipID).Items[0] as ToolTipTitleItem;

                                if (title != null)
                                {
                                    b.Caption = title.Text;
                                }

                            }

                        }
                    }
                    //리소스 설정
                    else if (b.UseResourceID == true)
                    {

                        if (acInfo.Resource != null)
                        {

                            b.Caption = acInfo.Resource.GetString(b.Caption, b.ResourceID);
                        }

                    }

                }



            }
        }


        void SaveSystemDefaultLayout()
        {
            //TODO:레이아웃 사용 막음
            return;
            MemoryStream sourceLayout = new MemoryStream();

            this.SaveLayoutToStream(sourceLayout);

            this._SourceLayout = sourceLayout.ToArray();

            sourceLayout.Close();
        }



        private byte[] _SourceLayout = null;

        private int _SourceBarItemCnt = 0;

        public void LoadSystemDefaultLayout()
        {
            //TODO:레이아웃 사용 막음
            return;
            MemoryStream layoutSt = new MemoryStream(this._SourceLayout, 0, this._SourceLayout.Length);

            this.RestoreLayoutFromStream(layoutSt);

            layoutSt.Close();
        }


        /// <summary>
        /// 기본레이아웃을 불러온다.
        /// </summary>
        public void LoadDefaultLayout()
        {

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("EMP_CODE", typeof(String)); //
            paramTable.Columns.Add("CLASS_NAME", typeof(String)); //
            paramTable.Columns.Add("CONTROL_NAME", typeof(String)); //

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["EMP_CODE"] = acInfo.UserID;
            paramRow["CLASS_NAME"] = this.Form.Name;
            paramRow["CONTROL_NAME"] = GetClassName();
            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            DataSet resultSet = BizRun.QBizRun.ExecuteService(this, "CTRL","GET_USERCONFIG_DEFAULT_USE", paramSet, "RQSTDT", "RSLTDT");

            if (resultSet.Tables["RSLTDT"].Rows.Count != 0)
            {

                byte[] layout = (byte[])resultSet.Tables["RSLTDT"].Rows[0]["LAYOUT"];

                MemoryStream layoutSt = new MemoryStream(layout, 0, layout.Length);

                this.RestoreLayoutFromStream(layoutSt);

                layoutSt.Close();

            }

        }

        /// <summary>
        /// 메뉴 기본레이아웃을 불러온다.
        /// </summary>
        private void LoadMenuDefaultLayout()
        {
            //TODO:레이아웃 사용 막음
            return;

            this._SourceBarItemCnt = acBarManager.GetBarItemCnt(this);


            MemoryStream layoutSt = null;

            string key = string.Format("{0},{1}", this.Form.Name, GetClassName());


            if (acBarManager._UserConfigs.ContainsKey(key))
            {
                layoutSt = new MemoryStream(acBarManager._UserConfigs[key], 0, acBarManager._UserConfigs[key].Length);

            }
            else
            {


                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("EMP_CODE", typeof(String)); //
                paramTable.Columns.Add("CLASS_NAME", typeof(String)); //
                paramTable.Columns.Add("CONTROL_NAME", typeof(String)); //

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["EMP_CODE"] = acInfo.UserID;
                paramRow["CLASS_NAME"] = this.Form.Name;
                paramRow["CONTROL_NAME"] = GetClassName();
                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                DataSet resultSet = BizRun.QBizRun.ExecuteService(this, "CTRL", "GET_USERCONFIG_DEFAULT_USE", paramSet, "RQSTDT", "RSLTDT");

                if (resultSet.Tables["RSLTDT"].Rows.Count != 0)
                {

                    byte[] layout = (byte[])resultSet.Tables["RSLTDT"].Rows[0]["LAYOUT"];

                    layoutSt = new MemoryStream(layout, 0, layout.Length);



                }
            }

            if (layoutSt != null)
            {
                this.RestoreLayoutFromStream(layoutSt);

                layoutSt.Close();

            }

            int restoreBarItemCnt = acBarManager.GetBarItemCnt(this);


            //if (this._SourceBarItemCnt != restoreBarItemCnt)
            //{
            //    this.LoadSystemDefaultLayout();

            //    acMessageBox.Show(this.Form, "추가기능으로 인하여 도구상자 사용자 UI정보가 초기화되었습니다.", "R915FRI2", true, acMessageBox.emMessageBoxType.CONFIRM);
            //}


        }


        public static int GetBarItemCnt(acBarManager barManager)
        {

            int itemCnt = 0;


            foreach (BarItem item in barManager.Items)
            {
                if (item.Links.Count > 0)
                {

                    if (item.Links[0].Visible == true)
                    {
                        ++itemCnt;
                    }

                }

            }


            return itemCnt;
        }



        /// <summary>
        /// 기본레이아웃을 저장한다.
        /// </summary>
        public void SaveDefaultLayout()
        {
            //TODO:레이아웃 사용 막음
            return;

            if (this.Form == null)
                return;

            string key = string.Format("{0},{1}", this.Form.Name, GetClassName());

            MemoryStream layoutSt = new MemoryStream();

            this.SaveLayoutToStream(layoutSt);

            if (!acBarManager._UserConfigs.ContainsKey(key))
            {
                acBarManager._UserConfigs.Add(key, layoutSt.ToArray());
            }
            else
            {
                acBarManager._UserConfigs[key] = layoutSt.ToArray();
            }

            layoutSt.Close();

        }


    }


    public class acBar : Bar, IBaseViewControl
    {
        public acBar()
            : base()
        {
            this.OptionsBar.AllowQuickCustomization = false;
            this.BarItemHorzIndent = 10;
            this.BarItemVertIndent = 5;
            this.OptionsBar.MultiLine = true;
            //this.OptionsBar.UseWholeRow
        }


        public void SetBarName()
        {
            if (acInfo.IsRunTime == true)
            {
                this.CanDockStyle = ((DevExpress.XtraBars.BarCanDockStyle)(((((DevExpress.XtraBars.BarCanDockStyle.Left | DevExpress.XtraBars.BarCanDockStyle.Top)
                        | DevExpress.XtraBars.BarCanDockStyle.Right)
                        | DevExpress.XtraBars.BarCanDockStyle.Bottom)
                        | DevExpress.XtraBars.BarCanDockStyle.Standalone)));

                //리소스 설정
                if (this._UseResourceID == true)
                {

                    this.Text = acInfo.Resource.GetString(this.Text, this._ResourceID);



                }

            }
        }


        #region IBaseViewControl 멤버

        private string _ResourceID = null;

        public string ResourceID
        {
            get
            {
                return _ResourceID;
            }
            set
            {
                _ResourceID = value;

                if (acInfo.IsRunTime == false)
                {
                    if (!string.IsNullOrEmpty(_ResourceID))
                    {
                        _UseResourceID = true;
                    }

                }

                this.SetBarName();

            }
        }

        private bool _UseResourceID = false;

        public bool UseResourceID
        {
            get
            {
                return _UseResourceID;
            }
            set
            {
                _UseResourceID = value;

                this.SetBarName();

            }
        }



        private string _ToolTipID = null;

        public string ToolTipID
        {
            get
            {
                return _ToolTipID;
            }
            set
            {
                _ToolTipID = value;
            }
        }

        private bool _UseToolTipID = false;

        public bool UseToolTipID
        {
            get
            {
                return _UseToolTipID;
            }
            set
            {
                _UseToolTipID = value;
            }
        }

        #endregion
    }

    public class acBarCheckItem : BarCheckItem, IBaseViewControl
    {
        static acBarCheckItem()
        {
            Register();


        }

        public void RaiseOnClick()
        {
            this.OnClick(this.Links[0]);
        }

        protected override void OnClick(BarItemLink link)
        {
            if (this.Manager.Form.Visible == false)
            {
                return;
            }


            base.OnClick(link);
        }


        private acBarManager.emBarShortCutType _ButtonShortCutType = acBarManager.emBarShortCutType.NONE;


        [Description("단축키형태 설정")]
        [DefaultValue(acBarManager.emBarShortCutType.NONE)]
        public acBarManager.emBarShortCutType ButtonShortCutType
        {
            get { return _ButtonShortCutType; }
            set { _ButtonShortCutType = value; }
        }


        //protected override void AfterLoad()
        //{

        //    //if (acInfo.IsRunTime == true)
        //    //{

        //    //    //툴팁 설정
        //    //    if (this._UseToolTipID == true)
        //    //    {
        //    //        if (!string.IsNullOrEmpty(this._ToolTipID))
        //    //        {
        //    //            if (acInfo.ToolTip.IsToolTip(this._ToolTipID))
        //    //            {
        //    //                this.SuperTip = acInfo.ToolTip.GetToolTip(this._ToolTipID);


        //    //                ToolTipTitleItem title = acInfo.ToolTip.GetToolTip(this._ToolTipID).Items[0] as ToolTipTitleItem;

        //    //                this.Caption = title.Text;
        //    //            }

        //    //        }
        //    //    }


        //    //    //리소스 설정
        //    //    else if (this._UseResourceID == true)
        //    //    {

        //    //        this.Caption = acInfo.Resource.GetString(this.Caption, this._ResourceID);

        //    //    }



        //    //    //단축키 설정

        //    //    //(this.Manager as acBarManager).SetShortCutType(this._ButtonShortCutType, this);


        //    //}


        //    base.AfterLoad();
        //}



        public static void Register() { Register(BarAndDockingController.Default); }

        public static void Register(BarAndDockingController controller)
        {
            Register(controller.PaintStyles);
        }
        public static void Register(BarManagerPaintStyleCollection styles)
        {
            foreach (BarManagerPaintStyle paintStyle in styles)
            {
                BarItemInfo list = paintStyle.ItemInfoCollection["BarCheckItem"];
                if (list != null && paintStyle.ItemInfoCollection["acBarCheckItem"] == null)
                {
                    paintStyle.ItemInfoCollection.Add(new BarItemInfo("acBarCheckItem", "acBarCheckItem", -1, typeof(acBarCheckItem), list.LinkType, list.ViewInfoType, list.LinkPainter, true, false));
                }
            }
        }

        #region IBaseViewControl 멤버

        private string _ResourceID = null;

        public string ResourceID
        {
            get
            {
                return _ResourceID;
            }
            set
            {
                _ResourceID = value;




            }
        }

        private bool _UseResourceID = false;

        public bool UseResourceID
        {
            get
            {
                return _UseResourceID;
            }
            set
            {
                _UseResourceID = value;
            }
        }

        private string _ToolTipID = null;

        public string ToolTipID
        {
            get
            {
                return _ToolTipID;
            }
            set
            {
                _ToolTipID = value;

            }
        }

        private bool _UseToolTipID = false;

        public bool UseToolTipID
        {
            get
            {
                return _UseToolTipID;
            }
            set
            {
                _UseToolTipID = value;



            }
        }

        #endregion
    }

    public class acBarSubItem : BarSubItem, IBaseViewControl
    {
        static acBarSubItem()
        {
            Register();


        }
        public void SetVisibility(bool ifEnabled, DevExpress.XtraBars.BarItemVisibility visibility)
        {
            if (this.Enabled == ifEnabled)
            {
                this.Visibility = visibility;
            }



        }
        /// <summary>
        /// Visibility 설정한다. Always 일경우 Enabled=true 되고 Never 일경우 Enabled=false 됨

        /// </summary>
        /// <param name="visibility"></param>
        public void SetVisibility(DevExpress.XtraBars.BarItemVisibility visibility)
        {
            this.Visibility = visibility;

            if (visibility == BarItemVisibility.Always)
            {
                this.Enabled = true;
            }
            else if (visibility == BarItemVisibility.Never)
            {
                this.Enabled = false;
            }
        }

        protected override void AfterLoad()
        {

            if (acInfo.IsRunTime == true)
            {

                //툴팁 설정
                if (this._UseToolTipID == true)
                {
                    if (!string.IsNullOrEmpty(this._ToolTipID))
                    {
                        if (acInfo.ToolTip.IsToolTip(this._ToolTipID))
                        {
                            this.SuperTip = acInfo.ToolTip.GetToolTip(this._ToolTipID);


                            //ToolTipTitleItem title = acInfo.ToolTip.GetToolTip(this._ToolTipID).Items[0] as ToolTipTitleItem;

                            //this.Caption = title.Text;
                        }

                    }
                }

                //리소스 설정
                else if (this._UseResourceID == true)
                {

                    this.Caption = acInfo.Resource.GetString(this.Caption, this._ResourceID);


                }



            }


            base.AfterLoad();
        }


        public static void Register() { Register(BarAndDockingController.Default); }

        public static void Register(BarAndDockingController controller)
        {
            Register(controller.PaintStyles);
        }
        public static void Register(BarManagerPaintStyleCollection styles)
        {
            foreach (BarManagerPaintStyle paintStyle in styles)
            {
                BarItemInfo list = paintStyle.ItemInfoCollection["BarSubItem"];
                if (list != null && paintStyle.ItemInfoCollection["acBarSubItem"] == null)
                {
                    paintStyle.ItemInfoCollection.Add(new BarItemInfo("acBarSubItem", "acBarSubItem", -1, typeof(acBarSubItem), list.LinkType, list.ViewInfoType, list.LinkPainter, true, false));
                }
            }
        }

        #region IBaseViewControl 멤버

        private string _ResourceID = null;

        public string ResourceID
        {
            get
            {
                return _ResourceID;
            }
            set
            {
                _ResourceID = value;




            }
        }

        private bool _UseResourceID = false;

        public bool UseResourceID
        {
            get
            {
                return _UseResourceID;
            }
            set
            {
                _UseResourceID = value;
            }
        }

        private string _ToolTipID = null;

        public string ToolTipID
        {
            get
            {
                return _ToolTipID;
            }
            set
            {
                _ToolTipID = value;

            }
        }

        private bool _UseToolTipID = false;

        public bool UseToolTipID
        {
            get
            {
                return _UseToolTipID;
            }
            set
            {
                _UseToolTipID = value;



            }
        }

        #endregion
    }

    public class acBarButtonItem : BarButtonItem, IBaseViewControl
    {
        public object RefObject = null;

        static acBarButtonItem()
        {
            Register();



        }

        protected override void OnClick(BarItemLink link)
        {
            if (this.Manager.Form.Visible == false)
            {
                return;
            }
            
            try
            {
                DataTable paramDT = new DataTable("RQSTDT");
                paramDT.Columns.Add("PLT_CODE", typeof(String));
                paramDT.Columns.Add("CLASS_NAME", typeof(String));
                paramDT.Columns.Add("BTN_CAPTION", typeof(String));
                paramDT.Columns.Add("BTN_NAME", typeof(String));

                DataRow paramRow = paramDT.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["CLASS_NAME"] = this.Manager.Form.Name;
                paramRow["BTN_CAPTION"] = this.Caption;
                paramRow["BTN_NAME"] = this.Name;
                paramDT.Rows.Add(paramRow);

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramDT);

                if (BizRun.QBizRun != null)
                    BizRun.QBizRun.ExecuteService(this,"CTRL", "ACTIVE_BUTTON_LOG", paramSet, "RQSTDT", "RSLTDT");
            }
            catch(Exception ex)
            { }

            base.OnClick(link);
        }

        public void RaiseOnClick()
        {
            this.OnClick(this.Links[0]);
        }



        /// <summary>
        /// Visibility 설정한다(ifEnabled 와 현재 Enabled와 같으면 설정됨)
        /// </summary>
        /// <param name="ifEnabled"></param>
        /// <param name="visibility"></param>
        public void SetVisibility(bool ifEnabled, DevExpress.XtraBars.BarItemVisibility visibility)
        {
            if (this.Enabled == ifEnabled)
            {
                this.Visibility = visibility;
            }



        }

        /// <summary>
        /// Visibility 설정한다. Always 일경우 Enabled=true 되고 Never 일경우 Enabled=false 됨

        /// </summary>
        /// <param name="visibility"></param>
        public void SetVisibility(DevExpress.XtraBars.BarItemVisibility visibility)
        {
            this.Visibility = visibility;

            if (visibility == BarItemVisibility.Always)
            {
                this.Enabled = true;
            }
            else if (visibility == BarItemVisibility.Never)
            {
                this.Enabled = false;
            }
        }


        private acBarManager.emBarShortCutType _ButtonShortCutType = acBarManager.emBarShortCutType.NONE;


        [Description("단축키형태 설정")]
        [DefaultValue(acBarManager.emBarShortCutType.NONE)]
        public acBarManager.emBarShortCutType ButtonShortCutType
        {
            get { return _ButtonShortCutType; }
            set { _ButtonShortCutType = value; }
        }

        //protected override void AfterLoad()
        //{

        //    //if (acInfo.IsRunTime == true)
        //    //{

        //    //    //툴팁 설정
        //    //    if (this._UseToolTipID == true)
        //    //    {
        //    //        if (!string.IsNullOrEmpty(this._ToolTipID))
        //    //        {
        //    //            if (acInfo.ToolTip.IsToolTip(this._ToolTipID))
        //    //            {
        //    //                this.SuperTip = acInfo.ToolTip.GetToolTip(this._ToolTipID);

        //    //                ToolTipTitleItem title = acInfo.ToolTip.GetToolTip(this._ToolTipID).Items[0] as ToolTipTitleItem;

        //    //                if (title != null)
        //    //                {
        //    //                    this.Caption = title.Text;
        //    //                }

        //    //            }

        //    //        }
        //    //    }
        //    //    //리소스 설정
        //    //    else if (this._UseResourceID == true)
        //    //    {

        //    //        if (acInfo.Resource != null)
        //    //        {

        //    //            this.Caption = acInfo.Resource.GetString(this.Caption, this._ResourceID);
        //    //        }

        //    //    }


        //    //    //단축키 설정
        //    //    //(this.Manager as acBarManager).SetShortCutType(this._ButtonShortCutType, this);



        //    //}


        //    base.AfterLoad();
        //}



        public static void Register() { Register(BarAndDockingController.Default); }

        public static void Register(BarAndDockingController controller)
        {
            Register(controller.PaintStyles);
        }
        public static void Register(BarManagerPaintStyleCollection styles)
        {
            foreach (BarManagerPaintStyle paintStyle in styles)
            {
                BarItemInfo list = paintStyle.ItemInfoCollection["BarButtonItem"];
                if (list != null && paintStyle.ItemInfoCollection["acBarButtonItem"] == null)
                {
                    paintStyle.ItemInfoCollection.Add(new BarItemInfo("acBarButtonItem", "acBarButtonItem", -1, typeof(acBarButtonItem), list.LinkType, list.ViewInfoType, list.LinkPainter, true, false));
                }
            }
        }

        #region IBaseViewControl 멤버

        private string _ResourceID = null;

        public string ResourceID
        {
            get
            {
                return _ResourceID;
            }
            set
            {
                _ResourceID = value;




            }
        }

        private bool _UseResourceID = false;

        public bool UseResourceID
        {
            get
            {
                return _UseResourceID;
            }
            set
            {
                _UseResourceID = value;
            }
        }

        private string _ToolTipID = null;

        public string ToolTipID
        {
            get
            {
                return _ToolTipID;
            }
            set
            {
                _ToolTipID = value;

            }
        }

        private bool _UseToolTipID = false;

        public bool UseToolTipID
        {
            get
            {
                return _UseToolTipID;
            }
            set
            {
                _UseToolTipID = value;



            }
        }

        #endregion
    }


    public class acBarStaticItem : BarStaticItem, IBaseViewControl
    {
        static acBarStaticItem()
        {
            Register();


        }

        protected override void AfterLoad()
        {
            //툴팁 설정
            if (acInfo.IsRunTime == true)
            {
                if (this._UseToolTipID == true)
                {
                    if (!string.IsNullOrEmpty(this._ToolTipID))
                    {
                        if (acInfo.ToolTip.IsToolTip(this._ToolTipID))
                        {
                            this.SuperTip = acInfo.ToolTip.GetToolTip(this._ToolTipID);


                            ToolTipTitleItem title = acInfo.ToolTip.GetToolTip(this._ToolTipID).Items[0] as ToolTipTitleItem;

                            if (title != null)
                            {
                                this.Caption = title.Text;
                            }
                        }

                    }
                }
            }


            //리소스 설정
            else if (this._UseResourceID == true)
            {

                this.Caption = acInfo.Resource.GetString(this.Caption, this._ResourceID);


            }




            base.AfterLoad();
        }


        public static void Register() { Register(BarAndDockingController.Default); }

        public static void Register(BarAndDockingController controller)
        {
            Register(controller.PaintStyles);
        }
        public static void Register(BarManagerPaintStyleCollection styles)
        {
            foreach (BarManagerPaintStyle paintStyle in styles)
            {
                BarItemInfo list = paintStyle.ItemInfoCollection["BarStaticItem"];
                if (list != null && paintStyle.ItemInfoCollection["acBarStaticItem"] == null)
                {
                    paintStyle.ItemInfoCollection.Add(new BarItemInfo("acBarStaticItem", "acBarStaticItem", -1, typeof(acBarStaticItem), list.LinkType, list.ViewInfoType, list.LinkPainter, true, false));
                }
            }
        }

        #region IBaseViewControl 멤버

        private string _ResourceID = null;

        public string ResourceID
        {
            get
            {
                return _ResourceID;
            }
            set
            {
                _ResourceID = value;
            }
        }

        private bool _UseResourceID = false;

        public bool UseResourceID
        {
            get
            {
                return _UseResourceID;
            }
            set
            {
                _UseResourceID = value;
            }
        }

        private string _ToolTipID = null;

        public string ToolTipID
        {
            get
            {
                return _ToolTipID;
            }
            set
            {
                _ToolTipID = value;

            }
        }

        private bool _UseToolTipID = false;

        public bool UseToolTipID
        {
            get
            {
                return _UseToolTipID;
            }
            set
            {
                _UseToolTipID = value;
            }
        }

        #endregion
    }


    public class acBarEditItem : BarEditItem, IBaseViewControl
    {
        static acBarEditItem()
        {
            Register();


        }


        protected override void AfterLoad()
        {

            if (acInfo.IsRunTime == true)
            {

                //툴팁 설정
                if (this._UseToolTipID == true)
                {
                    if (!string.IsNullOrEmpty(this._ToolTipID))
                    {
                        if (acInfo.ToolTip.IsToolTip(this._ToolTipID))
                        {
                            this.SuperTip = acInfo.ToolTip.GetToolTip(this._ToolTipID);

                            ToolTipTitleItem title = acInfo.ToolTip.GetToolTip(this._ToolTipID).Items[0] as ToolTipTitleItem;

                            if (title != null)
                            {
                                this.Caption = title.Text;
                            }

                        }

                    }
                }
                //리소스 설정
                else if (this._UseResourceID == true)
                {

                    this.Caption = acInfo.Resource.GetString(this.Caption, this._ResourceID);


                }




            }


            base.AfterLoad();
        }



        public static void Register() { Register(BarAndDockingController.Default); }

        public static void Register(BarAndDockingController controller)
        {
            Register(controller.PaintStyles);
        }
        public static void Register(BarManagerPaintStyleCollection styles)
        {
            foreach (BarManagerPaintStyle paintStyle in styles)
            {
                BarItemInfo list = paintStyle.ItemInfoCollection["acBarEditItem"];
                if (list != null && paintStyle.ItemInfoCollection["acBarEditItem"] == null)
                {
                    paintStyle.ItemInfoCollection.Add(new BarItemInfo("acBarEditItem", "acBarEditItem", -1, typeof(acBarEditItem), list.LinkType, list.ViewInfoType, list.LinkPainter, true, false));
                }
            }
        }

        #region IBaseViewControl 멤버

        private string _ResourceID = null;

        public string ResourceID
        {
            get
            {
                return _ResourceID;
            }
            set
            {
                _ResourceID = value;




            }
        }

        private bool _UseResourceID = false;

        public bool UseResourceID
        {
            get
            {
                return _UseResourceID;
            }
            set
            {
                _UseResourceID = value;
            }
        }

        private string _ToolTipID = null;

        public string ToolTipID
        {
            get
            {
                return _ToolTipID;
            }
            set
            {
                _ToolTipID = value;

            }
        }

        private bool _UseToolTipID = false;

        public bool UseToolTipID
        {
            get
            {
                return _UseToolTipID;
            }
            set
            {
                _UseToolTipID = value;



            }
        }

        #endregion
    }

}
