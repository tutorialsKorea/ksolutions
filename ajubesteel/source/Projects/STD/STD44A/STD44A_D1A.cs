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
    public sealed partial class STD44A_D1A : BaseMenuDialog
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
        public STD44A_D1A()
        {
            InitializeComponent();



            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT::STARTROW", "시작행", "R309968V", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NUMERIC);

            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT::MC_CODE", "설비코드", "41162", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT::MC_NAME", "설비명", "41202", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);


            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT::MC_GROUP", "설비그룹", "40308", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT::MC_MODEL", "실모델명", "40400", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT::MC_AUTOMATED", "무인가공", "40973", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT::MC_OS", "외부설비", "40974", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT::MC_MGT_FLAG", "부하 관리대상", "40065", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);


            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT::IS_OPERATE_STATE", "가동현황표시", "SR3IF2SN", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);


            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT::IS_MULTI_START", "다중작업지시 동시진행", "MQBVM2AJ", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT::MULTI_START_DIV", "다중작업지시 동시진행시 실적분할", "HTHN5WFV", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);


            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT::MC_OPEN_DATE", "유효시작일", "40477", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT::MC_CLOSE_DATE", "유효종료일", "40478", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT::MAIN_EMP", "담당자", "40127", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT::CPROC_CODE", "임률", "40505", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT::MC_SEQ", "표시순서", "40723", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);


            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT::IS_SIGNAL", "신호취득여부", "V4OOUWJC", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT::PLC_IP", "신호취득용IP", "42557", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT::MC_IP", "설비IP", "42556", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT::FTP_PORT", "FTP 포트", "881W45YM", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT::FTP_DIR", "FTP 디렉토리", "EU47YV71", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT::FTP_USER", "FTP 계정", "X688UUTM", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT::FTP_USER_PW", "FTP 계정암호", "HUQ6N8T3", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);


            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT::SCOMMENT", "비고", "ARYZ726K", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);


            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT::MON_TIME", "작업시간(월)", "I47BA44S", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT::TUE_TIME", "작업시간(화)", "IC8OOHO3", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT::WED_TIME", "작업시간(수)", "6CDZQQ27", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT::THR_TIME", "작업시간(목)", "05DIK1H8", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT::FRI_TIME", "작업시간(금)", "LSHZOU1R", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT::SAT_TIME", "작업시간(토)", "58CX8M4B", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT::SUN_TIME", "작업시간(일)", "J01ZZYP7", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);


  




            acGridView2.GridType = acGridView.emGridType.SEARCH;


            acGridView2.AddCheckEdit("SEL", "선택", "40290", true, true, true, acGridView.emCheckEditDataType._STRING);

            acGridView2.AddCheckEdit("OVERWRITE", "덮어쓰기", "QJJIK4V9", true, true, true, acGridView.emCheckEditDataType._STRING);

            acGridView2.AddTextEdit("MC_CODE", "설비코드", "41162", true, DevExpress.Utils.HorzAlignment.Center, true, true, true, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("MC_NAME", "설비명", "41202", true, DevExpress.Utils.HorzAlignment.Center, true, true, true, acGridView.emTextEditMask.NONE);

            acGridView2.AddLookUpEdit("MC_GROUP", "설비그룹", "40308", true, DevExpress.Utils.HorzAlignment.Center, true, true, true, "C020");

            acGridView2.AddTextEdit("MC_MODEL", "실모델명", "40400", true, DevExpress.Utils.HorzAlignment.Center, true, true, false, acGridView.emTextEditMask.NONE);


            acGridView2.AddCheckEdit("MC_AUTOMATED", "무인가공", "40973", true, true, true, acGridView.emCheckEditDataType._STRING);

            acGridView2.AddCheckEdit("MC_OS", "외부설비", "40974", true, true, true, acGridView.emCheckEditDataType._STRING);

            acGridView2.AddCheckEdit("MC_MGT_FLAG", "부하 관리대상", "40065", true, true, true, acGridView.emCheckEditDataType._STRING);



            acGridView2.AddCheckEdit("IS_OPERATE_STATE", "가동현황표시", "SR3IF2SN", true, true, true, acGridView.emCheckEditDataType._STRING);

            acGridView2.AddCheckEdit("IS_MULTI_START", "다중작업지시 동시진행", "MQBVM2AJ", true, true, true, acGridView.emCheckEditDataType._BYTE);

            acGridView2.AddCheckEdit("MULTI_START_DIV", "다중작업지시 동시진행시 실적분할", "HTHN5WFV", true, true, true, acGridView.emCheckEditDataType._BYTE);


            acGridView2.AddDateEdit("MC_OPEN_DATE", "유효시작일", "40477", true, DevExpress.Utils.HorzAlignment.Center, true, true, true, acGridView.emDateMask.SHORT_DATE);

            acGridView2.AddDateEdit("MC_CLOSE_DATE", "유효종료일", "40478", true, DevExpress.Utils.HorzAlignment.Center, true, true, true, acGridView.emDateMask.SHORT_DATE);

            acGridView2.AddHidden("MAIN_EMP", typeof(string));

            acGridView2.AddCustomEdit("MAIN_EMP_NAME", "담당자", "40127", true, DevExpress.Utils.HorzAlignment.Center, true, true, true, new RepositoryItemEmp());
            acGridView2.Columns["MAIN_EMP_NAME"].ColumnEdit.EditValueChanged += new EventHandler(MAIN_EMP_NAME_EditValueChanged);

            acGridView2.AddHidden("CPROC_CODE", typeof(string));

            acGridView2.AddCustomEdit("CPROC_NAME", "임률", "40505", true, DevExpress.Utils.HorzAlignment.Center, true, true, false, new RepositoryItemWageRate());
            acGridView2.Columns["CPROC_NAME"].ColumnEdit.EditValueChanged += new EventHandler(CPROC_NAMEt_EditValueChanged);

            acGridView2.AddTextEdit("MC_SEQ", "표시순서", "40723", true, DevExpress.Utils.HorzAlignment.Far, true, true, false, acGridView.emTextEditMask.NONE);



            acGridView2.AddCheckEdit("IS_SIGNAL", "신호취득여부", "V4OOUWJC", true, false, true, acGridView.emCheckEditDataType._STRING);

            acGridView2.AddTextEdit("PLC_IP", "신호취득용IP", "42557", true, DevExpress.Utils.HorzAlignment.Center, true, true, false, acGridView.emTextEditMask.IP);

            acGridView2.AddTextEdit("MC_IP", "설비IP", "42556", true, DevExpress.Utils.HorzAlignment.Center, true, true, false, acGridView.emTextEditMask.IP);

            acGridView2.AddTextEdit("FTP_PORT", "FTP 포트", "881W45YM", true, DevExpress.Utils.HorzAlignment.Center, true, true, false, acGridView.emTextEditMask.NONE);

            acGridView2.AddTextEdit("FTP_DIR", "FTP 디렉토리", "EU47YV71", true, DevExpress.Utils.HorzAlignment.Center, true, true, false, acGridView.emTextEditMask.NONE);

            acGridView2.AddTextEdit("FTP_USER", "FTP 계정", "X688UUTM", true, DevExpress.Utils.HorzAlignment.Center, true, true, false, acGridView.emTextEditMask.NONE);

            acGridView2.AddTextEdit("FTP_USER_PW", "FTP 계정암호", "HUQ6N8T3", true, DevExpress.Utils.HorzAlignment.Center, true, true, false, acGridView.emTextEditMask.NONE);

            acGridView2.AddTextEdit("SCOMMENT", "비고", "ARYZ726K", true, DevExpress.Utils.HorzAlignment.Near, true, true, false, acGridView.emTextEditMask.NONE);

            acGridView2.AddTextEdit("MON_TIME", "작업시간(월)", "I47BA44S", true, DevExpress.Utils.HorzAlignment.Far, true, true, true, acGridView.emTextEditMask.NUMERIC);
            acGridView2.AddTextEdit("TUE_TIME", "작업시간(화)", "IC8OOHO3", true, DevExpress.Utils.HorzAlignment.Far, true, true, true, acGridView.emTextEditMask.NUMERIC);
            acGridView2.AddTextEdit("WED_TIME", "작업시간(수)", "6CDZQQ27", true, DevExpress.Utils.HorzAlignment.Far, true, true, true, acGridView.emTextEditMask.NUMERIC);
            acGridView2.AddTextEdit("THR_TIME", "작업시간(목)", "05DIK1H8", true, DevExpress.Utils.HorzAlignment.Far, true, true, true, acGridView.emTextEditMask.NUMERIC);
            acGridView2.AddTextEdit("FRI_TIME", "작업시간(금)", "LSHZOU1R", true, DevExpress.Utils.HorzAlignment.Far, true, true, true, acGridView.emTextEditMask.NUMERIC);
            acGridView2.AddTextEdit("SAT_TIME", "작업시간(토)", "58CX8M4B", true, DevExpress.Utils.HorzAlignment.Far, true, true, true, acGridView.emTextEditMask.NUMERIC);
            acGridView2.AddTextEdit("SUN_TIME", "작업시간(일)", "J01ZZYP7", true, DevExpress.Utils.HorzAlignment.Far, true, true, true, acGridView.emTextEditMask.NUMERIC);




        }

        void CPROC_NAMEt_EditValueChanged(object sender, EventArgs e)
        {
            acGridView2.EndEditor();

            acWageRate editor = sender as acWageRate;

            DataRow focusRow = acGridView2.GetFocusedDataRow();

            focusRow["CPROC_CODE"] = editor.Value;
        }

        void MAIN_EMP_NAME_EditValueChanged(object sender, EventArgs e)
        {
            acGridView2.EndEditor();

            acEmp editor = sender as acEmp;

            DataRow focusRow = acGridView2.GetFocusedDataRow();

            focusRow["MAIN_EMP"] = editor.Value;
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
                int nRow = acVerticalGrid1.GetCellValue("EXCEL_IMPORT::STARTROW").toInt()-1;

                DataTable ecData = acGridView2.NewTable();

                int cnt = 0;

                if (acVerticalGrid1.GetCellValue("EXCEL_IMPORT::MC_CODE").isNullOrEmpty() == false)
                {
                    while (sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT::MC_CODE").ToString()].Cells[nRow].Value.isNullOrEmpty() == false)
                    {

                        this._ExcelFileLoadThread.SetCount(cnt);

                        DataRow ecRow = ecData.NewRow();

                        ecRow["SEL"] = "0";
                        ecRow["OVERWRITE"] = "0";


                        //부품

                        if (acVerticalGrid1.GetCellValue("EXCEL_IMPORT::MC_CODE").isNullOrEmpty() == false)
                        {
                            ecRow["MC_CODE"] = sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT::MC_CODE").ToString()].Cells[nRow].Value;
                        }


                        if (acVerticalGrid1.GetCellValue("EXCEL_IMPORT::MC_NAME").isNullOrEmpty() == false)
                        {
                            ecRow["MC_NAME"] = sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT::MC_NAME").ToString()].Cells[nRow].Value;
                        }


                        if (acVerticalGrid1.GetCellValue("EXCEL_IMPORT::MC_GROUP").isNullOrEmpty() == false)
                        {
                            ecRow["MC_GROUP"] = acInfo.StdCodes.GetCodeByName("C020", sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT::MC_GROUP").ToString()].Cells[nRow].Value);
                        }

                        if (acVerticalGrid1.GetCellValue("EXCEL_IMPORT::MC_MODEL").isNullOrEmpty() == false)
                        {
                            ecRow["MC_MODEL"] = sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT::MC_MODEL").ToString()].Cells[nRow].Value.toStringEmpty();
                        }


                        if (acVerticalGrid1.GetCellValue("EXCEL_IMPORT::MC_AUTOMATED").isNullOrEmpty() == false)
                        {
                            ecRow["MC_AUTOMATED"] = sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT::MC_AUTOMATED").ToString()].Cells[nRow].Value;
                        }

                        if (acVerticalGrid1.GetCellValue("EXCEL_IMPORT::MC_OS").isNullOrEmpty() == false)
                        {
                            ecRow["MC_OS"] = sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT::MC_OS").ToString()].Cells[nRow].Value;
                        }

                        if (acVerticalGrid1.GetCellValue("EXCEL_IMPORT::MC_MGT_FLAG").isNullOrEmpty() == false)
                        {
                            ecRow["MC_MGT_FLAG"] = sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT::MC_MGT_FLAG").ToString()].Cells[nRow].Value;
                        }



                        if (acVerticalGrid1.GetCellValue("EXCEL_IMPORT::IS_OPERATE_STATE").isNullOrEmpty() == false)
                        {
                            ecRow["IS_OPERATE_STATE"] = sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT::IS_OPERATE_STATE").ToString()].Cells[nRow].Value;
                        }



                        if (acVerticalGrid1.GetCellValue("EXCEL_IMPORT::IS_MULTI_START").isNullOrEmpty() == false)
                        {
                            ecRow["IS_MULTI_START"] = sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT::IS_MULTI_START").ToString()].Cells[nRow].Value;
                        }

                        if (acVerticalGrid1.GetCellValue("EXCEL_IMPORT::MULTI_START_DIV").isNullOrEmpty() == false)
                        {
                            ecRow["MULTI_START_DIV"] = sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT::MULTI_START_DIV").ToString()].Cells[nRow].Value;
                        }



                        if (acVerticalGrid1.GetCellValue("EXCEL_IMPORT::MC_OPEN_DATE").isNullOrEmpty() == false)
                        {
                            ecRow["MC_OPEN_DATE"] = sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT::MC_OPEN_DATE").ToString()].Cells[nRow].Value.toDateTimeDBNull();
                        }

                        if (acVerticalGrid1.GetCellValue("EXCEL_IMPORT::MC_CLOSE_DATE").isNullOrEmpty() == false)
                        {
                            ecRow["MC_CLOSE_DATE"] = sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT::MC_CLOSE_DATE").ToString()].Cells[nRow].Value.toDateTimeDBNull();
                        }



                        if (acVerticalGrid1.GetCellValue("EXCEL_IMPORT::MAIN_EMP").isNullOrEmpty() == false)
                        {
                            object code = acEmp.GetCodeByName(sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT::MAIN_EMP").ToString()].Cells[nRow].Value);

                            ecRow["MAIN_EMP"] = code;

                            if (code != null)
                            {
                                ecRow["MAIN_EMP_NAME"] = sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT::MAIN_EMP").ToString()].Cells[nRow].Value;
                            }
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


                        if (acVerticalGrid1.GetCellValue("EXCEL_IMPORT::MC_SEQ").isNullOrEmpty() == false)
                        {
                            ecRow["MC_SEQ"] = sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT::MC_SEQ").ToString()].Cells[nRow].Value.toInt();
                        }



                        if (acVerticalGrid1.GetCellValue("EXCEL_IMPORT::IS_SIGNAL").isNullOrEmpty() == false)
                        {
                            ecRow["IS_SIGNAL"] = sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT::IS_SIGNAL").ToString()].Cells[nRow].Value;
                        }

                        if (acVerticalGrid1.GetCellValue("EXCEL_IMPORT::PLC_IP").isNullOrEmpty() == false)
                        {
                            ecRow["PLC_IP"] = sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT::PLC_IP").ToString()].Cells[nRow].Value;
                        }


                        if (acVerticalGrid1.GetCellValue("EXCEL_IMPORT::MC_IP").isNullOrEmpty() == false)
                        {
                            ecRow["MC_IP"] = sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT::MC_IP").ToString()].Cells[nRow].Value;
                        }

                        if (acVerticalGrid1.GetCellValue("EXCEL_IMPORT::FTP_PORT").isNullOrEmpty() == false)
                        {
                            ecRow["FTP_PORT"] = sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT::FTP_PORT").ToString()].Cells[nRow].Value;
                        }


                        if (acVerticalGrid1.GetCellValue("EXCEL_IMPORT::FTP_DIR").isNullOrEmpty() == false)
                        {
                            ecRow["FTP_DIR"] = sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT::FTP_DIR").ToString()].Cells[nRow].Value;
                        }

                        if (acVerticalGrid1.GetCellValue("EXCEL_IMPORT::FTP_USER").isNullOrEmpty() == false)
                        {
                            ecRow["FTP_USER"] = sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT::FTP_USER").ToString()].Cells[nRow].Value;
                        }



                        if (acVerticalGrid1.GetCellValue("EXCEL_IMPORT::FTP_USER_PW").isNullOrEmpty() == false)
                        {
                            ecRow["FTP_USER_PW"] = sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT::FTP_USER_PW").ToString()].Cells[nRow].Value;
                        }


                        if (acVerticalGrid1.GetCellValue("EXCEL_IMPORT::SCOMMENT").isNullOrEmpty() == false)
                        {
                            ecRow["SCOMMENT"] = sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT::SCOMMENT").ToString()].Cells[nRow].Value;
                        }


                        if (acVerticalGrid1.GetCellValue("EXCEL_IMPORT::MON_TIME").isNullOrEmpty() == false)
                        {
                            ecRow["MON_TIME"] = sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT::MON_TIME").ToString()].Cells[nRow].Value.toDouble();
                        }


                        if (acVerticalGrid1.GetCellValue("EXCEL_IMPORT::TUE_TIME").isNullOrEmpty() == false)
                        {
                            ecRow["TUE_TIME"] = sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT::TUE_TIME").ToString()].Cells[nRow].Value.toDouble();
                        }

                        if (acVerticalGrid1.GetCellValue("EXCEL_IMPORT::WED_TIME").isNullOrEmpty() == false)
                        {
                            ecRow["WED_TIME"] = sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT::WED_TIME").ToString()].Cells[nRow].Value.toDouble();
                        }

                        if (acVerticalGrid1.GetCellValue("EXCEL_IMPORT::THR_TIME").isNullOrEmpty() == false)
                        {
                            ecRow["THR_TIME"] = sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT::THR_TIME").ToString()].Cells[nRow].Value.toDouble();
                        }


                        if (acVerticalGrid1.GetCellValue("EXCEL_IMPORT::THR_TIME").isNullOrEmpty() == false)
                        {
                            ecRow["THR_TIME"] = sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT::THR_TIME").ToString()].Cells[nRow].Value.toDouble();
                        }


                        if (acVerticalGrid1.GetCellValue("EXCEL_IMPORT::FRI_TIME").isNullOrEmpty() == false)
                        {
                            ecRow["FRI_TIME"] = sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT::FRI_TIME").ToString()].Cells[nRow].Value.toDouble();
                        }

                        if (acVerticalGrid1.GetCellValue("EXCEL_IMPORT::SAT_TIME").isNullOrEmpty() == false)
                        {
                            ecRow["SAT_TIME"] = sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT::SAT_TIME").ToString()].Cells[nRow].Value.toDouble();
                        }


                        if (acVerticalGrid1.GetCellValue("EXCEL_IMPORT::SUN_TIME").isNullOrEmpty() == false)
                        {
                            ecRow["SUN_TIME"] = sheet.Columns[acVerticalGrid1.GetCellValue("EXCEL_IMPORT::SUN_TIME").ToString()].Cells[nRow].Value.toDouble();
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

                frm.View.AddTextEdit("KEY", "설비코드", "41162", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

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
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //사업장 코드
                paramTable.Columns.Add("MC_CODE", typeof(String)); //
                paramTable.Columns.Add("MC_NAME", typeof(String)); //
                paramTable.Columns.Add("MC_GROUP", typeof(String)); //
                paramTable.Columns.Add("MC_AUTOMATED", typeof(Byte)); //
                paramTable.Columns.Add("MC_OS", typeof(Byte)); //
                paramTable.Columns.Add("MC_MGT_FLAG", typeof(Byte)); //

                paramTable.Columns.Add("IS_OPERATE_STATE", typeof(Byte)); //
                paramTable.Columns.Add("IS_SIGNAL", typeof(Byte)); //
                paramTable.Columns.Add("MC_OPEN_DATE", typeof(String)); //
                paramTable.Columns.Add("MC_CLOSE_DATE", typeof(String)); //
                paramTable.Columns.Add("MC_MODEL", typeof(String)); //
                paramTable.Columns.Add("CPROC_CODE", typeof(String)); //
                paramTable.Columns.Add("MC_SEQ", typeof(Int32)); //
                paramTable.Columns.Add("MAIN_EMP", typeof(String)); //
                paramTable.Columns.Add("SCOMMENT", typeof(String)); //
                paramTable.Columns.Add("REG_EMP", typeof(String)); //
                paramTable.Columns.Add("MC_IP", typeof(String)); //
                paramTable.Columns.Add("PLC_IP", typeof(String)); //
                paramTable.Columns.Add("FTP_PORT", typeof(String)); //
                paramTable.Columns.Add("FTP_USER", typeof(String)); //
                paramTable.Columns.Add("FTP_USER_PW", typeof(String)); //
                paramTable.Columns.Add("FTP_DIR", typeof(String)); //

                paramTable.Columns.Add("MON_TIME", typeof(Single)); //
                paramTable.Columns.Add("TUE_TIME", typeof(Single)); //
                paramTable.Columns.Add("WED_TIME", typeof(Single)); //
                paramTable.Columns.Add("THR_TIME", typeof(Single)); //
                paramTable.Columns.Add("FRI_TIME", typeof(Single)); //
                paramTable.Columns.Add("SAT_TIME", typeof(Single)); //
                paramTable.Columns.Add("SUN_TIME", typeof(Single)); //
                paramTable.Columns.Add("OPT_CAPA_CHANGE", typeof(String)); //오늘이후 제조월력 CAPA 수정
                paramTable.Columns.Add("OVERWRITE", typeof(String)); //덮어쓰기 여부


                DataView view = acGridView2.GetDataSourceView("SEL = '1'");

                foreach (DataRowView rv in view)
                {

                    DataRow row = rv.Row;

                    DataRow paramRow = paramTable.NewRow();
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["MC_CODE"] = row["MC_CODE"];
                    paramRow["MC_NAME"] = row["MC_NAME"];
                    paramRow["MC_GROUP"] = row["MC_GROUP"];
                    paramRow["MC_AUTOMATED"] = row["MC_AUTOMATED"];
                    paramRow["MC_OS"] = row["MC_OS"];
                    paramRow["MC_MGT_FLAG"] = row["MC_MGT_FLAG"];

                    paramRow["IS_OPERATE_STATE"] = row["IS_OPERATE_STATE"];
                    paramRow["IS_SIGNAL"] = row["IS_SIGNAL"];
                    paramRow["MC_OPEN_DATE"] = row["MC_OPEN_DATE"].toDateStringDBNull("yyyyMMdd");
                    paramRow["MC_CLOSE_DATE"] = row["MC_CLOSE_DATE"].toDateStringDBNull("yyyyMMdd");
                    paramRow["MC_MODEL"] = row["MC_MODEL"];
                    paramRow["CPROC_CODE"] = row["CPROC_CODE"];
                    paramRow["MC_SEQ"] = row["MC_SEQ"];
                    paramRow["MAIN_EMP"] = row["MAIN_EMP"];
                    paramRow["SCOMMENT"] = row["SCOMMENT"];
                    paramRow["REG_EMP"] = acInfo.UserID;
                    paramRow["MC_IP"] = row["MC_IP"];
                    paramRow["PLC_IP"] = row["PLC_IP"];
                    paramRow["FTP_PORT"] = row["FTP_PORT"];
                    paramRow["FTP_USER"] = row["FTP_USER"];
                    paramRow["FTP_USER_PW"] = row["FTP_USER_PW"];
                    paramRow["FTP_DIR"] = row["FTP_DIR"];

                    paramRow["MON_TIME"] = row["MON_TIME"];
                    paramRow["TUE_TIME"] = row["TUE_TIME"];
                    paramRow["WED_TIME"] = row["WED_TIME"];
                    paramRow["THR_TIME"] = row["THR_TIME"];
                    paramRow["FRI_TIME"] = row["FRI_TIME"];
                    paramRow["SAT_TIME"] = row["SAT_TIME"];
                    paramRow["SUN_TIME"] = row["SUN_TIME"];
                    paramRow["OPT_CAPA_CHANGE"] = "0";
                    paramRow["OVERWRITE"] = row["OVERWRITE"];
                    paramTable.Rows.Add(paramRow);


                }


                if (paramTable.Rows.Count != 0)
                {
                    DataSet paramSet = new DataSet();
                    paramSet.Tables.Add(paramTable);

                    BizRun.QBizRun.ExecuteService(
                    this, QBiz.emExecuteType.PROCESS, "STD04A_INS", paramSet, "RQSTDT", "RSLTDT",
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