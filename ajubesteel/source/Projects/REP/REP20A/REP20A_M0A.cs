using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraPivotGrid;
using ControlManager;
using BizManager;
using DevExpress.XtraCharts;

namespace REP
{
    public partial class REP20A_M0A : BaseMenu
    {
        DataTable _MCauseDt = null;
        DataTable _DCauseDt = null;
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

        public REP20A_M0A()
        {
            InitializeComponent();

            acLayoutControl1.OnValueKeyDown += acLayoutControl1_OnValueKeyDown;

            acBandGridView1.CellMerge += AcBandGridView_CellMerge;
            acBandGridView2.CellMerge += AcBandGridView_CellMerge;
            acBandGridView3.CellMerge += AcBandGridView_CellMerge;
            acBandGridView4.CellMerge += AcBandGridView_CellMerge;
        }

        private void AcBandGridView_CellMerge(object sender, DevExpress.XtraGrid.Views.Grid.CellMergeEventArgs e)
        {
            try
            {
                if (e.Column.FieldName.Equals("MASTER_CAUSE")
                    && e.CellValue1.ToString().Equals(e.CellValue2))
                {
                    e.Merge = true;
                }
                else
                {
                    e.Merge = false;
                }

                e.Handled = true;
            }
            catch
            {

            }
        }

