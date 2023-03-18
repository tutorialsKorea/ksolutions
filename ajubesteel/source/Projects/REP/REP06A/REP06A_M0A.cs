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
    public sealed partial class REP06A_M0A : BaseMenu
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



        public REP06A_M0A()
        {
            InitializeComponent();

            acLayoutControl1.OnValueKeyDown += new acLayoutControl.ValueKeyDownEventHandler(acLayoutControl1_OnValueKeyDown);

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
            acGridView1.AddTextEdit("TYPE", "유  형", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("WORK_1", "1월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("WORK_2", "2월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("WORK_3", "3월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("WORK_4", "4월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("WORK_5", "5월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("WORK_6", "6월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("WORK_7", "7월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("WORK_8", "8월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("WORK_9", "9월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("WORK_10", "10월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("WORK_11", "11월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("WORK_12", "12월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("WORK_SUM", "합계", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView2.GridType = acGridView.emGridType.LIST;
            acGridView2.AddTextEdit("TYPE", "유  형", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("WORK_1", "1월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("WORK_2", "2월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("WORK_3", "3월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("WORK_4", "4월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("WORK_5", "5월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("WORK_6", "6월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("WORK_7", "7월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("WORK_8", "8월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("WORK_9", "9월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("WORK_10", "10월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("WORK_11", "11월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("WORK_12", "12월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);
            //acGridView2.AddTextEdit("WORK_SUM", "합계", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);

            acDateEdit1.DateTime = acDateEdit.GetNowFirstDate();

            acDateEdit1.Properties.EditMask = "yyyy";

            acChartControl1.isEvent = false;
            acChartControl2.isEvent = false;

            base.MenuInit();


        }

        public override void ChildContainerInit(Control sender)
        {
            //기본값 설정

            if (sender == acLayoutControl1)
            {
                acLayoutControl layout = sender as acLayoutControl;

                layout.GetEditor("YEAR").Value = acDateEdit.GetNowFirstDate();

            }

            base.ChildContainerInit(sender);
        }

        void Search()
        {
            DataRow layoutRow = acLayoutControl1.CreateParameterRow();

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String));
            paramTable.Columns.Add("YEAR", typeof(String));


            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["YEAR"] = layoutRow["YEAR"];

            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD, "REP06A_SER", paramSet, "RQSTDT", "RSLTDT, RSLTDT2. RSLTDT3",
               QuickSearch,
               QuickException);
        }

        void QuickSearch(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
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
                    diagram1.AxisY.Label.TextPattern = "{V:N1}%";
                    diagram1.AxisX.Label.Visible = true;
                    //diagram1.AxisX.Label.Angle = -30;
                    diagram1.AxisY.Interlaced = true;
                    diagram1.AxisY.GridLines.Color = ColorTranslator.FromHtml("#8E8E8E"); //Color.WhiteSmoke;
                }

                foreach (DataRow row in e.result.Tables["RSLTDT"].Rows)
                {
                    if (row["FLAG"].ToString() != "RATE") continue;

                    if (!acChartControl1.SeriesDic.ContainsKey(row["TYPE"].ToString()))
                    {
                        acChartControl1.AddLineSeries(row["TYPE"].ToString()
                                , row["TYPE"].ToString(), "", false, acChartControl.SeriesPointType.NUMBER, DevExpress.XtraCharts.ViewType.Bar);

                        Series series = acChartControl1.SeriesDic[row["TYPE"].ToString()];
                        series.CrosshairLabelPattern = "{S} : {V:N1}%";
                        //LineSeriesView lsView = (LineSeriesView)series.View;

                        //if (lsView != null)
                        //{
                        //    //lsView.LineMarkerOptions.Kind = MarkerKind.Circle;
                        //    lsView.MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;
                        //    //acChartControl1.chartControl.Series[2].CrosshairLabelPattern = "{S} : {V:F3}";
                        //}

                        series.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
                        //PointSeriesLabel psLabel = (PointSeriesLabel)series.Label;
                        //psLabel.BackColor = Color.Transparent;
                        //psLabel.Border.Visibility = DevExpress.Utils.DefaultBoolean.False;
                        //psLabel.Shadow.Visible = false;
                        ////psLabel.TextColor = Color.DarkSlateGray;
                        //psLabel.ResolveOverlappingMode = ResolveOverlappingMode.Default;
                        //psLabel.TextPattern = "{V:N0}%";
                        //psLabel.Font = new Font("맑은 고딕", 10,
                        //    FontStyle.Bold, DevExpress.Utils.AppearanceObject.DefaultFont.Unit);

                        BarSeriesLabel bsLabel = (BarSeriesLabel)series.Label;
                        //bsLabel.BackColor = Color.Transparent;
                        bsLabel.Border.Visibility = DevExpress.Utils.DefaultBoolean.False;
                        bsLabel.Shadow.Visible = false;
                        bsLabel.ResolveOverlappingMode = ResolveOverlappingMode.Default;
                        bsLabel.TextPattern = "{V:N1}%";
                        bsLabel.Font = new Font("맑은 고딕", 10,
                        FontStyle.Bold, DevExpress.Utils.AppearanceObject.DefaultFont.Unit);

                        foreach (Series s in acChartControl1.SeriesDic.Values)
                        {
                            SideBySideBarSeriesView view = s.View as SideBySideBarSeriesView;
                            if (view == null) continue;
                            view.FillStyle.FillMode = FillMode.Solid;
                            view.Color = Color.LightGreen;
                        }

                        SeriesPoint sp = new SeriesPoint("[1월]", new double[] { row["WORK_1_D"].toDouble() });
                        acChartControl1.AddSeriesPoint(row["TYPE"].ToString(), sp);

                        SeriesPoint sp2 = new SeriesPoint("[2월]", new double[] { row["WORK_2_D"].toDouble() });
                        acChartControl1.AddSeriesPoint(row["TYPE"].ToString(), sp2);

                        SeriesPoint sp3 = new SeriesPoint("[3월]", new double[] { row["WORK_3_D"].toDouble() });
                        acChartControl1.AddSeriesPoint(row["TYPE"].ToString(), sp3);

                        SeriesPoint sp4 = new SeriesPoint("[4월]", new double[] { row["WORK_4_D"].toDouble() });
                        acChartControl1.AddSeriesPoint(row["TYPE"].ToString(), sp4);

                        SeriesPoint sp5 = new SeriesPoint("[5월]", new double[] { row["WORK_5_D"].toDouble() });
                        acChartControl1.AddSeriesPoint(row["TYPE"].ToString(), sp5);

                        SeriesPoint sp6 = new SeriesPoint("[6월]", new double[] { row["WORK_6_D"].toDouble() });
                        acChartControl1.AddSeriesPoint(row["TYPE"].ToString(), sp6);

                        SeriesPoint sp7 = new SeriesPoint("[7월]", new double[] { row["WORK_7_D"].toDouble() });
                        acChartControl1.AddSeriesPoint(row["TYPE"].ToString(), sp7);

                        SeriesPoint sp8 = new SeriesPoint("[8월]", new double[] { row["WORK_8_D"].toDouble() });
                        acChartControl1.AddSeriesPoint(row["TYPE"].ToString(), sp8);

                        SeriesPoint sp9 = new SeriesPoint("[9월]", new double[] { row["WORK_9_D"].toDouble() });
                        acChartControl1.AddSeriesPoint(row["TYPE"].ToString(), sp9);

                        SeriesPoint sp10 = new SeriesPoint("[10월]", new double[] { row["WORK_10_D"].toDouble() });
                        acChartControl1.AddSeriesPoint(row["TYPE"].ToString(), sp10);

                        SeriesPoint sp11 = new SeriesPoint("[11월]", new double[] { row["WORK_11_D"].toDouble() });
                        acChartControl1.AddSeriesPoint(row["TYPE"].ToString(), sp11);

                        SeriesPoint sp12 = new SeriesPoint("[12월]", new double[] { row["WORK_12_D"].toDouble() });
                        acChartControl1.AddSeriesPoint(row["TYPE"].ToString(), sp12);

                    }
                }

                acGridView1.GridControl.DataSource = e.result.Tables["RSLTDT"];



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
                    diagram2.AxisY.Label.TextPattern = "{V:N1}";
                    diagram2.AxisX.Label.Visible = true;
                    //diagram2.AxisX.Label.Angle = -30;
                    diagram2.AxisY.Interlaced = true;
                    diagram2.AxisY.GridLines.Color = ColorTranslator.FromHtml("#8E8E8E"); //Color.WhiteSmoke;
                }

                foreach (DataRow row in e.result.Tables["RSLTDT2"].Rows)
                {
                    if (!acChartControl2.SeriesDic.ContainsKey(row["TYPE"].ToString()))
                    {
                        acChartControl2.AddLineSeries(row["TYPE"].ToString()
                                , row["TYPE"].ToString(), "", false, acChartControl.SeriesPointType.NUMBER, DevExpress.XtraCharts.ViewType.Bar);

                        Series series = acChartControl2.SeriesDic[row["TYPE"].ToString()];
                        series.CrosshairLabelPattern = "{S} : {V:N1}%";

                        //LineSeriesView lsView = (LineSeriesView)series.View;

                        //if (lsView != null)
                        //{
                        //    //lsView.LineMarkerOptions.Kind = MarkerKind.Circle;
                        //    lsView.MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;
                        //    //acChartControl2.chartControl.Series[2].CrosshairLabelPattern = "{S} : {V:F3}";
                        //}
                        series.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
                        //PointSeriesLabel psLabel = (PointSeriesLabel)series.Label;
                        //psLabel.BackColor = Color.Transparent;
                        //psLabel.Border.Visibility = DevExpress.Utils.DefaultBoolean.False;
                        //psLabel.Shadow.Visible = false;
                        ////psLabel.TextColor = Color.DarkSlateGray;
                        //psLabel.ResolveOverlappingMode = ResolveOverlappingMode.Default;
                        //psLabel.TextPattern = "{V:N0}";
                        //psLabel.Font = new Font("맑은 고딕", 10,
                        //    FontStyle.Bold, DevExpress.Utils.AppearanceObject.DefaultFont.Unit);


                        BarSeriesLabel bsLabel = (BarSeriesLabel)series.Label;
                        //bsLabel.BackColor = Color.Transparent;
                        bsLabel.Border.Visibility = DevExpress.Utils.DefaultBoolean.False;
                        bsLabel.Shadow.Visible = false;
                        bsLabel.ResolveOverlappingMode = ResolveOverlappingMode.Default;
                        bsLabel.TextPattern = "{V:N1}";
                        bsLabel.Font = new Font("맑은 고딕", 10,
                        FontStyle.Bold, DevExpress.Utils.AppearanceObject.DefaultFont.Unit);

                        foreach (Series s in acChartControl2.SeriesDic.Values)
                        {
                            SideBySideBarSeriesView view = s.View as SideBySideBarSeriesView;
                            if (view == null) continue;
                            view.FillStyle.FillMode = FillMode.Solid;
                            view.Color = Color.LightGreen;
                        }


                        SeriesPoint sp = new SeriesPoint("[1월]", new double[] { row["WORK_1_D"].toDouble() });
                        acChartControl2.AddSeriesPoint(row["TYPE"].ToString(), sp);

                        SeriesPoint sp2 = new SeriesPoint("[2월]", new double[] { row["WORK_2_D"].toDouble() });
                        acChartControl2.AddSeriesPoint(row["TYPE"].ToString(), sp2);

                        SeriesPoint sp3 = new SeriesPoint("[3월]", new double[] { row["WORK_3_D"].toDouble() });
                        acChartControl2.AddSeriesPoint(row["TYPE"].ToString(), sp3);

                        SeriesPoint sp4 = new SeriesPoint("[4월]", new double[] { row["WORK_4_D"].toDouble() });
                        acChartControl2.AddSeriesPoint(row["TYPE"].ToString(), sp4);

                        SeriesPoint sp5 = new SeriesPoint("[5월]", new double[] { row["WORK_5_D"].toDouble() });
                        acChartControl2.AddSeriesPoint(row["TYPE"].ToString(), sp5);

                        SeriesPoint sp6 = new SeriesPoint("[6월]", new double[] { row["WORK_6_D"].toDouble() });
                        acChartControl2.AddSeriesPoint(row["TYPE"].ToString(), sp6);

                        SeriesPoint sp7 = new SeriesPoint("[7월]", new double[] { row["WORK_7_D"].toDouble() });
                        acChartControl2.AddSeriesPoint(row["TYPE"].ToString(), sp7);

                        SeriesPoint sp8 = new SeriesPoint("[8월]", new double[] { row["WORK_8_D"].toDouble() });
                        acChartControl2.AddSeriesPoint(row["TYPE"].ToString(), sp8);

                        SeriesPoint sp9 = new SeriesPoint("[9월]", new double[] { row["WORK_9_D"].toDouble() });
                        acChartControl2.AddSeriesPoint(row["TYPE"].ToString(), sp9);

                        SeriesPoint sp10 = new SeriesPoint("[10월]", new double[] { row["WORK_10_D"].toDouble() });
                        acChartControl2.AddSeriesPoint(row["TYPE"].ToString(), sp10);

                        SeriesPoint sp11 = new SeriesPoint("[11월]", new double[] { row["WORK_11_D"].toDouble() });
                        acChartControl2.AddSeriesPoint(row["TYPE"].ToString(), sp11);

                        SeriesPoint sp12 = new SeriesPoint("[12월]", new double[] { row["WORK_12_D"].toDouble() });
                        acChartControl2.AddSeriesPoint(row["TYPE"].ToString(), sp12);

                    }
                }

                acGridView2.GridControl.DataSource = e.result.Tables["RSLTDT2"];


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

        void QuickMultiException(object sender, QBizMulti QBiz, BizManager.BizException ex)
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

        private void acBarButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //상세설정
            if (!base.ChildFormContains("NEW"))
            {

                REP06A_D0A frm = new REP06A_D0A();

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
    }
}