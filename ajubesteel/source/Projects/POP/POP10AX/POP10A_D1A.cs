using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

using ControlManager;
using CodeHelperManager;
using GemBox.Spreadsheet;
using BizManager;

namespace POP
{
    public partial class POP10A_D1A : ControlManager.BaseMenuDialog
    {
        public override acBarManager BarManager
        {

            get
            {
                return acBarManager1;
            }

        }


        public override void BarCodeScanInput(string barcode)
        {


        }

        private DataRow _MasterRow = null;
        private acGridView _LinkView = null;


        public POP10A_D1A(DataRow mastetRow, acGridView linkView)
        {
            InitializeComponent();

            this._MasterRow = mastetRow;
            this._LinkView = linkView;


            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:SHEET", "시트", "LBG894M9", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);

            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:STARTROW", "시작행", "R309968V", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NUMERIC);

            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:TL_CODE", "공구코드", "836KV66Y", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:TL_NUM", "공구품번", "2XEVDYLQ", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:TL_TIME", "가공시간", "6S5HF69R", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:SCOMMENT", "비고", "ARYZ726K", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);



            acGridView2.GridType = acGridView.emGridType.SEARCH;


            acGridView2.AddCheckEdit("SEL", "선택", "40290", true, true, true, acGridView.emCheckEditDataType._STRING);


            //acGridView2.AddCheckEdit("OVERWRITE", "덮어쓰기", "QJJIK4V9", true, true, true, acGridView.emCheckEditDataType._STRING);

            acGridView2.AddHidden("TL_CODE", typeof(string));

            acGridView2.AddCustomEdit("TL_NAME", "공구", "MYHQ4E2U", true, DevExpress.Utils.HorzAlignment.Near, true, true, false, new RepositoryItemTool());

            acGridView2.Columns["TL_NAME"].ColumnEdit.EditValueChanged += new EventHandler(toolEditor_EditValueChanged);


            acGridView2.AddTextEdit("TL_NUM", "공구품번", "2XEVDYLQ", true, DevExpress.Utils.HorzAlignment.Center, true, true, true, acGridView.emTextEditMask.NONE);

            acGridView2.AddTextEdit("TL_SPEC", "공구사양", "43Q908E3", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView2.AddTextEdit("TL_TIME", "가공시간", "6S5HF69R", true, DevExpress.Utils.HorzAlignment.Far, true, true, true, acGridView.emTextEditMask.NUMERIC);

            acGridView2.AddTextEdit("SCOMMENT", "비고", "ARYZ726K", true, DevExpress.Utils.HorzAlignment.Near, true, true, false, acGridView.emTextEditMask.NONE);
        }
        void toolEditor_EditValueChanged(object sender, EventArgs e)
        {
            //공구 변경


            acGridView2.EndEditor();

            acTool tool = sender as acTool;

            if (tool.IsSelected == true)
            {
                DataRow toolRow = tool.SelectedRow;

                DataRow focusRow = acGridView2.GetFocusedDataRow();

                focusRow["TL_CODE"] = toolRow["TL_CODE"];

                focusRow["TL_SPEC"] = toolRow["TL_SPEC"];

            }

        }


        public override void DialogInit()
        {

            acVerticalGrid1.DataBind(this.GetMenuConfigRowTableByServer().Rows[0]);

            acVerticalGrid1.BestFit();


            if (FileNames != null)
            {
                this.OpenFiles(FileNames);
            }



            base.DialogInit();
        }

        private BizManager.QThread _ExcelFileLoadThread = null;


        public string[] FileNames = null;


        private void acBarButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //엑셀파일 열기

