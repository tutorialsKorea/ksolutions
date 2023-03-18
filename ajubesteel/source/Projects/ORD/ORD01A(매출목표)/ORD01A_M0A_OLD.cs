using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Grid;
using ControlManager;
using CodeHelperManager;
using BizManager;

namespace ORD
{
    public sealed partial class ORD01A_M0A_OLD : BaseMenu
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

        public override bool MenuDestory(object sender)
        {
            if (base.MenuStatus == emMenuStatus.WORK)
            {

                if (acMessageBox.Show(this, "수정된 항목이 있습니다. 계속 진행 하시겠습니까?", "", false, acMessageBox.emMessageBoxType.YESNO) == DialogResult.Yes)
                {
                    base.MenuStatus = emMenuStatus.NONE;

                    base.MenuDestory(sender);

                    return true;

                }
                else
                {
                    return false;
                }

            }

            base.MenuDestory(sender);

            return true;
        }


        public ORD01A_M0A_OLD()
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


        public override void ChildContainerInit(Control sender)
        {
            if (sender == acLayoutControl1)
            {

                acLayoutControl layout = sender as acLayoutControl;

                layout.GetEditor("DATE").Value = "GOAL_Y";

                layout.GetEditor("S_DATE").Value = acDateEdit.GetNowFirstYear().AddYears(-1);

                layout.GetEditor("E_DATE").Value = acDateEdit.GetNowFirstYear();

            }

            base.ChildContainerInit(sender);
        }


        public override void MenuInit()
        {

            //연도
            acGridView1.GridType = acGridView.emGridType.LIST_SINGLE;

            acGridView1.AddTextEdit("GOAL_Y", "연도", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("Y_GOAL_AMT", "목표 매출액", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);

            acGridView1.AddTextEdit("EX_DL", "＄", "", false, DevExpress.Utils.HorzAlignment.Far, true, true, false, acGridView.emTextEditMask.MONEY_F4);

            acGridView1.AddTextEdit("EX_YEN", "￥", "", false, DevExpress.Utils.HorzAlignment.Far, true, true, false, acGridView.emTextEditMask.MONEY_F4);

            acGridView1.AddTextEdit("EX_EURO", "￡", "", false, DevExpress.Utils.HorzAlignment.Far, true, true, false, acGridView.emTextEditMask.MONEY_F4);

            acGridView1.KeyColumn = new string[] { "GOAL_Y" };


            //월
            acGridView2.GridType = acGridView.emGridType.LIST_SINGLE;

            acGridView2.AddHidden("GOAL_YM", typeof(string));

            acGridView2.AddDateEdit("GOAL_M", "월", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.MONTH_DATE);

            acGridView2.AddTextEdit("M_GOAL_AMT", "목표 금액", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);

            acGridView2.KeyColumn = new string[] { "GOAL_YM" };



            //
            acGridView3.GridType = acGridView.emGridType.LIST_SINGLE;

            acGridView3.AddHidden("CVND_CODE", typeof(string));

            RepositoryItemVendor repVendor = new RepositoryItemVendor();
            repVendor.EditValueChanged += RepVendor_EditValueChanged;
            acGridView3.AddCustomEdit("CVND_NAME", "고객사", "", false, DevExpress.Utils.HorzAlignment.Center, true, true, true, repVendor);

            for (int i = 0; i < 12; i++)
            {
                acGridView3.AddTextEdit("M" + (i+1).ToString("00"), (i + 1).ToString() + "월", "", false, DevExpress.Utils.HorzAlignment.Far, true, true, false, acGridView.emTextEditMask.MONEY);
            }
            acGridView3.KeyColumn = new string[] { "CVND_CODE" };




            acCheckedComboBoxEdit1.AddItem("연도", false, "", "GOAL_Y", true, false);

            acLayoutControl1.OnValueKeyDown += new acLayoutControl.ValueKeyDownEventHandler(acLayoutControl1_OnValueKeyDown);

            acLayoutControl1.OnValueChanged += new acLayoutControl.ValueChangedEventHandler(acLayoutControl1_OnValueChanged);


            acGridView1.FocusedRowChanged += acGridView1_FocusedRowChanged;

            acGridView1.ShowGridMenuEx += acGridView1_ShowGridMenuEx;

            acGridView1.CellValueChanging += acGridView1_CellValueChanging;

            acGridView2.CellValueChanging += acGridView2_CellValueChanging;

            acGridView2.CustomDrawCell += acGridView2_CustomDrawCell;

            acGridView1.CustomDrawCell += acGridView1_CustomDrawCell;

            this.Load += ORD01A_M0A_OLD_Load;

            base.MenuInit();
        }

        private void RepVendor_EditValueChanged(object sender, EventArgs e)
        {            

            DataRow focusRow = acGridView3.GetFocusedDataRow();

            acVendor vendor = sender as acVendor;

            DataView existView = acGridView3.GetDataView(string.Format("CVND_CODE = '{0}'", vendor.SelectedRow["VEN_CODE"]));

            if(existView.Count > 0)
            {
                vendor.EditValueChanged -= RepVendor_EditValueChanged;
                vendor.EditValue = null;
                vendor.EditValueChanged += RepVendor_EditValueChanged;
                acMessageBox.Show("이미 등록된 업체가 존재합니다.\r\n다시 확인하여 주십시오.", "확인", acMessageBox.emMessageBoxType.CONFIRM);
                return;
            }

            focusRow["CVND_CODE"] = vendor.SelectedRow["VEN_CODE"];
            focusRow["CVND_NAME"] = vendor.SelectedRow["VEN_NAME"];

        }

        void ORD01A_M0A_OLD_Load(object sender, EventArgs e)
        {
            //this.Search();
        }

        public override void MenuInitComplete()
        {
            this.Search();
            base.MenuInitComplete();
        }

        void acGridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (acGridView1.Columns[e.Column.FieldName.ToString()].Tag != null && mdfyMasterCellChanges != null)
            {
                if (acGridView1.Columns[e.Column.FieldName.ToString()].Tag.ToString() == "1")
                {
                    foreach (int i in mdfyMasterCellChanges)
                    {
                        if (e.RowHandle == i)
                        {
                            e.Appearance.BackColor = Color.AliceBlue;
                        }
                    }
                }
            }
        }

