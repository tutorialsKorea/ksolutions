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
using DevExpress.XtraEditors;
using System.Runtime.InteropServices;
using BizManager;

namespace POP
{
    public partial class RegAct3 : BaseMenuDialog
    {
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);
      

        public RegAct3(DataTable dt)
        {
            InitializeComponent();

            //dr = focus;
            //_row = row;

            //acGridView1.AddTextEdit("DRAW_NO", "도면번호", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("PROC_NAME", "공정", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("PART_NAME", "픔명", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            //acGridView1.AddTextEdit("DRAW_NO", "작업자", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("MAT_SPEC", "제품규격", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("MC_NAME", "설비", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("PART_QTY", "수량", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.GridControl.DataSource = dt;

            POP04A_M0A.SetPopGridFont(acGridView1, null, null);

            acGridView1.BestFitColumns();

            //acLayoutControl4.DataBind(dr, false);
            //acLayoutControl4.DataBind(_row, false);


            StringBuilder oldCheck= new StringBuilder();
           
            GetPrivateProfileString("PAD1", "USE_FLAG", "False", oldCheck, 10, "C:\\CubicTek\\keypad.ini");
           
            if(oldCheck.ToString() == "True")
            {
                acCheckEdit1.CheckState = CheckState.Checked;
            }
            else
            {
                acCheckEdit1.CheckState = CheckState.Unchecked;
            }



            //if (dr.Table.Columns.Contains("ACT_QTY") && dr.Table.Columns.Contains("PART_QTY"))
            //{
            //    acLayoutControl4.GetEditor("OK_QTY").Value  = dr["PART_QTY"].toInt() - dr["ACT_QTY"].toInt();
            //}

            DataTable paramDT = new DataTable("RQSTDT");
            paramDT.Columns.Add("PLT_CODE", typeof(String)); //
            paramDT.Columns.Add("CHAIN_WO_NO", typeof(String)); //
            paramDT.Columns.Add("PROC_CODE", typeof(String)); //

            DataRow paramRw = paramDT.NewRow();
            paramRw["PLT_CODE"] = acInfo.PLT_CODE;
            paramRw["CHAIN_WO_NO"] = dt.Rows[0]["CHAIN_WO_NO"];
            paramRw["PROC_CODE"] = dt.Rows[0]["PROC_CODE"];


            paramDT.Rows.Add(paramRw);
            DataSet paramDS = new DataSet();
            paramDS.Tables.Add(paramDT);

            DataSet resultDS = BizRun.QBizRun.ExecuteService(this, "POP04A_SER11_2", paramDS, "RQSTDT", "RSLTDT");

            

            int plnQty = 0;
            int actQty = 0;

            foreach (DataRow row in dt.Rows)
            {
                plnQty = plnQty + row["PART_QTY"].toInt();
                actQty = actQty + row["ACT_QTY"].toInt();
            }

            acLayoutControl4.GetEditor("ACT_QTY").Value = actQty;
            acLayoutControl4.GetEditor("PART_QTY").Value = plnQty;
            acLayoutControl4.GetEditor("OK_QTY").Value = plnQty - actQty;


            (acLayoutControl4.GetEditor("SDATE2").Editor as acLookupEdit).SetCode("P002");
            (acLayoutControl4.GetEditor("SDATE3").Editor as acLookupEdit).SetCode("P003");
       

            (acLayoutControl4.GetEditor("EDATE2").Editor as acLookupEdit).SetCode("P002");
            (acLayoutControl4.GetEditor("EDATE3").Editor as acLookupEdit).SetCode("P003");
           

            (acLayoutControl4.GetEditor("MASTER_CAUSE").Editor as acLookupEdit).SetCode("C400");
         

            acLayoutControl4.OnValueChanged += acLayoutControl5_OnValueChanged;
            acLayoutControl4.OnValueKeyDown += AcLayoutControl4_OnValueKeyDown;

            acTextEdit9.EditValueChanged += acTextEdit9_EditValueChanged;

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("WO_NO", typeof(String)); //


            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["WO_NO"] = dt.Rows[0]["WO_NO"];


            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            DataSet resultSet = BizRun.QBizRun.ExecuteService(this, "POP04A_SER15", paramSet, "RQSTDT", "RSLTDT");

            if (resultSet.Tables["RSLTDT"].Rows.Count > 0)
            {
                acLayoutControl4.GetEditor("SDATE1").Value = resultSet.Tables["RSLTDT"].Rows[0]["S_DATE"];
                (acLayoutControl4.GetEditor("SDATE2").Editor as acLookupEdit).Value = resultSet.Tables["RSLTDT"].Rows[0]["SN_FLAG"];
                (acLayoutControl4.GetEditor("SDATE3").Editor as acLookupEdit).Value = resultSet.Tables["RSLTDT"].Rows[0]["SH_DATE"];
                acLayoutControl4.GetEditor("SDATE4").Value = resultSet.Tables["RSLTDT"].Rows[0]["SM_DATE"];

                acLayoutControl4.GetEditor("EDATE1").Value = resultSet.Tables["RSLTDT"].Rows[0]["E_DATE"];
                (acLayoutControl4.GetEditor("EDATE2").Editor as acLookupEdit).Value = resultSet.Tables["RSLTDT"].Rows[0]["EN_FLAG"];
                (acLayoutControl4.GetEditor("EDATE3").Editor as acLookupEdit).Value = resultSet.Tables["RSLTDT"].Rows[0]["EH_DATE"];
                acLayoutControl4.GetEditor("EDATE4").Value = resultSet.Tables["RSLTDT"].Rows[0]["EM_DATE"];
            }
            

            if (ActTimeFlag())
            {
                DataRow layoutRow = acLayoutControl4.CreateParameterRow();

                acTextEdit1.Text = ActTimeSpan(layoutRow).ToString();
            }

            acLayoutControlItem23.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;

            this.ActiveControl = acTextEdit10;

        }