            try
            {
                acVerticalGrid1.EndEditor();


                OpenFileDialog openFileDialog1 = new OpenFileDialog();

                openFileDialog1.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                openFileDialog1.Filter = "Excel Files|*.xls;*.xlsx; | All Files|*.*";
                openFileDialog1.FilterIndex = 1;
                openFileDialog1.RestoreDirectory = true;

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {

                    this.OpenFiles(openFileDialog1.FileNames);

                }

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        private void OpenFiles(string[] fileNames)
        {
            this._ExcelFileLoadThread = new BizManager.QThread(this, BizManager.QThread.emExecuteType.LOAD);

            this._ExcelFileLoadThread.Execute(ExcelFileLoadThreadStarter, new object[] { fileNames });

        }

        void ExcelFileLoadThreadStarter(object args)
        {
            try
            {
                //엑셀파일 Import 쓰레드


                DataTable ecData = acGridView2.NewTable();

                object[] parameter = (object[])args;


                //엑셀파일명

                string[] excelFileNames = (string[])parameter[0];

                foreach (string excelFileName in excelFileNames)
                {



                    ExcelFile ef = new ExcelFile();

                    FileInfo excelFileInfo = new FileInfo(excelFileName);


                    if (excelFileInfo.Extension.ToLower() == ".xls")
                    {
                        ef.LoadXls(excelFileName);
                    }
                    else if (excelFileInfo.Extension.ToLower() == ".xlsx")
                    {
                        ef.LoadXlsx(excelFileName, XlsxOptions.None);
                    }

                    else
                    {
                        return;
                    }

                    ExcelWorksheet sheet = null;

                    if (acVerticalGrid1.GetCellValue("EXCEL_IMPORT:SHEET").isNullOrEmpty() == false)
                    {

                        sheet = ef.Worksheets[acVerticalGrid1.GetCellValue("EXCEL_IMPORT:SHEET").ToString()];
                    }
                    else
                    {
                        sheet = ef.Worksheets[0];
                    }


                    //시작행 
                    int nRow = acVerticalGrid1.GetCellValue("EXCEL_IMPORT:STARTROW").toInt() - 1;




                    int cnt = 0;

                    if (acVerticalGrid1.GetCellValue("EXCEL_IMPORT:TL_CODE").isNullOrEmpty() == false)
                    {

                        while (sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT:TL_CODE").ToString()].Cells[nRow].Value.isNullOrEmpty() == false)
                        {


                            this._ExcelFileLoadThread.SetCount(cnt);


                            DataRow ecRow = ecData.NewRow();

                            ecRow["SEL"] = "0";
                            //ecRow["OVERWRITE"] = "0";

                            if (acVerticalGrid1.GetCellValue("EXCEL_IMPORT:TL_CODE").isNullOrEmpty() == false)
                            {
                                DataRow toolRow = acTool.GetDataRow(sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT:TL_CODE").ToString()].Cells[nRow].Value);

                                if (toolRow != null)
                                {
                                    ecRow["TL_CODE"] = sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT:TL_CODE").ToString()].Cells[nRow].Value;

                                    ecRow["TL_SPEC"] = toolRow["TL_SPEC"];

                                    ecRow["TL_NAME"] = toolRow.GetStringByMaskScript(acInfo.SysConfig.GetSysConfigByMemory("CTRL_TOOL_SHOW_COLUMN"));
                                }

                            }




                            if (acVerticalGrid1.GetCellValue("EXCEL_IMPORT:TL_NUM").isNullOrEmpty() == false)
                            {
                                ecRow["TL_NUM"] = sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT:TL_NUM").ToString()].Cells[nRow].Value;
                            }



                            if (acVerticalGrid1.GetCellValue("EXCEL_IMPORT:TL_TIME").isNullOrEmpty() == false)
                            {
                                ecRow["TL_TIME"] = sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT:TL_TIME").ToString()].Cells[nRow].Value.toDecimal();
                            }



                            if (acVerticalGrid1.GetCellValue("EXCEL_IMPORT:SCOMMENT").isNullOrEmpty() == false)
                            {
                                ecRow["SCOMMENT"] = sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT:SCOMMENT").ToString()].Cells[nRow].Value;
                            }

                            ecData.Rows.Add(ecRow);

                            ++nRow;

                            ++cnt;

                        }

                    }
                }

                this.BeginInvoke((MethodInvoker)delegate
                {

                    if (this._ExcelFileLoadThread.IsThreadAbort == false)
                    {
                        DataTable now = acGridView2.GridControl.DataSource as DataTable;

                        now.Load(new DataTableReader(ecData));

                        acGridView2.ResetGridRowSeq();
                    }

                });


            }
            catch (Exception ex)
            {
                this.BeginInvoke((MethodInvoker)delegate
                {

                    acMessageBox.Show(this, ex);

                });
            }



        }



        void QuickException(object sender, QBiz QBiz, BizManager.BizException ex)
        {

            if (ex.ErrNumber == 200065)
            {

                acMessageBoxGridConfirm frm = new acMessageBoxGridConfirm(this, "acMessageBoxGridConfirm1", acInfo.BizError.GetDesc(ex.ErrNumber), string.Empty, false, this.Caption, ex.ParameterData);


                frm.View.GridType = ControlManager.acGridView.emGridType.FIXED;

                frm.View.AddTextEdit("TL_CODE", "공구코드", "836KV66Y", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

                frm.ShowDialog();


            }
            else
            {

                acMessageBox.Show(this, ex);

            }

        }



        private void acBarButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //엑셀 복사
            try
            {

                acGridView2.EndEditor();


                if (acGridView2.ValidCheck("SEL='1'") == false)
                {
                    return;
                }


                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("TL_ID", typeof(String)); //
                paramTable.Columns.Add("WO_NO", typeof(String)); //
                paramTable.Columns.Add("TL_CODE", typeof(String)); //
                paramTable.Columns.Add("TL_NUM", typeof(String)); //
                paramTable.Columns.Add("TL_TIME", typeof(Decimal)); //
                paramTable.Columns.Add("SCOMMENT", typeof(String)); //
                paramTable.Columns.Add("REG_EMP", typeof(String)); //


                DataView view = acGridView2.GetDataSourceView("SEL = '1'");

                foreach (DataRowView rv in view)
                {
                    DataRow row = rv.Row;

                    DataRow paramRow = paramTable.NewRow();
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["TL_ID"] = null;
                    paramRow["WO_NO"] = this._MasterRow["WO_NO"];
                    paramRow["TL_CODE"] = row["TL_CODE"];
                    paramRow["TL_NUM"] = row["TL_NUM"];
                    paramRow["TL_TIME"] = row["TL_TIME"];
                    paramRow["SCOMMENT"] = row["SCOMMENT"];
                    paramRow["REG_EMP"] = acInfo.UserID;
                    paramTable.Rows.Add(paramRow);

                }


                if (paramTable.Rows.Count != 0)
                {
                    DataSet paramSet = new DataSet();
                    paramSet.Tables.Add(paramTable);

                    
                    //BizRun.QBizRun.ExecuteService(
                    BizRun.QBizRun.ExecuteService(
                        this, QBiz.emExecuteType.PROCESS, "POP10A_INS", paramSet, "RQSTDT", "RSLTDT",
                        QuickSave,
                        QuickException);


                }

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
                foreach (DataRow row in e.result.Tables["RSLTDT"].Rows)
                {
                    this._LinkView.UpdateMapingRow(row, true);
                }

                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }


    }
}
