namespace POP
{
    partial class DrawFile
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
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barItemSave = new ControlManager.acBarButtonItem();
            this.barItemSaveClose = new ControlManager.acBarButtonItem();
            this.acBarButtonItem1 = new ControlManager.acBarButtonItem();
            this.barItemFixedWindow = new ControlManager.acBarButtonItem();
            this.acBarButtonItem2 = new ControlManager.acBarButtonItem();
            this.barItemSelect = new ControlManager.acBarButtonItem();
            this.acLayoutControl1 = new ControlManager.acLayoutControl();
            this.acSimpleButton2 = new ControlManager.acSimpleButton();
            this.acSimpleButton1 = new ControlManager.acSimpleButton();
            this.acGridControl1 = new ControlManager.acGridControl();
            this.acGridView1 = new ControlManager.acGridView();
            this.layoutControlGroup1 = new ControlManager.acLayoutControlGroup();
            this.acLayoutControlItem1 = new ControlManager.acLayoutControlItem();
            this.acLayoutControlItem2 = new ControlManager.acLayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.acLayoutControlItem3 = new ControlManager.acLayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.acBarManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControl1)).BeginInit();
            this.acLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.acGridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem3)).BeginInit();
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
            this.barItemSave,
            this.barItemSaveClose,
            this.acBarButtonItem1,
            this.barItemFixedWindow,
            this.acBarButtonItem2,
            this.barItemSelect});
            this.acBarManager1.MaxItemId = 7;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.acBarManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(766, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 309);
            this.barDockControlBottom.Manager = this.acBarManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(766, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Manager = this.acBarManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 309);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(766, 0);
            this.barDockControlRight.Manager = this.acBarManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 309);
            // 
            // barItemSave
            // 
            this.barItemSave.Caption = "저장";
            this.barItemSave.Id = 0;
            this.barItemSave.ImageOptions.Image = global::POP.Resource.document_save_2x;
            this.barItemSave.Name = "barItemSave";
            this.barItemSave.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barItemSave.ResourceID = null;
            this.barItemSave.ToolTipID = null;
            this.barItemSave.UseResourceID = false;
            this.barItemSave.UseToolTipID = false;
            // 
            // barItemSaveClose
            // 
            this.barItemSaveClose.Caption = "저장 후 닫기";
            this.barItemSaveClose.Id = 1;
            this.barItemSaveClose.ImageOptions.Image = global::POP.Resource.document_save_close_2x;
            this.barItemSaveClose.Name = "barItemSaveClose";
            this.barItemSaveClose.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barItemSaveClose.ResourceID = null;
            this.barItemSaveClose.ToolTipID = null;
            this.barItemSaveClose.UseResourceID = false;
            this.barItemSaveClose.UseToolTipID = false;
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
            // barItemFixedWindow
            // 
            this.barItemFixedWindow.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.barItemFixedWindow.Caption = "FixWindow";
            this.barItemFixedWindow.Id = 3;
            this.barItemFixedWindow.ImageOptions.Image = global::POP.Resource.emblem_readonly_2x;
            this.barItemFixedWindow.Name = "barItemFixedWindow";
            this.barItemFixedWindow.ResourceID = null;
            this.barItemFixedWindow.ToolTipID = null;
            this.barItemFixedWindow.UseResourceID = false;
            this.barItemFixedWindow.UseToolTipID = false;
            // 
            // acBarButtonItem2
            // 
            this.acBarButtonItem2.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.acBarButtonItem2.Caption = "닫기";
            this.acBarButtonItem2.Id = 5;
            this.acBarButtonItem2.ImageOptions.Image = global::POP.Resource.exit_2x;
            this.acBarButtonItem2.Name = "acBarButtonItem2";
            this.acBarButtonItem2.ResourceID = null;
            this.acBarButtonItem2.ToolTipID = null;
            this.acBarButtonItem2.UseResourceID = false;
            this.acBarButtonItem2.UseToolTipID = false;
            this.acBarButtonItem2.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.acBarButtonItem2_ItemClick);
            // 
            // barItemSelect
            // 
            this.barItemSelect.Caption = "선택";
            this.barItemSelect.Id = 6;
            this.barItemSelect.ImageOptions.Image = global::POP.Resource.list_confirm_2x;
            this.barItemSelect.Name = "barItemSelect";
            this.barItemSelect.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barItemSelect.ResourceID = null;
            this.barItemSelect.ToolTipID = null;
            this.barItemSelect.UseResourceID = false;
            this.barItemSelect.UseToolTipID = false;
            this.barItemSelect.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barItemSelect_ItemClick);
            // 
            // acLayoutControl1
            // 
            this.acLayoutControl1.AllowCustomization = false;
            this.acLayoutControl1.AutoScroll = false;
            this.acLayoutControl1.ContainerName = null;
            this.acLayoutControl1.Controls.Add(this.acSimpleButton2);
            this.acLayoutControl1.Controls.Add(this.acSimpleButton1);
            this.acLayoutControl1.Controls.Add(this.acGridControl1);
            this.acLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.acLayoutControl1.LayoutType = ControlManager.acLayoutControl.emLayoutType.NONE;
            this.acLayoutControl1.Location = new System.Drawing.Point(0, 0);
            this.acLayoutControl1.Name = "acLayoutControl1";
            this.acLayoutControl1.ParentControl = null;
            this.acLayoutControl1.Root = this.layoutControlGroup1;
            this.acLayoutControl1.Size = new System.Drawing.Size(766, 309);
            this.acLayoutControl1.TabIndex = 5;
            this.acLayoutControl1.Text = "acLayoutControl1";
            // 
            // acSimpleButton2
            // 
            this.acSimpleButton2.Location = new System.Drawing.Point(537, 5);
            this.acSimpleButton2.Name = "acSimpleButton2";
            this.acSimpleButton2.ResourceID = null;
            this.acSimpleButton2.Size = new System.Drawing.Size(107, 55);
            this.acSimpleButton2.StyleController = this.acLayoutControl1;
            this.acSimpleButton2.TabIndex = 6;
            this.acSimpleButton2.Text = "선택";
            this.acSimpleButton2.ToolTipID = null;
            this.acSimpleButton2.UseResourceID = false;
            this.acSimpleButton2.UseToolTipID = false;
            this.acSimpleButton2.Click += new System.EventHandler(this.acSimpleButton2_Click);
            // 
            // acSimpleButton1
            // 
            this.acSimpleButton1.Location = new System.Drawing.Point(654, 5);
            this.acSimpleButton1.Name = "acSimpleButton1";
            this.acSimpleButton1.ResourceID = null;
            this.acSimpleButton1.Size = new System.Drawing.Size(107, 55);
            this.acSimpleButton1.StyleController = this.acLayoutControl1;
            this.acSimpleButton1.TabIndex = 5;
            this.acSimpleButton1.Text = "닫기";
            this.acSimpleButton1.ToolTipID = null;
            this.acSimpleButton1.UseResourceID = false;
            this.acSimpleButton1.UseToolTipID = false;
            this.acSimpleButton1.Click += new System.EventHandler(this.acSimpleButton1_Click);
            // 
            // acGridControl1
            // 
            this.acGridControl1.Location = new System.Drawing.Point(5, 70);
            this.acGridControl1.MainView = this.acGridView1;
            this.acGridControl1.MenuManager = this.acBarManager1;
            this.acGridControl1.Name = "acGridControl1";
            this.acGridControl1.Size = new System.Drawing.Size(756, 234);
            this.acGridControl1.TabIndex = 4;
            this.acGridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.acGridView1});
            // 
            // acGridView1
            // 
            this.acGridView1.ColumnPanelRowHeight = 25;
            this.acGridView1.GridControl = this.acGridControl1;
            this.acGridView1.IsUserStyle = false;
            this.acGridView1.Name = "acGridView1";
            this.acGridView1.NoApplyEditableCellColor = false;
            this.acGridView1.OptionsLayout.Columns.StoreAllOptions = true;
            this.acGridView1.OptionsLayout.StoreAllOptions = true;
            this.acGridView1.OptionsView.EnableAppearanceEvenRow = true;
            this.acGridView1.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.Button;
            this.acGridView1.OptionsView.RowAutoHeight = true;
            this.acGridView1.OptionsView.ShowGroupPanel = false;
            this.acGridView1.OptionsView.ShowIndicator = false;
            this.acGridView1.ParentControl = this.acLayoutControl1;
            this.acGridView1.RowHeight = 25;
            this.acGridView1.SaveFileName = null;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.IsHeader = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.acLayoutControlItem1,
            this.acLayoutControlItem2,
            this.emptySpaceItem1,
            this.acLayoutControlItem3});
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.ResourceID = null;
            this.layoutControlGroup1.Size = new System.Drawing.Size(766, 309);
            this.layoutControlGroup1.TextVisible = false;
            this.layoutControlGroup1.ToolTipID = null;
            this.layoutControlGroup1.UseResourceID = false;
            this.layoutControlGroup1.UseToolTipID = false;
            // 
            // acLayoutControlItem1
            // 
            this.acLayoutControlItem1.Control = this.acGridControl1;
            this.acLayoutControlItem1.CustomizationFormText = "acLayoutControlItem1";
            this.acLayoutControlItem1.IsHeader = false;
            this.acLayoutControlItem1.IsTitle = false;
            this.acLayoutControlItem1.Location = new System.Drawing.Point(0, 65);
            this.acLayoutControlItem1.Name = "acLayoutControlItem1";
            this.acLayoutControlItem1.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.acLayoutControlItem1.ResourceID = null;
            this.acLayoutControlItem1.Size = new System.Drawing.Size(766, 244);
            this.acLayoutControlItem1.Text = "acLayoutControlItem1";
            this.acLayoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.acLayoutControlItem1.TextVisible = false;
            this.acLayoutControlItem1.ToolTipID = null;
            this.acLayoutControlItem1.ToolTipStdCode = null;
            this.acLayoutControlItem1.UseResourceID = false;
            this.acLayoutControlItem1.UseToolTipID = false;
            // 
            // acLayoutControlItem2
            // 
            this.acLayoutControlItem2.Control = this.acSimpleButton1;
            this.acLayoutControlItem2.CustomizationFormText = "acLayoutControlItem2";
            this.acLayoutControlItem2.IsHeader = false;
            this.acLayoutControlItem2.IsTitle = false;
            this.acLayoutControlItem2.Location = new System.Drawing.Point(649, 0);
            this.acLayoutControlItem2.MaxSize = new System.Drawing.Size(117, 65);
            this.acLayoutControlItem2.MinSize = new System.Drawing.Size(117, 65);
            this.acLayoutControlItem2.Name = "acLayoutControlItem2";
            this.acLayoutControlItem2.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.acLayoutControlItem2.ResourceID = null;
            this.acLayoutControlItem2.Size = new System.Drawing.Size(117, 65);
            this.acLayoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.acLayoutControlItem2.Text = "acLayoutControlItem2";
            this.acLayoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.acLayoutControlItem2.TextVisible = false;
            this.acLayoutControlItem2.ToolTipID = null;
            this.acLayoutControlItem2.ToolTipStdCode = null;
            this.acLayoutControlItem2.UseResourceID = false;
            this.acLayoutControlItem2.UseToolTipID = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(532, 65);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // acLayoutControlItem3
            // 
            this.acLayoutControlItem3.Control = this.acSimpleButton2;
            this.acLayoutControlItem3.CustomizationFormText = "선택";
            this.acLayoutControlItem3.IsHeader = false;
            this.acLayoutControlItem3.IsTitle = false;
            this.acLayoutControlItem3.Location = new System.Drawing.Point(532, 0);
            this.acLayoutControlItem3.MaxSize = new System.Drawing.Size(117, 65);
            this.acLayoutControlItem3.MinSize = new System.Drawing.Size(117, 65);
            this.acLayoutControlItem3.Name = "acLayoutControlItem3";
            this.acLayoutControlItem3.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.acLayoutControlItem3.ResourceID = null;
            this.acLayoutControlItem3.Size = new System.Drawing.Size(117, 65);
            this.acLayoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.acLayoutControlItem3.Text = "선택";
            this.acLayoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.acLayoutControlItem3.TextVisible = false;
            this.acLayoutControlItem3.ToolTipID = null;
            this.acLayoutControlItem3.ToolTipStdCode = null;
            this.acLayoutControlItem3.UseResourceID = false;
            this.acLayoutControlItem3.UseToolTipID = false;
            // 
            // DrawFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(766, 309);
            this.Controls.Add(this.acLayoutControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.IconOptions.ShowIcon = false;
            this.Name = "DrawFile";
            this.Text = "도면 리스트";
            ((System.ComponentModel.ISupportInitialize)(this.acBarManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControl1)).EndInit();
            this.acLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.acGridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ControlManager.acBarManager acBarManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private ControlManager.acBarButtonItem barItemSave;
        private ControlManager.acBarButtonItem barItemSaveClose;
        private ControlManager.acLayoutControl acLayoutControl1;
        private ControlManager.acLayoutControlGroup layoutControlGroup1;
        private ControlManager.acBarButtonItem acBarButtonItem1;
        private ControlManager.acBarButtonItem barItemFixedWindow;
        private ControlManager.acBarButtonItem acBarButtonItem2;
        private ControlManager.acBarButtonItem barItemSelect;
        private ControlManager.acGridControl acGridControl1;
        private ControlManager.acGridView acGridView1;
        private ControlManager.acLayoutControlItem acLayoutControlItem1;
        private ControlManager.acSimpleButton acSimpleButton2;
        private ControlManager.acSimpleButton acSimpleButton1;
        private ControlManager.acLayoutControlItem acLayoutControlItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private ControlManager.acLayoutControlItem acLayoutControlItem3;
    }
}
