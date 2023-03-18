namespace POP
{
    partial class ActLog
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
			this.acSplitContainerControl1 = new ControlManager.acSplitContainerControl();
			this.acLayoutControl1 = new ControlManager.acLayoutControl();
			this.TimeLabel = new ControlManager.acLabelControl();
			this.btnRight = new ControlManager.acSimpleButton();
			this.btnLeft = new ControlManager.acSimpleButton();
			this.btnOk = new ControlManager.acSimpleButton();
			this.acLayoutControlGroup1 = new ControlManager.acLayoutControlGroup();
			this.acLayoutControlItem1 = new ControlManager.acLayoutControlItem();
			this.acLayoutControlItem2 = new ControlManager.acLayoutControlItem();
			this.acLayoutControlItem3 = new ControlManager.acLayoutControlItem();
			this.acLayoutControlItem4 = new ControlManager.acLayoutControlItem();
			this.acGridControl1 = new ControlManager.acGridControl();
			this.acGridView1 = new ControlManager.acGridView();
			((System.ComponentModel.ISupportInitialize)(this.acSplitContainerControl1)).BeginInit();
			this.acSplitContainerControl1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.acLayoutControl1)).BeginInit();
			this.acLayoutControl1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.acLayoutControlGroup1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem4)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.acGridControl1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.acGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// acSplitContainerControl1
			// 
			this.acSplitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.acSplitContainerControl1.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.None;
			this.acSplitContainerControl1.Horizontal = false;
			this.acSplitContainerControl1.Location = new System.Drawing.Point(0, 0);
			this.acSplitContainerControl1.Name = "acSplitContainerControl1";
			this.acSplitContainerControl1.Panel1.Controls.Add(this.acLayoutControl1);
			this.acSplitContainerControl1.Panel1.Text = "Panel1";
			this.acSplitContainerControl1.Panel2.Controls.Add(this.acGridControl1);
			this.acSplitContainerControl1.Panel2.Text = "Panel2";
			this.acSplitContainerControl1.ParentControl = this;
			this.acSplitContainerControl1.Size = new System.Drawing.Size(1247, 549);
			this.acSplitContainerControl1.SplitterPosition = 88;
			this.acSplitContainerControl1.TabIndex = 0;
			this.acSplitContainerControl1.Text = "acSplitContainerControl1";
			// 
			// acLayoutControl1
			// 
			this.acLayoutControl1.AllowCustomizationMenu = false;
			this.acLayoutControl1.ContainerName = null;
			this.acLayoutControl1.Controls.Add(this.TimeLabel);
			this.acLayoutControl1.Controls.Add(this.btnRight);
			this.acLayoutControl1.Controls.Add(this.btnLeft);
			this.acLayoutControl1.Controls.Add(this.btnOk);
			this.acLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.acLayoutControl1.LayoutType = ControlManager.acLayoutControl.emLayoutType.NONE;
			this.acLayoutControl1.Location = new System.Drawing.Point(0, 0);
			this.acLayoutControl1.Name = "acLayoutControl1";
			this.acLayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(2083, -16, 250, 350);
			this.acLayoutControl1.ParentControl = null;
			this.acLayoutControl1.Root = this.acLayoutControlGroup1;
			this.acLayoutControl1.Size = new System.Drawing.Size(1247, 88);
			this.acLayoutControl1.TabIndex = 0;
			this.acLayoutControl1.Text = "acLayoutControl1";
			// 
			// TimeLabel
			// 
			this.TimeLabel.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.TimeLabel.Location = new System.Drawing.Point(115, 5);
			this.TimeLabel.Name = "TimeLabel";
			this.TimeLabel.ResourceID = null;
			this.TimeLabel.Size = new System.Drawing.Size(827, 78);
			this.TimeLabel.StyleController = this.acLayoutControl1;
			this.TimeLabel.TabIndex = 7;
			this.TimeLabel.Text = " ";
			this.TimeLabel.ToolTipID = null;
			this.TimeLabel.UseResourceID = false;
			this.TimeLabel.UseToolTipID = false;
			// 
			// btnRight
			// 
			this.btnRight.Location = new System.Drawing.Point(952, 5);
			this.btnRight.Name = "btnRight";
			this.btnRight.ResourceID = null;
			this.btnRight.Size = new System.Drawing.Size(99, 78);
			this.btnRight.StyleController = this.acLayoutControl1;
			this.btnRight.TabIndex = 6;
			this.btnRight.Text = "▶";
			this.btnRight.ToolTipID = null;
			this.btnRight.UseResourceID = false;
			this.btnRight.UseToolTipID = false;
			this.btnRight.Click += new System.EventHandler(this.btnRight_Click);
			// 
			// btnLeft
			// 
			this.btnLeft.Location = new System.Drawing.Point(5, 5);
			this.btnLeft.Name = "btnLeft";
			this.btnLeft.ResourceID = null;
			this.btnLeft.Size = new System.Drawing.Size(100, 78);
			this.btnLeft.StyleController = this.acLayoutControl1;
			this.btnLeft.TabIndex = 5;
			this.btnLeft.Text = "◀";
			this.btnLeft.ToolTipID = null;
			this.btnLeft.UseResourceID = false;
			this.btnLeft.UseToolTipID = false;
			this.btnLeft.Click += new System.EventHandler(this.btnLeft_Click);
			// 
			// btnOk
			// 
			this.btnOk.Location = new System.Drawing.Point(1061, 5);
			this.btnOk.Name = "btnOk";
			this.btnOk.ResourceID = null;
			this.btnOk.Size = new System.Drawing.Size(181, 78);
			this.btnOk.StyleController = this.acLayoutControl1;
			this.btnOk.TabIndex = 4;
			this.btnOk.Text = "닫기";
			this.btnOk.ToolTipID = null;
			this.btnOk.UseResourceID = false;
			this.btnOk.UseToolTipID = false;
			this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
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
			this.acLayoutControlGroup1.Location = new System.Drawing.Point(0, 0);
			this.acLayoutControlGroup1.Name = "Root";
			this.acLayoutControlGroup1.ResourceID = null;
			this.acLayoutControlGroup1.Size = new System.Drawing.Size(1247, 88);
			this.acLayoutControlGroup1.Text = "Root";
			this.acLayoutControlGroup1.TextVisible = false;
			this.acLayoutControlGroup1.ToolTipID = null;
			this.acLayoutControlGroup1.UseResourceID = false;
			this.acLayoutControlGroup1.UseToolTipID = false;
			// 
			// acLayoutControlItem1
			// 
			this.acLayoutControlItem1.Control = this.btnOk;
			this.acLayoutControlItem1.CustomizationFormText = "acLayoutControlItem1";
			this.acLayoutControlItem1.IsHeader = false;
			this.acLayoutControlItem1.IsTitle = false;
			this.acLayoutControlItem1.Location = new System.Drawing.Point(1056, 0);
			this.acLayoutControlItem1.MinSize = new System.Drawing.Size(45, 32);
			this.acLayoutControlItem1.Name = "acLayoutControlItem1";
			this.acLayoutControlItem1.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
			this.acLayoutControlItem1.ResourceID = null;
			this.acLayoutControlItem1.Size = new System.Drawing.Size(191, 88);
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
			this.acLayoutControlItem2.Control = this.btnLeft;
			this.acLayoutControlItem2.CustomizationFormText = "acLayoutControlItem2";
			this.acLayoutControlItem2.IsHeader = false;
			this.acLayoutControlItem2.IsTitle = false;
			this.acLayoutControlItem2.Location = new System.Drawing.Point(0, 0);
			this.acLayoutControlItem2.MinSize = new System.Drawing.Size(45, 32);
			this.acLayoutControlItem2.Name = "acLayoutControlItem2";
			this.acLayoutControlItem2.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
			this.acLayoutControlItem2.ResourceID = null;
			this.acLayoutControlItem2.Size = new System.Drawing.Size(110, 88);
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
			this.acLayoutControlItem3.Control = this.btnRight;
			this.acLayoutControlItem3.CustomizationFormText = "acLayoutControlItem3";
			this.acLayoutControlItem3.IsHeader = false;
			this.acLayoutControlItem3.IsTitle = false;
			this.acLayoutControlItem3.Location = new System.Drawing.Point(947, 0);
			this.acLayoutControlItem3.MinSize = new System.Drawing.Size(45, 32);
			this.acLayoutControlItem3.Name = "acLayoutControlItem3";
			this.acLayoutControlItem3.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
			this.acLayoutControlItem3.ResourceID = null;
			this.acLayoutControlItem3.Size = new System.Drawing.Size(109, 88);
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
			this.acLayoutControlItem4.Control = this.TimeLabel;
			this.acLayoutControlItem4.CustomizationFormText = "acLayoutControlItem4";
			this.acLayoutControlItem4.IsHeader = false;
			this.acLayoutControlItem4.IsTitle = false;
			this.acLayoutControlItem4.Location = new System.Drawing.Point(110, 0);
			this.acLayoutControlItem4.MinSize = new System.Drawing.Size(96, 24);
			this.acLayoutControlItem4.Name = "acLayoutControlItem4";
			this.acLayoutControlItem4.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
			this.acLayoutControlItem4.ResourceID = null;
			this.acLayoutControlItem4.Size = new System.Drawing.Size(837, 88);
			this.acLayoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
			this.acLayoutControlItem4.Text = "acLayoutControlItem4";
			this.acLayoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
			this.acLayoutControlItem4.TextVisible = false;
			this.acLayoutControlItem4.ToolTipID = null;
			this.acLayoutControlItem4.ToolTipStdCode = null;
			this.acLayoutControlItem4.UseResourceID = false;
			this.acLayoutControlItem4.UseToolTipID = false;
			// 
			// acGridControl1
			// 
			this.acGridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.acGridControl1.Location = new System.Drawing.Point(0, 0);
			this.acGridControl1.MainView = this.acGridView1;
			this.acGridControl1.Name = "acGridControl1";
			this.acGridControl1.Size = new System.Drawing.Size(1247, 456);
			this.acGridControl1.TabIndex = 0;
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
			this.acGridView1.OptionsView.RowAutoHeight = true;
			this.acGridView1.OptionsView.ShowGroupPanel = false;
			this.acGridView1.OptionsView.ShowIndicator = false;
			this.acGridView1.ParentControl = this;
			this.acGridView1.RowHeight = 30;
			this.acGridView1.SaveFileName = null;
			// 
			// ActLog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
			this.ClientSize = new System.Drawing.Size(1247, 549);
			this.Controls.Add(this.acSplitContainerControl1);
			this.Margin = new System.Windows.Forms.Padding(5);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ActLog";
			this.ResourceID = "";
			this.Text = "수작업 내역";
			((System.ComponentModel.ISupportInitialize)(this.acSplitContainerControl1)).EndInit();
			this.acSplitContainerControl1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.acLayoutControl1)).EndInit();
			this.acLayoutControl1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.acLayoutControlGroup1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem4)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.acGridControl1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.acGridView1)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private ControlManager.acSplitContainerControl acSplitContainerControl1;
        private ControlManager.acLayoutControl acLayoutControl1;
        private ControlManager.acSimpleButton btnOk;
        private ControlManager.acLayoutControlGroup acLayoutControlGroup1;
        private ControlManager.acLayoutControlItem acLayoutControlItem1;
        private ControlManager.acGridControl acGridControl1;
        private ControlManager.acGridView acGridView1;
        private ControlManager.acSimpleButton btnRight;
        private ControlManager.acSimpleButton btnLeft;
        private ControlManager.acLayoutControlItem acLayoutControlItem2;
        private ControlManager.acLayoutControlItem acLayoutControlItem3;
        private ControlManager.acLabelControl TimeLabel;
        private ControlManager.acLayoutControlItem acLayoutControlItem4;






    }
}
