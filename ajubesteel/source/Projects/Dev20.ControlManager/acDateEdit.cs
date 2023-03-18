using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.ComponentModel;
using System.Data;
using DevExpress.XtraEditors;
using System.Windows.Forms;
using BizManager;
using System.Globalization;

namespace ControlManager
{


    public class acDateEdit : DevExpress.XtraEditors.DateEdit, IBaseEditControl
    {
        public class acDateEditInstantResult
        {
            public DialogResult DialogResult = DialogResult.None;

            public DateTime DateTime = DateTime.MinValue;


        }

        public acDateEdit()
            : base()
        {
            try
            {
                if (!acInfo.SysConfig.GetSysConfigByMemory("DATE_CULTURE").isNullOrEmpty())
                {
                    CultureInfo culture = new CultureInfo(acInfo.SysConfig.GetSysConfigByMemory("DATE_CULTURE"));
                    this.Properties.Mask.Culture = culture;
                }

                if (!acInfo.SysConfig.GetSysConfigByMemory("DATE_MASK").isNullOrEmpty())
                {
                    this.Properties.Mask.EditMask = acInfo.SysConfig.GetSysConfigByMemory("DATE_MASK");
                    this.Properties.Mask.UseMaskAsDisplayFormat = true;
                }
            }
            catch { }

            this.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;

            this.GotFocus += new EventHandler(acDateEdit_GotFocus);
            this.LostFocus += new EventHandler(acDateEdit_LostFocus);

        }

        void acDateEdit_LostFocus(object sender, EventArgs e)
        {
            if (acInfo.SysConfig.GetSysConfigByMemory("FOCUS_EDIT_ENABLED").toBoolean())
            {
                this.SetColor();

            }
        }

        void acDateEdit_GotFocus(object sender, EventArgs e)
        {
            if (acInfo.SysConfig.GetSysConfigByMemory("FOCUS_EDIT_ENABLED").toBoolean())
            {
                this.Properties.Appearance.BackColor = acInfo.SysConfig.GetSysConfigByMemory("FOCUS_EDIT_BACKCOLOR").toColor();

                this.Properties.Appearance.ForeColor = acInfo.SysConfig.GetSysConfigByMemory("FOCUS_EDIT_FORECOLOR").toColor();

                this.Properties.Appearance.Options.UseBackColor = true;

            }
        }


