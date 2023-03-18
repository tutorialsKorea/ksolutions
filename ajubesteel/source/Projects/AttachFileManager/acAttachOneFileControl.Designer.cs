namespace AttachFileManager
{
    partial class acAttachOneFileControl
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
            this.lblFileName = new ControlManager.acLabelControl();
            this.txtFileName = new ControlManager.acTextEdit();
            this.btnUpload = new ControlManager.acSimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtFileName.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFileName
            // 
            this.lblFileName.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblFileName.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblFileName.Location = new System.Drawing.Point(0, 0);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.ResourceID = null;
            this.lblFileName.Size = new System.Drawing.Size(38, 30);
            this.lblFileName.TabIndex = 0;
            this.lblFileName.Text = "파일명 : ";
            this.lblFileName.ToolTipID = null;
            this.lblFileName.UseResourceID = false;
            this.lblFileName.UseToolTipID = false;
            // 
            // txtFileName
            // 
            this.txtFileName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtFileName.isReadyOnly = true;
            this.txtFileName.Location = new System.Drawing.Point(38, 0);
            this.txtFileName.MaskType = ControlManager.acTextEdit.emMaskType.NONE;
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtFileName.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.txtFileName.Properties.Appearance.Options.UseBackColor = true;
            this.txtFileName.Properties.Appearance.Options.UseForeColor = true;
            this.txtFileName.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtFileName.Properties.AppearanceReadOnly.ForeColor = System.Drawing.Color.Black;
            this.txtFileName.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.txtFileName.Properties.AppearanceReadOnly.Options.UseForeColor = true;
            this.txtFileName.Properties.AutoHeight = false;
            this.txtFileName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txtFileName.Properties.ReadOnly = true;
            this.txtFileName.Size = new System.Drawing.Size(295, 30);
            this.txtFileName.TabIndex = 1;
            // 
            // btnUpload
            // 
            this.btnUpload.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnUpload.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnUpload.Location = new System.Drawing.Point(333, 0);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.ResourceID = null;
            this.btnUpload.Size = new System.Drawing.Size(56, 30);
            this.btnUpload.TabIndex = 2;
            this.btnUpload.Text = "등록";
            this.btnUpload.ToolTipID = null;
            this.btnUpload.UseResourceID = false;
            this.btnUpload.UseToolTipID = false;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // acAttachOneFileControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtFileName);
            this.Controls.Add(this.lblFileName);
            this.Controls.Add(this.btnUpload);
            this.Name = "acAttachOneFileControl";
            this.Size = new System.Drawing.Size(389, 30);
            ((System.ComponentModel.ISupportInitialize)(this.txtFileName.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ControlManager.acLabelControl lblFileName;
        private ControlManager.acTextEdit txtFileName;
        private ControlManager.acSimpleButton btnUpload;
    }
}
