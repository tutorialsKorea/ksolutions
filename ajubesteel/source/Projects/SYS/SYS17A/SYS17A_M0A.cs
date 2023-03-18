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
    public sealed partial class SYS17A_M0A : BaseMenu
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




        public SYS17A_M0A()
        {
            InitializeComponent();

            acGridView1.MouseDown += new MouseEventHandler(acGridView1_MouseDown);

            acGridView1.ShowGridMenuEx += new acGridView.ShowGridMenuExHandler(acGridView1_ShowGridMenuEx);

            acGridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(acGridView1_FocusedRowChanged);

            acLayoutControl1.OnValueKeyDown += new acLayoutControl.ValueKeyDownEventHandler(acLayoutControl1_OnValueKeyDown);

            acLayoutControl1.OnValueChanged += new acLayoutControl.ValueChangedEventHandler(acLayoutControl1_OnValueChanged);

            // this.Load += SYS17A_M0A_Load;

        }
          

        //void SYS17A_M0A_Load(object sender, EventArgs e)
        //{
        //    this.Search();
        //}

        void GetDetail()
        {

            DataRow row = acGridView1.GetFocusedDataRow();

            if (row != null)
            {
                acLayoutControl2.DataBind(row, false);
            }
            else
            {
                acLayoutControl2.ClearValue();
            }

        }

        void GetReplyDetail(DataRow focus)
        {

            if (focus != null)
            {
                acLayoutControl2.DataBind(focus, false);
            }
            else
            {
                acLayoutControl2.ClearValue();
            }

        }

     
     
        void acGridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            this.GetDetail();
            //this.UpdateReader();

            acGridView1.EndEditor();

            try
            {
                if (acGridView1.ValidFocusRowHandle() == true)
                {
                    DataRow focusRow = acGridView1.GetFocusedDataRow();

                    this.acAttachFileControl1.LinkKey = focusRow["MEETING_ID"];
                    this.acAttachFileControl1.ShowKey = new object[] { focusRow["MEETING_ID"] };

                }
                else
                {
                    this.acAttachFileControl1.LinkKey = null;
                    this.acAttachFileControl1.ShowKey = null;
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void UpdateReader()
        {

            if (acGridView1.ValidFocusRowHandle() == false)
            {
                return;
            }

            DataRow focusRow = acGridView1.GetFocusedDataRow();

            string reders = focusRow["READER"].ToString();

            if (reders.Contains(acInfo.UserID)) // 읽은사람에 이미 로그인 계정이 있을 경우
            {
                return;
            }
            else 
            {
                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("MEETING_ID", typeof(String)); //
                paramTable.Columns.Add("READER", typeof(String)); //
                paramTable.Columns.Add("EMP_CODE", typeof(String)); //

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["MEETING_ID"] = focusRow["MEETING_ID"];
                paramRow["READER"] = acInfo.UserName + " (" + acInfo.UserID + ")";
                paramRow["EMP_CODE"] = acInfo.UserID;

                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.NONE, "SYS17A_UPD", paramSet, "RQSTDT", "RSLTDT",
                QuickReader,
                QuickException);

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

                layout.GetEditor("DATE").Value = "REG_DATE";
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
                acBarButtonItem5.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            }
            else if (e.MenuType == GridMenuType.Row)
            {
                if (e.HitInfo.RowHandle >= 0)
                {
                    acBarButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    acBarButtonItem3.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    acBarButtonItem5.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                }
                else
                {

                    acBarButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    acBarButtonItem3.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    acBarButtonItem5.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                }

            }


            if (e.HitInfo.HitTest == GridHitTest.EmptyRow || e.HitInfo.HitTest == GridHitTest.Row || e.HitInfo.HitTest == GridHitTest.RowCell)
            {

                GridHitInfo hitInfo = view.CalcHitInfo(e.Point);

                popupMenu1.ShowPopup(view.GridControl.PointToScreen(e.Point));

            }

            if (e.HitInfo.HitTest == GridHitTest.RowDetail)
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
                    //읽은사람등록
                    this.UpdateReader();
                    
                    //게시판 편집기 열기
                    this.acBarButtonItem2_ItemClick(null, null);
                }

            }
            else if (e.Button == MouseButtons.Left && e.Clicks == 1)
            {
                GetDetail();
            }
        }

        public override void MenuNotify(object data)
        {
            #region 주석
            //DataRow row = data as DataRow;

            //DataTable paramTable = new DataTable("RQSTDT");
            //paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            //paramTable.Columns.Add("NOTICE_ID", typeof(String)); //


            //DataRow paramRow = paramTable.NewRow();
            //paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            //if (row != null) paramRow["NOTICE_ID"] = row["SEARCH_KEY"];

            //paramTable.Rows.Add(paramRow);
            //DataSet paramSet = new DataSet();
            //paramSet.Tables.Add(paramTable);

            //BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD, "SYS03A_SER", paramSet, "RQSTDT", "RSLTDT",
            //    QuickSearch,
            //    QuickException);      
            #endregion

            base.MenuNotify(data);
        }


    



        private acGridView acGridView1detail = null;
        public override void MenuInit()
        {


            acGridView1.GridType = acGridView.emGridType.SEARCH_SEL;

            acGridView1.AddHidden("MEETING_ID", typeof(String));

           // acGridView1.AddCheckEdit("SEL", "선택", "40290", true, true, true, acGridView.emCheckEditDataType._STRING);

            acGridView1.AddLookUpEdit("ACC_LEVEL", "공개형태", "0S83T0JI", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "S011");

            acGridView1.AddTextEdit("TITLE", "제목", "40556", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

            //acGridView1.AddMemoEdit("CONTENTS", "내용", "O00RH4SM", false, DevExpress.Utils.HorzAlignment.Center, DevExpress.Utils.VertAlignment.Center, false, false, false, false);

            acGridView1.AddRitchEdit("CONTENTS", "내용", "O00RH4SM", false, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, false, true, true, false, DevExpress.XtraRichEdit.DocumentFormat.Html);

            acGridView1.AddHidden("RECEIVER", typeof(String));

            acGridView1.AddHidden("READER", typeof(String));

            acGridView1.AddLookUpEmp("REG_EMP", "등록자", "608I87JD", true, DevExpress.Utils.HorzAlignment.Center, false, true, false);
           
            acGridView1.AddTextEdit("REG_DATE", "등록일", "CZP2OQ22", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

           
            acGridView1.OptionsView.ColumnAutoWidth = true;

            acGridView1.KeyColumn = new string[] { "MEETING_ID" };

            acGridView1.OptionsDetail.ShowDetailTabs = false;

            acGridView1.Columns["REG_DATE"].SortOrder = DevExpress.Data.ColumnSortOrder.Descending;

            acGridView1detail = new acGridView(acGridView1.GridControl);

            acGridView1detail.GridType = acGridView.emGridType.SEARCH;

            acGridView1detail.AddHidden("MEETING_ID", typeof(String));

            acGridView1detail.AddPictrue("REPLY", "", "", false, DevExpress.Utils.HorzAlignment.Center, false, true);

            acGridView1detail.AddTextEdit("TITLE", "제목", "40542", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1detail.AddMemoEdit("CONTENTS", "내용", "O00RH4SM", false, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, false, false, true, false);

            acGridView1detail.AddLookUpEmp("REG_EMP", "등록자", "608I87JD", true, DevExpress.Utils.HorzAlignment.Center, false, true, false);

            acGridView1detail.AddTextEdit("REG_DATE", "등록일", "CZP2OQ22", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1detail.KeyColumn = new string[] { "LINK_ID" };

            //acGridView1detail.OptionsView.ShowColumnHeaders = false;

            acGridView1.GridControl.LevelTree.Nodes.Add("M", acGridView1detail);

            acGridView1detail.GotFocus += new EventHandler(acGridView1detail_GotFocus);

            acGridView1detail.DataSourceChanged += acGridView1detail_DataSourceChanged;

            acGridView1detail.MouseDown += acGridView1detail_MouseDown;

            acGridView1detail.MouseUp += acGridView1detail_MouseUp;

            acGridView1detail.CustomDrawCell += AcGridView1detail_CustomDrawCell;

            acCheckedComboBoxEdit1.AddItem("등록일", true, "CZP2OQ22", "REG_DATE", true, false);

            base.MenuInit();

        }

        private void acGridView1detail_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.Clicks == 1)
            {
                GridView childView = sender as GridView;

                DataRow focusRow = childView.GetFocusedDataRow();

                GetReplyDetail(focusRow);
            }
        }

        String _strReplyMeeting_id = "";

        void acGridView1detail_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Left && e.Clicks == 2)
                {
                    GridView childView = sender as GridView;

                    DataRow focusRow = childView.GetFocusedDataRow();

                    if (focusRow != null)
                    {
                        if (!base.ChildFormContains(focusRow["MEETING_ID"]))
                        {

                            SYS17A_D2A frm = new SYS17A_D2A(childView as acGridView, focusRow);

                            frm.DialogMode = BaseMenuDialog.emDialogMode.OPEN;

                            frm.ParentControl = this;

                            base.ChildFormAdd(focusRow["MEETING_ID"], frm);

                            //frm.Show(this);
                            if (frm.ShowDialog() == DialogResult.OK)
                            {
                                Search();
                            }
                        }
                        else
                        {

                            base.ChildFormFocus(focusRow["MEETING_ID"]);

                        }
                    }
                }

                if (e.Button == MouseButtons.Right)
                {
                    GridView childView = sender as GridView;

                    DataRow focusRow = childView.GetFocusedDataRow();

                    _strReplyMeeting_id = focusRow["MEETING_ID"].ToString();
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }


        private void AcGridView1detail_CustomDrawCell(object sender, RowCellCustomDrawEventArgs e)
        {
            e.Appearance.ForeColor = Color.Black;
        }


        void acGridView1detail_DataSourceChanged(object sender, EventArgs e)
        {
            GridView childView = sender as GridView;

            childView.Columns["REPLY"].Width = 10;

            childView.BestFitColumns();
        }


        void acGridView1detail_GotFocus(object sender, EventArgs e)
        {
            GridView childView = sender as GridView;

            GridView masterView = childView.ParentView as GridView;

            if (masterView.FocusedRowHandle != childView.SourceRowHandle)
            {
                masterView.FocusedRowHandle = childView.SourceRowHandle;

            }
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

        public void Search()
        {
            DataRow layoutRow = acLayoutControl1.CreateParameterRow();

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("REG_EMP", typeof(String)); //
            paramTable.Columns.Add("EMP_CODE", typeof(String)); //
            paramTable.Columns.Add("S_DATE", typeof(String)); //
            paramTable.Columns.Add("E_DATE", typeof(String)); //
            paramTable.Columns.Add("TITLE", typeof(String)); //
            paramTable.Columns.Add("METTING_TYPE", typeof(String)); //

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["REG_EMP"] = acInfo.UserID;
            paramRow["EMP_CODE"] = acInfo.UserID;
            paramRow["TITLE"] = layoutRow["TITLE_LIKE"];
            paramRow["METTING_TYPE"] = "COMMON";

            foreach (string key in acCheckedComboBoxEdit1.GetKeyChecked())
            {
                switch (key)
                {
                    case "REG_DATE":

                        //등록일
                        paramRow["S_DATE"] = ((DateTime)layoutRow["S_DATE"]).ToString("yyyy-MM-dd HH:mm:ss");
                        paramRow["E_DATE"] = ((DateTime)layoutRow["E_DATE"]).ToString("yyyy-MM-dd HH:mm:ss");
                        break;
                }
            }

            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet(); 
            paramSet.Tables.Add(paramTable);

            BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.NONE, "SYS17A_SER", paramSet, "RQSTDT", "RSLTDT,RSLTDT_REPLY",
               QuickSearch,
               QuickException);
            
        }

        void QuickException(object sender, QBiz QBiz, BizManager.BizException ex)
        {
            acMessageBox.Show(this, ex);
        }

        private DataTable contentsDt = null;

        void QuickSearch(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {

                if (e.result.Tables["RSLTDT"].Rows.Count != 0)
                {
                    e.result.Tables["RSLTDT_REPLY"].Columns.Add("REPLY", typeof(Bitmap));

                    for (int i = 0; i < e.result.Tables["RSLTDT_REPLY"].Rows.Count; i++)
                    {

                        e.result.Tables["RSLTDT_REPLY"].Rows[i]["REPLY"] = Resource.edit_redo2_1x;

                    }

                    DataTable titleDt = e.result.Tables["RSLTDT"].Copy();
                    contentsDt = e.result.Tables["RSLTDT_REPLY"].Copy();

                    contentsDt.TableName = "D";

                    DataSet plans = new DataSet();

                    plans.Tables.Add(titleDt);
                    plans.Tables.Add(contentsDt);

                    DataColumn keyColumn = titleDt.Columns["MEETING_ID"];
                    DataColumn foreignKeyColumn = contentsDt.Columns["LINK_ID"];

                    if (keyColumn != null && foreignKeyColumn != null)
                    {
                        plans.Relations.Add("M", keyColumn, foreignKeyColumn);
                    }

                    acGridView1.GridControl.DataSource = plans.Tables[0];
                    acGridView1.SetOldFocusRowHandle(false);
                }
                else
                {
                    acLayoutControl2.ClearValue();
                }
                

                base.SetLog(e.executeType, e.result.Tables["RSLTDT"].Rows.Count, e.executeTime);

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }



        void QuickReader(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                foreach (DataRow row in e.result.Tables["RSLTDT"].Rows)
                {
                    acGridView1.UpdateMapingRow(row, false);
                }
            }
            catch (Exception ex)
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

                if (!base.ChildFormContains(focusRow["MEETING_ID"]))
                {

                    SYS17A_D0A frm = new SYS17A_D0A(acGridView1, focusRow);

                    frm.DialogMode = BaseMenuDialog.emDialogMode.OPEN;

                    frm.ParentControl = this;

                    base.ChildFormAdd(focusRow["MEETING_ID"], frm);

                    frm.Show(this);

                }
                else
                {

                    base.ChildFormFocus(focusRow["MEETING_ID"]);

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
                paramTable.Columns.Add("MEETING_ID", typeof(String)); //

                if (selectedRows.Length == 0)
                {
                    //단일
                    DataRow focusRow = acGridView1.GetFocusedDataRow();

                    if (focusRow["REG_EMP"].ToString() != acInfo.UserID)
                    {
                        acMessageBox.Show("등록자가 아니면 삭제할 수 없습니다.", this.Text, acMessageBox.emMessageBoxType.CONFIRM);
                        return;
                    }

                    DataRow paramRow = paramTable.NewRow();
                    paramRow["DEL_EMP"] = acInfo.UserID;
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["MEETING_ID"] = focusRow["MEETING_ID"];
                    paramTable.Rows.Add(paramRow);
                }
                else
                {
                    //다중
                    for (int i = 0; selectedRows.Length > i; i++)
                    {

                        if (selectedRows[i]["REG_EMP"].ToString() != acInfo.UserID)
                        {
                            acMessageBox.Show("등록자가 아니면 삭제할 수 없습니다.", this.Text, acMessageBox.emMessageBoxType.CONFIRM);
                            return;
                        }

                        DataRow paramRow = paramTable.NewRow();
                        paramRow["DEL_EMP"] = acInfo.UserID;
                        paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                        paramRow["MEETING_ID"] = selectedRows[i]["MEETING_ID"];
                        paramTable.Rows.Add(paramRow);
                    }

                }

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);


                //BizRun.QBizRun.ExecuteService(
                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.DEL,
                        "SYS17A_DEL", paramSet, "RQSTDT", "",
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
            //새로만들기 게시판편집기
            try
            {
                if (!base.ChildFormContains("NEW"))
                {
                    SYS17A_D0A frm = new SYS17A_D0A(acGridView1, null);

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

        private void acBarButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {

                DataRow focusRow = acGridView1.GetFocusedDataRow();


                if (focusRow == null)
                {
                    return;
                }

                if (!base.ChildFormContains(focusRow["MEETING_ID"]))
                {

                    SYS17A_D1A frm = new SYS17A_D1A(acGridView1, focusRow);

                    frm.DialogMode = BaseMenuDialog.emDialogMode.OPEN;

                    frm.ParentControl = this;

                    base.ChildFormAdd(focusRow["MEETING_ID"], frm);

                    //frm.Show(this);
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        Search();
                    }

                }
                else
                {

                    base.ChildFormFocus(focusRow["MEETING_ID"]);

                }

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void acBarButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //삭제
            try
            {
                if (acMessageBox.Show(this, "정말 삭제하시겠습니까?", "TB43FSY3", true, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
                {
                    return;
                }
                
                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("DEL_EMP", typeof(String)); //
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("MEETING_ID", typeof(String)); //

                DataRow paramRow = paramTable.NewRow();
                paramRow["DEL_EMP"] = acInfo.UserID;
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["MEETING_ID"] = _strReplyMeeting_id;
                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);


                //BizRun.QBizRun.ExecuteService(
                BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.DEL,
                "SYS17A_DEL", paramSet, "RQSTDT", "",
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
                this.Search();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

    }
}
