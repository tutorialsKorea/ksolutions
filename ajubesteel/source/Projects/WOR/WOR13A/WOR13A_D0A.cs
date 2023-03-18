using BizManager;
using ControlManager;
using DevExpress.XtraLayout;
using System;
using System.Data;
using System.Windows.Forms;

namespace WOR
{
    public sealed partial class WOR13A_D0A : BaseMenuDialog
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

        private object _LinkData = null;
        private acGridView _LinkView = null;

        private DataSet _WorkSet = null;
        private DataSet _HoliSet = null;
        private DataSet _IdleSet = null;

        private string _EmpCode = "";

        public WOR13A_D0A(acGridView linkView, object linkData, string empCode)
        {
            InitializeComponent();

            this._LinkData = linkData;

            this._LinkView = linkView;

            _EmpCode = empCode;
        }

        public override void DialogInit()
        {
            barItemSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barItemSaveClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            DataSet resultSet = BizRun.QBizRun.ExecuteService(this, "STD25A_SER2", acInfo.RefData, "RQSTDT", "RSLTDT");

            (acLayoutControl1.GetEditor("WORK_CODE") as acLookupEdit).SetData("WORK_NAME", "WORK_CODE", resultSet.Tables["RSLTDT"]);

            _WorkSet = BizRun.QBizRun.ExecuteService(this, "WOR01A_SER2", acInfo.RefData, "RQSTDT", "RSLTDT");

            _HoliSet = BizRun.QBizRun.ExecuteService(this, "WOR01A_SER3", acInfo.RefData, "RQSTDT", "RSLTDT");

            _IdleSet = BizRun.QBizRun.ExecuteService(this, "WOR01A_SER6", acInfo.RefData, "RQSTDT", "RSLTDT");

            (acLayoutControl1.GetEditor("REQ_AMPM") as acLookupEdit).SetCode("W005");

            (acLayoutControl1.GetEditor("S_HOUR") as acLookupEdit).SetCode("W006");
            DataTable sDT = (DataTable)(acLayoutControl1.GetEditor("S_HOUR") as acLookupEdit).Properties.DataSource;
            (acLayoutControl1.GetEditor("S_HOUR") as acLookupEdit).Properties.DropDownRows = sDT.Rows.Count;

            (acLayoutControl1.GetEditor("S_MINUTE") as acLookupEdit).SetCode("W007");

            (acLayoutControl1.GetEditor("E_HOUR") as acLookupEdit).SetCode("W006");
            DataTable eDT = (DataTable)(acLayoutControl1.GetEditor("E_HOUR") as acLookupEdit).Properties.DataSource;
            (acLayoutControl1.GetEditor("E_HOUR") as acLookupEdit).Properties.DropDownRows = eDT.Rows.Count;

            (acLayoutControl1.GetEditor("E_MINUTE") as acLookupEdit).SetCode("W007");

            if (_EmpCode != "")
            {
                acLayoutControl1.GetEditor("EMP_CODE").Value = _EmpCode;
                acLayoutControl1.GetEditor("EMP_CODE").isReadyOnly = true;
            }

            //(acLayoutControl1.GetEditor("SCOMMNET_SEL") as acLookupEdit).SetCode("W010"); 
            acLayoutControl1.OnValueChanged += acLayoutControl1_OnValueChanged;

            acLayoutControl1.GetEditor("WORK_CODE").Value = "W13";
            acLayoutControl1.GetEditor("WORK_CODE").isReadyOnly = true;

            SetItemSize(acLayoutControlItem1);
            SetItemSize(acLayoutControlItem2, 20);
            SetItemSize(acLayoutControlItem4, 20);

            SetItemSize(acLayoutControlItem5, 70);
            SetItemSize(acLayoutControlItem6, 70);
            SetItemSize(acLayoutControlItem7, 70);
            SetItemSize(acLayoutControlItem8, 70);
            SetItemSize(acLayoutControlItem9, 70);
            SetItemSize(acLayoutControlItem11, 70);
            SetItemSize(acLayoutControlItem12, 70);

            SetItemSize(acLayoutControlItem13);
            SetItemSize(acLayoutControlItem14);

            SetItemSize(acLayoutControlItem17, 40);
            SetItemSize(acLayoutControlItem18, 40);

            SetItemSize(acLayoutControlItem19); 

            acTextEdit1.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            acTextEdit1.Properties.Mask.EditMask = "N0";
            acTextEdit1.Properties.Mask.UseMaskAsDisplayFormat = true;
            acTextEdit1.Properties.EditFormat.FormatString = "N0";
            acTextEdit1.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;


            acTextEdit2.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            acTextEdit2.Properties.Mask.EditMask = "N0";
            acTextEdit2.Properties.Mask.UseMaskAsDisplayFormat = true;
            acTextEdit2.Properties.EditFormat.FormatString = "N0";
            acTextEdit2.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;

            base.DialogInit();
        }

