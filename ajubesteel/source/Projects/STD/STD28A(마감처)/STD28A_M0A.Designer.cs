namespace STD
{
    partial class STD28A_M0A
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
            this.barItemRefresh = new ControlManager.acBarButtonItem();
            this.bar3 = new ControlManager.acBar();
            this.statusBarLog = new ControlManager.acBarStaticItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.btnSave = new ControlManager.acBarButtonItem();
            this.acBarStaticItem1 = new ControlManager.acBarStaticItem();
            this.acBarButtonItem1 = new ControlManager.acBarButtonItem();
            this.acBarButtonItem2 = new ControlManager.acBarButtonItem();
            this.acBarButtonItem3 = new ControlManager.acBarButtonItem();
            this.acGroupControl1 = new ControlManager.acGroupControl();
            this.acLayoutControl1 = new ControlManager.acLayoutControl();
            this.acTextEdit1 = new ControlManager.acTextEdit();
            this.Root = new ControlManager.acLayoutControlGroup();
            this.acLayoutControlItem1 = new ControlManager.acLayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.acSplitContainerControl2 = new ControlManager.acSplitContainerControl();
            this.acGridControl1 = new ControlManager.acGridControl();
            this.acGridView1 = new ControlManager.acGridView();
            this.popupMenu1 = new DevExpress.XtraBars.PopupMenu(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pnlScreenBase)).BeginInit();
            this.pnlScreenBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.acBarManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acGroupControl1)).BeginInit();
            this.acGroupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControl1)).BeginInit();
            this.acLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.acTextEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acSplitContainerControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acSplitContainerControl2.Panel1)).BeginInit();
            this.acSplitContainerControl2.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.acSplitContainerControl2.Panel2)).BeginInit();
            this.acSplitContainerControl2.Panel2.SuspendLayout();
            this.acSplitContainerControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.acGridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlScreenBase
            // 
            this.pnlScreenBase.Controls.Add(this.acSplitContainerControl2);
            this.pnlScreenBase.Location = new System.Drawing.Point(0, 34);
            this.pnlScreenBase.Size = new System.Drawing.Size(797, 536);
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
            this.statusBarLog,
            this.barItemRefresh,
            this.btnSave,
            this.acBarStaticItem1,
            this.acBarButtonItem1,
            this.acBarButtonItem2,
            this.acBarButtonItem3});
            this.acBarManager1.MainMenu = this.bar2;
            this.acBarManager1.MaxItemId = 17;
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
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barItemRefresh, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar2.OptionsBar.AllowQuickCustomization = false;
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.ResourceID = "I7LE433K";
            this.bar2.Text = "도구상자";
            this.bar2.ToolTipID = null;
            this.bar2.UseResourceID = true;
            this.bar2.UseToolTipID = false;
            // 
            // barItemRefresh
            // 
            this.barItemRefresh.ButtonShortCutType = ControlManager.acBarManager.emBarShortCutType.SEARCH;
            this.barItemRefresh.Caption = "조회";
            this.barItemRefresh.Id = 3;
            this.barItemRefresh.ImageOptions.Image = global::STD.Resource.system_search_2x;
            this.barItemRefresh.Name = "barItemRefresh";
            this.barItemRefresh.ResourceID = null;
            this.barItemRefresh.ToolTipID = "1UMVQFSB";
            this.barItemRefresh.UseResourceID = false;
            this.barItemRefresh.UseToolTipID = true;
            this.barItemRefresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barItemRefresh_ItemClick);
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
            this.statusBarLog.Id = 0;
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
            this.barDockControlTop.Size = new System.Drawing.Size(797, 34);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 570);
            this.barDockControlBottom.Manager = this.acBarManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(797, 30);
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
            this.barDockControlRight.Location = new System.Drawing.Point(797, 34);
            this.barDockControlRight.Manager = this.acBarManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 536);
            // 
            // btnSave
            // 
            this.btnSave.Caption = "저장";
            this.btnSave.Id = 12;
            this.btnSave.ImageOptions.Image = global::STD.Resource.document_save_2x;
            this.btnSave.Name = "btnSave";
            this.btnSave.ResourceID = null;
            this.btnSave.ToolTipID = null;
            this.btnSave.UseResourceID = false;
            this.btnSave.UseToolTipID = false;
            // 
            // acBarStaticItem1
            // 
            this.acBarStaticItem1.Caption = "acBarStaticItem1";
            this.acBarStaticItem1.Id = 13;
            this.acBarStaticItem1.Name = "acBarStaticItem1";
            this.acBarStaticItem1.ResourceID = null;
            this.acBarStaticItem1.ToolTipID = null;
            this.acBarStaticItem1.UseResourceID = false;
            this.acBarStaticItem1.UseToolTipID = false;
            // 
            // acBarButtonItem1
            // 
            this.acBarButtonItem1.Caption = "새로만들기";
            this.acBarButtonItem1.Id = 14;
            this.acBarButtonItem1.ImageOptions.Image = global::STD.Resource.document_new_2x;
            this.acBarButtonItem1.Name = "acBarButtonItem1";
            this.acBarButtonItem1.ResourceID = null;
            this.acBarButtonItem1.ToolTipID = null;
            this.acBarButtonItem1.UseResourceID = false;
            this.acBarButtonItem1.UseToolTipID = false;
            this.acBarButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.acBarButtonItem1_ItemClick);
            // 
            // acBarButtonItem2
            // 
            this.acBarButtonItem2.Caption = "열기";
            this.acBarButtonItem2.Id = 15;
            this.acBarButtonItem2.ImageOptions.Image = global::STD.Resource.document_open_2x;
            this.acBarButtonItem2.Name = "acBarButtonItem2";
            this.acBarButtonItem2.ResourceID = null;
            this.acBarButtonItem2.ToolTipID = null;
            this.acBarButtonItem2.UseResourceID = false;
            this.acBarButtonItem2.UseToolTipID = false;
            this.acBarButtonItem2.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.acBarButtonItem2_ItemClick);
            // 
            // acBarButtonItem3
            // 
            this.acBarButtonItem3.Caption = "삭제";
            this.acBarButtonItem3.Id = 16;
            this.acBarButtonItem3.ImageOptions.Image = global::STD.Resource.edit_delete_2x;
            this.acBarButtonItem3.Name = "acBarButtonItem3";
            this.acBarButtonItem3.ResourceID = null;
            this.acBarButtonItem3.ToolTipID = null;
            this.acBarButtonItem3.UseResourceID = false;
            this.acBarButtonItem3.UseToolTipID = false;
            this.acBarButtonItem3.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.acBarButtonItem3_ItemClick);
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
            this.acGroupControl1.Size = new System.Drawing.Size(797, 54);
            this.acGroupControl1.TabIndex = 9;
            this.acGroupControl1.Text = "검색조건";
            this.acGroupControl1.ToolTipID = null;
            this.acGroupControl1.UseResourceID = true;
            this.acGroupControl1.UseToolTipID = false;
            // 
            // acLayoutControl1
            // 
            this.acLayoutControl1.AllowCustomization = false;
            this.acLayoutControl1.ContainerName = null;
            this.acLayoutControl1.Controls.Add(this.acTextEdit1);
            this.acLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.acLayoutControl1.LayoutType = ControlManager.acLayoutControl.emLayoutType.CONDITION;
            this.acLayoutControl1.Location = new System.Drawing.Point(2, 23);
            this.acLayoutControl1.Name = "acLayoutControl1";
            this.acLayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(3002, 0, 650, 400);
            this.acLayoutControl1.ParentControl = null;
            this.acLayoutControl1.Root = this.Root;
            this.acLayoutControl1.Size = new System.Drawing.Size(793, 29);
            this.acLayoutControl1.TabIndex = 0;
            this.acLayoutControl1.Text = "acLayoutControl1";
            // 
            // acTextEdit1
            // 
            this.acTextEdit1.ColumnName = "BVEN_LIKE";
            this.acTextEdit1.Location = new System.Drawing.Point(82, 5);
            this.acTextEdit1.MaskType = ControlManager.acTextEdit.emMaskType.NONE;
            this.acTextEdit1.MenuManager = this.acBarManager1;
            this.acTextEdit1.Name = "acTextEdit1";
            this.acTextEdit1.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.acTextEdit1.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.acTextEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.acTextEdit1.Properties.Appearance.Options.UseForeColor = true;
            this.acTextEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.acTextEdit1.Size = new System.Drawing.Size(126, 20);
            this.acTextEdit1.StyleController = this.acLayoutControl1;
            this.acTextEdit1.TabIndex = 4;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.False;
            this.Root.GroupBordersVisible = false;
            this.Root.IsHeader = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.acLayoutControlItem1,
            this.emptySpaceItem1,
            this.emptySpaceItem2});
            this.Root.Name = "Root";
            this.Root.ResourceID = null;
            this.Root.Size = new System.Drawing.Size(776, 40);
            this.Root.TextVisible = false;
            this.Root.ToolTipID = null;
            this.Root.UseResourceID = false;
            this.Root.UseToolTipID = false;
            // 
            // acLayoutControlItem1
            // 
            this.acLayoutControlItem1.Control = this.acTextEdit1;
            this.acLayoutControlItem1.CustomizationFormText = "마감처코드/명";
            this.acLayoutControlItem1.IsHeader = false;
            this.acLayoutControlItem1.IsTitle = false;
            this.acLayoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.acLayoutControlItem1.Name = "acLayoutControlItem1";
            this.acLayoutControlItem1.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.acLayoutControlItem1.ResourceID = null;
            this.acLayoutControlItem1.Size = new System.Drawing.Size(213, 30);
            this.acLayoutControlItem1.Text = "마감처코드/명";
            this.acLayoutControlItem1.TextSize = new System.Drawing.Size(65, 14);
            this.acLayoutControlItem1.ToolTipID = null;
            this.acLayoutControlItem1.ToolTipStdCode = null;
            this.acLayoutControlItem1.UseResourceID = false;
            this.acLayoutControlItem1.UseToolTipID = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 30);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(776, 10);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(213, 0);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(563, 30);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // acSplitContainerControl2
            // 
            this.acSplitContainerControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.acSplitContainerControl2.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.None;
            this.acSplitContainerControl2.Horizontal = false;
            this.acSplitContainerControl2.Location = new System.Drawing.Point(0, 0);
            this.acSplitContainerControl2.Name = "acSplitContainerControl2";
            // 
            // acSplitContainerControl2.Panel1
            // 
            this.acSplitContainerControl2.Panel1.Controls.Add(this.acGroupControl1);
            this.acSplitContainerControl2.Panel1.Text = "Panel1";
            // 
            // acSplitContainerControl2.Panel2
            // 
            this.acSplitContainerControl2.Panel2.Controls.Add(this.acGridControl1);
            this.acSplitContainerControl2.Panel2.Text = "Panel2";
            this.acSplitContainerControl2.ParentControl = null;
            this.acSplitContainerControl2.Size = new System.Drawing.Size(797, 536);
            this.acSplitContainerControl2.SplitterPosition = 54;
            this.acSplitContainerControl2.TabIndex = 10;
            this.acSplitContainerControl2.Text = "acSplitContainerControl2";
            // 
            // acGridControl1
            // 
            this.acGridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.acGridControl1.IsCustomReportExcel = false;
            this.acGridControl1.Location = new System.Drawing.Point(0, 0);
            this.acGridControl1.MainView = this.acGridView1;
            this.acGridControl1.MenuManager = this.acBarManager1;
            this.acGridControl1.Name = "acGridControl1";
            this.acGridControl1.Size = new System.Drawing.Size(797, 472);
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
            this.acGridView1.OptionsLayout.Columns.StoreAllOptions = true;
            this.acGridView1.OptionsLayout.StoreAllOptions = true;
            this.acGridView1.OptionsView.EnableAppearanceEvenRow = true;
            this.acGridView1.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.Button;
            this.acGridView1.OptionsView.RowAutoHeight = true;
            this.acGridView1.OptionsView.ShowGroupPanel = false;
            this.acGridView1.OptionsView.ShowIndicator = false;
            this.acGridView1.ParentControl = this;
            this.acGridView1.RowHeight = 25;
            this.acGridView1.SaveFileName = null;
            // 
            // popupMenu1
            // 
            this.popupMenu1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.acBarButtonItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.acBarButtonItem2),
            new DevExpress.XtraBars.LinkPersistInfo(this.acBarButtonItem3)});
            this.popupMenu1.Manager = this.acBarManager1;
            this.popupMenu1.Name = "popupMenu1";
            // 
            // STD28A_M0A
            // 
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "STD28A_M0A";
            this.Size = new System.Drawing.Size(797, 600);
            this.Controls.SetChildIndex(this.barDockControlTop, 0);
            this.Controls.SetChildIndex(this.barDockControlBottom, 0);
            this.Controls.SetChildIndex(this.barDockControlRight, 0);
            this.Controls.SetChildIndex(this.barDockControlLeft, 0);
            this.Controls.SetChildIndex(this.pnlScreenBase, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pnlScreenBase)).EndInit();
            this.pnlScreenBase.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.acBarManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acGroupControl1)).EndInit();
            this.acGroupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControl1)).EndInit();
            this.acLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.acTextEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acSplitContainerControl2.Panel1)).EndInit();
            this.acSplitContainerControl2.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.acSplitContainerControl2.Panel2)).EndInit();
            this.acSplitContainerControl2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.acSplitContainerControl2)).EndInit();
            this.acSplitContainerControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.acGridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ControlManager.acBarManager acBarManager1;
        private ControlManager.acBar bar2;
        private ControlManager.acBar bar3;

        

        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private ControlManager.acBarButtonItem barItemRefresh;
        private ControlManager.acBarStaticItem statusBarLog;
        private ControlManager.acGroupControl acGroupControl1;
        private ControlManager.acSplitContainerControl acSplitContainerControl2;
		private ControlManager.acBarButtonItem btnSave;
        private ControlManager.acGridControl acGridControl1;
        private ControlManager.acGridView acGridView1;
        private ControlManager.acBarStaticItem acBarStaticItem1;
        private ControlManager.acBarButtonItem acBarButtonItem1;
        private ControlManager.acBarButtonItem acBarButtonItem2;
        private ControlManager.acBarButtonItem acBarButtonItem3;
        private DevExpress.XtraBars.PopupMenu popupMenu1;
        private ControlManager.acLayoutControl acLayoutControl1;
        private ControlManager.acTextEdit acTextEdit1;
        private ControlManager.acLayoutControlGroup Root;
        private ControlManager.acLayoutControlItem acLayoutControlItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
    }
}
