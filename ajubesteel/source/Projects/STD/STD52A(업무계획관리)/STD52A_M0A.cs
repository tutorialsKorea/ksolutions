using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using DevExpress.XtraGrid.Views.Grid.ViewInfo;

using ControlManager;
using DevExpress.XtraGrid.Views.Grid;
using BizManager;
using DevExpress.Utils.Serializing;

namespace STD
{
    public sealed partial class STD52A_M0A : BaseMenu
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

        public STD52A_M0A()
        {

            InitializeComponent();


            acGridView1.FocusedRowChanged += acGridView1_FocusedRowChanged;
            //acGridView2.FocusedRowChanged += acGridView2_FocusedRowChanged;

            //acGridView1.RowUpdated += acGridView1_RowUpdated;
            //acGridView2.RowUpdated += acGridView2_RowUpdated;
            //acGridView3.RowUpdated += acGridView3_RowUpdated;

            //acGridControl1.EditorKeyDown += acGridControl1_EditorKeyDown;
            //acGridControl2.EditorKeyDown += acGridControl2_EditorKeyDown;
            //acGridControl3.EditorKeyDown += acGridControl3_EditorKeyDown;

            acGridView1.CustomDrawCell += acGridView1_CustomDrawCell;
            acGridView2.CustomDrawCell += acGridView2_CustomDrawCell;
            //acGridView3.CustomDrawCell += acGridView3_CustomDrawCell;

            //acGridView1.ShowingEditor += acGridView1_ShowingEditor;
            //acGridView2.ShowingEditor += acGridView2_ShowingEditor;
            //acGridView3.ShowingEditor += acGridView3_ShowingEditor;


            acGridView1.ShowGridMenuEx += new acGridView.ShowGridMenuExHandler(acGridView1_ShowGridMenuEx);
            acGridView2.ShowGridMenuEx += new acGridView.ShowGridMenuExHandler(acGridView2_ShowGridMenuEx);
            //acGridView3.ShowGridMenuEx += new acGridView.ShowGridMenuExHandler(acGridView3_ShowGridMenuEx);
            ///acGridView1.InitNewRow += acGridView1_InitNewRow;
        }

        void acGridView1_ShowGridMenuEx(object sender, PopupMenuShowingEventArgs e)
        {
            acGridView view = sender as acGridView;

            if (e.HitInfo.HitTest == GridHitTest.EmptyRow || e.HitInfo.HitTest == GridHitTest.Row || e.HitInfo.HitTest == GridHitTest.RowCell)
            {
                if (e.MenuType == GridMenuType.User)
                {
                    barItemDeleteGubun.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;                    
                }
                else if (e.MenuType == GridMenuType.Row)
                {
                    if (e.HitInfo.RowHandle >= 0)
                    {
                        barItemDeleteGubun.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    }
                    else
                    {
                        barItemDeleteGubun.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    }
                }

                GridHitInfo hitInfo = view.CalcHitInfo(e.Point);

                if (hitInfo.InColumn == false)
                {
                    popupMenu1.ShowPopup(view.GridControl.PointToScreen(e.Point));
                }

            }
        }

        void acGridView2_ShowGridMenuEx(object sender, PopupMenuShowingEventArgs e)
        {
            acGridView view = sender as acGridView;

            if (e.HitInfo.HitTest == GridHitTest.EmptyRow || e.HitInfo.HitTest == GridHitTest.Row || e.HitInfo.HitTest == GridHitTest.RowCell)
            {
                if (e.MenuType == GridMenuType.User)
                {
                    barItemDeleteSerise.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                }
                else if (e.MenuType == GridMenuType.Row)
                {
                    if (e.HitInfo.RowHandle >= 0)
                    {
                        barItemDeleteSerise.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    }
                    else
                    {
                        barItemDeleteSerise.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    }
                }

                GridHitInfo hitInfo = view.CalcHitInfo(e.Point);

                if (hitInfo.InColumn == false)
                {
                    popupMenu2.ShowPopup(view.GridControl.PointToScreen(e.Point));
                }

            }
        }

