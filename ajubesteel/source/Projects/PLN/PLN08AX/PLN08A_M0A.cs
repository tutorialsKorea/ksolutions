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

namespace PLN
{
    public sealed partial class PLN08A_M0A : BaseMenu
    {
        bool _IsAssy = false;

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




        public PLN08A_M0A()
        {
            InitializeComponent();

            this.acGridView1.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.acGridView1_CustomDrawCell);

            this.acGridView1.CellValueChanging += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.acGridView1_CellValueChanging);

            acGridView2.FocusedRowChanged += acGridView2_FocusedRowChanged;

            this.acTreeList2.FocusedNodeChanged += acTreeList2_FocusedNodeChanged;

            this.acTreeList2.MouseDown += acTreeList2_MouseDown;

            this.acTreeList2.KeyDown += acTreeList2_KeyDown;

            acLayoutControl1.OnValueKeyDown += new acLayoutControl.ValueKeyDownEventHandler(acLayoutControl1_OnValueKeyDown);
            acLayoutControl1.OnValueChanged += new acLayoutControl.ValueChangedEventHandler(acLayoutControl1_OnValueChanged);

        }

        void acGridView2_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            acGridView view = sender as acGridView;
            if(view != null)
            {
                DataRow focusRow = view.GetFocusedDataRow();
                if(focusRow != null)
                {
                    if(focusRow["MAT_TYPE"].ToString().Equals("제품"))
                    {
                        _IsAssy = true;
                    }
                    else
                    {
                        _IsAssy = false;
                    }
                }
            }

            this.GetBom();
        }

        void acTreeList2_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            if (_isChange)
            {
                if (acMessageBox.Show("수정된 항목이 있습니다. 계속 진행 하시겠습니까?", "확인", acMessageBox.emMessageBoxType.YESNO) != DialogResult.Yes)
                {
                    this.acTreeList2.FocusedNodeChanged -= acTreeList2_FocusedNodeChanged;
                    acTreeList2.SetFocusedNode(e.OldNode);
                    this.acTreeList2.FocusedNodeChanged += acTreeList2_FocusedNodeChanged;

                    return;
                }
            }

            _isChange = false;

            this.GetProc();
        }

        void acTreeList2_KeyDown(object sender, KeyEventArgs e)
        {
            if (acTreeList2.Selection.Count != 0)
            {
                if (e.Control && e.KeyCode == Keys.C)
                {
                    acBarButtonItem5_ItemClick(null, null);
                }
            }
                if (e.Control && e.KeyCode == Keys.V)
                {
                    acBarButtonItem6_ItemClick(null, null);
                }
            

        }

        void acTreeList2_MouseDown(object sender, MouseEventArgs e)
        {
            acTreeList view = sender as acTreeList;

            DataRow focusRow = acGridView2.GetFocusedDataRow();

            if (focusRow != null)
            {
                if (focusRow["PART_CODE"].ToString() != "")
                {
                    if (e.Button == MouseButtons.Right)
                    {
                        TreeListHitInfo hitInfo = view.CalcHitInfo(e.Location);
                        if (hitInfo.HitInfoType == HitInfoType.Cell || hitInfo.HitInfoType == HitInfoType.RowIndicator)
                        {
                            //추가
                            acBarSubItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                            //자식노드
                            acBarButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                            //열기
                            acBarButtonItem3.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                            //삭제
                            acBarButtonItem4.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

                            if (hitInfo.Node != null)
                            {
                                acTreeList2.FocusedNode = hitInfo.Node;

                                int level = acTreeList2.FocusedNode.Level;

                                if (level == 0)
                                {
                                    //노드
                                    acBarButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                                    acBarButtonItem3.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                                    //복사
                                    acBarButtonItem5.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                                }
                                else if (level == 1)
                                {
                                    acBarButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                                    acBarButtonItem3.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                                    acBarButtonItem5.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

                                    if(!_IsAssy)
                                    {
                                        acBarButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Never; 
                                    }
                                }
                                else
                                {
                                    acBarButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                                    acBarButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;  //3번째 부터 자식도드 불가
                                    acBarButtonItem3.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                                    acBarButtonItem5.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                                }

                                popupMenu1.ShowPopup(acTreeList2.PointToScreen(e.Location));
                            }
                        }
                        else
                        {
                            acBarSubItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                            acBarButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                            acBarButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                            acBarButtonItem3.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                            acBarButtonItem4.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                            acBarButtonItem5.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

                            if (hitInfo.Node == null)
                            {
                                acTreeList2.FocusedNode = hitInfo.Node;
                                popupMenu1.ShowPopup(acTreeList2.PointToScreen(e.Location));
                            }


                        }
                    }
                }
            }

            
        }
        

        void GetProc()
        {
            acGridView1.ClearRow();
            
            TreeListNode focusNode = acTreeList2.FocusedNode;

            if (focusNode == null) return;

            if (focusNode["PART_CODE"].ToString() == "") return;

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("PART_CODE", typeof(String)); //

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["PART_CODE"] = focusNode["PART_CODE"];

            paramTable.Rows.Add(paramRow);

            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);


            BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD_DETAIL, "PLN01A_SER2", paramSet, "RQSTDT", "RSLTDT",
                        QuickSearchDetail,
                        QuickException);

        }

        void GetBom()
        {
           
            acTreeList2.ClearNodes();

            //TreeListNode focusNode = acTreeList1.FocusedNode;

            DataRow focusRow = acGridView2.GetFocusedDataRow();

            if (focusRow == null) return;

            if (focusRow["PART_CODE"].ToString() == "") return;

            //BOM조회
            DataTable paramTable2 = new DataTable("RQSTDT");
            paramTable2.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable2.Columns.Add("BOM_PART_CODE", typeof(String)); //

            DataRow paramRow2 = paramTable2.NewRow();
            paramRow2["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow2["BOM_PART_CODE"] = focusRow["PART_CODE"];

            paramTable2.Rows.Add(paramRow2);

            DataSet paramSet2 = new DataSet();
            paramSet2.Tables.Add(paramTable2);


            BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD_DETAIL, "PLN08A_SER3", paramSet2, "RQSTDT", "RSLTDT",
                        QuickSearch2,
                        QuickException);

        }

        private DataTable dtSel = null;

        public override void MenuInit()
        {
            try
            {

                dtSel = new DataTable("RQSTDT");
                dtSel.Columns.Add("PLT_CODE", typeof(String));
                dtSel.Columns.Add("BOM_PART_CODE", typeof(String));
                dtSel.Columns.Add("NEW_BOM_PART_CODE", typeof(String));
                dtSel.Columns.Add("BOM_ID", typeof(String));
                dtSel.Columns.Add("PARENT_ID", typeof(String));
                dtSel.Columns.Add("NEW_PARENT_ID", typeof(String));

                acGridView2.AddLookUpEdit("MAT_TYPE", "구분", "40229", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "S016");

                acGridView2.AddLookUpEdit("PART_PRODTYPE", "품목제작구분", "40238", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, "M007");

                acGridView2.AddTextEdit("PART_CODE", "품목코드", "40239", true, DevExpress.Utils.HorzAlignment.Center, false, true, true, acGridView.emTextEditMask.NONE);

                acGridView2.AddTextEdit("PART_NAME", "품목명", "40234", true, DevExpress.Utils.HorzAlignment.Center, false, true, true, acGridView.emTextEditMask.NONE);

                acGridView2.AddTextEdit("DRAW_NO", "도면번호", "40145", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

                acGridView2.AddLookUpEdit("MAT_LTYPE", "대분류", "40132", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M014");

                acGridView2.AddLookUpEdit("MAT_MTYPE", "중분류", "40630", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M015");

                acGridView2.AddLookUpEdit("MAT_STYPE", "소분류", "40338", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M016");

                acGridView2.AddTextEdit("MAT_SPEC1", "제품규격", "42545", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

                acGridView2.AddTextEdit("PART_CNT", "개체 수", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

                acGridView2.OptionsView.ShowGroupPanel = true;
                acGridView2.Columns["MAT_LTYPE"].GroupIndex = 0;
                acGridView2.Columns["MAT_LTYPE"].SortMode = DevExpress.XtraGrid.ColumnSortMode.Custom;


                acTreeList2.KeyFieldName = "BOM_ID";

                acTreeList2.ParentFieldName = "PARENT_ID";

                acTreeList2.AddTextEdit("BOM_ID", "BOM_ID", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, ControlManager.acTreeList.emTextEditMask.NONE);

                acTreeList2.AddTextEdit("BOM_PART_CODE", "최상위부품", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, ControlManager.acTreeList.emTextEditMask.NONE);

                acTreeList2.AddTextEdit("PARENT_ID", "모품목ID", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, ControlManager.acTreeList.emTextEditMask.NONE);

                acTreeList2.AddTextEdit("PARENT_PART_CODE", "모품목 코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, ControlManager.acTreeList.emTextEditMask.NONE);

                acTreeList2.AddTextEdit("PARENT_PART_NAME", "모품목명", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, ControlManager.acTreeList.emTextEditMask.NONE);

                acTreeList2.AddTextEdit("PART_CODE", "품목코드", "C8PZLBQT", false, DevExpress.Utils.HorzAlignment.Center, false, true, ControlManager.acTreeList.emTextEditMask.NONE);

                acTreeList2.AddTextEdit("PART_NAME", "품목명", "C8PZLBQT", false, DevExpress.Utils.HorzAlignment.Center, false, true, ControlManager.acTreeList.emTextEditMask.NONE);

                acTreeList2.AddTextEdit("MAT_SPEC1", "규격", "42545", false, DevExpress.Utils.HorzAlignment.Center, false, true, ControlManager.acTreeList.emTextEditMask.NONE);

                acTreeList2.AddTextEdit("DRAW_NO", "도면번호", "40743", true, DevExpress.Utils.HorzAlignment.Center, false, true, ControlManager.acTreeList.emTextEditMask.NONE);

                acTreeList2.AddLookUpEdit("MAT_UNIT", "단위", "40123", true, DevExpress.Utils.HorzAlignment.Center, false, true, "M003", true);

                acTreeList2.AddLookUpEdit("MAT_LTYPE", "대분류", "40132", true, DevExpress.Utils.HorzAlignment.Center, false, true, "M014", true);

                acTreeList2.AddLookUpEdit("MAT_TYPE", "자재형태", "N05MMEKM", true, DevExpress.Utils.HorzAlignment.Center, false, true, "S016", true);

                acTreeList2.AddTextEdit("BOM_QTY", "소요수량", "", false, DevExpress.Utils.HorzAlignment.Far, true, true, ControlManager.acTreeList.emTextEditMask.QTY);

                acTreeList2.AddLookUpEdit("STOCK_CODE", "창고코드", "", false, DevExpress.Utils.HorzAlignment.Center, true, true, "M005", true);

                acTreeList2.AddLookUpEdit("STOCK_TYPE", "완성재고", "", false, DevExpress.Utils.HorzAlignment.Center, true, true, "M013", true);

                acTreeList2.AddTextEdit("BOM_SEQ", "표시순서", "40723", true, DevExpress.Utils.HorzAlignment.Far, true, true, acTreeList.emTextEditMask.QTY);

                acTreeList2.OptionsSelection.MultiSelect = true;

                #region 표준공정 리스트 컬럼 설정
                acGridView1.GridType = acGridView.emGridType.FIXED_SINGLE;
                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;

                paramTable.Rows.Add(paramRow);

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                DataSet rsltSet = BizRun.QBizRun.ExecuteService(QBiz.emExecuteType.LOAD, "PLN_PROC", paramSet, "RQSTDT", "RSLTDT");
                
                if(rsltSet.Tables["RSLTDT"].Rows.Count > 0)
                {
                    foreach(DataRow row in rsltSet.Tables["RSLTDT"].Rows)
                    {
                        string strColumnNmae = "";
                        foreach (char c in row["PROC_NAME"].ToString())
                        {
                            strColumnNmae += (c + "\n");
                        }
                        //strColumnNmae = row["PROC_NAME"].ToString() + "\n" + "sss";
                        acGridView1.AddCheckEdit(row["PROC_CODE"].ToString(), strColumnNmae, "", false, true, true, acGridView.emCheckEditDataType._INT);
                    }
                }

                acGridView1.ColumnPanelRowHeight = 90;
                acGridView1.RowHeight = 50;
                //acGridView1.BestFitColumns();
                #endregion


                acCheckedComboBoxEdit1.AddItem("등록일", false, "40515", "REG_DATE", true, false);

                (acLayoutControl1.GetEditor("MAT_LTYPE").Editor as acLookupEdit).SetCode("M001");
                (acLayoutControl1.GetEditor("MAT_MTYPE").Editor as acLookupEdit).SetCode("M002");
                (acLayoutControl1.GetEditor("MAT_STYPE").Editor as acLookupEdit).SetCode("M008");
                
                base.MenuInit();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }



        public override void ChildContainerInit(Control sender)
        {
            //기본값 설정
            if (sender == acLayoutControl1)
            {
                acLayoutControl layout = sender as acLayoutControl;


            }


            base.ChildContainerInit(sender);
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
            paramTable.Columns.Add("S_REG_DATE", typeof(String)); //
            paramTable.Columns.Add("E_REG_DATE", typeof(String)); //
            paramTable.Columns.Add("PART_LIKE", typeof(String)); //
            paramTable.Columns.Add("MAT_LTYPE", typeof(String)); //
            paramTable.Columns.Add("MAT_MTYPE", typeof(String)); //
            paramTable.Columns.Add("MAT_STYPE", typeof(String)); //

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;            

            foreach (string key in acCheckedComboBoxEdit1.GetKeyChecked())
            {
                switch (key)
                {
                    case "REG_DATE":

                        //수주일
                        paramRow["S_REG_DATE"] = layoutRow["S_DATE"];
                        paramRow["E_REG_DATE"] = layoutRow["E_DATE"];
                        break;
                }
            }

            paramRow["PART_LIKE"] = layoutRow["PART_LIKE"];
            paramRow["MAT_LTYPE"] = layoutRow["MAT_LTYPE"];
            paramRow["MAT_MTYPE"] = layoutRow["MAT_MTYPE"];
            paramRow["MAT_STYPE"] = layoutRow["MAT_STYPE"];

            paramTable.Rows.Add(paramRow);

            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);


            BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD, "PLN08A_SER", paramSet, "RQSTDT", "RSLTDT",
                        QuickSearch,
                        QuickException);


        }


        void QuickSearch(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                DataTable dtResult = e.result.Tables["RSLTDT"].Copy();

                //DataRow dr = dtResult.NewRow();
                //dr["PLT_CODE"] = acInfo.PLT_CODE;
                //dr["PARENT"] = DBNull.Value;
                //dr["KEYVALUE"] = acInfo.Resource.GetString("전체", "40583");
                //dr["PART_NAME"] = acInfo.Resource.GetString("전체", "40583");

                //dtResult.Rows.InsertAt(dr, 0);

                //acTreeList1.DataSource = dtResult;

                acGridView2.GridControl.DataSource = dtResult;
                acGridView2.ExpandAllGroups();
                //acGridView2.BestFitColumns();


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

                acTreeList2.DataSource = e.result.Tables["RSLTDT"];

                acTreeList2.ExpandAll();

                acTreeList2.BestFitColumns();

                base.SetLog(e.executeType, e.result.Tables["RSLTDT"].Rows.Count, e.executeTime);
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

                DataRow row = acGridView1.NewRow();                

                foreach(DataRow procRow in e.result.Tables["RSLTDT_PROC"].Rows)
                {
                    row[procRow["PROC_CODE"].ToString()] =  "1";
                }

                acGridView1.AddRow(row);

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


        public override bool MenuDestory(object sender)
        {
            if (_isChange)
            {
                if (acMessageBox.Show("수정된 항목이 있습니다. 계속 진행 하시겠습니까?", "확인", acMessageBox.emMessageBoxType.YESNO) != DialogResult.Yes)
                {
                    return false;
                }
            }
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



        private void barItemHelp_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                this.ShowHelp();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        private bool _isChange = false;

    
        void QuickSave(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                _isChange = false;
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        private void acGridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.CellValue == null) return;
            if (e.CellValue.ToString() == "1")
            {
                e.Appearance.BackColor = Color.YellowGreen;
                
            }
        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (acTreeList2.Nodes.Count == 0) return;

            TreeListNode focusNode = acTreeList2.FocusedNode;

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("PART_CODE", typeof(String)); //
            paramTable.Columns.Add("PROC_CODE", typeof(String)); //
            paramTable.Columns.Add("PROC_SEQ", typeof(Int32)); //
            paramTable.Columns.Add("REG_EMP", typeof(String)); //

            int i = 0;

            DataRow row = acGridView1.GetDataRow(0);

            foreach (acGridColumn col in acGridView1.Columns)
            {
                if (row[col.FieldName].ToString() == "1")
                {
                    DataRow paramRow = paramTable.NewRow();
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["PART_CODE"] = focusNode["PART_CODE"];
                    paramRow["PROC_CODE"] = col.FieldName;
                    paramRow["PROC_SEQ"] = i;
                    paramRow["REG_EMP"] = acInfo.UserID;

                    paramTable.Rows.Add(paramRow);

                    i++;
                }
            }

            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);


            BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.SAVE, "PLN01A_SAVE", paramSet, "RQSTDT", "RSLTDT",
                        QuickSave,
                        QuickException);
        }

        private void acGridView1_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            _isChange = true;
            acGridView1.SetRowCellValue(e.RowHandle, e.Column, e.Value.ToString());        
        }

        private void acBarButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //노드추가
            if (!base.ChildFormContains("BOM_NEW"))
            {
                PLN08A_D0A frm;

                bool isTurning = false;

                if (acTreeList2.Nodes.Count > 0)
                {
                    TreeListNode focusNode = acTreeList2.FocusedNode;

                    if (focusNode.Level > 1 || !_IsAssy)
                        isTurning = true;

                    frm = new PLN08A_D0A(null, focusNode, acTreeList2, false, isTurning);

                }
                else
                {
                    //TreeListNode focusNode = acTreeList1.FocusedNode;

                    if(!_IsAssy)
                    {
                        isTurning = true;
                    }

                    DataRow focusRow = acGridView2.GetFocusedDataRow();

                    frm = new PLN08A_D0A(focusRow, null, acTreeList2, false, isTurning);
                }

                frm.DialogMode = BaseMenuDialog.emDialogMode.OPEN;

                frm.ParentControl = this;

                base.ChildFormAdd("BOM_NEW", frm);

                frm.Show(this);
            }
            else
            {
                base.ChildFormFocus("BOM_NEW");
            }
        }

        private void acBarButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //자식노드추가
            if (!base.ChildFormContains("BOM_NEW"))
            {
                TreeListNode focusNode = acTreeList2.FocusedNode;
                bool isTurning = false;
                if(focusNode.Level == 1 || !_IsAssy)
                {
                    isTurning = true;
                }
                PLN08A_D0A frm = new PLN08A_D0A(null, focusNode, acTreeList2, true, isTurning);

                frm.DialogMode = BaseMenuDialog.emDialogMode.OPEN;

                frm.ParentControl = this;

                base.ChildFormAdd("BOM_NEW", frm);

                frm.Show(this);
            }
            else
            {
                base.ChildFormFocus("BOM_NEW");
            }
        }

        private void acBarButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //열기
            if (!base.ChildFormContains("BOM_UPD"))
            {
                TreeListNode focusNode = acTreeList2.FocusedNode;

                PLN08A_D1A frm = new PLN08A_D1A(focusNode, acTreeList2);

                frm.DialogMode = BaseMenuDialog.emDialogMode.OPEN;

                frm.ParentControl = this;

                base.ChildFormAdd("BOM_UPD", frm);

                frm.Show(this);
            }
            else
            {
                base.ChildFormFocus("BOM_UPD");
            }

        }

        private void acBarButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //삭제

            //acTreeList2.EndEditor();

            if (acMessageBox.Show(this, "정말 삭제하시겠습니까?", "TB43FSY3", true, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
            {
                return;
            }

            TreeListNode focusNode = acTreeList2.FocusedNode;

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("BOM_ID", typeof(String)); //
            paramTable.Columns.Add("BOM_PART_CODE", typeof(String)); //

            TreeListMultiSelection MultiSel = acTreeList2.Selection;
            foreach (TreeListNode tlNode in MultiSel)
            {
                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["BOM_ID"] = tlNode["BOM_ID"];
                paramRow["BOM_PART_CODE"] = tlNode["BOM_PART_CODE"];

                paramTable.Rows.Add(paramRow);
            }

            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);
            
            BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.DEL, "PLN08A_DEL", paramSet, "RQSTDT", "RSLTDT",
                        QuickDel,
                        QuickException);
        }

        void QuickDel(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                acTreeList2.DataSource = e.result.Tables["RSLTDT"];

                acTreeList2.ExpandAll();

                acTreeList2.BestFitColumns();

                base.SetLog(e.executeType, e.result.Tables["RSLTDT"].Rows.Count, e.executeTime);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }


        private void acBarButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //복사
            TreeListMultiSelection MultiSel = acTreeList2.Selection;

            dtSel.Rows.Clear();

            bool isSel = false;

            int j = 1;

            for (int i = 0; i < MultiSel.Count; i++)
            {
                if (i + 1 < MultiSel.Count)
                {
                    if (MultiSel[i].Level != MultiSel[j].Level)
                    {
                        isSel = true;
                    }
                    j++;
                }
            }
            if (isSel)
            {
                acMessageBox.Show(this, "같은 LEVEL에서만 복사가 가능합니다.", "", false, acMessageBox.emMessageBoxType.CONFIRM);
                return;
            }

            foreach (TreeListNode tlNode in MultiSel)
            {
                DataRow drSel = dtSel.NewRow();
                drSel["PLT_CODE"] = acInfo.PLT_CODE;
                drSel["BOM_ID"] = tlNode["BOM_ID"];
                if (tlNode["PARENT_ID"].ToString() != "")
                {
                    drSel["PARENT_ID"] = tlNode["BOM_ID"];
                }
                else
                {
                    drSel["PARENT_ID"] = null;
                }
                
                drSel["BOM_PART_CODE"] = tlNode["BOM_PART_CODE"];

                dtSel.Rows.Add(drSel);
            }

        }

        private void acBarButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //붙여넣기

            if (dtSel.Rows.Count == 0)
            {
                return;
            }

            //TreeListNode focusNode = acTreeList1.FocusedNode;

            DataRow focusRow = acGridView2.GetFocusedDataRow();

            DataSet dsBomPaste = new DataSet();

            if (acTreeList2.Selection.Count != 0)
            {
                TreeListNode focusNode2 = acTreeList2.FocusedNode;

                if (focusNode2["PARENT_ID"].ToString() != "")
                {
                    PLN08A_D2A frm = new PLN08A_D2A();

                    frm.ParentControl = this;

                    if (frm.ShowDialog() == DialogResult.Yes)
                    {
                        //노드
                        for (int i = 0; i < dtSel.Rows.Count; i++)
                        {
                            dtSel.Rows[i]["NEW_BOM_PART_CODE"] = focusRow["PART_CODE"];
                            dtSel.Rows[i]["NEW_PARENT_ID"] = focusNode2["PARENT_ID"];
                        }

                        dsBomPaste.Tables.Add(dtSel.Copy());

                    }
                    else
                    {
                        //자식노드
                        if (frm.OutputData != null)
                        {
                            if ((bool)frm.OutputData == false)
                            {
                                for (int i = 0; i < dtSel.Rows.Count; i++)
                                {
                                    dtSel.Rows[i]["NEW_BOM_PART_CODE"] = focusRow["PART_CODE"];
                                    dtSel.Rows[i]["NEW_PARENT_ID"] = focusNode2["BOM_ID"];
                                }

                                dsBomPaste.Tables.Add(dtSel.Copy());
                            }
                        }

                    }
                }
                else
                {
                    for (int i = 0; i < dtSel.Rows.Count; i++)
                    {
                        dtSel.Rows[i]["NEW_BOM_PART_CODE"] = focusRow["PART_CODE"];
                        dtSel.Rows[i]["NEW_PARENT_ID"] = focusNode2["BOM_ID"];
                    }

                    dsBomPaste.Tables.Add(dtSel.Copy());
                }

                
                

            }
            else
            {
                for (int i = 0; i < dtSel.Rows.Count; i++)
                {
                    dtSel.Rows[i]["NEW_BOM_PART_CODE"] = focusRow["PART_CODE"];
                }

                dsBomPaste.Tables.Add(dtSel.Copy());
            }

            if (dsBomPaste.Tables.Count != 0)
            {
                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.DEL, "PLN08A_INS2", dsBomPaste, "RQSTDT", "RSLTDT",
                        QuickSearch2,
                        QuickException);
            }

        }

        private void btnSaveBom_Click(object sender, EventArgs e)
        {
            try
            {
                acTreeList2.EndEditor();

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("BOM_ID", typeof(String)); //

                paramTable.Columns.Add("BOM_PART_CODE", typeof(String)); //
                paramTable.Columns.Add("BOM_SEQ", typeof(int)); //
                paramTable.Columns.Add("BOM_QTY", typeof(int)); //
                paramTable.Columns.Add("STOCK_CODE", typeof(String)); //
                paramTable.Columns.Add("STOCK_TYPE", typeof(String)); //
                paramTable.Columns.Add("REG_EMP", typeof(String)); //

                DataTable dtTree = (DataTable)acTreeList2.DataSource;
                DataTable dtSource =  acTreeList2.GetAddModifyRows();
                
                foreach (DataRow dr in dtTree.Rows)
                {
                    if(!dr["PARENT_PART_CODE"].isNullOrEmpty()
                        && dr["BOM_QTY"].toInt() <= 0)
                    {
                        acMessageBox.Show(this, "소요수량을 입력해주세요.", "", false, acMessageBox.emMessageBoxType.CONFIRM);
                        return;
                    }

                    DataRow paramRow = paramTable.NewRow();
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["BOM_ID"] = dr["BOM_ID"];

                    paramRow["BOM_PART_CODE"] = dr["BOM_PART_CODE"];
                    paramRow["BOM_SEQ"] = dr["BOM_SEQ"];
                    paramRow["BOM_QTY"] = dr["BOM_QTY"];
                    paramRow["STOCK_CODE"] = dr["STOCK_CODE"];
                    paramRow["STOCK_TYPE"] = dr["STOCK_TYPE"];
                    paramRow["REG_EMP"] = acInfo.UserID;

                    paramTable.Rows.Add(paramRow);

                }
                
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                DataTable dtDelPart = new DataTable("RQSTDT_DEL");

                paramSet.Tables.Add(dtDelPart);

                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.SAVE, "PLN08A_INS", paramSet, "RQSTDT", "RSLTDT",
                            QuickSave,
                            QuickException);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }



    }
}
