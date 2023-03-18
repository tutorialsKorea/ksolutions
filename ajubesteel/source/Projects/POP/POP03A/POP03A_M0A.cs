using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ControlManager;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;
using BizManager;
using CodeHelperManager;
using System.Linq;
using DevExpress.XtraGrid.Columns;
using System.Collections;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.ViewInfo;
using DevExpress.XtraEditors.Repository;
using System.IO;
using Zebra.Printing;

namespace POP
{
    public sealed partial class POP03A_M0A : BaseMenu
    {
        Dictionary<string, Color> _SetColor = new Dictionary<string, Color>();
        Dictionary<Color, string> _SetColor2 = new Dictionary<Color, string>();

        public POP03A_M0A()
        {
            InitializeComponent();
        }

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


        public override string InstantLog
        {
            set
            {
                statusBarLog.Caption = value;
            }
        }




        public override void MenuGotFocus()
        {

            base.MenuGotFocus();
        }

        public override void MenuLostFocus()
        {

            base.MenuLostFocus();

        }

        public override bool MenuDestory(object sender)
        {

            if (this._IsChanged == true && acMessageBox.Show(this, "수정된 항목이 있습니다.종료 하시겠습니까?", "QAISR59B", false, acMessageBox.emMessageBoxType.YESNO) != DialogResult.Yes)
            {
                return false;
            }

            return base.MenuDestory(sender);

        }


        public override void MenuLink(object data)
        {

            
        }
        
