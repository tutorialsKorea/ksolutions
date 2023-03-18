namespace SYS
{
    partial class SYS16A_D2A
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
            this.acPictureEdit1 = new ControlManager.acPictureEdit();
            this.acBarManager1 = new ControlManager.acBarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barItemClear = new ControlManager.acBarButtonItem();
            this.barItemSave = new ControlManager.acBarButtonItem();
            this.barItemSaveClose = new ControlManager.acBarButtonItem();
            this.barItemDelete = new ControlManager.acBarButtonItem();
            this.barItemFixedWindow = new ControlManager.acBarCheckItem();
            this.layoutControlGroup1 = new ControlManager.acLayoutControlGroup();
            this.acLayoutControlItem1 = new ControlManager.acLayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControl1)).BeginInit();
            this.acLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.acPictureEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acBarManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // acLayoutControl1
            // 
            this.acLayoutControl1.AllowCustomization = false;
            this.acLayoutControl1.AutoScroll = false;
            this.acLayoutControl1.ContainerName = null;
            this.acLayoutControl1.Controls.Add(this.acPictureEdit1);
            this.acLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.acLayoutControl1.LayoutType = ControlManager.acLayoutControl.emLayoutType.NONE;
            this.acLayoutControl1.Location = new System.Drawing.Point(0, 0);
            this.acLayoutControl1.Name = "acLayoutControl1";
            this.acLayoutControl1.ParentControl = null;
            this.acLayoutControl1.Root = this.layoutControlGroup1;
            this.acLayoutControl1.Size = new System.Drawing.Size(659, 669);
            this.acLayoutControl1.TabIndex = 1;
            this.acLayoutControl1.Text = "layoutControl1";
            // 
            // acPictureEdit1
            // 
            this.acPictureEdit1.ColumnName = null;
            this.acPictureEdit1.EditValue = global::SYS.Resource.심사평가표;
            this.acPictureEdit1.isReadyOnly = false;
            this.acPictureEdit1.isRequired = false;
            this.acPictureEdit1.Location = new System.Drawing.Point(15, 15);
            this.acPictureEdit1.MenuManager = this.acBarManager1;
            this.acPictureEdit1.Name = "acPictureEdit1";
            this.acPictureEdit1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.acPictureEdit1.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.acPictureEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.acPictureEdit1.Properties.Appearance.Options.UseForeColor = true;
            this.acPictureEdit1.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.acPictureEdit1.Properties.ShowScrollBars = true;
            this.acPictureEdit1.Size = new System.Drawing.Size(629, 639);
            this.acPictureEdit1.StyleController = this.acLayoutControl1;
            this.acPictureEdit1.TabIndex = 4;
            this.acPictureEdit1.ToolTipID = null;
            this.acPictureEdit1.UseToolTipID = false;
            // 
            // acBarManager1
            // 
            this.acBarManager1.AllowCustomization = false;
            this.acBarManager1.AllowQuickCustomization = false;
            this.acBarManager1.AllowShowToolbarsPopup = false;
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
            this.acBarManager1.MaxItemId = 5;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.acBarManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(659, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 669);
            this.barDockControlBottom.Manager = this.acBarManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(659, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Manager = this.acBarManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 669);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(659, 0);
            this.barDockControlRight.Manager = this.acBarManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 669);
            // 
            // barItemClear
            // 
            this.barItemClear.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.barItemClear.ButtonShortCutType = ControlManager.acBarManager.emBarShortCutType.CLEAR;
            this.barItemClear.Caption = "초기화";
            this.barItemClear.Id = 0;
            this.barItemClear.ImageOptions.Image = global::SYS.Resource.edit_clear_2x;
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
            this.barItemSave.ImageOptions.Image = global::SYS.Resource.document_save_2x;
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
            this.barItemSaveClose.ImageOptions.Image = global::SYS.Resource.document_save_close_2x;
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
            this.barItemFixedWindow.ImageOptions.Image = global::SYS.Resource.emblem_readonly_2x;
            this.barItemFixedWindow.Name = "barItemFixedWindow";
            this.barItemFixedWindow.ResourceID = null;
            this.barItemFixedWindow.ToolTipID = "IPF2LX1S";
            this.barItemFixedWindow.UseResourceID = false;
            this.barItemFixedWindow.UseToolTipID = true;
            this.barItemFixedWindow.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.barItemFixedWindow_CheckedChanged);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.IsHeader = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.acLayoutControlItem1});
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.ResourceID = null;
            this.layoutControlGroup1.Size = new System.Drawing.Size(659, 669);
            this.layoutControlGroup1.TextVisible = false;
            this.layoutControlGroup1.ToolTipID = null;
            this.layoutControlGroup1.UseResourceID = false;
            this.layoutControlGroup1.UseToolTipID = false;
            // 
            // acLayoutControlItem1
            // 
            this.acLayoutControlItem1.Control = this.acPictureEdit1;
            this.acLayoutControlItem1.CustomizationFormText = "acLayoutControlItem1";
            this.acLayoutControlItem1.IsHeader = false;
            this.acLayoutControlItem1.IsTitle = false;
            this.acLayoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.acLayoutControlItem1.Name = "acLayoutControlItem1";
            this.acLayoutControlItem1.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.acLayoutControlItem1.ResourceID = null;
            this.acLayoutControlItem1.Size = new System.Drawing.Size(639, 649);
            this.acLayoutControlItem1.Text = "acLayoutControlItem1";
            this.acLayoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.acLayoutControlItem1.TextVisible = false;
            this.acLayoutControlItem1.ToolTipID = null;
            this.acLayoutControlItem1.ToolTipStdCode = null;
            this.acLayoutControlItem1.UseResourceID = false;
            this.acLayoutControlItem1.UseToolTipID = false;
            // 
            // SYS16A_D2A
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 669);
            this.Controls.Add(this.acLayoutControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.IconOptions.ShowIcon = false;
            this.Name = "SYS16A_D2A";
            this.ResourceID = "";
            this.Text = "개선제안 심사평가 기준표";
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControl1)).EndInit();
            this.acLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.acPictureEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acBarManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ControlManager.acLayoutControl acLayoutControl1;
        private ControlManager.acLayoutControlGroup layoutControlGroup1;
        private ControlManager.acBarManager acBarManager1;

        

        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private ControlManager.acBarButtonItem barItemClear;
        private ControlManager.acBarButtonItem barItemSave;
        private ControlManager.acBarButtonItem barItemSaveClose;
        private ControlManager.acBarButtonItem barItemDelete;
        private ControlManager.acBarCheckItem barItemFixedWindow;
        private ControlManager.acPictureEdit acPictureEdit1;
        private ControlManager.acLayoutControlItem acLayoutControlItem1;
    }
}