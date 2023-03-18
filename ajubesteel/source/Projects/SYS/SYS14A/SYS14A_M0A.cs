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

namespace SYS
{
    public sealed partial class SYS14A_M0A : BaseMenu
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

        //private acGridView _seletedGridView = null;

        public SYS14A_M0A()
        {
            InitializeComponent();


            acGridView1.MouseDown += new MouseEventHandler(acGridView1_MouseDown);

            // acGridView1.OnMapingRowChanged += new acGridView.MapingRowChangedEventHandler(acGridView1_OnMapingRowChanged);

            acGridView1.ShowGridMenuEx += new acGridView.ShowGridMenuExHandler(acGridView1_ShowGridMenuEx);

            acGridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(acGridView1_FocusedRowChanged);


            acBandGridView1.MouseDown += acBandGridView1_MouseDown;

            acBandGridView1.ShowGridMenuEx += acBandGridView1_ShowGridMenuEx;

            acBandGridView1.FocusedRowChanged += acBandGridView1_FocusedRowChanged;

            acLayoutControl1.OnValueKeyDown += new acLayoutControl.ValueKeyDownEventHandler(acLayoutControl1_OnValueKeyDown);

            acLayoutControl1.OnValueChanged += new acLayoutControl.ValueChangedEventHandler(acLayoutControl1_OnValueChanged);

            acTabControl1.SelectedPageChanged += acTabControl1_SelectedPageChanged;
            //_seletedGridView = acGridView1;
            this.Load += SYS14A_M0A_Load;

            acBarButtonItem4.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
        }

