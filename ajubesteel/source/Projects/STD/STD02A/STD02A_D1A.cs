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
    public sealed partial class STD02A_D1A : BaseMenuDialog
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
        public STD02A_D1A()
        {
            InitializeComponent();


            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:SHEET", "시트", "LBG894M9", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);

            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:STARTROW", "시작행", "R309968V", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NUMERIC);

            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:PART_CODE", "부품코드", "40239", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:PART_NAME", "부품명", "40234", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:STD_PT_NUM", "품번", "40743", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:MAT_LTYPE", "대분류", "40132", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:MAT_MTYPE", "중분류", "40630", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:MAT_STYPE", "소분류", "40338", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:PART_ENAME", "부품명(영문)", "40235", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:PART_PRODTYPE", "부품제작구분", "40238", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:MAT_UNIT", "단위", "40123", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:STK_MNG", "재고관리", "F0A4HGPZ", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:STK_LOCATION", "창고", "NO1T1YEG", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:SAFE_STK_QTY", "안전재고수량", "SJVKEWA8", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);




            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:SPEC_TYPE", "규격입력형태", "42540", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:MAT_SPEC", "소재사양", "42544", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:MAT_SPEC1", "완성사양", "42545", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);


            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:AUTO_CREATE", "자동생성", "9ICKPDNH", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:AUTO_MARGIN", "자동여유사양", "0DRK00FJ", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:AUTO_MARGIN_SPEC", "여유사양", "1AW7AFGL", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);


            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:LOAD_FLAG", "BOP 부품", "M920A2XO", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:SCH_METHOD", "스케줄 방법", "42462", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:MAT_TYPE", "자재형태", "N05MMEKM", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);


            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:MAIN_VND", "기본 거래처", "UHQZT510", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:MAT_QLTY", "재질", "7QEYM43V", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:INS_FLAG", "입고검사여부", "42560", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);


            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:MAT_COST", "단가", "40121", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:ACT_CODE", "회계계정", "42569", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:PART_SEQ", "표시순서", "40723", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:SCOMMENT", "비고", "ARYZ726K", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);








            acGridView2.GridType = acGridView.emGridType.SEARCH;


            acGridView2.AddCheckEdit("SEL", "선택", "40290", true, true, true, acGridView.emCheckEditDataType._STRING);

            acGridView2.AddCheckEdit("OVERWRITE", "덮어쓰기", "QJJIK4V9", true, true, true, acGridView.emCheckEditDataType._STRING);

            acGridView2.AddTextEdit("PART_CODE", "부품코드", "40239", true, DevExpress.Utils.HorzAlignment.Center, true, true, true, acGridView.emTextEditMask.NONE);

            acGridView2.AddTextEdit("PART_NAME", "부품명", "40234", true, DevExpress.Utils.HorzAlignment.Center, true, true, true, acGridView.emTextEditMask.NONE);

            acGridView2.AddTextEdit("STD_PT_NUM", "품번", "40743", true, DevExpress.Utils.HorzAlignment.Center, true, true, false, acGridView.emTextEditMask.NONE);

            acGridView2.AddLookUpEdit("MAT_LTYPE", "대분류", "40132", true, DevExpress.Utils.HorzAlignment.Center, true, true, false, "M014");

            acGridView2.AddLookUpEdit("MAT_MTYPE", "중분류", "40630", true, DevExpress.Utils.HorzAlignment.Center, true, true, false, "M015");

            acGridView2.AddLookUpEdit("MAT_STYPE", "소분류", "40338", true, DevExpress.Utils.HorzAlignment.Center, true, true, false, "M016");

            acGridView2.AddTextEdit("PART_ENAME", "부품명(영문)", "40235", true, DevExpress.Utils.HorzAlignment.Center, true, true, false, acGridView.emTextEditMask.NONE);

            acGridView2.AddLookUpEdit("PART_PRODTYPE", "부품제작구분", "40238", true, DevExpress.Utils.HorzAlignment.Center, true, true, false, "M007");

            acGridView2.AddLookUpEdit("MAT_UNIT", "단위", "40123", true, DevExpress.Utils.HorzAlignment.Center, true, true, false, "M003");

            acGridView2.AddCheckEdit("STK_MNG", "재고관리", "F0A4HGPZ", true, true, true, acGridView.emCheckEditDataType._STRING);


            acGridView2.AddLookUpEdit("STK_LOCATION", "창고", "NO1T1YEG", true, DevExpress.Utils.HorzAlignment.Center, true, true, true, "M005");

            acGridView2.AddTextEdit("SAFE_STK_QTY", "안전재고수량", "SJVKEWA8", true, DevExpress.Utils.HorzAlignment.Far, true, true, true, acGridView.emTextEditMask.QTY);






            acGridView2.AddLookUpEdit("SPEC_TYPE", "규격입력형태", "42540", true, DevExpress.Utils.HorzAlignment.Center, true, true, true, "S062");

            acGridView2.Columns["SPEC_TYPE"].ColumnEdit.EditValueChanged += new EventHandler(SPEC_TYPE_EditValueChanged);


            acGridView2.AddCustomEdit("MAT_SPEC", "소재사양", "42544", true, DevExpress.Utils.HorzAlignment.Near, true, true, false, new RepositoryItemPartSpecTypeEdit());

            (acGridView2.Columns["MAT_SPEC"].ColumnEdit as RepositoryItemPartSpecTypeEdit).ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(SPEC_ButtonClick);

            acGridView2.AddCustomEdit("MAT_SPEC1", "완성사양", "42545", true, DevExpress.Utils.HorzAlignment.Near, true, true, false, new RepositoryItemPartSpecTypeEdit());

            (acGridView2.Columns["MAT_SPEC1"].ColumnEdit as RepositoryItemPartSpecTypeEdit).ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(SPEC_ButtonClick);

            acGridView2.AddCheckEdit("AUTO_CREATE", "자동생성", "9ICKPDNH", true, true, true, acGridView.emCheckEditDataType._STRING);

            acGridView2.AddCheckEdit("AUTO_MARGIN", "자동여유사양", "0DRK00FJ", true, true, true, acGridView.emCheckEditDataType._STRING);


            acGridView2.AddCustomEdit("AUTO_MARGIN_SPEC", "여유사양", "1AW7AFGL", true, DevExpress.Utils.HorzAlignment.Near, true, true, false, new RepositoryItemPartSpecTypeEdit());

            (acGridView2.Columns["AUTO_MARGIN_SPEC"].ColumnEdit as RepositoryItemPartSpecTypeEdit).ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(SPEC_ButtonClick);




            acGridView2.AddLookUpEdit("LOAD_FLAG", "BOP 부품", "M920A2XO", true, DevExpress.Utils.HorzAlignment.Center, true, true, true, "S024");

            acGridView2.AddLookUpEdit("SCH_METHOD", "스케줄 방법", "42462", true, DevExpress.Utils.HorzAlignment.Center, true, true, true, "S060");

            acGridView2.AddLookUpEdit("MAT_TYPE", "자재형태", "N05MMEKM", true, DevExpress.Utils.HorzAlignment.Center, true, true, true, "S016");


            acGridView2.AddHidden("MAIN_VND", typeof(string));

            acGridView2.AddCustomEdit("MAIN_VND_NAME", "기본 거래처", "UHQZT510", true, DevExpress.Utils.HorzAlignment.Near, true, true, false, new RepositoryItemVendor());

            acGridView2.Columns["MAIN_VND_NAME"].ColumnEdit.EditValueChanged += new EventHandler(MAIN_VND_NAME_EditValueChanged);

            acGridView2.AddHidden("MAT_QLTY", typeof(string));

            acGridView2.AddCustomEdit("MAT_QLTY_NAME", "재질", "7QEYM43V", true, DevExpress.Utils.HorzAlignment.Near, true, true, false, new RepositoryItemMaterial());

            acGridView2.Columns["MAT_QLTY_NAME"].ColumnEdit.EditValueChanged += new EventHandler(MAT_QLTY_NAME_EditValueChanged);

            acGridView2.AddLookUpEdit("INS_FLAG", "입고검사여부", "42560", true, DevExpress.Utils.HorzAlignment.Center, true, true, true, "S063");


            acGridView2.AddTextEdit("MAT_COST", "단가", "40121", true, DevExpress.Utils.HorzAlignment.Far, true, true, false, acGridView.emTextEditMask.MONEY);

            acGridView2.AddLookUpEdit("ACT_CODE", "회계계정", "42569", true, DevExpress.Utils.HorzAlignment.Center, true, true, false, "C600");



            acGridView2.AddTextEdit("PART_SEQ", "표시순서", "40723", true, DevExpress.Utils.HorzAlignment.Far, true, true, false, acGridView.emTextEditMask.NONE);

            acGridView2.AddTextEdit("SCOMMENT", "비고", "ARYZ726K", true, DevExpress.Utils.HorzAlignment.Near, true, true, false, acGridView.emTextEditMask.NONE);

        }


        void SPEC_TYPE_EditValueChanged(object sender, EventArgs e)
        {
            acGridView2.EndEditor();

            DataRow focusRow = acGridView2.GetFocusedDataRow();

            focusRow["MAT_SPEC"] = DBNull.Value;
            focusRow["MAT_SPEC1"] = DBNull.Value;
            focusRow["AUTO_MARGIN_SPEC"] = DBNull.Value;

        }

        void SPEC_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {

            acPartSpecTypePopupEdit edit = sender as acPartSpecTypePopupEdit;

            acGridView view = (edit.Parent as acGridControl).MainView as acGridView;

            DataRow focusRow = view.GetFocusedDataRow();

            edit.SpecType = focusRow["SPEC_TYPE"];

            edit.GridView = view;

        }

        void MAIN_VND_NAME_EditValueChanged(object sender, EventArgs e)
        {
            //기본거래처 변경

            acGridView2.EndEditor();

            acVendor editor = sender as acVendor;

            DataRow focusRow = acGridView2.GetFocusedDataRow();

            focusRow["MAIN_VND"] = editor.Value;

        }

        void MAT_QLTY_NAME_EditValueChanged(object sender, EventArgs e)
        {
            //재질 변경

            acGridView2.EndEditor();

            acMaterial editor = sender as acMaterial;

            DataRow focusRow = acGridView2.GetFocusedDataRow();

            focusRow["MAT_QLTY"] = editor.Value;

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

                if (acVerticalGrid1.GetCellValue("EXCEL_IMPORT:PART_CODE").isNullOrEmpty() == false)
                {
                    while (sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT:PART_CODE").ToString()].Cells[nRow].Value.isNullOrEmpty() == false)
                    {

                        this._ExcelFileLoadThread.SetCount(cnt);

                        DataRow ecRow = ecData.NewRow();

                        ecRow["SEL"] = "0";
                        ecRow["OVERWRITE"] = "0";


                        //부품

                        if (acVerticalGrid1.GetCellValue("EXCEL_IMPORT:PART_CODE").isNullOrEmpty() == false)
                        {
                            ecRow["PART_CODE"] = sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT:PART_CODE").ToString()].Cells[nRow].Value;
                        }


                        if (acVerticalGrid1.GetCellValue("EXCEL_IMPORT:PART_NAME").isNullOrEmpty() == false)
                        {
                            ecRow["PART_NAME"] = sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT:PART_NAME").ToString()].Cells[nRow].Value;
                        }


                        if (acVerticalGrid1.GetCellValue("EXCEL_IMPORT:STD_PT_NUM").isNullOrEmpty() == false)
                        {
                            ecRow["STD_PT_NUM"] = sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT:STD_PT_NUM").ToString()].Cells[nRow].Value.toStringEmpty();
                        }


                        if (acVerticalGrid1.GetCellValue("EXCEL_IMPORT:MAT_LTYPE").isNullOrEmpty() == false)
                        {
                            ecRow["MAT_LTYPE"] = acInfo.StdCodes.GetCodeByName("M001", sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT:MAT_LTYPE").ToString()].Cells[nRow].Value);
                        }

                        if (acVerticalGrid1.GetCellValue("EXCEL_IMPORT:MAT_MTYPE").isNullOrEmpty() == false)
                        {
                            ecRow["MAT_MTYPE"] = acInfo.StdCodes.GetCodeByName("M002", sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT:MAT_MTYPE").ToString()].Cells[nRow].Value);
                        }

                        if (acVerticalGrid1.GetCellValue("EXCEL_IMPORT:MAT_STYPE").isNullOrEmpty() == false)
                        {
                            ecRow["MAT_STYPE"] = acInfo.StdCodes.GetCodeByName("M008", sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT:MAT_STYPE").ToString()].Cells[nRow].Value);
                        }


                        if (acVerticalGrid1.GetCellValue("EXCEL_IMPORT:PART_ENAME").isNullOrEmpty() == false)
                        {
                            ecRow["PART_ENAME"] = sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT:PART_ENAME").ToString()].Cells[nRow].Value;
                        }


                        if (acVerticalGrid1.GetCellValue("EXCEL_IMPORT:STK_MNG").isNullOrEmpty() == false)
                        {
                            ecRow["STK_MNG"] = sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT:STK_MNG").ToString()].Cells[nRow].Value;
                        }

                        if (acVerticalGrid1.GetCellValue("EXCEL_IMPORT:STK_LOCATION").isNullOrEmpty() == false)
                        {
                            ecRow["STK_LOCATION"] = acInfo.StdCodes.GetCodeByName("M005", sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT:STK_LOCATION").ToString()].Cells[nRow].Value);
                        }

                        if (acVerticalGrid1.GetCellValue("EXCEL_IMPORT:SAFE_STK_QTY").isNullOrEmpty() == false)
                        {
                            ecRow["SAFE_STK_QTY"] = sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT:SAFE_STK_QTY").ToString()].Cells[nRow].Value.toDecimal();
                        }

                        if (acVerticalGrid1.GetCellValue("EXCEL_IMPORT:PART_PRODTYPE").isNullOrEmpty() == false)
                        {
                            ecRow["PART_PRODTYPE"] = acInfo.StdCodes.GetCodeByName("M007", sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT:PART_PRODTYPE").ToString()].Cells[nRow].Value);
                        }


                        if (acVerticalGrid1.GetCellValue("EXCEL_IMPORT:MAT_QLTY").isNullOrEmpty() == false)
                        {
                            object matQlty = acMaterial.GetCodeByName(sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT:MAT_QLTY").ToString()].Cells[nRow].Value);


                            ecRow["MAT_QLTY"] = matQlty;

                            if (matQlty != null)
                            {
                                ecRow["MAT_QLTY_NAME"] = sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT:MAT_QLTY").ToString()].Cells[nRow].Value;
                            }
                        }


                        if (acVerticalGrid1.GetCellValue("EXCEL_IMPORT:MAT_UNIT").isNullOrEmpty() == false)
                        {
                            ecRow["MAT_UNIT"] = acInfo.StdCodes.GetCodeByName("M003", sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT:MAT_UNIT").ToString()].Cells[nRow].Value);
                        }


                        if (acVerticalGrid1.GetCellValue("EXCEL_IMPORT:SPEC_TYPE").isNullOrEmpty() == false)
                        {
                            ecRow["SPEC_TYPE"] = acInfo.StdCodes.GetCodeByName("S062", sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT:SPEC_TYPE").ToString()].Cells[nRow].Value);
                        }


                        if (acVerticalGrid1.GetCellValue("EXCEL_IMPORT:MAT_SPEC").isNullOrEmpty() == false)
                        {
                            ecRow["MAT_SPEC"] = sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT:MAT_SPEC").ToString()].Cells[nRow].Value;
                        }

                        if (acVerticalGrid1.GetCellValue("EXCEL_IMPORT:MAT_SPEC1").isNullOrEmpty() == false)
                        {
                            ecRow["MAT_SPEC1"] = sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT:MAT_SPEC1").ToString()].Cells[nRow].Value;
                        }


                        if (acVerticalGrid1.GetCellValue("EXCEL_IMPORT:AUTO_CREATE").isNullOrEmpty() == false)
                        {
                            ecRow["AUTO_CREATE"] = sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT:AUTO_CREATE").ToString()].Cells[nRow].Value;
                        }


                        if (acVerticalGrid1.GetCellValue("EXCEL_IMPORT:AUTO_MARGIN").isNullOrEmpty() == false)
                        {
                            ecRow["AUTO_MARGIN"] = sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT:AUTO_MARGIN").ToString()].Cells[nRow].Value;
                        }

                        if (acVerticalGrid1.GetCellValue("EXCEL_IMPORT:AUTO_MARGIN_SPEC").isNullOrEmpty() == false)
                        {
                            ecRow["AUTO_MARGIN_SPEC"] = sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT:AUTO_MARGIN_SPEC").ToString()].Cells[nRow].Value;
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


                        if (acVerticalGrid1.GetCellValue("EXCEL_IMPORT:PART_SEQ").isNullOrEmpty() == false)
                        {
                            ecRow["PART_SEQ"] = sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT:PART_SEQ").ToString()].Cells[nRow].Value.toInt();
                        }



                        if (acVerticalGrid1.GetCellValue("EXCEL_IMPORT:INS_FLAG").isNullOrEmpty() == false)
                        {
                            ecRow["INS_FLAG"] = acInfo.StdCodes.GetCodeByName("S063", sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT:INS_FLAG").ToString()].Cells[nRow].Value);
                        }

                        if (acVerticalGrid1.GetCellValue("EXCEL_IMPORT:LOAD_FLAG").isNullOrEmpty() == false)
                        {
                            ecRow["LOAD_FLAG"] = acInfo.StdCodes.GetCodeByName("S024", sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT:LOAD_FLAG").ToString()].Cells[nRow].Value);
                        }

                        if (acVerticalGrid1.GetCellValue("EXCEL_IMPORT:SCH_METHOD").isNullOrEmpty() == false)
                        {
                            ecRow["SCH_METHOD"] = acInfo.StdCodes.GetCodeByName("S060", sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT:SCH_METHOD").ToString()].Cells[nRow].Value);
                        }


                        if (acVerticalGrid1.GetCellValue("EXCEL_IMPORT:MAT_TYPE").isNullOrEmpty() == false)
                        {
                            ecRow["MAT_TYPE"] = acInfo.StdCodes.GetCodeByName("S016", sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT:MAT_TYPE").ToString()].Cells[nRow].Value);
                        }


                        if (acVerticalGrid1.GetCellValue("EXCEL_IMPORT:MAT_COST").isNullOrEmpty() == false)
                        {
                            ecRow["MAT_COST"] = sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT:MAT_COST").ToString()].Cells[nRow].Value.toDecimal();
                        }


                        if (acVerticalGrid1.GetCellValue("EXCEL_IMPORT:ACT_CODE").isNullOrEmpty() == false)
                        {
                            ecRow["ACT_CODE"] = acInfo.StdCodes.GetCodeByName("C600", sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT:ACT_CODE").ToString()].Cells[nRow].Value);
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

                frm.View.AddTextEdit("KEY", "부품코드", "40239", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

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
                paramTable.Columns.Add("PART_CODE", typeof(String)); //
                paramTable.Columns.Add("PART_NAME", typeof(String)); //
                paramTable.Columns.Add("PART_ENAME", typeof(String)); //

                paramTable.Columns.Add("PART_SEQ", typeof(Int32)); //
                paramTable.Columns.Add("MAT_TYPE", typeof(String)); //
                paramTable.Columns.Add("PART_PRODTYPE", typeof(String)); //
                paramTable.Columns.Add("MAT_LTYPE", typeof(String)); //
                paramTable.Columns.Add("MAT_MTYPE", typeof(String)); //
                paramTable.Columns.Add("MAT_UNIT", typeof(String)); //
                paramTable.Columns.Add("MAT_COST", typeof(Decimal)); //
                paramTable.Columns.Add("MAT_QLTY", typeof(String)); //
                paramTable.Columns.Add("MAIN_VND", typeof(String)); //
                paramTable.Columns.Add("STD_PT_NUM", typeof(String)); //
                paramTable.Columns.Add("SCOMMENT", typeof(String)); //
                paramTable.Columns.Add("REG_EMP", typeof(String)); //
                paramTable.Columns.Add("SPEC_TYPE", typeof(String)); //
                paramTable.Columns.Add("MAT_STYPE", typeof(String)); //
                paramTable.Columns.Add("MAT_SPEC", typeof(String)); //
                paramTable.Columns.Add("MAT_SPEC1", typeof(String)); //
                paramTable.Columns.Add("SCH_METHOD", typeof(Byte)); //
                paramTable.Columns.Add("LOAD_FLAG", typeof(Byte)); //
                paramTable.Columns.Add("INS_FLAG", typeof(String)); //
                paramTable.Columns.Add("ACT_CODE", typeof(String)); //

                paramTable.Columns.Add("STK_LOCATION", typeof(String)); //
                paramTable.Columns.Add("SAFE_STK_QTY", typeof(Decimal)); //

                paramTable.Columns.Add("AUTO_CREATE", typeof(Byte)); //
                paramTable.Columns.Add("AUTO_MARGIN", typeof(Byte)); //
                paramTable.Columns.Add("AUTO_MARGIN_SPEC", typeof(String)); //

                paramTable.Columns.Add("STK_MNG", typeof(Byte)); //

                paramTable.Columns.Add("OVERWRITE", typeof(String)); //덮어쓰기 여부


                DataView view = acGridView2.GetDataSourceView("SEL = '1'");

                foreach (DataRowView rv in view)
                {

                    DataRow row = rv.Row;

                    DataRow paramRow = paramTable.NewRow();
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["PART_CODE"] = row["PART_CODE"];
                    paramRow["PART_NAME"] = row["PART_NAME"];
                    paramRow["STD_PT_NUM"] = row["STD_PT_NUM"];
                    paramRow["MAT_LTYPE"] = row["MAT_LTYPE"];
                    paramRow["MAT_MTYPE"] = row["MAT_MTYPE"];
                    paramRow["MAT_STYPE"] = row["MAT_STYPE"];
                    paramRow["PART_ENAME"] = row["PART_ENAME"];
                    paramRow["STK_LOCATION"] = row["STK_LOCATION"];
                    paramRow["SAFE_STK_QTY"] = row["SAFE_STK_QTY"];
                    paramRow["PART_PRODTYPE"] = row["PART_PRODTYPE"];
                    paramRow["MAT_QLTY"] = row["MAT_QLTY"];
                    paramRow["MAT_UNIT"] = row["MAT_UNIT"];
                    paramRow["SPEC_TYPE"] = row["SPEC_TYPE"];
                    paramRow["MAT_SPEC"] = row["MAT_SPEC"];
                    paramRow["MAT_SPEC1"] = row["MAT_SPEC1"];
                    paramRow["MAIN_VND"] = row["MAIN_VND"];
                    paramRow["PART_SEQ"] = row["PART_SEQ"];

                    paramRow["INS_FLAG"] = row["INS_FLAG"];
                    paramRow["LOAD_FLAG"] = row["LOAD_FLAG"].toByte();
                    paramRow["SCH_METHOD"] = row["SCH_METHOD"].toByte();
                    paramRow["MAT_TYPE"] = row["MAT_TYPE"];
                    paramRow["MAT_COST"] = row["MAT_COST"];
                    paramRow["ACT_CODE"] = row["ACT_CODE"];
                    paramRow["SCOMMENT"] = row["SCOMMENT"];

                    paramRow["AUTO_CREATE"] = row["AUTO_CREATE"].toByte();
                    paramRow["AUTO_MARGIN"] = row["AUTO_MARGIN"].toByte();
                    paramRow["AUTO_MARGIN_SPEC"] = row["AUTO_MARGIN_SPEC"];

                    paramRow["STK_MNG"] = row["STK_MNG"].toByte();

                    paramRow["REG_EMP"] = acInfo.UserID;
                    paramRow["OVERWRITE"] = row["OVERWRITE"];
                    paramTable.Rows.Add(paramRow);


                }


                if (paramTable.Rows.Count != 0)
                {
                    DataSet paramSet = new DataSet();
                    paramSet.Tables.Add(paramTable);

                    BizRun.QBizRun.ExecuteService(
                    this, QBiz.emExecuteType.PROCESS, "STD02A_INS", paramSet, "RQSTDT", "RSLTDT",
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