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
using GemBox.Spreadsheet;
using System.Threading;
using System.IO;
using CodeHelperManager;
using BizManager;

namespace STD
{
    public sealed partial class STD05A_D1A : BaseMenuDialog
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
        public STD05A_D1A()
        {
            InitializeComponent();

            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:SHEET", "시트", "LBG894M9", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);


            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:STARTROW", "시작행", "R309968V", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NUMERIC);

            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:VEN_CODE", "거래처코드", "40957", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:VEN_NAME", "거래처명", "40956", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:VEN_TYPE", "거래처 형태", "6OAMFTNJ", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:VEN_CAT_CODE", "거래처 분류", "U48S66C9", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:VEN_PRODUCTS", "취급품목", "40683", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:VEN_CEO", "대표자명", "40139", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:VEN_BIZ_NO", "사업자등록번호", "40256", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:VEN_ID_NO", "법인등록번호", "41006", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:VEN_BANK", "거래은행", "40022", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:VEN_BANK_NO", "계좌번호", "E4T9XCVC", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:VEN_COUNTRY", "국가", "40074", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:VEN_START_DATE", "거래시작일", "40020", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:VEN_CREDIT", "신용등급", "40396", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:VEN_ZIP", "우편번호", "40455", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:VEN_ADDRESS", "주소", "40626", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:VEN_TEL", "전화번호", "WCO6Q0OP", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:VEN_FAX", "팩스", "40713", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:VEN_EMAIL", "E-Mail", "40790", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:VEN_CHARGE_EMP", "담당자", "40127", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:VEN_CHARGE_TEL", "담당자 전화번호", "40128", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:VEN_CHARGE_HP", "담당자 휴대폰", "40129", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:SCOMMENT", "비고", "ARYZ726K", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);





            acGridView2.GridType = acGridView.emGridType.SEARCH;


            acGridView2.AddCheckEdit("SEL", "선택", "40290", true, true, true, acGridView.emCheckEditDataType._STRING);

            acGridView2.AddCheckEdit("OVERWRITE", "덮어쓰기", "QJJIK4V9", true, true, true, acGridView.emCheckEditDataType._STRING);

            acGridView2.AddTextEdit("VEN_CODE", "거래처코드", "40957", true, DevExpress.Utils.HorzAlignment.Center, true, true, true, acGridView.emTextEditMask.NONE);

            acGridView2.AddTextEdit("VEN_NAME", "거래처명", "40956", true, DevExpress.Utils.HorzAlignment.Center, true, true, true, acGridView.emTextEditMask.NONE);

            acGridView2.AddLookUpEdit("VEN_TYPE", "거래처 형태", "6OAMFTNJ", true, DevExpress.Utils.HorzAlignment.Center, true, true, false, "S019");

            acGridView2.AddLookUpEdit("VEN_CAT_CODE", "거래처 분류", "U48S66C9", true, DevExpress.Utils.HorzAlignment.Center, true, true, false, "C016");

            acGridView2.AddTextEdit("VEN_PRODUCTS", "취급품목", "40683", true, DevExpress.Utils.HorzAlignment.Center, true, true, false, acGridView.emTextEditMask.NONE);


            acGridView2.AddTextEdit("VEN_CEO", "대표자명", "40139", true, DevExpress.Utils.HorzAlignment.Center, true, true, false, acGridView.emTextEditMask.NONE);

            acGridView2.AddTextEdit("VEN_BIZ_NO", "사업자등록번호", "40256", true, DevExpress.Utils.HorzAlignment.Center, true, true, false, acGridView.emTextEditMask.CORP);

            acGridView2.AddTextEdit("VEN_ID_NO", "법인등록번호", "41006", true, DevExpress.Utils.HorzAlignment.Center, true, true, false, acGridView.emTextEditMask.LAW);

            acGridView2.AddLookUpEdit("VEN_BANK", "거래은행", "40022", true, DevExpress.Utils.HorzAlignment.Center, true, true, false, "C404");

            acGridView2.AddTextEdit("VEN_BANK_NO", "계좌번호", "E4T9XCVC", true, DevExpress.Utils.HorzAlignment.Near, true, true, false, acGridView.emTextEditMask.NONE);

