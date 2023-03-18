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
    public partial class WorkStopEnd : BaseMenuDialog
    {

        private int idleTime = 0;
        private string _strMcCode = "";
        private string _strStopCause = "";
        private string _strIdleID = "";
        private string _strEmpCode = "";
        private string _strWoNo = "";
        private string _strACtualID = "";

        private DateTime startTime = DateTime.Today;

        private bool _idle = true;      //true:비가동, false:작업중단

        public WorkStopEnd(string mcCode, string empCode, bool idle)
        {
            InitializeComponent();

            _strMcCode = mcCode;
            _strEmpCode = empCode;
            _idle = idle;

            Control[] con = POP20A_M0A.formcount(this);
            foreach (Control down in con) // 컨트롤 전체 조회
            {
                if (down.Name.StartsWith("btn"))
                {
                    Control[] ctrls = this.Controls.Find(down.Name, true);

                    ((ControlManager.acSimpleButton)ctrls[0]).Font = new Font(acInfo.SysConfig.GetSysConfigByMemory("DEFAULT_FONT"), acInfo.SysConfig.GetSysConfigByMemory("DEFAULT_FONT_SIZE").toInt() + 4,
                    FontStyle.Regular, GraphicsUnit.Point);
                }
            }

            acGridView2.GridType = acGridView.emGridType.LIST_USERCONFIG2;

            acGridView2.AddTextEdit("CD_CODE", "원인코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);

            acGridView2.AddTextEdit("CD_NAME", "원인", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView2.AddTextEdit("TIME", "시간(분)", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.Columns["TIME"].AppearanceCell.BackColor = Color.WhiteSmoke;

            acGridView2.Columns["TIME"].SummaryItem.SetSummary(DevExpress.Data.SummaryItemType.Sum, acGridView2.Columns["TIME"].DisplayFormat.FormatString);

            acGridView2.OptionsView.ShowFooter = true;

            POP20A_M0A.SetPopGridFont(acGridView2, null);

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("MC_CODE", typeof(String)); //
            paramTable.Columns.Add("IDLE_STATE", typeof(String)); //


            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["MC_CODE"] = _strMcCode;
            paramRow["IDLE_STATE"] = 1;

            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            DataSet resultSet = BizRun.QBizRun.ExecuteService(this, "POP20A_SER7", paramSet, "RQSTDT", "RSLTDT");

            DataTable resultDT = resultSet.Tables["RSLTDT"];


            _strStopCause = resultDT.Rows[0]["IDLE_CODE"].ToString();
            _strIdleID = resultDT.Rows[0]["IDLE_ID"].ToString();
            startTime = resultDT.Rows[0]["START_TIME"].toDateTime();
            _strACtualID = resultDT.Rows[0]["ACTUAL_ID"].ToString();
            _strWoNo = resultDT.Rows[0]["WO_NO"].ToString();

            TimeSpan ts = DateTime.Now.Subtract(startTime);

            idleTime = ts.TotalMinutes.toInt();

            acLayoutControl2.GetEditor("IDLE_TIME").Value = idleTime;

            if (_idle)
            {
                this.Text = "비가동";
                IdleSearch();
            }
            else
            {
                this.Text = "작업 중단";
                PauseSearch();
            }
                

            #region 이벤트 설정
            
            //acGridView1.RowCellClick += acGridView1_RowCellClick;

            acGridView2.RowCellClick += acGridView2_RowCellClick;
            
            #endregion

        }
        
        void acGridView2_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            if (e.Column.Name == "colTIME")
            {
                KeyPad kp = new KeyPad();

                kp.DialogMode = BaseMenuDialog.emDialogMode.NEW;

                kp.ParentControl = this;

                base.ChildFormAdd("NEW", kp);


                if (kp.ShowDialog() == DialogResult.OK)
                {
                    DataRow focus = acGridView2.GetFocusedDataRow();
                    if (focus["CD_CODE"].ToString() == _strStopCause)
                    {
                        if (kp.OutputData.toInt() == 0)
                        {
                            acMessageBox.Show(this, "처음원인은 0으로 수정하실 수 없습니다.", "", false, acMessageBox.emMessageBoxType.CONFIRM);
                            return;
                        }
                    }
                    focus["TIME"] = kp.OutputData;
                    idleTImeSpan(focus, false);
                }
            }
        }
        private void OK()
        {
            int idleTot = 0;

            if (idleTime > 0)
            {
                for (int i = 0; i < idleDT.Rows.Count; i++)
                {

                    if (idleDT.Rows[i]["IDLE_TIME"].toInt() == 0)
                    {
                        idleDT.Rows[i].Delete();
                    }

                }
            }

                foreach (DataRow row in idleDT.Rows)
                {
                    idleTot = row["IDLE_TIME"].toInt() + idleTot;
                }

            if (idleTot != idleTime)
            {
                acMessageBox.Show(this, "입력한 시간이 총 시간과 같지 않습니다.", "", false, acMessageBox.emMessageBoxType.CONFIRM);
                return;
            }

            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(idleDT);

            DataSet resultSet = BizRun.QBizRun.ExecuteService(this, "POP20A_UPD", paramSet, "RQSTDT", "RSLTDT");
            

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

        void PauseSearch()
        {
            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("CAT_CODE", typeof(String)); //


            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["CAT_CODE"] = "C009";

            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            DataSet resultSet = BizRun.QBizRun.ExecuteService(this, "POP20A_SER2", paramSet, "RQSTDT", "RSLTDT");

            DataTable resultDT = StopTime(resultSet.Tables["RSLTDT"], acGridView2);

            acGridView2.GridControl.DataSource = resultDT;

        }

        void IdleSearch()
        {
            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("CAT_CODE", typeof(String)); //


            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["CAT_CODE"] = "C010";

            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            DataSet resultSet = BizRun.QBizRun.ExecuteService(this, "POP20A_SER2", paramSet, "RQSTDT", "RSLTDT");

            DataTable resultDT = StopTime(resultSet.Tables["RSLTDT"], acGridView2);

            acGridView2.GridControl.DataSource = resultDT;

            
        }

        private DataTable StopTime(DataTable dt, acGridView grid)
        {
            dt.Columns.Add("TIME");

            foreach (DataRow row in dt.Rows)
            {
                if (row["CD_CODE"].ToString() == _strStopCause)
                {
                    row["TIME"] = idleTime;
                    idleTImeSpan(row, true);

                }
                else
                {
                    //row["TIME"] = 0;
                }
            }

            DataTable rsltDT = dt;

            return rsltDT;
        }

        private DataTable idleDT = new DataTable("RQSTDT");
        void idleTImeSpan(DataRow row, bool first)
        {
            bool change = false;
            if (idleDT.Rows.Count != 0)
            {
                for (int i = 0; i < idleDT.Rows.Count; i++)
                {
                    if (idleDT.Rows[i]["IDLE_CODE"].ToString() == row["CD_CODE"].ToString())
                    {
                        idleDT.Rows[i]["IDLE_TIME"] = row["TIME"];
                        idleDT.Rows[i]["END_TIME"] = idleDT.Rows[i]["START_TIME"].toDateTime().AddMinutes(row["TIME"].toDouble());
                        startTime = idleDT.Rows[i]["END_TIME"].toDateTime();
                        change = true;
                    }
                    else
                    {
                        if (change)
                        {
                            idleDT.Rows[i]["START_TIME"] = idleDT.Rows[i - 1]["END_TIME"];
                            idleDT.Rows[i]["END_TIME"] = idleDT.Rows[i]["START_TIME"].toDateTime().AddMinutes(idleDT.Rows[i]["IDLE_TIME"].toDouble());
                            startTime = idleDT.Rows[i]["END_TIME"].toDateTime();
                        }
                    }
                }
            }

            DateTime endTime = startTime.AddMinutes(row["TIME"].toDouble());

            if (!change)
            {
                if (!idleDT.Columns.Contains("PLT_CODE"))
                {
                    idleDT.Columns.Add("PLT_CODE", typeof(String)); //
                    idleDT.Columns.Add("IDLE_ID", typeof(String)); //
                    idleDT.Columns.Add("MC_CODE", typeof(String)); //
                    idleDT.Columns.Add("EMP_CODE", typeof(String)); //
                    idleDT.Columns.Add("IDLE_CODE", typeof(String)); //
                    idleDT.Columns.Add("IDLE_TIME", typeof(String)); //
                    idleDT.Columns.Add("IDLE_STATE", typeof(String)); //
                    idleDT.Columns.Add("START_TIME", typeof(DateTime)); //
                    idleDT.Columns.Add("END_TIME", typeof(DateTime)); //
                    idleDT.Columns.Add("SCOMMENT", typeof(String)); //
                    idleDT.Columns.Add("REG_EMP", typeof(String)); //
                    idleDT.Columns.Add("DATA_FLAG", typeof(String)); //
                    idleDT.Columns.Add("WO_NO", typeof(String));
                    idleDT.Columns.Add("ACTUAL_ID", typeof(String));

                }
                DataRow paramRow = idleDT.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["MC_CODE"] = _strMcCode;
                paramRow["EMP_CODE"] = _strEmpCode;
                paramRow["IDLE_CODE"] = row["CD_CODE"];
                paramRow["IDLE_STATE"] = 0;
                paramRow["IDLE_TIME"] = row["TIME"];
                paramRow["START_TIME"] = startTime;
                paramRow["END_TIME"] = endTime;
                paramRow["SCOMMENT"] = DBNull.Value;
                paramRow["REG_EMP"] = acInfo.UserID;
                paramRow["DATA_FLAG"] = 0;
                paramRow["WO_NO"] = _strWoNo;
                paramRow["ACTUAL_ID"] = _strACtualID;

                if (first == true)
                {
                    paramRow["IDLE_ID"] = _strIdleID;
                    
                }
                else
                {
                    startTime = endTime;
                }

                idleDT.Rows.Add(paramRow);
            }



        }
    }
}

