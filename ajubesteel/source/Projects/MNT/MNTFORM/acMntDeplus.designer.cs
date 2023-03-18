namespace MNT
{
    partial class acMntDeplus
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.acRoundLabel4 = new ControlManager.acRoundLabel();
            this.acRoundLabel3 = new ControlManager.acRoundLabel();
            this.acRoundLabel2 = new ControlManager.acRoundLabel();
            this.acRoundLabel1 = new ControlManager.acRoundLabel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.acRoundLabel4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.acRoundLabel3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.acRoundLabel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.acRoundLabel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(116, 136);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // acRoundLabel4
            // 
            this.acRoundLabel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.acRoundLabel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.acRoundLabel4.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.acRoundLabel4.Location = new System.Drawing.Point(3, 95);
            this.acRoundLabel4.Name = "acRoundLabel4";
            this.acRoundLabel4.Size = new System.Drawing.Size(110, 41);
            this.acRoundLabel4.TabIndex = 3;
            this.acRoundLabel4.Text = " ";
            // 
            // acRoundLabel3
            // 
            this.acRoundLabel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.acRoundLabel3.Font = new System.Drawing.Font("굴림", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.acRoundLabel3.ForeColor = System.Drawing.Color.MediumBlue;
            this.acRoundLabel3.Location = new System.Drawing.Point(3, 68);
            this.acRoundLabel3.Name = "acRoundLabel3";
            this.acRoundLabel3.Size = new System.Drawing.Size(110, 27);
            this.acRoundLabel3.TabIndex = 2;
            this.acRoundLabel3.Text = "수주번호";
            // 
            // acRoundLabel2
            // 
            this.acRoundLabel2.BackColor = System.Drawing.SystemColors.Control;
            this.acRoundLabel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.acRoundLabel2.Location = new System.Drawing.Point(3, 34);
            this.acRoundLabel2.Name = "acRoundLabel2";
            this.acRoundLabel2.Size = new System.Drawing.Size(110, 34);
            this.acRoundLabel2.TabIndex = 1;
            this.acRoundLabel2.Text = " ";
            // 
            // acRoundLabel1
            // 
            this.acRoundLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.acRoundLabel1.Font = new System.Drawing.Font("굴림", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.acRoundLabel1.Location = new System.Drawing.Point(3, 0);
            this.acRoundLabel1.Name = "acRoundLabel1";
            this.acRoundLabel1.Size = new System.Drawing.Size(110, 34);
            this.acRoundLabel1.TabIndex = 0;
            this.acRoundLabel1.Text = " ";
            // 
            // acMntDeplus
            // 
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "acMntDeplus";
            this.Size = new System.Drawing.Size(116, 136);
            this.Load += new System.EventHandler(this.acMntDeplus2_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private ControlManager.acRoundLabel acRoundLabel4;
        private ControlManager.acRoundLabel acRoundLabel3;
        private ControlManager.acRoundLabel acRoundLabel2;
        private ControlManager.acRoundLabel acRoundLabel1;
    }
}
