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
using DevExpress.XtraEditors.Registrator;
using DevExpress.XtraEditors.Repository;
using System.Collections;
using System.IO;
using DevExpress.XtraEditors.Controls;

namespace POP
{
    public sealed partial class POP05A_M0A : BaseMenu
    {

        Dictionary<string, Color> _SetColor = new Dictionary<string, Color>();
        Dictionary<Color, string> _SetColor2 = new Dictionary<Color, string>();

        public POP05A_M0A()
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
            string[] barcodes = barcode.Split(';');

            if (barcodes.Length > 1)
            {
                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String));
                paramTable.Columns.Add("PROD_CODE", typeof(String));
                paramTable.Columns.Add("PART_CODE", typeof(String));
                paramTable.Columns.Add("PROC_CODE_IN", typeof(String));
                paramTable.Columns.Add("IS_END", typeof(String));

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["PROD_CODE"] = barcodes[0];
                paramRow["PART_CODE"] = barcodes[1];
                paramRow["IS_END"] = acCheckEdit1.Checked ? "" : "1";

                foreach (string key in acCheckedComboBoxEdit2.GetKeyChecked())
                {
                    paramRow["PROC_CODE_IN"] += "," + key + "";
                }

                if (paramRow["PROC_CODE_IN"].ToString().Length > 0)
                {
                    paramRow["PROC_CODE_IN"] = paramRow["PROC_CODE_IN"].ToString().Substring(1, paramRow["PROC_CODE_IN"].ToString().Length - 1);
                }

                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(
                 this, QBiz.emExecuteType.LOAD,
                 "POP05A_SER4", paramSet, "RQSTDT", "RSLTDT",
                 QuickSearch,
                 QuickException);
            }
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
            this.OnLoad(null);
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


        //private Hashtable _htWoList = null;
        //private Hashtable _htWoFig = null;
        
        public override void MenuInit()
        {

            acGridView1.GridType = acGridView.emGridType.SEARCH;

            acGridView1.AddCheckEdit("SEL", "선택", "", false, true, true, acGridView.emCheckEditDataType._STRING);

            acGridView1.AddTextEdit("CHAIN_WO_NO", "묶음 작업지시번호", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddLookUpEdit("IS_REWORK", "재작업 여부", "", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "W012");
            acGridView1.AddLookUpEdit("PROD_PRIORITY", "우선순위", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P028");
            acGridView1.AddLookUpEdit("INS_STATE", "상태", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "S032");
            acGridView1.AddTextEdit("PROD_CODE", "수주번호", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddLookUpEdit("PROD_FLAG", "수주유형", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P006");
            acGridView1.AddTextEdit("PROD_NAME", "모델명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("PROD_VERSION", "버전", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddLookUpEdit("PROD_KIND", "제품구분", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "C011");
            acGridView1.AddCheckedComboBoxEdit("PROD_CATEGORY", "제품유형", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, "P009");
            acGridView1.AddLookUpEmp("BUSINESS_EMP", "영업담당자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false);
            acGridView1.AddTextEdit("CUSTOMER_EMP", "고객담당자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("CUSTDESIGN_EMP", "고객설계자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("CVND_CODE", "발주처코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("CVND_NAME", "발주처", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddDateEdit("ORD_DATE", "수주일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
            acGridView1.AddDateEdit("DUE_DATE", "출하예정일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
            acGridView1.AddDateEdit("CHG_DUE_DATE", "출하조정일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
            //acGridView1.AddDateEdit("DELIVERY_DATE", "납품일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);

            //acGridView1.AddCheckedComboBoxEdit("PROBE_PIN", "Probe Pin", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, "P011");
            acGridView1.AddLookUpEdit("PIN_TYPE", "Contact", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P011");
            acGridView1.AddLookUpEdit("PROD_TYPE", "제품분류", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P010");
            acGridView1.AddDateEdit("PREV_ACT_END_TIME", "가공완료시간", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.MEDIUM_DATE2);
            acGridView1.AddTextEdit("PROD_QTY", "수주수량", "CPW0FS8W", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NUMERIC);
            acGridView1.AddTextEdit("PART_QTY", "수량", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView1.AddTextEdit("ACT_QTY", "가공완료수량", "CPW0FS8W", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NUMERIC);
            acGridView1.AddTextEdit("OLD_INS_QTY", "검사완료수량", "CPW0FS8W", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NUMERIC);

            acGridView1.AddLookUpEmp("INS_EMP", "검사자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false);
            acGridView1.AddDateEdit("INS_DATE", "최종완료일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);

            acGridView1.AddTextEdit("DRAW_EMP", "조립품 개발자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

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

            acGridView1.AddLookUpEdit("IS_OS", "제작구분", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P016");
            acGridView1.AddTextEdit("PART_CODE", "부품코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("PART_NAME", "부품명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("DRAW_NO", "도면명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("MAT_SPEC", "규격", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("PROC_CODE", "작업코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("PROC_NAME", "작업명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("MAT_NAME", "소재명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddLookUpEdit("MC_GROUP", "설비그룹", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "C020");
            acGridView1.AddLookUpEmp("CAM_EMP", "CAM 담당자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false);
            acGridView1.AddTextEdit("SCOMMENT", "CAM 비고", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("PT_SCOMMENT", "생산계획 비고", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("ORD_SCOMMENT", "영업 전달사항", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("X_VALUE", "X", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NUMERIC);
            acGridView1.AddTextEdit("Y_VALUE", "Y", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NUMERIC);
            acGridView1.AddTextEdit("T_VALUE", "두께(T)", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.F3);
            acGridView1.AddTextEdit("P_CNT", "판수", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NUMERIC);


            acGridView1.AddTextEdit("O_EMP_CODE", "발주자 코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("O_EMP_NAME", "발주자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("OVND_CODE", "외주처 코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("OVND_NAME", "외주처", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("UNIT_COST", "단가", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
            acGridView1.AddTextEdit("AMT", "금액", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
            acGridView1.AddTextEdit("MAT_COST", "구매단가", "", false, DevExpress.Utils.HorzAlignment.Far, false, false, false, acGridView.emTextEditMask.MONEY);

            DataTable workTable = acInfo.StdCodes.GetCatTable("Q008");

            foreach (DataRow row in workTable.Rows)
            {
                acGridView1.AddCheckEdit("INS_WORK_" + row["CD_CODE"].ToString(), row["CD_NAME"].ToString(), "", false, true, true, acGridView.emCheckEditDataType._STRING);
            }

            acGridView1.AddCheckEdit("IS_ATTACH", "성적서 유무", "", false, false, true, acGridView.emCheckEditDataType._STRING);
            //acGridView1.AddButtonEdit("ATTACH", "업로드/다운로드", "", false, DevExpress.Utils.HorzAlignment.Center, DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor, true, true, false, POP.Resource.mail_attachment_2x, DevExpress.LookAndFeel.SkinStyle.TheAsphaltWorld);
            //acGridView1.Columns["ATTACH"].ColumnEdit.Click += ATTACH_Click;

            RepositoryItemHyperLinkEdit repItemHLE = new RepositoryItemHyperLinkEdit();
            repItemHLE.NullText = "업로드/다운로드";

            acGridView1.AddCustomEdit("ATTACH", "업로드/다운로드", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, repItemHLE);
            acGridView1.RowClick += AcGridView1_RowClick;

            acGridView1.AddButtonEdit("INS_QTY", "검사수량", "", false, DevExpress.Utils.HorzAlignment.Far, DevExpress.XtraEditors.Controls.TextEditStyles.Standard, true, true, false);

            RepositoryItemButtonEdit buttonEdit = acGridView1.Columns["INS_QTY"].RealColumnEdit as RepositoryItemButtonEdit;
            buttonEdit.Buttons.Clear();
            buttonEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "추가", 30, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), "", "FIND")
            ,new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "제거", 30, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), "", "FIND")});
            buttonEdit.Buttons[0].Click += ButtonEdit_Ins_Add_Click;
            buttonEdit.Buttons[1].Click += ButtonEdit_Ins_Del_Click;

            acGridView1.AddCheckedComboBoxEdit("INS_WORK", "검사현황", "", false, DevExpress.Utils.HorzAlignment.Near, false, false, false, "Q008");
            acGridView1.AddPictrue("INS_WORK_STATE", "진행현황 상태", "", false, DevExpress.Utils.HorzAlignment.Center, false, true);

            acGridView1.AddButtonEdit("INS_ALL_QTY", "일괄 추가", "", false, DevExpress.Utils.HorzAlignment.Center, TextEditStyles.HideTextEditor, true, true, false);
            RepositoryItemButtonEdit buttonEdit2 = acGridView1.Columns["INS_ALL_QTY"].RealColumnEdit as RepositoryItemButtonEdit;
            buttonEdit2.Buttons.Clear();
            buttonEdit2.Buttons.Add(new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "일괄 추가", 100, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), "", "FIND"));
            //buttonEdit2.Buttons[0].Click += ButtonEdit_Ins_All_Add_Click;


            acGridView1.Columns["INS_QTY"].Width = 150;

            buttonEdit.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            buttonEdit.Mask.EditMask = "N0";


            buttonEdit.KeyPress += buttonEdit_KeyPress;

            buttonEdit.MouseWheel += ButtonEdit_MouseWheel;

            buttonEdit.EditValueChanging += buttonEdit_EditValueChanging;


            acGridView1.Columns["INS_QTY"].ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;

            acGridView1.Columns["INS_QTY"].Fixed = FixedStyle.Right;
            acGridView1.Columns["INS_ALL_QTY"].Fixed = FixedStyle.Right;
            //acGridView1.Columns["INS_WORK"].Fixed = FixedStyle.Right;

            acGridView1.AddHidden("WO_NO", typeof(string));
            acGridView1.AddHidden("ACTUAL_ID", typeof(string));

            acGridView1.KeyColumn = new string[] { "WO_NO" };

            acGridView1.OptionsView.ShowIndicator = true;

            acCheckedComboBoxEdit1.AddItem("등록일", false, "", "REG_DATE", true, false);
            acCheckedComboBoxEdit1.AddItem("수주일", false, "", "ORD_DATE", true, false);
            acCheckedComboBoxEdit1.AddItem("출하예정일", false, "", "DUE_DATE", true, false);
            acCheckedComboBoxEdit1.AddItem("최종완료일", false, "", "INS_DATE", true, false);
            //acCheckedComboBoxEdit1.AddItem("납품일", false, "", "DELIVERY_DATE", true, false);

            DataSet resultSet = BizRun.QBizRun.ExecuteService(this, "POP05A_SER2", acInfo.RefData, "RQSTDT", "RSLTDT");

            DataSet paramSet = acInfo.RefData.Clone();

            paramSet.Tables["RQSTDT"].Columns.Add("MENU_CODE", typeof(string));

            DataRow paramRow = paramSet.Tables["RQSTDT"].NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["MENU_CODE"] = base.Name;
            paramSet.Tables["RQSTDT"].Rows.Add(paramRow);

            DataSet conResultSet = BizRun.QBizRun.ExecuteService(this, "POP05A_SER3", paramSet, "RQSTDT", "RSLTDT");

            string[] Conditions = new string[0];
            if (conResultSet.Tables["RSLTDT"].Rows.Count > 0)
            {
                DataRow[] rows = conResultSet.Tables["RSLTDT"].Select("CONTROL_NAME = '" + acCheckedComboBoxEdit2.Name + "'");
                if (rows.Length > 0)
                {
                    Conditions = rows[0]["CONDITION"].ToString().Split(',');
                }
            }

            foreach (DataRow row in resultSet.Tables["RSLTDT"].Rows)
            {
                //if (Conditions.Contains(row["PROC_CODE"].ToString()))
                //{
                //    acCheckedComboBoxEdit2.AddItem(row["PROC_NAME"].ToString(), false, "", row["PROC_CODE"].ToString(), true, false, CheckState.Checked);
                //}
                //else
                //{
                //    acCheckedComboBoxEdit2.AddItem(row["PROC_NAME"].ToString(), false, "", row["PROC_CODE"].ToString(), true, false);
                //}

                if (row["PROC_CODE"].ToString() == "P-06")
                {
                    acCheckedComboBoxEdit2.AddItem(row["PROC_NAME"].ToString(), false, "", row["PROC_CODE"].ToString(), true, false, CheckState.Checked);
                }
                else
                {
                    //acCheckedComboBoxEdit2.AddItem(row["PROC_NAME"].ToString(), false, "", row["PROC_CODE"].ToString(), true, false);
                }
            }

            this.acLayoutControl1.OnValueKeyDown += new acLayoutControl.ValueKeyDownEventHandler(acLayoutControl1_OnValueKeyDown);
            this.acLayoutControl1.OnValueChanged += new acLayoutControl.ValueChangedEventHandler(acLayoutControl1_OnValueChanged);

            this.acGridView1.CustomDrawCell += AcGridView1_CustomDrawCell;
            this.acGridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(acGridView1_FocusedRowChanged);
            this.acGridView1.ShowGridMenuEx += new acGridView.ShowGridMenuExHandler(acGridView1_ShowGridMenuEx);
            this.acGridView1.OnMapingRowChanged += new acGridView.MapingRowChangedEventHandler(acGridView1_OnMapingRowChanged);
            acGridView1.OptionsView.AllowCellMerge = true;

            acGridView1.Columns["INS_ALL_QTY"].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;

            acGridView1.CellMerge += acGridView1_CellMerge;

            this.acGridView1.MouseDown += acGridView1_MouseDown;

            acGridView1.CellValueChanged += acGridView1_CellValueChanged;

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

        private void acGridView1_CellMerge(object sender, CellMergeEventArgs e)
        {
            try
            {
                if (e.Column.FieldName.Equals("INS_ALL_QTY"))
                {
                    string cWo1 = acGridView1.GetRowCellValue(e.RowHandle1, "CHAIN_WO_NO").ToString();
                    string cWo2 = acGridView1.GetRowCellValue(e.RowHandle2, "CHAIN_WO_NO").ToString();

                    string cProc1 = acGridView1.GetRowCellValue(e.RowHandle1, "PROC_CODE").ToString();
                    string cProc2 = acGridView1.GetRowCellValue(e.RowHandle2, "PROC_CODE").ToString();

                    //if (cWo1 == cWo2
                    //    && cWo1 != "" && cWo2 != "")
                    //{
                    //    e.Merge = true;
                    //}
                    //else
                    //{
                    //    e.Merge = false;
                    //}

                    if (cWo1 == cWo2
                        && cWo1 != "" && cWo2 != ""
                        && cProc1 == cProc2)
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

        private void acGridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (e.Column.FieldName == "INS_WORK")
                {
                    //acGridView1.Columns["INS_WORK"].BestFit();
                }
            }
            catch
            { }
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

        private void ATTACH_Click(object sender, EventArgs e)
        {
            DataRow focusRow = acGridView1.GetFocusedDataRow();
            POP05A_D1A frm = new POP05A_D1A(focusRow);
            frm.ParentControl = this;
            frm.DialogMode = BaseMenuDialog.emDialogMode.NEW;
            frm.Show(this);
        }

        private void AcGridView1_RowClick(object sender, RowClickEventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo hi = (sender as GridView).CalcHitInfo(new Point(e.X, e.Y));

            if (hi.Column != null && hi.Column.FieldName == "ATTACH" && hi.InDataRow)
            {
                try
                {
                    DataRow focusRow = acGridView1.GetFocusedDataRow();
                    POP05A_D1A frm = new POP05A_D1A(focusRow);
                    frm.ParentControl = this;
                    frm.DialogMode = BaseMenuDialog.emDialogMode.NEW;
                    frm.Show(this);
                }
                catch (Exception ex)
                {
                    acMessageBox.Show(this, ex);
                }

            }
        }

        private void buttonEdit_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            Console.WriteLine(e.NewValue.ToString());

            if (e.NewValue.toInt() < 0)
                e.Cancel = true;
        }

        private void ButtonEdit_MouseWheel(object sender, MouseEventArgs e)
        {
            
        }

        private void buttonEdit_KeyPress(object sender, KeyPressEventArgs e)
        {
            int keyCode = (int)e.KeyChar;  // 46: Point  

            ButtonEdit buttonEdit = sender as ButtonEdit;

            if ((keyCode < 48 || keyCode > 57) && keyCode != 8 && keyCode != 46)
            {
                e.Handled = true;
            }
            if (keyCode == 46)
            {
                if (string.IsNullOrEmpty(buttonEdit.Text) || buttonEdit.Text.Contains('.') == true)
                {
                    e.Handled = true;
                }
            }        
        }

        private void acGridView1_MouseDown(object sender, MouseEventArgs e)
        {

            if ((Control.ModifierKeys & Keys.Control) != Keys.Control)
            {


                GridView view = sender as GridView;
                GridHitInfo hi = view.CalcHitInfo(e.Location);
                if (hi.InRowCell)
                {
                    if (hi.Column.RealColumnEdit.GetType() == typeof(RepositoryItemButtonEdit) && hi.Column.FieldName == "INS_QTY")
                    {
                        view.FocusedRowHandle = hi.RowHandle;
                        view.FocusedColumn = hi.Column;

                        view.ShowEditor();

                        //(view.ActiveEditor as ComboBoxEdit).ShowPopup();
                        //force button click  
                        ButtonEdit edit = (view.ActiveEditor as ButtonEdit);
                        //RepositoryItemTwoButtonEdit edit2 = hi.Column.RealColumnEdit as RepositoryItemTwoButtonEdit;
                        Rectangle rectangle = edit.Bounds;
                        if (rectangle.X + rectangle.Width - 45 < e.Location.X
                          && rectangle.X + rectangle.Width - 22 > e.Location.X)
                        {
 
                            ButtonEdit_Ins_Add_Click(null, null);
   
                        }
                        else if (rectangle.X + rectangle.Width - 23 < e.Location.X
                          && rectangle.X + rectangle.Width - 0 > e.Location.X)
                        {
                            ButtonEdit_Ins_Del_Click(null, null);
                        }
                    }
                    else if (hi.Column.RealColumnEdit.GetType() == typeof(RepositoryItemButtonEdit) && hi.Column.FieldName == "INS_ALL_QTY")
                    {
                        view.FocusedRowHandle = hi.RowHandle;
                        view.FocusedColumn = hi.Column;

                        view.ShowEditor();

                        //(view.ActiveEditor as ComboBoxEdit).ShowPopup();
                        //force button click  
                        ButtonEdit edit = (view.ActiveEditor as ButtonEdit);
                        //RepositoryItemTwoButtonEdit edit2 = hi.Column.RealColumnEdit as RepositoryItemTwoButtonEdit;
                        Rectangle rectangle = edit.Bounds;
                        if (rectangle.X + rectangle.Width - 110 <= e.Location.X
                          && rectangle.X + rectangle.Width >= e.Location.X)
                        {
                            ButtonEdit_Ins_All_Add_Click(null, null);
                        }

                    }
                }
            }
        }

        private void ButtonEdit_Ins_All_Add_Click(object sender, EventArgs e)
        {
            acGridView1.EndEditor();

            DataRow focusRow = acGridView1.GetFocusedDataRow();

            if (focusRow == null || focusRow["INS_QTY"].toInt() == 0)
            {
                return;
            }

            DataTable paramTable1 = new DataTable("RQSTDT");
            paramTable1.Columns.Add("PLT_CODE", typeof(String));
            //paramTable1.Columns.Add("ACTUAL_ID", typeof(String));
            paramTable1.Columns.Add("WO_NO", typeof(String));
            paramTable1.Columns.Add("PT_ID", typeof(String));
            paramTable1.Columns.Add("INS_QTY", typeof(Int32));
            paramTable1.Columns.Add("REG_EMP", typeof(String));
            paramTable1.Columns.Add("INS_WORK", typeof(String));

            if (focusRow["CHAIN_WO_NO"].ToString() == "")
            {
                DataRow paramRow1 = paramTable1.NewRow();
                paramRow1["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow1["WO_NO"] = focusRow["WO_NO"];
                paramRow1["PT_ID"] = focusRow["PT_ID"];
                paramRow1["INS_QTY"] = focusRow["INS_QTY"];
                paramRow1["REG_EMP"] = acInfo.UserID;
                paramRow1["INS_WORK"] = getInsWork(focusRow);

                paramTable1.Rows.Add(paramRow1);
            }
            else
            {
                DataView chainView = acGridView1.GetDataSourceView("CHAIN_WO_NO = '" + focusRow["CHAIN_WO_NO"].ToString() + "'");

                for (int i = 0; i < chainView.Count; i++)
                {
                    if (chainView[i]["INS_QTY"].toInt() == 0)
                    {
                        acAlert.Show(this, "검사수량이 0인 품목이 존재합니다.", acAlertForm.enmType.Info);
                        return;
                    }

                    DataRow paramRow = paramTable1.NewRow();
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["WO_NO"] = chainView[i]["WO_NO"];
                    paramRow["PT_ID"] = chainView[i]["PT_ID"];
                    paramRow["INS_QTY"] = chainView[i]["INS_QTY"];
                    paramRow["REG_EMP"] = acInfo.UserID;
                    paramRow["INS_WORK"] = getInsWork(chainView[i].Row);

                    paramTable1.Rows.Add(paramRow);
                }
            }

            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable1);

            BizRun.QBizRun.ExecuteService(
            this, QBiz.emExecuteType.SAVE,
            "POP05A_SAVE", paramSet, "RQSTDT", "RSLTDT",
            QuickSave,
            QuickException);
        }

        private void ButtonEdit_Ins_Add_Click(object sender, EventArgs e)
        {
            acGridView1.EndEditor();

            DataRow focusRow = acGridView1.GetFocusedDataRow();

            if (focusRow == null || focusRow["INS_QTY"].toInt() == 0)
                return;

            DataTable paramTable1 = new DataTable("RQSTDT");
            paramTable1.Columns.Add("PLT_CODE", typeof(String));
            //paramTable1.Columns.Add("ACTUAL_ID", typeof(String));
            paramTable1.Columns.Add("WO_NO", typeof(String));
            paramTable1.Columns.Add("PT_ID", typeof(String));
            paramTable1.Columns.Add("INS_QTY", typeof(Int32));
            paramTable1.Columns.Add("REG_EMP", typeof(String));
            paramTable1.Columns.Add("INS_WORK", typeof(String));

            DataRow paramRow1 = paramTable1.NewRow();
            paramRow1["PLT_CODE"] = acInfo.PLT_CODE;
            //paramRow1["ACTUAL_ID"] = focusRow["ACTUAL_ID"];
            paramRow1["WO_NO"] = focusRow["WO_NO"];
            paramRow1["PT_ID"] = focusRow["PT_ID"];
            paramRow1["INS_QTY"] = focusRow["INS_QTY"];
            paramRow1["REG_EMP"] = acInfo.UserID;
            //paramRow1["INS_WORK"] = focusRow["INS_WORK"];
            paramRow1["INS_WORK"] = getInsWork(focusRow);

            paramTable1.Rows.Add(paramRow1);

            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable1);

            BizRun.QBizRun.ExecuteService(
            this, QBiz.emExecuteType.SAVE,
            "POP05A_SAVE", paramSet, "RQSTDT", "RSLTDT",
            QuickSave,
            QuickException);
        }

        private void ButtonEdit_Ins_Del_Click(object sender, EventArgs e)
        {
            acGridView1.EndEditor();

            DataRow focusRow = acGridView1.GetFocusedDataRow();

            if (focusRow == null || focusRow["INS_QTY"].toInt() == 0)
                return;

            DataTable paramTable1 = new DataTable("RQSTDT");
            paramTable1.Columns.Add("PLT_CODE", typeof(String)); //
            //paramTable1.Columns.Add("ACTUAL_ID", typeof(String)); //
            paramTable1.Columns.Add("WO_NO", typeof(String)); //
            paramTable1.Columns.Add("PT_ID", typeof(String)); //
            paramTable1.Columns.Add("INS_QTY", typeof(Int32)); //            
            paramTable1.Columns.Add("REG_EMP", typeof(String)); //
            paramTable1.Columns.Add("INS_WORK", typeof(String));

            DataRow paramRow1 = paramTable1.NewRow();
            paramRow1["PLT_CODE"] = acInfo.PLT_CODE;
            //paramRow1["ACTUAL_ID"] = focusRow["ACTUAL_ID"];
            paramRow1["WO_NO"] = focusRow["WO_NO"];
            paramRow1["PT_ID"] = focusRow["PT_ID"];
            paramRow1["INS_QTY"] = focusRow["INS_QTY"].toInt() * -1;
            paramRow1["REG_EMP"] = acInfo.UserID;
            //paramRow1["INS_WORK"] = focusRow["INS_WORK"];
            paramRow1["INS_WORK"] = getInsWork(focusRow);

            paramTable1.Rows.Add(paramRow1);

            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable1);

            BizRun.QBizRun.ExecuteService(
            this, QBiz.emExecuteType.SAVE,
            "POP05A_SAVE", paramSet, "RQSTDT", "RSLTDT",
            QuickSave,
            QuickException);
        }

        //void QuickSave(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        //{
        //    try
        //    {
        //        foreach (DataRow row in e.result.Tables["RSLTDT"].Rows)
        //        {
        //            this.acGridView1.UpdateMapingRow(row, true);
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        acMessageBox.Show(this, ex);
        //    }

        //}

        private void acGridView1_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            DataRow row = acGridView1.GetFocusedDataRow();

            if (row == null)
                return;


            try
            {
                if (!base.ChildFormContains("NEW"))
                {

                    POP03A_D0A frm = new POP03A_D0A(acGridView1, row, acCheckEdit1.Checked);

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
                if (!base.ChildFormContains("NEW"))
                {

                    POP03A_D0A frm = new POP03A_D0A(acGridView1, row,acCheckEdit1.Checked);

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


        void SetBtnEnable(bool value)
        {
            //btnExcelImport.Enabled = value;
            //btnSave.Enabled = value;
            //btnAdd.Enabled = value;
            //btnDelete.Enabled = value;
        }

        private void AcGridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            try
            {
                if (sender is acGridView view)
                {
                    if (e.RowHandle < 0) return;

                    if (e.Column.FieldName == "INS_QTY"
                        || e.Column.FieldName == "SEL"
                        || e.Column.FieldName.StartsWith("INS_WORK")) return;

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
                acBarButtonItem5.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
            else if (e.MenuType == GridMenuType.Row)
            {
                if (e.HitInfo.RowHandle >= 0)
                {
                    acBarButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    acBarButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    acBarButtonItem3.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

                    acBarButtonItem5.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                }
                else
                {
                    acBarButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    acBarButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    acBarButtonItem3.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
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

            if (view.ValidFocusRowHandle())
            {
                this._IsChanged = false;

                //SetBtnEnable(true);
            }
            else
            {                
                this._IsChanged = false;                
                //acGridView2.ClearRow();
                //SetBtnEnable(false);
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

            paramTable.Columns.Add("S_INS_DATE", typeof(String)); //최종완료일 시작일
            paramTable.Columns.Add("E_INS_DATE", typeof(String)); //최종완료일 종료일

            //paramTable.Columns.Add("S_DELIVERY_DATE", typeof(String)); //납품 시작일
            //paramTable.Columns.Add("E_DELIVERY_DATE", typeof(String)); //납품 종료일
            paramTable.Columns.Add("IS_END", typeof(String)); //납기일 종료일
            paramTable.Columns.Add("PROC_CODE_IN", typeof(String));

            DataRow layoutRow = acLayoutControl1.CreateParameterRow();

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["PROD_LIKE"] = layoutRow["PROD_LIKE"];
            paramRow["CVND_LIKE"] = layoutRow["CVND_LIKE"];
            paramRow["IS_END"] = acCheckEdit1.Checked ? "" : "1";

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

                    case "INS_DATE":
                        //최종완료일
                        paramRow["S_INS_DATE"] = layoutRow["S_DATE"];
                        paramRow["E_INS_DATE"] = layoutRow["E_DATE"];

                        break;

                        //case "DELIVERY_DATE":
                        //    //납품일
                        //    paramRow["S_DELIVERY_DATE"] = layoutRow["S_DATE"];
                        //    paramRow["E_DELIVERY_DATE"] = layoutRow["E_DATE"];

                        //    break;
                }
            }

            foreach (string key in acCheckedComboBoxEdit2.GetKeyChecked())
            {
                paramRow["PROC_CODE_IN"] += "," + key + "";
            }

            if (paramRow["PROC_CODE_IN"].ToString().Length > 0)
            {
                paramRow["PROC_CODE_IN"] = paramRow["PROC_CODE_IN"].ToString().Substring(1, paramRow["PROC_CODE_IN"].ToString().Length - 1);
            }

            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            DataTable conTable = new DataTable("RQSTDT_CON");
            conTable.Columns.Add("PLT_CODE", typeof(string));
            conTable.Columns.Add("MENU_CODE", typeof(string));
            conTable.Columns.Add("CONTROL_NAME", typeof(string));
            conTable.Columns.Add("CONDITION", typeof(string));

            DataRow conRow = conTable.NewRow();
            conRow["PLT_CODE"] = acInfo.PLT_CODE;
            conRow["MENU_CODE"] = base.Name;
            conRow["CONTROL_NAME"] = this.acCheckedComboBoxEdit2.Name;
            conRow["CONDITION"] = paramRow["PROC_CODE_IN"];
            conTable.Rows.Add(conRow);

            paramSet.Tables.Add(conTable);

            BizRun.QBizRun.ExecuteService(
             this, QBiz.emExecuteType.LOAD,
             "POP05A_SER", paramSet, "RQSTDT", "RSLTDT",
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
                base.SetData("WORKORDER", e.result);


                DataTable workTable = acInfo.StdCodes.GetCatTable("Q008");

                foreach (DataRow row in workTable.Rows)
                {
                    if (!e.result.Tables["RSLTDT"].Columns.Contains("INS_WORK_" + row["CD_CODE"].ToString()))
                    {
                        e.result.Tables["RSLTDT"].Columns.Add("INS_WORK_" + row["CD_CODE"].ToString(), typeof(string));
                    }
                }

                foreach (DataRow row in e.result.Tables["RSLTDT"].Rows)
                {
                    //진행현황 상태 미미지
                    if (row["INS_WORK"].ToString().Length >= 2)
                    {
                        string state = row["INS_WORK"].ToString().Substring(row["INS_WORK"].ToString().Length - 2, 2);

                        switch(state)
                        {
                            case "10":

                                row["INS_WORK_STATE"] = ChangeIconColor(Resource.circle_2x, Color.DarkKhaki);

                                break;

                            case "20":

                                row["INS_WORK_STATE"] = ChangeIconColor(Resource.circle_2x, Color.LawnGreen);

                                break;

                            case "30":

                                row["INS_WORK_STATE"] = ChangeIconColor(Resource.circle_2x, Color.PowderBlue);

                                break;

                            case "40":

                                row["INS_WORK_STATE"] = ChangeIconColor(Resource.circle_2x, Color.DarkCyan);

                                break;

                            default:
                                row["INS_WORK_STATE"] = Resource.circle_2x;
                                break;
                        }
                    }
                    else
                    {
                        row["INS_WORK_STATE"] = Resource.circle_2x;
                    }

                    string[] works = row["INS_WORK"].ToString().Split(',');

                    foreach (string work in works)
                    {
                        string wk = work.Trim();

                        if (wk == "") continue;

                        if (!e.result.Tables["RSLTDT"].Columns.Contains("INS_WORK_" + wk)) continue;

                        row["INS_WORK_" + wk] = "1";
                    }
                    

                    if (row["CHAIN_WO_NO"].ToString() == "") continue;

                    Set_Color(row["CHAIN_WO_NO"].ToString());
                }


                acGridView1.GridControl.DataSource = e.result.Tables["RSLTDT"];
                
                _dwgFileDT = CodeHelperManager.acOpenDrawFile.GetFileExists();

                //acGridView1.Columns["INS_WORK"].BestFit();

                //acGridView1.SetOldFocusRowHandle(true);

                base.SetLog(e.executeType, e.result.Tables["RSLTDT"].Rows.Count, e.executeTime);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        Bitmap ChangeIconColor(Image img, Color iconColor)
        {
            if (img == null)
                return null;
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

                    if (p.R == 0 && p.G == 0 && p.B == 0)
                        bmp.SetPixel(x, y, Color.FromArgb(a, iconColor));
                }
            }
            return bmp;
        }


        void QuickSave(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                DataTable workTable = acInfo.StdCodes.GetCatTable("Q008");

                foreach (DataRow row in workTable.Rows)
                {
                    if (!e.result.Tables["RSLTDT"].Columns.Contains("INS_WORK_" + row["CD_CODE"].ToString()))
                    {
                        e.result.Tables["RSLTDT"].Columns.Add("INS_WORK_" + row["CD_CODE"].ToString(), typeof(string));
                    }
                }

                foreach (DataRow row in e.result.Tables["RSLTDT"].Rows)
                {
                    //진행현황 상태 미미지
                    if (row["INS_WORK"].ToString().Length >= 2)
                    {
                        string state = row["INS_WORK"].ToString().Substring(row["INS_WORK"].ToString().Length - 2, 2);

                        switch (state)
                        {
                            case "10":

                                row["INS_WORK_STATE"] = ChangeIconColor(Resource.circle_2x, Color.DarkKhaki);

                                break;

                            case "20":

                                row["INS_WORK_STATE"] = ChangeIconColor(Resource.circle_2x, Color.LawnGreen);

                                break;

                            case "30":

                                row["INS_WORK_STATE"] = ChangeIconColor(Resource.circle_2x, Color.PowderBlue);

                                break;

                            case "40":

                                row["INS_WORK_STATE"] = ChangeIconColor(Resource.circle_2x, Color.DarkCyan);

                                break;

                            default:
                                row["INS_WORK_STATE"] = Resource.circle_2x;
                                break;
                        }
                    }
                    else
                    {
                        row["INS_WORK_STATE"] = Resource.circle_2x;
                    }

                    string[] works = row["INS_WORK"].ToString().Split(',');

                    foreach (string work in works)
                    {
                        string wk = work.Trim();

                        if (wk == "") continue;

                        if (!e.result.Tables["RSLTDT"].Columns.Contains("INS_WORK_" + wk)) continue;

                        row["INS_WORK_" + wk] = "1";
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
                DataRow focusRow = acGridView1.GetFocusedDataRow();

                //if (focusRow != null)
                //{
                //    POP05A_D1A frm = new POP05A_D1A(focusRow);
                //    frm.ParentControl = this;
                //    frm.DialogMode = BaseMenuDialog.emDialogMode.NEW;
                //    base.ChildFormAdd("NEW_ITEM", frm);
                //    frm.Show(this);
                //}

                DataTable workTable = acInfo.StdCodes.GetCatTable("Q008");

                foreach (DataRow row in workTable.Rows)
                {
                    if (!e.result.Tables["RSLTDT"].Columns.Contains("INS_WORK_" + row["CD_CODE"].ToString()))
                    {
                        e.result.Tables["RSLTDT"].Columns.Add("INS_WORK_" + row["CD_CODE"].ToString(), typeof(string));
                    }
                }


                if (acCheckEdit1.Checked)
                {
                    foreach (DataRow row in e.result.Tables["RSLTDT"].Rows)
                    {
                        //진행현황 상태 미미지
                        if (row["INS_WORK"].ToString().Length >= 2)
                        {
                            string state = row["INS_WORK"].ToString().Substring(row["INS_WORK"].ToString().Length - 2, 2);

                            switch (state)
                            {
                                case "10":

                                    row["INS_WORK_STATE"] = ChangeIconColor(Resource.circle_2x, Color.DarkKhaki);

                                    break;

                                case "20":

                                    row["INS_WORK_STATE"] = ChangeIconColor(Resource.circle_2x, Color.LawnGreen);

                                    break;

                                case "30":

                                    row["INS_WORK_STATE"] = ChangeIconColor(Resource.circle_2x, Color.PowderBlue);

                                    break;

                                case "40":

                                    row["INS_WORK_STATE"] = ChangeIconColor(Resource.circle_2x, Color.DarkCyan);

                                    break;

                                default:
                                    row["INS_WORK_STATE"] = Resource.circle_2x;
                                    break;
                            }
                        }
                        else
                        {
                            row["INS_WORK_STATE"] = Resource.circle_2x;
                        }

                        string[] works = row["INS_WORK"].ToString().Split(',');

                        foreach (string work in works)
                        {
                            string wk = work.Trim();

                            if (wk == "") continue;

                            if (!e.result.Tables["RSLTDT"].Columns.Contains("INS_WORK_" + wk)) continue;

                            row["INS_WORK_" + wk] = "1";
                        }

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


                acAlert.Show(this, "완료 되었습니다.", acAlertForm.enmType.Success);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void btnLastEnd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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
                paramTable.Columns.Add("PT_ID", typeof(String)); //                
                paramTable.Columns.Add("WO_NO", typeof(String)); //                
                paramTable.Columns.Add("REG_EMP", typeof(String)); //
                paramTable.Columns.Add("IS_SHIP", typeof(String)); //
                paramTable.Columns.Add("INS_WORK", typeof(String)); //
                paramTable.Columns.Add("CHAIN_WO_NO", typeof(String)); //

                //DataRow[] rows = acGridView1.GetSelectedDataRows();

                //if (rows.Length == 0)
                //    rows = new DataRow[] { acGridView1.GetFocusedDataRow() };

                DataRow focusRow = acGridView1.GetFocusedDataRow();

                DataView selectedView = acGridView1.GetDataSourceView("SEL = '1'");

                Dictionary<string, string> cDic = new Dictionary<string, string>();

                if (selectedView.Count > 0)
                {
                    for (int i = 0; i < selectedView.Count; i++)
                    {
                        //if (selectedView[i]["CHAIN_WO_NO"].ToString() != "")
                        //{
                        //    if (cDic.ContainsKey(selectedView[i]["CHAIN_WO_NO"].ToString())) continue;

                        //    if (selectedView[i]["PART_QTY"].toInt() - selectedView[i]["OLD_INS_QTY"].toInt() > 0)
                        //    {
                        //        if (!cDic.ContainsKey(selectedView[i]["CHAIN_WO_NO"].ToString()))
                        //        {
                        //            cDic.Add(selectedView[i]["CHAIN_WO_NO"].ToString(), "1");
                        //        }

                        //        continue;
                        //    }
                        //}
                        //else
                        //{
                        //    if (selectedView[i]["PART_QTY"].toInt() - selectedView[i]["OLD_INS_QTY"].toInt() > 0) continue;
                        //}

                        if (selectedView[i]["PART_QTY"].toInt() - selectedView[i]["OLD_INS_QTY"].toInt() > 0)
                        {
                            acAlert.Show(this, "미검사 수량이 존재합니다.", acAlertForm.enmType.Info);
                            return;
                        }

                        DataRow paramRow = paramTable.NewRow();
                        paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                        paramRow["PT_ID"] = selectedView[i]["PT_ID"];
                        paramRow["WO_NO"] = selectedView[i]["WO_NO"];
                        paramRow["REG_EMP"] = acInfo.UserID;
                        //paramRow["INS_WORK"] = selectedView[i]["INS_WORK"];
                        paramRow["INS_WORK"] = getInsWork(selectedView[i].Row);
                        paramRow["CHAIN_WO_NO"] = selectedView[i]["CHAIN_WO_NO"];
                        paramTable.Rows.Add(paramRow);

                        ////if (selectedView[i]["CHAIN_WO_NO"].ToString() != "") continue;
                        //if (cDic.ContainsKey(selectedView[i]["CHAIN_WO_NO"].ToString())) continue;

                        //DataView addView = acGridView1.GetDataView("CHAIN_WO_NO = '" + selectedView[i]["CHAIN_WO_NO"].ToString() + "' AND ISNULL(SEL,'0') = '0'");

                        //for (int j = 0; j < addView.Count; j++)
                        //{
                        //    if (addView[i]["PART_QTY"].toInt() - addView[i]["OLD_INS_QTY"].toInt() > 0)
                        //    {
                        //        if (!cDic.ContainsKey(addView[i]["CHAIN_WO_NO"].ToString()))
                        //        {
                        //            cDic.Add(addView[i]["CHAIN_WO_NO"].ToString(), "1");
                        //        }
                        //    }

                        //    if (cDic.ContainsKey(addView[i]["CHAIN_WO_NO"].ToString()))
                        //    {
                        //        DataRow[] removeRows = paramTable.Select("CHAIN_WO_NO = '" + addView[i]["CHAIN_WO_NO"].ToString() + "'");

                        //        foreach (DataRow rRow in removeRows)
                        //        {
                        //            paramTable.Rows.Remove(rRow);
                        //        }

                        //        break;
                        //    }

                        //    //if (addView[i]["PART_QTY"].toInt() - addView[i]["OLD_INS_QTY"].toInt() > 0)
                        //    //{

                        //    //}

                        //    DataRow addparamRow = paramTable.NewRow();
                        //    addparamRow["PLT_CODE"] = acInfo.PLT_CODE;
                        //    addparamRow["PT_ID"] = addView[j]["PT_ID"];
                        //    addparamRow["WO_NO"] = addView[j]["WO_NO"];
                        //    addparamRow["REG_EMP"] = acInfo.UserID;
                        //    //addparamRow["INS_WORK"] = addView[j]["INS_WORK"];
                        //    addparamRow["INS_WORK"] = getInsWork(addView[i].Row);
                        //    addparamRow["CHAIN_WO_NO"] = addView[j]["CHAIN_WO_NO"];
                        //    paramTable.Rows.Add(addparamRow);
                        //}

                    }
                }
                else
                {
                    if (focusRow["CHAIN_WO_NO"].ToString() == "")
                    {
                        if (focusRow["PART_QTY"].toInt() - focusRow["OLD_INS_QTY"].toInt() > 0)
                        {
                            acAlert.Show(this, "미검사 수량이 존재합니다.", acAlertForm.enmType.Info);
                            return;
                        }

                        DataRow paramRow = paramTable.NewRow();
                        paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                        paramRow["PT_ID"] = focusRow["PT_ID"];
                        paramRow["WO_NO"] = focusRow["WO_NO"];
                        paramRow["REG_EMP"] = acInfo.UserID;
                        //paramRow["INS_WORK"] = focusRow["INS_WORK"];
                        paramRow["INS_WORK"] = getInsWork(focusRow);
                        paramRow["CHAIN_WO_NO"] = focusRow["CHAIN_WO_NO"];
                        paramTable.Rows.Add(paramRow);
                    }
                    else
                    {
                        DataView chainView = acGridView1.GetDataSourceView("CHAIN_WO_NO = '" + focusRow["CHAIN_WO_NO"].ToString() +"'");

                        for (int i = 0; i < chainView.Count; i++)
                        {
                            if (chainView[i]["PART_QTY"].toInt() - chainView[i]["OLD_INS_QTY"].toInt() > 0)
                            {
                                acAlert.Show(this, "미검사 수량이 존재합니다.", acAlertForm.enmType.Info);
                                return;
                            }

                            DataRow paramRow = paramTable.NewRow();
                            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                            paramRow["PT_ID"] = chainView[i]["PT_ID"];
                            paramRow["WO_NO"] = chainView[i]["WO_NO"];
                            paramRow["REG_EMP"] = acInfo.UserID;
                            //paramRow["INS_WORK"] = chainView[i]["INS_WORK"];
                            paramRow["INS_WORK"] = getInsWork(chainView[i].Row);
                            paramRow["CHAIN_WO_NO"] = chainView[i]["CHAIN_WO_NO"];
                            paramTable.Rows.Add(paramRow);
                        }
                    }
                }

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.PROCESS, "POP05A_UPD", paramSet, "RQSTDT", "RSLTDT",
                QuickUPD,
                QuickException);

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void btnNg_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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

            this.OnLoad(null);

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

            this.OnLoad(null);

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
            //검사현황 저장
            acGridView1.EndEditor();

            DataTable modifyTable = acGridView1.GetAddModifyRows();

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(string));
            paramTable.Columns.Add("WO_NO", typeof(string));
            paramTable.Columns.Add("INS_WORK", typeof(string));

            foreach (DataRow row in modifyTable.Rows)
            {
                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["WO_NO"] = row["WO_NO"];
                //paramRow["INS_WORK"] = row["INS_WORK"];
                paramRow["INS_WORK"] = getInsWork(row);
                //string test = getInsWork(row);

                paramTable.Rows.Add(paramRow);
            }

            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            BizRun.QBizRun.ExecuteService(
            this, QBiz.emExecuteType.SAVE,
            "POP05A_UPD3", paramSet, "RQSTDT", "RSLTDT",
            QuickSave,
            QuickException);
        }

        string getInsWork(DataRow row)
        {
            string insWork = "";
            foreach (DataColumn col in row.Table.Columns)
            {
                if(col.ColumnName.StartsWith("INS_WORK_"))
                {
                    if (row[col.ColumnName].ToString() == "1")
                    {
                        insWork = insWork + ", " + col.ColumnName.Replace("INS_WORK_", "");
                    }
                }
            }

            if (insWork.Length > 1)
            {
                insWork = insWork.Substring(2, insWork.Length - 2);
            }

            return insWork;
        }

        private void acBarButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //부적합등록
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
    }
}
