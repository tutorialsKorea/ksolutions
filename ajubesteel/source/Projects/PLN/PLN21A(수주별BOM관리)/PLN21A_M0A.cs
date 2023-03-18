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
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraEditors.Repository;
using POP;
using System.IO;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraSpreadsheet;
using DevExpress.Spreadsheet;
using DevExpress.XtraTreeList;

namespace PLN
{
    public sealed partial class PLN21A_M0A : BaseMenu
    {

        private GridHitInfo _downHitInfo = null;

        public PLN21A_M0A()
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
            DataRow linkRow = data as DataRow;
            acLayoutControl1.GetEditor("PROD_LIKE").Value = linkRow["PROD_CODE"];

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("PROD_CODE", typeof(String)); //수주코드/명 LIKE 검색

            DataRow layoutRow = acLayoutControl1.CreateParameterRow();

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["PROD_CODE"] = linkRow["PROD_CODE"];

            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            BizRun.QBizRun.ExecuteService(
             this, QBiz.emExecuteType.LOAD,
             "ORD02A_SER", paramSet, "RQSTDT", "RSLTDT",
             QuickSearch,
             QuickException);
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

            acGridView1.GridType = acGridView.emGridType.SEARCH_SEL;

            DataSet dsModel = BizRun.QBizRun.ExecuteService(this, "ORD02A_MODEL", "RQSTDT", "RSLTDT_T,RSLTDT_M");

