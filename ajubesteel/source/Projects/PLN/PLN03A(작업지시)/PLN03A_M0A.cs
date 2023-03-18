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
using POP;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using System.IO;

namespace PLN
{
    public sealed partial class PLN03A_M0A : BaseMenu
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

        public PLN03A_M0A()
        {
            InitializeComponent();

            acGridView1.DataSourceChanged += acGridView1_DataSourceChanged;
            acGridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(acGridView1_FocusedRowChanged);

            acGridView1.ShowGridMenuEx += new acGridView.ShowGridMenuExHandler(acGridView1_ShowGridMenuEx);
            //acGridView2.ShowGridMenuEx += new acGridView.ShowGridMenuExHandler(acGridView2_ShowGridMenuEx);


            acLayoutControl1.OnValueKeyDown += new acLayoutControl.ValueKeyDownEventHandler(acLayoutControl1_OnValueKeyDown);
            acLayoutControl1.OnValueChanged += new acLayoutControl.ValueChangedEventHandler(acLayoutControl1_OnValueChanged);


            acCheckEdit1.CheckedChanged += acCheckEdit1_CheckedChanged;

        }

        void acGridView1_DataSourceChanged(object sender, EventArgs e)
        {
            GetDetail();
        }

        private void acGridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            GetDetail();
        }

        public void GetDetail()
        {
            //품목정보 조회
            DataRow focus = acGridView1.GetFocusedDataRow();

            if (focus != null)
            {
                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String));                
                paramTable.Columns.Add("PROD_CODE", typeof(String));

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["PROD_CODE"] = focus["PROD_CODE"];
                
                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);


                BizRun.QBizRun.ExecuteService(
                 this, QBiz.emExecuteType.LOAD_DETAIL,
                 "PLN03A_SER2", paramSet, "RQSTDT", "RSLTDT",
                 QuickDetail,
                 QuickException);
            }
            else
            {
                acGridView2.ClearRow();
                return;
            }


        }

        //void acGridView1_ShowGridMenuEx(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        //{
        //    acGridView view = sender as acGridView;



        //    if (e.MenuType == GridMenuType.User)
        //    {
        //        acBarButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;//수정
        //        acBarButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;//신규
        //        acBarButtonItem3.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;//삭제

        //    }
        //    else if (e.MenuType == GridMenuType.Row)
        //    {
        //        if (e.HitInfo.RowHandle >= 0)
        //        {
        //            acBarButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
        //            acBarButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
        //            acBarButtonItem3.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
        //        }
        //        else
        //        {
        //            acBarButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
        //            acBarButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
        //            acBarButtonItem3.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
        //        }

        //    }


        //    if (e.HitInfo.HitTest == GridHitTest.EmptyRow || e.HitInfo.HitTest == GridHitTest.Row || e.HitInfo.HitTest == GridHitTest.RowCell)
        //    {

        //        GridHitInfo hitInfo = view.CalcHitInfo(e.Point);

        //        popupMenu1.ShowPopup(view.GridControl.PointToScreen(e.Point));

        //    }
        //}




        // 제작 관련 정보 보기
        void acGridView1_ShowGridMenuEx(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            acGridView view = sender as acGridView;

            if (e.MenuType == GridMenuType.User)
            {
                acBarButtonItem8.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                acBarButtonItem9.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                acBarButtonItem10.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
            else if (e.MenuType == GridMenuType.Row)
            {
                if (e.HitInfo.RowHandle >= 0)
                {
                    acBarButtonItem8.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    acBarButtonItem9.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    acBarButtonItem10.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                }
                else
                {
                    acBarButtonItem8.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    acBarButtonItem9.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    acBarButtonItem10.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                }

            }


            if (e.HitInfo.HitTest == GridHitTest.EmptyRow || e.HitInfo.HitTest == GridHitTest.Row || e.HitInfo.HitTest == GridHitTest.RowCell)
            {

                GridHitInfo hitInfo = view.CalcHitInfo(e.Point);

                popupMenu3.ShowPopup(view.GridControl.PointToScreen(e.Point));


            }

        }



        //작업지시 확정 취소
        void acGridView2_ShowGridMenuEx(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            acGridView view = sender as acGridView;

            if (e.MenuType == GridMenuType.User)
            {
                acBarButtonItem4.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                acBarButtonItem5.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            }
            else if (e.MenuType == GridMenuType.Row)
            {
                if (e.HitInfo.RowHandle >= 0)
                {
                    acBarButtonItem4.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    acBarButtonItem5.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                }
                else
                {
                    acBarButtonItem4.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    acBarButtonItem5.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                }

            }


            if (e.HitInfo.HitTest == GridHitTest.EmptyRow || e.HitInfo.HitTest == GridHitTest.Row || e.HitInfo.HitTest == GridHitTest.RowCell)
            {

                GridHitInfo hitInfo = view.CalcHitInfo(e.Point);

                popupMenu2.ShowPopup(view.GridControl.PointToScreen(e.Point));

            }
        }

        //계획 정보 상세 보기
        void acGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                GridHitInfo hitInfo = acGridView1.CalcHitInfo(e.Location);

                if (hitInfo.HitTest == GridHitTest.RowCell || hitInfo.HitTest == GridHitTest.Row)
                {

                   // this.acBarButtonItem1_ItemClick(null, null);
                }

            }
        }

        public override void MenuInit()
        {
            try
            {
                acGridView1.GridType = acGridView.emGridType.SEARCH;

                //CodeHelperManager.RepositoryItemEmp edit = new CodeHelperManager.RepositoryItemEmp();

                //edit.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;                 
                //acGridView1.AddCustomEdit("LOCK_FLAG", "잠금상태", "", false, DevExpress.Utils.HorzAlignment.Center, true, true, false, edit);
                acGridView1.AddLookUpEdit("PROD_PRIORITY", "우선순위", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P028");
                acGridView1.AddLookUpEdit("PROD_STATE", "수주상태", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P012");
                //acGridView1.AddCheckEdit("LOCK_FLAG", "잠금상태", "", false, false, true, acGridView.emCheckEditDataType._BYTE);
                //acGridView1.AddLookUpEmp("LOCK_EMP", "잠금자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false);
                acGridView1.AddTextEdit("PROD_CODE", "수주번호", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView1.AddTextEdit("PROD_NAME", "모델명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView1.AddTextEdit("PROD_VERSION", "버전", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView1.AddLookUpEdit("PROC_FLAG", "공정명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P005");
                acGridView1.AddLookUpEdit("PROD_FLAG", "유형", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P006");
                acGridView1.AddLookUpEdit("INS_YN", "성적서", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P007");
                acGridView1.AddLookUpEdit("SOCKET_YN", "소켓측정", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P007");
                acGridView1.AddCheckedComboBoxEdit("PROD_CATEGORY", "제품유형", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, "P009");
                //acGridView1.AddTextEdit("BUSINESS_EMP", "영업담당자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView1.AddLookUpEmp("BUSINESS_EMP", "영업담당자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false);
                //acGridView1.AddTextEdit("CUSTOMER_EMP", "고객담당자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView1.AddLookUpEmp("CUSTOMER_EMP", "고객담당자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false);
                //acGridView1.AddTextEdit("CUSTDESIGN_EMP", "고객설계자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView1.AddLookUpEmp("CUSTDESIGN_EMP", "고객설계자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false);
                acGridView1.AddLookUpEdit("ACTUATOR_YN", "Actuator유무", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "S101");

                //acGridView1.AddTextEdit("CVND_CODE", "발주처코드", "CPW0FS8W", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView1.AddTextEdit("CVND_NAME", "발주처", "CPW0FS8W", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                //acGridView1.AddTextEdit("TVND_CODE", "계산서 발행처 코드", "CPW0FS8W", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView1.AddTextEdit("TVND_NAME", "계산서 발행처", "CPW0FS8W", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

                acGridView1.AddDateEdit("ORD_DATE", "수주일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
                acGridView1.AddDateEdit("DUE_DATE", "출하예정일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
                acGridView1.AddDateEdit("CHG_DUE_DATE", "출하조정일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
                //acGridView1.AddDateEdit("DELIVERY_DATE", "납품일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);

                acGridView1.AddCheckedComboBoxEdit("PIN_TYPE", "Contact", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, "P011");
                acGridView1.AddLookUpEdit("PROD_TYPE", "제품분류", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P010");
                acGridView1.AddTextEdit("PROD_QTY", "수량", "CPW0FS8W", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NUMERIC);
                //acGridView1.AddTextEdit("PROD_COST", "공급단가", "CPW0FS8W", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
                //acGridView1.AddTextEdit("PROD_AMT", "총금액", "CPW0FS8W", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
                //acGridView1.AddCheckEdit("ORD_VAT", "VAT별도", "", false, false, true, acGridView.emCheckEditDataType._STRING);
                //acGridView1.AddLookUpEdit("CURR_UNIT", "통화", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P008");

                //acGridView1.AddLookUpEdit("TRADE_YN", "거래명세표", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P007");
                //acGridView1.AddLookUpEdit("TAX_YN", "세금계산서", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P007");
                //acGridView1.AddLookUpEdit("BILL_YN", "수금등록", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P007");

                //acGridView1.AddMemoEdit("REMARK", "특기사항", "", false, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, false, true, true, false);
                //acGridView1.AddMemoEdit("SCOMMENT", "전달사항", "", false, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, false, true, true, false);
                //acGridView1.AddTextEdit("REMARK", "특기사항", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView1.AddTextEdit("SCOMMENT", "전달사항", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

                acGridView1.AddDateEdit("REG_DATE", "최초 등록일", "UL1O77MB", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emDateMask.LONG_DATE);
                acGridView1.AddTextEdit("REG_EMP", "최초 등록자코드", "P72K0SQJ", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
                acGridView1.AddTextEdit("REG_EMP_NAME", "최초 등록자", "GPQHG8QQ", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
                acGridView1.AddDateEdit("MDFY_DATE", "최근 수정일", "6RXQO0B2", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emDateMask.LONG_DATE);
                acGridView1.AddTextEdit("MDFY_EMP", "최근 수정자코드", "WDHSCE72", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
                acGridView1.AddTextEdit("MDFY_EMP_NAME", "최근 수정자", "FHJDO4F0", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);

                acGridView1.KeyColumn = new string[] { "PROD_CODE" };



                acGridView2.GridType = acGridView.emGridType.SEARCH;

                //acGridView2.AddCheckEdit("SEL", "선택", "", false, true, true, acGridView.emCheckEditDataType._STRING);                
                acGridView2.AddLookUpEdit("PROD_PRIORITY", "수주 우선순위", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P028");
                acGridView2.AddLookUpEdit("JOB_PRIORITY", "공정 우선순위", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "W001");

                acGridView2.AddTextEdit("PART_CODE", "품목코드", "40239", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView2.AddTextEdit("PART_NAME", "품목명", "40234", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView2.AddLookUpEdit("WO_FLAG", "상태", "40278", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "S032");
                acGridView2.AddTextEdit("WO_NO", "작업지시번호", "40556", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView2.AddLookUpEdit("WORK_CODE", "재작업 사유", "42515", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "C108");
                acGridView2.AddTextEdit("PROC_CODE", "공정코드", "40920", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView2.AddTextEdit("PROC_NAME", "공정명", "40921", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView2.AddLookUpEdit("MC_GROUP", "설비그룹", "42515", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "C020");
                //acGridView2.AddTextEdit("MC_CODE", "설비코드", "41162", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                //acGridView2.AddTextEdit("MC_NAME", "설비명", "41202", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                //acGridView2.AddTextEdit("EMP_CODE", "작업자코드", "40551", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                //acGridView2.AddTextEdit("EMP_NAME", "작업자명", "40545", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView2.AddTextEdit("PLN_QTY", "계획수량", "NAFTT723", true, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
                acGridView1.AddDateEdit("PLN_START", "계획시작시간", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.LONG_DATE);
                acGridView1.AddDateEdit("PLN_END", "계획완료시간", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.LONG_DATE);
                acGridView1.AddTextEdit("PLN_PROC_TIME", "계획공수", "D2FYBIE6", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NUMERIC);
                acGridView2.AddTextEdit("CAUTION", "주의사항", "D2FYBIE6", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView2.AddTextEdit("SCOMMENT", "비고", "ARYZ726K", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

                //acGridView2.AddTextEdit("BAL_SPEC", "발주규격", "7MROZYWS", true, DevExpress.Utils.HorzAlignment.Near, false, false, false, acGridView.emTextEditMask.NONE);
                //acGridView2.AddTextEdit("BAL_WEIGHT", "발주중량", "GOC9BNEP", true, DevExpress.Utils.HorzAlignment.Near, false, false, false, acGridView.emTextEditMask.NONE);

                acGridView2.AddHidden("PROD_CODE", typeof(string));
                acGridView2.AddHidden("PART_ID", typeof(Int32));
                acGridView2.AddHidden("PROC_ID", typeof(Int32));
                acGridView2.AddHidden("IS_MAT", typeof(Int32));
                acGridView2.AddHidden("IS_OS", typeof(Int32));

                acGridView2.KeyColumn = new string[] { "WO_NO" };



                acCheckedComboBoxEdit1.AddItem("등록일", false, "", "REG_DATE", true, false);
                acCheckedComboBoxEdit1.AddItem("수주일", false, "", "ORD_DATE", true, false);
                acCheckedComboBoxEdit1.AddItem("출하예정일", false, "", "DUE_DATE", true, false);
                //acCheckedComboBoxEdit1.AddItem("납품일", false, "", "DELIVERY_DATE", true, false);

                base.MenuInit();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }



        public override void ChildContainerInit(Control sender)
        {

            if (sender == acLayoutControl1)
            {
                acLayoutControl layout = sender as acLayoutControl;

                layout.GetEditor("DATE").Value = "ORD_DATE";
                layout.GetEditor("S_DATE").Value = DateTime.Now.AddDays(-7);
                layout.GetEditor("E_DATE").Value = DateTime.Now;
            }

            //(acLayoutControl1.GetEditor("WEEK_YEAR").Editor as acDateEdit).EditValue = DateTime.Today;

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
            //paramTable.Columns.Add("S_DELIVERY_DATE", typeof(String)); //출하 시작일
            //paramTable.Columns.Add("E_DELIVERY_DATE", typeof(String)); //출하 종료일
            paramTable.Columns.Add("S_DUE_DATE", typeof(String)); //납기일 시작일
            paramTable.Columns.Add("E_DUE_DATE", typeof(String)); //납기일 종료일
            paramTable.Columns.Add("S_SHIP_DATE", typeof(String)); //출하 시작일
            paramTable.Columns.Add("E_SHIP_DATE", typeof(String)); //출하 종료일
            paramTable.Columns.Add("PROD_KIND_NOT_IE", typeof(String));

            DataRow layoutRow = acLayoutControl1.CreateParameterRow();

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["PROD_LIKE"] = layoutRow["PROD_LIKE"];
            paramRow["CVND_LIKE"] = layoutRow["CVND_LIKE"];
            paramRow["BUSINESS_EMP"] = layoutRow["BUSINESS_EMP"];
            paramRow["PROD_KIND_NOT_IE"] = "1";

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
                    //case "DELIVERY_DATE":
                    //    //납품일
                    //    paramRow["S_DELIVERY_DATE"] = layoutRow["S_DATE"];
                    //    paramRow["E_DELIVERY_DATE"] = layoutRow["E_DATE"];

                    //    break;

                    case "SHIP_DATE":
                        //출하일
                        paramRow["S_SHIP_DATE"] = layoutRow["S_DATE"];
                        paramRow["E_SHIP_DATE"] = layoutRow["E_DATE"];

                        break;
                }
            }


            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);


            BizRun.QBizRun.ExecuteService(
             this, QBiz.emExecuteType.LOAD,
             "PLN03A_SER", paramSet, "RQSTDT", "RSLTDT",
             QuickSearch,
             QuickException);
        }


        void QuickSearch(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {                

                acGridView1.GridControl.DataSource = e.result.Tables["RSLTDT"];

                base.SetLog(e.executeType, e.result.Tables["RSLTDT"].Rows.Count, e.executeTime);

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        private DataTable _dtDetail = null;

        void QuickDetail(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                this._dtDetail = e.result.Tables["RSLTDT"];

                if (acCheckEdit1.Checked)
                {
                    acGridView2.GridControl.DataSource = e.result.Tables["RSLTDT"];
                }
                else
                {
                    DataRow[] noneWoRows = e.result.Tables["RSLTDT"].Select("WO_FLAG = '0' ");

                    if (noneWoRows.Length == 0)
                    {
                        acGridView2.ClearRow();                        
                    }
                    else
                    {
                        acGridView2.GridControl.DataSource = noneWoRows.CopyToDataTable();
                    }

                }

                acGridView2.RaiseFocusedRowChanged();
                acGridView2.BestFitColumns();

                //base.SetLog(e.executeType, e.result.Tables["RSLTDT"].Rows.Count, e.executeTime);

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }



        private void acCheckEdit1_CheckedChanged(object sender, EventArgs e)
        {
            if (this._dtDetail != null)
            {
                acCheckEdit checkEdit = sender as acCheckEdit;

                if (checkEdit.Checked)
                {
                    acGridView2.GridControl.DataSource = this._dtDetail;
                }
                else
                {
                    DataRow[] noneWoRows = this._dtDetail.Select("WO_FLAG = '0' ");

                    if (noneWoRows.Length == 0)
                    {
                        acGridView2.ClearRow();
                    }
                    else
                    {
                        acGridView2.GridControl.DataSource = noneWoRows.CopyToDataTable();
                    }
                }

            }
        }



        void QuickException(object sender, QBiz qBiz, BizManager.BizException ex)
        {
            if (ex.ParameterData != null)
            {
                acMessageBoxGridConfirm frm = new acMessageBoxGridConfirm(this, "acMessageBoxGridConfirm1", acInfo.BizError.GetDesc(ex.ErrNumber), string.Empty, false, this.Caption, ex.ParameterData);


                frm.View.GridType = acGridView.emGridType.FIXED;

                frm.View.AddTextEdit("WO_NO", "작업지시번호", "40900", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

                frm.View.AddTextEdit("PART_CODE", "품목코드", "40900", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

                frm.View.AddTextEdit("PART_NAME", "품목명", "40900", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

                frm.View.AddTextEdit("PROC_CODE", "공정코드", "40900", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

                frm.View.AddTextEdit("PROC_NAME", "공정명", "40900", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);


                frm.ShowDialog();
            }
            else
            {
                acMessageBox.Show(this, ex);
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

        //삭제
        private void acBarButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (acMessageBox.Show(this, "정말 삭제하시겠습니까?", "TB43FSY3", true, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
            {
                return;
            }


            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("WO_NO", typeof(String)); //
            paramTable.Columns.Add("DEL_EMP", typeof(String)); //

            DataView selectedView = acGridView1.GetDataView("SEL = '1'");

            if (selectedView.Count == 0)
            {
                DataRow focusRow = acGridView1.GetFocusedDataRow();

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["WO_NO"] = focusRow["WO_NO"];
                paramRow["DEL_EMP"] = acInfo.UserID;

                paramTable.Rows.Add(paramRow);
            }
            else
            {
                for (int i = 0; i < selectedView.Count; i++)
                {
                    DataRow paramRow = paramTable.NewRow();
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["WO_NO"] = selectedView[i]["WO_NO"];
                    paramRow["DEL_EMP"] = acInfo.UserID;

                    paramTable.Rows.Add(paramRow);
                }
            }

            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            BizRun.QBizRun.ExecuteService(
                  this, QBiz.emExecuteType.DEL,
                  "PLN03A_DEL", paramSet, "RQSTDT", "",
                  QuickDEL,
                  QuickException);
        }

        void QuickDEL(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                foreach (DataRow row in e.result.Tables["RQSTDT"].Rows)
                {
                    this.acGridView1.DeleteMappingRow(row);
                }

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        
        //확정
        private void acBarButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            acGridView2.EndEditor();

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String));                        
            paramTable.Columns.Add("WO_NO", typeof(String));
            paramTable.Columns.Add("WO_FLAG", typeof(String));
            paramTable.Columns.Add("REG_EMP", typeof(String));            

            //DataView selectedView = acGridView2.GetDataView("SEL = '1'");
            DataRow[] selectedRows = acGridView2.GetSelectedDataRows();


            if (selectedRows.Length == 0)
            {
                DataRow focusRow = acGridView2.GetFocusedDataRow();
                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["WO_NO"] = focusRow["WO_NO"];
                paramRow["WO_FLAG"] = "1";
                paramRow["REG_EMP"] = acInfo.UserID;

                paramTable.Rows.Add(paramRow);
            }
            else
            {
                foreach (DataRow row in selectedRows)
                {
                    DataRow paramRow = paramTable.NewRow();
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["WO_NO"] = row["WO_NO"];
                    paramRow["WO_FLAG"] = "1";
                    paramRow["REG_EMP"] = acInfo.UserID;

                    paramTable.Rows.Add(paramRow);
                }
            }
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);


            BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD, "PLN03A_SAVE2", paramSet, "RQSTDT", "RSLTDT",
                        QuickSave,
                        QuickException);

        }
        //확정 취소
        private void acBarButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            acGridView2.EndEditor();

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String));
            paramTable.Columns.Add("ITEM_CODE", typeof(String));
            paramTable.Columns.Add("PROD_CODE", typeof(String));
            paramTable.Columns.Add("WO_NO", typeof(String));
            paramTable.Columns.Add("WO_FLAG", typeof(String));
            paramTable.Columns.Add("REG_EMP", typeof(String));
            paramTable.Columns.Add("IS_MAT", typeof(int));
            paramTable.Columns.Add("WP_NO", typeof(String));

            DataRow[] selectedRows = acGridView2.GetSelectedDataRows();


            if (selectedRows.Length == 0)
            {
                DataRow focusRow = acGridView2.GetFocusedDataRow();
                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["WO_NO"] = focusRow["WO_NO"];
                paramRow["WO_FLAG"] = "0";
                paramRow["REG_EMP"] = acInfo.UserID;

                paramTable.Rows.Add(paramRow);
            }
            else
            {
                foreach (DataRow row in selectedRows)
                {
                    DataRow paramRow = paramTable.NewRow();
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["WO_NO"] = row["WO_NO"];
                    paramRow["WO_FLAG"] = "0";
                    paramRow["REG_EMP"] = acInfo.UserID;

                    paramTable.Rows.Add(paramRow);
                }
            }


            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);


            BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.SAVE, "PLN03A_SAVE2", paramSet, "RQSTDT", "RSLTDT",
                        QuickSave,
                        QuickException);
        }



        private void acBarButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            acGridView2.EndEditor();
            //주의사항 입력

            DataRow focusRow = acGridView2.GetFocusedDataRow();


            string formKey = string.Format("{0},{1}", "WO_NO", focusRow["WO_NO"]);

            if (!base.ChildFormContains(formKey))
            {

                PLN03A_D1A frm = new PLN03A_D1A(acGridView2, focusRow);

                frm.DialogMode = BaseMenuDialog.emDialogMode.OPEN;

                frm.ParentControl = this;

                base.ChildFormAdd(formKey, frm);

                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    DataRow output = (DataRow)frm.OutputData;

                    DataTable paramTable = new DataTable("RQSTDT");
                    paramTable.Columns.Add("PLT_CODE", typeof(String));
                    paramTable.Columns.Add("WO_NO", typeof(String));
                    paramTable.Columns.Add("CAUTION", typeof(String));

                    DataRow[] selectedRows = acGridView2.GetSelectedDataRows();


                    if (selectedRows.Length == 0)
                    {
                        //DataRow focusRow = acGridView2.GetFocusedDataRow();
                        DataRow paramRow = paramTable.NewRow();
                        paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                        paramRow["WO_NO"] = focusRow["WO_NO"];
                        paramRow["CAUTION"] = output["CAUTION"];
                        //paramRow["REG_EMP"] = acInfo.UserID;

                        paramTable.Rows.Add(paramRow);
                    }
                    else
                    {
                        foreach (DataRow row in selectedRows)
                        {
                            DataRow paramRow = paramTable.NewRow();
                            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                            paramRow["WO_NO"] = row["WO_NO"];
                            paramRow["CAUTION"] = output["CAUTION"];
                           // paramRow["REG_EMP"] = acInfo.UserID;

                            paramTable.Rows.Add(paramRow);
                        }
                    }



                    DataSet paramSet = new DataSet();
                    paramSet.Tables.Add(paramTable);

                    BizRun.QBizRun.ExecuteService(
                    this, QBiz.emExecuteType.SAVE, "PLN03A_UPD", paramSet, "RQSTDT", "RSLTDT",
                    QuickSave,
                    QuickException);
                }
            }
            else
            {
                base.ChildFormFocus(formKey);

            }
        }

        void QuickSave(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {

                foreach (DataRow row in e.result.Tables["RQSTDT"].Rows)
                {
                    this.acGridView2.UpdateMapingRow(row, true);
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        //확정/확정취소 이력 보기
        private void acBarButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DataRow focusRow = acGridView2.GetFocusedDataRow();

            string formKey = string.Format("{0},{1}", "WO_NO", focusRow["WO_NO"]);

            if (!base.ChildFormContains(formKey))
            {

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String));
                paramTable.Columns.Add("WO_NO", typeof(String));

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["WO_NO"] = focusRow["WO_NO"];

                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                DataTable dtResult = BizRun.QBizRun.ExecuteService(this, "PLN03A_SER7", paramSet, "RQSTDT", "RSLTDT").Tables["RSLTDT"];

                PLN03A_D2A frm = new PLN03A_D2A(dtResult);

                frm.ParentControl = this;

                base.ChildFormAdd(formKey, frm);
                
                frm.Show();

            }
        }

        private void btnRework_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //재작업지시
            try
            {

                DataRow focusRow = acGridView2.GetFocusedDataRow();

                if (focusRow == null) return;
                //중지나 완료인 경우만 재작업지시 가능
                if (focusRow["WO_FLAG"].ToString() == "3" || focusRow["WO_FLAG"].ToString() == "4")
                {
                    PLN03A_D3A frm = new PLN03A_D3A();

                    frm.ParentControl = this;

                    base.ChildFormAdd("WO_NO", frm);

                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        DataRow dr = (DataRow)frm.OutputData;

                        DataTable paramTable = new DataTable("RQSTDT");
                        paramTable.Columns.Add("PLT_CODE", typeof(String));
                        paramTable.Columns.Add("WO_NO", typeof(String));

                        DataRow paramRow = paramTable.NewRow();
                        paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                        paramRow["WO_NO"] = focusRow["WO_NO"];

                        paramTable.Rows.Add(paramRow);                       

                        DataSet paramSet = new DataSet();
                        paramSet.Tables.Add(paramTable);

                        DataTable dtResult = BizRun.QBizRun.ExecuteService(this, "PLN03A_SAVE3", paramSet, "RQSTDT", "RSLTDT").Tables["RSLTDT"];
                        foreach (DataRow row in dtResult.Rows)
                        {
                            acGridView2.UpdateMapingRow(row, true);
                        }
                        acMessageBox.Show("재작업 지시 처리되었습니다. ", "재작업지시", acMessageBox.emMessageBoxType.CONFIRM);
                    }
                }
                else
                {
                    acMessageBox.Show("재작업지시는 중지 혹은 완료된 작업만 가능합니다. ", "재작업지시", acMessageBox.emMessageBoxType.CONFIRM);

                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void btnDelWO_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //지시 삭제
            try
            {
                if (acMessageBox.Show("선택한 작업지시를 삭제하시겠습니까? ", "작업지시 삭제", acMessageBox.emMessageBoxType.YESNO) != DialogResult.Yes)
                    return;
                

                DataRow[] selectedRows = acGridView2.GetSelectedDataRows();

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String));
                paramTable.Columns.Add("WO_NO", typeof(String));
                paramTable.Columns.Add("IS_MAT", typeof(String));


                if (selectedRows.Length == 0)
                {
                    DataRow focusRow = acGridView2.GetFocusedDataRow();


                    //if (focusRow["WO_FLAG"].ToString() == "1" || focusRow["WO_FLAG"].ToString() == "0")
                    //{
                    //    acMessageBox.Show("작업지시 삭제는 [미확정] 혹은 [확정]된 작업만 가능합니다. ", "작업지시 삭제", acMessageBox.emMessageBoxType.CONFIRM);
                    //    return;
                    //}

                    DataRow paramRow = paramTable.NewRow();
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["WO_NO"] = focusRow["WO_NO"];
                    paramRow["IS_MAT"] = focusRow["IS_MAT"];

                    paramTable.Rows.Add(paramRow);
                }
                else
                {
                    foreach (DataRow row in selectedRows)
                    {
                        //if (row["WO_FLAG"].ToString() == "1" || row["WO_FLAG"].ToString() == "0")
                        //{
                        //    acMessageBox.Show("작업지시 삭제는 [미확정] 혹은 [확정]된 작업만 가능합니다. ", "작업지시 삭제", acMessageBox.emMessageBoxType.CONFIRM);
                        //    return;
                        //}
                        DataRow paramRow = paramTable.NewRow();
                        paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                        paramRow["WO_NO"] = row["WO_NO"];
                        paramRow["IS_MAT"] = row["IS_MAT"];

                        paramTable.Rows.Add(paramRow);
                    }
                }

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.SAVE, "PLN03A_DEL", paramSet, "RQSTDT", "RSLTDT",
                        QuickDel,
                        QuickException);
                
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void QuickDel(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                foreach (DataRow row in e.result.Tables["RQSTDT"].Rows)
                {
                    this.acGridView2.DeleteMappingRow(row);
                }

                acMessageBox.Show("삭제 처리되었습니다. ", "작업지시 삭제", acMessageBox.emMessageBoxType.CONFIRM);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void acBarButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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

        private void acBarButtonItem9_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // BOM 보기

            DataRow focusRow = acGridView1.GetFocusedDataRow();

            if (focusRow == null) { return; }

            PopBom frm = new PopBom(focusRow);

            frm.DialogMode = BaseMenuDialog.emDialogMode.NEW;

            frm.ParentControl = this;

            frm.ShowDialog(this);

        }

        private void acBarButtonItem10_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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
