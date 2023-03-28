using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Linq;
using System.Drawing.Drawing2D;

namespace ControlManager
{
    public sealed partial class acPivotGridStyleBox : BaseMenuDialog
    {



        public override void BarCodeScanInput(string barcode)
        {


        }

        private acPivotGridControl _SourcePivotGrid = null;

 
        public acPivotGridStyleBox(acPivotGridControl source)
        {
            InitializeComponent();

            this._SourcePivotGrid = source;

            acVerticalGrid1.OnValueChanged += new acVerticalGrid.ValueChangedEventHandler(acVerticalGrid1_OnValueChanged);

        }



        protected override void OnLoad(EventArgs e)
        {
            List<object> linearGradientModeList = Enum.GetValues(typeof(LinearGradientMode)).Cast<object>().ToList();



            acVerticalGrid1.AddColorEdit("CELL_BACK_COLOR", "배경색", "KYF0TDNA", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);

            acVerticalGrid1.AddComboBoxEdit("CELL_GRADIENT_MODE", "그라데이션 모드", "IFXSSAZQ", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, linearGradientModeList);

            acVerticalGrid1.AddColorEdit("CELL_GRADIENT_BACK_COLOR2", "그라데이션 두번째 배경색", "6D9FSL8T", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);

            acVerticalGrid1.AddColorEdit("CELL_FONT_COLOR", "글꼴색", "URAB96B3", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);

            acVerticalGrid1.AddCustomEdit("CELL_FONT", "글꼴", "FS0E89ZT", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, new RepositoryItemFontDialogEdit());

            acVerticalGrid1.AddCategoryRow("셀", "11M4ITO2", true, new string[] {
                "CELL_BACK_COLOR"
                ,"CELL_GRADIENT_MODE"
                ,"CELL_GRADIENT_BACK_COLOR2"
                ,"CELL_FONT_COLOR"
                ,"CELL_FONT"
            });



            acVerticalGrid1.AddColorEdit("TOTAL_CELL_BACK_COLOR", "배경색", "KYF0TDNA", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);

            acVerticalGrid1.AddComboBoxEdit("TOTAL_CELL_GRADIENT_MODE", "그라데이션 모드", "IFXSSAZQ", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, linearGradientModeList);

            acVerticalGrid1.AddColorEdit("TOTAL_CELL_GRADIENT_BACK_COLOR2", "그라데이션 두번째 배경색", "6D9FSL8T", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);

            acVerticalGrid1.AddColorEdit("TOTAL_CELL_FONT_COLOR", "글꼴색", "URAB96B3", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);

            acVerticalGrid1.AddCustomEdit("TOTAL_CELL_FONT", "글꼴", "FS0E89ZT", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, new RepositoryItemFontDialogEdit());

            acVerticalGrid1.AddCategoryRow("셀 합계", "QJCOBF8R", true, new string[] {
                "TOTAL_CELL_BACK_COLOR"
                ,"TOTAL_CELL_GRADIENT_MODE"
                ,"TOTAL_CELL_GRADIENT_BACK_COLOR2"
                ,"TOTAL_CELL_FONT_COLOR"
                ,"TOTAL_CELL_FONT"
            });



            acVerticalGrid1.AddColorEdit("FIELD_HEADER_FONT_COLOR", "글꼴색", "URAB96B3", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);

            acVerticalGrid1.AddCustomEdit("FIELD_HEADER_FONT", "글꼴", "FS0E89ZT", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, new RepositoryItemFontDialogEdit());


            acVerticalGrid1.AddCategoryRow("필드 헤더", "CX1JSIMZ", true, new string[] {
                "FIELD_HEADER_FONT_COLOR"
                ,"FIELD_HEADER_FONT"
            });


            acVerticalGrid1.AddColorEdit("FIELD_VALUE_FONT_COLOR", "글꼴색", "URAB96B3", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);

            acVerticalGrid1.AddCustomEdit("FIELD_VALUE__FONT", "글꼴", "FS0E89ZT", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, new RepositoryItemFontDialogEdit());


            acVerticalGrid1.AddCategoryRow("필드값", "HRQNBLKN", true, new string[] {
                "FIELD_VALUE_FONT_COLOR"
                ,"FIELD_VALUE__FONT"
            });


            acVerticalGrid1.AddColorEdit("FIELD_TOT_VALUE_FONT_COLOR", "글꼴색", "URAB96B3", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);

            acVerticalGrid1.AddCustomEdit("FIELD_TOT_VALUE_FONT", "글꼴", "FS0E89ZT", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, new RepositoryItemFontDialogEdit());


            acVerticalGrid1.AddCategoryRow("필드값 합계", "94ZS6JQU", true, new string[] {
                "FIELD_TOT_VALUE_FONT_COLOR"
                ,"FIELD_TOT_VALUE_FONT"
            });


            acVerticalGrid1.SetCellValue("CELL_BACK_COLOR", this._SourcePivotGrid.Appearance.Cell.BackColor);
            acVerticalGrid1.SetCellValue("CELL_GRADIENT_MODE", this._SourcePivotGrid.Appearance.Cell.GradientMode);
            acVerticalGrid1.SetCellValue("CELL_GRADIENT_BACK_COLOR2", this._SourcePivotGrid.Appearance.Cell.BackColor2);
            acVerticalGrid1.SetCellValue("CELL_FONT_COLOR", this._SourcePivotGrid.Appearance.Cell.ForeColor);
            acVerticalGrid1.SetCellValue("CELL_FONT", this._SourcePivotGrid.Appearance.Cell.Font);


            acVerticalGrid1.SetCellValue("TOTAL_CELL_BACK_COLOR", this._SourcePivotGrid.Appearance.TotalCell.BackColor);
            acVerticalGrid1.SetCellValue("TOTAL_CELL_GRADIENT_MODE", this._SourcePivotGrid.Appearance.TotalCell.GradientMode);
            acVerticalGrid1.SetCellValue("TOTAL_CELL_GRADIENT_BACK_COLOR2", this._SourcePivotGrid.Appearance.TotalCell.BackColor2);
            acVerticalGrid1.SetCellValue("TOTAL_CELL_FONT_COLOR", this._SourcePivotGrid.Appearance.TotalCell.ForeColor);
            acVerticalGrid1.SetCellValue("TOTAL_CELL_FONT", this._SourcePivotGrid.Appearance.TotalCell.Font);


            acVerticalGrid1.SetCellValue("FIELD_HEADER_FONT_COLOR", this._SourcePivotGrid.Appearance.FieldHeader.ForeColor);
            acVerticalGrid1.SetCellValue("FIELD_HEADER_FONT", this._SourcePivotGrid.Appearance.FieldHeader.Font);



            acVerticalGrid1.SetCellValue("FIELD_VALUE_FONT_COLOR", this._SourcePivotGrid.Appearance.FieldValue.ForeColor);
            acVerticalGrid1.SetCellValue("FIELD_VALUE__FONT", this._SourcePivotGrid.Appearance.FieldValue.Font);


            acVerticalGrid1.SetCellValue("FIELD_TOT_VALUE_FONT_COLOR", this._SourcePivotGrid.Appearance.FieldValueTotal.ForeColor);
            acVerticalGrid1.SetCellValue("FIELD_TOT_VALUE_FONT", this._SourcePivotGrid.Appearance.FieldValueTotal.Font);


            acVerticalGrid1.BestFit();

            base.OnLoad(e);
        }

