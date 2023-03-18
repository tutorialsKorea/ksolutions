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
    public sealed partial class WOR03A_M0A : BaseMenu
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

        private string _year = "";

        public WOR03A_M0A()
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

        public override void MenuInit()
        {
            acLayoutControl1.OnValueChanged += new acLayoutControl.ValueChangedEventHandler(acLayoutControl1_OnValueChanged);
            acLayoutControl1.OnValueKeyDown += new acLayoutControl.ValueKeyDownEventHandler(acLayoutControl1_OnValueKeyDown);

            acBandGridView1.OptionsView.ShowIndicator = true;

            acBandGridView1.AddTextEdit("EMP_CODE", "사원코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acBandGridView.emTextEditMask.NONE);
            acBandGridView1.AddTextEdit("EMP_NAME", "사원명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acBandGridView.emTextEditMask.NONE);
            acBandGridView1.AddDateEdit("HIRE_DATE", "입사일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acBandGridView.emDateMask.SHORT_DATE);
            acBandGridView1.AddTextEdit("ORG_CODE", "부서코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acBandGridView.emTextEditMask.NONE);
            acBandGridView1.AddTextEdit("ORG_NAME", "부서명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acBandGridView.emTextEditMask.NONE);
            acBandGridView1.AddTextEdit("CNT_HOLI", "발생연차", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.F1);
            acBandGridView1.AddTextEdit("USE_HOLI", "사용연차", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.F1);
            acBandGridView1.AddTextEdit("PLAN_HOLI", "계획연차", "", false, DevExpress.Utils.HorzAlignment.Far, false, false, false, acBandGridView.emTextEditMask.F1);
            acBandGridView1.AddTextEdit("REMAIN_HOLI", "잔여연차", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.F1);

            acBandGridView1.AddTextEdit("HOLI_1", "1월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.F1, "연차사용내역(일)");
            acBandGridView1.AddTextEdit("HOLI_2", "2월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.F1, "연차사용내역(일)");
            acBandGridView1.AddTextEdit("HOLI_3", "3월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.F1, "연차사용내역(일)");
            acBandGridView1.AddTextEdit("HOLI_4", "4월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.F1, "연차사용내역(일)");
            acBandGridView1.AddTextEdit("HOLI_5", "5월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.F1, "연차사용내역(일)");
            acBandGridView1.AddTextEdit("HOLI_6", "6월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.F1, "연차사용내역(일)");
            acBandGridView1.AddTextEdit("HOLI_7", "7월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.F1, "연차사용내역(일)");
            acBandGridView1.AddTextEdit("HOLI_8", "8월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.F1, "연차사용내역(일)");
            acBandGridView1.AddTextEdit("HOLI_9", "9월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.F1, "연차사용내역(일)");
            acBandGridView1.AddTextEdit("HOLI_10", "10월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.F1, "연차사용내역(일)");
            acBandGridView1.AddTextEdit("HOLI_11", "11월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.F1, "연차사용내역(일)");
            acBandGridView1.AddTextEdit("HOLI_12", "12월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.F1, "연차사용내역(일)");

            acBandGridView1.AddTextEdit("WORK_1", "1월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.F1, "연장근로내역(시간)");
            acBandGridView1.AddTextEdit("WORK_2", "2월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.F1, "연장근로내역(시간)");
            acBandGridView1.AddTextEdit("WORK_3", "3월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.F1, "연장근로내역(시간)");
            acBandGridView1.AddTextEdit("WORK_4", "4월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.F1, "연장근로내역(시간)");
            acBandGridView1.AddTextEdit("WORK_5", "5월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.F1, "연장근로내역(시간)");
            acBandGridView1.AddTextEdit("WORK_6", "6월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.F1, "연장근로내역(시간)");
            acBandGridView1.AddTextEdit("WORK_7", "7월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.F1, "연장근로내역(시간)");
            acBandGridView1.AddTextEdit("WORK_8", "8월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.F1, "연장근로내역(시간)");
            acBandGridView1.AddTextEdit("WORK_9", "9월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.F1, "연장근로내역(시간)");
            acBandGridView1.AddTextEdit("WORK_10", "10월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.F1, "연장근로내역(시간)");
            acBandGridView1.AddTextEdit("WORK_11", "11월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.F1, "연장근로내역(시간)");
            acBandGridView1.AddTextEdit("WORK_12", "12월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.F1, "연장근로내역(시간)");

            acBandGridView1.AddTextEdit("QUARTER_1", "1/4분기", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.F1, "분기별 잔여시간");
            acBandGridView1.AddTextEdit("QUARTER_2", "2/4분기", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.F1, "분기별 잔여시간");
            acBandGridView1.AddTextEdit("QUARTER_3", "3/4분기", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.F1, "분기별 잔여시간");
            acBandGridView1.AddTextEdit("QUARTER_4", "4/4분기", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.F1, "분기별 잔여시간");

            (acLayoutControl1.GetEditor("YEAR") as acDateEdit).Properties.EditMask = "yyyy";

            acBandGridView1.CustomDrawCell += acBandGridView1_CustomDrawCell;
            acBandGridView1.ShowGridMenuEx += acBandGridView1_ShowGridMenuEx;
            acBandGridView1.MouseDown += acBandGridView1_MouseDown;

            base.MenuInit();
        }

        private void acBandGridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.RowHandle < 0) return;

            if (e.Column.FieldName.StartsWith("HOLI_"))
            {
                e.Appearance.BackColor = Color.Cornsilk;
                e.Appearance.ForeColor = Color.Black;
            }
            else if (e.Column.FieldName.StartsWith("WORK_"))
            {
                e.Appearance.BackColor = Color.Linen;
                e.Appearance.ForeColor = Color.Black;
            }
            else if (e.Column.FieldName.StartsWith("QUARTER_"))
            {
                e.Appearance.BackColor = Color.FloralWhite;
                e.Appearance.ForeColor = Color.Black;
            }
        }

        void acBandGridView1_ShowGridMenuEx(object sender, PopupMenuShowingEventArgs e)
        {
            acBandGridView view = sender as acBandGridView;

            if (e.HitInfo.HitTest == GridHitTest.EmptyRow || e.HitInfo.HitTest == GridHitTest.Row || e.HitInfo.HitTest == GridHitTest.RowCell)
            {

                if (e.MenuType == GridMenuType.User)
                {
                    acBarButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    acBarButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    acBarButtonItem3.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                }
                else if (e.MenuType == GridMenuType.Row)
                {
                    if (e.HitInfo.RowHandle >= 0)
                    {
                        acBarButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        acBarButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        acBarButtonItem3.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    }
                    else
                    {
                        acBarButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        acBarButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        acBarButtonItem3.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    }
                }

                GridHitInfo hitInfo = view.CalcHitInfo(e.Point);

                popupMenu1.ShowPopup(view.GridControl.PointToScreen(e.Point));

            }
        }

        public override void ChildContainerInit(Control sender)
        {
            if (sender == acLayoutControl1)
            {
                acLayoutControl layout = sender as acLayoutControl;

                layout.GetEditor("YEAR").Value = acDateEdit.GetNowFirstYear();
                _year = acDateEdit.GetNowFirstYear().Year.ToString();
            }

            base.ChildContainerInit(sender);
        }

        void acLayoutControl1_OnValueChanged(object sender, IBaseEditControl info, object newValue)
        {
            acLayoutControl layout = sender as acLayoutControl;

            switch (info.ColumnName)
            {
                case "EMP_CODE":

                    Search();

                    break;
            }

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
            paramTable.Columns.Add("EMP_CODE", typeof(String));
            paramTable.Columns.Add("ORG_CODE", typeof(String));
            paramTable.Columns.Add("REQ_YEAR", typeof(String));
            paramTable.Columns.Add("IS_RETIRE", typeof(String)); 

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["EMP_CODE"] = layoutRow["EMP_CODE"];
            paramRow["ORG_CODE"] = layoutRow["ORG_CODE"];
            paramRow["REQ_YEAR"] = layoutRow["YEAR"];
            paramRow["IS_RETIRE"] = layoutRow["IS_RETIRE"];

            if (acCheckEdit1.Checked)
            {
                paramRow["IS_RETIRE"] = null;
            }

            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();

            paramSet.Tables.Add(paramTable);

            BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD, "WOR03A_SER", paramSet, "RQSTDT", "RSLTDT",
            QuickSearch,
            QuickException);
        }

        void QuickSearch(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                _year = e.result.Tables["RQSTDT"].Rows[0]["REQ_YEAR"].ToString();
                acBandGridView1.GridControl.DataSource = e.result.Tables["RSLTDT"];
                acBandGridView1.BestFitColumns();

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

        private void acBarButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //열기
            try
            {
                DataRow focusRow =  acBandGridView1.GetFocusedDataRow();

                string formKey = string.Format("{0}", focusRow["EMP_CODE"]);

                if (!base.ChildFormContains(formKey))
                {
                    WOR03A_D0A frm = new WOR03A_D0A(focusRow, _year);
                    frm.DialogMode = BaseMenuDialog.emDialogMode.OPEN;

                    frm.ParentControl = this;

                    frm.Text = "근태상세 - " + focusRow["EMP_NAME"].ToString();

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

        private void acBandGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                GridHitInfo hitInfo = acBandGridView1.CalcHitInfo(e.Location);

                if (hitInfo.HitTest == GridHitTest.RowCell || hitInfo.HitTest == GridHitTest.Row)
                {
                    acBarButtonItem2_ItemClick(null, null);
                }
            }
        }
    }
}

