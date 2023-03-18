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
using DevExpress.XtraTreeList.Nodes;
using System.IO;
using DevExpress.XtraEditors.Controls;

namespace POP
{
    public sealed partial class POP06A_M0A : BaseMenu
    {

        private GridHitInfo _downHitInfo = null;

        public POP06A_M0A()
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


        private Dictionary<string, string> _dicProcStat = null;
        private DataTable _dtProcList = null;
        //private Hashtable _htWoList = null;
        //private Hashtable _htWoFig = null;

        private Color _WAIT;
        private Color _RUN;
        private Color _PAUSE;
        private Color _FINISH;

        public override void MenuInit()
        {

            acGridView1.GridType = acGridView.emGridType.SEARCH;

            //acGridView1.AddLookUpEdit("PROD_STATE", "상태", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P012");
            acGridView1.AddLookUpEdit("WO_FLAG", "상태", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "S032");
            acGridView1.AddLookUpEdit("PROD_PRIORITY", "우선순위", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P028");
            acGridView1.AddTextEdit("PROD_CODE", "수주번호", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddLookUpEdit("PROD_FLAG", "수주유형", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P006");
            acGridView1.AddTextEdit("PROD_NAME", "모델명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("PROD_VERSION", "버전", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddLookUpEdit("PROD_KIND", "제품구분", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "C011");
            //acGridView1.AddCheckedComboBoxEdit("PROD_CATEGORY", "제품유형", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, "P009");

            acGridView1.AddLookUpEmp("BUSINESS_EMP", "영업담당자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false);
            acGridView1.AddTextEdit("CUSTOMER_EMP", "고객담당자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("CUSTDESIGN_EMP", "고객설계자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("CVND_CODE", "발주처코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("CVND_NAME", "발주처", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddDateEdit("ORD_DATE", "수주일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
            acGridView1.AddDateEdit("DUE_DATE", "출하예정일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
            acGridView1.AddDateEdit("CHG_DUE_DATE", "출하조정일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
            //acGridView1.AddDateEdit("DELIVERY_DATE", "납품일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);

            acGridView1.AddTextEdit("PART_CODE", "부품코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("PART_NAME", "부품명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("MAT_SPEC", "규격", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("PROC_NAME", "작업명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("DRAW_EMP", "개발자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            //acGridView1.AddCheckedComboBoxEdit("PROBE_PIN", "Probe Pin", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, "P011");
            acGridView1.AddLookUpEdit("PIN_TYPE", "Contact", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P011");
            acGridView1.AddLookUpEdit("PROD_TYPE", "제품분류", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P010");
            acGridView1.AddTextEdit("PROD_QTY", "수주수량", "CPW0FS8W", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NUMERIC);
            acGridView1.AddTextEdit("INS_QTY", "이전 공정완료수량", "CPW0FS8W", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NUMERIC);

            acGridView1.AddTextEdit("CAM_SCOMMENT", "CAM 비고", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("SCOMMENT", "생산계획 비고", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
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


            acGridView1.AddTextEdit("ASSY_RATE", "전체진행율(%)", "", false, DevExpress.Utils.HorzAlignment.Far, true, true, false, acGridView.emTextEditMask.PER2);
            acGridView1.AddButtonEdit("ASSY_RATE_BTN", "저장", "", false, DevExpress.Utils.HorzAlignment.Far, DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor, true, true, false,DevExpress.LookAndFeel.SkinStyle.TheAsphaltWorld);

            RepositoryItemButtonEdit buttonEdit = acGridView1.Columns["ASSY_RATE_BTN"].RealColumnEdit as RepositoryItemButtonEdit;

            buttonEdit.Buttons.Clear();
            buttonEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "저장", 30, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), "", "FIND")});
            buttonEdit.Buttons[0].Click += AssyRate_Click;


            acGridView1.AddTextEdit("ASSY_EMPS", "조립작업자", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            //acGridView1.AddButtonEdit("ASSY_EMPS_BTN", "조립작업자 추가", "", false, DevExpress.Utils.HorzAlignment.Far, DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor, true, true, false, DevExpress.LookAndFeel.SkinStyle.TheAsphaltWorld);
            //RepositoryItemButtonEdit buttonEdit2 = acGridView1.Columns["ASSY_EMPS_BTN"].RealColumnEdit as RepositoryItemButtonEdit;
            //buttonEdit2.Buttons.Clear();
            //buttonEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            //new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "추가", 30, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), "", "FIND")});
            //buttonEdit2.Buttons[0].Click += AssyEmp_Click;

            acGridView1.AddTextEdit("PIN_EMPS", "핀작업자", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            //acGridView1.AddButtonEdit("PIN_EMPS_BTN", "핀작업자 추가", "", false, DevExpress.Utils.HorzAlignment.Far, DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor, true, true, false, DevExpress.LookAndFeel.SkinStyle.TheAsphaltWorld);
            //RepositoryItemButtonEdit buttonEdit3 = acGridView1.Columns["PIN_EMPS_BTN"].RealColumnEdit as RepositoryItemButtonEdit;
            //buttonEdit3.Buttons.Clear();
            //buttonEdit3.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            //new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "추가", 30, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), "", "FIND")});
            //buttonEdit3.Buttons[0].Click += PinEmp_Click;


            acGridView1.AddTextEdit("ASSY_SCOMMENT", "비고", "", false, DevExpress.Utils.HorzAlignment.Near, true, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("INS_SCOMMENT", "출하검사 비고", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);


            acGridView1.Columns["ASSY_RATE_BTN"].Fixed = FixedStyle.Right;
            acGridView1.Columns["ASSY_RATE"].Fixed = FixedStyle.Right;


            acGridView1.AddHidden("WO_NO", typeof(string));

            acGridView1.KeyColumn = new string[] { "WO_NO" };


            acGridView1.OptionsView.ShowIndicator = true;

            #region 상세 진행 내역
            acGridView2.GridType = acGridView.emGridType.SEARCH;

            //            acGridView2.AddCheckEdit("SEL", "선택", "40290", true, true, true, acGridView.emCheckEditDataType._STRING);            
            acGridView2.AddTextEdit("PART_CODE", "품목코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("PART_NAME", "품목명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("PART_SPEC", "규격", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("DRAW_NO", "도면번호", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

            RepositoryItemButtonEdit riButtonEdit4 = new RepositoryItemButtonEdit();
            EditorButton button4 = new EditorButton(ButtonPredefines.Glyph, string.Empty, -1, true, true, false, ImageLocation.MiddleCenter, null);
            riButtonEdit4.LookAndFeel.SetSkinStyle(DevExpress.LookAndFeel.SkinStyle.TheAsphaltWorld);

            button4.Caption = "DWG";
            button4.ToolTip = "DWG";

            riButtonEdit4.Buttons.Clear();
            riButtonEdit4.Buttons.Add(button4);
            riButtonEdit4.TextEditStyle = TextEditStyles.HideTextEditor;
            riButtonEdit4.ButtonClick += DWG2_ButtonClick;

            acGridView2.AddCustomEdit("DWG_OPEN", "DWG", "", false, DevExpress.Utils.HorzAlignment.Center, true, true, false, riButtonEdit4);

            RepositoryItemButtonEdit riButtonEdit5 = new RepositoryItemButtonEdit();
            EditorButton button5 = new EditorButton(ButtonPredefines.Glyph, string.Empty, -1, true, true, false, ImageLocation.MiddleCenter, null);
            riButtonEdit5.LookAndFeel.SetSkinStyle(DevExpress.LookAndFeel.SkinStyle.TheAsphaltWorld);

            button5.Caption = "PDF";
            button5.ToolTip = "PDF";

            riButtonEdit5.Buttons.Clear();
            riButtonEdit5.Buttons.Add(button5);
            riButtonEdit5.TextEditStyle = TextEditStyles.HideTextEditor;
            riButtonEdit5.ButtonClick += PDF2_ButtonClick;

            acGridView2.AddCustomEdit("PDF_OPEN", "PDF", "", false, DevExpress.Utils.HorzAlignment.Center, true, true, false, riButtonEdit5);

            RepositoryItemButtonEdit riButtonEdit6 = new RepositoryItemButtonEdit();
            EditorButton button6 = new EditorButton(ButtonPredefines.Glyph, string.Empty, -1, true, true, false, ImageLocation.MiddleCenter, null);
            riButtonEdit6.LookAndFeel.SetSkinStyle(DevExpress.LookAndFeel.SkinStyle.TheAsphaltWorld);

            button6.Caption = "JT";
            button6.ToolTip = "JT";

            riButtonEdit6.Buttons.Clear();
            riButtonEdit6.Buttons.Add(button6);
            riButtonEdit6.TextEditStyle = TextEditStyles.HideTextEditor;
            riButtonEdit6.ButtonClick += JT2_ButtonClick;

            acGridView2.AddCustomEdit("JT_OPEN", "JT", "", false, DevExpress.Utils.HorzAlignment.Center, true, true, false, riButtonEdit6);

            acGridView2.AddTextEdit("PRC_PART_QTY", "수량", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NUMERIC);
            acGridView2.AddLookUpEdit("MAT_UNIT", "단위", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M003");
            acGridView2.AddLookUpEdit("IS_REWORK", "재작업여부", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "W012");

            //공정 컬럼 생성
            if (acLayoutControl1.ValidCheck() == false)
            {
                return;
            }

            DataRow layoutRow = acLayoutControl1.CreateParameterRow();


            //this._dtProcList = ExtensionMethods.GetProcList(this);

            DataTable procParamTable = new DataTable("RQSTDT");
            procParamTable.Columns.Add("PLT_CODE", typeof(String)); //
            procParamTable.Columns.Add("IS_DISP", typeof(Byte)); //
            procParamTable.Columns.Add("IS_DISP2", typeof(Byte)); //

            DataRow procParamRow = procParamTable.NewRow();
            procParamRow["PLT_CODE"] = acInfo.PLT_CODE;
            procParamRow["IS_DISP"] = 0;
            procParamRow["IS_DISP2"] = 0;

            procParamTable.Rows.Add(procParamRow);
            DataSet procParamSet = new DataSet();
            procParamSet.Tables.Add(procParamTable);

            DataTable dtProc = BizRun.QBizRun.ExecuteService(this, "COMMON", "COMMON_PROC", procParamSet, "RQSTDT", "RSLTDT").Tables["RSLTDT"];

            this._dtProcList = dtProc;

            foreach (DataRow row in this._dtProcList.Rows)
            {

                acGridView2.AddMemoEdit(row["PROC_CODE"].ToString(), row["PROC_NAME"].ToString(), "", false, DevExpress.Utils.HorzAlignment.Center, DevExpress.Utils.VertAlignment.Center, false, true, true, false);
                acGridView2.Columns[row["PROC_CODE"].ToString()].Tag = "PROC";
            }

            acGridView2.AddTextEdit("PART_SCOMMENT", "비고", "ARYZ726K", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView2.KeyColumn = new string[] { "PART_CODE" };
            #endregion


            #region BOM
            acTreeList1.AddTextEdit("PART_CODE", "품목코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, acTreeList.emTextEditMask.NONE);
            acTreeList1.AddTextEdit("PART_NAME", "품목명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, acTreeList.emTextEditMask.NONE);
            acTreeList1.AddLookUpEdit("PART_LTYPE", "대분류", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, "M014", false);
            //acTreeList1.AddTextEdit("PART_LTYPE", "대분류", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, acTreeList.emTextEditMask.NONE);
            acTreeList1.AddTextEdit("P_PART_CODE", "모품목코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, acTreeList.emTextEditMask.NONE);
            acTreeList1.AddTextEdit("P_PART_NAME", "모품목명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, acTreeList.emTextEditMask.NONE);
            acTreeList1.AddTextEdit("PART_QTY", "수량", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, acTreeList.emTextEditMask.QTY);
            acTreeList1.AddTextEdit("DATA_FLAG", "삭제여부", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, acTreeList.emTextEditMask.NONE);

            acTreeList1.KeyFieldName = "PT_ID";
            acTreeList1.ParentFieldName = "O_PT_ID";

            acTreeList1.CustomDrawNodeCell += acTreeList1_CustomDrawNodeCell;

            #endregion



            acCheckedComboBoxEdit1.AddItem("등록일", false, "", "REG_DATE", true, false);
            acCheckedComboBoxEdit1.AddItem("수주일", false, "", "ORD_DATE", true, false);
            acCheckedComboBoxEdit1.AddItem("출하예정일", false, "", "DUE_DATE", true, false);
            //acCheckedComboBoxEdit1.AddItem("납품일", false, "", "DELIVERY_DATE", true, false);

            DataSet resultSet = BizRun.QBizRun.ExecuteService(this, "POP06A_SER2", acInfo.RefData, "RQSTDT", "RSLTDT");

            DataSet paramSet = acInfo.RefData.Clone();

            paramSet.Tables["RQSTDT"].Columns.Add("MENU_CODE", typeof(string));

            DataRow paramRow = paramSet.Tables["RQSTDT"].NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["MENU_CODE"] = base.Name;
            paramSet.Tables["RQSTDT"].Rows.Add(paramRow);

            DataSet conResultSet = BizRun.QBizRun.ExecuteService(this, "POP06A_SER3", paramSet, "RQSTDT", "RSLTDT");

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
                if (Conditions.Contains(row["PROC_CODE"].ToString()))
                {
                    acCheckedComboBoxEdit2.AddItem(row["PROC_NAME"].ToString(), false, "", row["PROC_CODE"].ToString(), true, false, CheckState.Checked);
                }
                else
                {
                    acCheckedComboBoxEdit2.AddItem(row["PROC_NAME"].ToString(), false, "", row["PROC_CODE"].ToString(), true, false);
                }
            }

            this.acLayoutControl1.OnValueKeyDown += new acLayoutControl.ValueKeyDownEventHandler(acLayoutControl1_OnValueKeyDown);
            this.acLayoutControl1.OnValueChanged += new acLayoutControl.ValueChangedEventHandler(acLayoutControl1_OnValueChanged);

            this.acGridView1.CustomDrawCell += AcGridView1_CustomDrawCell;
            this.acGridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(acGridView1_FocusedRowChanged);            
            this.acGridView1.ShowGridMenuEx += new acGridView.ShowGridMenuExHandler(acGridView1_ShowGridMenuEx);
            this.acGridView1.OnMapingRowChanged += new acGridView.MapingRowChangedEventHandler(acGridView1_OnMapingRowChanged);

            acGridView1.CustomRowCellEdit += acGridView1_CustomRowCellEdit;

            this.acGridView2.CustomDrawCell += acGridView2_CustomDrawCell;
            //this.acGridView2.RowCellStyle += acGridView2_RowCellStyle;

            acGridView2.CustomRowCellEdit += acGridView2_CustomRowCellEdit;


            _WAIT = acInfo.SysConfig.GetSysConfigByServer("MC_OPERATE_CLR_WAIT").toColor();
            _RUN = acInfo.SysConfig.GetSysConfigByServer("MC_OPERATE_CLR_RUN").toColor();
            _PAUSE = acInfo.SysConfig.GetSysConfigByServer("MC_OPERATE_CLR_PAUSE").toColor();
            _FINISH = acInfo.SysConfig.GetSysConfigByServer("MC_OPERATE_CLR_FINISH").toColor();

            txtWait.BackColor = acInfo.SysConfig.GetSysConfigByServer("MC_OPERATE_CLR_WAIT").toColor();
            txtRun.BackColor = acInfo.SysConfig.GetSysConfigByServer("MC_OPERATE_CLR_RUN").toColor();
            txtFinish.BackColor = acInfo.SysConfig.GetSysConfigByServer("MC_OPERATE_CLR_FINISH").toColor();

            _dicProcStat = new Dictionary<string, string>();

            //this.acGridView2.RowHeight = 60;

            base.MenuInit();
        }

        private void acGridView1_CustomRowCellEdit(object sender, CustomRowCellEditEventArgs e)
        {
            try
            {
                if (e.RowHandle < 0) return;
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


        private void acGridView2_CustomRowCellEdit(object sender, CustomRowCellEditEventArgs e)
        {
            try
            {
                if (e.RowHandle < 0) return;
                //string isDWG = acGridView2.GetRowCellValue(e.RowHandle, "IS_DWG").ToString();
                //string isPDF = acGridView2.GetRowCellValue(e.RowHandle, "IS_PDF").ToString();
                //string isJT = acGridView2.GetRowCellValue(e.RowHandle, "IS_JT").ToString();

                if (e.RowHandle < 0) return;

                string PART_CODE = acGridView2.GetRowCellValue(e.RowHandle, "PART_CODE").ToString();

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
                        riButtonEdit.ButtonClick += DWG2_ButtonClick;
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
                        riButtonEdit.ButtonClick += PDF2_ButtonClick;
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
                        riButtonEdit.ButtonClick += JT2_ButtonClick;
                        e.RepositoryItem = riButtonEdit;
                        (e.RepositoryItem as RepositoryItemButtonEdit).Buttons[0].Enabled = true;
                    }
                }
            }
            catch { }
        }

        private void DWG2_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                DataRow focusRow = acGridView2.GetFocusedDataRow();

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

        private void PDF2_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                DataRow focusRow = acGridView2.GetFocusedDataRow();

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

        private void JT2_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                DataRow focusRow = acGridView2.GetFocusedDataRow();

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

        private void acTreeList1_CustomDrawNodeCell(object sender, DevExpress.XtraTreeList.CustomDrawNodeCellEventArgs e)
        {

            TreeListNode node = e.Node;

            if (node["DATA_FLAG"].ToString() == "2")
            {
                e.Appearance.BackColor = Color.OrangeRed;
                e.Appearance.ForeColor = Color.White;
            }
        }


        void acGridView2_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            try
            {
                if (e.CellValue == null
                    || e.Column.Tag == null) return;

                e.Appearance.ForeColor = Color.Black;

                DataRow thisRow = acGridView2.GetDataRow(e.RowHandle);

                string key = thisRow["PT_ID"].ToString() + e.Column.FieldName + thisRow["RE_WO_NO"].ToString();

                if (!_dicProcStat.ContainsKey(key))
                    return;

                switch (_dicProcStat[key])
                {
                    case "0":
                    case "1":
                        e.Appearance.BackColor = _WAIT;
                        break;
                    case "2":
                    case "3":
                        e.Appearance.BackColor = _RUN;
                        break;

                    //e.Appearance.BackColor = _PAUSE;
                    //break;
                    case "4":
                        e.Appearance.BackColor = _FINISH;
                        break;
                        //case "03":
                        //    e.Appearance.BackColor = Color.LightGray;
                        //    break;
                        //case "11":
                        //    e.Appearance.BackColor = Color.CadetBlue;
                        //    break;
                }
            }
            catch
            {

            }
        }

        void acGridView2_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            if (e.RowHandle == acGridView2.FocusedRowHandle)
            {
                //if (e.CellValue.ToString() == "NEW")
                    //e.Appearance.BackColor = Color.White;
            }
        }

        void acGridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            acGridView view = sender as acGridView;

            if (view.ValidFocusRowHandle())
            {
                this.GetDatail();

            }
            else
            {
                acGridView2.ClearRow();
                acTreeList1.ClearNodes();
            }
        }


        private void AssyRate_Click(object sender, EventArgs e)
        {
            acGridView1.EndEditor();

            DataRow focusRow = acGridView1.GetFocusedDataRow();

            if (focusRow == null)
                return;

            DataTable paramTable1 = new DataTable("RQSTDT");
            paramTable1.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable1.Columns.Add("WO_NO", typeof(String)); //
            paramTable1.Columns.Add("ACTUAL_ID", typeof(String)); //
            paramTable1.Columns.Add("PT_ID", typeof(String)); //
            paramTable1.Columns.Add("ASSY_RATE", typeof(decimal)); //            
            paramTable1.Columns.Add("PART_QTY", typeof(int)); //            
            paramTable1.Columns.Add("REG_EMP", typeof(String)); //

            DataRow paramRow1 = paramTable1.NewRow();
            paramRow1["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow1["WO_NO"] = focusRow["WO_NO"];
            paramRow1["ACTUAL_ID"] = focusRow["ACTUAL_ID"];
            paramRow1["PT_ID"] = focusRow["PT_ID"];
            paramRow1["ASSY_RATE"] = focusRow["ASSY_RATE"];
            paramRow1["PART_QTY"] = focusRow["PART_QTY"];
            paramRow1["REG_EMP"] = acInfo.UserID;

            paramTable1.Rows.Add(paramRow1);

            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable1);

            BizRun.QBizRun.ExecuteService(
            this, QBiz.emExecuteType.SAVE,
            "POP06A_SAVE", paramSet, "RQSTDT", "RSLTDT",
            QuickSave,
            QuickException);
        }

        private void AssyEmp_Click(object sender, EventArgs e)
        {
            acGridView1.EndEditor();

            DataRow focusRow = acGridView1.GetFocusedDataRow();

            if (focusRow == null)
                return;

            POP06A_D0A frm = new POP06A_D0A(focusRow, acGridView1, "A");

            frm.DialogMode = BaseMenuDialog.emDialogMode.NEW;

            frm.ParentControl = this;

            frm.Show(this);
        }

        private void PinEmp_Click(object sender, EventArgs e)
        {
            acGridView1.EndEditor();

            DataRow focusRow = acGridView1.GetFocusedDataRow();

            if (focusRow == null)
                return;

            POP06A_D0A frm = new POP06A_D0A(focusRow, acGridView1, "P");

            frm.DialogMode = BaseMenuDialog.emDialogMode.NEW;

            frm.ParentControl = this;

            frm.Show(this);
        }

        private void ButtonEdit_Assy_Add_Click(object sender, EventArgs e)
        {
            acGridView1.EndEditor();

            DataRow focusRow = acGridView1.GetFocusedDataRow();

            if (focusRow == null || focusRow["ASSY_QTY"].toInt() == 0)
                return;

            DataTable paramTable1 = new DataTable("RQSTDT");
            paramTable1.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable1.Columns.Add("PROD_CODE", typeof(String)); //
            paramTable1.Columns.Add("ASSY_QTY", typeof(Int32)); //            
            paramTable1.Columns.Add("REG_EMP", typeof(String)); //

            DataRow paramRow1 = paramTable1.NewRow();
            paramRow1["PLT_CODE"] = acInfo.PLT_CODE;            
            paramRow1["PROD_CODE"] = focusRow["PROD_CODE"];
            paramRow1["ASSY_QTY"] = focusRow["ASSY_QTY"];            
            paramRow1["REG_EMP"] = acInfo.UserID;

            paramTable1.Rows.Add(paramRow1);

            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable1);

            BizRun.QBizRun.ExecuteService(
            this, QBiz.emExecuteType.SAVE,
            "POP06A_SAVE", paramSet, "RQSTDT", "RSLTDT",
            QuickSave,
            QuickException);
        }

        private void ButtonEdit_Assy_Del_Click(object sender, EventArgs e)
        {
            acGridView1.EndEditor();

            DataRow focusRow = acGridView1.GetFocusedDataRow();

            if (focusRow == null || focusRow["ASSY_QTY"].toInt() == 0)
                return;

            DataTable paramTable1 = new DataTable("RQSTDT");
            paramTable1.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable1.Columns.Add("WO_NO", typeof(String)); //
            paramTable1.Columns.Add("ACTUAL_ID", typeof(String)); //
            paramTable1.Columns.Add("PT_ID", typeof(String)); //
            paramTable1.Columns.Add("ASSY_QTY", typeof(Int32)); //            
            paramTable1.Columns.Add("REG_EMP", typeof(String)); //

            DataRow paramRow1 = paramTable1.NewRow();
            paramRow1["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow1["WO_NO"] = focusRow["WO_NO"];
            paramRow1["ACTUAL_ID"] = focusRow["ACTUAL_ID"];
            paramRow1["PT_ID"] = focusRow["PT_ID"];
            paramRow1["ASSY_QTY"] = focusRow["ASSY_QTY"].toInt() * -1;
            paramRow1["REG_EMP"] = acInfo.UserID;

            paramTable1.Rows.Add(paramRow1);

            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable1);

            BizRun.QBizRun.ExecuteService(
            this, QBiz.emExecuteType.SAVE,
            "POP06A_SAVE", paramSet, "RQSTDT", "RSLTDT",
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
                    DataRow row = view.GetDataRow(e.RowHandle);
                    if (row == null)
                        return;

                    if (row["PROD_STATE"].ToString() == "5")
                    {
                        e.Appearance.BackColor = Color.Orange;
                        e.Appearance.ForeColor = Color.Black;
                    }

                    if (row["PROD_KIND"].ToString() == "PE")
                    {
                        e.Appearance.ForeColor = Color.DarkViolet;
                    }

                    if (row["PROD_PRIORITY"].ToString() == "0")
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
                string formKey = string.Format("{0},{1}", "PROD_CODE", row["PROD_CODE"]);

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
                acBarButtonItem4.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
            else if (e.MenuType == GridMenuType.Row)
            {
                if (e.HitInfo.RowHandle >= 0)
                {
                    acBarButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    acBarButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    acBarButtonItem3.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    acBarButtonItem4.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                }
                else
                {
                    acBarButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    acBarButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    acBarButtonItem3.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    acBarButtonItem4.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                }

            }


            if (e.HitInfo.HitTest == GridHitTest.Row || e.HitInfo.HitTest == GridHitTest.RowCell)
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

        //        //SetBtnEnable(true);
        //    }
        //    else
        //    {                
        //        this._IsChanged = false;                
        //        //acGridView2.ClearRow();
        //        //SetBtnEnable(false);
        //    }
        //}


        void Search()
        {
            //조회
            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("PROD_LIKE", typeof(String)); //수주코드/명 LIKE 검색
            paramTable.Columns.Add("CVND_LIKE", typeof(String)); //발주
            //paramTable.Columns.Add("BUSINESS_EMP", typeof(String)); //발주
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
            paramTable.Columns.Add("IS_END", typeof(String)); //납기일 종료일
            paramTable.Columns.Add("PROC_CODE_IN", typeof(String));

            DataRow layoutRow = acLayoutControl1.CreateParameterRow();

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["PROD_LIKE"] = layoutRow["PROD_LIKE"];
            paramRow["CVND_LIKE"] = layoutRow["CVND_LIKE"];
            //paramRow["BUSINESS_EMP"] = layoutRow["BUSINESS_EMP"];
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
                //paramRow["PROC_CODE_IN"] = "(" + paramRow["PROC_CODE_IN"].ToString() + ")";
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
             "POP06A_SER", paramSet, "RQSTDT", "RSLTDT",
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

                acGridView1.RaiseFocusedRowChanged();

                this._IsChanged = false;

                acGridView1.ClearSelection();

                acAlert.Show(this, "저장 되었습니다.", acAlertForm.enmType.Success);
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

                if (focusRow != null)
                {
                    POP05A_D1A frm = new POP05A_D1A(focusRow);
                    frm.ParentControl = this;
                    frm.DialogMode = BaseMenuDialog.emDialogMode.NEW;
                    base.ChildFormAdd("NEW_ITEM", frm);
                    frm.Show(this);
                }

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

        private void btnLastEnd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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
                paramTable.Columns.Add("WO_NO", typeof(String)); //                
                paramTable.Columns.Add("REG_EMP", typeof(String)); //
                paramTable.Columns.Add("IS_SHIP", typeof(String)); //

                DataRow[] rows = acGridView1.GetSelectedDataRows();

                if (rows.Length == 0)
                    rows = new DataRow[] { acGridView1.GetFocusedDataRow() };

                foreach (DataRow row in rows)
                {

                    DataRow paramRow = paramTable.NewRow();
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["WO_NO"] = row["WO_NO"];
                    paramRow["REG_EMP"] = acInfo.UserID;
                    paramTable.Rows.Add(paramRow);

                }

                {
                    DataSet paramSet = new DataSet();
                    paramSet.Tables.Add(paramTable);

                    BizRun.QBizRun.ExecuteService(
                    this, QBiz.emExecuteType.PROCESS, "POP06A_UPD", paramSet, "RQSTDT", "RSLTDT",
                    QuickUPD,
                    QuickException);
                }
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

                    POP05A_D0A frm = new POP05A_D0A(acGridView1, null);

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


        void GetDatail()
        {

            DataRow focusRow = acGridView1.GetFocusedDataRow();

            if (focusRow == null)
            {
                acGridView2.ClearRow();

                return;
            }

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("PROD_CODE", typeof(String)); //

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["PROD_CODE"] = focusRow["PROD_CODE"];

            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);


            BizRun.QBizRun.ExecuteService(
            this, QBiz.emExecuteType.LOAD_DETAIL,
            "ORD02A_SER2", paramSet, "RQSTDT", "RSLTDT",
            QuickDetail,
            QuickException);


        }
        void QuickDetail(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                this._dicProcStat.Clear();

                DataTable dtTemp = e.result.Tables["RSLTDT"];

                foreach (DataRow row in this._dtProcList.Rows)
                {
                    dtTemp.Columns.Add(row["PROC_CODE"].ToString(), typeof(string));
                }

                foreach (DataRow row in e.result.Tables["RSLTDT_WO"].Rows)
                {

                    if (!dtTemp.Columns.Contains(row["PROC_CODE"].ToString()))
                        continue;

                    string where = string.Format("PT_ID = '{0}' AND RE_WO_NO IS NULL", row["PT_ID"]);

                    if (row["RE_WO_NO"].toStringEmpty() != "")
                    {
                        where = string.Format("PT_ID = '{0}' AND RE_WO_NO = '{1}'", row["PT_ID"], row["RE_WO_NO"]);
                    }

                    DataRow[] dataRows = dtTemp.Select(where);

                    string act_qty = (row["ACT_QTY"].toInt() > 0) ? row["ACT_QTY"].ToString() : "-";

                    if (dataRows.Length == 0)
                        continue;

                    dataRows[0]["PRC_PART_QTY"] = row["PART_QTY"];

                    switch (row["WO_FLAG"].ToString())
                    {
                        case "0":
                        case "1":
                            dataRows[0][row["PROC_CODE"].ToString()] = row["PLN_START_TIME"].toDateString("MM/dd")+"\r\n(" + act_qty +")";
                            break;
                        case "2":
                        case "3":
                            dataRows[0][row["PROC_CODE"].ToString()] = row["ACT_START_TIME"].toDateString("MM/dd") + "\r\n(" + act_qty + ")";
                            break;
                        case "4":
                            dataRows[0][row["PROC_CODE"].ToString()] = row["ACT_END_TIME"].toDateString("MM/dd") + "\r\n(" + act_qty + ")";
                            break;
                    }
                    if (this._dicProcStat.ContainsKey(row["PT_ID"].ToString() + row["PROC_CODE"].ToString() + row["RE_WO_NO"].ToString()))
                    {
                        if (row["WO_FLAG"].ToString() != "4")
                            this._dicProcStat[row["PT_ID"].ToString() + row["PROC_CODE"].ToString() + row["RE_WO_NO"].ToString()] = row["WO_FLAG"].ToString();
                    }
                    else
                    {
                        this._dicProcStat.Add(row["PT_ID"].ToString() + row["PROC_CODE"].ToString() + row["RE_WO_NO"].ToString(), row["WO_FLAG"].ToString());
                    }

                }

                acGridView2.GridControl.DataSource = dtTemp;

                acGridView2.BestFitColumns();



                acTreeList1.DataSource = e.result.Tables["RSLTDT_BOM"];
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

        private void acSimpleButton1_Click(object sender, EventArgs e)
        {
            if (acTreeList1.Nodes.Count > 0)
                acTreeList1.ExpandAll();
        }

        private void acSimpleButton2_Click(object sender, EventArgs e)
        {
            if (acTreeList1.Nodes.Count > 0)
                acTreeList1.CollapseAll();
        }

        private void acBarButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!base.ChildFormContains("NEW"))
                {
                    DataRow focusRow = acGridView1.GetFocusedDataRow();

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

        private void acBarButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //비고저장
            acGridView1.EndEditor();

            DataTable modifyTable = acGridView1.GetAddModifyRows();

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(string));
            paramTable.Columns.Add("PROD_CODE", typeof(string));
            paramTable.Columns.Add("PT_ID", typeof(string));
            paramTable.Columns.Add("WO_NO", typeof(string));
            paramTable.Columns.Add("SCOMMENT", typeof(string));

            foreach (DataRow row in modifyTable.Rows)
            {
                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["PROD_CODE"] = row["PROD_CODE"];
                paramRow["PT_ID"] = row["PT_ID"];
                paramRow["WO_NO"] = row["WO_NO"];
                paramRow["SCOMMENT"] = row["ASSY_SCOMMENT"];

                paramTable.Rows.Add(paramRow);
            }

            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            BizRun.QBizRun.ExecuteService(
            this, QBiz.emExecuteType.SAVE,
            "POP06A_UPD2", paramSet, "RQSTDT", "RSLTDT",
            QuickSave2,
            QuickException);
        }

        void QuickSave2(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {

                foreach (DataRow row in e.result.Tables["RSLTDT"].Rows)
                {
                    acGridView1.UpdateMapingRow(row, false);
                }

                acAlert.Show(this, "저장 되었습니다.", acAlertForm.enmType.Success);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void acBarButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //조립작업자 추가
            acGridView1.EndEditor();

            DataRow focusRow = acGridView1.GetFocusedDataRow();

            if (focusRow == null)
                return;

            POP06A_D0A frm = new POP06A_D0A(focusRow, acGridView1, "A");

            frm.DialogMode = BaseMenuDialog.emDialogMode.NEW;

            frm.ParentControl = this;

            frm.Show(this);
        }

        private void acBarButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //핀작업자 추가
            acGridView1.EndEditor();

            DataRow focusRow = acGridView1.GetFocusedDataRow();

            if (focusRow == null)
                return;

            POP06A_D0A frm = new POP06A_D0A(focusRow, acGridView1, "P");

            frm.DialogMode = BaseMenuDialog.emDialogMode.NEW;

            frm.ParentControl = this;

            frm.Show(this);
        }
    }

}