            acGridView2.AddLookUpEdit("VEN_COUNTRY", "국가", "40074", true, DevExpress.Utils.HorzAlignment.Center, true, true, false, "S020");

            acGridView2.AddDateEdit("VEN_START_DATE", "거래시작일", "40020", true, DevExpress.Utils.HorzAlignment.Center, true, true, false, acGridView.emDateMask.SHORT_DATE);

            acGridView2.AddLookUpEdit("VEN_CREDIT", "신용등급", "40396", true, DevExpress.Utils.HorzAlignment.Center, true, true, false, "C021");

            acGridView2.AddTextEdit("VEN_ZIP", "우편번호", "40455", true, DevExpress.Utils.HorzAlignment.Center, true, true, false, acGridView.emTextEditMask.ZIP);

            acGridView2.AddTextEdit("VEN_ADDRESS", "주소", "40626", true, DevExpress.Utils.HorzAlignment.Near, true, true, false, acGridView.emTextEditMask.NONE);

            acGridView2.AddTextEdit("VEN_TEL", "전화번호", "WCO6Q0OP", true, DevExpress.Utils.HorzAlignment.Center, true, true, false, acGridView.emTextEditMask.TEL);

            acGridView2.AddTextEdit("VEN_FAX", "팩스", "40713", true, DevExpress.Utils.HorzAlignment.Center, true, true, false, acGridView.emTextEditMask.TEL);

            acGridView2.AddTextEdit("VEN_EMAIL", "E-Mail", "40790", true, DevExpress.Utils.HorzAlignment.Center, true, true, false, acGridView.emTextEditMask.NONE);

            acGridView2.AddTextEdit("VEN_CHARGE_EMP", "담당자", "40127", true, DevExpress.Utils.HorzAlignment.Center, true, true, false, acGridView.emTextEditMask.NONE);

            acGridView2.AddTextEdit("VEN_CHARGE_TEL", "담당자 전화번호", "40128", true, DevExpress.Utils.HorzAlignment.Center, true, true, false, acGridView.emTextEditMask.TEL);

            acGridView2.AddTextEdit("VEN_CHARGE_HP", "담당자 휴대폰", "40129", true, DevExpress.Utils.HorzAlignment.Center, true, true, false, acGridView.emTextEditMask.TEL);

            acGridView2.AddTextEdit("SCOMMENT", "비고", "ARYZ726K", true, DevExpress.Utils.HorzAlignment.Near, true, true, false, acGridView.emTextEditMask.NONE);

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

