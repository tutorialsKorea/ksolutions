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
            foreach (Control down in con) // 컨트롤 전체 조회
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
            foreach (Control down in con) // 컨트롤 전체 조회
            {
                if (down.Name.StartsWith("btn"))
                {
                    Control[] ctrls = this.Controls.Find(down.Name, true);

                    ((ControlManager.acSimpleButton)ctrls[0]).Font = new Font(acInfo.SysConfig.GetSysConfigByMemory("DEFAULT_FONT"), acInfo.SysConfig.GetSysConfigByMemory("DEFAULT_FONT_SIZE").toInt() + 10,
                    FontStyle.Regular, GraphicsUnit.Point);
                }
            }

            this.Text = "작업 중단 사유를 선택하세요.";
            acLabelControl2.Text = "작업 중단 사유";

            (acLayoutControl2.GetEditor("IDLE_CAUSE").Editor as acLookupEdit).SetCode(cat_code);
            
        }

        private void OK()
        {
            DataRow layoutRow = acLayoutControl2.CreateParameterRow();

            if (layoutRow["IDLE_CAUSE"].ToString() == "" )
            {
                acMessageBox.Show("원인이 선택되지 않았습니다.", this.Text, acMessageBox.emMessageBoxType.CONFIRM);
                return;
            }

            this.OutputData = layoutRow;

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
        
    }
}

