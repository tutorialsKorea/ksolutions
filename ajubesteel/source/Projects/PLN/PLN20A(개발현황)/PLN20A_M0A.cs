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
using DevExpress.XtraEditors.Repository;
using POP;

namespace PLN
{
    public sealed partial class PLN20A_M0A : BaseMenu
    {

        private GridHitInfo _downHitInfo = null;

        public PLN20A_M0A()
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

            DataRow linkRow = data as DataRow;

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("PROD_CODE", typeof(String)); //
            paramTable.Columns.Add("STATES", typeof(String)); //

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["PROD_CODE"] = linkRow["PROD_CODE"];

            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            BizRun.QBizRun.ExecuteService(
             this, QBiz.emExecuteType.LOAD,
             "PLN20A_SER", paramSet, "RQSTDT", "RSLTDT",
             QuickSearch,
             QuickException);
        }

        private Dictionary<string, string> _dicProcStat = null;
        private DataTable _dtProcList = null;
        //private Hashtable _htWoList = null;
        //private Hashtable _htWoFig = null;

      

        public override void MenuInit()
        {

            // acGridView1.GridType = acGridView.emGridType.SEARCH_SEL;
            acGridView1.GridType = acGridView.emGridType.SEARCH;

            acGridView1.AddLookUpEdit("PROD_STATE", "수주상태", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P012");
            //acGridView1.AddCheckEdit("LOCK_FLAG", "잠금상태", "", false, false, true, acGridView.emCheckEditDataType._BYTE);            
            //acGridView1.AddLookUpEmp("LOCK_EMP", "잠금자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false);
            acGridView1.AddLookUpEdit("PROD_PRIORITY", "우선순위", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P028");
            acGridView1.AddTextEdit("PROD_CODE", "수주번호", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("CVND_NAME", "발주처", "CPW0FS8W", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddLookUpEmp("BUSINESS_EMP", "영업담당자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false);
            acGridView1.AddTextEdit("PROD_NAME", "모델명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            //acGridView1.AddTextEdit("PROD_VERSION", "버전", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            //acGridView1.AddLookUpEdit("PROC_FLAG", "공정명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P005");
            //acGridView1.AddLookUpEdit("INS_YN", "성적서", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P007");
            //acGridView1.AddLookUpEdit("SOCKET_YN", "소켓측정", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P007");            
            acGridView1.AddCheckedComboBoxEdit("PROD_CATEGORY", "제품유형", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, "P009");
            acGridView1.AddLookUpEdit("PROD_FLAG", "수주유형", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P006");
            acGridView1.AddLookUpEdit("PROD_TYPE", "제품분류", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P010");
            //acGridView1.AddTextEdit("BUSINESS_EMP", "영업담당자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            //acGridView1.AddLookUpEmp("BUSINESS_EMP", "영업담당자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false);
            //acGridView1.AddTextEdit("CUSTOMER_EMP", "고객담당자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            //acGridView1.AddLookUpEmp("CUSTOMER_EMP", "고객담당자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false);
            //acGridView1.AddTextEdit("CUSTDESIGN_EMP", "고객설계자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            //acGridView1.AddLookUpEmp("CUSTDESIGN_EMP", "고객설계자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false);
            //acGridView1.AddLookUpEdit("ACTUATOR_YN", "Actuator유무", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "S101");

            //acGridView1.AddTextEdit("CVND_CODE", "발주처코드", "CPW0FS8W", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            //acGridView1.AddTextEdit("CVND_NAME", "발주처", "CPW0FS8W", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            //acGridView1.AddTextEdit("TVND_CODE", "계산서 발행처 코드", "CPW0FS8W", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            //acGridView1.AddTextEdit("TVND_NAME", "계산서 발행처", "CPW0FS8W", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("PROD_QTY", "수량", "CPW0FS8W", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NUMERIC);
            acGridView1.AddCheckEdit("ASSY_CHG_FLAG", "I/F 조립품 변경여부", "", false, true, true, acGridView.emCheckEditDataType._STRING);
            acGridView1.AddCheckEdit("BOM_FLAG", "BOM", "", false, false, true, acGridView.emCheckEditDataType._INT);
            acGridView1.AddDateEdit("ORD_DATE", "수주일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
            acGridView1.AddDateEdit("DUE_DATE", "출하예정일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
            acGridView1.AddLookUpEmp("CUSTDESIGN_EMP", "고객설계자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false);

            acGridView1.AddDateEdit("PLN_DATE", "예정일", "", false, DevExpress.Utils.HorzAlignment.Center, true, true, false, acGridView.emDateMask.SHORT_DATE);
            acGridView1.AddDateEdit("FIN_DATE", "완료일", "", false, DevExpress.Utils.HorzAlignment.Center, true, true, false, acGridView.emDateMask.SHORT_DATE);

            RepositoryItemHyperLinkEdit repItemHLE = new RepositoryItemHyperLinkEdit();
            repItemHLE.NullText = "조회";
            acGridView1.AddCustomEdit("PROD_SPEC", "제작사양조회", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, repItemHLE);
            acGridView1.RowClick += AcGridView1_RowClick;


            //acGridView1.AddTextEdit("DRAW_IMAGE", "설계도면", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("DRAW_EMP", "설계자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddLookUpEmp("DEV_EMP", "개발담당자", "", false, DevExpress.Utils.HorzAlignment.Center, true, true, false, "IS_DEV = '1'");


            acGridView1.AddCheckEdit("IS_DRAW", "도면업로드", "", false, true, true, acGridView.emCheckEditDataType._STRING);
            acGridView1.AddTextEdit("DRAW_DIR", "도면경로", "", false, DevExpress.Utils.HorzAlignment.Near, true, true, false, acGridView.emTextEditMask.NONE);


            //acGridView1.AddDateEdit("CHG_DUE_DATE", "출하조정일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
            //acGridView1.AddDateEdit("DELIVERY_DATE", "납품일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);

            //acGridView1.AddCheckedComboBoxEdit("PROBE_PIN", "Probe Pin", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, "P011");
            //acGridView1.AddLookUpEdit("PROD_TYPE", "제품분류", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P010");
            // acGridView1.AddTextEdit("PROD_QTY", "수량", "CPW0FS8W", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NUMERIC);
            //acGridView1.AddTextEdit("PROD_COST", "공급단가", "CPW0FS8W", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
            //acGridView1.AddTextEdit("PROD_AMT", "총금액", "CPW0FS8W", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
            //acGridView1.AddCheckEdit("ORD_VAT", "VAT별도", "", false, false, true, acGridView.emCheckEditDataType._STRING);
            //acGridView1.AddLookUpEdit("CURR_UNIT", "통화", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P008");

            //acGridView1.AddLookUpEdit("TRADE_YN", "거래명세표", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P007");
            //acGridView1.AddLookUpEdit("TAX_YN", "세금계산서", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P007");
            //acGridView1.AddLookUpEdit("BILL_YN", "수금등록", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P007");

            //acGridView1.AddMemoEdit("REMARK", "특기사항", "", false, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, false, true, true, false);
            //acGridView1.AddMemoEdit("SCOMMENT", "전달사항", "", false, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, false, true, true, false);

            //acGridView1.AddDateEdit("REG_DATE", "최초 등록일", "UL1O77MB", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emDateMask.LONG_DATE);
            //acGridView1.AddTextEdit("REG_EMP", "최초 등록자코드", "P72K0SQJ", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            //acGridView1.AddTextEdit("REG_EMP_NAME", "최초 등록자", "GPQHG8QQ", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            //acGridView1.AddDateEdit("MDFY_DATE", "최근 수정일", "6RXQO0B2", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emDateMask.LONG_DATE);
            //acGridView1.AddTextEdit("MDFY_EMP", "최근 수정자코드", "WDHSCE72", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            //acGridView1.AddTextEdit("MDFY_EMP_NAME", "최근 수정자", "FHJDO4F0", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);

            acGridView1.KeyColumn = new string[] { "PROD_CODE" };


            //acCheckedComboBoxEdit1.AddItem("등록일", false, "", "REG_DATE", true, false);
            //acCheckedComboBoxEdit1.AddItem("수주일", false, "", "ORD_DATE", true, false);
            //acCheckedComboBoxEdit1.AddItem("납기일", false, "", "DUE_DATE", true, false);
            //acCheckedComboBoxEdit1.AddItem("납품일", false, "", "DELIVERY_DATE", true, false);

            acCheckedComboBoxEdit1.AddItem("P012", 1, 0, CheckState.Unchecked);
            
            this.acLayoutControl1.OnValueKeyDown += new acLayoutControl.ValueKeyDownEventHandler(acLayoutControl1_OnValueKeyDown);
            this.acLayoutControl1.OnValueChanged += new acLayoutControl.ValueChangedEventHandler(acLayoutControl1_OnValueChanged);

            //(acLayoutControl1.GetEditor("PROD_STATE").Editor as acLookupEdit).SetCode("P012");

            base.MenuInit();
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

      
        void acGridView1_OnMapingRowChanged(acGridView.emMappingRowChangedType type, DataRow row)
        {
            if (type == acGridView.emMappingRowChangedType.DELETE)
            {
                string formKey = string.Format("{0},{1}", "ITEM", row["ITEM_CODE"]);

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


                //acCheckedComboBoxEdit1.Properties.Items[9].CheckState = CheckState.Checked; //등록
                //acCheckedComboBoxEdit1.Properties.Items[10].CheckState = CheckState.Checked; //확정
                //acCheckedComboBoxEdit1.Properties.Items[0];

                foreach (acCheckedListBoxItem ti in acCheckedComboBoxEdit1.Properties.Items)
                {
                    if (ti.Key.ToString() == "6"
                        || ti.Key.ToString() == "7")
                    {
                        ti.CheckState = CheckState.Checked;
                    }
                }

                //acLayoutControl layout = sender as acLayoutControl;

                //layout.GetEditor("DATE").Value = "REG_DATE";
                //layout.GetEditor("S_DATE").Value = acDateEdit.GetNowFirstDate();
                //layout.GetEditor("E_DATE").Value = DateTime.Now;


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

    
     
        void acGridView1_ShowGridMenuEx(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            acGridView view = sender as acGridView;

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


            if (e.HitInfo.HitTest == GridHitTest.EmptyRow || e.HitInfo.HitTest == GridHitTest.Row || e.HitInfo.HitTest == GridHitTest.RowCell)
            {

                GridHitInfo hitInfo = view.CalcHitInfo(e.Point);

                popupMenu1.ShowPopup(view.GridControl.PointToScreen(e.Point));


            }

        }

        void acGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                GridHitInfo hitInfo = acGridView1.CalcHitInfo(e.Location);

                if (hitInfo.HitTest == GridHitTest.RowCell || hitInfo.HitTest == GridHitTest.Row)
                {
                    //수주 편집기 열기

                    this.acBarButtonItem2_ItemClick(null, null);
                }

            }
        }


        private void AcGridView1_RowClick(object sender, RowClickEventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo hi = (sender as GridView).CalcHitInfo(new Point(e.X, e.Y));

            if (hi.Column != null && hi.Column.FieldName == "PROD_SPEC" && hi.InDataRow)
            {
                try
                {
                    DataRow focusRow = acGridView1.GetFocusedDataRow();

                    if (focusRow != null)
                    {
                        if (!base.ChildFormContains("NEW_ITEM"))
                        {
                            PopSpec frm = new PopSpec(focusRow);
                            frm.DialogMode = BaseMenuDialog.emDialogMode.NEW;
                            frm.ParentControl = this;
                            base.ChildFormAdd("NEW_ITEM", frm);
                            frm.Show(this);
                            focusRow = null;
                        }
                        else
                        {
                            base.ChildFormFocus("NEW_ITEM");
                        }
                    }
                }
                catch (Exception ex)
                {
                    acMessageBox.Show(this, ex);
                }

            }
        }




        void Search()
        {
            //조회
            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("PROD_LIKE", typeof(String)); //수주코드/명 LIKE 검색
            paramTable.Columns.Add("STATES", typeof(String)); //
            paramTable.Columns.Add("PROD_STATE_IN", typeof(String)); //
            paramTable.Columns.Add("IS_END", typeof(String)); //
            paramTable.Columns.Add("IS_NEW", typeof(String)); //
            paramTable.Columns.Add("IS_REPEAT", typeof(String)); //
            paramTable.Columns.Add("PROD_KINDS", typeof(String)); //
            //paramTable.Columns.Add("CVND_LIKE", typeof(String)); //발주
            //paramTable.Columns.Add("BUSINESS_EMP", typeof(String)); //발주
            //paramTable.Columns.Add("S_REG_DATE", typeof(String)); //등록 시작일
            //paramTable.Columns.Add("E_REG_DATE", typeof(String)); //등록 종료일
            //paramTable.Columns.Add("S_ORD_DATE", typeof(String)); //수주일 시작일
            //paramTable.Columns.Add("E_ORD_DATE", typeof(String)); //수주일 종료일
            //paramTable.Columns.Add("S_DELIVERY_DATE", typeof(String)); //출하 시작일
            //paramTable.Columns.Add("E_DELIVERY_DATE", typeof(String)); //출하 종료일
            //paramTable.Columns.Add("S_DUE_DATE", typeof(String)); //납기일 시작일
            //paramTable.Columns.Add("E_DUE_DATE", typeof(String)); //납기일 종료일

            DataRow layoutRow = acLayoutControl1.CreateParameterRow();

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["STATES"] = layoutRow["PROD_STATE"];
            paramRow["PROD_STATE_IN"] = layoutRow["PROD_STATE"];
            paramRow["PROD_LIKE"] = layoutRow["PROD_LIKE"];
            paramRow["PROD_KINDS"] = "PD,PE";

            if (!acCheckEdit1.Checked)
            {
                paramRow["IS_END"] = "1";
            }

            if (acCheckEdit2.Checked)
            {
                paramRow["IS_REPEAT"] = "1";
            }
            else
            {
                paramRow["IS_NEW"] = "1";
            }
                

            //paramRow["CVND_LIKE"] = layoutRow["CVND_LIKE"];
            //paramRow["BUSINESS_EMP"] = layoutRow["BUSINESS_EMP"];


            //foreach (string key in acCheckedComboBoxEdit1.GetKeyChecked())
            //{
            //    switch (key)
            //    {
            //        case "REG_DATE":
            //            //등록일
            //            paramRow["P.PROD_STATE"] = layoutRow[""];

            //            break;
            //        case "ORD_DATE":
            //            //수주일
            //            paramRow["S_ORD_DATE"] = layoutRow["S_DATE"];
            //            paramRow["E_ORD_DATE"] = layoutRow["E_DATE"];

            //            break;
            //        case "DUE_DATE":
            //            //납기일
            //            paramRow["S_DUE_DATE"] = layoutRow["S_DATE"];
            //            paramRow["E_DUE_DATE"] = layoutRow["E_DATE"];

            //            break;
            //        case "DELIVERY_DATE":
            //            //납품일
            //            paramRow["S_SHIP_DATE"] = layoutRow["S_DATE"];
            //            paramRow["E_SHIP_DATE"] = layoutRow["E_DATE"];

            //            break;
            //    }
            //}


            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);


            BizRun.QBizRun.ExecuteService(
             this, QBiz.emExecuteType.LOAD,
             "PLN20A_SER", paramSet, "RQSTDT", "RSLTDT",
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
                 "ORD02A_SER", refreshSet, "RQSTDT", "RSLTDT",
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

                string stat = e.result.Tables["RQSTDT"].Rows[0]["STATES"].ToString();

                if(stat.isNullOrEmpty()) // 검색조건 없이 조회하는 경우
                {
                    acGridView1.GridControl.DataSource = e.result.Tables["RSLTDT"];

                    base.SetLog(e.executeType, e.result.Tables["RSLTDT"].Rows.Count, e.executeTime);
                }
                else
                {
                    // WHERE PROD_STATE IN ( n1, n2, n3...)과 동일한 기능을 수행
                    
                    IEnumerable<string> filters = stat.Split(',');

                    var Values = (from r in e.result.Tables["RSLTDT"].AsEnumerable()
                                  where filters.Contains(r.Field<string>("PROD_STATE"))
                                  select r).ToList();
                    
                    if(Values.Count > 0)
                    {
                        DataTable dtFilterd = Values.CopyToDataTable();

                        acGridView1.GridControl.DataSource = dtFilterd;

                        base.SetLog(e.executeType, dtFilterd.Rows.Count, e.executeTime);
                    }
                    else
                    {
                        acGridView1.ClearRow();
                        base.SetLog(e.executeType, 0, e.executeTime);
                    }

                }
      
                acGridView1.BestFitColumns();

                acGridView1.SetOldFocusRowHandle(true);

             
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

      
        private void acBarButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //새로만들기 수주 편집기
            try
            {
                if (!base.ChildFormContains("NEW_ITEM"))
                {
                    PLN20A_D1A frm = new PLN20A_D1A(acGridView1, "NEW_ITEM");

                    frm.DialogMode = BaseMenuDialog.emDialogMode.NEW;

                    frm.ParentControl = this;

                    base.ChildFormAdd("NEW_ITEM", frm);

                    frm.Show(this);


                }
                else
                {
                    base.ChildFormFocus("NEW_ITEM");
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }



        private void acBarButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //열기 수주편집기

            try
            {
                if (acGridView1.ValidFocusRowHandle() == false)
                {
                    return;
                }


                DataRow focusRow = acGridView1.GetFocusedDataRow();


                string formKey = string.Format("{0},{1}", "PROD", focusRow["PROD_CODE"]);

                if (!base.ChildFormContains(formKey))
                {

                    PLN20A_D1A frm = new PLN20A_D1A(acGridView1, focusRow);

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
            //수주 삭제
            try
            {
                acGridView1.EndEditor();


                if (acMessageBox.Show(this, "정말 삭제하시겠습니까?", "TB43FSY3", true, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
                {
                    return;
                }

                DataRow[] selected = acGridView1.GetSelectedDataRows();



                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("DEL_EMP", typeof(String)); //
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("PROD_CODE", typeof(String)); //                

                if (selected.Length == 0)
                {
                    //단일삭제

                    DataRow focusRow = acGridView1.GetFocusedDataRow();

                    DataRow paramRow = paramTable.NewRow();
                    paramRow["DEL_EMP"] = acInfo.UserID;
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["PROD_CODE"] = focusRow["PROD_CODE"];
                    paramTable.Rows.Add(paramRow);


                }
                else
                {

                    //다중삭제
                    foreach (DataRow row in selected)
                    {

                        DataRow paramRow = paramTable.NewRow();
                        paramRow["DEL_EMP"] = acInfo.UserID;
                        paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                        paramRow["PROD_CODE"] = row["PROD_CODE"];
                        paramTable.Rows.Add(paramRow);

                    }


                }


                DataSet paramSet = new DataSet();

                paramSet.Tables.Add(paramTable);


                BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.DEL,
                "ORD02A_DEL", paramSet, "RQSTDT", "RSLTDT",
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

                //수주 삭제후

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

        private void acBarButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //새로만들기 금형편집기
            try
            {
                if (!base.ChildFormContains("NEW_PROD"))
                {
                    //ORD02A_D2A frm = new ORD02A_D2A(acGridView1, acGridView1.GetFocusedDataRow(), acGridView2, null);

                    //frm.DialogMode = BaseMenuDialog.emDialogMode.NEW;

                    //frm.ParentControl = this;

                    //base.ChildFormAdd("NEW_PROD", frm);

                    //frm.Show(this);


                }
                else
                {
                    base.ChildFormFocus("NEW_PROD");
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

       

        private void btnNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!base.ChildFormContains("NEW_PROD"))
                {
                    PLN20A_D1A frm = new PLN20A_D1A(acGridView1, "NEW_PROD");

                    frm.DialogMode = BaseMenuDialog.emDialogMode.NEW;

                    frm.ParentControl = this;

                    base.ChildFormAdd("NEW_PROD", frm);

                    frm.Show(this);


                }
                else
                {
                    base.ChildFormFocus("NEW_PROD");
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void btnCopy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (acGridView1.ValidFocusRowHandle() == false)
                {
                    return;
                }


                DataRow focusRow = acGridView1.GetFocusedDataRow();


                //string formKey = string.Format("{0},{1}", "PROD_CODE", focusRow["PROD_CODE"]);

                if (!base.ChildFormContains("COPY_PROD"))
                {

                    PLN20A_D1A frm = new PLN20A_D1A(acGridView1, focusRow);

                    frm.DialogMode = BaseMenuDialog.emDialogMode.USER;

                    frm.ParentControl = this;

                    base.ChildFormAdd("COPY_PROD", frm);

                    frm.Show(this);

                }
                else
                {
                    base.ChildFormFocus("COPY_PROD");

                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        /// <summary>
        /// 확정
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConfirm_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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
            paramTable1.Columns.Add("PROD_STATE", typeof(String)); //
                        
            foreach (DataRow dr in selectedRows)
            {                
                DataRow paramRow1 = paramTable1.NewRow();
                paramRow1["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow1["PROD_CODE"] = dr["PROD_CODE"];
                paramRow1["PROD_STATE"] = "7";

                paramTable1.Rows.Add(paramRow1);                
            }

            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable1);

            BizRun.QBizRun.ExecuteService(
            this, QBiz.emExecuteType.SAVE,
            "ORD02A_UPD", paramSet, "RQSTDT", "RSLTDT",
            QuickSaveConfirm,
            QuickException);
        }

        void QuickSaveConfirm(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                foreach (DataRow row in e.result.Tables["RSLTDT"].Rows)
                {
                    this.acGridView1.UpdateMapingRow(row, true);
                }

                this.acGridView1.ClearSelection();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }


        /// <summary>
        /// 취소
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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
            paramTable1.Columns.Add("PROD_STATE", typeof(String)); //

            foreach (DataRow dr in selectedRows)
            {
                DataRow paramRow1 = paramTable1.NewRow();
                paramRow1["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow1["PROD_CODE"] = dr["PROD_CODE"];
                paramRow1["PROD_STATE"] = "5";

                paramTable1.Rows.Add(paramRow1);
            }

            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable1);

            BizRun.QBizRun.ExecuteService(
            this, QBiz.emExecuteType.SAVE,
            "ORD02A_UPD", paramSet, "RQSTDT", "RSLTDT",
            QuickSaveCancel,
            QuickException);
        }


        void QuickSaveCancel(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                foreach (DataRow row in e.result.Tables["RSLTDT"].Rows)
                {
                    this.acGridView1.UpdateMapingRow(row, true);
                }

                this.acGridView1.ClearSelection();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }
        private void btnShipPlan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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
            paramTable1.Columns.Add("SHIP_FLAG", typeof(String)); //

            foreach (DataRow dr in selectedRows)
            {
                DataRow paramRow1 = paramTable1.NewRow();
                paramRow1["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow1["PROD_CODE"] = dr["PROD_CODE"];
                paramRow1["SHIP_FLAG"] = "1";

                paramTable1.Rows.Add(paramRow1);
            }

            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable1);

            BizRun.QBizRun.ExecuteService(
            this, QBiz.emExecuteType.SAVE,
            "ORD02A_UPD2", paramSet, "RQSTDT", "RSLTDT",
            QuickSaveShip,
            QuickException);
        }

        void QuickSaveShip(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                foreach (DataRow row in e.result.Tables["RSLTDT"].Rows)
                {
                    this.acGridView1.UpdateMapingRow(row, true);
                }

                this.acGridView1.ClearSelection();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }


        /// <summary>
        /// 수주 잠금
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLock_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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
            paramTable1.Columns.Add("LOCK_FLAG", typeof(String)); //
            paramTable1.Columns.Add("LOCK_EMP", typeof(String)); //

            foreach (DataRow dr in selectedRows)
            {
                DataRow paramRow1 = paramTable1.NewRow();
                paramRow1["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow1["PROD_CODE"] = dr["PROD_CODE"];
                paramRow1["LOCK_FLAG"] = "1";
                paramRow1["LOCK_EMP"] = acInfo.UserID;

                paramTable1.Rows.Add(paramRow1);
            }

            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable1);

            BizRun.QBizRun.ExecuteService(
            this, QBiz.emExecuteType.SAVE,
            "ORD02A_UPD3", paramSet, "RQSTDT", "RSLTDT",
            QuickSaveLock,
            QuickException);
        }

        void QuickSaveLock(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                foreach (DataRow row in e.result.Tables["RSLTDT"].Rows)
                {
                    this.acGridView1.UpdateMapingRow(row, true);
                }

                this.acGridView1.ClearSelection();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        /// <summary>
        /// 잠금해제        
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLockCancel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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
            paramTable1.Columns.Add("LOCK_FLAG", typeof(String)); //
            paramTable1.Columns.Add("LOCK_EMP", typeof(String)); //

            foreach (DataRow dr in selectedRows)
            {
                DataRow paramRow1 = paramTable1.NewRow();
                paramRow1["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow1["PROD_CODE"] = dr["PROD_CODE"];
                paramRow1["LOCK_FLAG"] = "0";
                paramRow1["LOCK_EMP"] = acInfo.UserID;

                paramTable1.Rows.Add(paramRow1);
            }

            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable1);

            BizRun.QBizRun.ExecuteService(
            this, QBiz.emExecuteType.SAVE,
            "ORD02A_UPD4", paramSet, "RQSTDT", "RSLTDT",
            QuickSaveLockCancel,
            QuickException);
        }


        void QuickSaveLockCancel(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                foreach (DataRow row in e.result.Tables["RSLTDT"].Rows)
                {
                    this.acGridView1.UpdateMapingRow(row, true);
                }

                this.acGridView1.ClearSelection();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        private void acBarButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // 개발담당자 저장

            acGridView1.EndEditor();

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("PROD_CODE", typeof(String)); //
            paramTable.Columns.Add("DEV_EMP", typeof(String)); //
            paramTable.Columns.Add("SEND_DEV_EMP1", typeof(String)); //
            paramTable.Columns.Add("PLN_DATE", typeof(String)); //
            paramTable.Columns.Add("FIN_DATE", typeof(String)); //
            paramTable.Columns.Add("IS_DRAW", typeof(String)); //
            paramTable.Columns.Add("DRAW_DIR", typeof(String)); //
            paramTable.Columns.Add("ASSY_CHG_FLAG", typeof(String)); //

            DataTable mdfyDt = acGridView1.GetAddModifyRows();
            if (mdfyDt.Rows.Count == 0)
            {
                acMessageBox.Show(this, "변경한 내역이 존재하지 않습니다.", "", false, acMessageBox.emMessageBoxType.CONFIRM);
                return;
            }

            foreach (DataRow dr in mdfyDt.Rows)
            {
                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["PROD_CODE"] = dr["PROD_CODE"];
                paramRow["DEV_EMP"] = dr["DEV_EMP"];
                paramRow["SEND_DEV_EMP1"] = dr["DEV_EMP"];
                paramRow["PLN_DATE"] = dr["PLN_DATE"].toDateString("yyyyMMdd");
                paramRow["FIN_DATE"] = dr["FIN_DATE"].toDateString("yyyyMMdd");
                paramRow["IS_DRAW"] = dr["IS_DRAW"];
                paramRow["DRAW_DIR"] = dr["DRAW_DIR"];
                paramRow["ASSY_CHG_FLAG"] = dr["ASSY_CHG_FLAG"];
                paramTable.Rows.Add(paramRow);
            }

            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            BizRun.QBizRun.ExecuteService(
            this, QBiz.emExecuteType.SAVE,
            "PLN20A_UPD", paramSet, "RQSTDT", "RSLTDT",
            QuickSave,
            QuickException);
        }


        void QuickSave(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                foreach (DataRow row in e.result.Tables["RQSTDT"].Rows)
                {
                    this.acGridView1.UpdateMapingRow(row, true);
                }

                acAlert.Show(this, "저장되었습니다.", acAlertForm.enmType.Success);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

    }
}