        //void acGridView3_ShowGridMenuEx(object sender, PopupMenuShowingEventArgs e)
        //{
        //    acGridView view = sender as acGridView;

        //    if (e.HitInfo.HitTest == GridHitTest.EmptyRow || e.HitInfo.HitTest == GridHitTest.Row || e.HitInfo.HitTest == GridHitTest.RowCell)
        //    {
        //        if (e.MenuType == GridMenuType.User)
        //        {
        //            barItemDeleteModel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
        //        }
        //        else if (e.MenuType == GridMenuType.Row)
        //        {
        //            if (e.HitInfo.RowHandle >= 0)
        //            {
        //                barItemDeleteModel.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
        //            }
        //            else
        //            {
        //                barItemDeleteModel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
        //            }
        //        }

        //        GridHitInfo hitInfo = view.CalcHitInfo(e.Point);

        //        if (hitInfo.InColumn == false)
        //        {
        //            popupMenu3.ShowPopup(view.GridControl.PointToScreen(e.Point));
        //        }

        //    }
        //}

        private void acGridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if(e.RowHandle > -1 && e.Column.FieldName == "MODEL_TYPE")
            {
                string key = acGridView1.GetRowCellValue(e.RowHandle,"SCODE").ToString();
                if(key != string.Empty)
                    e.Appearance.BackColor = Color.White;
            }        
        }

        private void acGridView2_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.RowHandle > -1 && e.Column.FieldName == "MODEL_SERISE")
            {
                string key = acGridView2.GetRowCellValue(e.RowHandle, "SCODE").ToString();
                if (key != string.Empty)
                    e.Appearance.BackColor = Color.White;
            }

            if (acGridView2.GetRowCellValue(e.RowHandle, "ROUT_FLAG").ToString() == "1" && e.Column.FieldName != "SCOMMENT")
                e.Appearance.BackColor = Color.YellowGreen;
        }

        //private void acGridView3_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        //{
        //    if (e.RowHandle > -1 && e.Column.FieldName == "MODEL_NO")
        //    {
        //        string key = acGridView3.GetRowCellValue(e.RowHandle, "SCODE").ToString();
        //        if (key != string.Empty)
        //            e.Appearance.BackColor = Color.White;
        //    }
        //}

        //private void acGridControl1_EditorKeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyData == Keys.Enter)
        //    {
        //        if (acGridView1.FocusedRowHandle > -1 )
        //            return;

        //        acGridView1.EndEditor();

        //        DataRow row = acGridView1.GetFocusedDataRow();

        //        if (row == null) return;

        //        acGridView1.UpdateCurrentRow();
        //    }
        //}

        //private void acGridControl2_EditorKeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyData == Keys.Enter)
        //    {
        //        if (acGridView2.FocusedRowHandle > -1)
        //            return;

        //        acGridView2.EndEditor();

        //        DataRow row = acGridView2.GetFocusedDataRow();

        //        if (row == null) return;

        //        acGridView2.UpdateCurrentRow();
        //    }
        //}

        //private void acGridControl3_EditorKeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyData == Keys.Enter)
        //    {
        //        if (acGridView3.FocusedRowHandle > -1)
        //            return;

        //        acGridView3.EndEditor();

        //        DataRow row = acGridView3.GetFocusedDataRow();

        //        if (row == null) return;

        //        acGridView3.UpdateCurrentRow();
        //    }
        //}

        //private void acGridView1_ShowingEditor(object sender, CancelEventArgs e)
        //{
        //    acGridView currentView = (sender as acGridView);
        //    if (currentView.FocusedColumn.FieldName == "MODEL_TYPE")
        //    {
        //        string key = currentView.GetRowCellValue(currentView.FocusedRowHandle, "SCODE").ToString();
        //        if (key != string.Empty)                    
        //            e.Cancel = true;                
        //        else                
        //            e.Cancel = false;                
        //    }
        //}

        //private void acGridView2_ShowingEditor(object sender, CancelEventArgs e)
        //{
        //    acGridView currentView = (sender as acGridView);
        //    if (currentView.FocusedColumn.FieldName == "MODEL_SERISE")
        //    {
        //        string key = currentView.GetRowCellValue(currentView.FocusedRowHandle, "SCODE").ToString();
        //        if (key != string.Empty)
        //            e.Cancel = true;
        //        else
        //            e.Cancel = false;
        //    }
        //}

        
        private void acGridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            //if (e.FocusedRowHandle < 0) return;

            acGridView2.ClearRow();
            acGridView3.ClearRow();


            btnAddSerise.Enabled = false;
            btnSaveSerise.Enabled = false;
            //btnAddModel.Enabled = false;
            //btnSaveModel.Enabled = false;

            acGridView view = sender as acGridView;

            DataRow focusRow = view.GetFocusedDataRow();

            if (focusRow == null )
            {
                return;
            }
            else if(focusRow["SCODE"].ToString() == string.Empty)
            {                
                return;
            }

            btnAddSerise.Enabled = true;
            btnSaveSerise.Enabled = true;
            //btnAddModel.Enabled = false;
            //btnSaveModel.Enabled = false;

            SearchDetail();            
        }


        //private void acGridView2_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        //{
        //    //if (e.FocusedRowHandle < 0) return;            

        //    acGridView3.ClearRow();

        //    btnAddModel.Enabled = false;
        //    btnSaveModel.Enabled = false;

        //    acGridView view = sender as acGridView;

        //    DataRow focusRow = view.GetFocusedDataRow();

        //    if (focusRow == null)
        //    {
        //        return;
        //    }
        //    else if (focusRow["SCODE"].ToString() == string.Empty)
        //    {
        //        return;
        //    }

        //    btnAddModel.Enabled = true;
        //    btnSaveModel.Enabled = true;

        //    SearchS();
        //}

        public override string InstantLog
        {
            set
            {
                statusBarLog.Caption = value;
            }
        }




        public override void MenuInit()
        {
            acGridView1.GridType = acGridView.emGridType.FIXED_SINGLE;

            //acGridView1.AddLookUpEdit("PROD_TYPE", "유형", "", false, DevExpress.Utils.HorzAlignment.Center, true, true, false, "S907");

            acGridView1.AddTextEdit("ROUT_CODE", "라우팅 그룹", "", false, DevExpress.Utils.HorzAlignment.Near, true, true, false, acGridView.emTextEditMask.NONE);

            //acGridView1.AddTextEdit("ST_GROUP_NAME", "ST그룹명", "", false, DevExpress.Utils.HorzAlignment.Near, true, true, false, acGridView.emTextEditMask.NONE);

            //acGridView1.AddCheckEdit("USE_FLAG", "사용여부", "", false, true, true, acGridView.emCheckEditDataType._STRING);
            //acGridView1.AddRadioGroup("USE_FLAG", "사용여부", "", false, true, true, false, "S900");

            acGridView1.AddTextEdit("SCOMMENT", "비고", "", false, DevExpress.Utils.HorzAlignment.Near, true, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddHidden("SCODE", typeof(string));

            acGridView1.KeyColumn = new string[] { "SCODE" };

            acGridView1.OptionsView.ShowIndicator = true;

            //acGridView1.OptionsView.NewItemRowPosition = NewItemRowPosition.Top;

            acGridView1.OptionsBehavior.Editable = true;



            acGridView2.GridType = acGridView.emGridType.FIXED_SINGLE;

            acGridView2.AddCheckEdit("ROUT_FLAG", "선택", "", false, true, true, acGridView.emCheckEditDataType._STRING);

            acGridView2.AddTextEdit("ROUT_CODE", "공정코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView2.AddTextEdit("ROUT_NAME", "공정명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            //acGridView2.AddTextEdit("ST_TIME", "ST", "", false, DevExpress.Utils.HorzAlignment.Far, true, true, false, acGridView.emTextEditMask.NUMERIC);

            //acGridView2.AddCheckEdit("USE_FLAG", "사용여부", "", false, true, true, acGridView.emCheckEditDataType._STRING);
            //acGridView2.AddRadioGroup("USE_FLAG", "사용여부", "", false, true, true, false, "S900");

            acGridView2.AddTextEdit("SCOMMENT", "비고", "", false, DevExpress.Utils.HorzAlignment.Near, true, true, false, acGridView.emTextEditMask.NONE);

            acGridView2.AddHidden("SCODE", typeof(string));

            acGridView2.KeyColumn = new string[] { "SCODE" };

            acGridView2.OptionsView.ShowIndicator = true;

            //acGridView2.OptionsView.ShowIndicator = true;

            //acGridView2.OptionsView.NewItemRowPosition = NewItemRowPosition.Top;

            acGridView2.RowHeight = 30;

            //acGridView3.GridType = acGridView.emGridType.FIXED_SINGLE;

            //acGridView3.AddTextEdit("MODEL_TYPE", "구분", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

            //acGridView3.AddTextEdit("MODEL_SERISE", "시리즈", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

            //acGridView3.AddTextEdit("MODEL_NO", "모델", "", false, DevExpress.Utils.HorzAlignment.Near, true, true, false, acGridView.emTextEditMask.NONE);

            //acGridView3.AddTextEdit("MODEL_CODE", "호기관리", "", false, DevExpress.Utils.HorzAlignment.Near, true, true, false, acGridView.emTextEditMask.NONE);

            ////acGridView3.AddCheckEdit("USE_FLAG", "사용여부", "", false, true, true, acGridView.emCheckEditDataType._STRING);
            //acGridView3.AddRadioGroup("USE_FLAG", "사용여부", "", false, true, true,false, "S900");

            //acGridView3.AddHidden("SCODE", typeof(string));

            //acGridView3.KeyColumn = new string[] { "MODEL_NO" };

            //acGridView3.OptionsView.ShowIndicator = true;

            //acGridView3.OptionsView.NewItemRowPosition = NewItemRowPosition.Top;

            base.MenuInit();
        }


        void acLayoutControl1_OnValueKeyDown(object sender, IBaseEditControl info, KeyEventArgs e)
        {

            if (e.KeyData == Keys.Enter)
            {

                this.Search();

            }

        }

        public override void MenuInitComplete()
        {


            base.MenuInitComplete();
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

        void Search()
        {
            try
            {
                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String));
                paramTable.Columns.Add("DATA_TYPE", typeof(String));

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;


                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);


                BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.LOAD,
                "STD51A_SER", paramSet, "RQSTDT", "RSLTDT",
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

                acGridView1.BestFitColumns();
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
                if(acGridView1.RowCount == 0)
                {
                    acGridView2.ClearRow();
                    acGridView3.ClearRow();
                    return;
                }

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String));
                paramTable.Columns.Add("DATA_TYPE", typeof(String));
                paramTable.Columns.Add("P_SCODE", typeof(String));

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["DATA_TYPE"] = "M";
                paramRow["P_SCODE"] = acGridView1.GetFocusedDataRow()["SCODE"];

                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);


                BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.LOAD_DETAIL,
                "STD51A_SER2", paramSet, "RQSTDT", "RSLTDT",
                QuickSearchDetail,
                QuickException);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void QuickSearchDetail(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                acGridView2.GridControl.DataSource = e.result.Tables["RSLTDT"];

                acGridView2.BestFitColumns();
                for (int i = 0; i < acGridView2.RowCount; i++)
                {
                    acGridView2.SetRowCellValue(i,"ST_TIME", acGridView2.GetRowCellValue(i,"ST_TIME"));
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }


        //void SearchS()
        //{
        //    try
        //    {
        //        if (acGridView2.RowCount == 0)
        //        {                    
        //            acGridView3.ClearRow();
        //            return;
        //        }


        //        DataTable paramTable = new DataTable("RQSTDT");
        //        paramTable.Columns.Add("PLT_CODE", typeof(String));
        //        paramTable.Columns.Add("DATA_TYPE", typeof(String));
        //        paramTable.Columns.Add("P_SCODE", typeof(String));

        //        DataRow paramRow = paramTable.NewRow();
        //        paramRow["PLT_CODE"] = acInfo.PLT_CODE;
        //        paramRow["DATA_TYPE"] = "S";
        //        paramRow["P_SCODE"] = acGridView2.GetFocusedDataRow()["SCODE"];

        //        paramTable.Rows.Add(paramRow);
        //        DataSet paramSet = new DataSet();
        //        paramSet.Tables.Add(paramTable);


        //        BizRun.QBizRun.ExecuteService(
        //        this, QBiz.emExecuteType.LOAD,
        //        "STD44A_SER", paramSet, "RQSTDT", "RSLTDT",
        //        QuickSearchS,
        //        QuickException);
        //    }
        //    catch (Exception ex)
        //    {
        //        acMessageBox.Show(this, ex);
        //    }
        //}

        //void QuickSearchS(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        //{
        //    try
        //    {
        //        acGridView3.GridControl.DataSource = e.result.Tables["RSLTDT"];

        //        acGridView3.BestFitColumns();
        //    }
        //    catch (Exception ex)
        //    {
        //        acMessageBox.Show(this, ex);
        //    }
        //}

        void QuickException(object sender, QBiz qBiz, BizException ex)
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



        private void btnSaveGubun_Click(object sender, EventArgs e)
        {
            SetSaveUseFlag(acGridView1,"B");
            acGridView1_FocusedRowChanged(acGridView1, null);
        }

        private void btnSaveSerise_Click(object sender, EventArgs e)
        {
            SetSaveUseFlag(acGridView2,"M");
            //acGridView2_FocusedRowChanged(acGridView2, null);
        }

        private void btnSaveModel_Click(object sender, EventArgs e)
        {
            SetSaveUseFlag(acGridView3,"S");
            //acGridView3_FocusedRowChanged(acGridView3, null);
        }

        private void SetSaveUseFlag(acGridView view,string data_type)
        {
            DataTable dtParam = new DataTable("RQSTDT");
            dtParam.Columns.Add("PLT_CODE", typeof(String));
            dtParam.Columns.Add("SCODE", typeof(String));
            dtParam.Columns.Add("P_SCODE", typeof(String));            
            dtParam.Columns.Add("DATA_TYPE", typeof(String));
            dtParam.Columns.Add("ROUT_CODE", typeof(String));
            dtParam.Columns.Add("ROUT_FLAG", typeof(String));
            dtParam.Columns.Add("ROUT_SEQ", typeof(decimal));
            dtParam.Columns.Add("USE_FLAG", typeof(String));
            dtParam.Columns.Add("SCOMMENT", typeof(String));
            dtParam.Columns.Add("REG_EMP", typeof(String));

            DataView v = view.GetDataView();
            //foreach (DataRow row in view.GetDataView())
            for(int i = 0; i < v.Count; i++)
            {
                if (v[i]["ROUT_CODE"].isNullOrEmpty())
                    continue;

                DataRow drParam = dtParam.NewRow();
                drParam["PLT_CODE"] = acInfo.PLT_CODE;
                drParam["SCODE"] = v[i]["SCODE"];
                drParam["DATA_TYPE"] = data_type;
                drParam["ROUT_CODE"] = v[i]["ROUT_CODE"];                
                if (data_type == "M")
                {
                    drParam["ROUT_FLAG"] = v[i]["ROUT_FLAG"];
                    drParam["ROUT_SEQ"] = i;
                    drParam["P_SCODE"] = acGridView1.GetFocusedDataRow()["SCODE"];                                                              
                }

                //drParam["USE_FLAG"] = row["USE_FLAG"];
                drParam["SCOMMENT"] = v[i]["SCOMMENT"];
                drParam["REG_EMP"] = acInfo.UserID;

                dtParam.Rows.Add(drParam);
            }

            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(dtParam);
            if (dtParam.Rows.Count == 0)
            {
                acAlert.Show(this, "저장 되었습니다.", acAlertForm.enmType.Success);
                return;
            }

            DataSet dsRslt = BizRun.QBizRun.ExecuteService(this, "STD51A_INS", paramSet, "RQSTDT", "RSLTDT");
            //foreach (DataRow row in dsRslt.Tables["RSLTDT"].Rows)
            //{
            //    view.UpdateMapingRow(row, false);
            //}

            view.GridControl.DataSource = dsRslt.Tables["RSLTDT"];

            view.SetOldFocusRowHandle(true);

            acAlert.Show(this, "저장 되었습니다.", acAlertForm.enmType.Success);

        }

        private void barItemDeleteGubun_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SetDeleteUseFlag(acGridView1);
            acGridView1_FocusedRowChanged(acGridView1, null);
        }

        private void barItemDeleteSerise_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SetDeleteUseFlag(acGridView2);
            //acGridView2_FocusedRowChanged(acGridView2, null);
        }

        private void barItemDeleteModel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SetDeleteUseFlag(acGridView3);
            //acGridView2_FocusedRowChanged(acGridView2, null);
        }

        private void SetDeleteUseFlag(acGridView view)
        {

            ParameterYesNoDialogResult msgResult = acMessageBox.ShowParameterYesNo(this, "정말 삭제하시겠습니까?", "TB43FSY3", true, acInfo.Resource.GetString("삭제사유", "A9DY9R6G"));


            if (msgResult.DialogResult == DialogResult.No)
            {
                return;
            }

            DataTable dtParam = new DataTable("RQSTDT");
            dtParam.Columns.Add("PLT_CODE", typeof(String));
            dtParam.Columns.Add("SCODE", typeof(String));            
            dtParam.Columns.Add("DEL_EMP", typeof(String));

            DataRow drParam = dtParam.NewRow();
            drParam["PLT_CODE"] = acInfo.PLT_CODE;
            drParam["SCODE"] = view.GetFocusedDataRow()["SCODE"];                
            drParam["DEL_EMP"] = acInfo.UserID;

            dtParam.Rows.Add(drParam);

            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(dtParam);

            BizRun.QBizRun.ExecuteService(this, "STD51A_DEL", paramSet, "RQSTDT", "");

            view.DeleteMappingRow(view.GetFocusedDataRow());

            //acMessageBox.Show(this, "삭제 완료!", "", false, acMessageBox.emMessageBoxType.CONFIRM);
            acAlert.Show(this, "삭제 되었습니다.", acAlertForm.enmType.Info);
        }

        private void btnAddGubun_Click(object sender, EventArgs e)
        {
            acGridView1.AddNewRow();
            acGridView1.SetRowCellValue(acGridView1.FocusedRowHandle, "USE_FLAG", "1");
            acGridView1_FocusedRowChanged(acGridView1, null);
        }

        private void btnAddSerise_Click(object sender, EventArgs e)
        {
            acGridView2.AddNewRow();
            acGridView2.SetRowCellValue(acGridView2.FocusedRowHandle, "USE_FLAG", "1");
            //acGridView2_FocusedRowChanged(acGridView2, null);
        }

        private void btnAddModel_Click(object sender, EventArgs e)
        {
            acGridView3.AddNewRow();
            acGridView3.SetRowCellValue(acGridView3.FocusedRowHandle, "USE_FLAG", "1");
            //acGridView3_FocusedRowChanged(acGridView3, null);
        }
    }
}

