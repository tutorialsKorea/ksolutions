using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ControlManager;
using DevExpress.XtraEditors.Repository;
//using GemBox.Spreadsheet;
using System.Threading;
using System.IO;
using CodeHelperManager;
using BizManager;
using DevExpress.Spreadsheet;
using DevExpress.XtraSpreadsheet;

namespace QCT
{
    public sealed partial class QCT02A_D0A : BaseMenuDialog
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

        private acGridView _linkView = null;

        private string _prod_code = string.Empty;

        public QCT02A_D0A(acGridView linkView,string prod_code)
        {
            InitializeComponent();

            this._linkView = linkView;

            this._prod_code = prod_code;

            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:SHEET", "시트", "LBG894M9", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);

            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:STARTROW", "시작행", "R309968V", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NUMERIC);

            //acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:INS_LOC", "구분", "41162", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:INS_NAME", "검사명", "41202", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:INS_VALUE", "내역", "40308", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);



            acGridView2.GridType = acGridView.emGridType.SEARCH_SEL;

            acGridView2.AddCheckEdit("OVERWRITE", "덮어쓰기", "QJJIK4V9", false, true,false, acGridView.emCheckEditDataType._STRING);

            acGridView2.AddTextEdit("INS_LOC", "구분", "41162", false, DevExpress.Utils.HorzAlignment.Center, true, true, true, acGridView.emTextEditMask.NONE);

            acGridView2.AddTextEdit("INS_NAME", "검사명", "41202", false, DevExpress.Utils.HorzAlignment.Center, true, true, true, acGridView.emTextEditMask.NONE);

            acGridView2.AddTextEdit("INS_VALUE", "내역", "40400", false, DevExpress.Utils.HorzAlignment.Far, true, true, false, acGridView.emTextEditMask.NONE);


        }

        public override void DialogInit()
        {
            acVerticalGrid1.DataBind(this.GetMenuConfigRowTableByServer().Rows[0]);
            
            acVerticalGrid1.BestFit();            

            base.DialogInit();
        }

        private BizManager.QThread _ExcelFileLoadThread = null;

        private void acBarButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //엑셀파일 열기

            try
            {

                acVerticalGrid1.EndEditor();

                OpenFileDialog openFileDialog1 = new OpenFileDialog();

                //openFileDialog1.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                openFileDialog1.Filter = "Excel Files|*.csv;*.xls;*.xlsx | All Files|*.*";
                openFileDialog1.FilterIndex = 1;
                openFileDialog1.RestoreDirectory = true;
                openFileDialog1.Multiselect = true;

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {

                    this._ExcelFileLoadThread = new BizManager.QThread(this, BizManager.QThread.emExecuteType.LOAD);

                    this._ExcelFileLoadThread.Execute(ExcelFileLoadThreadStarter, new object[] {  openFileDialog1.FileNames });

                    
                }

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }


