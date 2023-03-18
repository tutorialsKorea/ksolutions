using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ControlManager;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Base;
using BizManager;

namespace PLN
{
    public sealed partial class PLN18A_M0A : BaseMenu
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


        public PLN18A_M0A()
        {
            InitializeComponent();


            acGridView1.MouseDown += new MouseEventHandler(acGridView1_MouseDown);

            acGridView2.MouseDown += new MouseEventHandler(acGridView2_MouseDown);

            // acGridView1.OnMapingRowChanged += new acGridView.MapingRowChangedEventHandler(acGridView1_OnMapingRowChanged);

            acGridView1.ShowGridMenuEx += new acGridView.ShowGridMenuExHandler(acGridView1_ShowGridMenuEx);

            acGridView2.ShowGridMenuEx += new acGridView.ShowGridMenuExHandler(acGridView2_ShowGridMenuEx);

            acGridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(acGridView1_FocusedRowChanged);

            acLayoutControl1.OnValueKeyDown += new acLayoutControl.ValueKeyDownEventHandler(acLayoutControl1_OnValueKeyDown);

            acLayoutControl1.OnValueChanged += new acLayoutControl.ValueChangedEventHandler(acLayoutControl1_OnValueChanged);


           this.Load += PLN18A_M0A_Load;
        }

        void PLN18A_M0A_Load(object sender, EventArgs e)
        {
          //  this.Search();
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
                    paramTable.Columns.Add("PRJ_CODE", typeof(String)); //

                    DataRow paramRow = paramTable.NewRow();
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["PRJ_CODE"] = focusRow["PRJ_CODE"];
                    paramTable.Rows.Add(paramRow);
                    DataSet paramSet = new DataSet();
                    paramSet.Tables.Add(paramTable);

                    BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD, "PLN18A_SER4", paramSet, "RQSTDT", "RSLTDT",
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





        void acGridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
           this.GetDetail();
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

                layout.GetEditor("DATE").Value = "REQ_DATE";
                layout.GetEditor("S_DATE").Value = acDateEdit.GetNowFirstDate();
                layout.GetEditor("E_DATE").Value = DateTime.Now;


            }


