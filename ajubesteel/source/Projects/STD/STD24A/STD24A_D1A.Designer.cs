﻿namespace STD
{
    partial class STD24A_D1A
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
            this.acMemoEdit1 = new ControlManager.acMemoEdit();
            this.acBarManager1 = new ControlManager.acBarManager(this.components);
            this.bar2 = new ControlManager.acBar();
            this.barItemSave = new ControlManager.acBarButtonItem();
            this.barItemSaveClose = new ControlManager.acBarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.acTextEdit2 = new ControlManager.acTextEdit();
            this.layoutControlGroup1 = new ControlManager.acLayoutControlGroup();
            this.acLayoutControlItem2 = new ControlManager.acLayoutControlItem();
            this.acLayoutControlItem4 = new ControlManager.acLayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControl1)).BeginInit();
            this.acLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.acMemoEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acBarManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acTextEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem4)).BeginInit();
            this.SuspendLayout();
            // 
            // acLayoutControl1
            // 
            this.acLayoutControl1.AllowCustomization = false;
            this.acLayoutControl1.AutoScroll = false;
            this.acLayoutControl1.ContainerName = null;
            this.acLayoutControl1.Controls.Add(this.acMemoEdit1);
            this.acLayoutControl1.Controls.Add(this.acTextEdit2);
            this.acLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.acLayoutControl1.LayoutType = ControlManager.acLayoutControl.emLayoutType.NONE;
            this.acLayoutControl1.Location = new System.Drawing.Point(0, 36);
            this.acLayoutControl1.Name = "acLayoutControl1";
            this.acLayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(2622, 0, 650, 400);
            this.acLayoutControl1.ParentControl = null;
            this.acLayoutControl1.Root = this.layoutControlGroup1;
            this.acLayoutControl1.Size = new System.Drawing.Size(391, 195);
            this.acLayoutControl1.TabIndex = 1;
            this.acLayoutControl1.Text = "layoutControl1";
            // 
            // acMemoEdit1
            // 
            this.acMemoEdit1.ColumnName = "SCOMMENT";
            this.acMemoEdit1.isReadyOnly = false;
            this.acMemoEdit1.isRequired = true;
            this.acMemoEdit1.Location = new System.Drawing.Point(47, 35);
            this.acMemoEdit1.MaskType = ControlManager.acMemoEdit.emMaskType.NONE;
            this.acMemoEdit1.MenuManager = this.acBarManager1;
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
            this.acMemoEdit1.Size = new System.Drawing.Size(339, 155);
            this.acMemoEdit1.StyleController = this.acLayoutControl1;
            this.acMemoEdit1.TabIndex = 7;
            this.acMemoEdit1.ToolTipID = null;
            this.acMemoEdit1.UseToolTipID = false;
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
            this.barItemSaveClose,
            this.barItemSave});
            this.acBarManager1.MainMenu = this.bar2;
            this.acBarManager1.MaxItemId = 2;
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
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barItemSaveClose, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
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
            this.barItemSave.Id = 1;
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
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.acBarManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(391, 36);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 231);
            this.barDockControlBottom.Manager = this.acBarManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(391, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 36);
            this.barDockControlLeft.Manager = this.acBarManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 195);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(391, 36);
            this.barDockControlRight.Manager = this.acBarManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 195);
            // 
            // acTextEdit2
            // 
            this.acTextEdit2.ColumnName = "CAUSE_NAME";
            this.acTextEdit2.isRequired = true;
            this.acTextEdit2.Location = new System.Drawing.Point(47, 5);
            this.acTextEdit2.MaskType = ControlManager.acTextEdit.emMaskType.NONE;
            this.acTextEdit2.MenuManager = this.acBarManager1;
            this.acTextEdit2.Name = "acTextEdit2";
            this.acTextEdit2.Properties.Appearance.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.acTextEdit2.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.acTextEdit2.Properties.Appearance.Options.UseBackColor = true;
            this.acTextEdit2.Properties.Appearance.Options.UseForeColor = true;
            this.acTextEdit2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.acTextEdit2.Size = new System.Drawing.Size(339, 20);
            this.acTextEdit2.StyleController = this.acLayoutControl1;
            this.acTextEdit2.TabIndex = 5;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "Root";
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.IsHeader = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.acLayoutControlItem2,
            this.acLayoutControlItem4});
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.ResourceID = null;
            this.layoutControlGroup1.Size = new System.Drawing.Size(391, 195);
            this.layoutControlGroup1.TextVisible = false;
            this.layoutControlGroup1.ToolTipID = null;
            this.layoutControlGroup1.UseResourceID = false;
            this.layoutControlGroup1.UseToolTipID = false;
            // 
            // acLayoutControlItem2
            // 
            this.acLayoutControlItem2.Control = this.acTextEdit2;
            this.acLayoutControlItem2.CustomizationFormText = "사유명";
            this.acLayoutControlItem2.IsHeader = false;
            this.acLayoutControlItem2.IsTitle = false;
            this.acLayoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.acLayoutControlItem2.Name = "acLayoutControlItem2";
            this.acLayoutControlItem2.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.acLayoutControlItem2.ResourceID = null;
            this.acLayoutControlItem2.Size = new System.Drawing.Size(391, 30);
            this.acLayoutControlItem2.Text = "사유명";
            this.acLayoutControlItem2.TextSize = new System.Drawing.Size(30, 14);
            this.acLayoutControlItem2.ToolTipID = null;
            this.acLayoutControlItem2.ToolTipStdCode = null;
            this.acLayoutControlItem2.UseResourceID = false;
            this.acLayoutControlItem2.UseToolTipID = false;
            // 
            // acLayoutControlItem4
            // 
            this.acLayoutControlItem4.Control = this.acMemoEdit1;
            this.acLayoutControlItem4.CustomizationFormText = "내용";
            this.acLayoutControlItem4.IsHeader = false;
            this.acLayoutControlItem4.IsTitle = false;
            this.acLayoutControlItem4.Location = new System.Drawing.Point(0, 30);
            this.acLayoutControlItem4.Name = "acLayoutControlItem4";
            this.acLayoutControlItem4.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.acLayoutControlItem4.ResourceID = null;
            this.acLayoutControlItem4.Size = new System.Drawing.Size(391, 165);
            this.acLayoutControlItem4.Text = "내용";
            this.acLayoutControlItem4.TextSize = new System.Drawing.Size(30, 14);
            this.acLayoutControlItem4.ToolTipID = null;
            this.acLayoutControlItem4.ToolTipStdCode = null;
            this.acLayoutControlItem4.UseResourceID = false;
            this.acLayoutControlItem4.UseToolTipID = false;
            // 
            // STD24A_D1A
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(391, 231);
            this.Controls.Add(this.acLayoutControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.IconOptions.ShowIcon = false;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "STD24A_D1A";
            this.ResourceID = "";
            this.Text = "근태사유 편집기";
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControl1)).EndInit();
            this.acLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.acMemoEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acBarManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acTextEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ControlManager.acLayoutControl acLayoutControl1;
        private ControlManager.acLayoutControlGroup layoutControlGroup1;
        private ControlManager.acBarManager acBarManager1;
        private ControlManager.acBar bar2;
        private ControlManager.acBarButtonItem barItemSaveClose;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private ControlManager.acBarButtonItem barItemSave;
        private ControlManager.acMemoEdit acMemoEdit1;
        private ControlManager.acTextEdit acTextEdit2;
        private ControlManager.acLayoutControlItem acLayoutControlItem2;
        private ControlManager.acLayoutControlItem acLayoutControlItem4;
    }
}