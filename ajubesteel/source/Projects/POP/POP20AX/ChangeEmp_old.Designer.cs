namespace POP
{
    partial class ChangeEmp_old
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gc = new ControlManager.acGridControl();
            this.gv = new ControlManager.acGridView();
            this.acSplitContainerControl1 = new ControlManager.acSplitContainerControl();
            this.acLayoutControl2 = new ControlManager.acLayoutControl();
            this.acLayoutControlGroup1 = new ControlManager.acLayoutControlGroup();
            this.acLayoutControlItem5 = new ControlManager.acLayoutControlItem();
            this.acLayoutControl1 = new ControlManager.acLayoutControl();
            this.btnCancel = new ControlManager.acSimpleButton();
            this.btnOk = new ControlManager.acSimpleButton();
            this.acLayoutControlGroup2 = new ControlManager.acLayoutControlGroup();
            this.acLayoutControlItem1 = new ControlManager.acLayoutControlItem();
            this.acLayoutControlItem2 = new ControlManager.acLayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.btnUp = new ControlManager.acSimpleButton();
            this.acLayoutControlItem3 = new ControlManager.acLayoutControlItem();
            this.btnDown = new ControlManager.acSimpleButton();
            this.acLayoutControlItem4 = new ControlManager.acLayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.gc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acSplitContainerControl1)).BeginInit();
            this.acSplitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControl2)).BeginInit();
            this.acLayoutControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControl1)).BeginInit();
            this.acLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem4)).BeginInit();
            this.SuspendLayout();
            // 
            // gc
            // 
            this.gc.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.gc.Location = new System.Drawing.Point(5, 5);
            this.gc.MainView = this.gv;
            this.gc.Margin = new System.Windows.Forms.Padding(4);
            this.gc.Name = "gc";
            this.gc.Size = new System.Drawing.Size(280, 348);
            this.gc.TabIndex = 6;
            this.gc.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv});
            // 
            // gv
            // 
            this.gv.Appearance.FocusedRow.BackColor = System.Drawing.Color.Black;
            this.gv.Appearance.FocusedRow.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gv.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.gv.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gv.Appearance.FocusedRow.Options.UseFont = true;
            this.gv.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gv.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gv.Appearance.HeaderPanel.Options.UseFont = true;
            this.gv.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.Black;
            this.gv.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gv.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.White;
            this.gv.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gv.Appearance.HideSelectionRow.Options.UseFont = true;
            this.gv.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gv.Appearance.Row.BackColor = System.Drawing.Color.White;
            this.gv.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gv.Appearance.Row.ForeColor = System.Drawing.Color.Black;
            this.gv.Appearance.Row.Options.UseBackColor = true;
            this.gv.Appearance.Row.Options.UseFont = true;
            this.gv.Appearance.Row.Options.UseForeColor = true;
            this.gv.ColumnPanelRowHeight = 0;
            this.gv.GridControl = this.gc;
            this.gv.Name = "gv";
            this.gv.OptionsBehavior.AutoPopulateColumns = false;
            this.gv.OptionsBehavior.Editable = false;
            this.gv.OptionsLayout.Columns.StoreAllOptions = true;
            this.gv.OptionsLayout.StoreAllOptions = true;
            this.gv.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gv.OptionsView.RowAutoHeight = true;
            this.gv.OptionsView.ShowGroupPanel = false;
            this.gv.OptionsView.ShowIndicator = false;
            this.gv.ParentControl = this;
            this.gv.RowHeight = 0;
            this.gv.SaveFileName = null;
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
            this.acSplitContainerControl1.Size = new System.Drawing.Size(340, 418);
            this.acSplitContainerControl1.SplitterPosition = 358;
            this.acSplitContainerControl1.TabIndex = 10;
            this.acSplitContainerControl1.Text = "acSplitContainerControl1";
            // 
            // acLayoutControl2
            // 
            this.acLayoutControl2.AllowCustomizationMenu = false;
            this.acLayoutControl2.ContainerName = null;
            this.acLayoutControl2.Controls.Add(this.btnDown);
            this.acLayoutControl2.Controls.Add(this.btnUp);
            this.acLayoutControl2.Controls.Add(this.gc);
            this.acLayoutControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.acLayoutControl2.LayoutType = ControlManager.acLayoutControl.emLayoutType.NONE;
            this.acLayoutControl2.Location = new System.Drawing.Point(0, 0);
            this.acLayoutControl2.Name = "acLayoutControl2";
            this.acLayoutControl2.ParentControl = null;
            this.acLayoutControl2.Root = this.acLayoutControlGroup1;
            this.acLayoutControl2.Size = new System.Drawing.Size(340, 358);
            this.acLayoutControl2.TabIndex = 10;
            this.acLayoutControl2.Text = "acLayoutControl2";
            // 
            // acLayoutControlGroup1
            // 
            this.acLayoutControlGroup1.CustomizationFormText = "acLayoutControlGroup1";
            this.acLayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.False;
            this.acLayoutControlGroup1.GroupBordersVisible = false;
            this.acLayoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.acLayoutControlItem5,
            this.acLayoutControlItem3,
            this.acLayoutControlItem4});
            this.acLayoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.acLayoutControlGroup1.Name = "acLayoutControlGroup1";
            this.acLayoutControlGroup1.ResourceID = null;
            this.acLayoutControlGroup1.Size = new System.Drawing.Size(340, 358);
            this.acLayoutControlGroup1.Text = "acLayoutControlGroup1";
            this.acLayoutControlGroup1.TextVisible = false;
            this.acLayoutControlGroup1.ToolTipID = null;
            this.acLayoutControlGroup1.UseResourceID = false;
            this.acLayoutControlGroup1.UseToolTipID = false;
            // 
            // acLayoutControlItem5
            // 
            this.acLayoutControlItem5.Control = this.gc;
            this.acLayoutControlItem5.CustomizationFormText = "acLayoutControlItem5";
            this.acLayoutControlItem5.Location = new System.Drawing.Point(0, 0);
            this.acLayoutControlItem5.Name = "acLayoutControlItem5";
            this.acLayoutControlItem5.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.acLayoutControlItem5.ResourceID = null;
            this.acLayoutControlItem5.Size = new System.Drawing.Size(290, 358);
            this.acLayoutControlItem5.Text = "acLayoutControlItem5";
            this.acLayoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.acLayoutControlItem5.TextToControlDistance = 0;
            this.acLayoutControlItem5.TextVisible = false;
            this.acLayoutControlItem5.ToolTipID = null;
            this.acLayoutControlItem5.UseResourceID = false;
            this.acLayoutControlItem5.UseToolTipID = false;
            // 
            // acLayoutControl1
            // 
            this.acLayoutControl1.AllowCustomizationMenu = false;
            this.acLayoutControl1.ContainerName = null;
            this.acLayoutControl1.Controls.Add(this.btnCancel);
            this.acLayoutControl1.Controls.Add(this.btnOk);
            this.acLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.acLayoutControl1.LayoutType = ControlManager.acLayoutControl.emLayoutType.NONE;
            this.acLayoutControl1.Location = new System.Drawing.Point(0, 0);
            this.acLayoutControl1.Name = "acLayoutControl1";
            this.acLayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(1859, 104, 250, 350);
            this.acLayoutControl1.ParentControl = null;
            this.acLayoutControl1.Root = this.acLayoutControlGroup2;
            this.acLayoutControl1.Size = new System.Drawing.Size(340, 55);
            this.acLayoutControl1.TabIndex = 0;
            this.acLayoutControl1.Text = "acLayoutControl1";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(261, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.ResourceID = null;
            this.btnCancel.Size = new System.Drawing.Size(74, 45);
            this.btnCancel.StyleController = this.acLayoutControl1;
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "취소";
            this.btnCancel.ToolTipID = null;
            this.btnCancel.UseResourceID = false;
            this.btnCancel.UseToolTipID = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(176, 5);
            this.btnOk.Name = "btnOk";
            this.btnOk.ResourceID = null;
            this.btnOk.Size = new System.Drawing.Size(75, 45);
            this.btnOk.StyleController = this.acLayoutControl1;
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "확인";
            this.btnOk.ToolTipID = null;
            this.btnOk.UseResourceID = false;
            this.btnOk.UseToolTipID = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // acLayoutControlGroup2
            // 
            this.acLayoutControlGroup2.CustomizationFormText = "Root";
            this.acLayoutControlGroup2.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.False;
            this.acLayoutControlGroup2.GroupBordersVisible = false;
            this.acLayoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.acLayoutControlItem1,
            this.acLayoutControlItem2,
            this.emptySpaceItem1});
            this.acLayoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.acLayoutControlGroup2.Name = "Root";
            this.acLayoutControlGroup2.ResourceID = null;
            this.acLayoutControlGroup2.Size = new System.Drawing.Size(340, 55);
            this.acLayoutControlGroup2.Text = "Root";
            this.acLayoutControlGroup2.TextVisible = false;
            this.acLayoutControlGroup2.ToolTipID = null;
            this.acLayoutControlGroup2.UseResourceID = false;
            this.acLayoutControlGroup2.UseToolTipID = false;
            // 
            // acLayoutControlItem1
            // 
            this.acLayoutControlItem1.Control = this.btnOk;
            this.acLayoutControlItem1.CustomizationFormText = "acLayoutControlItem1";
            this.acLayoutControlItem1.Location = new System.Drawing.Point(171, 0);
            this.acLayoutControlItem1.MinSize = new System.Drawing.Size(1, 1);
            this.acLayoutControlItem1.Name = "acLayoutControlItem1";
            this.acLayoutControlItem1.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.acLayoutControlItem1.ResourceID = null;
            this.acLayoutControlItem1.Size = new System.Drawing.Size(85, 55);
            this.acLayoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.acLayoutControlItem1.Text = "acLayoutControlItem1";
            this.acLayoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.acLayoutControlItem1.TextToControlDistance = 0;
            this.acLayoutControlItem1.TextVisible = false;
            this.acLayoutControlItem1.ToolTipID = null;
            this.acLayoutControlItem1.UseResourceID = false;
            this.acLayoutControlItem1.UseToolTipID = false;
            // 
            // acLayoutControlItem2
            // 
            this.acLayoutControlItem2.Control = this.btnCancel;
            this.acLayoutControlItem2.CustomizationFormText = "acLayoutControlItem2";
            this.acLayoutControlItem2.Location = new System.Drawing.Point(256, 0);
            this.acLayoutControlItem2.MinSize = new System.Drawing.Size(1, 1);
            this.acLayoutControlItem2.Name = "acLayoutControlItem2";
            this.acLayoutControlItem2.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.acLayoutControlItem2.ResourceID = null;
            this.acLayoutControlItem2.Size = new System.Drawing.Size(84, 55);
            this.acLayoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.acLayoutControlItem2.Text = "acLayoutControlItem2";
            this.acLayoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.acLayoutControlItem2.TextToControlDistance = 0;
            this.acLayoutControlItem2.TextVisible = false;
            this.acLayoutControlItem2.ToolTipID = null;
            this.acLayoutControlItem2.UseResourceID = false;
            this.acLayoutControlItem2.UseToolTipID = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(171, 55);
            this.emptySpaceItem1.Text = "emptySpaceItem1";
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // btnUp
            // 
            this.btnUp.Location = new System.Drawing.Point(295, 5);
            this.btnUp.Name = "btnUp";
            this.btnUp.ResourceID = null;
            this.btnUp.Size = new System.Drawing.Size(40, 169);
            this.btnUp.StyleController = this.acLayoutControl2;
            this.btnUp.TabIndex = 7;
            this.btnUp.Text = "▲";
            this.btnUp.ToolTipID = null;
            this.btnUp.UseResourceID = false;
            this.btnUp.UseToolTipID = false;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // acLayoutControlItem3
            // 
            this.acLayoutControlItem3.Control = this.btnUp;
            this.acLayoutControlItem3.CustomizationFormText = "acLayoutControlItem3";
            this.acLayoutControlItem3.Location = new System.Drawing.Point(290, 0);
            this.acLayoutControlItem3.MinSize = new System.Drawing.Size(1, 1);
            this.acLayoutControlItem3.Name = "acLayoutControlItem3";
            this.acLayoutControlItem3.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.acLayoutControlItem3.ResourceID = null;
            this.acLayoutControlItem3.Size = new System.Drawing.Size(50, 179);
            this.acLayoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.acLayoutControlItem3.Text = "acLayoutControlItem3";
            this.acLayoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.acLayoutControlItem3.TextToControlDistance = 0;
            this.acLayoutControlItem3.TextVisible = false;
            this.acLayoutControlItem3.ToolTipID = null;
            this.acLayoutControlItem3.UseResourceID = false;
            this.acLayoutControlItem3.UseToolTipID = false;
            // 
            // btnDown
            // 
            this.btnDown.Location = new System.Drawing.Point(295, 184);
            this.btnDown.Name = "btnDown";
            this.btnDown.ResourceID = null;
            this.btnDown.Size = new System.Drawing.Size(40, 169);
            this.btnDown.StyleController = this.acLayoutControl2;
            this.btnDown.TabIndex = 8;
            this.btnDown.Text = "▼";
            this.btnDown.ToolTipID = null;
            this.btnDown.UseResourceID = false;
            this.btnDown.UseToolTipID = false;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // acLayoutControlItem4
            // 
            this.acLayoutControlItem4.Control = this.btnDown;
            this.acLayoutControlItem4.CustomizationFormText = "acLayoutControlItem4";
            this.acLayoutControlItem4.Location = new System.Drawing.Point(290, 179);
            this.acLayoutControlItem4.MinSize = new System.Drawing.Size(1, 1);
            this.acLayoutControlItem4.Name = "acLayoutControlItem4";
            this.acLayoutControlItem4.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.acLayoutControlItem4.ResourceID = null;
            this.acLayoutControlItem4.Size = new System.Drawing.Size(50, 179);
            this.acLayoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.acLayoutControlItem4.Text = "acLayoutControlItem4";
            this.acLayoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.acLayoutControlItem4.TextToControlDistance = 0;
            this.acLayoutControlItem4.TextVisible = false;
            this.acLayoutControlItem4.ToolTipID = null;
            this.acLayoutControlItem4.UseResourceID = false;
            this.acLayoutControlItem4.UseToolTipID = false;
            // 
            // ChangeEmp_old
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(340, 418);
            this.Controls.Add(this.acSplitContainerControl1);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChangeEmp_old";
            this.ResourceID = "MUTWLOUO";
            this.Text = "작업자 변경";
            this.UseResourceID = true;
            ((System.ComponentModel.ISupportInitialize)(this.gc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acSplitContainerControl1)).EndInit();
            this.acSplitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControl2)).EndInit();
            this.acLayoutControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControl1)).EndInit();
            this.acLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ControlManager.acGridControl gc;
        private ControlManager.acGridView gv;
        private ControlManager.acSplitContainerControl acSplitContainerControl1;
        private ControlManager.acLayoutControl acLayoutControl2;
        private ControlManager.acLayoutControlGroup acLayoutControlGroup1;
        private ControlManager.acLayoutControlItem acLayoutControlItem5;
        private ControlManager.acLayoutControl acLayoutControl1;
        private ControlManager.acSimpleButton btnCancel;
        private ControlManager.acSimpleButton btnOk;
        private ControlManager.acLayoutControlGroup acLayoutControlGroup2;
        private ControlManager.acLayoutControlItem acLayoutControlItem1;
        private ControlManager.acLayoutControlItem acLayoutControlItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private ControlManager.acSimpleButton btnDown;
        private ControlManager.acSimpleButton btnUp;
        private ControlManager.acLayoutControlItem acLayoutControlItem3;
        private ControlManager.acLayoutControlItem acLayoutControlItem4;





    }
}
