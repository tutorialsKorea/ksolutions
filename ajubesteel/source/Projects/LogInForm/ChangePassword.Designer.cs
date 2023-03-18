namespace LogInForm
{
    partial class ChangePassword
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangePassword));
            this.acBarManager1 = new ControlManager.acBarManager();
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.btnItemSaveClose = new ControlManager.acBarButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.statusBarLog = new ControlManager.acBarStaticItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.acLayoutControl1 = new ControlManager.acLayoutControl();
            this.acLayoutControlGroup1 = new ControlManager.acLayoutControlGroup();
            this.txtOld = new ControlManager.acTextEdit();
            this.acLayoutControlItem2 = new ControlManager.acLayoutControlItem();
            this.txtNew = new ControlManager.acTextEdit();
            this.acLayoutControlItem3 = new ControlManager.acLayoutControlItem();
            this.txtConfirm = new ControlManager.acTextEdit();
            this.acLayoutControlItem1 = new ControlManager.acLayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.acBarManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControl1)).BeginInit();
            this.acLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOld.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNew.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtConfirm.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem1)).BeginInit();
            this.SuspendLayout();
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
            this.btnItemSaveClose,
            this.statusBarLog});
            this.acBarManager1.MainMenu = this.bar2;
            this.acBarManager1.MaxItemId = 3;
            this.acBarManager1.StatusBar = this.bar3;
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnItemSaveClose)});
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // btnItemSaveClose
            // 
            this.btnItemSaveClose.Caption = "btnSave";
            this.btnItemSaveClose.Glyph = global::LogInForm.Properties.Resources.document_save_close_2x;
            this.btnItemSaveClose.Id = 1;
            this.btnItemSaveClose.Name = "btnItemSaveClose";
            this.btnItemSaveClose.ResourceID = null;
            this.btnItemSaveClose.ToolTipID = null;
            this.btnItemSaveClose.UseResourceID = false;
            this.btnItemSaveClose.UseToolTipID = false;
            this.btnItemSaveClose.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barItemSave_ItemClick);
            // 
            // bar3
            // 
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
            this.bar3.Text = "Status bar";
            // 
            // statusBarLog
            // 
            this.statusBarLog.Border = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.statusBarLog.Glyph = ((System.Drawing.Image)(resources.GetObject("statusBarLog.Glyph")));
            this.statusBarLog.Id = 2;
            this.statusBarLog.Name = "statusBarLog";
            this.statusBarLog.ResourceID = null;
            this.statusBarLog.TextAlignment = System.Drawing.StringAlignment.Near;
            this.statusBarLog.ToolTipID = null;
            this.statusBarLog.UseResourceID = false;
            this.statusBarLog.UseToolTipID = false;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(300, 30);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 143);
            this.barDockControlBottom.Size = new System.Drawing.Size(300, 27);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 30);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 113);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(300, 30);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 113);
            // 
            // acLayoutControl1
            // 
            this.acLayoutControl1.AllowCustomizationMenu = false;
            this.acLayoutControl1.ContainerName = null;
            this.acLayoutControl1.Controls.Add(this.txtConfirm);
            this.acLayoutControl1.Controls.Add(this.txtNew);
            this.acLayoutControl1.Controls.Add(this.txtOld);
            this.acLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.acLayoutControl1.LayoutType = ControlManager.acLayoutControl.emLayoutType.NONE;
            this.acLayoutControl1.Location = new System.Drawing.Point(0, 30);
            this.acLayoutControl1.Name = "acLayoutControl1";
            this.acLayoutControl1.ParentControl = null;
            this.acLayoutControl1.Root = this.acLayoutControlGroup1;
            this.acLayoutControl1.Size = new System.Drawing.Size(300, 113);
            this.acLayoutControl1.TabIndex = 4;
            this.acLayoutControl1.Text = "acLayoutControl1";
            // 
            // acLayoutControlGroup1
            // 
            this.acLayoutControlGroup1.CustomizationFormText = "acLayoutControlGroup1";
            this.acLayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.acLayoutControlGroup1.GroupBordersVisible = false;
            this.acLayoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.acLayoutControlItem2,
            this.acLayoutControlItem3,
            this.acLayoutControlItem1});
            this.acLayoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.acLayoutControlGroup1.Name = "acLayoutControlGroup1";
            this.acLayoutControlGroup1.ResourceID = null;
            this.acLayoutControlGroup1.Size = new System.Drawing.Size(300, 113);
            this.acLayoutControlGroup1.Text = "acLayoutControlGroup1";
            this.acLayoutControlGroup1.TextVisible = false;
            this.acLayoutControlGroup1.ToolTipID = null;
            this.acLayoutControlGroup1.UseResourceID = false;
            this.acLayoutControlGroup1.UseToolTipID = false;
            // 
            // txtOld
            // 
            this.txtOld.ColumnName = "OLD_PASSWORD";
            this.txtOld.isRequired = true;
            this.txtOld.Location = new System.Drawing.Point(110, 15);
            this.txtOld.MaskType = ControlManager.acTextEdit.emMaskType.NONE;
            this.txtOld.MenuManager = this.acBarManager1;
            this.txtOld.Name = "txtOld";
            this.txtOld.Properties.Appearance.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.txtOld.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.txtOld.Properties.Appearance.Options.UseBackColor = true;
            this.txtOld.Properties.Appearance.Options.UseForeColor = true;
            this.txtOld.Size = new System.Drawing.Size(175, 20);
            this.txtOld.StyleController = this.acLayoutControl1;
            this.txtOld.TabIndex = 5;
            // 
            // acLayoutControlItem2
            // 
            this.acLayoutControlItem2.Control = this.txtOld;
            this.acLayoutControlItem2.CustomizationFormText = "기존 비밀번호";
            this.acLayoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.acLayoutControlItem2.Name = "acLayoutControlItem2";
            this.acLayoutControlItem2.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.acLayoutControlItem2.ResourceID = "0N4KAQIZ";
            this.acLayoutControlItem2.Size = new System.Drawing.Size(280, 30);
            this.acLayoutControlItem2.Text = "기존 비밀번호";
            this.acLayoutControlItem2.TextSize = new System.Drawing.Size(92, 14);
            this.acLayoutControlItem2.ToolTipID = null;
            this.acLayoutControlItem2.UseResourceID = false;
            this.acLayoutControlItem2.UseToolTipID = false;
            // 
            // txtNew
            // 
            this.txtNew.ColumnName = "NEW_PASSWORD";
            this.txtNew.isRequired = true;
            this.txtNew.Location = new System.Drawing.Point(110, 45);
            this.txtNew.MaskType = ControlManager.acTextEdit.emMaskType.NONE;
            this.txtNew.MenuManager = this.acBarManager1;
            this.txtNew.Name = "txtNew";
            this.txtNew.Properties.Appearance.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.txtNew.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.txtNew.Properties.Appearance.Options.UseBackColor = true;
            this.txtNew.Properties.Appearance.Options.UseForeColor = true;
            this.txtNew.Size = new System.Drawing.Size(175, 20);
            this.txtNew.StyleController = this.acLayoutControl1;
            this.txtNew.TabIndex = 6;
            // 
            // acLayoutControlItem3
            // 
            this.acLayoutControlItem3.Control = this.txtNew;
            this.acLayoutControlItem3.CustomizationFormText = "새 비밀번호";
            this.acLayoutControlItem3.Location = new System.Drawing.Point(0, 30);
            this.acLayoutControlItem3.Name = "acLayoutControlItem3";
            this.acLayoutControlItem3.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.acLayoutControlItem3.ResourceID = "58F41B56";
            this.acLayoutControlItem3.Size = new System.Drawing.Size(280, 30);
            this.acLayoutControlItem3.Text = "새 비밀번호";
            this.acLayoutControlItem3.TextSize = new System.Drawing.Size(92, 14);
            this.acLayoutControlItem3.ToolTipID = null;
            this.acLayoutControlItem3.UseResourceID = false;
            this.acLayoutControlItem3.UseToolTipID = false;
            // 
            // txtConfirm
            // 
            this.txtConfirm.ColumnName = "NEW_PASSWORD_CFM";
            this.txtConfirm.isRequired = true;
            this.txtConfirm.Location = new System.Drawing.Point(110, 75);
            this.txtConfirm.MaskType = ControlManager.acTextEdit.emMaskType.NONE;
            this.txtConfirm.MenuManager = this.acBarManager1;
            this.txtConfirm.Name = "txtConfirm";
            this.txtConfirm.Properties.Appearance.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.txtConfirm.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.txtConfirm.Properties.Appearance.Options.UseBackColor = true;
            this.txtConfirm.Properties.Appearance.Options.UseForeColor = true;
            this.txtConfirm.Size = new System.Drawing.Size(175, 20);
            this.txtConfirm.StyleController = this.acLayoutControl1;
            this.txtConfirm.TabIndex = 7;
            // 
            // acLayoutControlItem1
            // 
            this.acLayoutControlItem1.Control = this.txtConfirm;
            this.acLayoutControlItem1.CustomizationFormText = "새 비밀번호 확인";
            this.acLayoutControlItem1.Location = new System.Drawing.Point(0, 60);
            this.acLayoutControlItem1.Name = "acLayoutControlItem1";
            this.acLayoutControlItem1.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.acLayoutControlItem1.ResourceID = "4I3DR3L2";
            this.acLayoutControlItem1.Size = new System.Drawing.Size(280, 33);
            this.acLayoutControlItem1.Text = "새 비밀번호 확인";
            this.acLayoutControlItem1.TextSize = new System.Drawing.Size(92, 14);
            this.acLayoutControlItem1.ToolTipID = null;
            this.acLayoutControlItem1.UseResourceID = false;
            this.acLayoutControlItem1.UseToolTipID = false;
            // 
            // ChangePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(300, 170);
            this.Controls.Add(this.acLayoutControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "ChangePassword";
            this.Text = "비밀번호 변경";
            ((System.ComponentModel.ISupportInitialize)(this.acBarManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControl1)).EndInit();
            this.acLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOld.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNew.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtConfirm.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ControlManager.acBarManager acBarManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private ControlManager.acBarButtonItem btnItemSaveClose;
        private ControlManager.acBarStaticItem statusBarLog;
        private ControlManager.acLayoutControl acLayoutControl1;
        private ControlManager.acLayoutControlGroup acLayoutControlGroup1;
        private ControlManager.acTextEdit txtConfirm;
        private ControlManager.acTextEdit txtNew;
        private ControlManager.acTextEdit txtOld;
        private ControlManager.acLayoutControlItem acLayoutControlItem2;
        private ControlManager.acLayoutControlItem acLayoutControlItem3;
        private ControlManager.acLayoutControlItem acLayoutControlItem1;
    }
}
