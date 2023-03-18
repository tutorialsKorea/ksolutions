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

namespace PLN
{
    public partial class RegCheck : BaseMenuDialog
    {
        private bool _IsReadOnly = false;

        private DataRow dr = null;
        private DataRow _row = null;

        bool bSave = false;

        public RegCheck(DataRow focus, DataRow row, bool isReadOnly)
        {
            InitializeComponent();

            dr = focus;
            _row = row;
            _IsReadOnly = isReadOnly;

            acLayoutControlItem2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;

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

            acGridView1.CustomDrawCell += AcGridView1_CustomDrawCell;
            search();

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

                if (Math.Abs(avgVal - val) <= 1)
                {
                    if (val < minVal + avgVal
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
                    acGridView1.AddTextEdit(i.ToString(), "X" + i.ToString(), "", false, DevExpress.Utils.HorzAlignment.Center, !_IsReadOnly, true, false, acGridView.emTextEditMask.F3);
                    
                }

                acGridView1.GridControl.DataSource = e.result.Tables["RSLTDT"];

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

