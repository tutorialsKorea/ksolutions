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
using BizManager;

namespace REP
{
    public sealed partial class REP02A_M0A : BaseMenu
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

        public REP02A_M0A()
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

            #region 일별 가동률


            acGridView1.AddDateEdit("WORK_DATE", "작업일", "40540", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);

            acGridView1.AddLookUpEdit("MC_GROUP", "설비그룹", "40551", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "C020");

            acGridView1.AddTextEdit("MC_CODE", "설비코드", "40551", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("MC_NAME", "설비명", "40542", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            //acGridView1.AddTextEdit("CAPA", "가용시간", "DWNYLR5F", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);

            acGridView1.AddTextEdit("ACT_TIME", "가동시간(분)", "DWNYLR5F", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);

            //acGridView1.AddTextEdit("ACT_RATE", "가동율", "70NF0OEU", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.PER2);


            #endregion


            #region 주별 가동율

            //acGridView3.AddDateEdit("WORK_WEEK", "작업주", "40540", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.MONTH_DATE);
            //acGridView2.AddTextEdit("WORK_WEEK", "작업주", "40551", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            //acGridView2.AddTextEdit("MC_CODE", "설비코드", "40551", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            //acGridView2.AddTextEdit("MC_NAME", "설비명", "40542", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            //acGridView2.AddTextEdit("CAPA", "가용시간", "DWNYLR5F", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);

            //acGridView2.AddTextEdit("ACT_TIME", "가동시간", "DWNYLR5F", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);

            //acGridView2.AddTextEdit("ACT_RATE", "가동율", "70NF0OEU", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.PER2);

            #endregion


            #region 월별 가동율



            //acGridView3.AddDateEdit("WORK_MONTH", "작업월", "40540", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.MONTH_DATE);

            //acGridView3.AddTextEdit("MC_CODE", "설비코드", "40551", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            //acGridView3.AddTextEdit("MC_NAME", "설비명", "40542", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            //acGridView3.AddTextEdit("CAPA", "가용시간", "DWNYLR5F", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);

            //acGridView3.AddTextEdit("ACT_TIME", "가동시간", "DWNYLR5F", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);

            //acGridView3.AddTextEdit("ACT_RATE", "가동율", "70NF0OEU", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.PER2);


            #endregion





            acLayoutControl1.OnValueKeyDown += new acLayoutControl.ValueKeyDownEventHandler(acLayoutControl1_OnValueKeyDown);

            //acLayoutControl2.OnValueKeyDown += new acLayoutControl.ValueKeyDownEventHandler(acLayoutControl2_OnValueKeyDown);

            //acLayoutControl3.OnValueKeyDown += new acLayoutControl.ValueKeyDownEventHandler(acLayoutControl3_OnValueKeyDown);

            //acGridView3.ColumnFilterChanged += new EventHandler(acGridView4_ColumnFilterChanged);
            //acGridView3.EndSorting += new EventHandler(acGridView4_EndSorting);
            //acGridView3.DataSourceChanged += new EventHandler(acGridView4_DataSourceChanged);

            (acLayoutControl1.GetEditor("MC_GROUP").Editor as acLookupEdit).SetCode("C020");



            base.MenuInit();
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
        public override void ChildContainerInit(Control sender)
        {
            //기본값 설정

            if (sender == acLayoutControl1)
            {
                acLayoutControl layout = sender as acLayoutControl;

                layout.GetEditor("S_DATE").Value = DateTime.Now.AddDays(-7);
                layout.GetEditor("E_DATE").Value = DateTime.Now;
            }
            //else if (sender == acLayoutControl2)
            //{

            //    acLayoutControl layout = sender as acLayoutControl;


            //    layout.GetEditor("S_DATE").Value = acDateEdit.GetNowFirstDate();
            //    layout.GetEditor("E_DATE").Value = acDateEdit.GetNowLastDate();
            //}
            //else if (sender == acLayoutControl3)
            //{

            //    acLayoutControl layout = sender as acLayoutControl;


            //    layout.GetEditor("S_MONTH").Value = acDateEdit.GetNowFirstMonth();
            //    layout.GetEditor("E_MONTH").Value = acDateEdit.GetNowMonth();
            //}

            base.ChildContainerInit(sender);
        }
        //void acGridView4_EndSorting(object sender, EventArgs e)
        //{
        //    this.acGridView4_DataSourceChanged(null, null);

        //}

        //void acGridView4_ColumnFilterChanged(object sender, EventArgs e)
        //{
        //    this.acGridView4_DataSourceChanged(null, null);

        //}

        //void acGridView4_DataSourceChanged(object sender, EventArgs e)
        //{
        //    DataView view = acGridView3.GetDataView();

        //    acChartControl3.ClearSeriesPoint();


        //    for (int i = 0; i < view.Count; i++)
        //    {


        //        DateTime dt = view[i]["WORK_MONTH"].toDateTime();

        //        string argument = dt.ToString("yyyy-MM");


        //        SeriesPoint dayAvrTime = new SeriesPoint(
        //            argument,
        //            new double[] { view[i]["DAY_AVR_TIME"].toDouble() }
        //            );

        //        acChartControl3.AddSeriesPoint("DAY_AVR_TIME", dayAvrTime);


        //        SeriesPoint manTimePoint = new SeriesPoint(
        //            argument,
        //            new double[] { view[i]["MAN_TIME"].toDouble() }
        //            );

        //        acChartControl3.AddSeriesPoint("MAN_TIME", manTimePoint);

        //        SeriesPoint selfTimePoint = new SeriesPoint(
        //            argument,
        //            new double[] { view[i]["SELF_TIME"].toDouble() }
        //            );

        //        acChartControl3.AddSeriesPoint("SELF_TIME", selfTimePoint);

        //        SeriesPoint otTimePoint = new SeriesPoint(
        //         argument,
        //         new double[] { view[i]["OT_TIME"].toDouble() }
        //         );

        //        acChartControl3.AddSeriesPoint("OT_TIME", otTimePoint);



        //        SeriesPoint totTimePoint = new SeriesPoint(
        //         argument,
        //         new double[] { view[i]["TOT_TIME"].toDouble() }
        //         );

        //        acChartControl3.AddSeriesPoint("TOT_TIME", totTimePoint);


        //    }

        //}






        ///// <summary>
        ///// 설비별 월단위 챠트를 구성함
        ///// </summary>
        //void MonthSearch()
        //{
        //    if (acLayoutControl3.ValidCheck() == false)
        //    {
        //        return;
        //    }

        //    DataRow layoutRow = acLayoutControl3.CreateParameterRow();


        //    DataTable paramTable = new DataTable("RQSTDT");
        //    paramTable.Columns.Add("PLT_CODE", typeof(String)); //
        //    //paramTable.Columns.Add("EMP_CODE", typeof(String)); //
        //    paramTable.Columns.Add("S_WORK_DATE", typeof(String)); //작업일 (시작)
        //    paramTable.Columns.Add("E_WORK_DATE", typeof(String)); //작업일 (종료)

        //    foreach (DateTime item in acDateEdit.GetMonthList(layoutRow["S_MONTH"].toDateTime(), layoutRow["E_MONTH"].toDateTime()))
        //    {
        //        DataRow paramRow = paramTable.NewRow();
        //        paramRow["PLT_CODE"] = acInfo.PLT_CODE;
        //        //paramRow["EMP_CODE"] = layoutRow["EMP_CODE"];
        //        paramRow["S_WORK_DATE"] = item.GetFirstDate().toDateString("yyyyMMdd");
        //        paramRow["E_WORK_DATE"] = item.GetLastDate().toDateString("yyyyMMdd");
        //        paramTable.Rows.Add(paramRow);

        //    }

        //    DataSet paramSet = new DataSet();
        //    paramSet.Tables.Add(paramTable);

        //    BizRun.QBizRun.ExecuteService(
        //    this, QBiz.emExecuteType.LOAD, "REP03A_SER3", paramSet, "RQSTDT", "RSLTDT",
        //    MonthSearchCallBack,
        //    QuickException);


        //}

        //void MonthSearchCallBack(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        //{
        //    try
        //    {
        //        acGridView3.GridControl.DataSource = e.result.Tables["RSLTDT"];

        //        acGridView3.SetOldFocusRowHandle(false);

        //        acGridView3.BestFitColumns();


        //        #region 차크 그리기
        //        acChartControl3.ClearSeries();
        //        acChartControl3.ClearSeriesPoint();

        //        acChartControl3.chartControl.PaletteName = "Metro";//Metro

        //        acChartControl3.chartControl.Legend.AlignmentVertical = LegendAlignmentVertical.TopOutside;
        //        acChartControl3.chartControl.Legend.AlignmentHorizontal = LegendAlignmentHorizontal.Right;
        //        acChartControl3.chartControl.Legend.Direction = LegendDirection.LeftToRight;

        //        //차트 설정
        //        XYDiagram diagram1 = acChartControl3.chartControl.Diagram as XYDiagram;
        //        if (diagram1 != null)
        //        {
        //            diagram1.AxisY.Label.TextPattern = "{V:#,##0}";
        //            diagram1.AxisX.Label.Visible = true;
        //            //diagram1.AxisX.Label.Angle = -30;
        //            diagram1.AxisY.Interlaced = true;
        //            diagram1.AxisY.GridLines.Color = ColorTranslator.FromHtml("#8E8E8E"); //Color.WhiteSmoke;
        //            diagram1.AxisX.DateTimeScaleOptions.GridAlignment = DateTimeGridAlignment.Month;
        //            diagram1.AxisX.DateTimeScaleOptions.MeasureUnit = DateTimeMeasureUnit.Month;
        //        }

        //        foreach (DataRow row in e.result.Tables["RSLTDT"].Rows)
        //        {
        //            if (!acChartControl3.SeriesDic.ContainsKey(row["MC_CODE"].ToString()))
        //            {
        //                acChartControl3.AddLineSeries(row["MC_CODE"].ToString()
        //                    , row["MC_NAME"].ToString(), "", false, acChartControl.SeriesPointType.PERCENT, DevExpress.XtraCharts.ViewType.Line);

        //                Series series = acChartControl3.SeriesDic[row["MC_CODE"].ToString()];

        //                LineSeriesView lsView = (LineSeriesView)series.View;

        //                if (lsView != null)
        //                {
        //                    //lsView.LineMarkerOptions.Kind = MarkerKind.Circle;
        //                    lsView.MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;
        //                    //acChartControl1.chartControl.Series[2].CrosshairLabelPattern = "{S} : {V:F3}";

        //                }
        //                series.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
        //                PointSeriesLabel psLabel = (PointSeriesLabel)series.Label;
        //                psLabel.BackColor = Color.Transparent;
        //                psLabel.Border.Visibility = DevExpress.Utils.DefaultBoolean.False;
        //                psLabel.Shadow.Visible = false;
        //                //psLabel.TextColor = Color.DarkSlateGray;
        //                psLabel.ResolveOverlappingMode = ResolveOverlappingMode.Default;
        //                psLabel.TextPattern = "{V:P}";
        //                psLabel.Font = new Font("맑은 고딕", 10,
        //                    FontStyle.Bold, DevExpress.Utils.AppearanceObject.DefaultFont.Unit);

        //            }

        //            string work_month = row["WORK_MONTH"].ToString();

        //            SeriesPoint sp = new SeriesPoint("" + work_month + "", new double[] { row["ACT_RATE"].toDouble() });
        //            acChartControl3.AddSeriesPoint(row["MC_CODE"].ToString(), sp);
        //        }
        //        #endregion

        //        base.SetLog(e.executeType, e.result.Tables["RSLTDT"].Rows.Count, e.executeTime);
        //    }
        //    catch (Exception ex)
        //    {
        //        acMessageBox.Show(this, ex);
        //    }
        //}



        //void WeekSearch()
        //{

        //    DataRow layoutRow = acLayoutControl2.CreateParameterRow();

        //    if (acLayoutControl2.ValidCheck() == false)
        //    {

        //        return;
        //    }

        //    DataTable paramTable = new DataTable("RQSTDT");
        //    paramTable.Columns.Add("PLT_CODE", typeof(String)); //
        //    paramTable.Columns.Add("S_WORK_DATE", typeof(String)); //작업일 (시작)
        //    paramTable.Columns.Add("E_WORK_DATE", typeof(String)); //작업일 (종료)

        //    DataRow paramRow = paramTable.NewRow();
        //    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
        //    paramRow["S_WORK_DATE"] = layoutRow["S_DATE"];
        //    paramRow["E_WORK_DATE"] = layoutRow["E_DATE"];
        //    paramTable.Rows.Add(paramRow);
        //    DataSet paramSet = new DataSet();
        //    paramSet.Tables.Add(paramTable);


        //    BizRun.QBizRun.ExecuteService(
        //    this, QBiz.emExecuteType.LOAD, "REP03A_SER2", paramSet, "RQSTDT", "RSLTDT",
        //    WeekSearchCallBack,
        //    QuickException);



        //}

        //void WeekSearchCallBack(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        //{
        //    try
        //    {
        //        acGridView2.GridControl.DataSource = e.result.Tables["RSLTDT"];

        //        acGridView2.SetOldFocusRowHandle(false);

        //        acGridView2.BestFitColumns();


        //        #region 차크 그리기
        //        acChartControl2.ClearSeries();
        //        acChartControl2.ClearSeriesPoint();

        //        acChartControl2.chartControl.PaletteName = "Metro";//Metro

        //        acChartControl2.chartControl.Legend.AlignmentVertical = LegendAlignmentVertical.TopOutside;
        //        acChartControl2.chartControl.Legend.AlignmentHorizontal = LegendAlignmentHorizontal.Right;
        //        acChartControl2.chartControl.Legend.Direction = LegendDirection.LeftToRight;

        //        //차트 설정
        //        XYDiagram diagram1 = acChartControl2.chartControl.Diagram as XYDiagram;
        //        if (diagram1 != null)
        //        {
        //            diagram1.AxisY.Label.TextPattern = "{V:#,##0}";
        //            diagram1.AxisX.Label.Visible = true;
        //            //diagram1.AxisX.Label.Angle = -30;
        //            diagram1.AxisY.Interlaced = true;
        //            diagram1.AxisY.GridLines.Color = ColorTranslator.FromHtml("#8E8E8E"); //Color.WhiteSmoke;
        //        }

        //        foreach (DataRow row in e.result.Tables["RSLTDT"].Rows)
        //        {
        //            if (!acChartControl2.SeriesDic.ContainsKey(row["MC_CODE"].ToString()))
        //            {
        //                acChartControl2.AddLineSeries(row["MC_CODE"].ToString()
        //                    , row["MC_NAME"].ToString(), "", false, acChartControl.SeriesPointType.PERCENT, DevExpress.XtraCharts.ViewType.Line);

        //                Series series = acChartControl2.SeriesDic[row["MC_CODE"].ToString()];

        //                LineSeriesView lsView = (LineSeriesView)series.View;

        //                if (lsView != null)
        //                {
        //                    //lsView.LineMarkerOptions.Kind = MarkerKind.Circle;
        //                    lsView.MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;
        //                    //acChartControl1.chartControl.Series[2].CrosshairLabelPattern = "{S} : {V:F3}";
        //                }
        //                series.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
        //                PointSeriesLabel psLabel = (PointSeriesLabel)series.Label;
        //                psLabel.BackColor = Color.Transparent;
        //                psLabel.Border.Visibility = DevExpress.Utils.DefaultBoolean.False;
        //                psLabel.Shadow.Visible = false;
        //                //psLabel.TextColor = Color.DarkSlateGray;
        //                psLabel.ResolveOverlappingMode = ResolveOverlappingMode.Default;
        //                psLabel.TextPattern = "{V:P}";
        //                psLabel.Font = new Font("맑은 고딕", 10,
        //                    FontStyle.Bold, DevExpress.Utils.AppearanceObject.DefaultFont.Unit);

        //            }

        //            string work_week = row["WORK_WEEK"].ToString();

        //            SeriesPoint sp = new SeriesPoint("" + work_week + "", new double[] { row["ACT_RATE"].toDouble() });
        //            acChartControl2.AddSeriesPoint(row["MC_CODE"].ToString(), sp);
        //        }
        //        #endregion

        //        base.SetLog(e.executeType, e.result.Tables["RSLTDT"].Rows.Count, e.executeTime);
        //    }
        //    catch (Exception ex)
        //    {
        //        acMessageBox.Show(this, ex);
        //    }
        //}


        void DaySearch()
        {

            DataRow layoutRow = acLayoutControl1.CreateParameterRow();

            if (acLayoutControl1.ValidCheck() == false)
            {

                return;
            }


            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("S_WORK_DATE", typeof(String)); //작업일 (시작)
            paramTable.Columns.Add("E_WORK_DATE", typeof(String)); //작업일 (종료)
            paramTable.Columns.Add("MC_GROUP", typeof(String)); //작업일

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["S_WORK_DATE"] = layoutRow["S_DATE"];
            paramRow["E_WORK_DATE"] = layoutRow["E_DATE"];
            paramRow["MC_GROUP"] = layoutRow["MC_GROUP"];
            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);


            BizRun.QBizRun.ExecuteService(
            this, QBiz.emExecuteType.LOAD, "REP02A_SER", paramSet, "RQSTDT", "RSLTDT",
            DaySearchCallBack,
            QuickException);



        }
        void DaySearchCallBack(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {

                //DataTable dt = new DataTable();
                //dt.Columns.Add("WORK_DATE",typeof(string));
                //dt.Columns.Add("MC_NAME",typeof(string));
                //dt.Columns.Add("MC_CODE", typeof(string));
                //dt.Columns.Add("CAPA", typeof(decimal));
                //dt.Columns.Add("ACT_TIME", typeof(decimal));
                //dt.Columns.Add("ACT_RATE", typeof(decimal));

                //foreach (DataRow row in e.result.Tables["RSLTDT"].Rows)
                //{
                //    DataRow[] serRows = dt.Select(string.Format("WORK_DATE = '{0}'", row["WORK_DATE"].toDateString("yyyyMMdd")));

                //    if(serRows.Length == 0)
                //    {
                //        DataRow newRow = dt.NewRow();
                //        newRow["WORK_DATE"] = row["WORK_DATE"].toDateString("yyyyMMdd");
                //        newRow["CAPA"] = row["CAPA"];//실적 수량 * 제품 spec
                //        newRow["ACT_TIME"] = row["ACT_TIME"];//저울 측정 무게
                //        newRow["ACT_RATE"] = row["ACT_RATE"];// (newRow["MAMT"].toDecimal() == 0 ? 0 : (newRow["LAMT"].toDecimal()- newRow["MAMT"].toDecimal()) / newRow["MAMT"].toDecimal());
                //        dt.Rows.Add(newRow);                        
                //    }
                //    else
                //    {
                //        serRows[0]["MAMT"] = serRows[0]["MAMT"].toDecimal() + row["MAMT"].toDecimal();
                //        serRows[0]["LAMT"] = serRows[0]["LAMT"].toDecimal() + row["LAMT"].toDecimal();
                //        serRows[0]["LOSS_RATE"] = (serRows[0]["MAMT"].toDecimal() == 0 ? 0 :(serRows[0]["LAMT"].toDecimal() - serRows[0]["MAMT"].toDecimal()) / serRows[0]["MAMT"].toDecimal());
                //    }

                //    row["LOSS"] = row["LAMT"].toDecimal() - row["MAMT"].toDecimal();
                //    row["LOSS_RATE"] = (row["MAMT"].toDecimal() == 0 ? 0 : (row["LAMT"].toDecimal() - row["MAMT"].toDecimal()) / row["MAMT"].toDecimal());
                //    row["LOSS_RATE"] = row["LOSS_RATE"].toDecimal() * 100;

                //}

       


                #region 차크 그리기
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
                    diagram1.AxisY.Label.TextPattern = "{V:#,##0}";
                    diagram1.AxisX.Label.Visible = true;
                    //diagram1.AxisX.Label.Angle = -30;
                    diagram1.AxisY.Interlaced = true;
                    diagram1.AxisY.GridLines.Color = ColorTranslator.FromHtml("#8E8E8E"); //Color.WhiteSmoke;
                }

                DateTime startTime = acLayoutControl1.GetEditor("S_DATE").Value.toDateTime();
                DateTime endTime = acLayoutControl1.GetEditor("E_DATE").Value.toDateTime();

                foreach (DataRow row in e.result.Tables["RSLTDT_MC"].Rows)
                {
                    for (int i = 0; startTime.AddDays(i) < endTime; i++)
                    {                        

                        if (!acChartControl1.SeriesDic.ContainsKey(row["MC_CODE"].ToString()))
                        {
                            acChartControl1.AddLineSeries(row["MC_CODE"].ToString()
                                , row["MC_NAME"].ToString(), "", false, acChartControl.SeriesPointType.NUMBER, DevExpress.XtraCharts.ViewType.Line);

                            Series series = acChartControl1.SeriesDic[row["MC_CODE"].ToString()];

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
                            psLabel.TextPattern = "{V:N0}";
                            psLabel.Font = new Font("맑은 고딕", 10,
                                FontStyle.Bold, DevExpress.Utils.AppearanceObject.DefaultFont.Unit);

                        }

                        string work_date = startTime.AddDays(i).toDateString("yyyyMMdd");

                        string work_date_name = startTime.AddDays(i).toDateString("yyyy-MM-dd");

                        DataRow[] workRow = e.result.Tables["RSLTDT"].Select(string.Format("MC_CODE = '{0}' AND WORK_DATE = '{1}'", row["MC_CODE"],work_date));

                        if (workRow.Length > 0)
                        {
                            SeriesPoint sp = new SeriesPoint("" + work_date_name + "", new double[] { workRow[0]["ACT_TIME"].toDouble() });
                            acChartControl1.AddSeriesPoint(row["MC_CODE"].ToString(), sp);
                        }
                        else
                        {
                            SeriesPoint sp = new SeriesPoint("" + work_date_name + "", new double[] { 0 });
                            acChartControl1.AddSeriesPoint(row["MC_CODE"].ToString(), sp);
                        }
                    }
                }

                acGridView1.GridControl.DataSource = e.result.Tables["RSLTDT"];

                acGridView1.SetOldFocusRowHandle(false);

                acGridView1.BestFitColumns();

                //acChartControl1.chartControl.Legend.AlignmentVertical = LegendAlignmentVertical.Top;
                //acChartControl1.chartControl.Legend.AlignmentHorizontal = LegendAlignmentHorizontal.Right;
                //acChartControl1.chartControl.Legend.Direction = LegendDirection.LeftToRight;

                //제품무게
                //BarSeriesLabel bsLabel = (BarSeriesLabel)acChartControl1.chartControl.Series[0].Label;

                //acChartControl1.chartControl.Series[0].LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
                //bsLabel.BackColor = Color.Transparent;
                //bsLabel.Border.Visibility = DevExpress.Utils.DefaultBoolean.False;
                //bsLabel.Shadow.Visible = false;
                //bsLabel.TextColor = Color.OliveDrab;
                //bsLabel.ResolveOverlappingMode = ResolveOverlappingMode.Default;
                //bsLabel.TextPattern = "{V:#,##0}";
                //bsLabel.Font = new Font("맑은 고딕", 12,
                //    FontStyle.Bold, DevExpress.Utils.AppearanceObject.DefaultFont.Unit);
                ////저울무게
                //bsLabel = (BarSeriesLabel)acChartControl1.chartControl.Series[1].Label;

                //acChartControl1.chartControl.Series[1].LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
                //bsLabel.BackColor = Color.Transparent;
                //bsLabel.Border.Visibility = DevExpress.Utils.DefaultBoolean.False;
                //bsLabel.Shadow.Visible = false;
                //bsLabel.TextColor = Color.OliveDrab;
                //bsLabel.ResolveOverlappingMode = ResolveOverlappingMode.Default;
                //bsLabel.TextPattern = "{V:#,##0}";
                //bsLabel.Font = new Font("맑은 고딕", 12,
                //    FontStyle.Bold, DevExpress.Utils.AppearanceObject.DefaultFont.Unit);

                ////우측 Y
                //SecondaryAxisY SecAxisY = new SecondaryAxisY("my Y-Axis");
                //SecAxisY.WholeRange.Auto = true;
                ////SecAxisY.WholeRange.SetMinMaxValues(0.1, 1.8);
                //((XYDiagram)acChartControl1.chartControl.Diagram).SecondaryAxesY.Clear();
                //((XYDiagram)acChartControl1.chartControl.Diagram).SecondaryAxesY.Add(SecAxisY);
                //((LineSeriesView)acChartControl1.chartControl.Series[2].View).AxisY = SecAxisY;
                ////((LineSeriesView)acChartControl1.chartControl.Series[3].View).AxisY = SecAxisY;
                //SecAxisY.Title.Visible = false;
                //SecAxisY.Label.Visible = true;
                //SecAxisY.Label.TextPattern = "{V:###%}";

                ////손실율
                //LineSeriesView lsView = (LineSeriesView)acChartControl1.chartControl.Series[2].View;
                //if (lsView != null)
                //{
                //    lsView.LineMarkerOptions.Kind = MarkerKind.Circle;
                //    lsView.MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;
                //    //acChartControl1.chartControl.Series[2].CrosshairLabelPattern = "{S} : {V:F3}";
                //}
                //acChartControl1.chartControl.Series[2].LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
                //PointSeriesLabel psLabel = (PointSeriesLabel)acChartControl1.chartControl.Series[2].Label;
                //psLabel.BackColor = Color.Transparent;
                //psLabel.Border.Visibility = DevExpress.Utils.DefaultBoolean.False;
                //psLabel.Shadow.Visible = false;
                //psLabel.TextColor = Color.DarkSlateGray;
                //psLabel.ResolveOverlappingMode = ResolveOverlappingMode.Default;
                //psLabel.TextPattern = "{V:P}";
                //psLabel.Font = new Font("맑은 고딕", 12,
                //    FontStyle.Bold, DevExpress.Utils.AppearanceObject.DefaultFont.Unit);
                ////목표
                //lsView = (LineSeriesView)acChartControl1.chartControl.Series[3].View;
                //if (lsView != null)
                //{
                //    lsView.LineMarkerOptions.Kind = MarkerKind.Circle;
                //    lsView.MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;
                //    //acChartControl1.chartControl.Series[2].CrosshairLabelPattern = "{S} : {V:F3}";
                //}
                //acChartControl1.chartControl.Series[3].LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
                //psLabel = (PointSeriesLabel)acChartControl1.chartControl.Series[3].Label;
                //psLabel.BackColor = Color.Transparent;
                //psLabel.Border.Visibility = DevExpress.Utils.DefaultBoolean.False;
                //psLabel.Shadow.Visible = false;
                //psLabel.TextColor = Color.DarkSlateGray;
                //psLabel.ResolveOverlappingMode = ResolveOverlappingMode.Default;
                //psLabel.TextPattern = "{V:P}";
                //psLabel.Font = new Font("맑은 고딕", 12,
                //    FontStyle.Bold, DevExpress.Utils.AppearanceObject.DefaultFont.Unit);

                //acChartControl2.chartControl.PaletteName = "The Trees";

                //DateTime start = acLayoutControl1.GetEditor("S_DATE").Value.toDateTime();
                //DateTime end = acLayoutControl1.GetEditor("E_DATE").Value.toDateTime();

                //for(int i = 0; start.AddDays(i) < end.AddDays(1); i++)
                //{
                //    string date = start.AddDays(i).toDateString("yyyy-MM-dd");

                //    string serDate = start.AddDays(i).toDateString("yyyyMMdd");



                //    DataRow[] dataRows = e.result.Tables["RSLTDT"].Select(string.Format("WORK_DATE = '{0}'", serDate));

                //    double capa = 0, act = 0, rate = 0;

                //    if (dataRows.Length > 0)
                //    {

                //        capa = dataRows[0]["CAPA"].toDouble();
                //        act = dataRows[0]["ACT_TIME"].toDouble();
                //        rate = dataRows[0]["ACT_RATE"].toDouble();
                //    }

                //    SeriesPoint spMamt = new SeriesPoint("" + date + "", new double[] { mamt });
                //    acChartControl1.AddSeriesPoint("MAMT", spMamt);

                //    SeriesPoint spLamt = new SeriesPoint("" + date + "", new double[] { lamt });
                //    acChartControl1.AddSeriesPoint("LAMT", spLamt);

                //    SeriesPoint spRate = new SeriesPoint("" + date + "", new double[] { loss_rate });
                //    acChartControl1.AddSeriesPoint("LOSS_RATE", spRate);

                //    //SeriesPoint spGole = new SeriesPoint("[" + i.ToString() + "월]", new double[] { 1.5 });
                //    //acChartControl1.AddSeriesPoint("GOLE_RATE", spGole);
                //}

                #endregion

                base.SetLog(e.executeType, e.result.Tables["RSLTDT"].Rows.Count, e.executeTime);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }


        void QuickException(object sender, QBiz qBiz, BizException ex)
        {

            acMessageBox.Show(this, ex);

        }


        void Search()
        {
            //if (acTabControl1.SelectedTabPage == acTabPage1)
            //{
            //일별 작업자 실적공수 조회

            this.DaySearch();

            //}
            //else if (acTabControl1.SelectedTabPage == acTabPage2)
            //{
            //    //기간별 작업자 실적공수 조회

            //    this.WeekSearch();

            //}
            //else if (acTabControl1.SelectedTabPage == acTabPage3)
            //{

            //    //월별 작업 실적공수 조회

            //    this.MonthSearch();

            //}

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
