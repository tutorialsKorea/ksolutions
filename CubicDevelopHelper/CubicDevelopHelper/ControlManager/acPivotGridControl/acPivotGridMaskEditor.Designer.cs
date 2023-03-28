namespace ControlManager
{
    partial class acPivotGridMaskEdit
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
            this.acLayoutControl1 = new ControlManager.acLayoutControl();
            this.acTextEdit1 = new ControlManager.acTextEdit();
            this.layoutControlGroup1 = new ControlManager.acLayoutControlGroup();
            this.acLayoutControlItem2 = new ControlManager.acLayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControl1)).BeginInit();
            this.acLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.acTextEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // acLayoutControl1
            // 
            this.acLayoutControl1.AllowCustomizationMenu = false;
            this.acLayoutControl1.AutoScroll = false;
            this.acLayoutControl1.Controls.Add(this.acTextEdit1);
            this.acLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.acLayoutControl1.Location = new System.Drawing.Point(0, 0);
            this.acLayoutControl1.Name = "acLayoutControl1";
            this.acLayoutControl1.ParentControl = null;
            this.acLayoutControl1.Root = this.layoutControlGroup1;
            this.acLayoutControl1.Size = new System.Drawing.Size(253, 33);
            this.acLayoutControl1.TabIndex = 0;
            this.acLayoutControl1.Text = "acLayoutControl1";
            // 
            // acTextEdit1
            // 
            this.acTextEdit1.ColumnName = null;
            this.acTextEdit1.isReadyOnly = false;
            this.acTextEdit1.isRequired = false;
            this.acTextEdit1.Location = new System.Drawing.Point(63, 6);
            this.acTextEdit1.MaskType = ControlManager.acTextEdit.emMaskType.NONE;
            this.acTextEdit1.Name = "acTextEdit1";
            this.acTextEdit1.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.acTextEdit1.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.acTextEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.acTextEdit1.Properties.Appearance.Options.UseForeColor = true;
            this.acTextEdit1.Size = new System.Drawing.Size(185, 21);
            this.acTextEdit1.StyleController = this.acLayoutControl1;
            this.acTextEdit1.TabIndex = 5;
            this.acTextEdit1.ToolTipID = null;
            this.acTextEdit1.UseToolTipID = false;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.acLayoutControlItem2});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(253, 33);
            this.layoutControlGroup1.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // acLayoutControlItem2
            // 
            this.acLayoutControlItem2.Control = this.acTextEdit1;
            this.acLayoutControlItem2.CustomizationFormText = "표시 형태";
            this.acLayoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.acLayoutControlItem2.Name = "acLayoutControlItem2";
            this.acLayoutControlItem2.ResourceID = "K3PH6I97";
            this.acLayoutControlItem2.Size = new System.Drawing.Size(253, 33);
            this.acLayoutControlItem2.Text = "표시 형태";
            this.acLayoutControlItem2.TextLocation = DevExpress.Utils.Locations.Left;
            this.acLayoutControlItem2.TextSize = new System.Drawing.Size(52, 20);
            this.acLayoutControlItem2.ToolTipID = null;
            this.acLayoutControlItem2.UseResourceID = true;
            this.acLayoutControlItem2.UseToolTipID = false;
            // 
            // acPivotGridMaskEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(253, 33);
            this.Controls.Add(this.acLayoutControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "acPivotGridMaskEdit";
            this.ResourceID = "YSU2282M";
            this.ShowIcon = false;
            
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "마스크";
            
            this.UseResourceID = true;
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControl1)).EndInit();
            this.acLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.acTextEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private acLayoutControl acLayoutControl1;
        private ControlManager.acLayoutControlGroup layoutControlGroup1;
        private acTextEdit acTextEdit1;
        private acLayoutControlItem acLayoutControlItem2;
    }
}