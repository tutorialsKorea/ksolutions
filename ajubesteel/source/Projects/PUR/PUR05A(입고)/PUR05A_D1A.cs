using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using ControlManager;
using DevExpress.Spreadsheet;
using BizManager;

namespace PUR
{
    public sealed partial class PUR05A_D1A : BaseMenuDialog
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

        private string _selectedPage;

        public PUR05A_D1A(string selectedPage)
        {
            InitializeComponent();

            spreadsheetControl1.Visible = false;

            _selectedPage = selectedPage;

            //acVerticalGrid1.AddTextEdit("XLS_IMPORT:SHEET", "��Ʈ", "LBG894M9", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);
            acVerticalGrid1.AddTextEdit("XLS_IMPORT:STARTROW", "������", "R309968V", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NUMERIC);
            acVerticalGrid1.AddTextEdit("XLS_IMPORT:BALJU_NUM", "����_���ֹ�ȣ", "40239", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);
            acVerticalGrid1.AddTextEdit("XLS_IMPORT:BALJU_SEQ", "����_���ּ���", "40234", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);
            acVerticalGrid1.AddTextEdit("XLS_IMPORT:PART_CODE", "����_�����ڵ�", "40743", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);
            acVerticalGrid1.AddTextEdit("XLS_IMPORT:PART_NAME", "����_�����", "40132", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);
            acVerticalGrid1.AddTextEdit("XLS_IMPORT:QTY", "����_����", "40338", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);
            acVerticalGrid1.AddTextEdit("XLS_IMPORT:UNIT_COST", "����_�ܰ�", "40235", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

            acVerticalGrid1.AddTextEdit("XLS_IMPORT:OBALJU_NUM", "����_���ֹ�ȣ", "40239", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);
            acVerticalGrid1.AddTextEdit("XLS_IMPORT:OBALJU_SEQ", "����_���ּ���", "40234", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);
            //acVerticalGrid1.AddTextEdit("XLS_IMPORT:OWO_NO", "����_�۾����ù�ȣ", "40234", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);
            acVerticalGrid1.AddTextEdit("XLS_IMPORT:OPART_CODE", "����_�����ڵ�", "40743", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);
            acVerticalGrid1.AddTextEdit("XLS_IMPORT:OPART_NAME", "����_�����", "40132", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);            
            acVerticalGrid1.AddTextEdit("XLS_IMPORT:OQTY", "����_����", "40338", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);
            acVerticalGrid1.AddTextEdit("XLS_IMPORT:OUNIT_COST", "����_�ܰ�", "40235", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

            acVerticalGrid1.AddCategoryRow("����", "", false, new string[] {
            "XLS_IMPORT:BALJU_NUM"
            ,"XLS_IMPORT:BALJU_SEQ"
            ,"XLS_IMPORT:PART_CODE"
            ,"XLS_IMPORT:PART_NAME"
            ,"XLS_IMPORT:QTY"
            ,"XLS_IMPORT:UNIT_COST"
            });


            acVerticalGrid1.AddCategoryRow("����", "", false, new string[] {
            "XLS_IMPORT:OBALJU_NUM"
            ,"XLS_IMPORT:OBALJU_SEQ"
            ,"XLS_IMPORT:OWO_NO"
            ,"XLS_IMPORT:OPART_CODE"
            ,"XLS_IMPORT:OPART_NAME"
            ,"XLS_IMPORT:OQTY"
            ,"XLS_IMPORT:OUNIT_COST"
            });


            acGridView2.GridType = acGridView.emGridType.SEARCH;
            acGridView2.AddTextEdit("PLT_CODE", "", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("BALJU_NUM", "���ֹ�ȣ", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("BALJU_SEQ", "����", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("WO_NO", "�۾����ù�ȣ", "", false, DevExpress.Utils.HorzAlignment.Near, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("PART_CODE", "�����ڵ�", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("PART_NAME", "�����", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            //acGridView2.AddDateEdit("BALJU_DATE", "������", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
            acGridView2.AddTextEdit("QTY", "���ּ���", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView2.AddTextEdit("UNIT_COST", "�԰�ܰ�", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
            acGridView2.AddTextEdit("AMT", "�԰�ݾ�", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);


        }



        public override void DialogInit()
        {
            acVerticalGrid1.DataBind(this.GetMenuConfigRowTableByServer().Rows[0]);

            acVerticalGrid1.BestFit();

            base.DialogInit();
        }



        private void acBarButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                acVerticalGrid1.EndEditor();


                DataTable data = acVerticalGrid1.CreateParameterTable(true);

                foreach (DataColumn col in data.Columns)
                {
                    acInfo.MenuConfig.SetMenuConfigByServer("PUR05A", col.ColumnName, data.Rows[0][col.ColumnName].toStringEmpty());
                }

                OpenFileDialog openFileDialog1 = new OpenFileDialog();

                openFileDialog1.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                openFileDialog1.Filter = "Excel Files|*.xls;*.xlsx; | All Files|*.*";
                openFileDialog1.FilterIndex = 1;
                openFileDialog1.RestoreDirectory = true;

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {

                    spreadsheetControl1.LoadDocument(openFileDialog1.FileName);

                    this._ExcelFileLoadThread = new BizManager.QThread(this, BizManager.QThread.emExecuteType.LOAD);

                    this._ExcelFileLoadThread.Execute(ExcelFileLoadThreadStarter, new object[] { openFileDialog1.FileName });

                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }


        }


        private BizManager.QThread _ExcelFileLoadThread = null;

        private void acSimpleButton1_Click(object sender, EventArgs e)
        {

            try
            {

                
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private int _xls_cnt = 0;

        void ExcelFileLoadThreadStarter(object args)
        {
            try
            {
                //�������� Import ������
                object[] parameter = (object[])args;

                //�������ϸ�
                string filename = parameter[0] as string;



                IWorkbook workBook = spreadsheetControl1.Document;


                //������ 
                int idxStart = acVerticalGrid1.GetCellValue("XLS_IMPORT:STARTROW").toInt() - 1;

                string colXLS_BALJU_NUM = acVerticalGrid1.GetCellValue("XLS_IMPORT:BALJU_NUM").toStringNull();
                string colXLS_BALJU_SEQ = acVerticalGrid1.GetCellValue("XLS_IMPORT:BALJU_SEQ").toStringNull();
                string colXLS_WO_NO;
                string colXLS_PART_CODE = acVerticalGrid1.GetCellValue("XLS_IMPORT:PART_CODE").toStringNull(); 
                string colXLS_PART_NAME = acVerticalGrid1.GetCellValue("XLS_IMPORT:PART_NAME").toStringNull(); 
                string colXLS_BALJU_DATE = acVerticalGrid1.GetCellValue("XLS_IMPORT:BALJU_DATE").toStringNull(); 
                string colXLS_QTY = acVerticalGrid1.GetCellValue("XLS_IMPORT:QTY").toStringNull(); 
                string colXLS_UC = acVerticalGrid1.GetCellValue("XLS_IMPORT:UNIT_COST").ToString(); 

                if (_selectedPage == "OUT")
                {
                    colXLS_BALJU_NUM = acVerticalGrid1.GetCellValue("XLS_IMPORT:OBALJU_NUM").toStringNull();
                    colXLS_BALJU_SEQ = acVerticalGrid1.GetCellValue("XLS_IMPORT:OBALJU_SEQ").toStringNull();
                    colXLS_WO_NO = acVerticalGrid1.GetCellValue("XLS_IMPORT:OWO_NO").toStringNull();
                    colXLS_PART_CODE = acVerticalGrid1.GetCellValue("XLS_IMPORT:OPART_CODE").toStringNull();
                    colXLS_PART_NAME = acVerticalGrid1.GetCellValue("XLS_IMPORT:OPART_NAME").toStringNull();
                    colXLS_BALJU_DATE = acVerticalGrid1.GetCellValue("XLS_IMPORT:OBALJU_DATE").toStringNull();
                    colXLS_QTY = acVerticalGrid1.GetCellValue("XLS_IMPORT:OQTY").toStringNull();
                    colXLS_UC = acVerticalGrid1.GetCellValue("XLS_IMPORT:OUNIT_COST").ToString();
                }

                Worksheet worksheet = workBook.Worksheets[0];

                RowCollection rows = worksheet.Rows;
                

                DataTable ecData = acGridView2.NewTable();

                int cnt = 0;

                if (acVerticalGrid1.GetCellValue("XLS_IMPORT:BALJU_NUM").isNullOrEmpty() == false)
                {
                    int idx = idxStart;

                    while (true)
                    {
                        if (rows[idx][colXLS_BALJU_NUM].Value.ToString() == "") break;

                        this._ExcelFileLoadThread.SetCount(cnt);

                        DataRow ecRow = ecData.NewRow();
                        ecRow["PLT_CODE"] = acInfo.PLT_CODE;
                        ecRow["BALJU_NUM"] = rows[idx][colXLS_BALJU_NUM].DisplayText;
                        ecRow["BALJU_SEQ"] = rows[idx][colXLS_BALJU_SEQ].DisplayText;
                        ecRow["PART_CODE"] = rows[idx][colXLS_PART_CODE].DisplayText;
                        ecRow["PART_NAME"] = rows[idx][colXLS_PART_NAME].DisplayText;
                        //ecRow["WO_NO"] = rows[idx][colXLS_WO_NO].DisplayText;
                        ecRow["QTY"] = rows[idx][colXLS_QTY].DisplayText;
                        ecRow["UNIT_COST"] = rows[idx][colXLS_UC].DisplayText;
                        ecRow["AMT"] = rows[idx][colXLS_QTY].DisplayText.toInt() * rows[idx][colXLS_UC].Value.ToString().toDecimal() ;

                        ecData.Rows.Add(ecRow);

                        idx++;

                        ++cnt;
                    }
                    //for(int idx = idxStart; idx <= rows.LastUsedIndex; idx++)
                    //{

                    //}
                    _xls_cnt = cnt;
                }

                this.BeginInvoke((MethodInvoker)delegate
                {

                    if (this._ExcelFileLoadThread.IsThreadAbort == false)
                    {
                        acGridView2.GridControl.DataSource = ecData;

                        //DataTable now = acGridView2.GridControl.DataSource as DataTable;

                        //now.Load(new DataTableReader(ecData));

                        acGridView2.ResetGridRowSeq();
                        acGridView2.BestFitColumns();
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

        

        private void acBarButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            acVerticalGrid1.EndEditor();

            DataTable data = acVerticalGrid1.CreateParameterTable(true);

            foreach (DataColumn col in data.Columns)
            {
                acInfo.MenuConfig.SetMenuConfigByServer("PUR05A", col.ColumnName, data.Rows[0][col.ColumnName].toStringEmpty());
            }


            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void acBarButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                DataTable dt = acGridView2.GridControl.DataSource as DataTable;

                DataSet paramSet = new DataSet();
                DataTable paramTable = dt.Copy();
                paramTable.TableName = "RQSTDT";

                paramSet.Tables.Add(paramTable);

                if (_selectedPage == "MAT")
                    BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.SAVE, "PUR05A_UPD", paramSet, "RQSTDT", "RSLTDT", QuickSave, QuickException);
                else
                    BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.SAVE, "PUR05A_UPD2", paramSet, "RQSTDT", "RSLTDT", QuickSave, QuickException);


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
                //acMessageBox.Show(string.Format("'{0}'�� �ܰ� ������ ������Ʈ�Ǿ����ϴ�.", _xls_cnt.ToString()), "�ܰ� ������Ʈ", acMessageBox.emMessageBoxType.CONFIRM);

                this.OutputData = e.result.Tables["RQSTDT"];

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void QuickException(object sender, QBiz qBiz, BizManager.BizException ex)
        {
            acMessageBox.Show(this, ex);
        }

    }
}

