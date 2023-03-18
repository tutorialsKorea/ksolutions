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
using DevExpress.XtraGrid.Views.Grid;
using CodeHelperManager;
using BizManager;

namespace STD
{
    public sealed partial class STD26A_D2A : BaseMenuDialog
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

        public STD26A_D2A()
        {
            InitializeComponent();

            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:SHEET", "시트", "LBG894M9", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);

            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:STARTROW", "시작행", "R309968V", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NUMERIC);

            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:MQLTY_CODE", "재질코드", "QGD6SY0U", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:MQLTY_NAME", "재질명", "40572", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:MQLTY_WEIGHT", "비중", "40248", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:UNIT_CONVERT_VALUE", "단위환산값", "VRR6Q9XZ", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:SCOMMENT", "비고", "ARYZ726K", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);








            acGridView2.GridType = acGridView.emGridType.SEARCH;


            acGridView2.AddCheckEdit("SEL", "선택", "40290", true, true, true, acGridView.emCheckEditDataType._STRING);


            acGridView2.AddCheckEdit("OVERWRITE", "덮어쓰기", "QJJIK4V9", true, true, true, acGridView.emCheckEditDataType._STRING);


            acGridView2.AddTextEdit("MQLTY_CODE", "재질코드", "QGD6SY0U", true, DevExpress.Utils.HorzAlignment.Center, true, true, true, acGridView.emTextEditMask.NONE);

            acGridView2.AddTextEdit("MQLTY_NAME", "재질명", "40572", true, DevExpress.Utils.HorzAlignment.Center, true, true, true, acGridView.emTextEditMask.NONE);

            acGridView2.AddTextEdit("MQLTY_WEIGHT", "비중", "40248", true, DevExpress.Utils.HorzAlignment.Far, true, true, true, acGridView.emTextEditMask.WEIGHT);

            acGridView2.AddTextEdit("UNIT_CONVERT_VALUE", "단위환산값", "VRR6Q9XZ", true, DevExpress.Utils.HorzAlignment.Far, true, true, true, acGridView.emTextEditMask.NUMERIC);

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

                    this._ExcelFileLoadThread.Execute(ExcelFileLoadThreadStarter, new object[] { openFileDialog1.FileName });


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
                int nRow = acVerticalGrid1.GetCellValue("EXCEL_IMPORT:STARTROW").toInt() - 1;

                DataTable ecData = acGridView2.NewTable();


                int cnt = 0;

                if (acVerticalGrid1.GetCellValue("EXCEL_IMPORT:MQLTY_CODE").isNullOrEmpty() == false)
                {

                    while (sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT:MQLTY_CODE").ToString()].Cells[nRow].Value.isNullOrEmpty() == false)
                    {


                        this._ExcelFileLoadThread.SetCount(cnt);


                        DataRow ecRow = ecData.NewRow();

                        ecRow["SEL"] = "0";
                        ecRow["OVERWRITE"] = "0";

                        if (acVerticalGrid1.GetCellValue("EXCEL_IMPORT:MQLTY_CODE").isNullOrEmpty() == false)
                        {
                            ecRow["MQLTY_CODE"] = sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT:MQLTY_CODE").ToString()].Cells[nRow].Value;
                        }


                        if (acVerticalGrid1.GetCellValue("EXCEL_IMPORT:MQLTY_NAME").isNullOrEmpty() == false)
                        {
                            ecRow["MQLTY_NAME"] = sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT:MQLTY_NAME").ToString()].Cells[nRow].Value;
                        }



                        if (acVerticalGrid1.GetCellValue("EXCEL_IMPORT:MQLTY_WEIGHT").isNullOrEmpty() == false)
                        {
                            ecRow["MQLTY_WEIGHT"] = sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT:MQLTY_WEIGHT").ToString()].Cells[nRow].Value.toDecimal();
                        }

                        if (acVerticalGrid1.GetCellValue("EXCEL_IMPORT:UNIT_CONVERT_VALUE").isNullOrEmpty() == false)
                        {
                            ecRow["UNIT_CONVERT_VALUE"] = sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT:UNIT_CONVERT_VALUE").ToString()].Cells[nRow].Value.toDecimal();
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
            if (ex.ErrNumber == BizManager.BizException.OVERWRITE ||
                ex.ErrNumber == BizManager.BizException.OVERWRITE_HISTORY)
            {

                //동일 데이터가 존재합니다. 덮어쓰실려면 체크 하신후, 다시 시도하시기 바랍니다.
                acMessageBoxGridConfirm frm = new acMessageBoxGridConfirm(this, "acMessageBoxGridConfirm1", acInfo.BizError.GetDesc(100016), string.Empty, false, this.Caption, ex.ParameterData);

                frm.View.GridType = ControlManager.acGridView.emGridType.FIXED;

                frm.View.AddTextEdit("KEY", "재질코드", "QGD6SY0U", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

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
                paramTable.Columns.Add("MQLTY_CODE", typeof(String)); //
                paramTable.Columns.Add("MQLTY_NAME", typeof(String)); //
                paramTable.Columns.Add("MQLTY_WEIGHT", typeof(Decimal)); //
                paramTable.Columns.Add("SCOMMENT", typeof(String)); //
                paramTable.Columns.Add("REG_EMP", typeof(String)); //
                paramTable.Columns.Add("UNIT_CONVERT_VALUE", typeof(Decimal)); //단위환산값
                paramTable.Columns.Add("OVERWRITE", typeof(String)); //덮어쓰기 여부


                DataView view = acGridView2.GetDataSourceView("SEL = '1'");

                foreach (DataRowView rv in view)
                {
                    DataRow row = rv.Row;

                    DataRow paramRow = paramTable.NewRow();
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["MQLTY_CODE"] = row["MQLTY_CODE"];
                    paramRow["MQLTY_NAME"] = row["MQLTY_NAME"];
                    paramRow["MQLTY_WEIGHT"] = row["MQLTY_WEIGHT"];
                    paramRow["SCOMMENT"] = row["SCOMMENT"];
                    paramRow["REG_EMP"] = acInfo.UserID;
                    paramRow["UNIT_CONVERT_VALUE"] = row["UNIT_CONVERT_VALUE"];
                    paramRow["OVERWRITE"] = row["OVERWRITE"];
                    paramTable.Rows.Add(paramRow);


                }


                if (paramTable.Rows.Count != 0)
                {
                    DataSet paramSet = new DataSet();
                    paramSet.Tables.Add(paramTable);

                    BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.PROCESS,
                        "STD26A_INS", paramSet, "RQSTDT", "RSLTDT",
                        QuickSave,
                        QuickException);
                    //BizRun.QBizRun.ExecuteService(
                    //this, ControlManager.QBiz.emExecuteType.PROCESS, "STD26A_INS", paramSet, "RQSTDT", "RSLTDT",
                    //QuickSave,
                    //QuickException);
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
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }



    }
}