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

namespace ORD
{
    public sealed partial class ORD07A_M0A : BaseMenu
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

        public ORD07A_M0A()
        {

            InitializeComponent();

            //발주처
            acGridView4.FocusedRowChanged += acGridView4_FocusedRowChanged;
            acGridView4.CellValueChanged += AcGridView4_CellValueChanged;

            // 모델
            acGridView1.FocusedRowChanged += acGridView1_FocusedRowChanged;
            acGridView1.CellValueChanged += acGridView1_CellValueChanged;

            //세부모델
            acGridView2.CellValueChanged += acGridView2_CellValueChanged;

            

            //acGridView2.FocusedRowChanged += acGridView2_FocusedRowChanged;

            //acGridView1.RowUpdated += acGridView1_RowUpdated;
            //acGridView2.RowUpdated += acGridView2_RowUpdated;
            //acGridView3.RowUpdated += acGridView3_RowUpdated;

            //acGridControl1.EditorKeyDown += acGridControl1_EditorKeyDown;
            //acGridControl2.EditorKeyDown += acGridControl2_EditorKeyDown;
            //acGridControl3.EditorKeyDown += acGridControl3_EditorKeyDown;


            //acGridView3.CustomDrawCell += acGridView3_CustomDrawCell;

            //acGridView1.ShowingEditor += acGridView1_ShowingEditor;
            //acGridView2.ShowingEditor += acGridView2_ShowingEditor;
            //acGridView3.ShowingEditor += acGridView3_ShowingEditor;

            acGridView4.ShowGridMenuEx += new acGridView.ShowGridMenuExHandler(acGridView4_ShowGridMenuEx);
            acGridView1.ShowGridMenuEx += new acGridView.ShowGridMenuExHandler(acGridView1_ShowGridMenuEx);
            acGridView2.ShowGridMenuEx += new acGridView.ShowGridMenuExHandler(acGridView2_ShowGridMenuEx);
            //acGridView3.ShowGridMenuEx += new acGridView.ShowGridMenuExHandler(acGridView3_ShowGridMenuEx);
            ///acGridView1.InitNewRow += acGridView1_InitNewRow;

            //acGridView4.CustomRowCellEdit += acGridView4_CustomRowCellEdit;

            acGridView4.CustomDrawCell += acGridView4_CustomDrawCell;
            acGridView1.CustomDrawCell += acGridView4_CustomDrawCell;
            acGridView2.CustomDrawCell += acGridView4_CustomDrawCell;

            acGridView4.ShowingEditor += acGridView4_ShowingEditor;
            acGridView1.ShowingEditor += acGridView4_ShowingEditor;
            acGridView2.ShowingEditor += acGridView4_ShowingEditor;
        }

        private void acGridView4_ShowingEditor(object sender, CancelEventArgs e)
        {
            GridView gridView = sender as GridView;

            DataRow row = gridView.GetDataRow(gridView.FocusedRowHandle);

            if (gridView.FocusedColumn.FieldName == "SEL") return;

            if (row == null) return;

            if (row["LOCK_FLAG"].ToString() == "1")
            {
                e.Cancel = true;

            }
        }