        void acGridView2_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (acGridView2.Columns[e.Column.FieldName.ToString()].Tag != null && mdfyDetailCellChanges != null)
            {
                if (acGridView2.Columns[e.Column.FieldName.ToString()].Tag.ToString() == "1")
                {
                    foreach (int i in mdfyDetailCellChanges)
                    {
                        if (e.RowHandle == i)
                        {
                            e.Appearance.BackColor = Color.AliceBlue;
                        }
                    }
                }
            }
        }

        int[] mdfyMasterCellChanges = null;

        int[] mdfyMasterCellChangestmp = null;

        void acGridView1_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            acGridView1.Columns[e.Column.FieldName.ToString()].Tag = "1";

            if (mdfyMasterCellChanges != null)
            {
                mdfyMasterCellChangestmp = new int[mdfyMasterCellChanges.Length + 1];

                int idx = 1;

                mdfyMasterCellChangestmp[0] = e.RowHandle;

                foreach (int i in mdfyMasterCellChanges)
                {
                    mdfyMasterCellChangestmp[idx++] = i;
                }

                mdfyMasterCellChanges = mdfyMasterCellChangestmp;
            }
            else
            {
                mdfyMasterCellChanges = new int[] { e.RowHandle };
            }

            base.MenuStatus = emMenuStatus.WORK;
        }


        int[] mdfyDetailCellChanges = null;

        int[] mdfyDetailCellChangestmp = null;

        void acGridView2_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            acGridView2.Columns[e.Column.FieldName.ToString()].Tag = "1";

            if (mdfyDetailCellChanges != null)
            {
                mdfyDetailCellChangestmp = new int[mdfyDetailCellChanges.Length + 1];

                int idx = 1;

                mdfyDetailCellChangestmp[0] = e.RowHandle;

                foreach (int i in mdfyDetailCellChanges)
                {
                    mdfyDetailCellChangestmp[idx++] = i;
                }

                mdfyDetailCellChanges = mdfyDetailCellChangestmp;
            }
            else
            {
                mdfyDetailCellChanges = new int[] { e.RowHandle };
            }

            base.MenuStatus = emMenuStatus.WORK;
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

        void acLayoutControl1_OnValueKeyDown(object sender, IBaseEditControl info, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.Search();
            }
        }

        void acGridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {

            if (base.MenuStatus == emMenuStatus.WORK)
            {

                if (acMessageBox.Show(this, "수정된 항목이 있습니다. 계속 진행 하시겠습니까?", "", false, acMessageBox.emMessageBoxType.YESNO) == DialogResult.Yes)
                {
                    mdfyDetailCellChanges = null;

                    mdfyMasterCellChanges = null;

                    DataTable dt = (DataTable)acGridView1.GridControl.DataSource;

                    if (dt != null)
                    {
                        foreach (DataColumn col in dt.Columns)
                        {
                            if (acGridView1.Columns[col.ColumnName.ToString()] != null)
                            {
                                acGridView1.Columns[col.ColumnName.ToString()].Tag = null;
                            }
                        }
                    }

                    base.MenuStatus = emMenuStatus.NONE;

                    this.GetDetail();
                }
                else
                {
                    this.acGridView1.FocusedRowChanged -= new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(acGridView1_FocusedRowChanged);

                    acGridView1.FocusedRowHandle = e.PrevFocusedRowHandle;

                    this.acGridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(acGridView1_FocusedRowChanged);

                    return;
                }

            }
            else
            {
                this.GetDetail();
            }
        }

        void acGridView1_ShowGridMenuEx(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            acGridView view = sender as acGridView;

            if (e.HitInfo.HitTest == GridHitTest.EmptyRow || e.HitInfo.HitTest == GridHitTest.Row || e.HitInfo.HitTest == GridHitTest.RowCell)
            {

                GridHitInfo hitInfo = view.CalcHitInfo(e.Point);

                popupMenu1.ShowPopup(view.GridControl.PointToScreen(e.Point));

            }

        }


        void Search()
        {
            //조회

            if (base.MenuStatus == emMenuStatus.WORK)
            {
                if (acMessageBox.Show(this, "수정된 항목이 있습니다. 계속 진행 하시겠습니까?", "", false, acMessageBox.emMessageBoxType.YESNO) == DialogResult.Yes)
                {
                    mdfyDetailCellChanges = null;

                    mdfyMasterCellChanges = null;

                    DataTable dt = (DataTable)acGridView1.GridControl.DataSource;

                    if (dt != null)
                    {
                        foreach (DataColumn col in dt.Columns)
                        {
                            if (acGridView1.Columns[col.ColumnName.ToString()] != null)
                            {
                                acGridView1.Columns[col.ColumnName.ToString()].Tag = null;
                            }
                        }
                    }

                    base.MenuStatus = emMenuStatus.NONE;

                    Search2();
                }
            }
            else
            {
                Search2();
            }

        }

        void Search2()
        {
            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String));
            paramTable.Columns.Add("S_GOAL_Y", typeof(String));
            paramTable.Columns.Add("E_GOAL_Y", typeof(String));

            DataRow layoutRow = acLayoutControl1.CreateParameterRow();

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;

            foreach (string key in acCheckedComboBoxEdit1.GetKeyChecked())
            {
                switch (key)
                {
                    case "GOAL_Y":

                        //수주일

                        paramRow["S_GOAL_Y"] = layoutRow["S_DATE"];
                        paramRow["E_GOAL_Y"] = layoutRow["E_DATE"];

                        break;


                }
            }

            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);


            BizRun.QBizRun.ExecuteService(
             this, QBiz.emExecuteType.LOAD,
             "ORD01A_SER", paramSet, "RQSTDT", "RSLTDT",
             QuickSearch,
             QuickException);
        }

        void QuickException(object sender, QBiz qBiz, BizException ex)
        {
            acMessageBox.Show(this, ex);
        }

        void QuickSearch(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                acGridView1.GridControl.DataSource = e.result.Tables["RSLTDT"];

                base.MenuStatus = emMenuStatus.NONE;

                base.SetLog(e.executeType, e.result.Tables["RSLTDT"].Rows.Count, e.executeTime);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void GetDetail()
        {
            DataRow focusRow = acGridView1.GetFocusedDataRow();

            if (focusRow != null)
            {
                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String));
                paramTable.Columns.Add("GOAL_Y", typeof(String));

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["GOAL_Y"] = focusRow["GOAL_Y"];

                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(
                 this, QBiz.emExecuteType.LOAD_DETAIL,
                 "ORD01A_SER2", paramSet, "RQSTDT", "RSLTDT,RSLTDT_MONTH",
                 QuickSearchDetail,
                 QuickException);
            }
            else
            {
                acGridView2.ClearRow();
            }
        }

        void QuickSearchDetail(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                acGridView2.GridControl.DataSource = e.result.Tables["RSLTDT_MONTH"];

                acGridView3.GridControl.DataSource = GetPivotCvnd(e.result.Tables["RSLTDT"]);

                base.SetLog(e.executeType, e.result.Tables["RSLTDT"].Rows.Count, e.executeTime);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }


        DataTable GetPivotCvnd(DataTable dt)
        {
            DataTable dtTemp = new DataTable();
            dtTemp.Columns.Add("CVND_CODE", typeof(string));
            dtTemp.Columns.Add("CVND_NAME", typeof(string));
            for(int i = 0; i < 12; i++)
            {
                dtTemp.Columns.Add("M" + (i+1).ToString("00"),typeof(decimal));
            }

            try
            {
                foreach (DataRow row in dt.Rows)
                {
                    DataRow[] ser = dtTemp.Select(string.Format("CVND_CODE = '{0}'", row["CVND_CODE"]));

                    if (ser.Length > 0)
                    {
                        ser[0]["M" + row["GOAL_YM"].ToString().Substring(4, 2)] = row["GOAL_AMT"];
                    }
                    else
                    {
                        DataRow newRow = dtTemp.NewRow();
                        newRow["CVND_CODE"] = row["CVND_CODE"];
                        newRow["CVND_NAME"] = row["CVND_NAME"];
                        newRow["M" + row["GOAL_YM"].ToString().Substring(4, 2)] = row["GOAL_AMT"];
                        dtTemp.Rows.Add(newRow);
                    }
                }
            }
            catch
            {


            }

            return dtTemp;
        }

        private void barItemSearch_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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
            //추가
            try
            {
                if (acMessageBox.Show(this, "새로운 연도를 추가하시겠습니까?", "", false, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
                {
                    return;
                }

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String));

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;

                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(
                 this, QBiz.emExecuteType.LOAD_DETAIL,
                 "ORD01A_INS", paramSet, "RQSTDT", "RSLTDT",
                 QuickINS,
                 QuickException);

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void QuickINS(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                foreach (DataRow row in e.result.Tables["RSLTDT"].Rows)
                {
                    if (base.MenuStatus == emMenuStatus.WORK)
                    {
                        acGridView1.UpdateMapingRow(row, true);
                    }
                    else
                    {
                        acGridView1.UpdateMapingRow(row, true);
                    }
                }
                acGridView1.RaiseFocusedRowChanged();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void acSplitContainerControl2_SplitterPositionChanged(object sender, EventArgs e)
        {
            int Width = acSplitContainerControl2.Panel2.Width;

            acLayoutControl2.Width = Width / 2;
        }

        private void acBarButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //저장
            try
            {
                acGridView1.EndEditor();

                acGridView2.EndEditor();

                acGridView3.EndEditor();

                DataRow masterRow = acGridView1.GetFocusedDataRow();

                DataView detailView = acGridView3.GetDataView();

                DataTable paramTableM = new DataTable("RQSTDT_M");
                paramTableM.Columns.Add("PLT_CODE", typeof(String));
                paramTableM.Columns.Add("GOAL_Y", typeof(String));
                paramTableM.Columns.Add("EX_DL", typeof(Decimal));
                paramTableM.Columns.Add("EX_YEN", typeof(Decimal));
                paramTableM.Columns.Add("EX_EURO", typeof(Decimal));
                
          
                DataRow paramRow = paramTableM.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;

                paramRow["GOAL_Y"] = masterRow["GOAL_Y"];

                paramRow["EX_DL"] = masterRow["EX_DL"];
                paramRow["EX_YEN"] = masterRow["EX_YEN"];
                paramRow["EX_EURO"] = masterRow["EX_EURO"];

                paramTableM.Rows.Add(paramRow);
          

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String));
                paramTable.Columns.Add("CVND_CODE", typeof(String));
                paramTable.Columns.Add("GOAL_YM", typeof(String));
                paramTable.Columns.Add("GOAL_AMT", typeof(Decimal));
                paramTable.Columns.Add("EX_DL", typeof(Decimal));
                paramTable.Columns.Add("EX_YEN", typeof(Decimal));
                paramTable.Columns.Add("EX_EURO", typeof(Decimal));

                for (int i = 0; i < detailView.Count; i++)
                {
                    for (int a = 0; a < 12; a++)
                    {
                        DataRow paramRow2 = paramTable.NewRow();
                        paramRow2["PLT_CODE"] = acInfo.PLT_CODE;
                        paramRow2["CVND_CODE"] = detailView[i]["CVND_CODE"];

                        paramRow2["GOAL_YM"] = masterRow["GOAL_Y"].ToString() + (a+1).ToString("00");
                        paramRow2["GOAL_AMT"] = detailView[i]["M"+ (a + 1).ToString("00")];

                        paramRow2["EX_DL"] = masterRow["EX_DL"];
                        paramRow2["EX_YEN"] = masterRow["EX_YEN"];
                        paramRow2["EX_EURO"] = masterRow["EX_EURO"];

                        paramTable.Rows.Add(paramRow2);
                    }
                }

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTableM);
                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(
                 this, QBiz.emExecuteType.SAVE,
                 "ORD01A_SAVE", paramSet, "RQSTDT", "RSLTDT_M,RSLTDT",
                 QuickSave,
                 QuickException);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }
        void QuickSave(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                base.MenuStatus = emMenuStatus.NONE;

                mdfyMasterCellChanges = null;

                mdfyDetailCellChanges = null;

                DataTable dt = (DataTable)acGridView1.GridControl.DataSource;

                if (dt != null)
                {
                    foreach (DataColumn col in dt.Columns)
                    {
                        if (acGridView1.Columns[col.ColumnName.ToString()] != null)
                        {
                            acGridView1.Columns[col.ColumnName.ToString()].Tag = null;
                        }
                    }
                }

                foreach (DataRow row in e.result.Tables["RSLTDT_YEAR"].Rows)
                {
                    acGridView1.UpdateMapingRow(row, true);
                }

                acGridView2.GridControl.DataSource = e.result.Tables["RSLTDT_MONTH"];

                acGridView1.AcceptChanges();
                acGridView3.AcceptChanges();

                acAlert.Show(this, "저장되었습니다.", acAlertForm.enmType.Success);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void acSimpleButton1_Click(object sender, EventArgs e)
        {
            if(acGridView1.RowCount == 0)
            {
                acMessageBox.Show("선택된 년도가 없습니다.", "확인", acMessageBox.emMessageBoxType.CONFIRM);
                return;
            }

            acGridView3.AddRow(acGridView3.NewRow());
        }

        private void acSimpleButton2_Click(object sender, EventArgs e)
        {
            if(acGridView3.RowCount > 0)
            {
                acGridView3.DeleteMappingRow(acGridView3.GetFocusedDataRow());
            }
        }
    }
}
