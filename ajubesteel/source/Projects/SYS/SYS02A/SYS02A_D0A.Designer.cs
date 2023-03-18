namespace SYS
{
    partial class SYS02A_D0A
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SYS02A_D0A));
            this.acLayoutControl1 = new ControlManager.acLayoutControl();
            this.acMemoEdit1 = new ControlManager.acMemoEdit();
            this.txtPrjCode = new ControlManager.acTextEdit();
            this.layoutControlGroup1 = new ControlManager.acLayoutControlGroup();
            this.layoutControlItem2 = new ControlManager.acLayoutControlItem();
            this.acLayoutControlItem1 = new ControlManager.acLayoutControlItem();
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
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControl1)).BeginInit();
            this.acLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.acMemoEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrjCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acBarManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // acLayoutControl1
            // 
            this.acLayoutControl1.AllowCustomization = false;
            this.acLayoutControl1.AutoScroll = false;
            this.acLayoutControl1.ContainerName = null;
            this.acLayoutControl1.Controls.Add(this.acMemoEdit1);
            this.acLayoutControl1.Controls.Add(this.txtPrjCode);
            this.acLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.acLayoutControl1.LayoutType = ControlManager.acLayoutControl.emLayoutType.NONE;
            this.acLayoutControl1.Location = new System.Drawing.Point(0, 36);
            this.acLayoutControl1.Name = "acLayoutControl1";
            this.acLayoutControl1.ParentControl = null;
            this.acLayoutControl1.Root = this.layoutControlGroup1;
            this.acLayoutControl1.Size = new System.Drawing.Size(401, 133);
            this.acLayoutControl1.TabIndex = 1;
            this.acLayoutControl1.Text = "layoutControl1";
            // 
            // acMemoEdit1
            // 
            this.acMemoEdit1.ColumnName = "DESCRIPTION";
            this.acMemoEdit1.isReadyOnly = false;
            this.acMemoEdit1.isRequired = true;
            this.acMemoEdit1.Location = new System.Drawing.Point(67, 47);
            this.acMemoEdit1.MaskType = ControlManager.acMemoEdit.emMaskType.NONE;
            this.acMemoEdit1.Name = "acMemoEdit1";
            this.acMemoEdit1.Properties.Appearance.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.acMemoEdit1.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.acMemoEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.acMemoEdit1.Properties.Appearance.Options.UseFont = true;
            this.acMemoEdit1.Properties.Appearance.Options.UseForeColor = true;
            this.acMemoEdit1.Properties.AppearanceDisabled.Options.UseFont = true;
            this.acMemoEdit1.Properties.AppearanceFocused.Options.UseFont = true;
            this.acMemoEdit1.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.acMemoEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.acMemoEdit1.Size = new System.Drawing.Size(319, 71);
            this.acMemoEdit1.StyleController = this.acLayoutControl1;
            this.acMemoEdit1.TabIndex = 8;
            this.acMemoEdit1.ToolTipID = null;
            this.acMemoEdit1.UseToolTipID = false;
            // 
            // txtPrjCode
            // 
            this.txtPrjCode.ColumnName = "NUMBER";
            this.txtPrjCode.isRequired = true;
            this.txtPrjCode.Location = new System.Drawing.Point(67, 15);
            this.txtPrjCode.MaskType = ControlManager.acTextEdit.emMaskType.NUMBER;
            this.txtPrjCode.Name = "txtPrjCode";
            this.txtPrjCode.Properties.Appearance.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.txtPrjCode.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.txtPrjCode.Properties.Appearance.Options.UseBackColor = true;
            this.txtPrjCode.Properties.Appearance.Options.UseForeColor = true;
            this.txtPrjCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txtPrjCode.Size = new System.Drawing.Size(319, 20);
            this.txtPrjCode.StyleController = this.acLayoutControl1;
            this.txtPrjCode.TabIndex = 5;
            this.txtPrjCode.Tag = "*";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.IsHeader = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2,
            this.acLayoutControlItem1});
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.ResourceID = null;
            this.layoutControlGroup1.Size = new System.Drawing.Size(401, 133);
            this.layoutControlGroup1.TextVisible = false;
            this.layoutControlGroup1.ToolTipID = null;
            this.layoutControlGroup1.UseResourceID = false;
            this.layoutControlGroup1.UseToolTipID = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.AllowHotTrack = false;
            this.layoutControlItem2.Control = this.txtPrjCode;
            this.layoutControlItem2.CustomizationFormText = "오류번호";
            this.layoutControlItem2.IsHeader = false;
            this.layoutControlItem2.IsTitle = false;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.MaxSize = new System.Drawing.Size(0, 32);
            this.layoutControlItem2.MinSize = new System.Drawing.Size(114, 32);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlItem2.ResourceID = "5LI2L784";
            this.layoutControlItem2.Size = new System.Drawing.Size(381, 32);
            this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem2.Text = "오류번호";
            this.layoutControlItem2.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(40, 14);
            this.layoutControlItem2.ToolTipID = null;
            this.layoutControlItem2.ToolTipStdCode = null;
            this.layoutControlItem2.UseResourceID = true;
            this.layoutControlItem2.UseToolTipID = false;
            // 
            // acLayoutControlItem1
            // 
            this.acLayoutControlItem1.Control = this.acMemoEdit1;
            this.acLayoutControlItem1.CustomizationFormText = "내용";
            this.acLayoutControlItem1.IsHeader = false;
            this.acLayoutControlItem1.IsTitle = false;
            this.acLayoutControlItem1.Location = new System.Drawing.Point(0, 32);
            this.acLayoutControlItem1.Name = "acLayoutControlItem1";
            this.acLayoutControlItem1.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.acLayoutControlItem1.ResourceID = "O00RH4SM";
            this.acLayoutControlItem1.Size = new System.Drawing.Size(381, 81);
            this.acLayoutControlItem1.Text = "내용";
            this.acLayoutControlItem1.TextLocation = DevExpress.Utils.Locations.Left;
            this.acLayoutControlItem1.TextSize = new System.Drawing.Size(40, 14);
            this.acLayoutControlItem1.ToolTipID = null;
            this.acLayoutControlItem1.ToolTipStdCode = null;
            this.acLayoutControlItem1.UseResourceID = true;
            this.acLayoutControlItem1.UseToolTipID = false;
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
            this.barItemClear,
            this.barItemSave,
            this.barItemSaveClose,
            this.barItemDelete,
            this.barItemFixedWindow});
            this.acBarManager1.MainMenu = this.bar2;
            this.acBarManager1.MaxItemId = 5;
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
            this.barItemClear.Id = 0;
            this.barItemClear.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barItemClear.ImageOptions.Image")));
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
            this.barItemSave.Id = 1;
            this.barItemSave.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barItemSave.ImageOptions.Image")));
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
            this.barItemSaveClose.Id = 2;
            this.barItemSaveClose.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barItemSaveClose.ImageOptions.Image")));
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
            this.barItemDelete.Id = 3;
            this.barItemDelete.ImageOptions.Image = global::SYS.Resource.edit_delete_2x;
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
            this.barItemFixedWindow.Caption = "acBarCheckItem1";
            this.barItemFixedWindow.Id = 4;
            this.barItemFixedWindow.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barItemFixedWindow.ImageOptions.Image")));
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
            this.barDockControlTop.Size = new System.Drawing.Size(401, 36);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 169);
            this.barDockControlBottom.Manager = this.acBarManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(401, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 36);
            this.barDockControlLeft.Manager = this.acBarManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 133);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(401, 36);
            this.barDockControlRight.Manager = this.acBarManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 133);
            // 
            // SYS02A_D0A
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 169);
            this.Controls.Add(this.acLayoutControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.IconOptions.ShowIcon = false;
            this.Name = "SYS02A_D0A";
            this.ResourceID = "Y2Y9YO0E";
            this.Text = "오류 편집기";
            this.UseResourceID = true;
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControl1)).EndInit();
            this.acLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.acMemoEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrjCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acBarManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ControlManager.acLayoutControl acLayoutControl1;
        private ControlManager.acTextEdit txtPrjCode;
        private ControlManager.acLayoutControlGroup layoutControlGroup1;
        private ControlManager.acLayoutControlItem layoutControlItem2;
        private ControlManager.acBarManager acBarManager1;
        private ControlManager.acBar bar2;

        

        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private ControlManager.acBarButtonItem barItemClear;
        private ControlManager.acBarButtonItem barItemSave;
        private ControlManager.acBarButtonItem barItemSaveClose;
        private ControlManager.acBarButtonItem barItemDelete;
        private ControlManager.acBarCheckItem barItemFixedWindow;
        private ControlManager.acMemoEdit acMemoEdit1;
        private ControlManager.acLayoutControlItem acLayoutControlItem1;
    }
}