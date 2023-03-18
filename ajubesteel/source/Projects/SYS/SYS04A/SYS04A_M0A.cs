using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using ControlManager;
using CodeHelperManager;

using BizManager;

namespace SYS
{
    public sealed partial class SYS04A_M0A : BaseMenu
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

        public SYS04A_M0A()
        {
            InitializeComponent();

         
        }





        public override string InstantLog
        {
            set
            {
                statusBarLog.Caption = value;
            }
        }





        public override void MenuInit()
        {
            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //사업장코드

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            DataTable data = BizRun.QBizRun.ExecuteService(this, "CTRL", "CONTROL_USRGRP_SEARCH", paramSet, "RQSTDT", "RSLTDT").Tables[1];

            acVerticalGrid1.ClearRows();

            acVerticalGrid1.AddTextEdit("DEFAULT_FONT", "기본글꼴", "K9AWM1CM", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);

            acVerticalGrid1.AddTextEdit("DEFAULT_FONT_SIZE", "기본 글꼴 크기", "W22IG3C7", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NUMERIC);

            acVerticalGrid1.AddTextEdit("DEFAULT_FONT_SETUP_URL", "기본글꼴 설치URL", "JYTW4IQF", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);

            acVerticalGrid1.AddTextEdit("QUICK_SUPPORT_URL", "원격지원 설치URL", "UDKZJBWG", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);

            //acVerticalGrid1.AddTextEdit("HELP_URL", "도움말 URL", "IOU06N7Y", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);

            acVerticalGrid1.AddLookUpEdit("SYSTEM_GROUP", "시스템사용자 그룹", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, "USRGRP_NAME", "USRGRP_CODE", data);


            acVerticalGrid1.AddCheckEdit("IS_ICON_VISIBLE", "메뉴 아이콘 사용", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emCheckEditDataType._STRING);

            //acVerticalGrid1.AddTextEdit("COLUMN_PANEL_HEIGHT", "공정 컬럼 크기", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NUMERIC);

            acVerticalGrid1.AddCheckEdit("IS_FORM_ICON_COLOR_USE", "폼 아이콘 색 변경 사용", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emCheckEditDataType._STRING);

            acVerticalGrid1.AddColorEdit("ICON_COLOR", "폼 아이콘 색", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);

            acVerticalGrid1.AddCategoryRow("시스템", "UO57ITXM", true, new string[] { 
            "DEFAULT_FONT"
            ,"DEFAULT_FONT_SIZE"
            ,"DEFAULT_FONT_SETUP_URL"
            ,"QUICK_SUPPORT_URL"
            //,"HELP_URL"
            ,"SYSTEM_GROUP"
                        ,"IS_ICON_VISIBLE"
            ,"COLUMN_PANEL_HEIGHT"
            ,"IS_FORM_ICON_COLOR_USE"
            ,"ICON_COLOR"
            });


            acVerticalGrid1.AddCheckEdit("GRID_FOCUS_BORDER_USE", "선택 행 테두리 사용", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emCheckEditDataType._STRING);
            acVerticalGrid1.AddColorEdit("GRID_FOCUS_BORDER_COLOR", "선택 행 테두리 색상", string.Empty, false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);
            acVerticalGrid1.AddTextEdit("GRID_FOCUS_BORDER_HEIGHT", "선택 행 테두리 두께", string.Empty, false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NUMERIC);
            acVerticalGrid1.AddCheckEdit("GRID_HOT_TRACK_USE", "그리드행 HOT TRACK 사용", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emCheckEditDataType._STRING);

            #region pen dash style
            DataTable dtGridFocusBorderStyle = new DataTable();
            dtGridFocusBorderStyle.Columns.Add("STYLE_NAME", typeof(String));
            dtGridFocusBorderStyle.Columns.Add("STYLE_CODE", typeof(String));

            DataRow drGridFocusBorderStyle = dtGridFocusBorderStyle.NewRow();
            drGridFocusBorderStyle["STYLE_NAME"] = "──────────";
            drGridFocusBorderStyle["STYLE_CODE"] = "Solid";
            dtGridFocusBorderStyle.Rows.Add(drGridFocusBorderStyle);
            drGridFocusBorderStyle = dtGridFocusBorderStyle.NewRow();
            drGridFocusBorderStyle["STYLE_NAME"] = "─  ─  ─  ─  ─  ─  ";
            drGridFocusBorderStyle["STYLE_CODE"] = "Dash";
            dtGridFocusBorderStyle.Rows.Add(drGridFocusBorderStyle);
            drGridFocusBorderStyle = dtGridFocusBorderStyle.NewRow();
            drGridFocusBorderStyle["STYLE_NAME"] = "·  ·  ·  ·  ·  ·  ·  ·  ·  ·  ·";
            drGridFocusBorderStyle["STYLE_CODE"] = "Dot";
            dtGridFocusBorderStyle.Rows.Add(drGridFocusBorderStyle);
            drGridFocusBorderStyle = dtGridFocusBorderStyle.NewRow();
            drGridFocusBorderStyle["STYLE_NAME"] = "─ · ─ · ─ · ─ · ─ ·";
            drGridFocusBorderStyle["STYLE_CODE"] = "DashDot";
            dtGridFocusBorderStyle.Rows.Add(drGridFocusBorderStyle);
            drGridFocusBorderStyle = dtGridFocusBorderStyle.NewRow();
            drGridFocusBorderStyle["STYLE_NAME"] = "─ · · ─ · · ─ · · ─ ·";
            drGridFocusBorderStyle["STYLE_CODE"] = "DashDotDot";
            dtGridFocusBorderStyle.Rows.Add(drGridFocusBorderStyle);
            #endregion

            acVerticalGrid1.AddLookUpEdit("GRID_FOCUS_BORDER_STYLE", "선택 행 테두리 모양", string.Empty, false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, "STYLE_NAME", "STYLE_CODE", dtGridFocusBorderStyle);

            acVerticalGrid1.AddCategoryRow("그리드뷰", string.Empty, false, new string[] {
            "GRID_FOCUS_BORDER_USE"
            ,"GRID_FOCUS_BORDER_COLOR"
            ,"GRID_FOCUS_BORDER_HEIGHT"
            ,"GRID_FOCUS_BORDER_STYLE"
            ,"GRID_HOT_TRACK_USE"
            });

            acVerticalGrid1.AddTextEdit("DATE_MASK", "표시(마스크)", string.Empty, false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Default, true, true, acVerticalGrid.emTextEditMask.NONE);
            acVerticalGrid1.AddTextEdit("DATE_CULTURE", "국가", string.Empty, false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Default, true, true, acVerticalGrid.emTextEditMask.NONE);

            acVerticalGrid1.AddCategoryRow("날짜 설정", string.Empty, false, new string[] {
            "DATE_MASK"
            ,"DATE_CULTURE"
             });

            acVerticalGrid1.AddTextEdit("FTP_ADDRESS", "FTP 주소", "I666YSB1", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);
            acVerticalGrid1.AddTextEdit("FTP_PORT", "FTP 포트", "881W45YM", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NUMERIC);
            acVerticalGrid1.AddTextEdit("FTP_SERVER_PATH", "FTP 서버경로", "QCXTRJOC", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);
            acVerticalGrid1.AddTextEdit("FTP_USERID", "FTP 계정", "X688UUTM", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);
            acVerticalGrid1.AddTextEdit("FTP_PASSWORD", "FTP 계정암호", "HUQ6N8T3", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);


            acVerticalGrid1.AddCategoryRow("FTP 서버설정", "EUL30BTH", true, new string[] { 
            "FTP_ADDRESS"
            ,"FTP_PORT"
            ,"FTP_SERVER_PATH"
            ,"FTP_USERID"
            ,"FTP_PASSWORD"
            });


            acVerticalGrid1.AddTextEdit("SMTP_ADDRESS", "SMTP 주소", "VKFOXF2S", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);
            acVerticalGrid1.AddTextEdit("SMTP_PORT", "SMTP 포트", "N4B2391X", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NUMERIC);
            acVerticalGrid1.AddTextEdit("SMTP_USERID", "SMTP 계정", "X9PFSG8X", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);
            acVerticalGrid1.AddTextEdit("SMTP_PASSWORD", "SMTP 계정암호", "Q806XU1Q", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);
            acVerticalGrid1.AddCheckEdit("SMTP_SSL", "SMTP SSL 사용", "OH3M7P97", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emCheckEditDataType._STRING);

            acVerticalGrid1.AddCategoryRow("SMTP 서버설정", "EUCWY3AO", true, new string[] {
            "SMTP_ADDRESS"
            ,"SMTP_PORT"
            ,"SMTP_USERID"
            ,"SMTP_PASSWORD"
            ,"SMTP_SSL"
            });


            //acVerticalGrid1.AddTextEdit("UPDATE_DB_IP", "IP 주소", "A5DBGQ5Z", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);
            //acVerticalGrid1.AddTextEdit("UPDATE_DB_NAME", "데이터베이스명", "27K7T3UK", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);
            //acVerticalGrid1.AddTextEdit("UPDATE_DB_USER_NAME", "사용자", "5GUP7YWL", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);
            //acVerticalGrid1.AddTextEdit("UPDATE_DB_USER_PW", "비밀번호", "41100", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);
            //acVerticalGrid1.AddTextEdit("UPDATE_DB_PLT_CODE", "사업장코드", "A06BEXBH", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);

            //acVerticalGrid1.AddCategoryRow("업데이트 데이터베이스 정보", "7EZQ3BZ8", true, new string[] { 
            //"UPDATE_DB_IP"
            //,"UPDATE_DB_NAME"
            //,"UPDATE_DB_USER_NAME"
            //,"UPDATE_DB_USER_PW"
            //,"UPDATE_DB_PLT_CODE"
            //});

            acVerticalGrid1.AddTextEdit("BARCODE_SCANNER_HARDWARE_ID", "바코드스캐너 하드웨어ID", "EVUH56OO", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);
            //acVerticalGrid1.AddTextEdit("BARCODE_PRINTER", "바코드 프린터명", "VUPMY20Y", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);
            //acVerticalGrid1.AddMemoEdit("BARCODE_SEND_CODE", "바코드 전송코드", "N7C7K9BY", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Top, true, true);


            acVerticalGrid1.AddCategoryRow("바코드 설정", "VNBFWJCO", true, new string[] {
            "BARCODE_SCANNER_HARDWARE_ID"
            //,"BARCODE_PRINTER"
            //,"BARCODE_SEND_CODE"
            });


            acVerticalGrid1.AddColorEdit("STANDARD_EDIT_BACKCOLOR", "일반 컨트롤 배경색", "WWNNAIF8", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);
            acVerticalGrid1.AddColorEdit("STANDARD_EDIT_FORECOLOR", "일반 컨트롤 전경색", "ORFD3LNZ", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);

            acVerticalGrid1.AddColorEdit("READONLY_EDIT_BACKCOLOR", "읽기전용 컨트롤 배경색", "YY0NH5B1", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);
            acVerticalGrid1.AddColorEdit("READONLY_EDIT_FORECOLOR", "읽기전용 컨트롤 전경색", "KBI30SEJ", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);

            acVerticalGrid1.AddColorEdit("REQUIRED_EDIT_BACKCOLOR", "필수입력 컨트롤 배경색", "QT738WCF", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);
            acVerticalGrid1.AddColorEdit("REQUIRED_EDIT_FORECOLOR", "필수입력 컨트롤 전경색", "1Z9BGNMO", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);

            acVerticalGrid1.AddCheckEdit("FOCUS_EDIT_ENABLED", "포커스 컨트롤 사용", "ZMRXBD4Q", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emCheckEditDataType._STRING);
            acVerticalGrid1.AddColorEdit("FOCUS_EDIT_BACKCOLOR", "포커스 컨트롤 배경색", "YUOKPMZN", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);
            acVerticalGrid1.AddColorEdit("FOCUS_EDIT_FORECOLOR", "포커스 컨트롤 전경색", "MBRAW8K7", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);

            acVerticalGrid1.AddCheckEdit("LAYOUT_DRAW_ITEM_BORDERS", "레이아웃 아이템 선 표시", "NMLEOKAX", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emCheckEditDataType._STRING);

            acVerticalGrid1.AddCheckEdit("LAYOUT_HIGHLIGHT_FOCUS_ITEM", "레이아웃 아이템 포커스 강조", "B7BGIA0G", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emCheckEditDataType._STRING);
             
            acVerticalGrid1.AddTextEdit("GANTT_DAY_DISPLAY_TYPE", "간트차트 일표시형태", "YKR8WYFP", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);

            acVerticalGrid1.AddTextEdit("GANTT_DAYOFWEEK_DISPLAY_TYPE", "간트차트 요일표시형태", "FZ78RQD2", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);

            acVerticalGrid1.AddColorEdit("GANTT_SELECTED_ITEM_COLOR", "간트차트 아이템 선택색상", "9BN5KBOV", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);

            acVerticalGrid1.AddCheckEdit("GANTT_DISPLAY_TIMELINE", "간트차트 타임라인 표시", "8A9WX44Q", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emCheckEditDataType._STRING);

            acVerticalGrid1.AddColorEdit("GANTT_TIMELINE_COLOR", "간트차트 타임라인 색상", "G5658I0E", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);

            acVerticalGrid1.AddTimeEdit("GANTT_TIMELINE_DISPLAY_TIME", "간트차트 타임라인 표시시간", "ME6UL216", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, "HH:mm");

            acVerticalGrid1.AddColorEdit("GANTT_HOLIDAY_COLOR", "간트차트 휴일 색상", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);

            acVerticalGrid1.AddColorEdit("GANTT_SATSUN_COLOR", "간트차트 토/일 색상", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);

            
            acVerticalGrid1.AddCategoryRow("컨트롤", "S206OI4M", true, new string[] { 
            "STANDARD_EDIT_BACKCOLOR"
            ,"STANDARD_EDIT_FORECOLOR"
            ,"READONLY_EDIT_BACKCOLOR"
            ,"READONLY_EDIT_FORECOLOR"
            ,"REQUIRED_EDIT_BACKCOLOR"
            ,"REQUIRED_EDIT_FORECOLOR"
            ,"FOCUS_EDIT_ENABLED"
            ,"FOCUS_EDIT_BACKCOLOR"
            ,"FOCUS_EDIT_FORECOLOR"
            ,"LAYOUT_DRAW_ITEM_BORDERS"
            ,"LAYOUT_HIGHLIGHT_FOCUS_ITEM"
            ,"GANTT_DAY_DISPLAY_TYPE"
            ,"GANTT_DAYOFWEEK_DISPLAY_TYPE"
            ,"GANTT_SELECTED_ITEM_COLOR"
            ,"GANTT_DISPLAY_TIMELINE"
            ,"GANTT_TIMELINE_COLOR"
            ,"GANTT_TIMELINE_DISPLAY_TIME"
            ,"GANTT_HOLIDAY_COLOR"
            ,"GANTT_SATSUN_COLOR"
            });


            acVerticalGrid1.AddColorEdit("MONDAY_COLOR", "월요일", "DYMESF9O", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);
            acVerticalGrid1.AddColorEdit("TUESDAY_COLOR", "화요일", "212J5DAX", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);
            acVerticalGrid1.AddColorEdit("WEDNESDAY_COLOR", "수요일", "JBP1I70J", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);
            acVerticalGrid1.AddColorEdit("THURSDAY_COLOR", "목요일", "4JPD7G7I", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);
            acVerticalGrid1.AddColorEdit("FRIDAY_COLOR", "금요일", "YSI0B4DT", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);
            acVerticalGrid1.AddColorEdit("SATURDAY_COLOR", "토요일", "99S7MK5C", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);
            acVerticalGrid1.AddColorEdit("SUNDAY_COLOR", "일요일", "XVUMVHMK", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);


            acVerticalGrid1.AddCategoryRow("제조월력 설정", "B2RNM6NI", false, new string[] { 
            "MONDAY_COLOR"
            ,"TUESDAY_COLOR"
            ,"WEDNESDAY_COLOR"
            ,"THURSDAY_COLOR"
            ,"FRIDAY_COLOR"
            ,"SATURDAY_COLOR"
            ,"SUNDAY_COLOR"
            });


            //acVerticalGrid1.AddTextEdit("NOR_WORK_TIME", "평일 근무시간", "Z10EMQCF", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);
            //acVerticalGrid1.AddTextEdit("SAT_WORK_TIME", "토요일 근무시간", "J446V0DW", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);
            //acVerticalGrid1.AddTextEdit("SUN_WORK_TIME", "일요일 근무시간", "PK3O7WZ0", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);
            acVerticalGrid1.AddTextEdit("LUNCH_TIME", "점심식사시간", "ZQBONJO2", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);
            acVerticalGrid1.AddTextEdit("OFF_TIME", "휴식시간1", "J4W958Y3", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);
            acVerticalGrid1.AddTextEdit("OFF_TIME2", "휴식시간2", "J4W958Y3", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);
            acVerticalGrid1.AddTextEdit("DINNER_TIME", "저녁식사시간", "J4W958Y3", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);
            //acVerticalGrid1.AddTextEdit("DAY_CLOSE_TIME", "일마감시간", "CZX80JPM", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);


            //acVerticalGrid1.AddLookUpEdit("OE_COST_RATIO_TYPE", "판관비 적용율 형태", "BBD5C322", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, "C301");

            //acVerticalGrid1.AddCategoryRow("원가", "2I4B0E0U", true, new string[] { 
            //"OE_COST_RATIO_TYPE"
            //});


            acVerticalGrid1.AddTextEdit("MASK_MONEY_TYPE", "금액 형태", "4R4BWPUW", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);
            acVerticalGrid1.AddTextEdit("MASK_TEL_TYPE", "전화번호 형태", "ZILKC5JF", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);
            acVerticalGrid1.AddTextEdit("MASK_ZIP_TYPE", "우편번호 형태", "GT1P73PB", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);
            acVerticalGrid1.AddTextEdit("MASK_CORP_TYPE", "사업자번호 형태", "LZY9R2P3", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);
            acVerticalGrid1.AddTextEdit("MASK_LAW_TYPE", "법인번호 형태", "650RAB59", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);

            acVerticalGrid1.AddTextEdit("MASK_STD_CODE_TYPE", "기준코드 형태", "A5BH572Z", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);
            acVerticalGrid1.AddTextEdit("MASK_USER_CODE_TYPE", "사용자코드 형태", "VQOFDT9R", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);


            acVerticalGrid1.AddCategoryRow("마스크", "YSU2282M", true, new string[] { 
            "MASK_MONEY_TYPE"
            ,"MASK_TEL_TYPE"
            ,"MASK_ZIP_TYPE"
            ,"MASK_CORP_TYPE"
            ,"MASK_LAW_TYPE"
            ,"MASK_STD_CODE_TYPE"
            ,"MASK_USER_CODE_TYPE"
            });

            acVerticalGrid1.AddCategoryRow("근무시간", "G2U87YND", true, new string[] { 
            "LUNCH_TIME"
            ,"OFF_TIME"
            ,"OFF_TIME2"
            ,"DINNER_TIME"
            });

            //스케줄러 참조 정보
            //acVerticalGrid1.AddTextEdit("LSE_DSN_IP", "DSN IP 주소", "123LZF4R", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);
            //acVerticalGrid1.AddTextEdit("LSE_DSN_DATABASE", "DSN 데이터베이스", "03UHDIU6", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);
            //acVerticalGrid1.AddTextEdit("LSE_DSN_DRV", "DSN 드라이버", "ODWYICL2", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);
            //acVerticalGrid1.AddTextEdit("LSE_DSN_NAME", "DSN 명", "738D618T", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);
            //acVerticalGrid1.AddTextEdit("LSE_DSN_USER_NAME", "DSN 사용자", "4WQS12I9", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);
            //acVerticalGrid1.AddTextEdit("LSE_DSN_USER_PW", "DSN 비밀번호", "AXEUNLCS", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);

            //acVerticalGrid1.AddTextEdit("SHIFT_OT_TIME", "SHIFT_OT_TIME", "E5LK1JSG", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);
            //acVerticalGrid1.AddTextEdit("SHIFT_ST_TIME", "SHIFT_ST_TIME", "5WR5U0OH", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);
            //acVerticalGrid1.AddTextEdit("SHIFT_WK_TIME", "SHIFT_WK_TIME", "41IQY97J", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);
            //acVerticalGrid1.AddTextEdit("TIME_UNIT", "TIME_UNIT", "TSVLY0X8", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);
            //acVerticalGrid1.AddTextEdit("UNMANED_SCHED", "UNMANED_SCHED", "SJ1JVGRY", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);
            //acVerticalGrid1.AddTextEdit("WORK_ST_TIME", "WORK_ST_TIME", "VYHHW14I", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);
            //acVerticalGrid1.AddTextEdit("PROC_ST_TYPE", "PROC_ST_TYPE", "XVSL5EVZ", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);


            //acVerticalGrid1.AddCategoryRow("스케줄러 및 외부참조 연결", "270C6XEY", true, new string[] { 
            //"LSE_DSN_IP"
            //,"LSE_DSN_DATABASE"
            //,"LSE_DSN_DRV"
            //,"LSE_DSN_NAME"
            //,"LSE_DSN_USER_NAME"
            //,"LSE_DSN_USER_PW"
            //,"SHIFT_OT_TIME"
            //,"SHIFT_ST_TIME"
            //,"SHIFT_WK_TIME"
            //,"TIME_UNIT"
            //,"UNMANED_SCHED"
            //,"WORK_ST_TIME"
            //,"PROC_ST_TYPE"
            //});



            //acVerticalGrid1.AddColorEdit("MC_OPERATE_COLOR_0", "대기 색상", "B04SU027", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);
            //acVerticalGrid1.AddColorEdit("MC_OPERATE_COLOR_1", "비가동 색상", "OM2SLUC6", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);
            //acVerticalGrid1.AddColorEdit("MC_OPERATE_COLOR_2", "유인가동 색상", "N0Z7ZJU2", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);
            //acVerticalGrid1.AddColorEdit("MC_OPERATE_COLOR_3", "무인가동 색상", "OG9DMBH7", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);
            //acVerticalGrid1.AddColorEdit("MC_OPERATE_COLOR_4", "무작업지시 신호있음 색상", "FW0PN8ID", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);

            //acVerticalGrid1.AddCategoryRow("설비", "40303", true, new string[] { 
            //"MC_OPERATE_COLOR_0"
            //,"MC_OPERATE_COLOR_1"
            //,"MC_OPERATE_COLOR_2"
            //,"MC_OPERATE_COLOR_3"
            //,"MC_OPERATE_COLOR_4"
            // });

            acVerticalGrid1.AddColorEdit("MC_OPERATE_CLR_WAIT", "대기 색상", "B04SU027", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);
            //acVerticalGrid1.AddColorEdit("MC_OPERATE_CLR_IDLE", "비가동 색상", "OM2SLUC6", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);
            acVerticalGrid1.AddColorEdit("MC_OPERATE_CLR_RUN", "진행중 색상", "N0Z7ZJU2", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);
            acVerticalGrid1.AddColorEdit("MC_OPERATE_CLR_RUN2", "진행중 색상2", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true); //동일 작업 타설비 진행중
            acVerticalGrid1.AddColorEdit("MC_OPERATE_CLR_PAUSE", "중지 색상", "OG9DMBH7", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);
            acVerticalGrid1.AddColorEdit("MC_OPERATE_CLR_FINISH", "완료 색상", "FW0PN8ID", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);
           // acVerticalGrid1.AddColorEdit("MC_OPERATE_CLR_ERROR", "이상신호 색상", "10RII8CK", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);

            acVerticalGrid1.AddCategoryRow("설비", "40303", true, new string[] {
            "MC_OPERATE_CLR_WAIT"
          //,"MC_OPERATE_CLR_IDLE"
            ,"MC_OPERATE_CLR_RUN"
            ,"MC_OPERATE_CLR_RUN2"
            ,"MC_OPERATE_CLR_PAUSE"
            ,"MC_OPERATE_CLR_FINISH"
          //,"MC_OPERATE_CLR_ERROR"
             });

            //acVerticalGrid1.AddColorEdit("MC_SIGNAL_OPERATE_CLR_R", "가동 신호 색상", "9IIBW87F", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);
            //acVerticalGrid1.AddColorEdit("MC_SIGNAL_OPERATE_CLR_W", "비가동 신호 색상", "9E8LPOPI", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);
            //acVerticalGrid1.AddColorEdit("MC_SIGNAL_OPERATE_CLR_F", "전원OFF 색상", "TIBGENFC", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);
            //acVerticalGrid1.AddColorEdit("MC_SIGNAL_OPERATE_CLR_A", "알람 색상", "WJVGHDHR", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);

            //acVerticalGrid1.AddCategoryRow("설비 신호", "40303", true, new string[] { 
            //"MC_SIGNAL_OPERATE_CLR_R"
            //,"MC_SIGNAL_OPERATE_CLR_W"
            //,"MC_SIGNAL_OPERATE_CLR_F"
            //,"MC_SIGNAL_OPERATE_CLR_A"
            // });


            //acVerticalGrid1.AddTextEdit("POP_TERMINAL_REFRESH_TIME", "갱신시간(초)", "7QFY2GCJ", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NUMERIC);
            //acVerticalGrid1.AddCheckEdit("POP_TERMINAL_REQUEST_ACCESS", "접속허용 요청가능", "GEU7FL7K", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emCheckEditDataType._STRING);
            acVerticalGrid1.AddTextEdit("POP_SCROLL_SIZE", "스크롤 크기", "JVF83VHT", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NUMERIC);
            acVerticalGrid1.AddTextEdit("PANNEL_FONT_SIZE", "단말기 글꼴 크기", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NUMERIC);
            acVerticalGrid1.AddTextEdit("POP_FILE_DIR", "단말기 파일 다운로드 경로", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);


            acVerticalGrid1.AddCategoryRow("현장단말기", "CM4DLQGP", true, new string[] { 
            //"POP_TERMINAL_REFRESH_TIME"
            //,"POP_TERMINAL_REQUEST_ACCESS"
            //,
            "POP_SCROLL_SIZE"
            ,"PANNEL_FONT_SIZE"
            ,"POP_FILE_DIR"

            });


            acVerticalGrid1.AddTextEdit("MONITOR_REFRESH_TIME", "설정시간(초)", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NUMERIC);

            acVerticalGrid1.AddCategoryRow("설비모니터링 타이머 설정", "", true, new string[] { 
      
            "MONITOR_REFRESH_TIME"
     
            });

            acVerticalGrid1.AddTextEdit("SCROLLING_TIME", "설정시간(초)", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NUMERIC);

            acVerticalGrid1.AddCategoryRow("스크롤링 타이머 설정", "", true, new string[] {

            "SCROLLING_TIME"

            });



            //acVerticalGrid1.AddTextEdit("NOTIFY_REFRESH_TIME", "갱신시간(초)", "7QFY2GCJ", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NUMERIC);


            //acVerticalGrid1.AddCategoryRow("알림", "BKPRD7Y2", true, new string[] { 
            //"NOTIFY_REFRESH_TIME"
            //});

            //acVerticalGrid1.AddTextEdit("PROC_GOAL", "공정불량 목표(PPM)", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);
            //acVerticalGrid1.AddTextEdit("DUE_GOAL", "납품불량 목표(PPM)", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);
            //acVerticalGrid1.AddTextEdit("Q_COST_GOAL", "Q-COST 목표(%)", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);
            //acVerticalGrid1.AddTextEdit("P_A_COST_GOAL", "P-COST + A-COST 목표(%)", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);
            //acVerticalGrid1.AddTextEdit("F_COST_GOAL", "F-COST 목표(%)", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);

            //acVerticalGrid1.AddCategoryRow("불량 목표 관리", "", false, new string[] {
            //"PROC_GOAL"
            //,"DUE_GOAL"
            //,"Q_COST_GOAL"
            //,"P_A_COST_GOAL"
            //,"F_COST_GOAL"
            //});


            acVerticalGrid1.AddColorEdit("APP_STATE_PROG", "진행", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);
            acVerticalGrid1.AddColorEdit("APP_STATE_OK", "승인", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);
            acVerticalGrid1.AddColorEdit("APP_STATE_DENY", "반려", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);
           
            acVerticalGrid1.AddCategoryRow("승인 상태별 색상", "", false, new string[] {
            "APP_STATE_PROG"
            ,"APP_STATE_OK"
            ,"APP_STATE_DENY"
             });



            acVerticalGrid1.AddTextEdit("SPEC_KEYCHAR_CIRCLE", "원기둥 문자", "KLPQI82Y", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);
            acVerticalGrid1.AddTextEdit("SPEC_KEYCHAR_HEXA", "육면체 문자", "T855PH0H", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);
            acVerticalGrid1.AddTextEdit("SPEC_KEYCHAR_X", "곱셈 문자", "28AF2N09", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);

            acVerticalGrid1.AddCategoryRow("기타", "9T63A9BA", true, new string[] { 
            "SPEC_KEYCHAR_CIRCLE"
            ,"SPEC_KEYCHAR_HEXA"
            ,"SPEC_KEYCHAR_X"                                   
            });

            acVerticalGrid1.AddTextEdit("WEB_API_KEY_HOLIDAY", "공휴일 정보", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);

            acVerticalGrid1.AddCategoryRow("Web Api 키", "", false, new string[] {
            "WEB_API_KEY_HOLIDAY"
            });


            acVerticalGrid1.AddDateEdit("ACCOUNT_DATE", "첫회계일", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Center, true, true, acVerticalGrid.emDateMask.SHORT_DATE);
            acVerticalGrid1.AddDateEdit("TARGET_DATE", "대상자(일)", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Center, true, true, acVerticalGrid.emDateMask.SHORT_DATE);
            acVerticalGrid1.AddDateEdit("ENFOR_DATE", "시행일", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Center, true, true, acVerticalGrid.emDateMask.SHORT_DATE);

            acVerticalGrid1.AddCategoryRow("연차계산", "", false, new string[] {
            "ACCOUNT_DATE"
            ,"TARGET_DATE"
            ,"ENFOR_DATE"
            });

            acVerticalGrid1.AddCheckEdit("PWD_POLICY_USE", "비밀번호 정책 사용", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emCheckEditDataType._STRING);
            acVerticalGrid1.AddTextEdit("PWD_CHANGE_PERIOD", "비밀번호 변경 주기(일)", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NUMERIC);
            acVerticalGrid1.AddTextEdit("PWD_CHANGE_REMAIN_DAY", "비밀번호 변경 경고 잔여일", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NUMERIC);
            acVerticalGrid1.AddTextEdit("PWD_FAIL_LIMITED_CNT", "비밀번호 실패 제한 수", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NUMERIC);
            acVerticalGrid1.AddTextEdit("PASSWORD_LENGTH", "비밀번호 길이", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NUMERIC);

            acVerticalGrid1.AddCategoryRow("로그인 관리", "", false, new string[] {
                "PWD_POLICY_USE",
                "PWD_CHANGE_PERIOD",
                "PWD_CHANGE_REMAIN_DAY",
                "PWD_FAIL_LIMITED_CNT",
                "PASSWORD_LENGTH"
            });

            acVerticalGrid1.AddTextEdit("DRAW_FILE_DIR", "도면 파일 경로", "", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);
            acVerticalGrid1.AddTextEdit("DRAW_FILE_REMOVE_DIR", "도면 파일 제거 경로", "", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);
            acVerticalGrid1.AddTextEdit("DRAW_FILE_DIR_ID", "도면 파일 경로 ID", "", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);
            acVerticalGrid1.AddTextEdit("DRAW_FILE_DIR_PW", "도면 파일 경로 PW", "", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.PW);

            acVerticalGrid1.AddCategoryRow("인터페이스 정보", "", false, new string[] {
             "DRAW_FILE_DIR"
            ,"DRAW_FILE_REMOVE_DIR"
            ,"DRAW_FILE_DIR_ID"
            ,"DRAW_FILE_DIR_PW"
            });

            acVerticalGrid1.DataBind(acInfo.SysConfig.GetSysConfigRowTableByServer().Rows[0]);

            acVerticalGrid1.BestFit();


            base.MenuInit();
        }


