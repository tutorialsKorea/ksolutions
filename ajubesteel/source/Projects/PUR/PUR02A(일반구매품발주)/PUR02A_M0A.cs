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
using DevExpress.Utils;
using DevExpress.XtraEditors.Controls;

namespace PUR
{

    public sealed partial class PUR02A_M0A : BaseMenu
    {
        public PUR02A_M0A()
        {
            InitializeComponent();

            acLayoutControl1.OnValueChanged += acLayoutControl1_OnValueChanged;
            acLayoutControl1.OnValueKeyDown += acLayoutControl1_OnValueKeyDown;

            acLayoutControl2.OnValueChanged += AcLayoutControl2_OnValueChanged;
            acLayoutControl2.OnValueKeyDown += AcLayoutControl2_OnValueKeyDown;

            acGridView1.ShowGridMenuEx += AcGridView1_ShowGridMenuEx;
            acGridView1.MouseDown += AcGridView1_MouseDown;
            acGridView2.FocusedRowChanged += AcGridView2_FocusedRowChanged;
            acGridView2.CellValueChanged += AcGridView2_CellValueChanged;
            acGridView2.MouseDown += AcGridView2_MouseDown;
            acGridView2.ShowGridMenuEx += AcGridView2_ShowGridMenuEx;


            acGridView4.FocusedRowChanged += acGridView4_FocusedRowChanged;

            acTabControl1.SelectedPageChanged += AcTabControl1_SelectedPageChanged;
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
                acGridView1.AddTextEdit("PART_NAME", "자재 중분류명", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView1.AddLookUpVendor("MAIN_VND", "외주업체", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false);
                acGridView1.AddLookUpVendor("SUPP_VND", "공급사", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false);
                acGridView1.AddTextEdit("VEN_ACCOUNT", "예금주", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView1.AddTextEdit("STK_QTY", "재고 수량", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
                acGridView1.AddTextEdit("SAFE_STK_QTY", "안전 재고", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
                acGridView1.AddLookUpEdit("MAT_UNIT", "단위", "40123", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M003");
                acGridView1.AddTextEdit("MAT_COST", "자재 단가", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
                acGridView1.AddTextEdit("SCOMMENT", "비고", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
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
                acGridView2.AddTextEdit("PART_NAME", "자재 중분류명", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView2.AddLookUpVendor("MAIN_VND", "외주업체", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false);
                acGridView2.AddTextEdit("DETAIL_PART_NAME", "세부 자재명", "", false, DevExpress.Utils.HorzAlignment.Near, true, true, false, acGridView.emTextEditMask.NONE);
                acGridView2.AddLookUpVendor("SUPP_VND", "공급사", "", false, DevExpress.Utils.HorzAlignment.Center, true, true, true);
                acGridView2.AddDateEdit("DUE_DATE", "입고요청일", "", false, DevExpress.Utils.HorzAlignment.Center, true, true, true, acGridView.emDateMask.SHORT_DATE);
                acGridView2.AddTextEdit("BAL_QTY", "발주 수량", "", false, DevExpress.Utils.HorzAlignment.Far, true, true, true, acGridView.emTextEditMask.QTY);
                acGridView2.AddLookUpEdit("MAT_UNIT", "단위", "40123", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M003");
                acGridView2.AddTextEdit("MAT_COST", "단가", "", false, DevExpress.Utils.HorzAlignment.Far, true, true, false, acGridView.emTextEditMask.MONEY);
                acGridView2.AddLookUpEdit("BAL_UNIT", "금액단위", "", false, DevExpress.Utils.HorzAlignment.Center, true, true, false, "P008");
                acGridView2.AddTextEdit("MAT_AMT", "금액", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);

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
                acGridView3.AddLookUpEdit("MAT_LTYPE", "대분류", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M014");
                acGridView3.AddLookUpEdit("MAT_MTYPE", "중분류", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M015");
                acGridView3.AddLookUpEdit("MAT_STYPE", "소분류", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M016");
                //acGridView3.AddLookUpEdit("MAT_TYPE1", "자재구분", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, "M001");
                //acGridView3.AddLookUpEdit("MAT_TYPE2", "자재유형", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, "M002");
                acGridView3.AddTextEdit("BALJU_NUM", "발주번호", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView3.AddTextEdit("BALJU_SEQ", "순번", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView3.AddLookUpVendor("MVND_CODE", "발주처", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false);
                
                acGridView3.AddDateEdit("BAL_DATE", "발주일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
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
                //acGridView4.AddLookUpEdit("PART_PRODTYPE", "분류", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M007");
                acGridView4.AddTextEdit("DETAIL_PART_NAME", "세부 자재명", "", false, DevExpress.Utils.HorzAlignment.Near, true, true, false, acGridView.emTextEditMask.NONE);
                acGridView4.AddLookUpEdit("MAT_LTYPE", "대분류", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M014");
                acGridView4.AddLookUpEdit("MAT_MTYPE", "중분류", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M015");
                acGridView4.AddLookUpEdit("MAT_STYPE", "소분류", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M016");
                //acGridView4.AddLookUpEdit("MAT_TYPE1", "자재구분", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M001");
                //acGridView4.AddLookUpEdit("MAT_TYPE2", "자재유형", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M002");
                //acGridView4.AddLookUpEdit("MAT_MTYPE", "구분", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M001");
                acGridView4.AddLookUpVendor("MVND_CODE", "발주처", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false);
                acGridView4.AddDateEdit("BALJU_DATE", "발주일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
                acGridView4.AddDateEdit("DUE_DATE", "입고예정일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
                acGridView4.AddTextEdit("STATUS", "비고", "", false, DevExpress.Utils.HorzAlignment.Near, false, false, false, acGridView.emTextEditMask.NONE);
                acGridView4.AddTextEdit("QTY", "발주수량", "", false, DevExpress.Utils.HorzAlignment.Far, true, true, false, acGridView.emTextEditMask.QTY);                
                acGridView4.AddLookUpEdit("MAT_UNIT", "단위", "40123", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M003");
                acGridView4.AddTextEdit("UNIT_COST", "단가", "", false, DevExpress.Utils.HorzAlignment.Far, true, true, false, acGridView.emTextEditMask.MONEY);
                acGridView4.AddLookUpEdit("BAL_UNIT", "금액단위", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P008");
                acGridView4.AddTextEdit("AMT", "금액", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);

                acGridView4.AddTextEdit("PAY_CONDITION", "결제 조건", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

                acGridView4.AddTextEdit("REAL_AMT", "실제 입금금액", "", false, DevExpress.Utils.HorzAlignment.Far, true, true, false, acGridView.emTextEditMask.MONEY);
                acGridView4.AddTextEdit("BANK", "은행", "", false, DevExpress.Utils.HorzAlignment.Near, true, true, false, acGridView.emTextEditMask.NONE);
                acGridView4.AddTextEdit("PUR_VEN_ACCOUNT", "예금주", "", false, DevExpress.Utils.HorzAlignment.Center, true, true, false, acGridView.emTextEditMask.NONE);
                acGridView4.AddTextEdit("BANK_NO", "계좌번호", "", false, DevExpress.Utils.HorzAlignment.Near, true, true, false, acGridView.emTextEditMask.NONE);

                acGridView4.AddTextEdit("SCOMMENT", "비고", "", false, DevExpress.Utils.HorzAlignment.Near, true, true, false, acGridView.emTextEditMask.NONE);

                acGridView4.AddTextEdit("REG_EMP", "발주자코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
                acGridView4.AddTextEdit("REG_EMP_NAME", "발주자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

                acGridView4.AddLookUpEdit("APP_STATUS", "승인상태", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "W008");

                acGridView4.KeyColumn = new string[] { "BALJU_NUM", "BALJU_SEQ" };
                //acGridView4.AddHidden("STATUS", typeof(string));

                //acGridView4.OptionsSelection.MultiSelect = true;
                //acGridView4.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CheckBoxRowSelect;


                acGridView4.Columns["QTY"].ColumnEdit.EditValueChanging += qty_EditValueChanging;
                acGridView4.Columns["UNIT_COST"].ColumnEdit.EditValueChanging += cost_EditValueChanging;
                acGridView4.CellValueChanged += AcGridView4_CellValueChanged;
                acCheckedComboBoxEdit2.AddItem("발주일", true, "40206", "BALJU_DATE", true, false);

                //(acLayoutControl1.GetEditor("MAT_TYPE1") as acLookupEdit).SetCode("M001");
                //(acLayoutControl1.GetEditor("MAT_TYPE2") as acLookupEdit).SetCode("M002");
                //(acLayoutControl1.GetEditor("PART_PRODTYPE") as acLookupEdit).SetCode("M007");

                (acLayoutControl1.GetEditor("MAT_LTYPE") as acLookupEdit).SetCode("M014"); //대분류
                //(acLayoutControl1.GetEditor("MAT_MTYPE") as acLookupEdit).SetCode("M015"); //중분류
                //(acLayoutControl1.GetEditor("MAT_STYPE") as acLookupEdit).SetCode("M016"); //소분류

                btnEdit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                btnDel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

                base.MenuStatus = emMenuStatus.NONE;

                acGridView4.CustomRowCellEdit += acGridView4_CustomRowCellEdit;

                acGridView4.CustomDrawCell += acGridView4_CustomDrawCell1;

                base.MenuInit();
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

            bool isMdf = true;

            if (type == "11")
            {
                isMdf = false;
            }
            else if (type == "23")
            {
                isMdf = false;
            }

            if (isMdf)
            {
                if (e.Column.FieldName == "INS_FLAG"
                    || e.Column.FieldName == "QTY"
                    || e.Column.FieldName == "UNIT_COST"
                    || e.Column.FieldName == "SCOMMENT"
                    || e.Column.FieldName == "REAL_AMT"
                    || e.Column.FieldName == "BANK"
                    || e.Column.FieldName == "BANK_NO"
                    || e.Column.FieldName == "DETAIL_PART_NAME"
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

            bool isMdf = true;

            if (type == "11")
            {
                isMdf = false;
            }
            else if (type == "23")
            {
                isMdf = false;
            }

            if (isMdf)
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
                        || e.Column.FieldName == "DETAIL_PART_NAME"
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
            }
            else
            {
                btnAdd.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                btnDel.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                btnEdit.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
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
            if (sender == acLayoutControl2)
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
                        acGridView2.AddRow(focusRow);
                        //acGridView2.UpdateMapingRow(focusRow, true);

                        //acGridView1.DeleteMappingRow(focusRow);
                    }
                }

            }
        }

        private void AcGridView1_ShowGridMenuEx(object sender, PopupMenuShowingEventArgs e)
        {
            try
            {
                acGridView view = sender as acGridView;

                if (e.HitInfo.HitTest == GridHitTest.Row || e.HitInfo.HitTest == GridHitTest.RowCell)
                {
                    GridHitInfo hitInfo = view.CalcHitInfo(e.Point);

                    popdown.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    popDel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

                    popupMenu1.ShowPopup(view.GridControl.PointToScreen(e.Point));
                }
            }
            catch(Exception ex)
            {
                acMessageBox.Show(this, ex);
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
                        acGridView1.UpdateMapingRow(focusRow, true);

                        acGridView2.DeleteMappingRow(focusRow);
                        acGridView3.ClearRow();
                    }
                }

            }
        }

        private void AcGridView2_ShowGridMenuEx(object sender, PopupMenuShowingEventArgs e)
        {
            try
            {
                acGridView view = sender as acGridView;

                if (e.HitInfo.HitTest == GridHitTest.Row || e.HitInfo.HitTest == GridHitTest.RowCell)
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
                if (e.Column.FieldName == "DUE_DATE")
                {
                    acGridView2.EndEditor();
                    DataView dv = acGridView2.GetDataSourceView("DUE_DATE IS NULL");


                    foreach (DataRowView drv in dv)
                    {
                        drv["DUE_DATE"] = e.Value;

                    }

                    DataRow focusedrow = acGridView2.GetFocusedDataRow();

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

                    DataRow paramRow = paramTable.NewRow();
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["PART_PRODTYPE"] = layoutRow["PART_PRODTYPE"];

                    paramRow["MAT_LTYPE"] = layoutRow["MAT_LTYPE"];
                    paramRow["MAT_MTYPE"] = layoutRow["MAT_MTYPE"];
                    paramRow["MAT_STYPE"] = layoutRow["MAT_STYPE"];
   
                    paramRow["PART_LIKE"] = layoutRow["PART_LIKE"];
                    if (layoutRow["UNDER_SAFE"].ToString() == "1")
                        paramRow["UNDER_SAFE"] = "1";
                    paramTable.Rows.Add(paramRow);

                    DataSet paramSet = new DataSet();
                    paramSet.Tables.Add(paramTable);


                    BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD_DETAIL, "PUR02A_SER", paramSet, "RQSTDT", "RSLTDT",
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

                    DataRow paramRow = paramTable.NewRow();
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["PART_LIKE"] = layoutRow["PART_LIKE"];

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


                    BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD_DETAIL, "PUR02A_SER2", paramSet, "RQSTDT", "RSLTDT",
                                QuickSearch2,
                                QuickException);
                }
                
                
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
            
        }

        

        void QuickSearch(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                acGridView1.GridControl.DataSource = e.result.Tables["RSLTDT"];
                acGridView1.SetOldFocusRowHandle(false);

                base.SetLog(e.executeType, e.result.Tables["RSLTDT"].Rows.Count, e.executeTime);
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

                if (focusedRow == null) return;

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
        void QuickSearch2(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                acGridView4.GridControl.DataSource = e.result.Tables["RSLTDT"];
                acGridView4.SetOldFocusRowHandle(false);

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

                    //acGridView1.DeleteMappingRow(focusedrow);
                }
                else
                {
                    acGridView2.AcceptChanges();
                    DataTable dtData = acGridView2.GridControl.DataSource as DataTable;

                    foreach (DataRow dr in selectedRows)
                    {
                        dtData.ImportRow(dr);
                        //DataRow newrow = dr.NewCopy();
                        //acGridView2.UpdateMapingRow(newrow, true);
                    }

                    acGridView1.ClearSelection();
                    //acGridView1.DeleteSelectedRows();
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
                    DataRow focusedRow = acGridView2.GetFocusedDataRow();
                    acGridView1.UpdateMapingRow(focusedRow, true);

                    acGridView2.DeleteMappingRow(focusedRow);
                    acGridView3.ClearRow();
                }
                else
                {
                    foreach (DataRow dr in selectedRows)
                    {
                        //acGridView2.DeleteMappingRow(dr);
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

                PUR01A_D0A frm = new PUR01A_D0A(selectedView, acGridView2, "PUR");
                //PUR01A_D0A frm = new PUR01A_D0A();
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

        void QuickBalju(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            //자재발주 후
            try
            {

                acGridView2.ClearRow();


                base.SetLog(e.executeType, e.result.Tables["RQSTDT"].Rows.Count, e.executeTime);

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
                    DataRow focusedrow = acGridView4.GetFocusedDataRow();

                    DataRow dr = paramTable.NewRow();
                    dr["PLT_CODE"] = acInfo.PLT_CODE;
                    dr["BALJU_NUM"] = focusedrow["BALJU_NUM"];
                    dr["BALJU_SEQ"] = focusedrow["BALJU_SEQ"];
                    paramTable.Rows.Add(dr);
                }
                else
                {
                    foreach (DataRow row in acGridView4.GetSelectedDataRows())
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
                        this, QBiz.emExecuteType.SAVE, "PUR02A_DEL", paramSet, "RQSTDT_V,RQSTDT", "RSLTDT",
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
                paramTable.Columns.Add("REAL_AMT", typeof(Decimal)); //
                paramTable.Columns.Add("BANK", typeof(String)); //
                paramTable.Columns.Add("BANK_NO", typeof(String)); //
                paramTable.Columns.Add("DETAIL_PART_NAME", typeof(String)); //
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
                    paramRow["REAL_AMT"] = row["REAL_AMT"];
                    paramRow["BANK"] = row["BANK"];
                    paramRow["BANK_NO"] = row["BANK_NO"];
                    paramRow["DETAIL_PART_NAME"] = row["DETAIL_PART_NAME"];
                    paramRow["PUR_VEN_ACCOUNT"] = row["PUR_VEN_ACCOUNT"];
                    paramTable.Rows.Add(paramRow);
                }


                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);


                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.PROCESS, "PUR02A_UPD", paramSet, "RQSTDT", "",
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
                foreach (DataRow dr in e.result.Tables["RQSTDT"].Rows)
                {
                    acGridView4.UpdateMapingRow(dr, false);
                }

                acGridView4.ClearSelection();

                base.MenuStatus = emMenuStatus.NONE;

                acAlert.Show(this, "발주 내역이 수정되었습니다.", acAlertForm.enmType.Success);

                base.SetLog(e.executeType, e.result.Tables["RQSTDT"].Rows.Count, e.executeTime);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }
    }
}

