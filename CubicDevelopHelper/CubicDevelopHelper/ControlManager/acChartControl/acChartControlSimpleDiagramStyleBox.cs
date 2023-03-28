using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraCharts;
using System.Linq;

namespace ControlManager
{
    public sealed partial class acChartControlSimpleDiagramStyleBox : BaseMenuDialog
    {


        public override void BarCodeScanInput(string barcode)
        {


        }

        private DevExpress.XtraCharts.ChartControl _Chart = null;

        public acChartControlSimpleDiagramStyleBox(DevExpress.XtraCharts.ChartControl chart)
        {
            InitializeComponent();

            this._Chart = chart;

            acVerticalGrid1.OnValueChanged += new acVerticalGrid.ValueChangedEventHandler(acVerticalGrid1_OnValueChanged);

        }

        protected override void OnLoad(EventArgs e)
        {

            //컨트롤 설정

            List<object> paletteNameList = new List<object>();


            paletteNameList.Add("Apex");
            paletteNameList.Add("Aspect");
            paletteNameList.Add("Black and White");
            paletteNameList.Add("Chameleon");
            paletteNameList.Add("Civic");
            paletteNameList.Add("Concourse");
            paletteNameList.Add("Equity");
            paletteNameList.Add("Flow");
            paletteNameList.Add("Foundry");
            paletteNameList.Add("In A Fog");
            paletteNameList.Add("Median");
            paletteNameList.Add("Metro");
            paletteNameList.Add("Mixed");
            paletteNameList.Add("Module");
            paletteNameList.Add("Nature Colors");
            paletteNameList.Add("Northern Lights");
            paletteNameList.Add("Office");
            paletteNameList.Add("Opulent");
            paletteNameList.Add("Oriel");
            paletteNameList.Add("Origin");
            paletteNameList.Add("Paper");
            paletteNameList.Add("Origin");
            paletteNameList.Add("Pastel Kit");
            paletteNameList.Add("Solstice");
            paletteNameList.Add("Technic");
            paletteNameList.Add("Terracotta Pie");
            paletteNameList.Add("The Trees");
            paletteNameList.Add("Trek");
            paletteNameList.Add("Urban");
            paletteNameList.Add("Verve");


            List<object> styleNameList = new List<object>();

            styleNameList.Add("Nature Colors");
            styleNameList.Add("Dark");
            styleNameList.Add("Dark Flat");
            styleNameList.Add("Gray");
            styleNameList.Add("Light");




            List<object> fillModeList = Enum.GetValues(typeof(FillMode)).Cast<object>().ToList();

            List<object> rectGradientModeList = Enum.GetValues(typeof(DevExpress.XtraCharts.RectangleGradientMode)).Cast<object>().ToList();


            List<object> legendAlignmentVerticalList = Enum.GetValues(typeof(DevExpress.XtraCharts.LegendAlignmentVertical)).Cast<object>().ToList();

            List<object> legendAlignmentHorizontalList = Enum.GetValues(typeof(DevExpress.XtraCharts.LegendAlignmentHorizontal)).Cast<object>().ToList();

            List<object> stringAlignmentList = Enum.GetValues(typeof(StringAlignment)).Cast<object>().ToList();

            List<object> chartTitleDockStyleList = Enum.GetValues(typeof(ChartTitleDockStyle)).Cast<object>().ToList();

            List<object> dashStyleList = Enum.GetValues(typeof(DashStyle)).Cast<object>().ToList();

            List<object> legendDirectionList = Enum.GetValues(typeof(LegendDirection)).Cast<object>().ToList();



            dashStyleList.Remove(DashStyle.Empty);


            acVerticalGrid1.AddComboBoxEdit("PALETTE_NAME", "색조", "SEEGAGA4", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, paletteNameList);


            acVerticalGrid1.AddComboBoxEdit("STYLE_NAME", "스타일", "BQ2DLQ13", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, styleNameList);




            acVerticalGrid1.AddCheckEdit("SERIES_VISIBLE", "표시", "0VXIPFNO", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emCheckEditDataType._BOOL);

            acVerticalGrid1.AddColorEdit("SERIES_FONT_COLOR", "글꼴색", "URAB96B3", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);

            acVerticalGrid1.AddCustomEdit("SERIES_FONT", "글꼴", "FS0E89ZT", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, new RepositoryItemFontDialogEdit());

            acVerticalGrid1.AddCheckEdit("SERIES_BORDER_VISIBLE", "테두리 표시", "7WUABOW4", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emCheckEditDataType._BOOL);

            acVerticalGrid1.AddColorEdit("SERIES_BORDER_COLOR", "테두리 색상", "KN1005OS", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);

            acVerticalGrid1.AddCheckEdit("SERIES_LINE_VISIBLE", "선 표시", "E7JZ31PG", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emCheckEditDataType._BOOL);

            acVerticalGrid1.AddColorEdit("SERIES_LINE_COLOR", "선 색상", "XWWERQC6", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);

            acVerticalGrid1.AddComboBoxEdit("SERIES_LINE_DASH_STYLE", "선 형태", "TOBO0VNP", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, dashStyleList);

            acVerticalGrid1.AddCheckEdit("SERIES_SHADOW", "그림자 여부", "KPRYTWSC", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emCheckEditDataType._BOOL);

            acVerticalGrid1.AddCheckEdit("SERIES_ALIASING", "안티 앨리어싱", "122HJEYI", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emCheckEditDataType._BOOL);


            acVerticalGrid1.AddCategoryRow("요점표", "MLOLEZA9", true, new string[] {
                "SERIES_VISIBLE"
                ,"SERIES_FONT_COLOR"
                ,"SERIES_FONT"
                ,"SERIES_BORDER_VISIBLE"
                ,"SERIES_BORDER_COLOR"
                ,"SERIES_LINE_VISIBLE"
                ,"SERIES_LINE_COLOR"
                ,"SERIES_LINE_DASH_STYLE"
                ,"SERIES_SHADOW"
                ,"SERIES_ALIASING"
            });



            acVerticalGrid1.AddCheckEdit("TITLE_VISIBLE", "표시", "0VXIPFNO", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emCheckEditDataType._BOOL);

            acVerticalGrid1.AddTextEdit("TITLE_TEXT", "제목", "W4WOVWG8", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);

            acVerticalGrid1.AddColorEdit("TITLE_FONT_COLOR", "글꼴색", "URAB96B3", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);

            acVerticalGrid1.AddCustomEdit("TITLE_FONT", "글꼴", "FS0E89ZT", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, new RepositoryItemFontDialogEdit());


            acVerticalGrid1.AddComboBoxEdit("TITLE_ALIGNMENT", "정렬", "RCX5CLOA", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, stringAlignmentList);


            acVerticalGrid1.AddComboBoxEdit("TITLE_DOCK", "도킹", "IFI138Z9", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, chartTitleDockStyleList);


            acVerticalGrid1.AddCheckEdit("TITLE_ANTI_ALIASING", "안티 앨리어싱", "122HJEYI", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emCheckEditDataType._BOOL);



            acVerticalGrid1.AddCategoryRow("제목", "W4WOVWG8", true, new string[] {
                "TITLE_VISIBLE"
                ,"TITLE_TEXT"
                ,"TITLE_FONT_COLOR"
                ,"TITLE_FONT"
                ,"TITLE_ALIGNMENT"
                ,"TITLE_DOCK"
                ,"TITLE_ANTI_ALIASING"
            });






            acVerticalGrid1.AddCheckEdit("LEGEND_VISIBLE", "표시", "0VXIPFNO", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emCheckEditDataType._BOOL);



            acVerticalGrid1.AddColorEdit("LEGEND_BACK_COLOR", "배경색", "KYF0TDNA", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);


            acVerticalGrid1.AddComboBoxEdit("LEGEND_VERTICAL_ALIGN", "수직 정렬", "24CU98QH", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, legendAlignmentVerticalList);

            acVerticalGrid1.AddComboBoxEdit("LEGEND_HORIZONTAL_ALIGN", "수평 정렬", "IK3GIUFL", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, legendAlignmentHorizontalList);

            acVerticalGrid1.AddComboBoxEdit("LEGEND_DIRECTION", "방향", "LYTFJCOK", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, legendDirectionList);


            acVerticalGrid1.AddColorEdit("LEGEND_FONT_COLOR", "글꼴색", "URAB96B3", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);

            acVerticalGrid1.AddCustomEdit("LEGEND_FONT", "글꼴", "FS0E89ZT", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, new RepositoryItemFontDialogEdit());


            acVerticalGrid1.AddCheckEdit("LEGEND_SHADOW", "그림자 여부", "KPRYTWSC", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emCheckEditDataType._BOOL);



            acVerticalGrid1.AddCheckEdit("LEGEND_BORDER_VISIBLE", "테두리 표시", "7WUABOW4", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emCheckEditDataType._BOOL);

            acVerticalGrid1.AddColorEdit("LEGEND_BORDER_COLOR", "테두리 색상", "KN1005OS", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);



            acVerticalGrid1.AddCheckEdit("LEGEND_ANTI_ALIASING", "안티 앨리어싱", "122HJEYI", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emCheckEditDataType._BOOL);







            acVerticalGrid1.AddCategoryRow("범례", "3V0OSHPG", true, new string[] {
                            "LEGEND_VISIBLE"
                            ,"LEGEND_BACK_COLOR"
                            ,"LEGEND_VERTICAL_ALIGN"
                            ,"LEGEND_HORIZONTAL_ALIGN"
                            ,"LEGEND_DIRECTION"
                            ,"LEGEND_FONT_COLOR"
                            ,"LEGEND_FONT"
                            ,"LEGEND_SHADOW"
                            ,"LEGEND_BORDER_VISIBLE"
                            ,"LEGEND_BORDER_COLOR"
                            ,"LEGEND_ANTI_ALIASING"
            });





            SimpleDiagram diagram = this._Chart.Diagram as SimpleDiagram;

            acVerticalGrid1.SetCellValue("PALETTE_NAME", this._Chart.PaletteName);

            acVerticalGrid1.SetCellValue("STYLE_NAME", this._Chart.AppearanceName);
            //요점

            acVerticalGrid1.SetCellValue("SERIES_VISIBLE", this._Chart.Series[0].LabelsVisibility);

            acVerticalGrid1.SetCellValue("SERIES_FONT_COLOR", this._Chart.Series[0].Label.TextColor);

            acVerticalGrid1.SetCellValue("SERIES_FONT", this._Chart.Series[0].Label.Font);

            acVerticalGrid1.SetCellValue("SERIES_SHADOW", this._Chart.Series[0].Label.Shadow.Visible);

            acVerticalGrid1.SetCellValue("SERIES_BORDER_VISIBLE", this._Chart.Series[0].Label.Border.Visible);
            acVerticalGrid1.SetCellValue("SERIES_BORDER_COLOR", this._Chart.Series[0].Label.Border.Color);
            acVerticalGrid1.SetCellValue("SERIES_LINE_VISIBLE", this._Chart.Series[0].Label.LineVisible);

            acVerticalGrid1.SetCellValue("SERIES_LINE_COLOR", this._Chart.Series[0].Label.LineColor);

            acVerticalGrid1.SetCellValue("SERIES_LINE_DASH_STYLE", this._Chart.Series[0].Label.LineStyle.DashStyle);

            acVerticalGrid1.SetCellValue("SERIES_ALIASING", this._Chart.Series[0].Label.Antialiasing);


            //제목

            acVerticalGrid1.SetCellValue("TITLE_VISIBLE", this._Chart.Titles[0].Visible);

            acVerticalGrid1.SetCellValue("TITLE_TEXT", this._Chart.Titles[0].Text);

            acVerticalGrid1.SetCellValue("TITLE_FONT_COLOR", this._Chart.Titles[0].TextColor);

            acVerticalGrid1.SetCellValue("TITLE_FONT", this._Chart.Titles[0].Font);


            acVerticalGrid1.SetCellValue("TITLE_ALIGNMENT", this._Chart.Titles[0].Alignment);

            acVerticalGrid1.SetCellValue("TITLE_ANTI_ALIASING", this._Chart.Titles[0].Antialiasing);

            acVerticalGrid1.SetCellValue("TITLE_DOCK", this._Chart.Titles[0].Dock);



            //범례

            acVerticalGrid1.SetCellValue("LEGEND_VISIBLE", this._Chart.Legend.Visible);
            acVerticalGrid1.SetCellValue("LEGEND_VERTICAL_ALIGN", this._Chart.Legend.AlignmentVertical);
            acVerticalGrid1.SetCellValue("LEGEND_HORIZONTAL_ALIGN", this._Chart.Legend.AlignmentHorizontal);
            acVerticalGrid1.SetCellValue("LEGEND_FONT_COLOR", this._Chart.Legend.TextColor);
            acVerticalGrid1.SetCellValue("LEGEND_FONT", this._Chart.Legend.Font);
            acVerticalGrid1.SetCellValue("LEGEND_SHADOW", this._Chart.Legend.Shadow.Visible);
            acVerticalGrid1.SetCellValue("LEGEND_BORDER_VISIBLE", this._Chart.Legend.Border.Visible);
            acVerticalGrid1.SetCellValue("LEGEND_BORDER_COLOR", this._Chart.Legend.Border.Color);
            acVerticalGrid1.SetCellValue("LEGEND_ANTI_ALIASING", this._Chart.Legend.Antialiasing);

            acVerticalGrid1.SetCellValue("LEGEND_BACK_COLOR", this._Chart.Legend.BackColor);
            acVerticalGrid1.SetCellValue("LEGEND_DIRECTION", this._Chart.Legend.Direction);




            acVerticalGrid1.BestFit();

            base.OnLoad(e);
        }

