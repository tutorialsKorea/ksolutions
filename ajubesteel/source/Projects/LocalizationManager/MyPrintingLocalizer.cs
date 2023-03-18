using System;
using System.Collections.Generic;
using System.Text;
using ControlManager;

namespace LocalizationManager
{
    public class MyPrintingLocalizer : DevExpress.XtraPrinting.Localization.PreviewLocalizer
    {
        public override string GetLocalizedString(DevExpress.XtraPrinting.Localization.PreviewStringId id)
        {
            switch (id)
            {
                case DevExpress.XtraPrinting.Localization.PreviewStringId.BarText_MainMenu:

                    return acInfo.Resource.GetString("메인메뉴", "FFN5SW38");

                case DevExpress.XtraPrinting.Localization.PreviewStringId.BarText_StatusBar:

                    return acInfo.Resource.GetString("상태바", "NZ9JP9DH");

                case DevExpress.XtraPrinting.Localization.PreviewStringId.BarText_Toolbar:

                    return acInfo.Resource.GetString("도구상자", "I7LE433K");

                case DevExpress.XtraPrinting.Localization.PreviewStringId.Button_Apply:

                    return acInfo.Resource.GetString("적용", "H80OCOQV");

                case DevExpress.XtraPrinting.Localization.PreviewStringId.Button_Cancel:

                    return acInfo.Resource.GetString("취소", "FRR80RHR");

                case DevExpress.XtraPrinting.Localization.PreviewStringId.Button_Help:

                    return acInfo.Resource.GetString("도움말", "TGFJ3JK4");

                case DevExpress.XtraPrinting.Localization.PreviewStringId.Button_Ok:

                    return acInfo.Resource.GetString("확인", "KD40ZNWK");

                case DevExpress.XtraPrinting.Localization.PreviewStringId.EMail_From:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.ExportOption_HtmlCharacterSet:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.ExportOption_HtmlExportMode:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.ExportOption_HtmlExportMode_DifferentFiles:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.ExportOption_HtmlExportMode_SingleFile:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.ExportOption_HtmlExportMode_SingleFilePageByPage:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.ExportOption_HtmlPageBorderColor:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.ExportOption_HtmlPageBorderWidth:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.ExportOption_HtmlPageRange:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.ExportOption_HtmlRemoveSecondarySymbols:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.ExportOption_HtmlTitle:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.ExportOption_ImageExportMode:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.ExportOption_ImageExportMode_DifferentFiles:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.ExportOption_ImageExportMode_SingleFile:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.ExportOption_ImageExportMode_SingleFilePageByPage:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.ExportOption_ImageFormat:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.ExportOption_ImagePageBorderColor:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.ExportOption_ImagePageBorderWidth:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.ExportOption_ImagePageRange:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.ExportOption_ImageResolution:
                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.ExportOption_NativeFormatCompressed:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.ExportOption_PdfCompressed:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.ExportOption_PdfDocumentApplication:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.ExportOption_PdfDocumentAuthor:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.ExportOption_PdfDocumentKeywords:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.ExportOption_PdfDocumentSubject:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.ExportOption_PdfDocumentTitle:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.ExportOption_PdfImageQuality:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.ExportOption_PdfImageQuality_High:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.ExportOption_PdfImageQuality_Highest:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.ExportOption_PdfImageQuality_Low:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.ExportOption_PdfImageQuality_Lowest:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.ExportOption_PdfImageQuality_Medium:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.ExportOption_PdfNeverEmbeddedFonts:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.ExportOption_PdfPageRange:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.ExportOption_PdfShowPrintDialogOnOpen:

                    break;


                case DevExpress.XtraPrinting.Localization.PreviewStringId.ExportOption_RtfExportMode:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.ExportOption_RtfExportMode_SingleFile:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.ExportOption_RtfExportMode_SingleFilePageByPage:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.ExportOption_RtfExportWatermarks:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.ExportOption_RtfPageRange:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.ExportOption_TextEncoding:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.ExportOption_TextQuoteStringsWithSeparators:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.ExportOption_TextSeparator:

                    break;


                case DevExpress.XtraPrinting.Localization.PreviewStringId.ExportOption_TextSeparator_TabAlias:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.ExportOption_XlsSheetName:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.ExportOption_XlsShowGridLines:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.ExportOption_XlsUseNativeFormat:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.ExportOptionsForm_CaptionCsv:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.ExportOptionsForm_CaptionHtml:


                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.ExportOptionsForm_CaptionImage:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.ExportOptionsForm_CaptionMht:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.ExportOptionsForm_CaptionNativeOptions:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.ExportOptionsForm_CaptionPdf:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.ExportOptionsForm_CaptionRtf:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.ExportOptionsForm_CaptionTxt:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.ExportOptionsForm_CaptionXls:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.FolderBrowseDlg_ExportDirectory:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.Margin_BottomMargin:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.Margin_Inch:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.Margin_LeftMargin:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.Margin_Millimeter:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.Margin_RightMargin:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.Margin_TopMargin:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.MenuItem_BackgrColor:

                    return acInfo.Resource.GetString("배경색", "KYF0TDNA");

                case DevExpress.XtraPrinting.Localization.PreviewStringId.MenuItem_Background:

                    return acInfo.Resource.GetString("배경", "MZHLUE66");

                case DevExpress.XtraPrinting.Localization.PreviewStringId.MenuItem_CsvDocument:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.MenuItem_Exit:

                    return acInfo.Resource.GetString("미리보기 종료", "BALD7IWV");

                case DevExpress.XtraPrinting.Localization.PreviewStringId.MenuItem_Export:

                    return acInfo.Resource.GetString("파일 내보내기", "TEMS9X9O");


                case DevExpress.XtraPrinting.Localization.PreviewStringId.MenuItem_File:

                    return acInfo.Resource.GetString("파일", "0CMDK0UT");

                case DevExpress.XtraPrinting.Localization.PreviewStringId.MenuItem_GraphicDocument:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.MenuItem_HtmDocument:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.MenuItem_MhtDocument:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.MenuItem_PageLayout:

                    return acInfo.Resource.GetString("페이지 레이아웃", "SM7R1WC4");

                case DevExpress.XtraPrinting.Localization.PreviewStringId.MenuItem_PageSetup:

                    return acInfo.Resource.GetString("페이지 설정", "LIDHDQ1J");


                case DevExpress.XtraPrinting.Localization.PreviewStringId.MenuItem_PdfDocument:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.MenuItem_Print:

                    return acInfo.Resource.GetString("인쇄", "4HOA9EHQ");

                case DevExpress.XtraPrinting.Localization.PreviewStringId.MenuItem_PrintDirect:

                    return acInfo.Resource.GetString("빠른 인쇄", "U6B3HGH3");



                case DevExpress.XtraPrinting.Localization.PreviewStringId.MenuItem_RtfDocument:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.MenuItem_Send:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.MenuItem_TxtDocument:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.MenuItem_View:


                    return acInfo.Resource.GetString("보기", "YRUN9BAT");


                case DevExpress.XtraPrinting.Localization.PreviewStringId.MenuItem_ViewContinuous:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.MenuItem_ViewFacing:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.MenuItem_ViewStatusbar:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.MenuItem_ViewToolbar:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.MenuItem_Watermark:

                    return acInfo.Resource.GetString("워터마크", "NSBHPBBM");


                case DevExpress.XtraPrinting.Localization.PreviewStringId.MenuItem_XlsDocument:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.MenuItem_ZoomPageWidth:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.MenuItem_ZoomTextWidth:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.MenuItem_ZoomTwoPages:

                    break;


                case DevExpress.XtraPrinting.Localization.PreviewStringId.MenuItem_ZoomWholePage:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.MPForm_Lbl_Pages:

                    return acInfo.Resource.GetString("페이지", "JV9UN6O8");

                case DevExpress.XtraPrinting.Localization.PreviewStringId.Msg_BigBitmapToCreate:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.Msg_BigFileToCreateJPEG:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.Msg_CannotAccessFile:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.Msg_CantFitBarcodeToControlBounds:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.Msg_CreatingDocument:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.Msg_CustomDrawWarning:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.Msg_EmptyDocument:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.Msg_FileDosntContainValidXml:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.Msg_FileDosntHavePrnxExtention:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.Msg_FileReadOnly:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.Msg_FontInvalidNumber:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.Msg_IncorrectPageRange:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.Msg_IncorrectZoomFactor:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.Msg_InvalidBarcodeText:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.Msg_InvalidBarcodeTextFormat:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.Msg_InvalidMeasurement:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.Msg_NeedPrinter:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.Msg_NoDifferentFilesInStream:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.Msg_NotSupportedFont:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.Msg_OpenFileQuestion:

                    return acInfo.Resource.GetString("파일을 여시겠습니까?", "C5FDPXF8");

                case DevExpress.XtraPrinting.Localization.PreviewStringId.Msg_OpenFileQuestionCaption:

                    return acInfo.Resource.GetString("파일열기", "1U95KG44");

                case DevExpress.XtraPrinting.Localization.PreviewStringId.Msg_PageMarginsWarning:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.Msg_SearchDialogFinishedSearching:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.Msg_SearchDialogReady:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.Msg_SearchDialogTotalFound:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.Msg_UnavailableNetPrinter:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.Msg_WrongPageSettings:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.Msg_WrongPrinter:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.Msg_WrongPrinting:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.Msg_XlsMoreThanMaxColumns:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.Msg_XlsMoreThanMaxRows:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.OpenFileDialog_Filter:

                    break;


                case DevExpress.XtraPrinting.Localization.PreviewStringId.OpenFileDialog_Title:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.PageInfo_PageDate:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.PageInfo_PageNumber:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.PageInfo_PageNumberOfTotal:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.PageInfo_PageTime:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.PageInfo_PageUserName:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.PreviewForm_Caption:

                    return acInfo.Resource.GetString("미리보기", "KS4ZE4QN");

                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_ClosePreview_Caption:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_ClosePreview_STipContent:

                    break;


                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_ClosePreview_STipTitle:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_Customize_Caption:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_Customize_STipContent:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_Customize_STipTitle:


                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_DocumentMap_Caption:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_DocumentMap_STipContent:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_DocumentMap_STipTitle:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_EditPageHF_Caption:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_EditPageHF_STipContent:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_EditPageHF_STipTitle:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_ExportCsv_Caption:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_ExportCsv_Description:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_ExportCsv_STipContent:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_ExportCsv_STipTitle:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_ExportFile_Caption:

                    break;


                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_ExportFile_STipContent:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_ExportFile_STipTitle:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_ExportGraphic_Caption:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_ExportGraphic_Description:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_ExportGraphic_STipContent:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_ExportGraphic_STipTitle:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_ExportHtm_Caption:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_ExportHtm_Description:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_ExportHtm_STipContent:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_ExportHtm_STipTitle:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_ExportMht_Caption:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_ExportMht_Description:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_ExportMht_STipContent:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_ExportMht_STipTitle:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_ExportPdf_Caption:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_ExportPdf_Description:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_ExportPdf_STipContent:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_ExportPdf_STipTitle:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_ExportRtf_Caption:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_ExportRtf_Description:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_ExportRtf_STipContent:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_ExportRtf_STipTitle:

                    break;


                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_ExportTxt_Caption:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_ExportTxt_Description:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_ExportTxt_STipContent:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_ExportTxt_STipTitle:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_ExportXls_Caption:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_ExportXls_Description:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_ExportXls_STipContent:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_ExportXls_STipTitle:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_FillBackground_Caption:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_FillBackground_STipContent:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_FillBackground_STipTitle:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_Find_Caption:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_Find_STipContent:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_Find_STipTitle:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_GalleryItem_PageMargins_Description:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_GalleryItem_PageMarginsModerate_Caption:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_GalleryItem_PageMarginsModerate_Description:

                    break;


                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_GalleryItem_PageMarginsNarrow_Caption:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_GalleryItem_PageMarginsNarrow_Description:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_GalleryItem_PageMarginsNormal_Caption:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_GalleryItem_PageMarginsNormal_Description:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_GalleryItem_PageMarginsWide_Caption:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_GalleryItem_PageMarginsWide_Description:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_GalleryItem_PageOrientationLandscape_Caption:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_GalleryItem_PageOrientationLandscape_Description:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_GalleryItem_PageOrientationPortrait_Caption:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_GalleryItem_PageOrientationPortrait_Description:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_GalleryItem_PaperSize_Description:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_HandTool_Caption:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_HandTool_STipContent:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_HandTool_STipTitle:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_Magnifier_Caption:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_Magnifier_STipContent:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_Magnifier_STipTitle:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_MultiplePages_Caption:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_MultiplePages_STipContent:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_MultiplePages_STipTitle:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_Open_Caption:

                    return acInfo.Resource.GetString("열기", "5E5CQSN3");


                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_Open_STipContent:

                    break;


                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_Open_STipTitle:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_PageGroup_Background:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_PageGroup_Document:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_PageGroup_Export:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_PageGroup_Navigation:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_PageGroup_PageSetup:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_PageGroup_PageSetup_STipContent:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_PageGroup_PageSetup_STipTitle:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_PageGroup_Print:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_PageGroup_Zoom:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_PageMargins_Caption:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_PageMargins_STipContent:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_PageMargins_STipTitle:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_PageOrientation_Caption:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_PageOrientation_STipContent:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_PageOrientation_STipTitle:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_PageSetup_Caption:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_PageSetup_STipContent:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_PageSetup_STipTitle:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_PageText:

                    break;


                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_PaperSize_Caption:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_PaperSize_STipContent:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_PaperSize_STipTitle:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_Pointer_Caption:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_Pointer_STipContent:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_Pointer_STipTitle:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_Print_Caption:

                    break;


                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_Print_STipContent:

                    break;


                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_Print_STipTitle:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_PrintDirect_Caption:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_PrintDirect_STipContent:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_PrintDirect_STipTitle:

                    break;
                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_Save_Caption:

                    return acInfo.Resource.GetString("저장", "7NKYXFU5"); 

                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_Save_STipContent:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_Save_STipTitle:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_Scale_Caption:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_Scale_STipContent:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_Scale_STipTitle:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_SendCsv_Caption:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_SendCsv_Description:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_SendCsv_STipContent:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_SendCsv_STipTitle:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_SendFile_Caption:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_SendFile_STipContent:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_SendFile_STipTitle:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_SendGraphic_Caption:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_SendGraphic_Description:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_SendGraphic_STipContent:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_SendGraphic_STipTitle:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_SendMht_Caption:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_SendMht_Description:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_SendMht_STipContent:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_SendMht_STipTitle:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_SendPdf_Caption:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_SendPdf_Description:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_SendPdf_STipContent:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_SendPdf_STipTitle:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_SendRtf_Caption:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_SendRtf_Description:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_SendRtf_STipContent:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_SendRtf_STipTitle:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_SendTxt_Caption:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_SendTxt_Description:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_SendTxt_STipContent:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_SendTxt_STipTitle:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_SendXls_Caption:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_SendXls_Description:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_SendXls_STipContent:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_SendXls_STipTitle:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_ShowFirstPage_Caption:

                    break;


                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_ShowFirstPage_STipContent:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_ShowFirstPage_STipTitle:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_ShowLastPage_Caption:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_ShowLastPage_STipContent:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_ShowLastPage_STipTitle:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_ShowNextPage_Caption:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_ShowNextPage_STipContent:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_ShowNextPage_STipTitle:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_ShowPrevPage_Caption:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_ShowPrevPage_STipContent:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_ShowPrevPage_STipTitle:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_Watermark_Caption:

                    break;


                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_Watermark_STipContent:

                    break;


                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_Watermark_STipTitle:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_Zoom_Caption:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_Zoom_STipContent:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_Zoom_STipTitle:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_ZoomExact_Caption:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_ZoomIn_Caption:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_ZoomIn_STipContent:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_ZoomIn_STipTitle:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_ZoomOut_Caption:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_ZoomOut_STipContent:


                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.RibbonPreview_ZoomOut_STipTitle:

                    break;




                case DevExpress.XtraPrinting.Localization.PreviewStringId.SaveDlg_Title:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.SB_CurrentPageNo:

                    return acInfo.Resource.GetString("현재 페이지", "JORBHW0H");

                case DevExpress.XtraPrinting.Localization.PreviewStringId.SB_PageInfo:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.SB_PageNone:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.SB_TotalPageNo:

                    return acInfo.Resource.GetString("총페이지", "QILWDGQQ");

                case DevExpress.XtraPrinting.Localization.PreviewStringId.SB_ZoomFactor:

                    return acInfo.Resource.GetString("배율", "OSXZ8CAS");

                case DevExpress.XtraPrinting.Localization.PreviewStringId.ScalePopup_AdjustTo:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.ScalePopup_FitTo:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.ScalePopup_GroupText:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.ScalePopup_NormalSize:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.ScalePopup_PagesWide:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.ScrollingInfo_Page:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.Shapes_Arrow:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.Shapes_BackslantLine:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.Shapes_BottomArrow:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.Shapes_Brace:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.Shapes_Bracket:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.Shapes_Cross:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.Shapes_EightPointStar:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.Shapes_Ellipse:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.Shapes_FivePointStar:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.Shapes_Hexagon:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.Shapes_HorizontalLine:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.Shapes_LeftArrow:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.Shapes_Line:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.Shapes_Octagon:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.Shapes_Pentagon:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.Shapes_Polygon:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.Shapes_Rectangle:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.Shapes_RightArrow:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.Shapes_SixPointStar:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.Shapes_SlantLine:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.Shapes_Square:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.Shapes_Star:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.Shapes_ThreePointStar:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.Shapes_TopArrow:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.Shapes_Triangle:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.Shapes_VerticalLine:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.TB_TTip_Backgr:

                    return acInfo.Resource.GetString("배경색", "KYF0TDNA");

  
                case DevExpress.XtraPrinting.Localization.PreviewStringId.TB_TTip_Close:

                    return acInfo.Resource.GetString("미리보기 종료", "BALD7IWV");

                case DevExpress.XtraPrinting.Localization.PreviewStringId.TB_TTip_Customize:

                    return acInfo.Resource.GetString("커스터마이징", "0452A5VP");


                case DevExpress.XtraPrinting.Localization.PreviewStringId.TB_TTip_EditPageHF:

                    return acInfo.Resource.GetString("머리,바닥글 설정", "3EX3MI0F");

                case DevExpress.XtraPrinting.Localization.PreviewStringId.TB_TTip_Export:

                    return acInfo.Resource.GetString("문서 내보내기", "6V0UI7ZC");

                case DevExpress.XtraPrinting.Localization.PreviewStringId.TB_TTip_FirstPage:

                    return acInfo.Resource.GetString("첫번째 페이지로 이동", "4ML5KDGG"); 

                case DevExpress.XtraPrinting.Localization.PreviewStringId.TB_TTip_HandTool:

                    return acInfo.Resource.GetString("이동", "4E1488QE");


                case DevExpress.XtraPrinting.Localization.PreviewStringId.TB_TTip_LastPage:

                    return acInfo.Resource.GetString("마지막 페이지로 이동", "6WV6X7DE");

                case DevExpress.XtraPrinting.Localization.PreviewStringId.TB_TTip_Magnifier:

                    return acInfo.Resource.GetString("돋보기", "0ST18J0W");

                case DevExpress.XtraPrinting.Localization.PreviewStringId.TB_TTip_Map:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.TB_TTip_MultiplePages:

                    return acInfo.Resource.GetString("다중 페이지 보기", "BYZSXI71");


                case DevExpress.XtraPrinting.Localization.PreviewStringId.TB_TTip_NextPage:

                    return acInfo.Resource.GetString("다음 페이지로 이동", "DTW1CUR7"); 

                case DevExpress.XtraPrinting.Localization.PreviewStringId.TB_TTip_Open:

                    return acInfo.Resource.GetString("문서 열기", "DROTY2PA");

                case DevExpress.XtraPrinting.Localization.PreviewStringId.TB_TTip_PageSetup:

                    return acInfo.Resource.GetString("페이지 설정", "LIDHDQ1J"); 

                case DevExpress.XtraPrinting.Localization.PreviewStringId.TB_TTip_PreviousPage:

                    return acInfo.Resource.GetString("이전 페이지로 이동", "D3WW5PBS"); 

                case DevExpress.XtraPrinting.Localization.PreviewStringId.TB_TTip_Print:

                    return acInfo.Resource.GetString("인쇄", "4HOA9EHQ"); 

                case DevExpress.XtraPrinting.Localization.PreviewStringId.TB_TTip_PrintDirect:

                    return acInfo.Resource.GetString("빠른 인쇄", "U6B3HGH3");

                case DevExpress.XtraPrinting.Localization.PreviewStringId.TB_TTip_Save:

                    return acInfo.Resource.GetString("문서 저장", "8MYADIGH"); 

                case DevExpress.XtraPrinting.Localization.PreviewStringId.TB_TTip_Scale:

                    return acInfo.Resource.GetString("크기", "JVXU2AZ8");

                case DevExpress.XtraPrinting.Localization.PreviewStringId.TB_TTip_Search:

                    return acInfo.Resource.GetString("찾기", "6S7R2PIT"); 

                case DevExpress.XtraPrinting.Localization.PreviewStringId.TB_TTip_Send:

                    return acInfo.Resource.GetString("E-Mail로 보내기", "FUNFIXB5");

                case DevExpress.XtraPrinting.Localization.PreviewStringId.TB_TTip_Watermark:

                    return acInfo.Resource.GetString("워터마크", "NSBHPBBM");

                case DevExpress.XtraPrinting.Localization.PreviewStringId.TB_TTip_Zoom:

                    return acInfo.Resource.GetString("배율", "OSXZ8CAS");

                case DevExpress.XtraPrinting.Localization.PreviewStringId.TB_TTip_ZoomIn:

                    return acInfo.Resource.GetString("확대", "XBR8598R");
       

                case DevExpress.XtraPrinting.Localization.PreviewStringId.TB_TTip_ZoomOut:

                    return acInfo.Resource.GetString("축소", "V8Z581D3");


                case DevExpress.XtraPrinting.Localization.PreviewStringId.WMForm_Direction_BackwardDiagonal:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.WMForm_Direction_ForwardDiagonal:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.WMForm_Direction_Horizontal:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.WMForm_Direction_Vertical:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.WMForm_HorzAlign_Center:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.WMForm_HorzAlign_Left:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.WMForm_HorzAlign_Right:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.WMForm_ImageClip:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.WMForm_ImageStretch:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.WMForm_ImageZoom:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.WMForm_PageRangeRgrItem_All:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.WMForm_PageRangeRgrItem_Pages:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.WMForm_PictureDlg_Title:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.WMForm_VertAlign_Bottom:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.WMForm_VertAlign_Middle:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.WMForm_VertAlign_Top:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.WMForm_Watermark_Asap:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.WMForm_Watermark_Confidential:


                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.WMForm_Watermark_Copy:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.WMForm_Watermark_DoNotCopy:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.WMForm_Watermark_Draft:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.WMForm_Watermark_Evaluation:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.WMForm_Watermark_Original:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.WMForm_Watermark_Personal:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.WMForm_Watermark_Sample:

                    break;


                case DevExpress.XtraPrinting.Localization.PreviewStringId.WMForm_Watermark_TopSecret:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.WMForm_Watermark_Urgent:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.WMForm_ZOrderRgrItem_Behind:

                    break;

                case DevExpress.XtraPrinting.Localization.PreviewStringId.WMForm_ZOrderRgrItem_InFront:

                    break;


            }



            return base.GetLocalizedString(id);
        }
    }
}