        private void acGridView4_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            try
            {

                if (sender is acGridView view)
                {
                    DataRow row = view.GetDataRow(e.RowHandle);

                    if (row == null) return;
                    if (e.Column.FieldName == "SEL") return;

                    if (row["LOCK_FLAG"].ToString() == "1")
                    {
                        e.Appearance.BackColor = Color.Gray;
                        e.Appearance.ForeColor = Color.White;

                    }
                }
            }
            catch { }
        }


        private void acGridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.RowHandle > -1 && e.Column.FieldName == "MODEL_TYPE")
            {
                string key = acGridView1.GetRowCellValue(e.RowHandle, "SCODE").ToString();
                if (key != string.Empty)
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
        }

        private void acGridView4_CustomRowCellEdit(object sender, CustomRowCellEditEventArgs e)
        {
            //DataRow row = acGridView4.GetDataRow(e.RowHandle);

            //if (row == null) return;

            //if (row["LOCK_FLAG"].ToString() == "1")
            //{
            //    e.RepositoryItem.ReadOnly = true;
            //}
            //else
            //{
            //    e.RepositoryItem.ReadOnly = false;
            //}
        }

        private void AcGridView4_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                acGridView gridView = sender as acGridView;

                CheckSameValue(gridView, "V");

            }
            catch { }
      
        }

        private void acGridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                acGridView gridView = sender as acGridView;

                CheckSameValue(gridView, "T");
            }
            catch { }
        }

        private void acGridView2_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            acGridView gridView = sender as acGridView;

            CheckSameValue(gridView, "M");
        }



        // UI단에서 중복되는 항목 제거
        public void CheckSameValue(acGridView gView, string data_type)
        {
            try
            {
                gView.EndEditor();

                DataTable dtView = gView.GetDataView().ToTable();

                int cnt = 0;

                switch (data_type)
                {
                    case "V":

                        if (gView.GetFocusedDataRow()["VEN_CODE"].isNullOrEmpty()) { return; }

                        string vendor = gView.GetFocusedDataRow()["VEN_CODE"].ToString();

                        foreach (DataRow row in dtView.Rows)
                        {
                            if (row["VEN_CODE"].ToString() == vendor && vendor != "")
                            {
                                cnt++;
                            }
                        }

                        if (cnt > 1)
                        {
                            acMessageBox.Show("동일한 발주처가 이미 존재합니다.", "모델 관리", acMessageBox.emMessageBoxType.CONFIRM);

                            gView.SetFocusedRowCellValue("VEN_CODE", null);
                        }

                        break;

                    case "T" :

                        if (gView.GetFocusedDataRow()["MODEL_CODE"].isNullOrEmpty()) { return; }

                        string model = gView.GetFocusedDataRow()["MODEL_CODE"].ToString();

                        foreach (DataRow row in dtView.Rows)
                        {
                            if (row["MODEL_CODE"].ToString() == model && model != "")
                            {
                                cnt++;
                            }
                        }

                        if (cnt > 1)
                        {
                            acMessageBox.Show("해당 발주처에 이미 동일한 모델이 존재합니다.", "모델 관리", acMessageBox.emMessageBoxType.CONFIRM);

                            gView.SetFocusedRowCellValue("MODEL_CODE", null);
                        }

                        break;

                    case "M" :

                        if (gView.GetFocusedDataRow()["MODEL_CODE"].isNullOrEmpty()) { return; }

                        string detail = gView.GetFocusedDataRow()["MODEL_CODE"].ToString();

                        foreach (DataRow row in dtView.Rows)
                        {
                            if (row["MODEL_CODE"].ToString() == detail && detail != "")
                            {
                                cnt++;
                            }
                        }

                        if (cnt > 1)
                        {
                            acMessageBox.Show("동일한 세부모델이 이미 존재합니다.", "모델 관리", acMessageBox.emMessageBoxType.CONFIRM);

                            gView.SetFocusedRowCellValue("MODEL_CODE", null);
                        }

                        break;
                }
            }
            catch
            {
               
            }
        }




        void acGridView4_ShowGridMenuEx(object sender, PopupMenuShowingEventArgs e)
        {
            acGridView view = sender as acGridView;

            if (e.HitInfo.HitTest == GridHitTest.EmptyRow || e.HitInfo.HitTest == GridHitTest.Row || e.HitInfo.HitTest == GridHitTest.RowCell)
            {
                if (e.MenuType == GridMenuType.User)
                {
                    barItemDeleteVendor.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                }
                else if (e.MenuType == GridMenuType.Row)
                {
                    if (e.HitInfo.RowHandle >= 0)
                    {
                        barItemDeleteVendor.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    }
                    else
                    {
                        barItemDeleteVendor.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    }
                }

                GridHitInfo hitInfo = view.CalcHitInfo(e.Point);

                if (hitInfo.InColumn == false)
                {
                    popupMenu4.ShowPopup(view.GridControl.PointToScreen(e.Point));
                }

            }
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






        private void acGridView4_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            //if (e.FocusedRowHandle < 0) return;

            acGridView1.ClearRow();
            acGridView2.ClearRow();

            // 모델
            btnAddGubun.Enabled = false;
            btnSaveGubun.Enabled = false;
            // 세부모델
            btnAddSerise.Enabled = false;
            btnSaveSerise.Enabled = false;


            acGridView view = sender as acGridView;

            DataRow focusRow = view.GetFocusedDataRow();

            if (focusRow == null)
            {
                return;
            }
            else if (focusRow["SCODE"].ToString() == string.Empty)
            {
                return;
            }

            btnAddGubun.Enabled = true;
            btnSaveGubun.Enabled = true;

            //btnAddSerise.Enabled = true;
            //btnSaveSerise.Enabled = true;
            //btnAddModel.Enabled = false;
            //btnSaveModel.Enabled = false;

            SearchDetail();
        }





        private void acGridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            //if (e.FocusedRowHandle < 0) return;

            acGridView2.ClearRow();
           
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

            SearchDetail2();            
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

            acGridView1.AddCheckEdit("SEL", "선택", "", false, true, true, acGridView.emCheckEditDataType._STRING);

            acGridView1.AddTextEdit("MODEL_CODE", "모델코드", "", false, DevExpress.Utils.HorzAlignment.Near, true, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("MODEL_NAME", "모델명", "", false, DevExpress.Utils.HorzAlignment.Near, true, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddCheckEdit("USE_FLAG", "사용여부", "", false, true, true, acGridView.emCheckEditDataType._STRING);
            //acGridView1.AddRadioGroup("USE_FLAG", "사용여부", "", false, true, true, false, "S900");

            acGridView1.AddTextEdit("SCOMMENT", "비고", "", false, DevExpress.Utils.HorzAlignment.Near, true, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("EMP_CODE", "잠금자코드", "", false, DevExpress.Utils.HorzAlignment.Near, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("EMP_NAME", "잠금자", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddHidden("LOCK_FLAG", typeof(byte));

            acGridView1.AddHidden("SCODE", typeof(string));
           
            acGridView1.AddHidden("P_SCODE", typeof(string));

            acGridView1.KeyColumn = new string[] { "SCODE" };

            acGridView1.OptionsView.ShowIndicator = true;

            //acGridView1.OptionsView.NewItemRowPosition = NewItemRowPosition.Top;

            acGridView1.OptionsBehavior.Editable = true;



            acGridView2.GridType = acGridView.emGridType.FIXED_SINGLE;

            acGridView2.AddCheckEdit("SEL", "선택", "", false, true, true, acGridView.emCheckEditDataType._STRING);

            acGridView2.AddTextEdit("MODEL_CODE", "모델코드", "", false, DevExpress.Utils.HorzAlignment.Near, true, true, false, acGridView.emTextEditMask.NONE);

            acGridView2.AddTextEdit("MODEL_NAME", "모델명", "", false, DevExpress.Utils.HorzAlignment.Near, true, true, false, acGridView.emTextEditMask.NONE);

            acGridView2.AddCheckEdit("USE_FLAG", "사용여부", "", false, true, true, acGridView.emCheckEditDataType._STRING);
            //acGridView2.AddRadioGroup("USE_FLAG", "사용여부", "", false, true, true, false, "S900");

            acGridView2.AddTextEdit("SCOMMENT", "비고", "", false, DevExpress.Utils.HorzAlignment.Near, true, true, false, acGridView.emTextEditMask.NONE);

            acGridView2.AddTextEdit("EMP_CODE", "잠금자코드", "", false, DevExpress.Utils.HorzAlignment.Near, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("EMP_NAME", "잠금자", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView2.AddHidden("LOCK_FLAG", typeof(byte));

            acGridView2.AddHidden("SCODE", typeof(string));

            acGridView2.KeyColumn = new string[] { "SCODE" };

            acGridView2.OptionsView.ShowIndicator = true;

            //acGridView2.OptionsView.NewItemRowPosition = NewItemRowPosition.Top;



            acGridView4.GridType = acGridView.emGridType.FIXED_SINGLE;

            DataSet refSet = acInfo.RefData.Clone();

            refSet.Tables["RQSTDT"].Columns.Add("VEN_TYPE_IN", typeof(string));

            DataRow refRow = refSet.Tables["RQSTDT"].NewRow();
            refRow["PLT_CODE"] = acInfo.PLT_CODE;
            refRow["VEN_TYPE_IN"] = "1,3";

            refSet.Tables["RQSTDT"].Rows.Add(refRow);

            //DataTable dtVen = BizRun.QBizRun.ExecuteService(this, "CTRL", "CONTROL_VENDOR_SEARCH", ExtensionMethods.GetCubizParam("VEN_TYPE:3"), "RQSTDT", "RSLTDT").Tables["RSLTDT"];
            DataTable dtVen = BizRun.QBizRun.ExecuteService(this, "CTRL", "CONTROL_VENDOR_SEARCH", refSet, "RQSTDT", "RSLTDT").Tables["RSLTDT"];

            acGridView4.AddCheckEdit("SEL", "선택", "", false, true, true, acGridView.emCheckEditDataType._STRING);

            acGridView4.AddLookUpEdit("VEN_CODE", "발주처", "", false, DevExpress.Utils.HorzAlignment.Near, true, true, false, "VEN_NAME", "VEN_CODE", dtVen);

            acGridView4.AddCheckEdit("USE_FLAG", "사용여부", "", false, false, false, acGridView.emCheckEditDataType._STRING);

            acGridView4.AddTextEdit("SCOMMENT", "비고", "", false, DevExpress.Utils.HorzAlignment.Near, true, true, false, acGridView.emTextEditMask.NONE);

            acGridView4.AddTextEdit("EMP_CODE", "잠금자코드", "", false, DevExpress.Utils.HorzAlignment.Near, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView4.AddTextEdit("EMP_NAME", "잠금자", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView4.AddHidden("LOCK_FLAG", typeof(byte));

            acGridView4.AddHidden("SCODE", typeof(string));

            acGridView4.KeyColumn = new string[] { "SCODE" };

            acGridView4.OptionsView.ShowIndicator = true;



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
                paramTable.Columns.Add("EMP_CODE", typeof(String));

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["DATA_TYPE"] = "V";
                paramRow["EMP_CODE"] = acInfo.UserID;

                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);


                BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.LOAD,
                "ORD07A_SER", paramSet, "RQSTDT", "RSLTDT",
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
                acGridView4.GridControl.DataSource = e.result.Tables["RSLTDT"];

                acGridView4.BestFitColumns();

                acGridView4.SetOldFocusRowHandle(true);
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
                if (acGridView4.RowCount == 0)
                {
                    acGridView1.ClearRow();
                    acGridView2.ClearRow();
                    return;
                }

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String));
                paramTable.Columns.Add("DATA_TYPE", typeof(String));
                paramTable.Columns.Add("P_SCODE", typeof(String));
                paramTable.Columns.Add("EMP_CODE", typeof(String));

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["DATA_TYPE"] = "T";
                paramRow["P_SCODE"] = acGridView4.GetFocusedDataRow()["SCODE"];
                paramRow["EMP_CODE"] = acInfo.UserID;

                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);


                BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.LOAD_DETAIL,
                "ORD07A_SER2", paramSet, "RQSTDT", "RSLTDT",
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
                acGridView1.GridControl.DataSource = e.result.Tables["RSLTDT"];

                acGridView1.BestFitColumns();

                acGridView1.SetOldFocusRowHandle(true);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }


        void SearchDetail2()
        {
            try
            {
              
                if (acGridView4.RowCount == 0)
                {
                    acGridView1.ClearRow();
                    acGridView2.ClearRow();
                    return;
                }

                DataRow drFocusVendor = acGridView4.GetFocusedDataRow();
                DataRow drFocusModel = acGridView1.GetFocusedDataRow();

                // 발주처와 모델이 일치하지 않은 상태에서 조회하는 경우를 방지
                if (drFocusVendor["SCODE"].ToString() != drFocusModel["P_SCODE"].ToString()) { return; }

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String));
                paramTable.Columns.Add("DATA_TYPE", typeof(String));
                paramTable.Columns.Add("P_SCODE", typeof(String));
                paramTable.Columns.Add("EMP_CODE", typeof(String));

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["DATA_TYPE"] = "M";

                paramRow["P_SCODE"] = acGridView1.GetFocusedDataRow()["SCODE"];
                paramRow["EMP_CODE"] = acInfo.UserID;

                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);


                BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.LOAD_DETAIL,
                "ORD07A_SER2", paramSet, "RQSTDT", "RSLTDT",
                QuickSearchDetail2,
                QuickException);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void QuickSearchDetail2(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                acGridView2.GridControl.DataSource = e.result.Tables["RSLTDT"];

                acGridView2.BestFitColumns();
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



        /// <summary>
        /// 발주처 저장
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveVendor_Click(object sender, EventArgs e)
        {
            SetSaveUseFlag(acGridView4, "V");
           
        }



        /// <summary>
        /// 모델 저장
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveGubun_Click(object sender, EventArgs e)
        {
            SetSaveUseFlag(acGridView1,"T");
            //acGridView4_FocusedRowChanged(acGridView4, null);
        }

        /// <summary>
        /// 세부 모델 저장
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveSerise_Click(object sender, EventArgs e)
        {
            SetSaveUseFlag(acGridView2,"M");
            //acGridView1_FocusedRowChanged(acGridView1, null);
        }

        /// <summary>
        /// 사용X
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            dtParam.Columns.Add("VEN_CODE", typeof(String));
            dtParam.Columns.Add("DATA_TYPE", typeof(String));
            dtParam.Columns.Add("MODEL_CODE", typeof(String));
            dtParam.Columns.Add("MODEL_NAME", typeof(String));            
            dtParam.Columns.Add("USE_FLAG", typeof(String));
            dtParam.Columns.Add("SCOMMENT", typeof(String));
            dtParam.Columns.Add("REG_EMP", typeof(String));


            foreach (DataRow row in view.GetAddModifyRows().Rows)
            {
                DataRow drParam = dtParam.NewRow();
                drParam["PLT_CODE"] = acInfo.PLT_CODE;
                drParam["SCODE"] = row["SCODE"];
                drParam["DATA_TYPE"] = data_type;
              
                if (data_type == "V") // 발주처
                {
                    if (row["VEN_CODE"].isNullOrEmpty()) { continue; }
                    drParam["VEN_CODE"] = row["VEN_CODE"];
                }

                if (data_type == "T") // 모델
                {
                    if (row["MODEL_CODE"].isNullOrEmpty()) { continue; }
                    drParam["P_SCODE"] = acGridView4.GetFocusedDataRow()["SCODE"];
                    drParam["MODEL_CODE"] = row["MODEL_CODE"];
                    drParam["MODEL_NAME"] = row["MODEL_NAME"]; 
                    drParam["USE_FLAG"] = row["USE_FLAG"];
                }

                if (data_type == "M") // 세부모델
                {
                    if (row["MODEL_CODE"].isNullOrEmpty()) { continue; }
                    drParam["P_SCODE"] = acGridView1.GetFocusedDataRow()["SCODE"];
                    drParam["MODEL_CODE"] = row["MODEL_CODE"];
                    drParam["MODEL_NAME"] = row["MODEL_NAME"]; 
                    drParam["USE_FLAG"] = row["USE_FLAG"];
                }

               
                drParam["SCOMMENT"] = row["SCOMMENT"];
                drParam["REG_EMP"] = acInfo.UserID;

                dtParam.Rows.Add(drParam);
            }

            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(dtParam);

            if (dtParam.Rows.Count == 0)
            {
                return;
            }

            try
            {

                DataSet dsRslt = BizRun.QBizRun.ExecuteService(this, "ORD07A_INS", paramSet, "RQSTDT", "RSLTDT");
                Search();

                acAlert.Show(this, "저장 되었습니다.", acAlertForm.enmType.Success);
            }
            catch(BizException ex)
            {
                acMessageBox.Show(this,ex);
            }

        }

        private acGridView _deleteView = null;

        private void barItemDeleteGubun_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _deleteView = acGridView1;

            DataRow row = acGridView1.GetFocusedDataRow();
            if (row["MODEL_CODE"].isNullOrEmpty() || btnAddSerise.Enabled == false)
            {
                acGridView1.GetFocusedDataRow().Delete();
                return;
            }

            SetDeleteUseFlag(acGridView1);
           
        }

        private void barItemDeleteSerise_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _deleteView = acGridView2;

            DataRow row = acGridView2.GetFocusedDataRow();
            if (row["MODEL_CODE"].isNullOrEmpty()) 
            {
                acGridView2.GetFocusedDataRow().Delete();
                return;
            }

            SetDeleteUseFlag(acGridView2);
          
        }

        private void barItemDeleteModel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SetDeleteUseFlag(acGridView3);
          
        }

        private void barItemDeleteVendor_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _deleteView = acGridView4;

            DataRow row = acGridView4.GetFocusedDataRow();
            if (row["VEN_CODE"].isNullOrEmpty() || btnAddGubun.Enabled == false) 
            {
                acGridView4.GetFocusedDataRow().Delete();
                return;
            }

            SetDeleteUseFlag(acGridView4);
            acGridView4_FocusedRowChanged(acGridView4, null);
        }





        private void SetDeleteUseFlag(acGridView view)
        {

            ParameterYesNoDialogResult msgResult = acMessageBox.ShowParameterYesNo(this, "정말 삭제하시겠습니까?", "TB43FSY3", true, acInfo.Resource.GetString("삭제사유", "A9DY9R6G"));


            if (msgResult.DialogResult == DialogResult.No)
            {
                return;
            }

            DataView selectedView = view.GetDataSourceView("SEL = '1'");

            DataTable dtParam = new DataTable("RQSTDT");
            dtParam.Columns.Add("PLT_CODE", typeof(String));
            dtParam.Columns.Add("SCODE", typeof(String));            
            dtParam.Columns.Add("DEL_EMP", typeof(String));

            if (selectedView.Count == 0)
            {
                if (view.GetFocusedDataRow()["LOCK_FLAG"].toStringEmpty() == "1") return;

                DataRow drParam = dtParam.NewRow();
                drParam["PLT_CODE"] = acInfo.PLT_CODE;
                drParam["SCODE"] = view.GetFocusedDataRow()["SCODE"];
                drParam["DEL_EMP"] = acInfo.UserID;

                dtParam.Rows.Add(drParam);
            }
            else
            {
                for (int i = 0; i < selectedView.Count; i++)
                {
                    if (selectedView[i]["LOCK_FLAG"].toStringEmpty() == "1") continue;

                    DataRow drParam = dtParam.NewRow();
                    drParam["PLT_CODE"] = acInfo.PLT_CODE;
                    drParam["SCODE"] = selectedView[i]["SCODE"];
                    drParam["DEL_EMP"] = acInfo.UserID;

                    dtParam.Rows.Add(drParam);
                }
            }

            if (dtParam.Rows.Count > 0)
            {
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(dtParam);

                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.DEL, "ORD07A_DEL", paramSet, "RQSTDT", "", QuickDel, QuickException);
            }
            //view.DeleteMappingRow(view.GetFocusedDataRow());

            ////acMessageBox.Show(this, "삭제 완료!", "", false, acMessageBox.emMessageBoxType.CONFIRM);
            //acAlert.Show(this, "삭제 되었습니다.", acAlertForm.enmType.Info);
        }


        void QuickDel(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                if (_deleteView != null)
                {
                    foreach (DataRow row in e.result.Tables["RQSTDT"].Rows)
                    {
                        _deleteView.DeleteMappingRow(row);
                    }
                }

                acAlert.Show(this, "삭제 되었습니다.", acAlertForm.enmType.Info);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
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

        private void btnAddVendor_Click(object sender, EventArgs e)
        {
            acGridView4.AddNewRow();
            // acGridView4.SetRowCellValue(acGridView3.FocusedRowHandle, "USE_FLAG", "1");

     
        }

        private void btnVenLock_Click(object sender, EventArgs e)
        {

            DataSet paramSet = saveSet(acGridView4, "V", 1);

            if (paramSet == null) return;

            BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.PROCESS,
            "ORD07A_INS2", paramSet, "RQSTDT", "RSLTDT",
            QuickVenLock, QuickException);
        }

        void QuickVenLock(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                foreach (DataRow row in e.result.Tables["RSLTDT"].Rows)
                {
                    acGridView4.UpdateMapingRow(row, false);
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void btnModelLock_Click(object sender, EventArgs e)
        {
            DataSet paramSet = saveSet(acGridView1, "T", 1);

            if (paramSet == null) return;

            BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.PROCESS,
            "ORD07A_INS2", paramSet, "RQSTDT", "RSLTDT",
            QuickModelLock, QuickException);
        }

        void QuickModelLock(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                foreach (DataRow row in e.result.Tables["RSLTDT"].Rows)
                {
                    acGridView1.UpdateMapingRow(row, false);
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void btnDetailModelLock_Click(object sender, EventArgs e)
        {
            DataSet paramSet = saveSet(acGridView2, "M", 1);

            if (paramSet == null) return;

            BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.PROCESS,
            "ORD07A_INS2", paramSet, "RQSTDT", "RSLTDT",
            QuickDetailModelLock, QuickException);
        }

        void QuickDetailModelLock(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                foreach (DataRow row in e.result.Tables["RSLTDT"].Rows)
                {
                    acGridView2.UpdateMapingRow(row, false);
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }



        DataSet saveSet(acGridView gv, string type, byte lockflag)
        {
            gv.EndEditor();

            DataRow focusRow = gv.GetFocusedDataRow();

            if (focusRow == null) return null;

            DataView selectedView = gv.GetDataSourceView("SEL = '1'");

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(string));
            paramTable.Columns.Add("SCODE", typeof(string));
            paramTable.Columns.Add("EMP_CODE", typeof(string));
            paramTable.Columns.Add("LOCK_FLAG", typeof(byte));
            paramTable.Columns.Add("MODEL_TYPE", typeof(string));

            if (selectedView.Count == 0)
            {
                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["SCODE"] = focusRow["SCODE"];

                //byte lockFlag = 0;
                //if (focusRow["LOCK_FLAG"].ToString() == "0")
                //{
                //    lockFlag = 1;
                //}

                //if (lockflag == focusRow["LOCK_FLAG"].toByte()) return null;

                if (lockflag == 0)
                {
                    if (focusRow["LOCK_FLAG"].toStringEmpty() == "1")
                    {
                        if (focusRow["EMP_CODE"].toStringEmpty() != acInfo.UserID)
                        {
                            acAlert.Show(this, "잠금자만 해제할 수 있습니다.", acAlertForm.enmType.Info);
                            return null;
                        }
                    }
                }
                else if (lockflag == 1)
                {
                    paramRow["EMP_CODE"] = acInfo.UserID;

                    if (focusRow["LOCK_FLAG"].toStringEmpty() == "1"
                        && focusRow["EMP_CODE"].toStringEmpty() != acInfo.UserID)
                    {
                        acAlert.Show(this, "다른 잠금자가 존재합니다.", acAlertForm.enmType.Info);
                        return null;
                    }
                }

                paramRow["LOCK_FLAG"] = lockflag;
                paramRow["MODEL_TYPE"] = type;

                paramTable.Rows.Add(paramRow);

            }
            else
            {
                for (int i = 0; i < selectedView.Count; i++)
                {
                    DataRow paramRow = paramTable.NewRow();
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["SCODE"] = selectedView[i]["SCODE"];

                    //byte lockFlag = 0;
                    //if (selectedView[i]["LOCK_FLAG"].ToString() == "0")
                    //{
                    //    lockFlag = 1;
                    //}

                    //if (lockflag == selectedView[i]["LOCK_FLAG"].toByte()) continue;

                    if (lockflag == 0)
                    {
                        if (selectedView[i]["LOCK_FLAG"].toStringEmpty() == "1")
                        {
                            if (selectedView[i]["EMP_CODE"].toStringEmpty() != acInfo.UserID)
                            {
                                acAlert.Show(this, "잠금자만 해제할 수 있습니다.", acAlertForm.enmType.Info);
                                return null;
                            }
                        }
                    }
                    else if (lockflag == 1)
                    {
                        paramRow["EMP_CODE"] = acInfo.UserID;

                        if (selectedView[i]["LOCK_FLAG"].toStringEmpty() == "1"
                            && selectedView[i]["EMP_CODE"].toStringEmpty() != acInfo.UserID)
                        {
                            acAlert.Show(this, "다른 잠금자가 존재합니다.", acAlertForm.enmType.Info);
                            return null;
                        }
                    }

                    paramRow["LOCK_FLAG"] = lockflag;
                    paramRow["MODEL_TYPE"] = type;

                    paramTable.Rows.Add(paramRow);
                }
            }

            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            return paramSet;
        }

        private void btnVenUnLock_Click(object sender, EventArgs e)
        {
            DataSet paramSet = saveSet(acGridView4, "V", 0);

            if (paramSet == null) return;

            BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.PROCESS,
            "ORD07A_INS2", paramSet, "RQSTDT", "RSLTDT",
            QuickVenLock, QuickException);
        }

        private void btnModelUnLock_Click(object sender, EventArgs e)
        {
            DataSet paramSet = saveSet(acGridView1, "T", 0);

            if (paramSet == null) return;

            BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.PROCESS,
            "ORD07A_INS2", paramSet, "RQSTDT", "RSLTDT",
            QuickModelLock, QuickException);
        }

        private void btnDetailModelUnLock_Click(object sender, EventArgs e)
        {
            DataSet paramSet = saveSet(acGridView2, "M", 0);

            if (paramSet == null) return;

            BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.PROCESS,
            "ORD07A_INS2", paramSet, "RQSTDT", "RSLTDT",
            QuickDetailModelLock, QuickException);
        }
    }
}

