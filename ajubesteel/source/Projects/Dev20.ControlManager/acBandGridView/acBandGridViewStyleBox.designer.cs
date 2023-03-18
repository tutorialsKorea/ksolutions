namespace ControlManager
{
    partial class acBandGridViewStyleBox
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
            this.acVerticalGrid1 = new ControlManager.acVerticalGrid();
            ((System.ComponentModel.ISupportInitialize)(this.acVerticalGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // acVerticalGrid1
            // 
            this.acVerticalGrid1.DataBindRow = null;
            this.acVerticalGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.acVerticalGrid1.Location = new System.Drawing.Point(0, 0);
            this.acVerticalGrid1.Name = "acVerticalGrid1";
            this.acVerticalGrid1.ParentControl = this;
            this.acVerticalGrid1.RecordWidth = 339;
            this.acVerticalGrid1.Size = new System.Drawing.Size(439, 352);
            this.acVerticalGrid1.TabIndex = 0;
            // 
            // acBandGridViewStyleBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(439, 352);
            this.Controls.Add(this.acVerticalGrid1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "acBandGridViewStyleBox";
            this.ResourceID = "6T0ZDDPE";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "스타일 상자";
            this.UseResourceID = true;
            ((System.ComponentModel.ISupportInitialize)(this.acVerticalGrid1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private acVerticalGrid acVerticalGrid1;

    }
}