namespace POP
{
    partial class ChangeMC
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
            this.gc = new ControlManager.acGridControl();
            this.gv = new ControlManager.acGridView();
            this.acLayoutControl1 = new ControlManager.acLayoutControl();
            this.txtMcCord = new ControlManager.acTextEdit();
            this.btnCancel = new ControlManager.acSimpleButton();
            this.btnOk = new ControlManager.acSimpleButton();
            this.acLayoutControlGroup2 = new ControlManager.acLayoutControlGroup();
            this.acLayoutControlItem1 = new ControlManager.acLayoutControlItem();
            this.acLayoutControlItem2 = new ControlManager.acLayoutControlItem();
            this.acLayoutControlItem3 = new ControlManager.acLayoutControlItem();
            this.acLayoutControlItem4 = new ControlManager.acLayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.gc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControl1)).BeginInit();
            this.acLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMcCord.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem4)).BeginInit();
            this.SuspendLayout();
            // 
            // gc
            // 
            this.gc.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.gc.Location = new System.Drawing.Point(5, 70);
            this.gc.MainView = this.gv;
            this.gc.Margin = new System.Windows.Forms.Padding(4);
            this.gc.Name = "gc";
            this.gc.Size = new System.Drawing.Size(502, 400);
            this.gc.TabIndex = 4;
            this.gc.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv});
            // 
            // gv
            // 
            this.gv.Appearance.FocusedRow.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gv.Appearance.FocusedRow.Options.UseFont = true;
            this.gv.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gv.Appearance.HeaderPanel.Options.UseFont = true;
            this.gv.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gv.Appearance.HideSelectionRow.Options.UseFont = true;
            this.gv.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gv.Appearance.Row.Options.UseFont = true;
            this.gv.ColumnPanelRowHeight = 0;
            this.gv.GridControl = this.gc;
            this.gv.IsUserStyle = false;
            this.gv.Name = "gv";
            this.gv.NoApplyEditableCellColor = false;
            this.gv.OptionsBehavior.AutoPopulateColumns = false;
            this.gv.OptionsBehavior.Editable = false;
            this.gv.OptionsLayout.Columns.StoreAllOptions = true;
            this.gv.OptionsLayout.StoreAllOptions = true;
            this.gv.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gv.OptionsView.RowAutoHeight = true;
            this.gv.OptionsView.ShowGroupPanel = false;
            this.gv.OptionsView.ShowIndicator = false;
            this.gv.ParentControl = this;
            this.gv.RowHeight = 0;
            this.gv.SaveFileName = null;
            // 
            // acLayoutControl1
            // 
            this.acLayoutControl1.AllowCustomization = false;
            this.acLayoutControl1.ContainerName = null;
            this.acLayoutControl1.Controls.Add(this.txtMcCord);
            this.acLayoutControl1.Controls.Add(this.gc);
            this.acLayoutControl1.Controls.Add(this.btnCancel);
            this.acLayoutControl1.Controls.Add(this.btnOk);
            this.acLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.acLayoutControl1.LayoutType = ControlManager.acLayoutControl.emLayoutType.NONE;
            this.acLayoutControl1.Location = new System.Drawing.Point(0, 0);
            this.acLayoutControl1.Name = "acLayoutControl1";
            this.acLayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(1859, 104, 250, 350);
            this.acLayoutControl1.ParentControl = null;
            this.acLayoutControl1.Root = this.acLayoutControlGroup2;
            this.acLayoutControl1.Size = new System.Drawing.Size(512, 475);
            this.acLayoutControl1.TabIndex = 0;
            this.acLayoutControl1.Text = "acLayoutControl1";
            // 
            // txtMcCord
            // 
            this.txtMcCord.ColumnName = "MC_LIKE";
            this.txtMcCord.Location = new System.Drawing.Point(88, 5);
            this.txtMcCord.MaskType = ControlManager.acTextEdit.emMaskType.NONE;
            this.txtMcCord.Name = "txtMcCord";
            this.txtMcCord.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtMcCord.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 15F);
            this.txtMcCord.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.txtMcCord.Properties.Appearance.Options.UseBackColor = true;
            this.txtMcCord.Properties.Appearance.Options.UseFont = true;
            this.txtMcCord.Properties.Appearance.Options.UseForeColor = true;
            this.txtMcCord.Properties.AutoHeight = false;
            this.txtMcCord.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txtMcCord.Size = new System.Drawing.Size(203, 55);
            this.txtMcCord.StyleController = this.acLayoutControl1;
            this.txtMcCord.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(409, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.ResourceID = null;
            this.btnCancel.Size = new System.Drawing.Size(98, 55);
            this.btnCancel.StyleController = this.acLayoutControl1;
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "닫기";
            this.btnCancel.ToolTipID = null;
            this.btnCancel.UseResourceID = false;
            this.btnCancel.UseToolTipID = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(301, 5);
            this.btnOk.Name = "btnOk";
            this.btnOk.ResourceID = null;
            this.btnOk.Size = new System.Drawing.Size(98, 55);
            this.btnOk.StyleController = this.acLayoutControl1;
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "확인";
            this.btnOk.ToolTipID = null;
            this.btnOk.UseResourceID = false;
            this.btnOk.UseToolTipID = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // acLayoutControlGroup2
            // 
            this.acLayoutControlGroup2.CustomizationFormText = "Root";
            this.acLayoutControlGroup2.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.False;
            this.acLayoutControlGroup2.GroupBordersVisible = false;
            this.acLayoutControlGroup2.IsHeader = false;
            this.acLayoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.acLayoutControlItem1,
            this.acLayoutControlItem2,
            this.acLayoutControlItem3,
            this.acLayoutControlItem4});
            this.acLayoutControlGroup2.Name = "Root";
            this.acLayoutControlGroup2.ResourceID = null;
            this.acLayoutControlGroup2.Size = new System.Drawing.Size(512, 475);
            this.acLayoutControlGroup2.TextVisible = false;
            this.acLayoutControlGroup2.ToolTipID = null;
            this.acLayoutControlGroup2.UseResourceID = false;
            this.acLayoutControlGroup2.UseToolTipID = false;
            // 
            // acLayoutControlItem1
            // 
            this.acLayoutControlItem1.Control = this.btnOk;
            this.acLayoutControlItem1.CustomizationFormText = "acLayoutControlItem1";
            this.acLayoutControlItem1.IsHeader = false;
            this.acLayoutControlItem1.IsTitle = false;
            this.acLayoutControlItem1.Location = new System.Drawing.Point(296, 0);
            this.acLayoutControlItem1.MinSize = new System.Drawing.Size(1, 1);
            this.acLayoutControlItem1.Name = "acLayoutControlItem1";
            this.acLayoutControlItem1.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.acLayoutControlItem1.ResourceID = null;
            this.acLayoutControlItem1.Size = new System.Drawing.Size(108, 65);
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
            this.acLayoutControlItem2.Control = this.btnCancel;
            this.acLayoutControlItem2.CustomizationFormText = "acLayoutControlItem2";
            this.acLayoutControlItem2.IsHeader = false;
            this.acLayoutControlItem2.IsTitle = false;
            this.acLayoutControlItem2.Location = new System.Drawing.Point(404, 0);
            this.acLayoutControlItem2.MinSize = new System.Drawing.Size(1, 1);
            this.acLayoutControlItem2.Name = "acLayoutControlItem2";
            this.acLayoutControlItem2.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.acLayoutControlItem2.ResourceID = null;
            this.acLayoutControlItem2.Size = new System.Drawing.Size(108, 65);
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
            this.acLayoutControlItem3.Control = this.gc;
            this.acLayoutControlItem3.CustomizationFormText = "acLayoutControlItem3";
            this.acLayoutControlItem3.IsHeader = false;
            this.acLayoutControlItem3.IsTitle = false;
            this.acLayoutControlItem3.Location = new System.Drawing.Point(0, 65);
            this.acLayoutControlItem3.Name = "acLayoutControlItem3";
            this.acLayoutControlItem3.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.acLayoutControlItem3.ResourceID = null;
            this.acLayoutControlItem3.Size = new System.Drawing.Size(512, 410);
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
            this.acLayoutControlItem4.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.acLayoutControlItem4.AppearanceItemCaption.Options.UseFont = true;
            this.acLayoutControlItem4.Control = this.txtMcCord;
            this.acLayoutControlItem4.CustomizationFormText = "설비코드/명";
            this.acLayoutControlItem4.IsHeader = false;
            this.acLayoutControlItem4.IsTitle = false;
            this.acLayoutControlItem4.Location = new System.Drawing.Point(0, 0);
            this.acLayoutControlItem4.MinSize = new System.Drawing.Size(102, 30);
            this.acLayoutControlItem4.Name = "acLayoutControlItem4";
            this.acLayoutControlItem4.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.acLayoutControlItem4.ResourceID = null;
            this.acLayoutControlItem4.Size = new System.Drawing.Size(296, 65);
            this.acLayoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.acLayoutControlItem4.Text = "설비코드/명";
            this.acLayoutControlItem4.TextSize = new System.Drawing.Size(71, 18);
            this.acLayoutControlItem4.ToolTipID = null;
            this.acLayoutControlItem4.ToolTipStdCode = null;
            this.acLayoutControlItem4.UseResourceID = false;
            this.acLayoutControlItem4.UseToolTipID = false;
            // 
            // ChangeMC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(512, 475);
            this.Controls.Add(this.acLayoutControl1);
            this.IconOptions.ShowIcon = false;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChangeMC";
            this.ResourceID = "";
            this.Text = "설비 변경";
            ((System.ComponentModel.ISupportInitialize)(this.gc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControl1)).EndInit();
            this.acLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtMcCord.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ControlManager.acGridControl gc;
        private ControlManager.acGridView gv;
        private ControlManager.acLayoutControl acLayoutControl1;
        private ControlManager.acSimpleButton btnCancel;
        private ControlManager.acSimpleButton btnOk;
        private ControlManager.acLayoutControlGroup acLayoutControlGroup2;
        private ControlManager.acLayoutControlItem acLayoutControlItem1;
        private ControlManager.acLayoutControlItem acLayoutControlItem2;
        private ControlManager.acLayoutControlItem acLayoutControlItem3;
        private ControlManager.acTextEdit txtMcCord;
        private ControlManager.acLayoutControlItem acLayoutControlItem4;
    }
}