        public override void MenuInit()
        {
            base.MenuInit();

			#region bandedGridView
			acBandGridView1.OptionsView.ShowIndicator = true;
            acBandGridView2.OptionsView.ShowIndicator = true;
            acBandGridView3.OptionsView.ShowIndicator = true;
            acBandGridView4.OptionsView.ShowIndicator = true;
            acGridView1.OptionsView.ShowIndicator = true;
            acGridView2.OptionsView.ShowIndicator = true;

            acBandGridView1.OptionsView.ShowColumnHeaders = false;
            acBandGridView2.OptionsView.ShowColumnHeaders = false;
            acBandGridView3.OptionsView.ShowColumnHeaders = false;
            acBandGridView4.OptionsView.ShowColumnHeaders = false;

            acBandGridView1.OptionsView.AllowCellMerge = true;
            acBandGridView2.OptionsView.AllowCellMerge = true;
            acBandGridView3.OptionsView.AllowCellMerge = true;
            acBandGridView4.OptionsView.AllowCellMerge = true;

            acBandGridView1.OptionsView.ShowFooter = true;
            acBandGridView2.OptionsView.ShowFooter = true;
            acBandGridView3.OptionsView.ShowFooter = true;
            acBandGridView4.OptionsView.ShowFooter = true;
            acGridView1.OptionsView.ShowFooter = true;
            acGridView2.OptionsView.ShowFooter = true;

            #region 사내불량
            acBandGridView1.AddLookUpEdit("MASTER_CAUSE", "불량유형", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, "C400", "불량 유형");
            acBandGridView1.AddLookUpEdit("DETAIL_CAUSE", "불량유형", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, "C401", "불량 유형");
            acBandGridView1.AddTextEdit("TOT_QTY", "불량수량", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.QTY,"불량 수량");
            acBandGridView1.AddProgressBar("RATE", "점유율", "", false, DevExpress.Utils.HorzAlignment.Center, false, true,"점유율 ");

            acBandGridView1.Columns["TOT_QTY"].Summary.Add(DevExpress.Data.SummaryItemType.Sum,"TOT_QTY","{0:N0}");
            acBandGridView1.Columns["RATE"].Summary.Add(DevExpress.Data.SummaryItemType.Sum, "RATE", "{0:N0}%");
            #endregion

            #region 외주 불량
            acBandGridView2.AddLookUpEdit("MASTER_CAUSE", "불량유형", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, "C400", "불량 유형");
            acBandGridView2.AddLookUpEdit("DETAIL_CAUSE", "불량유형", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, "C401", "불량 유형");
            acBandGridView2.AddTextEdit("TOT_QTY", "불량수량", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.QTY, "불량 수량");
            acBandGridView2.AddProgressBar("RATE", "점유율", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, "점유율 ");
            
            acBandGridView2.Columns["TOT_QTY"].Summary.Add(DevExpress.Data.SummaryItemType.Sum, "TOT_QTY", "{0:N0}");
            acBandGridView2.Columns["RATE"].Summary.Add(DevExpress.Data.SummaryItemType.Sum, "RATE", "{0:N0}%");
            #endregion

            #region 사내불량 Worst 3
            acBandGridView3.AddLookUpEdit("MASTER_CAUSE", "불량유형", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, "C400", "불량 유형");
            acBandGridView3.AddLookUpEdit("DETAIL_CAUSE", "불량유형", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, "C401", "불량 유형");
            acBandGridView3.AddTextEdit("TOT_QTY", "불량수량", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.QTY, "불량 수량");
            
            acBandGridView3.Columns["TOT_QTY"].Summary.Add(DevExpress.Data.SummaryItemType.Sum, "TOT_QTY", "{0:N0}");
            #endregion

            #region 외주불량 Worst 3
            acBandGridView4.AddLookUpEdit("MASTER_CAUSE", "불량유형", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, "C400", "불량 유형");
            acBandGridView4.AddLookUpEdit("DETAIL_CAUSE", "불량유형", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, "C401", "불량 유형");
            acBandGridView4.AddTextEdit("TOT_QTY", "불량수량", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.QTY, "불량 수량");

            acBandGridView4.Columns["TOT_QTY"].Summary.Add(DevExpress.Data.SummaryItemType.Sum, "TOT_QTY", "{0:N0}");
            #endregion

            #region 사내 사원 불량
            acGridView1.AddLookUpEmp("EMP_CODE", "이름", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false);
            acGridView1.AddTextEdit("TOT_QTY", "불량수량", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView1.AddTextEdit("TOT_COST", "불량금액", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
            #endregion

            #region 외주 사원 불량
            acGridView2.AddLookUpVendor("VEN_CODE", "업체명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false);
            acGridView2.AddTextEdit("TOT_QTY", "불량수량", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView2.AddTextEdit("TOT_COST", "불량금액", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
            #endregion

            acBandGridView1.Columns["MASTER_CAUSE"].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            acBandGridView2.Columns["MASTER_CAUSE"].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            acBandGridView3.Columns["MASTER_CAUSE"].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            acBandGridView4.Columns["MASTER_CAUSE"].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;

            #endregion

            #region chartControl
            acChartControl1.AddLineSeries("DETAIL_CAUSE", "상세원인", "", false, acChartControl.SeriesPointType.PERCENT, DevExpress.XtraCharts.ViewType.Bar);
            acChartControl2.AddLineSeries("DETAIL_CAUSE", "상세원인", "", false, acChartControl.SeriesPointType.QTY, DevExpress.XtraCharts.ViewType.Bar);
            acChartControl3.AddLineSeries("DETAIL_CAUSE", "상세원인", "", false, acChartControl.SeriesPointType.PERCENT, DevExpress.XtraCharts.ViewType.Bar);
            acChartControl4.AddLineSeries("DETAIL_CAUSE", "상세원인", "", false, acChartControl.SeriesPointType.QTY, DevExpress.XtraCharts.ViewType.Bar);
            
            ((XYDiagram)acChartControl1.chartControl.Diagram).Rotated = true;
            ((XYDiagram)acChartControl2.chartControl.Diagram).Rotated = true;
            ((XYDiagram)acChartControl3.chartControl.Diagram).Rotated = true;
            ((XYDiagram)acChartControl4.chartControl.Diagram).Rotated = true;

            acChartControl1.chartControl.Legend.Visible = false;
            acChartControl2.chartControl.Legend.Visible = false;
            acChartControl3.chartControl.Legend.Visible = false;
            acChartControl4.chartControl.Legend.Visible = false;

            foreach (Series s in acChartControl1.SeriesDic.Values)
            {
                SideBySideBarSeriesView view = s.View as SideBySideBarSeriesView;
                if (view == null) continue;
                view.FillStyle.FillMode = FillMode.Solid;
                view.Color = Color.LightGreen;
            }

            foreach (Series s in acChartControl2.SeriesDic.Values)
            {
                SideBySideBarSeriesView view = s.View as SideBySideBarSeriesView;
                if (view == null) continue;
                view.FillStyle.FillMode = FillMode.Solid;
                view.Color = Color.LightSkyBlue;
            }

            foreach (Series s in acChartControl3.SeriesDic.Values)
            {
                SideBySideBarSeriesView view = s.View as SideBySideBarSeriesView;
                if (view == null) continue;
                view.FillStyle.FillMode = FillMode.Solid;
                view.Color = Color.LightGreen;
            }

            foreach (Series s in acChartControl4.SeriesDic.Values)
            {
                SideBySideBarSeriesView view = s.View as SideBySideBarSeriesView;
                if (view == null) continue;
                view.FillStyle.FillMode = FillMode.Solid;
                view.Color = Color.LightSkyBlue;
            }

            #endregion

            cboDate.AddItem("불량발생일", true, "F1HO50M4", "NG_DATE", true, false);

            _MCauseDt = acStdCodes.GetCatTableByServer("C400");
            _DCauseDt = acStdCodes.GetCatTableByServer("C401");
        }

        public override void ChildContainerInit(Control sender)
        {
            //기본값 설정

            if (sender == acLayoutControl1)
            {


                acLayoutControl layout = sender as acLayoutControl;

                DateTime now = DateTime.Now;
                layout.GetEditor("DATE").Value = "NG_DATE";
                layout.GetEditor("S_DATE").Value = new DateTime(now.Year, now.Month, 1);
                layout.GetEditor("E_DATE").Value = now;
            }

            base.ChildContainerInit(sender);
        }
        void Search()
        {
            DataRow layoutRow = acLayoutControl1.CreateParameterRow();

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("S_WORK_DATE", typeof(String)); //
            paramTable.Columns.Add("E_WORK_DATE", typeof(String)); //

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            foreach (string key in cboDate.GetKeyChecked())
            {
                switch (key)
                {
                    case "NG_DATE":

                        //불량발생일
                        paramRow["S_WORK_DATE"] = layoutRow["S_DATE"];
                        paramRow["E_WORK_DATE"] = layoutRow["E_DATE"];

                        break;
                }
            }

            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD, "REP20A_SER", paramSet, "RQSTDT", "RSLTDT",
                        QuickSearch,
                        QuickException);

        }

        void QuickException(object sender, QBiz QBiz, BizManager.BizException ex)
        {
            acMessageBox.Show(this, ex);
        }

        void QuickSearch(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                acGridView1.GridControl.DataSource = e.result.Tables["RSLTDT_NG_EMP"];
                acGridView2.GridControl.DataSource = e.result.Tables["RSLTDT_PNG_VEN"];

                SetData(e);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void SetData(QBiz.ExcuteCompleteArgs e)
        {
            int ngTotQty = e.result.Tables["RSLTDT_NG"].AsEnumerable().Sum(s => s["TOT_QTY"].toInt());
            int pngTotQty = e.result.Tables["RSLTDT_PNG"].AsEnumerable().Sum(s => s["TOT_QTY"].toInt());

            DataTable inNgDt = e.result.Tables["RSLTDT_NG"];
            DataTable outNgDt = e.result.Tables["RSLTDT_PNG"];

            DataTable inputTable1 = acBandGridView1.NewTable();
            DataTable inputTable2 = acBandGridView2.NewTable();

            foreach (DataRow mRow in _MCauseDt.AsEnumerable().OrderBy(o => o["CD_SEQ"]))
            {
                foreach (DataRow dRow in _DCauseDt.AsEnumerable().Where(w => w["CD_PARENT"].Equals(mRow["CD_CODE"].ToString())).OrderBy(o => o["CD_SEQ"]))
                {

                    #region 사내
                    DataRow selRow1 = inNgDt.Select("MASTER_CAUSE = '" + mRow["CD_CODE"] + "' AND DETAIL_CAUSE = '" + dRow["CD_CODE"] + "'").FirstOrDefault();

                    if (selRow1 != null)
                    {
                        DataRow inputRow1 = inputTable1.NewRow();
                        inputRow1["MASTER_CAUSE"] = selRow1["MASTER_CAUSE"];
                        inputRow1["DETAIL_CAUSE"] = selRow1["DETAIL_CAUSE"];
                        inputRow1["TOT_QTY"] = selRow1["TOT_QTY"];
                        inputRow1["RATE"] = selRow1["TOT_QTY"].toDecimal() / ngTotQty * 100;
                        inputTable1.Rows.Add(inputRow1);

                        SeriesPoint sp = new SeriesPoint(dRow["CD_NAME"], new object[] { selRow1["TOT_QTY"].toDecimal() / ngTotQty });
                        acChartControl1.AddSeriesPoint("DETAIL_CAUSE", sp);
                    }
                    #endregion


                    #region 외주
                    DataRow selRow2 = outNgDt.Select("MASTER_CAUSE = '" + mRow["CD_CODE"] + "' AND DETAIL_CAUSE = '" + dRow["CD_CODE"] + "'").FirstOrDefault();

                    if (selRow2 != null)
                    {
                        DataRow inputRow2 = inputTable2.NewRow();
                        inputRow2["MASTER_CAUSE"] = selRow2["MASTER_CAUSE"];
                        inputRow2["DETAIL_CAUSE"] = selRow2["DETAIL_CAUSE"];
                        inputRow2["TOT_QTY"] = selRow2["TOT_QTY"];
                        inputRow2["RATE"] = selRow2["TOT_QTY"].toDecimal() / pngTotQty * 100;
                        inputTable2.Rows.Add(inputRow2);

                        SeriesPoint sp = new SeriesPoint(dRow["CD_NAME"], new object[] { selRow2["TOT_QTY"].toDecimal() / pngTotQty });
                        acChartControl3.AddSeriesPoint("DETAIL_CAUSE", sp);
                    }
                    #endregion
                }
            }


            DataTable inputTable3 = acBandGridView3.NewTable();
            DataTable inputTable4 = acBandGridView4.NewTable();

            foreach (DataRow row in inNgDt.AsEnumerable().OrderByDescending(o => o["TOT_QTY"].toInt()).Take(3))
            {
                DataRow inputRow = inputTable3.NewRow();
                inputRow["MASTER_CAUSE"] = row["MASTER_CAUSE"];
                inputRow["DETAIL_CAUSE"] = row["DETAIL_CAUSE"];
                inputRow["TOT_QTY"] = row["TOT_QTY"];
                inputTable3.Rows.Add(inputRow);

                string cdName = _DCauseDt.AsEnumerable().Where(w => w["CD_CODE"].Equals(row["DETAIL_CAUSE"].ToString())).Select(r=>r["CD_NAME"].ToString()).FirstOrDefault();

                SeriesPoint sp = new SeriesPoint(cdName, new object[] { row["TOT_QTY"] });
                acChartControl2.AddSeriesPoint("DETAIL_CAUSE", sp);
            }

            foreach (DataRow row in outNgDt.AsEnumerable().OrderByDescending(o => o["TOT_QTY"].toInt()).Take(3))
            {
                DataRow inputRow = inputTable4.NewRow();
                inputRow["MASTER_CAUSE"] = row["MASTER_CAUSE"];
                inputRow["DETAIL_CAUSE"] = row["DETAIL_CAUSE"];
                inputRow["TOT_QTY"] = row["TOT_QTY"];
                inputTable4.Rows.Add(inputRow);

                string cdName = _DCauseDt.AsEnumerable().Where(w => w["CD_CODE"].Equals(row["DETAIL_CAUSE"].ToString())).Select(r => r["CD_NAME"].ToString()).FirstOrDefault();
                if (cdName.isNullOrEmpty())
                    continue;
                SeriesPoint sp = new SeriesPoint(cdName, new object[] { row["TOT_QTY"] });
                acChartControl4.AddSeriesPoint("DETAIL_CAUSE", sp);
            }

            acBandGridView1.GridControl.DataSource = inputTable1;
            acBandGridView2.GridControl.DataSource = inputTable2;
            acBandGridView3.GridControl.DataSource = inputTable3;
            acBandGridView4.GridControl.DataSource = inputTable4;
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

        void acLayoutControl1_OnValueKeyDown(object sender, IBaseEditControl info, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.Search();
            }
        }
    }
}
