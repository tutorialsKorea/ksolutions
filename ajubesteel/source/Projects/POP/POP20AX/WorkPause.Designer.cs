namespace POP
{
    partial class WorkPause
    {
        /// <summary>
        /// �ʼ� �����̳� �����Դϴ�.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// ��� ���� ��� ���ҽ��� �����մϴ�.
        /// </summary>
        /// <param name="disposing">�����Ǵ� ���ҽ��� �����ؾ� �ϸ� true�̰�, �׷��� ������ false�Դϴ�.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form �����̳ʿ��� ������ �ڵ�

        /// <summary>
        /// �����̳� ������ �ʿ��� �޼����Դϴ�.
        /// �� �޼����� ������ �ڵ� ������� �������� ���ʽÿ�.
        /// </summary>
        private void InitializeComponent()
        {
			this.acLayoutControl1 = new ControlManager.acLayoutControl();
			this.button2 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
			this.acLayoutControlItem1 = new ControlManager.acLayoutControlItem();
			this.acLayoutControlItem2 = new ControlManager.acLayoutControlItem();
			this.acSplitContainerControl1 = new ControlManager.acSplitContainerControl();
			this.acLayoutControl2 = new ControlManager.acLayoutControl();
			this.acLookupEdit1 = new ControlManager.acLookupEdit();
			this.acLayoutControlGroup1 = new ControlManager.acLayoutControlGroup();
			this.acLayoutControlItem3 = new ControlManager.acLayoutControlItem();
			((System.ComponentModel.ISupportInitialize)(this.acLayoutControl1)).BeginInit();
			this.acLayoutControl1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.acSplitContainerControl1)).BeginInit();
			this.acSplitContainerControl1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.acLayoutControl2)).BeginInit();
			this.acLayoutControl2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.acLookupEdit1.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.acLayoutControlGroup1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem3)).BeginInit();
			this.SuspendLayout();
			// 
			// acLayoutControl1
			// 
			this.acLayoutControl1.AllowCustomizationMenu = false;
			this.acLayoutControl1.AutoScroll = false;
			this.acLayoutControl1.ContainerName = null;
			this.acLayoutControl1.Controls.Add(this.button2);
			this.acLayoutControl1.Controls.Add(this.button1);
			this.acLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.acLayoutControl1.LayoutType = ControlManager.acLayoutControl.emLayoutType.NONE;
			this.acLayoutControl1.Location = new System.Drawing.Point(0, 0);
			this.acLayoutControl1.Name = "acLayoutControl1";
			this.acLayoutControl1.ParentControl = null;
			this.acLayoutControl1.Root = this.layoutControlGroup2;
			this.acLayoutControl1.Size = new System.Drawing.Size(236, 116);
			this.acLayoutControl1.TabIndex = 0;
			this.acLayoutControl1.Text = "acLayoutControl1";
			// 
			// button2
			// 
			this.button2.BackgroundImage = global::POP.Resource.Cancel2;
			this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.button2.FlatAppearance.BorderSize = 0;
			this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button2.Location = new System.Drawing.Point(131, 5);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(100, 106);
			this.button2.TabIndex = 5;
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button1
			// 
			this.button1.BackgroundImage = global::POP.Resource.Ok;
			this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.button1.FlatAppearance.BorderSize = 0;
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button1.Location = new System.Drawing.Point(5, 5);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(116, 106);
			this.button1.TabIndex = 4;
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// layoutControlGroup2
			// 
			this.layoutControlGroup2.CustomizationFormText = "Root";
			this.layoutControlGroup2.GroupBordersVisible = false;
			this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.acLayoutControlItem1,
            this.acLayoutControlItem2});
			this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
			this.layoutControlGroup2.Name = "Root";
			this.layoutControlGroup2.Size = new System.Drawing.Size(236, 116);
			this.layoutControlGroup2.Text = "Root";
			this.layoutControlGroup2.TextVisible = false;
			// 
			// acLayoutControlItem1
			// 
			this.acLayoutControlItem1.Control = this.button1;
			this.acLayoutControlItem1.CustomizationFormText = "acLayoutControlItem1";
			this.acLayoutControlItem1.IsHeader = false;
			this.acLayoutControlItem1.IsTitle = false;
			this.acLayoutControlItem1.Location = new System.Drawing.Point(0, 0);
			this.acLayoutControlItem1.Name = "acLayoutControlItem1";
			this.acLayoutControlItem1.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
			this.acLayoutControlItem1.ResourceID = null;
			this.acLayoutControlItem1.Size = new System.Drawing.Size(126, 116);
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
			this.acLayoutControlItem2.Control = this.button2;
			this.acLayoutControlItem2.CustomizationFormText = "acLayoutControlItem2";
			this.acLayoutControlItem2.IsHeader = false;
			this.acLayoutControlItem2.IsTitle = false;
			this.acLayoutControlItem2.Location = new System.Drawing.Point(126, 0);
			this.acLayoutControlItem2.Name = "acLayoutControlItem2";
			this.acLayoutControlItem2.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
			this.acLayoutControlItem2.ResourceID = null;
			this.acLayoutControlItem2.Size = new System.Drawing.Size(110, 116);
			this.acLayoutControlItem2.Text = "acLayoutControlItem2";
			this.acLayoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
			this.acLayoutControlItem2.TextVisible = false;
			this.acLayoutControlItem2.ToolTipID = null;
			this.acLayoutControlItem2.ToolTipStdCode = null;
			this.acLayoutControlItem2.UseResourceID = false;
			this.acLayoutControlItem2.UseToolTipID = false;
			// 
			// acSplitContainerControl1
			// 
			this.acSplitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.acSplitContainerControl1.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.None;
			this.acSplitContainerControl1.Horizontal = false;
			this.acSplitContainerControl1.Location = new System.Drawing.Point(0, 0);
			this.acSplitContainerControl1.Name = "acSplitContainerControl1";
			this.acSplitContainerControl1.Panel1.Controls.Add(this.acLayoutControl2);
			this.acSplitContainerControl1.Panel1.Text = "Panel1";
			this.acSplitContainerControl1.Panel2.Controls.Add(this.acLayoutControl1);
			this.acSplitContainerControl1.Panel2.Text = "Panel2";
			this.acSplitContainerControl1.ParentControl = this;
			this.acSplitContainerControl1.Size = new System.Drawing.Size(236, 149);
			this.acSplitContainerControl1.SplitterPosition = 28;
			this.acSplitContainerControl1.TabIndex = 10;
			this.acSplitContainerControl1.Text = "acSplitContainerControl1";
			// 
			// acLayoutControl2
			// 
			this.acLayoutControl2.AllowCustomizationMenu = false;
			this.acLayoutControl2.AutoScroll = false;
			this.acLayoutControl2.ContainerName = null;
			this.acLayoutControl2.Controls.Add(this.acLookupEdit1);
			this.acLayoutControl2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.acLayoutControl2.LayoutType = ControlManager.acLayoutControl.emLayoutType.NONE;
			this.acLayoutControl2.Location = new System.Drawing.Point(0, 0);
			this.acLayoutControl2.Name = "acLayoutControl2";
			this.acLayoutControl2.ParentControl = null;
			this.acLayoutControl2.Root = this.acLayoutControlGroup1;
			this.acLayoutControl2.Size = new System.Drawing.Size(236, 28);
			this.acLayoutControl2.TabIndex = 0;
			this.acLayoutControl2.Text = "acLayoutControl2";
			// 
			// acLookupEdit1
			// 
			this.acLookupEdit1.ColumnName = null;
			this.acLookupEdit1.DefaultValueType = ControlManager.acLookupEdit.emDefaultValueType.NONE;
			this.acLookupEdit1.isReadyOnly = false;
			this.acLookupEdit1.isRequired = false;
			this.acLookupEdit1.Location = new System.Drawing.Point(5, 5);
			this.acLookupEdit1.Name = "acLookupEdit1";
			this.acLookupEdit1.Properties.Appearance.BackColor = System.Drawing.Color.White;
			this.acLookupEdit1.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
			this.acLookupEdit1.Properties.Appearance.Options.UseBackColor = true;
			this.acLookupEdit1.Properties.Appearance.Options.UseForeColor = true;
			this.acLookupEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.acLookupEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.acLookupEdit1.Properties.NullText = "";
			this.acLookupEdit1.Properties.ShowHeader = false;
			this.acLookupEdit1.Size = new System.Drawing.Size(226, 20);
			this.acLookupEdit1.StyleController = this.acLayoutControl2;
			this.acLookupEdit1.TabIndex = 4;
			this.acLookupEdit1.ToolTipID = null;
			this.acLookupEdit1.UseToolTipID = false;
			this.acLookupEdit1.Value = null;
			// 
			// acLayoutControlGroup1
			// 
			this.acLayoutControlGroup1.CustomizationFormText = "acLayoutControlGroup1";
			this.acLayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.False;
			this.acLayoutControlGroup1.GroupBordersVisible = false;
			this.acLayoutControlGroup1.IsHeader = false;
			this.acLayoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.acLayoutControlItem3});
			this.acLayoutControlGroup1.Location = new System.Drawing.Point(0, 0);
			this.acLayoutControlGroup1.Name = "acLayoutControlGroup1";
			this.acLayoutControlGroup1.ResourceID = null;
			this.acLayoutControlGroup1.Size = new System.Drawing.Size(236, 30);
			this.acLayoutControlGroup1.Text = "acLayoutControlGroup1";
			this.acLayoutControlGroup1.TextVisible = false;
			this.acLayoutControlGroup1.ToolTipID = null;
			this.acLayoutControlGroup1.UseResourceID = false;
			this.acLayoutControlGroup1.UseToolTipID = false;
			// 
			// acLayoutControlItem3
			// 
			this.acLayoutControlItem3.Control = this.acLookupEdit1;
			this.acLayoutControlItem3.CustomizationFormText = "acLayoutControlItem3";
			this.acLayoutControlItem3.IsHeader = false;
			this.acLayoutControlItem3.IsTitle = false;
			this.acLayoutControlItem3.Location = new System.Drawing.Point(0, 0);
			this.acLayoutControlItem3.Name = "acLayoutControlItem3";
			this.acLayoutControlItem3.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
			this.acLayoutControlItem3.ResourceID = null;
			this.acLayoutControlItem3.Size = new System.Drawing.Size(236, 30);
			this.acLayoutControlItem3.Text = "acLayoutControlItem3";
			this.acLayoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
			this.acLayoutControlItem3.TextVisible = false;
			this.acLayoutControlItem3.ToolTipID = null;
			this.acLayoutControlItem3.ToolTipStdCode = null;
			this.acLayoutControlItem3.UseResourceID = false;
			this.acLayoutControlItem3.UseToolTipID = false;
			// 
			// WorkPause
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
			this.ClientSize = new System.Drawing.Size(236, 149);
			this.Controls.Add(this.acSplitContainerControl1);
			this.Margin = new System.Windows.Forms.Padding(5);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "WorkPause";
			this.ResourceID = "";
			this.Text = "�۾�����";
			((System.ComponentModel.ISupportInitialize)(this.acLayoutControl1)).EndInit();
			this.acLayoutControl1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.acSplitContainerControl1)).EndInit();
			this.acSplitContainerControl1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.acLayoutControl2)).EndInit();
			this.acLayoutControl2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.acLookupEdit1.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.acLayoutControlGroup1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem3)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private ControlManager.acSplitContainerControl acSplitContainerControl1;
        private ControlManager.acLayoutControl acLayoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private ControlManager.acLayoutControl acLayoutControl2;
        private ControlManager.acLayoutControlGroup acLayoutControlGroup1;
        private ControlManager.acLookupEdit acLookupEdit1;
        private ControlManager.acLayoutControlItem acLayoutControlItem3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private ControlManager.acLayoutControlItem acLayoutControlItem1;
        private ControlManager.acLayoutControlItem acLayoutControlItem2;





    }
}
