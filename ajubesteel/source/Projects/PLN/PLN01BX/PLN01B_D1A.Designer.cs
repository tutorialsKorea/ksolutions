﻿namespace PLN
{
    partial class PLN01B_D1A
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
			this.pdfViewer1 = new DevExpress.XtraPdfViewer.PdfViewer();
			this.SuspendLayout();
			// 
			// pdfViewer1
			// 
			this.pdfViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pdfViewer1.Location = new System.Drawing.Point(0, 0);
			this.pdfViewer1.Name = "pdfViewer1";
			this.pdfViewer1.Size = new System.Drawing.Size(569, 390);
			this.pdfViewer1.TabIndex = 0;
			// 
			// PLN01B_D1A
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(569, 390);
			this.Controls.Add(this.pdfViewer1);
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
			this.Name = "PLN01B_D1A";
			this.ResourceID = "";
			this.Text = "";
			this.ResumeLayout(false);

        }

		#endregion

		private DevExpress.XtraPdfViewer.PdfViewer pdfViewer1;
	}
}