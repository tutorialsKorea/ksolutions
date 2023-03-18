namespace ORD
{
    partial class ORD02A_D5A
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
            this.acTreeList1 = new ControlManager.acTreeList();
            this.acBarManager1 = new ControlManager.acBarManager(this.components);
            this.bar2 = new ControlManager.acBar();
            this.acBarButtonItem1 = new ControlManager.acBarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.acBarButtonItem2 = new ControlManager.acBarButtonItem();
            this.acBarButtonItem3 = new ControlManager.acBarButtonItem();
            this.acBarButtonItem4 = new ControlManager.acBarButtonItem();
            this.popupMenu1 = new DevExpress.XtraBars.PopupMenu(this.components);
            this.acLayoutControl1 = new ControlManager.acLayoutControl();
            this.acCheckEdit1 = new ControlManager.acCheckEdit();
            this.acLabelControl1 = new ControlManager.acLabelControl();
            this.Root = new ControlManager.acLayoutControlGroup();
            this.acLayoutControlItem1 = new ControlManager.acLayoutControlItem();
            this.acLayoutControlItem2 = new ControlManager.acLayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.acTreeList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acBarManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControl1)).BeginInit();
            this.acLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.acCheckEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // acTreeList1
            // 
            this.acTreeList1.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black;
            this.acTreeList1.Appearance.FocusedRow.Options.UseForeColor = true;
            this.acTreeList1.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.acTreeList1.Appearance.SelectedRow.Options.UseForeColor = true;
            this.acTreeList1.ColumnPanelRowHeight = 30;
            this.acTreeList1.DataSource = null;
            this.acTreeList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.acTreeList1.IndicatorWidth = 30;
            this.acTreeList1.Location = new System.Drawing.Point(0, 69);
            this.acTreeList1.MenuManager = this.acBarManager1;
            this.acTreeList1.Name = "acTreeList1";
            this.acTreeList1.OptionsMenu.ShowExpandCollapseItems = false;
            this.acTreeList1.ParentControl = this;
            this.acTreeList1.RowHeight = 20;
            this.acTreeList1.SaveFileName = null;
            this.acTreeList1.Size = new System.Drawing.Size(632, 359);
            this.acTreeList1.TabIndex = 4;
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
            this.acBarButtonItem1,
            this.acBarButtonItem2,
            this.acBarButtonItem3,
            this.acBarButtonItem4});
            this.acBarManager1.MainMenu = this.bar2;
            this.acBarManager1.MaxItemId = 4;
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
            this.acBarButtonItem1.Caption = "저장";
            this.acBarButtonItem1.Id = 0;
            this.acBarButtonItem1.ImageOptions.Image = global::ORD.Resource.document_save_2x;
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
            this.barDockControlTop.Size = new System.Drawing.Size(632, 36);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 428);
            this.barDockControlBottom.Manager = this.acBarManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(632, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 36);
            this.barDockControlLeft.Manager = this.acBarManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 392);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(632, 36);
            this.barDockControlRight.Manager = this.acBarManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 392);
            // 
            // acBarButtonItem2
            // 
            this.acBarButtonItem2.Caption = "삭제";
            this.acBarButtonItem2.Id = 1;
            this.acBarButtonItem2.ImageOptions.Image = global::ORD.Resource.edit_delete_2x;
            this.acBarButtonItem2.Name = "acBarButtonItem2";
            this.acBarButtonItem2.ResourceID = null;
            this.acBarButtonItem2.ToolTipID = null;
            this.acBarButtonItem2.UseResourceID = false;
            this.acBarButtonItem2.UseToolTipID = false;
            this.acBarButtonItem2.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.acBarButtonItem2_ItemClick);
            // 
            // acBarButtonItem3
            // 
            this.acBarButtonItem3.Caption = "복원";
            this.acBarButtonItem3.Id = 2;
            this.acBarButtonItem3.ImageOptions.Image = global::ORD.Resource.edit_undo_2x;
            this.acBarButtonItem3.Name = "acBarButtonItem3";
            this.acBarButtonItem3.ResourceID = null;
            this.acBarButtonItem3.ToolTipID = null;
            this.acBarButtonItem3.UseResourceID = false;
            this.acBarButtonItem3.UseToolTipID = false;
            this.acBarButtonItem3.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.acBarButtonItem3_ItemClick);
            // 
            // acBarButtonItem4
            // 
            this.acBarButtonItem4.Caption = "acBarButtonItem4";
            this.acBarButtonItem4.Id = 3;
            this.acBarButtonItem4.Name = "acBarButtonItem4";
            this.acBarButtonItem4.ResourceID = null;
            this.acBarButtonItem4.ToolTipID = null;
            this.acBarButtonItem4.UseResourceID = false;
            this.acBarButtonItem4.UseToolTipID = false;
            // 
            // popupMenu1
            // 
            this.popupMenu1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.acBarButtonItem2),
            new DevExpress.XtraBars.LinkPersistInfo(this.acBarButtonItem3)});
            this.popupMenu1.Manager = this.acBarManager1;
            this.popupMenu1.Name = "popupMenu1";
            // 
            // acLayoutControl1
            // 
            this.acLayoutControl1.AllowCustomization = false;
            this.acLayoutControl1.ContainerName = null;
            this.acLayoutControl1.Controls.Add(this.acCheckEdit1);
            this.acLayoutControl1.Controls.Add(this.acLabelControl1);
            this.acLayoutControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.acLayoutControl1.EnterMoveNextControl = false;
            this.acLayoutControl1.LayoutType = ControlManager.acLayoutControl.emLayoutType.NONE;
            this.acLayoutControl1.Location = new System.Drawing.Point(0, 36);
            this.acLayoutControl1.Name = "acLayoutControl1";
            this.acLayoutControl1.ParentControl = null;
            this.acLayoutControl1.Root = this.Root;
            this.acLayoutControl1.Size = new System.Drawing.Size(632, 33);
            this.acLayoutControl1.TabIndex = 6;
            this.acLayoutControl1.Text = "acLayoutControl1";
            // 
            // acCheckEdit1
            // 
            this.acCheckEdit1.ColumnName = null;
            this.acCheckEdit1.EditValue = "0";
            this.acCheckEdit1.isReadyOnly = false;
            this.acCheckEdit1.isRequired = false;
            this.acCheckEdit1.Location = new System.Drawing.Point(5, 5);
            this.acCheckEdit1.MenuManager = this.acBarManager1;
            this.acCheckEdit1.Name = "acCheckEdit1";
            this.acCheckEdit1.Properties.Caption = "삭제포함 여부";
            this.acCheckEdit1.Properties.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            this.acCheckEdit1.Properties.ValueChecked = "1";
            this.acCheckEdit1.Properties.ValueUnchecked = "0";
            this.acCheckEdit1.Size = new System.Drawing.Size(122, 20);
            this.acCheckEdit1.StyleController = this.acLayoutControl1;
            this.acCheckEdit1.TabIndex = 5;
            this.acCheckEdit1.ToolTipID = null;
            this.acCheckEdit1.UseToolTipID = false;
            this.acCheckEdit1.Value = "0";
            this.acCheckEdit1.ValueType = ControlManager.acCheckEdit.emValueType.STRING;
            // 
            // acLabelControl1
            // 
            this.acLabelControl1.Location = new System.Drawing.Point(137, 5);
            this.acLabelControl1.Name = "acLabelControl1";
            this.acLabelControl1.ResourceID = null;
            this.acLabelControl1.Size = new System.Drawing.Size(490, 23);
            this.acLabelControl1.StyleController = this.acLayoutControl1;
            this.acLabelControl1.TabIndex = 4;
            this.acLabelControl1.Text = "수주 생성 후 BOM편집으로 삭제된 BOM포함";
            this.acLabelControl1.ToolTipID = null;
            this.acLabelControl1.UseResourceID = false;
            this.acLabelControl1.UseToolTipID = false;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.False;
            this.Root.GroupBordersVisible = false;
            this.Root.IsHeader = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.acLayoutControlItem1,
            this.acLayoutControlItem2});
            this.Root.Name = "Root";
            this.Root.ResourceID = null;
            this.Root.Size = new System.Drawing.Size(632, 33);
            this.Root.TextVisible = false;
            this.Root.ToolTipID = null;
            this.Root.UseResourceID = false;
            this.Root.UseToolTipID = false;
            // 
            // acLayoutControlItem1
            // 
            this.acLayoutControlItem1.Control = this.acLabelControl1;
            this.acLayoutControlItem1.CustomizationFormText = "acLayoutControlItem1";
            this.acLayoutControlItem1.IsHeader = false;
            this.acLayoutControlItem1.IsTitle = false;
            this.acLayoutControlItem1.Location = new System.Drawing.Point(132, 0);
            this.acLayoutControlItem1.MinSize = new System.Drawing.Size(96, 24);
            this.acLayoutControlItem1.Name = "acLayoutControlItem1";
            this.acLayoutControlItem1.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.acLayoutControlItem1.ResourceID = null;
            this.acLayoutControlItem1.Size = new System.Drawing.Size(500, 33);
            this.acLayoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
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
            this.acLayoutControlItem2.Control = this.acCheckEdit1;
            this.acLayoutControlItem2.CustomizationFormText = "acLayoutControlItem2";
            this.acLayoutControlItem2.IsHeader = false;
            this.acLayoutControlItem2.IsTitle = false;
            this.acLayoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.acLayoutControlItem2.MinSize = new System.Drawing.Size(93, 30);
            this.acLayoutControlItem2.Name = "acLayoutControlItem2";
            this.acLayoutControlItem2.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.acLayoutControlItem2.ResourceID = null;
            this.acLayoutControlItem2.Size = new System.Drawing.Size(132, 33);
            this.acLayoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.acLayoutControlItem2.Text = "acLayoutControlItem2";
            this.acLayoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.acLayoutControlItem2.TextVisible = false;
            this.acLayoutControlItem2.ToolTipID = null;
            this.acLayoutControlItem2.ToolTipStdCode = null;
            this.acLayoutControlItem2.UseResourceID = false;
            this.acLayoutControlItem2.UseToolTipID = false;
            // 
            // ORD02A_D5A
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(632, 428);
            this.Controls.Add(this.acTreeList1);
            this.Controls.Add(this.acLayoutControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.IconOptions.ShowIcon = false;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ORD02A_D5A";
            this.ResourceID = "";
            this.Tag = "";
            this.Text = "BOM 편집기";
            this.ToolTipID = "";
            ((System.ComponentModel.ISupportInitialize)(this.acTreeList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acBarManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControl1)).EndInit();
            this.acLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.acCheckEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private ControlManager.acBarManager acBarManager1;
        private ControlManager.acBar bar2;
        private ControlManager.acBarButtonItem acBarButtonItem1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private ControlManager.acTreeList acTreeList1;
        private DevExpress.XtraBars.PopupMenu popupMenu1;
        private ControlManager.acBarButtonItem acBarButtonItem2;
        private ControlManager.acBarButtonItem acBarButtonItem3;
        private ControlManager.acBarButtonItem acBarButtonItem4;
        private ControlManager.acLayoutControl acLayoutControl1;
        private ControlManager.acCheckEdit acCheckEdit1;
        private ControlManager.acLabelControl acLabelControl1;
        private ControlManager.acLayoutControlGroup Root;
        private ControlManager.acLayoutControlItem acLayoutControlItem1;
        private ControlManager.acLayoutControlItem acLayoutControlItem2;
    }
}
