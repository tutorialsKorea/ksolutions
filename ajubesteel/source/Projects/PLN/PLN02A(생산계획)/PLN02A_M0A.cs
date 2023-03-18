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
using POP;
using System.IO;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;

namespace PLN
{
    public sealed partial class PLN02A_M0A : BaseMenu
    {

        private GridHitInfo _downHitInfo = null;

        public PLN02A_M0A()
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

        private enum emOption
        {
            //계획일정
            PLN_TIME,

            //지시상태
            WO_STATE,

            //도형
            WO_FIG

        }

        private emOption _viewOpt = emOption.PLN_TIME;

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
            return base.MenuDestory(sender);

        }


        public override void MenuLink(object data)
        {

            this.Search();

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

            acGridView1.AddLookUpEdit("PROD_STATE", "수주상태", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P012");
            acGridView1.AddCheckEdit("BOM_FLAG", "BOM", "", false, false, true, acGridView.emCheckEditDataType._INT);
            acGridView1.AddCheckEdit("LOCK_FLAG", "잠금상태", "", false, false, true, acGridView.emCheckEditDataType._BYTE);            
            acGridView1.AddLookUpEmp("LOCK_EMP", "잠금자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false);
            acGridView1.AddLookUpEdit("PROD_PRIORITY", "우선순위", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P028");
            acGridView1.AddTextEdit("PROD_CODE", "수주번호", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddCheckEdit("CHK_FLAG", "확인", "", false, true, true, acGridView.emCheckEditDataType._STRING);
            acGridView1.AddTextEdit("CHK_EMP", "확인자 코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("CHK_EMP_NAME", "확인자", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddDateEdit("CHK_DATE", "확인일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
            acGridView1.AddTextEdit("CHK_DEL_EMP", "확인취소자 코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("CHK_DEL_EMP_NAME", "확인취소자", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddDateEdit("CHK_DEL_DATE", "확인취소일", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emDateMask.SHORT_DATE);
            

            acGridView1.AddTextEdit("PROD_NAME", "모델명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("PROD_VERSION", "버전", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddLookUpEdit("PROC_FLAG", "공정명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P005");
            acGridView1.AddLookUpEdit("PROD_FLAG", "유형", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P006");
            acGridView1.AddLookUpEdit("PROD_KIND", "제품구분", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "C011");
            acGridView1.AddLookUpEdit("INS_YN", "성적서", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P007");
            acGridView1.AddLookUpEdit("SOCKET_YN", "소켓측정", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P007");            
            acGridView1.AddCheckedComboBoxEdit("PROD_CATEGORY", "제품유형", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, "P009");
            //acGridView1.AddTextEdit("BUSINESS_EMP", "영업담당자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddLookUpEmp("BUSINESS_EMP", "영업담당자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false);
            //acGridView1.AddTextEdit("CUSTOMER_EMP", "고객담당자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddLookUpEmp("CUSTOMER_EMP", "고객담당자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false);
            //acGridView1.AddTextEdit("CUSTDESIGN_EMP", "고객설계자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddLookUpEmp("CUSTDESIGN_EMP", "고객설계자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false);
            acGridView1.AddLookUpEdit("ACTUATOR_YN", "Actuator유무", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "S101");

            //acGridView1.AddTextEdit("CVND_CODE", "발주처코드", "CPW0FS8W", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("CVND_NAME", "발주처", "CPW0FS8W", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            //acGridView1.AddTextEdit("TVND_CODE", "계산서 발행처 코드", "CPW0FS8W", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("TVND_NAME", "계산서 발행처", "CPW0FS8W", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddDateEdit("ORD_DATE", "수주일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
            acGridView1.AddDateEdit("DUE_DATE", "출하예정일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
            acGridView1.AddDateEdit("CHG_DUE_DATE", "출하조정일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
            //acGridView1.AddDateEdit("DELIVERY_DATE", "납품일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);

            acGridView1.AddDateEdit("DES_DATE", "설계일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);

            acGridView1.AddDateEdit("LAST_DES_DATETIME", "설계시간", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.MEDIUM_DATE2);
            acGridView1.AddDateEdit("PREV_DES_DATETIME", "이전 설계시간", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.MEDIUM_DATE2);

            acGridView1.AddCheckedComboBoxEdit("PIN_TYPE", "Contact", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, "P011");
            acGridView1.AddLookUpEdit("PROD_TYPE", "제품분류", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P010");
            acGridView1.AddTextEdit("PROD_QTY", "수량", "CPW0FS8W", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NUMERIC);
            //acGridView1.AddTextEdit("PROD_COST", "공급단가", "CPW0FS8W", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
            //acGridView1.AddTextEdit("PROD_AMT", "총금액", "CPW0FS8W", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
            //acGridView1.AddCheckEdit("ORD_VAT", "VAT별도", "", false, false, true, acGridView.emCheckEditDataType._STRING);
            //acGridView1.AddLookUpEdit("CURR_UNIT", "통화", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P008");

            acGridView1.AddLookUpEdit("TRADE_YN", "거래명세표", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P007");
            acGridView1.AddLookUpEdit("TAX_YN", "세금계산서", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P007");
            acGridView1.AddLookUpEdit("BILL_YN", "수금등록", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P007");

            acGridView1.AddTextEdit("DRAW_EMP", "조립품 개발자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            //acGridView1.AddMemoEdit("REMARK", "특기사항", "", false, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, false, true, true, false);
            acGridView1.AddMemoEdit("SCOMMENT", "전달사항", "", false, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, false, true, true, false);

            acGridView1.AddDateEdit("REG_DATE", "최초 등록일", "UL1O77MB", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emDateMask.LONG_DATE);
            acGridView1.AddTextEdit("REG_EMP", "최초 등록자코드", "P72K0SQJ", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("REG_EMP_NAME", "최초 등록자", "GPQHG8QQ", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddDateEdit("MDFY_DATE", "최근 수정일", "6RXQO0B2", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emDateMask.LONG_DATE);
            acGridView1.AddTextEdit("MDFY_EMP", "최근 수정자코드", "WDHSCE72", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("MDFY_EMP_NAME", "최근 수정자", "FHJDO4F0", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);

            acGridView1.KeyColumn = new string[] { "PROD_CODE" };

            acGridView1.OptionsCustomization.AllowRowSizing = true;
            acGridView1.OptionsView.RowAutoHeight = false;

            acGridView2.GridType = acGridView.emGridType.SEARCH;

//            acGridView2.AddCheckEdit("SEL", "선택", "40290", true, true, true, acGridView.emCheckEditDataType._STRING);            
            acGridView2.AddTextEdit("PART_CODE", "품목코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("PART_NAME", "품목명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("PART_SPEC", "규격", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("MAT_QLTY", "재질", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("SURFACE_TREAT", "표면처리/도장", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("AFTER_TREAT", "후처리", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

            RepositoryItemButtonEdit riButtonEdit = new RepositoryItemButtonEdit();
            EditorButton button = new EditorButton(ButtonPredefines.Glyph, string.Empty, -1, true, true, false, ImageLocation.MiddleCenter, null);
            riButtonEdit.LookAndFeel.SetSkinStyle(DevExpress.LookAndFeel.SkinStyle.TheAsphaltWorld);

            button.Caption = "DWG";
            button.ToolTip = "DWG";

            riButtonEdit.Buttons.Clear();
            riButtonEdit.Buttons.Add(button);
            riButtonEdit.TextEditStyle = TextEditStyles.HideTextEditor;
            riButtonEdit.ButtonClick += DWG_ButtonClick;

            acGridView2.AddCustomEdit("DWG_OPEN", "DWG", "", false, DevExpress.Utils.HorzAlignment.Center, true, true, false, riButtonEdit);

            RepositoryItemButtonEdit riButtonEdit2 = new RepositoryItemButtonEdit();
            EditorButton button2 = new EditorButton(ButtonPredefines.Glyph, string.Empty, -1, true, true, false, ImageLocation.MiddleCenter, null);
            riButtonEdit2.LookAndFeel.SetSkinStyle(DevExpress.LookAndFeel.SkinStyle.TheAsphaltWorld);

            button2.Caption = "PDF";
            button2.ToolTip = "PDF";

            riButtonEdit2.Buttons.Clear();
            riButtonEdit2.Buttons.Add(button2);
            riButtonEdit2.TextEditStyle = TextEditStyles.HideTextEditor;
            riButtonEdit2.ButtonClick += PDF_ButtonClick;

            acGridView2.AddCustomEdit("PDF_OPEN", "PDF", "", false, DevExpress.Utils.HorzAlignment.Center, true, true, false, riButtonEdit2);

            RepositoryItemButtonEdit riButtonEdit3 = new RepositoryItemButtonEdit();
            EditorButton button3 = new EditorButton(ButtonPredefines.Glyph, string.Empty, -1, true, true, false, ImageLocation.MiddleCenter, null);
            riButtonEdit3.LookAndFeel.SetSkinStyle(DevExpress.LookAndFeel.SkinStyle.TheAsphaltWorld);

            button3.Caption = "JT";
            button3.ToolTip = "JT";

            riButtonEdit3.Buttons.Clear();
            riButtonEdit3.Buttons.Add(button3);
            riButtonEdit3.TextEditStyle = TextEditStyles.HideTextEditor;
            riButtonEdit3.ButtonClick += JT_ButtonClick;

            acGridView2.AddCustomEdit("JT_OPEN", "JT", "", false, DevExpress.Utils.HorzAlignment.Center, true, true, false, riButtonEdit3);

            acGridView2.AddTextEdit("DRAW_NO", "도면명", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("PRC_PART_QTY", "수량", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NUMERIC);
            acGridView2.AddLookUpEdit("MAT_UNIT", "단위", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M003");
            acGridView2.AddLookUpEdit("IS_REWORK", "재작업여부", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "W012");

            acGridView2.AddTextEdit("OS_TYPE", "외주구분", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView2.AddTextEdit("IS_COPY_SIDE_DISP", "측면수정", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE); 
            acGridView2.AddDateEdit("COPY_SIDE_DATE", "측면수정일", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emDateMask.SHORT_DATE);
            acGridView2.AddTextEdit("COPY_SIDE_EMP_NAME", "측면수정자", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);

            acGridView2.AddHidden("IS_DES_CHANGE", typeof(string));
            acGridView2.AddHidden("IS_DES_REMCT", typeof(string));
            acGridView2.AddHidden("IS_DES_MODIFY", typeof(string));
            acGridView2.AddHidden("PT_ID", typeof(string));
            acGridView2.AddHidden("PART_QTY", typeof(int));
            acGridView2.AddHidden("RE_WO_NO", typeof(string));
            //공정 컬럼 생성
            if (acLayoutControl1.ValidCheck() == false)
            {
                return;
            }

            DataRow layoutRow = acLayoutControl1.CreateParameterRow();


            //this._dtProcList = ExtensionMethods.GetProcList(this);

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("IS_DISP", typeof(Byte)); //
            paramTable.Columns.Add("IS_DISP2", typeof(Byte)); //

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["IS_DISP"] = 0;
            paramRow["IS_DISP2"] = 0;

            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);


            DataTable dtProc = BizRun.QBizRun.ExecuteService(this, "COMMON", "COMMON_PROC", paramSet, "RQSTDT", "RSLTDT").Tables["RSLTDT"];

            this._dtProcList = dtProc;

            foreach(DataRow row in this._dtProcList.Rows)
            {

                //acGridView2.AddTextEdit(row["PROC_CODE"].ToString(), row["PROC_NAME"].ToString(), "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView2.AddCheckEdit(row["PROC_CODE"].ToString(), row["PROC_NAME"].ToString(), "", false, true, true, acGridView.emCheckEditDataType._STRING);
                acGridView2.Columns[row["PROC_CODE"].ToString()].Tag = "PROC";
            }

            acGridView2.AddTextEdit("PART_SCOMMENT", "비고", "ARYZ726K", true, DevExpress.Utils.HorzAlignment.Near, true, true, false, acGridView.emTextEditMask.NONE);
            //acGridView2.AddMemoEdit("SCOMMENT", "비고", "ARYZ726K", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Top, true, false, true, false);

            acGridView2.KeyColumn = new string[] { "PART_CODE" };

            acCheckedComboBoxEdit1.AddItem("등록일", false, "", "REG_DATE", true, false);
            acCheckedComboBoxEdit1.AddItem("수주일", false, "", "ORD_DATE", true, false);
            acCheckedComboBoxEdit1.AddItem("출하예정일", false, "", "DUE_DATE", true, false);
            //acCheckedComboBoxEdit1.AddItem("납품일", false, "", "DELIVERY_DATE", true, false);

            this.acLayoutControl1.OnValueKeyDown += new acLayoutControl.ValueKeyDownEventHandler(acLayoutControl1_OnValueKeyDown);
            this.acLayoutControl1.OnValueChanged += new acLayoutControl.ValueChangedEventHandler(acLayoutControl1_OnValueChanged);

            this.acGridView1.ShowGridMenuEx += new acGridView.ShowGridMenuExHandler(acGridView1_ShowGridMenuEx);

            this.acGridView1.CustomDrawCell += AcGridView1_CustomDrawCell;
            this.acGridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(acGridView1_FocusedRowChanged);

            acGridView2.CustomDrawCell += acGridView2_CustomDrawCell;
            acGridView2.CellValueChanging += acGridView2_CellValueChanging;

            acGridView2.ShowGridMenuEx += acGridView2_ShowGridMenuEx; ;

            acGridView2.CustomRowCellEdit += acGridView2_CustomRowCellEdit;

            _WAIT = acInfo.SysConfig.GetSysConfigByServer("MC_OPERATE_CLR_WAIT").toColor();
            _RUN = acInfo.SysConfig.GetSysConfigByServer("MC_OPERATE_CLR_RUN").toColor();
            _PAUSE = acInfo.SysConfig.GetSysConfigByServer("MC_OPERATE_CLR_PAUSE").toColor();
            _FINISH = acInfo.SysConfig.GetSysConfigByServer("MC_OPERATE_CLR_FINISH").toColor();


            txtNone.BackColor = Color.DarkGray;// acInfo.SysConfig.GetSysConfigByServer("MC_OPERATE_CLR_PAUSE").toColor(); 
            txtWait.BackColor = acInfo.SysConfig.GetSysConfigByServer("MC_OPERATE_CLR_WAIT").toColor();
            txtRun.BackColor = acInfo.SysConfig.GetSysConfigByServer("MC_OPERATE_CLR_RUN").toColor();
            txtFinish.BackColor = acInfo.SysConfig.GetSysConfigByServer("MC_OPERATE_CLR_FINISH").toColor();
            //txtFinish.BackColor = Color.YellowGreen;

            _dicProcStat = new Dictionary<string, string>();


            base.MenuInit();
        }

        private void acGridView2_CustomRowCellEdit(object sender, CustomRowCellEditEventArgs e)
        {
            try
            {
                //string isDWG = acGridView2.GetRowCellValue(e.RowHandle, "IS_DWG").ToString();
                //string isPDF = acGridView2.GetRowCellValue(e.RowHandle, "IS_PDF").ToString();
                //string isJT = acGridView2.GetRowCellValue(e.RowHandle, "IS_JT").ToString();
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

        private void PDF_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
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

        private void JT_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
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



        private void acGridView2_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {

            if (e.Column.FieldName == "PART_SCOMMENT") { return; }

            DataRow thisRow = acGridView2.GetDataRow(e.RowHandle);

            string key = thisRow["PT_ID"].ToString() + e.Column.FieldName + thisRow["RE_WO_NO"].ToString();

            if (this._dicProcStat.ContainsKey(key))
            {

                string wo_flag = this._dicProcStat[key];

                if (wo_flag == "2" || wo_flag == "3" || wo_flag == "4")
                {
                    acAlert.Show(this, "해당작업지시가 이미 진행된 항목이라 수정 할 수 없습니다.", acAlertForm.enmType.Success);
                    this.acGridView2.SetRowCellValue(e.RowHandle, e.Column, "1");
                    return;
                }

                this._dicProcStat[key] = "0";
            }            

            this.acGridView2.SetRowCellValue(e.RowHandle, e.Column, e.Value);
            this.acGridView2.EndEditor();
        }

        private void acGridView2_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            


            try
            {
                if (e.CellValue == null
                    || e.Column.Tag == null) return;

                if (e.CellValue.ToString() == "1")
                    e.Appearance.BackColor = Color.DarkGray;
                //else
                //    e.Appearance.BackColor = Color.White;

                e.Appearance.ForeColor = Color.Black;

                DataRow thisRow = acGridView2.GetDataRow(e.RowHandle);

                string key = thisRow["PT_ID"].ToString() + e.Column.FieldName + thisRow["RE_WO_NO"].ToString();

                if (!this._dicProcStat.ContainsKey(key))
                    return;

                switch (this._dicProcStat[key])
                {
                    //case "0":
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
            catch
            {

            }
        }

        void SetBtnEnable()
        {
            if(acGridView2.RowCount == 0)
            {
                btnPlanSave.Enabled = false;
                btnWoSave.Enabled = false;
                btnOverLoadPlan.Enabled = false;
            }
            else
            {
                if (acGridView2.GetFocusedDataRow()["HAS_WO"].ToString() == "1")
                {
                    btnPlanSave.Enabled = true;
                    btnWoSave.Enabled = true;
                    btnOverLoadPlan.Enabled = true;
                }
                else
                {
                    btnPlanSave.Enabled = false;
                    btnWoSave.Enabled = true;
                    btnOverLoadPlan.Enabled = false;
                }
            }
        }

        private void btnWoSave_Click(object sender, EventArgs e)
        {
            acGridView2.EndEditor();


            //DataRow[] selectedRows = acGridView1.GetSelectedDataRows();

            //if (selectedRows.Length == 0)
            //{
            //    acMessageBox.Show("선택된 데이터가 없습니다.", "확인", acMessageBox.emMessageBoxType.CONFIRM);
            //    return;
            //}

            DataTable paramTable1 = new DataTable("RQSTDT");
            paramTable1.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable1.Columns.Add("PROD_CODE", typeof(String)); //
            paramTable1.Columns.Add("PART_CODE", typeof(String)); //
            paramTable1.Columns.Add("PART_ID", typeof(int)); //
            paramTable1.Columns.Add("PROC_ID", typeof(int)); //
            paramTable1.Columns.Add("PT_ID", typeof(String)); //
            paramTable1.Columns.Add("PROC_CODE", typeof(String)); //
            paramTable1.Columns.Add("PART_QTY", typeof(int)); //
            paramTable1.Columns.Add("PLN_START_DATE", typeof(String)); //
            paramTable1.Columns.Add("PLN_END_DATE", typeof(String)); //
            paramTable1.Columns.Add("WO_FLAG", typeof(String)); //
            paramTable1.Columns.Add("DATA_FLAG", typeof(byte)); //
            paramTable1.Columns.Add("REG_EMP", typeof(String)); //
            paramTable1.Columns.Add("PROD_PRIORITY", typeof(String)); //
            paramTable1.Columns.Add("SCOMMENT", typeof(String)); //
            paramTable1.Columns.Add("RE_WO_NO", typeof(String)); //
            paramTable1.Columns.Add("IS_DES_CHANGE", typeof(String)); //
            paramTable1.Columns.Add("IS_REMCT", typeof(String)); //
            paramTable1.Columns.Add("IS_MODIFY", typeof(String)); //


            DataRow masterRow = acGridView1.GetFocusedDataRow();

            DataView dataView = acGridView2.GetDataView();

            for (int i = 0; i < dataView.Count; i++)
            {
                int proc_id = 0;
                foreach (acGridColumn col in acGridView2.Columns)
                {
                    if (col.Tag == null || col.Tag.ToString() != "PROC")
                        continue;

                    //if (dataView[i][col.FieldName].ToString() != "1")
                    //  proc_id++;

                    string key = dataView[i]["PT_ID"].ToString() + col.FieldName + dataView[i]["RE_WO_NO"].ToString();
                    string wo_flag = "0";
                    if (this._dicProcStat.ContainsKey(key))
                        wo_flag = this._dicProcStat[key];

                    DataRow paramRow1 = paramTable1.NewRow();
                    paramRow1["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow1["PROD_CODE"] = masterRow["PROD_CODE"];
                    paramRow1["PART_CODE"] = dataView[i]["PART_CODE"];
                    paramRow1["PART_ID"] = i;
                    paramRow1["PROC_ID"] = dataView[i][col.FieldName].ToString() == "1" ? proc_id++ : -1;
                    paramRow1["PT_ID"] = dataView[i]["PT_ID"];
                    paramRow1["PROC_CODE"] = col.FieldName;
                    //paramRow1["PART_QTY"] = dataView[i]["BOM_QTY"].toInt() * masterRow["PROD_QTY"].toInt();
                    paramRow1["PART_QTY"] = dataView[i]["PRC_PART_QTY"].toInt();
                    paramRow1["PLN_START_DATE"] = DateTime.Now.toDateString("yyyyMMdd");
                    paramRow1["PLN_END_DATE"] = DateTime.Now.toDateString("yyyyMMdd");
                    paramRow1["WO_FLAG"] = wo_flag;
                    paramRow1["DATA_FLAG"] = dataView[i][col.FieldName].ToString() == "1" ? 0 : 2;
                    paramRow1["REG_EMP"] = acInfo.UserID;
                    paramRow1["PROD_PRIORITY"] = masterRow["PROD_PRIORITY"];
                    paramRow1["SCOMMENT"] = dataView[i]["PART_SCOMMENT"];
                    paramRow1["RE_WO_NO"] = dataView[i]["RE_WO_NO"];
                    paramRow1["IS_DES_CHANGE"] = dataView[i]["IS_DES_CHANGE"];
                    paramRow1["IS_REMCT"] = dataView[i]["IS_DES_REMCT"];
                    paramRow1["IS_MODIFY"] = dataView[i]["IS_DES_MODIFY"];

                    paramTable1.Rows.Add(paramRow1);
                }
            }

            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable1);

            BizRun.QBizRun.ExecuteService(
            this, QBiz.emExecuteType.SAVE,
            "PLN02A_SAVE", paramSet, "RQSTDT", "RSLTDT",
            QuickSave,
            QuickException);
        }


        void QuickSave(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                acGridView2.GetFocusedDataRow()["HAS_WO"] = "1";

                GetDetail();

                acAlert.Show(this, "작업지시가 저장 및 생성 되었습니다.", acAlertForm.enmType.Success);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
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

                layout.GetEditor("DATE").Value = "REG_DATE";
                layout.GetEditor("S_DATE").Value = acDateEdit.GetNowFirstDate();
                layout.GetEditor("E_DATE").Value = DateTime.Now;

                SetBtnEnable();
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
       

        void acGridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            acGridView view = sender as acGridView;

            if (view.ValidFocusRowHandle())
            {
                this.GetDetail();

            }
            else
            {
                acGridView2.ClearRow();
                SetBtnEnable();
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

        private void acGridView2_ShowGridMenuEx(object sender, PopupMenuShowingEventArgs e)
        {
            acGridView view = sender as acGridView;

            if (e.MenuType == GridMenuType.User)
            {
                acBarButtonItem4.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                acBarButtonItem5.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
            else if (e.MenuType == GridMenuType.Row)
            {
                if (e.HitInfo.RowHandle >= 0)
                {
                    acBarButtonItem4.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    acBarButtonItem5.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                }
                else
                {
                    acBarButtonItem4.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    acBarButtonItem5.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                }
            }

            if (e.HitInfo.HitTest == GridHitTest.EmptyRow || e.HitInfo.HitTest == GridHitTest.Row || e.HitInfo.HitTest == GridHitTest.RowCell)
            {
                GridHitInfo hitInfo = view.CalcHitInfo(e.Point);

                popupMenu2.ShowPopup(view.GridControl.PointToScreen(e.Point));
            }
        }



        void Search()
        {
            //조회
            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("PROD_LIKE", typeof(String)); //수주코드/명 LIKE 검색
            paramTable.Columns.Add("CVND_LIKE", typeof(String)); //발주
            paramTable.Columns.Add("BUSINESS_EMP", typeof(String)); //발주
            paramTable.Columns.Add("S_REG_DATE", typeof(String)); //등록 시작일
            paramTable.Columns.Add("E_REG_DATE", typeof(String)); //등록 종료일
            paramTable.Columns.Add("S_ORD_DATE", typeof(String)); //수주일 시작일
            paramTable.Columns.Add("E_ORD_DATE", typeof(String)); //수주일 종료일
            //paramTable.Columns.Add("S_DELIVERY_DATE", typeof(String)); //출하 시작일
            //paramTable.Columns.Add("E_DELIVERY_DATE", typeof(String)); //출하 종료일
            paramTable.Columns.Add("S_DUE_DATE", typeof(String)); //납기일 시작일
            paramTable.Columns.Add("E_DUE_DATE", typeof(String)); //납기일 종료일
            paramTable.Columns.Add("S_SHIP_DATE", typeof(String)); //출하 시작일
            paramTable.Columns.Add("E_SHIP_DATE", typeof(String)); //출하 종료일
            paramTable.Columns.Add("HAS_NONE_WO", typeof(String)); //출하 종료일
            paramTable.Columns.Add("PROD_KIND_NOT_IE", typeof(String));
            

            DataRow layoutRow = acLayoutControl1.CreateParameterRow();

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["PROD_LIKE"] = layoutRow["PROD_LIKE"];
            paramRow["CVND_LIKE"] = layoutRow["CVND_LIKE"];
            paramRow["BUSINESS_EMP"] = layoutRow["BUSINESS_EMP"];
            if (!acCheckEdit1.Checked)
                paramRow["HAS_NONE_WO"] = "1";

            paramRow["PROD_KIND_NOT_IE"] = "1";
            
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
                    //case "DELIVERY_DATE":
                    //    //납품일
                    //    paramRow["S_DELIVERY_DATE"] = layoutRow["S_DATE"];
                    //    paramRow["E_DELIVERY_DATE"] = layoutRow["E_DATE"];

                    //    break;

                    case "SHIP_DATE":
                        //출하일
                        paramRow["S_SHIP_DATE"] = layoutRow["S_DATE"];
                        paramRow["E_SHIP_DATE"] = layoutRow["E_DATE"];

                        break;
                }
            }


            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);


            BizRun.QBizRun.ExecuteService(
             this, QBiz.emExecuteType.LOAD,
             "PLN02A_SER", paramSet, "RQSTDT", "RSLTDT",
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

        public override void DataRefresh(object data)
        {
            GetDetail();
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

                this.DataRefresh("PROD");
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

        void GetDetail()
        {

            DataRow focusRow = acGridView1.GetFocusedDataRow();

            if (focusRow == null)
            {
                acGridView2.ClearRow();
                SetBtnEnable();
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
            "PLN02A_SER2", paramSet, "RQSTDT", "RSLTDT",
            QuickDetail,
            QuickException);


        }
        void QuickDetail(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                this._dicProcStat.Clear();

                if (!e.result.Tables["RSLTDT"].Columns.Contains("OS_TYPE"))
                {
                    e.result.Tables["RSLTDT"].Columns.Add("OS_TYPE", typeof(string));
                }

                DataTable dtTemp = e.result.Tables["RSLTDT"];

                foreach (DataRow row in this._dtProcList.Rows)
                {
                    dtTemp.Columns.Add(row["PROC_CODE"].ToString(), typeof(string));
                }

                if (e.result.Tables.Contains("RSLTDT_WO"))
                {                    
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

                        if (dataRows.Length == 0)
                            continue;

                        dataRows[0][row["PROC_CODE"].ToString()] = "1";

                        if (row["PROC_CODE"].ToString() == "P14")
                        {
                            dataRows[0]["OS_TYPE"] = row["OS_TYPE"];
                        }

                        dataRows[0]["PRC_PART_QTY"] = row["PART_QTY"];

                        if (!this._dicProcStat.ContainsKey(row["PT_ID"].ToString() + row["PROC_CODE"].ToString() + row["RE_WO_NO"].ToString()))
                            this._dicProcStat.Add(row["PT_ID"].ToString() + row["PROC_CODE"].ToString() + row["RE_WO_NO"].ToString(), row["WO_FLAG"].ToString());
                    }
                }
                foreach (DataRow row in e.result.Tables["RSLTDT"].Rows)
                {
                    //작업지시가 저장 안된경우
                    if (row["HAS_WO"].ToString() != "1")
                    {
                        //도금 공정 자동 체크
                        if (row["MAT_SPEC"].ToString().Contains("AL"))
                        {
                            row["P-11"] = "1";
                        }
                        ////측면 공정 자동 체크
                        //if (row["MAT_SPEC"].ToString().Contains("측면"))
                        //{
                        //    row["P-12"] = "1";
                        //}
                    }
                }


                acGridView2.GridControl.DataSource = dtTemp;

                acGridView2.BestFitColumns();

                acGridView2.Columns["PART_NAME"].Width = acGridView2.Columns["DRAW_NO"].Width;


                SetBtnEnable();

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }


        private void barItemHelp_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                this.ShowHelp();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        private void btnPlanSave_Click(object sender, EventArgs e)
        {
            if (acGridView2.ValidFocusRowHandle() == false)
            {
                return;
            }


            DataRow focusRow = acGridView2.GetFocusedDataRow();

            if (focusRow != null)
            {
                if (focusRow["HAS_WO"].ToString() == "1")
                {
                    string formKey = string.Format("{0},{1},{2}", focusRow["PROD_CODE"], focusRow["PT_ID"], focusRow["RE_WO_NO"]);

                    if (!base.ChildFormContains(formKey))
                    {

                        PLN02A_D0A frm = new PLN02A_D0A(acGridView2, focusRow);

                        frm.DialogMode = BaseMenuDialog.emDialogMode.OPEN;

                        frm.ParentControl = this;

                        base.ChildFormAdd(formKey, frm);

                        if (frm.ShowDialog() == DialogResult.OK)
                        {
                            this.DataRefresh(null);
                        }

                    }
                    else
                    {
                        base.ChildFormFocus(formKey);

                    }
                }
                else
                {
                    acMessageBox.Show("저장된 작업지시가 없습니다.", this.Text, acMessageBox.emMessageBoxType.CONFIRM);
                }

            }
        }

        /// <summary>
        /// 설비그룹의 부하고려를 판단하여 외주 판단.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOverLoadPlan_Click(object sender, EventArgs e)
        {
            
        }

        void QuickUpdate(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                //acAlert.Show(this, "부하율 고려가 완료 되었습니다.", acAlertForm.enmType.Success);                

                if (e.result.Tables["RSLTDT"].Rows.Count == 0)
                {
                    acMessageBox.Show("부하율 고려 외주처리된 품목이 없습니다.","확인", acMessageBox.emMessageBoxType.CONFIRM);
                }
                else
                {
                    acMessageBoxGridConfirm msg = new acMessageBoxGridConfirm(this, "외주처리 항목", "부하율 고려 외주처리 품목 입니다.", "", false, "확인", e.result.Tables["RSLTDT"]);

                    msg.View.GridType = acGridView.emGridType.FIXED;

                    msg.Text = "";

                    msg.View.AddTextEdit("PROD_CODE", "수주코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

                    msg.View.AddTextEdit("PART_CODE", "품목코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

                    msg.View.AddTextEdit("PART_NAME", "품목명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

                    msg.ShowDialog();
                }


                acGridView1.ClearSelection();

                GetDetail();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        private void barItemPlanRate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                acGridView1.EndEditor();


                if (acMessageBox.Show(this, "정말 부하율 고려를 진행 하시겠습니까?", "TB43FSY3", false, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
                {
                    return;
                }

                DataRow[] selected = acGridView1.GetSelectedDataRows();


                if (selected.Length == 0)
                {
                    acMessageBox.Show("고려대상 항목이 없습니다.", "확인", acMessageBox.emMessageBoxType.CONFIRM);
                    return;
                }



                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("REG_EMP", typeof(String)); //
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("PROD_CODE", typeof(String)); //                

                if (selected.Length == 0)
                {
                    //단일삭제

                    DataRow focusRow = acGridView1.GetFocusedDataRow();

                    DataRow paramRow = paramTable.NewRow();
                    paramRow["REG_EMP"] = acInfo.UserID;
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["PROD_CODE"] = focusRow["PROD_CODE"];
                    paramTable.Rows.Add(paramRow);


                }
                else
                {

                    //다중삭제
                    foreach (DataRow row in selected)
                    {

                        DataRow paramRow = paramTable.NewRow();
                        paramRow["REG_EMP"] = acInfo.UserID;
                        paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                        paramRow["PROD_CODE"] = row["PROD_CODE"];
                        paramTable.Rows.Add(paramRow);

                    }


                }


                DataSet paramSet = new DataSet();

                paramSet.Tables.Add(paramTable);


                BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.PROCESS,
                "PLN02A_UPD2", paramSet, "RQSTDT", "RSLTDT",
                QuickUpdate,
                QuickException);


            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void acBarButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // 제작사양서
          
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

            try
            {
                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("PART_CODE", typeof(String)); //

                DataRow focusRow = acGridView1.GetFocusedDataRow();

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["PART_CODE"] = focusRow["PART_CODE"];

                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                //도면 조회
                DataSet dsRslt = BizRun.QBizRun.ExecuteService(this, "POP02A_SER2", paramSet, "RQSTDT", "RSLTDT");


                if (dsRslt.Tables["RSLTDT"].Rows.Count == 0)
                    acAlert.Show(this, "등록된 도면이 없습니다.", acAlertForm.enmType.Info);
                else if ((dsRslt.Tables["RSLTDT"].Rows.Count > 1))
                {
                    PopDraw frm = new PopDraw(dsRslt.Tables["RSLTDT"]);

                    frm.Text = string.Format("도면파일리스트 - {0}({1})", focusRow["PART_NAME"], focusRow["PART_CODE"]);

                    frm.DialogMode = BaseMenuDialog.emDialogMode.OPEN;

                    frm.ParentControl = this;

                    base.ChildFormAdd("DRAW", frm);

                    frm.ShowDialog(this);
                }
                else
                {
                    string path = acInfo.SysConfig.GetSysConfigByMemory("DRAW_FILE_DIR");
                    string id = acInfo.SysConfig.GetSysConfigByMemory("DRAW_FILE_DIR_ID");
                    string pass = acInfo.SysConfig.GetSysConfigByMemory("DRAW_FILE_DIR_PW");
                    string removePath = acInfo.SysConfig.GetSysConfigByMemory("DRAW_FILE_REMOVE_DIR");

                    int iSeq = dsRslt.Tables["RSLTDT"].Rows[0]["PART_FILE_PATH"].ToString().IndexOf(removePath) + removePath.Length;

                    string replacePath = dsRslt.Tables["RSLTDT"].Rows[0]["PART_FILE_PATH"].ToString().Substring(iSeq, dsRslt.Tables["RSLTDT"].Rows[0]["PART_FILE_PATH"].ToString().Length - iSeq);

                    string fullPath = path + replacePath;


                    string strFileFullPath = path;
                    string strFileFullName = fullPath;

                    IFModule iFModule = new IFModule(path, id, pass);

                    int ret = iFModule.NetWorkAccess();

                    acMessageBox.Show(ret.ToString(), ret.ToString(), acMessageBox.emMessageBoxType.CONFIRM);

                    //if (ret != 0)
                    //{
                    //    acMessageBox.Show("네트워크 연결 오류", "오류", acMessageBox.emMessageBoxType.CONFIRM);
                    //    return;
                    //}

                    bool isExists = true;

                    if (System.IO.Directory.Exists(strFileFullPath))
                    {
                        FileInfo fileInfo = new FileInfo(strFileFullName);

                        if (fileInfo.Exists)
                        {
                            System.Diagnostics.Process.Start(strFileFullName);
                        }
                        else
                        {
                            isExists = false;
                        }
                    }
                    else
                    {
                        isExists = false;
                    }

                    if (!isExists)
                    {
                        //acMessageBox.Show(this, "파일이 존재하지 않습니다.", "", false, acMessageBox.emMessageBoxType.CONFIRM);
                        acAlert.Show(this, "파일이 존재하지 않습니다.", acAlertForm.enmType.Warning);
                    }

                    //System.Diagnostics.Process.Start(dsRslt.Tables["RSLTDT"].Rows[0]["PART_FILE_PATH"].ToString());
                }


            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        private void acBarButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //추가

            DataRow focusRow = acGridView1.GetFocusedDataRow();

            string formKey = string.Format("{0}", focusRow["PROD_CODE"]);

            if (!base.ChildFormContains(formKey))
            {

                PLN02A_D1A frm = new PLN02A_D1A(acGridView2, focusRow);

                frm.DialogMode = BaseMenuDialog.emDialogMode.OPEN;

                frm.ParentControl = this;

                base.ChildFormAdd(formKey, frm);

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    acGridView1.RaiseFocusedRowChanged();
                }

            }
            else
            {
                base.ChildFormFocus(formKey);

            }
        }

        private void acBarButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //삭제

            acGridView2.EndEditor();
            if (acMessageBox.Show(this, "정말 삭제하시겠습니까?", "", false, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
            {
                return;
            }

            DataRow masterRow = acGridView1.GetFocusedDataRow();
            DataRow focusRow = acGridView2.GetFocusedDataRow();

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String));
            paramTable.Columns.Add("PROD_CODE", typeof(String));
            paramTable.Columns.Add("PT_ID", typeof(String));
            paramTable.Columns.Add("RE_WO_NO", typeof(String));

            DataRow layoutRow = acLayoutControl1.CreateParameterRow();

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["PROD_CODE"] = masterRow["PROD_CODE"];
            paramRow["PT_ID"] = focusRow["PT_ID"];
            paramRow["RE_WO_NO"] = focusRow["RE_WO_NO"];

            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);


            BizRun.QBizRun.ExecuteService(
             this, QBiz.emExecuteType.DEL,
             "PLN02A_DEL", paramSet, "RQSTDT", "RSLTDT",
             QuickDel,
             QuickException);
        }

        void QuickDel(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                acGridView1.RaiseFocusedRowChanged();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        private void acBarButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //확인
            try
            {
                acGridView1.EndEditor();

                if (acMessageBox.Show(this, "저장 하시겠습니까?", "", false, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
                {
                    return;
                }

                DataRow[] selected = acGridView1.GetSelectedDataRows();

                DataTable mdfyTable = acGridView1.GetAddModifyRows();

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("PROD_CODE", typeof(String)); //
                paramTable.Columns.Add("CHK_FLAG", typeof(String)); //
                paramTable.Columns.Add("CHK_EMP", typeof(String)); //
                paramTable.Columns.Add("CHK_DATE", typeof(String)); //
                paramTable.Columns.Add("CHK_DEL_EMP", typeof(String)); //
                paramTable.Columns.Add("CHK_DEL_DATE", typeof(String)); //

                if (mdfyTable.Rows.Count == 0)
                {
                    DataRow focusRow = acGridView1.GetFocusedDataRow();

                    DataRow paramRow = paramTable.NewRow();
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["PROD_CODE"] = focusRow["PROD_CODE"];
                    paramRow["CHK_FLAG"] = focusRow["CHK_FLAG"];

                    if (focusRow["CHK_FLAG"].ToString() == "1")
                    {
                        paramRow["CHK_EMP"] = acInfo.UserID;
                        paramRow["CHK_DATE"] = DateTime.Now.toDateString("yyyyMMdd");
                    }
                    else
                    {
                        paramRow["CHK_DEL_EMP"] = acInfo.UserID;
                        paramRow["CHK_DEL_DATE"] = DateTime.Now.toDateString("yyyyMMdd");
                    }

                    paramTable.Rows.Add(paramRow);
                }
                else
                {
                    foreach (DataRow row in mdfyTable.Rows)
                    {

                        DataRow paramRow = paramTable.NewRow();
                        paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                        paramRow["PROD_CODE"] = row["PROD_CODE"];
                        paramRow["CHK_FLAG"] = row["CHK_FLAG"];

                        if (row["CHK_FLAG"].ToString() == "1")
                        {
                            paramRow["CHK_EMP"] = acInfo.UserID;
                            paramRow["CHK_DATE"] = DateTime.Now.toDateString("yyyyMMdd");
                        }
                        else
                        {
                            paramRow["CHK_DEL_EMP"] = acInfo.UserID;
                            paramRow["CHK_DEL_DATE"] = DateTime.Now.toDateString("yyyyMMdd");
                        }
                        paramTable.Rows.Add(paramRow);
                    }
                }

                DataSet paramSet = new DataSet();

                paramSet.Tables.Add(paramTable);


                BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.PROCESS,
                "PLN02A_UPD3", paramSet, "RQSTDT", "RSLTDT",
                QuickChk,
                QuickException);


            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void QuickChk(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                foreach (DataRow row in e.result.Tables["RSLTDT"].Rows)
                {
                    acGridView1.UpdateMapingRow(row, false);
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        private void acSimpleButton1_Click(object sender, EventArgs e)
        {
            //측면 수정
            acGridView2.EndEditor();

            DataRow focusRow = acGridView2.GetFocusedDataRow();

            if (focusRow != null)
            {
                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String));
                paramTable.Columns.Add("PT_ID", typeof(String));
                paramTable.Columns.Add("IS_COPY_SIDE", typeof(byte));
                paramTable.Columns.Add("COPY_SIDE_DATE", typeof(DateTime));
                paramTable.Columns.Add("COPY_SIDE_EMP", typeof(String));

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["PT_ID"] = focusRow["PT_ID"];
                paramRow["IS_COPY_SIDE"] = "1";
                paramRow["COPY_SIDE_DATE"] = DateTime.Now;
                paramRow["COPY_SIDE_EMP"] = acInfo.UserID;

                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);


                BizRun.QBizRun.ExecuteService(
                 this, QBiz.emExecuteType.PROCESS,
                 "PLN02A_UPD4", paramSet, "RQSTDT", "RSLTDT",
                 QuickUpd,
                 QuickException);
            }
        }

        void QuickUpd(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                if (!e.result.Tables["RSLTDT"].Columns.Contains("OS_TYPE"))
                {
                    e.result.Tables["RSLTDT"].Columns.Add("OS_TYPE", typeof(string));
                }

                DataTable dtTemp = e.result.Tables["RSLTDT"];

                foreach (DataRow row in this._dtProcList.Rows)
                {
                    dtTemp.Columns.Add(row["PROC_CODE"].ToString(), typeof(string));
                }

                if (e.result.Tables.Contains("RSLTDT_WO"))
                {
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

                        if (dataRows.Length == 0)
                            continue;

                        dataRows[0][row["PROC_CODE"].ToString()] = "1";

                        if (row["PROC_CODE"].ToString() == "P14")
                        {
                            dataRows[0]["OS_TYPE"] = row["OS_TYPE"];
                        }

                        dataRows[0]["PRC_PART_QTY"] = row["PART_QTY"];

                    }
                }
                foreach (DataRow row in e.result.Tables["RSLTDT"].Rows)
                {
                    //작업지시가 저장 안된경우
                    if (row["HAS_WO"].ToString() != "1")
                    {
                        //도금 공정 자동 체크
                        if (row["MAT_SPEC"].ToString().Contains("AL"))
                        {
                            row["P-11"] = "1";
                        }
                        ////측면 공정 자동 체크
                        //if (row["MAT_SPEC"].ToString().Contains("측면"))
                        //{
                        //    row["P-12"] = "1";
                        //}
                    }
                }

                DataTable dt = (acGridView2.GridControl.DataSource as DataTable);

                foreach (DataRow rw in dtTemp.Rows)
                {

                    if (rw["RE_WO_NO"].ToString() == "")
                    {
                        DataRow[] rows = dt.Select("PT_ID = '" + rw["PT_ID"].ToString() + "' AND RE_WO_NO IS NULL");

                        if (rows.Length > 0)
                        {
                            rows[0]["IS_COPY_SIDE_DISP"] = rw["IS_COPY_SIDE_DISP"];
                            rows[0]["COPY_SIDE_DATE"] = rw["COPY_SIDE_DATE"];
                            rows[0]["COPY_SIDE_EMP_NAME"] = rw["COPY_SIDE_EMP_NAME"];    
                        }
                    }
                    else
                    {
                        DataRow[] rows = dt.Select("PT_ID = '" + rw["PT_ID"].ToString() + "' AND RE_WO_NO = '" + rw["RE_WO_NO"].ToString() + "'");

                        if (rows.Length > 0)
                        {
                            rows[0]["IS_COPY_SIDE_DISP"] = rw["IS_COPY_SIDE_DISP"];
                            rows[0]["COPY_SIDE_DATE"] = rw["COPY_SIDE_DATE"];
                            rows[0]["COPY_SIDE_EMP_NAME"] = rw["COPY_SIDE_EMP_NAME"];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        private void acSimpleButton2_Click(object sender, EventArgs e)
        {
            //측면 수정 취소
            acGridView2.EndEditor();

            DataRow focusRow = acGridView2.GetFocusedDataRow();

            if (focusRow != null)
            {
                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String));
                paramTable.Columns.Add("PT_ID", typeof(String));
                paramTable.Columns.Add("IS_COPY_SIDE", typeof(byte));
                paramTable.Columns.Add("COPY_SIDE_DATE", typeof(DateTime));
                paramTable.Columns.Add("COPY_SIDE_EMP", typeof(String));

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["PT_ID"] = focusRow["PT_ID"];
                paramRow["IS_COPY_SIDE"] = "0";
                paramRow["COPY_SIDE_DATE"] = DBNull.Value;
                paramRow["COPY_SIDE_EMP"] = DBNull.Value;

                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);


                BizRun.QBizRun.ExecuteService(
                 this, QBiz.emExecuteType.PROCESS,
                 "PLN02A_UPD4", paramSet, "RQSTDT", "RSLTDT",
                 QuickUpd,
                 QuickException);
            }
        }
    }
}
