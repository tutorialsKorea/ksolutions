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
    public sealed partial class WOR07A_M0A : BaseMenu
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

        public WOR07A_M0A()
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
            acGridView1.GridType = acGridView.emGridType.SEARCH;

            acGridView1.AddTextEdit("EMP_CODE", "사원코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("EMP_NAME", "사원명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("ORG_CODE", "부서코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("ORG_NAME", "부서명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddDateEdit("HIRE_DATE", "입사일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
            acGridView1.AddDateEdit("RETIRE_DATE", "퇴사일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);

            acGridView2.KeyColumn = new string[] { "EMP_CODE" };


            acGridView2.GridType = acGridView.emGridType.SEARCH;

            acGridView2.AddTextEdit("EMP_CODE", "사원코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("EMP_NAME", "사원명", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("EH_SEQ", "순번", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);

            acGridView2.AddTextEdit("WORK_YEAR", "근무년차", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("HOLI_OCCUR_DATE", "휴가발생일자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("HOLI_OCCUR_CNT", "휴가발생일수(계산)", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("HOLI_OCCUR_INPUT_CNT", "휴가발생일수(직접입력)", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddCheckEdit("IS_USE", "적용연차", "", false, false, true, acGridView.emCheckEditDataType._STRING);

            acGridView2.KeyColumn = new string[] { "EMP_CODE", "EH_SEQ" };

            acLayoutControl1.OnValueChanged += new acLayoutControl.ValueChangedEventHandler(acLayoutControl1_OnValueChanged);
            acLayoutControl1.OnValueKeyDown += new acLayoutControl.ValueKeyDownEventHandler(acLayoutControl1_OnValueKeyDown);

            acGridView1.FocusedRowChanged += acGridView1_FocusedRowChanged;

            acGridView2.ShowGridMenuEx += acGridView2_ShowGridMenuEx;

            acGridView2.MouseDown += acGridView2_MouseDown;

            acGridView2.CustomDrawCell += acGridView2_CustomDrawCell;

            acLayoutControl1.GetEditor("ACCOUNT_DATE").Value = acInfo.SysConfig.GetSysConfigByMemory("ACCOUNT_DATE").toDateString("MM-dd");

            //(acLayoutControl1.GetEditor("ACCOUNT_DATE") as acDateEdit).Properties.UseMaskAsDisplayFormat = true;
            //(acLayoutControl1.GetEditor("ACCOUNT_DATE") as acDateEdit).Properties.EditMask = "MM-dd";

            base.MenuInit();
        }

        private void acGridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            GetDetail();
        }

        private void acGridView2_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            try
            {
                if (e.RowHandle < 0) return;

            }
            catch { }
        }

        public override void ChildContainerInit(Control sender)
        {
            if (sender == acLayoutControl1)
            {
                acLayoutControl layout = sender as acLayoutControl;

            }

            base.ChildContainerInit(sender);
        }

        void acLayoutControl1_OnValueChanged(object sender, IBaseEditControl info, object newValue)
        {
            acLayoutControl layout = sender as acLayoutControl;

            switch (info.ColumnName)
            {
                case "EMP_CODE":

                    if (newValue != null)
                    {
                        Search();
                    }

                    break;
            }

        }

        private void acGridView2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                GridHitInfo hitInfo = acGridView2.CalcHitInfo(e.Location);

                if (hitInfo.HitTest == GridHitTest.RowCell || hitInfo.HitTest == GridHitTest.Row)
                {
                    acBarButtonItem2_ItemClick(null, null);
                }
            }
        }

        void acGridView2_ShowGridMenuEx(object sender, PopupMenuShowingEventArgs e)
        {
            acGridView view = sender as acGridView;

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

        void acLayoutControl1_OnValueKeyDown(object sender, IBaseEditControl info, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.Search();
            }
        }

        void Search()
        {
            try
            {
                DataRow layoutRow = acLayoutControl1.CreateParameterRow();

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("EMP_CODE", typeof(String)); //
                paramTable.Columns.Add("ORG_CODE", typeof(String)); //
                paramTable.Columns.Add("IS_RETIRE", typeof(String)); //

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["EMP_CODE"] = layoutRow["EMP_CODE"];
                paramRow["ORG_CODE"] = layoutRow["ORG_CODE"];
                paramRow["IS_RETIRE"] = layoutRow["IS_RETIRE"];

                if (acCheckEdit1.Checked)
                {
                    paramRow["IS_RETIRE"] = null;
                }

                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();

                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD, "WOR07A_SER2", paramSet, "RQSTDT", "RSLTDT",
                QuickSearch,
                QuickException);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
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

        void GetDetail()
        {
            try
            {
                //if (acLayoutControl1.ValidCheck() == false) return;

                //DataRow empRow = (acLayoutControl1.GetEditor("EMP_CODE") as acEmp).SelectedRow;
                //if (empRow != null)
                //{
                //    acLayoutControl1.GetEditor("HIRE_DATE").Value = empRow["HIRE_DATE"];
                //    acLayoutControl1.GetEditor("RETIRE_DATE").Value = empRow["RETIRE_DATE"];
                //    acLayoutControl1.GetEditor("ACCOUNT_DATE").Value = acInfo.SysConfig.GetSysConfigByMemory("ACCOUNT_DATE");
                //}

                //DataRow layoutRow = acLayoutControl1.CreateParameterRow();

                DataRow focusRow = acGridView1.GetFocusedDataRow();

                if (focusRow == null)
                {
                    acGridView2.ClearRow();
                    return;
                }

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("EMP_CODE", typeof(String)); //

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["EMP_CODE"] = focusRow["EMP_CODE"];

                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();

                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD_DETAIL, "WOR07A_SER", paramSet, "RQSTDT", "RSLTDT",
                QuickDetailSearch,
                QuickException);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void QuickDetailSearch(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                acGridView2.GridControl.DataSource = e.result.Tables["RSLTDT"];
                acGridView2.BestFitColumns();

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
                DataRow focusRow = acGridView2.GetFocusedDataRow();

                string formKey = string.Format("{0}_{1}", focusRow["EMP_CODE"], focusRow["EH_SEQ"]);

                if (!base.ChildFormContains(formKey))
                {
                    WOR07A_D0A frm = new WOR07A_D0A(acGridView2, focusRow);
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

        private void acBarButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (acLayoutControl1.ValidCheck() == false) return;

            if (acMessageBox.Show(this, "연차계산을 하시겠습니까?", "", false, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No) return;

            //DataRow layoutRow = acLayoutControl1.CreateParameterRow();
            DataRow focusRow = acGridView1.GetFocusedDataRow();

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("EMP_CODE", typeof(String)); //
            paramTable.Columns.Add("REG_DATE", typeof(DateTime)); //

            paramTable.Columns.Add("ACCOUNT_DATE", typeof(String)); //
            paramTable.Columns.Add("TARGET_DATE", typeof(String)); //
            paramTable.Columns.Add("ENFOR_DATE", typeof(String)); //

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["EMP_CODE"] = focusRow["EMP_CODE"];
            paramRow["REG_DATE"] = acDateEdit.GetNowDateFromServer();
            paramRow["ACCOUNT_DATE"] = acInfo.SysConfig.GetSysConfigByMemory("ACCOUNT_DATE");
            paramRow["TARGET_DATE"] = acInfo.SysConfig.GetSysConfigByMemory("TARGET_DATE");
            paramRow["ENFOR_DATE"] = acInfo.SysConfig.GetSysConfigByMemory("ENFOR_DATE");

            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();

            paramSet.Tables.Add(paramTable);

            BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.PROCESS, "WOR07A_INS", paramSet, "RQSTDT", "RSLTDT",
            QuickSave,
            QuickException);
        }

        void QuickSave(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                foreach (DataRow row in e.result.Tables["RSLTDT"].Rows)
                {
                    acGridView2.UpdateMapingRow(row, true);
                }

                acGridView2.BestFitColumns();

                acAlert.Show(this,"완료되었습니다.", acAlertForm.enmType.Success);
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
                //연차계산적용
                if (acMessageBox.Show(this, "계산된 휴가발생일수를 직접입력에 적용 하시겠습니까?", "", false, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No) return;

                DataView dv = acGridView2.GetDataSourceView();

                if (dv.Count == 0) return;

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("EMP_CODE", typeof(String)); //

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["EMP_CODE"] = dv[0]["EMP_CODE"];

                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();

                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.PROCESS, "WOR07A_UPD2", paramSet, "RQSTDT", "RSLTDT",
                QuickSave2,
                QuickException);

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void QuickSave2(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                foreach (DataRow row in e.result.Tables["RSLTDT"].Rows)
                {
                    acGridView2.UpdateMapingRow(row, true);
                }

                acGridView2.BestFitColumns();

                acAlert.Show(this,"적용되었습니다.", acAlertForm.enmType.Success);
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
                //전사원 연차계산
                if (acMessageBox.Show(this, "전사원 연차계산을 하시겠습니까?", "", false, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No) return;

                //DataRow layoutRow = acLayoutControl1.CreateParameterRow();

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("REG_DATE", typeof(DateTime)); //

                paramTable.Columns.Add("ACCOUNT_DATE", typeof(String)); //
                paramTable.Columns.Add("TARGET_DATE", typeof(String)); //
                paramTable.Columns.Add("ENFOR_DATE", typeof(String)); //

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["REG_DATE"] = acDateEdit.GetNowDateFromServer();
                paramRow["ACCOUNT_DATE"] = acInfo.SysConfig.GetSysConfigByMemory("ACCOUNT_DATE");
                paramRow["TARGET_DATE"] = acInfo.SysConfig.GetSysConfigByMemory("TARGET_DATE");
                paramRow["ENFOR_DATE"] = acInfo.SysConfig.GetSysConfigByMemory("ENFOR_DATE");

                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();

                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.PROCESS, "WOR07A_INS2", paramSet, "RQSTDT", "RSLTDT",
                QuickSave3,
                QuickException);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void QuickSave3(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                //acMessageBox.Show(this, "전사원 연차계산이 완료되었습니다.", "", false, acMessageBox.emMessageBoxType.CONFIRM);
                acAlert.Show(this,"완료되었습니다.", acAlertForm.enmType.Success);
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
                //연차계산적용
                if (acMessageBox.Show(this, "계산된 휴가발생일수를 직접입력에 적용 하시겠습니까?", "", false, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No) return;

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;

                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();

                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.PROCESS, "WOR07A_UPD3", paramSet, "RQSTDT", "RSLTDT",
                QuickSave4,
                QuickException);

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void QuickSave4(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                //acMessageBox.Show(this, "계산된 휴가발생일수를 직접입력에 적용이 완료되었습니다.", "", false, acMessageBox.emMessageBoxType.CONFIRM);
                acAlert.Show(this,"적용되었습니다.", acAlertForm.enmType.Success);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }
    }
}

