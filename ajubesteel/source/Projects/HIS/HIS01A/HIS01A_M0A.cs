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

namespace HIS
{
    public sealed partial class HIS01A_M0A : BaseMenu
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
        int mergedColumnIndex;

        public HIS01A_M0A()
        {
            InitializeComponent();

            //acLayoutControl1.OnValueChanged += acLayoutControl1_OnValueChanged;
            acLayoutControl1.OnValueKeyDown += acLayoutControl1_OnValueKeyDown;

            acBandGridView1.FocusedRowChanged += AcBandGridView1_FocusedRowChanged;
            acBandGridView1.ShowGridMenuEx += AcBandGridView1_ShowGridMenuEx;
            acBandGridView1.CellMerge += AcBandGridView1_CellMerge;
            acBandGridView1.MouseDown += AcBandGridView1_MouseDown;
            //acBandGridView1.RowCellStyle += AcBandGridView1_RowCellStyle;

            acGridView1.ShowGridMenuEx += AcGridView1_ShowGridMenuEx;
            acGridView1.FocusedRowChanged += AcGridView1_FocusedRowChanged;

            acGridView2.ShowGridMenuEx += AcGridView2_ShowGridMenuEx;
        }

        //private void AcBandGridView1_RowCellStyle(object sender, RowCellStyleEventArgs e)
        //{
        //    acBandGridView view = (acBandGridView)sender;
        //    GridViewInfo viewInfo = (GridViewInfo)view.GetViewInfo();
        //    if (e.RowHandle == 6) 
        //    { 
        //    }

        //    if (MergedCellIsFocused(view, GetMergedCell(view, viewInfo, e.RowHandle, mergedColumnIndex)))
        //    {
                
        //        e.Appearance.Assign(viewInfo.PaintAppearance.FocusedRow);
         
        //    }
        //}

        private GridCellInfo GetMergedCell(acBandGridView view, GridViewInfo viewInfo, int rowHandle, int colIndex)
        {
            GridCellInfo cell = viewInfo.GetGridCellInfo(rowHandle, acBandGridView1.Columns[colIndex]);
            if (cell == null) return null; 
            else if(!cell.IsMerged)
            {
                if (cell.RowHandle == view.FocusedRowHandle) return cell;
                else return null;
            }
            else return cell;
        }

        private bool MergedCellIsFocused(acBandGridView view, GridCellInfo cell)
        {
            if (cell == null) return false;
            if (cell.MergedCell == null) return true;
            foreach (GridCellInfo ci in cell.MergedCell.MergedCells)
            {
                if (ci.RowHandle == view.FocusedRowHandle) return true;
            }
            return false;
        }

        private void RefreshMergedCell(acBandGridView view, GridCellInfo cell)
        {
            if (cell == null|| cell.MergedCell == null) return;
            foreach (GridCellInfo ci in cell.MergedCell.MergedCells) view.RefreshRow(ci.RowHandle);

        }

