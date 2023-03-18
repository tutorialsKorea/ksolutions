using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;
using System.Collections;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.Utils.Drawing;
using ControlManager;
using BizManager;

namespace STD
{
    public sealed partial class STD50A_M0A : ControlManager.BaseMenu
    {
        public STD50A_M0A()
        {
            InitializeComponent();
            acLayoutControl1.OnValueKeyDown += new acLayoutControl.ValueKeyDownEventHandler(acLayoutControl1_OnValueKeyDown);
            acLayoutControl1.OnValueChanged += AcLayoutControl1_OnValueChanged;
        }

        

        Color _clrAssy;
        Color _clrMat;
        Color _clrRoot;
        DataTable copyBom = null;
        DataTable resultBom = null;
        DataTable copyBan = null;
        protected override void OnLoad(EventArgs e)
        {
            this.Search();
            base.OnLoad(e);
        }

        public override string InstantLog
        {
            set
            {
                statusBarLog.Caption = value;
            }
        }

        public override void MenuInit()
        {
            try
            {
                //마스터
                gvLeft.GridType = acGridView.emGridType.SEARCH;
                gvLeft.AddTextEdit("PART_CODE", "제품 코드", "", false, DevExpress.Utils.HorzAlignment.Default, false, true, true, acGridView.emTextEditMask.NONE);
                gvLeft.AddTextEdit("PART_NAME", "품목명", "", false, DevExpress.Utils.HorzAlignment.Default, false, true, false, acGridView.emTextEditMask.NONE);
                gvLeft.AddCheckEdit("IS_BOM_REG", "BOM 등록", "", false, false, true, acGridView.emCheckEditDataType._INT);
                gvLeft.AddTextEdit("REV_NO", "Rev.", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                gvLeft.AddLookUpEdit("BOM_STATE", "BOM 상태", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "0A04");
                gvLeft.AddDateEdit("REG_DATE", "최초 등록일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.LONG_DATE);
                gvLeft.AddLookUpEmp("REG_EMP", "최초 등록인", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false);
                gvLeft.AddDateEdit("MDFY_DATE", "최근 수정일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.LONG_DATE);
                gvLeft.AddLookUpEmp("MDFY_EMP", "최근 수정자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false);
                gvLeft.AddLookUpEmp("LOCK_EMP", "잠금 사용자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false);
                gvLeft.AddLookUpEdit("MAT_LTYPE", "자재구분", "40132", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, "M001");
                gvLeft.AddLookUpEdit("MAT_MTYPE", "자재유형", "40630", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, "M002");
                gvLeft.AddTextEdit("MAT_SPEC", "규격", "42544", false, DevExpress.Utils.HorzAlignment.Near, false, false, false, acGridView.emTextEditMask.NONE);
                gvLeft.AddTextEdit("DRAW_NO", "도면번호", "42545", false, DevExpress.Utils.HorzAlignment.Near, false, false, false, acGridView.emTextEditMask.NONE);
                gvLeft.AddLookUpEdit("PART_PRODTYPE", "분류", "", false, DevExpress.Utils.HorzAlignment.Near, false, false, false, "M007");
                gvLeft.AddLookUpEdit("MAT_TYPE", "구매 분류", "", false, DevExpress.Utils.HorzAlignment.Near, false, false, false, "S016");
                gvLeft.KeyColumn = new string[] { "PART_CODE" };

                //내역
                gvTop.GridType = acGridView.emGridType.SEARCH;
                gvTop.AddTextEdit("BM_KEY", "BOM 마스터 코드", "", false, DevExpress.Utils.HorzAlignment.Default, false, false, false, acGridView.emTextEditMask.NONE);
                gvTop.AddTextEdit("BM_CODE", "BM 코드", "", false, DevExpress.Utils.HorzAlignment.Default, false, false, false, acGridView.emTextEditMask.NONE);
                gvTop.AddTextEdit("PART_CODE", "제품 코드", "", false, DevExpress.Utils.HorzAlignment.Default, false, true, false, acGridView.emTextEditMask.NONE);
                gvTop.AddLookUpEdit("BOM_STATE", "BOM 상태", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "0A04");
                gvTop.AddTextEdit("REV_NO", "Rev.", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                gvTop.AddDateEdit("REV_DATE", "개정일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
                gvTop.AddTextEdit("SCOMMENT", "설명", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
                gvTop.AddDateEdit("REG_DATE", "최초 등록일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.LONG_DATE);
                gvTop.AddLookUpEmp("REG_EMP", "최초 등록인", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false);
                gvTop.AddDateEdit("MDFY_DATE", "최근 수정일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.LONG_DATE);
                gvTop.AddLookUpEmp("MDFY_EMP", "최근 수정자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false);
                
                gvTop.KeyColumn = new string[] { "BM_KEY" };

                //정보
                tlBottom.KeyFieldName = "BOM_ID";
                tlBottom.ParentFieldName = "PARENT_ID";
                tlBottom.AddTextEdit("BM_KEY", "BOM 마스터 코드", "", false, DevExpress.Utils.HorzAlignment.Default, false, false, ControlManager.acTreeList.emTextEditMask.NONE);
                tlBottom.AddTextEdit("BOM_ID", "BOM_ID", "", false, DevExpress.Utils.HorzAlignment.Default, false, false, ControlManager.acTreeList.emTextEditMask.NONE);
                tlBottom.AddTextEdit("BM_CODE", "최상위부품", "", false, DevExpress.Utils.HorzAlignment.Default, false, false, ControlManager.acTreeList.emTextEditMask.NONE);
                tlBottom.AddTextEdit("PARENT_ID", "모품목ID", "", false, DevExpress.Utils.HorzAlignment.Default, false, false, ControlManager.acTreeList.emTextEditMask.NONE);
                tlBottom.AddTextEdit("PARENT_PART_CODE", "모품목 코드", "", false, DevExpress.Utils.HorzAlignment.Default, false, false, ControlManager.acTreeList.emTextEditMask.NONE);
                tlBottom.AddTextEdit("PART_CODE", "품목코드", "", false, DevExpress.Utils.HorzAlignment.Default, false, true, ControlManager.acTreeList.emTextEditMask.NONE);
                tlBottom.AddTextEdit("PART_NAME", "품목명", "", false, DevExpress.Utils.HorzAlignment.Default, false, true, ControlManager.acTreeList.emTextEditMask.NONE);
                tlBottom.AddTextEdit("REV_NO", "Rev.", "", false, DevExpress.Utils.HorzAlignment.Default, false, false, ControlManager.acTreeList.emTextEditMask.NUMBER);
                tlBottom.AddLookUpEdit("PART_PRODTYPE", "분류", "", false, DevExpress.Utils.HorzAlignment.Default, true, true, "M007", false);
                tlBottom.AddLookUpEdit("MAT_LTYPE", "자재구분", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, "M001", true);
                tlBottom.AddLookUpEdit("MAT_MTYPE", "자재유형", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, "M002", true);
                tlBottom.AddTextEdit("DRAW_NO", "도면번호", "", false, DevExpress.Utils.HorzAlignment.Default, false, true, ControlManager.acTreeList.emTextEditMask.NONE);
                tlBottom.AddLookUpEdit("MAT_UNIT", "단위", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, "M003", true);
                //tlBottom.AddLookUpEdit("PROC_GRP", "공정그룹", "", false, DevExpress.Utils.HorzAlignment.Default, false, false, "P100", false);
                //tlBottom.AddLookUpProc("PROC_CODE", "공정", "", false, DevExpress.Utils.HorzAlignment.Default, false, true, false);
                tlBottom.AddTextEdit("BOM_QTY", "소요수량", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, ControlManager.acTreeList.emTextEditMask.NUMBER);
                //tlBottom.AddLookUpEdit("PART_UNIT", "단위", "", false, DevExpress.Utils.HorzAlignment.Default, false, true, "M003", true);
                //tlBottom.AddLookUpEdit("CUR_UNIT", "화폐", "", false, DevExpress.Utils.HorzAlignment.Default, false, true, "O001", true);
                //tlBottom.AddTextEdit("UNIT_COST", "단가1", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, ControlManager.acTreeList.emTextEditMask.F4);
                //tlBottom.AddTextEdit("UNIT_AMT", "금액", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, ControlManager.acTreeList.emTextEditMask.F4);
                //tlBottom.AddLookUpVendor("MVND_CODE", "공급업체1", "", false, DevExpress.Utils.HorzAlignment.Default, false, true, false);
                tlBottom.AddTextEdit("BOM_SEQ", "순서", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, ControlManager.acTreeList.emTextEditMask.NUMBER);

                tlBottom.OptionsView.ShowIndicator = true;
                tlBottom.IndicatorWidth = 30;

                tlBottom.OptionsFind.AllowFindPanel = true;

                tlBottom.OptionsBehavior.AutoSelectAllInEditor = true;
                tlBottom.OptionsBehavior.EnableFiltering = true;
                tlBottom.OptionsFilter.FilterMode = FilterMode.Extended;

                copyBan = new DataTable("COPY_RQSTDT");
                copyBan.Columns.Add("PLT_CODE", typeof(String));
                copyBan.Columns.Add("BM_KEY", typeof(String));
                copyBan.Columns.Add("BOM_ID", typeof(String));
                copyBan.Columns.Add("BM_CODE", typeof(String));
                copyBan.Columns.Add("PARENT_ID", typeof(String));
                copyBan.Columns.Add("PART_CODE", typeof(String));
                copyBan.Columns.Add("PROC_GRP", typeof(String));
                copyBan.Columns.Add("PROC_CODE", typeof(String));
                copyBan.Columns.Add("BOM_QTY", typeof(Decimal));


                tlBottom.CustomDrawNodeCell += acTreeList1_CustomDrawNodeCell;
                _clrAssy = acInfo.SysConfig.GetSysConfigByServer("ASSY_DISP_COLOR").toColor();
                _clrMat = acInfo.SysConfig.GetSysConfigByServer("MAT_DISP_COLOR").toColor();
                _clrRoot = acInfo.SysConfig.GetSysConfigByServer("ROOT_DISP_COLOR").toColor();

                gvLeft.FocusedRowChanged += gvLeft_FocusedRowChanged;

                gvTop.ShowGridMenuEx += gvTop_ShowGridMenuEx;
                tlBottom.MouseDown += TlBottom_MouseDown;
                gvTop.FocusedRowChanged += gvTop_FocusedRowChanged;
                gvTop.MouseDown += new MouseEventHandler(gvTop_MouseDown);

                (acLayoutControl1.GetEditor("MAT_LTYPE") as acLookupEdit).SetCode("M001");

                acBarButtonItem10.Enabled = false;

                base.MenuInit();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void acLayoutControl1_OnValueKeyDown(object sender, IBaseEditControl info, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                this.Search();
            }
        }
        private void AcLayoutControl1_OnValueChanged(object sender, IBaseEditControl info, object newValue)
        {
            acLayoutControl layout = sender as acLayoutControl;

            switch (info.ColumnName)
            {
                case "MAT_LTYPE":

                    acLookupEdit1.SetCode("M002", newValue);
                    break;
            }
        }
        private void TlBottom_MouseDown(object sender, MouseEventArgs e)
        {

            TreeListHitInfo hitInfo = tlBottom.CalcHitInfo(e.Location);

            if (e.Button == MouseButtons.Right)
            {

                if (hitInfo.HitInfoType == HitInfoType.Cell || hitInfo.HitInfoType == HitInfoType.RowIndicator)
                {
                    if (copyBan != null)
                    {
                        if (copyBan.Rows.Count > 0)
                            acBarButtonItem10.Enabled = true;
                        else
                            acBarButtonItem10.Enabled = false;
                    }
                    else
                    {
                        acBarButtonItem10.Enabled = false;
                    }
                    
                }

            }
        }

        void gvTop_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                GridHitInfo hitInfo = gvTop.CalcHitInfo(e.Location);

                if (hitInfo.HitTest == GridHitTest.RowCell || hitInfo.HitTest == GridHitTest.Row)
                {
                    this.acBarButtonItem5_ItemClick(null, null);
                }

            }
        }
        //void acTreeList1_CustomDrawNodeIndicator(object sender, CustomDrawNodeIndicatorEventArgs e)
        //{
        //    TreeList tree = sender as TreeList;

        //    IndicatorObjectInfoArgs args = e.ObjectArgs as IndicatorObjectInfoArgs;
        //    args.DisplayText = (tree.GetVisibleIndexByNode(e.Node) + 1).ToString();

        //}

        void acTreeList1_CustomDrawNodeCell(object sender, CustomDrawNodeCellEventArgs e)
        {
            TreeListNode node = e.Node;
            Brush backBrush = new SolidBrush(_clrAssy);
            Brush matBrush = new SolidBrush(_clrMat);
            Brush rootBrush = new SolidBrush(_clrRoot);

            //if (node["MAT_TYPE"].ToString() == "1")
            //{
            //    e.Graphics.FillRectangle(backBrush, e.Bounds);
            //    e.Appearance.ForeColor = Color.Black;
            //}
            //else if (node["MAT_TYPE"].ToString() == "2")
            //{
            //    e.Graphics.FillRectangle(matBrush, e.Bounds);
            //    e.Appearance.ForeColor = Color.Black;
            //}
            
            if (node.RootNode == node)
            {
                e.Graphics.FillRectangle(rootBrush, e.Bounds);
                e.Appearance.ForeColor = Color.Black;
                e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Bold);
            }

            if (node.Selected)
            {
                e.Graphics.FillRectangle(Brushes.LightYellow, e.Bounds);
                e.Appearance.ForeColor = Color.Black;
            }
                
        }

        void acTreeList1_MouseDown(object sender, MouseEventArgs e)
        {
            acTreeList view = sender as acTreeList;

            
            if (e.Button == MouseButtons.Right)
            {
                TreeListHitInfo hitInfo = view.CalcHitInfo(e.Location);

                if (hitInfo.HitInfoType == HitInfoType.Cell || hitInfo.HitInfoType == HitInfoType.RowIndicator)
                {
                    if (hitInfo.Node.Level == 1)
                        btnbanEdit.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    else
                        btnbanEdit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                   
                    if (hitInfo.Node != null)
                    {
                        popupMenu2.ShowPopup(tlBottom.PointToScreen(e.Location));
                    }
                }
                else
                {
                    btnbanEdit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    
                    if (hitInfo.Node == null)
                    {
                        //acTreeList2.FocusedNode = hitInfo.Node;
                        popupMenu2.ShowPopup(tlBottom.PointToScreen(e.Location));
                    }
                }
            }
        }

        void gvLeft_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            Search_Rev();
        }
        void gvTop_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            SearchBOM();
        }

        void gvTop_ShowGridMenuEx(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            acGridView view = sender as acGridView;

            if (e.MenuType == GridMenuType.User)
            {
                acBarButtonItem5.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                acBarButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                acBarButtonItem7.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                acBarButtonItem8.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            }
            else if (e.MenuType == GridMenuType.Row)
            {
                if (e.HitInfo.RowHandle >= 0)
                {
                    acBarButtonItem5.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    acBarButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    acBarButtonItem7.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    acBarButtonItem8.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    if (copyBom != null)
                    {
                        if (copyBom.Rows.Count > 0)
                            acBarButtonItem8.Enabled = true;
                        else
                            acBarButtonItem8.Enabled = false;
                    }
                    else
                    {
                        acBarButtonItem8.Enabled = false;
                    }
                }
                else
                {
                    acBarButtonItem5.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    acBarButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    acBarButtonItem7.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    acBarButtonItem8.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    if (copyBom != null)
                    {
                        if (copyBom.Rows.Count > 0)
                            acBarButtonItem8.Enabled = true;
                        else
                            acBarButtonItem8.Enabled = false;
                    }
                    else
                    {
                        acBarButtonItem8.Enabled = false;
                    }
                }
            }

            if (gvTop.RowCount == 0)
            {
                barButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

                acBarButtonItem8.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                if (copyBom != null)
                {
                    if(copyBom.Rows.Count > 0)
                        acBarButtonItem8.Enabled = true;
                    else
                        acBarButtonItem8.Enabled = false;
                }
                else
                {
                    acBarButtonItem8.Enabled = false;
                }
            }
            else
            {
                barButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                acBarButtonItem8.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                if (copyBom != null)
                {
                    if (copyBom.Rows.Count > 0)
                        acBarButtonItem8.Enabled = true;
                    else
                        acBarButtonItem8.Enabled = false;
                }
                else
                {
                    acBarButtonItem8.Enabled = false;
                }
            }

            if (e.HitInfo.HitTest == GridHitTest.Row || e.HitInfo.HitTest == GridHitTest.EmptyRow || e.HitInfo.HitTest == GridHitTest.RowCell)
            {

                GridHitInfo hitInfo = view.CalcHitInfo(e.Point);

                popupMenu1.ShowPopup(view.GridControl.PointToScreen(e.Point));

            }
        }



        public override void ChildContainerInit(Control sender)
        {
            

            base.ChildContainerInit(sender);
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
            try
            {
                DataRow layoutRow = acLayoutControl1.CreateParameterRow();

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("PART_LIKE", typeof(String)); //
                paramTable.Columns.Add("MAT_LTYPE", typeof(String)); //
                paramTable.Columns.Add("MAT_MTYPE", typeof(String)); //
                paramTable.Columns.Add("S_PART_CODE", typeof(String)); //
                paramTable.Columns.Add("IS_REG", typeof(String)); //

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["PART_LIKE"] = layoutRow["PART_LIKE"];
                paramRow["MAT_LTYPE"] = layoutRow["MAT_LTYPE"];
                paramRow["MAT_MTYPE"] = layoutRow["MAT_MTYPE"];
                paramRow["S_PART_CODE"] = layoutRow["S_PART_CODE"];
                if (layoutRow["IS_REG"].Equals("Y"))
                    paramRow["IS_REG"] = layoutRow["IS_REG"];

                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD, "STD50A_SER1", paramSet, "RQSTDT", "RSLTDT",
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
                gvLeft.GridControl.DataSource = e.result.Tables["RSLTDT"];
                gvLeft.SetOldFocusRowHandle(false);

                if (e.result.Tables["RSLTDT"].Rows.Count == 0)
                {
                    gvTop.ClearRow();
                }

                
                base.SetLog(e.executeType, e.result.Tables["RSLTDT"].Rows.Count, e.executeTime);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }


        void Search_Rev()
        {
            try
            {
                DataRow focusedRow = gvLeft.GetFocusedDataRow();

                if (focusedRow == null)
                {

                    gvTop.ClearRow();
                    tlBottom.ClearNodes();
                    return;
                }

                DataTable dtParam = new DataTable("RQSTDT");
                dtParam.Columns.Add("PLT_CODE", typeof(String));
                dtParam.Columns.Add("BM_CODE", typeof(String));

                DataRow drParam = dtParam.NewRow();
                drParam["PLT_CODE"] = acInfo.PLT_CODE;
                drParam["BM_CODE"] = focusedRow["PART_CODE"];
                dtParam.Rows.Add(drParam);

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(dtParam);

                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD_DETAIL, "STD50A_SER", paramSet, "RQSTDT", "RSLTDT",
                            QuickSearch_Rev,
                            QuickException);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void QuickSearch_Rev(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                gvTop.GridControl.DataSource = e.result.Tables["RSLTDT"];
                gvTop.SetOldFocusRowHandle(false);

                if (e.result.Tables["RSLTDT"].Rows.Count == 0)
                {
                    tlBottom.ClearNodes();
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        void SearchBOM()
        {
            try
            {
                DataRow focusedRow = null;
                focusedRow = gvTop.GetFocusedDataRow();

                if (focusedRow == null)
                {
                    tlBottom.ClearNodes();
                    resultBom = null;
                    return;
                }

                if (focusedRow["BM_CODE"].ToString() == "") return;

                DataTable dtParam = new DataTable("RQSTDT");
                dtParam.Columns.Add("PLT_CODE", typeof(String));
                dtParam.Columns.Add("BM_KEY", typeof(String));
                dtParam.Columns.Add("BM_CODE", typeof(String));

                DataRow drParam = dtParam.NewRow();
                drParam["PLT_CODE"] = acInfo.PLT_CODE;
                drParam["BM_KEY"] = focusedRow["BM_KEY"];
                drParam["BM_CODE"] = focusedRow["BM_CODE"];
                dtParam.Rows.Add(drParam);

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(dtParam);

                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD_DETAIL, "STD50A_SER2", paramSet, "RQSTDT", "RSLTDT",
                            QuickSearch2,
                            QuickException);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        void QuickException(object sender, QBiz qBiz, BizException ex)
        {
            if (ex.ErrNumber == BizActorException.ABORT)
            {
                acMessageBox.Show(ex.Message, "경 고", acMessageBox.emMessageBoxType.CONFIRM);
            }
            else
            {
                acMessageBox.Show(this, ex);
            }
        }

        
        

        void QuickSearch2(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                tlBottom.DataSource = e.result.Tables["RSLTDT"];
                resultBom = e.result.Tables["RSLTDT"];
                tlBottom.ExpandToLevel(0);

                base.SetLog(e.executeType, e.result.Tables["RSLTDT"].Rows.Count, e.executeTime);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        //BM_MASTER 코드 새로 만들기
        private void acBarButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                //acBarButtonItem item = e.Item as acBarButtonItem;

                //STD50A_D0A frm = null;

                //frm = new DES01A_D0A(gvLeft, null);

                //frm.ParentControl = this;
                //frm.DialogMode = BaseMenuDialog.emDialogMode.NEW;
                //frm.Text = item.Caption;

                //if (frm.ShowDialog() == DialogResult.OK)
                //{
                //    DataRow frmRow = (DataRow)frm.OutputData;

                    
                //    DataTable paramTable = new DataTable("RQSTDT");
                //    paramTable.Columns.Add("PLT_CODE", typeof(String));
                //    paramTable.Columns.Add("BM_CODE", typeof(String));
                //    paramTable.Columns.Add("SCOMMENT", typeof(String));
                //    paramTable.Columns.Add("REG_EMP", typeof(String));

                //    DataRow paramRow = paramTable.NewRow();
                //    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                //    paramRow["BM_CODE"] = frmRow["BM_CODE"];
                //    paramRow["SCOMMENT"] = frmRow["SCOMMENT"];
                //    paramRow["REG_EMP"] = acInfo.UserID;
                //    paramTable.Rows.Add(paramRow);

                //    DataSet paramSet = new DataSet();
                //    paramSet.Tables.Add(paramTable);

                //    BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD, "DES01A_INS", paramSet, "RQSTDT", "",
                //        QuickSave,
                //        QuickException);
                //}
            }
            catch(Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void QuickSave(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                
                foreach(DataRow dr in e.result.Tables["RSLTDT"].Rows)
                {
                    gvLeft.UpdateMapingRow(dr, true);
                }

                //base.SetLog(e.executeType, e.result.Tables["RSLTDT"].Rows.Count, e.executeTime);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        //BOM 열기
        private void acBarButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!base.ChildFormContains("BM_NEW"))
            {
                
                DataRow focusRow = gvTop.GetFocusedDataRow();

                if (focusRow == null) return;

                STD50A_D0A frm = new STD50A_D0A(focusRow, tlBottom, false);
                //STD50A_D1A frm = new STD50A_D1A(focusRow, tlBottom, false);

                frm.DialogMode = BaseMenuDialog.emDialogMode.OPEN;

                frm.ParentControl = this;

                base.ChildFormAdd("BM_NEW", frm);

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    SearchBOM();
                }
            }
            else
            {
                base.ChildFormFocus("BM_NEW");
            }
        }

        private void acBarButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {

                DataRow focusedRow = gvTop.GetFocusedDataRow();

                if (focusedRow == null) return;

                if (acMessageBox.Show(this, "정말 삭제하시겠습니까?\n[제품코드 : " + focusedRow["BM_CODE"].ToString() + ", Rev No. " + focusedRow["REV_NO"].ToString() + " ]", "", false, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
                {
                    return;
                }

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("DEL_EMP", typeof(String)); //
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("BM_KEY", typeof(String)); //
                paramTable.Columns.Add("BM_CODE", typeof(String)); //
                paramTable.Columns.Add("REV_NO", typeof(String)); //
                paramTable.Columns.Add("PART_CODE", typeof(String)); //

                DataRow paramRow = paramTable.NewRow();
                paramRow["DEL_EMP"] = acInfo.UserID;
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["BM_KEY"] = focusedRow["BM_KEY"];
                paramRow["BM_CODE"] = focusedRow["BM_CODE"];
                paramRow["REV_NO"] = focusedRow["REV_NO"];
                paramRow["PART_CODE"] = focusedRow["PART_CODE"];

                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.DEL, "STD50A_DEL", paramSet, "RQSTDT", "",
                QuickDEL,
                QuickException);

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
                //this.Search();
                foreach (DataRow dr in e.result.Tables["RSLTDT"].Rows)
                {
                    gvLeft.UpdateMapingRow(dr, false);
                }

                gvTop.GridControl.DataSource = e.result.Tables["RSLTDT2"];

                //base.SetLog(e.executeType, e.result.Tables["RSLTDT"].Rows.Count, e.executeTime);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        


        private void btnEditBom_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!base.ChildFormContains("BM_NEW"))
            {
                TreeListNode focusNode = tlBottom.FocusedNode;

                DataRow focusRow = gvTop.GetFocusedDataRow();

                if (focusRow == null) return;

                STD50A_D0A frm = new STD50A_D0A(focusRow, tlBottom, false);

                frm.DialogMode = BaseMenuDialog.emDialogMode.OPEN;

                frm.ParentControl = this;

                base.ChildFormAdd("BM_NEW", frm);

                frm.Show(this);
            }
            else
            {
                base.ChildFormFocus("BM_NEW");
            }
        }

        private void btnUpdate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                acBarButtonItem item = e.Item as acBarButtonItem;

                STD50A_D2A frm = new STD50A_D2A();
                frm.ParentControl = this;
                frm.Text = item.Caption;

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    DataRow frmRow = (DataRow)frm.OutputData;

                    DataTable paramTable = new DataTable("RQSTDT");
                    paramTable.Columns.Add("PLT_CODE", typeof(String));
                    paramTable.Columns.Add("BEF_PART_CODE", typeof(String));
                    paramTable.Columns.Add("AFT_PART_CODE", typeof(String));
                    paramTable.Columns.Add("MDFY_EMP", typeof(String));

                    DataRow paramRow = paramTable.NewRow();
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["BEF_PART_CODE"] = frmRow["BEF_PART_CODE"];
                    paramRow["AFT_PART_CODE"] = frmRow["AFT_PART_CODE"];
                    paramRow["MDFY_EMP"] = acInfo.UserID;
                    paramTable.Rows.Add(paramRow);

                    DataSet paramSet = new DataSet();
                    paramSet.Tables.Add(paramTable);

                    BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.SAVE, "STD50A_INS3", paramSet, "RQSTDT", "",
                        QuickUpdate,
                        QuickException);
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void QuickUpdate(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                int rows = 0;

                if (e.result.Tables["RSLTDT"].Rows.Count > 0)
                    rows = e.result.Tables["RSLTDT"].Rows[0]["RESULT_ROWS"].toInt();

                acMessageBox.Show(string.Format("[ {0} ] 건 일괄 변경하였습니다.", rows), "일괄변경", acMessageBox.emMessageBoxType.CONFIRM);

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        private void btnbanEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!base.ChildFormContains("BME_NEW"))
                {
                    TreeListNode focusNode = tlBottom.FocusedNode;

                    DataRow focusRow = gvTop.GetFocusedDataRow();

                    if (focusRow == null) return;

                    STD50A_D0A frm = new STD50A_D0A(focusRow, tlBottom, true);

                    frm.DialogMode = BaseMenuDialog.emDialogMode.OPEN;

                    frm.ParentControl = this;

                    base.ChildFormAdd("BME_NEW", frm);

                    frm.Show(this);
                }
                else
                {
                    base.ChildFormFocus("BME_NEW");
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //신규 BOM 등록

            if (!base.ChildFormContains("BM_NEW"))
            {
                //TreeListNode focusNode = tlBottom.FocusedNode;

                DataRow focusRow = gvLeft.GetFocusedDataRow();
              
                if (focusRow == null) return;

                if (!focusRow.Table.Columns.Contains("BM_KEY"))
                    focusRow.Table.Columns.Add("BM_KEY");

                STD50A_D0A frm = new STD50A_D0A(focusRow, null, false);

                frm.DialogMode = BaseMenuDialog.emDialogMode.NEW;

                frm.ParentControl = this;

                base.ChildFormAdd("BM_NEW", frm);

                if(frm.ShowDialog() == DialogResult.OK)
                {
                    this.SearchBOM();
                }
            }
            else
            {
                base.ChildFormFocus("BM_NEW");
            }
        }

        //복사
        private void acBarButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            copyBom = resultBom;
        }
        //붙여넣기
        private void acBarButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            DataRow focusRow = gvLeft.GetFocusedDataRow();

            if (focusRow == null) return;

            if (acMessageBox.Show(string.Format("클립보드에 복사된 내용을\n [{0}] 에 붙여넣기 하시겠습니까?", focusRow["PART_CODE"].ToString())
                        , "붙여넣기", acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
                return;

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String));
            paramTable.Columns.Add("BM_KEY", typeof(String));
            paramTable.Columns.Add("BM_CODE", typeof(String));
            paramTable.Columns.Add("PART_CODE", typeof(String));
            paramTable.Columns.Add("REV_NO", typeof(Int32));
            paramTable.Columns.Add("BOM_STATE", typeof(String));
            paramTable.Columns.Add("REV_DATE", typeof(String));

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["BM_CODE"] = focusRow["PART_CODE"];
            paramRow["PART_CODE"] = focusRow["PART_CODE"];
            paramRow["BOM_STATE"] = "DEV";
            paramRow["REV_DATE"] = DateTime.Today.toDateString("yyyyMMdd");

            paramTable.Rows.Add(paramRow);

            DataTable paramTable2 = copyBom.Copy();
            paramTable2.TableName = "RQSTDT_BOM";
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);
            paramSet.Tables.Add(paramTable2);


            BizRun.QBizRun.ExecuteService(
             this, QBiz.emExecuteType.SAVE,
             "STD50A_INS4", paramSet, "RQSTDT, RQSTDT_BOM", "RSLTDT, RSLTDT2",
             QuickPaste,
             QuickException);

        }

        void QuickPaste(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                foreach (DataRow dr in e.result.Tables["RSLTDT"].Rows)
                {
                    gvLeft.UpdateMapingRow(dr, false);
                }


                foreach (DataRow dr in e.result.Tables["RSLTDT2"].Rows)
                {
                    gvTop.UpdateMapingRow(dr, true);
                }



            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        private TreeListMultiSelection _CutNodeCollection = null;
        private void acBarButtonItem9_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            try
            {


                Hashtable nodesForDelet = GetNodesForDeleting();


                if (nodesForDelet == null) return;
                DataRow masterRow = gvTop.GetFocusedDataRow();

                //copyBan = ((DataTable)tlBottom.DataSource).Copy();
                copyBan.Clear();
                foreach (DictionaryEntry de in nodesForDelet)
                {

                    DataTable paramTable = new DataTable("RQSTDT");
                    paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                    paramTable.Columns.Add("BOM_ID", typeof(String)); //
                    paramTable.Columns.Add("BM_KEY", typeof(String)); //
                    paramTable.Columns.Add("BM_CODE", typeof(String)); //

                    DataRow paramRow = paramTable.NewRow();
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["BOM_ID"] = de.Key;
                    paramRow["BM_KEY"] = masterRow["BM_KEY"];
                    paramRow["BM_CODE"] = masterRow["BM_CODE"];

                    paramTable.Rows.Add(paramRow);

                    DataSet paramSet = new DataSet();
                    paramSet.Tables.Add(paramTable);

                    DataSet dsResult = BizRun.QBizRun.ExecuteService(this, "STD50A_SER7", paramSet, "RQSTDT", "RSLTDT");

                    if (dsResult.Tables["RSLTDT"].Rows.Count > 0)
                    {
                        DataRow resultRow = dsResult.Tables["RSLTDT"].Rows[0];

                        DataRow dr = copyBan.NewRow();


                        dr["PLT_CODE"] = acInfo.PLT_CODE;
                        dr["BM_KEY"] = resultRow["BM_KEY"];
                        dr["BOM_ID"] = resultRow["BOM_ID"];
                        dr["BM_CODE"] = resultRow["BM_CODE"];
                        if(tlBottom.Selection[0]["BOM_ID"].ToString() == resultRow["BOM_ID"].ToString())
                            dr["PARENT_ID"] = "0";
                        else
                            dr["PARENT_ID"] = resultRow["PARENT_ID"];
                        dr["PART_CODE"] = resultRow["PART_CODE"];
                        dr["PROC_GRP"] = resultRow["PROC_GRP"];
                        dr["PROC_CODE"] = resultRow["PROC_CODE"];
                        dr["BOM_QTY"] = resultRow["BOM_QTY"];


                        copyBan.Rows.Add(dr);
                    }
                }

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);

            }
        }

        Hashtable nodesForDeleting;
        private Hashtable GetNodesForDeleting()
        {
            nodesForDeleting = new Hashtable();

            IEnumerator sel = tlBottom.Selection.GetEnumerator();
            sel.Reset();

            while (sel.MoveNext())
            {
                TreeListNode node = sel.Current as TreeListNode;

                if (node["PART_CODE"].ToString() == node["BM_CODE"].ToString())
                {
                    acMessageBox.Show("제품 BOM은 복사 할 수 없습니다.", "확인", acMessageBox.emMessageBoxType.CONFIRM);
                    return null;
                }

                nodesForDeleting.Add(node["BOM_ID"], node);
            }





            return nodesForDeleting;
        }

        private void acBarButtonItem10_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (acMessageBox.Show("클립보드에 복사된 내용을\n붙여넣기 하시겠습니까?", "붙여넣기", acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
                return;

            DataRow focusRow = gvTop.GetFocusedDataRow();
            if (focusRow == null)
                return;

            MessageBox.Show(tlBottom.Selection[0]["BOM_ID"].ToString());
            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String));
            paramTable.Columns.Add("BM_KEY", typeof(String));
            paramTable.Columns.Add("BM_CODE", typeof(String));
            paramTable.Columns.Add("PARENT_ID", typeof(String));

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["BM_CODE"] = focusRow["BM_CODE"];
            paramRow["BM_KEY"] = focusRow["BM_KEY"];
            paramRow["PARENT_ID"] = tlBottom.Selection[0]["BOM_ID"].ToString();

            paramTable.Rows.Add(paramRow);

            DataTable paramTable2 = copyBan.Copy();
            paramTable2.TableName = "RQSTDT_BOM";
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);
            paramSet.Tables.Add(paramTable2);


            BizRun.QBizRun.ExecuteService(
             this, QBiz.emExecuteType.SAVE,
             "STD50A_INS5", paramSet, "RQSTDT, RQSTDT_BOM", "RSLTDT, RSLTDT2",
             QuickPaste,
             QuickException);
        }


        private void btnExpand_Click(object sender, EventArgs e)
        {
            if (tlBottom.Nodes.Count > 0)
                tlBottom.ExpandAll();
        }

        private void acSimpleButton1_Click(object sender, EventArgs e)
        {
            if (tlBottom.Nodes.Count > 0)
                tlBottom.CollapseAll();
        }
    }
}
    