        void ExcelFileLoadThreadStarter(object args)
        {
            try
            {
                //엑셀파일 Import 쓰레드

                object[] parameter = (object[])args;
                 
                //엑셀파일명
                string[] excelFileNames = parameter[0] as string[];

                DataTable ecData = acGridView2.NewTable();

                foreach (string excelFileName in excelFileNames)
                {
                    FileInfo excelFileInfo = new FileInfo(excelFileName);

                    Workbook workbook = new Workbook();


                    if (excelFileInfo.Extension.ToLower() == ".xls")
                    {
                        workbook.LoadDocument(excelFileName, DocumentFormat.Xls);
                    }
                    else if (excelFileInfo.Extension.ToLower() == ".xlsx")
                    {
                        workbook.LoadDocument(excelFileName, DocumentFormat.Xlsx);
                    }
                    else if (excelFileInfo.Extension.ToLower() == ".csv")
                    {
                        workbook.LoadDocument(excelFileName, DocumentFormat.Csv);
                    }
                    else
                    {
                        return;
                    }

                    Worksheet sheet = null;

                    if (acVerticalGrid1.GetCellValue("EXCEL_IMPORT:SHEET").isNullOrEmpty() == false)
                    {

                        sheet = workbook.Worksheets[acVerticalGrid1.GetCellValue("EXCEL_IMPORT:SHEET").ToString()];
                    }
                    else
                    {
                        sheet = workbook.Worksheets[0];
                    }


                    //시작행 
                    int nRow = acVerticalGrid1.GetCellValue("EXCEL_IMPORT:STARTROW").toInt() - 1;

                    

                    int cnt = 0;

                    if (acVerticalGrid1.GetCellValue("EXCEL_IMPORT:INS_NAME").isNullOrEmpty() == false)
                    {
                        while (sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT:INS_NAME").ToString()][nRow].Value.isNullOrEmpty() == false)
                        {
                            if (!sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT:INS_NAME").ToString()][nRow].Value.ToString().Contains(":END"))
                            {
                                this._ExcelFileLoadThread.SetCount(cnt);

                                DataRow ecRow = ecData.NewRow();

                                ecRow["OVERWRITE"] = "0";


                                //if (acVerticalGrid1.GetCellValue("EXCEL_IMPORT:INS_LOC").isNullOrEmpty() == false)
                                //{
                                ecRow["INS_LOC"] = excelFileInfo.Name.Replace(excelFileInfo.Extension, string.Empty);// sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT:INS_LOC").ToString()][nRow].Value;
                                                                                                                     //}


                                if (acVerticalGrid1.GetCellValue("EXCEL_IMPORT:INS_NAME").isNullOrEmpty() == false)
                                {
                                    ecRow["INS_NAME"] = sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT:INS_NAME").ToString()][nRow].Value;
                                }


                                if (acVerticalGrid1.GetCellValue("EXCEL_IMPORT:INS_VALUE").isNullOrEmpty() == false)
                                {
                                    ecRow["INS_VALUE"] = sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT:INS_VALUE").ToString()][nRow].Value.toStringEmpty();
                                }



                                ecData.Rows.Add(ecRow);
                                ++cnt;
                            }
                            ++nRow;
                            
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


        void QuickException(object sender, QBiz qBiz, BizManager.BizException ex)
        {
        
            acMessageBox.Show(this, ex);

        }



        private void acBarButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //엑셀 복사
            try
            {

                acGridView2.EndEditor();
                

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //사업장 코드
                paramTable.Columns.Add("PROD_CODE", typeof(String)); //
                paramTable.Columns.Add("INS_NO", typeof(String)); //
                paramTable.Columns.Add("INS_LOC", typeof(String)); //
                paramTable.Columns.Add("INS_NAME", typeof(String)); //
                paramTable.Columns.Add("INS_VALUE", typeof(String)); //
                paramTable.Columns.Add("REG_EMP", typeof(String)); //
                paramTable.Columns.Add("OVERWRITE", typeof(String)); //

                DataRow[] rows = acGridView2.GetSelectedDataRows();

                if (rows.Length == 0)
                    return;

                foreach (DataRow row in rows)
                {

                    DataRow paramRow = paramTable.NewRow();
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["PROD_CODE"] = this._prod_code;
                    paramRow["INS_LOC"] = row["INS_LOC"];
                    paramRow["INS_NAME"] = row["INS_NAME"];
                    paramRow["INS_VALUE"] = row["INS_VALUE"];
                    paramRow["REG_EMP"] = acInfo.UserID;
                    paramRow["OVERWRITE"] = "1";
                    paramTable.Rows.Add(paramRow);

                }


                if (paramTable.Rows.Count != 0)
                {
                    DataSet paramSet = new DataSet();
                    paramSet.Tables.Add(paramTable);

                    BizRun.QBizRun.ExecuteService(
                    this, QBiz.emExecuteType.PROCESS, "QCT02A_INS", paramSet, "RQSTDT", "RSLTDT",
                    QuickSave,
                    QuickException);
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }



        }


        void QuickSave(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {

                foreach(DataRow row in e.result.Tables["RQSTDT"].Rows)
                {
                    acGridView2.UpdateMapingRow(row, true);
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