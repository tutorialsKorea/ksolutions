namespace POP
{
    partial class SelProduct
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
            this.btnCancel = new ControlManager.acSimpleButton();
            this.acLayoutControl1 = new ControlManager.acLayoutControl();
            this.btnSearch = new ControlManager.acSimpleButton();
            this.btnOk = new ControlManager.acSimpleButton();
            this.acTextEdit1 = new ControlManager.acTextEdit();
            this.acGridControl1 = new ControlManager.acGridControl();
            this.acGridView1 = new ControlManager.acGridView();
            this.acLayoutControlGroup1 = new ControlManager.acLayoutControlGroup();
            this.acLayoutControlItem1 = new ControlManager.acLayoutControlItem();
            this.acLayoutControlItem6 = new ControlManager.acLayoutControlItem();
            this.acLayoutControlItem7 = new ControlManager.acLayoutControlItem();
            this.acLayoutControlItem2 = new ControlManager.acLayoutControlItem();
            this.acLayoutControlItem3 = new ControlManager.acLayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControl1)).BeginInit();
            this.acLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.acTextEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acGridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem3)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(703, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.ResourceID = null;
            this.btnCancel.Size = new System.Drawing.Size(102, 50);
            this.btnCancel.StyleController = this.acLayoutControl1;
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "닫기";
            this.btnCancel.ToolTipID = null;
            this.btnCancel.UseResourceID = false;
            this.btnCancel.UseToolTipID = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // acLayoutControl1
            // 
            this.acLayoutControl1.AllowCustomizationMenu = false;
            this.acLayoutControl1.ContainerName = null;
            this.acLayoutControl1.Controls.Add(this.btnCancel);
            this.acLayoutControl1.Controls.Add(this.btnSearch);
            this.acLayoutControl1.Controls.Add(this.btnOk);
            this.acLayoutControl1.Controls.Add(this.acTextEdit1);
            this.acLayoutControl1.Controls.Add(this.acGridControl1);
            this.acLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.acLayoutControl1.LayoutType = ControlManager.acLayoutControl.emLayoutType.NONE;
            this.acLayoutControl1.Location = new System.Drawing.Point(0, 0);
            this.acLayoutControl1.Name = "acLayoutControl1";
            this.acLayoutControl1.ParentControl = null;
            this.acLayoutControl1.Root = this.acLayoutControlGroup1;
            this.acLayoutControl1.Size = new System.Drawing.Size(810, 401);
            this.acLayoutControl1.TabIndex = 1;
            this.acLayoutControl1.Text = "acLayoutControl1";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(479, 5);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.ResourceID = null;
            this.btnSearch.Size = new System.Drawing.Size(102, 50);
            this.btnSearch.StyleController = this.acLayoutControl1;
            this.btnSearch.TabIndex = 8;
            this.btnSearch.Text = "조회";
            this.btnSearch.ToolTipID = null;
            this.btnSearch.UseResourceID = false;
            this.btnSearch.UseToolTipID = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(591, 5);
            this.btnOk.Name = "btnOk";
            this.btnOk.ResourceID = null;
            this.btnOk.Size = new System.Drawing.Size(102, 50);
            this.btnOk.StyleController = this.acLayoutControl1;
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "선택";
            this.btnOk.ToolTipID = null;
            this.btnOk.UseResourceID = false;
            this.btnOk.UseToolTipID = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // acTextEdit1
            // 
            this.acTextEdit1.ColumnName = "PART_LIKE";
            this.acTextEdit1.Location = new System.Drawing.Point(96, 5);
            this.acTextEdit1.MaskType = ControlManager.acTextEdit.emMaskType.NONE;
            this.acTextEdit1.Name = "acTextEdit1";
            this.acTextEdit1.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.acTextEdit1.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 15F);
            this.acTextEdit1.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.acTextEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.acTextEdit1.Properties.Appearance.Options.UseFont = true;
            this.acTextEdit1.Properties.Appearance.Options.UseForeColor = true;
            this.acTextEdit1.Properties.AutoHeight = false;
            this.acTextEdit1.Size = new System.Drawing.Size(373, 50);
            this.acTextEdit1.StyleController = this.acLayoutControl1;
            this.acTextEdit1.TabIndex = 7;
            // 
            // acGridControl1
            // 
            this.acGridControl1.Location = new System.Drawing.Point(5, 65);
            this.acGridControl1.MainView = this.acGridView1;
            this.acGridControl1.Name = "acGridControl1";
            this.acGridControl1.Size = new System.Drawing.Size(800, 331);
            this.acGridControl1.TabIndex = 6;
            this.acGridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.acGridView1});
            // 
            // acGridView1
            // 
            this.acGridView1.GridControl = this.acGridControl1;
            this.acGridView1.Name = "acGridView1";
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
            // acLayoutControlGroup1
            // 
            this.acLayoutControlGroup1.CustomizationFormText = "acLayoutControlGroup1";
            this.acLayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.False;
            this.acLayoutControlGroup1.GroupBordersVisible = false;
            this.acLayoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.acLayoutControlItem1,
            this.acLayoutControlItem6,
            this.acLayoutControlItem7,
            this.acLayoutControlItem2,
            this.acLayoutControlItem3});
            this.acLayoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.acLayoutControlGroup1.Name = "acLayoutControlGroup1";
            this.acLayoutControlGroup1.ResourceID = null;
            this.acLayoutControlGroup1.Size = new System.Drawing.Size(810, 401);
            this.acLayoutControlGroup1.Text = "acLayoutControlGroup1";
            this.acLayoutControlGroup1.TextVisible = false;
            this.acLayoutControlGroup1.ToolTipID = null;
            this.acLayoutControlGroup1.UseResourceID = false;
            this.acLayoutControlGroup1.UseToolTipID = false;
            // 
            // acLayoutControlItem1
            // 
            this.acLayoutControlItem1.Control = this.acGridControl1;
            this.acLayoutControlItem1.CustomizationFormText = "acLayoutControlItem1";
            this.acLayoutControlItem1.Location = new System.Drawing.Point(0, 60);
            this.acLayoutControlItem1.MinSize = new System.Drawing.Size(110, 30);
            this.acLayoutControlItem1.Name = "acLayoutControlItem1";
            this.acLayoutControlItem1.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.acLayoutControlItem1.ResourceID = null;
            this.acLayoutControlItem1.Size = new System.Drawing.Size(810, 341);
            this.acLayoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.acLayoutControlItem1.Text = "acLayoutControlItem1";
            this.acLayoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.acLayoutControlItem1.TextToControlDistance = 0;
            this.acLayoutControlItem1.TextVisible = false;
            this.acLayoutControlItem1.ToolTipID = null;
            this.acLayoutControlItem1.UseResourceID = false;
            this.acLayoutControlItem1.UseToolTipID = false;
            // 
            // acLayoutControlItem6
            // 
            this.acLayoutControlItem6.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 15F);
            this.acLayoutControlItem6.AppearanceItemCaption.Options.UseFont = true;
            this.acLayoutControlItem6.Control = this.acTextEdit1;
            this.acLayoutControlItem6.CustomizationFormText = "품목코드/명";
            this.acLayoutControlItem6.Location = new System.Drawing.Point(0, 0);
            this.acLayoutControlItem6.MinSize = new System.Drawing.Size(128, 30);
            this.acLayoutControlItem6.Name = "acLayoutControlItem6";
            this.acLayoutControlItem6.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.acLayoutControlItem6.ResourceID = null;
            this.acLayoutControlItem6.Size = new System.Drawing.Size(474, 60);
            this.acLayoutControlItem6.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.acLayoutControlItem6.Text = "품목코드/명";
            this.acLayoutControlItem6.TextSize = new System.Drawing.Size(88, 24);
            this.acLayoutControlItem6.ToolTipID = null;
            this.acLayoutControlItem6.UseResourceID = false;
            this.acLayoutControlItem6.UseToolTipID = false;
            // 
            // acLayoutControlItem7
            // 
            this.acLayoutControlItem7.Control = this.btnSearch;
            this.acLayoutControlItem7.CustomizationFormText = "acLayoutControlItem7";
            this.acLayoutControlItem7.Location = new System.Drawing.Point(474, 0);
            this.acLayoutControlItem7.MinSize = new System.Drawing.Size(1, 1);
            this.acLayoutControlItem7.Name = "acLayoutControlItem7";
            this.acLayoutControlItem7.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.acLayoutControlItem7.ResourceID = null;
            this.acLayoutControlItem7.Size = new System.Drawing.Size(112, 60);
            this.acLayoutControlItem7.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.acLayoutControlItem7.Text = "acLayoutControlItem7";
            this.acLayoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.acLayoutControlItem7.TextToControlDistance = 0;
            this.acLayoutControlItem7.TextVisible = false;
            this.acLayoutControlItem7.ToolTipID = null;
            this.acLayoutControlItem7.UseResourceID = false;
            this.acLayoutControlItem7.UseToolTipID = false;
            // 
            // acLayoutControlItem2
            // 
            this.acLayoutControlItem2.Control = this.btnOk;
            this.acLayoutControlItem2.CustomizationFormText = "acLayoutControlItem2";
            this.acLayoutControlItem2.Location = new System.Drawing.Point(586, 0);
            this.acLayoutControlItem2.MinSize = new System.Drawing.Size(45, 32);
            this.acLayoutControlItem2.Name = "acLayoutControlItem2";
            this.acLayoutControlItem2.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.acLayoutControlItem2.ResourceID = null;
            this.acLayoutControlItem2.Size = new System.Drawing.Size(112, 60);
            this.acLayoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.acLayoutControlItem2.Text = "acLayoutControlItem2";
            this.acLayoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.acLayoutControlItem2.TextToControlDistance = 0;
            this.acLayoutControlItem2.TextVisible = false;
            this.acLayoutControlItem2.ToolTipID = null;
            this.acLayoutControlItem2.UseResourceID = false;
            this.acLayoutControlItem2.UseToolTipID = false;
            // 
            // acLayoutControlItem3
            // 
            this.acLayoutControlItem3.Control = this.btnCancel;
            this.acLayoutControlItem3.CustomizationFormText = "acLayoutControlItem3";
            this.acLayoutControlItem3.Location = new System.Drawing.Point(698, 0);
            this.acLayoutControlItem3.MinSize = new System.Drawing.Size(45, 32);
            this.acLayoutControlItem3.Name = "acLayoutControlItem3";
            this.acLayoutControlItem3.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.acLayoutControlItem3.ResourceID = null;
            this.acLayoutControlItem3.Size = new System.Drawing.Size(112, 60);
            this.acLayoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.acLayoutControlItem3.Text = "acLayoutControlItem3";
            this.acLayoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.acLayoutControlItem3.TextToControlDistance = 0;
            this.acLayoutControlItem3.TextVisible = false;
            this.acLayoutControlItem3.ToolTipID = null;
            this.acLayoutControlItem3.UseResourceID = false;
            this.acLayoutControlItem3.UseToolTipID = false;
            // 
            // SelProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(810, 401);
            this.Controls.Add(this.acLayoutControl1);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SelProduct";
            this.ResourceID = "";
            this.Text = "품명선택";
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControl1)).EndInit();
            this.acLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.acTextEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acGridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ControlManager.acLayoutControl acLayoutControl1;
        private ControlManager.acLayoutControlGroup acLayoutControlGroup1;
        private ControlManager.acSimpleButton btnCancel;
        private ControlManager.acSimpleButton btnOk;
        private ControlManager.acGridControl acGridControl1;
        private ControlManager.acGridView acGridView1;
        private ControlManager.acLayoutControlItem acLayoutControlItem1;
        private ControlManager.acTextEdit acTextEdit1;
        private ControlManager.acLayoutControlItem acLayoutControlItem6;
        private ControlManager.acSimpleButton btnSearch;
        private ControlManager.acLayoutControlItem acLayoutControlItem7;
        private ControlManager.acLayoutControlItem acLayoutControlItem2;
        private ControlManager.acLayoutControlItem acLayoutControlItem3;





    }
}
