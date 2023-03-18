using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ControlManager;
using CodeHelperManager;
using DevExpress.XtraGrid.Views.Base;
using BizManager;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;

namespace MAT
{
    public partial class MAT04A_M0A : BaseMenu
    {
        public override acBarManager BarManager
        {

            get
            {
                return acBarManager1;
            }

        }

        public override string InstantLog
        {
            set
            {
                statusBarLog.Caption = value;
            }
        }

        public MAT04A_M0A()
        {
            InitializeComponent();
        }

        public override void MenuInit()
        {
            try
            {
                acGridView1.GridType = acGridView.emGridType.SEARCH;
                acGridView1.OptionsSelection.EnableAppearanceFocusedRow = false;
                //acGridView1.AddTextEdit("PROD_CODE", "내부관리번호", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView1.AddDateEdit("DUE_DATE", "출하예정일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
                acGridView1.AddTextEdit("PROD_CODE", "수주번호", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView1.AddLookUpEdit("PROD_FLAG", "수주유형", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P006");
                acGridView1.AddCheckedComboBoxEdit("PROD_CATEGORY", "제품유형", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, "P009");
                acGridView1.AddTextEdit("PROD_NAME", "모델명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView1.AddTextEdit("PROD_QTY", "수량", "CPW0FS8W", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NUMERIC);

                acGridView2.GridType = acGridView.emGridType.SEARCH;
                acGridView2.OptionsSelection.EnableAppearanceFocusedRow = false;
                acGridView2.AddCheckEdit("SEL", "선택", "", false, true, true, acGridView.emCheckEditDataType._STRING);
                acGridView2.AddTextEdit("OUT_ID", "불출ID", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
                acGridView2.AddTextEdit("PT_ID", "부품ID", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
                acGridView2.AddTextEdit("PART_CODE", "품목코드", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView2.AddTextEdit("PART_NAME", "품목명", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView2.AddLookUpEdit("MAT_LTYPE", "대분류", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M014");
                acGridView2.AddLookUpEdit("MAT_MTYPE", "중분류", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M015");
                acGridView2.AddLookUpEdit("MAT_STYPE", "소분류", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M016");
                acGridView2.AddTextEdit("DRAW_NO", "도면번호", "40145", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView2.AddLookUpEdit("PART_PRODTYPE", "형식", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M007");
                //acGridView2.AddLookUpPart("MAT_CODE", "소재", DevExpress.Utils.HorzAlignment.Center, false, true, false);
                acGridView2.AddTextEdit("PART_QTY", "BOM 수량", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
                acGridView2.AddTextEdit("RET_REQ_QTY", "재입고 수량", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
                acGridView2.AddTextEdit("OUT_QTY", "불출 수량", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
                acGridView2.AddTextEdit("STOCK_QTY", "재고 수량", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
                acGridView2.AddTextEdit("SAFE_STK_QTY", "안전재고", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);

                acGridView3.GridType = acGridView.emGridType.SEARCH;
                acGridView3.OptionsSelection.EnableAppearanceFocusedRow = false;
                acGridView3.AddCheckEdit("SEL", "선택", "", false, true, true, acGridView.emCheckEditDataType._STRING);
                acGridView3.AddTextEdit("OUT_ID", "불출ID", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
                acGridView3.AddTextEdit("PT_ID", "부품ID", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
                acGridView3.AddTextEdit("PART_CODE", "품목코드", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView3.AddTextEdit("PART_NAME", "품목명", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView3.AddLookUpEdit("MAT_LTYPE", "대분류", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M014");
                acGridView3.AddLookUpEdit("MAT_MTYPE", "중분류", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M015");
                acGridView3.AddLookUpEdit("MAT_STYPE", "소분류", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M016");
                acGridView3.AddTextEdit("DRAW_NO", "도면번호", "40145", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView3.AddLookUpEdit("PART_PRODTYPE", "형식", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M007");
                //acGridView3.AddLookUpPart("MAT_CODE", "소재", DevExpress.Utils.HorzAlignment.Center, false, true, false);
                acGridView3.AddTextEdit("PART_QTY", "BOM 수량", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
                acGridView3.AddTextEdit("OUT_QTY", "불출 수량", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
                acGridView3.AddTextEdit("RTN_QTY", "반납수량", "", false, DevExpress.Utils.HorzAlignment.Far, true, true, false, acGridView.emTextEditMask.QTY);
                acGridView3.AddTextEdit("MAT_COST", "자재 단가", "", false, DevExpress.Utils.HorzAlignment.Far, true, true, false, acGridView.emTextEditMask.F1);
                acGridView3.AddTextEdit("MAT_AMT", "자재 금액", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.F1);
                acGridView3.AddTextEdit("SCOMMENT", " 비고", "", false, DevExpress.Utils.HorzAlignment.Far, true, true, false, acGridView.emTextEditMask.NONE);

                acGridView4.GridType = acGridView.emGridType.SEARCH;
                acGridView4.OptionsSelection.EnableAppearanceFocusedRow = false;
                acGridView4.AddCheckEdit("SEL", "선택", "", false, true, true, acGridView.emCheckEditDataType._STRING);
                acGridView4.AddTextEdit("PT_ID", "부품ID", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
                acGridView4.AddTextEdit("PART_CODE", "품목코드", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView4.AddTextEdit("PART_NAME", "품목명", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView4.AddLookUpEdit("MAT_LTYPE", "대분류", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M014");
                acGridView4.AddLookUpEdit("MAT_MTYPE", "중분류", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M015");
                acGridView4.AddLookUpEdit("MAT_STYPE", "소분류", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M016");
                acGridView4.AddLookUpEdit("STOCK_LOC", "자재 창고", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M005");
                acGridView4.AddTextEdit("DRAW_NO", "도면번호", "40145", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView4.AddLookUpEdit("PART_PRODTYPE", "형식", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M007");
                acGridView4.AddTextEdit("RET_REQ_QTY", "반납수량", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
                acGridView4.AddTextEdit("SCOMMENT", " 비고", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);

                acGridView1.KeyColumn = new string[] { "PROD_CODE" };

                acGridView2.KeyColumn = new string[] { "PT_ID" };
                acGridView3.KeyColumn = new string[] { "PT_ID" };

                acGridView2.ShowGridMenuEx += AcGridView2_ShowGridMenuEx;
                acGridView3.ShowGridMenuEx += AcGridView3_ShowGridMenuEx;

                acGridView1.FocusedRowChanged += AcGridView1_FocusedRowChanged;

                //acGridView1.MouseDown += AcGridView1_MouseDown;
                acGridView2.MouseDown += AcGridView2_MouseDown;
                acGridView3.MouseDown += AcGridView3_MouseDown;

                acGridView3.CellValueChanging += acGridView3_CellValueChanging;

                acLayoutControl1.OnValueKeyDown += acLayoutControl1_OnValueKeyDown;

                (acLayoutControl1.GetEditor("STOCK_CODE") as acLookupEdit).SetCode("M005");
                (acLayoutControl2.GetEditor("STK_LOC") as acLookupEdit).SetCode("M005");
                
                acTabControl1.SelectedPageChanged += acTabControl1_SelectedPageChanged;

                base.MenuInit();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        private void acGridView3_CellValueChanging(object sender, CellValueChangedEventArgs e)
        {
            try
            {
                DataRow focusRow = acGridView3.GetDataRow(e.RowHandle);
                if (focusRow == null) return;

                decimal qty = focusRow["RTN_QTY"].toDecimal();
                decimal cost = focusRow["MAT_COST"].toDecimal();
                if (qty == 0) return;
                switch (e.Column.FieldName)
                {
                    case "MAT_COST":
                        {
                            focusRow["MAT_AMT"] = e.Value.toDecimal() * qty;
                        }
                        break;
                    case "RTN_QTY":
                        {
                            focusRow["MAT_AMT"] = e.Value.toDecimal() * cost;
                        }
                        break;
                }
            }
            catch (Exception ex)
            { }
        }

        private void AcGridView3_ShowGridMenuEx(object sender, PopupMenuShowingEventArgs e)
        {
            acGridView view = sender as acGridView;

            if (e.MenuType == GridMenuType.Row)
            {
                if (e.HitInfo.RowHandle >= 0)
                {
                    acBarButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                }
                else
                {
                    acBarButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

                }

            }
            else if (e.MenuType == GridMenuType.User)
            {
                acBarButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }

            if (e.HitInfo.HitTest == GridHitTest.EmptyRow || e.HitInfo.HitTest == GridHitTest.Row || e.HitInfo.HitTest == GridHitTest.RowCell)
            {

                GridHitInfo hitInfo = view.CalcHitInfo(e.Point);

                popupMenu2.ShowPopup(view.GridControl.PointToScreen(e.Point));
            }
        }

        private void AcGridView2_ShowGridMenuEx(object sender, PopupMenuShowingEventArgs e)
        {
            acGridView view = sender as acGridView;

            if (e.MenuType == GridMenuType.Row)
            {
                if (e.HitInfo.RowHandle >= 0)
                {
                    acBarButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                }
                else
                {
                    acBarButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

                }

            }
            else if (e.MenuType == GridMenuType.User)
            {
                acBarButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }

            if (e.HitInfo.HitTest == GridHitTest.EmptyRow || e.HitInfo.HitTest == GridHitTest.Row || e.HitInfo.HitTest == GridHitTest.RowCell)
            {

                GridHitInfo hitInfo = view.CalcHitInfo(e.Point);

                popupMenu1.ShowPopup(view.GridControl.PointToScreen(e.Point));
            }
        }

        private void AcGridView3_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Clicks == 2 && e.Button == MouseButtons.Left)
            {
                acBarButtonItem2_ItemClick(null, null);
            }
        }

        public override void ChildContainerInit(Control sender)
        {
            base.ChildContainerInit(sender);
        }

        private void AcGridView2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Clicks == 2 && e.Button == MouseButtons.Left)
            {
                acBarButtonItem1_ItemClick(null, null);
            }
        }

        private void AcGridView1_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            GetDetail();
        }

        void acLayoutControl1_OnValueKeyDown(object sender, IBaseEditControl info, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.Search();
        }

        void acTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            try
            {
                switch (acTabControl1.GetSelectedContainerName())
                {
                    case "B":

                        btnReqBan.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        btnReqCancel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        break;

                    case "BL":

                        btnReqBan.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        btnReqCancel.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        break;
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void Search()
        {
            try
            {
                switch (acTabControl1.GetSelectedContainerName())
                {
                    case "B":
                        {
                            if (acLayoutControl1.ValidCheck() == false) return;

                            DataRow layoutRow = acLayoutControl1.CreateParameterRow();

                            DataTable dtSearch = new DataTable("RQSTDT");
                            dtSearch.Columns.Add("PLT_CODE", typeof(String));
                            dtSearch.Columns.Add("PROD_LIKE", typeof(String));
                            dtSearch.Columns.Add("PART_LIKE", typeof(String));
                            dtSearch.Columns.Add("SPEC_LIKE", typeof(String));
                            dtSearch.Columns.Add("STOCK_CODE", typeof(String));

                            DataRow paramRow = dtSearch.NewRow();
                            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                            paramRow["PROD_LIKE"] = layoutRow["PROD_LIKE"];
                            paramRow["PART_LIKE"] = layoutRow["PART_LIKE"];
                            paramRow["SPEC_LIKE"] = layoutRow["SPEC_LIKE"];
                            paramRow["STOCK_CODE"] = layoutRow["STOCK_CODE"];
                            dtSearch.Rows.Add(paramRow);

                            DataSet paramSet = new DataSet();
                            paramSet.Tables.Add(dtSearch);

                            BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD, "MAT04A_SER", paramSet, "RQSTDT", "RSLTDT",
                                        QuickSearch,
                                        QuickException);
                            break;
                        }
                    case "BL":
                        {
                            DataRow layoutRow = acLayoutControl2.CreateParameterRow();

                            DataTable dtSearch = new DataTable("RQSTDT");
                            dtSearch.Columns.Add("PLT_CODE", typeof(String));
                            dtSearch.Columns.Add("PART_LIKE", typeof(String));
                            dtSearch.Columns.Add("SPEC_LIKE", typeof(String));
                            dtSearch.Columns.Add("STK_LOC", typeof(String));

                            DataRow paramRow = dtSearch.NewRow();
                            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                            paramRow["PART_LIKE"] = layoutRow["PART_LIKE"];
                            paramRow["SPEC_LIKE"] = layoutRow["SPEC_LIKE"];
                            paramRow["STK_LOC"] = layoutRow["STK_LOC"];

                            dtSearch.Rows.Add(paramRow);

                            DataSet paramSet = new DataSet();
                            paramSet.Tables.Add(dtSearch);

                            BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD, "MAT04A_SER3", paramSet, "RQSTDT", "RSLTDT",
                                        QuickSearch3,
                                        QuickException);
                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void GetDetail()
        {
            try
            {

                DataRow focusRow = acGridView1.GetFocusedDataRow();
                if (focusRow == null) return;

                DataTable dtSearch = new DataTable("RQSTDT");
                dtSearch.Columns.Add("PLT_CODE", typeof(String));
                dtSearch.Columns.Add("PROD_CODE", typeof(String));

                DataRow paramRow = dtSearch.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["PROD_CODE"] = focusRow["PROD_CODE"];
                dtSearch.Rows.Add(paramRow);

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(dtSearch);

                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD, "MAT04A_SER2", paramSet, "RQSTDT", "RSLTDT",
                            QuickSearch2,
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
                if(acGridView1.DataRowCount == 0)
                {
                    acGridView2.ClearRow();
                }
                
                base.SetLog(e.executeType, e.result.Tables["RSLTDT"].Rows.Count, e.executeTime);
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
                DataRow[] rows = e.result.Tables["RSLTDT"].Select("RET_REQ_QTY < OUT_QTY");
                if (rows.Length > 0)
                    acGridView2.GridControl.DataSource = rows.CopyToDataTable();
                else
                    acGridView2.GridControl.DataSource = null;

                    base.SetLog(e.executeType, e.result.Tables["RSLTDT"].Rows.Count, e.executeTime);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void QuickSearch3(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                acGridView4.GridControl.DataSource = e.result.Tables["RSLTDT"];
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


        private void barItemRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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

        private void btnReqBan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                acGridView3.EndEditor();

                if (acGridView3.GetSelectedDataRows().Length == 0)
                {
                    acAlert.Show(this, "반납 목록이 없습니다.", acAlertForm.enmType.Warning);
                    return;
                }

                if (acGridView3.ValidCheck() == false)
                {
                    return;
                }


                DataRow layoutRow = acLayoutControl1.CreateParameterRow();

                MAT04A_D0A frm = new MAT04A_D0A(layoutRow);

                frm.ParentControl = this;

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    DataRow frmRow = (DataRow)frm.OutputData;

                    acGridView3.EndEditor();

                    DataTable dtParam = new DataTable("RQSTDT");
                    dtParam.Columns.Add("PLT_CODE", typeof(String));
                    dtParam.Columns.Add("OUT_ID", typeof(String));
                    dtParam.Columns.Add("PT_ID", typeof(String));
                    dtParam.Columns.Add("RET_REQ_ID", typeof(String));
                    dtParam.Columns.Add("PART_CODE", typeof(String));
                    dtParam.Columns.Add("STOCK_LOC", typeof(String));
                    dtParam.Columns.Add("RET_REQ_DATE", typeof(String));
                    dtParam.Columns.Add("RET_REQ_EMP", typeof(String));
                    dtParam.Columns.Add("RET_REQ_QTY", typeof(int));
                    dtParam.Columns.Add("RET_REQ_STAT", typeof(String));
                    dtParam.Columns.Add("PART_NAME", typeof(String));
                    dtParam.Columns.Add("REG_EMP", typeof(String));
                    dtParam.Columns.Add("SCOMMENT", typeof(String));


                    dtParam.Columns.Add("MAT_COST", typeof(decimal));
                    dtParam.Columns.Add("MAT_AMT", typeof(decimal));
                    dtParam.Columns.Add("YPGO_COST", typeof(decimal));
                    dtParam.Columns.Add("YPGO_AMT", typeof(decimal));
                    dtParam.Columns.Add("STK_LOCATION", typeof(string));
                    dtParam.Columns.Add("QTY", typeof(int));
                    dtParam.Columns.Add("YPGO_ID", typeof(String));
                    dtParam.Columns.Add("YPGO_DATE", typeof(string));

                    DataTable dtSource = acGridView3.GridControl.DataSource as DataTable;

                    foreach (DataRow dr in dtSource.Select())
                    {

                        if (dr["RTN_QTY"].toInt() <= 0)
                        {
                            acAlert.Show(this, "반납 수량을 입력해주세요.", acAlertForm.enmType.Warning);
                            return;
                        }

                        DataRow drParam = dtParam.NewRow();

                        drParam["PLT_CODE"] = acInfo.PLT_CODE;
                        drParam["OUT_ID"] = dr["OUT_ID"];
                        drParam["PT_ID"] = dr["PT_ID"];
                        drParam["PART_CODE"] = dr["PART_CODE"];
                        drParam["STOCK_LOC"] = frmRow["STOCK_LOC"];
                        drParam["RET_REQ_DATE"] = frmRow["RET_REQ_DATE"];
                        drParam["RET_REQ_EMP"] = frmRow["RET_REQ_EMP"];
                        drParam["RET_REQ_QTY"] = dr["RTN_QTY"];
                        //drParam["RET_REQ_STAT"] = "49";//반납요청
                        drParam["RET_REQ_STAT"] = "22";//재입고
                        drParam["SCOMMENT"] = dr["SCOMMENT"];
                        drParam["PART_NAME"] = dr["PART_NAME"];
                        drParam["REG_EMP"] = acInfo.UserID;


                        drParam["MAT_COST"] = dr["MAT_COST"];
                        drParam["MAT_AMT"] = dr["MAT_AMT"];
                        drParam["YPGO_DATE"] = frmRow["RET_REQ_DATE"];
                        drParam["QTY"] = dr["RTN_QTY"];
                        drParam["YPGO_COST"] = dr["MAT_COST"];
                        drParam["YPGO_AMT"] = dr["MAT_AMT"];
                        drParam["STK_LOCATION"] = frmRow["STOCK_LOC"];


                        dtParam.Rows.Add(drParam);

                        
                    }

                    DataSet paramSet = new DataSet();
                    paramSet.Tables.Add(dtParam);

                    BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.SAVE, "MAT04A_INS", paramSet, "RQSTDT", "RSLTDT",
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
                //foreach(DataRow row in e.result.Tables["RSLTDT"].Rows)
                //{
                //    acGridView3.UpdateMapingRow(row, true);
                //}

                //acGridView2.DeleteMappingRowLinq(e.result.Tables["RQSTDT"]);

                acGridView3.ClearRow();

                acAlert.Show(this, "반납 완료", acAlertForm.enmType.Success);

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }
        private void btnReqCancel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                acGridView4.EndEditor();

                DataRow focusRow = acGridView4.GetFocusedDataRow();

                if (focusRow == null)
                {
                    return;
                }

                DataView selectedView = acGridView4.GetDataSourceView("SEL = '1'");

                //if (selectedView.Count == 0)
                //{
                //    acAlert.Show(this, "반납 취소 목록이 없습니다.", acAlertForm.enmType.Warning);
                //    return;
                //}

                if (acMessageBox.Show(this, "반납 취소 하시겠습니까?", "", false, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
                {
                    return;
                }

                DataTable dtParam = new DataTable("RQSTDT");
                dtParam.Columns.Add("PLT_CODE", typeof(String));
                dtParam.Columns.Add("RET_REQ_ID", typeof(String));


                for (int i = 0; i < selectedView.Count; i++)
                {
                    DataRow drParam = dtParam.NewRow();

                    drParam["PLT_CODE"] = acInfo.PLT_CODE;
                    drParam["RET_REQ_ID"] = selectedView[i]["RET_REQ_ID"];
                    dtParam.Rows.Add(drParam);
                }

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(dtParam);

                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.SAVE, "MAT04A_DEL", paramSet, "RQSTDT", "RSLTDT",
                            QuickDel,
                            QuickException);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void QuickDel(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                foreach (DataRow row in e.result.Tables["RQSTDT"].Rows)
                {
                    acGridView4.DeleteMappingRow(row);
                }

                acAlert.Show(this, "요청 취소 완료", acAlertForm.enmType.Success);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        private void acBarButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                acGridView2.EndEditor();
                DataView selView = acGridView2.GetDataSourceView("SEL='1'");

                if (selView.Count == 0)
                {
                    DataRow focusRow = acGridView2.GetFocusedDataRow();

                    if (focusRow == null) return;
                    acGridView3.UpdateMapingRow(focusRow, true);
                }
                else
                {
                    foreach (DataRowView row in selView)
                    {
                        acGridView3.UpdateMapingRow(row.Row, true);
                    }
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void acBarButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                acGridView3.EndEditor();
                    DataView selView = acGridView3.GetDataSourceView("SEL='1'");

                if (selView.Count == 0)
                {
                    acGridView3.DeleteSelectedRows();
                }
                else
                {
                    foreach (DataRowView row in selView)
                    {
                        acGridView3.DeleteMappingRow(row.Row);
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
