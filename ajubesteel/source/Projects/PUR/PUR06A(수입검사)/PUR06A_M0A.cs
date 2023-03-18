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
using DevExpress.XtraEditors.Controls;
using DevExpress.Utils;

namespace PUR
{

    public sealed partial class PUR06A_M0A : BaseMenu
    {
        public PUR06A_M0A()
        {
            InitializeComponent();

            acLayoutControl1.OnValueChanged += acLayoutControl1_OnValueChanged;
            acLayoutControl1.OnValueKeyDown += acLayoutControl1_OnValueKeyDown;

            acLayoutControl2.OnValueChanged += AcLayoutControl2_OnValueChanged;
            acLayoutControl2.OnValueKeyDown += AcLayoutControl2_OnValueKeyDown;

            // acGridView1.ShowGridMenuEx += AcGridView1_ShowGridMenuEx;

            acGridView1.ShowGridMenuEx += acGridView1_ShowGridMenuEx;

            acGridView1.FocusedRowChanged += AcGridView1_FocusedRowChanged;

            acGridView4.FocusedRowChanged += acGridView4_FocusedRowChanged;

            acTabControl1.SelectedPageChanged += AcTabControl1_SelectedPageChanged;

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

            base.MenuDestory(sender);

            acAttachFileControl2.Close();

            return acAttachFileControl1.Close();

        }

