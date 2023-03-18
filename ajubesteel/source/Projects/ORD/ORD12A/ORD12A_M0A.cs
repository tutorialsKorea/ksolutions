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

namespace ORD
{
    public sealed partial class ORD12A_M0A : BaseMenu
    {

        private GridHitInfo _downHitInfo = null;

        public ORD12A_M0A()
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

            if (this._IsChanged == true && acMessageBox.Show(this, "수정된 항목이 있습니다.종료 하시겠습니까?", "QAISR59B", false, acMessageBox.emMessageBoxType.YESNO) != DialogResult.Yes)
            {
                return false;
            }

            return base.MenuDestory(sender);

        }


        public override void MenuLink(object data)
        {
            //try
            //{
            //검색조건 초기화
            //acCheckedComboBoxEdit1.Text = "";
            //foreach (acCheckedListBoxItem item in acCheckedComboBoxEdit1.Properties.Items)
            //{
            //    item.CheckState = System.Windows.Forms.CheckState.Unchecked;
            //}
            //acTextEdit1.Text = "";

            //acTextEdit1.Text = ((DataRow)data)["ITEM_CODE"].ToString();

            this.Search();
            //}
            //catch { }
        }

        private Dictionary<string, string> _dicProcStat = null;
        private DataTable _dtDeleteList = null;
        //private Hashtable _htWoList = null;
        //private Hashtable _htWoFig = null;

