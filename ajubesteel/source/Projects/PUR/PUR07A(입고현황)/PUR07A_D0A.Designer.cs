namespace PUR
{
    partial class PUR07A_D0A
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
            this.components = new System.ComponentModel.Container();
            this.acLayoutControl1 = new ControlManager.acLayoutControl();
            this.txtSComment = new ControlManager.acMemoEdit();
            this.dtDue = new ControlManager.acDateEdit();
            this.dtReq = new ControlManager.acDateEdit();
            this.layoutControlGroup1 = new ControlManager.acLayoutControlGroup();
            this.layoutControlItem4 = new ControlManager.acLayoutControlItem();
            this.layoutControlItem5 = new ControlManager.acLayoutControlItem();
            this.layoutControlItem6 = new ControlManager.acLayoutControlItem();
            this.acBarManager1 = new ControlManager.acBarManager(this.components);
            this.bar2 = new ControlManager.acBar();
            this.acBarButtonItem1 = new ControlManager.acBarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControl1)).BeginInit();
            this.acLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSComment.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDue.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDue.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtReq.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtReq.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acBarManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // acLayoutControl1
            // 
            this.acLayoutControl1.AllowCustomizationMenu = false;
            this.acLayoutControl1.AutoScroll = false;
            this.acLayoutControl1.ContainerName = null;
            this.acLayoutControl1.Controls.Add(this.txtSComment);
            this.acLayoutControl1.Controls.Add(this.dtDue);
            this.acLayoutControl1.Controls.Add(this.dtReq);
            this.acLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.acLayoutControl1.LayoutType = ControlManager.acLayoutControl.emLayoutType.NONE;
            this.acLayoutControl1.Location = new System.Drawing.Point(0, 32);
            this.acLayoutControl1.Name = "acLayoutControl1";
            this.acLayoutControl1.ParentControl = null;
            this.acLayoutControl1.Root = this.layoutControlGroup1;
            this.acLayoutControl1.Size = new System.Drawing.Size(445, 205);
            this.acLayoutControl1.TabIndex = 1;
            this.acLayoutControl1.Text = "layoutControl1";
            // 
            // txtSComment
            // 
            this.txtSComment.ColumnName = "SCOMMENT";
            this.txtSComment.isReadyOnly = false;
            this.txtSComment.isRequired = false;
            this.txtSComment.Location = new System.Drawing.Point(84, 71);
            this.txtSComment.Name = "txtSComment";
            this.txtSComment.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtSComment.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.txtSComment.Properties.Appearance.Options.UseBackColor = true;
            this.txtSComment.Properties.Appearance.Options.UseForeColor = true;
            this.txtSComment.Size = new System.Drawing.Size(355, 128);
            this.txtSComment.StyleController = this.acLayoutControl1;
            this.txtSComment.TabIndex = 10;
            this.txtSComment.ToolTipID = null;
            this.txtSComment.UseToolTipID = false;
            this.txtSComment.Value = null;
            // 
            // dtDue
            // 
            this.dtDue.ColumnName = "DUE_DATE";
            this.dtDue.CreateParameterFormat = "yyyyMMdd";
            this.dtDue.EditValue = null;
            this.dtDue.isReadyOnly = false;
            this.dtDue.isRequired = true;
            this.dtDue.Location = new System.Drawing.Point(84, 39);
            this.dtDue.Name = "dtDue";
            this.dtDue.Properties.Appearance.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.dtDue.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.dtDue.Properties.Appearance.Options.UseBackColor = true;
            this.dtDue.Properties.Appearance.Options.UseForeColor = true;
            this.dtDue.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtDue.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtDue.Size = new System.Drawing.Size(355, 21);
            this.dtDue.StyleController = this.acLayoutControl1;
            this.dtDue.TabIndex = 9;
            this.dtDue.Tag = "";
            this.dtDue.TimeOfDayType = ControlManager.acDateEdit.emTimeOfDayType.START;
            this.dtDue.ToolTipID = null;
            this.dtDue.UseToolTipID = false;
            // 
            // dtReq
            // 
            this.dtReq.ColumnName = "REQ_DATE";
            this.dtReq.CreateParameterFormat = "yyyyMMdd";
            this.dtReq.EditValue = null;
            this.dtReq.isReadyOnly = true;
            this.dtReq.isRequired = true;
            this.dtReq.Location = new System.Drawing.Point(84, 7);
            this.dtReq.Name = "dtReq";
            this.dtReq.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.dtReq.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.dtReq.Properties.Appearance.Options.UseBackColor = true;
            this.dtReq.Properties.Appearance.Options.UseForeColor = true;
            this.dtReq.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dtReq.Properties.AppearanceReadOnly.ForeColor = System.Drawing.Color.Black;
            this.dtReq.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.dtReq.Properties.AppearanceReadOnly.Options.UseForeColor = true;
            this.dtReq.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtReq.Properties.ReadOnly = true;
            this.dtReq.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtReq.Size = new System.Drawing.Size(355, 21);
            this.dtReq.StyleController = this.acLayoutControl1;
            this.dtReq.TabIndex = 8;
            this.dtReq.Tag = "";
            this.dtReq.TimeOfDayType = ControlManager.acDateEdit.emTimeOfDayType.START;
            this.dtReq.ToolTipID = null;
            this.dtReq.UseToolTipID = false;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.layoutControlItem6});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.ResourceID = null;
            this.layoutControlGroup1.Size = new System.Drawing.Size(445, 205);
            this.layoutControlGroup1.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            this.layoutControlGroup1.ToolTipID = null;
            this.layoutControlGroup1.UseResourceID = false;
            this.layoutControlGroup1.UseToolTipID = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.AllowHotTrack = false;
            this.layoutControlItem4.Control = this.dtReq;
            this.layoutControlItem4.CustomizationFormText = "신청일";
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.ResourceID = "42322";
            this.layoutControlItem4.Size = new System.Drawing.Size(443, 32);
            this.layoutControlItem4.Tag = "";
            this.layoutControlItem4.Text = "신청일";
            this.layoutControlItem4.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItem4.TextSize = new System.Drawing.Size(72, 0);
            this.layoutControlItem4.ToolTipID = null;
            this.layoutControlItem4.UseResourceID = true;
            this.layoutControlItem4.UseToolTipID = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.AllowHotTrack = false;
            this.layoutControlItem5.Control = this.dtDue;
            this.layoutControlItem5.CustomizationFormText = "신청자요구일";
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 32);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.ResourceID = "0TZNF5Y7";
            this.layoutControlItem5.Size = new System.Drawing.Size(443, 32);
            this.layoutControlItem5.Tag = "";
            this.layoutControlItem5.Text = "신청자요구일";
            this.layoutControlItem5.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItem5.TextSize = new System.Drawing.Size(72, 0);
            this.layoutControlItem5.ToolTipID = null;
            this.layoutControlItem5.UseResourceID = true;
            this.layoutControlItem5.UseToolTipID = false;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.AllowHotTrack = false;
            this.layoutControlItem6.Control = this.txtSComment;
            this.layoutControlItem6.CustomizationFormText = "비고";
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 64);
            this.layoutControlItem6.MinSize = new System.Drawing.Size(21, 64);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.ResourceID = "ARYZ726K";
            this.layoutControlItem6.Size = new System.Drawing.Size(443, 139);
            this.layoutControlItem6.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem6.Tag = "";
            this.layoutControlItem6.Text = "비고";
            this.layoutControlItem6.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItem6.TextSize = new System.Drawing.Size(72, 0);
            this.layoutControlItem6.ToolTipID = null;
            this.layoutControlItem6.UseResourceID = true;
            this.layoutControlItem6.UseToolTipID = false;
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
            this.acBarButtonItem1.ButtonShortCutType = ControlManager.acBarManager.emBarShortCutType.SAVE;
            this.acBarButtonItem1.Caption = "acBarButtonItem1";
            this.acBarButtonItem1.Glyph = global::PUR.Resource.document_save_close_2x;
            this.acBarButtonItem1.Id = 0;
            this.acBarButtonItem1.Name = "acBarButtonItem1";
            this.acBarButtonItem1.ResourceID = null;
            this.acBarButtonItem1.ToolTipID = "4UY7EZBZ";
            this.acBarButtonItem1.UseResourceID = false;
            this.acBarButtonItem1.UseToolTipID = true;
            this.acBarButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.acBarButtonItem1_ItemClick);
            // 
            // PUR07A_D0A
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(445, 237);
            this.Controls.Add(this.acLayoutControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "PUR07A_D0A";
            this.ResourceID = "";
            this.Tag = "";
            this.Text = "";
            this.ToolTipID = "";
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControl1)).EndInit();
            this.acLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtSComment.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDue.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDue.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtReq.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtReq.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acBarManager1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ControlManager.acLayoutControl acLayoutControl1;
        private ControlManager.acMemoEdit txtSComment;
        private ControlManager.acDateEdit dtDue;
        private ControlManager.acDateEdit dtReq;
        private ControlManager.acLayoutControlGroup layoutControlGroup1;

        
        private ControlManager.acLayoutControlItem layoutControlItem4;
        private ControlManager.acLayoutControlItem layoutControlItem5;
        private ControlManager.acLayoutControlItem layoutControlItem6;
        private ControlManager.acBarManager acBarManager1;
        private ControlManager.acBar bar2;
        private ControlManager.acBarButtonItem acBarButtonItem1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;

    }
}
