using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Collections;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using System.Reflection;

using ControlManager;
using DevExpress.XtraEditors.Repository;
using DevExpress.Utils;
using BizManager;
using DevExpress.Spreadsheet;

namespace PUR
{
    public sealed partial class PUR05A_M0A : BaseMenu
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
            SearchBarcode(barcode);

        }


        public PUR05A_M0A()
        {
            InitializeComponent();

            acLayoutControl1.OnValueChanged += new acLayoutControl.ValueChangedEventHandler(acLayoutControl1_OnValueChanged);

            acLayoutControl1.OnValueKeyDown += new acLayoutControl.ValueKeyDownEventHandler(acLayoutControl1_OnValueKeyDown);

            acTabControl1.SelectedPageChanged += AcTabControl1_SelectedPageChanged;
        }

        

        private string _selectedPage;

        

        public override string InstantLog
        {
            set
            {
                statusBarLog.Caption = value;
            }
        }

        public override void MenuInit()
        {
            
            acGridView1.GridType = acGridView.emGridType.SEARCH_SEL;

            //
            acGridView1.AddLookUpEdit("BAL_STAT", "발주 상태", "", false, HorzAlignment.Center, false, true, false, "S043");
            acGridView1.AddLookUpEdit("BAL_TYPE", "발주 구분", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "S016");
            acGridView1.AddTextEdit("BALJU_NUM", "발주번호", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("BALJU_SEQ", "순번", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("PART_CODE", "자재코드", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("PART_NAME", "자재명", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("DETAIL_PART_NAME", "세부 자재명", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            //acGridView1.AddLookUpEdit("PART_PRODTYPE", "분류", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M007");
            acGridView1.AddLookUpEdit("MAT_LTYPE", "대분류", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M014");
            acGridView1.AddLookUpEdit("MAT_MTYPE", "중분류", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M015");
            acGridView1.AddLookUpVendor("VND_CODE", "발주처", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false);
            acGridView1.AddDateEdit("BALJU_DATE", "발주일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
            acGridView1.AddDateEdit("DUE_DATE", "입고예정일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
            acGridView1.AddTextEdit("SCOMMENT", "비고", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddLookUpEdit("INS_FLAG", "검사여부", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "S063");
            acGridView1.AddTextEdit("BAL_QTY", "발주수량", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView1.AddTextEdit("OK_QTY", "양품수량", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView1.AddTextEdit("NG_QTY", "불량수량", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView1.AddLookUpEdit("MAT_UNIT", "단위", "40123", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M003");
            acGridView1.AddTextEdit("BAL_COST", "발주단가", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
            acGridView1.AddTextEdit("BAL_AMT", "발주금액", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);

            acGridView1.AddLookUpEdit("BAL_UNIT", "금액단위", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P008");
            //acGridView1.AddLookUpEdit("INS_FLAG", "입고검사", "40123", false, DevExpress.Utils.HorzAlignment.Center, true, true, true, "S063");
            acGridView1.AddTextEdit("YPGO_QTY", "입고된 수량", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView1.AddTextEdit("QTY", "입고할 수량", "", false, DevExpress.Utils.HorzAlignment.Far, true, true, false, acGridView.emTextEditMask.QTY);
            acGridView1.AddTextEdit("YPGO_COST", "입고단가", "", false, DevExpress.Utils.HorzAlignment.Far, true, true, false, acGridView.emTextEditMask.MONEY);
            acGridView1.AddTextEdit("EX_RATE", "환율", "", false, DevExpress.Utils.HorzAlignment.Far, true, true, false, acGridView.emTextEditMask.MONEY);
            acGridView1.AddTextEdit("YPGO_AMT", "입고금액", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
            acGridView1.AddLookUpEdit("STK_LOCATION", "적재창고", "", false, DevExpress.Utils.HorzAlignment.Center, true, true, false, "M005");

            //acGridView1.Columns["INS_FLAG"].ColumnEdit.EditValueChanging += ColumnEdit_EditValueChanging;
            acGridView1.Columns["QTY"].ColumnEdit.EditValueChanging +=qty_EditValueChanging;
            acGridView1.Columns["YPGO_COST"].ColumnEdit.EditValueChanging += cost_EditValueChanging;
            acGridView1.Columns["EX_RATE"].ColumnEdit.EditValueChanging += rate_EditValueChanging;
            acGridView1.ValidateRow += AcGridView1_ValidateRow;

            acGridView1.KeyColumn = new string[] { "BALJU_NUM", "BALJU_SEQ" };

            acGridView2.GridType = acGridView.emGridType.SEARCH_SEL;

            acGridView2.AddLookUpEdit("BAL_STAT", "발주 상태", "", false, HorzAlignment.Center, false, true, false, "S043");
            acGridView2.AddTextEdit("BALJU_NUM", "발주번호", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("BALJU_SEQ", "순번", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("PROD_CODE", "수주코드", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("WO_NO", "작업지시번호", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("PART_CODE", "자재코드", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("PART_NAME", "자재명", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            //acGridView2.AddLookUpEdit("PART_PRODTYPE", "분류", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M007");
            acGridView2.AddLookUpEdit("MAT_LTYPE", "대분류", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M014");
            acGridView2.AddLookUpEdit("MAT_MTYPE", "중분류", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M015");
            acGridView2.AddLookUpVendor("VND_CODE", "발주처", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false);
            acGridView2.AddDateEdit("BALJU_DATE", "발주일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
            acGridView2.AddDateEdit("DUE_DATE", "입고예정일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
            acGridView2.AddDateEdit("INS_DATE", "검사일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
            acGridView2.AddTextEdit("SCOMMENT", "비고", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddLookUpEmp("REG_EMP", "발주자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false);
            acGridView2.AddLookUpEdit("INS_FLAG", "검사여부", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "S063");
            acGridView2.AddTextEdit("BAL_QTY", "발주수량", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView2.AddTextEdit("OK_QTY", "양품수량", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView2.AddTextEdit("NG_QTY", "불량수량", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView2.AddTextEdit("YPGO_QTY", "입고된 수량", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView2.AddTextEdit("QTY", "입고할 수량", "", false, DevExpress.Utils.HorzAlignment.Far, true, true, false, acGridView.emTextEditMask.QTY);
            acGridView2.AddLookUpEdit("MAT_UNIT", "단위", "40123", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M003");
            acGridView2.AddTextEdit("YPGO_COST", "입고단가", "", false, DevExpress.Utils.HorzAlignment.Far, true, true, false, acGridView.emTextEditMask.MONEY);
            acGridView2.AddTextEdit("EX_RATE", "환율", "", false, DevExpress.Utils.HorzAlignment.Far, true, true, false, acGridView.emTextEditMask.MONEY);
            acGridView2.AddTextEdit("YPGO_AMT", "입고금액", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
            acGridView2.AddLookUpEdit("STK_LOCATION", "적재창고", "", false, DevExpress.Utils.HorzAlignment.Center, true, true, false, "M005");            
            acGridView2.KeyColumn = new string[] { "BALJU_NUM", "BALJU_SEQ" };

            acGridView2.Columns["QTY"].ColumnEdit.EditValueChanging += qty_EditValueChanging;
            acGridView2.Columns["YPGO_COST"].ColumnEdit.EditValueChanging += cost_EditValueChanging;
            acGridView2.Columns["EX_RATE"].ColumnEdit.EditValueChanging += rate_EditValueChanging;

            acGridView1.CellValueChanged += acGridView1_CellValueChanged;
            acGridView2.CellValueChanged += acGridView2_CellValueChanged;

            (acLayoutControl1.GetEditor("MAT_LTYPE") as acLookupEdit).SetCode("M014");

            acCheckedComboBoxEdit1.AddItem("발주일", false, "40206", "BALJU_DATE", true, false);
            acCheckedComboBoxEdit1.AddItem("입고요청일", false, "40206", "DUE_DATE", true, false);

            _selectedPage = "MAT";

            //acBarButtonItem4.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            base.MenuInit();

        }

        private void acGridView1_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            try
            {
                acGridView1.EndEditor();

                if (e.Column.FieldName == "STK_LOCATION")
                {

                    //DataView dv = acGridView1.GetDataSourceView("STK_LOCATION IS NULL");

                    //if (dv.Count > 0)
                    //{
                    //    foreach (DataRowView drv in dv)
                    //    {
                    //        drv["STK_LOCATION"] = e.Value;
                    //    }
                    //}

                    if (acGridView1.IsRowSelected(acGridView1.FocusedRowHandle))
                    {
                        
                        foreach (DataRow row in acGridView1.GetSelectedDataRows())
                        {
                            row["STK_LOCATION"] = e.Value;
                        }
                    }
                    acGridView1.AcceptChanges();
                }



            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void acGridView2_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            acGridView2.EndEditor();

            if (e.Column.FieldName == "STK_LOCATION")
            {

                //DataView dv = acGridView2.GetDataSourceView("STK_LOCATION IS NULL");

                //if (dv.Count > 0)
                //{
                //    foreach (DataRowView drv in dv)
                //    {
                //        drv["STK_LOCATION"] = e.Value;
                //    }
                //}

                if (acGridView2.IsRowSelected(acGridView2.FocusedRowHandle))
                {

                    foreach (DataRow row in acGridView2.GetSelectedDataRows())
                    {
                        row["STK_LOCATION"] = e.Value;
                    }
                }
                acGridView2.AcceptChanges();
            }
        }


        private void AcGridView1_ValidateRow(object sender, ValidateRowEventArgs e)
        {
            try
            {
                acGridView gridView = sender as acGridView;

                
            }
            catch { }
        }

        public override void ChildContainerInit(Control sender)
        {
            if (sender == acLayoutControl1)
            {
                acLayoutControl layout = sender as acLayoutControl;

                layout.GetEditor("DATE").Value = "BALJU_DATE";

                layout.GetEditor("S_DATE").Value = System.DateTime.Now.AddDays(-7);

                layout.GetEditor("E_DATE").Value = System.DateTime.Now;
            }

            base.ChildContainerInit(sender);
        }
        private void AcTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            acTabControl tc = sender as acTabControl;

            if (tc.SelectedTabPage == acTabPage1)
            {
                _selectedPage = "MAT";
                //acBarButtonItem4.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
            else
            {
                _selectedPage = "OUT";
                //acBarButtonItem4.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            }
        }

        void acLayoutControl1_OnValueKeyDown(object sender, IBaseEditControl info, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.Search();
            }
        }

        void acLayoutControl1_OnValueChanged(object sender, IBaseEditControl info, object newValue)
        {
            //발주 조건변경
            acLayoutControl layout = sender as acLayoutControl;

            switch (info.ColumnName)
            {
                case "DATE":

                    //날짜검색조건이 존재하면 날짜컨트롤을 필수로 바꾼다.

                    if (newValue.EqualsEx(string.Empty))
                    {

                        layout.GetEditor("S_DATE").isRequired = false;
                        layout.GetEditor("E_DATE").isRequired = false;

                    }
                    else
                    {
                        layout.GetEditor("S_DATE").isRequired = true;
                        layout.GetEditor("E_DATE").isRequired = true;
                    }

                    break;
            }
        }

        private void cost_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            try
            {
                DevExpress.XtraEditors.TextEdit edit = sender as DevExpress.XtraEditors.TextEdit;

                acGridView view = (edit.Parent as acGridControl).MainView as acGridView;

                DataRow focusedRow = view.GetFocusedDataRow();

                decimal exRate = 1;

                if (focusedRow["EX_RATE"].toDecimal() > 0)
                {
                    exRate = focusedRow["EX_RATE"].toDecimal();
                }
                focusedRow["YPGO_AMT"] = focusedRow["QTY"].toInt() * (e.NewValue.toDecimal() * exRate);
                view.SelectRow(view.FocusedRowHandle);
                view.UpdateCurrentRow();


            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        private void rate_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            try
            {
                DevExpress.XtraEditors.TextEdit edit = sender as DevExpress.XtraEditors.TextEdit;

                acGridView view = (edit.Parent as acGridControl).MainView as acGridView;

                DataRow focusedRow = view.GetFocusedDataRow();

                focusedRow["YPGO_AMT"] = focusedRow["QTY"].toInt() * (e.NewValue.toDecimal() * focusedRow["YPGO_COST"].toDecimal());
                view.SelectRow(view.FocusedRowHandle);
                view.UpdateCurrentRow();


            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void qty_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            try
            {
                DevExpress.XtraEditors.TextEdit edit = sender as DevExpress.XtraEditors.TextEdit;

                acGridView view = (edit.Parent as acGridControl).MainView as acGridView;

                DataRow focusedRow = view.GetFocusedDataRow();

                if ((focusedRow["BAL_QTY"].toInt() - focusedRow["NG_QTY"].toInt() - focusedRow["YPGO_QTY"].toInt()) < e.NewValue.toInt())
                {
                    acMessageBox.Show("입고수량이 (발주-(불량+입고))수량보다 큽니다. 입고 수량을 확인하세요.", "자재 입고", acMessageBox.emMessageBoxType.CONFIRM);
                    e.Cancel = true;
                    return;
                }

                decimal exRate = 1;

                if (focusedRow["EX_RATE"].toDecimal() > 0)
                {
                    exRate = focusedRow["EX_RATE"].toDecimal();
                }

                focusedRow["YPGO_AMT"] = (e.NewValue.toInt() * exRate) * focusedRow["YPGO_COST"].toDecimal();
                view.SelectRow(view.FocusedRowHandle);
                view.UpdateCurrentRow();

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }


        void SearchBarcode(string barcode)
        {
            if (acLayoutControl1.ValidCheck() == false)
            {
                return;
            }

            DataRow layoutRow = acLayoutControl1.CreateParameterRow();

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("BARCODE", typeof(String)); //발주일 시작
            
            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["BARCODE"] = barcode;
            
            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            if (_selectedPage == "MAT")
            {
                DataSet dsResult = BizRun.QBizRun.ExecuteService(this, "PUR05A_SER", paramSet, "RQSTDT", "RSLTDT");

                acGridView1.GridControl.DataSource = dsResult.Tables["RSLTDT"];
            }
            else
            {
                DataSet dsResult = BizRun.QBizRun.ExecuteService(this, "PUR05A_SER2", paramSet, "RQSTDT", "RSLTDT");

                acGridView2.GridControl.DataSource = dsResult.Tables["RSLTDT"];
            }

        }

        void Search()
        {
            if (acLayoutControl1.ValidCheck() == false)
            {
                return;
            }

            DataRow layoutRow = acLayoutControl1.CreateParameterRow();

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("S_BALJU_DATE", typeof(String)); //발주일 시작
            paramTable.Columns.Add("E_BALJU_DATE", typeof(String)); //발주일 종료
            paramTable.Columns.Add("MAT_LTYPE", typeof(String)); 
            paramTable.Columns.Add("BALJU_NUM_LIKE", typeof(String));
            paramTable.Columns.Add("PART_LIKE", typeof(String));
            paramTable.Columns.Add("BARCODE", typeof(String));

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["MAT_LTYPE"] = layoutRow["MAT_LTYPE"];
            paramRow["BALJU_NUM_LIKE"] = layoutRow["BALJU_NUM_LIKE"];
            paramRow["PART_LIKE"] = layoutRow["PART_LIKE"];
            paramRow["BARCODE"] = layoutRow["BARCODE"];

            foreach (string key in acCheckedComboBoxEdit1.GetKeyChecked())
            {
                switch (key)
                {

                    case "BALJU_DATE":

                        //발주일
                        paramRow["S_BALJU_DATE"] = layoutRow["S_DATE"];
                        paramRow["E_BALJU_DATE"] = layoutRow["E_DATE"];

                        break;

                }

            }

            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            if (_selectedPage == "MAT")
            {
                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD, "PUR05A_SER", paramSet, "RQSTDT", "RSLTDT",
                        QuickSearch,
                        QuickException);

                //DataSet dsResult = BizRun.QBizRun.ExecuteService(this, "PUR05A_SER", paramSet, "RQSTDT", "RSLTDT");

                
            }
            else
            {

                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD, "PUR05A_SER2", paramSet, "RQSTDT", "RSLTDT",
                            QuickSearch2,
                            QuickException);

                //DataSet dsResult = BizRun.QBizRun.ExecuteService(this, "PUR05A_SER2", paramSet, "RQSTDT", "RSLTDT");

            }

        }

        void QuickSearch(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {

                //바코드 스캔시
                if (e.result.Tables["RQSTDT"].Columns.Contains("BARCODE"))
                {
                    if (e.result.Tables["RQSTDT"].Rows[0]["BARCODE"].ToString() != "")
                    {
                        acTextEdit3.Text = "";
                        if (e.result.Tables["RSLTDT"].Rows.Count == 0)
                        {
                            acAlert.Show(this, "발주 정보가 없거나 이미 입고된 바코드입니다. ", acAlertForm.enmType.Info);
                            
                            return;
                        }
                    }
                }

                acGridView1.GridControl.DataSource = e.result.Tables["RSLTDT"];

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }


        void QuickSearch2(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {

                //바코드 스캔시
                if (e.result.Tables["RQSTDT"].Columns.Contains("BARCODE"))
                {
                    if (e.result.Tables["RQSTDT"].Rows[0]["BARCODE"].ToString() != "")
                    {
                        acTextEdit3.Text = "";
                        if (e.result.Tables["RSLTDT"].Rows.Count == 0)
                        {
                            acAlert.Show(this, "발주 정보가 없거나 이미 입고된 바코드입니다. ", acAlertForm.enmType.Info);
                            return;
                        }
                    }
                }

                acGridView2.GridControl.DataSource = e.result.Tables["RSLTDT"];

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

        private void barItemSearch_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //조회
            try
            {
                this.Search();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }


        private void acBarButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //입고
            try
            {
                acGridView1.EndEditor();

                DataRow[] selectedRows = acGridView1.GetSelectedDataRows();
                DataRow focusedRow = acGridView1.GetFocusedDataRow();

                if (_selectedPage == "OUT")
                {
                
                    acGridView2.EndEditor();

                    selectedRows = acGridView2.GetSelectedDataRows();
                    focusedRow = acGridView2.GetFocusedDataRow();

                    if (!acGridView2.ValidCheck()) return;
                }


                //if (selectedRows.Length == 0)
                //{
                //    acMessageBox.Show("선택된 목록이 없습니다.", "구매 입고", acMessageBox.emMessageBoxType.CONFIRM);
                //    return;
                //}

                foreach (DataRow r in selectedRows)
                {
                    if (r["STK_LOCATION"].ToString() == "")
                    {

                        acMessageBox.Show("입고 창고를 선택하세요.", "구매 입고", acMessageBox.emMessageBoxType.CONFIRM);
                        return;
                    }
                }

                if (selectedRows.Length == 0)
                {
                    if (focusedRow != null)
                    {
                        if (focusedRow["STK_LOCATION"].ToString() == "")
                        {

                            acMessageBox.Show("입고 창고를 선택하세요.", "구매 입고", acMessageBox.emMessageBoxType.CONFIRM);
                            return;
                        }
                    }
                    else
                    {
                        return;
                    }
                }

                PUR05A_D0A frm = new PUR05A_D0A();
                frm.ParentControl = this;
                frm.Text = "입고";

                if (frm.ShowDialog() == DialogResult.OK)
                {

                    DataRow outputRow = frm.OutputData as DataRow;

                    DataTable paramtable = new DataTable("RQSTDT");
                    paramtable.Columns.Add("PLT_CODE", typeof(string));
                    paramtable.Columns.Add("BALJU_NUM", typeof(string));
                    paramtable.Columns.Add("BALJU_SEQ", typeof(string));
                    paramtable.Columns.Add("YPGO_DATE", typeof(string));
                    paramtable.Columns.Add("QTY", typeof(int));
                    paramtable.Columns.Add("YPGO_COST", typeof(decimal));
                    paramtable.Columns.Add("YPGO_AMT", typeof(decimal));
                    paramtable.Columns.Add("SCOMMENT", typeof(string));
                    paramtable.Columns.Add("REG_EMP", typeof(string));
                    paramtable.Columns.Add("STK_LOCATION", typeof(string));
                    paramtable.Columns.Add("WO_NO", typeof(string));
                    paramtable.Columns.Add("EX_RATE", typeof(decimal));
                    paramtable.Columns.Add("VND_CODE", typeof(string));

                    if (selectedRows.Length == 0)
                    {
                        DataRow datarow = paramtable.NewRow();
                        datarow["PLT_CODE"] = acInfo.PLT_CODE;
                        datarow["BALJU_NUM"] = focusedRow["BALJU_NUM"];
                        datarow["BALJU_SEQ"] = focusedRow["BALJU_SEQ"];
                        datarow["YPGO_DATE"] = outputRow["YPGO_DATE"];
                        datarow["QTY"] = focusedRow["QTY"];
                        datarow["YPGO_COST"] = focusedRow["YPGO_COST"];
                        datarow["YPGO_AMT"] = focusedRow["YPGO_AMT"];
                        datarow["SCOMMENT"] = outputRow["SCOMMENT"];
                        datarow["REG_EMP"] = acInfo.UserID;
                        datarow["STK_LOCATION"] = focusedRow["STK_LOCATION"];
                        datarow["EX_RATE"] = focusedRow["EX_RATE"];
                        datarow["VND_CODE"] = focusedRow["VND_CODE"];

                        if (focusedRow.Table.Columns.Contains("WO_NO"))
                            datarow["WO_NO"] = focusedRow["WO_NO"];

                        paramtable.Rows.Add(datarow);
                    }
                    else
                    {
                        foreach (DataRow dr in selectedRows)
                        {
                            DataRow datarow = paramtable.NewRow();
                            datarow["PLT_CODE"] = acInfo.PLT_CODE;
                            datarow["BALJU_NUM"] = dr["BALJU_NUM"];
                            datarow["BALJU_SEQ"] = dr["BALJU_SEQ"];
                            datarow["YPGO_DATE"] = outputRow["YPGO_DATE"];
                            datarow["QTY"] = dr["QTY"];
                            datarow["YPGO_COST"] = dr["YPGO_COST"];
                            datarow["YPGO_AMT"] = dr["YPGO_AMT"];
                            datarow["SCOMMENT"] = outputRow["SCOMMENT"];
                            datarow["REG_EMP"] = acInfo.UserID;
                            datarow["STK_LOCATION"] = dr["STK_LOCATION"];
                            datarow["EX_RATE"] = dr["EX_RATE"];
                            datarow["VND_CODE"] = dr["VND_CODE"];

                            if (dr.Table.Columns.Contains("WO_NO"))
                                datarow["WO_NO"] = dr["WO_NO"];

                            paramtable.Rows.Add(datarow);

                        }
                    }
                    

                    //입고처리 후 조회
                    DataRow layoutRow = acLayoutControl1.CreateParameterRow();
                   
                    DataTable paramTable = new DataTable("RQSTDT_SEARCH");
                    paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                    paramTable.Columns.Add("S_BALJU_DATE", typeof(String)); //발주일 시작
                    paramTable.Columns.Add("E_BALJU_DATE", typeof(String)); //발주일 종료
                    paramTable.Columns.Add("MAT_LTYPE", typeof(String));
                    paramTable.Columns.Add("BALJU_NUM_LIKE", typeof(String));
                    paramTable.Columns.Add("PART_LIKE", typeof(String));

                    DataRow paramRow = paramTable.NewRow();
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["MAT_LTYPE"] = layoutRow["MAT_LTYPE"];
                    paramRow["BALJU_NUM_LIKE"] = layoutRow["BALJU_NUM_LIKE"];
                    paramRow["PART_LIKE"] = layoutRow["PART_LIKE"];

                    foreach (string key in acCheckedComboBoxEdit1.GetKeyChecked())
                    {
                        switch (key)
                        {

                            case "BALJU_DATE":

                                //발주일
                                paramRow["S_BALJU_DATE"] = layoutRow["S_DATE"];
                                paramRow["E_BALJU_DATE"] = layoutRow["E_DATE"];

                                break;

                        }

                    }
                    paramTable.Rows.Add(paramRow);

                    DataSet paramSet = new DataSet();
                    paramSet.Tables.Add(paramtable);
                    paramSet.Tables.Add(paramTable);

                    paramTable.TableName = "RQSTDT_SEARCH";

                    if (_selectedPage == "MAT")
                    {
                        BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.SAVE, "PUR05A_INS_M", paramSet, "RQSTDT", "RSLTDT", QuickSave, QuickException);
                    }
                    else
                    {
                        BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.SAVE, "PUR05A_INS_PO", paramSet, "RQSTDT", "RSLTDT", QuickSave, QuickException);
                    }
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
                if (_selectedPage == "MAT")
                {
                    acGridView1.GridControl.DataSource = e.result.Tables["RSLTDT"];
                }
                else
                {
                    acGridView2.GridControl.DataSource = e.result.Tables["RSLTDT"];
                }

                acAlert.Show(this, "입고 되었습니다.", acAlertForm.enmType.Success);

                base.SetLog(e.executeType, e.result.Tables["RSLTDT"].Rows.Count, e.executeTime);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void acBarButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                PUR05A_D1A frm = new PUR05A_D1A(_selectedPage);

                frm.ParentControl = this;

                frm.Text = "단가 업데이트";

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    //DataTable paramtable = frm.OutputData as DataTable;

                    DataTable paramtable = new DataTable("RQSTDT");
                    paramtable.Columns.Add("PLT_CODE", typeof(string));
                    paramtable.Columns.Add("S_MDFY_DATE", typeof(string));
                    paramtable.Columns.Add("E_MDFY_DATE", typeof(string));

                    DataRow paramRow = paramtable.NewRow();
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["S_MDFY_DATE"] = DateTime.Now.AddMinutes(-5).toDateString("yyyy-MM-dd HH:mm:ss");
                    paramRow["E_MDFY_DATE"] = DateTime.Now.AddMinutes(1).toDateString("yyyy-MM-dd HH:mm:ss");
                    paramtable.Rows.Add(paramRow);

                    DataSet paramSet = new DataSet();
                    paramSet.Tables.Add(paramtable);

                    //paramSet.Tables.Add(paramtable.Copy());
                    //paramSet.Tables[0].TableName = "RQSTDT";

                    if (_selectedPage == "MAT")
                    {
                        DataSet dsResult = BizRun.QBizRun.ExecuteService(this, "PUR05A_SER", paramSet, "RQSTDT", "RSLTDT");

                        acGridView1.GridControl.DataSource = dsResult.Tables["RSLTDT"];
                    }
                    else
                    {
                        DataSet dsResult = BizRun.QBizRun.ExecuteService(this, "PUR05A_SER2", paramSet, "RQSTDT", "RSLTDT");

                        acGridView2.GridControl.DataSource = dsResult.Tables["RSLTDT"];
                    }

                }
                
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void acBarButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (acMessageBox.Show("선택한 항목들을 모두 입고 완료처리하시겠습니까? ", this.Caption, acMessageBox.emMessageBoxType.YESNO)
                            == DialogResult.No) return;

                if (_selectedPage == "MAT")
                {
                    acGridView1.EndEditor();

                    DataRow[] selectedRows = acGridView1.GetSelectedDataRows();
                    DataRow focusedRow = acGridView1.GetFocusedDataRow();

                    DataTable paramtable = new DataTable("RQSTDT");
                    paramtable.Columns.Add("PLT_CODE", typeof(string));
                    paramtable.Columns.Add("BALJU_NUM", typeof(string));
                    paramtable.Columns.Add("BALJU_SEQ", typeof(string));

                    if (selectedRows.Length == 0)
                    {
                        DataRow datarow = paramtable.NewRow();
                        datarow["PLT_CODE"] = acInfo.PLT_CODE;
                        datarow["BALJU_NUM"] = focusedRow["BALJU_NUM"];
                        datarow["BALJU_SEQ"] = focusedRow["BALJU_SEQ"];
                     
                        paramtable.Rows.Add(datarow);

                    }
                    else
                    {
                        foreach (DataRow dr in selectedRows)
                        {

                            DataRow datarow = paramtable.NewRow();
                            datarow["PLT_CODE"] = acInfo.PLT_CODE;
                            datarow["BALJU_NUM"] = dr["BALJU_NUM"];
                            datarow["BALJU_SEQ"] = dr["BALJU_SEQ"];

                            paramtable.Rows.Add(datarow);

                        }
                    }


                    DataSet paramSet = new DataSet();
                    paramSet.Tables.Add(paramtable);

                    BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.SAVE, "PUR05A_INS2_M", paramSet, "RQSTDT", "RSLTDT", QuickSave2, QuickException);

                }
                else if (_selectedPage == "OUT")
                {
                    acGridView2.EndEditor();

                    DataRow[] selectedRows = acGridView2.GetSelectedDataRows();
                    DataRow focusedRow = acGridView2.GetFocusedDataRow();

                    DataTable paramtable = new DataTable("RQSTDT");
                    paramtable.Columns.Add("PLT_CODE", typeof(string));
                    paramtable.Columns.Add("BALJU_NUM", typeof(string));
                    paramtable.Columns.Add("BALJU_SEQ", typeof(string));
                    paramtable.Columns.Add("WO_NO", typeof(string));
                    paramtable.Columns.Add("YPGO_DATE", typeof(string));

                    if (selectedRows.Length == 0)
                    {
                        DataRow datarow = paramtable.NewRow();
                        datarow["PLT_CODE"] = acInfo.PLT_CODE;
                        datarow["BALJU_NUM"] = focusedRow["BALJU_NUM"];
                        datarow["BALJU_SEQ"] = focusedRow["BALJU_SEQ"];
                        datarow["WO_NO"] = focusedRow["WO_NO"];
                        datarow["YPGO_DATE"] = DateTime.Today.toDateString("yyyyMMdd");

                        paramtable.Rows.Add(datarow);

                    }
                    else
                    {

                        foreach (DataRow dr in selectedRows)
                        {

                            DataRow datarow = paramtable.NewRow();
                            datarow["PLT_CODE"] = acInfo.PLT_CODE;
                            datarow["BALJU_NUM"] = dr["BALJU_NUM"];
                            datarow["BALJU_SEQ"] = dr["BALJU_SEQ"];
                            datarow["WO_NO"] = dr["WO_NO"];
                            datarow["YPGO_DATE"] = DateTime.Today.toDateString("yyyyMMdd");

                            paramtable.Rows.Add(datarow);

                        }
                    }


                    DataSet paramSet = new DataSet();
                    paramSet.Tables.Add(paramtable);

                    BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.SAVE, "PUR05A_INS2_PO", paramSet, "RQSTDT", "RSLTDT", QuickSave2, QuickException);

                }

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void QuickSave2(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                if (_selectedPage == "MAT")
                {
                    foreach (DataRow dr in e.result.Tables["RQSTDT"].Rows)
                    {
                        acGridView1.DeleteMappingRow(dr);
                    }
                }
                else
                {
                    foreach (DataRow dr in e.result.Tables["RQSTDT"].Rows)
                    {
                        acGridView2.DeleteMappingRow(dr);
                    }
                }

                base.SetLog(e.executeType, e.result.Tables["RQSTDT"].Rows.Count, e.executeTime);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }


        private void acBarButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {

                if (_selectedPage == "MAT")
                {
                    if ((acGridView1.GridControl.DataSource as DataTable).Rows.Count > 0)
                        acGridView1.SaveGridViewToFile(QGridViewExportTo.emSaveFileType.Xlsx);
                    else
                        acMessageBox.Show("조회된 자료가 없습니다.", "엑셀로 내보내기", acMessageBox.emMessageBoxType.CONFIRM);
                }
                else
                {
                    if ((acGridView2.GridControl.DataSource as DataTable).Rows.Count > 0)
                        acGridView2.SaveGridViewToFile(QGridViewExportTo.emSaveFileType.Xlsx);
                    else
                        acMessageBox.Show("조회된 자료가 없습니다.", "엑셀로 내보내기", acMessageBox.emMessageBoxType.CONFIRM);
                }

                
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

    }
}



