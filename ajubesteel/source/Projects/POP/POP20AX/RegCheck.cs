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
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraBars;

namespace POP
{
    public partial class RegCheck : BaseMenuDialog
    {
        private bool _IsKeyPadUse = false;

        private DataRow dr = null;
        private DataRow _row = null;

        bool bSave = false;

        public bool IsKeyPadUse
        {
            get
            {
                return _IsKeyPadUse;
            }
            set
            {
                if (value)
                {
                    emptySpaceItem1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    acLayoutControlItem5.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                }
                else
                {
                    emptySpaceItem1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    acLayoutControlItem5.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                }

                _IsKeyPadUse = value;
            }
        }

        public RegCheck(DataRow focus, DataRow row)
        {
            InitializeComponent();

            #region 컨트롤설정
            Control[] con = POP20A_M0A.formcount(this);
            foreach (Control down in con) // 컨트롤 전체 조회
            {
                if (down.Name.StartsWith("btn"))
                {
                    Control[] ctrls = this.Controls.Find(down.Name, true);

                    if (ctrls[0] is ControlManager.acSimpleButton)
                    {
                        ((ControlManager.acSimpleButton)ctrls[0]).Font = new Font(acInfo.SysConfig.GetSysConfigByMemory("DEFAULT_FONT"), acInfo.SysConfig.GetSysConfigByMemory("DEFAULT_FONT_SIZE").toInt() + 10,
                        FontStyle.Regular, GraphicsUnit.Point);
                    }
                }
            }
            #endregion

            dr = focus;
            _row = row;

            SetDataRow(focus, row);

            acRadioGroup1.AddRadioItem("아래", false, "", false, "", (byte)0);
            acRadioGroup1.AddRadioItem("오른쪽", false, "", false, "", (byte)1);
            acRadioGroup1.SelectedIndex = 0;

            IsKeyPadUse = false;

            acGridView1.MouseDown += acGridView1_MouseDown;
            //acGridView1.KeyUp += AcGridView1_KeyUp;
            acGridView1.CellValueChanged += AcGridView1_CellValueChanged;
            acGridView1.CustomDrawCell += AcGridView1_CustomDrawCell;
            acRadioGroup1.EditValueChanged += AcRadioGroup1_EditValueChanged;
            toggle.CheckedChanged += Toggle_CheckedChanged;
        }

        private void Toggle_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            BarToggleSwitchItem bts = sender as BarToggleSwitchItem;