        private void AcGridView2_ShowGridMenuEx(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {

            if (acBandGridView1.FocusedRowHandle < 0)
            {
                return;
            }
           
            if (e.MenuType == GridMenuType.User)
            {
                
                btnPartOpen.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                btnPartDel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            }
            else if (e.MenuType == GridMenuType.Row)
            {
                if (e.HitInfo.RowHandle >= 0)
                {
                    btnPartOpen.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    btnPartDel.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                }
                else
                {

                    btnPartOpen.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    btnPartDel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                }

            }

            if (e.HitInfo.HitTest == GridHitTest.EmptyRow || e.HitInfo.HitTest == GridHitTest.Row || e.HitInfo.HitTest == GridHitTest.RowCell)
            {
                GridHitInfo hitInfo = acGridView2.CalcHitInfo(e.Point);
                popupMenu3.ShowPopup(acGridView2.GridControl.PointToScreen(e.Point));
            }
        }

        private void AcGridView1_ShowGridMenuEx(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {

            if (acBandGridView1.FocusedRowHandle < 0)
            {
                return;
            }
          
            if (e.HitInfo.HitTest == GridHitTest.EmptyRow || e.HitInfo.HitTest == GridHitTest.Row || e.HitInfo.HitTest == GridHitTest.RowCell)
            {
                GridHitInfo hitInfo = acGridView1.CalcHitInfo(e.Point);
                popupMenu2.ShowPopup(acGridView1.GridControl.PointToScreen(e.Point));
            }
            
        }

        private void AcBandGridView1_MouseDown(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                GridHitInfo hitInfo = acBandGridView1.CalcHitInfo(e.Location);
                if (hitInfo.HitTest == GridHitTest.RowCell || hitInfo.HitTest == GridHitTest.Row)
                {
                    this.OpenDataForm();
                }
            }
        }

        private void AcBandGridView1_CellMerge(object sender, CellMergeEventArgs e)
        {
            try
            {
                if (sender is acBandGridView view)//Name 컬럼만 Merge
                {
                    if(e.Column is acBandedGridColumn col)
                    {
                        switch (col.OwnerBand.Caption)
                        {
                            case "보전 항목":
                                var dr1 = view.GetDataRow(e.RowHandle1); //위에 행 정보
                                var dr2 = view.GetDataRow(e.RowHandle2); //아래 행 정보

                                e.Merge = dr1["MTN_CODE"].ToString().Equals(dr2["MTN_CODE"].ToString());
                                break;
                        }
                    }
                }
                else
                    e.Merge = false;

                e.Handled = true;
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void AcBandGridView1_ShowGridMenuEx(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
           
            if (e.MenuType == GridMenuType.User)
            {
                btnOpen.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                btnDel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            }
            else if (e.MenuType == GridMenuType.Row)
            {
                if (e.HitInfo.RowHandle >= 0)
                {
                    btnOpen.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    btnDel.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                }
                else
                {

                    btnOpen.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    btnDel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                }

            }

            if (e.HitInfo.HitTest == GridHitTest.EmptyRow || e.HitInfo.HitTest == GridHitTest.Row || e.HitInfo.HitTest == GridHitTest.RowCell)
            {
                GridHitInfo hitInfo = acBandGridView1.CalcHitInfo(e.Point);
                popupMenu1.ShowPopup(acBandGridView1.GridControl.PointToScreen(e.Point));
            }
        }

        private void AcGridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            this.SearchMcParts();
        }

        private void AcBandGridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            acBandGridView view = (acBandGridView)sender;
            GridViewInfo viewInfo = (GridViewInfo)view.GetViewInfo();
            RefreshMergedCell(view, GetMergedCell(view, viewInfo, e.PrevFocusedRowHandle, mergedColumnIndex));
            RefreshMergedCell(view, GetMergedCell(view, viewInfo, e.FocusedRowHandle, mergedColumnIndex));

            this.SearchMc();
        }

        //void acLayoutControl1_OnValueChanged(object sender, IBaseEditControl info, object newValue)
        //{
        //    acLayoutControl layout = sender as acLayoutControl;
        //    switch (info.ColumnName)
        //    {
        //        case "DATE":

        //            //날짜검색조건이 존재하면 날짜컨트롤을 필수로 바꾼다.
        //            if (newValue.EqualsEx(string.Empty))
        //            {
        //                layout.GetEditor("S_DATE").isRequired = false;
        //                layout.GetEditor("E_DATE").isRequired = false;
        //            }
        //            else
        //            {
        //                layout.GetEditor("S_DATE").isRequired = true;
        //                layout.GetEditor("E_DATE").isRequired = true;
        //            }
        //            break;
        //    }
        //}

        void acLayoutControl1_OnValueKeyDown(object sender, IBaseEditControl info, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                this.Search();
            }
        }

        public override void DataRefresh(object data)
        {
            base.DataRefresh(data);

            this.Search();
        }

        //public override void ChildContainerInit(Control sender)
        //{

        //    if (sender == acLayoutControl1)
        //    {
        //        acLayoutControl layout = sender as acLayoutControl;

        //        layout.GetEditor("DATE").Value = "REG_DATE";
        //        layout.GetEditor("S_DATE").Value = acDateEdit.GetNowFirstDate();
        //        layout.GetEditor("E_DATE").Value = DateTime.Now;

        //    }

        //    base.ChildContainerInit(sender);
        //}



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
                acBandGridView1.OptionsView.AllowCellMerge = true;

