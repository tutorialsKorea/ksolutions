﻿namespace STD
{
    partial class STD14A_D0A
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
            this.acMemoEdit1 = new ControlManager.acMemoEdit();
            this.acCheckEdit1 = new ControlManager.acCheckEdit();
            this.acLookupEdit1 = new ControlManager.acLookupEdit();
            this.acTextEdit2 = new ControlManager.acTextEdit();
            this.acTextEdit1 = new ControlManager.acTextEdit();
            this.layoutControlGroup1 = new ControlManager.acLayoutControlGroup();
            this.acLayoutControlItem1 = new ControlManager.acLayoutControlItem();
            this.acLayoutControlItem2 = new ControlManager.acLayoutControlItem();
            this.acLayoutControlItem3 = new ControlManager.acLayoutControlItem();
            this.acLayoutControlItem5 = new ControlManager.acLayoutControlItem();
            this.acLayoutControlItem6 = new ControlManager.acLayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.acBarManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControl1)).BeginInit();
            this.acLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.acMemoEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acCheckEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLookupEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acTextEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acTextEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem6)).BeginInit();
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
            new DevExpress.XtraBars.LinkPersistInfo(this.barItemClear),
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
            this.barItemFixedWindow.Caption = "칭고정";
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
            this.barDockControlTop.Size = new System.Drawing.Size(395, 36);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 232);
            this.barDockControlBottom.Manager = this.acBarManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(395, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 36);
            this.barDockControlLeft.Manager = this.acBarManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 196);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(395, 36);
            this.barDockControlRight.Manager = this.acBarManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 196);
            // 
            // acLayoutControl1
            // 
            this.acLayoutControl1.AllowCustomization = false;
            this.acLayoutControl1.AutoScroll = false;
            this.acLayoutControl1.ContainerName = null;
            this.acLayoutControl1.Controls.Add(this.acMemoEdit1);
            this.acLayoutControl1.Controls.Add(this.acCheckEdit1);
            this.acLayoutControl1.Controls.Add(this.acLookupEdit1);
            this.acLayoutControl1.Controls.Add(this.acTextEdit2);
            this.acLayoutControl1.Controls.Add(this.acTextEdit1);
            this.acLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.acLayoutControl1.LayoutType = ControlManager.acLayoutControl.emLayoutType.NONE;
            this.acLayoutControl1.Location = new System.Drawing.Point(0, 36);
            this.acLayoutControl1.Name = "acLayoutControl1";
            this.acLayoutControl1.ParentControl = null;
            this.acLayoutControl1.Root = this.layoutControlGroup1;
            this.acLayoutControl1.Size = new System.Drawing.Size(395, 196);
            this.acLayoutControl1.TabIndex = 4;
            this.acLayoutControl1.Text = "acLayoutControl1";
            // 
            // acMemoEdit1
            // 
            this.acMemoEdit1.ColumnName = "SCOMMENT";
            this.acMemoEdit1.isReadyOnly = false;
            this.acMemoEdit1.isRequired = false;
            this.acMemoEdit1.Location = new System.Drawing.Point(57, 125);
            this.acMemoEdit1.MaskType = ControlManager.acMemoEdit.emMaskType.SHORT_COMMENT;
            this.acMemoEdit1.Name = "acMemoEdit1";
            this.acMemoEdit1.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.acMemoEdit1.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.acMemoEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.acMemoEdit1.Properties.Appearance.Options.UseFont = true;
            this.acMemoEdit1.Properties.Appearance.Options.UseForeColor = true;
            this.acMemoEdit1.Properties.AppearanceDisabled.Options.UseFont = true;
            this.acMemoEdit1.Properties.AppearanceFocused.Options.UseFont = true;
            this.acMemoEdit1.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.acMemoEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.acMemoEdit1.Size = new System.Drawing.Size(333, 66);
            this.acMemoEdit1.StyleController = this.acLayoutControl1;
            this.acMemoEdit1.TabIndex = 4;
            this.acMemoEdit1.ToolTipID = null;
            this.acMemoEdit1.UseToolTipID = false;
            // 
            // acCheckEdit1
            // 
            this.acCheckEdit1.ColumnName = "IS_FIXED_CD";
            this.acCheckEdit1.EditValue = ((byte)(0));
            this.acCheckEdit1.isReadyOnly = false;
            this.acCheckEdit1.isRequired = false;
            this.acCheckEdit1.Location = new System.Drawing.Point(5, 65);
            this.acCheckEdit1.Name = "acCheckEdit1";
            this.acCheckEdit1.Properties.Caption = "고정코드여부";
            this.acCheckEdit1.Properties.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            this.acCheckEdit1.Properties.ValueChecked = ((byte)(1));
            this.acCheckEdit1.Properties.ValueUnchecked = ((byte)(0));
            this.acCheckEdit1.Size = new System.Drawing.Size(385, 20);
            this.acCheckEdit1.StyleController = this.acLayoutControl1;
            this.acCheckEdit1.TabIndex = 2;
            this.acCheckEdit1.ToolTipID = null;
            this.acCheckEdit1.UseToolTipID = false;
            this.acCheckEdit1.Value = ((byte)(0));
            this.acCheckEdit1.ValueType = ControlManager.acCheckEdit.emValueType.BYTE;
            // 
            // acLookupEdit1
            // 
            this.acLookupEdit1.ColumnName = "CAT_PARENT";
            this.acLookupEdit1.DefaultValueType = ControlManager.acLookupEdit.emDefaultValueType.NONE;
            this.acLookupEdit1.isReadyOnly = false;
            this.acLookupEdit1.isRequired = false;
            this.acLookupEdit1.Location = new System.Drawing.Point(57, 95);
            this.acLookupEdit1.Name = "acLookupEdit1";
            this.acLookupEdit1.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.acLookupEdit1.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.acLookupEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.acLookupEdit1.Properties.Appearance.Options.UseForeColor = true;
            this.acLookupEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.acLookupEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.acLookupEdit1.Properties.NullText = "";
            this.acLookupEdit1.Properties.ShowHeader = false;
            this.acLookupEdit1.Size = new System.Drawing.Size(333, 20);
            this.acLookupEdit1.StyleController = this.acLayoutControl1;
            this.acLookupEdit1.TabIndex = 3;
            this.acLookupEdit1.ToolTipID = null;
            this.acLookupEdit1.UseToolTipID = false;
            this.acLookupEdit1.Value = null;
            // 
            // acTextEdit2
            // 
            this.acTextEdit2.ColumnName = "CAT_NAME";
            this.acTextEdit2.isRequired = true;
            this.acTextEdit2.Location = new System.Drawing.Point(57, 35);
            this.acTextEdit2.MaskType = ControlManager.acTextEdit.emMaskType.STD_NAME;
            this.acTextEdit2.Name = "acTextEdit2";
            this.acTextEdit2.Properties.Appearance.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.acTextEdit2.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.acTextEdit2.Properties.Appearance.Options.UseBackColor = true;
            this.acTextEdit2.Properties.Appearance.Options.UseForeColor = true;
            this.acTextEdit2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.acTextEdit2.Properties.MaxLength = 50;
            this.acTextEdit2.Size = new System.Drawing.Size(333, 20);
            this.acTextEdit2.StyleController = this.acLayoutControl1;
            this.acTextEdit2.TabIndex = 1;
            // 
            // acTextEdit1
            // 
            this.acTextEdit1.ColumnName = "CAT_CODE";
            this.acTextEdit1.isRequired = true;
            this.acTextEdit1.Location = new System.Drawing.Point(57, 5);
            this.acTextEdit1.MaskType = ControlManager.acTextEdit.emMaskType.STD_NAME;
            this.acTextEdit1.Name = "acTextEdit1";
            this.acTextEdit1.Properties.Appearance.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.acTextEdit1.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.acTextEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.acTextEdit1.Properties.Appearance.Options.UseForeColor = true;
            this.acTextEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.acTextEdit1.Properties.MaxLength = 4;
            this.acTextEdit1.Size = new System.Drawing.Size(333, 20);
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
            this.acLayoutControlItem2,
            this.acLayoutControlItem3,
            this.acLayoutControlItem5,
            this.acLayoutControlItem6});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.ResourceID = null;
            this.layoutControlGroup1.Size = new System.Drawing.Size(395, 196);
            this.layoutControlGroup1.TextVisible = false;
            this.layoutControlGroup1.ToolTipID = null;
            this.layoutControlGroup1.UseResourceID = false;
            this.layoutControlGroup1.UseToolTipID = false;
            // 
            // acLayoutControlItem1
            // 
            this.acLayoutControlItem1.Control = this.acTextEdit1;
            this.acLayoutControlItem1.CustomizationFormText = "분류코드";
            this.acLayoutControlItem1.IsHeader = false;
            this.acLayoutControlItem1.IsTitle = false;
            this.acLayoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.acLayoutControlItem1.Name = "acLayoutControlItem1";
            this.acLayoutControlItem1.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.acLayoutControlItem1.ResourceID = "4O9IJCLM";
            this.acLayoutControlItem1.Size = new System.Drawing.Size(395, 30);
            this.acLayoutControlItem1.Text = "분류코드";
            this.acLayoutControlItem1.TextSize = new System.Drawing.Size(40, 14);
            this.acLayoutControlItem1.ToolTipID = null;
            this.acLayoutControlItem1.ToolTipStdCode = null;
            this.acLayoutControlItem1.UseResourceID = true;
            this.acLayoutControlItem1.UseToolTipID = false;
            // 
            // acLayoutControlItem2
            // 
            this.acLayoutControlItem2.Control = this.acTextEdit2;
            this.acLayoutControlItem2.CustomizationFormText = "분류명";
            this.acLayoutControlItem2.IsHeader = false;
            this.acLayoutControlItem2.IsTitle = false;
            this.acLayoutControlItem2.Location = new System.Drawing.Point(0, 30);
            this.acLayoutControlItem2.Name = "acLayoutControlItem2";
            this.acLayoutControlItem2.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.acLayoutControlItem2.ResourceID = "I9J5CC12";
            this.acLayoutControlItem2.Size = new System.Drawing.Size(395, 30);
            this.acLayoutControlItem2.Text = "분류명";
            this.acLayoutControlItem2.TextSize = new System.Drawing.Size(40, 14);
            this.acLayoutControlItem2.ToolTipID = null;
            this.acLayoutControlItem2.ToolTipStdCode = null;
            this.acLayoutControlItem2.UseResourceID = true;
            this.acLayoutControlItem2.UseToolTipID = false;
            // 
            // acLayoutControlItem3
            // 
            this.acLayoutControlItem3.Control = this.acLookupEdit1;
            this.acLayoutControlItem3.CustomizationFormText = "상위분류";
            this.acLayoutControlItem3.IsHeader = false;
            this.acLayoutControlItem3.IsTitle = false;
            this.acLayoutControlItem3.Location = new System.Drawing.Point(0, 90);
            this.acLayoutControlItem3.Name = "acLayoutControlItem3";
            this.acLayoutControlItem3.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.acLayoutControlItem3.ResourceID = "ZIKYSISY";
            this.acLayoutControlItem3.Size = new System.Drawing.Size(395, 30);
            this.acLayoutControlItem3.Text = "상위분류";
            this.acLayoutControlItem3.TextSize = new System.Drawing.Size(40, 14);
            this.acLayoutControlItem3.ToolTipID = null;
            this.acLayoutControlItem3.ToolTipStdCode = null;
            this.acLayoutControlItem3.UseResourceID = true;
            this.acLayoutControlItem3.UseToolTipID = false;
            // 
            // acLayoutControlItem5
            // 
            this.acLayoutControlItem5.Control = this.acCheckEdit1;
            this.acLayoutControlItem5.CustomizationFormText = "acLayoutControlItem5";
            this.acLayoutControlItem5.IsHeader = false;
            this.acLayoutControlItem5.IsTitle = false;
            this.acLayoutControlItem5.Location = new System.Drawing.Point(0, 60);
            this.acLayoutControlItem5.Name = "acLayoutControlItem5";
            this.acLayoutControlItem5.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.acLayoutControlItem5.ResourceID = "5X8J3FYD";
            this.acLayoutControlItem5.Size = new System.Drawing.Size(395, 30);
            this.acLayoutControlItem5.Text = "acLayoutControlItem5";
            this.acLayoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.acLayoutControlItem5.TextVisible = false;
            this.acLayoutControlItem5.ToolTipID = null;
            this.acLayoutControlItem5.ToolTipStdCode = null;
            this.acLayoutControlItem5.UseResourceID = true;
            this.acLayoutControlItem5.UseToolTipID = false;
            // 
            // acLayoutControlItem6
            // 
            this.acLayoutControlItem6.Control = this.acMemoEdit1;
            this.acLayoutControlItem6.CustomizationFormText = "비고";
            this.acLayoutControlItem6.IsHeader = false;
            this.acLayoutControlItem6.IsTitle = false;
            this.acLayoutControlItem6.Location = new System.Drawing.Point(0, 120);
            this.acLayoutControlItem6.Name = "acLayoutControlItem6";
            this.acLayoutControlItem6.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.acLayoutControlItem6.ResourceID = "ARYZ726K";
            this.acLayoutControlItem6.Size = new System.Drawing.Size(395, 76);
            this.acLayoutControlItem6.Text = "비고";
            this.acLayoutControlItem6.TextSize = new System.Drawing.Size(40, 14);
            this.acLayoutControlItem6.ToolTipID = null;
            this.acLayoutControlItem6.ToolTipStdCode = null;
            this.acLayoutControlItem6.UseResourceID = false;
            this.acLayoutControlItem6.UseToolTipID = false;
            // 
            // STD14A_D0A
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(395, 232);
            this.Controls.Add(this.acLayoutControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.IconOptions.ShowIcon = false;
            this.Name = "STD14A_D0A";
            this.ResourceID = "ASSHCM37";
            this.Text = "분류코드 편집기";
            this.UseResourceID = true;
            ((System.ComponentModel.ISupportInitialize)(this.acBarManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControl1)).EndInit();
            this.acLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.acMemoEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acCheckEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLookupEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acTextEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acTextEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem6)).EndInit();
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
        private ControlManager.acLookupEdit acLookupEdit1;
        private ControlManager.acTextEdit acTextEdit2;
        private ControlManager.acTextEdit acTextEdit1;
        private ControlManager.acLayoutControlGroup layoutControlGroup1;
        private ControlManager.acLayoutControlItem acLayoutControlItem1;
        private ControlManager.acLayoutControlItem acLayoutControlItem2;
        private ControlManager.acLayoutControlItem acLayoutControlItem3;
        private ControlManager.acBarButtonItem barItemClear;
        private ControlManager.acBarButtonItem barItemSave;
        private ControlManager.acBarCheckItem barItemFixedWindow;
        private ControlManager.acCheckEdit acCheckEdit1;
        private ControlManager.acLayoutControlItem acLayoutControlItem5;
        private ControlManager.acMemoEdit acMemoEdit1;
        private ControlManager.acLayoutControlItem acLayoutControlItem6;
    }
}