        private void acLayoutControl1_OnValueChanged(object sender, IBaseEditControl info, object newValue)
        {
            acLayoutControl layout = sender as acLayoutControl;

            switch (info.ColumnName)
            {
                case "WORK_CODE":

                    if (_WorkSet == null) return;

                    if (newValue == null)
                    {
                        SetValidControl(layout, true, true, true, true, true, true, true, true, false, false, false, false);
                        (layout.GetEditor("SCOMMNET_SEL") as acLookupEdit).Clear();
                        (layout.GetEditor("SCOMMENT") as acMemoEdit).Clear();
                        return;
                    }

                    DataRow[] workRows = _WorkSet.Tables["RSLTDT"].Select("WORK_CODE = '" + newValue.ToString() + "'");

                    if (workRows.Length == 1)
                    {
                        switch (workRows[0]["INPUT_TYPE"].ToString())
                        {
                            case "A":

                                SetValidControl(layout, true, false, false, true, false, false, false, true, false, false, false, false);

                                break;

                            case "B":

                                SetValidControl(layout, true, true, true, true, true, true, false, true, false, false, false, false);

                                break;

                            case "C":

                                SetValidControl(layout, true, false, false, false, false, false, true, false, false, false, false, false);

                                break;

                            case "D":

                                SetValidControl(layout, true, true, true, true, true, true, false, true, false, false, false, false);

                                break;

                            case "E":

                                SetValidControl(layout, true, true, true, true, true, true, false, true, false, false, false, false);

                                break;

                            case "F":

                                SetValidControl(layout, true, true, false, true, true, false, false, true, true, true, false, false, "8");

                                break;

                            case "G":

                                SetValidControl(layout, true, false, false, true, false, false, false, true, false, false, true, true);

                                break;
                        }
                    }

                    DataSet ds = acInfo.RefData.Clone();
                    ds.Tables["RQSTDT"].Columns.Add("WORK_CODE", typeof(string));

                    DataRow newRow = ds.Tables["RQSTDT"].NewRow();
                    newRow["PLT_CODE"] = acInfo.PLT_CODE;
                    newRow["WORK_CODE"] = newValue;
                    ds.Tables["RQSTDT"].Rows.Add(newRow);

                    DataSet resultSet = BizRun.QBizRun.ExecuteService(this, "WOR01A_SER5", ds, "RQSTDT", "RSLTDT");

                    (acLayoutControl1.GetEditor("SCOMMNET_SEL") as acLookupEdit).SetData("CAUSE_NAME", "CAUSE_CODE", resultSet.Tables["RSLTDT"]);
                    layout.GetEditor("REQ_SCOMMENT").Value = null;

                    layout.GetEditor("SCOMMENT").Value = workRows[0]["SCOMMENT"];

                    break;

                case "S_MIN_TEXT":

                    if (newValue == null) return;

                    if (newValue.toInt() < 0)
                    {
                        layout.GetEditor("S_MIN_TEXT").Value = "0";
                    }
                    else if (newValue.toInt() > 59)
                    {
                        layout.GetEditor("S_MIN_TEXT").Value = "59";
                    }

                    DataRow[] wRows1 = _WorkSet.Tables["RSLTDT"].Select("WORK_CODE = '" + layout.GetEditor("WORK_CODE").Value.ToString() + "'");

                    if (wRows1.Length == 1)
                    {
                        if (layout.GetEditor("S_HOUR").Value == null
                            || layout.GetEditor("E_HOUR").Value == null) return;

                        if (layout.GetEditor("S_HOUR").Value.ToString() != layout.GetEditor("E_HOUR").Value.ToString())
                        {
                            if (TimeValidCheck(layout, wRows1[0]["INPUT_TYPE"].ToString()) == false)
                            {
                                acAlert.Show(this, "시작시간보다 작을 수 없습니다.", acAlertForm.enmType.Info);
                                layout.GetEditor(info.ColumnName).Value = null;
                            }
                            else
                            {
                                layout.GetEditor("REQ_MINUTE").Value = SetReqMinute();
                            }
                        }
                        else
                        {
                            if (layout.GetEditor("E_MIN_TEXT").Value.toInt() < newValue.toInt())
                            {
                                layout.GetEditor("S_MIN_TEXT").Value = layout.GetEditor("E_MIN_TEXT").Value;
                            }
                            else
                            {
                                layout.GetEditor("REQ_MINUTE").Value = SetReqMinute();
                            }
                        }

                    }

                    break;

                case "E_MIN_TEXT":

                    if (newValue == null) return;

                    if (newValue.toInt() < 0)
                    {
                        layout.GetEditor("E_MIN_TEXT").Value = "0";
                    }
                    else if (newValue.toInt() > 59)
                    {
                        layout.GetEditor("E_MIN_TEXT").Value = "59";
                    }

                    DataRow[] wRows2 = _WorkSet.Tables["RSLTDT"].Select("WORK_CODE = '" + layout.GetEditor("WORK_CODE").Value.ToString() + "'");

                    if (wRows2.Length == 1)
                    {
                        if (layout.GetEditor("S_HOUR").Value == null
                            || layout.GetEditor("E_HOUR").Value == null) return;

                        if (layout.GetEditor("S_HOUR").Value.ToString() != layout.GetEditor("E_HOUR").Value.ToString())
                        {
                            if (TimeValidCheck(layout, wRows2[0]["INPUT_TYPE"].ToString()) == false)
                            {
                                acAlert.Show(this, "시작시간보다 작을 수 없습니다.", acAlertForm.enmType.Info);
                                layout.GetEditor(info.ColumnName).Value = null;
                            }
                            else
                            {
                                layout.GetEditor("REQ_MINUTE").Value = SetReqMinute();
                            }
                        }
                        else
                        {
                            if (layout.GetEditor("S_MIN_TEXT").Value.toInt() > newValue.toInt())
                            {
                                layout.GetEditor("E_MIN_TEXT").Value = layout.GetEditor("S_MIN_TEXT").Value;
                            }
                            else
                            {
                                layout.GetEditor("REQ_MINUTE").Value = SetReqMinute();
                            }
                        }
                    }

                    break;

                case "SCOMMNET_SEL":

                    DataRow row = (layout.GetEditor("SCOMMNET_SEL") as acLookupEdit).GetSelectedRow("CAUSE_CODE");

                    layout.GetEditor("REQ_SCOMMENT").Value = row["SCOMMENT"];

                    break;

                case "REQ_SCOMMENT":

                    break;

                case "S_REQ_DATE":

                    if (newValue == null) return;

                    if (DayVaildCheck(layout, newValue, "E_REQ_DATE") == false)
                    {
                        acAlert.Show(this, "시작시간보다 작을 수 없습니다.", acAlertForm.enmType.Info);
                        layout.GetEditor("S_REQ_DATE").Value = layout.GetEditor("E_REQ_DATE").Value;
                    }
                    else
                    {
                        SetTime(layout, newValue, "S_REQ_DATE");
                    }

                    break;

                case "E_REQ_DATE":

                    if (newValue == null) return;

                    if (DayVaildCheck(layout, newValue, "S_REQ_DATE") == false)
                    {
                        acAlert.Show(this, "시작시간보다 작을 수 없습니다.", acAlertForm.enmType.Info);
                        layout.GetEditor("E_REQ_DATE").Value = layout.GetEditor("S_REQ_DATE").Value;
                    }
                    else
                    {
                        SetTime(layout, newValue, "E_REQ_DATE");
                    }

                    break;

                case "CC_EMP":
                    break;

                case "S_HOUR":
                case "S_MINUTE":
                case "E_HOUR":
                case "E_MINUTE":

                    if (newValue == null) return;

                    DataRow[] wRows = _WorkSet.Tables["RSLTDT"].Select("WORK_CODE = '" + layout.GetEditor("WORK_CODE").Value.ToString() + "'");

                    if (wRows.Length == 1)
                    {
                        if (TimeValidCheck(layout, wRows[0]["INPUT_TYPE"].ToString()) == false)
                        {
                            acAlert.Show(this, "시작시간보다 작을 수 없습니다.", acAlertForm.enmType.Info);
                            layout.GetEditor(info.ColumnName).Value = null;
                        }
                        else
                        {
                            layout.GetEditor("REQ_MINUTE").Value = SetReqMinute();
                        }
                    }

                    break;

                default:

                    if (newValue == null) return;

                    layout.GetEditor("REQ_MINUTE").Value = SetReqMinute();

                    break;
            }
        }

        public override void DialogNew()
        {
            barItemSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

            DateTime nowDate = acDateEdit.GetNowDateFromServer();

            (acLayoutControl1.GetEditor("S_REQ_DATE") as acDateEdit).Value = nowDate;
            (acLayoutControl1.GetEditor("E_REQ_DATE") as acDateEdit).Value = nowDate;

            base.DialogNew();
        }

