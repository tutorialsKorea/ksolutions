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

                            //Excel ������ ��������-ǥ�ذ���

                            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:SHEET", "��Ʈ", "LBG894M9", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);

                            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:STARTROW", "������", "R309968V", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NUMERIC);

                            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:PART_CODE", "ǰ���ڵ�", "41202", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:PART_NAME", "ǰ���", "41202", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:PART_LTYPE", "��з�", "41202", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:P_PART_CODE", "��ǰ���ڵ�", "40308", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:P_PART_NAME", "��ǰ���", "40308", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:MAT_CODE", "�����ڵ�", "40308", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:MAT_NAME", "�����", "40308", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:PART_QTY", "����", "40308", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                            acVerticalGrid1.AddCategoryRow("Excel ������ ��������", "OUZTPLY1", true, new string[] {
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

                            //Excel ������ ��������-ǥ�ذ���

                            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:SHEET", "��Ʈ", "LBG894M9", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);

                            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:STARTROW", "������", "R309968V", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NUMERIC);

                            //acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:INS_LOC", "����", "41162", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:INS_NAME", "�˻��", "41202", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:INS_VALUE", "����", "40308", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);


                            acVerticalGrid1.AddCategoryRow("Excel ������ ��������", "OUZTPLY1", true, new string[] {
                             "EXCEL_IMPORT:SHEET"
                            ,"EXCEL_IMPORT:STARTROW"
                            ,"EXCEL_IMPORT:INS_NAME"
                            ,"EXCEL_IMPORT:INS_VALUE"      
                            });
                        }

                        break;


                    case "WOR09A":
                        {

                            //Excel ������ ��������-ǥ�ذ���

                            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:SHEET", "��Ʈ", "LBG894M9", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);

                            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:STARTROW", "������", "R309968V", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NUMERIC);

                            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:WORK_DATE", "�ٹ�����", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:ORG_NAME", "����", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:EMP_CODE", "���ID", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:EMP_NAME", "�̸�", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:EMP_TITLE", "����", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:WORK_START_TIME", "��ٽð�", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:WORK_END_TIME", "��ٽð�", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:WORK_START_TYPE", "�������", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:WORK_END_TYPE", "�������", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:WORK_TIME", "�����ٹ��ð�", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                            acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:SCOMMENT", "���", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                            acVerticalGrid1.AddCategoryRow("Excel ������ ��������", "OUZTPLY1", true, new string[] {
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
                        //        //ǥ�غ�ǰ

                        //        //Excel ������ ��������-ǥ�غ�ǰ
                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:SHEET", "��Ʈ", "LBG894M9", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:STARTROW", "������", "R309968V", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NUMERIC);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:PART_CODE", "��ǰ�ڵ�", "40239", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:PART_NAME", "��ǰ��", "40234", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:STD_PT_NUM", "ǰ��", "40743", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:MAT_LTYPE", "��з�", "40132", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:MAT_MTYPE", "�ߺз�", "40630", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:MAT_STYPE", "�Һз�", "40338", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:PART_ENAME", "��ǰ��(����)", "40235", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:PART_PRODTYPE", "��ǰ���۱���", "40238", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:MAT_UNIT", "����", "40123", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:STK_MNG", "������", "F0A4HGPZ", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:STK_LOCATION", "â��", "NO1T1YEG", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:SAFE_STK_QTY", "����������", "SJVKEWA8", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);



                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:SPEC_TYPE", "�԰��Է�����", "42540", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:MAT_SPEC", "������", "42544", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:MAT_SPEC1", "�ϼ����", "42545", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);


                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:AUTO_CREATE", "�ڵ�����", "9ICKPDNH", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:AUTO_MARGIN", "�ڵ��������", "0DRK00FJ", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:AUTO_MARGIN_SPEC", "�������", "1AW7AFGL", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);


                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:LOAD_FLAG", "BOP ��ǰ", "M920A2XO", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:SCH_METHOD", "������ ���", "42462", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:MAT_TYPE", "��������", "N05MMEKM", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);


                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:MAIN_VND", "�⺻ �ŷ�ó", "UHQZT510", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:MAT_QLTY", "����", "7QEYM43V", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:INS_FLAG", "�԰�˻翩��", "42560", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);


                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:MAT_COST", "�ܰ�", "40121", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:ACT_CODE", "ȸ�����", "42569", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:PART_SEQ", "ǥ�ü���", "40723", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:SCOMMENT", "���", "ARYZ726K", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);



                        //        acVerticalGrid1.AddCategoryRow("Excel ������ ��������", "OUZTPLY1", true, new string[] { 
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


                        //        //Excel ������ ��������-ǥ�ؼ���
                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:SHEET", "��Ʈ", "LBG894M9", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:STARTROW", "������", "R309968V", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NUMERIC);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:MC_CODE", "�����ڵ�", "41162", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:MC_NAME", "�����", "41202", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:MC_GROUP", "����׷�", "40308", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:MC_MODEL", "�Ǹ𵨸�", "40400", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);


                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:MC_AUTOMATED", "���ΰ���", "40973", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:MC_OS", "�ܺμ���", "40974", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:MC_MGT_FLAG", "���� �������", "40065", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);


                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:IS_OPERATE_STATE", "������Ȳǥ��", "SR3IF2SN", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);


                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:IS_MULTI_START", "�����۾����� ��������", "MQBVM2AJ", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:MULTI_START_DIV", "�����۾����� ��������� ��������", "HTHN5WFV", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);


                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:MC_OPEN_DATE", "��ȿ������", "40477", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:MC_CLOSE_DATE", "��ȿ������", "40478", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:MAIN_EMP", "�����", "40127", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:CPROC_CODE", "�ӷ�", "40505", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:MC_SEQ", "ǥ�ü���", "40723", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);


                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:IS_SIGNAL", "��ȣ��濩��", "V4OOUWJC", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:PLC_IP", "��ȣ����IP", "42557", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:MC_IP", "����IP", "42556", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:FTP_PORT", "FTP ��Ʈ", "881W45YM", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:FTP_DIR", "FTP ���丮", "EU47YV71", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:FTP_USER", "FTP ����", "X688UUTM", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:FTP_USER_PW", "FTP ������ȣ", "HUQ6N8T3", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);


                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:SCOMMENT", "���", "ARYZ726K", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);


                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:MON_TIME", "�۾��ð�(��)", "I47BA44S", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:TUE_TIME", "�۾��ð�(ȭ)", "IC8OOHO3", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:WED_TIME", "�۾��ð�(��)", "6CDZQQ27", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:THR_TIME", "�۾��ð�(��)", "05DIK1H8", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:FRI_TIME", "�۾��ð�(��)", "LSHZOU1R", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:SAT_TIME", "�۾��ð�(��)", "58CX8M4B", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:SUN_TIME", "�۾��ð�(��)", "J01ZZYP7", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);


                        //        acVerticalGrid1.AddCategoryRow("Excel ������ ��������", "OUZTPLY1", true, new string[] { 
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


                        //        //Excel ������ ��������-�ŷ�ó
                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:SHEET", "��Ʈ", "LBG894M9", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:STARTROW", "������", "R309968V", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NUMERIC);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:VEN_CODE", "�ŷ�ó�ڵ�", "40957", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:VEN_NAME", "�ŷ�ó��", "40956", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:VEN_TYPE", "�ŷ�ó ����", "6OAMFTNJ", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:VEN_CAT_CODE", "�ŷ�ó �з�", "U48S66C9", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:VEN_PRODUCTS", "���ǰ��", "40683", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:VEN_CEO", "��ǥ�ڸ�", "40139", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:VEN_BIZ_NO", "����ڵ�Ϲ�ȣ", "40256", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:VEN_ID_NO", "���ε�Ϲ�ȣ", "41006", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:VEN_BANK", "�ŷ�����", "40022", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:VEN_BANK_NO", "���¹�ȣ", "E4T9XCVC", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:VEN_COUNTRY", "����", "40074", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:VEN_START_DATE", "�ŷ�������", "40020", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:VEN_CREDIT", "�ſ���", "40396", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:VEN_ZIP", "�����ȣ", "40455", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:VEN_ADDRESS", "�ּ�", "40626", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:VEN_TEL", "��ȭ��ȣ", "WCO6Q0OP", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:VEN_FAX", "�ѽ�", "40713", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:VEN_EMAIL", "E-Mail", "40790", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:VEN_CHARGE_EMP", "�����", "40127", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:VEN_CHARGE_TEL", "����� ��ȭ��ȣ", "40128", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:VEN_CHARGE_HP", "����� �޴���", "40129", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:SCOMMENT", "���", "ARYZ726K", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);



                        //        acVerticalGrid1.AddCategoryRow("Excel ������ ��������", "OUZTPLY1", true, new string[] { 
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


                        //        //Excel ������ ��������-ǥ�ذ���

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:SHEET", "��Ʈ", "LBG894M9", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:STARTROW", "������", "R309968V", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NUMERIC);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:TL_CODE", "�����ڵ�", "836KV66Y", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:TL_NAME", "������", "06LAUCR8", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:TL_TYPE", "��������", "LKGXVQFX", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:IS_MC_TOOL", "������������", "GSPAJEZW", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);


                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:TL_LTYPE", "���� ��з�", "UD9RQ4VO", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:TL_MTYPE", "���� �ߺз�", "YEPCM8Q9", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:TL_STYPE", "���� �Һз�", "Q8YT0F8H", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:TL_SPEC", "�������", "43Q908E3", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:STK_LOCATION", "â��", "NO1T1YEG", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);


                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:SAFE_STK_QTY", "����������", "SJVKEWA8", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);


                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:TL_MAKER", "���ۻ�", "9HDUX97V", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:TL_UNITCOST", "�ܰ�", "40121", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:TL_UNIT", "����", "40123", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:MAIN_VND", "�⺻ �ŷ�ó", "UHQZT510", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:INS_FLAG", "�԰�˻翩��", "42560", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:ACT_CODE", "ȸ�����", "42569", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:SCOMMENT", "���", "ARYZ726K", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);


                        //        acVerticalGrid1.AddCategoryRow("Excel ������ ��������", "OUZTPLY1", true, new string[] { 
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



                        //        //Excel ������ ��������-����/���

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:SHEET", "��Ʈ", "LBG894M9", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT::STARTROW", "������", "R309968V", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NUMERIC);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT::ORG_CODE", "�μ�", "40221", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT::EMP_CODE", "����ڵ�", "UV9LGK3D", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT::EMP_NAME", "�����", "40266", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT::EMP_TYPE", "�������", "U2V6VABY", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT::EMP_TITLE", "��å", "72MOO4VJ", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT::CPROC_CODE", "�ӷ�", "40505", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT::USRGRP_CODE", "����� �׷�", "40263", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT::MOBILE_PHONE", "�޴���", "0SRN1JQ9", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT::EMAIL", "E-Mail", "40790", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT::EMP_SEQ", "ǥ�ü���", "40723", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);


                        //        acVerticalGrid1.AddCategoryRow("Excel ������ ��������", "OUZTPLY1", true, new string[] { 
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


                        //        //Excel ������ ��������-ǥ������

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:SHEET", "��Ʈ", "LBG894M9", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);


                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:STARTROW", "������", "R309968V", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NUMERIC);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:MQLTY_CODE", "�����ڵ�", "QGD6SY0U", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:MQLTY_NAME", "������", "40572", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:MQLTY_WEIGHT", "����", "40248", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:UNIT_CONVERT_VALUE", "����ȯ�갪", "VRR6Q9XZ", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:SCOMMENT", "���", "ARYZ726K", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);


                        //        acVerticalGrid1.AddCategoryRow("Excel ������ ��������", "OUZTPLY1", true, new string[] { 
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


                        //        //������ ���� ��� ����

                        //        acVerticalGrid1.AddTextEdit("QLTY:AUTO_MARGIN_RND_UN30", "ȯ��_�п�", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);

                        //        acVerticalGrid1.AddTextEdit("QLTY:AUTO_MARGIN_RND_UP30", "ȯ��_����", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);

                        //        acVerticalGrid1.AddTextEdit("QLTY:AUTO_MARGIN_HEXA", "����ü", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);

                        //        acVerticalGrid1.AddCategoryRow("��纰 ������� ����", "", false, new string[] { 
                        //        "QLTY:AUTO_MARGIN_RND_UN30"
                        //        ,"QLTY:AUTO_MARGIN_RND_UP30"
                        //        ,"QLTY:AUTO_MARGIN_HEXA"
                        //        });

                        //    }
                        //    break;

                        //case "POP05A":
                        //    {


                        //        //Excel ������ ��������-��������Ʈ

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:SHEET", "��Ʈ", "LBG894M9", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);


                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:STARTROW", "������", "R309968V", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NUMERIC);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:TL_CODE", "�����ڵ�", "836KV66Y", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:TL_NUM", "����ǰ��", "2XEVDYLQ", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:TL_TIME","�����ð�", "6S5HF69R", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:SCOMMENT", "���", "ARYZ726K", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);


                        //        acVerticalGrid1.AddCategoryRow("Excel ������ ��������", "OUZTPLY1", true, new string[] { 
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
                        //        //���ְ���

                        //        acVerticalGrid1.AddCheckEdit("AUTO_INDUE_DATE", "���γ����� �ڵ�����", "5WOR9I9Z", true, "������ ������ �ڵ����� ���γ������� �����մϴ�.", "M8YWZ3IR", true, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emCheckEditDataType._STRING);
                        //        acVerticalGrid1.AddTextEdit("AUTO_INDUE_DATE_DAYS", "���γ����� �ڵ����� ��¥(��)", "9U8KHDB3", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NUMERIC);

                        //        acVerticalGrid1.AddCategoryRow(menuName, string.Empty, false, new string[] { 
                        //        "AUTO_INDUE_DATE"
                        //        ,"AUTO_INDUE_DATE_DAYS"
                        //        });


                        //    }

                        //    break;

                        //case "ORD02B":
                        //    {
                        //        //��������

                        //        acVerticalGrid1.AddCheckEdit("AUTO_INDUE_DATE", "���γ����� �ڵ�����", "5WOR9I9Z", true, "������ ������ �ڵ����� ���γ������� �����մϴ�.", "M8YWZ3IR", true, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emCheckEditDataType._STRING);
                        //        acVerticalGrid1.AddTextEdit("AUTO_INDUE_DATE_DAYS", "���γ����� �ڵ����� ��¥(��)", "9U8KHDB3", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NUMERIC);

                        //        acVerticalGrid1.AddCategoryRow(menuName, string.Empty, false, new string[] { 
                        //        "AUTO_INDUE_DATE"
                        //        ,"AUTO_INDUE_DATE_DAYS"
                        //        });


                        //    }

                        //    break;

                        //case "ORD05A":
                        //    {

                        //        acVerticalGrid1.AddColorEdit("PROD_PERIOD_COLOR", "����Ⱓ ����", "DXLV1T43", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);

                        //        acVerticalGrid1.AddColorEdit("PLN_ACT_LINK_COLOR", "��ȹ���� ���� ������", "4T8Y2NB3", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);


                        //        acVerticalGrid1.AddCategoryRow(menuName, string.Empty, false, new string[] { 
                        //        "PROD_PERIOD_COLOR"
                        //        ,"PLN_ACT_LINK_COLOR"
                        //        });

                        //    }

                        //    break;

                        //case "ORD07A":
                        //    {
                        //        acVerticalGrid1.AddTextEdit("EXCEL_PATH", "������� ���", "UCO4YAY7", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);

                        //        acVerticalGrid1.AddCategoryRow(menuName, string.Empty, false, new string[] { 
                        //        "EXCEL_PATH"
                        //        });

                        //    }

                        //    break;


                        //case "DES03A":
                        //    {

                        //        acVerticalGrid1.AddColorEdit("PROD_PERIOD_COLOR", "����Ⱓ ����", "DXLV1T43", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);

                        //        acVerticalGrid1.AddCategoryRow(menuName, string.Empty, false, new string[] { 
                        //        "PROD_PERIOD_COLOR"
                        //        });

                        //    }

                        //    break;


                        //case "PLN02A":
                        //    {

                        //        acVerticalGrid1.AddTextEdit("PROC_DISPLAY_TYPE", "���� ǥ������", "O80PN1MH", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);

                        //        acVerticalGrid1.AddColorEdit("PROC_ORDER_LINE_COLOR", "�������� ������", "BT7RXE2N", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);

                        //        acVerticalGrid1.AddTextEdit("PROC_ORDER_LINE_WIDTH", "�������� ������", "XM29G9Z8", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NUMERIC);

                        //        acVerticalGrid1.AddColorEdit("SUCC_LINE_COLOR", "�������� ����", "ZDL8M6EG", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);

                        //        acVerticalGrid1.AddTextEdit("SUCC_LINE_SELECTED_RADIUS", "�������� ���ù���", "VNU98R5Y", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);

                        //        acVerticalGrid1.AddColorEdit("SUCC_LINE_SELECTED_COLOR", "�������� ���û���", "RMK8HCO4", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);


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
                        //        acVerticalGrid1.AddColorEdit("PROD_PERIOD_COLOR", "����Ⱓ ����", "DXLV1T43", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);

                        //        acVerticalGrid1.AddColorEdit("PLN_ACT_LINK_COLOR", "��ȹ���� ���� ������", "4T8Y2NB3", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);

                        //        acVerticalGrid1.AddTextEdit("SUCC_LINE_WIDTH", "�������� ������", "UQVLSG89", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NUMERIC);

                        //        acVerticalGrid1.AddColorEdit("PLN_ACT_LINK_COLOR", "��ȹ���� ���� ������", "4T8Y2NB3", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);


                        //        acVerticalGrid1.AddTextEdit("PROC_DISPLAY_TYPE", "���� ǥ������", "O80PN1MH", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);

                        //        acVerticalGrid1.AddColorEdit("SCH_PROD_EXPT_DATE_LINE_COLOR", "���󳳱��� ������", "3SH4W1IN", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);


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
                        //        acVerticalGrid1.AddTextEdit("BOP_TABLE_PROD_DISPLAY_TYPE", "���� ǥ������", "7TGT9ML2", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);

                        //        acVerticalGrid1.AddTextEdit("BOP_TABLE_PLN_DISPLAY_TYPE", "���� ��ȹǥ������", "DB9DJ6GA", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);

                        //        acVerticalGrid1.AddTextEdit("BOP_TABLE_ACT_DISPLAY_TYPE", "���� ����ǥ������", "Z2XSFIZU", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);


                        //        acVerticalGrid1.AddCategoryRow(menuName, string.Empty, false, new string[] { 
                        //        "BOP_TABLE_PROD_DISPLAY_TYPE"
                        //        ,"BOP_TABLE_PLN_DISPLAY_TYPE"
                        //        ,"BOP_TABLE_ACT_DISPLAY_TYPE"
                        //        });


                        //    }

                        //    break;

                        //case "PLN08A":
                        //    {

                        //        acVerticalGrid1.AddColorEdit("SCH_PROD_NOW_DATE_LINE_COLOR", "���糯¥ ������", "XW2UX58I", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);

                        //        acVerticalGrid1.AddColorEdit("PROD_PERIOD_COLOR", "����Ⱓ ����", "DXLV1T43", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);

                        //        acVerticalGrid1.AddColorEdit("PROD_PLN_WO_COLOR", "�۾���ȹ ����", "ETIL8KYR", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);

                        //        acVerticalGrid1.AddColorEdit("PROD_ACT_WO_COLOR", "�۾����� ����", "3J5O71AU", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);


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


                        //        acVerticalGrid1.AddColorEdit("SCH_PROD_NOW_DATE_LINE_COLOR", "���糯¥ ������", "XW2UX58I", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);

                        //        acVerticalGrid1.AddColorEdit("SCH_PROD_ORD_DATE_LINE_COLOR", "������ ������", "484KT151", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);

                        //        acVerticalGrid1.AddColorEdit("SCH_PROD_INDUE_DATE_LINE_COLOR", "���γ����� ������", "B9AKARMR", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);

                        //        acVerticalGrid1.AddColorEdit("SCH_PROD_DUE_DATE_LINE_COLOR", "������ ������", "YPWA72HO", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);

                        //        acVerticalGrid1.AddColorEdit("SCH_PROD_EXPT_DATE_LINE_COLOR", "���󳳱��� ������", "3SH4W1IN", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);

                        //        acVerticalGrid1.AddColorEdit("SCH_PROD_PUR_DATE_LINE_COLOR", "���� ������", "GRHKKGOI", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);

                        //        acVerticalGrid1.AddColorEdit("SUCC_LINE_COLOR", "�������� ����", "ZDL8M6EG", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);

                        //        acVerticalGrid1.AddTextEdit("SUCC_LINE_WIDTH", "�������� ������", "UQVLSG89", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NUMERIC);

                        //        acVerticalGrid1.AddColorEdit("PLN_ACT_LINK_COLOR", "��ȹ���� ���� ������", "4T8Y2NB3", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);


                        //        acVerticalGrid1.AddTextEdit("PLN_PROD_DISPLAY_TYPE", "���� ǥ������", "O80PN1MH", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);
                        //        acVerticalGrid1.AddTextEdit("PLN_PROD_OS_DISPLAY_TYPE", "�������� ǥ������", "E2SL0J4F", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);
                        //        acVerticalGrid1.AddColorEdit("SCH_PROD_ACT_START_DATE_LINE_COLOR", "�۾������� ������", "4WRLL1QX", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true);


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
                        //        acVerticalGrid1.AddTextEdit("PLN_MC_DISPLAY_TYPE", "���� ǥ������", "O80PN1MH", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);

                        //        acVerticalGrid1.AddTextEdit("PLN_MC_IDLE_DISPLAY_TYPE", "�񰡵����� ǥ������", "YH4G5C9Q", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);

                        //        acVerticalGrid1.AddTextEdit("PLN_MC_OS_DISPLAY_TYPE", "�������� ǥ������", "E2SL0J4F", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);


                        //        acVerticalGrid1.AddCategoryRow(menuName, string.Empty, false, new string[] { 
                        //        "PLN_MC_DISPLAY_TYPE"
                        //        ,"PLN_MC_IDLE_DISPLAY_TYPE"
                        //        ,"PLN_MC_OS_DISPLAY_TYPE"
                        //        });

                        //    }

                        //    break;


                        //case "DES01A":
                        //    {

                        //        //Excel ������ ��������-��ǰ����Ʈ
                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:SHEET", "��Ʈ", "LBG894M9", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:STARTROW", "������", "R309968V", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NUMERIC);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:P_PART_CODE", "���ǰ�ڵ�", "42562", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:P_PART_NUM", "��ǰ��", "42564", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:PART_CODE", "��ǰ�ڵ�", "40239", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:PART_NUM", "ǰ��", "40743", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:PTNAME", "��ǰ��", "40234", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:PART_QLTY", "�����ڵ�", "QGD6SY0U", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:PART_SPEC", "������", "42544", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:PART_SPEC1", "�ϼ����", "42545", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:PART_QTY", "����", "40345", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:SCOMMENT", "���", "ARYZ726K", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);

                        //        acVerticalGrid1.AddTextEdit("EXCEL_IMPORT:DRAW_NO", "�����ȣ", "40145", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.UPPERCASE);




                        //        acVerticalGrid1.AddCategoryRow("Excel ������ ��������", "OUZTPLY1", true, new string[] { 
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


                        //        acVerticalGrid1.AddTextEdit("MC_STATUS_RUN_CONTENTS_DISPLAY_TYPE", "�������� ǥ������", "4JSIRU39", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);

                        //        acVerticalGrid1.AddTextEdit("MC_STATUS_IDLE_CONTENTS_DISPLAY_TYPE", "�񰡵����� ǥ������", "YH4G5C9Q", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NONE);

                        //        acVerticalGrid1.AddTextEdit("MC_STATUS_REFRESH_TIME", "���Žð�(��)", "7QFY2GCJ", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NUMERIC);

                        //        acVerticalGrid1.AddTextEdit("MC_STATUS_PAGE_CHANGE_TIME", "������ ��ȯ�ð�(��)", "05TAVNJT", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NUMERIC);

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
                        //        //�����û

                        //        acVerticalGrid1.AddCheckEdit("IS_CHANGE_REQ_DATE", "��û�� ���氡��", "FWH2A8AO", true, "���� ��û�� ��û�� ���氡�ɿ��θ� �����մϴ�.", "8ZV4RPRB", true, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emCheckEditDataType._STRING);

                        //        acVerticalGrid1.AddCheckEdit("AUTOAPP_MAT_REQ", "��û �ڵ�����", "ZLAHAVHG", true, "���� ��û�� �ڵ����� ��û���ε˴ϴ�.", "QS9581Q0", true, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emCheckEditDataType._STRING);

                        //        acVerticalGrid1.AddCategoryRow(menuName, string.Empty, false, new string[] { 
                        //          "IS_CHANGE_REQ_DATE"
                        //         ,"AUTOAPP_MAT_REQ"
                        //         });
                        //    }

                        //    break;


                        //case "PUR03B":
                        //    {
                        //        //�������

                        //        acVerticalGrid1.AddCheckEdit("IS_CHANGE_BALJU_DATE", "������ ���氡��", "BMFRUSY4", true, "���� ���ֽ� ������ ���氡�ɿ��θ� �����մϴ�.", "U5V6LID4", true, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emCheckEditDataType._STRING);

                        //        acVerticalGrid1.AddCheckEdit("AUTOAPP_MAT_BAL", "���� �ڵ�����", "Y2YSTBFC", true, "���ֽ� �ڵ����� ���ֽ��ε˴ϴ�.", "4V35L0Q6", true, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emCheckEditDataType._STRING);

                        //        acVerticalGrid1.AddCheckEdit("IS_INPUT_MINUS_COST", "���̳ʽ� �ܰ� �Է����", "QRDOEUT1", true, "���� ���ֽ� 0 ������ �ܰ� �Է��� ����մϴ�.", "SY7N9BT0", true, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emCheckEditDataType._STRING);


                        //        acVerticalGrid1.AddTextEdit("EXPENSE_RECENT_LIST_MONTH", "�ֱ� ������� ����(����)", "CT9MWH0U", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NUMERIC);


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
                        //        //�������� ��û
                        //        acVerticalGrid1.AddCheckEdit("IS_CHANGE_REQ_DATE", "��û�� ���氡��", "FWH2A8AO", true, "���� ��û�� ��û�� ���氡�ɿ��θ� �����մϴ�.", "8ZV4RPRB", true, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emCheckEditDataType._STRING);

                        //        acVerticalGrid1.AddCheckEdit("AUTOAPP_OUT_REQ", "��û �ڵ�����", "ZLAHAVHG", true, "���� ��û�� �ڵ����� ��û���ε˴ϴ�.", "QS9581Q0", true, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emCheckEditDataType._STRING);

                        //        acVerticalGrid1.AddCategoryRow(menuName, string.Empty, false, new string[] { 
                        //          "IS_CHANGE_REQ_DATE"
                        //         ,"AUTOAPP_OUT_REQ"
                        //         });

                        //    }

                        //    break;

                        //case "PUR13B":
                        //    {
                        //        //�������� ����

                        //        acVerticalGrid1.AddCheckEdit("IS_CHANGE_BALJU_DATE", "������ ���氡��", "BMFRUSY4", true, "���� ���ֽ� ������ ���氡�ɿ��θ� �����մϴ�.", "U5V6LID4", true, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emCheckEditDataType._STRING);

                        //        acVerticalGrid1.AddCheckEdit("AUTOAPP_OUT_BAL", "���� �ڵ�����", "Y2YSTBFC", true, "���ֽ� �ڵ����� ���ֽ��ε˴ϴ�.", "4V35L0Q6", true, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emCheckEditDataType._STRING);

                        //        acVerticalGrid1.AddCheckEdit("IS_INPUT_MINUS_COST", "���̳ʽ� �ܰ� �Է����", "QRDOEUT1", true, "���� ���ֽ� 0 ������ �ܰ� �Է��� ����մϴ�.", "SY7N9BT0", true, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emCheckEditDataType._STRING);

                        //        acVerticalGrid1.AddTextEdit("EXPENSE_RECENT_LIST_MONTH", "�ֱ� ������� ����(����)", "CT9MWH0U", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NUMERIC);


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
                        //        //��Ʈ���� ��û
                        //        acVerticalGrid1.AddCheckEdit("IS_CHANGE_REQ_DATE", "��û�� ���氡��", "FWH2A8AO", true, "���� ��û�� ��û�� ���氡�ɿ��θ� �����մϴ�.", "8ZV4RPRB", true, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emCheckEditDataType._STRING);

                        //        acVerticalGrid1.AddCheckEdit("AUTOAPP_SET_REQ", "��û �ڵ�����", "ZLAHAVHG", true, "���� ��û�� �ڵ����� ��û���ε˴ϴ�.", "QS9581Q0", true, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emCheckEditDataType._STRING);

                        //        acVerticalGrid1.AddCategoryRow(menuName, string.Empty, false, new string[] { 
                        //          "IS_CHANGE_REQ_DATE"
                        //         ,"AUTOAPP_SET_REQ"
                        //         });
                        //    }

                        //    break;

                        //case "PUR22B":
                        //    {
                        //        //��Ʈ���� ����
                        //        acVerticalGrid1.AddCheckEdit("IS_CHANGE_BALJU_DATE", "������ ���氡��", "BMFRUSY4", true, "���� ���ֽ� ������ ���氡�ɿ��θ� �����մϴ�.", "U5V6LID4", true, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emCheckEditDataType._STRING);


                        //        acVerticalGrid1.AddCheckEdit("AUTOAPP_SET_BAL", "���� �ڵ�����", "Y2YSTBFC", true, "���ֽ� �ڵ����� ���� ���ε˴ϴ�.", "4V35L0Q6", true, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emCheckEditDataType._STRING);

                        //        acVerticalGrid1.AddCheckEdit("IS_INPUT_MINUS_COST", "���̳ʽ� �ܰ� �Է����", "QRDOEUT1", true, "���� ���ֽ� 0 ������ �ܰ� �Է��� ����մϴ�.", "SY7N9BT0", true, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emCheckEditDataType._STRING);


                        //        acVerticalGrid1.AddCategoryRow(menuName, string.Empty, false, new string[] { 
                        //          "IS_CHANGE_BALJU_DATE"
                        //         ,"AUTOAPP_SET_BAL"
                        //         ,"IS_INPUT_MINUS_COST"
                        //         });
                        //    }

                        //    break;


                        //case "PUR07A":
                        //    {
                        //        //���� ��û

                        //        acVerticalGrid1.AddCheckEdit("IS_CHANGE_REQ_DATE", "��û�� ���氡��", "FWH2A8AO", true, "���� ��û�� ��û�� ���氡�ɿ��θ� �����մϴ�.", "8ZV4RPRB", true, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emCheckEditDataType._STRING);

                        //        acVerticalGrid1.AddCheckEdit("AUTOAPP_TOL_REQ", "��û �ڵ�����", "ZLAHAVHG", true, "���� ��û�� �ڵ����� ��û���ε˴ϴ�.", "QS9581Q0", false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emCheckEditDataType._STRING);

                        //        acVerticalGrid1.AddCategoryRow(menuName, string.Empty, false, new string[] { 
                        //          "IS_CHANGE_REQ_DATE"
                        //         ,"AUTOAPP_TOL_REQ"
                        //         });
                        //    }

                        //    break;


                        //case "PUR09A":
                        //    {
                        //        //���� ����

                        //        acVerticalGrid1.AddCheckEdit("IS_CHANGE_BALJU_DATE", "������ ���氡��", "BMFRUSY4", true, "���� ���ֽ� ������ ���氡�ɿ��θ� �����մϴ�.", "U5V6LID4", true, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emCheckEditDataType._STRING);

                        //        acVerticalGrid1.AddCheckEdit("AUTOAPP_TOL_BAL", "���� �ڵ�����", "Y2YSTBFC", true, "���ֽ� �ڵ����� ���� ���ε˴ϴ�.", "4V35L0Q6", false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emCheckEditDataType._STRING);

                        //        acVerticalGrid1.AddCheckEdit("IS_INPUT_MINUS_COST", "���̳ʽ� �ܰ� �Է����", "QRDOEUT1", true, "���� ���ֽ� 0 ������ �ܰ� �Է��� ����մϴ�.", "SY7N9BT0", true, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emCheckEditDataType._STRING);

                        //        acVerticalGrid1.AddTextEdit("EXPENSE_RECENT_LIST_MONTH", "�ֱ� ������� ����(����)", "CT9MWH0U", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NUMERIC);


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
                        //        //�԰�
                        //        acVerticalGrid1.AddCheckEdit("IS_CHANGE_YPGO_DATE", "�԰��� ���氡��", "MXH1BFPX", true, "���� �԰�� �԰��� ���氡�ɿ��θ� �����մϴ�.", "9K1VYOMW", true, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emCheckEditDataType._STRING);


                        //        acVerticalGrid1.AddCategoryRow(menuName, string.Empty, false, new string[] { 
                        //          "IS_CHANGE_YPGO_DATE"
                        //         });

                        //    }

                        //    break;


                        //case "PUR31A":
                        //    {
                        //        //�������
                        //        acVerticalGrid1.AddCheckEdit("IS_CHANGE_EXPENSE_DATE", "��������� ���氡��", "3FUBH9X5", true, "��������� ���氡�ɿ��θ� �����մϴ�.", "P2ULXSQ1", true, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emCheckEditDataType._STRING);

                        //        acVerticalGrid1.AddCheckEdit("AUTOAPP_EXP_MAT", "���籸�� ������� �ڵ�����", "VDS5TZRG", true, "���籸�� ������ǽ� �ڵ����� ������� ���ε˴ϴ�.", "5VT8PZWB", true, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emCheckEditDataType._STRING);

                        //        acVerticalGrid1.AddCheckEdit("AUTOAPP_EXP_OUT", "�������� ������� �ڵ�����", "8W8R9IZ9", true, "�������� ������ǽ� �ڵ����� ������� ���ε˴ϴ�.", "CW6WYW9B", true, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emCheckEditDataType._STRING);

                        //        acVerticalGrid1.AddCheckEdit("AUTOAPP_EXP_SET", "��Ʈ���� ������� �ڵ�����", "0QG1FM5T", true, "��Ʈ���� ������ǽ� �ڵ����� ������� ���ε˴ϴ�.", "BZJRSYFL", true, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emCheckEditDataType._STRING);

                        //        acVerticalGrid1.AddCheckEdit("AUTOAPP_EXP_TOL", "�������� ������� �ڵ�����", "L5HAJXBF", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emCheckEditDataType._STRING);

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
                        //        acVerticalGrid1.AddLookUpEdit("REQ_LIST_STATE", "��û�� ��°��� ���Ż���", "ML7STFRN", true, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, "S043");

                        //        acVerticalGrid1.AddCategoryRow(menuName, string.Empty, false, new string[] { 
                        //        "REQ_LIST_STATE"
                        //         });

                        //    }

                        //    break;

                        //case "TOL02A":
                        //    {

                        //        acVerticalGrid1.AddCheckEdit("IS_CHANGE_GIVE_DATE", "������ ���氡��", "WM6XAKJQ", true, "���� ���޽� ������ ���氡�ɿ��θ� �����մϴ�.", "4OWUY1ZB", true, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emCheckEditDataType._STRING);

                        //        acVerticalGrid1.AddCategoryRow(menuName, string.Empty, false, new string[] { 
                        //        "IS_CHANGE_GIVE_DATE"
                        //         });

                        //    }

                        //    break;

                        //case "TOL04A":
                        //    {
                        //        acVerticalGrid1.AddCheckEdit("IS_CHANGE_RETURN_DATE", "�ݳ��� ���氡��", "UALDBT1O", true, "���� �ݳ��� �ݳ��� ���氡�ɿ��θ� �����մϴ�.", "RCSN2OIX", true, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emCheckEditDataType._STRING);

                        //        acVerticalGrid1.AddCategoryRow(menuName, string.Empty, false, new string[] { 
                        //        "IS_CHANGE_RETURN_DATE"
                        //         });
                        //    }

                        //    break;


                        //case "TOL06A":
                        //    {
                        //        acVerticalGrid1.AddCheckEdit("IS_CHANGE_DISUSE_DATE", "����� ���氡��", "A7TZS19M", true, "���� ���� ����� ���氡�ɿ��θ� �����մϴ�.", "H6BY5CRQ", true, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emCheckEditDataType._STRING);

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

            acGridView1.AddTextEdit("MENU_NAME", "�޴���", "D6UJPZ3J", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

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
            //����

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
            //����
            if (acGridView1.ValidFocusRowHandle() == false)
            {
                return;
            }

            acGridView1.RaiseFocusedRowChanged();

            base.SetLog(QBiz.emExecuteType.REFRESH);

        }


    }
}

