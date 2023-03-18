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
using System.IO;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;

namespace POP
{
    public sealed partial class POP08A_M0A : BaseMenu
    {

        Dictionary<string, Color> _SetColor = new Dictionary<string, Color>();
        Dictionary<Color, string> _SetColor2 = new Dictionary<Color, string>();

        public POP08A_M0A()
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
            //try
            //{
            //검색조건 초기화
            //acCheckedComboBoxEdit1.Text = "";
            //foreach (acCheckedListBoxItem item in acCheckedComboBoxEdit1.Properties.Items)
            //{
            //    item.CheckState = System.Windows.Forms.CheckState.Unchecked;
            //}
            //acTextEdit1.Text = "";

            //acTextEdit1.Text = ((DataRow)data)["ITEM_CODE"].ToString();

            this.Search();
            //}
            //catch { }
        }

        //private Hashtable _htWoList = null;
        //private Hashtable _htWoFig = null;

        public override void MenuInit()
        {

            acGridView1.GridType = acGridView.emGridType.SEARCH;

            acGridView1.AddCheckEdit("SEL", "선택", "", false, true, true, acGridView.emCheckEditDataType._STRING);

            acGridView1.AddTextEdit("CHAIN_WO_NO", "묶음 작업지시번호", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddLookUpEdit("WO_FLAG", "상태", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "S032");
            acGridView1.AddLookUpEdit("IS_REWORK", "재작업여부", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "W012");

            acGridView1.AddTextEdit("PREV_CHAIN_WO_NO", "변경전 묶음작업번호", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddLookUpEdit("IS_PREV_CHAIN", "변경전 묶음작업 여부", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "W013");

            acGridView1.AddLookUpEdit("PROD_PRIORITY", "우선순위", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P028");

            acGridView1.AddTextEdit("PROD_CODE", "수주번호", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddLookUpEdit("PROD_FLAG", "수주유형", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P006");
            acGridView1.AddTextEdit("PROD_NAME", "모델명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("PROD_VERSION", "버전", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddLookUpEdit("PROD_KIND", "제품구분", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "C011");
            acGridView1.AddCheckedComboBoxEdit("PROD_CATEGORY", "제품유형", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, "P009");
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

            //acGridView1.AddCheckEdit("HAS_DRAW", "도면", "", false, false, true, acGridView.emCheckEditDataType._STRING);

            acGridView1.AddDateEdit("END_TIME", "실적완료시간", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.LONG_DATE);
            acGridView1.AddLookUpEdit("IS_OS", "제작구분", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P016");
            acGridView1.AddTextEdit("PART_CODE", "부품코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("PART_NAME", "부품명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            //acGridView1.AddTextEdit("MAT_NAME", "소재명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("DRAW_NO", "도면명", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("MAT_QLTY", "재질", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("PART_QTY", "수량", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);

            acGridView1.AddTextEdit("SCOMMENT", "생산계획 비고", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("DRAW_EMP", "개발자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("ORD_SCOMMENT", "영업 전달사항", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

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


            acGridView1.AddTextEdit("PART_PUID", "참조 부품코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("PART_PUID_NAME", "참조 부품명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddLookUpEdit("MC_GROUP", "설비그룹", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "C020");


            acGridView1.AddTextEdit("CAM_EMP_SUB", "담당자 코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("CAM_EMP_SUB_NAME", "담당자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddLookUpEmp("CAM_EMP", "담당자", "", false, DevExpress.Utils.HorzAlignment.Center, true, true, false,"IS_CAM = 1");

            acGridView1.AddHidden("PT_ID", typeof(string));
            acGridView1.AddHidden("RE_WO_NO", typeof(string));

            acGridView1.Columns["CAM_EMP"].Fixed = FixedStyle.Right;

            acGridView1.AddHidden("WO_NO", typeof(string));

            acGridView1.KeyColumn = new string[] { "WO_NO" };

            acGridView1.OptionsView.ShowIndicator = true;

            acGridView1.Columns["SEL"].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            acGridView1.Columns["CAM_EMP"].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;

            acGridView1.OptionsView.AllowCellMerge = true;

            acGridView1.CellMerge += acGridView1_CellMerge;

            acCheckedComboBoxEdit1.AddItem("등록일", false, "", "REG_DATE", true, false);
            acCheckedComboBoxEdit1.AddItem("수주일", false, "", "ORD_DATE", true, false);
            acCheckedComboBoxEdit1.AddItem("출하예정일", false, "", "DUE_DATE", true, false);
            //acCheckedComboBoxEdit1.AddItem("납품일", false, "", "DELIVERY_DATE", true, false);

            this.acLayoutControl1.OnValueKeyDown += new acLayoutControl.ValueKeyDownEventHandler(acLayoutControl1_OnValueKeyDown);
            this.acLayoutControl1.OnValueChanged += new acLayoutControl.ValueChangedEventHandler(acLayoutControl1_OnValueChanged);

            this.acGridView1.CustomDrawCell += AcGridView1_CustomDrawCell;
            this.acGridView1.ShowGridMenuEx += new acGridView.ShowGridMenuExHandler(acGridView1_ShowGridMenuEx);
            this.acGridView1.OnMapingRowChanged += new acGridView.MapingRowChangedEventHandler(acGridView1_OnMapingRowChanged);

            acGridView1.ShownEditor += acGridView1_ShownEditor;
            SetBtnEnable(false);

            this.acGridView1.CellValueChanged += acGridView1_CellValueChanged;

            acGridView1.CustomRowCellEdit += acGridView1_CustomRowCellEdit;

            //acGridView1.OptionsCustomization.AllowFilter = false;

            //acGridView1.OptionsCustomization.AllowSort = false;

            //foreach (acGridColumn col in acGridView1.Columns)
            //{
            //    if (col.FieldName != "PART_CODE"
            //         && col.FieldName != "PART_NAME")
            //    {
            //        col.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            //    }
            //}

            (acLayoutControl1.GetEditor("WO_LIKE") as acCheckedComboBoxEdit).SetCodes("S032", true, false, CheckState.Unchecked);

            (acLayoutControl1.GetEditor("WO_LIKE") as acCheckedComboBoxEdit).GetItem("0").CheckState = CheckState.Checked;
            (acLayoutControl1.GetEditor("WO_LIKE") as acCheckedComboBoxEdit).GetItem("1").CheckState = CheckState.Checked;
            //(acLayoutControl1.GetEditor("WO_LIKE") as acCheckedComboBoxEdit).GetItem("2").CheckState = CheckState.Checked;
            //(acLayoutControl1.GetEditor("WO_LIKE") as acCheckedComboBoxEdit).GetItem("3").CheckState = CheckState.Checked;

            base.MenuInit();
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

        private void acGridView1_CellMerge(object sender, CellMergeEventArgs e)
        {
            try
            {
                if (e.Column.FieldName.Equals("SEL")
                    || e.Column.FieldName.Equals("CAM_EMP"))
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
                //else if (e.Column.FieldName.Equals("CAM_EMP"))
                //{
                //    string cWo1 = acGridView1.GetRowCellValue(e.RowHandle1, "CHAIN_WO_NO").ToString();
                //    string cWo2 = acGridView1.GetRowCellValue(e.RowHandle2, "CHAIN_WO_NO").ToString();

                //    string cEmp1 = acGridView1.GetRowCellValue(e.RowHandle1, "CAM_EMP").ToString();
                //    string cEmp2 = acGridView1.GetRowCellValue(e.RowHandle2, "CAM_EMP").ToString();

                //    if (cWo1 == cWo2 && cEmp1 == cEmp2
                //        && cWo1 != "" && cWo2 != "")
                //    {
                //        e.Merge = true;
                //    }
                //    else
                //    {
                //        e.Merge = false;
                //    }
                //}

                e.Handled = true;
            }
            catch
            {

            }
        }

        private void acGridView1_ShownEditor(object sender, EventArgs e)
        {
            acGridView view = sender as acGridView;

            if(view.FocusedColumn.FieldName == "CAM_EMP")
            {
                if(view.GetRowCellValue(view.FocusedRowHandle, "CAM_EMP").isNullOrEmpty())
                {
                    view.SetRowCellValue(view.FocusedRowHandle, "CAM_EMP", acInfo.UserID);

                    if (!view.GetRowCellValue(view.FocusedRowHandle, "CHAIN_WO_NO").isNullOrEmpty())
                    {
                        DataView dv = view.GetDataSourceView("CHAIN_WO_NO = '" + view.GetRowCellValue(view.FocusedRowHandle, "CHAIN_WO_NO").ToString() + "'");

                        for (int i = 0; i < dv.Count; i++)
                        {
                            dv[i]["CAM_EMP"] = acInfo.UserID;
                        }

                    }
                }
            }
        }

        private bool _IsChanged = false;

        private void acGridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
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


        void SetBtnEnable(bool value)
        {
            btnSave.Enabled = value; 
        }

        private void AcGridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            try
            {
                if (e.RowHandle < 0) return;

                if (e.Column.FieldName == "SEL"
                    || e.Column.FieldName == "CAM_EMP") return;

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

                string IS_OS = acGridView1.GetRowCellValue(e.RowHandle, "IS_OS").ToString();

                if (IS_OS == "1")
                {
                    e.Appearance.ForeColor = Color.Blue;
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
                string formKey = string.Format("{0},{1}", "PROD", row["PROD_CODE"]);

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
                //acBarButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                acBarButtonItem3.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;


            }
            else if (e.MenuType == GridMenuType.Row)
            {
                if (e.HitInfo.RowHandle >= 0)
                {
                    //acBarButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    acBarButtonItem3.Visibility = DevExpress.XtraBars.BarItemVisibility.Never; ;
                }
                else
                {
                    //acBarButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    acBarButtonItem3.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                }

            }


            if (e.HitInfo.HitTest == GridHitTest.EmptyRow || e.HitInfo.HitTest == GridHitTest.Row || e.HitInfo.HitTest == GridHitTest.RowCell)
            {

                GridHitInfo hitInfo = view.CalcHitInfo(e.Point);

                popupMenu1.ShowPopup(view.GridControl.PointToScreen(e.Point));


            }

        }

        private int _oldRowHandel = -1;

        //void acGridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        //{
        //    acGridView view = sender as acGridView;

        //    if (this._IsChanged == true && acMessageBox.Show(this, "수정된 항목이 있습니다.계속진행 하시겠습니까?", "QAISR59B", false, acMessageBox.emMessageBoxType.YESNO) != DialogResult.Yes)
        //    {
        //        acGridView1.FocusedRowChanged -= acGridView1_FocusedRowChanged;
        //        acGridView1.FocusedRowHandle = this._oldRowHandel;
        //        //acGridView1.SetOldFocusRowHandle(true);
        //        acGridView1.FocusedRowChanged += acGridView1_FocusedRowChanged;
        //        return;
        //    }

        //    this._oldRowHandel = acGridView1.FocusedRowHandle;

        //    if (view.ValidFocusRowHandle())
        //    {
        //        this._IsChanged = false;
        //        if (this._dtDeleteList != null)
        //            this._dtDeleteList.Clear();
        //        this.GetDatail();
        //        SetBtnEnable(true);
        //    }
        //    else
        //    {
        //        if(this._dtDeleteList != null)
        //            this._dtDeleteList.Clear();
        //        this._IsChanged = false;                
        //        acGridView2.ClearRow();
        //        SetBtnEnable(false);
        //    }
        //}


        void Search()
        {
            //조회
            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("PROD_LIKE", typeof(String)); //수주코드/명 LIKE 검색
            paramTable.Columns.Add("CVND_LIKE", typeof(String)); //발주
            paramTable.Columns.Add("PART_LIKE", typeof(String)); //발주
            paramTable.Columns.Add("BUSINESS_EMP", typeof(String)); //발주
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
            paramTable.Columns.Add("WO_LIKE", typeof(String));
            paramTable.Columns.Add("MAT_QLTY", typeof(String)); //
            paramTable.Columns.Add("CAM_EMP_ALL", typeof(String)); //

            paramTable.Columns.Add("CHAIN_WO_LIKE", typeof(String)); //

            DataRow layoutRow = acLayoutControl1.CreateParameterRow();

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["PROD_LIKE"] = layoutRow["PROD_LIKE"];
            paramRow["CVND_LIKE"] = layoutRow["CVND_LIKE"];
            paramRow["BUSINESS_EMP"] = layoutRow["BUSINESS_EMP"];
            paramRow["PART_LIKE"] = layoutRow["PART_LIKE"];
            paramRow["WO_LIKE"] = layoutRow["WO_LIKE"];
            paramRow["MAT_QLTY"] = layoutRow["MAT_QLTY"];
            paramRow["CAM_EMP_ALL"] = layoutRow["CAM_EMP_ALL"];
            paramRow["CHAIN_WO_LIKE"] = layoutRow["CHAIN_WO_LIKE"];

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
             "POP08A_SER", paramSet, "RQSTDT", "RSLTDT",
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

            if (ex.ErrNumber == 200027)
            {
                //부품이 존재하여 삭제할수없음

                acMessageBoxGridConfirm frm = new acMessageBoxGridConfirm(this, "acMessageBoxGridConfirm1", acInfo.BizError.GetDesc(ex.ErrNumber), string.Empty, false, this.Caption, ex.ParameterData);


                frm.View.GridType = acGridView.emGridType.FIXED;

                frm.View.AddTextEdit("PROD_CODE", "금형코드", "40900", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);


                frm.ShowDialog();

            }
            else if (ex.ErrNumber == 200059)
            {
                //세트외주 구매정보가 존재하여 삭제할수없음

                acMessageBoxGridConfirm frm = new acMessageBoxGridConfirm(this, "acMessageBoxGridConfirm2", acInfo.BizError.GetDesc(ex.ErrNumber), string.Empty, false,  this.Caption, ex.ParameterData);

                frm.View.GridType = acGridView.emGridType.FIXED;

                frm.View.AddTextEdit("PROD_CODE", "금형코드", "40900", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);


            }
            else if (ex.ErrNumber == 200083)
            {
                //금형상태가 유효하지않음

                acMessageBoxGridConfirm frm = new acMessageBoxGridConfirm(this, "acMessageBoxGridConfirm3", acInfo.BizError.GetDesc(ex.ErrNumber), string.Empty, false, this.Caption, ex.ParameterData);

                if (ex.ParameterData == null)
                {
                    acMessageBox.Show(this, ex);

                    return;
                }

                foreach (DataRow row in ex.ParameterData.Rows)
                {
                    row["CHECK_PROD_STATE"] = acInfo.StdCodes.GetNameByCodes("S025", row["CHECK_PROD_STATE"]);
                }

                frm.ParentControl = this;

                frm.View.GridType = acGridView.emGridType.FIXED;

                frm.View.AddLookUpEdit("NOW_PROD_STATE", "금형상태", "WJB3HAFK", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "S025");

                frm.View.AddTextEdit("PROD_CODE", "금형코드", "40900", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

                frm.View.AddTextEdit("CHECK_PROD_STATE", "유효 금형상태", "Y91G7XDQ", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);


                frm.ShowDialog();

            }
            else if (ex.ErrNumber == BizManager.BizException.DATA_REFRESH)
            {
                //데이터 갱신
                acMessageBox.Show(this, ex);

                this.DataRefresh("ITEM");
            }
            else if (ex.ErrNumber == 200202)
            {
                acMessageBox.Show("품목이 존재하여 삭제할 수 없습니다. \n품목을 먼저 삭제하세요. ", this.Text, acMessageBox.emMessageBoxType.CONFIRM);
            }
            else if (ex.ErrNumber == 200203)
            {
                acMessageBox.Show("대기 상태인 수주만 삭제 가능합니다.", this.Text, acMessageBox.emMessageBoxType.CONFIRM);
            }
            else if (ex.ErrNumber == 200204)
            {
                acMessageBox.Show("대기 상태인 품목만 삭제 가능합니다.", this.Text, acMessageBox.emMessageBoxType.CONFIRM);
            }
            else
            {
                acMessageBox.Show(this, ex);
            }

        }



        DataTable _dwgFileDT = new DataTable();
        void QuickSearch(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                base.SetData("PROD", e.result);


                foreach (DataRow row in e.result.Tables["RSLTDT"].Rows)
                {
                    if (row["CHAIN_WO_NO"].ToString() == "") continue;

                    Set_Color(row["CHAIN_WO_NO"].ToString());
                }

                acGridView1.GridControl.DataSource = e.result.Tables["RSLTDT"];

                acGridView1.ExpandAllGroups();

                _dwgFileDT = CodeHelperManager.acOpenDrawFile.GetFileExists();

                //acGridView1.SetOldFocusRowHandle(true);

                if (acGridView1.RowCount > 0)
                    SetBtnEnable(true);
                else
                    SetBtnEnable(false);

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
                 
                //foreach(DataRow row in e.result.Tables["RSLTDT"].Rows)
                //{
                //    acGridView1.UpdateMapingRow(row, false);
                //}

                this._IsChanged = false;

                acAlert.Show(this, "저장 되었습니다.", acAlertForm.enmType.Success);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }


        void QuickDEL(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                //foreach (DataRow row in e.result.Tables["RQSTDT"].Rows)
                //{
                //    acGridView2.DeleteMappingRow(row);
                //}
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                //if (acGridView2.RowCount == 0)
                //    return;


                acGridView1.EndEditor();


                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //사업장 코드
                paramTable.Columns.Add("WO_NO", typeof(String)); //
                paramTable.Columns.Add("CAM_EMP", typeof(String)); //
                paramTable.Columns.Add("CAM_EMP_DATE", typeof(String)); //
                paramTable.Columns.Add("REG_EMP", typeof(String)); //
                paramTable.Columns.Add("OVERWRITE", typeof(String)); //

                //DataRow[] rows = acGridView2.GetSelectedDataRows();

                //if (rows.Length == 0)
                //    return;

                foreach (DataRow row in acGridView1.GetAddModifyRows().Rows)
                {

                    DataRow paramRow = paramTable.NewRow();
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["WO_NO"] = row["WO_NO"];
                    paramRow["CAM_EMP"] = row["CAM_EMP"];
                    paramRow["CAM_EMP_DATE"] = acDateEdit.GetNowDateFromServer().toDateString("yyyyMMdd");
                    paramRow["REG_EMP"] = acInfo.UserID;
                    paramRow["OVERWRITE"] = "1";
                    paramTable.Rows.Add(paramRow);

                }

                {
                    DataSet paramSet = new DataSet();
                    paramSet.Tables.Add(paramTable);

                    BizRun.QBizRun.ExecuteService(
                    this, QBiz.emExecuteType.PROCESS, "POP08A_SAVE", paramSet, "RQSTDT", "RSLTDT",
                    QuickSave,
                    QuickException);
                }
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

            //ProdSpec frm = new ProdSpec(focusRow);

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
            //묶음
            try
            {
                acGridView1.EndEditor();

                DataView selectedView = acGridView1.GetDataSourceView("SEL = '1'");

                if (selectedView.Count > 0)
                {
                    DataTable paramTable = new DataTable("RQSTDT");
                    paramTable.Columns.Add("PLT_CODE", typeof(string));
                    paramTable.Columns.Add("PROD_CODE", typeof(string));
                    paramTable.Columns.Add("PART_CODE", typeof(string));
                    paramTable.Columns.Add("PT_ID", typeof(string));
                    paramTable.Columns.Add("WO_NO", typeof(string));
                    paramTable.Columns.Add("RE_WO_NO", typeof(string));
                    paramTable.Columns.Add("MC_GROUP", typeof(string));

                    string empCode = selectedView[0]["CAM_EMP"].ToString();

                    for (int i = 0; i < selectedView.Count; i++)
                    {
                        if (selectedView[i]["CHAIN_WO_NO"].ToString() != "")
                        {
                            acAlert.Show(this, "묶음처리되어있는 품목이 존재합니다.", acAlertForm.enmType.Warning);
                            return;
                        }

                        if (empCode != selectedView[i]["CAM_EMP"].ToString())
                        {
                            acAlert.Show(this, "같은 담당자만 처리 가능합니다.", acAlertForm.enmType.Info);
                            return;
                        }

                        if (selectedView[i]["IS_OS"].ToString() == "1")
                        {
                            acAlert.Show(this, "외주 품목이 선택되어 있습니다.", acAlertForm.enmType.Warning);
                            return;
                        }

                        DataRow paramRow = paramTable.NewRow();
                        paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                        paramRow["PROD_CODE"] = selectedView[i]["PROD_CODE"];
                        paramRow["PART_CODE"] = selectedView[i]["PART_CODE"];
                        paramRow["PT_ID"] = selectedView[i]["PT_ID"];
                        paramRow["WO_NO"] = selectedView[i]["WO_NO"];
                        paramRow["RE_WO_NO"] = selectedView[i]["RE_WO_NO"];
                        paramRow["MC_GROUP"] = selectedView[i]["MC_GROUP"]; 

                        paramTable.Rows.Add(paramRow);
                    }

                    DataSet paramSet = new DataSet();
                    paramSet.Tables.Add(paramTable);

                    BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.PROCESS, "POP08A_INS", paramSet, "RQSTDT", "RSLTDT",
                    QuickSave2,
                    QuickException);
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void acBarButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //묶음취소
            try
            {
                acGridView1.EndEditor();

                DataView selectedView = acGridView1.GetDataSourceView("SEL = '1'");

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(string));
                paramTable.Columns.Add("PROD_CODE", typeof(string));
                paramTable.Columns.Add("PART_CODE", typeof(string));
                paramTable.Columns.Add("PT_ID", typeof(string));
                paramTable.Columns.Add("WO_NO", typeof(string));
                paramTable.Columns.Add("RE_WO_NO", typeof(string));

                if (selectedView.Count > 0)
                {
                    for (int i = 0; i < selectedView.Count; i++)
                    {
                        if (selectedView[i]["IS_OS"].ToString() == "1")
                        {
                            acAlert.Show(this, "외주 품목이 선택되어 있습니다.", acAlertForm.enmType.Warning);
                            return;
                        }

                        DataRow paramRow = paramTable.NewRow();
                        paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                        paramRow["PROD_CODE"] = selectedView[i]["PROD_CODE"];
                        paramRow["PART_CODE"] = selectedView[i]["PART_CODE"];
                        paramRow["PT_ID"] = selectedView[i]["PT_ID"];
                        paramRow["WO_NO"] = selectedView[i]["WO_NO"];
                        paramRow["RE_WO_NO"] = selectedView[i]["RE_WO_NO"];

                        paramTable.Rows.Add(paramRow);
                    }
                }
                else
                {
                    DataRow focusRow = acGridView1.GetFocusedDataRow();

                    if (focusRow["CHAIN_WO_NO"].ToString() == "") { return; }

                    if (focusRow["IS_OS"].ToString() == "1")
                    {
                        acAlert.Show(this, "외주 품목이 선택되어 있습니다.", acAlertForm.enmType.Warning);
                        return;
                    }

                    DataView chainView = acGridView1.GetDataSourceView("CHAIN_WO_NO = '" + focusRow["CHAIN_WO_NO"].ToString() + "'");

                    for (int i = 0; i < chainView.Count; i++)
                    {
                        DataRow paramRow = paramTable.NewRow();
                        paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                        paramRow["PROD_CODE"] = chainView[i]["PROD_CODE"];
                        paramRow["PART_CODE"] = chainView[i]["PART_CODE"];
                        paramRow["PT_ID"] = chainView[i]["PT_ID"];
                        paramRow["WO_NO"] = chainView[i]["WO_NO"];
                        paramRow["RE_WO_NO"] = chainView[i]["RE_WO_NO"];

                        paramTable.Rows.Add(paramRow);
                    }
                }

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.PROCESS, "POP08A_INS2", paramSet, "RQSTDT", "RSLTDT",
                QuickSave2,
                QuickException);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void QuickSave2(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                foreach (DataRow row in e.result.Tables["RSLTDT"].Rows)
                {
                    //DataRow[] rows = e.result.Tables["RSLTDT_WO"].Select("PT_ID = '" + row["PT_ID"].ToString() + "'");
                    //if (rows.Length > 0)
                    //{
                    //    foreach (DataRow rw in rows)
                    //    {
                    //        if (!e.result.Tables["RSLTDT"].Columns.Contains(rw["PROC_CODE"].ToString()))
                    //        {
                    //            e.result.Tables["RSLTDT"].Columns.Add(rw["PROC_CODE"].ToString(), typeof(String));
                    //        }

                    //        row[rw["PROC_CODE"].ToString()] = rw["WO_FLAG"];
                    //    }
                    //}

                    if (row["CHAIN_WO_NO"].ToString() != "")
                    {
                        Set_Color(row["CHAIN_WO_NO"].ToString());
                    }

                    this.acGridView1.UpdateMapingRow(row, false);
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }
    }
}
