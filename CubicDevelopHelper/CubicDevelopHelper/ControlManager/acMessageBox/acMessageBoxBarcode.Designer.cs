namespace ControlManager
{
    partial class acMessageBoxBarcode
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
            this.layoutControl1 = new ControlManager.acLayoutControl();
            this.acTextEdit1 = new ControlManager.acTextEdit();
            this.layoutControlGroup1 = new ControlManager.acLayoutControlGroup();
            this.acLayoutControlItem1 = new ControlManager.acLayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.acTextEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.AllowCustomizationMenu = false;
            this.layoutControl1.AutoScroll = false;
            this.layoutControl1.ContainerName = null;
            this.layoutControl1.Controls.Add(this.acTextEdit1);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.LayoutType = ControlManager.acLayoutControl.emLayoutType.NONE;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.ParentControl = null;
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(302, 35);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // acTextEdit1
            // 
            this.acTextEdit1.ColumnName = "BARCODE";
            this.acTextEdit1.Enabled = false;
            this.acTextEdit1.Location = new System.Drawing.Point(7, 7);
            this.acTextEdit1.MaskType = ControlManager.acTextEdit.emMaskType.NONE;
            this.acTextEdit1.Name = "acTextEdit1";
            this.acTextEdit1.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.acTextEdit1.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.acTextEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.acTextEdit1.Properties.Appearance.Options.UseForeColor = true;
            this.acTextEdit1.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.WhiteSmoke;
            this.acTextEdit1.Properties.AppearanceReadOnly.ForeColor = System.Drawing.Color.Black;
            this.acTextEdit1.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.acTextEdit1.Properties.AppearanceReadOnly.Options.UseForeColor = true;
            this.acTextEdit1.Size = new System.Drawing.Size(289, 21);
            this.acTextEdit1.StyleController = this.layoutControl1;
            this.acTextEdit1.TabIndex = 4;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.acLayoutControlItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.ResourceID = null;
            this.layoutControlGroup1.Size = new System.Drawing.Size(302, 35);
            this.layoutControlGroup1.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Text = "Root";
            this.layoutControlGroup1.TextVisible = false;
            this.layoutControlGroup1.ToolTipID = null;
            this.layoutControlGroup1.UseResourceID = false;
            this.layoutControlGroup1.UseToolTipID = false;
            // 
            // acLayoutControlItem1
            // 
            this.acLayoutControlItem1.Control = this.acTextEdit1;
            this.acLayoutControlItem1.CustomizationFormText = "acLayoutControlItem1";
            this.acLayoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.acLayoutControlItem1.Name = "acLayoutControlItem1";
            this.acLayoutControlItem1.ResourceID = null;
            this.acLayoutControlItem1.Size = new System.Drawing.Size(300, 33);
            this.acLayoutControlItem1.Text = "acLayoutControlItem1";
            this.acLayoutControlItem1.TextLocation = DevExpress.Utils.Locations.Left;
            this.acLayoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.acLayoutControlItem1.TextToControlDistance = 0;
            this.acLayoutControlItem1.TextVisible = false;
            this.acLayoutControlItem1.ToolTipID = null;
            this.acLayoutControlItem1.UseResourceID = false;
            this.acLayoutControlItem1.UseToolTipID = false;
            // 
            // acMessageBoxBarcode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(302, 35);
            this.Controls.Add(this.layoutControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "acMessageBoxBarcode";
            this.ShowIcon = false;
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.acTextEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ControlManager.acLayoutControl layoutControl1;
        private ControlManager.acLayoutControlGroup layoutControlGroup1;
        private acTextEdit acTextEdit1;
        private acLayoutControlItem acLayoutControlItem1;
    }
}