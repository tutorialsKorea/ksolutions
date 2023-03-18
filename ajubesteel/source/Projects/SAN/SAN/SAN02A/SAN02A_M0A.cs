using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using ControlManager;
using CodeHelperManager;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using BizManager;
using System.Linq;

namespace SAN
{
    public sealed partial class SAN02A_M0A : BaseMenu
    {
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

        public SAN02A_M0A()
        {
            InitializeComponent();

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
            return base.MenuDestory(sender);
        }

        public override void MenuGotFocus()
        {
            base.MenuGotFocus();
        }

        public override void MenuLostFocus()
        {

            base.MenuLostFocus();
        }

        public override void MenuInitComplete()
        {

            base.MenuInitComplete();
        }

        private Color _progColor = acInfo.SysConfig.GetSysConfigByMemory("APP_STATE_PROG").toColor();
        private Color _okColor = acInfo.SysConfig.GetSysConfigByMemory("APP_STATE_OK").toColor();
        private Color _denyColor = acInfo.SysConfig.GetSysConfigByMemory("APP_STATE_DENY").toColor();

        private DataTable _holiTable = null;

        private DataTable _stdHoliTable = null;
        public override void MenuInit()
        {
            acLayoutControl1.OnValueChanged += new acLayoutControl.ValueChangedEventHandler(acLayoutControl1_OnValueChanged);
            acLayoutControl1.OnValueKeyDown += new acLayoutControl.ValueKeyDownEventHandler(acLayoutControl1_OnValueKeyDown);

            DataSet empResultSet = BizRun.QBizRun.ExecuteService(this, "CTRL", "GET_EMPLOYEE", acInfo.RefData, "RQSTDT", "RSLTDT");
            DataSet venResultSet = BizRun.QBizRun.ExecuteService(this, "CTRL", "CONTROL_VENDOR_SEARCH", acInfo.RefData, "RQSTDT", "RSLTDT");
            
            //승인/반려
            acGridView1.GridType = acGridView.emGridType.SEARCH_SEL;
            acGridView1.OptionsView.ShowIndicator = true;
            acGridView1.AddLookUpEdit("BAL_TYPE", "발주 구분", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "S016");
            acGridView1.AddTextEdit("BALJU_NUM", "발주번호", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddLookUpEdit("MVND_CODE", "발주처", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "VEN_NAME", "VEN_CODE", venResultSet.Tables["RSLTDT"]);
            acGridView1.AddDateEdit("BALJU_DATE", "발주일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
            acGridView1.AddCheckEdit("INCL_VAT", "부가세포함", "", false, false, true, acGridView.emCheckEditDataType._STRING);
            acGridView1.AddCheckEdit("SPLIT", "분할납품", "", false, false, true, acGridView.emCheckEditDataType._STRING);
            acGridView1.AddTextEdit("DELIVERY_LOCATION", "납품장소", "HEP4DK2T", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("PAY_CONDITION", "결제조건", "HEP4DK2T", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("REG_EMP", "발주자코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("REG_EMP_NAME", "발주자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            //acGridView1.AddTextEdit("YPGO_CHARGE", "입고담당", "HEP4DK2T", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddCheckEdit("CHK_MEASURE", "치수검사", "", false, false, true, acGridView.emCheckEditDataType._STRING);
            acGridView1.AddCheckEdit("CHK_PERFORM", "성능검사", "", false, false, true, acGridView.emCheckEditDataType._STRING);
            acGridView1.AddCheckEdit("CHK_ATTEND", "입회검사", "", false, false, true, acGridView.emCheckEditDataType._STRING);
            acGridView1.AddCheckEdit("CHK_TEST", "검사성적서", "", false, false, true, acGridView.emCheckEditDataType._STRING);
            acGridView1.AddCheckEdit("CHK_MEEL", "MEEL SHEET", "", false, false, true, acGridView.emCheckEditDataType._STRING);
            acGridView1.AddTextEdit("CHK_ADD1", "기타1", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("CHK_ADD2", "기타2", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("CHK_ADD3", "기타3", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddLookUpEdit("APP_EMP1", "승인자1", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "EMP_NAME", "EMP_CODE", empResultSet.Tables["RSLTDT"]);
            acGridView1.AddTextEdit("APP_EMP_FLAG1", "승인자1상태", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddLookUpEdit("APP_EMP2", "승인자1", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "EMP_NAME", "EMP_CODE", empResultSet.Tables["RSLTDT"]);
            acGridView1.AddTextEdit("APP_EMP_FLAG2", "승인자2상태", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddLookUpEdit("APP_EMP3", "승인자1", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "EMP_NAME", "EMP_CODE", empResultSet.Tables["RSLTDT"]);
            acGridView1.AddTextEdit("APP_EMP_FLAG3", "승인자3상태", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddLookUpEdit("APP_EMP4", "승인자1", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "EMP_NAME", "EMP_CODE", empResultSet.Tables["RSLTDT"]);
            acGridView1.AddTextEdit("APP_EMP_FLAG4", "승인자4상태", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);

            acGridView1.KeyColumn = new string[] { "BALJU_NUM" };

            acGridView1.CustomDrawCell += acGridView_CustomDrawCell;

            acGridView1.FocusedRowChanged += acGridView_FocusedRowChanged;

            //승인 취소
            acGridView3.GridType = acGridView.emGridType.SEARCH_SEL;
            acGridView3.OptionsView.ShowIndicator = true;
            acGridView3.AddLookUpEdit("BAL_TYPE", "발주 구분", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "S016");
            acGridView3.AddTextEdit("BALJU_NUM", "발주번호", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView3.AddLookUpEdit("MVND_CODE", "발주처", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "VEN_NAME", "VEN_CODE", venResultSet.Tables["RSLTDT"]);
            acGridView3.AddDateEdit("BALJU_DATE", "발주일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
            acGridView3.AddCheckEdit("INCL_VAT", "부가세포함", "", false, false, true, acGridView.emCheckEditDataType._STRING);
            acGridView3.AddCheckEdit("SPLIT", "분할납품", "", false, false, true, acGridView.emCheckEditDataType._STRING);
            acGridView3.AddTextEdit("DELIVERY_LOCATION", "납품장소", "HEP4DK2T", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView3.AddTextEdit("PAY_CONDITION", "결제조건", "HEP4DK2T", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView3.AddTextEdit("REG_EMP", "발주자코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView3.AddTextEdit("REG_EMP_NAME", "발주자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            //acGridView3.AddTextEdit("YPGO_CHARGE", "입고담당", "HEP4DK2T", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView3.AddCheckEdit("CHK_MEASURE", "치수검사", "", false, false, true, acGridView.emCheckEditDataType._STRING);
            acGridView3.AddCheckEdit("CHK_PERFORM", "성능검사", "", false, false, true, acGridView.emCheckEditDataType._STRING);
            acGridView3.AddCheckEdit("CHK_ATTEND", "입회검사", "", false, false, true, acGridView.emCheckEditDataType._STRING);
            acGridView3.AddCheckEdit("CHK_TEST", "검사성적서", "", false, false, true, acGridView.emCheckEditDataType._STRING);
            acGridView3.AddCheckEdit("CHK_MEEL", "MEEL SHEET", "", false, false, true, acGridView.emCheckEditDataType._STRING);
            acGridView3.AddTextEdit("CHK_ADD1", "기타1", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView3.AddTextEdit("CHK_ADD2", "기타2", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView3.AddTextEdit("CHK_ADD3", "기타3", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView3.AddLookUpEdit("APP_EMP1", "승인자1", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "EMP_NAME", "EMP_CODE", empResultSet.Tables["RSLTDT"]);
            acGridView3.AddTextEdit("APP_EMP_FLAG1", "승인자1상태", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView3.AddLookUpEdit("APP_EMP2", "승인자1", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "EMP_NAME", "EMP_CODE", empResultSet.Tables["RSLTDT"]);
            acGridView3.AddTextEdit("APP_EMP_FLAG2", "승인자2상태", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView3.AddLookUpEdit("APP_EMP3", "승인자1", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "EMP_NAME", "EMP_CODE", empResultSet.Tables["RSLTDT"]);
            acGridView3.AddTextEdit("APP_EMP_FLAG3", "승인자3상태", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView3.AddLookUpEdit("APP_EMP4", "승인자1", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "EMP_NAME", "EMP_CODE", empResultSet.Tables["RSLTDT"]);
            acGridView3.AddTextEdit("APP_EMP_FLAG4", "승인자4상태", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);

            acGridView3.KeyColumn = new string[] { "BALJU_NUM" };

            acGridView3.CustomDrawCell += acGridView_CustomDrawCell;

            acGridView3.FocusedRowChanged += acGridView_FocusedRowChanged;

            //반려 취소
            acGridView4.GridType = acGridView.emGridType.SEARCH_SEL;
            acGridView4.OptionsView.ShowIndicator = true;
            acGridView4.AddLookUpEdit("BAL_TYPE", "발주 구분", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "S016");
            acGridView4.AddTextEdit("BALJU_NUM", "발주번호", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView4.AddLookUpEdit("MVND_CODE", "발주처", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "VEN_NAME", "VEN_CODE", venResultSet.Tables["RSLTDT"]);
            acGridView4.AddDateEdit("BALJU_DATE", "발주일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
            acGridView4.AddCheckEdit("INCL_VAT", "부가세포함", "", false, false, true, acGridView.emCheckEditDataType._STRING);
            acGridView4.AddCheckEdit("SPLIT", "분할납품", "", false, false, true, acGridView.emCheckEditDataType._STRING);
            acGridView4.AddTextEdit("DELIVERY_LOCATION", "납품장소", "HEP4DK2T", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView4.AddTextEdit("PAY_CONDITION", "결제조건", "HEP4DK2T", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView4.AddTextEdit("REG_EMP", "발주자코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView4.AddTextEdit("REG_EMP_NAME", "발주자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            //acGridView4.AddTextEdit("YPGO_CHARGE", "입고담당", "HEP4DK2T", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView4.AddCheckEdit("CHK_MEASURE", "치수검사", "", false, false, true, acGridView.emCheckEditDataType._STRING);
            acGridView4.AddCheckEdit("CHK_PERFORM", "성능검사", "", false, false, true, acGridView.emCheckEditDataType._STRING);
            acGridView4.AddCheckEdit("CHK_ATTEND", "입회검사", "", false, false, true, acGridView.emCheckEditDataType._STRING);
            acGridView4.AddCheckEdit("CHK_TEST", "검사성적서", "", false, false, true, acGridView.emCheckEditDataType._STRING);
            acGridView4.AddCheckEdit("CHK_MEEL", "MEEL SHEET", "", false, false, true, acGridView.emCheckEditDataType._STRING);
            acGridView4.AddTextEdit("CHK_ADD1", "기타1", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView4.AddTextEdit("CHK_ADD2", "기타2", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView4.AddTextEdit("CHK_ADD3", "기타3", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView4.AddLookUpEdit("APP_EMP1", "승인자1", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "EMP_NAME", "EMP_CODE", empResultSet.Tables["RSLTDT"]);
            acGridView4.AddTextEdit("APP_EMP_FLAG1", "승인자1상태", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView4.AddLookUpEdit("APP_EMP2", "승인자2", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "EMP_NAME", "EMP_CODE", empResultSet.Tables["RSLTDT"]);
            acGridView4.AddTextEdit("APP_EMP_FLAG2", "승인자2상태", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView4.AddLookUpEdit("APP_EMP3", "승인자3", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "EMP_NAME", "EMP_CODE", empResultSet.Tables["RSLTDT"]);
            acGridView4.AddTextEdit("APP_EMP_FLAG3", "승인자3상태", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView4.AddLookUpEdit("APP_EMP4", "승인자4", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "EMP_NAME", "EMP_CODE", empResultSet.Tables["RSLTDT"]);
            acGridView4.AddTextEdit("APP_EMP_FLAG4", "승인자4상태", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);

            acGridView4.KeyColumn = new string[] { "BALJU_NUM" };

            acGridView4.CustomDrawCell += acGridView_CustomDrawCell;

            acGridView4.FocusedRowChanged += acGridView_FocusedRowChanged;

            //상세
            acGridView2.GridType = acGridView.emGridType.SEARCH;
            acGridView2.OptionsView.ShowIndicator = true;
            acGridView2.AddTextEdit("BALJU_NUM", "발주번호", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("BALJU_SEQ", "순번", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddLookUpEdit("BAL_TYPE", "발주구분", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "S016");
            acGridView2.AddTextEdit("PART_CODE", "자재코드", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("PART_NAME", "자재명", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("DETAIL_PART_NAME", "세부 자재명", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            //acGridView2.AddLookUpEdit("PART_PRODTYPE", "분류", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M007");
            acGridView2.AddLookUpEdit("MAT_LTYPE", "대분류", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M014");
            acGridView2.AddLookUpEdit("MAT_MTYPE", "중분류", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M015");
            acGridView2.AddDateEdit("DUE_DATE", "입고예정일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
            acGridView2.AddTextEdit("UNIT_COST", "단가", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
            acGridView2.AddTextEdit("AMT", "금액", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
            acGridView2.AddTextEdit("QTY", "발주수량", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView2.AddTextEdit("YPGO_QTY", "입고수량", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView2.AddTextEdit("REMAIN_QTY", "남은수량", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            //acGridView2.AddTextEdit("PART_QTY", "재고수량", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView2.AddTextEdit("REAL_AMT", "실제 입금금액", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
            acGridView2.AddTextEdit("BANK", "은행", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("BANK_NO", "계좌번호", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView2.AddTextEdit("SCOMMENT", "비고", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);


            acTabControl1.SelectedPageChanged += acTabControl_SelectedPageChanged;

            //공정외주
            acGridView6.GridType = acGridView.emGridType.SEARCH_SEL;
            acGridView6.OptionsView.ShowIndicator = true;
            acGridView6.AddTextEdit("BALJU_NUM", "발주번호", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView6.AddLookUpEdit("OVND_CODE", "발주처", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "VEN_NAME", "VEN_CODE", venResultSet.Tables["RSLTDT"]);
            acGridView6.AddDateEdit("BALJU_DATE", "발주일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);

            acGridView6.AddTextEdit("REG_EMP", "발주자코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView6.AddTextEdit("REG_EMP_NAME", "발주자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView6.AddTextEdit("SCOMMENT", "비고", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView6.AddLookUpEdit("APP_EMP1", "승인자1", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "EMP_NAME", "EMP_CODE", empResultSet.Tables["RSLTDT"]);
            acGridView6.AddTextEdit("APP_EMP_FLAG1", "승인자1상태", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView6.AddLookUpEdit("APP_EMP2", "승인자1", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "EMP_NAME", "EMP_CODE", empResultSet.Tables["RSLTDT"]);
            acGridView6.AddTextEdit("APP_EMP_FLAG2", "승인자2상태", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView6.AddLookUpEdit("APP_EMP3", "승인자1", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "EMP_NAME", "EMP_CODE", empResultSet.Tables["RSLTDT"]);
            acGridView6.AddTextEdit("APP_EMP_FLAG3", "승인자3상태", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView6.AddLookUpEdit("APP_EMP4", "승인자1", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "EMP_NAME", "EMP_CODE", empResultSet.Tables["RSLTDT"]);
            acGridView6.AddTextEdit("APP_EMP_FLAG4", "승인자4상태", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);

            acGridView6.KeyColumn = new string[] { "BALJU_NUM" };

            acGridView6.FocusedRowChanged += acGridView_FocusedRowChanged;
            acGridView6.CustomDrawCell += acGridView_CustomDrawCell;

            acGridView7.GridType = acGridView.emGridType.SEARCH_SEL;
            acGridView7.OptionsView.ShowIndicator = true;
            acGridView7.AddTextEdit("BALJU_NUM", "발주번호", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView7.AddLookUpEdit("OVND_CODE", "발주처", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "VEN_NAME", "VEN_CODE", venResultSet.Tables["RSLTDT"]);
            acGridView7.AddDateEdit("BALJU_DATE", "발주일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);

            acGridView7.AddTextEdit("REG_EMP", "발주자코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView7.AddTextEdit("REG_EMP_NAME", "발주자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView7.AddTextEdit("SCOMMENT", "비고", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView7.AddLookUpEdit("APP_EMP1", "승인자1", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "EMP_NAME", "EMP_CODE", empResultSet.Tables["RSLTDT"]);
            acGridView7.AddTextEdit("APP_EMP_FLAG1", "승인자1상태", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView7.AddLookUpEdit("APP_EMP2", "승인자1", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "EMP_NAME", "EMP_CODE", empResultSet.Tables["RSLTDT"]);
            acGridView7.AddTextEdit("APP_EMP_FLAG2", "승인자2상태", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView7.AddLookUpEdit("APP_EMP3", "승인자1", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "EMP_NAME", "EMP_CODE", empResultSet.Tables["RSLTDT"]);
            acGridView7.AddTextEdit("APP_EMP_FLAG3", "승인자3상태", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView7.AddLookUpEdit("APP_EMP4", "승인자1", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "EMP_NAME", "EMP_CODE", empResultSet.Tables["RSLTDT"]);
            acGridView7.AddTextEdit("APP_EMP_FLAG4", "승인자4상태", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);

            acGridView7.KeyColumn = new string[] { "BALJU_NUM" };

            acGridView7.FocusedRowChanged += acGridView_FocusedRowChanged;
            acGridView7.CustomDrawCell += acGridView_CustomDrawCell;

            acGridView8.GridType = acGridView.emGridType.SEARCH_SEL;
            acGridView8.OptionsView.ShowIndicator = true;
            acGridView8.AddTextEdit("BALJU_NUM", "발주번호", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView8.AddLookUpEdit("OVND_CODE", "발주처", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "VEN_NAME", "VEN_CODE", venResultSet.Tables["RSLTDT"]);
            acGridView8.AddDateEdit("BALJU_DATE", "발주일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);

            acGridView8.AddTextEdit("REG_EMP", "발주자코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView8.AddTextEdit("REG_EMP_NAME", "발주자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView8.AddTextEdit("SCOMMENT", "비고", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView8.AddLookUpEdit("APP_EMP1", "승인자1", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "EMP_NAME", "EMP_CODE", empResultSet.Tables["RSLTDT"]);
            acGridView8.AddTextEdit("APP_EMP_FLAG1", "승인자1상태", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView8.AddLookUpEdit("APP_EMP2", "승인자1", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "EMP_NAME", "EMP_CODE", empResultSet.Tables["RSLTDT"]);
            acGridView8.AddTextEdit("APP_EMP_FLAG2", "승인자2상태", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView8.AddLookUpEdit("APP_EMP3", "승인자1", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "EMP_NAME", "EMP_CODE", empResultSet.Tables["RSLTDT"]);
            acGridView8.AddTextEdit("APP_EMP_FLAG3", "승인자3상태", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView8.AddLookUpEdit("APP_EMP4", "승인자1", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "EMP_NAME", "EMP_CODE", empResultSet.Tables["RSLTDT"]);
            acGridView8.AddTextEdit("APP_EMP_FLAG4", "승인자4상태", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);

            acGridView8.KeyColumn = new string[] { "BALJU_NUM" };

            acGridView8.FocusedRowChanged += acGridView_FocusedRowChanged;
            acGridView8.CustomDrawCell += acGridView_CustomDrawCell;

            //외주발주상세
            acGridView9.GridType = acGridView.emGridType.SEARCH;
            acGridView9.OptionsView.ShowIndicator = true;
            acGridView9.AddTextEdit("BALJU_NUM", "발주번호", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView9.AddTextEdit("BALJU_SEQ", "순번", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView9.AddTextEdit("WO_NO", "작업지시번호", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView9.AddTextEdit("PROD_CODE", "수주코드", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView9.AddTextEdit("PROD_NAME", "수주명", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView9.AddTextEdit("PART_CODE", "자재코드", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView9.AddTextEdit("PART_NAME", "자재명", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            //acGridView9.AddLookUpEdit("PART_PRODTYPE", "분류", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M007");
            acGridView9.AddLookUpEdit("MAT_LTYPE", "대분류", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M014");
            acGridView9.AddLookUpEdit("MAT_MTYPE", "중분류", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M015");
            acGridView9.AddDateEdit("DUE_DATE", "입고예정일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
            acGridView9.AddTextEdit("UNIT_COST", "단가", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
            acGridView9.AddTextEdit("AMT", "금액", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
            acGridView9.AddTextEdit("QTY", "발주수량", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView9.AddTextEdit("YPGO_QTY", "입고수량", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView9.AddTextEdit("NG_QTY", "불량수량", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView9.AddTextEdit("REMAIN_QTY", "남은수량", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView9.AddTextEdit("PART_QTY", "재고수량", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);


            acTabControl3.SelectedPageChanged += acTabControl_SelectedPageChanged;

            acTabControl2.SelectedPageChanged += acTabControl2_SelectedPageChanged;

            acCheckedComboBoxEdit1.AddItem("발주일", true, "40206", "BALJU_DATE", true, false);

            btnApproval.Enabled = false;
            btnApproval.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

            btnCancel.Enabled = false;
            btnCancel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            btnReject.Enabled = false;
            btnReject.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

            btnRejectCancel.Enabled = false;
            btnRejectCancel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            acGridView1.RowCountChanged += acGridView_RowCountChanged;
            acGridView3.RowCountChanged += acGridView_RowCountChanged;
            acGridView4.RowCountChanged += acGridView_RowCountChanged;
            acGridView6.RowCountChanged += acGridView_RowCountChanged;
            acGridView7.RowCountChanged += acGridView_RowCountChanged;
            acGridView8.RowCountChanged += acGridView_RowCountChanged;

            base.MenuInit();
        }

        private void acGridView_RowCountChanged(object sender, EventArgs e)
        {
            acGridView gridView = sender as acGridView;

            string masterTabName = acTabControl2.GetSelectedContainerName();

            string tabName = "";

            if (masterTabName == "MAT")
            {
                tabName = acTabControl1.GetSelectedContainerName();
            }
            else if (masterTabName == "OUT")
            {
                tabName = acTabControl3.GetSelectedContainerName();
            }

            bool isEnabled = false;

            if (gridView.RowCount > 0)
            {
                isEnabled = true;
            }
            else
            {
                isEnabled = false;
            }

            switch (tabName)
            {
                case "MAT_REQ_APP":
                    btnApproval.Enabled = isEnabled;
                    btnReject.Enabled = isEnabled;
                    break;

                case "MAT_APP_CANCEL":
                    btnCancel.Enabled = isEnabled;
                    break;

                case "MAT_REJ_CANCEL":
                    btnRejectCancel.Enabled = isEnabled;
                    break;

                case "OUT_REQ_APP":
                    btnApproval.Enabled = isEnabled;
                    btnReject.Enabled = isEnabled;
                    break;

                case "OUT_APP_CANCEL":
                    btnCancel.Enabled = isEnabled;
                    break;

                case "OUT_REJ_CANCEL":
                    btnRejectCancel.Enabled = isEnabled;
                    break;
            }
        }

        private void acTabControl_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            acTabControl tabControl = sender as acTabControl;
            DataRow focusRow = null;
            switch (tabControl.GetSelectedContainerName())
            {
                case "MAT_REQ_APP": //신청 승인/반려

                    //btnApproval.Enabled = true;
                    btnApproval.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

                    //btnCancel.Enabled = false;
                    btnCancel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

                    //btnReject.Enabled = true;
                    btnReject.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

                    //btnRejectCancel.Enabled = false;
                    btnRejectCancel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

                    focusRow = acGridView1.GetFocusedDataRow();

                    acGridView_RowCountChanged(acGridView1, null);

                    break;

                case "MAT_APP_CANCEL": //승인취소

                    //btnApproval.Enabled = false;
                    btnApproval.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

                    //btnCancel.Enabled = true;
                    btnCancel.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

                    //btnReject.Enabled = false;
                    btnReject.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

                    //btnRejectCancel.Enabled = false;
                    btnRejectCancel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

                    focusRow = acGridView3.GetFocusedDataRow();

                    acGridView_RowCountChanged(acGridView3, null);

                    break;

                case "MAT_REJ_CANCEL": //반려취소

                    //btnApproval.Enabled = false;
                    btnApproval.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

                    //btnCancel.Enabled = false;
                    btnCancel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

                    //btnReject.Enabled = false;
                    btnReject.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

                    //btnRejectCancel.Enabled = true;
                    btnRejectCancel.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

                    focusRow = acGridView4.GetFocusedDataRow();

                    acGridView_RowCountChanged(acGridView4, null);

                    break;

                case "OUT_REQ_APP": //신청 승인/반려

                    //btnApproval.Enabled = true;
                    btnApproval.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

                    //btnCancel.Enabled = false;
                    btnCancel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

                    //btnReject.Enabled = true;
                    btnReject.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

                    //btnRejectCancel.Enabled = false;
                    btnRejectCancel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;


                    focusRow = acGridView6.GetFocusedDataRow();

                    acGridView_RowCountChanged(acGridView6, null);

                    break;

                case "OUT_APP_CANCEL": //승인취소

                    //btnApproval.Enabled = false;
                    btnApproval.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

                    //btnCancel.Enabled = true;
                    btnCancel.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

                    //btnReject.Enabled = false;
                    btnReject.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

                    //btnRejectCancel.Enabled = false;
                    btnRejectCancel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

                    focusRow = acGridView7.GetFocusedDataRow();

                    acGridView_RowCountChanged(acGridView7, null);

                    break;

                case "OUT_REJ_CANCEL": //반려취소

                    //btnApproval.Enabled = false;
                    btnApproval.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

                    //btnCancel.Enabled = false;
                    btnCancel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

                    //btnReject.Enabled = false;
                    btnReject.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

                    //btnRejectCancel.Enabled = true;
                    btnRejectCancel.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

                    focusRow = acGridView8.GetFocusedDataRow();

                    acGridView_RowCountChanged(acGridView8, null);

                    break;
            }

            this.GetDetail(focusRow);
        }
        private void acTabControl2_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            switch (acTabControl2.GetSelectedContainerName())
            {
                case "MAT":
                    acTabControl_SelectedPageChanged(acTabControl1, null);
                    break;

                case "OUT":
                    acTabControl_SelectedPageChanged(acTabControl3, null);
                    break;
            }
        }

        void acGridView1_ShowGridMenuEx(object sender, PopupMenuShowingEventArgs e)
        {
            acGridView view = sender as acGridView;

            if (e.HitInfo.HitTest == GridHitTest.EmptyRow || e.HitInfo.HitTest == GridHitTest.Row || e.HitInfo.HitTest == GridHitTest.RowCell)
            {

                if (e.MenuType == GridMenuType.User)
                {
                    acBarButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    acBarButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    acBarButtonItem3.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                }
                else if (e.MenuType == GridMenuType.Row)
                {
                    if (e.HitInfo.RowHandle >= 0)
                    {
                        acBarButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        acBarButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        acBarButtonItem3.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    }
                    else
                    {
                        acBarButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        acBarButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        acBarButtonItem3.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    }
                }

                GridHitInfo hitInfo = view.CalcHitInfo(e.Point);

                popupMenu1.ShowPopup(view.GridControl.PointToScreen(e.Point));

            }
        }

        private void acGridView_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            try
            {
                acGridView gridView = sender as acGridView;

                if (e.RowHandle < 0) return;

                string app1 = gridView.GetRowCellValue(e.RowHandle, "APP_EMP_FLAG1").ToString();
                string app2 = gridView.GetRowCellValue(e.RowHandle, "APP_EMP_FLAG2").ToString();
                string app3 = gridView.GetRowCellValue(e.RowHandle, "APP_EMP_FLAG3").ToString();
                string app4 = gridView.GetRowCellValue(e.RowHandle, "APP_EMP_FLAG4").ToString();

                if (e.Column.FieldName.StartsWith("APP_EMP"))
                {
                    if (e.Column.FieldName.IndexOf("1") > -1)
                    {
                        //if (app1 != "0")
                        //{
                        e.Appearance.BackColor = GetStatColor(app1);
                        e.Appearance.ForeColor = GetStatFontColor(app1);
                        //}
                    }
                    else if (e.Column.FieldName.IndexOf("2") > -1)
                    {
                        //if (app2 != "0")
                        //{
                        e.Appearance.BackColor = GetStatColor(app2);
                        e.Appearance.ForeColor = GetStatFontColor(app2);
                        //}
                    }
                    else if (e.Column.FieldName.IndexOf("3") > -1)
                    {
                        //if (app3 != "0")
                        //{
                        e.Appearance.BackColor = GetStatColor(app3);
                        e.Appearance.ForeColor = GetStatFontColor(app3);
                        //}
                    }
                    else if (e.Column.FieldName.IndexOf("4") > -1)
                    {
                        //if (app4 != "0")
                        //{
                        e.Appearance.BackColor = GetStatColor(app4);
                        e.Appearance.ForeColor = GetStatFontColor(app4);
                        //}
                    }
                }
            }
            catch { }
        }

        Color GetStatColor(string flag)
        {
            Color color = Color.Transparent;

            switch (flag)
            {
                case "0":
                    color = _progColor;
                    break;

                case "1":
                    color = _okColor;
                    break;

                case "2":
                    color = _denyColor;
                    break;
            }

            return color;
        }

        Color GetStatFontColor(string flag)
        {
            Color color = Color.Black;

            switch (flag)
            {
                case "0":
                    color = Color.Black;
                    break;

                case "1":
                    color = Color.Black;
                    break;

                case "2":
                    color = Color.Black;
                    break;
            }

            return color;
        }

        private void acGridView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                acGridView gridView = sender as acGridView;

                DataRow focusRow = gridView.GetFocusedDataRow();

                GetDetail(focusRow);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void acDetailGridView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                acGridView gridView = sender as acGridView;

                DataRow focusRow = gridView.GetFocusedDataRow();
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
                layout.GetEditor("DATE").Value = "BALJU_DATE";
                layout.GetEditor("S_DATE").Value = acDateEdit.GetNowMonth().AddMonths(-1);
                layout.GetEditor("E_DATE").Value = acDateEdit.GetNowDateFromServer();

            }

            base.ChildContainerInit(sender);
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
                        acLayoutControl1.GetEditor("S_DATE").isRequired = false;
                        acLayoutControl1.GetEditor("E_DATE").isRequired = false;


                    }
                    else
                    {
                        acLayoutControl1.GetEditor("S_DATE").isRequired = true;
                        acLayoutControl1.GetEditor("E_DATE").isRequired = true;
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

        void Search(string app = "all")
        {
            if (acLayoutControl1.ValidCheck() == false) return;

            DataRow layoutRow = acLayoutControl1.CreateParameterRow();

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String));
            paramTable.Columns.Add("BALJU_NUM_LIKE", typeof(String)); //
            paramTable.Columns.Add("S_BALJU_DATE", typeof(String));
            paramTable.Columns.Add("E_BALJU_DATE", typeof(String));
            paramTable.Columns.Add("BAL_TYPE", typeof(String)); //
            paramTable.Columns.Add("SER_TYPE", typeof(String)); //
            paramTable.Columns.Add("REG_EMP", typeof(String)); //
            paramTable.Columns.Add("IS_APP", typeof(Byte)); //

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["BALJU_NUM_LIKE"] = layoutRow["BALJU_NUM_LIKE"];

            foreach (string key in acCheckedComboBoxEdit1.GetKeyChecked())
            {
                switch (key)
                {
                    case "BALJU_DATE":

                        paramRow["S_BALJU_DATE"] = layoutRow["S_DATE"];
                        paramRow["E_BALJU_DATE"] = layoutRow["E_DATE"];

                        break;
                }
            }

            paramRow["BAL_TYPE"] = acTabControl2.GetSelectedContainerName();

            string SelectedContainerName = acTabControl2.GetSelectedContainerName();

            if (SelectedContainerName == "MAT")
            {
                paramRow["SER_TYPE"] = acTabControl1.GetSelectedContainerName();
            }
            else if (SelectedContainerName == "OUT")
            {
                paramRow["SER_TYPE"] = acTabControl3.GetSelectedContainerName();
            }
            
            paramRow["REG_EMP"] = acInfo.UserID;

            if (app == "APP")
            {
                paramRow["IS_APP"] = "1";
            }

            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();

            paramSet.Tables.Add(paramTable);

            BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD, "SAN02A_SER", paramSet, "RQSTDT", "RSLTDT",
            QuickSearch,
            QuickException);
        }

        void QuickSearch(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                switch (e.result.Tables["RQSTDT"].Rows[0]["SER_TYPE"].ToString())
                {
                    case "MAT_REQ_APP":
                        acGridView1.GridControl.DataSource = e.result.Tables["RSLTDT"];
                        acGridView1.BestFitColumns();
                        break;

                    case "MAT_APP_CANCEL":
                        acGridView3.GridControl.DataSource = e.result.Tables["RSLTDT"];
                        acGridView3.BestFitColumns();
                        break;

                    case "MAT_REJ_CANCEL":
                        acGridView4.GridControl.DataSource = e.result.Tables["RSLTDT"];
                        acGridView4.BestFitColumns();
                        break;

                    case "OUT_REQ_APP":
                        acGridView6.GridControl.DataSource = e.result.Tables["RSLTDT"];
                        acGridView6.BestFitColumns();
                        break;

                    case "OUT_APP_CANCEL":
                        acGridView7.GridControl.DataSource = e.result.Tables["RSLTDT"];
                        acGridView7.BestFitColumns();
                        break;

                    case "OUT_REJ_CANCEL":
                        acGridView8.GridControl.DataSource = e.result.Tables["RSLTDT"];
                        acGridView8.BestFitColumns();
                        break;

                }

                base.SetLog(e.executeType, e.result.Tables["RSLTDT"].Rows.Count, e.executeTime);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void QuickException(object sender, QBiz QBiz, BizManager.BizException ex)
        {
            acMessageBox.Show(this, ex);
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

        void GetDetail(DataRow focusRow)
        {
            //DataRow focusRow = acGridView1.GetFocusedDataRow();

            string SelectedContainerName = acTabControl2.GetSelectedContainerName();

            if (focusRow == null)
            {
                if (SelectedContainerName == "MAT")
                {
                    acGridView2.ClearRow();
                    acAttachFileControl1.LinkKey = null;
                    acAttachFileControl1.ShowKey = null;
                    return;
                }
                else if (SelectedContainerName == "OUT")
                {
                    acGridView9.ClearRow();
                    acAttachFileControl2.LinkKey = null;
                    acAttachFileControl2.ShowKey = null;
                    return;
                }
            }
            else
            {
                if (SelectedContainerName == "MAT")
                {
                    acAttachFileControl1.LinkKey = focusRow["BALJU_NUM"].ToString() + "_PUR";
                    acAttachFileControl1.ShowKey = new object[] { focusRow["BALJU_NUM"].ToString() + "_PUR" };
                }
                else if (SelectedContainerName == "OUT")
                {
                    acAttachFileControl2.LinkKey = focusRow["BALJU_NUM"].ToString() + "_PUR";
                    acAttachFileControl2.ShowKey = new object[] { focusRow["BALJU_NUM"].ToString() + "_PUR" };
                }
            }

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(string));
            paramTable.Columns.Add("BALJU_NUM", typeof(string));
            //paramTable.Columns.Add("BALJU_SEQ", typeof(string));
            paramTable.Columns.Add("LOG_SER_TYPE", typeof(string));

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["BALJU_NUM"] = focusRow["BALJU_NUM"];
            //paramRow["BALJU_SEQ"] = focusRow["BALJU_SEQ"];
            paramRow["LOG_SER_TYPE"] = SelectedContainerName;

            paramTable.Rows.Add(paramRow);


            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD_DETAIL, "SAN02A_SER2", paramSet, "RQSTDT", "RSLTDT",
            QuickDetailSearch,
            QuickException);
        }

        void QuickDetailSearch(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {

                if (e.result.Tables["RQSTDT"].Rows[0]["LOG_SER_TYPE"].ToString() == "MAT")
                {
                    acGridView2.GridControl.DataSource = e.result.Tables["RSLTDT"];

                    acGridView2.BestFitColumns();

                    return;
                }
                else if (e.result.Tables["RQSTDT"].Rows[0]["LOG_SER_TYPE"].ToString() == "OUT")
                {
                    acGridView9.GridControl.DataSource = e.result.Tables["RSLTDT"];

                    acGridView9.BestFitColumns();

                    return;
                }

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void acBarButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                //승인
                acGridView gridView = null;
                if (acTabControl2.GetSelectedContainerName() == "MAT")
                {
                    gridView = acGridView1;
                }
                else if (acTabControl2.GetSelectedContainerName() == "OUT")
                {
                    gridView = acGridView6;
                }


                gridView.EndEditor();

                DataRow focusRow = gridView.GetFocusedDataRow();

                if (focusRow == null) return;

                DataRow[] selected = gridView.GetSelectedDataRows();

                if (acMessageBox.Show(this, "정말 승인 하시겠습니까?", "", false, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
                {
                    return;
                }

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("REG_EMP", typeof(String));
                paramTable.Columns.Add("PLT_CODE", typeof(String));
                paramTable.Columns.Add("BALJU_NUM", typeof(String));
                paramTable.Columns.Add("APP_FLAG", typeof(String));
                paramTable.Columns.Add("BAL_SER_TYPE", typeof(String));
                paramTable.Columns.Add("SER_TYPE", typeof(String));

                if (selected.Length == 0)
                {
                    //단일승인

                    if (focusRow["APP_EMP_FLAG1"].ToString() != "1")
                    {
                        if (focusRow["APP_EMP1"].ToString() != acInfo.UserID)
                        {
                            return;
                        }
                    }
                    else if (focusRow["APP_EMP_FLAG2"].ToString() != "1")
                    {
                        if (focusRow["APP_EMP2"].ToString() != acInfo.UserID)
                        {
                            return;
                        }
                    }
                    else if (focusRow["APP_EMP_FLAG3"].ToString() != "1")
                    {
                        if (focusRow["APP_EMP3"].ToString() != acInfo.UserID)
                        {
                            return;
                        }
                    }
                    else if (focusRow["APP_EMP_FLAG4"].ToString() != "1")
                    {
                        if (focusRow["APP_EMP4"].ToString() != acInfo.UserID)
                        {
                            return;
                        }
                    }

                    DataRow paramRow = paramTable.NewRow();
                    paramRow["REG_EMP"] = acInfo.UserID;
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["BALJU_NUM"] = focusRow["BALJU_NUM"];
                    paramRow["APP_FLAG"] = "1";
                    paramRow["BAL_SER_TYPE"] = acTabControl2.GetSelectedContainerName();
                    paramRow["SER_TYPE"] = acTabControl1.GetSelectedContainerName();
                    paramTable.Rows.Add(paramRow);
                }
                else
                {
                    //다중승인
                    //for (int i = 0; i < selectedView.Count; i++)
                    foreach (DataRow row in selected)
                    {
                        if (row["APP_EMP_FLAG1"].ToString() != "1")
                        {
                            if (row["APP_EMP1"].ToString() != acInfo.UserID)
                            {
                                continue;
                            }
                        }
                        else if (row["APP_EMP_FLAG2"].ToString() != "1")
                        {
                            if (row["APP_EMP2"].ToString() != acInfo.UserID)
                            {
                                continue;
                            }
                        }
                        else if (row["APP_EMP_FLAG3"].ToString() != "1")
                        {
                            if (row["APP_EMP3"].ToString() != acInfo.UserID)
                            {
                                continue;
                            }
                        }
                        else if (row["APP_EMP_FLAG4"].ToString() != "1")
                        {
                            if (row["APP_EMP4"].ToString() != acInfo.UserID)
                            {
                                continue;
                            }
                        }

                        DataRow paramRow = paramTable.NewRow();
                        paramRow["REG_EMP"] = acInfo.UserID;
                        paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                        paramRow["BALJU_NUM"] = row["BALJU_NUM"];
                        paramRow["APP_FLAG"] = "1";
                        paramRow["BAL_SER_TYPE"] = acTabControl2.GetSelectedContainerName();
                        paramRow["SER_TYPE"] = acTabControl1.GetSelectedContainerName();
                        paramTable.Rows.Add(paramRow);
                    }
                }

                DataSet paramSet = new DataSet();

                if (paramTable.Rows.Count > 0)
                {
                    paramSet.Tables.Add(paramTable);

                    BizRun.QBizRun.ExecuteService(
                    this, QBiz.emExecuteType.PROCESS,
                    "SAN02A_UPD", paramSet, "RQSTDT", "RSLTDT",
                    QuickUPD,
                    QuickException);
                }
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
                acGridView gridView = null;
                if (acTabControl2.GetSelectedContainerName() == "MAT")
                {
                    gridView = acGridView1;
                }
                else if (acTabControl2.GetSelectedContainerName() == "OUT")
                {
                    gridView = acGridView6;
                }

                foreach (DataRow row in e.result.Tables["RQSTDT"].Rows)
                {
                    gridView.DeleteMappingRow(row);
                }

                gridView.RaiseFocusedRowChanged();

                acAlert.Show(this, "승인되었습니다.", acAlertForm.enmType.Success);
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
                //승인취소
                acGridView gridView = null;
                if (acTabControl2.GetSelectedContainerName() == "MAT")
                {
                    gridView = acGridView3;
                }
                else if (acTabControl2.GetSelectedContainerName() == "OUT")
                {
                    gridView = acGridView7;
                }

                gridView.EndEditor();

                DataRow focusRow = gridView.GetFocusedDataRow();

                if (focusRow == null) return;

                if (acMessageBox.Show(this, "정말 승인취소 하시겠습니까?", "", false, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
                {
                    return;
                }

                //DataView selectedView = gridView.GetDataSourceView("SEL = '1'");
                DataRow[] selected = gridView.GetSelectedDataRows();

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("REG_EMP", typeof(String));
                paramTable.Columns.Add("PLT_CODE", typeof(String));
                paramTable.Columns.Add("BALJU_NUM", typeof(String));
                paramTable.Columns.Add("APP_FLAG", typeof(String));
                paramTable.Columns.Add("SER_TYPE", typeof(String));
                paramTable.Columns.Add("BAL_SER_TYPE", typeof(String));

                if (selected.Length == 0)
                {
                    //단일승인취소

                    DataRow paramRow = paramTable.NewRow();
                    paramRow["REG_EMP"] = acInfo.UserID;
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["BALJU_NUM"] = focusRow["BALJU_NUM"];
                    paramRow["APP_FLAG"] = "0";
                    paramRow["BAL_SER_TYPE"] = acTabControl2.GetSelectedContainerName();
                    paramRow["SER_TYPE"] = acTabControl1.GetSelectedContainerName();
                    paramTable.Rows.Add(paramRow);
                }
                else
                {
                    //다중승인취소
                    //for (int i = 0; i < selectedView.Count; i++)
                    foreach (DataRow row in selected)
                    {
                        DataRow paramRow = paramTable.NewRow();
                        paramRow["REG_EMP"] = acInfo.UserID;
                        paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                        paramRow["BALJU_NUM"] = row["BALJU_NUM"];
                        paramRow["APP_FLAG"] = "0";
                        paramRow["BAL_SER_TYPE"] = acTabControl2.GetSelectedContainerName();
                        paramRow["SER_TYPE"] = acTabControl1.GetSelectedContainerName();
                        paramTable.Rows.Add(paramRow);
                    }
                }

                DataSet paramSet = new DataSet();

                paramSet.Tables.Add(paramTable);


                BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.PROCESS,
                "SAN02A_UPD2", paramSet, "RQSTDT", "RSLTDT",
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
                acGridView gridView = null;
                if (acTabControl2.GetSelectedContainerName() == "MAT")
                {
                    gridView = acGridView3;
                }
                else if (acTabControl2.GetSelectedContainerName() == "OUT")
                {
                    gridView = acGridView7;
                }

                foreach (DataRow row in e.result.Tables["RQSTDT"].Rows)
                {
                    gridView.DeleteMappingRow(row);
                }

                gridView.RaiseFocusedRowChanged();

                acAlert.Show(this, "승인취소되었습니다.", acAlertForm.enmType.Warning);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        private void acBarButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                //반려
                acGridView gridView = null;
                if (acTabControl2.GetSelectedContainerName() == "MAT")
                {
                    gridView = acGridView1;
                }
                else if (acTabControl2.GetSelectedContainerName() == "OUT")
                {
                    gridView = acGridView6;
                }

                gridView.EndEditor();

                DataRow focusRow = gridView.GetFocusedDataRow();

                if (focusRow == null) return;

                if (acMessageBox.Show(this, "정말 반려 하시겠습니까?", "", false, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
                {
                    return;
                }

                //DataView selectedView = gridView.GetDataSourceView("SEL = '1'");
                DataRow[] selected = gridView.GetSelectedDataRows();

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("REG_EMP", typeof(String));
                paramTable.Columns.Add("PLT_CODE", typeof(String));
                paramTable.Columns.Add("BALJU_NUM", typeof(String));
                paramTable.Columns.Add("APP_FLAG", typeof(String));
                paramTable.Columns.Add("BAL_SER_TYPE", typeof(String));
                paramTable.Columns.Add("SER_TYPE", typeof(String));

                if (selected.Length == 0)
                {
                    //단일반려

                    if (focusRow["APP_EMP_FLAG1"].ToString() != "1")
                    {
                        if (focusRow["APP_EMP1"].ToString() != acInfo.UserID)
                        {
                            return;
                        }
                    }
                    else if (focusRow["APP_EMP_FLAG2"].ToString() != "1")
                    {
                        if (focusRow["APP_EMP2"].ToString() != acInfo.UserID)
                        {
                            return;
                        }
                    }
                    else if (focusRow["APP_EMP_FLAG3"].ToString() != "1")
                    {
                        if (focusRow["APP_EMP3"].ToString() != acInfo.UserID)
                        {
                            return;
                        }
                    }
                    else if (focusRow["APP_EMP_FLAG4"].ToString() != "1")
                    {
                        if (focusRow["APP_EMP4"].ToString() != acInfo.UserID)
                        {
                            return;
                        }
                    }

                    DataRow paramRow = paramTable.NewRow();
                    paramRow["REG_EMP"] = acInfo.UserID;
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["BALJU_NUM"] = focusRow["BALJU_NUM"];
                    paramRow["APP_FLAG"] = "2";
                    paramRow["BAL_SER_TYPE"] = acTabControl2.GetSelectedContainerName();
                    paramRow["SER_TYPE"] = acTabControl1.GetSelectedContainerName();
                    paramTable.Rows.Add(paramRow);
                }
                else
                {
                    //다중반려
                    foreach (DataRow row in selected)
                    {
                        if (row["APP_EMP_FLAG1"].ToString() != "1")
                        {
                            if (row["APP_EMP1"].ToString() != acInfo.UserID)
                            {
                                continue;
                            }
                        }
                        else if (row["APP_EMP_FLAG2"].ToString() != "1")
                        {
                            if (row["APP_EMP2"].ToString() != acInfo.UserID)
                            {
                                continue;
                            }
                        }
                        else if (row["APP_EMP_FLAG3"].ToString() != "1")
                        {
                            if (row["APP_EMP3"].ToString() != acInfo.UserID)
                            {
                                continue;
                            }
                        }
                        else if (row["APP_EMP_FLAG4"].ToString() != "1")
                        {
                            if (row["APP_EMP4"].ToString() != acInfo.UserID)
                            {
                                continue;
                            }
                        }

                        DataRow paramRow = paramTable.NewRow();
                        paramRow["REG_EMP"] = acInfo.UserID;
                        paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                        paramRow["BALJU_NUM"] = row["BALJU_NUM"];
                        paramRow["APP_FLAG"] = "2";
                        paramRow["BAL_SER_TYPE"] = acTabControl2.GetSelectedContainerName();
                        paramRow["SER_TYPE"] = acTabControl1.GetSelectedContainerName();
                        paramTable.Rows.Add(paramRow);
                    }
                }

                DataSet paramSet = new DataSet();

                paramSet.Tables.Add(paramTable);

                if (paramTable.Rows.Count > 0)
                {
                    BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.PROCESS,
                "SAN02A_UPD3", paramSet, "RQSTDT", "RSLTDT",
                QuickUPD3,
                QuickException);
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void QuickUPD3(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                acGridView gridView = null;
                if (acTabControl2.GetSelectedContainerName() == "MAT")
                {
                    gridView = acGridView1;
                }
                else if (acTabControl2.GetSelectedContainerName() == "OUT")
                {
                    gridView = acGridView6;
                }

                foreach (DataRow row in e.result.Tables["RQSTDT"].Rows)
                {
                    gridView.DeleteMappingRow(row);
                }

                gridView.RaiseFocusedRowChanged();

                acAlert.Show(this, "반려되었습니다.", acAlertForm.enmType.Error);
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
                //반려취소
                acGridView gridView = null;
                if (acTabControl2.GetSelectedContainerName() == "MAT")
                {
                    gridView = acGridView4;
                }
                else if (acTabControl2.GetSelectedContainerName() == "OUT")
                {
                    gridView = acGridView8;
                }

                gridView.EndEditor();

                DataRow focusRow = gridView.GetFocusedDataRow();

                if (focusRow == null) return;

                if (acMessageBox.Show(this, "정말 반려취소 하시겠습니까?", "", false, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
                {
                    return;
                }

                //DataView selectedView = gridView.GetDataSourceView("SEL = '1'");
                DataRow[] selected = gridView.GetSelectedDataRows();

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("REG_EMP", typeof(String));
                paramTable.Columns.Add("PLT_CODE", typeof(String));
                paramTable.Columns.Add("BALJU_NUM", typeof(String));
                paramTable.Columns.Add("APP_FLAG", typeof(String));
                paramTable.Columns.Add("BAL_SER_TYPE", typeof(String));
                paramTable.Columns.Add("SER_TYPE", typeof(String));

                if (selected.Length == 0)
                {
                    //단일반려

                    DataRow paramRow = paramTable.NewRow();
                    paramRow["REG_EMP"] = acInfo.UserID;
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["BALJU_NUM"] = focusRow["BALJU_NUM"];
                    paramRow["APP_FLAG"] = "0";
                    paramRow["BAL_SER_TYPE"] = acTabControl2.GetSelectedContainerName();
                    paramRow["SER_TYPE"] = acTabControl1.GetSelectedContainerName();
                    paramTable.Rows.Add(paramRow);
                }
                else
                {
                    //다중반려
                    foreach (DataRow row in selected)
                    {
                        DataRow paramRow = paramTable.NewRow();
                        paramRow["REG_EMP"] = acInfo.UserID;
                        paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                        paramRow["BALJU_NUM"] = row["BALJU_NUM"];
                        paramRow["APP_FLAG"] = "0";
                        paramRow["BAL_SER_TYPE"] = acTabControl2.GetSelectedContainerName();
                        paramRow["SER_TYPE"] = acTabControl1.GetSelectedContainerName();
                        paramTable.Rows.Add(paramRow);
                    }
                }

                DataSet paramSet = new DataSet();

                paramSet.Tables.Add(paramTable);


                BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.PROCESS,
                "SAN02A_UPD2", paramSet, "RQSTDT", "RSLTDT",
                QuickUPD4,
                QuickException);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void QuickUPD4(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                acGridView gridView = null;
                if (acTabControl2.GetSelectedContainerName() == "MAT")
                {
                    gridView = acGridView4;
                }
                else if (acTabControl2.GetSelectedContainerName() == "OUT")
                {
                    gridView = acGridView8;
                }

                foreach (DataRow row in e.result.Tables["RQSTDT"].Rows)
                {
                    gridView.DeleteMappingRow(row);
                }

                gridView.RaiseFocusedRowChanged();

                acAlert.Show(this, "반려취소되었습니다.", acAlertForm.enmType.Warning);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void acBarButtonItem4_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //조회
            try
            {
                this.Search("APP");
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }
    }
}

