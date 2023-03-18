using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

using ControlManager;
using CodeHelperManager;
using BizManager;


namespace SYS
{
    public sealed partial class SYS04D_M0A : BaseMenu
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

        public SYS04D_M0A()
        {
            InitializeComponent();

            acGridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(acGridView1_FocusedRowChanged);

            acGridView1.CustomColumnSort += new DevExpress.XtraGrid.Views.Base.CustomColumnSortEventHandler(acGridView1_CustomColumnSort);

            acGridView1.CustomDrawGroupRow += new DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventHandler(acGridView1_CustomDrawGroupRow);

         



        }

        void acGridView1_CustomDrawGroupRow(object sender, DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventArgs e)
        {
            acGridView view = sender as acGridView;

            GridGroupRowInfo info = e.Info as GridGroupRowInfo;

            info.GroupText = info.Column.RealColumnEdit.GetDisplayText(info.EditValue);
        }

        void acGridView1_CustomColumnSort(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnSortEventArgs e)
        {
            acGridView view = sender as acGridView;

            int val1 = 0;
            int val2 = 0;

            switch (e.Column.FieldName)
            {

                case "MENU_PARENT_NAME":

                    val1 = view.GetListSourceRowCellValue(e.ListSourceRowIndex1, "MENU_SEQ").toInt();
                    val2 = view.GetListSourceRowCellValue(e.ListSourceRowIndex2, "MENU_SEQ").toInt();


                    e.Result = val1 > val2 ? 1 : val1 == val2 ? 0 : -1;

                    if (e.Result == 0)
                    {

                        e.Handled = false;
                    }
                    else
                    {
                        e.Handled = true;
                    }


                    break;

            }
        }