        public override void DialogOpen()
        {
            DataRow linkRow = this._LinkData as DataRow;

            acLayoutControl1.DataBind(linkRow, true);

            //(acLayoutControl1.GetEditor("S_HOUR") as acLookupEdit).Value = linkRow["REQ_START_DATE"].toDateTime().Hour;
            //(acLayoutControl1.GetEditor("S_MINUTE") as acLookupEdit).Value = linkRow["REQ_START_DATE"].toDateTime().Minute;

            //(acLayoutControl1.GetEditor("E_HOUR") as acLookupEdit).Value = linkRow["REQ_END_DATE"].toDateTime().Hour;
            //(acLayoutControl1.GetEditor("E_MINUTE") as acLookupEdit).Value = linkRow["REQ_END_DATE"].toDateTime().Minute;

            DataRow[] workRows = _WorkSet.Tables["RSLTDT"].Select("WORK_CODE = '" + linkRow["WORK_CODE"].ToString() + "'");

            if (workRows.Length == 1)
            {
                switch (workRows[0]["INPUT_TYPE"].ToString())
                {
                    case "A":
                    case "G":
                        acLayoutControl1.GetEditor("S_REQ_DATE").Value = linkRow["REQ_START_DATE"].toDateTime();
                        acLayoutControl1.GetEditor("E_REQ_DATE").Value = linkRow["REQ_END_DATE"].toDateTime();

                        break;

                    case "B":
                        acLayoutControl1.GetEditor("S_REQ_DATE").Value = linkRow["REQ_START_DATE"].toDateTime();
                        (acLayoutControl1.GetEditor("S_HOUR") as acLookupEdit).Value = linkRow["REQ_START_DATE"].toDateTime().Hour;
                        (acLayoutControl1.GetEditor("S_MINUTE") as acLookupEdit).Value = linkRow["REQ_START_DATE"].toDateTime().Minute;

                        acLayoutControl1.GetEditor("E_REQ_DATE").Value = linkRow["REQ_END_DATE"].toDateTime();
                        (acLayoutControl1.GetEditor("E_HOUR") as acLookupEdit).Value = linkRow["REQ_END_DATE"].toDateTime().Hour;
                        (acLayoutControl1.GetEditor("E_MINUTE") as acLookupEdit).Value = linkRow["REQ_END_DATE"].toDateTime().Minute;
                        
                        break;

                    case "C":

                        acLayoutControl1.GetEditor("S_REQ_DATE").Value = linkRow["REQ_START_DATE"].toDateTime();

                        break;

                    case "D":

                        acLayoutControl1.GetEditor("S_REQ_DATE").Value = linkRow["REQ_START_DATE"].toDateTime();
                        (acLayoutControl1.GetEditor("S_HOUR") as acLookupEdit).Value = linkRow["REQ_START_DATE"].toDateTime().Hour;
                        (acLayoutControl1.GetEditor("S_MINUTE") as acLookupEdit).Value = linkRow["REQ_START_DATE"].toDateTime().Minute;

                        (acLayoutControl1.GetEditor("E_HOUR") as acLookupEdit).Value = linkRow["REQ_END_DATE"].toDateTime().Hour;
                        (acLayoutControl1.GetEditor("E_MINUTE") as acLookupEdit).Value = linkRow["REQ_END_DATE"].toDateTime().Minute;

                        break;

                    case "E":

                        acLayoutControl1.GetEditor("S_REQ_DATE").Value = linkRow["REQ_START_DATE"].toDateTime();
                        (acLayoutControl1.GetEditor("S_HOUR") as acLookupEdit).Value = linkRow["REQ_START_DATE"].toDateTime().Hour;
                        (acLayoutControl1.GetEditor("S_MINUTE") as acLookupEdit).Value = linkRow["REQ_START_DATE"].toDateTime().Minute;

                        acLayoutControl1.GetEditor("E_REQ_DATE").Value = linkRow["REQ_END_DATE"].toDateTime();
                        (acLayoutControl1.GetEditor("E_HOUR") as acLookupEdit).Value = linkRow["REQ_END_DATE"].toDateTime().Hour;
                        (acLayoutControl1.GetEditor("E_MINUTE") as acLookupEdit).Value = linkRow["REQ_END_DATE"].toDateTime().Minute;

                        break;

                    case "F":

                        acLayoutControl1.GetEditor("S_REQ_DATE").Value = linkRow["REQ_START_DATE"].toDateTime();
                        (acLayoutControl1.GetEditor("S_HOUR") as acLookupEdit).Value = linkRow["REQ_START_DATE"].toDateTime().Hour;
                        acLayoutControl1.GetEditor("S_MIN_TEXT").Value = linkRow["REQ_START_DATE"].toDateTime().Minute;

                        //acLayoutControl1.GetEditor("E_REQ_DATE").Value = linkRow["REQ_END_DATE"].toDateTime();
                        (acLayoutControl1.GetEditor("E_HOUR") as acLookupEdit).Value = linkRow["REQ_END_DATE"].toDateTime().Hour;
                        acLayoutControl1.GetEditor("E_MIN_TEXT").Value = linkRow["REQ_END_DATE"].toDateTime().Minute;

                        break;
                }
            }

            barItemSaveClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

            base.DialogOpen();
        }