        public override void MenuInit()
        {

            acGridView1.GridType = acGridView.emGridType.SEARCH_SEL;

            //acGridView1.AddLookUpEdit("CAM_STATE", "상태", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P012");
            //acGridView1.AddTextEdit("CAM_STATE", "상태", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddLookUpEdit("PROD_STATE", "상태", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P012");
            //acGridView1.AddTextEdit("CAM_CNT", "지정/미지정", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            //acGridView1.AddDateEdit("CAM_EMP_DATE", "지정/미지정", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
            //acGridView1.AddCheckEdit("LOCK_FLAG", "잠금상태", "", false, false, true, acGridView.emCheckEditDataType._BYTE);            
            //acGridView1.AddLookUpEmp("LOCK_EMP", "잠금자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false);
            acGridView1.AddTextEdit("PROD_CODE", "수주번호", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("PROD_NAME", "모델명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("PROD_VERSION", "버전", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            //acGridView1.AddLookUpEdit("PROC_FLAG", "공정명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P005");
            //acGridView1.AddLookUpEdit("PROD_FLAG", "유형", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P006");
            //acGridView1.AddLookUpEdit("INS_YN", "성적서", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P007");
            //acGridView1.AddLookUpEdit("SOCKET_YN", "소켓측정", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P007");            
            acGridView1.AddCheckedComboBoxEdit("PROD_CATEGORY", "제품유형", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, "P009");
            //acGridView1.AddTextEdit("BUSINESS_EMP", "영업담당자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddLookUpEmp("BUSINESS_EMP", "영업담당자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false);
            acGridView1.AddTextEdit("CUSTOMER_EMP", "고객담당자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            //acGridView1.AddLookUpEmp("CUSTOMER_EMP", "고객담당자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false);
            acGridView1.AddTextEdit("CUSTDESIGN_EMP", "고객설계자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            //acGridView1.AddLookUpEmp("CUSTDESIGN_EMP", "고객설계자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false);
            //acGridView1.AddLookUpEdit("ACTUATOR_YN", "Actuator유무", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P007");

            ////acGridView1.AddTextEdit("CVND_CODE", "발주처코드", "CPW0FS8W", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            //acGridView1.AddTextEdit("CVND_NAME", "발주처", "CPW0FS8W", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            ////acGridView1.AddTextEdit("TVND_CODE", "계산서 발행처 코드", "CPW0FS8W", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            //acGridView1.AddTextEdit("TVND_NAME", "계산서 발행처", "CPW0FS8W", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddDateEdit("ORD_DATE", "수주일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
            acGridView1.AddDateEdit("DUE_DATE", "납기일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
            acGridView1.AddDateEdit("CHG_DUE_DATE", "납기조정일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
            acGridView1.AddDateEdit("DELIVERY_DATE", "납품일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
            acGridView1.AddDateEdit("PLN_END_TIME", "완료예정일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
            acGridView1.AddCheckedComboBoxEdit("PROBE_PIN", "Probe Pin", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, "P011");
            acGridView1.AddLookUpEdit("PROD_TYPE", "제품분류", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P010");
            acGridView1.AddTextEdit("PROD_QTY", "수주수량", "CPW0FS8W", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NUMERIC);

            acGridView1.AddCheckEdit("HAS_DRAW", "도면", "", false, false, true, acGridView.emCheckEditDataType._STRING);

            //acGridView1.AddDateEdit("START_TIME", "시작시간", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.LONG_DATE);
            //acGridView1.AddDateEdit("END_TIME", "실적완료시간", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.LONG_DATE);

            acGridView1.AddLookUpEdit("IS_OS", "제작구분", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P016");
            acGridView1.AddTextEdit("PART_CODE", "부품코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("PART_NAME", "부품명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("MAT_NAME", "소재명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("PART_QTY", "수량", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            //acGridView1.AddTextEdit("MC_GROUP", "호기구분", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddLookUpEdit("MC_GROUP", "설비그룹", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "C020");
            acGridView1.AddTextEdit("PLAN_RATE", "부하율", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.PER2);
            //acGridView1.AddLookUpEmp("CAM_EMP", "담당자", "", false, DevExpress.Utils.HorzAlignment.Center, true, true, false,"IS_CAM = 1");

            //acGridView1.Columns["CAM_EMP"].Fixed = FixedStyle.Right;

            acGridView1.AddHidden("PT_ID", typeof(string));

            acGridView1.KeyColumn = new string[] { "PT_ID" };

            acGridView1.OptionsView.ShowIndicator = true;


            acGridView1.GridType = acGridView.emGridType.SEARCH;

            //if(acGridView2.Columns["LOAD_FLAG"] is GridColumn gc)
            //{
            //    if(gc.ColumnEdit is DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit rce)
            //    {
            //        rce.ValueChecked = (Byte)0;
            //        rce.ValueUnchecked = (Byte)1;
            //    }
            //}
            acCheckedComboBoxEdit1.AddItem("등록일", false, "", "REG_DATE", true, false);
            acCheckedComboBoxEdit1.AddItem("수주일", false, "", "ORD_DATE", true, false);
            acCheckedComboBoxEdit1.AddItem("납기일", false, "", "DUE_DATE", true, false);
            acCheckedComboBoxEdit1.AddItem("납품일", false, "", "DELIVERY_DATE", true, false);

            this.acLayoutControl1.OnValueKeyDown += new acLayoutControl.ValueKeyDownEventHandler(acLayoutControl1_OnValueKeyDown);
            this.acLayoutControl1.OnValueChanged += new acLayoutControl.ValueChangedEventHandler(acLayoutControl1_OnValueChanged);

            this.acGridView1.CustomDrawCell += AcGridView1_CustomDrawCell;
            //this.acGridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(acGridView1_FocusedRowChanged);
            //this.acGridView1.MouseDown += new MouseEventHandler(acGridView1_MouseDown);
            this.acGridView1.ShowGridMenuEx += new acGridView.ShowGridMenuExHandler(acGridView1_ShowGridMenuEx);
            this.acGridView1.OnMapingRowChanged += new acGridView.MapingRowChangedEventHandler(acGridView1_OnMapingRowChanged);

            //this.acGridView2.MouseDown += new MouseEventHandler(acGridView2_MouseDown);
            //this.acGridView2.MouseMove += AcGridView2_MouseMove;
            //this.acGridView2.EndSorting += AcGridView2_EndSorting;
            //this.acGridView2.ShowGridMenuEx += new acGridView.ShowGridMenuExHandler(acGridView2_ShowGridMenuEx);
            //this.acGridView2.OnMapingRowChanged += new acGridView.MapingRowChangedEventHandler(acGridView2_OnMapingRowChanged);
            //this.acGridView2.CellValueChanged += acGridView2_CellValueChanged;
            //this.acGridView2.CustomDrawCell += acGridView2_CustomDrawCell;
            //this.acGridView2.RowCellStyle += acGridView2_RowCellStyle;
            //this.acGridView2.Layout += AcGridView2_Layout;

            acGridView1.ShownEditor += acGridView1_ShownEditor;

            //acGridView2.ShowingEditor += acGridView2_ShowingEditor;

            SetBtnEnable(false);

            //this.acGridControl2.ProcessGridKey += acGridControl2_ProcessGridKey;
            //this.acGridView2.RowUpdated += acGridView2_RowUpdated;
            this.acGridView1.CellValueChanged += acGridView1_CellValueChanged;
            //this.acGridView2.RowDeleted += acGridView2_RowDeleted;                        

            base.MenuInit();
        }

        private void acGridView1_ShowingEditor(object sender, CancelEventArgs e)
        {
            acGridView view = sender as acGridView;

            if (view.FocusedColumn.FieldName == "CAM_EMP")
            {
                if (view.GetRowCellValue(view.FocusedRowHandle, "CAM_EMP").isNullOrEmpty())
                {
                    view.SetRowCellValue(view.FocusedRowHandle, "CAM_EMP", acInfo.UserID);

                    //(view.Columns["CAM_EMP"].ColumnEdit as acLookupEdit).sele

                    LookUpEdit lookUpEdit = view.ActiveEditor as LookUpEdit;
                    if (lookUpEdit != null)
                    {
                        //lookUpEdit.IsPopupOpen = true;
                        //Dispatcher.BeginInvoke(new Action(() =>{
                        //    GridControl lookUpGrid = lookUpEdit.GetGridControl();
                        //}));
                    }
                }
            }
        }

        private void acGridView1_ShownEditor(object sender, EventArgs e)
        {
            acGridView view = sender as acGridView;

            if(view.FocusedColumn.FieldName == "CAM_EMP")
            {
                if(view.GetRowCellValue(view.FocusedRowHandle, "CAM_EMP").isNullOrEmpty())
                {
                    view.SetRowCellValue(view.FocusedRowHandle, "CAM_EMP", acInfo.UserID);

                    //(view.Columns["CAM_EMP"].ColumnEdit as acLookupEdit).sele

                    LookUpEdit lookUpEdit = view.ActiveEditor as LookUpEdit;
                    if (lookUpEdit != null)
                    {
                        //lookUpEdit.IsPopupOpen = true;
                        //Dispatcher.BeginInvoke(new Action(() =>{
                        //    GridControl lookUpGrid = lookUpEdit.GetGridControl();
                        //}));
                    }
                }
            }
        }

        private bool _IsChanged = false;

        private void acGridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                this._IsChanged = true;                
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }


        void SetBtnEnable(bool value)
        {
            barItemOsCreate.Enabled = value; 
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
                string formKey = string.Format("{0},{1}", "PROD", row["PROD_CODE"]);

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


                acLayoutControl layout = sender as acLayoutControl;

                layout.GetEditor("DATE").Value = "DUE_DATE";
                layout.GetEditor("S_DATE").Value = acDateEdit.GetNowFirstDate();
                layout.GetEditor("E_DATE").Value = DateTime.Now;


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
                //acBarButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                //acBarButtonItem3.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;


            }
            else if (e.MenuType == GridMenuType.Row)
            {
                if (e.HitInfo.RowHandle >= 0)
                {
                    //acBarButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    //acBarButtonItem3.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                }
                else
                {
                    //acBarButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    //acBarButtonItem3.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                }

            }


            if (e.HitInfo.HitTest == GridHitTest.EmptyRow || e.HitInfo.HitTest == GridHitTest.Row || e.HitInfo.HitTest == GridHitTest.RowCell)
            {

                GridHitInfo hitInfo = view.CalcHitInfo(e.Point);

                popupMenu1.ShowPopup(view.GridControl.PointToScreen(e.Point));


            }

        }

        private int _oldRowHandel = -1;

        //void acGridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        //{
        //    acGridView view = sender as acGridView;

        //    if (this._IsChanged == true && acMessageBox.Show(this, "수정된 항목이 있습니다.계속진행 하시겠습니까?", "QAISR59B", false, acMessageBox.emMessageBoxType.YESNO) != DialogResult.Yes)
        //    {
        //        acGridView1.FocusedRowChanged -= acGridView1_FocusedRowChanged;
        //        acGridView1.FocusedRowHandle = this._oldRowHandel;
        //        //acGridView1.SetOldFocusRowHandle(true);
        //        acGridView1.FocusedRowChanged += acGridView1_FocusedRowChanged;
        //        return;
        //    }

        //    this._oldRowHandel = acGridView1.FocusedRowHandle;

        //    if (view.ValidFocusRowHandle())
        //    {
        //        this._IsChanged = false;
        //        if (this._dtDeleteList != null)
        //            this._dtDeleteList.Clear();
        //        this.GetDatail();
        //        SetBtnEnable(true);
        //    }
        //    else
        //    {
        //        if(this._dtDeleteList != null)
        //            this._dtDeleteList.Clear();
        //        this._IsChanged = false;                
        //        acGridView2.ClearRow();
        //        SetBtnEnable(false);
        //    }
        //}


        void Search()
        {
            //조회
            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("PROD_LIKE", typeof(String)); //수주코드/명 LIKE 검색
            paramTable.Columns.Add("CVND_LIKE", typeof(String)); //발주
            paramTable.Columns.Add("PART_LIKE", typeof(String)); //발주
            paramTable.Columns.Add("BUSINESS_EMP", typeof(String)); //발주
            paramTable.Columns.Add("S_REG_DATE", typeof(String)); //등록 시작일
            paramTable.Columns.Add("E_REG_DATE", typeof(String)); //등록 종료일
            paramTable.Columns.Add("S_ORD_DATE", typeof(String)); //수주일 시작일
            paramTable.Columns.Add("E_ORD_DATE", typeof(String)); //수주일 종료일
            paramTable.Columns.Add("S_SHIP_DATE", typeof(String)); //출하 시작일
            paramTable.Columns.Add("E_SHIP_DATE", typeof(String)); //출하 종료일
            paramTable.Columns.Add("S_DUE_DATE", typeof(String)); //납기일 시작일
            paramTable.Columns.Add("E_DUE_DATE", typeof(String)); //납기일 종료일
            paramTable.Columns.Add("S_DELIVERY_DATE", typeof(String)); //납품 시작일
            paramTable.Columns.Add("E_DELIVERY_DATE", typeof(String)); //납품 종료일
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
                    case "SHIP_DATE":
                        //출하일
                        paramRow["S_SHIP_DATE"] = layoutRow["S_DATE"];
                        paramRow["E_SHIP_DATE"] = layoutRow["E_DATE"];

                        break;
                    case "DELIVERY_DATE":
                        //납품일
                        paramRow["S_DELIVERY_DATE"] = layoutRow["S_DATE"];
                        paramRow["E_DELIVERY_DATE"] = layoutRow["E_DATE"];

                        break;
                }
            }


            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);


            BizRun.QBizRun.ExecuteService(
             this, QBiz.emExecuteType.LOAD,
             "ORD12A_SER", paramSet, "RQSTDT", "RSLTDT",
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

                if (acGridView1.RowCount > 0)
                    SetBtnEnable(true);
                else
                    SetBtnEnable(false);

                base.SetLog(e.executeType, e.result.Tables["RSLTDT"].Rows.Count, e.executeTime);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        //void GetDatail()
        //{

        //    DataRow focusRow = acGridView1.GetFocusedDataRow();

        //    if (focusRow == null)
        //    {
        //        acGridView2.ClearRow();

        //        return;
        //    }

        //    DataTable paramTable = new DataTable("RQSTDT");
        //    paramTable.Columns.Add("PLT_CODE", typeof(String)); //
        //    paramTable.Columns.Add("PROD_CODE", typeof(String)); //

        //    DataRow paramRow = paramTable.NewRow();
        //    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
        //    paramRow["PROD_CODE"] = focusRow["PROD_CODE"];
            
        //    paramTable.Rows.Add(paramRow);
        //    DataSet paramSet = new DataSet();
        //    paramSet.Tables.Add(paramTable);


        //    BizRun.QBizRun.ExecuteService(
        //    this, QBiz.emExecuteType.LOAD_DETAIL,
        //    "POP01A_SER2", paramSet, "RQSTDT", "RSLTDT",
        //    QuickDetail,
        //    QuickException);


        //}



        void QuickSave(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                 
                //foreach(DataRow row in e.result.Tables["RSLTDT"].Rows)
                //{
                //    acGridView1.UpdateMapingRow(row, false);
                //}

                this._IsChanged = false;

                acAlert.Show(this, "저장 되었습니다.", acAlertForm.enmType.Success);
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
                //foreach (DataRow row in e.result.Tables["RQSTDT"].Rows)
                //{
                //    acGridView2.DeleteMappingRow(row);
                //}
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void barItemOsCreate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                acGridView1.EndEditor();


                if (acMessageBox.Show(this, "정말 외주 공정 설정을 진행 하시겠습니까?", "TB43FSY3", false, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
                {
                    return;
                }

                DataRow[] selected = acGridView1.GetSelectedDataRows();



                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("REG_EMP", typeof(String)); //
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("PT_ID", typeof(String)); //                

                if (selected.Length == 0)
                {
                    //단일삭제

                    DataRow focusRow = acGridView1.GetFocusedDataRow();

                    DataRow paramRow = paramTable.NewRow();
                    paramRow["REG_EMP"] = acInfo.UserID;
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["PT_ID"] = focusRow["PT_ID"];
                    paramTable.Rows.Add(paramRow);


                }
                else
                {

                    //다중삭제
                    foreach (DataRow row in selected)
                    {

                        DataRow paramRow = paramTable.NewRow();
                        paramRow["REG_EMP"] = acInfo.UserID;
                        paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                        paramRow["PT_ID"] = row["PT_ID"];
                        paramTable.Rows.Add(paramRow);

                    }


                }


                DataSet paramSet = new DataSet();

                paramSet.Tables.Add(paramTable);


                BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.PROCESS,
                "ORD12A_UPD", paramSet, "RQSTDT", "RSLTDT",
                QuickUpdate,
                QuickException);


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
                acAlert.Show(this, "외주 공정 설정이 완료 되었습니다.", acAlertForm.enmType.Success);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }
    }
}
