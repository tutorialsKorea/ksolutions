namespace QCT
{
    partial class QCT01A_D1A
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
            this.acBarManager1 = new ControlManager.acBarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.barItemSaveClose = new ControlManager.acBarButtonItem();
            this.barItemFixedWindow = new ControlManager.acBarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.acBarButtonItem1 = new ControlManager.acBarButtonItem();
            this.acLayoutControl1 = new ControlManager.acLayoutControl();
            this.acLookupEdit2 = new ControlManager.acLookupEdit();
            this.acLookupEdit1 = new ControlManager.acLookupEdit();
            this.acTextEdit3 = new ControlManager.acTextEdit();
            this.acTextEdit1 = new ControlManager.acTextEdit();
            this.acTextEdit2 = new ControlManager.acTextEdit();
            this.layoutControlGroup1 = new ControlManager.acLayoutControlGroup();
            this.acLayoutControlItem6 = new ControlManager.acLayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.acLayoutControlItem1 = new ControlManager.acLayoutControlItem();
            this.acLayoutControlItem2 = new ControlManager.acLayoutControlItem();
            this.acLayoutControlItem3 = new ControlManager.acLayoutControlItem();
            this.acLayoutControlItem4 = new ControlManager.acLayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.acBarManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControl1)).BeginInit();
            this.acLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.acLookupEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLookupEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acTextEdit3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acTextEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acTextEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem4)).BeginInit();
            this.SuspendLayout();
            // 
            // acBarManager1
            // 
            this.acBarManager1.AllowCustomization = false;
            this.acBarManager1.AllowQuickCustomization = false;
            this.acBarManager1.AllowShowToolbarsPopup = false;
            this.acBarManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1});
            this.acBarManager1.CloseButtonAffectAllTabs = false;
            this.acBarManager1.DockControls.Add(this.barDockControlTop);
            this.acBarManager1.DockControls.Add(this.barDockControlBottom);
            this.acBarManager1.DockControls.Add(this.barDockControlLeft);
            this.acBarManager1.DockControls.Add(this.barDockControlRight);
            this.acBarManager1.Form = this;
            this.acBarManager1.IsLoadDefaultLayout = true;
            this.acBarManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barItemSaveClose,
            this.acBarButtonItem1,
            this.barItemFixedWindow});
            this.acBarManager1.MaxItemId = 4;
            // 
            // bar1
            // 
            this.bar1.BarItemHorzIndent = 10;
            this.bar1.BarItemVertIndent = 5;
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barItemSaveClose, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(this.barItemFixedWindow)});
            this.bar1.OptionsBar.UseWholeRow = true;
            this.bar1.Text = "Tools";
            // 
            // barItemSaveClose
            // 
            this.barItemSaveClose.Caption = "저장후 닫기";
            this.barItemSaveClose.Id = 1;
            this.barItemSaveClose.ImageOptions.Image = global::QCT.Resources.document_save_close_2x;
            this.barItemSaveClose.Name = "barItemSaveClose";
            this.barItemSaveClose.ResourceID = null;
            this.barItemSaveClose.ToolTipID = null;
            this.barItemSaveClose.UseResourceID = false;
            this.barItemSaveClose.UseToolTipID = false;
            this.barItemSaveClose.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barItemSaveClose_ItemClick);
            // 
            // barItemFixedWindow
            // 
            this.barItemFixedWindow.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.barItemFixedWindow.Caption = "FixWindow";
            this.barItemFixedWindow.Id = 3;
            this.barItemFixedWindow.ImageOptions.Image = global::QCT.Resources.emblem_readonly_2x;
            this.barItemFixedWindow.Name = "barItemFixedWindow";
            this.barItemFixedWindow.ResourceID = null;
            this.barItemFixedWindow.ToolTipID = null;
            this.barItemFixedWindow.UseResourceID = false;
            this.barItemFixedWindow.UseToolTipID = false;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.acBarManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(482, 36);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 140);
            this.barDockControlBottom.Manager = this.acBarManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(482, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 36);
            this.barDockControlLeft.Manager = this.acBarManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 104);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(482, 36);
            this.barDockControlRight.Manager = this.acBarManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 104);
            // 
            // acBarButtonItem1
            // 
            this.acBarButtonItem1.Caption = "Clear";
            this.acBarButtonItem1.Id = 2;
            this.acBarButtonItem1.Name = "acBarButtonItem1";
            this.acBarButtonItem1.ResourceID = null;
            this.acBarButtonItem1.ToolTipID = null;
            this.acBarButtonItem1.UseResourceID = false;
            this.acBarButtonItem1.UseToolTipID = false;
            // 
            // acLayoutControl1
            // 
            this.acLayoutControl1.AllowCustomization = false;
            this.acLayoutControl1.AutoScroll = false;
            this.acLayoutControl1.ContainerName = null;
            this.acLayoutControl1.Controls.Add(this.acLookupEdit2);
            this.acLayoutControl1.Controls.Add(this.acLookupEdit1);
            this.acLayoutControl1.Controls.Add(this.acTextEdit3);
            this.acLayoutControl1.Controls.Add(this.acTextEdit1);
            this.acLayoutControl1.Controls.Add(this.acTextEdit2);
            this.acLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.acLayoutControl1.LayoutType = ControlManager.acLayoutControl.emLayoutType.NONE;
            this.acLayoutControl1.Location = new System.Drawing.Point(0, 36);
            this.acLayoutControl1.Name = "acLayoutControl1";
            this.acLayoutControl1.ParentControl = null;
            this.acLayoutControl1.Root = this.layoutControlGroup1;
            this.acLayoutControl1.Size = new System.Drawing.Size(482, 104);
            this.acLayoutControl1.TabIndex = 5;
            this.acLayoutControl1.Text = "acLayoutControl1";
            // 
            // acLookupEdit2
            // 
            this.acLookupEdit2.ColumnName = "DETAIL_CAUSE";
            this.acLookupEdit2.DefaultValueType = ControlManager.acLookupEdit.emDefaultValueType.NONE;
            this.acLookupEdit2.isReadyOnly = true;
            this.acLookupEdit2.isRequired = true;
            this.acLookupEdit2.Location = new System.Drawing.Point(298, 35);
            this.acLookupEdit2.Name = "acLookupEdit2";
            this.acLookupEdit2.Properties.Appearance.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.acLookupEdit2.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.acLookupEdit2.Properties.Appearance.Options.UseBackColor = true;
            this.acLookupEdit2.Properties.Appearance.Options.UseForeColor = true;
            this.acLookupEdit2.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.WhiteSmoke;
            this.acLookupEdit2.Properties.AppearanceReadOnly.ForeColor = System.Drawing.Color.Black;
            this.acLookupEdit2.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.acLookupEdit2.Properties.AppearanceReadOnly.Options.UseForeColor = true;
            this.acLookupEdit2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.acLookupEdit2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.acLookupEdit2.Properties.NullText = "";
            this.acLookupEdit2.Properties.ReadOnly = true;
            this.acLookupEdit2.Properties.ShowHeader = false;
            this.acLookupEdit2.searchMode = false;
            this.acLookupEdit2.Size = new System.Drawing.Size(179, 20);
            this.acLookupEdit2.StyleController = this.acLayoutControl1;
            this.acLookupEdit2.TabIndex = 10;
            this.acLookupEdit2.ToolTipID = null;
            this.acLookupEdit2.UseToolTipID = false;
            this.acLookupEdit2.Value = null;
            // 
            // acLookupEdit1
            // 
            this.acLookupEdit1.ColumnName = "MASTER_CAUSE";
            this.acLookupEdit1.DefaultValueType = ControlManager.acLookupEdit.emDefaultValueType.NONE;
            this.acLookupEdit1.isReadyOnly = true;
            this.acLookupEdit1.isRequired = true;
            this.acLookupEdit1.Location = new System.Drawing.Point(57, 35);
            this.acLookupEdit1.Name = "acLookupEdit1";
            this.acLookupEdit1.Properties.Appearance.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.acLookupEdit1.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.acLookupEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.acLookupEdit1.Properties.Appearance.Options.UseForeColor = true;
            this.acLookupEdit1.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.WhiteSmoke;
            this.acLookupEdit1.Properties.AppearanceReadOnly.ForeColor = System.Drawing.Color.Black;
            this.acLookupEdit1.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.acLookupEdit1.Properties.AppearanceReadOnly.Options.UseForeColor = true;
            this.acLookupEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.acLookupEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.acLookupEdit1.Properties.NullText = "";
            this.acLookupEdit1.Properties.ReadOnly = true;
            this.acLookupEdit1.Properties.ShowHeader = false;
            this.acLookupEdit1.searchMode = false;
            this.acLookupEdit1.Size = new System.Drawing.Size(179, 20);
            this.acLookupEdit1.StyleController = this.acLayoutControl1;
            this.acLookupEdit1.TabIndex = 10;
            this.acLookupEdit1.ToolTipID = null;
            this.acLookupEdit1.UseToolTipID = false;
            this.acLookupEdit1.Value = null;
            // 
            // acTextEdit3
            // 
            this.acTextEdit3.ColumnName = "PROD_CODE";
            this.acTextEdit3.isReadyOnly = true;
            this.acTextEdit3.Location = new System.Drawing.Point(57, 5);
            this.acTextEdit3.MaskType = ControlManager.acTextEdit.emMaskType.NONE;
            this.acTextEdit3.MenuManager = this.acBarManager1;
            this.acTextEdit3.Name = "acTextEdit3";
            this.acTextEdit3.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.acTextEdit3.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.acTextEdit3.Properties.Appearance.Options.UseBackColor = true;
            this.acTextEdit3.Properties.Appearance.Options.UseForeColor = true;
            this.acTextEdit3.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.WhiteSmoke;
            this.acTextEdit3.Properties.AppearanceReadOnly.ForeColor = System.Drawing.Color.Black;
            this.acTextEdit3.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.acTextEdit3.Properties.AppearanceReadOnly.Options.UseForeColor = true;
            this.acTextEdit3.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.acTextEdit3.Properties.ReadOnly = true;
            this.acTextEdit3.Size = new System.Drawing.Size(179, 20);
            this.acTextEdit3.StyleController = this.acLayoutControl1;
            this.acTextEdit3.TabIndex = 11;
            // 
            // acTextEdit1
            // 
            this.acTextEdit1.ColumnName = "PART_CODE";
            this.acTextEdit1.isReadyOnly = true;
            this.acTextEdit1.Location = new System.Drawing.Point(298, 5);
            this.acTextEdit1.MaskType = ControlManager.acTextEdit.emMaskType.NONE;
            this.acTextEdit1.MenuManager = this.acBarManager1;
            this.acTextEdit1.Name = "acTextEdit1";
            this.acTextEdit1.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.acTextEdit1.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.acTextEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.acTextEdit1.Properties.Appearance.Options.UseForeColor = true;
            this.acTextEdit1.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.WhiteSmoke;
            this.acTextEdit1.Properties.AppearanceReadOnly.ForeColor = System.Drawing.Color.Black;
            this.acTextEdit1.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.acTextEdit1.Properties.AppearanceReadOnly.Options.UseForeColor = true;
            this.acTextEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.acTextEdit1.Properties.ReadOnly = true;
            this.acTextEdit1.Size = new System.Drawing.Size(179, 20);
            this.acTextEdit1.StyleController = this.acLayoutControl1;
            this.acTextEdit1.TabIndex = 10;
            // 
            // acTextEdit2
            // 
            this.acTextEdit2.ColumnName = "QUANTITY";
            this.acTextEdit2.isRequired = true;
            this.acTextEdit2.Location = new System.Drawing.Point(57, 65);
            this.acTextEdit2.MaskType = ControlManager.acTextEdit.emMaskType.QTY;
            this.acTextEdit2.Name = "acTextEdit2";
            this.acTextEdit2.Properties.Appearance.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.acTextEdit2.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.acTextEdit2.Properties.Appearance.Options.UseBackColor = true;
            this.acTextEdit2.Properties.Appearance.Options.UseForeColor = true;
            this.acTextEdit2.Properties.Appearance.Options.UseTextOptions = true;
            this.acTextEdit2.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.acTextEdit2.Properties.AppearanceReadOnly.Options.UseTextOptions = true;
            this.acTextEdit2.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.acTextEdit2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.acTextEdit2.Properties.NullText = "0";
            this.acTextEdit2.Size = new System.Drawing.Size(420, 20);
            this.acTextEdit2.StyleController = this.acLayoutControl1;
            this.acTextEdit2.TabIndex = 11;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.IsHeader = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.acLayoutControlItem6,
            this.emptySpaceItem1,
            this.acLayoutControlItem1,
            this.acLayoutControlItem2,
            this.acLayoutControlItem3,
            this.acLayoutControlItem4});
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.ResourceID = null;
            this.layoutControlGroup1.Size = new System.Drawing.Size(482, 104);
            this.layoutControlGroup1.TextVisible = false;
            this.layoutControlGroup1.ToolTipID = null;
            this.layoutControlGroup1.UseResourceID = false;
            this.layoutControlGroup1.UseToolTipID = false;
            // 
            // acLayoutControlItem6
            // 
            this.acLayoutControlItem6.Control = this.acTextEdit2;
            this.acLayoutControlItem6.CustomizationFormText = "불량수량";
            this.acLayoutControlItem6.IsHeader = false;
            this.acLayoutControlItem6.IsTitle = false;
            this.acLayoutControlItem6.Location = new System.Drawing.Point(0, 60);
            this.acLayoutControlItem6.Name = "acLayoutControlItem6";
            this.acLayoutControlItem6.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.acLayoutControlItem6.ResourceID = "UGW32N5B";
            this.acLayoutControlItem6.Size = new System.Drawing.Size(482, 30);
            this.acLayoutControlItem6.Text = "불량수량";
            this.acLayoutControlItem6.TextSize = new System.Drawing.Size(40, 14);
            this.acLayoutControlItem6.ToolTipID = null;
            this.acLayoutControlItem6.ToolTipStdCode = null;
            this.acLayoutControlItem6.UseResourceID = true;
            this.acLayoutControlItem6.UseToolTipID = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 90);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(482, 14);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // acLayoutControlItem1
            // 
            this.acLayoutControlItem1.Control = this.acTextEdit1;
            this.acLayoutControlItem1.CustomizationFormText = "품목코드";
            this.acLayoutControlItem1.IsHeader = false;
            this.acLayoutControlItem1.IsTitle = false;
            this.acLayoutControlItem1.Location = new System.Drawing.Point(241, 0);
            this.acLayoutControlItem1.Name = "acLayoutControlItem1";
            this.acLayoutControlItem1.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.acLayoutControlItem1.ResourceID = null;
            this.acLayoutControlItem1.Size = new System.Drawing.Size(241, 30);
            this.acLayoutControlItem1.Text = "품목코드";
            this.acLayoutControlItem1.TextSize = new System.Drawing.Size(40, 14);
            this.acLayoutControlItem1.ToolTipID = null;
            this.acLayoutControlItem1.ToolTipStdCode = null;
            this.acLayoutControlItem1.UseResourceID = false;
            this.acLayoutControlItem1.UseToolTipID = false;
            // 
            // acLayoutControlItem2
            // 
            this.acLayoutControlItem2.Control = this.acTextEdit3;
            this.acLayoutControlItem2.CustomizationFormText = "수주코드";
            this.acLayoutControlItem2.IsHeader = false;
            this.acLayoutControlItem2.IsTitle = false;
            this.acLayoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.acLayoutControlItem2.Name = "acLayoutControlItem2";
            this.acLayoutControlItem2.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.acLayoutControlItem2.ResourceID = null;
            this.acLayoutControlItem2.Size = new System.Drawing.Size(241, 30);
            this.acLayoutControlItem2.Text = "수주코드";
            this.acLayoutControlItem2.TextSize = new System.Drawing.Size(40, 14);
            this.acLayoutControlItem2.ToolTipID = null;
            this.acLayoutControlItem2.ToolTipStdCode = null;
            this.acLayoutControlItem2.UseResourceID = false;
            this.acLayoutControlItem2.UseToolTipID = false;
            // 
            // acLayoutControlItem3
            // 
            this.acLayoutControlItem3.Control = this.acLookupEdit1;
            this.acLayoutControlItem3.CustomizationFormText = "주원인";
            this.acLayoutControlItem3.IsHeader = false;
            this.acLayoutControlItem3.IsTitle = false;
            this.acLayoutControlItem3.Location = new System.Drawing.Point(0, 30);
            this.acLayoutControlItem3.Name = "acLayoutControlItem3";
            this.acLayoutControlItem3.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.acLayoutControlItem3.ResourceID = null;
            this.acLayoutControlItem3.Size = new System.Drawing.Size(241, 30);
            this.acLayoutControlItem3.Text = "주원인";
            this.acLayoutControlItem3.TextSize = new System.Drawing.Size(40, 14);
            this.acLayoutControlItem3.ToolTipID = null;
            this.acLayoutControlItem3.ToolTipStdCode = null;
            this.acLayoutControlItem3.UseResourceID = false;
            this.acLayoutControlItem3.UseToolTipID = false;
            // 
            // acLayoutControlItem4
            // 
            this.acLayoutControlItem4.Control = this.acLookupEdit2;
            this.acLayoutControlItem4.CustomizationFormText = "상세원인";
            this.acLayoutControlItem4.IsHeader = false;
            this.acLayoutControlItem4.IsTitle = false;
            this.acLayoutControlItem4.Location = new System.Drawing.Point(241, 30);
            this.acLayoutControlItem4.Name = "acLayoutControlItem4";
            this.acLayoutControlItem4.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.acLayoutControlItem4.ResourceID = null;
            this.acLayoutControlItem4.Size = new System.Drawing.Size(241, 30);
            this.acLayoutControlItem4.Text = "상세원인";
            this.acLayoutControlItem4.TextSize = new System.Drawing.Size(40, 14);
            this.acLayoutControlItem4.ToolTipID = null;
            this.acLayoutControlItem4.ToolTipStdCode = null;
            this.acLayoutControlItem4.UseResourceID = false;
            this.acLayoutControlItem4.UseToolTipID = false;
            // 
            // QCT01A_D1A
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(482, 140);
            this.Controls.Add(this.acLayoutControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.IconOptions.ShowIcon = false;
            this.Name = "QCT01A_D1A";
            this.Text = "불량 처리";
            ((System.ComponentModel.ISupportInitialize)(this.acBarManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControl1)).EndInit();
            this.acLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.acLookupEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLookupEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acTextEdit3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acTextEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acTextEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ControlManager.acBarManager acBarManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private ControlManager.acBarButtonItem barItemSaveClose;
        private ControlManager.acLayoutControl acLayoutControl1;
        private ControlManager.acTextEdit acTextEdit2;
        private ControlManager.acLayoutControlGroup layoutControlGroup1;
        private ControlManager.acLayoutControlItem acLayoutControlItem6;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private ControlManager.acBarButtonItem acBarButtonItem1;
        private ControlManager.acBarButtonItem barItemFixedWindow;
        private ControlManager.acTextEdit acTextEdit3;
        private ControlManager.acTextEdit acTextEdit1;
        private ControlManager.acLayoutControlItem acLayoutControlItem1;
        private ControlManager.acLayoutControlItem acLayoutControlItem2;
        private ControlManager.acLookupEdit acLookupEdit1;
        private ControlManager.acLayoutControlItem acLayoutControlItem3;
        private ControlManager.acLookupEdit acLookupEdit2;
        private ControlManager.acLayoutControlItem acLayoutControlItem4;
    }
}
