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
    public partial class WorkStop : BaseMenuDialog
    {

        public WorkStop()
        {
            InitializeComponent(); 

            Control[] con = POP20A_M0A.formcount(this);
            foreach (Control down in con) // ��Ʈ�� ��ü ��ȸ
            {
                if (down.Name.StartsWith("btn"))
                {
                    Control[] ctrls = this.Controls.Find(down.Name, true);

                    ((ControlManager.acSimpleButton)ctrls[0]).Font = new Font(acInfo.SysConfig.GetSysConfigByMemory("DEFAULT_FONT"), acInfo.SysConfig.GetSysConfigByMemory("DEFAULT_FONT_SIZE").toInt() + 10,
                    FontStyle.Regular, GraphicsUnit.Point);
                }
            }
            
            (acLayoutControl2.GetEditor("IDLE_CAUSE").Editor as acLookupEdit).SetCode("C010");

        }

        public WorkStop(string cat_code)
        {
            InitializeComponent();

            Control[] con = POP20A_M0A.formcount(this);
            foreach (Control down in con) // ��Ʈ�� ��ü ��ȸ
            {
                if (down.Name.StartsWith("btn"))
                {
                    Control[] ctrls = this.Controls.Find(down.Name, true);

                    ((ControlManager.acSimpleButton)ctrls[0]).Font = new Font(acInfo.SysConfig.GetSysConfigByMemory("DEFAULT_FONT"), acInfo.SysConfig.GetSysConfigByMemory("DEFAULT_FONT_SIZE").toInt() + 10,
                    FontStyle.Regular, GraphicsUnit.Point);
                }
            }

            this.Text = "�۾� �ߴ� ������ �����ϼ���.";
            acLabelControl2.Text = "�۾� �ߴ� ����";

            (acLayoutControl2.GetEditor("IDLE_CAUSE").Editor as acLookupEdit).SetCode(cat_code);
            
        }

        private void OK()
        {
            DataRow layoutRow = acLayoutControl2.CreateParameterRow();

            if (layoutRow["IDLE_CAUSE"].ToString() == "" )
            {
                acMessageBox.Show("������ ���õ��� �ʾҽ��ϴ�.", this.Text, acMessageBox.emMessageBoxType.CONFIRM);
                return;
            }

            this.OutputData = layoutRow;

            this.DialogResult = DialogResult.OK;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            //Ȯ��
            this.OK();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //���
            this.DialogResult = DialogResult.Cancel;
        }
        
    }
}

