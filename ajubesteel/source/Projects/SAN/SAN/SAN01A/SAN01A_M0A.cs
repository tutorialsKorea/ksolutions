using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ControlManager;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Base;
using BizManager;
using DevExpress.XtraGrid.Columns;

namespace SAN
{
    public sealed partial class SAN01A_M0A : BaseMenu
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

        public SAN01A_M0A()
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

        private DataSet _WorkSet = null;
        private DataSet _WorkTimeSet = null;

        public override void MenuInit()
        {
            acGridView1.GridType = acGridView.emGridType.SEARCH_SEL;

            DataSet resultSet = BizRun.QBizRun.ExecuteService(this, "CTRL", "GET_EMPLOYEE", acInfo.RefData, "RQSTDT", "RSLTDT");

            //acGridView1.AddCheckEdit("SEL", "선택", "", false, true, true, acGridView.emCheckEditDataType._STRING);
            acGridView1.AddTextEdit("WORK_ID", "ID", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("ORG_CODE", "부서코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("ORG_NAME", "부서명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("EMP_CODE", "신청자코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("EMP_NAME", "신청자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("WORK_CODE", "근태코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("WORK_NAME", "근태명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddDateEdit("REQ_START_DATE", "시작시간", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.MEDIUM_DATE2);
            acGridView1.AddDateEdit("REQ_END_DATE", "종료시간", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.MEDIUM_DATE2);

            acGridView1.AddTextEdit("REQ_DAY", "일단위", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.F1);
            acGridView1.Columns["REQ_DAY"].Summary.Add(DevExpress.Data.SummaryItemType.Sum, "REQ_DAY", "합계={0:N1}");

            acGridView1.AddTextEdit("REQ_HOUR", "신청시간", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.F1);
            acGridView1.Columns["REQ_HOUR"].Summary.Add(DevExpress.Data.SummaryItemType.Sum, "REQ_HOUR", "합계={0:N1}");
            acGridView1.AddTextEdit("REQ_TIME", "신청시간(분)", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NUMERIC);
            acGridView1.Columns["REQ_TIME"].Summary.Add(DevExpress.Data.SummaryItemType.Sum, "REQ_TIME", "합계={0:N0}");
            acGridView1.AddDateEdit("REQ_DATE", "신청일시", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.MEDIUM_DATE2);
            acGridView1.AddLookUpEdit("REQ_AMPM", "반차 구분", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "W005");
            acGridView1.AddLookUpEdit("OUT_TYPE", "외근 구분", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "W011");
            acGridView1.AddCheckEdit("IS_DIR_IN", "직출여부", "", false, false, true, acGridView.emCheckEditDataType._STRING);
            acGridView1.AddCheckEdit("IS_DIR_OUT", "직퇴여부", "", false, false, true, acGridView.emCheckEditDataType._STRING);
            acGridView1.AddTextEdit("OUT_VEN_CODE", "업체코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("OUT_VEN_NAME", "업체명", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddLookUpEdit("REQ_STATUS", "상태", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "W008");
            acGridView1.AddTextEdit("REQ_SCOMMENT", "신청내용", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("APP_SCOMMENT", "비고", "", false, DevExpress.Utils.HorzAlignment.Near, false, false, false, acGridView.emTextEditMask.NONE);

            //acGridView1.AddLookUpEmp("APP_EMP1", "승인자1", string.Empty, false, DevExpress.Utils.HorzAlignment.Center, false, true, false);
            acGridView1.AddLookUpEdit("APP_EMP1", "승인자1", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "EMP_NAME", "EMP_CODE", resultSet.Tables["RSLTDT"]);
            acGridView1.AddTextEdit("APP_EMP_FLAG1", "승인자1상태", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            //acGridView1.AddLookUpEmp("APP_EMP2", "승인자2", string.Empty, false, DevExpress.Utils.HorzAlignment.Center, false, true, false);
            acGridView1.AddLookUpEdit("APP_EMP2", "승인자2", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "EMP_NAME", "EMP_CODE", resultSet.Tables["RSLTDT"]);
            acGridView1.AddTextEdit("APP_EMP_FLAG2", "승인자2상태", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            //acGridView1.AddLookUpEmp("APP_EMP3", "승인자3", string.Empty, false, DevExpress.Utils.HorzAlignment.Center, false, true, false);
            acGridView1.AddLookUpEdit("APP_EMP3", "승인자3", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "EMP_NAME", "EMP_CODE", resultSet.Tables["RSLTDT"]);
            acGridView1.AddTextEdit("APP_EMP_FLAG3", "승인자3상태", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            //acGridView1.AddLookUpEmp("APP_EMP4", "승인자4", string.Empty, false, DevExpress.Utils.HorzAlignment.Center, false, true, false);
            acGridView1.AddLookUpEdit("APP_EMP4", "승인자4", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "EMP_NAME", "EMP_CODE", resultSet.Tables["RSLTDT"]);
            acGridView1.AddTextEdit("APP_EMP_FLAG4", "승인자4상태", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddHidden("IS_OUT", typeof(string));

            acGridView1.KeyColumn = new string[] { "WORK_ID" };


            acGridView2.GridType = acGridView.emGridType.SEARCH_SEL;

            acGridView2.AddTextEdit("WORK_ID", "ID", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("ORG_CODE", "부서코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("ORG_NAME", "부서명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("EMP_CODE", "신청자코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("EMP_NAME", "신청자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("WORK_CODE", "근태코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("WORK_NAME", "근태명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddDateEdit("REQ_START_DATE", "시작시간", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.MEDIUM_DATE2);
            acGridView2.AddDateEdit("REQ_END_DATE", "종료시간", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.MEDIUM_DATE2);

            acGridView2.AddTextEdit("REQ_DAY", "일단위", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.F1);
            acGridView2.Columns["REQ_DAY"].Summary.Add(DevExpress.Data.SummaryItemType.Sum, "REQ_DAY", "합계={0:N1}");

            acGridView2.AddTextEdit("REQ_HOUR", "신청시간", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.F1);
            acGridView2.Columns["REQ_HOUR"].Summary.Add(DevExpress.Data.SummaryItemType.Sum, "REQ_HOUR", "합계={0:N1}");
            acGridView2.AddDateEdit("REQ_DATE", "신청일시", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.MEDIUM_DATE2);
            acGridView2.AddCheckEdit("IS_DIR_IN", "직출여부", "", false, false, true, acGridView.emCheckEditDataType._STRING);
            acGridView2.AddCheckEdit("IS_DIR_OUT", "직퇴여부", "", false, false, true, acGridView.emCheckEditDataType._STRING);
            acGridView2.AddTextEdit("OUT_VEN_CODE", "업체코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("OUT_VEN_NAME", "업체명", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddLookUpEdit("REQ_STATUS", "상태", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "W008");
            acGridView2.AddTextEdit("REQ_SCOMMENT", "신청내용", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("APP_SCOMMENT", "비고", "", false, DevExpress.Utils.HorzAlignment.Near, false, false, false, acGridView.emTextEditMask.NONE);

            //acGridView2.AddLookUpEmp("APP_EMP1", "승인자1", string.Empty, false, DevExpress.Utils.HorzAlignment.Center, false, true, false);
            acGridView2.AddLookUpEdit("APP_EMP1", "승인자1", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "EMP_NAME", "EMP_CODE", resultSet.Tables["RSLTDT"]);
            acGridView2.AddTextEdit("APP_EMP_FLAG1", "승인자1상태", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            //acGridView2.AddLookUpEmp("APP_EMP2", "승인자2", string.Empty, false, DevExpress.Utils.HorzAlignment.Center, false, true, false);
            acGridView2.AddLookUpEdit("APP_EMP2", "승인자2", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "EMP_NAME", "EMP_CODE", resultSet.Tables["RSLTDT"]);
            acGridView2.AddTextEdit("APP_EMP_FLAG2", "승인자2상태", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            //acGridView2.AddLookUpEmp("APP_EMP3", "승인자3", string.Empty, false, DevExpress.Utils.HorzAlignment.Center, false, true, false);
            acGridView2.AddLookUpEdit("APP_EMP3", "승인자3", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "EMP_NAME", "EMP_CODE", resultSet.Tables["RSLTDT"]);
            acGridView2.AddTextEdit("APP_EMP_FLAG3", "승인자3상태", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            //acGridView2.AddLookUpEmp("APP_EMP4", "승인자4", string.Empty, false, DevExpress.Utils.HorzAlignment.Center, false, true, false);
            acGridView2.AddLookUpEdit("APP_EMP4", "승인자4", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "EMP_NAME", "EMP_CODE", resultSet.Tables["RSLTDT"]);
            acGridView2.AddTextEdit("APP_EMP_FLAG4", "승인자4상태", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);

            acGridView2.AddHidden("IS_OUT", typeof(string));

            acGridView2.KeyColumn = new string[] { "WORK_ID" };


            acGridView3.GridType = acGridView.emGridType.SEARCH_SEL;

            acGridView3.AddTextEdit("WORK_ID", "ID", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView3.AddTextEdit("ORG_CODE", "부서코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView3.AddTextEdit("ORG_NAME", "부서명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView3.AddTextEdit("EMP_CODE", "신청자코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView3.AddTextEdit("EMP_NAME", "신청자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView3.AddTextEdit("WORK_CODE", "근태코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView3.AddTextEdit("WORK_NAME", "근태명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView3.AddDateEdit("REQ_START_DATE", "시작시간", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.MEDIUM_DATE2);
            acGridView3.AddDateEdit("REQ_END_DATE", "종료시간", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.MEDIUM_DATE2);

            acGridView3.AddTextEdit("REQ_DAY", "일단위", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.F1);
            acGridView3.Columns["REQ_DAY"].Summary.Add(DevExpress.Data.SummaryItemType.Sum, "REQ_DAY", "합계={0:N1}");

            acGridView3.AddTextEdit("REQ_HOUR", "신청시간", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.F1);
            acGridView3.Columns["REQ_HOUR"].Summary.Add(DevExpress.Data.SummaryItemType.Sum, "REQ_HOUR", "합계={0:N1}");
            acGridView3.AddDateEdit("REQ_DATE", "신청일시", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.MEDIUM_DATE2);
            acGridView3.AddCheckEdit("IS_DIR_IN", "직출여부", "", false, false, true, acGridView.emCheckEditDataType._STRING);
            acGridView3.AddCheckEdit("IS_DIR_OUT", "직퇴여부", "", false, false, true, acGridView.emCheckEditDataType._STRING);
            acGridView3.AddTextEdit("OUT_VEN_CODE", "업체코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView3.AddTextEdit("OUT_VEN_NAME", "업체명", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView3.AddLookUpEdit("REQ_STATUS", "상태", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "W008");
            acGridView3.AddTextEdit("REQ_SCOMMENT", "신청내용", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView3.AddDateEdit("REJECT_DATE", "반려일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
            acGridView3.AddTextEdit("REJECT_REASON", "반려사유", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView3.AddTextEdit("APP_SCOMMENT", "비고", "", false, DevExpress.Utils.HorzAlignment.Near, false, false, false, acGridView.emTextEditMask.NONE);

            //acGridView3.AddLookUpEmp("APP_EMP1", "승인자1", string.Empty, false, DevExpress.Utils.HorzAlignment.Center, false, true, false);
            acGridView3.AddLookUpEdit("APP_EMP1", "승인자1", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "EMP_NAME", "EMP_CODE", resultSet.Tables["RSLTDT"]);
            acGridView3.AddTextEdit("APP_EMP_FLAG1", "승인자1상태", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            //acGridView3.AddLookUpEmp("APP_EMP2", "승인자2", string.Empty, false, DevExpress.Utils.HorzAlignment.Center, false, true, false);
            acGridView3.AddLookUpEdit("APP_EMP2", "승인자2", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "EMP_NAME", "EMP_CODE", resultSet.Tables["RSLTDT"]);
            acGridView3.AddTextEdit("APP_EMP_FLAG2", "승인자2상태", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            //acGridView3.AddLookUpEmp("APP_EMP3", "승인자3", string.Empty, false, DevExpress.Utils.HorzAlignment.Center, false, true, false);
            acGridView3.AddLookUpEdit("APP_EMP3", "승인자3", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "EMP_NAME", "EMP_CODE", resultSet.Tables["RSLTDT"]);
            acGridView3.AddTextEdit("APP_EMP_FLAG3", "승인자3상태", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            //acGridView3.AddLookUpEmp("APP_EMP4", "승인자4", string.Empty, false, DevExpress.Utils.HorzAlignment.Center, false, true, false);
            acGridView3.AddLookUpEdit("APP_EMP4", "승인자4", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "EMP_NAME", "EMP_CODE", resultSet.Tables["RSLTDT"]);
            acGridView3.AddTextEdit("APP_EMP_FLAG4", "승인자4상태", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);

            acGridView3.AddHidden("IS_OUT", typeof(string));

            acGridView3.KeyColumn = new string[] { "WORK_ID" };

            

            acLayoutControl1.OnValueKeyDown += new acLayoutControl.ValueKeyDownEventHandler(acLayoutControl1_OnValueKeyDown);

            acLayoutControl1.OnValueChanged += new acLayoutControl.ValueChangedEventHandler(acLayoutControl1_OnValueChanged);

            acGridView1.CustomDrawCell += acGridView_CustomDrawCell;
            acGridView2.CustomDrawCell += acGridView_CustomDrawCell;
            acGridView3.CustomDrawCell += acGridView_CustomDrawCell;

            acGridView1.FocusedRowChanged += acGridView_FocusedRowChanged;
            acGridView2.FocusedRowChanged += acGridView_FocusedRowChanged;
            acGridView3.FocusedRowChanged += acGridView_FocusedRowChanged;

            acCheckedComboBoxEdit1.AddItem("신청일", false, "", "REQ_DATE", true, false);
            acCheckedComboBoxEdit1.AddItem("신청시작일", false, "", "REQ_START_DATE", true, false);

            _WorkSet = BizRun.QBizRun.ExecuteService(this, "WOR01A_SER2", acInfo.RefData, "RQSTDT", "RSLTDT");

            (acLayoutControl1.GetEditor("WORK_CODE") as acLookupEdit).SetData("WORK_NAME", "WORK_CODE", _WorkSet.Tables["RSLTDT"]);

            _WorkTimeSet = BizRun.QBizRun.ExecuteService(this, "WOR01A_SER4", acInfo.RefData, "RQSTDT", "RSLTDT");

            DateTime nowDate = acDateEdit.GetNowDateFromServer();

            //string[] bands1 = new string[] { "구분", nowDate.Year.ToString() + "년" };

            //acBandGridView1.AddTextEdit("YEAR", nowDate.Year.ToString() + "년", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acBandGridView.emTextEditMask.NONE, bands1);


            //string[] bands2 = new string[] { "분단위 기록", "지각" };
            //string[] bands3 = new string[] { "분단위 기록", "외출" };
            //string[] bands4 = new string[] { "분단위 기록", "조퇴" };
            //string[] bands5 = new string[] { "분단위 기록", "무급" };

            //acBandGridView1.AddTextEdit("W01", "지각", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.NONE, bands2);
            //acBandGridView1.AddTextEdit("W02", "외출", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.NONE, bands3);
            //acBandGridView1.AddTextEdit("W03", "조퇴", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.NONE, bands4);
            //acBandGridView1.AddTextEdit("W04", "무급", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.NONE, bands5);


            //string[] bands6 = new string[] { "일단위 기록", "연차\r\n반차" };
            //string[] bands7 = new string[] { "일단위 기록", "경조" };

            //acBandGridView1.AddTextEdit("W05_W06", "연차\r\n반차", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.NONE, bands6);
            //acBandGridView1.AddTextEdit("W07", "경조", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.NONE, bands7);


            //string[] bands8 = new string[] { nowDate.Year.ToString() + "년" + " 고정값", "월근무\r\n일수" };
            //string[] bands9 = new string[] { nowDate.Year.ToString() + "년" + " 고정값", "월별\r\n최대\r\n시간\r\n(주52)" };
            //string[] bands10 = new string[] { nowDate.Year.ToString() + "년" + " 고정값", "기본근무\r\n일수\r\n(근무일수*8)" };

            //acBandGridView1.AddTextEdit("WORK_DAY", "월근무\r\n일수", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.NONE, bands8);
            //acBandGridView1.AddTextEdit("WORK_MONTH_TIME", "월별\r\n최대\r\n시간\r\n(주52)", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.NONE, bands9);
            //acBandGridView1.AddTextEdit("WORK_HOUR", "기본근무\r\n일수\r\n(근무일수*8)", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.NONE, bands10);


            //string[] bands11 = new string[] { "시간단위 기록", "지,조\r\n외출\r\n연차\r\n시간" };
            //string[] bands12 = new string[] { "시간단위 기록", "실근무시간" };
            //string[] bands13 = new string[] { "시간단위 기록", "월잔여\r\n가능\r\n시간" };
            //string[] bands14 = new string[] { "시간단위 기록", "연장\r\n누계\r\n시간" };

            //acBandGridView1.AddTextEdit("HOLI_TIME", "지,조\r\n외출\r\n연차\r\n시간", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.NONE, bands11);
            //acBandGridView1.AddTextEdit("WORK_TIME", "실근무시간", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.NONE, bands12);
            //acBandGridView1.AddTextEdit("REMAIN_TIME", "월잔여\r\n가능\r\n시간", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.NONE, bands13);
            //acBandGridView1.AddTextEdit("CUM_TIME", "연장\r\n누계\r\n시간", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.NONE, bands14);

            //int iBands1 = 1;
            //int iBands2 = 1;
            //int iBands3 = 1;
            //int iBands4 = 1;
            //foreach (DataRow row in _WorkTimeSet.Tables["RSLTDT"].Rows)
            //{
            //    if (row["WORK_CODE"].ToString() == "W08")
            //    {
            //        string sTime = row["WORK_START_HOUR"].ToString().Substring(0, 2) + ":" + row["WORK_START_HOUR"].ToString().Substring(2, 2);
            //        string eTime = row["WORK_END_HOUR"].ToString().Substring(0, 2) + ":" + row["WORK_END_HOUR"].ToString().Substring(2, 2);
            //        string[] bands = new string[] { "시간단위 기록", row["WORK_NAME"].ToString(), sTime, eTime, row["WORK_RATE"].ToString() };

            //        acBandGridView1.AddTextEdit(row["WORK_CODE"].ToString() + "_" + iBands1.ToString(), row["WORK_NAME"].ToString(), "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.NONE, bands);
            //        acBandGridView1.Columns[row["WORK_CODE"].ToString() + "_" + iBands1.ToString()].Tag = row["WORK_START_HOUR"].ToString() + "-" + row["WORK_END_HOUR"].ToString();
            //        iBands1++;
            //    }
            //    else if (row["WORK_CODE"].ToString() == "W09")
            //    {
            //        string sTime = row["WORK_START_HOUR"].ToString().Substring(0, 2) + ":" + row["WORK_START_HOUR"].ToString().Substring(2, 2);
            //        string eTime = row["WORK_END_HOUR"].ToString().Substring(0, 2) + ":" + row["WORK_END_HOUR"].ToString().Substring(2, 2);
            //        string[] bands = new string[] { "시간단위 기록", row["WORK_NAME"].ToString(), sTime, eTime, row["WORK_RATE"].ToString() };

            //        acBandGridView1.AddTextEdit(row["WORK_CODE"].ToString() + "_" + iBands2.ToString(), row["WORK_NAME"].ToString(), "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.NONE, bands);
            //        acBandGridView1.Columns[row["WORK_CODE"].ToString() + "_" + iBands2.ToString()].Tag = row["WORK_START_HOUR"].ToString() + "-" + row["WORK_END_HOUR"].ToString();
            //        iBands2++;
            //    }
            //    else if (row["WORK_CODE"].ToString() == "W10")
            //    {
            //        string sTime = row["WORK_START_HOUR"].ToString().Substring(0, 2) + ":" + row["WORK_START_HOUR"].ToString().Substring(2, 2);
            //        string eTime = row["WORK_END_HOUR"].ToString().Substring(0, 2) + ":" + row["WORK_END_HOUR"].ToString().Substring(2, 2);
            //        string[] bands = new string[] { "시간단위 기록", row["WORK_NAME"].ToString(), sTime, eTime, row["WORK_RATE"].ToString() };

            //        acBandGridView1.AddTextEdit(row["WORK_CODE"].ToString() + "_" + iBands3.ToString(), row["WORK_NAME"].ToString(), "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.NONE, bands);
            //        acBandGridView1.Columns[row["WORK_CODE"].ToString() + "_" + iBands3.ToString()].Tag = row["WORK_START_HOUR"].ToString() + "-" + row["WORK_END_HOUR"].ToString();
            //        iBands3++;
            //    }
            //    else if (row["WORK_CODE"].ToString() == "W11")
            //    {
            //        string sTime = row["WORK_START_HOUR"].ToString().Substring(0, 2) + ":" + row["WORK_START_HOUR"].ToString().Substring(2, 2);
            //        string eTime = row["WORK_END_HOUR"].ToString().Substring(0, 2) + ":" + row["WORK_END_HOUR"].ToString().Substring(2, 2);
            //        string[] bands = new string[] { "시간단위 기록", row["WORK_NAME"].ToString(), sTime, eTime, row["WORK_RATE"].ToString() };

            //        acBandGridView1.AddTextEdit(row["WORK_CODE"].ToString() + "_" + iBands4.ToString(), row["WORK_NAME"].ToString(), "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.NONE, bands);
            //        acBandGridView1.Columns[row["WORK_CODE"].ToString() + "_" + iBands4.ToString()].Tag = row["WORK_START_HOUR"].ToString() + "-" + row["WORK_END_HOUR"].ToString();
            //        iBands4++;
            //    }
            //}

            //acBandGridView1.BestFitColumns();
            //acBandGridView1.ColumnPanelRowHeight = 100;
            //acBandGridView1.OptionsView.ShowColumnHeaders = false;

            //acBandGridView1.Bands[0].Visible = false;

            btnApproval.Enabled = false;
            btnApproval.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

            btnCancel.Enabled = false;
            btnCancel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            btnReject.Enabled = false;
            btnReject.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

            btnRejectCancel.Enabled = false;
            btnRejectCancel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            acTabControl1.SelectedPageChanged += acTabControl1_SelectedPageChanged;

            acGridView1.RowCountChanged += acGridView_RowCountChanged;
            acGridView2.RowCountChanged += acGridView_RowCountChanged;
            acGridView3.RowCountChanged += acGridView_RowCountChanged;

            acGridView1.ShowGridMenuEx += acGridView1_ShowGridMenuEx;

            base.MenuInit();
        }

        private void acGridView1_ShowGridMenuEx(object sender, PopupMenuShowingEventArgs e)
        {
            acGridView view = sender as acGridView;

            if (e.HitInfo.HitTest == GridHitTest.EmptyRow || e.HitInfo.HitTest == GridHitTest.Row || e.HitInfo.HitTest == GridHitTest.RowCell)
            {
                if (e.MenuType == GridMenuType.User)
                {
                    acBarSubItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    acBarButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    acBarButtonItem3.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                }
                else if (e.MenuType == GridMenuType.Row)
                {
                    if (e.HitInfo.RowHandle >= 0)
                    {
                        acBarSubItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        acBarButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        acBarButtonItem3.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    }
                    else
                    {
                        acBarSubItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        acBarButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        acBarButtonItem3.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    }
                }

                GridHitInfo hitInfo = view.CalcHitInfo(e.Point);

                popupMenu1.ShowPopup(view.GridControl.PointToScreen(e.Point));

            }
        }

        private void acGridView_RowCountChanged(object sender, EventArgs e)
        {
            acGridView gridView = sender as acGridView;

            string tabName = acTabControl1.GetSelectedContainerName();

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
                case "REQ_APP":
                    btnApproval.Enabled = isEnabled;
                    btnReject.Enabled = isEnabled;
                    break;

                case "APP_CANCEL":
                    btnCancel.Enabled = isEnabled;
                    break;

                case "REJ_CANCEL":
                    btnRejectCancel.Enabled = isEnabled;
                    break;
            }
        }

        private void acTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            acTabControl tabControl = sender as acTabControl;
            DataRow focusRow = null;
            switch (tabControl.GetSelectedContainerName())
            {
                case "REQ_APP": //신청 승인/반려

                    //btnApproval.Enabled = true;
                    btnApproval.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    
                    //btnCancel.Enabled = false;
                    btnCancel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

                    //btnReject.Enabled = true;
                    btnReject.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    
                    //btnRejectCancel.Enabled = false;
                    btnRejectCancel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

                    focusRow = acGridView1.GetFocusedDataRow();

                    break;

                case "APP_CANCEL": //승인취소

                    //btnApproval.Enabled = false;
                    btnApproval.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

                    //btnCancel.Enabled = true;
                    btnCancel.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    
                    //btnReject.Enabled = false;
                    btnReject.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    
                    //btnRejectCancel.Enabled = false;
                    btnRejectCancel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

                    focusRow = acGridView2.GetFocusedDataRow();

                    break;

                case "REJ_CANCEL": //반려취소

                    //btnApproval.Enabled = false;
                    btnApproval.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

                    //btnCancel.Enabled = false;
                    btnCancel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    
                    //btnReject.Enabled = false;
                    btnReject.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    
                    //btnRejectCancel.Enabled = true;
                    btnRejectCancel.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

                    focusRow = acGridView3.GetFocusedDataRow();

                    break;
            }

            //this.Getdetail(focusRow);
        }

        private void acGridView_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            //try
            //{
            //    acGridView gridView = sender as acGridView;

            //    DataRow focusRow = gridView.GetFocusedDataRow();
            //    this.Getdetail(focusRow);
            //}
            //catch (Exception ex)
            //{
            //    acMessageBox.Show(this, ex);
            //}
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

        public override void ChildContainerInit(Control sender)
        {
            if (sender == acLayoutControl1)
            {
                acLayoutControl layout = sender as acLayoutControl;

                layout.GetEditor("DATE").Value = "REQ_DATE";
                layout.GetEditor("S_DATE").Value = acDateEdit.GetNowFirstDate().AddMonths(-1);
                layout.GetEditor("E_DATE").Value = acDateEdit.GetNowLastDate();
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

        void Search()
        {
            if (acLayoutControl1.ValidCheck() == false) return;

            DataRow layoutRow = acLayoutControl1.CreateParameterRow();

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("EMP_LIKE", typeof(String)); //
            paramTable.Columns.Add("REG_EMP", typeof(String)); //
            paramTable.Columns.Add("WORK_CODE", typeof(String)); //
            paramTable.Columns.Add("S_REQ_DATE", typeof(String)); //
            paramTable.Columns.Add("E_REQ_DATE", typeof(String)); //
            paramTable.Columns.Add("S_REQ_START_DATE", typeof(String)); //
            paramTable.Columns.Add("E_REQ_START_DATE", typeof(String)); //
            paramTable.Columns.Add("SER_TYPE", typeof(String)); //

            //paramTable.Columns.Add("IS_FIN", typeof(String)); //

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["EMP_LIKE"] = layoutRow["EMP_LIKE"];
            paramRow["REG_EMP"] = acInfo.UserID;
            paramRow["WORK_CODE"] = layoutRow["WORK_CODE"];

            foreach (string key in acCheckedComboBoxEdit1.GetKeyChecked())
            {
                switch (key)
                {

                    case "REQ_DATE":

                        paramRow["S_REQ_DATE"] = layoutRow["S_DATE"];
                        paramRow["E_REQ_DATE"] = layoutRow["E_DATE"];

                        break;

                    case "REQ_START_DATE":

                        paramRow["S_REQ_START_DATE"] = layoutRow["S_DATE"];
                        paramRow["E_REQ_START_DATE"] = layoutRow["E_DATE"];

                        break;
                }
            }

            paramRow["SER_TYPE"] = acTabControl1.GetSelectedContainerName();
            //paramRow["IS_FIN"] = layoutRow["IS_FIN"];

            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();

            paramSet.Tables.Add(paramTable);

            BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD, "SAN01A_SER", paramSet, "RQSTDT", "RSLTDT",
            QuickSearch,
            QuickException);
        }

        void QuickSearch(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                switch (e.result.Tables["RQSTDT"].Rows[0]["SER_TYPE"].ToString())
                {
                    case "REQ_APP":
                        acGridView1.GridControl.DataSource = e.result.Tables["RSLTDT"];
                        acGridView1.BestFitColumns();

                        break;

                    case "APP_CANCEL":
                        acGridView2.GridControl.DataSource = e.result.Tables["RSLTDT"];
                        acGridView2.BestFitColumns();

                        break;

                    case "REJ_CANCEL":
                        acGridView3.GridControl.DataSource = e.result.Tables["RSLTDT"];
                        acGridView3.BestFitColumns();

                        break;
                }

                base.SetLog(e.executeType, e.result.Tables["RSLTDT"].Rows.Count, e.executeTime);

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void NonAppSearch()
        {
            DataRow layoutRow = acLayoutControl1.CreateParameterRow();

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("EMP_LIKE", typeof(String)); //
            paramTable.Columns.Add("REG_EMP", typeof(String)); //
            paramTable.Columns.Add("WORK_CODE", typeof(String)); //
            paramTable.Columns.Add("SER_TYPE", typeof(String)); //

            //paramTable.Columns.Add("IS_FIN", typeof(String)); //

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["EMP_LIKE"] = layoutRow["EMP_LIKE"];
            paramRow["REG_EMP"] = acInfo.UserID;
            paramRow["WORK_CODE"] = layoutRow["WORK_CODE"];

            paramRow["SER_TYPE"] = acTabControl1.GetSelectedContainerName();
            //paramRow["IS_FIN"] = "1";

            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();

            paramSet.Tables.Add(paramTable);

            BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD, "SAN01A_SER", paramSet, "RQSTDT", "RSLTDT",
            QuickSearch,
            QuickException);
        }

        void QuickException(object sender, QBiz QBiz, BizManager.BizException ex)
        {
            //acMessageBox.Show(this, ex);

            acMessageBox.Show(this, ex.Message, "", false, acMessageBox.emMessageBoxType.CONFIRM);
        }

        //void Getdetail(DataRow focusRow)
        //{
        //    //DataRow focusRow = acGridView1.GetFocusedDataRow();

        //    if (focusRow != null)
        //    {
        //        DataTable paramTable = new DataTable("RQSTDT");
        //        paramTable.Columns.Add("PLT_CODE", typeof(String)); //
        //        paramTable.Columns.Add("EMP_CODE", typeof(String)); //
        //        paramTable.Columns.Add("REQ_YEAR", typeof(String)); //
        //        paramTable.Columns.Add("REQ_STATUS", typeof(String)); //

        //        DataRow paramRow = paramTable.NewRow();
        //        paramRow["PLT_CODE"] = acInfo.PLT_CODE;
        //        paramRow["EMP_CODE"] = focusRow["EMP_CODE"];
        //        paramRow["REQ_YEAR"] = focusRow["REQ_START_DATE"].toDateString("yyyy");
        //        paramRow["REQ_STATUS"] = "2";

        //        paramTable.Rows.Add(paramRow);
        //        DataSet paramSet = new DataSet();

        //        paramSet.Tables.Add(paramTable);

        //        BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD, "SAN01A_SER2", paramSet, "RQSTDT", "RSLTDT",
        //        QuickSearchDetail,
        //        QuickException);
        //    }
        //    else
        //    {
        //        acBandGridView1.ClearRow();
        //    }

        //}

        //void QuickSearchDetail(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        //{
        //    //근로현황데이터 가공

        //    DataTable gridTable = ((DataTable)acBandGridView1.GridControl.DataSource).Clone();

        //    //합계 저장 dictionary
        //    Dictionary<string, decimal> sumDic = new Dictionary<string, decimal>();

        //    for (int i = 1; i <= 12; i++)
        //    {
        //        DataRow newRow = gridTable.NewRow();
        //        newRow["YEAR"] = i.ToString() + "월";

        //        string month = e.result.Tables["RQSTDT"].Rows[0]["REQ_YEAR"].ToString() + Convert.ToString(i).PadLeft(2, '0');

        //        DataRow[] reqRwos = e.result.Tables["RSLTDT_YEAR"].Select("REQ_START_MONTH = '" + month + "'");

        //        foreach (DataRow row in reqRwos)
        //        {
        //            //분단위 - 지각(W01), 외출(W02), 조퇴(W03), 무급(W04)
        //            //일단위 - 연차/반차(W05/W06), 경조(W07)
        //            //시간단위 - 잔업(W08), 교대(W09), 특근(W10), 휴일교대(W11)
        //            switch (row["WORK_CODE"].ToString())
        //            {
        //                case "W01": //지각

        //                    newRow["W01"] = newRow["W01"].toInt() + row["REQ_TIME"].toInt();

        //                    //합계 - 누적저장
        //                    if (sumDic.ContainsKey("W01"))
        //                    {
        //                        sumDic["W01"] = sumDic["W01"] + row["REQ_TIME"].toInt();
        //                    }
        //                    else
        //                    {
        //                        sumDic.Add("W01", newRow["W01"].toDecimal());
        //                    }

        //                    break;

        //                case "W02": //외출

        //                    newRow["W02"] = newRow["W02"].toInt() + row["REQ_TIME"].toInt();

        //                    //합계 - 누적저장
        //                    if (sumDic.ContainsKey("W02"))
        //                    {
        //                        sumDic["W02"] = sumDic["W02"] + row["REQ_TIME"].toInt();
        //                    }
        //                    else
        //                    {
        //                        sumDic.Add("W02", newRow["W02"].toDecimal());
        //                    }

        //                    break;

        //                case "W03": //조퇴

        //                    newRow["W03"] = newRow["W03"].toInt() + row["REQ_TIME"].toInt();

        //                    //합계 - 누적저장
        //                    if (sumDic.ContainsKey("W03"))
        //                    {
        //                        sumDic["W03"] = sumDic["W03"] + row["REQ_TIME"].toInt();
        //                    }
        //                    else
        //                    {
        //                        sumDic.Add("W03", newRow["W03"].toDecimal());
        //                    }

        //                    break;

        //                case "W04": //무급

        //                    newRow["W04"] = newRow["W04"].toInt() + row["REQ_TIME"].toInt();

        //                    //합계 - 누적저장
        //                    if (sumDic.ContainsKey("W04"))
        //                    {
        //                        sumDic["W04"] = sumDic["W04"] + row["REQ_TIME"].toInt();
        //                    }
        //                    else
        //                    {
        //                        sumDic.Add("W04", newRow["W04"].toDecimal());
        //                    }

        //                    break;

        //                case "W05": //연차
        //                case "W06": //반차

        //                    newRow["W05_W06"] = Math.Round(((newRow["W05_W06"].toDecimal() * 480) + row["REQ_TIME"].toDecimal()).toDecimal() / 480, 1);

        //                    //합계 - 누적저장
        //                    if (sumDic.ContainsKey("W05_W06"))
        //                    {
        //                        sumDic["W05_W06"] = sumDic["W05_W06"] + Math.Round((row["REQ_TIME"].toDecimal()).toDecimal() / 480, 1);
        //                    }
        //                    else
        //                    {
        //                        sumDic.Add("W05_W06", newRow["W05_W06"].toDecimal());
        //                    }

        //                    break;

        //                case "W07": //경조

        //                    newRow["W07"] = Math.Round(((newRow["W07"].toDecimal() * 480) + row["REQ_TIME"].toDecimal()).toDecimal() / 480, 1);

        //                    //합계 - 누적저장
        //                    if (sumDic.ContainsKey("W07"))
        //                    {
        //                        sumDic["W07"] = sumDic["W07"] + Math.Round((row["REQ_TIME"].toDecimal()).toDecimal() / 480, 1);
        //                    }
        //                    else
        //                    {
        //                        sumDic.Add("W07", newRow["W07"].toDecimal());
        //                    }

        //                    break;

        //                case "W08": //잔업
        //                case "W09": //교대
        //                case "W10": //특근
        //                case "W11": //휴일교대

        //                    //기준시간의 교집합구하기
        //                    //1.신청시간에 기준시간 시작시간과 종료시간이 포함된경우
        //                    //2.기준시작시간이 신청시간 사이에 있는경우
        //                    //3.기준시간에 신청시간 시작시간과 종료시간이 포함된경우
        //                    //5.기준종료시간이 신청시간 사이에 있는경우
        //                    DataRow[] workRows = _WorkTimeSet.Tables["RSLTDT"].Select("WORK_CODE = '" + row["WORK_CODE"].ToString() + "'");

        //                    int iSeq = 1;
        //                    foreach (DataRow workRow in workRows)
        //                    {
        //                        DateTime reqStartDateTime = row["REQ_START_DATE"].toDateTime();
        //                        DateTime reqEndDateTime = row["REQ_END_DATE"].toDateTime();

        //                        DateTime stdStartDate = new DateTime(reqStartDateTime.Year, reqStartDateTime.Month, reqStartDateTime.Day, workRow["WORK_START_HOUR"].ToString().Substring(0, 2).toInt(), workRow["WORK_START_HOUR"].ToString().Substring(2, 2).toInt(), 0);
        //                        DateTime stdEndDate = new DateTime(reqStartDateTime.Year, reqStartDateTime.Month, reqStartDateTime.Day, workRow["WORK_END_HOUR"].ToString().Substring(0, 2).toInt(), workRow["WORK_END_HOUR"].ToString().Substring(2, 2).toInt(), 0);

        //                        //종료시간이 작을경우 하루 더함
        //                        if (workRow["WORK_START_HOUR"].ToString().Substring(0, 2).toInt() > workRow["WORK_END_HOUR"].ToString().Substring(0, 2).toInt())
        //                        {
        //                            stdEndDate = stdEndDate.AddDays(1);
        //                        }

        //                        if (workRows[0]["WORK_START_HOUR"].toInt() > workRow["WORK_START_HOUR"].toInt())
        //                        {
        //                            stdStartDate = stdStartDate.AddDays(1);
        //                            stdEndDate = stdEndDate.AddDays(1);
        //                        }

        //                        TimeSpan ts = new TimeSpan();
        //                        //시간 교집합 구분
        //                        if (reqStartDateTime < stdStartDate && reqEndDateTime > stdEndDate) //신청시간에 기준시간 시작시간과 종료시간이 포함된경우
        //                        {
        //                            ts = stdEndDate.Subtract(stdStartDate);
        //                            newRow[row["WORK_CODE"].ToString() + "_" + iSeq.ToString()] = Math.Round(((newRow[row["WORK_CODE"].ToString() + "_" + iSeq.ToString()].toDouble() * 60) + ts.TotalMinutes).toDecimal() / 60, 1);
        //                        }
        //                        else if (reqStartDateTime < stdStartDate && reqEndDateTime > stdStartDate) //기준시작시간이 신청시간 사이에 있는경우
        //                        {
        //                            ts = reqEndDateTime.Subtract(stdStartDate);
        //                            newRow[row["WORK_CODE"].ToString() + "_" + iSeq.ToString()] = Math.Round(((newRow[row["WORK_CODE"].ToString() + "_" + iSeq.ToString()].toDouble() * 60) + ts.TotalMinutes).toDecimal() / 60, 1);
        //                        }
        //                        else if (stdStartDate < reqStartDateTime && stdEndDate > reqEndDateTime) //기준시간에 신청시간 시작시간과 종료시간이 포함된경우
        //                        {
        //                            ts = reqEndDateTime.Subtract(reqStartDateTime);
        //                            newRow[row["WORK_CODE"].ToString() + "_" + iSeq.ToString()] = Math.Round(((newRow[row["WORK_CODE"].ToString() + "_" + iSeq.ToString()].toDouble() * 60) + ts.TotalMinutes).toDecimal() / 60, 1);
        //                        }
        //                        else if (reqStartDateTime < stdEndDate && reqEndDateTime > stdEndDate) //기준종료시간이 신청시간 사이에 있는경우
        //                        {
        //                            ts = stdEndDate.Subtract(reqStartDateTime);
        //                            newRow[row["WORK_CODE"].ToString() + "_" + iSeq.ToString()] = Math.Round(((newRow[row["WORK_CODE"].ToString() + "_" + iSeq.ToString()].toDouble() * 60) + ts.TotalMinutes).toDecimal() / 60, 1);
        //                        }

        //                        if (ts.TotalMinutes > 0)
        //                        {
        //                            //합계 - 누적저장
        //                            if (sumDic.ContainsKey(row["WORK_CODE"].ToString() + "_" + iSeq.ToString()))
        //                            {
        //                                sumDic[row["WORK_CODE"].ToString() + "_" + iSeq.ToString()] = sumDic[row["WORK_CODE"].ToString() + "_" + iSeq.ToString()] + Math.Round((ts.TotalMinutes).toDecimal() / 60, 1);
        //                            }
        //                            else
        //                            {
        //                                sumDic.Add(row["WORK_CODE"].ToString() + "_" + iSeq.ToString(), newRow[row["WORK_CODE"].ToString() + "_" + iSeq.ToString()].toDecimal());
        //                            }
        //                        }

        //                        //야간근무를 제외한 연장 누계시간
        //                        if (workRow["NIGHT_FLAG"].ToString() != "1")
        //                        {
        //                            newRow["CUM_TIME"] = newRow["CUM_TIME"].toDecimal() + newRow[row["WORK_CODE"].ToString() + "_" + iSeq.ToString()].toDecimal();
        //                        }

        //                        //합계 - 누적저장
        //                        if (sumDic.ContainsKey("CUM_TIME"))
        //                        {
        //                            sumDic["CUM_TIME"] = sumDic["CUM_TIME"] + newRow[row["WORK_CODE"].ToString() + "_" + iSeq.ToString()].toDecimal();
        //                        }
        //                        else
        //                        {
        //                            sumDic.Add("CUM_TIME", newRow["CUM_TIME"].toDecimal());
        //                        }

        //                        iSeq++;
        //                    }

        //                    break;
        //            }
        //        }

        //        //지,조 외출 연차 시간 : (지각/60 + 외출/60 + 조퇴/60 + 무급/60) + 연차반차 * 8  + 경조 * 8
        //        newRow["HOLI_TIME"] = (Math.Round((newRow["W01"].toDecimal() / 60), 2) + Math.Round((newRow["W02"].toDecimal() / 60), 2) + Math.Round((newRow["W03"].toDecimal() / 60), 2) + Math.Round((newRow["W04"].toDecimal() / 60), 2))
        //           + (newRow["W05_W06"].toDecimal() * 8) + (newRow["W07"].toDecimal() * 8);

        //        //고정값
        //        DataRow[] dayRows = e.result.Tables["RSLTDT_WORKDAY"].Select("WORK_MONTH = '" + month + "'");
        //        if (dayRows.Length > 0)
        //        {
        //            newRow["WORK_DAY"] = dayRows[0]["WORK_DAY"];
        //            newRow["WORK_MONTH_TIME"] = dayRows[0]["WORK_MONTH_TIME"];
        //            newRow["WORK_HOUR"] = dayRows[0]["WORK_HOUR"];
        //        }

        //        //실근무시간 : (기본근무시간 + 연장누계시간) - 지,조 외출연차시간
        //        newRow["WORK_TIME"] = newRow["WORK_HOUR"].toDecimal() + newRow["CUM_TIME"].toDecimal() - newRow["HOLI_TIME"].toDecimal();

        //        //월잔여시간 : 월별최대시간 - 실근무시간
        //        newRow["REMAIN_TIME"] = newRow["WORK_MONTH_TIME"].toDecimal() - newRow["WORK_TIME"].toDecimal();

        //        gridTable.Rows.Add(newRow);
        //    }

        //    //합계
        //    DataRow sumRow = gridTable.NewRow();
        //    sumRow["YEAR"] = "합계";

        //    foreach (DataColumn col in gridTable.Columns)
        //    {
        //        if (sumDic.ContainsKey(col.ColumnName))
        //        {
        //            sumRow[col.ColumnName] = sumDic[col.ColumnName];
        //        }
        //    }

        //    gridTable.Rows.Add(sumRow);

        //    //사용
        //    DataRow useRow = gridTable.NewRow();
        //    useRow["YEAR"] = "사용";
        //    useRow["W01"] = "연차 : ";
        //    if (sumDic.ContainsKey("W05_W06"))
        //    {
        //        useRow["W02"] = sumDic["W05_W06"];
        //    }

        //    //분기별 잔여시간 : 1분기
        //    int iquarter = 0;
        //    int remainQuarter = 0;
        //    foreach (DataRow row in gridTable.Rows)
        //    {
        //        if (iquarter >= 0)
        //        {
        //            remainQuarter = (remainQuarter.toDecimal() + (row["WORK_MONTH_TIME"].toDecimal() - row["WORK_TIME"].toDecimal())).toInt();

        //            if (iquarter > 1)
        //            {
        //                break;
        //            }
        //        }
        //        iquarter++;
        //    }

        //    useRow["W11_1"] = "1/4";
        //    useRow["W11_2"] = remainQuarter;
        //    gridTable.Rows.Add(useRow);

        //    //내역
        //    DataRow conRow = gridTable.NewRow();
        //    conRow["YEAR"] = "내역";
        //    conRow["W01"] = "경조 : ";
        //    if (sumDic.ContainsKey("W07"))
        //    {
        //        conRow["W02"] = sumDic["W07"];
        //    }

        //    //분기별 잔여시간 : 2분기
        //    iquarter = 0;
        //    remainQuarter = 0;
        //    foreach (DataRow row in gridTable.Rows)
        //    {
        //        if (iquarter >= 3)
        //        {
        //            remainQuarter = (remainQuarter.toDecimal() + (row["WORK_MONTH_TIME"].toDecimal() - row["WORK_TIME"].toDecimal())).toInt();

        //            if (iquarter > 4)
        //            {
        //                break;
        //            }
        //        }
        //        iquarter++;
        //    }

        //    conRow["W11_1"] = "2/4";
        //    conRow["W11_2"] = remainQuarter;

        //    gridTable.Rows.Add(conRow);

        //    //발생
        //    DataRow occRow = gridTable.NewRow();
        //    occRow["YEAR"] = "발생";
        //    occRow["W01"] = "연차 : ";
        //    double dHoli = 0.0;
        //    if (e.result.Tables["RSLTDT_EMP_HOLI"].Rows.Count > 0)
        //    {
        //        dHoli = e.result.Tables["RSLTDT_EMP_HOLI"].Rows[0]["HOLI_OCCUR_INPUT_CNT"].toDouble();
        //    }
        //    occRow["W02"] = dHoli;

        //    //분기별 잔여시간 : 3분기
        //    iquarter = 0;
        //    remainQuarter = 0;
        //    foreach (DataRow row in gridTable.Rows)
        //    {
        //        if (iquarter >= 6)
        //        {
        //            remainQuarter = (remainQuarter.toDecimal() + (row["WORK_MONTH_TIME"].toDecimal() - row["WORK_TIME"].toDecimal())).toInt();

        //            if (iquarter > 7)
        //            {
        //                break;
        //            }
        //        }
        //        iquarter++;
        //    }

        //    occRow["W11_1"] = "3/4";
        //    occRow["W11_2"] = remainQuarter;

        //    gridTable.Rows.Add(occRow);

        //    //사용
        //    DataRow useRow2 = gridTable.NewRow();
        //    useRow2["YEAR"] = "사용";
        //    useRow2["W01"] = "연차 : ";


        //    //분기별 잔여시간 : 4분기
        //    iquarter = 0;
        //    remainQuarter = 0;
        //    foreach (DataRow row in gridTable.Rows)
        //    {
        //        if (iquarter >= 9)
        //        {
        //            remainQuarter = (remainQuarter.toDecimal() + (row["WORK_MONTH_TIME"].toDecimal() - row["WORK_TIME"].toDecimal())).toInt();

        //            if (iquarter > 10)
        //            {
        //                break;
        //            }
        //        }
        //        iquarter++;
        //    }

        //    useRow2["W11_1"] = "4/4";
        //    useRow2["W11_2"] = remainQuarter;

        //    gridTable.Rows.Add(useRow2);

        //    //남은
        //    DataRow remainRow = gridTable.NewRow();
        //    remainRow["YEAR"] = "남은";
        //    remainRow["W01"] = "연차 : ";
        //    double dUseHoli = 0.0;
        //    if (sumDic.ContainsKey("W05_W06"))
        //    {
        //        dUseHoli = sumDic["W05_W06"].toDouble(); ;
        //    }

        //    remainRow["W02"] = dHoli - dUseHoli;
        //    gridTable.Rows.Add(remainRow);

        //    acBandGridView1.GridControl.DataSource = gridTable;
        //    acBandGridView1.OptionsView.ShowColumnHeaders = true;
        //    acBandGridView1.BestFitColumns();
        //    acBandGridView1.OptionsView.ShowColumnHeaders = false;
        //}

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

        private void btnApproval_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //승인
            try
            {
                acGridView1.EndEditor();

                DataRow focusRow = acGridView1.GetFocusedDataRow();

                if (focusRow == null) return;

                if (acMessageBox.Show(this, "정말 승인 하시겠습니까?", "", false, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
                {
                    return;
                }

                //DataView selectedView = acGridView1.GetDataSourceView("SEL = '1'");
                DataRow[] selected = acGridView1.GetSelectedDataRows();

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("REG_EMP", typeof(String));
                paramTable.Columns.Add("PLT_CODE", typeof(String));
                paramTable.Columns.Add("WORK_ID", typeof(String));
                paramTable.Columns.Add("APP_FLAG", typeof(String));
                paramTable.Columns.Add("SER_TYPE", typeof(String));
                paramTable.Columns.Add("APP_TYPE", typeof(String));

                if (selected.Length == 0)
                {
                    //단일승인

                    DataRow paramRow = paramTable.NewRow();
                    paramRow["REG_EMP"] = acInfo.UserID;
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["WORK_ID"] = focusRow["WORK_ID"];
                    paramRow["APP_FLAG"] = "1";
                    paramRow["SER_TYPE"] = acTabControl1.GetSelectedContainerName();

                    string appType = "ATD";

                    if (focusRow["IS_OUT"].ToString() == "1")
                    {
                        appType = "OUT";
                    }

                    paramRow["APP_TYPE"] = appType;

                    paramTable.Rows.Add(paramRow);
                }
                else
                {
                    //다중승인
                    //for (int i = 0; i < selectedView.Count; i++)
                    foreach(DataRow row in selected)
                    {
                        DataRow paramRow = paramTable.NewRow();
                        paramRow["REG_EMP"] = acInfo.UserID;
                        paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                        paramRow["WORK_ID"] = row["WORK_ID"];
                        paramRow["APP_FLAG"] = "1";
                        paramRow["SER_TYPE"] = acTabControl1.GetSelectedContainerName();

                        string appType = "ATD";

                        if (row["IS_OUT"].ToString() == "1")
                        {
                            appType = "OUT";
                        }

                        paramRow["APP_TYPE"] = appType;

                        paramTable.Rows.Add(paramRow);
                    }
                }

                DataSet paramSet = new DataSet();

                paramSet.Tables.Add(paramTable);


                BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.PROCESS,
                "SAN01A_UPD", paramSet, "RQSTDT", "RSLTDT",
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
                foreach (DataRow row in e.result.Tables["RQSTDT"].Rows)
                {
                    acGridView1.DeleteMappingRow(row);
                }

                acAlert.Show(this, "승인되었습니다.", acAlertForm.enmType.Success);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        private void btnCancel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //승인취소
            try
            {
                acGridView2.EndEditor();

                DataRow focusRow = acGridView2.GetFocusedDataRow();

                if (focusRow == null) return;

                if (acMessageBox.Show(this, "정말 승인취소 하시겠습니까?", "", false, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
                {
                    return;
                }

                //DataView selectedView = acGridView2.GetDataSourceView("SEL = '1'");
                DataRow[] selected = acGridView2.GetSelectedDataRows();

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("REG_EMP", typeof(String));
                paramTable.Columns.Add("PLT_CODE", typeof(String));
                paramTable.Columns.Add("WORK_ID", typeof(String));
                paramTable.Columns.Add("APP_FLAG", typeof(String));
                paramTable.Columns.Add("SER_TYPE", typeof(String));
                paramTable.Columns.Add("APP_TYPE", typeof(String));

                if (selected.Length == 0)
                {
                    //단일승인취소

                    DataRow paramRow = paramTable.NewRow();
                    paramRow["REG_EMP"] = acInfo.UserID;
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["WORK_ID"] = focusRow["WORK_ID"];
                    paramRow["APP_FLAG"] = "0";
                    paramRow["SER_TYPE"] = acTabControl1.GetSelectedContainerName();

                    string appType = "ATD";

                    if (focusRow["IS_OUT"].ToString() == "1")
                    {
                        appType = "OUT";
                    }

                    paramRow["APP_TYPE"] = appType;

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
                        paramRow["WORK_ID"] = row["WORK_ID"];
                        paramRow["APP_FLAG"] = "0";
                        paramRow["SER_TYPE"] = acTabControl1.GetSelectedContainerName();

                        string appType = "ATD";

                        if (row["IS_OUT"].ToString() == "1")
                        {
                            appType = "OUT";
                        }

                        paramRow["APP_TYPE"] = appType;

                        paramTable.Rows.Add(paramRow);
                    }
                }

                DataSet paramSet = new DataSet();

                paramSet.Tables.Add(paramTable);


                BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.PROCESS,
                "SAN01A_UPD2", paramSet, "RQSTDT", "RSLTDT",
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
                foreach (DataRow row in e.result.Tables["RQSTDT"].Rows)
                {
                    acGridView2.DeleteMappingRow(row);
                }

                acAlert.Show(this, "승인취소되었습니다.", acAlertForm.enmType.Warning);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        private void btnReject_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //반려
            try
            {
                acGridView1.EndEditor();

                DataRow focusRow = acGridView1.GetFocusedDataRow();

                if (focusRow == null) return;

                //if (acMessageBox.Show(this, "정말 반려 하시겠습니까?", "", false, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
                //{
                //    return;
                //}

                SAN01A_D0A frm = new SAN01A_D0A();

                frm.ParentControl = this;
                frm.DialogMode = BaseMenuDialog.emDialogMode.NEW;

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    DataRow frmRow = (DataRow)frm.OutputData;

                    //DataView selectedView = acGridView1.GetDataSourceView("SEL = '1'");
                    DataRow[] selected = acGridView1.GetSelectedDataRows();

                    DataTable paramTable = new DataTable("RQSTDT");
                    paramTable.Columns.Add("REG_EMP", typeof(String));
                    paramTable.Columns.Add("PLT_CODE", typeof(String));
                    paramTable.Columns.Add("WORK_ID", typeof(String));
                    paramTable.Columns.Add("REJECT_DATE", typeof(String));
                    paramTable.Columns.Add("REJECT_REASON", typeof(String));
                    paramTable.Columns.Add("APP_FLAG", typeof(String));
                    paramTable.Columns.Add("SER_TYPE", typeof(String));
                    paramTable.Columns.Add("APP_TYPE", typeof(String));

                    if (selected.Length == 0)
                    {
                        //단일반려

                        DataRow paramRow = paramTable.NewRow();
                        paramRow["REG_EMP"] = acInfo.UserID;
                        paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                        paramRow["WORK_ID"] = focusRow["WORK_ID"];
                        paramRow["REJECT_DATE"] = frmRow["REJECT_DATE"];
                        paramRow["REJECT_REASON"] = frmRow["REJECT_REASON"];
                        paramRow["APP_FLAG"] = "2";
                        paramRow["SER_TYPE"] = acTabControl1.GetSelectedContainerName();

                        string appType = "ATD";

                        if (focusRow["IS_OUT"].ToString() == "1")
                        {
                            appType = "OUT";
                        }

                        paramRow["APP_TYPE"] = appType;

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
                            paramRow["WORK_ID"] = row["WORK_ID"];
                            paramRow["REJECT_DATE"] = frmRow["REJECT_DATE"];
                            paramRow["REJECT_REASON"] = frmRow["REJECT_REASON"];
                            paramRow["APP_FLAG"] = "2";
                            paramRow["SER_TYPE"] = acTabControl1.GetSelectedContainerName();

                            string appType = "ATD";

                            if (row["IS_OUT"].ToString() == "1")
                            {
                                appType = "OUT";
                            }

                            paramRow["APP_TYPE"] = appType;

                            paramTable.Rows.Add(paramRow);
                        }
                    }

                    DataSet paramSet = new DataSet();

                    paramSet.Tables.Add(paramTable);


                    BizRun.QBizRun.ExecuteService(
                    this, QBiz.emExecuteType.PROCESS,
                    "SAN01A_UPD3", paramSet, "RQSTDT", "RSLTDT",
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
                foreach (DataRow row in e.result.Tables["RQSTDT"].Rows)
                {
                    acGridView1.DeleteMappingRow(row);
                }

                acAlert.Show(this,"반려되었습니다.", acAlertForm.enmType.Error);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        private void btnRejectCancel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //반려취소
            try
            {
                acGridView3.EndEditor();

                DataRow focusRow = acGridView3.GetFocusedDataRow();

                if (focusRow == null) return;

                if (acMessageBox.Show(this, "정말 반려취소 하시겠습니까?", "", false, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
                {
                    return;
                }

                //DataView selectedView = acGridView3.GetDataSourceView("SEL = '1'");
                DataRow[] selected = acGridView3.GetSelectedDataRows();

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("REG_EMP", typeof(String));
                paramTable.Columns.Add("PLT_CODE", typeof(String));
                paramTable.Columns.Add("WORK_ID", typeof(String));
                paramTable.Columns.Add("APP_FLAG", typeof(String));
                paramTable.Columns.Add("SER_TYPE", typeof(String));
                paramTable.Columns.Add("APP_TYPE", typeof(String));

                if (selected.Length == 0)
                {
                    //단일반려

                    DataRow paramRow = paramTable.NewRow();
                    paramRow["REG_EMP"] = acInfo.UserID;
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["WORK_ID"] = focusRow["WORK_ID"];
                    paramRow["APP_FLAG"] = "0";
                    paramRow["SER_TYPE"] = acTabControl1.GetSelectedContainerName();

                    string appType = "ATD";

                    if (focusRow["IS_OUT"].ToString() == "1")
                    {
                        appType = "OUT";
                    }

                    paramRow["APP_TYPE"] = appType;

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
                        paramRow["WORK_ID"] = row["WORK_ID"];
                        paramRow["APP_FLAG"] = "0";
                        paramRow["SER_TYPE"] = acTabControl1.GetSelectedContainerName();

                        string appType = "ATD";

                        if (row["IS_OUT"].ToString() == "1")
                        {
                            appType = "OUT";
                        }

                        paramRow["APP_TYPE"] = appType;

                        paramTable.Rows.Add(paramRow);
                    }
                }

                DataSet paramSet = new DataSet();

                paramSet.Tables.Add(paramTable);


                BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.PROCESS,
                "SAN01A_UPD4", paramSet, "RQSTDT", "RSLTDT",
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
                foreach (DataRow row in e.result.Tables["RQSTDT"].Rows)
                {
                    acGridView3.DeleteMappingRow(row);
                }

                acAlert.Show(this, "반려취소되었습니다.", acAlertForm.enmType.Warning);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void btnNonApprovalSearch_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            NonAppSearch();
        }

        private void acBarButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //새로만들기
            try
            {
                if (!base.ChildFormContains("NEW"))
                {

                    DataRow layoutRow = acLayoutControl1.CreateParameterRow();

                    DataRow focusRow = acGridView2.GetFocusedDataRow();

                    if (focusRow == null) return;

                    SAN01A_D1A frm = new SAN01A_D1A(acGridView1, null, focusRow["EMP_CODE"].ToString());
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

        private void acBarButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //열기
            try
            {
                DataRow focusRow = acGridView1.GetFocusedDataRow();

                if (focusRow == null) return;

                string formKey = string.Format("{0}", focusRow["WORK_ID"]);

                if (!base.ChildFormContains(formKey))
                {
                    SAN01A_D1A frm = new SAN01A_D1A(acGridView1, focusRow, focusRow["EMP_CODE"].ToString());
                    frm.DialogMode = BaseMenuDialog.emDialogMode.OPEN;

                    frm.ParentControl = this;

                    base.ChildFormAdd(formKey, frm);

                    frm.Show(this);
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

        private void acBarButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //삭제
        }
    }
}
