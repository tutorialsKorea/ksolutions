using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ControlManager;
using DevExpress.XtraGrid;
using DevExpress.XtraCharts;
using DevExpress.XtraPivotGrid;
using BizManager;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace REP
{
    public sealed partial class REP03A_M0A : BaseMenu
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

        public REP03A_M0A()
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





        public override void MenuInit()
        {
            acGridView11.GridType = acGridView.emGridType.AUTO_COL;

            acGridView11.AddTextEdit("EMP_NAME", "사원명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView11.AddDateEdit("HIRE_DATE", "입사일자", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emDateMask.SHORT_DATE);

            acGridView11.AddTextEdit("ORG_NAME", "부서명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("IS_DEV", "개발자여부", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("IS_CAM", "CAM작업자여부", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView11.Columns["EMP_NAME"].SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;

            acGridView11.AddHidden("EMP_CODE", typeof(String));

            acGridView11.AddHidden("ORG_CODE", typeof(String));


            acGridView1.AddTextEdit("DLOG_TYPE_NAME", "분류", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("RATE", "비율", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("DLOG_DAY", "수행 소요시간", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.F1);
            acGridView1.AddTextEdit("DLOG_PLAN_DAY", "계획 소요시간", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.F1);

            acGridView2.AddTextEdit("RELATED_PROD_NAME", "직   무", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("RATE", "비율", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("DLOG_DAY", "수행 소요시간", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.F1);
            acGridView2.AddTextEdit("DLOG_PLAN_DAY", "계획 소요시간", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.F1);
            acGridView2.AddTextEdit("ROW_RATE", "계획대비 실적", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView3.AddTextEdit("CONTENTS", "세부 직무 내용", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView3.AddTextEdit("RATE", "비율", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView3.AddTextEdit("DLOG_DAY", "수행 소요시간", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.F1);
            acGridView3.AddTextEdit("DLOG_PLAN_DAY", "계획 소요시간", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.F1);
            acGridView3.AddTextEdit("ROW_RATE", "계획대비 실적", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);


            acGridView4.AddTextEdit("DLOG_TYPE_NAME", "분류", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView4.AddTextEdit("RATE", "비율", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView4.AddTextEdit("DLOG_DAY", "수행 소요시간", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.F1);
            acGridView4.AddTextEdit("DLOG_PLAN_DAY", "계획 소요시간", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.F1);

            acGridView5.AddTextEdit("RELATED_PROD_NAME", "직   무", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView5.AddTextEdit("RATE", "비율", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView5.AddTextEdit("DLOG_DAY", "수행 소요시간", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.F1);
            acGridView5.AddTextEdit("DLOG_PLAN_DAY", "계획 소요시간", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.F1);
            acGridView5.AddTextEdit("ROW_RATE", "계획대비 실적", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView6.AddTextEdit("CONTENTS", "세부 직무 내용", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView6.AddTextEdit("RATE", "비율", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView6.AddTextEdit("DLOG_DAY", "수행 소요시간", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.F1);
            acGridView6.AddTextEdit("DLOG_PLAN_DAY", "계획 소요시간", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.F1);
            acGridView6.AddTextEdit("ROW_RATE", "계획대비 실적", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);


            acGridView7.AddTextEdit("DLOG_TYPE_NAME", "분류", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView7.AddTextEdit("RATE", "비율", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView7.AddTextEdit("DLOG_DAY", "수행 소요시간", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.F1);
            acGridView7.AddTextEdit("DLOG_PLAN_DAY", "계획 소요시간", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.F1);

            acGridView8.AddTextEdit("RELATED_PROD_NAME", "직   무", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView8.AddTextEdit("RATE", "비율", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView8.AddTextEdit("DLOG_DAY", "수행 소요시간", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.F1);
            acGridView8.AddTextEdit("DLOG_PLAN_DAY", "계획 소요시간", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.F1);
            acGridView8.AddTextEdit("ROW_RATE", "계획대비 실적", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView9.AddTextEdit("CONTENTS", "세부 직무 내용", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView9.AddTextEdit("RATE", "비율", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView9.AddTextEdit("DLOG_DAY", "수행 소요시간", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.F1);
            acGridView9.AddTextEdit("DLOG_PLAN_DAY", "계획 소요시간", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.F1);
            acGridView9.AddTextEdit("ROW_RATE", "계획대비 실적", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView10.GridType = acGridView.emGridType.LIST;
            acGridView10.AddTextEdit("ORG_NAME", "구분", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView10.AddTextEdit("WORK_1", "1월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.F1);
            acGridView10.AddTextEdit("WORK_2", "2월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.F1);
            acGridView10.AddTextEdit("WORK_3", "3월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.F1);
            acGridView10.AddTextEdit("WORK_4", "4월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.F1);
            acGridView10.AddTextEdit("WORK_5", "5월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.F1);
            acGridView10.AddTextEdit("WORK_6", "6월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.F1);
            acGridView10.AddTextEdit("WORK_7", "7월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.F1);
            acGridView10.AddTextEdit("WORK_8", "8월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.F1);
            acGridView10.AddTextEdit("WORK_9", "9월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.F1);
            acGridView10.AddTextEdit("WORK_10", "10월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.F1);
            acGridView10.AddTextEdit("WORK_11", "11월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.F1);
            acGridView10.AddTextEdit("WORK_12", "12월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.F1);
            acGridView10.AddTextEdit("WORK_SUM", "합계", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.F1);


            acGridView11.FocusedRowChanged += acGridView11_FocusedRowChanged;

            acGridView1.CustomDrawCell += acGridView_CustomDrawCell;
            acGridView2.CustomDrawCell += acGridView_CustomDrawCell;
            acGridView3.CustomDrawCell += acGridView_CustomDrawCell;
            acGridView4.CustomDrawCell += acGridView_CustomDrawCell;
            acGridView5.CustomDrawCell += acGridView_CustomDrawCell;
            acGridView6.CustomDrawCell += acGridView_CustomDrawCell;
            acGridView7.CustomDrawCell += acGridView_CustomDrawCell;
            acGridView8.CustomDrawCell += acGridView_CustomDrawCell;
            acGridView9.CustomDrawCell += acGridView_CustomDrawCell;

            acGridView1.OptionsView.AllowCellMerge = true;
            acGridView2.OptionsView.AllowCellMerge = true;
            acGridView3.OptionsView.AllowCellMerge = true;
            acGridView4.OptionsView.AllowCellMerge = true;
            acGridView5.OptionsView.AllowCellMerge = true;
            acGridView6.OptionsView.AllowCellMerge = true;
            acGridView7.OptionsView.AllowCellMerge = true;
            acGridView8.OptionsView.AllowCellMerge = true;
            acGridView9.OptionsView.AllowCellMerge = true;

            acGridView10.OptionsView.AllowCellMerge = true; 

            acDateEdit4.Properties.EditMask = "yyyy-MM";
            acDateEdit5.Properties.EditMask = "yyyy";
            dtpDATE1.Properties.EditMask = "yyyy";

            acGridView11.ShowGridMenuEx += acGridView11_ShowGridMenuEx;

            acWeekDate1.WeekType = acWeekDate.emWeekType.MonToSun;
            acWeekDate1.SetWeekOnly();
            acWeekDate1.SetType(acWeekDate.DateType.WEEK);
            acWeekDate1.SetWeekNoRule(DevExpress.XtraEditors.Controls.WeekNumberRule.FirstFourDayWeek);

            acWeekDate1.OnPrevButtonClick += acWeekDate1_OnPrevButtonClick;
            acWeekDate1.OnNextButtonClick += acWeekDate1_OnNextButtonClick;

            acWeekDate1.OnStartDateEnter += acWeekDate1_OnStartDateEnter;
            acWeekDate1.OnEndDateEnter += acWeekDate1_OnEndDateEnter;

            base.MenuInit();
        }

        private void acWeekDate1_OnStartDateEnter()
        {
            acGridView11_FocusedRowChanged(null, null);
        }

        private void acWeekDate1_OnEndDateEnter()
        {
            acGridView11_FocusedRowChanged(null, null);
        }

        private void acWeekDate1_OnPrevButtonClick()
        {
            acGridView11_FocusedRowChanged(null, null);
        }

        private void acWeekDate1_OnNextButtonClick()
        {
            acGridView11_FocusedRowChanged(null, null);
        }

        void acGridView11_ShowGridMenuEx(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            acGridView view = sender as acGridView;

            DataRow focusRow = view.GetFocusedDataRow();

            if (e.MenuType == GridMenuType.User)
            {
                acBarButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                acBarButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
            else if (e.MenuType == GridMenuType.Row)
            {
                if (e.HitInfo.RowHandle >= 0)
                {
                    if (focusRow["IS_CAM"].ToString() == "1")
                    {
                        acBarButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    }
                    else
                    {
                        acBarButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    }

                    if (focusRow["IS_DEV"].ToString() == "1")
                    {
                        acBarButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    }
                    else
                    {
                        acBarButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    }

                }
                else
                {
                    acBarButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    acBarButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

                }
            }


            if (e.HitInfo.HitTest == GridHitTest.Row || e.HitInfo.HitTest == GridHitTest.RowCell)
            {

                GridHitInfo hitInfo = view.CalcHitInfo(e.Point);

                popupMenu1.ShowPopup(view.GridControl.PointToScreen(e.Point));


            }
        }

        private void acGridView_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            acGridView gridView = sender as acGridView;

            if (gridView.Name == "acGridView1"
                || gridView.Name == "acGridView4"
                || gridView.Name == "acGridView7")
            {
                string type = gridView.GetRowCellValue(e.RowHandle, "DLOG_TYPE_NAME").toStringEmpty();

                if (type == "합계")
                {
                    e.Appearance.BackColor = Color.LightGray;
                    e.Appearance.Font = new Font(e.Appearance.Font.Name, e.Appearance.Font.Size, FontStyle.Bold);
                }
            }

            if (gridView.Name == "acGridView2"
                || gridView.Name == "acGridView5"
                || gridView.Name == "acGridView8")
            {
                string type = gridView.GetRowCellValue(e.RowHandle, "RELATED_PROD").toStringEmpty();

                if (type == "합계")
                {
                    e.Appearance.BackColor = Color.LightGray;
                    e.Appearance.Font = new Font(e.Appearance.Font.Name, e.Appearance.Font.Size, FontStyle.Bold);
                }
            }

            if (gridView.Name == "acGridView3"
                || gridView.Name == "acGridView6"
                || gridView.Name == "acGridView9")
            {
                string type = gridView.GetRowCellValue(e.RowHandle, "CONTENTS").toStringEmpty();

                if (type == "합계")
                {
                    e.Appearance.BackColor = Color.LightGray;
                    e.Appearance.Font = new Font(e.Appearance.Font.Name, e.Appearance.Font.Size, FontStyle.Bold);
                }
            }
        }

        private void acGridView11_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow focusRow = acGridView11.GetFocusedDataRow();

            if (focusRow == null)
            {
                return;
            }

            switch (acTabControl1.GetSelectedContainerName())
            {
                case "WEEK":

                    DataRow layoutRow = acLayoutControl1.CreateParameterRow();

                    DataRow weekRow = acWeekDate1.WeekRow;

                    DataTable paramTable = new DataTable("RQSTDT");
                    paramTable.Columns.Add("PLT_CODE", typeof(String));
                    paramTable.Columns.Add("S_DATE", typeof(String));
                    paramTable.Columns.Add("E_DATE", typeof(String));
                    paramTable.Columns.Add("EMP_CODE", typeof(String));

                    DataRow paramRow = paramTable.NewRow();
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    //paramRow["S_DATE"] = layoutRow["S_DATE"];
                    //paramRow["E_DATE"] = layoutRow["E_DATE"];

                    paramRow["S_DATE"] = weekRow["START_TIME"].toDateString("yyyyMMdd");
                    paramRow["E_DATE"] = weekRow["END_TIME"].toDateString("yyyyMMdd");

                    paramRow["EMP_CODE"] = focusRow["EMP_CODE"];

                    paramTable.Rows.Add(paramRow);
                    DataSet paramSet = new DataSet();
                    paramSet.Tables.Add(paramTable);

                    BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD_DETAIL, "REP03A_SER3", paramSet, "RQSTDT", "RSLTDT",
                       QuickDaySearch,
                       QuickException);

                    break;

                case "MONTH":

                    DataRow layoutRow2 = acLayoutControl2.CreateParameterRow();

                    DataTable paramTable2 = new DataTable("RQSTDT");
                    paramTable2.Columns.Add("PLT_CODE", typeof(String));
                    paramTable2.Columns.Add("MONTH", typeof(String));
                    paramTable2.Columns.Add("EMP_CODE", typeof(String));

                    DataRow paramRow2 = paramTable2.NewRow();
                    paramRow2["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow2["MONTH"] = layoutRow2["MONTH"];
                    paramRow2["EMP_CODE"] = focusRow["EMP_CODE"];

                    paramTable2.Rows.Add(paramRow2);
                    DataSet paramSet2 = new DataSet();
                    paramSet2.Tables.Add(paramTable2);

                    BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD_DETAIL, "REP03A_SER4", paramSet2, "RQSTDT", "RSLTDT",
                       QuickMonthSearch,
                       QuickException);

                    break;

                case "YEAR":

                    DataRow layoutRow3 = acLayoutControl3.CreateParameterRow();

                    DataTable paramTable3 = new DataTable("RQSTDT");
                    paramTable3.Columns.Add("PLT_CODE", typeof(String));
                    paramTable3.Columns.Add("YEAR", typeof(String));
                    paramTable3.Columns.Add("EMP_CODE", typeof(String));

                    DataRow paramRow3 = paramTable3.NewRow();
                    paramRow3["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow3["YEAR"] = layoutRow3["YEAR"];
                    paramRow3["EMP_CODE"] = focusRow["EMP_CODE"];

                    paramTable3.Rows.Add(paramRow3);
                    DataSet paramSet3 = new DataSet();
                    paramSet3.Tables.Add(paramTable3);

                    BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD_DETAIL, "REP03A_SER5", paramSet3, "RQSTDT", "RSLTDT",
                       QuickYearSearch,
                       QuickException);

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

        public override void ChildContainerInit(Control sender)
        {
            //기본값 설정

            if (sender == acLayoutControl1)
            {
                acLayoutControl layout = sender as acLayoutControl;

                //layout.GetEditor("S_DATE").Value = acDateEdit.GetNowDateFromServer();
                //layout.GetEditor("E_DATE").Value = acDateEdit.GetNowDateFromServer();

            }
            else if (sender == acLayoutControl2)
            {
                acLayoutControl layout = sender as acLayoutControl;

                layout.GetEditor("MONTH").Value = acDateEdit.GetNowDateFromServer();

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


        void QuickException(object sender, QBiz QBiz, BizManager.BizException ex)
        {
            acMessageBox.Show(this, ex);

        }

        void Search()
        {
            switch (acTabControl2.GetSelectedContainerName())
            {
                case "D":

                    DataRow layoutRow = acLayoutControl5.CreateParameterRow();

                    DataTable paramTable = new DataTable("RQSTDT");
                    paramTable.Columns.Add("PLT_CODE", typeof(String));
                    //paramTable.Columns.Add("ORG_CODE", typeof(String));
                    //paramTable.Columns.Add("EMP_CODE", typeof(String)); 
                    paramTable.Columns.Add("IS_RETIRE", typeof(String)); 

                    DataRow paramRow = paramTable.NewRow();
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    //paramRow["ORG_CODE"] = layoutRow["ORG_CODE"];
                    //paramRow["EMP_CODE"] = layoutRow["EMP_CODE"]; 

                    paramRow["IS_RETIRE"] = layoutRow["IS_RETIRE"];

                    if (acCheckEdit1.Checked)
                    {
                        paramRow["IS_RETIRE"] = null;
                    }

                    paramTable.Rows.Add(paramRow);
                    DataSet paramSet = new DataSet();
                    paramSet.Tables.Add(paramTable);

                    BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD, "REP03A_SER", paramSet, "RQSTDT", "RSLTDT",
                       QuickSearch,
                       QuickException);

                    break;

                case "W":

                    DataRow layoutRow4 = acLayoutControl4.CreateParameterRow();

                    DataTable paramTable4 = new DataTable("RQSTDT");
                    paramTable4.Columns.Add("PLT_CODE", typeof(String));
                    paramTable4.Columns.Add("YEAR", typeof(String));


                    DataRow paramRow4 = paramTable4.NewRow();
                    paramRow4["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow4["YEAR"] = layoutRow4["YEAR"];

                    paramTable4.Rows.Add(paramRow4);
                    DataSet paramSet4 = new DataSet();
                    paramSet4.Tables.Add(paramTable4);

                    BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD, "REP03A_SER2", paramSet4, "RQSTDT", "RSLTDT",
                       QuickWorkSearch,
                       QuickException);

                    break;
                
            }

            //DataRow layoutRow = acLayoutControl1.CreateParameterRow();

            //List<acDateEdit.StartEndDateTime> splitDate = acDateEdit.SplitDateTime(acLayoutControl1.GetEditor("S_DATE").Value.toDateTime(),
            //                                            acLayoutControl1.GetEditor("E_DATE").Value.toDateTime(), 30);



            //List<DataSet> paramSets = new List<DataSet>();

            //foreach (acDateEdit.StartEndDateTime spDate in splitDate)
            //{
            //    DataTable paramTable = new DataTable("RQSTDT");
            //    paramTable.Columns.Add("PLT_CODE", typeof(String)); //플랜트 코드
            //    paramTable.Columns.Add("S_PLN_DATE", typeof(String));
            //    paramTable.Columns.Add("E_PLN_DATE", typeof(String));
            //    paramTable.Columns.Add("S_WORK_DATE", typeof(String));
            //    paramTable.Columns.Add("E_WORK_DATE", typeof(String));
            //    paramTable.Columns.Add("S_END_DATE", typeof(String));
            //    paramTable.Columns.Add("E_END_DATE", typeof(String));
            //    paramTable.Columns.Add("PROD_CODE", typeof(String)); //금형코드


            //    DataRow paramRow = paramTable.NewRow();

            //    paramRow["PLT_CODE"] = acInfo.PLT_CODE;

            //    foreach (string checkedKey in acCheckedComboBoxEdit4.GetKeyChecked())
            //    {
            //        switch (checkedKey)
            //        {
            //            case "PLN_DATE":

            //                paramRow["S_PLN_DATE"] = spDate.StartDate.toDateString("yyyyMMdd");
            //                paramRow["E_PLN_DATE"] = spDate.EndDate.toDateString("yyyyMMdd");

            //                break;

            //            case "WORK_DATE":

            //                paramRow["S_WORK_DATE"] = spDate.StartDate.toDateString("yyyyMMdd");
            //                paramRow["E_WORK_DATE"] = spDate.EndDate.toDateString("yyyyMMdd");

            //                break;


            //            case "END_DATE":

            //                paramRow["S_END_DATE"] = spDate.StartDate.toDateString("yyyyMMdd");
            //                paramRow["E_END_DATE"] = spDate.EndDate.toDateString("yyyyMMdd");

            //                break;

            //        }

            //    }

            //    paramRow["PROD_CODE"] = layoutRow["PROD_CODE"];

            //    paramTable.Rows.Add(paramRow);
            //    DataSet paramSet = new DataSet();
            //    paramSet.Tables.Add(paramTable);

            //    paramSets.Add(paramSet);


            //}

            //if (paramSets.Count > 0)
            //{
            //    BizRun.QBizRun.ExecuteMultiService(
            //    this, QBiz.emExecuteType.LOAD,
            //    "REP03A_SER4", paramSets, "RQSTDT", "RSLTDT",
            //    QuickMultiSearch,
            //    QuickMultiException);

            //}
        }
        void QuickMultiException(object sender, QBizMulti QBiz, BizManager.BizException ex)
        {

            acMessageBox.Show(this, ex);

        }


        void QuickMultiSearch(object sender, QBizMulti QBizMulti, QBizMulti.ExcuteCompleteArgs e)
        {


            base.SetLog(e.executeType, e.result.Tables["RSLTDT"].Rows.Count, e.executeTime);

        }

        void QuickSearch(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                acGridView11.GridControl.DataSource = e.result.Tables["RSLTDT"];
                acGridView11.BestFitColumns();
                base.SetLog(e.executeType, e.result.Tables["RSLTDT"].Rows.Count, e.executeTime);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void QuickDaySearch(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                acGridView1.GridControl.DataSource = e.result.Tables["RSLTDT"];
                acGridView1.Columns[0].Width = 120;
                acGridView1.Columns[1].Width = 100;
                acGridView1.Columns[2].Width = 150;
                acGridView1.Columns[3].Width = 150;
                //acGridView4.BestFitColumns();

                acGridView2.GridControl.DataSource = e.result.Tables["RSLTDT2"];
                acGridView2.Columns[0].Width = 200;
                acGridView2.Columns[1].Width = 100;
                acGridView2.Columns[2].Width = 150;
                acGridView2.Columns[3].Width = 150;
                acGridView2.Columns[3].Width = 150;
                //acGridView5.BestFitColumns();

                acGridView3.GridControl.DataSource = e.result.Tables["RSLTDT3"];
                acGridView3.Columns[0].Width = 300;
                acGridView3.Columns[1].Width = 100;
                acGridView3.Columns[2].Width = 150;
                acGridView3.Columns[3].Width = 150;
                acGridView3.Columns[3].Width = 150;
                //acGridView6.BestFitColumns();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void QuickMonthSearch(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                acGridView4.GridControl.DataSource = e.result.Tables["RSLTDT"];
                acGridView4.Columns[0].Width = 120;
                acGridView4.Columns[1].Width = 100;
                acGridView4.Columns[2].Width = 150;
                acGridView4.Columns[3].Width = 150;
                //acGridView4.BestFitColumns();

                acGridView5.GridControl.DataSource = e.result.Tables["RSLTDT2"];
                acGridView5.Columns[0].Width = 200;
                acGridView5.Columns[1].Width = 100;
                acGridView5.Columns[2].Width = 150;
                acGridView5.Columns[3].Width = 150;
                acGridView5.Columns[3].Width = 150;
                //acGridView5.BestFitColumns();

                acGridView6.GridControl.DataSource = e.result.Tables["RSLTDT3"];
                acGridView6.Columns[0].Width = 300;
                acGridView6.Columns[1].Width = 100;
                acGridView6.Columns[2].Width = 150;
                acGridView6.Columns[3].Width = 150;
                acGridView6.Columns[3].Width = 150;
                //acGridView6.BestFitColumns();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void QuickYearSearch(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                acGridView7.GridControl.DataSource = e.result.Tables["RSLTDT"];
                acGridView7.Columns[0].Width = 120;
                acGridView7.Columns[1].Width = 100;
                acGridView7.Columns[2].Width = 150;
                acGridView7.Columns[3].Width = 150;
                //acGridView4.BestFitColumns();

                acGridView8.GridControl.DataSource = e.result.Tables["RSLTDT2"];
                acGridView8.Columns[0].Width = 200;
                acGridView8.Columns[1].Width = 100;
                acGridView8.Columns[2].Width = 150;
                acGridView8.Columns[3].Width = 150;
                acGridView8.Columns[4].Width = 150;
                //acGridView5.BestFitColumns();

                acGridView9.GridControl.DataSource = e.result.Tables["RSLTDT3"];
                acGridView9.Columns[0].Width = 300;
                acGridView9.Columns[1].Width = 100;
                acGridView9.Columns[2].Width = 150;
                acGridView9.Columns[3].Width = 150;
                acGridView9.Columns[4].Width = 150;
                //acGridView6.BestFitColumns();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void QuickWorkSearch(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
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
                    diagram1.AxisY.Label.TextPattern = "{V:N1}";
                    diagram1.AxisX.Label.Visible = true;
                    //diagram1.AxisX.Label.Angle = -30;
                    diagram1.AxisY.Interlaced = true;
                    diagram1.AxisY.GridLines.Color = ColorTranslator.FromHtml("#8E8E8E"); //Color.WhiteSmoke;
                }

                foreach (DataRow row in e.result.Tables["RSLTDT"].Rows)
                {
                    if (!acChartControl1.SeriesDic.ContainsKey(row["ORG_NAME"].ToString()))
                    {
                        acChartControl1.AddLineSeries(row["ORG_NAME"].ToString()
                                , row["ORG_NAME"].ToString(), "", false, acChartControl.SeriesPointType.NUMBER, DevExpress.XtraCharts.ViewType.Line);

                        Series series = acChartControl1.SeriesDic[row["ORG_NAME"].ToString()];
                        series.CrosshairLabelPattern = "{S} : {V:N1}";
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
                        psLabel.TextPattern = "{V:N1}";
                        psLabel.Font = new Font("맑은 고딕", 10,
                            FontStyle.Bold, DevExpress.Utils.AppearanceObject.DefaultFont.Unit);

                        SeriesPoint sp = new SeriesPoint("[1월]", new double[] { row["WORK_1"].toDouble() });
                        acChartControl1.AddSeriesPoint(row["ORG_NAME"].ToString(), sp);

                        SeriesPoint sp2 = new SeriesPoint("[2월]", new double[] { row["WORK_2"].toDouble() });
                        acChartControl1.AddSeriesPoint(row["ORG_NAME"].ToString(), sp2);

                        SeriesPoint sp3 = new SeriesPoint("[3월]", new double[] { row["WORK_3"].toDouble() });
                        acChartControl1.AddSeriesPoint(row["ORG_NAME"].ToString(), sp3);

                        SeriesPoint sp4 = new SeriesPoint("[4월]", new double[] { row["WORK_4"].toDouble() });
                        acChartControl1.AddSeriesPoint(row["ORG_NAME"].ToString(), sp4);

                        SeriesPoint sp5 = new SeriesPoint("[5월]", new double[] { row["WORK_5"].toDouble() });
                        acChartControl1.AddSeriesPoint(row["ORG_NAME"].ToString(), sp5);

                        SeriesPoint sp6 = new SeriesPoint("[6월]", new double[] { row["WORK_6"].toDouble() });
                        acChartControl1.AddSeriesPoint(row["ORG_NAME"].ToString(), sp6);

                        SeriesPoint sp7 = new SeriesPoint("[7월]", new double[] { row["WORK_7"].toDouble() });
                        acChartControl1.AddSeriesPoint(row["ORG_NAME"].ToString(), sp7);

                        SeriesPoint sp8 = new SeriesPoint("[8월]", new double[] { row["WORK_8"].toDouble() });
                        acChartControl1.AddSeriesPoint(row["ORG_NAME"].ToString(), sp8);

                        SeriesPoint sp9 = new SeriesPoint("[9월]", new double[] { row["WORK_9"].toDouble() });
                        acChartControl1.AddSeriesPoint(row["ORG_NAME"].ToString(), sp9);

                        SeriesPoint sp10 = new SeriesPoint("[10월]", new double[] { row["WORK_10"].toDouble() });
                        acChartControl1.AddSeriesPoint(row["ORG_NAME"].ToString(), sp10);

                        SeriesPoint sp11 = new SeriesPoint("[11월]", new double[] { row["WORK_11"].toDouble() });
                        acChartControl1.AddSeriesPoint(row["ORG_NAME"].ToString(), sp11);

                        SeriesPoint sp12 = new SeriesPoint("[12월]", new double[] { row["WORK_12"].toDouble() });
                        acChartControl1.AddSeriesPoint(row["ORG_NAME"].ToString(), sp12);

                    }
                }

                acGridView10.GridControl.DataSource = e.result.Tables["RSLTDT"];
                acGridView10.BestFitColumns();
                base.SetLog(e.executeType, e.result.Tables["RSLTDT"].Rows.Count, e.executeTime);
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
                switch (acTabControl2.GetSelectedContainerName())
                {
                    case "D":
                        this.Search();
                        break;

                    case "W":
                        this.Search();
                        break;
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }


        void Search2()
        {

        }

        private void acBarButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                //생산실적으로 이동
                DataRow focusRow = acGridView11.GetFocusedDataRow();

                if (focusRow != null)
                {
                    Main.MoveLinkMenu("REP05A", focusRow);
                }
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
                //개발현황으로 이동
                DataRow focusRow = acGridView11.GetFocusedDataRow();

                if (focusRow != null)
                {
                    Main.MoveLinkMenu("REP04A", focusRow);
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }
    }
}