            base.ChildContainerInit(sender);
        }


        void acGridView1_ShowGridMenuEx(object sender, PopupMenuShowingEventArgs e)
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



        void acGridView2_ShowGridMenuEx(object sender, PopupMenuShowingEventArgs e)
        {
           
            //if (acGridView2.FocusedRowHandle < 0)
            //{
            //    return;
            //}

            acGridView view = sender as acGridView;

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


            if (e.HitInfo.HitTest == GridHitTest.EmptyRow || e.HitInfo.HitTest == GridHitTest.Row || e.HitInfo.HitTest == GridHitTest.RowCell)
            {

                GridHitInfo hitInfo = view.CalcHitInfo(e.Point);

                popupMenu2.ShowPopup(view.GridControl.PointToScreen(e.Point));

            }
        }





        void acGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                GridHitInfo hitInfo = acGridView1.CalcHitInfo(e.Location);

                if (hitInfo.HitTest == GridHitTest.RowCell || hitInfo.HitTest == GridHitTest.Row)
                {
                    //프로젝트 현황 편집기 열기

                    this.acBarButtonItem2_ItemClick(null, null);
                }

            }
        }


        void acGridView2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                GridHitInfo hitInfo = acGridView2.CalcHitInfo(e.Location);

                if (hitInfo.HitTest == GridHitTest.RowCell || hitInfo.HitTest == GridHitTest.Row)
                {
                    //진행 사항 편집기 열기

                    this.acBarButtonItem5_ItemClick(null, null);
                }

            }
        }



        public override void MenuNotify(object data)
        {
            base.MenuNotify(data);
        }


        public override void MenuInit()
        {


            acGridView1.GridType = acGridView.emGridType.SEARCH_SEL;

            acGridView1.OptionsView.ShowIndicator = true;

            acGridView1.AddLookUpEdit("PRJ_STATE", "진행상황", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P013");

            acGridView1.AddTextEdit("PRJ_NAME", "프로젝트명", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("PROGRESS", "진척율", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.PER100);

            acGridView1.AddLookUpVendor("CVND_CODE", "고객사", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false);

            acGridView1.AddTextEdit("CHARGE_EMP", "고객담당자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddLookUpEmp("BUSINESS_EMP", "영업담당자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false);

            acGridView1.AddLookUpEmp("DESIGN_EMP", "설계담당자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false);

            acGridView1.AddLookUpEdit("DEV_GROUP", "개발그룹", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P014");

            acGridView1.AddDateEdit("REQ_DATE", "고객요청일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);

            acGridView1.AddDateEdit("PRJ_START_DATE", "시작일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);

            acGridView1.AddDateEdit("PLN_END_DATE", "완료예정일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);

            acGridView1.AddDateEdit("PRJ_END_DATE", "완료일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);

            acGridView1.AddLookUpEdit("IS_CONFIRM", "팀장확인", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P015");

            acGridView1.AddTextEdit("SCOMMENT", "개요", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);


            acGridView1.AddHidden("PRJ_CODE", typeof(String));

            acGridView1.KeyColumn = new string[] { "PRJ_CODE" };



            acGridView2.GridType = acGridView.emGridType.SEARCH_SEL;

            acGridView2.OptionsView.ShowIndicator = true;

            acGridView2.AddDateEdit("HIS_DATE", "작성일자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);

            acGridView2.AddMemoEdit("CONTENTS", "진행사항", "", false, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, false, true, true, false);

            acGridView2.AddLookUpEmp("EMP_CODE", "작성자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false);

            acGridView2.AddHidden("PRJ_HIS_CODE", typeof(String));

            // acGridView2.OptionsView.ColumnAutoWidth = true;

            acGridView2.KeyColumn = new string[] { "PRJ_HIS_CODE" };


            acCheckedComboBoxEdit1.AddItem("고객요청일", false, "", "REQ_DATE", true, false);
            acCheckedComboBoxEdit1.AddItem("시작일", false, "", "PRJ_START_DATE", true, false);
            acCheckedComboBoxEdit1.AddItem("완료예정일", false, "", "PLN_END_DATE", true, false);
            acCheckedComboBoxEdit1.AddItem("완료일", false, "", "PRJ_END_DATE", true, false);

            (acLayoutControl1.GetEditor("PRJ_STATE") as acLookupEdit).SetCode("P013");
          
            base.MenuInit();

        }


        public override void MenuInitComplete()
        {
            base.MenuInitComplete();
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
            DataRow layoutRow = acLayoutControl1.CreateParameterRow();

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("PRJ_STATE", typeof(String)); //
            paramTable.Columns.Add("PRJ_LIKE", typeof(String)); //

            paramTable.Columns.Add("S_REQ_DATE", typeof(String)); //
            paramTable.Columns.Add("E_REQ_DATE", typeof(String)); //

            paramTable.Columns.Add("S_PRJ_START_DATE", typeof(String)); //
            paramTable.Columns.Add("E_PRJ_START_DATE", typeof(String)); //

            paramTable.Columns.Add("S_PLN_END_DATE", typeof(String)); //
            paramTable.Columns.Add("E_PLN_END_DATE", typeof(String)); //

            paramTable.Columns.Add("S_PRJ_END_DATE", typeof(String)); //
            paramTable.Columns.Add("E_PRJ_END_DATE", typeof(String)); //


            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["PRJ_STATE"] = layoutRow["PRJ_STATE"];
            paramRow["PRJ_LIKE"] = layoutRow["PRJ_LIKE"];



            foreach (string key in acCheckedComboBoxEdit1.GetKeyChecked())
            {
                switch (key)
                {
                    case "REQ_DATE":

                        //고객요청일
                        paramRow["S_REQ_DATE"] = ((DateTime)layoutRow["S_DATE"]).toDateString("yyyyMMdd");
                        paramRow["E_REQ_DATE"] = ((DateTime)layoutRow["E_DATE"]).toDateString("yyyyMMdd");
                    break;

                    case "PRJ_START_DATE":

                        //(프로젝트) 시작일
                        paramRow["S_PRJ_START_DATE"] = ((DateTime)layoutRow["S_DATE"]).toDateString("yyyyMMdd");
                        paramRow["E_PRJ_START_DATE"] = ((DateTime)layoutRow["E_DATE"]).toDateString("yyyyMMdd");
                    break;

                    case "PLN_END_DATE":

                        //(프로젝트) 완료예정일
                        paramRow["S_PLN_END_DATE"] = ((DateTime)layoutRow["S_DATE"]).toDateString("yyyyMMdd");
                        paramRow["E_PLN_END_DATE"] = ((DateTime)layoutRow["E_DATE"]).toDateString("yyyyMMdd");
                    break;

                    case "PRJ_END_DATE":

                        //(프로젝트) 완료일
                        paramRow["S_PRJ_END_DATE"] = ((DateTime)layoutRow["S_DATE"]).toDateString("yyyyMMdd");
                        paramRow["E_PRJ_END_DATE"] = ((DateTime)layoutRow["E_DATE"]).toDateString("yyyyMMdd");
                    break;

                }
            }

            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.NONE, "PLN18A_SER2", paramSet, "RQSTDT", "RSLTDT",
               QuickSearch,
               QuickException);

        }

        void QuickSearch(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                acGridView1.GridControl.DataSource = e.result.Tables["RSLTDT"];

                acGridView1.BestFitColumns();

                base.SetLog(e.executeType, e.result.Tables["RSLTDT"].Rows.Count, e.executeTime);
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




        private void acBarButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // 열기

            try
            {

                DataRow focusRow = acGridView1.GetFocusedDataRow();


                if (focusRow == null)
                {
                    return;
                }

                if (!base.ChildFormContains(focusRow["PRJ_CODE"]))
                {

                    PLN18A_D0A frm = new PLN18A_D0A(acGridView1, focusRow);

                    frm.DialogMode = BaseMenuDialog.emDialogMode.OPEN;

                    frm.ParentControl = this;

                    base.ChildFormAdd(focusRow["PRJ_CODE"], frm);


                    frm.Show(this);
                }
                else
                {

                    base.ChildFormFocus(focusRow["PRJ_CODE"]);

                }

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }


        }


        private void acBarButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //삭제

            try
            {

                acGridView1.EndEditor();


                if (acMessageBox.Show(this, "정말 삭제하시겠습니까?", "TB43FSY3", true, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
                {
                    return;
                }

                DataRow[] selectedRows = acGridView1.GetSelectedDataRows();
             
                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("DEL_EMP", typeof(String)); //
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("PRJ_CODE", typeof(String)); //

                if (selectedRows.Length == 0)
                {
                    //단일
                    DataRow focusRow = acGridView1.GetFocusedDataRow();

                    DataRow paramRow = paramTable.NewRow();
                    paramRow["DEL_EMP"] = acInfo.UserID;
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["PRJ_CODE"] = focusRow["PRJ_CODE"];
                    paramTable.Rows.Add(paramRow);
                }
                else
                {
                    //다중
                    for (int i = 0; selectedRows.Length > i; i++)
                    {
                        DataRow paramRow = paramTable.NewRow();
                        paramRow["DEL_EMP"] = acInfo.UserID;
                        paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                        paramRow["PRJ_CODE"] = selectedRows[i]["PRJ_CODE"];
                        paramTable.Rows.Add(paramRow);
                    }

                }

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);


                //BizRun.QBizRun.ExecuteService(
                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.DEL,
                        "PLN18A_DEL", paramSet, "RQSTDT", "",
                        QuickDEL,
                        QuickException);

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }


        }

        void QuickDEL(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {

                //링크된 자식창 삭제
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


        private void acBarButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //새로만들기 업무일지편집기
            try
            {
                if (!base.ChildFormContains("NEW"))
                {
                    PLN18A_D0A frm = new PLN18A_D0A(acGridView1, null);

                    frm.DialogMode = BaseMenuDialog.emDialogMode.NEW;

                    frm.ParentControl = this;

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

        // 진행사항 편집기 열기
        private void acBarButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {

                DataRow focusRow = acGridView2.GetFocusedDataRow();


                if (focusRow == null)
                {
                    return;
                }

                if (!base.ChildFormContains(focusRow["PRJ_HIS_CODE"]))
                {

                    PLN18A_D1A frm = new PLN18A_D1A(acGridView2,focusRow);

                    frm.DialogMode = BaseMenuDialog.emDialogMode.OPEN;

                    frm.ParentControl = this;

                    base.ChildFormAdd(focusRow["PRJ_HIS_CODE"], frm);

                    frm.Show(this);
                }
                else
                {

                    base.ChildFormFocus(focusRow["PRJ_HIS_CODE"]);

                }

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        // 진행사항 편집기 새로만들기
        private void acBarButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                DataRow focusRow = acGridView1.GetFocusedDataRow();

                if (!base.ChildFormContains("NEW"))
                {

                    PLN18A_D1A frm = new PLN18A_D1A(acGridView2, focusRow);

                    frm.DialogMode = BaseMenuDialog.emDialogMode.NEW;

                    frm.ParentControl = this;

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

        // 진행사항 삭제
        private void acBarButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {

                acGridView2.EndEditor();

                if (acMessageBox.Show(this, "정말 삭제하시겠습니까?", "TB43FSY3", true, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
                {
                    return;
                }

                DataRow[] selectedRows = acGridView2.GetSelectedDataRows();

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("DEL_EMP", typeof(String)); //
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("PRJ_HIS_CODE", typeof(String)); //

                if (selectedRows.Length == 0)
                {
                    //단일
                    DataRow focusRow = acGridView2.GetFocusedDataRow();

                    DataRow paramRow = paramTable.NewRow();
                    paramRow["DEL_EMP"] = acInfo.UserID;
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["PRJ_HIS_CODE"] = focusRow["PRJ_HIS_CODE"];
                    paramTable.Rows.Add(paramRow);
                }
                else
                {
                    //다중
                    for (int i = 0; selectedRows.Length > i; i++)
                    {
                        DataRow paramRow = paramTable.NewRow();
                        paramRow["DEL_EMP"] = acInfo.UserID;
                        paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                        paramRow["PRJ_HIS_CODE"] = selectedRows[i]["PRJ_HIS_CODE"];
                        paramTable.Rows.Add(paramRow);
                    }

                }

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);


                //BizRun.QBizRun.ExecuteService(
                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.DEL,
                        "PLN18A_DEL2", paramSet, "RQSTDT", "",
                        QuickDEL2,
                        QuickException);

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }


        void QuickDEL2(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
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


    }
}
