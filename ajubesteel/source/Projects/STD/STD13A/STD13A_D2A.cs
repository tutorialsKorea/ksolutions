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
    public sealed partial class STD13A_D2A : BaseMenuDialog
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
        public STD13A_D2A()
        {
            InitializeComponent();



            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT::STARTROW", "시작행", "R309968V", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NUMERIC);

            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT::ORG_CODE", "부서", "40221", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT::EMP_CODE", "사원코드", "UV9LGK3D", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT::EMP_NAME", "사원명", "40266", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT::EMP_TYPE", "사원형태", "U2V6VABY", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT::EMP_TITLE", "직책", "72MOO4VJ", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT::CPROC_CODE", "임률", "40505", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT::USRGRP_CODE", "사용자 그룹", "40263", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT::MOBILE_PHONE", "휴대폰", "0SRN1JQ9", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT::EMAIL", "E-Mail", "40790", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT::EMP_SEQ", "표시순서", "40723", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);





            acGridView2.GridType = acGridView.emGridType.SEARCH;


            acGridView2.AddCheckEdit("SEL", "선택", "40290", true, true, true, acGridView.emCheckEditDataType._STRING);

            acGridView2.AddCheckEdit("OVERWRITE", "덮어쓰기", "QJJIK4V9", true, true, true, acGridView.emCheckEditDataType._STRING);


            acGridView2.AddHidden("ORG_CODE", typeof(string));

            acGridView2.AddCustomEdit("ORG_NAME", "부서", "40221", true, DevExpress.Utils.HorzAlignment.Center, true, true, false, new RepositoryItemORG());

            acGridView2.Columns["ORG_NAME"].ColumnEdit.EditValueChanged += new EventHandler(ORG_NAME_EditValueChanged);

            acGridView2.AddTextEdit("EMP_CODE", "사원코드", "UV9LGK3D", true, DevExpress.Utils.HorzAlignment.Center, true, true, true, acGridView.emTextEditMask.NONE);

            acGridView2.AddTextEdit("EMP_NAME", "사원명", "40266", true, DevExpress.Utils.HorzAlignment.Center, true, true, true, acGridView.emTextEditMask.NONE);

            acGridView2.AddLookUpEdit("EMP_TYPE", "사원형태", "U2V6VABY", true, DevExpress.Utils.HorzAlignment.Center, true, true, true, "S021");

            acGridView2.AddLookUpEdit("EMP_TITLE", "직책", "72MOO4VJ", true, DevExpress.Utils.HorzAlignment.Center, true, true, false, "C040");

            acGridView2.AddHidden("CPROC_CODE", typeof(string));

            acGridView2.AddCustomEdit("CPROC_NAME", "임률", "40505", true, DevExpress.Utils.HorzAlignment.Center, true, true, false, new RepositoryItemWageRate());

            acGridView2.Columns["CPROC_NAME"].ColumnEdit.EditValueChanged += new EventHandler(CPROC_NAME_EditValueChanged);

            acGridView2.AddHidden("USRGRP_CODE", typeof(string));

            acGridView2.AddCustomEdit("USRGRP_NAME", "사용자 그룹", "40263", true, DevExpress.Utils.HorzAlignment.Center, true, true, true, new RepositoryItemUserGroup());

            acGridView2.Columns["USRGRP_NAME"].ColumnEdit.EditValueChanged += new EventHandler(USRGRP_NAME_EditValueChanged);

            acGridView2.AddTextEdit("MOBILE_PHONE", "휴대폰", "0SRN1JQ9", true, DevExpress.Utils.HorzAlignment.Center, true, true, false, acGridView.emTextEditMask.NONE);


            acGridView2.AddTextEdit("EMAIL", "E-Mail", "40790", true, DevExpress.Utils.HorzAlignment.Center, true, true, false, acGridView.emTextEditMask.NONE);


            acGridView2.AddTextEdit("EMP_SEQ", "표시순서", "40723", true, DevExpress.Utils.HorzAlignment.Far, true, true, false, acGridView.emTextEditMask.NONE);

        }

        void USRGRP_NAME_EditValueChanged(object sender, EventArgs e)
        {
            //사용자그룹 변경

            acGridView2.EndEditor();

            acUserGroup editor = sender as acUserGroup;

            DataRow focusRow = acGridView2.GetFocusedDataRow();

            focusRow["USRGRP_CODE"] = editor.Value;

        }

        void CPROC_NAME_EditValueChanged(object sender, EventArgs e)
        {
            //임률 변경

            acGridView2.EndEditor();

            acWageRate editor = sender as acWageRate;

            DataRow focusRow = acGridView2.GetFocusedDataRow();

            focusRow["CPROC_CODE"] = editor.Value;

        }

        void ORG_NAME_EditValueChanged(object sender, EventArgs e)
        {
            //부서 변경

            acGridView2.EndEditor();

            acORG editor = sender as acORG;

            DataRow focusRow = acGridView2.GetFocusedDataRow();

            focusRow["ORG_CODE"] = editor.Value;

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
                int nRow = acVerticalGrid1.GetCellValue("EXCEL_IMPORT::STARTROW").toInt() - 1;

                DataTable ecData = acGridView2.NewTable();

                int cnt = 0;

                if (acVerticalGrid1.GetCellValue("EXCEL_IMPORT::EMP_CODE").isNullOrEmpty() == false)
                {
                    while (sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT::EMP_CODE").ToString()].Cells[nRow].Value.isNullOrEmpty() == false)
                    {

                        this._ExcelFileLoadThread.SetCount(cnt);

                        DataRow ecRow = ecData.NewRow();

                        ecRow["SEL"] = "0";
                        ecRow["OVERWRITE"] = "0";


                        if (acVerticalGrid1.GetCellValue("EXCEL_IMPORT::ORG_CODE").isNullOrEmpty() == false)
                        {
                            object code = acORG.GetCodeByName(sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT::ORG_CODE").ToString()].Cells[nRow].Value);


                            ecRow["ORG_CODE"] = code;

                            if (code != null)
                            {
                                ecRow["ORG_NAME"] = sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT::ORG_CODE").ToString()].Cells[nRow].Value;
                            }
                        }


                        if (acVerticalGrid1.GetCellValue("EXCEL_IMPORT::EMP_CODE").isNullOrEmpty() == false)
                        {
                            ecRow["EMP_CODE"] = sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT::EMP_CODE").ToString()].Cells[nRow].Value;
                        }


                        if (acVerticalGrid1.GetCellValue("EXCEL_IMPORT::EMP_NAME").isNullOrEmpty() == false)
                        {
                            ecRow["EMP_NAME"] = sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT::EMP_NAME").ToString()].Cells[nRow].Value;
                        }


                        if (acVerticalGrid1.GetCellValue("EXCEL_IMPORT::EMP_TYPE").isNullOrEmpty() == false)
                        {
                            ecRow["EMP_TYPE"] = acInfo.StdCodes.GetCodeByName("S021", sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT::EMP_TYPE").ToString()].Cells[nRow].Value);
                        }


                        if (acVerticalGrid1.GetCellValue("EXCEL_IMPORT::EMP_TITLE").isNullOrEmpty() == false)
                        {
                            ecRow["EMP_TITLE"] = acInfo.StdCodes.GetCodeByName("C040", sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT::EMP_TITLE").ToString()].Cells[nRow].Value);
                        }



                        if (acVerticalGrid1.GetCellValue("EXCEL_IMPORT::CPROC_CODE").isNullOrEmpty() == false)
                        {
                            object code = acWageRate.GetCodeByName(sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT::CPROC_CODE").ToString()].Cells[nRow].Value);


                            ecRow["CPROC_CODE"] = code;

                            if (code != null)
                            {
                                ecRow["CPROC_NAME"] = sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT::CPROC_CODE").ToString()].Cells[nRow].Value;
                            }
                        }


                        if (acVerticalGrid1.GetCellValue("EXCEL_IMPORT::USRGRP_CODE").isNullOrEmpty() == false)
                        {
                            object code = acUserGroup.GetCodeByName(sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT::USRGRP_CODE").ToString()].Cells[nRow].Value);


                            ecRow["USRGRP_CODE"] = code;

                            if (code != null)
                            {
                                ecRow["USRGRP_NAME"] = sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT::USRGRP_CODE").ToString()].Cells[nRow].Value;
                            }
                        }



                        if (acVerticalGrid1.GetCellValue("EXCEL_IMPORT::MOBILE_PHONE").isNullOrEmpty() == false)
                        {
                            ecRow["MOBILE_PHONE"] = sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT::MOBILE_PHONE").ToString()].Cells[nRow].Value;
                        }



                        if (acVerticalGrid1.GetCellValue("EXCEL_IMPORT::EMAIL").isNullOrEmpty() == false)
                        {
                            ecRow["EMAIL"] = sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT::EMAIL").ToString()].Cells[nRow].Value;
                        }


                        if (acVerticalGrid1.GetCellValue("EXCEL_IMPORT::EMP_SEQ").isNullOrEmpty() == false)
                        {
                            ecRow["EMP_SEQ"] = sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT::EMP_SEQ").ToString()].Cells[nRow].Value.toInt();
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

                frm.View.AddTextEdit("KEY", "사원코드", "UV9LGK3D", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

                frm.ShowDialog();



            }
            else if (ex.ErrNumber == 100022)
            {
                //시스템 예약어는 사원코드로 쓸수없음

                acMessageBoxGridConfirm frm = new acMessageBoxGridConfirm(this, "acMessageBoxGridConfirm1", acInfo.BizError.GetDesc(ex.ErrNumber), string.Empty, false, this.Caption, ex.ParameterData);

                frm.View.GridType = ControlManager.acGridView.emGridType.FIXED;

                frm.View.AddTextEdit("EMP_CODE", "사원코드", "UV9LGK3D", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);


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
                paramTable.Columns.Add("EMP_CODE", typeof(String)); //
                paramTable.Columns.Add("EMP_NAME", typeof(String)); //
                paramTable.Columns.Add("EMP_TYPE", typeof(String)); //
                paramTable.Columns.Add("EMP_TITLE", typeof(String)); //
                paramTable.Columns.Add("EMP_SEQ", typeof(Int32)); //
                paramTable.Columns.Add("ORG_CODE", typeof(String)); //
                paramTable.Columns.Add("CPROC_CODE", typeof(String)); //
                paramTable.Columns.Add("USRGRP_CODE", typeof(String)); //
                paramTable.Columns.Add("EMAIL", typeof(String)); //
                paramTable.Columns.Add("MOBILE_PHONE", typeof(String)); //
                paramTable.Columns.Add("IS_VND", typeof(Byte)); //
                paramTable.Columns.Add("REG_EMP", typeof(String)); //
                paramTable.Columns.Add("OVERWRITE", typeof(String)); //덮어쓰기 여부


                DataView view = acGridView2.GetDataSourceView("SEL = '1'");

                foreach (DataRowView rv in view)
                {

                    DataRow row = rv.Row;

                    DataRow paramRow = paramTable.NewRow();
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["EMP_CODE"] = row["EMP_CODE"];
                    paramRow["EMP_NAME"] = row["EMP_NAME"];
                    paramRow["EMP_TYPE"] = row["EMP_TYPE"];
                    paramRow["EMP_TITLE"] = row["EMP_TITLE"];
                    paramRow["EMP_SEQ"] = row["EMP_SEQ"];
                    paramRow["ORG_CODE"] = row["ORG_CODE"];
                    paramRow["CPROC_CODE"] = row["CPROC_CODE"];
                    paramRow["USRGRP_CODE"] = row["USRGRP_CODE"];
                    paramRow["EMAIL"] = row["EMAIL"];
                    paramRow["MOBILE_PHONE"] = row["MOBILE_PHONE"];
                    paramRow["IS_VND"] = 0;
                    paramRow["REG_EMP"] = acInfo.UserID;
                    paramRow["OVERWRITE"] = row["OVERWRITE"];
                    paramTable.Rows.Add(paramRow);


                }


                if (paramTable.Rows.Count != 0)
                {
                    DataSet paramSet = new DataSet();
                    paramSet.Tables.Add(paramTable);

                    BizRun.QBizRun.ExecuteService(
                    this, QBiz.emExecuteType.PROCESS, "STD13A_INS2", paramSet, "RQSTDT", "RSLTDT",
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