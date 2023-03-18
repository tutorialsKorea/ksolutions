using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ControlManager;
using BizManager;

using DevExpress.XtraGrid.Scrolling;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.ViewInfo;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Grid;
using System.Diagnostics;
using System.Linq;
using DevExpress.XtraEditors.Repository;
using POP;
using System.IO;
using DevExpress.Utils;
using DevExpress.XtraEditors.Controls;

namespace PUR
{

    public sealed partial class PUR01A_M0A : BaseMenu
    {
        public PUR01A_M0A()
        {
            InitializeComponent();

            acLayoutControl1.OnValueChanged += acLayoutControl1_OnValueChanged;
            acLayoutControl1.OnValueKeyDown += acLayoutControl1_OnValueKeyDown;

            acLayoutControl2.OnValueChanged += AcLayoutControl2_OnValueChanged;
            acLayoutControl2.OnValueKeyDown += AcLayoutControl2_OnValueKeyDown;

            // acGridView1.ShowGridMenuEx += AcGridView1_ShowGridMenuEx;
            acGridView1.ShowGridMenuEx += acGridView1_ShowGridMenuEx;

            acGridView1.MouseDown += AcGridView1_MouseDown;
            acGridView2.FocusedRowChanged += AcGridView2_FocusedRowChanged;
            acGridView2.CellValueChanged += AcGridView2_CellValueChanged;
            acGridView2.ShowGridMenuEx += AcGridView2_ShowGridMenuEx;
            acGridView2.MouseDown += AcGridView2_MouseDown;

            acGridView4.FocusedRowChanged += acGridView4_FocusedRowChanged;
            
            acTabControl1.SelectedPageChanged += AcTabControl1_SelectedPageChanged;

           // acLayoutControl1.GetEditor("MAT_LTYPE").Value = "2"; //디폴트 : 구매품
        }

        private void acGridView4_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            acGridView view = sender as acGridView;

            if (view.ValidFocusRowHandle())
            {
                DataRow focusRow = acGridView4.GetFocusedDataRow();

                if (focusRow != null)
                {
                    acAttachFileControl1.LinkKey = focusRow["BALJU_NUM"].ToString() + "_PUR";
                    acAttachFileControl1.ShowKey = new object[] { focusRow["BALJU_NUM"].ToString() + "_PUR" };
                }
            }
        }

        public override acBarManager BarManager
        {

            get
            {
                return acBarManager1;
            }

        }

        public override string InstantLog
        {
            set
            {
                statusBarLog.Caption = value;
            }
        }

        public override bool MenuDestory(object sender)
        {
            if (acTabControl1.SelectedTabPage.Name == "acTabPage2")
            {
                if (base.MenuStatus == emMenuStatus.WORK)
                {
                    //수정하거나 작업중인 항목이 존재합니다. 정말 닫으시겠습니까?

                    if (acMessageBox.Show(this, "수정하거나 작업중인 항목이 존재합니다. 정말 닫으시겠습니까?", "AEIR4MG6", true, acMessageBox.emMessageBoxType.YESNO) == DialogResult.Yes)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }

                return true;
            }
            else
                return base.MenuDestory(sender);
        }

