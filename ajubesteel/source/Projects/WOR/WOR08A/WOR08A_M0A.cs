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
using DevExpress.XtraEditors.Repository;

namespace WOR
{
    public sealed partial class WOR08A_M0A : BaseMenu
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

        public WOR08A_M0A()
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
        private DataSet _IdleSet = null;

        public override void MenuInit()
        {
            acGridView2.GridType = acGridView.emGridType.SEARCH;
            acGridView2.AddTextEdit("EMP_CODE", "사원코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("EMP_NAME", "사원명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddDateEdit("HIRE_DATE", "입사일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
            acGridView2.AddTextEdit("ORG_CODE", "부서코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("ORG_NAME", "부서명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("CNT_HOLI", "발생연차", "", false, DevExpress.Utils.HorzAlignment.Far, false, false, false, acGridView.emTextEditMask.F1);
            acGridView2.AddTextEdit("USE_HOLI", "사용연차", "", false, DevExpress.Utils.HorzAlignment.Far, false, false, false, acGridView.emTextEditMask.F1);
            acGridView2.AddTextEdit("REMAIN_HOLI", "잔여연차", "", false, DevExpress.Utils.HorzAlignment.Far, false, false, false, acGridView.emTextEditMask.F1);

            acGridView2.FocusedRowChanged += acGridView2_FocusedRowChanged;

            acGridView1.GridType = acGridView.emGridType.SEARCH;

            //acGridView1.AddCheckEdit("SEL", "선택", "", false, true, true, acGridView.emCheckEditDataType._STRING);
            acGridView1.AddTextEdit("WORK_ID", "ID", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("EMP_CODE", "신청자코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("EMP_NAME", "신청자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("WORK_CODE", "근태코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("WORK_NAME", "근태명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddDateEdit("REQ_START_DATE", "시작시간", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.MEDIUM_DATE2);
            acGridView1.AddDateEdit("REQ_END_DATE", "종료시간", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.MEDIUM_DATE2);
            acGridView1.AddTextEdit("REQ_DAY", "일단위", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.F1);
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
            acGridView1.AddTextEdit("CC_EMP", "참조자", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddDateEdit("REJECT_DATE", "반려일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
            acGridView1.AddTextEdit("REJECT_REASON", "반려사유", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

            //acGridView1.AddTextEdit("APP_EMP_CODE1", "승인자1코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            //acGridView1.AddTextEdit("APP_EMP_NAME1", "승인자1", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            //acGridView1.AddTextEdit("APP_EMP1_FLAG", "승인자1상태", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);

            //acGridView1.AddTextEdit("APP_EMP_CODE2", "승인자2코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            //acGridView1.AddTextEdit("APP_EMP_NAME2", "승인자2", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            //acGridView1.AddTextEdit("APP_EMP2_FLAG", "승인자1상태", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);

            //acGridView1.AddTextEdit("APP_EMP_CODE3", "승인자3코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            //acGridView1.AddTextEdit("APP_EMP_NAME3", "승인자3", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            //acGridView1.AddTextEdit("APP_EMP3_FLAG", "승인자1상태", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);

            //acGridView1.AddTextEdit("APP_EMP_CODE4", "승인자4코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            //acGridView1.AddTextEdit("APP_EMP_NAME4", "승인자4", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            //acGridView1.AddTextEdit("APP_EMP4_FLAG", "승인자1상태", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddLookUpEmp("APP_EMP1", "승인자1", string.Empty, false, DevExpress.Utils.HorzAlignment.Center, false, true, false);
            acGridView1.AddTextEdit("APP_EMP_FLAG1", "승인자1상태", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddLookUpEmp("APP_EMP2", "승인자2", string.Empty, false, DevExpress.Utils.HorzAlignment.Center, false, true, false);
            acGridView1.AddTextEdit("APP_EMP_FLAG2", "승인자2상태", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddLookUpEmp("APP_EMP3", "승인자3", string.Empty, false, DevExpress.Utils.HorzAlignment.Center, false, true, false);
            acGridView1.AddTextEdit("APP_EMP_FLAG3", "승인자3상태", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddLookUpEmp("APP_EMP4", "승인자4", string.Empty, false, DevExpress.Utils.HorzAlignment.Center, false, true, false);
            acGridView1.AddTextEdit("APP_EMP_FLAG4", "승인자4상태", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);

            RepositoryItemHyperLinkEdit repItemHLE = new RepositoryItemHyperLinkEdit();
            repItemHLE.NullText = "첨부파일";

            acGridView1.AddCustomEdit("ATCH_FILE", "첨부파일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, repItemHLE);

            acGridView1.AddCheckEdit("HAS_ATTACH", "첨부파일유무", "", false, false, true, acGridView.emCheckEditDataType._STRING);

            acGridView1.AddDateEdit("REG_DATE", "최초 등록일", "UL1O77MB", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.LONG_DATE);
            acGridView1.AddTextEdit("REG_EMP", "최초 등록자코드", "P72K0SQJ", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("REG_EMP_NAME", "최초 등록자", "GPQHG8QQ", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddDateEdit("MDFY_DATE", "최근 수정일", "6RXQO0B2", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.LONG_DATE);
            acGridView1.AddTextEdit("MDFY_EMP", "최근 수정자코드", "WDHSCE72", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("MDFY_EMP_NAME", "최근 수정자", "FHJDO4F0", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.KeyColumn = new string[] { "WORK_ID" };

            acLayoutControl1.OnValueChanged += new acLayoutControl.ValueChangedEventHandler(acLayoutControl1_OnValueChanged);
            acLayoutControl1.OnValueKeyDown += new acLayoutControl.ValueKeyDownEventHandler(acLayoutControl1_OnValueKeyDown);

            acGridView1.ShowGridMenuEx += acGridView1_ShowGridMenuEx;

            acGridView1.MouseDown += acGridView1_MouseDown;

            acGridView1.MouseUp += acGridView1_MouseUp;

            acGridView1.CustomDrawCell += acGridView1_CustomDrawCell;

            acGridView1.FocusedRowChanged += acGridView1_FocusedRowChanged;

            //acGridView1.CustomSummaryCalculate += acGridView1_CustomSummaryCalculate;

            _WorkSet = BizRun.QBizRun.ExecuteService(this, "WOR01A_SER2", acInfo.RefData, "RQSTDT", "RSLTDT");

            _WorkTimeSet = BizRun.QBizRun.ExecuteService(this, "WOR01A_SER4", acInfo.RefData, "RQSTDT", "RSLTDT");

            _IdleSet = BizRun.QBizRun.ExecuteService(this, "WOR01A_SER6", acInfo.RefData, "RQSTDT", "RSLTDT");

            DateTime nowDate = acDateEdit.GetNowDateFromServer();

            string[] bands1 = new string[] { "구분", nowDate.Year.ToString() + "년" };

            acBandGridView1.AddTextEdit("YEAR", nowDate.Year.ToString() + "년", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acBandGridView.emTextEditMask.NONE, bands1);


            string[] bands2 = new string[] { "분단위 기록", "지각" };
            string[] bands3 = new string[] { "분단위 기록", "외출" };
            string[] bands4 = new string[] { "분단위 기록", "조퇴" };
            string[] bands5 = new string[] { "분단위 기록", "무급" };

            acBandGridView1.AddTextEdit("W01", "지각", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.NONE, bands2);
            acBandGridView1.AddTextEdit("W02", "외출", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.NONE, bands3);
            acBandGridView1.AddTextEdit("W03", "조퇴", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.NONE, bands4);
            acBandGridView1.AddTextEdit("W04", "무급", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.NONE, bands5);


            string[] bands6 = new string[] { "일단위 기록", "연차\r\n반차"};
            string[] bands7 = new string[] { "일단위 기록", "경조"};

            acBandGridView1.AddTextEdit("W05_W06", "연차\r\n반차", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.NONE, bands6);
            acBandGridView1.AddTextEdit("W07", "경조", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.NONE, bands7);


            string[] bands8 = new string[] { nowDate.Year.ToString() + "년" + " 고정값", "월근무\r\n일수" };
            string[] bands9 = new string[] { nowDate.Year.ToString() + "년" + " 고정값", "월별\r\n최대\r\n시간\r\n(주52)" };
            string[] bands10 = new string[] { nowDate.Year.ToString() + "년" + " 고정값", "기본근무\r\n일수\r\n(근무일수*8)" };

            //Dictionary<string, Color> colColorDic = new Dictionary<string, Color>();

            acBandGridView1.AddTextEdit("WORK_DAY", "월근무\r\n일수", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.NONE, bands8);
            //colColorDic.Add("WORK_DAY:BACK", Color.LightGray);
            acBandGridView1.AddTextEdit("WORK_MONTH_TIME", "월별\r\n최대\r\n시간\r\n(주52)", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.NONE, bands9);
            //colColorDic.Add("WORK_MONTH_TIME:BACK", Color.LightGray);
            acBandGridView1.AddTextEdit("WORK_HOUR", "기본근무\r\n일수\r\n(근무일수*8)", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.NONE, bands10);
            //colColorDic.Add("WORK_HOUR:BACK", Color.LightGray);


            string[] bands11 = new string[] { "시간단위 기록", "지,조\r\n외출\r\n연차\r\n시간" };
            string[] bands12 = new string[] { "시간단위 기록", "실근무시간" };
            string[] bands13 = new string[] { "시간단위 기록", "월잔여\r\n가능\r\n시간" };
            string[] bands14 = new string[] { "시간단위 기록", "연장\r\n누계\r\n시간" };

            acBandGridView1.AddTextEdit("HOLI_TIME", "지,조\r\n외출\r\n연차\r\n시간", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.NONE, bands11);
            //colColorDic.Add("HOLI_TIME:FORE", Color.Red);
            acBandGridView1.AddTextEdit("WORK_TIME", "실근무시간", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.NONE, bands12);
            acBandGridView1.AddTextEdit("REMAIN_TIME", "월잔여\r\n가능\r\n시간", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.NONE, bands13);
            acBandGridView1.AddTextEdit("CUM_TIME", "연장\r\n누계\r\n시간", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.NONE, bands14);

            int iBands1 = 1;
            int iBands2 = 1;
            int iBands3 = 1;
            int iBands4 = 1;
            foreach (DataRow row in _WorkTimeSet.Tables["RSLTDT"].Rows)
            {
                if (row["WORK_CODE"].ToString() == "W08")
                {
                    string sTime = row["WORK_START_HOUR"].ToString().Substring(0,2) + ":" + row["WORK_START_HOUR"].ToString().Substring(2, 2);
                    string eTime = row["WORK_END_HOUR"].ToString().Substring(0, 2) + ":" + row["WORK_END_HOUR"].ToString().Substring(2, 2);
                    string[] bands = new string[] { "시간단위 기록", row["WORK_NAME"].ToString(), sTime, eTime, row["WORK_RATE"].ToString() };

                    acBandGridView1.AddTextEdit(row["WORK_CODE"].ToString() + "_" + iBands1.ToString(), row["WORK_NAME"].ToString(), "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.NONE, bands);
                    acBandGridView1.Columns[row["WORK_CODE"].ToString() + "_" + iBands1.ToString()].Tag = row["WORK_START_HOUR"].ToString() + "-" + row["WORK_END_HOUR"].ToString();
                    iBands1++;
                    //string[] bands15 = new string[] { "시간단위 기록", "잔업", "18:00", "22:00", "1.5" };
                    //string[] bands16 = new string[] { "시간단위 기록", "잔업", "22:00", "06:00", "2.0" };
                    //string[] bands17 = new string[] { "시간단위 기록", "잔업", "06:00", "08:00", "1.5" };

                    //acBandGridView1.AddTextEdit("W08_1", "1.5", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acBandGridView.emTextEditMask.NONE, bands15);
                    //acBandGridView1.AddTextEdit("W08_2", "2.0", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acBandGridView.emTextEditMask.NONE, bands16);
                    //acBandGridView1.AddTextEdit("W08_3", "1.5", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acBandGridView.emTextEditMask.NONE, bands17);
                }
                else if (row["WORK_CODE"].ToString() == "W09")
                {
                    string sTime = row["WORK_START_HOUR"].ToString().Substring(0, 2) + ":" + row["WORK_START_HOUR"].ToString().Substring(2, 2);
                    string eTime = row["WORK_END_HOUR"].ToString().Substring(0, 2) + ":" + row["WORK_END_HOUR"].ToString().Substring(2, 2);
                    string[] bands = new string[] { "시간단위 기록", row["WORK_NAME"].ToString(), sTime, eTime, row["WORK_RATE"].ToString() };

                    acBandGridView1.AddTextEdit(row["WORK_CODE"].ToString() + "_" + iBands2.ToString(), row["WORK_NAME"].ToString(), "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.NONE, bands);
                    acBandGridView1.Columns[row["WORK_CODE"].ToString() + "_" + iBands2.ToString()].Tag = row["WORK_START_HOUR"].ToString() + "-" + row["WORK_END_HOUR"].ToString();
                    iBands2++;

                    //string[] bands18 = new string[] { "시간단위 기록", "교대", "22:00", "05:30", "0.5" };
                    //string[] bands19 = new string[] { "시간단위 기록", "교대", "06:00", "08:00", "1.5" };

                    //acBandGridView1.AddTextEdit("W09_1", "0.5", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acBandGridView.emTextEditMask.NONE, bands18);
                    //acBandGridView1.AddTextEdit("W09_2", "1.5", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acBandGridView.emTextEditMask.NONE, bands19);
                }
                else if (row["WORK_CODE"].ToString() == "W10")
                {
                    string sTime = row["WORK_START_HOUR"].ToString().Substring(0, 2) + ":" + row["WORK_START_HOUR"].ToString().Substring(2, 2);
                    string eTime = row["WORK_END_HOUR"].ToString().Substring(0, 2) + ":" + row["WORK_END_HOUR"].ToString().Substring(2, 2);
                    string[] bands = new string[] { "시간단위 기록", row["WORK_NAME"].ToString(), sTime, eTime, row["WORK_RATE"].ToString() };

                    acBandGridView1.AddTextEdit(row["WORK_CODE"].ToString() + "_" + iBands3.ToString(), row["WORK_NAME"].ToString(), "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.NONE, bands);
                    acBandGridView1.Columns[row["WORK_CODE"].ToString() + "_" + iBands3.ToString()].Tag = row["WORK_START_HOUR"].ToString() + "-" + row["WORK_END_HOUR"].ToString();
                    iBands3++;

                    //string[] bands20 = new string[] { "시간단위 기록", "특근", "08:30", "17:30", "1.5" };
                    //string[] bands21 = new string[] { "시간단위 기록", "특근", "18:00", "22:00", "2.0" };
                    //string[] bands22 = new string[] { "시간단위 기록", "특근", "22:00", "06:00", "2.5" };
                    //string[] bands23 = new string[] { "시간단위 기록", "특근", "06:00", "08:00", "2.0" };

                    //acBandGridView1.AddTextEdit("W10_1", "1.5", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acBandGridView.emTextEditMask.NONE, bands20);
                    //acBandGridView1.AddTextEdit("W10_2", "2.0", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acBandGridView.emTextEditMask.NONE, bands21);
                    //acBandGridView1.AddTextEdit("W10_3", "2.5", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acBandGridView.emTextEditMask.NONE, bands22);
                    //acBandGridView1.AddTextEdit("W10_4", "2.0", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acBandGridView.emTextEditMask.NONE, bands23);
                }
                else if (row["WORK_CODE"].ToString() == "W11")
                {
                    string sTime = row["WORK_START_HOUR"].ToString().Substring(0, 2) + ":" + row["WORK_START_HOUR"].ToString().Substring(2, 2);
                    string eTime = row["WORK_END_HOUR"].ToString().Substring(0, 2) + ":" + row["WORK_END_HOUR"].ToString().Substring(2, 2);
                    string[] bands = new string[] { "시간단위 기록", row["WORK_NAME"].ToString(), sTime, eTime, row["WORK_RATE"].ToString() };

                    acBandGridView1.AddTextEdit(row["WORK_CODE"].ToString() + "_" + iBands4.ToString(), row["WORK_NAME"].ToString(), "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.NONE, bands);
                    acBandGridView1.Columns[row["WORK_CODE"].ToString() + "_" + iBands4.ToString()].Tag = row["WORK_START_HOUR"].ToString() + "-" + row["WORK_END_HOUR"].ToString();
                    iBands4++;

                    //string[] bands24 = new string[] { "시간단위 기록", "휴일교대", "20:30", "22:00", "1.5" };
                    //string[] bands25 = new string[] { "시간단위 기록", "휴일교대", "22:00", "05:30", "2.0" };
                    //string[] bands26 = new string[] { "시간단위 기록", "휴일교대", "06:00", "08:00", "2.0" };

                    //acBandGridView1.AddTextEdit("W11_1", "1.5", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acBandGridView.emTextEditMask.NONE, bands24);
                    //acBandGridView1.AddTextEdit("W11_2", "2.0", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acBandGridView.emTextEditMask.NONE, bands25);
                    //acBandGridView1.AddTextEdit("W11_3", "2.0", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acBandGridView.emTextEditMask.NONE, bands26);
                }
            }

            acBandGridView1.BestFitColumns();
            acBandGridView1.ColumnPanelRowHeight = 100;
            acBandGridView1.OptionsView.ShowColumnHeaders = false;

            acBandGridView1.Bands[0].Visible = false;

            acBandGridView1.CustomDrawCell += acBandGridView1_CustomDrawCell;


            acCheckedComboBoxEdit1.AddItem("신청시작시간", false, "", "REQ_DATE", true, false);

            base.MenuInit();
        }

        private void acGridView1_CustomSummaryCalculate(object sender, DevExpress.Data.CustomSummaryEventArgs e)
        {
            
        }

        private void acGridView1_MouseUp(object sender, MouseEventArgs e)
        {
            GridHitInfo hitInfo = acGridView1.CalcHitInfo(e.Location);

            if (hitInfo.Column == null) return;

            if (hitInfo.Column.FieldName == "ATCH_FILE" && hitInfo.HitTest == GridHitTest.RowCell)
            {
                DataRow focusRow = acGridView1.GetFocusedDataRow();

                if (focusRow != null)
                {
                    if (!base.ChildFormContains("NEW_ITEM"))
                    {
                        WOR08A_D1A frm = new WOR08A_D1A(focusRow);
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
        }

        private void acGridView2_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            Search();
        }

        private void acGridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow empRow = acGridView2.GetFocusedDataRow();

            if (empRow["EMP_NAME"].ToString() == "전체")
            {
                acBandGridView1.ClearRow();
                //GetDetail();
            }
        }

        private void acBandGridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.RowHandle < 0) return;

            if (e.Column.FieldName == "WORK_DAY"
                || e.Column.FieldName == "WORK_MONTH_TIME"
                || e.Column.FieldName == "WORK_HOUR")
            {
                if (e.RowHandle < 12)
                {
                    e.Appearance.BackColor = Color.LightGray;
                }
            }

            if (e.Column.FieldName == "HOLI_TIME")
            {
                e.Appearance.ForeColor = Color.Red;
            }

            string sFirstColumn = acBandGridView1.GetRowCellDisplayText(e.RowHandle, "YEAR").ToString();

            if (sFirstColumn == "합계")
            {
                e.Appearance.BackColor = Color.DimGray;
                e.Appearance.ForeColor = Color.White;
            }

            if (sFirstColumn == "사용"
                || sFirstColumn == "내역"
                || sFirstColumn == "발생")
            {
                if (e.Column.FieldName.Contains("W11"))
                {
                    string[] cols = e.Column.FieldName.Split('_');

                    int iCols = cols[1].toInt();

                    if (iCols < 3)
                    {
                        e.Appearance.BackColor = Color.LightGreen;
                        e.Appearance.ForeColor = Color.Black;
                    }
                }
            }
        }

        private void acGridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            try
            {
                if (e.RowHandle < 0) return;

                string app1 = acGridView1.GetRowCellValue(e.RowHandle, "APP_EMP_FLAG1").ToString();
                string app2 = acGridView1.GetRowCellValue(e.RowHandle, "APP_EMP_FLAG2").ToString();
                string app3 = acGridView1.GetRowCellValue(e.RowHandle, "APP_EMP_FLAG3").ToString();
                string app4 = acGridView1.GetRowCellValue(e.RowHandle, "APP_EMP_FLAG4").ToString();

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

            switch(flag)
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

                //layout.GetEditor("EMP_CODE").Value = acInfo.UserID;
                layout.GetEditor("DATE").Value = "REQ_DATE";
                layout.GetEditor("S_DATE").Value = acDateEdit.GetNowFirstYear();
                layout.GetEditor("E_DATE").Value = acDateEdit.GetNowLastDate();
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

        private void acGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                GridHitInfo hitInfo = acGridView1.CalcHitInfo(e.Location);

                if (hitInfo.HitTest == GridHitTest.RowCell || hitInfo.HitTest == GridHitTest.Row)
                {
                    acBarButtonItem2_ItemClick(null, null);
                }
            }
        }

        void acGridView1_ShowGridMenuEx(object sender, PopupMenuShowingEventArgs e)
        {
            acGridView view = sender as acGridView;

            if (e.HitInfo.HitTest == GridHitTest.EmptyRow || e.HitInfo.HitTest == GridHitTest.Row || e.HitInfo.HitTest == GridHitTest.RowCell)
            {
                DataRow focusRow = acGridView2.GetFocusedDataRow();

                if (focusRow == null) return;

                bool isAll = false;
                if (focusRow["EMP_NAME"].ToString() == "전체")
                {
                    isAll = true;
                }

                if (e.MenuType == GridMenuType.User)
                {
                    acBarSubItem1.Visibility = isAll == true ? DevExpress.XtraBars.BarItemVisibility.Never : DevExpress.XtraBars.BarItemVisibility.Always;
                    acBarButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    acBarButtonItem3.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                }
                else if (e.MenuType == GridMenuType.Row)
                {
                    if (e.HitInfo.RowHandle >= 0)
                    {
                        acBarSubItem1.Visibility = isAll == true ? DevExpress.XtraBars.BarItemVisibility.Never : DevExpress.XtraBars.BarItemVisibility.Always;
                        acBarButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        acBarButtonItem3.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    }
                    else
                    {
                        acBarSubItem1.Visibility = isAll == true ? DevExpress.XtraBars.BarItemVisibility.Never : DevExpress.XtraBars.BarItemVisibility.Always;
                        acBarButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        acBarButtonItem3.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    }
                }

                GridHitInfo hitInfo = view.CalcHitInfo(e.Point);

                popupMenu1.ShowPopup(view.GridControl.PointToScreen(e.Point));

            }
        }

        void acLayoutControl1_OnValueKeyDown(object sender, IBaseEditControl info, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SearchEmp();
            }
        }

        void Search(bool isDel = false)
        {
            if (acLayoutControl1.ValidCheck() == false) return;

            DataRow layoutRow = acLayoutControl1.CreateParameterRow();

            DataRow focusRow = acGridView2.GetFocusedDataRow();
            if (focusRow == null)
            {
                acBandGridView1.ClearRow();
                return;
            }

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("EMP_CODE", typeof(String)); //
            paramTable.Columns.Add("S_REQ_DATE", typeof(String)); //
            paramTable.Columns.Add("E_REQ_DATE", typeof(String)); //
            paramTable.Columns.Add("YEAR", typeof(String)); //
            paramTable.Columns.Add("IS_DEL", typeof(bool)); //

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["EMP_CODE"] = focusRow["EMP_CODE"];
            //paramRow["S_REQ_DATE"] = layoutRow["S_DATE"];
            //paramRow["E_REQ_DATE"] = layoutRow["E_DATE"];
            paramRow["IS_DEL"] = isDel;


            foreach (string key in acCheckedComboBoxEdit1.GetKeyChecked())
            {
                switch (key)
                {
                    case "REQ_DATE":
                        paramRow["S_REQ_DATE"] = layoutRow["S_DATE"];
                        paramRow["E_REQ_DATE"] = layoutRow["E_DATE"];
                        break;
                }
            }

            paramRow["YEAR"] = layoutRow["S_DATE"].toDateTime().toDateString("yyyy");

            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();

            paramSet.Tables.Add(paramTable);

            BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD, "WOR01A_SER", paramSet, "RQSTDT", "RSLTDT",
            QuickSearch,
            QuickException);
        }

        void QuickSearch(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                if (!e.result.Tables["RQSTDT"].Rows[0]["IS_DEL"].toBoolean())
                {
                    acGridView1.GridControl.DataSource = e.result.Tables["RSLTDT"];

                    acGridView1.BestFitColumns();
                }

                DataRow focusRow = acGridView2.GetFocusedDataRow();

                if (focusRow != null)
                {
                    acLayoutControl2.DataBind(focusRow, false);
                }

                if (focusRow["EMP_NAME"].ToString() == "전체")
                {
                    acBandGridView1.ClearRow();
                    return;
                }

                //acBandGridView1.ClearRow();

                //return;

                //근로현황데이터 가공

                DataTable gridTable = ((DataTable)acBandGridView1.GridControl.DataSource).Clone();

                //합계 저장 dictionary
                Dictionary<string, decimal> sumDic = new Dictionary<string, decimal>();

                for (int i = 1; i <= 12; i++)
                {
                    DataRow newRow = gridTable.NewRow();
                    newRow["YEAR"] = i.ToString() + "월";

                    string month = e.result.Tables["RQSTDT"].Rows[0]["YEAR"].ToString() + Convert.ToString(i).PadLeft(2, '0');

                    DataRow[] reqRwos = e.result.Tables["RSLTDT_YEAR"].Select("REQ_START_MONTH = '" + month + "'");

                    foreach (DataRow row in reqRwos)
                    {
                        //분단위 - 지각(W01), 외출(W02), 조퇴(W03), 무급(W04)
                        //일단위 - 연차/반차(W05/W06), 경조(W07)
                        //시간단위 - 잔업(W08), 교대(W09), 특근(W10), 휴일교대(W11)
                        switch (row["WORK_CODE"].ToString())
                        {
                            case "W01": //지각

                                newRow["W01"] = newRow["W01"].toInt() + row["REQ_TIME"].toInt();

                                //합계 - 누적저장
                                if (sumDic.ContainsKey("W01"))
                                {
                                    sumDic["W01"] = sumDic["W01"] + row["REQ_TIME"].toInt();
                                }
                                else
                                {
                                    sumDic.Add("W01", newRow["W01"].toDecimal());
                                }

                                break;

                            case "W02": //외출

                                newRow["W02"] = newRow["W02"].toInt() + row["REQ_TIME"].toInt();

                                //합계 - 누적저장
                                if (sumDic.ContainsKey("W02"))
                                {
                                    sumDic["W02"] = sumDic["W02"] + row["REQ_TIME"].toInt();
                                }
                                else
                                {
                                    sumDic.Add("W02", newRow["W02"].toDecimal());
                                }

                                break;

                            case "W03": //조퇴

                                newRow["W03"] = newRow["W03"].toInt() + row["REQ_TIME"].toInt();

                                //합계 - 누적저장
                                if (sumDic.ContainsKey("W03"))
                                {
                                    sumDic["W03"] = sumDic["W03"] + row["REQ_TIME"].toInt();
                                }
                                else
                                {
                                    sumDic.Add("W03", newRow["W03"].toDecimal());
                                }

                                break;

                            case "W04": //무급

                                newRow["W04"] = newRow["W04"].toInt() + row["REQ_TIME"].toInt();

                                //합계 - 누적저장
                                if (sumDic.ContainsKey("W04"))
                                {
                                    sumDic["W04"] = sumDic["W04"] + row["REQ_TIME"].toInt();
                                }
                                else
                                {
                                    sumDic.Add("W04", newRow["W04"].toDecimal());
                                }

                                break;

                            case "W05": //연차
                            case "W06": //반차

                                newRow["W05_W06"] = Math.Round(((newRow["W05_W06"].toDecimal() * 480) + row["REQ_TIME"].toDecimal()).toDecimal() / 480, 1);

                                //합계 - 누적저장
                                if (sumDic.ContainsKey("W05_W06"))
                                {
                                    sumDic["W05_W06"] = sumDic["W05_W06"] + Math.Round((row["REQ_TIME"].toDecimal()).toDecimal() / 480, 1);
                                }
                                else
                                {
                                    sumDic.Add("W05_W06", newRow["W05_W06"].toDecimal());
                                }

                                break;

                            case "W07": //경조

                                newRow["W07"] = Math.Round(((newRow["W07"].toDecimal() * 480) + row["REQ_TIME"].toDecimal()).toDecimal() / 480, 1);

                                //합계 - 누적저장
                                if (sumDic.ContainsKey("W07"))
                                {
                                    sumDic["W07"] = sumDic["W07"] + Math.Round((row["REQ_TIME"].toDecimal()).toDecimal() / 480, 1);
                                }
                                else
                                {
                                    sumDic.Add("W07", newRow["W07"].toDecimal());
                                }

                                break;

                            case "W08": //잔업
                            case "W09": //교대
                            case "W10": //특근
                            case "W11": //휴일교대

                                //근무형태에 따른 주,야간 정례화 시간을 가져온다.
                                DataTable idleTable = new DataTable("RQSTDT");
                                idleTable.Columns.Add("PLT_CODE", typeof(string));
                                idleTable.Columns.Add("EMP_CODE", typeof(string));
                                idleTable.Columns.Add("WORK_YEAR", typeof(string));
                                idleTable.Columns.Add("EWT_DATE", typeof(string));

                                DataRow idleRow = idleTable.NewRow();
                                idleRow["PLT_CODE"] = acInfo.PLT_CODE;
                                idleRow["EMP_CODE"] = row["EMP_CODE"];
                                idleRow["WORK_YEAR"] = row["REQ_START_DATE"].toDateTime().ToString("yyyy");
                                idleRow["EWT_DATE"] = row["REQ_START_DATE"].toDateTime().ToString("yyyyMMdd");

                                idleTable.Rows.Add(idleRow);
                                DataSet idleSet = new DataSet();
                                idleSet.Tables.Add(idleTable);

                                DataSet resultSet = BizRun.QBizRun.ExecuteService(this, "WOR01A_SER10", idleSet, "RQSTDT", "RSLTDT");

                                //IDLE_FLAG - 0 : 주간 , 1 : 야간
                                string idleFillter = "IDLE_FLAG = '0'";

                                if (resultSet.Tables["RSLTDT"].Rows.Count > 0)
                                {
                                    if (resultSet.Tables["RSLTDT"].Rows[0]["EWT_TYPE"].ToString() == "1")
                                    {
                                        idleFillter = "IDLE_FLAG = '1'";
                                    }
                                }

                                //휴일교대일 경우 강제 야간근무자
                                if (row["WORK_CODE"].ToString() == "W11")
                                {
                                    idleFillter = "IDLE_FLAG = '1'";
                                }

                                //기준시간의 교집합구하기
                                //1.신청시간에 기준시간 시작시간과 종료시간이 포함된경우
                                //2.기준시작시간이 신청시간 사이에 있는경우
                                //3.기준시간에 신청시간 시작시간과 종료시간이 포함된경우
                                //5.기준종료시간이 신청시간 사이에 있는경우
                                DataRow[] workRows = _WorkTimeSet.Tables["RSLTDT"].Select("WORK_CODE = '" + row["WORK_CODE"].ToString() + "'");

                                Dictionary<string, bool> nextdaydic = new Dictionary<string, bool>();

                                if (!nextdaydic.ContainsKey(row["WORK_CODE"].ToString()))
                                {
                                    nextdaydic.Add(row["WORK_CODE"].ToString(), false);
                                }
                                else
                                {
                                    nextdaydic[row["WORK_CODE"].ToString()] = false;
                                }

                                int iSeq = 1;
                                foreach (DataRow workRow in workRows)
                                {           
                                    DateTime reqStartDateTime = row["REQ_START_DATE"].toDateTime();
                                    DateTime reqEndDateTime = row["REQ_END_DATE"].toDateTime();

                                    DateTime stdStartDate = new DateTime(reqStartDateTime.Year, reqStartDateTime.Month, reqStartDateTime.Day, workRow["WORK_START_HOUR"].ToString().Substring(0, 2).toInt(), workRow["WORK_START_HOUR"].ToString().Substring(2, 2).toInt(), 0);
                                    DateTime stdEndDate = new DateTime(reqStartDateTime.Year, reqStartDateTime.Month, reqStartDateTime.Day, workRow["WORK_END_HOUR"].ToString().Substring(0, 2).toInt(), workRow["WORK_END_HOUR"].ToString().Substring(2, 2).toInt(), 0);


                                    if (nextdaydic[row["WORK_CODE"].ToString()])
                                    {
                                        stdStartDate = stdStartDate.AddDays(1);
                                        stdEndDate = stdEndDate.AddDays(1);
                                    }

                                    //종료시간이 작을경우 하루 더함
                                    if (workRow["WORK_START_HOUR"].ToString().Substring(0, 2).toInt() > workRow["WORK_END_HOUR"].ToString().Substring(0, 2).toInt())
                                    {
                                        stdEndDate = stdEndDate.AddDays(1);

                                        nextdaydic[row["WORK_CODE"].ToString()] = true;
                                    }

                                    //if (workRows[0]["WORK_START_HOUR"].toInt() > workRow["WORK_START_HOUR"].toInt())
                                    //{
                                    //    stdStartDate = stdStartDate.AddDays(1);
                                    //    stdEndDate = stdEndDate.AddDays(1);
                                    //}

                                    TimeSpan ts = new TimeSpan();
                                    double time = 0.0;
                                    //시간 교집합 구분
                                    if (reqStartDateTime <= stdStartDate && reqEndDateTime >= stdEndDate) //신청시간에 기준시간 시작시간과 종료시간이 포함된경우
                                    {
                                        ts = stdEndDate.Subtract(stdStartDate);
                                        time = ts.TotalMinutes;
                                        time = time - GetIdleTime(stdStartDate, stdEndDate, idleFillter);
                                        newRow[row["WORK_CODE"].ToString() + "_" + iSeq.ToString()] = Math.Round(((newRow[row["WORK_CODE"].ToString() + "_" + iSeq.ToString()].toDouble() * 60) + time).toDecimal() / 60, 1);
                                    }
                                    else if (reqStartDateTime <= stdStartDate && reqEndDateTime >= stdStartDate) //기준시작시간이 신청시간 사이에 있는경우
                                    {
                                        ts = reqEndDateTime.Subtract(stdStartDate);
                                        time = ts.TotalMinutes;
                                        time = time - GetIdleTime(stdStartDate, reqEndDateTime, idleFillter);
                                        newRow[row["WORK_CODE"].ToString() + "_" + iSeq.ToString()] = Math.Round(((newRow[row["WORK_CODE"].ToString() + "_" + iSeq.ToString()].toDouble() * 60) + time).toDecimal() / 60, 1);
                                    }
                                    else if (stdStartDate <= reqStartDateTime && stdEndDate >= reqEndDateTime) //기준시간에 신청시간 시작시간과 종료시간이 포함된경우
                                    {
                                        ts = reqEndDateTime.Subtract(reqStartDateTime);
                                        time = ts.TotalMinutes;
                                        time = time - GetIdleTime(reqStartDateTime, reqEndDateTime, idleFillter);
                                        newRow[row["WORK_CODE"].ToString() + "_" + iSeq.ToString()] = Math.Round(((newRow[row["WORK_CODE"].ToString() + "_" + iSeq.ToString()].toDouble() * 60) + time).toDecimal() / 60, 1);
                                    }
                                    else if (reqStartDateTime <= stdEndDate && reqEndDateTime >= stdEndDate) //기준종료시간이 신청시간 사이에 있는경우
                                    {
                                        ts = stdEndDate.Subtract(reqStartDateTime);
                                        time = ts.TotalMinutes;
                                        time = time - GetIdleTime(reqStartDateTime, stdEndDate, idleFillter);
                                        newRow[row["WORK_CODE"].ToString() + "_" + iSeq.ToString()] = Math.Round(((newRow[row["WORK_CODE"].ToString() + "_" + iSeq.ToString()].toDouble() * 60) + time).toDecimal() / 60, 1);
                                    }

                                    if (time > 0)
                                    {
                                        //합계 - 누적저장
                                        if (sumDic.ContainsKey(row["WORK_CODE"].ToString() + "_" + iSeq.ToString()))
                                        {
                                            sumDic[row["WORK_CODE"].ToString() + "_" + iSeq.ToString()] = sumDic[row["WORK_CODE"].ToString() + "_" + iSeq.ToString()] + Math.Round((time).toDecimal() / 60, 1);
                                        }
                                        else
                                        {
                                            sumDic.Add(row["WORK_CODE"].ToString() + "_" + iSeq.ToString(), newRow[row["WORK_CODE"].ToString() + "_" + iSeq.ToString()].toDecimal());
                                        }

                                        //야간근무를 제외한 연장 누계시간
                                        if (workRow["NIGHT_FLAG"].ToString() != "1")
                                        {
                                            //newRow["CUM_TIME"] = newRow["CUM_TIME"].toDecimal() + newRow[row["WORK_CODE"].ToString() + "_" + iSeq.ToString()].toDecimal();
                                            newRow["CUM_TIME"] = newRow["CUM_TIME"].toDecimal() + Math.Round((time).toDecimal() / 60, 1).toDecimal();

                                            //합계 - 누적저장
                                            if (sumDic.ContainsKey("CUM_TIME"))
                                            {
                                                //sumDic["CUM_TIME"] = sumDic["CUM_TIME"] + newRow[row["WORK_CODE"].ToString() + "_" + iSeq.ToString()].toDecimal();
                                                sumDic["CUM_TIME"] = sumDic["CUM_TIME"] + Math.Round((time).toDecimal() / 60, 1).toDecimal();
                                            }
                                            else
                                            {
                                                sumDic.Add("CUM_TIME", newRow["CUM_TIME"].toDecimal());
                                            }
                                        }                                        
                                    }

                                    iSeq++;
                                }

                                break;
                        }
                    }

                    //지,조 외출 연차 시간 : (지각/60 + 외출/60 + 조퇴/60 + 무급/60) + 연차반차 * 8  + 경조 * 8
                    newRow["HOLI_TIME"] = (Math.Round((newRow["W01"].toDecimal() / 60), 2) + Math.Round((newRow["W02"].toDecimal() / 60), 2) + Math.Round((newRow["W03"].toDecimal() / 60), 2) + Math.Round((newRow["W04"].toDecimal() / 60), 2))
                       + (newRow["W05_W06"].toDecimal() * 8) + (newRow["W07"].toDecimal() * 8);

                    ////합계 - 누적저장
                    //if (sumDic.ContainsKey("HOLI_TIME"))
                    //{
                    //    sumDic["HOLI_TIME"] = sumDic["HOLI_TIME"] + newRow["HOLI_TIME"].toDecimal();
                    //}
                    //else
                    //{
                    //    sumDic.Add("HOLI_TIME", newRow["HOLI_TIME"].toDecimal());
                    //}

                    //고정값
                    DataRow[] dayRows = e.result.Tables["RSLTDT_WORKDAY"].Select("WORK_MONTH = '" + month + "'");
                    if (dayRows.Length > 0)
                    {
                        newRow["WORK_DAY"] = dayRows[0]["WORK_DAY"];
                        newRow["WORK_MONTH_TIME"] = dayRows[0]["WORK_MONTH_TIME"];
                        newRow["WORK_HOUR"] = dayRows[0]["WORK_HOUR"];
                    }

                    //실근무시간 : (기본근무시간 + 연장누계시간) - 지,조 외출연차시간
                    newRow["WORK_TIME"] = newRow["WORK_HOUR"].toDecimal() + newRow["CUM_TIME"].toDecimal() - newRow["HOLI_TIME"].toDecimal();

                    //월잔여시간 : 월별최대시간 - 실근무시간
                    newRow["REMAIN_TIME"] = newRow["WORK_MONTH_TIME"].toDecimal() - newRow["WORK_TIME"].toDecimal();

                    gridTable.Rows.Add(newRow);
                }

                //합계
                DataRow sumRow = gridTable.NewRow();
                sumRow["YEAR"] = "합계";

                foreach (DataColumn col in gridTable.Columns)
                {
                    if (sumDic.ContainsKey(col.ColumnName))
                    {
                        sumRow[col.ColumnName] = sumDic[col.ColumnName];
                    }
                }

                gridTable.Rows.Add(sumRow);

                //사용
                DataRow useRow = gridTable.NewRow();
                useRow["YEAR"] = "사용";
                useRow["W01"] = "연차 : ";
                if (sumDic.ContainsKey("W05_W06"))
                {
                    useRow["W02"] = sumDic["W05_W06"];
                }

                //분기별 잔여시간 : 1분기
                int iquarter = 0;
                int remainQuarter = 0;
                foreach (DataRow row in gridTable.Rows)
                {
                    if (iquarter >= 0)
                    {
                        remainQuarter = (remainQuarter.toDecimal() + (row["WORK_MONTH_TIME"].toDecimal() - row["WORK_TIME"].toDecimal())).toInt();

                        if (iquarter > 1)
                        {
                            break;
                        }
                    }
                    iquarter++;
                }

                useRow["W11_1"] = "1/4";
                useRow["W11_2"] = remainQuarter;
                gridTable.Rows.Add(useRow);

                //내역
                DataRow conRow = gridTable.NewRow();
                conRow["YEAR"] = "내역";
                conRow["W01"] = "경조 : ";
                if (sumDic.ContainsKey("W07"))
                {
                    conRow["W02"] = sumDic["W07"];
                }

                //분기별 잔여시간 : 2분기
                iquarter = 0;
                remainQuarter = 0;
                foreach (DataRow row in gridTable.Rows)
                {
                    if (iquarter >= 3)
                    {
                        remainQuarter = (remainQuarter.toDecimal() + (row["WORK_MONTH_TIME"].toDecimal() - row["WORK_TIME"].toDecimal())).toInt();

                        if (iquarter > 4)
                        {
                            break;
                        }
                    }
                    iquarter++;
                }

                conRow["W11_1"] = "2/4";
                conRow["W11_2"] = remainQuarter;

                gridTable.Rows.Add(conRow);

                //발생
                DataRow occRow = gridTable.NewRow();
                occRow["YEAR"] = "발생";
                occRow["W01"] = "연차 : ";
                double dHoli = 0.0;
                if (e.result.Tables["RSLTDT_EMP_HOLI"].Rows.Count > 0)
                {
                    dHoli = e.result.Tables["RSLTDT_EMP_HOLI"].Rows[0]["HOLI_OCCUR_INPUT_CNT"].toDouble();
                }
                occRow["W02"] = dHoli;


                //분기별 잔여시간 : 3분기
                iquarter = 0;
                remainQuarter = 0;
                foreach (DataRow row in gridTable.Rows)
                {
                    if (iquarter >= 6)
                    {
                        remainQuarter = (remainQuarter.toDecimal() + (row["WORK_MONTH_TIME"].toDecimal() - row["WORK_TIME"].toDecimal())).toInt();

                        if (iquarter > 7)
                        {
                            break;
                        }
                    }
                    iquarter++;
                }

                occRow["W11_1"] = "3/4";
                occRow["W11_2"] = remainQuarter;

                gridTable.Rows.Add(occRow);

                //사용
                DataRow useRow2 = gridTable.NewRow();
                useRow2["YEAR"] = "사용";
                useRow2["W01"] = "연차 : ";


                //분기별 잔여시간 : 4분기
                iquarter = 0;
                remainQuarter = 0;
                foreach (DataRow row in gridTable.Rows)
                {
                    if (iquarter >= 9)
                    {
                        remainQuarter = (remainQuarter.toDecimal() + (row["WORK_MONTH_TIME"].toDecimal() - row["WORK_TIME"].toDecimal())).toInt();

                        if (iquarter > 10)
                        {
                            break;
                        }
                    }
                    iquarter++;
                }

                useRow2["W11_1"] = "4/4";
                useRow2["W11_2"] = remainQuarter;

                gridTable.Rows.Add(useRow2);

                //남은
                DataRow remainRow = gridTable.NewRow();
                remainRow["YEAR"] = "남은";
                remainRow["W01"] = "연차 : ";
                double dUseHoli = 0.0;
                if (sumDic.ContainsKey("W05_W06"))
                {
                    dUseHoli = sumDic["W05_W06"].toDouble();
                }

                remainRow["W02"] = dHoli - dUseHoli;
                gridTable.Rows.Add(remainRow);

                acBandGridView1.GridControl.DataSource = gridTable;
                acBandGridView1.OptionsView.ShowColumnHeaders = true;
                acBandGridView1.BestFitColumns();
                acBandGridView1.OptionsView.ShowColumnHeaders = false;

                //base.SetLog(e.executeType, e.result.Tables["RSLTDT"].Rows.Count, e.executeTime);

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

        void SearchEmp()
        {
            try
            {
                if (acLayoutControl1.ValidCheck() == false) return;

                DataRow layoutRow = acLayoutControl1.CreateParameterRow();

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("EMP_CODE", typeof(String)); //
                paramTable.Columns.Add("YEAR", typeof(String)); //
                paramTable.Columns.Add("IS_RETIRE", typeof(String)); //

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["EMP_CODE"] = layoutRow["EMP_CODE"];
                //paramRow["S_REQ_DATE"] = layoutRow["S_DATE"];
                //paramRow["E_REQ_DATE"] = layoutRow["E_DATE"];

                paramRow["YEAR"] = layoutRow["S_DATE"].toDateTime().toDateString("yyyy");
                paramRow["IS_RETIRE"] = layoutRow["IS_RETIRE"];

                if (acCheckEdit1.Checked)
                {
                    paramRow["IS_RETIRE"] = null;
                }

                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();

                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD, "WOR08A_SER", paramSet, "RQSTDT", "RSLTDT",
                QuickSearchEmp,
                QuickException);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void QuickSearchEmp(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                DataRow newAllRow = e.result.Tables["RSLTDT"].NewRow();
                newAllRow["PLT_CODE"] = acInfo.PLT_CODE;
                newAllRow["EMP_NAME"] = "전체";

                e.result.Tables["RSLTDT"].Rows.InsertAt(newAllRow, 0);

                acGridView2.GridControl.DataSource = e.result.Tables["RSLTDT"];

                base.SetLog(e.executeType, e.result.Tables["RSLTDT"].Rows.Count, e.executeTime);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void barItemRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //조회
            try
            {
                this.SearchEmp();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
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

                    WOR08A_D0A frm = new WOR08A_D0A(acGridView1, null, focusRow["EMP_CODE"].ToString());
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
                    WOR08A_D0A frm = new WOR08A_D0A(acGridView1, focusRow, focusRow["EMP_CODE"].ToString());
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
            try
            {
                acGridView1.EndEditor();

                if (acMessageBox.Show(this, "정말 삭제하시겠습니까?", "TB43FSY3", true, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No) return;

                //DataView selected = acGridView1.GetDataSourceView("SEL = '1'");

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("WORK_ID", typeof(String)); //

                //단일삭제
                DataRow focusRow = acGridView1.GetFocusedDataRow();

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["WORK_ID"] = focusRow["WORK_ID"];

                paramTable.Rows.Add(paramRow);

                //if (selected.Count == 0)
                //{
                //    //단일삭제
                //    DataRow focusRow = acGridView1.GetFocusedDataRow();

                //    DataRow paramRow = paramTable.NewRow();
                //    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                //    paramRow["WORK_ID"] = focusRow["WORK_ID"];

                //    paramTable.Rows.Add(paramRow);
                //}
                //else
                //{
                //    //다중삭제
                //    for (int i = 0; i < selected.Count; i++)
                //    {

                //        DataRow paramRow = paramTable.NewRow();
                //        paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                //        paramRow["WORK_ID"] = selected[i]["WORK_ID"];

                //        paramTable.Rows.Add(paramRow);
                //    }

                //}

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.DEL,
                "WOR08A_DEL", paramSet, "RQSTDT", "",
                QuickDEL,
                QuickException);

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void QuickDEL(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                foreach (DataRow row in e.result.Tables["RQSTDT"].Rows)
                {
                    acGridView1.DeleteMappingRow(row);
                }

                Search(true);

                //acGridView1.RaiseFocusedRowChanged();

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }


        void GetDetail()
        {
            if (acLayoutControl1.ValidCheck() == false) return;

            DataRow layoutRow = acLayoutControl1.CreateParameterRow();

            DataRow focusRow = acGridView1.GetFocusedDataRow();
            if (focusRow == null)
            {
                acBandGridView1.ClearRow();
                return;
            }

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("EMP_CODE", typeof(String)); //
            paramTable.Columns.Add("S_REQ_DATE", typeof(String)); //
            paramTable.Columns.Add("E_REQ_DATE", typeof(String)); //
            paramTable.Columns.Add("YEAR", typeof(String)); //

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["EMP_CODE"] = focusRow["EMP_CODE"];
            //paramRow["S_REQ_DATE"] = layoutRow["S_DATE"];
            //paramRow["E_REQ_DATE"] = layoutRow["E_DATE"];

            foreach (string key in acCheckedComboBoxEdit1.GetKeyChecked())
            {
                switch (key)
                {
                    case "REQ_DATE":
                        paramRow["S_REQ_DATE"] = layoutRow["S_DATE"];
                        paramRow["E_REQ_DATE"] = layoutRow["E_DATE"];
                        break;
                }
            }

            paramRow["YEAR"] = layoutRow["S_DATE"].toDateTime().toDateString("yyyy");

            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();

            paramSet.Tables.Add(paramTable);

            BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD_DETAIL, "WOR01A_SER", paramSet, "RQSTDT", "RSLTDT",
            QuickDetailSearch,
            QuickException);
        }

        void QuickDetailSearch(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                DataRow focusRow = acGridView1.GetFocusedDataRow();

                if (focusRow == null)
                {
                    return;
                }

                DataRow layoutRow = acLayoutControl1.CreateParameterRow();

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("EMP_CODE", typeof(String)); //
                paramTable.Columns.Add("YEAR", typeof(String)); //

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["EMP_CODE"] = focusRow["EMP_CODE"];

                paramRow["YEAR"] = layoutRow["S_DATE"].toDateTime().toDateString("yyyy");

                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();

                paramSet.Tables.Add(paramTable);

                DataSet empSet = BizRun.QBizRun.ExecuteService(this, "WOR08A_SER", paramSet, "RQSTDT", "RSLTDT");

                if (empSet.Tables["RSLTDT"].Rows.Count > 0)
                {
                    acLayoutControl2.DataBind(empSet.Tables["RSLTDT"].Rows[0], false);
                }
                
                //DataRow focusRow = acGridView2.GetFocusedDataRow();

                //if (focusRow != null)
                //{
                //    acLayoutControl2.DataBind(focusRow, false);
                //}


                //근로현황데이터 가공

                DataTable gridTable = ((DataTable)acBandGridView1.GridControl.DataSource).Clone();

                //합계 저장 dictionary
                Dictionary<string, decimal> sumDic = new Dictionary<string, decimal>();

                for (int i = 1; i <= 12; i++)
                {
                    DataRow newRow = gridTable.NewRow();
                    newRow["YEAR"] = i.ToString() + "월";

                    string month = e.result.Tables["RQSTDT"].Rows[0]["YEAR"].ToString() + Convert.ToString(i).PadLeft(2, '0');

                    DataRow[] reqRwos = e.result.Tables["RSLTDT_YEAR"].Select("REQ_START_MONTH = '" + month + "'");

                    foreach (DataRow row in reqRwos)
                    {
                        //분단위 - 지각(W01), 외출(W02), 조퇴(W03), 무급(W04)
                        //일단위 - 연차/반차(W05/W06), 경조(W07)
                        //시간단위 - 잔업(W08), 교대(W09), 특근(W10), 휴일교대(W11)
                        switch (row["WORK_CODE"].ToString())
                        {
                            case "W01": //지각

                                newRow["W01"] = newRow["W01"].toInt() + row["REQ_TIME"].toInt();

                                //합계 - 누적저장
                                if (sumDic.ContainsKey("W01"))
                                {
                                    sumDic["W01"] = sumDic["W01"] + row["REQ_TIME"].toInt();
                                }
                                else
                                {
                                    sumDic.Add("W01", newRow["W01"].toDecimal());
                                }

                                break;

                            case "W02": //외출

                                newRow["W02"] = newRow["W02"].toInt() + row["REQ_TIME"].toInt();

                                //합계 - 누적저장
                                if (sumDic.ContainsKey("W02"))
                                {
                                    sumDic["W02"] = sumDic["W02"] + row["REQ_TIME"].toInt();
                                }
                                else
                                {
                                    sumDic.Add("W02", newRow["W02"].toDecimal());
                                }

                                break;

                            case "W03": //조퇴

                                newRow["W03"] = newRow["W03"].toInt() + row["REQ_TIME"].toInt();

                                //합계 - 누적저장
                                if (sumDic.ContainsKey("W03"))
                                {
                                    sumDic["W03"] = sumDic["W03"] + row["REQ_TIME"].toInt();
                                }
                                else
                                {
                                    sumDic.Add("W03", newRow["W03"].toDecimal());
                                }

                                break;

                            case "W04": //무급

                                newRow["W04"] = newRow["W04"].toInt() + row["REQ_TIME"].toInt();

                                //합계 - 누적저장
                                if (sumDic.ContainsKey("W04"))
                                {
                                    sumDic["W04"] = sumDic["W04"] + row["REQ_TIME"].toInt();
                                }
                                else
                                {
                                    sumDic.Add("W04", newRow["W04"].toDecimal());
                                }

                                break;

                            case "W05": //연차
                            case "W06": //반차

                                newRow["W05_W06"] = Math.Round(((newRow["W05_W06"].toDecimal() * 480) + row["REQ_TIME"].toDecimal()).toDecimal() / 480, 1);

                                //합계 - 누적저장
                                if (sumDic.ContainsKey("W05_W06"))
                                {
                                    sumDic["W05_W06"] = sumDic["W05_W06"] + Math.Round((row["REQ_TIME"].toDecimal()).toDecimal() / 480, 1);
                                }
                                else
                                {
                                    sumDic.Add("W05_W06", newRow["W05_W06"].toDecimal());
                                }

                                break;

                            case "W07": //경조

                                newRow["W07"] = Math.Round(((newRow["W07"].toDecimal() * 480) + row["REQ_TIME"].toDecimal()).toDecimal() / 480, 1);

                                //합계 - 누적저장
                                if (sumDic.ContainsKey("W07"))
                                {
                                    sumDic["W07"] = sumDic["W07"] + Math.Round((row["REQ_TIME"].toDecimal()).toDecimal() / 480, 1);
                                }
                                else
                                {
                                    sumDic.Add("W07", newRow["W07"].toDecimal());
                                }

                                break;

                            case "W08": //잔업
                            case "W09": //교대
                            case "W10": //특근
                            case "W11": //휴일교대

                                //근무형태에 따른 주,야간 정례화 시간을 가져온다.
                                DataTable idleTable = new DataTable("RQSTDT");
                                idleTable.Columns.Add("PLT_CODE", typeof(string));
                                idleTable.Columns.Add("EMP_CODE", typeof(string));
                                idleTable.Columns.Add("WORK_YEAR", typeof(string));
                                idleTable.Columns.Add("EWT_DATE", typeof(string));

                                DataRow idleRow = idleTable.NewRow();
                                idleRow["PLT_CODE"] = acInfo.PLT_CODE;
                                idleRow["EMP_CODE"] = row["EMP_CODE"];
                                idleRow["WORK_YEAR"] = row["REQ_START_DATE"].toDateTime().ToString("yyyy");
                                idleRow["EWT_DATE"] = row["REQ_START_DATE"].toDateTime().ToString("yyyyMMdd");

                                idleTable.Rows.Add(idleRow);
                                DataSet idleSet = new DataSet();
                                idleSet.Tables.Add(idleTable);

                                DataSet resultSet = BizRun.QBizRun.ExecuteService(this, "WOR01A_SER10", idleSet, "RQSTDT", "RSLTDT");

                                //IDLE_FLAG - 0 : 주간 , 1 : 야간
                                string idleFillter = "IDLE_FLAG = '0'";

                                if (resultSet.Tables["RSLTDT"].Rows.Count > 0)
                                {
                                    if (resultSet.Tables["RSLTDT"].Rows[0]["EWT_TYPE"].ToString() == "1")
                                    {
                                        idleFillter = "IDLE_FLAG = '1'";
                                    }
                                }

                                //휴일교대일 경우 강제 야간근무자
                                if (row["WORK_CODE"].ToString() == "W11")
                                {
                                    idleFillter = "IDLE_FLAG = '1'";
                                }

                                //기준시간의 교집합구하기
                                //1.신청시간에 기준시간 시작시간과 종료시간이 포함된경우
                                //2.기준시작시간이 신청시간 사이에 있는경우
                                //3.기준시간에 신청시간 시작시간과 종료시간이 포함된경우
                                //5.기준종료시간이 신청시간 사이에 있는경우
                                DataRow[] workRows = _WorkTimeSet.Tables["RSLTDT"].Select("WORK_CODE = '" + row["WORK_CODE"].ToString() + "'");

                                Dictionary<string, bool> nextdaydic = new Dictionary<string, bool>();

                                if (!nextdaydic.ContainsKey(row["WORK_CODE"].ToString()))
                                {
                                    nextdaydic.Add(row["WORK_CODE"].ToString(), false);
                                }
                                else
                                {
                                    nextdaydic[row["WORK_CODE"].ToString()] = false;
                                }

                                int iSeq = 1;
                                foreach (DataRow workRow in workRows)
                                {
                                    DateTime reqStartDateTime = row["REQ_START_DATE"].toDateTime();
                                    DateTime reqEndDateTime = row["REQ_END_DATE"].toDateTime();

                                    DateTime stdStartDate = new DateTime(reqStartDateTime.Year, reqStartDateTime.Month, reqStartDateTime.Day, workRow["WORK_START_HOUR"].ToString().Substring(0, 2).toInt(), workRow["WORK_START_HOUR"].ToString().Substring(2, 2).toInt(), 0);
                                    DateTime stdEndDate = new DateTime(reqStartDateTime.Year, reqStartDateTime.Month, reqStartDateTime.Day, workRow["WORK_END_HOUR"].ToString().Substring(0, 2).toInt(), workRow["WORK_END_HOUR"].ToString().Substring(2, 2).toInt(), 0);

                                    if (nextdaydic[row["WORK_CODE"].ToString()])
                                    {
                                        stdStartDate = stdStartDate.AddDays(1);
                                        stdEndDate = stdEndDate.AddDays(1);
                                    }

                                    //종료시간이 작을경우 하루 더함
                                    if (workRow["WORK_START_HOUR"].ToString().Substring(0, 2).toInt() > workRow["WORK_END_HOUR"].ToString().Substring(0, 2).toInt())
                                    {
                                        stdEndDate = stdEndDate.AddDays(1);

                                        nextdaydic[row["WORK_CODE"].ToString()] = true;
                                    }

                                    //if (workRows[0]["WORK_START_HOUR"].toInt() > workRow["WORK_START_HOUR"].toInt())
                                    //{
                                    //    stdStartDate = stdStartDate.AddDays(1);
                                    //    stdEndDate = stdEndDate.AddDays(1);
                                    //}

                                    TimeSpan ts = new TimeSpan();
                                    double time = 0.0;
                                    //시간 교집합 구분
                                    if (reqStartDateTime <= stdStartDate && reqEndDateTime >= stdEndDate) //신청시간에 기준시간 시작시간과 종료시간이 포함된경우
                                    {
                                        ts = stdEndDate.Subtract(stdStartDate);
                                        time = ts.TotalMinutes;
                                        time = time - GetIdleTime(stdStartDate, stdEndDate, idleFillter);
                                        newRow[row["WORK_CODE"].ToString() + "_" + iSeq.ToString()] = Math.Round(((newRow[row["WORK_CODE"].ToString() + "_" + iSeq.ToString()].toDouble() * 60) + time).toDecimal() / 60, 1);
                                    }
                                    else if (reqStartDateTime <= stdStartDate && reqEndDateTime >= stdStartDate) //기준시작시간이 신청시간 사이에 있는경우
                                    {
                                        ts = reqEndDateTime.Subtract(stdStartDate);
                                        time = ts.TotalMinutes;
                                        time = time - GetIdleTime(stdStartDate, reqEndDateTime, idleFillter);
                                        newRow[row["WORK_CODE"].ToString() + "_" + iSeq.ToString()] = Math.Round(((newRow[row["WORK_CODE"].ToString() + "_" + iSeq.ToString()].toDouble() * 60) + time).toDecimal() / 60, 1);
                                    }
                                    else if (stdStartDate <= reqStartDateTime && stdEndDate >= reqEndDateTime) //기준시간에 신청시간 시작시간과 종료시간이 포함된경우
                                    {
                                        ts = reqEndDateTime.Subtract(reqStartDateTime);
                                        time = ts.TotalMinutes;
                                        time = time - GetIdleTime(reqStartDateTime, reqEndDateTime, idleFillter);
                                        newRow[row["WORK_CODE"].ToString() + "_" + iSeq.ToString()] = Math.Round(((newRow[row["WORK_CODE"].ToString() + "_" + iSeq.ToString()].toDouble() * 60) + time).toDecimal() / 60, 1);
                                    }
                                    else if (reqStartDateTime <= stdEndDate && reqEndDateTime >= stdEndDate) //기준종료시간이 신청시간 사이에 있는경우
                                    {
                                        ts = stdEndDate.Subtract(reqStartDateTime);
                                        time = ts.TotalMinutes;
                                        time = time - GetIdleTime(reqStartDateTime, stdEndDate, idleFillter);
                                        newRow[row["WORK_CODE"].ToString() + "_" + iSeq.ToString()] = Math.Round(((newRow[row["WORK_CODE"].ToString() + "_" + iSeq.ToString()].toDouble() * 60) + time).toDecimal() / 60, 1);
                                    }

                                    if (time > 0)
                                    {
                                        //합계 - 누적저장
                                        if (sumDic.ContainsKey(row["WORK_CODE"].ToString() + "_" + iSeq.ToString()))
                                        {
                                            sumDic[row["WORK_CODE"].ToString() + "_" + iSeq.ToString()] = sumDic[row["WORK_CODE"].ToString() + "_" + iSeq.ToString()] + Math.Round((time).toDecimal() / 60, 1);
                                        }
                                        else
                                        {
                                            sumDic.Add(row["WORK_CODE"].ToString() + "_" + iSeq.ToString(), newRow[row["WORK_CODE"].ToString() + "_" + iSeq.ToString()].toDecimal());
                                        }

                                        //야간근무를 제외한 연장 누계시간
                                        if (workRow["NIGHT_FLAG"].ToString() != "1")
                                        {
                                            //newRow["CUM_TIME"] = newRow["CUM_TIME"].toDecimal() + newRow[row["WORK_CODE"].ToString() + "_" + iSeq.ToString()].toDecimal();
                                            newRow["CUM_TIME"] = newRow["CUM_TIME"].toDecimal() + Math.Round((time).toDecimal() / 60, 1).toDecimal();

                                            //합계 - 누적저장
                                            if (sumDic.ContainsKey("CUM_TIME"))
                                            {
                                                //sumDic["CUM_TIME"] = sumDic["CUM_TIME"] + newRow[row["WORK_CODE"].ToString() + "_" + iSeq.ToString()].toDecimal();
                                                sumDic["CUM_TIME"] = sumDic["CUM_TIME"] + Math.Round((time).toDecimal() / 60, 1).toDecimal();
                                            }
                                            else
                                            {
                                                sumDic.Add("CUM_TIME", newRow["CUM_TIME"].toDecimal());
                                            }
                                        }
                                    }

                                    iSeq++;
                                }

                                break;
                        }
                    }

                    //지,조 외출 연차 시간 : (지각/60 + 외출/60 + 조퇴/60 + 무급/60) + 연차반차 * 8  + 경조 * 8
                    newRow["HOLI_TIME"] = (Math.Round((newRow["W01"].toDecimal() / 60), 2) + Math.Round((newRow["W02"].toDecimal() / 60), 2) + Math.Round((newRow["W03"].toDecimal() / 60), 2) + Math.Round((newRow["W04"].toDecimal() / 60), 2))
                       + (newRow["W05_W06"].toDecimal() * 8) + (newRow["W07"].toDecimal() * 8);

                    ////합계 - 누적저장
                    //if (sumDic.ContainsKey("HOLI_TIME"))
                    //{
                    //    sumDic["HOLI_TIME"] = sumDic["HOLI_TIME"] + newRow["HOLI_TIME"].toDecimal();
                    //}
                    //else
                    //{
                    //    sumDic.Add("HOLI_TIME", newRow["HOLI_TIME"].toDecimal());
                    //}

                    //고정값
                    DataRow[] dayRows = e.result.Tables["RSLTDT_WORKDAY"].Select("WORK_MONTH = '" + month + "'");
                    if (dayRows.Length > 0)
                    {
                        newRow["WORK_DAY"] = dayRows[0]["WORK_DAY"];
                        newRow["WORK_MONTH_TIME"] = dayRows[0]["WORK_MONTH_TIME"];
                        newRow["WORK_HOUR"] = dayRows[0]["WORK_HOUR"];
                    }

                    //실근무시간 : (기본근무시간 + 연장누계시간) - 지,조 외출연차시간
                    newRow["WORK_TIME"] = newRow["WORK_HOUR"].toDecimal() + newRow["CUM_TIME"].toDecimal() - newRow["HOLI_TIME"].toDecimal();

                    //월잔여시간 : 월별최대시간 - 실근무시간
                    newRow["REMAIN_TIME"] = newRow["WORK_MONTH_TIME"].toDecimal() - newRow["WORK_TIME"].toDecimal();

                    gridTable.Rows.Add(newRow);
                }

                //합계
                DataRow sumRow = gridTable.NewRow();
                sumRow["YEAR"] = "합계";

                foreach (DataColumn col in gridTable.Columns)
                {
                    if (sumDic.ContainsKey(col.ColumnName))
                    {
                        sumRow[col.ColumnName] = sumDic[col.ColumnName];
                    }
                }

                gridTable.Rows.Add(sumRow);

                //사용
                DataRow useRow = gridTable.NewRow();
                useRow["YEAR"] = "사용";
                useRow["W01"] = "연차 : ";
                if (sumDic.ContainsKey("W05_W06"))
                {
                    useRow["W02"] = sumDic["W05_W06"];
                }

                //분기별 잔여시간 : 1분기
                int iquarter = 0;
                int remainQuarter = 0;
                foreach (DataRow row in gridTable.Rows)
                {
                    if (iquarter >= 0)
                    {
                        remainQuarter = (remainQuarter.toDecimal() + (row["WORK_MONTH_TIME"].toDecimal() - row["WORK_TIME"].toDecimal())).toInt();

                        if (iquarter > 1)
                        {
                            break;
                        }
                    }
                    iquarter++;
                }

                useRow["W11_1"] = "1/4";
                useRow["W11_2"] = remainQuarter;
                gridTable.Rows.Add(useRow);

                //내역
                DataRow conRow = gridTable.NewRow();
                conRow["YEAR"] = "내역";
                conRow["W01"] = "경조 : ";
                if (sumDic.ContainsKey("W07"))
                {
                    conRow["W02"] = sumDic["W07"];
                }

                //분기별 잔여시간 : 2분기
                iquarter = 0;
                remainQuarter = 0;
                foreach (DataRow row in gridTable.Rows)
                {
                    if (iquarter >= 3)
                    {
                        remainQuarter = (remainQuarter.toDecimal() + (row["WORK_MONTH_TIME"].toDecimal() - row["WORK_TIME"].toDecimal())).toInt();

                        if (iquarter > 4)
                        {
                            break;
                        }
                    }
                    iquarter++;
                }

                conRow["W11_1"] = "2/4";
                conRow["W11_2"] = remainQuarter;

                gridTable.Rows.Add(conRow);

                //발생
                DataRow occRow = gridTable.NewRow();
                occRow["YEAR"] = "발생";
                occRow["W01"] = "연차 : ";
                double dHoli = 0.0;
                if (e.result.Tables["RSLTDT_EMP_HOLI"].Rows.Count > 0)
                {
                    dHoli = e.result.Tables["RSLTDT_EMP_HOLI"].Rows[0]["HOLI_OCCUR_INPUT_CNT"].toDouble();
                }
                occRow["W02"] = dHoli;


                //분기별 잔여시간 : 3분기
                iquarter = 0;
                remainQuarter = 0;
                foreach (DataRow row in gridTable.Rows)
                {
                    if (iquarter >= 6)
                    {
                        remainQuarter = (remainQuarter.toDecimal() + (row["WORK_MONTH_TIME"].toDecimal() - row["WORK_TIME"].toDecimal())).toInt();

                        if (iquarter > 7)
                        {
                            break;
                        }
                    }
                    iquarter++;
                }

                occRow["W11_1"] = "3/4";
                occRow["W11_2"] = remainQuarter;

                gridTable.Rows.Add(occRow);

                //사용
                DataRow useRow2 = gridTable.NewRow();
                useRow2["YEAR"] = "사용";
                useRow2["W01"] = "연차 : ";


                //분기별 잔여시간 : 4분기
                iquarter = 0;
                remainQuarter = 0;
                foreach (DataRow row in gridTable.Rows)
                {
                    if (iquarter >= 9)
                    {
                        remainQuarter = (remainQuarter.toDecimal() + (row["WORK_MONTH_TIME"].toDecimal() - row["WORK_TIME"].toDecimal())).toInt();

                        if (iquarter > 10)
                        {
                            break;
                        }
                    }
                    iquarter++;
                }

                useRow2["W11_1"] = "4/4";
                useRow2["W11_2"] = remainQuarter;

                gridTable.Rows.Add(useRow2);

                //남은
                DataRow remainRow = gridTable.NewRow();
                remainRow["YEAR"] = "남은";
                remainRow["W01"] = "연차 : ";
                double dUseHoli = 0.0;
                if (sumDic.ContainsKey("W05_W06"))
                {
                    dUseHoli = sumDic["W05_W06"].toDouble();
                }

                remainRow["W02"] = dHoli - dUseHoli;
                gridTable.Rows.Add(remainRow);

                acBandGridView1.GridControl.DataSource = gridTable;
                acBandGridView1.OptionsView.ShowColumnHeaders = true;
                acBandGridView1.BestFitColumns();
                acBandGridView1.OptionsView.ShowColumnHeaders = false;

                //base.SetLog(e.executeType, e.result.Tables["RSLTDT"].Rows.Count, e.executeTime);

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        int GetIdleTime(DateTime startDate, DateTime endDate, String idleFilter)
        {
            int idleTime = 0;

            DataRow[] idleRows = _IdleSet.Tables["RSLTDT"].Select(idleFilter);

            foreach (DataRow row in idleRows)
            {
                string sIdleHour = row["IDLE_START_TIME"].ToString().Substring(0, 2);
                string sIdleMinute = row["IDLE_START_TIME"].ToString().Substring(2, 2);

                string eIdleHour = row["IDLE_END_TIME"].ToString().Substring(0, 2);
                string eIdleMinute = row["IDLE_END_TIME"].ToString().Substring(2, 2);

                DateTime idleStartTime = new DateTime(startDate.Year, startDate.Month, startDate.Day, sIdleHour.toInt(), sIdleMinute.toInt(), 0);
                DateTime idleEndTime = new DateTime(startDate.Year, startDate.Month, startDate.Day, eIdleHour.toInt(), eIdleMinute.toInt(), 0);

                if (startDate.Day != endDate.Day && (sIdleHour.toInt() >= 0 && sIdleHour.toInt() <= 7))
                {
                    idleStartTime = idleStartTime.AddDays(1);
                    idleEndTime = idleEndTime.AddDays(1);
                }

                TimeSpan idleTs = new TimeSpan();

                if (idleStartTime < startDate && idleEndTime > startDate)
                {
                    //정례화 시작시간이 신청시작시간보다 작거나 같고 정례화 종료시간이 신청시작시간보다 클떄
                    idleTs = idleEndTime.Subtract(startDate);

                }
                else if (idleStartTime >= startDate && idleEndTime <= endDate)
                {
                    //정례화 시작시간 종료시간이 신청시간사이에 포함될때
                    idleTs = idleEndTime.Subtract(idleStartTime);
                }
                else if (idleStartTime < endDate && idleEndTime > endDate)
                {
                    //정례화 시작시간이 신청종료시간보다 작고 정례화 종료시간이 신청종료시간보다 클때
                    idleTs = endDate.Subtract(idleStartTime);
                }
                else if (idleStartTime <= startDate && idleEndTime >= endDate)
                {
                    //정례화 시간이 신청시간보다 클때
                    idleTs = endDate.Subtract(startDate);
                }

                idleTime = idleTime + idleTs.TotalMinutes.toInt();
            }

            return idleTime;
        }
    }
}

