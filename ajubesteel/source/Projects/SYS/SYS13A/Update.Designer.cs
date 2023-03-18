
namespace SYS.SYS13A
{
    partial class Update
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

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.acLayoutControl1 = new ControlManager.acLayoutControl();
            this.acRichEdit1 = new ControlManager.acRichEdit();
            this.lblTitle = new ControlManager.acLabelControl();
            this.Root = new ControlManager.acLayoutControlGroup();
            this.acLayoutControlItem1 = new ControlManager.acLayoutControlItem();
            this.acLayoutControlItem3 = new ControlManager.acLayoutControlItem();
            this.lblVersion = new ControlManager.acLabelControl();
            this.acLayoutControlItem2 = new ControlManager.acLayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControl1)).BeginInit();
            this.acLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // acLayoutControl1
            // 
            this.acLayoutControl1.AllowCustomization = false;
            this.acLayoutControl1.ContainerName = null;
            this.acLayoutControl1.Controls.Add(this.lblVersion);
            this.acLayoutControl1.Controls.Add(this.acRichEdit1);
            this.acLayoutControl1.Controls.Add(this.lblTitle);
            this.acLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.acLayoutControl1.LayoutType = ControlManager.acLayoutControl.emLayoutType.NONE;
            this.acLayoutControl1.Location = new System.Drawing.Point(0, 0);
            this.acLayoutControl1.Name = "acLayoutControl1";
            this.acLayoutControl1.ParentControl = null;
            this.acLayoutControl1.Root = this.Root;
            this.acLayoutControl1.Size = new System.Drawing.Size(279, 333);
            this.acLayoutControl1.TabIndex = 0;
            this.acLayoutControl1.Text = "acLayoutControl1";
            // 
            // acRichEdit1
            // 
            this.acRichEdit1.ActiveViewType = DevExpress.XtraRichEdit.RichEditViewType.Simple;
            this.acRichEdit1.Appearance.Text.BackColor = System.Drawing.Color.White;
            this.acRichEdit1.Appearance.Text.ForeColor = System.Drawing.Color.Black;
            this.acRichEdit1.Appearance.Text.Options.UseBackColor = true;
            this.acRichEdit1.Appearance.Text.Options.UseFont = true;
            this.acRichEdit1.Appearance.Text.Options.UseForeColor = true;
            this.acRichEdit1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.acRichEdit1.ColumnName = null;
            this.acRichEdit1.DocumentFormat = DevExpress.XtraRichEdit.DocumentFormat.Rtf;
            this.acRichEdit1.IsNotApplyColorStyle = true;
            this.acRichEdit1.isReadyOnly = false;
            this.acRichEdit1.isRequired = false;
            this.acRichEdit1.LayoutUnit = DevExpress.XtraRichEdit.DocumentLayoutUnit.Pixel;
            this.acRichEdit1.Location = new System.Drawing.Point(5, 74);
            this.acRichEdit1.Name = "acRichEdit1";
            this.acRichEdit1.Options.VerticalScrollbar.Visibility = DevExpress.XtraRichEdit.RichEditScrollbarVisibility.Hidden;
            this.acRichEdit1.ReadOnly = true;
            this.acRichEdit1.Size = new System.Drawing.Size(269, 254);
            this.acRichEdit1.TabIndex = 6;
            this.acRichEdit1.ToolTipID = null;
            this.acRichEdit1.UseToolTipID = false;
            this.acRichEdit1.Views.SimpleView.AdjustColorsToSkins = true;
            // 
            // lblTitle
            // 
            this.lblTitle.Appearance.BackColor = System.Drawing.Color.White;
            this.lblTitle.Appearance.Font = new System.Drawing.Font("Tahoma", 14F);
            this.lblTitle.Appearance.Options.UseBackColor = true;
            this.lblTitle.Appearance.Options.UseFont = true;
            this.lblTitle.Appearance.Options.UseTextOptions = true;
            this.lblTitle.Appearance.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;
            this.lblTitle.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.lblTitle.Location = new System.Drawing.Point(10, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.ResourceID = null;
            this.lblTitle.Size = new System.Drawing.Size(259, 35);
            this.lblTitle.StyleController = this.acLayoutControl1;
            this.lblTitle.TabIndex = 4;
            this.lblTitle.ToolTipID = null;
            this.lblTitle.UseResourceID = false;
            this.lblTitle.UseToolTipID = false;
            // 
            // Root
            // 
            this.Root.AppearanceGroup.BackColor = System.Drawing.Color.White;
            this.Root.AppearanceGroup.Options.UseBackColor = true;
            this.Root.AppearanceItemCaption.BackColor = System.Drawing.Color.White;
            this.Root.AppearanceItemCaption.Options.UseBackColor = true;
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.IsHeader = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.acLayoutControlItem1,
            this.acLayoutControlItem3,
            this.acLayoutControlItem2});
            this.Root.Name = "Root";
            this.Root.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.Root.ResourceID = null;
            this.Root.Size = new System.Drawing.Size(279, 333);
            this.Root.TextVisible = false;
            this.Root.ToolTipID = null;
            this.Root.UseResourceID = false;
            this.Root.UseToolTipID = false;
            // 
            // acLayoutControlItem1
            // 
            this.acLayoutControlItem1.AppearanceItemCaption.BackColor = System.Drawing.Color.White;
            this.acLayoutControlItem1.AppearanceItemCaption.Options.UseBackColor = true;
            this.acLayoutControlItem1.Control = this.lblTitle;
            this.acLayoutControlItem1.CustomizationFormText = "acLayoutControlItem1";
            this.acLayoutControlItem1.IsHeader = false;
            this.acLayoutControlItem1.IsTitle = false;
            this.acLayoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.acLayoutControlItem1.MinSize = new System.Drawing.Size(96, 24);
            this.acLayoutControlItem1.Name = "acLayoutControlItem1";
            this.acLayoutControlItem1.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.acLayoutControlItem1.ResourceID = null;
            this.acLayoutControlItem1.Size = new System.Drawing.Size(269, 45);
            this.acLayoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.acLayoutControlItem1.Text = "acLayoutControlItem1";
            this.acLayoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.acLayoutControlItem1.TextVisible = false;
            this.acLayoutControlItem1.ToolTipID = null;
            this.acLayoutControlItem1.ToolTipStdCode = null;
            this.acLayoutControlItem1.UseResourceID = false;
            this.acLayoutControlItem1.UseToolTipID = false;
            // 
            // acLayoutControlItem3
            // 
            this.acLayoutControlItem3.Control = this.acRichEdit1;
            this.acLayoutControlItem3.CustomizationFormText = "acLayoutControlItem3";
            this.acLayoutControlItem3.IsHeader = false;
            this.acLayoutControlItem3.IsTitle = false;
            this.acLayoutControlItem3.Location = new System.Drawing.Point(0, 69);
            this.acLayoutControlItem3.Name = "acLayoutControlItem3";
            this.acLayoutControlItem3.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.acLayoutControlItem3.ResourceID = null;
            this.acLayoutControlItem3.Size = new System.Drawing.Size(269, 254);
            this.acLayoutControlItem3.Text = "acLayoutControlItem3";
            this.acLayoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.acLayoutControlItem3.TextVisible = false;
            this.acLayoutControlItem3.ToolTipID = null;
            this.acLayoutControlItem3.ToolTipStdCode = null;
            this.acLayoutControlItem3.UseResourceID = false;
            this.acLayoutControlItem3.UseToolTipID = false;
            // 
            // lblVersion
            // 
            this.lblVersion.Appearance.BackColor = System.Drawing.Color.White;
            this.lblVersion.Appearance.Options.UseBackColor = true;
            this.lblVersion.Location = new System.Drawing.Point(10, 55);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.ResourceID = null;
            this.lblVersion.Size = new System.Drawing.Size(259, 14);
            this.lblVersion.StyleController = this.acLayoutControl1;
            this.lblVersion.TabIndex = 7;
            this.lblVersion.ToolTipID = null;
            this.lblVersion.UseResourceID = false;
            this.lblVersion.UseToolTipID = false;
            // 
            // acLayoutControlItem2
            // 
            this.acLayoutControlItem2.Control = this.lblVersion;
            this.acLayoutControlItem2.CustomizationFormText = "acLayoutControlItem2";
            this.acLayoutControlItem2.IsHeader = false;
            this.acLayoutControlItem2.IsTitle = false;
            this.acLayoutControlItem2.Location = new System.Drawing.Point(0, 45);
            this.acLayoutControlItem2.Name = "acLayoutControlItem2";
            this.acLayoutControlItem2.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.acLayoutControlItem2.ResourceID = null;
            this.acLayoutControlItem2.Size = new System.Drawing.Size(269, 24);
            this.acLayoutControlItem2.Text = "acLayoutControlItem2";
            this.acLayoutControlItem2.TextLocation = DevExpress.Utils.Locations.Left;
            this.acLayoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.acLayoutControlItem2.TextVisible = false;
            this.acLayoutControlItem2.ToolTipID = null;
            this.acLayoutControlItem2.ToolTipStdCode = null;
            this.acLayoutControlItem2.UseResourceID = false;
            this.acLayoutControlItem2.UseToolTipID = false;
            // 
            // Update
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.acLayoutControl1);
            this.Name = "Update";
            this.Size = new System.Drawing.Size(279, 333);
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControl1)).EndInit();
            this.acLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ControlManager.acLayoutControl acLayoutControl1;
        private ControlManager.acLayoutControlGroup Root;
        private ControlManager.acLabelControl lblTitle;
        private ControlManager.acLayoutControlItem acLayoutControlItem1;
        private ControlManager.acRichEdit acRichEdit1;
        private ControlManager.acLayoutControlItem acLayoutControlItem3;
        private ControlManager.acLabelControl lblVersion;
        private ControlManager.acLayoutControlItem acLayoutControlItem2;
    }
}
