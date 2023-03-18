namespace AttachFileManager
{
    partial class acAttachFileControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.acBarManager1 = new ControlManager.acBarManager();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.btnDownload = new ControlManager.acBarButtonItem();
            this.btnDelete = new ControlManager.acBarButtonItem();
            this.btnOpen = new ControlManager.acBarButtonItem();
            this.btnRename = new ControlManager.acBarButtonItem();
            this.btnUpload = new ControlManager.acBarButtonItem();
            this.btnCancel = new ControlManager.acBarButtonItem();
            this.acBarSubItem1 = new ControlManager.acBarSubItem();
            this.FileGridControl = new ControlManager.acGridControl();
            this.FileGridView = new ControlManager.acGridView();
            this.acTabControl1 = new ControlManager.acTabControl();
            this.acTabPage1 = new ControlManager.acTabPage();
            this.acTabPage2 = new ControlManager.acTabPage();
            this.FileTransferGridControl = new ControlManager.acGridControl();
            this.FileTransferGridView = new ControlManager.acGridView();
            this.acTabPage3 = new ControlManager.acTabPage();
            this.FileDelHistoryGridControl = new ControlManager.acGridControl();
            this.FileDelHistoryGridView = new ControlManager.acGridView();
            this.popupMenu1 = new DevExpress.XtraBars.PopupMenu();
            this.popupMenu2 = new DevExpress.XtraBars.PopupMenu();
            ((System.ComponentModel.ISupportInitialize)(this.acBarManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FileGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FileGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acTabControl1)).BeginInit();
            this.acTabControl1.SuspendLayout();
            this.acTabPage1.SuspendLayout();
            this.acTabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FileTransferGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FileTransferGridView)).BeginInit();
            this.acTabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FileDelHistoryGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FileDelHistoryGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu2)).BeginInit();
            this.SuspendLayout();
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
            this.btnDownload,
            this.btnDelete,
            this.btnOpen,
            this.btnRename,
            this.btnUpload,
            this.btnCancel,
            this.acBarSubItem1});
            this.acBarManager1.MaxItemId = 22;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(680, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 280);
            this.barDockControlBottom.Size = new System.Drawing.Size(680, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 280);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(680, 0);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 280);
            // 
            // btnDownload
            // 
            this.btnDownload.Caption = "내려받기";
            this.btnDownload.Glyph = global::AttachFileManager.Resource.browser_download_1x;
            this.btnDownload.Id = 8;
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.ResourceID = "WEF7PSFW";
            this.btnDownload.ToolTipID = null;
            this.btnDownload.UseResourceID = true;
            this.btnDownload.UseToolTipID = false;
            this.btnDownload.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDownload_ItemClick);
            // 
            // btnDelete
            // 
            this.btnDelete.Caption = "파일삭제";
            this.btnDelete.Glyph = global::AttachFileManager.Resource.edit_delete_1x;
            this.btnDelete.Id = 10;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.ResourceID = "E0W8BN84";
            this.btnDelete.ToolTipID = null;
            this.btnDelete.UseResourceID = true;
            this.btnDelete.UseToolTipID = false;
            this.btnDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDelete_ItemClick);
            // 
            // btnOpen
            // 
            this.btnOpen.Caption = "파일열기";
            this.btnOpen.Glyph = global::AttachFileManager.Resource.document_open_1x;
            this.btnOpen.Id = 11;
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.ResourceID = "1U95KG44";
            this.btnOpen.ToolTipID = null;
            this.btnOpen.UseResourceID = true;
            this.btnOpen.UseToolTipID = false;
            this.btnOpen.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnOpen_ItemClick);
            // 
            // btnRename
            // 
            this.btnRename.Caption = "이름 바꾸기";
            this.btnRename.Glyph = global::AttachFileManager.Resource.font_x_generic_1x;
            this.btnRename.Id = 12;
            this.btnRename.Name = "btnRename";
            this.btnRename.ResourceID = "NMHTUND6";
            this.btnRename.ToolTipID = null;
            this.btnRename.UseResourceID = true;
            this.btnRename.UseToolTipID = false;
            this.btnRename.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnRename_ItemClick);
            // 
            // btnUpload
            // 
            this.btnUpload.Caption = "파일 올리기";
            this.btnUpload.Glyph = global::AttachFileManager.Resource.user_home_1x;
            this.btnUpload.Id = 13;
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.ResourceID = "RK6ANI27";
            this.btnUpload.ToolTipID = null;
            this.btnUpload.UseResourceID = true;
            this.btnUpload.UseToolTipID = false;
            this.btnUpload.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnUpload_ItemClick);
            // 
            // btnCancel
            // 
            this.btnCancel.Caption = "취소";
            this.btnCancel.Glyph = global::AttachFileManager.Resource.cancel_1x;
            this.btnCancel.Id = 15;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.ResourceID = "FRR80RHR";
            this.btnCancel.ToolTipID = null;
            this.btnCancel.UseResourceID = true;
            this.btnCancel.UseToolTipID = false;
            this.btnCancel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCancel_ItemClick);
            // 
            // acBarSubItem1
            // 
            this.acBarSubItem1.Caption = "공개형태";
            this.acBarSubItem1.Glyph = global::AttachFileManager.Resource.user_silhouette_1x;
            this.acBarSubItem1.Id = 21;
            this.acBarSubItem1.Name = "acBarSubItem1";
            this.acBarSubItem1.ResourceID = "0S83T0JI";
            this.acBarSubItem1.ToolTipID = null;
            this.acBarSubItem1.UseResourceID = true;
            this.acBarSubItem1.UseToolTipID = false;
            // 
            // FileGridControl
            // 
            this.FileGridControl.AllowDrop = true;
            this.FileGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FileGridControl.Location = new System.Drawing.Point(0, 0);
            this.FileGridControl.MainView = this.FileGridView;
            this.FileGridControl.Name = "FileGridControl";
            this.FileGridControl.Size = new System.Drawing.Size(674, 251);
            this.FileGridControl.TabIndex = 5;
            this.FileGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.FileGridView});
            // 
            // FileGridView
            // 
            this.FileGridView.ColumnPanelRowHeight = 30;
            this.FileGridView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.FileGridView.GridControl = this.FileGridControl;
            this.FileGridView.Name = "FileGridView";
            this.FileGridView.OptionsBehavior.AutoPopulateColumns = false;
            this.FileGridView.OptionsLayout.Columns.StoreAllOptions = true;
            this.FileGridView.OptionsLayout.StoreAllOptions = true;
            this.FileGridView.OptionsView.ColumnAutoWidth = false;
            this.FileGridView.OptionsView.RowAutoHeight = true;
            this.FileGridView.OptionsView.ShowGroupPanel = false;
            this.FileGridView.OptionsView.ShowIndicator = false;
            this.FileGridView.ParentControl = this;
            this.FileGridView.RowHeight = 30;
            this.FileGridView.SaveFileName = null;
            // 
            // acTabControl1
            // 
            this.acTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.acTabControl1.Location = new System.Drawing.Point(0, 0);
            this.acTabControl1.Name = "acTabControl1";
            this.acTabControl1.SelectedTabPage = this.acTabPage1;
            this.acTabControl1.Size = new System.Drawing.Size(680, 280);
            this.acTabControl1.TabIndex = 6;
            this.acTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.acTabPage1,
            this.acTabPage2,
            this.acTabPage3});
            // 
            // acTabPage1
            // 
            this.acTabPage1.ContainerName = "ATTACH_LIST";
            this.acTabPage1.Controls.Add(this.FileGridControl);
            this.acTabPage1.Name = "acTabPage1";
            this.acTabPage1.ResourceID = "55DEZ9MT";
            this.acTabPage1.Size = new System.Drawing.Size(674, 251);
            this.acTabPage1.Tag = "ATTACH_LIST";
            this.acTabPage1.Text = "첨부파일목록";
            this.acTabPage1.ToolTipID = null;
            this.acTabPage1.UseResourceID = true;
            this.acTabPage1.UseToolTipID = false;
            // 
            // acTabPage2
            // 
            this.acTabPage2.ContainerName = "WAITING_LIST";
            this.acTabPage2.Controls.Add(this.FileTransferGridControl);
            this.acTabPage2.Name = "acTabPage2";
            this.acTabPage2.ResourceID = "CXB57KJL";
            this.acTabPage2.Size = new System.Drawing.Size(674, 251);
            this.acTabPage2.Tag = "WAITING_LIST";
            this.acTabPage2.Text = "전송 대기파일";
            this.acTabPage2.ToolTipID = null;
            this.acTabPage2.UseResourceID = true;
            this.acTabPage2.UseToolTipID = false;
            // 
            // FileTransferGridControl
            // 
            this.FileTransferGridControl.AllowDrop = true;
            this.FileTransferGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FileTransferGridControl.Location = new System.Drawing.Point(0, 0);
            this.FileTransferGridControl.MainView = this.FileTransferGridView;
            this.FileTransferGridControl.Name = "FileTransferGridControl";
            this.FileTransferGridControl.Size = new System.Drawing.Size(674, 251);
            this.FileTransferGridControl.TabIndex = 6;
            this.FileTransferGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.FileTransferGridView});
            // 
            // FileTransferGridView
            // 
            this.FileTransferGridView.ColumnPanelRowHeight = 30;
            this.FileTransferGridView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.FileTransferGridView.GridControl = this.FileTransferGridControl;
            this.FileTransferGridView.Name = "FileTransferGridView";
            this.FileTransferGridView.OptionsBehavior.AutoPopulateColumns = false;
            this.FileTransferGridView.OptionsLayout.Columns.StoreAllOptions = true;
            this.FileTransferGridView.OptionsLayout.StoreAllOptions = true;
            this.FileTransferGridView.OptionsView.ColumnAutoWidth = false;
            this.FileTransferGridView.OptionsView.RowAutoHeight = true;
            this.FileTransferGridView.OptionsView.ShowGroupPanel = false;
            this.FileTransferGridView.OptionsView.ShowIndicator = false;
            this.FileTransferGridView.ParentControl = this;
            this.FileTransferGridView.RowHeight = 30;
            this.FileTransferGridView.SaveFileName = null;
            // 
            // acTabPage3
            // 
            this.acTabPage3.ContainerName = "DELETE_LIST";
            this.acTabPage3.Controls.Add(this.FileDelHistoryGridControl);
            this.acTabPage3.Name = "acTabPage3";
            this.acTabPage3.ResourceID = "75XBJUBS";
            this.acTabPage3.Size = new System.Drawing.Size(674, 251);
            this.acTabPage3.Tag = "DELETE_LIST";
            this.acTabPage3.Text = "삭제이력";
            this.acTabPage3.ToolTipID = null;
            this.acTabPage3.UseResourceID = true;
            this.acTabPage3.UseToolTipID = false;
            // 
            // FileDelHistoryGridControl
            // 
            this.FileDelHistoryGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FileDelHistoryGridControl.Location = new System.Drawing.Point(0, 0);
            this.FileDelHistoryGridControl.MainView = this.FileDelHistoryGridView;
            this.FileDelHistoryGridControl.Name = "FileDelHistoryGridControl";
            this.FileDelHistoryGridControl.Size = new System.Drawing.Size(674, 251);
            this.FileDelHistoryGridControl.TabIndex = 0;
            this.FileDelHistoryGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.FileDelHistoryGridView});
            // 
            // FileDelHistoryGridView
            // 
            this.FileDelHistoryGridView.ColumnPanelRowHeight = 30;
            this.FileDelHistoryGridView.GridControl = this.FileDelHistoryGridControl;
            this.FileDelHistoryGridView.Name = "FileDelHistoryGridView";
            this.FileDelHistoryGridView.OptionsBehavior.AutoPopulateColumns = false;
            this.FileDelHistoryGridView.OptionsLayout.Columns.StoreAllOptions = true;
            this.FileDelHistoryGridView.OptionsLayout.StoreAllOptions = true;
            this.FileDelHistoryGridView.OptionsView.RowAutoHeight = true;
            this.FileDelHistoryGridView.OptionsView.ShowGroupPanel = false;
            this.FileDelHistoryGridView.OptionsView.ShowIndicator = false;
            this.FileDelHistoryGridView.ParentControl = this;
            this.FileDelHistoryGridView.RowHeight = 30;
            this.FileDelHistoryGridView.SaveFileName = null;
            // 
            // popupMenu1
            // 
            this.popupMenu1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnUpload),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnOpen, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnDownload),
            new DevExpress.XtraBars.LinkPersistInfo(this.acBarSubItem1, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnRename),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnDelete)});
            this.popupMenu1.Manager = this.acBarManager1;
            this.popupMenu1.Name = "popupMenu1";
            // 
            // popupMenu2
            // 
            this.popupMenu2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnCancel)});
            this.popupMenu2.Manager = this.acBarManager1;
            this.popupMenu2.Name = "popupMenu2";
            // 
            // acAttachFileControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.acTabControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "acAttachFileControl";
            this.Size = new System.Drawing.Size(680, 280);
            ((System.ComponentModel.ISupportInitialize)(this.acBarManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FileGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FileGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acTabControl1)).EndInit();
            this.acTabControl1.ResumeLayout(false);
            this.acTabPage1.ResumeLayout(false);
            this.acTabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.FileTransferGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FileTransferGridView)).EndInit();
            this.acTabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.FileDelHistoryGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FileDelHistoryGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ControlManager.acBarManager acBarManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private ControlManager.acGridControl FileGridControl;
        private ControlManager.acGridView FileGridView;
        private ControlManager.acTabPage acTabPage1;
        private ControlManager.acTabPage acTabPage2;
        private ControlManager.acGridControl FileTransferGridControl;
        private ControlManager.acGridView FileTransferGridView;
        private ControlManager.acBarButtonItem btnDownload;
        private ControlManager.acBarButtonItem btnDelete;
        private DevExpress.XtraBars.PopupMenu popupMenu1;
        private ControlManager.acBarButtonItem btnOpen;
        private ControlManager.acBarButtonItem btnRename;
        private DevExpress.XtraBars.PopupMenu popupMenu2;
        private ControlManager.acBarButtonItem btnUpload;
        private ControlManager.acBarButtonItem btnCancel;
        private ControlManager.acTabPage acTabPage3;
        private ControlManager.acGridControl FileDelHistoryGridControl;
        private ControlManager.acGridView FileDelHistoryGridView;
        private ControlManager.acBarSubItem acBarSubItem1;
        public ControlManager.acTabControl acTabControl1;


    }
}
