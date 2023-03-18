using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using System.Reflection;
using ControlManager;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Grid;
using BizManager;

namespace STD
{
    public sealed partial class STD23B_M0A : BaseMenu
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


        public STD23B_M0A()
        {

            InitializeComponent();
        }

        void acLayoutControl2_OnValueKeyDown(object sender, IBaseEditControl info, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.SearchMC();
        }

        void acGridView1_ShowGridMenuEx(object sender, PopupMenuShowingEventArgs e)
        {
            acGridView view = sender as acGridView;

            if (e.MenuType == GridMenuType.Row)
            {
                GridHitInfo hitInfo = view.CalcHitInfo(e.Point);

                popupMenu2.ShowPopup(view.GridControl.PointToScreen(e.Point));
            }

        }

        void acGridView2_ShowGridMenuEx(object sender, PopupMenuShowingEventArgs e)
        {
            acGridView view = sender as acGridView;

            if (e.HitInfo.HitTest == GridHitTest.EmptyRow || e.HitInfo.HitTest == GridHitTest.Row || e.HitInfo.HitTest == GridHitTest.RowCell)
            {

                if (e.MenuType == GridMenuType.User)
                {
                    acBarButtonItem9.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    acBarButtonItem10.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    acBarButtonItem11.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;


                }
                else if (e.MenuType == GridMenuType.Row)
                {
                    if (e.HitInfo.RowHandle >= 0)
                    {
                        acBarButtonItem9.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        acBarButtonItem10.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        acBarButtonItem11.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    }
                    else
                    {
                        acBarButtonItem9.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        acBarButtonItem10.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        acBarButtonItem11.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    }
                }


                GridHitInfo hitInfo = view.CalcHitInfo(e.Point);

                popupMenu3.ShowPopup(view.GridControl.PointToScreen(e.Point));


            }

        }

