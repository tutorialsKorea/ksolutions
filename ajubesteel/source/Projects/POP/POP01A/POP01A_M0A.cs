using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ControlManager;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;
using BizManager;
using CodeHelperManager;
using System.Linq;
using DevExpress.XtraGrid.Columns;
using System.Collections;
using System.IO;

namespace POP
{
    public sealed partial class POP01A_M0A : BaseMenu
    {

        private GridHitInfo _downHitInfo = null;

        public POP01A_M0A()
        {
            InitializeComponent();
        }

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




        public override void MenuGotFocus()
        {

            base.MenuGotFocus();
        }

        public override void MenuLostFocus()
        {

            base.MenuLostFocus();

        }

        public override bool MenuDestory(object sender)
        {

            if (this._IsChanged == true && acMessageBox.Show(this, "수정된 항목이 있습니다.종료 하시겠습니까?", "QAISR59B", false, acMessageBox.emMessageBoxType.YESNO) != DialogResult.Yes)
            {
                return false;
            }

            return base.MenuDestory(sender);

        }


        public override void MenuLink(object data)
        {
            //try
            //{
            //검색조건 초기화
            //acCheckedComboBoxEdit1.Text = "";
            //foreach (acCheckedListBoxItem item in acCheckedComboBoxEdit1.Properties.Items)
            //{
            //    item.CheckState = System.Windows.Forms.CheckState.Unchecked;
            //}
            //acTextEdit1.Text = "";

            //acTextEdit1.Text = ((DataRow)data)["ITEM_CODE"].ToString();

            this.Search();
            //}
            //catch { }
        }

        private Dictionary<string, string> _dicProcStat = null;
        private DataTable _dtDeleteList = null;
        //private Hashtable _htWoList = null;
        //private Hashtable _htWoFig = null;