            if (bts.Checked)
            {
                this.TopMost = true;
            }
            else
            {
                this.TopMost = false;
            }
        }
        public bool SetDataRow(DataRow focus,DataRow row)
        {
            dr = focus;
            _row = row;

            acGridView1.ClearColumns();
            acGridView1.ClearRow();

            acGridView1.GridType = acGridView.emGridType.SEARCH;

            acGridView1.OptionsView.ShowIndicator = true;
            acGridView1.AddLookUpEdit("INS_CODE", "검사항목", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M011");
            acGridView1.AddLookUpEdit("MEAS_CODE", "측정기", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M012");
            acGridView1.AddTextEdit("AVG_VAL", "기준치", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("MIN_VAL", "최소값", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("MAX_VAL", "최대값", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("SCOMMENT", "비고", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.Columns["INS_CODE"].Fixed = FixedStyle.Left;
            acGridView1.Columns["MEAS_CODE"].Fixed = FixedStyle.Left;
            acGridView1.Columns["AVG_VAL"].Fixed = FixedStyle.Left;
            acGridView1.Columns["MIN_VAL"].Fixed = FixedStyle.Left;
            acGridView1.Columns["MAX_VAL"].Fixed = FixedStyle.Left;
            acGridView1.Columns["SCOMMENT"].Fixed = FixedStyle.Left;

            acLabelControl1.Text = focus["PART_CODE"] + Environment.NewLine + focus["PART_NAME"];

            search();

            return true;
        }

        private void AcGridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            try
            {

                switch (e.Column.FieldName)
                {
                    case "INS_CODE":
                    case "MEAS_CODE":
                    case "AVG_VAL":
                    case "MIN_VAL":
                    case "MAX_VAL":
                    case "SCOMMENT":
                        return;
                }

                if (e.CellValue.isNullOrEmpty())
                    return;

                DataRow selRow = acGridView1.GetDataRow(e.RowHandle);

                decimal val = e.CellValue.toDecimal();
                decimal avgVal = selRow["AVG_VAL"].toDecimal();
                decimal minVal = selRow["MIN_VAL"].toDecimal();
                decimal maxVal = selRow["MAX_VAL"].toDecimal();

                if(Math.Abs(avgVal - val) <= 1)
                {
                    if (val < minVal+avgVal
                        || val > maxVal + avgVal)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.Black;
                    }
                }
                else
                {
                    if (val < minVal
                       || val > maxVal)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.Black;
                    }
                }

                
            }
            catch
            {

            }
        }

        private void AcRadioGroup1_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                DataSet paramSet = new DataSet();
                DataTable paramTable = paramSet.Tables.Add("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String));
                paramTable.Columns.Add("EMP_CODE", typeof(String));
                paramTable.Columns.Add("INS_DIRECTION", typeof(Byte));

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["EMP_CODE"] = acInfo.UserID;
                paramRow["INS_DIRECTION"] = acRadioGroup1.Value;
                paramTable.Rows.Add(paramRow);

                BizRun.QBizRun.ExecuteService(this, "POP20A_INS8", paramSet, "RQSTDT", "RSLTDT");
            }
            catch
            {

            }
        }

        private void AcGridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                int colIndex = e.Column.AbsoluteIndex;
                int rowIndex = e.RowHandle;

                //0 가로, 1 세로
                byte isDirection = (byte)acRadioGroup1.Value;

                if (isDirection == 0)
                {
                    if (rowIndex + 1 < acGridView1.RowCount)
                    {
                        acGridView1.FocusedRowHandle = rowIndex + 1;
                    }
                    else
                    {
                        if (colIndex + 1 < acGridView1.Columns.Count)
                        {
                            acGridView1.FocusedRowHandle = 0;
                            acGridView1.FocusedColumn = acGridView1.Columns[colIndex + 1];
                        }
                    }
                }
                else
                {
                    if (colIndex + 1 < acGridView1.Columns.Count)
                    {
                        acGridView1.FocusedColumn = acGridView1.Columns[colIndex + 1];
                    }
                    else
                    {
                        if (rowIndex + 1 < acGridView1.RowCount)
                        {
                            acGridView1.FocusedRowHandle = rowIndex + 1;
                            acGridView1.FocusedColumn = acGridView1.Columns[6];
                        }
                    }
                }

                acGridView1.ShowEditor();

                if(IsKeyPadUse)     
                {
                    KeyPadSetValue(acGridView1.FocusedColumn);
                }
            }
            catch
            { }
        }

        private void AcGridView1_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                int colIndex = acGridView1.FocusedColumn.AbsoluteIndex;
                int rowIndex = acGridView1.FocusedRowHandle;
                
