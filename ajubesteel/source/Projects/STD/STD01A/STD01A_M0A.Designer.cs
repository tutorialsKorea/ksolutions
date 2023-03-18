using ControlManager;
namespace STD
{
    partial class STD01A_M0A
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.acBarManager1 = new ControlManager.acBarManager(this.components);
            this.bar2 = new ControlManager.acBar();
            this.barItemSearch = new ControlManager.acBarButtonItem();
            this.acBarButtonItem12 = new ControlManager.acBarButtonItem();
            this.bar1 = new ControlManager.acBar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barItemHelp = new ControlManager.acBarButtonItem();
            this.acBarButtonItem1 = new ControlManager.acBarButtonItem();
            this.acBarButtonItem4 = new ControlManager.acBarButtonItem();
            this.acBarButtonItem5 = new ControlManager.acBarButtonItem();
            this.acBarButtonItem6 = new ControlManager.acBarButtonItem();
            this.acBarButtonItem7 = new ControlManager.acBarButtonItem();
            this.acBarButtonItem8 = new ControlManager.acBarButtonItem();
            this.acBarButtonItem9 = new ControlManager.acBarButtonItem();
            this.acBarSubItem3 = new ControlManager.acBarSubItem();
            this.acBarSubItem2 = new ControlManager.acBarSubItem();
            this.acBarSubItem4 = new ControlManager.acBarSubItem();
            this.acBarButtonItem10 = new ControlManager.acBarButtonItem();
            this.acBarSubItem5 = new ControlManager.acBarSubItem();
            this.acBarButtonItem11 = new ControlManager.acBarButtonItem();
            this.acBarButtonItem13 = new ControlManager.acBarButtonItem();
            this.acBarSubItem6 = new ControlManager.acBarSubItem();
            this.btnAddProcGrp = new ControlManager.acBarButtonItem();
            this.btnOpenProcGrp = new ControlManager.acBarButtonItem();
            this.btnDelProcGrp = new ControlManager.acBarButtonItem();
            this.popupSmall = new DevExpress.XtraBars.PopupMenu(this.components);
            this.acSplitContainerControl1 = new ControlManager.acSplitContainerControl();
            this.gcS = new ControlManager.acGridControl();
            this.gvS = new ControlManager.acGridView();
            this.gcMC = new ControlManager.acGridControl();
            this.gvMC = new ControlManager.acGridView();
            this.acSplitContainerControl2 = new ControlManager.acSplitContainerControl();
            this.acGridControl1 = new ControlManager.acGridControl();
            this.acGridView1 = new ControlManager.acGridView();
            this.popupGroup = new DevExpress.XtraBars.PopupMenu(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pnlScreenBase)).BeginInit();
            this.pnlScreenBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.acBarManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupSmall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acSplitContainerControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acSplitContainerControl1.Panel1)).BeginInit();
            this.acSplitContainerControl1.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.acSplitContainerControl1.Panel2)).BeginInit();
            this.acSplitContainerControl1.Panel2.SuspendLayout();
            this.acSplitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcMC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acSplitContainerControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acSplitContainerControl2.Panel1)).BeginInit();
            this.acSplitContainerControl2.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.acSplitContainerControl2.Panel2)).BeginInit();
            this.acSplitContainerControl2.Panel2.SuspendLayout();
            this.acSplitContainerControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.acGridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupGroup)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlScreenBase
            // 
            this.pnlScreenBase.Controls.Add(this.acSplitContainerControl2);
            this.pnlScreenBase.Location = new System.Drawing.Point(0, 34);
            this.pnlScreenBase.Size = new System.Drawing.Size(800, 546);
            // 
            // acBarManager1
            // 
            this.acBarManager1.AllowCustomization = false;
            this.acBarManager1.AllowQuickCustomization = false;
            this.acBarManager1.AllowShowToolbarsPopup = false;
            this.acBarManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2,
            this.bar1});
            this.acBarManager1.CloseButtonAffectAllTabs = false;
            this.acBarManager1.DockControls.Add(this.barDockControlTop);
            this.acBarManager1.DockControls.Add(this.barDockControlBottom);
            this.acBarManager1.DockControls.Add(this.barDockControlLeft);
            this.acBarManager1.DockControls.Add(this.barDockControlRight);
            this.acBarManager1.Form = this;
            this.acBarManager1.IsLoadDefaultLayout = true;
            this.acBarManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barItemSearch,
            this.barItemHelp,
            this.acBarButtonItem1,
            this.acBarButtonItem4,
            this.acBarButtonItem5,
            this.acBarButtonItem6,
            this.acBarButtonItem7,
            this.acBarButtonItem8,
            this.acBarButtonItem9,
            this.acBarSubItem3,
            this.acBarSubItem2,
            this.acBarSubItem4,
            this.acBarButtonItem10,
            this.acBarSubItem5,
            this.acBarButtonItem11,
            this.acBarButtonItem12,
            this.acBarButtonItem13,
            this.acBarSubItem6,
            this.btnOpenProcGrp,
            this.btnDelProcGrp,
            this.btnAddProcGrp});
            this.acBarManager1.MainMenu = this.bar2;
            this.acBarManager1.MaxItemId = 33;
            this.acBarManager1.StatusBar = this.bar1;
            // 
            // bar2
            // 
            this.bar2.BarItemHorzIndent = 10;
            this.bar2.BarItemVertIndent = 5;
            this.bar2.BarName = "도구상자";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barItemSearch, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.acBarButtonItem12, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar2.OptionsBar.AllowQuickCustomization = false;
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.ResourceID = "I7LE433K";
            this.bar2.Text = "도구상자";
            this.bar2.ToolTipID = null;
            this.bar2.UseResourceID = true;
            this.bar2.UseToolTipID = false;
            // 
            // barItemSearch
            // 
            this.barItemSearch.ButtonShortCutType = ControlManager.acBarManager.emBarShortCutType.SEARCH;
            this.barItemSearch.Caption = "조회";
            this.barItemSearch.Id = 3;
            this.barItemSearch.ImageOptions.Image = global::STD.Resource.system_search_2x;
            this.barItemSearch.Name = "barItemSearch";
            this.barItemSearch.ResourceID = null;
            this.barItemSearch.ToolTipID = "1UMVQFSB";
            this.barItemSearch.UseResourceID = false;
            this.barItemSearch.UseToolTipID = true;
            this.barItemSearch.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barItemSearch_ItemClick);
            // 
            // acBarButtonItem12
            // 
            this.acBarButtonItem12.ButtonShortCutType = ControlManager.acBarManager.emBarShortCutType.METHOD_1;
            this.acBarButtonItem12.Caption = "엑셀 데이터 불러오기";
            this.acBarButtonItem12.Id = 27;
            this.acBarButtonItem12.ImageOptions.Image = global::STD.Resource.excel_import_2x;
            this.acBarButtonItem12.Name = "acBarButtonItem12";
            this.acBarButtonItem12.ResourceID = null;
            this.acBarButtonItem12.ToolTipID = "PGC6U30Z";
            this.acBarButtonItem12.UseResourceID = false;
            this.acBarButtonItem12.UseToolTipID = true;
            this.acBarButtonItem12.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.acBarButtonItem12.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.acBarButtonItem12_ItemClick);
            // 
            // bar1
            // 
            this.bar1.BarItemHorzIndent = 10;
            this.bar1.BarItemVertIndent = 5;
            this.bar1.BarName = "Custom 3";
            this.bar1.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar1.OptionsBar.AllowQuickCustomization = false;
            this.bar1.OptionsBar.DrawDragBorder = false;
            this.bar1.OptionsBar.UseWholeRow = true;
            this.bar1.ResourceID = null;
            this.bar1.Text = "Custom 3";
            this.bar1.ToolTipID = null;
            this.bar1.UseResourceID = false;
            this.bar1.UseToolTipID = false;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.acBarManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(800, 34);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 580);
            this.barDockControlBottom.Manager = this.acBarManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(800, 20);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 34);
            this.barDockControlLeft.Manager = this.acBarManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 546);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(800, 34);
            this.barDockControlRight.Manager = this.acBarManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 546);
            // 
            // barItemHelp
            // 
            this.barItemHelp.ButtonShortCutType = ControlManager.acBarManager.emBarShortCutType.HELP;
            this.barItemHelp.Caption = "도움말";
            this.barItemHelp.Id = 6;
            this.barItemHelp.ImageOptions.Image = global::STD.Resource.help_browser_2x;
            this.barItemHelp.Name = "barItemHelp";
            this.barItemHelp.ResourceID = null;
            this.barItemHelp.ToolTipID = "46ZIMD99";
            this.barItemHelp.UseResourceID = false;
            this.barItemHelp.UseToolTipID = true;
            this.barItemHelp.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barItemHelp_ItemClick);
            // 
            // acBarButtonItem1
            // 
            this.acBarButtonItem1.Caption = "대일정 편집기";
            this.acBarButtonItem1.Id = 7;
            this.acBarButtonItem1.Name = "acBarButtonItem1";
            this.acBarButtonItem1.ResourceID = "1SHNKCGP";
            this.acBarButtonItem1.ToolTipID = null;
            this.acBarButtonItem1.UseResourceID = true;
            this.acBarButtonItem1.UseToolTipID = false;
            // 
            // acBarButtonItem4
            // 
            this.acBarButtonItem4.Caption = "중일정 편집기";
            this.acBarButtonItem4.Id = 10;
            this.acBarButtonItem4.Name = "acBarButtonItem4";
            this.acBarButtonItem4.ResourceID = "SN5QMI9V";
            this.acBarButtonItem4.ToolTipID = null;
            this.acBarButtonItem4.UseResourceID = true;
            this.acBarButtonItem4.UseToolTipID = false;
            // 
            // acBarButtonItem5
            // 
            this.acBarButtonItem5.Caption = "열기";
            this.acBarButtonItem5.Id = 11;
            this.acBarButtonItem5.ImageOptions.Image = global::STD.Resource.document_open_2x;
            this.acBarButtonItem5.Name = "acBarButtonItem5";
            this.acBarButtonItem5.ResourceID = "5E5CQSN3";
            this.acBarButtonItem5.ToolTipID = null;
            this.acBarButtonItem5.UseResourceID = true;
            this.acBarButtonItem5.UseToolTipID = false;
            // 
            // acBarButtonItem6
            // 
            this.acBarButtonItem6.Caption = "삭제";
            this.acBarButtonItem6.Id = 12;
            this.acBarButtonItem6.ImageOptions.Image = global::STD.Resource.edit_delete_2x;
            this.acBarButtonItem6.Name = "acBarButtonItem6";
            this.acBarButtonItem6.ResourceID = "Y1JCF012";
            this.acBarButtonItem6.ToolTipID = null;
            this.acBarButtonItem6.UseResourceID = true;
            this.acBarButtonItem6.UseToolTipID = false;
            // 
            // acBarButtonItem7
            // 
            this.acBarButtonItem7.Caption = "공정 편집기";
            this.acBarButtonItem7.Id = 13;
            this.acBarButtonItem7.Name = "acBarButtonItem7";
            this.acBarButtonItem7.ResourceID = "7F8233K9";
            this.acBarButtonItem7.ToolTipID = null;
            this.acBarButtonItem7.UseResourceID = false;
            this.acBarButtonItem7.UseToolTipID = false;
            this.acBarButtonItem7.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.acBarButtonItem7_ItemClick);
            // 
            // acBarButtonItem8
            // 
            this.acBarButtonItem8.Caption = "열기";
            this.acBarButtonItem8.Id = 14;
            this.acBarButtonItem8.ImageOptions.Image = global::STD.Resource.document_open_2x;
            this.acBarButtonItem8.Name = "acBarButtonItem8";
            this.acBarButtonItem8.ResourceID = "5E5CQSN3";
            this.acBarButtonItem8.ToolTipID = null;
            this.acBarButtonItem8.UseResourceID = true;
            this.acBarButtonItem8.UseToolTipID = false;
            this.acBarButtonItem8.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.acBarButtonItem8_ItemClick);
            // 
            // acBarButtonItem9
            // 
            this.acBarButtonItem9.Caption = "삭제";
            this.acBarButtonItem9.Id = 15;
            this.acBarButtonItem9.ImageOptions.Image = global::STD.Resource.edit_delete_2x;
            this.acBarButtonItem9.Name = "acBarButtonItem9";
            this.acBarButtonItem9.ResourceID = "Y1JCF012";
            this.acBarButtonItem9.ToolTipID = null;
            this.acBarButtonItem9.UseResourceID = true;
            this.acBarButtonItem9.UseToolTipID = false;
            this.acBarButtonItem9.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.acBarButtonItem9_ItemClick);
            // 
            // acBarSubItem3
            // 
            this.acBarSubItem3.Caption = "새로 만들기";
            this.acBarSubItem3.Id = 20;
            this.acBarSubItem3.ImageOptions.Image = global::STD.Resource.document_new_2x;
            this.acBarSubItem3.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.acBarButtonItem4)});
            this.acBarSubItem3.Name = "acBarSubItem3";
            this.acBarSubItem3.ResourceID = "ZN2APG9L";
            this.acBarSubItem3.ToolTipID = null;
            this.acBarSubItem3.UseResourceID = true;
            this.acBarSubItem3.UseToolTipID = false;
            // 
            // acBarSubItem2
            // 
            this.acBarSubItem2.Caption = "새로 만들기";
            this.acBarSubItem2.Id = 21;
            this.acBarSubItem2.ImageOptions.Image = global::STD.Resource.document_new_2x;
            this.acBarSubItem2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.acBarButtonItem7)});
            this.acBarSubItem2.Name = "acBarSubItem2";
            this.acBarSubItem2.ResourceID = "ZN2APG9L";
            this.acBarSubItem2.ToolTipID = null;
            this.acBarSubItem2.UseResourceID = true;
            this.acBarSubItem2.UseToolTipID = false;
            // 
            // acBarSubItem4
            // 
            this.acBarSubItem4.Caption = "기능";
            this.acBarSubItem4.Id = 23;
            this.acBarSubItem4.ImageOptions.Image = global::STD.Resource.lightning_2x;
            this.acBarSubItem4.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.acBarButtonItem10)});
            this.acBarSubItem4.Name = "acBarSubItem4";
            this.acBarSubItem4.ResourceID = "QS1MTC9B";
            this.acBarSubItem4.ToolTipID = null;
            this.acBarSubItem4.UseResourceID = true;
            this.acBarSubItem4.UseToolTipID = false;
            // 
            // acBarButtonItem10
            // 
            this.acBarButtonItem10.Caption = "중일정 이동";
            this.acBarButtonItem10.Id = 24;
            this.acBarButtonItem10.Name = "acBarButtonItem10";
            this.acBarButtonItem10.ResourceID = "LYKSOXEG";
            this.acBarButtonItem10.ToolTipID = null;
            this.acBarButtonItem10.UseResourceID = true;
            this.acBarButtonItem10.UseToolTipID = false;
            // 
            // acBarSubItem5
            // 
            this.acBarSubItem5.Caption = "기능";
            this.acBarSubItem5.Id = 25;
            this.acBarSubItem5.ImageOptions.Image = global::STD.Resource.lightning_2x;
            this.acBarSubItem5.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.acBarButtonItem11)});
            this.acBarSubItem5.Name = "acBarSubItem5";
            this.acBarSubItem5.ResourceID = "QS1MTC9B";
            this.acBarSubItem5.ToolTipID = null;
            this.acBarSubItem5.UseResourceID = true;
            this.acBarSubItem5.UseToolTipID = false;
            // 
            // acBarButtonItem11
            // 
            this.acBarButtonItem11.Caption = "소일정 이동";
            this.acBarButtonItem11.Id = 26;
            this.acBarButtonItem11.Name = "acBarButtonItem11";
            this.acBarButtonItem11.ResourceID = "PQDFEYWH";
            this.acBarButtonItem11.ToolTipID = null;
            this.acBarButtonItem11.UseResourceID = true;
            this.acBarButtonItem11.UseToolTipID = false;
            this.acBarButtonItem11.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.acBarButtonItem11_ItemClick);
            // 
            // acBarButtonItem13
            // 
            this.acBarButtonItem13.Caption = "새로만들기";
            this.acBarButtonItem13.Id = 28;
            this.acBarButtonItem13.Name = "acBarButtonItem13";
            this.acBarButtonItem13.ResourceID = null;
            this.acBarButtonItem13.ToolTipID = null;
            this.acBarButtonItem13.UseResourceID = false;
            this.acBarButtonItem13.UseToolTipID = false;
            // 
            // acBarSubItem6
            // 
            this.acBarSubItem6.Caption = "새로 만들기";
            this.acBarSubItem6.Id = 29;
            this.acBarSubItem6.ImageOptions.Image = global::STD.Resource.document_new_2x;
            this.acBarSubItem6.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnAddProcGrp)});
            this.acBarSubItem6.Name = "acBarSubItem6";
            this.acBarSubItem6.ResourceID = null;
            this.acBarSubItem6.ToolTipID = null;
            this.acBarSubItem6.UseResourceID = false;
            this.acBarSubItem6.UseToolTipID = false;
            // 
            // btnAddProcGrp
            // 
            this.btnAddProcGrp.Caption = "공정그룹 편집기";
            this.btnAddProcGrp.Id = 32;
            this.btnAddProcGrp.Name = "btnAddProcGrp";
            this.btnAddProcGrp.ResourceID = null;
            this.btnAddProcGrp.ToolTipID = null;
            this.btnAddProcGrp.UseResourceID = false;
            this.btnAddProcGrp.UseToolTipID = false;
            this.btnAddProcGrp.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAddProcGrp_ItemClick);
            // 
            // btnOpenProcGrp
            // 
            this.btnOpenProcGrp.Caption = "열기";
            this.btnOpenProcGrp.Id = 30;
            this.btnOpenProcGrp.ImageOptions.Image = global::STD.Resource.document_open_2x;
            this.btnOpenProcGrp.Name = "btnOpenProcGrp";
            this.btnOpenProcGrp.ResourceID = null;
            this.btnOpenProcGrp.ToolTipID = null;
            this.btnOpenProcGrp.UseResourceID = false;
            this.btnOpenProcGrp.UseToolTipID = false;
            this.btnOpenProcGrp.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnOpenProcGrp_ItemClick);
            // 
            // btnDelProcGrp
            // 
            this.btnDelProcGrp.Caption = "삭제";
            this.btnDelProcGrp.Id = 31;
            this.btnDelProcGrp.ImageOptions.Image = global::STD.Resource.edit_delete_2x;
            this.btnDelProcGrp.Name = "btnDelProcGrp";
            this.btnDelProcGrp.ResourceID = null;
            this.btnDelProcGrp.ToolTipID = null;
            this.btnDelProcGrp.UseResourceID = false;
            this.btnDelProcGrp.UseToolTipID = false;
            this.btnDelProcGrp.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDelProcGrp_ItemClick);
            // 
            // popupSmall
            // 
            this.popupSmall.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.acBarSubItem2),
            new DevExpress.XtraBars.LinkPersistInfo(this.acBarSubItem5),
            new DevExpress.XtraBars.LinkPersistInfo(this.acBarButtonItem8),
            new DevExpress.XtraBars.LinkPersistInfo(this.acBarButtonItem9)});
            this.popupSmall.Manager = this.acBarManager1;
            this.popupSmall.Name = "popupSmall";
            // 
            // acSplitContainerControl1
            // 
            this.acSplitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.acSplitContainerControl1.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.None;
            this.acSplitContainerControl1.Horizontal = false;
            this.acSplitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.acSplitContainerControl1.Name = "acSplitContainerControl1";
            // 
            // acSplitContainerControl1.Panel1
            // 
            this.acSplitContainerControl1.Panel1.Controls.Add(this.gcS);
            this.acSplitContainerControl1.Panel1.Text = "Panel1";
            // 
            // acSplitContainerControl1.Panel2
            // 
            this.acSplitContainerControl1.Panel2.Controls.Add(this.gcMC);
            this.acSplitContainerControl1.Panel2.Text = "Panel2";
            this.acSplitContainerControl1.ParentControl = null;
            this.acSplitContainerControl1.Size = new System.Drawing.Size(800, 546);
            this.acSplitContainerControl1.SplitterPosition = 274;
            this.acSplitContainerControl1.TabIndex = 0;
            this.acSplitContainerControl1.Text = "acSplitContainerControl1";
            // 
            // gcS
            // 
            this.gcS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcS.Location = new System.Drawing.Point(0, 0);
            this.gcS.MainView = this.gvS;
            this.gcS.MenuManager = this.acBarManager1;
            this.gcS.Name = "gcS";
            this.gcS.Size = new System.Drawing.Size(800, 274);
            this.gcS.TabIndex = 0;
            this.gcS.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvS});
            // 
            // gvS
            // 
            this.gvS.ColumnPanelRowHeight = 25;
            this.gvS.GridControl = this.gcS;
            this.gvS.IsUserStyle = false;
            this.gvS.Name = "gvS";
            this.gvS.NoApplyEditableCellColor = false;
            this.gvS.OptionsBehavior.AutoPopulateColumns = false;
            this.gvS.OptionsLayout.Columns.StoreAllOptions = true;
            this.gvS.OptionsLayout.StoreAllOptions = true;
            this.gvS.OptionsView.RowAutoHeight = true;
            this.gvS.OptionsView.ShowGroupPanel = false;
            this.gvS.OptionsView.ShowIndicator = false;
            this.gvS.ParentControl = this;
            this.gvS.RowHeight = 30;
            this.gvS.SaveFileName = null;
            // 
            // gcMC
            // 
            this.gcMC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcMC.Location = new System.Drawing.Point(0, 0);
            this.gcMC.MainView = this.gvMC;
            this.gcMC.MenuManager = this.acBarManager1;
            this.gcMC.Name = "gcMC";
            this.gcMC.Size = new System.Drawing.Size(800, 262);
            this.gcMC.TabIndex = 0;
            this.gcMC.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvMC});
            // 
            // gvMC
            // 
            this.gvMC.ColumnPanelRowHeight = 25;
            this.gvMC.GridControl = this.gcMC;
            this.gvMC.IsUserStyle = false;
            this.gvMC.Name = "gvMC";
            this.gvMC.NoApplyEditableCellColor = false;
            this.gvMC.OptionsBehavior.AutoPopulateColumns = false;
            this.gvMC.OptionsLayout.Columns.StoreAllOptions = true;
            this.gvMC.OptionsLayout.StoreAllOptions = true;
            this.gvMC.OptionsView.RowAutoHeight = true;
            this.gvMC.OptionsView.ShowGroupPanel = false;
            this.gvMC.OptionsView.ShowIndicator = false;
            this.gvMC.ParentControl = this;
            this.gvMC.RowHeight = 30;
            this.gvMC.SaveFileName = null;
            // 
            // acSplitContainerControl2
            // 
            this.acSplitContainerControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.acSplitContainerControl2.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.None;
            this.acSplitContainerControl2.Location = new System.Drawing.Point(0, 0);
            this.acSplitContainerControl2.Name = "acSplitContainerControl2";
            // 
            // acSplitContainerControl2.Panel1
            // 
            this.acSplitContainerControl2.Panel1.Controls.Add(this.acGridControl1);
            this.acSplitContainerControl2.Panel1.Text = "Panel1";
            // 
            // acSplitContainerControl2.Panel2
            // 
            this.acSplitContainerControl2.Panel2.Controls.Add(this.acSplitContainerControl1);
            this.acSplitContainerControl2.Panel2.Text = "Panel2";
            this.acSplitContainerControl2.PanelVisibility = DevExpress.XtraEditors.SplitPanelVisibility.Panel2;
            this.acSplitContainerControl2.ParentControl = null;
            this.acSplitContainerControl2.Size = new System.Drawing.Size(800, 546);
            this.acSplitContainerControl2.SplitterPosition = 371;
            this.acSplitContainerControl2.TabIndex = 1;
            this.acSplitContainerControl2.Text = "acSplitContainerControl2";
            // 
            // acGridControl1
            // 
            this.acGridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.acGridControl1.Location = new System.Drawing.Point(0, 0);
            this.acGridControl1.MainView = this.acGridView1;
            this.acGridControl1.MenuManager = this.acBarManager1;
            this.acGridControl1.Name = "acGridControl1";
            this.acGridControl1.Size = new System.Drawing.Size(0, 0);
            this.acGridControl1.TabIndex = 0;
            this.acGridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.acGridView1});
            // 
            // acGridView1
            // 
            this.acGridView1.ColumnPanelRowHeight = 25;
            this.acGridView1.GridControl = this.acGridControl1;
            this.acGridView1.IsUserStyle = false;
            this.acGridView1.Name = "acGridView1";
            this.acGridView1.NoApplyEditableCellColor = false;
            this.acGridView1.OptionsBehavior.AutoPopulateColumns = false;
            this.acGridView1.OptionsLayout.Columns.StoreAllOptions = true;
            this.acGridView1.OptionsLayout.StoreAllOptions = true;
            this.acGridView1.OptionsView.RowAutoHeight = true;
            this.acGridView1.OptionsView.ShowGroupPanel = false;
            this.acGridView1.OptionsView.ShowIndicator = false;
            this.acGridView1.ParentControl = this;
            this.acGridView1.RowHeight = 30;
            this.acGridView1.SaveFileName = null;
            // 
            // popupGroup
            // 
            this.popupGroup.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.acBarSubItem6),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnOpenProcGrp),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnDelProcGrp)});
            this.popupGroup.Manager = this.acBarManager1;
            this.popupGroup.Name = "popupGroup";
            // 
            // STD01A_M0A
            // 
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "STD01A_M0A";
            this.Controls.SetChildIndex(this.barDockControlTop, 0);
            this.Controls.SetChildIndex(this.barDockControlBottom, 0);
            this.Controls.SetChildIndex(this.barDockControlRight, 0);
            this.Controls.SetChildIndex(this.barDockControlLeft, 0);
            this.Controls.SetChildIndex(this.pnlScreenBase, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pnlScreenBase)).EndInit();
            this.pnlScreenBase.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.acBarManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupSmall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acSplitContainerControl1.Panel1)).EndInit();
            this.acSplitContainerControl1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.acSplitContainerControl1.Panel2)).EndInit();
            this.acSplitContainerControl1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.acSplitContainerControl1)).EndInit();
            this.acSplitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcMC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acSplitContainerControl2.Panel1)).EndInit();
            this.acSplitContainerControl2.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.acSplitContainerControl2.Panel2)).EndInit();
            this.acSplitContainerControl2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.acSplitContainerControl2)).EndInit();
            this.acSplitContainerControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.acGridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupGroup)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ControlManager.acBarManager acBarManager1;
        private ControlManager.acBar bar2;

        


        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        
        
        private ControlManager.acBarButtonItem barItemSearch;
        private ControlManager.acBarButtonItem barItemHelp;
        private ControlManager.acBarButtonItem acBarButtonItem1;
        private ControlManager.acBarButtonItem acBarButtonItem4;
        private ControlManager.acBarButtonItem acBarButtonItem5;
        private ControlManager.acBarButtonItem acBarButtonItem6;
        private ControlManager.acBarButtonItem acBarButtonItem7;
        private ControlManager.acBarButtonItem acBarButtonItem8;
        private ControlManager.acBarButtonItem acBarButtonItem9;
        private DevExpress.XtraBars.PopupMenu popupSmall;
        private ControlManager.acBarSubItem acBarSubItem3;
        private ControlManager.acBarSubItem acBarSubItem2;
        private ControlManager.acBar bar1;
        private acBarSubItem acBarSubItem4;
        private acBarButtonItem acBarButtonItem10;
        private acBarSubItem acBarSubItem5;
        private acBarButtonItem acBarButtonItem11;
        private acBarButtonItem acBarButtonItem12;
        private acSplitContainerControl acSplitContainerControl1;
        private acGridControl gcS;
        private acGridView gvS;
        private acGridControl gcMC;
        private acGridView gvMC;
        private acSplitContainerControl acSplitContainerControl2;
        private acGridControl acGridControl1;
        private acGridView acGridView1;
        private acBarButtonItem acBarButtonItem13;
        private acBarSubItem acBarSubItem6;
        private acBarButtonItem btnOpenProcGrp;
        private acBarButtonItem btnDelProcGrp;
        private DevExpress.XtraBars.PopupMenu popupGroup;
        private acBarButtonItem btnAddProcGrp;



    }
}
