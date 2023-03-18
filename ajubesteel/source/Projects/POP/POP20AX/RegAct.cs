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
using BizManager;

namespace POP
{
    public partial class RegAct : BaseMenuDialog
    {
        private DataRow dr = null;
        private DataRow _row = null;
        public RegAct(DataRow focus, DataRow row)
        {
            InitializeComponent();

            dr = focus;
            _row = row;

            acLayoutControl4.DataBind(dr, false);
            acLayoutControl4.DataBind(_row, false);

            //acGridView2.GridType = acGridView.emGridType.LIST_USERCONFIG;

            //acGridView2.AddTextEdit("PAUSE_TIME", "정지시간", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            //acGridView2.AddTextEdit("PAUSE_CAUSE", "원인", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            //acGridView2.BestFitColumns();


            //acGridView3.GridType = acGridView.emGridType.LIST_USERCONFIG;

            //acGridView3.AddTextEdit("STOP_CAUSE", "중단원인", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            //acGridView3.AddTextEdit("STOP_TIME", "중단시간", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            //acGridView3.BestFitColumns();

            (acLayoutControl4.GetEditor("SDATE2").Editor as acLookupEdit).SetCode("P002");
            (acLayoutControl4.GetEditor("SDATE3").Editor as acLookupEdit).SetCode("P003");
            //(acLayoutControl5.GetEditor("SDATE4").Editor as acLookupEdit).SetCode("P004");

            (acLayoutControl4.GetEditor("EDATE2").Editor as acLookupEdit).SetCode("P002");
            (acLayoutControl4.GetEditor("EDATE3").Editor as acLookupEdit).SetCode("P003");
            //(acLayoutControl5.GetEditor("EDATE4").Editor as acLookupEdit).SetCode("P004");

            (acLayoutControl4.GetEditor("MASTER_CAUSE").Editor as acLookupEdit).SetCode("C400");
            (acLayoutControl4.GetEditor("PAUSE_REASON").Editor as acLookupEdit).SetCode("C009");

            acLayoutControl4.OnValueChanged += acLayoutControl5_OnValueChanged;

            acTextEdit9.EditValueChanged += acTextEdit9_EditValueChanged;

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("WO_NO", typeof(String)); //


            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["WO_NO"] = dr["WO_NO"];


            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            DataSet resultSet = BizRun.QBizRun.ExecuteService(this, "POP20A_SER6", paramSet, "RQSTDT", "RSLTDT");

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

            if (acLayoutControl4.GetEditor("OK_QTY").Value.toInt() == 0 &&
                acLayoutControl4.GetEditor("NG_QTY").Value.toInt() == 0 &&
                acLayoutControl4.GetEditor("PAUSE_REASON").Value.toStringEmpty() == "")
            {
                acLayoutControlItem23.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                acLayoutControl4.GetEditor("PAUSE_REASON").isRequired = true;
                this.ActiveControl = acLookupEdit3;
                acMessageBox.Show("중단 사유를 입력하세요.", this.Text, acMessageBox.emMessageBoxType.CONFIRM);
                return;
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
        private void btnNG_Click(object sender, EventArgs e)
        {
            NgCause frm = new NgCause();

            frm.ShowDialog();


            //불량원인 등록
            if (frm.DialogResult == DialogResult.OK)
            {

                DataRow frmRow = frm.OutputData as DataRow;
            }
        }

        private bool ActTimeFlag()
        {
            if (acLookupEdit1.Value.toStringEmpty() != ""
                && acLookupEdit2.Value.toStringEmpty() != ""
                && acTextEdit13.Value.toStringEmpty() != ""
                && acLookupEdit4.Value.toStringEmpty() != ""
                && acLookupEdit5.Value.toStringEmpty() != ""
                && acTextEdit14.Value.toStringEmpty() != "")
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
                case "OK_QTY":

                    if (newValue.toInt() == 0)
                    {
                        acLayoutControlItem23.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                        acLayoutControl4.GetEditor("PAUSE_REASON").isRequired = true;
                    }
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
            if (e.Clicks == 1)
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
            if (e.Clicks == 1)
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


    }
}

