namespace ControlManager
{
    partial class acGridViewUserCustomReportManager
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(acGridViewUserCustomReportManager));
            this.acGridControl1 = new ControlManager.acGridControl();
            this.acGridView1 = new ControlManager.acGridView();
            this.acLayoutControl1 = new ControlManager.acLayoutControl();
            this.layoutControlGroup1 = new ControlManager.acLayoutControlGroup();
            this.layoutControlItem1 = new ControlManager.acLayoutControlItem();
            this.acBarManager1 = new ControlManager.acBarManager(this.components);
            this.bar1 = new ControlManager.acBar();
            this.btnNew = new ControlManager.acBarButtonItem();
            this.btnOpen = new ControlManager.acBarButtonItem();
            this.barButtonItem1 = new ControlManager.acBarButtonItem();
            this.btnApply = new ControlManager.acBarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            ((System.ComponentModel.ISupportInitialize)(this.acGridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControl1)).BeginInit();
            this.acLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acBarManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // acGridControl1
            // 
            this.acGridControl1.DataMember = "Query";
            this.acGridControl1.IsCustomReportExcel = false;
            this.acGridControl1.Location = new System.Drawing.Point(15, 15);
            this.acGridControl1.MainView = this.acGridView1;
            this.acGridControl1.Name = "acGridControl1";
            this.acGridControl1.Size = new System.Drawing.Size(441, 270);
            this.acGridControl1.TabIndex = 0;
            this.acGridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.acGridView1});
            // 
            // acGridView1
            // 
            this.acGridView1.ColumnPanelRowHeight = 25;
            this.acGridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.acGridView1.GridControl = this.acGridControl1;
            this.acGridView1.IsUserStyle = false;
            this.acGridView1.Name = "acGridView1";
            this.acGridView1.NoApplyEditableCellColor = false;
            this.acGridView1.OptionsBehavior.AutoPopulateColumns = false;
            this.acGridView1.OptionsCustomization.AllowRowSizing = true;
            this.acGridView1.OptionsLayout.Columns.StoreAllOptions = true;
            this.acGridView1.OptionsLayout.StoreAllOptions = true;
            this.acGridView1.OptionsLayout.StoreAppearance = true;
            this.acGridView1.OptionsMenu.EnableColumnMenu = false;
            this.acGridView1.OptionsMenu.EnableFooterMenu = false;
            this.acGridView1.OptionsMenu.EnableGroupPanelMenu = false;
            this.acGridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.acGridView1.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.acGridView1.OptionsSelection.EnableAppearanceHideSelection = false;
            this.acGridView1.OptionsView.RowAutoHeight = true;
            this.acGridView1.OptionsView.ShowGroupPanel = false;
            this.acGridView1.OptionsView.ShowIndicator = false;
            this.acGridView1.ParentControl = this;
            this.acGridView1.RowHeight = 30;
            this.acGridView1.SaveFileName = null;
            // 
            // acLayoutControl1
            // 
            this.acLayoutControl1.AllowCustomization = false;
            this.acLayoutControl1.AutoScroll = false;
            this.acLayoutControl1.ContainerName = null;
            this.acLayoutControl1.Controls.Add(this.acGridControl1);
            this.acLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.acLayoutControl1.LayoutType = ControlManager.acLayoutControl.emLayoutType.NONE;
            this.acLayoutControl1.Location = new System.Drawing.Point(0, 34);
            this.acLayoutControl1.Name = "acLayoutControl1";
            this.acLayoutControl1.ParentControl = null;
            this.acLayoutControl1.Root = this.layoutControlGroup1;
            this.acLayoutControl1.Size = new System.Drawing.Size(471, 300);
            this.acLayoutControl1.TabIndex = 1;
            this.acLayoutControl1.Text = "acLayoutControl1";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.IsHeader = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.ResourceID = null;
            this.layoutControlGroup1.Size = new System.Drawing.Size(471, 300);
            this.layoutControlGroup1.TextVisible = false;
            this.layoutControlGroup1.ToolTipID = null;
            this.layoutControlGroup1.UseResourceID = false;
            this.layoutControlGroup1.UseToolTipID = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.acGridControl1;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.IsHeader = false;
            this.layoutControlItem1.IsTitle = false;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlItem1.ResourceID = null;
            this.layoutControlItem1.Size = new System.Drawing.Size(451, 280);
            this.layoutControlItem1.Text = "layoutControlItem1";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            this.layoutControlItem1.ToolTipID = null;
            this.layoutControlItem1.ToolTipStdCode = null;
            this.layoutControlItem1.UseResourceID = false;
            this.layoutControlItem1.UseToolTipID = false;
            // 
            // acBarManager1
            // 
            this.acBarManager1.AllowCustomization = false;
            this.acBarManager1.AllowQuickCustomization = false;
            this.acBarManager1.AllowShowToolbarsPopup = false;
            this.acBarManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1});
            this.acBarManager1.CloseButtonAffectAllTabs = false;
            this.acBarManager1.DockControls.Add(this.barDockControlTop);
            this.acBarManager1.DockControls.Add(this.barDockControlBottom);
            this.acBarManager1.DockControls.Add(this.barDockControlLeft);
            this.acBarManager1.DockControls.Add(this.barDockControlRight);
            this.acBarManager1.Form = this;
            this.acBarManager1.IsLoadDefaultLayout = true;
            this.acBarManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barButtonItem1,
            this.btnNew,
            this.btnOpen,
            this.btnApply});
            this.acBarManager1.MainMenu = this.bar1;
            this.acBarManager1.MaxItemId = 6;
            // 
            // bar1
            // 
            this.bar1.BarItemHorzIndent = 10;
            this.bar1.BarItemVertIndent = 5;
            this.bar1.BarName = "Custom 2";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnNew),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnOpen),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnApply)});
            this.bar1.OptionsBar.AllowQuickCustomization = false;
            this.bar1.OptionsBar.MultiLine = true;
            this.bar1.OptionsBar.UseWholeRow = true;
            this.bar1.ResourceID = "I7LE433K";
            this.bar1.Text = "도구상자";
            this.bar1.ToolTipID = null;
            this.bar1.UseResourceID = true;
            this.bar1.UseToolTipID = false;
            // 
            // btnNew
            // 
            this.btnNew.Caption = "등록";
            this.btnNew.Id = 3;
            this.btnNew.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnNew.ImageOptions.Image")));
            this.btnNew.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnNew.ImageOptions.LargeImage")));
            this.btnNew.Name = "btnNew";
            this.btnNew.ResourceID = null;
            this.btnNew.ToolTipID = null;
            this.btnNew.UseResourceID = false;
            this.btnNew.UseToolTipID = false;
            this.btnNew.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNew_ItemClick);
            // 
            // btnOpen
            // 
            this.btnOpen.Caption = "열기";
            this.btnOpen.Id = 4;
            this.btnOpen.ImageOptions.Image = global::ControlManager.Resource.document_open;
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.ResourceID = null;
            this.btnOpen.ToolTipID = null;
            this.btnOpen.UseResourceID = false;
            this.btnOpen.UseToolTipID = false;
            this.btnOpen.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnOpen_ItemClick);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.barButtonItem1.ButtonShortCutType = ControlManager.acBarManager.emBarShortCutType.DEL;
            this.barButtonItem1.Caption = "삭제";
            this.barButtonItem1.Id = 2;
            this.barButtonItem1.ImageOptions.Image = global::ControlManager.Resource.edit_delete_x22;
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.ResourceID = null;
            this.barButtonItem1.ToolTipID = "2AJQS0WU";
            this.barButtonItem1.UseResourceID = false;
            this.barButtonItem1.UseToolTipID = true;
            this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
            // 
            // btnApply
            // 
            this.btnApply.Caption = "양식 지정";
            this.btnApply.Id = 5;
            this.btnApply.ImageOptions.Image = global::ControlManager.Resource.dialog_apply_x22;
            this.btnApply.Name = "btnApply";
            this.btnApply.ResourceID = null;
            this.btnApply.ToolTipID = null;
            this.btnApply.UseResourceID = false;
            this.btnApply.UseToolTipID = false;
            this.btnApply.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnApply_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.acBarManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(471, 34);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 334);
            this.barDockControlBottom.Manager = this.acBarManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(471, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 34);
            this.barDockControlLeft.Manager = this.acBarManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 300);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(471, 34);
            this.barDockControlRight.Manager = this.acBarManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 300);
            // 
            // acGridViewUserCustomReportManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(471, 334);
            this.Controls.Add(this.acLayoutControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.IconOptions.ShowIcon = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "acGridViewUserCustomReportManager";
            this.ResourceID = "";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "사용자 양식 관리";
            ((System.ComponentModel.ISupportInitialize)(this.acGridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControl1)).EndInit();
            this.acLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acBarManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private acGridControl acGridControl1;
        private acGridView acGridView1;
        private acLayoutControl acLayoutControl1;
        private acLayoutControlGroup layoutControlGroup1;
        private acLayoutControlItem layoutControlItem1;
        private ControlManager.acBarManager acBarManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private ControlManager.acBar bar1;
        private ControlManager.acBarButtonItem barButtonItem1;
        private acBarButtonItem btnNew;
        private acBarButtonItem btnOpen;
        private acBarButtonItem btnApply;
    }
}