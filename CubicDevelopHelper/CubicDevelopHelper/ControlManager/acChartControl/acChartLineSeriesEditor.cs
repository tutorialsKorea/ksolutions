using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using DevExpress.XtraCharts;
using System.Linq;

namespace ControlManager
{
    public sealed partial class acChartLineSeriesEditor : BaseMenuDialog
    {


        public override void BarCodeScanInput(string barcode)
        {


        }

        private Dictionary<string, DevExpress.XtraCharts.Series> _SeriesDic = new Dictionary<string, Series>();

        private DevExpress.XtraCharts.ChartControl _Chart = null;

        public acChartLineSeriesEditor(DevExpress.XtraCharts.ChartControl chart, Dictionary<string, DevExpress.XtraCharts.Series> seriesDic)
        {
            InitializeComponent();

            this._Chart = chart;

            this._SeriesDic = seriesDic;

            acGridView1.CellValueChanging += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(acGridView1_CellValueChanging);


        }




        public override void DialogInit()
        {
            acGridView1.GridType = acGridView.emGridType.FIXED;

            acGridView1.AddHidden("SERIES_OBJECT", typeof(object));

            acGridView1.AddTextEdit("SERIES_NAME", "범례", "3V0OSHPG", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddCheckEdit("VISIBLE", "표시", "0VXIPFNO", true, true, true, acGridView.emCheckEditDataType._BOOL);

            acGridView1.AddColorEdit("COLOR", "색상", "40281", true, DevExpress.Utils.HorzAlignment.Center, true, true);

            List<object> dashStyleList = Enum.GetValues(typeof(DashStyle)).Cast<object>().ToList();

            dashStyleList.Remove(DashStyle.Empty);


            acGridView1.AddComboBoxEdit("DASH_STYLE", "선 형태", "TOBO0VNP", true, DevExpress.Utils.HorzAlignment.Center, true, true, false, dashStyleList);


            acGridView1.AddCheckEdit("SHADOW", "그림자 여부", "KPRYTWSC", true, true, true, acGridView.emCheckEditDataType._BOOL);



            //라인마커

            acGridView1.AddColorEdit("LINE_MARKER_COLOR", "라인마커 색상", "QHRJLSPA", true, DevExpress.Utils.HorzAlignment.Center, true, true);

            List<object> lineMarkerfillModeList = Enum.GetValues(typeof(FillMode)).Cast<object>().ToList();


            acGridView1.AddComboBoxEdit("LINE_MARKER_FILL_MODE", "라인마커 채우기 형태", "BV8TWCF3", true, DevExpress.Utils.HorzAlignment.Center, true, true, false, lineMarkerfillModeList);

            acGridView1.AddColorEdit("LINE_MARKER_BORDER_COLOR", "라인마커 테두리 색상", "7ILGNI2H", true, DevExpress.Utils.HorzAlignment.Center, true, true);

            acGridView1.AddCheckEdit("LINE_MARKER_BORDER_VISIBLE", "라인마커 테두리 여부", "GQ05WDCT", true, true, true, acGridView.emCheckEditDataType._BOOL);



            acGridView1.AddCheckEdit("LINE_MARKER_VISIBLE", "라인마커 표시", "RQQADV2U", true, true, true, acGridView.emCheckEditDataType._BOOL);


            List<object> lineMarkerKindList = Enum.GetValues(typeof(MarkerKind)).Cast<object>().ToList();

            acGridView1.AddComboBoxEdit("LINE_MARKER_KIND", "라인마커 모양", "L0A5OYJW", true, DevExpress.Utils.HorzAlignment.Center, true, true, false, lineMarkerKindList);

            acGridView1.OptionsView.ColumnAutoWidth = false;


            DataTable dt = acGridView1.NewTable();


            foreach (KeyValuePair<string, DevExpress.XtraCharts.Series> sr in this._SeriesDic)
            {
                LineSeriesView srView = sr.Value.View as LineSeriesView;

                DataRow row = dt.NewRow();
                row["SERIES_OBJECT"] = sr.Value;
                row["SERIES_NAME"] = sr.Value.Name;
                row["VISIBLE"] = sr.Value.Visible;
                row["COLOR"] = srView.Color.ToArgb();
                row["DASH_STYLE"] = srView.LineStyle.DashStyle;
                row["SHADOW"] = srView.Shadow.Visible;

                row["LINE_MARKER_COLOR"] = srView.LineMarkerOptions.Color.ToArgb();

                row["LINE_MARKER_FILL_MODE"] = srView.LineMarkerOptions.FillStyle.FillMode;
                row["LINE_MARKER_BORDER_COLOR"] = srView.LineMarkerOptions.BorderColor.ToArgb();
                row["LINE_MARKER_BORDER_VISIBLE"] = srView.LineMarkerOptions.BorderVisible;

                row["LINE_MARKER_VISIBLE"] = srView.LineMarkerOptions.Visible;

                row["LINE_MARKER_KIND"] = srView.LineMarkerOptions.Kind;

                dt.Rows.Add(row);

            }

            acGridView1.GridControl.DataSource = dt;

            base.DialogInit();
        }



        void acGridView1_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            DataRow row = acGridView1.GetDataRow(e.RowHandle);

            DevExpress.XtraCharts.Series sr = row["SERIES_OBJECT"] as DevExpress.XtraCharts.Series;

            LineSeriesView srView = sr.View as LineSeriesView;

            switch (e.Column.FieldName)
            {
                case "VISIBLE":
                    {


                        sr.Visible = e.Value.toBoolean();

                    }
                    break;

                case "COLOR":
                    {


                        srView.Color = e.Value.toColor();

                        row["COLOR"] = srView.Color.ToArgb();

                    }

                    break;


                case "DASH_STYLE":
                    {

                        srView.LineStyle.DashStyle = (DashStyle)e.Value;
                    }

                    break;

                case "SHADOW":
                    {
                        srView.Shadow.Visible = e.Value.toBoolean();
                    }

                    break;

                case "LINE_MARKER_COLOR":
                    {
                        srView.LineMarkerOptions.Color = e.Value.toColor();
                        row["LINE_MARKER_COLOR"] = srView.LineMarkerOptions.Color.ToArgb();
  
                    }
                    break;

                case "LINE_MARKER_FILL_MODE":
                    {
                        srView.LineMarkerOptions.FillStyle.FillMode = (FillMode)e.Value;
                    }
                    break;

                case "LINE_MARKER_BORDER_COLOR":
                    {
                        srView.LineMarkerOptions.BorderColor = e.Value.toColor();
                        row["LINE_MARKER_BORDER_COLOR"] = srView.LineMarkerOptions.BorderColor.ToArgb();
                    }
                    break;

                case "LINE_MARKER_BORDER_VISIBLE":
                    {
                        srView.LineMarkerOptions.BorderVisible = e.Value.toBoolean();
                    }
                    break;

                case "LINE_MARKER_VISIBLE":
                    {
                        srView.LineMarkerOptions.Visible = e.Value.toBoolean();
                    }
                    break;

                case "LINE_MARKER_KIND":
                    {
                        srView.LineMarkerOptions.Kind = (MarkerKind)e.Value;
                    }
                    break;
            }


 

            acGridView1.UpdateCurrentRow();

        }



    }
}