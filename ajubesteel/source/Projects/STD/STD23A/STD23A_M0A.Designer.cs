namespace STD
{
    partial class STD23A_M0A
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
            this.gcHoli = new ControlManager.acGridControl();
            this.gvHoli = new ControlManager.acGridView();
            this.dnCalender = new ControlManager.acDateNavigator();
            this.acBarManager1 = new ControlManager.acBarManager(this.components);
            this.bar2 = new ControlManager.acBar();
            this.barItemSearch = new ControlManager.acBarButtonItem();
            this.barItemHelp = new ControlManager.acBarButtonItem();
            this.barItemCreate = new ControlManager.acBarButtonItem();
            this.bar3 = new ControlManager.acBar();
            this.statusBarLog = new ControlManager.acBarStaticItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.acBarButtonItem1 = new ControlManager.acBarButtonItem();
            this.acBarButtonItem2 = new ControlManager.acBarButtonItem();
            this.acBarButtonItem3 = new ControlManager.acBarButtonItem();
            this.acBarButtonItem4 = new ControlManager.acBarButtonItem();
            this.popupMenu1 = new DevExpress.XtraBars.PopupMenu(this.components);
            this.acSplitContainerControl1 = new ControlManager.acSplitContainerControl();
            this.popupMenu2 = new DevExpress.XtraBars.PopupMenu(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pnlScreenBase)).BeginInit();
            this.pnlScreenBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcHoli)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvHoli)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dnCalender)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dnCalender.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acBarManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acSplitContainerControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acSplitContainerControl1.Panel1)).BeginInit();
            this.acSplitContainerControl1.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.acSplitContainerControl1.Panel2)).BeginInit();
            this.acSplitContainerControl1.Panel2.SuspendLayout();
            this.acSplitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu2)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlScreenBase
            // 
            this.pnlScreenBase.Controls.Add(this.acSplitContainerControl1);
            this.pnlScreenBase.Location = new System.Drawing.Point(0, 34);
            this.pnlScreenBase.Size = new System.Drawing.Size(800, 536);
            // 
            // gcHoli
            // 
            this.gcHoli.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcHoli.Location = new System.Drawing.Point(0, 0);
            this.gcHoli.MainView = this.gvHoli;
            this.gcHoli.Name = "gcHoli";
            this.gcHoli.Size = new System.Drawing.Size(509, 536);
            this.gcHoli.TabIndex = 8;
            this.gcHoli.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvHoli});
            // 
            // gvHoli
            // 
            this.gvHoli.ColumnPanelRowHeight = 30;
            this.gvHoli.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gvHoli.GridControl = this.gcHoli;
            this.gvHoli.IsUserStyle = false;
            this.gvHoli.Name = "gvHoli";
            this.gvHoli.NoApplyEditableCellColor = false;
            this.gvHoli.OptionsBehavior.AutoPopulateColumns = false;
            this.gvHoli.OptionsLayout.Columns.StoreAllOptions = true;
            this.gvHoli.OptionsLayout.StoreAllOptions = true;
            this.gvHoli.OptionsView.ColumnAutoWidth = false;
            this.gvHoli.OptionsView.RowAutoHeight = true;
            this.gvHoli.OptionsView.ShowGroupPanel = false;
            this.gvHoli.OptionsView.ShowIndicator = false;
            this.gvHoli.ParentControl = this;
            this.gvHoli.RowHeight = 30;
            this.gvHoli.SaveFileName = null;
            // 
            // dnCalender
            // 
            this.dnCalender.Appearance.BorderColor = System.Drawing.Color.Black;
            this.dnCalender.Appearance.ForeColor = System.Drawing.Color.Black;
            this.dnCalender.Appearance.Options.UseBorderColor = true;
            this.dnCalender.Appearance.Options.UseForeColor = true;
            this.dnCalender.Appearance.Options.UseTextOptions = true;
            this.dnCalender.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.dnCalender.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dnCalender.DateTime = new System.DateTime(2009, 12, 15, 0, 0, 0, 0);
            this.dnCalender.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dnCalender.EditValue = new System.DateTime(2009, 12, 15, 0, 0, 0, 0);
            this.dnCalender.FirstDayOfWeek = System.DayOfWeek.Sunday;
            this.dnCalender.HighlightHolidays = false;
            this.dnCalender.Location = new System.Drawing.Point(0, 0);
            this.dnCalender.MaxCalendar = 12;
            this.dnCalender.Name = "dnCalender";
            this.dnCalender.SelectionMode = DevExpress.XtraEditors.Repository.CalendarSelectionMode.Single;
            this.dnCalender.ShowTodayButton = false;
            this.dnCalender.ShowWeekNumbers = false;
            this.dnCalender.Size = new System.Drawing.Size(281, 536);
            this.dnCalender.TabIndex = 7;
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
            this.barItemHelp,
            this.barItemCreate,
            this.statusBarLog,
            this.acBarButtonItem1,
            this.acBarButtonItem2,
            this.acBarButtonItem3,
            this.acBarButtonItem4});
            this.acBarManager1.MainMenu = this.bar2;
            this.acBarManager1.MaxItemId = 14;
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
            this.bar2.FloatLocation = new System.Drawing.Point(228, 115);
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barItemSearch, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barItemCreate, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar2.OptionsBar.AllowQuickCustomization = false;
            this.bar2.OptionsBar.RotateWhenVertical = false;
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
            this.barItemSearch.ImageOptions.Image = global::STD.Resource.system_search_2x;
            this.barItemSearch.Name = "barItemSearch";
            this.barItemSearch.ResourceID = null;
            this.barItemSearch.ToolTipID = "1UMVQFSB";
            this.barItemSearch.UseResourceID = false;
            this.barItemSearch.UseToolTipID = true;
            this.barItemSearch.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barItemSearch_ItemClick);
            // 
            // barItemHelp
            // 
            this.barItemHelp.ButtonShortCutType = ControlManager.acBarManager.emBarShortCutType.HELP;
            this.barItemHelp.Caption = "도움말";
            this.barItemHelp.Id = 3;
            this.barItemHelp.ImageOptions.Image = global::STD.Resource.help_browser_2x;
            this.barItemHelp.Name = "barItemHelp";
            this.barItemHelp.ResourceID = null;
            this.barItemHelp.ToolTipID = "46ZIMD99";
            this.barItemHelp.UseResourceID = false;
            this.barItemHelp.UseToolTipID = true;
            this.barItemHelp.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barItemHelp_ItemClick);
            // 
            // barItemCreate
            // 
            this.barItemCreate.ButtonShortCutType = ControlManager.acBarManager.emBarShortCutType.METHOD_1;
            this.barItemCreate.Caption = "생성";
            this.barItemCreate.Id = 4;
            this.barItemCreate.ImageOptions.Image = global::STD.Resource.newtodo_2x;
            this.barItemCreate.Name = "barItemCreate";
            this.barItemCreate.ResourceID = null;
            this.barItemCreate.ToolTipID = "1FM141XL";
            this.barItemCreate.UseResourceID = false;
            this.barItemCreate.UseToolTipID = true;
            this.barItemCreate.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barItemCreate_ItemClick);
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
            this.statusBarLog.Id = 7;
            this.statusBarLog.ImageOptions.Image = global::STD.Resource.internet_group_chat_1x;
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
            this.barDockControlTop.Size = new System.Drawing.Size(800, 34);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 570);
            this.barDockControlBottom.Manager = this.acBarManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(800, 30);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 34);
            this.barDockControlLeft.Manager = this.acBarManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 536);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(800, 34);
            this.barDockControlRight.Manager = this.acBarManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 536);
            // 
            // acBarButtonItem1
            // 
            this.acBarButtonItem1.Caption = "휴일설정";
            this.acBarButtonItem1.Id = 10;
            this.acBarButtonItem1.ImageOptions.Image = global::STD.Resource.day_ok_2x;
            this.acBarButtonItem1.Name = "acBarButtonItem1";
            this.acBarButtonItem1.ResourceID = "ALZUOZAW";
            this.acBarButtonItem1.ToolTipID = null;
            this.acBarButtonItem1.UseResourceID = true;
            this.acBarButtonItem1.UseToolTipID = false;
            this.acBarButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.acBarButtonItem1_ItemClick);
            // 
            // acBarButtonItem2
            // 
            this.acBarButtonItem2.Caption = "휴일해제";
            this.acBarButtonItem2.Id = 11;
            this.acBarButtonItem2.ImageOptions.Image = global::STD.Resource.day_ok_cancel_2x;
            this.acBarButtonItem2.Name = "acBarButtonItem2";
            this.acBarButtonItem2.ResourceID = "OMZIJ6MI";
            this.acBarButtonItem2.ToolTipID = null;
            this.acBarButtonItem2.UseResourceID = true;
            this.acBarButtonItem2.UseToolTipID = false;
            this.acBarButtonItem2.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.acBarButtonItem2_ItemClick);
            // 
            // acBarButtonItem3
            // 
            this.acBarButtonItem3.Caption = "CAPA 변경";
            this.acBarButtonItem3.Id = 12;
            this.acBarButtonItem3.Name = "acBarButtonItem3";
            this.acBarButtonItem3.ResourceID = "SO1XAF3G";
            this.acBarButtonItem3.ToolTipID = null;
            this.acBarButtonItem3.UseResourceID = true;
            this.acBarButtonItem3.UseToolTipID = false;
            this.acBarButtonItem3.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.acBarButtonItem3_ItemClick);
            // 
            // acBarButtonItem4
            // 
            this.acBarButtonItem4.Caption = "CAPA 설비 기본값으로 설정";
            this.acBarButtonItem4.Id = 13;
            this.acBarButtonItem4.Name = "acBarButtonItem4";
            this.acBarButtonItem4.ResourceID = "62WGJ532";
            this.acBarButtonItem4.ToolTipID = null;
            this.acBarButtonItem4.UseResourceID = true;
            this.acBarButtonItem4.UseToolTipID = false;
            this.acBarButtonItem4.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.acBarButtonItem4_ItemClick);
            // 
            // popupMenu1
            // 
            this.popupMenu1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.acBarButtonItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.acBarButtonItem2)});
            this.popupMenu1.Manager = this.acBarManager1;
            this.popupMenu1.Name = "popupMenu1";
            // 
            // acSplitContainerControl1
            // 
            this.acSplitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.acSplitContainerControl1.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.None;
            this.acSplitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.acSplitContainerControl1.Name = "acSplitContainerControl1";
            // 
            // acSplitContainerControl1.Panel1
            // 
            this.acSplitContainerControl1.Panel1.Controls.Add(this.dnCalender);
            this.acSplitContainerControl1.Panel1.Text = "Panel1";
            // 
            // acSplitContainerControl1.Panel2
            // 
            this.acSplitContainerControl1.Panel2.Controls.Add(this.gcHoli);
            this.acSplitContainerControl1.Panel2.Text = "Panel2";
            this.acSplitContainerControl1.ParentControl = null;
            this.acSplitContainerControl1.Size = new System.Drawing.Size(800, 536);
            this.acSplitContainerControl1.SplitterPosition = 281;
            this.acSplitContainerControl1.TabIndex = 13;
            this.acSplitContainerControl1.Text = "acSplitContainerControl1";
            // 
            // popupMenu2
            // 
            this.popupMenu2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.acBarButtonItem3),
            new DevExpress.XtraBars.LinkPersistInfo(this.acBarButtonItem4)});
            this.popupMenu2.Manager = this.acBarManager1;
            this.popupMenu2.Name = "popupMenu2";
            // 
            // STD23A_M0A
            // 
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "STD23A_M0A";
            this.Controls.SetChildIndex(this.barDockControlTop, 0);
            this.Controls.SetChildIndex(this.barDockControlBottom, 0);
            this.Controls.SetChildIndex(this.barDockControlRight, 0);
            this.Controls.SetChildIndex(this.barDockControlLeft, 0);
            this.Controls.SetChildIndex(this.pnlScreenBase, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pnlScreenBase)).EndInit();
            this.pnlScreenBase.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcHoli)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvHoli)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dnCalender.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dnCalender)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acBarManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acSplitContainerControl1.Panel1)).EndInit();
            this.acSplitContainerControl1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.acSplitContainerControl1.Panel2)).EndInit();
            this.acSplitContainerControl1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.acSplitContainerControl1)).EndInit();
            this.acSplitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ControlManager.acGridControl gcHoli;
        private ControlManager.acGridView gvHoli;
        private ControlManager.acDateNavigator dnCalender;
        private ControlManager.acBarManager acBarManager1;
        private ControlManager.acBar bar2;
        private ControlManager.acBar bar3;

        

        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private ControlManager.acBarButtonItem barItemSearch;
        private ControlManager.acBarButtonItem barItemHelp;
        private ControlManager.acBarButtonItem barItemCreate;
        private ControlManager.acBarStaticItem statusBarLog;
        
        
        private ControlManager.acBarButtonItem acBarButtonItem1;
        private ControlManager.acBarButtonItem acBarButtonItem2;
        private DevExpress.XtraBars.PopupMenu popupMenu1;
        private ControlManager.acSplitContainerControl acSplitContainerControl1;
        private ControlManager.acBarButtonItem acBarButtonItem3;
        private DevExpress.XtraBars.PopupMenu popupMenu2;
        private ControlManager.acBarButtonItem acBarButtonItem4;

    }
}