                #region 보전항목
                string bandName1 = "보전 항목";
                acBandGridView1.AddTextEdit("MTN_CODE", "보전코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acBandGridView.emTextEditMask.NONE, bandName1);
                acBandGridView1.AddTextEdit("MTN_NAME", "보전항목", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acBandGridView.emTextEditMask.NONE, bandName1);
                acBandGridView1.AddTextEdit("STD_PERIOD", "보전주기", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.QTY, bandName1);
                acBandGridView1.AddTextEdit("MTN_SEQ", "순서", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.QTY, bandName1);
                acBandGridView1.AddTextEdit("MTN_SCOMMENT", "비고", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acBandGridView.emTextEditMask.NONE, bandName1);
                string bandName2 = "소요 예비품";
                acBandGridView1.AddTextEdit("PART_CODE", "품목코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acBandGridView.emTextEditMask.NONE, bandName2);
                acBandGridView1.AddTextEdit("PART_NAME", "품목명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acBandGridView.emTextEditMask.NONE, bandName2);
                acBandGridView1.AddTextEdit("MAT_SPEC", "규격", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acBandGridView.emTextEditMask.NONE, bandName2);
                acBandGridView1.AddTextEdit("USE_QTY", "소요수량", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.F1, bandName2);
                acBandGridView1.AddTextEdit("MTN_PART_SCOMMENT", "비고", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acBandGridView.emTextEditMask.NONE, bandName2);

                acBandGridView1.KeyColumn = new string[] { "MTN_CODE", "PART_CODE" };

                mergedColumnIndex = acBandGridView1.Columns["MTN_CODE"].AbsoluteIndex;
                #endregion

                #region 보전 설비
                acGridView1.AddCheckEdit("SEL", "선택", "", false, true, true, acGridView.emCheckEditDataType._STRING);
                acGridView1.AddLookUpEdit("MC_GROUP", "설비그룹", "40308", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "C020");
                acGridView1.AddTextEdit("MC_CODE", "설비 코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                //acGridView1.AddTextEdit("PM_ACT_CODE", "보전관리번호", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView1.AddTextEdit("MC_NAME", "설비명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView1.AddTextEdit("MTN_NAME", "보전항목", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView1.AddTextEdit("MC_PERIOD", "보전주기", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
                acGridView1.AddTextEdit("SCOMMENT", "비고", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

                acGridView1.KeyColumn = new string[] { "MTN_CODE", "MC_CODE" };
                #endregion

                #region 소요 예비품
                acGridView2.AddCheckEdit("SEL", "선택", "", false, true, true, acGridView.emCheckEditDataType._STRING);
                acGridView2.AddTextEdit("MC_NAME", "설비명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView2.AddTextEdit("MTN_NAME", "보전항목", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView2.AddTextEdit("PART_CODE", "품목코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView2.AddTextEdit("PART_NAME", "품목명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView2.AddTextEdit("MAT_SPEC", "사양", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView2.AddTextEdit("USE_QTY", "소요수량", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.F1);
                acGridView2.AddTextEdit("SCOMMENT", "비고", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView2.KeyColumn = new string[] { "MTN_CODE", "MC_CODE","PART_CODE" };
                #endregion

               // cboDate.AddItem("작성일", false, "", "REG_DATE", true, false);
               
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

        private void btnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.NewDataForm();
        }

        private void btnOpen_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.OpenDataForm();
        }

        private void btnDel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.DeleteData();
        }

        private void btnMC_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.SelectMachine();
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
            paramTable.Columns.Add("MTN_LIKE", typeof(String)); //
           
            //paramTable.Columns.Add("S_REG_DATE", typeof(String)); //
            //paramTable.Columns.Add("E_REG_DATE", typeof(String)); //

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["MTN_LIKE"] = layoutRow["MTN_LIKE"];
         
            //foreach (string key in cboDate.GetKeyChecked())
            //{
            //    switch (key)
            //    {
            //        case "REG_DATE":

            //            paramRow["S_REG_DATE"] = layoutRow["S_DATE"];
            //            paramRow["E_REG_DATE"] = layoutRow["E_DATE"];

            //            break;

            //    }

            //}
            paramTable.Rows.Add(paramRow);

            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD_DETAIL, "HIS01A_SER1", paramSet, "RQSTDT", "RSLTDT,RSLTDT_HEAD",
              QuickSearch,
              QuickException);
        }


        void QuickSearch(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                acGridView1.ClearRow();
                acGridView2.ClearRow();

                acBandGridView1.GridControl.DataSource = e.result.Tables["RSLTDT"];
                acBandGridView1.SetOldFocusRowHandle(false);
                acBandGridView1.BestFitColumns();
                base.SetLog(e.executeType, e.result.Tables["RSLTDT"].Rows.Count, e.executeTime);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        public void SearchMc()
        {
            try
            {
                if (acBandGridView1.GetFocusedDataRow() is DataRow focusRow)
                {
                    DataSet paramSet = new DataSet();
                    DataTable paramTable = paramSet.Tables.Add("RQSTDT");
                    paramTable.Columns.Add("PLT_CODE", typeof(String));
                    paramTable.Columns.Add("MTN_CODE", typeof(String));

                    DataRow paramRow = paramTable.NewRow();
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["MTN_CODE"] = focusRow["MTN_CODE"];
                    paramTable.Rows.Add(paramRow);

                    BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD_DETAIL, "HIS01A_SER2", paramSet, "RQSTDT", "RSLTDT,RSLTDT_HEAD",
                      QuickSearchMc,
                      QuickException);
                }
            }catch(Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }


        void QuickSearchMc(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                acGridView2.ClearRow();
                acGridView1.GridControl.DataSource = e.result.Tables["RSLTDT"];
                acGridView1.SetOldFocusRowHandle(false);
                acGridView1.BestFitColumns();
                base.SetLog(e.executeType, e.result.Tables["RSLTDT"].Rows.Count, e.executeTime);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        void SearchMcParts()
        {
            try
            {
                if (acGridView1.GetFocusedDataRow() is DataRow focusRow)
                {
                    DataSet paramSet = new DataSet();
                    DataTable paramTable = paramSet.Tables.Add("RQSTDT");
                    paramTable.Columns.Add("PLT_CODE", typeof(String));
                    paramTable.Columns.Add("MTN_CODE", typeof(String));
                    paramTable.Columns.Add("MC_CODE", typeof(String));

                    DataRow paramRow = paramTable.NewRow();
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["MTN_CODE"] = focusRow["MTN_CODE"];
                    paramRow["MC_CODE"] = focusRow["MC_CODE"];
                    paramTable.Rows.Add(paramRow);

                    BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD_DETAIL, "HIS01A_SER3", paramSet, "RQSTDT", "RSLTDT,RSLTDT_HEAD",
                      QuickSearchMcParts,
                      QuickException);
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }


        void QuickSearchMcParts(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                acGridView2.GridControl.DataSource = e.result.Tables["RSLTDT"];
                acGridView2.SetOldFocusRowHandle(false);
                acGridView2.BestFitColumns();
                base.SetLog(e.executeType, e.result.Tables["RSLTDT"].Rows.Count, e.executeTime);
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

        private void NewDataForm()
        {
            try
            {
                if (!base.ChildFormContains("NEW"))
                {

                    HIS01A_D0A frm = new HIS01A_D0A(acBandGridView1, null);
                    frm.DialogMode = BaseMenuDialog.emDialogMode.NEW;
                    frm.ParentControl = this;
                    base.ChildFormAdd("NEW", frm);
                    frm.ShowDialog(this);
                }
                else
                {
                    base.ChildFormFocus("NEW");
                }
            }
            catch(Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void OpenDataForm()
        {
            try
            {
                DataRow focusRow = acBandGridView1.GetFocusedDataRow();

                if (!base.ChildFormContains(focusRow["MTN_CODE"]+"MTN"))
                {

                    HIS01A_D0A frm = new HIS01A_D0A(acBandGridView1, focusRow);
                    frm.DialogMode = BaseMenuDialog.emDialogMode.OPEN;
                    frm.ParentControl = this;
                    base.ChildFormAdd(focusRow["MTN_CODE"] + "MTN", frm);
                    frm.ShowDialog(this);
                }
                else
                {
                    base.ChildFormFocus(focusRow["MTN_CODE"] + "MTN");
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void DeleteData()
        {
            try
            {
                if(acMessageBox.Show(this,"선택한 보전항목을 삭제 하시겠습니까?","",false, acMessageBox.emMessageBoxType.YESNO)== DialogResult.Yes)
                {
                    DataRow focusRow = acBandGridView1.GetFocusedDataRow();

                    DataSet paramSet = new DataSet();
                    DataTable paramTable = paramSet.Tables.Add("RQSTDT");
                    paramTable.Columns.Add("PLT_CODE", typeof(String));
                    paramTable.Columns.Add("MTN_CODE", typeof(String));

                    DataRow paramRow = paramTable.NewRow();
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["MTN_CODE"] = focusRow["MTN_CODE"];
                    paramTable.Rows.Add(paramRow);

                    BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.DEL, "HIS01A_DEL", paramSet, "RQSTDT", "RSLTDT",
                      QuickDel,
                      QuickException);
                }
            }
            catch(Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void QuickDel(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                this.Search();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        void SelectMachine()
        {
            try
            {
                DataRow focusRow = acBandGridView1.GetFocusedDataRow();

                if (!base.ChildFormContains(focusRow["MTN_CODE"]+"MC"))
                {
                    HIS01A_D1A frm = new HIS01A_D1A(acGridView1, focusRow);
                    frm.DialogMode = BaseMenuDialog.emDialogMode.OPEN;
                    frm.ParentControl = this;
                    base.ChildFormAdd(focusRow["MTN_CODE"] + "MC", frm);
                    if (frm.ShowDialog(this) == DialogResult.OK)
                    {
                        this.SearchMc();
                    }
                }
                else
                {
                    base.ChildFormFocus(focusRow["MTN_CODE"] + "MC");
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void btnPartEditForm_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                DataRow focusRow = acGridView1.GetFocusedDataRow();

                if (!base.ChildFormContains("NEW"))
                {

                    HIS01A_D2A frm = new HIS01A_D2A(acGridView2, focusRow);
                    frm.DialogMode = BaseMenuDialog.emDialogMode.NEW;
                    frm.ParentControl = this;
                    base.ChildFormAdd("NEW", frm);
                    frm.ShowDialog(this);
                }
                else
                {
                    base.ChildFormFocus("NEW");
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void btnPartOpen_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                DataRow focusRow = acGridView2.GetFocusedDataRow();

                if (!base.ChildFormContains(focusRow["MC_CODE"]))
                {

                    HIS01A_D2A frm = new HIS01A_D2A(acGridView2, focusRow);
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

        private void btnPartDel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (acMessageBox.Show(this, "선택한 예비품을 삭제 하시겠습니까?", "", false, acMessageBox.emMessageBoxType.YESNO) == DialogResult.Yes)
                {
                    DataRow focusRow = acGridView2.GetFocusedDataRow();

                    DataSet paramSet = new DataSet();
                    DataTable paramTable = paramSet.Tables.Add("RQSTDT");
                    paramTable.Columns.Add("PLT_CODE", typeof(String));
                    paramTable.Columns.Add("MTN_CODE", typeof(String));
                    paramTable.Columns.Add("MC_CODE", typeof(String));
                    paramTable.Columns.Add("PART_CODE", typeof(String));

                    DataRow paramRow = paramTable.NewRow();
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["MTN_CODE"] = focusRow["MTN_CODE"];
                    paramRow["MC_CODE"] = focusRow["MC_CODE"];
                    paramRow["PART_CODE"] = focusRow["PART_CODE"];
                    paramTable.Rows.Add(paramRow);

                    BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.DEL, "HIS01A_DEL2", paramSet, "RQSTDT", "RSLTDT",
                      QuickDel,
                      QuickException);
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void acGridControl1_MouseDown(object sender, MouseEventArgs e)
        {
            // 보전설비 편집기 열기

            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                GridHitInfo hitInfo = acGridView1.CalcHitInfo(e.Location);
                if (hitInfo.HitTest == GridHitTest.RowCell || hitInfo.HitTest == GridHitTest.Row)
                {
                    this.SelectMachine();

                }
            }


        }

        private void acGridControl2_MouseDown(object sender, MouseEventArgs e)
        {
            //소모예비품 편집기 열기

            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                GridHitInfo hitInfo = acGridView2.CalcHitInfo(e.Location);
                if (hitInfo.HitTest == GridHitTest.RowCell || hitInfo.HitTest == GridHitTest.Row)
                {
                    try
                    {
                        DataRow focusRow = acGridView2.GetFocusedDataRow();

                        if (!base.ChildFormContains(focusRow["MC_CODE"]))
                        {

                            HIS01A_D2A frm = new HIS01A_D2A(acGridView2, focusRow);
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
            }

        }
    }
}
