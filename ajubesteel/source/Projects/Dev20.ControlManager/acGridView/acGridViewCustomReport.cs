using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Linq;
using System.Drawing.Drawing2D;
using System.IO;
using DevExpress.Spreadsheet;
using System.Text.RegularExpressions;
using BizManager;

namespace ControlManager
{
    public sealed partial class acGridViewCustomReport : BaseMenuDialog
    {
        private acGridView _SourceGridView = null;

        Dictionary<string, string[]> _DicOriginValue = null;

        DataRow _LinkRow = null;

        bool _IsNew = false;
        public acGridViewCustomReport(acGridView source, DataRow linkRow)
        {
            InitializeComponent();

            _SourceGridView = source;
            _LinkRow = linkRow;
            _DicOriginValue = new Dictionary<string, string[]>();
        }

        public override void DialogInit()
        {
            acRadioGroup1.Value = "LIST";

            SetVerticalGrid();

            base.DialogInit();
        }
        public override void DialogOpen()
        {
            base.DialogOpen();
            _IsNew = false;
            //txtPath
            acLayoutControlItem5.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            //btnLoadFile
            acLayoutControlItem6.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
        }

        public override void DialogNew()
        {
            base.DialogNew();

            _IsNew = true;
            //txtPath
            acLayoutControlItem5.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            //btnLoadFile
            acLayoutControlItem6.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
        }

        public override void DialogInitComplete()
        {
            base.DialogInitComplete();

            if (!_IsNew) Search();
        }

