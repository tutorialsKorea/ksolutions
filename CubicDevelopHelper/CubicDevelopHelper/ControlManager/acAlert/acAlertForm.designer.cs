
namespace ControlManager
{
    partial class acAlertForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(acAlertForm));
            this.lblMsg = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.button1 = new DevExpress.XtraEditors.SimpleButton();
            this.acPictureEdit1 = new ControlManager.acPictureEdit();
            this.pictureBox1 = new ControlManager.acPictureEdit();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acPictureEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMsg
            // 
            this.lblMsg.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblMsg.Location = new System.Drawing.Point(82, 15);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(187, 57);
            this.lblMsg.TabIndex = 0;
            this.lblMsg.Text = "Sucess";
            this.lblMsg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.acPictureEdit1);
            this.layoutControl1.Controls.Add(this.pictureBox1);
            this.layoutControl1.Controls.Add(this.lblMsg);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.layoutControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.layoutControl1.LookAndFeel.UseWindowsXPTheme = true;
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(318, 87);
            this.layoutControl1.TabIndex = 6;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3});
            this.Root.Name = "Root";
            this.Root.Padding = new DevExpress.XtraLayout.Utils.Padding(10, 10, 10, 10);
            this.Root.Size = new System.Drawing.Size(318, 87);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.lblMsg;
            this.layoutControlItem1.Location = new System.Drawing.Point(67, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(197, 67);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // button1
            // 
            this.button1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.button1.Appearance.BackColor2 = System.Drawing.Color.Transparent;
            this.button1.Appearance.Options.UseBackColor = true;
            this.button1.ImageOptions.Image = global::ControlManager.Resource.alert_close;
            this.button1.Location = new System.Drawing.Point(267, 25);
            this.button1.LookAndFeel.SkinMaskColor = System.Drawing.Color.Orange;
            this.button1.LookAndFeel.SkinMaskColor2 = System.Drawing.Color.Orange;
            this.button1.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat;
            this.button1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(35, 35);
            this.button1.TabIndex = 3;
            this.button1.Text = " ";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // acPictureEdit1
            // 
            this.acPictureEdit1.ColumnName = null;
            this.acPictureEdit1.EditValue = global::ControlManager.Resource.alert_close;
            this.acPictureEdit1.isReadyOnly = false;
            this.acPictureEdit1.isRequired = false;
            this.acPictureEdit1.Location = new System.Drawing.Point(279, 15);
            this.acPictureEdit1.Name = "acPictureEdit1";
            this.acPictureEdit1.Properties.AllowFocused = false;
            this.acPictureEdit1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.acPictureEdit1.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.acPictureEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.acPictureEdit1.Properties.Appearance.Options.UseForeColor = true;
            this.acPictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.acPictureEdit1.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.acPictureEdit1.Size = new System.Drawing.Size(24, 57);
            this.acPictureEdit1.StyleController = this.layoutControl1;
            this.acPictureEdit1.TabIndex = 5;
            this.acPictureEdit1.ToolTipID = null;
            this.acPictureEdit1.UseToolTipID = false;
            this.acPictureEdit1.Click += new System.EventHandler(this.acPictureEdit1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.ColumnName = null;
            this.pictureBox1.EditValue = ((object)(resources.GetObject("pictureBox1.EditValue")));
            this.pictureBox1.isReadyOnly = false;
            this.pictureBox1.isRequired = false;
            this.pictureBox1.Location = new System.Drawing.Point(15, 15);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Properties.AllowFocused = false;
            this.pictureBox1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.pictureBox1.Properties.Appearance.Options.UseBackColor = true;
            this.pictureBox1.Properties.Appearance.Options.UseForeColor = true;
            this.pictureBox1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pictureBox1.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pictureBox1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.pictureBox1.Size = new System.Drawing.Size(57, 57);
            this.pictureBox1.StyleController = this.layoutControl1;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.ToolTipID = null;
            this.pictureBox1.UseToolTipID = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.pictureBox1;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(67, 67);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.acPictureEdit1;
            this.layoutControlItem3.Location = new System.Drawing.Point(264, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(34, 67);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // acAlertForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Orange;
            this.ClientSize = new System.Drawing.Size(318, 87);
            this.ControlBox = false;
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "acAlertForm";
            this.Text = "Form_Alert";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acPictureEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.Timer timer1;
        private acPictureEdit pictureBox1;
        private acPictureEdit acPictureEdit1;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.SimpleButton button1;
    }
}