                if (rowIndex+1 < acGridView1.RowCount)
                {
                    acGridView1.FocusedRowHandle = rowIndex + 1;
                }
                else
                {
                    if (colIndex + 1 < acGridView1.Columns.Count)
                    {
                        acGridView1.FocusedRowHandle = 0;
                        acGridView1.FocusedColumn = acGridView1.Columns[colIndex + 1];
                    }
                }
                acGridView1.ShowEditor();
            }
        }

        void acGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            if(IsKeyPadUse  == false)
            {
                return;
            }

            if (e.Button == System.Windows.Forms.MouseButtons.Left && e.Clicks == 1)
            {
                GridHitInfo hitInfo = acGridView1.CalcHitInfo(e.Location);

                if (hitInfo.HitTest == GridHitTest.RowCell)
                {
                    if (hitInfo.Column.Caption.StartsWith("X"))
                    {
                        KeyPad kp = new KeyPad();

                        kp.DialogMode = BaseMenuDialog.emDialogMode.NEW;

                        kp.ParentControl = this;

                        base.ChildFormAdd("NEW_KEY", kp);


                        if (kp.ShowDialog() == DialogResult.OK)
                        {
                            acGridView1.SetRowCellValue(hitInfo.RowHandle, hitInfo.Column, kp.OutputData);
                            acGridView1.EndEditor();
                        }
                    }
                }
                
            }
        }

        void KeyPadSetValue(GridColumn col)
        {
            acGridView1.Focus();
            acGridView1.ResetCursor();
            if (col.Caption.StartsWith("X"))
            {
                KeyPad kp = new KeyPad();

                kp.DialogMode = BaseMenuDialog.emDialogMode.NEW;

                kp.ParentControl = this;

                base.ChildFormAdd("NEW_KEY", kp);


                if (kp.ShowDialog() == DialogResult.OK)
                {
                    //DataRow dr = acGridView1.GetDataRow(hitInfo.RowHandle);

                    //dr[hitInfo.Column.FieldName] = kp.OutputData;
                    acGridView1.SetFocusedValue(kp.OutputData);
                    acGridView1.EndEditor();
                }
            }
        }
        void search()
        {
            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("WO_NO", typeof(String)); //
            paramTable.Columns.Add("PART_CODE", typeof(String)); //
            paramTable.Columns.Add("EMP_CODE", typeof(String)); //

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["WO_NO"] = dr["WO_NO"];
            paramRow["PART_CODE"] = dr["PART_CODE"];
            paramRow["EMP_CODE"] = acInfo.UserID;

            paramTable.Rows.Add(paramRow);

            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.NONE, "POP20A_SER10", paramSet, "RQSTDT", "RSLTDT",
                   QuickSearch,
                   QuickException);
        }

        void QuickSearch(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {   
                //신규 검사 컬럼 추가
                for (int i = 1; i < dr["PART_QTY"].toInt() + 1; i++)
                {
                    acGridView1.AddTextEdit(i.ToString(), "X" + i.ToString(), "", false, DevExpress.Utils.HorzAlignment.Center, true, true, false, acGridView.emTextEditMask.F3);
                }

                acGridView1.GridControl.DataSource = e.result.Tables["RSLTDT"];

                foreach(DataRow row in e.result.Tables["RSLTDT_EMP"].Rows)
                {
                    acRadioGroup1.Value = row["INS_DIRECTION"];
                }


                SetFocus();
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
                this.DialogResult = DialogResult.OK;
        }
        
        private void btnSave_Click(object sender, EventArgs e)
        {
            //저장

            acGridView1.EndEditor();

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //사업장 코드
            paramTable.Columns.Add("WO_NO", typeof(String)); //
            paramTable.Columns.Add("PART_CODE", typeof(String)); //
            paramTable.Columns.Add("INS_CODE", typeof(String)); //
            paramTable.Columns.Add("CHK_NO", typeof(int)); //
            paramTable.Columns.Add("CHK_VALUE", typeof(Decimal)); //
            
            DataView view = acGridView1.GetDataSourceView("");

            int totCnt = dr["PART_QTY"].toInt();

            foreach (DataRowView rv in view)
            {
                DataRow row = rv.Row;
                for (int i = 1; i < totCnt + 1; i++)
                {
                    DataRow paramRow = paramTable.NewRow();
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["WO_NO"] = dr["WO_NO"];
                    paramRow["PART_CODE"] = dr["PART_CODE"];
                    paramRow["INS_CODE"] = row["INS_CODE"];
                    paramRow["CHK_NO"] = i.ToString();
                    paramRow["CHK_VALUE"] = row[i.ToString()];
                    paramTable.Rows.Add(paramRow);
                }
            }

            if (paramTable.Rows.Count != 0)
            {
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.SAVE, "POP20A_INS4", paramSet, "RQSTDT", "RSLTDT",
                   QuickSave,
                   QuickException);
            }
        }

        void QuickSave(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //취소
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void checkKeyPadUse_CheckedChanged(object sender, EventArgs e)
        {
            CheckButton cbtn = sender as CheckButton;

            if (cbtn == null) return;

            if (cbtn.Checked)
            {
                //키패드 사용
                IsKeyPadUse = true;
                //SetReadOnly(true);
            }
            else
            {
                //키패드 미사용
                IsKeyPadUse = false;
                //SetReadOnly(false);
            }
        }

        private void SetReadOnly(bool isReadOnly)
        {
            foreach (acGridColumn col in acGridView1.Columns)
            {
                bool isContinue = false;

                switch (col.FieldName)
                {
                    case "INS_CODE":
                    case "MEAS_CODE":
                    case "AVG_VAL":
                    case "MIN_VAL":
                    case "MAX_VAL":
                    case "SCOMMENT":
                    {
                        isContinue = true;
                    }
                    break;
                }

                if (isContinue) continue;

                col.OptionsColumn.AllowEdit = !isReadOnly;
            }
        }

        private void SetFocus()
        {
            acGridView1.Focus();
            foreach (acGridColumn col in acGridView1.Columns)
            {
                bool isContinue = false;

                switch (col.FieldName)
                {
                    case "INS_CODE":
                    case "MEAS_CODE":
                    case "AVG_VAL":
                    case "MIN_VAL":
                    case "MAX_VAL":
                    case "SCOMMENT":
                    {
                        isContinue = true;
                    }
                    break;
                }

                if (isContinue) continue;

                for (int i = 0; i < acGridView1.RowCount; i++)
                {
                    if(acGridView1.GetRowCellValue(i,col).isNullOrEmpty())
                    {
                        //acGridView1.SetFocusCell(i, col.FieldName);
                        acGridView1.FocusedColumn = col;
                        acGridView1.FocusedRowHandle = i;
                        acGridView1.ShowEditor();
                       
                        return;
                    }
                }
            }
        }
    }
}

