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
using DevExpress.XtraSpreadsheet;
using DevExpress.Spreadsheet;
using System.IO;

namespace WOR
{
    public sealed partial class WOR05A_M0A : BaseMenu
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

        public WOR05A_M0A()
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

            acGridView1.GridType = acGridView.emGridType.SEARCH;
            acGridView1.OptionsView.ShowIndicator = true;
            acGridView1.AddTextEdit("PLAN_NO", "계획번호", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("EMP_CODE", "사원코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("EMP_NAME", "사원명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("PLAN_YEAR", "년도", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("PLAN_SEQ", "차수", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddLookUpEdit("PLAN_STATUS", "상태", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, "W008");
            acGridView1.AddDateEdit("REG_DATE", "신청일", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emDateMask.MEDIUM_DATE);

            acGridView1.AddLookUpEdit("EMP_TITLE", "직책", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "C040");
            acGridView1.AddTextEdit("ORG_CODE", "부서코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("ORG_NAME", "부서명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddDateEdit("HIRE_DATE", "입사일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);

            acGridView1.AddTextEdit("YEAR_HOLI", "발생연차", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("USE_HOLI", "사용연차", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("POS_HOLI", "가능연차", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("REQ_HOLI", "신청연차", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddLookUpEmp("APP_EMP1", "승인자1", string.Empty, false, DevExpress.Utils.HorzAlignment.Center, false, false, false);
            acGridView1.AddTextEdit("APP_EMP_FLAG1", "승인자1상태", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddLookUpEmp("APP_EMP2", "승인자2", string.Empty, false, DevExpress.Utils.HorzAlignment.Center, false, false, false);
            acGridView1.AddTextEdit("APP_EMP_FLAG2", "승인자2상태", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddLookUpEmp("APP_EMP3", "승인자3", string.Empty, false, DevExpress.Utils.HorzAlignment.Center, false, false, false);
            acGridView1.AddTextEdit("APP_EMP_FLAG3", "승인자3상태", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddLookUpEmp("APP_EMP4", "승인자4", string.Empty, false, DevExpress.Utils.HorzAlignment.Center, false, false, false);
            acGridView1.AddTextEdit("APP_EMP_FLAG4", "승인자4상태", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);

            acGridView1.KeyColumn = new string[] { "PLAN_NO" };

            //acGridView1.ShowGridMenuEx += acGridView1_ShowGridMenuEx;

            //acGridView1.MouseDown += acGridView1_MouseDown;

            acGridView1.CustomDrawCell += acGridView1_CustomDrawCell;

            acGridView1.FocusedRowChanged += acGridView1_FocusedRowChanged;

            acGridView2.GridType = acGridView.emGridType.SEARCH;
            acGridView2.OptionsView.ShowIndicator = true;
            acGridView2.AddTextEdit("PLAN_MONTH", "월", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
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

            base.MenuInit();
        }

        void acGridView1_ShowGridMenuEx(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
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

        private void acGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                GridHitInfo hitInfo = acGridView1.CalcHitInfo(e.Location);

                if (hitInfo.HitTest == GridHitTest.RowCell || hitInfo.HitTest == GridHitTest.Row)
                {
                    acBarButtonItem2_ItemClick(null, null);
                }
            }
        }

        private void acGridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            try
            {
                if (e.RowHandle < 0) return;

                string app1 = acGridView1.GetRowCellValue(e.RowHandle, "APP_EMP_FLAG1").ToString();
                string app2 = acGridView1.GetRowCellValue(e.RowHandle, "APP_EMP_FLAG2").ToString();
                string app3 = acGridView1.GetRowCellValue(e.RowHandle, "APP_EMP_FLAG3").ToString();
                string app4 = acGridView1.GetRowCellValue(e.RowHandle, "APP_EMP_FLAG4").ToString();

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

        private void acGridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                GetDetail();
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
            paramTable.Columns.Add("EMP_CODE", typeof(String));

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["PLAN_YEAR"] = layoutRow["PLAN_YEAR"];
            paramRow["EMP_CODE"] = layoutRow["EMP_CODE"];

            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();

            paramSet.Tables.Add(paramTable);

            BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD, "WOR04A_SER", paramSet, "RQSTDT", "RSLTDT",
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

        void GetDetail()
        {
            DataRow focusRow = acGridView1.GetFocusedDataRow();

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

        private void acBarButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                //새로만들기
                WOR04A_D0A frm = new WOR04A_D0A(acGridView1, null);
                frm.ParentControl = this;
                frm.DialogMode = BaseMenuDialog.emDialogMode.NEW;
                frm.Show();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void acBarButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                //열기
                DataRow focusRow = acGridView1.GetFocusedDataRow();

                WOR04A_D0A frm = new WOR04A_D0A(acGridView1, focusRow);
                frm.ParentControl = this;
                frm.DialogMode = BaseMenuDialog.emDialogMode.OPEN;
                frm.Show();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void acBarButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                //삭제
                acGridView1.EndEditor();

                if (acMessageBox.Show(this, "정말 삭제하시겠습니까?", "TB43FSY3", true, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No) return;

                //DataView selected = acGridView1.GetDataSourceView("SEL = '1'");

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("PLAN_NO", typeof(String)); //

                DataRow focusRow = acGridView1.GetFocusedDataRow();

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["PLAN_NO"] = focusRow["PLAN_NO"];

                paramTable.Rows.Add(paramRow);

                //if (selected.Count == 0)
                //{
                //    //단일삭제
                //    DataRow focusRow = acGridView1.GetFocusedDataRow();

                //    DataRow paramRow = paramTable.NewRow();
                //    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                //    paramRow["WORK_ID"] = focusRow["WORK_ID"];

                //    paramTable.Rows.Add(paramRow);
                //}
                //else
                //{
                //    //다중삭제
                //    for (int i = 0; i < selected.Count; i++)
                //    {

                //        DataRow paramRow = paramTable.NewRow();
                //        paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                //        paramRow["WORK_ID"] = selected[i]["WORK_ID"];

                //        paramTable.Rows.Add(paramRow);
                //    }

                //}

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.DEL,
                "WOR04A_DEL", paramSet, "RQSTDT", "",
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
                    acGridView1.DeleteMappingRow(row);
                }
                acGridView1.RaiseFocusedRowChanged();

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
                //통지서 출력

                DataRow focusRow = acGridView1.GetFocusedDataRow();

                if (focusRow == null) return;

                DataTable calendarTable = (DataTable)acGridView2.GridControl.DataSource;

                string plan_deadline_date = acInfo.SysConfig.GetSysConfigByMemory("PLAN_DEADLINE_DATE");
                //string plan_s_mark_month = acInfo.SysConfig.GetSysConfigByMemory("PLAN_S_MARK_MONTH");
                //string plan_e_mark_month = acInfo.SysConfig.GetSysConfigByMemory("PLAN_E_MARK_MONTH");

                plan_deadline_date = plan_deadline_date.toDateString("yyyy-MM-dd");
                //plan_s_mark_month = new DateTime(focusRow["PLAN_YEAR"].toInt(), plan_s_mark_month.toInt(), 1).toDateString("yyyy-MM");
                //plan_e_mark_month = new DateTime(focusRow["PLAN_YEAR"].toInt(), plan_e_mark_month.toInt(), 1).toDateString("yyyy-MM");

                string msg = string.Format("통지서 출력을 하시겠습니까?\n제출기한 : {0} 까지", plan_deadline_date);

                if (acMessageBox.Show(this, msg, "", false, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
                {
                    return;
                }

                //WOR05A_D0A frm = new WOR05A_D0A(focusRow, calendarTable, _holiTable, _stdHoliTable);
                //frm.ParentControl = this;
                //frm.ShowDialog();

                plan_deadline_date = acInfo.SysConfig.GetSysConfigByMemory("PLAN_DEADLINE_DATE");
                //plan_s_mark_month = acInfo.SysConfig.GetSysConfigByMemory("PLAN_S_MARK_MONTH");
                //plan_e_mark_month = acInfo.SysConfig.GetSysConfigByMemory("PLAN_E_MARK_MONTH");


                int iMonth = 1;
                if (focusRow["PLAN_SEQ"].ToString() == "2")
                {
                    iMonth = 7;
                }
                DateTime startDate = new DateTime(focusRow["PLAN_YEAR"].toInt(), iMonth, 1, 0, 0, 0);
                DateTime endDate = startDate.AddMonths(5);

                string plan_s_mark_month = startDate.toDateString("MM");
                string plan_e_mark_month = endDate.toDateString("MM");

                byte[] holi_plan = Resource.holi_plan;
                SpreadsheetControl spread = new SpreadsheetControl();
                spread.LoadDocument(holi_plan, DocumentFormat.Xlsx);

                //Stream stream = new MemoryStream(Resource.holi_plan);
                //spread.LoadDocument(stream, DocumentFormat.Xlsx);

                IWorkbook workbook = spread.Document;

                Worksheet ws = workbook.Worksheets[0];

                ws["B2"].SetValue("연차유급휴가 사용촉진 통지서(계획서)-" + focusRow["PLAN_SEQ"].ToString() + "차");

                RichTextRunFont rtfUnder = new RichTextRunFont();
                rtfUnder.UnderlineType = UnderlineType.Single;
                rtfUnder.Bold = true;
                rtfUnder.Name = "굴림";
                rtfUnder.Size = 10;

                RichTextRunFont rtfNomal = new RichTextRunFont();
                rtfNomal.Name = "굴림";
                rtfNomal.Size = 10;

                RichTextString rt = new RichTextString();
                rt.AddTextRun("근로기준법 제61조(연차유급휴가의 사용촉진)에 의거하여 당사는 연차유급휴가 사용촉진제도를 시행합니다.", rtfNomal);
                rt.AddTextRun("\n\n당해에 사용하지 않은 미사용 연차에 대해서는 다음해로 이월되거나 수당으로 지급되지 않고 자동 소멸됩니다.", rtfNomal);
                rt.AddTextRun("\n\n하여 아래와 같이 잔여일수를 확인하고 연차휴가 사용계획서를 작성하여 10일이내에(", rtfNomal);
                if (plan_deadline_date.Length == 8)
                {
                    rt.AddTextRun(plan_deadline_date.Substring(0, 4) + "년 " + plan_deadline_date.Substring(4, 2) + "월 " + plan_deadline_date.Substring(6, 2) + "일까지", rtfUnder);
                }
                rt.AddTextRun(") 서면으로 제출해 주시기 바랍니다.", rtfNomal);

                ws["B10"].SetRichText(rt);

                DataRow myVenderRow = acVendor.GetMyVendor();

                if (myVenderRow != null)
                {
                    ws["F15"].SetValue(myVenderRow["VEN_NAME"].toStringEmpty());
                    ws["Q15"].SetValue(myVenderRow["VEN_TEL"].toStringEmpty());
                    ws["F16"].SetValue(myVenderRow["VEN_ADDRESS"].toStringEmpty());
                }

                DataTable empTable = new DataTable("RQSTDT");
                empTable.Columns.Add("PLT_CODE", typeof(string));
                empTable.Columns.Add("EMP_CODE", typeof(string));

                DataRow newEmpRow = empTable.NewRow();
                newEmpRow["PLT_CODE"] = acInfo.PLT_CODE;
                newEmpRow["EMP_CODE"] = focusRow["EMP_CODE"];
                empTable.Rows.Add(newEmpRow);

                DataSet empSet = new DataSet();
                empSet.Tables.Add(empTable);

                DataSet empResultSet = BizRun.QBizRun.ExecuteService(this, "CTRL", "GET_EMPLOYEE", empSet, "RQSTDT", "RSLTDT");

                if (empResultSet.Tables["RSLTDT"].Rows.Count > 0)
                {
                    ws["F18"].SetValue(empResultSet.Tables["RSLTDT"].Rows[0]["EMP_NAME"].toStringEmpty());
                    ws["Q18"].SetValue(empResultSet.Tables["RSLTDT"].Rows[0]["EMP_REG_NUMBER"].toStringEmpty());
                    ws["F19"].SetValue(empResultSet.Tables["RSLTDT"].Rows[0]["EMP_ADDRESS"].toStringEmpty());

                    ws["F21"].SetValue(empResultSet.Tables["RSLTDT"].Rows[0]["HIRE_DATE"].toDateString("yyyy-MM-dd"));
                    ws["Q21"].SetValue(acStdCodes.GetNameByCodeServer("C040", empResultSet.Tables["RSLTDT"].Rows[0]["EMP_TITLE"].toStringEmpty()));
                }

                ws["F22"].SetValue(focusRow["PLAN_YEAR"].ToString() + "년 발생 연차");
                ws["L22"].SetValue("사용 연차");
                ws["R22"].SetValue("잔여 연차");

                ws["F23"].SetValue(focusRow["YEAR_HOLI"].toDecimal());
                ws["L23"].SetValue(focusRow["USE_HOLI"].toDecimal());


                //int idx = 0;
                int iDatePeriod = 28;

                string sYear = focusRow["PLAN_YEAR"].ToString();

                foreach (DataRow row in calendarTable.Rows)
                {
                    //if (idx == 10) break;

                    //foreach (DataColumn col in _calendarTable.Columns)
                    //{
                    //    ws["B" + iDatePeriod.ToString()].SetValue("");
                    //}

                    string month = row["PLAN_MONTH"].ToString();

                    if ((sYear + plan_s_mark_month).toInt() > month.toInt())
                    {
                        continue;
                    }
                    if ((sYear + plan_e_mark_month).toInt() < month.toInt())
                    {
                        continue;
                    }

                    ws["B" + iDatePeriod.ToString()].SetValue(row["DATE_PERIOD"].toStringEmpty());
                    SpreadsheetFont sf = ws["B" + iDatePeriod.ToString()].Font;
                    sf.Name = "굴림";
                    sf.Size = 9;

                    ws["E" + iDatePeriod.ToString()].SetValue(row["1"].toStringEmpty());
                    SetCell(ws, "E", row, "1", month, iDatePeriod);

                    ws["F" + iDatePeriod.ToString()].SetValue(row["2"].toStringEmpty());
                    SetCell(ws, "F", row, "2", month, iDatePeriod);

                    ws["G" + iDatePeriod.ToString()].SetValue(row["3"].toStringEmpty());
                    SetCell(ws, "G", row, "3", month, iDatePeriod);

                    ws["H" + iDatePeriod.ToString()].SetValue(row["4"].toStringEmpty());
                    SetCell(ws, "H", row, "4", month, iDatePeriod);

                    ws["I" + iDatePeriod.ToString()].SetValue(row["5"].toStringEmpty());
                    SetCell(ws, "I", row, "5", month, iDatePeriod);

                    ws["J" + iDatePeriod.ToString()].SetValue(row["6"].toStringEmpty());
                    SetCell(ws, "J", row, "6", month, iDatePeriod);

                    ws["K" + iDatePeriod.ToString()].SetValue(row["7"].toStringEmpty());
                    SetCell(ws, "K", row, "7", month, iDatePeriod);

                    ws["L" + iDatePeriod.ToString()].SetValue(row["8"].toStringEmpty());
                    SetCell(ws, "L", row, "8", month, iDatePeriod);

                    ws["M" + iDatePeriod.ToString()].SetValue(row["9"].toStringEmpty());
                    SetCell(ws, "M", row, "9", month, iDatePeriod);

                    ws["N" + iDatePeriod.ToString()].SetValue(row["10"].toStringEmpty());
                    SetCell(ws, "N", row, "10", month, iDatePeriod);

                    ws["O" + iDatePeriod.ToString()].SetValue(row["11"].toStringEmpty());
                    SetCell(ws, "O", row, "11", month, iDatePeriod);

                    ws["P" + iDatePeriod.ToString()].SetValue(row["12"].toStringEmpty());
                    SetCell(ws, "P", row, "12", month, iDatePeriod);

                    ws["Q" + iDatePeriod.ToString()].SetValue(row["13"].toStringEmpty());
                    SetCell(ws, "Q", row, "13", month, iDatePeriod);

                    ws["R" + iDatePeriod.ToString()].SetValue(row["14"].toStringEmpty());
                    SetCell(ws, "R", row, "14", month, iDatePeriod);

                    ws["S" + iDatePeriod.ToString()].SetValue(row["15"].toStringEmpty());
                    SetCell(ws, "S", row, "15", month, iDatePeriod);

                    ws["T" + iDatePeriod.ToString()].SetValue(row["16"].toStringEmpty());
                    SetCell(ws, "T", row, "16", month, iDatePeriod);

                    iDatePeriod++;
                    //idx++;
                }

                DateTime nowDateTime = acDateEdit.GetNowDateFromServer();

                string nowYear = nowDateTime.Year.ToString();
                string nowMonth = nowDateTime.Month.ToString().PadLeft(2, '0');
                string nowDay = nowDateTime.Day.ToString().PadLeft(2, '0');

                ws["B44"].SetValue(nowYear + "  년         " + nowMonth + "  월       " + nowDay + " 일 ");


                DataRow[] planHoliRows = _holiTable.Select("PLAN_DATE >= '" + sYear + plan_s_mark_month + "01' AND PLAN_DATE <= '" + sYear + plan_e_mark_month + "31'");

                decimal planHoliCnt = 0;
                if (planHoliRows.Length > 0)
                {
                    planHoliCnt = planHoliRows.CopyToDataTable().Compute("sum(PLAN_HOLI)", "").toDecimal();
                }

                decimal point = planHoliCnt - Math.Truncate(planHoliCnt);

                string holiCnt = planHoliCnt.ToString();
                if (point == 0)
                {
                    holiCnt = Math.Truncate(planHoliCnt).ToString();
                }



                ws["B45"].SetValue("기재한 연차 사용계획 일수 :                     " + holiCnt.ToString() + "  일 ");
                ws["B46"].SetValue(" 제출자 :            " + focusRow["EMP_NAME"].ToString() + "               (서명 또는 인)");
                SpreadsheetFont Bsf = ws["B46"].Font;
                Bsf.Color = Color.Black;

                spread.ShowPrintPreview();

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void SetCell(Worksheet ws, string CellName, DataRow row, string rowSeq, string month, int iDatePeriod)
        {
            string day = row[rowSeq].toStringEmpty().PadLeft(2, '0');
            SpreadsheetFont sf = ws[CellName + iDatePeriod.ToString()].Font;
            sf.Color = Color.Black;

            if (day != "00")
            {
                DataRow[] eRows = _stdHoliTable.Select("HOLI_DATE = '" + month + day + "'");
                DateTime eStdHolidt = new DateTime(month.Substring(0, 4).toInt(), month.Substring(4, 2).toInt(), day.toInt(), 0, 0, 0);
                if (eRows.Length > 0
                    || eStdHolidt.DayOfWeek == DayOfWeek.Saturday
                    || eStdHolidt.DayOfWeek == DayOfWeek.Sunday)
                {
                    sf.Color = Color.Red;
                }

                eRows = _holiTable.Select("PLAN_DATE = '" + month + day + "'");

                if (eRows.Length > 0)
                {
                    ws[CellName + iDatePeriod.ToString()].Fill.BackgroundColor = Color.Yellow;

                    Formatting formatting = ws[CellName + iDatePeriod.ToString()].BeginUpdateFormatting();
                    Borders borders = formatting.Borders;
                    ws[CellName + iDatePeriod.ToString()].Borders.SetAllBorders(Color.Black, BorderLineStyle.Medium);

                    if (eRows[0]["PLAN_HOLI"].toDouble() == 0.5)
                    {
                        borders.DiagonalBorderType = DiagonalBorderType.Up;
                        borders.DiagonalBorderLineStyle = BorderLineStyle.Medium;
                    }
                }
                else
                {
                    ws[CellName + iDatePeriod.ToString()].Fill.BackgroundColor = Color.Transparent;
                }
            }
        }

        private void acBarButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            WOR05A_D1A frm = new WOR05A_D1A();
            frm.ParentControl = this;
            frm.ShowDialog();
        }
    }
}

