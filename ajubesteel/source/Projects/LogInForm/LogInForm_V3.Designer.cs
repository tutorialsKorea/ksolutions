namespace LogInForm
{
    partial class LogInForm_V3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogInForm_V3));
            this.pnlLogIn = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.acLayoutControl1 = new ControlManager.acLayoutControl();
            this.lueSkin = new ControlManager.acLookupEdit();
            this.acLookupEdit1 = new ControlManager.acLookupEdit();
            this.acLayoutControlGroup1 = new ControlManager.acLayoutControlGroup();
            this.acLayoutControlItem2 = new ControlManager.acLayoutControlItem();
            this.acLayoutControlItem4 = new ControlManager.acLayoutControlItem();
            this.acLabelControl6 = new ControlManager.acLabelControl();
            this.txtUserID = new DevExpress.XtraEditors.TextEdit();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnConnect = new DevExpress.XtraEditors.SimpleButton();
            this.chkSavePwd = new DevExpress.XtraEditors.CheckEdit();
            this.txtPassword = new DevExpress.XtraEditors.TextEdit();
            this.panel5 = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.acLabelControl5 = new ControlManager.acLabelControl();
            this.acLabelControl4 = new ControlManager.acLabelControl();
            this.btnConfig = new DevExpress.XtraEditors.SimpleButton();
            this.pnlLogIn.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControl1)).BeginInit();
            this.acLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lueSkin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLookupEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSavePwd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).BeginInit();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.panel6.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlLogIn
            // 
            this.pnlLogIn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            this.pnlLogIn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlLogIn.Controls.Add(this.panel2);
            this.pnlLogIn.Controls.Add(this.panel1);
            this.pnlLogIn.Controls.Add(this.btnConfig);
            this.pnlLogIn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLogIn.Location = new System.Drawing.Point(0, 0);
            this.pnlLogIn.Name = "pnlLogIn";
            this.pnlLogIn.Size = new System.Drawing.Size(482, 728);
            this.pnlLogIn.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.panel8);
            this.panel2.Controls.Add(this.acLabelControl6);
            this.panel2.Controls.Add(this.txtUserID);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.btnConnect);
            this.panel2.Controls.Add(this.chkSavePwd);
            this.panel2.Controls.Add(this.txtPassword);
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(480, 697);
            this.panel2.TabIndex = 22;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.acLayoutControl1);
            this.panel8.Location = new System.Drawing.Point(74, 581);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(348, 43);
            this.panel8.TabIndex = 41;
            this.panel8.Visible = false;
            // 
            // acLayoutControl1
            // 
            this.acLayoutControl1.AllowCustomization = false;
            this.acLayoutControl1.ContainerName = null;
            this.acLayoutControl1.Controls.Add(this.lueSkin);
            this.acLayoutControl1.Controls.Add(this.acLookupEdit1);
            this.acLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.acLayoutControl1.LayoutType = ControlManager.acLayoutControl.emLayoutType.NONE;
            this.acLayoutControl1.Location = new System.Drawing.Point(0, 0);
            this.acLayoutControl1.Name = "acLayoutControl1";
            this.acLayoutControl1.ParentControl = null;
            this.acLayoutControl1.Root = this.acLayoutControlGroup1;
            this.acLayoutControl1.Size = new System.Drawing.Size(348, 43);
            this.acLayoutControl1.TabIndex = 1;
            this.acLayoutControl1.Text = "acLayoutControl1";
            // 
            // lueSkin
            // 
            this.lueSkin.ColumnName = "SKIN";
            this.lueSkin.DefaultValueType = ControlManager.acLookupEdit.emDefaultValueType.NONE;
            this.lueSkin.isReadyOnly = false;
            this.lueSkin.isRequired = false;
            this.lueSkin.Location = new System.Drawing.Point(217, 5);
            this.lueSkin.Name = "lueSkin";
            this.lueSkin.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.lueSkin.Properties.Appearance.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.lueSkin.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.lueSkin.Properties.Appearance.Options.UseBackColor = true;
            this.lueSkin.Properties.Appearance.Options.UseFont = true;
            this.lueSkin.Properties.Appearance.Options.UseForeColor = true;
            this.lueSkin.Properties.AppearanceDisabled.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.lueSkin.Properties.AppearanceDisabled.Options.UseFont = true;
            this.lueSkin.Properties.AppearanceDropDown.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.lueSkin.Properties.AppearanceDropDown.Options.UseFont = true;
            this.lueSkin.Properties.AppearanceDropDownHeader.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.lueSkin.Properties.AppearanceDropDownHeader.Options.UseFont = true;
            this.lueSkin.Properties.AppearanceFocused.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.lueSkin.Properties.AppearanceFocused.Options.UseFont = true;
            this.lueSkin.Properties.AppearanceReadOnly.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.lueSkin.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.lueSkin.Properties.AutoHeight = false;
            this.lueSkin.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.lueSkin.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueSkin.Properties.NullText = "";
            this.lueSkin.Properties.ShowHeader = false;
            this.lueSkin.searchMode = false;
            this.lueSkin.Size = new System.Drawing.Size(126, 33);
            this.lueSkin.StyleController = this.acLayoutControl1;
            this.lueSkin.TabIndex = 39;
            this.lueSkin.ToolTipID = null;
            this.lueSkin.UseToolTipID = false;
            this.lueSkin.Value = null;
            // 
            // acLookupEdit1
            // 
            this.acLookupEdit1.ColumnName = "SKIN";
            this.acLookupEdit1.DefaultValueType = ControlManager.acLookupEdit.emDefaultValueType.NONE;
            this.acLookupEdit1.isReadyOnly = false;
            this.acLookupEdit1.isRequired = false;
            this.acLookupEdit1.Location = new System.Drawing.Point(70, 5);
            this.acLookupEdit1.Name = "acLookupEdit1";
            this.acLookupEdit1.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.acLookupEdit1.Properties.Appearance.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.acLookupEdit1.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.acLookupEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.acLookupEdit1.Properties.Appearance.Options.UseFont = true;
            this.acLookupEdit1.Properties.Appearance.Options.UseForeColor = true;
            this.acLookupEdit1.Properties.AppearanceDisabled.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.acLookupEdit1.Properties.AppearanceDisabled.Options.UseFont = true;
            this.acLookupEdit1.Properties.AppearanceDropDown.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.acLookupEdit1.Properties.AppearanceDropDown.Options.UseFont = true;
            this.acLookupEdit1.Properties.AppearanceDropDownHeader.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.acLookupEdit1.Properties.AppearanceDropDownHeader.Options.UseFont = true;
            this.acLookupEdit1.Properties.AppearanceFocused.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.acLookupEdit1.Properties.AppearanceFocused.Options.UseFont = true;
            this.acLookupEdit1.Properties.AppearanceReadOnly.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.acLookupEdit1.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.acLookupEdit1.Properties.AutoHeight = false;
            this.acLookupEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.acLookupEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.acLookupEdit1.Properties.NullText = "";
            this.acLookupEdit1.Properties.ShowHeader = false;
            this.acLookupEdit1.searchMode = false;
            this.acLookupEdit1.Size = new System.Drawing.Size(72, 33);
            this.acLookupEdit1.StyleController = this.acLayoutControl1;
            this.acLookupEdit1.TabIndex = 41;
            this.acLookupEdit1.ToolTipID = null;
            this.acLookupEdit1.UseToolTipID = false;
            this.acLookupEdit1.Value = null;
            // 
            // acLayoutControlGroup1
            // 
            this.acLayoutControlGroup1.CustomizationFormText = "acLayoutControlGroup1";
            this.acLayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.acLayoutControlGroup1.GroupBordersVisible = false;
            this.acLayoutControlGroup1.IsHeader = false;
            this.acLayoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.acLayoutControlItem2,
            this.acLayoutControlItem4});
            this.acLayoutControlGroup1.Name = "acLayoutControlGroup1";
            this.acLayoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.acLayoutControlGroup1.ResourceID = null;
            this.acLayoutControlGroup1.Size = new System.Drawing.Size(348, 43);
            this.acLayoutControlGroup1.TextVisible = false;
            this.acLayoutControlGroup1.ToolTipID = null;
            this.acLayoutControlGroup1.UseResourceID = false;
            this.acLayoutControlGroup1.UseToolTipID = false;
            // 
            // acLayoutControlItem2
            // 
            this.acLayoutControlItem2.AppearanceItemCaption.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.acLayoutControlItem2.AppearanceItemCaption.Options.UseFont = true;
            this.acLayoutControlItem2.Control = this.acLookupEdit1;
            this.acLayoutControlItem2.CustomizationFormText = "메뉴 방향";
            this.acLayoutControlItem2.IsHeader = false;
            this.acLayoutControlItem2.IsTitle = false;
            this.acLayoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.acLayoutControlItem2.Name = "acLayoutControlItem2";
            this.acLayoutControlItem2.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.acLayoutControlItem2.ResourceID = null;
            this.acLayoutControlItem2.Size = new System.Drawing.Size(147, 43);
            this.acLayoutControlItem2.Text = "메뉴 방향";
            this.acLayoutControlItem2.TextSize = new System.Drawing.Size(61, 19);
            this.acLayoutControlItem2.ToolTipID = null;
            this.acLayoutControlItem2.ToolTipStdCode = null;
            this.acLayoutControlItem2.UseResourceID = false;
            this.acLayoutControlItem2.UseToolTipID = false;
            // 
            // acLayoutControlItem4
            // 
            this.acLayoutControlItem4.AppearanceItemCaption.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.acLayoutControlItem4.AppearanceItemCaption.Options.UseFont = true;
            this.acLayoutControlItem4.Control = this.lueSkin;
            this.acLayoutControlItem4.CustomizationFormText = "스킨";
            this.acLayoutControlItem4.IsHeader = false;
            this.acLayoutControlItem4.IsTitle = false;
            this.acLayoutControlItem4.Location = new System.Drawing.Point(147, 0);
            this.acLayoutControlItem4.Name = "acLayoutControlItem4";
            this.acLayoutControlItem4.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.acLayoutControlItem4.ResourceID = null;
            this.acLayoutControlItem4.Size = new System.Drawing.Size(201, 43);
            this.acLayoutControlItem4.Text = "스킨";
            this.acLayoutControlItem4.TextSize = new System.Drawing.Size(61, 19);
            this.acLayoutControlItem4.ToolTipID = null;
            this.acLayoutControlItem4.ToolTipStdCode = null;
            this.acLayoutControlItem4.UseResourceID = false;
            this.acLayoutControlItem4.UseToolTipID = false;
            // 
            // acLabelControl6
            // 
            this.acLabelControl6.Appearance.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.acLabelControl6.Appearance.Options.UseFont = true;
            this.acLabelControl6.Location = new System.Drawing.Point(276, 553);
            this.acLabelControl6.Name = "acLabelControl6";
            this.acLabelControl6.ResourceID = null;
            this.acLabelControl6.Size = new System.Drawing.Size(96, 17);
            this.acLabelControl6.TabIndex = 40;
            this.acLabelControl6.Text = "Option View ▷";
            this.acLabelControl6.ToolTipID = null;
            this.acLabelControl6.UseResourceID = false;
            this.acLabelControl6.UseToolTipID = false;
            this.acLabelControl6.Click += new System.EventHandler(this.acLabelControl6_Click);
            // 
            // txtUserID
            // 
            this.txtUserID.Location = new System.Drawing.Point(74, 432);
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.Properties.Appearance.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.txtUserID.Properties.Appearance.Options.UseFont = true;
            this.txtUserID.Properties.AppearanceFocused.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.txtUserID.Properties.AppearanceFocused.Options.UseFont = true;
            this.txtUserID.Properties.AppearanceReadOnly.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.txtUserID.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.txtUserID.Properties.AutoHeight = false;
            this.txtUserID.Size = new System.Drawing.Size(348, 30);
            this.txtUserID.TabIndex = 0;
            this.txtUserID.Enter += new System.EventHandler(this.txtUserID_Enter);
            this.txtUserID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUserID_KeyDown);
            this.txtUserID.Leave += new System.EventHandler(this.txtUserID_Leave);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Image = global::LogInForm.Resource.logo1;
            this.pictureBox1.Location = new System.Drawing.Point(0, 102);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(480, 304);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 20;
            this.pictureBox1.TabStop = false;
            // 
            // btnConnect
            // 
            this.btnConnect.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(130)))), ((int)(((byte)(182)))));
            this.btnConnect.Appearance.Font = new System.Drawing.Font("맑은 고딕", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnConnect.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnConnect.Appearance.Options.UseBackColor = true;
            this.btnConnect.Appearance.Options.UseFont = true;
            this.btnConnect.Appearance.Options.UseForeColor = true;
            this.btnConnect.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btnConnect.Location = new System.Drawing.Point(74, 504);
            this.btnConnect.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnConnect.LookAndFeel.UseWindowsXPTheme = true;
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(348, 40);
            this.btnConnect.TabIndex = 2;
            this.btnConnect.Text = "로그인";
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // chkSavePwd
            // 
            this.chkSavePwd.Location = new System.Drawing.Point(74, 550);
            this.chkSavePwd.Name = "chkSavePwd";
            this.chkSavePwd.Properties.Appearance.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.chkSavePwd.Properties.Appearance.Options.UseFont = true;
            this.chkSavePwd.Properties.AutoHeight = false;
            this.chkSavePwd.Properties.Caption = "Remember password";
            this.chkSavePwd.Size = new System.Drawing.Size(155, 25);
            this.chkSavePwd.TabIndex = 36;
            // 
            // txtPassword
            // 
            this.txtPassword.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtPassword.Location = new System.Drawing.Point(74, 468);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Properties.Appearance.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.txtPassword.Properties.Appearance.Options.UseFont = true;
            this.txtPassword.Properties.AppearanceFocused.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.txtPassword.Properties.AppearanceFocused.Options.UseFont = true;
            this.txtPassword.Properties.AppearanceReadOnly.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.txtPassword.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.txtPassword.Properties.AutoHeight = false;
            this.txtPassword.Properties.PasswordChar = '●';
            this.txtPassword.ShowToolTips = false;
            this.txtPassword.Size = new System.Drawing.Size(348, 30);
            this.txtPassword.TabIndex = 1;
            this.txtPassword.Enter += new System.EventHandler(this.txtPassword_Enter);
            this.txtPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPassword_KeyDown);
            this.txtPassword.Leave += new System.EventHandler(this.txtPassword_Leave);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.pictureBox3);
            this.panel5.Controls.Add(this.panel4);
            this.panel5.Controls.Add(this.panel3);
            this.panel5.Controls.Add(this.panel6);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(480, 102);
            this.panel5.TabIndex = 31;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox3.Image = global::LogInForm.Resource.logo_1;
            this.pictureBox3.Location = new System.Drawing.Point(10, 34);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(460, 68);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 24;
            this.pictureBox3.TabStop = false;
            // 
            // panel4
            // 
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(470, 34);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(10, 68);
            this.panel4.TabIndex = 31;
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 34);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(10, 68);
            this.panel3.TabIndex = 30;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.Transparent;
            this.panel6.Controls.Add(this.button1);
            this.panel6.Controls.Add(this.btnClose);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(480, 34);
            this.panel6.TabIndex = 28;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(8, 6);
            this.button1.Margin = new System.Windows.Forms.Padding(0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(35, 25);
            this.button1.TabIndex = 26;
            this.button1.Text = "◀▶";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.IndianRed;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnClose.ForeColor = System.Drawing.Color.Black;
            this.btnClose.Location = new System.Drawing.Point(447, 3);
            this.btnClose.Margin = new System.Windows.Forms.Padding(0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(25, 25);
            this.btnClose.TabIndex = 25;
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.acLabelControl5);
            this.panel1.Controls.Add(this.acLabelControl4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 697);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(480, 29);
            this.panel1.TabIndex = 19;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox2.Image = global::LogInForm.Resource.Main7;
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(195, 29);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // acLabelControl5
            // 
            this.acLabelControl5.Appearance.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.acLabelControl5.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(122)))), ((int)(((byte)(183)))));
            this.acLabelControl5.Appearance.Options.UseFont = true;
            this.acLabelControl5.Appearance.Options.UseForeColor = true;
            this.acLabelControl5.Location = new System.Drawing.Point(401, 11);
            this.acLabelControl5.Name = "acLabelControl5";
            this.acLabelControl5.ResourceID = null;
            this.acLabelControl5.Size = new System.Drawing.Size(68, 15);
            this.acLabelControl5.TabIndex = 1;
            this.acLabelControl5.Text = "(주)큐빅테크";
            this.acLabelControl5.ToolTipID = null;
            this.acLabelControl5.UseResourceID = false;
            this.acLabelControl5.UseToolTipID = false;
            // 
            // acLabelControl4
            // 
            this.acLabelControl4.Appearance.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.acLabelControl4.Appearance.Options.UseFont = true;
            this.acLabelControl4.Location = new System.Drawing.Point(326, 11);
            this.acLabelControl4.Name = "acLabelControl4";
            this.acLabelControl4.ResourceID = null;
            this.acLabelControl4.Size = new System.Drawing.Size(71, 15);
            this.acLabelControl4.TabIndex = 0;
            this.acLabelControl4.Text = "powered by";
            this.acLabelControl4.ToolTipID = null;
            this.acLabelControl4.UseResourceID = false;
            this.acLabelControl4.UseToolTipID = false;
            // 
            // btnConfig
            // 
            this.btnConfig.Appearance.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnConfig.Appearance.Options.UseFont = true;
            this.btnConfig.Location = new System.Drawing.Point(569, 383);
            this.btnConfig.Name = "btnConfig";
            this.btnConfig.Size = new System.Drawing.Size(73, 79);
            this.btnConfig.TabIndex = 9;
            this.btnConfig.Text = "환경 설정";
            this.btnConfig.Visible = false;
            this.btnConfig.Click += new System.EventHandler(this.btnConfig_Click);
            // 
            // LogInForm_V3
            // 
            this.Appearance.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(482, 728);
            this.Controls.Add(this.pnlLogIn);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Shadow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.IconOptions.Icon = ((System.Drawing.Icon)(resources.GetObject("LogInForm_V3.IconOptions.Icon")));
            this.LookAndFeel.SkinName = "Office 2013";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "LogInForm_V3";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Proactive Log-in";
            this.pnlLogIn.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControl1)).EndInit();
            this.acLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lueSkin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLookupEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSavePwd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).EndInit();
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlLogIn;
        private DevExpress.XtraEditors.SimpleButton btnConfig;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Panel panel2;
		private ControlManager.acLabelControl acLabelControl5;
		private ControlManager.acLabelControl acLabelControl4;
		private System.Windows.Forms.Panel panel5;
		private System.Windows.Forms.PictureBox pictureBox2;
        private DevExpress.XtraEditors.TextEdit txtUserID;
        private DevExpress.XtraEditors.SimpleButton btnConnect;
        private DevExpress.XtraEditors.CheckEdit chkSavePwd;
        private DevExpress.XtraEditors.TextEdit txtPassword;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel8;
        private ControlManager.acLabelControl acLabelControl6;
		private ControlManager.acLayoutControl acLayoutControl1;
		private ControlManager.acLookupEdit lueSkin;
		private ControlManager.acLookupEdit acLookupEdit1;
		private ControlManager.acLayoutControlGroup acLayoutControlGroup1;
		private ControlManager.acLayoutControlItem acLayoutControlItem2;
		private ControlManager.acLayoutControlItem acLayoutControlItem4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
    }
}