        public override void MenuInit()
        {
            try
            {

                acGridView1.GridType = acGridView.emGridType.SEARCH;


            
                //acGridView1.AddLookUpEdit("PART_PRODTYPE", "분류", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M007");
                acGridView1.AddLookUpEdit("MAT_LTYPE", "대분류", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M014");
                acGridView1.AddLookUpEdit("MAT_MTYPE", "중분류", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M015");
                acGridView1.AddLookUpEdit("MAT_STYPE", "소분류", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M016");
                //acGridView1.AddLookUpEdit("MAT_TYPE1", "자재구분", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M001");
                //acGridView1.AddLookUpEdit("MAT_TYPE2", "자재유형", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M002");
                acGridView1.AddTextEdit("PART_CODE", "자재코드", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView1.AddTextEdit("PART_NAME", "자재명", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView1.AddLookUpVendor("MAIN_VND", "외주업체", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false);
                acGridView1.AddLookUpVendor("SUPP_VND", "공급사", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false);
                acGridView1.AddLookUpEdit("INS_FLAG", "검사여부", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "S063");
                acGridView1.AddTextEdit("STK_QTY", "재고 수량", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
                acGridView1.AddTextEdit("SAFE_STK_QTY", "안전 재고", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
                acGridView1.AddLookUpEdit("MAT_UNIT", "단위", "40123", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M003");
                acGridView1.AddTextEdit("MAT_COST", "자재 단가", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
                acGridView1.AddTextEdit("SCOMMENT", "비고", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

                RepositoryItemButtonEdit riButtonEdit = new RepositoryItemButtonEdit();
                EditorButton button = new EditorButton(ButtonPredefines.Glyph, string.Empty, -1, true, true, false, ImageLocation.MiddleCenter, null);
                riButtonEdit.LookAndFeel.SetSkinStyle(DevExpress.LookAndFeel.SkinStyle.TheAsphaltWorld);

                button.Caption = "DWG";
                button.ToolTip = "DWG";

                riButtonEdit.Buttons.Clear();
                riButtonEdit.Buttons.Add(button);
                riButtonEdit.TextEditStyle = TextEditStyles.HideTextEditor;
                riButtonEdit.ButtonClick += DWG_ButtonClick;

                acGridView1.AddCustomEdit("DWG_OPEN", "DWG", "", false, DevExpress.Utils.HorzAlignment.Center, true, true, false, riButtonEdit);

                RepositoryItemButtonEdit riButtonEdit2 = new RepositoryItemButtonEdit();
                EditorButton button2 = new EditorButton(ButtonPredefines.Glyph, string.Empty, -1, true, true, false, ImageLocation.MiddleCenter, null);
                riButtonEdit2.LookAndFeel.SetSkinStyle(DevExpress.LookAndFeel.SkinStyle.TheAsphaltWorld);

                button2.Caption = "PDF";
                button2.ToolTip = "PDF";

                riButtonEdit2.Buttons.Clear();
                riButtonEdit2.Buttons.Add(button2);
                riButtonEdit2.TextEditStyle = TextEditStyles.HideTextEditor;
                riButtonEdit2.ButtonClick += PDF_ButtonClick;

                acGridView1.AddCustomEdit("PDF_OPEN", "PDF", "", false, DevExpress.Utils.HorzAlignment.Center, true, true, false, riButtonEdit2);

                RepositoryItemButtonEdit riButtonEdit3 = new RepositoryItemButtonEdit();
                EditorButton button3 = new EditorButton(ButtonPredefines.Glyph, string.Empty, -1, true, true, false, ImageLocation.MiddleCenter, null);
                riButtonEdit3.LookAndFeel.SetSkinStyle(DevExpress.LookAndFeel.SkinStyle.TheAsphaltWorld);

                button3.Caption = "JT";
                button3.ToolTip = "JT";

                riButtonEdit3.Buttons.Clear();
                riButtonEdit3.Buttons.Add(button3);
                riButtonEdit3.TextEditStyle = TextEditStyles.HideTextEditor;
                riButtonEdit3.ButtonClick += JT_ButtonClick;

                acGridView1.AddCustomEdit("JT_OPEN", "JT", "", false, DevExpress.Utils.HorzAlignment.Center, true, true, false, riButtonEdit3);

                acGridView1.AddDateEdit("REG_DATE", "최초 등록일", "UL1O77MB", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.FULL_DATE);
                acGridView1.AddTextEdit("REG_EMP", "최초 등록인", "GPQHG8QQ", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView1.AddDateEdit("MDFY_DATE", "최근 수정일", "6RXQO0B2", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.FULL_DATE);
                acGridView1.AddTextEdit("MDFY_EMP", "최근 수정자", "FHJDO4F0", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView1.KeyColumn = new string[] { "PART_CODE" };

                acGridView1.OptionsSelection.MultiSelect = true;
                acGridView1.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CheckBoxRowSelect;

                acGridView2.GridType = acGridView.emGridType.SEARCH;

           
                //acGridView2.AddLookUpEdit("PART_PRODTYPE", "분류", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M007");
                acGridView2.AddLookUpEdit("MAT_LTYPE", "대분류", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M014");
                acGridView2.AddLookUpEdit("MAT_MTYPE", "중분류", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M015");
                acGridView2.AddLookUpEdit("MAT_STYPE", "소분류", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M016");
                //acGridView2.AddLookUpEdit("MAT_TYPE1", "자재구분", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M001");
                //acGridView2.AddLookUpEdit("MAT_TYPE2", "자재유형", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M002");
                acGridView2.AddTextEdit("PART_CODE", "자재코드", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView2.AddTextEdit("PART_NAME", "자재명", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView2.AddLookUpEdit("INS_FLAG", "검사여부", "", false, DevExpress.Utils.HorzAlignment.Center, true, true, true, "S063");
                acGridView2.AddLookUpVendor("MAIN_VND", "외주업체", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false);
                acGridView2.AddLookUpVendor("SUPP_VND", "공급사", "", false, DevExpress.Utils.HorzAlignment.Center, true, true, true);
                acGridView2.AddDateEdit("DUE_DATE", "입고요청일", "", false, DevExpress.Utils.HorzAlignment.Center, true, true, true, acGridView.emDateMask.SHORT_DATE);
                acGridView2.AddTextEdit("BAL_QTY", "발주 수량", "", false, DevExpress.Utils.HorzAlignment.Far, true, true, true, acGridView.emTextEditMask.QTY);
                acGridView2.AddLookUpEdit("MAT_UNIT", "단위", "40123", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M003");
                
                acGridView2.AddTextEdit("MAT_COST", "단가", "", false, DevExpress.Utils.HorzAlignment.Far, true, true, false, acGridView.emTextEditMask.MONEY);
                acGridView2.AddLookUpEdit("BAL_UNIT", "화폐단위", "", false, DevExpress.Utils.HorzAlignment.Center, true, true, false, "P008");
                acGridView2.AddTextEdit("MAT_AMT", "금액", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);

                //acGridView2.AddTextEdit("REAL_AMT", "실제 입금금액", "", false, DevExpress.Utils.HorzAlignment.Far, true, true, false, acGridView.emTextEditMask.MONEY);
                //acGridView2.AddTextEdit("BANK", "은행", "", false, DevExpress.Utils.HorzAlignment.Near, true, true, false, acGridView.emTextEditMask.NONE);
                //acGridView2.AddTextEdit("BANK_NO", "계좌번호", "", false, DevExpress.Utils.HorzAlignment.Near, true, true, false, acGridView.emTextEditMask.NONE);

                acGridView2.AddTextEdit("REAL_AMT", "실제 입금금액", "", false, DevExpress.Utils.HorzAlignment.Far, true, true, false, acGridView.emTextEditMask.MONEY);
                acGridView2.AddTextEdit("BANK", "은행", "", false, DevExpress.Utils.HorzAlignment.Near, true, true, false, acGridView.emTextEditMask.NONE);
                acGridView2.AddTextEdit("VEN_ACCOUNT", "예금주", "", false, DevExpress.Utils.HorzAlignment.Center, true, true, false, acGridView.emTextEditMask.NONE);
                acGridView2.AddTextEdit("BANK_NO", "계좌번호", "", false, DevExpress.Utils.HorzAlignment.Near, true, true, false, acGridView.emTextEditMask.NONE);

                acGridView2.AddTextEdit("BAL_SCOMMENT", "비고", "", false, DevExpress.Utils.HorzAlignment.Near, true, true, false, acGridView.emTextEditMask.NONE);

                //acGridView2.KeyColumn = new string[] { "PART_CODE" };
                acGridView2.Columns["BAL_QTY"].ColumnEdit.EditValueChanging += ColumnEdit_EditValueChanging;
                acGridView2.Columns["MAT_COST"].ColumnEdit.EditValueChanging += ColumnEdit_EditValueChanging1;

                acGridView2.OptionsSelection.MultiSelect = true;
                acGridView2.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CheckBoxRowSelect;

                acGridView3.GridType = acGridView.emGridType.SEARCH;

                //acGridView3.AddLookUpEdit("PART_PRODTYPE", "분류", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, "M007");
                //acGridView3.AddLookUpEdit("MAT_TYPE1", "자재구분", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, "M001");
                //acGridView3.AddLookUpEdit("MAT_TYPE2", "자재유형", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, "M002");
                acGridView3.AddTextEdit("BALJU_NUM", "발주번호", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView3.AddTextEdit("BALJU_SEQ", "순번", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                
                acGridView3.AddLookUpVendor("MVND_CODE", "발주처", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false);
                acGridView3.AddDateEdit("BALJU_DATE", "발주일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
                acGridView3.AddTextEdit("QTY", "발주수량", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
                acGridView3.AddLookUpEdit("MAT_UNIT", "단위", "40123", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M003");
                acGridView3.AddTextEdit("UNIT_COST", "단가", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
                acGridView3.AddTextEdit("AMT", "금액", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
                //acGridView3.AddTextEdit("YPGO_QTY", "입고수량", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.QTY);
                //acGridView3.AddTextEdit("YPGO_AMT", "입고금액", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.MONEY);

                acGridView4.GridType = acGridView.emGridType.SEARCH_SEL;
                acGridView4.AddLookUpEdit("BAL_STAT", "발주 상태", "", false, HorzAlignment.Center, false, true, false, "S043");
                acGridView4.AddTextEdit("BALJU_NUM", "발주번호", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView4.AddTextEdit("BALJU_SEQ", "순번", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView4.AddLookUpOrg("APP_ORG", "승인자그룹", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false);
                acGridView4.AddTextEdit("PART_CODE", "자재코드", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView4.AddTextEdit("PART_NAME", "자재명", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView4.AddLookUpEdit("MAT_LTYPE", "대분류", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M014");
                acGridView4.AddLookUpEdit("MAT_MTYPE", "중분류", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M015");
                acGridView4.AddLookUpEdit("MAT_STYPE", "소분류", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M016");
                //acGridView4.AddLookUpEdit("PART_PRODTYPE", "분류", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M007");
                //acGridView4.AddLookUpEdit("MAT_TYPE1", "자재구분", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M001");
                //acGridView4.AddLookUpEdit("MAT_TYPE2", "자재유형", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M002");
                //acGridView4.AddLookUpEdit("MAT_MTYPE", "구분", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M001");
                acGridView4.AddLookUpEdit("INS_FLAG", "검사여부", "", false, DevExpress.Utils.HorzAlignment.Center, true, true, false, "S063");
                acGridView4.AddLookUpVendor("MVND_CODE", "발주처", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false);
                acGridView4.AddDateEdit("BALJU_DATE", "발주일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
                acGridView4.AddDateEdit("DUE_DATE", "입고예정일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
                acGridView4.AddTextEdit("STATUS", "수정상태(system)", "", false, DevExpress.Utils.HorzAlignment.Near, false, false, false, acGridView.emTextEditMask.NONE);
                acGridView4.AddTextEdit("QTY", "발주수량", "", false, DevExpress.Utils.HorzAlignment.Far, true, true, false, acGridView.emTextEditMask.QTY);
                acGridView4.AddLookUpEdit("MAT_UNIT", "단위", "40123", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M003");
                acGridView4.AddTextEdit("UNIT_COST", "단가", "", false, DevExpress.Utils.HorzAlignment.Far, true, true, false, acGridView.emTextEditMask.MONEY);
                acGridView4.AddLookUpEdit("BAL_UNIT", "금액단위", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P008");
                acGridView4.AddTextEdit("AMT", "금액", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);

                //acGridView4.AddTextEdit("REAL_AMT", "실제 입금금액", "", false, DevExpress.Utils.HorzAlignment.Far, true, true, false, acGridView.emTextEditMask.MONEY);
                //acGridView4.AddTextEdit("BANK", "은행", "", false, DevExpress.Utils.HorzAlignment.Near, true, true, false, acGridView.emTextEditMask.NONE);
                //acGridView4.AddTextEdit("BANK_NO", "계좌번호", "", false, DevExpress.Utils.HorzAlignment.Near, true, true, false, acGridView.emTextEditMask.NONE);

                acGridView4.AddTextEdit("REAL_AMT", "실제 입금금액", "", false, DevExpress.Utils.HorzAlignment.Far, true, true, false, acGridView.emTextEditMask.MONEY);
                acGridView4.AddTextEdit("BANK", "은행", "", false, DevExpress.Utils.HorzAlignment.Near, true, true, false, acGridView.emTextEditMask.NONE);
                acGridView4.AddTextEdit("PUR_VEN_ACCOUNT", "예금주", "", false, DevExpress.Utils.HorzAlignment.Center, true, true, false, acGridView.emTextEditMask.NONE);
                acGridView4.AddTextEdit("BANK_NO", "계좌번호", "", false, DevExpress.Utils.HorzAlignment.Near, true, true, false, acGridView.emTextEditMask.NONE);

                acGridView4.AddTextEdit("SCOMMENT", "비고", "", false, DevExpress.Utils.HorzAlignment.Near, true, true, false, acGridView.emTextEditMask.NONE);

                acGridView4.AddCheckEdit("INCL_VAT", "부가세포함", "", false, false, true, acGridView.emCheckEditDataType._STRING);
                acGridView4.AddCheckEdit("SPLIT", "분할납품", "", false, false, true, acGridView.emCheckEditDataType._STRING);
                acGridView4.AddTextEdit("DELIVERY_LOCATION", "납품장소", "HEP4DK2T", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView4.AddTextEdit("PAY_CONDITION", "결제조건", "HEP4DK2T", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView4.AddTextEdit("YPGO_CHARGE", "입고담당", "HEP4DK2T", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView4.AddCheckEdit("CHK_MEASURE", "치수검사", "", false, false, true, acGridView.emCheckEditDataType._STRING);
                acGridView4.AddCheckEdit("CHK_PERFORM", "성능검사", "", false, false, true, acGridView.emCheckEditDataType._STRING);
                acGridView4.AddCheckEdit("CHK_ATTEND", "입회검사", "", false, false, true, acGridView.emCheckEditDataType._STRING);
                acGridView4.AddCheckEdit("CHK_TEST", "검사성적서", "", false, false, true, acGridView.emCheckEditDataType._STRING);
                acGridView4.AddCheckEdit("CHK_MEEL", "MEEL SHEET", "", false, false, true, acGridView.emCheckEditDataType._STRING);
                //acGridView4.AddCheckEdit("CHK_ADD1", "기타1", "", false, false, true, acGridView.emCheckEditDataType._STRING);
                //acGridView4.AddCheckEdit("CHK_ADD2", "기타2", "", false, false, true, acGridView.emCheckEditDataType._STRING);
                //acGridView4.AddCheckEdit("CHK_ADD3", "기타3", "", false, false, true, acGridView.emCheckEditDataType._STRING);
                acGridView4.AddTextEdit("CHK_ADD1", "기타1", "HEP4DK2T", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView4.AddTextEdit("CHK_ADD2", "기타2", "HEP4DK2T", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView4.AddTextEdit("CHK_ADD3", "기타3", "HEP4DK2T", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView4.AddTextEdit("M_SCOMMENT", "특기사항", "HEP4DK2T", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

                acGridView4.AddTextEdit("REG_EMP", "발주자코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
                acGridView4.AddTextEdit("REG_EMP_NAME", "발주자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

                acGridView4.AddLookUpEdit("APP_STATUS", "승인상태", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "W008");

                acGridView4.KeyColumn = new string[] { "BALJU_NUM", "BALJU_SEQ" };
                
                //acGridView4.OptionsSelection.MultiSelect = true;
                //acGridView4.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CheckBoxRowSelect;


                acGridView4.Columns["QTY"].ColumnEdit.EditValueChanging += qty_EditValueChanging;
                acGridView4.Columns["UNIT_COST"].ColumnEdit.EditValueChanging += cost_EditValueChanging;
                acGridView4.CellValueChanged += AcGridView4_CellValueChanged;
                acCheckedComboBoxEdit2.AddItem("발주일", true, "40206", "BALJU_DATE", true, false);

                //(acLayoutControl1.GetEditor("MAT_TYPE1") as acLookupEdit).SetCode("M001"); //자재구분
                //(acLayoutControl1.GetEditor("MAT_TYPE2") as acLookupEdit).SetCode("M002"); //자재유형

                (acLayoutControl1.GetEditor("MAT_LTYPE") as acLookupEdit).SetCode("M014"); //대분류
                //(acLayoutControl1.GetEditor("MAT_MTYPE") as acLookupEdit).SetCode("M015"); //중분류
                //(acLayoutControl1.GetEditor("MAT_STYPE") as acLookupEdit).SetCode("M016"); //소분류

                //(acLayoutControl1.GetEditor("PART_PRODTYPE") as acLookupEdit).SetCode("M007");

                btnEdit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                btnDel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                acBarButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

                base.MenuStatus = emMenuStatus.NONE;

                acGridView4.CustomRowCellEdit += acGridView4_CustomRowCellEdit;

                acGridView4.CustomDrawCell += acGridView4_CustomDrawCell1;

                acGridView1.CustomRowCellEdit += acGridView1_CustomRowCellEdit;

                base.MenuInit();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void acGridView1_CustomRowCellEdit(object sender, CustomRowCellEditEventArgs e)
        {
            try
            {
                //string isDWG = acGridView1.GetRowCellValue(e.RowHandle, "IS_DWG").ToString();
                //string isPDF = acGridView1.GetRowCellValue(e.RowHandle, "IS_PDF").ToString();
                //string isJT = acGridView1.GetRowCellValue(e.RowHandle, "IS_JT").ToString();

                if (e.RowHandle < 0) return;

                string PART_CODE = acGridView1.GetRowCellValue(e.RowHandle, "PART_CODE").ToString();

                if (e.Column.FieldName == "DWG_OPEN")
                {
                    DataRow[] rows = _dwgFileDT.Select("PART_NO = '" + PART_CODE + "' AND FILE_TYPE = 'DWG'");

                    if (rows.Length == 0)
                    //if (isDWG != "1")
                    {
                        EditorButton button = new EditorButton(ButtonPredefines.Glyph, string.Empty, -1, true, true, false, ImageLocation.MiddleCenter, null);
                        button.ToolTip = "DWG";
                        button.Enabled = false;

                        RepositoryItemButtonEdit riButtonEdit = new RepositoryItemButtonEdit();
                        riButtonEdit.TextEditStyle = TextEditStyles.HideTextEditor;
                        riButtonEdit.Buttons.Clear();
                        riButtonEdit.Buttons.Add(button);
                        e.RepositoryItem = riButtonEdit;
                        (e.RepositoryItem as RepositoryItemButtonEdit).Buttons[0].Enabled = false;
                    }
                    else
                    {
                        RepositoryItemButtonEdit riButtonEdit = new RepositoryItemButtonEdit();
                        EditorButton button = new EditorButton(ButtonPredefines.Glyph, string.Empty, -1, true, true, false, ImageLocation.MiddleCenter, null);
                        riButtonEdit.LookAndFeel.SetSkinStyle(DevExpress.LookAndFeel.SkinStyle.TheAsphaltWorld);

                        button.Caption = "DWG";
                        button.ToolTip = "DWG";

                        riButtonEdit.Buttons.Clear();
                        riButtonEdit.Buttons.Add(button);
                        riButtonEdit.TextEditStyle = TextEditStyles.HideTextEditor;
                        riButtonEdit.ButtonClick += DWG_ButtonClick;
                        e.RepositoryItem = riButtonEdit;
                        (e.RepositoryItem as RepositoryItemButtonEdit).Buttons[0].Enabled = true;
                    }
                }
                else if (e.Column.FieldName == "PDF_OPEN")
                {
                    DataRow[] rows = _dwgFileDT.Select("PART_NO = '" + PART_CODE + "' AND FILE_TYPE = 'PDF'");

                    if (rows.Length == 0)
                    //if (isDWG != "1")
                    {
                        EditorButton button = new EditorButton(ButtonPredefines.Glyph, string.Empty, -1, true, true, false, ImageLocation.MiddleCenter, null);
                        button.ToolTip = "PDF";
                        button.Enabled = false;

                        RepositoryItemButtonEdit riButtonEdit = new RepositoryItemButtonEdit();
                        riButtonEdit.TextEditStyle = TextEditStyles.HideTextEditor;
                        riButtonEdit.Buttons.Clear();
                        riButtonEdit.Buttons.Add(button);
                        e.RepositoryItem = riButtonEdit;
                        (e.RepositoryItem as RepositoryItemButtonEdit).Buttons[0].Enabled = false;
                    }
                    else
                    {
                        RepositoryItemButtonEdit riButtonEdit = new RepositoryItemButtonEdit();
                        EditorButton button = new EditorButton(ButtonPredefines.Glyph, string.Empty, -1, true, true, false, ImageLocation.MiddleCenter, null);
                        riButtonEdit.LookAndFeel.SetSkinStyle(DevExpress.LookAndFeel.SkinStyle.TheAsphaltWorld);

                        button.Caption = "PDF";
                        button.ToolTip = "PDF";

                        riButtonEdit.Buttons.Clear();
                        riButtonEdit.Buttons.Add(button);
                        riButtonEdit.TextEditStyle = TextEditStyles.HideTextEditor;
                        riButtonEdit.ButtonClick += PDF_ButtonClick;
                        e.RepositoryItem = riButtonEdit;
                        (e.RepositoryItem as RepositoryItemButtonEdit).Buttons[0].Enabled = true;
                    }
                }
                else if (e.Column.FieldName == "JT_OPEN")
                {
                    DataRow[] rows = _dwgFileDT.Select("PART_NO = '" + PART_CODE + "' AND FILE_TYPE = 'JT'");

                    if (rows.Length == 0)
                    //if (isDWG != "1")
                    {
                        EditorButton button = new EditorButton(ButtonPredefines.Glyph, string.Empty, -1, true, true, false, ImageLocation.MiddleCenter, null);
                        button.ToolTip = "JT";
                        button.Enabled = false;

                        RepositoryItemButtonEdit riButtonEdit = new RepositoryItemButtonEdit();
                        riButtonEdit.TextEditStyle = TextEditStyles.HideTextEditor;
                        riButtonEdit.Buttons.Clear();
                        riButtonEdit.Buttons.Add(button);
                        e.RepositoryItem = riButtonEdit;
                        (e.RepositoryItem as RepositoryItemButtonEdit).Buttons[0].Enabled = false;
                    }
                    else
                    {
                        RepositoryItemButtonEdit riButtonEdit = new RepositoryItemButtonEdit();
                        EditorButton button = new EditorButton(ButtonPredefines.Glyph, string.Empty, -1, true, true, false, ImageLocation.MiddleCenter, null);
                        riButtonEdit.LookAndFeel.SetSkinStyle(DevExpress.LookAndFeel.SkinStyle.TheAsphaltWorld);

                        button.Caption = "JT";
                        button.ToolTip = "JT";

                        riButtonEdit.Buttons.Clear();
                        riButtonEdit.Buttons.Add(button);
                        riButtonEdit.TextEditStyle = TextEditStyles.HideTextEditor;
                        riButtonEdit.ButtonClick += JT_ButtonClick;
                        e.RepositoryItem = riButtonEdit;
                        (e.RepositoryItem as RepositoryItemButtonEdit).Buttons[0].Enabled = true;
                    }
                }
            }
            catch { }
        }

        private void DWG_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                DataRow focusRow = acGridView1.GetFocusedDataRow();

                if (focusRow != null)
                {
                    //GetFile(focusRow, "DWG");
                    CodeHelperManager.acOpenDrawFile.GetFile(this, focusRow, "DWG");
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        private void PDF_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                DataRow focusRow = acGridView1.GetFocusedDataRow();

                if (focusRow != null)
                {
                    //GetFile(focusRow, "PDF");
                    CodeHelperManager.acOpenDrawFile.GetFile(this, focusRow, "PDF");
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        private void JT_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                DataRow focusRow = acGridView1.GetFocusedDataRow();

                if (focusRow != null)
                {
                    //GetFile(focusRow, "JT");
                    CodeHelperManager.acOpenDrawFile.GetFile(this, focusRow, "JT");
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        private void acGridView4_CustomDrawCell1(object sender, RowCellCustomDrawEventArgs e)
        {
            if (e.RowHandle < 0) return;

            acGridView view = sender as acGridView;

            if (view == null) return;

            if (view.RowCount == 0) return;

            string type = view.GetRowCellValue(e.RowHandle, "BAL_STAT").ToString();

            if (type != "11" && type != "20")
            {
                if (e.Column.FieldName == "INS_FLAG"
                    || e.Column.FieldName == "QTY"
                    || e.Column.FieldName == "UNIT_COST"
                    || e.Column.FieldName == "SCOMMENT"
                    || e.Column.FieldName == "REAL_AMT"
                    || e.Column.FieldName == "BANK"
                    || e.Column.FieldName == "BANK_NO"
                    || e.Column.FieldName == "PUR_VEN_ACCOUNT")
                {
                    e.Appearance.BackColor = Color.Transparent;
                }
            }
        }

        private void acGridView4_CustomRowCellEdit(object sender, CustomRowCellEditEventArgs e)
        {
            DataView dv = acGridView4.GetDataSourceView();

            acGridView view = sender as acGridView;

            if (view == null) return;
            if (dv.Count == 0) return;
            if (e.RowHandle < 0) return;

            string type = view.GetRowCellValue(e.RowHandle, "BAL_STAT").ToString();

            if (type != "11" && type != "20")
            {
                if (e.Column.FieldName == "INS_FLAG")
                {
                    e.RepositoryItem = CreateLookupEdit("S063", true);
                }
                else if (e.Column.FieldName == "QTY"
                        || e.Column.FieldName == "UNIT_COST"
                        || e.Column.FieldName == "REAL_AMT")
                {
                    e.RepositoryItem = CreateTextEdit(FormatType.Numeric, "", HorzAlignment.Far, true);
                }
                else if (e.Column.FieldName == "SCOMMENT"
                        || e.Column.FieldName == "BANK"
                        || e.Column.FieldName == "BANK_NO"
                        || e.Column.FieldName == "PUR_VEN_ACCOUNT")
                {
                    e.RepositoryItem = CreateTextEdit(FormatType.None, "", HorzAlignment.Near, true);
                }
            }

        }

        private RepositoryItemLookUpEdit CreateLookupEdit(string catCode, bool isRead)
        {

            RepositoryItemLookUpEdit lookupEdit = new RepositoryItemLookUpEdit();

            LookUpColumnInfo displayColumnInfo = new LookUpColumnInfo();
            LookUpColumnInfo valueColumnInfo = new LookUpColumnInfo();


            displayColumnInfo.FieldName = "CD_NAME";
            displayColumnInfo.Caption = "CD_NAME";

            valueColumnInfo.FieldName = "CD_CODE";
            valueColumnInfo.Caption = "CD_CODE";

            valueColumnInfo.Visible = false;

            lookupEdit.NullText = string.Empty;
            lookupEdit.ShowHeader = false;
            lookupEdit.ShowFooter = true;

            lookupEdit.Columns.Add(displayColumnInfo);
            lookupEdit.Columns.Add(valueColumnInfo);
            lookupEdit.DataSource = acInfo.StdCodes.GetCatTable(catCode);
            lookupEdit.DisplayMember = "CD_NAME";
            lookupEdit.ValueMember = "CD_CODE";
            lookupEdit.ReadOnly = isRead;
            lookupEdit.Appearance.BackColor = Color.Transparent;
            return lookupEdit;
        }

        private RepositoryItemTextEdit CreateTextEdit(DevExpress.Utils.FormatType maskType, string mask, HorzAlignment align, bool isRead)
        {

            RepositoryItemTextEdit textEditItem = new RepositoryItemTextEdit();
            textEditItem.Mask.UseMaskAsDisplayFormat = true;
            //textEditItem.Mask.MaskType = maskType;
            //textEditItem.Mask.EditMask = mask;
            textEditItem.DisplayFormat.FormatType = maskType;
            textEditItem.DisplayFormat.FormatString = mask;
            textEditItem.Appearance.TextOptions.HAlignment = align;
            textEditItem.ReadOnly = isRead;
            textEditItem.Appearance.BackColor = Color.Transparent;
            return textEditItem;
        }

        private void AcLayoutControl2_OnValueKeyDown(object sender, IBaseEditControl info, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                this.Search();
            }
        }

        private void AcLayoutControl2_OnValueChanged(object sender, IBaseEditControl info, object newValue)
        {
            acLayoutControl layout = sender as acLayoutControl;

            switch (info.ColumnName)
            {
                case "DATE":

                    //날짜검색조건이 존재하면 날짜컨트롤을 필수로 바꾼다.

                    if (newValue.EqualsEx(string.Empty))
                    {

                        layout.GetEditor("S_DATE").isRequired = false;
                        layout.GetEditor("E_DATE").isRequired = false;

                    }
                    else
                    {

                        layout.GetEditor("S_DATE").isRequired = true;
                        layout.GetEditor("E_DATE").isRequired = true;
                    }

                    break;

            }
        }



        private void AcGridView4_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;

                if (e.Column.FieldName == "QTY" ||
                e.Column.FieldName == "UNIT_COST" ||
                e.Column.FieldName == "SCOMMENT" )
                {
                    view.SetRowCellValue(e.RowHandle, "STATUS", "UPD");
                    base.MenuStatus = emMenuStatus.WORK;
                }
                
                //view.UpdateCurrentRow();

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void AcTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (acTabControl1.SelectedTabPage.Name == "acTabPage1")
            {
                btnAdd.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                btnDel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                btnEdit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                acBarButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
            else
            {
                btnAdd.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                btnDel.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                btnEdit.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                acBarButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            }
        }

        private void ColumnEdit_EditValueChanging1(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            try
            {
                DevExpress.XtraEditors.TextEdit edit = sender as DevExpress.XtraEditors.TextEdit;

                acGridView view = (edit.Parent as acGridControl).MainView as acGridView;

                DataRow focusedRow = view.GetFocusedDataRow();
                focusedRow["MAT_AMT"] = focusedRow["BAL_QTY"].toInt() * e.NewValue.toDecimal();
                view.UpdateCurrentRow();


            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
           
        }

        private void ColumnEdit_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            try
            {
                DevExpress.XtraEditors.TextEdit edit = sender as DevExpress.XtraEditors.TextEdit;

                acGridView view = (edit.Parent as acGridControl).MainView as acGridView;

                DataRow focusedRow = view.GetFocusedDataRow();
                focusedRow["MAT_AMT"] = e.NewValue.toInt() * focusedRow["MAT_COST"].toDecimal();
                view.UpdateCurrentRow();
                
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void cost_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            try
            {
                DevExpress.XtraEditors.TextEdit edit = sender as DevExpress.XtraEditors.TextEdit;

                acGridView view = (edit.Parent as acGridControl).MainView as acGridView;

                DataRow focusedRow = view.GetFocusedDataRow();
                focusedRow["AMT"] = focusedRow["QTY"].toInt() * e.NewValue.toDecimal();
                view.UpdateCurrentRow();


            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        private void qty_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            try
            {
                DevExpress.XtraEditors.TextEdit edit = sender as DevExpress.XtraEditors.TextEdit;

                acGridView view = (edit.Parent as acGridControl).MainView as acGridView;

                DataRow focusedRow = view.GetFocusedDataRow();
                focusedRow["AMT"] = e.NewValue.toInt() * focusedRow["UNIT_COST"].toDecimal();
                
                view.UpdateCurrentRow();

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }


        public override void ChildContainerInit(Control sender)
        {
            if (sender == acLayoutControl1)
            {
                acLayoutControl layout = sender as acLayoutControl;

                layout.GetEditor("IS_MAIN").Value = "1";

            }
            else if (sender == acLayoutControl2)
            {
                //기본값 설정

                acLayoutControl layout = sender as acLayoutControl;

                layout.GetEditor("DATE").Value = "BALJU_DATE";
                layout.GetEditor("S_DATE").Value = DateTime.Now.AddDays(-7);
                layout.GetEditor("E_DATE").Value = DateTime.Now;

            }

            base.ChildContainerInit(sender);
        }

        private void AcGridView1_MouseDown(object sender, MouseEventArgs e)
        {

            acGridView view = sender as acGridView;

            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                GridHitInfo hitInfo = view.CalcHitInfo(e.Location);

                if (hitInfo.HitTest == GridHitTest.RowCell || hitInfo.HitTest == GridHitTest.Row)
                {
                    DataRow focusRow = view.GetFocusedDataRow();

                    if (focusRow != null)
                    {
                        //acGridView2.UpdateMapingRow(focusRow, true);
                        acGridView2.AddRow(focusRow);
                        //acGridView1.DeleteMappingRow(focusRow);
                    }
                }

            }
        }

        //private void AcGridView1_ShowGridMenuEx(object sender, PopupMenuShowingEventArgs e)
        //{
        //    try
        //    {
        //        acGridView view = sender as acGridView;

                
        //        if (e.HitInfo.HitTest == GridHitTest.Row || e.HitInfo.HitTest == GridHitTest.RowCell)
        //        {
        //            GridHitInfo hitInfo = view.CalcHitInfo(e.Point);

        //            popdown.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
        //            popDel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

        //            popupMenu1.ShowPopup(view.GridControl.PointToScreen(e.Point));
        //        }
        //    }
        //    catch(Exception ex)
        //    {
        //        acMessageBox.Show(this, ex);
        //    }
        //}



        void acGridView1_ShowGridMenuEx(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            acGridView view = sender as acGridView;

            if (e.MenuType == GridMenuType.User)
            {
                acBarButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
              
            }
            else if (e.MenuType == GridMenuType.Row)
            {
                if (e.HitInfo.RowHandle >= 0)
                {
                    acBarButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    
                }
                else
                {
                    acBarButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                }

            }


            if (e.HitInfo.HitTest == GridHitTest.EmptyRow || e.HitInfo.HitTest == GridHitTest.Row || e.HitInfo.HitTest == GridHitTest.RowCell)
            {

                GridHitInfo hitInfo = view.CalcHitInfo(e.Point);

                popdown.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                popDel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

                popupMenu1.ShowPopup(view.GridControl.PointToScreen(e.Point));


            }

        }





        private void AcGridView2_MouseDown(object sender, MouseEventArgs e)
        {
            acGridView view = sender as acGridView;

            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                GridHitInfo hitInfo = view.CalcHitInfo(e.Location);

                if (hitInfo.HitTest == GridHitTest.RowCell || hitInfo.HitTest == GridHitTest.Row)
                {
                    DataRow focusRow = view.GetFocusedDataRow();

                    if (focusRow != null)
                    {
                        //acGridView1.UpdateMapingRow(focusRow, true);
                        acGridView2.DeleteRow(view.FocusedRowHandle);
                        acGridView3.ClearRow();
                        //acGridView2.DeleteMappingRow(focusRow);
                    }
                }

            }
        }

        private void AcGridView2_ShowGridMenuEx(object sender, PopupMenuShowingEventArgs e)
        {
            try
            {
                acGridView view = sender as acGridView;

                if ( e.HitInfo.HitTest == GridHitTest.Row || e.HitInfo.HitTest == GridHitTest.RowCell)
                {
                    GridHitInfo hitInfo = view.CalcHitInfo(e.Point);

                    popdown.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    popDel.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

                    popupMenu1.ShowPopup(view.GridControl.PointToScreen(e.Point));
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void AcGridView2_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            try
            {
                acGridView2.EndEditor();

                if (e.Column.FieldName == "DUE_DATE")
                {
                    
                    DataView dv = acGridView2.GetDataSourceView("DUE_DATE IS NULL");
           
                    if (dv.Count > 0)
                    {
                        foreach (DataRowView drv in dv)
                        {
                            drv["DUE_DATE"] = e.Value;
                        }
                    }

                    //DataRow focusedrow = acGridView2.GetFocusedDataRow();

                    if (acGridView2.IsRowSelected(acGridView2.FocusedRowHandle))
                    {
                        //입고요청일에 날짜가 있어도 선택된 행에서 입고요청일을 변경하면 모든 선택된 행에 동일 변경 처리
                        foreach (DataRow row in acGridView2.GetSelectedDataRows())
                        {
                            row["DUE_DATE"] = e.Value;
                        }
                    }
                    acGridView2.AcceptChanges();
                    acGridView2.ClearSelection();
                }
                else if (e.Column.FieldName == "SUPP_VND")
                {
                    DataView dv = acGridView2.GetDataSourceView("SUPP_VND IS NULL");

                    if (dv.Count > 0)
                    {
                        foreach (DataRowView drv in dv)
                        {
                            drv["SUPP_VND"] = e.Value;
                        }
                    }

                    if (acGridView2.IsRowSelected(acGridView2.FocusedRowHandle))
                    {
                        foreach (DataRow row in acGridView2.GetSelectedDataRows())
                        {
                            row["SUPP_VND"] = e.Value;
                        }
                    }
                    acGridView2.AcceptChanges();
                    acGridView2.ClearSelection();
                }
                else if (e.Column.FieldName == "INS_FLAG")
                {
                    DataView dv = acGridView2.GetDataSourceView("INS_FLAG IS NULL");

                    if (dv.Count > 0)
                    {
                        foreach (DataRowView drv in dv)
                        {
                            drv["INS_FLAG"] = e.Value;
                        }
                    }

                    if (acGridView2.IsRowSelected(acGridView2.FocusedRowHandle))
                    {
                        foreach (DataRow row in acGridView2.GetSelectedDataRows())
                        {
                            row["INS_FLAG"] = e.Value;
                        }
                    }
                    acGridView2.AcceptChanges();
                    acGridView2.ClearSelection();
                }
                else if (e.Column.FieldName == "BAL_UNIT")
                {
                    DataView dv = acGridView2.GetDataSourceView("BAL_UNIT IS NULL");

                    if (dv.Count > 0)
                    {
                        foreach (DataRowView drv in dv)
                        {
                            drv["BAL_UNIT"] = e.Value;
                        }
                    }

                    if (acGridView2.IsRowSelected(acGridView2.FocusedRowHandle))
                    {
                        foreach (DataRow row in acGridView2.GetSelectedDataRows())
                        {
                            row["BAL_UNIT"] = e.Value;
                        }
                    }
                    acGridView2.AcceptChanges();
                    acGridView2.ClearSelection();
                }



            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
            
        }


        private void AcGridView2_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            this.SearchHistory();
        }

        void acLayoutControl1_OnValueChanged(object sender, IBaseEditControl info, object newValue)
        {
            acLayoutControl layout = sender as acLayoutControl;
            switch (info.ColumnName)
            {
                case "MAT_LTYPE":

                    layout.GetEditor("MAT_MTYPE").Value = null;
                    layout.GetEditor("MAT_STYPE").Value = null;

                    if (newValue == null) return;

                    (layout.GetEditor("MAT_MTYPE").Editor as acLookupEdit).SetCode("M015", newValue);

                    break;

                case "MAT_MTYPE":

                    layout.GetEditor("MAT_STYPE").Value = null;

                    if (newValue == null) return;

                    (layout.GetEditor("MAT_STYPE").Editor as acLookupEdit).SetCode("M016", newValue);

                    break;
            }

        }

        void acLayoutControl1_OnValueKeyDown(object sender, IBaseEditControl info, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                this.Search();
            }
        }

        private void barItemRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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


        void Search()
        {
           try
           {
                if (acTabControl1.SelectedTabPage == acTabPage1)
                {
                    DataRow layoutRow = acLayoutControl1.CreateParameterRow();

                    DataTable paramTable = new DataTable("RQSTDT");
                    paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                    paramTable.Columns.Add("PART_PRODTYPE", typeof(String)); //

                    paramTable.Columns.Add("MAT_LTYPE", typeof(String)); //            
                    paramTable.Columns.Add("MAT_MTYPE", typeof(String)); //
                    paramTable.Columns.Add("MAT_STYPE", typeof(String)); //

                    paramTable.Columns.Add("PART_LIKE", typeof(String)); // 
                    paramTable.Columns.Add("UNDER_SAFE", typeof(String)); // 

                    paramTable.Columns.Add("IS_MAIN", typeof(String)); // 

                    DataRow paramRow = paramTable.NewRow();
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["PART_PRODTYPE"] = layoutRow["PART_PRODTYPE"];

                    paramRow["MAT_LTYPE"] = layoutRow["MAT_LTYPE"];
                    paramRow["MAT_MTYPE"] = layoutRow["MAT_MTYPE"];
                    paramRow["MAT_STYPE"] = layoutRow["MAT_STYPE"];

                    paramRow["PART_LIKE"] = layoutRow["PART_LIKE"];
                    if (layoutRow["UNDER_SAFE"].ToString() == "1")
                        paramRow["UNDER_SAFE"] = "1";

                    if (layoutRow["IS_MAIN"].ToString() == "1")
                    {
                        paramRow["IS_MAIN"] = "1";
                    }

                    paramTable.Rows.Add(paramRow);

                    DataSet paramSet = new DataSet();
                    paramSet.Tables.Add(paramTable);


                    BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD_DETAIL, "PUR01A_SER", paramSet, "RQSTDT", "RSLTDT",
                                QuickSearch,
                                QuickException);
                }
                else
                {

                    DataRow layoutRow = acLayoutControl2.CreateParameterRow();

                    DataTable paramTable = new DataTable("RQSTDT");
                    paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                    paramTable.Columns.Add("S_BALJU_DATE", typeof(String)); //
                    paramTable.Columns.Add("E_BALJU_DATE", typeof(String)); //            
                    paramTable.Columns.Add("PART_LIKE", typeof(String)); //            
                    paramTable.Columns.Add("BALJU_LIKE", typeof(String)); //     
                    paramTable.Columns.Add("CHARGE_LIKE", typeof(String)); //     

                    DataRow paramRow = paramTable.NewRow();
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["PART_LIKE"] = layoutRow["PART_LIKE"];
                    paramRow["BALJU_LIKE"] = layoutRow["BALJU_LIKE"];
                    paramRow["CHARGE_LIKE"] = layoutRow["CHARGE_LIKE"];

                    foreach (string key in acCheckedComboBoxEdit2.GetKeyChecked())
                    {
                        switch (key)
                        {
                            case "BALJU_DATE":

                                paramRow["S_BALJU_DATE"] = layoutRow["S_DATE"];
                                paramRow["E_BALJU_DATE"] = layoutRow["E_DATE"];

                                break;
                        }
                    }


                    paramTable.Rows.Add(paramRow);

                    DataSet paramSet = new DataSet();                    
                    paramSet.Tables.Add(paramTable);


                    BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD_DETAIL, "PUR01A_SER2", paramSet, "RQSTDT", "RSLTDT",
                                QuickSearch2,
                                QuickException);
                }
                
                
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
            
        }

        void SearchHistory()
        {
            try
            {
                DataRow focusedRow = acGridView2.GetFocusedDataRow();

                if (focusedRow == null)
                {
                    acGridView3.ClearRow();
                    return;
                }
                
                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("PART_CODE", typeof(String)); //
                paramTable.Columns.Add("S_BALJU_DATE", typeof(String)); //            
                paramTable.Columns.Add("E_BALJU_DATE", typeof(String)); //            

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["PART_CODE"] = focusedRow["PART_CODE"];
                paramRow["S_BALJU_DATE"] = DateTime.Today.AddDays(-90).toDateString("yyyyMMdd");
                paramRow["E_BALJU_DATE"] = DateTime.Today.toDateString("yyyyMMdd");
                paramTable.Rows.Add(paramRow);

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD_DETAIL, "PUR01A_SER3", paramSet, "RQSTDT", "RSLTDT",
                            QuickSearchHistory,
                            QuickException);
               


            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }
        void QuickSearchHistory(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                acGridView3.GridControl.DataSource = e.result.Tables["RSLTDT"];

                //base.SetLog(e.executeType, e.result.Tables["RSLTDT"].Rows.Count, e.executeTime);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        DataTable _dwgFileDT = new DataTable();
        void QuickSearch(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                acGridView1.GridControl.DataSource = e.result.Tables["RSLTDT"];
                
                _dwgFileDT = CodeHelperManager.acOpenDrawFile.GetFileExists();

                base.SetLog(e.executeType, e.result.Tables["RSLTDT"].Rows.Count, e.executeTime);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        void QuickSearch2(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                acGridView4.GridControl.DataSource = e.result.Tables["RSLTDT"];

                base.SetLog(e.executeType, e.result.Tables["RSLTDT"].Rows.Count, e.executeTime);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }



        void QuickException(object sender, QBiz qBiz, BizManager.BizException ex)
        {
            acMessageBox.Show(this, ex);
        }

        private void popdown_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                acGridView1.EndEditor();

                DataRow[] selectedRows = acGridView1.GetSelectedDataRows();

                if (selectedRows.Length == 0)
                {
                    DataRow focusedrow = acGridView1.GetFocusedDataRow();
                    acGridView2.AddRow(focusedrow);
                    //acGridView2.UpdateMapingRow(focusedrow, true);

                }
                else
                {
                    acGridView2.AcceptChanges();
                    DataTable dtData = acGridView2.GridControl.DataSource as DataTable;

                    foreach (DataRow dr in selectedRows)
                    {
                        //DataRow data = dtData.NewRow();
                        dr["BAL_QTY"] = 1;
                        dr["MAT_AMT"] = dr["MAT_COST"];

                        dtData.ImportRow(dr);
                        
                    }

                    acGridView1.ClearSelection();
                    
                }
                
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void popDel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                acGridView2.EndEditor();

                DataRow[] selectedRows = acGridView2.GetSelectedDataRows();

                if (selectedRows.Length == 0)
                {
                    DataRow focusedrow = acGridView2.GetFocusedDataRow();
                    acGridView1.UpdateMapingRow(focusedrow, true);

                    acGridView2.DeleteMappingRow(focusedrow);
                    acGridView3.ClearRow();
                }
                else
                {
                    foreach (DataRow dr in selectedRows)
                    {
                        
                        acGridView1.UpdateMapingRow(dr, true);
                    }

                    acGridView2.DeleteSelectedRows();
                    acGridView3.ClearRow();
                }
                

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void btnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                //발주
                acGridView2.EndEditor();

                if (!acGridView2.ValidCheck()) return;

                DataView selectedView = acGridView2.GetDataSourceView();

                if (selectedView.Count == 0) return;
                
                DataRow[] invalidrows = selectedView.ToTable().Select("ISNULL(BAL_QTY, 0) = 0");

                if (invalidrows.Length > 0)
                {
                    acMessageBox.Show("발주 수량이 0인 항목이 있습니다. 수량을 확인하세요. ", "구매 발주", acMessageBox.emMessageBoxType.CONFIRM);
                    return;
                }


                PUR01A_D0A frm = new PUR01A_D0A(selectedView, acGridView2, "MAT");
                frm.ParentControl = this;

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    acAlert.Show(this, "발주 되었습니다.", acAlertForm.enmType.Success);
                }
                
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void btnDel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                acGridView4.EndEditor();

                DataRow focusedRow = acGridView4.GetFocusedDataRow();

                DataRow[] selectedRows = acGridView4.GetSelectedDataRows();

                if (focusedRow == null) return;

                if (focusedRow["BAL_STAT"].ToString() != "11"
                        && focusedRow["BAL_STAT"].ToString() != "20")
                {
                    acAlert.Show(this, "발주 또는 검사대기 상태만 취소가능합니다.", acAlertForm.enmType.Info);
                    return;
                }

                foreach (DataRow row in selectedRows)
                {
                    if (row["BAL_STAT"].ToString() != "11"
                        && row["BAL_STAT"].ToString() != "20")
                    {
                        acAlert.Show(this, "발주 또는 검사대기 상태만 취소가능합니다.", acAlertForm.enmType.Info);
                        return;
                    }
                }

                if (acMessageBox.Show("선택한 발주건을 취소하시겠습니까?", "자재 발주", acMessageBox.emMessageBoxType.YESNO) == DialogResult.No) return;

                //발주 취소
                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(string));
                paramTable.Columns.Add("BALJU_NUM", typeof(string));
                paramTable.Columns.Add("BALJU_SEQ", typeof(string));

                if (selectedRows.Length == 0)
                {
                    DataRow dr = paramTable.NewRow();
                    dr["PLT_CODE"] = acInfo.PLT_CODE;
                    dr["BALJU_NUM"] = focusedRow["BALJU_NUM"];
                    dr["BALJU_SEQ"] = focusedRow["BALJU_SEQ"];
                    paramTable.Rows.Add(dr);
                }
                else
                {
                    foreach (DataRow row in selectedRows)
                    {
                        DataRow dr = paramTable.NewRow();
                        dr["PLT_CODE"] = acInfo.PLT_CODE;
                        dr["BALJU_NUM"] = row["BALJU_NUM"];
                        dr["BALJU_SEQ"] = row["BALJU_SEQ"];
                        paramTable.Rows.Add(dr);
                    }
                }
                

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(
                        this, QBiz.emExecuteType.SAVE, "PUR01A_DEL", paramSet, "RQSTDT_V,RQSTDT", "RSLTDT",
                        QuickDel,
                        QuickException);


            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void QuickDel(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            //자재발주 후
            try
            {

                foreach (DataRow row in e.result.Tables["RQSTDT"].Rows)
                {
                    acGridView4.DeleteMappingRow(row);
                }

                acAlert.Show(this, "발주 취소되었습니다.", acAlertForm.enmType.Success);

                base.SetLog(e.executeType, e.result.Tables["RQSTDT"].Rows.Count, e.executeTime);

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                acGridView4.EndEditor();

                DataTable modifyData = acGridView4.GetAddModifyRows();

                if (modifyData.Rows.Count == 0) return;
                
                if (acMessageBox.Show("발주 내역을 수정하시겠습니까?", "자재 발주", acMessageBox.emMessageBoxType.YESNO) == DialogResult.No) return;

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("UNIT_COST", typeof(Decimal)); //
                paramTable.Columns.Add("QTY", typeof(Int32)); //
                paramTable.Columns.Add("AMT", typeof(Decimal)); //
                paramTable.Columns.Add("SCOMMENT", typeof(String)); //
                paramTable.Columns.Add("REG_EMP", typeof(String)); //
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("BALJU_NUM", typeof(String)); //
                paramTable.Columns.Add("BALJU_SEQ", typeof(Int32)); //
                paramTable.Columns.Add("STATUS", typeof(String)); //
                paramTable.Columns.Add("INS_FLAG", typeof(String)); //
                paramTable.Columns.Add("REAL_AMT", typeof(Decimal)); //
                paramTable.Columns.Add("BANK", typeof(String)); //
                paramTable.Columns.Add("BANK_NO", typeof(String)); //
                paramTable.Columns.Add("PUR_VEN_ACCOUNT", typeof(String)); //

                foreach (DataRow row in modifyData.Rows)
                {
                    DataRow paramRow = paramTable.NewRow();
                    paramRow["UNIT_COST"] = row["UNIT_COST"];
                    paramRow["QTY"] = row["QTY"];
                    paramRow["AMT"] = row["AMT"];
                    paramRow["SCOMMENT"] = row["SCOMMENT"];
                    paramRow["REG_EMP"] = acInfo.UserID;
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["BALJU_NUM"] = row["BALJU_NUM"];
                    paramRow["BALJU_SEQ"] = row["BALJU_SEQ"];
                    paramRow["STATUS"] = "";
                    paramRow["INS_FLAG"] = row["INS_FLAG"];
                    paramRow["REAL_AMT"] = row["REAL_AMT"];
                    paramRow["BANK"] = row["BANK"];
                    paramRow["BANK_NO"] = row["BANK_NO"];
                    paramRow["PUR_VEN_ACCOUNT"] = row["PUR_VEN_ACCOUNT"];

                    paramTable.Rows.Add(paramRow);
                }


                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);


                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.PROCESS, "PUR01A_UPD", paramSet, "RQSTDT", "",
                    QuickUpdate,
                    QuickException);

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void QuickUpdate(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            //자재발주 수정 후
            try
            {
                foreach(DataRow dr in e.result.Tables["RQSTDT"].Rows)   
                {
                    acGridView4.UpdateMapingRow(dr, false);
                }

                acGridView4.ClearSelection();

                base.MenuStatus = emMenuStatus.NONE;

                acAlert.Show(this, "발주 내역이 수정되었습니다.", acAlertForm.enmType.Success);

                //alertControl1.FormLocation = DevExpress.XtraBars.Alerter.AlertFormLocation.TopLeft;
                //alertControl1.AutoFormDelay = 2000;
                //alertControl1.FormShowingEffect = DevExpress.XtraBars.Alerter.AlertFormShowingEffect.SlideVertical;

                //alertControl1.Show(this.Menu.MainControl as Form, "자재 발주", "내역이 수정되었습니다", true);


                base.SetLog(e.executeType, e.result.Tables["RQSTDT"].Rows.Count, e.executeTime);

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        private void acBarButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // 도면 보기
        }

        private void acBarButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            acGridView4.EndEditor();

            if (!acGridView4.ValidCheck()) return;

            DataView selectedView = acGridView4.GetDataSourceView();

            if (selectedView.Count == 0) return;

            DataRow focusRow = acGridView4.GetFocusedDataRow();

            if (focusRow == null) return;

            PUR01A_D1A frm = new PUR01A_D1A(acGridView4, focusRow);

            frm.ParentControl = this;

            if (frm.ShowDialog() == DialogResult.OK)
            {
                acAlert.Show(this, "수정 되었습니다.", acAlertForm.enmType.Success);
            }
        }
    }
}