        private void barItemSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //저장
            try
            {
                if (acLayoutControl1.ValidCheck() == false) return;

                DataRow layoutRow = acLayoutControl1.CreateParameterRow();

                DataRow linkRow = this._LinkData as DataRow;

                DataTable paramTable = new DataTable("RQSTDT");

                paramTable.Columns.Add("PLT_CODE", typeof(string));
                paramTable.Columns.Add("WORK_ID", typeof(string));
                paramTable.Columns.Add("WORK_CODE", typeof(string));
                paramTable.Columns.Add("EMP_CODE", typeof(string));
                paramTable.Columns.Add("REQ_STATUS", typeof(string));
                paramTable.Columns.Add("REQ_DATE", typeof(DateTime));
                paramTable.Columns.Add("REQ_START_DATE", typeof(DateTime));
                paramTable.Columns.Add("REQ_END_DATE", typeof(DateTime));
                paramTable.Columns.Add("REQ_TIME", typeof(decimal));
                paramTable.Columns.Add("REQ_AMPM", typeof(string));
                paramTable.Columns.Add("CC_EMP", typeof(string));
                paramTable.Columns.Add("REQ_SCOMMENT", typeof(string));
                paramTable.Columns.Add("APP_SCOMMENT", typeof(string));
                paramTable.Columns.Add("IS_DIR_IN", typeof(string));
                paramTable.Columns.Add("IS_DIR_OUT", typeof(string));
                paramTable.Columns.Add("APP_TYPE", typeof(string));
                paramTable.Columns.Add("OVERWRITE", typeof(string));

                DataRow paramRow = paramTable.NewRow();

                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["WORK_ID"] = null;
                paramRow["WORK_CODE"] = layoutRow["WORK_CODE"];
                paramRow["EMP_CODE"] = layoutRow["EMP_CODE"];
                paramRow["REQ_STATUS"] = "0";
                paramRow["REQ_DATE"] = acDateEdit.GetNowDateFromServer();

                int sYear = layoutRow["S_REQ_DATE"].toDateTime().Year;
                int sMonth = layoutRow["S_REQ_DATE"].toDateTime().Month;
                int sDay = layoutRow["S_REQ_DATE"].toDateTime().Day;
                int sHour = layoutRow["S_HOUR"].ToString() == "" ? 8 : layoutRow["S_HOUR"].toInt();
                //int sMinute = layoutRow["S_MINUTE"].ToString() == "" ? 0 : layoutRow["S_MINUTE"].toInt();

                int sMinute = 0;

                if (layoutRow["S_MINUTE"].ToString() != "")
                {
                    sMinute = layoutRow["S_MINUTE"].toInt();
                }
                else if (layoutRow["S_MIN_TEXT"].ToString() != "")
                {
                    sMinute = layoutRow["S_MIN_TEXT"].toInt();
                }

                int eYear = layoutRow["E_REQ_DATE"].ToString() == "" ? sYear : layoutRow["E_REQ_DATE"].toDateTime().Year;
                int eMonth = layoutRow["E_REQ_DATE"].ToString() == "" ? sMonth : layoutRow["E_REQ_DATE"].toDateTime().Month;
                int eDay = layoutRow["E_REQ_DATE"].ToString() == "" ? sDay : layoutRow["E_REQ_DATE"].toDateTime().Day;
                int eHour = layoutRow["E_HOUR"].ToString() == "" ? 8 : layoutRow["E_HOUR"].toInt();
                //int eMinute = layoutRow["E_MINUTE"].ToString() == "" ? 0 : layoutRow["E_MINUTE"].toInt();

                int eMinute = 0;

                if (layoutRow["E_MINUTE"].ToString() != "")
                {
                    eMinute = layoutRow["E_MINUTE"].toInt();
                }
                else if (layoutRow["E_MIN_TEXT"].ToString() != "")
                {
                    eMinute = layoutRow["E_MIN_TEXT"].toInt();
                }

                DateTime startDate = new DateTime(sYear, sMonth, sDay, sHour, sMinute, 0);

                DateTime endDate = new DateTime(eYear, eMonth, eDay, eHour, eMinute, 0);


                //잔업 종료시간이 현재 시간과 30분이상 차이나면 진행 여부 묻는 메시지 표시
                DateTime nowTime = DateTime.Now;
                if (string.Compare(layoutRow["WORK_CODE"].toStringEmpty(), "W08", true) == 0
                && Math.Abs((endDate - nowTime).TotalMinutes) > 30
                && acMessageBox.Show(this, "잔업완료 시간이 현재 시간과의 차이가 30분 이상 차이가 납니다. 계속하시겠습니까?", string.Empty, false, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
                {
                    return;
                }
                //DateTime endDate = startDate;

                ////END시간이 작을경우 다음날로 변경
                //if (eYear != 0)
                //{
                //    endDate = new DateTime(eYear, sMonth, eDay, eHour, eMinute, 0);

                //    if (sHour > eHour)
                //    {
                //        endDate = endDate.AddDays(1);
                //    }
                //}

                paramRow["REQ_START_DATE"] = startDate;
                paramRow["REQ_END_DATE"] = endDate;

                int idleTime = 0;

                foreach (DataRow row in _IdleSet.Tables["RSLTDT"].Rows)
                {
                    string sIdleHour = row["IDLE_START_TIME"].ToString().Substring(0, 2);
                    string sIdleMinute = row["IDLE_START_TIME"].ToString().Substring(2, 2);

                    string eIdleHour = row["IDLE_END_TIME"].ToString().Substring(0, 2);
                    string eIdleMinute = row["IDLE_END_TIME"].ToString().Substring(2, 2);

                    DateTime idleStartTime = new DateTime(startDate.Year, startDate.Month, startDate.Day, sIdleHour.toInt(), sIdleMinute.toInt(), 0);
                    DateTime idleEndTime = new DateTime(startDate.Year, startDate.Month, startDate.Day, eIdleHour.toInt(), eIdleMinute.toInt(), 0);

                    if (sIdleHour == "00"
                        && startDate.Day != endDate.Day)
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

                ////시작시간과 종료시간이 같으면 종료시간에 하루 추가해서 시간(분)계산
                //if (startDate == endDate)
                //{
                //    endDate = endDate.AddDays(1);
                //}

                TimeSpan ts = endDate.Subtract(startDate);

                //근태유형별 입력에 따라 시간계산
                DataRow[] workRows = _WorkSet.Tables["RSLTDT"].Select("WORK_CODE = '" + layoutRow["WORK_CODE"].ToString() + "'");

                if (workRows.Length == 1)
                {
                    //휴일체크
                    int iHoliday = 0;
                    for (DateTime sDate = startDate; sDate.toDateString("yyyyMMdd").toInt() <= endDate.toDateString("yyyyMMdd").toInt(); sDate = sDate.AddDays(1))
                    {
                        DataRow[] rows = _HoliSet.Tables["RSLTDT"].Select("HOLI_DATE = '" + sDate.toDateString("yyyyMMdd") + "'");

                        if (rows.Length > 0 
                            || sDate.DayOfWeek == DayOfWeek.Saturday
                            || sDate.DayOfWeek == DayOfWeek.Sunday)
                        {
                            iHoliday++;
                        }
                    }

                    if (ts.TotalDays.toInt() + 1 <= iHoliday)
                    {
                        if (workRows[0]["IS_HOLI"].ToString() == "0")
                        {
                            acMessageBox.Show(this, "휴일에 신청 할 수 없습니다.", "", false, acMessageBox.emMessageBoxType.CONFIRM);
                            return;
                        }
                    }
                    
                    if (ts.TotalDays.toInt() + 1 > iHoliday)
                    {
                        if (workRows[0]["IS_HOLI"].ToString() == "1")
                        {
                            acMessageBox.Show(this, "휴일만 신청 할 수 있습니다.", "", false, acMessageBox.emMessageBoxType.CONFIRM);
                            return;
                        }
                    }

                    //시간(분) 계산
                    switch (workRows[0]["INPUT_TYPE"].ToString())
                    {
                        case "A":
                            /*
                             연차
                            */

                            //하루 8시간 = 480분으로 계산
                            paramRow["REQ_TIME"] = (ts.TotalDays.toInt() + 1 - iHoliday) * 480;

                            break;

                        case "B":
                            /*
                             잔업, 교대, 특근, 휴일교대
                            */

                            //분계산
                            paramRow["REQ_TIME"] = ts.TotalMinutes.toInt() - idleTime;

                            break;

                        case "C":
                            /*
                             반차
                            */

                            //근태유형 기준정보에서 IS_HALF가 설정된경우 하루에서 반 나눠준다 반차와 같은 하루 절반인 경우
                            if (workRows[0]["IS_HALF"].ToString() == "1")
                            {
                                paramRow["REQ_TIME"] = ((ts.TotalDays.toInt() + 1) * 480) / 2;
                            }

                            break;

                        case "D":
                            /*
                             외출, 조퇴, 무급
                            */

                            //분계산
                            paramRow["REQ_TIME"] = ts.TotalMinutes.toInt() - idleTime;

                            break;

                        case "E":
                            /*
                             연차/반차(육아)?
                            */

                            //분계산
                            paramRow["REQ_TIME"] = ts.TotalMinutes.toInt() - idleTime;

                            break;

                        case "F":
                            /*
                             지각
                            */

                            //분계산
                            paramRow["REQ_TIME"] = ts.TotalMinutes.toInt() - idleTime;

                            break;
                    }
                }


                paramRow["REQ_AMPM"] = layoutRow["REQ_AMPM"];
                paramRow["CC_EMP"] = layoutRow["CC_EMP"];
                paramRow["REQ_SCOMMENT"] = layoutRow["REQ_SCOMMENT"];
                paramRow["APP_SCOMMENT"] = null;

                paramRow["IS_DIR_IN"] = layoutRow["IS_DIR_IN"];
                paramRow["IS_DIR_OUT"] = layoutRow["IS_DIR_OUT"];

                string appType = "ATD";
                if (workRows.Length == 1)
                {
                    if (workRows[0]["IS_OUT"].ToString() == "1")
                    {
                        appType = "OUT";
                    }
                }

                paramRow["APP_TYPE"] = appType;

                paramRow["OVERWRITE"] = "0";
                paramTable.Rows.Add(paramRow);

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                if (dsEmp != null)
                {
                    DataTable paramTable2 = dsEmp.Tables["RQSTDT2"].Copy();
                    paramSet.Tables.Add(paramTable2);
                }

                BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.SAVE,
                "WOR08A_INS", paramSet, "RQSTDT", "RSLTDT",
                QuickSave,
                QuickException);

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
                DataTable addGridTable = e.result.Tables["RSLTDT"].Clone();

                DataTable gridTable = _LinkView.GridControl.DataSource as DataTable;

                foreach (DataRow row in e.result.Tables["RSLTDT"].Rows)
                {
                    foreach (DataRow rw in gridTable.Rows)
                    {
                        if (row["WORK_ID"].ToString() == rw["WORK_ID"].ToString())
                        {
                            _LinkView.DeleteMappingRow(rw);
                        }
                    }

                    TimeSpan ts = row["REQ_END_DATE"].toDateTime().Subtract(row["REQ_START_DATE"].toDateTime());

                    DataRow newRow = addGridTable.NewRow();
                    newRow.ItemArray = row.ItemArray;
                    addGridTable.Rows.Add(newRow);

                    for (int i = 0; i < ts.TotalDays; i++)
                    {
                        DataRow newAddRow = addGridTable.NewRow();
                        newAddRow.ItemArray = row.ItemArray;
                        newAddRow["STR_REQ_DATE"] = row["STR_REQ_DATE"].toDateTime().AddDays(i + 1).toDateString("yyyyMMdd");
                        addGridTable.Rows.Add(newAddRow);
                    }
                }

                DataTable tmpTable = addGridTable.Clone();
                tmpTable.Columns["STR_REQ_DATE"].DataType = typeof(DateTime);

                foreach (DataRow addRow in addGridTable.Rows)
                {
                    DataRow newRow = tmpTable.NewRow();
                    foreach (DataColumn col in addGridTable.Columns)
                    {
                        if (col.ColumnName == "STR_REQ_DATE")
                        {
                            newRow[col.ColumnName] = addRow[col.ColumnName].toDateTime();
                        }
                        else
                        {
                            newRow[col.ColumnName] = addRow[col.ColumnName];
                        }
                    }

                    tmpTable.Rows.Add(newRow);
                }

                foreach (DataRow tmpRow in tmpTable.Rows)
                {
                    gridTable.ImportRow(tmpRow);
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }


        private void barItemSaveClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //저장 후 닫기
            try
            {
                if (acLayoutControl1.ValidCheck() == false) return;

                DataRow layoutRow = acLayoutControl1.CreateParameterRow();

                DataRow linkRow = this._LinkData as DataRow;

                DataTable paramTable = new DataTable("RQSTDT");

                paramTable.Columns.Add("PLT_CODE", typeof(string));
                paramTable.Columns.Add("WORK_ID", typeof(string));
                paramTable.Columns.Add("WORK_CODE", typeof(string));
                paramTable.Columns.Add("EMP_CODE", typeof(string));
                paramTable.Columns.Add("REQ_STATUS", typeof(string));
                paramTable.Columns.Add("REQ_DATE", typeof(DateTime));
                paramTable.Columns.Add("REQ_START_DATE", typeof(DateTime));
                paramTable.Columns.Add("REQ_END_DATE", typeof(DateTime));
                paramTable.Columns.Add("REQ_TIME", typeof(decimal));
                paramTable.Columns.Add("REQ_AMPM", typeof(string));
                paramTable.Columns.Add("CC_EMP", typeof(string));
                paramTable.Columns.Add("REQ_SCOMMENT", typeof(string));
                paramTable.Columns.Add("APP_SCOMMENT", typeof(string));
                paramTable.Columns.Add("IS_DIR_IN", typeof(string));
                paramTable.Columns.Add("IS_DIR_OUT", typeof(string));
                paramTable.Columns.Add("APP_TYPE", typeof(string));
                paramTable.Columns.Add("OVERWRITE", typeof(string));

                DataRow paramRow = paramTable.NewRow();

                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["WORK_ID"] = linkRow["WORK_ID"];
                paramRow["WORK_CODE"] = layoutRow["WORK_CODE"];
                paramRow["EMP_CODE"] = layoutRow["EMP_CODE"];
                paramRow["REQ_STATUS"] = linkRow["REQ_STATUS"];
                paramRow["REQ_DATE"] = linkRow["REQ_DATE"];

                int sYear = layoutRow["S_REQ_DATE"].toDateTime().Year;
                int sMonth = layoutRow["S_REQ_DATE"].toDateTime().Month;
                int sDay = layoutRow["S_REQ_DATE"].toDateTime().Day;
                int sHour = layoutRow["S_HOUR"].ToString() == "" ? 8 : layoutRow["S_HOUR"].toInt();
                //int sMinute = layoutRow["S_MINUTE"].ToString() == "" ? 0 : layoutRow["S_MINUTE"].toInt();
                int sMinute = 0;

                if (layoutRow["S_MINUTE"].ToString() != "")
                {
                    sMinute = layoutRow["S_MINUTE"].toInt();
                }
                else if (layoutRow["S_MIN_TEXT"].ToString() != "")
                {
                    sMinute = layoutRow["S_MIN_TEXT"].toInt();
                }


                

                int eYear = layoutRow["E_REQ_DATE"].ToString() == "" ? sYear : layoutRow["E_REQ_DATE"].toDateTime().Year;
                int eMonth = layoutRow["E_REQ_DATE"].ToString() == "" ? sMonth : layoutRow["E_REQ_DATE"].toDateTime().Month;
                int eDay = layoutRow["E_REQ_DATE"].ToString() == "" ? sDay : layoutRow["E_REQ_DATE"].toDateTime().Day;
                int eHour = layoutRow["E_HOUR"].ToString() == "" ? 8 : layoutRow["E_HOUR"].toInt();
                //int eMinute = layoutRow["E_MINUTE"].ToString() == "" ? 0 : layoutRow["E_MINUTE"].toInt();

                int eMinute = 0;

                if (layoutRow["E_MINUTE"].ToString() != "")
                {
                    eMinute = layoutRow["E_MINUTE"].toInt();
                }
                else if (layoutRow["E_MIN_TEXT"].ToString() != "")
                {
                    eMinute = layoutRow["E_MIN_TEXT"].toInt();
                }

                DateTime startDate = new DateTime(sYear, sMonth, sDay, sHour, sMinute, 0);

                DateTime endDate = new DateTime(eYear, eMonth, eDay, eHour, eMinute, 0);

                //DateTime endDate = startDate;

                ////END시간이 작을경우 다음날로 변경
                //if (eYear != 0)
                //{
                //    endDate = new DateTime(eYear, sMonth, eDay, eHour, eMinute, 0);

                //    if (sHour > eHour)
                //    {
                //        endDate = endDate.AddDays(1);
                //    }
                //}

                paramRow["REQ_START_DATE"] = startDate;
                paramRow["REQ_END_DATE"] = endDate;

                ////시작시간과 종료시간이 같으면 종료시간에 하루 추가해서 시간(분)계산
                //if (startDate == endDate)
                //{
                //    endDate = endDate.AddDays(1);
                //}

                TimeSpan ts = endDate.Subtract(startDate);

                //근태유형별 입력에 따라 시간계산
                DataRow[] workRows = _WorkSet.Tables["RSLTDT"].Select("WORK_CODE = '" + layoutRow["WORK_CODE"].ToString() + "'");

                if (workRows.Length == 1)
                {
                    //휴일체크
                    int iHoliday = 0;
                    for (DateTime sDate = startDate; sDate.toDateString("yyyyMMdd").toInt() <= endDate.toDateString("yyyyMMdd").toInt(); sDate = sDate.AddDays(1))
                    {
                        DataRow[] rows = _HoliSet.Tables["RSLTDT"].Select("HOLI_DATE = '" + sDate.toDateString("yyyyMMdd") + "'");

                        if (rows.Length > 0
                            || sDate.DayOfWeek == DayOfWeek.Saturday
                            || sDate.DayOfWeek == DayOfWeek.Sunday)
                        {
                            iHoliday++;
                        }
                    }

                    if (ts.TotalDays.toInt() + 1 <= iHoliday)
                    {
                        if (workRows[0]["IS_HOLI"].ToString() == "0")
                        {
                            acMessageBox.Show(this, "휴일에 신청 할 수 없습니다.", "", false, acMessageBox.emMessageBoxType.CONFIRM);
                            return;
                        }
                    }

                    if (ts.TotalDays.toInt() + 1 > iHoliday)
                    {
                        if (workRows[0]["IS_HOLI"].ToString() == "1")
                        {
                            acMessageBox.Show(this, "휴일만 신청 할 수 있습니다.", "", false, acMessageBox.emMessageBoxType.CONFIRM);
                            return;
                        }
                    }

                    switch (workRows[0]["INPUT_TYPE"].ToString())
                    {
                        case "A":
                            /*
                             연차
                            */

                            //하루 8시간 = 480분으로 계산
                            paramRow["REQ_TIME"] = (ts.TotalDays.toInt() + 1 - iHoliday) * 480;

                            break;

                        case "B":

                            /*
                             잔업, 교대, 특근, 휴일교대
                            */

                            //분계산
                            paramRow["REQ_TIME"] = ts.TotalMinutes.toInt();

                            break;

                        case "C":
                            /*
                             반차
                            */

                            //근태유형 기준정보에서 IS_HALF가 설정된경우 하루에서 반 나눠준다 반차와 같은 하루 절반인 경우
                            if (workRows[0]["IS_HALF"].ToString() == "1")
                            {
                                paramRow["REQ_TIME"] = ((ts.TotalDays.toInt() + 1) * 480) / 2;
                            }

                            break;

                        case "D":
                            /*
                             외출, 조퇴, 무급
                            */

                            //분계산
                            paramRow["REQ_TIME"] = ts.TotalMinutes.toInt();

                            break;

                        case "E":
                            /*
                             연차/반차(육아)?
                            */

                            //분계산
                            paramRow["REQ_TIME"] = ts.TotalMinutes.toInt();

                            break;

                        case "F":
                            /*
                             지각
                            */

                            //분계산
                            paramRow["REQ_TIME"] = ts.TotalMinutes.toInt();

                            break;
                    }
                }

                paramRow["REQ_AMPM"] = layoutRow["REQ_AMPM"];
                paramRow["CC_EMP"] = layoutRow["CC_EMP"];
                paramRow["REQ_SCOMMENT"] = layoutRow["REQ_SCOMMENT"];
                paramRow["APP_SCOMMENT"] = linkRow["APP_SCOMMENT"];

                paramRow["IS_DIR_IN"] = layoutRow["IS_DIR_IN"];
                paramRow["IS_DIR_OUT"] = layoutRow["IS_DIR_OUT"];

                string appType = "ATD";
                if (workRows.Length == 1)
                {
                    if (workRows[0]["IS_OUT"].ToString() == "1")
                    {
                        appType = "OUT";
                    }
                }

                paramRow["APP_TYPE"] = appType;

                paramRow["OVERWRITE"] = "1";
                paramTable.Rows.Add(paramRow);

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                if (dsEmp != null)
                {
                    DataTable paramTable2 = dsEmp.Tables["RQSTDT2"].Copy();
                    paramSet.Tables.Add(paramTable2);
                }

                BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.SAVE,
                "WOR08A_INS", paramSet, "RQSTDT", "RSLTDT",
                QuickSaveClose,
                QuickException);

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void QuickSaveClose(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                //foreach (DataRow row in e.result.Tables["RSLTDT"].Rows)
                //{
                //    DataTable gridTable = _LinkView.GridControl.DataSource as DataTable;

                //    foreach (DataRow rw in gridTable.Rows)
                //    {
                //        if (row["WORK_ID"].ToString() == rw["WORK_ID"].ToString())
                //        {
                //            _LinkView.DeleteMappingRow(rw);
                //        }
                //    }

                //    TimeSpan ts = row["REQ_END_DATE"].toDateTime().Subtract(row["REQ_START_DATE"].toDateTime());

                //    DataRow newRow = gridTable.NewRow();

                //    newRow.ItemArray = row.ItemArray;
                    
                //    gridTable.Rows.Add(newRow);

                //    for (int i = 0; i < ts.TotalDays; i++)
                //    {
                //        DataRow newAddRow = gridTable.NewRow();
                //        newAddRow.ItemArray = row.ItemArray;
                //        newAddRow["STR_REQ_DATE"] = row["STR_REQ_DATE"].toDateTime().AddDays(i + 1).toDateString("yyyyMMdd");
                //        gridTable.Rows.Add(newAddRow);
                //    }
                //}

                this.Close();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }



        void QuickException(object sender, QBiz qBiz, BizManager.BizException ex)
        {
            if (ex.ErrNumber == BizManager.BizException.OVERWRITE)
            {
                if (acMessageBox.Show(acInfo.BizError.GetDesc(ex.ErrNumber), this.Caption, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
                {
                    return;
                }

                foreach (DataRow row in qBiz.RefData.Tables["RQSTDT"].Rows)
                {
                    row["OVERWRITE"] = "1";
                }

                qBiz.Start();

            }
            else if (ex.ErrNumber == BizManager.BizException.OVERWRITE_HISTORY)
            {
                acMessageBoxGridYesNo frm = new acMessageBoxGridYesNo(this, "acMessageBoxGridYesNo1", acInfo.BizError.GetDesc(ex.ErrNumber), string.Empty, false, this.Caption, ex.ParameterData);

                frm.View.GridType = acGridView.emGridType.FIXED;

                frm.View.AddDateEdit("DEL_DATE", "삭제일", "EHRC2TC6", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.LONG_DATE);

                frm.View.AddTextEdit("DEL_EMP", "삭제자코드", "58XXVB97", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

                if (frm.ShowDialog() == DialogResult.No)
                {
                    return;
                }


                foreach (DataRow row in qBiz.RefData.Tables["RQSTDT"].Rows)
                {
                    row["OVERWRITE"] = "1";
                }

                qBiz.Start();

            }
            else if (ex.ErrNumber == 300000)
            {
                acMessageBox.Show(acInfo.BizError.GetDesc(ex.ErrNumber), this.Caption, acMessageBox.emMessageBoxType.CONFIRM);
            }
            else
            {
                acMessageBox.Show(this, ex);
            }

        }

        void SetValidControl(acLayoutControl layout, bool isSdate, bool isShour, bool isSminute, bool isEdate, bool isEhour, bool isEminute, bool isampm, bool isWave, bool isSMinText, bool isEminText, bool isDirIn, bool isDirOut, string sHourValue = "")
        {

            DateTime nowDate = acDateEdit.GetNowDateFromServer();

            //시작일
            if (isSdate) 
            {
                acLayoutControlItem2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                layout.GetEditor("S_REQ_DATE").isRequired = isSdate;
                layout.GetEditor("S_REQ_DATE").Value = nowDate;
            }
            else if (!isSdate)
            {
                layout.GetEditor("S_REQ_DATE").Value = null;
                layout.GetEditor("S_REQ_DATE").isRequired = isSdate;
                acLayoutControlItem2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }

            //시작시간
            if (isShour) 
            { 
                acLayoutControlItem6.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                layout.GetEditor("S_HOUR").isRequired = isShour;

                if (sHourValue != "")
                {
                    layout.GetEditor("S_HOUR").Value = sHourValue;
                }
                else
                {
                    layout.GetEditor("S_HOUR").Value = null;
                }

            }
            else if (!isShour) 
            {
                layout.GetEditor("S_HOUR").Value = null;
                layout.GetEditor("S_HOUR").isRequired = isShour;
                acLayoutControlItem6.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }

            //시작분
            if (isSminute)
            {
                acLayoutControlItem7.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                layout.GetEditor("S_MINUTE").isRequired = isSminute;
            }
            else if (!isSminute)
            {
                layout.GetEditor("S_MINUTE").Value = null;
                layout.GetEditor("S_MINUTE").isRequired = isSminute;
                acLayoutControlItem7.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }

            //종료일
            if (isEdate)
            {
                acLayoutControlItem4.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                layout.GetEditor("E_REQ_DATE").isRequired = isEdate;
                layout.GetEditor("E_REQ_DATE").Value = nowDate;
            }
            else if (!isEdate)
            {
                layout.GetEditor("E_REQ_DATE").Value = null;
                layout.GetEditor("E_REQ_DATE").isRequired = isEdate;
                acLayoutControlItem4.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }

            //종료시간
            if (isEhour)
            {
                acLayoutControlItem8.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                layout.GetEditor("E_HOUR").isRequired = isEhour;
            }
            else if (!isEhour)
            {
                layout.GetEditor("E_HOUR").Value = null;
                layout.GetEditor("E_HOUR").isRequired = isEhour;
                acLayoutControlItem8.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }

            //종료분
            if (isEminute)
            {
                acLayoutControlItem9.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                layout.GetEditor("E_MINUTE").isRequired = isEminute;
            }
            else if (!isEminute)
            {
                layout.GetEditor("E_MINUTE").Value = null;
                layout.GetEditor("E_MINUTE").isRequired = isEminute;
                acLayoutControlItem9.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }

            //오전오후
            if (isampm)
            {
                acLayoutControlItem5.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                layout.GetEditor("REQ_AMPM").isRequired = isampm;
            }
            else if (!isampm)
            {
                layout.GetEditor("REQ_AMPM").Value = null;
                layout.GetEditor("REQ_AMPM").isRequired = isampm;
                acLayoutControlItem5.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }

            //물결
            if (isWave)
            {
                acLayoutControlItem3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            }
            else if (!isWave)
            {
                //layout.GetEditor("S_REQ_DATE").Value = null;
                //layout.GetEditor("S_REQ_DATE").isRequired = isSdate;
                acLayoutControlItem3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }

            //시작분(text)
            if (isSMinText)
            {
                acLayoutControlItem11.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                layout.GetEditor("S_MIN_TEXT").isRequired = isSMinText;
                layout.GetEditor("S_MIN_TEXT").Value = "30";
            }
            else if (!isSMinText)
            {
                layout.GetEditor("S_MIN_TEXT").Value = null;
                layout.GetEditor("S_MIN_TEXT").isRequired = isSMinText;
                acLayoutControlItem11.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }

            //종료분(text)
            if (isEminText)
            {
                acLayoutControlItem12.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                layout.GetEditor("E_MIN_TEXT").isRequired = isEminText;
            }
            else if (!isEminText)
            {
                layout.GetEditor("E_MIN_TEXT").Value = null;
                layout.GetEditor("E_MIN_TEXT").isRequired = isEminText;
                acLayoutControlItem12.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }

            //직출여부
            if (isDirIn)
            {
                acLayoutControlItem17.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            }
            else
            {
                layout.GetEditor("IS_DIR_IN").Value = null;
                acLayoutControlItem17.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }

            //직퇴여부
            if (isDirOut)
            {
                acLayoutControlItem18.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            }
            else
            {
                layout.GetEditor("IS_DIR_OUT").Value = null;
                acLayoutControlItem18.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
        }

        void SetTime(acLayoutControl layout, object value, string type)
        {
            if (layout.GetEditor("WORK_CODE").Value == null) return;

            DataRow[] workRows2 = _WorkSet.Tables["RSLTDT"].Select("WORK_CODE = '" + layout.GetEditor("WORK_CODE").Value.ToString() + "'");

            if (workRows2.Length == 1)
            {
                if (workRows2[0]["IS_PRE"].ToString() == "1")
                {
                    if (value.toDateString("yyyyMMdd").toInt() < acDateEdit.GetNowDateFromServer().toDateString("yyyyMMdd").toInt())
                    {
                        layout.GetEditor(type).Value = acDateEdit.GetNowDateFromServer();
                    }
                }
            }

            layout.GetEditor("REQ_MINUTE").Value = SetReqMinute();
        }

        string SetReqMinute()
        {
            if (acLayoutControl1.GetEditor("S_REQ_DATE").Value == null) return "";
            if (acLayoutControl1.GetEditor("E_REQ_DATE").Value == null) return "";
            if (acLayoutControl1.GetEditor("S_HOUR").Value == null) return "";
            if (acLayoutControl1.GetEditor("E_HOUR").Value == null) return "";

            bool isSelectMin = false;
            if (acLayoutControl1.GetEditor("S_MINUTE").Value != null
                && acLayoutControl1.GetEditor("E_MINUTE").Value != null)
            {
                isSelectMin = true;
            }

            bool isTextMin = false;
            if (acLayoutControl1.GetEditor("S_MIN_TEXT").Value != null
                && acLayoutControl1.GetEditor("E_MIN_TEXT").Value != null)
            {
                isTextMin = true;
            }

            string sYear = acLayoutControl1.GetEditor("S_REQ_DATE").Value.ToString().Substring(0, 4);
            string sMonth = acLayoutControl1.GetEditor("S_REQ_DATE").Value.ToString().Substring(4, 2);
            string SDay = acLayoutControl1.GetEditor("S_REQ_DATE").Value.ToString().Substring(6, 2);

            string eYear = acLayoutControl1.GetEditor("E_REQ_DATE").Value.ToString().Substring(0, 4);
            string eMonth = acLayoutControl1.GetEditor("E_REQ_DATE").Value.ToString().Substring(4, 2);
            string eDay = acLayoutControl1.GetEditor("E_REQ_DATE").Value.ToString().Substring(6, 2);

            DateTime StartTime = DateTime.Now;
            DateTime EndTime = DateTime.Now;

            if (isSelectMin)
            {
                StartTime = new DateTime(sYear.toInt(), sMonth.toInt(), SDay.toInt(), acLayoutControl1.GetEditor("S_HOUR").Value.toInt(), acLayoutControl1.GetEditor("S_MINUTE").Value.toInt(), 0);
                EndTime = new DateTime(eYear.toInt(), eMonth.toInt(), eDay.toInt(), acLayoutControl1.GetEditor("E_HOUR").Value.toInt(), acLayoutControl1.GetEditor("E_MINUTE").Value.toInt(), 0);
            }
            else if (isTextMin)
            {
                StartTime = new DateTime(sYear.toInt(), sMonth.toInt(), SDay.toInt(), acLayoutControl1.GetEditor("S_HOUR").Value.toInt(), acLayoutControl1.GetEditor("S_MIN_TEXT").Value.toInt(), 0);
                EndTime = new DateTime(eYear.toInt(), eMonth.toInt(), eDay.toInt(), acLayoutControl1.GetEditor("E_HOUR").Value.toInt(), acLayoutControl1.GetEditor("E_MIN_TEXT").Value.toInt(), 0);
            }
            else
            {
                return "";
            }

            //if (StartTime.Hour > EndTime.Hour)
            //{
            //    EndTime = EndTime.AddDays(1);
            //}

            int idleTime = 0;

            foreach (DataRow row in _IdleSet.Tables["RSLTDT"].Rows)
            {
                string sIdleHour = row["IDLE_START_TIME"].ToString().Substring(0, 2);
                string sIdleMinute = row["IDLE_START_TIME"].ToString().Substring(2, 2);

                string eIdleHour = row["IDLE_END_TIME"].ToString().Substring(0, 2);
                string eIdleMinute = row["IDLE_END_TIME"].ToString().Substring(2, 2);

                DateTime idleStartTime = new DateTime(StartTime.Year, StartTime.Month, StartTime.Day, sIdleHour.toInt(), sIdleMinute.toInt(), 0);
                DateTime idleEndTime = new DateTime(StartTime.Year, StartTime.Month, StartTime.Day, eIdleHour.toInt(), eIdleMinute.toInt(), 0);

                if (sIdleHour == "00"
                    && StartTime.Day != EndTime.Day)
                {
                    idleStartTime = idleStartTime.AddDays(1);
                    idleEndTime = idleEndTime.AddDays(1);
                }

                TimeSpan idleTs = new TimeSpan();

                if (idleStartTime < StartTime && idleEndTime > StartTime)
                {
                    //정례화 시작시간이 신청시작시간보다 작거나 같고 정례화 종료시간이 신청시작시간보다 클떄
                    idleTs = idleEndTime.Subtract(StartTime);

                }
                else if (idleStartTime >= StartTime && idleEndTime <= EndTime)
                {
                    //정례화 시작시간 종료시간이 신청시간사이에 포함될때
                    idleTs = idleEndTime.Subtract(idleStartTime);
                }
                else if (idleStartTime < EndTime && idleEndTime > EndTime)
                {
                    //정례화 시작시간이 신청종료시간보다 작고 정례화 종료시간이 신청종료시간보다 클때
                    idleTs = EndTime.Subtract(idleStartTime);
                }
                else if (idleStartTime <= StartTime && idleEndTime >= EndTime)
                {
                    //정례화 시간이 신청시간보다 클때
                    idleTs = EndTime.Subtract(StartTime);
                }

                idleTime = idleTime + idleTs.TotalMinutes.toInt();
            }

            TimeSpan ts = EndTime.Subtract(StartTime);

            return (ts.TotalMinutes.toInt() - idleTime).ToString();
        }

        bool DayVaildCheck(acLayoutControl layout, object value, string stdName)
        {
            if (layout.GetEditor(stdName).Value == null) return true;

            switch (stdName)
            {
                case "S_REQ_DATE":

                    if (layout.GetEditor(stdName).Value.toInt() > value.toInt())
                    {
                        return false;
                    }

                    break;

                case "E_REQ_DATE":

                    if (layout.GetEditor(stdName).Value.toInt() < value.toInt())
                    {
                        return false;
                    }

                    break;
            }


            return true;
        }

        bool TimeValidCheck(acLayoutControl layout, string inputType)
        {
            if (layout.GetEditor("S_HOUR").Value == null
                || layout.GetEditor("E_HOUR").Value == null)
            {
                return true;
            }

            string sYear = layout.GetEditor("S_REQ_DATE").Value.ToString().Substring(0, 4);
            string sMonth = layout.GetEditor("S_REQ_DATE").Value.ToString().Substring(4, 2);
            string sDay = layout.GetEditor("S_REQ_DATE").Value.ToString().Substring(6, 2);
            string sHour = layout.GetEditor("S_HOUR").Value.ToString();
            string sMin = "";

            string eYear = layout.GetEditor("E_REQ_DATE").Value.ToString().Substring(0, 4);
            string eMonth = layout.GetEditor("E_REQ_DATE").Value.ToString().Substring(4, 2);
            string eDay = layout.GetEditor("E_REQ_DATE").Value.ToString().Substring(6, 2);
            string eHour = layout.GetEditor("E_HOUR").Value.ToString();
            string eMin = "";


            if (inputType == "F")
            {
                if (layout.GetEditor("S_MIN_TEXT").Value == null
                    || layout.GetEditor("E_MIN_TEXT").Value == null)
                {
                    string day1 = layout.GetEditor("S_REQ_DATE").Value.ToString();
                    string hour1 = layout.GetEditor("S_HOUR").Value.ToString().PadLeft(2, '0');
                    string day2 = layout.GetEditor("E_REQ_DATE").Value.ToString();
                    string hour2 = layout.GetEditor("E_HOUR").Value.ToString().PadLeft(2, '0');

                    string date1 = day1 + hour1;
                    string date2 = day2 + hour2;

                    if (date1.toInt() > date2.toInt())
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }

                sMin = layout.GetEditor("S_MIN_TEXT").Value.ToString();
                eMin = layout.GetEditor("E_MIN_TEXT").Value.ToString();
            }
            else if (inputType == "B"
                    || inputType == "D"
                    || inputType == "E")
            {
                if (layout.GetEditor("S_MINUTE").Value == null
                    || layout.GetEditor("E_MINUTE").Value == null)
                {
                    string day1 = layout.GetEditor("S_REQ_DATE").Value.ToString();
                    string hour1 = layout.GetEditor("S_HOUR").Value.ToString().PadLeft(2, '0');
                    string day2 = layout.GetEditor("E_REQ_DATE").Value.ToString();
                    string hour2 = layout.GetEditor("E_HOUR").Value.ToString().PadLeft(2, '0');

                    string date1 = day1 + hour1;
                    string date2 = day2 + hour2;

                    if (date1.toInt() > date2.toInt())
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }

                sMin = layout.GetEditor("S_MINUTE").Value.ToString();
                eMin = layout.GetEditor("E_MINUTE").Value.ToString();
            }
            else
            {
                return true;
            }


            DateTime sDateTime = new DateTime(sYear.toInt(), sMonth.toInt(), sDay.toInt(), sHour.toInt(), sMin.toInt(), 0);
            DateTime eDateTime = new DateTime(eYear.toInt(), eMonth.toInt(), eDay.toInt(), eHour.toInt(), eMin.toInt(), 0);

            if (sDateTime > eDateTime)
            {
                return false;
            }

            return true;
        }

        void SetItemSize(acLayoutControlItem item, int iMinus = 0)
        {
            item.SizeConstraintsType = SizeConstraintsType.Custom;

            int margin = (DevExpress.Utils.AppearanceObject.DefaultFont.Size.toInt() - acInfo.DefaultFont.Size.toInt()) * 10;
            int itemHeight = item.Size.Height;
            int width = item.TextSize.Width + 150 + margin - iMinus;

            item.MinSize = new System.Drawing.Size(width, itemHeight);

            item.MaxSize = new System.Drawing.Size(width, itemHeight);

            item.Size = new System.Drawing.Size(width, itemHeight);
        }

        private DataSet dsEmp = null;
        private void acSimpleButton1_Click(object sender, EventArgs e)
        {
            //참조자 추가
            if (!base.ChildFormContains("CC_NEW"))
            {

                WOR01A_D1A frm = new WOR01A_D1A(_LinkData, dsEmp);

                frm.DialogMode = BaseMenuDialog.emDialogMode.OPEN;

                base.ChildFormAdd("CC_NEW", frm);

                frm.ParentControl = this;

                //frm.Show(this);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    dsEmp = frm.OutputData as DataSet;
                    acLayoutControl1.GetEditor("CC_EMP").Value = dsEmp.Tables["RQSTDT"].Rows[0]["CC_EMP"];
                }

            }
            else
            {

                base.ChildFormFocus("CC_NEW");

            }
        }
    }
}