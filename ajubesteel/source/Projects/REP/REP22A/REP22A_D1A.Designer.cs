namespace REP
{
    partial class REP22A_D1A
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
            this.acTextEdit6 = new ControlManager.acTextEdit();
            this.acTextEdit5 = new ControlManager.acTextEdit();
            this.acTextEdit4 = new ControlManager.acTextEdit();
            this.acTextEdit3 = new ControlManager.acTextEdit();
            this.acTextEdit2 = new ControlManager.acTextEdit();
            this.acTextEdit1 = new ControlManager.acTextEdit();
            this.Root = new ControlManager.acLayoutControlGroup();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.acLayoutControlItem2 = new ControlManager.acLayoutControlItem();
            this.acLayoutControlItem3 = new ControlManager.acLayoutControlItem();
            this.acLayoutControlItem4 = new ControlManager.acLayoutControlItem();
            this.acLayoutControlItem5 = new ControlManager.acLayoutControlItem();
            this.acLayoutControlItem1 = new ControlManager.acLayoutControlItem();
            this.acLayoutControlItem6 = new ControlManager.acLayoutControlItem();
            this.acTextEdit7 = new ControlManager.acTextEdit();
            this.acLayoutControlItem7 = new ControlManager.acLayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.acBarManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControl1)).BeginInit();
            this.acLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.acTextEdit6.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acTextEdit5.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acTextEdit4.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acTextEdit3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acTextEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acTextEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acTextEdit7.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem7)).BeginInit();
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
            this.barItemSaveClose.ImageOptions.Image = global::REP.Resource.document_save_2x;
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
            this.barItemFixedWindow.ImageOptions.Image = global::REP.Resource.emblem_readonly_2x;
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
            this.barDockControlTop.Size = new System.Drawing.Size(641, 36);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 94);
            this.barDockControlBottom.Manager = this.acBarManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(641, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 36);
            this.barDockControlLeft.Manager = this.acBarManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 58);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(641, 36);
            this.barDockControlRight.Manager = this.acBarManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 58);
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
            this.acLayoutControl1.ContainerName = null;
            this.acLayoutControl1.Controls.Add(this.acTextEdit7);
            this.acLayoutControl1.Controls.Add(this.acTextEdit6);
            this.acLayoutControl1.Controls.Add(this.acTextEdit5);
            this.acLayoutControl1.Controls.Add(this.acTextEdit4);
            this.acLayoutControl1.Controls.Add(this.acTextEdit3);
            this.acLayoutControl1.Controls.Add(this.acTextEdit2);
            this.acLayoutControl1.Controls.Add(this.acTextEdit1);
            this.acLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.acLayoutControl1.EnterMoveNextControl = false;
            this.acLayoutControl1.LayoutType = ControlManager.acLayoutControl.emLayoutType.NONE;
            this.acLayoutControl1.Location = new System.Drawing.Point(0, 36);
            this.acLayoutControl1.Name = "acLayoutControl1";
            this.acLayoutControl1.ParentControl = null;
            this.acLayoutControl1.Root = this.Root;
            this.acLayoutControl1.Size = new System.Drawing.Size(641, 58);
            this.acLayoutControl1.TabIndex = 15;
            this.acLayoutControl1.Text = "acLayoutControl1";
            // 
            // acTextEdit6
            // 
            this.acTextEdit6.ColumnName = "COST_SHIP_TIME";
            this.acTextEdit6.Location = new System.Drawing.Point(582, 5);
            this.acTextEdit6.MaskType = ControlManager.acTextEdit.emMaskType.F2;
            this.acTextEdit6.MenuManager = this.acBarManager1;
            this.acTextEdit6.Name = "acTextEdit6";
            this.acTextEdit6.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.acTextEdit6.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.acTextEdit6.Properties.Appearance.Options.UseBackColor = true;
            this.acTextEdit6.Properties.Appearance.Options.UseForeColor = true;
            this.acTextEdit6.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.acTextEdit6.Size = new System.Drawing.Size(54, 20);
            this.acTextEdit6.StyleController = this.acLayoutControl1;
            this.acTextEdit6.TabIndex = 10;
            // 
            // acTextEdit5
            // 
            this.acTextEdit5.ColumnName = "COST_ASSY_TIME";
            this.acTextEdit5.Location = new System.Drawing.Point(494, 5);
            this.acTextEdit5.MaskType = ControlManager.acTextEdit.emMaskType.F2;
            this.acTextEdit5.MenuManager = this.acBarManager1;
            this.acTextEdit5.Name = "acTextEdit5";
            this.acTextEdit5.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.acTextEdit5.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.acTextEdit5.Properties.Appearance.Options.UseBackColor = true;
            this.acTextEdit5.Properties.Appearance.Options.UseForeColor = true;
            this.acTextEdit5.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.acTextEdit5.Size = new System.Drawing.Size(53, 20);
            this.acTextEdit5.StyleController = this.acLayoutControl1;
            this.acTextEdit5.TabIndex = 9;
            // 
            // acTextEdit4
            // 
            this.acTextEdit4.ColumnName = "COST_INS_TIME";
            this.acTextEdit4.Location = new System.Drawing.Point(405, 5);
            this.acTextEdit4.MaskType = ControlManager.acTextEdit.emMaskType.F2;
            this.acTextEdit4.MenuManager = this.acBarManager1;
            this.acTextEdit4.Name = "acTextEdit4";
            this.acTextEdit4.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.acTextEdit4.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.acTextEdit4.Properties.Appearance.Options.UseBackColor = true;
            this.acTextEdit4.Properties.Appearance.Options.UseForeColor = true;
            this.acTextEdit4.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.acTextEdit4.Size = new System.Drawing.Size(54, 20);
            this.acTextEdit4.StyleController = this.acLayoutControl1;
            this.acTextEdit4.TabIndex = 8;
            // 
            // acTextEdit3
            // 
            this.acTextEdit3.ColumnName = "COST_SIDE_TIME";
            this.acTextEdit3.Location = new System.Drawing.Point(316, 5);
            this.acTextEdit3.MaskType = ControlManager.acTextEdit.emMaskType.F2;
            this.acTextEdit3.MenuManager = this.acBarManager1;
            this.acTextEdit3.Name = "acTextEdit3";
            this.acTextEdit3.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.acTextEdit3.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.acTextEdit3.Properties.Appearance.Options.UseBackColor = true;
            this.acTextEdit3.Properties.Appearance.Options.UseForeColor = true;
            this.acTextEdit3.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.acTextEdit3.Size = new System.Drawing.Size(54, 20);
            this.acTextEdit3.StyleController = this.acLayoutControl1;
            this.acTextEdit3.TabIndex = 7;
            // 
            // acTextEdit2
            // 
            this.acTextEdit2.ColumnName = "COST_MILL_TIME";
            this.acTextEdit2.Location = new System.Drawing.Point(217, 5);
            this.acTextEdit2.MaskType = ControlManager.acTextEdit.emMaskType.F2;
            this.acTextEdit2.MenuManager = this.acBarManager1;
            this.acTextEdit2.Name = "acTextEdit2";
            this.acTextEdit2.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.acTextEdit2.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.acTextEdit2.Properties.Appearance.Options.UseBackColor = true;
            this.acTextEdit2.Properties.Appearance.Options.UseForeColor = true;
            this.acTextEdit2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.acTextEdit2.Size = new System.Drawing.Size(54, 20);
            this.acTextEdit2.StyleController = this.acLayoutControl1;
            this.acTextEdit2.TabIndex = 6;
            // 
            // acTextEdit1
            // 
            this.acTextEdit1.ColumnName = "COST_DES_TIME";
            this.acTextEdit1.Location = new System.Drawing.Point(30, 5);
            this.acTextEdit1.MaskType = ControlManager.acTextEdit.emMaskType.F2;
            this.acTextEdit1.MenuManager = this.acBarManager1;
            this.acTextEdit1.Name = "acTextEdit1";
            this.acTextEdit1.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.acTextEdit1.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.acTextEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.acTextEdit1.Properties.Appearance.Options.UseForeColor = true;
            this.acTextEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.acTextEdit1.Size = new System.Drawing.Size(56, 20);
            this.acTextEdit1.StyleController = this.acLayoutControl1;
            this.acTextEdit1.TabIndex = 5;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.False;
            this.Root.GroupBordersVisible = false;
            this.Root.IsHeader = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.emptySpaceItem1,
            this.acLayoutControlItem2,
            this.acLayoutControlItem3,
            this.acLayoutControlItem4,
            this.acLayoutControlItem5,
            this.acLayoutControlItem1,
            this.acLayoutControlItem6,
            this.acLayoutControlItem7});
            this.Root.Name = "Root";
            this.Root.ResourceID = null;
            this.Root.Size = new System.Drawing.Size(641, 58);
            this.Root.TextVisible = false;
            this.Root.ToolTipID = null;
            this.Root.UseResourceID = false;
            this.Root.UseToolTipID = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 30);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(641, 28);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // acLayoutControlItem2
            // 
            this.acLayoutControlItem2.Control = this.acTextEdit1;
            this.acLayoutControlItem2.CustomizationFormText = "설계";
            this.acLayoutControlItem2.IsHeader = false;
            this.acLayoutControlItem2.IsTitle = false;
            this.acLayoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.acLayoutControlItem2.Name = "acLayoutControlItem2";
            this.acLayoutControlItem2.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.acLayoutControlItem2.ResourceID = null;
            this.acLayoutControlItem2.Size = new System.Drawing.Size(91, 30);
            this.acLayoutControlItem2.Text = "설계";
            this.acLayoutControlItem2.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.acLayoutControlItem2.TextSize = new System.Drawing.Size(20, 14);
            this.acLayoutControlItem2.TextToControlDistance = 5;
            this.acLayoutControlItem2.ToolTipID = null;
            this.acLayoutControlItem2.ToolTipStdCode = null;
            this.acLayoutControlItem2.UseResourceID = false;
            this.acLayoutControlItem2.UseToolTipID = false;
            // 
            // acLayoutControlItem3
            // 
            this.acLayoutControlItem3.Control = this.acTextEdit2;
            this.acLayoutControlItem3.CustomizationFormText = "밀링";
            this.acLayoutControlItem3.IsHeader = false;
            this.acLayoutControlItem3.IsTitle = false;
            this.acLayoutControlItem3.Location = new System.Drawing.Point(187, 0);
            this.acLayoutControlItem3.Name = "acLayoutControlItem3";
            this.acLayoutControlItem3.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.acLayoutControlItem3.ResourceID = null;
            this.acLayoutControlItem3.Size = new System.Drawing.Size(89, 30);
            this.acLayoutControlItem3.Text = "밀링";
            this.acLayoutControlItem3.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.acLayoutControlItem3.TextSize = new System.Drawing.Size(20, 14);
            this.acLayoutControlItem3.TextToControlDistance = 5;
            this.acLayoutControlItem3.ToolTipID = null;
            this.acLayoutControlItem3.ToolTipStdCode = null;
            this.acLayoutControlItem3.UseResourceID = false;
            this.acLayoutControlItem3.UseToolTipID = false;
            // 
            // acLayoutControlItem4
            // 
            this.acLayoutControlItem4.Control = this.acTextEdit3;
            this.acLayoutControlItem4.CustomizationFormText = "후가공";
            this.acLayoutControlItem4.IsHeader = false;
            this.acLayoutControlItem4.IsTitle = false;
            this.acLayoutControlItem4.Location = new System.Drawing.Point(276, 0);
            this.acLayoutControlItem4.Name = "acLayoutControlItem4";
            this.acLayoutControlItem4.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.acLayoutControlItem4.ResourceID = null;
            this.acLayoutControlItem4.Size = new System.Drawing.Size(99, 30);
            this.acLayoutControlItem4.Text = "후가공";
            this.acLayoutControlItem4.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.acLayoutControlItem4.TextSize = new System.Drawing.Size(30, 14);
            this.acLayoutControlItem4.TextToControlDistance = 5;
            this.acLayoutControlItem4.ToolTipID = null;
            this.acLayoutControlItem4.ToolTipStdCode = null;
            this.acLayoutControlItem4.UseResourceID = false;
            this.acLayoutControlItem4.UseToolTipID = false;
            // 
            // acLayoutControlItem5
            // 
            this.acLayoutControlItem5.Control = this.acTextEdit4;
            this.acLayoutControlItem5.CustomizationFormText = "검사";
            this.acLayoutControlItem5.IsHeader = false;
            this.acLayoutControlItem5.IsTitle = false;
            this.acLayoutControlItem5.Location = new System.Drawing.Point(375, 0);
            this.acLayoutControlItem5.Name = "acLayoutControlItem5";
            this.acLayoutControlItem5.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.acLayoutControlItem5.ResourceID = null;
            this.acLayoutControlItem5.Size = new System.Drawing.Size(89, 30);
            this.acLayoutControlItem5.Text = "검사";
            this.acLayoutControlItem5.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.acLayoutControlItem5.TextSize = new System.Drawing.Size(20, 14);
            this.acLayoutControlItem5.TextToControlDistance = 5;
            this.acLayoutControlItem5.ToolTipID = null;
            this.acLayoutControlItem5.ToolTipStdCode = null;
            this.acLayoutControlItem5.UseResourceID = false;
            this.acLayoutControlItem5.UseToolTipID = false;
            // 
            // acLayoutControlItem1
            // 
            this.acLayoutControlItem1.Control = this.acTextEdit5;
            this.acLayoutControlItem1.CustomizationFormText = "조립";
            this.acLayoutControlItem1.IsHeader = false;
            this.acLayoutControlItem1.IsTitle = false;
            this.acLayoutControlItem1.Location = new System.Drawing.Point(464, 0);
            this.acLayoutControlItem1.Name = "acLayoutControlItem1";
            this.acLayoutControlItem1.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.acLayoutControlItem1.ResourceID = null;
            this.acLayoutControlItem1.Size = new System.Drawing.Size(88, 30);
            this.acLayoutControlItem1.Text = "조립";
            this.acLayoutControlItem1.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.acLayoutControlItem1.TextSize = new System.Drawing.Size(20, 14);
            this.acLayoutControlItem1.TextToControlDistance = 5;
            this.acLayoutControlItem1.ToolTipID = null;
            this.acLayoutControlItem1.ToolTipStdCode = null;
            this.acLayoutControlItem1.UseResourceID = false;
            this.acLayoutControlItem1.UseToolTipID = false;
            // 
            // acLayoutControlItem6
            // 
            this.acLayoutControlItem6.Control = this.acTextEdit6;
            this.acLayoutControlItem6.CustomizationFormText = "출하";
            this.acLayoutControlItem6.IsHeader = false;
            this.acLayoutControlItem6.IsTitle = false;
            this.acLayoutControlItem6.Location = new System.Drawing.Point(552, 0);
            this.acLayoutControlItem6.Name = "acLayoutControlItem6";
            this.acLayoutControlItem6.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.acLayoutControlItem6.ResourceID = null;
            this.acLayoutControlItem6.Size = new System.Drawing.Size(89, 30);
            this.acLayoutControlItem6.Text = "출하";
            this.acLayoutControlItem6.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.acLayoutControlItem6.TextSize = new System.Drawing.Size(20, 14);
            this.acLayoutControlItem6.TextToControlDistance = 5;
            this.acLayoutControlItem6.ToolTipID = null;
            this.acLayoutControlItem6.ToolTipStdCode = null;
            this.acLayoutControlItem6.UseResourceID = false;
            this.acLayoutControlItem6.UseToolTipID = false;
            // 
            // acTextEdit7
            // 
            this.acTextEdit7.ColumnName = "COST_CAM_TIME";
            this.acTextEdit7.Location = new System.Drawing.Point(132, 5);
            this.acTextEdit7.MaskType = ControlManager.acTextEdit.emMaskType.F2;
            this.acTextEdit7.MenuManager = this.acBarManager1;
            this.acTextEdit7.Name = "acTextEdit7";
            this.acTextEdit7.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.acTextEdit7.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.acTextEdit7.Properties.Appearance.Options.UseBackColor = true;
            this.acTextEdit7.Properties.Appearance.Options.UseForeColor = true;
            this.acTextEdit7.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.acTextEdit7.Size = new System.Drawing.Size(50, 20);
            this.acTextEdit7.StyleController = this.acLayoutControl1;
            this.acTextEdit7.TabIndex = 11;
            // 
            // acLayoutControlItem7
            // 
            this.acLayoutControlItem7.Control = this.acTextEdit7;
            this.acLayoutControlItem7.CustomizationFormText = "CAM";
            this.acLayoutControlItem7.IsHeader = false;
            this.acLayoutControlItem7.IsTitle = false;
            this.acLayoutControlItem7.Location = new System.Drawing.Point(91, 0);
            this.acLayoutControlItem7.Name = "acLayoutControlItem7";
            this.acLayoutControlItem7.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.acLayoutControlItem7.ResourceID = null;
            this.acLayoutControlItem7.Size = new System.Drawing.Size(96, 30);
            this.acLayoutControlItem7.Text = "CAM";
            this.acLayoutControlItem7.TextSize = new System.Drawing.Size(24, 14);
            this.acLayoutControlItem7.ToolTipID = null;
            this.acLayoutControlItem7.ToolTipStdCode = null;
            this.acLayoutControlItem7.UseResourceID = false;
            this.acLayoutControlItem7.UseToolTipID = false;
            // 
            // REP22A_D1A
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(641, 94);
            this.Controls.Add(this.acLayoutControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.IconOptions.ShowIcon = false;
            this.Name = "REP22A_D1A";
            this.Text = "상세설정 편집기";
            ((System.ComponentModel.ISupportInitialize)(this.acBarManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControl1)).EndInit();
            this.acLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.acTextEdit6.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acTextEdit5.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acTextEdit4.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acTextEdit3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acTextEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acTextEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acTextEdit7.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem7)).EndInit();
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
        private ControlManager.acBarButtonItem acBarButtonItem1;
        private ControlManager.acBarButtonItem barItemFixedWindow;
        private ControlManager.acLayoutControl acLayoutControl1;
        private ControlManager.acLayoutControlGroup Root;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private ControlManager.acTextEdit acTextEdit4;
        private ControlManager.acTextEdit acTextEdit3;
        private ControlManager.acTextEdit acTextEdit2;
        private ControlManager.acTextEdit acTextEdit1;
        private ControlManager.acLayoutControlItem acLayoutControlItem2;
        private ControlManager.acLayoutControlItem acLayoutControlItem3;
        private ControlManager.acLayoutControlItem acLayoutControlItem4;
        private ControlManager.acLayoutControlItem acLayoutControlItem5;
        private ControlManager.acTextEdit acTextEdit6;
        private ControlManager.acTextEdit acTextEdit5;
        private ControlManager.acLayoutControlItem acLayoutControlItem1;
        private ControlManager.acLayoutControlItem acLayoutControlItem6;
        private ControlManager.acTextEdit acTextEdit7;
        private ControlManager.acLayoutControlItem acLayoutControlItem7;
    }
}
