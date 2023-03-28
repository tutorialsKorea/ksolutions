namespace ControlManager
{
    partial class acPartSpecTypePopupForm
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
            this.acTextEdit1 = new ControlManager.acTextEdit();
            this.acLayoutControlGroup1 = new ControlManager.acLayoutControlGroup();
            this.acLayoutControlItem1 = new ControlManager.acLayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControl1)).BeginInit();
            this.acLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.acTextEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // acLayoutControl1
            // 
            this.acLayoutControl1.AllowCustomizationMenu = false;
            this.acLayoutControl1.AutoScroll = false;
            this.acLayoutControl1.ContainerName = null;
            this.acLayoutControl1.Controls.Add(this.acTextEdit1);
            this.acLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.acLayoutControl1.LayoutType = ControlManager.acLayoutControl.emLayoutType.NONE;
            this.acLayoutControl1.Location = new System.Drawing.Point(0, 0);
            this.acLayoutControl1.Name = "acLayoutControl1";
            this.acLayoutControl1.ParentControl = null;
            this.acLayoutControl1.Root = this.acLayoutControlGroup1;
            this.acLayoutControl1.Size = new System.Drawing.Size(208, 32);
            this.acLayoutControl1.TabIndex = 4;
            this.acLayoutControl1.Text = "acLayoutControl1";
            // 
            // acTextEdit1
            // 
            this.acTextEdit1.ColumnName = "PART_SPEC";
            this.acTextEdit1.Location = new System.Drawing.Point(6, 6);
            this.acTextEdit1.MaskType = ControlManager.acTextEdit.emMaskType.NONE;
            this.acTextEdit1.Name = "acTextEdit1";
            this.acTextEdit1.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.acTextEdit1.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.acTextEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.acTextEdit1.Properties.Appearance.Options.UseForeColor = true;
            this.acTextEdit1.Size = new System.Drawing.Size(197, 21);
            this.acTextEdit1.StyleController = this.acLayoutControl1;
            this.acTextEdit1.TabIndex = 4;
            // 
            // acLayoutControlGroup1
            // 
            this.acLayoutControlGroup1.CustomizationFormText = "acLayoutControlGroup1";
            this.acLayoutControlGroup1.GroupBordersVisible = false;
            this.acLayoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.acLayoutControlItem1});
            this.acLayoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.acLayoutControlGroup1.Name = "acLayoutControlGroup1";
            this.acLayoutControlGroup1.ResourceID = null;
            this.acLayoutControlGroup1.Size = new System.Drawing.Size(208, 32);
            this.acLayoutControlGroup1.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.acLayoutControlGroup1.Text = "acLayoutControlGroup1";
            this.acLayoutControlGroup1.TextVisible = false;
            this.acLayoutControlGroup1.ToolTipID = null;
            this.acLayoutControlGroup1.UseResourceID = false;
            this.acLayoutControlGroup1.UseToolTipID = false;
            // 
            // acLayoutControlItem1
            // 
            this.acLayoutControlItem1.Control = this.acTextEdit1;
            this.acLayoutControlItem1.CustomizationFormText = "acLayoutControlItem1";
            this.acLayoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.acLayoutControlItem1.MinSize = new System.Drawing.Size(1, 1);
            this.acLayoutControlItem1.Name = "acLayoutControlItem1";
            this.acLayoutControlItem1.ResourceID = null;
            this.acLayoutControlItem1.Size = new System.Drawing.Size(208, 32);
            this.acLayoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.acLayoutControlItem1.Text = "acLayoutControlItem1";
            this.acLayoutControlItem1.TextLocation = DevExpress.Utils.Locations.Left;
            this.acLayoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.acLayoutControlItem1.TextToControlDistance = 0;
            this.acLayoutControlItem1.TextVisible = false;
            this.acLayoutControlItem1.ToolTipID = null;
            this.acLayoutControlItem1.UseResourceID = false;
            this.acLayoutControlItem1.UseToolTipID = false;
            // 
            // acPartSpecTypePopupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(208, 32);
            this.Controls.Add(this.acLayoutControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "acPartSpecTypePopupForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "사양";
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControl1)).EndInit();
            this.acLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.acTextEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private acLayoutControl acLayoutControl1;
        private acLayoutControlGroup acLayoutControlGroup1;
        private acTextEdit acTextEdit1;
        private acLayoutControlItem acLayoutControlItem1;
    }
}