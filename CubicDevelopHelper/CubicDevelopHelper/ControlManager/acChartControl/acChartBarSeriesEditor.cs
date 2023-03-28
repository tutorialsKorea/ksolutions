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
    public sealed partial class acChartBarSeriesEditor : BaseMenuDialog
    {


        public override void BarCodeScanInput(string barcode)
        {


        }

        private Dictionary<string, DevExpress.XtraCharts.Series> _SeriesDic = new Dictionary<string, Series>();

        private DevExpress.XtraCharts.ChartControl _Chart = null;

        public acChartBarSeriesEditor(DevExpress.XtraCharts.ChartControl chart, Dictionary<string, DevExpress.XtraCharts.Series> seriesDic)
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

            acGridView1.GridType = acGridView.emGridType.FIXED;

            acGridView1.AddHidden("SERIES_OBJECT", typeof(object));

            acGridView1.AddTextEdit("SERIES_NAME", "범례", "3V0OSHPG", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddCheckEdit("VISIBLE", "표시", "0VXIPFNO", true, true, true, acGridView.emCheckEditDataType._BOOL);

            acGridView1.AddColorEdit("COLOR", "색상", "40281", true, DevExpress.Utils.HorzAlignment.Center, true, true);


            acGridView1.AddCheckEdit("BORDER_VISIBLE", "테두리 표시", "7WUABOW4", true, true, true, acGridView.emCheckEditDataType._BOOL);

            acGridView1.AddColorEdit("BORDER_COLOR", "테두리 색상", "KN1005OS", true, DevExpress.Utils.HorzAlignment.Center, true, true);


            acGridView1.AddComboBoxEdit("FILL_MODE", "채우기 형태", "2IE4AX37", true, DevExpress.Utils.HorzAlignment.Center, true, true, false, fillModeList);

            acGridView1.AddComboBoxEdit("GRADIENT_MODE", "그라데이션", "IFXSSAZQ", true, DevExpress.Utils.HorzAlignment.Center, true, true, false, rectGradientModeList);

            acGridView1.AddColorEdit("GRADIENT_BACK_COLOR2", "그라데이션 두번째 배경색", "6D9FSL8T", true, DevExpress.Utils.HorzAlignment.Center, true, true);

            acGridView1.AddCheckEdit("SHADOW", "그림자 여부", "KPRYTWSC", true, true, true, acGridView.emCheckEditDataType._BOOL);

            acGridView1.OptionsView.ColumnAutoWidth = false;


            DataTable dt = acGridView1.NewTable();


            foreach (KeyValuePair<string, DevExpress.XtraCharts.Series> sr in this._SeriesDic)
            {
                SideBySideBarSeriesView srView = sr.Value.View as SideBySideBarSeriesView;

                DevExpress.XtraCharts.RectangleGradientFillOptions fillOption = srView.FillStyle.Options as DevExpress.XtraCharts.RectangleGradientFillOptions;


                DataRow row = dt.NewRow();
                row["SERIES_OBJECT"] = sr.Value;
                row["SERIES_NAME"] = sr.Value.Name;
                row["VISIBLE"] = sr.Value.Visible;
                row["COLOR"] = srView.Color.ToArgb();
                row["BORDER_VISIBLE"] = srView.Border.Visible;
                row["BORDER_COLOR"] = srView.Border.Color.ToArgb();

                row["FILL_MODE"] = srView.FillStyle.FillMode;

                if (fillOption != null)
                {
                    row["GRADIENT_MODE"] = fillOption.GradientMode;
                    row["GRADIENT_BACK_COLOR2"] = fillOption.Color2.ToArgb();
                }

                row["SHADOW"] = srView.Shadow.Visible;

                dt.Rows.Add(row);

            }

            acGridView1.GridControl.DataSource = dt;

            base.DialogInit();
        }



        void acGridView1_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            DataRow row = acGridView1.GetDataRow(e.RowHandle);

            DevExpress.XtraCharts.Series sr = row["SERIES_OBJECT"] as DevExpress.XtraCharts.Series;

            SideBySideBarSeriesView srView = sr.View as SideBySideBarSeriesView;

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

                case "BORDER_VISIBLE":
                    {
                        srView.Border.Visible = e.Value.toBoolean();
                    }

                    break;

                case "BORDER_COLOR":
                    {


                        srView.Border.Color = e.Value.toColor();

                        row["BORDER_COLOR"] = srView.Border.Color.ToArgb();
                    }

                    break;

                case "FILL_MODE":
                    {
                        srView.FillStyle.FillMode = (FillMode)e.Value;


                    }

                    break;

                case "GRADIENT_MODE":
                    {
                        DevExpress.XtraCharts.RectangleGradientFillOptions fillOption = srView.FillStyle.Options as DevExpress.XtraCharts.RectangleGradientFillOptions;

                        if (fillOption != null)
                        {
                            fillOption.GradientMode = (RectangleGradientMode)e.Value;

                        }
                    }
                    break;

                case "GRADIENT_BACK_COLOR2":
                    {
                        DevExpress.XtraCharts.RectangleGradientFillOptions fillOption = srView.FillStyle.Options as DevExpress.XtraCharts.RectangleGradientFillOptions;

                        if (fillOption != null)
                        {
                            fillOption.Color2 = e.Value.toColor();
                           
                        }

                        row["GRADIENT_BACK_COLOR2"] = e.Value.toColor().ToArgb();
                    }

                    break;

                case "SHADOW":
                    {
                        srView.Shadow.Visible = e.Value.toBoolean();
                    }

                    break;

            }


            acGridView1.UpdateCurrentRow();

        }


    }
}