using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using ControlManager;
using BizManager;

using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraGrid.Columns;

namespace HIS
{
    public sealed partial class HIS03A_M0A : BaseMenu
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

        public override string InstantLog
        {
            set
            {
                statusBarLog.Caption = value;
            }
        }

        public HIS03A_M0A()
        {
            InitializeComponent();

            acLayoutControl1.OnValueChanged += acLayoutControl1_OnValueChanged;
            acLayoutControl1.OnValueKeyDown += acLayoutControl1_OnValueKeyDown;

            acGridView1.FocusedRowChanged += AcGridView1_FocusedRowChanged;
            acGridView2.ShowGridMenuEx += AcGridView2_ShowGridMenuEx;
            acGridView3.ShowGridMenuEx += AcGridView3_ShowGridMenuEx;
            acGridView4.ShowGridMenuEx += AcGridView4_ShowGridMenuEx;

            acGridView3.CustomDrawCell += AcGridView3_CustomDrawCell;

            acGridView2.MouseDown += new MouseEventHandler(acGridView2_MouseDown);
            acGridView3.MouseDown += new MouseEventHandler(acGridView3_MouseDown);
            acGridView4.MouseDown += new MouseEventHandler(acGridView4_MouseDown);

            acGridView3.CellMerge += AcGridView3_CellMerge;
        }

        private void AcGridView3_CellMerge(object sender, CellMergeEventArgs e)
        {
            try
            {
                switch (e.Column.FieldName)
                {
                    case "PART_CODE":
                    case "PART_NAME":
                    case "USE_QTY":
                    case "SCOMMENT":
                        return;
                }

                acGridView view = sender as acGridView;
                if (view == null) return;

                DataRow row1 = view.GetDataRow(e.RowHandle1);
                DataRow row2 = view.GetDataRow(e.RowHandle2);

                if(row1["MTN_CODE"].ToString().Equals(row2["MTN_CODE"])
                && row1["PLN_DATE"].toDateString("yyyyMMdd").Equals(row2["PLN_DATE"].toDateString("yyyyMMdd")))
                {
                    e.Merge = true;
                }
                else
                {
                    e.Merge = false;
                }
                
                e.Handled = true;
            }
            catch{ }
        }

        private void AcGridView3_ShowGridMenuEx(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            if(acGridView1.FocusedRowHandle < 0)
            {
                return;
            }

            if (e.MenuType == GridMenuType.User)
            {

                btnPlanOpen.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                btnPlanDel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            }
            else if (e.MenuType == GridMenuType.Row)
            {
                if (e.HitInfo.RowHandle >= 0)
                {
                    btnPlanOpen.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    btnPlanDel.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                }
                else
                {

                    btnPlanOpen.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    btnPlanDel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                }

            }


            if (e.HitInfo.HitTest == GridHitTest.EmptyRow || e.HitInfo.HitTest == GridHitTest.Row || e.HitInfo.HitTest == GridHitTest.RowCell)
            {
                GridHitInfo hitInfo = acGridView3.CalcHitInfo(e.Point);
                popupMenu2.ShowPopup(acGridView3.GridControl.PointToScreen(e.Point));
            }
        }


        private void AcGridView4_ShowGridMenuEx(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            if (acGridView1.FocusedRowHandle < 0)
            {
                return;
            }

            if (e.MenuType == GridMenuType.User)
            {

                acBarButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                acBarButtonItem3.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            }
            else if (e.MenuType == GridMenuType.Row)
            {
                if (e.HitInfo.RowHandle >= 0)
                {
                    acBarButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    acBarButtonItem3.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                }
                else
                {

                    acBarButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    acBarButtonItem3.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                }

            }

            if (e.HitInfo.HitTest == GridHitTest.EmptyRow || e.HitInfo.HitTest == GridHitTest.Row || e.HitInfo.HitTest == GridHitTest.RowCell)
            {
                GridHitInfo hitInfo = acGridView4.CalcHitInfo(e.Point);
                popupMenu3.ShowPopup(acGridView4.GridControl.PointToScreen(e.Point));
            }
        }




        void acGridView2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                GridHitInfo hitInfo = acGridView2.CalcHitInfo(e.Location);