                openFileDialog1.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                openFileDialog1.Filter = "Excel Files|*.xls;*.xlsx; | All Files|*.*";
                openFileDialog1.FilterIndex = 1;
                openFileDialog1.RestoreDirectory = true;

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {

                    this._ExcelFileLoadThread = new BizManager.QThread(this, BizManager.QThread.emExecuteType.LOAD);

                    this._ExcelFileLoadThread.Execute(ExcelFileLoadThreadStarter, new object[] {  openFileDialog1.FileName });

                    
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
                string excelFileName = parameter[0] as string;

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
                int nRow = acVerticalGrid1.GetCellValue("EXCEL_IMPORT:STARTROW").toInt()-1;

                DataTable ecData = acGridView2.NewTable();

                int cnt = 0;

                if (acVerticalGrid1.GetCellValue("EXCEL_IMPORT:VEN_CODE").isNullOrEmpty() == false)
                {

                    while (sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT:VEN_CODE").ToString()].Cells[nRow].Value.isNullOrEmpty() == false)
                    {

                        this._ExcelFileLoadThread.SetCount(cnt);

                        DataRow ecRow = ecData.NewRow();

                        ecRow["SEL"] = "0";
                        ecRow["OVERWRITE"] = "0";


                        if (acVerticalGrid1.GetCellValue("EXCEL_IMPORT:VEN_CODE").isNullOrEmpty() == false)
                        {
                            ecRow["VEN_CODE"] = sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT:VEN_CODE").ToString()].Cells[nRow].Value;
                        }


                        if (acVerticalGrid1.GetCellValue("EXCEL_IMPORT:VEN_NAME").isNullOrEmpty() == false)
                        {
                            ecRow["VEN_NAME"] = sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT:VEN_NAME").ToString()].Cells[nRow].Value;
                        }


                        if (acVerticalGrid1.GetCellValue("EXCEL_IMPORT:VEN_TYPE").isNullOrEmpty() == false)
                        {
                            ecRow["VEN_TYPE"] = acInfo.StdCodes.GetCodeByName("S019", sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT:VEN_TYPE").ToString()].Cells[nRow].Value);
                        }

                        if (acVerticalGrid1.GetCellValue("EXCEL_IMPORT:VEN_CAT_CODE").isNullOrEmpty() == false)
                        {
                            ecRow["VEN_CAT_CODE"] = acInfo.StdCodes.GetCodeByName("C016", sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT:VEN_CAT_CODE").ToString()].Cells[nRow].Value);
                        }


                        if (acVerticalGrid1.GetCellValue("EXCEL_IMPORT:VEN_PRODUCTS").isNullOrEmpty() == false)
                        {
                            ecRow["VEN_PRODUCTS"] = sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT:VEN_PRODUCTS").ToString()].Cells[nRow].Value.toStringEmpty();
                        }

                        if (acVerticalGrid1.GetCellValue("EXCEL_IMPORT:VEN_CEO").isNullOrEmpty() == false)
                        {
                            ecRow["VEN_CEO"] = sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT:VEN_CEO").ToString()].Cells[nRow].Value.toStringEmpty();
                        }

                        if (acVerticalGrid1.GetCellValue("EXCEL_IMPORT:VEN_BIZ_NO").isNullOrEmpty() == false)
                        {
                            ecRow["VEN_BIZ_NO"] = sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT:VEN_BIZ_NO").ToString()].Cells[nRow].Value.toStringEmpty();
                        }

                        if (acVerticalGrid1.GetCellValue("EXCEL_IMPORT:VEN_ID_NO").isNullOrEmpty() == false)
                        {
                            ecRow["VEN_ID_NO"] = sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT:VEN_ID_NO").ToString()].Cells[nRow].Value.toStringEmpty();
                        }


                        if (acVerticalGrid1.GetCellValue("EXCEL_IMPORT:VEN_BANK").isNullOrEmpty() == false)
                        {
                            ecRow["VEN_BANK"] = acInfo.StdCodes.GetCodeByName("C404", sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT:VEN_BANK").ToString()].Cells[nRow].Value);
                        }


                        if (acVerticalGrid1.GetCellValue("EXCEL_IMPORT:VEN_BANK_NO").isNullOrEmpty() == false)
                        {
                            ecRow["VEN_BANK_NO"] = sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT:VEN_BANK_NO").ToString()].Cells[nRow].Value.toStringEmpty();
                        }


                        if (acVerticalGrid1.GetCellValue("EXCEL_IMPORT:VEN_COUNTRY").isNullOrEmpty() == false)
                        {
                            ecRow["VEN_COUNTRY"] = acInfo.StdCodes.GetCodeByName("S020", sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT:VEN_COUNTRY").ToString()].Cells[nRow].Value);
                        }

                        if (acVerticalGrid1.GetCellValue("EXCEL_IMPORT:VEN_START_DATE").isNullOrEmpty() == false)
                        {
                            ecRow["VEN_START_DATE"] = sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT:VEN_START_DATE").ToString()].Cells[nRow].Value.toDateTimeDBNull();
                        }


                        if (acVerticalGrid1.GetCellValue("EXCEL_IMPORT:VEN_CREDIT").isNullOrEmpty() == false)
                        {
                            ecRow["VEN_CREDIT"] = acInfo.StdCodes.GetCodeByName("C021", sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT:VEN_CREDIT").ToString()].Cells[nRow].Value);
                        }


                        if (acVerticalGrid1.GetCellValue("EXCEL_IMPORT:VEN_ZIP").isNullOrEmpty() == false)
                        {
                            ecRow["VEN_ZIP"] = sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT:VEN_ZIP").ToString()].Cells[nRow].Value.toStringEmpty();
                        }

                        if (acVerticalGrid1.GetCellValue("EXCEL_IMPORT:VEN_ADDRESS").isNullOrEmpty() == false)
                        {
                            ecRow["VEN_ADDRESS"] = sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT:VEN_ADDRESS").ToString()].Cells[nRow].Value.toStringEmpty();
                        }

                        if (acVerticalGrid1.GetCellValue("EXCEL_IMPORT:VEN_TEL").isNullOrEmpty() == false)
                        {
                            ecRow["VEN_TEL"] = sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT:VEN_TEL").ToString()].Cells[nRow].Value.toStringEmpty();
                        }

                        if (acVerticalGrid1.GetCellValue("EXCEL_IMPORT:VEN_FAX").isNullOrEmpty() == false)
                        {
                            ecRow["VEN_FAX"] = sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT:VEN_FAX").ToString()].Cells[nRow].Value.toStringEmpty();
                        }

                        if (acVerticalGrid1.GetCellValue("EXCEL_IMPORT:VEN_EMAIL").isNullOrEmpty() == false)
                        {
                            ecRow["VEN_EMAIL"] = sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT:VEN_EMAIL").ToString()].Cells[nRow].Value.toStringEmpty();
                        }

                        if (acVerticalGrid1.GetCellValue("EXCEL_IMPORT:VEN_CHARGE_EMP").isNullOrEmpty() == false)
                        {
                            ecRow["VEN_CHARGE_EMP"] = sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT:VEN_CHARGE_EMP").ToString()].Cells[nRow].Value.toStringEmpty();
                        }

                        if (acVerticalGrid1.GetCellValue("EXCEL_IMPORT:VEN_CHARGE_TEL").isNullOrEmpty() == false)
                        {
                            ecRow["VEN_CHARGE_TEL"] = sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT:VEN_CHARGE_TEL").ToString()].Cells[nRow].Value.toStringEmpty();
                        }

                        if (acVerticalGrid1.GetCellValue("EXCEL_IMPORT:VEN_CHARGE_HP").isNullOrEmpty() == false)
                        {
                            ecRow["VEN_CHARGE_HP"] = sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT:VEN_CHARGE_HP").ToString()].Cells[nRow].Value.toStringEmpty();
                        }

                        if (acVerticalGrid1.GetCellValue("EXCEL_IMPORT:SCOMMENT").isNullOrEmpty() == false)
                        {
                            ecRow["SCOMMENT"] = sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT:SCOMMENT").ToString()].Cells[nRow].Value.toStringEmpty();
                        }

                        ecData.Rows.Add(ecRow);

                        ++nRow;

                        ++cnt;
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
            if (ex.ErrNumber == BizManager.BizException.OVERWRITE ||
                ex.ErrNumber == BizManager.BizException.OVERWRITE_HISTORY)
            {


                //동일 데이터가 존재합니다. 덮어쓰실려면 체크 하신후, 다시 시도하시기 바랍니다.
                acMessageBoxGridConfirm frm = new acMessageBoxGridConfirm(this, "acMessageBoxGridConfirm1", acInfo.BizError.GetDesc(100016), string.Empty, false, this.Caption, ex.ParameterData);

                frm.View.GridType = ControlManager.acGridView.emGridType.FIXED;

                frm.View.AddTextEdit("KEY", "거래처코드", "40957", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

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
                paramTable.Columns.Add("VEN_CODE", typeof(String)); //
                paramTable.Columns.Add("VEN_NAME", typeof(String)); //
                paramTable.Columns.Add("VEN_TYPE", typeof(String)); //
                paramTable.Columns.Add("VEN_CAT_CODE", typeof(String)); //
                paramTable.Columns.Add("VEN_COUNTRY", typeof(String)); //
                paramTable.Columns.Add("VEN_CEO", typeof(String)); //
                paramTable.Columns.Add("VEN_BIZ_NO", typeof(String)); //
                paramTable.Columns.Add("VEN_ID_NO", typeof(String)); //
                paramTable.Columns.Add("VEN_START_DATE", typeof(String)); //
                paramTable.Columns.Add("VEN_BANK", typeof(String)); //
                paramTable.Columns.Add("VEN_BANK_NO", typeof(String)); //
                paramTable.Columns.Add("VEN_CREDIT", typeof(String)); //
                paramTable.Columns.Add("VEN_ZIP", typeof(String)); //
                paramTable.Columns.Add("VEN_ADDRESS", typeof(String)); //
                paramTable.Columns.Add("VEN_TEL", typeof(String)); //
                paramTable.Columns.Add("VEN_FAX", typeof(String)); //
                paramTable.Columns.Add("VEN_EMAIL", typeof(String)); //
                paramTable.Columns.Add("VEN_PRODUCTS", typeof(String)); //
                paramTable.Columns.Add("VEN_CHARGE_EMP", typeof(String)); //
                paramTable.Columns.Add("VEN_CHARGE_TEL", typeof(String)); //
                paramTable.Columns.Add("VEN_CHARGE_HP", typeof(String)); //
                paramTable.Columns.Add("SCOMMENT", typeof(String)); //
                paramTable.Columns.Add("IS_MYVENDOR", typeof(Byte)); //
                paramTable.Columns.Add("REG_EMP", typeof(String)); //
                paramTable.Columns.Add("OVERWRITE", typeof(String)); //덮어쓰기 여부


                DataView view = acGridView2.GetDataSourceView("SEL = '1'");

                foreach (DataRowView rv in view)
                {

                    DataRow row = rv.Row;

                    DataRow paramRow = paramTable.NewRow();
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["VEN_CODE"] = row["VEN_CODE"];
                    paramRow["VEN_NAME"] = row["VEN_NAME"];
                    paramRow["VEN_TYPE"] = row["VEN_TYPE"];
                    paramRow["VEN_CAT_CODE"] = row["VEN_CAT_CODE"];
                    paramRow["VEN_COUNTRY"] = row["VEN_COUNTRY"];
                    paramRow["VEN_CEO"] = row["VEN_CEO"];
                    paramRow["VEN_BIZ_NO"] = row["VEN_BIZ_NO"];
                    paramRow["VEN_ID_NO"] = row["VEN_ID_NO"];
                    paramRow["VEN_START_DATE"] = row["VEN_START_DATE"].toDateStringDBNull("yyyyMMdd");
                    paramRow["VEN_BANK"] = row["VEN_BANK"];
                    paramRow["VEN_BANK_NO"] = row["VEN_BANK_NO"];
                    paramRow["VEN_CREDIT"] = row["VEN_CREDIT"];
                    paramRow["VEN_ZIP"] = row["VEN_ZIP"];
                    paramRow["VEN_ADDRESS"] = row["VEN_ADDRESS"];
                    paramRow["VEN_TEL"] = row["VEN_TEL"];
                    paramRow["VEN_FAX"] = row["VEN_FAX"];
                    paramRow["VEN_EMAIL"] = row["VEN_EMAIL"];
                    paramRow["VEN_PRODUCTS"] = row["VEN_PRODUCTS"];
                    paramRow["VEN_CHARGE_EMP"] = row["VEN_CHARGE_EMP"];
                    paramRow["VEN_CHARGE_TEL"] = row["VEN_CHARGE_TEL"];
                    paramRow["VEN_CHARGE_HP"] = row["VEN_CHARGE_HP"];
                    paramRow["SCOMMENT"] = row["SCOMMENT"];
                    paramRow["IS_MYVENDOR"] = 0;
                    paramRow["REG_EMP"] = acInfo.UserID;
                    paramRow["OVERWRITE"] = row["OVERWRITE"];
                    paramTable.Rows.Add(paramRow);


                }


                if (paramTable.Rows.Count != 0)
                {
                    DataSet paramSet = new DataSet();
                    paramSet.Tables.Add(paramTable);
                    
                    BizRun.QBizRun.ExecuteService(
                    this, QBiz.emExecuteType.PROCESS, "STD05A_INS", paramSet, "RQSTDT", "RSLTDT",
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

                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }



    }
}