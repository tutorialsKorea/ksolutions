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
    public sealed partial class acAdvBandGridViewStyleBox : BaseMenuDialog
    {



        public override void BarCodeScanInput(string barcode)
        {


        }

        private acAdvBandGridView _SourceGridView = null;


        public acAdvBandGridViewStyleBox(acAdvBandGridView source)
        {
            InitializeComponent();

            _SourceGridView = source;

            acVerticalGrid1.OnValueChanged += new acVerticalGrid.ValueChangedEventHandler(acVerticalGrid1_OnValueChanged);

        }



        protected override void OnLoad(EventArgs e)
        {

            List<object> linearGradientModeList = Enum.GetValues(typeof(LinearGradientMode)).Cast<object>().ToList();



            acVerticalGrid1.AddColorEdit("ROW_BACK_COLOR", "배경색", "KYF0TDNA", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);

            acVerticalGrid1.AddComboBoxEdit("ROW_GRADIENT_MODE", "그라데이션 모드", "IFXSSAZQ", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, linearGradientModeList);

            acVerticalGrid1.AddColorEdit("ROW_GRADIENT_BACK_COLOR2", "그라데이션 두번째 배경색", "6D9FSL8T", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);

            acVerticalGrid1.AddColorEdit("ROW_FONT_COLOR", "글꼴색", "URAB96B3", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);

            acVerticalGrid1.AddCustomEdit("ROW_FONT", "글꼴", "FS0E89ZT", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, new RepositoryItemFontDialogEdit());

            acVerticalGrid1.AddCheckEdit("ROW_AUTO_HEIGHT", "행 자동높이", "2JJAK44P", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emCheckEditDataType._BOOL);

            acVerticalGrid1.AddTextEdit("ROW_HEIGHT", "행 높이", "50V19XAQ", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NUMERIC);


            acVerticalGrid1.AddCategoryRow("행", "4ASZA8N7", true, new string[] {
                "ROW_BACK_COLOR"
                ,"ROW_GRADIENT_MODE"
                ,"ROW_GRADIENT_BACK_COLOR2"
                ,"ROW_FONT_COLOR"
                ,"ROW_FONT"
                ,"ROW_AUTO_HEIGHT"
                ,"ROW_HEIGHT"
            });            

            acVerticalGrid1.AddCheckEdit("EVENROW_ENABLED", "사용", "UB1IGK7V", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emCheckEditDataType._BOOL);

            acVerticalGrid1.AddColorEdit("EVENROW_BACK_COLOR", "배경색", "KYF0TDNA", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);

            acVerticalGrid1.AddComboBoxEdit("EVENROW_GRADIENT_MODE", "그라데이션 모드", "IFXSSAZQ", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, linearGradientModeList);

            acVerticalGrid1.AddColorEdit("EVENROW_GRADIENT_BACK_COLOR2", "그라데이션 두번째 배경색", "6D9FSL8T", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);

            acVerticalGrid1.AddColorEdit("EVENROW_FONT_COLOR", "글꼴색", "URAB96B3", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);

            acVerticalGrid1.AddCustomEdit("EVENROW_FONT", "글꼴", "FS0E89ZT", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, new RepositoryItemFontDialogEdit());

            acVerticalGrid1.AddCategoryRow("행구분", "BVKV417A", true, new string[] {
                "EVENROW_ENABLED"
                ,"EVENROW_BACK_COLOR"
                ,"EVENROW_GRADIENT_MODE"
                ,"EVENROW_GRADIENT_BACK_COLOR2"
                ,"EVENROW_FONT_COLOR"
                ,"EVENROW_FONT"
            });


            acVerticalGrid1.AddCategoryRow("FOCUS", "포커스", "MVPDQAJQ", true, null, new string[] { });

            acVerticalGrid1.AddCheckEdit("FOCUS_CELL_ENABLE_APPEARANCE", "사용", "UB1IGK7V", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emCheckEditDataType._BOOL);
  
            acVerticalGrid1.AddColorEdit("FOCUS_CELL_BACK_COLOR", "배경색", "KYF0TDNA", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);

            acVerticalGrid1.AddComboBoxEdit("FOCUS_CELL_GRADIENT_MODE", "그라데이션 모드", "IFXSSAZQ", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, linearGradientModeList);

            acVerticalGrid1.AddColorEdit("FOCUS_CELL_GRADIENT_BACK_COLOR2", "그라데이션 두번째 배경색", "6D9FSL8T", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);

            acVerticalGrid1.AddColorEdit("FOCUS_CELL_FONT_COLOR", "글꼴색", "URAB96B3", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);

            acVerticalGrid1.AddCustomEdit("FOCUS_CELL_FONT", "글꼴", "FS0E89ZT", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, new RepositoryItemFontDialogEdit());


            acVerticalGrid1.AddCategoryRow("FOCUS_CELL", "셀", "11M4ITO2", true, "FOCUS", new string[] {
                "FOCUS_CELL_ENABLE_APPEARANCE"
                ,"FOCUS_CELL_BACK_COLOR"
                ,"FOCUS_CELL_GRADIENT_MODE"
                ,"FOCUS_CELL_GRADIENT_BACK_COLOR2"
                ,"FOCUS_CELL_FONT_COLOR"
                ,"FOCUS_CELL_FONT"
            });

            acVerticalGrid1.AddCheckEdit("FOCUS_ROW_ENABLE_APPEARANCE", "사용", "UB1IGK7V", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emCheckEditDataType._BOOL);

            acVerticalGrid1.AddColorEdit("FOCUS_ROW_BACK_COLOR", "배경색", "KYF0TDNA", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);

            acVerticalGrid1.AddComboBoxEdit("FOCUS_ROW_GRADIENT_MODE", "그라데이션 모드", "IFXSSAZQ", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, linearGradientModeList);

            acVerticalGrid1.AddColorEdit("FOCUS_ROW_GRADIENT_BACK_COLOR2", "그라데이션 두번째 배경색", "6D9FSL8T", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);

            acVerticalGrid1.AddColorEdit("FOCUS_ROW_FONT_COLOR", "글꼴색", "URAB96B3", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);

            acVerticalGrid1.AddCustomEdit("FOCUS_ROW_FONT", "글꼴", "FS0E89ZT", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, new RepositoryItemFontDialogEdit());


            acVerticalGrid1.AddCategoryRow("FOCUS_ROW", "행", "4ASZA8N7", true, "FOCUS", new string[] {
                "FOCUS_ROW_ENABLE_APPEARANCE"
                ,"FOCUS_ROW_BACK_COLOR"
                ,"FOCUS_ROW_GRADIENT_MODE"
                ,"FOCUS_ROW_GRADIENT_BACK_COLOR2"
                ,"FOCUS_ROW_FONT_COLOR"
                ,"FOCUS_ROW_FONT"
            });






            acVerticalGrid1.AddCheckEdit("HIDE_SELECTION_ROW_ENABLE_APPEARANCE", "사용", "UB1IGK7V", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emCheckEditDataType._BOOL);

            acVerticalGrid1.AddColorEdit("HIDE_SELECTION_ROW_BACK_COLOR", "배경색", "KYF0TDNA", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);

            acVerticalGrid1.AddComboBoxEdit("HIDE_SELECTION_ROW_GRADIENT_MODE", "그라데이션 모드", "IFXSSAZQ", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, linearGradientModeList);

            acVerticalGrid1.AddColorEdit("HIDE_SELECTION_ROW_GRADIENT_BACK_COLOR2", "그라데이션 두번째 배경색", "6D9FSL8T", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);

            acVerticalGrid1.AddColorEdit("HIDE_SELECTION_ROW_FONT_COLOR", "글꼴색", "URAB96B3", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);

            acVerticalGrid1.AddCustomEdit("HIDE_SELECTION_ROW_FONT", "글꼴", "FS0E89ZT", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, new RepositoryItemFontDialogEdit());


            acVerticalGrid1.AddCategoryRow("숨김 행", "7IXJYKD5", true, new string[] {
                "HIDE_SELECTION_ROW_ENABLE_APPEARANCE"
                ,"HIDE_SELECTION_ROW_BACK_COLOR"
                ,"HIDE_SELECTION_ROW_GRADIENT_MODE"
                ,"HIDE_SELECTION_ROW_GRADIENT_BACK_COLOR2"
                ,"HIDE_SELECTION_ROW_FONT_COLOR"
                ,"HIDE_SELECTION_ROW_FONT"
            });
                

            acVerticalGrid1.AddColorEdit("EDITABLE_CELL_BACK_COLOR", "배경색", "KYF0TDNA", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);

            acVerticalGrid1.AddComboBoxEdit("EDITABLE_CELL_GRADIENT_MODE", "그라데이션 모드", "IFXSSAZQ", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, linearGradientModeList);

            acVerticalGrid1.AddColorEdit("EDITABLE_CELL_GRADIENT_BACK_COLOR2", "그라데이션 두번째 배경색", "6D9FSL8T", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);

            acVerticalGrid1.AddColorEdit("EDITABLE_CELL_FONT_COLOR", "글꼴색", "URAB96B3", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);

            acVerticalGrid1.AddCustomEdit("EDITABLE_CELL_FONT", "글꼴", "FS0E89ZT", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, new RepositoryItemFontDialogEdit());


            acVerticalGrid1.AddCategoryRow("수정가능 셀", "M15CQO71", true, new string[] {
                "EDITABLE_CELL_BACK_COLOR"
                ,"EDITABLE_CELL_GRADIENT_MODE"
                ,"EDITABLE_CELL_GRADIENT_BACK_COLOR2"
                ,"EDITABLE_CELL_FONT_COLOR"
                ,"EDITABLE_CELL_FONT"
            });




            acVerticalGrid1.AddColorEdit("MODIFIED_ROW_BACK_COLOR", "배경색", "KYF0TDNA", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);

            acVerticalGrid1.AddComboBoxEdit("MODIFIED_ROW_GRADIENT_MODE", "그라데이션 모드", "IFXSSAZQ", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, linearGradientModeList);

            acVerticalGrid1.AddColorEdit("MODIFIED_ROW_GRADIENT_BACK_COLOR2", "그라데이션 두번째 배경색", "6D9FSL8T", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);

            acVerticalGrid1.AddColorEdit("MODIFIED_ROW_FONT_COLOR", "글꼴색", "URAB96B3", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);

            acVerticalGrid1.AddCustomEdit("MODIFIED_ROW_FONT", "글꼴", "FS0E89ZT", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, new RepositoryItemFontDialogEdit());


            acVerticalGrid1.AddCategoryRow("변경된 행", "YMHF30RS", true, new string[] {
                "MODIFIED_ROW_BACK_COLOR"
                ,"MODIFIED_ROW_GRADIENT_MODE"
                ,"MODIFIED_ROW_GRADIENT_BACK_COLOR2"
                ,"MODIFIED_ROW_FONT_COLOR"
                ,"MODIFIED_ROW_FONT"
            });




            acVerticalGrid1.AddColorEdit("COLUMN_FONT_COLOR", "글꼴색", "URAB96B3", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);

            acVerticalGrid1.AddCustomEdit("COLUMN_FONT", "글꼴", "FS0E89ZT", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, new RepositoryItemFontDialogEdit());

            acVerticalGrid1.AddCheckEdit("COLUMN_AUTO_WIDTH", "컬럼 자동크기", "KT5H6DIK", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emCheckEditDataType._BOOL);

            acVerticalGrid1.AddCategoryRow("컬럼", "8HEB5JMB", true, new string[] {
                "COLUMN_FONT_COLOR"
                ,"COLUMN_FONT"
                ,"COLUMN_AUTO_WIDTH"
            });



            acVerticalGrid1.AddCategoryRow("LINE", "선", "97Q1FR6F", true, null, new string[] { });


            acVerticalGrid1.AddCheckEdit("LINE_HORIZ_SHOW", "표시", "0VXIPFNO", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emCheckEditDataType._BOOL);

            acVerticalGrid1.AddColorEdit("LINE_HORIZ_COLOR", "색상", "40281", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);


            acVerticalGrid1.AddCategoryRow("LINE_HORIZ", "세로", "LTW1YLT6", true, "LINE", new string[] {
                "LINE_HORIZ_SHOW"
                ,"LINE_HORIZ_COLOR"
            });


            acVerticalGrid1.AddCheckEdit("LINE_VERTI_SHOW", "표시", "0VXIPFNO", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emCheckEditDataType._BOOL);

            acVerticalGrid1.AddColorEdit("LINE_VERTI_COLOR", "색상", "40281", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);

            acVerticalGrid1.AddCategoryRow("LINE_VERTI", "가로", "XG3313AV", true, "LINE", new string[] {
                "LINE_VERTI_SHOW"
                ,"LINE_VERTI_COLOR"
            });



            //행

            acVerticalGrid1.SetCellValue("ROW_BACK_COLOR", this._SourceGridView.Appearance.Row.BackColor);

            acVerticalGrid1.SetCellValue("ROW_GRADIENT_MODE", this._SourceGridView.Appearance.Row.GradientMode);

            acVerticalGrid1.SetCellValue("ROW_GRADIENT_BACK_COLOR2", this._SourceGridView.Appearance.Row.BackColor2);

            acVerticalGrid1.SetCellValue("ROW_FONT_COLOR", this._SourceGridView.Appearance.Row.ForeColor);
            
            acVerticalGrid1.SetCellValue("ROW_FONT", this._SourceGridView.Appearance.Row.Font);

            acVerticalGrid1.SetCellValue("ROW_AUTO_HEIGHT", this._SourceGridView.OptionsView.RowAutoHeight);

            acVerticalGrid1.SetCellValue("ROW_HEIGHT", this._SourceGridView.RowHeight);

            //행구분

            acVerticalGrid1.SetCellValue("EVENROW_ENABLED", this._SourceGridView.OptionsView.EnableAppearanceEvenRow);

            acVerticalGrid1.SetCellValue("EVENROW_BACK_COLOR", this._SourceGridView.Appearance.EvenRow.BackColor);

            acVerticalGrid1.SetCellValue("EVENROW_GRADIENT_MODE", this._SourceGridView.Appearance.EvenRow.GradientMode);

            acVerticalGrid1.SetCellValue("EVENROW_GRADIENT_BACK_COLOR2", this._SourceGridView.Appearance.EvenRow.BackColor2);

            acVerticalGrid1.SetCellValue("EVENROW_FONT_COLOR", this._SourceGridView.Appearance.EvenRow.ForeColor);

            acVerticalGrid1.SetCellValue("EVENROW_FONT", this._SourceGridView.Appearance.EvenRow.Font);


            acVerticalGrid1.SetCellValue("FOCUS_CELL_ENABLE_APPEARANCE", this._SourceGridView.OptionsSelection.EnableAppearanceFocusedCell);
            acVerticalGrid1.SetCellValue("FOCUS_CELL_BACK_COLOR", this._SourceGridView.Appearance.FocusedCell.BackColor);
            acVerticalGrid1.SetCellValue("FOCUS_CELL_GRADIENT_MODE", this._SourceGridView.Appearance.FocusedCell.GradientMode);
            acVerticalGrid1.SetCellValue("FOCUS_CELL_GRADIENT_BACK_COLOR2",  this._SourceGridView.Appearance.FocusedCell.BackColor2);
            acVerticalGrid1.SetCellValue("FOCUS_CELL_FONT_COLOR", this._SourceGridView.Appearance.FocusedCell.ForeColor);
            acVerticalGrid1.SetCellValue("FOCUS_CELL_FONT", this._SourceGridView.Appearance.FocusedCell.Font);


            acVerticalGrid1.SetCellValue("FOCUS_ROW_ENABLE_APPEARANCE", this._SourceGridView.OptionsSelection.EnableAppearanceFocusedRow);
            acVerticalGrid1.SetCellValue("FOCUS_ROW_BACK_COLOR", this._SourceGridView.Appearance.FocusedRow.BackColor);
            acVerticalGrid1.SetCellValue("FOCUS_ROW_GRADIENT_MODE", this._SourceGridView.Appearance.FocusedRow.GradientMode);
            acVerticalGrid1.SetCellValue("FOCUS_ROW_GRADIENT_BACK_COLOR2", this._SourceGridView.Appearance.FocusedRow.BackColor2);
            acVerticalGrid1.SetCellValue("FOCUS_ROW_FONT_COLOR", this._SourceGridView.Appearance.FocusedRow.ForeColor);
            acVerticalGrid1.SetCellValue("FOCUS_ROW_FONT", this._SourceGridView.Appearance.FocusedRow.Font);



            acVerticalGrid1.SetCellValue("HIDE_SELECTION_ROW_ENABLE_APPEARANCE", this._SourceGridView.OptionsSelection.EnableAppearanceHideSelection);
            acVerticalGrid1.SetCellValue("HIDE_SELECTION_ROW_BACK_COLOR", this._SourceGridView.Appearance.HideSelectionRow.BackColor);
            acVerticalGrid1.SetCellValue("HIDE_SELECTION_ROW_GRADIENT_MODE", this._SourceGridView.Appearance.HideSelectionRow.GradientMode);
            acVerticalGrid1.SetCellValue("HIDE_SELECTION_ROW_GRADIENT_BACK_COLOR2", this._SourceGridView.Appearance.HideSelectionRow.BackColor2);
            acVerticalGrid1.SetCellValue("HIDE_SELECTION_ROW_FONT_COLOR", this._SourceGridView.Appearance.HideSelectionRow.ForeColor);
            acVerticalGrid1.SetCellValue("HIDE_SELECTION_ROW_FONT", this._SourceGridView.Appearance.HideSelectionRow.Font);



            acVerticalGrid1.SetCellValue("EDITABLE_CELL_BACK_COLOR", this._SourceGridView._Config.EditCellStyle.BackColor);
            acVerticalGrid1.SetCellValue("EDITABLE_CELL_GRADIENT_MODE", this._SourceGridView._Config.EditCellStyle.GradientMode);
            acVerticalGrid1.SetCellValue("EDITABLE_CELL_GRADIENT_BACK_COLOR2", this._SourceGridView._Config.EditCellStyle.BackColor2);
            acVerticalGrid1.SetCellValue("EDITABLE_CELL_FONT_COLOR", this._SourceGridView._Config.EditCellStyle.ForeColor);
            acVerticalGrid1.SetCellValue("EDITABLE_CELL_FONT",this._SourceGridView._Config.EditCellStyle.Font);


            acVerticalGrid1.SetCellValue("MODIFIED_ROW_BACK_COLOR", this._SourceGridView._Config.ModifiedRowStyle.BackColor);
            acVerticalGrid1.SetCellValue("MODIFIED_ROW_GRADIENT_MODE", this._SourceGridView._Config.ModifiedRowStyle.GradientMode);
            acVerticalGrid1.SetCellValue("MODIFIED_ROW_GRADIENT_BACK_COLOR2", this._SourceGridView._Config.ModifiedRowStyle.BackColor2);
            acVerticalGrid1.SetCellValue("MODIFIED_ROW_FONT_COLOR", this._SourceGridView._Config.ModifiedRowStyle.ForeColor);
            acVerticalGrid1.SetCellValue("MODIFIED_ROW_FONT", this._SourceGridView._Config.ModifiedRowStyle.Font);



            acVerticalGrid1.SetCellValue("COLUMN_FONT_COLOR", this._SourceGridView.Appearance.HeaderPanel.ForeColor);
            acVerticalGrid1.SetCellValue("COLUMN_FONT", this._SourceGridView.Appearance.HeaderPanel.Font);
            acVerticalGrid1.SetCellValue("COLUMN_AUTO_WIDTH", this._SourceGridView.OptionsView.ColumnAutoWidth);
            

            //acVerticalGrid1.SetCellValue("LINE_HORIZ_SHOW", this._SourceGridView.OptionsView.ShowHorzLines);
            acVerticalGrid1.SetCellValue("LINE_HORIZ_SHOW", this._SourceGridView.OptionsView.ShowHorizontalLines);
            acVerticalGrid1.SetCellValue("LINE_HORIZ_COLOR", this._SourceGridView.Appearance.HorzLine.BackColor);

            //acVerticalGrid1.SetCellValue("LINE_VERTI_SHOW", this._SourceGridView.OptionsView.ShowVertLines);
            acVerticalGrid1.SetCellValue("LINE_VERTI_SHOW", this._SourceGridView.OptionsView.ShowVerticalLines);
            acVerticalGrid1.SetCellValue("LINE_VERTI_COLOR", this._SourceGridView.Appearance.VertLine.BackColor);



            acVerticalGrid1.BestFit();

            base.OnLoad(e);
        }
        void acVerticalGrid1_OnValueChanged(object sender, string columnName, object newValue)
        {
            switch (columnName)
            {

                case "ROW_BACK_COLOR":

                    this._SourceGridView.Appearance.Row.BackColor = newValue.toColor();

                    break;

                case "ROW_GRADIENT_MODE":
                    
                    this._SourceGridView.Appearance.Row.GradientMode = (LinearGradientMode)newValue;

                    break;

                case "ROW_GRADIENT_BACK_COLOR2":

                    this._SourceGridView.Appearance.Row.BackColor2 = newValue.toColor();
                    break;

                case "ROW_FONT_COLOR":

                    this._SourceGridView.Appearance.Row.ForeColor = newValue.toColor();
                    
                    break;

                case "ROW_FONT":

                    this._SourceGridView.Appearance.Row.Font = newValue as Font;

                    break;

                case "ROW_AUTO_HEIGHT":

                    this._SourceGridView.OptionsView.RowAutoHeight = newValue.toBoolean();

                    break;

                case "ROW_HEIGHT":

                    this._SourceGridView.RowHeight = newValue.toInt();
                    break;

                case "EVENROW_ENABLED":

                    this._SourceGridView.OptionsView.EnableAppearanceEvenRow = newValue.toBoolean();

                    break;

                case "EVENROW_BACK_COLOR":

                    this._SourceGridView.Appearance.EvenRow.BackColor = newValue.toColor();

                    break;

                case "EVENROW_GRADIENT_MODE":

                    this._SourceGridView.Appearance.EvenRow.GradientMode = (LinearGradientMode)newValue;
                    break;

                case "EVENROW_GRADIENT_BACK_COLOR2":

                    this._SourceGridView.Appearance.EvenRow.BackColor2 = newValue.toColor();

                    break;

                case "EVENROW_FONT_COLOR":

                    this._SourceGridView.Appearance.EvenRow.ForeColor = newValue.toColor();

                    break;

                case "EVENROW_FONT":

                    this._SourceGridView.Appearance.EvenRow.Font = newValue as Font;

                    break;

                case "FOCUS_CELL_ENABLE_APPEARANCE":

                    this._SourceGridView.OptionsSelection.EnableAppearanceFocusedCell = newValue.toBoolean();

                    break;

                case "FOCUS_CELL_BACK_COLOR":

                    this._SourceGridView.Appearance.FocusedCell.BackColor = newValue.toColor();

                    break;

                case "FOCUS_CELL_GRADIENT_MODE":

                    this._SourceGridView.Appearance.FocusedCell.GradientMode = (LinearGradientMode)newValue;

                    break;

                case "FOCUS_CELL_GRADIENT_BACK_COLOR2":

                    this._SourceGridView.Appearance.FocusedCell.BackColor2 = newValue.toColor();

                    break;

                case "FOCUS_CELL_FONT_COLOR":

                    this._SourceGridView.Appearance.FocusedCell.ForeColor = newValue.toColor();

                    break;

                case "FOCUS_CELL_FONT":

                    this._SourceGridView.Appearance.FocusedCell.Font = newValue as Font;

                    break;

                case "FOCUS_ROW_ENABLE_APPEARANCE":

                    this._SourceGridView.OptionsSelection.EnableAppearanceFocusedRow = newValue.toBoolean();

                    break;

                case "FOCUS_ROW_BACK_COLOR":

                    this._SourceGridView.Appearance.FocusedRow.BackColor = newValue.toColor();

                    break;

                case "FOCUS_ROW_GRADIENT_MODE":

                    this._SourceGridView.Appearance.FocusedRow.GradientMode = (LinearGradientMode)newValue;
                    break;

                case "FOCUS_ROW_GRADIENT_BACK_COLOR2":

                    this._SourceGridView.Appearance.FocusedRow.BackColor2 = newValue.toColor();

                    break;

                case "FOCUS_ROW_FONT_COLOR":

                    this._SourceGridView.Appearance.FocusedRow.ForeColor = newValue.toColor();

                    break;

                case "FOCUS_ROW_FONT":

                    this._SourceGridView.Appearance.FocusedRow.Font = newValue as Font;

                    break;

                case "HIDE_SELECTION_ROW_ENABLE_APPEARANCE":

                    this._SourceGridView.OptionsSelection.EnableAppearanceHideSelection = newValue.toBoolean();
                    break;

                case "HIDE_SELECTION_ROW_BACK_COLOR":
                    
                    this._SourceGridView.Appearance.HideSelectionRow.BackColor = newValue.toColor();

                    break;

                case "HIDE_SELECTION_ROW_GRADIENT_MODE":

                    this._SourceGridView.Appearance.HideSelectionRow.GradientMode = (LinearGradientMode)newValue;
                    break;

                case "HIDE_SELECTION_ROW_GRADIENT_BACK_COLOR2":
                    
                    this._SourceGridView.Appearance.HideSelectionRow.BackColor2 = newValue.toColor();

                    break;

                case "HIDE_SELECTION_ROW_FONT_COLOR":
                    
                    this._SourceGridView.Appearance.HideSelectionRow.ForeColor = newValue.toColor();

                    break;

                case "HIDE_SELECTION_ROW_FONT":
                    this._SourceGridView.Appearance.HideSelectionRow.Font = newValue as Font;

                    break;

                case "EDITABLE_CELL_BACK_COLOR":

                    this._SourceGridView._Config.EditCellStyle.BackColor = newValue.toColor();

                    break;

                case "EDITABLE_CELL_GRADIENT_MODE":

                    this._SourceGridView._Config.EditCellStyle.GradientMode = (LinearGradientMode)newValue;

                    break;

                case "EDITABLE_CELL_GRADIENT_BACK_COLOR2":

                    this._SourceGridView._Config.EditCellStyle.BackColor2 = newValue.toColor();

                    break;

                case "EDITABLE_CELL_FONT_COLOR":

                    this._SourceGridView._Config.EditCellStyle.ForeColor = newValue.toColor();

                    break;

                case "EDITABLE_CELL_FONT":

                    this._SourceGridView._Config.EditCellStyle.Font = newValue as Font;

                    break;

                case "MODIFIED_ROW_BACK_COLOR":

                    this._SourceGridView._Config.ModifiedRowStyle.BackColor = newValue.toColor();

                    break;

                case "MODIFIED_ROW_GRADIENT_MODE":
                    
                    this._SourceGridView._Config.ModifiedRowStyle.GradientMode = (LinearGradientMode)newValue;

                    break;

                case "MODIFIED_ROW_GRADIENT_BACK_COLOR2":

                    this._SourceGridView._Config.ModifiedRowStyle.BackColor2 = newValue.toColor();

                    break;

                case "MODIFIED_ROW_FONT_COLOR":

                    this._SourceGridView._Config.ModifiedRowStyle.ForeColor = newValue.toColor();

                    break;

                case "MODIFIED_ROW_FONT":

                    this._SourceGridView._Config.ModifiedRowStyle.Font = newValue as Font;

                    break;

                case "COLUMN_FONT_COLOR":

                    this._SourceGridView.Appearance.HeaderPanel.ForeColor = newValue.toColor();

                    break;

                case "COLUMN_FONT":

                    this._SourceGridView.Appearance.HeaderPanel.Font = newValue as Font;

                    break;

                case "COLUMN_AUTO_WIDTH":
                    
                    this._SourceGridView.OptionsView.ColumnAutoWidth = newValue.toBoolean();

                    break;

                case "LINE_HORIZ_SHOW":

                    //this._SourceGridView.OptionsView.ShowHorzLines = newValue.toBoolean();
                    if (newValue.toBoolean())
                    {
                        this._SourceGridView.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.True;
                    }
                    else
                    {
                        this._SourceGridView.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.False;
                    }

                    break;

                case "LINE_HORIZ_COLOR":


                    this._SourceGridView.Appearance.HorzLine.BackColor = newValue.toColor();

                    break;

                case "LINE_VERTI_SHOW":

                    //this._SourceGridView.OptionsView.ShowVertLines = newValue.toBoolean();                    
                    if (newValue.toBoolean())
                    {
                        this._SourceGridView.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.True;
                    }
                    else
                    {
                        this._SourceGridView.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
                    }

                    break;


                case "LINE_VERTI_COLOR":

                    this._SourceGridView.Appearance.VertLine.BackColor = newValue.toColor();
                    

                    break;
            }
           
        }
    }
}