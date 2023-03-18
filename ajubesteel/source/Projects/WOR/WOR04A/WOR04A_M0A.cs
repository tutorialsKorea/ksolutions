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

namespace WOR
{
    public sealed partial class WOR04A_M0A : BaseMenu
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

        public WOR04A_M0A()
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
            acGridView1.AddTextEdit("PLAN_YEAR", "년도", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("PLAN_SEQ", "차수", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddLookUpEdit("PLAN_STATUS", "상태", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "W008");
            acGridView1.AddDateEdit("REG_DATE", "신청일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.MEDIUM_DATE);

            acGridView1.AddTextEdit("YEAR_HOLI", "발생연차", "", false, DevExpress.Utils.HorzAlignment.Far, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("USE_HOLI", "사용연차", "", false, DevExpress.Utils.HorzAlignment.Far, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("POS_HOLI", "가능연차", "", false, DevExpress.Utils.HorzAlignment.Far, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("REQ_HOLI", "신청연차", "", false, DevExpress.Utils.HorzAlignment.Far, false, false, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddLookUpEmp("APP_EMP1", "승인자1", string.Empty, false, DevExpress.Utils.HorzAlignment.Center, false, true, false);
            acGridView1.AddTextEdit("APP_EMP_FLAG1", "승인자1상태", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddLookUpEmp("APP_EMP2", "승인자2", string.Empty, false, DevExpress.Utils.HorzAlignment.Center, false, true, false);
            acGridView1.AddTextEdit("APP_EMP_FLAG2", "승인자2상태", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddLookUpEmp("APP_EMP3", "승인자3", string.Empty, false, DevExpress.Utils.HorzAlignment.Center, false, true, false);
            acGridView1.AddTextEdit("APP_EMP_FLAG3", "승인자3상태", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddLookUpEmp("APP_EMP4", "승인자4", string.Empty, false, DevExpress.Utils.HorzAlignment.Center, false, true, false);
            acGridView1.AddTextEdit("APP_EMP_FLAG4", "승인자4상태", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);

            acGridView1.KeyColumn = new string[] { "PLAN_NO" };

            acGridView1.ShowGridMenuEx += acGridView1_ShowGridMenuEx;

            acGridView1.MouseDown += acGridView1_MouseDown;

            acGridView1.CustomDrawCell += acGridView1_CustomDrawCell;

            acGridView1.FocusedRowChanged += acGridView1_FocusedRowChanged;

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

            base.MenuInit();
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

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["PLAN_YEAR"] = layoutRow["PLAN_YEAR"];

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
    }
}

