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
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //������ڵ�

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            DataTable data = BizRun.QBizRun.ExecuteService(this, "CTRL", "CONTROL_USRGRP_SEARCH", paramSet, "RQSTDT", "RSLTDT").Tables[1];

            acVerticalGrid1.ClearRows();

            acVerticalGrid1.AddTextEdit("DEFAULT_FONT", "�⺻�۲�", "K9AWM1CM", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);

            acVerticalGrid1.AddTextEdit("DEFAULT_FONT_SIZE", "�⺻ �۲� ũ��", "W22IG3C7", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NUMERIC);

            acVerticalGrid1.AddTextEdit("DEFAULT_FONT_SETUP_URL", "�⺻�۲� ��ġURL", "JYTW4IQF", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);

            acVerticalGrid1.AddTextEdit("QUICK_SUPPORT_URL", "�������� ��ġURL", "UDKZJBWG", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);

            //acVerticalGrid1.AddTextEdit("HELP_URL", "���� URL", "IOU06N7Y", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);

            acVerticalGrid1.AddLookUpEdit("SYSTEM_GROUP", "�ý��ۻ���� �׷�", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, "USRGRP_NAME", "USRGRP_CODE", data);


            acVerticalGrid1.AddCheckEdit("IS_ICON_VISIBLE", "�޴� ������ ���", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emCheckEditDataType._STRING);

            //acVerticalGrid1.AddTextEdit("COLUMN_PANEL_HEIGHT", "���� �÷� ũ��", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NUMERIC);

            acVerticalGrid1.AddCheckEdit("IS_FORM_ICON_COLOR_USE", "�� ������ �� ���� ���", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emCheckEditDataType._STRING);

            acVerticalGrid1.AddColorEdit("ICON_COLOR", "�� ������ ��", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);

            acVerticalGrid1.AddCategoryRow("�ý���", "UO57ITXM", true, new string[] { 
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


            acVerticalGrid1.AddCheckEdit("GRID_FOCUS_BORDER_USE", "���� �� �׵θ� ���", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emCheckEditDataType._STRING);
            acVerticalGrid1.AddColorEdit("GRID_FOCUS_BORDER_COLOR", "���� �� �׵θ� ����", string.Empty, false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);
            acVerticalGrid1.AddTextEdit("GRID_FOCUS_BORDER_HEIGHT", "���� �� �׵θ� �β�", string.Empty, false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NUMERIC);
            acVerticalGrid1.AddCheckEdit("GRID_HOT_TRACK_USE", "�׸����� HOT TRACK ���", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emCheckEditDataType._STRING);

            #region pen dash style
            DataTable dtGridFocusBorderStyle = new DataTable();
            dtGridFocusBorderStyle.Columns.Add("STYLE_NAME", typeof(String));
            dtGridFocusBorderStyle.Columns.Add("STYLE_CODE", typeof(String));

            DataRow drGridFocusBorderStyle = dtGridFocusBorderStyle.NewRow();
            drGridFocusBorderStyle["STYLE_NAME"] = "��������������������";
            drGridFocusBorderStyle["STYLE_CODE"] = "Solid";
            dtGridFocusBorderStyle.Rows.Add(drGridFocusBorderStyle);
            drGridFocusBorderStyle = dtGridFocusBorderStyle.NewRow();
            drGridFocusBorderStyle["STYLE_NAME"] = "��  ��  ��  ��  ��  ��  ";
            drGridFocusBorderStyle["STYLE_CODE"] = "Dash";
            dtGridFocusBorderStyle.Rows.Add(drGridFocusBorderStyle);
            drGridFocusBorderStyle = dtGridFocusBorderStyle.NewRow();
            drGridFocusBorderStyle["STYLE_NAME"] = "��  ��  ��  ��  ��  ��  ��  ��  ��  ��  ��";
            drGridFocusBorderStyle["STYLE_CODE"] = "Dot";
            dtGridFocusBorderStyle.Rows.Add(drGridFocusBorderStyle);
            drGridFocusBorderStyle = dtGridFocusBorderStyle.NewRow();
            drGridFocusBorderStyle["STYLE_NAME"] = "�� �� �� �� �� �� �� �� �� ��";
            drGridFocusBorderStyle["STYLE_CODE"] = "DashDot";
            dtGridFocusBorderStyle.Rows.Add(drGridFocusBorderStyle);
            drGridFocusBorderStyle = dtGridFocusBorderStyle.NewRow();
            drGridFocusBorderStyle["STYLE_NAME"] = "�� �� �� �� �� �� �� �� �� �� ��";
            drGridFocusBorderStyle["STYLE_CODE"] = "DashDotDot";
            dtGridFocusBorderStyle.Rows.Add(drGridFocusBorderStyle);
            #endregion

            acVerticalGrid1.AddLookUpEdit("GRID_FOCUS_BORDER_STYLE", "���� �� �׵θ� ���", string.Empty, false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, "STYLE_NAME", "STYLE_CODE", dtGridFocusBorderStyle);

            acVerticalGrid1.AddCategoryRow("�׸����", string.Empty, false, new string[] {
            "GRID_FOCUS_BORDER_USE"
            ,"GRID_FOCUS_BORDER_COLOR"
            ,"GRID_FOCUS_BORDER_HEIGHT"
            ,"GRID_FOCUS_BORDER_STYLE"
            ,"GRID_HOT_TRACK_USE"
            });

            acVerticalGrid1.AddTextEdit("DATE_MASK", "ǥ��(����ũ)", string.Empty, false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Default, true, true, acVerticalGrid.emTextEditMask.NONE);
            acVerticalGrid1.AddTextEdit("DATE_CULTURE", "����", string.Empty, false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Default, true, true, acVerticalGrid.emTextEditMask.NONE);

            acVerticalGrid1.AddCategoryRow("��¥ ����", string.Empty, false, new string[] {
            "DATE_MASK"
            ,"DATE_CULTURE"
             });

            acVerticalGrid1.AddTextEdit("FTP_ADDRESS", "FTP �ּ�", "I666YSB1", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);
            acVerticalGrid1.AddTextEdit("FTP_PORT", "FTP ��Ʈ", "881W45YM", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NUMERIC);
            acVerticalGrid1.AddTextEdit("FTP_SERVER_PATH", "FTP �������", "QCXTRJOC", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);
            acVerticalGrid1.AddTextEdit("FTP_USERID", "FTP ����", "X688UUTM", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);
            acVerticalGrid1.AddTextEdit("FTP_PASSWORD", "FTP ������ȣ", "HUQ6N8T3", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);


            acVerticalGrid1.AddCategoryRow("FTP ��������", "EUL30BTH", true, new string[] { 
            "FTP_ADDRESS"
            ,"FTP_PORT"
            ,"FTP_SERVER_PATH"
            ,"FTP_USERID"
            ,"FTP_PASSWORD"
            });


            acVerticalGrid1.AddTextEdit("SMTP_ADDRESS", "SMTP �ּ�", "VKFOXF2S", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);
            acVerticalGrid1.AddTextEdit("SMTP_PORT", "SMTP ��Ʈ", "N4B2391X", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NUMERIC);
            acVerticalGrid1.AddTextEdit("SMTP_USERID", "SMTP ����", "X9PFSG8X", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);
            acVerticalGrid1.AddTextEdit("SMTP_PASSWORD", "SMTP ������ȣ", "Q806XU1Q", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);
            acVerticalGrid1.AddCheckEdit("SMTP_SSL", "SMTP SSL ���", "OH3M7P97", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emCheckEditDataType._STRING);

            acVerticalGrid1.AddCategoryRow("SMTP ��������", "EUCWY3AO", true, new string[] {
            "SMTP_ADDRESS"
            ,"SMTP_PORT"
            ,"SMTP_USERID"
            ,"SMTP_PASSWORD"
            ,"SMTP_SSL"
            });


            //acVerticalGrid1.AddTextEdit("UPDATE_DB_IP", "IP �ּ�", "A5DBGQ5Z", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);
            //acVerticalGrid1.AddTextEdit("UPDATE_DB_NAME", "�����ͺ��̽���", "27K7T3UK", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);
            //acVerticalGrid1.AddTextEdit("UPDATE_DB_USER_NAME", "�����", "5GUP7YWL", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);
            //acVerticalGrid1.AddTextEdit("UPDATE_DB_USER_PW", "��й�ȣ", "41100", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);
            //acVerticalGrid1.AddTextEdit("UPDATE_DB_PLT_CODE", "������ڵ�", "A06BEXBH", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);

            //acVerticalGrid1.AddCategoryRow("������Ʈ �����ͺ��̽� ����", "7EZQ3BZ8", true, new string[] { 
            //"UPDATE_DB_IP"
            //,"UPDATE_DB_NAME"
            //,"UPDATE_DB_USER_NAME"
            //,"UPDATE_DB_USER_PW"
            //,"UPDATE_DB_PLT_CODE"
            //});

            acVerticalGrid1.AddTextEdit("BARCODE_SCANNER_HARDWARE_ID", "���ڵ彺ĳ�� �ϵ����ID", "EVUH56OO", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);
            //acVerticalGrid1.AddTextEdit("BARCODE_PRINTER", "���ڵ� �����͸�", "VUPMY20Y", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);
            //acVerticalGrid1.AddMemoEdit("BARCODE_SEND_CODE", "���ڵ� �����ڵ�", "N7C7K9BY", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Top, true, true);


            acVerticalGrid1.AddCategoryRow("���ڵ� ����", "VNBFWJCO", true, new string[] {
            "BARCODE_SCANNER_HARDWARE_ID"
            //,"BARCODE_PRINTER"
            //,"BARCODE_SEND_CODE"
            });


            acVerticalGrid1.AddColorEdit("STANDARD_EDIT_BACKCOLOR", "�Ϲ� ��Ʈ�� ����", "WWNNAIF8", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);
            acVerticalGrid1.AddColorEdit("STANDARD_EDIT_FORECOLOR", "�Ϲ� ��Ʈ�� �����", "ORFD3LNZ", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);

            acVerticalGrid1.AddColorEdit("READONLY_EDIT_BACKCOLOR", "�б����� ��Ʈ�� ����", "YY0NH5B1", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);
            acVerticalGrid1.AddColorEdit("READONLY_EDIT_FORECOLOR", "�б����� ��Ʈ�� �����", "KBI30SEJ", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);

            acVerticalGrid1.AddColorEdit("REQUIRED_EDIT_BACKCOLOR", "�ʼ��Է� ��Ʈ�� ����", "QT738WCF", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);
            acVerticalGrid1.AddColorEdit("REQUIRED_EDIT_FORECOLOR", "�ʼ��Է� ��Ʈ�� �����", "1Z9BGNMO", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);

            acVerticalGrid1.AddCheckEdit("FOCUS_EDIT_ENABLED", "��Ŀ�� ��Ʈ�� ���", "ZMRXBD4Q", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emCheckEditDataType._STRING);
            acVerticalGrid1.AddColorEdit("FOCUS_EDIT_BACKCOLOR", "��Ŀ�� ��Ʈ�� ����", "YUOKPMZN", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);
            acVerticalGrid1.AddColorEdit("FOCUS_EDIT_FORECOLOR", "��Ŀ�� ��Ʈ�� �����", "MBRAW8K7", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);

            acVerticalGrid1.AddCheckEdit("LAYOUT_DRAW_ITEM_BORDERS", "���̾ƿ� ������ �� ǥ��", "NMLEOKAX", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emCheckEditDataType._STRING);

            acVerticalGrid1.AddCheckEdit("LAYOUT_HIGHLIGHT_FOCUS_ITEM", "���̾ƿ� ������ ��Ŀ�� ����", "B7BGIA0G", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emCheckEditDataType._STRING);
             
            acVerticalGrid1.AddTextEdit("GANTT_DAY_DISPLAY_TYPE", "��Ʈ��Ʈ ��ǥ������", "YKR8WYFP", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);

            acVerticalGrid1.AddTextEdit("GANTT_DAYOFWEEK_DISPLAY_TYPE", "��Ʈ��Ʈ ����ǥ������", "FZ78RQD2", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);

            acVerticalGrid1.AddColorEdit("GANTT_SELECTED_ITEM_COLOR", "��Ʈ��Ʈ ������ ���û���", "9BN5KBOV", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);

            acVerticalGrid1.AddCheckEdit("GANTT_DISPLAY_TIMELINE", "��Ʈ��Ʈ Ÿ�Ӷ��� ǥ��", "8A9WX44Q", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emCheckEditDataType._STRING);

            acVerticalGrid1.AddColorEdit("GANTT_TIMELINE_COLOR", "��Ʈ��Ʈ Ÿ�Ӷ��� ����", "G5658I0E", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);

            acVerticalGrid1.AddTimeEdit("GANTT_TIMELINE_DISPLAY_TIME", "��Ʈ��Ʈ Ÿ�Ӷ��� ǥ�ýð�", "ME6UL216", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, "HH:mm");

            acVerticalGrid1.AddColorEdit("GANTT_HOLIDAY_COLOR", "��Ʈ��Ʈ ���� ����", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);

            acVerticalGrid1.AddColorEdit("GANTT_SATSUN_COLOR", "��Ʈ��Ʈ ��/�� ����", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);

            
            acVerticalGrid1.AddCategoryRow("��Ʈ��", "S206OI4M", true, new string[] { 
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


            acVerticalGrid1.AddColorEdit("MONDAY_COLOR", "������", "DYMESF9O", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);
            acVerticalGrid1.AddColorEdit("TUESDAY_COLOR", "ȭ����", "212J5DAX", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);
            acVerticalGrid1.AddColorEdit("WEDNESDAY_COLOR", "������", "JBP1I70J", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);
            acVerticalGrid1.AddColorEdit("THURSDAY_COLOR", "�����", "4JPD7G7I", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);
            acVerticalGrid1.AddColorEdit("FRIDAY_COLOR", "�ݿ���", "YSI0B4DT", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);
            acVerticalGrid1.AddColorEdit("SATURDAY_COLOR", "�����", "99S7MK5C", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);
            acVerticalGrid1.AddColorEdit("SUNDAY_COLOR", "�Ͽ���", "XVUMVHMK", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);


            acVerticalGrid1.AddCategoryRow("�������� ����", "B2RNM6NI", false, new string[] { 
            "MONDAY_COLOR"
            ,"TUESDAY_COLOR"
            ,"WEDNESDAY_COLOR"
            ,"THURSDAY_COLOR"
            ,"FRIDAY_COLOR"
            ,"SATURDAY_COLOR"
            ,"SUNDAY_COLOR"
            });


            //acVerticalGrid1.AddTextEdit("NOR_WORK_TIME", "���� �ٹ��ð�", "Z10EMQCF", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);
            //acVerticalGrid1.AddTextEdit("SAT_WORK_TIME", "����� �ٹ��ð�", "J446V0DW", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);
            //acVerticalGrid1.AddTextEdit("SUN_WORK_TIME", "�Ͽ��� �ٹ��ð�", "PK3O7WZ0", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);
            acVerticalGrid1.AddTextEdit("LUNCH_TIME", "���ɽĻ�ð�", "ZQBONJO2", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);
            acVerticalGrid1.AddTextEdit("OFF_TIME", "�޽Ľð�1", "J4W958Y3", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);
            acVerticalGrid1.AddTextEdit("OFF_TIME2", "�޽Ľð�2", "J4W958Y3", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);
            acVerticalGrid1.AddTextEdit("DINNER_TIME", "����Ļ�ð�", "J4W958Y3", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);
            //acVerticalGrid1.AddTextEdit("DAY_CLOSE_TIME", "�ϸ����ð�", "CZX80JPM", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);


            //acVerticalGrid1.AddLookUpEdit("OE_COST_RATIO_TYPE", "�ǰ��� ������ ����", "BBD5C322", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, "C301");

            //acVerticalGrid1.AddCategoryRow("����", "2I4B0E0U", true, new string[] { 
            //"OE_COST_RATIO_TYPE"
            //});


            acVerticalGrid1.AddTextEdit("MASK_MONEY_TYPE", "�ݾ� ����", "4R4BWPUW", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);
            acVerticalGrid1.AddTextEdit("MASK_TEL_TYPE", "��ȭ��ȣ ����", "ZILKC5JF", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);
            acVerticalGrid1.AddTextEdit("MASK_ZIP_TYPE", "�����ȣ ����", "GT1P73PB", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);
            acVerticalGrid1.AddTextEdit("MASK_CORP_TYPE", "����ڹ�ȣ ����", "LZY9R2P3", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);
            acVerticalGrid1.AddTextEdit("MASK_LAW_TYPE", "���ι�ȣ ����", "650RAB59", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);

            acVerticalGrid1.AddTextEdit("MASK_STD_CODE_TYPE", "�����ڵ� ����", "A5BH572Z", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);
            acVerticalGrid1.AddTextEdit("MASK_USER_CODE_TYPE", "������ڵ� ����", "VQOFDT9R", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);


            acVerticalGrid1.AddCategoryRow("����ũ", "YSU2282M", true, new string[] { 
            "MASK_MONEY_TYPE"
            ,"MASK_TEL_TYPE"
            ,"MASK_ZIP_TYPE"
            ,"MASK_CORP_TYPE"
            ,"MASK_LAW_TYPE"
            ,"MASK_STD_CODE_TYPE"
            ,"MASK_USER_CODE_TYPE"
            });

            acVerticalGrid1.AddCategoryRow("�ٹ��ð�", "G2U87YND", true, new string[] { 
            "LUNCH_TIME"
            ,"OFF_TIME"
            ,"OFF_TIME2"
            ,"DINNER_TIME"
            });

            //�����ٷ� ���� ����
            //acVerticalGrid1.AddTextEdit("LSE_DSN_IP", "DSN IP �ּ�", "123LZF4R", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);
            //acVerticalGrid1.AddTextEdit("LSE_DSN_DATABASE", "DSN �����ͺ��̽�", "03UHDIU6", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);
            //acVerticalGrid1.AddTextEdit("LSE_DSN_DRV", "DSN ����̹�", "ODWYICL2", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);
            //acVerticalGrid1.AddTextEdit("LSE_DSN_NAME", "DSN ��", "738D618T", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);
            //acVerticalGrid1.AddTextEdit("LSE_DSN_USER_NAME", "DSN �����", "4WQS12I9", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);
            //acVerticalGrid1.AddTextEdit("LSE_DSN_USER_PW", "DSN ��й�ȣ", "AXEUNLCS", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);

            //acVerticalGrid1.AddTextEdit("SHIFT_OT_TIME", "SHIFT_OT_TIME", "E5LK1JSG", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);
            //acVerticalGrid1.AddTextEdit("SHIFT_ST_TIME", "SHIFT_ST_TIME", "5WR5U0OH", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);
            //acVerticalGrid1.AddTextEdit("SHIFT_WK_TIME", "SHIFT_WK_TIME", "41IQY97J", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);
            //acVerticalGrid1.AddTextEdit("TIME_UNIT", "TIME_UNIT", "TSVLY0X8", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);
            //acVerticalGrid1.AddTextEdit("UNMANED_SCHED", "UNMANED_SCHED", "SJ1JVGRY", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);
            //acVerticalGrid1.AddTextEdit("WORK_ST_TIME", "WORK_ST_TIME", "VYHHW14I", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);
            //acVerticalGrid1.AddTextEdit("PROC_ST_TYPE", "PROC_ST_TYPE", "XVSL5EVZ", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);


            //acVerticalGrid1.AddCategoryRow("�����ٷ� �� �ܺ����� ����", "270C6XEY", true, new string[] { 
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



            //acVerticalGrid1.AddColorEdit("MC_OPERATE_COLOR_0", "��� ����", "B04SU027", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);
            //acVerticalGrid1.AddColorEdit("MC_OPERATE_COLOR_1", "�񰡵� ����", "OM2SLUC6", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);
            //acVerticalGrid1.AddColorEdit("MC_OPERATE_COLOR_2", "���ΰ��� ����", "N0Z7ZJU2", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);
            //acVerticalGrid1.AddColorEdit("MC_OPERATE_COLOR_3", "���ΰ��� ����", "OG9DMBH7", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);
            //acVerticalGrid1.AddColorEdit("MC_OPERATE_COLOR_4", "���۾����� ��ȣ���� ����", "FW0PN8ID", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);

            //acVerticalGrid1.AddCategoryRow("����", "40303", true, new string[] { 
            //"MC_OPERATE_COLOR_0"
            //,"MC_OPERATE_COLOR_1"
            //,"MC_OPERATE_COLOR_2"
            //,"MC_OPERATE_COLOR_3"
            //,"MC_OPERATE_COLOR_4"
            // });

            acVerticalGrid1.AddColorEdit("MC_OPERATE_CLR_WAIT", "��� ����", "B04SU027", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);
            //acVerticalGrid1.AddColorEdit("MC_OPERATE_CLR_IDLE", "�񰡵� ����", "OM2SLUC6", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);
            acVerticalGrid1.AddColorEdit("MC_OPERATE_CLR_RUN", "������ ����", "N0Z7ZJU2", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);
            acVerticalGrid1.AddColorEdit("MC_OPERATE_CLR_RUN2", "������ ����2", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true); //���� �۾� Ÿ���� ������
            acVerticalGrid1.AddColorEdit("MC_OPERATE_CLR_PAUSE", "���� ����", "OG9DMBH7", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);
            acVerticalGrid1.AddColorEdit("MC_OPERATE_CLR_FINISH", "�Ϸ� ����", "FW0PN8ID", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);
           // acVerticalGrid1.AddColorEdit("MC_OPERATE_CLR_ERROR", "�̻��ȣ ����", "10RII8CK", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);

            acVerticalGrid1.AddCategoryRow("����", "40303", true, new string[] {
            "MC_OPERATE_CLR_WAIT"
          //,"MC_OPERATE_CLR_IDLE"
            ,"MC_OPERATE_CLR_RUN"
            ,"MC_OPERATE_CLR_RUN2"
            ,"MC_OPERATE_CLR_PAUSE"
            ,"MC_OPERATE_CLR_FINISH"
          //,"MC_OPERATE_CLR_ERROR"
             });

            //acVerticalGrid1.AddColorEdit("MC_SIGNAL_OPERATE_CLR_R", "���� ��ȣ ����", "9IIBW87F", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);
            //acVerticalGrid1.AddColorEdit("MC_SIGNAL_OPERATE_CLR_W", "�񰡵� ��ȣ ����", "9E8LPOPI", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);
            //acVerticalGrid1.AddColorEdit("MC_SIGNAL_OPERATE_CLR_F", "����OFF ����", "TIBGENFC", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);
            //acVerticalGrid1.AddColorEdit("MC_SIGNAL_OPERATE_CLR_A", "�˶� ����", "WJVGHDHR", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);

            //acVerticalGrid1.AddCategoryRow("���� ��ȣ", "40303", true, new string[] { 
            //"MC_SIGNAL_OPERATE_CLR_R"
            //,"MC_SIGNAL_OPERATE_CLR_W"
            //,"MC_SIGNAL_OPERATE_CLR_F"
            //,"MC_SIGNAL_OPERATE_CLR_A"
            // });


            //acVerticalGrid1.AddTextEdit("POP_TERMINAL_REFRESH_TIME", "���Žð�(��)", "7QFY2GCJ", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NUMERIC);
            //acVerticalGrid1.AddCheckEdit("POP_TERMINAL_REQUEST_ACCESS", "������� ��û����", "GEU7FL7K", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emCheckEditDataType._STRING);
            acVerticalGrid1.AddTextEdit("POP_SCROLL_SIZE", "��ũ�� ũ��", "JVF83VHT", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NUMERIC);
            acVerticalGrid1.AddTextEdit("PANNEL_FONT_SIZE", "�ܸ��� �۲� ũ��", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NUMERIC);
            acVerticalGrid1.AddTextEdit("POP_FILE_DIR", "�ܸ��� ���� �ٿ�ε� ���", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);


            acVerticalGrid1.AddCategoryRow("����ܸ���", "CM4DLQGP", true, new string[] { 
            //"POP_TERMINAL_REFRESH_TIME"
            //,"POP_TERMINAL_REQUEST_ACCESS"
            //,
            "POP_SCROLL_SIZE"
            ,"PANNEL_FONT_SIZE"
            ,"POP_FILE_DIR"

            });


            acVerticalGrid1.AddTextEdit("MONITOR_REFRESH_TIME", "�����ð�(��)", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NUMERIC);

            acVerticalGrid1.AddCategoryRow("�������͸� Ÿ�̸� ����", "", true, new string[] { 
      
            "MONITOR_REFRESH_TIME"
     
            });

            acVerticalGrid1.AddTextEdit("SCROLLING_TIME", "�����ð�(��)", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NUMERIC);

            acVerticalGrid1.AddCategoryRow("��ũ�Ѹ� Ÿ�̸� ����", "", true, new string[] {

            "SCROLLING_TIME"

            });



            //acVerticalGrid1.AddTextEdit("NOTIFY_REFRESH_TIME", "���Žð�(��)", "7QFY2GCJ", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NUMERIC);


            //acVerticalGrid1.AddCategoryRow("�˸�", "BKPRD7Y2", true, new string[] { 
            //"NOTIFY_REFRESH_TIME"
            //});

            //acVerticalGrid1.AddTextEdit("PROC_GOAL", "�����ҷ� ��ǥ(PPM)", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);
            //acVerticalGrid1.AddTextEdit("DUE_GOAL", "��ǰ�ҷ� ��ǥ(PPM)", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);
            //acVerticalGrid1.AddTextEdit("Q_COST_GOAL", "Q-COST ��ǥ(%)", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);
            //acVerticalGrid1.AddTextEdit("P_A_COST_GOAL", "P-COST + A-COST ��ǥ(%)", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);
            //acVerticalGrid1.AddTextEdit("F_COST_GOAL", "F-COST ��ǥ(%)", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);

            //acVerticalGrid1.AddCategoryRow("�ҷ� ��ǥ ����", "", false, new string[] {
            //"PROC_GOAL"
            //,"DUE_GOAL"
            //,"Q_COST_GOAL"
            //,"P_A_COST_GOAL"
            //,"F_COST_GOAL"
            //});


            acVerticalGrid1.AddColorEdit("APP_STATE_PROG", "����", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);
            acVerticalGrid1.AddColorEdit("APP_STATE_OK", "����", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);
            acVerticalGrid1.AddColorEdit("APP_STATE_DENY", "�ݷ�", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);
           
            acVerticalGrid1.AddCategoryRow("���� ���º� ����", "", false, new string[] {
            "APP_STATE_PROG"
            ,"APP_STATE_OK"
            ,"APP_STATE_DENY"
             });



            acVerticalGrid1.AddTextEdit("SPEC_KEYCHAR_CIRCLE", "����� ����", "KLPQI82Y", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);
            acVerticalGrid1.AddTextEdit("SPEC_KEYCHAR_HEXA", "����ü ����", "T855PH0H", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);
            acVerticalGrid1.AddTextEdit("SPEC_KEYCHAR_X", "���� ����", "28AF2N09", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);

            acVerticalGrid1.AddCategoryRow("��Ÿ", "9T63A9BA", true, new string[] { 
            "SPEC_KEYCHAR_CIRCLE"
            ,"SPEC_KEYCHAR_HEXA"
            ,"SPEC_KEYCHAR_X"                                   
            });

            acVerticalGrid1.AddTextEdit("WEB_API_KEY_HOLIDAY", "������ ����", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);

            acVerticalGrid1.AddCategoryRow("Web Api Ű", "", false, new string[] {
            "WEB_API_KEY_HOLIDAY"
            });


            acVerticalGrid1.AddDateEdit("ACCOUNT_DATE", "ùȸ����", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Center, true, true, acVerticalGrid.emDateMask.SHORT_DATE);
            acVerticalGrid1.AddDateEdit("TARGET_DATE", "�����(��)", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Center, true, true, acVerticalGrid.emDateMask.SHORT_DATE);
            acVerticalGrid1.AddDateEdit("ENFOR_DATE", "������", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Center, true, true, acVerticalGrid.emDateMask.SHORT_DATE);

            acVerticalGrid1.AddCategoryRow("�������", "", false, new string[] {
            "ACCOUNT_DATE"
            ,"TARGET_DATE"
            ,"ENFOR_DATE"
            });

            acVerticalGrid1.AddCheckEdit("PWD_POLICY_USE", "��й�ȣ ��å ���", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emCheckEditDataType._STRING);
            acVerticalGrid1.AddTextEdit("PWD_CHANGE_PERIOD", "��й�ȣ ���� �ֱ�(��)", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NUMERIC);
            acVerticalGrid1.AddTextEdit("PWD_CHANGE_REMAIN_DAY", "��й�ȣ ���� ��� �ܿ���", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NUMERIC);
            acVerticalGrid1.AddTextEdit("PWD_FAIL_LIMITED_CNT", "��й�ȣ ���� ���� ��", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NUMERIC);
            acVerticalGrid1.AddTextEdit("PASSWORD_LENGTH", "��й�ȣ ����", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NUMERIC);

            acVerticalGrid1.AddCategoryRow("�α��� ����", "", false, new string[] {
                "PWD_POLICY_USE",
                "PWD_CHANGE_PERIOD",
                "PWD_CHANGE_REMAIN_DAY",
                "PWD_FAIL_LIMITED_CNT",
                "PASSWORD_LENGTH"
            });

            acVerticalGrid1.AddTextEdit("DRAW_FILE_DIR", "���� ���� ���", "", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);
            acVerticalGrid1.AddTextEdit("DRAW_FILE_REMOVE_DIR", "���� ���� ���� ���", "", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);
            acVerticalGrid1.AddTextEdit("DRAW_FILE_DIR_ID", "���� ���� ��� ID", "", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);
            acVerticalGrid1.AddTextEdit("DRAW_FILE_DIR_PW", "���� ���� ��� PW", "", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.PW);

            acVerticalGrid1.AddCategoryRow("�������̽� ����", "", false, new string[] {
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
            //����

            acVerticalGrid1.DataBind(acInfo.SysConfig.GetSysConfigRowTableByServer().Rows[0]);

            base.SetLog(QBiz.emExecuteType.REFRESH);

        }


        private void barItemSearch_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //��ȸ

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
         
            //����

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

