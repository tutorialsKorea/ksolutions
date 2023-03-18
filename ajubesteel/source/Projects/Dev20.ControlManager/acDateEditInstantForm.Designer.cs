namespace ControlManager
{
    partial class acDateEditInstantForm
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
            this.acDateNavigator1 = new ControlManager.acDateNavigator();
            ((System.ComponentModel.ISupportInitialize)(this.acDateNavigator1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acDateNavigator1.CalendarTimeProperties)).BeginInit();
            this.SuspendLayout();
            // 
            // acDateNavigator1
            // 
            this.acDateNavigator1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.acDateNavigator1.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.acDateNavigator1.CellPadding = new System.Windows.Forms.Padding(3);
            this.acDateNavigator1.DateTime = new System.DateTime(2012, 3, 30, 0, 0, 0, 0);
            this.acDateNavigator1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.acDateNavigator1.EditValue = new System.DateTime(2012, 3, 30, 0, 0, 0, 0);
            this.acDateNavigator1.FirstDayOfWeek = System.DayOfWeek.Sunday;
            this.acDateNavigator1.Location = new System.Drawing.Point(0, 0);
            this.acDateNavigator1.MaxCalendar = 12;
            this.acDateNavigator1.Name = "acDateNavigator1";
            this.acDateNavigator1.SelectionMode = DevExpress.XtraEditors.Repository.CalendarSelectionMode.Single;
            this.acDateNavigator1.Size = new System.Drawing.Size(599, 460);
            this.acDateNavigator1.TabIndex = 0;
            // 
            // acDateEditInstantForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 460);
            this.Controls.Add(this.acDateNavigator1);
            this.IconOptions.ShowIcon = false;
            this.Name = "acDateEditInstantForm";
            this.Text = "";
            ((System.ComponentModel.ISupportInitialize)(this.acDateNavigator1.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acDateNavigator1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private acDateNavigator acDateNavigator1;
    }
}