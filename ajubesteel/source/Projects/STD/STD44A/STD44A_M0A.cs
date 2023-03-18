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

namespace STD
{
    public sealed partial class STD44A_M0A : BaseMenu
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

        public STD44A_M0A()
        {

            InitializeComponent();
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

            // acGridView1.GridType = acGridView.emGridType.AUTO_COL;

            acGridView1.GridType = acGridView.emGridType.SEARCH;
            
           //  acGridView1.AddCheckEdit("SEL", "선택", "40290", true, true, true, acGridView.emCheckEditDataType._STRING);

            acGridView1.AddTextEdit("MC_CODE", "설비코드", "41162", true , DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("MC_NAME", "설비명", "41202", true , DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddLookUpEdit("MC_GROUP", "설비그룹", "40308", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "C020");

            acGridView1.AddTextEdit("MC_MODEL", "실모델명", "40400", true , DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            //acGridView1.AddCheckEdit("MC_AUTOMATED", "무인가공", "40973", true , false, true, acGridView.emCheckEditDataType._BYTE);

            //acGridView1.AddCheckEdit("MC_OS", "외부설비", "40974", true , false, true, acGridView.emCheckEditDataType._BYTE);

            //acGridView1.AddCheckEdit("MC_MGT_FLAG", "부하 관리대상", "40065", true, false, false, acGridView.emCheckEditDataType._BYTE);

            acGridView1.AddCheckEdit("IS_OPERATE_STATE", "가동현황표시", "SR3IF2SN", true, false, false, acGridView.emCheckEditDataType._BYTE);

            //acGridView1.AddCheckEdit("IS_MULTI_START", "다중작업지시 동시진행", "MQBVM2AJ", true, false, false, acGridView.emCheckEditDataType._BYTE);

            //acGridView1.AddCheckEdit("MULTI_START_DIV", "다중작업지시 동시진행시 실적분할", "HTHN5WFV", true, false, false, acGridView.emCheckEditDataType._BYTE);

            acGridView1.AddDateEdit("MC_OPEN_DATE", "유효시작일", "40477", true , DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);

            acGridView1.AddDateEdit("MC_CLOSE_DATE", "유효종료일", "40478", true , DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);

            //acGridView1.AddTextEdit("CPROC_CODE", "임률코드", "0BXLGNK0", true , DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            //acGridView1.AddTextEdit("CPROC_NAME", "임률명", "PQB42PSL", true , DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("MC_SEQ", "표시순서", "40723", true, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("MAIN_EMP", "담당자코드", "42388", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("MAIN_EMP_NAME", "담당자", "40127", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("VEN_CODE", "거래처 코드", "40957", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("VEN_NAME", "거래처명", "40956", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            //acGridView1.AddCheckEdit("IS_SIGNAL", "신호취득여부", "V4OOUWJC", true , false, true, acGridView.emCheckEditDataType._BYTE);

            //acGridView1.AddLookUpEdit("SIGNAL_TYPE", "신호취득형태", "V919GCY1", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "C022");

            //acGridView1.AddTextEdit("PLC_IP", "신호취득용IP", "42557", true , DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            //acGridView1.AddTextEdit("PLC_PORT", "신호취득용 포트", "DDTXOCL0", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            //acGridView1.AddTextEdit("MC_IP", "설비IP", "42556", true , DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.IP);

            //acGridView1.AddTextEdit("FTP_PORT", "FTP 포트", "881W45YM", true , DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            //acGridView1.AddTextEdit("FTP_DIR", "FTP 디렉토리", "EU47YV71", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            //acGridView1.AddTextEdit("FTP_USER", "FTP 계정", "X688UUTM", true , DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);


            acGridView1.AddTextEdit("SCOMMENT", "비고", "ARYZ726K", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("IF_MC_CODE", "IF 코드", "K8GKZPXM", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            
            acGridView1.AddDateEdit("REG_DATE", "최초 등록일", "UL1O77MB", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.LONG_DATE);

            acGridView1.AddTextEdit("REG_EMP", "최초 등록자코드", "P72K0SQJ", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("REG_EMP_NAME", "최초 등록자", "GPQHG8QQ", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddDateEdit("MDFY_DATE", "최근 수정일", "6RXQO0B2", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.LONG_DATE);

            acGridView1.AddTextEdit("MDFY_EMP", "최근 수정자코드", "WDHSCE72", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("MDFY_EMP_NAME", "최근 수정자", "FHJDO4F0", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddPictrue("MC_IMAGE", "설비 이미지", "E9NYS432", true, DevExpress.Utils.HorzAlignment.Near, false, false);

            acGridView1.KeyColumn = new string[] { "MC_CODE" };


            // acGridView2.GridType = acGridView.emGridType.SEARCH_SEL;

            acGridView2.GridType = acGridView.emGridType.SEARCH;

            //acGridView2.AddCheckEdit("SEL", "선택", "40290", true, true, true, acGridView.emCheckEditDataType._STRING);

            acGridView2.AddTextEdit("INS_SEQ", "순위", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView2.AddLookUpEdit("INS_INTERVAL", "점검주기", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "S091");

            acGridView2.AddLookUpEdit("INS_ITEM", "점검항목", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "S092");

            acGridView2.AddMemoEdit("INS_METHOD", "점검방법", "", false, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, false, true, true, false);

            acGridView2.AddTextEdit("INS_SPEC", "검사 SPEC", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView2.AddTextEdit("INS_ACTION", "조치사항", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView2.AddHidden("MC_INS_CODE", typeof(String));

            acGridView2.AddHidden("MC_CODE", typeof(String));

            // acGridView2.OptionsView.ShowIndicator = true;

            acGridView2.KeyColumn = new string[] { "MC_INS_CODE" };


            //이벤트 설정

            acGridView2.MouseDown += new MouseEventHandler(acGridView2_MouseDown);

            //acGridView1.OnMapingRowChanged += new acGridView.MapingRowChangedEventHandler(acGridView1_OnMapingRowChanged);

            acGridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(acGridView1_FocusedRowChanged);

            acGridView2.ShowGridMenuEx += new acGridView.ShowGridMenuExHandler(acGridView2_ShowGridMenuEx);    

            acLayoutControl1.OnValueKeyDown+=new acLayoutControl.ValueKeyDownEventHandler(acLayoutControl1_OnValueKeyDown);

            base.MenuInit();
        }


        void acGridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            this.GetDetail();
        }



        void GetDetail()
        {
            try
            {
                if (acGridView1.ValidFocusRowHandle() == true)
                {
                    DataRow focusRow = acGridView1.GetFocusedDataRow();

                    DataTable paramTable = new DataTable("RQSTDT");
                    paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                    paramTable.Columns.Add("MC_CODE", typeof(String)); //

                    DataRow paramRow = paramTable.NewRow();
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["MC_CODE"] = focusRow["MC_CODE"];
                    paramTable.Rows.Add(paramRow);
                    DataSet paramSet = new DataSet();
                    paramSet.Tables.Add(paramTable);

                    BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD, "STD44A_SER2", paramSet, "RQSTDT", "RSLTDT",
                                    QuickDetail,
                                    QuickException);
                }
                else
                {
                    acGridView2.ClearRow();
                }

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }


        void QuickDetail(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
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


        void acGridView2_ShowGridMenuEx(object sender, PopupMenuShowingEventArgs e)
        {

            if (acGridView1.FocusedRowHandle < 0)
            {
                return;
            }

            acGridView view = sender as acGridView;

            if (e.HitInfo.HitTest == GridHitTest.EmptyRow || e.HitInfo.HitTest == GridHitTest.Row || e.HitInfo.HitTest == GridHitTest.RowCell)
            {




                if (e.MenuType == GridMenuType.User)
                {
                    acBarButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    acBarButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;


                }
                else if (e.MenuType == GridMenuType.Row)
                {
                    if (e.HitInfo.RowHandle >= 0)
                    {

                        acBarButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        acBarButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    }
                    else
                    {
                        acBarButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        acBarButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    }

                }


                //팝업메뉴 열기

                GridHitInfo hitInfo = view.CalcHitInfo(e.Point);

                popupMenu1.ShowPopup(view.GridControl.PointToScreen(e.Point));


            }
        }

        void acLayoutControl1_OnValueKeyDown(object sender, IBaseEditControl info, KeyEventArgs e)
        {

            if (e.KeyData == Keys.Enter)
            {

                this.Search();

            }

        }

        void acGridView1_OnMapingRowChanged(acGridView.emMappingRowChangedType type, DataRow row)
        {
           
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

            DataRow layoutRow = acLayoutControl1.CreateParameterRow();

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String));
            paramTable.Columns.Add("MC_LIKE", typeof(String));
            paramTable.Columns.Add("MC_MODEL_LIKE", typeof(String));


            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["MC_LIKE"] = layoutRow["MC_LIKE"];
            paramRow["MC_MODEL_LIKE"] = layoutRow["MC_MODEL_LIKE"];

            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);


            BizRun.QBizRun.ExecuteService(
            this, QBiz.emExecuteType.LOAD,
            "STD04A_SER", paramSet, "RQSTDT", "RSLTDT",
            QuickSearch,
            QuickException);
        }



        void QuickSearch(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                acGridView1.GridControl.DataSource = e.result.Tables["RSLTDT"];
                
                acGridView1.BestFitColumns();

                acGridView1.SetOldFocusRowHandle(false);

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



        void QuickDel(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {

                foreach (DataRow row in e.result.Tables["RQSTDT"].Rows)
                {
                    acGridView2.DeleteMappingRow(row);

                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
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


        private void acBarButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //새로만들기 

            try
            {
                DataRow focused = acGridView1.GetFocusedDataRow();

                if (!base.ChildFormContains("NEW"))
                {
                    STD44A_D0A frm = new STD44A_D0A(acGridView2, focused);

                    frm.ParentControl = this;

                    frm.DialogMode = BaseMenuDialog.emDialogMode.NEW;


                    base.ChildFormAdd("NEW", frm);

                    frm.Show(this);

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

        private void acBarButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //열기
            try
            {

                DataRow focusRow = acGridView2.GetFocusedDataRow();

                if (focusRow == null)
                {
                    return;
                }


                if (!base.ChildFormContains(focusRow["MC_INS_CODE"]))
                {

                    STD44A_D0A frm = new STD44A_D0A(acGridView2, focusRow);

                    frm.ParentControl = this;

                    frm.DialogMode = BaseMenuDialog.emDialogMode.OPEN;

                    base.ChildFormAdd(focusRow["MC_INS_CODE"], frm);


                    frm.Show(this);
                }
                else
                {
                    base.ChildFormFocus(focusRow["MC_INS_CODE"]);
                }

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void acBarButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //삭제
            try
            {

                acGridView2.EndEditor();

                if (acMessageBox.Show(this, "정말 삭제하시겠습니까?", "TB43FSY3", true, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
                {
                    return;
                }

                DataRow[] selected = acGridView2.GetSelectedDataRows();


                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("DEL_EMP", typeof(String)); //
                paramTable.Columns.Add("MC_INS_CODE", typeof(String)); //
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //사업장 코드


                if (selected.Length == 0)
                {
                    //단일삭제

                    DataRow focusRow = acGridView2.GetFocusedDataRow();

                    DataRow paramRow = paramTable.NewRow();
                    paramRow["DEL_EMP"] = acInfo.UserID;
                    paramRow["MC_INS_CODE"] = focusRow["MC_INS_CODE"];
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                

                    paramTable.Rows.Add(paramRow);


                }
                else
                {
                    //다중 삭제
                    for (int i = 0; i < selected.Length; i++)
                    {
                        DataRow paramRow = paramTable.NewRow();
                        paramRow["DEL_EMP"] = acInfo.UserID;
                        paramRow["MC_INS_CODE"] = selected[i]["MC_INS_CODE"];
                        paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                      
                        paramTable.Rows.Add(paramRow);
                    }


                }


                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.PROCESS,
                "STD44A_DEL", paramSet, "RQSTDT", "",
                QuickDel,
                QuickException);

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }


        }


        void acGridView2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                GridHitInfo hitInfo = acGridView2.CalcHitInfo(e.Location);

                if (hitInfo.HitTest == GridHitTest.RowCell || hitInfo.HitTest == GridHitTest.Row)
                {
                    //점검항목 편집기 열기

                    this.acBarButtonItem1_ItemClick(null, null);
                }

            }
        }
    }
}

