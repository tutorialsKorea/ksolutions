namespace ControlManager
{
    partial class acGridViewCustomReport
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
            this.acLayoutControl1 = new ControlManager.acLayoutControl();
            this.txtTitle = new ControlManager.acTextEdit();
            this.acBarManager1 = new ControlManager.acBarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.btnSaveClose = new ControlManager.acBarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.btnLoadFile = new ControlManager.acSimpleButton();
            this.txtPath = new ControlManager.acTextEdit();
            this.acSplitContainerControl1 = new ControlManager.acSplitContainerControl();
            this.acLayoutControl2 = new ControlManager.acLayoutControl();
            this.VerticalColumns = new ControlManager.acVerticalGrid();
            this.acLayoutControlGroup1 = new ControlManager.acLayoutControlGroup();
            this.acLayoutControlItem2 = new ControlManager.acLayoutControlItem();
            this.acLayoutControl3 = new ControlManager.acLayoutControl();
            this.spreadExcel = new DevExpress.XtraSpreadsheet.SpreadsheetControl();
            this.acLayoutControlGroup2 = new ControlManager.acLayoutControlGroup();
            this.acLayoutControlItem1 = new ControlManager.acLayoutControlItem();
            this.acRadioGroup1 = new ControlManager.acRadioGroup();
            this.Root = new ControlManager.acLayoutControlGroup();
            this.acLayoutControlItem3 = new ControlManager.acLayoutControlItem();
            this.acLayoutControlItem4 = new ControlManager.acLayoutControlItem();
            this.acLayoutControlItem5 = new ControlManager.acLayoutControlItem();
            this.acLayoutControlItem6 = new ControlManager.acLayoutControlItem();
            this.acLayoutControlItem7 = new ControlManager.acLayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControl1)).BeginInit();
            this.acLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTitle.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acBarManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPath.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acSplitContainerControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acSplitContainerControl1.Panel1)).BeginInit();
            this.acSplitContainerControl1.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.acSplitContainerControl1.Panel2)).BeginInit();
            this.acSplitContainerControl1.Panel2.SuspendLayout();
            this.acSplitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControl2)).BeginInit();
            this.acLayoutControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VerticalColumns)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControl3)).BeginInit();
            this.acLayoutControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acRadioGroup1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem7)).BeginInit();
            this.SuspendLayout();
            // 
            // acLayoutControl1
            // 
            this.acLayoutControl1.AllowCustomization = false;
            this.acLayoutControl1.ContainerName = null;
            this.acLayoutControl1.Controls.Add(this.txtTitle);
            this.acLayoutControl1.Controls.Add(this.btnLoadFile);
            this.acLayoutControl1.Controls.Add(this.txtPath);
            this.acLayoutControl1.Controls.Add(this.acSplitContainerControl1);
            this.acLayoutControl1.Controls.Add(this.acRadioGroup1);
            this.acLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.acLayoutControl1.LayoutType = ControlManager.acLayoutControl.emLayoutType.NONE;
            this.acLayoutControl1.Location = new System.Drawing.Point(0, 30);
            this.acLayoutControl1.Name = "acLayoutControl1";
            this.acLayoutControl1.ParentControl = null;
            this.acLayoutControl1.Root = this.Root;
            this.acLayoutControl1.Size = new System.Drawing.Size(702, 569);
            this.acLayoutControl1.TabIndex = 0;
            this.acLayoutControl1.Text = "acLayoutControl1";
            // 
            // txtTitle
            // 
            this.txtTitle.isRequired = true;
            this.txtTitle.Location = new System.Drawing.Point(47, 50);
            this.txtTitle.MaskType = ControlManager.acTextEdit.emMaskType.NONE;
            this.txtTitle.MenuManager = this.acBarManager1;
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Properties.Appearance.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.txtTitle.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.txtTitle.Properties.Appearance.Options.UseBackColor = true;
            this.txtTitle.Properties.Appearance.Options.UseForeColor = true;
            this.txtTitle.Properties.AutoHeight = false;
            this.txtTitle.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txtTitle.Size = new System.Drawing.Size(640, 25);
            this.txtTitle.StyleController = this.acLayoutControl1;
            this.txtTitle.TabIndex = 7;
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
            this.btnSaveClose});
            this.acBarManager1.MainMenu = this.bar2;
            this.acBarManager1.MaxItemId = 2;
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnSaveClose)});
            this.bar2.OptionsBar.DrawBorder = false;
            this.bar2.OptionsBar.DrawDragBorder = false;
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // btnSaveClose
            // 
            this.btnSaveClose.ButtonShortCutType = ControlManager.acBarManager.emBarShortCutType.SAVE;
            this.btnSaveClose.Caption = "저장 후 닫기";
            this.btnSaveClose.Id = 0;
            this.btnSaveClose.ImageOptions.Image = global::ControlManager.Resource.document_save_close_x22;
            this.btnSaveClose.Name = "btnSaveClose";
            this.btnSaveClose.ResourceID = null;
            this.btnSaveClose.ToolTipID = null;
            this.btnSaveClose.UseResourceID = false;
            this.btnSaveClose.UseToolTipID = false;
            this.btnSaveClose.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSaveClose_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.acBarManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(702, 30);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 599);
            this.barDockControlBottom.Manager = this.acBarManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(702, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 30);
            this.barDockControlLeft.Manager = this.acBarManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 569);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(702, 30);
            this.barDockControlRight.Manager = this.acBarManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 569);
            // 
            // btnLoadFile
            // 
            this.btnLoadFile.Location = new System.Drawing.Point(641, 15);
            this.btnLoadFile.Name = "btnLoadFile";
            this.btnLoadFile.ResourceID = null;
            this.btnLoadFile.Size = new System.Drawing.Size(46, 25);
            this.btnLoadFile.StyleController = this.acLayoutControl1;
            this.btnLoadFile.TabIndex = 6;
            this.btnLoadFile.Text = "…";
            this.btnLoadFile.ToolTipID = null;
            this.btnLoadFile.UseResourceID = false;
            this.btnLoadFile.UseToolTipID = false;
            this.btnLoadFile.Click += new System.EventHandler(this.btnLoadFile_Click);
            // 
            // txtPath
            // 
            this.txtPath.isReadyOnly = true;
            this.txtPath.Location = new System.Drawing.Point(47, 15);
            this.txtPath.MaskType = ControlManager.acTextEdit.emMaskType.NONE;
            this.txtPath.MenuManager = this.acBarManager1;
            this.txtPath.Name = "txtPath";
            this.txtPath.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtPath.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.txtPath.Properties.Appearance.Options.UseBackColor = true;
            this.txtPath.Properties.Appearance.Options.UseForeColor = true;
            this.txtPath.Properties.Appearance.Options.UseTextOptions = true;
            this.txtPath.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.txtPath.Properties.AppearanceFocused.Options.UseTextOptions = true;
            this.txtPath.Properties.AppearanceFocused.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.txtPath.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtPath.Properties.AppearanceReadOnly.ForeColor = System.Drawing.Color.Black;
            this.txtPath.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.txtPath.Properties.AppearanceReadOnly.Options.UseForeColor = true;
            this.txtPath.Properties.AppearanceReadOnly.Options.UseTextOptions = true;
            this.txtPath.Properties.AppearanceReadOnly.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.txtPath.Properties.AutoHeight = false;
            this.txtPath.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txtPath.Properties.ReadOnly = true;
            this.txtPath.Size = new System.Drawing.Size(584, 25);
            this.txtPath.StyleController = this.acLayoutControl1;
            this.txtPath.TabIndex = 5;
            // 
            // acSplitContainerControl1
            // 
            this.acSplitContainerControl1.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.None;
            this.acSplitContainerControl1.Location = new System.Drawing.Point(15, 120);
            this.acSplitContainerControl1.Name = "acSplitContainerControl1";
            // 
            // acSplitContainerControl1.Panel1
            // 
            this.acSplitContainerControl1.Panel1.Controls.Add(this.acLayoutControl2);
            this.acSplitContainerControl1.Panel1.Text = "Panel1";
            // 
            // acSplitContainerControl1.Panel2
            // 
            this.acSplitContainerControl1.Panel2.Controls.Add(this.acLayoutControl3);
            this.acSplitContainerControl1.Panel2.Text = "Panel2";
            this.acSplitContainerControl1.ParentControl = null;
            this.acSplitContainerControl1.Size = new System.Drawing.Size(672, 434);
            this.acSplitContainerControl1.SplitterPosition = 336;
            this.acSplitContainerControl1.TabIndex = 4;
            // 
            // acLayoutControl2
            // 
            this.acLayoutControl2.AllowCustomization = false;
            this.acLayoutControl2.ContainerName = null;
            this.acLayoutControl2.Controls.Add(this.VerticalColumns);
            this.acLayoutControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.acLayoutControl2.LayoutType = ControlManager.acLayoutControl.emLayoutType.NONE;
            this.acLayoutControl2.Location = new System.Drawing.Point(0, 0);
            this.acLayoutControl2.Name = "acLayoutControl2";
            this.acLayoutControl2.ParentControl = null;
            this.acLayoutControl2.Root = this.acLayoutControlGroup1;
            this.acLayoutControl2.Size = new System.Drawing.Size(336, 434);
            this.acLayoutControl2.TabIndex = 0;
            this.acLayoutControl2.Text = "acLayoutControl2";
            // 
            // VerticalColumns
            // 
            this.VerticalColumns.Cursor = System.Windows.Forms.Cursors.Default;
            this.VerticalColumns.DataBindRow = null;
            this.VerticalColumns.LayoutStyle = DevExpress.XtraVerticalGrid.LayoutViewStyle.BandsView;
            this.VerticalColumns.Location = new System.Drawing.Point(5, 22);
            this.VerticalColumns.Name = "VerticalColumns";
            this.VerticalColumns.ParentControl = this;
            this.VerticalColumns.RecordWidth = 226;
            this.VerticalColumns.Size = new System.Drawing.Size(326, 407);
            this.VerticalColumns.TabIndex = 2;
            // 
            // acLayoutControlGroup1
            // 
            this.acLayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.acLayoutControlGroup1.GroupBordersVisible = false;
            this.acLayoutControlGroup1.IsHeader = false;
            this.acLayoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.acLayoutControlItem2});
            this.acLayoutControlGroup1.Name = "acLayoutControlGroup1";
            this.acLayoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.acLayoutControlGroup1.ResourceID = null;
            this.acLayoutControlGroup1.Size = new System.Drawing.Size(336, 434);
            this.acLayoutControlGroup1.TextVisible = false;
            this.acLayoutControlGroup1.ToolTipID = null;
            this.acLayoutControlGroup1.UseResourceID = false;
            this.acLayoutControlGroup1.UseToolTipID = false;
            // 
            // acLayoutControlItem2
            // 
            this.acLayoutControlItem2.Control = this.VerticalColumns;
            this.acLayoutControlItem2.CustomizationFormText = "엑셀 위치";
            this.acLayoutControlItem2.IsHeader = false;
            this.acLayoutControlItem2.IsTitle = false;
            this.acLayoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.acLayoutControlItem2.Name = "acLayoutControlItem2";
            this.acLayoutControlItem2.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.acLayoutControlItem2.ResourceID = null;
            this.acLayoutControlItem2.Size = new System.Drawing.Size(336, 434);
            this.acLayoutControlItem2.Text = "엑셀 위치";
            this.acLayoutControlItem2.TextLocation = DevExpress.Utils.Locations.Top;
            this.acLayoutControlItem2.TextSize = new System.Drawing.Size(44, 14);
            this.acLayoutControlItem2.ToolTipID = null;
            this.acLayoutControlItem2.ToolTipStdCode = null;
            this.acLayoutControlItem2.UseResourceID = false;
            this.acLayoutControlItem2.UseToolTipID = false;
            // 
            // acLayoutControl3
            // 
            this.acLayoutControl3.AllowCustomization = false;
            this.acLayoutControl3.ContainerName = null;
            this.acLayoutControl3.Controls.Add(this.spreadExcel);
            this.acLayoutControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.acLayoutControl3.LayoutType = ControlManager.acLayoutControl.emLayoutType.NONE;
            this.acLayoutControl3.Location = new System.Drawing.Point(0, 0);
            this.acLayoutControl3.Name = "acLayoutControl3";
            this.acLayoutControl3.ParentControl = null;
            this.acLayoutControl3.Root = this.acLayoutControlGroup2;
            this.acLayoutControl3.Size = new System.Drawing.Size(326, 434);
            this.acLayoutControl3.TabIndex = 1;
            this.acLayoutControl3.Text = "acLayoutControl3";
            // 
            // spreadExcel
            // 
            this.spreadExcel.Location = new System.Drawing.Point(5, 22);
            this.spreadExcel.MenuManager = this.acBarManager1;
            this.spreadExcel.Name = "spreadExcel";
            this.spreadExcel.ReadOnly = true;
            this.spreadExcel.Size = new System.Drawing.Size(316, 407);
            this.spreadExcel.TabIndex = 3;
            this.spreadExcel.Text = "spreadsheetControl1";
            // 
            // acLayoutControlGroup2
            // 
            this.acLayoutControlGroup2.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.acLayoutControlGroup2.GroupBordersVisible = false;
            this.acLayoutControlGroup2.IsHeader = false;
            this.acLayoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.acLayoutControlItem1});
            this.acLayoutControlGroup2.Name = "acLayoutControlGroup1";
            this.acLayoutControlGroup2.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.acLayoutControlGroup2.ResourceID = null;
            this.acLayoutControlGroup2.Size = new System.Drawing.Size(326, 434);
            this.acLayoutControlGroup2.TextVisible = false;
            this.acLayoutControlGroup2.ToolTipID = null;
            this.acLayoutControlGroup2.UseResourceID = false;
            this.acLayoutControlGroup2.UseToolTipID = false;
            // 
            // acLayoutControlItem1
            // 
            this.acLayoutControlItem1.Control = this.spreadExcel;
            this.acLayoutControlItem1.CustomizationFormText = "등록 Excel 미리보기";
            this.acLayoutControlItem1.IsHeader = false;
            this.acLayoutControlItem1.IsTitle = false;
            this.acLayoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.acLayoutControlItem1.Name = "acLayoutControlItem1";
            this.acLayoutControlItem1.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.acLayoutControlItem1.ResourceID = null;
            this.acLayoutControlItem1.Size = new System.Drawing.Size(326, 434);
            this.acLayoutControlItem1.Text = "등록 Excel 미리보기";
            this.acLayoutControlItem1.TextLocation = DevExpress.Utils.Locations.Top;
            this.acLayoutControlItem1.TextSize = new System.Drawing.Size(96, 14);
            this.acLayoutControlItem1.ToolTipID = null;
            this.acLayoutControlItem1.ToolTipStdCode = null;
            this.acLayoutControlItem1.UseResourceID = false;
            this.acLayoutControlItem1.UseToolTipID = false;
            // 
            // acRadioGroup1
            // 
            this.acRadioGroup1.ColumnName = null;
            this.acRadioGroup1.isReadyOnly = false;
            this.acRadioGroup1.isRequired = false;
            this.acRadioGroup1.Location = new System.Drawing.Point(47, 85);
            this.acRadioGroup1.MenuManager = this.acBarManager1;
            this.acRadioGroup1.Name = "acRadioGroup1";
            this.acRadioGroup1.Properties.Columns = 2;
            this.acRadioGroup1.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new ControlManager.acRadioGroupItem("LIST", "리스트", false, null, false, null),
            new ControlManager.acRadioGroupItem("EACH", "개별 파일", false, null, false, null)});
            this.acRadioGroup1.Size = new System.Drawing.Size(640, 25);
            this.acRadioGroup1.StyleController = this.acLayoutControl1;
            this.acRadioGroup1.TabIndex = 0;
            this.acRadioGroup1.ToolTipID = null;
            this.acRadioGroup1.UseToolTipID = false;
            this.acRadioGroup1.Value = null;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.IsHeader = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.acLayoutControlItem3,
            this.acLayoutControlItem4,
            this.acLayoutControlItem5,
            this.acLayoutControlItem6,
            this.acLayoutControlItem7});
            this.Root.Name = "Root";
            this.Root.ResourceID = null;
            this.Root.Size = new System.Drawing.Size(702, 569);
            this.Root.TextVisible = false;
            this.Root.ToolTipID = null;
            this.Root.UseResourceID = false;
            this.Root.UseToolTipID = false;
            // 
            // acLayoutControlItem3
            // 
            this.acLayoutControlItem3.Control = this.acRadioGroup1;
            this.acLayoutControlItem3.CustomizationFormText = "형식";
            this.acLayoutControlItem3.IsHeader = false;
            this.acLayoutControlItem3.IsTitle = false;
            this.acLayoutControlItem3.Location = new System.Drawing.Point(0, 70);
            this.acLayoutControlItem3.MaxSize = new System.Drawing.Size(0, 44);
            this.acLayoutControlItem3.MinSize = new System.Drawing.Size(92, 35);
            this.acLayoutControlItem3.Name = "acLayoutControlItem3";
            this.acLayoutControlItem3.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.acLayoutControlItem3.ResourceID = null;
            this.acLayoutControlItem3.Size = new System.Drawing.Size(682, 35);
            this.acLayoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.acLayoutControlItem3.Text = "형식";
            this.acLayoutControlItem3.TextSize = new System.Drawing.Size(20, 14);
            this.acLayoutControlItem3.ToolTipID = null;
            this.acLayoutControlItem3.ToolTipStdCode = null;
            this.acLayoutControlItem3.UseResourceID = false;
            this.acLayoutControlItem3.UseToolTipID = false;
            // 
            // acLayoutControlItem4
            // 
            this.acLayoutControlItem4.Control = this.acSplitContainerControl1;
            this.acLayoutControlItem4.CustomizationFormText = "acLayoutControlItem4";
            this.acLayoutControlItem4.IsHeader = false;
            this.acLayoutControlItem4.IsTitle = false;
            this.acLayoutControlItem4.Location = new System.Drawing.Point(0, 105);
            this.acLayoutControlItem4.Name = "acLayoutControlItem4";
            this.acLayoutControlItem4.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.acLayoutControlItem4.ResourceID = null;
            this.acLayoutControlItem4.Size = new System.Drawing.Size(682, 444);
            this.acLayoutControlItem4.Text = "acLayoutControlItem4";
            this.acLayoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.acLayoutControlItem4.TextVisible = false;
            this.acLayoutControlItem4.ToolTipID = null;
            this.acLayoutControlItem4.ToolTipStdCode = null;
            this.acLayoutControlItem4.UseResourceID = false;
            this.acLayoutControlItem4.UseToolTipID = false;
            // 
            // acLayoutControlItem5
            // 
            this.acLayoutControlItem5.Control = this.txtPath;
            this.acLayoutControlItem5.CustomizationFormText = "경로";
            this.acLayoutControlItem5.IsHeader = false;
            this.acLayoutControlItem5.IsTitle = false;
            this.acLayoutControlItem5.Location = new System.Drawing.Point(0, 0);
            this.acLayoutControlItem5.MaxSize = new System.Drawing.Size(0, 44);
            this.acLayoutControlItem5.MinSize = new System.Drawing.Size(92, 35);
            this.acLayoutControlItem5.Name = "acLayoutControlItem5";
            this.acLayoutControlItem5.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.acLayoutControlItem5.ResourceID = null;
            this.acLayoutControlItem5.Size = new System.Drawing.Size(626, 35);
            this.acLayoutControlItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.acLayoutControlItem5.Text = "경로";
            this.acLayoutControlItem5.TextSize = new System.Drawing.Size(20, 14);
            this.acLayoutControlItem5.ToolTipID = null;
            this.acLayoutControlItem5.ToolTipStdCode = null;
            this.acLayoutControlItem5.UseResourceID = false;
            this.acLayoutControlItem5.UseToolTipID = false;
            // 
            // acLayoutControlItem6
            // 
            this.acLayoutControlItem6.Control = this.btnLoadFile;
            this.acLayoutControlItem6.CustomizationFormText = "acLayoutControlItem6";
            this.acLayoutControlItem6.IsHeader = false;
            this.acLayoutControlItem6.IsTitle = false;
            this.acLayoutControlItem6.Location = new System.Drawing.Point(626, 0);
            this.acLayoutControlItem6.MaxSize = new System.Drawing.Size(60, 0);
            this.acLayoutControlItem6.MinSize = new System.Drawing.Size(27, 32);
            this.acLayoutControlItem6.Name = "acLayoutControlItem6";
            this.acLayoutControlItem6.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.acLayoutControlItem6.ResourceID = null;
            this.acLayoutControlItem6.Size = new System.Drawing.Size(56, 35);
            this.acLayoutControlItem6.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.acLayoutControlItem6.Text = "acLayoutControlItem6";
            this.acLayoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.acLayoutControlItem6.TextVisible = false;
            this.acLayoutControlItem6.ToolTipID = null;
            this.acLayoutControlItem6.ToolTipStdCode = null;
            this.acLayoutControlItem6.UseResourceID = false;
            this.acLayoutControlItem6.UseToolTipID = false;
            // 
            // acLayoutControlItem7
            // 
            this.acLayoutControlItem7.Control = this.txtTitle;
            this.acLayoutControlItem7.CustomizationFormText = "제목";
            this.acLayoutControlItem7.IsHeader = false;
            this.acLayoutControlItem7.IsTitle = false;
            this.acLayoutControlItem7.Location = new System.Drawing.Point(0, 35);
            this.acLayoutControlItem7.MaxSize = new System.Drawing.Size(0, 44);
            this.acLayoutControlItem7.MinSize = new System.Drawing.Size(92, 35);
            this.acLayoutControlItem7.Name = "acLayoutControlItem7";
            this.acLayoutControlItem7.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.acLayoutControlItem7.ResourceID = null;
            this.acLayoutControlItem7.Size = new System.Drawing.Size(682, 35);
            this.acLayoutControlItem7.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.acLayoutControlItem7.Text = "제목";
            this.acLayoutControlItem7.TextSize = new System.Drawing.Size(20, 14);
            this.acLayoutControlItem7.ToolTipID = null;
            this.acLayoutControlItem7.ToolTipStdCode = null;
            this.acLayoutControlItem7.UseResourceID = false;
            this.acLayoutControlItem7.UseToolTipID = false;
            // 
            // acGridViewCustomReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(702, 599);
            this.Controls.Add(this.acLayoutControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.IconOptions.ShowIcon = false;
            this.Name = "acGridViewCustomReport";
            this.ResourceID = "6T0ZDDPE";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "커스텀 리포트 설정";
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControl1)).EndInit();
            this.acLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtTitle.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acBarManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPath.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acSplitContainerControl1.Panel1)).EndInit();
            this.acSplitContainerControl1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.acSplitContainerControl1.Panel2)).EndInit();
            this.acSplitContainerControl1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.acSplitContainerControl1)).EndInit();
            this.acSplitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControl2)).EndInit();
            this.acLayoutControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.VerticalColumns)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControl3)).EndInit();
            this.acLayoutControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acRadioGroup1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem7)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private acLayoutControl acLayoutControl1;
        private DevExpress.XtraSpreadsheet.SpreadsheetControl spreadExcel;
        private acLayoutControlGroup Root;
        private acVerticalGrid VerticalColumns;
        private acBarManager acBarManager1;
        private DevExpress.XtraBars.Bar bar2;
        private acBarButtonItem btnSaveClose;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private acRadioGroup acRadioGroup1;
        private acLayoutControlItem acLayoutControlItem3;
        private acSplitContainerControl acSplitContainerControl1;
        private acLayoutControl acLayoutControl2;
        private acLayoutControlGroup acLayoutControlGroup1;
        private acLayoutControlItem acLayoutControlItem2;
        private acLayoutControl acLayoutControl3;
        private acLayoutControlGroup acLayoutControlGroup2;
        private acLayoutControlItem acLayoutControlItem1;
        private acLayoutControlItem acLayoutControlItem4;
        private acTextEdit txtPath;
        private acLayoutControlItem acLayoutControlItem5;
        private acSimpleButton btnLoadFile;
        private acLayoutControlItem acLayoutControlItem6;
        private acTextEdit txtTitle;
        private acLayoutControlItem acLayoutControlItem7;
    }
}