                if (hitInfo.HitTest == GridHitTest.RowCell || hitInfo.HitTest == GridHitTest.Row)
                {
                    //돌발수리 열기
                    this.btnActOpen_ItemClick(null, null);
                }

            }
        }



        void acGridView3_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                GridHitInfo hitInfo = acGridView3.CalcHitInfo(e.Location);

                if (hitInfo.HitTest == GridHitTest.RowCell || hitInfo.HitTest == GridHitTest.Row)
                {
                    //계획수리 열기

                    this.btnPlanAct_ItemClick(null, null);
                }

            }
        }



        void acGridView4_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                GridHitInfo hitInfo = acGridView4.CalcHitInfo(e.Location);

                if (hitInfo.HitTest == GridHitTest.RowCell || hitInfo.HitTest == GridHitTest.Row)
                {
                    //점검항목 편집기 열기

                    this.acBarButtonItem2_ItemClick(null, null);
                }

            }
        }


        private void AcGridView3_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            try
            {
                DataRow row = acGridView3.GetDataRow(e.RowHandle);

                if(row != null
                    && row.Table.Columns.Contains("IS_CANCEL_DEL")
                    && row["IS_CANCEL_DEL"].Equals("1"))
                {
                    e.Appearance.BackColor = Color.Orange;
                }
            }
            catch
            { }
        }

        private void AcGridView2_ShowGridMenuEx(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {

            if (acGridView1.FocusedRowHandle < 0)
            {
                return;
            }

            if (e.MenuType == GridMenuType.User)
            {

                btnActOpen.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                btnActDel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            }
            else if (e.MenuType == GridMenuType.Row)
            {
                if (e.HitInfo.RowHandle >= 0)
                {
                    btnActOpen.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    btnActDel.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                }
                else
                {

                    btnActOpen.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    btnActDel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                }

            }

            if (e.HitInfo.HitTest == GridHitTest.EmptyRow || e.HitInfo.HitTest == GridHitTest.Row || e.HitInfo.HitTest == GridHitTest.RowCell)
            {
                GridHitInfo hitInfo = acGridView2.CalcHitInfo(e.Point);
                popupMenu1.ShowPopup(acGridView2.GridControl.PointToScreen(e.Point));
            }
        }

        private void AcGridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            this.SearchDetail();
        }

        void acLayoutControl1_OnValueChanged(object sender, IBaseEditControl info, object newValue)
        {
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

        void acLayoutControl1_OnValueKeyDown(object sender, IBaseEditControl info, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                this.Search();
            }
        }

        public override void ChildContainerInit(Control sender)
        {

            if (sender == acLayoutControl1)
            {
                acLayoutControl layout = sender as acLayoutControl;
            }

            base.ChildContainerInit(sender);
        }

        public override bool MenuDestory(object sender)
        {
            return base.MenuDestory(sender);
        }

        public override void MenuGotFocus()
        {
            base.MenuGotFocus();
        }

        public override void MenuLostFocus()
        {
            base.MenuLostFocus();
        }

        public override void MenuInit()
        {
            try
            {
                acGridView1.GridType = acGridView.emGridType.AUTO_COL;
                acGridView1.AddTextEdit("MC_CODE", "설비 코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView1.AddTextEdit("MC_NAME", "설비명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView1.AddLookUpVendor("MC_MAKER", "제조사", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false);

                acGridView1.KeyColumn = new string[] { "MC_CODE" };

                acGridView2.AddDateEdit("PM_DATE", "수리일자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
                acGridView2.AddLookUpEdit("PM_GUBUN", "보전 구분", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "H002");
                acGridView2.AddMemoEdit("PM_CONTENTS", "보전 내용", "", false, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, false, true, true,false);
                acGridView2.AddTextEdit("PART_SUPPLY", "부품수급일", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NUMERIC);
                acGridView2.AddTextEdit("PM_TIME", "수리시간", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NUMERIC);
                acGridView2.AddTextEdit("PM_COST", "비용", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
                acGridView2.AddLookUpVendor("PM_VND", "외주업체", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false);
                acGridView2.AddTextEdit("PM_CHARGE", "담당자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

                acGridView2.KeyColumn = new string[] { "PM_ACT_CODE" };


                acGridView3.AddDateEdit("PLN_DATE", "계획일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
                acGridView3.AddTextEdit("MTN_CODE", "보전항목코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView3.AddTextEdit("MTN_NAME", "보전항목명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView3.AddDateEdit("PM_DATE", "수리일", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emDateMask.SHORT_DATE);
                acGridView3.AddLookUpEdit("PM_GUBUN", "보전 구분", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "H002");
                acGridView3.AddMemoEdit("PM_CONTENTS", "보전 내용", "", false, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, false, true, true, false);
                acGridView3.AddTextEdit("PART_SUPPLY", "부품수급일", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NUMERIC);
                acGridView3.AddTextEdit("PM_TIME", "수리시간", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NUMERIC);
                acGridView3.AddTextEdit("PM_COST", "비용", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
                acGridView3.AddLookUpVendor("PM_VND", "외주업체", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false);
                acGridView3.AddTextEdit("PM_CHARGE", "담당자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView3.AddTextEdit("PART_CODE", "부품코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView3.AddTextEdit("PART_NAME", "부품명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView3.AddTextEdit("USE_QTY", "수량", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView3.AddTextEdit("SCOMMENT", "비고", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

                foreach(GridColumn col in acGridView3.Columns)
                {
                    switch(col.FieldName)
                    {
                        case "PART_CODE":
                        case "PART_NAME":
                        case "USE_QTY":
                        case "SCOMMENT":
                            continue;
                    }

                    col.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
                }

                acGridView3.OptionsView.AllowCellMerge = true;

                acGridView3.KeyColumn = new string[] { "MTN_CODE", "MC_CODE", "PLN_DATE"};

                acGridView3.Columns["PLN_DATE"].SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;

                acGridView4.AddDateEdit("INS_DATE", "점검일자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
                acGridView4.AddTextEdit("OK_QTY", "적합건수", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView4.AddTextEdit("NG_QTY", "부적합건수", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView4.AddLookUpEmp("INS_CHARGE", "담당자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false);
                acGridView4.AddLookUpEmp("MC_CODE", "설비코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false);


                acGridView4.KeyColumn = new string[] { "INS_DATE", "INS_CHARGE" };

                (acLayoutControl3.GetEditor("MC_GROUP") as acLookupEdit).SetCode("C020");

                base.MenuInit();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
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

        void Search()
        {
            DataRow layoutRow = acLayoutControl1.CreateParameterRow();

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("MC_LIKE", typeof(String)); //
            //paramTable.Columns.Add("MC_GROUP", typeof(String)); //
            paramTable.Columns.Add("SERIAL_NO_LIKE", typeof(String)); //
            paramTable.Columns.Add("S_REG_DATE", typeof(String)); //
            paramTable.Columns.Add("E_REG_DATE", typeof(String)); //
            
            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["MC_LIKE"] = layoutRow["MC_LIKE"];
            //paramRow["MC_GROUP"] = "MCT";
            paramRow["SERIAL_NO_LIKE"] = layoutRow["SERIAL_NO_LIKE"];
            foreach (string key in cboDate.GetKeyChecked())
            {
                switch (key)
                {
                    case "REG_DATE":

                        paramRow["S_REG_DATE"] = layoutRow["S_DATE"];
                        paramRow["E_REG_DATE"] = layoutRow["E_DATE"];

                        break;

                }

            }
            paramTable.Rows.Add(paramRow);

            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);


            BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD, "HIS03A_SER1", paramSet, "RQSTDT", "RSLTDT",
              QuickSearch,
              QuickException);
        }


        void QuickSearch(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                acGridView1.GridControl.DataSource = e.result.Tables["RSLTDT"];
                acGridView1.BestFitColumns();
                base.SetLog(e.executeType, e.result.Tables["RSLTDT"].Rows.Count, e.executeTime);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        void SearchDetail()
        {
            try
            {
                if (acGridView1.GetFocusedDataRow() is DataRow focusRow)
                {
                    DataSet paramSet = new DataSet();
                    DataTable paramTable = paramSet.Tables.Add("RQSTDT");
                    paramTable.Columns.Add("PLT_CODE", typeof(String));
                    paramTable.Columns.Add("MC_CODE", typeof(String));

                    DataRow paramRow = paramTable.NewRow();
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["MC_CODE"] = focusRow["MC_CODE"];
                    paramTable.Rows.Add(paramRow);

                    BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD, "HIS03A_SER2", paramSet, "RQSTDT", "RSLTDT",
                      QuickSearchDetail,
                      QuickException);
                }
            }catch(Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }


        void QuickSearchDetail(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                e.result.Tables["RSLTDT_PLAN"].Columns.Add("IS_CANCEL_DEL", typeof(String));

                acGridView2.GridControl.DataSource = e.result.Tables["RSLTDT_ACT"];
                acGridView3.GridControl.DataSource = e.result.Tables["RSLTDT_PLAN"];
                acGridView4.GridControl.DataSource = e.result.Tables["RSLTDT_INS"];
                acLayoutControl3.GetEditor("MC_IMAGE").Value = null;
                foreach (DataRow row in e.result.Tables["RSLTDT"].Rows)
                {
                    acLayoutControl3.DataBind(row, false);
                }
                base.SetLog(e.executeType, e.result.Tables["RSLTDT"].Rows.Count, e.executeTime);
               
                acGridView4.BestFitColumns();
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

        private void btnAct_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                DataRow focusRow = acGridView1.GetFocusedDataRow();

                if (!base.ChildFormContains(focusRow["MC_CODE"] ))
                {
                    HIS03A_D0A frm = new HIS03A_D0A(acGridView2, focusRow);
                    frm.DialogMode = BaseMenuDialog.emDialogMode.NEW;
                    frm.ParentControl = this;
                    base.ChildFormAdd(focusRow["MC_CODE"], frm);
                    frm.ShowDialog(this);
                }
                else
                {
                    base.ChildFormFocus(focusRow["MC_CODE"] );
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void btnActOpen_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            try
            {
                DataRow focusRow = acGridView2.GetFocusedDataRow();

                if(focusRow == null)
                {
                    acMessageBox.Show(this, "대상을 선택해주세요.", "", false, acMessageBox.emMessageBoxType.CONFIRM);
                    return;
                }

                if (!base.ChildFormContains(focusRow["MC_CODE"]))
                {
                    HIS03A_D0A frm = new HIS03A_D0A(acGridView2, focusRow);
                    frm.DialogMode = BaseMenuDialog.emDialogMode.OPEN;
                    frm.ParentControl = this;
                    base.ChildFormAdd(focusRow["MC_CODE"], frm);
                    frm.ShowDialog(this);
                }
                else
                {
                    base.ChildFormFocus(focusRow["MC_CODE"]);
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void btnActDel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                DataRow focusRow = acGridView2.GetFocusedDataRow();

                if(focusRow == null)
                {
                    acMessageBox.Show(this, "대상을 선택해주세요.", "", false, acMessageBox.emMessageBoxType.CONFIRM);
                    return;
                }

                if (acMessageBox.Show(this, "정말 삭제하시겠습니까?", "", false, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
                {
                    return;
                }

                DataSet paramSet = new DataSet();
                DataTable paramTable = paramSet.Tables.Add("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String));
                paramTable.Columns.Add("PM_ACT_CODE", typeof(String));

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["PM_ACT_CODE"] = focusRow["PM_ACT_CODE"];
                paramTable.Rows.Add(paramRow);

                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.DEL, "HIS03A_DEL", paramSet, "RQSTDT", "RSLTDT",
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
                foreach(DataRow row in e.result.Tables["RQSTDT"].Rows)
                {
                    acGridView2.DeleteMappingRow(row);
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        void QuickDel2(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                foreach (DataRow row in e.result.Tables["RQSTDT"].Rows)
                {
                    acGridView4.DeleteMappingRow(row);
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }


        private void btnPlanAct_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                DataRow focusRow = acGridView3.GetFocusedDataRow();

                if (focusRow == null)
                {
                    acMessageBox.Show(this, "대상을 선택해주세요.", "", false, acMessageBox.emMessageBoxType.CONFIRM);
                    return;
                }

                if (!base.ChildFormContains(focusRow["MC_CODE"]))
                {
                    HIS03A_D1A frm = new HIS03A_D1A(acGridView3, focusRow);
                    frm.DialogMode = BaseMenuDialog.emDialogMode.OPEN;
                    frm.ParentControl = this;
                    base.ChildFormAdd(focusRow["MC_CODE"], frm);
                    frm.ShowDialog(this);
                }
                else
                {
                    base.ChildFormFocus(focusRow["MC_CODE"]);
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void btnPlanDel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                DataRow focusRow = acGridView3.GetFocusedDataRow();

                if (focusRow == null)
                {
                    acMessageBox.Show(this, "대상을 선택해주세요.", "", false, acMessageBox.emMessageBoxType.CONFIRM);
                    return;
                }

                if (acMessageBox.Show(this, "정말 삭제하시겠습니까?", "", false, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
                {
                    return;
                }

                DataSet paramSet = new DataSet();
                DataTable paramTable = paramSet.Tables.Add("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String));
                paramTable.Columns.Add("MTN_CODE", typeof(String));
                paramTable.Columns.Add("MC_CODE", typeof(String));
                paramTable.Columns.Add("PLN_DATE", typeof(String));

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["MTN_CODE"] = focusRow["MTN_CODE"];
                paramRow["MC_CODE"] = focusRow["MC_CODE"];
                paramRow["PLN_DATE"] = focusRow["PLN_DATE"].toDateString("yyyyMMdd");
                paramTable.Rows.Add(paramRow);

                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.DEL, "HIS03A_DEL2", paramSet, "RQSTDT", "RSLTDT",
                      QuickPlanDel,
                      QuickException);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void QuickPlanDel(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                int isCancelDelCnt = 0;
                foreach (DataRow row in e.result.Tables["RQSTDT"].Rows)
                {
                    if (row["IS_CANCEL_DEL"].toStringEmpty().Equals("1"))
                    {
                        isCancelDelCnt++;
                        acGridView3.UpdateMapingRow(row,false);
                    }
                    else
                    {
                        //acGridView3.DeleteMappingRow(row);
                        while(acGridView3.GetDataRow("MTN_CODE = '"+row["MTN_CODE"] +"' AND MC_CODE = '" + row["MC_CODE"] + "' AND PLN_DATE = '" + row["PLN_DATE"].toDateTime() + "'") != null)
                        {
                            acGridView3.DeleteMappingRow(row);
                        }
                    }
                }

                if(isCancelDelCnt > 0)
                {
                    acMessageBox.Show(this, "실적이 존재하는 데이터는 삭제하지 못하였습니다.\n해당 데이터는 색으로 표시됩니다.", "", false, acMessageBox.emMessageBoxType.CONFIRM);
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }


        // 점검 편집기 (새로만들기)
        private void acBarButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                DataRow focusRow = acGridView1.GetFocusedDataRow();

                if (!base.ChildFormContains(focusRow["MC_CODE"]))
                {
                    HIS03A_D2A frm = new HIS03A_D2A(acGridView4, focusRow);
                    frm.DialogMode = BaseMenuDialog.emDialogMode.NEW;
                    frm.ParentControl = this;
                    base.ChildFormAdd(focusRow["MC_CODE"], frm);
                    frm.ShowDialog(this);
                }
                else
                {
                    base.ChildFormFocus(focusRow["MC_CODE"]);
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }


        // 점검 편집기 (열기) 
        private void acBarButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //열기
            try
            {
                acGridView4.EndEditor();

                DataRow focusRow = acGridView4.GetFocusedDataRow();

                if (focusRow == null)
                {
                    return;
                }


                HIS03A_D2A frm = new HIS03A_D2A(acGridView4, focusRow);

                frm.ParentControl = this;

                frm.DialogMode = BaseMenuDialog.emDialogMode.OPEN;

                frm.Show(this);
               

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }



        }

        //점검편집기 삭제
        private void acBarButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //삭제
            try
            {

                acGridView4.EndEditor();

                if (acMessageBox.Show(this, "정말 삭제하시겠습니까?", "TB43FSY3", true, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
                {
                    return;
                }


                DataRow focusRow = acGridView4.GetFocusedDataRow();

                // DataRow[] selected = acGridView4.GetSelectedDataRows();

                DataTable paramTable = new DataTable("RQSTDT");
                //paramTable.Columns.Add("DEL_EMP", typeof(String)); //
                //paramTable.Columns.Add("MRI_CODE", typeof(String)); //
                //paramTable.Columns.Add("PLT_CODE", typeof(String)); //사업장 코드

                paramTable.Columns.Add("MC_CODE", typeof(String)); //
                paramTable.Columns.Add("INS_DATE", typeof(String)); //
                paramTable.Columns.Add("INS_CHARGE", typeof(String)); //
                
                DataRow paramRow = paramTable.NewRow();

                paramRow["MC_CODE"] = focusRow["MC_CODE"];
                paramRow["INS_DATE"] = focusRow["INS_DATE"].toDateString("yyyyMMdd");
                paramRow["INS_CHARGE"] = focusRow["INS_CHARGE"];


                //paramRow["DEL_EMP"] = acInfo.UserID;
                //paramRow["MRI_CODE"] = focusRow["MC_CODE"];
                //paramRow["PLT_CODE"] = acInfo.PLT_CODE;


                paramTable.Rows.Add(paramRow);


                //if (selected.Length == 0)
                //{
                //    //단일삭제

                //    DataRow focusRow = acGridView4.GetFocusedDataRow();

                //    DataRow paramRow = paramTable.NewRow();
                //    paramRow["DEL_EMP"] = acInfo.UserID;
                //    paramRow["MRI_CODE"] = focusRow["MRI_CODE"];
                //    paramRow["PLT_CODE"] = acInfo.PLT_CODE;


                //    paramTable.Rows.Add(paramRow);


                //}
                //else
                //{
                //    //다중 삭제
                //    for (int i = 0; i < selected.Length; i++)
                //    {
                //        DataRow paramRow = paramTable.NewRow();
                //        paramRow["DEL_EMP"] = acInfo.UserID;
                //        paramRow["MRI_CODE"] = selected[i]["MRI_CODE"];
                //        paramRow["PLT_CODE"] = acInfo.PLT_CODE;

                //        paramTable.Rows.Add(paramRow);
                //    }


                //}


                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.PROCESS,
                "HIS03A_DEL3", paramSet, "RQSTDT", "",
                QuickDel2,
                QuickException);

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

    }
}
