namespace HIS
{
    partial class HIS01A_D1A
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
            this.btnAdd = new ControlManager.acBarButtonItem();
            this.btnDel = new ControlManager.acBarButtonItem();
            this.acLayoutControl1 = new ControlManager.acLayoutControl();
            this.acCheckEdit1 = new ControlManager.acCheckEdit();
            this.acGridControl1 = new ControlManager.acGridControl();
            this.acGridView1 = new ControlManager.acGridView();
            this.acTextEdit3 = new ControlManager.acTextEdit();
            this.acTextEdit2 = new ControlManager.acTextEdit();
            this.acTextEdit1 = new ControlManager.acTextEdit();
            this.layoutControlGroup1 = new ControlManager.acLayoutControlGroup();
            this.acLayoutControlItem1 = new ControlManager.acLayoutControlItem();
            this.acLayoutControlItem5 = new ControlManager.acLayoutControlItem();
            this.acLayoutControlItem2 = new ControlManager.acLayoutControlItem();
            this.acLayoutControlItem4 = new ControlManager.acLayoutControlItem();
            this.acLayoutControlItem3 = new ControlManager.acLayoutControlItem();
            this.acSplitContainerControl1 = new ControlManager.acSplitContainerControl();
            this.acGridControl2 = new ControlManager.acGridControl();
            this.acGridView2 = new ControlManager.acGridView();
            ((System.ComponentModel.ISupportInitialize)(this.acBarManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControl1)).BeginInit();
            this.acLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.acCheckEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acGridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acTextEdit3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acTextEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acTextEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acSplitContainerControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acSplitContainerControl1.Panel1)).BeginInit();
            this.acSplitContainerControl1.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.acSplitContainerControl1.Panel2)).BeginInit();
            this.acSplitContainerControl1.Panel2.SuspendLayout();
            this.acSplitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.acGridControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acGridView2)).BeginInit();
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
            this.btnAdd,
            this.btnDel});
            this.acBarManager1.MainMenu = this.bar2;
            this.acBarManager1.MaxItemId = 11;
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
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barItemSave, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barItemSaveClose, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
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
            this.barItemSave.Caption = "저장";
            this.barItemSave.Id = 3;
            this.barItemSave.ImageOptions.Image = global::HIS.Resource.document_save_2x;
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
            this.barItemSaveClose.Caption = "저장 후 닫기";
            this.barItemSaveClose.Id = 0;
            this.barItemSaveClose.ImageOptions.Image = global::HIS.Resource.document_save_close_2x;
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
            this.barItemFixedWindow.Id = 5;
            this.barItemFixedWindow.ImageOptions.Image = global::HIS.Resource.emblem_readonly_2x;
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
            this.barDockControlTop.Manager = this.acBarManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(934, 36);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 489);
            this.barDockControlBottom.Manager = this.acBarManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(934, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 36);
            this.barDockControlLeft.Manager = this.acBarManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 453);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(934, 36);
            this.barDockControlRight.Manager = this.acBarManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 453);
            // 
            // btnAdd
            // 
            this.btnAdd.Id = 9;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.ResourceID = null;
            this.btnAdd.ToolTipID = null;
            this.btnAdd.UseResourceID = false;
            this.btnAdd.UseToolTipID = false;
            // 
            // btnDel
            // 
            this.btnDel.Id = 10;
            this.btnDel.Name = "btnDel";
            this.btnDel.ResourceID = null;
            this.btnDel.ToolTipID = null;
            this.btnDel.UseResourceID = false;
            this.btnDel.UseToolTipID = false;
            // 
            // acLayoutControl1
            // 
            this.acLayoutControl1.AllowCustomization = false;
            this.acLayoutControl1.AutoScroll = false;
            this.acLayoutControl1.ContainerName = null;
            this.acLayoutControl1.Controls.Add(this.acCheckEdit1);
            this.acLayoutControl1.Controls.Add(this.acGridControl1);
            this.acLayoutControl1.Controls.Add(this.acTextEdit3);
            this.acLayoutControl1.Controls.Add(this.acTextEdit2);
            this.acLayoutControl1.Controls.Add(this.acTextEdit1);
            this.acLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.acLayoutControl1.LayoutType = ControlManager.acLayoutControl.emLayoutType.NONE;
            this.acLayoutControl1.Location = new System.Drawing.Point(0, 0);
            this.acLayoutControl1.Name = "acLayoutControl1";
            this.acLayoutControl1.ParentControl = null;
            this.acLayoutControl1.Root = this.layoutControlGroup1;
            this.acLayoutControl1.Size = new System.Drawing.Size(447, 453);
            this.acLayoutControl1.TabIndex = 4;
            this.acLayoutControl1.Text = "acLayoutControl1";
            // 
            // acCheckEdit1
            // 
            this.acCheckEdit1.ColumnName = "IS_USE";
            this.acCheckEdit1.EditValue = true;
            this.acCheckEdit1.isReadyOnly = false;
            this.acCheckEdit1.isRequired = false;
            this.acCheckEdit1.Location = new System.Drawing.Point(228, 35);
            this.acCheckEdit1.MenuManager = this.acBarManager1;
            this.acCheckEdit1.Name = "acCheckEdit1";
            this.acCheckEdit1.Properties.Caption = "사용여부";
            this.acCheckEdit1.Properties.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            this.acCheckEdit1.Size = new System.Drawing.Size(214, 20);
            this.acCheckEdit1.StyleController = this.acLayoutControl1;
            this.acCheckEdit1.TabIndex = 4;
            this.acCheckEdit1.ToolTipID = null;
            this.acCheckEdit1.UseToolTipID = false;
            this.acCheckEdit1.Value = true;
            this.acCheckEdit1.ValueType = ControlManager.acCheckEdit.emValueType.DEFAULT;
            this.acCheckEdit1.Visible = false;
            // 
            // acGridControl1
            // 
            this.acGridControl1.Location = new System.Drawing.Point(5, 82);
            this.acGridControl1.MainView = this.acGridView1;
            this.acGridControl1.MenuManager = this.acBarManager1;
            this.acGridControl1.Name = "acGridControl1";
            this.acGridControl1.Size = new System.Drawing.Size(437, 366);
            this.acGridControl1.TabIndex = 5;
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
            // acTextEdit3
            // 
            this.acTextEdit3.ColumnName = "STD_PERIOD";
            this.acTextEdit3.isReadyOnly = true;
            this.acTextEdit3.Location = new System.Drawing.Point(97, 35);
            this.acTextEdit3.MaskType = ControlManager.acTextEdit.emMaskType.NUMBER;
            this.acTextEdit3.MenuManager = this.acBarManager1;
            this.acTextEdit3.Name = "acTextEdit3";
            this.acTextEdit3.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.acTextEdit3.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.acTextEdit3.Properties.Appearance.Options.UseBackColor = true;
            this.acTextEdit3.Properties.Appearance.Options.UseForeColor = true;
            this.acTextEdit3.Properties.Appearance.Options.UseTextOptions = true;
            this.acTextEdit3.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.acTextEdit3.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.WhiteSmoke;
            this.acTextEdit3.Properties.AppearanceReadOnly.ForeColor = System.Drawing.Color.Black;
            this.acTextEdit3.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.acTextEdit3.Properties.AppearanceReadOnly.Options.UseForeColor = true;
            this.acTextEdit3.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.acTextEdit3.Properties.ReadOnly = true;
            this.acTextEdit3.Size = new System.Drawing.Size(121, 20);
            this.acTextEdit3.StyleController = this.acLayoutControl1;
            this.acTextEdit3.TabIndex = 3;
            // 
            // acTextEdit2
            // 
            this.acTextEdit2.ColumnName = "MTN_NAME";
            this.acTextEdit2.isReadyOnly = true;
            this.acTextEdit2.Location = new System.Drawing.Point(320, 5);
            this.acTextEdit2.MaskType = ControlManager.acTextEdit.emMaskType.NONE;
            this.acTextEdit2.MenuManager = this.acBarManager1;
            this.acTextEdit2.Name = "acTextEdit2";
            this.acTextEdit2.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.acTextEdit2.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.acTextEdit2.Properties.Appearance.Options.UseBackColor = true;
            this.acTextEdit2.Properties.Appearance.Options.UseForeColor = true;
            this.acTextEdit2.Properties.Appearance.Options.UseTextOptions = true;
            this.acTextEdit2.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.acTextEdit2.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.WhiteSmoke;
            this.acTextEdit2.Properties.AppearanceReadOnly.ForeColor = System.Drawing.Color.Black;
            this.acTextEdit2.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.acTextEdit2.Properties.AppearanceReadOnly.Options.UseForeColor = true;
            this.acTextEdit2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.acTextEdit2.Properties.ReadOnly = true;
            this.acTextEdit2.Size = new System.Drawing.Size(122, 20);
            this.acTextEdit2.StyleController = this.acLayoutControl1;
            this.acTextEdit2.TabIndex = 2;
            // 
            // acTextEdit1
            // 
            this.acTextEdit1.ColumnName = "MTN_CODE";
            this.acTextEdit1.isReadyOnly = true;
            this.acTextEdit1.Location = new System.Drawing.Point(97, 5);
            this.acTextEdit1.MaskType = ControlManager.acTextEdit.emMaskType.NONE;
            this.acTextEdit1.MenuManager = this.acBarManager1;
            this.acTextEdit1.Name = "acTextEdit1";
            this.acTextEdit1.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.acTextEdit1.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.acTextEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.acTextEdit1.Properties.Appearance.Options.UseForeColor = true;
            this.acTextEdit1.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.WhiteSmoke;
            this.acTextEdit1.Properties.AppearanceReadOnly.ForeColor = System.Drawing.Color.Black;
            this.acTextEdit1.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.acTextEdit1.Properties.AppearanceReadOnly.Options.UseForeColor = true;
            this.acTextEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.acTextEdit1.Properties.ReadOnly = true;
            this.acTextEdit1.Size = new System.Drawing.Size(121, 20);
            this.acTextEdit1.StyleController = this.acLayoutControl1;
            this.acTextEdit1.TabIndex = 0;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.IsHeader = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.acLayoutControlItem1,
            this.acLayoutControlItem5,
            this.acLayoutControlItem2,
            this.acLayoutControlItem4,
            this.acLayoutControlItem3});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.ResourceID = null;
            this.layoutControlGroup1.Size = new System.Drawing.Size(447, 453);
            this.layoutControlGroup1.TextVisible = false;
            this.layoutControlGroup1.ToolTipID = null;
            this.layoutControlGroup1.UseResourceID = false;
            this.layoutControlGroup1.UseToolTipID = false;
            // 
            // acLayoutControlItem1
            // 
            this.acLayoutControlItem1.Control = this.acTextEdit1;
            this.acLayoutControlItem1.CustomizationFormText = "관리코드";
            this.acLayoutControlItem1.IsHeader = false;
            this.acLayoutControlItem1.IsTitle = false;
            this.acLayoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.acLayoutControlItem1.Name = "acLayoutControlItem1";
            this.acLayoutControlItem1.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.acLayoutControlItem1.ResourceID = null;
            this.acLayoutControlItem1.Size = new System.Drawing.Size(223, 30);
            this.acLayoutControlItem1.Text = "관리코드";
            this.acLayoutControlItem1.TextSize = new System.Drawing.Size(80, 14);
            this.acLayoutControlItem1.ToolTipID = null;
            this.acLayoutControlItem1.ToolTipStdCode = null;
            this.acLayoutControlItem1.UseResourceID = false;
            this.acLayoutControlItem1.UseToolTipID = false;
            // 
            // acLayoutControlItem5
            // 
            this.acLayoutControlItem5.Control = this.acTextEdit3;
            this.acLayoutControlItem5.CustomizationFormText = "표준보전주기(일)";
            this.acLayoutControlItem5.IsHeader = false;
            this.acLayoutControlItem5.IsTitle = false;
            this.acLayoutControlItem5.Location = new System.Drawing.Point(0, 30);
            this.acLayoutControlItem5.Name = "acLayoutControlItem5";
            this.acLayoutControlItem5.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.acLayoutControlItem5.ResourceID = null;
            this.acLayoutControlItem5.Size = new System.Drawing.Size(223, 30);
            this.acLayoutControlItem5.Text = "표준보전주기(일)";
            this.acLayoutControlItem5.TextSize = new System.Drawing.Size(80, 14);
            this.acLayoutControlItem5.ToolTipID = null;
            this.acLayoutControlItem5.ToolTipStdCode = null;
            this.acLayoutControlItem5.UseResourceID = false;
            this.acLayoutControlItem5.UseToolTipID = false;
            // 
            // acLayoutControlItem2
            // 
            this.acLayoutControlItem2.Control = this.acTextEdit2;
            this.acLayoutControlItem2.CustomizationFormText = "보전항목";
            this.acLayoutControlItem2.IsHeader = false;
            this.acLayoutControlItem2.IsTitle = false;
            this.acLayoutControlItem2.Location = new System.Drawing.Point(223, 0);
            this.acLayoutControlItem2.Name = "acLayoutControlItem2";
            this.acLayoutControlItem2.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.acLayoutControlItem2.ResourceID = null;
            this.acLayoutControlItem2.Size = new System.Drawing.Size(224, 30);
            this.acLayoutControlItem2.Text = "보전항목";
            this.acLayoutControlItem2.TextSize = new System.Drawing.Size(80, 14);
            this.acLayoutControlItem2.ToolTipID = null;
            this.acLayoutControlItem2.ToolTipStdCode = null;
            this.acLayoutControlItem2.UseResourceID = false;
            this.acLayoutControlItem2.UseToolTipID = false;
            // 
            // acLayoutControlItem4
            // 
            this.acLayoutControlItem4.Control = this.acGridControl1;
            this.acLayoutControlItem4.CustomizationFormText = "보전대상설비";
            this.acLayoutControlItem4.IsHeader = false;
            this.acLayoutControlItem4.IsTitle = false;
            this.acLayoutControlItem4.Location = new System.Drawing.Point(0, 60);
            this.acLayoutControlItem4.Name = "acLayoutControlItem4";
            this.acLayoutControlItem4.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.acLayoutControlItem4.ResourceID = null;
            this.acLayoutControlItem4.Size = new System.Drawing.Size(447, 393);
            this.acLayoutControlItem4.Text = "보전대상설비";
            this.acLayoutControlItem4.TextLocation = DevExpress.Utils.Locations.Top;
            this.acLayoutControlItem4.TextSize = new System.Drawing.Size(80, 14);
            this.acLayoutControlItem4.ToolTipID = null;
            this.acLayoutControlItem4.ToolTipStdCode = null;
            this.acLayoutControlItem4.UseResourceID = false;
            this.acLayoutControlItem4.UseToolTipID = false;
            // 
            // acLayoutControlItem3
            // 
            this.acLayoutControlItem3.Control = this.acCheckEdit1;
            this.acLayoutControlItem3.CustomizationFormText = "acLayoutControlItem3";
            this.acLayoutControlItem3.IsHeader = false;
            this.acLayoutControlItem3.IsTitle = false;
            this.acLayoutControlItem3.Location = new System.Drawing.Point(223, 30);
            this.acLayoutControlItem3.Name = "acLayoutControlItem3";
            this.acLayoutControlItem3.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.acLayoutControlItem3.ResourceID = null;
            this.acLayoutControlItem3.Size = new System.Drawing.Size(224, 30);
            this.acLayoutControlItem3.Text = "acLayoutControlItem3";
            this.acLayoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.acLayoutControlItem3.TextVisible = false;
            this.acLayoutControlItem3.ToolTipID = null;
            this.acLayoutControlItem3.ToolTipStdCode = null;
            this.acLayoutControlItem3.UseResourceID = false;
            this.acLayoutControlItem3.UseToolTipID = false;
            this.acLayoutControlItem3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            // 
            // acSplitContainerControl1
            // 
            this.acSplitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.acSplitContainerControl1.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.None;
            this.acSplitContainerControl1.Location = new System.Drawing.Point(0, 36);
            this.acSplitContainerControl1.Name = "acSplitContainerControl1";
            // 
            // acSplitContainerControl1.Panel1
            // 
            this.acSplitContainerControl1.Panel1.Controls.Add(this.acLayoutControl1);
            this.acSplitContainerControl1.Panel1.Text = "Panel1";
            // 
            // acSplitContainerControl1.Panel2
            // 
            this.acSplitContainerControl1.Panel2.Controls.Add(this.acGridControl2);
            this.acSplitContainerControl1.Panel2.Text = "Panel2";
            this.acSplitContainerControl1.ParentControl = null;
            this.acSplitContainerControl1.Size = new System.Drawing.Size(934, 453);
            this.acSplitContainerControl1.SplitterPosition = 447;
            this.acSplitContainerControl1.TabIndex = 9;
            this.acSplitContainerControl1.Text = "acSplitContainerControl1";
            // 
            // acGridControl2
            // 
            this.acGridControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.acGridControl2.Location = new System.Drawing.Point(0, 0);
            this.acGridControl2.MainView = this.acGridView2;
            this.acGridControl2.MenuManager = this.acBarManager1;
            this.acGridControl2.Name = "acGridControl2";
            this.acGridControl2.Size = new System.Drawing.Size(477, 453);
            this.acGridControl2.TabIndex = 6;
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
            // HIS01A_D1A
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 489);
            this.Controls.Add(this.acSplitContainerControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.IconOptions.ShowIcon = false;
            this.Name = "HIS01A_D1A";
            this.ResourceID = "";
            this.Text = "보전설비편집기";
            ((System.ComponentModel.ISupportInitialize)(this.acBarManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControl1)).EndInit();
            this.acLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.acCheckEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acGridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acTextEdit3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acTextEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acTextEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acSplitContainerControl1.Panel1)).EndInit();
            this.acSplitContainerControl1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.acSplitContainerControl1.Panel2)).EndInit();
            this.acSplitContainerControl1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.acSplitContainerControl1)).EndInit();
            this.acSplitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.acGridControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acGridView2)).EndInit();
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
        private ControlManager.acBarButtonItem barItemSaveClose;
        private ControlManager.acLayoutControl acLayoutControl1;
        private ControlManager.acLayoutControlGroup layoutControlGroup1;
        private ControlManager.acBarButtonItem barItemSave;
        private ControlManager.acBarCheckItem barItemFixedWindow;
        private ControlManager.acTextEdit acTextEdit3;
        private ControlManager.acTextEdit acTextEdit2;
        private ControlManager.acTextEdit acTextEdit1;
        private ControlManager.acLayoutControlItem acLayoutControlItem1;
        private ControlManager.acLayoutControlItem acLayoutControlItem2;
        private ControlManager.acLayoutControlItem acLayoutControlItem5;
        private ControlManager.acBarButtonItem btnAdd;
        private ControlManager.acBarButtonItem btnDel;
        private ControlManager.acSplitContainerControl acSplitContainerControl1;
        private ControlManager.acGridControl acGridControl1;
        private ControlManager.acGridView acGridView1;
        private ControlManager.acLayoutControlItem acLayoutControlItem4;
        private ControlManager.acCheckEdit acCheckEdit1;
        private ControlManager.acLayoutControlItem acLayoutControlItem3;
        private ControlManager.acGridControl acGridControl2;
        private ControlManager.acGridView acGridView2;
    }
}