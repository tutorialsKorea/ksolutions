using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

using ControlManager;
using DevExpress.XtraEditors.Repository;
using DevExpress.Utils;
using DevExpress.XtraCharts;
using System.Linq;
using BizManager;

namespace REP
{
    public sealed partial class REP08A_M0A : BaseMenu
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




        public REP08A_M0A()
        {
            InitializeComponent();

            #region 이벤트 설정

            acLayoutControl1.OnValueKeyDown += new acLayoutControl.ValueKeyDownEventHandler(acLayoutControl1_OnValueKeyDown);

            acLayoutControl2.OnValueKeyDown += new acLayoutControl.ValueKeyDownEventHandler(acLayoutControl2_OnValueKeyDown);


            #endregion
        }

        void acLayoutControl3_OnValueKeyDown(object sender, IBaseEditControl info, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.Search();
            }
        }

        void acLayoutControl2_OnValueKeyDown(object sender, IBaseEditControl info, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.Search();
            }
        }

        void acLayoutControl1_OnValueKeyDown(object sender, IBaseEditControl info, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.Search();
            }
        }






        public override void MenuInit()
        {
            acGridView1.GridType = acGridView.emGridType.LIST;
            acGridView1.AddTextEdit("TYPE", "유형", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("WORK_1", "1월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView1.AddTextEdit("WORK_2", "2월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView1.AddTextEdit("WORK_3", "3월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView1.AddTextEdit("WORK_4", "4월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView1.AddTextEdit("WORK_5", "5월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView1.AddTextEdit("WORK_6", "6월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView1.AddTextEdit("WORK_7", "7월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView1.AddTextEdit("WORK_8", "8월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView1.AddTextEdit("WORK_9", "9월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView1.AddTextEdit("WORK_10", "10월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView1.AddTextEdit("WORK_11", "11월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView1.AddTextEdit("WORK_12", "12월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView1.AddTextEdit("WORK_SUM", "합계", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView1.AddTextEdit("WORK_RATE", "비율", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.PER2);

            acGridView1.AddTextEdit("WORK_1_R", "1월", "", false, DevExpress.Utils.HorzAlignment.Far, false, false, false, acGridView.emTextEditMask.PER2);
            acGridView1.AddTextEdit("WORK_2_R", "2월", "", false, DevExpress.Utils.HorzAlignment.Far, false, false, false, acGridView.emTextEditMask.PER2);
            acGridView1.AddTextEdit("WORK_3_R", "3월", "", false, DevExpress.Utils.HorzAlignment.Far, false, false, false, acGridView.emTextEditMask.PER2);
            acGridView1.AddTextEdit("WORK_4_R", "4월", "", false, DevExpress.Utils.HorzAlignment.Far, false, false, false, acGridView.emTextEditMask.PER2);
            acGridView1.AddTextEdit("WORK_5_R", "5월", "", false, DevExpress.Utils.HorzAlignment.Far, false, false, false, acGridView.emTextEditMask.PER2);
            acGridView1.AddTextEdit("WORK_6_R", "6월", "", false, DevExpress.Utils.HorzAlignment.Far, false, false, false, acGridView.emTextEditMask.PER2);
            acGridView1.AddTextEdit("WORK_7_R", "7월", "", false, DevExpress.Utils.HorzAlignment.Far, false, false, false, acGridView.emTextEditMask.PER2);
            acGridView1.AddTextEdit("WORK_8_R", "8월", "", false, DevExpress.Utils.HorzAlignment.Far, false, false, false, acGridView.emTextEditMask.PER2);
            acGridView1.AddTextEdit("WORK_9_R", "9월", "", false, DevExpress.Utils.HorzAlignment.Far, false, false, false, acGridView.emTextEditMask.PER2);
            acGridView1.AddTextEdit("WORK_10_R", "10월", "", false, DevExpress.Utils.HorzAlignment.Far, false, false, false, acGridView.emTextEditMask.PER2);
            acGridView1.AddTextEdit("WORK_11_R", "11월", "", false, DevExpress.Utils.HorzAlignment.Far, false, false, false, acGridView.emTextEditMask.PER2);
            acGridView1.AddTextEdit("WORK_12_R", "12월", "", false, DevExpress.Utils.HorzAlignment.Far, false, false, false, acGridView.emTextEditMask.PER2);

            acGridView2.GridType = acGridView.emGridType.LIST;
            acGridView2.AddTextEdit("TYPE", "업체명", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("WORK_1", "1월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView2.AddTextEdit("WORK_2", "2월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView2.AddTextEdit("WORK_3", "3월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView2.AddTextEdit("WORK_4", "4월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView2.AddTextEdit("WORK_5", "5월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView2.AddTextEdit("WORK_6", "6월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView2.AddTextEdit("WORK_7", "7월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView2.AddTextEdit("WORK_8", "8월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView2.AddTextEdit("WORK_9", "9월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView2.AddTextEdit("WORK_10", "10월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView2.AddTextEdit("WORK_11", "11월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView2.AddTextEdit("WORK_12", "12월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView2.AddTextEdit("WORK_SUM", "합계", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView2.AddTextEdit("WORK_RATE", "비율", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.PER2);


            acGridView3.GridType = acGridView.emGridType.LIST;
            acGridView3.AddTextEdit("TYPE", "유형", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView3.AddTextEdit("WORK_1", "1월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView3.AddTextEdit("WORK_2", "2월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView3.AddTextEdit("WORK_3", "3월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView3.AddTextEdit("WORK_4", "4월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView3.AddTextEdit("WORK_5", "5월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView3.AddTextEdit("WORK_6", "6월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView3.AddTextEdit("WORK_7", "7월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView3.AddTextEdit("WORK_8", "8월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView3.AddTextEdit("WORK_9", "9월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView3.AddTextEdit("WORK_10", "10월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView3.AddTextEdit("WORK_11", "11월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView3.AddTextEdit("WORK_12", "12월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView3.AddTextEdit("WORK_SUM", "합계", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView3.AddTextEdit("WORK_RATE", "비율", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.PER2);

            acGridView4.GridType = acGridView.emGridType.LIST;
            acGridView4.AddTextEdit("TYPE", "유형", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView4.AddTextEdit("WORK_1", "1월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView4.AddTextEdit("WORK_2", "2월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView4.AddTextEdit("WORK_3", "3월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView4.AddTextEdit("WORK_4", "4월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView4.AddTextEdit("WORK_5", "5월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView4.AddTextEdit("WORK_6", "6월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView4.AddTextEdit("WORK_7", "7월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView4.AddTextEdit("WORK_8", "8월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView4.AddTextEdit("WORK_9", "9월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView4.AddTextEdit("WORK_10", "10월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView4.AddTextEdit("WORK_11", "11월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView4.AddTextEdit("WORK_12", "12월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView4.AddTextEdit("WORK_SUM", "합계", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView4.AddTextEdit("WORK_RATE", "비율", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.PER2);

            acGridView5.GridType = acGridView.emGridType.LIST;
            acGridView5.AddTextEdit("TYPE", "업체명", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView5.AddTextEdit("WORK_1", "1월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView5.AddTextEdit("WORK_2", "2월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView5.AddTextEdit("WORK_3", "3월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView5.AddTextEdit("WORK_4", "4월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView5.AddTextEdit("WORK_5", "5월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView5.AddTextEdit("WORK_6", "6월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView5.AddTextEdit("WORK_7", "7월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView5.AddTextEdit("WORK_8", "8월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView5.AddTextEdit("WORK_9", "9월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView5.AddTextEdit("WORK_10", "10월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView5.AddTextEdit("WORK_11", "11월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView5.AddTextEdit("WORK_12", "12월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView5.AddTextEdit("WORK_SUM", "합계", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView5.AddTextEdit("WORK_RATE", "비율", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.PER2);

            acDateEdit1.Properties.EditMask = "yyyy";
            acDateEdit2.Properties.EditMask = "yyyy";
            acDateEdit3.Properties.EditMask = "yyyy";
            acDateEdit4.Properties.EditMask = "yyyy";


            acGridView1.CustomColumnSort += acGridView1_CustomColumnSort;

            foreach (acGridColumn col in acGridView1.Columns)
            {
                col.SortMode = ColumnSortMode.Custom;
            }

            acGridView2.CustomColumnSort += acGridView2_CustomColumnSort;

            foreach (acGridColumn col in acGridView2.Columns)
            {
                col.SortMode = ColumnSortMode.Custom;
            }

            //acGridView3.CustomColumnSort += acGridView3_CustomColumnSort;

            //foreach (acGridColumn col in acGridView3.Columns)
            //{
            //    col.SortMode = ColumnSortMode.Custom;
            //}

            //acGridView4.CustomColumnSort += acGridView4_CustomColumnSort;

            //foreach (acGridColumn col in acGridView4.Columns)
            //{
            //    col.SortMode = ColumnSortMode.Custom;
            //}

            acGridView5.CustomColumnSort += acGridView5_CustomColumnSort;

            foreach (acGridColumn col in acGridView5.Columns)
            {
                col.SortMode = ColumnSortMode.Custom;
            }

            base.MenuInit();

        }

        private void acGridView1_CustomColumnSort(object sender, CustomColumnSortEventArgs e)
        {
            try
            {
                acGridView view = sender as acGridView;

                e.Handled = true;

                string key1 = view.GetListSourceRowCellValue(e.ListSourceRowIndex1, "TYPE").ToString();
                string key2 = view.GetListSourceRowCellValue(e.ListSourceRowIndex2, "TYPE").ToString();

                if (key1 == key2)
                {
                    e.Handled = false;
                    return;
                }

                if (key1.Equals("합계"))
                {
                    e.Result = (e.SortOrder == DevExpress.Data.ColumnSortOrder.Ascending ? -1 : 1);
                }
                else if (key2.Equals("합계"))
                {
                    e.Result = (e.SortOrder == DevExpress.Data.ColumnSortOrder.Ascending ? 1 : -1);
                }
                else
                {
                    e.Handled = false;
                }
            }
            catch { }
        }

        private void acGridView2_CustomColumnSort(object sender, CustomColumnSortEventArgs e)
        {
            try
            {
                acGridView view = sender as acGridView;

                e.Handled = true;

                string key1 = view.GetListSourceRowCellValue(e.ListSourceRowIndex1, "TYPE").ToString();
                string key2 = view.GetListSourceRowCellValue(e.ListSourceRowIndex2, "TYPE").ToString();

                if (key1 == key2)
                {
                    e.Handled = false;
                    return;
                }

                if (key1.Equals("합계"))
                {
                    e.Result = (e.SortOrder == DevExpress.Data.ColumnSortOrder.Ascending ? -1 : 1);
                }
                else if (key2.Equals("합계"))
                {
                    e.Result = (e.SortOrder == DevExpress.Data.ColumnSortOrder.Ascending ? 1 : -1);
                }
                else
                {
                    e.Handled = false;
                }
            }
            catch { }
        }

        //private void acGridView3_CustomColumnSort(object sender, CustomColumnSortEventArgs e)
        //{
        //    try
        //    {
        //        acGridView view = sender as acGridView;

        //        e.Handled = true;

        //        string key1 = view.GetListSourceRowCellValue(e.ListSourceRowIndex1, "TYPE").ToString();
        //        string key2 = view.GetListSourceRowCellValue(e.ListSourceRowIndex2, "TYPE").ToString();

        //        if (key1 == key2)
        //        {
        //            e.Handled = false;
        //            return;
        //        }

        //        if (key1.Equals("합계"))
        //        {
        //            e.Result = (e.SortOrder == DevExpress.Data.ColumnSortOrder.Ascending ? -1 : 1);
        //        }
        //        else if (key2.Equals("합계"))
        //        {
        //            e.Result = (e.SortOrder == DevExpress.Data.ColumnSortOrder.Ascending ? 1 : -1);
        //        }
        //        else
        //        {
        //            e.Handled = false;
        //        }
        //    }
        //    catch { }
        //}

        //private void acGridView4_CustomColumnSort(object sender, CustomColumnSortEventArgs e)
        //{
        //    try
        //    {
        //        acGridView view = sender as acGridView;

        //        e.Handled = true;

        //        string key1 = view.GetListSourceRowCellValue(e.ListSourceRowIndex1, "TYPE").ToString();
        //        string key2 = view.GetListSourceRowCellValue(e.ListSourceRowIndex2, "TYPE").ToString();

        //        if (key1 == key2)
        //        {
        //            e.Handled = false;
        //            return;
        //        }

        //        if (key1.Equals("합계"))
        //        {
        //            e.Result = (e.SortOrder == DevExpress.Data.ColumnSortOrder.Ascending ? -1 : 1);
        //        }
        //        else if (key2.Equals("합계"))
        //        {
        //            e.Result = (e.SortOrder == DevExpress.Data.ColumnSortOrder.Ascending ? 1 : -1);
        //        }
        //        else
        //        {
        //            e.Handled = false;
        //        }
        //    }
        //    catch { }
        //}

        private void acGridView5_CustomColumnSort(object sender, CustomColumnSortEventArgs e)
        {
            try
            {
                acGridView view = sender as acGridView;

                e.Handled = true;

                string key1 = view.GetListSourceRowCellValue(e.ListSourceRowIndex1, "TYPE").ToString();
                string key2 = view.GetListSourceRowCellValue(e.ListSourceRowIndex2, "TYPE").ToString();

                if (key1 == key2)
                {
                    e.Handled = false;
                    return;
                }

                if (key1.Equals("합계"))
                {
                    e.Result = (e.SortOrder == DevExpress.Data.ColumnSortOrder.Ascending ? -1 : 1);
                }
                else if (key2.Equals("합계"))
                {
                    e.Result = (e.SortOrder == DevExpress.Data.ColumnSortOrder.Ascending ? 1 : -1);
                }
                else
                {
                    e.Handled = false;
                }
            }
            catch { }
        }

        public override void ChildContainerInit(Control sender)
        {
            //기본값 설정

            if (sender == acLayoutControl1)
            {


                acLayoutControl layout = sender as acLayoutControl;

                layout.GetEditor("YEAR").Value = acDateEdit.GetNowDateFromServer();


            }
            else if (sender == acLayoutControl2)
            {
                acLayoutControl layout = sender as acLayoutControl;

                layout.GetEditor("YEAR").Value = acDateEdit.GetNowDateFromServer();
            }
            else if (sender == acLayoutControl3)
            {
                acLayoutControl layout = sender as acLayoutControl;

                layout.GetEditor("YEAR").Value = acDateEdit.GetNowDateFromServer();
            }
            else if (sender == acLayoutControl4)
            {
                acLayoutControl layout = sender as acLayoutControl;

                layout.GetEditor("YEAR").Value = acDateEdit.GetNowDateFromServer();
            }


            base.ChildContainerInit(sender);
        }


        void Search()
        {
            if (acTabControl1.SelectedTabPage == acTabPage1)
            {
                if (acLayoutControl1.ValidCheck() == false)
                {
                    return;
                }


                DataRow layoutRow = acLayoutControl1.CreateParameterRow();

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("YEAR", typeof(String)); //

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["YEAR"] = layoutRow["YEAR"];
                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);


                BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.LOAD,
                "REP08A_SER", paramSet, "RQSTDT", "RSLTDT",
                QuickSearch,
                QuickException);


            }
            else if (acTabControl1.SelectedTabPage == acTabPage2)
            {
                if (acLayoutControl2.ValidCheck() == false)
                {
                    return;
                }


                DataRow layoutRow = acLayoutControl2.CreateParameterRow();

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("YEAR", typeof(String)); //

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["YEAR"] = layoutRow["YEAR"];
                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);


                BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.LOAD,
                "REP08A_SER2", paramSet, "RQSTDT", "RSLTDT",
                QuickSearch2,
                QuickException);

            }
            else if(acTabControl1.SelectedTabPage == acTabPage3)
            {
                if (acLayoutControl3.ValidCheck() == false)
                {
                    return;
                }


                DataRow layoutRow = acLayoutControl3.CreateParameterRow();

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("YEAR", typeof(String)); //

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["YEAR"] = layoutRow["YEAR"];
                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);


                BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.LOAD,
                "REP08A_SER", paramSet, "RQSTDT", "RSLTDT",
                QuickSearch3,
                QuickException);
            }
            else if (acTabControl1.SelectedTabPage == acTabPage4)
            {
                if (acLayoutControl4.ValidCheck() == false)
                {
                    return;
                }


                DataRow layoutRow = acLayoutControl4.CreateParameterRow();

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("YEAR", typeof(String)); //

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["YEAR"] = layoutRow["YEAR"];
                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);


                BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.LOAD,
                "REP08A_SER3", paramSet, "RQSTDT", "RSLTDT",
                QuickSearch4,
                QuickException);

            }

        }
        void QuickSearch(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                acGridView1.GridControl.DataSource = e.result.Tables["RSLTDT"];


                SetChart(acChartControl1, e.result.Tables["RSLTDT"]);


                base.SetLog(e.executeType, e.result.Tables["RSLTDT"].Rows.Count, e.executeTime);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }
        void QuickSearch3(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                acGridView2.GridControl.DataSource = e.result.Tables["RSLTDT2"];

                base.SetLog(e.executeType, e.result.Tables["RSLTDT"].Rows.Count, e.executeTime);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void QuickSearch4(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                acGridView5.GridControl.DataSource = e.result.Tables["RSLTDT"];

                base.SetLog(e.executeType, e.result.Tables["RSLTDT"].Rows.Count, e.executeTime);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void SetChart(acChartControl ac, DataTable rslt)
        {
            ac.ClearSeries();
            ac.ClearSeriesPoint();

            ac.chartControl.PaletteName = "Metro";//Metro

            ac.chartControl.Legend.AlignmentVertical = LegendAlignmentVertical.TopOutside;
            ac.chartControl.Legend.AlignmentHorizontal = LegendAlignmentHorizontal.Right;
            ac.chartControl.Legend.Direction = LegendDirection.LeftToRight;
            
            //차트 설정
            XYDiagram diagram1 = ac.chartControl.Diagram as XYDiagram;
            if (diagram1 != null)
            {
                diagram1.AxisY.Label.TextPattern = "{V:P2}";
                diagram1.AxisX.Label.Visible = true;
                //diagram1.AxisX.Label.Angle = -30;
                diagram1.AxisY.Interlaced = true;
                diagram1.AxisY.GridLines.Color = ColorTranslator.FromHtml("#8E8E8E"); //Color.WhiteSmoke;
            }

            int i = 0;
            foreach (DataRow row in rslt.Rows)
            {
                if (row["TYPE"].ToString().EndsWith("합계")) continue;

                if (!ac.SeriesDic.ContainsKey(row["TYPE"].ToString()))
                {
                    ac.AddLineSeries(row["TYPE"].ToString()
                            , row["TYPE"].ToString(), "", false, acChartControl.SeriesPointType.PERCENT, DevExpress.XtraCharts.ViewType.Line);

                    Series series = ac.SeriesDic[row["TYPE"].ToString()];
                    series.CrosshairLabelPattern = "{S} : {V:P2}";
                    LineSeriesView lsView = (LineSeriesView)series.View;
                    
                    if (lsView != null)
                    {
                        lsView.MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;
                        lsView.AxisY.Label.TextPattern = "{V:P2}";
                        
                    }
                    series.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
                    PointSeriesLabel psLabel = (PointSeriesLabel)series.Label;
                    psLabel.BackColor = Color.Transparent;
                    psLabel.Border.Visibility = DevExpress.Utils.DefaultBoolean.False;
                    psLabel.Shadow.Visible = false;
                    //psLabel.TextColor = Color.DarkSlateGray;
                    psLabel.ResolveOverlappingMode = ResolveOverlappingMode.Default;
                    psLabel.TextPattern = "{V:P2}";
                    psLabel.Font = new Font("맑은 고딕", 10,
                        FontStyle.Bold, DevExpress.Utils.AppearanceObject.DefaultFont.Unit);

                    SeriesPoint sp = new SeriesPoint("[1월]", new double[] { row["WORK_1_R"].toDouble() });
                    ac.AddSeriesPoint(row["TYPE"].ToString(), sp);

                    SeriesPoint sp2 = new SeriesPoint("[2월]", new double[] { row["WORK_2_R"].toDouble() });
                    ac.AddSeriesPoint(row["TYPE"].ToString(), sp2);

                    SeriesPoint sp3 = new SeriesPoint("[3월]", new double[] { row["WORK_3_R"].toDouble() });
                    ac.AddSeriesPoint(row["TYPE"].ToString(), sp3);

                    SeriesPoint sp4 = new SeriesPoint("[4월]", new double[] { row["WORK_4_R"].toDouble() });
                    ac.AddSeriesPoint(row["TYPE"].ToString(), sp4);

                    SeriesPoint sp5 = new SeriesPoint("[5월]", new double[] { row["WORK_5_R"].toDouble() });
                    ac.AddSeriesPoint(row["TYPE"].ToString(), sp5);

                    SeriesPoint sp6 = new SeriesPoint("[6월]", new double[] { row["WORK_6_R"].toDouble() });
                    ac.AddSeriesPoint(row["TYPE"].ToString(), sp6);

                    SeriesPoint sp7 = new SeriesPoint("[7월]", new double[] { row["WORK_7_R"].toDouble() });
                    ac.AddSeriesPoint(row["TYPE"].ToString(), sp7);

                    SeriesPoint sp8 = new SeriesPoint("[8월]", new double[] { row["WORK_8_R"].toDouble() });
                    ac.AddSeriesPoint(row["TYPE"].ToString(), sp8);

                    SeriesPoint sp9 = new SeriesPoint("[9월]", new double[] { row["WORK_9_R"].toDouble() });
                    ac.AddSeriesPoint(row["TYPE"].ToString(), sp9);

                    SeriesPoint sp10 = new SeriesPoint("[10월]", new double[] { row["WORK_10_R"].toDouble() });
                    ac.AddSeriesPoint(row["TYPE"].ToString(), sp10);

                    SeriesPoint sp11 = new SeriesPoint("[11월]", new double[] { row["WORK_11_R"].toDouble() });
                    ac.AddSeriesPoint(row["TYPE"].ToString(), sp11);

                    SeriesPoint sp12 = new SeriesPoint("[12월]", new double[] { row["WORK_12_R"].toDouble() });
                    ac.AddSeriesPoint(row["TYPE"].ToString(), sp12);

                }
            }
        }

        void QuickSearch2(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                acGridView3.GridControl.DataSource = e.result.Tables["RSLTDT"];
                acGridView4.GridControl.DataSource = e.result.Tables["RSLTDT2"];

                base.SetLog(e.executeType, e.result.Tables["RSLTDT"].Rows.Count, e.executeTime);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }



        void QuickException(object sender, QBiz QBiz, BizManager.BizException ex)
        {




            if (ex.ErrNumber == BizManager.BizException.DATA_REFRESH)
            {
                acMessageBox.Show(this, ex);
                this.DataRefresh(null);
            }
            else
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
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }



    }
}