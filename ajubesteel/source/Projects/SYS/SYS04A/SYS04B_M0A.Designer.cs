namespace SYS
{
    partial class SYS04B_M0A
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
            this.barItemSave = new ControlManager.acBarButtonItem();
            this.bar3 = new ControlManager.acBar();
            this.statusBarLog = new ControlManager.acBarStaticItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.acSplitContainerControl4 = new ControlManager.acSplitContainerControl();
            this.acGridControl1 = new ControlManager.acGridControl();
            this.acGridView1 = new ControlManager.acGridView();
            this.acLayoutControl1 = new ControlManager.acLayoutControl();
            this.acGridControl2 = new ControlManager.acGridControl();
            this.acGridView2 = new ControlManager.acGridView();
            this.acCheckEdit1 = new ControlManager.acCheckEdit();
            this.acTextEdit1 = new ControlManager.acTextEdit();
            this.acLayoutControlGroup12 = new ControlManager.acLayoutControlGroup();
            this.acLayoutControlItem44 = new ControlManager.acLayoutControlItem();
            this.acLayoutControlItem5 = new ControlManager.acLayoutControlItem();
            this.acLayoutControlItem1 = new ControlManager.acLayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.pnlScreenBase)).BeginInit();
            this.pnlScreenBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.acBarManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acSplitContainerControl4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acSplitContainerControl4.Panel1)).BeginInit();
            this.acSplitContainerControl4.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.acSplitContainerControl4.Panel2)).BeginInit();
            this.acSplitContainerControl4.Panel2.SuspendLayout();
            this.acSplitContainerControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.acGridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControl1)).BeginInit();
            this.acLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.acGridControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acCheckEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acTextEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlGroup12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem44)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlScreenBase
            // 
            this.pnlScreenBase.Controls.Add(this.acSplitContainerControl4);
            this.pnlScreenBase.Location = new System.Drawing.Point(0, 36);
            this.pnlScreenBase.Size = new System.Drawing.Size(1023, 573);
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
            this.barItemSave});
            this.acBarManager1.MainMenu = this.bar2;
            this.acBarManager1.MaxItemId = 8;
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
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barItemSave, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar2.OptionsBar.AllowQuickCustomization = false;
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.ResourceID = "I7LE433K";
            this.bar2.Text = "도구상자";
            this.bar2.ToolTipID = null;
            this.bar2.UseResourceID = true;
            this.bar2.UseToolTipID = false;
            // 
            // barItemSave
            // 
            this.barItemSave.ButtonShortCutType = ControlManager.acBarManager.emBarShortCutType.SAVE;
            this.barItemSave.Caption = "저장";
            this.barItemSave.Id = 4;
            this.barItemSave.ImageOptions.Image = global::SYS.Resource.document_save_2x;
            this.barItemSave.Name = "barItemSave";
            this.barItemSave.ResourceID = null;
            this.barItemSave.ToolTipID = "4UY7EZBZ";
            this.barItemSave.UseResourceID = false;
            this.barItemSave.UseToolTipID = true;
            this.barItemSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barItemSave_ItemClick);
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
            this.barDockControlTop.Size = new System.Drawing.Size(1023, 36);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 609);
            this.barDockControlBottom.Manager = this.acBarManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(1023, 30);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 36);
            this.barDockControlLeft.Manager = this.acBarManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 573);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1023, 36);
            this.barDockControlRight.Manager = this.acBarManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 573);
            // 
            // acSplitContainerControl4
            // 
            this.acSplitContainerControl4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.acSplitContainerControl4.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.None;
            this.acSplitContainerControl4.Location = new System.Drawing.Point(0, 0);
            this.acSplitContainerControl4.Name = "acSplitContainerControl4";
            // 
            // acSplitContainerControl4.Panel1
            // 
            this.acSplitContainerControl4.Panel1.Controls.Add(this.acGridControl1);
            this.acSplitContainerControl4.Panel1.Text = "Panel1";
            // 
            // acSplitContainerControl4.Panel2
            // 
            this.acSplitContainerControl4.Panel2.Controls.Add(this.acLayoutControl1);
            this.acSplitContainerControl4.Panel2.Text = "Panel2";
            this.acSplitContainerControl4.ParentControl = null;
            this.acSplitContainerControl4.Size = new System.Drawing.Size(1023, 573);
            this.acSplitContainerControl4.SplitterPosition = 462;
            this.acSplitContainerControl4.TabIndex = 5;
            this.acSplitContainerControl4.Text = "acSplitContainerControl4";
            // 
            // acGridControl1
            // 
            this.acGridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.acGridControl1.Location = new System.Drawing.Point(0, 0);
            this.acGridControl1.MainView = this.acGridView1;
            this.acGridControl1.Name = "acGridControl1";
            this.acGridControl1.Size = new System.Drawing.Size(462, 573);
            this.acGridControl1.TabIndex = 5;
            this.acGridControl1.Tag = "";
            this.acGridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.acGridView1});
            // 
            // acGridView1
            // 
            this.acGridView1.ColumnPanelRowHeight = 30;
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
            this.acGridView1.Tag = "";
            // 
            // acLayoutControl1
            // 
            this.acLayoutControl1.AllowCustomization = false;
            this.acLayoutControl1.AutoScroll = false;
            this.acLayoutControl1.ContainerName = "";
            this.acLayoutControl1.Controls.Add(this.acGridControl2);
            this.acLayoutControl1.Controls.Add(this.acCheckEdit1);
            this.acLayoutControl1.Controls.Add(this.acTextEdit1);
            this.acLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.acLayoutControl1.LayoutType = ControlManager.acLayoutControl.emLayoutType.NONE;
            this.acLayoutControl1.Location = new System.Drawing.Point(0, 0);
            this.acLayoutControl1.Name = "acLayoutControl1";
            this.acLayoutControl1.ParentControl = null;
            this.acLayoutControl1.Root = this.acLayoutControlGroup12;
            this.acLayoutControl1.Size = new System.Drawing.Size(551, 573);
            this.acLayoutControl1.TabIndex = 0;
            this.acLayoutControl1.Text = "acLayoutControl6";
            // 
            // acGridControl2
            // 
            this.acGridControl2.Location = new System.Drawing.Point(5, 65);
            this.acGridControl2.MainView = this.acGridView2;
            this.acGridControl2.Name = "acGridControl2";
            this.acGridControl2.Size = new System.Drawing.Size(541, 503);
            this.acGridControl2.TabIndex = 0;
            this.acGridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.acGridView2});
            // 
            // acGridView2
            // 
            this.acGridView2.ColumnPanelRowHeight = 30;
            this.acGridView2.GridControl = this.acGridControl2;
            this.acGridView2.IsUserStyle = false;
            this.acGridView2.Name = "acGridView2";
            this.acGridView2.NoApplyEditableCellColor = false;
            this.acGridView2.OptionsBehavior.AutoPopulateColumns = false;
            this.acGridView2.OptionsLayout.Columns.StoreAllOptions = true;
            this.acGridView2.OptionsLayout.StoreAllOptions = true;
            this.acGridView2.OptionsView.RowAutoHeight = true;
            this.acGridView2.OptionsView.ShowGroupPanel = false;
            this.acGridView2.OptionsView.ShowIndicator = false;
            this.acGridView2.ParentControl = this;
            this.acGridView2.RowHeight = 30;
            this.acGridView2.SaveFileName = null;
            // 
            // acCheckEdit1
            // 
            this.acCheckEdit1.ColumnName = "AUTO_FIND";
            this.acCheckEdit1.EditValue = "0";
            this.acCheckEdit1.isReadyOnly = false;
            this.acCheckEdit1.isRequired = false;
            this.acCheckEdit1.Location = new System.Drawing.Point(5, 35);
            this.acCheckEdit1.Name = "acCheckEdit1";
            this.acCheckEdit1.Properties.Caption = "자동찾기";
            this.acCheckEdit1.Properties.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            this.acCheckEdit1.Properties.ValueChecked = "1";
            this.acCheckEdit1.Properties.ValueUnchecked = "0";
            this.acCheckEdit1.Size = new System.Drawing.Size(541, 20);
            this.acCheckEdit1.StyleController = this.acLayoutControl1;
            this.acCheckEdit1.TabIndex = 6;
            this.acCheckEdit1.ToolTipID = null;
            this.acCheckEdit1.UseToolTipID = false;
            this.acCheckEdit1.Value = "0";
            this.acCheckEdit1.ValueType = ControlManager.acCheckEdit.emValueType.STRING;
            // 
            // acTextEdit1
            // 
            this.acTextEdit1.ColumnName = "SHOW_COLUMN";
            this.acTextEdit1.Location = new System.Drawing.Point(57, 5);
            this.acTextEdit1.MaskType = ControlManager.acTextEdit.emMaskType.NONE;
            this.acTextEdit1.Name = "acTextEdit1";
            this.acTextEdit1.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.acTextEdit1.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.acTextEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.acTextEdit1.Properties.Appearance.Options.UseForeColor = true;
            this.acTextEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.acTextEdit1.Size = new System.Drawing.Size(489, 20);
            this.acTextEdit1.StyleController = this.acLayoutControl1;
            this.acTextEdit1.TabIndex = 4;
            // 
            // acLayoutControlGroup12
            // 
            this.acLayoutControlGroup12.CustomizationFormText = "acLayoutControlGroup12";
            this.acLayoutControlGroup12.GroupBordersVisible = false;
            this.acLayoutControlGroup12.IsHeader = false;
            this.acLayoutControlGroup12.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.acLayoutControlItem44,
            this.acLayoutControlItem5,
            this.acLayoutControlItem1});
            this.acLayoutControlGroup12.Name = "Root";
            this.acLayoutControlGroup12.ResourceID = null;
            this.acLayoutControlGroup12.Size = new System.Drawing.Size(551, 573);
            this.acLayoutControlGroup12.TextVisible = false;
            this.acLayoutControlGroup12.ToolTipID = null;
            this.acLayoutControlGroup12.UseResourceID = false;
            this.acLayoutControlGroup12.UseToolTipID = false;
            // 
            // acLayoutControlItem44
            // 
            this.acLayoutControlItem44.Control = this.acTextEdit1;
            this.acLayoutControlItem44.CustomizationFormText = "표시컬럼";
            this.acLayoutControlItem44.IsHeader = false;
            this.acLayoutControlItem44.IsTitle = false;
            this.acLayoutControlItem44.Location = new System.Drawing.Point(0, 0);
            this.acLayoutControlItem44.Name = "acLayoutControlItem44";
            this.acLayoutControlItem44.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.acLayoutControlItem44.ResourceID = "GC5AAON8";
            this.acLayoutControlItem44.Size = new System.Drawing.Size(551, 30);
            this.acLayoutControlItem44.Text = "표시컬럼";
            this.acLayoutControlItem44.TextSize = new System.Drawing.Size(40, 14);
            this.acLayoutControlItem44.ToolTipID = "9VMPEQEM";
            this.acLayoutControlItem44.ToolTipStdCode = null;
            this.acLayoutControlItem44.UseResourceID = true;
            this.acLayoutControlItem44.UseToolTipID = true;
            // 
            // acLayoutControlItem5
            // 
            this.acLayoutControlItem5.Control = this.acCheckEdit1;
            this.acLayoutControlItem5.CustomizationFormText = "acLayoutControlItem5";
            this.acLayoutControlItem5.IsHeader = false;
            this.acLayoutControlItem5.IsTitle = false;
            this.acLayoutControlItem5.Location = new System.Drawing.Point(0, 30);
            this.acLayoutControlItem5.Name = "acLayoutControlItem5";
            this.acLayoutControlItem5.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.acLayoutControlItem5.ResourceID = "FU0I0K6O";
            this.acLayoutControlItem5.Size = new System.Drawing.Size(551, 30);
            this.acLayoutControlItem5.Text = "acLayoutControlItem5";
            this.acLayoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.acLayoutControlItem5.TextVisible = false;
            this.acLayoutControlItem5.ToolTipID = "XYA35FKQ";
            this.acLayoutControlItem5.ToolTipStdCode = null;
            this.acLayoutControlItem5.UseResourceID = true;
            this.acLayoutControlItem5.UseToolTipID = true;
            // 
            // acLayoutControlItem1
            // 
            this.acLayoutControlItem1.Control = this.acGridControl2;
            this.acLayoutControlItem1.CustomizationFormText = "acLayoutControlItem1";
            this.acLayoutControlItem1.IsHeader = false;
            this.acLayoutControlItem1.IsTitle = false;
            this.acLayoutControlItem1.Location = new System.Drawing.Point(0, 60);
            this.acLayoutControlItem1.Name = "acLayoutControlItem1";
            this.acLayoutControlItem1.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.acLayoutControlItem1.ResourceID = null;
            this.acLayoutControlItem1.Size = new System.Drawing.Size(551, 513);
            this.acLayoutControlItem1.Text = "acLayoutControlItem1";
            this.acLayoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.acLayoutControlItem1.TextVisible = false;
            this.acLayoutControlItem1.ToolTipID = null;
            this.acLayoutControlItem1.ToolTipStdCode = null;
            this.acLayoutControlItem1.UseResourceID = false;
            this.acLayoutControlItem1.UseToolTipID = false;
            // 
            // SYS04B_M0A
            // 
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "SYS04B_M0A";
            this.Size = new System.Drawing.Size(1023, 639);
            this.Controls.SetChildIndex(this.barDockControlTop, 0);
            this.Controls.SetChildIndex(this.barDockControlBottom, 0);
            this.Controls.SetChildIndex(this.barDockControlRight, 0);
            this.Controls.SetChildIndex(this.barDockControlLeft, 0);
            this.Controls.SetChildIndex(this.pnlScreenBase, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pnlScreenBase)).EndInit();
            this.pnlScreenBase.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.acBarManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acSplitContainerControl4.Panel1)).EndInit();
            this.acSplitContainerControl4.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.acSplitContainerControl4.Panel2)).EndInit();
            this.acSplitContainerControl4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.acSplitContainerControl4)).EndInit();
            this.acSplitContainerControl4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.acGridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControl1)).EndInit();
            this.acLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.acGridControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acCheckEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acTextEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlGroup12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem44)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem1)).EndInit();
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
        private ControlManager.acBarStaticItem statusBarLog;
        private ControlManager.acBarButtonItem barItemSave;
        private ControlManager.acSplitContainerControl acSplitContainerControl4;
        private ControlManager.acGridControl acGridControl1;
        private ControlManager.acGridView acGridView1;
        private ControlManager.acLayoutControl acLayoutControl1;
        private ControlManager.acGridControl acGridControl2;
        private ControlManager.acGridView acGridView2;
        private ControlManager.acCheckEdit acCheckEdit1;
        private ControlManager.acTextEdit acTextEdit1;
        private ControlManager.acLayoutControlGroup acLayoutControlGroup12;
        private ControlManager.acLayoutControlItem acLayoutControlItem44;
        private ControlManager.acLayoutControlItem acLayoutControlItem5;
        private ControlManager.acLayoutControlItem acLayoutControlItem1;
        

    }
}