        void acVerticalGrid1_OnValueChanged(object sender, string columnName, object newValue)
        {
            switch (columnName)
            {

                case "PALETTE_NAME":

                    this._Chart.PaletteName = newValue.ToString();
                    break;

                case "STYLE_NAME":

                    this._Chart.AppearanceName = newValue.ToString();

                    break;

                case "SERIES_VISIBLE":

                    for (int i = 0; i < this._Chart.Series.Count; i++)
                    {

                        this._Chart.Series[i].Label.Visible = newValue.toBoolean();
                    }

                    break;

                case "SERIES_FONT_COLOR":

                    for (int i = 0; i < this._Chart.Series.Count; i++)
                    {
                        this._Chart.Series[i].Label.TextColor = newValue.toColor();

                    }

                    break;

                case "SERIES_FONT":

                    for (int i = 0; i < this._Chart.Series.Count; i++)
                    {
                        this._Chart.Series[i].Label.Font = newValue as Font;

                    }
                    break;

                case "SERIES_SHADOW":


                    for (int i = 0; i < this._Chart.Series.Count; i++)
                    {

                        this._Chart.Series[i].Label.Shadow.Visible = newValue.toBoolean();

                    }

                    break;

                case "SERIES_BORDER_VISIBLE":

                    for (int i = 0; i < this._Chart.Series.Count; i++)
                    {
                        this._Chart.Series[i].Label.Border.Visible = newValue.toBoolean();
                    }

                    break;

                case "SERIES_BORDER_COLOR":

                    for (int i = 0; i < this._Chart.Series.Count; i++)
                    {
                        this._Chart.Series[i].Label.Border.Color = newValue.toColor();

                    }

                    break;

                case "SERIES_LINE_VISIBLE":

                    for (int i = 0; i < this._Chart.Series.Count; i++)
                    {

                        this._Chart.Series[i].Label.LineVisible = newValue.toBoolean();

                    }

                    break;

                case "SERIES_LINE_COLOR":


                    for (int i = 0; i < this._Chart.Series.Count; i++)
                    {
                        this._Chart.Series[i].Label.LineColor = newValue.toColor();

                    }

                    break;

                case "SERIES_LINE_DASH_STYLE":

                    for (int i = 0; i < this._Chart.Series.Count; i++)
                    {
                        this._Chart.Series[i].Label.LineStyle.DashStyle = (DashStyle)newValue;

                    }

                    break;

                case "SERIES_ALIASING":

                    for (int i = 0; i < this._Chart.Series.Count; i++)
                    {
                        this._Chart.Series[i].Label.Antialiasing = newValue.toBoolean();

                    }

                    break;

                case "TITLE_VISIBLE":

                    this._Chart.Titles[0].Visible = newValue.toBoolean();

                    break;

                case "TITLE_TEXT":

                    this._Chart.Titles[0].Text = newValue.ToString();

                    break;

                case "TITLE_FONT_COLOR":

                    this._Chart.Titles[0].TextColor = newValue.toColor();

                    break;

                case "TITLE_FONT":

                    this._Chart.Titles[0].Font = newValue as Font;



                    break;

                case "TITLE_ANTI_ALIASING":

                    this._Chart.Titles[0].Antialiasing = newValue.toBoolean();

                    break;

                case "TITLE_ALIGNMENT":

                    this._Chart.Titles[0].Alignment = (StringAlignment)newValue;


                    break;

                case "TITLE_DOCK":

                    this._Chart.Titles[0].Dock = (ChartTitleDockStyle)newValue;

                    break;

                case "LEGEND_VISIBLE":

                    this._Chart.Legend.Visible = newValue.toBoolean();



                    break;

                case "LEGEND_VERTICAL_ALIGN":

                    this._Chart.Legend.AlignmentVertical = (LegendAlignmentVertical)newValue;

                    break;

                case "LEGEND_HORIZONTAL_ALIGN":

                    this._Chart.Legend.AlignmentHorizontal = (LegendAlignmentHorizontal)newValue;

                    break;

                case "LEGEND_FONT_COLOR":

                    this._Chart.Legend.TextColor = newValue.toColor();

                    break;

                case "LEGEND_FONT":

                    this._Chart.Legend.Font = newValue as Font;

                    break;

                case "LEGEND_ANTI_ALIASING":

                    this._Chart.Legend.Antialiasing = newValue.toBoolean();


                    break;

                case "LEGEND_SHADOW":

                    this._Chart.Legend.Shadow.Visible = newValue.toBoolean();

                    break;

                case "LEGEND_BORDER_VISIBLE":

                    this._Chart.Legend.Border.Visible = newValue.toBoolean();

                    break;

                case "LEGEND_BORDER_COLOR":

                    this._Chart.Legend.Border.Color = newValue.toColor();


                    break;

                case "LEGEND_BACK_COLOR":

                    this._Chart.Legend.EquallySpacedItems = true;

                    this._Chart.Legend.BackColor = newValue.toColor();

                    break;

                case "LEGEND_DIRECTION":

                    this._Chart.Legend.Direction = (LegendDirection)newValue;


                    break;

            }


        }



    }
}