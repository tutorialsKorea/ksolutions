namespace SYS
{
    partial class SYS32A_M0A
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

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.acGridControl1 = new ControlManager.acGridControl();
            this.acGridView1 = new ControlManager.acGridView();
            this.acBarManager1 = new ControlManager.acBarManager(this.components);
            this.bar2 = new ControlManager.acBar();
            this.barItemSearch = new ControlManager.acBarButtonItem();
            this.barItemSave = new ControlManager.acBarButtonItem();
            this.acBarButtonItem3 = new ControlManager.acBarButtonItem();
            this.acBarButtonItem5 = new ControlManager.acBarButtonItem();
            this.acBarButtonItem4 = new ControlManager.acBarButtonItem();
            this.bar3 = new ControlManager.acBar();
            this.statusBarLog = new ControlManager.acBarStaticItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.acBarButtonItem1 = new ControlManager.acBarButtonItem();
            this.acBarButtonItem2 = new ControlManager.acBarButtonItem();
            this.acBarSubItem1 = new ControlManager.acBarSubItem();
            this.acLayoutControl1 = new ControlManager.acLayoutControl();
            this.acTextEdit2 = new ControlManager.acTextEdit();
            this.acTextEdit1 = new ControlManager.acTextEdit();
            this.layoutControlGroup1 = new ControlManager.acLayoutControlGroup();
            this.acLayoutControlItem1 = new ControlManager.acLayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.acLayoutControlItem2 = new ControlManager.acLayoutControlItem();
            this.popupMenu1 = new DevExpress.XtraBars.PopupMenu(this.components);
            this.acGroupControl1 = new ControlManager.acGroupControl();
            this.acSplitContainerControl1 = new ControlManager.acSplitContainerControl();
            ((System.ComponentModel.ISupportInitialize)(this.pnlScreenBase)).BeginInit();
            this.pnlScreenBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.acGridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acBarManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControl1)).BeginInit();
            this.acLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.acTextEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acTextEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acGroupControl1)).BeginInit();
            this.acGroupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.acSplitContainerControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acSplitContainerControl1.Panel1)).BeginInit();
            this.acSplitContainerControl1.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.acSplitContainerControl1.Panel2)).BeginInit();
            this.acSplitContainerControl1.Panel2.SuspendLayout();
            this.acSplitContainerControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlScreenBase
            // 
            this.pnlScreenBase.Controls.Add(this.acSplitContainerControl1);
            this.pnlScreenBase.Location = new System.Drawing.Point(0, 36);
            this.pnlScreenBase.Size = new System.Drawing.Size(773, 577);
            // 
            // acGridControl1
            // 
            this.acGridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.acGridControl1.Location = new System.Drawing.Point(0, 0);
            this.acGridControl1.MainView = this.acGridView1;
            this.acGridControl1.Name = "acGridControl1";
            this.acGridControl1.Size = new System.Drawing.Size(773, 513);
            this.acGridControl1.TabIndex = 5;
            this.acGridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.acGridView1});
            // 
            // acGridView1
            // 
            this.acGridView1.ColumnPanelRowHeight = 25;
            this.acGridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.acGridView1.GridControl = this.acGridControl1;
            this.acGridView1.IsUserStyle = false;
            this.acGridView1.Name = "acGridView1";
            this.acGridView1.NoApplyEditableCellColor = false;
            this.acGridView1.OptionsBehavior.AutoPopulateColumns = false;
            this.acGridView1.OptionsLayout.Columns.StoreAllOptions = true;
            this.acGridView1.OptionsLayout.StoreAllOptions = true;
            this.acGridView1.OptionsView.ColumnAutoWidth = false;
            this.acGridView1.OptionsView.RowAutoHeight = true;
            this.acGridView1.OptionsView.ShowGroupPanel = false;
            this.acGridView1.OptionsView.ShowIndicator = false;
            this.acGridView1.ParentControl = this;
            this.acGridView1.RowHeight = 25;
            this.acGridView1.SaveFileName = null;
            // 
            // acBarManager1
            // 
            this.acBarManager1.AllowCustomization = false;
            this.acBarManager1.AllowQuickCustomization = false;
            this.acBarManager1.AllowShowToolbarsPopup = false;
            this.acBarManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2,
            this.bar3});
            this.acBarManager1.CloseButtonAffectAllTabs = false;
            this.acBarManager1.DockControls.Add(this.barDockControlTop);
            this.acBarManager1.DockControls.Add(this.barDockControlBottom);
            this.acBarManager1.DockControls.Add(this.barDockControlLeft);
            this.acBarManager1.DockControls.Add(this.barDockControlRight);
            this.acBarManager1.Form = this;
            this.acBarManager1.IsLoadDefaultLayout = true;
            this.acBarManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barItemSearch,
            this.barItemSave,
            this.statusBarLog,
            this.acBarButtonItem1,
            this.acBarButtonItem2,
            this.acBarSubItem1,
            this.acBarButtonItem3,
            this.acBarButtonItem4,
            this.acBarButtonItem5});
            this.acBarManager1.MainMenu = this.bar2;
            this.acBarManager1.MaxItemId = 15;
            this.acBarManager1.StatusBar = this.bar3;
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
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barItemSave, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.acBarButtonItem3, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.acBarButtonItem5, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.acBarButtonItem4, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar2.OptionsBar.AllowQuickCustomization = false;
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
            this.barItemSearch.Id = 0;
            this.barItemSearch.ImageOptions.Image = global::SYS.Resource.system_search_2x;
            this.barItemSearch.Name = "barItemSearch";
            this.barItemSearch.ResourceID = null;
            this.barItemSearch.ToolTipID = "1UMVQFSB";
            this.barItemSearch.UseResourceID = false;
            this.barItemSearch.UseToolTipID = true;
            this.barItemSearch.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barItemSearch_ItemClick);
            // 
            // barItemSave
            // 
            this.barItemSave.ButtonShortCutType = ControlManager.acBarManager.emBarShortCutType.SAVE;
            this.barItemSave.Caption = "저장";
            this.barItemSave.Id = 1;
            this.barItemSave.ImageOptions.Image = global::SYS.Resource.document_save_2x;
            this.barItemSave.Name = "barItemSave";
            this.barItemSave.ResourceID = null;
            this.barItemSave.ToolTipID = "4UY7EZBZ";
            this.barItemSave.UseResourceID = false;
            this.barItemSave.UseToolTipID = true;
            this.barItemSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barItemSave_ItemClick);
            // 
            // acBarButtonItem3
            // 
            this.acBarButtonItem3.ButtonShortCutType = ControlManager.acBarManager.emBarShortCutType.METHOD_1;
            this.acBarButtonItem3.Caption = "리소스 일괄변경";
            this.acBarButtonItem3.Id = 11;
            this.acBarButtonItem3.ImageOptions.Image = global::SYS.Resource.resource_all_change_2x;
            this.acBarButtonItem3.Name = "acBarButtonItem3";
            this.acBarButtonItem3.ResourceID = null;
            this.acBarButtonItem3.ToolTipID = "K9VAZG2W";
            this.acBarButtonItem3.UseResourceID = false;
            this.acBarButtonItem3.UseToolTipID = true;
            this.acBarButtonItem3.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.acBarButtonItem3_ItemClick);
            // 
            // acBarButtonItem5
            // 
            this.acBarButtonItem5.ButtonShortCutType = ControlManager.acBarManager.emBarShortCutType.METHOD_2;
            this.acBarButtonItem5.Caption = "다국어 복사";
            this.acBarButtonItem5.Id = 13;
            this.acBarButtonItem5.ImageOptions.Image = global::SYS.Resource.preferences_desktop_font_2x;
            this.acBarButtonItem5.Name = "acBarButtonItem5";
            this.acBarButtonItem5.ResourceID = "";
            this.acBarButtonItem5.ToolTipID = "ZYZNWC5X";
            this.acBarButtonItem5.UseResourceID = false;
            this.acBarButtonItem5.UseToolTipID = true;
            this.acBarButtonItem5.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.acBarButtonItem5_ItemClick);
            // 
            // acBarButtonItem4
            // 
            this.acBarButtonItem4.ButtonShortCutType = ControlManager.acBarManager.emBarShortCutType.METHOD_3;
            this.acBarButtonItem4.Caption = "엑셀 데이터 불러오기";
            this.acBarButtonItem4.Id = 12;
            this.acBarButtonItem4.ImageOptions.Image = global::SYS.Resource.excel_import_2x;
            this.acBarButtonItem4.Name = "acBarButtonItem4";
            this.acBarButtonItem4.ResourceID = null;
            this.acBarButtonItem4.ToolTipID = "PGC6U30Z";
            this.acBarButtonItem4.UseResourceID = false;
            this.acBarButtonItem4.UseToolTipID = true;
            this.acBarButtonItem4.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.acBarButtonItem4_ItemClick);
            // 
            // bar3
            // 
            this.bar3.BarItemHorzIndent = 10;
            this.bar3.BarItemVertIndent = 5;
            this.bar3.BarName = "Status bar";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.statusBarLog, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.ResourceID = null;
            this.bar3.Text = "Status bar";
            this.bar3.ToolTipID = null;
            this.bar3.UseResourceID = false;
            this.bar3.UseToolTipID = false;
            // 
            // statusBarLog
            // 
            this.statusBarLog.Border = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.statusBarLog.Id = 4;
            this.statusBarLog.ImageOptions.Image = global::SYS.Resource.internet_group_chat_1x;
            this.statusBarLog.Name = "statusBarLog";
            this.statusBarLog.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.statusBarLog.ResourceID = null;
            this.statusBarLog.ToolTipID = null;
            this.statusBarLog.UseResourceID = false;
            this.statusBarLog.UseToolTipID = false;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.acBarManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(773, 36);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 613);
            this.barDockControlBottom.Manager = this.acBarManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(773, 30);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 36);
            this.barDockControlLeft.Manager = this.acBarManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 577);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(773, 36);
            this.barDockControlRight.Manager = this.acBarManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 577);
            // 
            // acBarButtonItem1
            // 
            this.acBarButtonItem1.Caption = "리소스 편집기";
            this.acBarButtonItem1.Id = 8;
            this.acBarButtonItem1.Name = "acBarButtonItem1";
            this.acBarButtonItem1.ResourceID = "XR3BOZ2V";
            this.acBarButtonItem1.ToolTipID = null;
            this.acBarButtonItem1.UseResourceID = true;
            this.acBarButtonItem1.UseToolTipID = false;
            this.acBarButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.acBarButtonItem1_ItemClick);
            // 
            // acBarButtonItem2
            // 
            this.acBarButtonItem2.Caption = "삭제";
            this.acBarButtonItem2.Id = 9;
            this.acBarButtonItem2.ImageOptions.Image = global::SYS.Resource.edit_delete_2x;
            this.acBarButtonItem2.Name = "acBarButtonItem2";
            this.acBarButtonItem2.ResourceID = "Y1JCF012";
            this.acBarButtonItem2.ToolTipID = null;
            this.acBarButtonItem2.UseResourceID = true;
            this.acBarButtonItem2.UseToolTipID = false;
            this.acBarButtonItem2.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.acBarButtonItem2_ItemClick);
            // 
            // acBarSubItem1
            // 
            this.acBarSubItem1.Caption = "새로 만들기";
            this.acBarSubItem1.Id = 10;
            this.acBarSubItem1.ImageOptions.Image = global::SYS.Resource.document_new_2x;
            this.acBarSubItem1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.acBarButtonItem1)});
            this.acBarSubItem1.Name = "acBarSubItem1";
            this.acBarSubItem1.ResourceID = "ZN2APG9L";
            this.acBarSubItem1.ToolTipID = null;
            this.acBarSubItem1.UseResourceID = true;
            this.acBarSubItem1.UseToolTipID = false;
            // 
            // acLayoutControl1
            // 
            this.acLayoutControl1.AllowCustomization = false;
            this.acLayoutControl1.AutoScroll = false;
            this.acLayoutControl1.ContainerName = null;
            this.acLayoutControl1.Controls.Add(this.acTextEdit2);
            this.acLayoutControl1.Controls.Add(this.acTextEdit1);
            this.acLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.acLayoutControl1.LayoutType = ControlManager.acLayoutControl.emLayoutType.CONDITION;
            this.acLayoutControl1.Location = new System.Drawing.Point(2, 23);
            this.acLayoutControl1.Name = "acLayoutControl1";
            this.acLayoutControl1.ParentControl = null;
            this.acLayoutControl1.Root = this.layoutControlGroup1;
            this.acLayoutControl1.Size = new System.Drawing.Size(769, 29);
            this.acLayoutControl1.TabIndex = 0;
            this.acLayoutControl1.Text = "acLayoutControl1";
            // 
            // acTextEdit2
            // 
            this.acTextEdit2.ColumnName = "RES_ID";
            this.acTextEdit2.Location = new System.Drawing.Point(37, 5);
            this.acTextEdit2.MaskType = ControlManager.acTextEdit.emMaskType.NONE;
            this.acTextEdit2.Name = "acTextEdit2";
            this.acTextEdit2.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.acTextEdit2.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.acTextEdit2.Properties.Appearance.Options.UseBackColor = true;
            this.acTextEdit2.Properties.Appearance.Options.UseForeColor = true;
            this.acTextEdit2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.acTextEdit2.Size = new System.Drawing.Size(115, 20);
            this.acTextEdit2.StyleController = this.acLayoutControl1;
            this.acTextEdit2.TabIndex = 5;
            // 
            // acTextEdit1
            // 
            this.acTextEdit1.ColumnName = "RES_CONTENTS_LIKE";
            this.acTextEdit1.Location = new System.Drawing.Point(194, 5);
            this.acTextEdit1.MaskType = ControlManager.acTextEdit.emMaskType.NONE;
            this.acTextEdit1.Name = "acTextEdit1";
            this.acTextEdit1.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.acTextEdit1.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.acTextEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.acTextEdit1.Properties.Appearance.Options.UseForeColor = true;
            this.acTextEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.acTextEdit1.Size = new System.Drawing.Size(121, 20);
            this.acTextEdit1.StyleController = this.acLayoutControl1;
            this.acTextEdit1.TabIndex = 4;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.IsHeader = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.acLayoutControlItem1,
            this.emptySpaceItem1,
            this.emptySpaceItem2,
            this.acLayoutControlItem2});
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.ResourceID = null;
            this.layoutControlGroup1.Size = new System.Drawing.Size(769, 40);
            this.layoutControlGroup1.TextVisible = false;
            this.layoutControlGroup1.ToolTipID = null;
            this.layoutControlGroup1.UseResourceID = false;
            this.layoutControlGroup1.UseToolTipID = false;
            // 
            // acLayoutControlItem1
            // 
            this.acLayoutControlItem1.Control = this.acTextEdit1;
            this.acLayoutControlItem1.CustomizationFormText = "내용";
            this.acLayoutControlItem1.IsHeader = false;
            this.acLayoutControlItem1.IsTitle = false;
            this.acLayoutControlItem1.Location = new System.Drawing.Point(157, 0);
            this.acLayoutControlItem1.Name = "acLayoutControlItem1";
            this.acLayoutControlItem1.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.acLayoutControlItem1.ResourceID = "O00RH4SM";
            this.acLayoutControlItem1.Size = new System.Drawing.Size(163, 30);
            this.acLayoutControlItem1.Text = "내용";
            this.acLayoutControlItem1.TextLocation = DevExpress.Utils.Locations.Left;
            this.acLayoutControlItem1.TextSize = new System.Drawing.Size(20, 14);
            this.acLayoutControlItem1.ToolTipID = null;
            this.acLayoutControlItem1.ToolTipStdCode = null;
            this.acLayoutControlItem1.UseResourceID = true;
            this.acLayoutControlItem1.UseToolTipID = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(320, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(449, 30);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.CustomizationFormText = "emptySpaceItem2";
            this.emptySpaceItem2.Location = new System.Drawing.Point(0, 30);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(769, 10);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // acLayoutControlItem2
            // 
            this.acLayoutControlItem2.Control = this.acTextEdit2;
            this.acLayoutControlItem2.CustomizationFormText = "ID";
            this.acLayoutControlItem2.IsHeader = false;
            this.acLayoutControlItem2.IsTitle = false;
            this.acLayoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.acLayoutControlItem2.Name = "acLayoutControlItem2";
            this.acLayoutControlItem2.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.acLayoutControlItem2.ResourceID = "OYL0JR2M";
            this.acLayoutControlItem2.Size = new System.Drawing.Size(157, 30);
            this.acLayoutControlItem2.Text = "ID";
            this.acLayoutControlItem2.TextLocation = DevExpress.Utils.Locations.Left;
            this.acLayoutControlItem2.TextSize = new System.Drawing.Size(20, 14);
            this.acLayoutControlItem2.ToolTipID = null;
            this.acLayoutControlItem2.ToolTipStdCode = null;
            this.acLayoutControlItem2.UseResourceID = true;
            this.acLayoutControlItem2.UseToolTipID = false;
            // 
            // popupMenu1
            // 
            this.popupMenu1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.acBarSubItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.acBarButtonItem2)});
            this.popupMenu1.Manager = this.acBarManager1;
            this.popupMenu1.Name = "popupMenu1";
            // 
            // acGroupControl1
            // 
            this.acGroupControl1.Controls.Add(this.acLayoutControl1);
            this.acGroupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.acGroupControl1.IsHeader = false;
            this.acGroupControl1.IsNavPlan = true;
            this.acGroupControl1.Location = new System.Drawing.Point(0, 0);
            this.acGroupControl1.Name = "acGroupControl1";
            this.acGroupControl1.ResourceID = "0ESJ7Q53";
            this.acGroupControl1.Size = new System.Drawing.Size(773, 54);
            this.acGroupControl1.TabIndex = 6;
            this.acGroupControl1.Text = "검색조건";
            this.acGroupControl1.ToolTipID = null;
            this.acGroupControl1.UseResourceID = true;
            this.acGroupControl1.UseToolTipID = false;
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
            this.acSplitContainerControl1.Panel1.Controls.Add(this.acGroupControl1);
            this.acSplitContainerControl1.Panel1.Text = "Panel1";
            // 
            // acSplitContainerControl1.Panel2
            // 
            this.acSplitContainerControl1.Panel2.Controls.Add(this.acGridControl1);
            this.acSplitContainerControl1.Panel2.Text = "Panel2";
            this.acSplitContainerControl1.ParentControl = null;
            this.acSplitContainerControl1.Size = new System.Drawing.Size(773, 577);
            this.acSplitContainerControl1.SplitterPosition = 54;
            this.acSplitContainerControl1.TabIndex = 7;
            this.acSplitContainerControl1.Text = "acSplitContainerControl1";
            // 
            // SYS32A_M0A
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "SYS32A_M0A";
            this.Size = new System.Drawing.Size(773, 643);
            this.Controls.SetChildIndex(this.barDockControlTop, 0);
            this.Controls.SetChildIndex(this.barDockControlBottom, 0);
            this.Controls.SetChildIndex(this.barDockControlRight, 0);
            this.Controls.SetChildIndex(this.barDockControlLeft, 0);
            this.Controls.SetChildIndex(this.pnlScreenBase, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pnlScreenBase)).EndInit();
            this.pnlScreenBase.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.acGridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acBarManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControl1)).EndInit();
            this.acLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.acTextEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acTextEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acGroupControl1)).EndInit();
            this.acGroupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.acSplitContainerControl1.Panel1)).EndInit();
            this.acSplitContainerControl1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.acSplitContainerControl1.Panel2)).EndInit();
            this.acSplitContainerControl1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.acSplitContainerControl1)).EndInit();
            this.acSplitContainerControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ControlManager.acGridControl acGridControl1;
        private ControlManager.acGridView acGridView1;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private ControlManager.acBarManager acBarManager1;
        private ControlManager.acBar bar2;
        private ControlManager.acBar bar3;


        private ControlManager.acBarButtonItem barItemSearch;
        private ControlManager.acBarButtonItem barItemSave;
        private ControlManager.acBarStaticItem statusBarLog;
        private ControlManager.acLayoutControl acLayoutControl1;
        private ControlManager.acTextEdit acTextEdit1;
        private ControlManager.acLayoutControlGroup layoutControlGroup1;
        private ControlManager.acLayoutControlItem acLayoutControlItem1;
        private ControlManager.acBarButtonItem acBarButtonItem1;
        private ControlManager.acBarButtonItem acBarButtonItem2;
        private DevExpress.XtraBars.PopupMenu popupMenu1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private ControlManager.acGroupControl acGroupControl1;
        private ControlManager.acBarSubItem acBarSubItem1;
        private ControlManager.acBarButtonItem acBarButtonItem3;
        private ControlManager.acSplitContainerControl acSplitContainerControl1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private ControlManager.acBarButtonItem acBarButtonItem4;
        private ControlManager.acBarButtonItem acBarButtonItem5;
        private ControlManager.acTextEdit acTextEdit2;
        private ControlManager.acLayoutControlItem acLayoutControlItem2;
    }
}
