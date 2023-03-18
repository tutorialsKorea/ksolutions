using BizManager;
using ControlManager;
using DevExpress.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace WOR
{
    public sealed partial class WOR11A_D0A : BaseMenuDialog
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

        DataRow _linkRow = null;

        private Color _progColor = acInfo.SysConfig.GetSysConfigByMemory("APP_STATE_PROG").toColor();
        private Color _okColor = acInfo.SysConfig.GetSysConfigByMemory("APP_STATE_OK").toColor();
        private Color _denyColor = acInfo.SysConfig.GetSysConfigByMemory("APP_STATE_DENY").toColor();

        private DataSet _WorkSet = null;
        private DataSet _WorkTimeSet = null;
        private DataSet _IdleSet = null;

        private string _year = "";

        public WOR11A_D0A(DataRow linkRow, String year)
        {
            InitializeComponent();

            _linkRow = linkRow;
            _year = year;
        }

        public override void DialogInit()
        {
            barItemSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barItemSaveClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

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

            string[] bands6 = new string[] { "일단위 기록", "연차\r\n반차" };
            string[] bands7 = new string[] { "일단위 기록", "경조" };

            acBandGridView1.AddTextEdit("W05_W06", "연차\r\n반차", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.NONE, bands6);
            acBandGridView1.AddTextEdit("W07", "경조", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.NONE, bands7);

            string[] bands8 = new string[] { nowDate.Year.ToString() + "년" + " 고정값", "월근무\r\n일수" };
            string[] bands9 = new string[] { nowDate.Year.ToString() + "년" + " 고정값", "월별\r\n최대\r\n시간\r\n(주52)" };
            string[] bands10 = new string[] { nowDate.Year.ToString() + "년" + " 고정값", "기본근무\r\n일수\r\n(근무일수*8)" };

            acBandGridView1.AddTextEdit("WORK_DAY", "월근무\r\n일수", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.NONE, bands8);

            acBandGridView1.AddTextEdit("WORK_MONTH_TIME", "월별\r\n최대\r\n시간\r\n(주52)", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.NONE, bands9);

            acBandGridView1.AddTextEdit("WORK_HOUR", "기본근무\r\n일수\r\n(근무일수*8)", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.NONE, bands10);

            string[] bands11 = new string[] { "시간단위 기록", "지,조\r\n외출\r\n연차\r\n시간" };
            string[] bands12 = new string[] { "시간단위 기록", "실근무시간" };
            string[] bands13 = new string[] { "시간단위 기록", "월잔여\r\n가능\r\n시간" };
            string[] bands14 = new string[] { "시간단위 기록", "연장\r\n누계\r\n시간" };

            acBandGridView1.AddTextEdit("HOLI_TIME", "지,조\r\n외출\r\n연차\r\n시간", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.NONE, bands11);
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
                    string sTime = row["WORK_START_HOUR"].ToString().Substring(0, 2) + ":" + row["WORK_START_HOUR"].ToString().Substring(2, 2);
                    string eTime = row["WORK_END_HOUR"].ToString().Substring(0, 2) + ":" + row["WORK_END_HOUR"].ToString().Substring(2, 2);
                    string[] bands = new string[] { "시간단위 기록", row["WORK_NAME"].ToString(), sTime, eTime, row["WORK_RATE"].ToString() };

                    acBandGridView1.AddTextEdit(row["WORK_CODE"].ToString() + "_" + iBands1.ToString(), row["WORK_NAME"].ToString(), "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.NONE, bands);
                    acBandGridView1.Columns[row["WORK_CODE"].ToString() + "_" + iBands1.ToString()].Tag = row["WORK_START_HOUR"].ToString() + "-" + row["WORK_END_HOUR"].ToString();
                    iBands1++;
                }
                else if (row["WORK_CODE"].ToString() == "W09")
                {
                    string sTime = row["WORK_START_HOUR"].ToString().Substring(0, 2) + ":" + row["WORK_START_HOUR"].ToString().Substring(2, 2);
                    string eTime = row["WORK_END_HOUR"].ToString().Substring(0, 2) + ":" + row["WORK_END_HOUR"].ToString().Substring(2, 2);
                    string[] bands = new string[] { "시간단위 기록", row["WORK_NAME"].ToString(), sTime, eTime, row["WORK_RATE"].ToString() };

                    acBandGridView1.AddTextEdit(row["WORK_CODE"].ToString() + "_" + iBands2.ToString(), row["WORK_NAME"].ToString(), "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.NONE, bands);
                    acBandGridView1.Columns[row["WORK_CODE"].ToString() + "_" + iBands2.ToString()].Tag = row["WORK_START_HOUR"].ToString() + "-" + row["WORK_END_HOUR"].ToString();
                    iBands2++;
                }
                else if (row["WORK_CODE"].ToString() == "W10")
                {
                    string sTime = row["WORK_START_HOUR"].ToString().Substring(0, 2) + ":" + row["WORK_START_HOUR"].ToString().Substring(2, 2);
                    string eTime = row["WORK_END_HOUR"].ToString().Substring(0, 2) + ":" + row["WORK_END_HOUR"].ToString().Substring(2, 2);
                    string[] bands = new string[] { "시간단위 기록", row["WORK_NAME"].ToString(), sTime, eTime, row["WORK_RATE"].ToString() };

                    acBandGridView1.AddTextEdit(row["WORK_CODE"].ToString() + "_" + iBands3.ToString(), row["WORK_NAME"].ToString(), "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.NONE, bands);
                    acBandGridView1.Columns[row["WORK_CODE"].ToString() + "_" + iBands3.ToString()].Tag = row["WORK_START_HOUR"].ToString() + "-" + row["WORK_END_HOUR"].ToString();
                    iBands3++;
                }
                else if (row["WORK_CODE"].ToString() == "W11")
                {
                    string sTime = row["WORK_START_HOUR"].ToString().Substring(0, 2) + ":" + row["WORK_START_HOUR"].ToString().Substring(2, 2);
                    string eTime = row["WORK_END_HOUR"].ToString().Substring(0, 2) + ":" + row["WORK_END_HOUR"].ToString().Substring(2, 2);
                    string[] bands = new string[] { "시간단위 기록", row["WORK_NAME"].ToString(), sTime, eTime, row["WORK_RATE"].ToString() };

                    acBandGridView1.AddTextEdit(row["WORK_CODE"].ToString() + "_" + iBands4.ToString(), row["WORK_NAME"].ToString(), "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.NONE, bands);
                    acBandGridView1.Columns[row["WORK_CODE"].ToString() + "_" + iBands4.ToString()].Tag = row["WORK_START_HOUR"].ToString() + "-" + row["WORK_END_HOUR"].ToString();
                    iBands4++;
                }
            }

            acBandGridView1.BestFitColumns();
            acBandGridView1.ColumnPanelRowHeight = 100;
            acBandGridView1.OptionsView.ShowColumnHeaders = false;

            acBandGridView1.Bands[0].Visible = false;

            acBandGridView1.CustomDrawCell += acBandGridView1_CustomDrawCell;
            acBandGridView1.FocusedRowChanged += acBandGridView1_FocusedRowChanged;


            acBandGridView2.OptionsView.AllowCellMerge = true;

            //상세그리드
            string[] DetailBands1 = new string[] { "날짜", "월" };
            string[] DetailBands1_1 = new string[] { "날짜", "일" };
            acBandGridView2.AddTextEdit("MONTH", "월", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acBandGridView.emTextEditMask.NONE, DetailBands1);
            acBandGridView2.AddTextEdit("DAY", "일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acBandGridView.emTextEditMask.NONE, DetailBands1_1);

            string[] DetailBands2 = new string[] { "분단위 기록", "지각" };
            string[] DetailBands3 = new string[] { "분단위 기록", "외출" };
            string[] DetailBands4 = new string[] { "분단위 기록", "조퇴" };
            string[] DetailBands5 = new string[] { "분단위 기록", "무급" };

            acBandGridView2.AddTextEdit("W01", "지각", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.NONE, DetailBands2);
            acBandGridView2.AddTextEdit("W02", "외출", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.NONE, DetailBands3);
            acBandGridView2.AddTextEdit("W03", "조퇴", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.NONE, DetailBands4);
            acBandGridView2.AddTextEdit("W04", "무급", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.NONE, DetailBands5);

            string[] DetailBands6 = new string[] { "일단위 기록", "연차\r\n반차" };
            string[] DetailBands7 = new string[] { "일단위 기록", "경조" };

            acBandGridView2.AddTextEdit("W05_W06", "연차\r\n반차", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.NONE, DetailBands6);
            acBandGridView2.AddTextEdit("W07", "경조", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.NONE, DetailBands7);

            int iDetailBands1 = 1;
            int iDetailBands2 = 1;
            int iDetailBands3 = 1;
            int iDetailBands4 = 1;
            foreach (DataRow row in _WorkTimeSet.Tables["RSLTDT"].Rows)
            {
                if (row["WORK_CODE"].ToString() == "W08")
                {
                    string sTime = row["WORK_START_HOUR"].ToString().Substring(0, 2) + ":" + row["WORK_START_HOUR"].ToString().Substring(2, 2);
                    string eTime = row["WORK_END_HOUR"].ToString().Substring(0, 2) + ":" + row["WORK_END_HOUR"].ToString().Substring(2, 2);
                    string[] DetailBands = new string[] { "시간단위 기록", row["WORK_NAME"].ToString(), sTime, eTime, row["WORK_RATE"].ToString() };

                    acBandGridView2.AddTextEdit(row["WORK_CODE"].ToString() + "_" + iDetailBands1.ToString(), row["WORK_NAME"].ToString(), "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.NONE, DetailBands);
                    acBandGridView2.Columns[row["WORK_CODE"].ToString() + "_" + iDetailBands1.ToString()].Tag = row["WORK_START_HOUR"].ToString() + "-" + row["WORK_END_HOUR"].ToString();
                    iDetailBands1++;
                }
                else if (row["WORK_CODE"].ToString() == "W09")
                {
                    string sTime = row["WORK_START_HOUR"].ToString().Substring(0, 2) + ":" + row["WORK_START_HOUR"].ToString().Substring(2, 2);
                    string eTime = row["WORK_END_HOUR"].ToString().Substring(0, 2) + ":" + row["WORK_END_HOUR"].ToString().Substring(2, 2);
                    string[] DetailBands = new string[] { "시간단위 기록", row["WORK_NAME"].ToString(), sTime, eTime, row["WORK_RATE"].ToString() };

                    acBandGridView2.AddTextEdit(row["WORK_CODE"].ToString() + "_" + iDetailBands2.ToString(), row["WORK_NAME"].ToString(), "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.NONE, DetailBands);
                    acBandGridView2.Columns[row["WORK_CODE"].ToString() + "_" + iDetailBands2.ToString()].Tag = row["WORK_START_HOUR"].ToString() + "-" + row["WORK_END_HOUR"].ToString();
                    iDetailBands2++;
                }
                else if (row["WORK_CODE"].ToString() == "W10")
                {
                    string sTime = row["WORK_START_HOUR"].ToString().Substring(0, 2) + ":" + row["WORK_START_HOUR"].ToString().Substring(2, 2);
                    string eTime = row["WORK_END_HOUR"].ToString().Substring(0, 2) + ":" + row["WORK_END_HOUR"].ToString().Substring(2, 2);
                    string[] DetailBands = new string[] { "시간단위 기록", row["WORK_NAME"].ToString(), sTime, eTime, row["WORK_RATE"].ToString() };

                    acBandGridView2.AddTextEdit(row["WORK_CODE"].ToString() + "_" + iDetailBands3.ToString(), row["WORK_NAME"].ToString(), "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.NONE, DetailBands);
                    acBandGridView2.Columns[row["WORK_CODE"].ToString() + "_" + iDetailBands3.ToString()].Tag = row["WORK_START_HOUR"].ToString() + "-" + row["WORK_END_HOUR"].ToString();
                    iDetailBands3++;
                }
                else if (row["WORK_CODE"].ToString() == "W11")
                {
                    string sTime = row["WORK_START_HOUR"].ToString().Substring(0, 2) + ":" + row["WORK_START_HOUR"].ToString().Substring(2, 2);
                    string eTime = row["WORK_END_HOUR"].ToString().Substring(0, 2) + ":" + row["WORK_END_HOUR"].ToString().Substring(2, 2);
                    string[] DetailBands = new string[] { "시간단위 기록", row["WORK_NAME"].ToString(), sTime, eTime, row["WORK_RATE"].ToString() };

                    acBandGridView2.AddTextEdit(row["WORK_CODE"].ToString() + "_" + iDetailBands4.ToString(), row["WORK_NAME"].ToString(), "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.NONE, DetailBands);
                    acBandGridView2.Columns[row["WORK_CODE"].ToString() + "_" + iDetailBands4.ToString()].Tag = row["WORK_START_HOUR"].ToString() + "-" + row["WORK_END_HOUR"].ToString();
                    iDetailBands4++;
                }
            }


            foreach (acBandedGridColumn col in acBandGridView2.Columns)
            {
                if (col.FieldName == "MONTH")
                {
                    col.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
                }
                else
                {
                    col.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
                }
            }

            acBandGridView2.BestFitColumns();
            acBandGridView2.ColumnPanelRowHeight = 100;
            acBandGridView2.OptionsView.ShowColumnHeaders = false;
            acBandGridView2.Bands[0].Visible = false;
            acBandGridView2.CustomDrawCell += acBandGridView2_CustomDrawCell;

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String));
            paramTable.Columns.Add("EMP_CODE", typeof(String));
            paramTable.Columns.Add("YEAR", typeof(String));

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["EMP_CODE"] = _linkRow["EMP_CODE"];
            paramRow["YEAR"] = _year;

            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();

            paramSet.Tables.Add(paramTable);

            DataSet resultSet = BizRun.QBizRun.ExecuteService(this, "WOR03A_SER2", paramSet, "RQSTDT", "RSLTDT");

            //근로현황데이터 가공
            _WorkSet = resultSet;

            DataTable gridTable = ((DataTable)acBandGridView1.GridControl.DataSource).Clone();

            //합계 저장 dictionary
            Dictionary<string, decimal> sumDic = new Dictionary<string, decimal>();

            for (int i = 1; i <= 12; i++)
            {
                DataRow newRow = gridTable.NewRow();
                newRow["YEAR"] = i.ToString() + "월";

                string month = resultSet.Tables["RQSTDT"].Rows[0]["YEAR"].ToString() + Convert.ToString(i).PadLeft(2, '0');

                DataRow[] reqRwos = resultSet.Tables["RSLTDT"].Select("REQ_START_MONTH = '" + month + "'");

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

                            DataSet resultSet2 = BizRun.QBizRun.ExecuteService(this, "WOR01A_SER10", idleSet, "RQSTDT", "RSLTDT");

                            //IDLE_FLAG - 0 : 주간 , 1 : 야간
                            string idleFillter = "IDLE_FLAG = '0'";

                            if (resultSet2.Tables["RSLTDT"].Rows.Count > 0)
                            {
                                if (resultSet2.Tables["RSLTDT"].Rows[0]["EWT_TYPE"].ToString() == "1")
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
                DataRow[] dayRows = resultSet.Tables["RSLTDT_WORKDAY"].Select("WORK_MONTH = '" + month + "'");
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
            if (resultSet.Tables["RSLTDT_EMP_HOLI"].Rows.Count > 0)
            {
                dHoli = resultSet.Tables["RSLTDT_EMP_HOLI"].Rows[0]["HOLI_OCCUR_INPUT_CNT"].toDouble();
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
            double dUseHoli = 0;
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


            base.DialogInit();
        }

        private void acLayoutControl1_OnValueChanged(object sender, IBaseEditControl info, object newValue)
        {
            //acLayoutControl layout = sender as acLayoutControl;

            //switch (info.ColumnName)
            //{
            //}
        }

        public override void DialogNew()
        {
            barItemSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

            base.DialogNew();
        }

        public override void DialogOpen()
        {
            barItemSaveClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

            base.DialogOpen();
        }



        private void acBandGridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                this.DetailGrid();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
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

        private void acBandGridView2_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.RowHandle < 0) return;

            string dayValue = acBandGridView2.GetRowCellDisplayText(e.RowHandle, "DAY").ToString();

            if (dayValue == "계")
            {
                e.Appearance.BackColor = Color.DimGray;
                e.Appearance.ForeColor = Color.White;
            }

            string monValue = acBandGridView2.GetRowCellDisplayText(e.RowHandle, "MONTH").ToString();

            if (monValue.IndexOf("월") < 0 && monValue != "")
            {
                if (e.Column.FieldName == "MONTH"
                    || e.Column.FieldName == "DAY")
                {
                    e.Appearance.BackColor = Color.AliceBlue;
                }

                if ((e.Column.FieldName == "W02"
                        || e.Column.FieldName == "W03")
                    && (monValue == "잔업"
                        || monValue == "평일 교대"))
                {
                    e.Appearance.BackColor = Color.Honeydew;
                }
            }

            if (dayValue.IndexOf("일") > -1)
            {
                if (e.Column.FieldName.StartsWith("W01")
                    || e.Column.FieldName.StartsWith("W02")
                    || e.Column.FieldName.StartsWith("W03")
                    || e.Column.FieldName.StartsWith("W04"))
                {
                    e.Appearance.BackColor = Color.WhiteSmoke;
                }
                else if (e.Column.FieldName.StartsWith("W05")
                        || e.Column.FieldName.StartsWith("W07"))
                {

                }
                else if (e.Column.FieldName.StartsWith("W08"))
                {
                    e.Appearance.BackColor = Color.Linen;
                }
                else if (e.Column.FieldName.StartsWith("W09"))
                {
                    e.Appearance.BackColor = Color.Cornsilk;
                }
                else if (e.Column.FieldName.StartsWith("W10"))
                {
                    e.Appearance.BackColor = Color.Azure;
                }
                else if (e.Column.FieldName.StartsWith("W11"))
                {
                    e.Appearance.BackColor = Color.FloralWhite;
                }
            }

            //if (e.Column.FieldName == "WORK_DAY"
            //    || e.Column.FieldName == "WORK_MONTH_TIME"
            //    || e.Column.FieldName == "WORK_HOUR")
            //{
            //    if (e.RowHandle < 12)
            //    {
            //        e.Appearance.BackColor = Color.LightGray;
            //    }
            //}

            //string sFirstColumn = acBandGridView1.GetRowCellDisplayText(e.RowHandle, "YEAR").ToString();

            //if (sFirstColumn == "합계")
            //{
            //    e.Appearance.BackColor = Color.DimGray;
            //    e.Appearance.ForeColor = Color.White;
            //}

            //if (sFirstColumn == "사용"
            //    || sFirstColumn == "내역"
            //    || sFirstColumn == "발생")
            //{
            //    if (e.Column.FieldName.Contains("W11"))
            //    {
            //        string[] cols = e.Column.FieldName.Split('_');

            //        int iCols = cols[1].toInt();

            //        if (iCols < 3)
            //        {
            //            e.Appearance.BackColor = Color.LightGreen;
            //            e.Appearance.ForeColor = Color.Black;
            //        }
            //    }
            //}
        }


        void DetailGrid()
        {
            DataTable gridTable = ((DataTable)acBandGridView2.GridControl.DataSource).Clone();

            DataRow focusRow = acBandGridView1.GetFocusedDataRow();

            if (focusRow == null) return;

            if (focusRow["YEAR"].ToString().IndexOf("월") < 0) return;

            //연차(W05),경조(W07) 날짜 쪼개기
            DataRow[] dayRows = _WorkSet.Tables["RSLTDT"].Select("WORK_CODE IN ('W05','W07')");

            foreach (DataRow row in dayRows)
            {
                int days = row["REQ_TIME"].toInt() / 480;

                for (int i = 0; i < days; i++)
                {
                    DateTime reqDateTime = row["REQ_START_DATE"].toDateTime().AddDays(i);
                    DataRow[] holiRows = _WorkSet.Tables["RSLTDT_HOLI"].Select("HOLI_DATE = '" + reqDateTime.toDateString("yyyyMMdd") + "'");

                    if (holiRows.Length > 0
                        || reqDateTime.DayOfWeek == DayOfWeek.Saturday
                        || reqDateTime.DayOfWeek == DayOfWeek.Sunday)
                    {
                        days++;
                        continue;
                    }

                    DataRow newRow = _WorkSet.Tables["RSLTDT"].NewRow();
                    newRow.ItemArray = row.ItemArray;

                    newRow["STR_REQ_DATE"] = reqDateTime.toDateString("yyyyMMdd");
                    newRow["REQ_START_DATE"] = reqDateTime;
                    newRow["REQ_END_DATE"] = reqDateTime;
                    newRow["REQ_TIME"] = 480;

                    _WorkSet.Tables["RSLTDT"].Rows.Add(newRow);
                }

                _WorkSet.Tables["RSLTDT"].Rows.Remove(row);
            }

            int yearidx = focusRow["YEAR"].ToString().IndexOf("월");

            string month = focusRow["YEAR"].ToString().Substring(0, yearidx);

            DateTime startDate = new DateTime(_WorkSet.Tables["RQSTDT"].Rows[0]["YEAR"].toInt(), month.toInt(), 1);
            DateTime first = startDate.AddDays(-(startDate.Day - 1));
            DateTime endDate = first.AddDays(DateTime.DaysInMonth(first.Year, first.Month) - 1);

            //합계 저장 dictionary
            Dictionary<string, decimal> sumDic = new Dictionary<string, decimal>();

            for (DateTime dt = startDate; dt <= endDate; dt = dt.AddDays(1))
            {
                DataRow newRow = gridTable.NewRow();
                newRow["MONTH"] = focusRow["YEAR"];
                newRow["DAY"] = dt.Day.ToString() + "일";

                string day = dt.toDateString("yyyyMMdd");

                DataRow[] reqRwos = _WorkSet.Tables["RSLTDT"].Select("STR_REQ_DATE = '" + day + "'");

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

                            DataSet resultSet2 = BizRun.QBizRun.ExecuteService(this, "WOR01A_SER10", idleSet, "RQSTDT", "RSLTDT");

                            //IDLE_FLAG - 0 : 주간 , 1 : 야간
                            string idleFillter = "IDLE_FLAG = '0'";

                            if (resultSet2.Tables["RSLTDT"].Rows.Count > 0)
                            {
                                if (resultSet2.Tables["RSLTDT"].Rows[0]["EWT_TYPE"].ToString() == "1")
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
                                        //합계 - 누적저장
                                        if (sumDic.ContainsKey("CUM_TIME"))
                                        {
                                            //sumDic["CUM_TIME"] = sumDic["CUM_TIME"] + newRow[row["WORK_CODE"].ToString() + "_" + iSeq.ToString()].toDecimal();
                                            sumDic["CUM_TIME"] = sumDic["CUM_TIME"] + Math.Round((time).toDecimal() / 60, 1).toDecimal();
                                        }
                                        else
                                        {
                                            sumDic.Add("CUM_TIME", newRow[row["WORK_CODE"].ToString() + "_" + iSeq.ToString()].toDecimal());
                                        }
                                    }
                                    else
                                    {
                                        if (sumDic.ContainsKey("NIGHT_TIME"))
                                        {
                                            sumDic["NIGHT_TIME"] = sumDic["NIGHT_TIME"] + newRow[row["WORK_CODE"].ToString() + "_" + iSeq.ToString()].toDecimal();
                                        }
                                        else
                                        {
                                            sumDic.Add("NIGHT_TIME", newRow[row["WORK_CODE"].ToString() + "_" + iSeq.ToString()].toDecimal());
                                        }
                                    }
                                }





                                iSeq++;
                            }

                            break;
                    }
                }

                gridTable.Rows.Add(newRow);
            }

            //합계
            DataRow sumRow = gridTable.NewRow();
            sumRow["DAY"] = "계";

            foreach (DataColumn col in gridTable.Columns)
            {
                if (sumDic.ContainsKey(col.ColumnName))
                {
                    sumRow[col.ColumnName] = sumDic[col.ColumnName];
                }
            }

            gridTable.Rows.Add(sumRow);


            //잔업
            DataRow remainRow = gridTable.NewRow();
            remainRow["MONTH"] = "잔업";

            foreach (DataColumn col in gridTable.Columns)
            {
                if (sumDic.ContainsKey(col.ColumnName)
                    && col.ColumnName.Contains("W08"))
                {
                    remainRow["DAY"] = remainRow["DAY"].toDecimal() + sumDic[col.ColumnName];
                }

                //연장근무 - 야간근무제외
                remainRow["W02"] = "연장근무";
                if (sumDic.ContainsKey("CUM_TIME"))
                {
                    remainRow["W03"] = sumDic["CUM_TIME"];
                }
            }

            gridTable.Rows.Add(remainRow);

            //평일 교대
            DataRow nomalRow = gridTable.NewRow();
            nomalRow["MONTH"] = "평일 교대";

            foreach (DataColumn col in gridTable.Columns)
            {
                if (sumDic.ContainsKey(col.ColumnName)
                    && col.ColumnName.Contains("W09"))
                {
                    nomalRow["DAY"] = nomalRow["DAY"].toDecimal() + sumDic[col.ColumnName];
                }
            }

            //야간근무
            nomalRow["W02"] = "야간근무";
            if (sumDic.ContainsKey("NIGHT_TIME"))
            {
                nomalRow["W03"] = sumDic["NIGHT_TIME"];
            }

            gridTable.Rows.Add(nomalRow);

            //특근
            DataRow specialRow = gridTable.NewRow();
            specialRow["MONTH"] = "특근";

            foreach (DataColumn col in gridTable.Columns)
            {
                if (sumDic.ContainsKey(col.ColumnName)
                    && col.ColumnName.Contains("W10"))
                {
                    specialRow["DAY"] = specialRow["DAY"].toDecimal() + sumDic[col.ColumnName];
                }
            }

            gridTable.Rows.Add(specialRow);

            //휴일 교대
            DataRow holiWorkRow = gridTable.NewRow();
            holiWorkRow["MONTH"] = "휴일교대";

            foreach (DataColumn col in gridTable.Columns)
            {
                if (sumDic.ContainsKey(col.ColumnName)
                    && col.ColumnName.Contains("W11"))
                {
                    holiWorkRow["DAY"] = holiWorkRow["DAY"].toDecimal() + sumDic[col.ColumnName];
                }
            }

            gridTable.Rows.Add(holiWorkRow);

            //지,외,조,무
            DataRow minuteRow = gridTable.NewRow();
            minuteRow["MONTH"] = "지,외,조,무";

            foreach (DataColumn col in gridTable.Columns)
            {
                if (sumDic.ContainsKey(col.ColumnName)
                    && (col.ColumnName.Contains("W01")
                        || col.ColumnName.Contains("W02")
                        || col.ColumnName.Contains("W03")
                        || col.ColumnName.Contains("W04")))
                {
                    minuteRow["DAY"] = minuteRow["DAY"].toDecimal() + sumDic[col.ColumnName];
                }
            }

            gridTable.Rows.Add(minuteRow);

            //연차,반차
            DataRow holiRow = gridTable.NewRow();
            holiRow["MONTH"] = "연차,반차";

            foreach (DataColumn col in gridTable.Columns)
            {
                if (sumDic.ContainsKey(col.ColumnName)
                    && col.ColumnName.Contains("W05_W06"))
                {
                    holiRow["DAY"] = holiRow["DAY"].toDecimal() + sumDic[col.ColumnName];
                }
            }

            gridTable.Rows.Add(holiRow);


            acBandGridView2.GridControl.DataSource = gridTable;
            acBandGridView2.OptionsView.ShowColumnHeaders = true;
            acBandGridView2.BestFitColumns();
            acBandGridView2.OptionsView.ShowColumnHeaders = false;

        }

        void QuickException(object sender, QBiz qBiz, BizManager.BizException ex)
        {
            acMessageBox.Show(this, ex);
        }

        int GetIdleTime(DateTime startDate, DateTime endDate, string idleFilter)
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