        void Search()
        {
            try
            {
                DataSet paramCusSet = new DataSet();
                DataTable paramCusTable = paramCusSet.Tables.Add("RQSTDT");
                paramCusTable.Columns.Add("PLT_CODE", typeof(String));
                paramCusTable.Columns.Add("CUS_ID", typeof(String));

                DataRow paramCusRow = paramCusTable.NewRow();
                paramCusRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramCusRow["CUS_ID"] = _LinkRow["CUS_ID"]; //Open 시에만 Search 하기 때문에 _LinkRow null체크 필요없음
                paramCusTable.Rows.Add(paramCusRow);

                BizRun.QBizRun.ExecuteService(this,QBiz.emExecuteType.LOAD_DETAIL, "CTRL", "GET_USE_CUSTOM_EXCELFILE", paramCusSet, "RQSTDT", "RSLTDT_M,RSLTDT_D"
                                        , QuickSearch,QuickException);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void QuickSearch(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                foreach(DataRow row in e.result.Tables["RSLTDT_M"].Rows)
                {
                    txtTitle.Text = row["FILE_NAME"].toStringEmpty();
                    acRadioGroup1.Value = row["EXPORT_TYPE"];

                    DataTable detailTable = e.result.Tables["RSLTDT_D"].Select("CUS_ID='" + row["CUS_ID"] + "'").CopyToDataTable();

                    foreach(DataRow detailRow in detailTable.Rows)
                    {
                        VerticalColumns.SetCellValue(detailRow["CONNET_COLUMN_NAME"].toStringEmpty(), detailRow["START_CELL_NAME"]);
                    }
                    
                    #region 양식 파일 SpreadSheet에 로드
                    spreadExcel.Options.TabSelector.Visibility = DevExpress.XtraSpreadsheet.SpreadsheetElementVisibility.Hidden;

                    spreadExcel.LoadDocument(row["FILE_DATA"] as byte[]);

                    if (spreadExcel.Document.Worksheets.Count > 0)
                    {
                        spreadExcel.Document.Worksheets.ActiveWorksheet = spreadExcel.Document.Worksheets[0];
                    }
                    #endregion
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }
        private void AcVerticalGrid1_CustomDrawRowValueCell(object sender, DevExpress.XtraVerticalGrid.Events.CustomDrawRowValueCellEventArgs e)
        {
            try
            {
                if (!e.CellValue.isNullOrEmpty() &&!IsRegex(@"[a-zA-Z][\d]", e.CellValue))
                {
                    e.Appearance.BackColor = Color.OrangeRed;
                    return;
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void AcVerticalGrid1_CellValueChanged(object sender, DevExpress.XtraVerticalGrid.Events.CellValueChangedEventArgs e)
        {
            try
            {
                string fName = e.Row.Properties.FieldName;
                //엑셀 위치
                string cValue = e.Value.toStringEmpty();


                if (!cValue.isNullOrEmpty() && !IsRegex(@"[a-zA-Z][\d]", cValue))
                {
                    if (_DicOriginValue.ContainsKey(fName))
                    {
                        spreadExcel.ActiveWorksheet[_DicOriginValue[fName][0]].Value = _DicOriginValue[fName][1];
                        _DicOriginValue.Remove(fName);
                    }
                    acMessageBox.Show(this, "입력 값이 잘못되었습니다. 다시 입력해주세요.", "", false, acMessageBox.emMessageBoxType.CONFIRM);
                    return;
                }

                if (!cValue.isNullOrEmpty())
                {
                    //key : 컬럼이름, value : 엑셀 위치, 엑셀 값
                    if (_DicOriginValue.ContainsKey(fName))
                    {
                        spreadExcel.ActiveWorksheet[_DicOriginValue[fName][0]].Value = _DicOriginValue[fName][1];
                        _DicOriginValue[fName] = new string[] { cValue, spreadExcel.ActiveWorksheet[cValue].Value.toStringEmpty() };
                    }
                    else
                    {
                        _DicOriginValue.Add(fName, new string[] { cValue, spreadExcel.ActiveWorksheet[cValue].Value.toStringEmpty() });
                    }
                    spreadExcel.ActiveWorksheet[cValue].Value = "<" + e.Row.Properties.Caption + ">";
                }
                else
                {
                    if (_DicOriginValue.ContainsKey(fName))
                    {
                        spreadExcel.ActiveWorksheet[_DicOriginValue[fName][0]].Value = _DicOriginValue[fName][1];
                        _DicOriginValue.Remove(fName);
                    }
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void btnSaveClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {

                if(acLayoutControl1.ValidCheck() == false)  return;

                //신규이고 양식의 경로에 파일이 아니면
                if (_IsNew && !File.Exists(txtPath.Text))
                {
                    acMessageBox.Show(this, "파일이 존재하지 않습니다.", "", false, acMessageBox.emMessageBoxType.CONFIRM);
                    return;
                }

                DataSet paramSet = new DataSet();

                DataTable paramTableM = paramSet.Tables.Add("RQSTDT_M");
                paramTableM.Columns.Add("PLT_CODE", typeof(String));
                paramTableM.Columns.Add("CUS_ID", typeof(String));
                paramTableM.Columns.Add("CLASS_NAME", typeof(String));
                paramTableM.Columns.Add("CONTROL_NAME", typeof(String));
                paramTableM.Columns.Add("EXPORT_TYPE", typeof(String));
                paramTableM.Columns.Add("EMP_CODE", typeof(String));
                paramTableM.Columns.Add("FILE_NAME", typeof(String));
                paramTableM.Columns.Add("FILE_DATA", typeof(Byte[]));
                paramTableM.Columns.Add("REG_DATE", typeof(String));

                DataTable paramTableD = paramSet.Tables.Add("RQSTDT_D");
                paramTableD.Columns.Add("PLT_CODE", typeof(String));
                paramTableD.Columns.Add("CUS_ID", typeof(String));
                paramTableD.Columns.Add("START_CELL_NAME", typeof(String));
                paramTableD.Columns.Add("CONNET_COLUMN_NAME", typeof(String));

                DataRow paramRowM = paramTableM.NewRow();
                paramRowM["PLT_CODE"] = acInfo.PLT_CODE;
                if(_LinkRow != null)
                {
                    paramRowM["CUS_ID"] = _LinkRow["CUS_ID"];
                }
                paramRowM["CLASS_NAME"] = _SourceGridView.ParentControl.Name;
                paramRowM["CONTROL_NAME"] = _SourceGridView.Name;
                paramRowM["EXPORT_TYPE"] = acRadioGroup1.Value;
                paramRowM["EMP_CODE"] = acInfo.UserID;
                paramRowM["FILE_NAME"] = txtTitle.Text;
                if (_IsNew && File.Exists(txtPath.Text))
                {
                    paramRowM["FILE_DATA"] = File.ReadAllBytes(txtPath.Text);
                }
                else{
                    MemoryStream ms = new MemoryStream();
                    spreadExcel.SaveDocument(ms, DocumentFormat.Xlsx);

                    paramRowM["FILE_DATA"] = ms.ToArray();
                    ms.Flush();
                    ms.Close();
                    
                }
                paramRowM["REG_DATE"] = DateTime.Now;
                paramTableM.Rows.Add(paramRowM);

                for (int i = 0; i < VerticalColumns.Rows.Count; i++)
                {
                    if (!VerticalColumns.Rows[i].Properties.Value.isNullOrEmpty() && !IsRegex(@"[a-zA-Z][\d]", VerticalColumns.Rows[i].Properties.Value))
                    {
                        acMessageBox.Show(this, "형식에 맞지 않는 값이 존재합니다.", string.Empty, false, acMessageBox.emMessageBoxType.CONFIRM);
                        return;
                    }

                    DataRow paramRowD = paramTableD.NewRow();
                    paramRowD["PLT_CODE"] = acInfo.PLT_CODE;
                    if (_LinkRow != null)
                    {
                        paramRowD["CUS_ID"] = _LinkRow["CUS_ID"];
                    }
                    paramRowD["START_CELL_NAME"] = VerticalColumns.Rows[i].Properties.Value;
                    paramRowD["CONNET_COLUMN_NAME"] = VerticalColumns.Rows[i].Properties.FieldName;
                    paramTableD.Rows.Add(paramRowD);
                }
                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.SAVE, "CTRL", "CONTROL_GRID_EXCEL_INPUT", paramSet, "RQSTDT_M,RQSTDT_D", "RSLTDT",
                     QuickSave,
                     QuickException);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }
        void QuickSave(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                acMessageBox.Show(this, "저장 완료", "", false, acMessageBox.emMessageBoxType.CONFIRM);
                this.OutputData = e.result.Tables["RQSTDT_M"];
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }
        void QuickException(object sender, QBiz qBiz, BizManager.BizException ex)
        {
            acMessageBox.Show(this, ex);
        }
        void SetVerticalGrid()
        {
            try
            {
                //foreach (acGridColumn col in _SourceGridView.Columns.OrderBy(o => o.Caption))
                foreach (acGridColumn col in _SourceGridView.Columns)
                {
                    VerticalColumns.AddTextEdit(col.FieldName, col.Caption, string.Empty, false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Center, true, true, acVerticalGrid.emTextEditMask.NONE);
                }

                VerticalColumns.CellValueChanged += AcVerticalGrid1_CellValueChanged;
                VerticalColumns.CustomDrawRowValueCell += AcVerticalGrid1_CustomDrawRowValueCell;
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        bool IsRegex(string regexString, object value)
        {
            try
            {
                Regex reg = new Regex(regexString);
                return reg.IsMatch(value.toStringEmpty());
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        void OpenExcelFile()
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "Excel(*.xls, *.xlsx)|*.xls;*.xlsx";
                if(ofd.ShowDialog() == DialogResult.OK)
                {
                    string filePath = ofd.FileName;
                    txtPath.Text = filePath;

                    spreadExcel.Options.TabSelector.Visibility = DevExpress.XtraSpreadsheet.SpreadsheetElementVisibility.Hidden;

                    spreadExcel.LoadDocument(filePath);

                    if (spreadExcel.Document.Worksheets.Count > 0)
                    {
                        spreadExcel.Document.Worksheets.ActiveWorksheet = spreadExcel.Document.Worksheets[0];
                    }
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void btnLoadFile_Click(object sender, EventArgs e)
        {
            OpenExcelFile();
        }
    }
}