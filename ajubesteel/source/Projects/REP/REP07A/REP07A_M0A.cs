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
using BizManager;

namespace REP
{
    public sealed partial class REP07A_M0A : BaseMenu
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




        public REP07A_M0A()
        {
            InitializeComponent();

            acBandGridView1.AddTextEdit("END_MONTH", "NO", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.NONE);
            acBandGridView1.AddTextEdit("PART_QTY", "출고(ea)", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.QTY);
            acBandGridView1.AddTextEdit("ACT_QTY", "검사(ea)", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.QTY);
            
            acBandGridView1.AddTextEdit("R_PART_QTY", "수량(ea)", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.QTY, "수정");
            acBandGridView1.AddTextEdit("R_RATE", "%", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.PER2, "수정");
            
            acBandGridView1.AddTextEdit("M_PART_QTY", "수량(ea)", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.QTY, "재가공");
            acBandGridView1.AddTextEdit("M_RATE", "%", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.PER2, "재가공");
            
            acBandGridView1.AddTextEdit("S_PART_QTY", "수량(ea)", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.QTY, "특채");
            acBandGridView1.AddTextEdit("S_RATE", "%", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.PER2, "특채");
            
            acBandGridView1.AddTextEdit("N_PART_QTY", "수량(ea)", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.QTY, "불량율");
            acBandGridView1.AddTextEdit("N_RATE", "%", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.PER2, "불량율");


            acBandGridView2.AddTextEdit("NG_MONTH", "NO", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.NONE);
            acBandGridView2.AddTextEdit("PART_QTY", "출고(ea)", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.QTY);
            acBandGridView2.AddTextEdit("ACT_QTY", "검사(ea)", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.QTY);

            acBandGridView2.AddTextEdit("IN_NG_AMT", "발생(원)", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.QTY, "내부품질비용");
            acBandGridView2.AddTextEdit("IN_NG_RATE", "매출대비", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.PER2, "내부품질비용");

            acBandGridView2.AddTextEdit("OUT_NG_AMT", "발생(원)", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.QTY, "외부품질비용");
            acBandGridView2.AddTextEdit("OUT_NG_RATE", "매출대비", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.PER2, "외부품질비용");

            acBandGridView2.AddTextEdit("SUM_NG_AMT", "발생(원)", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.QTY, "품질비용(합계)");
            acBandGridView2.AddTextEdit("SUM_NG_RATE", "매출대비", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.PER2, "품질비용(합계)");


            acGridView6.GridType = acGridView.emGridType.LIST;
            acGridView6.AddTextEdit("TYPE", "불량유형", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView6.AddTextEdit("WORK_1", "1월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView6.AddTextEdit("WORK_2", "2월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView6.AddTextEdit("WORK_3", "3월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView6.AddTextEdit("WORK_4", "4월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView6.AddTextEdit("WORK_5", "5월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView6.AddTextEdit("WORK_6", "6월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView6.AddTextEdit("WORK_7", "7월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView6.AddTextEdit("WORK_8", "8월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView6.AddTextEdit("WORK_9", "9월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView6.AddTextEdit("WORK_10", "10월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView6.AddTextEdit("WORK_11", "11월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView6.AddTextEdit("WORK_12", "12월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView6.AddTextEdit("WORK_SUM", "합계", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView6.AddTextEdit("WORK_RATE", "비율", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.PER2);

            acGridView7.GridType = acGridView.emGridType.LIST;
            acGridView7.AddTextEdit("TYPE", "불량유형", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView7.AddTextEdit("WORK_1", "1월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView7.AddTextEdit("WORK_2", "2월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView7.AddTextEdit("WORK_3", "3월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView7.AddTextEdit("WORK_4", "4월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView7.AddTextEdit("WORK_5", "5월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView7.AddTextEdit("WORK_6", "6월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView7.AddTextEdit("WORK_7", "7월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView7.AddTextEdit("WORK_8", "8월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView7.AddTextEdit("WORK_9", "9월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView7.AddTextEdit("WORK_10", "10월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView7.AddTextEdit("WORK_11", "11월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView7.AddTextEdit("WORK_12", "12월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView7.AddTextEdit("WORK_SUM", "합계", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView7.AddTextEdit("WORK_RATE", "비율", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.PER2);

            acGridView8.GridType = acGridView.emGridType.LIST;
            acGridView8.AddTextEdit("TYPE", "불량유형", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView8.AddTextEdit("WORK_1", "1월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView8.AddTextEdit("WORK_2", "2월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView8.AddTextEdit("WORK_3", "3월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView8.AddTextEdit("WORK_4", "4월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView8.AddTextEdit("WORK_5", "5월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView8.AddTextEdit("WORK_6", "6월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView8.AddTextEdit("WORK_7", "7월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView8.AddTextEdit("WORK_8", "8월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView8.AddTextEdit("WORK_9", "9월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView8.AddTextEdit("WORK_10", "10월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView8.AddTextEdit("WORK_11", "11월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView8.AddTextEdit("WORK_12", "12월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView8.AddTextEdit("WORK_SUM", "합계", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView8.AddTextEdit("WORK_RATE", "비율", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.PER2);

            acGridView9.GridType = acGridView.emGridType.LIST;
            acGridView9.AddTextEdit("TYPE", "불량유형", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView9.AddTextEdit("WORK_1", "1월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView9.AddTextEdit("WORK_2", "2월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView9.AddTextEdit("WORK_3", "3월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView9.AddTextEdit("WORK_4", "4월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView9.AddTextEdit("WORK_5", "5월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView9.AddTextEdit("WORK_6", "6월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView9.AddTextEdit("WORK_7", "7월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView9.AddTextEdit("WORK_8", "8월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView9.AddTextEdit("WORK_9", "9월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView9.AddTextEdit("WORK_10", "10월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView9.AddTextEdit("WORK_11", "11월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView9.AddTextEdit("WORK_12", "12월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView9.AddTextEdit("WORK_SUM", "합계", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView9.AddTextEdit("WORK_RATE", "비율", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.PER2);


            acGridView3.GridType = acGridView.emGridType.LIST;
            acGridView3.AddTextEdit("TYPE", "구분", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView3.AddTextEdit("WORK_1", "1월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView3.AddTextEdit("WORK_2", "2월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView3.AddTextEdit("WORK_3", "3월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView3.AddTextEdit("WORK_4", "4월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView3.AddTextEdit("WORK_5", "5월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView3.AddTextEdit("WORK_6", "6월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView3.AddTextEdit("WORK_7", "7월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView3.AddTextEdit("WORK_8", "8월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView3.AddTextEdit("WORK_9", "9월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView3.AddTextEdit("WORK_10", "10월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView3.AddTextEdit("WORK_11", "11월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView3.AddTextEdit("WORK_12", "12월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView3.AddTextEdit("WORK_SUM", "합계", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView4.GridType = acGridView.emGridType.LIST;
            acGridView4.AddTextEdit("TYPE", "고객사", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
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

            acLayoutControl1.OnValueKeyDown += new acLayoutControl.ValueKeyDownEventHandler(acLayoutControl1_OnValueKeyDown);

            acDateEdit1.Properties.EditMask = "yyyy";

            acSplitContainerControl7.SplitterPosition = 220;
            acSplitContainerControl8.SplitterPosition = 220;
            acSplitContainerControl9.SplitterPosition = 220;
            acSplitContainerControl10.SplitterPosition = 220;

            acGridView4.CustomColumnSort += acGridView4_CustomColumnSort;

            foreach (acGridColumn col in acGridView4.Columns)
            {
                col.SortMode = ColumnSortMode.Custom;
            }

            acGridView6.CustomColumnSort += acGridView6_CustomColumnSort;

            foreach (acGridColumn col in acGridView6.Columns)
            {
                col.SortMode = ColumnSortMode.Custom;
            }

            acGridView7.CustomColumnSort += acGridView7_CustomColumnSort;

            foreach (acGridColumn col in acGridView7.Columns)
            {
                col.SortMode = ColumnSortMode.Custom;
            }

            acGridView8.CustomColumnSort += acGridView8_CustomColumnSort;

            foreach (acGridColumn col in acGridView8.Columns)
            {
                col.SortMode = ColumnSortMode.Custom;
            }

            acGridView9.CustomColumnSort += acGridView9_CustomColumnSort;

            foreach (acGridColumn col in acGridView9.Columns)
            {
                col.SortMode = ColumnSortMode.Custom;
            }
        }

        private void acGridView6_CustomColumnSort(object sender, CustomColumnSortEventArgs e)
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

                if (key1.Equals("사내 유형별 합계"))
                {
                    e.Result = (e.SortOrder == DevExpress.Data.ColumnSortOrder.Ascending ? -1 : 1);
                }
                else if (key2.Equals("사내 유형별 합계"))
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

        private void acGridView7_CustomColumnSort(object sender, CustomColumnSortEventArgs e)
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

                if (key1.Equals("외주 업체별 합계"))
                {
                    e.Result = (e.SortOrder == DevExpress.Data.ColumnSortOrder.Ascending ? -1 : 1);
                }
                else if (key2.Equals("외주 업체별 합계"))
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

        private void acGridView8_CustomColumnSort(object sender, CustomColumnSortEventArgs e)
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

                if (key1.Equals("납품 현황 합계"))
                {
                    e.Result = (e.SortOrder == DevExpress.Data.ColumnSortOrder.Ascending ? -1 : 1);
                }
                else if (key2.Equals("납품 현황 합계"))
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

        private void acGridView9_CustomColumnSort(object sender, CustomColumnSortEventArgs e)
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

                if (key1.Equals("합  계(원)"))
                {
                    e.Result = (e.SortOrder == DevExpress.Data.ColumnSortOrder.Ascending ? -1 : 1);
                }
                else if (key2.Equals("합  계(원)"))
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

        private void acGridView4_CustomColumnSort(object sender, CustomColumnSortEventArgs e)
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

                if (key1.Equals("사내 유형별 합계"))
                {
                    e.Result = (e.SortOrder == DevExpress.Data.ColumnSortOrder.Ascending ? -1 : 1);
                }
                else if (key2.Equals("사내 유형별 합계"))
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

        void acLayoutControl1_OnValueKeyDown(object sender, IBaseEditControl info, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.Search();
            }
        }
        public override void MenuInit()
        {
            base.MenuInit();
        }

        public override void ChildContainerInit(Control sender)
        {
            //기본값 설정

            if (sender == acLayoutControl1)
            {
                acLayoutControl layout = sender as acLayoutControl;

                layout.GetEditor("YEAR").Value = acDateEdit.GetNowDateFromServer();
            }

            base.ChildContainerInit(sender);
        }


        void Search()
        {

            if (acLayoutControl1.ValidCheck() == false)
            {
                return;
            }

            DataRow layoutRow = acLayoutControl1.CreateParameterRow();

            switch (acTabControl1.GetSelectedContainerName())
            {
                case "N":

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
                    "REP07A_SER", paramSet, "RQSTDT", "RSLTDT",
                    QuickSearch,
                    QuickException);

                    break;

                case "N2":

                    DataTable paramTable2 = new DataTable("RQSTDT");
                    paramTable2.Columns.Add("PLT_CODE", typeof(String)); //
                    paramTable2.Columns.Add("YEAR", typeof(String)); //

                    DataRow paramRow2 = paramTable2.NewRow();
                    paramRow2["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow2["YEAR"] = layoutRow["YEAR"];

                    paramTable2.Rows.Add(paramRow2);
                    DataSet paramSet2 = new DataSet();
                    paramSet2.Tables.Add(paramTable2);

                    BizRun.QBizRun.ExecuteService(
                    this, QBiz.emExecuteType.LOAD,
                    "REP07A_SER2", paramSet2, "RQSTDT", "RSLTDT",
                    QuickSearch2,
                    QuickException);

                    break;

                case "N3":

                    DataTable paramTable3 = new DataTable("RQSTDT");
                    paramTable3.Columns.Add("PLT_CODE", typeof(String)); //
                    paramTable3.Columns.Add("YEAR", typeof(String)); //

                    DataRow paramRow3 = paramTable3.NewRow();
                    paramRow3["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow3["YEAR"] = layoutRow["YEAR"];

                    paramTable3.Rows.Add(paramRow3);
                    DataSet paramSet3 = new DataSet();
                    paramSet3.Tables.Add(paramTable3);

                    BizRun.QBizRun.ExecuteService(
                    this, QBiz.emExecuteType.LOAD,
                    "REP07A_SER3", paramSet3, "RQSTDT", "RSLTDT",
                    QuickSearch3,
                    QuickException);

                    break;
            }

            

        }



        void QuickSearch(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {

                acBandGridView1.GridControl.DataSource = e.result.Tables["RSLTDT"];


                acChartControl1.ClearSeries();
                acChartControl1.ClearSeriesPoint();

                acChartControl1.chartControl.PaletteName = "Metro";//Metro

                acChartControl1.chartControl.Legend.AlignmentVertical = LegendAlignmentVertical.TopOutside;
                acChartControl1.chartControl.Legend.AlignmentHorizontal = LegendAlignmentHorizontal.Right;
                acChartControl1.chartControl.Legend.Direction = LegendDirection.LeftToRight;

                //차트 설정
                XYDiagram diagram1 = acChartControl1.chartControl.Diagram as XYDiagram;
                if (diagram1 != null)
                {
                    diagram1.AxisY.Label.TextPattern = "{V:P2}";
                    diagram1.AxisX.Label.Visible = true;
                    //diagram1.AxisX.Label.Angle = -30;
                    diagram1.AxisY.Interlaced = true;
                    diagram1.AxisY.GridLines.Color = ColorTranslator.FromHtml("#8E8E8E"); //Color.WhiteSmoke;
                }

                int i = 0;
                foreach (DataRow row in e.result.Tables["RSLTDT"].Rows)
                {

                    if (!acChartControl1.SeriesDic.ContainsKey("R_RATE")
                        && !acChartControl1.SeriesDic.ContainsKey("M_RATE"))
                    {
                        acChartControl1.AddLineSeries("R_RATE"
                                , "수정", "", false, acChartControl.SeriesPointType.PERCENT, DevExpress.XtraCharts.ViewType.Line);

                        acChartControl1.AddLineSeries("M_RATE"
                                    , "재가공", "", false, acChartControl.SeriesPointType.PERCENT, DevExpress.XtraCharts.ViewType.Line);

                        Series series = acChartControl1.SeriesDic["R_RATE"];
                        series.CrosshairLabelPattern = "{S} : {V:P2}";

                        LineSeriesView lsView = (LineSeriesView)series.View;

                        if (lsView != null)
                        {
                            //lsView.LineMarkerOptions.Kind = MarkerKind.Circle;
                            lsView.MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;
                            //acChartControl1.chartControl.Series[2].CrosshairLabelPattern = "{S} : {V:F3}";
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


                        Series series2 = acChartControl1.SeriesDic["M_RATE"];
                        series2.CrosshairLabelPattern = "{S} : {V:P2}";

                        LineSeriesView lsView2 = (LineSeriesView)series2.View;

                        if (lsView2 != null)
                        {
                            //lsView2.LineMarkerOptions.Kind = MarkerKind.Circle;
                            lsView2.MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;
                            //acChartControl1.chartControl.Series[2].CrosshairLabelPattern = "{S} : {V:F3}";
                        }
                        series2.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
                        PointSeriesLabel psLabel2 = (PointSeriesLabel)series2.Label;
                        psLabel2.BackColor = Color.Transparent;
                        psLabel2.Border.Visibility = DevExpress.Utils.DefaultBoolean.False;
                        psLabel2.Shadow.Visible = false;
                        //psLabel2.TextColor = Color.DarkSlateGray;
                        psLabel2.ResolveOverlappingMode = ResolveOverlappingMode.Default;
                        psLabel2.TextPattern = "{V:P2}";
                        psLabel2.Font = new Font("맑은 고딕", 10,
                            FontStyle.Bold, DevExpress.Utils.AppearanceObject.DefaultFont.Unit);
                    }

                    SeriesPoint sp = new SeriesPoint("[" + (i + 1).ToString() + "월]", new double[] { row["R_RATE"].toDouble() });
                    acChartControl1.AddSeriesPoint("R_RATE", sp);

                    SeriesPoint sp2 = new SeriesPoint("[" + (i + 1).ToString() + "월]", new double[] { row["M_RATE"].toDouble() });
                    acChartControl1.AddSeriesPoint("M_RATE", sp2);

                    i++;
                }





                acBandGridView2.GridControl.DataSource = e.result.Tables["RSLTDT2"];


                acChartControl2.ClearSeries();
                acChartControl2.ClearSeriesPoint();

                acChartControl2.chartControl.PaletteName = "Metro";//Metro

                acChartControl2.chartControl.Legend.AlignmentVertical = LegendAlignmentVertical.TopOutside;
                acChartControl2.chartControl.Legend.AlignmentHorizontal = LegendAlignmentHorizontal.Right;
                acChartControl2.chartControl.Legend.Direction = LegendDirection.LeftToRight;

                //차트 설정
                XYDiagram diagram2 = acChartControl2.chartControl.Diagram as XYDiagram;
                if (diagram2 != null)
                {
                    diagram2.AxisY.Label.TextPattern = "{V:P2}";
                    diagram2.AxisX.Label.Visible = true;
                    //diagram2.AxisX.Label.Angle = -30;
                    diagram2.AxisY.Interlaced = true;
                    diagram2.AxisY.GridLines.Color = ColorTranslator.FromHtml("#8E8E8E"); //Color.WhiteSmoke;
                }

                int i2 = 0;
                foreach (DataRow row in e.result.Tables["RSLTDT2"].Rows)
                {

                    if (!acChartControl2.SeriesDic.ContainsKey("IN_NG_RATE")
                        && !acChartControl2.SeriesDic.ContainsKey("OUT_NG_RATE"))
                    {
                        acChartControl2.AddLineSeries("IN_NG_RATE"
                                , "내부", "", false, acChartControl.SeriesPointType.PERCENT, DevExpress.XtraCharts.ViewType.Line);

                        acChartControl2.AddLineSeries("OUT_NG_RATE"
                                    , "외부", "", false, acChartControl.SeriesPointType.PERCENT, DevExpress.XtraCharts.ViewType.Line);

                        Series series = acChartControl2.SeriesDic["IN_NG_RATE"];
                        series.CrosshairLabelPattern = "{S} : {V:P2}";

                        LineSeriesView lsView = (LineSeriesView)series.View;

                        if (lsView != null)
                        {
                            //lsView.LineMarkerOptions.Kind = MarkerKind.Circle;
                            lsView.MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;
                            //acChartControl2.chartControl.Series[2].CrosshairLabelPattern = "{S} : {V:F3}";
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


                        Series series2 = acChartControl2.SeriesDic["OUT_NG_RATE"];
                        series2.CrosshairLabelPattern = "{S} : {V:P2}";

                        LineSeriesView lsView2 = (LineSeriesView)series2.View;

                        if (lsView2 != null)
                        {
                            //lsView2.LineMarkerOptions.Kind = MarkerKind.Circle;
                            lsView2.MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;
                            //acChartControl2.chartControl.Series[2].CrosshairLabelPattern = "{S} : {V:F3}";
                        }
                        series2.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
                        PointSeriesLabel psLabel2 = (PointSeriesLabel)series2.Label;
                        psLabel2.BackColor = Color.Transparent;
                        psLabel2.Border.Visibility = DevExpress.Utils.DefaultBoolean.False;
                        psLabel2.Shadow.Visible = false;
                        //psLabel2.TextColor = Color.DarkSlateGray;
                        psLabel2.ResolveOverlappingMode = ResolveOverlappingMode.Default;
                        psLabel2.TextPattern = "{V:P2}";
                        psLabel2.Font = new Font("맑은 고딕", 10,
                            FontStyle.Bold, DevExpress.Utils.AppearanceObject.DefaultFont.Unit);
                    }

                    SeriesPoint sp = new SeriesPoint("[" + (i2 + 1).ToString() + "월]", new double[] { row["IN_NG_RATE"].toDouble() });
                    acChartControl2.AddSeriesPoint("IN_NG_RATE", sp);

                    SeriesPoint sp2 = new SeriesPoint("[" + (i2 + 1).ToString() + "월]", new double[] { row["OUT_NG_RATE"].toDouble() });
                    acChartControl2.AddSeriesPoint("OUT_NG_RATE", sp2);

                    i2++;
                }


                base.SetLog(e.executeType, e.result.Tables["RSLTDT"].Rows.Count, e.executeTime);

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void QuickSearch2(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {

                acGridView6.GridControl.DataSource = e.result.Tables["RSLTDT"];
                acGridView7.GridControl.DataSource = e.result.Tables["RSLTDT2"];
                acGridView8.GridControl.DataSource = e.result.Tables["RSLTDT4"];
                acGridView9.GridControl.DataSource = e.result.Tables["RSLTDT3"];

                SetChart(acChartControl3, e.result.Tables["RSLTDT"]);
                SetChart(acChartControl4, e.result.Tables["RSLTDT2"]);
                SetChart(acChartControl5, e.result.Tables["RSLTDT4"]);
                SetChart(acChartControl6, e.result.Tables["RSLTDT3"]);


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
                diagram1.AxisY.Label.TextPattern = "{V:N0}";
                diagram1.AxisX.Label.Visible = true;
                //diagram1.AxisX.Label.Angle = -30;
                diagram1.AxisY.Interlaced = true;
                diagram1.AxisY.GridLines.Color = ColorTranslator.FromHtml("#8E8E8E"); //Color.WhiteSmoke;
            }

            int i = 0;
            foreach (DataRow row in rslt.Rows)
            {
                if (row["TYPE"].ToString().EndsWith("합계")
                    || row["TYPE"].ToString().EndsWith("계(원)")) continue;

                if (!ac.SeriesDic.ContainsKey(row["TYPE"].ToString()))
                {
                    ac.AddLineSeries(row["TYPE"].ToString()
                            , row["TYPE"].ToString(), "", false, acChartControl.SeriesPointType.NUMBER, DevExpress.XtraCharts.ViewType.Line);

                    Series series = ac.SeriesDic[row["TYPE"].ToString()];

                    LineSeriesView lsView = (LineSeriesView)series.View;

                    if (lsView != null)
                    {
                        //lsView.LineMarkerOptions.Kind = MarkerKind.Circle;
                        lsView.MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;
                        //ac.chartControl.Series[2].CrosshairLabelPattern = "{S} : {V:F3}";
                    }
                    series.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
                    PointSeriesLabel psLabel = (PointSeriesLabel)series.Label;
                    psLabel.BackColor = Color.Transparent;
                    psLabel.Border.Visibility = DevExpress.Utils.DefaultBoolean.False;
                    psLabel.Shadow.Visible = false;
                    //psLabel.TextColor = Color.DarkSlateGray;
                    psLabel.ResolveOverlappingMode = ResolveOverlappingMode.Default;
                    psLabel.TextPattern = "{V:N0}";
                    psLabel.Font = new Font("맑은 고딕", 10,
                        FontStyle.Bold, DevExpress.Utils.AppearanceObject.DefaultFont.Unit);

                    SeriesPoint sp = new SeriesPoint("[1월]", new double[] { row["WORK_1"].toDouble() });
                    ac.AddSeriesPoint(row["TYPE"].ToString(), sp);

                    SeriesPoint sp2 = new SeriesPoint("[2월]", new double[] { row["WORK_2"].toDouble() });
                    ac.AddSeriesPoint(row["TYPE"].ToString(), sp2);

                    SeriesPoint sp3 = new SeriesPoint("[3월]", new double[] { row["WORK_3"].toDouble() });
                    ac.AddSeriesPoint(row["TYPE"].ToString(), sp3);

                    SeriesPoint sp4 = new SeriesPoint("[4월]", new double[] { row["WORK_4"].toDouble() });
                    ac.AddSeriesPoint(row["TYPE"].ToString(), sp4);

                    SeriesPoint sp5 = new SeriesPoint("[5월]", new double[] { row["WORK_5"].toDouble() });
                    ac.AddSeriesPoint(row["TYPE"].ToString(), sp5);

                    SeriesPoint sp6 = new SeriesPoint("[6월]", new double[] { row["WORK_6"].toDouble() });
                    ac.AddSeriesPoint(row["TYPE"].ToString(), sp6);

                    SeriesPoint sp7 = new SeriesPoint("[7월]", new double[] { row["WORK_7"].toDouble() });
                    ac.AddSeriesPoint(row["TYPE"].ToString(), sp7);

                    SeriesPoint sp8 = new SeriesPoint("[8월]", new double[] { row["WORK_8"].toDouble() });
                    ac.AddSeriesPoint(row["TYPE"].ToString(), sp8);

                    SeriesPoint sp9 = new SeriesPoint("[9월]", new double[] { row["WORK_9"].toDouble() });
                    ac.AddSeriesPoint(row["TYPE"].ToString(), sp9);

                    SeriesPoint sp10 = new SeriesPoint("[10월]", new double[] { row["WORK_10"].toDouble() });
                    ac.AddSeriesPoint(row["TYPE"].ToString(), sp10);

                    SeriesPoint sp11 = new SeriesPoint("[11월]", new double[] { row["WORK_11"].toDouble() });
                    ac.AddSeriesPoint(row["TYPE"].ToString(), sp11);

                    SeriesPoint sp12 = new SeriesPoint("[12월]", new double[] { row["WORK_12"].toDouble() });
                    ac.AddSeriesPoint(row["TYPE"].ToString(), sp12);

                }
            }
        }

        void QuickSearch3(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
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