        void dnCalender_OnDateChanged(DateTime value)
        {
            try
            {
                //if (this.IsMenuInit == false)
                //{
                //    return;
                //}



                //DataTable paramTable1 = new DataTable("RQSTDT");
                //paramTable1.Columns.Add("DATE1", typeof(String)); //기간(From)
                //paramTable1.Columns.Add("DATE2", typeof(String)); //기간(To)
                //paramTable1.Columns.Add("PLT_CODE", typeof(String)); //사업장코드

                //DataRow paramRow1 = paramTable1.NewRow();
                //paramRow1["DATE1"] = value.ToString("yyyyMMdd");
                //paramRow1["DATE2"] = value.ToString("yyyyMMdd");
                //paramRow1["PLT_CODE"] = acInfo.PLT_CODE;
                //paramTable1.Rows.Add(paramRow1);



                //DataSet paramSet = new DataSet();
                //paramSet.Tables.Add(paramTable1);

                //BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.NONE,
                //"STD23A_SER", paramSet, "RQSTDT", "RSLTDT",
                //QuickSearchMC,
                //QuickException);

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);

            }
        }


        void popupMenu1_BeforePopup(object sender, CancelEventArgs e)
        {
            if (dnCalender.HoliDayTable != null)
            {
                DataRow[] hoilResult = dnCalender.HoliDayTable.Select("HOLI_DATE = '" + dnCalender.DateTime.ToString("yyyyMMdd") + "'");

                if (hoilResult.Length == 0)
                {

                    acBarButtonItem1.Enabled = true;
                    acBarButtonItem2.Enabled = false;


                }
                else
                {
                    acBarButtonItem1.Enabled = false;
                    acBarButtonItem2.Enabled = true;
                }
            }

        }

        protected override void OnLoad(EventArgs e)
        {
            //this.Search();

            //this.SearchMC();

            base.OnLoad(e);
        }
        public override void MenuInit()
        {
            gvHoli.GridType = acGridView.emGridType.AUTO_COL;

            //gvHoli.AddCheckEdit("SEL", "선택", "40290", true, true, true, acGridView.emCheckEditDataType._STRING);

            gvHoli.AddDateEdit("DISP_HOLI_DATE", "일자", "T1R1O52X", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);

            gvHoli.AddTextEdit("HOLI_DATE", "일자", "T1R1O52X", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);

            gvHoli.AddTextEdit("HOLI_NAME", "휴일명", "QGZ6WHRI", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.GridType = acGridView.emGridType.SEARCH;

            //acGridView1.AddCheckEdit("SEL", "선택", "40290", true, true, true, acGridView.emCheckEditDataType._STRING);

            acGridView1.AddDateEdit("WORK_DATE", "일자", "T1R1O52X", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
            acGridView1.AddTextEdit("MC_CODE", "설비코드", "41162", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("MC_NAME", "설비명", "41202", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddLookUpEdit("MC_GROUP", "설비그룹", "40308", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "C020");
            acGridView1.AddTextEdit("CAPA", "CAPA", "40774", true, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.TIME);
            acGridView1.AddTextEdit("HOLI_NAME", "휴일명", "QGZ6WHRI", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("SCOMMENT", "CAPA 변경사유", "YQYEZL82", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.KeyColumn = new string[] { "MC_CODE" };

            acGridView2.GridType = acGridView.emGridType.AUTO_COL;

            acGridView2.AddCheckEdit("SEL", "선택", "40290", true, true, true, acGridView.emCheckEditDataType._STRING);
            acGridView2.AddDateEdit("WORK_MONTH", "월", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.MONTH_DATE);
            acGridView2.AddTextEdit("WORK_DAY", "월근무일수", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.F2);
            acGridView2.AddTextEdit("WORK_MONTH_TIME", "월별최대시간", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.F2);
            acGridView2.AddTextEdit("WORK_HOUR", "기본근무일수\r\n(근무일수*8)", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.F2);

            acGridView2.KeyColumn = new string[] { "WORK_MONTH" };

            acGridView2.ColumnPanelRowHeight = 50;

            dnCalender.OnChangeEditDate += new acDateNavigator.ChangeEditDateHandler(dnCalender_OnChangeEditDate);

            dnCalender.OnDateChanged += dnCalender_OnDateChanged;

            dnCalender.MouseClick += new MouseEventHandler(dnCalender_MouseClick);

            popupMenu1.BeforePopup += new CancelEventHandler(popupMenu1_BeforePopup);

            acGridView1.ShowGridMenuEx += acGridView1_ShowGridMenuEx;

            acGridView2.ShowGridMenuEx += acGridView2_ShowGridMenuEx;

            acGridView2.MouseDown += acGridView2_MouseDown;

            acLayoutControl2.OnValueKeyDown += acLayoutControl2_OnValueKeyDown;

            acLayoutControl1.GetEditor("YEAR").Value = acDateEdit.GetNowFirstYear();

            base.MenuInit();

        }

        private void acGridView2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                GridHitInfo hitInfo = acGridView2.CalcHitInfo(e.Location);

                if (hitInfo.HitTest == GridHitTest.RowCell || hitInfo.HitTest == GridHitTest.Row)
                {
                    acBarButtonItem10_ItemClick(null, null);
                }
            }
        }

        void dnCalender_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Clicks == 1 && e.Button == MouseButtons.Right)
            {
                popupMenu1.ShowPopup(dnCalender.PointToScreen(e.Location));
            }
        }


        void dnCalender_OnChangeEditDate(DevExpress.XtraEditors.Calendar.CalendarHitInfoType infoType)
        {
            if (infoType == DevExpress.XtraEditors.Calendar.CalendarHitInfoType.DecMonth ||
                infoType == DevExpress.XtraEditors.Calendar.CalendarHitInfoType.DecYear ||
                infoType == DevExpress.XtraEditors.Calendar.CalendarHitInfoType.IncMonth ||
                infoType == DevExpress.XtraEditors.Calendar.CalendarHitInfoType.IncYear
                )
            {

                this.Search();

            }
        }



        public override void MenuInitComplete()
        {



            dnCalender.DateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            dnCalender.MaxCalendar = 12;

            (acLayoutControl2.GetEditor("FR_DATE") as acDateEdit).DateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            (acLayoutControl2.GetEditor("TO_DATE") as acDateEdit).DateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);


            this.Search();

            base.MenuInitComplete();

        }

        void SearchMC()
        {
            try
            {
                DataTable dtParam = new DataTable("RQSTDT");
                dtParam.Columns.Add("PLT_CODE", typeof(String));
                dtParam.Columns.Add("DATE1", typeof(String));
                dtParam.Columns.Add("DATE2", typeof(String));

                DataRow layoutRow = acLayoutControl2.CreateParameterRow();


                DataRow paramRow = dtParam.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["DATE1"] = ((DateTime)layoutRow["FR_DATE"]).ToString("yyyyMMdd");
                paramRow["DATE2"] = ((DateTime)layoutRow["TO_DATE"]).ToString("yyyyMMdd");

                dtParam.Rows.Add(paramRow);

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(dtParam);

                DataSet resultSet = BizRun.QBizRun.ExecuteService(this, "STD23B_SER2", paramSet, "RQSTDT", "RSLTDT");

                acGridView1.GridControl.DataSource = resultSet.Tables["RSLTDT"];
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }


        void Search()
        {
            //달력 정보 갱신
            try
            {
                DataRow layoutRow = acLayoutControl1.CreateParameterRow();

                DateTime timeLastDateTime = new DateTime(
                    dnCalender.EndDateTime.Year,
                    dnCalender.EndDateTime.Month,
                    DateTime.DaysInMonth(dnCalender.EndDateTime.Year, dnCalender.EndDateTime.Month));

                DataTable paramTable2 = new DataTable("RQSTDT");
                paramTable2.Columns.Add("S_HOLI_DATE", typeof(String)); //기간(From)
                paramTable2.Columns.Add("E_HOLI_DATE", typeof(String)); //기간(To)
                paramTable2.Columns.Add("YEAR", typeof(String)); //년
                paramTable2.Columns.Add("PLT_CODE", typeof(String)); //사업장코드

                DataRow paramRow2 = paramTable2.NewRow();
                paramRow2["S_HOLI_DATE"] = dnCalender.StartDateTime.ToString("yyyyMMdd");
                paramRow2["E_HOLI_DATE"] = dnCalender.StartDateTime.AddMonths(12).ToString("yyyyMMdd"); //timeLastDateTime.ToString("yyyyMMdd");
                paramRow2["YEAR"] = layoutRow["YEAR"];
                paramRow2["PLT_CODE"] = acInfo.PLT_CODE;
                paramTable2.Rows.Add(paramRow2);

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable2);

                DataSet resultSet = BizRun.QBizRun.ExecuteService(this, "STD23B_SER", paramSet, "RQSTDT", "RSLTDT");

                dnCalender.HoliDayTable = resultSet.Tables["RSLTDT"];

                gvHoli.GridControl.DataSource = resultSet.Tables["RSLTDT"];

                gvHoli.SetOldFocusRowHandle(false);

                acGridView2.GridControl.DataSource = resultSet.Tables["RSLTDT_MNG"];


            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        void QuickException(object sender, QBiz qBiz, BizException ex)
        {
            acMessageBox.Show(this, ex);
        }

        void QuickSearch(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {

                gvHoli.GridControl.DataSource = e.result.Tables["RSLTDT"];

                gvHoli.SetOldFocusRowHandle(false);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        void QuickSearchMC(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {

                acGridView1.GridControl.DataSource = e.result.Tables["RSLTDT"];

                acGridView1.SetOldFocusRowHandle(false);
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
                this.SearchMC();
            }

            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }


        private void acBarButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //휴일설정

            try
            {
                STD23A_D1B frm = new STD23A_D1B(dnCalender.DateTime);

                frm.ParentControl = this;

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    DataTable paramTable = new DataTable("RQSTDT");
                    paramTable.Columns.Add("WORK_DATE");
                    paramTable.Columns.Add("HOLI_NAME");
                    paramTable.Columns.Add("PLT_CODE");
                    paramTable.Columns.Add("EMP_CODE");
                    DataRow paramRow = paramTable.NewRow();
                    paramRow["WORK_DATE"] = frm.HoliDateTime.ToString("yyyyMMdd");
                    paramRow["HOLI_NAME"] = frm.HoliReason;
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["EMP_CODE"] = acInfo.UserID;
                    paramTable.Rows.Add(paramRow);
                    DataSet paramSet = new DataSet();
                    paramSet.Tables.Add(paramTable);


                    BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.PROCESS,
                       "STD23B_UPD2", paramSet, "RQSTDT", "",
                       QuickProcess,
                       QuickException);

                }

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }


        }

        private void acBarButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //휴일해제

            try
            {


                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //사업장코드
                paramTable.Columns.Add("HOLI_DATE", typeof(String)); //휴일

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["HOLI_DATE"] = dnCalender.DateTime.ToString("yyyyMMdd");
                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.PROCESS,
                       "STD23B_UPD3", paramSet, "RQSTDT", "",
                       QuickProcess,
                       QuickException);



            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }


        void QuickProcess(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
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

        private void ModifyCapa()
        {
            try
            {
                DataRow focusRow = acGridView1.GetFocusedDataRow();

                STD23A_D2B frm = new STD23A_D2B(focusRow, acGridView1);

                frm.DialogMode = BaseMenuDialog.emDialogMode.OPEN;

                frm.ParentControl = this;

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    this.SetLog(QBiz.emExecuteType.PROCESS, "CAPA 정보가 수정되었습니다.");
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

        private void btnCreate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //생성
            try
            {
                STD23A_D0B frm = new STD23A_D0B();

                frm.ParentControl = this;


                if (frm.ShowDialog() == DialogResult.OK)
                {
                    this.Search();

                    this.SetLog(QBiz.emExecuteType.PROCESS, "CAPA 정보가 생성되었습니다.");
                }

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        private void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {

                STD23A_D3B frm = new STD23A_D3B(dnCalender.DateTime, acGridView1);

                frm.ParentControl = this;

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    this.SetLog(QBiz.emExecuteType.PROCESS, "CAPA 일괄 변경이 처리되었습니다.");

                }

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        //capa 변경
        private void acBarButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                this.ModifyCapa();
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

                STD23A_D4B frm = new STD23A_D4B();

                frm.ParentControl = this;

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    Search();
                }

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void acBarButtonItem9_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //새로만들기 - 근태
            try
            {
                if (!base.ChildFormContains("NEW"))
                {

                    STD23A_D5B frm = new STD23A_D5B(acGridView2, null);
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

        private void acBarButtonItem10_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //열기 - 근태
            try
            {
                DataRow focusRow = acGridView2.GetFocusedDataRow();

                string formKey = string.Format("{0}", focusRow["WORK_MONTH"]);

                if (!base.ChildFormContains(formKey))
                {
                    STD23A_D5B frm = new STD23A_D5B(acGridView2, focusRow);
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

        private void acBarButtonItem11_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //삭제 - 근태
            try
            {
                acGridView2.EndEditor();

                if (acMessageBox.Show(this, "정말 삭제하시겠습니까?", "TB43FSY3", true, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No) return;

                DataView selected = acGridView2.GetDataSourceView("SEL = '1'");

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("WORK_MONTH", typeof(String)); //

                if (selected.Count == 0)
                {
                    //단일삭제
                    DataRow focusRow = acGridView2.GetFocusedDataRow();

                    DataRow paramRow = paramTable.NewRow();
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["WORK_MONTH"] = focusRow["WORK_MONTH"].toDateString("yyyyMM");

                    paramTable.Rows.Add(paramRow);
                }
                else
                {
                    //다중삭제
                    for (int i = 0; i < selected.Count; i++)
                    {

                        DataRow paramRow = paramTable.NewRow();
                        paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                        paramRow["WORK_MONTH"] = selected[i]["WORK_MONTH"].toDateString("yyyyMM");

                        paramTable.Rows.Add(paramRow);
                    }

                }

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.DEL,
                "STD23B_DEL", paramSet, "RQSTDT", "",
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

