namespace POP
{
    partial class POP20A_D0A
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
			this.barItemSave = new ControlManager.acBarButtonItem();
			this.barItemSaveClose = new ControlManager.acBarButtonItem();
			this.barItemFixedWindow = new ControlManager.acBarCheckItem();
			this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
			this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
			this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
			this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
			this.btnDel = new ControlManager.acBarButtonItem();
			this.btnAdd = new ControlManager.acBarButtonItem();
			this.acLayoutControl1 = new ControlManager.acLayoutControl();
			this.acSplitContainerControl1 = new ControlManager.acSplitContainerControl();
			this.acGridControl1 = new ControlManager.acGridControl();
			this.acGridView1 = new ControlManager.acGridView();
			this.acGridControl2 = new ControlManager.acGridControl();
			this.acGridView2 = new ControlManager.acGridView();
			this.layoutControlGroup1 = new ControlManager.acLayoutControlGroup();
			this.acLayoutControlItem1 = new ControlManager.acLayoutControlItem();
			this.popupMenu1 = new DevExpress.XtraBars.PopupMenu(this.components);
			this.popupMenu2 = new DevExpress.XtraBars.PopupMenu(this.components);
			((System.ComponentModel.ISupportInitialize)(this.acBarManager1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.acLayoutControl1)).BeginInit();
			this.acLayoutControl1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.acSplitContainerControl1)).BeginInit();
			this.acSplitContainerControl1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.acGridControl1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.acGridView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.acGridControl2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.acGridView2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.popupMenu2)).BeginInit();
			this.SuspendLayout();
			// 
			// acBarManager1
			// 
			this.acBarManager1.AllowCustomization = false;
			this.acBarManager1.AllowMoveBarOnToolbar = false;
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
            this.barItemSaveClose,
            this.barItemSave,
            this.barItemFixedWindow,
            this.btnDel,
            this.btnAdd});
			this.acBarManager1.MainMenu = this.bar2;
			this.acBarManager1.MaxItemId = 9;
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
            new DevExpress.XtraBars.LinkPersistInfo(this.barItemSave),
            new DevExpress.XtraBars.LinkPersistInfo(this.barItemSaveClose),
            new DevExpress.XtraBars.LinkPersistInfo(this.barItemFixedWindow)});
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
			this.barItemSave.Caption = "acBarButtonItem2";
			this.barItemSave.Glyph = global::POP.Resource.document_save_2x;
			this.barItemSave.Id = 3;
			this.barItemSave.Name = "barItemSave";
			this.barItemSave.ResourceID = null;
			this.barItemSave.ToolTipID = "4UY7EZBZ";
			this.barItemSave.UseResourceID = false;
			this.barItemSave.UseToolTipID = true;
			this.barItemSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barItemSave_ItemClick);
			// 
			// barItemSaveClose
			// 
			this.barItemSaveClose.ButtonShortCutType = ControlManager.acBarManager.emBarShortCutType.SAVE;
			this.barItemSaveClose.Caption = "acBarButtonItem1";
			this.barItemSaveClose.Glyph = global::POP.Resource.document_save_close_2x;
			this.barItemSaveClose.Id = 0;
			this.barItemSaveClose.Name = "barItemSaveClose";
			this.barItemSaveClose.ResourceID = null;
			this.barItemSaveClose.ToolTipID = "TWPQ2QB2";
			this.barItemSaveClose.UseResourceID = false;
			this.barItemSaveClose.UseToolTipID = true;
			this.barItemSaveClose.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barItemSaveClose_ItemClick);
			// 
			// barItemFixedWindow
			// 
			this.barItemFixedWindow.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
			this.barItemFixedWindow.ButtonShortCutType = ControlManager.acBarManager.emBarShortCutType.WIN_LOCK;
			this.barItemFixedWindow.Caption = "acBarCheckItem1";
			this.barItemFixedWindow.Glyph = global::POP.Resource.emblem_readonly_2x;
			this.barItemFixedWindow.Id = 5;
			this.barItemFixedWindow.Name = "barItemFixedWindow";
			this.barItemFixedWindow.ResourceID = null;
			this.barItemFixedWindow.ToolTipID = "IPF2LX1S";
			this.barItemFixedWindow.UseResourceID = false;
			this.barItemFixedWindow.UseToolTipID = true;
			this.barItemFixedWindow.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.barItemFixedWindow_CheckedChanged);
			// 
			// barDockControlTop
			// 
			this.barDockControlTop.CausesValidation = false;
			this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
			this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
			this.barDockControlTop.Size = new System.Drawing.Size(747, 34);
			// 
			// barDockControlBottom
			// 
			this.barDockControlBottom.CausesValidation = false;
			this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.barDockControlBottom.Location = new System.Drawing.Point(0, 496);
			this.barDockControlBottom.Size = new System.Drawing.Size(747, 0);
			// 
			// barDockControlLeft
			// 
			this.barDockControlLeft.CausesValidation = false;
			this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
			this.barDockControlLeft.Location = new System.Drawing.Point(0, 34);
			this.barDockControlLeft.Size = new System.Drawing.Size(0, 462);
			// 
			// barDockControlRight
			// 
			this.barDockControlRight.CausesValidation = false;
			this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
			this.barDockControlRight.Location = new System.Drawing.Point(747, 34);
			this.barDockControlRight.Size = new System.Drawing.Size(0, 462);
			// 
			// btnDel
			// 
			this.btnDel.Caption = "삭제";
			this.btnDel.Glyph = global::POP.Resource.edit_delete_2x;
			this.btnDel.Id = 7;
			this.btnDel.Name = "btnDel";
			this.btnDel.ResourceID = null;
			this.btnDel.ToolTipID = null;
			this.btnDel.UseResourceID = false;
			this.btnDel.UseToolTipID = false;
			this.btnDel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDel_ItemClick);
			// 
			// btnAdd
			// 
			this.btnAdd.Caption = "추가";
			this.btnAdd.Glyph = global::POP.Resource.list_add_2x;
			this.btnAdd.Id = 8;
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.ResourceID = null;
			this.btnAdd.ToolTipID = null;
			this.btnAdd.UseResourceID = false;
			this.btnAdd.UseToolTipID = false;
			this.btnAdd.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAdd_ItemClick);
			// 
			// acLayoutControl1
			// 
			this.acLayoutControl1.AllowCustomizationMenu = false;
			this.acLayoutControl1.AutoScroll = false;
			this.acLayoutControl1.ContainerName = null;
			this.acLayoutControl1.Controls.Add(this.acSplitContainerControl1);
			this.acLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.acLayoutControl1.LayoutType = ControlManager.acLayoutControl.emLayoutType.NONE;
			this.acLayoutControl1.Location = new System.Drawing.Point(0, 34);
			this.acLayoutControl1.Name = "acLayoutControl1";
			this.acLayoutControl1.ParentControl = null;
			this.acLayoutControl1.Root = this.layoutControlGroup1;
			this.acLayoutControl1.Size = new System.Drawing.Size(747, 462);
			this.acLayoutControl1.TabIndex = 4;
			this.acLayoutControl1.Text = "acLayoutControl1";
			// 
			// acSplitContainerControl1
			// 
			this.acSplitContainerControl1.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.None;
			this.acSplitContainerControl1.Location = new System.Drawing.Point(5, 5);
			this.acSplitContainerControl1.Name = "acSplitContainerControl1";
			this.acSplitContainerControl1.Panel1.Controls.Add(this.acGridControl1);
			this.acSplitContainerControl1.Panel1.Text = "Panel1";
			this.acSplitContainerControl1.Panel2.Controls.Add(this.acGridControl2);
			this.acSplitContainerControl1.Panel2.Text = "Panel2";
			this.acSplitContainerControl1.ParentControl = null;
			this.acSplitContainerControl1.Size = new System.Drawing.Size(737, 452);
			this.acSplitContainerControl1.SplitterPosition = 369;
			this.acSplitContainerControl1.TabIndex = 4;
			this.acSplitContainerControl1.Text = "acSplitContainerControl1";
			// 
			// acGridControl1
			// 
			this.acGridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.acGridControl1.Location = new System.Drawing.Point(0, 0);
			this.acGridControl1.MainView = this.acGridView1;
			this.acGridControl1.MenuManager = this.acBarManager1;
			this.acGridControl1.Name = "acGridControl1";
			this.acGridControl1.Size = new System.Drawing.Size(369, 452);
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
			// acGridControl2
			// 
			this.acGridControl2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.acGridControl2.Location = new System.Drawing.Point(0, 0);
			this.acGridControl2.MainView = this.acGridView2;
			this.acGridControl2.MenuManager = this.acBarManager1;
			this.acGridControl2.Name = "acGridControl2";
			this.acGridControl2.Size = new System.Drawing.Size(363, 452);
			this.acGridControl2.TabIndex = 0;
			this.acGridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.acGridView2});
			// 
			// acGridView2
			// 
			this.acGridView2.ColumnPanelRowHeight = 25;
			this.acGridView2.GridControl = this.acGridControl2;
			this.acGridView2.IsUserStyle = false;
			this.acGridView2.Name = "acGridView2";
			this.acGridView2.NoApplyEditableCellColor = false;
			this.acGridView2.OptionsLayout.Columns.StoreAllOptions = true;
			this.acGridView2.OptionsLayout.StoreAllOptions = true;
			this.acGridView2.OptionsView.EnableAppearanceEvenRow = true;
			this.acGridView2.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.Button;
			this.acGridView2.OptionsView.RowAutoHeight = true;
			this.acGridView2.OptionsView.ShowGroupPanel = false;
			this.acGridView2.OptionsView.ShowIndicator = false;
			this.acGridView2.ParentControl = this;
			this.acGridView2.RowHeight = 25;
			this.acGridView2.SaveFileName = null;
			// 
			// layoutControlGroup1
			// 
			this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
			this.layoutControlGroup1.GroupBordersVisible = false;
			this.layoutControlGroup1.IsHeader = false;
			this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.acLayoutControlItem1});
			this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
			this.layoutControlGroup1.Name = "layoutControlGroup1";
			this.layoutControlGroup1.ResourceID = null;
			this.layoutControlGroup1.Size = new System.Drawing.Size(747, 462);
			this.layoutControlGroup1.Text = "layoutControlGroup1";
			this.layoutControlGroup1.TextVisible = false;
			this.layoutControlGroup1.ToolTipID = null;
			this.layoutControlGroup1.UseResourceID = false;
			this.layoutControlGroup1.UseToolTipID = false;
			// 
			// acLayoutControlItem1
			// 
			this.acLayoutControlItem1.Control = this.acSplitContainerControl1;
			this.acLayoutControlItem1.CustomizationFormText = "acLayoutControlItem1";
			this.acLayoutControlItem1.IsHeader = false;
			this.acLayoutControlItem1.IsTitle = false;
			this.acLayoutControlItem1.Location = new System.Drawing.Point(0, 0);
			this.acLayoutControlItem1.Name = "acLayoutControlItem1";
			this.acLayoutControlItem1.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
			this.acLayoutControlItem1.ResourceID = null;
			this.acLayoutControlItem1.Size = new System.Drawing.Size(747, 462);
			this.acLayoutControlItem1.Text = "acLayoutControlItem1";
			this.acLayoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
			this.acLayoutControlItem1.TextVisible = false;
			this.acLayoutControlItem1.ToolTipID = null;
			this.acLayoutControlItem1.ToolTipStdCode = null;
			this.acLayoutControlItem1.UseResourceID = false;
			this.acLayoutControlItem1.UseToolTipID = false;
			// 
			// popupMenu1
			// 
			this.popupMenu1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnDel)});
			this.popupMenu1.Manager = this.acBarManager1;
			this.popupMenu1.Name = "popupMenu1";
			// 
			// popupMenu2
			// 
			this.popupMenu2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnAdd)});
			this.popupMenu2.Manager = this.acBarManager1;
			this.popupMenu2.Name = "popupMenu2";
			// 
			// POP20A_D0A
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(747, 496);
			this.Controls.Add(this.acLayoutControl1);
			this.Controls.Add(this.barDockControlLeft);
			this.Controls.Add(this.barDockControlRight);
			this.Controls.Add(this.barDockControlBottom);
			this.Controls.Add(this.barDockControlTop);
			this.Name = "POP20A_D0A";
			this.ResourceID = "";
			this.Text = "공구 편집기";
			((System.ComponentModel.ISupportInitialize)(this.acBarManager1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.acLayoutControl1)).EndInit();
			this.acLayoutControl1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.acSplitContainerControl1)).EndInit();
			this.acSplitContainerControl1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.acGridControl1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.acGridView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.acGridControl2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.acGridView2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.popupMenu2)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private ControlManager.acBarManager acBarManager1;
        private ControlManager.acBar bar2;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private ControlManager.acBarButtonItem barItemSaveClose;
        private ControlManager.acLayoutControl acLayoutControl1;
        private ControlManager.acLayoutControlGroup layoutControlGroup1;
        private ControlManager.acBarButtonItem barItemSave;
        private ControlManager.acBarCheckItem barItemFixedWindow;
        private ControlManager.acSplitContainerControl acSplitContainerControl1;
        private ControlManager.acGridControl acGridControl1;
        private ControlManager.acGridView acGridView1;
        private ControlManager.acGridControl acGridControl2;
        private ControlManager.acGridView acGridView2;
        private ControlManager.acLayoutControlItem acLayoutControlItem1;
        private ControlManager.acBarButtonItem btnDel;
        private ControlManager.acBarButtonItem btnAdd;
        private DevExpress.XtraBars.PopupMenu popupMenu1;
        private DevExpress.XtraBars.PopupMenu popupMenu2;
    }
}