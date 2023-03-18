using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ControlManager;

namespace POP
{
    public partial class KeyPad : BaseMenuDialog
    {
        

        public KeyPad()
        {
            InitializeComponent();

            Control[] con = POP20A_M0A.formcount(this);
            foreach (Control down in con) // 컨트롤 전체 조회
            {
                if (down.Name.StartsWith("btn"))
                {
                    Control[] ctrls = this.Controls.Find(down.Name, true);

                    ((ControlManager.acSimpleButton)ctrls[0]).Font = new Font(acInfo.SysConfig.GetSysConfigByMemory("DEFAULT_FONT"), acInfo.SysConfig.GetSysConfigByMemory("DEFAULT_FONT_SIZE").toInt() + 9,
                    FontStyle.Regular, GraphicsUnit.Point);
                }
            }


        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btn1_Click(object sender, EventArgs e)
        {

            //acTextEdit1.EditValue = acConvert.toDecimal(acTextEdit1.Text + (sender as ControlManager.acSimpleButton).Text);
            acTextEdit1.EditValue = acTextEdit1.Text + (sender as ControlManager.acSimpleButton).Text;
        }

        private void btnP_Click(object sender, EventArgs e)
        {

            acTextEdit1.EditValue = 0;
        }

        private void btnB_Click(object sender, EventArgs e)
        {
            

            if (acTextEdit1.Text.Length == 0)
            {
                return;
            }

            if (acTextEdit1.Text.Length == 1)
            {
                acTextEdit1.EditValue = null;
                return;
            }
            
            acTextEdit1.EditValue = acConvert.toDecimal((acTextEdit1.Text.Substring(0, acTextEdit1.Text.Length - 1)));
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.OutputData = acTextEdit1.EditValue;

            this.DialogResult = DialogResult.OK;
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            try
            {
                if (!acTextEdit1.Text.StartsWith("-"))
                {
                    decimal d = acConvert.toDecimal(acTextEdit1.Text);

                    if (d == 0)
                        acTextEdit1.EditValue = "-" + acTextEdit1.Text;
                    else
                        acTextEdit1.EditValue = -d;
                }
                   
                
            }
            catch(Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }


    }
}