        void acGridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {

            try
            {
                if (acGridView1.ValidFocusRowHandle() == false)
                {
                    return;
                }


                DataRow focusRow = acGridView1.GetFocusedDataRow();

                acVerticalGrid1.ClearRows();

                string menuCode = focusRow["MENU_CODE"].toStringEmpty();
                string menuName = focusRow["MENU_NAME"].ToString();

                switch (menuCode)
                {

                    case "PLN21A":
                        {

                            //Excel 데이터 가져오기-표준공정

                            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:SHEET", "시트", "LBG894M9", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);

                            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:STARTROW", "시작행", "R309968V", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NUMERIC);

                            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:PART_CODE", "품목코드", "41202", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:PART_NAME", "품목명", "41202", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:PART_LTYPE", "대분류", "41202", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:P_PART_CODE", "모품목코드", "40308", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:P_PART_NAME", "모품목명", "40308", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:MAT_CODE", "소재코드", "40308", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:MAT_NAME", "소재명", "40308", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:PART_QTY", "수량", "40308", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                            acVerticalGrid1.AddCategoryRow("Excel 데이터 가져오기", "OUZTPLY1", true, new string[] {
                             "EXCEL_IMPORT:SHEET"
                            ,"EXCEL_IMPORT:STARTROW"
                            ,"EXCEL_IMPORT:PART_CODE"
                            ,"EXCEL_IMPORT:PART_NAME"
                            ,"EXCEL_IMPORT:PART_LTYPE"
                            ,"EXCEL_IMPORT:P_PART_CODE"
                            ,"EXCEL_IMPORT:P_PART_NAME"
                            ,"EXCEL_IMPORT:MAT_CODE"
                            ,"EXCEL_IMPORT:MAT_NAME"
                            ,"EXCEL_IMPORT:PART_QTY"            
                            });
                        }

                        break;

                    case "QCT02A":
                        {

                            //Excel 데이터 가져오기-표준공정

                            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:SHEET", "시트", "LBG894M9", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);

                            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:STARTROW", "시작행", "R309968V", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NUMERIC);

                            //acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:INS_LOC", "구분", "41162", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:INS_NAME", "검사명", "41202", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:INS_VALUE", "내역", "40308", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);


                            acVerticalGrid1.AddCategoryRow("Excel 데이터 가져오기", "OUZTPLY1", true, new string[] {
                             "EXCEL_IMPORT:SHEET"
                            ,"EXCEL_IMPORT:STARTROW"
                            ,"EXCEL_IMPORT:INS_NAME"
                            ,"EXCEL_IMPORT:INS_VALUE"      
                            });
                        }

                        break;


                    case "WOR09A":
                        {

                            //Excel 데이터 가져오기-표준공정

                            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:SHEET", "시트", "LBG894M9", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);

                            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:STARTROW", "시작행", "R309968V", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NUMERIC);

                            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:WORK_DATE", "근무일자", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:ORG_NAME", "조직", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:EMP_CODE", "사원ID", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:EMP_NAME", "이름", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:EMP_TITLE", "직급", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:WORK_START_TIME", "출근시간", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:WORK_END_TIME", "퇴근시간", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:WORK_START_TYPE", "출근판정", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:WORK_END_TYPE", "퇴근판정", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:WORK_TIME", "신제근무시간", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:SCOMMENT", "비고", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                            acVerticalGrid1.AddCategoryRow("Excel 데이터 가져오기", "OUZTPLY1", true, new string[] {
                             "EXCEL_IMPORT:SHEET"
                            ,"EXCEL_IMPORT:STARTROW"
                            ,"EXCEL_IMPORT:WORK_DATE"
                            ,"EXCEL_IMPORT:ORG_NAME"
                            ,"EXCEL_IMPORT:EMP_CODE"
                            ,"EXCEL_IMPORT:EMP_NAME"
                            ,"EXCEL_IMPORT:EMP_TITLE"
                            ,"EXCEL_IMPORT:WORK_START_TIME"
                            ,"EXCEL_IMPORT:WORK_END_TIME"
                            ,"EXCEL_IMPORT:WORK_START_TYPE"
                            ,"EXCEL_IMPORT:WORK_END_TYPE"
                            ,"EXCEL_IMPORT:WORK_TIME"
                            ,"EXCEL_IMPORT:SCOMMENT"
                            });
                        }

                        break;

                        //case "STD02A":
                        //    {
                        //        //표준부품

                        //        //Excel 데이터 가져오기-표준부품
                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:SHEET", "시트", "LBG894M9", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:STARTROW", "시작행", "R309968V", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NUMERIC);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:PART_CODE", "부품코드", "40239", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:PART_NAME", "부품명", "40234", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:STD_PT_NUM", "품번", "40743", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:MAT_LTYPE", "대분류", "40132", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:MAT_MTYPE", "중분류", "40630", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:MAT_STYPE", "소분류", "40338", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:PART_ENAME", "부품명(영문)", "40235", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:PART_PRODTYPE", "부품제작구분", "40238", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:MAT_UNIT", "단위", "40123", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:STK_MNG", "재고관리", "F0A4HGPZ", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:STK_LOCATION", "창고", "NO1T1YEG", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:SAFE_STK_QTY", "안전재고수량", "SJVKEWA8", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);



                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:SPEC_TYPE", "규격입력형태", "42540", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:MAT_SPEC", "소재사양", "42544", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:MAT_SPEC1", "완성사양", "42545", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);


                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:AUTO_CREATE", "자동생성", "9ICKPDNH", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:AUTO_MARGIN", "자동여유사양", "0DRK00FJ", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:AUTO_MARGIN_SPEC", "여유사양", "1AW7AFGL", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);


                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:LOAD_FLAG", "BOP 부품", "M920A2XO", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:SCH_METHOD", "스케줄 방법", "42462", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:MAT_TYPE", "자재형태", "N05MMEKM", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);


                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:MAIN_VND", "기본 거래처", "UHQZT510", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:MAT_QLTY", "재질", "7QEYM43V", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:INS_FLAG", "입고검사여부", "42560", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);


                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:MAT_COST", "단가", "40121", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:ACT_CODE", "회계계정", "42569", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:PART_SEQ", "표시순서", "40723", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:SCOMMENT", "비고", "ARYZ726K", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);



                        //        acVerticalGrid1.AddCategoryRow("Excel 데이터 가져오기", "OUZTPLY1", true, new string[] { 
                        //        "EXCEL_IMPORT:SHEET"
                        //        ,"EXCEL_IMPORT:STARTROW"
                        //        ,"EXCEL_IMPORT:PART_CODE"
                        //        ,"EXCEL_IMPORT:PART_NAME"
                        //        ,"EXCEL_IMPORT:STD_PT_NUM"
                        //        ,"EXCEL_IMPORT:MAT_LTYPE"
                        //        ,"EXCEL_IMPORT:MAT_MTYPE"
                        //        ,"EXCEL_IMPORT:MAT_STYPE"
                        //        ,"EXCEL_IMPORT:PART_ENAME"
                        //        ,"EXCEL_IMPORT:PART_PRODTYPE"
                        //        ,"EXCEL_IMPORT:MAT_UNIT"
                        //        ,"EXCEL_IMPORT:STK_MNG"
                        //        ,"EXCEL_IMPORT:STK_LOCATION"
                        //        ,"EXCEL_IMPORT:SAFE_STK_QTY"
                        //        ,"EXCEL_IMPORT:SPEC_TYPE"
                        //        ,"EXCEL_IMPORT:MAT_SPEC"
                        //        ,"EXCEL_IMPORT:MAT_SPEC1"
                        //        ,"EXCEL_IMPORT:AUTO_CREATE"
                        //        ,"EXCEL_IMPORT:AUTO_MARGIN"
                        //        ,"EXCEL_IMPORT:AUTO_MARGIN_SPEC"
                        //        ,"EXCEL_IMPORT:LOAD_FLAG"
                        //        ,"EXCEL_IMPORT:SCH_METHOD"
                        //        ,"EXCEL_IMPORT:MAT_TYPE"
                        //        ,"EXCEL_IMPORT:MAIN_VND"
                        //        ,"EXCEL_IMPORT:MAT_QLTY"
                        //        ,"EXCEL_IMPORT:INS_FLAG"
                        //        ,"EXCEL_IMPORT:MAT_COST"
                        //        ,"EXCEL_IMPORT:ACT_CODE"
                        //        ,"EXCEL_IMPORT:SCOMMENT"
                        //        ,"EXCEL_IMPORT:PART_SEQ"
                        //        });

                        //    }

                        //    break;


                        //case "STD04A":
                        //    {


                        //        //Excel 데이터 가져오기-표준설비
                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:SHEET", "시트", "LBG894M9", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:STARTROW", "시작행", "R309968V", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NUMERIC);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:MC_CODE", "설비코드", "41162", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:MC_NAME", "설비명", "41202", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:MC_GROUP", "설비그룹", "40308", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:MC_MODEL", "실모델명", "40400", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);


                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:MC_AUTOMATED", "무인가공", "40973", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:MC_OS", "외부설비", "40974", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:MC_MGT_FLAG", "부하 관리대상", "40065", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);


                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:IS_OPERATE_STATE", "가동현황표시", "SR3IF2SN", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);


                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:IS_MULTI_START", "다중작업지시 동시진행", "MQBVM2AJ", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:MULTI_START_DIV", "다중작업지시 동시진행시 실적분할", "HTHN5WFV", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);


                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:MC_OPEN_DATE", "유효시작일", "40477", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:MC_CLOSE_DATE", "유효종료일", "40478", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:MAIN_EMP", "담당자", "40127", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:CPROC_CODE", "임률", "40505", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:MC_SEQ", "표시순서", "40723", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);


                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:IS_SIGNAL", "신호취득여부", "V4OOUWJC", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:PLC_IP", "신호취득용IP", "42557", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:MC_IP", "설비IP", "42556", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:FTP_PORT", "FTP 포트", "881W45YM", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:FTP_DIR", "FTP 디렉토리", "EU47YV71", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:FTP_USER", "FTP 계정", "X688UUTM", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:FTP_USER_PW", "FTP 계정암호", "HUQ6N8T3", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);


                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:SCOMMENT", "비고", "ARYZ726K", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);


                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:MON_TIME", "작업시간(월)", "I47BA44S", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:TUE_TIME", "작업시간(화)", "IC8OOHO3", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:WED_TIME", "작업시간(수)", "6CDZQQ27", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:THR_TIME", "작업시간(목)", "05DIK1H8", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:FRI_TIME", "작업시간(금)", "LSHZOU1R", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:SAT_TIME", "작업시간(토)", "58CX8M4B", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:SUN_TIME", "작업시간(일)", "J01ZZYP7", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);


                        //        acVerticalGrid1.AddCategoryRow("Excel 데이터 가져오기", "OUZTPLY1", true, new string[] { 
                        //        "EXCEL_IMPORT:SHEET"
                        //        ,"EXCEL_IMPORT:STARTROW"
                        //        ,"EXCEL_IMPORT:MC_CODE"
                        //        ,"EXCEL_IMPORT:MC_NAME"
                        //        ,"EXCEL_IMPORT:MC_GROUP"
                        //        ,"EXCEL_IMPORT:MC_MODEL"
                        //        ,"EXCEL_IMPORT:MC_AUTOMATED"
                        //        ,"EXCEL_IMPORT:MC_OS"
                        //        ,"EXCEL_IMPORT:MC_MGT_FLAG"
                        //        ,"EXCEL_IMPORT:IS_MULTI_START"
                        //        ,"EXCEL_IMPORT:MULTI_START_DIV"
                        //        ,"EXCEL_IMPORT:IS_OPERATE_STATE"
                        //        ,"EXCEL_IMPORT:MC_OPEN_DATE"
                        //        ,"EXCEL_IMPORT:MC_CLOSE_DATE"
                        //        ,"EXCEL_IMPORT:MAIN_EMP"
                        //        ,"EXCEL_IMPORT:CPROC_CODE"
                        //        ,"EXCEL_IMPORT:MC_SEQ"
                        //        ,"EXCEL_IMPORT:IS_SIGNAL"
                        //        ,"EXCEL_IMPORT:PLC_IP"
                        //        ,"EXCEL_IMPORT:MC_IP"
                        //        ,"EXCEL_IMPORT:FTP_PORT"
                        //        ,"EXCEL_IMPORT:FTP_DIR"
                        //        ,"EXCEL_IMPORT:FTP_USER"
                        //        ,"EXCEL_IMPORT:FTP_USER_PW"
                        //        ,"EXCEL_IMPORT:SCOMMENT"
                        //        ,"EXCEL_IMPORT:MON_TIME"
                        //        ,"EXCEL_IMPORT:TUE_TIME"
                        //        ,"EXCEL_IMPORT:WED_TIME"
                        //        ,"EXCEL_IMPORT:THR_TIME"
                        //        ,"EXCEL_IMPORT:FRI_TIME"
                        //        ,"EXCEL_IMPORT:SAT_TIME"
                        //        ,"EXCEL_IMPORT:SUN_TIME"
                        //        });

                        //    }

                        //    break;

                        //case "STD05A":
                        //    {


                        //        //Excel 데이터 가져오기-거래처
                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:SHEET", "시트", "LBG894M9", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:STARTROW", "시작행", "R309968V", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NUMERIC);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:VEN_CODE", "거래처코드", "40957", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:VEN_NAME", "거래처명", "40956", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:VEN_TYPE", "거래처 형태", "6OAMFTNJ", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:VEN_CAT_CODE", "거래처 분류", "U48S66C9", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:VEN_PRODUCTS", "취급품목", "40683", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:VEN_CEO", "대표자명", "40139", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:VEN_BIZ_NO", "사업자등록번호", "40256", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:VEN_ID_NO", "법인등록번호", "41006", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:VEN_BANK", "거래은행", "40022", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:VEN_BANK_NO", "계좌번호", "E4T9XCVC", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:VEN_COUNTRY", "국가", "40074", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:VEN_START_DATE", "거래시작일", "40020", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:VEN_CREDIT", "신용등급", "40396", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:VEN_ZIP", "우편번호", "40455", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:VEN_ADDRESS", "주소", "40626", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:VEN_TEL", "전화번호", "WCO6Q0OP", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:VEN_FAX", "팩스", "40713", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:VEN_EMAIL", "E-Mail", "40790", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:VEN_CHARGE_EMP", "담당자", "40127", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:VEN_CHARGE_TEL", "담당자 전화번호", "40128", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:VEN_CHARGE_HP", "담당자 휴대폰", "40129", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:SCOMMENT", "비고", "ARYZ726K", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);



                        //        acVerticalGrid1.AddCategoryRow("Excel 데이터 가져오기", "OUZTPLY1", true, new string[] { 
                        //        "EXCEL_IMPORT:SHEET"
                        //        ,"EXCEL_IMPORT:STARTROW"
                        //        ,"EXCEL_IMPORT:VEN_CODE"
                        //        ,"EXCEL_IMPORT:VEN_NAME"
                        //        ,"EXCEL_IMPORT:VEN_TYPE"
                        //        ,"EXCEL_IMPORT:VEN_CAT_CODE"
                        //        ,"EXCEL_IMPORT:VEN_PRODUCTS"
                        //        ,"EXCEL_IMPORT:VEN_CEO"
                        //        ,"EXCEL_IMPORT:VEN_BIZ_NO"
                        //        ,"EXCEL_IMPORT:VEN_ID_NO"
                        //        ,"EXCEL_IMPORT:VEN_BANK"
                        //        ,"EXCEL_IMPORT:VEN_BANK_NO"
                        //        ,"EXCEL_IMPORT:VEN_COUNTRY"
                        //        ,"EXCEL_IMPORT:VEN_START_DATE"
                        //        ,"EXCEL_IMPORT:VEN_CREDIT"
                        //        ,"EXCEL_IMPORT:VEN_ZIP"
                        //        ,"EXCEL_IMPORT:VEN_ADDRESS"
                        //        ,"EXCEL_IMPORT:VEN_TEL"
                        //        ,"EXCEL_IMPORT:VEN_FAX"
                        //        ,"EXCEL_IMPORT:VEN_EMAIL"
                        //        ,"EXCEL_IMPORT:VEN_CHARGE_EMP"
                        //        ,"EXCEL_IMPORT:VEN_CHARGE_TEL"
                        //        ,"EXCEL_IMPORT:VEN_CHARGE_HP"
                        //        ,"EXCEL_IMPORT:SCOMMENT"
                        //        });

                        //    }

                        //    break;

                        //case "STD07A":
                        //    {


                        //        //Excel 데이터 가져오기-표준공구

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:SHEET", "시트", "LBG894M9", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:STARTROW", "시작행", "R309968V", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NUMERIC);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:TL_CODE", "공구코드", "836KV66Y", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:TL_NAME", "공구명", "06LAUCR8", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:TL_TYPE", "공구형태", "LKGXVQFX", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:IS_MC_TOOL", "설비장착공구", "GSPAJEZW", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);


                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:TL_LTYPE", "공구 대분류", "UD9RQ4VO", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:TL_MTYPE", "공구 중분류", "YEPCM8Q9", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:TL_STYPE", "공구 소분류", "Q8YT0F8H", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:TL_SPEC", "공구사양", "43Q908E3", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:STK_LOCATION", "창고", "NO1T1YEG", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);


                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:SAFE_STK_QTY", "안전재고수량", "SJVKEWA8", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);


                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:TL_MAKER", "제작사", "9HDUX97V", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:TL_UNITCOST", "단가", "40121", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:TL_UNIT", "단위", "40123", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:MAIN_VND", "기본 거래처", "UHQZT510", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:INS_FLAG", "입고검사여부", "42560", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:ACT_CODE", "회계계정", "42569", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:SCOMMENT", "비고", "ARYZ726K", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);


                        //        acVerticalGrid1.AddCategoryRow("Excel 데이터 가져오기", "OUZTPLY1", true, new string[] { 
                        //        "EXCEL_IMPORT:SHEET"
                        //        ,"EXCEL_IMPORT:STARTROW"
                        //        ,"EXCEL_IMPORT:TL_CODE"
                        //        ,"EXCEL_IMPORT:TL_NAME"
                        //        ,"EXCEL_IMPORT:TL_TYPE"
                        //        ,"EXCEL_IMPORT:IS_MC_TOOL"
                        //        ,"EXCEL_IMPORT:TL_LTYPE"
                        //        ,"EXCEL_IMPORT:TL_MTYPE"
                        //        ,"EXCEL_IMPORT:TL_STYPE"
                        //        ,"EXCEL_IMPORT:TL_SPEC"
                        //        ,"EXCEL_IMPORT:STK_LOCATION"
                        //        ,"EXCEL_IMPORT:SAFE_STK_QTY"
                        //        ,"EXCEL_IMPORT:TL_MAKER"
                        //        ,"EXCEL_IMPORT:TL_UNITCOST"
                        //        ,"EXCEL_IMPORT:TL_UNIT"
                        //        ,"EXCEL_IMPORT:MAIN_VND"
                        //        ,"EXCEL_IMPORT:INS_FLAG"
                        //        ,"EXCEL_IMPORT:ACT_CODE"
                        //        ,"EXCEL_IMPORT:SCOMMENT"
                        //        });

                        //    }
                        //    break;

                        //case "STD13A":
                        //    {



                        //        //Excel 데이터 가져오기-조직/사원

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:SHEET", "시트", "LBG894M9", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT::STARTROW", "시작행", "R309968V", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NUMERIC);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT::ORG_CODE", "부서", "40221", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT::EMP_CODE", "사원코드", "UV9LGK3D", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT::EMP_NAME", "사원명", "40266", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT::EMP_TYPE", "사원형태", "U2V6VABY", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT::EMP_TITLE", "직책", "72MOO4VJ", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT::CPROC_CODE", "임률", "40505", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT::USRGRP_CODE", "사용자 그룹", "40263", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT::MOBILE_PHONE", "휴대폰", "0SRN1JQ9", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT::EMAIL", "E-Mail", "40790", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT::EMP_SEQ", "표시순서", "40723", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);


                        //        acVerticalGrid1.AddCategoryRow("Excel 데이터 가져오기", "OUZTPLY1", true, new string[] { 
                        //        "EXCEL_IMPORT:SHEET"
                        //        ,"EXCEL_IMPORT::STARTROW"
                        //        ,"EXCEL_IMPORT::ORG_CODE"
                        //        ,"EXCEL_IMPORT::EMP_CODE"
                        //        ,"EXCEL_IMPORT::EMP_NAME"
                        //        ,"EXCEL_IMPORT::EMP_TYPE"
                        //        ,"EXCEL_IMPORT::EMP_TITLE"
                        //        ,"EXCEL_IMPORT::CPROC_CODE"
                        //        ,"EXCEL_IMPORT::USRGRP_CODE"
                        //        ,"EXCEL_IMPORT::MOBILE_PHONE"
                        //        ,"EXCEL_IMPORT::EMAIL"
                        //        ,"EXCEL_IMPORT::EMP_SEQ"
                        //        });

                        //    }

                        //    break;


                        //case "STD26A":
                        //    {


                        //        //Excel 데이터 가져오기-표준재질

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:SHEET", "시트", "LBG894M9", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);


                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:STARTROW", "시작행", "R309968V", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NUMERIC);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:MQLTY_CODE", "재질코드", "QGD6SY0U", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:MQLTY_NAME", "재질명", "40572", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:MQLTY_WEIGHT", "비중", "40248", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:UNIT_CONVERT_VALUE", "단위환산값", "VRR6Q9XZ", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:SCOMMENT", "비고", "ARYZ726K", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);


                        //        acVerticalGrid1.AddCategoryRow("Excel 데이터 가져오기", "OUZTPLY1", true, new string[] { 
                        //        "EXCEL_IMPORT:SHEET"
                        //        ,"EXCEL_IMPORT:STARTROW"
                        //        ,"EXCEL_IMPORT:MQLTY_CODE"
                        //        ,"EXCEL_IMPORT:MQLTY_NAME"
                        //        ,"EXCEL_IMPORT:MQLTY_WEIGHT"
                        //        ,"EXCEL_IMPORT:UNIT_CONVERT_VALUE"
                        //        ,"EXCEL_IMPORT:SCOMMENT"
                        //        });

                        //    }
                        //    break;


                        //case "PLN01A":
                        //    {


                        //        //재질별 여유 사양 적용

                        //        acVerticalGrid1.AddTextEdit("QLTY:AUTO_MARGIN_RND_UN30", "환봉_압연", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);

                        //        acVerticalGrid1.AddTextEdit("QLTY:AUTO_MARGIN_RND_UP30", "환봉_단조", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);

                        //        acVerticalGrid1.AddTextEdit("QLTY:AUTO_MARGIN_HEXA", "육면체", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);

                        //        acVerticalGrid1.AddCategoryRow("사양별 여유사양 설정", "", false, new string[] { 
                        //        "QLTY:AUTO_MARGIN_RND_UN30"
                        //        ,"QLTY:AUTO_MARGIN_RND_UP30"
                        //        ,"QLTY:AUTO_MARGIN_HEXA"
                        //        });

                        //    }
                        //    break;

                        //case "POP05A":
                        //    {


                        //        //Excel 데이터 가져오기-공구리스트

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:SHEET", "시트", "LBG894M9", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);


                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:STARTROW", "시작행", "R309968V", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NUMERIC);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:TL_CODE", "공구코드", "836KV66Y", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:TL_NUM", "공구품번", "2XEVDYLQ", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:TL_TIME","가공시간", "6S5HF69R", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:SCOMMENT", "비고", "ARYZ726K", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);


                        //        acVerticalGrid1.AddCategoryRow("Excel 데이터 가져오기", "OUZTPLY1", true, new string[] { 
                        //        "EXCEL_IMPORT:SHEET"
                        //        ,"EXCEL_IMPORT:STARTROW"
                        //        ,"EXCEL_IMPORT:TL_CODE"
                        //        ,"EXCEL_IMPORT:TL_NUM"
                        //        ,"EXCEL_IMPORT:TL_TIME"
                        //        ,"EXCEL_IMPORT:SCOMMENT"
                        //        });

                        //    }
                        //    break;


                        //case "ORD02A":
                        //    {
                        //        //수주관리

                        //        acVerticalGrid1.AddCheckEdit("AUTO_INDUE_DATE", "내부납기일 자동설정", "5WOR9I9Z", true, "납기일 설정시 자동으로 내부납기일을 설정합니다.", "M8YWZ3IR", true, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emCheckEditDataType._STRING);
                        //        acVerticalGrid1.AddTextEdit("AUTO_INDUE_DATE_DAYS", "내부납기일 자동설정 날짜(일)", "9U8KHDB3", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NUMERIC);

                        //        acVerticalGrid1.AddCategoryRow(menuName, string.Empty, false, new string[] { 
                        //        "AUTO_INDUE_DATE"
                        //        ,"AUTO_INDUE_DATE_DAYS"
                        //        });


                        //    }

                        //    break;

                        //case "ORD02B":
                        //    {
                        //        //금형관리

                        //        acVerticalGrid1.AddCheckEdit("AUTO_INDUE_DATE", "내부납기일 자동설정", "5WOR9I9Z", true, "납기일 설정시 자동으로 내부납기일을 설정합니다.", "M8YWZ3IR", true, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emCheckEditDataType._STRING);
                        //        acVerticalGrid1.AddTextEdit("AUTO_INDUE_DATE_DAYS", "내부납기일 자동설정 날짜(일)", "9U8KHDB3", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NUMERIC);

                        //        acVerticalGrid1.AddCategoryRow(menuName, string.Empty, false, new string[] { 
                        //        "AUTO_INDUE_DATE"
                        //        ,"AUTO_INDUE_DATE_DAYS"
                        //        });


                        //    }

                        //    break;

                        //case "ORD05A":
                        //    {

                        //        acVerticalGrid1.AddColorEdit("PROD_PERIOD_COLOR", "생산기간 색상", "DXLV1T43", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);

                        //        acVerticalGrid1.AddColorEdit("PLN_ACT_LINK_COLOR", "계획실적 연결 선색상", "4T8Y2NB3", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);


                        //        acVerticalGrid1.AddCategoryRow(menuName, string.Empty, false, new string[] { 
                        //        "PROD_PERIOD_COLOR"
                        //        ,"PLN_ACT_LINK_COLOR"
                        //        });

                        //    }

                        //    break;

                        //case "ORD07A":
                        //    {
                        //        acVerticalGrid1.AddTextEdit("EXCEL_PATH", "엑셀양식 경로", "UCO4YAY7", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);

                        //        acVerticalGrid1.AddCategoryRow(menuName, string.Empty, false, new string[] { 
                        //        "EXCEL_PATH"
                        //        });

                        //    }

                        //    break;


                        //case "DES03A":
                        //    {

                        //        acVerticalGrid1.AddColorEdit("PROD_PERIOD_COLOR", "생산기간 색상", "DXLV1T43", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);

                        //        acVerticalGrid1.AddCategoryRow(menuName, string.Empty, false, new string[] { 
                        //        "PROD_PERIOD_COLOR"
                        //        });

                        //    }

                        //    break;


                        //case "PLN02A":
                        //    {

                        //        acVerticalGrid1.AddTextEdit("PROC_DISPLAY_TYPE", "공정 표시형태", "O80PN1MH", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);

                        //        acVerticalGrid1.AddColorEdit("PROC_ORDER_LINE_COLOR", "공정순서 선색상", "BT7RXE2N", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);

                        //        acVerticalGrid1.AddTextEdit("PROC_ORDER_LINE_WIDTH", "공정순서 선굵기", "XM29G9Z8", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NUMERIC);

                        //        acVerticalGrid1.AddColorEdit("SUCC_LINE_COLOR", "조립관계 색상", "ZDL8M6EG", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);

                        //        acVerticalGrid1.AddTextEdit("SUCC_LINE_SELECTED_RADIUS", "조립관계 선택범위", "VNU98R5Y", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);

                        //        acVerticalGrid1.AddColorEdit("SUCC_LINE_SELECTED_COLOR", "조립관계 선택색상", "RMK8HCO4", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);


                        //        acVerticalGrid1.AddCategoryRow(menuName, string.Empty, false, new string[] { 
                        //            "PROC_DISPLAY_TYPE"
                        //            ,"PROC_ORDER_LINE_COLOR"
                        //            ,"PROC_ORDER_LINE_WIDTH"
                        //            ,"SUCC_LINE_COLOR"
                        //            ,"SUCC_LINE_SELECTED_RADIUS"
                        //            ,"SUCC_LINE_SELECTED_COLOR"
                        //        });

                        //    }

                        //    break;

                        //case "PLN04A":
                        //    {
                        //        acVerticalGrid1.AddColorEdit("PROD_PERIOD_COLOR", "생산기간 색상", "DXLV1T43", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);

                        //        acVerticalGrid1.AddColorEdit("PLN_ACT_LINK_COLOR", "계획실적 연결 선색상", "4T8Y2NB3", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);

                        //        acVerticalGrid1.AddTextEdit("SUCC_LINE_WIDTH", "조립관계 선굵기", "UQVLSG89", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NUMERIC);

                        //        acVerticalGrid1.AddColorEdit("PLN_ACT_LINK_COLOR", "계획실적 연결 선색상", "4T8Y2NB3", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);


                        //        acVerticalGrid1.AddTextEdit("PROC_DISPLAY_TYPE", "공정 표시형태", "O80PN1MH", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);

                        //        acVerticalGrid1.AddColorEdit("SCH_PROD_EXPT_DATE_LINE_COLOR", "예상납기일 선색상", "3SH4W1IN", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);


                        //        acVerticalGrid1.AddCategoryRow(menuName, string.Empty, false, new string[] { 
                        //            "PROD_PERIOD_COLOR"
                        //            ,"PLN_ACT_LINK_COLOR"
                        //            ,"SUCC_LINE_WIDTH"
                        //            ,"PLN_ACT_LINK_COLOR"
                        //            ,"PROC_DISPLAY_TYPE"
                        //            ,"SCH_PROD_EXPT_DATE_LINE_COLOR"
                        //        });
                        //    }

                        //    break;


                        //case "PLN06A":
                        //    {
                        //        acVerticalGrid1.AddTextEdit("BOP_TABLE_PROD_DISPLAY_TYPE", "금형 표시형태", "7TGT9ML2", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);

                        //        acVerticalGrid1.AddTextEdit("BOP_TABLE_PLN_DISPLAY_TYPE", "공정 계획표시형태", "DB9DJ6GA", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);

                        //        acVerticalGrid1.AddTextEdit("BOP_TABLE_ACT_DISPLAY_TYPE", "공정 실적표시형태", "Z2XSFIZU", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);


                        //        acVerticalGrid1.AddCategoryRow(menuName, string.Empty, false, new string[] { 
                        //        "BOP_TABLE_PROD_DISPLAY_TYPE"
                        //        ,"BOP_TABLE_PLN_DISPLAY_TYPE"
                        //        ,"BOP_TABLE_ACT_DISPLAY_TYPE"
                        //        });


                        //    }

                        //    break;

                        //case "PLN08A":
                        //    {

                        //        acVerticalGrid1.AddColorEdit("SCH_PROD_NOW_DATE_LINE_COLOR", "현재날짜 선색상", "XW2UX58I", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);

                        //        acVerticalGrid1.AddColorEdit("PROD_PERIOD_COLOR", "생산기간 색상", "DXLV1T43", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);

                        //        acVerticalGrid1.AddColorEdit("PROD_PLN_WO_COLOR", "작업계획 색상", "ETIL8KYR", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);

                        //        acVerticalGrid1.AddColorEdit("PROD_ACT_WO_COLOR", "작업실적 색상", "3J5O71AU", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);


                        //        acVerticalGrid1.AddCategoryRow(menuName, string.Empty, false, new string[] {
                        //        "SCH_PROD_NOW_DATE_LINE_COLOR"
                        //        ,"PROD_PERIOD_COLOR"
                        //        ,"PROD_PLN_WO_COLOR"
                        //        ,"PROD_ACT_WO_COLOR"
                        //        });
                        //    }

                        //    break;



                        //case "PLN09A":
                        //    {


                        //        acVerticalGrid1.AddColorEdit("SCH_PROD_NOW_DATE_LINE_COLOR", "현재날짜 선색상", "XW2UX58I", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);

                        //        acVerticalGrid1.AddColorEdit("SCH_PROD_ORD_DATE_LINE_COLOR", "시작일 선색상", "484KT151", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);

                        //        acVerticalGrid1.AddColorEdit("SCH_PROD_INDUE_DATE_LINE_COLOR", "내부납기일 선색상", "B9AKARMR", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);

                        //        acVerticalGrid1.AddColorEdit("SCH_PROD_DUE_DATE_LINE_COLOR", "납기일 선색상", "YPWA72HO", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);

                        //        acVerticalGrid1.AddColorEdit("SCH_PROD_EXPT_DATE_LINE_COLOR", "예상납기일 선색상", "3SH4W1IN", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);

                        //        acVerticalGrid1.AddColorEdit("SCH_PROD_PUR_DATE_LINE_COLOR", "구매 선색상", "GRHKKGOI", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);

                        //        acVerticalGrid1.AddColorEdit("SUCC_LINE_COLOR", "조립관계 색상", "ZDL8M6EG", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);

                        //        acVerticalGrid1.AddTextEdit("SUCC_LINE_WIDTH", "조립관계 선굵기", "UQVLSG89", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NUMERIC);

                        //        acVerticalGrid1.AddColorEdit("PLN_ACT_LINK_COLOR", "계획실적 연결 선색상", "4T8Y2NB3", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);


                        //        acVerticalGrid1.AddTextEdit("PLN_PROD_DISPLAY_TYPE", "공정 표시형태", "O80PN1MH", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);
                        //        acVerticalGrid1.AddTextEdit("PLN_PROD_OS_DISPLAY_TYPE", "공정외주 표시형태", "E2SL0J4F", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);
                        //        acVerticalGrid1.AddColorEdit("SCH_PROD_ACT_START_DATE_LINE_COLOR", "작업시작일 선색상", "4WRLL1QX", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);


                        //        acVerticalGrid1.AddCategoryRow(menuName, string.Empty, false, new string[] { 
                        //        "SCH_PROD_NOW_DATE_LINE_COLOR"
                        //        ,"SCH_PROD_ORD_DATE_LINE_COLOR"
                        //        ,"SCH_PROD_INDUE_DATE_LINE_COLOR"
                        //        ,"SCH_PROD_DUE_DATE_LINE_COLOR"
                        //        ,"SCH_PROD_EXPT_DATE_LINE_COLOR"
                        //        ,"SCH_PROD_PUR_DATE_LINE_COLOR"
                        //        ,"SUCC_LINE_COLOR"
                        //        ,"SUCC_LINE_WIDTH"
                        //        ,"PLN_ACT_LINK_COLOR"
                        //        ,"PLN_PROD_DISPLAY_TYPE"
                        //        ,"PLN_PROD_OS_DISPLAY_TYPE"
                        //        ,"SCH_PROD_ACT_START_DATE_LINE_COLOR"
                        //        });

                        //    }


                        //    break;


                        //case "PLN14A":
                        //    {
                        //        acVerticalGrid1.AddTextEdit("PLN_MC_DISPLAY_TYPE", "공정 표시형태", "O80PN1MH", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);

                        //        acVerticalGrid1.AddTextEdit("PLN_MC_IDLE_DISPLAY_TYPE", "비가동내용 표시형태", "YH4G5C9Q", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);

                        //        acVerticalGrid1.AddTextEdit("PLN_MC_OS_DISPLAY_TYPE", "공정외주 표시형태", "E2SL0J4F", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);


                        //        acVerticalGrid1.AddCategoryRow(menuName, string.Empty, false, new string[] { 
                        //        "PLN_MC_DISPLAY_TYPE"
                        //        ,"PLN_MC_IDLE_DISPLAY_TYPE"
                        //        ,"PLN_MC_OS_DISPLAY_TYPE"
                        //        });

                        //    }

                        //    break;


                        //case "DES01A":
                        //    {

                        //        //Excel 데이터 가져오기-부품리스트
                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:SHEET", "시트", "LBG894M9", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:STARTROW", "시작행", "R309968V", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NUMERIC);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:P_PART_CODE", "모부품코드", "42562", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:P_PART_NUM", "모품번", "42564", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:PART_CODE", "부품코드", "40239", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:PART_NUM", "품번", "40743", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:PTNAME", "부품명", "40234", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:PART_QLTY", "재질코드", "QGD6SY0U", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:PART_SPEC", "소재사양", "42544", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:PART_SPEC1", "완성사양", "42545", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:PART_QTY", "수량", "40345", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:SCOMMENT", "비고", "ARYZ726K", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:DRAW_NO", "도면번호", "40145", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);




                        //        acVerticalGrid1.AddCategoryRow("Excel 데이터 가져오기", "OUZTPLY1", true, new string[] { 
                        //        "EXCEL_IMPORT:SHEET"
                        //        ,"EXCEL_IMPORT:STARTROW"
                        //        ,"EXCEL_IMPORT:P_PART_CODE"
                        //        ,"EXCEL_IMPORT:P_PART_NUM"
                        //        ,"EXCEL_IMPORT:PART_CODE"
                        //        ,"EXCEL_IMPORT:PART_NUM"
                        //        ,"EXCEL_IMPORT:PTNAME"
                        //        ,"EXCEL_IMPORT:PART_QLTY"
                        //        ,"EXCEL_IMPORT:PART_SPEC"
                        //        ,"EXCEL_IMPORT:PART_SPEC1"
                        //        ,"EXCEL_IMPORT:PART_QTY"
                        //        ,"EXCEL_IMPORT:SCOMMENT"
                        //        ,"EXCEL_IMPORT:DRAW_NO"
                        //        });


                        //    }

                        //    break;

                        //case "POP06A":
                        //    {


                        //        acVerticalGrid1.AddTextEdit("MC_STATUS_RUN_CONTENTS_DISPLAY_TYPE", "가동내용 표시형태", "4JSIRU39", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);

                        //        acVerticalGrid1.AddTextEdit("MC_STATUS_IDLE_CONTENTS_DISPLAY_TYPE", "비가동내용 표시형태", "YH4G5C9Q", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);

                        //        acVerticalGrid1.AddTextEdit("MC_STATUS_REFRESH_TIME", "갱신시간(초)", "7QFY2GCJ", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NUMERIC);

                        //        acVerticalGrid1.AddTextEdit("MC_STATUS_PAGE_CHANGE_TIME", "페이지 전환시간(초)", "05TAVNJT", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NUMERIC);

                        //        acVerticalGrid1.AddCategoryRow(menuName, string.Empty, false, new string[] { 
                        //        "MC_STATUS_RUN_CONTENTS_DISPLAY_TYPE"
                        //        ,"MC_STATUS_IDLE_CONTENTS_DISPLAY_TYPE"
                        //        ,"MC_STATUS_REFRESH_TIME"
                        //        ,"MC_STATUS_PAGE_CHANGE_TIME"
                        //        });

                        //    }

                        //    break;


                        //case "PUR01B":
                        //    {
                        //        //자재신청

                        //        acVerticalGrid1.AddCheckEdit("IS_CHANGE_REQ_DATE", "신청일 변경가능", "FWH2A8AO", true, "구매 신청시 신청일 변경가능여부를 설정합니다.", "8ZV4RPRB", true, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emCheckEditDataType._STRING);

                        //        acVerticalGrid1.AddCheckEdit("AUTOAPP_MAT_REQ", "신청 자동승인", "ZLAHAVHG", true, "구매 신청시 자동으로 신청승인됩니다.", "QS9581Q0", true, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emCheckEditDataType._STRING);

                        //        acVerticalGrid1.AddCategoryRow(menuName, string.Empty, false, new string[] { 
                        //          "IS_CHANGE_REQ_DATE"
                        //         ,"AUTOAPP_MAT_REQ"
                        //         });
                        //    }

                        //    break;


                        //case "PUR03B":
                        //    {
                        //        //자재발주

                        //        acVerticalGrid1.AddCheckEdit("IS_CHANGE_BALJU_DATE", "발주일 변경가능", "BMFRUSY4", true, "구매 발주시 발주일 변경가능여부를 설정합니다.", "U5V6LID4", true, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emCheckEditDataType._STRING);

                        //        acVerticalGrid1.AddCheckEdit("AUTOAPP_MAT_BAL", "발주 자동승인", "Y2YSTBFC", true, "발주시 자동으로 발주승인됩니다.", "4V35L0Q6", true, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emCheckEditDataType._STRING);

                        //        acVerticalGrid1.AddCheckEdit("IS_INPUT_MINUS_COST", "마이너스 단가 입력허용", "QRDOEUT1", true, "구매 발주시 0 이하의 단가 입력을 허용합니다.", "SY7N9BT0", true, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emCheckEditDataType._STRING);


                        //        acVerticalGrid1.AddTextEdit("EXPENSE_RECENT_LIST_MONTH", "최근 지출결의 내역(개월)", "CT9MWH0U", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NUMERIC);


                        //        acVerticalGrid1.AddCategoryRow(menuName, string.Empty, false, new string[] { 
                        //        "IS_CHANGE_BALJU_DATE"
                        //        ,"AUTOAPP_MAT_BAL"
                        //        ,"IS_INPUT_MINUS_COST"
                        //        ,"EXPENSE_RECENT_LIST_MONTH"
                        //         });
                        //    }

                        //    break;

                        //case "PUR11B":
                        //    {
                        //        //공정외주 신청
                        //        acVerticalGrid1.AddCheckEdit("IS_CHANGE_REQ_DATE", "신청일 변경가능", "FWH2A8AO", true, "구매 신청시 신청일 변경가능여부를 설정합니다.", "8ZV4RPRB", true, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emCheckEditDataType._STRING);

                        //        acVerticalGrid1.AddCheckEdit("AUTOAPP_OUT_REQ", "신청 자동승인", "ZLAHAVHG", true, "구매 신청시 자동으로 신청승인됩니다.", "QS9581Q0", true, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emCheckEditDataType._STRING);

                        //        acVerticalGrid1.AddCategoryRow(menuName, string.Empty, false, new string[] { 
                        //          "IS_CHANGE_REQ_DATE"
                        //         ,"AUTOAPP_OUT_REQ"
                        //         });

                        //    }

                        //    break;

                        //case "PUR13B":
                        //    {
                        //        //공정외주 발주

                        //        acVerticalGrid1.AddCheckEdit("IS_CHANGE_BALJU_DATE", "발주일 변경가능", "BMFRUSY4", true, "구매 발주시 발주일 변경가능여부를 설정합니다.", "U5V6LID4", true, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emCheckEditDataType._STRING);

                        //        acVerticalGrid1.AddCheckEdit("AUTOAPP_OUT_BAL", "발주 자동승인", "Y2YSTBFC", true, "발주시 자동으로 발주승인됩니다.", "4V35L0Q6", true, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emCheckEditDataType._STRING);

                        //        acVerticalGrid1.AddCheckEdit("IS_INPUT_MINUS_COST", "마이너스 단가 입력허용", "QRDOEUT1", true, "구매 발주시 0 이하의 단가 입력을 허용합니다.", "SY7N9BT0", true, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emCheckEditDataType._STRING);

                        //        acVerticalGrid1.AddTextEdit("EXPENSE_RECENT_LIST_MONTH", "최근 지출결의 내역(개월)", "CT9MWH0U", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NUMERIC);


                        //        acVerticalGrid1.AddCategoryRow(menuName, string.Empty, false, new string[] { 
                        //          "IS_CHANGE_BALJU_DATE"
                        //         ,"AUTOAPP_OUT_BAL"
                        //         ,"IS_INPUT_MINUS_COST"
                        //         ,"EXPENSE_RECENT_LIST_MONTH"
                        //         });
                        //    }

                        //    break;


                        //case "PUR21B":
                        //    {
                        //        //세트외주 신청
                        //        acVerticalGrid1.AddCheckEdit("IS_CHANGE_REQ_DATE", "신청일 변경가능", "FWH2A8AO", true, "구매 신청시 신청일 변경가능여부를 설정합니다.", "8ZV4RPRB", true, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emCheckEditDataType._STRING);

                        //        acVerticalGrid1.AddCheckEdit("AUTOAPP_SET_REQ", "신청 자동승인", "ZLAHAVHG", true, "구매 신청시 자동으로 신청승인됩니다.", "QS9581Q0", true, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emCheckEditDataType._STRING);

                        //        acVerticalGrid1.AddCategoryRow(menuName, string.Empty, false, new string[] { 
                        //          "IS_CHANGE_REQ_DATE"
                        //         ,"AUTOAPP_SET_REQ"
                        //         });
                        //    }

                        //    break;

                        //case "PUR22B":
                        //    {
                        //        //세트외주 발주
                        //        acVerticalGrid1.AddCheckEdit("IS_CHANGE_BALJU_DATE", "발주일 변경가능", "BMFRUSY4", true, "구매 발주시 발주일 변경가능여부를 설정합니다.", "U5V6LID4", true, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emCheckEditDataType._STRING);


                        //        acVerticalGrid1.AddCheckEdit("AUTOAPP_SET_BAL", "발주 자동승인", "Y2YSTBFC", true, "발주시 자동으로 발주 승인됩니다.", "4V35L0Q6", true, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emCheckEditDataType._STRING);

                        //        acVerticalGrid1.AddCheckEdit("IS_INPUT_MINUS_COST", "마이너스 단가 입력허용", "QRDOEUT1", true, "구매 발주시 0 이하의 단가 입력을 허용합니다.", "SY7N9BT0", true, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emCheckEditDataType._STRING);


                        //        acVerticalGrid1.AddCategoryRow(menuName, string.Empty, false, new string[] { 
                        //          "IS_CHANGE_BALJU_DATE"
                        //         ,"AUTOAPP_SET_BAL"
                        //         ,"IS_INPUT_MINUS_COST"
                        //         });
                        //    }

                        //    break;


                        //case "PUR07A":
                        //    {
                        //        //공구 신청

                        //        acVerticalGrid1.AddCheckEdit("IS_CHANGE_REQ_DATE", "신청일 변경가능", "FWH2A8AO", true, "구매 신청시 신청일 변경가능여부를 설정합니다.", "8ZV4RPRB", true, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emCheckEditDataType._STRING);

                        //        acVerticalGrid1.AddCheckEdit("AUTOAPP_TOL_REQ", "신청 자동승인", "ZLAHAVHG", true, "구매 신청시 자동으로 신청승인됩니다.", "QS9581Q0", false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emCheckEditDataType._STRING);

                        //        acVerticalGrid1.AddCategoryRow(menuName, string.Empty, false, new string[] { 
                        //          "IS_CHANGE_REQ_DATE"
                        //         ,"AUTOAPP_TOL_REQ"
                        //         });
                        //    }

                        //    break;


                        //case "PUR09A":
                        //    {
                        //        //공구 발주

                        //        acVerticalGrid1.AddCheckEdit("IS_CHANGE_BALJU_DATE", "발주일 변경가능", "BMFRUSY4", true, "구매 발주시 발주일 변경가능여부를 설정합니다.", "U5V6LID4", true, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emCheckEditDataType._STRING);

                        //        acVerticalGrid1.AddCheckEdit("AUTOAPP_TOL_BAL", "발주 자동승인", "Y2YSTBFC", true, "발주시 자동으로 발주 승인됩니다.", "4V35L0Q6", false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emCheckEditDataType._STRING);

                        //        acVerticalGrid1.AddCheckEdit("IS_INPUT_MINUS_COST", "마이너스 단가 입력허용", "QRDOEUT1", true, "구매 발주시 0 이하의 단가 입력을 허용합니다.", "SY7N9BT0", true, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emCheckEditDataType._STRING);

                        //        acVerticalGrid1.AddTextEdit("EXPENSE_RECENT_LIST_MONTH", "최근 지출결의 내역(개월)", "CT9MWH0U", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NUMERIC);


                        //        acVerticalGrid1.AddCategoryRow(menuName, string.Empty, false, new string[] { 
                        //          "IS_CHANGE_BALJU_DATE"
                        //         ,"AUTOAPP_TOL_BAL"
                        //         ,"IS_INPUT_MINUS_COST"
                        //         ,"EXPENSE_RECENT_LIST_MONTH"
                        //         });

                        //    }
                        //    break;

                        //case "PUR05B":
                        //    {
                        //        //입고
                        //        acVerticalGrid1.AddCheckEdit("IS_CHANGE_YPGO_DATE", "입고일 변경가능", "MXH1BFPX", true, "구매 입고시 입고일 변경가능여부를 설정합니다.", "9K1VYOMW", true, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emCheckEditDataType._STRING);


                        //        acVerticalGrid1.AddCategoryRow(menuName, string.Empty, false, new string[] { 
                        //          "IS_CHANGE_YPGO_DATE"
                        //         });

                        //    }

                        //    break;


                        //case "PUR31A":
                        //    {
                        //        //지출결의
                        //        acVerticalGrid1.AddCheckEdit("IS_CHANGE_EXPENSE_DATE", "지출결의일 변경가능", "3FUBH9X5", true, "지출결의일 변경가능여부를 설정합니다.", "P2ULXSQ1", true, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emCheckEditDataType._STRING);

                        //        acVerticalGrid1.AddCheckEdit("AUTOAPP_EXP_MAT", "자재구매 지출결의 자동승인", "VDS5TZRG", true, "자재구매 지출결의시 자동으로 지출결의 승인됩니다.", "5VT8PZWB", true, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emCheckEditDataType._STRING);

                        //        acVerticalGrid1.AddCheckEdit("AUTOAPP_EXP_OUT", "공정외주 지출결의 자동승인", "8W8R9IZ9", true, "공정외주 지출결의시 자동으로 지출결의 승인됩니다.", "CW6WYW9B", true, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emCheckEditDataType._STRING);

                        //        acVerticalGrid1.AddCheckEdit("AUTOAPP_EXP_SET", "세트외주 지출결의 자동승인", "0QG1FM5T", true, "세트외주 지출결의시 자동으로 지출결의 승인됩니다.", "BZJRSYFL", true, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emCheckEditDataType._STRING);

                        //        acVerticalGrid1.AddCheckEdit("AUTOAPP_EXP_TOL", "공구구매 지출결의 자동승인", "L5HAJXBF", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emCheckEditDataType._STRING);

                        //        acVerticalGrid1.AddCategoryRow(menuName, string.Empty, false, new string[] { 
                        //        "IS_CHANGE_EXPENSE_DATE"
                        //        ,"AUTOAPP_EXP_MAT"
                        //        ,"AUTOAPP_EXP_OUT"
                        //        ,"AUTOAPP_EXP_SET"
                        //        ,"AUTOAPP_EXP_TOL"
                        //         });

                        //    }

                        //    break;

                        //case "PUR40A":
                        //    {
                        //        acVerticalGrid1.AddLookUpEdit("REQ_LIST_STATE", "신청서 출력가능 구매상태", "ML7STFRN", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, "S043");

                        //        acVerticalGrid1.AddCategoryRow(menuName, string.Empty, false, new string[] { 
                        //        "REQ_LIST_STATE"
                        //         });

                        //    }

                        //    break;

                        //case "TOL02A":
                        //    {

                        //        acVerticalGrid1.AddCheckEdit("IS_CHANGE_GIVE_DATE", "지급일 변경가능", "WM6XAKJQ", true, "공구 지급시 지급일 변경가능여부를 설정합니다.", "4OWUY1ZB", true, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emCheckEditDataType._STRING);

                        //        acVerticalGrid1.AddCategoryRow(menuName, string.Empty, false, new string[] { 
                        //        "IS_CHANGE_GIVE_DATE"
                        //         });

                        //    }

                        //    break;

                        //case "TOL04A":
                        //    {
                        //        acVerticalGrid1.AddCheckEdit("IS_CHANGE_RETURN_DATE", "반납일 변경가능", "UALDBT1O", true, "공구 반납시 반납일 변경가능여부를 설정합니다.", "RCSN2OIX", true, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emCheckEditDataType._STRING);

                        //        acVerticalGrid1.AddCategoryRow(menuName, string.Empty, false, new string[] { 
                        //        "IS_CHANGE_RETURN_DATE"
                        //         });
                        //    }

                        //    break;


                        //case "TOL06A":
                        //    {
                        //        acVerticalGrid1.AddCheckEdit("IS_CHANGE_DISUSE_DATE", "폐기일 변경가능", "A7TZS19M", true, "공구 폐기시 폐기일 변경가능여부를 설정합니다.", "H6BY5CRQ", true, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emCheckEditDataType._STRING);

                        //        acVerticalGrid1.AddCategoryRow(menuName, string.Empty, false, new string[] { 
                        //        "IS_CHANGE_DISUSE_DATE"
                        //         });
                        //    }

                        //    break;


                }


                acVerticalGrid1.DataBind(acInfo.MenuConfig.GetMenuConfigRowTableByServer(menuCode).Rows[0]);

                acVerticalGrid1.BestFit();

                
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }


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

            acGridView1.GridType = acGridView.emGridType.LIST_SINGLE;

            acGridView1.AddHidden("MENU_CODE", typeof(string));

            acGridView1.AddTextEdit("MENU_PARENT_NAME", "", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("MENU_NAME", "메뉴명", "D6UJPZ3J", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.Columns["MENU_PARENT_NAME"].GroupIndex = 0;
            acGridView1.Columns["MENU_PARENT_NAME"].SortMode = DevExpress.XtraGrid.ColumnSortMode.Custom;


            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("LANG", typeof(String)); //
            paramTable.Columns.Add("IS_MENU", typeof(String)); //
            paramTable.Columns.Add("USE_CONF", typeof(String)); //


            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["LANG"] = acInfo.Lang;
            paramRow["IS_MENU"] = "1";
            paramRow["USE_CONF"] = "1";


            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            DataSet resultSet = BizRun.QBizRun.ExecuteService(this, "CTRL", "CONTROL_MENU_SEARCH", paramSet, "RQSTDT", "");
            //DataSet resultSet = BizRun.QBizRun.ExecuteService(this, "CONTROL_MENU_SEARCH", paramSet, "RQSTDT", "RSLTDT");

            acGridView1.GridControl.DataSource = resultSet.Tables["RSLTDT"];

            acGridView1.ExpandAllGroups();

            base.MenuInit();
        }


        private void barItemSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //저장

            try
            {
                if (acGridView1.ValidFocusRowHandle() == false)
                {
                    return;
                }

                acVerticalGrid1.EndEditor();

                DataRow focusRow = acGridView1.GetFocusedDataRow();


                DataTable data = acVerticalGrid1.CreateParameterTable(true);

                foreach (DataColumn col in data.Columns)
                {

                    acInfo.MenuConfig.SetMenuConfigByServer(focusRow["MENU_CODE"].ToString(), col.ColumnName, data.Rows[0][col.ColumnName].toStringEmpty());


                }

                acVerticalGrid1.ClearValueChanged();


                acInfo.MenuConfig.UpdateMemoryMenuConfig();

                base.SetLog(QBiz.emExecuteType.SAVE);


            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        private void barItemSearch_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                this.Search();

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void Search()
        {
            //갱신
            if (acGridView1.ValidFocusRowHandle() == false)
            {
                return;
            }

            acGridView1.RaiseFocusedRowChanged();

            base.SetLog(QBiz.emExecuteType.REFRESH);

        }


    }
}