        /// <summary>
        /// 작업시작시간을 반환
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static TimeSpan GetWorkStartTime(DateTime date)
        {

            try
            {

                string confName = null;

                if (date.DayOfWeek == DayOfWeek.Sunday)
                {
                    //일요일

                    confName = "SUN_WORK_TIME";

                }
                else if (date.DayOfWeek == DayOfWeek.Saturday)
                {
                    //토요일
                    confName = "SAT_WORK_TIME";

                }
                else
                {
                    //평일

                    confName = "NOR_WORK_TIME";
                }

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("CONF_SECTION", typeof(String)); //
                paramTable.Columns.Add("CONF_NAME", typeof(String)); //

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["CONF_SECTION"] = "SYS";
                paramRow["CONF_NAME"] = confName;
                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);


                DataSet resultSet = BizRun.QBizRun.ExecuteService(GetClassName(), "CTRL", "GET_SYS_CONFIG", paramSet, "RQSTDT", "RSLTDT");

                //DataSet resultSet = BizManager.acControls.GET_SYS_CONFIG(paramSet);

                string value = resultSet.Tables["RSLTDT"].Rows[0]["CONF_VALUE"].toStringNull();

                string[] values = value.Split(',');

                return values[0].toTimeSpan();


            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        /// <summary>
        /// 작업종료시간을 반환
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static TimeSpan GetWorkEndTime(DateTime date)
        {

            try
            {

                string confName = null;

                if (date.DayOfWeek == DayOfWeek.Sunday)
                {
                    //일요일

                    confName = "SUN_WORK_TIME";

                }
                else if (date.DayOfWeek == DayOfWeek.Saturday)
                {
                    //토요일
                    confName = "SAT_WORK_TIME";

                }
                else
                {
                    //평일

                    confName = "NOR_WORK_TIME";
                }

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("CONF_SECTION", typeof(String)); //
                paramTable.Columns.Add("CONF_NAME", typeof(String)); //

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["CONF_SECTION"] = "SYS";
                paramRow["CONF_NAME"] = confName;
                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);


                DataSet resultSet = BizRun.QBizRun.ExecuteService(GetClassName(), "CTRL", "GET_SYS_CONFIG", paramSet, "RQSTDT", "RSLTDT");
                //DataSet resultSet = BizManager.acControls.GET_SYS_CONFIG(paramSet);

                string value = resultSet.Tables["RSLTDT"].Rows[0]["CONF_VALUE"].toStringNull();

                string[] values = value.Split(',');

                return values[1].toTimeSpan();


            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



        public class StartEndDateTime
        {
            public DateTime StartDate = DateTime.MinValue;
            public DateTime EndDate = DateTime.MinValue;
        }

        public static List<StartEndDateTime> SplitDateTime(DateTime fromDateTime, DateTime toDateTime, int splitDay)
        {
            List<StartEndDateTime> dateList = new List<StartEndDateTime>();

            if (fromDateTime > toDateTime)
            {
                return dateList;
            }



            DateTime loopDate = fromDateTime;

            while (loopDate <= toDateTime)
            {
                StartEndDateTime startEndDt = new StartEndDateTime();

                startEndDt.StartDate = loopDate;

                if (loopDate.AddDays(splitDay) < toDateTime)
                {

                    startEndDt.EndDate = loopDate.AddDays(splitDay);

                }
                else
                {
                    startEndDt.EndDate = toDateTime;
                }

                dateList.Add(startEndDt);

                loopDate = loopDate.AddDays(splitDay + 1);

            }

            return dateList;

        }

        /// <summary>
        /// 점심시간 저녁시간을 뺀 실적(정규시간, 잔업시간) 시간을 반환한다.
        /// </summary>
        /// <param name="st"></param>
        /// <param name="ed"></param>
        /// <returns></returns>
        public static void GetActTime(DateTime workDate, DateTime st, DateTime ed, out double manTime, out double otTime)
        {


            double lunchMinusMin = 0;
            double offMinusMin = 0;
            double otMinusMin = 0;

            if (st >= ed)
            {
                manTime = 0;
                otTime = 0;

                return;
            }

            DateTime edx = ed;

            bool nextDate = false;

            if (st.Year != ed.Year
                || st.Month != ed.Month
                || st.Day != ed.Day)
            {
                //날짜가 다르면 완료일 23:59:59
                edx = new DateTime(st.Year, st.Month, ed.Day, 23, 59, 59);

                nextDate = true;

            }

            //점심시간 제외

            if (st.TimeOfDay <= acInfo.SysConfig.LUNCH_START_TIME && acInfo.SysConfig.LUNCH_END_TIME <= edx.TimeOfDay)
            {
                lunchMinusMin += Math.Abs(acInfo.SysConfig.LUNCH_END_TIME.Subtract(acInfo.SysConfig.LUNCH_START_TIME).TotalMinutes);

            }
            else if (st.TimeOfDay <= acInfo.SysConfig.LUNCH_START_TIME && edx.TimeOfDay <= acInfo.SysConfig.LUNCH_END_TIME && edx.TimeOfDay >= acInfo.SysConfig.LUNCH_START_TIME)
            {
                lunchMinusMin += Math.Abs(edx.TimeOfDay.Subtract(acInfo.SysConfig.LUNCH_START_TIME).TotalMinutes);

            }
            else if (st.TimeOfDay <= acInfo.SysConfig.LUNCH_END_TIME && acInfo.SysConfig.LUNCH_END_TIME <= edx.TimeOfDay)
            {
                lunchMinusMin += Math.Abs(acInfo.SysConfig.LUNCH_END_TIME.Subtract(st.TimeOfDay).TotalMinutes);

            }


            //저녁시간 제외

            if (st.TimeOfDay <= acInfo.SysConfig.OFF_START_TIME && acInfo.SysConfig.OFF_END_TIME <= edx.TimeOfDay)
            {
                offMinusMin += Math.Abs(acInfo.SysConfig.OFF_END_TIME.Subtract(acInfo.SysConfig.OFF_START_TIME).TotalMinutes);

            }
            else if (st.TimeOfDay <= acInfo.SysConfig.OFF_START_TIME && edx.TimeOfDay <= acInfo.SysConfig.OFF_END_TIME && edx.TimeOfDay >= acInfo.SysConfig.OFF_START_TIME)
            {
                offMinusMin += Math.Abs(edx.TimeOfDay.Subtract(acInfo.SysConfig.OFF_START_TIME).TotalMinutes);

            }
            else if (st.TimeOfDay <= acInfo.SysConfig.OFF_END_TIME && acInfo.SysConfig.OFF_END_TIME <= edx.TimeOfDay)
            {
                offMinusMin += Math.Abs(acInfo.SysConfig.OFF_END_TIME.Subtract(st.TimeOfDay).TotalMinutes);

            }


            //잔업시간 계산


            if (acInfo.SysConfig.OT_START_TIME(workDate) <= acInfo.SysConfig.OT_END_TIME(workDate)) //잔업시작시간 <= 잔업완료시간
            {
                if (st.TimeOfDay <= acInfo.SysConfig.OT_START_TIME(workDate) //실적시작시간 <= 잔업시작시간
                    && acInfo.SysConfig.OT_END_TIME(workDate) <= edx.TimeOfDay) // 잔업종료시간 <= 실적완료시간(실적시작일과 날짜가 다르면 23:59)
                {
                    //잔업 시작시간 - 잔업 종료시간
                    otMinusMin += Math.Abs(acInfo.SysConfig.OT_START_TIME(workDate).Subtract(acInfo.SysConfig.OT_END_TIME(workDate)).TotalMinutes);

                }
                else if (st.TimeOfDay <= acInfo.SysConfig.OT_START_TIME(workDate) //실적시작시간 <= 잔업시작시간
                    && st.TimeOfDay >= acInfo.SysConfig.WK_START_TIME(workDate)
                    && edx.TimeOfDay <= acInfo.SysConfig.OT_END_TIME(workDate) //실적완료시간(실적시작일과 날짜가 다르면 23:59) <= 잔업종료시간
                    && edx.TimeOfDay >= acInfo.SysConfig.WK_END_TIME(workDate))
                {
                    //잔업시작시간 - 실적완료시간
                    otMinusMin += Math.Abs(acInfo.SysConfig.OT_START_TIME(workDate).Subtract(edx.TimeOfDay).TotalMinutes);

                }
                else if (acInfo.SysConfig.OT_END_TIME(workDate) <= st.TimeOfDay //잔업종료시간 <= 실적시작시간
                    && acInfo.SysConfig.OT_END_TIME(workDate) <= edx.TimeOfDay) //잔업종료시간 <= 실적완료시간(실적시작일과 날짜가 다르면 23:59)
                {
                    //실적시작시간 - 잔업종료시간
                    otMinusMin += Math.Abs(st.TimeOfDay.Subtract(acInfo.SysConfig.OT_END_TIME(workDate)).TotalMinutes);
                }

                ////////////////////////추가/////////////////////////
                else if (acInfo.SysConfig.OT_START_TIME(workDate) <= st.TimeOfDay //잔업시작시간 <= 실적시작시간
                && acInfo.SysConfig.OT_END_TIME(workDate) <= edx.TimeOfDay) //잔업종료시간 <= 실적완료시간(실적시작일과 날짜가 다르면 23:59)
                {
                    //실적시작시간 - 잔업종료시간
                    otMinusMin += Math.Abs(st.TimeOfDay.Subtract(acInfo.SysConfig.OT_END_TIME(workDate)).TotalMinutes);
                }
                else if (acInfo.SysConfig.OT_START_TIME(workDate) <= st.TimeOfDay //잔업시작시간 <= 실적시작시간
                    && acInfo.SysConfig.OT_END_TIME(workDate) >= edx.TimeOfDay) //잔업종료시간 >= 실적완료시간(실적시작일과 날짜가 다르면 23:59)
                {
                    //실적시작시간 - 실적완료시간
                    otMinusMin += Math.Abs(st.TimeOfDay.Subtract(edx.TimeOfDay).TotalMinutes);
                }
                ///////////////////////////////////////////////////
            }
            else
            {


                TimeSpan tempOtEndTime = new TimeSpan(24, 0, 0);



                if (st.TimeOfDay <= acInfo.SysConfig.OT_START_TIME(workDate) //실적시작시간 <= 잔업종료시간
                    && tempOtEndTime <= edx.TimeOfDay) //24시 <= 실적완료시간
                {
                    //잔업시작시간 - 24시
                    otMinusMin += Math.Abs(acInfo.SysConfig.OT_START_TIME(workDate).Subtract(tempOtEndTime).TotalMinutes);

                }
                else if (st.TimeOfDay <= acInfo.SysConfig.OT_START_TIME(workDate) //실적시작시간 <= 잔업종료시간
                        && edx.TimeOfDay <= tempOtEndTime) //실적완료시간 <= 24시
                {
                    if (acInfo.SysConfig.OT_START_TIME(workDate) < ed.TimeOfDay)// 잔업종료시간 < 실적완료시간
                    {
                        //잔업종료시간 - 24시
                        otMinusMin += Math.Abs(acInfo.SysConfig.OT_START_TIME(workDate).Subtract(ed.TimeOfDay).TotalMinutes);
                    }
                    else if (acInfo.SysConfig.OT_START_TIME(workDate) < edx.TimeOfDay) //잔업종료시간 < 실적완료시간
                    {
                        //잔업종료시간 - 24시
                        otMinusMin += Math.Abs(acInfo.SysConfig.OT_START_TIME(workDate).Subtract(tempOtEndTime).TotalMinutes);
                    }
                }
                else if (tempOtEndTime <= st.TimeOfDay //24시 <= 실적시작시간
                    && tempOtEndTime <= edx.TimeOfDay) //24시 <= 실적완료시간
                {
                    //
                    otMinusMin += Math.Abs(st.TimeOfDay.Subtract(tempOtEndTime).TotalMinutes);

                }

                ////////////////////////추가/////////////////////////
                else if (acInfo.SysConfig.OT_START_TIME(workDate) <= st.TimeOfDay) //잔업시작시간 <= 실적시작시간
                {
                    otMinusMin += Math.Abs(st.TimeOfDay.Subtract(edx.TimeOfDay).TotalMinutes);

                }



                if (nextDate == true)
                {
                    TimeSpan tempOtStartTime = new TimeSpan(0, 0, 0);

                    otMinusMin += Math.Abs(tempOtStartTime.Subtract(ed.TimeOfDay).TotalMinutes);
                }
                ///////////////////////////////////////////////////

            }





            TimeSpan actTime = ed.Subtract(st);


            otTime = otMinusMin;

            manTime = Math.Abs(actTime.TotalMinutes) - (lunchMinusMin + offMinusMin + otMinusMin);




        }

        ///// <summary>
        ///// 점심시간, 저녁시간을 고려한 실적완료시간을 계산한다.
        ///// </summary>
        ///// <param name="dt"></param>
        ///// <returns></returns>
        //public static DateTime GetActEndTime(DateTime st, DateTime ed)
        //{

        //    DateTime temp = ed;

        //    if (st.TimeOfDay < acDateEdit.LUNCH_START_TIME)
        //    {

        //        if (ed.TimeOfDay > acDateEdit.LUNCH_START_TIME)
        //        {
        //            temp = temp.AddMinutesEx(acDateEdit.LUNCH_END_TIME.Subtract(acDateEdit.LUNCH_START_TIME).TotalMinutes);
        //        }
        //    }

        //    if (st.TimeOfDay < acDateEdit.OFF_START_TIME)
        //    {

        //        if (ed.TimeOfDay > acDateEdit.OFF_START_TIME)
        //        {
        //            temp = temp.AddMinutesEx(acDateEdit.OFF_END_TIME.Subtract(acDateEdit.OFF_START_TIME).TotalMinutes);
        //        }
        //    }


        //    return temp;

        //}


        /// <summary>
        /// 두 날짜간의 분차이를 알아옵니다.
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public static double SubtractMinute(object start, object end)
        {

            try
            {

                DateTime startDate = (DateTime)start;

                DateTime endDate = (DateTime)end;

                TimeSpan time = endDate.Subtract(startDate);

                return time.TotalMinutes;

            }
            catch
            {
                return 0;
            }
        }

        protected override void OnEditorKeyDownProcessNullInputKeys(System.Windows.Forms.KeyEventArgs e)
        {
            if (e.Control == false && e.KeyCode == System.Windows.Forms.Keys.Tab)
            {
                this.ClosePopup();

                SendKeys.SendWait("{TAB}");

                return;


            }

            base.OnEditorKeyDownProcessNullInputKeys(e);
        }

        public static string GetFomattedDateTime(DateTime dt, string fmt)
        {
            string fmtStr = string.Empty;

            if (fmt.Contains("/"))
                fmtStr = dt.ToString("MM/dd", System.Globalization.CultureInfo.InvariantCulture);
            else
                fmtStr = dt.ToString(fmt);

            return fmtStr;
        }

        public static string GetFomattedDateTime(string str_dt, string fmt)
        {
            //if 
            DateTime dt = str_dt.toDateTime();

            string fmtStr = string.Empty;

            if (fmt.Contains("/"))
                fmtStr = dt.ToString("MM/dd", System.Globalization.CultureInfo.InvariantCulture);
            else
                fmtStr = dt.ToString(fmt);

            return fmtStr;
        }


        /// <summary>
        /// 두날짜간의 월리스트를 반환합니다.
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public static List<DateTime> GetDateMonthList(DateTime start, DateTime end)
        {
            List<DateTime> monthList = new List<DateTime>();

            DateTime cnt = start;

            while (cnt <= end)
            {
                monthList.Add(cnt);

                cnt = cnt.AddMonths(1);

            }

            return monthList;

        }

        /// <summary>
        /// 지정된 날짜의 시작일과 마지막일을 반환합니다.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        public static void GetDateStartEnd(DateTime value, out DateTime start, out DateTime end)
        {

            start = value.AddDays(-(value.Day - 1));

            end = start.AddDays(DateTime.DaysInMonth(start.Year, start.Month) - 1);

        }


        /// <summary>
        /// 현재월의 첫날을 반환합니다.
        /// </summary>
        /// <returns></returns>
        public static DateTime GetNowFirstDate()
        {
            return DateTime.Now.AddDays(-(DateTime.Now.Day - 1));
        }


        /// <summary>
        /// 현재 날짜의 첫달을 반환합니다.
        /// </summary>
        /// <returns></returns>
        public static DateTime GetNowFirstMonth()
        {
            return new DateTime(DateTime.Now.Year, 1, 1, 0, 0, 0, 0);
        }

        /// <summary>
        /// 현재 날짜의 첫달을 반환합니다.
        /// </summary>
        /// <returns></returns>
        public static DateTime GetNowFirstYear()
        {
            return new DateTime(DateTime.Now.Year, 1, 1, 0, 0, 0, 0);
        }


        /// <summary>
        /// 현재 날짜의 마지막달을 반환합니다.
        /// </summary>
        /// <returns></returns>
        public static DateTime GetNowLastMonth()
        {
            return new DateTime(DateTime.Now.Year, 12, 1, 0, 0, 0, 0);
        }

        /// <summary>
        /// 현재 날짜의 달을 반환합니다.
        /// </summary>
        /// <returns></returns>
        public static DateTime GetNowMonth()
        {
            return new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1, 0, 0, 0, 0);
        }


        /// <summary>
        /// 현재월의 마지막날을 반환합니다.
        /// </summary>
        /// <returns></returns>
        public static DateTime GetNowLastDate()
        {

            DateTime first = DateTime.Now.AddDays(-(DateTime.Now.Day - 1));

            return first.AddDays(DateTime.DaysInMonth(first.Year, first.Month) - 1);
        }

        public static DateTime StrToDatetime(string date)
        {
            string year = date.Substring(0, 4);

            string month = date.Substring(5, 2);

            string day = date.Substring(8, 2);

            DateTime dt = new DateTime(year.toInt(), month.toInt(), day.toInt());

            return dt;
        }

        public static List<DateTime> GetMonthList(DateTime value1, DateTime value2)
        {

            List<DateTime> result = new List<DateTime>();


            DateTime start = value1.GetFirstDate();

            DateTime end = value2.GetFirstDate();

            result.Add(start);

            DateTime item = start;

            while (true)
            {

                item = item.AddMonths(1);

                result.Add(item);

                if (item >= end)
                {

                    break;
                }
            }


            return result;


        }


        /// <summary>
        /// 선택된 날짜의 첫날을 반환합니다.
        /// </summary>
        /// <returns></returns>
        public DateTime GetFirstDate()
        {
            return this.DateTime.AddDays(-(this.DateTime.Day - 1));
        }

        /// <summary>
        /// 선택된 날짜의 마지막날을 반환합니다.
        /// </summary>
        /// <returns></returns>
        public DateTime GetLastDate()
        {

            DateTime first = this.DateTime.AddDays(-(this.DateTime.Day - 1));

            return first.AddDays(DateTime.DaysInMonth(first.Year, first.Month) - 1);
        }

        public static string GetClassName()
        {
            return "acDateEdit";
        }

        /// <summary>
        /// 서버컴퓨터의 현재날짜를 반환합니다.
        /// </summary>
        public static DateTime GetNowDateFromServer()
        {


            DataTable paramTable = new DataTable();

            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            DataSet resultSet = BizRun.QBizRun.ExecuteService(GetClassName(), "CTRL", "GetDateTimeNow", paramSet, "", "RSLTDT");
            //DataSet resultSet = BizManager.acControls.GetDateTimeNow();

            return (DateTime)resultSet.Tables["RSLTDT"].Rows[0]["DATETIME"];

        }


        public static acDateEditInstantResult ShowInstantForm(Control parent, string caption)
        {
            acDateEditInstantForm frm = new acDateEditInstantForm();

            frm.ParentControl = parent;

            frm.Text = caption;

            if (frm.ShowDialog() == DialogResult.OK)
            {

                DateTime dt = (DateTime)frm.OutputData;

                return new acDateEditInstantResult() { DateTime = dt, DialogResult = DialogResult.OK };


            }

            return new acDateEditInstantResult() { DateTime = DateTime.MinValue, DialogResult = DialogResult.Cancel };
        }



        public enum emTimeOfDayType
        {

            /// <summary>
            /// 없음
            /// </summary>
            NONE,

            /// <summary>
            /// 일의 시작
            /// </summary>
            START,

            /// <summary>
            /// 일의 끝
            /// </summary>
            END
        };

        private emTimeOfDayType _TimeOfDayType = emTimeOfDayType.NONE;


        /// <summary>
        /// 날짜값 반환시 시간형태를 설정합니다.
        /// </summary>
        [DefaultValue(emTimeOfDayType.NONE)]
        public emTimeOfDayType TimeOfDayType
        {
            get { return _TimeOfDayType; }
            set { _TimeOfDayType = value; }
        }

        public enum emTimeSelectMode
        {
            /// <summary>
            /// 없음
            /// </summary>
            NONE,
            /// <summary>
            /// 일 선택
            /// </summary>
            DAY,

            /// <summary>
            /// 월선택
            /// </summary>
            MONTH,

            /// <summary>
            /// 년선택
            /// </summary>
            YEAR
        };

        private emTimeSelectMode _TimeSelectMode = emTimeSelectMode.DAY;

        /// <summary>
        /// 날짜값 반환시 시간형태를 설정합니다.
        /// </summary>
        [DefaultValue(emTimeSelectMode.DAY)]
        public emTimeSelectMode TimeSelectMode
        {
            get { return _TimeSelectMode; }
            set
            {
                _TimeSelectMode = value;
                SetSelectMode();
            }
        }

        private void SetSelectMode()
        {
            switch (this._TimeSelectMode)
            {
                case emTimeSelectMode.DAY:
                    this.Properties.DisplayFormat.FormatString = "yyyy-MM-dd";
                    this.Properties.EditFormat.FormatString = "yyyy-MM-dd";
                    this.Properties.Mask.EditMask = "yyyy-MM-dd";
                    this.Properties.Mask.UseMaskAsDisplayFormat = true;
                    if (this._CreateParameterFormat == string.Empty)
                        this._CreateParameterFormat = "yyyyMMdd";
                    this.Properties.VistaCalendarViewStyle = VistaCalendarViewStyle.YearView;

                    break;

                case emTimeSelectMode.MONTH:
                    this.Properties.DisplayFormat.FormatString = "yyyy-MM";
                    this.Properties.EditFormat.FormatString = "yyyy-MM";
                    this.Properties.Mask.EditMask = "yyyy-MM";
                    this.Properties.Mask.UseMaskAsDisplayFormat = true;
                    if (this._CreateParameterFormat == string.Empty)
                        this._CreateParameterFormat = "yyyyMM";
                    this.Properties.VistaCalendarViewStyle = VistaCalendarViewStyle.YearView;

                    break;
                case emTimeSelectMode.YEAR:
                    this.Properties.DisplayFormat.FormatString = "yyyy";
                    this.Properties.EditFormat.FormatString = "yyyy";
                    this.Properties.Mask.EditMask = "yyyy";
                    this.Properties.Mask.UseMaskAsDisplayFormat = true;
                    if (this._CreateParameterFormat == string.Empty)
                        this._CreateParameterFormat = "yyyy";
                    this.Properties.VistaCalendarViewStyle = VistaCalendarViewStyle.YearsGroupView;
                    break;
            }
        }


        private string _CreateParameterFormat = null;

        /// <summary>
        /// 파라메터 생성시 포맷을 설정하거나 반환합니다.
        /// </summary>
        public string CreateParameterFormat
        {
            get { return _CreateParameterFormat; }
            set { _CreateParameterFormat = value; }
        }


        protected override void OnEditValueChanged()
        {


            //자동 DateTime 형식으로 변환
            if (this.EditValue is string)
            {
                string value = (string)this.EditValue;

                value = value.Replace("-", "");
                value = value.Replace(":", "");


                if (value.Length == 8)
                {
                    DateTime resultDataTime = new DateTime(System.Convert.ToInt32(value.Substring(0, 4)),
                                     System.Convert.ToInt32(value.Substring(4, 2)),
                                     System.Convert.ToInt32(value.Substring(6, 2)));

                    this.EditValue = resultDataTime;


                }
                else if (value.Length == 12)
                {
                    DateTime resultDataTime = new DateTime(
                            System.Convert.ToInt32(value.Substring(0, 4)),
                            System.Convert.ToInt32(value.Substring(4, 2)),
                            System.Convert.ToInt32(value.Substring(6, 2)),
                            System.Convert.ToInt32(value.Substring(8, 2)),
                            System.Convert.ToInt32(value.Substring(10, 2)),
                            0
                            );

                    this.EditValue = resultDataTime;

                }
                else if (value.Length == 14)
                {
                    DateTime resultDataTime = new DateTime(
                            System.Convert.ToInt32(value.Substring(0, 4)),
                            System.Convert.ToInt32(value.Substring(4, 2)),
                            System.Convert.ToInt32(value.Substring(6, 2)),
                            System.Convert.ToInt32(value.Substring(8, 2)),
                            System.Convert.ToInt32(value.Substring(10, 2)),
                            System.Convert.ToInt32(value.Substring(12, 2))
                            );

                    this.EditValue = resultDataTime;
                }
                else
                {

                    this.EditValue = null;
                }

            }
            else if (this.EditValue is DateTime)
            {

                DateTime value = (DateTime)this.EditValue;

                switch (this.TimeOfDayType)
                {

                    case emTimeOfDayType.NONE:

                        break;


                    case emTimeOfDayType.START:

                        value = value.Subtract(value.TimeOfDay);


                        break;

                    case emTimeOfDayType.END:

                        value = value.Subtract(value.TimeOfDay);

                        TimeSpan time = new TimeSpan(0, 23, 59, 59, 999);

                        value = value.Add(time);

                        break;
                }


                this.EditValue = value;


            }

            base.OnEditValueChanged();
        }

        protected override void OnEnabledChanged(EventArgs e)
        {
            base.OnEnabledChanged(e);

            this.SetColor();

        }


        protected override void OnCreateControl()
        {
            this.SetColor();

            base.OnCreateControl();
        }

        /// <summary>
        /// 속성에 따른 배경색 결정
        /// </summary>
        private void SetColor()
        {

            if (this.Enabled == true)
            {
                //필수 +  읽기전용
                if (_isRequired == true && _isReadyOnly == true)
                {
                    this.Properties.AppearanceReadOnly.BackColor = acInfo.ReadOnlyBackColor;

                    this.Properties.AppearanceReadOnly.ForeColor = acInfo.ReadOnlyForeColor;

                    this.Properties.AppearanceReadOnly.Options.UseBackColor = true;

                }
                //필수 
                else if (_isRequired == true && _isReadyOnly == false)
                {
                    this.Properties.Appearance.BackColor = acInfo.RequiredBackColor;

                    this.Properties.Appearance.ForeColor = acInfo.RequiredForeColor;

                    this.Properties.Appearance.Options.UseBackColor = true;
                }

                //읽기전용
                else if (_isRequired == false && _isReadyOnly == true)
                {
                    this.Properties.AppearanceReadOnly.BackColor = acInfo.ReadOnlyBackColor;

                    this.Properties.AppearanceReadOnly.ForeColor = acInfo.ReadOnlyForeColor;

                    this.Properties.AppearanceReadOnly.Options.UseBackColor = true;
                }
                else
                {
                    this.Properties.Appearance.BackColor = acInfo.StandardBackColor;

                    this.Properties.Appearance.ForeColor = acInfo.StandardForeColor;

                    this.Properties.Appearance.Options.UseBackColor = true;
                }

            }
            else
            {
                this.Properties.Appearance.BackColor = acInfo.ReadOnlyBackColor;

                this.Properties.Appearance.ForeColor = acInfo.ReadOnlyForeColor;

                this.Properties.Appearance.Options.UseBackColor = true;

                this.Properties.AppearanceReadOnly.BackColor = acInfo.ReadOnlyBackColor;

                this.Properties.AppearanceReadOnly.ForeColor = acInfo.ReadOnlyForeColor;

                this.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            }

            //this.Refresh();

        }

        #region IBaseControl 멤버


        public BaseEdit Editor
        {
            get
            {
                return this;
            }

        }




        private bool _isRequired = false;

        /// <summary>
        /// 필수입력 여부
        /// </summary>
        public bool isRequired
        {
            get
            {
                return _isRequired;
            }
            set
            {
                _isRequired = value;

                this.SetColor();

            }
        }

        private bool _isReadyOnly = false;


        /// <summary>
        /// 읽기전용 여부
        /// </summary>
        public bool isReadyOnly
        {
            get
            {
                return _isReadyOnly;
            }
            set
            {
                _isReadyOnly = value;

                this.Properties.ReadOnly = _isReadyOnly;

                this.SetColor();
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public object Value
        {
            get
            {
                //Format 변환

                if (!acChecker.isNull(this.EditValue))
                {

                    if (!string.IsNullOrEmpty(this._CreateParameterFormat))
                    {

                        string dateString = this.DateTime.ToString(this._CreateParameterFormat);

                        return dateString;
                    }
                    else
                    {
                        return this.DateTime;
                    }
                }
                else
                {

                    return null;
                }

            }
            set
            {
                if (this.Enabled == false)
                    return;

                this.EditValue = value;
            }
        }

        private string _ColumnName = null;

        /// <summary>
        /// 컬럼명
        /// </summary>
        public string ColumnName
        {
            get
            {
                return _ColumnName;
            }
            set
            {
                _ColumnName = value;
            }
        }

        public void Clear()
        {
            this.EditValue = null;
        }


        public void FocusEdit()
        {
            this.Focus();
        }


        private string _ToolTipID = null;

        public string ToolTipID
        {
            get
            {
                return _ToolTipID;
            }
            set
            {
                _ToolTipID = value;
            }
        }

        private bool _UseToolTipID = false;

        public bool UseToolTipID
        {
            get
            {
                return _UseToolTipID;
            }
            set
            {
                _UseToolTipID = value;
            }
        }

        private bool _isChanged = false;


        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool isChanged
        {
            get
            {
                return _isChanged;
            }
            set
            {
                _isChanged = value;
            }
        }


        #endregion
    }
}
