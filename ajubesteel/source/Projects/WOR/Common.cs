using BizManager;
using ControlManager;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WOR
{
    class Common
    {
        private static Common _Instance = null;

        internal static Common Instance
        {
            get
            {
                if (_Instance == null) _Instance = new Common();
                return _Instance;
            }
        }

        /// <summary>
        /// 입력일(완료일)과 현재 시간사이의 평일 존재 유무 확인
        /// 휴일만 존재하면 true 리턴
        /// </summary>
        /// <param name="endDate"></param>
        /// <param name="nowDateTime"></param>
        /// <returns></returns>
        public bool IsOnlyHoliday(DateTime endDate, DateTime nowDateTime)
        {
            //휴일 불러오기
            DataTable holidayTable = GetHolidays();
            DataTable breakDayTable = GetEmpBreakDay();

            //입력일(완료)로부터 오늘까지의 휴일을 구한다. 중간에 휴일이 아니면 입력 불가
            for (DateTime dt = endDate.AddDays(1); dt.Date<=nowDateTime.Date; dt = dt.AddDays(1))
            {
                ////현재 날짜가 휴일인지
                if (IsBreakDay(holidayTable, breakDayTable, dt, true) == false)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 휴일인지 확인
        /// </summary>
        /// <param name="holidayTable">휴일</param>
        /// <param name="breakDayTable">개인 휴일</param>
        /// <param name="inputDate">체크날짜</param>
        /// <param name="isIncludeWeekend">주말 체크여부</param>
        /// <returns></returns>
        private bool IsBreakDay(DataTable holidayTable, DataTable breakDayTable, DateTime inputDate, bool isIncludeWeekend)
        {

            try
            {
                string sDate = inputDate.ToString("yyyyMMdd");

                //휴무일에 포함되는지 체크
                if (holidayTable.AsEnumerable().Where(w => w["HOLI_DATE"].toStringEmpty() == sDate).Any())
                {
                    return true;
                }

                //개인 휴무일에 포함되는지 체크(연차,반차)
                //반차의 경우 오전 반차만
                if (breakDayTable.AsEnumerable().Where(w => w["STR_REQ_DATE"].toStringEmpty() == sDate
                                                    &&((w["WORK_CODE"].toStringEmpty() == "W05")       //연차
                                                        || (w["WORK_CODE"].toStringEmpty() == "W06"            //반차
                                                            && w["REQ_AMPM"].toStringEmpty() == "AM")))   //반차의 오전 반차만
                                                .Any())
                {
                    return true;
                }

                switch (inputDate.DayOfWeek)
                {
                    case DayOfWeek.Sunday:
                    case DayOfWeek.Saturday:
                        return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return false;
        }

        /// <summary>
        /// 휴일 가져오기
        /// </summary>
        /// <returns></returns>
        private DataTable GetHolidays()
        {
            return BizRun.QBizRun.ExecuteService(this, "WOR01A_SER3", acInfo.RefData, "RQSTDT", "RSLTDT").Tables["RSLTDT"];
        }

        private DataTable GetEmpBreakDay()
        {
            DataSet paramSet = new DataSet();
            DataTable paramTable = paramSet.Tables.Add("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String));
            paramTable.Columns.Add("EMP_CODE", typeof(String));
            paramTable.Columns.Add("REQ_STATE", typeof(String));
            paramTable.Columns.Add("OR_WORK_CODE1", typeof(String));
            paramTable.Columns.Add("OR_WORK_CODE2", typeof(String));

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["EMP_CODE"] = acInfo.UserID;
            paramRow["REQ_STATE"] = "2";    //승인완료 건
            paramRow["OR_WORK_CODE1"] = "W05";    //연차
            paramRow["OR_WORK_CODE2"] = "W06";    //반차
            paramTable.Rows.Add(paramRow);

            return BizRun.QBizRun.ExecuteService(this, "WOR01A_SER9", paramSet, "RQSTDT", "RSLTDT").Tables["RSLTDT"];
        }

    }
}