        void acVerticalGrid1_OnValueChanged(object sender, string columnName, object newValue)
        {



            switch (columnName)
            {
                case "CELL_BACK_COLOR":
                    
                    this._SourcePivotGrid.Appearance.Cell.BackColor = newValue.toColor();

                    break;

                case "CELL_GRADIENT_MODE":

                    this._SourcePivotGrid.Appearance.Cell.GradientMode = (LinearGradientMode)newValue;

                    break;

                case "CELL_GRADIENT_BACK_COLOR2":
                    
                    this._SourcePivotGrid.Appearance.Cell.BackColor2 = newValue.toColor();

                    break;

                case "CELL_FONT_COLOR":

                    this._SourcePivotGrid.Appearance.Cell.ForeColor = newValue.toColor();

                    break;

                case "CELL_FONT":

                    this._SourcePivotGrid.Appearance.Cell.Font = newValue as Font;

                    break;


                case "TOTAL_CELL_BACK_COLOR":

                    this._SourcePivotGrid.Appearance.TotalCell.BackColor = newValue.toColor();

                    break;

                case "TOTAL_CELL_GRADIENT_MODE":

                    this._SourcePivotGrid.Appearance.TotalCell.GradientMode = (LinearGradientMode)newValue;

                    break;

                case "TOTAL_CELL_GRADIENT_BACK_COLOR2":

                    this._SourcePivotGrid.Appearance.TotalCell.BackColor2 = newValue.toColor();

                    break;

                case "TOTAL_CELL_FONT_COLOR":

                    this._SourcePivotGrid.Appearance.TotalCell.ForeColor = newValue.toColor();

                    break;

                case "TOTAL_CELL_FONT":

                    this._SourcePivotGrid.Appearance.TotalCell.Font = newValue as Font;

                    break;

                case "FIELD_HEADER_FONT_COLOR":

                    this._SourcePivotGrid.Appearance.FieldHeader.ForeColor = newValue.toColor();

                    break;

                case "FIELD_HEADER_FONT":

                    this._SourcePivotGrid.Appearance.FieldHeader.Font = newValue as Font;

                    break;


                case "FIELD_VALUE_FONT_COLOR":

                    this._SourcePivotGrid.Appearance.FieldValue.ForeColor = newValue.toColor();

                    break;

                case "FIELD_VALUE__FONT":

                    this._SourcePivotGrid.Appearance.FieldValue.Font = newValue as Font;

                    break;

                case "FIELD_TOT_VALUE_FONT_COLOR":

                    this._SourcePivotGrid.Appearance.FieldValueTotal.ForeColor = newValue.toColor();

                    break;

                case "FIELD_TOT_VALUE_FONT":

                    this._SourcePivotGrid.Appearance.FieldValueTotal.Font = newValue as Font;

                    break;


            }
            
        }
    }
}