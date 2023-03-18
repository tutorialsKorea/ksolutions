namespace ORD
{
    partial class frmPictureEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPictureEdit));
            this.acPictureEdit1 = new ControlManager.acPictureEdit();
            this.acBarManager1 = new ControlManager.acBarManager(this.components);
            this.bar2 = new ControlManager.acBar();
            this.acBarButtonItem2 = new ControlManager.acBarButtonItem();
            this.acBarButtonItem1 = new ControlManager.acBarButtonItem();
            this.btnBarZoomIn = new ControlManager.acBarButtonItem();
            this.btnBarZoomOut = new ControlManager.acBarButtonItem();
            this.barItemFixedWindow = new ControlManager.acBarCheckItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.xtraScrollableControl1 = new DevExpress.XtraEditors.XtraScrollableControl();
            ((System.ComponentModel.ISupportInitialize)(this.acPictureEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acBarManager1)).BeginInit();
            this.xtraScrollableControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // acPictureEdit1
            // 
            this.acPictureEdit1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.acPictureEdit1.ColumnName = null;
            this.acPictureEdit1.EditValue = ((object)(resources.GetObject("acPictureEdit1.EditValue")));
            this.acPictureEdit1.isReadyOnly = false;
            this.acPictureEdit1.isRequired = false;
            this.acPictureEdit1.Location = new System.Drawing.Point(0, 0);
            this.acPictureEdit1.MenuManager = this.acBarManager1;
            this.acPictureEdit1.Name = "acPictureEdit1";
            this.acPictureEdit1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.acPictureEdit1.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.acPictureEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.acPictureEdit1.Properties.Appearance.Options.UseForeColor = true;
            this.acPictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.acPictureEdit1.Size = new System.Drawing.Size(504, 397);
            this.acPictureEdit1.TabIndex = 4;
            this.acPictureEdit1.ToolTipID = null;
            this.acPictureEdit1.UseToolTipID = false;
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
            this.barItemFixedWindow,
            this.acBarButtonItem1,
            this.acBarButtonItem2,
            this.btnBarZoomIn,
            this.btnBarZoomOut});
            this.acBarManager1.MainMenu = this.bar2;
            this.acBarManager1.MaxItemId = 12;
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
            new DevExpress.XtraBars.LinkPersistInfo(this.acBarButtonItem2),
            new DevExpress.XtraBars.LinkPersistInfo(this.acBarButtonItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnBarZoomIn),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnBarZoomOut),
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
            // acBarButtonItem2
            // 
            this.acBarButtonItem2.Caption = "지우기";
            this.acBarButtonItem2.Id = 9;
            this.acBarButtonItem2.ImageOptions.Image = global::ORD.Resource.edit_clear_2x;
            this.acBarButtonItem2.Name = "acBarButtonItem2";
            this.acBarButtonItem2.ResourceID = null;
            this.acBarButtonItem2.ToolTipID = null;
            this.acBarButtonItem2.UseResourceID = false;
            this.acBarButtonItem2.UseToolTipID = false;
            this.acBarButtonItem2.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.acBarButtonItem2_ItemClick);
            // 
            // acBarButtonItem1
            // 
            this.acBarButtonItem1.Caption = "선택";
            this.acBarButtonItem1.Id = 8;
            this.acBarButtonItem1.ImageOptions.Image = global::ORD.Resource.dialog_apply_2x;
            this.acBarButtonItem1.Name = "acBarButtonItem1";
            this.acBarButtonItem1.ResourceID = null;
            this.acBarButtonItem1.ToolTipID = null;
            this.acBarButtonItem1.UseResourceID = false;
            this.acBarButtonItem1.UseToolTipID = false;
            this.acBarButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.acBarButtonItem1_ItemClick);
            // 
            // btnBarZoomIn
            // 
            this.btnBarZoomIn.Caption = "확대";
            this.btnBarZoomIn.Id = 10;
            this.btnBarZoomIn.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnBarZoomIn.ImageOptions.SvgImage")));
            this.btnBarZoomIn.Name = "btnBarZoomIn";
            this.btnBarZoomIn.ResourceID = null;
            this.btnBarZoomIn.ToolTipID = null;
            this.btnBarZoomIn.UseResourceID = false;
            this.btnBarZoomIn.UseToolTipID = false;
            this.btnBarZoomIn.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnBarZoomIn.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnBarZoomIn_ItemClick);
            // 
            // btnBarZoomOut
            // 
            this.btnBarZoomOut.Caption = "축소";
            this.btnBarZoomOut.Id = 11;
            this.btnBarZoomOut.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnBarZoomOut.ImageOptions.SvgImage")));
            this.btnBarZoomOut.Name = "btnBarZoomOut";
            this.btnBarZoomOut.ResourceID = null;
            this.btnBarZoomOut.ToolTipID = null;
            this.btnBarZoomOut.UseResourceID = false;
            this.btnBarZoomOut.UseToolTipID = false;
            this.btnBarZoomOut.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnBarZoomOut.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnBarZoomOut_ItemClick);
            // 
            // barItemFixedWindow
            // 
            this.barItemFixedWindow.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.barItemFixedWindow.ButtonShortCutType = ControlManager.acBarManager.emBarShortCutType.WIN_LOCK;
            this.barItemFixedWindow.Caption = "고정";
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
            this.barDockControlTop.Size = new System.Drawing.Size(504, 34);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 431);
            this.barDockControlBottom.Manager = this.acBarManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(504, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 34);
            this.barDockControlLeft.Manager = this.acBarManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 397);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(504, 34);
            this.barDockControlRight.Manager = this.acBarManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 397);
            // 
            // xtraScrollableControl1
            // 
            this.xtraScrollableControl1.Controls.Add(this.acPictureEdit1);
            this.xtraScrollableControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraScrollableControl1.Location = new System.Drawing.Point(0, 34);
            this.xtraScrollableControl1.Name = "xtraScrollableControl1";
            this.xtraScrollableControl1.Size = new System.Drawing.Size(504, 397);
            this.xtraScrollableControl1.TabIndex = 10;
            // 
            // frmPictureEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 431);
            this.Controls.Add(this.xtraScrollableControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.IconOptions.ShowIcon = false;
            this.Name = "frmPictureEdit";
            this.ResourceID = "ZU0I0ZJW";
            this.Text = "이미지편집";
            ((System.ComponentModel.ISupportInitialize)(this.acPictureEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acBarManager1)).EndInit();
            this.xtraScrollableControl1.ResumeLayout(false);
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
        private ControlManager.acBarCheckItem barItemFixedWindow;
        private ControlManager.acBarButtonItem acBarButtonItem1;
        private ControlManager.acPictureEdit acPictureEdit1;
        private ControlManager.acBarButtonItem acBarButtonItem2;
        private DevExpress.XtraEditors.XtraScrollableControl xtraScrollableControl1;
        private ControlManager.acBarButtonItem btnBarZoomIn;
        private ControlManager.acBarButtonItem btnBarZoomOut;
    }
}