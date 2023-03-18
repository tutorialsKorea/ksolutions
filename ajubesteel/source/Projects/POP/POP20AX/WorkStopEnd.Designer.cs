namespace POP
{
    partial class WorkStopEnd
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
            this.btnCancel = new ControlManager.acSimpleButton();
            this.btnOk = new ControlManager.acSimpleButton();
            this.acLayoutControlGroup2 = new ControlManager.acLayoutControlGroup();
            this.acLayoutControlItem1 = new ControlManager.acLayoutControlItem();
            this.acLayoutControlItem2 = new ControlManager.acLayoutControlItem();
            this.acLayoutControl2 = new ControlManager.acLayoutControl();
            this.acTextEdit1 = new ControlManager.acTextEdit();
            this.acGridControl2 = new ControlManager.acGridControl();
            this.acGridView2 = new ControlManager.acGridView();
            this.acLayoutControlGroup1 = new ControlManager.acLayoutControlGroup();
            this.acLayoutControlItem4 = new ControlManager.acLayoutControlItem();
            this.acLayoutControlItem5 = new ControlManager.acLayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.acSplitContainerControl1)).BeginInit();
            this.acSplitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControl1)).BeginInit();
            this.acLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControl2)).BeginInit();
            this.acLayoutControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.acTextEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acGridControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem5)).BeginInit();
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
            this.acSplitContainerControl1.Panel2.Controls.Add(this.acLayoutControl2);
            this.acSplitContainerControl1.Panel2.Text = "Panel2";
            this.acSplitContainerControl1.ParentControl = this;
            this.acSplitContainerControl1.Size = new System.Drawing.Size(378, 466);
            this.acSplitContainerControl1.SplitterPosition = 57;
            this.acSplitContainerControl1.TabIndex = 10;
            this.acSplitContainerControl1.Text = "acSplitContainerControl1";
            // 
            // acLayoutControl1
            // 
            this.acLayoutControl1.AllowCustomizationMenu = false;
            this.acLayoutControl1.ContainerName = null;
            this.acLayoutControl1.Controls.Add(this.btnCancel);
            this.acLayoutControl1.Controls.Add(this.btnOk);
            this.acLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.acLayoutControl1.LayoutType = ControlManager.acLayoutControl.emLayoutType.NONE;
            this.acLayoutControl1.Location = new System.Drawing.Point(0, 0);
            this.acLayoutControl1.Name = "acLayoutControl1";
            this.acLayoutControl1.ParentControl = null;
            this.acLayoutControl1.Root = this.acLayoutControlGroup2;
            this.acLayoutControl1.Size = new System.Drawing.Size(378, 57);
            this.acLayoutControl1.TabIndex = 0;
            this.acLayoutControl1.Text = "acLayoutControl1";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(193, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.ResourceID = null;
            this.btnCancel.Size = new System.Drawing.Size(180, 47);
            this.btnCancel.StyleController = this.acLayoutControl1;
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "닫기";
            this.btnCancel.ToolTipID = null;
            this.btnCancel.UseResourceID = false;
            this.btnCancel.UseToolTipID = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(5, 5);
            this.btnOk.Name = "btnOk";
            this.btnOk.ResourceID = null;
            this.btnOk.Size = new System.Drawing.Size(178, 47);
            this.btnOk.StyleController = this.acLayoutControl1;
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "확인";
            this.btnOk.ToolTipID = null;
            this.btnOk.UseResourceID = false;
            this.btnOk.UseToolTipID = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // acLayoutControlGroup2
            // 
            this.acLayoutControlGroup2.CustomizationFormText = "acLayoutControlGroup2";
            this.acLayoutControlGroup2.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.False;
            this.acLayoutControlGroup2.GroupBordersVisible = false;
            this.acLayoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.acLayoutControlItem1,
            this.acLayoutControlItem2});
            this.acLayoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.acLayoutControlGroup2.Name = "acLayoutControlGroup2";
            this.acLayoutControlGroup2.ResourceID = null;
            this.acLayoutControlGroup2.Size = new System.Drawing.Size(378, 57);
            this.acLayoutControlGroup2.Text = "acLayoutControlGroup2";
            this.acLayoutControlGroup2.TextVisible = false;
            this.acLayoutControlGroup2.ToolTipID = null;
            this.acLayoutControlGroup2.UseResourceID = false;
            this.acLayoutControlGroup2.UseToolTipID = false;
            // 
            // acLayoutControlItem1
            // 
            this.acLayoutControlItem1.Control = this.btnOk;
            this.acLayoutControlItem1.CustomizationFormText = "acLayoutControlItem1";
            this.acLayoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.acLayoutControlItem1.MinSize = new System.Drawing.Size(1, 1);
            this.acLayoutControlItem1.Name = "acLayoutControlItem1";
            this.acLayoutControlItem1.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.acLayoutControlItem1.ResourceID = null;
            this.acLayoutControlItem1.Size = new System.Drawing.Size(188, 57);
            this.acLayoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.acLayoutControlItem1.Text = "acLayoutControlItem1";
            this.acLayoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.acLayoutControlItem1.TextToControlDistance = 0;
            this.acLayoutControlItem1.TextVisible = false;
            this.acLayoutControlItem1.ToolTipID = null;
            this.acLayoutControlItem1.UseResourceID = false;
            this.acLayoutControlItem1.UseToolTipID = false;
            // 
            // acLayoutControlItem2
            // 
            this.acLayoutControlItem2.Control = this.btnCancel;
            this.acLayoutControlItem2.CustomizationFormText = "acLayoutControlItem2";
            this.acLayoutControlItem2.Location = new System.Drawing.Point(188, 0);
            this.acLayoutControlItem2.MinSize = new System.Drawing.Size(1, 1);
            this.acLayoutControlItem2.Name = "acLayoutControlItem2";
            this.acLayoutControlItem2.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.acLayoutControlItem2.ResourceID = null;
            this.acLayoutControlItem2.Size = new System.Drawing.Size(190, 57);
            this.acLayoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.acLayoutControlItem2.Text = "acLayoutControlItem2";
            this.acLayoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.acLayoutControlItem2.TextToControlDistance = 0;
            this.acLayoutControlItem2.TextVisible = false;
            this.acLayoutControlItem2.ToolTipID = null;
            this.acLayoutControlItem2.UseResourceID = false;
            this.acLayoutControlItem2.UseToolTipID = false;
            // 
            // acLayoutControl2
            // 
            this.acLayoutControl2.AllowCustomizationMenu = false;
            this.acLayoutControl2.AutoScroll = false;
            this.acLayoutControl2.ContainerName = null;
            this.acLayoutControl2.Controls.Add(this.acTextEdit1);
            this.acLayoutControl2.Controls.Add(this.acGridControl2);
            this.acLayoutControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.acLayoutControl2.LayoutType = ControlManager.acLayoutControl.emLayoutType.NONE;
            this.acLayoutControl2.Location = new System.Drawing.Point(0, 0);
            this.acLayoutControl2.Name = "acLayoutControl2";
            this.acLayoutControl2.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(2218, 16, 250, 350);
            this.acLayoutControl2.OptionsView.DrawItemBorders = true;
            this.acLayoutControl2.ParentControl = null;
            this.acLayoutControl2.Root = this.acLayoutControlGroup1;
            this.acLayoutControl2.Size = new System.Drawing.Size(378, 404);
            this.acLayoutControl2.TabIndex = 0;
            this.acLayoutControl2.Text = "acLayoutControl2";
            // 
            // acTextEdit1
            // 
            this.acTextEdit1.ColumnName = "IDLE_TIME";
            this.acTextEdit1.isReadyOnly = true;
            this.acTextEdit1.Location = new System.Drawing.Point(62, 5);
            this.acTextEdit1.MaskType = ControlManager.acTextEdit.emMaskType.NONE;
            this.acTextEdit1.Name = "acTextEdit1";
            this.acTextEdit1.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.acTextEdit1.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 15F);
            this.acTextEdit1.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.acTextEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.acTextEdit1.Properties.Appearance.Options.UseFont = true;
            this.acTextEdit1.Properties.Appearance.Options.UseForeColor = true;
            this.acTextEdit1.Properties.Appearance.Options.UseTextOptions = true;
            this.acTextEdit1.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.acTextEdit1.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.WhiteSmoke;
            this.acTextEdit1.Properties.AppearanceReadOnly.ForeColor = System.Drawing.Color.Black;
            this.acTextEdit1.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.acTextEdit1.Properties.AppearanceReadOnly.Options.UseForeColor = true;
            this.acTextEdit1.Properties.AutoHeight = false;
            this.acTextEdit1.Properties.ReadOnly = true;
            this.acTextEdit1.Size = new System.Drawing.Size(311, 52);
            this.acTextEdit1.StyleController = this.acLayoutControl2;
            this.acTextEdit1.TabIndex = 6;
            // 
            // acGridControl2
            // 
            this.acGridControl2.Location = new System.Drawing.Point(5, 67);
            this.acGridControl2.MainView = this.acGridView2;
            this.acGridControl2.Name = "acGridControl2";
            this.acGridControl2.Size = new System.Drawing.Size(368, 332);
            this.acGridControl2.TabIndex = 5;
            this.acGridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.acGridView2});
            // 
            // acGridView2
            // 
            this.acGridView2.ColumnPanelRowHeight = 30;
            this.acGridView2.GridControl = this.acGridControl2;
            this.acGridView2.Name = "acGridView2";
            this.acGridView2.OptionsBehavior.AutoPopulateColumns = false;
            this.acGridView2.OptionsLayout.Columns.StoreAllOptions = true;
            this.acGridView2.OptionsLayout.StoreAllOptions = true;
            this.acGridView2.OptionsView.RowAutoHeight = true;
            this.acGridView2.OptionsView.ShowGroupPanel = false;
            this.acGridView2.OptionsView.ShowIndicator = false;
            this.acGridView2.ParentControl = this;
            this.acGridView2.RowHeight = 30;
            this.acGridView2.SaveFileName = null;
            // 
            // acLayoutControlGroup1
            // 
            this.acLayoutControlGroup1.CustomizationFormText = "acLayoutControlGroup1";
            this.acLayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.False;
            this.acLayoutControlGroup1.GroupBordersVisible = false;
            this.acLayoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.acLayoutControlItem4,
            this.acLayoutControlItem5});
            this.acLayoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.acLayoutControlGroup1.Name = "Root";
            this.acLayoutControlGroup1.ResourceID = null;
            this.acLayoutControlGroup1.Size = new System.Drawing.Size(378, 404);
            this.acLayoutControlGroup1.Text = "Root";
            this.acLayoutControlGroup1.TextVisible = false;
            this.acLayoutControlGroup1.ToolTipID = null;
            this.acLayoutControlGroup1.UseResourceID = false;
            this.acLayoutControlGroup1.UseToolTipID = false;
            // 
            // acLayoutControlItem4
            // 
            this.acLayoutControlItem4.Control = this.acGridControl2;
            this.acLayoutControlItem4.CustomizationFormText = "acLayoutControlItem4";
            this.acLayoutControlItem4.Location = new System.Drawing.Point(0, 62);
            this.acLayoutControlItem4.Name = "acLayoutControlItem4";
            this.acLayoutControlItem4.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.acLayoutControlItem4.ResourceID = null;
            this.acLayoutControlItem4.Size = new System.Drawing.Size(378, 342);
            this.acLayoutControlItem4.Text = "acLayoutControlItem4";
            this.acLayoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.acLayoutControlItem4.TextToControlDistance = 0;
            this.acLayoutControlItem4.TextVisible = false;
            this.acLayoutControlItem4.ToolTipID = null;
            this.acLayoutControlItem4.UseResourceID = false;
            this.acLayoutControlItem4.UseToolTipID = false;
            // 
            // acLayoutControlItem5
            // 
            this.acLayoutControlItem5.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 15F);
            this.acLayoutControlItem5.AppearanceItemCaption.Options.UseFont = true;
            this.acLayoutControlItem5.Control = this.acTextEdit1;
            this.acLayoutControlItem5.CustomizationFormText = "총 시간";
            this.acLayoutControlItem5.Location = new System.Drawing.Point(0, 0);
            this.acLayoutControlItem5.MinSize = new System.Drawing.Size(99, 30);
            this.acLayoutControlItem5.Name = "acLayoutControlItem5";
            this.acLayoutControlItem5.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.acLayoutControlItem5.ResourceID = null;
            this.acLayoutControlItem5.Size = new System.Drawing.Size(378, 62);
            this.acLayoutControlItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.acLayoutControlItem5.Text = "총 시간";
            this.acLayoutControlItem5.TextSize = new System.Drawing.Size(54, 24);
            this.acLayoutControlItem5.ToolTipID = null;
            this.acLayoutControlItem5.UseResourceID = false;
            this.acLayoutControlItem5.UseToolTipID = false;
            // 
            // WorkStopEnd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(378, 466);
            this.Controls.Add(this.acSplitContainerControl1);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WorkStopEnd";
            this.ResourceID = "";
            this.Text = "비가동";
            ((System.ComponentModel.ISupportInitialize)(this.acSplitContainerControl1)).EndInit();
            this.acSplitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControl1)).EndInit();
            this.acLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControl2)).EndInit();
            this.acLayoutControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.acTextEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acGridControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem5)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ControlManager.acSplitContainerControl acSplitContainerControl1;
        private ControlManager.acLayoutControl acLayoutControl2;
        private ControlManager.acLayoutControlGroup acLayoutControlGroup1;
        private ControlManager.acGridControl acGridControl2;
        private ControlManager.acGridView acGridView2;
        private ControlManager.acLayoutControlItem acLayoutControlItem4;
        private ControlManager.acTextEdit acTextEdit1;
        private ControlManager.acLayoutControlItem acLayoutControlItem5;
        private ControlManager.acLayoutControl acLayoutControl1;
        private ControlManager.acSimpleButton btnCancel;
        private ControlManager.acSimpleButton btnOk;
        private ControlManager.acLayoutControlGroup acLayoutControlGroup2;
        private ControlManager.acLayoutControlItem acLayoutControlItem1;
        private ControlManager.acLayoutControlItem acLayoutControlItem2;





    }
}
