﻿namespace CodeHelperManager
{
    partial class acMaterialForm
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
            this.acGridControl1 = new ControlManager.acGridControl();
            this.acGridView1 = new ControlManager.acGridView();
            this.acBarManager1 = new ControlManager.acBarManager(this.components);
            this.bar2 = new ControlManager.acBar();
            this.acBarButtonItem1 = new ControlManager.acBarButtonItem();
            this.acBarButtonItem2 = new ControlManager.acBarButtonItem();
            this.bar3 = new ControlManager.acBar();
            this.statusBarLog = new ControlManager.acBarStaticItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.acGroupControl1 = new ControlManager.acGroupControl();
            this.acLayoutControl1 = new ControlManager.acLayoutControl();
            this.txtPartCode = new ControlManager.acTextEdit();
            this.layoutControlGroup1 = new ControlManager.acLayoutControlGroup();
            this.layoutControlItem2 = new ControlManager.acLayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.acSplitContainerControl1 = new ControlManager.acSplitContainerControl();
            ((System.ComponentModel.ISupportInitialize)(this.acGridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acBarManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acGroupControl1)).BeginInit();
            this.acGroupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControl1)).BeginInit();
            this.acLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPartCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acSplitContainerControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acSplitContainerControl1.Panel1)).BeginInit();
            this.acSplitContainerControl1.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.acSplitContainerControl1.Panel2)).BeginInit();
            this.acSplitContainerControl1.Panel2.SuspendLayout();
            this.acSplitContainerControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // acGridControl1
            // 
            this.acGridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.acGridControl1.Location = new System.Drawing.Point(0, 0);
            this.acGridControl1.MainView = this.acGridView1;
            this.acGridControl1.Name = "acGridControl1";
            this.acGridControl1.Size = new System.Drawing.Size(706, 274);
            this.acGridControl1.TabIndex = 0;
            this.acGridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.acGridView1});
            // 
            // acGridView1
            // 
            this.acGridView1.ColumnPanelRowHeight = 25;
            this.acGridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.acGridView1.GridControl = this.acGridControl1;
            this.acGridView1.IsUserStyle = false;
            this.acGridView1.Name = "acGridView1";
            this.acGridView1.NoApplyEditableCellColor = false;
            this.acGridView1.OptionsBehavior.AutoPopulateColumns = false;
            this.acGridView1.OptionsLayout.Columns.StoreAllOptions = true;
            this.acGridView1.OptionsLayout.StoreAllOptions = true;
            this.acGridView1.OptionsView.ColumnAutoWidth = false;
            this.acGridView1.OptionsView.RowAutoHeight = true;
            this.acGridView1.OptionsView.ShowGroupPanel = false;
            this.acGridView1.OptionsView.ShowIndicator = false;
            this.acGridView1.ParentControl = this;
            this.acGridView1.RowHeight = 30;
            this.acGridView1.SaveFileName = null;
            // 
            // acBarManager1
            // 
            this.acBarManager1.AllowCustomization = false;
            this.acBarManager1.AllowQuickCustomization = false;
            this.acBarManager1.AllowShowToolbarsPopup = false;
            this.acBarManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2,
            this.bar3});
            this.acBarManager1.CloseButtonAffectAllTabs = false;
            this.acBarManager1.DockControls.Add(this.barDockControlTop);
            this.acBarManager1.DockControls.Add(this.barDockControlBottom);
            this.acBarManager1.DockControls.Add(this.barDockControlLeft);
            this.acBarManager1.DockControls.Add(this.barDockControlRight);
            this.acBarManager1.Form = this;
            this.acBarManager1.IsLoadDefaultLayout = true;
            this.acBarManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.statusBarLog,
            this.acBarButtonItem1,
            this.acBarButtonItem2});
            this.acBarManager1.MainMenu = this.bar2;
            this.acBarManager1.MaxItemId = 3;
            this.acBarManager1.StatusBar = this.bar3;
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
            new DevExpress.XtraBars.LinkPersistInfo(this.acBarButtonItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.acBarButtonItem2)});
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
            this.acBarButtonItem1.ButtonShortCutType = ControlManager.acBarManager.emBarShortCutType.SEARCH;
            this.acBarButtonItem1.Caption = "조회";
            this.acBarButtonItem1.Id = 1;
            this.acBarButtonItem1.ImageOptions.Image = global::CodeHelperManager.Resource.system_search_2x;
            this.acBarButtonItem1.Name = "acBarButtonItem1";
            this.acBarButtonItem1.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.acBarButtonItem1.ResourceID = null;
            this.acBarButtonItem1.ToolTipID = "1UMVQFSB";
            this.acBarButtonItem1.UseResourceID = false;
            this.acBarButtonItem1.UseToolTipID = true;
            this.acBarButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.acBarButtonItem1_ItemClick);
            // 
            // acBarButtonItem2
            // 
            this.acBarButtonItem2.ButtonShortCutType = ControlManager.acBarManager.emBarShortCutType.SELECT;
            this.acBarButtonItem2.Caption = "선택";
            this.acBarButtonItem2.Id = 2;
            this.acBarButtonItem2.ImageOptions.Image = global::CodeHelperManager.Resource.dialog_apply_2x;
            this.acBarButtonItem2.Name = "acBarButtonItem2";
            this.acBarButtonItem2.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.acBarButtonItem2.ResourceID = null;
            this.acBarButtonItem2.ToolTipID = "E5QTF4L5";
            this.acBarButtonItem2.UseResourceID = false;
            this.acBarButtonItem2.UseToolTipID = true;
            this.acBarButtonItem2.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.acBarButtonItem2_ItemClick);
            // 
            // bar3
            // 
            this.bar3.BarItemHorzIndent = 10;
            this.bar3.BarItemVertIndent = 5;
            this.bar3.BarName = "Status bar";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.statusBarLog, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.ResourceID = null;
            this.bar3.Text = "Status bar";
            this.bar3.ToolTipID = null;
            this.bar3.UseResourceID = false;
            this.bar3.UseToolTipID = false;
            // 
            // statusBarLog
            // 
            this.statusBarLog.Border = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.statusBarLog.Id = 0;
            this.statusBarLog.ImageOptions.Image = global::CodeHelperManager.Resource.internet_group_chat_1x;
            this.statusBarLog.Name = "statusBarLog";
            this.statusBarLog.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.statusBarLog.ResourceID = null;
            this.statusBarLog.ToolTipID = null;
            this.statusBarLog.UseResourceID = false;
            this.statusBarLog.UseToolTipID = false;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.acBarManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(706, 34);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 371);
            this.barDockControlBottom.Manager = this.acBarManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(706, 30);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 34);
            this.barDockControlLeft.Manager = this.acBarManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 337);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(706, 34);
            this.barDockControlRight.Manager = this.acBarManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 337);
            // 
            // acGroupControl1
            // 
            this.acGroupControl1.Controls.Add(this.acLayoutControl1);
            this.acGroupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.acGroupControl1.IsHeader = false;
            this.acGroupControl1.IsNavPlan = true;
            this.acGroupControl1.Location = new System.Drawing.Point(0, 0);
            this.acGroupControl1.Name = "acGroupControl1";
            this.acGroupControl1.ResourceID = "0ESJ7Q53";
            this.acGroupControl1.Size = new System.Drawing.Size(706, 53);
            this.acGroupControl1.TabIndex = 8;
            this.acGroupControl1.Text = "검색조건";
            this.acGroupControl1.ToolTipID = null;
            this.acGroupControl1.UseResourceID = true;
            this.acGroupControl1.UseToolTipID = false;
            // 
            // acLayoutControl1
            // 
            this.acLayoutControl1.AllowCustomization = false;
            this.acLayoutControl1.AutoScroll = false;
            this.acLayoutControl1.ContainerName = null;
            this.acLayoutControl1.Controls.Add(this.txtPartCode);
            this.acLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.acLayoutControl1.LayoutType = ControlManager.acLayoutControl.emLayoutType.CONDITION;
            this.acLayoutControl1.Location = new System.Drawing.Point(2, 23);
            this.acLayoutControl1.Name = "acLayoutControl1";
            this.acLayoutControl1.ParentControl = null;
            this.acLayoutControl1.Root = this.layoutControlGroup1;
            this.acLayoutControl1.Size = new System.Drawing.Size(702, 28);
            this.acLayoutControl1.TabIndex = 1;
            this.acLayoutControl1.Text = "layoutControl1";
            // 
            // txtPartCode
            // 
            this.txtPartCode.ColumnName = "MAT_LIKE";
            this.txtPartCode.Location = new System.Drawing.Point(76, 5);
            this.txtPartCode.MaskType = ControlManager.acTextEdit.emMaskType.NONE;
            this.txtPartCode.Name = "txtPartCode";
            this.txtPartCode.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtPartCode.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.txtPartCode.Properties.Appearance.Options.UseBackColor = true;
            this.txtPartCode.Properties.Appearance.Options.UseForeColor = true;
            this.txtPartCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txtPartCode.Size = new System.Drawing.Size(270, 20);
            this.txtPartCode.StyleController = this.acLayoutControl1;
            this.txtPartCode.TabIndex = 12;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.IsHeader = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2,
            this.emptySpaceItem1,
            this.emptySpaceItem2});
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.ResourceID = null;
            this.layoutControlGroup1.Size = new System.Drawing.Size(702, 40);
            this.layoutControlGroup1.TextVisible = false;
            this.layoutControlGroup1.ToolTipID = null;
            this.layoutControlGroup1.UseResourceID = false;
            this.layoutControlGroup1.UseToolTipID = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.AllowHotTrack = false;
            this.layoutControlItem2.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem2.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.layoutControlItem2.AppearanceItemCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.layoutControlItem2.Control = this.txtPartCode;
            this.layoutControlItem2.CustomizationFormText = "재질 코드/명";
            this.layoutControlItem2.IsHeader = false;
            this.layoutControlItem2.IsTitle = false;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlItem2.ResourceID = "GIIQP46F";
            this.layoutControlItem2.Size = new System.Drawing.Size(351, 30);
            this.layoutControlItem2.Text = "재질 코드/명";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(59, 14);
            this.layoutControlItem2.ToolTipID = null;
            this.layoutControlItem2.ToolTipStdCode = null;
            this.layoutControlItem2.UseResourceID = true;
            this.layoutControlItem2.UseToolTipID = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(351, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(351, 30);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.CustomizationFormText = "emptySpaceItem2";
            this.emptySpaceItem2.Location = new System.Drawing.Point(0, 30);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(702, 10);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // acSplitContainerControl1
            // 
            this.acSplitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.acSplitContainerControl1.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.None;
            this.acSplitContainerControl1.Horizontal = false;
            this.acSplitContainerControl1.Location = new System.Drawing.Point(0, 34);
            this.acSplitContainerControl1.Name = "acSplitContainerControl1";
            // 
            // acSplitContainerControl1.Panel1
            // 
            this.acSplitContainerControl1.Panel1.Controls.Add(this.acGroupControl1);
            this.acSplitContainerControl1.Panel1.Text = "Panel1";
            // 
            // acSplitContainerControl1.Panel2
            // 
            this.acSplitContainerControl1.Panel2.Controls.Add(this.acGridControl1);
            this.acSplitContainerControl1.Panel2.Text = "Panel2";
            this.acSplitContainerControl1.ParentControl = null;
            this.acSplitContainerControl1.Size = new System.Drawing.Size(706, 337);
            this.acSplitContainerControl1.SplitterPosition = 53;
            this.acSplitContainerControl1.TabIndex = 9;
            this.acSplitContainerControl1.Text = "acSplitContainerControl1";
            // 
            // acMaterialForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(706, 401);
            this.Controls.Add(this.acSplitContainerControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.IconOptions.ShowIcon = false;
            this.Name = "acMaterialForm";
            this.ResourceID = "OY8W1KI7";
            this.Text = "재질 찾기";
            this.UseResourceID = true;
            ((System.ComponentModel.ISupportInitialize)(this.acGridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acBarManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acGroupControl1)).EndInit();
            this.acGroupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControl1)).EndInit();
            this.acLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtPartCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acSplitContainerControl1.Panel1)).EndInit();
            this.acSplitContainerControl1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.acSplitContainerControl1.Panel2)).EndInit();
            this.acSplitContainerControl1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.acSplitContainerControl1)).EndInit();
            this.acSplitContainerControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ControlManager.acGridControl acGridControl1;
        private ControlManager.acGridView acGridView1;
        private ControlManager.acBarManager acBarManager1;
        private ControlManager.acBar bar2;
        private ControlManager.acBarButtonItem acBarButtonItem1;
        private ControlManager.acBar bar3;



        private ControlManager.acBarStaticItem statusBarLog;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private ControlManager.acGroupControl acGroupControl1;
        private ControlManager.acLayoutControl acLayoutControl1;
        private ControlManager.acTextEdit txtPartCode;
        private ControlManager.acLayoutControlGroup layoutControlGroup1;
        private ControlManager.acLayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private ControlManager.acBarButtonItem acBarButtonItem2;
        private ControlManager.acSplitContainerControl acSplitContainerControl1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
    }
}