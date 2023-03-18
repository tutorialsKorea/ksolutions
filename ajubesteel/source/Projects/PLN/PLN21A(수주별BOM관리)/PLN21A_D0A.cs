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


namespace PLN
{
    public sealed partial class PLN21A_D0A : BaseMenuDialog
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

        private acTreeList _linkTree = null;

        private string _prod_code = string.Empty;

        public PLN21A_D0A(acTreeList linkTree,string prod_code)
        {
            InitializeComponent();

            this._linkTree = linkTree;

            this._prod_code = prod_code;

            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:SHEET", "시트", "LBG894M9", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);

            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:STARTROW", "시작행", "R309968V", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NUMERIC);

            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:PART_CODE", "품목코드", "41202", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:PART_NAME", "품목명", "41202", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:PART_LTYPE", "대분류", "41202", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:PART_MTYPE", "중분류", "41202", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:PART_STYPE", "소분류", "41202", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:P_PART_CODE", "모품목코드", "40308", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:P_PART_NAME", "모품목명", "40308", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

            //acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:MAT_CODE", "소재코드", "40308", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

            //acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:MAT_NAME", "소재명", "40308", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

            //acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:PART_QTY", "수량", "40308", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:TAB_MACHINE", "탭 가공 유무", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:MakeSideHole", "측면 가공 유무", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

            //acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:도금?", "수량", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:Slit_Division", "슬릿 유무", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:SAFE_STK_QTY", "안전 재고", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:MAT_QLTY", "재질", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:Surface_Treat", "표면처리/도장", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:AFTER_TREAT", "후가공", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:MAKE_DESC", "Remark", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:PART_QTY", "소요량", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);
            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:ORD_QTY", "영업수량", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

            acGridView2.GridType = acGridView.emGridType.SEARCH_SEL;

            acGridView2.AddCheckEdit("OVERWRITE", "덮어쓰기", "QJJIK4V9", false, true,false, acGridView.emCheckEditDataType._STRING);

            acGridView2.AddTextEdit("PART_CODE", "품목코드", "41162", false, DevExpress.Utils.HorzAlignment.Center, true, true, true, acGridView.emTextEditMask.NONE);

            acGridView2.AddTextEdit("PART_NAME", "품목명", "41202", false, DevExpress.Utils.HorzAlignment.Center, true, true, true, acGridView.emTextEditMask.NONE);

            acGridView2.AddLookUpEdit("PART_LTYPE", "대분류", "", false, DevExpress.Utils.HorzAlignment.Center, true, true, false, "M014");

            acGridView2.AddLookUpEdit("PART_MTYPE", "중분류", "", false, DevExpress.Utils.HorzAlignment.Center, true, true, false, "M015");

            acGridView2.AddLookUpEdit("PART_STYPE", "소분류", "", false, DevExpress.Utils.HorzAlignment.Center, true, true, false, "M016");

            acGridView2.AddTextEdit("P_PART_CODE", "모품목코드", "40400", false, DevExpress.Utils.HorzAlignment.Center, true, true, false, acGridView.emTextEditMask.NONE);

            acGridView2.AddTextEdit("P_PART_NAME", "모품목명", "40400", false, DevExpress.Utils.HorzAlignment.Center, true, true, false, acGridView.emTextEditMask.NONE);

            //acGridView2.AddTextEdit("MAT_CODE", "소재코드", "40400", false, DevExpress.Utils.HorzAlignment.Center, true, true, false, acGridView.emTextEditMask.NONE);

            //acGridView2.AddTextEdit("MAT_NAME", "소재명", "40400", false, DevExpress.Utils.HorzAlignment.Center, true, true, false, acGridView.emTextEditMask.NONE);

            acGridView2.AddTextEdit("TAB_MACHINE", "탭 가공 유무", "", false, DevExpress.Utils.HorzAlignment.Center, true, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("MakeSideHole", "측면 가공 유무", "", false, DevExpress.Utils.HorzAlignment.Center, true, true, false, acGridView.emTextEditMask.NONE);
            //acGridView2.AddTextEdit("도금?", "소재명", "", false, DevExpress.Utils.HorzAlignment.Center, true, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("Slit_Division", "슬릿 유무", "", false, DevExpress.Utils.HorzAlignment.Center, true, true, false, acGridView.emTextEditMask.NONE);            
            acGridView2.AddTextEdit("SAFE_STK_QTY", "안전 재고", "", false, DevExpress.Utils.HorzAlignment.Far, true, true, false, acGridView.emTextEditMask.QTY);
            acGridView2.AddTextEdit("MAT_QLTY", "재질", "", false, DevExpress.Utils.HorzAlignment.Center, true, true, false, acGridView.emTextEditMask.NONE);

            acGridView2.AddTextEdit("Surface_Treat", "표면처리/도장", "", false, DevExpress.Utils.HorzAlignment.Center, true, true, false, acGridView.emTextEditMask.NONE);

            acGridView2.AddTextEdit("AFTER_TREAT", "후가공", "", false, DevExpress.Utils.HorzAlignment.Center, true, true, false, acGridView.emTextEditMask.NONE);

            acGridView2.AddTextEdit("MAKE_DESC", "Remark", "", false, DevExpress.Utils.HorzAlignment.Center, true, true, false, acGridView.emTextEditMask.NONE);

            acGridView2.AddTextEdit("PART_QTY", "소요량", "", false, DevExpress.Utils.HorzAlignment.Far, true, true, false, acGridView.emTextEditMask.QTY);
            acGridView2.AddTextEdit("ORD_QTY", "영업수량", "", false, DevExpress.Utils.HorzAlignment.Far, true, true, false, acGridView.emTextEditMask.QTY);


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

                DataTable data = acVerticalGrid1.CreateParameterTable(true);

                foreach (DataColumn col in data.Columns)
                {
                    acInfo.MenuConfig.SetMenuConfigByServer("PLN21A", col.ColumnName, data.Rows[0][col.ColumnName].toStringEmpty());
                }

                OpenFileDialog openFileDialog1 = new OpenFileDialog();

                //openFileDialog1.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                openFileDialog1.Filter = "엑셀 파일 (*.xls)|*.xls|엑셀 파일 (*.xlsx)|*.xlsx| All Files|*.*";
                openFileDialog1.FilterIndex = 2;
                openFileDialog1.RestoreDirectory = true;
                openFileDialog1.Multiselect = false;

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

                    if (acVerticalGrid1.GetCellValue("EXCEL_IMPORT:PART_CODE").isNullOrEmpty() == false)
                    {
                        while (sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT:PART_CODE").ToString()][nRow].Value.isNullOrEmpty() == false)
                        {
                            if (!sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT:PART_CODE").ToString()][nRow].Value.ToString().Contains(":END"))
                            {
                                this._ExcelFileLoadThread.SetCount(cnt);

                                DataRow ecRow = ecData.NewRow();

                                ecRow["OVERWRITE"] = "1";


                                if (acVerticalGrid1.GetCellValue("EXCEL_IMPORT:PART_CODE").isNullOrEmpty() == false)
                                {
                                    ecRow["PART_CODE"] = sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT:PART_CODE").ToString()][nRow].Value.toStringEmpty();
                                }                                                                                                   


                                if (acVerticalGrid1.GetCellValue("EXCEL_IMPORT:PART_NAME").isNullOrEmpty() == false)
                                {
                                    ecRow["PART_NAME"] = sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT:PART_NAME").ToString()][nRow].Value.toStringEmpty(); 
                                }

                                if (acVerticalGrid1.GetCellValue("EXCEL_IMPORT:PART_LTYPE").isNullOrEmpty() == false)
                                {
                                    ecRow["PART_LTYPE"] = acStdCodes.GetCodeByNameServer("M014", sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT:PART_LTYPE").ToString()][nRow].Value.toStringEmpty());
                                }

                                if (acVerticalGrid1.GetCellValue("EXCEL_IMPORT:PART_MTYPE").isNullOrEmpty() == false)
                                {
                                    ecRow["PART_MTYPE"] = acStdCodes.GetCodeByNameServer("M015", sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT:PART_MTYPE").ToString()][nRow].Value.toStringEmpty());
                                }

                                if (acVerticalGrid1.GetCellValue("EXCEL_IMPORT:PART_STYPE").isNullOrEmpty() == false)
                                {
                                    ecRow["PART_STYPE"] = acStdCodes.GetCodeByNameServer("M016", sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT:PART_STYPE").ToString()][nRow].Value.toStringEmpty());
                                }


                                if (acVerticalGrid1.GetCellValue("EXCEL_IMPORT:P_PART_CODE").isNullOrEmpty() == false)
                                {
                                    ecRow["P_PART_CODE"] = sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT:P_PART_CODE").ToString()][nRow].Value.toStringEmpty();
                                }

                                if (acVerticalGrid1.GetCellValue("EXCEL_IMPORT:P_PART_NAME").isNullOrEmpty() == false)
                                {
                                    ecRow["P_PART_NAME"] = sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT:P_PART_NAME").ToString()][nRow].Value.toStringEmpty();
                                }


                                if (acVerticalGrid1.GetCellValue("EXCEL_IMPORT:MAT_CODE").isNullOrEmpty() == false)
                                {
                                    ecRow["MAT_CODE"] = sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT:MAT_CODE").ToString()][nRow].Value.toStringEmpty();
                                }

                                if (acVerticalGrid1.GetCellValue("EXCEL_IMPORT:MAT_NAME").isNullOrEmpty() == false)
                                {
                                    ecRow["MAT_NAME"] = sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT:MAT_NAME").ToString()][nRow].Value.toStringEmpty();
                                }


                                //if (acVerticalGrid1.GetCellValue("EXCEL_IMPORT:PART_QTY").isNullOrEmpty() == false)
                                //{
                                //    if (sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT:PART_QTY").ToString()][nRow].Value.toStringEmpty() != "")
                                //    {
                                //        ecRow["PART_QTY"] = sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT:PART_QTY").ToString()][nRow].Value.toStringEmpty();
                                //    }
                                //}

                                if (acVerticalGrid1.GetCellValue("EXCEL_IMPORT:TAB_MACHINE").isNullOrEmpty() == false)
                                {
                                    ecRow["TAB_MACHINE"] = sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT:TAB_MACHINE").ToString()][nRow].Value.toStringEmpty();
                                }

                                if (acVerticalGrid1.GetCellValue("EXCEL_IMPORT:MakeSideHole").isNullOrEmpty() == false)
                                {
                                    ecRow["MakeSideHole"] = sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT:MakeSideHole").ToString()][nRow].Value.toStringEmpty();
                                }

                                //if (acVerticalGrid1.GetCellValue("EXCEL_IMPORT:도금?").isNullOrEmpty() == false)
                                //{
                                //    ecRow["도금?"] = sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT:도금?").ToString()][nRow].Value.toStringEmpty();
                                //}

                                if (acVerticalGrid1.GetCellValue("EXCEL_IMPORT:Slit_Division").isNullOrEmpty() == false)
                                {
                                    ecRow["Slit_Division"] = sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT:Slit_Division").ToString()][nRow].Value.toStringEmpty();
                                }

                                if (acVerticalGrid1.GetCellValue("EXCEL_IMPORT:Surface_Treat").isNullOrEmpty() == false)
                                {
                                    ecRow["Surface_Treat"] = sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT:Surface_Treat").ToString()][nRow].Value.toStringEmpty();
                                }

                                if (acVerticalGrid1.GetCellValue("EXCEL_IMPORT:AFTER_TREAT").isNullOrEmpty() == false)
                                {
                                    ecRow["AFTER_TREAT"] = sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT:AFTER_TREAT").ToString()][nRow].Value.toStringEmpty();
                                }

                                if (acVerticalGrid1.GetCellValue("EXCEL_IMPORT:MAKE_DESC").isNullOrEmpty() == false)
                                {
                                    ecRow["MAKE_DESC"] = sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT:MAKE_DESC").ToString()][nRow].Value.toStringEmpty();
                                }

                                if (acVerticalGrid1.GetCellValue("EXCEL_IMPORT:SAFE_STK_QTY").isNullOrEmpty() == false)
                                {
                                    if (sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT:SAFE_STK_QTY").ToString()][nRow].Value.toStringEmpty() != "")
                                    {
                                        ecRow["SAFE_STK_QTY"] = sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT:SAFE_STK_QTY").ToString()][nRow].Value.toStringEmpty();
                                    }
                                }

                                if (acVerticalGrid1.GetCellValue("EXCEL_IMPORT:MAT_QLTY").isNullOrEmpty() == false)
                                {
                                    ecRow["MAT_QLTY"] = sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT:MAT_QLTY").ToString()][nRow].Value.toStringEmpty();
                                }

                                if (acVerticalGrid1.GetCellValue("EXCEL_IMPORT:PART_QTY").isNullOrEmpty() == false)
                                {
                                    if (sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT:PART_QTY").ToString()][nRow].Value.toStringEmpty() != "")
                                    {
                                        ecRow["PART_QTY"] = sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT:PART_QTY").ToString()][nRow].Value.toStringEmpty();
                                    }
                                }

                                if (acVerticalGrid1.GetCellValue("EXCEL_IMPORT:ORD_QTY").isNullOrEmpty() == false)
                                {
                                    if (sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT:ORD_QTY").ToString()][nRow].Value.toStringEmpty() != "")
                                    {
                                        ecRow["ORD_QTY"] = sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT:ORD_QTY").ToString()][nRow].Value.toStringEmpty();
                                    }
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

                        acGridView2.SelectAll();
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
                paramTable.Columns.Add("PART_CODE", typeof(String)); //
                paramTable.Columns.Add("PART_NAME", typeof(String)); //
                paramTable.Columns.Add("MAT_LTYPE", typeof(String)); //
                paramTable.Columns.Add("MAT_MTYPE", typeof(String)); //
                paramTable.Columns.Add("MAT_STYPE", typeof(String)); //
                paramTable.Columns.Add("P_PART_CODE", typeof(String)); //
                paramTable.Columns.Add("P_PART_NAME", typeof(String)); //
                //paramTable.Columns.Add("MAT_CODE", typeof(String)); //
                //paramTable.Columns.Add("MAT_NAME", typeof(String)); //
                paramTable.Columns.Add("REG_EMP", typeof(String)); //

                paramTable.Columns.Add("TAB_MACHINE", typeof(String)); //
                paramTable.Columns.Add("MakeSideHole", typeof(String)); //
                //paramTable.Columns.Add("도금", typeof(String)); //
                paramTable.Columns.Add("Slit_Division", typeof(String)); //
                paramTable.Columns.Add("SAFE_STK_QTY", typeof(int)); //
                paramTable.Columns.Add("MAT_QLTY", typeof(String)); //

                paramTable.Columns.Add("Surface_Treat", typeof(String)); //
                paramTable.Columns.Add("AFTER_TREAT", typeof(String)); //
                paramTable.Columns.Add("MAKE_DESC", typeof(String)); //

                paramTable.Columns.Add("PART_QTY", typeof(int)); //
                paramTable.Columns.Add("ORD_QTY", typeof(int)); //

                paramTable.Columns.Add("OVERWRITE", typeof(String)); //

                DataRow[] rows = acGridView2.GetSelectedDataRows();

                if (rows.Length == 0)
                    return;

                foreach (DataRow row in rows)
                {

                    DataRow paramRow = paramTable.NewRow();
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["PROD_CODE"] = this._prod_code;
                    paramRow["PART_CODE"] = row["PART_CODE"].ToString().Trim();
                    paramRow["PART_NAME"] = row["PART_NAME"].ToString().Trim();
                    paramRow["MAT_LTYPE"] = row["PART_LTYPE"];
                    paramRow["MAT_MTYPE"] = row["PART_MTYPE"];
                    paramRow["MAT_STYPE"] = row["PART_STYPE"];
                    paramRow["P_PART_CODE"] = row["P_PART_CODE"];
                    paramRow["P_PART_NAME"] = row["P_PART_NAME"];
                    //paramRow["MAT_CODE"] = row["MAT_CODE"];
                    //paramRow["MAT_NAME"] = row["MAT_NAME"];

                    paramRow["TAB_MACHINE"] = row["TAB_MACHINE"];
                    paramRow["MakeSideHole"] = row["MakeSideHole"];
                    //paramRow["도금"] = row["도금"];
                    paramRow["Slit_Division"] = row["Slit_Division"];
                    paramRow["SAFE_STK_QTY"] = row["SAFE_STK_QTY"].toInt() == 0 ? 0 : row["SAFE_STK_QTY"];
                    paramRow["MAT_QLTY"] = row["MAT_QLTY"];

                    paramRow["Surface_Treat"] = row["Surface_Treat"];
                    paramRow["AFTER_TREAT"] = row["AFTER_TREAT"];
                    paramRow["MAKE_DESC"] = row["MAKE_DESC"];

                    paramRow["PART_QTY"] = row["PART_QTY"];
                    paramRow["ORD_QTY"] = row["ORD_QTY"];

                    paramRow["REG_EMP"] = acInfo.UserID;
                    paramRow["OVERWRITE"] = "1";
                    paramTable.Rows.Add(paramRow);

                }


                if (paramTable.Rows.Count != 0)
                {
                    DataSet paramSet = new DataSet();
                    paramSet.Tables.Add(paramTable);

                    BizRun.QBizRun.ExecuteService(
                    this, QBiz.emExecuteType.PROCESS, "ORD02A_INS2", paramSet, "RQSTDT", "RSLTDT",
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

                //foreach(DataRow row in e.result.Tables["RQSTDT"].Rows)
                //{
                //    acGridView2.UpdateMapingRow(row, true);
                //}

                //_linkTree.DataSource = e.result.Tables["RQSTDT"];

                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }



    }
}