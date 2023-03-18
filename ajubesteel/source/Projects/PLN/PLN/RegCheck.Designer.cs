namespace PLN
{
    partial class RegCheck
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
			this.acLayoutControl4 = new ControlManager.acLayoutControl();
			this.acLabelControl1 = new ControlManager.acLabelControl();
			this.acGridControl1 = new ControlManager.acGridControl();
			this.acGridView1 = new ControlManager.acGridView();
			this.btnCancel = new ControlManager.acSimpleButton();
			this.btnSave = new ControlManager.acSimpleButton();
			this.acLayoutControlGroup5 = new ControlManager.acLayoutControlGroup();
			this.acLayoutControlItem2 = new ControlManager.acLayoutControlItem();
			this.acLayoutControlItem15 = new ControlManager.acLayoutControlItem();
			this.acLayoutControlItem1 = new ControlManager.acLayoutControlItem();
			this.acLayoutControlItem4 = new ControlManager.acLayoutControlItem();
			this.layoutControlGroup1 = new ControlManager.acLayoutControlGroup();
			this.acLayoutControlGroup3 = new ControlManager.acLayoutControlGroup();
			((System.ComponentModel.ISupportInitialize)(this.acLayoutControl4)).BeginInit();
			this.acLayoutControl4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.acGridControl1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.acGridView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.acLayoutControlGroup5)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem15)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem4)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.acLayoutControlGroup3)).BeginInit();
			this.SuspendLayout();
			// 
			// acLayoutControl4
			// 
			this.acLayoutControl4.AllowCustomizationMenu = false;
			this.acLayoutControl4.AutoScroll = false;
			this.acLayoutControl4.ContainerName = null;
			this.acLayoutControl4.Controls.Add(this.acLabelControl1);
			this.acLayoutControl4.Controls.Add(this.acGridControl1);
			this.acLayoutControl4.Controls.Add(this.btnCancel);
			this.acLayoutControl4.Controls.Add(this.btnSave);
			this.acLayoutControl4.Dock = System.Windows.Forms.DockStyle.Fill;
			this.acLayoutControl4.LayoutType = ControlManager.acLayoutControl.emLayoutType.NONE;
			this.acLayoutControl4.Location = new System.Drawing.Point(0, 0);
			this.acLayoutControl4.Name = "acLayoutControl4";
			this.acLayoutControl4.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(1121, 159, 250, 350);
			this.acLayoutControl4.OptionsView.DrawItemBorders = true;
			this.acLayoutControl4.ParentControl = null;
			this.acLayoutControl4.Root = this.acLayoutControlGroup5;
			this.acLayoutControl4.Size = new System.Drawing.Size(704, 406);
			this.acLayoutControl4.TabIndex = 1;
			this.acLayoutControl4.Text = "acLayoutControl4";
			// 
			// acLabelControl1
			// 
			this.acLabelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
			this.acLabelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.acLabelControl1.Location = new System.Drawing.Point(5, 5);
			this.acLabelControl1.Name = "acLabelControl1";
			this.acLabelControl1.ResourceID = null;
			this.acLabelControl1.Size = new System.Drawing.Size(477, 56);
			this.acLabelControl1.StyleController = this.acLayoutControl4;
			this.acLabelControl1.TabIndex = 9;
			this.acLabelControl1.ToolTipID = null;
			this.acLabelControl1.UseResourceID = false;
			this.acLabelControl1.UseToolTipID = false;
			// 
			// acGridControl1
			// 
			this.acGridControl1.Location = new System.Drawing.Point(5, 71);
			this.acGridControl1.MainView = this.acGridView1;
			this.acGridControl1.Name = "acGridControl1";
			this.acGridControl1.Size = new System.Drawing.Size(694, 330);
			this.acGridControl1.TabIndex = 7;
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
			this.acGridView1.OptionsBehavior.AutoPopulateColumns = false;
			this.acGridView1.OptionsLayout.Columns.StoreAllOptions = true;
			this.acGridView1.OptionsLayout.StoreAllOptions = true;
			this.acGridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
			this.acGridView1.OptionsView.RowAutoHeight = true;
			this.acGridView1.OptionsView.ShowGroupPanel = false;
			this.acGridView1.OptionsView.ShowIndicator = false;
			this.acGridView1.ParentControl = this;
			this.acGridView1.RowHeight = 30;
			this.acGridView1.SaveFileName = null;
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(605, 5);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.ResourceID = null;
			this.btnCancel.Size = new System.Drawing.Size(94, 56);
			this.btnCancel.StyleController = this.acLayoutControl4;
			this.btnCancel.TabIndex = 6;
			this.btnCancel.Text = "닫기";
			this.btnCancel.ToolTipID = null;
			this.btnCancel.UseResourceID = false;
			this.btnCancel.UseToolTipID = false;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnSave
			// 
			this.btnSave.Location = new System.Drawing.Point(492, 5);
			this.btnSave.Name = "btnSave";
			this.btnSave.ResourceID = null;
			this.btnSave.Size = new System.Drawing.Size(103, 56);
			this.btnSave.StyleController = this.acLayoutControl4;
			this.btnSave.TabIndex = 5;
			this.btnSave.Text = "저장";
			this.btnSave.ToolTipID = null;
			this.btnSave.UseResourceID = false;
			this.btnSave.UseToolTipID = false;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// acLayoutControlGroup5
			// 
			this.acLayoutControlGroup5.CustomizationFormText = "Root";
			this.acLayoutControlGroup5.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.False;
			this.acLayoutControlGroup5.GroupBordersVisible = false;
			this.acLayoutControlGroup5.IsHeader = false;
			this.acLayoutControlGroup5.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.acLayoutControlItem2,
            this.acLayoutControlItem15,
            this.acLayoutControlItem1,
            this.acLayoutControlItem4});
			this.acLayoutControlGroup5.Location = new System.Drawing.Point(0, 0);
			this.acLayoutControlGroup5.Name = "Root";
			this.acLayoutControlGroup5.ResourceID = null;
			this.acLayoutControlGroup5.Size = new System.Drawing.Size(704, 406);
			this.acLayoutControlGroup5.Text = "Root";
			this.acLayoutControlGroup5.TextVisible = false;
			this.acLayoutControlGroup5.ToolTipID = null;
			this.acLayoutControlGroup5.UseResourceID = false;
			this.acLayoutControlGroup5.UseToolTipID = false;
			// 
			// acLayoutControlItem2
			// 
			this.acLayoutControlItem2.Control = this.btnSave;
			this.acLayoutControlItem2.CustomizationFormText = "acLayoutControlItem2";
			this.acLayoutControlItem2.IsHeader = false;
			this.acLayoutControlItem2.IsTitle = false;
			this.acLayoutControlItem2.Location = new System.Drawing.Point(487, 0);
			this.acLayoutControlItem2.MinSize = new System.Drawing.Size(45, 32);
			this.acLayoutControlItem2.Name = "acLayoutControlItem2";
			this.acLayoutControlItem2.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
			this.acLayoutControlItem2.ResourceID = null;
			this.acLayoutControlItem2.Size = new System.Drawing.Size(113, 66);
			this.acLayoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
			this.acLayoutControlItem2.Text = "acLayoutControlItem2";
			this.acLayoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
			this.acLayoutControlItem2.TextVisible = false;
			this.acLayoutControlItem2.ToolTipID = null;
			this.acLayoutControlItem2.ToolTipStdCode = null;
			this.acLayoutControlItem2.UseResourceID = false;
			this.acLayoutControlItem2.UseToolTipID = false;
			// 
			// acLayoutControlItem15
			// 
			this.acLayoutControlItem15.Control = this.btnCancel;
			this.acLayoutControlItem15.CustomizationFormText = "acLayoutControlItem15";
			this.acLayoutControlItem15.IsHeader = false;
			this.acLayoutControlItem15.IsTitle = false;
			this.acLayoutControlItem15.Location = new System.Drawing.Point(600, 0);
			this.acLayoutControlItem15.MinSize = new System.Drawing.Size(45, 32);
			this.acLayoutControlItem15.Name = "acLayoutControlItem15";
			this.acLayoutControlItem15.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
			this.acLayoutControlItem15.ResourceID = null;
			this.acLayoutControlItem15.Size = new System.Drawing.Size(104, 66);
			this.acLayoutControlItem15.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
			this.acLayoutControlItem15.Text = "acLayoutControlItem15";
			this.acLayoutControlItem15.TextSize = new System.Drawing.Size(0, 0);
			this.acLayoutControlItem15.TextVisible = false;
			this.acLayoutControlItem15.ToolTipID = null;
			this.acLayoutControlItem15.ToolTipStdCode = null;
			this.acLayoutControlItem15.UseResourceID = false;
			this.acLayoutControlItem15.UseToolTipID = false;
			// 
			// acLayoutControlItem1
			// 
			this.acLayoutControlItem1.Control = this.acGridControl1;
			this.acLayoutControlItem1.CustomizationFormText = "acLayoutControlItem1";
			this.acLayoutControlItem1.IsHeader = false;
			this.acLayoutControlItem1.IsTitle = false;
			this.acLayoutControlItem1.Location = new System.Drawing.Point(0, 66);
			this.acLayoutControlItem1.Name = "acLayoutControlItem1";
			this.acLayoutControlItem1.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
			this.acLayoutControlItem1.ResourceID = null;
			this.acLayoutControlItem1.Size = new System.Drawing.Size(704, 340);
			this.acLayoutControlItem1.Text = "acLayoutControlItem1";
			this.acLayoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
			this.acLayoutControlItem1.TextVisible = false;
			this.acLayoutControlItem1.ToolTipID = null;
			this.acLayoutControlItem1.ToolTipStdCode = null;
			this.acLayoutControlItem1.UseResourceID = false;
			this.acLayoutControlItem1.UseToolTipID = false;
			// 
			// acLayoutControlItem4
			// 
			this.acLayoutControlItem4.Control = this.acLabelControl1;
			this.acLayoutControlItem4.CustomizationFormText = "acLayoutControlItem4";
			this.acLayoutControlItem4.IsHeader = false;
			this.acLayoutControlItem4.IsTitle = false;
			this.acLayoutControlItem4.Location = new System.Drawing.Point(0, 0);
			this.acLayoutControlItem4.MinSize = new System.Drawing.Size(96, 24);
			this.acLayoutControlItem4.Name = "acLayoutControlItem4";
			this.acLayoutControlItem4.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
			this.acLayoutControlItem4.ResourceID = null;
			this.acLayoutControlItem4.Size = new System.Drawing.Size(487, 66);
			this.acLayoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
			this.acLayoutControlItem4.Text = "acLayoutControlItem4";
			this.acLayoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
			this.acLayoutControlItem4.TextVisible = false;
			this.acLayoutControlItem4.ToolTipID = null;
			this.acLayoutControlItem4.ToolTipStdCode = null;
			this.acLayoutControlItem4.UseResourceID = false;
			this.acLayoutControlItem4.UseToolTipID = false;
			// 
			// layoutControlGroup1
			// 
			this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
			this.layoutControlGroup1.IsHeader = false;
			this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
			this.layoutControlGroup1.Name = "layoutControlGroup1";
			this.layoutControlGroup1.ResourceID = null;
			this.layoutControlGroup1.Size = new System.Drawing.Size(260, 382);
			this.layoutControlGroup1.Text = "layoutControlGroup1";
			this.layoutControlGroup1.TextVisible = false;
			this.layoutControlGroup1.ToolTipID = null;
			this.layoutControlGroup1.UseResourceID = false;
			this.layoutControlGroup1.UseToolTipID = false;
			// 
			// acLayoutControlGroup3
			// 
			this.acLayoutControlGroup3.CustomizationFormText = "layoutControlGroup1";
			this.acLayoutControlGroup3.IsHeader = false;
			this.acLayoutControlGroup3.Location = new System.Drawing.Point(0, 0);
			this.acLayoutControlGroup3.Name = "layoutControlGroup1";
			this.acLayoutControlGroup3.ResourceID = null;
			this.acLayoutControlGroup3.Size = new System.Drawing.Size(260, 382);
			this.acLayoutControlGroup3.Text = "layoutControlGroup1";
			this.acLayoutControlGroup3.TextVisible = false;
			this.acLayoutControlGroup3.ToolTipID = null;
			this.acLayoutControlGroup3.UseResourceID = false;
			this.acLayoutControlGroup3.UseToolTipID = false;
			// 
			// RegCheck
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
			this.ClientSize = new System.Drawing.Size(704, 406);
			this.Controls.Add(this.acLayoutControl4);
			this.Margin = new System.Windows.Forms.Padding(5);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "RegCheck";
			this.ResourceID = "";
			this.Text = "자주검사";
			((System.ComponentModel.ISupportInitialize)(this.acLayoutControl4)).EndInit();
			this.acLayoutControl4.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.acGridControl1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.acGridView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.acLayoutControlGroup5)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem15)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem4)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.acLayoutControlGroup3)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private ControlManager.acLayoutControlGroup layoutControlGroup1;
        private ControlManager.acLayoutControlGroup acLayoutControlGroup3;
        private ControlManager.acLayoutControl acLayoutControl4;
        private ControlManager.acLayoutControlGroup acLayoutControlGroup5;
        private ControlManager.acSimpleButton btnCancel;
        private ControlManager.acSimpleButton btnSave;
        private ControlManager.acLayoutControlItem acLayoutControlItem2;
        private ControlManager.acLayoutControlItem acLayoutControlItem15;
        private ControlManager.acGridControl acGridControl1;
        private ControlManager.acGridView acGridView1;
        private ControlManager.acLayoutControlItem acLayoutControlItem1;
        private ControlManager.acLabelControl acLabelControl1;
        private ControlManager.acLayoutControlItem acLayoutControlItem4;
	}
}
