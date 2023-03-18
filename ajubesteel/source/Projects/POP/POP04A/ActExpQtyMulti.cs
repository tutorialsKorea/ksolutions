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
using System.Runtime.InteropServices;

using BizManager;

namespace POP
{
    public partial class ActExpQtyMulti : BaseMenuDialog
    {

        private DataTable _LinkData = null;


        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);


             

        string Default_Font = acInfo.SysConfig.GetSysConfigByMemory("DEFAULT_FONT");
       
        int Panel_FontSize = acInfo.SysConfig.GetSysConfigByMemory("PANNEL_FONT_SIZE").toInt();


        public ActExpQtyMulti(DataTable linkData)
        {
            InitializeComponent();


            acGridView1.AddTextEdit("PROD_CODE", "수주번호", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("PROD_NAME", "모델명", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("PART_NAME", "부품명", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

            Control[] con = POP04A_M0A.formcount(this);
            foreach (Control down in con) // 컨트롤 전체 조회
            {
                if (down is acSimpleButton)
                {
                    Control[] ctrls = this.Controls.Find(down.Name, true);

                    ((ControlManager.acSimpleButton)ctrls[0]).Font = new Font(Default_Font, Panel_FontSize + 10, FontStyle.Regular, GraphicsUnit.Point);
                }
            }

            StringBuilder oldCheck = new StringBuilder();
            
            GetPrivateProfileString("PAD2", "USE_FLAG", "False", oldCheck, 10, "C:\\CubicTek\\keypad.ini");

            if (oldCheck.ToString() == "True")
            {
                acCheckEdit1.CheckState = CheckState.Checked;
            }
            else
            {
                acCheckEdit1.CheckState = CheckState.Unchecked;
            }

            acGridView1.GridControl.DataSource = linkData;

            POP04A_M0A.SetPopGridFont(acGridView1, null, null);

            acGridView1.BestFitColumns();

            _LinkData = linkData;

        }

     

        public override void DialogNew()
        {
            try
            { 
                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("CHAIN_WO_NO", typeof(String)); //
                paramTable.Columns.Add("PROC_CODE", typeof(String)); //

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["CHAIN_WO_NO"] = _LinkData.Rows[0]["CHAIN_WO_NO"];
                paramRow["PROC_CODE"] = _LinkData.Rows[0]["PROC_CODE"];

                paramTable.Rows.Add(paramRow);

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD, "POP04A_SER11_2", paramSet, "RQSTDT", "RSLTDT",
                  QuickSearch,
                  QuickException);

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        void QuickSearch(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                if (e.result.Tables["RSLTDT"].Rows.Count > 0)
                {
                    e.result.Tables["RSLTDT"].Columns.Add("PLN_QTY", typeof(int));

                    foreach (DataRow row in e.result.Tables["RSLTDT"].Rows)
                    {
                        row["PLN_QTY"] = row["LEFT_QTY"].toInt() - row["ING_QTY"].toInt();

                        acLayoutControl1.DataBind(row, false);
                    }

                }
                else
                {
                    e.result.Tables["RSLTDT"].Columns.Add("PLN_QTY", typeof(int));

                    DataRow row = e.result.Tables["RSLTDT"].NewRow();

                    row["ACT_QTY"] = row["ING_QTY"] = 0;
                    row["PLN_QTY"] = row["LEFT_QTY"];

                    acLayoutControl1.DataBind(row, false);

                }

                acLayoutControl1.GetEditor("PLN_QTY").FocusEdit();

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        void QuickException(object sender, QBiz QBiz, BizManager.BizException ex)
        {
            acMessageBox.Show(this, ex);
        }




        private void OK()
        {
            DataRow layoutRow = acLayoutControl1.CreateParameterRow();

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

        private void acTextEdit1_MouseDown(object sender, MouseEventArgs e)
        {
            if (acCheckEdit1.CheckState == CheckState.Checked)
            {
                KeyPad kp = new KeyPad();

                kp.DialogMode = BaseMenuDialog.emDialogMode.NEW;

                kp.ParentControl = this;

                base.ChildFormAdd("NEW", kp);


                if (kp.ShowDialog() == DialogResult.OK)
                {

                    acTextEdit1.EditValue = acConvert.toDecimal(kp.OutputData);

                }
            }
        }

        private void acCheckEdit1_CheckedChanged(object sender, EventArgs e)
        {
            // 키패드 사용유무 설정 변경시

            string PathINI = "C:\\CubicTek\\keypad.ini";

            WritePrivateProfileString("PAD2", "USE_FLAG", acCheckEdit1.Value.ToString(), @PathINI);

        }
    }
}

