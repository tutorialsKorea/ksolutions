namespace STD
{
    partial class STD6311A_D0A
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
            this.barItemClear = new ControlManager.acBarButtonItem();
            this.barItemSave = new ControlManager.acBarButtonItem();
            this.barItemSaveClose = new ControlManager.acBarButtonItem();
            this.barItemDelete = new ControlManager.acBarButtonItem();
            this.barItemFixedWindow = new ControlManager.acBarCheckItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.acLayoutControl1 = new ControlManager.acLayoutControl();
            this.acLookupEdit2 = new ControlManager.acLookupEdit();
            this.acLookupEdit1 = new ControlManager.acLookupEdit();
            this.layoutControlGroup1 = new ControlManager.acLayoutControlGroup();
            this.acLayoutControlItem8 = new ControlManager.acLayoutControlItem();
            this.acLayoutControlItem3 = new ControlManager.acLayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.acBarManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControl1)).BeginInit();
            this.acLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.acLookupEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLookupEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem3)).BeginInit();
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
            this.barItemDelete,
            this.barItemClear,
            this.barItemSave,
            this.barItemFixedWindow});
            this.acBarManager1.MainMenu = this.bar2;
            this.acBarManager1.MaxItemId = 7;
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
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barItemClear, DevExpress.XtraBars.BarItemPaintStyle.Standard),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barItemSave, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barItemSaveClose, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barItemDelete, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
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
            // barItemClear
            // 
            this.barItemClear.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.barItemClear.ButtonShortCutType = ControlManager.acBarManager.emBarShortCutType.CLEAR;
            this.barItemClear.Caption = "초기화";
            this.barItemClear.Id = 2;
            this.barItemClear.ImageOptions.Image = global::STD.Resource.edit_clear_2x;
            this.barItemClear.Name = "barItemClear";
            this.barItemClear.ResourceID = null;
            this.barItemClear.ToolTipID = "P3U1F2R9";
            this.barItemClear.UseResourceID = false;
            this.barItemClear.UseToolTipID = true;
            this.barItemClear.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barItemClear_ItemClick);
            // 
            // barItemSave
            // 
            this.barItemSave.ButtonShortCutType = ControlManager.acBarManager.emBarShortCutType.SAVE;
            this.barItemSave.Caption = "저장";
            this.barItemSave.Id = 3;
            this.barItemSave.ImageOptions.Image = global::STD.Resource.document_save_2x;
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
            this.barItemSaveClose.ImageOptions.Image = global::STD.Resource.document_save_close_2x;
            this.barItemSaveClose.Name = "barItemSaveClose";
            this.barItemSaveClose.ResourceID = null;
            this.barItemSaveClose.ToolTipID = "TWPQ2QB2";
            this.barItemSaveClose.UseResourceID = false;
            this.barItemSaveClose.UseToolTipID = true;
            this.barItemSaveClose.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barItemSaveClose_ItemClick);
            // 
            // barItemDelete
            // 
            this.barItemDelete.ButtonShortCutType = ControlManager.acBarManager.emBarShortCutType.DEL;
            this.barItemDelete.Caption = "삭제";
            this.barItemDelete.Id = 1;
            this.barItemDelete.ImageOptions.Image = global::STD.Resource.edit_delete_2x;
            this.barItemDelete.Name = "barItemDelete";
            this.barItemDelete.ResourceID = null;
            this.barItemDelete.ToolTipID = "2AJQS0WU";
            this.barItemDelete.UseResourceID = false;
            this.barItemDelete.UseToolTipID = true;
            this.barItemDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barItemDelete_ItemClick);
            // 
            // barItemFixedWindow
            // 
            this.barItemFixedWindow.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.barItemFixedWindow.ButtonShortCutType = ControlManager.acBarManager.emBarShortCutType.WIN_LOCK;
            this.barItemFixedWindow.Caption = "창고정";
            this.barItemFixedWindow.Id = 5;
            this.barItemFixedWindow.ImageOptions.Image = global::STD.Resource.emblem_readonly_2x;
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
            this.barDockControlTop.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlTop.Size = new System.Drawing.Size(492, 44);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 212);
            this.barDockControlBottom.Manager = this.acBarManager1;
            this.barDockControlBottom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlBottom.Size = new System.Drawing.Size(492, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 44);
            this.barDockControlLeft.Manager = this.acBarManager1;
            this.barDockControlLeft.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 168);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(492, 44);
            this.barDockControlRight.Manager = this.acBarManager1;
            this.barDockControlRight.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 168);
            // 
            // acLayoutControl1
            // 
            this.acLayoutControl1.AllowCustomization = false;
            this.acLayoutControl1.AutoScroll = false;
            this.acLayoutControl1.ContainerName = null;
            this.acLayoutControl1.Controls.Add(this.acLookupEdit2);
            this.acLayoutControl1.Controls.Add(this.acLookupEdit1);
            this.acLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.acLayoutControl1.EnterMoveNextControl = false;
            this.acLayoutControl1.LayoutType = ControlManager.acLayoutControl.emLayoutType.NONE;
            this.acLayoutControl1.Location = new System.Drawing.Point(0, 44);
            this.acLayoutControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.acLayoutControl1.Name = "acLayoutControl1";
            this.acLayoutControl1.ParentControl = null;
            this.acLayoutControl1.Root = this.layoutControlGroup1;
            this.acLayoutControl1.Size = new System.Drawing.Size(492, 168);
            this.acLayoutControl1.TabIndex = 4;
            this.acLayoutControl1.Text = "acLayoutControl1";
            // 
            // acLookupEdit2
            // 
            this.acLookupEdit2.ColumnName = "MDR_RCODE";
            this.acLookupEdit2.DefaultValueType = ControlManager.acLookupEdit.emDefaultValueType.NONE;
            this.acLookupEdit2.isReadyOnly = false;
            this.acLookupEdit2.isRequired = true;
            this.acLookupEdit2.Location = new System.Drawing.Point(108, 39);
            this.acLookupEdit2.MenuManager = this.acBarManager1;
            this.acLookupEdit2.Name = "acLookupEdit2";
            this.acLookupEdit2.Properties.Appearance.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.acLookupEdit2.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.acLookupEdit2.Properties.Appearance.Options.UseBackColor = true;
            this.acLookupEdit2.Properties.Appearance.Options.UseForeColor = true;
            this.acLookupEdit2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.acLookupEdit2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.acLookupEdit2.Properties.NullText = "";
            this.acLookupEdit2.Properties.ShowHeader = false;
            this.acLookupEdit2.searchMode = false;
            this.acLookupEdit2.Size = new System.Drawing.Size(379, 24);
            this.acLookupEdit2.StyleController = this.acLayoutControl1;
            this.acLookupEdit2.TabIndex = 33;
            this.acLookupEdit2.ToolTipID = null;
            this.acLookupEdit2.UseToolTipID = false;
            this.acLookupEdit2.Value = null;
            // 
            // acLookupEdit1
            // 
            this.acLookupEdit1.ColumnName = "MDR_TCODE";
            this.acLookupEdit1.DefaultValueType = ControlManager.acLookupEdit.emDefaultValueType.NONE;
            this.acLookupEdit1.isReadyOnly = false;
            this.acLookupEdit1.isRequired = true;
            this.acLookupEdit1.Location = new System.Drawing.Point(108, 5);
            this.acLookupEdit1.MenuManager = this.acBarManager1;
            this.acLookupEdit1.Name = "acLookupEdit1";
            this.acLookupEdit1.Properties.Appearance.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.acLookupEdit1.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.acLookupEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.acLookupEdit1.Properties.Appearance.Options.UseForeColor = true;
            this.acLookupEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.acLookupEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.acLookupEdit1.Properties.NullText = "";
            this.acLookupEdit1.Properties.ShowHeader = false;
            this.acLookupEdit1.searchMode = false;
            this.acLookupEdit1.Size = new System.Drawing.Size(379, 24);
            this.acLookupEdit1.StyleController = this.acLayoutControl1;
            this.acLookupEdit1.TabIndex = 32;
            this.acLookupEdit1.ToolTipID = null;
            this.acLookupEdit1.UseToolTipID = false;
            this.acLookupEdit1.Value = null;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.IsHeader = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.acLayoutControlItem8,
            this.acLayoutControlItem3});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.ResourceID = null;
            this.layoutControlGroup1.Size = new System.Drawing.Size(492, 168);
            this.layoutControlGroup1.TextVisible = false;
            this.layoutControlGroup1.ToolTipID = null;
            this.layoutControlGroup1.UseResourceID = false;
            this.layoutControlGroup1.UseToolTipID = false;
            // 
            // acLayoutControlItem8
            // 
            this.acLayoutControlItem8.Control = this.acLookupEdit1;
            this.acLayoutControlItem8.CustomizationFormText = "비가동구분코드";
            this.acLayoutControlItem8.IsHeader = false;
            this.acLayoutControlItem8.IsTitle = false;
            this.acLayoutControlItem8.Location = new System.Drawing.Point(0, 0);
            this.acLayoutControlItem8.Name = "acLayoutControlItem8";
            this.acLayoutControlItem8.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.acLayoutControlItem8.ResourceID = "AB_L0037";
            this.acLayoutControlItem8.Size = new System.Drawing.Size(492, 34);
            this.acLayoutControlItem8.Text = "비가동구분코드";
            this.acLayoutControlItem8.TextSize = new System.Drawing.Size(91, 18);
            this.acLayoutControlItem8.ToolTipID = null;
            this.acLayoutControlItem8.ToolTipStdCode = null;
            this.acLayoutControlItem8.UseResourceID = true;
            this.acLayoutControlItem8.UseToolTipID = false;
            // 
            // acLayoutControlItem3
            // 
            this.acLayoutControlItem3.Control = this.acLookupEdit2;
            this.acLayoutControlItem3.CustomizationFormText = "비가동원인코드";
            this.acLayoutControlItem3.IsHeader = false;
            this.acLayoutControlItem3.IsTitle = false;
            this.acLayoutControlItem3.Location = new System.Drawing.Point(0, 34);
            this.acLayoutControlItem3.Name = "acLayoutControlItem3";
            this.acLayoutControlItem3.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.acLayoutControlItem3.ResourceID = "AB_L0039";
            this.acLayoutControlItem3.Size = new System.Drawing.Size(492, 134);
            this.acLayoutControlItem3.Text = "비가동원인코드";
            this.acLayoutControlItem3.TextSize = new System.Drawing.Size(91, 18);
            this.acLayoutControlItem3.ToolTipID = null;
            this.acLayoutControlItem3.ToolTipStdCode = null;
            this.acLayoutControlItem3.UseResourceID = true;
            this.acLayoutControlItem3.UseToolTipID = false;
            // 
            // STD63A_D0A
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 212);
            this.Controls.Add(this.acLayoutControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.IconOptions.ShowIcon = false;
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "STD63A_D0A";
            this.ResourceID = "AB_L0036";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "비가동사유 편집기";
            this.UseResourceID = true;
            ((System.ComponentModel.ISupportInitialize)(this.acBarManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControl1)).EndInit();
            this.acLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.acLookupEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLookupEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem3)).EndInit();
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
        private ControlManager.acBarButtonItem barItemDelete;
        private ControlManager.acLayoutControl acLayoutControl1;
        private ControlManager.acLayoutControlGroup layoutControlGroup1;
        private ControlManager.acBarButtonItem barItemClear;
        private ControlManager.acBarButtonItem barItemSave;
        private ControlManager.acBarCheckItem barItemFixedWindow;
        private ControlManager.acLookupEdit acLookupEdit1;
        private ControlManager.acLayoutControlItem acLayoutControlItem8;
        private ControlManager.acLookupEdit acLookupEdit2;
        private ControlManager.acLayoutControlItem acLayoutControlItem3;
    }
}