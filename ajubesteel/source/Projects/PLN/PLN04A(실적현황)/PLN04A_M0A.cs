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
    public sealed partial class PLN04A_M0A : BaseMenu
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

        public PLN04A_M0A()
        {
            InitializeComponent();

            acGridView1.DataSourceChanged += acGridView1_DataSourceChanged;
            acGridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(acGridView1_FocusedRowChanged);
            //acGridView1.MouseDown += new MouseEventHandler(acGridView1_MouseDown);         
            //acGridView1.ShowGridMenuEx += new acGridView.ShowGridMenuExHandler(acGridView1_ShowGridMenuEx);


            //acGridView2.ShowGridMenuEx += new acGridView.ShowGridMenuExHandler(acGridView2_ShowGridMenuEx);
            acGridView2.FocusedRowChanged += acGridView2_FocusedRowChanged;
            //acGridView2.RowCellClick += acGridView2_RowCellClick;




            acGridView4.CustomDrawCell += acGridView4_CustomDrawCell;
            acGridView4.FocusedRowChanged += acGridView4_FocusedRowChanged;


            acLayoutControl1.OnValueKeyDown += new acLayoutControl.ValueKeyDownEventHandler(acLayoutControl1_OnValueKeyDown);
            acLayoutControl1.OnValueChanged += new acLayoutControl.ValueChangedEventHandler(acLayoutControl1_OnValueChanged);

        }



        void acGridView1_DataSourceChanged(object sender, EventArgs e)
        {
            GetDetail();
        }

        void acGridView4_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.RowHandle == 0)
            {
                e.Appearance.BackColor = Color.LightGray;
            }
        }



        void acGridView4_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow focus = acGridView4.GetFocusedDataRow();

            DataRow layoutRow = acLayoutControl1.CreateParameterRow();

            if (focus != null)
            {

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("CVND_LIKE", typeof(String)); //
                paramTable.Columns.Add("CVND_CODE", typeof(String)); //
                paramTable.Columns.Add("S_REG_DATE", typeof(String)); //등록 시작일
                paramTable.Columns.Add("E_REG_DATE", typeof(String)); //등록 종료일
                paramTable.Columns.Add("S_ORD_DATE", typeof(String)); //수주일 시작일
                paramTable.Columns.Add("E_ORD_DATE", typeof(String)); //수주일 종료일
                //paramTable.Columns.Add("S_DELIVERY_DATE", typeof(String)); //출하 시작일
                //paramTable.Columns.Add("E_DELIVERY_DATE", typeof(String)); //출하 종료일
                paramTable.Columns.Add("S_DUE_DATE", typeof(String)); //납기일 시작일
                paramTable.Columns.Add("E_DUE_DATE", typeof(String)); //납기일 종료일


                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["CVND_LIKE"] = layoutRow["CVND_LIKE"];
                paramRow["CVND_CODE"] = focus["CVND_CODE"];
                //paramRow["PROD_STATE"] = "WK,PG";

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
                        //    paramRow["S_SHIP_DATE"] = layoutRow["S_DATE"];
                        //    paramRow["E_SHIP_DATE"] = layoutRow["E_DATE"];

                        //    break;
                    }
                }

                paramTable.Rows.Add(paramRow);

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);


                BizRun.QBizRun.ExecuteService(
                 this, QBiz.emExecuteType.LOAD,
                 "PLN04A_SER2", paramSet, "RQSTDT", "RSLTDT",
                 QuickSearch2,
                 QuickException);
            }
        }



        
        void acGridView2_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
  
            GetSubDetail();
        }


        public void GetSubDetail()
        {
            //품목정보 조회
            DataRow focus = acGridView2.GetFocusedDataRow();

            if (focus != null)
            {
                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String));
                paramTable.Columns.Add("WO_NO", typeof(String));

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["WO_NO"] = focus["WO_NO"];

                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);


                BizRun.QBizRun.ExecuteService(
                 this, QBiz.emExecuteType.LOAD_DETAIL,
                 "PLN04A_SER4", paramSet, "RQSTDT", "RSLTDT",
                 QuickSearchSubDetail,
                 QuickException);
            }
            else
            {                
                acGridView3.ClearRow();
                return;
            }


        }


        void acGridView2_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.Clicks == 2 && e.Column.Name == "colCAUTION")
            {
                acBarButtonItem6_ItemClick(null, null);
            }
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
                 "PLN04A_SER3", paramSet, "RQSTDT", "RSLTDT",
                 QuickSearchDetail,
                 QuickException);
            }
            else
            {
                acGridView2.ClearRow();
                acGridView3.ClearRow();

                return;
            }


        }

        void acGridView1_ShowGridMenuEx(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            acGridView view = sender as acGridView;



            if (e.MenuType == GridMenuType.User)
            {
                acBarButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;//수정
                acBarButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;//신규
                acBarButtonItem3.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;//삭제

            }
            else if (e.MenuType == GridMenuType.Row)
            {
                if (e.HitInfo.RowHandle >= 0)
                {
                    acBarButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    acBarButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    acBarButtonItem3.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
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
                #region 수주
                acGridView1.GridType = acGridView.emGridType.SEARCH;

                //CodeHelperManager.RepositoryItemEmp edit = new CodeHelperManager.RepositoryItemEmp();

                //edit.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;                 
                //acGridView1.AddCustomEdit("LOCK_FLAG", "잠금상태", "", false, DevExpress.Utils.HorzAlignment.Center, true, true, false, edit);

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
                acGridView1.AddTextEdit("SCOMMENT", "전달사항", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

                acGridView1.AddDateEdit("REG_DATE", "최초 등록일", "UL1O77MB", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emDateMask.LONG_DATE);
                acGridView1.AddTextEdit("REG_EMP", "최초 등록자코드", "P72K0SQJ", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
                acGridView1.AddTextEdit("REG_EMP_NAME", "최초 등록자", "GPQHG8QQ", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
                acGridView1.AddDateEdit("MDFY_DATE", "최근 수정일", "6RXQO0B2", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emDateMask.LONG_DATE);
                acGridView1.AddTextEdit("MDFY_EMP", "최근 수정자코드", "WDHSCE72", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
                acGridView1.AddTextEdit("MDFY_EMP_NAME", "최근 수정자", "FHJDO4F0", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);

                acGridView1.KeyColumn = new string[] { "PROD_CODE" };
                #endregion

                #region 작업지시 그리드
                acGridView2.GridType = acGridView.emGridType.SEARCH;

                //acGridView2.AddCheckEdit("SEL", "선택", "", false, true, true, acGridView.emCheckEditDataType._STRING);                

                acGridView2.AddTextEdit("PART_CODE", "품목코드", "40239", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView2.AddTextEdit("PART_NAME", "품목명", "40234", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView2.AddLookUpEdit("WO_FLAG", "상태", "40278", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "S032");
                acGridView2.AddTextEdit("WO_NO", "작업지시번호", "40556", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView2.AddLookUpEdit("JOB_PRIORITY", "우선순위", "41914", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "W001");
                acGridView2.AddLookUpEdit("WORK_CODE", "재작업 사유", "42515", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "C108");
                acGridView2.AddTextEdit("PROC_CODE", "공정코드", "40920", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView2.AddTextEdit("PROC_NAME", "공정명", "40921", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView2.AddTextEdit("MC_CODE", "설비코드", "41162", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView2.AddTextEdit("MC_NAME", "설비명", "41202", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView2.AddTextEdit("EMP_CODE", "작업자코드", "40551", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView2.AddTextEdit("EMP_NAME", "작업자명", "40545", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView2.AddTextEdit("PLN_QTY", "계획수량", "NAFTT723", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.QTY);
                acGridView2.AddTextEdit("CAUTION", "주의사항", "D2FYBIE6", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView2.AddDateEdit("PLN_START_TIME", "계획시작시간", "N8Z1NIPS", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.MEDIUM_DATE);
                acGridView2.AddDateEdit("PLN_END_TIME", "계획완료시간", "O74LS73I", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.MEDIUM_DATE);
                acGridView2.AddTextEdit("PLN_PROC_TIME", "계획공수", "CLLN0WCV", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.TIME);
                acGridView2.AddTextEdit("MAN_TIME", "실적공수", "CLLN0WCV", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.TIME);
                //acGridView2.AddTextEdit("BAL_SPEC", "발주규격", "7MROZYWS", true, DevExpress.Utils.HorzAlignment.Near, false, false, false, acGridView.emTextEditMask.NONE);
                //acGridView2.AddTextEdit("BAL_WEIGHT", "발주중량", "GOC9BNEP", true, DevExpress.Utils.HorzAlignment.Near, false, false, false, acGridView.emTextEditMask.NONE);

                acGridView2.AddHidden("PROD_CODE", typeof(string));
                acGridView2.AddHidden("PART_ID", typeof(Int32));
                acGridView2.AddHidden("PROC_ID", typeof(Int32));
                acGridView2.AddHidden("IS_MAT", typeof(Int32));
                acGridView2.AddHidden("IS_OS", typeof(Int32));

                acGridView2.KeyColumn = new string[] { "WO_NO" };
                #endregion


                #region 실적 그리드 
                acGridView3.GridType = acGridView.emGridType.SEARCH;
                acGridView3.AddLookUpEdit("INPUT_FLAG", "입력구분", "UYJGZO3N", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "S039");
                acGridView3.AddDateEdit("WORK_DATE", "작업일", "40540", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
                acGridView3.AddTextEdit("EMP_CODE", "작업자코드", "40551", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView3.AddTextEdit("EMP_NAME", "작업자", "40542", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView3.AddTextEdit("MC_CODE", "설비코드", "41162", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView3.AddTextEdit("MC_NAME", "설비명", "41202", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView3.AddLookUpEdit("MC_NM_CHECK", "유/무인", "NVJLZWWQ", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, "S033");
                acGridView3.AddLookUpEdit("PROC_STAT", "공정상태", "41055", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, "S038");
                acGridView3.AddDateEdit("ACT_START_TIME", "시작시간", "N8Z1NIPS", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.MEDIUM_DATE);
                acGridView3.AddDateEdit("ACT_END_TIME", "완료시간", "O74LS73I", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.MEDIUM_DATE);
                //acGridView3.AddDateEdit("MAN_START_TIME", "실적시작시간", "50319", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.MEDIUM_DATE);
                //acGridView3.AddDateEdit("MAN_END_TIME", "실적완료시간", "50320", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.MEDIUM_DATE);
                //acGridView3.AddDateEdit("PRE_START_TIME", "준비시작시각", "RTWG2G0Q", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.MEDIUM_DATE);
                //acGridView3.AddDateEdit("PRE_END_TIME", "준비완료시각", "27CR70AY", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.MEDIUM_DATE);
                acGridView3.AddTextEdit("ACT_TIME", "가공시간(분)", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.TIME);
                acGridView3.AddTextEdit("OK_QTY", "실적수량", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
                //acGridView3.AddTextEdit("OT_TIME", "잔업 실적공수", "70NF0OEU", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.TIME);
                //acGridView3.AddTextEdit("PRE_TIME", "준비 실적공수", "IVNZDKSG", true, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.TIME);
                //acGridView3.AddTextEdit("SELF_TIME", "무인 실적공수", "DWNYLR5F", true, DevExpress.Utils.HorzAlignment.Far, false, false, false, acGridView.emTextEditMask.TIME);
                //acGridView3.AddTextEdit("PAUSE_TIME", "작업중지시간", "42640", true, DevExpress.Utils.HorzAlignment.Far, false, false, false, acGridView.emTextEditMask.TIME);
                //acGridView3.AddTextEdit("WORK_TIME", "실적공수", "40402", true, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.TIME);
                //acGridView3.AddTextEdit("WORK_QTY", "작업수량", "42643", true, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
                //acGridView3.AddTextEdit("OK_QTY", "양품수량", "42644", true, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
                //acGridView3.AddTextEdit("NG_QTY", "불량수량", "UGW32N5B", true, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
                acGridView3.AddDateEdit("REG_DATE", "최초 등록일", "UL1O77MB", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emDateMask.LONG_DATE);
                acGridView3.AddTextEdit("REG_EMP", "최초 등록자코드", "P72K0SQJ", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
                acGridView3.AddTextEdit("REG_EMP_NAME", "최초 등록자", "GPQHG8QQ", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
                acGridView3.AddDateEdit("MDFY_DATE", "최근 수정일", "6RXQO0B2", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emDateMask.LONG_DATE);
                acGridView3.AddTextEdit("MDFY_EMP", "최근 수정자코드", "WDHSCE72", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
                acGridView3.AddTextEdit("MDFY_EMP_NAME", "최근 수정자", "FHJDO4F0", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);

                acGridView3.KeyColumn = new string[] { "ACTUAL_ID" };
                #endregion

                acGridView4.GridType = acGridView.emGridType.AUTO_COL;

                acGridView4.AddTextEdit("CVND_CODE", "수주처코드", "FYVPQ9JZ", true, DevExpress.Utils.HorzAlignment.Near, false, false, false, acGridView.emTextEditMask.NONE);

                acGridView4.AddTextEdit("CVND_NAME", "업체", "40583", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

                acGridView4.AddTextEdit("WO_CNT", "작업", "WECL735S", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

                acGridView4.AddTextEdit("WO_END_CNT", "완료 작업", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);




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
            acGridView1.ClearRow();
            acGridView2.ClearRow();
            acGridView3.ClearRow();

            DataRow layoutRow = acLayoutControl1.CreateParameterRow();

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("CVND_LIKE", typeof(String)); //
            paramTable.Columns.Add("S_REG_DATE", typeof(String)); //등록 시작일
            paramTable.Columns.Add("E_REG_DATE", typeof(String)); //등록 종료일
            paramTable.Columns.Add("S_ORD_DATE", typeof(String)); //수주일 시작일
            paramTable.Columns.Add("E_ORD_DATE", typeof(String)); //수주일 종료일
            //paramTable.Columns.Add("S_DELIVERY_DATE", typeof(String)); //출하 시작일
            //paramTable.Columns.Add("E_DELIVERY_DATE", typeof(String)); //출하 종료일
            paramTable.Columns.Add("S_DUE_DATE", typeof(String)); //납기일 시작일
            paramTable.Columns.Add("E_DUE_DATE", typeof(String)); //납기일 종료일


            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["CVND_LIKE"] = layoutRow["CVND_LIKE"];
            //paramRow["PROD_STATE"] = "WK,PG";

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
                    //    paramRow["S_SHIP_DATE"] = layoutRow["S_DATE"];
                    //    paramRow["E_SHIP_DATE"] = layoutRow["E_DATE"];

                    //    break;
                }
            }

            paramTable.Rows.Add(paramRow);

            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);


            BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD, "PLN04A_SER", paramSet, "RQSTDT", "RSLTDT",
              QuickSearch,
              QuickException);

        }


        void QuickSearch(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {

                acGridView4.GridControl.DataSource = e.result.Tables["RSLTDT"];
                acGridView4.BestFitColumns();


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
                acGridView1.GridControl.DataSource = e.result.Tables["RSLTDT"];
                acGridView1.RaiseFocusedRowChanged();

                acGridView1.BestFitColumns();

                //base.SetLog(e.executeType, e.result.Tables["RSLTDT"].Rows.Count, e.executeTime);
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
                
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }


        void QuickSearchSubDetail(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                acGridView3.GridControl.DataSource = e.result.Tables["RSLTDT"];
                acGridView3.BestFitColumns();
                //base.SetLog(e.executeType, e.result.Tables["RSLTDT"].Rows.Count, e.executeTime);
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
            paramTable.Columns.Add("WP_NO", typeof(String)); //
            paramTable.Columns.Add("DEL_EMP", typeof(String)); //

            DataView selectedView = acGridView1.GetDataView("SEL = '1'");

            if (selectedView.Count == 0)
            {
                DataRow focusRow = acGridView1.GetFocusedDataRow();

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["WP_NO"] = focusRow["WP_NO"];
                paramRow["DEL_EMP"] = acInfo.UserID;

                paramTable.Rows.Add(paramRow);
            }
            else
            {
                for (int i = 0; i < selectedView.Count; i++)
                {
                    DataRow paramRow = paramTable.NewRow();
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["WP_NO"] = selectedView[i]["WP_NO"];
                    paramRow["DEL_EMP"] = acInfo.UserID;

                    paramTable.Rows.Add(paramRow);
                }
            }

            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            BizRun.QBizRun.ExecuteService(
                  this, QBiz.emExecuteType.DEL,
                  "PLN04A_DEL", paramSet, "RQSTDT", "",
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

        //신규
        //private void acBarButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        //{
        //    try
        //    {
        //        if (acGridView1.ValidFocusRowHandle() == false)
        //        {
        //            return;
        //        }

        //        DataRow linkRow = acLayoutControl1.CreateParameterRow();


        //        string formKey = string.Format("{0},{1}", "WP_NO", "");

        //        if (!base.ChildFormContains(formKey))
        //        {

        //            PLN03A_D0A frm = new PLN03A_D0A(acGridView1, acGridView2, linkRow);

        //            frm.DialogMode = BaseMenuDialog.emDialogMode.NEW;

        //            frm.ParentControl = this;

        //            base.ChildFormAdd(formKey, frm);

        //            frm.Show(this);

        //        }
        //        else
        //        {
        //            base.ChildFormFocus(formKey);

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        acMessageBox.Show(this, ex);
        //    }
        //}

        //확정
        private void acBarButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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

            DataView selectedView = acGridView2.GetDataView("SEL = '1'");

            if (selectedView.Count == 0)
            {
                DataRow focusRow = acGridView2.GetFocusedDataRow();
                if (focusRow == null) return;
                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["ITEM_CODE"] = focusRow["ITEM_CODE"]; 
                paramRow["PROD_CODE"] = focusRow["PROD_CODE"];
                paramRow["WO_NO"] = focusRow["WO_NO"];
                paramRow["WO_FLAG"] = "1";
                paramRow["REG_EMP"] = acInfo.UserID;
                paramRow["IS_MAT"] = focusRow["IS_MAT"];
                paramRow["WP_NO"] = focusRow["WP_NO"];

                paramTable.Rows.Add(paramRow);

            }
            else
            {
                for (int i = 0; i < selectedView.Count; i++)
                {
                    DataRow paramRow = paramTable.NewRow();
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["ITEM_CODE"] = selectedView[i]["ITEM_CODE"];
                    paramRow["PROD_CODE"] = selectedView[i]["PROD_CODE"];
                    paramRow["WO_NO"] = selectedView[i]["WO_NO"];
                    paramRow["WO_FLAG"] = "1";
                    paramRow["REG_EMP"] = acInfo.UserID;
                    paramRow["IS_MAT"] = selectedView[i]["IS_MAT"];
                    paramRow["WP_NO"] = selectedView[i]["WP_NO"];

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

            DataView selectedView = acGridView2.GetDataView("SEL = '1'");

            if (selectedView.Count == 0)
            {
                DataRow focusRow = acGridView2.GetFocusedDataRow();
                if (focusRow == null) return;
                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["ITEM_CODE"] = focusRow["ITEM_CODE"];
                paramRow["PROD_CODE"] = focusRow["PROD_CODE"];
                paramRow["WO_NO"] = focusRow["WO_NO"];
                paramRow["WO_FLAG"] = "0";
                paramRow["REG_EMP"] = acInfo.UserID;
                paramRow["IS_MAT"] = focusRow["IS_MAT"];
                paramRow["WP_NO"] = focusRow["WP_NO"];

                paramTable.Rows.Add(paramRow);

            }
            else
            {
                for (int i = 0; i < selectedView.Count; i++)
                {
                    DataRow paramRow = paramTable.NewRow();
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["ITEM_CODE"] = selectedView[i]["ITEM_CODE"];
                    paramRow["PROD_CODE"] = selectedView[i]["PROD_CODE"];
                    paramRow["WO_NO"] = selectedView[i]["WO_NO"];
                    paramRow["WO_FLAG"] = "0";
                    paramRow["REG_EMP"] = acInfo.UserID;
                    paramRow["IS_MAT"] = selectedView[i]["IS_MAT"];
                    paramRow["WP_NO"] = selectedView[i]["WP_NO"];

                    paramTable.Rows.Add(paramRow);
                }

            }

            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);


            BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.SAVE, "PLN03A_SAVE2", paramSet, "RQSTDT", "RSLTDT",
                        QuickSave,
                        QuickException);
        }


        void QuickSave(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                foreach (DataRow row in e.result.Tables["RSLTDT"].Rows)
                {

                    acGridView2.UpdateMapingRow(row, false);
                }

                //acMessageBox.Show(" 처리되었습니다.", this.Caption, acMessageBox.emMessageBoxType.CONFIRM);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

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

                    DataView selected = acGridView2.GetDataSourceView("SEL = '1'");

                    if (selected.Count == 0)
                    {
                        //단일선택
                        DataRow paramRow = paramTable.NewRow();
                        paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                        paramRow["WO_NO"] = focusRow["WO_NO"];
                        paramRow["CAUTION"] = output["CAUTION"];

                        paramTable.Rows.Add(paramRow);
                    }
                    else
                    {
                        //다중선택
                        for (int i = 0; i < selected.Count; i++)
                        {
                            DataRow paramRow = paramTable.NewRow();
                            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                            paramRow["WO_NO"] = selected[i]["WO_NO"];
                            paramRow["CAUTION"] = output["CAUTION"];

                            paramTable.Rows.Add(paramRow);
                        }
                    }


                    DataSet paramSet = new DataSet();
                    paramSet.Tables.Add(paramTable);

                    BizRun.QBizRun.ExecuteService(
                    this, QBiz.emExecuteType.SAVE, "PLN03A_UPD", paramSet, "RQSTDT", "RSLTDT",
                    QuickSaveClose,
                    QuickException);
                }
            }
            else
            {
                base.ChildFormFocus(formKey);

            }
        }

        void QuickSaveClose(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
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
                DataRow masterRow = acGridView1.GetFocusedDataRow();

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
                        paramTable.Columns.Add("WORK_CODE", typeof(String));

                        DataRow paramRow = paramTable.NewRow();
                        paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                        paramRow["WO_NO"] = focusRow["WO_NO"];
                        paramRow["WORK_CODE"] = dr["WORK_CODE"];

                        paramTable.Rows.Add(paramRow);
                        
                        DataTable paramTable2 = new DataTable("RQSTDT_M");
                        paramTable2.Columns.Add("PLT_CODE", typeof(String)); //

                        paramTable2.Columns.Add("PROD_CODE", typeof(String)); //
        
                        DataRow paramRow2 = paramTable2.NewRow();
                        paramRow2["PLT_CODE"] = acInfo.PLT_CODE;
                        paramRow2["PROD_CODE"] = masterRow["PROD_CODE"];
 

                        paramTable2.Rows.Add(paramRow2);

                        DataSet paramSet = new DataSet();
                        paramSet.Tables.Add(paramTable);
                        paramSet.Tables.Add(paramTable2);

                        DataTable dtResult = BizRun.QBizRun.ExecuteService(this, "PLN03A_SAVE3", paramSet, "RQSTDT", "RSLTDT").Tables["RSLTDT"];

                        acGridView2.GridControl.DataSource = dtResult;


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
            ////지시 삭제
            //try
            //{

            //    DataRow focusRow = acGridView2.GetFocusedDataRow();


            //    if (focusRow == null) return;
            //    //미확정 혹은 확정인 작업지시만 삭제 가능
            //    if (focusRow["WO_FLAG"].ToString() == "1" || focusRow["WO_FLAG"].ToString() == "0")
            //    {
            //        if (acMessageBox.Show("선택한 지시를 삭제하시겠습니까? ", "작업지시 삭제", acMessageBox.emMessageBoxType.YESNO) == DialogResult.Yes)
            //        {
                        
            //            DataTable paramTable = new DataTable("RQSTDT");
            //            paramTable.Columns.Add("PLT_CODE", typeof(String));
            //            paramTable.Columns.Add("WO_NO", typeof(String));
            //            paramTable.Columns.Add("IS_MAT", typeof(String));

            //            DataRow paramRow = paramTable.NewRow();
            //            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            //            paramRow["WO_NO"] = focusRow["WO_NO"];
            //            paramRow["IS_MAT"] = focusRow["IS_MAT"];
                        
            //            paramTable.Rows.Add(paramRow);

            //            DataTable paramTable2 = new DataTable("RQSTDT_M");
            //            paramTable2.Columns.Add("PLT_CODE", typeof(String)); //
            //            paramTable2.Columns.Add("WP_NO", typeof(String)); //
            //            paramTable2.Columns.Add("PROD_CODE", typeof(String)); //
            //            paramTable2.Columns.Add("PART_CODE", typeof(String)); //

            //            DataRow paramRow2 = paramTable2.NewRow();
            //            paramRow2["PLT_CODE"] = acInfo.PLT_CODE;
            //            paramRow2["WP_NO"] = focusNode["WP_NO"];
            //            paramRow2["PROD_CODE"] = focusNode["PROD_CODE"];
            //            paramRow2["PART_CODE"] = focusNode["PART_CODE"];

            //            paramTable2.Rows.Add(paramRow2);

            //            DataSet paramSet = new DataSet();
            //            paramSet.Tables.Add(paramTable);
            //            paramSet.Tables.Add(paramTable2);

            //            DataTable dtResult = BizRun.QBizRun.ExecuteService(this, "PLN03A_SAVE4", paramSet, "RQSTDT", "RSLTDT").Tables["RSLTDT"];

            //            acGridView2.GridControl.DataSource = dtResult;


            //            acMessageBox.Show("삭제 처리되었습니다. ", "작업지시 삭제", acMessageBox.emMessageBoxType.CONFIRM);
            //        }
                    
            //    }
            //    else
            //    {
            //        acMessageBox.Show("작업지시 삭제는 [미확정] 혹은 [확정]된 작업만 가능합니다. ", "작업지시 삭제", acMessageBox.emMessageBoxType.CONFIRM);

            //    }
            //}
            //catch (Exception ex)
            //{
            //    acMessageBox.Show(this, ex);
            //}
        }
    }
}
