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

namespace SYS
{
    public sealed partial class SYS32A_D2A : BaseMenuDialog
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
        public SYS32A_D2A()
        {
            InitializeComponent();



            acVerticalGrid1.AddTextEdit("RESOURCE_EXCEL_IMPORT:STARTROW", "시작행", "R309968V", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NUMERIC);

            acVerticalGrid1.AddTextEdit("RESOURCE_EXCEL_IMPORT:RES_ID", "ID", "OYL0JR2M", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

            acVerticalGrid1.AddTextEdit("RESOURCE_EXCEL_IMPORT:RES_CONTENTS", "내용", "O00RH4SM", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);


            acVerticalGrid1.BestFit();


            acGridView2.GridType = acGridView.emGridType.SEARCH;


            acGridView2.AddCheckEdit("SEL", "선택", "40290", true, true, true, acGridView.emCheckEditDataType._STRING);


            acGridView2.AddTextEdit("RES_ID", "ID", "OYL0JR2M", true, DevExpress.Utils.HorzAlignment.Center, true, true, true, acGridView.emTextEditMask.NONE);

            acGridView2.AddTextEdit("RES_CONTENTS", "내용", "O00RH4SM", true, DevExpress.Utils.HorzAlignment.Center, true, true, true, acGridView.emTextEditMask.NONE);



        }


        public override void DialogInit()
        {


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

                ExcelWorksheet sheet = ef.Worksheets[0];


                //시작행 
                int nRow = acVerticalGrid1.GetCellValue("RESOURCE_EXCEL_IMPORT:STARTROW").toInt() - 1;

                DataTable ecData = acGridView2.NewTable();

                int cnt = 0;

                if (acVerticalGrid1.GetCellValue("RESOURCE_EXCEL_IMPORT:RES_ID").isNullOrEmpty() == false)
                {
                    while (sheet.Columns[acVerticalGrid1.GetCellValue("RESOURCE_EXCEL_IMPORT:RES_ID").ToString()].Cells[nRow].Value.isNullOrEmpty() == false)
                    {

                        this._ExcelFileLoadThread.SetCount(cnt);

                        DataRow ecRow = ecData.NewRow();

                        ecRow["SEL"] = "0";


                        //부품

                        if (acVerticalGrid1.GetCellValue("RESOURCE_EXCEL_IMPORT:RES_ID").isNullOrEmpty() == false)
                        {
                            ecRow["RES_ID"] = sheet.Columns[acVerticalGrid1.GetCellValue("RESOURCE_EXCEL_IMPORT:RES_ID").ToString()].Cells[nRow].Value;
                        }


                        if (acVerticalGrid1.GetCellValue("RESOURCE_EXCEL_IMPORT:RES_CONTENTS").isNullOrEmpty() == false)
                        {
                            ecRow["RES_CONTENTS"] = sheet.Columns[acVerticalGrid1.GetCellValue("RESOURCE_EXCEL_IMPORT:RES_CONTENTS").ToString()].Cells[nRow].Value;
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

            acMessageBox.Show(this, ex);


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


                DataTable paramTable = new DataTable("RQSTDT2");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("RES_ID", typeof(String)); //
                paramTable.Columns.Add("RES_LANG", typeof(String)); //
                paramTable.Columns.Add("RES_CONTENTS", typeof(String)); //

                DataView view = acGridView2.GetDataSourceView("SEL = '1'");

                foreach (DataRowView rv in view)
                {

                    DataRow row = rv.Row;

                    DataRow paramRow = paramTable.NewRow();
                    paramRow["PLT_CODE"] = row["PLT_CODE"];
                    paramRow["RES_ID"] = row["RES_ID"];
                    paramRow["RES_LANG"] = acInfo.Lang;
                    paramRow["RES_CONTENTS"] = row["RES_CONTENTS"];

                    paramTable.Rows.Add(paramRow);


                }


                if (paramTable.Rows.Count != 0)
                {
                    DataSet paramSet = new DataSet();
                    paramSet.Tables.Add(paramTable);

                    BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.SAVE, "SYS32A_INS", paramSet, "RQSTDT", "RSLTDT",
                            QuickSave,
                            QuickException);

                    //BizRun.QBizRun.ExecuteService(
                    //this, ControlManager.QBiz.emExecuteType.PROCESS, "SYS32A_INS", paramSet, "RQSTDT", "RSLTDT",
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