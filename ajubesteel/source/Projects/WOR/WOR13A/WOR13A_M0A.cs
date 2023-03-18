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
    public sealed partial class WOR13A_M0A : BaseMenu
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

        public WOR13A_M0A()
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

        public override void MenuInit()
        {
            acGridView1.GridType = acGridView.emGridType.SEARCH;

            //acGridView1.AddCheckEdit("SEL", "선택", "", false, true, true, acGridView.emCheckEditDataType._STRING);
            acGridView1.AddTextEdit("WORK_ID", "ID", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("EMP_CODE", "신청자코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("EMP_NAME", "신청자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("ORG_CODE", "부서코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("ORG_NAME", "부서", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("WORK_CODE", "근태코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("WORK_NAME", "근태명", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddDateEdit("STR_REQ_DATE", "외근일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
            acGridView1.AddLookUpEdit("OUT_TYPE", "외근 구분", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "W011");
            acGridView1.AddDateEdit("REQ_DATE", "신청일시", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.MEDIUM_DATE2);
            acGridView1.AddCheckEdit("IS_DIR_IN", "직출여부", "", false, false, true, acGridView.emCheckEditDataType._STRING);
            acGridView1.AddCheckEdit("IS_DIR_OUT", "직퇴여부", "", false, false, true, acGridView.emCheckEditDataType._STRING);
            acGridView1.AddTextEdit("OUT_VEN_CODE", "업체코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("OUT_VEN_NAME", "업체명", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddLookUpEdit("REQ_STATUS", "상태", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "W008");
            acGridView1.AddTextEdit("REQ_SCOMMENT", "신청내용", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("CC_EMP", "참조자", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("APP_SCOMMENT", "비고", "", false, DevExpress.Utils.HorzAlignment.Near, false, false, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddDateEdit("REJECT_DATE", "반려일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
            acGridView1.AddTextEdit("REJECT_REASON", "반려사유", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddLookUpEmp("APP_EMP1", "승인자1", string.Empty, false, DevExpress.Utils.HorzAlignment.Center, false, true, false);
            acGridView1.AddTextEdit("APP_EMP_FLAG1", "승인자1상태", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddLookUpEmp("APP_EMP2", "승인자2", string.Empty, false, DevExpress.Utils.HorzAlignment.Center, false, true, false);
            acGridView1.AddTextEdit("APP_EMP_FLAG2", "승인자2상태", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddLookUpEmp("APP_EMP3", "승인자3", string.Empty, false, DevExpress.Utils.HorzAlignment.Center, false, true, false);
            acGridView1.AddTextEdit("APP_EMP_FLAG3", "승인자3상태", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddLookUpEmp("APP_EMP4", "승인자4", string.Empty, false, DevExpress.Utils.HorzAlignment.Center, false, true, false);
            acGridView1.AddTextEdit("APP_EMP_FLAG4", "승인자4상태", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);

            acGridView1.KeyColumn = new string[] { "WORK_ID" };

            acLayoutControl1.OnValueChanged += new acLayoutControl.ValueChangedEventHandler(acLayoutControl1_OnValueChanged);
            acLayoutControl1.OnValueKeyDown += new acLayoutControl.ValueKeyDownEventHandler(acLayoutControl1_OnValueKeyDown);

            //acGridView1.ShowGridMenuEx += acGridView1_ShowGridMenuEx;

            //acGridView1.MouseDown += acGridView1_MouseDown;

            acGridView1.CustomDrawCell += acGridView1_CustomDrawCell;

            acCheckedComboBoxEdit1.AddItem("신청일", false, "", "REQ_DATE", true, false);
            acCheckedComboBoxEdit1.AddItem("외근일", false, "", "STR_REQ_DATE", true, false);


            base.MenuInit();
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

            switch(flag)
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

        public override void ChildContainerInit(Control sender)
        {
            if (sender == acLayoutControl1)
            {
                acLayoutControl layout = sender as acLayoutControl;

                //layout.GetEditor("EMP_CODE").Value = acInfo.UserID;

                layout.GetEditor("DATE").Value = "REQ_DATE";
                layout.GetEditor("S_DATE").Value = acDateEdit.GetNowFirstDate();
                layout.GetEditor("E_DATE").Value = acDateEdit.GetNowLastDate();
            }

            base.ChildContainerInit(sender);
        }

        void acLayoutControl1_OnValueChanged(object sender, IBaseEditControl info, object newValue)
        {
            //acLayoutControl layout = sender as acLayoutControl;

            //switch (info.ColumnName)
            //{
            //    case "EMP_CODE":

            //        if (acLayoutControl1.GetEditor("S_DATE").Value == null
            //            || acLayoutControl1.GetEditor("E_DATE").Value == null)
            //        {
            //            return;
            //        }

            //        Search();

            //        break;
            //}

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

        void acGridView1_ShowGridMenuEx(object sender, PopupMenuShowingEventArgs e)
        {
            acGridView view = sender as acGridView;

            if (e.HitInfo.HitTest == GridHitTest.EmptyRow || e.HitInfo.HitTest == GridHitTest.Row || e.HitInfo.HitTest == GridHitTest.RowCell)
            {

                if (e.MenuType == GridMenuType.User)
                {
                    acBarSubItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    acBarButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    acBarButtonItem3.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                }
                else if (e.MenuType == GridMenuType.Row)
                {
                    if (e.HitInfo.RowHandle >= 0)
                    {
                        acBarSubItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        acBarButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        acBarButtonItem3.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    }
                    else
                    {
                        acBarSubItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
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
            if (acLayoutControl1.ValidCheck() == false) return;

            DataRow layoutRow = acLayoutControl1.CreateParameterRow();

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("EMP_CODE", typeof(String)); //
            paramTable.Columns.Add("ORG_CODE", typeof(String)); //
            paramTable.Columns.Add("S_REQ_DATE", typeof(String)); //
            paramTable.Columns.Add("E_REQ_DATE", typeof(String)); //
            paramTable.Columns.Add("S_OUT_DATE", typeof(String)); //
            paramTable.Columns.Add("E_OUT_DATE", typeof(String)); //

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["EMP_CODE"] = layoutRow["EMP_CODE"];
            paramRow["ORG_CODE"] = layoutRow["ORG_CODE"];
            foreach (string key in acCheckedComboBoxEdit1.GetKeyChecked())
            {
                switch (key)
                {
                    case "REQ_DATE":
                        paramRow["S_REQ_DATE"] = layoutRow["S_DATE"];
                        paramRow["E_REQ_DATE"] = layoutRow["E_DATE"];
                        break;

                    case "STR_REQ_DATE":
                        paramRow["S_OUT_DATE"] = layoutRow["S_DATE"];
                        paramRow["E_OUT_DATE"] = layoutRow["E_DATE"];
                        break;
                }
            }

            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();

            paramSet.Tables.Add(paramTable);

            BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD, "WOR13A_SER", paramSet, "RQSTDT", "RSLTDT",
            QuickSearch,
            QuickException);
        }

        void QuickSearch(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                DataTable gridTable = e.result.Tables["RSLTDT"].Clone();

                DataRow layoutRow = acLayoutControl1.CreateParameterRow();

                bool isOutDate = false;
                foreach (string key in acCheckedComboBoxEdit1.GetKeyChecked())
                {
                    switch (key)
                    {
                        case "STR_REQ_DATE":
                            isOutDate = true;
                            break;
                    }
                }

                foreach (DataRow row in e.result.Tables["RSLTDT"].Rows)
                {
                    TimeSpan ts = row["REQ_END_DATE"].toDateTime().Subtract(row["REQ_START_DATE"].toDateTime());

                    if (isOutDate)
                    {
                        if (layoutRow["S_DATE"].toDateTime() <= row["STR_REQ_DATE"].toDateTime()
                            && layoutRow["E_DATE"].toDateTime() >= row["STR_REQ_DATE"].toDateTime())
                        {
                            DataRow newRow = gridTable.NewRow();
                            newRow.ItemArray = row.ItemArray;
                            gridTable.Rows.Add(newRow);
                        }
                    }
                    else
                    {
                        DataRow newRow = gridTable.NewRow();
                        newRow.ItemArray = row.ItemArray;
                        gridTable.Rows.Add(newRow);
                    }

                    //for (int i = 0; i < ts.TotalDays; i++)
                    for (int i = 0; i < ts.Days; i++)
                    {
                        if (isOutDate)
                        {
                            if (layoutRow["S_DATE"].toDateTime() > row["STR_REQ_DATE"].toDateTime().AddDays(i + 1)
                                || layoutRow["E_DATE"].toDateTime() < row["STR_REQ_DATE"].toDateTime().AddDays(i + 1))
                            {
                                continue;
                            }
                        }

                        DataRow newAddRow = gridTable.NewRow();
                        newAddRow.ItemArray = row.ItemArray;
                        newAddRow["STR_REQ_DATE"] = row["STR_REQ_DATE"].toDateTime().AddDays(i + 1);
                        gridTable.Rows.Add(newAddRow);
                    }
                }

                //acGridView1.GridControl.DataSource = e.result.Tables["RSLTDT"];
                acGridView1.GridControl.DataSource = gridTable;

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

        private void acBarButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //새로만들기
            try
            {
                if (!base.ChildFormContains("NEW"))
                { 

                    DataRow layoutRow = acLayoutControl1.CreateParameterRow();

                    WOR13A_D0A frm = new WOR13A_D0A(acGridView1, null, "");
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

        private void acBarButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //열기
            try
            {
                DataRow focusRow = acGridView1.GetFocusedDataRow();

                string formKey = string.Format("{0}", focusRow["WORK_ID"]);

                if (!base.ChildFormContains(formKey))
                {
                    WOR13A_D0A frm = new WOR13A_D0A(acGridView1, focusRow, focusRow["EMP_CODE"].ToString());
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

        private void acBarButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //삭제
            try
            {
                acGridView1.EndEditor();

                if (acMessageBox.Show(this, "정말 삭제하시겠습니까?", "TB43FSY3", true, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No) return;

                //DataView selected = acGridView1.GetDataSourceView("SEL = '1'");

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("WORK_ID", typeof(String)); //

                //단일삭제
                DataRow focusRow = acGridView1.GetFocusedDataRow();

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["WORK_ID"] = focusRow["WORK_ID"];

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
                "WOR01A_DEL", paramSet, "RQSTDT", "",
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

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void acBarButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //신청
            acBarButtonItem1_ItemClick(null, null);

        }

        private void acBarButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //삭제

            DataRow focusRow = acGridView1.GetFocusedDataRow();

            if (focusRow != null)
            {
                acBarButtonItem3_ItemClick(null, null);
            }
        }
    }
}

