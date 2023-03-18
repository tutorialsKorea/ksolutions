namespace POP
{
    partial class BomList
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
            this.acSplitContainerControl1 = new ControlManager.acSplitContainerControl();
            this.acTreeList1 = new ControlManager.acTreeList();
            this.acLayoutControl1 = new ControlManager.acLayoutControl();
            this.btnCancel = new ControlManager.acSimpleButton();
            this.Root = new ControlManager.acLayoutControlGroup();
            this.acLayoutControlItem1 = new ControlManager.acLayoutControlItem();
            this.acLayoutControlItem2 = new ControlManager.acLayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.acSplitContainerControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acSplitContainerControl1.Panel1)).BeginInit();
            this.acSplitContainerControl1.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.acSplitContainerControl1.Panel2)).BeginInit();
            this.acSplitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.acTreeList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControl1)).BeginInit();
            this.acLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // acSplitContainerControl1
            // 
            this.acSplitContainerControl1.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.None;
            this.acSplitContainerControl1.Horizontal = false;
            this.acSplitContainerControl1.Location = new System.Drawing.Point(5, 70);
            this.acSplitContainerControl1.Name = "acSplitContainerControl1";
            // 
            // acSplitContainerControl1.Panel1
            // 
            this.acSplitContainerControl1.Panel1.Controls.Add(this.acTreeList1);
            this.acSplitContainerControl1.Panel1.Text = "Panel1";
            // 
            // acSplitContainerControl1.Panel2
            // 
            this.acSplitContainerControl1.Panel2.Text = "Panel2";
            this.acSplitContainerControl1.PanelVisibility = DevExpress.XtraEditors.SplitPanelVisibility.Panel1;
            this.acSplitContainerControl1.ParentControl = null;
            this.acSplitContainerControl1.Size = new System.Drawing.Size(991, 331);
            this.acSplitContainerControl1.SplitterPosition = 230;
            this.acSplitContainerControl1.TabIndex = 4;
            this.acSplitContainerControl1.Text = "acSplitContainerControl1";
            // 
            // acTreeList1
            // 
            this.acTreeList1.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black;
            this.acTreeList1.Appearance.FocusedRow.Options.UseForeColor = true;
            this.acTreeList1.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.acTreeList1.Appearance.SelectedRow.Options.UseForeColor = true;
            this.acTreeList1.ColumnPanelRowHeight = 30;
            this.acTreeList1.DataSource = null;
            this.acTreeList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.acTreeList1.IndicatorWidth = 30;
            this.acTreeList1.Location = new System.Drawing.Point(0, 0);
            this.acTreeList1.Name = "acTreeList1";
            this.acTreeList1.OptionsMenu.ShowExpandCollapseItems = false;
            this.acTreeList1.ParentControl = this.acLayoutControl1;
            this.acTreeList1.RowHeight = 20;
            this.acTreeList1.SaveFileName = null;
            this.acTreeList1.Size = new System.Drawing.Size(991, 331);
            this.acTreeList1.TabIndex = 0;
            // 
            // acLayoutControl1
            // 
            this.acLayoutControl1.AllowCustomization = false;
            this.acLayoutControl1.ContainerName = null;
            this.acLayoutControl1.Controls.Add(this.btnCancel);
            this.acLayoutControl1.Controls.Add(this.acSplitContainerControl1);
            this.acLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.acLayoutControl1.LayoutType = ControlManager.acLayoutControl.emLayoutType.NONE;
            this.acLayoutControl1.Location = new System.Drawing.Point(0, 0);
            this.acLayoutControl1.Name = "acLayoutControl1";
            this.acLayoutControl1.ParentControl = null;
            this.acLayoutControl1.Root = this.Root;
            this.acLayoutControl1.Size = new System.Drawing.Size(1001, 406);
            this.acLayoutControl1.TabIndex = 5;
            this.acLayoutControl1.Text = "acLayoutControl1";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(889, 5);
            this.btnCancel.MinimumSize = new System.Drawing.Size(106, 55);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.ResourceID = null;
            this.btnCancel.Size = new System.Drawing.Size(107, 55);
            this.btnCancel.StyleController = this.acLayoutControl1;
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "닫기";
            this.btnCancel.ToolTipID = null;
            this.btnCancel.UseResourceID = false;
            this.btnCancel.UseToolTipID = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.False;
            this.Root.GroupBordersVisible = false;
            this.Root.IsHeader = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.acLayoutControlItem1,
            this.acLayoutControlItem2,
            this.emptySpaceItem1});
            this.Root.Name = "Root";
            this.Root.ResourceID = null;
            this.Root.Size = new System.Drawing.Size(1001, 406);
            this.Root.TextVisible = false;
            this.Root.ToolTipID = null;
            this.Root.UseResourceID = false;
            this.Root.UseToolTipID = false;
            // 
            // acLayoutControlItem1
            // 
            this.acLayoutControlItem1.Control = this.acSplitContainerControl1;
            this.acLayoutControlItem1.CustomizationFormText = "acLayoutControlItem1";
            this.acLayoutControlItem1.IsHeader = false;
            this.acLayoutControlItem1.IsTitle = false;
            this.acLayoutControlItem1.Location = new System.Drawing.Point(0, 65);
            this.acLayoutControlItem1.Name = "acLayoutControlItem1";
            this.acLayoutControlItem1.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.acLayoutControlItem1.ResourceID = null;
            this.acLayoutControlItem1.Size = new System.Drawing.Size(1001, 341);
            this.acLayoutControlItem1.Text = "acLayoutControlItem1";
            this.acLayoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.acLayoutControlItem1.TextVisible = false;
            this.acLayoutControlItem1.ToolTipID = null;
            this.acLayoutControlItem1.ToolTipStdCode = null;
            this.acLayoutControlItem1.UseResourceID = false;
            this.acLayoutControlItem1.UseToolTipID = false;
            // 
            // acLayoutControlItem2
            // 
            this.acLayoutControlItem2.Control = this.btnCancel;
            this.acLayoutControlItem2.CustomizationFormText = "acLayoutControlItem2";
            this.acLayoutControlItem2.IsHeader = false;
            this.acLayoutControlItem2.IsTitle = false;
            this.acLayoutControlItem2.Location = new System.Drawing.Point(884, 0);
            this.acLayoutControlItem2.MaxSize = new System.Drawing.Size(117, 65);
            this.acLayoutControlItem2.MinSize = new System.Drawing.Size(117, 65);
            this.acLayoutControlItem2.Name = "acLayoutControlItem2";
            this.acLayoutControlItem2.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.acLayoutControlItem2.ResourceID = null;
            this.acLayoutControlItem2.Size = new System.Drawing.Size(117, 65);
            this.acLayoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.acLayoutControlItem2.Text = "acLayoutControlItem2";
            this.acLayoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.acLayoutControlItem2.TextVisible = false;
            this.acLayoutControlItem2.ToolTipID = null;
            this.acLayoutControlItem2.ToolTipStdCode = null;
            this.acLayoutControlItem2.UseResourceID = false;
            this.acLayoutControlItem2.UseToolTipID = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(884, 65);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // BomList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1001, 406);
            this.Controls.Add(this.acLayoutControl1);
            this.IconOptions.ShowIcon = false;
            this.Name = "BomList";
            this.ResourceID = "";
            this.Text = "BOM현황";
            ((System.ComponentModel.ISupportInitialize)(this.acSplitContainerControl1.Panel1)).EndInit();
            this.acSplitContainerControl1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.acSplitContainerControl1.Panel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acSplitContainerControl1)).EndInit();
            this.acSplitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.acTreeList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControl1)).EndInit();
            this.acLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private ControlManager.acSplitContainerControl acSplitContainerControl1;
        private ControlManager.acLayoutControl acLayoutControl1;
        private ControlManager.acLayoutControlGroup Root;
        private ControlManager.acLayoutControlItem acLayoutControlItem1;
        private ControlManager.acSimpleButton btnCancel;
        private ControlManager.acLayoutControlItem acLayoutControlItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private ControlManager.acTreeList acTreeList1;
    }
}