        public override void MenuInit()
        {

            acGridView1.GridType = acGridView.emGridType.SEARCH_SEL;

            acGridView1.AddTextEdit("CAM_CNT", "지정/미지정", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("PROD_CODE", "수주번호", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("PROD_NAME", "모델명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddLookUpEdit("PROD_FLAG", "수주유형", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P006");
            acGridView1.AddTextEdit("PROD_VERSION", "버전", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddLookUpEdit("PROD_KIND", "제품구분", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "C011");
            acGridView1.AddCheckedComboBoxEdit("PROD_CATEGORY", "제품유형", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, "P009");
            acGridView1.AddLookUpEmp("BUSINESS_EMP", "영업담당자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false);
            acGridView1.AddTextEdit("CUSTOMER_EMP", "고객담당자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("CUSTDESIGN_EMP", "고객설계자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddDateEdit("ORD_DATE", "수주일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
            acGridView1.AddDateEdit("DUE_DATE", "출하예정일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
            acGridView1.AddDateEdit("CHG_DUE_DATE", "출하조정일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
            //acGridView1.AddDateEdit("DELIVERY_DATE", "납품일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);

            acGridView1.AddLookUpEdit("PROD_PRIORITY", "우선순위", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P028");

            acGridView1.AddLookUpEdit("PIN_TYPE", "Contact", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P011");
            acGridView1.AddLookUpEdit("PROD_TYPE", "제품분류", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P010");
            acGridView1.AddTextEdit("PROD_QTY", "수주수량", "CPW0FS8W", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NUMERIC);

            acGridView1.AddCheckEdit("HAS_DRAW", "도면", "", false, false, true, acGridView.emCheckEditDataType._STRING);

            acGridView1.AddDateEdit("END_TIME", "실적완료시간", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.LONG_DATE);

            acGridView1.AddTextEdit("PART_CODE", "품목코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("DRAW_EMP", "조립품 개발자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("ORD_SCOMMENT", "영업 전달사항", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.KeyColumn = new string[] { "PROD_CODE" };


            acGridView2.GridType = acGridView.emGridType.SEARCH;

            acGridView2.AddLookUpEdit("IS_OS", "제작구분", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P016");
            acGridView2.AddLookUpEdit("IS_REWORK", "재작업여부", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "W012");

            acGridView2.AddTextEdit("PART_CODE", "부품코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("PART_NAME", "부품명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView2.AddTextEdit("DRAW_NO", "도면명", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

            //acGridView2.AddTextEdit("MAT_NAME", "소재명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("MAT_QLTY", "재질", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("PART_QTY", "수량", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView2.AddLookUpEdit("MC_GROUP", "설비그룹", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "C020");
            acGridView2.AddLookUpEmp("CAM_EMP", "담당자", "", false, DevExpress.Utils.HorzAlignment.Center, true, true, false,"IS_CAM = 1");

            

            acGridView2.AddHidden("WO_NO", typeof(string));

            acGridView2.KeyColumn = new string[] { "WO_NO" };

            acGridView2.OptionsView.ShowIndicator = true;

            //if(acGridView2.Columns["LOAD_FLAG"] is GridColumn gc)
            //{
            //    if(gc.ColumnEdit is DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit rce)
            //    {
            //        rce.ValueChecked = (Byte)0;
            //        rce.ValueUnchecked = (Byte)1;
            //    }
            //}
            acCheckedComboBoxEdit1.AddItem("등록일", false, "", "REG_DATE", true, false);
            acCheckedComboBoxEdit1.AddItem("수주일", false, "", "ORD_DATE", true, false);
            acCheckedComboBoxEdit1.AddItem("출하예정일", false, "", "DUE_DATE", true, false);
            //acCheckedComboBoxEdit1.AddItem("납품일", false, "", "DELIVERY_DATE", true, false);

            this.acLayoutControl1.OnValueKeyDown += new acLayoutControl.ValueKeyDownEventHandler(acLayoutControl1_OnValueKeyDown);
            this.acLayoutControl1.OnValueChanged += new acLayoutControl.ValueChangedEventHandler(acLayoutControl1_OnValueChanged);

            this.acGridView1.CustomDrawCell += AcGridView1_CustomDrawCell;
            this.acGridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(acGridView1_FocusedRowChanged);
            //this.acGridView1.MouseDown += new MouseEventHandler(acGridView1_MouseDown);
            this.acGridView1.ShowGridMenuEx += new acGridView.ShowGridMenuExHandler(acGridView1_ShowGridMenuEx);
            this.acGridView1.OnMapingRowChanged += new acGridView.MapingRowChangedEventHandler(acGridView1_OnMapingRowChanged);

            this.acGridView2.MouseDown += new MouseEventHandler(acGridView2_MouseDown);
            this.acGridView2.MouseMove += AcGridView2_MouseMove;
            this.acGridView2.EndSorting += AcGridView2_EndSorting;
            //this.acGridView2.ShowGridMenuEx += new acGridView.ShowGridMenuExHandler(acGridView2_ShowGridMenuEx);
            this.acGridView2.OnMapingRowChanged += new acGridView.MapingRowChangedEventHandler(acGridView2_OnMapingRowChanged);
            //this.acGridView2.CellValueChanged += acGridView2_CellValueChanged;
            //this.acGridView2.CustomDrawCell += acGridView2_CustomDrawCell;
            //this.acGridView2.RowCellStyle += acGridView2_RowCellStyle;
            this.acGridView2.Layout += AcGridView2_Layout;

            acGridView2.ShownEditor += acGridView2_ShownEditor;

            //acGridView2.ShowingEditor += acGridView2_ShowingEditor;

            SetBtnEnable(false);

            //this.acGridControl2.ProcessGridKey += acGridControl2_ProcessGridKey;
            //this.acGridView2.RowUpdated += acGridView2_RowUpdated;
            this.acGridView2.CellValueChanged += acGridView2_CellValueChanged;
            //this.acGridView2.RowDeleted += acGridView2_RowDeleted;                        

            base.MenuInit();
        }

        private void acGridView2_ShowingEditor(object sender, CancelEventArgs e)
        {
            acGridView view = sender as acGridView;

            if (view.FocusedColumn.FieldName == "CAM_EMP")
            {
                if (view.GetRowCellValue(view.FocusedRowHandle, "CAM_EMP").isNullOrEmpty())
                {
                    view.SetRowCellValue(view.FocusedRowHandle, "CAM_EMP", acInfo.UserID);

                    //(view.Columns["CAM_EMP"].ColumnEdit as acLookupEdit).sele

                    LookUpEdit lookUpEdit = view.ActiveEditor as LookUpEdit;
                    if (lookUpEdit != null)
                    {
                        //lookUpEdit.IsPopupOpen = true;
                        //Dispatcher.BeginInvoke(new Action(() =>{
                        //    GridControl lookUpGrid = lookUpEdit.GetGridControl();
                        //}));
                    }
                }
            }
        }

        private void acGridView2_ShownEditor(object sender, EventArgs e)
        {
            acGridView view = sender as acGridView;

            if(view.FocusedColumn.FieldName == "CAM_EMP")
            {
                if(view.GetRowCellValue(view.FocusedRowHandle, "CAM_EMP").isNullOrEmpty())
                {
                    view.SetRowCellValue(view.FocusedRowHandle, "CAM_EMP", acInfo.UserID);

                    //(view.Columns["CAM_EMP"].ColumnEdit as acLookupEdit).sele

                    LookUpEdit lookUpEdit = view.ActiveEditor as LookUpEdit;
                    if (lookUpEdit != null)
                    {
                        //lookUpEdit.IsPopupOpen = true;
                        //Dispatcher.BeginInvoke(new Action(() =>{
                        //    GridControl lookUpGrid = lookUpEdit.GetGridControl();
                        //}));
                    }
                }
            }
        }

        private bool _IsChanged = false;

        private void acGridView2_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                this._IsChanged = true;                
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }


        void SetBtnEnable(bool value)
        {
            //btnExcelImport.Enabled = value;
            btnSave.Enabled = value;
            //btnAdd.Enabled = value;
            //btnDelete.Enabled = value;
        }

        private void AcGridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            try
            {
                if (sender is acGridView view)
                {
                    DataRow row = view.GetDataRow(e.RowHandle);
                    if (row == null)
                        return;

                    if (row["PROD_STATE"].ToString() == "5")
                    {
                        e.Appearance.BackColor = Color.Orange;
                        e.Appearance.ForeColor = Color.Black;
                    }

                    //string PROD_PRIORITY = acGridView1.GetRowCellValue(e.RowHandle, "PROD_PRIORITY").ToString();

                    if (row["PROD_KIND"].ToString() == "PE")
                    {
                        e.Appearance.ForeColor = Color.DarkViolet;
                    }

                    if (row["PROD_PRIORITY"].ToString() == "0")
                    {
                        e.Appearance.ForeColor = Color.Red;
                    }
                }
            }
            catch
            {

            }
        }

        private void AcGridControl2_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        {
            e.UseDefaultCursors = false;
        }

        private void AcGridControl2_DragLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void AcGridView2_Layout(object sender, EventArgs e)
        {
            if(sender is GridView gv)
            {
                //if(gv.SortedColumns.Count ==0)
                //{
                //    gv.Columns["PROD_SEQ"].SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
                //}
            }
        }

        private void AcGridView2_EndSorting(object sender, EventArgs e)
        {
            if (sender is GridView gv)
            {
                try
                {
                    if (gv.SortedColumns.Count == 1
                        && gv.SortedColumns.FirstOrDefault().FieldName.Equals("PROD_SEQ"))
                    {
                        for (int rowIndex = 0; rowIndex < ((DataView)this.acGridView2.DataSource).Count; rowIndex++)
                        {
                            if (gv != null)
                            {
                                DataRowView drv = (gv.DataSource as System.Data.DataView)[rowIndex];
                                if (!drv.isNullOrEmpty())
                                {
                                    int rowHandle = gv.GetRowHandle(rowIndex);
                                    drv["PROD_SEQ"] = rowHandle + 1;
                                }
                            }
                        }
                    }
                }catch
                {

                }
            }
        }

        private void AcGridView2_MouseMove(object sender, MouseEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.Button == MouseButtons.Left && _downHitInfo != null)
            {
                Size dragSize = SystemInformation.DragSize;
                Rectangle dragRect = new Rectangle(new Point(_downHitInfo.HitPoint.X - dragSize.Width / 2,
                    _downHitInfo.HitPoint.Y - dragSize.Height / 2), dragSize);

                if (!dragRect.Contains(new Point(e.X, e.Y)))
                {
                    if (view != null) view.GridControl.DoDragDrop(_downHitInfo, DragDropEffects.All);
                    _downHitInfo = null;
                    DevExpress.Utils.DXMouseEventArgs.GetMouseArgs(e).Handled = true;
                }
            }
        }

        private void AcGridControl2_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.All;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void AcGridControl2_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                this.Cursor = Cursors.Default;
                //string[] dataFormats = e.Data.GetFormats();

                //if (dataFormats.Any())
                //{
                if (e.Data.GetDataPresent(typeof(GridHitInfo)))
                    {
                        //그리드 로우 순서 변경

                        GridControl grid = (GridControl)sender;

                        if (grid != null)
                        {
                            acGridView view = grid.MainView as acGridView;
                            view.EndEditor();
                            //ClearSorting(FileGridView);
                            GridHitInfo srcHitInfo = e.Data.GetData(typeof(GridHitInfo)) as GridHitInfo;
                            if (view != null)
                            {
                                GridHitInfo hitInfo = view.CalcHitInfo(grid.PointToClient(new Point(e.X, e.Y)));
                                if (srcHitInfo != null)
                                {
                                    int sourceRow = srcHitInfo.RowHandle;
                                    int targetRow = hitInfo.RowHandle;
                                    MoveRow(acGridView2, sourceRow, targetRow);
                                    SetRowSeqAfterSort(acGridView2);
                                }
                            }
                        }
                    }
              //  }
            }
            catch (Exception ex)
            {

            }
        }

        private void AcGridControl2_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(GridHitInfo)))
            {
                GridHitInfo downHitInfo = e.Data.GetData(typeof(GridHitInfo)) as GridHitInfo;
                if (downHitInfo == null)
                    return;

                if (sender is GridControl)
                {
                    acGridControl grid = sender as acGridControl;
                    if (grid.MainView is GridView)
                    {
                        acGridView view = grid.MainView as acGridView;
                        GridHitInfo hitInfo = view.CalcHitInfo(grid.PointToClient(new Point(e.X, e.Y)));
                        if (hitInfo.InRow && hitInfo.RowHandle != downHitInfo.RowHandle && hitInfo.RowHandle != GridControl.NewItemRowHandle)
                        {
                            e.Effect = DragDropEffects.Move;
                            this.Cursor = acGraphics.CreateCursor(view.GetFocusRowImage(acGridView.emFocusRowImageType.MOVE), 0, 0);
                        }
                        else
                            e.Effect = DragDropEffects.None;

                    }
                }
            }
        }

        void acGridView1_OnMapingRowChanged(acGridView.emMappingRowChangedType type, DataRow row)
        {
            if (type == acGridView.emMappingRowChangedType.DELETE)
            {
                string formKey = string.Format("{0},{1}", "PROD", row["PROD_CODE"]);

                base.ChildFormRemove(formKey);
            }

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

        public override void ChildContainerInit(Control sender)
        {
            //기본값 설정

            if (sender == acLayoutControl1)
            {


                acLayoutControl layout = sender as acLayoutControl;

                layout.GetEditor("DATE").Value = "DUE_DATE";
                layout.GetEditor("S_DATE").Value = acDateEdit.GetNowDateFromServer();
                layout.GetEditor("E_DATE").Value = acDateEdit.GetNowDateFromServer().AddDays(7);


            }


            base.ChildContainerInit(sender);
        }


        void acLayoutControl1_OnValueKeyDown(object sender, IBaseEditControl info, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                this.Search();
            }
        }

        void acGridView2_ShowGridMenuEx(object sender, PopupMenuShowingEventArgs e)
        {

            //마스터 Row가 존재해야 팝업창을 연다.

            if (acGridView1.FocusedRowHandle < 0)
            {
                return;
            }


            acGridView view = sender as acGridView;



            if (e.MenuType == GridMenuType.User)
            {
                //acBarButtonItem5.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                //acBarButtonItem6.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
              
            }
            else if (e.MenuType == GridMenuType.Row)
            {
                if (e.HitInfo.RowHandle >= 0)
                {
                    if (acGridView2.GetRowCellValue(e.HitInfo.RowHandle, "NEW").ToString() == "NEW")
                    {
                        //acBarButtonItem5.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        //acBarButtonItem6.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    }
                    else
                    {
                        //acBarButtonItem5.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        //acBarButtonItem6.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    }
                    
                   
                }
                else
                {

                    //acBarButtonItem5.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    //acBarButtonItem6.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                   

                }

            }


            if (e.HitInfo.HitTest == GridHitTest.EmptyRow || e.HitInfo.HitTest == GridHitTest.Row || e.HitInfo.HitTest == GridHitTest.RowCell)
            {

                GridHitInfo hitInfo = view.CalcHitInfo(e.Point);

                popupMenu2.ShowPopup(view.GridControl.PointToScreen(e.Point));

            }


        }

        void acGridView2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                GridHitInfo hitInfo = acGridView2.CalcHitInfo(e.Location);

                if (hitInfo.HitTest == GridHitTest.RowCell || hitInfo.HitTest == GridHitTest.Row)
                {
                    //수주 편집기 열기

                    //this.acBarButtonItem5_ItemClick(null, null);
                }

            }
            else if(e.Button == MouseButtons.Left)
            {
                GridView view = sender as GridView;
                _downHitInfo = null;

                if (view != null)
                {
                    GridHitInfo hitInfo = view.CalcHitInfo(new Point(e.X, e.Y));
                    if (Control.ModifierKeys != Keys.None)
                        return;
                    if (e.Button == MouseButtons.Left && hitInfo.InRow && hitInfo.RowHandle != GridControl.NewItemRowHandle)
                        _downHitInfo = hitInfo;
                }
            }

        }

        //void acGridView1_ShowGridMenuEx(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        //{
        //    acGridView view = sender as acGridView;

        //    if (e.MenuType == GridMenuType.User)
        //    {
        //        //acBarButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
        //        //acBarButtonItem3.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;


        //    }
        //    else if (e.MenuType == GridMenuType.Row)
        //    {
        //        if (e.HitInfo.RowHandle >= 0)
        //        {
        //            //acBarButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
        //            //acBarButtonItem3.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
        //        }
        //        else
        //        {
        //            //acBarButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
        //            //acBarButtonItem3.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
        //        }

        //    }


        //    if (e.HitInfo.HitTest == GridHitTest.EmptyRow || e.HitInfo.HitTest == GridHitTest.Row || e.HitInfo.HitTest == GridHitTest.RowCell)
        //    {

        //        GridHitInfo hitInfo = view.CalcHitInfo(e.Point);

        //        popupMenu1.ShowPopup(view.GridControl.PointToScreen(e.Point));


        //    }

        //}




        void acGridView1_ShowGridMenuEx(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            acGridView view = sender as acGridView;

            if (e.MenuType == GridMenuType.User)
            {
                acBarButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                acBarButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                acBarButtonItem3.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
            else if (e.MenuType == GridMenuType.Row)
            {
                if (e.HitInfo.RowHandle >= 0)
                {
                    acBarButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    acBarButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    acBarButtonItem3.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                }
                else
                {
                    acBarButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    acBarButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    acBarButtonItem3.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                }

            }


            if (e.HitInfo.HitTest == GridHitTest.EmptyRow || e.HitInfo.HitTest == GridHitTest.Row || e.HitInfo.HitTest == GridHitTest.RowCell)
            {

                GridHitInfo hitInfo = view.CalcHitInfo(e.Point);

                popupMenu1.ShowPopup(view.GridControl.PointToScreen(e.Point));


            }

        }




        private int _oldRowHandel = -1;

        void acGridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            acGridView view = sender as acGridView;

            if (this._IsChanged == true && acMessageBox.Show(this, "수정된 항목이 있습니다.계속진행 하시겠습니까?", "QAISR59B", false, acMessageBox.emMessageBoxType.YESNO) != DialogResult.Yes)
            {
                acGridView1.FocusedRowChanged -= acGridView1_FocusedRowChanged;
                acGridView1.FocusedRowHandle = this._oldRowHandel;
                //acGridView1.SetOldFocusRowHandle(true);
                acGridView1.FocusedRowChanged += acGridView1_FocusedRowChanged;
                return;
            }

            this._oldRowHandel = acGridView1.FocusedRowHandle;

            if (view.ValidFocusRowHandle())
            {
                this._IsChanged = false;
                if (this._dtDeleteList != null)
                    this._dtDeleteList.Clear();
                this.GetDatail();
                SetBtnEnable(true);
            }
            else
            {
                if(this._dtDeleteList != null)
                    this._dtDeleteList.Clear();
                this._IsChanged = false;                
                acGridView2.ClearRow();
                SetBtnEnable(false);
            }
        }


        void Search()
        {
            //조회
            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("PROD_LIKE", typeof(String)); //수주코드/명 LIKE 검색
            paramTable.Columns.Add("CVND_LIKE", typeof(String)); //발주
            paramTable.Columns.Add("BUSINESS_EMP", typeof(String)); //발주
            paramTable.Columns.Add("S_REG_DATE", typeof(String)); //등록 시작일
            paramTable.Columns.Add("E_REG_DATE", typeof(String)); //등록 종료일
            paramTable.Columns.Add("S_ORD_DATE", typeof(String)); //수주일 시작일
            paramTable.Columns.Add("E_ORD_DATE", typeof(String)); //수주일 종료일
            paramTable.Columns.Add("S_SHIP_DATE", typeof(String)); //출하 시작일
            paramTable.Columns.Add("E_SHIP_DATE", typeof(String)); //출하 종료일
            paramTable.Columns.Add("S_DUE_DATE", typeof(String)); //납기일 시작일
            paramTable.Columns.Add("E_DUE_DATE", typeof(String)); //납기일 종료일
            //paramTable.Columns.Add("S_DELIVERY_DATE", typeof(String)); //납품 시작일
            //paramTable.Columns.Add("E_DELIVERY_DATE", typeof(String)); //납품 종료일
            DataRow layoutRow = acLayoutControl1.CreateParameterRow();

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["PROD_LIKE"] = layoutRow["PROD_LIKE"];
            paramRow["CVND_LIKE"] = layoutRow["CVND_LIKE"];
            paramRow["BUSINESS_EMP"] = layoutRow["BUSINESS_EMP"];


            foreach (string key in acCheckedComboBoxEdit1.GetKeyChecked())
            {
                switch (key)
                {
                    case "REG_DATE":
                        //등록일
                        paramRow["S_REG_DATE"] = layoutRow["S_DATE"];
                        paramRow["E_REG_DATE"] = layoutRow["E_DATE"];

                        break;
                    case "ORD_DATE":
                        //수주일
                        paramRow["S_ORD_DATE"] = layoutRow["S_DATE"];
                        paramRow["E_ORD_DATE"] = layoutRow["E_DATE"];

                        break;
                    case "DUE_DATE":
                        //납기일
                        paramRow["S_DUE_DATE"] = layoutRow["S_DATE"];
                        paramRow["E_DUE_DATE"] = layoutRow["E_DATE"];

                        break;
                    case "SHIP_DATE":
                        //출하일
                        paramRow["S_SHIP_DATE"] = layoutRow["S_DATE"];
                        paramRow["E_SHIP_DATE"] = layoutRow["E_DATE"];

                        break;
                    //case "DELIVERY_DATE":
                    //    //납품일
                    //    paramRow["S_DELIVERY_DATE"] = layoutRow["S_DATE"];
                    //    paramRow["E_DELIVERY_DATE"] = layoutRow["E_DATE"];

                    //    break;
                }
            }


            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);


            BizRun.QBizRun.ExecuteService(
             this, QBiz.emExecuteType.LOAD,
             "POP01A_SER", paramSet, "RQSTDT", "RSLTDT",
             QuickSearch,
             QuickException);
        }


        private void barItemSearch_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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


        void QuickException(object sender, QBiz qBiz, BizManager.BizException ex)
        {

            if (ex.ErrNumber == 200027)
            {
                //부품이 존재하여 삭제할수없음

                acMessageBoxGridConfirm frm = new acMessageBoxGridConfirm(this, "acMessageBoxGridConfirm1", acInfo.BizError.GetDesc(ex.ErrNumber), string.Empty, false, this.Caption, ex.ParameterData);


                frm.View.GridType = acGridView.emGridType.FIXED;

                frm.View.AddTextEdit("PROD_CODE", "금형코드", "40900", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);


                frm.ShowDialog();

            }
            else if (ex.ErrNumber == 200059)
            {
                //세트외주 구매정보가 존재하여 삭제할수없음

                acMessageBoxGridConfirm frm = new acMessageBoxGridConfirm(this, "acMessageBoxGridConfirm2", acInfo.BizError.GetDesc(ex.ErrNumber), string.Empty, false,  this.Caption, ex.ParameterData);

                frm.View.GridType = acGridView.emGridType.FIXED;

                frm.View.AddTextEdit("PROD_CODE", "금형코드", "40900", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);


            }
            else if (ex.ErrNumber == 200083)
            {
                //금형상태가 유효하지않음

                acMessageBoxGridConfirm frm = new acMessageBoxGridConfirm(this, "acMessageBoxGridConfirm3", acInfo.BizError.GetDesc(ex.ErrNumber), string.Empty, false, this.Caption, ex.ParameterData);

                if (ex.ParameterData == null)
                {
                    acMessageBox.Show(this, ex);

                    return;
                }

                foreach (DataRow row in ex.ParameterData.Rows)
                {
                    row["CHECK_PROD_STATE"] = acInfo.StdCodes.GetNameByCodes("S025", row["CHECK_PROD_STATE"]);
                }

                frm.ParentControl = this;

                frm.View.GridType = acGridView.emGridType.FIXED;

                frm.View.AddLookUpEdit("NOW_PROD_STATE", "금형상태", "WJB3HAFK", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "S025");

                frm.View.AddTextEdit("PROD_CODE", "금형코드", "40900", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

                frm.View.AddTextEdit("CHECK_PROD_STATE", "유효 금형상태", "Y91G7XDQ", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);


                frm.ShowDialog();

            }
            else if (ex.ErrNumber == BizManager.BizException.DATA_REFRESH)
            {
                //데이터 갱신
                acMessageBox.Show(this, ex);

                this.DataRefresh("ITEM");
            }
            else if (ex.ErrNumber == 200202)
            {
                acMessageBox.Show("품목이 존재하여 삭제할 수 없습니다. \n품목을 먼저 삭제하세요. ", this.Text, acMessageBox.emMessageBoxType.CONFIRM);
            }
            else if (ex.ErrNumber == 200203)
            {
                acMessageBox.Show("대기 상태인 수주만 삭제 가능합니다.", this.Text, acMessageBox.emMessageBoxType.CONFIRM);
            }
            else if (ex.ErrNumber == 200204)
            {
                acMessageBox.Show("대기 상태인 품목만 삭제 가능합니다.", this.Text, acMessageBox.emMessageBoxType.CONFIRM);
            }
            else
            {
                acMessageBox.Show(this, ex);
            }

        }




        void QuickSearch(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                base.SetData("PROD", e.result);


                acGridView1.GridControl.DataSource = e.result.Tables["RSLTDT"];

                acGridView1.SetOldFocusRowHandle(true);

                base.SetLog(e.executeType, e.result.Tables["RSLTDT"].Rows.Count, e.executeTime);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        void GetDatail()
        {

            DataRow focusRow = acGridView1.GetFocusedDataRow();

            if (focusRow == null)
            {
                acGridView2.ClearRow();

                return;
            }

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("PROD_CODE", typeof(String)); //

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["PROD_CODE"] = focusRow["PROD_CODE"];
            
            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);


            BizRun.QBizRun.ExecuteService(
            this, QBiz.emExecuteType.LOAD_DETAIL,
            "POP01A_SER2", paramSet, "RQSTDT", "RSLTDT",
            QuickDetail,
            QuickException);


        }
        void QuickDetail(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                //this._dicProcStat.Clear();

                //DataTable dtTemp = e.result.Tables["RSLTDT"];

                //foreach (DataRow row in this._dtProcList.Rows)
                //{
                //    dtTemp.Columns.Add(row["PROC_CODE"].ToString(), typeof(string));
                //}

                //foreach(DataRow row in e.result.Tables["RSLTDT_WO"].Rows)
                //{
                //    DataRow[] dataRows = dtTemp.Select(string.Format("PT_ID = '{0}'", row["PT_ID"]));

                //    if (dataRows.Length == 0)
                //        continue;
                //    switch(row["WO_FLAG"].ToString())
                //    {
                //        case "0":
                //        case "1":
                //            dataRows[0][row["PROC_CODE"].ToString()] = row["PLN_START_TIME"].toDateString("MM/dd");
                //            break;
                //        case "2":
                //        case "3":
                //            dataRows[0][row["PROC_CODE"].ToString()] = row["ACT_START_TIME"].toDateString("MM/dd");
                //            break;
                //        case "4":
                //            dataRows[0][row["PROC_CODE"].ToString()] = row["ACT_END_TIME"].toDateString("MM/dd");
                //            break;
                //    }                    
                //    this._dicProcStat.Add(row["PT_ID"].ToString() + row["PROC_CODE"].ToString(), row["WO_FLAG"].ToString());

                //}

                acGridView2.GridControl.DataSource = e.result.Tables["RSLTDT"];
                
                acGridView2.BestFitColumns();

                this._dtDeleteList = (acGridView2.GridControl.DataSource as DataTable).Clone();

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }


        void acGridView2_OnMapingRowChanged(acGridView.emMappingRowChangedType type, DataRow row)
        {
            if (type == acGridView.emMappingRowChangedType.DELETE)
            {
                string formKey = string.Format("{0},{1}", "PROD", row["PROD_CODE"]);

                base.ChildFormRemove(formKey);
            }
        }

        public void MoveRow(GridView views, int sourceRow, int targetRow)
        {
            if (sourceRow == targetRow || sourceRow == targetRow + 1)
                return;
            DataRow row1 = views.GetDataRow(targetRow);
            DataRow row2 = views.GetDataRow(targetRow + 1);
            DataRow dragRow = views.GetDataRow(sourceRow);
            object val1 = row1["PROD_SEQ"];
            if (row2 == null)
                dragRow["PROD_SEQ"] = val1.toDouble() + 1;
            else
            {
                object val2 = row2["PROD_SEQ"];
                dragRow["PROD_SEQ"] = (val1.toDouble() + val2.toDouble()) / 2.0;
            }
        }

        private void SetRowSeqAfterSort(acGridView gridView)
        {
            try
            {
                gridView.BeginSort();

                DataView dv = gridView.GetDataSourceView();
                DataTable paramTable = dv.ToTable();
                paramTable.TableName = "RQSTDT";

                for (int i = 1; i < paramTable.Rows.Count; i++)
                {
                    paramTable.Rows[i - 1]["PROD_SEQ"] = i;
                }

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(this, "ORD02A_UPD", paramSet, "RQSTDT", "RSLTDT");
            }
            finally
            {
                gridView.EndSort();
            }
        }


        private void btnExcelImport_Click(object sender, EventArgs e)
        {
            //엑셀 데이터 불러오기
            try
            {

                //string prod_code = acGridView1.GetFocusedDataRow()["PROD_CODE"].ToString();
                //QCT02A_D0A frm = new QCT02A_D0A(acGridView2,prod_code);

                //frm.ParentControl = this;

                //frm.Text = "검사결과입력";

                //if (frm.ShowDialog() == DialogResult.OK)
                //{
                //    this.Search();
                //}
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DataRow newRow = acGridView2.NewRow();
            newRow["INS_NO"] = ExtensionMethods.GetSerialNo(this,"INS");
            acGridView2._AddRow(newRow);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (acGridView2.RowCount == 0)
                return;

            DataRow[] selected = acGridView2.GetSelectedDataRows();

            this._IsChanged = false;

            if (selected.Length == 0)
            {
                //단일삭제

                DataRow focusRow = acGridView1.GetFocusedDataRow();

                this._dtDeleteList.ImportRow(focusRow);

                acGridView2.DeleteMappingRow(focusRow);

            }
            else
            {

                //다중삭제
                foreach (DataRow row in selected)
                {
                    this._dtDeleteList.ImportRow(row);

                    acGridView2.DeleteMappingRow(row);
                }


            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //엑셀 복사
            try
            {
                //if (acGridView2.RowCount == 0)
                //    return;


                acGridView2.EndEditor();


                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //사업장 코드
                paramTable.Columns.Add("WO_NO", typeof(String)); //
                paramTable.Columns.Add("CAM_EMP", typeof(String)); //
                paramTable.Columns.Add("CAM_EMP_DATE", typeof(String)); //
                paramTable.Columns.Add("REG_EMP", typeof(String)); //
                paramTable.Columns.Add("OVERWRITE", typeof(String)); //

                //DataRow[] rows = acGridView2.GetSelectedDataRows();

                //if (rows.Length == 0)
                //    return;

                foreach (DataRow row in acGridView2.GetAddModifyRows().Rows)
                {

                    DataRow paramRow = paramTable.NewRow();
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["WO_NO"] = row["WO_NO"];
                    paramRow["CAM_EMP"] = row["CAM_EMP"];
                    paramRow["CAM_EMP_DATE"] = acDateEdit.GetNowDateFromServer().toDateString("yyyyMMdd");
                    paramRow["REG_EMP"] = acInfo.UserID;
                    paramRow["OVERWRITE"] = "1";
                    paramTable.Rows.Add(paramRow);

                }

                {
                    DataSet paramSet = new DataSet();
                    paramSet.Tables.Add(paramTable);
                    
                    BizRun.QBizRun.ExecuteService(
                    this, QBiz.emExecuteType.PROCESS, "POP01A_SAVE", paramSet, "RQSTDT", "RSLTDT",
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

                //조회
                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("PROD_CODE", typeof(String)); //수주코드/명 LIKE 검색

                DataRow layoutRow = acLayoutControl1.CreateParameterRow();

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["PROD_CODE"] = acGridView1.GetFocusedDataRow()["PROD_CODE"];

                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);


                DataTable dtRslt = BizRun.QBizRun.ExecuteService(this, "POP01A_SER", paramSet, "RQSTDT", "RSLTDT").Tables["RSLTDT"];
                 
                foreach(DataRow row in dtRslt.Rows)
                {
                    acGridView1.UpdateMapingRow(row, false);
                }

                this._IsChanged = false;

                acAlert.Show(this, "저장 되었습니다.", acAlertForm.enmType.Success);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }


        void QuickDEL(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                //foreach (DataRow row in e.result.Tables["RQSTDT"].Rows)
                //{
                //    acGridView2.DeleteMappingRow(row);
                //}
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void acBarButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // 제작사양서 보기

            DataRow focusRow = acGridView1.GetFocusedDataRow();

            if (focusRow == null) { return; }

            //ProdSpec frm = new ProdSpec(focusRow);

            PopSpec frm = new PopSpec(focusRow);

            frm.DialogMode = BaseMenuDialog.emDialogMode.NEW;

            frm.ParentControl = this;

            frm.ShowDialog(this);
        }

        private void acBarButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // BOM 보기

            DataRow focusRow = acGridView1.GetFocusedDataRow();

            if (focusRow == null) { return; }

            PopBom frm = new PopBom(focusRow);

            frm.DialogMode = BaseMenuDialog.emDialogMode.NEW;

            frm.ParentControl = this;

            frm.ShowDialog(this);

        }

        private void acBarButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // 도면 보기

            try
            {
                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("PART_CODE", typeof(String)); //

                DataRow focusRow = acGridView1.GetFocusedDataRow();

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["PART_CODE"] = focusRow["PART_CODE"];

                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                //도면 조회
                DataSet dsRslt = BizRun.QBizRun.ExecuteService(this, "POP02A_SER2", paramSet, "RQSTDT", "RSLTDT");


                if (dsRslt.Tables["RSLTDT"].Rows.Count == 0)
                    acAlert.Show(this, "등록된 도면이 없습니다.", acAlertForm.enmType.Info);
                else if ((dsRslt.Tables["RSLTDT"].Rows.Count > 1))
                {
                    PopDraw frm = new PopDraw(dsRslt.Tables["RSLTDT"]);

                    frm.Text = string.Format("도면파일리스트 - {0}({1})", focusRow["PART_NAME"], focusRow["PART_CODE"]);

                    frm.DialogMode = BaseMenuDialog.emDialogMode.OPEN;

                    frm.ParentControl = this;

                    base.ChildFormAdd("DRAW", frm);

                    frm.ShowDialog(this);
                }
                else
                {
                    string path = acInfo.SysConfig.GetSysConfigByMemory("DRAW_FILE_DIR");
                    string id = acInfo.SysConfig.GetSysConfigByMemory("DRAW_FILE_DIR_ID");
                    string pass = acInfo.SysConfig.GetSysConfigByMemory("DRAW_FILE_DIR_PW");
                    string removePath = acInfo.SysConfig.GetSysConfigByMemory("DRAW_FILE_REMOVE_DIR");

                    int iSeq = dsRslt.Tables["RSLTDT"].Rows[0]["PART_FILE_PATH"].ToString().IndexOf(removePath) + removePath.Length;

                    string replacePath = dsRslt.Tables["RSLTDT"].Rows[0]["PART_FILE_PATH"].ToString().Substring(iSeq, dsRslt.Tables["RSLTDT"].Rows[0]["PART_FILE_PATH"].ToString().Length - iSeq);

                    string fullPath = path + replacePath;


                    string strFileFullPath = path;
                    string strFileFullName = fullPath;

                    IFModule iFModule = new IFModule(path, id, pass);

                    int ret = iFModule.NetWorkAccess();

                    acMessageBox.Show(ret.ToString(), ret.ToString(), acMessageBox.emMessageBoxType.CONFIRM);

                    //if (ret != 0)
                    //{
                    //    acMessageBox.Show("네트워크 연결 오류", "오류", acMessageBox.emMessageBoxType.CONFIRM);
                    //    return;
                    //}

                    bool isExists = true;

                    if (System.IO.Directory.Exists(strFileFullPath))
                    {
                        FileInfo fileInfo = new FileInfo(strFileFullName);

                        if (fileInfo.Exists)
                        {
                            System.Diagnostics.Process.Start(strFileFullName);
                        }
                        else
                        {
                            isExists = false;
                        }
                    }
                    else
                    {
                        isExists = false;
                    }

                    if (!isExists)
                    {
                        //acMessageBox.Show(this, "파일이 존재하지 않습니다.", "", false, acMessageBox.emMessageBoxType.CONFIRM);
                        acAlert.Show(this, "파일이 존재하지 않습니다.", acAlertForm.enmType.Warning);
                    }

                    //System.Diagnostics.Process.Start(dsRslt.Tables["RSLTDT"].Rows[0]["PART_FILE_PATH"].ToString());
                }


            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }
    }
}
