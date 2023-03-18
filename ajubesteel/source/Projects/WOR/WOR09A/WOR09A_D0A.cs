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

namespace WOR
{
    public sealed partial class WOR09A_D0A : BaseMenuDialog
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


        public WOR09A_D0A()
        {
            InitializeComponent();

            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:SHEET", "시트", "LBG894M9", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);

            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:STARTROW", "시작행", "R309968V", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NUMERIC);

            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:WORK_DATE", "근무일자", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:ORG_NAME", "조직", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:EMP_CODE", "사원ID", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:EMP_NAME", "이름", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:EMP_TITLE", "직급", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:WORK_START_TIME", "출근시간", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:WORK_END_TIME", "퇴근시간", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:WORK_START_TYPE", "출근판정", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:WORK_END_TYPE", "퇴근판정", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:WORK_TIME", "신제근무시간", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:SCOMMENT", "비고", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

            acGridView1.GridType = acGridView.emGridType.SEARCH;

            acGridView1.AddTextEdit("WORK_DATE", "근무일자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("ORG_NAME", "조직", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("EMP_CODE", "사원ID", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("EMP_NAME", "이름", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("EMP_TITLE", "직급", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            //acGridView1.AddDateEdit("WORK_START_TIME", "출근시간", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.MEDIUM_DATE2);
            acGridView1.AddTextEdit("WORK_START_TIME", "출근시간", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            //acGridView1.AddDateEdit("WORK_END_TIME", "퇴근시간", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.MEDIUM_DATE2);
            acGridView1.AddTextEdit("WORK_END_TIME", "퇴근시간", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("WORK_START_TYPE", "출근판정", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("WORK_END_TYPE", "퇴근판정", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("WORK_TIME", "실제근무시간", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("SCOMMENT", "비고", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.KeyColumn = new string[] { "WORK_DATE", "EMP_CODE" };
        }

        public override void DialogInit()
        {
            acVerticalGrid1.DataBind(this.GetMenuConfigRowTableByServer().Rows[0]);

            acVerticalGrid1.BestFit();

            base.DialogInit();
        }


        public override void DialogNew()
        {

            base.DialogNew();
        }

        public override void DialogOpen()
        {
            base.DialogOpen();
        }

        private ControlManager.QThread _ExcelFileLoadThread = null;

        private void acBarButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //엑셀파일 열기

            try
            {
                acVerticalGrid1.EndEditor();

                DataTable data = acVerticalGrid1.CreateParameterTable(true);

                foreach (DataColumn col in data.Columns)
                {
                    acInfo.MenuConfig.SetMenuConfigByServer("WOR09A", col.ColumnName, data.Rows[0][col.ColumnName].toStringEmpty());
                }

                OpenFileDialog openFileDialog1 = new OpenFileDialog();

                //openFileDialog1.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                openFileDialog1.Filter = "Excel Files|*.xls;*.xlsx; | All Files|*.*";
                openFileDialog1.FilterIndex = 1;
                openFileDialog1.RestoreDirectory = true;

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {

                    acGridView1.ClearRow();

                    acGridView1.AcceptChanges();

                    this._ExcelFileLoadThread = new ControlManager.QThread(this, ControlManager.QThread.emExecuteType.LOAD);

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

                //ExcelFile ef = new ExcelFile();

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

                DataTable ecData = acGridView1.NewTable();

                int cnt = 0;

                if (acVerticalGrid1.GetCellValue("EXCEL_IMPORT:EMP_CODE").isNullOrEmpty() == false)
                {
                    while (sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT:EMP_CODE").ToString()][nRow].Value.isNullOrEmpty() == false)
                    {

                        this._ExcelFileLoadThread.SetCount(cnt);

                        DataRow ecRow = ecData.NewRow();


                        if (acVerticalGrid1.GetCellValue("EXCEL_IMPORT:WORK_DATE").isNullOrEmpty() == false)
                        {
                            ecRow["WORK_DATE"] = sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT:WORK_DATE").ToString()][nRow].Value;
                        }

                        if (acVerticalGrid1.GetCellValue("EXCEL_IMPORT:ORG_NAME").isNullOrEmpty() == false)
                        {
                            ecRow["ORG_NAME"] = sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT:ORG_NAME").ToString()][nRow].Value;
                        }

                        if (acVerticalGrid1.GetCellValue("EXCEL_IMPORT:EMP_CODE").isNullOrEmpty() == false)
                        {
                            ecRow["EMP_CODE"] = sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT:EMP_CODE").ToString()][nRow].Value;
                        }

                        if (acVerticalGrid1.GetCellValue("EXCEL_IMPORT:EMP_NAME").isNullOrEmpty() == false)
                        {
                            ecRow["EMP_NAME"] = sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT:EMP_NAME").ToString()][nRow].Value;
                        }

                        if (acVerticalGrid1.GetCellValue("EXCEL_IMPORT:EMP_TITLE").isNullOrEmpty() == false)
                        {
                            ecRow["EMP_TITLE"] = sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT:EMP_TITLE").ToString()][nRow].Value;
                        }

                        if (acVerticalGrid1.GetCellValue("EXCEL_IMPORT:WORK_START_TIME").isNullOrEmpty() == false)
                        {
                            ecRow["WORK_START_TIME"] = sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT:WORK_START_TIME").ToString()][nRow].Value;
                        }

                        if (acVerticalGrid1.GetCellValue("EXCEL_IMPORT:WORK_END_TIME").isNullOrEmpty() == false)
                        {
                            ecRow["WORK_END_TIME"] = sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT:WORK_END_TIME").ToString()][nRow].Value;
                        }

                        if (acVerticalGrid1.GetCellValue("EXCEL_IMPORT:WORK_START_TYPE").isNullOrEmpty() == false)
                        {
                            ecRow["WORK_START_TYPE"] = sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT:WORK_START_TYPE").ToString()][nRow].Value;
                        }

                        if (acVerticalGrid1.GetCellValue("EXCEL_IMPORT:WORK_END_TYPE").isNullOrEmpty() == false)
                        {
                            ecRow["WORK_END_TYPE"] = sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT:WORK_END_TYPE").ToString()][nRow].Value;
                        }

                        if (acVerticalGrid1.GetCellValue("EXCEL_IMPORT:WORK_TIME").isNullOrEmpty() == false)
                        {
                            ecRow["WORK_TIME"] = sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT:WORK_TIME").ToString()][nRow].Value;
                        }

                        if (acVerticalGrid1.GetCellValue("EXCEL_IMPORT:SCOMMENT").isNullOrEmpty() == false)
                        {
                            ecRow["SCOMMENT"] = sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT:SCOMMENT").ToString()][nRow].Value;
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
                        DataTable now = acGridView1.GridControl.DataSource as DataTable;

                        now.Load(new DataTableReader(ecData));

                        acGridView1.ResetGridRowSeq();

                        acGridView1.BestFitColumns();
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
            //저장
            acGridView1.EndEditor();

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("WORK_DATE", typeof(String)); //
            paramTable.Columns.Add("ORG_NAME", typeof(String)); //
            paramTable.Columns.Add("EMP_CODE", typeof(String)); //
            paramTable.Columns.Add("EMP_NAME", typeof(String)); //
            paramTable.Columns.Add("EMP_TITLE", typeof(String)); //
            paramTable.Columns.Add("WORK_START_TIME", typeof(DateTime)); //
            paramTable.Columns.Add("WORK_END_TIME", typeof(DateTime)); //
            paramTable.Columns.Add("WORK_START_TYPE", typeof(String)); //
            paramTable.Columns.Add("WORK_END_TYPE", typeof(String)); //
            paramTable.Columns.Add("WORK_TIME", typeof(String)); //
            paramTable.Columns.Add("SCOMMENT", typeof(String)); //


            DataView view = acGridView1.GetDataSourceView();

            foreach (DataRowView rv in view)
            {

                DataRow row = rv.Row;

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["WORK_DATE"] = row["WORK_DATE"].toDateString("yyyyMMdd");
                paramRow["ORG_NAME"] = row["ORG_NAME"];
                paramRow["EMP_CODE"] = row["EMP_CODE"];
                paramRow["EMP_NAME"] = row["EMP_NAME"];
                paramRow["EMP_TITLE"] = row["EMP_TITLE"];

                if (row["WORK_START_TIME"].ToString().Length > 0)
                {
                    paramRow["WORK_START_TIME"] = row["WORK_START_TIME"].ToString().Replace(" ", "").toDateTime();
                }

                if (row["WORK_END_TIME"].ToString().Length > 0)
                {
                    paramRow["WORK_END_TIME"] = row["WORK_END_TIME"].ToString().Replace(" ", "").toDateTime();
                }
                paramRow["WORK_START_TYPE"] = row["WORK_START_TYPE"];
                paramRow["WORK_END_TYPE"] = row["WORK_END_TYPE"];
                paramRow["WORK_TIME"] = row["WORK_TIME"];
                paramRow["SCOMMENT"] = row["SCOMMENT"];
                paramTable.Rows.Add(paramRow);

            }


            if (paramTable.Rows.Count != 0)
            {
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.PROCESS, "WOR09A_INS", paramSet, "RQSTDT", "",
                QuickSave,
                QuickException);
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