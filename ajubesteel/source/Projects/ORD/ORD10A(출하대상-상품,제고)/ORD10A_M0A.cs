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
using POP;
using System.IO;

namespace ORD
{
    public sealed partial class ORD10A_M0A : BaseMenu
    {

        private GridHitInfo _downHitInfo = null;

        public ORD10A_M0A()
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

        private enum emOption
        {
            //계획일정
            PLN_TIME,

            //지시상태
            WO_STATE,

            //도형
            WO_FIG

        }

        private emOption _viewOpt = emOption.PLN_TIME;

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
            return base.MenuDestory(sender);

        }


        public override void MenuLink(object data)
        {
 
        }

        public override void MenuInit()
        {

            acGridView1.GridType = acGridView.emGridType.SEARCH_SEL;

            acGridView1.AddLookUpEdit("PROD_STATE", "수주상태", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P012");
            acGridView1.AddLookUpEdit("ITEM_FLAG", "수주구분", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P027");
            //acGridView1.AddCheckEdit("LOCK_FLAG", "잠금", "", false, false, true, acGridView.emCheckEditDataType._BYTE);            
            //acGridView1.AddLookUpEmp("LOCK_EMP", "잠금자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false);
            acGridView1.AddTextEdit("PROD_CODE", "수주번호", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("PROD_NAME", "모델명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("PROD_VERSION", "버전", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddLookUpEdit("PROD_KIND", "제품구분", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "C011");
            acGridView1.AddLookUpEdit("PROC_FLAG", "공정명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P005");
            acGridView1.AddLookUpEdit("PROD_FLAG", "유형", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P006");
            acGridView1.AddLookUpEdit("INS_YN", "성적서", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P007");
            //acGridView1.AddLookUpEdit("SOCKET_YN", "소켓측정", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P007");            
            acGridView1.AddCheckedComboBoxEdit("PROD_CATEGORY", "제품유형", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, "P009");
            //acGridView1.AddTextEdit("BUSINESS_EMP", "영업담당자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddLookUpEmp("BUSINESS_EMP", "영업담당자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false);
            acGridView1.AddTextEdit("CUSTOMER_EMP", "고객담당자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            //acGridView1.AddLookUpEmp("CUSTOMER_EMP", "고객담당자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false);
            acGridView1.AddTextEdit("CUSTDESIGN_EMP", "고객설계자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            //acGridView1.AddLookUpEmp("CUSTDESIGN_EMP", "고객설계자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false);
            acGridView1.AddLookUpEdit("ACTUATOR_YN", "Actuator유무", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "S101");

            acGridView1.AddTextEdit("PO_NO", "PO No", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

            //acGridView1.AddTextEdit("CVND_CODE", "발주처코드", "CPW0FS8W", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("CVND_NAME", "발주처", "CPW0FS8W", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            //acGridView1.AddTextEdit("TVND_CODE", "계산서 발행처 코드", "CPW0FS8W", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("TVND_NAME", "계산서 발행처", "CPW0FS8W", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("PROD_QTY", "수량", "CPW0FS8W", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NUMERIC);
            //acGridView1.AddTextEdit("SHIP_QTY", "출하수량", "CPW0FS8W", false, DevExpress.Utils.HorzAlignment.Far, true, true, true, acGridView.emTextEditMask.QTY);
            acGridView1.AddTextEdit("OLD_SHIP_QTY", "기존출하수량", "CPW0FS8W", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NUMERIC);
            //acGridView1.AddLookUpEdit("PROD_LOCATION", "창고", "", false, DevExpress.Utils.HorzAlignment.Center, true, true, true, "M042");

            acGridView1.AddDateEdit("ORD_DATE", "수주일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
            acGridView1.AddDateEdit("DUE_DATE", "출하예정일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
            acGridView1.AddDateEdit("CHG_DUE_DATE", "출하조정일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
            //acGridView1.AddDateEdit("DELIVERY_DATE", "납품일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);

            //acGridView1.AddCheckedComboBoxEdit("PROBE_PIN", "Contact", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, "P011");
            acGridView1.AddLookUpEdit("PIN_TYPE", "Contact", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P011");
            acGridView1.AddLookUpEdit("PROD_TYPE", "제품분류", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P010");
            acGridView1.AddTextEdit("EST_COST", "견적단가", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
            acGridView1.AddTextEdit("PROD_COST", "공급단가", "CPW0FS8W", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
            acGridView1.AddTextEdit("PROD_AMT", "총금액", "CPW0FS8W", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
            acGridView1.AddCheckEdit("ORD_VAT", "VAT별도", "", false, false, true, acGridView.emCheckEditDataType._STRING);
            acGridView1.AddLookUpEdit("CURR_UNIT", "통화", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P008");

            //acGridView1.AddLookUpEdit("TRADE_YN", "거래명세표", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P007");
            //acGridView1.AddLookUpEdit("TAX_YN", "세금계산서", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P007");
            //acGridView1.AddLookUpEdit("BILL_YN", "수금등록", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P007");

            //acGridView1.AddMemoEdit("REMARK", "특기사항", "", false, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, false, true, true, false);
            //acGridView1.AddMemoEdit("SCOMMENT", "전달사항", "", false, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, false, true, true, false);

            acGridView1.AddDateEdit("REG_DATE", "최초 등록일", "UL1O77MB", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emDateMask.LONG_DATE);
            acGridView1.AddTextEdit("REG_EMP", "최초 등록자코드", "P72K0SQJ", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("REG_EMP_NAME", "최초 등록자", "GPQHG8QQ", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddDateEdit("MDFY_DATE", "최근 수정일", "6RXQO0B2", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emDateMask.LONG_DATE);
            acGridView1.AddTextEdit("MDFY_EMP", "최근 수정자코드", "WDHSCE72", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("MDFY_EMP_NAME", "최근 수정자", "FHJDO4F0", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);

            acGridView1.KeyColumn = new string[] { "PROD_CODE" };



            acCheckedComboBoxEdit1.AddItem("등록일", false, "", "REG_DATE", true, false);
            acCheckedComboBoxEdit1.AddItem("수주일", false, "", "ORD_DATE", true, false);
            acCheckedComboBoxEdit1.AddItem("출하예정일", false, "", "DUE_DATE", true, false);
            //acCheckedComboBoxEdit1.AddItem("납품일", false, "", "DELIVERY_DATE", true, false);

            this.acLayoutControl1.OnValueKeyDown += new acLayoutControl.ValueKeyDownEventHandler(acLayoutControl1_OnValueKeyDown);
            this.acLayoutControl1.OnValueChanged += new acLayoutControl.ValueChangedEventHandler(acLayoutControl1_OnValueChanged);

            this.acGridView1.ShowGridMenuEx += new acGridView.ShowGridMenuExHandler(acGridView1_ShowGridMenuEx);

            this.acGridView1.CustomDrawCell += AcGridView1_CustomDrawCell;
            this.acGridView1.OnMapingRowChanged += new acGridView.MapingRowChangedEventHandler(acGridView1_OnMapingRowChanged);

            this.acGridView1.CellValueChanged += acGridView1_CellValueChanged;


            base.MenuInit();
        }

        private void acGridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            acGridView1.SelectRow(e.RowHandle);
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
                }
            }
            catch
            {

            }
        }

        void acGridView1_OnMapingRowChanged(acGridView.emMappingRowChangedType type, DataRow row)
        {
            if (type == acGridView.emMappingRowChangedType.DELETE)
            {
                string formKey = string.Format("{0},{1}", "PROD_CODE", row["PROD_CODE"]);

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





        public override void ChildContainerInit(Control sender)
        {
            //기본값 설정

            if (sender == acLayoutControl1)
            {


                acLayoutControl layout = sender as acLayoutControl;

                layout.GetEditor("DATE").Value = "REG_DATE";
                layout.GetEditor("S_DATE").Value = acDateEdit.GetNowFirstDate();
                layout.GetEditor("E_DATE").Value = acDateEdit.GetNowLastDate();


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
                    //case "SHIP_DATE":
                    //    //출하일
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
             "ORD10A_SER", paramSet, "RQSTDT", "RSLTDT",
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

        public override void DataRefresh(object data)
        {
            if (data.EqualsEx("ITEM"))
            {
                if (base.IsData(data))
                {
                    DataSet refreshSet = base.GetData(data) as DataSet;

                    refreshSet.Tables.Remove("RSLTDT");

                    BizRun.QBizRun.ExecuteService(
                 this, QBiz.emExecuteType.REFRESH,
                 "ORD03A_SER", refreshSet, "RQSTDT", "RSLTDT",
                 QuickSearch,
                 QuickException);

                }

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


        //private void acBarButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        //{
        //    //새로만들기 수주 편집기
        //    try
        //    {
        //        if (!base.ChildFormContains("NEW_ITEM"))
        //        {
        //            ORD02A_D1A frm = new ORD02A_D1A(acGridView1, "NEW_ITEM");

        //            frm.DialogMode = BaseMenuDialog.emDialogMode.NEW;

        //            frm.ParentControl = this;

        //            base.ChildFormAdd("NEW_ITEM", frm);

        //            frm.Show(this);


        //        }
        //        else
        //        {
        //            base.ChildFormFocus("NEW_ITEM");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        acMessageBox.Show(this, ex);
        //    }

        //}



        //private void acBarButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        //{
        //    //열기 수주편집기

        //    try
        //    {
        //        if (acGridView1.ValidFocusRowHandle() == false)
        //        {
        //            return;
        //        }


        //        DataRow focusRow = acGridView1.GetFocusedDataRow();


        //        string formKey = string.Format("{0},{1}", "ITEM", focusRow["ITEM_CODE"]);

        //        if (!base.ChildFormContains(formKey))
        //        {

        //            ORD02A_D1A frm = new ORD02A_D1A(acGridView1, focusRow);

        //            frm.DialogMode = BaseMenuDialog.emDialogMode.OPEN;

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

        /// <summary>
        /// 출하장 인쇄
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnShipPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //acGridView1.EndEditor();

            //if (acGridView1.RowCount == 0) return;

            //DataRow[] selectedRows = acGridView1.GetSelectedDataRows();

            ////if (selectedRows.Length == 0)
            ////{
            ////    acMessageBox.Show("선택된 데이터가 없습니다.", "확인", acMessageBox.emMessageBoxType.CONFIRM);
            ////    return;
            ////}


            //DataTable paramTable1 = new DataTable("RQSTDT");
            //paramTable1.Columns.Add("PLT_CODE", typeof(String)); //
            //paramTable1.Columns.Add("PROD_CODE", typeof(String)); //
            //paramTable1.Columns.Add("LOCK_FLAG", typeof(String)); //
            //paramTable1.Columns.Add("LOCK_EMP", typeof(String)); //


            //if (selectedRows.Length == 0)
            //{
            //    //acMessageBox.Show("선택된 데이터가 없습니다.", "확인", acMessageBox.emMessageBoxType.CONFIRM);
            //    //return;
            //    DataRow dr = acGridView1.GetFocusedDataRow();
            //    DataRow paramRow1 = paramTable1.NewRow();
            //    paramRow1["PLT_CODE"] = acInfo.PLT_CODE;
            //    paramRow1["PROD_CODE"] = dr["PROD_CODE"];
            //    paramRow1["LOCK_FLAG"] = "0";
            //    paramRow1["LOCK_EMP"] = acInfo.UserID;

            //    paramTable1.Rows.Add(paramRow1);
            //}
            //else
            //{
            //    foreach (DataRow dr in selectedRows)
            //    {
            //        DataRow paramRow1 = paramTable1.NewRow();
            //        paramRow1["PLT_CODE"] = acInfo.PLT_CODE;
            //        paramRow1["PROD_CODE"] = dr["PROD_CODE"];
            //        paramRow1["LOCK_FLAG"] = "0";
            //        paramRow1["LOCK_EMP"] = acInfo.UserID;

            //        paramTable1.Rows.Add(paramRow1);
            //    }
            //}
            //DataSet paramSet = new DataSet();
            //paramSet.Tables.Add(paramTable1);

            //BizRun.QBizRun.ExecuteService(
            //this, QBiz.emExecuteType.SAVE,
            //"ORD03A_PRINT", paramSet, "RQSTDT", "RSLTDT",
            //QuickShipPrint,
            //QuickException);
        }


        void QuickShipPrint(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                //foreach (DataRow row in e.result.Tables["RSLTDT"].Rows)
                //{
                //    this.acGridView1.UpdateMapingRow(row, true);
                //}

                this.acGridView1.ClearSelection();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        /// <summary>
        /// 출하지시 요청
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnShip_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            acGridView1.EndEditor();

            //if (!acGridView1.ValidCheck())
            //    return;

            //DataRow[] selectedRows = acGridView1.GetSelectedDataRows();

            DataRow focusRow = acGridView1.GetFocusedDataRow();

            if (focusRow == null)
            {
                acMessageBox.Show("선택된 데이터가 없습니다.", "확인", acMessageBox.emMessageBoxType.CONFIRM);
                return;
            }

            ORD10A_D0A frm = new ORD10A_D0A(acGridView1, focusRow);
            frm.ParentControl = this;
            frm.ShowDialog(this);

            if (frm.DialogResult != DialogResult.OK)
                return;

            //DataRow outputRow = frm.OutputData as DataRow;

            //DataTable paramTable1 = new DataTable("RQSTDT");
            //paramTable1.Columns.Add("PLT_CODE", typeof(String)); //
            //paramTable1.Columns.Add("PROD_CODE", typeof(String)); //
            //paramTable1.Columns.Add("SHIP_QTY", typeof(int)); //
            //paramTable1.Columns.Add("SHIP_DATE", typeof(String)); //
            //paramTable1.Columns.Add("SHIP_EMP", typeof(String)); //
            //paramTable1.Columns.Add("PROD_LOCATION", typeof(String)); //
            //paramTable1.Columns.Add("SCOMMENT", typeof(String)); //
            //paramTable1.Columns.Add("REG_EMP", typeof(String)); //

            //foreach (DataRow dr in selectedRows)
            //{
            //    if(dr["PROD_LOCATION"].isNullOrEmpty())
            //    {
            //        acAlert.Show(this, "창고를 지정 해 주십시오.", acAlertForm.enmType.Error);
            //        return;
            //    }


            //    DataRow paramRow1 = paramTable1.NewRow();
            //    paramRow1["PLT_CODE"] = acInfo.PLT_CODE;
            //    paramRow1["PROD_CODE"] = dr["PROD_CODE"];
            //    paramRow1["SHIP_QTY"] = dr["SHIP_QTY"];
            //    paramRow1["SHIP_DATE"] = outputRow["SHIP_DATE"];
            //    paramRow1["SHIP_EMP"] = outputRow["SHIP_EMP"];
            //    paramRow1["PROD_LOCATION"] = dr["PROD_LOCATION"];
            //    paramRow1["SCOMMENT"] = outputRow["SCOMMENT"];
            //    paramRow1["REG_EMP"] = acInfo.UserID;

            //    paramTable1.Rows.Add(paramRow1);
            //}

            //DataSet paramSet = new DataSet();
            //paramSet.Tables.Add(paramTable1);

            //BizRun.QBizRun.ExecuteService(
            //this, QBiz.emExecuteType.SAVE,
            //"ORD10A_UPD", paramSet, "RQSTDT", "RSLTDT",
            //QuickShip,
            //QuickException);
        }

        void QuickShip(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                foreach (DataRow row in e.result.Tables["RQSTDT"].Rows)
                {
                    this.acGridView1.DeleteMappingRow(row);
                }

                this.acGridView1.ClearSelection();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        /// <summary>
        /// 출하지시 취소
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReturn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            acGridView1.EndEditor();

            DataRow[] selectedRows = acGridView1.GetSelectedDataRows();

            if (selectedRows.Length == 0)
            {
                acMessageBox.Show("선택된 데이터가 없습니다.", "확인", acMessageBox.emMessageBoxType.CONFIRM);
                return;
            }


            DataTable paramTable1 = new DataTable("RQSTDT");
            paramTable1.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable1.Columns.Add("PROD_CODE", typeof(String)); //
            paramTable1.Columns.Add("REG_EMP", typeof(String)); //

            foreach (DataRow dr in selectedRows)
            {
                if (dr["PROD_STATE"].ToString() == "8")
                {
                    acMessageBox.Show("부분출하인 경우 취소할 수 없습니다.", "확인", acMessageBox.emMessageBoxType.CONFIRM);
                    return;
                }

                DataRow paramRow1 = paramTable1.NewRow();
                paramRow1["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow1["PROD_CODE"] = dr["PROD_CODE"];
                paramRow1["REG_EMP"] = acInfo.UserID;

                paramTable1.Rows.Add(paramRow1);
            }

            if (acMessageBox.Show(this, "출하지시 취소하시겠습니까?", "", false, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
            {
                return;
            }

            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable1);

            BizRun.QBizRun.ExecuteService(
            this, QBiz.emExecuteType.SAVE,
            "ORD10A_RETURN", paramSet, "RQSTDT", "RSLTDT",
            QuickShipReturn,
            QuickException);
        }

        void QuickShipReturn(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                foreach (DataRow row in e.result.Tables["RQSTDT"].Rows)
                {
                    this.acGridView1.DeleteMappingRow(row);
                }

                this.acGridView1.ClearSelection();
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

                    string replacePath = dsRslt.Tables["RSLTDT"].Rows[0]["PART_FILE_PATH"].ToString().Substring(iSeq, dsRslt.Tables["RSLTDT"].Rows[0].ToString().Length - iSeq);

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

        private void acBarButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //출하
            acGridView1.EndEditor();

            DataRow focusRow = acGridView1.GetFocusedDataRow();

            if (focusRow == null)
            {
                acMessageBox.Show("선택된 데이터가 없습니다.", "확인", acMessageBox.emMessageBoxType.CONFIRM);
                return;
            }

            ORD10A_D2A frm = new ORD10A_D2A(acGridView1, focusRow);
            frm.ParentControl = this;
            frm.ShowDialog(this);

            if (frm.DialogResult != DialogResult.OK)
                return;
        }
    }
}
