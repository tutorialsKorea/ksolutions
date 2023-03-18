namespace PUR
{
    partial class PUR04A_D1A
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
            this.acTextEdit1 = new ControlManager.acTextEdit();
            this.acBarManager1 = new ControlManager.acBarManager(this.components);
            this.bar2 = new ControlManager.acBar();
            this.acBarButtonItem1 = new ControlManager.acBarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.acDateEdit3 = new ControlManager.acDateEdit();
            this.acDateEdit2 = new ControlManager.acDateEdit();
            this.acDateEdit1 = new ControlManager.acDateEdit();
            this.layoutControlGroup1 = new ControlManager.acLayoutControlGroup();
            this.acLayoutControlItem1 = new ControlManager.acLayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.acLayoutControlItem2 = new ControlManager.acLayoutControlItem();
            this.acLayoutControlItem3 = new ControlManager.acLayoutControlItem();
            this.acLayoutControlItem4 = new ControlManager.acLayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControl1)).BeginInit();
            this.acLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.acTextEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acBarManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acDateEdit3.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acDateEdit3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acDateEdit2.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acDateEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acDateEdit1.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acDateEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem4)).BeginInit();
            this.SuspendLayout();
            // 
            // acLayoutControl1
            // 
            this.acLayoutControl1.AllowCustomization = false;
            this.acLayoutControl1.AutoScroll = false;
            this.acLayoutControl1.ContainerName = null;
            this.acLayoutControl1.Controls.Add(this.acTextEdit1);
            this.acLayoutControl1.Controls.Add(this.acDateEdit3);
            this.acLayoutControl1.Controls.Add(this.acDateEdit2);
            this.acLayoutControl1.Controls.Add(this.acDateEdit1);
            this.acLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.acLayoutControl1.EnterMoveNextControl = false;
            this.acLayoutControl1.LayoutType = ControlManager.acLayoutControl.emLayoutType.NONE;
            this.acLayoutControl1.Location = new System.Drawing.Point(0, 36);
            this.acLayoutControl1.Name = "acLayoutControl1";
            this.acLayoutControl1.ParentControl = null;
            this.acLayoutControl1.Root = this.layoutControlGroup1;
            this.acLayoutControl1.Size = new System.Drawing.Size(253, 129);
            this.acLayoutControl1.TabIndex = 1;
            this.acLayoutControl1.Text = "layoutControl1";
            // 
            // acTextEdit1
            // 
            this.acTextEdit1.ColumnName = "PO_NO";
            this.acTextEdit1.Location = new System.Drawing.Point(69, 5);
            this.acTextEdit1.MaskType = ControlManager.acTextEdit.emMaskType.NONE;
            this.acTextEdit1.MenuManager = this.acBarManager1;
            this.acTextEdit1.Name = "acTextEdit1";
            this.acTextEdit1.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.acTextEdit1.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.acTextEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.acTextEdit1.Properties.Appearance.Options.UseForeColor = true;
            this.acTextEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.acTextEdit1.Size = new System.Drawing.Size(179, 20);
            this.acTextEdit1.StyleController = this.acLayoutControl1;
            this.acTextEdit1.TabIndex = 7;
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
            this.barDockControlTop.Size = new System.Drawing.Size(253, 36);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 165);
            this.barDockControlBottom.Manager = this.acBarManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(253, 0);
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
            this.barDockControlRight.Location = new System.Drawing.Point(253, 36);
            this.barDockControlRight.Manager = this.acBarManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 129);
            // 
            // acDateEdit3
            // 
            this.acDateEdit3.ColumnName = "SHIPMENT";
            this.acDateEdit3.CreateParameterFormat = "yyyyMMdd";
            this.acDateEdit3.EditValue = null;
            this.acDateEdit3.isReadyOnly = false;
            this.acDateEdit3.isRequired = false;
            this.acDateEdit3.Location = new System.Drawing.Point(69, 95);
            this.acDateEdit3.MenuManager = this.acBarManager1;
            this.acDateEdit3.Name = "acDateEdit3";
            this.acDateEdit3.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.acDateEdit3.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.acDateEdit3.Properties.Appearance.Options.UseBackColor = true;
            this.acDateEdit3.Properties.Appearance.Options.UseForeColor = true;
            this.acDateEdit3.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.acDateEdit3.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.acDateEdit3.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.acDateEdit3.Size = new System.Drawing.Size(179, 20);
            this.acDateEdit3.StyleController = this.acLayoutControl1;
            this.acDateEdit3.TabIndex = 6;
            this.acDateEdit3.ToolTipID = null;
            this.acDateEdit3.UseToolTipID = false;
            // 
            // acDateEdit2
            // 
            this.acDateEdit2.ColumnName = "SHIP_DATE";
            this.acDateEdit2.CreateParameterFormat = "yyyyMMdd";
            this.acDateEdit2.EditValue = null;
            this.acDateEdit2.isReadyOnly = false;
            this.acDateEdit2.isRequired = false;
            this.acDateEdit2.Location = new System.Drawing.Point(69, 65);
            this.acDateEdit2.MenuManager = this.acBarManager1;
            this.acDateEdit2.Name = "acDateEdit2";
            this.acDateEdit2.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.acDateEdit2.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.acDateEdit2.Properties.Appearance.Options.UseBackColor = true;
            this.acDateEdit2.Properties.Appearance.Options.UseForeColor = true;
            this.acDateEdit2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.acDateEdit2.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.acDateEdit2.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.acDateEdit2.Size = new System.Drawing.Size(179, 20);
            this.acDateEdit2.StyleController = this.acLayoutControl1;
            this.acDateEdit2.TabIndex = 5;
            this.acDateEdit2.ToolTipID = null;
            this.acDateEdit2.UseToolTipID = false;
            // 
            // acDateEdit1
            // 
            this.acDateEdit1.ColumnName = "DELIVERY";
            this.acDateEdit1.CreateParameterFormat = "yyyyMMdd";
            this.acDateEdit1.EditValue = null;
            this.acDateEdit1.isReadyOnly = false;
            this.acDateEdit1.isRequired = false;
            this.acDateEdit1.Location = new System.Drawing.Point(69, 35);
            this.acDateEdit1.MenuManager = this.acBarManager1;
            this.acDateEdit1.Name = "acDateEdit1";
            this.acDateEdit1.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.acDateEdit1.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.acDateEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.acDateEdit1.Properties.Appearance.Options.UseForeColor = true;
            this.acDateEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.acDateEdit1.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.acDateEdit1.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.acDateEdit1.Size = new System.Drawing.Size(179, 20);
            this.acDateEdit1.StyleController = this.acLayoutControl1;
            this.acDateEdit1.TabIndex = 4;
            this.acDateEdit1.ToolTipID = null;
            this.acDateEdit1.UseToolTipID = false;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.IsHeader = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.acLayoutControlItem1,
            this.emptySpaceItem1,
            this.acLayoutControlItem2,
            this.acLayoutControlItem3,
            this.acLayoutControlItem4});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.ResourceID = null;
            this.layoutControlGroup1.Size = new System.Drawing.Size(253, 130);
            this.layoutControlGroup1.TextVisible = false;
            this.layoutControlGroup1.ToolTipID = null;
            this.layoutControlGroup1.UseResourceID = false;
            this.layoutControlGroup1.UseToolTipID = false;
            // 
            // acLayoutControlItem1
            // 
            this.acLayoutControlItem1.Control = this.acDateEdit1;
            this.acLayoutControlItem1.CustomizationFormText = "Delivery";
            this.acLayoutControlItem1.IsHeader = false;
            this.acLayoutControlItem1.IsTitle = false;
            this.acLayoutControlItem1.Location = new System.Drawing.Point(0, 30);
            this.acLayoutControlItem1.Name = "acLayoutControlItem1";
            this.acLayoutControlItem1.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.acLayoutControlItem1.ResourceID = null;
            this.acLayoutControlItem1.Size = new System.Drawing.Size(253, 30);
            this.acLayoutControlItem1.Text = "Delivery";
            this.acLayoutControlItem1.TextSize = new System.Drawing.Size(52, 14);
            this.acLayoutControlItem1.ToolTipID = null;
            this.acLayoutControlItem1.ToolTipStdCode = null;
            this.acLayoutControlItem1.UseResourceID = false;
            this.acLayoutControlItem1.UseToolTipID = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 120);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(253, 10);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // acLayoutControlItem2
            // 
            this.acLayoutControlItem2.Control = this.acDateEdit2;
            this.acLayoutControlItem2.CustomizationFormText = "Ship date";
            this.acLayoutControlItem2.IsHeader = false;
            this.acLayoutControlItem2.IsTitle = false;
            this.acLayoutControlItem2.Location = new System.Drawing.Point(0, 60);
            this.acLayoutControlItem2.Name = "acLayoutControlItem2";
            this.acLayoutControlItem2.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.acLayoutControlItem2.ResourceID = null;
            this.acLayoutControlItem2.Size = new System.Drawing.Size(253, 30);
            this.acLayoutControlItem2.Text = "Ship date";
            this.acLayoutControlItem2.TextSize = new System.Drawing.Size(52, 14);
            this.acLayoutControlItem2.ToolTipID = null;
            this.acLayoutControlItem2.ToolTipStdCode = null;
            this.acLayoutControlItem2.UseResourceID = false;
            this.acLayoutControlItem2.UseToolTipID = false;
            // 
            // acLayoutControlItem3
            // 
            this.acLayoutControlItem3.Control = this.acDateEdit3;
            this.acLayoutControlItem3.CustomizationFormText = "Shipment";
            this.acLayoutControlItem3.IsHeader = false;
            this.acLayoutControlItem3.IsTitle = false;
            this.acLayoutControlItem3.Location = new System.Drawing.Point(0, 90);
            this.acLayoutControlItem3.Name = "acLayoutControlItem3";
            this.acLayoutControlItem3.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.acLayoutControlItem3.ResourceID = null;
            this.acLayoutControlItem3.Size = new System.Drawing.Size(253, 30);
            this.acLayoutControlItem3.Text = "Shipment";
            this.acLayoutControlItem3.TextSize = new System.Drawing.Size(52, 14);
            this.acLayoutControlItem3.ToolTipID = null;
            this.acLayoutControlItem3.ToolTipStdCode = null;
            this.acLayoutControlItem3.UseResourceID = false;
            this.acLayoutControlItem3.UseToolTipID = false;
            // 
            // acLayoutControlItem4
            // 
            this.acLayoutControlItem4.Control = this.acTextEdit1;
            this.acLayoutControlItem4.CustomizationFormText = "PO NO.";
            this.acLayoutControlItem4.IsHeader = false;
            this.acLayoutControlItem4.IsTitle = false;
            this.acLayoutControlItem4.Location = new System.Drawing.Point(0, 0);
            this.acLayoutControlItem4.Name = "acLayoutControlItem4";
            this.acLayoutControlItem4.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.acLayoutControlItem4.ResourceID = null;
            this.acLayoutControlItem4.Size = new System.Drawing.Size(253, 30);
            this.acLayoutControlItem4.Text = "PO NO.";
            this.acLayoutControlItem4.TextSize = new System.Drawing.Size(52, 14);
            this.acLayoutControlItem4.ToolTipID = null;
            this.acLayoutControlItem4.ToolTipStdCode = null;
            this.acLayoutControlItem4.UseResourceID = false;
            this.acLayoutControlItem4.UseToolTipID = false;
            // 
            // PUR04A_D1A
            // 
            this.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(253, 165);
            this.Controls.Add(this.acLayoutControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.IconOptions.ShowIcon = false;
            this.Name = "PUR04A_D1A";
            this.ResourceID = "";
            this.Tag = "";
            this.Text = "";
            this.ToolTipID = "";
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControl1)).EndInit();
            this.acLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.acTextEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acBarManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acDateEdit3.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acDateEdit3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acDateEdit2.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acDateEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acDateEdit1.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acDateEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ControlManager.acLayoutControl acLayoutControl1;
        private ControlManager.acLayoutControlGroup layoutControlGroup1;
        private ControlManager.acBarManager acBarManager1;
        private ControlManager.acBar bar2;
        private ControlManager.acBarButtonItem acBarButtonItem1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private ControlManager.acDateEdit acDateEdit3;
        private ControlManager.acDateEdit acDateEdit2;
        private ControlManager.acDateEdit acDateEdit1;
        private ControlManager.acLayoutControlItem acLayoutControlItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private ControlManager.acLayoutControlItem acLayoutControlItem2;
        private ControlManager.acLayoutControlItem acLayoutControlItem3;
        private ControlManager.acTextEdit acTextEdit1;
        private ControlManager.acLayoutControlItem acLayoutControlItem4;
    }
}
