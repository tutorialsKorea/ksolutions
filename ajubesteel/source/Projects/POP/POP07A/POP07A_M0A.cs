using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

using DevExpress.XtraPivotGrid;
using ControlManager;
using BizManager;
using DevExpress.XtraCharts;
using DevExpress.Data;
using DevExpress.XtraGrid;

namespace POP
{
    public sealed partial class POP07A_M0A : BaseMenu
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


        public POP07A_M0A()
        {
            InitializeComponent();

            acLayoutControl1.OnValueChanged+=new acLayoutControl.ValueChangedEventHandler(acLayoutControl1_OnValueChanged);
            acLayoutControl1.OnValueKeyDown += new acLayoutControl.ValueKeyDownEventHandler(acLayoutControl1_OnValueKeyDown);

            acGridView1.CellMerge += new DevExpress.XtraGrid.Views.Grid.CellMergeEventHandler(acGridView1_CellMerge);

            acGridView1.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(acGridView1_CustomDrawCell);

            acGridView1.MouseDown += new MouseEventHandler(acGridView1_MouseDown);

            acGridView1.CustomSummaryCalculate += acGridView1_CustomSummaryCalculate;
        }
       
        void acGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            //if (e.Clicks == 2 && e.Button == MouseButtons.Left)
            //{
            //    DateTime dtStart = (acLayoutControl1.GetEditor("YEAR_MONTH").Editor as acDateEdit).GetFirstDate();
            //    DateTime dtEnd = (acLayoutControl1.GetEditor("YEAR_MONTH").Editor as acDateEdit).GetLastDate();

            //    string mc_code = acGridView1.GetFocusedDataRow()["MC_CODE"].ToString();

