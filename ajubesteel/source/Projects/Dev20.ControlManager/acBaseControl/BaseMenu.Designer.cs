namespace ControlManager
{
    partial class BaseMenu 
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
            this.pnlScreenBase = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.pnlScreenBase)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlScreenBase
            // 
            this.pnlScreenBase.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlScreenBase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlScreenBase.Location = new System.Drawing.Point(0, 0);
            this.pnlScreenBase.Name = "pnlScreenBase";
            this.pnlScreenBase.Size = new System.Drawing.Size(800, 600);
            this.pnlScreenBase.TabIndex = 0;
            // 
            // BaseMenu
            // 
            this.Controls.Add(this.pnlScreenBase);
            this.Name = "BaseMenu";
            this.Size = new System.Drawing.Size(800, 600);
            this.Load += new System.EventHandler(this.BaseMenu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pnlScreenBase)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public DevExpress.XtraEditors.PanelControl pnlScreenBase;


    }
}