        public override void MenuInit()
        {

            acGridView1.GridType = acGridView.emGridType.SEARCH_SEL;

            acGridView1.AddLookUpEdit("MILL_STATE", "상태", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "S032");
            acGridView1.AddTextEdit("CHAIN_WO_NO", "묶음 작업지시번호", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddLookUpEdit("IS_REWORK", "재작업 여부", "", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "W012");
            acGridView1.AddLookUpEdit("PROD_PRIORITY", "우선순위", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P028");
            acGridView1.AddTextEdit("PROD_CODE", "수주번호", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("PROD_NAME", "모델명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("PROD_VERSION", "버전", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddLookUpEdit("PROD_KIND", "제품구분", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "C011");
            acGridView1.AddCheckedComboBoxEdit("PROD_CATEGORY", "제품유형", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, "P009");
            
            acGridView1.AddTextEdit("CVND_CODE", "발주처코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("CVND_NAME", "발주처", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddLookUpEmp("BUSINESS_EMP", "영업담당자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false);
            acGridView1.AddTextEdit("CUSTOMER_EMP", "고객담당자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("CUSTDESIGN_EMP", "고객설계자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddDateEdit("ORD_DATE", "수주일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
            acGridView1.AddDateEdit("DUE_DATE", "출하예정일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
            acGridView1.AddDateEdit("CHG_DUE_DATE", "출하조정일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
            //acGridView1.AddDateEdit("DELIVERY_DATE", "납품일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);

            //acGridView1.AddCheckedComboBoxEdit("PROBE_PIN", "Contact", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, "P011");
            acGridView1.AddLookUpEdit("PIN_TYPE", "Contact", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P011");
            acGridView1.AddLookUpEdit("PROD_TYPE", "제품분류", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P010");
            acGridView1.AddTextEdit("PROD_QTY", "수주수량", "CPW0FS8W", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NUMERIC);

            acGridView1.AddTextEdit("PART_CODE", "부품코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("PART_NAME", "부품명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("DRAW_NO", "도면명", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

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


            acGridView1.AddTextEdit("PART_QTY", "계획수량", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView1.AddTextEdit("ACT_QTY", "실적수량", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView1.AddLookUpEdit("MC_GROUP", "설비그룹", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "C020");
            acGridView1.AddDateEdit("ACT_END_TIME", "완료시간", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.LONG_DATE);
            acGridView1.AddTextEdit("X_VALUE", "X", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NUMERIC);
            acGridView1.AddTextEdit("Y_VALUE", "Y", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NUMERIC);
            acGridView1.AddTextEdit("T_VALUE", "두께(T)", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.F3);
            acGridView1.AddTextEdit("P_CNT", "판수", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NUMERIC);

            acGridView1.AddDateEdit("MIL_REQ_DATE", "밀링 요청일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);

            acGridView1.AddTextEdit("CAM_EMP", "CAM담당자 코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("CAM_EMP_NAME", "CAM담당자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("CAM_MAT_CODE", "소재코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("CAM_MAT_NAME", "소재", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("MAT_CODE", "가공소재코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("MAT_NAME", "가공소재", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("MAT_QLTY", "소재(재질)", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddMemoEdit("SCOMMENT", "CAM 비고", "", false, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Top, false, true, true, false);

            acGridView1.AddTextEdit("PT_SCOMMENT", "생산계획 비고", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

            //acGridView1.AddButtonEdit("BTN_END", "완료/취소", "", false, DevExpress.Utils.HorzAlignment.Center, 
            //    DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor, true, true, false, POP.Resource.list_confirm_2x,
            //    DevExpress.LookAndFeel.SkinStyle.TheAsphaltWorld);

            acGridView1.AddPictrue("BTN_END", "완료/취소", "", false, DevExpress.Utils.HorzAlignment.Center, true, true);

            acGridView1.Columns["BTN_END"].Fixed = FixedStyle.Right;
            //acGridView1.Columns["BTN_END"].ColumnEdit.Click += ColumnEdit_Click;


            acGridView1.AddHidden("WO_NO", typeof(string));
            acGridView1.AddHidden("ACTUAL_ID", typeof(string));
            acGridView1.AddHidden("RE_WO_NO", typeof(string));
            acGridView1.AddHidden("PROC_ID", typeof(string));


            acGridView1.KeyColumn = new string[] { "WO_NO" };


            acGridView1.OptionsView.ShowIndicator = true;
            acGridView1.Columns["X_VALUE"].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            acGridView1.Columns["Y_VALUE"].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            acGridView1.Columns["T_VALUE"].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            acGridView1.Columns["P_CNT"].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            acGridView1.Columns["MIL_REQ_DATE"].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True; 
            acGridView1.Columns["CAM_MAT_CODE"].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            acGridView1.Columns["CAM_MAT_NAME"].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            acGridView1.Columns["MAT_NAME"].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            acGridView1.Columns["MAT_QLTY"].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            acGridView1.Columns["SCOMMENT"].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            acGridView1.Columns["CAM_EMP"].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            acGridView1.Columns["CAM_EMP_NAME"].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            acGridView1.Columns["PT_SCOMMENT"].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;

            acGridView1.Columns["BTN_END"].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            acGridView1.OptionsView.AllowCellMerge = true;


            acCheckedComboBoxEdit1.AddItem("등록일", false, "", "REG_DATE", true, false);
            acCheckedComboBoxEdit1.AddItem("수주일", false, "", "ORD_DATE", true, false);
            acCheckedComboBoxEdit1.AddItem("출하예정일", false, "", "DUE_DATE", true, false);
            //acCheckedComboBoxEdit1.AddItem("납품일", false, "", "DELIVERY_DATE", true, false);

            this.acLayoutControl1.OnValueKeyDown += new acLayoutControl.ValueKeyDownEventHandler(acLayoutControl1_OnValueKeyDown);
            this.acLayoutControl1.OnValueChanged += new acLayoutControl.ValueChangedEventHandler(acLayoutControl1_OnValueChanged);

            acGridView1.CellMerge += acGridView1_CellMerge;
            this.acGridView1.CustomDrawCell += AcGridView1_CustomDrawCell;
            this.acGridView1.ShowGridMenuEx += new acGridView.ShowGridMenuExHandler(acGridView1_ShowGridMenuEx);
            this.acGridView1.OnMapingRowChanged += new acGridView.MapingRowChangedEventHandler(acGridView1_OnMapingRowChanged);
            //this.acGridView1.CustomRowCellEdit += acGridView1_CustomRowCellEdit;

            this.acGridView1.MouseUp += acGridView1_MouseUp;
            //this.acGridView1.MouseDown += acGridView1_MouseDown;
            acGridView1.CustomRowCellEdit += acGridView1_CustomRowCellEdit;

            acGridView1.OptionsCustomization.AllowFilter = false;

            //acGridView1.OptionsCustomization.AllowSort = false;

            foreach (acGridColumn col in acGridView1.Columns)
            {
                if (col.FieldName != "PART_CODE"
                     && col.FieldName != "PART_NAME")
                {
                    col.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
                }
            }


            base.MenuInit();
        }

        private string _clickedFilter;

        private bool _isMouseUp = false;

        private string _millState = "";


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

        private void acGridView1_MouseUp(object sender, MouseEventArgs e)
        {
            acGridView view = sender as acGridView;

            GridHitInfo hitInfo = view.CalcHitInfo(e.Location);

            if (hitInfo.Column == null)
                return;

            if (hitInfo.RowHandle < 0) return;

            string chainWono = view.GetRowCellValue(hitInfo.RowHandle, "CHAIN_WO_NO").ToString();
            string wono = view.GetRowCellValue(hitInfo.RowHandle, "WO_NO").ToString();
            string millState = view.GetRowCellValue(hitInfo.RowHandle, "MILL_STATE").ToString();

            _millState = millState;
            _isMouseUp = true;

            if (chainWono == "")
            {
                _clickedFilter = string.Format("WO_NO = '{0}' ", wono);
            }
            else
            {
                _clickedFilter = string.Format("CHAIN_WO_NO = '{0}' ", chainWono);
            }

            if (hitInfo.InRowCell && hitInfo.Column.FieldName == "BTN_END" && e.Button == MouseButtons.Left)
            {
                if (millState == "4")
                {
                    view.SetValue(_clickedFilter, "BTN_END", Confrim_2x);
                }
                else
                {
                    view.SetValue(_clickedFilter, "BTN_END", Cencel_2x);
                }

                ColumnEdit_Click(null, null);
            }

            //acGridView view = sender as acGridView;

            ////view.SetValue(_clickedFilter, "BTN_END", Confrim_2x);

            //GridHitInfo hitInfo = view.CalcHitInfo(e.Location);

            //if (hitInfo.Column == null)
            //    return;

            //string millState = view.GetRowCellValue(hitInfo.RowHandle, "MILL_STATE").ToString();

            //if (hitInfo.InRowCell && hitInfo.Column.FieldName == "BTN_END" && e.Button == MouseButtons.Left)
            //{
            //    if (millState == "4")
            //    {
            //        view.SetValue(_clickedFilter, "BTN_END", Cencel_2x);
            //    }
            //    else
            //    {
            //        view.SetValue(_clickedFilter, "BTN_END", Confrim_2x);
            //    }
            //}

        }

        private void acGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            acGridView view = sender as acGridView;

            GridHitInfo hitInfo = view.CalcHitInfo(e.Location);

            if (hitInfo.Column == null)
                return;

            string chainWono = view.GetRowCellValue(hitInfo.RowHandle, "CHAIN_WO_NO").ToString();
            string wono = view.GetRowCellValue(hitInfo.RowHandle, "WO_NO").ToString();
            string millState = view.GetRowCellValue(hitInfo.RowHandle, "MILL_STATE").ToString();

            if (chainWono == "")
            {
                _clickedFilter = string.Format("WO_NO = '{0}' ", wono);
            }
            else
            {
                _clickedFilter = string.Format("CHAIN_WO_NO = '{0}' ", chainWono);
            }

            if (hitInfo.InRowCell && hitInfo.Column.FieldName == "BTN_END" && e.Button == MouseButtons.Left)
            {
                if (millState == "4")
                {
                    view.SetValue(_clickedFilter, "BTN_END", Confrim_2x);
                }
                else
                {
                    view.SetValue(_clickedFilter, "BTN_END", Cencel_2x);
                }

                ColumnEdit_Click(null, null);
            }
        }

        private void acGridView1_CellMerge(object sender, CellMergeEventArgs e)
        {
            try
            {
                if (e.Column.FieldName.Equals("BTN_END")
                    || e.Column.FieldName.Equals("X_VALUE")
                    || e.Column.FieldName.Equals("Y_VALUE")
                    || e.Column.FieldName.Equals("T_VALUE")
                    || e.Column.FieldName.Equals("P_CNT")
                    || e.Column.FieldName.Equals("MIL_REQ_DATE")
                    || e.Column.FieldName.Equals("CAM_MAT_CODE")
                    || e.Column.FieldName.Equals("CAM_MAT_NAME")
                    || e.Column.FieldName.Equals("MAT_NAME")
                    || e.Column.FieldName.Equals("MAT_QLTY")
                    || e.Column.FieldName.Equals("SCOMMENT")
                    || e.Column.FieldName.Equals("CAM_EMP")
                    || e.Column.FieldName.Equals("CAM_EMP_NAME")
                    || e.Column.FieldName.Equals("PT_SCOMMENT"))
                {
                    string cWo1 = acGridView1.GetRowCellValue(e.RowHandle1, "CHAIN_WO_NO").ToString();
                    string cWo2 = acGridView1.GetRowCellValue(e.RowHandle2, "CHAIN_WO_NO").ToString();

                    if (cWo1 == cWo2
                        && cWo1 != "" && cWo2 != "")
                    {
                        e.Merge = true;
                    }
                    else
                    {
                        e.Merge = false;
                    }
                }

                e.Handled = true;
            }
            catch
            {

            }
        }


        Bitmap Confrim_2x = ChangeIconColor(POP.Resource.list_confirm_2x, Color.LimeGreen);
        Bitmap Cencel_2x = ChangeIconColor(POP.Resource.dialog_no_2x, Color.Red);



        // 상태에 따라 버튼 이미지 변경 
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
            //if (e.Column.FieldName == "BTN_END")
            //{
            //    acGridView1.EndEditor();

            //    if (sender is acGridView view)
            //    {
            //        DataRow row = view.GetDataRow(e.RowHandle);
            //        if (row == null)
            //            return;

            //        if(row["MILL_STATE"].ToString() == "4")
            //        {
            //            EditorButton button = new EditorButton(ButtonPredefines.Glyph, string.Empty, -1, true, true, 
            //                false, ImageLocation.MiddleCenter, Cencel_2x);
            //            button.ToolTip = "실적취소";

            //            RepositoryItemButtonEdit riButtonEdit = new RepositoryItemButtonEdit();
            //            riButtonEdit.TextEditStyle = TextEditStyles.HideTextEditor;
            //            riButtonEdit.LookAndFeel.SetSkinStyle(DevExpress.LookAndFeel.SkinStyle.TheAsphaltWorld);
            //            riButtonEdit.Buttons.Clear();
            //            riButtonEdit.Buttons.Add(button);
            //            riButtonEdit.ButtonClick += ColumnEdit_Click;
            //            e.RepositoryItem = riButtonEdit;

            //        }
            //        else
            //        {
            //            EditorButton button = new EditorButton(ButtonPredefines.Glyph, string.Empty, -1, true, true, 
            //                false, ImageLocation.MiddleCenter, Confrim_2x);
            //            button.ToolTip = "실적완료";

            //            RepositoryItemButtonEdit riButtonEdit = new RepositoryItemButtonEdit();
            //            riButtonEdit.TextEditStyle = TextEditStyles.HideTextEditor;
            //            riButtonEdit.LookAndFeel.SetSkinStyle(DevExpress.LookAndFeel.SkinStyle.TheAsphaltWorld);
            //            riButtonEdit.Buttons.Clear();
            //            riButtonEdit.Buttons.Add(button);
            //            riButtonEdit.ButtonClick += ColumnEdit_Click;
            //            e.RepositoryItem = riButtonEdit;
            //        }
            //    }
            //}
        }



        // 셀 아이콘 색상변경 
        private static Bitmap ChangeIconColor(Image img, Color iconColor)
        {
            Bitmap bmp = new Bitmap(img);

            int width = bmp.Width;
            int height = bmp.Height;

            //총 사이즈만큼 반복을 하면서 하나하나의 픽셀을 변경한다.
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    //get pixel value
                    Color p = bmp.GetPixel(x, y);

                    //extract ARGB value from p
                    int a = p.A;

                    if (p.R < 50 && p.G < 50 && p.B < 50)
                        bmp.SetPixel(x, y, Color.FromArgb(a, iconColor));
                }
            }
            return bmp;
        }

        /// <summary>
        /// 완료처리
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ColumnEdit_Click(object sender, EventArgs e)
        {
            DataRow row = acGridView1.GetFocusedDataRow();

            if (row == null)
                return;

            try
            {

                if(row["MILL_STATE"].ToString() == "4")
                {

                    if (acMessageBox.Show(this, "기존 실적이 있습니다. 취소하시겠습니까?", "", false, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
                    {
                        if (row["MILL_STATE"].ToString() == "4")
                        {
                            acGridView1.SetValue(_clickedFilter, "BTN_END", Cencel_2x);
                        }
                        else
                        {
                            acGridView1.SetValue(_clickedFilter, "BTN_END", Confrim_2x);
                        }

                        return;
                    }

                    // 밀링 이후 다음 공정들이 한번이라도 진행을 했는지 판단한다.
                    DataTable paramTable = new DataTable("RQSTDT");
                    paramTable.Columns.Add("PLT_CODE", typeof(String));               
                    paramTable.Columns.Add("PROD_CODE", typeof(String));
                    paramTable.Columns.Add("PART_CODE", typeof(String));
                    paramTable.Columns.Add("RE_WO_NO", typeof(String));
                    paramTable.Columns.Add("NON_RE_WO_NO", typeof(String));

                    DataRow paramRow = paramTable.NewRow();
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["PROD_CODE"] = row["PROD_CODE"];
                    paramRow["PART_CODE"] = row["PART_CODE"];

                    if (row["RE_WO_NO"].ToString() == "")
                    {
                        paramRow["NON_RE_WO_NO"] = "1";
                    }
                    else
                    {
                        paramRow["RE_WO_NO"] = row["RE_WO_NO"];
                    }

                    paramTable.Rows.Add(paramRow);
                    DataSet dtSet = new DataSet();
                    dtSet.Tables.Add(paramTable);

                    DataSet dsRslt = BizRun.QBizRun.ExecuteService(this, "POP03A_SER2", dtSet, "RQSTDT", "RSLTDT");

                    bool nextProc = false;

                    if(dsRslt.Tables["RSLTDT"].Rows.Count > 0)
                    {
                        foreach(DataRow dr in dsRslt.Tables["RSLTDT"].Rows)
                        {
                            if (row["PROC_ID"].toInt() >= dr["PROC_ID"].toInt())
                            {
                                continue;
                            }

                            if(dr["WO_FLAG"].ToString() == "2" || dr["WO_FLAG"].ToString() == "3" || dr["WO_FLAG"].ToString() == "4")
                            {
                                nextProc = true;
                            }
                        }

                        if(nextProc == true)
                        {
                            acAlert.Show(this, "다음 공정이 진행되었기 때문에 실적을 취소할 수 없습니다.", acAlertForm.enmType.Warning);

                            if (row["MILL_STATE"].ToString() == "4")
                            {
                                acGridView1.SetValue(_clickedFilter, "BTN_END", Cencel_2x);
                            }
                            else
                            {
                                acGridView1.SetValue(_clickedFilter, "BTN_END", Confrim_2x);
                            }

                            return;

                        }
                        else
                        {
                            // 밀링 실적 취소

                            DataTable MillTable = new DataTable("RQSTDT");
                            MillTable.Columns.Add("PLT_CODE", typeof(String));
                            MillTable.Columns.Add("ACTUAL_ID", typeof(String));
                            MillTable.Columns.Add("WO_NO", typeof(String));
                            MillTable.Columns.Add("WO_FLAG", typeof(String));

                            if (row["CHAIN_WO_NO"].ToString() == "")
                            {
                                DataRow millRow = MillTable.NewRow();
                                millRow["PLT_CODE"] = acInfo.PLT_CODE;
                                millRow["ACTUAL_ID"] = row["ACTUAL_ID"];
                                millRow["WO_NO"] = row["WO_NO"];
                                millRow["WO_FLAG"] = "1";

                                MillTable.Rows.Add(millRow);
                            }
                            else
                            {
                                DataView chainView = acGridView1.GetDataSourceView("CHAIN_WO_NO = '" + row["CHAIN_WO_NO"].ToString() + "'");

                                for (int i = 0; i < chainView.Count; i++)
                                {
                                    DataRow millRow = MillTable.NewRow();
                                    millRow["PLT_CODE"] = acInfo.PLT_CODE;
                                    millRow["ACTUAL_ID"] = chainView[i]["ACTUAL_ID"];
                                    millRow["WO_NO"] = chainView[i]["WO_NO"];
                                    millRow["WO_FLAG"] = "1";
                                    MillTable.Rows.Add(millRow);
                                }
                            }

                            DataSet paramSet = new DataSet();
                            paramSet.Tables.Add(MillTable);

                            BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.DEL, "POP03A_DEL", paramSet, "RQSTDT", "RSLTDT",
                                    QuickDel,
                                    QuickException);

                        }

                    }

                }
                else
                {
                    //if (row["ACTUAL_ID"].isNullOrEmpty())
                    //{
                    if (!base.ChildFormContains("NEW"))
                    {

                        POP03A_D0A frm = new POP03A_D0A(acGridView1, row, acCheckEdit1.Checked);

                        frm.DialogMode = BaseMenuDialog.emDialogMode.NEW;

                        frm.ParentControl = this;

                        base.ChildFormAdd("NEW", frm);

                        if (frm.ShowDialog(this) == DialogResult.OK)
                        {
                            DataRow frmRow = (DataRow)frm.OutputData;

                            DataTable paramTable = new DataTable("RQSTDT");
                            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                            paramTable.Columns.Add("WO_NO", typeof(String)); //
                            paramTable.Columns.Add("PT_ID", typeof(String)); //
                            paramTable.Columns.Add("ACTUAL_ID", typeof(String)); //
                            paramTable.Columns.Add("EMP_CODE", typeof(String)); //
                            paramTable.Columns.Add("MAT_CODE", typeof(String)); //
                            paramTable.Columns.Add("MAT_OUT", typeof(String)); //
                            paramTable.Columns.Add("OUT_MAT_CODE", typeof(String)); //
                            paramTable.Columns.Add("OUT_QTY", typeof(Int32)); //                
                            paramTable.Columns.Add("ACT_QTY", typeof(Int32)); //                
                            paramTable.Columns.Add("REG_EMP", typeof(String)); //
                            paramTable.Columns.Add("RE_WO_NO", typeof(String)); //
                            paramTable.Columns.Add("PROD_CODE", typeof(String)); //
                            paramTable.Columns.Add("X_VALUE", typeof(decimal)); //
                            paramTable.Columns.Add("Y_VALUE", typeof(decimal)); //
                            paramTable.Columns.Add("T_VALUE", typeof(decimal)); //
                            paramTable.Columns.Add("MC_GROUP", typeof(String)); //
                            paramTable.Columns.Add("PROD_QTY", typeof(int)); //
                            paramTable.Columns.Add("PART_CODE", typeof(String)); //
                            paramTable.Columns.Add("PART_NAME", typeof(String)); //
                            paramTable.Columns.Add("MAT_QLTY", typeof(String)); //
                            paramTable.Columns.Add("PROD_NAME", typeof(String)); //
                            paramTable.Columns.Add("CVND_NAME", typeof(String)); //

                            paramTable.Columns.Add("P_CNT", typeof(decimal)); //
                            paramTable.Columns.Add("DUE_DATE", typeof(String)); //
                            paramTable.Columns.Add("CAM_EMP_NAME", typeof(String)); //
                            paramTable.Columns.Add("PART_QTY", typeof(int)); //
                            paramTable.Columns.Add("PROD_PRIORITY", typeof(String)); //

                            paramTable.Columns.Add("MIL_REQ_DATE", typeof(String)); //

                            paramTable.Columns.Add("SCOMMENT", typeof(String)); //

                            if (row["CHAIN_WO_NO"].ToString() == "")
                            {
                                DataRow paramRow = paramTable.NewRow();
                                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                                paramRow["ACTUAL_ID"] = row["ACTUAL_ID"];
                                paramRow["WO_NO"] = row["WO_NO"];
                                paramRow["PT_ID"] = row["PT_ID"];
                                paramRow["EMP_CODE"] = frmRow["MILL_EMP"];
                                paramRow["MAT_CODE"] = frmRow["MAT_CODE"];
                                paramRow["MAT_OUT"] = frmRow["MAT_OUT"];
                                paramRow["OUT_MAT_CODE"] = frmRow["OUT_MAT_CODE"];
                                
                                paramRow["OUT_QTY"] = row["OUT_QTY"];

                                paramRow["ACT_QTY"] = row["PART_QTY"];
                                paramRow["REG_EMP"] = acInfo.UserID;
                                paramRow["RE_WO_NO"] = row["RE_WO_NO"];
                                paramRow["PROD_CODE"] = row["PROD_CODE"];
                                paramRow["X_VALUE"] = row["X_VALUE"];
                                paramRow["Y_VALUE"] = row["Y_VALUE"];
                                paramRow["T_VALUE"] = row["T_VALUE"];
                                paramRow["MC_GROUP"] = row["MC_GROUP"];
                                paramRow["PROD_QTY"] = row["PROD_QTY"];
                                paramRow["PART_CODE"] = row["PART_CODE"];
                                paramRow["PART_NAME"] = row["PART_NAME"];
                                paramRow["MAT_QLTY"] = row["MAT_QLTY"];
                                paramRow["PROD_NAME"] = row["PROD_NAME"];
                                paramRow["CVND_NAME"] = row["CVND_NAME"];

                                paramRow["P_CNT"] = row["P_CNT"];
                                paramRow["DUE_DATE"] = row["DUE_DATE"];
                                paramRow["CAM_EMP_NAME"] = row["CAM_EMP_NAME"];
                                paramRow["PART_QTY"] = row["PART_QTY"];
                                paramRow["PROD_PRIORITY"] = acInfo.StdCodes.GetNameByCode("P028", row["PROD_PRIORITY"].ToString());

                                if (row["MIL_REQ_DATE"].ToString().Length > 0)
                                {
                                    paramRow["MIL_REQ_DATE"] = (System.Convert.ToDateTime(row["MIL_REQ_DATE"]).ToString("yyyyMMdd"));
                                }

                                paramRow["SCOMMENT"] = row["SCOMMENT"];

                                paramTable.Rows.Add(paramRow);
                            }
                            else
                            {
                                DataView chainView = acGridView1.GetDataSourceView("CHAIN_WO_NO = '" + row["CHAIN_WO_NO"].ToString() + "'");

                                for (int i = 0; i < chainView.Count; i++)
                                {
                                    DataRow paramRow = paramTable.NewRow();
                                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                                    paramRow["ACTUAL_ID"] = chainView[i]["ACTUAL_ID"];
                                    paramRow["WO_NO"] = chainView[i]["WO_NO"];
                                    paramRow["PT_ID"] = chainView[i]["PT_ID"];
                                    paramRow["EMP_CODE"] = frmRow["MILL_EMP"];
                                    paramRow["MAT_CODE"] = frmRow["MAT_CODE"];
                                    paramRow["MAT_OUT"] = frmRow["MAT_OUT"];
                                    paramRow["OUT_MAT_CODE"] = frmRow["OUT_MAT_CODE"];
                                    paramRow["OUT_QTY"] = chainView[i]["OUT_QTY"];
                                    paramRow["ACT_QTY"] = chainView[i]["PART_QTY"];
                                    paramRow["REG_EMP"] = acInfo.UserID;
                                    paramRow["RE_WO_NO"] = row["RE_WO_NO"];
                                    paramRow["PROD_CODE"] = chainView[i]["PROD_CODE"];
                                    paramRow["X_VALUE"] = chainView[i]["X_VALUE"];
                                    paramRow["Y_VALUE"] = chainView[i]["Y_VALUE"];
                                    paramRow["T_VALUE"] = chainView[i]["T_VALUE"];
                                    paramRow["MC_GROUP"] = chainView[i]["MC_GROUP"];
                                    paramRow["PROD_QTY"] = chainView[i]["PROD_QTY"];
                                    paramRow["PART_CODE"] = chainView[i]["PART_CODE"];
                                    paramRow["PART_NAME"] = chainView[i]["PART_NAME"];
                                    paramRow["MAT_QLTY"] = chainView[i]["MAT_QLTY"];
                                    paramRow["PROD_NAME"] = chainView[i]["PROD_NAME"];
                                    paramRow["CVND_NAME"] = chainView[i]["CVND_NAME"];

                                    paramRow["P_CNT"] = chainView[i]["P_CNT"];
                                    paramRow["DUE_DATE"] = chainView[i]["DUE_DATE"];
                                    paramRow["CAM_EMP_NAME"] = chainView[i]["CAM_EMP_NAME"];
                                    paramRow["PART_QTY"] = chainView[i]["PART_QTY"];

                                    if (chainView[i]["MIL_REQ_DATE"].ToString().Length > 0)
                                    {
                                        paramRow["MIL_REQ_DATE"] = (System.Convert.ToDateTime(chainView[i]["MIL_REQ_DATE"]).ToString("yyyyMMdd"));
                                    }

                                    paramRow["PROD_PRIORITY"] = acInfo.StdCodes.GetNameByCode("P028", chainView[i]["PROD_PRIORITY"].ToString());

                                    paramRow["SCOMMENT"] = chainView[i]["SCOMMENT"];

                                    paramTable.Rows.Add(paramRow);
                                }
                            }

                            DataSet paramSet = new DataSet();
                            paramSet.Tables.Add(paramTable);


                            BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD, "POP03A_SAVE", paramSet, "RQSTDT", "RSLTDT",
                                    QuickSave,
                                    QuickException);

                        }
                        else
                        {
                            if (row["MILL_STATE"].ToString() == "4")
                            {
                                acGridView1.SetValue(_clickedFilter, "BTN_END", Cencel_2x);
                            }
                            else
                            {
                                acGridView1.SetValue(_clickedFilter, "BTN_END", Confrim_2x);
                            }
                        }
                    }
                    else
                    {
                        base.ChildFormFocus("NEW");
                    }
                    //}
                    //else
                    //{
                    //    if (!base.ChildFormContains(string.Format("MILL-{0}", row["WO_NO"])))
                    //    {

                    //        POP03A_D0A frm = new POP03A_D0A(acGridView1, row, acCheckEdit1.Checked);

                    //        frm.DialogMode = BaseMenuDialog.emDialogMode.OPEN;

                    //        frm.ParentControl = this;

                    //        base.ChildFormAdd(string.Format("MILL-{0}", row["WO_NO"]), frm);

                    //        if (frm.ShowDialog(this) == DialogResult.OK)
                    //        {
                    //            DataRow frmRow = (DataRow)frm.OutputData;

                    //            DataTable paramTable = new DataTable("RQSTDT");
                    //            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                    //            paramTable.Columns.Add("WO_NO", typeof(String)); //
                    //            paramTable.Columns.Add("PT_ID", typeof(String)); //
                    //            paramTable.Columns.Add("ACTUAL_ID", typeof(String)); //
                    //            paramTable.Columns.Add("EMP_CODE", typeof(String)); //
                    //            paramTable.Columns.Add("MAT_CODE", typeof(String)); //
                    //            paramTable.Columns.Add("MAT_OUT", typeof(String)); //
                    //            paramTable.Columns.Add("OUT_MAT_CODE", typeof(String)); //
                    //            paramTable.Columns.Add("OUT_QTY", typeof(Int32)); //                
                    //            paramTable.Columns.Add("ACT_QTY", typeof(Int32)); //                
                    //            paramTable.Columns.Add("REG_EMP", typeof(String)); //

                    //            if (row["CHAIN_WO_NO"].ToString() == "")
                    //            {
                    //                DataRow paramRow = paramTable.NewRow();
                    //                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    //                paramRow["ACTUAL_ID"] = row["ACTUAL_ID"];
                    //                paramRow["WO_NO"] = row["WO_NO"];
                    //                paramRow["PT_ID"] = row["PT_ID"];
                    //                paramRow["EMP_CODE"] = frmRow["MILL_EMP"];
                    //                paramRow["MAT_CODE"] = frmRow["MAT_CODE"];
                    //                paramRow["MAT_OUT"] = frmRow["MAT_OUT"];
                    //                paramRow["OUT_MAT_CODE"] = frmRow["OUT_MAT_CODE"];
                    //                paramRow["OUT_QTY"] = frmRow["OUT_QTY"];
                    //                paramRow["ACT_QTY"] = frmRow["PART_QTY"];
                    //                paramRow["REG_EMP"] = acInfo.UserID;

                    //                paramTable.Rows.Add(paramRow);
                    //            }
                    //            else
                    //            {
                    //                DataView chainView = acGridView1.GetDataSourceView("CHAIN_WO_NO = '" + row["CHAIN_WO_NO"].ToString() + "'");

                    //                for (int i = 0; i < chainView.Count; i++)
                    //                {
                    //                    DataRow paramRow = paramTable.NewRow();
                    //                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    //                    paramRow["ACTUAL_ID"] = chainView[i]["ACTUAL_ID"];
                    //                    paramRow["WO_NO"] = chainView[i]["WO_NO"];
                    //                    paramRow["PT_ID"] = chainView[i]["PT_ID"];
                    //                    paramRow["EMP_CODE"] = frmRow["MILL_EMP"];
                    //                    paramRow["MAT_CODE"] = frmRow["MAT_CODE"];
                    //                    paramRow["MAT_OUT"] = frmRow["MAT_OUT"];
                    //                    paramRow["OUT_MAT_CODE"] = frmRow["OUT_MAT_CODE"];
                    //                    paramRow["OUT_QTY"] = frmRow["OUT_QTY"];
                    //                    paramRow["ACT_QTY"] = frmRow["PART_QTY"];
                    //                    paramRow["REG_EMP"] = acInfo.UserID;

                    //                    paramTable.Rows.Add(paramRow);
                    //                }
                    //            }

                    //            DataSet paramSet = new DataSet();
                    //            paramSet.Tables.Add(paramTable);


                    //            BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD, "POP03A_SAVE", paramSet, "RQSTDT", "RSLTDT",
                    //                    QuickSave,
                    //                    QuickException);

                    //        }


                    //    }
                    //    else
                    //    {
                    //        base.ChildFormFocus(string.Format("MILL-{0}", row["WO_NO"]));
                    //    }
                    //}
                }
      
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private bool _IsChanged = false;

        private void acGridView2_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                this._IsChanged = true;                
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void AcGridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            try
            {
                if (sender is acGridView view)
                {

                    if (e.RowHandle < 0) return;

                    if (e.Column.FieldName == "BTN_END") return;

                    string cWo = acGridView1.GetRowCellValue(e.RowHandle, "CHAIN_WO_NO").ToString();

                    if (_SetColor.ContainsKey(cWo))
                    {
                        e.Appearance.BackColor = _SetColor[cWo];
                    }

                    string PROD_KIND = acGridView1.GetRowCellValue(e.RowHandle, "PROD_KIND").ToString();

                    if (PROD_KIND == "PE")
                    {
                        e.Appearance.ForeColor = Color.DarkViolet;
                    }

                    string PROD_PRIORITY = acGridView1.GetRowCellValue(e.RowHandle, "PROD_PRIORITY").ToString();

                    if (PROD_PRIORITY == "0")
                    {
                        e.Appearance.ForeColor = Color.Red;
                    }
                }

            }
            catch
            {

            }
        }

        void acGridView1_OnMapingRowChanged(acGridView.emMappingRowChangedType type, DataRow row)
        {
            if (type == acGridView.emMappingRowChangedType.DELETE)
            {
                string formKey = string.Format("{0},{1}", "WO_NO", row["WO_NO"]);

                base.ChildFormRemove(formKey);
            }

        }


        void acLayoutControl1_OnValueChanged(object sender, IBaseEditControl info, object newValue)
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

        public override void ChildContainerInit(Control sender)
        {
            //기본값 설정

            if (sender == acLayoutControl1)
            {


                acLayoutControl layout = sender as acLayoutControl;
                
                layout.GetEditor("DATE").Value = "DUE_DATE";
                layout.GetEditor("S_DATE").Value = acDateEdit.GetNowDateFromServer();
                layout.GetEditor("E_DATE").Value = acDateEdit.GetNowDateFromServer().AddDays(7);

                acLabelControl2.Text = acInfo.UserName + "(" + acInfo.UserORG_Name + ")";


            }


            base.ChildContainerInit(sender);
        }


        void acLayoutControl1_OnValueKeyDown(object sender, IBaseEditControl info, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                this.Search();
            }
        }
        void acGridView1_ShowGridMenuEx(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            acGridView view = sender as acGridView;

            if (e.MenuType == GridMenuType.User)
            {
                acBarButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                acBarButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                acBarButtonItem3.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
            else if (e.MenuType == GridMenuType.Row)
            {
                if (e.HitInfo.RowHandle >= 0)
                {
                    acBarButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    acBarButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    acBarButtonItem3.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                }
                else
                {
                    acBarButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    acBarButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    acBarButtonItem3.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                }

            }


            if (e.HitInfo.HitTest == GridHitTest.EmptyRow || e.HitInfo.HitTest == GridHitTest.Row || e.HitInfo.HitTest == GridHitTest.RowCell)
            {

                GridHitInfo hitInfo = view.CalcHitInfo(e.Point);

                popupMenu1.ShowPopup(view.GridControl.PointToScreen(e.Point));

            }
        }

        void Search()
        {
            //조회
            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("PROD_LIKE", typeof(String)); //수주코드/명 LIKE 검색
            paramTable.Columns.Add("CVND_LIKE", typeof(String)); //발주
            paramTable.Columns.Add("S_REG_DATE", typeof(String)); //등록 시작일
            paramTable.Columns.Add("E_REG_DATE", typeof(String)); //등록 종료일
            paramTable.Columns.Add("S_ORD_DATE", typeof(String)); //수주일 시작일
            paramTable.Columns.Add("E_ORD_DATE", typeof(String)); //수주일 종료일
            paramTable.Columns.Add("S_SHIP_DATE", typeof(String)); //출하 시작일
            paramTable.Columns.Add("E_SHIP_DATE", typeof(String)); //출하 종료일
            paramTable.Columns.Add("S_DUE_DATE", typeof(String)); //납기일 시작일
            paramTable.Columns.Add("E_DUE_DATE", typeof(String)); //납기일 종료일
            //paramTable.Columns.Add("S_DELIVERY_DATE", typeof(String)); //납품 시작일
            //paramTable.Columns.Add("E_DELIVERY_DATE", typeof(String)); //납품 종료일
            paramTable.Columns.Add("IS_END", typeof(String));
            paramTable.Columns.Add("IS_MID_INS", typeof(String)); //

            DataRow layoutRow = acLayoutControl1.CreateParameterRow();

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["PROD_LIKE"] = layoutRow["PROD_LIKE"];
            paramRow["CVND_LIKE"] = layoutRow["CVND_LIKE"];

            if (!acCheckEdit1.Checked)
            {
                paramRow["IS_END"] = "1";
            }

            if (!acCheckEdit2.Checked)
            {
                paramRow["IS_MID_INS"] = "1";
            }

            foreach (string key in acCheckedComboBoxEdit1.GetKeyChecked())
            {
                switch (key)
                {
                    case "REG_DATE":
                        //등록일
                        paramRow["S_REG_DATE"] = layoutRow["S_DATE"];
                        paramRow["E_REG_DATE"] = layoutRow["E_DATE"];

                        break;
                    case "ORD_DATE":
                        //수주일
                        paramRow["S_ORD_DATE"] = layoutRow["S_DATE"];
                        paramRow["E_ORD_DATE"] = layoutRow["E_DATE"];

                        break;
                    case "DUE_DATE":
                        //납기일
                        paramRow["S_DUE_DATE"] = layoutRow["S_DATE"];
                        paramRow["E_DUE_DATE"] = layoutRow["E_DATE"];

                        break;
                    case "SHIP_DATE":
                        //출하일
                        paramRow["S_SHIP_DATE"] = layoutRow["S_DATE"];
                        paramRow["E_SHIP_DATE"] = layoutRow["E_DATE"];

                        break;
                    //case "DELIVERY_DATE":
                    //    //납품일
                    //    paramRow["S_DELIVERY_DATE"] = layoutRow["S_DATE"];
                    //    paramRow["E_DELIVERY_DATE"] = layoutRow["E_DATE"];

                    //    break;
                }
            }


            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);


            BizRun.QBizRun.ExecuteService(
             this, QBiz.emExecuteType.LOAD,
             "POP03A_SER", paramSet, "RQSTDT", "RSLTDT",
             QuickSearch,
             QuickException);
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


        void QuickException(object sender, QBiz qBiz, BizManager.BizException ex)
        {

            if (_isMouseUp && _millState != "")
            {
                //if (_millState == "4")
                //{
                //    acGridView1.SetValue(_clickedFilter, "BTN_END", Confrim_2x);
                //}
                //else
                //{
                //    acGridView1.SetValue(_clickedFilter, "BTN_END", Cencel_2x);
                //}

                DataTable gridDT = (DataTable)acGridView1.GridControl.DataSource;
                DataRow[] rows = gridDT.Select(_clickedFilter);

                foreach (DataRow row in rows)
                {
                    if (row["MILL_STATE"].ToString() == "4")
                    {
                        row["BTN_END"] = Cencel_2x;
                    }
                    else
                    {
                        row["BTN_END"] = Confrim_2x;
                    }
                }

            }

            _isMouseUp = false;
            _millState = "";

            acMessageBox.Show(this, ex);
        }

        DataTable _dwgFileDT = new DataTable();
        void QuickSearch(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                base.SetData("PROD", e.result);

                foreach (DataRow row in e.result.Tables["RSLTDT"].Rows)
                {
                    if (row["MILL_STATE"].ToString() == "4")
                    {
                        row["BTN_END"] = Cencel_2x;
                    }
                    else
                    {
                        row["BTN_END"] = Confrim_2x;
                    }

                    if (row["CHAIN_WO_NO"].ToString() == "") continue;

                    Set_Color(row["CHAIN_WO_NO"].ToString());
                }

                acGridView1.GridControl.DataSource = e.result.Tables["RSLTDT"];
                
                _dwgFileDT = CodeHelperManager.acOpenDrawFile.GetFileExists();

                acGridView1.SetOldFocusRowHandle(true);

                base.SetLog(e.executeType, e.result.Tables["RSLTDT"].Rows.Count, e.executeTime);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }
        

        void QuickSave(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                foreach(DataRow row in e.result.Tables["RSLTDT"].Rows)
                {
                    if (row["MILL_STATE"].ToString() == "4")
                    {
                        row["BTN_END"] = Cencel_2x;
                    }
                    else
                    {
                        row["BTN_END"] = Confrim_2x;
                    }

                    acGridView1.UpdateMapingRow(row, false);

                    
                }

                this._IsChanged = false;

                acGridView1.ClearSelection();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }


        void QuickDel(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                foreach (DataRow row in e.result.Tables["RSLTDT"].Rows)
                {
                    if (row["MILL_STATE"].ToString() == "4")
                    {
                        row["BTN_END"] = Cencel_2x;
                    }
                    else
                    {
                        row["BTN_END"] = Confrim_2x;
                    }

                    acGridView1.UpdateMapingRow(row, false);

                }

                acAlert.Show(this, "취소되었습니다.", acAlertForm.enmType.Success);

                acGridView1.RefreshData();

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }


        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //엑셀 복사
            try
            {
                acGridView1.EndEditor();

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //사업장 코드
                paramTable.Columns.Add("ACTUAL_ID", typeof(String)); //
                paramTable.Columns.Add("PT_ID", typeof(String)); //
                paramTable.Columns.Add("WO_NO", typeof(String)); //
                paramTable.Columns.Add("EMP_CODE", typeof(String)); //
                paramTable.Columns.Add("X_VALUE", typeof(float)); //
                paramTable.Columns.Add("Y_VALUE", typeof(float)); //
                paramTable.Columns.Add("T_VALUE", typeof(float)); //
                paramTable.Columns.Add("PART_CODE", typeof(String)); //
                paramTable.Columns.Add("SCOMMENT", typeof(String)); //
                paramTable.Columns.Add("REG_EMP", typeof(String)); //
                paramTable.Columns.Add("OVERWRITE", typeof(String)); //

                foreach (DataRow row in acGridView1.GetAddModifyRows().Rows)
                {

                    DataRow paramRow = paramTable.NewRow();
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["ACTUAL_ID"] = row["ACTUAL_ID"];
                    paramRow["PT_ID"] = row["PT_ID"];
                    paramRow["WO_NO"] = row["WO_NO"];
                    paramRow["EMP_CODE"] = acInfo.UserID;
                    paramRow["X_VALUE"] = row["X_VALUE"];
                    paramRow["Y_VALUE"] = row["Y_VALUE"];
                    paramRow["T_VALUE"] = row["T_VALUE"];
                    paramRow["PART_CODE"] = row["PART_CODE"];
                    paramRow["SCOMMENT"] = row["SCOMMENT"];
                    paramRow["REG_EMP"] = acInfo.UserID;
                    paramRow["OVERWRITE"] = "1";
                    paramTable.Rows.Add(paramRow);
                }

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.PROCESS, "POP02A_SAVE", paramSet, "RQSTDT", "RSLTDT",
                QuickSave,
                QuickException);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        /// <summary>
        /// 완료 처리
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnWorkEnd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (acMessageBox.Show(this, "완료 처리 하시겠습니까?", "", false, acMessageBox.emMessageBoxType.YESNO) != DialogResult.Yes)
                {
                    return;
                }

                acGridView1.EndEditor();

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //사업장 코드
                paramTable.Columns.Add("ACTUAL_ID", typeof(String)); //
                paramTable.Columns.Add("WO_NO", typeof(String)); //
                paramTable.Columns.Add("EMP_CODE", typeof(String)); //
                paramTable.Columns.Add("X_VALUE", typeof(float)); //
                paramTable.Columns.Add("Y_VALUE", typeof(float)); //
                paramTable.Columns.Add("T_VALUE", typeof(float)); //
                paramTable.Columns.Add("PART_CODE", typeof(String)); //
                paramTable.Columns.Add("SCOMMENT", typeof(String)); //
                paramTable.Columns.Add("RE_WO_NO", typeof(String)); //
                paramTable.Columns.Add("REG_EMP", typeof(String)); //
                paramTable.Columns.Add("OVERWRITE", typeof(String)); //

                DataRow[] rows = acGridView1.GetSelectedDataRows();

                if (rows.Length == 0)
                    rows = new DataRow[] { acGridView1.GetFocusedDataRow() };

                foreach (DataRow row in rows)
                {

                    DataRow paramRow = paramTable.NewRow();
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["ACTUAL_ID"] = row["ACTUAL_ID"];
                    paramRow["WO_NO"] = row["WO_NO"];
                    paramRow["EMP_CODE"] = acInfo.UserID;
                    paramRow["X_VALUE"] = row["X_VALUE"];
                    paramRow["Y_VALUE"] = row["Y_VALUE"];
                    paramRow["T_VALUE"] = row["T_VALUE"];
                    paramRow["PART_CODE"] = row["PART_CODE"];
                    paramRow["SCOMMENT"] = row["SCOMMENT"];
                    paramRow["RE_WO_NO"] = row["RE_WO_NO"];
                    paramRow["REG_EMP"] = acInfo.UserID;
                    paramRow["OVERWRITE"] = "1";
                    paramTable.Rows.Add(paramRow);

                }

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.PROCESS, "POP02A_UPD", paramSet, "RQSTDT", "RSLTDT",
                QuickUPD,
                QuickException);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        /// <summary>
        /// 완료처리 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="qBiz"></param>
        /// <param name="e"></param>
        void QuickUPD(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                if (acCheckEdit1.Checked)
                {
                    foreach (DataRow row in e.result.Tables["RSLTDT"].Rows)
                    {
                        acGridView1.UpdateMapingRow(row, false);
                        
                    }
                }
                else
                {
                    foreach (DataRow row in e.result.Tables["RQSTDT"].Rows)
                    {
                        acGridView1.DeleteMappingRow(row);
                    }
                }

                this._IsChanged = false;

                acGridView1.ClearSelection();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void acBarButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // 제작사양서 보기

            DataRow focusRow = acGridView1.GetFocusedDataRow();

            if (focusRow == null) { return; }

            PopSpec frm = new PopSpec(focusRow);

            frm.DialogMode = BaseMenuDialog.emDialogMode.NEW;

            frm.ParentControl = this;

            frm.ShowDialog(this);

        }

        private void acBarButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // BOM 보기

            DataRow focusRow = acGridView1.GetFocusedDataRow();

            if (focusRow == null) { return; }

            PopBom frm = new PopBom(focusRow);

            frm.DialogMode = BaseMenuDialog.emDialogMode.NEW;

            frm.ParentControl = this;

            frm.ShowDialog(this);
        }

        private void acBarButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // 도면 보기
        }

        void Set_Color(string sName)
        {
            if (!_SetColor.ContainsKey(sName))
            {
                Random r = new Random();

                while (1 < 2)
                {
                    // Get a random fore- and backcolor
                    Color backColor = Color.FromArgb(r.Next(0, 256), r.Next(0, 256), r.Next(0, 256));
                    Color foreColor = Color.Black;//Color.FromArgb(r.Next(0, 256), r.Next(0, 256), r.Next(0, 256));

                    if (!_SetColor2.ContainsKey(backColor))
                    {
                        // Contrast readable?
                        if (ContrastReadableIs(foreColor, backColor))
                        {
                            _SetColor.Add(sName, backColor);
                            _SetColor2.Add(backColor, sName);
                            break;
                        }
                    }
                }
            }
        }

        public static bool ContrastReadableIs(Color color_1, Color color_2)
        {
            // Maximum contrast would be a value of "1.0f" which is the brightness
            // difference between "Color.Black" and "Color.White"
            float minContrast = 0.8f;

            float brightness_1 = color_1.GetBrightness();
            float brightness_2 = color_2.GetBrightness();

            // Contrast readable?
            return (Math.Abs(brightness_1 - brightness_2) >= minContrast);
        }

        private void acBarButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //QR코드 재출력

            DataRow focusRow = acGridView1.GetFocusedDataRow();

            if (focusRow == null) return;

            if (acMessageBox.Show(this, "재출력하시겠습니까?", "", false, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
            {
                return;
            }

            DataTable paramTable = ((DataTable)acGridView1.GridControl.DataSource).Clone();
            paramTable.TableName = "RQSTDT";


            if (focusRow["CHAIN_WO_NO"].ToString() == "")
            {
                DataRow paramRow = paramTable.NewRow();
                paramRow.ItemArray = focusRow.ItemArray;
                paramTable.Rows.Add(paramRow);
            }
            else
            {
                DataView chainView = acGridView1.GetDataSourceView("CHAIN_WO_NO = '" + focusRow["CHAIN_WO_NO"].ToString() + "'");

                for (int i = 0; i < chainView.Count; i++)
                {
                    DataRow paramRow = paramTable.NewRow();
                    paramRow.ItemArray = chainView[i].Row.ItemArray;

                    paramTable.Rows.Add(paramRow);
                }
            }

            foreach (DataRow row in paramTable.Rows)
            {
                row["PROD_PRIORITY"] = acInfo.StdCodes.GetNameByCode("P028", row["PROD_PRIORITY"].ToString());
            }

            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);


            BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD, "POP03A_PRINT", paramSet, "RQSTDT", "RSLTDT",
                    QuickPrint,
                    QuickException);

        }

        void QuickPrint(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            acAlert.Show(this, "출력되었습니다.", acAlertForm.enmType.Success);
        }
    }

}
