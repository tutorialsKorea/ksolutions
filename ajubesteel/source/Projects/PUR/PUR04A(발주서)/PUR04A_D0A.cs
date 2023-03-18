using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ControlManager;
using CodeHelperManager;
using BizManager;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;
using System.IO;

using DevExpress.Spreadsheet; 
using DevExpress.XtraSpreadsheet;
using System.Linq;
using System.Text.RegularExpressions;
using System.Drawing.Text;
using ZXing.Common;
using ZXing;
using ZXing.QrCode;
using DevExpress.XtraPrinting;

namespace PUR
{
    public sealed partial class PUR04A_D0A : BaseMenuDialog
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

        private string _balju_num;
        private string _strSubject;

        private DataRow _drMaster;
        private DataTable _dtDetail;
        private DataRow _drMyVendor;

        private bool _isPrice = true;

        public PUR04A_D0A(DataRow drMaster, DataTable dtDetail, bool isPrice)
        {
            InitializeComponent();

            _drMaster = drMaster;
            _dtDetail = dtDetail.Copy();

            _balju_num = drMaster["BALJU_NUM"].ToString();
            
            _strSubject = "발주서";

            pdfViewer1.PrintPage += PdfViewer1_PrintPage;

            _isPrice = isPrice;
        }

        

        public override void DialogInit()
        {
            //입고일
            acLayoutControl1.GetEditor("FROM").Value = acInfo.EmailAddr;
            acLayoutControl1.GetEditor("MAIL_SUBJECT").Value = "[디플러스]발주서";
            acLayoutControl1.GetEditor("MAIL_TO").Value = _drMaster["VEN_EMAIL"];

            acLayoutControl1.GetEditor("MAIL_CC").Value = _drMaster["VEN_EMAIL_CC"];

            acAttachFileControl1.LinkKey = _balju_num;
            acAttachFileControl1.ShowKey = new object[] { _balju_num };
            acAttachFileControl1.IsMailFile = false;
            //acAttachFileControl1.FileName = _strSubject + "_첨부";

            acAttachFileControl1.acTabControl1.TabPages[2].PageVisible = false;


            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE");

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramTable.Rows.Add(paramRow);

            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            DataSet resultSet = BizRun.QBizRun.ExecuteService(this, "CTRL", "GET_MYVENDOR", paramSet, "RQSTDT", "RSLTDT");

            if(resultSet.Tables.Count > 0) 
            {
                _drMyVendor = resultSet.Tables["RSLTDT"].Rows[0];
            }

            base.DialogInit();
        }

        public override void DialogOpen()
        {

            WriteXlsx();

            pdfFileStream = new FileStream(_balju_num + ".pdf", FileMode.Create);
            //{ 
            //wb.Worksheets[0].DefinedNames.Add("_xlnm.Print_Area", "Sheet1!A1:E3");
            //workBook.Worksheets[0].PrintOptions.FitToPage = true;
            //workBook.Worksheets[0].HorizontalPageBreaks.Add(108);
            //workBook.Worksheets[0].PrintOptions.AutoPageBreaks = false;

            //workBook.Worksheets[0].PrintOptions.FitToWidth = 1;
            //workBook.Worksheets[0].PrintOptions.FitToHeight = 1;
            workBook.Worksheets[0].ActiveView.Orientation = PageOrientation.Portrait;
            workBook.ExportToPdf(pdfFileStream);
            //System.Threading.Thread.Sleep(1000);

            pdfViewer1.LoadDocument(pdfFileStream);
            //}


            base.DialogOpen();
        }

        protected override void OnLoad(EventArgs e)
        {

            
            base.OnLoad(e);

        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            pdfFileStream.Dispose();

            pdfViewer1.CloseDocument();

            //System.IO.File.Delete(pdfViewer1.DocumentFilePath);
        }

        FileStream pdfFileStream;

        public override void DialogInitComplete()
        {
            base.DialogInitComplete();

            //pdfFileStream = new FileStream(_balju_num + ".pdf", FileMode.Create);
            ////{ 
            //    //wb.Worksheets[0].DefinedNames.Add("_xlnm.Print_Area", "Sheet1!A1:E3");
            //    workBook.Worksheets[0].PrintOptions.FitToPage = true;
            //    workBook.Worksheets[0].PrintOptions.FitToWidth = 1;
            //    workBook.Worksheets[0].PrintOptions.FitToHeight = 1;
            //    workBook.Worksheets[0].ActiveView.Orientation = PageOrientation.Portrait;
            //    workBook.ExportToPdf(pdfFileStream);

            //    pdfViewer1.LoadDocument(pdfFileStream);
            ////}

            //pdfViewer1.LoadDocument(_balju_num + ".pdf");
        }


