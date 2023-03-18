using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ControlManager;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Grid;
using BizManager;

namespace ORD
{
    public sealed partial class ORD10A_D0A : BaseMenuDialog
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

        private acGridView _linkView = null;


        private object _linkData = null;

        public object LinkData
        {
            set { _linkData = value; }
            get { return _linkData; }
        }

        private DataSet dsEmp = null;

        public ORD10A_D0A(acGridView linkView, object linkData)
        {
            InitializeComponent();


            this._linkView = linkView;

            this._linkData = linkData;

            (acLayoutControl2.GetEditor("STK_LOC") as acLookupEdit).SetCode("M005");

            (acLayoutControl2.GetEditor("MAT_LTYPE") as acLookupEdit).SetCode("M014");
            //(acLayoutControl1.GetEditor("PROD_LOCATION") as acLookupEdit).SetCode("M042");

            acGridView1.GridType = acGridView.emGridType.SEARCH;

            //acGridView1.AddLookUpEdit("MAT_LTYPE", "구분", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M014");
            acGridView1.AddTextEdit("PART_CODE", "품목코드", "40239", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("PART_NAME", "품목명", "40234", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            //acGridView1.AddLookUpEdit("MAT_TYPE", "자재형태", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "ItemType");

            acGridView1.AddLookUpEdit("MAT_LTYPE", "대분류", "40132", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M014");

            acGridView1.AddLookUpEdit("MAT_MTYPE", "중분류", "40630", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M015");

            acGridView1.AddLookUpEdit("MAT_STYPE", "소분류", "40338", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M016");

            acGridView1.AddTextEdit("DRAW_NO", "도면번호", "40145", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("MAT_SPEC", "규격", "AD1YYZ7Z", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            //acGridView1.AddTextEdit("CHANGE_VALUE", "환산수량", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddLookUpEdit("MAT_UNIT", "관리 단위", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M003");
            //acGridView1.AddTextEdit("MAT_QTY", "재고 수량(관리)", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.F1);
            acGridView1.AddLookUpEdit("STK_UNIT", "재고 단위", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M022");
            acGridView1.AddTextEdit("PART_QTY", "재고 수량(재고)", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.F1);
            //acGridView1.AddTextEdit("REQ_QTY", "소요예상수량", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.F1);
            //acGridView1.AddTextEdit("STK_ID", "재고ID", "", false, DevExpress.Utils.HorzAlignment.Near, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("SAFE_STK_QTY", "안전재고 수량", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView1.AddLookUpEdit("STOCK_LOC", "자재 창고", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M005");
            acGridView1.AddTextEdit("TOT_YPGO_AMT", "재고 금액", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);


            acGridView1.KeyColumn = new string[] { "PART_CODE" };

            acGridView2.GridType = acGridView.emGridType.SEARCH;

            acGridView2.AddTextEdit("PART_CODE", "품목코드", "40239", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("PART_NAME", "품목명", "40234", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView2.AddLookUpEdit("MAT_LTYPE", "대분류", "40132", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M014");

            acGridView2.AddLookUpEdit("MAT_MTYPE", "중분류", "40630", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M015");

            acGridView2.AddLookUpEdit("MAT_STYPE", "소분류", "40338", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M016");

            acGridView2.AddTextEdit("DRAW_NO", "도면번호", "40145", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("MAT_SPEC", "규격", "AD1YYZ7Z", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddLookUpEdit("MAT_UNIT", "관리 단위", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M003");
            acGridView2.AddLookUpEdit("STK_UNIT", "재고 단위", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M022");
            acGridView2.AddTextEdit("PART_QTY", "재고 수량(재고)", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView2.AddTextEdit("OUT_QTY", "출하지시 요청 수량", "", false, DevExpress.Utils.HorzAlignment.Far, true, true, false, acGridView.emTextEditMask.QTY);
            acGridView2.Columns["OUT_QTY"].SummaryItem.SetSummary(DevExpress.Data.SummaryItemType.Sum, acGridView2.Columns["OUT_QTY"].DisplayFormat.ToString());
            acGridView2.AddTextEdit("SAFE_STK_QTY", "안전재고 수량", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView2.AddLookUpEdit("STOCK_LOC", "자재 창고", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M005");
            acGridView2.AddTextEdit("TOT_YPGO_AMT", "재고 금액", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);

            acGridView2.OptionsView.ShowFooter = true;           

            acGridView2.KeyColumn = new string[] { "PART_CODE" };

            acGridView3.GridType = acGridView.emGridType.SEARCH;

            acGridView3.AddTextEdit("PART_CODE", "품목코드", "40239", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView3.AddTextEdit("PART_NAME", "품목명", "40234", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView3.AddLookUpEdit("MAT_LTYPE", "대분류", "40132", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M014");

            acGridView3.AddLookUpEdit("MAT_MTYPE", "중분류", "40630", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M015");

            acGridView3.AddLookUpEdit("MAT_STYPE", "소분류", "40338", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M016");

            acGridView3.AddTextEdit("OUT_REQ_QTY", "출하지시 수량", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView3.AddTextEdit("OUT_QTY", "불출수량", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView3.AddTextEdit("SHIP_QTY", "출하된 수량", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);

            acGridView3.OptionsView.ShowFooter = true;

            acGridView3.KeyColumn = new string[] { "PART_CODE" };


            acGridView1.ShowGridMenuEx += acGridView1_ShowGridMenuEx;
            acGridView1.MouseDown += acGridView1_MouseDown;
            
            acGridView2.ShowGridMenuEx += acGridView2_ShowGridMenuEx;
            acGridView2.MouseDown += acGridView2_MouseDown;

            acLayoutControl2.OnValueChanged += acLayoutControl2_OnValueChanged;

            acLayoutControl2.OnValueKeyDown += acLayoutControl2_OnValueKeyDown;

        }

        private void acLayoutControl2_OnValueKeyDown(object sender, IBaseEditControl info, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                acSimpleButton1_Click(null, null);
            }
        }

        private void acLayoutControl2_OnValueChanged(object sender, IBaseEditControl info, object newValue)
        {
            try
            {
                acLayoutControl layout = sender as acLayoutControl;

                switch (info.ColumnName)
                {
                    case "MAT_LTYPE":

                        layout.GetEditor("MAT_MTYPE").Value = null;
                        layout.GetEditor("MAT_STYPE").Value = null;

                        if (newValue == null)
                        {
                            layout.GetEditor("MAT_MTYPE").Value = null;
                        }

                        (layout.GetEditor("MAT_MTYPE") as acLookupEdit).SetCode("M015", newValue);

                        break;

                    case "MAT_MTYPE":

                        layout.GetEditor("MAT_STYPE").Value = null;

                        if (newValue == null)
                        {
                            layout.GetEditor("MAT_STYPE").Value = null;
                        }


                        (layout.GetEditor("MAT_STYPE") as acLookupEdit).SetCode("M016", newValue);

                        break;

                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void acGridView1_MouseDown(object sender, MouseEventArgs e)
        {

            acGridView view = sender as acGridView;

            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                GridHitInfo hitInfo = view.CalcHitInfo(e.Location);

                if (hitInfo.HitTest == GridHitTest.RowCell || hitInfo.HitTest == GridHitTest.Row)
                {
                    DataRow focusRow = view.GetFocusedDataRow();

                    if (focusRow != null)
                    {
                        acGridView2.UpdateMapingRow(focusRow, true);
                        //acGridView2.AddRow(focusRow);
                        //acGridView1.DeleteMappingRow(focusRow);
                    }
                }

            }
        }
        private void acGridView1_ShowGridMenuEx(object sender, PopupMenuShowingEventArgs e)
        {
            try
            {
                acGridView view = sender as acGridView;

                if (e.HitInfo.HitTest == GridHitTest.EmptyRow || e.HitInfo.HitTest == GridHitTest.Row || e.HitInfo.HitTest == GridHitTest.RowCell)
                {
                    GridHitInfo hitInfo = view.CalcHitInfo(e.Point);

                    popdown.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    popDel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

                    popupMenu1.ShowPopup(view.GridControl.PointToScreen(e.Point));
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }


        private void acGridView2_MouseDown(object sender, MouseEventArgs e)
        {
            acGridView view = sender as acGridView;

            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                GridHitInfo hitInfo = view.CalcHitInfo(e.Location);

                if (hitInfo.HitTest == GridHitTest.RowCell || hitInfo.HitTest == GridHitTest.Row)
                {
                    DataRow focusRow = view.GetFocusedDataRow();

                    if (focusRow != null)
                    {
                        //acGridView1.UpdateMapingRow(focusRow, true);
                        acGridView2.DeleteRow(view.FocusedRowHandle);
                        //acGridView2.DeleteMappingRow(focusRow);
                    }
                }

            }
        }

        private void acGridView2_ShowGridMenuEx(object sender, PopupMenuShowingEventArgs e)
        {
            try
            {
                acGridView view = sender as acGridView;

                if (e.HitInfo.HitTest == GridHitTest.EmptyRow || e.HitInfo.HitTest == GridHitTest.Row || e.HitInfo.HitTest == GridHitTest.RowCell)
                {
                    GridHitInfo hitInfo = view.CalcHitInfo(e.Point);

                    popdown.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    popDel.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

                    popupMenu1.ShowPopup(view.GridControl.PointToScreen(e.Point));
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }


        public override void DialogInit()
        {
            acLayoutControl1.GetEditor("SHIP_QTY").Value = (this._linkData as DataRow)["SHIP_QTY"];

            //acLayoutControl2.GetEditor("PART_LIKE").Value = (this._linkData as DataRow)["PROD_NAME"];

            acLayoutControl2.GetEditor("MAT_LTYPE").Value = "22";

            acLayoutControl2.GetEditor("MAT_MTYPE").Value = null;

            acLayoutControl2.GetEditor("MAT_STYPE").Value = null;

            base.DialogInit();


        }

        public override void DialogInitComplete()
        {
            DataRow linkRow = _linkData as DataRow;

            DataTable dtSearch = new DataTable("RQSTDT");
            dtSearch.Columns.Add("PLT_CODE", typeof(String));
            dtSearch.Columns.Add("PROD_CODE", typeof(String));

            DataRow paramRow = dtSearch.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["PROD_CODE"] = linkRow["PROD_CODE"];

            dtSearch.Rows.Add(paramRow);

            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(dtSearch);

            DataSet resultSet = BizRun.QBizRun.ExecuteService(this, "ORD10A_SER4", paramSet, "RQSTDT", "RSLTDT");

            acGridView3.GridControl.DataSource = resultSet.Tables["RSLTDT"];

            base.DialogInitComplete();
        }

        public override void DialogNew()
        {


            base.DialogNew();
        }


        private void acBarButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //저장
            try
            {
                acGridView2.EndEditor();

                if (!acLayoutControl1.ValidCheck())
                    return;

                //this.OutputData = acLayoutControl1.CreateParameterRow();


                DataRow layoutRow = acLayoutControl1.CreateParameterRow();

                //this.DialogResult = DialogResult.OK;


                DataTable paramTable1 = new DataTable("RQSTDT");
                paramTable1.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable1.Columns.Add("PROD_CODE", typeof(String)); //
                paramTable1.Columns.Add("SHIP_QTY", typeof(int)); //
                //paramTable1.Columns.Add("SHIP_DATE", typeof(String)); //
                //paramTable1.Columns.Add("SHIP_EMP", typeof(String)); //
                //paramTable1.Columns.Add("PROD_LOCATION", typeof(String)); //
                //paramTable1.Columns.Add("SCOMMENT", typeof(String)); //
                paramTable1.Columns.Add("REG_EMP", typeof(String)); //

                DataRow linkRow = this._linkData as DataRow;

                //foreach (DataRow dr in selectedRows)
                
                    //if (linkRow["PROD_LOCATION"].isNullOrEmpty())
                    //{
                    //    acAlert.Show(this, "창고를 지정 해 주십시오.", acㄴAlertForm.enmType.Error);
                    //    return;
                    //}


                    DataRow paramRow1 = paramTable1.NewRow();
                    paramRow1["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow1["PROD_CODE"] = linkRow["PROD_CODE"];
                    //paramRow1["SHIP_QTY"] = linkRow["SHIP_QTY"];
                    //paramRow1["SHIP_DATE"] = layoutRow["SHIP_DATE"];
                    //paramRow1["SHIP_EMP"] = layoutRow["SHIP_EMP"];
                    //paramRow1["PROD_LOCATION"] = layoutRow["PROD_LOCATION"];
                    //paramRow1["SCOMMENT"] = layoutRow["SCOMMENT"];
                    paramRow1["REG_EMP"] = acInfo.UserID;

                    paramTable1.Rows.Add(paramRow1);
                

                DataTable dtParam = new DataTable("RQSTDT_STOCK");
                dtParam.Columns.Add("PLT_CODE", typeof(String));
                dtParam.Columns.Add("OUT_ID", typeof(String));
                dtParam.Columns.Add("OUT_REQ_ID", typeof(String));
                dtParam.Columns.Add("PART_CODE", typeof(String));
                dtParam.Columns.Add("PART_NAME", typeof(String));
                dtParam.Columns.Add("OUT_DATE", typeof(String));
                dtParam.Columns.Add("OUT_EMP", typeof(String));
                dtParam.Columns.Add("OUT_QTY", typeof(Int32));
                dtParam.Columns.Add("OUT_ORG", typeof(String));
                //dtParam.Columns.Add("SCOMMENT", typeof(String));
                dtParam.Columns.Add("OUT_REQ_QTY", typeof(Int32));
                dtParam.Columns.Add("O_OUT_QTY", typeof(Int32));
                dtParam.Columns.Add("OUT_LOC", typeof(String));
                dtParam.Columns.Add("OUT_REQ_EMP", typeof(String));
                dtParam.Columns.Add("PROD_CODE", typeof(String));
                dtParam.Columns.Add("REG_EMP", typeof(String));

                DataView view = acGridView2.GetDataView();

                for (int i = 0; i <  view.Count; i++)
                {
                    //if (view[i]["OUT_QTY"].toInt() > view[i]["PART_QTY"].toInt())
                    //{
                    //    acAlert.Show(this, "재고수량이 부족합니다.", acAlertForm.enmType.Warning);
                    //    return;
                    //}

                    DataRow drParam = dtParam.NewRow();

                    drParam["PLT_CODE"] = acInfo.PLT_CODE;
                    drParam["PROD_CODE"] = linkRow["PROD_CODE"];
                    drParam["PART_CODE"] = view[i]["PART_CODE"];
                    drParam["PART_NAME"] = view[i]["PART_NAME"];
                    //drParam["OUT_DATE"] = layoutRow["SHIP_DATE"];
                    //drParam["OUT_EMP"] = layoutRow["SHIP_EMP"];
                    drParam["OUT_QTY"] = view[i]["OUT_QTY"];
                    //drParam["OUT_ORG"] = selectedRow["OUT_ORG"];
                    //drParam["SCOMMENT"] = layoutRow["SCOMMENT"];
                    //drParam["OUT_REQ_QTY"] = view[i]["OUT_REQ_QTY"];
                    //drParam["O_OUT_QTY"] = view[i]["O_OUT_QTY"];
                    //drParam["OUT_LOC"] = layoutRow["PROD_LOCATION"];  //불출창고
                    //drParam["OUT_REQ_EMP"] = dr["OUT_REQ_EMP"];
                    drParam["REG_EMP"] = acInfo.UserID; ;
                    drParam["OUT_LOC"] = linkRow["PROD_CODE"]; 
                    paramRow1["SHIP_QTY"] = paramRow1["SHIP_QTY"].toDecimal() + view[i]["OUT_QTY"].toDecimal();
                    dtParam.Rows.Add(drParam);

                }

                if (dtParam.Rows.Count == 0)
                {
                    acAlert.Show(this, "선택된 상품,재고가 없습니다.", acAlertForm.enmType.Warning);
                    return;
                }


                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable1);
                paramSet.Tables.Add(dtParam);

                if (dsEmp != null)
                {
                    DataTable paramTable2 = dsEmp.Tables["RQSTDT2"].Copy();
                    paramSet.Tables.Add(paramTable2);
                }
                if (paramSet != null)
                {
                    acBarButtonItem1.Enabled = false;
                }

                BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.SAVE,
                "ORD10A_UPD", paramSet, "RQSTDT,RQSTDT_STOCK,RQSTDT2", "RSLTDT",
                QuickShip,
                QuickException);

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        private void popdown_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                acGridView1.EndEditor();

                DataRow[] selectedRows = acGridView1.GetSelectedDataRows();

                if (selectedRows.Length == 0)
                {
                    DataRow focusedrow = acGridView1.GetFocusedDataRow();
                    acGridView2.AddRow(focusedrow);
                    //acGridView2.UpdateMapingRow(focusedrow, true);

                }
                else
                {
                    DataTable dtData = acGridView2.GridControl.DataSource as DataTable;

                    foreach (DataRow dr in selectedRows)
                    {
                        //DataRow data = dtData.NewRow();
                        dtData.ImportRow(dr);
                        //data.ItemArray = dr.ItemArray;

                        //dtData.Rows.Add(data);
                        //DataRow newrow = dr.NewCopy();
                        //acGridView2.AddRow(newrow);
                        ////acGridView2.UpdateMapingRow(newrow, true);
                    }

                    acGridView1.ClearSelection();

                }

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void popDel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                acGridView2.EndEditor();

                DataRow[] selectedRows = acGridView2.GetSelectedDataRows();

                if (selectedRows.Length == 0)
                {
                    DataRow focusedrow = acGridView2.GetFocusedDataRow();
                    acGridView1.UpdateMapingRow(focusedrow, true);

                    acGridView2.DeleteMappingRow(focusedrow);
                }
                else
                {
                    foreach (DataRow dr in selectedRows)
                    {

                        acGridView1.UpdateMapingRow(dr, true);
                    }

                    acGridView2.DeleteSelectedRows();
                }


            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void acSimpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                DataRow layoutRow = acLayoutControl2.CreateParameterRow();

                DataTable dtSearch = new DataTable("RQSTDT");
                dtSearch.Columns.Add("PLT_CODE", typeof(String));
                dtSearch.Columns.Add("PART_LIKE", typeof(String));
                dtSearch.Columns.Add("SPEC_LIKE", typeof(String));
                dtSearch.Columns.Add("STK_LOC", typeof(String));
                dtSearch.Columns.Add("MAT_LTYPE", typeof(String));
                dtSearch.Columns.Add("MAT_MTYPE", typeof(String));
                dtSearch.Columns.Add("MAT_STYPE", typeof(String));

                DataRow paramRow = dtSearch.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["PART_LIKE"] = layoutRow["PART_LIKE"];
                paramRow["SPEC_LIKE"] = layoutRow["SPEC_LIKE"];
                paramRow["STK_LOC"] = layoutRow["STK_LOC"];
                paramRow["MAT_LTYPE"] = layoutRow["MAT_LTYPE"];
                paramRow["MAT_MTYPE"] = layoutRow["MAT_MTYPE"];
                paramRow["MAT_STYPE"] = layoutRow["MAT_STYPE"];

                dtSearch.Rows.Add(paramRow);

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(dtSearch);

                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD, "ORD10A_SER2", paramSet, "RQSTDT", "RSLTDT",
                            QuickSearch,
                            QuickException);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }


        void QuickSearch(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                acGridView1.GridControl.DataSource = e.result.Tables["RSLTDT"];
                base.SetLog(e.executeType, e.result.Tables["RSLTDT"].Rows.Count, e.executeTime);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void QuickException(object sender, QBiz qBiz, BizException ex)
        {
            acMessageBox.Show(this, ex);
        }


        void QuickShip(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                foreach (DataRow row in e.result.Tables["RQSTDT"].Rows)
                {
                    if (row["PROD_STATE"].ToString() == "9")
                    {
                        this._linkView.DeleteMappingRow(row);
                    }
                    else
                    {
                        DataRow[] rows = e.result.Tables["RSLTDT"].Select("PROD_CODE = '" + row["PROD_CODE"].ToString() + "'");
                        if(rows.Length == 1) this._linkView.UpdateMapingRow(rows[0], true);
                    }
                }

                //this.acGridView1.ClearSelection();
                this.Close();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        private void acSimpleButton2_Click(object sender, EventArgs e)
        {
            //담당자 추가
            if (!base.ChildFormContains("OUT_NEW"))
            {

                ORD10A_D1A frm = new ORD10A_D1A(dsEmp);

                frm.DialogMode = BaseMenuDialog.emDialogMode.OPEN;

                base.ChildFormAdd("OUT_NEW", frm);

                frm.ParentControl = this;

                //frm.Show(this);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    dsEmp = frm.OutputData as DataSet;
                    acLayoutControl1.GetEditor("OUT_EMP").Value = dsEmp.Tables["RQSTDT"].Rows[0]["OUT_EMP"];
                }

            }
            else
            {

                base.ChildFormFocus("OUT_NEW");

            }

        }

        private void acSimpleButton3_Click(object sender, EventArgs e)
        {
            //간편추가
            try
            {
                DataRow layoutRow = acLayoutControl1.CreateParameterRow();

                if (layoutRow["EMP_LIKE"].ToString() != "")
                {
                    DataTable paramTable = new DataTable("RQSTDT");
                    paramTable.Columns.Add("PLT_CODE", typeof(String));
                    paramTable.Columns.Add("EMP_LIKE", typeof(String));

                    DataRow paramRow = paramTable.NewRow();
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["EMP_LIKE"] = layoutRow["EMP_LIKE"];

                    paramTable.Rows.Add(paramRow);
                    DataSet paramSet = new DataSet();
                    paramSet.Tables.Add(paramTable);

                    DataSet resultSet = BizRun.QBizRun.ExecuteService(this, "STD06A_SER3", paramSet, "RQSTDT", "RSLTDT");

                    if (resultSet.Tables["RSLTDT"].Rows.Count == 0)
                    {
                        acAlert.Show(this, "등록된 사원이 없습니다.", acAlertForm.enmType.Info);
                        acLayoutControl1.GetEditor("EMP_LIKE").FocusEdit();
                        return;
                    }

                    if (resultSet.Tables["RSLTDT"].Rows.Count > 1)
                    {
                        //검색결과 여러명 검색됬을 경우
                        return;
                    }
                    else
                    {
                        //한명인 경우 바로 추가
                        if (dsEmp == null)
                        {
                            DataTable empTable = new DataTable("RQSTDT");
                            empTable.Columns.Add("OUT_EMP", typeof(string));

                            DataRow empRow = empTable.NewRow();
                            empRow["OUT_EMP"] = resultSet.Tables["RSLTDT"].Rows[0]["EMP_NAME"].ToString() + "(" + resultSet.Tables["RSLTDT"].Rows[0]["EMP_CODE"].ToString() + ")";
                            empTable.Rows.Add(empRow);

                            DataTable empTable2 = new DataTable("RQSTDT2");
                            empTable2.Columns.Add("PLT_CODE", typeof(string));
                            empTable2.Columns.Add("ORG_NAME", typeof(string));
                            empTable2.Columns.Add("EMP_CODE", typeof(string));
                            empTable2.Columns.Add("EMP_NAME", typeof(string));
                            empTable2.Columns.Add("SEL", typeof(string));

                            DataRow empRow2 = empTable2.NewRow();
                            empRow2["PLT_CODE"] = acInfo.PLT_CODE;
                            empRow2["ORG_NAME"] = resultSet.Tables["RSLTDT"].Rows[0]["ORG_NAME"];
                            empRow2["EMP_CODE"] = resultSet.Tables["RSLTDT"].Rows[0]["EMP_CODE"];
                            empRow2["EMP_NAME"] = resultSet.Tables["RSLTDT"].Rows[0]["EMP_NAME"];
                            empTable2.Rows.Add(empRow2);

                            DataSet empSet = new DataSet();
                            empSet.Tables.Add(empTable);
                            empSet.Tables.Add(empTable2);

                            dsEmp = empSet;

                            acLayoutControl1.GetEditor("OUT_EMP").Value = dsEmp.Tables["RQSTDT"].Rows[0]["OUT_EMP"];

                        }
                        else
                        {
                            DataRow[] empRows = dsEmp.Tables["RQSTDT2"].Select("EMP_CODE = '" + resultSet.Tables["RSLTDT"].Rows[0]["EMP_CODE"].ToString() + "'");

                            if (empRows.Length == 0)
                            {
                                string emps = dsEmp.Tables["RQSTDT"].Rows[0]["OUT_EMP"].ToString();

                                if (emps != "")
                                {
                                    emps = emps + ", ";
                                }

                                dsEmp.Tables["RQSTDT"].Rows[0]["OUT_EMP"] = emps + resultSet.Tables["RSLTDT"].Rows[0]["EMP_NAME"].ToString() + "(" + resultSet.Tables["RSLTDT"].Rows[0]["EMP_CODE"].ToString() + ")";

                                DataRow newEmpRow = dsEmp.Tables["RQSTDT2"].NewRow();
                                newEmpRow["PLT_CODE"] = acInfo.PLT_CODE;
                                newEmpRow["ORG_NAME"] = resultSet.Tables["RSLTDT"].Rows[0]["ORG_NAME"];
                                newEmpRow["EMP_CODE"] = resultSet.Tables["RSLTDT"].Rows[0]["EMP_CODE"];
                                newEmpRow["EMP_NAME"] = resultSet.Tables["RSLTDT"].Rows[0]["EMP_NAME"];
                                dsEmp.Tables["RQSTDT2"].Rows.Add(newEmpRow);

                                acLayoutControl1.GetEditor("OUT_EMP").Value = dsEmp.Tables["RQSTDT"].Rows[0]["OUT_EMP"];
                            }
                        }

                        acLayoutControl1.GetEditor("EMP_LIKE").Value = "";
                    }

                    

                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void acSimpleButton4_Click(object sender, EventArgs e)
        {
            //간편제거
            try
            {
                DataRow layoutRow = acLayoutControl1.CreateParameterRow();

                if (acLayoutControl1.GetEditor("EMP_LIKE").Value.ToString() != "")
                {
                    DataTable paramTable = new DataTable("RQSTDT");
                    paramTable.Columns.Add("PLT_CODE", typeof(String));
                    paramTable.Columns.Add("EMP_LIKE", typeof(String));

                    DataRow paramRow = paramTable.NewRow();
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["EMP_LIKE"] = layoutRow["EMP_LIKE"];

                    paramTable.Rows.Add(paramRow);
                    DataSet paramSet = new DataSet();
                    paramSet.Tables.Add(paramTable);

                    DataSet resultSet = BizRun.QBizRun.ExecuteService(this, "STD06A_SER3", paramSet, "RQSTDT", "RSLTDT");

                    if (resultSet.Tables["RSLTDT"].Rows.Count == 0)
                    {
                        acAlert.Show(this, "등록된 사원이 없습니다.", acAlertForm.enmType.Info);
                        acLayoutControl1.GetEditor("EMP_LIKE").FocusEdit();
                        return;
                    }

                    if (resultSet.Tables["RSLTDT"].Rows.Count > 1)
                    {
                        //검색결과 여러명 검색됬을 경우
                        return;
                    }
                    else
                    {
                        //한명인 경우 바로 제거
                        if (dsEmp != null)
                        {
                            DataRow[] empRows = dsEmp.Tables["RQSTDT2"].Select("EMP_CODE = '" + resultSet.Tables["RSLTDT"].Rows[0]["EMP_CODE"].ToString() + "'");

                            foreach (DataRow row in empRows)
                            {
                                dsEmp.Tables["RQSTDT2"].Rows.Remove(row);
                            }

                            string emps = "";
                            foreach (DataRow row in dsEmp.Tables["RQSTDT2"].Rows)
                            {
                                emps = row["EMP_NAME"].ToString() + "(" + row["EMP_CODE"].ToString() + ")" + ", ";
                            }

                            if (emps != "")
                            {
                                emps = emps.Substring(0, emps.Length - 2);
                            }

                            dsEmp.Tables["RQSTDT"].Rows[0]["OUT_EMP"] = emps;

                            acLayoutControl1.GetEditor("OUT_EMP").Value = emps;



                            //if (empRows.Length == 0)
                            //{
                            //    string emps = dsEmp.Tables["RQSTDT"].Rows[0]["OUT_EMP"].ToString();

                            //    if (emps != "")
                            //    {
                            //        emps = emps + ", ";
                            //    }

                            //    dsEmp.Tables["RQSTDT"].Rows[0]["OUT_EMP"] = emps + resultSet.Tables["RSLTDT"].Rows[0]["EMP_NAME"].ToString() + "(" + resultSet.Tables["RSLTDT"].Rows[0]["EMP_CODE"].ToString() + ")";

                            //    DataRow newEmpRow = dsEmp.Tables["RQSTDT2"].NewRow();
                            //    newEmpRow["PLT_CODE"] = acInfo.PLT_CODE;
                            //    newEmpRow["ORG_NAME"] = resultSet.Tables["RSLTDT"].Rows[0]["ORG_NAME"];
                            //    newEmpRow["EMP_CODE"] = resultSet.Tables["RSLTDT"].Rows[0]["EMP_CODE"];
                            //    newEmpRow["EMP_NAME"] = resultSet.Tables["RSLTDT"].Rows[0]["EMP_NAME"];
                            //    dsEmp.Tables["RQSTDT2"].Rows.Add(newEmpRow);

                            //    acLayoutControl1.GetEditor("OUT_EMP").Value = dsEmp.Tables["RQSTDT"].Rows[0]["OUT_EMP"];
                            //}

                            acLayoutControl1.GetEditor("EMP_LIKE").Value = "";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void acTextEdit5_KeyDown(object sender, KeyEventArgs e)
        {
            //추가 OR 제거
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    DataRow layoutRow = acLayoutControl1.CreateParameterRow();

                    if (acLayoutControl1.GetEditor("EMP_LIKE").Value.toStringEmpty() != "")
                    {
                        DataTable paramTable = new DataTable("RQSTDT");
                        paramTable.Columns.Add("PLT_CODE", typeof(String));
                        paramTable.Columns.Add("EMP_LIKE", typeof(String));

                        DataRow paramRow = paramTable.NewRow();
                        paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                        paramRow["EMP_LIKE"] = layoutRow["EMP_LIKE"];

                        paramTable.Rows.Add(paramRow);
                        DataSet paramSet = new DataSet();
                        paramSet.Tables.Add(paramTable);

                        DataSet resultSet = BizRun.QBizRun.ExecuteService(this, "STD06A_SER3", paramSet, "RQSTDT", "RSLTDT");

                        if (resultSet.Tables["RSLTDT"].Rows.Count == 0)
                        {
                            acAlert.Show(this, "등록된 사원이 없습니다.", acAlertForm.enmType.Info);
                            acLayoutControl1.GetEditor("EMP_LIKE").FocusEdit();
                            return;
                        }

                        if (resultSet.Tables["RSLTDT"].Rows.Count > 1)
                        {
                            //검색결과 여러명 검색됬을 경우
                            return;
                        }
                        else
                        {
                            if (dsEmp != null)
                            {
                                //있으면 제거 없으면 삭제
                                DataRow[] empRows = dsEmp.Tables["RQSTDT2"].Select("EMP_CODE = '" + resultSet.Tables["RSLTDT"].Rows[0]["EMP_CODE"].toStringEmpty() + "'");

                                if (empRows.Length > 0)
                                {
                                    foreach (DataRow row in empRows)
                                    {
                                        dsEmp.Tables["RQSTDT2"].Rows.Remove(row);
                                    }

                                    string emps = "";
                                    foreach (DataRow row in dsEmp.Tables["RQSTDT2"].Rows)
                                    {
                                        emps = row["EMP_NAME"].toStringEmpty() + "(" + row["EMP_CODE"].toStringEmpty() + ")" + ", ";
                                    }

                                    if (emps != "")
                                    {
                                        emps = emps.Substring(0, emps.Length - 2);
                                    }

                                    dsEmp.Tables["RQSTDT"].Rows[0]["OUT_EMP"] = emps;

                                    acLayoutControl1.GetEditor("OUT_EMP").Value = emps;
                                }
                                else if (empRows.Length == 0)
                                {
                                    string emps = dsEmp.Tables["RQSTDT"].Rows[0]["OUT_EMP"].toStringEmpty();

                                    if (emps != "")
                                    {
                                        emps = emps + ", ";
                                    }

                                    dsEmp.Tables["RQSTDT"].Rows[0]["OUT_EMP"] = emps + resultSet.Tables["RSLTDT"].Rows[0]["EMP_NAME"].toStringEmpty() + "(" + resultSet.Tables["RSLTDT"].Rows[0]["EMP_CODE"].toStringEmpty() + ")";

                                    DataRow newEmpRow = dsEmp.Tables["RQSTDT2"].NewRow();
                                    newEmpRow["PLT_CODE"] = acInfo.PLT_CODE;
                                    newEmpRow["ORG_NAME"] = resultSet.Tables["RSLTDT"].Rows[0]["ORG_NAME"];
                                    newEmpRow["EMP_CODE"] = resultSet.Tables["RSLTDT"].Rows[0]["EMP_CODE"];
                                    newEmpRow["EMP_NAME"] = resultSet.Tables["RSLTDT"].Rows[0]["EMP_NAME"];
                                    dsEmp.Tables["RQSTDT2"].Rows.Add(newEmpRow);

                                    acLayoutControl1.GetEditor("OUT_EMP").Value = dsEmp.Tables["RQSTDT"].Rows[0]["OUT_EMP"];
                                }
                            }
                            else
                            {
                                //dataset 없으면 바로추가
                                DataTable empTable = new DataTable("RQSTDT");
                                empTable.Columns.Add("OUT_EMP", typeof(string));

                                DataRow empRow = empTable.NewRow();
                                empRow["OUT_EMP"] = resultSet.Tables["RSLTDT"].Rows[0]["EMP_NAME"].toStringEmpty() + "(" + resultSet.Tables["RSLTDT"].Rows[0]["EMP_CODE"].toStringEmpty() + ")";
                                empTable.Rows.Add(empRow);

                                DataTable empTable2 = new DataTable("RQSTDT2");
                                empTable2.Columns.Add("PLT_CODE", typeof(string));
                                empTable2.Columns.Add("ORG_NAME", typeof(string));
                                empTable2.Columns.Add("EMP_CODE", typeof(string));
                                empTable2.Columns.Add("EMP_NAME", typeof(string));
                                empTable2.Columns.Add("SEL", typeof(string));

                                DataRow empRow2 = empTable2.NewRow();
                                empRow2["PLT_CODE"] = acInfo.PLT_CODE;
                                empRow2["ORG_NAME"] = resultSet.Tables["RSLTDT"].Rows[0]["ORG_NAME"];
                                empRow2["EMP_CODE"] = resultSet.Tables["RSLTDT"].Rows[0]["EMP_CODE"];
                                empRow2["EMP_NAME"] = resultSet.Tables["RSLTDT"].Rows[0]["EMP_NAME"];
                                empTable2.Rows.Add(empRow2);

                                DataSet empSet = new DataSet();
                                empSet.Tables.Add(empTable);
                                empSet.Tables.Add(empTable2);

                                dsEmp = empSet;

                                acLayoutControl1.GetEditor("OUT_EMP").Value = dsEmp.Tables["RQSTDT"].Rows[0]["OUT_EMP"];
                            }

                            acLayoutControl1.GetEditor("EMP_LIKE").Value = "";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }
    }
}