using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ControlManager;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Grid;
using BizManager;

namespace POP
{
    public partial class AttachFileList : BaseMenuDialog
    {

        private DataRow _row = null;

        public AttachFileList(DataRow row)
        {
            InitializeComponent();

            _row = row;

            Control[] con = POP20A_M0A.formcount(this);
            foreach (Control down in con) // 컨트롤 전체 조회
            {
                if (down.Name.StartsWith("btn"))
                {
                    Control[] ctrls = this.Controls.Find(down.Name, true);

                    ((ControlManager.acSimpleButton)ctrls[0]).Font = new Font(acInfo.SysConfig.GetSysConfigByMemory("DEFAULT_FONT"), acInfo.SysConfig.GetSysConfigByMemory("DEFAULT_FONT_SIZE").toInt() + 10,
                    FontStyle.Regular, GraphicsUnit.Point);
                }
            }

            this.acPOPAttachFileControl1.AttachLinkPermission = AttachFileManager.acPOPAttachFileControl.emAttachLinkPermission.D; 

            this.acPOPAttachFileControl1.LinkKey = _row["PART_CODE"];
            this.acPOPAttachFileControl1.ShowKey = new object[] { _row["PART_CODE"] };

            this.acPOPAttachFileControl1.Enabled = true;

        }

        public AttachFileList(object part)
        {
            InitializeComponent();


            Control[] con = POP20A_M0A.formcount(this);
            foreach (Control down in con) // 컨트롤 전체 조회
            {
                if (down.Name.StartsWith("btn"))
                {
                    Control[] ctrls = this.Controls.Find(down.Name, true);

                    ((ControlManager.acSimpleButton)ctrls[0]).Font = new Font(acInfo.SysConfig.GetSysConfigByMemory("DEFAULT_FONT"), acInfo.SysConfig.GetSysConfigByMemory("DEFAULT_FONT_SIZE").toInt() + 10,
                    FontStyle.Regular, GraphicsUnit.Point);
                }
            }

            this.acPOPAttachFileControl1.AttachLinkPermission = AttachFileManager.acPOPAttachFileControl.emAttachLinkPermission.D;

            this.acPOPAttachFileControl1.LinkKey = part;
            this.acPOPAttachFileControl1.ShowKey = new object[] { part };

            this.acPOPAttachFileControl1.Enabled = true;

        }

        private void OK()
        {

            this.DialogResult = DialogResult.OK;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            //확인
            this.OK();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //취소
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            OK();
        }
        
    }
}