        private ControlManager.QThread _writeThread = null;

        SpreadsheetControl spread = null;
        IWorkbook workBook = null;
        private void WriteXlsx()
        {
            try
            {

                if(_drMaster["USE_GLOBAL"].ToString() != "1" || _drMaster["USE_GLOBAL"].isNullOrEmpty())
                {
                    // 국내용 발주서 출력

                    //byte[] balju = Resource.pur_balju;
                    byte[] balju = Resource.PUR_BALJU_BARCODE8;
                    spread = new SpreadsheetControl();
                    spread.LoadDocument(balju, DocumentFormat.Xlsx);

                    workBook = spread.Document;
                    Worksheet worksheet = workBook.Worksheets[0];


                    EncodingOptions opt = new EncodingOptions
                    {
                        Width = 250,
                        Height = 100,
                        PureBarcode = true,
                        Margin = 0,
                    };
                    var barBaljuNum = new BarcodeWriter();
                    barBaljuNum.Format = BarcodeFormat.CODE_128;
                    barBaljuNum.Options = opt;

                    //var result = new barBaljuNum.Write(_drMaster["BALJU_NUM"].ToString());

                    worksheet.Pictures.AddPicture(barBaljuNum.Write(_drMaster["BALJU_NUM"].ToString()), worksheet["AJ3:AZ8"]);

                    //worksheet["AJ3"].Value = "*" + _drMaster["BALJU_NUM"].ToString() + "*";
                    //발주번호
                    worksheet["B10"].Value = " 발주번호 : " + _drMaster["BALJU_NUM"].ToString();
                    //업체명
                    worksheet["B12"].Value = " 업 체 명  : " + _drMaster["VEN_NAME"].ToString();
                    //대표자
                    worksheet["B14"].Value = " 대 표 자  : " + _drMaster["VEN_CEO"].ToString();
                    //참조
                    worksheet["B16"].Value = " 참     조  : " + _drMaster["VEN_CHARGE_EMP"].ToString();
                    //연락처
                    worksheet["B18"].Value = " 연 락 처  : " + _drMaster["VEN_CHARGE_HP"].ToString();
                    //발주일
                    worksheet["B21"].Value = " 발 주 일  : " + _drMaster["BALJU_DATE"].toDateString("yyyy-MM-dd");

                    //결재
                    //작성
                    worksheet["BC5"].Value = _drMaster["CHARGE_EMP"].ToString();

                    if (_drMaster["APP_STATUS"].ToString() == "2")
                    {
                        worksheet.Pictures.AddPicture(Resource.sign3, worksheet["BR5:BV8"]);
                    }


                    //디플러스
                    //담당자
                    worksheet["AF16"].Value = " 담 당 자  : " + _drMaster["CHARGE_EMP"].ToString();
                    //연락처
                    worksheet["AW16"].Value = " 연락처 : " + _drMaster["CHARGE_PHONE"].ToString();
                    //이메일
                    worksheet["AF18"].Value = " 이 메 일  : " + _drMaster["CHARGE_EMAIL"].ToString();

                    //납기일
                    worksheet["AF21"].Value = " 납 기 일  : " + _dtDetail.Rows[0]["DUE_DATE"].toDateString("yyyy-MM-dd");

                    foreach (Shape shape in worksheet.Shapes)
                    {
                        //분할납품
                        if (shape.Name == "직사각형 13")
                        {
                            if (_drMaster["SPLIT"].ToString() == "1") shape.Fill.SetSolidFill(Color.Black);
                        }
                        //부가세 포함    
                        if (shape.Name == "직사각형 14" && _drMaster["INCL_VAT"].ToString() == "1")
                        {
                            shape.Fill.SetSolidFill(Color.Black);
                        }
                        //부가세 별도
                        if (shape.Name == "직사각형 15" && _drMaster["INCL_VAT"].ToString() == "0")
                        {
                            shape.Fill.SetSolidFill(Color.Black);
                        }
                        //치수검사
                        if (shape.Name == "직사각형 4" && _drMaster["CHK_MEASURE"].ToString() == "1")
                        {
                            shape.Fill.SetSolidFill(Color.Black);
                        }
                        //성능검사
                        if (shape.Name == "직사각형 5" && _drMaster["CHK_PERFORM"].ToString() == "1")
                        {
                            shape.Fill.SetSolidFill(Color.Black);
                        }
                        //입회검사
                        if (shape.Name == "직사각형 6" && _drMaster["CHK_ATTEND"].ToString() == "1")
                        {
                            shape.Fill.SetSolidFill(Color.Black);
                        }
                        //검사성적서
                        if (shape.Name == "직사각형 7" && _drMaster["CHK_TEST"].ToString() == "1")
                        {
                            shape.Fill.SetSolidFill(Color.Black);
                        }
                        //meel sheet
                        if (shape.Name == "직사각형 8" && _drMaster["CHK_MEEL"].ToString() == "1")
                        {
                            shape.Fill.SetSolidFill(Color.Black);
                        }
                        //check1
                        if (shape.Name == "직사각형 11" && _drMaster["CHK_ADD1"].ToString() != "")
                        {
                            shape.Fill.SetSolidFill(Color.Black);

                        }
                        //check2
                        if (shape.Name == "직사각형 12" && _drMaster["CHK_ADD2"].ToString() != "")
                        {
                            shape.Fill.SetSolidFill(Color.Black);
                        }
                        //check3
                        if (shape.Name == "직사각형 9" && _drMaster["CHK_ADD3"].ToString() != "")
                        {
                            shape.Fill.SetSolidFill(Color.Black);
                        }

                        //연구개발비
                        if (shape.Name == "직사각형 17" && _drMaster["CHK_RD"].ToString() == "1")
                        {
                            shape.Fill.SetSolidFill(Color.Black);
                        }

                    }

                    int rowIdx = 29;
                    int rownum = 1;

                    decimal sum_amt = 0;
                    int sum_qty = 0;


                    foreach (DataRow row in _dtDetail.Rows)
                    {

                        //this._writeThread.SetCount(rownum);
                        
                        if (rownum > 20)
                        {
                            //새로운 행을 삽입한다.(4줄 삽입 후, 양식 copy)
                            worksheet.Rows.Insert(rowIdx - 1, 1, RowFormatMode.FormatAsPrevious);
                            worksheet.Rows.Insert(rowIdx - 1, 1, RowFormatMode.FormatAsPrevious);
                            worksheet.Rows[rowIdx - 1].RowHeight = worksheet.Rows[29].Height;
                            worksheet.Rows.Insert(rowIdx - 1, 1, RowFormatMode.FormatAsPrevious);
                            worksheet.Rows[rowIdx - 1].RowHeight = worksheet.Rows[30].Height;
                            worksheet.Rows.Insert(rowIdx - 1, 1, RowFormatMode.FormatAsPrevious);

                            CellRange sourceRange = worksheet.Range["B29:BV32"]; // 4개 Row가 모여 하나의 Row를 구성하고 있음.
                            worksheet.Range["B" + (rowIdx).ToString() + ":" + "BV" + (rowIdx + 3).ToString()].CopyFrom(sourceRange, PasteSpecial.Formats);
                            //(4개의 Row 각각의 높이는 바코드가 들어갈 위치 때문에 다르다)
                            //worksheet.Rows[rowIdx].Height = worksheet.Rows[28].Height;
                            //worksheet.Rows[rowIdx + 1].Height = worksheet.Rows[29].Height; // 바코드가 표시되는 범위 시작 
                            //worksheet.Rows[rowIdx + 2].Height = worksheet.Rows[30].Height; // 바코드가 표시되는 범위 종료 
                            //worksheet.Rows[rowIdx + 3].Height = worksheet.Rows[31].Height;

                        }
                        worksheet["B" + rowIdx.ToString()].Value = rownum;
                        //품명
                        //자재일경우 PART_NAME
                        //일반구매품일 경우 DETAIL_PART_NAME

                        //외주발주는 MAT_TYPE이 없음
                        //작업지시 번호(WO_NO)가 있으면 외주발주

                        bool is_os = false;

                        if (_dtDetail.Columns.Contains("WO_NO"))
                        {
                            is_os = true;
                        }

                        if (is_os)
                        {
                            worksheet["E" + rowIdx.ToString()].Value = row["PART_NAME"].ToString();
                        }
                        else
                        {
                            switch (row["MAT_TYPE"].ToString())
                            {
                                case "PUR":
                                    worksheet["E" + rowIdx.ToString()].Value = row["PART_NAME"].ToString();
                                    break;

                                case "SUP":
                                    worksheet["E" + rowIdx.ToString()].Value = row["DETAIL_PART_NAME"].ToString();
                                    break;

                                default:
                                    worksheet["E" + rowIdx.ToString()].Value = row["PART_NAME"].ToString();
                                    break;
                            }
                        }

                        //규격
                        worksheet["W" + rowIdx.ToString()].Value = row["MAT_SPEC"].ToString();
                        //수량
                        worksheet["AN" + rowIdx.ToString()].Value = row["QTY"].toInt();
                        worksheet["AN" + rowIdx.ToString()].NumberFormat = "#,##0";
                        worksheet["AN" + rowIdx.ToString()].Alignment.Horizontal = SpreadsheetHorizontalAlignment.Right;

                        if (_isPrice)
                        {
                            //단가
                            worksheet["AS" + rowIdx.ToString()].Value = row["UNIT_COST"].toInt();
                            worksheet["AS" + rowIdx.ToString()].NumberFormat = "#,##0";
                            worksheet["AS" + rowIdx.ToString()].Alignment.Horizontal = SpreadsheetHorizontalAlignment.Right;
                            //공급가
                            worksheet["AZ" + rowIdx.ToString()].Value = row["AMT"].toInt();
                            worksheet["AZ" + rowIdx.ToString()].NumberFormat = "#,##0";
                            worksheet["AZ" + rowIdx.ToString()].Alignment.Horizontal = SpreadsheetHorizontalAlignment.Right;
                        }
                        
                        //품번
                        worksheet["BH" + rowIdx.ToString()].Value = row["PART_CODE"].ToString();
                        //수주번호
                        if (_dtDetail.Columns.Contains("PROD_CODE"))
                        {
                            worksheet["BP" + rowIdx.ToString()].Value = row["PROD_CODE"].ToString();
                        }

                        ////규격
                        //worksheet["X" + rowIdx.ToString()].Value = row["MAT_SPEC"].ToString();
                        ////단위
                        //worksheet["AJ" + rowIdx.ToString()].Value = acInfo.StdCodes.GetNameByCode("M003", row["MAT_UNIT"].ToString());
                        ////수량
                        //worksheet["AM" + rowIdx.ToString()].Value = row["QTY"].toInt();
                        //worksheet["AM" + rowIdx.ToString()].NumberFormat = "#,##0";
                        //worksheet["AM" + rowIdx.ToString()].Alignment.Horizontal = SpreadsheetHorizontalAlignment.Right;
                        ////단가
                        //worksheet["AR" + rowIdx.ToString()].Value = row["UNIT_COST"].toInt();
                        //worksheet["AR" + rowIdx.ToString()].NumberFormat = "#,##0";
                        //worksheet["AR" + rowIdx.ToString()].Alignment.Horizontal = SpreadsheetHorizontalAlignment.Right;
                        ////공급가액
                        //worksheet["AZ" + rowIdx.ToString()].Value = row["AMT"].toInt();
                        //worksheet["AZ" + rowIdx.ToString()].NumberFormat = "#,##0";
                        //worksheet["AZ" + rowIdx.ToString()].Alignment.Horizontal = SpreadsheetHorizontalAlignment.Right;

                        //바코드
                        //EncodingOptions optSeq = new EncodingOptions
                        //{
                        //    Width = 40,
                        //    Height = 10,
                        //    PureBarcode = true

                        //};

                        //var barBaljuSeq = new BarcodeWriter();
                        //barBaljuSeq.Format = BarcodeFormat.CODE_128;
                        //barBaljuSeq.Options = optSeq;

                        ////string barcodeCell = "BI" + rowIdx.ToString() + ":BV" + (rowIdx + 1).ToString();
                        ////string barcodeCell = "BJ" + rowIdx.ToString() + ":BU" + (rowIdx + 1).ToString();
                        //string barcodeCell = "BJ" + (rowIdx + 1).ToString() + ":BU" + (rowIdx + 2).ToString();
                        //Bitmap img = barBaljuSeq.Write(row["BALJU_NUM"].ToString() + "-" + row["BALJU_SEQ"].ToString()) as Bitmap;

                        //worksheet.Pictures.AddPicture(img, worksheet[barcodeCell]);

                        //worksheet["BI" + rowIdx.ToString()].Value = row["BALJU_NUM"].ToString() + "-" + row["BALJU_SEQ"].ToString();

                        sum_qty += row["QTY"].toInt();
                        sum_amt += row["AMT"].toDecimal();

                        rownum++;
                        //rowIdx = rowIdx + 2;
                        rowIdx = rowIdx + 4;
                    }

                    //worksheet.Rows.Remove(rowIdx);

                    //if (rownum <= 20) rowIdx = 69;
                    if (rownum <= 20) rowIdx = 109;

                    if (_isPrice)
                    {
                        //합계
                        worksheet["AN" + rowIdx.ToString()].Value = string.Format("{0:#,###}", sum_qty);
                        worksheet["AZ" + rowIdx.ToString()].Value = string.Format("{0:#,###}", sum_amt);
                    }

                    //납품장소
                    worksheet["B" + (rowIdx + 7).ToString()].Value = " 납품장소 : " + _drMaster["DELIVERY_LOCATION"].ToString();
                    //결제조건
                    worksheet["T" + (rowIdx + 7).ToString()].Value = " 결제조건 : " + _drMaster["PAY_CONDITION"].ToString();
                    //입고담당
                    worksheet["AR" + (rowIdx + 7).ToString()].Value = " 입고담당 : " + _drMaster["YPGO_CHARGE"].ToString();
                    //검수방법
                    worksheet["K" + (rowIdx + 12).ToString()].Value = "  (" + _drMaster["CHK_ADD1"].ToString() + ")";
                    worksheet["T" + (rowIdx + 12).ToString()].Value = "  (" + _drMaster["CHK_ADD2"].ToString() + ")";
                    worksheet["AI" + (rowIdx + 12).ToString()].Value = "  (" + _drMaster["CHK_ADD3"].ToString() + ")";

                    //특기사항
                    worksheet["B" + (rowIdx + 16).ToString()].Value = _drMaster["SCOMMENT"].ToString();

                    //합계금액(VAT포함)
                    if (_drMaster["INCL_VAT"].ToString() == "0")
                    {
                        sum_amt = sum_amt + (sum_amt.toDouble() * 0.1).toDecimal();
                    }

                    if (_isPrice)
                    {
                        worksheet["AF24"].Value = " 합계금액(VAT포함) : " + string.Format("{0:#,###}", sum_amt);
                    }

                    int pageBreak = 148;

                    int totalCnt = _dtDetail.Rows.Count;

                    int cnt = 0;

                    int subCnt = 0;

                    //발주수량이 26 ~ 30개일경우 pagebreak
                    if (totalCnt > 25 && totalCnt < 30)
                    {
                        worksheet.HorizontalPageBreaks.Add(128);
                    }

                    foreach (DataRow row in _dtDetail.Rows)
                    {
                        //31번이 있으면 pagebreak
                        if (cnt == 30)
                        {
                            worksheet.HorizontalPageBreaks.Add(pageBreak);
                        }

                        if (subCnt == 40)
                        {
                            worksheet.HorizontalPageBreaks.Add(pageBreak);
                            subCnt = 0;
                        }
                        

                        if (cnt > 30)
                        {
                            pageBreak = pageBreak + 4;

                            subCnt++;
                        }

                        cnt++;
                    }

                    if (subCnt > 30)
                    {
                        worksheet.HorizontalPageBreaks.Add(pageBreak + 4);
                    }


                    ////합계
                    //worksheet["AM" + rowIdx.ToString()].Value = string.Format("{0:#,###}", sum_qty);
                    //worksheet["AZ" + rowIdx.ToString()].Value = string.Format("{0:#,###}", sum_amt);


                    ////납품장소
                    //worksheet["B" + (rowIdx + 7).ToString()].Value = " 납품장소 : " + _drMaster["DELIVERY_LOCATION"].ToString();
                    ////결제조건
                    //worksheet["T" + (rowIdx + 7).ToString()].Value = " 결제조건 : " + _drMaster["PAY_CONDITION"].ToString();
                    ////입고담당
                    //worksheet["AR" + (rowIdx + 7).ToString()].Value = " 입고담당 : " + _drMaster["YPGO_CHARGE"].ToString();
                    ////검수방법
                    //worksheet["K" + (rowIdx + 12).ToString()].Value = "  (" + _drMaster["CHK_ADD1"].ToString() + ")";
                    //worksheet["T" + (rowIdx + 12).ToString()].Value = "  (" + _drMaster["CHK_ADD2"].ToString() + ")";
                    //worksheet["AI" + (rowIdx + 12).ToString()].Value = "  (" + _drMaster["CHK_ADD3"].ToString() + ")";

                    //////특기사항
                    //worksheet["B" + (rowIdx + 16).ToString()].Value = _drMaster["SCOMMENT"].ToString();

                    ////합계금액(VAT포함)
                    //if (_drMaster["INCL_VAT"].ToString() == "0")
                    //{
                    //    sum_amt = sum_amt + (sum_amt.toDouble() * 0.1).toDecimal();
                    //}

                    //worksheet["AF24"].Value = " 합계금액(VAT포함) : " + string.Format("{0:#,###}", sum_amt);
                }
                else
                {

                    // 해외용 발주서 출력

                    byte[] balju = Resource.GLOBAL_BALJU8;
                    spread = new SpreadsheetControl();
                    spread.LoadDocument(balju, DocumentFormat.Xlsx);

                    workBook = spread.Document;
                    Worksheet worksheet = workBook.Worksheets[0];

                    // 기본회사 정보
                    worksheet["B2"].Value = _drMyVendor["ENG_VEN_ADDR"].ToString() + ", " + _drMyVendor["ENG_VEN_ADDR2"].ToString() + "   |   " + "Tel: " + _drMyVendor["VEN_TEL"].ToString() + " Fax: " + _drMyVendor["VEN_FAX"].ToString();

                    string PO_NO = _drMaster["BALJU_NUM"].ToString();
                    if (_drMaster["PO_NO"].ToString() != "")
                    {
                        PO_NO = _drMaster["PO_NO"].ToString();
                    }
                    //발주번호
                    worksheet["C5"].Value = PO_NO;
                    
                    //구매 업체명
                    worksheet["B7"].Value = "  Supplier Name : " + _drMaster["ENG_VEN_NAME"].ToString();
                    
                    //영문주소
                    worksheet["C8"].Value = _drMaster["ENG_VEN_ADDR"].ToString();

                    //영문주소2
                    worksheet["C9"].Value = _drMaster["ENG_VEN_ADDR2"].ToString();

                    //전화 및 FAX
                    worksheet["C10"].Value = "TEL : " + _drMaster["VEN_TEL"].ToString() + "     FAX : " + _drMaster["VEN_FAX"].ToString();

                    // 디플러스 영문 업체명
                    worksheet["F7"].Value = "Delievery To : " + _drMyVendor["ENG_VEN_NAME"].ToString();
                    
                    // 디플러스 영문 주소
                    worksheet["H8"].Value = _drMyVendor["ENG_VEN_ADDR"].ToString();

                    // 디플러스 영문 주소2
                    worksheet["H9"].Value = _drMyVendor["ENG_VEN_ADDR2"].ToString();

                    //디플러스 전화 및 FAX
                    worksheet["H10"].Value = "TEL : " + _drMyVendor["VEN_TEL"].ToString() + "    FAX : " + _drMyVendor["VEN_FAX"].ToString();

                    //발주일
                    worksheet["H5"].Value = _drMaster["BALJU_DATE"].toDateString("yyyy-MM-dd");

                    //Delivery
                    worksheet["C49"].Value = _drMaster["DELIVERY"].toDateString("yyyy-MM-dd");

                    //Ship date
                    worksheet["C50"].Value = _drMaster["SHIP_DATE"].toDateString("yyyy-MM-dd");

                    //Shipment
                    worksheet["C51"].Value = _drMaster["SHIPMENT"].toDateString("yyyy-MM-dd");

                    int rowIdx = 14;
                    int rownum = 1;

                    decimal sum_amt = 0;
                 
                    foreach (DataRow row in _dtDetail.Rows)
                    {
                        if (rownum > 29)
                        {
                            worksheet.Rows.Insert(rowIdx-1, 1);
                            worksheet.Range["B" + (rowIdx-1).ToString() + ":" + "I" + (rowIdx-1).ToString()].CopyFrom(worksheet.Range["B15:I15"], PasteSpecial.Formats);
                            worksheet.Rows[rowIdx].Height = worksheet.Rows[29].Height;
                            worksheet.Rows[rowIdx].Height = worksheet.Rows[29].Height;
                        }

                        //// Product Category
                        worksheet["B" + rowIdx.ToString()].Value = acInfo.StdCodes.GetNameByCode("P030", row["PART_CAT"].ToString());


                        if (_dtDetail.Columns.Contains("PROD_CODE"))
                        {
                            ////수주번호
                            worksheet["C" + rowIdx.ToString()].Value = row["PROD_CODE"].ToString();
                        }

                        //품목코드
                        worksheet["D" + rowIdx.ToString()].Value = row["PART_CODE"].ToString();

                        ////품명
                        //worksheet["E" + rowIdx.ToString()].Value = row["PART_NAME"].ToString();

                        switch (row["MAT_TYPE"].ToString())
                        {
                            case "PUR":
                                worksheet["E" + rowIdx.ToString()].Value = row["PART_NAME"].ToString();
                                break;

                            case "SUP":
                                worksheet["E" + rowIdx.ToString()].Value = row["DETAIL_PART_NAME"].ToString();
                                break;

                            default:
                                worksheet["E" + rowIdx.ToString()].Value = row["PART_NAME"].ToString();
                                break;
                        }


                        ////수량
                        worksheet["F" + rowIdx.ToString()].Value = row["QTY"].toInt();
                        worksheet["F" + rowIdx.ToString()].NumberFormat = "#,##0";
                        worksheet["F" + rowIdx.ToString()].Alignment.Horizontal = SpreadsheetHorizontalAlignment.Right;

                        ////단위
                        worksheet["G" + rowIdx.ToString()].Value = acInfo.StdCodes.GetNameByCode("M003", row["MAT_UNIT"].ToString());

                        if (_isPrice)
                        {
                            ////단가
                            worksheet["H" + rowIdx.ToString()].Value = row["UNIT_COST"].toInt();
                            worksheet["H" + rowIdx.ToString()].Alignment.Horizontal = SpreadsheetHorizontalAlignment.Right;

                            ////공급가액
                            worksheet["I" + rowIdx.ToString()].Value = row["AMT"].toInt();
                            worksheet["I" + rowIdx.ToString()].Alignment.Horizontal = SpreadsheetHorizontalAlignment.Right;
                        }
                       
                        sum_amt += row["AMT"].toDecimal();

                        rownum++;
     
                        rowIdx++;
                    }

                    if (rownum <= 20) rowIdx = 43;

                    // 마지막 행 서식 추가
                    worksheet.Range["B" + (rowIdx - 1).ToString() + ":" + "I" + (rowIdx - 1).ToString()].CopyFrom(worksheet.Range["B15:I15"], PasteSpecial.Formats);

                    if (_isPrice)
                    {
                        //합계
                        worksheet["I" + (rowIdx + 1).ToString()].Value = sum_amt;
                    }

                    worksheet["I" + (rowIdx + 1).ToString()].Alignment.Horizontal = SpreadsheetHorizontalAlignment.Right;


                    int pageBreak2 = 77;

                    int totalCnt2 = _dtDetail.Rows.Count;

                    int cnt2 = 0;

                    int subCnt2 = 0;

                    //발주수량이 40 ~ 50개일경우 pagebreak
                    if (totalCnt2 > 50 && totalCnt2 < 56)
                    {
                        worksheet.HorizontalPageBreaks.Add(67);
                    }

                    foreach (DataRow row in _dtDetail.Rows)
                    {
                        if (subCnt2 == 75)
                        {
                            worksheet.HorizontalPageBreaks.Add(pageBreak2);
                            subCnt2 = 0;
                        }


                        if (cnt2 > 64)
                        {
                            pageBreak2++;

                            subCnt2++;
                        }

                        cnt2++;
                    }

                    if (subCnt2 > 56)
                    {
                        worksheet.HorizontalPageBreaks.Add(pageBreak2);
                    }

                }


            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
               
            }

        }

