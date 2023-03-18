using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using ControlManager;
using CodeHelperManager;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using BizManager;
using System.Linq;

namespace SAN
{
    public sealed partial class SAN05A_M0A : BaseMenu
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

        public SAN05A_M0A()
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

        public override void MenuInitComplete()
        {

            base.MenuInitComplete();
        }

        private Color _progColor = acInfo.SysConfig.GetSysConfigByMemory("APP_STATE_PROG").toColor();
        private Color _okColor = acInfo.SysConfig.GetSysConfigByMemory("APP_STATE_OK").toColor();
        private Color _denyColor = acInfo.SysConfig.GetSysConfigByMemory("APP_STATE_DENY").toColor();

        private DataTable _holiTable = null;

        private DataTable _stdHoliTable = null;
        public override void MenuInit()
        {
            acLayoutControl1.OnValueChanged += new acLayoutControl.ValueChangedEventHandler(acLayoutControl1_OnValueChanged);
            acLayoutControl1.OnValueKeyDown += new acLayoutControl.ValueKeyDownEventHandler(acLayoutControl1_OnValueKeyDown);

            DataSet resultSet = BizRun.QBizRun.ExecuteService(this, "CTRL", "GET_EMPLOYEE", acInfo.RefData, "RQSTDT", "RSLTDT");

            //승인/반려
            acGridView1.GridType = acGridView.emGridType.SEARCH_SEL;
            acGridView1.OptionsView.ShowIndicator = true;
            acGridView1.AddTextEdit("PLAN_NO", "계획번호", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("EMP_CODE", "사원코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("EMP_NAME", "사원명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("PLAN_YEAR", "년도", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("PLAN_SEQ", "차수", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddLookUpEdit("PLAN_STATUS", "상태", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "W008");
            acGridView1.AddDateEdit("REG_DATE", "신청일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.MEDIUM_DATE2);

            //acGridView1.AddLookUpEmp("APP_EMP1", "승인자1", string.Empty, false, DevExpress.Utils.HorzAlignment.Center, false, true, false);
            acGridView1.AddLookUpEdit("APP_EMP1", "승인자1", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "EMP_NAME", "EMP_CODE", resultSet.Tables["RSLTDT"]);
            acGridView1.AddTextEdit("APP_EMP_FLAG1", "승인자1상태", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            //acGridView1.AddLookUpEmp("APP_EMP2", "승인자2", string.Empty, false, DevExpress.Utils.HorzAlignment.Center, false, true, false);
            acGridView1.AddLookUpEdit("APP_EMP2", "승인자1", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "EMP_NAME", "EMP_CODE", resultSet.Tables["RSLTDT"]);
            acGridView1.AddTextEdit("APP_EMP_FLAG2", "승인자2상태", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            //acGridView1.AddLookUpEmp("APP_EMP3", "승인자3", string.Empty, false, DevExpress.Utils.HorzAlignment.Center, false, true, false);
            acGridView1.AddLookUpEdit("APP_EMP3", "승인자1", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "EMP_NAME", "EMP_CODE", resultSet.Tables["RSLTDT"]);
            acGridView1.AddTextEdit("APP_EMP_FLAG3", "승인자3상태", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            //acGridView1.AddLookUpEmp("APP_EMP4", "승인자4", string.Empty, false, DevExpress.Utils.HorzAlignment.Center, false, true, false);
            acGridView1.AddLookUpEdit("APP_EMP4", "승인자1", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "EMP_NAME", "EMP_CODE", resultSet.Tables["RSLTDT"]);
            acGridView1.AddTextEdit("APP_EMP_FLAG4", "승인자4상태", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);

            acGridView1.KeyColumn = new string[] { "PLAN_NO" };

            acGridView1.CustomDrawCell += acGridView_CustomDrawCell;

            acGridView1.FocusedRowChanged += acGridView_FocusedRowChanged;

            //승인 취소
            acGridView3.GridType = acGridView.emGridType.SEARCH_SEL;
            acGridView3.OptionsView.ShowIndicator = true;
            acGridView3.AddTextEdit("PLAN_NO", "계획번호", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView3.AddTextEdit("EMP_CODE", "사원코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView3.AddTextEdit("EMP_NAME", "사원명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView3.AddTextEdit("PLAN_YEAR", "년도", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView3.AddTextEdit("PLAN_SEQ", "차수", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView3.AddLookUpEdit("PLAN_STATUS", "상태", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "W008");
            acGridView3.AddDateEdit("REG_DATE", "신청일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.MEDIUM_DATE2);

            //acGridView3.AddLookUpEmp("APP_EMP1", "승인자1", string.Empty, false, DevExpress.Utils.HorzAlignment.Center, false, true, false);
            acGridView3.AddLookUpEdit("APP_EMP1", "승인자1", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "EMP_NAME", "EMP_CODE", resultSet.Tables["RSLTDT"]);
            acGridView3.AddTextEdit("APP_EMP_FLAG1", "승인자1상태", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            //acGridView3.AddLookUpEmp("APP_EMP2", "승인자2", string.Empty, false, DevExpress.Utils.HorzAlignment.Center, false, true, false);
            acGridView3.AddLookUpEdit("APP_EMP2", "승인자1", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "EMP_NAME", "EMP_CODE", resultSet.Tables["RSLTDT"]);
            acGridView3.AddTextEdit("APP_EMP_FLAG2", "승인자2상태", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            //acGridView3.AddLookUpEmp("APP_EMP3", "승인자3", string.Empty, false, DevExpress.Utils.HorzAlignment.Center, false, true, false);
            acGridView3.AddLookUpEdit("APP_EMP3", "승인자1", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "EMP_NAME", "EMP_CODE", resultSet.Tables["RSLTDT"]);
            acGridView3.AddTextEdit("APP_EMP_FLAG3", "승인자3상태", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            //acGridView3.AddLookUpEmp("APP_EMP4", "승인자4", string.Empty, false, DevExpress.Utils.HorzAlignment.Center, false, true, false);
            acGridView3.AddLookUpEdit("APP_EMP4", "승인자1", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "EMP_NAME", "EMP_CODE", resultSet.Tables["RSLTDT"]);
            acGridView3.AddTextEdit("APP_EMP_FLAG4", "승인자4상태", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);

            acGridView3.KeyColumn = new string[] { "PLAN_NO" };

            acGridView3.CustomDrawCell += acGridView_CustomDrawCell;

            acGridView3.FocusedRowChanged += acGridView_FocusedRowChanged;

            //반려 취소
            acGridView4.GridType = acGridView.emGridType.SEARCH_SEL;
            acGridView4.OptionsView.ShowIndicator = true;
            acGridView4.AddTextEdit("PLAN_NO", "계획번호", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView4.AddTextEdit("EMP_CODE", "사원코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView4.AddTextEdit("EMP_NAME", "사원명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView4.AddTextEdit("PLAN_YEAR", "년도", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView4.AddTextEdit("PLAN_SEQ", "차수", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView4.AddLookUpEdit("PLAN_STATUS", "상태", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "W008");
            acGridView4.AddDateEdit("REG_DATE", "신청일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.MEDIUM_DATE2);

            //acGridView4.AddLookUpEmp("APP_EMP1", "승인자1", string.Empty, false, DevExpress.Utils.HorzAlignment.Center, false, true, false);
            acGridView4.AddLookUpEdit("APP_EMP1", "승인자1", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "EMP_NAME", "EMP_CODE", resultSet.Tables["RSLTDT"]);
            acGridView4.AddTextEdit("APP_EMP_FLAG1", "승인자1상태", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            //acGridView4.AddLookUpEmp("APP_EMP2", "승인자2", string.Empty, false, DevExpress.Utils.HorzAlignment.Center, false, true, false);
            acGridView4.AddLookUpEdit("APP_EMP2", "승인자1", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "EMP_NAME", "EMP_CODE", resultSet.Tables["RSLTDT"]);
            acGridView4.AddTextEdit("APP_EMP_FLAG2", "승인자2상태", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            //acGridView4.AddLookUpEmp("APP_EMP3", "승인자3", string.Empty, false, DevExpress.Utils.HorzAlignment.Center, false, true, false);
            acGridView4.AddLookUpEdit("APP_EMP3", "승인자1", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "EMP_NAME", "EMP_CODE", resultSet.Tables["RSLTDT"]);
            acGridView4.AddTextEdit("APP_EMP_FLAG3", "승인자3상태", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            //acGridView4.AddLookUpEmp("APP_EMP4", "승인자4", string.Empty, false, DevExpress.Utils.HorzAlignment.Center, false, true, false);
            acGridView4.AddLookUpEdit("APP_EMP4", "승인자1", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "EMP_NAME", "EMP_CODE", resultSet.Tables["RSLTDT"]);
            acGridView4.AddTextEdit("APP_EMP_FLAG4", "승인자4상태", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);

            acGridView4.KeyColumn = new string[] { "PLAN_NO" };

            acGridView4.CustomDrawCell += acGridView_CustomDrawCell;

            acGridView4.FocusedRowChanged += acGridView_FocusedRowChanged;

            //상세
            acGridView2.GridType = acGridView.emGridType.SEARCH;
            acGridView2.OptionsView.ShowIndicator = true;
            acGridView2.AddTextEdit("DATE_PERIOD", "구분", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView2.AddTextEdit("1", " ", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("2", " ", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("3", " ", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("4", " ", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("5", " ", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("6", " ", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("7", " ", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("8", " ", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("9", " ", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("10", " ", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("11", " ", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("12", " ", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("13", " ", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("14", " ", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("15", " ", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("16", " ", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView2.CustomDrawCell += acGridView2_CustomDrawCell;

            (acLayoutControl1.GetEditor("PLAN_YEAR") as acDateEdit).Properties.EditMask = "yyyy";

            acTabControl1.SelectedPageChanged += acTabControl1_SelectedPageChanged;

            btnApproval.Enabled = false;
            btnApproval.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

            btnCancel.Enabled = false;
            btnCancel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            btnReject.Enabled = false;
            btnReject.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

            btnRejectCancel.Enabled = false;
            btnRejectCancel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            acGridView1.RowCountChanged += acGridView_RowCountChanged;
            acGridView3.RowCountChanged += acGridView_RowCountChanged;
            acGridView4.RowCountChanged += acGridView_RowCountChanged;

            base.MenuInit();
        }

        private void acGridView_RowCountChanged(object sender, EventArgs e)
        {
            acGridView gridView = sender as acGridView;

            string tabName = acTabControl1.GetSelectedContainerName();

            bool isEnabled = false;

            if (gridView.RowCount > 0)
            {
                isEnabled = true;
            }
            else
            {
                isEnabled = false;
            }

            switch (tabName)
            {
                case "REQ_APP":
                    btnApproval.Enabled = isEnabled;
                    btnReject.Enabled = isEnabled;
                    break;

                case "APP_CANCEL":
                    btnCancel.Enabled = isEnabled;
                    break;

                case "REJ_CANCEL":
                    btnRejectCancel.Enabled = isEnabled;
                    break;
            }
        }

        private void acTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            acTabControl tabControl = sender as acTabControl;
            DataRow focusRow = null;
            switch (tabControl.GetSelectedContainerName())
            {
                case "REQ_APP": //신청 승인/반려

                    //btnApproval.Enabled = true;
                    btnApproval.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

                    //btnCancel.Enabled = false;
                    btnCancel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

                    //btnReject.Enabled = true;
                    btnReject.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

                    //btnRejectCancel.Enabled = false;
                    btnRejectCancel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

                    focusRow = acGridView1.GetFocusedDataRow();

                    break;

                case "APP_CANCEL": //승인취소

                    //btnApproval.Enabled = false;
                    btnApproval.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

                    //btnCancel.Enabled = true;
                    btnCancel.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

                    //btnReject.Enabled = false;
                    btnReject.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

                    //btnRejectCancel.Enabled = false;
                    btnRejectCancel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

                    focusRow = acGridView3.GetFocusedDataRow();

                    break;

                case "REJ_CANCEL": //반려취소

                    //btnApproval.Enabled = false;
                    btnApproval.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

                    //btnCancel.Enabled = false;
                    btnCancel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

                    //btnReject.Enabled = false;
                    btnReject.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

                    //btnRejectCancel.Enabled = true;
                    btnRejectCancel.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

                    focusRow = acGridView4.GetFocusedDataRow();

                    break;
            }

            this.GetDetail(focusRow);
        }

        void acGridView1_ShowGridMenuEx(object sender, PopupMenuShowingEventArgs e)
        {
            acGridView view = sender as acGridView;

            if (e.HitInfo.HitTest == GridHitTest.EmptyRow || e.HitInfo.HitTest == GridHitTest.Row || e.HitInfo.HitTest == GridHitTest.RowCell)
            {

                if (e.MenuType == GridMenuType.User)
                {
                    acBarButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    acBarButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    acBarButtonItem3.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
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
                        acBarButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        acBarButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        acBarButtonItem3.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    }
                }

                GridHitInfo hitInfo = view.CalcHitInfo(e.Point);

                popupMenu1.ShowPopup(view.GridControl.PointToScreen(e.Point));

            }
        }

        private void acGridView_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            try
            {
                acGridView gridView = sender as acGridView;

                if (e.RowHandle < 0) return;

                string app1 = gridView.GetRowCellValue(e.RowHandle, "APP_EMP_FLAG1").ToString();
                string app2 = gridView.GetRowCellValue(e.RowHandle, "APP_EMP_FLAG2").ToString();
                string app3 = gridView.GetRowCellValue(e.RowHandle, "APP_EMP_FLAG3").ToString();
                string app4 = gridView.GetRowCellValue(e.RowHandle, "APP_EMP_FLAG4").ToString();

                if (e.Column.FieldName.StartsWith("APP_EMP"))
                {
                    if (e.Column.FieldName.IndexOf("1") > -1)
                    {
                        //if (app1 != "0")
                        //{
                        e.Appearance.BackColor = GetStatColor(app1);
                        e.Appearance.ForeColor = GetStatFontColor(app1);
                        //}
                    }
                    else if (e.Column.FieldName.IndexOf("2") > -1)
                    {
                        //if (app2 != "0")
                        //{
                        e.Appearance.BackColor = GetStatColor(app2);
                        e.Appearance.ForeColor = GetStatFontColor(app2);
                        //}
                    }
                    else if (e.Column.FieldName.IndexOf("3") > -1)
                    {
                        //if (app3 != "0")
                        //{
                        e.Appearance.BackColor = GetStatColor(app3);
                        e.Appearance.ForeColor = GetStatFontColor(app3);
                        //}
                    }
                    else if (e.Column.FieldName.IndexOf("4") > -1)
                    {
                        //if (app4 != "0")
                        //{
                        e.Appearance.BackColor = GetStatColor(app4);
                        e.Appearance.ForeColor = GetStatFontColor(app4);
                        //}
                    }
                }
            }
            catch { }
        }

        Color GetStatColor(string flag)
        {
            Color color = Color.Transparent;

            switch (flag)
            {
                case "0":
                    color = _progColor;
                    break;

                case "1":
                    color = _okColor;
                    break;

                case "2":
                    color = _denyColor;
                    break;
            }

            return color;
        }

        Color GetStatFontColor(string flag)
        {
            Color color = Color.Black;

            switch (flag)
            {
                case "0":
                    color = Color.Black;
                    break;

                case "1":
                    color = Color.Black;
                    break;

                case "2":
                    color = Color.Black;
                    break;
            }

            return color;
        }

        private void acGridView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                acGridView gridView = sender as acGridView;

                DataRow focusRow = gridView.GetFocusedDataRow();

                GetDetail(focusRow);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void acGridView2_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.RowHandle < 0) return;
            if (_stdHoliTable == null) return;

            string month = acGridView2.GetRowCellValue(e.RowHandle, "PLAN_MONTH").ToString();

            foreach (acGridColumn col in acGridView2.Columns)
            {
                if (!col.FieldName.isNumeric())
                {
                    continue;
                }
                //string day = col.FieldName.PadLeft(2, '0');
                string day = acGridView2.GetRowCellValue(e.RowHandle, col.FieldName).ToString().PadLeft(2, '0');

                if (day == "00") continue;

                DataRow[] rows = _stdHoliTable.Select("HOLI_DATE = '" + month + day + "'");

                DateTime dt = new DateTime(month.Substring(0, 4).toInt(), month.Substring(4, 2).toInt(), day.toInt(), 0, 0, 0);

                if (rows.Length > 0
                    || dt.DayOfWeek == DayOfWeek.Saturday
                    || dt.DayOfWeek == DayOfWeek.Sunday)
                {
                    if (e.Column.FieldName == col.FieldName)
                    {
                        e.Appearance.ForeColor = Color.Red;
                    }
                }

                rows = _holiTable.Select("PLAN_DATE = '" + month + day + "'");

                if (rows.Length > 0)
                {
                    if (e.Column.FieldName == col.FieldName)
                    {
                        e.Appearance.BackColor = Color.Yellow;
                        e.Appearance.ForeColor = Color.Green;
                    }
                }
            }

        }

        public override void ChildContainerInit(Control sender)
        {
            if (sender == acLayoutControl1)
            {
                acLayoutControl layout = sender as acLayoutControl;

                layout.GetEditor("PLAN_YEAR").Value = acDateEdit.GetNowFirstYear();
            }

            base.ChildContainerInit(sender);
        }

        void acLayoutControl1_OnValueChanged(object sender, IBaseEditControl info, object newValue)
        {
            //acLayoutControl layout = sender as acLayoutControl;

            //switch (info.ColumnName)
            //{
            //    case "EMP_CODE":

            //        break;
            //}

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
            if (acLayoutControl1.ValidCheck() == false) return;

            DataRow layoutRow = acLayoutControl1.CreateParameterRow();

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String));
            paramTable.Columns.Add("PLAN_YEAR", typeof(String));
            paramTable.Columns.Add("SER_TYPE", typeof(String)); //
            paramTable.Columns.Add("REG_EMP", typeof(String)); //

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["PLAN_YEAR"] = layoutRow["PLAN_YEAR"];
            paramRow["SER_TYPE"] = acTabControl1.GetSelectedContainerName();
            paramRow["REG_EMP"] = acInfo.UserID;

            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();

            paramSet.Tables.Add(paramTable);

            BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD, "SAN05A_SER", paramSet, "RQSTDT", "RSLTDT",
            QuickSearch,
            QuickException);
        }

        void QuickSearch(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                switch (e.result.Tables["RQSTDT"].Rows[0]["SER_TYPE"].ToString())
                {
                    case "REQ_APP":
                        acGridView1.GridControl.DataSource = e.result.Tables["RSLTDT"];
                        acGridView1.BestFitColumns();
                        break;

                    case "APP_CANCEL":
                        acGridView3.GridControl.DataSource = e.result.Tables["RSLTDT"];
                        acGridView3.BestFitColumns();
                        break;

                    case "REJ_CANCEL":
                        acGridView4.GridControl.DataSource = e.result.Tables["RSLTDT"];
                        acGridView4.BestFitColumns();
                        break;
                }

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

        void GetDetail(DataRow focusRow)
        {
            //DataRow focusRow = acGridView1.GetFocusedDataRow();

            if (focusRow == null)
            {
                acGridView2.ClearRow();
                return;
            }

            if (focusRow["PLAN_YEAR"].ToString() == "") return;

            int iMonth = 1;
            if (focusRow["PLAN_SEQ"].ToString() == "2")
            {
                iMonth = 7;
            }

            DateTime planDT = new DateTime(focusRow["PLAN_YEAR"].toInt(), iMonth, 1);

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(string));
            paramTable.Columns.Add("PLAN_MON", typeof(string));
            paramTable.Columns.Add("PLAN_MONTH", typeof(string));
            paramTable.Columns.Add("PLAN_NO", typeof(string));

            for (int i = 0; i < 6; i++)
            {
                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["PLAN_MON"] = planDT.toDateString("yyyyMM");
                paramRow["PLAN_MONTH"] = planDT.toDateString("yyyy-MM");
                paramRow["PLAN_NO"] = focusRow["PLAN_NO"];

                paramTable.Rows.Add(paramRow);
                planDT = planDT.AddMonths(1);
            }


            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD_DETAIL, "WOR04A_SER2", paramSet, "RQSTDT", "RSLTDT",
            QuickDetailSearch,
            QuickException);
        }

        void QuickDetailSearch(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                _stdHoliTable = e.result.Tables["RSLTDT_HOLI"];
                _holiTable = e.result.Tables["RSLTDT_PLAN"];

                acGridView2.GridControl.DataSource = e.result.Tables["RSLTDT"];

                acGridView2.BestFitColumns();

                base.SetLog(e.executeType, e.result.Tables["RSLTDT"].Rows.Count, e.executeTime);

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
                //승인
                acGridView1.EndEditor();

                DataRow focusRow = acGridView1.GetFocusedDataRow();

                if (focusRow == null) return;

                if (acMessageBox.Show(this, "정말 승인 하시겠습니까?", "", false, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
                {
                    return;
                }

                DataRow[] selected = acGridView1.GetSelectedDataRows();

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("REG_EMP", typeof(String));
                paramTable.Columns.Add("PLT_CODE", typeof(String));
                paramTable.Columns.Add("PLAN_NO", typeof(String));
                paramTable.Columns.Add("APP_FLAG", typeof(String));
                paramTable.Columns.Add("SER_TYPE", typeof(String));

                if (selected.Length == 0)
                {
                    //단일승인

                    DataRow paramRow = paramTable.NewRow();
                    paramRow["REG_EMP"] = acInfo.UserID;
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["PLAN_NO"] = focusRow["PLAN_NO"];
                    paramRow["APP_FLAG"] = "1";
                    paramRow["SER_TYPE"] = acTabControl1.GetSelectedContainerName();
                    paramTable.Rows.Add(paramRow);
                }
                else
                {
                    //다중승인
                    //for (int i = 0; i < selectedView.Count; i++)
                    foreach (DataRow row in selected)
                    {
                        DataRow paramRow = paramTable.NewRow();
                        paramRow["REG_EMP"] = acInfo.UserID;
                        paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                        paramRow["PLAN_NO"] = row["PLAN_NO"];
                        paramRow["APP_FLAG"] = "1";
                        paramRow["SER_TYPE"] = acTabControl1.GetSelectedContainerName();
                        paramTable.Rows.Add(paramRow);
                    }
                }

                DataSet paramSet = new DataSet();

                paramSet.Tables.Add(paramTable);


                BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.PROCESS,
                "SAN05A_UPD", paramSet, "RQSTDT", "RSLTDT",
                QuickUPD,
                QuickException);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void QuickUPD(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                foreach (DataRow row in e.result.Tables["RQSTDT"].Rows)
                {
                    acGridView1.DeleteMappingRow(row);
                }

                acAlert.Show(this, "승인되었습니다.", acAlertForm.enmType.Success);
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
                //승인취소
                acGridView3.EndEditor();

                DataRow focusRow = acGridView3.GetFocusedDataRow();

                if (focusRow == null) return;


                if (acMessageBox.Show(this, "정말 승인취소 하시겠습니까?", "", false, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
                {
                    return;
                }

                //DataView selectedView = acGridView3.GetDataSourceView("SEL = '1'");
                DataRow[] selected = acGridView3.GetSelectedDataRows();

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("REG_EMP", typeof(String));
                paramTable.Columns.Add("PLT_CODE", typeof(String));
                paramTable.Columns.Add("PLAN_NO", typeof(String));
                paramTable.Columns.Add("APP_FLAG", typeof(String));
                paramTable.Columns.Add("SER_TYPE", typeof(String));

                if (selected.Length == 0)
                {
                    //단일승인취소
                    DataRow paramRow = paramTable.NewRow();
                    paramRow["REG_EMP"] = acInfo.UserID;
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["PLAN_NO"] = focusRow["PLAN_NO"];
                    paramRow["APP_FLAG"] = "0";
                    paramRow["SER_TYPE"] = acTabControl1.GetSelectedContainerName();
                    paramTable.Rows.Add(paramRow);
                }
                else
                {
                    //다중승인취소
                    //for (int i = 0; i < selectedView.Count; i++)
                    foreach (DataRow row in selected)
                    {
                        DataRow paramRow = paramTable.NewRow();
                        paramRow["REG_EMP"] = acInfo.UserID;
                        paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                        paramRow["PLAN_NO"] = row["PLAN_NO"];
                        paramRow["APP_FLAG"] = "0";
                        paramRow["SER_TYPE"] = acTabControl1.GetSelectedContainerName();
                        paramTable.Rows.Add(paramRow);
                    }
                }

                DataSet paramSet = new DataSet();

                paramSet.Tables.Add(paramTable);


                BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.PROCESS,
                "SAN05A_UPD2", paramSet, "RQSTDT", "RSLTDT",
                QuickUPD2,
                QuickException);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void QuickUPD2(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                foreach (DataRow row in e.result.Tables["RQSTDT"].Rows)
                {
                    acGridView3.DeleteMappingRow(row);
                }

                acAlert.Show(this, "승인취소되었습니다.", acAlertForm.enmType.Warning);
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
                //반려
                acGridView1.EndEditor();

                DataRow focusRow = acGridView1.GetFocusedDataRow();

                if (focusRow == null) return;

                if (acMessageBox.Show(this, "정말 반려 하시겠습니까?", "", false, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
                {
                    return;
                }

                //DataView selectedView = acGridView1.GetDataSourceView("SEL = '1'");
                DataRow[] selected = acGridView1.GetSelectedDataRows();

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("REG_EMP", typeof(String));
                paramTable.Columns.Add("PLT_CODE", typeof(String));
                paramTable.Columns.Add("PLAN_NO", typeof(String));
                paramTable.Columns.Add("APP_FLAG", typeof(String));
                paramTable.Columns.Add("SER_TYPE", typeof(String));

                if (selected.Length == 0)
                {
                    //단일반려

                    DataRow paramRow = paramTable.NewRow();
                    paramRow["REG_EMP"] = acInfo.UserID;
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["PLAN_NO"] = focusRow["PLAN_NO"];
                    paramRow["APP_FLAG"] = "2";
                    paramRow["SER_TYPE"] = acTabControl1.GetSelectedContainerName();
                    paramTable.Rows.Add(paramRow);
                }
                else
                {
                    //다중반려
                    foreach (DataRow row in selected)
                    {
                        DataRow paramRow = paramTable.NewRow();
                        paramRow["REG_EMP"] = acInfo.UserID;
                        paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                        paramRow["PLAN_NO"] = row["PLAN_NO"];
                        paramRow["APP_FLAG"] = "2";
                        paramRow["SER_TYPE"] = acTabControl1.GetSelectedContainerName();
                        paramTable.Rows.Add(paramRow);
                    }
                }

                DataSet paramSet = new DataSet();

                paramSet.Tables.Add(paramTable);


                BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.PROCESS,
                "SAN05A_UPD3", paramSet, "RQSTDT", "RSLTDT",
                QuickUPD3,
                QuickException);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void QuickUPD3(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                foreach (DataRow row in e.result.Tables["RQSTDT"].Rows)
                {
                    acGridView1.DeleteMappingRow(row);
                }

                acAlert.Show(this, "반려되었습니다.", acAlertForm.enmType.Error);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        private void acBarButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                //반려취소
                acGridView4.EndEditor();

                DataRow focusRow = acGridView4.GetFocusedDataRow();

                if (focusRow == null) return;

                if (acMessageBox.Show(this, "정말 반려취소 하시겠습니까?", "", false, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
                {
                    return;
                }

                //DataView selectedView = acGridView4.GetDataSourceView("SEL = '1'");
                DataRow[] selected = acGridView4.GetSelectedDataRows();

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("REG_EMP", typeof(String));
                paramTable.Columns.Add("PLT_CODE", typeof(String));
                paramTable.Columns.Add("PLAN_NO", typeof(String));
                paramTable.Columns.Add("APP_FLAG", typeof(String));
                paramTable.Columns.Add("SER_TYPE", typeof(String));

                if (selected.Length == 0)
                {
                    //단일반려

                    DataRow paramRow = paramTable.NewRow();
                    paramRow["REG_EMP"] = acInfo.UserID;
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["PLAN_NO"] = focusRow["PLAN_NO"];
                    paramRow["APP_FLAG"] = "0";
                    paramRow["SER_TYPE"] = acTabControl1.GetSelectedContainerName();
                    paramTable.Rows.Add(paramRow);
                }
                else
                {
                    //다중반려
                    foreach (DataRow row in selected)
                    {
                        DataRow paramRow = paramTable.NewRow();
                        paramRow["REG_EMP"] = acInfo.UserID;
                        paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                        paramRow["PLAN_NO"] = row["PLAN_NO"];
                        paramRow["APP_FLAG"] = "0";
                        paramRow["SER_TYPE"] = acTabControl1.GetSelectedContainerName();
                        paramTable.Rows.Add(paramRow);
                    }
                }

                DataSet paramSet = new DataSet();

                paramSet.Tables.Add(paramTable);


                BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.PROCESS,
                "SAN05A_UPD2", paramSet, "RQSTDT", "RSLTDT",
                QuickUPD4,
                QuickException);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void QuickUPD4(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                foreach (DataRow row in e.result.Tables["RQSTDT"].Rows)
                {
                    acGridView4.DeleteMappingRow(row);
                }

                acAlert.Show(this, "반려취소되었습니다.", acAlertForm.enmType.Warning);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }
    }
}

