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

namespace MNT
{
    public sealed partial class MNT06A_M0A : BaseMenu
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

        public MNT06A_M0A()
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
            acDateEdit1.Properties.EditMask = "yyyy-MM";


            timer1.Interval = acInfo.SysConfig.GetSysConfigByMemory("MONITOR_REFRESH_TIME").toInt() * 1000; //30*1000 = 30초 주기

            //timer1.Start();


            base.MenuInit();
        }

        public override void ChildContainerInit(Control sender)
        {
            //기본값 설정

            if (sender == acLayoutControl1)
            {
                acLayoutControl layout = sender as acLayoutControl;

                layout.GetEditor("S_MONTH").Value = acDateEdit.GetNowMonth();

            }
            base.ChildContainerInit(sender);
        }


        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            timer1_Tick(null, null);
        }



        public override void MenuInitComplete()
        {
            this.Search();

            base.MenuInitComplete();
        }


        public override bool MenuDestory(object sender)
        {
            timer1.Stop();

            return base.MenuDestory(sender);
        }


        void search()
        {

            DataRow layoutRow = acLayoutControl1.CreateParameterRow();

            if (acLayoutControl1.ValidCheck() == false)
            {

                return;
            }


            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("S_MONTH", typeof(String)); //

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["S_MONTH"] = layoutRow["S_MONTH"];

            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);


            BizRun.QBizRun.ExecuteService(
            this, QBiz.emExecuteType.LOAD_DETAIL, "MNT06A_SER", paramSet, "RQSTDT", "RSLTDT",
            DaySearchCallBack,
            QuickException);



        }
        void DaySearchCallBack(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                acLabelControl8.Text = string.Format("{0:N0}", e.result.Tables["RSLTDT"].Rows[0]["DATA1"].toDecimal());
                acLabelControl9.Text = string.Format("{0:N0}", e.result.Tables["RSLTDT"].Rows[0]["DATA2"].toDecimal());
                acLabelControl10.Text = string.Format("{0:N0}건", e.result.Tables["RSLTDT"].Rows[0]["DATA3"].toDecimal());
                acLabelControl11.Text = string.Format("{0:N0}건", e.result.Tables["RSLTDT"].Rows[0]["DATA4"].toDecimal());
                acLabelControl12.Text = string.Format("{0:N0}", e.result.Tables["RSLTDT"].Rows[0]["DATA5"].toDecimal());
                acLabelControl13.Text = string.Format("{0:N0}", e.result.Tables["RSLTDT"].Rows[0]["DATA6"].toDecimal());
                acLabelControl14.Text = string.Format("{0:N0}%", e.result.Tables["RSLTDT"].Rows[0]["DATA7"].toDecimal());

                acLabelControl23.Text = string.Format("{0:N0}건", e.result.Tables["RSLTDT"].Rows[0]["DATA8"].toDecimal());
                acLabelControl24.Text = string.Format("{0:N0}건", e.result.Tables["RSLTDT"].Rows[0]["DATA9"].toDecimal());
                acLabelControl25.Text = string.Format("{0:N0}건", e.result.Tables["RSLTDT"].Rows[0]["DATA10"].toDecimal());
                acLabelControl26.Text = string.Format("{0:N0}건", e.result.Tables["RSLTDT"].Rows[0]["DATA11"].toDecimal());
                acLabelControl27.Text = string.Format("{0:N0}건", e.result.Tables["RSLTDT"].Rows[0]["DATA12"].toDecimal());
                acLabelControl28.Text = string.Format("{0:N0}%", e.result.Tables["RSLTDT"].Rows[0]["DATA13"].toDecimal());
                acLabelControl29.Text = string.Format("{0:N0}명", e.result.Tables["RSLTDT"].Rows[0]["DATA14"].toDecimal());


                acBandGridView ab = new acBandGridView();
                DataTable table = new DataTable();

                DataTable currDT = acInfo.StdCodes.GetCatTable("V002");

                table.Columns.Add("GUBUN", typeof(string));

                string[] month = new string[] { "JAN", "FEB", "MAR", "APR", "MAY", "JUN", "JUL", "AUG", "SEP", "OCT", "NOV", "DEC" };

                for (int i = 0; i < 13; i++)
                {
                    foreach (DataRow row in currDT.Rows)
                    {
                        if (i < 12)
                        { 
                            table.Columns.Add(month[i] + "_" + row["CD_CODE"].ToString(), typeof(string));
                        }
                        else
                        {
                            table.Columns.Add("TOTAL_" + row["CD_CODE"].ToString(), typeof(string));
                        }
                    }
                }



                foreach (DataRow row in e.result.Tables["RSLTDT_CHART1"].Rows)
                {
                    DataRow[] rows = table.Select("GUBUN = '" + row["GUBUN"].ToString() + "'");

                    if (rows.Length == 0)
                    {
                        DataRow newRow = table.NewRow();
                        newRow["GUBUN"] = row["GUBUN"];

                        table.Rows.Add(newRow);
                    }

                    rows = table.Select("GUBUN = '" + row["GUBUN"].ToString() + "'");

                    foreach (DataColumn col in table.Columns)
                    {
                        string[] strs = col.ColumnName.Split('_');

                        if (strs.Length == 2)
                        {
                            if (rows[0][col.ColumnName].ToString() == "")
                            {
                                rows[0][col.ColumnName] = 0;
                            }

                            if (strs[1] == row["CURR_UNIT"].ToString())
                            {
                                rows[0][col.ColumnName] = System.Convert.ToDecimal(rows[0][col.ColumnName]) + System.Convert.ToDecimal(row[strs[0]]);
                            }
                            else
                            {
                                if (System.Convert.ToDecimal(rows[0][col.ColumnName]) == 0)
                                {
                                    rows[0][col.ColumnName] = 0;
                                }
                            }
                        }
                    }
                }

                //매출현황
                setChart4(acChartControl1, table);

                //매입현황
                SetChart(acChartControl2, e.result.Tables["RSLTDT_CHART2"]);

                //가공 및 검사실적
                SetChart2(acChartControl3, e.result.Tables["RSLTDT_CHART3"]);

                //불량률 현황
                setChart3(acChartControl4, e.result.Tables["RSLTDT_CHART4"]);
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
            ac.chartControl.Titles[0].Text = "[매입현황]";
            ac.chartControl.Titles[0].Visibility = DevExpress.Utils.DefaultBoolean.True;
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
                    series.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;
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


        void SetChart2(acChartControl ac, DataTable rslt)
        {
            ac.ClearSeries();
            ac.ClearSeriesPoint();

            ac.chartControl.PaletteName = "Metro";//Metro
            ac.chartControl.Titles[0].Text = "[가공 및 검사실적]";
            ac.chartControl.Titles[0].Visibility = DevExpress.Utils.DefaultBoolean.True;
            ac.chartControl.Legend.AlignmentVertical = LegendAlignmentVertical.TopOutside;
            ac.chartControl.Legend.AlignmentHorizontal = LegendAlignmentHorizontal.Right;
            ac.chartControl.Legend.Direction = LegendDirection.LeftToRight;

            //차트 설정
            XYDiagram diagram1 = ac.chartControl.Diagram as XYDiagram;
            if (diagram1 != null)
            {
                diagram1.AxisY.Label.TextPattern = "{V:N0}";
                diagram1.AxisX.Label.Visible = true;
                diagram1.AxisY.Interlaced = true;
                diagram1.AxisY.GridLines.Color = ColorTranslator.FromHtml("#8E8E8E"); //Color.WhiteSmoke;
            }

            foreach (DataRow row in rslt.Rows)
            {
                if (row["TYPE_NAME"].ToString() == "차이") continue;

                if (!ac.SeriesDic.ContainsKey(row["TYPE_NAME"].ToString()))
                {
                    ac.AddLineSeries(row["TYPE_NAME"].ToString()
                            , row["TYPE_NAME"].ToString(), "", false, acChartControl.SeriesPointType.NUMBER, DevExpress.XtraCharts.ViewType.Line);

                    Series series = ac.SeriesDic[row["TYPE_NAME"].ToString()];

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
                    ac.AddSeriesPoint(row["TYPE_NAME"].ToString(), sp);

                    SeriesPoint sp2 = new SeriesPoint("[2월]", new double[] { row["WORK_2"].toDouble() });
                    ac.AddSeriesPoint(row["TYPE_NAME"].ToString(), sp2);

                    SeriesPoint sp3 = new SeriesPoint("[3월]", new double[] { row["WORK_3"].toDouble() });
                    ac.AddSeriesPoint(row["TYPE_NAME"].ToString(), sp3);

                    SeriesPoint sp4 = new SeriesPoint("[4월]", new double[] { row["WORK_4"].toDouble() });
                    ac.AddSeriesPoint(row["TYPE_NAME"].ToString(), sp4);

                    SeriesPoint sp5 = new SeriesPoint("[5월]", new double[] { row["WORK_5"].toDouble() });
                    ac.AddSeriesPoint(row["TYPE_NAME"].ToString(), sp5);

                    SeriesPoint sp6 = new SeriesPoint("[6월]", new double[] { row["WORK_6"].toDouble() });
                    ac.AddSeriesPoint(row["TYPE_NAME"].ToString(), sp6);

                    SeriesPoint sp7 = new SeriesPoint("[7월]", new double[] { row["WORK_7"].toDouble() });
                    ac.AddSeriesPoint(row["TYPE_NAME"].ToString(), sp7);

                    SeriesPoint sp8 = new SeriesPoint("[8월]", new double[] { row["WORK_8"].toDouble() });
                    ac.AddSeriesPoint(row["TYPE_NAME"].ToString(), sp8);

                    SeriesPoint sp9 = new SeriesPoint("[9월]", new double[] { row["WORK_9"].toDouble() });
                    ac.AddSeriesPoint(row["TYPE_NAME"].ToString(), sp9);

                    SeriesPoint sp10 = new SeriesPoint("[10월]", new double[] { row["WORK_10"].toDouble() });
                    ac.AddSeriesPoint(row["TYPE_NAME"].ToString(), sp10);

                    SeriesPoint sp11 = new SeriesPoint("[11월]", new double[] { row["WORK_11"].toDouble() });
                    ac.AddSeriesPoint(row["TYPE_NAME"].ToString(), sp11);

                    SeriesPoint sp12 = new SeriesPoint("[12월]", new double[] { row["WORK_12"].toDouble() });
                    ac.AddSeriesPoint(row["TYPE_NAME"].ToString(), sp12);

                }
            }
        }

        void setChart3(acChartControl ac, DataTable rslt)
        {
            ac.ClearSeries();
            ac.ClearSeriesPoint();

            ac.chartControl.PaletteName = "Metro";//Metro
            ac.chartControl.Titles[0].Text = "[불량률 현황]";
            ac.chartControl.Titles[0].Visibility = DevExpress.Utils.DefaultBoolean.True;
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

                if (!ac.SeriesDic.ContainsKey("R_RATE")
                    && !ac.SeriesDic.ContainsKey("M_RATE"))
                {
                    ac.AddLineSeries("R_RATE"
                            , "수정", "", false, acChartControl.SeriesPointType.PERCENT, DevExpress.XtraCharts.ViewType.Line);

                    ac.AddLineSeries("M_RATE"
                                , "재가공", "", false, acChartControl.SeriesPointType.PERCENT, DevExpress.XtraCharts.ViewType.Line);

                    Series series = ac.SeriesDic["R_RATE"];
                    series.CrosshairLabelPattern = "{S} : {V:P2}";

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
                    psLabel.TextPattern = "{V:P2}";
                    psLabel.Font = new Font("맑은 고딕", 10,
                        FontStyle.Bold, DevExpress.Utils.AppearanceObject.DefaultFont.Unit);


                    Series series2 = ac.SeriesDic["M_RATE"];
                    series2.CrosshairLabelPattern = "{S} : {V:P2}";

                    LineSeriesView lsView2 = (LineSeriesView)series2.View;

                    if (lsView2 != null)
                    {
                        //lsView2.LineMarkerOptions.Kind = MarkerKind.Circle;
                        lsView2.MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;
                        //ac.chartControl.Series[2].CrosshairLabelPattern = "{S} : {V:F3}";
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
                ac.AddSeriesPoint("R_RATE", sp);

                SeriesPoint sp2 = new SeriesPoint("[" + (i + 1).ToString() + "월]", new double[] { row["M_RATE"].toDouble() });
                ac.AddSeriesPoint("M_RATE", sp2);

                i++;
            }
        }

        void setChart4(acChartControl ac, DataTable rslt)
        {
            ac.ClearSeries();
            ac.ClearSeriesPoint();

            ac.chartControl.PaletteName = "Metro";//Metro
            ac.chartControl.Titles[0].Text = "[매출현황]";
            ac.chartControl.Titles[0].Visibility = DevExpress.Utils.DefaultBoolean.True;
            ac.chartControl.Legend.AlignmentVertical = LegendAlignmentVertical.TopOutside;
            ac.chartControl.Legend.AlignmentHorizontal = LegendAlignmentHorizontal.Right;
            ac.chartControl.Legend.Direction = LegendDirection.LeftToRight;

            //차트 설정
            XYDiagram diagram1 = ac.chartControl.Diagram as XYDiagram;
            if (diagram1 != null)
            {
                diagram1.AxisY.Label.TextPattern = "{V:N0}";
                diagram1.AxisX.Label.Visible = true;
                diagram1.AxisY.Interlaced = true;
                diagram1.AxisY.GridLines.Color = ColorTranslator.FromHtml("#8E8E8E"); //Color.WhiteSmoke;
            }

            foreach (DataRow row in rslt.Rows)
            {
                if (!ac.SeriesDic.ContainsKey(row["GUBUN"].ToString()))
                {
                    ac.AddLineSeries(acInfo.StdCodes.GetNameByCode("V001", row["GUBUN"].ToString())
                            , acInfo.StdCodes.GetNameByCode("V001", row["GUBUN"].ToString()), "", false, acChartControl.SeriesPointType.NUMBER, DevExpress.XtraCharts.ViewType.Line);

                    Series series = ac.SeriesDic[acInfo.StdCodes.GetNameByCode("V001", row["GUBUN"].ToString())];

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
                    psLabel.TextPattern = "{V:N2}";
                    if (row["GUBUN"].ToString() == "01") psLabel.TextPattern = "{V:N0}";
                    psLabel.Font = new Font("맑은 고딕", 10,
                        FontStyle.Bold, DevExpress.Utils.AppearanceObject.DefaultFont.Unit);

                    if (row["GUBUN"].ToString() == "01")
                    {
                        SeriesPoint sp = new SeriesPoint("[1월]", new double[] { row["JAN_01"].toDouble() });
                        ac.AddSeriesPoint(acInfo.StdCodes.GetNameByCode("V001", row["GUBUN"].ToString()), sp);

                        SeriesPoint sp2 = new SeriesPoint("[2월]", new double[] { row["FEB_01"].toDouble() });
                        ac.AddSeriesPoint(acInfo.StdCodes.GetNameByCode("V001", row["GUBUN"].ToString()), sp2);

                        SeriesPoint sp3 = new SeriesPoint("[3월]", new double[] { row["MAR_01"].toDouble() });
                        ac.AddSeriesPoint(acInfo.StdCodes.GetNameByCode("V001", row["GUBUN"].ToString()), sp3);

                        SeriesPoint sp4 = new SeriesPoint("[4월]", new double[] { row["APR_01"].toDouble() });
                        ac.AddSeriesPoint(acInfo.StdCodes.GetNameByCode("V001", row["GUBUN"].ToString()), sp4);

                        SeriesPoint sp5 = new SeriesPoint("[5월]", new double[] { row["MAY_01"].toDouble() });
                        ac.AddSeriesPoint(acInfo.StdCodes.GetNameByCode("V001", row["GUBUN"].ToString()), sp5);

                        SeriesPoint sp6 = new SeriesPoint("[6월]", new double[] { row["JUN_01"].toDouble() });
                        ac.AddSeriesPoint(acInfo.StdCodes.GetNameByCode("V001", row["GUBUN"].ToString()), sp6);

                        SeriesPoint sp7 = new SeriesPoint("[7월]", new double[] { row["JUL_01"].toDouble() });
                        ac.AddSeriesPoint(acInfo.StdCodes.GetNameByCode("V001", row["GUBUN"].ToString()), sp7);

                        SeriesPoint sp8 = new SeriesPoint("[8월]", new double[] { row["AUG_01"].toDouble() });
                        ac.AddSeriesPoint(acInfo.StdCodes.GetNameByCode("V001", row["GUBUN"].ToString()), sp8);

                        SeriesPoint sp9 = new SeriesPoint("[9월]", new double[] { row["SEP_01"].toDouble() });
                        ac.AddSeriesPoint(acInfo.StdCodes.GetNameByCode("V001", row["GUBUN"].ToString()), sp9);

                        SeriesPoint sp10 = new SeriesPoint("[10월]", new double[] { row["OCT_01"].toDouble() });
                        ac.AddSeriesPoint(acInfo.StdCodes.GetNameByCode("V001", row["GUBUN"].ToString()), sp10);

                        SeriesPoint sp11 = new SeriesPoint("[11월]", new double[] { row["NOV_01"].toDouble() });
                        ac.AddSeriesPoint(acInfo.StdCodes.GetNameByCode("V001", row["GUBUN"].ToString()), sp11);

                        SeriesPoint sp12 = new SeriesPoint("[12월]", new double[] { row["DEC_01"].toDouble() });
                        ac.AddSeriesPoint(acInfo.StdCodes.GetNameByCode("V001", row["GUBUN"].ToString()), sp12);
                    }
                    else
                    {
                        SeriesPoint sp = new SeriesPoint("[1월]", new double[] { row["JAN_02"].toDouble() });
                        ac.AddSeriesPoint(acInfo.StdCodes.GetNameByCode("V001", row["GUBUN"].ToString()), sp);

                        SeriesPoint sp2 = new SeriesPoint("[2월]", new double[] { row["FEB_02"].toDouble() });
                        ac.AddSeriesPoint(acInfo.StdCodes.GetNameByCode("V001", row["GUBUN"].ToString()), sp2);

                        SeriesPoint sp3 = new SeriesPoint("[3월]", new double[] { row["MAR_02"].toDouble() });
                        ac.AddSeriesPoint(acInfo.StdCodes.GetNameByCode("V001", row["GUBUN"].ToString()), sp3);

                        SeriesPoint sp4 = new SeriesPoint("[4월]", new double[] { row["APR_02"].toDouble() });
                        ac.AddSeriesPoint(acInfo.StdCodes.GetNameByCode("V001", row["GUBUN"].ToString()), sp4);

                        SeriesPoint sp5 = new SeriesPoint("[5월]", new double[] { row["MAY_02"].toDouble() });
                        ac.AddSeriesPoint(acInfo.StdCodes.GetNameByCode("V001", row["GUBUN"].ToString()), sp5);

                        SeriesPoint sp6 = new SeriesPoint("[6월]", new double[] { row["JUN_02"].toDouble() });
                        ac.AddSeriesPoint(acInfo.StdCodes.GetNameByCode("V001", row["GUBUN"].ToString()), sp6);

                        SeriesPoint sp7 = new SeriesPoint("[7월]", new double[] { row["JUL_02"].toDouble() });
                        ac.AddSeriesPoint(acInfo.StdCodes.GetNameByCode("V001", row["GUBUN"].ToString()), sp7);

                        SeriesPoint sp8 = new SeriesPoint("[8월]", new double[] { row["AUG_02"].toDouble() });
                        ac.AddSeriesPoint(acInfo.StdCodes.GetNameByCode("V001", row["GUBUN"].ToString()), sp8);

                        SeriesPoint sp9 = new SeriesPoint("[9월]", new double[] { row["SEP_02"].toDouble() });
                        ac.AddSeriesPoint(acInfo.StdCodes.GetNameByCode("V001", row["GUBUN"].ToString()), sp9);

                        SeriesPoint sp10 = new SeriesPoint("[10월]", new double[] { row["OCT_02"].toDouble() });
                        ac.AddSeriesPoint(acInfo.StdCodes.GetNameByCode("V001", row["GUBUN"].ToString()), sp10);

                        SeriesPoint sp11 = new SeriesPoint("[11월]", new double[] { row["NOV_02"].toDouble() });
                        ac.AddSeriesPoint(acInfo.StdCodes.GetNameByCode("V001", row["GUBUN"].ToString()), sp11);

                        SeriesPoint sp12 = new SeriesPoint("[12월]", new double[] { row["DEC_02"].toDouble() });
                        ac.AddSeriesPoint(acInfo.StdCodes.GetNameByCode("V001", row["GUBUN"].ToString()), sp12);
                    }

                    

                }
            }
        }


        void QuickException(object sender, QBiz qBiz, BizException ex)
        {

            acMessageBox.Show(this, ex);

        }


        void Search()
        {
            this.search();

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

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Search();
        }

        private void acBarButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //전체화면으로 보기
            try
            {
                BaseFullScreenMenu frm = new BaseFullScreenMenu();

                frm.Text = e.Item.Caption;

                frm.ShowFullScreen(this, this.pnlScreenBase);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }
    }
}
