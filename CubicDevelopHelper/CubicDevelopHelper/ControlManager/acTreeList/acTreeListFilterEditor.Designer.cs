namespace ControlManager
{
    partial class acTreeListFilterEditor
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
            this.checkedListBoxControl1 = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.acLayoutControl1 = new ControlManager.acLayoutControl();
            this.QuickFindEditor = new ControlManager.acTextEdit();
            this.layoutControlGroup1 = new ControlManager.acLayoutControlGroup();
            this.acLayoutControlItem1 = new ControlManager.acLayoutControlItem();
            this.acLayoutControlItem2 = new ControlManager.acLayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.checkedListBoxControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControl1)).BeginInit();
            this.acLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.QuickFindEditor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // checkedListBoxControl1
            // 
            this.checkedListBoxControl1.HotTrackItems = true;
            this.checkedListBoxControl1.Location = new System.Drawing.Point(6, 38);
            this.checkedListBoxControl1.Name = "checkedListBoxControl1";
            this.checkedListBoxControl1.Size = new System.Drawing.Size(156, 254);
            this.checkedListBoxControl1.StyleController = this.acLayoutControl1;
            this.checkedListBoxControl1.TabIndex = 0;
            // 
            // acLayoutControl1
            // 
            this.acLayoutControl1.AllowCustomizationMenu = false;
            this.acLayoutControl1.AutoScroll = false;
            this.acLayoutControl1.ContainerName = null;
            this.acLayoutControl1.Controls.Add(this.QuickFindEditor);
            this.acLayoutControl1.Controls.Add(this.checkedListBoxControl1);
            this.acLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.acLayoutControl1.LayoutType = ControlManager.acLayoutControl.emLayoutType.NONE;
            this.acLayoutControl1.Location = new System.Drawing.Point(0, 0);
            this.acLayoutControl1.Name = "acLayoutControl1";
            this.acLayoutControl1.ParentControl = null;
            this.acLayoutControl1.Root = this.layoutControlGroup1;
            this.acLayoutControl1.Size = new System.Drawing.Size(167, 297);
            this.acLayoutControl1.TabIndex = 1;
            this.acLayoutControl1.Text = "acLayoutControl1";
            // 
            // QuickFindEditor
            // 
            this.QuickFindEditor.ColumnName = null;
            this.QuickFindEditor.isReadyOnly = false;
            this.QuickFindEditor.isRequired = false;
            this.QuickFindEditor.Location = new System.Drawing.Point(6, 6);
            this.QuickFindEditor.MaskType = ControlManager.acTextEdit.emMaskType.NONE;
            this.QuickFindEditor.Name = "QuickFindEditor";
            this.QuickFindEditor.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.QuickFindEditor.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.QuickFindEditor.Properties.Appearance.Options.UseBackColor = true;
            this.QuickFindEditor.Properties.Appearance.Options.UseForeColor = true;
            this.QuickFindEditor.Size = new System.Drawing.Size(156, 21);
            this.QuickFindEditor.StyleController = this.acLayoutControl1;
            this.QuickFindEditor.TabIndex = 4;
            this.QuickFindEditor.ToolTipID = null;
            this.QuickFindEditor.UseToolTipID = false;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.acLayoutControlItem1,
            this.acLayoutControlItem2});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.ResourceID = null;
            this.layoutControlGroup1.Size = new System.Drawing.Size(167, 297);
            this.layoutControlGroup1.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            this.layoutControlGroup1.ToolTipID = null;
            this.layoutControlGroup1.UseResourceID = false;
            this.layoutControlGroup1.UseToolTipID = false;
            // 
            // acLayoutControlItem1
            // 
            this.acLayoutControlItem1.Control = this.checkedListBoxControl1;
            this.acLayoutControlItem1.CustomizationFormText = "acLayoutControlItem1";
            this.acLayoutControlItem1.Location = new System.Drawing.Point(0, 32);
            this.acLayoutControlItem1.Name = "acLayoutControlItem1";
            this.acLayoutControlItem1.ResourceID = null;
            this.acLayoutControlItem1.Size = new System.Drawing.Size(167, 265);
            this.acLayoutControlItem1.Text = "acLayoutControlItem1";
            this.acLayoutControlItem1.TextLocation = DevExpress.Utils.Locations.Left;
            this.acLayoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.acLayoutControlItem1.TextToControlDistance = 0;
            this.acLayoutControlItem1.TextVisible = false;
            this.acLayoutControlItem1.ToolTipID = null;
            this.acLayoutControlItem1.UseResourceID = false;
            this.acLayoutControlItem1.UseToolTipID = false;
            // 
            // acLayoutControlItem2
            // 
            this.acLayoutControlItem2.Control = this.QuickFindEditor;
            this.acLayoutControlItem2.CustomizationFormText = "acLayoutControlItem2";
            this.acLayoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.acLayoutControlItem2.Name = "acLayoutControlItem2";
            this.acLayoutControlItem2.ResourceID = null;
            this.acLayoutControlItem2.Size = new System.Drawing.Size(167, 32);
            this.acLayoutControlItem2.Text = "acLayoutControlItem2";
            this.acLayoutControlItem2.TextLocation = DevExpress.Utils.Locations.Left;
            this.acLayoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.acLayoutControlItem2.TextToControlDistance = 0;
            this.acLayoutControlItem2.TextVisible = false;
            this.acLayoutControlItem2.ToolTipID = null;
            this.acLayoutControlItem2.UseResourceID = false;
            this.acLayoutControlItem2.UseToolTipID = false;
            // 
            // acGridViewFilterEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(167, 297);
            this.Controls.Add(this.acLayoutControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "acGridViewFilterEditor";
            this.ResourceID = "78ED5IQF";
            
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "빠른 필터";
            
            this.UseResourceID = true;
            ((System.ComponentModel.ISupportInitialize)(this.checkedListBoxControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControl1)).EndInit();
            this.acLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.QuickFindEditor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.CheckedListBoxControl checkedListBoxControl1;
        private acLayoutControl acLayoutControl1;
        private acTextEdit QuickFindEditor;
        private ControlManager.acLayoutControlGroup layoutControlGroup1;
        private acLayoutControlItem acLayoutControlItem1;
        private acLayoutControlItem acLayoutControlItem2;
    }
}