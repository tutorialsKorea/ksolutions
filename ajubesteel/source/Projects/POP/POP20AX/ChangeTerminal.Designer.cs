namespace POP
{
    partial class ChangeTerminal
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
			this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
			this.btnDown = new ControlManager.acSimpleButton();
			this.acLayoutControl1 = new ControlManager.acLayoutControl();
			this.gc = new ControlManager.acGridControl();
			this.gv = new ControlManager.acGridView();
			this.btnUp = new ControlManager.acSimpleButton();
			this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
			this.acLayoutControlItem1 = new ControlManager.acLayoutControlItem();
			this.acLayoutControlItem2 = new ControlManager.acLayoutControlItem();
			this.acLayoutControlItem3 = new ControlManager.acLayoutControlItem();
			this.layoutControl1 = new ControlManager.acLayoutControl();
			this.acSimpleButton2 = new ControlManager.acSimpleButton();
			this.acSimpleButton1 = new ControlManager.acSimpleButton();
			this.layoutControlGroup1 = new ControlManager.acLayoutControlGroup();
			this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
			this.layoutControlItem5 = new ControlManager.acLayoutControlItem();
			this.layoutControlItem4 = new ControlManager.acLayoutControlItem();
			this.acSplitContainerControl1 = new ControlManager.acSplitContainerControl();
			((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.acLayoutControl1)).BeginInit();
			this.acLayoutControl1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gc)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gv)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
			this.layoutControl1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.acSplitContainerControl1)).BeginInit();
			this.acSplitContainerControl1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panelControl3
			// 
			this.panelControl3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelControl3.Location = new System.Drawing.Point(3, 3);
			this.panelControl3.Margin = new System.Windows.Forms.Padding(4);
			this.panelControl3.Name = "panelControl3";
			this.panelControl3.Size = new System.Drawing.Size(1185, 450);
			this.panelControl3.TabIndex = 2;
			// 
			// btnDown
			// 
			this.btnDown.AllowFocus = false;
			this.btnDown.Location = new System.Drawing.Point(844, 173);
			this.btnDown.Margin = new System.Windows.Forms.Padding(4);
			this.btnDown.Name = "btnDown";
			this.btnDown.ResourceID = null;
			this.btnDown.Size = new System.Drawing.Size(64, 185);
			this.btnDown.StyleController = this.acLayoutControl1;
			this.btnDown.TabIndex = 8;
			this.btnDown.Text = "▼";
			this.btnDown.ToolTipID = null;
			this.btnDown.UseResourceID = false;
			this.btnDown.UseToolTipID = false;
			this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
			// 
			// acLayoutControl1
			// 
			this.acLayoutControl1.AllowCustomizationMenu = false;
			this.acLayoutControl1.AutoScroll = false;
			this.acLayoutControl1.ContainerName = null;
			this.acLayoutControl1.Controls.Add(this.gc);
			this.acLayoutControl1.Controls.Add(this.btnUp);
			this.acLayoutControl1.Controls.Add(this.btnDown);
			this.acLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.acLayoutControl1.LayoutType = ControlManager.acLayoutControl.emLayoutType.NONE;
			this.acLayoutControl1.Location = new System.Drawing.Point(0, 0);
			this.acLayoutControl1.Name = "acLayoutControl1";
			this.acLayoutControl1.ParentControl = null;
			this.acLayoutControl1.Root = this.layoutControlGroup2;
			this.acLayoutControl1.Size = new System.Drawing.Size(913, 363);
			this.acLayoutControl1.TabIndex = 11;
			this.acLayoutControl1.Text = "acLayoutControl1";
			// 
			// gc
			// 
			this.gc.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
			this.gc.Location = new System.Drawing.Point(5, 5);
			this.gc.MainView = this.gv;
			this.gc.Margin = new System.Windows.Forms.Padding(4);
			this.gc.Name = "gc";
			this.gc.Size = new System.Drawing.Size(829, 353);
			this.gc.TabIndex = 9;
			this.gc.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv});
			// 
			// gv
			// 
			this.gv.Appearance.FocusedRow.BackColor = System.Drawing.Color.Black;
			this.gv.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
			this.gv.Appearance.FocusedRow.Options.UseBackColor = true;
			this.gv.Appearance.FocusedRow.Options.UseForeColor = true;
			this.gv.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.Black;
			this.gv.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.White;
			this.gv.Appearance.HideSelectionRow.Options.UseBackColor = true;
			this.gv.Appearance.HideSelectionRow.Options.UseForeColor = true;
			this.gv.Appearance.Row.BackColor = System.Drawing.Color.White;
			this.gv.Appearance.Row.ForeColor = System.Drawing.Color.Black;
			this.gv.Appearance.Row.Options.UseBackColor = true;
			this.gv.Appearance.Row.Options.UseForeColor = true;
			this.gv.ColumnPanelRowHeight = 0;
			this.gv.GridControl = this.gc;
			this.gv.IsUserStyle = false;
			this.gv.Name = "gv";
			this.gv.NoApplyEditableCellColor = false;
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
			// btnUp
			// 
			this.btnUp.AllowFocus = false;
			this.btnUp.Location = new System.Drawing.Point(844, 5);
			this.btnUp.Margin = new System.Windows.Forms.Padding(4);
			this.btnUp.Name = "btnUp";
			this.btnUp.ResourceID = null;
			this.btnUp.Size = new System.Drawing.Size(64, 158);
			this.btnUp.StyleController = this.acLayoutControl1;
			this.btnUp.TabIndex = 7;
			this.btnUp.Text = "▲";
			this.btnUp.ToolTipID = null;
			this.btnUp.UseResourceID = false;
			this.btnUp.UseToolTipID = false;
			this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
			// 
			// layoutControlGroup2
			// 
			this.layoutControlGroup2.CustomizationFormText = "Root";
			this.layoutControlGroup2.GroupBordersVisible = false;
			this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.acLayoutControlItem1,
            this.acLayoutControlItem2,
            this.acLayoutControlItem3});
			this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
			this.layoutControlGroup2.Name = "Root";
			this.layoutControlGroup2.Size = new System.Drawing.Size(913, 363);
			this.layoutControlGroup2.Text = "Root";
			this.layoutControlGroup2.TextVisible = false;
			// 
			// acLayoutControlItem1
			// 
			this.acLayoutControlItem1.Control = this.gc;
			this.acLayoutControlItem1.CustomizationFormText = "acLayoutControlItem1";
			this.acLayoutControlItem1.IsHeader = false;
			this.acLayoutControlItem1.IsTitle = false;
			this.acLayoutControlItem1.Location = new System.Drawing.Point(0, 0);
			this.acLayoutControlItem1.Name = "acLayoutControlItem1";
			this.acLayoutControlItem1.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
			this.acLayoutControlItem1.ResourceID = null;
			this.acLayoutControlItem1.Size = new System.Drawing.Size(839, 363);
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
			this.acLayoutControlItem2.Control = this.btnUp;
			this.acLayoutControlItem2.CustomizationFormText = "acLayoutControlItem2";
			this.acLayoutControlItem2.IsHeader = false;
			this.acLayoutControlItem2.IsTitle = false;
			this.acLayoutControlItem2.Location = new System.Drawing.Point(839, 0);
			this.acLayoutControlItem2.MinSize = new System.Drawing.Size(34, 34);
			this.acLayoutControlItem2.Name = "acLayoutControlItem2";
			this.acLayoutControlItem2.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
			this.acLayoutControlItem2.ResourceID = null;
			this.acLayoutControlItem2.Size = new System.Drawing.Size(74, 168);
			this.acLayoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
			this.acLayoutControlItem2.Text = "acLayoutControlItem2";
			this.acLayoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
			this.acLayoutControlItem2.TextVisible = false;
			this.acLayoutControlItem2.ToolTipID = null;
			this.acLayoutControlItem2.ToolTipStdCode = null;
			this.acLayoutControlItem2.UseResourceID = false;
			this.acLayoutControlItem2.UseToolTipID = false;
			// 
			// acLayoutControlItem3
			// 
			this.acLayoutControlItem3.Control = this.btnDown;
			this.acLayoutControlItem3.CustomizationFormText = "acLayoutControlItem3";
			this.acLayoutControlItem3.IsHeader = false;
			this.acLayoutControlItem3.IsTitle = false;
			this.acLayoutControlItem3.Location = new System.Drawing.Point(839, 168);
			this.acLayoutControlItem3.MinSize = new System.Drawing.Size(34, 34);
			this.acLayoutControlItem3.Name = "acLayoutControlItem3";
			this.acLayoutControlItem3.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
			this.acLayoutControlItem3.ResourceID = null;
			this.acLayoutControlItem3.Size = new System.Drawing.Size(74, 195);
			this.acLayoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
			this.acLayoutControlItem3.Text = "acLayoutControlItem3";
			this.acLayoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
			this.acLayoutControlItem3.TextVisible = false;
			this.acLayoutControlItem3.ToolTipID = null;
			this.acLayoutControlItem3.ToolTipStdCode = null;
			this.acLayoutControlItem3.UseResourceID = false;
			this.acLayoutControlItem3.UseToolTipID = false;
			// 
			// layoutControl1
			// 
			this.layoutControl1.AllowCustomizationMenu = false;
			this.layoutControl1.AutoScroll = false;
			this.layoutControl1.ContainerName = null;
			this.layoutControl1.Controls.Add(this.acSimpleButton2);
			this.layoutControl1.Controls.Add(this.acSimpleButton1);
			this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.layoutControl1.LayoutType = ControlManager.acLayoutControl.emLayoutType.NONE;
			this.layoutControl1.Location = new System.Drawing.Point(0, 0);
			this.layoutControl1.Name = "layoutControl1";
			this.layoutControl1.ParentControl = null;
			this.layoutControl1.Root = this.layoutControlGroup1;
			this.layoutControl1.Size = new System.Drawing.Size(913, 62);
			this.layoutControl1.TabIndex = 10;
			this.layoutControl1.Text = "layoutControl1";
			// 
			// acSimpleButton2
			// 
			this.acSimpleButton2.AllowFocus = false;
			this.acSimpleButton2.Location = new System.Drawing.Point(656, 15);
			this.acSimpleButton2.Name = "acSimpleButton2";
			this.acSimpleButton2.ResourceID = null;
			this.acSimpleButton2.Size = new System.Drawing.Size(118, 32);
			this.acSimpleButton2.StyleController = this.layoutControl1;
			this.acSimpleButton2.TabIndex = 11;
			this.acSimpleButton2.Text = "확인";
			this.acSimpleButton2.ToolTipID = null;
			this.acSimpleButton2.UseResourceID = false;
			this.acSimpleButton2.UseToolTipID = false;
			this.acSimpleButton2.Click += new System.EventHandler(this.acSimpleButton2_Click);
			// 
			// acSimpleButton1
			// 
			this.acSimpleButton1.AllowFocus = false;
			this.acSimpleButton1.Location = new System.Drawing.Point(784, 15);
			this.acSimpleButton1.Name = "acSimpleButton1";
			this.acSimpleButton1.ResourceID = null;
			this.acSimpleButton1.Size = new System.Drawing.Size(114, 32);
			this.acSimpleButton1.StyleController = this.layoutControl1;
			this.acSimpleButton1.TabIndex = 10;
			this.acSimpleButton1.Text = "취소";
			this.acSimpleButton1.ToolTipID = null;
			this.acSimpleButton1.UseResourceID = false;
			this.acSimpleButton1.UseToolTipID = false;
			this.acSimpleButton1.Click += new System.EventHandler(this.acSimpleButton1_Click);
			// 
			// layoutControlGroup1
			// 
			this.layoutControlGroup1.AppearanceGroup.BackColor = System.Drawing.SystemColors.ControlDark;
			this.layoutControlGroup1.AppearanceGroup.Options.UseBackColor = true;
			this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
			this.layoutControlGroup1.IsHeader = false;
			this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.emptySpaceItem1,
            this.layoutControlItem5,
            this.layoutControlItem4});
			this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
			this.layoutControlGroup1.Name = "Root";
			this.layoutControlGroup1.ResourceID = null;
			this.layoutControlGroup1.Size = new System.Drawing.Size(913, 62);
			this.layoutControlGroup1.Text = "Root";
			this.layoutControlGroup1.TextVisible = false;
			this.layoutControlGroup1.ToolTipID = null;
			this.layoutControlGroup1.UseResourceID = false;
			this.layoutControlGroup1.UseToolTipID = false;
			// 
			// emptySpaceItem1
			// 
			this.emptySpaceItem1.AllowHotTrack = false;
			this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
			this.emptySpaceItem1.Location = new System.Drawing.Point(0, 0);
			this.emptySpaceItem1.MinSize = new System.Drawing.Size(110, 30);
			this.emptySpaceItem1.Name = "emptySpaceItem1";
			this.emptySpaceItem1.Size = new System.Drawing.Size(641, 42);
			this.emptySpaceItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
			this.emptySpaceItem1.Text = "emptySpaceItem1";
			this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
			// 
			// layoutControlItem5
			// 
			this.layoutControlItem5.Control = this.acSimpleButton2;
			this.layoutControlItem5.CustomizationFormText = "layoutControlItem5";
			this.layoutControlItem5.IsHeader = false;
			this.layoutControlItem5.IsTitle = false;
			this.layoutControlItem5.Location = new System.Drawing.Point(641, 0);
			this.layoutControlItem5.MinSize = new System.Drawing.Size(1, 31);
			this.layoutControlItem5.Name = "layoutControlItem5";
			this.layoutControlItem5.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
			this.layoutControlItem5.ResourceID = "KD40ZNWK";
			this.layoutControlItem5.Size = new System.Drawing.Size(128, 42);
			this.layoutControlItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
			this.layoutControlItem5.Text = "layoutControlItem5";
			this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem5.TextVisible = false;
			this.layoutControlItem5.ToolTipID = null;
			this.layoutControlItem5.ToolTipStdCode = null;
			this.layoutControlItem5.UseResourceID = true;
			this.layoutControlItem5.UseToolTipID = false;
			// 
			// layoutControlItem4
			// 
			this.layoutControlItem4.Control = this.acSimpleButton1;
			this.layoutControlItem4.CustomizationFormText = "layoutControlItem4";
			this.layoutControlItem4.IsHeader = false;
			this.layoutControlItem4.IsTitle = false;
			this.layoutControlItem4.Location = new System.Drawing.Point(769, 0);
			this.layoutControlItem4.MinSize = new System.Drawing.Size(1, 40);
			this.layoutControlItem4.Name = "layoutControlItem4";
			this.layoutControlItem4.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
			this.layoutControlItem4.ResourceID = "FRR80RHR";
			this.layoutControlItem4.Size = new System.Drawing.Size(124, 42);
			this.layoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
			this.layoutControlItem4.Text = "layoutControlItem4";
			this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem4.TextVisible = false;
			this.layoutControlItem4.ToolTipID = null;
			this.layoutControlItem4.ToolTipStdCode = null;
			this.layoutControlItem4.UseResourceID = true;
			this.layoutControlItem4.UseToolTipID = false;
			// 
			// acSplitContainerControl1
			// 
			this.acSplitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.acSplitContainerControl1.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.None;
			this.acSplitContainerControl1.Horizontal = false;
			this.acSplitContainerControl1.Location = new System.Drawing.Point(0, 0);
			this.acSplitContainerControl1.Name = "acSplitContainerControl1";
			this.acSplitContainerControl1.Panel1.Controls.Add(this.acLayoutControl1);
			this.acSplitContainerControl1.Panel1.Text = "Panel1";
			this.acSplitContainerControl1.Panel2.Controls.Add(this.layoutControl1);
			this.acSplitContainerControl1.Panel2.Text = "Panel2";
			this.acSplitContainerControl1.ParentControl = this;
			this.acSplitContainerControl1.Size = new System.Drawing.Size(913, 430);
			this.acSplitContainerControl1.SplitterPosition = 363;
			this.acSplitContainerControl1.TabIndex = 12;
			this.acSplitContainerControl1.Text = "acSplitContainerControl1";
			// 
			// ChangeTerminal
			// 
			this.ClientSize = new System.Drawing.Size(913, 430);
			this.Controls.Add(this.acSplitContainerControl1);
			this.Margin = new System.Windows.Forms.Padding(5);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ChangeTerminal";
			this.ResourceID = "R3GW922Q";
			this.ShowIcon = false;
			this.Text = "단말기 변경";
			this.UseResourceID = true;
			((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.acLayoutControl1)).EndInit();
			this.acLayoutControl1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gc)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gv)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
			this.layoutControl1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.acSplitContainerControl1)).EndInit();
			this.acSplitContainerControl1.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl3;
        private ControlManager.acSimpleButton btnDown;
        private ControlManager.acSimpleButton btnUp;
        private ControlManager.acLayoutControl layoutControl1;
        private ControlManager.acGridControl gc;
        private ControlManager.acGridView gv;
        private ControlManager.acLayoutControlGroup layoutControlGroup1;
        private ControlManager.acSimpleButton acSimpleButton1;
        private ControlManager.acLayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private ControlManager.acSimpleButton acSimpleButton2;
        private ControlManager.acLayoutControlItem layoutControlItem5;
        private ControlManager.acLayoutControl acLayoutControl1;
        private ControlManager.acSplitContainerControl acSplitContainerControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private ControlManager.acLayoutControlItem acLayoutControlItem1;
        private ControlManager.acLayoutControlItem acLayoutControlItem2;
        private ControlManager.acLayoutControlItem acLayoutControlItem3;
    }
}
