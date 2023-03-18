using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ControlManager;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraEditors.Repository;
using BizManager;
using CodeHelperManager;

namespace POP
{
    public partial class RegHandAct : BaseMenuDialog
    {
        private DataRow _row = null;
        private string _strPartCode = "";
        private DateTime _actStartTime = DateTime.Now;
        private DateTime _actEndTime = DateTime.Now;

        public RegHandAct(DataRow row)
        {
            InitializeComponent();

            _row = row;

            #region 컨트롤 설정

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

            #endregion


            acDateEdit1.EditValue = DateTime.Now;

            acDateEdit2.EditValue = DateTime.Now;

            (acLayoutControl4.GetEditor("SDATE2").Editor as acLookupEdit).SetCode("P002");
            (acLayoutControl4.GetEditor("SDATE3").Editor as acLookupEdit).SetCode("P003");

            (acLayoutControl4.GetEditor("EDATE2").Editor as acLookupEdit).SetCode("P002");
            (acLayoutControl4.GetEditor("EDATE3").Editor as acLookupEdit).SetCode("P003");

            (acLayoutControl4.GetEditor("MASTER_CAUSE").Editor as acLookupEdit).SetCode("C400");

            (acLayoutControl4.GetEditor("PART_PRODTYPE").Editor as acLookupEdit).SetCode("M007");

            
            acLayoutControl4.OnValueChanged += acLayoutControl4_OnValueChanged;

            acTextEdit11.EditValueChanged += acTextEdit11_EditValueChanged;

            acLayoutControl4.DataBind(_row, false);

            this.ActiveControl = acTextEdit12;


            #region 이벤트 설정



            #endregion

        }


        public override void DialogInit()
        {
            
        }
     
        void acTextEdit11_EditValueChanged(object sender, EventArgs e)
        {
            if (acTextEdit11.Text.toInt() != 0)
            {
                acLayoutControl4.GetEditor("MASTER_CAUSE").isReadyOnly = false;
                acLayoutControl4.GetEditor("DETAIL_CAUSE").isReadyOnly = false;
            }
            else
            {
                acLayoutControl4.GetEditor("MASTER_CAUSE").isReadyOnly = true;
                acLayoutControl4.GetEditor("DETAIL_CAUSE").isReadyOnly = true;

                acLayoutControl4.GetEditor("MASTER_CAUSE").Value = null;
                acLayoutControl4.GetEditor("DETAIL_CAUSE").Value = null;
            }
        }

        private void OK()
        {

            DataRow focus = acLayoutControl4.CreateParameterRow();
            if (acLayoutControl4.ValidCheck() == false)
            {
                return;

            }
            if (_strPartCode == "")
            {
                acMessageBox.Show("품명선택을 하지 않았습니다.", this.Text, acMessageBox.emMessageBoxType.CONFIRM);
                return;
            }

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("EMP_CODE", typeof(String)); //
            paramTable.Columns.Add("WORK_DATE", typeof(String)); //
            paramTable.Columns.Add("PROD_CODE", typeof(String)); //
            paramTable.Columns.Add("PART_CODE", typeof(String)); //
            paramTable.Columns.Add("PROC_CODE", typeof(String)); //
            paramTable.Columns.Add("MC_CODE", typeof(String)); //
            paramTable.Columns.Add("PROC_STAT", typeof(String)); //
            paramTable.Columns.Add("ACT_START_TIME", typeof(DateTime)); //
            paramTable.Columns.Add("ACT_END_TIME", typeof(DateTime)); //
            paramTable.Columns.Add("SELF_TIME", typeof(decimal)); //
            paramTable.Columns.Add("MAN_TIME", typeof(decimal)); //
            paramTable.Columns.Add("OT_TIME", typeof(decimal)); //
            paramTable.Columns.Add("OK_QTY", typeof(String)); //
            paramTable.Columns.Add("NG_QTY", typeof(String)); //
            paramTable.Columns.Add("IS_MPROC_ACT", typeof(String)); //
            paramTable.Columns.Add("IS_LAST", typeof(String)); //출하
            paramTable.Columns.Add("REG_EMP", typeof(String)); //

            DataTable paramTable2 = new DataTable("RQSTDT_NG");
            paramTable2.Columns.Add("MASTER_CAUSE", typeof(String)); //
            paramTable2.Columns.Add("DETAIL_CAUSE", typeof(String)); //
            paramTable2.Columns.Add("QUANTITY", typeof(int)); //


            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["EMP_CODE"] = _row["EMP_CODE"];
            paramRow["WORK_DATE"] = focus["SDATE1"];
            paramRow["PROD_CODE"] = DBNull.Value;
            paramRow["PART_CODE"] = _strPartCode;
            paramRow["PROC_CODE"] = focus["PROC_CODE"];
            paramRow["MC_CODE"] = _row["MC_CODE"];
            paramRow["PROC_STAT"] = 4;
            paramRow["ACT_START_TIME"] = _actStartTime;
            paramRow["ACT_END_TIME"] = _actEndTime;
            paramRow["SELF_TIME"] = 0;
            paramRow["MAN_TIME"] = focus["MAN_TIME"];
            paramRow["OT_TIME"] = 0;
            paramRow["OK_QTY"] = focus["OK_QTY"];
            paramRow["NG_QTY"] = focus["NG_QTY"];
            paramRow["IS_MPROC_ACT"] = 0;
            paramRow["IS_LAST"] = focus["SHIP"];
            paramRow["REG_EMP"] = acInfo.UserID;

            if (focus["MASTER_CAUSE"].ToString() != "")
            {
                DataRow paramRow2 = paramTable2.NewRow();
                paramRow2["MASTER_CAUSE"] = focus["MASTER_CAUSE"];
                paramRow2["DETAIL_CAUSE"] = focus["DETAIL_CAUSE"];
                paramRow2["QUANTITY"] = focus["NG_QTY"];
                paramTable2.Rows.Add(paramRow2);
            }


            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);
            paramSet.Tables.Add(paramTable2);

            BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.SAVE, "POP20A_INS2", paramSet, "RQSTDT,RQSTDT_NG", "RSLTDT",
                   QuickIns,
                   QuickException);


        }
        void QuickIns(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                this.DialogResult = DialogResult.OK;
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

        void acLayoutControl4_OnValueChanged(object sender, IBaseEditControl info, object newValue)
        {
            //그리드 변경시 안타면 switch문 빼고 테스트 해볼것
            DataRow layoutRow = acLayoutControl4.CreateParameterRow();

            switch (info.ColumnName)
            {
                case "MASTER_CAUSE":

                    (acLayoutControl4.GetEditor("DETAIL_CAUSE") as acLookupEdit).SetCode("C401", newValue);

                    break;
                case "SDATE2":

                    if (ActTimeFlag())
                    {
                        acTextEdit1.Text = ActTimeSpan(layoutRow).ToString();
                    }

                    break;

                case "SDATE3":

                    if (ActTimeFlag())
                    {
                        acTextEdit1.Text = ActTimeSpan(layoutRow).ToString();
                    }

                    break;

                case "SDATE4":

                    if (newValue.toInt() >= 60)
                    {
                        acMessageBox.Show("60분 미만만 입력이 가능합니다..", this.Text, acMessageBox.emMessageBoxType.CONFIRM);
                        acLayoutControl4.GetEditor("SDATE4").Value = 0;
                        return;
                    }

                    if (ActTimeFlag())
                    {
                        acTextEdit1.Text = ActTimeSpan(layoutRow).ToString();
                    }

                    break;

                case "EDATE2":

                    if (ActTimeFlag())
                    {
                        acTextEdit1.Text = ActTimeSpan(layoutRow).ToString();
                    }

                    break;

                case "EDATE3":

                    if (ActTimeFlag())
                    {
                        acTextEdit1.Text = ActTimeSpan(layoutRow).ToString();
                    }

                    break;

                case "EDATE4":

                    if (newValue.toInt() >= 60)
                    {
                        acMessageBox.Show("60분 미만만 입력이 가능합니다..", this.Text, acMessageBox.emMessageBoxType.CONFIRM);
                        acLayoutControl4.GetEditor("EDATE4").Value = 0;
                        return;
                    }

                    if (ActTimeFlag())
                    {
                        acTextEdit1.Text = ActTimeSpan(layoutRow).ToString();
                    }

                    break;

            }

        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            //저장

            if (!acLookupEdit8.isReadyOnly || !acLookupEdit10.isReadyOnly)
            {
                if (acLookupEdit8.Value.toStringEmpty() == "" || acLookupEdit10.Value.toStringEmpty() == "")
                {
                    acMessageBox.Show("불량원인을 선택하지 않았습니다.", this.Text ,acMessageBox.emMessageBoxType.CONFIRM);
                    return;
                }
            }

            this.OK();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //취소
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnSelProd_Click(object sender, EventArgs e)
        {
            //품명선택
            SelProduct frm = new SelProduct();
            
            frm.DialogMode = BaseMenuDialog.emDialogMode.NEW;

            frm.ParentControl = this;

            base.ChildFormAdd("NEW", frm);

            if (frm.ShowDialog() == DialogResult.OK)
            {
                DataRow frmRow = frm.OutputData as DataRow;

                acLayoutControl4.DataBind(frmRow, false);
                _strPartCode = frmRow["PART_CODE"].ToString();

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("PART_CODE", typeof(String)); //

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["PART_CODE"] = _strPartCode;

                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                (acLayoutControl4.GetEditor("PROC_CODE").Editor as acLookupEdit).SetData("PROC_NAME", "PROC_CODE", "POP20A_SER4", paramSet, "RQSTDT", "RSLTDT");

                acTextEdit12.Focus();
            }
        }

        private DataSet _NgDataSet = null;
        private void btnNG_Click(object sender, EventArgs e)
        {
            NgCause frm = new NgCause();

            //불량원인 등록
            if (frm.ShowDialog() == DialogResult.OK)
            {

                DataRow frmRow = frm.OutputData as DataRow;
            }
        }

        private bool ActTimeFlag()
        {
            if (acLookupEdit2.Value.toStringEmpty() != ""
                && acLookupEdit3.Value.toStringEmpty() != ""
                && acTextEdit6.Value.toStringEmpty() != ""
                && acLookupEdit5.Value.toStringEmpty() != ""
                && acLookupEdit6.Value.toStringEmpty() != ""
                && acTextEdit8.Value.toStringEmpty() != "")
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

            string sdate = acDateEdit1.Text + " " + Convert.ToString(hour + ti) + ":" + acTextEdit6.Value.toStringEmpty() + ":00";

            string edate = acDateEdit2.Text + " " + Convert.ToString(hour2 + ti2) + ":" + acTextEdit8.Value.toStringEmpty() + ":00";
            _actStartTime = Convert.ToDateTime(sdate);
            _actEndTime = Convert.ToDateTime(edate);

            // 점심시간/저녁시간 제외 및 잔업시간 계산
            double manTime = 0;
            double otTime = 0;
            acDateEdit.GetActTime(acDateEdit2.toDateTime(), _actStartTime, _actEndTime, out manTime, out  otTime);

            double act = manTime + otTime;


            TimeSpan ts = _actEndTime.Subtract(_actStartTime);

            actTime = ts.TotalMinutes.ToString();//((ts.Hours * 60) + ts.Minutes).toStringEmpty();

            return act;
        }

        private void acTextEdit11_MouseDown(object sender, MouseEventArgs e)
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

                    acTextEdit11.EditValue = acConvert.toDecimal(kp.OutputData);

                }
            }
        }

        private void acTextEdit12_MouseDown(object sender, MouseEventArgs e)
        {
            //완료수량
            if (e.Clicks == 2)
            {
                KeyPad kp = new KeyPad();

                kp.DialogMode = BaseMenuDialog.emDialogMode.NEW;

                kp.ParentControl = this;

                base.ChildFormAdd("NEW", kp);


                if (kp.ShowDialog() == DialogResult.OK)
                {

                    acTextEdit12.EditValue = acConvert.toDecimal(kp.OutputData);

                }
            }
        }

        private void acTextEdit6_MouseDown(object sender, MouseEventArgs e)
        {
            //시작 분
            if (e.Clicks == 2)
            {
                KeyPad kp = new KeyPad();

                kp.DialogMode = BaseMenuDialog.emDialogMode.NEW;

                kp.ParentControl = this;

                base.ChildFormAdd("NEW", kp);


                if (kp.ShowDialog() == DialogResult.OK)
                {

                    acTextEdit6.EditValue = acConvert.toDecimal(kp.OutputData);

                }
            }
        }

        private void acTextEdit8_MouseDown(object sender, MouseEventArgs e)
        {
            //완료 분
            if (e.Clicks == 1)
            {
                KeyPad kp = new KeyPad();

                kp.DialogMode = BaseMenuDialog.emDialogMode.NEW;

                kp.ParentControl = this;

                base.ChildFormAdd("NEW", kp);


                if (kp.ShowDialog() == DialogResult.OK)
                {

                    acTextEdit8.EditValue = acConvert.toDecimal(kp.OutputData);

                }
            }
        }

        private void acTextEdit11_EditValueChanged_1(object sender, EventArgs e)
        {

        }

  


    }
}

