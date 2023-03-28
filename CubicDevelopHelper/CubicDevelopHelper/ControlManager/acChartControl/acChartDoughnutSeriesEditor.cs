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
    public sealed partial class acChartDoughnutSeriesEditor : BaseMenuDialog
    {


        public override void BarCodeScanInput(string barcode)
        {


        }

        private Dictionary<string, DevExpress.XtraCharts.Series> _SeriesDic = new Dictionary<string, Series>();

        private DevExpress.XtraCharts.ChartControl _Chart = null;

        public acChartDoughnutSeriesEditor(DevExpress.XtraCharts.ChartControl chart , Dictionary<string, DevExpress.XtraCharts.Series> seriesDic)
        {
            InitializeComponent();

            this._Chart = chart;

            this._SeriesDic = seriesDic;

            acGridView1.CellValueChanging += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(acGridView1_CellValueChanging);


        }




        public override void DialogInit()
        {
            List<object> fillModeList = Enum.GetValues(typeof(FillMode)).Cast<object>().ToList();

            List<object> rectGradientModeList = Enum.GetValues(typeof(DevExpress.XtraCharts.RectangleGradientMode)).Cast<object>().ToList();

            List<object> explodeModeList = Enum.GetValues(typeof(PieExplodeMode)).Cast<object>().ToList();


            acGridView1.GridType = acGridView.emGridType.FIXED;

            acGridView1.AddHidden("SERIES_OBJECT", typeof(object));

            acGridView1.AddTextEdit("SERIES_NAME", "범례", "3V0OSHPG", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddCheckEdit("VISIBLE", "표시", "0VXIPFNO", true, true, true, acGridView.emCheckEditDataType._BOOL);

            acGridView1.AddColorEdit("BORDER_COLOR", "테두리 색상", "KN1005OS", true, DevExpress.Utils.HorzAlignment.Center, true, true);

            acGridView1.AddCheckEdit("BORDER_VISIBLE", "테두리 표시", "7WUABOW4", true, true, true, acGridView.emCheckEditDataType._BOOL);


            acGridView1.AddComboBoxEdit("FILL_MODE", "채우기 형태", "2IE4AX37", true, DevExpress.Utils.HorzAlignment.Center, true, true, false, fillModeList);


            acGridView1.AddComboBoxEdit("EXPLODE_MODE", "Explode Mode", "VZMP97ZB", true, DevExpress.Utils.HorzAlignment.Center, true, true, false, explodeModeList);

            acGridView1.OptionsView.ColumnAutoWidth = false;


            DataTable dt = acGridView1.NewTable();


            foreach (KeyValuePair<string, DevExpress.XtraCharts.Series> sr in this._SeriesDic)
            {
                DoughnutSeriesView srView = sr.Value.View as DoughnutSeriesView;

                DataRow row = dt.NewRow();
                row["SERIES_OBJECT"] = sr.Value;
                row["SERIES_NAME"] = sr.Value.Name;
                row["VISIBLE"] = sr.Value.Visible;

                row["BORDER_COLOR"] = srView.Border.Color.ToArgb();
                row["BORDER_VISIBLE"] = srView.Border.Visible;

                row["FILL_MODE"] = srView.FillStyle.FillMode;
                

                row["EXPLODE_MODE"] = srView.ExplodeMode;

                dt.Rows.Add(row);

            }

            acGridView1.GridControl.DataSource = dt;

            base.DialogInit();
        }



        void acGridView1_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            DataRow row = acGridView1.GetDataRow(e.RowHandle);

            DevExpress.XtraCharts.Series sr = row["SERIES_OBJECT"] as DevExpress.XtraCharts.Series;

            DoughnutSeriesView srView = sr.View as DoughnutSeriesView;


            switch (e.Column.FieldName)
            {
                case "VISIBLE":
                    {


                        sr.Visible = e.Value.toBoolean();

                    }
                    break;

                case "BORDER_COLOR":
                    {

                        srView.Border.Color = e.Value.toColor();

                        row["BORDER_COLOR"] = srView.Border.Color.ToArgb();
                    }

                    break;

                case "BORDER_VISIBLE":
                    {
                        srView.Border.Visible = e.Value.toBoolean();

                    }
                    break;

                case "FILL_MODE":
                    {
                        srView.FillStyle.FillMode = (FillMode)e.Value;

                    }
                    break;



                case "EXPLODE_MODE":
                    {
                        srView.ExplodeMode = (PieExplodeMode)e.Value;
                    }

                    break;

            }


            acGridView1.UpdateCurrentRow();

        }


    }
}