        void Search()
        {
            //갱신

            acVerticalGrid1.DataBind(acInfo.SysConfig.GetSysConfigRowTableByServer().Rows[0]);

            base.SetLog(QBiz.emExecuteType.REFRESH);

        }


        private void barItemSearch_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //조회

            try
            {
                this.Search();

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void barItemSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
         
            //저장

            try
            {

                acVerticalGrid1.EndEditor();


                DataTable data = acVerticalGrid1.CreateParameterTable(true);

                foreach (DataColumn col in data.Columns)
                {
                    if (col.ColumnName == "ACCOUNT_DATE"
                        || col.ColumnName == "TARGET_DATE"
                        || col.ColumnName == "ENFOR_DATE")
                    {
                        if (data.Rows[0][col.ColumnName].toStringEmpty() != "")
                        {
                            data.Rows[0][col.ColumnName] = data.Rows[0][col.ColumnName].ToString().Substring(0, 10).toDateString("yyyyMMdd");
                        }
                    }

                    acInfo.SysConfig.SetSysConfigByServer(col.ColumnName, data.Rows[0][col.ColumnName].toStringEmpty(),"SYS");


                }

                acVerticalGrid1.ClearValueChanged();


                acInfo.SysConfig.UpdateMemorySysConfig();

                base.SetLog(QBiz.emExecuteType.SAVE);

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }



    }
}

