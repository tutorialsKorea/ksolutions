namespace REP
{
    partial class REP19A_M0A
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
            this.acBarManager1 = new ControlManager.acBarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.acBarButtonItem1 = new ControlManager.acBarButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.statusBarLog = new ControlManager.acBarStaticItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.acSplitContainerControl1 = new ControlManager.acSplitContainerControl();
            this.acGroupControl1 = new ControlManager.acGroupControl();
            this.acLayoutControl1 = new ControlManager.acLayoutControl();
            this.acDateEdit1 = new ControlManager.acDateEdit();
            this.acLayoutControlGroup1 = new ControlManager.acLayoutControlGroup();
            this.emptySpaceItem5 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.acLayoutControlItem1 = new ControlManager.acLayoutControlItem();
            this.acGridControl1 = new ControlManager.acGridControl();
            this.acGridView1 = new ControlManager.acGridView();
            ((System.ComponentModel.ISupportInitialize)(this.pnlScreenBase)).BeginInit();
            this.pnlScreenBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.acBarManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acSplitContainerControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acSplitContainerControl1.Panel1)).BeginInit();
            this.acSplitContainerControl1.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.acSplitContainerControl1.Panel2)).BeginInit();
            this.acSplitContainerControl1.Panel2.SuspendLayout();
            this.acSplitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.acGroupControl1)).BeginInit();
            this.acGroupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControl1)).BeginInit();
            this.acLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.acDateEdit1.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acDateEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acGridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlScreenBase
            // 
            this.pnlScreenBase.Controls.Add(this.acSplitContainerControl1);
            this.pnlScreenBase.Location = new System.Drawing.Point(0, 34);
            this.pnlScreenBase.Size = new System.Drawing.Size(800, 540);
            // 
            // acBarManager1
            // 
            this.acBarManager1.AllowCustomization = false;
            this.acBarManager1.AllowQuickCustomization = false;
            this.acBarManager1.AllowShowToolbarsPopup = false;
            this.acBarManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1,
            this.bar3});
            this.acBarManager1.CloseButtonAffectAllTabs = false;
            this.acBarManager1.DockControls.Add(this.barDockControlTop);
            this.acBarManager1.DockControls.Add(this.barDockControlBottom);
            this.acBarManager1.DockControls.Add(this.barDockControlLeft);
            this.acBarManager1.DockControls.Add(this.barDockControlRight);
            this.acBarManager1.Form = this;
            this.acBarManager1.IsLoadDefaultLayout = true;
            this.acBarManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.acBarButtonItem1,
            this.statusBarLog});
            this.acBarManager1.MaxItemId = 2;
            this.acBarManager1.StatusBar = this.bar3;
            // 
            // bar1
            // 
            this.bar1.BarItemHorzIndent = 10;
            this.bar1.BarItemVertIndent = 5;
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.acBarButtonItem1, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar1.OptionsBar.UseWholeRow = true;
            this.bar1.Text = "Tools";
            // 
            // acBarButtonItem1
            // 
            this.acBarButtonItem1.ButtonShortCutType = ControlManager.acBarManager.emBarShortCutType.SEARCH;
            this.acBarButtonItem1.Caption = "조회";
            this.acBarButtonItem1.Id = 0;
            this.acBarButtonItem1.ImageOptions.Image = global::REP.Resource.system_search_2x;
            this.acBarButtonItem1.Name = "acBarButtonItem1";
            this.acBarButtonItem1.ResourceID = null;
            this.acBarButtonItem1.ToolTipID = null;
            this.acBarButtonItem1.UseResourceID = false;
            this.acBarButtonItem1.UseToolTipID = false;
            this.acBarButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barItemSearch_ItemClick);
            // 
            // bar3
            // 
            this.bar3.BarName = "Status bar";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.statusBarLog)});
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Status bar";
            // 
            // statusBarLog
            // 
            this.statusBarLog.Id = 1;
            this.statusBarLog.ImageOptions.Image = global::REP.Resource.internet_group_chat_1x;
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
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 574);
            this.barDockControlBottom.Manager = this.acBarManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(800, 26);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 34);
            this.barDockControlLeft.Manager = this.acBarManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 540);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(800, 34);
            this.barDockControlRight.Manager = this.acBarManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 540);
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
            this.acSplitContainerControl1.Size = new System.Drawing.Size(800, 540);
            this.acSplitContainerControl1.SplitterPosition = 62;
            this.acSplitContainerControl1.TabIndex = 1;
            this.acSplitContainerControl1.Text = "acSplitContainerControl1";
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
            this.acGroupControl1.Size = new System.Drawing.Size(800, 62);
            this.acGroupControl1.TabIndex = 9;
            this.acGroupControl1.Text = "검색조건";
            this.acGroupControl1.ToolTipID = null;
            this.acGroupControl1.UseResourceID = true;
            this.acGroupControl1.UseToolTipID = false;
            // 
            // acLayoutControl1
            // 
            this.acLayoutControl1.AllowCustomization = false;
            this.acLayoutControl1.AutoScroll = false;
            this.acLayoutControl1.ContainerName = null;
            this.acLayoutControl1.Controls.Add(this.acDateEdit1);
            this.acLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.acLayoutControl1.LayoutType = ControlManager.acLayoutControl.emLayoutType.CONDITION;
            this.acLayoutControl1.Location = new System.Drawing.Point(2, 23);
            this.acLayoutControl1.Name = "acLayoutControl1";
            this.acLayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(307, 201, 250, 350);
            this.acLayoutControl1.ParentControl = null;
            this.acLayoutControl1.Root = this.acLayoutControlGroup1;
            this.acLayoutControl1.Size = new System.Drawing.Size(796, 37);
            this.acLayoutControl1.TabIndex = 0;
            this.acLayoutControl1.Text = "acLayoutControl1";
            // 
            // acDateEdit1
            // 
            this.acDateEdit1.ColumnName = "SYEAR";
            this.acDateEdit1.CreateParameterFormat = "yyyy";
            this.acDateEdit1.EditValue = null;
            this.acDateEdit1.isReadyOnly = false;
            this.acDateEdit1.isRequired = true;
            this.acDateEdit1.Location = new System.Drawing.Point(5, 5);
            this.acDateEdit1.MenuManager = this.acBarManager1;
            this.acDateEdit1.Name = "acDateEdit1";
            this.acDateEdit1.Properties.Appearance.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.acDateEdit1.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.acDateEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.acDateEdit1.Properties.Appearance.Options.UseForeColor = true;
            this.acDateEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.acDateEdit1.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.acDateEdit1.Properties.DisplayFormat.FormatString = "yyyy";
            this.acDateEdit1.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.acDateEdit1.Properties.EditFormat.FormatString = "yyyy";
            this.acDateEdit1.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.acDateEdit1.Properties.Mask.EditMask = "yyyy";
            this.acDateEdit1.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.acDateEdit1.Properties.VistaCalendarInitialViewStyle = DevExpress.XtraEditors.VistaCalendarInitialViewStyle.YearsGroupView;
            this.acDateEdit1.Properties.VistaCalendarViewStyle = DevExpress.XtraEditors.VistaCalendarViewStyle.YearsGroupView;
            this.acDateEdit1.Size = new System.Drawing.Size(106, 20);
            this.acDateEdit1.StyleController = this.acLayoutControl1;
            this.acDateEdit1.TabIndex = 4;
            this.acDateEdit1.ToolTipID = null;
            this.acDateEdit1.UseToolTipID = false;
            // 
            // acLayoutControlGroup1
            // 
            this.acLayoutControlGroup1.CustomizationFormText = "Root";
            this.acLayoutControlGroup1.GroupBordersVisible = false;
            this.acLayoutControlGroup1.IsHeader = false;
            this.acLayoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.emptySpaceItem5,
            this.emptySpaceItem1,
            this.acLayoutControlItem1});
            this.acLayoutControlGroup1.Name = "Root";
            this.acLayoutControlGroup1.ResourceID = null;
            this.acLayoutControlGroup1.Size = new System.Drawing.Size(796, 41);
            this.acLayoutControlGroup1.TextVisible = false;
            this.acLayoutControlGroup1.ToolTipID = null;
            this.acLayoutControlGroup1.UseResourceID = false;
            this.acLayoutControlGroup1.UseToolTipID = false;
            // 
            // emptySpaceItem5
            // 
            this.emptySpaceItem5.AllowHotTrack = false;
            this.emptySpaceItem5.CustomizationFormText = "emptySpaceItem5";
            this.emptySpaceItem5.Location = new System.Drawing.Point(138, 0);
            this.emptySpaceItem5.MaxSize = new System.Drawing.Size(0, 31);
            this.emptySpaceItem5.MinSize = new System.Drawing.Size(10, 31);
            this.emptySpaceItem5.Name = "emptySpaceItem5";
            this.emptySpaceItem5.Size = new System.Drawing.Size(658, 31);
            this.emptySpaceItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem5.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 31);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(796, 10);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // acLayoutControlItem1
            // 
            this.acLayoutControlItem1.Control = this.acDateEdit1;
            this.acLayoutControlItem1.CustomizationFormText = "년";
            this.acLayoutControlItem1.IsHeader = false;
            this.acLayoutControlItem1.IsTitle = false;
            this.acLayoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.acLayoutControlItem1.Name = "acLayoutControlItem1";
            this.acLayoutControlItem1.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.acLayoutControlItem1.ResourceID = null;
            this.acLayoutControlItem1.Size = new System.Drawing.Size(138, 31);
            this.acLayoutControlItem1.Text = "년";
            this.acLayoutControlItem1.TextLocation = DevExpress.Utils.Locations.Right;
            this.acLayoutControlItem1.TextSize = new System.Drawing.Size(10, 14);
            this.acLayoutControlItem1.ToolTipID = null;
            this.acLayoutControlItem1.ToolTipStdCode = null;
            this.acLayoutControlItem1.UseResourceID = false;
            this.acLayoutControlItem1.UseToolTipID = false;
            // 
            // acGridControl1
            // 
            this.acGridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.acGridControl1.Location = new System.Drawing.Point(0, 0);
            this.acGridControl1.MainView = this.acGridView1;
            this.acGridControl1.MenuManager = this.acBarManager1;
            this.acGridControl1.Name = "acGridControl1";
            this.acGridControl1.Size = new System.Drawing.Size(800, 468);
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
            // REP19A_M0A
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "REP19A_M0A";
            this.Controls.SetChildIndex(this.barDockControlTop, 0);
            this.Controls.SetChildIndex(this.barDockControlBottom, 0);
            this.Controls.SetChildIndex(this.barDockControlRight, 0);
            this.Controls.SetChildIndex(this.barDockControlLeft, 0);
            this.Controls.SetChildIndex(this.pnlScreenBase, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pnlScreenBase)).EndInit();
            this.pnlScreenBase.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.acBarManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acSplitContainerControl1.Panel1)).EndInit();
            this.acSplitContainerControl1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.acSplitContainerControl1.Panel2)).EndInit();
            this.acSplitContainerControl1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.acSplitContainerControl1)).EndInit();
            this.acSplitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.acGroupControl1)).EndInit();
            this.acGroupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControl1)).EndInit();
            this.acLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.acDateEdit1.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acDateEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acGridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ControlManager.acBarManager acBarManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private ControlManager.acBarButtonItem acBarButtonItem1;
        private ControlManager.acSplitContainerControl acSplitContainerControl1;
        private ControlManager.acGroupControl acGroupControl1;
        private ControlManager.acLayoutControl acLayoutControl1;
        private ControlManager.acLayoutControlGroup acLayoutControlGroup1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem5;
        private ControlManager.acBarStaticItem statusBarLog;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private ControlManager.acDateEdit acDateEdit1;
        private ControlManager.acLayoutControlItem acLayoutControlItem1;
        private ControlManager.acGridControl acGridControl1;
        private ControlManager.acGridView acGridView1;
    }
}
