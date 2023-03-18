using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.Utils.Menu;
using DevExpress.XtraCharts;
using DevExpress.XtraPrinting;
using DevExpress.Utils;
using BizManager;

namespace ControlManager
{
    public class ChartControlEx : DevExpress.XtraCharts.ChartControl
    {
        public ChartControlEx()
            : base()
        {

        }

        private bool _ShowMenu = false;

        public bool ShowMenu
        {
            get { return _ShowMenu; }
            set { _ShowMenu = value; }
        }

        private MouseEventArgs _MouseEventArgs = null;

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WIN32API.WM_CONTEXTMENU)
            {
                Point pt = new Point(m.LParam.ToInt32());

                Point cpt = this.PointToClient(pt);


                this._ShowMenu = true;


                if (_MouseEventArgs != null)
                {
                    base.OnMouseDown(_MouseEventArgs);
                }


                this._ShowMenu = false;

            }

            base.WndProc(ref m);
        }

        protected override void OnMouseDown(MouseEventArgs ee)
        {
            this._MouseEventArgs = ee;

            base.OnMouseDown(ee);
        }
    }



    public sealed partial class acChartControl : DevExpress.XtraEditors.XtraUserControl
    {


        internal acChartUserConfig _Config = null;

        internal ChartControlEx _Chart = null;

        public ChartControl chartControl = null;

        public ToolTipController toolControl = null;

        private System.Windows.Forms.Timer _VisibleTimer = null;

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Title
        {
            get
            {
                return this.chartControl1.Titles[0].Text;
            }
            set
            {
                this.chartControl1.Titles[0].Text = value;
            }

        }

        private bool _isEvent = true;

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool isEvent 
        {
            get
            {
                return _isEvent;
            }
            set
            {
                _isEvent = value;

                if (!_isEvent)
                {
                    chartControl1.ObjectHotTracked -= new HotTrackEventHandler(chartControl1_ObjectHotTracked);
                }
            }

        }

        public acChartControl()
        {
            InitializeComponent();


            _Chart = chartControl1;

            chartControl = chartControl1;

            toolControl = toolTipController1;

            this._VisibleTimer = new System.Windows.Forms.Timer();

            this._VisibleTimer.Interval = 100;


            chartControl1.MouseDown += new MouseEventHandler(chartControl1_MouseDown);

            popupMenu1.BeforePopup += new CancelEventHandler(popupMenu1_BeforePopup);

            this.VisibleChanged += new EventHandler(acChartControl_VisibleChanged);

            this._VisibleTimer.Tick += new EventHandler(VisibleTimer_Tick);

            chartControl1.ObjectHotTracked += new HotTrackEventHandler(chartControl1_ObjectHotTracked);
        }


        void chartControl1_ObjectHotTracked(object sender, HotTrackEventArgs e)
        {
            SeriesPoint point = e.AdditionalObject as SeriesPoint;
            Series srs = e.Object as Series;

            if (point != null && srs != null && this.Enabled == true)
            {

                SuperToolTip superTT = new SuperToolTip();

                ToolTipTitleItem titleTT = new ToolTipTitleItem();

                ToolTipItem contentTT = new ToolTipItem();

                if (srs.Tag == null) return;

                SeriesPointType srsPointType = (SeriesPointType)srs.Tag;

                if (srs.View is DevExpress.XtraCharts.LineSeriesView)
                {

                    titleTT.Text = point.Argument;

                    if (srsPointType == SeriesPointType.MONEY)
                    {
                        contentTT.Text = string.Format("{0} : {1:" + acInfo.SysConfig.GetSysConfigByMemory("MASK_MONEY_TYPE") + "}", srs.Name, point.Values[0]);
                    }
                    else if (srsPointType == SeriesPointType.NUMBER)
                    {
                        contentTT.Text = string.Format("{0} : {1}", srs.Name, point.Values[0]);
                    }
                    else if (srsPointType == SeriesPointType.PERCENT)
                    {
                        contentTT.Text = string.Format("{0} : {1}%", srs.Name, point.Values[0].toPercent(2));
                    }
                    else if (srsPointType == SeriesPointType.QTY)
                    {
                        contentTT.Text = string.Format("{0} : {1:N0}", srs.Name, point.Values[0]);
                    }


                }
                else if (srs.View is DevExpress.XtraCharts.SideBySideBarSeriesView)
                {
                    titleTT.Text = point.Argument;

                    if (srsPointType == SeriesPointType.MONEY)
                    {
                        contentTT.Text = string.Format("{0} : {1:" + acInfo.SysConfig.GetSysConfigByMemory("MASK_MONEY_TYPE") + "}", srs.Name, point.Values[0]);
                    }
                    else if (srsPointType == SeriesPointType.NUMBER)
                    {
                        contentTT.Text = string.Format("{0} : {1}", srs.Name, point.Values[0]);
                    }
                    else if (srsPointType == SeriesPointType.PERCENT)
                    {
                        contentTT.Text = string.Format("{0} : {1}%", srs.Name, point.Values[0].toPercent(2));
                    }
                    else if (srsPointType == SeriesPointType.QTY)
                    {
                        contentTT.Text = string.Format("{0} : {1:N0}", srs.Name, point.Values[0]);
                    }
                }
                else if (srs.View is DevExpress.XtraCharts.PieSeriesView)
                {
                    titleTT.Text = srs.Name;

                    if (srsPointType == SeriesPointType.MONEY)
                    {
                        contentTT.Text = string.Format("{0} : {1:" + acInfo.SysConfig.GetSysConfigByMemory("MASK_MONEY_TYPE") + "}", point.Argument, point.Values[0]);
                    }
                    else if (srsPointType == SeriesPointType.NUMBER)
                    {
                        contentTT.Text = string.Format("{0} : {1}", point.Argument, point.Values[0]);
                    }
                    else if (srsPointType == SeriesPointType.PERCENT)
                    {
                        contentTT.Text = string.Format("{0} : {1}%", point.Argument, point.Values[0].toPercent(2));
                    }
                    else if (srsPointType == SeriesPointType.QTY)
                    {
                        contentTT.Text = string.Format("{0} : {1:N0}", point.Argument, point.Values[0]);
                    }

                }





                superTT.Items.Add(titleTT);
                superTT.Items.Add(contentTT);

                DevExpress.Utils.ToolTipControllerShowEventArgs args = new DevExpress.Utils.ToolTipControllerShowEventArgs();

                args.SuperTip = superTT;

                args.ToolTipType = DevExpress.Utils.ToolTipType.SuperTip;

                this.toolTipController1.ShowHint(args, Control.MousePosition);


            }
            else
            {
                this.toolTipController1.HideHint();
            }


        }



        void VisibleTimer_Tick(object sender, EventArgs e)
        {
            if (this.Visible == false)
            {
                //보이지않을때는 서브윈도우를 모두 숨긴다.


                this.HideSubWindows();


                this._VisibleTimer.Stop();
            }
        }

        void acChartControl_VisibleChanged(object sender, EventArgs e)
        {

            if (this.Visible == true)
            {
                //보일때는 서브윈도우를 숨긴 창들을 표시

                this.ShowSubWindows();


                this._VisibleTimer.Start();
            }


        }


        /// <summary>
        /// 서브윈도우를 숨긴다.
        /// </summary>
        private void HideSubWindows()
        {

            //스타일상자

            if (this._StyleBox != null)
            {
                this._StyleBox.Hide();
            }

            //사용자 UI 불러오기

            if (this._LoadConfig != null)
            {

                this._LoadConfig.Hide();
            }

            //사용자 UI 관리

            if (this._ConfigManager != null)
            {
                this._ConfigManager.Hide();
            }

            //범례 에디터

            foreach (KeyValuePair<string, BaseMenuDialog> seriesEditor in this._SeriesEditors)
            {
                seriesEditor.Value.Hide();

            }
        }


        /// <summary>
        /// 서브윈도우를 표시한다.
        /// </summary>
        private void ShowSubWindows()
        {

            //스타일상자

            if (this._StyleBox != null)
            {
                this._StyleBox.Show();
            }

            //사용자 UI 불러오기

            if (this._LoadConfig != null)
            {

                this._LoadConfig.Show();
            }

            //사용자 UI 관리

            if (this._ConfigManager != null)
            {
                this._ConfigManager.Show();
            }

            //범례 에디터

            foreach (KeyValuePair<string, BaseMenuDialog> seriesEditor in this._SeriesEditors)
            {
                seriesEditor.Value.Show();

            }

        }


        /// <summary>
        /// 챠트 타이틀을 설정한다.
        /// </summary>
        /// <param name="title"></param>
        public void SetChartTitle(object title)
        {

            chartControl1.Titles[0].Text = title.toStringNull();

        }

        void popupMenu1_BeforePopup(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(this._Config.ConfigName))
            {
                acBarButtonItem9.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

                acBarButtonItem13.Enabled = false;

                acBarButtonItem14.Enabled = false;

            }
            else
            {
                acBarButtonItem9.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

                acBarButtonItem13.Enabled = true;

                acBarButtonItem14.Enabled = true;

                acBarButtonItem9.Caption = string.Format(acInfo.Resource.GetString("현재 설정된 UI - {0}", "NK9O7TO0"), this._Config.ConfigName);
            }


        }

        private Dictionary<string, BaseMenuDialog> _SeriesEditors = new Dictionary<string, BaseMenuDialog>();


        private bool _IsDiagramSetFont = false;

        private void SetDiagramFont()
        {
            if (this._Chart.Diagram is DevExpress.XtraCharts.SimpleDiagram)
            {

                this._IsDiagramSetFont = true;
            }
            else if (this._Chart.Diagram is DevExpress.XtraCharts.XYDiagram)
            {
                XYDiagram diagram = this._Chart.Diagram as XYDiagram;

                diagram.AxisX.Label.Font = new Font(DevExpress.Utils.AppearanceObject.DefaultFont.Name, DevExpress.Utils.AppearanceObject.DefaultFont.Size,
            DevExpress.Utils.AppearanceObject.DefaultFont.Style, DevExpress.Utils.AppearanceObject.DefaultFont.Unit);



                diagram.AxisY.Label.Font = new Font(DevExpress.Utils.AppearanceObject.DefaultFont.Name, DevExpress.Utils.AppearanceObject.DefaultFont.Size,
            DevExpress.Utils.AppearanceObject.DefaultFont.Style, DevExpress.Utils.AppearanceObject.DefaultFont.Unit);


                this._IsDiagramSetFont = true;
            }


        }

        protected override void OnCreateControl()
        {

            if (this.ParentControl == null)
            {
                this.ParentControl = this.GetContainerControl() as Control;
            }

            if (acInfo.IsRunTime == true)
            {
                //기본폰트 설정

                if (this._IsDiagramSetFont == false)
                {
                    this.SetDiagramFont();
                }



                this._Chart.Legend.Font = new Font(DevExpress.Utils.AppearanceObject.DefaultFont.Name, DevExpress.Utils.AppearanceObject.DefaultFont.Size,
                                                    DevExpress.Utils.AppearanceObject.DefaultFont.Style, DevExpress.Utils.AppearanceObject.DefaultFont.Unit);




                //챠트 타이틀 생성
                DevExpress.XtraCharts.ChartTitle title = new DevExpress.XtraCharts.ChartTitle();

                title.Visible = false;

                title.Font = new Font(DevExpress.Utils.AppearanceObject.DefaultFont.Name, DevExpress.Utils.AppearanceObject.DefaultFont.Size,
                DevExpress.Utils.AppearanceObject.DefaultFont.Style, DevExpress.Utils.AppearanceObject.DefaultFont.Unit);

                chartControl1.Titles.Add(title);


                //UI클래스 생성

                this._Config = new acChartUserConfig(this);


                //기본으로 UI환경 불러오기


                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE");
                paramTable.Columns.Add("EMP_CODE");
                paramTable.Columns.Add("CLASS_NAME");
                paramTable.Columns.Add("CONTROL_NAME");

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["EMP_CODE"] = acInfo.UserID;
                paramRow["CLASS_NAME"] = this._ParentControl.Name;
                paramRow["CONTROL_NAME"] = this.Name;

                paramTable.Rows.Add(paramRow);

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(
    this._ParentControl, QBiz.emExecuteType.NONE,"CTRL",
    "GET_USERCONFIG_DEFAULT_USE", paramSet, "RQSTDT", "RSLTDT", QuickUse, QuickException);

                //DataSet dsResult = BizManager.acControls.GET_USERCONFIG_DEFAULT_USE(paramSet);

                //QuickUse(dsResult);


            }


            base.OnCreateControl();



        }

        void chartControl1_MouseDown(object sender, MouseEventArgs e)
        {
            if (this._Chart.ShowMenu == false)
            {
                return;
            }


            if (e.Button == MouseButtons.Right)
            {

                popupMenu1.ShowPopup(Control.MousePosition);


            }

        }

        public void ClearSeries()
        {
            chartControl1.Series.Clear();

            this._SeriesDic.Clear();

            this._SeriesIndexDic.Clear();

        }


        public void ClearSeriesPoint()
        {

            foreach (DevExpress.XtraCharts.Series srs in chartControl1.Series)
            {
                srs.Points.Clear();
            }
        }



        public void AddSeriesPoint(string seriesKey, SeriesPoint point)
        {


            if (this._SeriesDic.ContainsKey(seriesKey))
            {


                this._SeriesDic[seriesKey].Points.Add(point);

            }


        }


        internal Dictionary<string, DevExpress.XtraCharts.Series> _SeriesDic = new Dictionary<string, DevExpress.XtraCharts.Series>();

        public Dictionary<string, DevExpress.XtraCharts.Series> SeriesDic
        {
            get { return _SeriesDic; }
        }


        internal Dictionary<string, int> _SeriesIndexDic = new Dictionary<string, int>();



        public enum SeriesPointType { NONE, NUMBER, MONEY, QTY, PERCENT };



        public void AddLineSeries(string seriesKey, string name, string resourceID, bool useResourceID, SeriesPointType seriesPointType, DevExpress.XtraCharts.ViewType type)
        {
            string seriesName = null;

            if (useResourceID == true)
            {
                seriesName = acInfo.Resource.GetString(name, resourceID);
            }
            else
            {
                seriesName = name;
            }


            DevExpress.XtraCharts.Series srs = new DevExpress.XtraCharts.Series(seriesName, type);

            srs.ArgumentDataMember = seriesKey;

            if (seriesPointType == SeriesPointType.NUMBER)
            {
                srs.PointOptions.ValueNumericOptions.Format = DevExpress.XtraCharts.NumericFormat.General;

                srs.PointOptions.ValueNumericOptions.Precision = 0;
            }
            else if (seriesPointType == SeriesPointType.MONEY)
            {
                srs.PointOptions.ValueNumericOptions.Format = DevExpress.XtraCharts.NumericFormat.Number;

                srs.PointOptions.ValueNumericOptions.Precision = 1;
            }
            else if (seriesPointType == SeriesPointType.QTY)
            {
                srs.PointOptions.ValueNumericOptions.Format = DevExpress.XtraCharts.NumericFormat.Number;

                srs.PointOptions.ValueNumericOptions.Precision = 0;
            }
            else if (seriesPointType == SeriesPointType.PERCENT)
            {

                srs.PointOptions.ValueNumericOptions.Format = DevExpress.XtraCharts.NumericFormat.Percent;

                srs.PointOptions.ValueNumericOptions.Precision = 2;
            }

            srs.Tag = seriesPointType;

            srs.Label.Font = new Font(DevExpress.Utils.AppearanceObject.DefaultFont.Name, DevExpress.Utils.AppearanceObject.DefaultFont.Size,
                DevExpress.Utils.AppearanceObject.DefaultFont.Style, DevExpress.Utils.AppearanceObject.DefaultFont.Unit);

            srs.Label.Shadow.Visible = true;

            this._SeriesDic.Add(seriesKey, srs);

            this._SeriesIndexDic.Add(seriesKey, this._Chart.Series.Count);

            chartControl1.Series.Add(srs);

            if (this._IsDiagramSetFont == false)
            {
                this.SetDiagramFont();
            }

        }

        public void AddLinePercentSeries(string seriesKey, string name, string resourceID, bool useResourceID, DevExpress.XtraCharts.ViewType type)
        {
            string seriesName = null;

            if (useResourceID == true)
            {
                seriesName = acInfo.Resource.GetString(name, resourceID);
            }
            else
            {
                seriesName = name;
            }


            DevExpress.XtraCharts.Series srs = new DevExpress.XtraCharts.Series(seriesName, type);

            srs.PointOptions.ValueNumericOptions.Format = DevExpress.XtraCharts.NumericFormat.Percent;

            srs.PointOptions.ValueNumericOptions.Precision = 2;

            srs.Label.Font = new Font(DevExpress.Utils.AppearanceObject.DefaultFont.Name, DevExpress.Utils.AppearanceObject.DefaultFont.Size,
                DevExpress.Utils.AppearanceObject.DefaultFont.Style, DevExpress.Utils.AppearanceObject.DefaultFont.Unit);

            srs.Label.Shadow.Visible = true;

            this._SeriesDic.Add(seriesKey, srs);

            this._SeriesIndexDic.Add(seriesKey, this._Chart.Series.Count);

            chartControl1.Series.Add(srs);

        }

        public void AddPieSeries(string seriesKey, string name, string resourceID, bool useResourceID, SeriesPointType seriesPointType, DevExpress.XtraCharts.ViewType type)
        {
            string seriesName = null;

            if (useResourceID == true)
            {
                seriesName = acInfo.Resource.GetString(name, resourceID);
            }
            else
            {
                seriesName = name;
            }


            DevExpress.XtraCharts.Series srs = new DevExpress.XtraCharts.Series(seriesName, type);


            DevExpress.XtraCharts.PiePointOptions piePointOpt = srs.PointOptions as DevExpress.XtraCharts.PiePointOptions;

            //piePointOpt.PercentOptions.ValuePercentPrecision = 4;
            piePointOpt.PercentOptions.PercentageAccuracy = 4;

            piePointOpt.ValueNumericOptions.Format = DevExpress.XtraCharts.NumericFormat.Percent;


            srs.Tag = seriesPointType;

            srs.PointOptions.PointView = PointView.ArgumentAndValues;

            srs.LegendPointOptions.PointView = PointView.Argument;

            srs.Label.Font = new Font(DevExpress.Utils.AppearanceObject.DefaultFont.Name, DevExpress.Utils.AppearanceObject.DefaultFont.Size,
                DevExpress.Utils.AppearanceObject.DefaultFont.Style, DevExpress.Utils.AppearanceObject.DefaultFont.Unit);

            srs.Label.Shadow.Visible = true;

            this._SeriesDic.Add(seriesKey, srs);

            this._SeriesIndexDic.Add(seriesKey, this._Chart.Series.Count);

            chartControl1.Series.Add(srs);

            if (this._IsDiagramSetFont == false)
            {
                this.SetDiagramFont();
            }
        }





        private BaseMenuDialog _StyleBox = null;


        private void acBarButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //챠트 스타일상자
            try
            {

                if (this._StyleBox == null)
                {
                    if (chartControl1.Diagram is DevExpress.XtraCharts.XYDiagram)
                    {

                        this._StyleBox = new acChartControlXYDiagramStyleBox(chartControl1);

                        this._StyleBox.ParentControl = new Control();

                        this._StyleBox.ParentControl.Name = this.ParentControl.Name + "." + this.Name;

                        this._StyleBox.FormClosed += new FormClosedEventHandler(_StyleBox_FormClosed);

                        this._StyleBox.Show();

                    }
                    else if (chartControl1.Diagram is DevExpress.XtraCharts.SimpleDiagram)
                    {
                        this._StyleBox = new acChartControlSimpleDiagramStyleBox(chartControl1);

                        this._StyleBox.ParentControl = new Control();

                        this._StyleBox.ParentControl.Name = this.ParentControl.Name + "." + this.Name;

                        this._StyleBox.FormClosed += new FormClosedEventHandler(_StyleBox_FormClosed);

                        this._StyleBox.Show();
                    }
                    else
                    {
                        return;
                    }

                }
                else
                {

                    this._StyleBox.Focus();
                }

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this.ParentControl, ex);
            }



        }

        void _StyleBox_FormClosed(object sender, FormClosedEventArgs e)
        {
            this._StyleBox = null;
        }

        private void acBarButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //파일로 저장 웹문서 (html) 

            try
            {
                this.ShowExportFileDialog(emExportFileType.HTML);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this.ParentControl, ex);
            }


        }

        private void acBarButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //파일로 저장 (이미지)
            try
            {
                this.ShowExportFileDialog(emExportFileType.IMAGE);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this.ParentControl, ex);
            }
        }

        private void acBarButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //파일로 저장(웹페이지 보관파일)
            try
            {
                this.ShowExportFileDialog(emExportFileType.MHT);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this.ParentControl, ex);
            }
        }

        private void acBarButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //파일로 저장 Adobe Acrobat PDF
            try
            {
                this.ShowExportFileDialog(emExportFileType.PDF);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this.ParentControl, ex);
            }
        }

        private void acBarButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //파일로 저장 (Mircrosoft Excel)
            try
            {
                this.ShowExportFileDialog(emExportFileType.EXCEL);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this.ParentControl, ex);
            }
        }

        private Control _ParentControl = null;

        /// <summary>
        /// 부모컨트롤(메뉴컨트롤)
        /// </summary>
        public Control ParentControl
        {
            get { return _ParentControl; }
            set { _ParentControl = value; }
        }



        private enum emExportFileType { HTML, IMAGE, MHT, PDF, EXCEL }

        void ShowExportFileDialog(emExportFileType fileType)
        {
            SaveFileDialog saveDlg = new SaveFileDialog();


            switch (fileType)
            {

                case emExportFileType.HTML:

                    saveDlg.Filter = "모든 웹페이지 (*.htm;*.html)|*.htm;*.html";
                    break;

                case emExportFileType.IMAGE:

                    saveDlg.Filter = "이미지(*.png)|*.png";
                    break;

                case emExportFileType.MHT:


                    saveDlg.Filter = "웹페이지 보관파일(*.mht)|*.mht";
                    break;


                case emExportFileType.PDF:

                    saveDlg.Filter = "Adobe Acrobat PDF 문서(*.pdf)|*.pdf";


                    break;

                case emExportFileType.EXCEL:


                    saveDlg.Filter = "Excel 97 - 2003 통합 문서 (*.xls)|*.xls";
                    break;


            }

            if (saveDlg.ShowDialog() == DialogResult.OK)
            {
                this.ExportFile(fileType, saveDlg.FileName);

            }


        }

        void ExportFile(emExportFileType fileType, string fileName)
        {
            try
            {

                switch (fileType)
                {

                    case emExportFileType.HTML:


                        chartControl1.ExportToHtml(fileName);

                        break;

                    case emExportFileType.IMAGE:

                        chartControl1.ExportToImage(fileName, System.Drawing.Imaging.ImageFormat.Png);

                        break;

                    case emExportFileType.MHT:


                        chartControl1.ExportToMht(fileName);

                        break;


                    case emExportFileType.PDF:


                        chartControl1.ExportToPdf(fileName);

                        break;

                    case emExportFileType.EXCEL:

                        chartControl1.ExportToXls(fileName);

                        break;


                }

                if (acMessageBox.Show(this.ParentControl, "파일을 여시겠습니까?", "C5FDPXF8", true, acMessageBox.emMessageBoxType.YESNO) == DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start(fileName);
                }


            }

            catch (Exception ex)
            {

                acMessageBox.Show(ex.Message, this._ParentControl.Parent.Text, acMessageBox.emMessageBoxType.CONFIRM);
            }

        }

        private void acBarButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //인쇄 기본양식
            try
            {
                IPrintingSystem ps = new PrintingSystem();

                PrintableComponentLink link = new PrintableComponentLink((PrintingSystem)ps);

                link.Component = this.chartControl1;

                link.PaperKind = System.Drawing.Printing.PaperKind.A4;

                link.CreateDocument();

                link.ShowPreview();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this.ParentControl, ex);
            }

        }


        private acChartUserConfigLoadEditor _LoadConfig = null;

        private void acBarButtonItem10_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //사용자 UI 불러오기

            if (this._LoadConfig == null)
            {
                this._LoadConfig = new acChartUserConfigLoadEditor(this);

                this._LoadConfig.ParentControl = new Control();

                this._LoadConfig.ParentControl.Name = this.ParentControl.Name + "." + this.Name;

                this._LoadConfig.FormClosed += new FormClosedEventHandler(_LoadConfig_FormClosed);


                this._LoadConfig.Show();

            }
            else
            {
                this._LoadConfig.Focus();
            }


        }
        void _LoadConfig_FormClosed(object sender, FormClosedEventArgs e)
        {
            _LoadConfig = null;
        }


        private void acBarButtonItem11_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //사용자 UI 저장
            try
            {
                if (this._Config.ConfigMaKer == acInfo.UserID)
                {
                    //현재 적용중인 그리드UI 작성자가 본인일경우는 바로 저장된다.

                    byte[] layoutData = this._Config.SaveLayout();

                    DataTable paramTable = new DataTable("RQSTDT");

                    paramTable.Columns.Add("PLT_CODE", typeof(string));
                    paramTable.Columns.Add("EMP_CODE", typeof(string));
                    paramTable.Columns.Add("CLASS_NAME", typeof(string));
                    paramTable.Columns.Add("CONTROL_NAME", typeof(string));
                    paramTable.Columns.Add("CONFIG_NAME", typeof(string));
                    paramTable.Columns.Add("LAYOUT", typeof(byte[]));
                    paramTable.Columns.Add("OBJECT", typeof(byte[]));
                    paramTable.Columns.Add("OVERWRITE", typeof(string));


                    DataRow paramRow = paramTable.NewRow();

                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["EMP_CODE"] = acInfo.UserID;
                    paramRow["CLASS_NAME"] = this.ParentControl.Name;
                    paramRow["CONTROL_NAME"] = this.Name;
                    paramRow["CONFIG_NAME"] = this._Config.ConfigName;
                    paramRow["LAYOUT"] = layoutData;
                    paramRow["OBJECT"] = null;
                    paramRow["OVERWRITE"] = "1";

                    paramTable.Rows.Add(paramRow);

                    DataSet paramSet = new DataSet();

                    paramSet.Tables.Add(paramTable);

                    BizRun.QBizRun.ExecuteService(
                        this.ParentControl, QBiz.emExecuteType.SAVE,"CTRL",
                        "SET_USERCONFIG_SAVE2", paramSet, "RQSTDT", "RSLTDT", QuickSave, QuickException);


                    //DataSet dsResult = BizManager.acControls.SET_USERCONFIG_SAVE(paramSet);

                    //QuickSave(dsResult);
                }
                else
                {
                    acChartUserConfigSaveEditor frm = new acChartUserConfigSaveEditor(this);

                    frm.ParentControl = new Control();

                    frm.ParentControl.Name = this.ParentControl.Name + "." + this.Name;

                    frm.ShowDialog();


                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this.ParentControl, ex);
            }
        }

        private void acBarButtonItem12_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //사용자 UI 다른이름으로 저장
            try
            {
                acChartUserConfigSaveEditor frm = new acChartUserConfigSaveEditor(this);

                frm.ParentControl = new Control();

                frm.ParentControl.Name = this.ParentControl.Name + "." + this.Name;

                frm.ShowDialog();

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this.ParentControl, ex);
            }


        }

        private void acBarButtonItem13_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //현재 사용자 UI을 기본으로 설정
            try
            {
                DataTable paramTable = new DataTable("RQSTDT");

                paramTable.Columns.Add("PLT_CODE");
                paramTable.Columns.Add("EMP_CODE");
                paramTable.Columns.Add("CLASS_NAME");
                paramTable.Columns.Add("CONTROL_NAME");
                paramTable.Columns.Add("USE_CONFIG_NAME");
                paramTable.Columns.Add("USE_CONFIG_MAKER");

                DataRow paramRow = paramTable.NewRow();

                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["EMP_CODE"] = acInfo.UserID;
                paramRow["CLASS_NAME"] = this._ParentControl.Name;
                paramRow["CONTROL_NAME"] = this.Name;
                paramRow["USE_CONFIG_NAME"] = this._Config.ConfigName;
                paramRow["USE_CONFIG_MAKER"] = this._Config.ConfigMaKer;

                paramTable.Rows.Add(paramRow);

                DataSet paramSet = new DataSet();

                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(
        this._ParentControl, QBiz.emExecuteType.SAVE,"CTRL",
        "SET_USERCONFIG_DEFAULT_USE", paramSet, "RQSTDT", "", QuickDefaultUse, QuickException);

                //BizManager.acControls.SET_USERCONFIG_DEFAULT_USE(paramSet);

                //this._Config.ConfigName = (string)dsResult.Tables["RQSTDT"].Rows[0]["USE_CONFIG_NAME"];
                //this._Config.ConfigMaKer = (string)dsResult.Tables["RQSTDT"].Rows[0]["USE_CONFIG_MAKER"];
                
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this.ParentControl, ex);
            }
        }

        private void acBarButtonItem14_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //시스템 UI로 초기화
            try
            {
                DataTable paramTable = new DataTable("RQSTDT");

                paramTable.Columns.Add("PLT_CODE");
                paramTable.Columns.Add("EMP_CODE");
                paramTable.Columns.Add("CLASS_NAME");
                paramTable.Columns.Add("CONTROL_NAME");


                DataRow paramRow = paramTable.NewRow();

                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["EMP_CODE"] = acInfo.UserID;
                paramRow["CLASS_NAME"] = this._ParentControl.Name;
                paramRow["CONTROL_NAME"] = this.Name;

                paramTable.Rows.Add(paramRow);

                DataSet paramSet = new DataSet();

                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(
                this._ParentControl, QBiz.emExecuteType.SAVE,"CTRL",
                "SET_USERCONFIG_DEFAULT_USE_DEL", paramSet, "RQSTDT", "", QuickUseDel, QuickException);

                //BizManager.acControls.SET_USERCONFIG_DEFAULT_USE_DEL(paramSet);

                //this._Config.LoadDefaultLayout();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this.ParentControl, ex);
            }
        }

        void QuickUseDel(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                this._Config.LoadDefaultLayout();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this.ParentControl, ex);
            }
        }


        private acChartUserConfigManager _ConfigManager = null;


        private void acBarButtonItem15_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //사용자 UI 관리
            try
            {
                if (_ConfigManager == null)
                {
                    this._ConfigManager = new acChartUserConfigManager(this);

                    this._ConfigManager.ParentControl = new Control();

                    this._ConfigManager.ParentControl.Name = this.ParentControl.Name + "." + this.Name;


                    this._ConfigManager.FormClosed += new FormClosedEventHandler(_ConfigManager_FormClosed);

                    this._ConfigManager.Show();

                }
                else
                {
                    this._ConfigManager.Focus();
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this.ParentControl, ex);
            }
        }

        void _ConfigManager_FormClosed(object sender, FormClosedEventArgs e)
        {
            this._ConfigManager = null;
        }


        void QuickSave(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            //사용자 UI 저장

            try
            {
                if (e.result.Tables["RSLTDT"].Rows.Count != 0)
                {
                    //기본UI로 저장할경우 현재 사용자 UI으로 표시

                    this._Config.ConfigName = (string)e.result.Tables["RSLTDT"].Rows[0]["CONFIG_NAME"];
                    this._Config.ConfigMaKer = (string)e.result.Tables["RSLTDT"].Rows[0]["EMP_CODE"];
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this.ParentControl, ex);
            }

        }

        void QuickSave(DataSet ds)
        {
            //사용자 UI 저장

            try
            {
                if (ds.Tables["RSLTDT"].Rows.Count != 0)
                {
                    //기본UI로 저장할경우 현재 사용자 UI으로 표시

                    this._Config.ConfigName = (string)ds.Tables["RSLTDT"].Rows[0]["CONFIG_NAME"];
                    this._Config.ConfigMaKer = (string)ds.Tables["RSLTDT"].Rows[0]["EMP_CODE"];
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this.ParentControl, ex);
            }

        }

        void QuickDefaultUse(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            //기본UI로 설정
            try
            {
                this._Config.ConfigName = (string)e.result.Tables["RQSTDT"].Rows[0]["USE_CONFIG_NAME"];
                this._Config.ConfigMaKer = (string)e.result.Tables["RQSTDT"].Rows[0]["USE_CONFIG_MAKER"];
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this.ParentControl, ex);
            }

        }

        void QuickUse(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            //기본UI로 설정된 사용자 UI 불러옴
            try
            {
                if (e.result.Tables["RSLTDT"].Rows.Count != 0)
                {
                    DataRow chartLayoutRow = e.result.Tables["RSLTDT"].Rows[0];

                    this._Config.LoadLayout(chartLayoutRow["CONFIG_NAME"], chartLayoutRow["EMP_CODE"], (byte[])chartLayoutRow["LAYOUT"]);
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this.ParentControl, ex);
            }
        }

        //void QuickUse(DataSet ds)
        //{
        //    //기본UI로 설정된 사용자 UI 불러옴
        //    try
        //    {
        //        if (ds.Tables["RSLTDT"].Rows.Count != 0)
        //        {
        //            DataRow chartLayoutRow = ds.Tables["RSLTDT"].Rows[0];

        //            this._Config.LoadLayout(chartLayoutRow["CONFIG_NAME"], chartLayoutRow["EMP_CODE"], (byte[])chartLayoutRow["LAYOUT"]);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        acMessageBox.Show(this.ParentControl, ex);
        //    }
        //}

        void QuickException(object sender, QBiz qBiz, BizException ex)
        {
            acMessageBox.Show(this.ParentControl, ex);
        }

        private void acBarButtonItem16_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //챠트 도움말
            try
            {
                string helpClassName = "HELP_CTRL_CHART";

                if (!acInfo.HelpForms.ContainsKey(helpClassName))
                {
                    acMessageBoxHelp frm = new acMessageBoxHelp(helpClassName);

                    frm.ParentControl = this._ParentControl;

                    frm.Show();

                    acInfo.HelpForms.Add(helpClassName, frm);
                }
                else
                {
                    acInfo.HelpForms[helpClassName].Focus();
                }

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this.ParentControl, ex);
            }
        }

        private void acBarButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //범례 에디터
            try
            {

                if (this.chartControl1.Series[0].View is LineSeriesView)
                {
                    if (!this._SeriesEditors.ContainsKey("acChartLineSeriesEditor"))
                    {

                        acChartLineSeriesEditor frm = new acChartLineSeriesEditor(this.chartControl1, this._SeriesDic);

                        frm.Text = e.Item.Caption;

                        frm.ParentControl = new Control();

                        frm.ParentControl.Name = this.ParentControl.Name + "." + this.Name;

                        this._SeriesEditors.Add("acChartLineSeriesEditor", frm);

                        frm.FormClosed += new FormClosedEventHandler(acChartLineSeriesEditor_FormClosed);

                        frm.Show();
                    }
                    else
                    {
                        this._SeriesEditors["acChartLineSeriesEditor"].Focus();
                    }


                }
                else if (this.chartControl1.Series[0].View is SideBySideBarSeriesView)
                {

                    if (!this._SeriesEditors.ContainsKey("acChartBarSeriesEditor"))
                    {

                        acChartBarSeriesEditor frm = new acChartBarSeriesEditor(this.chartControl1, this._SeriesDic);

                        frm.Text = e.Item.Caption;

                        frm.ParentControl = new Control();

                        frm.ParentControl.Name = this.ParentControl.Name + "." + this.Name;

                        this._SeriesEditors.Add("acChartBarSeriesEditor", frm);

                        frm.FormClosed += new FormClosedEventHandler(acChartBarSeriesEditor_FormClosed);

                        frm.Show();
                    }
                    else
                    {
                        this._SeriesEditors["acChartBarSeriesEditor"].Focus();
                    }





                }
                else if (this.chartControl1.Series[0].View is DoughnutSeriesView)
                {
                    if (!this._SeriesEditors.ContainsKey("acChartDoughnutSeriesEditor"))
                    {
                        acChartDoughnutSeriesEditor frm = new acChartDoughnutSeriesEditor(this.chartControl1, this._SeriesDic);

                        frm.Text = e.Item.Caption;

                        frm.ParentControl = new Control();

                        frm.ParentControl.Name = this.ParentControl.Name + "." + this.Name;

                        this._SeriesEditors.Add("acChartDoughnutSeriesEditor", frm);

                        frm.FormClosed += new FormClosedEventHandler(acChartDoughnutSeriesEditor_FormClosed);

                        frm.Show();

                    }
                    else
                    {
                        this._SeriesEditors["acChartDoughnutSeriesEditor"].Focus();

                    }
                }


            }
            catch (Exception ex)
            {
                acMessageBox.Show(this.ParentControl, ex);
            }

        }

        void acChartLineSeriesEditor_FormClosed(object sender, FormClosedEventArgs e)
        {
            acChartLineSeriesEditor frm = sender as acChartLineSeriesEditor;

            this._SeriesEditors.Remove("acChartLineSeriesEditor");
        }

        void acChartBarSeriesEditor_FormClosed(object sender, FormClosedEventArgs e)
        {
            acChartBarSeriesEditor frm = sender as acChartBarSeriesEditor;

            this._SeriesEditors.Remove("acChartBarSeriesEditor");
        }

        void acChartDoughnutSeriesEditor_FormClosed(object sender, FormClosedEventArgs e)
        {
            acChartDoughnutSeriesEditor frm = sender as acChartDoughnutSeriesEditor;

            this._SeriesEditors.Remove("acChartDoughnutSeriesEditor");
        }

        private void acBarButtonItem17_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //전체화면으로 보기
            try
            {
                BaseFullScreenMenu frm = new BaseFullScreenMenu();

                frm.Text = e.Item.Caption;


                frm.ShowFullScreen(this, this.chartControl1);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this.ParentControl, ex);
            }

        }


    }



}