        private void acBarButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!acLayoutControl1.ValidCheck()) return;

                DataRow layoutRow = acLayoutControl1.CreateParameterRow();

                try
                {
                    //메일형식
                    string pattern = @"([\w\.-]+)@([\w\.-]+)(\.[\w\.]+)";
                    Regex re = new Regex(pattern);

                    //보내는사람 메일형식 확인
                    MatchCollection matchesFrom = re.Matches(layoutRow["FROM"].ToString());

                    string[] addrFromList = new string[matchesFrom.Count];

                    int i = 0;

                    foreach (Match match in matchesFrom)
                    {
                        if (!addrFromList.Contains(match.Value))
                        {
                            addrFromList[i] = match.Value;
                            i++;
                        }
                    }

                    if (addrFromList.Length == 0)
                    {
                        acMessageBox.Show("보내는 사람이 없습니다.", "확인", acMessageBox.emMessageBoxType.CONFIRM);
                        return;
                    }

                    if (addrFromList.Length > 1)
                    {
                        acMessageBox.Show("보내는 사람이 여러명입니다.", "확인", acMessageBox.emMessageBoxType.CONFIRM);
                        return;
                    }

                    acMailImplicitSSL mail = new acMailImplicitSSL(layoutRow["FROM"].ToString(), acInfo.UserName);

                    //받는사람 메일형식 확인
                    MatchCollection matchesTo = re.Matches(layoutRow["MAIL_TO"].ToString());

                    string[] addrToList = new string[matchesTo.Count];

                    i = 0;

                    foreach (Match match in matchesTo)
                    {
                        if (!addrToList.Contains(match.Value))
                        {
                            addrToList[i] = match.Value;
                            i++;
                        }
                    }

                    if (addrToList.Length == 0)
                    {
                        acMessageBox.Show("받는 사람이 없습니다.", "확인", acMessageBox.emMessageBoxType.CONFIRM);
                        return;
                    }

                    mail.SetToAddressList(addrToList);

                    //참조 메일형식 확인
                    MatchCollection matchesCC = re.Matches(layoutRow["MAIL_CC"].ToString());

                    string[] addrCCList = new string[matchesCC.Count];

                    i = 0;

                    foreach (Match match in matchesCC)
                    {
                        if (!addrCCList.Contains(match.Value))
                        {
                            addrCCList[i] = match.Value;
                            i++;
                        }
                    }

                    mail.SetCcAddressList(addrCCList);

                    //내용&첨부파일
                    mail.SetBodyAttatchFileList(pdfFileStream, "ATT", "PUR04A_D0A", _balju_num, layoutRow["MAIL_BODY"].ToString());

                    mail.LINK_NO = this._balju_num;

                    // send mail
                    if (mail.SendEmail(this, layoutRow["MAIL_SUBJECT"].ToString()))
                    {
                        acMessageBox.Show("E-Mail 전송에 성공하였습니다.", "확인", acMessageBox.emMessageBoxType.CONFIRM);
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {

                        acMessageBox.Show("E-Mail 전송에 실패하였습니다! (관리자에게 문의하십시오)", "오류", acMessageBox.emMessageBoxType.CONFIRM);
                    }

                }
                catch (Exception ex)
                {
                    acMessageBox.Show(this, ex);
                }


                //if (!acLayoutControl1.ValidCheck()) return;

                //DataRow layoutRow = acLayoutControl1.CreateParameterRow();

                //acMail mail = new acMail(acInfo.EmailAddr, acInfo.UserName);

                //string pattern = @"([\w\.-]+)@([\w\.-]+)(\.[\w\.]+)";
                //Regex re = new Regex(pattern);

                //MatchCollection matchesTo = re.Matches(layoutRow["MAIL_TO"].ToString());

                //string[] addrToList = new string[matchesTo.Count];

                //int i = 0;

                //foreach (Match match in matchesTo)
                //{
                //    if (!addrToList.Contains(match.Value))
                //    {
                //        addrToList[i] = match.Value;
                //        i++;
                //    }

                //}

                //MatchCollection matchesCC = re.Matches(layoutRow["MAIL_CC"].ToString());

                //string[] addrCCList = new string[matchesCC.Count];

                //i = 0;

                //foreach (Match match in matchesCC)
                //{
                //    if (!addrCCList.Contains(match.Value))
                //    {
                //        addrCCList[i] = match.Value;
                //        i++;
                //    }
                //}

                //if (addrToList.Length == 0)
                //{
                //    acMessageBox.Show("받는 사람이 없습니다.", "확인", acMessageBox.emMessageBoxType.CONFIRM);
                //    return;
                //}

                //mail.SetToAddressList(addrToList);

                //mail.SetCcAddressList(addrCCList);

                //string fileName = "발주서.pdf";
                //workBook.ExportToPdf(fileName);

                //mail.SetAttatchFileList(new string[] { fileName }, "ATT", "PUR04A_D0A", _balju_num);

                ////mail.SetAttatchFileList(pdfFileStream, "ATT", "PUR04A_D0A", _balju_num);

                //mail.LINK_NO = this._balju_num;

                //string subject = layoutRow["MAIL_SUBJECT"].ToString();

                //string body = layoutRow["MAIL_BODY"].ToString();

                //if (mail.SendEmail(this, subject, body))
                //{
                //    acMessageBox.Show("E-Mail 전송에 성공하였습니다.", "확인", acMessageBox.emMessageBoxType.CONFIRM);

                //    this.DialogResult = DialogResult.OK;
                //    //this.Close();
                //}
                //else
                //{
                //    acMessageBox.Show("E-Mail 전송에 실패하였습니다! (관리자에게 문의하십시오)", "오류", acMessageBox.emMessageBoxType.CONFIRM);
                //}

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
            finally
            {
                System.IO.File.Delete(Path.GetTempPath() + "발주서.pdf");
            }
        }


        void QuickException(object sender, QBiz qBiz, BizManager.BizException ex)
        {
            acMessageBox.Show(this, ex);
        }


        private void acBarButtonItem3_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();

                saveFileDialog1.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                saveFileDialog1.Title = "저장할 위치를 입력하여 주십시오.";
                saveFileDialog1.FileName = "발주서 [" + _balju_num + "]";
                saveFileDialog1.Filter = "Excel Files|*.xlsx; | All Files|*.*";
                saveFileDialog1.FilterIndex = 1;
                saveFileDialog1.RestoreDirectory = true;

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {

                    using (FileStream stream = new FileStream(saveFileDialog1.FileName,
                    FileMode.OpenOrCreate, FileAccess.ReadWrite))
                    {
                        //IWorkbook workBook = spreadsheetControl1.Document;
                        workBook.SaveDocument(stream, DocumentFormat.OpenXml);

                    }

                    System.Diagnostics.Process.Start(saveFileDialog1.FileName);
                }

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void PdfViewer1_PrintPage(object sender, DevExpress.Pdf.PdfPrintPageEventArgs e)
        {
            try
            {
                DataTable dtParam = new DataTable("RQSTDT");
                dtParam.Columns.Add("TYPE", typeof(string));
                dtParam.Columns.Add("LINK_NO", typeof(string));

                DataRow dr = dtParam.NewRow();
                dr["TYPE"] = "PUR";
                dr["LINK_NO"] = this._balju_num;
                dtParam.Rows.Add(dr);

                DataSet dsParam = new DataSet();
                dsParam.Tables.Add(dtParam);

                BizRun.QBizRun.ExecuteService(sender, "CTRL", "SET_PRINT_LOG", dsParam, "RQSTDT", "RSLTDT");

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

    }
}

