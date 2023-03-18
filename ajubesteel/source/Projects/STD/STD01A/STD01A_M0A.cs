using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Grid;

using ControlManager;
using CodeHelperManager;
using DevExpress.XtraEditors.Repository;

using BizManager;

namespace STD
{
    public sealed partial class STD01A_M0A : BaseMenu
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

        public STD01A_M0A()
        {
            InitializeComponent();


            //이벤트 설정
            acGridView1.FocusedRowChanged += acGridView1_FocusedRowChanged;
            acGridView1.MouseDown += acGridView1_MouseDown;
            acGridView1.ShowGridMenuEx += acGridView1_ShowGridMenuEx;
            
            gvS.MouseDown += new MouseEventHandler(gvS_MouseDown);
            gvS.FocusedRowChanged += new FocusedRowChangedEventHandler(gvS_FocusedRowChanged);
            gvS.ShowGridMenuEx +=new acGridView.ShowGridMenuExHandler(gvS_ShowGridMenuEx);
            gvS.OnMapingRowChanged += new acGridView.MapingRowChangedEventHandler(gvS_OnMapingRowChanged);

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

        public override void MenuInitComplete()
        {
            
            base.MenuInitComplete();
        }

        public override void MenuInit()
        {
            acGridView1.GridType = acGridView.emGridType.SEARCH;
            //acGridView1.GridType = acGridView.emGridType.AUTO_COL;

            acGridView1.AddTextEdit("PRG_CODE", "공정그룹 코드", "40962", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("PRG_NAME", "공정그룹", "40045", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("ORG_NAME", "담당부서", "40126", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            //acGridView1.AddColorEdit("PRG_COLOR", "색상", "40281", true, DevExpress.Utils.HorzAlignment.Center, false, true);

            //acGridView1.AddLookUpEdit("INS_FLAG", "입고검사여부", "42560", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "S063");
            //acGridView1.AddCheckEdit("IS_OS", "외주가능", "0PZP4HXS", true, false, true, acGridView.emCheckEditDataType._BYTE);
            //acGridView1.AddLookUpEdit("PRG_TYPE", "일정형태", "AT04WS2Q", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "S006");

            acGridView1.AddTextEdit("PRG_SEQ", "순서", "40382", true, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.KeyColumn = new string[] { "PRG_CODE" };



            gvS.GridType = acGridView.emGridType.SEARCH;
            //gvS.GridType = acGridView.emGridType.AUTO_COL;

            gvS.AddCheckEdit("SEL", "선택", "40290", true, true, true, acGridView.emCheckEditDataType._STRING);

            gvS.AddTextEdit("PROC_CODE", "공정코드", "40920", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            gvS.AddTextEdit("PROC_NAME", "공정명", "40921", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            gvS.AddColorEdit("PROC_COLOR", "색상", "40281", true, DevExpress.Utils.HorzAlignment.Center, false, true);

            //gvS.AddLookUpEdit("INS_FLAG", "입고검사여부", "42560", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, "S063");

            gvS.AddTextEdit("PROC_MAN_TIME", "공수계", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.F2);

            gvS.AddTextEdit("PROC_UC", "공정 단가", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);

            gvS.AddTextEdit("PROC_COST", "공정 비용", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);

            //gvS.AddTextEdit("PROC_SELF_TIME", "기본 무인공수", "WEN5OLRH", true, DevExpress.Utils.HorzAlignment.Far, false, false, false, acGridView.emTextEditMask.TIME);

            //gvS.AddCheckEdit("IS_MAT", "자재발주", "0PZP4HXS", false, false, true, acGridView.emCheckEditDataType._BYTE);

            gvS.AddCheckEdit("IS_OS", "외주공정", "0PZP4HXS", false, false, true, acGridView.emCheckEditDataType._BYTE);

            //gvS.AddLookUpEdit("BAL_DISP", "발주서 표시", "VJP0T4B1", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, "S088");

            gvS.AddLookUpEdit("WO_TYPE", "작업지시 구분", "VJP0T4B1", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "S103");

            //gvS.AddCheckEdit("IS_BOP_PROC", "BOP 공정", "OMVJF9WC", true, false, true, acGridView.emCheckEditDataType._BYTE);

            //gvS.AddCheckEdit("IS_CHECK_PREV_PROC", "이전 공정확인", "6BT012DK", true, false, false, acGridView.emCheckEditDataType._BYTE);

            //gvS.AddCheckEdit("IS_PART_SAME_START", "부품내 동시진행가능", "A782SUA0", true, false, false, acGridView.emCheckEditDataType._BYTE);

            //gvS.AddCheckEdit("IS_CHECK_TOOL", "공구확인", "AJGZPGML", true, false, false, acGridView.emCheckEditDataType._BYTE);

            //gvS.AddTextEdit("WO_DEFAULT_OSMC", "외주설비코드", "M7J0QMEF", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);

            //gvS.AddTextEdit("WO_DEFAULT_OSMC_NAME", "외주설비코드", "3PUSJN19", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);


            gvS.AddTextEdit("CPROC_CODE", "임률코드,", "OKL64GAA", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            gvS.AddTextEdit("CPROC_NAME", "임률명", "QLQAMPP1", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);


            //gvS.AddTextEdit("MAIN_VND", "기본 거래처코드", "Z8OA566Z", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);

            //gvS.AddTextEdit("MAIN_VND_NAME", "기본 거래처명", "1NSUG8A3", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);

            //gvS.AddLookUpEdit("ACT_CODE", "회계계정", "42569", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, "C600");

            gvS.AddTextEdit("SCOMMENT", "주의사항", "W17GYPQY", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

            gvS.AddTextEdit("PROC_SEQ", "표시순서", "40723", true, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);


            //gvS.AddTextEdit("IF_PROC_CODE", "IF 코드", "K8GKZPXM", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);



            gvS.KeyColumn = new string[] { "PROC_CODE" };



            //가용설비 그리드 설정
            gvMC.GridType = acGridView.emGridType.SEARCH;
            //gvMC.GridType = acGridView.emGridType.AUTO_COL;
            gvMC.OptionsView.ShowIndicator = true;


            gvMC.AddLookUpEdit("MC_GROUP", "기계그룹", "40308", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "C020");

            gvMC.AddTextEdit("MC_CODE", "설비코드", "41162", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            gvMC.AddTextEdit("MC_NAME", "설비명", "41202", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            gvMC.AddTextEdit("MC_MODEL", "실모델명", "40400", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            gvMC.AddCheckEdit("MC_AUTOMATED", "무인가공", "40973", true, false, false, acGridView.emCheckEditDataType._BYTE);

            gvMC.AddCheckEdit("MC_OS", "외부설비", "40974", true, false, false, acGridView.emCheckEditDataType._BYTE);

            gvMC.AddCheckEdit("MC_MGT_FLAG", "부하 관리대상", "40065", true, false, false, acGridView.emCheckEditDataType._BYTE);

            gvMC.AddDateEdit("MC_OPEN_DATE", "유효시작일", "40477", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);

            gvMC.AddDateEdit("MC_CLOSE_DATE", "유효종료일", "40478", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);

            gvMC.AddTextEdit("MC_SEQ", "표시순서", "40723", true, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);

            gvMC.AddTextEdit("MAIN_EMP", "담당자코드", "42388", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            gvMC.AddTextEdit("MAIN_EMP_NAME", "담당자", "40127", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            gvMC.AddTextEdit("SCOMMENT", "비고", "ARYZ726K", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);


            base.MenuInit();
        }

        void acGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            acGridView view = sender as acGridView;

            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                GridHitInfo hitInfo = view.CalcHitInfo(e.Location);

                if (hitInfo.HitTest == GridHitTest.RowCell || hitInfo.HitTest == GridHitTest.Row)
                {
                    this.btnOpenProcGrp_ItemClick(null, null);
                }

            }
        }

        void acGridView1_ShowGridMenuEx(object sender, PopupMenuShowingEventArgs e)
        {
            //공정그룹 팝업메뉴

            acGridView view = sender as acGridView;

            if (e.HitInfo.HitTest == GridHitTest.EmptyRow || e.HitInfo.HitTest == GridHitTest.Row || e.HitInfo.HitTest == GridHitTest.RowCell)
            {


                if (e.MenuType == GridMenuType.User)
                {
                    btnOpenProcGrp.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    btnDelProcGrp.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;



                }
                else if (e.MenuType == GridMenuType.Row)
                {
                    if (e.HitInfo.RowHandle > 0)
                    {
                        btnOpenProcGrp.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        btnDelProcGrp.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        btnAddProcGrp.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    }
                    else
                    {
                        btnOpenProcGrp.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        btnDelProcGrp.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;



                    }

                }

                GridHitInfo hitInfo = view.CalcHitInfo(e.Point);

                if (hitInfo.InColumn == false)
                {
                    popupGroup.ShowPopup(view.GridControl.PointToScreen(e.Point));
                }

            }
        }

        void acGridView1_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            try
            {
                this.GetSData();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void gvS_OnMapingRowChanged(acGridView.emMappingRowChangedType type, DataRow row)
        {
            if (type == acGridView.emMappingRowChangedType.DELETE)
            {
                string formKey = string.Format("{0},{1}", "S", row["PROC_CODE"]);

                base.ChildFormRemove(row["PROC_CODE"]);
            }
        }

        
        void gvS_ShowGridMenuEx(object sender, PopupMenuShowingEventArgs e)
        {
            //소일정 팝업메뉴

            acGridView view = sender as acGridView;

            if (e.HitInfo.HitTest == GridHitTest.EmptyRow || e.HitInfo.HitTest == GridHitTest.Row || e.HitInfo.HitTest == GridHitTest.RowCell)
            {


                if (e.MenuType == GridMenuType.User)
                {
                    acBarButtonItem8.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    acBarButtonItem9.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    acBarSubItem5.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

                }
                else if (e.MenuType == GridMenuType.Row)
                {
                    if (e.HitInfo.RowHandle >= 0)
                    {
                        acBarButtonItem8.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        acBarButtonItem9.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        acBarSubItem5.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    }
                    else
                    {
                        acBarButtonItem8.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        acBarButtonItem9.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        
                       

                    }

                }

                GridHitInfo hitInfo = view.CalcHitInfo(e.Point);

                if (hitInfo.InColumn == false)
                {
                    popupSmall.ShowPopup(view.GridControl.PointToScreen(e.Point));
                }

            }

        }


        private void gvS_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            //가용기계 조회

            GetMCData();
        }



  
        void QuickBSearch(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {

            try
            {
              
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }


        void QuickException(object sender, QBiz qBiz, BizManager.BizException ex)
        {


            if (ex.ErrNumber == BizManager.BizException.DATA_REFRESH)
            {

                this.DataRefresh(null);

            }
            else
            {
                acMessageBox.Show(this, ex);

            }
        }

        private void GetPrgGroup()
        {
            try
            {

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;

                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD,
                    "STD01A_SER6", paramSet, "RQSTDT", "RSLTDT",
                    QuickPrgSearch,
                    QuickException);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void QuickPrgSearch(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                DataTable dtRslt = e.result.Tables["RSLTDT"];

                DataRow dr = dtRslt.NewRow(); //dtRslt.Rows[dtRslt.Rows.Count - 1];
                dr["PLT_CODE"] = acInfo.PLT_CODE;
                dr["PRG_CODE"] = "";
                dr["PRG_NAME"] = "전체";

                dtRslt.Rows.InsertAt(dr, 0);

                acGridView1.GridControl.DataSource = e.result.Tables["RSLTDT"];

                acGridView1.SetOldFocusRowHandle(true);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        /// <summary>
        /// /소일정(공정) 조회
        /// </summary>
        private void GetSData()
        {
            try
            {

                DataRow dr = acGridView1.GetFocusedDataRow();

                if (dr == null) return;

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("PRG_CODE", typeof(String)); //

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["PRG_CODE"] = dr["PRG_CODE"];

                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                //BizRun.QBizRun.ExecuteService(
                //this, QBiz.emExecuteType.LOAD,
                //"STD01A_SER3", paramSet, "RQSTDT", "RSLTDT",
                //QuickSearch,
                //QuickException);

                DataSet dsResult = BizRun.QBizRun.ExecuteService(this, "STD01A_SER3", paramSet, "RQSTDT", "RSLTDT");

                gvS.GridControl.DataSource = dsResult.Tables["RSLTDT"];

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
                gvS.GridControl.DataSource = e.result.Tables["RSLTDT"];

                gvS.SetOldFocusRowHandle(true);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        /// <summary>
        /// 가용기계 조회
        /// </summary>
        private void GetMCData()
        {
            try
            {

                if (gvS.ValidFocusRowHandle() == true)
                {
                    
                    DataRow masterFocusRow = gvS.GetFocusedDataRow();

                    if (masterFocusRow == null)
                    {
                        gvMC.ClearRow();
                        return;
                    }

                    DataTable paramTable = new DataTable("RQSTDT");
                    paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                    paramTable.Columns.Add("PROC_CODE", typeof(String)); //

                    DataRow paramRow = paramTable.NewRow();
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["PROC_CODE"] = masterFocusRow["PROC_CODE"];

                    paramTable.Rows.Add(paramRow);
                    DataSet paramSet = new DataSet();
                    paramSet.Tables.Add(paramTable);

                    BizRun.QBizRun.ExecuteService(
                    this, QBiz.emExecuteType.LOAD_DETAIL,
                    "STD01A_SER4", paramSet, "RQSTDT", "RSLTDT",
                    QuickMachineSearch,
                    QuickException);

                }
                else
                {
                    gvMC.ClearRow();
                }


            }
            catch (Exception ex)
            {

                acMessageBox.Show(this, ex);
            }

        }
        void QuickMachineSearch(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                gvMC.GridControl.DataSource = e.result.Tables["RSLTDT"];
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

    
        void gvS_MouseDown(object sender, MouseEventArgs e)
        {
            acGridView view = sender as acGridView;

            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                GridHitInfo hitInfo = view.CalcHitInfo(e.Location);

                if (hitInfo.HitTest == GridHitTest.RowCell || hitInfo.HitTest == GridHitTest.Row)
                {
                    //소일정 편집기 열기

                    this.acBarButtonItem8_ItemClick(null, null);
                }

            }
        }




        private void barItemSearch_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //조회
            try
            {
                this.GetPrgGroup();

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void btnAddProcGrp_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //새로만들기 공정그룹 편집기
            try
            {
                if (!base.ChildFormContains("NEW_G"))
                {

                    STD01A_D0A_G frm = new STD01A_D0A_G(acGridView1, null);
                    frm.DialogMode = BaseMenuDialog.emDialogMode.NEW;
                    frm.ParentControl = this;

                    base.ChildFormAdd("NEW_G", frm);

                    frm.Show(this);
                }
                else
                {
                    base.ChildFormFocus("NEW_G");
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void btnOpenProcGrp_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                DataRow focusRow = acGridView1.GetFocusedDataRow();

                string formKey = string.Format("{0},{1}", "S", focusRow["PRG_CODE"]);

                if (!base.ChildFormContains(formKey))
                {

                    STD01A_D0A_G frm = new STD01A_D0A_G(acGridView1, focusRow);
                    frm.DialogMode = BaseMenuDialog.emDialogMode.OPEN;

                    frm.ParentControl = this;

                    base.ChildFormAdd(formKey, frm);

                    frm.Show(this);
                }
                else
                {
                    base.ChildFormFocus(formKey);
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void btnDelProcGrp_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                acGridView1.EndEditor();


                ParameterYesNoDialogResult msgResult = acMessageBox.ShowParameterYesNo(this, "정말 삭제하시겠습니까?", "TB43FSY3", true, acInfo.Resource.GetString("삭제사유", "A9DY9R6G"));


                if (msgResult.DialogResult == DialogResult.No) return;
                
                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //사업장 코드
                paramTable.Columns.Add("PRG_CODE", typeof(String)); //
                paramTable.Columns.Add("DEL_EMP", typeof(String)); //
                paramTable.Columns.Add("DEL_REASON", typeof(String)); //

                DataRow focuseRow = acGridView1.GetFocusedDataRow();

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["PRG_CODE"] = focuseRow["PRG_CODE"];
                paramRow["DEL_EMP"] = acInfo.UserID;
                paramRow["DEL_REASON"] = msgResult.Parameter;
                paramTable.Rows.Add(paramRow);

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(
                    this, QBiz.emExecuteType.DEL,
                    "STD01A_DEL4", paramSet, "RQSTDT", "", QuickDEL, QuickException);


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

                foreach (DataRow row in e.result.Tables["RQSTDT"].Rows)
                {
                    acGridView1.DeleteMappingRow(row);
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }


        private void acBarButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //새로만들기 소일정 편집기
            try
            {
                DataRow dr = acGridView1.GetFocusedDataRow();
                string prgCode = null;
                if (dr != null) prgCode = dr["PRG_CODE"].ToString();

                if (!base.ChildFormContains("NEW_S"))
                {

                    STD01A_D0A_S frm = new STD01A_D0A_S(gvS, null, prgCode);
                    frm.DialogMode = BaseMenuDialog.emDialogMode.NEW;

                    frm.ParentControl = this;

                    base.ChildFormAdd("NEW_S", frm);

                    frm.Show(this);
                }
                else
                {
                    base.ChildFormFocus("NEW_S");
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }


        }

        private void acBarButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //소일정 편집기 열기
            try
            {
                DataRow focusRow = gvS.GetFocusedDataRow();

                string formKey = string.Format("{0},{1}", "S", focusRow["PROC_CODE"]);

                if (!base.ChildFormContains(formKey))
                {

                    STD01A_D0A_S frm = new STD01A_D0A_S(gvS, new object[] { focusRow, gvMC.GridControl.DataSource }, null);
                    frm.DialogMode = BaseMenuDialog.emDialogMode.OPEN;

                    frm.ParentControl = this;

                    base.ChildFormAdd(formKey, frm);

                    frm.Show(this);
                }
                else
                {
                    base.ChildFormFocus(formKey);
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }


        }

        private void acBarButtonItem9_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //소일정 삭제

            try
            {
                gvS.EndEditor();


                ParameterYesNoDialogResult msgResult = acMessageBox.ShowParameterYesNo(this, "정말 삭제하시겠습니까?", "TB43FSY3", true, acInfo.Resource.GetString("삭제사유", "A9DY9R6G"));


                if (msgResult.DialogResult == DialogResult.No)
                {
                    return;
                }
                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //사업장 코드
                paramTable.Columns.Add("PROC_CODE", typeof(String)); //
                paramTable.Columns.Add("DEL_EMP", typeof(String)); //
                paramTable.Columns.Add("DEL_REASON", typeof(String)); //

                DataView selected = gvS.GetDataSourceView("SEL = '1'");



                if (selected.Count == 0)
                {
                    DataRow focuseRow = gvS.GetFocusedDataRow();

                    DataRow paramRow = paramTable.NewRow();
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["PROC_CODE"] = focuseRow["PROC_CODE"];
                    paramRow["DEL_EMP"] = acInfo.UserID;
                    paramRow["DEL_REASON"] = msgResult.Parameter;
                    paramTable.Rows.Add(paramRow);

                }
                else
                {
                    for (int i = 0; i < selected.Count; i++)
                    {

                        DataRow paramRow = paramTable.NewRow();
                        paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                        paramRow["PROC_CODE"] = selected[i]["PROC_CODE"];
                        paramRow["DEL_EMP"] = acInfo.UserID;
                        paramRow["DEL_REASON"] = msgResult.Parameter;

                        paramTable.Rows.Add(paramRow);
                    }

                }


                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.DEL,
                "STD01A_DEL3", paramSet, "RQSTDT", "",
                QuickSmallDEL,
                QuickException);


            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }


        }

        void QuickSmallDEL(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {

                foreach (DataRow row in e.result.Tables["RQSTDT"].Rows)
                {
                    gvS.DeleteMappingRow(row);

                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        private void acBarButtonItem11_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //소일정 이동
            try
            {
                gvS.EndEditor();

                if (gvS.ValidFocusRowHandle() == false)
                {
                    return;
                }


                acPlanInstantResult result = acPlan.ShowInstantForm(this, acPlan.emShowPlanType.L, e.Item.Caption, null);


                if (result.DialogResult == DialogResult.OK)
                {

                    DataRow frmRow = result.OutputData as DataRow;

                    DataView selected = gvS.GetDataSourceView("SEL = '1'");

                    DataTable paramTable = new DataTable("RQSTDT");
                    paramTable.Columns.Add("MPROC_CODE", typeof(String)); //
                    paramTable.Columns.Add("REG_EMP", typeof(String)); //
                    paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                    paramTable.Columns.Add("PROC_CODE", typeof(String)); //

                    if (selected.Count == 0)
                    {
                        //단일선택
                        DataRow focuseRow = gvS.GetFocusedDataRow();

                        DataRow paramRow = paramTable.NewRow();
                        paramRow["MPROC_CODE"] = frmRow["PRG_CODE"];
                        paramRow["REG_EMP"] = acInfo.UserID;
                        paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                        paramRow["PROC_CODE"] = focuseRow["PROC_CODE"];
                        paramTable.Rows.Add(paramRow);


                    }
                    else
                    {
                        //다중선택

                        for (int i = 0; i < selected.Count; i++)
                        {

                            DataRow paramRow = paramTable.NewRow();
                            paramRow["MPROC_CODE"] = frmRow["PRG_CODE"];
                            paramRow["REG_EMP"] = acInfo.UserID;
                            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                            paramRow["PROC_CODE"] = selected[i]["PROC_CODE"];
                            paramTable.Rows.Add(paramRow);
                        }

                    }


                    DataSet paramSet = new DataSet();
                    paramSet.Tables.Add(paramTable);

                    BizRun.QBizRun.ExecuteService(
                    this, QBiz.emExecuteType.PROCESS,
                    "STD01A_UPD2", paramSet, "RQSTDT", "",
                    QuickSmallUPD,
                    QuickException);

                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }


        }
        void QuickSmallUPD(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                this.DataRefresh(null);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void acBarButtonItem12_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //엑셀 데이터 불러오기
            try
            {
                acBarButtonItem item = e.Item as acBarButtonItem;

                STD01A_D0A_S2 frm = new STD01A_D0A_S2();

                frm.ParentControl = this;

                frm.Text = item.Caption;

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    this.GetSData();
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }


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


    }
}