        private void AcLayoutControl4_OnValueKeyDown(object sender, IBaseEditControl info, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btnSave_Click(null, null);
            }
        }

        private void OK()
        {
                this.DialogResult = DialogResult.OK;
        }

        


        private void btnSave_Click(object sender, EventArgs e)
        {
            //저장

            if (!acLayoutControl4.GetEditor("MASTER_CAUSE").isReadyOnly || !acLayoutControl4.GetEditor("DETAIL_CAUSE").isReadyOnly) 
            {
                if (acLayoutControl4.GetEditor("MASTER_CAUSE").Value == null || acLayoutControl4.GetEditor("DETAIL_CAUSE").Value == null)
                {
                    acMessageBox.Show("불량원인을 선택하지 않았습니다.", this.Text, acMessageBox.emMessageBoxType.CONFIRM); 
                    return;
                }
            }


            this.OutputData = acLayoutControl4.CreateParameterRow();

            this.OK();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //취소
            this.DialogResult = DialogResult.Cancel;
        }

        private DataSet _NgDataSet = null;
        //private void btnNG_Click(object sender, EventArgs e)
        //{
        //    NgCause frm = new NgCause();

        //    frm.ShowDialog();


        //    //불량원인 등록
        //    if (frm.DialogResult == DialogResult.OK)
        //    {

        //        DataRow frmRow = frm.OutputData as DataRow;
        //    }
        //}

        private bool ActTimeFlag()
        {
            if (acLookupEdit1.Value.toStringEmpty() != ""
                && acLookupEdit2.Value.toStringEmpty() != ""
                && acTextEdit12.Value.toStringEmpty() != ""
                && acLookupEdit4.Value.toStringEmpty() != ""
                && acLookupEdit5.Value.toStringEmpty() != ""
                && acTextEdit13.Value.toStringEmpty() != "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private double ActTimeSpan(DataRow layout)
        {
            string actTime = "";

            int ti = 0;
            int ti2 = 0;

            int hour = 0;
            int hour2 = 0;

            if (layout["SDATE2"].toStringEmpty() == "2" && layout["SDATE3"].toStringEmpty() == "12") { hour = 0; } else { hour = layout["SDATE3"].toInt(); };
            if (layout["EDATE2"].toStringEmpty() == "2" && layout["EDATE3"].toStringEmpty() == "12") { hour2 = 0; } else { hour2 = layout["EDATE3"].toInt(); };

            if (layout["SDATE2"].toStringEmpty() == "1")
            {
                ti = 0;
            }
            else
            {
                ti = 12;
            }

            if (layout["EDATE2"].toStringEmpty() == "1")
            {
                ti2 = 0;
            }
            else
            {
                ti2 = 12;
            }

            string sdate = acDateEdit1.Text + " " + Convert.ToString(hour + ti) + ":" + acTextEdit12.Value.toStringEmpty() + ":00";

            string edate = acDateEdit2.Text + " " + Convert.ToString(hour2 + ti2) + ":" + acTextEdit13.Value.toStringEmpty() + ":00";

            // 점심시간/저녁시간 제외 및 잔업시간 계산
            double manTime = 0;
            double otTime = 0;
            acDateEdit.GetActTime(acDateEdit2.toDateTime(), Convert.ToDateTime(sdate), Convert.ToDateTime(edate), out manTime, out  otTime);

            double act = manTime + otTime;

            TimeSpan ts = Convert.ToDateTime(edate).Subtract(Convert.ToDateTime(sdate));

            actTime = ts.TotalMinutes.ToString();

            return act;
        }

        void acLayoutControl5_OnValueChanged(object sender, IBaseEditControl info, object newValue)
        {
            DataRow layoutRow = acLayoutControl4.CreateParameterRow();

            switch (info.ColumnName)
            {
                case "MASTER_CAUSE":

                    (acLayoutControl4.GetEditor("DETAIL_CAUSE").Editor as acLookupEdit).SetCode("C401", newValue);

                break;
                
            }
        }

        

        void acTextEdit9_EditValueChanged(object sender, EventArgs e)
        {
            if (acTextEdit9.Text.toInt() != 0)
            {
                acLayoutControl4.GetEditor("MASTER_CAUSE").isReadyOnly = false;
                acLayoutControl4.GetEditor("DETAIL_CAUSE").isReadyOnly = false;

                acLayoutControl4.GetEditor("MASTER_CAUSE").isRequired = true;
                acLayoutControl4.GetEditor("DETAIL_CAUSE").isRequired = true;

            }
            else
            {
                acLayoutControl4.GetEditor("MASTER_CAUSE").isReadyOnly = true;
                acLayoutControl4.GetEditor("DETAIL_CAUSE").isReadyOnly = true;

                acLayoutControl4.GetEditor("MASTER_CAUSE").Value = null;
                acLayoutControl4.GetEditor("DETAIL_CAUSE").Value = null;
            }
        }

        private void acTextEdit9_MouseDown(object sender, MouseEventArgs e)
        {
            //불량수량
            if (acCheckEdit1.CheckState == CheckState.Checked)
            {
                KeyPad kp = new KeyPad();

                kp.DialogMode = BaseMenuDialog.emDialogMode.NEW;

                kp.ParentControl = this;

                base.ChildFormAdd("NEW", kp);


                if (kp.ShowDialog() == DialogResult.OK)
                {

                    acTextEdit9.EditValue = acConvert.toDecimal(kp.OutputData);

                }
            }
        }

        private void acTextEdit10_MouseDown(object sender, MouseEventArgs e)
        {
            //완료수량
            if (acCheckEdit1.CheckState == CheckState.Checked)
            {
                KeyPad kp = new KeyPad();

                kp.DialogMode = BaseMenuDialog.emDialogMode.NEW;

                kp.ParentControl = this;

                base.ChildFormAdd("NEW", kp);


                if (kp.ShowDialog() == DialogResult.OK)
                {

                    acTextEdit10.EditValue = acConvert.toDecimal(kp.OutputData);

                }
            }
        }

       
       

        private void acCheckEdit1_CheckedChanged(object sender, EventArgs e)
        {
            // 체크 박스 클릭시 

            string PathINI = "C:\\CubicTek\\keypad.ini";

            WritePrivateProfileString("PAD1", "USE_FLAG", acCheckEdit1.Value.ToString(), @PathINI);
         
        }
    }
}