            acGridView1.AddLookUpEdit("PROD_STATE", "수주상태", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P012");
            //acGridView1.AddCheckEdit("LOCK_FLAG", "잠금상태", "", false, false, true, acGridView.emCheckEditDataType._BYTE);            
            //acGridView1.AddLookUpEmp("LOCK_EMP", "잠금자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false);
            acGridView1.AddCheckEdit("BOM_FLAG", "BOM ", "", false, false, true, acGridView.emCheckEditDataType._INT);
            acGridView1.AddLookUpEdit("MODEL_TYPE", "모델구분", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "MODEL_CODE","SCODE", dsModel.Tables["RSLTDT_T"]);
            acGridView1.AddLookUpEdit("MODEL_CODE", "세부모델", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "MODEL_CODE", "SCODE", dsModel.Tables["RSLTDT_M"]);
            acGridView1.AddTextEdit("PROD_CODE", "수주번호", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("PROD_NAME", "모델명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("PROD_VERSION", "버전", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddLookUpEdit("PROD_KIND", "제품구분", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "C011");
            acGridView1.AddLookUpEdit("PROC_TYPE", "공정구분", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P017");
            acGridView1.AddLookUpEdit("PROC_FLAG", "공정명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P005");            
            acGridView1.AddLookUpEdit("PROD_FLAG", "유형", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P006");
            acGridView1.AddLookUpEdit("INS_YN", "성적서", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P007");
            //acGridView1.AddLookUpEdit("SOCKET_YN", "소켓측정", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P007");            
            acGridView1.AddCheckedComboBoxEdit("PROD_CATEGORY", "제품유형", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, "P009");
            //acGridView1.AddTextEdit("BUSINESS_EMP", "영업담당자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddLookUpEmp("BUSINESS_EMP", "영업담당자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false);
            acGridView1.AddTextEdit("CUSTOMER_EMP", "고객담당자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            //acGridView1.AddLookUpEmp("CUSTOMER_EMP", "고객담당자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false);
            acGridView1.AddTextEdit("CUSTDESIGN_EMP", "고객설계자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddCheckEdit("REPEAT_STOP", "리핏금지", "", false, false, true, acGridView.emCheckEditDataType._BYTE);
            acGridView1.AddTextEdit("REPEAT_STOP_EMP", "리핏금지자 코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("REPEAT_STOP_EMP_NAME", "리핏금지자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddDateEdit("REPEAT_STOP_DATE", "리핏금지일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);

            acGridView1.AddDateEdit("DESIGN_DATE", "설계완료일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);

            RepositoryItemHyperLinkEdit repItemHLE = new RepositoryItemHyperLinkEdit();
            repItemHLE.NullText = "조회";
            acGridView1.AddCustomEdit("PROD_SPEC", "제작사양조회", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, repItemHLE);
            acGridView1.RowClick += AcGridView1_RowClick;

            //acGridView1.AddLookUpEmp("CUSTDESIGN_EMP", "고객설계자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false);
            acGridView1.AddLookUpEdit("ACTUATOR_YN", "Actuator유무", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "S101");

            //acGridView1.AddTextEdit("CVND_CODE", "발주처코드", "CPW0FS8W", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("CVND_NAME", "발주처", "CPW0FS8W", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            //acGridView1.AddTextEdit("TVND_CODE", "계산서 발행처 코드", "CPW0FS8W", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            //acGridView1.AddTextEdit("TVND_NAME", "계산서 발행처", "CPW0FS8W", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddDateEdit("ORD_DATE", "수주일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
            acGridView1.AddDateEdit("DUE_DATE", "출하예정일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
            acGridView1.AddDateEdit("CHG_DUE_DATE", "출하조정일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
            //acGridView1.AddDateEdit("DELIVERY_DATE", "납품일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);

            acGridView1.AddCheckedComboBoxEdit("PIN_TYPE", "Contact", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, "P011");
            acGridView1.AddLookUpEdit("PROD_TYPE", "제품분류", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P010");
            acGridView1.AddTextEdit("PROD_QTY", "수량", "CPW0FS8W", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NUMERIC);

            acGridView1.AddCheckEdit("EX_BOM", "익스클루드BOM", "", false, false, true, acGridView.emCheckEditDataType._STRING);
            //acGridView1.AddTextEdit("PROD_COST", "공급단가", "CPW0FS8W", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
            //acGridView1.AddTextEdit("PROD_AMT", "총금액", "CPW0FS8W", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
            //acGridView1.AddCheckEdit("ORD_VAT", "VAT별도", "", false, false, true, acGridView.emCheckEditDataType._STRING);
            //acGridView1.AddLookUpEdit("CURR_UNIT", "통화", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P008");

            //acGridView1.AddLookUpEdit("TRADE_YN", "거래명세표", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P007");
            //acGridView1.AddLookUpEdit("TAX_YN", "세금계산서", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P007");
            //acGridView1.AddLookUpEdit("BILL_YN", "수금등록", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P007");

            //acGridView1.AddMemoEdit("REMARK", "특기사항", "", false, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, false, true, true, false);
            //acGridView1.AddMemoEdit("SCOMMENT", "전달사항", "", false, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, false, true, true, false);

            //acGridView1.AddDateEdit("REG_DATE", "최초 등록일", "UL1O77MB", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emDateMask.LONG_DATE);
            //acGridView1.AddTextEdit("REG_EMP", "최초 등록자코드", "P72K0SQJ", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            //acGridView1.AddTextEdit("REG_EMP_NAME", "최초 등록자", "GPQHG8QQ", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            //acGridView1.AddDateEdit("MDFY_DATE", "최근 수정일", "6RXQO0B2", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emDateMask.LONG_DATE);
            //acGridView1.AddTextEdit("MDFY_EMP", "최근 수정자코드", "WDHSCE72", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            //acGridView1.AddTextEdit("MDFY_EMP_NAME", "최근 수정자", "FHJDO4F0", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);

            acGridView1.KeyColumn = new string[] { "PROD_CODE" };

            #region 상세 진행 내역
            acGridView2.GridType = acGridView.emGridType.SEARCH;

            //acGridView2.AddCheckEdit("SEL", "선택", "40290", true, true, true, acGridView.emCheckEditDataType._STRING);            

            acGridView2.AddTextEdit("PT_ID", "품목 ID", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("PROD_CODE", "수주번호", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("PART_CODE", "품목코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("PART_NAME", "품목명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("PART_SPEC", "규격", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            
            acGridView2.AddTextEdit("DRAW_NO", "도면명", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("PRC_PART_QTY", "수량", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NUMERIC);
            acGridView2.AddTextEdit("MATERIAL", "재질", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("SURFACE_TREAT", "표면처리/도장", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("AFTER_TREAT", "후처리", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddCheckEdit("IS_REVISION", "도면변경(리비전)", "", false, false, false, acGridView.emCheckEditDataType._BYTE);
            acGridView2.AddCheckEdit("IS_REMCT", "도면변경(재가공)", "", false, false, true, acGridView.emCheckEditDataType._BYTE);
            acGridView2.AddCheckEdit("IS_MODIFY", "도면변경(현품수정)", "", false, false, true, acGridView.emCheckEditDataType._BYTE);


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


            //acGridView2.AddButtonEdit("DRAW_SER", "도면", "", false, DevExpress.Utils.HorzAlignment.Center, DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor, true, true, false, PLN.Resource.system_search_2x, DevExpress.LookAndFeel.SkinStyle.TheAsphaltWorld);
            //acGridView2.Columns["DRAW_SER"].ColumnEdit.Click += DRAW_SER_Click;

            acGridView2.AddLookUpEdit("MAT_UNIT", "단위", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M003");
            acGridView2.AddLookUpEdit("IS_REWORK", "재작업여부", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "W012");

            //공정 컬럼 생성
            if (acLayoutControl1.ValidCheck() == false)
            {
                return;
            }

            DataRow layoutRow = acLayoutControl1.CreateParameterRow();


            this._dtProcList = ExtensionMethods.GetProcList(this);

            foreach(DataRow row in this._dtProcList.Rows)
            {

                acGridView2.AddTextEdit(row["PROC_CODE"].ToString(), row["PROC_NAME"].ToString(), "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView2.Columns[row["PROC_CODE"].ToString()].Tag = "PROC";
            }

            acGridView2.KeyColumn = new string[] { "PT_ID", "PART_CODE" };
            #endregion


            #region BOM
            acTreeList1.AddTextEdit("PT_ID", "품목 ID", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, acTreeList.emTextEditMask.NONE);
            acTreeList1.AddTextEdit("PROD_CODE", "수주번호", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, acTreeList.emTextEditMask.NONE);
            acTreeList1.AddTextEdit("PART_CODE", "품목코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, acTreeList.emTextEditMask.NONE);
            acTreeList1.AddTextEdit("PART_NAME", "품목명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, acTreeList.emTextEditMask.NONE);
            acTreeList1.AddLookUpEdit("MAT_LTYPE", "대분류", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, "M014", false);


            acTreeList1.AddTextEdit("Material", "재질", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, acTreeList.emTextEditMask.NONE);
            acTreeList1.AddTextEdit("Surface_Treat", "표면처리/도장", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, acTreeList.emTextEditMask.NONE);
            acTreeList1.AddTextEdit("After_Treat", "후처리", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, acTreeList.emTextEditMask.NONE);
            acTreeList1.AddCheckEdit("IS_REVISION", "도면변경(리비전)", "", false, false, false, acTreeList.emCheckEditDataType._BYTE);
            acTreeList1.AddCheckEdit("IS_REMCT", "도면변경(재가공)", "", false, false, true, acTreeList.emCheckEditDataType._BYTE);
            acTreeList1.AddCheckEdit("IS_MODIFY", "도면변경(현품수정)", "", false, false, true, acTreeList.emCheckEditDataType._BYTE);

            acTreeList1.AddTextEdit("MAT_SPEC", "사양", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, acTreeList.emTextEditMask.NONE);
            acTreeList1.AddTextEdit("P_PART_CODE", "모품목코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, acTreeList.emTextEditMask.NONE);
            acTreeList1.AddTextEdit("P_PART_NAME", "모품목명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, acTreeList.emTextEditMask.NONE);
            //acTreeList1.AddTextEdit("PART_QTY", "수량", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, acTreeList.emTextEditMask.QTY);
            acTreeList1.AddTextEdit("BOM_QTY", "소요량", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, acTreeList.emTextEditMask.QTY);
            acTreeList1.AddTextEdit("ORD_QTY", "영업수량", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, acTreeList.emTextEditMask.NONE);
            acTreeList1.AddTextEdit("DATA_FLAG", "삭제여부", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, acTreeList.emTextEditMask.NONE);

            acTreeList1.KeyFieldName = "PT_ID";
            acTreeList1.ParentFieldName = "O_PT_ID";

            acTreeList1.CustomDrawNodeCell += acTreeList1_CustomDrawNodeCell;

            
            #endregion

            //if(acGridView2.Columns["LOAD_FLAG"] is GridColumn gc)
            //{
            //    if(gc.ColumnEdit is DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit rce)
            //    {
            //        rce.ValueChecked = (Byte)0;
            //        rce.ValueUnchecked = (Byte)1;
            //    }
            //}
            acCheckedComboBoxEdit1.AddItem("등록일", false, "", "REG_DATE", true, false);
            acCheckedComboBoxEdit1.AddItem("수주일", false, "", "ORD_DATE", true, false);
            acCheckedComboBoxEdit1.AddItem("출하예정일", false, "", "DUE_DATE", true, false);
            //acCheckedComboBoxEdit1.AddItem("납품일", false, "", "DELIVERY_DATE", true, false);

            this.acLayoutControl1.OnValueKeyDown += new acLayoutControl.ValueKeyDownEventHandler(acLayoutControl1_OnValueKeyDown);
            this.acLayoutControl1.OnValueChanged += new acLayoutControl.ValueChangedEventHandler(acLayoutControl1_OnValueChanged);

            this.acGridView1.CustomDrawCell += AcGridView1_CustomDrawCell;
            this.acGridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(acGridView1_FocusedRowChanged);
            //this.acGridView1.MouseDown += new MouseEventHandler(acGridView1_MouseDown);
            //this.acGridView1.ShowGridMenuEx += new acGridView.ShowGridMenuExHandler(acGridView1_ShowGridMenuEx);
            this.acGridView1.OnMapingRowChanged += new acGridView.MapingRowChangedEventHandler(acGridView1_OnMapingRowChanged);

            //this.acGridView2.MouseDown += new MouseEventHandler(acGridView2_MouseDown);
            //this.acGridView2.MouseMove += AcGridView2_MouseMove;
            //this.acGridView2.EndSorting += AcGridView2_EndSorting;
            this.acGridView2.ShowGridMenuEx += new acGridView.ShowGridMenuExHandler(acGridView2_ShowGridMenuEx);
            //this.acGridView2.OnMapingRowChanged += new acGridView.MapingRowChangedEventHandler(acGridView2_OnMapingRowChanged);
            //this.acGridView2.CellValueChanged += acGridView2_CellValueChanged;
            this.acGridView2.CustomDrawCell += acGridView2_CustomDrawCell;
            //this.acGridView2.RowCellStyle += acGridView2_RowCellStyle;
            //this.acGridView2.Layout += AcGridView2_Layout;
            //acGridControl2.DragOver += AcGridControl2_DragOver;
            //acGridControl2.DragDrop += AcGridControl2_DragDrop;
            //acGridControl2.DragEnter += AcGridControl2_DragEnter;
            //acGridControl2.DragLeave += AcGridControl2_DragLeave;
            //acGridControl2.GiveFeedback += AcGridControl2_GiveFeedback;
            acGridView2.CustomRowCellEdit += acGridView2_CustomRowCellEdit;

            acTreeList1.MouseDown += acTreeList1_MouseDown;


            _WAIT = acInfo.SysConfig.GetSysConfigByServer("MC_OPERATE_CLR_WAIT").toColor();
            _RUN = acInfo.SysConfig.GetSysConfigByServer("MC_OPERATE_CLR_RUN").toColor();
            _PAUSE = acInfo.SysConfig.GetSysConfigByServer("MC_OPERATE_CLR_PAUSE").toColor();
            _FINISH = acInfo.SysConfig.GetSysConfigByServer("MC_OPERATE_CLR_FINISH").toColor();

            txtWait.BackColor = acInfo.SysConfig.GetSysConfigByServer("MC_OPERATE_CLR_WAIT").toColor();
            txtRun.BackColor = acInfo.SysConfig.GetSysConfigByServer("MC_OPERATE_CLR_RUN").toColor();
            txtFinish.BackColor = acInfo.SysConfig.GetSysConfigByServer("MC_OPERATE_CLR_FINISH").toColor();

            _dicProcStat = new Dictionary<string, string>();

            base.MenuInit();
        }

        private void acTreeList1_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                acTreeList view = sender as acTreeList;

                if (e.Button == MouseButtons.Right)
                {
                    TreeListHitInfo hitInfo = view.CalcHitInfo(e.Location);

                    if (hitInfo.HitInfoType == HitInfoType.Cell)
                    {
                        if (hitInfo.Node != null)
                        {

                            popupMenu3.ShowPopup(acTreeList1.PointToScreen(e.Location));

                        }
                    }
                }
            }
            catch { }
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
                    
                    if(rows.Length == 0)
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

        private void acTreeList1_CustomDrawNodeCell(object sender, DevExpress.XtraTreeList.CustomDrawNodeCellEventArgs e)
        {
            
            TreeListNode node = e.Node;

            if (node["DATA_FLAG"].ToString() == "2")
            {
                e.Appearance.BackColor = Color.OrangeRed;
                e.Appearance.ForeColor = Color.White;
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
                    else if (row["EX_BOM"].ToString() == "1")
                    {
                        e.Appearance.BackColor = Color.AliceBlue;
                        e.Appearance.ForeColor = Color.Black;
                    }
                }
            }
            catch
            {

            }
        }
        #region 주석
        //private void AcGridControl2_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        //{
        //    e.UseDefaultCursors = false;
        //}

        //private void AcGridControl2_DragLeave(object sender, EventArgs e)
        //{
        //    this.Cursor = Cursors.Default;
        //}

        //private void AcGridView2_Layout(object sender, EventArgs e)
        //{
        //    if(sender is GridView gv)
        //    {
        //        //if(gv.SortedColumns.Count ==0)
        //        //{
        //        //    gv.Columns["PROD_SEQ"].SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
        //        //}
        //    }
        //}

        //private void AcGridView2_EndSorting(object sender, EventArgs e)
        //{
        //    if (sender is GridView gv)
        //    {
        //        try
        //        {
        //            if (gv.SortedColumns.Count == 1
        //                && gv.SortedColumns.FirstOrDefault().FieldName.Equals("PROD_SEQ"))
        //            {
        //                for (int rowIndex = 0; rowIndex < ((DataView)this.acGridView2.DataSource).Count; rowIndex++)
        //                {
        //                    if (gv != null)
        //                    {
        //                        DataRowView drv = (gv.DataSource as System.Data.DataView)[rowIndex];
        //                        if (!drv.isNullOrEmpty())
        //                        {
        //                            int rowHandle = gv.GetRowHandle(rowIndex);
        //                            drv["PROD_SEQ"] = rowHandle + 1;
        //                        }
        //                    }
        //                }
        //            }
        //        }catch
        //        {

        //        }
        //    }
        //}

        //private void AcGridView2_MouseMove(object sender, MouseEventArgs e)
        //{
        //    GridView view = sender as GridView;
        //    if (e.Button == MouseButtons.Left && _downHitInfo != null)
        //    {
        //        Size dragSize = SystemInformation.DragSize;
        //        Rectangle dragRect = new Rectangle(new Point(_downHitInfo.HitPoint.X - dragSize.Width / 2,
        //            _downHitInfo.HitPoint.Y - dragSize.Height / 2), dragSize);

        //        if (!dragRect.Contains(new Point(e.X, e.Y)))
        //        {
        //            if (view != null) view.GridControl.DoDragDrop(_downHitInfo, DragDropEffects.All);
        //            _downHitInfo = null;
        //            DevExpress.Utils.DXMouseEventArgs.GetMouseArgs(e).Handled = true;
        //        }
        //    }
        //}

        //private void AcGridControl2_DragEnter(object sender, DragEventArgs e)
        //{
        //    if (e.Data.GetDataPresent(DataFormats.FileDrop))
        //    {
        //        e.Effect = DragDropEffects.All;
        //    }
        //    else
        //    {
        //        e.Effect = DragDropEffects.None;
        //    }
        //}

        //private void AcGridControl2_DragDrop(object sender, DragEventArgs e)
        //{
        //    try
        //    {
        //        this.Cursor = Cursors.Default;
        //        //string[] dataFormats = e.Data.GetFormats();

        //        //if (dataFormats.Any())
        //        //{
        //        if (e.Data.GetDataPresent(typeof(GridHitInfo)))
        //            {
        //                //그리드 로우 순서 변경

        //                GridControl grid = (GridControl)sender;

        //                if (grid != null)
        //                {
        //                    acGridView view = grid.MainView as acGridView;
        //                    view.EndEditor();
        //                    //ClearSorting(FileGridView);
        //                    GridHitInfo srcHitInfo = e.Data.GetData(typeof(GridHitInfo)) as GridHitInfo;
        //                    if (view != null)
        //                    {
        //                        GridHitInfo hitInfo = view.CalcHitInfo(grid.PointToClient(new Point(e.X, e.Y)));
        //                        if (srcHitInfo != null)
        //                        {
        //                            int sourceRow = srcHitInfo.RowHandle;
        //                            int targetRow = hitInfo.RowHandle;
        //                            MoveRow(acGridView2, sourceRow, targetRow);
        //                            SetRowSeqAfterSort(acGridView2);
        //                        }
        //                    }
        //                }
        //            }
        //      //  }
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //}

        //private void AcGridControl2_DragOver(object sender, DragEventArgs e)
        //{
        //    if (e.Data.GetDataPresent(typeof(GridHitInfo)))
        //    {
        //        GridHitInfo downHitInfo = e.Data.GetData(typeof(GridHitInfo)) as GridHitInfo;
        //        if (downHitInfo == null)
        //            return;

        //        if (sender is GridControl)
        //        {
        //            acGridControl grid = sender as acGridControl;
        //            if (grid.MainView is GridView)
        //            {
        //                acGridView view = grid.MainView as acGridView;
        //                GridHitInfo hitInfo = view.CalcHitInfo(grid.PointToClient(new Point(e.X, e.Y)));
        //                if (hitInfo.InRow && hitInfo.RowHandle != downHitInfo.RowHandle && hitInfo.RowHandle != GridControl.NewItemRowHandle)
        //                {
        //                    e.Effect = DragDropEffects.Move;
        //                    this.Cursor = acGraphics.CreateCursor(view.GetFocusRowImage(acGridView.emFocusRowImageType.MOVE), 0, 0);
        //                }
        //                else
        //                    e.Effect = DragDropEffects.None;

        //            }
        //        }
        //    }
        //}
        #endregion

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



        private void AcGridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo hi = (sender as GridView).CalcHitInfo(new Point(e.X, e.Y));

            if (hi.Column != null && hi.Column.FieldName == "PROD_SPEC" && hi.InDataRow)
            {
                try
                {
                    DataRow focusRow = acGridView1.GetFocusedDataRow();

                    if (focusRow != null)
                    {
                        if (!base.ChildFormContains("NEW_ITEM"))
                        {
                            PopSpec frm = new PopSpec(focusRow);
                            frm.DialogMode = BaseMenuDialog.emDialogMode.NEW;
                            frm.ParentControl = this;
                            
                            base.ChildFormAdd("NEW_ITEM", frm);
                            frm.Show(this);
                            focusRow = null;
                        }
                        else
                        {
                            base.ChildFormFocus("NEW_ITEM");
                        }
                    }
                }
                catch (Exception ex)
                {
                    acMessageBox.Show(this, ex);
                }

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
        
        void acGridView2_ShowGridMenuEx(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {

            //마스터 Row가 존재해야 팝업창을 연다.

            if (acGridView1.FocusedRowHandle < 0)
            {
                return;
            }


            acGridView view = sender as acGridView;



            if (e.MenuType == GridMenuType.User)
            {
                acBarSubItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                acBarSubItem3.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                acBarButtonItem5.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                acBarButtonItem6.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
              
            }
            else if (e.MenuType == GridMenuType.Row)
            {
                if (e.HitInfo.RowHandle >= 0)
                {
                    acBarSubItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    acBarSubItem3.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    acBarButtonItem5.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    acBarButtonItem6.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

                }
                else
                {
                    acBarSubItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    acBarSubItem3.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    acBarButtonItem5.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    acBarButtonItem6.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                   

                }

            }


            if (e.HitInfo.HitTest == GridHitTest.Row || e.HitInfo.HitTest == GridHitTest.RowCell)
            {

                GridHitInfo hitInfo = view.CalcHitInfo(e.Point);

                popupMenu2.ShowPopup(view.GridControl.PointToScreen(e.Point));

            }


        }

        void acGridView2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                GridHitInfo hitInfo = acGridView2.CalcHitInfo(e.Location);

                if (hitInfo.HitTest == GridHitTest.RowCell || hitInfo.HitTest == GridHitTest.Row)
                {
                    //수주 편집기 열기
                    this.acBarButtonItem5_ItemClick(null, null);
                }
            }
            else if(e.Button == MouseButtons.Left)
            {
                GridView view = sender as GridView;
                _downHitInfo = null;

                if (view != null)
                {
                    GridHitInfo hitInfo = view.CalcHitInfo(new Point(e.X, e.Y));
                    if (Control.ModifierKeys != Keys.None)
                        return;
                    if (e.Button == MouseButtons.Left && hitInfo.InRow && hitInfo.RowHandle != GridControl.NewItemRowHandle)
                        _downHitInfo = hitInfo;
                }
            }

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



        //void GetFile(DataRow focusRow, string Type)
        //{
        //    try
        //    {
        //        DataTable paramTable = new DataTable("RQSTDT");
        //        paramTable.Columns.Add("PLT_CODE", typeof(String)); //
        //        paramTable.Columns.Add("PART_CODE", typeof(String)); //
        //        paramTable.Columns.Add("FILE_TYPE", typeof(String)); //

        //        DataRow paramRow = paramTable.NewRow();
        //        paramRow["PLT_CODE"] = acInfo.PLT_CODE;
        //        paramRow["PART_CODE"] = focusRow["PART_CODE"];
        //        paramRow["FILE_TYPE"] = Type;

        //        paramTable.Rows.Add(paramRow);
        //        DataSet paramSet = new DataSet();
        //        paramSet.Tables.Add(paramTable);

        //        //도면 조회
        //        DataSet dsRslt = BizRun.QBizRun.ExecuteService(this, "POP02A_SER2", paramSet, "RQSTDT", "RSLTDT");

        //        if (dsRslt.Tables["RSLTDT"].Rows.Count == 0)
        //        {

        //            if (focusRow["PART_CODE"].ToString().Substring(0, 1) == "A")
        //            {
        //                string p = acInfo.SysConfig.GetSysConfigByMemory("NEW_DRAW_FILE_DIR");
        //                string i = acInfo.SysConfig.GetSysConfigByMemory("NEW_DRAW_FILE_DIR_ID");
        //                string pas = acInfo.SysConfig.GetSysConfigByMemory("NEW_DRAW_FILE_DIR_PW");

        //                IFModule iFModule = new IFModule(p, i, pas);

        //                int ret = iFModule.NetWorkAccess();

        //                if (System.IO.Directory.Exists(p + @"\" + focusRow["PART_CODE"].ToString()))
        //                {
        //                    FileInfo fileInfo = new FileInfo(p + @"\" + focusRow["PART_CODE"].ToString() + @"\" + focusRow["PART_CODE"].ToString() + "." + Type);

        //                    if (fileInfo.Exists)
        //                    {
        //                        System.Diagnostics.Process.Start(p + @"\" + focusRow["PART_CODE"].ToString() + @"\" + focusRow["PART_CODE"].ToString() + "." + Type);
        //                    }
        //                }
        //            }

        //            acAlert.Show(this, "파일이 존재하지 않습니다.", acAlertForm.enmType.Warning);
        //            return;
        //        }


        //        //if (dsRslt.Tables["RSLTDT"].Rows.Count == 0)
        //        //    acAlert.Show(this, "등록된 도면이 없습니다.", acAlertForm.enmType.Info);
        //        //else if ((dsRslt.Tables["RSLTDT"].Rows.Count > 1))
        //        //{
        //        //    PopDraw frm = new PopDraw(dsRslt.Tables["RSLTDT"]);

        //        //    frm.Text = string.Format("도면파일리스트 - {0}({1})", focusRow["PART_NAME"], focusRow["PART_CODE"]);

        //        //    frm.DialogMode = BaseMenuDialog.emDialogMode.OPEN;

        //        //    frm.ParentControl = this;

        //        //    base.ChildFormAdd("DRAW", frm);

        //        //    frm.ShowDialog(this);
        //        //}
        //        //else
        //        //{
        //        string path = acInfo.SysConfig.GetSysConfigByMemory("DRAW_FILE_DIR");
        //        string id = acInfo.SysConfig.GetSysConfigByMemory("DRAW_FILE_DIR_ID");
        //        string pass = acInfo.SysConfig.GetSysConfigByMemory("DRAW_FILE_DIR_PW");
        //        string removePath = acInfo.SysConfig.GetSysConfigByMemory("DRAW_FILE_REMOVE_DIR");
        //        string strFileFullPath = "";
        //        string strFileFullName = "";

        //        if (dsRslt.Tables["RSLTDT"].Columns.Contains("FILE_ID"))
        //        {
        //            string fileDir = string.Format(@"{0}\{1}", acInfo.GetTempSystemDirectory(), dsRslt.Tables["RSLTDT"].Rows[0]["FILE_ID"]);

        //            if (!Directory.Exists(fileDir))
        //            {
        //                Directory.CreateDirectory(fileDir);
        //            }


        //            acFTP acFtp1 = new acFTP();
        //            acFtp1.Server = acInfo.SysConfig.GetSysConfigByServer("FTP_ADDRESS");
        //            acFtp1.ServerPort = acInfo.SysConfig.GetSysConfigByServer("FTP_PORT").toInt();
        //            acFtp1.Username = acInfo.SysConfig.GetSysConfigByServer("FTP_USERID");
        //            acFtp1.Password = acInfo.SysConfig.GetSysConfigByServer("FTP_PASSWORD");

        //            acFtp1.FileType = FileType.Image;
        //            acFtp1.DoEvents = true;
        //            acFtp1.Passive = true;
        //            acFtp1.Restart = false;

        //            string dir = "";

        //            string orginfilename = "";
        //            string filename = "";
        //            string fileID = "";
        //            foreach (DataRow row in dsRslt.Tables["RSLTDT"].Rows)
        //            {

        //                string fileName = string.Format(@"{0}\{1}", fileDir, row["FILE_NAME"]);

        //                dir = row["REG_DATE"].ToString().Substring(0, 10);

        //                orginfilename = row["FILE_NAME"].ToString();
        //                filename = row["FILE_ID"].ToString() + getExtName(dsRslt.Tables["RSLTDT"].Rows[0]["FILE_NAME"].ToString());
        //                fileID = row["FILE_ID"].ToString();

        //                FtpFile ftpResult = acFtp1.Get(string.Format(@"{0}\{1}\{2}", acInfo.PLT_CODE, dir, filename), fileName);


        //                System.Diagnostics.Process.Start(ftpResult.LocalFileName);
        //            }

        //            acFtp1.Close();
        //            acFtp1 = null;
        //        }
        //        else
        //        {
        //            if (dsRslt.Tables["RSLTDT"].Rows[0]["PART_FILE_PATH"].ToString().Contains("192.168.10.6"))
        //            {
        //                strFileFullPath = dsRslt.Tables["RSLTDT"].Rows[0]["PART_PATH"].ToString(); ;
        //                strFileFullName = dsRslt.Tables["RSLTDT"].Rows[0]["PART_FILE_PATH"].ToString();

        //                path = acInfo.SysConfig.GetSysConfigByMemory("NEW_DRAW_FILE_DIR");
        //                id = acInfo.SysConfig.GetSysConfigByMemory("NEW_DRAW_FILE_DIR_ID");
        //                pass = acInfo.SysConfig.GetSysConfigByMemory("NEW_DRAW_FILE_DIR_PW");
        //            }
        //            else
        //            {
        //                int iSeq = dsRslt.Tables["RSLTDT"].Rows[0]["PART_FILE_PATH"].ToString().IndexOf(removePath) + removePath.Length;

        //                string replacePath = dsRslt.Tables["RSLTDT"].Rows[0]["PART_FILE_PATH"].ToString().Substring(iSeq, dsRslt.Tables["RSLTDT"].Rows[0]["PART_FILE_PATH"].ToString().Length - iSeq);

        //                string fullPath = path + replacePath;


        //                strFileFullPath = path;
        //                strFileFullName = fullPath;
        //            }


        //            IFModule iFModule = new IFModule(path, id, pass);

        //            int ret = iFModule.NetWorkAccess();

        //            bool isExists = true;

        //            if (System.IO.Directory.Exists(strFileFullPath))
        //            {
        //                FileInfo fileInfo = new FileInfo(strFileFullName);

        //                if (fileInfo.Exists)
        //                {
        //                    System.Diagnostics.Process.Start(strFileFullName);
        //                }
        //                else
        //                {
        //                    isExists = false;
        //                }
        //            }
        //            else
        //            {
        //                isExists = false;
        //            }

        //            if (!isExists)
        //            {
        //                acAlert.Show(this, "파일이 존재하지 않습니다.", acAlertForm.enmType.Warning);
        //            }
        //        }
                


        //    }
        //    catch (Exception ex)
        //    {
        //        acMessageBox.Show(this, ex);
        //    }
        //}

        //string getExtName(string filename)
        //{

        //    string[] str = filename.Split('.');

        //    if (str.Length > 1)
        //    {
        //        string extname = str[str.Length - 1];
        //        return "." + extname;
        //    }
        //    else
        //    {
        //        return "";
        //    }
        //}


        void acGridView1_ShowGridMenuEx(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            acGridView view = sender as acGridView;

            if (e.MenuType == GridMenuType.User)
            {
                acBarButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                acBarButtonItem3.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;


            }
            else if (e.MenuType == GridMenuType.Row)
            {
                if (e.HitInfo.RowHandle >= 0)
                {
                    acBarButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    acBarButtonItem3.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                }
                else
                {
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

        void acGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                GridHitInfo hitInfo = acGridView1.CalcHitInfo(e.Location);

                if (hitInfo.HitTest == GridHitTest.RowCell || hitInfo.HitTest == GridHitTest.Row)
                {
                    //수주 편집기 열기

                    this.acBarButtonItem2_ItemClick(null, null);
                }

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
                acTreeList1.ClearNodes();
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

            DataRow layoutRow = acLayoutControl1.CreateParameterRow();

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["PROD_LIKE"] = layoutRow["PROD_LIKE"];
            paramRow["CVND_LIKE"] = layoutRow["CVND_LIKE"];
            paramRow["BUSINESS_EMP"] = layoutRow["BUSINESS_EMP"];


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
             "ORD02A_SER", paramSet, "RQSTDT", "RSLTDT",
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
            if (data.EqualsEx("ITEM"))
            {
                if (base.IsData(data))
                {
                    DataSet refreshSet = base.GetData(data) as DataSet;

                    refreshSet.Tables.Remove("RSLTDT");

                    BizRun.QBizRun.ExecuteService(
                 this, QBiz.emExecuteType.REFRESH,
                 "ORD02A_SER", refreshSet, "RQSTDT", "RSLTDT",
                 QuickSearch,
                 QuickException);

                }

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




        void QuickSearch(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                base.SetData("PROD", e.result);


                acGridView1.GridControl.DataSource = e.result.Tables["RSLTDT"];

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

        DataTable _dwgFileDT = new DataTable();

        bool isOldFocus = false;
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

                foreach(DataRow row in e.result.Tables["RSLTDT_WO"].Rows)
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
                    switch(row["WO_FLAG"].ToString())
                    {
                        case "0":
                        case "1":
                            dataRows[0][row["PROC_CODE"].ToString()] = row["PLN_START_TIME"].toDateString("MM/dd");
                            break;
                        case "2":
                        case "3":
                            dataRows[0][row["PROC_CODE"].ToString()] = row["ACT_START_TIME"].toDateString("MM/dd");
                            break;
                        case "4":
                            dataRows[0][row["PROC_CODE"].ToString()] = row["ACT_END_TIME"].toDateString("MM/dd");
                            break;
                    }


                    dataRows[0]["PRC_PART_QTY"] = row["PART_QTY"];

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

                if (isOldFocus)
                {
                    acGridView2.SetOldFocusRowHandle(false);
                    isOldFocus = false;
                }

                //DataRow[] rows = e.result.Tables["RSLTDT_BOM"].Select("O_PT_ID IS NULL OR O_PT_ID = ''");

                //if (rows.Length > 0)
                //{
                //    _dwgFileDT = CodeHelperManager.acOpenDrawFile.GetFileExists(rows[0]["PART_CODE"].ToString());
                //}
                //else
                //{
                //    _dwgFileDT = CodeHelperManager.acOpenDrawFile.GetFileExists();
                //}

                _dwgFileDT = CodeHelperManager.acOpenDrawFile.GetFileExists();

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
            //새로만들기 수주 편집기
            try
            {
                //if (!base.ChildFormContains("NEW_ITEM"))
                //{
                //    ORD02A_D1A frm = new ORD02A_D1A(acGridView1, "NEW_ITEM");

                //    frm.DialogMode = BaseMenuDialog.emDialogMode.NEW;

                //    frm.ParentControl = this;

                //    base.ChildFormAdd("NEW_ITEM", frm);

                //    frm.Show(this);


                //}
                //else
                //{
                //    base.ChildFormFocus("NEW_ITEM");
                //}
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }



        private void acBarButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //열기 수주편집기

            try
            {
                if (acGridView1.ValidFocusRowHandle() == false)
                {
                    return;
                }


                DataRow focusRow = acGridView1.GetFocusedDataRow();


                string formKey = string.Format("{0},{1}", "PROD", focusRow["PROD_CODE"]);

                //if (!base.ChildFormContains(formKey))
                //{

                //    ORD02A_D1A frm = new ORD02A_D1A(acGridView1, focusRow);

                //    frm.DialogMode = BaseMenuDialog.emDialogMode.OPEN;

                //    frm.ParentControl = this;

                //    base.ChildFormAdd(formKey, frm);

                //    frm.Show(this);

                //}
                //else
                //{
                //    base.ChildFormFocus(formKey);

                //}
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }



        }


        private void acBarButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //수주 삭제
            try
            {
                acGridView1.EndEditor();


                if (acMessageBox.Show(this, "정말 삭제하시겠습니까?", "TB43FSY3", true, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
                {
                    return;
                }

                DataRow[] selected = acGridView1.GetSelectedDataRows();



                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("DEL_EMP", typeof(String)); //
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("PROD_CODE", typeof(String)); //                

                if (selected.Length == 0)
                {
                    //단일삭제

                    DataRow focusRow = acGridView1.GetFocusedDataRow();

                    DataRow paramRow = paramTable.NewRow();
                    paramRow["DEL_EMP"] = acInfo.UserID;
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
                        paramRow["DEL_EMP"] = acInfo.UserID;
                        paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                        paramRow["PROD_CODE"] = row["PROD_CODE"];
                        paramTable.Rows.Add(paramRow);

                    }


                }


                DataSet paramSet = new DataSet();

                paramSet.Tables.Add(paramTable);


                BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.DEL,
                "ORD02A_DEL", paramSet, "RQSTDT", "RSLTDT",
                QuickDEL,
                QuickException);


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

                //수주 삭제후

                foreach (DataRow row in e.result.Tables["RQSTDT"].Rows)
                {
                    acGridView1.DeleteMappingRow(row);

                }

                acAlert.Show(this, "삭제 되었습니다.", acAlertForm.enmType.Success);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }


        }

        private void acBarButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //새로만들기 금형편집기
            try
            {
                if (!base.ChildFormContains("NEW_PROD"))
                {
                    //ORD02A_D2A frm = new ORD02A_D2A(acGridView1, acGridView1.GetFocusedDataRow(), acGridView2, null);

                    //frm.DialogMode = BaseMenuDialog.emDialogMode.NEW;

                    //frm.ParentControl = this;

                    //base.ChildFormAdd("NEW_PROD", frm);

                    //frm.Show(this);


                }
                else
                {
                    base.ChildFormFocus("NEW_PROD");
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }


        }

        private void acBarButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                DataRow focusRow = acGridView2.GetFocusedDataRow();


                if (focusRow == null)
                {
                    return;
                }

                string formKey = string.Format("{0},{1}", "PROD", focusRow["PT_ID"]);

                if (!base.ChildFormContains(formKey))
                {
                    PLN21A_D1A frm = new PLN21A_D1A(acGridView2, focusRow);
                    frm.ParentControl = this;
                    frm.DialogMode = BaseMenuDialog.emDialogMode.OPEN;

                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        //int rowHandle = acGridView2.FocusedRowHandle;
                        acGridView1.RaiseFocusedRowChanged();
                        isOldFocus = true;
                    }
                }
                else
                {
                    base.ChildFormFocus(formKey);

                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }


        }

        private void acBarButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //금형 삭제
            try
            {
                acGridView1.EndEditor();


                if (acMessageBox.Show(this, "정말 삭제하시겠습니까?", "TB43FSY3", true, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
                {
                    return;
                }

                DataRow[] selected = acGridView1.GetSelectedDataRows();



                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("DEL_EMP", typeof(String)); //
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("PROD_CODE", typeof(String)); //                

                if (selected.Length == 0)
                {
                    //단일삭제

                    DataRow focusRow = acGridView1.GetFocusedDataRow();

                    DataRow paramRow = paramTable.NewRow();
                    paramRow["DEL_EMP"] = acInfo.UserID;
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
                        paramRow["DEL_EMP"] = acInfo.UserID;
                        paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                        paramRow["PROD_CODE"] = row["PROD_CODE"];
                        paramTable.Rows.Add(paramRow);

                    }


                }


                DataSet paramSet = new DataSet();

                paramSet.Tables.Add(paramTable);


                BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.DEL,
                "ORD06A_DEL", paramSet, "RQSTDT", "RSLTDT",
                QuickDEL,
                QuickException);


            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        void QuickDEL2(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {

            try
            {
                //금형 삭제후


                foreach (DataRow row in e.result.Tables["RQSTDT"].Rows)
                {
                    acGridView2.DeleteMappingRow(row);
                }

                //수주결과값 갱신
                if (e.result.Tables.Contains("ITEM"))
                {
                    foreach (DataRow row in e.result.Tables["ITEM"].Rows)
                    {
                        acGridView1.UpdateMapingRow(row, true);
                    }
                }
                    

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }



        }

        private void acBarButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //중단 기능
            try
            {
                acGridView2.EndEditor();


                if (acMessageBox.Show(this, "정말 중단하시겠습니까? 모든 관련 작업지시가 삭제됩니다.", "P439UE1Q", true, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
                {
                    return;
                }

                DataView selected = acGridView2.GetDataSourceView("SEL = '1'");



                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("REG_EMP", typeof(String)); //
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("PROD_CODE", typeof(String)); //


                if (selected.Count == 0)
                {
                 

                    DataRow focusRow = acGridView2.GetFocusedDataRow();

                    DataRow paramRow = paramTable.NewRow();
                    paramRow["REG_EMP"] = acInfo.UserID;
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["PROD_CODE"] = focusRow["PROD_CODE"];
                    paramTable.Rows.Add(paramRow);


                }
                else
                {

                    for (int i = 0; i < selected.Count; i++)
                    {

                        DataRow paramRow = paramTable.NewRow();
                        paramRow["REG_EMP"] = acInfo.UserID;
                        paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                        paramRow["PROD_CODE"] = selected[i]["PROD_CODE"];
                        paramTable.Rows.Add(paramRow);

                    }


                }


                DataSet paramSet = new DataSet();

                paramSet.Tables.Add(paramTable);


                BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.DEL,
                "ORD02A_UPD", paramSet, "RQSTDT", "WORKORDER,RSLTDT",
                QuickUPD,
                QuickException);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }


        void QuickUPD(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {

            try
            {
                //금형 중단후



                if (e.result.Tables["WORKORDER"].Rows.Count != 0)
                {
                    //진행중인 작업지시가 있는지 확인한다.

                    acMessageBoxGridConfirm frm = new acMessageBoxGridConfirm(this, "acMessageBoxGridConfirm1", "진행중인 작업지시가 존재하여 처리할수없습니다. 중지후 다시 시도하시기 바랍니다.", "O9OQ5CD1", true, this.Parent.Text, e.result.Tables["WORKORDER"]);

                    frm.View.GridType = acGridView.emGridType.SEARCH;

                    frm.View.AddLookUpEdit("WO_FLAG", "상태", "40278", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "S032");

                    frm.View.AddLookUpEdit("WO_TYPE", "작업지시 형태", "BPIJ8QTW", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "S037");

                    frm.View.AddTextEdit("WO_NO", "작업지시번호", "40556", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);


                    frm.View.AddTextEdit("PROD_CODE", "금형코드", "40900", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

                    frm.View.AddTextEdit("PROD_NAME", "금형명", "40901", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

                    frm.View.AddTextEdit("PART_CODE", "부품코드", "40239", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

                    frm.View.AddTextEdit("PART_NAME", "부품명", "40234", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

                    frm.View.AddTextEdit("PART_NUM", "품번", "40743", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

                    frm.View.AddTextEdit("PROC_CODE", "공정코드", "40920", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

                    frm.View.AddTextEdit("PROC_NAME", "공정명", "40921", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

                    frm.View.AddTextEdit("MC_CODE", "설비코드", "41162", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

                    frm.View.AddTextEdit("MC_NAME", "설비명", "41202", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

                    frm.View.AddTextEdit("EMP_NAME", "담당자", "40127", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);


                    frm.ShowDialog();

                }
                else
                {

                    //업데이트
                    foreach (DataRow row in e.result.Tables["RSLTDT"].Rows)
                    {
                        acGridView2.UpdateMapingRow(row, true);
                    }

                    acAlert.Show(this, "중단 되었습니다.", acAlertForm.enmType.Success);
                }

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

        private void btnMultiAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            acPartForm frmPart = new acPartForm();

            frmPart.ParentControl = this;

            frmPart.SelectType = acPart.emSelectType.MULTI;

            if (frmPart.ShowDialog() == DialogResult.OK)
            {
                DataTable result = (DataTable)frmPart.OutputData;

                if(!result.Columns.Contains(""))
                {
                    result.Columns.Add("TARGET_DUE_DATE");
                }

                DataRow prodInfo = acGridView1.GetFocusedDataRow();

                foreach (DataRow row in result.Rows)
                {
                    DataRow newRow = acGridView2.NewRow();

                    newRow["SEL"] = "1";
                    newRow["MAT_TYPE"] = row["MAT_TYPE"];

                    newRow["PROD_CODE"] = acGridView2.RowCount; //row["MAT_TYPE"];
                    
                    newRow["PART_CODE"] = row["PART_CODE"];
                    newRow["DRAW_NO"] = row["DRAW_NO"];
                    newRow["PART_NAME"] = row["PART_NAME"];
                    newRow["PROD_STATE"] = "WT";
                    newRow["DUE_DATE"] = prodInfo["DUE_DATE"];
                    newRow["TARGET_DUE_DATE"] = prodInfo["DUE_DATE"].toDateTime().AddDays(-3);
                    newRow["MAT_SPEC1"] = row["MAT_SPEC1"];
                    newRow["MAT_SPEC"] = row["MAT_SPEC"];
                    newRow["PROD_QTY"] = 0;
                    newRow["MAT_UNIT"] = row["MAT_UNIT"];
                    newRow["PROD_UC"] = 0;
                    newRow["PROD_COST"] = 0;
                    newRow["PROD_VAT"] = 0;
                    newRow["PROD_AMT"] = 0;
                    newRow["SCOMMENT"] = "";
                    newRow["REG_DATE"] = DateTime.Now;
                    newRow["REG_EMP"] = acInfo.UserID;
                    newRow["REG_EMP_NAME"] = acInfo.UserName;
                    newRow["NEW"] = "NEW";

                    acGridView2.AddRow(newRow);
                    
                }
                
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
                    e.Appearance.BackColor = e.Appearance.BackColor;
            }
        }


        void acGridView2_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            double amt = 0, d_vat = 0;
            DataRow prodInfo = acGridView1.GetFocusedDataRow();
            DataRow row = acGridView2.GetFocusedDataRow();

            if (prodInfo == null) return;

            bool bVat = prodInfo["ORD_VAT"].ToString() == "1" ? true : false;

            switch (e.Column.FieldName)
            {

                case "PROD_QTY":

                    amt = e.Value.toDouble() * row["PROD_UC"].toDouble();
                    d_vat = amt * 0.1;

                    acGridView2.SetRowCellValue(e.RowHandle, acGridView2.Columns["PROD_COST"], amt);
                    if (bVat)
                    {

                        acGridView2.SetRowCellValue(e.RowHandle, acGridView2.Columns["PROD_VAT"], d_vat);
                        acGridView2.SetRowCellValue(e.RowHandle, acGridView2.Columns["PROD_AMT"], amt + d_vat);
                    }
                    else
                        acGridView2.SetRowCellValue(e.RowHandle, acGridView2.Columns["PROD_AMT"], amt);


                    break;
                case "PROD_UC":
                    
                    amt = e.Value.toDouble() * row["PROD_QTY"].toDouble();
                    d_vat = amt * 0.1;

                    acGridView2.SetRowCellValue(e.RowHandle, acGridView2.Columns["PROD_COST"], amt);
                    //acGridView2.SetRowCellValue(e.RowHandle, acGridView2.Columns["PROD_AMT"], amt);

                    if (bVat)
                    {
                        acGridView2.SetRowCellValue(e.RowHandle, acGridView2.Columns["PROD_VAT"], d_vat);
                        acGridView2.SetRowCellValue(e.RowHandle, acGridView2.Columns["PROD_AMT"], amt + d_vat);
                    }
                    else
                        acGridView2.SetRowCellValue(e.RowHandle, acGridView2.Columns["PROD_AMT"], amt);

                    break;

            }

        }

        void acGridView2_OnMapingRowChanged(acGridView.emMappingRowChangedType type, DataRow row)
        {
            if (type == acGridView.emMappingRowChangedType.DELETE)
            {
                string formKey = string.Format("{0},{1}", "PROD", row["PROD_CODE"]);

                base.ChildFormRemove(formKey);
            }
        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            acGridView2.EndEditor();

            DataRow masterRow  = acGridView1.GetFocusedDataRow();

            if (masterRow == null ) return;

            DataTable paramTable1 = new DataTable("RQSTDT");
            paramTable1.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable1.Columns.Add("PROD_CODE", typeof(String)); //
            paramTable1.Columns.Add("PART_CODE", typeof(String)); //
            paramTable1.Columns.Add("PART_NAME", typeof(String)); //
            paramTable1.Columns.Add("ITEM_CODE", typeof(String)); //
            paramTable1.Columns.Add("ORD_DATE", typeof(String)); //
            paramTable1.Columns.Add("INDUE_DATE", typeof(String)); //
            paramTable1.Columns.Add("DUE_DATE", typeof(String)); //
            paramTable1.Columns.Add("TARGET_DUE_DATE", typeof(String)); //
            paramTable1.Columns.Add("PROD_QTY", typeof(Int32)); //
            paramTable1.Columns.Add("SCOMMENT", typeof(String)); //
            paramTable1.Columns.Add("REG_EMP", typeof(String)); //
            paramTable1.Columns.Add("PROD_UC", typeof(Decimal)); //
            paramTable1.Columns.Add("PROD_COST", typeof(Decimal)); //
            paramTable1.Columns.Add("PROD_VAT", typeof(Decimal)); //
            paramTable1.Columns.Add("PROD_AMT", typeof(Decimal)); //

            paramTable1.Columns.Add("SCH_LIMIT", typeof(Byte));
            paramTable1.Columns.Add("IS_LMPLAN", typeof(Byte));
            paramTable1.Columns.Add("LOAD_FLAG", typeof(Byte));

            paramTable1.Columns.Add("OVERWRITE", typeof(Byte)); //덮어쓰기 여부
            paramTable1.Columns.Add("MODE", typeof(String)); //덮어쓰기 여부

            DataTable dt = (DataTable)acGridView2.GridControl.DataSource;
            foreach (DataRow dr in dt.Rows)
            {
                if (dr.RowState != DataRowState.Deleted)
                {
                    DataRow paramRow1 = paramTable1.NewRow();
                    paramRow1["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow1["PROD_CODE"] = dr["PROD_CODE"];
                    paramRow1["ITEM_CODE"] = masterRow["ITEM_CODE"];
                    paramRow1["PART_CODE"] = dr["PART_CODE"];
                    paramRow1["PART_NAME"] = dr["PART_NAME"];
                    paramRow1["ORD_DATE"] = masterRow["ORD_DATE"].toDateString("yyyyMMdd");
                    paramRow1["INDUE_DATE"] = masterRow["DUE_DATE"].toDateString("yyyyMMdd");
                    paramRow1["DUE_DATE"] = dr["DUE_DATE"].toDateString("yyyyMMdd");
                    paramRow1["TARGET_DUE_DATE"] = dr["TARGET_DUE_DATE"].toDateString("yyyyMMdd");
                    paramRow1["PROD_QTY"] = dr["PROD_QTY"];
                    paramRow1["SCOMMENT"] = dr["PROD_SCOMMENT"];
                    paramRow1["REG_EMP"] = acInfo.UserID;
                    paramRow1["PROD_UC"] = dr["PROD_UC"];
                    paramRow1["PROD_COST"] = dr["PROD_COST"];
                    paramRow1["PROD_VAT"] = dr["PROD_VAT"];
                    paramRow1["PROD_AMT"] = dr["PROD_AMT"];

                    paramRow1["LOAD_FLAG"] = dr["LOAD_FLAG"];
                    paramRow1["IS_LMPLAN"] = "0";
                    paramRow1["SCH_LIMIT"] = "0";
                    paramRow1["OVERWRITE"] = "0";
                    if (dr["NEW"].ToString() == "NEW")
                        paramRow1["MODE"] = "I";
                    else
                        paramRow1["MODE"] = "U";

                    paramTable1.Rows.Add(paramRow1);
                }

            }
            
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable1);
           
            BizRun.QBizRun.ExecuteService(
            this, QBiz.emExecuteType.SAVE,
            "ORD02A_INS2", paramSet, "RQSTDT,RQSTDT2", "ITEM,PROD",
            QuickSave,
            QuickException);
        }

        void QuickSave(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                
                this.acGridView2.GridControl.DataSource = e.result.Tables["PROD"];

                foreach (DataRow row in e.result.Tables["ITEM"].Rows)
                {
                    this.acGridView1.UpdateMapingRow(row, true);
                }

                
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        public void MoveRow(GridView views, int sourceRow, int targetRow)
        {
            if (sourceRow == targetRow || sourceRow == targetRow + 1)
                return;
            DataRow row1 = views.GetDataRow(targetRow);
            DataRow row2 = views.GetDataRow(targetRow + 1);
            DataRow dragRow = views.GetDataRow(sourceRow);
            object val1 = row1["PROD_SEQ"];
            if (row2 == null)
                dragRow["PROD_SEQ"] = val1.toDouble() + 1;
            else
            {
                object val2 = row2["PROD_SEQ"];
                dragRow["PROD_SEQ"] = (val1.toDouble() + val2.toDouble()) / 2.0;
            }
        }

        private void SetRowSeqAfterSort(acGridView gridView)
        {
            try
            {
                gridView.BeginSort();

                DataView dv = gridView.GetDataSourceView();
                DataTable paramTable = dv.ToTable();
                paramTable.TableName = "RQSTDT";

                for (int i = 1; i < paramTable.Rows.Count; i++)
                {
                    paramTable.Rows[i - 1]["PROD_SEQ"] = i;
                }

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(this, "ORD02A_UPD", paramSet, "RQSTDT", "RSLTDT");
            }
            finally
            {
                gridView.EndSort();
            }
        }

        private void btnSaveAPS_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            acGridView2.EndEditor();

            DataRow masterRow = acGridView1.GetFocusedDataRow();

            if (masterRow == null) return;

            DataTable paramTable1 = new DataTable("RQSTDT");
            paramTable1.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable1.Columns.Add("PROD_CODE", typeof(String)); //
            paramTable1.Columns.Add("PART_CODE", typeof(String)); //
            paramTable1.Columns.Add("LOAD_FLAG", typeof(Byte));

            DataTable dt = (DataTable)acGridView2.GridControl.DataSource;
            foreach (DataRow dr in dt.Rows)
            {
                if (dr.RowState != DataRowState.Deleted)
                {
                    DataRow paramRow1 = paramTable1.NewRow();
                    paramRow1["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow1["PROD_CODE"] = dr["PROD_CODE"];
                    paramRow1["PART_CODE"] = dr["PART_CODE"];
                    paramRow1["LOAD_FLAG"] = dr["LOAD_FLAG"];

                    paramTable1.Rows.Add(paramRow1);
                }
            }

            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable1);

            BizRun.QBizRun.ExecuteService(
            this, QBiz.emExecuteType.SAVE,
            "ORD02A_UPD2", paramSet, "RQSTDT", "RSLTDT",
            QuickSaveAPS,
            QuickException);
        }

        void QuickSaveAPS(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        private void btnNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                //if (!base.ChildFormContains("NEW_PROD"))
                //{
                //    ORD02A_D1A frm = new ORD02A_D1A(acGridView1, "NEW_PROD");

                //    frm.DialogMode = BaseMenuDialog.emDialogMode.NEW;

                //    frm.ParentControl = this;

                //    base.ChildFormAdd("NEW_PROD", frm);

                //    frm.Show(this);


                //}
                //else
                //{
                //    base.ChildFormFocus("NEW_PROD");
                //}
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void btnCopy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                //if (acGridView1.ValidFocusRowHandle() == false)
                //{
                //    return;
                //}


                //DataRow focusRow = acGridView1.GetFocusedDataRow();


                ////string formKey = string.Format("{0},{1}", "PROD_CODE", focusRow["PROD_CODE"]);

                //if (!base.ChildFormContains("COPY_PROD"))
                //{

                //    ORD02A_D1A frm = new ORD02A_D1A(acGridView1, focusRow);

                //    frm.DialogMode = BaseMenuDialog.emDialogMode.USER;

                //    frm.ParentControl = this;

                //    base.ChildFormAdd("COPY_PROD", frm);

                //    frm.Show(this);

                //}
                //else
                //{
                //    base.ChildFormFocus("COPY_PROD");

                //}
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        /// <summary>
        /// 확정
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConfirm_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            acGridView1.EndEditor();

            if (acGridView1.RowCount == 0) return;

            DataRow[] selectedRows = acGridView1.GetSelectedDataRows();

            //if (selectedRows.Length == 0)
            //{
            //    acMessageBox.Show("선택된 데이터가 없습니다.", "확인", acMessageBox.emMessageBoxType.CONFIRM);
            //    return;
            //}
            

            DataTable paramTable1 = new DataTable("RQSTDT");
            paramTable1.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable1.Columns.Add("PROD_CODE", typeof(String)); //
            paramTable1.Columns.Add("PROD_STATE", typeof(String)); //

            if (selectedRows.Length == 0)
            {
                DataRow dr = acGridView1.GetFocusedDataRow();
                DataRow paramRow1 = paramTable1.NewRow();
                paramRow1["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow1["PROD_CODE"] = dr["PROD_CODE"];
                paramRow1["PROD_STATE"] = "7";

                paramTable1.Rows.Add(paramRow1);
            }
            else
            {
                foreach (DataRow dr in selectedRows)
                {
                    DataRow paramRow1 = paramTable1.NewRow();
                    paramRow1["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow1["PROD_CODE"] = dr["PROD_CODE"];
                    paramRow1["PROD_STATE"] = "7";

                    paramTable1.Rows.Add(paramRow1);
                }
            }

            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable1);

            BizRun.QBizRun.ExecuteService(
            this, QBiz.emExecuteType.SAVE,
            "ORD02A_UPD", paramSet, "RQSTDT", "RSLTDT",
            QuickSaveConfirm,
            QuickException);
        }

        void QuickSaveConfirm(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                foreach (DataRow row in e.result.Tables["RSLTDT"].Rows)
                {
                    this.acGridView1.UpdateMapingRow(row, true);
                }

                this.acGridView1.ClearSelection();


                acAlert.Show(this, "확정 되었습니다.", acAlertForm.enmType.Success);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }


        /// <summary>
        /// 취소
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            acGridView1.EndEditor();

            if (acGridView1.RowCount == 0) return;

            DataRow[] selectedRows = acGridView1.GetSelectedDataRows();

            //if (selectedRows.Length == 0)
            //{
            //    acMessageBox.Show("선택된 데이터가 없습니다.", "확인", acMessageBox.emMessageBoxType.CONFIRM);
            //    return;
            //}


            DataTable paramTable1 = new DataTable("RQSTDT");
            paramTable1.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable1.Columns.Add("PROD_CODE", typeof(String)); //
            paramTable1.Columns.Add("PROD_STATE", typeof(String)); //


            if (selectedRows.Length == 0)
            {
                DataRow dr = acGridView1.GetFocusedDataRow();
                DataRow paramRow1 = paramTable1.NewRow();
                paramRow1["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow1["PROD_CODE"] = dr["PROD_CODE"];
                paramRow1["PROD_STATE"] = "5";

                paramTable1.Rows.Add(paramRow1);
            }
            else
            {

                foreach (DataRow dr in selectedRows)
                {
                    DataRow paramRow1 = paramTable1.NewRow();
                    paramRow1["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow1["PROD_CODE"] = dr["PROD_CODE"];
                    paramRow1["PROD_STATE"] = "5";

                    paramTable1.Rows.Add(paramRow1);
                }
            }
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable1);

            BizRun.QBizRun.ExecuteService(
            this, QBiz.emExecuteType.SAVE,
            "ORD02A_UPD", paramSet, "RQSTDT", "RSLTDT",
            QuickSaveCancel,
            QuickException);
        }


        void QuickSaveCancel(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                foreach (DataRow row in e.result.Tables["RSLTDT"].Rows)
                {
                    this.acGridView1.UpdateMapingRow(row, true);
                }

                this.acGridView1.ClearSelection();

                acAlert.Show(this, "취소 되었습니다.", acAlertForm.enmType.Success);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }
        private void btnShipPlan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            acGridView1.EndEditor();

            if (acGridView1.RowCount == 0) return;

            DataRow[] selectedRows = acGridView1.GetSelectedDataRows();

            DataTable paramTable1 = new DataTable("RQSTDT");
            paramTable1.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable1.Columns.Add("PROD_CODE", typeof(String)); //
            paramTable1.Columns.Add("SHIP_FLAG", typeof(String)); //


            if (selectedRows.Length == 0)
            {
                //acMessageBox.Show("선택된 데이터가 없습니다.", "확인", acMessageBox.emMessageBoxType.CONFIRM);
                //return;
                DataRow dr = acGridView1.GetFocusedDataRow();
                DataRow paramRow1 = paramTable1.NewRow();
                paramRow1["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow1["PROD_CODE"] = dr["PROD_CODE"];
                paramRow1["SHIP_FLAG"] = "1";

                paramTable1.Rows.Add(paramRow1);
            }
            else
            {
                foreach (DataRow dr in selectedRows)
                {
                    DataRow paramRow1 = paramTable1.NewRow();
                    paramRow1["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow1["PROD_CODE"] = dr["PROD_CODE"];
                    paramRow1["SHIP_FLAG"] = "1";

                    paramTable1.Rows.Add(paramRow1);
                }
            }

            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable1);

            BizRun.QBizRun.ExecuteService(
            this, QBiz.emExecuteType.SAVE,
            "ORD02A_UPD2", paramSet, "RQSTDT", "RSLTDT",
            QuickSaveShip,
            QuickException);
        }

        void QuickSaveShip(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                foreach (DataRow row in e.result.Tables["RSLTDT"].Rows)
                {
                    this.acGridView1.UpdateMapingRow(row, true);
                }

                this.acGridView1.ClearSelection();

                acAlert.Show(this, "출하지시 되었습니다.", acAlertForm.enmType.Success);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }


        /// <summary>
        /// 수주 잠금
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLock_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            acGridView1.EndEditor();

            if (acGridView1.RowCount == 0) return;

            DataRow[] selectedRows = acGridView1.GetSelectedDataRows();
            

            DataTable paramTable1 = new DataTable("RQSTDT");
            paramTable1.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable1.Columns.Add("PROD_CODE", typeof(String)); //
            paramTable1.Columns.Add("LOCK_FLAG", typeof(String)); //
            paramTable1.Columns.Add("LOCK_EMP", typeof(String)); //

            if (selectedRows.Length == 0)
            {
                DataRow dr = acGridView1.GetFocusedDataRow();
                DataRow paramRow1 = paramTable1.NewRow();
                paramRow1["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow1["PROD_CODE"] = dr["PROD_CODE"];
                paramRow1["LOCK_FLAG"] = "1";
                paramRow1["LOCK_EMP"] = acInfo.UserID;

                paramTable1.Rows.Add(paramRow1);

                //acMessageBox.Show("선택된 데이터가 없습니다.", "확인", acMessageBox.emMessageBoxType.CONFIRM);
                //return;
            }
            else
            {
                foreach (DataRow dr in selectedRows)
                {
                    DataRow paramRow1 = paramTable1.NewRow();
                    paramRow1["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow1["PROD_CODE"] = dr["PROD_CODE"];
                    paramRow1["LOCK_FLAG"] = "1";
                    paramRow1["LOCK_EMP"] = acInfo.UserID;

                    paramTable1.Rows.Add(paramRow1);
                }
            }

            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable1);

            BizRun.QBizRun.ExecuteService(
            this, QBiz.emExecuteType.SAVE,
            "ORD02A_UPD3", paramSet, "RQSTDT", "RSLTDT",
            QuickSaveLock,
            QuickException);
        }

        void QuickSaveLock(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                foreach (DataRow row in e.result.Tables["RSLTDT"].Rows)
                {
                    this.acGridView1.UpdateMapingRow(row, true);
                }

                this.acGridView1.ClearSelection();

                acAlert.Show(this, "잠금 되었습니다.", acAlertForm.enmType.Success);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        /// <summary>
        /// 잠금해제        
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLockCancel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            acGridView1.EndEditor();

            if (acGridView1.RowCount == 0) return;

            DataRow[] selectedRows = acGridView1.GetSelectedDataRows();

            //if (selectedRows.Length == 0)
            //{
            //    acMessageBox.Show("선택된 데이터가 없습니다.", "확인", acMessageBox.emMessageBoxType.CONFIRM);
            //    return;
            //}


            DataTable paramTable1 = new DataTable("RQSTDT");
            paramTable1.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable1.Columns.Add("PROD_CODE", typeof(String)); //
            paramTable1.Columns.Add("LOCK_FLAG", typeof(String)); //
            paramTable1.Columns.Add("LOCK_EMP", typeof(String)); //
            if (selectedRows.Length == 0)
            {
                DataRow dr = acGridView1.GetFocusedDataRow();

                DataRow paramRow1 = paramTable1.NewRow();
                paramRow1["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow1["PROD_CODE"] = dr["PROD_CODE"];
                paramRow1["LOCK_FLAG"] = "0";
                paramRow1["LOCK_EMP"] = acInfo.UserID;

                paramTable1.Rows.Add(paramRow1);
            }
            else
            {
                foreach (DataRow dr in selectedRows)
                {
                    DataRow paramRow1 = paramTable1.NewRow();
                    paramRow1["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow1["PROD_CODE"] = dr["PROD_CODE"];
                    paramRow1["LOCK_FLAG"] = "0";
                    paramRow1["LOCK_EMP"] = acInfo.UserID;

                    paramTable1.Rows.Add(paramRow1);
                }
            }

            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable1);

            BizRun.QBizRun.ExecuteService(
            this, QBiz.emExecuteType.SAVE,
            "ORD02A_UPD4", paramSet, "RQSTDT", "RSLTDT",
            QuickSaveLockCancel,
            QuickException);
        }


        void QuickSaveLockCancel(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                foreach (DataRow row in e.result.Tables["RSLTDT"].Rows)
                {
                    this.acGridView1.UpdateMapingRow(row, true);
                }

                this.acGridView1.ClearSelection();

                acAlert.Show(this, "잠금해제 되었습니다.", acAlertForm.enmType.Success);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        private void acSimpleButton1_Click(object sender, EventArgs e)
        {

            if (acGridView1.DataRowCount == 0)
            {
                acAlert.Show(this, "선택된 수주가 없습니다.", acAlertForm.enmType.Warning);
                return;
            }

            //if (acTreeList1.AllNodesCount > 0)
            //{
            //    if (acMessageBox.Show("등록된 BOM이 있습니다.\r\n삭제 하시고 새로 등록 하시겠습니까?", "확인", acMessageBox.emMessageBoxType.YESNO) != DialogResult.Yes)
            //        return;
            //}


            try
            {

                string prod_code = acGridView1.GetFocusedDataRow()["PROD_CODE"].ToString();
                PLN21A_D0A frm = new PLN21A_D0A(acTreeList1, prod_code);

                frm.ParentControl = this;

                frm.Text = "BOM등록";

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    this.Search();
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void btnExpand_Click(object sender, EventArgs e)
        {
            if (acTreeList1.Nodes.Count > 0)
                acTreeList1.ExpandAll();
        }

        private void acSimpleButton2_Click(object sender, EventArgs e)
        {
            if (acTreeList1.Nodes.Count > 0)
                acTreeList1.CollapseAll();
        }

        private void acSimpleButton3_Click(object sender, EventArgs e)
        {
            try
            {
                DataRow focusRow = acGridView1.GetFocusedDataRow();

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(string));
                paramTable.Columns.Add("PROD_CODE", typeof(string));

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["PROD_CODE"] = focusRow["PROD_CODE"];

                paramTable.Rows.Add(paramRow);

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.PROCESS,
                "PLN21A_SER", paramSet, "RQSTDT", "RSLTDT",
                QuickSaveExcel,
                QuickException);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void QuickSaveExcel(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();

                saveFileDialog.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                saveFileDialog.Title = "저장할 위치를 입력하여 주십시오.";

                saveFileDialog.Filter = " Excel Files |*.xlsx;";

                saveFileDialog.FilterIndex = 1;

                saveFileDialog.RestoreDirectory = true;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    saveExcel(e.result.Tables["RSLTDT"], saveFileDialog.FileName);
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }


        void saveExcel(DataTable dt, string savePath)
        {
            using (SpreadsheetControl spreadCon = new SpreadsheetControl())
            {
                spreadCon.LoadDocument(Resource.BOM, DevExpress.Spreadsheet.DocumentFormat.Xlsx);

                using (IWorkbook workbook = spreadCon.Document)
                {
                    Worksheet bom = workbook.Worksheets[0];

                    int i = 1;
                    foreach (DataRow row in dt.Rows)
                    {
                        bom.Columns["A"][i].Value = row["PART_CODE"].toStringEmpty();
                        bom.Columns["B"][i].Value = row["PART_NAME"].toStringEmpty();
                        //bom.Columns["C"][i].Value = row["MAT_LTYPE"].toStringEmpty();
                        //bom.Columns["D"][i].Value = row["MAT_MTYPE"].toStringEmpty();
                        //bom.Columns["E"][i].Value = row["MAT_STYPE"].toStringEmpty();
                        bom.Columns["C"][i].Value = acInfo.StdCodes.GetNameByCode("M014", row["MAT_LTYPE"].toStringEmpty());
                        bom.Columns["D"][i].Value = acInfo.StdCodes.GetNameByCode("M015", row["MAT_MTYPE"].toStringEmpty());
                        bom.Columns["E"][i].Value = acInfo.StdCodes.GetNameByCode("M016", row["MAT_STYPE"].toStringEmpty());
                        bom.Columns["F"][i].Value = row["O_PART_CODE"].toStringEmpty();
                        bom.Columns["G"][i].Value = row["O_PART_CODE"].toStringEmpty();
                        bom.Columns["H"][i].Value = row["Tab_Machine"].toStringEmpty();
                        bom.Columns["I"][i].Value = row["MakeSideHole"].toStringEmpty();
                        bom.Columns["J"][i].Value = row["Slit_Division"].toStringEmpty();
                        bom.Columns["K"][i].Value = row["SAFE_STK_QTY"].toStringEmpty();
                        bom.Columns["L"][i].Value = row["Material"].toStringEmpty();
                        bom.Columns["M"][i].Value = row["Surface_Treat"].toStringEmpty();
                        bom.Columns["N"][i].Value = row["After_Treat"].toStringEmpty();
                        bom.Columns["O"][i].Value = row["MAKE_DESC"].toStringEmpty();
                        bom.Columns["P"][i].Value = row["PART_QTY"].toStringEmpty();
                        bom.Columns["Q"][i].Value = row["ORD_QTY"].toStringEmpty();

                        i++;
                    }

                    workbook.SaveDocument(savePath);

                }
            }
        }

        private void acBarButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DataRowView focusRowView = (DataRowView)acTreeList1.GetDataRecordByNode(acTreeList1.FocusedNode);

            if (focusRowView == null)
            {
                return;
            }

            PLN21A_D2A frm = new PLN21A_D2A(acTreeList1, focusRowView.Row);

            frm.ParentControl = this;
            frm.DialogMode = BaseMenuDialog.emDialogMode.OPEN;

            if (frm.ShowDialog() == DialogResult.OK)
            {
            }
        }

        private void acBarButtonItem9_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //리핏금지
            acGridView1.EndEditor();

            DataRow focusRow = acGridView1.GetFocusedDataRow();

            if (focusRow == null) return;

            DataRow[] selectedRows = acGridView1.GetSelectedDataRows();

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(string));
            paramTable.Columns.Add("PROD_CODE", typeof(string));
            paramTable.Columns.Add("REPEAT_STOP", typeof(byte));
            paramTable.Columns.Add("REPEAT_STOP_EMP", typeof(string));
            paramTable.Columns.Add("REPEAT_STOP_DATE", typeof(DateTime));

            if (selectedRows.Length == 0)
            {
                if (focusRow["REPEAT_STOP_EMP"].ToString() == "")
                {
                    DataRow paramRow = paramTable.NewRow();
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["PROD_CODE"] = focusRow["PROD_CODE"];
                    paramRow["REPEAT_STOP"] = "1";
                    paramRow["REPEAT_STOP_EMP"] = acInfo.UserID;
                    paramRow["REPEAT_STOP_DATE"] = acDateEdit.GetNowDateFromServer();
                    paramTable.Rows.Add(paramRow);
                }
                else
                {
                    acAlert.Show(this, "이미 금지된 수주입니다.", acAlertForm.enmType.Warning);
                    return;
                }
            }
            else
            {
                foreach (DataRow row in selectedRows)
                {
                    if (row["REPEAT_STOP_EMP"].ToString() == "")
                    {
                        DataRow paramRow = paramTable.NewRow();
                        paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                        paramRow["PROD_CODE"] = row["PROD_CODE"];
                        paramRow["REPEAT_STOP"] = "1";
                        paramRow["REPEAT_STOP_EMP"] = acInfo.UserID;
                        paramRow["REPEAT_STOP_DATE"] = acDateEdit.GetNowDateFromServer();
                        paramTable.Rows.Add(paramRow);
                    }
                    else
                    {
                        acAlert.Show(this, "이미 금지된 수주가 선택되어 있습니다.", acAlertForm.enmType.Warning);
                        return;
                    }
                }
            }

            if (paramTable.Rows.Count > 0)
            {
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.SAVE,
                "ORD02A_UPD8", paramSet, "RQSTDT", "RSLTDT",
                QuickSave2,
                QuickException);
            }
        }

        private void acBarButtonItem10_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //리핏금지 취소
            acGridView1.EndEditor();

            DataRow focusRow = acGridView1.GetFocusedDataRow();

            if (focusRow == null) return;

            DataRow[] selectedRows = acGridView1.GetSelectedDataRows();

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(string));
            paramTable.Columns.Add("PROD_CODE", typeof(string));
            paramTable.Columns.Add("REPEAT_STOP", typeof(byte));
            paramTable.Columns.Add("REPEAT_STOP_EMP", typeof(string));
            paramTable.Columns.Add("REPEAT_STOP_DATE", typeof(DateTime));

            if (selectedRows.Length == 0)
            {
                if (focusRow["REPEAT_STOP_EMP"].ToString() == acInfo.UserID)
                {
                    DataRow paramRow = paramTable.NewRow();
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["PROD_CODE"] = focusRow["PROD_CODE"];
                    paramRow["REPEAT_STOP"] = "0";
                    paramRow["REPEAT_STOP_EMP"] = DBNull.Value;
                    paramRow["REPEAT_STOP_DATE"] = DBNull.Value;
                    paramTable.Rows.Add(paramRow);
                }
                else if (focusRow["REPEAT_STOP_EMP"].ToString() != "")
                {
                    acAlert.Show(this, "금지한 사람만 취소 가능합니다.", acAlertForm.enmType.Warning);
                    return;
                }
            }
            else
            {
                foreach (DataRow row in selectedRows)
                {
                    if (row["REPEAT_STOP_EMP"].ToString() == acInfo.UserID)
                    {
                        DataRow paramRow = paramTable.NewRow();
                        paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                        paramRow["PROD_CODE"] = row["PROD_CODE"];
                        paramRow["REPEAT_STOP"] = "0";
                        paramRow["REPEAT_STOP_EMP"] = DBNull.Value;
                        paramRow["REPEAT_STOP_DATE"] = DBNull.Value;
                        paramTable.Rows.Add(paramRow);
                    }
                    else if (focusRow["REPEAT_STOP_EMP"].ToString() != "")
                    {
                        acAlert.Show(this, "금지한 사람과 다른 수주가 선택되어 있습니다.", acAlertForm.enmType.Warning);
                        return;
                    }
                }
            }

            if (paramTable.Rows.Count > 0)
            {
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.SAVE,
                "ORD02A_UPD8", paramSet, "RQSTDT", "RSLTDT",
                QuickSave2,
                QuickException);
            }
        }

        void QuickSave2(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                foreach (DataRow row in e.result.Tables["RSLTDT"].Rows)
                {
                    this.acGridView1.UpdateMapingRow(row, true);
                }

                this.acGridView1.ClearSelection();


                acAlert.Show(this, "처리 되었습니다.", acAlertForm.enmType.Success);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        private DataTable editedBom = null;
        private DataTable editedDelBom = null;

        private DataTable tempEditBom = null;


        private void acBarButtonItem11_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DataRow focusRow = acGridView1.GetFocusedDataRow();

            PLN21A_D3A frm = new PLN21A_D3A(focusRow["PROD_CODE"].ToString(), tempEditBom, true, focusRow);

            frm.DialogMode = BaseMenuDialog.emDialogMode.NEW;

            frm.ParentControl = this;

            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                tempEditBom = (DataTable)frm.OutputData; //임시저장용

                // 편집된 BOM 저장
                if (((DataTable)frm.OutputData).Select("[CHK_FLAG] = '1'").Length != 0)
                {
                    editedBom = ((DataTable)frm.OutputData).Select("[CHK_FLAG] = '1'").CopyToDataTable();

                    if (((DataTable)frm.OutputData).Select("[CHK_FLAG] = '0'").Length != 0)
                    {
                        editedDelBom = ((DataTable)frm.OutputData).Select("[CHK_FLAG] = '0'").CopyToDataTable();
                    }
                    else
                    {
                        editedDelBom = null;
                    }

                }
                else
                {
                    editedBom = null;
                    editedDelBom = null;
                }

                DataTable paramTable = ((DataTable)acGridView1.GridControl.DataSource).Clone();
                DataRow paramRow = paramTable.NewRow();
                paramRow.ItemArray = focusRow.ItemArray;
                paramRow["BOM_FLAG"] = DBNull.Value;
                paramTable.Rows.Add(paramRow);
                paramTable.TableName = "RQSTDT";

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);
                

                if (editedBom != null)
                {
                    if (editedBom.Rows.Count > 0)
                    {
                        // 기존 수주건의 PART_QTY를 지우고 새로 편집한 수량을 PART_QTY로 지정
                        editedBom.TableName = "RQSTDT_BOM";
                        paramSet.Tables.Add(editedBom);
                    }
                }

                if (editedDelBom != null)
                {
                    if (editedDelBom.Rows.Count > 0)
                    {
                        editedDelBom.TableName = "RQSTDT_DEL_BOM";
                        paramSet.Tables.Add(editedDelBom);
                    }
                }

                BizRun.QBizRun.ExecuteService(
                    this, QBiz.emExecuteType.SAVE,
                    "PLN21A_INS3", paramSet, "RQSTDT", "RSLTDT",
                    QuickSaveClose,
                    QuickException);
            }
        }

        void QuickSaveClose(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                tempEditBom = null;
                editedBom = null;
                editedDelBom = null;
                acGridView1.RaiseFocusedRowChanged();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }
    }
}
