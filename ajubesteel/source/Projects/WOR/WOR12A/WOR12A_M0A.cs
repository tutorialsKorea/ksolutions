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
    public sealed partial class WOR12A_M0A : BaseMenu
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

        public WOR12A_M0A()
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

        private DataTable _workTable = null;

        private DataTable _stdHoliTable = null;

        private string _workYear = "";
        public override void MenuInit()
        {
            acLayoutControl1.OnValueChanged += new acLayoutControl.ValueChangedEventHandler(acLayoutControl1_OnValueChanged);
            acLayoutControl1.OnValueKeyDown += new acLayoutControl.ValueKeyDownEventHandler(acLayoutControl1_OnValueKeyDown);

            acGridView1.GridType = acGridView.emGridType.SEARCH;
            acGridView1.OptionsView.ShowIndicator = true;
            acGridView1.AddTextEdit("EWT_NO", "근태유형 번호", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("EMP_CODE", "사원코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("EMP_NAME", "사원명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("ORG_CODE", "부서코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("ORG_NAME", "부서명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("WORK_YEAR", "년도", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddCheckEdit("IS_REG", "등록여부", "", false, false, true, acGridView.emCheckEditDataType._STRING);

            acGridView1.KeyColumn = new string[] { "EMP_CODE" }; 

            acGridView1.ShowGridMenuEx += acGridView1_ShowGridMenuEx;

            acGridView1.MouseDown += acGridView1_MouseDown;

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

            (acLayoutControl1.GetEditor("WORK_YEAR") as acDateEdit).Properties.EditMask = "yyyy";

            simpleLabelItem2.AppearanceItemCaption.BackColor = Color.Yellow;

            base.MenuInit();
        }

        void acGridView1_ShowGridMenuEx(object sender, PopupMenuShowingEventArgs e)
        {
            acGridView view = sender as acGridView;

            if (e.HitInfo.HitTest == GridHitTest.EmptyRow || e.HitInfo.HitTest == GridHitTest.Row || e.HitInfo.HitTest == GridHitTest.RowCell)
            {

                if (e.MenuType == GridMenuType.User)
                {
                    acBarSubItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    acBarButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    acBarButtonItem3.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                }
                else if (e.MenuType == GridMenuType.Row)
                {
                    if (e.HitInfo.RowHandle >= 0)
                    {
                        acBarSubItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        acBarButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        acBarButtonItem3.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    }
                    else
                    {
                        acBarSubItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
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

        private void acGridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                acGridView1.EndEditor();

                DataRow row  = acGridView1.GetFocusedDataRow();

                if(!row.isNullOrEmpty())
                {
                    acGroupControl2.Text = "근태유형 상세(" + row["EMP_NAME"] + ")";
                }

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
            if (_workTable == null) return;
            if (_workTable.Rows.Count == 0) return;

            string month = acGridView2.GetRowCellValue(e.RowHandle, "WORK_MONTH").ToString();

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

                rows = _workTable.Select("EWT_DATE = '" + month + day + "' AND EWT_TYPE = '1'");

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

                layout.GetEditor("WORK_YEAR").Value = acDateEdit.GetNowFirstYear();
                _workYear = acDateEdit.GetNowFirstYear().toDateString("yyyy");
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
            paramTable.Columns.Add("WORK_YEAR", typeof(String));
            paramTable.Columns.Add("EMP_CODE", typeof(String));
            paramTable.Columns.Add("ORG_CODE", typeof(String));
            paramTable.Columns.Add("IS_RETIRE", typeof(String)); //

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["WORK_YEAR"] = layoutRow["WORK_YEAR"];
            paramRow["EMP_CODE"] = layoutRow["EMP_CODE"];
            paramRow["ORG_CODE"] = layoutRow["ORG_CODE"];
            paramRow["IS_RETIRE"] = layoutRow["IS_RETIRE"];

            if (acCheckEdit1.Checked)
            {
                paramRow["IS_RETIRE"] = null;
            }

            _workYear = layoutRow["WORK_YEAR"].ToString();

            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();

            paramSet.Tables.Add(paramTable);

            BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD, "WOR12A_SER", paramSet, "RQSTDT", "RSLTDT",
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

            if (focusRow["WORK_YEAR"].ToString() == "") return;

            int iMonth = 1;

            DateTime planDT = new DateTime(focusRow["WORK_YEAR"].toInt(), iMonth, 1);

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(string));
            paramTable.Columns.Add("WORK_MON", typeof(string));
            paramTable.Columns.Add("WORK_MONTH", typeof(string));
            paramTable.Columns.Add("EWT_NO", typeof(string));

            for (int i = 0; i < 12; i++)
            {
                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["WORK_MON"] = planDT.toDateString("yyyyMM");
                paramRow["WORK_MONTH"] = planDT.toDateString("yyyy-MM");
                paramRow["EWT_NO"] = focusRow["EWT_NO"];

                paramTable.Rows.Add(paramRow);
                planDT = planDT.AddMonths(1);
            }


            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD_DETAIL, "WOR12A_SER2", paramSet, "RQSTDT", "RSLTDT",
            QuickDetailSearch,
            QuickException);
        }

        void QuickDetailSearch(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                _stdHoliTable = e.result.Tables["RSLTDT_HOLI"];
                _workTable = e.result.Tables["RSLTDT_WORK"];

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
                if (_workYear == "") return;

                WOR12A_D0A frm = new WOR12A_D0A(acGridView1, null, _workYear);
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
                if (_workYear == "") return;

                DataRow focusRow = acGridView1.GetFocusedDataRow();

                WOR12A_D0A frm = new WOR12A_D0A(acGridView1, focusRow, _workYear);
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
                paramTable.Columns.Add("EWT_NO", typeof(String)); //
                paramTable.Columns.Add("EMP_CODE", typeof(String)); //
                paramTable.Columns.Add("WORK_YEAR", typeof(String)); //

                DataRow focusRow = acGridView1.GetFocusedDataRow();

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["EWT_NO"] = focusRow["EWT_NO"];
                paramRow["EMP_CODE"] = focusRow["EMP_CODE"];
                paramRow["WORK_YEAR"] = focusRow["WORK_YEAR"];

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
                "WOR12A_DEL", paramSet, "RQSTDT", "RSLTDT",
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
                foreach (DataRow row in e.result.Tables["RSLTDT"].Rows)
                {
                    acGridView1.UpdateMapingRow(row, false);
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

