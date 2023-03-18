namespace ControlManager
{
    partial class acLoadableMcForm
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
            this.acBarManager1 = new ControlManager.acBarManager(this.components);
            this.bar2 = new ControlManager.acBar();
            this.acBarButtonItem1 = new ControlManager.acBarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.acBarButtonItem2 = new ControlManager.acBarButtonItem();
            this.acBarButtonItem3 = new ControlManager.acBarButtonItem();
            this.gcSel = new ControlManager.acGridControl();
            this.gvSel = new ControlManager.acGridView();
            this.gcNotSel = new ControlManager.acGridControl();
            this.gvNotSel = new ControlManager.acGridView();
            this.popupMenu1 = new DevExpress.XtraBars.PopupMenu(this.components);
            this.popupMenu2 = new DevExpress.XtraBars.PopupMenu(this.components);
            this.acSplitContainerControl1 = new ControlManager.acSplitContainerControl();
            this.acLayoutControl2 = new ControlManager.acLayoutControl();
            this.acLayoutControlGroup1 = new ControlManager.acLayoutControlGroup();
            this.acLayoutControlItem1 = new ControlManager.acLayoutControlItem();
            this.acLayoutControl3 = new ControlManager.acLayoutControl();
            this.acLayoutControlGroup2 = new ControlManager.acLayoutControlGroup();
            this.acLayoutControlItem2 = new ControlManager.acLayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.acBarManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcSel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcNotSel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvNotSel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acSplitContainerControl1)).BeginInit();
            this.acSplitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControl2)).BeginInit();
            this.acLayoutControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControl3)).BeginInit();
            this.acLayoutControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // acBarManager1
            // 
            this.acBarManager1.AllowCustomization = false;
            this.acBarManager1.AllowQuickCustomization = false;
            this.acBarManager1.AllowShowToolbarsPopup = false;
            this.acBarManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2});
            this.acBarManager1.CloseButtonAffectAllTabs = false;
            this.acBarManager1.DockControls.Add(this.barDockControlTop);
            this.acBarManager1.DockControls.Add(this.barDockControlBottom);
            this.acBarManager1.DockControls.Add(this.barDockControlLeft);
            this.acBarManager1.DockControls.Add(this.barDockControlRight);
            this.acBarManager1.Form = this;
            this.acBarManager1.IsLoadDefaultLayout = true;
            this.acBarManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.acBarButtonItem1,
            this.acBarButtonItem2,
            this.acBarButtonItem3});
            this.acBarManager1.MainMenu = this.bar2;
            this.acBarManager1.MaxItemId = 3;
            // 
            // bar2
            // 
            this.bar2.BarName = "도구상자";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.acBarButtonItem1)});
            this.bar2.OptionsBar.AllowQuickCustomization = false;
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.ResourceID = "I7LE433K";
            this.bar2.Text = "도구상자";
            this.bar2.ToolTipID = null;
            this.bar2.UseResourceID = true;
            this.bar2.UseToolTipID = false;
            // 
            // acBarButtonItem1
            // 
            this.acBarButtonItem1.ButtonShortCutType = ControlManager.acBarManager.emBarShortCutType.SAVE;
            this.acBarButtonItem1.Caption = "acBarButtonItem1";
            this.acBarButtonItem1.Glyph = global::ControlManager.Resource.document_save_close_x22;
            this.acBarButtonItem1.Id = 0;
            this.acBarButtonItem1.Name = "acBarButtonItem1";
            this.acBarButtonItem1.ResourceID = null;
            this.acBarButtonItem1.ToolTipID = "TWPQ2QB2";
            this.acBarButtonItem1.UseResourceID = false;
            this.acBarButtonItem1.UseToolTipID = true;
            this.acBarButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.acBarButtonItem1_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(607, 30);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 316);
            this.barDockControlBottom.Size = new System.Drawing.Size(607, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 30);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 286);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(607, 30);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 286);
            // 
            // acBarButtonItem2
            // 
            this.acBarButtonItem2.Caption = "이동";
            this.acBarButtonItem2.Glyph = global::ControlManager.Resource.go_next_x16;
            this.acBarButtonItem2.Id = 1;
            this.acBarButtonItem2.Name = "acBarButtonItem2";
            this.acBarButtonItem2.ResourceID = "4E1488QE";
            this.acBarButtonItem2.ToolTipID = null;
            this.acBarButtonItem2.UseResourceID = true;
            this.acBarButtonItem2.UseToolTipID = false;
            this.acBarButtonItem2.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.acBarButtonItem2_ItemClick);
            // 
            // acBarButtonItem3
            // 
            this.acBarButtonItem3.Caption = "이동";
            this.acBarButtonItem3.Glyph = global::ControlManager.Resource.go_previous_x16;
            this.acBarButtonItem3.Id = 2;
            this.acBarButtonItem3.Name = "acBarButtonItem3";
            this.acBarButtonItem3.ResourceID = "4E1488QE";
            this.acBarButtonItem3.ToolTipID = null;
            this.acBarButtonItem3.UseResourceID = true;
            this.acBarButtonItem3.UseToolTipID = false;
            this.acBarButtonItem3.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.acBarButtonItem3_ItemClick);
            // 
            // gcSel
            // 
            this.gcSel.AllowDrop = true;
            this.gcSel.Location = new System.Drawing.Point(5, 22);
            this.gcSel.MainView = this.gvSel;
            this.gcSel.Name = "gcSel";
            this.gcSel.Size = new System.Drawing.Size(290, 259);
            this.gcSel.TabIndex = 9;
            this.gcSel.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvSel});
            // 
            // gvSel
            // 
            this.gvSel.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gvSel.GridControl = this.gcSel;
            this.gvSel.Name = "gvSel";
            this.gvSel.OptionsBehavior.AutoPopulateColumns = false;
            this.gvSel.OptionsCustomization.AllowColumnMoving = false;
            this.gvSel.OptionsCustomization.AllowFilter = false;
            this.gvSel.OptionsCustomization.AllowGroup = false;
            this.gvSel.OptionsCustomization.AllowSort = false;
            this.gvSel.OptionsLayout.Columns.StoreAllOptions = true;
            this.gvSel.OptionsLayout.StoreAllOptions = true;
            this.gvSel.OptionsMenu.EnableColumnMenu = false;
            this.gvSel.OptionsMenu.EnableFooterMenu = false;
            this.gvSel.OptionsMenu.EnableGroupPanelMenu = false;
            this.gvSel.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gvSel.OptionsSelection.MultiSelect = true;
            this.gvSel.OptionsView.RowAutoHeight = true;
            this.gvSel.OptionsView.ShowGroupPanel = false;
            this.gvSel.OptionsView.ShowIndicator = false;
            this.gvSel.ParentControl = this;
            this.gvSel.RowHeight = 30;
            this.gvSel.SaveFileName = null;
            // 
            // gcNotSel
            // 
            this.gcNotSel.Location = new System.Drawing.Point(5, 22);
            this.gcNotSel.MainView = this.gvNotSel;
            this.gcNotSel.Name = "gcNotSel";
            this.gcNotSel.Size = new System.Drawing.Size(292, 259);
            this.gcNotSel.TabIndex = 8;
            this.gcNotSel.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvNotSel});
            // 
            // gvNotSel
            // 
            this.gvNotSel.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gvNotSel.GridControl = this.gcNotSel;
            this.gvNotSel.Name = "gvNotSel";
            this.gvNotSel.OptionsBehavior.AutoPopulateColumns = false;
            this.gvNotSel.OptionsCustomization.AllowColumnMoving = false;
            this.gvNotSel.OptionsCustomization.AllowFilter = false;
            this.gvNotSel.OptionsCustomization.AllowGroup = false;
            this.gvNotSel.OptionsCustomization.AllowSort = false;
            this.gvNotSel.OptionsLayout.Columns.StoreAllOptions = true;
            this.gvNotSel.OptionsLayout.StoreAllOptions = true;
            this.gvNotSel.OptionsMenu.EnableColumnMenu = false;
            this.gvNotSel.OptionsMenu.EnableFooterMenu = false;
            this.gvNotSel.OptionsMenu.EnableGroupPanelMenu = false;
            this.gvNotSel.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gvNotSel.OptionsSelection.MultiSelect = true;
            this.gvNotSel.OptionsView.RowAutoHeight = true;
            this.gvNotSel.OptionsView.ShowGroupPanel = false;
            this.gvNotSel.OptionsView.ShowIndicator = false;
            this.gvNotSel.ParentControl = this;
            this.gvNotSel.RowHeight = 30;
            this.gvNotSel.SaveFileName = null;
            // 
            // popupMenu1
            // 
            this.popupMenu1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.acBarButtonItem2)});
            this.popupMenu1.Manager = this.acBarManager1;
            this.popupMenu1.Name = "popupMenu1";
            // 
            // popupMenu2
            // 
            this.popupMenu2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.acBarButtonItem3)});
            this.popupMenu2.Manager = this.acBarManager1;
            this.popupMenu2.Name = "popupMenu2";
            // 
            // acSplitContainerControl1
            // 
            this.acSplitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.acSplitContainerControl1.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.None;
            this.acSplitContainerControl1.Location = new System.Drawing.Point(0, 30);
            this.acSplitContainerControl1.Name = "acSplitContainerControl1";
            this.acSplitContainerControl1.Panel1.Controls.Add(this.acLayoutControl2);
            this.acSplitContainerControl1.Panel1.Text = "Panel1";
            this.acSplitContainerControl1.Panel2.Controls.Add(this.acLayoutControl3);
            this.acSplitContainerControl1.Panel2.Text = "Panel2";
            this.acSplitContainerControl1.Size = new System.Drawing.Size(607, 286);
            this.acSplitContainerControl1.SplitterPosition = 302;
            this.acSplitContainerControl1.TabIndex = 11;
            this.acSplitContainerControl1.Text = "acSplitContainerControl1";
            // 
            // acLayoutControl2
            // 
            this.acLayoutControl2.AllowCustomizationMenu = false;
            this.acLayoutControl2.AutoScroll = false;
            this.acLayoutControl2.ContainerName = null;
            this.acLayoutControl2.Controls.Add(this.gcNotSel);
            this.acLayoutControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.acLayoutControl2.LayoutType = ControlManager.acLayoutControl.emLayoutType.NONE;
            this.acLayoutControl2.Location = new System.Drawing.Point(0, 0);
            this.acLayoutControl2.Name = "acLayoutControl2";
            this.acLayoutControl2.ParentControl = null;
            this.acLayoutControl2.Root = this.acLayoutControlGroup1;
            this.acLayoutControl2.Size = new System.Drawing.Size(302, 286);
            this.acLayoutControl2.TabIndex = 0;
            this.acLayoutControl2.Text = "acLayoutControl2";
            // 
            // acLayoutControlGroup1
            // 
            this.acLayoutControlGroup1.CustomizationFormText = "acLayoutControlGroup1";
            this.acLayoutControlGroup1.GroupBordersVisible = false;
            this.acLayoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.acLayoutControlItem1});
            this.acLayoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.acLayoutControlGroup1.Name = "acLayoutControlGroup1";
            this.acLayoutControlGroup1.ResourceID = null;
            this.acLayoutControlGroup1.Size = new System.Drawing.Size(302, 286);
            this.acLayoutControlGroup1.Text = "acLayoutControlGroup1";
            this.acLayoutControlGroup1.TextVisible = false;
            this.acLayoutControlGroup1.ToolTipID = null;
            this.acLayoutControlGroup1.UseResourceID = false;
            this.acLayoutControlGroup1.UseToolTipID = false;
            // 
            // acLayoutControlItem1
            // 
            this.acLayoutControlItem1.Control = this.gcNotSel;
            this.acLayoutControlItem1.CustomizationFormText = "가능한 가용설비";
            this.acLayoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.acLayoutControlItem1.Name = "acLayoutControlItem1";
            this.acLayoutControlItem1.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.acLayoutControlItem1.ResourceID = "S50FNOEB";
            this.acLayoutControlItem1.Size = new System.Drawing.Size(302, 286);
            this.acLayoutControlItem1.Text = "가능한 가용설비";
            this.acLayoutControlItem1.TextLocation = DevExpress.Utils.Locations.Top;
            this.acLayoutControlItem1.TextSize = new System.Drawing.Size(88, 14);
            this.acLayoutControlItem1.ToolTipID = "EJAZM50F";
            this.acLayoutControlItem1.UseResourceID = true;
            this.acLayoutControlItem1.UseToolTipID = true;
            // 
            // acLayoutControl3
            // 
            this.acLayoutControl3.AllowCustomizationMenu = false;
            this.acLayoutControl3.AutoScroll = false;
            this.acLayoutControl3.ContainerName = null;
            this.acLayoutControl3.Controls.Add(this.gcSel);
            this.acLayoutControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.acLayoutControl3.LayoutType = ControlManager.acLayoutControl.emLayoutType.NONE;
            this.acLayoutControl3.Location = new System.Drawing.Point(0, 0);
            this.acLayoutControl3.Name = "acLayoutControl3";
            this.acLayoutControl3.ParentControl = null;
            this.acLayoutControl3.Root = this.acLayoutControlGroup2;
            this.acLayoutControl3.Size = new System.Drawing.Size(300, 286);
            this.acLayoutControl3.TabIndex = 0;
            this.acLayoutControl3.Text = "acLayoutControl3";
            // 
            // acLayoutControlGroup2
            // 
            this.acLayoutControlGroup2.CustomizationFormText = "acLayoutControlGroup2";
            this.acLayoutControlGroup2.GroupBordersVisible = false;
            this.acLayoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.acLayoutControlItem2});
            this.acLayoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.acLayoutControlGroup2.Name = "acLayoutControlGroup2";
            this.acLayoutControlGroup2.ResourceID = null;
            this.acLayoutControlGroup2.Size = new System.Drawing.Size(300, 286);
            this.acLayoutControlGroup2.Text = "acLayoutControlGroup2";
            this.acLayoutControlGroup2.TextVisible = false;
            this.acLayoutControlGroup2.ToolTipID = null;
            this.acLayoutControlGroup2.UseResourceID = false;
            this.acLayoutControlGroup2.UseToolTipID = false;
            // 
            // acLayoutControlItem2
            // 
            this.acLayoutControlItem2.Control = this.gcSel;
            this.acLayoutControlItem2.CustomizationFormText = "선택된 가용설비";
            this.acLayoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.acLayoutControlItem2.Name = "acLayoutControlItem2";
            this.acLayoutControlItem2.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.acLayoutControlItem2.ResourceID = "2LNGWQB2";
            this.acLayoutControlItem2.Size = new System.Drawing.Size(300, 286);
            this.acLayoutControlItem2.Text = "선택된 가용설비";
            this.acLayoutControlItem2.TextLocation = DevExpress.Utils.Locations.Top;
            this.acLayoutControlItem2.TextSize = new System.Drawing.Size(88, 14);
            this.acLayoutControlItem2.ToolTipID = "ZR4RCFC8";
            this.acLayoutControlItem2.UseResourceID = true;
            this.acLayoutControlItem2.UseToolTipID = true;
            // 
            // acLoadableMcForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(607, 316);
            this.Controls.Add(this.acSplitContainerControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "acLoadableMcForm";
            this.ResourceID = "40011";
            this.Text = "가용설비";
            ((System.ComponentModel.ISupportInitialize)(this.acBarManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcSel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcNotSel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvNotSel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acSplitContainerControl1)).EndInit();
            this.acSplitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControl2)).EndInit();
            this.acLayoutControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControl3)).EndInit();
            this.acLayoutControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ControlManager.acBarManager acBarManager1;
        private ControlManager.acBar bar2;

        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private ControlManager.acBarButtonItem acBarButtonItem1;
        private ControlManager.acGridControl gcNotSel;
        private ControlManager.acGridView gvNotSel;
        private ControlManager.acGridControl gcSel;
        private ControlManager.acGridView gvSel;
        private ControlManager.acBarButtonItem acBarButtonItem2;
        private DevExpress.XtraBars.PopupMenu popupMenu1;
        private ControlManager.acBarButtonItem acBarButtonItem3;
        private DevExpress.XtraBars.PopupMenu popupMenu2;
        private ControlManager.acSplitContainerControl acSplitContainerControl1;
        private ControlManager.acLayoutControl acLayoutControl2;
        private ControlManager.acLayoutControlGroup acLayoutControlGroup1;
        private ControlManager.acLayoutControlItem acLayoutControlItem1;
        private ControlManager.acLayoutControl acLayoutControl3;
        private ControlManager.acLayoutControlGroup acLayoutControlGroup2;
        private ControlManager.acLayoutControlItem acLayoutControlItem2;
    }
}