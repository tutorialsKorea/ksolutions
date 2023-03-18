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
    public sealed partial class POP02A_M0A : BaseMenu
    {

        Dictionary<string, Color> _SetColor = new Dictionary<string, Color>();
        Dictionary<Color, string> _SetColor2 = new Dictionary<Color, string>();

        public POP02A_M0A()
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

            acGridView1.GridType = acGridView.emGridType.SEARCH;

            acGridView1.AddCheckEdit("SEL", "선택", "", false, true, true, acGridView.emCheckEditDataType._STRING);

            acGridView1.AddTextEdit("CAM_EMP", "캠담당자 코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("CAM_EMP_NAME", "캠담당자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("CHAIN_WO_NO", "묶음 작업지시번호", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddLookUpEdit("IS_REWORK", "재작업 여부", "", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "W012");

            acGridView1.AddTextEdit("PREV_CHAIN_WO_NO", "변경전 묶음작업번호", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddLookUpEdit("IS_PREV_CHAIN", "변경전 묶음작업 여부", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "W013");

            acGridView1.AddLookUpEdit("PROD_PRIORITY", "우선순위", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P028");

            acGridView1.AddLookUpEdit("PROC_STAT", "공정상태", "41055", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "S038");
                        
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
            acGridView1.AddCheckedComboBoxEdit("PIN_TYPE", "Contact", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, "P011");
            acGridView1.AddLookUpEdit("PROD_TYPE", "제품분류", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P010");
            acGridView1.AddTextEdit("PROD_QTY", "수주수량", "CPW0FS8W", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NUMERIC);

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

            //acGridView1.AddButtonEdit("DRAW_SER", "도면", "", false, DevExpress.Utils.HorzAlignment.Center, DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor, true, true, false,POP.Resource.system_search_2x, DevExpress.LookAndFeel.SkinStyle.TheAsphaltWorld);
            //acGridView1.Columns["DRAW_SER"].ColumnEdit.Click += DRAW_SER_Click;

            acGridView1.AddLookUpEdit("IS_OS", "제작구분", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P016");
            acGridView1.AddTextEdit("PART_CODE", "부품코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("PART_NAME", "부품명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("DRAW_NO", "도면명", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("PART_MAT_QLTY", "재질", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("DRAW_EMP", "개발자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("ASY_DRAW_EMP", "조립품 개발자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("BOM_PART_QTY", "BOM 수량", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView1.AddTextEdit("O_PART_QTY", "세트수량", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView1.AddTextEdit("ORD_PROD_QTY", "영업수량", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("PART_QTY", "수량", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);

            acGridView1.AddTextEdit("PART_PUID", "참조 부품코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("PART_PUID_NAME", "참조 부품명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("PD_SCOMMENT", "영업 전달사항", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("FILE_CNT", "첨부파일수", "CPW0FS8W", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NUMERIC);
            acGridView1.AddDateEdit("ACT_START_TIME", "시작시간", "", false, DevExpress.Utils.HorzAlignment.Center, false, true,false, acGridView.emDateMask.LONG_DATE);
            acGridView1.AddDateEdit("ACT_END_TIME", "종료시간", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.LONG_DATE);
            acGridView1.AddTextEdit("PT_SCOMMENT", "생산계획 비고", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddLookUpEdit("MC_GROUP", "설비그룹", "", false, DevExpress.Utils.HorzAlignment.Center, true, true, false, "C020");
            acGridView1.AddTextEdit("X_VALUE", "X", "", false, DevExpress.Utils.HorzAlignment.Far, true, true, false, acGridView.emTextEditMask.NUMERIC);
            acGridView1.AddTextEdit("Y_VALUE", "Y", "", false, DevExpress.Utils.HorzAlignment.Far, true, true, false, acGridView.emTextEditMask.NUMERIC);
            acGridView1.AddTextEdit("T_VALUE", "두께(T)", "", false, DevExpress.Utils.HorzAlignment.Far, true, true, false, acGridView.emTextEditMask.F3);
            acGridView1.AddTextEdit("P_CNT", "판수", "", false, DevExpress.Utils.HorzAlignment.Far, true, true, false, acGridView.emTextEditMask.NUMERIC);

            acGridView1.AddDateEdit("MIL_REQ_DATE", "밀링 요청일", "", false, DevExpress.Utils.HorzAlignment.Center, true, true, false, acGridView.emDateMask.SHORT_DATE);

            acGridView1.AddTextEdit("IS_PREV_NG", "불량 이력 여부", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddHidden("MAT_COST", typeof(Decimal));
            acGridView1.AddHidden("NG_ID", typeof(string));

            RepositoryItemPart partEdit = new RepositoryItemPart();
            
            acGridView1.AddCustomEdit("MAT_CODE_NAME", "소재", "", false, DevExpress.Utils.HorzAlignment.Center, true, true, false, partEdit);
            acGridView1.Columns["MAT_CODE_NAME"].ColumnEdit.Click += ColumnEdit_Click;
            acGridView1.AddTextEdit("MAT_QLTY", "소재(재질)", "", false, DevExpress.Utils.HorzAlignment.Center, true, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddMemoEdit("SCOMMENT", "특기사항", "", false, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Top, true, false, true, false);
            acGridView1.AddHidden("MAT_CODE", typeof(string));
            acGridView1.AddHidden("PT_ID", typeof(string));

            partEdit.EditValueChanged += PartEdit_EditValueChanged;
            acGridView1.Columns["SCOMMENT"].Fixed = FixedStyle.Right;
            acGridView1.Columns["MAT_QLTY"].Fixed = FixedStyle.Right;
            acGridView1.Columns["MAT_CODE_NAME"].Fixed = FixedStyle.Right;
            acGridView1.Columns["MIL_REQ_DATE"].Fixed = FixedStyle.Right;
            acGridView1.Columns["P_CNT"].Fixed = FixedStyle.Right;
            acGridView1.Columns["T_VALUE"].Fixed = FixedStyle.Right;
            acGridView1.Columns["Y_VALUE"].Fixed = FixedStyle.Right;
            acGridView1.Columns["X_VALUE"].Fixed = FixedStyle.Right;            
            acGridView1.Columns["MC_GROUP"].Fixed = FixedStyle.Right;

            acGridView1.AddHidden("WO_NO", typeof(string));
            acGridView1.AddHidden("ACTUAL_ID", typeof(string));
            acGridView1.AddHidden("RE_WO_NO", typeof(string));

            acGridView1.KeyColumn = new string[] { "WO_NO" };

            acGridView1.OptionsView.ShowIndicator = true;

            acGridView1.Columns["SEL"].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            acGridView1.Columns["MC_GROUP"].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            acGridView1.Columns["X_VALUE"].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            acGridView1.Columns["Y_VALUE"].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            acGridView1.Columns["T_VALUE"].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            acGridView1.Columns["P_CNT"].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            acGridView1.Columns["MIL_REQ_DATE"].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            acGridView1.Columns["MAT_CODE_NAME"].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            acGridView1.Columns["MAT_QLTY"].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            acGridView1.Columns["SCOMMENT"].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            acGridView1.OptionsView.AllowCellMerge = true;

            this.acLayoutControl1.OnValueKeyDown += new acLayoutControl.ValueKeyDownEventHandler(acLayoutControl1_OnValueKeyDown);
            this.acLayoutControl1.OnValueChanged += new acLayoutControl.ValueChangedEventHandler(acLayoutControl1_OnValueChanged);

            acGridView1.CellMerge += acGridView1_CellMerge;

            this.acGridView1.ShowGridMenuEx += new acGridView.ShowGridMenuExHandler(acGridView1_ShowGridMenuEx);

            this.acGridView1.CustomDrawCell += AcGridView1_CustomDrawCell;
            this.acGridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(acGridView1_FocusedRowChanged);
            this.acGridView1.OnMapingRowChanged += new acGridView.MapingRowChangedEventHandler(acGridView1_OnMapingRowChanged);

            acGridView1.CustomRowCellEdit += acGridView1_CustomRowCellEdit;

            acGridView1.ShownEditor += acGridView1_ShownEditor;

            acGridView1.OptionsCustomization.AllowFilter = false;

            //acGridView1.OptionsCustomization.AllowSort = false;

            foreach (acGridColumn col in acGridView1.Columns)
            {
                if (col.FieldName != "PART_CODE"
                    && col.FieldName != "PART_NAME"
                    && col.FieldName != "CAM_EMP"
                    && col.FieldName != "CAM_EMP_NAME")
                {
                    col.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
                }
            }
            acGridView1.CellValueChanged += AcGridView1_CellValueChanged;


            base.MenuInit();
        }

        private void AcGridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (e.RowHandle < 0) return;
                if (e.Column.FieldName == "SEL") return;

                DataRow row = acGridView1.GetDataRow(e.RowHandle);

                if (row["CHAIN_WO_NO"].ToString() != "")
                {
                    DataTable dt = (DataTable)acGridView1.GridControl.DataSource;

                    DataRow[] rows = dt.Select("CHAIN_WO_NO = '" + row["CHAIN_WO_NO"].ToString() + "'");

                    foreach (DataRow rw in rows)
                    {
                        rw[e.Column.FieldName] = e.Value;
                    }
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void acGridView1_ShownEditor(object sender, EventArgs e)
        {
            acGridView view = sender as acGridView;

            if (view.FocusedColumn.FieldName == "MIL_REQ_DATE")
            {
                if (view.GetRowCellValue(view.FocusedRowHandle, "MIL_REQ_DATE").isNullOrEmpty())
                {
                    view.SetRowCellValue(view.FocusedRowHandle, "MIL_REQ_DATE", DateTime.Now);

                    if (!view.GetRowCellValue(view.FocusedRowHandle, "CHAIN_WO_NO").isNullOrEmpty())
                    {
                        DataView dv = view.GetDataSourceView("CHAIN_WO_NO = '" + view.GetRowCellValue(view.FocusedRowHandle, "CHAIN_WO_NO").ToString() + "'");

                        for (int i = 0; i < dv.Count; i++)
                        {
                            dv[i]["MIL_REQ_DATE"] = DateTime.Now;
                        }

                    }
                }
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

        private void acGridView1_CellMerge(object sender, CellMergeEventArgs e)
        {
            try
            {
                if (e.Column.FieldName.Equals("SEL")
                    || e.Column.FieldName.Equals("MC_GROUP")
                    || e.Column.FieldName.Equals("X_VALUE")
                    || e.Column.FieldName.Equals("Y_VALUE")
                    || e.Column.FieldName.Equals("T_VALUE")
                    || e.Column.FieldName.Equals("P_CNT")
                    || e.Column.FieldName.Equals("MIL_REQ_DATE")
                    || e.Column.FieldName.Equals("MAT_CODE_NAME")
                    || e.Column.FieldName.Equals("MAT_QLTY")
                    || e.Column.FieldName.Equals("SCOMMENT"))
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

        private void ColumnEdit_Click(object sender, EventArgs e)
        {
            acPart part = sender as acPart;

            part.MAT_LTYPE = "22";

            part.MAT_MTYPE = "20";
        }

        private void PartEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            acPart part = sender as acPart;

            part.MAT_LTYPE = "22";
        }

        private void PartEdit_EditValueChanged(object sender, EventArgs e)
        {
            acPart part = sender as acPart;

            DataRow selectRow = part.SelectedRow;

            string MAT_CODE = null;
            string MAT_CODE_NAME = null;

            if (selectRow != null)
            {
                MAT_CODE = selectRow["PART_CODE"].ToString();
                MAT_CODE_NAME = selectRow["PART_NAME"].ToString();
            }

            DataRow focusRow = acGridView1.GetFocusedDataRow();

            
            if (focusRow["CHAIN_WO_NO"].ToString() == "")
            {
                focusRow["MAT_CODE"] = MAT_CODE;
                focusRow["MAT_CODE_NAME"] = MAT_CODE_NAME;

                acGridView1.SetRowCellValue(acGridView1.FocusedRowHandle, "MAT_CODE", MAT_CODE);
                acGridView1.SetRowCellValue(acGridView1.FocusedRowHandle, "MAT_CODE_NAME", MAT_CODE_NAME);
            }
            else
            {
                DataView chainView = acGridView1.GetDataSourceView("CHAIN_WO_NO = '" + focusRow["CHAIN_WO_NO"].ToString() + "'");

                DataTable updTable = new DataTable();
                updTable.Columns.Add("WO_NO", typeof(string));
                updTable.Columns.Add("MAT_CODE", typeof(string));
                updTable.Columns.Add("MAT_CODE_NAME", typeof(string));

                for (int i = 0; i < chainView.Count; i++)
                {
                    chainView[i]["MAT_CODE"] = MAT_CODE;
                    chainView[i]["MAT_CODE_NAME"] = MAT_CODE_NAME;
                }
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
                    //DataRow row = view.GetDataRow(e.RowHandle);
                    //if (row == null)
                    //    return;

                    //if (row["PROD_STATE"].ToString() == "5")
                    //{
                    //    e.Appearance.BackColor = Color.Orange;
                    //    e.Appearance.ForeColor = Color.Black;
                    //}

                    //if (row["PROC_STAT"].ToString() == "4")
                    //{
                    //    if (!e.Column.OptionsColumn.AllowEdit)
                    //    {
                    //        e.Appearance.BackColor = Color.Honeydew;
                    //        e.Appearance.ForeColor = Color.Black;
                    //    }
                    //}

                    if (e.RowHandle < 0) return;

                    if (e.Column.FieldName == "SEL"
                        || e.Column.FieldName == "SCOMMENT"
                        || e.Column.FieldName == "MAT_QLTY"
                        || e.Column.FieldName == "MAT_CODE_NAME"
                        || e.Column.FieldName == "P_CNT"
                        || e.Column.FieldName == "MIL_REQ_DATE"
                        || e.Column.FieldName == "T_VALUE"
                        || e.Column.FieldName == "Y_VALUE"
                        || e.Column.FieldName == "X_VALUE"
                        || e.Column.FieldName == "MC_GROUP") return;

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
                case "IS_END":

                    //날짜검색조건이 존재하면 날짜컨트롤을 필수로 바꾼다.

                    if (newValue == null || newValue.toBoolean() != true)
                    {
                        //acCheckedComboBoxEdit1.isReadyOnly = true;
                        //layout.GetEditor("DATE").isReadyOnly = true;
                        layout.GetEditor("S_DATE").isReadyOnly = true;
                        layout.GetEditor("E_DATE").isReadyOnly = true;
                        //layout.GetEditor("DATE").isRequired = false;
                        layout.GetEditor("S_DATE").isRequired = false;
                        layout.GetEditor("E_DATE").isRequired = false;

                    }
                    else
                    {
                        //acCheckedComboBoxEdit1.isReadyOnly = false;
                        //layout.GetEditor("DATE").isReadyOnly = false;
                        layout.GetEditor("S_DATE").isReadyOnly = false;
                        layout.GetEditor("E_DATE").isReadyOnly = false;
                        //layout.GetEditor("DATE").isRequired = true;
                        layout.GetEditor("S_DATE").isRequired = true;
                        layout.GetEditor("E_DATE").isRequired = true;
                    }

                    break;
                //case "DATE":
                //    //날짜검색조건이 존재하면 날짜컨트롤을 필수로 바꾼다.
                //    if (newValue.EqualsEx(string.Empty))
                //    {

                //        layout.GetEditor("S_DATE").isRequired = false;
                //        layout.GetEditor("E_DATE").isRequired = false;

                //    }
                //    else
                //    {
                //        layout.GetEditor("S_DATE").isRequired = true;
                //        layout.GetEditor("E_DATE").isRequired = true;
                //    }

                //    break;
            }

        }

        public override void ChildContainerInit(Control sender)
        {
            //기본값 설정

            if (sender == acLayoutControl1)
            {


                acLayoutControl layout = sender as acLayoutControl;
                //layout.GetEditor("DATE").Value = "DUE_DATE";
                layout.GetEditor("CAM_EMP").Value = acInfo.UserID;
                //layout.GetEditor("DATE").Value = "DUE_DATE";
                layout.GetEditor("S_DATE").Value = acDateEdit.GetNowFirstDate();
                layout.GetEditor("E_DATE").Value = DateTime.Now;


                //layout.GetEditor("EMP_NAME").Value =  acInfo.UserName + "("+ acInfo.UserORG_Name +")";
                acLabelControl1.Text = acInfo.UserName + "(" + acInfo.UserORG_Name + ")";

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

        //void acGridView1_ShowGridMenuEx(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        //{
        //    acGridView view = sender as acGridView;

        //    if (e.MenuType == GridMenuType.User)
        //    {
        //        //acBarButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
        //        //acBarButtonItem3.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;


        //    }
        //    else if (e.MenuType == GridMenuType.Row)
        //    {
        //        if (e.HitInfo.RowHandle >= 0)
        //        {
        //            //acBarButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
        //            //acBarButtonItem3.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
        //        }
        //        else
        //        {
        //            //acBarButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
        //            //acBarButtonItem3.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
        //        }

        //    }


        //    if (e.HitInfo.HitTest == GridHitTest.EmptyRow || e.HitInfo.HitTest == GridHitTest.Row || e.HitInfo.HitTest == GridHitTest.RowCell)
        //    {

        //        GridHitInfo hitInfo = view.CalcHitInfo(e.Point);

        //        popupMenu1.ShowPopup(view.GridControl.PointToScreen(e.Point));


        //    }

        //}


        void acGridView1_ShowGridMenuEx(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            acGridView view = sender as acGridView;

            if (e.MenuType == GridMenuType.User)
            {
                acBarButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                acBarButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                acBarButtonItem3.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                acBarSubItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                acBarButtonItem4.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                acBarButtonItem5.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
            else if (e.MenuType == GridMenuType.Row)
            {
                if (e.HitInfo.RowHandle >= 0)
                {
                    acBarSubItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    acBarButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    acBarButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    acBarButtonItem3.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

                    acBarButtonItem4.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    acBarButtonItem5.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                }
                else
                {
                    acBarSubItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    acBarButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    acBarButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    acBarButtonItem3.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

                    acBarButtonItem4.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    acBarButtonItem5.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                }

            }


            if (e.HitInfo.HitTest == GridHitTest.Row || e.HitInfo.HitTest == GridHitTest.RowCell)
            {

                GridHitInfo hitInfo = view.CalcHitInfo(e.Point);

                popupMenu1.ShowPopup(view.GridControl.PointToScreen(e.Point));


            }

        }

        private int _oldRowHandel = -1;

        void acGridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            acGridView view = sender as acGridView;

            if (this._IsChanged == true && acMessageBox.Show(this, "수정된 항목이 있습니다.계속진행 하시겠습니까?", "QAISR59B", false, acMessageBox.emMessageBoxType.YESNO) != DialogResult.Yes)
            {
                acGridView1.FocusedRowChanged -= acGridView1_FocusedRowChanged;
                acGridView1.FocusedRowHandle = this._oldRowHandel;
                //acGridView1.SetOldFocusRowHandle(true);
                acGridView1.FocusedRowChanged += acGridView1_FocusedRowChanged;
                return;
            }

            this._oldRowHandel = acGridView1.FocusedRowHandle;
            this._IsChanged = false;


            if (this._IsChanged == true && acMessageBox.Show(this, "수정된 항목이 있습니다.계속진행 하시겠습니까?", "QAISR59B", false, acMessageBox.emMessageBoxType.YESNO) != DialogResult.Yes)
            {
                acGridView1.FocusedRowChanged -= acGridView1_FocusedRowChanged;
                acGridView1.FocusedRowHandle = this._oldRowHandel;
                //acGridView1.SetOldFocusRowHandle(true);
                acGridView1.FocusedRowChanged += acGridView1_FocusedRowChanged;
                return;
            }

            this._oldRowHandel = acGridView1.FocusedRowHandle;

            DataRow focusRow = acGridView1.GetFocusedDataRow();

            if (focusRow == null)
            {
                this.acAttachFileControl1.LinkKey = null;
                this.acAttachFileControl1.ShowKey = null;
            }
            else if (view.ValidFocusRowHandle())
            {
                object linkKey = focusRow["PT_ID"];

                if (focusRow["CHAIN_WO_NO"].ToString() != "")
                {
                    linkKey = focusRow["CHAIN_WO_NO"];
                }

                this.acAttachFileControl1.LinkKey = linkKey;
                this.acAttachFileControl1.ShowKey = new object[] { linkKey };

                //this.acAttachFileControl1.LinkKey = focusRow["PT_ID"];
                //this.acAttachFileControl1.ShowKey = new object[] { focusRow["PT_ID"] };
            }
            else
            {

                this.acAttachFileControl1.LinkKey = null;
                this.acAttachFileControl1.ShowKey = null;
            }
        }


        void Search()
        {
            //조회
            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("CAM_EMP", typeof(String)); //작업자
            paramTable.Columns.Add("IS_END", typeof(String));
            paramTable.Columns.Add("PART_LIKE", typeof(String));

            paramTable.Columns.Add("PROD_LIKE", typeof(String));
            paramTable.Columns.Add("CHAIN_WO_LIKE", typeof(String));
            

            paramTable.Columns.Add("MAT_QLTY", typeof(String)); 
            //paramTable.Columns.Add("S_PLN_DATE", typeof(String));
            //paramTable.Columns.Add("E_PLN_DATE", typeof(String));
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
            paramTable.Columns.Add("S_ACT_DATE", typeof(String)); //실적완료일 시작일
            paramTable.Columns.Add("E_ACT_DATE", typeof(String)); //실적완료일 종료일

            DataRow layoutRow = acLayoutControl1.CreateParameterRow();

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;                        
            paramRow["CAM_EMP"] = layoutRow["CAM_EMP"];
            paramRow["IS_END"] = acCheckEdit1.Checked ? "" : "1";
            paramRow["PART_LIKE"] = layoutRow["PART_LIKE"];
            paramRow["MAT_QLTY"] = layoutRow["MAT_QLTY"];

            paramRow["PROD_LIKE"] = layoutRow["PROD_LIKE"];
            paramRow["CHAIN_WO_LIKE"] = layoutRow["CHAIN_WO_LIKE"];

            if (acCheckEdit1.Checked)
            {
                paramRow["S_ACT_DATE"] = layoutRow["S_DATE"];
                paramRow["E_ACT_DATE"] = layoutRow["E_DATE"];

                //foreach (string key in acCheckedComboBoxEdit1.GetKeyChecked())
                //{
                //    switch (key)
                //    {
                //        case "REG_DATE":
                //            //등록일
                //            paramRow["S_REG_DATE"] = layoutRow["S_DATE"];
                //            paramRow["E_REG_DATE"] = layoutRow["E_DATE"];

                //            break;
                //        case "ORD_DATE":
                //            //수주일
                //            paramRow["S_ORD_DATE"] = layoutRow["S_DATE"];
                //            paramRow["E_ORD_DATE"] = layoutRow["E_DATE"];

                //            break;
                //        case "DUE_DATE":
                //            //납기일
                //            paramRow["S_DUE_DATE"] = layoutRow["S_DATE"];
                //            paramRow["E_DUE_DATE"] = layoutRow["E_DATE"];

                //            break;
                //        case "SHIP_DATE":
                //            //출하일
                //            paramRow["S_SHIP_DATE"] = layoutRow["S_DATE"];
                //            paramRow["E_SHIP_DATE"] = layoutRow["E_DATE"];

                //            break;
                //        case "DELIVERY_DATE":
                //            //납품일
                //            paramRow["S_DELIVERY_DATE"] = layoutRow["S_DATE"];
                //            paramRow["E_DELIVERY_DATE"] = layoutRow["E_DATE"];

                //            break;
                //    }
                //}
            }

            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);


            BizRun.QBizRun.ExecuteService(
             this, QBiz.emExecuteType.LOAD,
             "POP02A_SER", paramSet, "RQSTDT", "RSLTDT",
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
                    acGridView1.UpdateMapingRow(row, false);
                }

                this._IsChanged = false;

                acGridView1.ClearSelection();

                acAlert.Show(this, "저장되었습니다.", acAlertForm.enmType.Success);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //작업내용 저장
            try
            {
                //if (acGridView2.RowCount == 0)
                //    return;
                
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
                paramTable.Columns.Add("P_CNT", typeof(float)); //
                paramTable.Columns.Add("MIL_REQ_DATE", typeof(String)); //
                paramTable.Columns.Add("PART_CODE", typeof(String)); //
                paramTable.Columns.Add("MAT_CODE", typeof(String)); //
                paramTable.Columns.Add("MAT_QLTY", typeof(String)); //
                paramTable.Columns.Add("MC_GROUP", typeof(String)); //
                paramTable.Columns.Add("SCOMMENT", typeof(String)); //
                paramTable.Columns.Add("REG_EMP", typeof(String)); //
                paramTable.Columns.Add("RE_WO_NO", typeof(String)); //
                paramTable.Columns.Add("OVERWRITE", typeof(String)); //

                //DataRow[] rows = acGridView2.GetSelectedDataRows();

                //if (rows.Length == 0)
                //    return;

                Dictionary<string, string> dic = new Dictionary<string, string>();

                foreach (DataRow row in acGridView1.GetAddModifyRows().Rows)
                {

                    if (row["CHAIN_WO_NO"].ToString() != "")
                    {
                        if (!dic.ContainsKey(row["CHAIN_WO_NO"].ToString()))
                        {
                            dic.Add(row["CHAIN_WO_NO"].ToString(), row["MC_GROUP"].ToString());
                        }
                        else
                        {
                            if (dic[row["CHAIN_WO_NO"].ToString()] != row["MC_GROUP"].ToString())
                            {
                                acAlert.Show(this, "묶음작업 설비그룹 삭제후 재선택 해주시기 바랍니다.", acAlertForm.enmType.Info);
                                return;
                            }
                        }
                    }

                    DataRow paramRow = paramTable.NewRow();
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["ACTUAL_ID"] = row["ACTUAL_ID"];
                    paramRow["PT_ID"] = row["PT_ID"];
                    paramRow["WO_NO"] = row["WO_NO"];
                    paramRow["EMP_CODE"] = acInfo.UserID;
                    paramRow["X_VALUE"] = row["X_VALUE"];
                    paramRow["Y_VALUE"] = row["Y_VALUE"];
                    paramRow["T_VALUE"] = row["T_VALUE"];
                    paramRow["P_CNT"] = row["P_CNT"];
                    paramRow["MIL_REQ_DATE"] = row["MIL_REQ_DATE"].toDateString("yyyyMMdd");
                    paramRow["PART_CODE"] = row["PART_CODE"];
                    paramRow["MAT_CODE"] = row["MAT_CODE"];
                    paramRow["MAT_QLTY"] = row["MAT_QLTY"];

                    //if (row["MC_GROUP"].ToString() == "")
                    //{
                    //    acMessageBox.Show(this, "설비그룹이 없습니다.", "", false, acMessageBox.emMessageBoxType.CONFIRM);
                    //    return;
                    //}

                    paramRow["MC_GROUP"] = row["MC_GROUP"];
                    paramRow["SCOMMENT"] = row["SCOMMENT"];
                    paramRow["REG_EMP"] = acInfo.UserID;
                    paramRow["RE_WO_NO"] = row["RE_WO_NO"];
                    paramRow["OVERWRITE"] = "1";
                    paramTable.Rows.Add(paramRow);

                }

                {
                    DataSet paramSet = new DataSet();
                    paramSet.Tables.Add(paramTable);

                    BizRun.QBizRun.ExecuteService(
                    this, QBiz.emExecuteType.PROCESS, "POP02A_SAVE", paramSet, "RQSTDT", "RSLTDT",
                    QuickSave,
                    QuickException);
                }
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

                if (acGridView1.RowCount == 0) return;

                if (acMessageBox.Show(this, "완료 처리 하시겠습니까?", "", false, acMessageBox.emMessageBoxType.YESNO) != DialogResult.Yes)
                {
                    return;
                }


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
                paramTable.Columns.Add("P_CNT", typeof(float)); //
                paramTable.Columns.Add("MIL_REQ_DATE", typeof(String)); //
                paramTable.Columns.Add("PART_CODE", typeof(String)); //
                paramTable.Columns.Add("MAT_CODE", typeof(String)); //
                paramTable.Columns.Add("MAT_QLTY", typeof(String)); //
                paramTable.Columns.Add("ACT_QTY", typeof(int)); //
                paramTable.Columns.Add("MC_GROUP", typeof(String)); //
                paramTable.Columns.Add("SCOMMENT", typeof(String)); //
                paramTable.Columns.Add("REG_EMP", typeof(String)); //
                paramTable.Columns.Add("RE_WO_NO", typeof(String)); //
                paramTable.Columns.Add("OVERWRITE", typeof(String)); //
                paramTable.Columns.Add("CHAIN_WO_NO", typeof(String)); //

                DataView selectedView = acGridView1.GetDataSourceView("SEL = '1'");

                Dictionary<string, string> dic = new Dictionary<string, string>();

                if (selectedView.Count == 0)
                {
                    DataRow focusRow = acGridView1.GetFocusedDataRow();

                    if (focusRow["CHAIN_WO_NO"].ToString() == "")
                    {
                        DataRow paramRow = paramTable.NewRow();
                        paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                        paramRow["ACTUAL_ID"] = focusRow["ACTUAL_ID"];
                        paramRow["PT_ID"] = focusRow["PT_ID"];
                        paramRow["WO_NO"] = focusRow["WO_NO"];
                        paramRow["EMP_CODE"] = acInfo.UserID;
                        paramRow["X_VALUE"] = focusRow["X_VALUE"];
                        paramRow["Y_VALUE"] = focusRow["Y_VALUE"];
                        paramRow["T_VALUE"] = focusRow["T_VALUE"];
                        paramRow["P_CNT"] = focusRow["P_CNT"];
                        paramRow["MIL_REQ_DATE"] = focusRow["MIL_REQ_DATE"].toDateString("yyyyMMdd");
                        paramRow["PART_CODE"] = focusRow["PART_CODE"];
                        paramRow["MAT_CODE"] = focusRow["MAT_CODE"];
                        paramRow["MAT_QLTY"] = focusRow["MAT_QLTY"];
                        paramRow["ACT_QTY"] = focusRow["PART_QTY"];

                        //if (focusRow["MC_GROUP"].ToString() == "")
                        //{
                        //    acMessageBox.Show(this, "설비그룹이 없습니다.", "", false, acMessageBox.emMessageBoxType.CONFIRM);
                        //    return;
                        //}

                        paramRow["MC_GROUP"] = focusRow["MC_GROUP"];
                        paramRow["SCOMMENT"] = focusRow["SCOMMENT"];
                        paramRow["REG_EMP"] = acInfo.UserID;
                        paramRow["RE_WO_NO"] = focusRow["RE_WO_NO"];
                        paramRow["OVERWRITE"] = "1";
                        paramRow["CHAIN_WO_NO"] = focusRow["CHAIN_WO_NO"];
                        paramTable.Rows.Add(paramRow);
                    }
                    else
                    {
                        DataView chainView = acGridView1.GetDataSourceView("CHAIN_WO_NO = '" + focusRow["CHAIN_WO_NO"].ToString() + "'");

                        for (int i = 0; i < chainView.Count; i++)
                        {
                            if (chainView[i]["CHAIN_WO_NO"].ToString() != "")
                            {
                                if (!dic.ContainsKey(chainView[i]["CHAIN_WO_NO"].ToString()))
                                {
                                    dic.Add(chainView[i]["CHAIN_WO_NO"].ToString(), chainView[i]["MC_GROUP"].ToString());
                                }
                                else
                                {
                                    if (dic[chainView[i]["CHAIN_WO_NO"].ToString()] != chainView[i]["MC_GROUP"].ToString())
                                    {
                                        acAlert.Show(this, "묶음작업 설비그룹 삭제후 재선택 해주시기 바랍니다.", acAlertForm.enmType.Info);
                                        return;
                                    }
                                }
                            }

                            DataRow paramRow = paramTable.NewRow();
                            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                            paramRow["ACTUAL_ID"] = chainView[i]["ACTUAL_ID"];
                            paramRow["PT_ID"] = chainView[i]["PT_ID"];
                            paramRow["WO_NO"] = chainView[i]["WO_NO"];
                            paramRow["EMP_CODE"] = acInfo.UserID;
                            paramRow["X_VALUE"] = chainView[i]["X_VALUE"];
                            paramRow["Y_VALUE"] = chainView[i]["Y_VALUE"];
                            paramRow["T_VALUE"] = chainView[i]["T_VALUE"];
                            paramRow["P_CNT"] = chainView[i]["P_CNT"];
                            paramRow["MIL_REQ_DATE"] = chainView[i]["MIL_REQ_DATE"].toDateString("yyyyMMdd");
                            paramRow["PART_CODE"] = chainView[i]["PART_CODE"];
                            paramRow["MAT_CODE"] = chainView[i]["MAT_CODE"];
                            paramRow["MAT_QLTY"] = chainView[i]["MAT_QLTY"];
                            paramRow["ACT_QTY"] = chainView[i]["PART_QTY"];

                            //if (chainView[i]["MC_GROUP"].ToString() == "")
                            //{
                            //    acMessageBox.Show(this, "설비그룹이 없습니다.", "", false, acMessageBox.emMessageBoxType.CONFIRM);
                            //    return;
                            //}

                            paramRow["MC_GROUP"] = chainView[i]["MC_GROUP"];
                            paramRow["SCOMMENT"] = chainView[i]["SCOMMENT"];
                            paramRow["REG_EMP"] = acInfo.UserID;
                            paramRow["RE_WO_NO"] = chainView[i]["RE_WO_NO"];
                            paramRow["OVERWRITE"] = "1";
                            paramRow["CHAIN_WO_NO"] = chainView[i]["CHAIN_WO_NO"];
                            paramTable.Rows.Add(paramRow);
                        }

                    }
                }
                else
                {
                    for (int i = 0; i < selectedView.Count; i++)
                    {
                        if (!dic.ContainsKey(selectedView[i]["CHAIN_WO_NO"].ToString()))
                        {
                            dic.Add(selectedView[i]["CHAIN_WO_NO"].ToString(), selectedView[i]["MC_GROUP"].ToString());
                        }
                        else
                        {
                            if (dic[selectedView[i]["CHAIN_WO_NO"].ToString()] != selectedView[i]["MC_GROUP"].ToString())
                            {
                                acAlert.Show(this, "묶음작업 설비그룹 삭제후 재선택 해주시기 바랍니다.", acAlertForm.enmType.Info);
                                return;
                            }
                        }

                        DataRow paramRow = paramTable.NewRow();
                        paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                        paramRow["ACTUAL_ID"] = selectedView[i]["ACTUAL_ID"];
                        paramRow["PT_ID"] = selectedView[i]["PT_ID"];
                        paramRow["WO_NO"] = selectedView[i]["WO_NO"];
                        paramRow["EMP_CODE"] = acInfo.UserID;
                        paramRow["X_VALUE"] = selectedView[i]["X_VALUE"];
                        paramRow["Y_VALUE"] = selectedView[i]["Y_VALUE"];
                        paramRow["T_VALUE"] = selectedView[i]["T_VALUE"];
                        paramRow["P_CNT"] = selectedView[i]["P_CNT"];
                        paramRow["MIL_REQ_DATE"] = selectedView[i]["MIL_REQ_DATE"].toDateString("yyyyMMdd");
                        paramRow["PART_CODE"] = selectedView[i]["PART_CODE"];
                        paramRow["MAT_CODE"] = selectedView[i]["MAT_CODE"];
                        paramRow["MAT_QLTY"] = selectedView[i]["MAT_QLTY"];
                        paramRow["ACT_QTY"] = selectedView[i]["PART_QTY"];
                        paramRow["MC_GROUP"] = selectedView[i]["MC_GROUP"];
                        paramRow["SCOMMENT"] = selectedView[i]["SCOMMENT"];
                        paramRow["REG_EMP"] = acInfo.UserID;
                        paramRow["RE_WO_NO"] = selectedView[i]["RE_WO_NO"];
                        paramRow["CHAIN_WO_NO"] = selectedView[i]["CHAIN_WO_NO"];
                        paramRow["OVERWRITE"] = "1";
                        paramTable.Rows.Add(paramRow);
                    }
                }

                //DataRow[] rows = acGridView1.GetSelectedDataRows();

                //if (rows.Length == 0)
                //    rows = new DataRow[] { acGridView1.GetFocusedDataRow() };

                //foreach (DataRow row in rows)
                //{

                //    DataRow paramRow = paramTable.NewRow();
                //    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                //    paramRow["ACTUAL_ID"] = row["ACTUAL_ID"];
                //    paramRow["PT_ID"] = row["PT_ID"];
                //    paramRow["WO_NO"] = row["WO_NO"];
                //    paramRow["EMP_CODE"] = acInfo.UserID;
                //    paramRow["X_VALUE"] = row["X_VALUE"];
                //    paramRow["Y_VALUE"] = row["Y_VALUE"];
                //    paramRow["T_VALUE"] = row["T_VALUE"];
                //    paramRow["PART_CODE"] = row["PART_CODE"];
                //    paramRow["MAT_CODE"] = row["MAT_CODE"];
                //    paramRow["MAT_QLTY"] = row["MAT_QLTY"];
                //    paramRow["ACT_QTY"] = row["PART_QTY"];
                //    paramRow["MC_GROUP"] = row["MC_GROUP"];
                //    paramRow["SCOMMENT"] = row["SCOMMENT"];
                //    paramRow["REG_EMP"] = acInfo.UserID;
                //    paramRow["OVERWRITE"] = "1";
                //    paramTable.Rows.Add(paramRow);

                //}

                {
                    DataSet paramSet = new DataSet();
                    paramSet.Tables.Add(paramTable);

                    BizRun.QBizRun.ExecuteService(
                    this, QBiz.emExecuteType.PROCESS, "POP02A_UPD", paramSet, "RQSTDT", "RSLTDT",
                    QuickUPD,
                    QuickException);
                }
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

                acGridView1.RaiseFocusedRowChanged();

                //acGridView1.ClearSelection();


                acAlert.Show(this, "완료 되었습니다.", acAlertForm.enmType.Success);
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

                    string MC_GROUP = "";
                    string X_VALUE = "";
                    string Y_VALUE = "";
                    string T_VALUE = "";
                    string P_CNT = "";
                    string MIL_REQ_DATE = "";
                    string MAT_CODE = "";
                    string MAT_CODE_NAME = "";
                    string MAT_QLTY = "";
                    string SCOMMENT = "";

                    for (int i = 0; i < selectedView.Count; i++)
                    {
                        if (selectedView[i]["CHAIN_WO_NO"].ToString() != "")
                        {
                            acAlert.Show(this, "묶음처리되어있는 품목이 존재합니다", acAlertForm.enmType.Warning);
                            return;
                        }

                        if (i > 0)
                        {
                            if (selectedView[i]["MC_GROUP"].ToString() != MC_GROUP || selectedView[i]["X_VALUE"].ToString() != X_VALUE
                                || selectedView[i]["Y_VALUE"].ToString() != Y_VALUE || selectedView[i]["T_VALUE"].ToString() != T_VALUE
                                || selectedView[i]["P_CNT"].ToString() != P_CNT || selectedView[i]["MAT_CODE"].ToString() != MAT_CODE
                                || selectedView[i]["MAT_CODE_NAME"].ToString() != MAT_CODE_NAME || selectedView[i]["MAT_QLTY"].ToString() != MAT_QLTY
                                || selectedView[i]["SCOMMENT"].ToString() != SCOMMENT || selectedView[i]["MIL_REQ_DATE"].toDateString("yyyyMMdd") != MIL_REQ_DATE)
                            {
                                acAlert.Show(this, "다른 입력값이 존재합니다.", acAlertForm.enmType.Warning);
                                return;
                            }
                        }

                        DataRow paramRow = paramTable.NewRow();
                        paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                        paramRow["PROD_CODE"] = selectedView[i]["PROD_CODE"];
                        paramRow["PART_CODE"] = selectedView[i]["PART_CODE"];
                        paramRow["PT_ID"] = selectedView[i]["PT_ID"];
                        paramRow["WO_NO"] = selectedView[i]["WO_NO"];
                        paramRow["RE_WO_NO"] = selectedView[i]["RE_WO_NO"];

                        paramTable.Rows.Add(paramRow);

                        MC_GROUP = selectedView[i]["MC_GROUP"].ToString();
                        X_VALUE = selectedView[i]["X_VALUE"].ToString();
                        Y_VALUE = selectedView[i]["Y_VALUE"].ToString();
                        T_VALUE = selectedView[i]["T_VALUE"].ToString();
                        P_CNT = selectedView[i]["P_CNT"].ToString();
                        MIL_REQ_DATE = selectedView[i]["MIL_REQ_DATE"].toDateString("yyyyMMdd");
                        MAT_CODE = selectedView[i]["MAT_CODE"].ToString();
                        MAT_CODE_NAME = selectedView[i]["MAT_CODE_NAME"].ToString();
                        MAT_QLTY = selectedView[i]["MAT_QLTY"].ToString();
                        SCOMMENT = selectedView[i]["SCOMMENT"].ToString();
                    }

                    DataSet paramSet = new DataSet();
                    paramSet.Tables.Add(paramTable);

                    BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.PROCESS, "POP02A_INS", paramSet, "RQSTDT", "RSLTDT",
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

                    DataView chainView = acGridView1.GetDataSourceView("CHAIN_WO_NO = '" + focusRow["CHAIN_WO_NO"].ToString() + "'");

                    for (int i = 0; i < chainView.Count; i++)
                    {
                        DataRow paramRow = paramTable.NewRow();
                        paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                        paramRow["PROD_CODE"] = chainView[i]["PROD_CODE"];
                        paramRow["PART_CODE"] = chainView[i]["PART_CODE"];
                        paramRow["PT_ID"] = chainView[i]["PT_ID"];
                        paramRow["WO_NO"] = chainView[i]["WO_NO"];

                        paramTable.Rows.Add(paramRow);
                    }
                }

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.PROCESS, "POP02A_INS2", paramSet, "RQSTDT", "RSLTDT",
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
                    if (row["CHAIN_WO_NO"].ToString() != "")
                    {
                        Set_Color(row["CHAIN_WO_NO"].ToString());
                    }

                    this.acGridView1.UpdateMapingRow(row, false);
                }

                acGridView1.RaiseFocusedRowChanged();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void acBarButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //완료취소

            try
            {

                if (acGridView1.RowCount == 0) return;

                if (acMessageBox.Show(this, "완료취소 처리 하시겠습니까?", "", false, acMessageBox.emMessageBoxType.YESNO) != DialogResult.Yes)
                {
                    return;
                }


                acGridView1.EndEditor();


                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //사업장 코드
                paramTable.Columns.Add("ACTUAL_ID", typeof(String)); //
                paramTable.Columns.Add("WO_NO", typeof(String)); //
                paramTable.Columns.Add("PT_ID", typeof(String)); //
                paramTable.Columns.Add("RE_WO_NO", typeof(string));

                DataView selectedView = acGridView1.GetDataSourceView("SEL = '1'");

                if (selectedView.Count == 0)
                {
                    DataRow focusRow = acGridView1.GetFocusedDataRow();

                    if (focusRow["CHAIN_WO_NO"].ToString() == "")
                    {
                        DataRow paramRow = paramTable.NewRow();
                        paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                        paramRow["ACTUAL_ID"] = focusRow["ACTUAL_ID"];
                        paramRow["WO_NO"] = focusRow["WO_NO"];
                        paramRow["RE_WO_NO"] = focusRow["RE_WO_NO"];
                        paramRow["PT_ID"] = focusRow["PT_ID"];
                        paramTable.Rows.Add(paramRow);
                    }
                    else
                    {
                        DataView chainView = acGridView1.GetDataSourceView("CHAIN_WO_NO = '" + focusRow["CHAIN_WO_NO"].ToString() + "'");

                        for (int i = 0; i < chainView.Count; i++)
                        {
                            DataRow paramRow = paramTable.NewRow();
                            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                            paramRow["ACTUAL_ID"] = chainView[i]["ACTUAL_ID"];
                            paramRow["WO_NO"] = chainView[i]["WO_NO"];
                            paramRow["RE_WO_NO"] = chainView[i]["RE_WO_NO"];
                            paramRow["PT_ID"] = chainView[i]["PT_ID"];
                            paramTable.Rows.Add(paramRow);
                        }

                    }
                }
                else
                {
                    for (int i = 0; i < selectedView.Count; i++)
                    {
                        DataRow paramRow = paramTable.NewRow();
                        paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                        paramRow["ACTUAL_ID"] = selectedView[i]["ACTUAL_ID"];
                        paramRow["WO_NO"] = selectedView[i]["WO_NO"];
                        paramRow["RE_WO_NO"] = selectedView[i]["RE_WO_NO"];
                        paramRow["PT_ID"] = selectedView[i]["PT_ID"];
                        paramTable.Rows.Add(paramRow);
                    }
                }
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.PROCESS, "POP02A_UPD2", paramSet, "RQSTDT", "RSLTDT",
                QuickUPD2,
                QuickException);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void QuickUPD2(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                foreach (DataRow row in e.result.Tables["RSLTDT"].Rows)
                {
                    acGridView1.UpdateMapingRow(row, false);
                }

                acGridView1.RaiseFocusedRowChanged();

                acAlert.Show(this, "완료 되었습니다.", acAlertForm.enmType.Success);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void acBarButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!base.ChildFormContains("NEW"))
                {
                    DataRow focusRow = acGridView1.GetFocusedDataRow();

                    if (focusRow == null) return;

                    POP05A_D0A frm = new POP05A_D0A(acGridView1, focusRow);

                    frm.DialogMode = BaseMenuDialog.emDialogMode.NEW;

                    frm.ParentControl = this;

                    base.ChildFormAdd("NEW", frm);

                    frm.Show(this);


                }
                else
                {
                    base.ChildFormFocus("NEW");
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void acBarButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                DataRow focusRow = acGridView1.GetFocusedDataRow();

                if (focusRow == null) return;

                if (focusRow["NG_ID"].ToString() != "")
                {
                    DataTable paramTable = new DataTable("RQSTDT");
                    paramTable.Columns.Add("PLT_CODE", typeof(string));
                    paramTable.Columns.Add("NG_ID", typeof(string));

                    DataRow paramRow = paramTable.NewRow();
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["NG_ID"] = focusRow["NG_ID"];

                    paramTable.Rows.Add(paramRow);

                    DataSet paramSet = new DataSet();
                    paramSet.Tables.Add(paramTable);

                    DataSet resultSet = BizRun.QBizRun.ExecuteService(this, "POP02A_SER7", paramSet, "RQSTDT", "RSLTDT");

                    if (resultSet.Tables["RSLTDT"].Rows.Count > 0)
                    {
                        POP02A_D1A frm = new POP02A_D1A(null, resultSet.Tables["RSLTDT"].Rows[0], true);

                        frm.DialogMode = BaseMenuDialog.emDialogMode.OPEN;

                        frm.ParentControl = this;

                        frm.Text = "불량";

                        frm.Show(this);
                    }
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }
    }

}
