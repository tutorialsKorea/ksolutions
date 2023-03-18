namespace LogInForm
{
    partial class ConfigForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigForm));
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.acGridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.acBarManager1 = new ControlManager.acBarManager(this.components);
            this.bar2 = new ControlManager.acBar();
            this.acBarButtonItem2 = new ControlManager.acBarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.acBarButtonItem3 = new ControlManager.acBarButtonItem();
            this.acBarButtonItem4 = new ControlManager.acBarButtonItem();
            this.layoutControl1 = new ControlManager.acLayoutControl();
            this.btnDelete = new ControlManager.acSimpleButton();
            this.btnSetServer = new ControlManager.acSimpleButton();
            this.textEdit5 = new ControlManager.acTextEdit();
            this.lookUpEdit2 = new ControlManager.acLookupEdit();
            this.lookUpEdit1 = new ControlManager.acLookupEdit();
            this.textEdit4 = new ControlManager.acTextEdit();
            this.textEdit2 = new ControlManager.acTextEdit();
            this.textEdit1 = new ControlManager.acTextEdit();
            this.layoutControlGroup1 = new ControlManager.acLayoutControlGroup();
            this.layoutItem_ServerIP = new ControlManager.acLayoutControlItem();
            this.layoutItem_DatabaseName = new ControlManager.acLayoutControlItem();
            this.layoutItem_Plant = new ControlManager.acLayoutControlItem();
            this.layoutItem_Lang = new ControlManager.acLayoutControlItem();
            this.layoutItem_Skin = new ControlManager.acLayoutControlItem();
            this.layoutItem_ServerName = new ControlManager.acLayoutControlItem();
            this.acLayoutControlItem1 = new ControlManager.acLayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.acLayoutControlItem2 = new ControlManager.acLayoutControlItem();
            this.popupMenu1 = new DevExpress.XtraBars.PopupMenu(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acBarManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit5.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit4.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItem_ServerIP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItem_DatabaseName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItem_Plant)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItem_Lang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItem_Skin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItem_ServerName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            resources.ApplyResources(this.splitContainerControl1, "splitContainerControl1");
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.gridControl1);
            resources.ApplyResources(this.splitContainerControl1.Panel1, "splitContainerControl1.Panel1");
            this.splitContainerControl1.Panel2.Controls.Add(this.layoutControl1);
            resources.ApplyResources(this.splitContainerControl1.Panel2, "splitContainerControl1.Panel2");
            this.splitContainerControl1.SplitterPosition = 248;
            // 
            // gridControl1
            // 
            resources.ApplyResources(this.gridControl1, "gridControl1");
            this.gridControl1.MainView = this.acGridView1;
            this.gridControl1.MenuManager = this.acBarManager1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.acGridView1});
            // 
            // acGridView1
            // 
            this.acGridView1.ColumnPanelRowHeight = 20;
            this.acGridView1.GridControl = this.gridControl1;
            this.acGridView1.Name = "acGridView1";
            this.acGridView1.OptionsView.RowAutoHeight = true;
            this.acGridView1.OptionsView.ShowGroupPanel = false;
            this.acGridView1.RowHeight = 30;
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
            this.acBarButtonItem2,
            this.acBarButtonItem3,
            this.acBarButtonItem4});
            this.acBarManager1.MainMenu = this.bar2;
            this.acBarManager1.MaxItemId = 4;
            // 
            // bar2
            // 
            this.bar2.BarItemHorzIndent = 10;
            this.bar2.BarItemVertIndent = 5;
            this.bar2.BarName = "도구상자";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.FloatLocation = new System.Drawing.Point(434, 129);
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.acBarButtonItem2)});
            this.bar2.OptionsBar.AllowQuickCustomization = false;
            this.bar2.OptionsBar.DrawDragBorder = false;
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.ResourceID = "I7LE433K";
            resources.ApplyResources(this.bar2, "bar2");
            this.bar2.ToolTipID = null;
            this.bar2.UseResourceID = true;
            this.bar2.UseToolTipID = false;
            // 
            // acBarButtonItem2
            // 
            resources.ApplyResources(this.acBarButtonItem2, "acBarButtonItem2");
            this.acBarButtonItem2.Glyph = global::LogInForm.Resource.document_save_2x;
            this.acBarButtonItem2.Id = 1;
            this.acBarButtonItem2.Name = "acBarButtonItem2";
            this.acBarButtonItem2.ResourceID = null;
            this.acBarButtonItem2.ToolTipID = null;
            this.acBarButtonItem2.UseResourceID = false;
            this.acBarButtonItem2.UseToolTipID = false;
            this.acBarButtonItem2.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.acBarButtonItem2_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            resources.ApplyResources(this.barDockControlTop, "barDockControlTop");
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            resources.ApplyResources(this.barDockControlBottom, "barDockControlBottom");
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            resources.ApplyResources(this.barDockControlLeft, "barDockControlLeft");
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            resources.ApplyResources(this.barDockControlRight, "barDockControlRight");
            // 
            // acBarButtonItem3
            // 
            resources.ApplyResources(this.acBarButtonItem3, "acBarButtonItem3");
            this.acBarButtonItem3.Glyph = global::LogInForm.Resource.harddisk_check_2x;
            this.acBarButtonItem3.Id = 2;
            this.acBarButtonItem3.Name = "acBarButtonItem3";
            this.acBarButtonItem3.ResourceID = null;
            this.acBarButtonItem3.ToolTipID = null;
            this.acBarButtonItem3.UseResourceID = false;
            this.acBarButtonItem3.UseToolTipID = false;
            // 
            // acBarButtonItem4
            // 
            resources.ApplyResources(this.acBarButtonItem4, "acBarButtonItem4");
            this.acBarButtonItem4.Glyph = global::LogInForm.Resource.edit_delete_2x;
            this.acBarButtonItem4.Id = 3;
            this.acBarButtonItem4.Name = "acBarButtonItem4";
            this.acBarButtonItem4.ResourceID = null;
            this.acBarButtonItem4.ToolTipID = null;
            this.acBarButtonItem4.UseResourceID = false;
            this.acBarButtonItem4.UseToolTipID = false;
            // 
            // layoutControl1
            // 
            this.layoutControl1.AllowCustomizationMenu = false;
            resources.ApplyResources(this.layoutControl1, "layoutControl1");
            this.layoutControl1.ContainerName = null;
            this.layoutControl1.Controls.Add(this.btnDelete);
            this.layoutControl1.Controls.Add(this.btnSetServer);
            this.layoutControl1.Controls.Add(this.textEdit5);
            this.layoutControl1.Controls.Add(this.lookUpEdit2);
            this.layoutControl1.Controls.Add(this.lookUpEdit1);
            this.layoutControl1.Controls.Add(this.textEdit4);
            this.layoutControl1.Controls.Add(this.textEdit2);
            this.layoutControl1.Controls.Add(this.textEdit1);
            this.layoutControl1.LayoutType = ControlManager.acLayoutControl.emLayoutType.NONE;
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.ParentControl = null;
            this.layoutControl1.Root = this.layoutControlGroup1;
            // 
            // btnDelete
            // 
            resources.ApplyResources(this.btnDelete, "btnDelete");
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.ResourceID = null;
            this.btnDelete.StyleController = this.layoutControl1;
            this.btnDelete.ToolTipID = null;
            this.btnDelete.UseResourceID = false;
            this.btnDelete.UseToolTipID = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSetServer
            // 
            resources.ApplyResources(this.btnSetServer, "btnSetServer");
            this.btnSetServer.Name = "btnSetServer";
            this.btnSetServer.ResourceID = null;
            this.btnSetServer.StyleController = this.layoutControl1;
            this.btnSetServer.ToolTipID = null;
            this.btnSetServer.UseResourceID = false;
            this.btnSetServer.UseToolTipID = false;
            this.btnSetServer.Click += new System.EventHandler(this.btnSetServer_Click);
            // 
            // textEdit5
            // 
            this.textEdit5.ColumnName = "SERVER_NAME";
            this.textEdit5.isRequired = true;
            resources.ApplyResources(this.textEdit5, "textEdit5");
            this.textEdit5.MaskType = ControlManager.acTextEdit.emMaskType.NONE;
            this.textEdit5.Name = "textEdit5";
            this.textEdit5.Properties.Appearance.BackColor = ((System.Drawing.Color)(resources.GetObject("textEdit5.Properties.Appearance.BackColor")));
            this.textEdit5.Properties.Appearance.ForeColor = ((System.Drawing.Color)(resources.GetObject("textEdit5.Properties.Appearance.ForeColor")));
            this.textEdit5.Properties.Appearance.Options.UseBackColor = true;
            this.textEdit5.Properties.Appearance.Options.UseForeColor = true;
            this.textEdit5.Properties.AppearanceReadOnly.BackColor = ((System.Drawing.Color)(resources.GetObject("textEdit5.Properties.AppearanceReadOnly.BackColor")));
            this.textEdit5.Properties.AppearanceReadOnly.ForeColor = ((System.Drawing.Color)(resources.GetObject("textEdit5.Properties.AppearanceReadOnly.ForeColor")));
            this.textEdit5.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.textEdit5.Properties.AppearanceReadOnly.Options.UseForeColor = true;
            this.textEdit5.StyleController = this.layoutControl1;
            // 
            // lookUpEdit2
            // 
            this.lookUpEdit2.ColumnName = "SKIN";
            this.lookUpEdit2.DefaultValueType = ControlManager.acLookupEdit.emDefaultValueType.NONE;
            this.lookUpEdit2.isReadyOnly = false;
            this.lookUpEdit2.isRequired = true;
            resources.ApplyResources(this.lookUpEdit2, "lookUpEdit2");
            this.lookUpEdit2.Name = "lookUpEdit2";
            this.lookUpEdit2.Properties.Appearance.BackColor = ((System.Drawing.Color)(resources.GetObject("lookUpEdit2.Properties.Appearance.BackColor")));
            this.lookUpEdit2.Properties.Appearance.ForeColor = ((System.Drawing.Color)(resources.GetObject("lookUpEdit2.Properties.Appearance.ForeColor")));
            this.lookUpEdit2.Properties.Appearance.Options.UseBackColor = true;
            this.lookUpEdit2.Properties.Appearance.Options.UseForeColor = true;
            this.lookUpEdit2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("lookUpEdit2.Properties.Buttons"))))});
            this.lookUpEdit2.Properties.NullText = resources.GetString("lookUpEdit2.Properties.NullText");
            this.lookUpEdit2.Properties.ShowHeader = false;
            this.lookUpEdit2.StyleController = this.layoutControl1;
            this.lookUpEdit2.ToolTipID = null;
            this.lookUpEdit2.UseToolTipID = false;
            this.lookUpEdit2.Value = null;
            // 
            // lookUpEdit1
            // 
            this.lookUpEdit1.ColumnName = "LANG";
            this.lookUpEdit1.DefaultValueType = ControlManager.acLookupEdit.emDefaultValueType.NONE;
            this.lookUpEdit1.isReadyOnly = false;
            this.lookUpEdit1.isRequired = false;
            resources.ApplyResources(this.lookUpEdit1, "lookUpEdit1");
            this.lookUpEdit1.Name = "lookUpEdit1";
            this.lookUpEdit1.Properties.Appearance.BackColor = ((System.Drawing.Color)(resources.GetObject("lookUpEdit1.Properties.Appearance.BackColor")));
            this.lookUpEdit1.Properties.Appearance.ForeColor = ((System.Drawing.Color)(resources.GetObject("lookUpEdit1.Properties.Appearance.ForeColor")));
            this.lookUpEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.lookUpEdit1.Properties.Appearance.Options.UseForeColor = true;
            this.lookUpEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("lookUpEdit1.Properties.Buttons"))))});
            this.lookUpEdit1.Properties.NullText = resources.GetString("lookUpEdit1.Properties.NullText");
            this.lookUpEdit1.Properties.ShowHeader = false;
            this.lookUpEdit1.StyleController = this.layoutControl1;
            this.lookUpEdit1.ToolTipID = null;
            this.lookUpEdit1.UseToolTipID = false;
            this.lookUpEdit1.Value = null;
            // 
            // textEdit4
            // 
            this.textEdit4.ColumnName = "PLANT";
            this.textEdit4.isRequired = true;
            resources.ApplyResources(this.textEdit4, "textEdit4");
            this.textEdit4.MaskType = ControlManager.acTextEdit.emMaskType.PLT_CODE;
            this.textEdit4.Name = "textEdit4";
            this.textEdit4.Properties.Appearance.BackColor = ((System.Drawing.Color)(resources.GetObject("textEdit4.Properties.Appearance.BackColor")));
            this.textEdit4.Properties.Appearance.ForeColor = ((System.Drawing.Color)(resources.GetObject("textEdit4.Properties.Appearance.ForeColor")));
            this.textEdit4.Properties.Appearance.Options.UseBackColor = true;
            this.textEdit4.Properties.Appearance.Options.UseForeColor = true;
            this.textEdit4.Properties.Mask.EditMask = resources.GetString("textEdit4.Properties.Mask.EditMask");
            this.textEdit4.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("textEdit4.Properties.Mask.MaskType")));
            this.textEdit4.StyleController = this.layoutControl1;
            // 
            // textEdit2
            // 
            this.textEdit2.ColumnName = "DATABASE_NAME";
            this.textEdit2.isRequired = true;
            resources.ApplyResources(this.textEdit2, "textEdit2");
            this.textEdit2.MaskType = ControlManager.acTextEdit.emMaskType.NONE;
            this.textEdit2.Name = "textEdit2";
            this.textEdit2.Properties.Appearance.BackColor = ((System.Drawing.Color)(resources.GetObject("textEdit2.Properties.Appearance.BackColor")));
            this.textEdit2.Properties.Appearance.ForeColor = ((System.Drawing.Color)(resources.GetObject("textEdit2.Properties.Appearance.ForeColor")));
            this.textEdit2.Properties.Appearance.Options.UseBackColor = true;
            this.textEdit2.Properties.Appearance.Options.UseForeColor = true;
            this.textEdit2.StyleController = this.layoutControl1;
            // 
            // textEdit1
            // 
            this.textEdit1.ColumnName = "SERVER_IP";
            this.textEdit1.isRequired = true;
            resources.ApplyResources(this.textEdit1, "textEdit1");
            this.textEdit1.MaskType = ControlManager.acTextEdit.emMaskType.IP;
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Properties.Appearance.BackColor = ((System.Drawing.Color)(resources.GetObject("textEdit1.Properties.Appearance.BackColor")));
            this.textEdit1.Properties.Appearance.ForeColor = ((System.Drawing.Color)(resources.GetObject("textEdit1.Properties.Appearance.ForeColor")));
            this.textEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.textEdit1.Properties.Appearance.Options.UseForeColor = true;
            this.textEdit1.Properties.Mask.EditMask = resources.GetString("textEdit1.Properties.Mask.EditMask");
            this.textEdit1.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("textEdit1.Properties.Mask.MaskType")));
            this.textEdit1.StyleController = this.layoutControl1;
            // 
            // layoutControlGroup1
            // 
            resources.ApplyResources(this.layoutControlGroup1, "layoutControlGroup1");
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutItem_ServerIP,
            this.layoutItem_DatabaseName,
            this.layoutItem_Plant,
            this.layoutItem_Lang,
            this.layoutItem_Skin,
            this.layoutItem_ServerName,
            this.acLayoutControlItem1,
            this.emptySpaceItem1,
            this.acLayoutControlItem2});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.ResourceID = null;
            this.layoutControlGroup1.Size = new System.Drawing.Size(322, 242);
            this.layoutControlGroup1.TextVisible = false;
            this.layoutControlGroup1.ToolTipID = null;
            this.layoutControlGroup1.UseResourceID = false;
            this.layoutControlGroup1.UseToolTipID = false;
            // 
            // layoutItem_ServerIP
            // 
            this.layoutItem_ServerIP.Control = this.textEdit1;
            resources.ApplyResources(this.layoutItem_ServerIP, "layoutItem_ServerIP");
            this.layoutItem_ServerIP.Location = new System.Drawing.Point(0, 30);
            this.layoutItem_ServerIP.Name = "layoutItem_ServerIP";
            this.layoutItem_ServerIP.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutItem_ServerIP.ResourceID = null;
            this.layoutItem_ServerIP.Size = new System.Drawing.Size(302, 30);
            this.layoutItem_ServerIP.TextSize = new System.Drawing.Size(84, 14);
            this.layoutItem_ServerIP.ToolTipID = null;
            this.layoutItem_ServerIP.UseResourceID = false;
            this.layoutItem_ServerIP.UseToolTipID = false;
            // 
            // layoutItem_DatabaseName
            // 
            this.layoutItem_DatabaseName.Control = this.textEdit2;
            resources.ApplyResources(this.layoutItem_DatabaseName, "layoutItem_DatabaseName");
            this.layoutItem_DatabaseName.Location = new System.Drawing.Point(0, 60);
            this.layoutItem_DatabaseName.Name = "layoutItem_DatabaseName";
            this.layoutItem_DatabaseName.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutItem_DatabaseName.ResourceID = null;
            this.layoutItem_DatabaseName.Size = new System.Drawing.Size(302, 30);
            this.layoutItem_DatabaseName.TextSize = new System.Drawing.Size(84, 14);
            this.layoutItem_DatabaseName.ToolTipID = null;
            this.layoutItem_DatabaseName.UseResourceID = false;
            this.layoutItem_DatabaseName.UseToolTipID = false;
            // 
            // layoutItem_Plant
            // 
            this.layoutItem_Plant.Control = this.textEdit4;
            resources.ApplyResources(this.layoutItem_Plant, "layoutItem_Plant");
            this.layoutItem_Plant.Location = new System.Drawing.Point(0, 90);
            this.layoutItem_Plant.Name = "layoutItem_Plant";
            this.layoutItem_Plant.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutItem_Plant.ResourceID = null;
            this.layoutItem_Plant.Size = new System.Drawing.Size(302, 30);
            this.layoutItem_Plant.TextSize = new System.Drawing.Size(84, 14);
            this.layoutItem_Plant.ToolTipID = null;
            this.layoutItem_Plant.UseResourceID = false;
            this.layoutItem_Plant.UseToolTipID = false;
            // 
            // layoutItem_Lang
            // 
            this.layoutItem_Lang.Control = this.lookUpEdit1;
            resources.ApplyResources(this.layoutItem_Lang, "layoutItem_Lang");
            this.layoutItem_Lang.Location = new System.Drawing.Point(0, 120);
            this.layoutItem_Lang.Name = "layoutItem_Lang";
            this.layoutItem_Lang.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutItem_Lang.ResourceID = null;
            this.layoutItem_Lang.Size = new System.Drawing.Size(302, 30);
            this.layoutItem_Lang.TextSize = new System.Drawing.Size(84, 14);
            this.layoutItem_Lang.ToolTipID = null;
            this.layoutItem_Lang.UseResourceID = false;
            this.layoutItem_Lang.UseToolTipID = false;
            this.layoutItem_Lang.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            // 
            // layoutItem_Skin
            // 
            this.layoutItem_Skin.Control = this.lookUpEdit2;
            resources.ApplyResources(this.layoutItem_Skin, "layoutItem_Skin");
            this.layoutItem_Skin.Location = new System.Drawing.Point(0, 150);
            this.layoutItem_Skin.Name = "layoutItem_Skin";
            this.layoutItem_Skin.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutItem_Skin.ResourceID = null;
            this.layoutItem_Skin.Size = new System.Drawing.Size(302, 30);
            this.layoutItem_Skin.TextSize = new System.Drawing.Size(84, 14);
            this.layoutItem_Skin.ToolTipID = null;
            this.layoutItem_Skin.UseResourceID = false;
            this.layoutItem_Skin.UseToolTipID = false;
            // 
            // layoutItem_ServerName
            // 
            this.layoutItem_ServerName.Control = this.textEdit5;
            resources.ApplyResources(this.layoutItem_ServerName, "layoutItem_ServerName");
            this.layoutItem_ServerName.Location = new System.Drawing.Point(0, 0);
            this.layoutItem_ServerName.Name = "layoutItem_ServerName";
            this.layoutItem_ServerName.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutItem_ServerName.ResourceID = null;
            this.layoutItem_ServerName.Size = new System.Drawing.Size(302, 30);
            this.layoutItem_ServerName.TextSize = new System.Drawing.Size(84, 14);
            this.layoutItem_ServerName.ToolTipID = null;
            this.layoutItem_ServerName.UseResourceID = false;
            this.layoutItem_ServerName.UseToolTipID = false;
            // 
            // acLayoutControlItem1
            // 
            this.acLayoutControlItem1.Control = this.btnSetServer;
            resources.ApplyResources(this.acLayoutControlItem1, "acLayoutControlItem1");
            this.acLayoutControlItem1.Location = new System.Drawing.Point(0, 180);
            this.acLayoutControlItem1.Name = "acLayoutControlItem1";
            this.acLayoutControlItem1.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.acLayoutControlItem1.ResourceID = null;
            this.acLayoutControlItem1.Size = new System.Drawing.Size(151, 32);
            this.acLayoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.acLayoutControlItem1.TextToControlDistance = 0;
            this.acLayoutControlItem1.TextVisible = false;
            this.acLayoutControlItem1.ToolTipID = null;
            this.acLayoutControlItem1.UseResourceID = false;
            this.acLayoutControlItem1.UseToolTipID = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            resources.ApplyResources(this.emptySpaceItem1, "emptySpaceItem1");
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 212);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(302, 10);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // acLayoutControlItem2
            // 
            this.acLayoutControlItem2.Control = this.btnDelete;
            resources.ApplyResources(this.acLayoutControlItem2, "acLayoutControlItem2");
            this.acLayoutControlItem2.Location = new System.Drawing.Point(151, 180);
            this.acLayoutControlItem2.Name = "acLayoutControlItem2";
            this.acLayoutControlItem2.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.acLayoutControlItem2.ResourceID = null;
            this.acLayoutControlItem2.Size = new System.Drawing.Size(151, 32);
            this.acLayoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.acLayoutControlItem2.TextToControlDistance = 0;
            this.acLayoutControlItem2.TextVisible = false;
            this.acLayoutControlItem2.ToolTipID = null;
            this.acLayoutControlItem2.UseResourceID = false;
            this.acLayoutControlItem2.UseToolTipID = false;
            // 
            // popupMenu1
            // 
            this.popupMenu1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.acBarButtonItem3),
            new DevExpress.XtraBars.LinkPersistInfo(this.acBarButtonItem4)});
            this.popupMenu1.Manager = this.acBarManager1;
            this.popupMenu1.Name = "popupMenu1";
            // 
            // ConfigForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConfigForm";
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acBarManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.textEdit5.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit4.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItem_ServerIP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItem_DatabaseName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItem_Plant)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItem_Lang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItem_Skin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItem_ServerName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ControlManager.acLayoutControl layoutControl1;

        

        private ControlManager.acLayoutControlGroup layoutControlGroup1;
        private ControlManager.acTextEdit textEdit4;
        private ControlManager.acTextEdit textEdit2;
        private ControlManager.acTextEdit textEdit1;

        

        private ControlManager.acLayoutControlItem layoutItem_ServerIP;
        private ControlManager.acLayoutControlItem layoutItem_DatabaseName;
        private ControlManager.acLayoutControlItem layoutItem_Plant;
        private ControlManager.acLookupEdit lookUpEdit2;
        private ControlManager.acLookupEdit lookUpEdit1;

        

        private ControlManager.acLayoutControlItem layoutItem_Lang;
        private ControlManager.acLayoutControlItem layoutItem_Skin;
        private ControlManager.acTextEdit textEdit5;
        private ControlManager.acLayoutControlItem layoutItem_ServerName;
        private ControlManager.acBarManager acBarManager1;
        private ControlManager.acBar bar2;
        private ControlManager.acBarButtonItem acBarButtonItem2;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private ControlManager.acBarButtonItem acBarButtonItem3;
        private ControlManager.acBarButtonItem acBarButtonItem4;
        private DevExpress.XtraBars.PopupMenu popupMenu1;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView acGridView1;
        private ControlManager.acSimpleButton btnSetServer;
        private ControlManager.acLayoutControlItem acLayoutControlItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private ControlManager.acSimpleButton btnDelete;
        private ControlManager.acLayoutControlItem acLayoutControlItem2;
    }
}