            //    //Main.MoveMenu("POP74A",new object[] {dtStart,dtEnd, mc_code});
            //}
        }

        void acGridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            //if (e.Column.FieldName != "GUBUN" && acGridView1.RowCount != (e.RowHandle + 1))
            //{
            //    string val = acGridView1.GetRowCellValue(e.RowHandle, "MC_NAME").ToString();

            //    if (val == "계")
            //        e.Appearance.BackColor = Color.LightGray;
            //}
            //else if (acGridView1.RowCount == (e.RowHandle + 1))
            //{
            //    e.Appearance.BackColor = Color.DimGray;
            //    e.Appearance.ForeColor = Color.White;
            //}

        }

        void acGridView1_CellMerge(object sender, DevExpress.XtraGrid.Views.Grid.CellMergeEventArgs e)
        {
            if (e.Column.FieldName == "GUBUN")
            {
                string value1 = acGridView1.GetRowCellValue(e.RowHandle1,e.Column).ToString();
                string value2 = acGridView1.GetRowCellValue(e.RowHandle2,e.Column).ToString();

                e.Merge = value1 == value2;
            }
        }

        void acLayoutControl1_OnValueKeyDown(object sender, IBaseEditControl info, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.Search();
            }
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
            acGridView1.GridType = acGridView.emGridType.LIST;

            acGridView1.AddTextEdit("MC_GROUP", "설비그룹코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);


            acGridView1.AddTextEdit("MC_GROUP_NAME", "설비그룹명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("CAPA", "조업시간", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView1.Columns["CAPA"].SummaryItem.SetSummary(DevExpress.Data.SummaryItemType.Sum,acGridView1.Columns["CAPA"].DisplayFormat.FormatString);

            acGridView1.AddTextEdit("ACT_TIME", "가동시간", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView1.Columns["ACT_TIME"].SummaryItem.SetSummary(DevExpress.Data.SummaryItemType.Sum, acGridView1.Columns["ACT_TIME"].DisplayFormat.FormatString);

            //acGridView1.AddTextEdit("READY_TIME", "비가동시간\n\r(준비)", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            //acGridView1.Columns["READY_TIME"].SummaryItem.SetSummary(DevExpress.Data.SummaryItemType.Sum, acGridView1.Columns["READY_TIME"].DisplayFormat.FormatString);

            acGridView1.AddTextEdit("NONE_TIME", "유실공수", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView1.Columns["NONE_TIME"].SummaryItem.SetSummary(DevExpress.Data.SummaryItemType.Sum, acGridView1.Columns["NONE_TIME"].DisplayFormat.FormatString);

            acGridView1.AddTextEdit("ACT_RATE", "부하율", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.PER2);
            acGridView1.Columns["ACT_RATE"].SummaryItem.SetSummary(DevExpress.Data.SummaryItemType.Custom, acGridView1.Columns["ACT_RATE"].DisplayFormat.FormatString);
            acGridView1.Columns["ACT_RATE"].SummaryItem.Tag = 1;

            //acGridView1.AddTextEdit("RDY_RATE", "부하율\r\n(준비포함)", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.PER2);
            //acGridView1.Columns["RDY_RATE"].SummaryItem.SetSummary(DevExpress.Data.SummaryItemType.Custom, acGridView1.Columns["RDY_RATE"].DisplayFormat.FormatString);
            //acGridView1.Columns["RDY_RATE"].SummaryItem.Tag = 2;

            acGridView1.ColumnPanelRowHeight = 45;

            acGridView1.OptionsView.ShowFooter = true;

            //RepositoryItemDesInfo


            //acCheckedComboBoxEdit1.AddItem("작업일", true, "40540", "WORK_DATE", true, false);

            //acLookupEdit1.SetCode("C020",1);
            //acLookupEdit2.SetCode("C019");


            acChartControl1.AddLinePercentSeries("ACT", "가공", "", false, ViewType.StackedBar);

            //acChartControl1.AddLinePercentSeries("RDY", "준비", "", false, ViewType.StackedBar);

            (acChartControl1.chartControl.Diagram as XYDiagram).Rotated = true;

            acChartControl1.chartControl.PaletteName = "Pastel Kit";


            acCheckedComboBoxEdit2.AddItem("C020", "1", "0", CheckState.Checked);

            //acCheckedComboBoxEdit3.AddItem("C020", "1", "0", CheckState.Checked);

            

            //(acLayoutControl1.GetEditor("SHIFT_FLAG").Editor as acLookupEdit).SetCode("S098");

            acRadioGroup1.AddRadioItem("계획", false, "", false, "", "1");
            acRadioGroup1.AddRadioItem("실적", false, "", false, "", "2");

            acRadioGroup1.Value = "1";


            acChartControl1.chartControl.PaletteName = "The Trees";

            base.MenuInit();
        }


        public override void ChildContainerInit(Control sender)
        {
            //기본값 설정

            if (sender == acLayoutControl1)
            {

                
                acLayoutControl layout = sender as acLayoutControl;

                layout.GetEditor("YEAR_MONTH").Value = DateTime.Now;

                layout.GetEditor("S_DATE").Value = acDateEdit.GetNowFirstDate();
                layout.GetEditor("E_DATE").Value = acDateEdit.GetNowLastDate();

                //layout.GetEditor("MNG_GROUP").Value = "05,02,03,01,04";
            }


            base.ChildContainerInit(sender);
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
       
        

        void Search()
        {
            if (acLayoutControl1.ValidCheck() == false)
            {
                return;
            }

            DataRow layoutRow = acLayoutControl1.CreateParameterRow();

            //if (layoutRow["MC_GROUP"].ToString() != "" &&
            //        layoutRow["MNG_GROUP"].ToString() != "")
            //{
            //    acMessageBox.Show("설비그룹과 관리용 설비그룹 중에 하나만 입력하십시오.", this.Caption, acMessageBox.emMessageBoxType.CONFIRM);
            //    return;
            //}

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            //paramTable.Columns.Add("YEAR_MONTH", typeof(String)); //            
            paramTable.Columns.Add("MC_GROUP", typeof(String)); //            
            paramTable.Columns.Add("S_DATE", typeof(String)); //
            paramTable.Columns.Add("E_DATE", typeof(String)); //



            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            //paramRow["YEAR_MONTH"] = layoutRow["YEAR_MONTH"];            
            paramRow["MC_GROUP"] = layoutRow["MC_GROUP"];
            paramRow["S_DATE"] = layoutRow["S_DATE"];//.toDateString("yyyyMM01");
            paramRow["E_DATE"] = layoutRow["E_DATE"];//.toDateTime().GetLastDate().toDateString("yyyyMMdd");

            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            if (acRadioGroup1.Value.ToString() == "1")
            {
                BizManager.BizRun.QBizRun.ExecuteService(
                        this, QBiz.emExecuteType.LOAD,
                        "POP07A_SER", paramSet, "RQSTDT", "RSLTDT",
                        QuickSearch,
                        QuickException);
            }
            else
            {
                BizManager.BizRun.QBizRun.ExecuteService(
                        this, QBiz.emExecuteType.LOAD,
                        "POP07A_SER2", paramSet, "RQSTDT", "RSLTDT",
                        QuickSearch,
                        QuickException);
            }

        }

        private void acGridView1_CustomSummaryCalculate(object sender, CustomSummaryEventArgs e)
        {
            acGridView view = sender as acGridView;
            // Get the summary ID. 
            int summaryID = Convert.ToInt32((e.Item as GridSummaryItem).Tag);

            // Initialization. 
            //if (e.SummaryProcess == CustomSummaryProcess.Start)
            //{
            //    //discontinuedProductsCount = 0;
            //    //totalPrice = 0;
            //}

            //double value = 0;

            //if (e.SummaryProcess == CustomSummaryProcess.Calculate)
            //{

            //    double totCapa = this.ReadData.Tables["RSLTDT"].SUM("CAPA").toDouble();
            //    double totActTime = this.ReadData.Tables["RSLTDT"].SUM("ACT_TIME").toDouble();
            //    double totRdyTime = this.ReadData.Tables["RSLTDT"].SUM("READY_TIME").toDouble();


            //    switch (summaryID)
            //    {
            //        case 1: // The total summary calculated against the 'UnitPrice' column. 
            //            //int unitsInStock = Convert.ToInt32(view.GetRowCellValue(e.RowHandle, "UnitsInStock"));
            //            //totalPrice += Convert.ToDouble(e.FieldValue) * unitsInStock;
            //            value = totActTime / totCapa;
            //            break;
            //        case 2: // The group summary. 
            //            //Boolean isDiscontinued = Convert.ToBoolean(e.FieldValue);
            //            //if (isDiscontinued) discontinuedProductsCount++;
            //            value = (totActTime + totRdyTime) / totCapa;
            //            break;
            //    }
            //}
            // Finalization. 
            //if (e.SummaryProcess == CustomSummaryProcess.Finalize)
            //{
            //    if (this.ReadData == null) return;

            //    double totCapa = this.ReadData.Tables["RSLTDT"].SUM("CAPA").toDouble();
            //    double totActTime = this.ReadData.Tables["RSLTDT"].SUM("ACT_TIME").toDouble();
            //    double totRdyTime = this.ReadData.Tables["RSLTDT"].SUM("READY_TIME").toDouble();


            //    switch (summaryID)
            //    {
            //        case 1: // The total summary calculated against the 'UnitPrice' column. 
            //            //int unitsInStock = Convert.ToInt32(view.GetRowCellValue(e.RowHandle, "UnitsInStock"));
            //            //totalPrice += Convert.ToDouble(e.FieldValue) * unitsInStock;
            //            e.TotalValue = totActTime / totCapa;
            //            break;
            //        case 2: // The group summary. 
            //            //Boolean isDiscontinued = Convert.ToBoolean(e.FieldValue);
            //            //if (isDiscontinued) discontinuedProductsCount++;
            //            e.TotalValue = (totActTime + totRdyTime) / totCapa;
            //            break;
            //    }
            //}

            if (this.ReadData == null) return;

            double totCapa = this.ReadData.Tables["RSLTDT"].SUM("CAPA").toDouble();
            double totActTime = this.ReadData.Tables["RSLTDT"].SUM("ACT_TIME").toDouble();
            //double totRdyTime = this.ReadData.Tables["RSLTDT"].SUM("READY_TIME").toDouble();
         

            switch (summaryID)
            {
                case 1: // The total summary calculated against the 'UnitPrice' column. 
                        //int unitsInStock = Convert.ToInt32(view.GetRowCellValue(e.RowHandle, "UnitsInStock"));
                        //totalPrice += Convert.ToDouble(e.FieldValue) * unitsInStock;
                    e.TotalValue = (totActTime / totCapa).ToString("#0.0#%");
                    break;
                case 2: // The group summary. 
                        //Boolean isDiscontinued = Convert.ToBoolean(e.FieldValue);
                        //if (isDiscontinued) discontinuedProductsCount++;
                    e.TotalValue = (totActTime) / totCapa;
                    break;
            }
        }

        private DataSet ReadData = null;

        void QuickSearch(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                acChartControl1.ClearSeriesPoint();

                this.ReadData = e.result;

                acGridView1.GridControl.DataSource = e.result.Tables["RSLTDT"];

                base.SetLog(e.executeType, e.result.Tables["RSLTDT"].Rows.Count, e.executeTime);

                acTextEdit1.Text = e.result.Tables["RSLTDT2"].Rows.Count.ToString() + "일";

                double totCapa = e.result.Tables["RSLTDT"].SUM("CAPA").toDouble();
                double totActTime = e.result.Tables["RSLTDT"].SUM("ACT_TIME").toDouble();
                //double totRdyTime = e.result.Tables["RSLTDT"].SUM("READY_TIME").toDouble();
                //foreach (DataRow row in e.result.Tables["RSLTDT"].Rows)
                //for (int i = e.result.Tables["RSLTDT"].Rows.Count; i >0 ; i--)
                //{

                //    DataRow row = e.result.Tables["RSLTDT"].Rows[i-1];

                //    totCapa += row["CAPA"].toDouble();

                //    totActTime += row["ACT_TIME"].toDouble();

                //    totRdyTime += row["READY_TIME"].toDouble();

                //}

                SeriesPoint spTotAct = new SeriesPoint("평균", new double[] { totActTime / totCapa });

                acChartControl1.AddSeriesPoint("ACT", spTotAct);

                //SeriesPoint spTotRdy = new SeriesPoint("평균", new double[] { totRdyTime / totCapa });

                //acChartControl1.AddSeriesPoint("RDY", spTotRdy);


           

                for (int i = e.result.Tables["RSLTDT"].Rows.Count; i > 0; i--)
                {

                    DataRow row = e.result.Tables["RSLTDT"].Rows[i - 1];

                    SeriesPoint spAct = new SeriesPoint(row["MC_GROUP_NAME"].ToString(), new double[] { row["ACT_RATE"].toDouble() });

                    acChartControl1.AddSeriesPoint("ACT", spAct);

                    //SeriesPoint spRdy = new SeriesPoint(row["MC_NAME"].ToString(), new double[] { row["RDY_RATE"].toDouble() - row["ACT_RATE"].toDouble() });

                    //acChartControl1.AddSeriesPoint("RDY", spRdy);

                    //totActRate += row["ACT_RATE"].toDouble();

                    //totRdyRate += (row["RDY_RATE"].toDouble() - row["ACT_RATE"].toDouble());

                }

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void QuickException(object sender, QBiz qBiz,  BizException ex)
        {
            acMessageBox.Show(this, ex);
        }


        private void barItemSearch_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //조회
            this.Search();

        }

        private void barItemHelp_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //도움말

            //acMessageBox.ShowHelp(this, this.MenuCode);
        }
    }
}