        public override void MenuInit()
        {
            try
            {
    
                acGridView1.GridType = acGridView.emGridType.SEARCH_SEL ;
                acGridView1.AddTextEdit("BALJU_NUM", "발주번호", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView1.AddTextEdit("BALJU_SEQ", "순번", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView1.AddTextEdit("PROD_CODE", "수주코드", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView1.AddTextEdit("PROD_NAME", "모델명", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView1.AddTextEdit("WO_NO", "작업지시번호", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

                acGridView1.AddDateEdit("ORD_DATE", "수주일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
                acGridView1.AddDateEdit("ORD_DUE_DATE", "출하예정일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
                acGridView1.AddDateEdit("CHG_DUE_DATE", "출하조정일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);

                acGridView1.AddTextEdit("PART_CODE", "자재코드", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView1.AddTextEdit("PART_NAME", "자재명", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                //acGridView1.AddLookUpEdit("PART_PRODTYPE", "분류", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M007");
                acGridView1.AddLookUpEdit("MAT_LTYPE", "대분류", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M014");
                acGridView1.AddLookUpVendor("VND_CODE", "발주처", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false);
                acGridView1.AddDateEdit("BALJU_DATE", "발주일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
                acGridView1.AddDateEdit("DUE_DATE", "입고예정일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
                acGridView1.AddTextEdit("QTY", "발주수량", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
                acGridView1.AddLookUpEdit("MAT_UNIT", "단위", "40123", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M003");
                acGridView1.AddTextEdit("INS_QTY", "검사수량", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
                acGridView1.AddTextEdit("NG_QTY", "불량수량", "", false, DevExpress.Utils.HorzAlignment.Far, true, true, false, acGridView.emTextEditMask.QTY);
                acGridView1.AddLookUpEdit("MASTER_CAUSE", "불량처리", "40123", false, DevExpress.Utils.HorzAlignment.Near, true, true, false, "C402");
                
                //acGridView1.AddTextEdit("UNIT_COST", "단가", "", false, DevExpress.Utils.HorzAlignment.Far, true, true, false, acGridView.emTextEditMask.MONEY);
                //acGridView1.AddTextEdit("AMT", "금액", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
                acGridView1.AddTextEdit("SCOMMENT", "발주비고", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView1.AddTextEdit("IN_SCOMMENT", "불량 비고", "", false, DevExpress.Utils.HorzAlignment.Near, true, true, false, acGridView.emTextEditMask.NONE);
                acGridView1.AddLookUpEmp("REG_EMP", "발주자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false);

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


                acGridView1.Columns["NG_QTY"].ColumnEdit.EditValueChanged += ColumnEdit_EditValueChanged; 
                //acGridView4.Columns["UNIT_COST"].ColumnEdit.EditValueChanging += cost_EditValueChanging;

                acGridView1.KeyColumn = new string[] { "BALJU_NUM", "BALJU_SEQ" };


                acGridView4.GridType = acGridView.emGridType.SEARCH_SEL;
                acGridView4.AddTextEdit("BALJU_NUM", "발주번호", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView4.AddTextEdit("BALJU_SEQ", "순번", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

                acGridView4.AddLookUpEdit("BAL_STAT", "발주 상태", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "S043");

                acGridView4.AddTextEdit("PROD_CODE", "수주코드", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView4.AddTextEdit("PROD_NAME", "모델명", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView4.AddTextEdit("WO_NO", "작업지시번호", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

                acGridView4.AddDateEdit("ORD_DATE", "수주일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
                acGridView4.AddDateEdit("ORD_DUE_DATE", "출하예정일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
                acGridView4.AddDateEdit("CHG_DUE_DATE", "출하조정일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);

                acGridView4.AddTextEdit("PART_CODE", "자재코드", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView4.AddTextEdit("PART_NAME", "자재명", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                //acGridView4.AddLookUpEdit("PART_PRODTYPE", "분류", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M007");
                acGridView4.AddLookUpEdit("MAT_LTYPE", "대분류", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M014");
                acGridView4.AddLookUpEdit("MAT_MTYPE", "중분류", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M015");
                acGridView4.AddLookUpEdit("MAT_UNIT", "단위", "40123", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M003");
                //acGridView4.AddLookUpEdit("MAT_MTYPE", "구분", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M001");
                acGridView4.AddLookUpVendor("VND_CODE", "발주처", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false);
                acGridView4.AddDateEdit("INS_DATE", "검사일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
                acGridView4.AddDateEdit("BALJU_DATE", "발주일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
                acGridView4.AddDateEdit("DUE_DATE", "입고예정일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
                acGridView4.AddTextEdit("STATUS", "비고", "", false, DevExpress.Utils.HorzAlignment.Near, false, false, false, acGridView.emTextEditMask.NONE);
                acGridView4.AddTextEdit("INS_QTY", "검사수량", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
                acGridView4.AddTextEdit("OK_QTY", "양품수량", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
                acGridView4.AddTextEdit("NG_QTY", "불량수량", "", false, DevExpress.Utils.HorzAlignment.Far, true, true, false, acGridView.emTextEditMask.QTY);
                acGridView4.AddLookUpEdit("MASTER_CAUSE", "불량처리", "40123", false, DevExpress.Utils.HorzAlignment.Near, true, true, false, "C402");
                acGridView4.AddTextEdit("NG_ID", "NG_ID", "", false, DevExpress.Utils.HorzAlignment.Near, false, false, false, acGridView.emTextEditMask.QTY);

                //acGridView4.AddTextEdit("UNIT_COST", "단가", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
                //acGridView4.AddTextEdit("AMT", "금액", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
                acGridView4.AddTextEdit("NG_CONTENTS", "불량 비고", "", false, DevExpress.Utils.HorzAlignment.Near, true, true, false, acGridView.emTextEditMask.NONE);
                
                acGridView4.KeyColumn = new string[] { "BALJU_NUM", "BALJU_SEQ" };

                //acGridView4.Columns["QTY"].ColumnEdit.EditValueChanging += qty_EditValueChanging;
                //acGridView4.Columns["UNIT_COST"].ColumnEdit.EditValueChanging += cost_EditValueChanging;
                acCheckedComboBoxEdit1.AddItem("발주일", false, "40206", "BALJU_DATE", true, false);
                acCheckedComboBoxEdit1.AddItem("입고예정일", false, "40206", "DUE_DATE", true, false);
                acCheckedComboBoxEdit2.AddItem("검사일", false, "40206", "INS_DATE", true, false);

                (acLayoutControl1.GetEditor("MAT_LTYPE") as acLookupEdit).SetCode("M001");
                (acLayoutControl1.GetEditor("PART_PRODTYPE") as acLookupEdit).SetCode("M007");

                btnEdit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                btnDel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

                acGridView1.CustomRowCellEdit += acGridView1_CustomRowCellEdit;

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

            if (type != "43" && type != "23")
            {
                if (e.Column.FieldName == "MASTER_CAUSE"
                    || e.Column.FieldName == "NG_QTY"
                    || e.Column.FieldName == "NG_CONTENTS")
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

            if (type != "43" && type != "23")
            {
                if (e.Column.FieldName == "MASTER_CAUSE")
                {
                    e.RepositoryItem = CreateLookupEdit("C402", true);
                }
                else if (e.Column.FieldName == "NG_QTY")
                {
                    e.RepositoryItem = CreateTextEdit(FormatType.Numeric, "", HorzAlignment.Far, true);
                }
                else if (e.Column.FieldName == "NG_CONTENTS")
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

        private void AcLayoutControl1_OnValueChanged(object sender, IBaseEditControl info, object newValue)
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

        private void ColumnEdit_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                DevExpress.XtraEditors.TextEdit edit = sender as DevExpress.XtraEditors.TextEdit;

                acGridView view = (edit.Parent as acGridControl).MainView as acGridView;

                DataRow focusedRow = view.GetFocusedDataRow();
                if (focusedRow["QTY"].toInt() < focusedRow["NG_QTY"].toInt())
                    acMessageBox.Show("불량 수량이 검사 수량보다 큽니다. 불량 수량을 확인하세요.", "수입 검사", acMessageBox.emMessageBoxType.CONFIRM);
                


            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
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
                //기본값 설정

                acLayoutControl layout = sender as acLayoutControl;

                layout.GetEditor("DATE").Value = "BALJU_DATE";
                layout.GetEditor("S_DATE").Value = DateTime.Now.AddDays(-7);
                layout.GetEditor("E_DATE").Value = DateTime.Now;


            }
            else if (sender == acLayoutControl2)
            {
                //기본값 설정

                acLayoutControl layout = sender as acLayoutControl;

                layout.GetEditor("DATE").Value = "INS_DATE";
                layout.GetEditor("S_DATE").Value = DateTime.Now.AddDays(-7);
                layout.GetEditor("E_DATE").Value = DateTime.Now;


            }

            base.ChildContainerInit(sender);
        }

        private void AcGridView1_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            try
            {
                if (acGridView1.ValidFocusRowHandle() == true)
                {
                    DataRow focusRow = acGridView1.GetFocusedDataRow();

                    if (focusRow != null)
                    {
                        string key = focusRow["BALJU_NUM"].ToString() + focusRow["BALJU_SEQ"].ToString();
                        this.acAttachFileControl1.LinkKey = key;
                        this.acAttachFileControl1.ShowKey = new object[] { key };
                    }
                }
                else
                {
                    this.acAttachFileControl1.LinkKey = null;
                    this.acAttachFileControl1.ShowKey = null;
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void acGridView4_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            try
            {
                if (acGridView4.ValidFocusRowHandle() == true)
                {
                    DataRow focusRow = acGridView4.GetFocusedDataRow();

                    if (focusRow != null)
                    {
                        string key = focusRow["BALJU_NUM"].ToString() + focusRow["BALJU_SEQ"].ToString();
                        this.acAttachFileControl2.LinkKey = key;
                        this.acAttachFileControl2.ShowKey = new object[] { key };
                    }
                }
                else
                {
                    this.acAttachFileControl2.LinkKey = null;
                    this.acAttachFileControl2.ShowKey = null;
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void AcGridView1_ShowGridMenuEx(object sender, PopupMenuShowingEventArgs e)
        {
            try
            {
                acGridView view = sender as acGridView;

                if (e.HitInfo.HitTest == GridHitTest.EmptyRow || e.HitInfo.HitTest == GridHitTest.Row || e.HitInfo.HitTest == GridHitTest.RowCell)
                {
                    GridHitInfo hitInfo = view.CalcHitInfo(e.Point);

                    //popdown.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    //popDel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

                    //popupMenu1.ShowPopup(view.GridControl.PointToScreen(e.Point));
                }
            }
            catch(Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }





        void acGridView1_ShowGridMenuEx(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            acGridView view = sender as acGridView;

            if (e.MenuType == GridMenuType.User)
            {
                popDel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                popdown.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                acBarButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
            else if (e.MenuType == GridMenuType.Row)
            {
                if (e.HitInfo.RowHandle >= 0)
                {
                    popDel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    popdown.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    acBarButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                }
                else
                {
                    popDel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    popdown.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    acBarButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                }
            }


            if (e.HitInfo.HitTest == GridHitTest.EmptyRow || e.HitInfo.HitTest == GridHitTest.Row || e.HitInfo.HitTest == GridHitTest.RowCell)
            {
                GridHitInfo hitInfo = view.CalcHitInfo(e.Point);

                popupMenu1.ShowPopup(view.GridControl.PointToScreen(e.Point));
            }

        }




        private void AcGridView2_ShowGridMenuEx(object sender, PopupMenuShowingEventArgs e)
        {
            try
            {
                acGridView view = sender as acGridView;

                if (e.HitInfo.HitTest == GridHitTest.EmptyRow || e.HitInfo.HitTest == GridHitTest.Row || e.HitInfo.HitTest == GridHitTest.RowCell)
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
                //if (e.Column.FieldName == "DUE_DATE")
                //{
                //    acGridView2.EndEditor();
                //    DataView dv = acGridView2.GetDataSourceView("DUE_DATE IS NULL");

                //    DataTable dt = dv.ToTable().Copy();

                //    int cnt = dv.Count;

                //    for (int i = 0; i < cnt; i++)
                //    {
                //        if (e.Value != null)
                //        {
                //            dt.Rows[i]["DUE_DATE"] = e.Value;
                //        }

                //        acGridView2.UpdateMapingRow(dt.Rows[i], false);
                //    }
                //}
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
            
        }


        private void AcGridView2_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            //this.SearchHistory();
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

        void acLayoutControl1_OnValueChanged(object sender, IBaseEditControl info, object newValue)
        {
            acLayoutControl layout = sender as acLayoutControl;
            switch (info.ColumnName)
            {
                case "MAT_LTYPE":

                    acLookupEdit3.SetCode("M002", newValue);


                    break;


                case "MAT_MTYPE":



                    break;

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

        void acLayoutControl1_OnValueKeyDown(object sender, IBaseEditControl info, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                this.Search();
            }
        }

        private void AcLayoutControl2_OnValueKeyDown(object sender, IBaseEditControl info, KeyEventArgs e)
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
                    paramTable.Columns.Add("PART_LIKE", typeof(String)); //    
                    paramTable.Columns.Add("S_BALJU_DATE", typeof(String)); //
                    paramTable.Columns.Add("E_BALJU_DATE", typeof(String)); //            
                    paramTable.Columns.Add("S_DUE_DATE", typeof(String)); //
                    paramTable.Columns.Add("E_DUE_DATE", typeof(String)); //            

                    DataRow paramRow = paramTable.NewRow();
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["PART_PRODTYPE"] = layoutRow["PART_PRODTYPE"];
                    paramRow["MAT_LTYPE"] = layoutRow["MAT_LTYPE"];
                    paramRow["PART_LIKE"] = layoutRow["PART_LIKE"];
                    foreach (string key in acCheckedComboBoxEdit1.GetKeyChecked())
                    {
                        switch (key)
                        {
                            case "BALJU_DATE":
                                paramRow["S_BALJU_DATE"] = layoutRow["S_DATE"];
                                paramRow["E_BALJU_DATE"] = layoutRow["E_DATE"];

                                break;

                            case "DUE_DATE":
                                paramRow["S_DUE_DATE"] = layoutRow["S_DATE"];
                                paramRow["E_DUE_DATE"] = layoutRow["E_DATE"];

                                break;
                        }
                    }



                    paramTable.Rows.Add(paramRow);

                    DataSet paramSet = new DataSet();
                    paramSet.Tables.Add(paramTable);


                    BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD_DETAIL, "PUR06A_SER", paramSet, "RQSTDT", "RSLTDT",
                                QuickSearch,
                                QuickException);
                }
                else
                {

                    DataRow layoutRow = acLayoutControl2.CreateParameterRow();

                    DataTable paramTable = new DataTable("RQSTDT");
                    paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                    paramTable.Columns.Add("S_INS_DATE", typeof(String)); //
                    paramTable.Columns.Add("E_INS_DATE", typeof(String)); //            
                    paramTable.Columns.Add("BALJU_NUM", typeof(String)); //            

                    DataRow paramRow = paramTable.NewRow();
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["BALJU_NUM"] = layoutRow["BALJU_NUM"];

                    foreach (string key in acCheckedComboBoxEdit2.GetKeyChecked())
                    {
                        switch (key)
                        {
                            case "INS_DATE":
                                paramRow["S_INS_DATE"] = layoutRow["S_DATE"];
                                paramRow["E_INS_DATE"] = layoutRow["E_DATE"];
                                break;
                        }
                    }

                    paramTable.Rows.Add(paramRow);

                    DataSet paramSet = new DataSet();
                    paramSet.Tables.Add(paramTable);

                    BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD_DETAIL, "PUR06A_SER2", paramSet, "RQSTDT", "RSLTDT",
                                QuickSearch2,
                                QuickException);
                }
                
                
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
            
        }

        private void popDel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
           
        }

        private void btnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                //수입검사 완료 
                acGridView1.EndEditor();

                DataRow[] selectedRows = acGridView1.GetSelectedDataRows();

                DataRow focusedRow = acGridView1.GetFocusedDataRow();

                if (selectedRows.Length == 0 &&
                    focusedRow == null) return;

                //if (selectedRows.Length == 0) return;

                foreach (DataRow dr in selectedRows)
                {
                    if (dr["NG_QTY"].toInt() > 0 && dr["MASTER_CAUSE"].ToString() == "")                        
                    {
                        acMessageBox.Show("불량 처리 항목을 선택하세요. ", "수입 검사", acMessageBox.emMessageBoxType.CONFIRM);
                        return;
                    }

                    //if (dr["QTY"].toInt() < dr["NG_QTY"].toInt())
                    //{
                    //    acMessageBox.Show("불량 수량이 발주 수량보다 많습니다. 수량을 확인하세요.", "수입 검사", acMessageBox.emMessageBoxType.CONFIRM);
                    //    return;
                    //}
                }

                if (selectedRows.Length == 0)
                {
                    if (focusedRow["NG_QTY"].toInt() > 0 && focusedRow["MASTER_CAUSE"].ToString() == "")
                    {
                        acMessageBox.Show("불량 처리 항목을 선택하세요. ", "수입 검사", acMessageBox.emMessageBoxType.CONFIRM);
                        return;
                    }

                    //if (focusedRow["QTY"].toInt() < focusedRow["NG_QTY"].toInt())
                    //{
                    //    acMessageBox.Show("불량 수량이 발주 수량보다 많습니다. 수량을 확인하세요.", "수입 검사", acMessageBox.emMessageBoxType.CONFIRM);
                    //    return;
                    //}
                }

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(string));
                paramTable.Columns.Add("BALJU_NUM", typeof(string));
                paramTable.Columns.Add("BALJU_SEQ", typeof(string));
                paramTable.Columns.Add("INS_DATE", typeof(string));
                paramTable.Columns.Add("INS_EMP", typeof(string));
                paramTable.Columns.Add("QTY", typeof(Int32));
                paramTable.Columns.Add("NG_QTY", typeof(Int32));
                paramTable.Columns.Add("UNIT_COST", typeof(decimal));
                paramTable.Columns.Add("AMT", typeof(decimal));
                paramTable.Columns.Add("MASTER_CAUSE", typeof(string));
                paramTable.Columns.Add("SCOMMENT", typeof(string));

                if (selectedRows.Length == 0)
                {
                    
                    DataRow paramRow = paramTable.NewRow();
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["BALJU_NUM"] = focusedRow["BALJU_NUM"];
                    paramRow["BALJU_SEQ"] = focusedRow["BALJU_SEQ"];
                    paramRow["INS_DATE"] = DateTime.Today.toDateString("yyyyMMdd");
                    paramRow["INS_EMP"] = acInfo.UserID;
                    paramRow["QTY"] = focusedRow["QTY"];
                    paramRow["NG_QTY"] = focusedRow["NG_QTY"];
                    paramRow["UNIT_COST"] = focusedRow["UNIT_COST"];
                    paramRow["AMT"] = focusedRow["UNIT_COST"].toDecimal() * (focusedRow["INS_QTY"].toInt() - focusedRow["NG_QTY"].toInt());
                    paramRow["MASTER_CAUSE"] = focusedRow["MASTER_CAUSE"];
                    paramRow["SCOMMENT"] = focusedRow["IN_SCOMMENT"];

                    paramTable.Rows.Add(paramRow);
                }
                else
                {
                    foreach (DataRow dr in selectedRows)
                    {
                        DataRow paramRow = paramTable.NewRow();
                        paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                        paramRow["BALJU_NUM"] = dr["BALJU_NUM"];
                        paramRow["BALJU_SEQ"] = dr["BALJU_SEQ"];
                        paramRow["INS_DATE"] = DateTime.Today.toDateString("yyyyMMdd");
                        paramRow["INS_EMP"] = acInfo.UserID;
                        paramRow["QTY"] = dr["QTY"];
                        paramRow["NG_QTY"] = dr["NG_QTY"];
                        paramRow["UNIT_COST"] = dr["UNIT_COST"];
                        paramRow["AMT"] = dr["UNIT_COST"].toDecimal() * (dr["INS_QTY"].toInt() - dr["NG_QTY"].toInt());
                        paramRow["MASTER_CAUSE"] = dr["MASTER_CAUSE"];
                        paramRow["SCOMMENT"] = dr["IN_SCOMMENT"];

                        paramTable.Rows.Add(paramRow);
                    }
                }
                
                
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);
                
                BizRun.QBizRun.ExecuteService(
                        this, QBiz.emExecuteType.SAVE, "PUR06A_INS", paramSet, "RQSTDT", "RSLTDT",
                        QuickIns,
                        QuickException);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void QuickIns(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            
            try
            {

                foreach (DataRow dr in e.result.Tables["RQSTDT"].Rows)
                {
                    acGridView1.DeleteMappingRow(dr);
                }

                acGridView1.RaiseFocusedRowChanged();

                acAlert.Show(this, "검사 완료 되었습니다.", acAlertForm.enmType.Success);

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

                foreach (DataRow row in acGridView4.GetSelectedDataRows())
                {
                    if (row["BAL_STAT"].ToString() != "23"
                    && row["BAL_STAT"].ToString() != "43")
                    {
                        acAlert.Show(this, "검사완료, 입고취소 상태만 취소가능합니다.", acAlertForm.enmType.Info);
                        return;
                    }
                }

                if (acMessageBox.Show("선택한 건을 검사 취소하시겠습니까?", "수입 검사", acMessageBox.emMessageBoxType.YESNO) == DialogResult.No) return;

                //발주 취소
                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(string));
                paramTable.Columns.Add("BALJU_NUM", typeof(string));
                paramTable.Columns.Add("BALJU_SEQ", typeof(string));
                paramTable.Columns.Add("NG_ID", typeof(string));

                foreach (DataRow row in acGridView4.GetSelectedDataRows())
                {
                    DataRow dr = paramTable.NewRow();
                    dr["PLT_CODE"] = acInfo.PLT_CODE;
                    dr["BALJU_NUM"] = row["BALJU_NUM"];
                    dr["BALJU_SEQ"] = row["BALJU_SEQ"];
                    dr["NG_ID"] = row["NG_ID"];
                    paramTable.Rows.Add(dr);
                }

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(
                        this, QBiz.emExecuteType.SAVE, "PUR06A_DEL", paramSet, "RQSTDT", "RSLTDT",
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

                acGridView4.RaiseFocusedRowChanged();

                acAlert.Show(this, "취소 되었습니다.", acAlertForm.enmType.Success);

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
                
                DataTable paramTable = new DataTable("RQSTDT");
                
                paramTable.Columns.Add("QTY", typeof(Int32)); //
                paramTable.Columns.Add("NG_QTY", typeof(Int32)); //
                paramTable.Columns.Add("SCOMMENT", typeof(String)); //
                paramTable.Columns.Add("REG_EMP", typeof(String)); //
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("BALJU_NUM", typeof(String)); //
                paramTable.Columns.Add("BALJU_SEQ", typeof(Int32)); //
                paramTable.Columns.Add("NG_ID", typeof(String)); //
                paramTable.Columns.Add("MASTER_CAUSE", typeof(String)); //


                foreach (DataRow row in modifyData.Rows)
                {
                    if (row["BAL_STAT"].ToString() != "23"
                        && row["BAL_STAT"].ToString() != "43")
                    {
                        acAlert.Show(this, "검사완료, 입고취소 상태만 수정가능합니다.", acAlertForm.enmType.Info);
                        return;
                    }

                    DataRow paramRow = paramTable.NewRow();
                    
                    if (row["QTY"].toInt() < row["NG_QTY"].toInt())
                    {
                        acMessageBox.Show("불량 수량이 검사 수량보다 많습니다. 확인하세요. ", "수입 검사", acMessageBox.emMessageBoxType.CONFIRM);
                        
                        return;
                    }


                    paramRow["QTY"] = row["INS_QTY"];
                    paramRow["NG_QTY"] = row["NG_QTY"];
                    paramRow["SCOMMENT"] = row["NG_CONTENTS"];
                    paramRow["REG_EMP"] = acInfo.UserID;
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["BALJU_NUM"] = row["BALJU_NUM"];
                    paramRow["BALJU_SEQ"] = row["BALJU_SEQ"];
                    paramRow["NG_ID"] = row["NG_ID"];
                    paramRow["MASTER_CAUSE"] = row["MASTER_CAUSE"];
                    paramTable.Rows.Add(paramRow);
                }


                DataRow layoutRow = acLayoutControl1.CreateParameterRow();

                DataTable paramTableQuery = new DataTable("RQSTDT_SEARCH");
                paramTableQuery.Columns.Add("PLT_CODE", typeof(String)); //
                paramTableQuery.Columns.Add("PART_PRODTYPE", typeof(String)); //
                paramTableQuery.Columns.Add("MAT_LTYPE", typeof(String)); //            
                paramTableQuery.Columns.Add("PART_LIKE", typeof(String)); //    
                paramTableQuery.Columns.Add("S_INS_DATE", typeof(String)); //
                paramTableQuery.Columns.Add("E_INS_DATE", typeof(String)); //            
                paramTableQuery.Columns.Add("S_DUE_DATE", typeof(String)); //
                paramTableQuery.Columns.Add("E_DUE_DATE", typeof(String)); //            

                DataRow paramRow2 = paramTableQuery.NewRow();
                paramRow2["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow2["PART_PRODTYPE"] = layoutRow["PART_PRODTYPE"];
                paramRow2["MAT_LTYPE"] = layoutRow["MAT_LTYPE"];
                paramRow2["PART_LIKE"] = layoutRow["PART_LIKE"];

                foreach (string key in acCheckedComboBoxEdit2.GetKeyChecked())
                {
                    switch (key)
                    {
                        case "INS_DATE":
                            paramRow2["S_INS_DATE"] = layoutRow["S_DATE"];
                            paramRow2["E_INS_DATE"] = layoutRow["E_DATE"];

                            break;
                    }
                }

                paramTableQuery.Rows.Add(paramRow2);

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);
                paramSet.Tables.Add(paramTableQuery);

                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.PROCESS, "PUR06A_UPD", paramSet, "RQSTDT", "",
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

                foreach (DataRow row in e.result.Tables["RSLTDT"].Rows)
                {
                    acGridView4.UpdateMapingRow(row, false);
                }

                //acGridView4.GridControl.DataSource = e.result.Tables["RSLTDT"];

                acAlert.Show(this, "검사내역이 수정되었습니다.", acAlertForm.enmType.Success);

                base.SetLog(e.executeType, e.result.Tables["RSLTDT"].Rows.Count, e.executeTime);

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        private void acBarButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // 도면 보기
        }
    }
}
