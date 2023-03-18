using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using ControlManager;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Grid;
using BizManager;

namespace ORD
{
    public sealed partial class ORD30B_M0A : BaseMenu
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

        public ORD30B_M0A()
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

       
        private DataTable _dtProcList = null;

        private acGridView acGridView2detail = null;

        public override void MenuInit()
        {

            #region 출하
            //업체 리스트

            acGridView1.GridType = acGridView.emGridType.AUTO_COL;

            //acGridView1.AddCheckEdit("SEL", "선택", "40290", true, true, false, acGridView.emCheckEditDataType._STRING);
            acGridView1.AddTextEdit("VEN_CODE", "업체코드", "", false, DevExpress.Utils.HorzAlignment.Near, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("VEN_NAME", "수주처", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("WORK_CNT", "작업", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.KeyColumn = new string[] { "VEN_CODE" };

            acGridView1.OptionsCustomization.AllowSort = false;

            //수주정보
            acGridView2.GridType = acGridView.emGridType.SEARCH;
            acGridView2.AddTextEdit("CVND_CODE", "수주처코드", "FYVPQ9JZ", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("CVND_NAME", "수주처명", "42428", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("ITEM_CODE", "수주코드", "40377", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddDateEdit("ORD_DATE", "수주일", "40902", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
            acGridView2.AddDateEdit("DUE_DATE", "납기일", "40111", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
            acGridView2.AddDateEdit("SALECONFM_DATE", "매출 확정일", "50295", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
            acGridView2.AddTextEdit("BUSINESS_EMP", "등록인 코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("BUSINESS_EMP_NAME", "등록인", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("MOBILE_PHONE", "전화번호", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView2.AddTextEdit("CHARGE_EMP", "담당자", "40127", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("CHARGE_DEPT", "담당부서", "40126", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("CHARGE_TEL", "담당자", "40128", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("CHARGE_HP", "전화번호", "40129", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("CHARGE_EMAIL", "40790", "WCO6Q0OP", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("VEN_FAX", "팩스", "40713", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("CHARGE_SCOMMENT", "담당자 비고", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            //acGridView2.AddTextEdit("VEN_CHARGE_EMP", "담당자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            //acGridView2.AddTextEdit("VEN_CHARGE_HP", "전화번호", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            //acGridView2.AddTextEdit("VEN_FAX", "팩스", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            
            acGridView2.AddTextEdit("ORD_QTY", "수량", "40345", true, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView2.AddTextEdit("PROD_COST", "수주가", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);

            acGridView2.AddTextEdit("ORD_AMT", "수주가", "40958", true, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
            acGridView2.AddCheckEdit("ORD_VAT", "VAT포함", "", false, false, true, acGridView.emCheckEditDataType._STRING);
            acGridView2.AddTextEdit("SCOMMENT", "비고", "ARYZ726K", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddDateEdit("REG_DATE", "최초 등록일", "UL1O77MB", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emDateMask.LONG_DATE);
            acGridView2.AddTextEdit("REG_EMP", "최초 등록자코드", "P72K0SQJ", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("REG_EMP_NAME", "최초 등록자", "GPQHG8QQ", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddDateEdit("MDFY_DATE", "최근 수정일", "6RXQO0B2", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emDateMask.LONG_DATE);
            acGridView2.AddTextEdit("MDFY_EMP", "최근 수정자코드", "WDHSCE72", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("MDFY_EMP_NAME", "최근 수정자", "FHJDO4F0", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);

            acGridView2.KeyColumn = new string[] { "ITEM_CODE" };

            acGridView2.OptionsDetail.ShowDetailTabs = false;

            acGridView2detail = new acGridView(acGridView2.GridControl);

            acGridView2detail.GridType = acGridView.emGridType.AUTO_COL;

            acGridView2detail.OptionsView.ShowIndicator = true;

            acGridView2detail.AddHidden("ITEM_CODE", typeof(String));

            acGridView2detail.AddTextEdit("PROD_CODE", "금형코드", "40900", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView2detail.AddTextEdit("PART_CODE", "부품코드", "40239", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView2detail.AddTextEdit("DRAW_NO", "도면번호", "40145", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView2detail.AddTextEdit("PART_NAME", "부품명", "40234", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView2detail.AddTextEdit("MAT_SPEC1", "제품규격", "42545", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

            //acGridView2detail.AddTextEdit("MAT_SPEC", "소재규격", "42544", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView2detail.AddTextEdit("PROD_QTY", "수량", "40345", true, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);

            acGridView2detail.AddTextEdit("SHIP_QTY", "출하 수량", "ORP744BN", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);

            //acGridView2detail.AddLookUpEdit("MAT_UNIT", "단위", "40123", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M003");

           

            acGridView2detail.AddTextEdit("PROD_UC", "단가", "40121", true, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);

            acGridView2detail.AddTextEdit("PROD_COST", "제품가", "42568", true, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);

            acGridView2detail.AddTextEdit("PROD_VAT", "부가세", "JZKPAJUA", true, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);

            acGridView2detail.AddTextEdit("PROD_AMT", "공급가", "40958", true, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);

            //acGridView2detail.AddTextEdit("PROD_VAT", "부가세", "JZKPAJUA", true, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);

            acGridView2detail.KeyColumn = new string[] { "PROD_CODE" };

            //acGridView2detail.OptionsView.ShowColumnHeaders = false;

            acGridView2.GridControl.LevelTree.Nodes.Add("M", acGridView2detail);

            acGridView2detail.GotFocus += new EventHandler(acGridView2detail_GotFocus);
            acGridView2detail.FocusedRowChanged += acGridView2detail_FocusedRowChanged;


            //품목정보
            acGridView3.GridType = acGridView.emGridType.SEARCH;
            acGridView3.AddCheckEdit("SEL", "선택", "40290", true, true, true, acGridView.emCheckEditDataType._STRING);
            acGridView3.AddTextEdit("ACTUAL_ID", "작업실적번호", "ZU7TGN7X", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView3.AddTextEdit("WO_NO", "작업지시번호", "40556", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            //acGridView3.AddTextEdit("STK_ID", "재고ID", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);

            acGridView3.AddTextEdit("CVND_CODE", "수주처코드", "FYVPQ9JZ", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView3.AddTextEdit("CVND_NAME", "수주처명", "42428", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView3.AddTextEdit("ITEM_CODE", "수주코드", "40377", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView3.AddTextEdit("PROD_CODE", "제품코드", "40900", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView3.AddTextEdit("PART_CODE", "부품코드", "40239", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView3.AddTextEdit("PART_NAME", "부품명", "40234", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView3.AddTextEdit("DRAW_NO", "도면번호", "40145", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView3.AddTextEdit("MAT_SPEC1", "규격", "42545", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView3.AddTextEdit("MAT_SPEC", "규격", "42544", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView3.AddTextEdit("PROC_CODE", "공정코드", "40920", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView3.AddTextEdit("PROC_NAME", "공정명", "40921", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView3.AddTextEdit("EMP_CODE", "작업자코드", "40551", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView3.AddTextEdit("EMP_NAME", "작업자", "40542", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView3.AddLookUpEdit("STOCK_CODE", "창고", "NO1T1YEG", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M005");
            acGridView3.AddLookUpEdit("STOCK_TYPE", "재고구분", "F6Z0JHP5", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M013");
            acGridView3.AddTextEdit("PART_QTY", "생산량", "RREEL82Q", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.QTY);

            acGridView3.AddTextEdit("PROD_UC", "단가", "40121", true, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);

            acGridView3.AddTextEdit("PROD_AMT", "제품가", "42568", true, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);

            acGridView3.AddLookUpEdit("DELIVERY", "택배/직납", "", false, DevExpress.Utils.HorzAlignment.Center, true, true, true, "D002");

            acGridView3.KeyColumn = new string[] { "ACTUAL_ID", "WO_NO" };


            (acLayoutControl4.GetEditor("ITEM_AUTO_CODE").Editor as acLookupEdit).SetCode("D001");

            //이벤트 설정

            acGridView1.CustomDrawCell += acGridView1_CustomDrawCell;
            acGridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(acGridView1_FocusedRowChanged);

            acGridView2.CustomDrawCell += acGridView2_CustomDrawCell;
       
            #endregion

            #region 출하 취소

            //수주정보
            acGridView4.GridType = acGridView.emGridType.SEARCH;
            acGridView4.AddCheckEdit("SEL", "선택", "40290", true, true, true, acGridView.emCheckEditDataType._STRING);
            acGridView4.AddTextEdit("SEQ", "표시순서", "", false, DevExpress.Utils.HorzAlignment.Center, true, true, false, acGridView.emTextEditMask.NONE);

            acGridView4.AddTextEdit("SHIP_ID", "출하ID", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView4.AddDateEdit("SHIP_DATE", "출하일", "42362", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
            acGridView4.AddTextEdit("SHIP_EMP", "출하 담당자", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView4.AddTextEdit("SHIP_EMP_NAME", "출하 담당자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView4.AddTextEdit("SCOMMENT", "출하비고", "1ITYML4N", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView4.AddTextEdit("CVND_CODE", "수주처코드", "FYVPQ9JZ", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView4.AddTextEdit("CVND_NAME", "수주처명", "42428", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView4.AddTextEdit("ITEM_CODE", "수주코드", "40377", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView4.AddTextEdit("ITEM_NAME", "수주명", "41906", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView4.AddDateEdit("ORD_DATE", "수주일", "42362", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
            acGridView4.AddTextEdit("PROD_CODE", "금형코드", "40900", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);

            acGridView4.AddLookUpEdit("MAT_TYPE", "자재형태", "N05MMEKM", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "S016");

            acGridView4.AddTextEdit("PART_CODE", "부품코드", "40239", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView4.AddTextEdit("PART_NAME", "부품명", "40234", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView4.AddTextEdit("DRAW_NO", "도면번호", "40145", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView4.AddTextEdit("MAT_SPEC", "소재사양", "42544", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView4.AddTextEdit("MAT_SPEC1", "완성사양", "42545", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView4.AddTextEdit("PART_QTY", "생산 수량", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView4.AddTextEdit("SHIP_QTY", "출하 수량", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView4.AddLookUpEdit("DELIVERY", "택배/직납", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, true, "D002");

            acGridView4.AddLookUpEdit("MAT_UNIT", "단위", "40123", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M003");

            acGridView4.AddTextEdit("BALJU_NUM", "발주번호", "40203", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView4.AddTextEdit("ITEM_SCOMMENT", "수주비고", "U3QX515T", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView4.KeyColumn = new string[] { "SHIP_ID" };
            //acGridView4.OptionsView.ColumnAutoWidth = true;
            acGridView4.OptionsSelection.MultiSelect = true;

            #endregion

            
            acGridView3.ShowGridMenuEx += new acGridView.ShowGridMenuExHandler(acGridView3_ShowGridMenuEx);
            acGridView4.ShowGridMenuEx += new acGridView.ShowGridMenuExHandler(acGridView4_ShowGridMenuEx);

            acGridView2.FocusedRowChanged += acGridView2_FocusedRowChanged;

            acLayoutControl1.OnValueKeyDown += new acLayoutControl.ValueKeyDownEventHandler(acLayoutControl1_OnValueKeyDown);
            acCheckedComboBoxEdit1.AddItem("수주일", true, "40902", "ORD_DATE", true, false);
            acCheckedComboBoxEdit1.AddItem("납기일", true, "40111", "DUE_DATE", true, false);
            this.acLayoutControl1.OnValueChanged += new acLayoutControl.ValueChangedEventHandler(acLayoutControl1_OnValueChanged);

            acLayoutControlGroup5.Expanded = false;

            btnCancel.Enabled = false;

            base.MenuInit();

        }

        void acGridView2detail_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            GridView childView = sender as GridView;

            DataRow focus = childView.GetFocusedDataRow();
            if (focus != null)
            {
                GetDetail(focus, false);
            }
            else
            {
                acGridView3.ClearRow();
            }
        }

        void acGridView2detail_GotFocus(object sender, EventArgs e)
        {
            GridView childView = sender as GridView;

            GridView masterView = childView.ParentView as GridView;

            if (masterView.FocusedRowHandle != childView.SourceRowHandle)
            {
                masterView.FocusedRowHandle = childView.SourceRowHandle;
            }
        }

        void acGridView2_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.RowHandle == 0)
            {
                e.Appearance.BackColor = Color.LightGray;
            }
        }

        void acGridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.RowHandle == 0)
            {
                e.Appearance.BackColor = Color.LightGray;
            }
        }

       
        void acGridView2_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow focus = acGridView2.GetFocusedDataRow();
            if (focus != null)
            {
                GetDetail(focus,true);
            }
            else
            {
                acGridView3.ClearRow();
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

                layout.GetEditor("DATE").Value = "ORD_DATE";
                layout.GetEditor("S_DATE").Value = acDateEdit.GetNowFirstDate();
                layout.GetEditor("E_DATE").Value = DateTime.Now;


            }


            base.ChildContainerInit(sender);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            //this.Search();
        }

        void acLayoutControl1_OnValueKeyDown(object sender, IBaseEditControl info, KeyEventArgs e)
        {

            if (e.KeyData == Keys.Enter)
            {

                this.Search();

            }

        }

        void acGridView3_ShowGridMenuEx(object sender, PopupMenuShowingEventArgs e)
        {
            acGridView view = sender as acGridView;

            if (view.RowCount == 0) return;

            if (e.HitInfo.HitTest == GridHitTest.EmptyRow || e.HitInfo.HitTest == GridHitTest.Row || e.HitInfo.HitTest == GridHitTest.RowCell)
            {
                GridHitInfo hitInfo = view.CalcHitInfo(e.Point);

                acBarButtonItem4.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                acBarButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                popupMenu1.ShowPopup(view.GridControl.PointToScreen(e.Point));


            }
        }

        void acGridView4_ShowGridMenuEx(object sender, PopupMenuShowingEventArgs e)
        {
            acGridView view = sender as acGridView;

            if (e.HitInfo.HitTest == GridHitTest.EmptyRow || e.HitInfo.HitTest == GridHitTest.Row || e.HitInfo.HitTest == GridHitTest.RowCell)
            {
                GridHitInfo hitInfo = view.CalcHitInfo(e.Point);

                acBarButtonItem4.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                acBarButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

                popupMenu2.ShowPopup(view.GridControl.PointToScreen(e.Point));


            }
        }

        public override void MenuInitComplete()
        {
   
            base.MenuInitComplete();
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

            return base.MenuDestory(sender);

        }


        void GetDetail_VEN()
        {
            if (acGridView1.ValidFocusRowHandle() == true)
            {
                DataRow layoutRow = acLayoutControl1.CreateParameterRow();

                DataRow focusRow = acGridView1.GetFocusedDataRow();

                if (focusRow != null)
                {
                    DataTable paramTable = new DataTable("RQSTDT");
                    paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                    paramTable.Columns.Add("VEN_CODE", typeof(String)); //
                    paramTable.Columns.Add("S_DUE_DATE", typeof(String)); //
                    paramTable.Columns.Add("E_DUE_DATE", typeof(String)); //


                    DataRow paramRow = paramTable.NewRow();
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["VEN_CODE"] = focusRow["VEN_CODE"];

                    foreach (string key in acCheckedComboBoxEdit1.GetKeyChecked())
                    {
                        switch (key)
                        {
                            case "DUE_DATE":
                                //납기일

                                paramRow["S_DUE_DATE"] = layoutRow["S_DATE"];
                                paramRow["E_DUE_DATE"] = layoutRow["E_DATE"];
                                break;
                        }
                    }

                    paramTable.Rows.Add(paramRow);

                    DataSet paramSet = new DataSet();
                    paramSet.Tables.Add(paramTable);

                    BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD_DETAIL,
                    "STD05A_SER", paramSet, "RQSTDT", "RSLTDT",
                    QuickDetail_VEN,
                    QuickException);
                }

            }
            else
            {
                acLayoutControl4.ClearValue();
            }
        }

        void GetDetail_ORD()
        {
            if (acGridView1.ValidFocusRowHandle() == true)
            {
                DataRow focusRow = acGridView1.GetFocusedDataRow();

                if (focusRow != null)
                {
                    DataTable paramTable = new DataTable("RQSTDT");
                    paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                    paramTable.Columns.Add("CVND_CODE", typeof(String)); //
                    paramTable.Columns.Add("S_ORD_DATE", typeof(String)); //
                    paramTable.Columns.Add("E_ORD_DATE", typeof(String)); //
                    paramTable.Columns.Add("S_DUE_DATE", typeof(String)); //
                    paramTable.Columns.Add("E_DUE_DATE", typeof(String)); //


                    DataRow paramRow = paramTable.NewRow();
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["CVND_CODE"] = focusRow["VEN_CODE"];
                    if (_strS_ORD_DATE != "") paramRow["S_ORD_DATE"] = _strS_ORD_DATE;
                    if (_strE_ORD_DATE != "") paramRow["E_ORD_DATE"] = _strE_ORD_DATE;
                    if (_strS_DUE_DATE != "") paramRow["S_DUE_DATE"] = _strS_DUE_DATE;
                    if (_strE_DUE_DATE != "") paramRow["E_DUE_DATE"] = _strE_DUE_DATE;

                    paramTable.Rows.Add(paramRow);

                    DataSet paramSet = new DataSet();
                    paramSet.Tables.Add(paramTable);

                    BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD_DETAIL,
                    "ORD30B_SER2", paramSet, "RQSTDT", "RSLTDT,RSLTDT_PROD",
                    QuickDetail_ORD,
                    QuickException);
                }

            }
            else
            {
                acGridView2.ClearRow();
                acGridView2.GridControl.Enabled = false;
            }
        }

   

        void acGridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            //거래처

            this.GetDetail_VEN();

            //수주정보
            this.GetDetail_ORD();

        }

        void QuickDetail_VEN(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                acLayoutControl4.ClearValue();
                acLayoutControl4.DataBind(e.result.Tables["RSLTDT"].Rows[0], false);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        private DataTable contentsDt = null;

        void QuickDetail_ORD(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                DataRow dr = e.result.Tables["RSLTDT"].NewRow();
                dr["CVND_CODE"] = "전체 ";
                dr["ITEM_CODE"] = "ALL";
                //dr["WORK_CNT"] = e.result.Tables["RSLTDT_HEAD"].Rows[0]["WORK_SUM"];

                e.result.Tables["RSLTDT"].Rows.InsertAt(dr, 0);

                DataTable titleDt = e.result.Tables["RSLTDT"].Copy();
                contentsDt = e.result.Tables["RSLTDT_PROD"].Copy();

                contentsDt.TableName = "D";

                DataSet plans = new DataSet();

                plans.Tables.Add(titleDt);
                plans.Tables.Add(contentsDt);

                DataColumn keyColumn = titleDt.Columns["ITEM_CODE"];
                DataColumn foreignKeyColumn = contentsDt.Columns["ITEM_CODE"];

                plans.Relations.Add("M", keyColumn, foreignKeyColumn);

                acGridView2.GridControl.Enabled = true;

                acGridView2.GridControl.DataSource = plans.Tables[0];
                acGridView2.RaiseFocusedRowChanged();
                acGridView2detail.BestFitColumns();
                ////CVND_CODE
                //DataRow dr = e.result.Tables["RSLTDT"].NewRow();
                //dr["CVND_CODE"] = "전체 " ;
                //dr["ITEM_CODE"] = "ALL";
                ////dr["WORK_CNT"] = e.result.Tables["RSLTDT_HEAD"].Rows[0]["WORK_SUM"];

                //e.result.Tables["RSLTDT"].Rows.InsertAt(dr, 0);

                //acGridView2.GridControl.Enabled = true;

                //acGridView2.GridControl.DataSource = e.result.Tables["RSLTDT"];

                ////acGridView2.BestFitColumns();

                //acGridView2.SetOldFocusRowHandle(false);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        String _strS_ORD_DATE = "";
        String _strE_ORD_DATE = "";
        String _strS_DUE_DATE = "";
        String _strE_DUE_DATE = "";
        void Search()
        {
            if (acTabControl1.SelectedTabPageIndex == 0)
            {
                //출하
                acLayoutControl4.ClearValue();

                DataRow layoutRow = acLayoutControl1.CreateParameterRow();

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("VEN_LIKE", typeof(String)); //
                paramTable.Columns.Add("S_ORD_DATE", typeof(String)); //
                paramTable.Columns.Add("E_ORD_DATE", typeof(String)); //
                paramTable.Columns.Add("S_DUE_DATE", typeof(String)); //
                paramTable.Columns.Add("E_DUE_DATE", typeof(String)); //

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["VEN_LIKE"] = layoutRow["VEN_LIKE"];

                _strS_ORD_DATE = "";
                _strE_ORD_DATE = "";
                _strS_DUE_DATE = "";
                _strE_DUE_DATE = "";

                foreach (string key in acCheckedComboBoxEdit1.GetKeyChecked())
                {
                    switch (key)
                    {
                        case "ORD_DATE":
                            //수주일

                            paramRow["S_ORD_DATE"] = layoutRow["S_DATE"];
                            paramRow["E_ORD_DATE"] = layoutRow["E_DATE"];
                            _strS_ORD_DATE = layoutRow["S_DATE"].ToString();
                            _strE_ORD_DATE = layoutRow["E_DATE"].ToString();
                            break;

                        case "DUE_DATE":
                            //납기일

                            paramRow["S_DUE_DATE"] = layoutRow["S_DATE"];
                            paramRow["E_DUE_DATE"] = layoutRow["E_DATE"];
                            _strS_DUE_DATE = layoutRow["S_DATE"].ToString();
                            _strE_DUE_DATE = layoutRow["E_DATE"].ToString();
                            break;
                    }
                }

                paramTable.Rows.Add(paramRow);

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);


                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD, "ORD30B_SER", paramSet, "RQSTDT", "RSLTDT, RSLTDT_HEAD",
                  QuickSearch,
                  QuickException);
            }
            else if (acTabControl1.SelectedTabPageIndex == 1)
            {
                //출하 취소

                DataRow layoutRow = acLayoutControl1.CreateParameterRow();

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("VEN_LIKE", typeof(String)); //
                paramTable.Columns.Add("S_DUE_DATE", typeof(String)); //
                paramTable.Columns.Add("E_DUE_DATE", typeof(String)); //
                paramTable.Columns.Add("S_SHIP_DATE", typeof(String)); //
                paramTable.Columns.Add("E_SHIP_DATE", typeof(String)); //

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["VEN_LIKE"] = layoutRow["VEN_LIKE"];

                foreach (string key in acCheckedComboBoxEdit1.GetKeyChecked())
                {
                    switch (key)
                    {
                        case "DUE_DATE":
                            //납기일

                            paramRow["S_DUE_DATE"] = layoutRow["S_DATE"];
                            paramRow["E_DUE_DATE"] = layoutRow["E_DATE"];
                            break;

                        case "SHP_DATE":
                            //출하일

                            paramRow["S_SHIP_DATE"] = layoutRow["S_DATE"];
                            paramRow["E_SHIP_DATE"] = layoutRow["E_DATE"];
                            break;
                    }
                }

                paramTable.Rows.Add(paramRow);

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);


                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD, "ORD30B_SER3", paramSet, "RQSTDT", "RSLTDT",
                  QuickSearch,
                  QuickException);
            }
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

        void QuickException(object sender, QBiz QBiz, BizManager.BizException ex)
        {
            acMessageBox.Show(this, ex);
        }


        void QuickSearch(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                if (acTabControl1.SelectedTabPageIndex == 0)
                {
                    //acGridView1.Columns["VEN_NAME"].Caption = "업체 : " + e.result.Tables["RSLTDT_HEAD"].Rows[0]["VEN_CNT"].ToString();
                    //acGridView1.Columns["WORK_CNT"].Caption = "작업 : " + e.result.Tables["RSLTDT_HEAD"].Rows[0]["WORK_SUM"].ToString();
                    DataRow dr = e.result.Tables["RSLTDT"].NewRow();
                    dr["VEN_NAME"] = "전체 " + "(업체 : " + e.result.Tables["RSLTDT_HEAD"].Rows[0]["VEN_CNT"].ToString() + ")";
                    dr["WORK_CNT"] = e.result.Tables["RSLTDT_HEAD"].Rows[0]["WORK_SUM"];

                    e.result.Tables["RSLTDT"].Rows.InsertAt(dr, 0);

                    acGridView1.GridControl.DataSource = e.result.Tables["RSLTDT"];
                   
                    acGridView1.SetOldFocusRowHandle(false);
                }
                else if (acTabControl1.SelectedTabPageIndex == 1)
                {
                    acGridView4.GridControl.DataSource = e.result.Tables["RSLTDT"];
                    //acGridView1.SetOldFocusRowHandle(false);
                }

                base.SetLog(e.executeType, e.result.Tables["RSLTDT"].Rows.Count, e.executeTime);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void SaveData()
        {
            //출하
            try
            {
                acGridView3.EndEditor();
                List<DataRow> selRows = new List<DataRow>();

                DataRow[] drArr = acGridView3.GetDataView().Table.Select("SEL = '1'");

                //if ((drArr.Length == 0) && (acGridView3.GetFocusedDataRow() != null))
                //{
                //    selRows.Add(acGridView3.GetFocusedDataRow());
                //}
                //else
                //{
                    foreach (DataRow dr in drArr)
                    {
                        DataRow row = dr;
                        selRows.Add(row);
                    }
                //}


                DataSet paramDS = new DataSet();
                paramDS.Tables.Add(drArr.CopyToDataTable());
                paramDS.Tables[0].TableName = "RQSTDT";

                DataSet dsResult = BizRun.QBizRun.ExecuteService(this, "ORD30B_SER5", paramDS, "RQSTDT", "RSLTDT");

                if (dsResult.Tables["RSLTDT"].Rows.Count > 0)
                {
                    acMessageBoxGridYesNo frmMsg = new acMessageBoxGridYesNo(this, "acMessageBoxGridConfirm1",
                         "생산실적 미완료 처리된 단품들이 있습니다.\r\n그래도 출하 하시겠습니까?.", "", false, this.Parent.Text, dsResult.Tables["RSLTDT"]);

                    frmMsg.View.GridType = acGridView.emGridType.SEARCH;

                    frmMsg.View.AddTextEdit("PART_CODE", "품목코드", "40556", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

                    frmMsg.View.AddTextEdit("PART_NAME", "품목명", "40556", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

                    frmMsg.View.AddTextEdit("PROC_NAME", "공정", "40556", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

                    frmMsg.View.AddDateEdit("ACT_START_TIME", "실적 시작시각", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.FULL_DATE);

                    frmMsg.View.AddDateEdit("ACT_END_TIME", "실적 완료시각", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.FULL_DATE);

                    if (frmMsg.ShowDialog() != DialogResult.Yes)
                    {
                        return;
                    }
                }

                if (selRows.Count  == 0)
                {
                    acMessageBox.Show("선택된 완료 실적이 없습니다. 완료 실적 중 출하 대상을 선택하세요.", this.Caption, acMessageBox.emMessageBoxType.CONFIRM);
                    return;
                }
                
                ORD30B_D0A frm = new ORD30B_D0A(acGridView3, selRows);

                frm.ParentControl = this;

                frm.DialogMode = BaseMenuDialog.emDialogMode.OPEN;

                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    acGridView1.RaiseFocusedRowChanged();
                    //this.Search();
                }

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void acBarButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SaveData();
        }

        private void acTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            //탭 변경            

            if (acTabControl1.SelectedTabPageIndex == 1)
            {
                acCheckedComboBoxEdit1.AddItem("출하일", false, "", "SHP_DATE", true, false, CheckState.Checked);
                acLayoutControl1.GetEditor("DATE").Value = "SHP_DATE"; 
                btnDeliver.Enabled = false;
                btnCancel.Enabled = true;
            }
            else
            {
                acCheckedComboBoxEdit1.RemoveItem(2);
                acLayoutControl1.GetEditor("DATE").Value = "ORD_DATE"; 
                btnDeliver.Enabled = true;
                btnCancel.Enabled = false;
            }

        }

        private void CancelData()
        {
            
            //출하 취소
            try
            {
                if (acMessageBox.Show("[출 하] 취소하시겠습니까?", this.Caption, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
                {
                    return;
                }

                acGridView4.EndEditor();


                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("ITEM_CODE", typeof(String)); //
                paramTable.Columns.Add("PROD_CODE", typeof(String)); //
                paramTable.Columns.Add("PART_CODE", typeof(String)); //
                paramTable.Columns.Add("SHIP_QTY", typeof(int)); //
                paramTable.Columns.Add("SHIP_ID", typeof(String)); //

                DataView selected = acGridView4.GetDataSourceView("SEL = '1'");

                if (selected.Count == 0)
                {
                    //단일삭제

                    DataRow focusRow = acGridView4.GetFocusedDataRow();

                    DataRow paramRow = paramTable.NewRow();
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["ITEM_CODE"] = focusRow["ITEM_CODE"];
                    paramRow["PROD_CODE"] = focusRow["PROD_CODE"];
                    paramRow["PART_CODE"] = focusRow["PART_CODE"];
                    paramRow["SHIP_QTY"] = focusRow["SHIP_QTY"];
                    paramRow["SHIP_ID"] = focusRow["SHIP_ID"];

                    paramTable.Rows.Add(paramRow);

                }
                else
                {
                    //다중 삭제
                    for (int i = 0; i < selected.Count; i++)
                    {
                        DataRow paramRow = paramTable.NewRow();
                        paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                        paramRow["ITEM_CODE"] = selected[i]["ITEM_CODE"];
                        paramRow["PROD_CODE"] = selected[i]["PROD_CODE"];
                        paramRow["PART_CODE"] = selected[i]["PART_CODE"];
                        paramRow["SHIP_QTY"] = selected[i]["SHIP_QTY"];
                        paramRow["SHIP_ID"] = selected[i]["SHIP_ID"];

                        paramTable.Rows.Add(paramRow);
                    }
                }

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);
                DataTable dtDeleteMapping = paramTable.Copy();
                dtDeleteMapping.TableName = "RQSTDT2";
                paramSet.Tables.Add(dtDeleteMapping);

                BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.PROCESS,
                "ORD30B_DEL", paramSet, "RQSTDT", "",
                QuickDEL,
                QuickException);

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }
        private void acBarButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CancelData();
        }

        void QuickDEL(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {

                foreach (DataRow row in e.result.Tables["RQSTDT2"].Rows)
                {
                    acGridView4.DeleteMappingRow(row);

                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }


        }

        void GetDetail(DataRow focus, bool isDetail)
        {
            //DataRow focus = acGridView2.GetFocusedDataRow();
            DataRow VEN_focus = acGridView1.GetFocusedDataRow();

            if (focus != null)
            {
                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String));
                paramTable.Columns.Add("ITEM_CODE", typeof(String));
                paramTable.Columns.Add("PROD_CODE", typeof(String));
                paramTable.Columns.Add("CVND_CODE", typeof(String));
                paramTable.Columns.Add("S_ORD_DATE", typeof(String)); //
                paramTable.Columns.Add("E_ORD_DATE", typeof(String)); //
                paramTable.Columns.Add("S_DUE_DATE", typeof(String)); //
                paramTable.Columns.Add("E_DUE_DATE", typeof(String)); //

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["ITEM_CODE"] = focus["ITEM_CODE"];

                if (focus["ITEM_CODE"].EqualsEx("ALL"))
                {
                    paramRow["CVND_CODE"] = VEN_focus["VEN_CODE"];
                }

                if (!isDetail) paramRow["PROD_CODE"] = focus["PROD_CODE"];
                

                if (_strS_ORD_DATE != "") paramRow["S_ORD_DATE"] = _strS_ORD_DATE;
                if (_strE_ORD_DATE != "") paramRow["E_ORD_DATE"] = _strE_ORD_DATE;
                if (_strS_DUE_DATE != "") paramRow["S_DUE_DATE"] = _strS_DUE_DATE;
                if (_strE_DUE_DATE != "") paramRow["E_DUE_DATE"] = _strE_DUE_DATE;

                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);


                BizRun.QBizRun.ExecuteService(
                 this, QBiz.emExecuteType.LOAD_DETAIL,
                 "ORD30B_SER4", paramSet, "RQSTDT", "RSLTDT,RSLTDT_WO,RSLTDT_BAL",
                 QuickSearch2,
                 QuickException);
            }
        }

        void QuickSearch2(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {

                acGridView3.GridControl.DataSource = e.result.Tables["RSLTDT"];

                if (acGridView3.RowCount > 0)
                    btnDeliver.Enabled = true;
                else
                    btnDeliver.Enabled = false;


                base.SetLog(e.executeType, e.result.Tables["RSLTDT"].Rows.Count, e.executeTime);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void acBarButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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

        private void btnDeliver_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SaveData();
        }

        private void btnCancel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CancelData();
        }

        private void acBarButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //일일업무보고서(출하), 거래명세표 출력
            try
            {
                if (acGridView4.FocusedRowHandle < 0)
                {
                    return;
                }

                acGridView4.EndEditor();



                //DataView view = acGridView4.GetDataSourceView("SEL = '1'");
                DataView view = acGridView4.GetDataSourceView("SEL = '1'");

                if (view.Count != 0)
                {
                    DataRow focusRow = view[0].Row;

                    DataSet dataSource = new DataSet();

                    DataTable master = focusRow.NewTable();
                    master.TableName = "M";

                    master.Columns.Add("PAGE_INFO", typeof(String));

                    master.Rows[0]["PAGE_INFO"] = "0";

                    if (view.Count > 9)
                    {
                        int cnt = view.Count / 9;

                        for (int i = 0; i < cnt; i++)
                        {
                            string pageinfo = (i + 1).toStringEmpty();
                            DataRow dr = master.NewRow();
                            dr["PAGE_INFO"] = pageinfo;
                            master.Rows.Add(dr);
                        }

                    }

                    
                    //DataTable detail = view.ToTable();
                    DataTable detail = view.ToTable().Select("", "SEQ").CopyToDataTable();

                    detail.TableName = "D";

                    detail.Columns.Add("PAGE_INFO", typeof(String));

                    for (int i = 0; i < detail.Rows.Count; i++)
                    {
                        int cnt = i / 9;

                        detail.Rows[i]["PAGE_INFO"] = cnt.ToString();
                    }



                    dataSource.Tables.AddRange(new DataTable[] { master, detail });

                    ReportManager.acReportView.ShowReportCategoryPreview(this, "DEFAULT", dataSource);
                }

                

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        
        private void acBarButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (this.acTabControl1.SelectedTabPage == acTabPage2)
                {
                    foreach (DataRow dr in acGridView4.GetSelectedDataRows())
                    {
                        dr["SEL"] = "1";
                    }
                }

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void acBarButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (this.acTabControl1.SelectedTabPage == acTabPage2)
                {
                    foreach (DataRow dr in acGridView4.GetSelectedDataRows())
                    {
                        dr["SEL"] = "0";
                    }
                }

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

       

    }
}