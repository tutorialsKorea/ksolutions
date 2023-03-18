namespace POP
{
    partial class ChangeEmp
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
            this.acSplitContainerControl1 = new ControlManager.acSplitContainerControl();
            this.acTreeList1 = new ControlManager.acTreeList();
            this.gcEmployee = new ControlManager.acGridControl();
            this.gvEmployee = new ControlManager.acGridView();
            this.acBarManager1 = new ControlManager.acBarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.acBarButtonItem1 = new ControlManager.acBarButtonItem();
            this.barItemSearch = new ControlManager.acBarButtonItem();
            this.statusBarLog = new ControlManager.acBarStaticItem();
            this.acLayoutControl2 = new ControlManager.acLayoutControl();
            this.btnCancel = new ControlManager.acSimpleButton();
            this.btnOk = new ControlManager.acSimpleButton();
            this.txtPartCode = new ControlManager.acTextEdit();
            this.acLayoutControlGroup1 = new ControlManager.acLayoutControlGroup();
            this.acLayoutControlItem1 = new ControlManager.acLayoutControlItem();
            this.acLayoutControlItem2 = new ControlManager.acLayoutControlItem();
            this.acLayoutControlItem3 = new ControlManager.acLayoutControlItem();
            this.acLayoutControlItem4 = new ControlManager.acLayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.acSplitContainerControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acSplitContainerControl1.Panel1)).BeginInit();
            this.acSplitContainerControl1.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.acSplitContainerControl1.Panel2)).BeginInit();
            this.acSplitContainerControl1.Panel2.SuspendLayout();
            this.acSplitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.acTreeList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcEmployee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvEmployee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acBarManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControl2)).BeginInit();
            this.acLayoutControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPartCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem4)).BeginInit();
            this.SuspendLayout();
            // 
            // acSplitContainerControl1
            // 
            this.acSplitContainerControl1.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.None;
            this.acSplitContainerControl1.Location = new System.Drawing.Point(5, 70);
            this.acSplitContainerControl1.Margin = new System.Windows.Forms.Padding(0);
            this.acSplitContainerControl1.Name = "acSplitContainerControl1";
            // 
            // acSplitContainerControl1.Panel1
            // 
            this.acSplitContainerControl1.Panel1.Controls.Add(this.acTreeList1);
            this.acSplitContainerControl1.Panel1.Text = "Panel1";
            // 
            // acSplitContainerControl1.Panel2
            // 
            this.acSplitContainerControl1.Panel2.Controls.Add(this.gcEmployee);
            this.acSplitContainerControl1.Panel2.Text = "Panel2";
            this.acSplitContainerControl1.ParentControl = null;
            this.acSplitContainerControl1.Size = new System.Drawing.Size(603, 363);
            this.acSplitContainerControl1.SplitterPosition = 212;
            this.acSplitContainerControl1.TabIndex = 0;
            this.acSplitContainerControl1.Text = "acSplitContainerControl1";
            // 
            // acTreeList1
            // 
            this.acTreeList1.ColumnPanelRowHeight = 30;
            this.acTreeList1.DataSource = null;
            this.acTreeList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.acTreeList1.Font = new System.Drawing.Font("맑은 고딕", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.acTreeList1.IndicatorWidth = 30;
            this.acTreeList1.KeyFieldName = "ORG_CODE";
            this.acTreeList1.Location = new System.Drawing.Point(0, 0);
            this.acTreeList1.Margin = new System.Windows.Forms.Padding(0);
            this.acTreeList1.Name = "acTreeList1";
            this.acTreeList1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.acTreeList1.OptionsView.ShowColumns = false;
            this.acTreeList1.OptionsView.ShowIndicator = false;
            this.acTreeList1.ParentControl = this;
            this.acTreeList1.ParentFieldName = "ORG_PARENT";
            this.acTreeList1.RowHeight = 30;
            this.acTreeList1.SaveFileName = null;
            this.acTreeList1.Size = new System.Drawing.Size(212, 363);
            this.acTreeList1.TabIndex = 5;
            // 
            // gcEmployee
            // 
            this.gcEmployee.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcEmployee.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(0);
            this.gcEmployee.Font = new System.Drawing.Font("맑은 고딕", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.gcEmployee.Location = new System.Drawing.Point(0, 0);
            this.gcEmployee.MainView = this.gvEmployee;
            this.gcEmployee.Margin = new System.Windows.Forms.Padding(0);
            this.gcEmployee.Name = "gcEmployee";
            this.gcEmployee.Size = new System.Drawing.Size(381, 363);
            this.gcEmployee.TabIndex = 6;
            this.gcEmployee.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvEmployee});
            // 
            // gvEmployee
            // 
            this.gvEmployee.ColumnPanelRowHeight = 25;
            this.gvEmployee.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gvEmployee.GridControl = this.gcEmployee;
            this.gvEmployee.IsUserStyle = false;
            this.gvEmployee.Name = "gvEmployee";
            this.gvEmployee.NoApplyEditableCellColor = false;
            this.gvEmployee.OptionsBehavior.AutoPopulateColumns = false;
            this.gvEmployee.OptionsLayout.Columns.StoreAllOptions = true;
            this.gvEmployee.OptionsLayout.StoreAllOptions = true;
            this.gvEmployee.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gvEmployee.OptionsSelection.MultiSelect = true;
            this.gvEmployee.OptionsView.ColumnAutoWidth = false;
            this.gvEmployee.OptionsView.RowAutoHeight = true;
            this.gvEmployee.OptionsView.ShowGroupPanel = false;
            this.gvEmployee.OptionsView.ShowIndicator = false;
            this.gvEmployee.ParentControl = this;
            this.gvEmployee.RowHeight = 30;
            this.gvEmployee.SaveFileName = null;
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
            this.acBarButtonItem1,
            this.barItemSearch,
            this.statusBarLog});
            this.acBarManager1.MaxItemId = 3;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.acBarManager1;
            this.barDockControlTop.Margin = new System.Windows.Forms.Padding(0);
            this.barDockControlTop.Size = new System.Drawing.Size(613, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 438);
            this.barDockControlBottom.Manager = this.acBarManager1;
            this.barDockControlBottom.Margin = new System.Windows.Forms.Padding(0);
            this.barDockControlBottom.Size = new System.Drawing.Size(613, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Manager = this.acBarManager1;
            this.barDockControlLeft.Margin = new System.Windows.Forms.Padding(0);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 438);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(613, 0);
            this.barDockControlRight.Manager = this.acBarManager1;
            this.barDockControlRight.Margin = new System.Windows.Forms.Padding(0);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 438);
            // 
            // acBarButtonItem1
            // 
            this.acBarButtonItem1.ButtonShortCutType = ControlManager.acBarManager.emBarShortCutType.SELECT;
            this.acBarButtonItem1.Caption = "acBarButtonItem1";
            this.acBarButtonItem1.Id = 0;
            this.acBarButtonItem1.Name = "acBarButtonItem1";
            this.acBarButtonItem1.ResourceID = null;
            this.acBarButtonItem1.ToolTipID = "E5QTF4L5";
            this.acBarButtonItem1.UseResourceID = false;
            this.acBarButtonItem1.UseToolTipID = true;
            // 
            // barItemSearch
            // 
            this.barItemSearch.ButtonShortCutType = ControlManager.acBarManager.emBarShortCutType.SEARCH;
            this.barItemSearch.Caption = "acBarButtonItem2";
            this.barItemSearch.Id = 1;
            this.barItemSearch.ImageOptions.Image = global::POP.Resource.system_search_2x;
            this.barItemSearch.Name = "barItemSearch";
            this.barItemSearch.ResourceID = null;
            this.barItemSearch.ToolTipID = "1UMVQFSB";
            this.barItemSearch.UseResourceID = false;
            this.barItemSearch.UseToolTipID = true;
            this.barItemSearch.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barItemSearch_ItemClick);
            // 
            // statusBarLog
            // 
            this.statusBarLog.Border = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.statusBarLog.Id = 2;
            this.statusBarLog.Name = "statusBarLog";
            this.statusBarLog.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.statusBarLog.ResourceID = null;
            this.statusBarLog.ToolTipID = null;
            this.statusBarLog.UseResourceID = false;
            this.statusBarLog.UseToolTipID = false;
            // 
            // acLayoutControl2
            // 
            this.acLayoutControl2.AllowCustomization = false;
            this.acLayoutControl2.ContainerName = null;
            this.acLayoutControl2.Controls.Add(this.acSplitContainerControl1);
            this.acLayoutControl2.Controls.Add(this.btnCancel);
            this.acLayoutControl2.Controls.Add(this.btnOk);
            this.acLayoutControl2.Controls.Add(this.txtPartCode);
            this.acLayoutControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.acLayoutControl2.LayoutType = ControlManager.acLayoutControl.emLayoutType.NONE;
            this.acLayoutControl2.Location = new System.Drawing.Point(0, 0);
            this.acLayoutControl2.Margin = new System.Windows.Forms.Padding(0);
            this.acLayoutControl2.Name = "acLayoutControl2";
            this.acLayoutControl2.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(1857, -33, 250, 350);
            this.acLayoutControl2.ParentControl = null;
            this.acLayoutControl2.Root = this.acLayoutControlGroup1;
            this.acLayoutControl2.Size = new System.Drawing.Size(613, 438);
            this.acLayoutControl2.TabIndex = 10;
            this.acLayoutControl2.Text = "acLayoutControl2";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(502, 5);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(0);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.ResourceID = null;
            this.btnCancel.Size = new System.Drawing.Size(106, 55);
            this.btnCancel.StyleController = this.acLayoutControl2;
            this.btnCancel.TabIndex = 14;
            this.btnCancel.Text = "닫기";
            this.btnCancel.ToolTipID = null;
            this.btnCancel.UseResourceID = false;
            this.btnCancel.UseToolTipID = false;
            this.btnCancel.Click += new System.EventHandler(this.acSimpleButton2_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(386, 5);
            this.btnOk.Margin = new System.Windows.Forms.Padding(0);
            this.btnOk.Name = "btnOk";
            this.btnOk.ResourceID = null;
            this.btnOk.Size = new System.Drawing.Size(106, 55);
            this.btnOk.StyleController = this.acLayoutControl2;
            this.btnOk.TabIndex = 13;
            this.btnOk.Text = "확인";
            this.btnOk.ToolTipID = null;
            this.btnOk.UseResourceID = false;
            this.btnOk.UseToolTipID = false;
            this.btnOk.Click += new System.EventHandler(this.acSimpleButton1_Click);
            // 
            // txtPartCode
            // 
            this.txtPartCode.ColumnName = "EMP_LIKE";
            this.txtPartCode.Location = new System.Drawing.Point(101, 5);
            this.txtPartCode.Margin = new System.Windows.Forms.Padding(0);
            this.txtPartCode.MaskType = ControlManager.acTextEdit.emMaskType.NONE;
            this.txtPartCode.Name = "txtPartCode";
            this.txtPartCode.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtPartCode.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 15F);
            this.txtPartCode.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.txtPartCode.Properties.Appearance.Options.UseBackColor = true;
            this.txtPartCode.Properties.Appearance.Options.UseFont = true;
            this.txtPartCode.Properties.Appearance.Options.UseForeColor = true;
            this.txtPartCode.Properties.AutoHeight = false;
            this.txtPartCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txtPartCode.Size = new System.Drawing.Size(275, 55);
            this.txtPartCode.StyleController = this.acLayoutControl2;
            this.txtPartCode.TabIndex = 12;
            // 
            // acLayoutControlGroup1
            // 
            this.acLayoutControlGroup1.CustomizationFormText = "Root";
            this.acLayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.False;
            this.acLayoutControlGroup1.GroupBordersVisible = false;
            this.acLayoutControlGroup1.IsHeader = false;
            this.acLayoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.acLayoutControlItem1,
            this.acLayoutControlItem2,
            this.acLayoutControlItem3,
            this.acLayoutControlItem4});
            this.acLayoutControlGroup1.Name = "Root";
            this.acLayoutControlGroup1.ResourceID = null;
            this.acLayoutControlGroup1.Size = new System.Drawing.Size(613, 438);
            this.acLayoutControlGroup1.TextVisible = false;
            this.acLayoutControlGroup1.ToolTipID = null;
            this.acLayoutControlGroup1.UseResourceID = false;
            this.acLayoutControlGroup1.UseToolTipID = false;
            // 
            // acLayoutControlItem1
            // 
            this.acLayoutControlItem1.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.acLayoutControlItem1.AppearanceItemCaption.Options.UseFont = true;
            this.acLayoutControlItem1.Control = this.txtPartCode;
            this.acLayoutControlItem1.CustomizationFormText = "작업자코드/명";
            this.acLayoutControlItem1.IsHeader = false;
            this.acLayoutControlItem1.IsTitle = false;
            this.acLayoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.acLayoutControlItem1.Name = "acLayoutControlItem1";
            this.acLayoutControlItem1.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.acLayoutControlItem1.ResourceID = null;
            this.acLayoutControlItem1.Size = new System.Drawing.Size(381, 65);
            this.acLayoutControlItem1.Text = "작업자코드/명";
            this.acLayoutControlItem1.TextSize = new System.Drawing.Size(84, 18);
            this.acLayoutControlItem1.ToolTipID = null;
            this.acLayoutControlItem1.ToolTipStdCode = null;
            this.acLayoutControlItem1.UseResourceID = false;
            this.acLayoutControlItem1.UseToolTipID = false;
            // 
            // acLayoutControlItem2
            // 
            this.acLayoutControlItem2.Control = this.btnOk;
            this.acLayoutControlItem2.CustomizationFormText = "acLayoutControlItem2";
            this.acLayoutControlItem2.IsHeader = false;
            this.acLayoutControlItem2.IsTitle = false;
            this.acLayoutControlItem2.Location = new System.Drawing.Point(381, 0);
            this.acLayoutControlItem2.MaxSize = new System.Drawing.Size(116, 65);
            this.acLayoutControlItem2.MinSize = new System.Drawing.Size(116, 65);
            this.acLayoutControlItem2.Name = "acLayoutControlItem2";
            this.acLayoutControlItem2.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.acLayoutControlItem2.ResourceID = null;
            this.acLayoutControlItem2.Size = new System.Drawing.Size(116, 65);
            this.acLayoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.acLayoutControlItem2.Text = "acLayoutControlItem2";
            this.acLayoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.acLayoutControlItem2.TextVisible = false;
            this.acLayoutControlItem2.ToolTipID = null;
            this.acLayoutControlItem2.ToolTipStdCode = null;
            this.acLayoutControlItem2.UseResourceID = false;
            this.acLayoutControlItem2.UseToolTipID = false;
            // 
            // acLayoutControlItem3
            // 
            this.acLayoutControlItem3.Control = this.btnCancel;
            this.acLayoutControlItem3.CustomizationFormText = "acLayoutControlItem3";
            this.acLayoutControlItem3.IsHeader = false;
            this.acLayoutControlItem3.IsTitle = false;
            this.acLayoutControlItem3.Location = new System.Drawing.Point(497, 0);
            this.acLayoutControlItem3.MaxSize = new System.Drawing.Size(116, 65);
            this.acLayoutControlItem3.MinSize = new System.Drawing.Size(116, 65);
            this.acLayoutControlItem3.Name = "acLayoutControlItem3";
            this.acLayoutControlItem3.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.acLayoutControlItem3.ResourceID = null;
            this.acLayoutControlItem3.Size = new System.Drawing.Size(116, 65);
            this.acLayoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.acLayoutControlItem3.Text = "acLayoutControlItem3";
            this.acLayoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.acLayoutControlItem3.TextVisible = false;
            this.acLayoutControlItem3.ToolTipID = null;
            this.acLayoutControlItem3.ToolTipStdCode = null;
            this.acLayoutControlItem3.UseResourceID = false;
            this.acLayoutControlItem3.UseToolTipID = false;
            // 
            // acLayoutControlItem4
            // 
            this.acLayoutControlItem4.Control = this.acSplitContainerControl1;
            this.acLayoutControlItem4.CustomizationFormText = "acLayoutControlItem4";
            this.acLayoutControlItem4.IsHeader = false;
            this.acLayoutControlItem4.IsTitle = false;
            this.acLayoutControlItem4.Location = new System.Drawing.Point(0, 65);
            this.acLayoutControlItem4.Name = "acLayoutControlItem4";
            this.acLayoutControlItem4.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.acLayoutControlItem4.ResourceID = null;
            this.acLayoutControlItem4.Size = new System.Drawing.Size(613, 373);
            this.acLayoutControlItem4.Text = "acLayoutControlItem4";
            this.acLayoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.acLayoutControlItem4.TextVisible = false;
            this.acLayoutControlItem4.ToolTipID = null;
            this.acLayoutControlItem4.ToolTipStdCode = null;
            this.acLayoutControlItem4.UseResourceID = false;
            this.acLayoutControlItem4.UseToolTipID = false;
            // 
            // ChangeEmp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(613, 438);
            this.Controls.Add(this.acLayoutControl2);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.IconOptions.ShowIcon = false;
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ChangeEmp";
            this.ResourceID = "UZ194X3W";
            this.Text = "사원찾기";
            this.UseResourceID = true;
            ((System.ComponentModel.ISupportInitialize)(this.acSplitContainerControl1.Panel1)).EndInit();
            this.acSplitContainerControl1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.acSplitContainerControl1.Panel2)).EndInit();
            this.acSplitContainerControl1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.acSplitContainerControl1)).EndInit();
            this.acSplitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.acTreeList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcEmployee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvEmployee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acBarManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControl2)).EndInit();
            this.acLayoutControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtPartCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ControlManager.acSplitContainerControl acSplitContainerControl1;
        private ControlManager.acGridControl gcEmployee;
        private ControlManager.acGridView gvEmployee;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private ControlManager.acBarManager acBarManager1;
        private ControlManager.acBarButtonItem acBarButtonItem1;
        private ControlManager.acBarButtonItem barItemSearch;
        private ControlManager.acBarStaticItem statusBarLog;
        private ControlManager.acTreeList acTreeList1;
        private ControlManager.acLayoutControl acLayoutControl2;
        private ControlManager.acSimpleButton btnCancel;
        private ControlManager.acSimpleButton btnOk;
        private ControlManager.acLayoutControlGroup acLayoutControlGroup1;
        private ControlManager.acLayoutControlItem acLayoutControlItem2;
        private ControlManager.acLayoutControlItem acLayoutControlItem3;
        private ControlManager.acLayoutControlItem acLayoutControlItem4;
        private ControlManager.acTextEdit txtPartCode;
        private ControlManager.acLayoutControlItem acLayoutControlItem1;
    }
}