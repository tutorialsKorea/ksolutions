using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using DevExpress.XtraCharts;

namespace ControlManager
{
    public class acChartUserConfig
    {

        private acChartControl _ChartControl = null;

        private byte[] _DefaultLayout = null;


        public acChartUserConfig(acChartControl chart)
        {

            _ChartControl = chart;

            MemoryStream layoutStream = new MemoryStream();

            this._ChartControl._Chart.SaveToStream(layoutStream);

            this._DefaultLayout = layoutStream.ToArray();

            layoutStream.Close();

        }


        private string _ConfigName = null;

        public string ConfigName
        {
            get { return _ConfigName; }
            set { _ConfigName = value; }
        }


        private string _ConfigMaKer = null;

        public string ConfigMaKer
        {
            get { return _ConfigMaKer; }
            set { _ConfigMaKer = value; }
        }


        public byte[] SaveLayout()
        {
            MemoryStream layoutStream = new MemoryStream();

            this._ChartControl._Chart.SaveToStream(layoutStream);

            byte[] layoutArray = layoutStream.ToArray();

            layoutStream.Close();

            return layoutArray;

        }

        public void LoadDefaultLayout()
        {
            MemoryStream layoutSt = new MemoryStream(this._DefaultLayout, 0, this._DefaultLayout.Length);

            this._ChartControl._Chart.LoadFromStream(layoutSt);

            this._ConfigName = null;
            this._ConfigMaKer = null;

            layoutSt.Close();


            this.Restore();



        }


        void Restore()
        {
            //레이아웃 수정으로 인한 시리즈 복원


            Dictionary<string, DevExpress.XtraCharts.Series> tempSeriesDic = new Dictionary<string, DevExpress.XtraCharts.Series>();

            foreach (KeyValuePair<string, DevExpress.XtraCharts.Series> series in this._ChartControl.SeriesDic)
            {

                this._ChartControl._Chart.Series[this._ChartControl._SeriesIndexDic[series.Key]].Tag = series.Value.Tag;

                tempSeriesDic.Add(series.Key, this._ChartControl._Chart.Series[this._ChartControl._SeriesIndexDic[series.Key]]);


            }

            //시리즈 포인트도 새로추가해야함 

            Dictionary<string, List<SeriesPoint>> tempSeriesPoints = new Dictionary<string, List<SeriesPoint>>();

            foreach (KeyValuePair<string, DevExpress.XtraCharts.Series> series in this._ChartControl.SeriesDic)
            {
                List<SeriesPoint> points = new List<SeriesPoint>();
        
                foreach (SeriesPoint sp in series.Value.Points)
                {
                    SeriesPoint tempSp = (SeriesPoint)sp.Clone();

                    
                    points.Add(tempSp);

                }

                tempSeriesPoints.Add(series.Key, points);

                tempSeriesDic[series.Key].Points.Clear();

            }


            foreach (KeyValuePair<string, List<SeriesPoint>> sp in tempSeriesPoints)
            {

                foreach (SeriesPoint pt in sp.Value)
                {
                    tempSeriesDic[sp.Key].Points.Add(pt);
                }
            }



            this._ChartControl._SeriesDic = tempSeriesDic;

            this._ChartControl._Chart.RefreshData();

        }


        public void LoadLayout(object configName, object configMaker, byte[] layout)
        {
            MemoryStream layoutSt = new MemoryStream(layout, 0, layout.Length);

            this._ChartControl._Chart.LoadFromStream(layoutSt);

            this._ConfigName = (string)configName;
            this._ConfigMaKer = (string)configMaker;

            layoutSt.Close();


            this.Restore();


        }

    }
}
