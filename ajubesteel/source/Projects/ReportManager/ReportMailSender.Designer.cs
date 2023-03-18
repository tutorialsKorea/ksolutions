namespace ReportManager
{
    partial class ReportMailSender
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
            this.acGridControl1 = new ControlManager.acGridControl();
            this.acGridView1 = new ControlManager.acGridView();
            this.acLayoutControl1 = new ControlManager.acLayoutControl();
            this.acLookupEdit1 = new ControlManager.acLookupEdit();
            this.acMemoEdit1 = new ControlManager.acMemoEdit();
            this.acTextEdit2 = new ControlManager.acTextEdit();
            this.acTextEdit1 = new ControlManager.acTextEdit();
            this.acLayoutControlGroup1 = new ControlManager.acLayoutControlGroup();
            this.acLayoutControlItem2 = new ControlManager.acLayoutControlItem();
            this.acLayoutControlItem3 = new ControlManager.acLayoutControlItem();
            this.acLayoutControlItem4 = new ControlManager.acLayoutControlItem();
            this.acLayoutControlItem5 = new ControlManager.acLayoutControlItem();
            this.acLayoutControlItem1 = new ControlManager.acLayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.acBarManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acGridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControl1)).BeginInit();
            this.acLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.acLookupEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acMemoEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acTextEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acTextEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem1)).BeginInit();
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
            this.acBarButtonItem1});
            this.acBarManager1.MainMenu = this.bar2;
            this.acBarManager1.MaxItemId = 1;
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
            this.acBarButtonItem1.Caption = "acBarButtonItem1";
            this.acBarButtonItem1.Glyph = global::ReportManager.Resource.dialog_apply_2x;
            this.acBarButtonItem1.Id = 0;
            this.acBarButtonItem1.Name = "acBarButtonItem1";
            this.acBarButtonItem1.ResourceID = null;
            this.acBarButtonItem1.ToolTipID = "9GUNM3V8";
            this.acBarButtonItem1.UseResourceID = false;
            this.acBarButtonItem1.UseToolTipID = true;
            this.acBarButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.acBarButtonItem1_ItemClick);
            // 
            // acGridControl1
            // 
            this.acGridControl1.Location = new System.Drawing.Point(87, 236);
            this.acGridControl1.MainView = this.acGridView1;
            this.acGridControl1.Name = "acGridControl1";
            this.acGridControl1.Size = new System.Drawing.Size(361, 122);
            this.acGridControl1.TabIndex = 4;
            this.acGridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.acGridView1});
            // 
            // acGridView1
            // 
            this.acGridView1.GridControl = this.acGridControl1;
            this.acGridView1.Name = "acGridView1";
            this.acGridView1.OptionsBehavior.AutoPopulateColumns = false;
            this.acGridView1.OptionsLayout.Columns.StoreAllOptions = true;
            this.acGridView1.OptionsLayout.StoreAllOptions = true;
            this.acGridView1.OptionsView.ColumnAutoWidth = false;
            this.acGridView1.OptionsView.RowAutoHeight = true;
            this.acGridView1.OptionsView.ShowGroupPanel = false;
            this.acGridView1.OptionsView.ShowIndicator = false;
            this.acGridView1.ParentControl = this;
            this.acGridView1.SaveFileName = null;
            // 
            // acLayoutControl1
            // 
            this.acLayoutControl1.AllowCustomizationMenu = false;
            this.acLayoutControl1.ContainerName = null;
            this.acLayoutControl1.Controls.Add(this.acLookupEdit1);
            this.acLayoutControl1.Controls.Add(this.acMemoEdit1);
            this.acLayoutControl1.Controls.Add(this.acGridControl1);
            this.acLayoutControl1.Controls.Add(this.acTextEdit2);
            this.acLayoutControl1.Controls.Add(this.acTextEdit1);
            this.acLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.acLayoutControl1.LayoutType = ControlManager.acLayoutControl.emLayoutType.NONE;
            this.acLayoutControl1.Location = new System.Drawing.Point(0, 32);
            this.acLayoutControl1.Name = "acLayoutControl1";
            this.acLayoutControl1.ParentControl = null;
            this.acLayoutControl1.Root = this.acLayoutControlGroup1;
            this.acLayoutControl1.Size = new System.Drawing.Size(453, 363);
            this.acLayoutControl1.TabIndex = 5;
            this.acLayoutControl1.Text = "acLayoutControl1";
            // 
            // acLookupEdit1
            // 
            this.acLookupEdit1.ColumnName = "REPORT_INCLUDE_TYPE";
            
            this.acLookupEdit1.isReadyOnly = false;
            this.acLookupEdit1.isRequired = true;
            this.acLookupEdit1.Location = new System.Drawing.Point(87, 6);
            this.acLookupEdit1.Name = "acLookupEdit1";
            this.acLookupEdit1.Properties.Appearance.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.acLookupEdit1.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.acLookupEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.acLookupEdit1.Properties.Appearance.Options.UseForeColor = true;
            this.acLookupEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.acLookupEdit1.Properties.NullText = "";
            this.acLookupEdit1.Properties.ShowHeader = false;
            this.acLookupEdit1.Size = new System.Drawing.Size(361, 21);
            this.acLookupEdit1.StyleController = this.acLayoutControl1;
            this.acLookupEdit1.TabIndex = 8;
            this.acLookupEdit1.ToolTipID = null;
            this.acLookupEdit1.UseToolTipID = false;
            this.acLookupEdit1.Value = null;
            // 
            // acMemoEdit1
            // 
            this.acMemoEdit1.ColumnName = "BODY";
            this.acMemoEdit1.isReadyOnly = false;
            this.acMemoEdit1.isRequired = false;
            this.acMemoEdit1.Location = new System.Drawing.Point(87, 102);
            this.acMemoEdit1.Name = "acMemoEdit1";
            this.acMemoEdit1.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.acMemoEdit1.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.acMemoEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.acMemoEdit1.Properties.Appearance.Options.UseFont = true;
            this.acMemoEdit1.Properties.Appearance.Options.UseForeColor = true;
            this.acMemoEdit1.Properties.AppearanceDisabled.Options.UseFont = true;
            this.acMemoEdit1.Properties.AppearanceFocused.Options.UseFont = true;
            this.acMemoEdit1.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.acMemoEdit1.Size = new System.Drawing.Size(361, 123);
            this.acMemoEdit1.StyleController = this.acLayoutControl1;
            this.acMemoEdit1.TabIndex = 7;
            this.acMemoEdit1.ToolTipID = null;
            this.acMemoEdit1.UseToolTipID = false;
            // 
            // acTextEdit2
            // 
            this.acTextEdit2.ColumnName = "SUBJECT";
            this.acTextEdit2.isRequired = true;
            this.acTextEdit2.Location = new System.Drawing.Point(87, 70);
            this.acTextEdit2.MaskType = ControlManager.acTextEdit.emMaskType.NONE;
            this.acTextEdit2.Name = "acTextEdit2";
            this.acTextEdit2.Properties.Appearance.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.acTextEdit2.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.acTextEdit2.Properties.Appearance.Options.UseBackColor = true;
            this.acTextEdit2.Properties.Appearance.Options.UseForeColor = true;
            this.acTextEdit2.Size = new System.Drawing.Size(361, 21);
            this.acTextEdit2.StyleController = this.acLayoutControl1;
            this.acTextEdit2.TabIndex = 6;
            // 
            // acTextEdit1
            // 
            this.acTextEdit1.ColumnName = "TO_ADDRESS";
            this.acTextEdit1.isRequired = true;
            this.acTextEdit1.Location = new System.Drawing.Point(87, 38);
            this.acTextEdit1.MaskType = ControlManager.acTextEdit.emMaskType.NONE;
            this.acTextEdit1.Name = "acTextEdit1";
            this.acTextEdit1.Properties.Appearance.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.acTextEdit1.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.acTextEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.acTextEdit1.Properties.Appearance.Options.UseForeColor = true;
            this.acTextEdit1.Size = new System.Drawing.Size(361, 21);
            this.acTextEdit1.StyleController = this.acLayoutControl1;
            this.acTextEdit1.TabIndex = 5;
            // 
            // acLayoutControlGroup1
            // 
            this.acLayoutControlGroup1.CustomizationFormText = "acLayoutControlGroup1";
            this.acLayoutControlGroup1.GroupBordersVisible = false;
            this.acLayoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.acLayoutControlItem2,
            this.acLayoutControlItem3,
            this.acLayoutControlItem4,
            this.acLayoutControlItem5,
            this.acLayoutControlItem1});
            this.acLayoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.acLayoutControlGroup1.Name = "acLayoutControlGroup1";
            this.acLayoutControlGroup1.ResourceID = null;
            this.acLayoutControlGroup1.Size = new System.Drawing.Size(453, 363);
            this.acLayoutControlGroup1.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.acLayoutControlGroup1.Text = "acLayoutControlGroup1";
            this.acLayoutControlGroup1.TextVisible = false;
            this.acLayoutControlGroup1.ToolTipID = null;
            this.acLayoutControlGroup1.UseResourceID = false;
            this.acLayoutControlGroup1.UseToolTipID = false;
            // 
            // acLayoutControlItem2
            // 
            this.acLayoutControlItem2.Control = this.acTextEdit1;
            this.acLayoutControlItem2.CustomizationFormText = "받는사람";
            this.acLayoutControlItem2.Location = new System.Drawing.Point(0, 32);
            this.acLayoutControlItem2.Name = "acLayoutControlItem2";
            this.acLayoutControlItem2.ResourceID = "78SOANHR";
            this.acLayoutControlItem2.Size = new System.Drawing.Size(453, 32);
            this.acLayoutControlItem2.Text = "받는사람";
            this.acLayoutControlItem2.TextLocation = DevExpress.Utils.Locations.Left;
            this.acLayoutControlItem2.TextSize = new System.Drawing.Size(76, 20);
            this.acLayoutControlItem2.ToolTipID = null;
            this.acLayoutControlItem2.UseResourceID = true;
            this.acLayoutControlItem2.UseToolTipID = false;
            // 
            // acLayoutControlItem3
            // 
            this.acLayoutControlItem3.Control = this.acTextEdit2;
            this.acLayoutControlItem3.CustomizationFormText = "제목";
            this.acLayoutControlItem3.Location = new System.Drawing.Point(0, 64);
            this.acLayoutControlItem3.Name = "acLayoutControlItem3";
            this.acLayoutControlItem3.ResourceID = "W4WOVWG8";
            this.acLayoutControlItem3.Size = new System.Drawing.Size(453, 32);
            this.acLayoutControlItem3.Text = "제목";
            this.acLayoutControlItem3.TextLocation = DevExpress.Utils.Locations.Left;
            this.acLayoutControlItem3.TextSize = new System.Drawing.Size(76, 20);
            this.acLayoutControlItem3.ToolTipID = null;
            this.acLayoutControlItem3.UseResourceID = true;
            this.acLayoutControlItem3.UseToolTipID = false;
            // 
            // acLayoutControlItem4
            // 
            this.acLayoutControlItem4.Control = this.acMemoEdit1;
            this.acLayoutControlItem4.CustomizationFormText = "내용";
            this.acLayoutControlItem4.Location = new System.Drawing.Point(0, 96);
            this.acLayoutControlItem4.Name = "acLayoutControlItem4";
            this.acLayoutControlItem4.ResourceID = "O00RH4SM";
            this.acLayoutControlItem4.Size = new System.Drawing.Size(453, 134);
            this.acLayoutControlItem4.Text = "내용";
            this.acLayoutControlItem4.TextLocation = DevExpress.Utils.Locations.Left;
            this.acLayoutControlItem4.TextSize = new System.Drawing.Size(76, 20);
            this.acLayoutControlItem4.ToolTipID = null;
            this.acLayoutControlItem4.UseResourceID = true;
            this.acLayoutControlItem4.UseToolTipID = false;
            // 
            // acLayoutControlItem5
            // 
            this.acLayoutControlItem5.Control = this.acGridControl1;
            this.acLayoutControlItem5.CustomizationFormText = "첨부파일";
            this.acLayoutControlItem5.Location = new System.Drawing.Point(0, 230);
            this.acLayoutControlItem5.Name = "acLayoutControlItem5";
            this.acLayoutControlItem5.ResourceID = "I2YLPXGU";
            this.acLayoutControlItem5.Size = new System.Drawing.Size(453, 133);
            this.acLayoutControlItem5.Text = "첨부파일";
            this.acLayoutControlItem5.TextLocation = DevExpress.Utils.Locations.Left;
            this.acLayoutControlItem5.TextSize = new System.Drawing.Size(76, 20);
            this.acLayoutControlItem5.ToolTipID = null;
            this.acLayoutControlItem5.UseResourceID = true;
            this.acLayoutControlItem5.UseToolTipID = false;
            // 
            // acLayoutControlItem1
            // 
            this.acLayoutControlItem1.Control = this.acLookupEdit1;
            this.acLayoutControlItem1.CustomizationFormText = "양식 첨부형태";
            this.acLayoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.acLayoutControlItem1.Name = "acLayoutControlItem1";
            this.acLayoutControlItem1.ResourceID = "GJQZSAC2";
            this.acLayoutControlItem1.Size = new System.Drawing.Size(453, 32);
            this.acLayoutControlItem1.Text = "양식 첨부형태";
            this.acLayoutControlItem1.TextLocation = DevExpress.Utils.Locations.Left;
            this.acLayoutControlItem1.TextSize = new System.Drawing.Size(76, 20);
            this.acLayoutControlItem1.ToolTipID = null;
            this.acLayoutControlItem1.UseResourceID = true;
            this.acLayoutControlItem1.UseToolTipID = false;
            // 
            // ReportMailSender
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(453, 395);
            this.Controls.Add(this.acLayoutControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "ReportMailSender";
            this.ResourceID = "SNLUZ20X";
            this.Text = "메일 보내기";
            this.UseResourceID = true;
            ((System.ComponentModel.ISupportInitialize)(this.acBarManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acGridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControl1)).EndInit();
            this.acLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.acLookupEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acMemoEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acTextEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acTextEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ControlManager.acBarManager acBarManager1;
        private ControlManager.acBar bar2;
        private ControlManager.acBarButtonItem acBarButtonItem1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private ControlManager.acGridControl acGridControl1;
        private ControlManager.acGridView acGridView1;
        private ControlManager.acLayoutControl acLayoutControl1;
        private ControlManager.acMemoEdit acMemoEdit1;
        private ControlManager.acTextEdit acTextEdit2;
        private ControlManager.acTextEdit acTextEdit1;
        private ControlManager.acLayoutControlGroup acLayoutControlGroup1;
        private ControlManager.acLayoutControlItem acLayoutControlItem2;
        private ControlManager.acLayoutControlItem acLayoutControlItem3;
        private ControlManager.acLayoutControlItem acLayoutControlItem4;
        private ControlManager.acLayoutControlItem acLayoutControlItem5;
        private ControlManager.acLookupEdit acLookupEdit1;
        private ControlManager.acLayoutControlItem acLayoutControlItem1;

    }
}