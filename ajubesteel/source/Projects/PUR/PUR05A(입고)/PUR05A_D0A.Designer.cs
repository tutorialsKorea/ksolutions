namespace PUR
{
    partial class PUR05A_D0A
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
            this.dtYpgo = new ControlManager.acDateEdit();
            this.layoutControlGroup1 = new ControlManager.acLayoutControlGroup();
            this.layoutControlItem4 = new ControlManager.acLayoutControlItem();
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
            ((System.ComponentModel.ISupportInitialize)(this.dtYpgo.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtYpgo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acBarManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // acLayoutControl1
            // 
            this.acLayoutControl1.AllowCustomization = false;
            this.acLayoutControl1.AutoScroll = false;
            this.acLayoutControl1.ContainerName = null;
            this.acLayoutControl1.Controls.Add(this.txtSComment);
            this.acLayoutControl1.Controls.Add(this.dtYpgo);
            this.acLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.acLayoutControl1.LayoutType = ControlManager.acLayoutControl.emLayoutType.NONE;
            this.acLayoutControl1.Location = new System.Drawing.Point(0, 36);
            this.acLayoutControl1.Name = "acLayoutControl1";
            this.acLayoutControl1.ParentControl = null;
            this.acLayoutControl1.Root = this.layoutControlGroup1;
            this.acLayoutControl1.Size = new System.Drawing.Size(445, 129);
            this.acLayoutControl1.TabIndex = 1;
            this.acLayoutControl1.Text = "layoutControl1";
            // 
            // txtSComment
            // 
            this.txtSComment.ColumnName = "SCOMMENT";
            this.txtSComment.isReadyOnly = false;
            this.txtSComment.isRequired = false;
            this.txtSComment.Location = new System.Drawing.Point(57, 45);
            this.txtSComment.MaskType = ControlManager.acMemoEdit.emMaskType.NONE;
            this.txtSComment.Name = "txtSComment";
            this.txtSComment.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtSComment.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.txtSComment.Properties.Appearance.Options.UseBackColor = true;
            this.txtSComment.Properties.Appearance.Options.UseFont = true;
            this.txtSComment.Properties.Appearance.Options.UseForeColor = true;
            this.txtSComment.Properties.AppearanceDisabled.Options.UseFont = true;
            this.txtSComment.Properties.AppearanceFocused.Options.UseFont = true;
            this.txtSComment.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.txtSComment.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txtSComment.Size = new System.Drawing.Size(373, 69);
            this.txtSComment.StyleController = this.acLayoutControl1;
            this.txtSComment.TabIndex = 10;
            this.txtSComment.ToolTipID = null;
            this.txtSComment.UseToolTipID = false;
            // 
            // dtYpgo
            // 
            this.dtYpgo.ColumnName = "YPGO_DATE";
            this.dtYpgo.CreateParameterFormat = "yyyyMMdd";
            this.dtYpgo.EditValue = null;
            this.dtYpgo.isReadyOnly = true;
            this.dtYpgo.isRequired = true;
            this.dtYpgo.Location = new System.Drawing.Point(57, 15);
            this.dtYpgo.Name = "dtYpgo";
            this.dtYpgo.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.dtYpgo.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.dtYpgo.Properties.Appearance.Options.UseBackColor = true;
            this.dtYpgo.Properties.Appearance.Options.UseForeColor = true;
            this.dtYpgo.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dtYpgo.Properties.AppearanceReadOnly.ForeColor = System.Drawing.Color.Black;
            this.dtYpgo.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.dtYpgo.Properties.AppearanceReadOnly.Options.UseForeColor = true;
            this.dtYpgo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtYpgo.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtYpgo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.dtYpgo.Properties.ReadOnly = true;
            this.dtYpgo.Size = new System.Drawing.Size(373, 20);
            this.dtYpgo.StyleController = this.acLayoutControl1;
            this.dtYpgo.TabIndex = 8;
            this.dtYpgo.Tag = "";
            this.dtYpgo.TimeOfDayType = ControlManager.acDateEdit.emTimeOfDayType.START;
            this.dtYpgo.ToolTipID = null;
            this.dtYpgo.UseToolTipID = false;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.IsHeader = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem4,
            this.layoutControlItem6});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.ResourceID = null;
            this.layoutControlGroup1.Size = new System.Drawing.Size(445, 129);
            this.layoutControlGroup1.TextVisible = false;
            this.layoutControlGroup1.ToolTipID = null;
            this.layoutControlGroup1.UseResourceID = false;
            this.layoutControlGroup1.UseToolTipID = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.AllowHotTrack = false;
            this.layoutControlItem4.Control = this.dtYpgo;
            this.layoutControlItem4.CustomizationFormText = "입고일";
            this.layoutControlItem4.IsHeader = false;
            this.layoutControlItem4.IsTitle = false;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlItem4.ResourceID = "40515";
            this.layoutControlItem4.Size = new System.Drawing.Size(425, 30);
            this.layoutControlItem4.Tag = "";
            this.layoutControlItem4.Text = "입고일";
            this.layoutControlItem4.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItem4.TextSize = new System.Drawing.Size(30, 14);
            this.layoutControlItem4.ToolTipID = null;
            this.layoutControlItem4.ToolTipStdCode = null;
            this.layoutControlItem4.UseResourceID = true;
            this.layoutControlItem4.UseToolTipID = false;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.AllowHotTrack = false;
            this.layoutControlItem6.Control = this.txtSComment;
            this.layoutControlItem6.CustomizationFormText = "비고";
            this.layoutControlItem6.IsHeader = false;
            this.layoutControlItem6.IsTitle = false;
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 30);
            this.layoutControlItem6.MinSize = new System.Drawing.Size(21, 64);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlItem6.ResourceID = "ARYZ726K";
            this.layoutControlItem6.Size = new System.Drawing.Size(425, 79);
            this.layoutControlItem6.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem6.Tag = "";
            this.layoutControlItem6.Text = "비고";
            this.layoutControlItem6.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItem6.TextSize = new System.Drawing.Size(30, 14);
            this.layoutControlItem6.ToolTipID = null;
            this.layoutControlItem6.ToolTipStdCode = null;
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
            this.bar2.BarItemHorzIndent = 10;
            this.bar2.BarItemVertIndent = 5;
            this.bar2.BarName = "도구상자";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.acBarButtonItem1, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
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
            this.acBarButtonItem1.Caption = "저장 후 닫기";
            this.acBarButtonItem1.Id = 0;
            this.acBarButtonItem1.ImageOptions.Image = global::PUR.Resource.document_save_close_2x;
            this.acBarButtonItem1.Name = "acBarButtonItem1";
            this.acBarButtonItem1.ResourceID = null;
            this.acBarButtonItem1.ToolTipID = "4UY7EZBZ";
            this.acBarButtonItem1.UseResourceID = false;
            this.acBarButtonItem1.UseToolTipID = true;
            this.acBarButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.acBarButtonItem1_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.acBarManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(445, 36);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 165);
            this.barDockControlBottom.Manager = this.acBarManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(445, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 36);
            this.barDockControlLeft.Manager = this.acBarManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 129);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(445, 36);
            this.barDockControlRight.Manager = this.acBarManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 129);
            // 
            // PUR05A_D0A
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(445, 165);
            this.Controls.Add(this.acLayoutControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.IconOptions.ShowIcon = false;
            this.Name = "PUR05A_D0A";
            this.ResourceID = "";
            this.Tag = "";
            this.Text = "";
            this.ToolTipID = "";
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControl1)).EndInit();
            this.acLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtSComment.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtYpgo.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtYpgo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acBarManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ControlManager.acLayoutControl acLayoutControl1;
        private ControlManager.acMemoEdit txtSComment;
        private ControlManager.acDateEdit dtYpgo;
        private ControlManager.acLayoutControlGroup layoutControlGroup1;


        private ControlManager.acLayoutControlItem layoutControlItem4;
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
