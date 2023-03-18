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
    public sealed partial class STD41A_M0A : BaseMenu
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

        public STD41A_M0A()
        {
            InitializeComponent();


            //이벤트 설정


            gvB.FocusedRowChanged += new FocusedRowChangedEventHandler(gvB_FocusedRowChanged);
            gvB.MouseDown += new MouseEventHandler(gvB_MouseDown);
            gvB.ShowGridMenuEx +=new acGridView.ShowGridMenuExHandler(gvB_ShowGridMenuEx);
            gvB.OnMapingRowChanged += new acGridView.MapingRowChangedEventHandler(gvB_OnMapingRowChanged);


            gvM.MouseDown += new MouseEventHandler(gvM_MouseDown);
            gvM.FocusedRowChanged += new FocusedRowChangedEventHandler(gvM_FocusedRowChanged);
            gvM.ShowGridMenuEx +=new acGridView.ShowGridMenuExHandler(gvM_ShowGridMenuEx);
            gvM.OnMapingRowChanged += new acGridView.MapingRowChangedEventHandler(gvM_OnMapingRowChanged);


            gvS.MouseDown += new MouseEventHandler(gvS_MouseDown);
            gvS.FocusedRowChanged += new FocusedRowChangedEventHandler(gvS_FocusedRowChanged);
            gvS.ShowGridMenuEx +=new acGridView.ShowGridMenuExHandler(gvS_ShowGridMenuEx);
            gvS.OnMapingRowChanged += new acGridView.MapingRowChangedEventHandler(gvS_OnMapingRowChanged);


        }

        void gvS_OnMapingRowChanged(acGridView.emMappingRowChangedType type, DataRow row)
        {
            if (type == acGridView.emMappingRowChangedType.DELETE)
            {
                string formKey = string.Format("{0},{1}", "S", row["PROC_CODE"]);

                base.ChildFormRemove(row["PROC_CODE"]);
            }
        }

        void gvB_OnMapingRowChanged(acGridView.emMappingRowChangedType type, DataRow row)
        {
            if (type == acGridView.emMappingRowChangedType.DELETE)
            {
                string formKey = string.Format("{0},{1}", "B", row["PRG_CODE"]);

                base.ChildFormRemove(row["PRG_CODE"]);
            }
        }

        void gvM_OnMapingRowChanged(acGridView.emMappingRowChangedType type, DataRow row)
        {
            if (type == acGridView.emMappingRowChangedType.DELETE)
            {
                string formKey = string.Format("{0},{1}", "M", row["PRG_CODE"]);

                base.ChildFormRemove(formKey);
            }
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

        void gvM_ShowGridMenuEx(object sender, PopupMenuShowingEventArgs e)
        {
            //중일정 팝업메뉴

            acGridView view = sender as acGridView;

            if (e.HitInfo.HitTest == GridHitTest.EmptyRow || e.HitInfo.HitTest == GridHitTest.Row || e.HitInfo.HitTest == GridHitTest.RowCell)
            {


                if (e.MenuType == GridMenuType.User)
                {
                    acBarButtonItem5.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    acBarButtonItem6.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;


                }
                else if (e.MenuType == GridMenuType.Row)
                {
                    if (e.HitInfo.RowHandle >= 0)
                    {
                        acBarButtonItem5.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        acBarButtonItem6.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    }
                    else
                    {
                        acBarButtonItem5.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        acBarButtonItem6.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    }

                }

                GridHitInfo hitInfo = view.CalcHitInfo(e.Point);

                if (hitInfo.InColumn == false)
                {
                    popupMiddle.ShowPopup(view.GridControl.PointToScreen(e.Point));
                }

            }
        }

        void gvB_ShowGridMenuEx(object sender, PopupMenuShowingEventArgs e)
        {
            //대일정 팝업메뉴

            acGridView view = sender as acGridView;

            if (e.HitInfo.HitTest == GridHitTest.EmptyRow || e.HitInfo.HitTest == GridHitTest.Row || e.HitInfo.HitTest == GridHitTest.RowCell)
            {


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

                GridHitInfo hitInfo = view.CalcHitInfo(e.Point);

                if (hitInfo.InColumn == false)
                {
                    popupLarge.ShowPopup(view.GridControl.PointToScreen(e.Point));
                }

            }
        }

        public override void MenuInit()
        {

            //대일정 그리드 설정

            gvB.GridType = acGridView.emGridType.SEARCH;

            gvB.AddTextEdit("PRG_CODE", "일정코드", "WHZ16F4U", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            gvB.AddTextEdit("PRG_NAME", "일정명", "EJPVN5D0", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            gvB.AddTextEdit("ORG_NAME", "담당부서", "40126", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            gvB.AddColorEdit("PRG_COLOR", "색상", "40281", true, DevExpress.Utils.HorzAlignment.Center, false, true);

            gvB.AddLookUpEdit("INS_FLAG", "입고검사여부", "42560", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "S063");

            gvB.AddCheckEdit("IS_OS", "외주가능", "0PZP4HXS", true, false, true, acGridView.emCheckEditDataType._BYTE);

            gvB.AddLookUpEdit("PRG_TYPE", "일정형태", "AT04WS2Q", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "S006");

            gvB.AddTextEdit("PRG_SEQ", "순서", "40382", true, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);


            gvB.KeyColumn = new string[] { "PRG_CODE" };


            //중일정 그리드 설정


            gvM.GridType = acGridView.emGridType.SEARCH;

            gvM.AddCheckEdit("SEL", "선택", "40290", true, true, true, acGridView.emCheckEditDataType._STRING);

            gvM.AddTextEdit("PRG_CODE", "일정코드", "WHZ16F4U", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            gvM.AddTextEdit("PRG_NAME", "일정명", "EJPVN5D0", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            gvM.AddTextEdit("ORG_NAME", "권한부서", "42481", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            gvM.AddColorEdit("PRG_COLOR", "색상", "40281", true, DevExpress.Utils.HorzAlignment.Center, false, true);


            gvM.AddLookUpEdit("INS_FLAG", "입고검사여부", "42560", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "S063");

            gvM.AddCheckEdit("IS_OS", "외주가능", "0PZP4HXS", true, false, true, acGridView.emCheckEditDataType._BYTE);

            gvM.AddCheckEdit("MCLASS_FLAG", "중일정계획 실적관리", "42309", true, false, true, acGridView.emCheckEditDataType._BYTE);

            gvM.AddLookUpEdit("PRG_TYPE", "일정형태", "AT04WS2Q", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "S006");

            gvM.AddTextEdit("PRG_SEQ", "순서", "40382", true, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);

            gvM.KeyColumn = new string[] { "PRG_CODE" };


            //소일정 그리드 설정


            gvS.GridType = acGridView.emGridType.SEARCH;

            gvS.AddCheckEdit("SEL", "선택", "40290", true, true, true, acGridView.emCheckEditDataType._STRING);


            gvS.AddTextEdit("LPROC_CODE", "대일정코드", "J9JUSMI9", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            gvS.AddTextEdit("LPROC_NAME", "대일정명", "FLB6T3Z9", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);

            gvS.AddTextEdit("MPROC_CODE", "중일정코드", "PWTROOUT", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            gvS.AddTextEdit("MPROC_NAME", "중일정명", "561M1BEG", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);



            gvS.AddTextEdit("PROC_CODE", "공정코드", "40920", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            
            gvS.AddTextEdit("PROC_NAME", "공정명", "40921", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            gvS.AddColorEdit("PROC_COLOR", "색상", "40281", true, DevExpress.Utils.HorzAlignment.Center, false, true);

            gvS.AddLookUpEdit("INS_FLAG", "입고검사여부", "42560", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "S063");


            gvS.AddTextEdit("PROC_MAN_TIME", "기본 유인공수", "26Q8PX5Z", true, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.TIME);

            gvS.AddTextEdit("PROC_SELF_TIME", "기본 무인공수", "WEN5OLRH", true, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.TIME);



            gvS.AddCheckEdit("IS_OS", "외주가능", "0PZP4HXS", true, false, true, acGridView.emCheckEditDataType._BYTE);

            gvS.AddCheckEdit("IS_BOP_PROC", "BOP 공정", "OMVJF9WC", true, false, true, acGridView.emCheckEditDataType._BYTE);

            gvS.AddCheckEdit("IS_CHECK_PREV_PROC", "이전 공정확인", "6BT012DK", true, false, true, acGridView.emCheckEditDataType._BYTE);

            gvS.AddCheckEdit("IS_PART_SAME_START", "부품내 동시진행가능", "A782SUA0", true, false, true, acGridView.emCheckEditDataType._BYTE);

            gvS.AddCheckEdit("IS_CHECK_TOOL", "공구확인", "AJGZPGML", true, false, true, acGridView.emCheckEditDataType._BYTE);



            gvS.AddTextEdit("MPROC_PROGRESS_RATE", "중일정계획 진도율(%)", "ROK6V3Y6", true, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.PER100);

            gvS.AddTextEdit("WO_DEFAULT_OSMC", "외주설비코드", "M7J0QMEF", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            gvS.AddTextEdit("WO_DEFAULT_OSMC_NAME", "외주설비코드", "3PUSJN19", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);


            gvS.AddTextEdit("CPROC_CODE", "견적임률코드,", "OKL64GAA", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            gvS.AddTextEdit("CPROC_NAME", "견적임률명", "QLQAMPP1", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);


            gvS.AddTextEdit("MAIN_VND", "기본 거래처코드", "Z8OA566Z", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            gvS.AddTextEdit("MAIN_VND_NAME", "기본 거래처명", "1NSUG8A3", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            gvS.AddLookUpEdit("ACT_CODE", "회계계정", "42569", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "C600");

            gvS.AddTextEdit("PROC_SEQ", "표시순서", "40723", true, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);


            gvS.AddTextEdit("IF_PROC_CODE", "IF 코드", "K8GKZPXM", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);

            

            gvS.KeyColumn = new string[] { "PROC_CODE" };
            


            //가용설비 그리드 설정
            gvMC.GridType = acGridView.emGridType.SEARCH;
            gvMC.OptionsView.ShowIndicator = true;


            gvMC.AddLookUpEdit("MC_GROUP", "기계그룹", "40308", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "C020");

            gvMC.AddTextEdit("MC_CODE", "설비코드", "41162", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            gvMC.AddTextEdit("MC_NAME", "설비명", "41202", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            gvMC.AddTextEdit("MC_MODEL", "실모델명", "40400", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            gvMC.AddCheckEdit("MC_AUTOMATED", "무인가공", "40973", true, false, true, acGridView.emCheckEditDataType._BYTE);

            gvMC.AddCheckEdit("MC_OS", "외부설비", "40974", true, false, true, acGridView.emCheckEditDataType._BYTE);

            gvMC.AddCheckEdit("MC_MGT_FLAG", "부하 관리대상", "40065", true, false, true, acGridView.emCheckEditDataType._BYTE);

            gvMC.AddDateEdit("MC_OPEN_DATE", "유효시작일", "40477", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);

            gvMC.AddDateEdit("MC_CLOSE_DATE", "유효종료일", "40478", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);

            gvMC.AddTextEdit("MC_SEQ", "표시순서", "40723", true, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);

            gvMC.AddTextEdit("MAIN_EMP", "담당자코드", "42388", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            gvMC.AddTextEdit("MAIN_EMP_NAME", "담당자", "40127", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            gvMC.AddTextEdit("SCOMMENT", "비고", "ARYZ726K", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);


            base.MenuInit();
        }

        public override void MenuInitComplete()
        {
            //20160405 김준구 - 메뉴 실행 시 자동조회 부분 삭제 ; 스레드 에러 문제
            //this.Search();

            base.MenuInitComplete();
        }


        void Search()
        {
            //대일정 조회
            GetBData();

        }

        private void gvB_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            //중일정 조회

            GetMData();

        }
        private void gvM_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            //소일정 조회

            GetSData();


        }
        private void gvS_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            //가용기계 조회

            GetMCData();
        }



        private void GetBData()
        {

            //대일정 조회

            try
            {

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);


                BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.NONE,
                "STD41A_SER", paramSet, "RQSTDT", "RSLTDT",
                QuickBSearch,
                QuickException);


            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }


        }
        void QuickBSearch(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {

            try
            {
                gvB.GridControl.DataSource = e.result.Tables["RSLTDT"];

                gvB.SetOldFocusRowHandle(true);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        /// <summary>
        /// 중일정 조회
        /// </summary>
        private void GetMData()
        {

            try
            {
                if (gvB.ValidFocusRowHandle() == true)
                {

                    DataRow masterFocusRow = gvB.GetFocusedDataRow();


                    DataTable paramTable = new DataTable("RQSTDT");
                    paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                    paramTable.Columns.Add("UP_CLASS", typeof(String)); //

                    DataRow paramRow = paramTable.NewRow();
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["UP_CLASS"] = masterFocusRow["PRG_CODE"];
                    paramTable.Rows.Add(paramRow);
                    DataSet paramSet = new DataSet();
                    paramSet.Tables.Add(paramTable);


                    BizRun.QBizRun.ExecuteService(
                    this, QBiz.emExecuteType.LOAD_DETAIL,
                    "STD41A_SER2", paramSet, "RQSTDT", "RSLTDT",
                    QuickMSearch,
                    QuickException);


                }
                else
                {
                    gvM.ClearRow();
                }



            }
            catch (Exception ex)
            {

                acMessageBox.Show(this, ex);
            }


        }

        void QuickMSearch(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                gvM.GridControl.DataSource = e.result.Tables["RSLTDT"];

                gvM.SetOldFocusRowHandle(true);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        public override void DataRefresh(object data)
        {
            this.Search();
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


        /// <summary>
        /// /소일정(공정) 조회
        /// </summary>
        private void GetSData()
        {
            try
            {
                if (gvM.ValidFocusRowHandle() == true)
                {

                    DataRow bFocusRow = gvB.GetFocusedDataRow();
                    DataRow mFocusRow = gvM.GetFocusedDataRow();

                    DataTable paramTable = new DataTable("RQSTDT");
                    paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                    paramTable.Columns.Add("LPROC_CODE", typeof(String)); //
                    paramTable.Columns.Add("MPROC_CODE", typeof(String)); //

                    DataRow paramRow = paramTable.NewRow();
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;


                    if (bFocusRow != null)
                    {
                        paramRow["LPROC_CODE"] = bFocusRow["PRG_CODE"];
                    }


                    if (mFocusRow != null)
                    {
                        paramRow["MPROC_CODE"] = mFocusRow["PRG_CODE"];
                    }

                    paramTable.Rows.Add(paramRow);
                    DataSet paramSet = new DataSet();
                    paramSet.Tables.Add(paramTable);


                    BizRun.QBizRun.ExecuteService(
                    this, QBiz.emExecuteType.LOAD_DETAIL,
                    "STD41A_SER3", paramSet, "RQSTDT", "RSLTDT",
                    QuickSSearch,
                    QuickException);
                }
                else
                {
                    gvS.ClearRow();
                }



            }
            catch (Exception ex)
            {

                acMessageBox.Show(this, ex);
            }

        }

        void QuickSSearch(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
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
                    "STD41A_SER4", paramSet, "RQSTDT", "RSLTDT",
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

        private void gvB_MouseDown(object sender, MouseEventArgs e)
        {
            acGridView view = sender as acGridView;

            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                GridHitInfo hitInfo = view.CalcHitInfo(e.Location);

                if (hitInfo.HitTest == GridHitTest.RowCell || hitInfo.HitTest == GridHitTest.Row)
                {
                    //대일정 편집기 열기

                    this.acBarButtonItem2_ItemClick(null, null);
                }

            }
        }

        void gvM_MouseDown(object sender, MouseEventArgs e)
        {
            acGridView view = sender as acGridView;

            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                GridHitInfo hitInfo = view.CalcHitInfo(e.Location);

                if (hitInfo.HitTest == GridHitTest.RowCell || hitInfo.HitTest == GridHitTest.Row)
                {
                    //중일정 편집기 열기

                    this.acBarButtonItem5_ItemClick(null, null);
                }

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
                this.Search();

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }




        private void acBarButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //대일정 편집기 새로만들기
            try
            {
                if (!base.ChildFormContains("NEW_B"))
                {

                    STD41A_D0A_B frm = new STD41A_D0A_B(gvB, null);

                    frm.DialogMode = BaseMenuDialog.emDialogMode.NEW;

                    frm.ParentControl = this;

                    base.ChildFormAdd("NEW_B", frm);

                    frm.Show(this);
                }
                else
                {
                    base.ChildFormFocus("NEW_B");

                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }


        }




        private void acBarButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //대일정 편집기 열기
            try
            {
                DataRow focusRow = gvB.GetFocusedDataRow();

                string formKey = string.Format("{0},{1}", "B", focusRow["PRG_CODE"]);

                if (!base.ChildFormContains(formKey))
                {

                    STD41A_D0A_B frm = new STD41A_D0A_B(gvB, focusRow);

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


        private void acBarButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //대일정 삭제
            try
            {
                gvB.EndEditor();

                ParameterYesNoDialogResult msgResult = acMessageBox.ShowParameterYesNo(this, "정말 삭제하시겠습니까?", "TB43FSY3", true, acInfo.Resource.GetString("삭제사유", "A9DY9R6G"));


                if (msgResult.DialogResult == DialogResult.No)
                {
                    return;
                }

                DataRow focuseRow = gvB.GetFocusedDataRow();


                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //사업장 코드
                paramTable.Columns.Add("PRG_CODE", typeof(String)); //
                paramTable.Columns.Add("DEL_EMP", typeof(String)); //
                paramTable.Columns.Add("DEL_REASON", typeof(String)); //

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
                "STD41A_DEL", paramSet, "RQSTDT", "",
                QuickBigDEL,
                QuickException);

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }


        }
        void QuickBigDEL(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                foreach (DataRow row in e.result.Tables["RQSTDT"].Rows)
                {
                    gvB.DeleteMappingRow(row);


                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        private void acBarButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //새로 만들기 중일정편집기
            try
            {
                if (!base.ChildFormContains("NEW_M"))
                {

                    STD41A_D0A_M frm = new STD41A_D0A_M(gvB, gvB.GetFocusedDataRow(), gvM, null);

                    frm.DialogMode = BaseMenuDialog.emDialogMode.NEW;

                    frm.ParentControl = this;

                    base.ChildFormAdd("NEW_M", frm);

                    frm.Show(this);
                }
                else
                {
                    base.ChildFormFocus("NEW_M");

                }

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }



        }

        private void acBarButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //중일정 편집기 열기
            try
            {

                DataRow focusRow = gvM.GetFocusedDataRow();


                string formKey = string.Format("{0},{1}", "M", focusRow["PRG_CODE"]);

                if (!base.ChildFormContains(formKey))
                {

                    STD41A_D0A_M frm = new STD41A_D0A_M(gvB, gvB.GetFocusedDataRow(), gvM, focusRow);

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

        private void acBarButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //중일정 삭제

            try
            {
                gvM.EndEditor();


                ParameterYesNoDialogResult msgResult = acMessageBox.ShowParameterYesNo(this, "정말 삭제하시겠습니까?", "TB43FSY3", true, acInfo.Resource.GetString("삭제사유", "A9DY9R6G"));


                if (msgResult.DialogResult == DialogResult.No)
                {
                    return;
                }

                DataView selected = gvM.GetDataSourceView("SEL = '1'");

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //사업장 코드
                paramTable.Columns.Add("PRG_CODE", typeof(String)); //
                paramTable.Columns.Add("DEL_EMP", typeof(String)); //

                if (selected.Count == 0)
                {
                    //단일선택
                    DataRow focuseRow = gvM.GetFocusedDataRow();

                    DataRow paramRow = paramTable.NewRow();
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["PRG_CODE"] = focuseRow["PRG_CODE"];
                    paramRow["DEL_EMP"] = acInfo.UserID;
                    paramTable.Rows.Add(paramRow);

                }
                else
                {
                    //다중선택

                    for (int i = 0; i < selected.Count; i++)
                    {

                        DataRow paramRow = paramTable.NewRow();
                        paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                        paramRow["PRG_CODE"] = selected[i]["PRG_CODE"];
                        paramRow["DEL_EMP"] = acInfo.UserID;
                        paramTable.Rows.Add(paramRow);
                    }

                }


                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.DEL,
                "STD41A_DEL2", paramSet, "RQSTDT", "",
                QuickMiddleDEL,
                QuickException);

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }


        }

        void QuickMiddleDEL(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                foreach (DataRow row in e.result.Tables["RQSTDT"].Rows)
                {
                    gvM.DeleteMappingRow(row);
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

                if (!base.ChildFormContains("NEW_S"))
                {

                    STD41A_D0A_S frm = new STD41A_D0A_S(gvB, gvB.GetFocusedDataRow(), gvM, gvM.GetFocusedDataRow(), gvS, new object[] { null, null });

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

                    STD41A_D0A_S frm = new STD41A_D0A_S(gvB, gvB.GetFocusedDataRow(), gvM, gvM.GetFocusedDataRow(), gvS, new object[] { focusRow, gvMC.GridControl.DataSource });

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
                "STD41A_DEL3", paramSet, "RQSTDT", "",
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



        private void acBarButtonItem10_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //중일정 이동

            try
            {
                gvM.EndEditor();

                if (gvM.ValidFocusRowHandle() == false)
                {
                    return;
                }

                acPlanInstantResult result = acPlan.ShowInstantForm(this, acPlan.emShowPlanType.L, e.Item.Caption, null);

                if (result.DialogResult == DialogResult.OK)
                {

                    DataRow frmRow = result.OutputData as DataRow;

                    DataView selected = gvM.GetDataSourceView("SEL = '1'");

                    DataTable paramTable = new DataTable("RQSTDT");
                    paramTable.Columns.Add("UP_CLASS", typeof(String)); //
                    paramTable.Columns.Add("REG_EMP", typeof(String)); //
                    paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                    paramTable.Columns.Add("PRG_CODE", typeof(String)); //

                    if (selected.Count == 0)
                    {
                        //단일선택
                        DataRow focuseRow = gvM.GetFocusedDataRow();

                        DataRow paramRow = paramTable.NewRow();
                        paramRow["UP_CLASS"] = frmRow["PRG_CODE"];
                        paramRow["REG_EMP"] = acInfo.UserID;
                        paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                        paramRow["PRG_CODE"] = focuseRow["PRG_CODE"];
                        paramTable.Rows.Add(paramRow);


                    }
                    else
                    {
                        //다중선택

                        for (int i = 0; i < selected.Count; i++)
                        {

                            DataRow paramRow = paramTable.NewRow();
                            paramRow["UP_CLASS"] = frmRow["PRG_CODE"];
                            paramRow["REG_EMP"] = acInfo.UserID;
                            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                            paramRow["PRG_CODE"] = selected[i]["PRG_CODE"];
                            paramTable.Rows.Add(paramRow);
                        }

                    }


                    DataSet paramSet = new DataSet();
                    paramSet.Tables.Add(paramTable);

                    BizRun.QBizRun.ExecuteService(
                    this, QBiz.emExecuteType.PROCESS,
                    "STD41A_UPD", paramSet, "RQSTDT", "",
                    QuickMiddleUPD,
                    QuickException);

                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }


        }
        void QuickMiddleUPD(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
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


                acPlanInstantResult result = acPlan.ShowInstantForm(this, acPlan.emShowPlanType.M, e.Item.Caption, null);


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
                    "STD41A_UPD2", paramSet, "RQSTDT", "",
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

                STD41A_D0A_S2 frm = new STD41A_D0A_S2();

                frm.ParentControl = this;

                frm.Text = item.Caption;

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    this.Search();
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