        private void acBandGridView1_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            this.GetDetail();
        }

        private void acBandGridView1_ShowGridMenuEx(object sender, PopupMenuShowingEventArgs e)
        {
            acBandGridView view = sender as acBandGridView;

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

        private void acBandGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            acBandGridView view = sender as acBandGridView;

            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                GridHitInfo hitInfo = view.CalcHitInfo(e.Location);

                if (hitInfo.HitTest == GridHitTest.RowCell || hitInfo.HitTest == GridHitTest.Row)
                {
                    //업무일지 편집기 열기

                    this.acBarButtonItem2_ItemClick(null, null);
                }

            }
        }

        private void acTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            switch (acTabControl1.GetSelectedContainerName())
            {
                case "A":
                    //_seletedGridView = acGridView1;
                    acCheckedComboBoxEdit1.RemoveItem(1);
                    acLayoutControl1.GetEditor("DATE").Value = "WORK_DATE";
                    acBarButtonItem4.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    acLayoutControlItem1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    acLayoutControl1.GetEditor("IS_ACT_FLAG").Value = null;
                    break;

                case "P":
                    acCheckedComboBoxEdit1.AddItem("계획일자", false, "", "PLAN_DATE", true, false);
                    acLayoutControl1.GetEditor("DATE").Value = "PLAN_DATE";
                    acBarButtonItem4.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    acLayoutControlItem1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    break;
            }
        }

        void SYS14A_M0A_Load(object sender, EventArgs e)
        {
            
        }

        void GetDetail()
        {
            try
            {
                switch (acTabControl1.GetSelectedContainerName())
                {
                    case "A":
                        if (acGridView1.ValidFocusRowHandle() == true)
                        {
                            DataRow focusRow = acGridView1.GetFocusedDataRow();

                            this.acAttachFileControl1.LinkKey = focusRow["DLOG_ID"];
                            this.acAttachFileControl1.ShowKey = new object[] { focusRow["DLOG_ID"] };

                        }
                        else
                        {
                            this.acAttachFileControl1.LinkKey = null;
                            this.acAttachFileControl1.ShowKey = null;
                        }
                        break;

                    case "P":
                        if (acBandGridView1.ValidFocusRowHandle() == true)
                        {
                            DataRow focusRow = acBandGridView1.GetFocusedDataRow();

                            this.acAttachFileControl2.LinkKey = focusRow["DLOG_ID"];
                            this.acAttachFileControl2.ShowKey = new object[] { focusRow["DLOG_ID"] };

                        }
                        else
                        {
                            this.acAttachFileControl2.LinkKey = null;
                            this.acAttachFileControl2.ShowKey = null;
                        }
                        break;
                }


                
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }


        }

        // 업무일지 건별 첨부파일 불러오기  
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

                layout.GetEditor("DATE").Value = "PLAN_DATE";
                layout.GetEditor("S_DATE").Value = acDateEdit.GetNowFirstYear();
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


        void acGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            acGridView view = sender as acGridView;

            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                GridHitInfo hitInfo = view.CalcHitInfo(e.Location);

                if (hitInfo.HitTest == GridHitTest.RowCell || hitInfo.HitTest == GridHitTest.Row)
                {
                    //업무일지 편집기 열기

                    this.acBarButtonItem2_ItemClick(null, null);
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

            acGridView1.AddLookUpEdit("DLOG_CAT", "분류", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "S095");
            
            acGridView1.AddLookUpEdit("DLOG_TYPE", "구분", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "S096");
            
            acGridView1.AddLookUpEdit("DLOG_PERIOD", "수행주기", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "S097");
            
            acGridView1.AddLookUpEdit("DLOG_PLAN", "수행예정시기", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "S098");

            acGridView1.AddDateEdit("WORK_DATE", "수행일자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);

            acGridView1.AddLookUpVendor("VEN_CODE", "고객명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false);
            
            acGridView1.AddTextEdit("RELATED_EMP", "관련자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddLookUpEdit("RELATED_PROD", "직무", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "S099");

            acGridView1.AddMemoEdit("CONTENTS", "직무내용", "", false, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, false, true, true, false);

            acGridView1.AddTextEdit("DLOG_TIME", "소요시간(분)", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.TIME);

            acGridView1.AddTextEdit("DLOG_HOUR_TIME", "소요시간", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.F1);

            acGridView1.AddTextEdit("SCOMMENT", "세부내용 및 특이사항", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddCheckEdit("HAS_ATTACH", "첨부파일유무", "", false, false, true, acGridView.emCheckEditDataType._STRING);

            acGridView1.AddHidden("DLOG_ID", typeof(String));

            acGridView1.KeyColumn = new string[] { "DLOG_ID" };


            acBandGridView1.GridType = acBandGridView.emGridType.SEARCH_SEL;

            acBandGridView1.OptionsView.ShowIndicator = true;

            acBandGridView1.AddLookUpEdit("DLOG_CAT", "분류", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "S095");

            acBandGridView1.AddLookUpEdit("DLOG_TYPE", "구분", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "S096");

            acBandGridView1.AddLookUpEdit("DLOG_PERIOD", "수행주기", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "S097");

            acBandGridView1.AddLookUpEdit("DLOG_PLAN", "수행예정시기", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "S098");

            acBandGridView1.AddLookUpVendor("VEN_CODE", "고객명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false);

            acBandGridView1.AddTextEdit("RELATED_EMP", "관련자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acBandGridView.emTextEditMask.NONE);

            acBandGridView1.AddLookUpEdit("RELATED_PROD", "직무", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "S099");

            acBandGridView1.AddMemoEdit("CONTENTS", "직무내용", "", false, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, false, true, true, false);

            acBandGridView1.AddDateEdit("PLAN_DATE", "계획일자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acBandGridView.emDateMask.SHORT_DATE, "계획");

            acBandGridView1.AddTextEdit("DLOG_PLAN_TIME", "예상 소요시간(분)", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.TIME, "계획");

            acBandGridView1.AddTextEdit("DLOG_PLAN_HOUR_TIME", "예상 소요시간", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.F1, "계획");

            acBandGridView1.AddTextEdit("PLAN_SCOMMENT", "세부내용 및 특이사항", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acBandGridView.emTextEditMask.NONE, "계획");

            acBandGridView1.AddDateEdit("WORK_DATE", "수행일자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acBandGridView.emDateMask.SHORT_DATE, "수행");

            acBandGridView1.AddTextEdit("DLOG_TIME", "소요시간(분)", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.TIME, "수행");

            acBandGridView1.AddTextEdit("DLOG_HOUR_TIME", "소요시간", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.F1, "수행");

            acBandGridView1.AddTextEdit("SCOMMENT", "세부내용 및 특이사항", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acBandGridView.emTextEditMask.NONE, "수행");

            acBandGridView1.AddCheckEdit("HAS_ATTACH", "첨부파일유무", "", false, false, true, acBandGridView.emCheckEditDataType._STRING);

            acBandGridView1.AddCheckEdit("DLOG_ACT_FLAG", "수행여부", "", false, false, true, acBandGridView.emCheckEditDataType._BYTE);

            acBandGridView1.AddHidden("DLOG_ID", typeof(String));

            acBandGridView1.KeyColumn = new string[] { "DLOG_ID" };

            acCheckedComboBoxEdit1.AddItem("수행일자", false, "", "WORK_DATE", true, false);

            acCheckedComboBoxEdit1.AddItem("계획일자", false, "", "PLAN_DATE", true, false);

            base.MenuInit();

        }


        public override void MenuInitComplete()
        {
            this.Search();

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
            paramTable.Columns.Add("EMP_CODE", typeof(String)); //
            paramTable.Columns.Add("DLOG_CAT", typeof(String)); //


            paramTable.Columns.Add("S_WORK_DATE", typeof(String)); //
            paramTable.Columns.Add("E_WORK_DATE", typeof(String)); //
            paramTable.Columns.Add("S_PLAN_DATE", typeof(String)); //
            paramTable.Columns.Add("E_PLAN_DATE", typeof(String)); //

            paramTable.Columns.Add("IS_ACT_FLAG", typeof(String)); //
            paramTable.Columns.Add("IS_ACT_FLAG2", typeof(String)); //

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["EMP_CODE"] = acInfo.UserID;
            //paramRow["DLOG_CAT"] = acTabControl1.GetSelectedContainerName();

            if (acTabControl1.GetSelectedContainerName() == "P")
            {
                if (layoutRow["IS_ACT_FLAG"].ToString() == "0")
                {
                    paramRow["IS_ACT_FLAG"] = "1";
                }
                else if (layoutRow["IS_ACT_FLAG"].ToString() == "1")
                {
                    paramRow["IS_ACT_FLAG2"] = "1";
                }
            }

            foreach (string key in acCheckedComboBoxEdit1.GetKeyChecked())
            {
                switch (key)
                {
                    case "WORK_DATE":
                        paramRow["S_WORK_DATE"] = ((DateTime)layoutRow["S_DATE"]).toDateString("yyyyMMdd");
                        paramRow["E_WORK_DATE"] = ((DateTime)layoutRow["E_DATE"]).toDateString("yyyyMMdd");
                        break;

                    case "PLAN_DATE":
                        paramRow["S_PLAN_DATE"] = ((DateTime)layoutRow["S_DATE"]).toDateString("yyyyMMdd");
                        paramRow["E_PLAN_DATE"] = ((DateTime)layoutRow["E_DATE"]).toDateString("yyyyMMdd");
                        break;
                }
            }

            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD, "SYS14A_SER2", paramSet, "RQSTDT", "RSLTDT",
               QuickSearch,
               QuickException);

        }

        void QuickSearch(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                if (acTabControl1.GetSelectedContainerName() == "A")
                {
                    acGridView1.GridControl.DataSource = e.result.Tables["RSLTDT"];

                    acGridView1.BestFitColumns();

                    if (e.result.Tables["RSLTDT2"].Rows.Count > 0)
                    {
                        acLayoutControl3.DataBind(e.result.Tables["RSLTDT2"].Rows[0], false);
                    }
                }
                else if (acTabControl1.GetSelectedContainerName() == "P")
                {
                    acBandGridView1.GridControl.DataSource = e.result.Tables["RSLTDT"];

                    acBandGridView1.BestFitColumns();

                    if (e.result.Tables["RSLTDT2"].Rows.Count > 0)
                    {
                        acLayoutControl2.DataBind(e.result.Tables["RSLTDT2"].Rows[0], false);
                    }
                }

                //_seletedGridView.GridControl.DataSource = e.result.Tables["RSLTDT"];

                //_seletedGridView.BestFitColumns();

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
                DataRow focusRow = null;

                if (acTabControl1.GetSelectedContainerName() == "A")
                {
                    focusRow = acGridView1.GetFocusedDataRow();
                }
                else if (acTabControl1.GetSelectedContainerName() == "P")
                {
                    focusRow = acBandGridView1.GetFocusedDataRow();
                }

                if (focusRow == null)
                {
                    return;
                }

                if (!base.ChildFormContains(focusRow["DLOG_ID"]))
                {
                    if (acTabControl1.GetSelectedContainerName() == "A")
                    {
                        SYS14A_D0A frm = new SYS14A_D0A(acGridView1, acBandGridView1, focusRow, acTabControl1.GetSelectedContainerName());

                        frm.DialogMode = BaseMenuDialog.emDialogMode.OPEN;

                        frm.ParentControl = this;

                        base.ChildFormAdd(focusRow["DLOG_ID"], frm);

                        frm.Show(this);
                    }
                    else if (acTabControl1.GetSelectedContainerName() == "P")
                    {
                        SYS14A_D1A frm = new SYS14A_D1A(acGridView1, acBandGridView1, focusRow, acTabControl1.GetSelectedContainerName());

                        frm.DialogMode = BaseMenuDialog.emDialogMode.OPEN;

                        frm.ParentControl = this;

                        base.ChildFormAdd(focusRow["DLOG_ID"], frm);

                        frm.Show(this);
                    }
                }
                else
                {
                    base.ChildFormFocus(focusRow["DLOG_ID"]);
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
                Del();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void Del()
        {
            try
            {
                if (acTabControl1.GetSelectedContainerName() == "A")
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
                    paramTable.Columns.Add("DLOG_ID", typeof(String)); //

                    if (selectedRows.Length == 0)
                    {
                        //단일
                        DataRow focusRow = acGridView1.GetFocusedDataRow();

                        DataRow paramRow = paramTable.NewRow();
                        paramRow["DEL_EMP"] = acInfo.UserID;
                        paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                        paramRow["DLOG_ID"] = focusRow["DLOG_ID"];
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
                            paramRow["DLOG_ID"] = selectedRows[i]["DLOG_ID"];
                            paramTable.Rows.Add(paramRow);
                        }
                    }

                    DataSet paramSet = new DataSet();
                    paramSet.Tables.Add(paramTable);

                    //BizRun.QBizRun.ExecuteService(
                    BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.DEL,
                            "SYS14A_DEL", paramSet, "RQSTDT", "",
                            QuickDEL,
                            QuickException);
                }
                else if (acTabControl1.GetSelectedContainerName() == "P")
                {
                    acBandGridView1.EndEditor();

                    if (acMessageBox.Show(this, "정말 삭제하시겠습니까?", "TB43FSY3", true, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
                    {
                        return;
                    }

                    DataRow[] selectedRows = acBandGridView1.GetSelectedDataRows();

                    DataTable paramTable = new DataTable("RQSTDT");
                    paramTable.Columns.Add("DEL_EMP", typeof(String)); //
                    paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                    paramTable.Columns.Add("DLOG_ID", typeof(String)); //

                    if (selectedRows.Length == 0)
                    {
                        //단일
                        DataRow focusRow = acBandGridView1.GetFocusedDataRow();

                        DataRow paramRow = paramTable.NewRow();
                        paramRow["DEL_EMP"] = acInfo.UserID;
                        paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                        paramRow["DLOG_ID"] = focusRow["DLOG_ID"];
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
                            paramRow["DLOG_ID"] = selectedRows[i]["DLOG_ID"];
                            paramTable.Rows.Add(paramRow);
                        }
                    }

                    DataSet paramSet = new DataSet();
                    paramSet.Tables.Add(paramTable);

                    //BizRun.QBizRun.ExecuteService(
                    BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.DEL,
                            "SYS14A_DEL", paramSet, "RQSTDT", "",
                            QuickDEL,
                            QuickException);
                }
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
                if (acTabControl1.GetSelectedContainerName() == "A")
                {
                    foreach (DataRow row in e.result.Tables["RQSTDT"].Rows)
                    {
                        acGridView1.DeleteMappingRow(row);

                    }
                }
                else if (acTabControl1.GetSelectedContainerName() == "P")
                {
                    foreach (DataRow row in e.result.Tables["RQSTDT"].Rows)
                    {
                        acBandGridView1.DeleteMappingRow(row);

                    }
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

                    if (acTabControl1.GetSelectedContainerName() == "A")
                    {
                        SYS14A_D0A frm = new SYS14A_D0A(acGridView1, acBandGridView1, null, acTabControl1.GetSelectedContainerName());

                        frm.DialogMode = BaseMenuDialog.emDialogMode.NEW;

                        frm.ParentControl = this;

                        base.ChildFormAdd("NEW", frm);

                        frm.Show(this);
                    }
                    else if (acTabControl1.GetSelectedContainerName() == "P")
                    {
                        SYS14A_D1A frm = new SYS14A_D1A(acGridView1, acBandGridView1, null, acTabControl1.GetSelectedContainerName());

                        frm.DialogMode = BaseMenuDialog.emDialogMode.NEW;

                        frm.ParentControl = this;

                        base.ChildFormAdd("NEW", frm);

                        frm.Show(this);
                    }
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

        private void acBarButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                DataRow focusRow = acBandGridView1.GetFocusedDataRow();
                DataRow[] selectedRows = acBandGridView1.GetSelectedDataRows();

                if (focusRow == null) return;

                SYS14A_D2A frm = new SYS14A_D2A(focusRow);

                frm.DialogMode = BaseMenuDialog.emDialogMode.NEW;

                frm.ParentControl = this;

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    DataRow frmRow = frm.OutputData as DataRow;

                    DataTable paramTable = new DataTable("RQSTDT");
                    paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                    paramTable.Columns.Add("DLOG_ID", typeof(String)); //
                    paramTable.Columns.Add("WORK_DATE", typeof(String)); //
                    paramTable.Columns.Add("DLOG_TIME", typeof(decimal)); //
                    paramTable.Columns.Add("SCOMMENT", typeof(String)); //
                    paramTable.Columns.Add("DLOG_ACT_FLAG", typeof(byte)); //

                    if (selectedRows.Length == 0)
                    {
                        DataRow paramRow = paramTable.NewRow();
                        paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                        paramRow["DLOG_ID"] = focusRow["DLOG_ID"];
                        paramRow["WORK_DATE"] = frmRow["WORK_DATE"];
                        paramRow["DLOG_TIME"] = frmRow["DLOG_TIME"];
                        paramRow["SCOMMENT"] = frmRow["SCOMMENT"];
                        paramRow["DLOG_ACT_FLAG"] = 1;
                        paramTable.Rows.Add(paramRow);

                    }
                    else
                    {
                        foreach (DataRow row in selectedRows)
                        {
                            DataRow paramRow = paramTable.NewRow();
                            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                            paramRow["DLOG_ID"] = row["DLOG_ID"];
                            paramRow["WORK_DATE"] = frmRow["WORK_DATE"];
                            paramRow["DLOG_TIME"] = frmRow["DLOG_TIME"];
                            paramRow["SCOMMENT"] = frmRow["SCOMMENT"];
                            paramRow["DLOG_ACT_FLAG"] = 1;
                            paramTable.Rows.Add(paramRow);
                        }
                    }

                    DataSet paramSet = new DataSet();
                    paramSet.Tables.Add(paramTable);

                    BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.SAVE, "SYS14A_INS3", paramSet, "RQSTDT", "RSLTDT",
                       QuickSave,
                       QuickException);
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void QuickSave(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                foreach (DataRow row in e.result.Tables["RSLTDT"].Rows)
                {
                    acBandGridView1.UpdateMapingRow(row, false);
                }
                acBandGridView1.ClearSelection();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        private void acBarButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //복사하여 등록

            DataRow focusRow = null;

            if (acTabControl1.GetSelectedContainerName() == "A")
            {
                focusRow = acGridView1.GetFocusedDataRow();
            }
            else if (acTabControl1.GetSelectedContainerName() == "P")
            {
                focusRow = acBandGridView1.GetFocusedDataRow();
            }

            if (focusRow == null)
            {
                return;
            }

            if (acTabControl1.GetSelectedContainerName() == "A")
            {
                SYS14A_D0A frm = new SYS14A_D0A(acGridView1, acBandGridView1, focusRow, acTabControl1.GetSelectedContainerName(), "COPY");

                frm.DialogMode = BaseMenuDialog.emDialogMode.OPEN;

                frm.ParentControl = this;

                frm.Show(this);
            }
            else if (acTabControl1.GetSelectedContainerName() == "P")
            {
                SYS14A_D1A frm = new SYS14A_D1A(acGridView1, acBandGridView1, focusRow, acTabControl1.GetSelectedContainerName(), "COPY");

                frm.DialogMode = BaseMenuDialog.emDialogMode.OPEN;

                frm.ParentControl = this;

                frm.Show(this);
            }
        }

        private void acBarButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //일괄변환
            try
            {
                DataRow focusRow = acBandGridView1.GetFocusedDataRow();
                DataRow[] selectedRows = acBandGridView1.GetSelectedDataRows();

                if (focusRow == null) return;

                SYS14A_D3A frm = new SYS14A_D3A(acBandGridView1);

                frm.DialogMode = BaseMenuDialog.emDialogMode.NEW;

                frm.ParentControl = this;

                if (frm.ShowDialog() == DialogResult.OK)
                {
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }
    }
}
