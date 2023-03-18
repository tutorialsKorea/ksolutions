namespace POP
{
    partial class WorkStop2
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
            this.acLayoutControl2 = new ControlManager.acLayoutControl();
            this.btnCancel = new ControlManager.acSimpleButton();
            this.acLabelControl2 = new ControlManager.acLabelControl();
            this.btnOk = new ControlManager.acSimpleButton();
            this.acLookupEdit2 = new ControlManager.acLookupEdit();
            this.acLayoutControlGroup1 = new ControlManager.acLayoutControlGroup();
            this.acLayoutControlItem4 = new ControlManager.acLayoutControlItem();
            this.acLayoutControlItem6 = new ControlManager.acLayoutControlItem();
            this.acLayoutControlItem1 = new ControlManager.acLayoutControlItem();
            this.acLayoutControlItem2 = new ControlManager.acLayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControl2)).BeginInit();
            this.acLayoutControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.acLookupEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // acLayoutControl2
            // 
            this.acLayoutControl2.AllowCustomizationMenu = false;
            this.acLayoutControl2.AutoScroll = false;
            this.acLayoutControl2.ContainerName = null;
            this.acLayoutControl2.Controls.Add(this.btnCancel);
            this.acLayoutControl2.Controls.Add(this.acLabelControl2);
            this.acLayoutControl2.Controls.Add(this.btnOk);
            this.acLayoutControl2.Controls.Add(this.acLookupEdit2);
            this.acLayoutControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.acLayoutControl2.LayoutType = ControlManager.acLayoutControl.emLayoutType.NONE;
            this.acLayoutControl2.Location = new System.Drawing.Point(0, 0);
            this.acLayoutControl2.Name = "acLayoutControl2";
            this.acLayoutControl2.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(2218, 16, 250, 350);
            this.acLayoutControl2.OptionsView.DrawItemBorders = true;
            this.acLayoutControl2.ParentControl = null;
            this.acLayoutControl2.Root = this.acLayoutControlGroup1;
            this.acLayoutControl2.Size = new System.Drawing.Size(368, 147);
            this.acLayoutControl2.TabIndex = 0;
            this.acLayoutControl2.Text = "acLayoutControl2";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(189, 87);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.ResourceID = null;
            this.btnCancel.Size = new System.Drawing.Size(174, 55);
            this.btnCancel.StyleController = this.acLayoutControl2;
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "닫기";
            this.btnCancel.ToolTipID = null;
            this.btnCancel.UseResourceID = false;
            this.btnCancel.UseToolTipID = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // acLabelControl2
            // 
            this.acLabelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold);
            this.acLabelControl2.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.acLabelControl2.Location = new System.Drawing.Point(5, 5);
            this.acLabelControl2.Name = "acLabelControl2";
            this.acLabelControl2.ResourceID = null;
            this.acLabelControl2.Size = new System.Drawing.Size(358, 18);
            this.acLabelControl2.StyleController = this.acLayoutControl2;
            this.acLabelControl2.TabIndex = 7;
            this.acLabelControl2.Text = "비가동 사유";
            this.acLabelControl2.ToolTipID = null;
            this.acLabelControl2.UseResourceID = false;
            this.acLabelControl2.UseToolTipID = false;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(5, 87);
            this.btnOk.Name = "btnOk";
            this.btnOk.ResourceID = null;
            this.btnOk.Size = new System.Drawing.Size(174, 55);
            this.btnOk.StyleController = this.acLayoutControl2;
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "확인";
            this.btnOk.ToolTipID = null;
            this.btnOk.UseResourceID = false;
            this.btnOk.UseToolTipID = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // acLookupEdit2
            // 
            this.acLookupEdit2.ColumnName = "IDLE_CAUSE";
            this.acLookupEdit2.DefaultValueType = ControlManager.acLookupEdit.emDefaultValueType.NONE;
            this.acLookupEdit2.isReadyOnly = false;
            this.acLookupEdit2.isRequired = false;
            this.acLookupEdit2.Location = new System.Drawing.Point(5, 33);
            this.acLookupEdit2.Name = "acLookupEdit2";
            this.acLookupEdit2.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.acLookupEdit2.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 15F);
            this.acLookupEdit2.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.acLookupEdit2.Properties.Appearance.Options.UseBackColor = true;
            this.acLookupEdit2.Properties.Appearance.Options.UseFont = true;
            this.acLookupEdit2.Properties.Appearance.Options.UseForeColor = true;
            this.acLookupEdit2.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Tahoma", 15F);
            this.acLookupEdit2.Properties.AppearanceDropDown.Options.UseFont = true;
            this.acLookupEdit2.Properties.AppearanceFocused.Font = new System.Drawing.Font("Tahoma", 15F);
            this.acLookupEdit2.Properties.AppearanceFocused.Options.UseFont = true;
            this.acLookupEdit2.Properties.AutoHeight = false;
            this.acLookupEdit2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.acLookupEdit2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.acLookupEdit2.Properties.NullText = "";
            this.acLookupEdit2.Properties.ShowHeader = false;
            this.acLookupEdit2.Size = new System.Drawing.Size(358, 44);
            this.acLookupEdit2.StyleController = this.acLayoutControl2;
            this.acLookupEdit2.TabIndex = 5;
            this.acLookupEdit2.ToolTipID = null;
            this.acLookupEdit2.UseToolTipID = false;
            this.acLookupEdit2.Value = null;
            // 
            // acLayoutControlGroup1
            // 
            this.acLayoutControlGroup1.CustomizationFormText = "acLayoutControlGroup1";
            this.acLayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.False;
            this.acLayoutControlGroup1.GroupBordersVisible = false;
            this.acLayoutControlGroup1.IsHeader = false;
            this.acLayoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.acLayoutControlItem4,
            this.acLayoutControlItem6,
            this.acLayoutControlItem1,
            this.acLayoutControlItem2});
            this.acLayoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.acLayoutControlGroup1.Name = "Root";
            this.acLayoutControlGroup1.ResourceID = null;
            this.acLayoutControlGroup1.Size = new System.Drawing.Size(368, 147);
            this.acLayoutControlGroup1.Text = "Root";
            this.acLayoutControlGroup1.TextVisible = false;
            this.acLayoutControlGroup1.ToolTipID = null;
            this.acLayoutControlGroup1.UseResourceID = false;
            this.acLayoutControlGroup1.UseToolTipID = false;
            // 
            // acLayoutControlItem4
            // 
            this.acLayoutControlItem4.Control = this.acLookupEdit2;
            this.acLayoutControlItem4.CustomizationFormText = "acLayoutControlItem4";
            this.acLayoutControlItem4.IsHeader = false;
            this.acLayoutControlItem4.IsTitle = false;
            this.acLayoutControlItem4.Location = new System.Drawing.Point(0, 28);
            this.acLayoutControlItem4.MinSize = new System.Drawing.Size(60, 40);
            this.acLayoutControlItem4.Name = "acLayoutControlItem4";
            this.acLayoutControlItem4.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.acLayoutControlItem4.ResourceID = null;
            this.acLayoutControlItem4.Size = new System.Drawing.Size(368, 54);
            this.acLayoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.acLayoutControlItem4.Text = "acLayoutControlItem4";
            this.acLayoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.acLayoutControlItem4.TextVisible = false;
            this.acLayoutControlItem4.ToolTipID = null;
            this.acLayoutControlItem4.ToolTipStdCode = null;
            this.acLayoutControlItem4.UseResourceID = false;
            this.acLayoutControlItem4.UseToolTipID = false;
            // 
            // acLayoutControlItem6
            // 
            this.acLayoutControlItem6.Control = this.acLabelControl2;
            this.acLayoutControlItem6.CustomizationFormText = "acLayoutControlItem6";
            this.acLayoutControlItem6.IsHeader = false;
            this.acLayoutControlItem6.IsTitle = false;
            this.acLayoutControlItem6.Location = new System.Drawing.Point(0, 0);
            this.acLayoutControlItem6.MinSize = new System.Drawing.Size(96, 24);
            this.acLayoutControlItem6.Name = "acLayoutControlItem6";
            this.acLayoutControlItem6.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.acLayoutControlItem6.ResourceID = null;
            this.acLayoutControlItem6.Size = new System.Drawing.Size(368, 28);
            this.acLayoutControlItem6.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.acLayoutControlItem6.Text = "acLayoutControlItem6";
            this.acLayoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.acLayoutControlItem6.TextVisible = false;
            this.acLayoutControlItem6.ToolTipID = null;
            this.acLayoutControlItem6.ToolTipStdCode = null;
            this.acLayoutControlItem6.UseResourceID = false;
            this.acLayoutControlItem6.UseToolTipID = false;
            // 
            // acLayoutControlItem1
            // 
            this.acLayoutControlItem1.Control = this.btnOk;
            this.acLayoutControlItem1.CustomizationFormText = "acLayoutControlItem1";
            this.acLayoutControlItem1.IsHeader = false;
            this.acLayoutControlItem1.IsTitle = false;
            this.acLayoutControlItem1.Location = new System.Drawing.Point(0, 82);
            this.acLayoutControlItem1.MinSize = new System.Drawing.Size(41, 32);
            this.acLayoutControlItem1.Name = "acLayoutControlItem1";
            this.acLayoutControlItem1.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.acLayoutControlItem1.ResourceID = null;
            this.acLayoutControlItem1.Size = new System.Drawing.Size(184, 65);
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
            this.acLayoutControlItem2.Location = new System.Drawing.Point(184, 82);
            this.acLayoutControlItem2.MinSize = new System.Drawing.Size(41, 32);
            this.acLayoutControlItem2.Name = "acLayoutControlItem2";
            this.acLayoutControlItem2.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.acLayoutControlItem2.ResourceID = null;
            this.acLayoutControlItem2.Size = new System.Drawing.Size(184, 65);
            this.acLayoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.acLayoutControlItem2.Text = "acLayoutControlItem2";
            this.acLayoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.acLayoutControlItem2.TextVisible = false;
            this.acLayoutControlItem2.ToolTipID = null;
            this.acLayoutControlItem2.ToolTipStdCode = null;
            this.acLayoutControlItem2.UseResourceID = false;
            this.acLayoutControlItem2.UseToolTipID = false;
            // 
            // WorkStop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(368, 147);
            this.ControlBox = false;
            this.Controls.Add(this.acLayoutControl2);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WorkStop";
            this.ResourceID = "";
            this.Text = "비가동 사유를 선택하세요.";
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControl2)).EndInit();
            this.acLayoutControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.acLookupEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ControlManager.acLayoutControl acLayoutControl2;
        private ControlManager.acLayoutControlGroup acLayoutControlGroup1;
        private ControlManager.acLookupEdit acLookupEdit2;
        private ControlManager.acLayoutControlItem acLayoutControlItem4;
        private ControlManager.acSimpleButton btnCancel;
        private ControlManager.acSimpleButton btnOk;
        private ControlManager.acLabelControl acLabelControl2;
        private ControlManager.acLayoutControlItem acLayoutControlItem6;
        private ControlManager.acLayoutControlItem acLayoutControlItem1;
        private ControlManager.acLayoutControlItem acLayoutControlItem2;





    }
}
