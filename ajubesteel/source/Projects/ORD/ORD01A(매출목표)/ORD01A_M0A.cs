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
using DevExpress.XtraGrid;
using ControlManager;
using CodeHelperManager;
using BizManager;

namespace ORD
{
    public sealed partial class ORD01A_M0A : BaseMenu
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


        public ORD01A_M0A()
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

                layout.GetEditor("S_DATE").Value = acDateEdit.GetNowFirstYear().AddYears(-5);

                layout.GetEditor("E_DATE").Value = acDateEdit.GetNowFirstYear().AddYears(5);
              

            }

         
            base.ChildContainerInit(sender);
        }


        public override void MenuInit()
        {
            //연도
            acGridView3.GridType = acGridView.emGridType.LIST_SINGLE;

            acGridView3.AddTextEdit("GOAL_Y", "연도", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView3.AddTextEdit("WON", "￦(원화)", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);

            acGridView3.AddTextEdit("EX_DL", "＄(달러)", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.F2);

            acGridView3.AddTextEdit("EX_YEN", "￥(엔화)", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.F2);

            acGridView3.AddTextEdit("EX_DONG", "₫ (동)", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.F2);

            acGridView3.KeyColumn = new string[] { "GOAL_Y" };

            acGridView3.Columns["GOAL_Y"].SortOrder = DevExpress.Data.ColumnSortOrder.Descending;

            //연도 업체별
            acGridView1.GridType = acGridView.emGridType.LIST_SINGLE;

            //acGridView1.AddLookUpEmp("GOAL_EMP", "마감처", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false);

            acGridView1.AddTextEdit("GOAL_EMP", "마감처코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("GOAL_EMP_NAME", "마감처", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("GOAL_Y", "연도", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("WON", "￦(원화)", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);

            acGridView1.AddTextEdit("EX_DL", "＄(달러)", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.F2);

            acGridView1.AddTextEdit("EX_YEN", "￥(엔화)", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.F2);

            acGridView1.AddTextEdit("EX_DONG", "₫ (동)", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.F2);

            acGridView1.KeyColumn = new string[] { "GOAL_EMP", "GOAL_Y" };

            acGridView1.Columns["GOAL_EMP"].SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
            acGridView1.Columns["GOAL_Y"].SortOrder = DevExpress.Data.ColumnSortOrder.Descending;



            //월
            acGridView2.GridType = acGridView.emGridType.LIST_SINGLE;

            acGridView2.AddDateEdit("GOAL_YM", "월", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.MONTH_DATE);

            acGridView2.AddTextEdit("WON", "￦(원화)", "", false, DevExpress.Utils.HorzAlignment.Far, true, true, false, acGridView.emTextEditMask.MONEY);

            acGridView2.AddTextEdit("EX_DL", "＄(달러)", "", false, DevExpress.Utils.HorzAlignment.Far, true, true, false, acGridView.emTextEditMask.F2);

            acGridView2.AddTextEdit("EX_YEN", "￥(엔화)", "", false, DevExpress.Utils.HorzAlignment.Far, true, true, false, acGridView.emTextEditMask.F2);

            acGridView2.AddTextEdit("EX_DONG", "₫ (동)", "", false, DevExpress.Utils.HorzAlignment.Far, true, true, false, acGridView.emTextEditMask.F2);

            acGridView2.KeyColumn = new string[] { "GOAL_YM" };


            acGridView2.OptionsView.ShowFooter = true;
            acGridView2.OptionsView.GroupFooterShowMode = GroupFooterShowMode.VisibleAlways;
            GridColumnSummaryItem itemWon = new GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "WON", "￦(합계): {0:n0}");
            GridColumnSummaryItem itemDL = new GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "EX_DL", "＄(합계): {0:n2}");
            GridColumnSummaryItem itemYen = new GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "EX_YEN", "￥(합계): {0:n2}");
            GridColumnSummaryItem itemEuro = new GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "EX_DONG", "₫(합계): {0:n2}");

            acGridView2.Columns["WON"].Summary.Add(itemWon);
            acGridView2.Columns["EX_DL"].Summary.Add(itemDL);
            acGridView2.Columns["EX_YEN"].Summary.Add(itemYen);
            acGridView2.Columns["EX_DONG"].Summary.Add(itemEuro);


            acCheckedComboBoxEdit1.AddItem("연도", false, "", "GOAL_Y", true, false);

            acLayoutControl1.OnValueKeyDown += new acLayoutControl.ValueKeyDownEventHandler(acLayoutControl1_OnValueKeyDown);

            acLayoutControl1.OnValueChanged += new acLayoutControl.ValueChangedEventHandler(acLayoutControl1_OnValueChanged);

            //this.acGridView1.OnMapingRowChanged += new acGridView.MapingRowChangedEventHandler(acGridView1_OnMapingRowChanged);

            acGridView3.FocusedRowChanged += acGridView3_FocusedRowChanged;
            acGridView1.FocusedRowChanged += acGridView1_FocusedRowChanged;

            acGridView1.ShowGridMenuEx += acGridView1_ShowGridMenuEx;

            acGridView2.CellValueChanging += acGridView2_CellValueChanging;

            acGridView2.CustomDrawCell += acGridView2_CustomDrawCell;

            acLayoutControl3.GetEditor("GOAL_EMP").Value = acInfo.UserID;
            acLayoutControl3.GetEditor("GOAL_Y").Value = acDateEdit.GetNowFirstYear().AddYears(0);

       
            this.Load += ORD01A_M0A_Load;

            base.MenuInit();
        }

        void ORD01A_M0A_Load(object sender, EventArgs e)
        {
            // this.Search();

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String));
            //paramTable.Columns.Add("ORG_CODE", typeof(String));

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            //paramRow["ORG_CODE"] = "P002";

            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            DataSet dsRslt = BizRun.QBizRun.ExecuteService(this, "ORD01A_SER3", paramSet, "RQSTDT", "RSLTDT");

            (acLayoutControl3.GetEditor("GOAL_EMP").Editor as acLookupEdit).SetData("BVEN_NAME", "BVEN_CODE", dsRslt.Tables["RSLTDT"]);

        }


        public override void MenuInitComplete()
        {
            //this.Search();
            base.MenuInitComplete();
        }



        void acGridView1_OnMapingRowChanged(acGridView.emMappingRowChangedType type, DataRow row)
        {
           
        }


        void acGridView2_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            //if (acGridView2.Columns[e.Column.FieldName.ToString()].Tag != null && mdfyDetailCellChanges != null)
            //{
            //    if (acGridView2.Columns[e.Column.FieldName.ToString()].Tag.ToString() == "1")
            //    {
            //        foreach (int i in mdfyDetailCellChanges)
            //        {
            //            if (e.RowHandle == i)
            //            {
            //                e.Appearance.BackColor = Color.AliceBlue;
            //            }
            //        }
            //    }
            //}
        }



        //int[] mdfyDetailCellChanges = null;

        //int[] mdfyDetailCellChangestmp = null;

   
        void acGridView2_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            //acGridView2.Columns[e.Column.FieldName.ToString()].Tag = "1";

            //if (mdfyDetailCellChanges != null)
            //{
            //    mdfyDetailCellChangestmp = new int[mdfyDetailCellChanges.Length + 1];

            //    int idx = 1;

            //    mdfyDetailCellChangestmp[0] = e.RowHandle;

            //    foreach (int i in mdfyDetailCellChanges)
            //    {
            //        mdfyDetailCellChangestmp[idx++] = i;
            //    }

            //    mdfyDetailCellChanges = mdfyDetailCellChangestmp;
            //}
            //else
            //{
            //    mdfyDetailCellChanges = new int[] { e.RowHandle };
            //}

            //base.MenuStatus = emMenuStatus.WORK;
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
                SearchYear();
                //this.Search();
            }
        }

        void acGridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {

            acGridView1.EndEditor();

            DataRow focusRow = acGridView1.GetFocusedDataRow();
            if (focusRow.isNullOrEmpty()
                || focusRow["GOAL_Y"].ToString() == "") { return; }

            acLayoutControl3.GetEditor("GOAL_EMP").Value = focusRow["GOAL_EMP"].ToString();

            acLayoutControl3.GetEditor("GOAL_Y").Value = DateTime.ParseExact(focusRow["GOAL_Y"].ToString(), "yyyy", null);


            //if (base.MenuStatus == emMenuStatus.WORK)
            //{

            //    if (acMessageBox.Show(this, "수정된 항목이 있습니다. 계속 진행 하시겠습니까?", "", false, acMessageBox.emMessageBoxType.YESNO) == DialogResult.Yes)
            //    {
            //        mdfyDetailCellChanges = null;

            //        DataTable dt = (DataTable)acGridView2.GridControl.DataSource;

            //        if (dt != null)
            //        {
            //            foreach (DataColumn col in dt.Columns)
            //            {
            //                if (acGridView2.Columns[col.ColumnName.ToString()] != null)
            //                {
            //                    acGridView2.Columns[col.ColumnName.ToString()].Tag = null;
            //                }
            //            }
            //        }

            //        base.MenuStatus = emMenuStatus.NONE;

            //        this.GetDetail();
            //    }
            //    else
            //    {
            //        this.acGridView1.FocusedRowChanged -= new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(acGridView1_FocusedRowChanged);

            //        acGridView1.FocusedRowHandle = e.PrevFocusedRowHandle;

            //        this.acGridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(acGridView1_FocusedRowChanged);

            //        return;
            //    }

            //}
            //else
            //{
                this.GetDetail();
            //}
        }

        private void acGridView3_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            acGridView3.EndEditor();

            DataRow focusRow = acGridView3.GetFocusedDataRow();
            if (focusRow.isNullOrEmpty()) { return; }

            acLayoutControl3.GetEditor("GOAL_Y").Value = DateTime.ParseExact(focusRow["GOAL_Y"].ToString(), "yyyy", null);


            //if (base.MenuStatus == emMenuStatus.WORK)
            //{

            //    if (acMessageBox.Show(this, "수정된 항목이 있습니다. 계속 진행 하시겠습니까?", "", false, acMessageBox.emMessageBoxType.YESNO) == DialogResult.Yes)
            //    {
            //        mdfyDetailCellChanges = null;

            //        DataTable dt = (DataTable)acGridView2.GridControl.DataSource;

            //        if (dt != null)
            //        {
            //            foreach (DataColumn col in dt.Columns)
            //            {
            //                if (acGridView2.Columns[col.ColumnName.ToString()] != null)
            //                {
            //                    acGridView2.Columns[col.ColumnName.ToString()].Tag = null;
            //                }
            //            }
            //        }

            //        base.MenuStatus = emMenuStatus.NONE;

            //        this.Search();
            //    }
            //    else
            //    {
            //        this.acGridView3.FocusedRowChanged -= new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(acGridView1_FocusedRowChanged);

            //        acGridView3.FocusedRowHandle = e.PrevFocusedRowHandle;

            //        this.acGridView3.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(acGridView1_FocusedRowChanged);

            //        return;
            //    }

            //}
            //else
            //{
                this.Search();
            //}
        }

        void acGridView1_ShowGridMenuEx(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            acGridView view = sender as acGridView;

            if (e.HitInfo.HitTest == GridHitTest.Row || e.HitInfo.HitTest == GridHitTest.RowCell)
            {

                GridHitInfo hitInfo = view.CalcHitInfo(e.Point);

                popupMenu1.ShowPopup(view.GridControl.PointToScreen(e.Point));

            }

        }


        void Search()
        {
            //조회

            //if (base.MenuStatus == emMenuStatus.WORK)
            //{
            //    if (acMessageBox.Show(this, "수정된 항목이 있습니다. 계속 진행 하시겠습니까?", "", false, acMessageBox.emMessageBoxType.YESNO) == DialogResult.Yes)
            //    {
            //        mdfyDetailCellChanges = null;

            //        DataTable dt = (DataTable)acGridView2.GridControl.DataSource;

            //        if (dt != null)
            //        {
            //            foreach (DataColumn col in dt.Columns)
            //            {
            //                if (acGridView2.Columns[col.ColumnName.ToString()] != null)
            //                {
            //                    acGridView2.Columns[col.ColumnName.ToString()].Tag = null;
            //                }
            //            }
            //        }

            //        base.MenuStatus = emMenuStatus.NONE;

            //        Search2();
            //    }
            //}
            //else
            //{
                Search2();
            //}

        }

        void Search2()
        {

            DataRow focusRow = acGridView3.GetFocusedDataRow();

            if (focusRow == null) return;

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String));
            paramTable.Columns.Add("S_GOAL_Y", typeof(String));
            paramTable.Columns.Add("E_GOAL_Y", typeof(String));

          
            //DataRow layoutRow = acLayoutControl1.CreateParameterRow();

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;

            foreach (string key in acCheckedComboBoxEdit1.GetKeyChecked())
            {
                switch (key)
                {
                    case "GOAL_Y":
                        //paramRow["S_GOAL_Y"] = layoutRow["S_DATE"];
                        //paramRow["E_GOAL_Y"] = layoutRow["E_DATE"];

                        paramRow["S_GOAL_Y"] = focusRow["GOAL_Y"];
                        paramRow["E_GOAL_Y"] = focusRow["GOAL_Y"];

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

        void SearchYear()
        {
            //년도 조회
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
             "ORD01A_SER4", paramSet, "RQSTDT", "RSLTDT",
             QuickSearchYear,
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
                if(e.result.Tables["RSLTDT"].Rows.Count == 0)
                {

                    string Year = acLayoutControl3.GetEditor("GOAL_Y").Value.toDateString("yyyy");

                    DataTable dtTemp = new DataTable();
                    dtTemp.Columns.Add("GOAL_YM", typeof(String));
                    dtTemp.Columns.Add("WON", typeof(String));
                    dtTemp.Columns.Add("EX_DL", typeof(String));
                    dtTemp.Columns.Add("EX_YEN", typeof(String));
                    dtTemp.Columns.Add("EX_DONG", typeof(String));

                    for (int i = 0; i < 12; i++)
                    {
                        DataRow paramRow = dtTemp.NewRow();
                        paramRow["GOAL_YM"] = Year + (i + 1).ToString("00");
                        paramRow["WON"] = null;
                        paramRow["EX_DL"] = null;
                        paramRow["EX_YEN"] = null;
                        paramRow["EX_DONG"] = null;
                        dtTemp.Rows.Add(paramRow);
                    }

                    acGridView2.GridControl.DataSource = dtTemp;



                }
                else
                {
                    acGridView1.GridControl.DataSource = e.result.Tables["RSLTDT"];

                    base.MenuStatus = emMenuStatus.NONE;

                    base.SetLog(e.executeType, e.result.Tables["RSLTDT"].Rows.Count, e.executeTime);
                }

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void QuickSearchYear(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                acGridView3.GridControl.DataSource = e.result.Tables["RSLTDT"];

                if (e.result.Tables["RSLTDT"].Rows.Count == 0)
                {
                    acGridView1.ClearRow();
                    acGridView2.ClearRow();
                }

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
                paramTable.Columns.Add("GOAL_EMP", typeof(String));
                paramTable.Columns.Add("YEAR", typeof(String));

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["GOAL_EMP"] = focusRow["GOAL_EMP"];
                paramRow["YEAR"] = focusRow["GOAL_Y"];

                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(
                 this, QBiz.emExecuteType.LOAD_DETAIL,
                 "ORD01A_SER2", paramSet, "RQSTDT", "RSLTDT",
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
                if (e.result.Tables["RSLTDT"].Rows.Count > 0)
                {
                    acGridView2.GridControl.DataSource = e.result.Tables["RSLTDT"];

                    base.SetLog(e.executeType, e.result.Tables["RSLTDT"].Rows.Count, e.executeTime);
                }
         
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
                this.SearchYear();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        private void acBarButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //삭제
            try
            {
                if (acMessageBox.Show(this, "정말 삭제하시겠습니까?", "", false, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
                {
                    return;
                }

                acGridView1.EndEditor();

                DataRow focusRow = acGridView1.GetFocusedDataRow();

                if (focusRow.isNullOrEmpty()) { return; }

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String));
                paramTable.Columns.Add("GOAL_EMP", typeof(String));
                paramTable.Columns.Add("GOAL_Y", typeof(String));
                paramTable.Columns.Add("S_GOAL_Y", typeof(String));
                paramTable.Columns.Add("E_GOAL_Y", typeof(String));

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["GOAL_EMP"] = focusRow["GOAL_EMP"].ToString();
                paramRow["GOAL_Y"] = focusRow["GOAL_Y"].ToString();
                paramRow["S_GOAL_Y"] = focusRow["GOAL_Y"].ToString();
                paramRow["E_GOAL_Y"] = focusRow["GOAL_Y"].ToString();

                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.DEL,
                "ORD01A_DEL", paramSet, "RQSTDT", "RSLTDT",
                 QuickDelete,
                 QuickException);

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void QuickDelete(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                foreach (DataRow row in e.result.Tables["RQSTDT"].Rows)
                {
                    acGridView1.DeleteMappingRow(row);
                }

                foreach (DataRow row in e.result.Tables["RSLTDT"].Rows)
                {
                    acGridView3.UpdateMapingRow(row, false);
                }

                if (e.result.Tables["RSLTDT"].Rows.Count == 0)
                {
                    DataRow focusRow = acGridView3.GetFocusedDataRow();

                    acGridView3.DeleteMappingRow(focusRow);
                }

                //acGridView1.RaiseFocusedRowChanged();
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

                acGridView2.EndEditor();

                DataView detailView = acGridView2.GetDataView();

                DataTable dtView = detailView.ToTable();

                DataRow layoutRow = acLayoutControl1.CreateParameterRow();

                DataRow layoutRow2 = acLayoutControl3.CreateParameterRow();

                string goal_Emp = layoutRow2["GOAL_EMP"].ToString();
                string goal_Year = layoutRow2["GOAL_Y"].toDateString("yyyy");

                DataRow focusRow = acGridView1.GetFocusedDataRow();

                // 기간별
                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String));
                paramTable.Columns.Add("S_GOAL_Y", typeof(String));
                paramTable.Columns.Add("E_GOAL_Y", typeof(String));

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["S_GOAL_Y"] = goal_Year;
                paramRow["E_GOAL_Y"] = goal_Year;

                paramTable.Rows.Add(paramRow);


                // 년도별
                DataTable paramTableY = new DataTable("RQSTDT_Y");
                paramTableY.Columns.Add("PLT_CODE", typeof(String));
                paramTableY.Columns.Add("GOAL_EMP", typeof(String));
                paramTableY.Columns.Add("GOAL_Y", typeof(String));

                DataRow paramYRow = paramTableY.NewRow();
                paramYRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramYRow["GOAL_EMP"] = goal_Emp;
                paramYRow["GOAL_Y"] = goal_Year;

                paramTableY.Rows.Add(paramYRow);
            

                // 월별
                DataTable paramTableM = new DataTable("RQSTDT_M");
                paramTableM.Columns.Add("PLT_CODE", typeof(String));
                paramTableM.Columns.Add("GOAL_EMP", typeof(String));
                paramTableM.Columns.Add("GOAL_YM", typeof(String));
                paramTableM.Columns.Add("GOAL_AMT", typeof(Decimal));
                paramTableM.Columns.Add("WON", typeof(Decimal));
                paramTableM.Columns.Add("EX_DL", typeof(Decimal));
                paramTableM.Columns.Add("EX_YEN", typeof(Decimal));
                paramTableM.Columns.Add("EX_DONG", typeof(Decimal));

                foreach (DataRow dr in dtView.Rows)
                {
                    if (goal_Year != dr["GOAL_YM"].toDateString("yyyy"))
                    {
                        acAlert.Show(this, "연도와 월별 목표 매출 연도가 맞지 않습니다.", acAlertForm.enmType.Warning);

                        return;
                    }

                    DataRow paramMRow = paramTableM.NewRow();
                    paramMRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramMRow["GOAL_EMP"] = goal_Emp;
                    paramMRow["GOAL_YM"] = dr["GOAL_YM"].toDateString("yyyyMM");
                    paramMRow["WON"] = dr["WON"];
                    paramMRow["EX_DL"] = dr["EX_DL"];
                    paramMRow["EX_YEN"] = dr["EX_YEN"];
                    paramMRow["EX_DONG"] = dr["EX_DONG"];

                    paramTableM.Rows.Add(paramMRow);

                }

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);
                paramSet.Tables.Add(paramTableY);
                paramSet.Tables.Add(paramTableM);

                BizRun.QBizRun.ExecuteService(
                 this, QBiz.emExecuteType.SAVE,
                 "ORD01A_SAVE", paramSet, "RQSTDT", "RSLTDT, RSLTDT",
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

                //base.MenuStatus = emMenuStatus.NONE;

                //mdfyDetailCellChanges = null;

                //DataTable dt = (DataTable)acGridView2.GridControl.DataSource;

                //if (dt != null)
                //{
                //    foreach (DataColumn col in dt.Columns)
                //    {
                //        if (acGridView1.Columns[col.ColumnName.ToString()] != null)
                //        {
                //            acGridView1.Columns[col.ColumnName.ToString()].Tag = null;
                //        }
                //    }
                //}

                foreach (DataRow row in e.result.Tables["RSLTDT"].Rows)
                {
                    acGridView1.UpdateMapingRow(row, true);
                }


                foreach (DataRow row in e.result.Tables["RSLTDT_YEAR"].Rows)
                {
                    acGridView3.UpdateMapingRow(row, true);
                }

                //acGridView1.GridControl.DataSource = e.result.Tables["RSLTDT"];

                acGridView1.AcceptChanges();
                
                acGridView2.AcceptChanges();

                acAlert.Show(this, "저장되었습니다.", acAlertForm.enmType.Success);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void acSimpleButton1_Click(object sender, EventArgs e)
        {
            // 새로쓰기
            string Year = acLayoutControl3.GetEditor("GOAL_Y").Value.toDateString("yyyy");

            DataTable dtTemp = new DataTable();
            dtTemp.Columns.Add("GOAL_YM", typeof(String));
            dtTemp.Columns.Add("WON", typeof(String));
            dtTemp.Columns.Add("EX_DL", typeof(String));
            dtTemp.Columns.Add("EX_YEN", typeof(String));
            dtTemp.Columns.Add("EX_DONG", typeof(String));

            for (int i = 0; i < 12; i++)
            {
                DataRow paramRow = dtTemp.NewRow();
                paramRow["GOAL_YM"] = Year + (i + 1).ToString("00");
                paramRow["WON"] = null;
                paramRow["EX_DL"] = null;
                paramRow["EX_YEN"] = null;
                paramRow["EX_DONG"] = null;
                dtTemp.Rows.Add(paramRow);
            }

            acGridView2.GridControl.DataSource = dtTemp;

        }

        private void acSplitContainerControl2_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void acSimpleButton2_Click(object sender, EventArgs e)
        {
            acBarButtonItem1_ItemClick(null, null);
        }
    }
}
