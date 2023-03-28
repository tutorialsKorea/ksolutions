namespace ControlManager
{
    partial class acGridViewMaskEdit
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
            this.acLayoutControl1 = new ControlManager.acLayoutControl();
            this.comboBoxEdit1 = new DevExpress.XtraEditors.ComboBoxEdit();
            this.acTextEdit1 = new ControlManager.acTextEdit();
            this.layoutControlGroup1 = new ControlManager.acLayoutControlGroup();
            this.acLayoutControlItem2 = new ControlManager.acLayoutControlItem();
            this.acLayoutControlItem1 = new ControlManager.acLayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControl1)).BeginInit();
            this.acLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acTextEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // acLayoutControl1
            // 
            this.acLayoutControl1.AllowCustomizationMenu = false;
            this.acLayoutControl1.AutoScroll = false;
            this.acLayoutControl1.ContainerName = null;
            this.acLayoutControl1.Controls.Add(this.comboBoxEdit1);
            this.acLayoutControl1.Controls.Add(this.acTextEdit1);
            this.acLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.acLayoutControl1.LayoutType = ControlManager.acLayoutControl.emLayoutType.NONE;
            this.acLayoutControl1.Location = new System.Drawing.Point(0, 0);
            this.acLayoutControl1.Name = "acLayoutControl1";
            this.acLayoutControl1.ParentControl = null;
            this.acLayoutControl1.Root = this.layoutControlGroup1;
            this.acLayoutControl1.Size = new System.Drawing.Size(253, 67);
            this.acLayoutControl1.TabIndex = 0;
            this.acLayoutControl1.Text = "acLayoutControl1";
            // 
            // comboBoxEdit1
            // 
            this.comboBoxEdit1.Location = new System.Drawing.Point(75, 6);
            this.comboBoxEdit1.Name = "comboBoxEdit1";
            this.comboBoxEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEdit1.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboBoxEdit1.Size = new System.Drawing.Size(173, 21);
            this.comboBoxEdit1.StyleController = this.acLayoutControl1;
            this.comboBoxEdit1.TabIndex = 6;
            // 
            // acTextEdit1
            // 
            this.acTextEdit1.Location = new System.Drawing.Point(75, 38);
            this.acTextEdit1.MaskType = ControlManager.acTextEdit.emMaskType.NONE;
            this.acTextEdit1.Name = "acTextEdit1";
            this.acTextEdit1.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.acTextEdit1.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.acTextEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.acTextEdit1.Properties.Appearance.Options.UseForeColor = true;
            this.acTextEdit1.Size = new System.Drawing.Size(173, 21);
            this.acTextEdit1.StyleController = this.acLayoutControl1;
            this.acTextEdit1.TabIndex = 5;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.acLayoutControlItem2,
            this.acLayoutControlItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.ResourceID = null;
            this.layoutControlGroup1.Size = new System.Drawing.Size(253, 67);
            this.layoutControlGroup1.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            this.layoutControlGroup1.ToolTipID = null;
            this.layoutControlGroup1.UseResourceID = false;
            this.layoutControlGroup1.UseToolTipID = false;
            // 
            // acLayoutControlItem2
            // 
            this.acLayoutControlItem2.Control = this.acTextEdit1;
            this.acLayoutControlItem2.CustomizationFormText = "표시 형태";
            this.acLayoutControlItem2.Location = new System.Drawing.Point(0, 32);
            this.acLayoutControlItem2.Name = "acLayoutControlItem2";
            this.acLayoutControlItem2.ResourceID = "K3PH6I97";
            this.acLayoutControlItem2.Size = new System.Drawing.Size(253, 35);
            this.acLayoutControlItem2.Text = "표시 형태";
            this.acLayoutControlItem2.TextLocation = DevExpress.Utils.Locations.Left;
            this.acLayoutControlItem2.TextSize = new System.Drawing.Size(64, 20);
            this.acLayoutControlItem2.ToolTipID = null;
            this.acLayoutControlItem2.UseResourceID = true;
            this.acLayoutControlItem2.UseToolTipID = false;
            // 
            // acLayoutControlItem1
            // 
            this.acLayoutControlItem1.Control = this.comboBoxEdit1;
            this.acLayoutControlItem1.CustomizationFormText = "마스크 형태";
            this.acLayoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.acLayoutControlItem1.Name = "acLayoutControlItem1";
            this.acLayoutControlItem1.ResourceID = "9QJPOVL2";
            this.acLayoutControlItem1.Size = new System.Drawing.Size(253, 32);
            this.acLayoutControlItem1.Text = "마스크 형태";
            this.acLayoutControlItem1.TextLocation = DevExpress.Utils.Locations.Left;
            this.acLayoutControlItem1.TextSize = new System.Drawing.Size(64, 20);
            this.acLayoutControlItem1.ToolTipID = null;
            this.acLayoutControlItem1.UseResourceID = true;
            this.acLayoutControlItem1.UseToolTipID = false;
            // 
            // acGridViewMaskEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(253, 67);
            this.Controls.Add(this.acLayoutControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "acGridViewMaskEdit";
            this.ResourceID = "YSU2282M";
            
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "마스크";
            
            this.UseResourceID = true;
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControl1)).EndInit();
            this.acLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acTextEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private acLayoutControl acLayoutControl1;
        private ControlManager.acLayoutControlGroup layoutControlGroup1;
        private acTextEdit acTextEdit1;
        private acLayoutControlItem acLayoutControlItem2;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit1;
        private acLayoutControlItem acLayoutControlItem1;
    }
}