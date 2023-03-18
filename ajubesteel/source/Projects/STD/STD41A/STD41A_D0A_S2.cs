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
    public sealed partial class STD41A_D0A_S2 : BaseMenuDialog
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
        public STD41A_D0A_S2()
        {
            InitializeComponent();


            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:SHEET", "시트", "LBG894M9", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);

            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:STARTROW", "시작행", "R309968V", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NUMERIC);

            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:LPROC_CODE", "대일정", "40134", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:MPROC_CODE", "중일정", "40632", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:PROC_CODE", "공정코드", "40920", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:PROC_NAME", "공정명", "40921", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:PROC_COLOR", "색상", "40281", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:INS_FLAG", "입고검사여부", "42560", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:PROC_MAN_TIME", "기본 유인공수", "26Q8PX5Z", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:PROC_SELF_TIME", "기본 무인공수", "WEN5OLRH", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:IS_OS", "외주가능", "0PZP4HXS", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:IS_BOP_PROC", "BOP 공정", "OMVJF9WC", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:WO_DEFAULT_OSMC", "외주설비", "0JQXMLGW", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:CPROC_CODE", "견적임률", "UUQM6V6T", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:MAIN_VND", "기본 거래처", "UHQZT510", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:ACT_CODE", "회계계정", "42569", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:PROC_SEQ", "표시순서", "40723", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);






            acGridView2.GridType = acGridView.emGridType.SEARCH;


            acGridView2.AddCheckEdit("SEL", "선택", "40290", true, true, true, acGridView.emCheckEditDataType._STRING);

            acGridView2.AddCheckEdit("OVERWRITE", "덮어쓰기", "QJJIK4V9", true, true, true, acGridView.emCheckEditDataType._STRING);

            acGridView2.AddHidden("LPROC_CODE", typeof(string));

            acGridView2.AddCustomEdit("LPROC_NAME", "대일정", "40134", true, DevExpress.Utils.HorzAlignment.Center, true, true, true, new RepositoryItemPlan());

            acGridView2.Columns["LPROC_NAME"].ColumnEdit.EditValueChanged += new EventHandler(LPROC_NAME_EditValueChanged);

            acGridView2.AddHidden("MPROC_CODE", typeof(string));

            acGridView2.AddCustomEdit("MPROC_NAME", "중일정", "40632", true, DevExpress.Utils.HorzAlignment.Center, true, true, true, new RepositoryItemPlan());

            acGridView2.Columns["MPROC_NAME"].ColumnEdit.EditValueChanged += new EventHandler(MPROC_NAME_EditValueChanged);


            acGridView2.AddTextEdit("PROC_CODE", "공정코드", "40920", true, DevExpress.Utils.HorzAlignment.Center, true, true, true, acGridView.emTextEditMask.NONE);

            acGridView2.AddTextEdit("PROC_NAME", "공정명", "40921", true, DevExpress.Utils.HorzAlignment.Center, true, true, true, acGridView.emTextEditMask.NONE);

            acGridView2.AddColorEdit("PROC_COLOR", "색상", "40281", true, DevExpress.Utils.HorzAlignment.Center, true, true);
            acGridView2.Columns["PROC_COLOR"].ColumnEdit.EditValueChanged += new EventHandler(ColumnEdit_EditValueChanged);

            acGridView2.AddLookUpEdit("INS_FLAG", "입고검사여부", "42560", true, DevExpress.Utils.HorzAlignment.Center, true, true, true, "S063");


            acGridView2.AddTextEdit("PROC_MAN_TIME", "기본 유인공수", "26Q8PX5Z", true, DevExpress.Utils.HorzAlignment.Far, true, true, true, acGridView.emTextEditMask.TIME);

            acGridView2.AddTextEdit("PROC_SELF_TIME", "기본 무인공수", "WEN5OLRH", true, DevExpress.Utils.HorzAlignment.Far, true, true, true, acGridView.emTextEditMask.TIME);



            acGridView2.AddCheckEdit("IS_OS", "외주가능", "0PZP4HXS", true, false, true, acGridView.emCheckEditDataType._STRING);

            acGridView2.AddCheckEdit("IS_BOP_PROC", "BOP 공정", "OMVJF9WC", true, false, true, acGridView.emCheckEditDataType._STRING);

            acGridView2.AddHidden("WO_DEFAULT_OSMC", typeof(string));

            acGridView2.AddCustomEdit("WO_DEFAULT_OSMC_NAME", "외주설비", "0JQXMLGW", true, DevExpress.Utils.HorzAlignment.Center, true, true, false, new RepositoryItemMachine());

            acGridView2.Columns["WO_DEFAULT_OSMC_NAME"].ColumnEdit.EditValueChanged += new EventHandler(WO_DEFAULT_OSMC_NAME_EditValueChanged);


            acGridView2.AddHidden("CPROC_CODE", typeof(string));

            acGridView2.AddCustomEdit("CPROC_NAME", "견적임률", "UUQM6V6T", true, DevExpress.Utils.HorzAlignment.Center, true, true, false, new RepositoryItemWageRate());

            acGridView2.Columns["CPROC_NAME"].ColumnEdit.EditValueChanged += new EventHandler(CPROC_NAME_EditValueChanged);

            acGridView2.AddHidden("MAIN_VND", typeof(string));

            acGridView2.AddCustomEdit("MAIN_VND_NAME", "기본 거래처", "UHQZT510", true, DevExpress.Utils.HorzAlignment.Center, true, true, false, new RepositoryItemWageRate());

            acGridView2.Columns["MAIN_VND_NAME"].ColumnEdit.EditValueChanged += new EventHandler(MAIN_VND_NAME_EditValueChanged);


            acGridView2.AddLookUpEdit("ACT_CODE", "회계계정", "42569", true, DevExpress.Utils.HorzAlignment.Center, true, true, false, "C600");

            acGridView2.AddTextEdit("PROC_SEQ", "표시순서", "40723", true, DevExpress.Utils.HorzAlignment.Far, true, true, false, acGridView.emTextEditMask.NONE);

        }

        void ColumnEdit_EditValueChanged(object sender, EventArgs e)
        {
            acGridView2.EndEditor();

            ColorEdit editor = sender as ColorEdit;

            DataRow focusRow = acGridView2.GetFocusedDataRow();

            focusRow["PROC_COLOR"] = editor.EditValue.toColor().ToArgb();
        }

        void WO_DEFAULT_OSMC_NAME_EditValueChanged(object sender, EventArgs e)
        {
            acGridView2.EndEditor();

            acMachine editor = sender as acMachine;

            DataRow focusRow = acGridView2.GetFocusedDataRow();

            focusRow["WO_DEFAULT_OSMC"] = editor.Value;
        }

        void MAIN_VND_NAME_EditValueChanged(object sender, EventArgs e)
        {
            acGridView2.EndEditor();

            acVendor editor = sender as acVendor;

            DataRow focusRow = acGridView2.GetFocusedDataRow();

            focusRow["MAIN_VND"] = editor.Value;
        }

        void CPROC_NAME_EditValueChanged(object sender, EventArgs e)
        {
            acGridView2.EndEditor();

            acWageRate editor = sender as acWageRate;

            DataRow focusRow = acGridView2.GetFocusedDataRow();

            focusRow["CPROC_CODE"] = editor.Value;
        }

        void MPROC_NAME_EditValueChanged(object sender, EventArgs e)
        {
            acGridView2.EndEditor();

            acPlan editor = sender as acPlan;

            DataRow focusRow = acGridView2.GetFocusedDataRow();

            focusRow["MPROC_CODE"] = editor.Value;
        }


        void LPROC_NAME_EditValueChanged(object sender, EventArgs e)
        {
            acGridView2.EndEditor();

            acPlan editor = sender as acPlan;

            DataRow focusRow = acGridView2.GetFocusedDataRow();

            focusRow["LPROC_CODE"] = editor.Value;
        }



        public override void DialogInit()
        {
            acVerticalGrid1.DataBind(this.GetMenuConfigRowTableByServer().Rows[0]);

            acVerticalGrid1.BestFit();

            base.DialogInit();
        }

        private ControlManager.QThread _ExcelFileLoadThread = null;

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

                if (acVerticalGrid1.GetCellValue("EXCEL_IMPORT:PROC_CODE").isNullOrEmpty() == false)
                {
                    while (sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT:PROC_CODE").ToString()].Cells[nRow].Value.isNullOrEmpty() == false)
                    {

                        this._ExcelFileLoadThread.SetCount(cnt);

                        DataRow ecRow = ecData.NewRow();

                        ecRow["SEL"] = "0";
                        ecRow["OVERWRITE"] = "0";



                        if (acVerticalGrid1.GetCellValue("EXCEL_IMPORT:LPROC_CODE").isNullOrEmpty() == false)
                        {
                            object code = acPlan.GetCodeByName(sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT:LPROC_CODE").ToString()].Cells[nRow].Value);

                            ecRow["LPROC_CODE"] = code;

                            if (code != null)
                            {
                                ecRow["LPROC_NAME"] = sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT:LPROC_CODE").ToString()].Cells[nRow].Value;
                            }
                        }


                        if (acVerticalGrid1.GetCellValue("EXCEL_IMPORT:MPROC_CODE").isNullOrEmpty() == false)
                        {
                            object code = acPlan.GetCodeByName(sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT:MPROC_CODE").ToString()].Cells[nRow].Value);

                            ecRow["MPROC_CODE"] = code;

                            if (code != null)
                            {
                                ecRow["MPROC_NAME"] = sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT:MPROC_CODE").ToString()].Cells[nRow].Value;
                            }
                        }


                        if (acVerticalGrid1.GetCellValue("EXCEL_IMPORT:PROC_CODE").isNullOrEmpty() == false)
                        {
                            ecRow["PROC_CODE"] = sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT:PROC_CODE").ToString()].Cells[nRow].Value;
                        }


                        if (acVerticalGrid1.GetCellValue("EXCEL_IMPORT:PROC_NAME").isNullOrEmpty() == false)
                        {
                            ecRow["PROC_NAME"] = sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT:PROC_NAME").ToString()].Cells[nRow].Value;
                        }


                        if (acVerticalGrid1.GetCellValue("EXCEL_IMPORT:PROC_COLOR").isNullOrEmpty() == false)
                        {

                            ecRow["PROC_COLOR"] = acColorEdit.FromName(sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT:PROC_COLOR").ToString()].Cells[nRow].Value.toStringNull()).ToArgb();


                        }



                        if (acVerticalGrid1.GetCellValue("EXCEL_IMPORT:INS_FLAG").isNullOrEmpty() == false)
                        {
                            ecRow["INS_FLAG"] = acInfo.StdCodes.GetCodeByName("S063", sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT:INS_FLAG").ToString()].Cells[nRow].Value);
                        }

                        if (acVerticalGrid1.GetCellValue("EXCEL_IMPORT:PROC_MAN_TIME").isNullOrEmpty() == false)
                        {
                            ecRow["PROC_MAN_TIME"] = sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT:PROC_MAN_TIME").ToString()].Cells[nRow].Value.toDecimal();
                        }

                        if (acVerticalGrid1.GetCellValue("EXCEL_IMPORT:PROC_SELF_TIME").isNullOrEmpty() == false)
                        {
                            ecRow["PROC_SELF_TIME"] = sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT:PROC_SELF_TIME").ToString()].Cells[nRow].Value.toDecimal();
                        }

                        if (acVerticalGrid1.GetCellValue("EXCEL_IMPORT:IS_OS").isNullOrEmpty() == false)
                        {
                            ecRow["IS_OS"] = sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT:IS_OS").ToString()].Cells[nRow].Value;
                        }

                        if (acVerticalGrid1.GetCellValue("EXCEL_IMPORT:IS_BOP_PROC").isNullOrEmpty() == false)
                        {
                            ecRow["IS_BOP_PROC"] = sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT:IS_BOP_PROC").ToString()].Cells[nRow].Value;
                        }

                        if (acVerticalGrid1.GetCellValue("EXCEL_IMPORT:WO_DEFAULT_OSMC").isNullOrEmpty() == false)
                        {
                            object code = acMachine.GetCodeByName(sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT:WO_DEFAULT_OSMC").ToString()].Cells[nRow].Value);

                            ecRow["WO_DEFAULT_OSMC"] = code;

                            if (code != null)
                            {
                                ecRow["WO_DEFAULT_OSMC_NAME"] = sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT:WO_DEFAULT_OSMC").ToString()].Cells[nRow].Value;
                            }
                        }


                        if (acVerticalGrid1.GetCellValue("EXCEL_IMPORT:CPROC_CODE").isNullOrEmpty() == false)
                        {
                            object code = acWageRate.GetCodeByName(sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT:CPROC_CODE").ToString()].Cells[nRow].Value);

                            ecRow["CPROC_CODE"] = code;

                            if (code != null)
                            {
                                ecRow["CPROC_NAME"] = sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT:CPROC_CODE").ToString()].Cells[nRow].Value;
                            }
                        }

                        if (acVerticalGrid1.GetCellValue("EXCEL_IMPORT:MAIN_VND").isNullOrEmpty() == false)
                        {
                            object code = acVendor.GetCodeByName(sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT:MAIN_VND").ToString()].Cells[nRow].Value);

                            ecRow["MAIN_VND"] = code;

                            if (code != null)
                            {
                                ecRow["MAIN_VND_NAME"] = sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT:MAIN_VND").ToString()].Cells[nRow].Value;
                            }
                        }


                        if (acVerticalGrid1.GetCellValue("EXCEL_IMPORT:ACT_CODE").isNullOrEmpty() == false)
                        {
                            ecRow["ACT_CODE"] = acInfo.StdCodes.GetCodeByName("C600", sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT:ACT_CODE").ToString()].Cells[nRow].Value);
                        }


                        if (acVerticalGrid1.GetCellValue("EXCEL_IMPORT:PROC_SEQ").isNullOrEmpty() == false)
                        {
                            ecRow["PROC_SEQ"] = sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT:PROC_SEQ").ToString()].Cells[nRow].Value.toInt();
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

                frm.View.AddTextEdit("KEY", "공정코드", "40920", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

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
                paramTable.Columns.Add("PROC_CODE", typeof(String)); //
                paramTable.Columns.Add("PROC_NAME", typeof(String)); //
                paramTable.Columns.Add("MPROC_CODE", typeof(String)); //
                paramTable.Columns.Add("LPROC_CODE", typeof(String)); //

                paramTable.Columns.Add("PROC_SEQ", typeof(Int32)); //
                paramTable.Columns.Add("PROC_COLOR", typeof(String)); //
                paramTable.Columns.Add("PROC_MAN_TIME", typeof(Single)); //
                paramTable.Columns.Add("PROC_SELF_TIME", typeof(Single)); //
                paramTable.Columns.Add("CPROC_CODE", typeof(String)); //
                paramTable.Columns.Add("WO_DEFAULT_OSMC", typeof(String)); //
                paramTable.Columns.Add("IS_OS", typeof(Byte)); //

                paramTable.Columns.Add("IS_BOP_PROC", typeof(Byte)); //
                paramTable.Columns.Add("INS_FLAG", typeof(String)); //
                paramTable.Columns.Add("MAIN_VND", typeof(String)); //

                paramTable.Columns.Add("ACT_CODE", typeof(String)); //

                paramTable.Columns.Add("REG_EMP", typeof(String)); //
                paramTable.Columns.Add("OVERWRITE", typeof(String)); //덮어쓰기 여부


                DataView view = acGridView2.GetDataSourceView("SEL = '1'");

                foreach (DataRowView rv in view)
                {

                    DataRow row = rv.Row;

                    DataRow paramRow = paramTable.NewRow();
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["PROC_CODE"] = row["PROC_CODE"];
                    paramRow["PROC_NAME"] = row["PROC_NAME"];
                    paramRow["MPROC_CODE"] = row["MPROC_CODE"];
                    paramRow["LPROC_CODE"] = row["LPROC_CODE"];

                    paramRow["PROC_SEQ"] = row["PROC_SEQ"];
                    paramRow["PROC_COLOR"] = row["PROC_COLOR"];
                    paramRow["PROC_MAN_TIME"] = row["PROC_MAN_TIME"];
                    paramRow["PROC_SELF_TIME"] = row["PROC_SELF_TIME"];
                    paramRow["CPROC_CODE"] = row["CPROC_CODE"];
                    paramRow["WO_DEFAULT_OSMC"] = row["WO_DEFAULT_OSMC"];


                    paramRow["IS_BOP_PROC"] = row["IS_BOP_PROC"];
                    paramRow["INS_FLAG"] = row["INS_FLAG"];

                    paramRow["IS_OS"] = row["IS_OS"];
                    paramRow["MAIN_VND"] = row["MAIN_VND"];
                    paramRow["ACT_CODE"] = row["ACT_CODE"];

                    paramRow["REG_EMP"] = acInfo.UserID;
                    paramRow["OVERWRITE"] = row["OVERWRITE"];
                    paramTable.Rows.Add(paramRow);


                }


                if (paramTable.Rows.Count != 0)
                {
                    DataSet paramSet = new DataSet();
                    paramSet.Tables.Add(paramTable);

                    BizRun.QBizRun.ExecuteService(
                    this, QBiz.emExecuteType.PROCESS, "STD41A_INS3", paramSet, "RQSTDT,RQSTDT2", "RSLTDT",
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
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }



    }
}